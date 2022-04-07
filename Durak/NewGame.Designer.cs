namespace Durak
{
    partial class frmNewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewGame));
            this.optDeck52 = new System.Windows.Forms.RadioButton();
            this.optDeck36 = new System.Windows.Forms.RadioButton();
            this.optDeck20 = new System.Windows.Forms.RadioButton();
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // optDeck52
            // 
            this.optDeck52.AutoSize = true;
            this.optDeck52.BackColor = System.Drawing.Color.Transparent;
            this.optDeck52.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optDeck52.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDeck52.Location = new System.Drawing.Point(65, 82);
            this.optDeck52.Margin = new System.Windows.Forms.Padding(2);
            this.optDeck52.Name = "optDeck52";
            this.optDeck52.Size = new System.Drawing.Size(41, 21);
            this.optDeck52.TabIndex = 49;
            this.optDeck52.Text = "52";
            this.optDeck52.UseVisualStyleBackColor = false;
            // 
            // optDeck36
            // 
            this.optDeck36.AutoSize = true;
            this.optDeck36.BackColor = System.Drawing.Color.Transparent;
            this.optDeck36.Checked = true;
            this.optDeck36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optDeck36.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDeck36.Location = new System.Drawing.Point(65, 58);
            this.optDeck36.Margin = new System.Windows.Forms.Padding(2);
            this.optDeck36.Name = "optDeck36";
            this.optDeck36.Size = new System.Drawing.Size(41, 21);
            this.optDeck36.TabIndex = 48;
            this.optDeck36.TabStop = true;
            this.optDeck36.Text = "36";
            this.optDeck36.UseVisualStyleBackColor = false;
            // 
            // optDeck20
            // 
            this.optDeck20.AutoSize = true;
            this.optDeck20.BackColor = System.Drawing.Color.Transparent;
            this.optDeck20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optDeck20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDeck20.Location = new System.Drawing.Point(65, 34);
            this.optDeck20.Margin = new System.Windows.Forms.Padding(2);
            this.optDeck20.Name = "optDeck20";
            this.optDeck20.Size = new System.Drawing.Size(41, 21);
            this.optDeck20.TabIndex = 47;
            this.optDeck20.Text = "20";
            this.optDeck20.UseVisualStyleBackColor = false;
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.AutoSize = true;
            this.lblDeckSize.BackColor = System.Drawing.Color.Transparent;
            this.lblDeckSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDeckSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckSize.Location = new System.Drawing.Point(28, 11);
            this.lblDeckSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(123, 17);
            this.lblDeckSize.TabIndex = 46;
            this.lblDeckSize.Text = "Choose Deck Size";
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btnNewGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewGame.BackgroundImage")));
            this.btnNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewGame.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.Location = new System.Drawing.Point(44, 162);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(91, 38);
            this.btnNewGame.TabIndex = 50;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(25, 130);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(136, 20);
            this.txtName.TabIndex = 51;
            this.txtName.Text = "Player";
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(28, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(127, 17);
            this.lblName.TabIndex = 52;
            this.lblName.Text = "Enter Player Name";
            // 
            // frmNewGame
            // 
            this.AcceptButton = this.btnNewGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 212);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.optDeck52);
            this.Controls.Add(this.optDeck36);
            this.Controls.Add(this.optDeck20);
            this.Controls.Add(this.lblDeckSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "    Start A New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optDeck52;
        private System.Windows.Forms.RadioButton optDeck36;
        private System.Windows.Forms.RadioButton optDeck20;
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}