namespace Durak
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.lblDeck = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.pnlCPU = new System.Windows.Forms.Panel();
            this.lblTrump = new System.Windows.Forms.Label();
            this.pnlRiver = new System.Windows.Forms.Panel();
            this.pnlRiverCard6 = new System.Windows.Forms.Panel();
            this.pnlRiverCard1 = new System.Windows.Forms.Panel();
            this.pnlRiverCard5 = new System.Windows.Forms.Panel();
            this.pnlRiverCard4 = new System.Windows.Forms.Panel();
            this.pnlRiverCard3 = new System.Windows.Forms.Panel();
            this.pnlRiverCard2 = new System.Windows.Forms.Panel();
            this.lblAttack1 = new System.Windows.Forms.Label();
            this.lblAttack2 = new System.Windows.Forms.Label();
            this.lblAttack3 = new System.Windows.Forms.Label();
            this.lblAttack4 = new System.Windows.Forms.Label();
            this.lblAttack5 = new System.Windows.Forms.Label();
            this.lblDefend1 = new System.Windows.Forms.Label();
            this.lblDefend2 = new System.Windows.Forms.Label();
            this.lblDefend3 = new System.Windows.Forms.Label();
            this.lblDefend4 = new System.Windows.Forms.Label();
            this.lblDefend5 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.mmMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miStats = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAttack6 = new System.Windows.Forms.Label();
            this.lblDefend6 = new System.Windows.Forms.Label();
            this.btnPass = new System.Windows.Forms.Button();
            this.lblCPUText = new System.Windows.Forms.Label();
            this.lblPlayerText = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblTurnNum = new System.Windows.Forms.Label();
            this.pnlRiver.SuspendLayout();
            this.mmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeck
            // 
            this.lblDeck.AutoSize = true;
            this.lblDeck.BackColor = System.Drawing.Color.Transparent;
            this.lblDeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeck.ForeColor = System.Drawing.Color.White;
            this.lblDeck.Location = new System.Drawing.Point(65, 213);
            this.lblDeck.Name = "lblDeck";
            this.lblDeck.Size = new System.Drawing.Size(98, 20);
            this.lblDeck.TabIndex = 30;
            this.lblDeck.Text = "Cards Left:";
            this.lblDeck.Visible = false;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.White;
            this.lblPlayerName.Location = new System.Drawing.Point(187, 576);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(41, 20);
            this.lblPlayerName.TabIndex = 28;
            this.lblPlayerName.Text = "You";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.BackColor = System.Drawing.Color.Transparent;
            this.lblComputerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblComputerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerName.ForeColor = System.Drawing.Color.White;
            this.lblComputerName.Location = new System.Drawing.Point(187, 79);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(141, 20);
            this.lblComputerName.TabIndex = 26;
            this.lblComputerName.Text = "Computer Player";
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pnlPlayer.Location = new System.Drawing.Point(341, 515);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(584, 134);
            this.pnlPlayer.TabIndex = 24;
            this.pnlPlayer.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlPlayer.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlCPU
            // 
            this.pnlCPU.BackColor = System.Drawing.Color.Transparent;
            this.pnlCPU.Location = new System.Drawing.Point(334, 29);
            this.pnlCPU.Name = "pnlCPU";
            this.pnlCPU.Size = new System.Drawing.Size(584, 132);
            this.pnlCPU.TabIndex = 23;
            // 
            // lblTrump
            // 
            this.lblTrump.AutoSize = true;
            this.lblTrump.BackColor = System.Drawing.Color.Transparent;
            this.lblTrump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTrump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrump.ForeColor = System.Drawing.Color.White;
            this.lblTrump.Location = new System.Drawing.Point(35, 254);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTrump.Size = new System.Drawing.Size(59, 20);
            this.lblTrump.TabIndex = 47;
            this.lblTrump.Text = "Trump";
            this.lblTrump.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTrump.Visible = false;
            // 
            // pnlRiver
            // 
            this.pnlRiver.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiver.Controls.Add(this.pnlRiverCard6);
            this.pnlRiver.Controls.Add(this.pnlRiverCard1);
            this.pnlRiver.Controls.Add(this.pnlRiverCard5);
            this.pnlRiver.Controls.Add(this.pnlRiverCard4);
            this.pnlRiver.Controls.Add(this.pnlRiverCard3);
            this.pnlRiver.Controls.Add(this.pnlRiverCard2);
            this.pnlRiver.Location = new System.Drawing.Point(254, 275);
            this.pnlRiver.Name = "pnlRiver";
            this.pnlRiver.Size = new System.Drawing.Size(714, 140);
            this.pnlRiver.TabIndex = 52;
            // 
            // pnlRiverCard6
            // 
            this.pnlRiverCard6.AllowDrop = true;
            this.pnlRiverCard6.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard6.BackgroundImage")));
            this.pnlRiverCard6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard6.Location = new System.Drawing.Point(3, 3);
            this.pnlRiverCard6.Name = "pnlRiverCard6";
            this.pnlRiverCard6.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard6.TabIndex = 58;
            this.pnlRiverCard6.Visible = false;
            this.pnlRiverCard6.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard6.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlRiverCard1
            // 
            this.pnlRiverCard1.AllowDrop = true;
            this.pnlRiverCard1.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard1.BackgroundImage")));
            this.pnlRiverCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard1.Location = new System.Drawing.Point(122, 3);
            this.pnlRiverCard1.Name = "pnlRiverCard1";
            this.pnlRiverCard1.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard1.TabIndex = 53;
            this.pnlRiverCard1.Visible = false;
            this.pnlRiverCard1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlRiverCard5
            // 
            this.pnlRiverCard5.AllowDrop = true;
            this.pnlRiverCard5.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard5.BackgroundImage")));
            this.pnlRiverCard5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard5.Location = new System.Drawing.Point(241, 4);
            this.pnlRiverCard5.Name = "pnlRiverCard5";
            this.pnlRiverCard5.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard5.TabIndex = 57;
            this.pnlRiverCard5.Visible = false;
            this.pnlRiverCard5.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard5.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlRiverCard4
            // 
            this.pnlRiverCard4.AllowDrop = true;
            this.pnlRiverCard4.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard4.BackgroundImage")));
            this.pnlRiverCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard4.Location = new System.Drawing.Point(360, 4);
            this.pnlRiverCard4.Name = "pnlRiverCard4";
            this.pnlRiverCard4.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard4.TabIndex = 56;
            this.pnlRiverCard4.Visible = false;
            this.pnlRiverCard4.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard4.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlRiverCard3
            // 
            this.pnlRiverCard3.AllowDrop = true;
            this.pnlRiverCard3.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard3.BackgroundImage")));
            this.pnlRiverCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard3.Location = new System.Drawing.Point(479, 3);
            this.pnlRiverCard3.Name = "pnlRiverCard3";
            this.pnlRiverCard3.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard3.TabIndex = 55;
            this.pnlRiverCard3.Visible = false;
            this.pnlRiverCard3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // pnlRiverCard2
            // 
            this.pnlRiverCard2.AllowDrop = true;
            this.pnlRiverCard2.BackColor = System.Drawing.Color.Transparent;
            this.pnlRiverCard2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRiverCard2.BackgroundImage")));
            this.pnlRiverCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRiverCard2.Location = new System.Drawing.Point(598, 3);
            this.pnlRiverCard2.Name = "pnlRiverCard2";
            this.pnlRiverCard2.Size = new System.Drawing.Size(77, 134);
            this.pnlRiverCard2.TabIndex = 54;
            this.pnlRiverCard2.Visible = false;
            this.pnlRiverCard2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Panel_DragDrop);
            this.pnlRiverCard2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Panel_DragEnter);
            // 
            // lblAttack1
            // 
            this.lblAttack1.AutoSize = true;
            this.lblAttack1.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack1.ForeColor = System.Drawing.Color.Red;
            this.lblAttack1.Location = new System.Drawing.Point(267, 254);
            this.lblAttack1.Name = "lblAttack1";
            this.lblAttack1.Size = new System.Drawing.Size(61, 20);
            this.lblAttack1.TabIndex = 53;
            this.lblAttack1.Text = "Attack";
            this.lblAttack1.Visible = false;
            // 
            // lblAttack2
            // 
            this.lblAttack2.AutoSize = true;
            this.lblAttack2.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack2.ForeColor = System.Drawing.Color.Red;
            this.lblAttack2.Location = new System.Drawing.Point(382, 254);
            this.lblAttack2.Name = "lblAttack2";
            this.lblAttack2.Size = new System.Drawing.Size(61, 20);
            this.lblAttack2.TabIndex = 54;
            this.lblAttack2.Text = "Attack";
            this.lblAttack2.Visible = false;
            // 
            // lblAttack3
            // 
            this.lblAttack3.AutoSize = true;
            this.lblAttack3.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack3.ForeColor = System.Drawing.Color.Red;
            this.lblAttack3.Location = new System.Drawing.Point(503, 254);
            this.lblAttack3.Name = "lblAttack3";
            this.lblAttack3.Size = new System.Drawing.Size(61, 20);
            this.lblAttack3.TabIndex = 55;
            this.lblAttack3.Text = "Attack";
            this.lblAttack3.Visible = false;
            // 
            // lblAttack4
            // 
            this.lblAttack4.AutoSize = true;
            this.lblAttack4.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack4.ForeColor = System.Drawing.Color.Red;
            this.lblAttack4.Location = new System.Drawing.Point(620, 254);
            this.lblAttack4.Name = "lblAttack4";
            this.lblAttack4.Size = new System.Drawing.Size(61, 20);
            this.lblAttack4.TabIndex = 56;
            this.lblAttack4.Text = "Attack";
            this.lblAttack4.Visible = false;
            // 
            // lblAttack5
            // 
            this.lblAttack5.AutoSize = true;
            this.lblAttack5.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack5.ForeColor = System.Drawing.Color.Red;
            this.lblAttack5.Location = new System.Drawing.Point(740, 254);
            this.lblAttack5.Name = "lblAttack5";
            this.lblAttack5.Size = new System.Drawing.Size(61, 20);
            this.lblAttack5.TabIndex = 57;
            this.lblAttack5.Text = "Attack";
            this.lblAttack5.Visible = false;
            // 
            // lblDefend1
            // 
            this.lblDefend1.AutoSize = true;
            this.lblDefend1.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend1.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend1.Location = new System.Drawing.Point(260, 415);
            this.lblDefend1.Name = "lblDefend1";
            this.lblDefend1.Size = new System.Drawing.Size(68, 20);
            this.lblDefend1.TabIndex = 58;
            this.lblDefend1.Text = "Defend";
            this.lblDefend1.Visible = false;
            // 
            // lblDefend2
            // 
            this.lblDefend2.AutoSize = true;
            this.lblDefend2.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend2.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend2.Location = new System.Drawing.Point(378, 415);
            this.lblDefend2.Name = "lblDefend2";
            this.lblDefend2.Size = new System.Drawing.Size(68, 20);
            this.lblDefend2.TabIndex = 59;
            this.lblDefend2.Text = "Defend";
            this.lblDefend2.Visible = false;
            // 
            // lblDefend3
            // 
            this.lblDefend3.AutoSize = true;
            this.lblDefend3.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend3.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend3.Location = new System.Drawing.Point(498, 416);
            this.lblDefend3.Name = "lblDefend3";
            this.lblDefend3.Size = new System.Drawing.Size(68, 20);
            this.lblDefend3.TabIndex = 60;
            this.lblDefend3.Text = "Defend";
            this.lblDefend3.Visible = false;
            // 
            // lblDefend4
            // 
            this.lblDefend4.AutoSize = true;
            this.lblDefend4.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend4.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend4.Location = new System.Drawing.Point(621, 416);
            this.lblDefend4.Name = "lblDefend4";
            this.lblDefend4.Size = new System.Drawing.Size(68, 20);
            this.lblDefend4.TabIndex = 61;
            this.lblDefend4.Text = "Defend";
            this.lblDefend4.Visible = false;
            // 
            // lblDefend5
            // 
            this.lblDefend5.AutoSize = true;
            this.lblDefend5.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend5.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend5.Location = new System.Drawing.Point(738, 415);
            this.lblDefend5.Name = "lblDefend5";
            this.lblDefend5.Size = new System.Drawing.Size(68, 20);
            this.lblDefend5.TabIndex = 62;
            this.lblDefend5.Text = "Defend";
            this.lblDefend5.Visible = false;
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.Transparent;
            this.pnlDeck.Location = new System.Drawing.Point(39, 280);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(150, 107);
            this.pnlDeck.TabIndex = 63;
            // 
            // mmMenu
            // 
            this.mmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.helpToolStripMenuItem});
            this.mmMenu.Location = new System.Drawing.Point(0, 0);
            this.mmMenu.Name = "mmMenu";
            this.mmMenu.Size = new System.Drawing.Size(1014, 24);
            this.mmMenu.TabIndex = 64;
            this.mmMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewGame,
            this.miStats,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miNewGame
            // 
            this.miNewGame.Name = "miNewGame";
            this.miNewGame.Size = new System.Drawing.Size(132, 22);
            this.miNewGame.Text = "&New Game";
            this.miNewGame.Click += new System.EventHandler(this.miNewGame_Click);
            // 
            // miStats
            // 
            this.miStats.Name = "miStats";
            this.miStats.Size = new System.Drawing.Size(132, 22);
            this.miStats.Text = "&Stats";
            this.miStats.Click += new System.EventHandler(this.miStats_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(132, 22);
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout,
            this.miDebug});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(252, 22);
            this.miAbout.Text = "A&bout";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miDebug
            // 
            this.miDebug.Name = "miDebug";
            this.miDebug.Size = new System.Drawing.Size(252, 22);
            this.miDebug.Text = "Turn Debug &On (Resets the game)";
            this.miDebug.Click += new System.EventHandler(this.miDebug_Click);
            // 
            // lblAttack6
            // 
            this.lblAttack6.AutoSize = true;
            this.lblAttack6.BackColor = System.Drawing.Color.Transparent;
            this.lblAttack6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAttack6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttack6.ForeColor = System.Drawing.Color.Red;
            this.lblAttack6.Location = new System.Drawing.Point(859, 254);
            this.lblAttack6.Name = "lblAttack6";
            this.lblAttack6.Size = new System.Drawing.Size(61, 20);
            this.lblAttack6.TabIndex = 65;
            this.lblAttack6.Text = "Attack";
            this.lblAttack6.Visible = false;
            // 
            // lblDefend6
            // 
            this.lblDefend6.AutoSize = true;
            this.lblDefend6.BackColor = System.Drawing.Color.Transparent;
            this.lblDefend6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDefend6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefend6.ForeColor = System.Drawing.Color.Blue;
            this.lblDefend6.Location = new System.Drawing.Point(857, 415);
            this.lblDefend6.Name = "lblDefend6";
            this.lblDefend6.Size = new System.Drawing.Size(68, 20);
            this.lblDefend6.TabIndex = 66;
            this.lblDefend6.Text = "Defend";
            this.lblDefend6.Visible = false;
            // 
            // btnPass
            // 
            this.btnPass.BackColor = System.Drawing.Color.Transparent;
            this.btnPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPass.BackgroundImage")));
            this.btnPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPass.FlatAppearance.BorderSize = 0;
            this.btnPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPass.Location = new System.Drawing.Point(69, 458);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(79, 38);
            this.btnPass.TabIndex = 29;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // lblCPUText
            // 
            this.lblCPUText.BackColor = System.Drawing.Color.Transparent;
            this.lblCPUText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCPUText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUText.ForeColor = System.Drawing.Color.White;
            this.lblCPUText.Location = new System.Drawing.Point(297, 191);
            this.lblCPUText.Name = "lblCPUText";
            this.lblCPUText.Size = new System.Drawing.Size(700, 40);
            this.lblCPUText.TabIndex = 67;
            this.lblCPUText.Text = "CPU info";
            this.lblCPUText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlayerText
            // 
            this.lblPlayerText.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlayerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerText.ForeColor = System.Drawing.Color.White;
            this.lblPlayerText.Location = new System.Drawing.Point(297, 467);
            this.lblPlayerText.Name = "lblPlayerText";
            this.lblPlayerText.Size = new System.Drawing.Size(700, 40);
            this.lblPlayerText.TabIndex = 68;
            this.lblPlayerText.Text = "Player info";
            this.lblPlayerText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.White;
            this.lblTurn.Location = new System.Drawing.Point(86, 395);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(45, 20);
            this.lblTurn.TabIndex = 69;
            this.lblTurn.Text = "Turn";
            this.lblTurn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTurnNum
            // 
            this.lblTurnNum.AutoSize = true;
            this.lblTurnNum.BackColor = System.Drawing.Color.Transparent;
            this.lblTurnNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTurnNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnNum.ForeColor = System.Drawing.Color.White;
            this.lblTurnNum.Location = new System.Drawing.Point(97, 415);
            this.lblTurnNum.Name = "lblTurnNum";
            this.lblTurnNum.Size = new System.Drawing.Size(19, 20);
            this.lblTurnNum.TabIndex = 70;
            this.lblTurnNum.Text = "0";
            this.lblTurnNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Durak.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(1014, 661);
            this.Controls.Add(this.lblTurnNum);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lblPlayerText);
            this.Controls.Add(this.lblCPUText);
            this.Controls.Add(this.lblDefend6);
            this.Controls.Add(this.lblAttack6);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.lblDefend5);
            this.Controls.Add(this.lblDefend4);
            this.Controls.Add(this.lblDefend3);
            this.Controls.Add(this.lblDefend2);
            this.Controls.Add(this.lblDefend1);
            this.Controls.Add(this.lblAttack5);
            this.Controls.Add(this.lblAttack4);
            this.Controls.Add(this.lblAttack3);
            this.Controls.Add(this.lblAttack2);
            this.Controls.Add(this.lblAttack1);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lblDeck);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblComputerName);
            this.Controls.Add(this.pnlPlayer);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.pnlCPU);
            this.Controls.Add(this.pnlRiver);
            this.Controls.Add(this.mmMenu);
            this.MainMenuStrip = this.mmMenu;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.pnlRiver.ResumeLayout(false);
            this.mmMenu.ResumeLayout(false);
            this.mmMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDeck;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Panel pnlCPU;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.Panel pnlRiver;
        private System.Windows.Forms.Panel pnlRiverCard5;
        private System.Windows.Forms.Panel pnlRiverCard4;
        private System.Windows.Forms.Panel pnlRiverCard3;
        private System.Windows.Forms.Panel pnlRiverCard2;
        private System.Windows.Forms.Panel pnlRiverCard1;
        private System.Windows.Forms.Label lblAttack1;
        private System.Windows.Forms.Label lblAttack2;
        private System.Windows.Forms.Label lblAttack3;
        private System.Windows.Forms.Label lblAttack4;
        private System.Windows.Forms.Label lblAttack5;
        private System.Windows.Forms.Label lblDefend1;
        private System.Windows.Forms.Label lblDefend2;
        private System.Windows.Forms.Label lblDefend3;
        private System.Windows.Forms.Label lblDefend4;
        private System.Windows.Forms.Label lblDefend5;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.MenuStrip mmMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNewGame;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Panel pnlRiverCard6;
        private System.Windows.Forms.Label lblAttack6;
        private System.Windows.Forms.Label lblDefend6;
        private System.Windows.Forms.ToolStripMenuItem miDebug;
        private System.Windows.Forms.Label lblCPUText;
        private System.Windows.Forms.Label lblPlayerText;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblTurnNum;
        private System.Windows.Forms.ToolStripMenuItem miStats;
    }
}

