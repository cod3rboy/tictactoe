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
    public partial class DifficultyForm : Form {
        public DifficultyForm() {
            InitializeComponent();
        }

        private void BtnEasy_Click(object sender, EventArgs e) {
            new PlayForm(PlayForm.Difficulty.EASY).Show(this.Owner);
            this.Dispose();
        }

        private void BtnMedium_Click(object sender, EventArgs e) {
            new PlayForm(PlayForm.Difficulty.MEDIUM).Show(this.Owner);
            this.Dispose();
        }

        private void BtnHard_Click(object sender, EventArgs e) {
            new PlayForm(PlayForm.Difficulty.HARD).Show(this.Owner);
            this.Dispose();
        }
    }
}
