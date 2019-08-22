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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void BtnStart_Click(object sender, EventArgs e) {
            if (playerVsCPU.Checked) new DifficultyForm().Show(this);
            else new PlayForm().Show(this);
        }
    }
}
