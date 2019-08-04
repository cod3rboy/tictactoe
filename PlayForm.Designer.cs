namespace TicTacToe {
    partial class PlayForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.board = new System.Windows.Forms.GroupBox();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn21 = new System.Windows.Forms.Button();
            this.btn22 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn02 = new System.Windows.Forms.Button();
            this.btn01 = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.cpuMove = new System.Windows.Forms.RadioButton();
            this.playerMove = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.board.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Vs CPU";
            // 
            // board
            // 
            this.board.Controls.Add(this.btn20);
            this.board.Controls.Add(this.btn21);
            this.board.Controls.Add(this.btn22);
            this.board.Controls.Add(this.btn12);
            this.board.Controls.Add(this.btn11);
            this.board.Controls.Add(this.btn10);
            this.board.Controls.Add(this.btn02);
            this.board.Controls.Add(this.btn01);
            this.board.Controls.Add(this.btn00);
            this.board.Location = new System.Drawing.Point(38, 54);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(424, 357);
            this.board.TabIndex = 2;
            this.board.TabStop = false;
            this.board.Text = "Tic-Tac-Toe Board ";
            // 
            // btn20
            // 
            this.btn20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn20.Location = new System.Drawing.Point(84, 247);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(50, 50);
            this.btn20.TabIndex = 6;
            this.btn20.TabStop = false;
            this.btn20.Tag = "";
            this.btn20.UseVisualStyleBackColor = true;
            // 
            // btn21
            // 
            this.btn21.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn21.Location = new System.Drawing.Point(188, 247);
            this.btn21.Name = "btn21";
            this.btn21.Size = new System.Drawing.Size(50, 50);
            this.btn21.TabIndex = 6;
            this.btn21.TabStop = false;
            this.btn21.UseVisualStyleBackColor = true;
            // 
            // btn22
            // 
            this.btn22.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn22.Location = new System.Drawing.Point(296, 247);
            this.btn22.Name = "btn22";
            this.btn22.Size = new System.Drawing.Size(50, 50);
            this.btn22.TabIndex = 6;
            this.btn22.TabStop = false;
            this.btn22.UseVisualStyleBackColor = true;
            // 
            // btn12
            // 
            this.btn12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn12.Location = new System.Drawing.Point(296, 151);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(50, 50);
            this.btn12.TabIndex = 6;
            this.btn12.TabStop = false;
            this.btn12.UseVisualStyleBackColor = true;
            // 
            // btn11
            // 
            this.btn11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn11.Location = new System.Drawing.Point(188, 151);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(50, 50);
            this.btn11.TabIndex = 6;
            this.btn11.TabStop = false;
            this.btn11.UseVisualStyleBackColor = true;
            // 
            // btn10
            // 
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(84, 151);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(50, 50);
            this.btn10.TabIndex = 6;
            this.btn10.TabStop = false;
            this.btn10.UseVisualStyleBackColor = true;
            // 
            // btn02
            // 
            this.btn02.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn02.Location = new System.Drawing.Point(296, 62);
            this.btn02.Name = "btn02";
            this.btn02.Size = new System.Drawing.Size(50, 50);
            this.btn02.TabIndex = 6;
            this.btn02.TabStop = false;
            this.btn02.UseVisualStyleBackColor = true;
            // 
            // btn01
            // 
            this.btn01.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn01.Location = new System.Drawing.Point(188, 62);
            this.btn01.Name = "btn01";
            this.btn01.Size = new System.Drawing.Size(50, 50);
            this.btn01.TabIndex = 6;
            this.btn01.TabStop = false;
            this.btn01.UseVisualStyleBackColor = true;
            // 
            // btn00
            // 
            this.btn00.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn00.Location = new System.Drawing.Point(84, 62);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(50, 50);
            this.btn00.TabIndex = 6;
            this.btn00.TabStop = false;
            this.btn00.UseVisualStyleBackColor = true;
            // 
            // cpuMove
            // 
            this.cpuMove.AutoSize = true;
            this.cpuMove.Cursor = System.Windows.Forms.Cursors.No;
            this.cpuMove.Location = new System.Drawing.Point(142, 30);
            this.cpuMove.Name = "cpuMove";
            this.cpuMove.Size = new System.Drawing.Size(57, 21);
            this.cpuMove.TabIndex = 3;
            this.cpuMove.Text = "CPU";
            this.cpuMove.UseVisualStyleBackColor = true;
            // 
            // playerMove
            // 
            this.playerMove.AutoSize = true;
            this.playerMove.Checked = true;
            this.playerMove.Cursor = System.Windows.Forms.Cursors.No;
            this.playerMove.Location = new System.Drawing.Point(29, 30);
            this.playerMove.Name = "playerMove";
            this.playerMove.Size = new System.Drawing.Size(69, 21);
            this.playerMove.TabIndex = 3;
            this.playerMove.TabStop = true;
            this.playerMove.Text = "Player";
            this.playerMove.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cpuMove);
            this.groupBox2.Controls.Add(this.playerMove);
            this.groupBox2.Location = new System.Drawing.Point(133, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 103);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Move";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(254, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 39);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-4, 542);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 111);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "O";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "X";
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 648);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Play Game";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.board.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox board;
        private System.Windows.Forms.RadioButton cpuMove;
        private System.Windows.Forms.RadioButton playerMove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn21;
        private System.Windows.Forms.Button btn22;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn02;
        private System.Windows.Forms.Button btn01;
        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}