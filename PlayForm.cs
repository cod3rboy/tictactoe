using System;
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
        private Difficulty level;
        private Game.TTTGame gameObject;

        private Random mRandom;

        public PlayForm(Difficulty level) {
            InitializeComponent();
            this.level = level;
            gameObject = new Game.TTTGame(3, 3);
            mRandom = new Random(DateTime.Now.Millisecond);
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

            // Determine whether CPU will play first move
            double p = mRandom.NextDouble();
            if (p > 0.5) MakeCPUMove();
        }
        private void MakePlayerMove(object sender, EventArgs e) {
            if (gameObject.IsGameOver) return;

            Button btn = (Button)sender;
            // Disable the Button and the board
            btn.Enabled = false;
            btn.Text = (Game.TTTGame.PLAYER_SYMBOL == Game.TTTGame.CellState.CROSS) ? "X" : "O";
            btn.Cursor = Cursors.No;
            gameObject.MakePlayerMove((Game.CellPos)btn.Tag);
            if (gameObject.IsGameOver) {
                GameOver();
                return;
            }

            MakeCPUMove();
        }

        private void MakeCPUMove() {
            board.Enabled = false;
            cpuMove.Checked = true;

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
            playerMove.Checked = true;
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
        }
    }
}
