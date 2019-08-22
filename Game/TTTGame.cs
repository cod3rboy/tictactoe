using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game {
    public struct CellPos { 
        public int row;
        public int col;
        public CellPos(int r, int c) {
            row = r; col = c;
        }
        public static bool operator==(CellPos a, CellPos b) {
            return a.row == b.row && a.col == b.col;
        }
        public static bool operator!=(CellPos a, CellPos b) {
            return a.row != b.row || a.col != b.col;
        }
    }
    public class InvalidMoveException : Exception {
        public InvalidMoveException(String msg) : base(msg) { }
    }
    public delegate void GameEvent(CellPos pos);
    public class TTTGame {

        // Gameboard representation
        public enum CellState {NIL, ZERO, CROSS};
        private int mRows;
        private int mColumns;
        private CellState[,] mGrid;

        // Flags for game states
        private bool mGameOver;
        private bool mPlayerWins;
        private bool mIsDraw;

        private bool mFirstCpuMove = true;

        // Symbols Assignment
        public static readonly CellState PLAYER1_SYMBOL = CellState.ZERO;
        public static readonly CellState PLAYER2_SYMBOL = CellState.CROSS;
        public static readonly CellState CPU_SYMBOL = CellState.CROSS;

        private CellState mWinnerSymbol;

        // Event
        public event GameEvent CpuMoveOver;

        public TTTGame(int gridRows, int gridColumns) {
            // Init Rows and Colums along with the grid
            mRows = gridRows;
            mColumns = gridColumns;
            mGrid = new CellState[mRows, mColumns];
            for(int i=0; i <= mGrid.GetUpperBound(0); i++) {
                for(int j=0; j <= mGrid.GetUpperBound(1); j++) {
                    mGrid[i, j] = CellState.NIL;
                }
            }
            // Init game states
            mGameOver = false;
            mPlayerWins = false;
            mIsDraw = false;

            mWinnerSymbol = CellState.NIL;
        }

        /**
         * Method returns grid cell positions where match has been made.
         * It returns null if no match has occurred yet.
         */
        public CellPos[] GetMatchPosition() {
            // Check for a Row or Column Match
            int i;
            for (i = 0; i < mRows; i++) if (RowMatch(i)) break;
            if (i < mRows) {
                CellPos[] matches = new CellPos[mColumns];
                for (int c = 0; c < mColumns; c++) matches[c] = new CellPos(i, c);
                return matches;
            }
            for (i = 0; i < mColumns; i++) if (ColumnMatch(i)) break;
            if(i < mColumns) {
                CellPos[] matches = new CellPos[mRows];
                for (int r = 0; r < mRows; r++) matches[r] = new CellPos(r, i);
                return matches;
            }

            // Check for Left Diagonal Match
            if (LeftDiagonalMatch()) {
                CellPos[] matches = new CellPos[mRows];
                for (int j = 0; j < mRows; j++) matches[j] = new CellPos(j, j);
                return matches;
            }
            // Check for Right Diagonal Match
            if (RightDiagonalMatch()) {
                CellPos[] matches = new CellPos[mRows];
                for (int j = 0, k = mRows - 1; j < mRows; j++, k--) matches[j] = new CellPos(j, k);
                return matches;
            }

            return null;
        }


        public void MakePlayerMove(CellPos position) {
            MakePlayerMove(position, PLAYER1_SYMBOL);
        }
        /**
         * This method is used to make move of the player into the grid.
         */
        public void MakePlayerMove(CellPos position, CellState symbol) {
            if (position.row < 0 || position.row >= mRows 
                || position.col < 0 || position.col >= mColumns 
                || mGrid[position.row, position.col] != CellState.NIL)
                throw new InvalidMoveException(String.Format("Invalid move at grid cell ({0}, {1})", position.row, position.col));
            mGrid[position.row, position.col] = symbol;
            // Update Game State
            UpdateGameState();
        }

        /**
         * This method is used to tell CPU to make its move into the grid.
         */
        public void MakeRandomCpuMove() {
            CellPos randMove = GetRandomCpuMove();
            mGrid[randMove.row, randMove.col] = CPU_SYMBOL;
            // Update Game State
            UpdateGameState();
            CpuMoveOver(randMove);
        }

        private CellPos GetRandomCpuMove() {
            Random rand = new Random(DateTime.Now.Millisecond);
            // Make Random Move for now
            int row, col;
            do {
                row = rand.Next(mRows);
                col = rand.Next(mColumns);
            } while (mGrid[row, col] != CellState.NIL);
            return new CellPos(row, col);
        }

        public void MakeCpuMove() {
            if (mFirstCpuMove) { // This prevents player from setting a row and a column match simultaneously
                // Center Cell row and col
                int cR = mRows / 2, cC = mColumns / 2;
                if (mGrid[cR, cC] == PLAYER1_SYMBOL) cC = cR = 0;
                mGrid[cR, cC] = CPU_SYMBOL;
                UpdateGameState();
                CpuMoveOver(new CellPos(cR, cC));
                mFirstCpuMove = false;
                return;
            }
            // Try to win
            for (int r = 0; r < mRows; r++) {
                for (int c = 0; c < mColumns; c++) {
                    CellPos movePos = new CellPos(r, c);
                    if (mGrid[r, c] == CellState.NIL && WinMoveOfCpu(movePos)) {
                        mGrid[r, c] = CPU_SYMBOL;
                        // Update Game State
                        UpdateGameState();
                        CpuMoveOver(movePos);
                        return;
                    }
                }
            }
            // Go Agressive
            for (int r = 0; r < mRows; r++) {
                for (int c = 0; c < mColumns; c++) {
                    CellPos movePos = new CellPos(r, c);
                    if (mGrid[r, c] == CellState.NIL && WinMoveOfPlayer(movePos)) {
                        mGrid[r, c] = CPU_SYMBOL;
                        // Update Game State
                        UpdateGameState();
                        CpuMoveOver(movePos);
                        return;
                    }
                }
            }
            CellPos randPos;
            int count = mRows; // Time To Live (TTL) count to prevent infinite loop
            do {
                randPos = GetRandomCpuMove();
                count--;
            } while (!BestMoveOfCpu(randPos) && count > 0);
            mGrid[randPos.row, randPos.col] = CPU_SYMBOL;
            UpdateGameState(); 
            CpuMoveOver(randPos);
        }
        private bool WinMoveOfPlayer(CellPos movePos) {
            return IsWinMove(movePos, PLAYER1_SYMBOL, CPU_SYMBOL);
        }
        private bool WinMoveOfCpu(CellPos movePos) {
            return IsWinMove(movePos, CPU_SYMBOL, PLAYER1_SYMBOL);
        }
        private bool IsWinMove(CellPos movePos, CellState mPlayerSymbol, CellState mOpponentSymbol) {

            // Check for best move row-wise
            int count = 0;
            for (int c = 0; c < mColumns; c++) {
                if (mGrid[movePos.row, c] == mOpponentSymbol) break;
                if(mGrid[movePos.row, c] == mPlayerSymbol) count++;
            }
            if (count == mColumns-1) return true;
            
            // Check for best move col-wise
            count = 0;
            for(int r=0; r < mRows; r++) {
                if (mGrid[r, movePos.col] == mOpponentSymbol) break;
                if (mGrid[r, movePos.col] == mPlayerSymbol) count++;
            }
            if (count == mRows-1) return true;

            // Check for diagonal move
            if (movePos.col == movePos.row) { // Check For Left Diagonal only when move is left diagonal element
                count = 0;
                for (int i=0; i < mRows; i++) {
                    if (mGrid[i, i] == mOpponentSymbol) break;
                    if (mGrid[i, i] == mPlayerSymbol) count++;
                }
                if (count == mRows-1) return true;
            }
            if(movePos.col + movePos.row == mRows - 1) { // Check for Right Diagonal only when move is right diagonal element
                count = 0;
                for(int i=0,j=mRows-1; i < mRows && j >= 0; i++, j--) {
                    if (mGrid[i, j] == mOpponentSymbol) break;
                    if (mGrid[i, j] == mPlayerSymbol) count++;
                }
                if (count == mRows-1) return true;
            }

            return false;
        }

        /**
         * Checks whether given move increases no of CPU symbol in given row or in given col or in diagonals.
         * If true then it is the best move of player otherwise not.
         */
        private bool BestMoveOfCpu(CellPos movePos) {
            // Check for row
            int count = 0;
            for (int c = 0; c < mColumns; c++) {
                if (mGrid[movePos.row, c] == CPU_SYMBOL) {
                    count++;
                } else if (mGrid[movePos.row, c] == PLAYER1_SYMBOL) {
                    count = 0;
                    break;
                }
            }
            if (count > 0) return true;
            
            // Check for column
            for(int r=0; r < mRows; r++) {
                if(mGrid[r, movePos.col] == CPU_SYMBOL) {
                    count++;
                }else if(mGrid[r, movePos.col] == PLAYER1_SYMBOL) {
                    count = 0;
                    break;
                }
            }

            if (count > 0) return true;

            // Check for diagonal
            if (movePos.col == movePos.row) { // Check For Left Diagonal only when move is left diagonal element
                count = 0;
                for (int i = 0; i < mRows; i++) {
                    if (mGrid[i, i] == CPU_SYMBOL) {
                        count++;
                    }else if(mGrid[i, i] == PLAYER1_SYMBOL) {
                        count = 0;
                        break;
                    }
                    if (count > 0) return true;
                }
                if (count == mRows - 1) return true;
            }
            if (movePos.col + movePos.row == mRows - 1) { // Check for Right Diagonal only when move is right diagonal element
                count = 0;
                for (int i = 0, j = mRows - 1; i < mRows && j >= 0; i++, j--) {
                    if (mGrid[i, j] == CPU_SYMBOL) {
                        count++;
                    }else if(mGrid[i, j] == PLAYER1_SYMBOL) {
                        count = 0;
                        break;
                    }
                    if (count > 0) return true;
                }
                if (count == mRows - 1) return true;
            }

            return false;
        }

        /** 
         * Check for win or tie conditions and update game state flags
         */
        private void UpdateGameState() {
            if (CheckWin()) {
                mGameOver = true;
                mPlayerWins = (mWinnerSymbol == PLAYER1_SYMBOL);
                return;
            }else if (!MoveExists()) {
                mGameOver = true;
                mIsDraw = true;
                return;
            }
        }

        /**
         * Checks for a Winner
         */
        private bool CheckWin() {
            bool win = false;
            // Check for a Row or Column Match
            for(int i=0; i<mRows; i++) {
                win = RowMatch(i);
                if (win) break;
                win = ColumnMatch(i);
                if(win) break;
            }
            // Check for a Diagonal Match
            if (!win) win = LeftDiagonalMatch() || RightDiagonalMatch();

            return win;
        }
        /**
         * Checks whether a move exists or not
         */
        private bool MoveExists() {
            for(int i=0; i<mRows; i++) {
                for(int j=0; j<mColumns; j++) {
                    if (mGrid[i, j] == CellState.NIL) return true;
                }
            }
            return false;
        }

        /**
         * Checks for a Row Match
         */
        private bool RowMatch(int row) {
            CellState lastSymbol = mGrid[row, 0];
            int i = 1;
            while(i < mColumns) {
                if (mGrid[row, i] == CellState.NIL || mGrid[row, i] != lastSymbol) break;
                i++;
            }
            bool match = !(i < mColumns);
            if (match) mWinnerSymbol = lastSymbol;
            return match; 
        }
        /**
         * Checks for a Column Match
         */
        private bool ColumnMatch(int col) {
            CellState lastSymbol = mGrid[0, col];
            int i = 1;
            while(i < mRows) {
                if (mGrid[i, col] == CellState.NIL || mGrid[i, col] != lastSymbol) break;
                i++;
            }
            bool match = !(i < mRows);
            if (match) mWinnerSymbol = lastSymbol;
            return match;
        }
        /**
         * Checks for a Left Diagonal Match
         */
        private bool LeftDiagonalMatch() {
            CellState ldSymbol = mGrid[0, 0];

            // Left Diagonal Match
            int l = 1;
            while(l < mRows) {
                if (mGrid[l, l] == CellState.NIL || mGrid[l, l] != ldSymbol) break;
                l++;
            }

            if (l == mRows) {
                mWinnerSymbol = ldSymbol;
                return true;
            }
            return false;
        }
        /**
         * Checks for a Right Diagonal Match
         */
        private bool RightDiagonalMatch() {
            CellState rdSymbol = mGrid[mRows - 1, 0];

            // Right Diagonal Match
            int c = 1;
            for (int r = mRows - 2; r >= 0; r--) {
                if (mGrid[r, c] == CellState.NIL || mGrid[r, c] != rdSymbol) break;
                c++;
            }

            if (c == mColumns) {
                mWinnerSymbol = rdSymbol;
                return true;
            }
            return false;
        }

        /**
         * Method to match any symbol agaist a winner symbol (if any).
         */
        public bool IsWinnerSymbol(CellState symbol) {
            if (mPlayerWins && symbol == PLAYER1_SYMBOL) return true;
            if (!mPlayerWins && !mIsDraw && symbol == PLAYER2_SYMBOL) return true;
            return false;
        }

        public bool IsGameOver {
            get {
                return mGameOver;
            }
        }
        public bool IsDraw {
            get {
                return mIsDraw;
            }
        }
        public bool PlayerWon {
            get {
                return mPlayerWins;
            }
        }
        public bool CpuWon {
            get {
                return !mPlayerWins && !mIsDraw;
            }
        }
    }
}
