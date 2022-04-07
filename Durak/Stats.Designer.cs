namespace Durak
{
    partial class frmStats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPlayed = new System.Windows.Forms.Label();
            this.lblWon = new System.Windows.Forms.Label();
            this.lblLost = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayed
            // 
            this.lblPlayed.AutoSize = true;
            this.lblPlayed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayed.Location = new System.Drawing.Point(34, 72);
            this.lblPlayed.Name = "lblPlayed";
            this.lblPlayed.Size = new System.Drawing.Size(112, 17);
            this.lblPlayed.TabIndex = 0;
            this.lblPlayed.Text = "Games Played : ";
            // 
            // lblWon
            // 
            this.lblWon.AutoSize = true;
            this.lblWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWon.Location = new System.Drawing.Point(34, 101);
            this.lblWon.Name = "lblWon";
            this.lblWon.Size = new System.Drawing.Size(106, 17);
            this.lblWon.TabIndex = 1;
            this.lblWon.Text = "Games Won    :";
            // 
            // lblLost
            // 
            this.lblLost.AutoSize = true;
            this.lblLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLost.Location = new System.Drawing.Point(34, 130);
            this.lblLost.Name = "lblLost";
            this.lblLost.Size = new System.Drawing.Size(104, 17);
            this.lblLost.TabIndex = 2;
            this.lblLost.Text = "Games Lost    :";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(63, 34);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(54, 17);
            this.lblPlayer.TabIndex = 3;
            this.lblPlayer.Text = "Player";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(52, 177);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Stats";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 228);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblLost);
            this.Controls.Add(this.lblWon);
            this.Controls.Add(this.lblPlayed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stats";
            this.Load += new System.EventHandler(this.Stats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayed;
        private System.Windows.Forms.Label lblWon;
        private System.Windows.Forms.Label lblLost;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Button btnReset;
    }
}