using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe {
    public partial class PlayForm : Form {
        public enum Difficulty{EASY, MEDIUM, HARD}
        public enum Mode {PLAYERPLAYER, PLAYERCPU}
        private Difficulty level;
        private Mode mode;
        private Game.TTTGame gameObject;

        private Random mRandom;

        // Use this constructor to create Player vs CPU game
        public PlayForm(Difficulty level) {
            InitializeComponent();
            this.level = level;
            this.mode = Mode.PLAYERCPU;
            gameObject = new Game.TTTGame(3, 3);
            mRandom = new Random(DateTime.Now.Millisecond);
            lblMode.Text = "Player vs CPU";
            rbtnPlayer1.Text = "Player";
            rbtnPlayer2.Text = "CPU";
        }
        
        // Use this constructor to create Player vs Player game
        public PlayForm() {
            InitializeComponent();
            this.level = Difficulty.EASY; // No use in case of Player vs Player
            this.mode = Mode.PLAYERPLAYER;
            gameObject = new Game.TTTGame(3, 3);
            mRandom = new Random(DateTime.Now.Millisecond);
            lblMode.Text = "Player vs Player";
            rbtnPlayer1.Text = "Player 1";
            rbtnPlayer2.Text = "Player 2";
        }

        private void PlayForm_Load(object sender, EventArgs e) {
            // Attach tags to the buttons
            btn00.Tag = new Game.CellPos(0, 0);
            btn01.Tag = new Game.CellPos(0, 1);
            btn02.Tag = new Game.CellPos(0, 2);
            btn10.Tag = new Game.CellPos(1, 0);
            btn11.Tag = new Game.CellPos(1, 1);
            btn12.Tag = new Game.CellPos(1, 2);
            btn20.Tag = new Game.CellPos(2, 0);
            btn21.Tag = new Game.CellPos(2, 1);
            btn22.Tag = new Game.CellPos(2, 2);

            // Register Click Event Handler with the buttons
            btn00.Click += MakePlayerMove;
            btn01.Click += MakePlayerMove;
            btn02.Click += MakePlayerMove;
            btn10.Click += MakePlayerMove;
            btn11.Click += MakePlayerMove;
            btn12.Click += MakePlayerMove;
            btn20.Click += MakePlayerMove;
            btn21.Click += MakePlayerMove;
            btn22.Click += MakePlayerMove;

            // Register CPU Move over Event Handler with the Game Object
            gameObject.CpuMoveOver += CPUMoveCompleted;

            if(mode == Mode.PLAYERCPU) {
                // Determine whether CPU will play first move
                double p = mRandom.NextDouble();
                if (p > 0.5) MakeCPUMove();
            }
        }
        private void MakePlayerMove(object sender, EventArgs e) {
            if (gameObject.IsGameOver) return;

            Button btn = (Button)sender;
            if(mode == Mode.PLAYERCPU) {
                // Disable the Button and the board
                btn.Enabled = false;
                btn.Text = (Game.TTTGame.PLAYER1_SYMBOL == Game.TTTGame.CellState.CROSS) ? "X" : "O";
                btn.Cursor = Cursors.No;
                gameObject.MakePlayerMove((Game.CellPos)btn.Tag);
                if (gameObject.IsGameOver) {
                    GameOver();
                    return;
                }

                MakeCPUMove();

            }else if(mode == Mode.PLAYERPLAYER) {
                btn.Enabled = false;
                Game.TTTGame.CellState playerSymbol = Game.TTTGame.CellState.NIL;
                if (rbtnPlayer1.Checked) {
                    playerSymbol = Game.TTTGame.PLAYER1_SYMBOL;
                } else if (rbtnPlayer2.Checked) {
                    playerSymbol = Game.TTTGame.PLAYER2_SYMBOL;
                }
                btn.Text = (playerSymbol == Game.TTTGame.CellState.CROSS) ? "X" : "O";
                btn.Cursor = Cursors.No;
                if (rbtnPlayer2.Checked) rbtnPlayer1.Checked = true;
                else rbtnPlayer2.Checked = true;
                gameObject.MakePlayerMove((Game.CellPos)btn.Tag, playerSymbol);
                if (gameObject.IsGameOver) {
                    GameOver();
                    return;
                }
            }
        }

        private void MakeCPUMove() {
            board.Enabled = false;
            rbtnPlayer2.Checked = true;

            switch (level){
                case Difficulty.EASY:
                    gameObject.MakeRandomCpuMove();
                    break;
                case Difficulty.MEDIUM:
                    double p = mRandom.NextDouble();
                    if (p < 0.5) gameObject.MakeRandomCpuMove();
                    else gameObject.MakeCpuMove();
                    break;
                case Difficulty.HARD:
                    gameObject.MakeCpuMove();
                    break;
            }
        }

        private void CPUMoveCompleted(Game.CellPos cellPos) {
            Button btn = GetButtonAtPosition(cellPos);
            if (btn != null) {
                btn.Text = (Game.TTTGame.CPU_SYMBOL == Game.TTTGame.CellState.CROSS) ? "X" : "O";
                btn.Enabled = false;
                btn.Cursor = Cursors.No;
            }
            if (gameObject.IsGameOver) {
                GameOver();
                return;
            }
            board.Enabled = true;
            rbtnPlayer1.Checked = true;
        }

        private Button GetButtonAtPosition(Game.CellPos pos) {
            if (pos == (Game.CellPos)btn00.Tag) return btn00;
            if (pos == (Game.CellPos)btn01.Tag) return btn01;
            if (pos == (Game.CellPos)btn02.Tag) return btn02;
            if (pos == (Game.CellPos)btn10.Tag) return btn10;
            if (pos == (Game.CellPos)btn11.Tag) return btn11;
            if (pos == (Game.CellPos)btn12.Tag) return btn12;
            if (pos == (Game.CellPos)btn20.Tag) return btn20;
            if (pos == (Game.CellPos)btn21.Tag) return btn21;
            if (pos == (Game.CellPos)btn22.Tag) return btn22;
            return null;
        }

        private void MarkWinPosition() {
            Game.CellPos[] matches = gameObject.GetMatchPosition();
            foreach(Game.CellPos p in matches) {
                ((Button)GetButtonAtPosition(p)).BackColor = Color.Yellow;
            }
        }

        /**
         * Game is over and determine the result
         */
        private void GameOver() {
            if(mode == Mode.PLAYERCPU) {
                if (gameObject.PlayerWon) {
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "Hurrah! You won the match!";
                    MarkWinPosition();
                } else if (gameObject.CpuWon) {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Sorry! You lose the match!";
                    MarkWinPosition();
                } else if (gameObject.IsDraw) {
                    lblStatus.ForeColor = Color.Violet;
                    lblStatus.Text = "That was tough. It's a tie!";
                }
            }else if(mode == Mode.PLAYERPLAYER) {
                lblStatus.ForeColor = Color.Blue;
                if (gameObject.IsWinnerSymbol(Game.TTTGame.PLAYER1_SYMBOL)) {
                    lblStatus.Text = "Player 1 Winner";
                    MarkWinPosition();
                } else if (gameObject.IsWinnerSymbol(Game.TTTGame.PLAYER2_SYMBOL)) {
                    lblStatus.Text = "Player 2 Winner";
                    MarkWinPosition();
                } else if (gameObject.IsDraw) {
                    lblStatus.Text = "That was tough. It's a tie!";
                }
            }
        }
    }
}
