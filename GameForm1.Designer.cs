
namespace Project
{
    partial class GameForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm1));
            panel1 = new Panel();
            TurnLabel = new Label();
            P2PiecesLabel = new Label();
            P1PiecesLabel = new Label();
            StartGameButton = new Button();
            P2TextBox = new TextBox();
            P1TextBox = new TextBox();
            P2Label = new Label();
            P1Label = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            GameMenu = new ToolStripMenuItem();
            NewGameMenu = new ToolStripMenuItem();
            SaveGameMenu = new ToolStripMenuItem();
            ExitMenu = new ToolStripMenuItem();
            SettingsMenu = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            HelpMenu = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            AboutButton = new ToolStripMenuItem();
            RestoreGameMenu = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(TurnLabel);
            panel1.Controls.Add(P2PiecesLabel);
            panel1.Controls.Add(P1PiecesLabel);
            panel1.Controls.Add(StartGameButton);
            panel1.Controls.Add(P2TextBox);
            panel1.Controls.Add(P1TextBox);
            panel1.Controls.Add(P2Label);
            panel1.Controls.Add(P1Label);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(602, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 553);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // TurnLabel
            // 
            TurnLabel.AutoSize = true;
            TurnLabel.Location = new Point(68, 467);
            TurnLabel.Name = "TurnLabel";
            TurnLabel.Size = new Size(97, 20);
            TurnLabel.TabIndex = 9;
            TurnLabel.Text = "Turn: Player 1";
            TurnLabel.Click += TurnLabel_Click;
            // 
            // P2PiecesLabel
            // 
            P2PiecesLabel.AutoSize = true;
            P2PiecesLabel.Location = new Point(56, 435);
            P2PiecesLabel.Name = "P2PiecesLabel";
            P2PiecesLabel.Size = new Size(121, 20);
            P2PiecesLabel.TabIndex = 8;
            P2PiecesLabel.Text = "Player 2 Pieces: 0";
            // 
            // P1PiecesLabel
            // 
            P1PiecesLabel.AutoSize = true;
            P1PiecesLabel.Location = new Point(56, 233);
            P1PiecesLabel.Name = "P1PiecesLabel";
            P1PiecesLabel.Size = new Size(121, 20);
            P1PiecesLabel.TabIndex = 7;
            P1PiecesLabel.Text = "Player 1 Pieces: 0";
            // 
            // StartGameButton
            // 
            StartGameButton.BackColor = SystemColors.MenuHighlight;
            StartGameButton.Location = new Point(71, 499);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(94, 29);
            StartGameButton.TabIndex = 6;
            StartGameButton.Text = "Start Game";
            StartGameButton.UseVisualStyleBackColor = false;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // P2TextBox
            // 
            P2TextBox.Location = new Point(83, 395);
            P2TextBox.Name = "P2TextBox";
            P2TextBox.Size = new Size(125, 27);
            P2TextBox.TabIndex = 5;
            P2TextBox.Text = "Enter your name";
            // 
            // P1TextBox
            // 
            P1TextBox.Location = new Point(83, 192);
            P1TextBox.Name = "P1TextBox";
            P1TextBox.Size = new Size(125, 27);
            P1TextBox.TabIndex = 1;
            P1TextBox.Text = "Enter your name";
            // 
            // P2Label
            // 
            P2Label.AutoSize = true;
            P2Label.Location = new Point(13, 398);
            P2Label.Name = "P2Label";
            P2Label.Size = new Size(64, 20);
            P2Label.TabIndex = 4;
            P2Label.Text = "Player 2:";
            // 
            // P1Label
            // 
            P1Label.AutoSize = true;
            P1Label.Location = new Point(13, 195);
            P1Label.Name = "P1Label";
            P1Label.Size = new Size(64, 20);
            P1Label.TabIndex = 3;
            P1Label.Text = "Player 1:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._1;
            pictureBox2.Location = new Point(56, 269);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 120);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._0;
            pictureBox1.Location = new Point(56, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 119);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { GameMenu, SettingsMenu, HelpMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(250, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // GameMenu
            // 
            GameMenu.DropDownItems.AddRange(new ToolStripItem[] { NewGameMenu, RestoreGameMenu, SaveGameMenu, ExitMenu });
            GameMenu.Name = "GameMenu";
            GameMenu.Size = new Size(62, 24);
            GameMenu.Text = "&Game";
            // 
            // NewGameMenu
            // 
            NewGameMenu.Name = "NewGameMenu";
            NewGameMenu.Size = new Size(224, 26);
            NewGameMenu.Text = "New Game";
            NewGameMenu.Click += NewGameMenu_Click;
            // 
            // SaveGameMenu
            // 
            SaveGameMenu.Name = "SaveGameMenu";
            SaveGameMenu.Size = new Size(224, 26);
            SaveGameMenu.Text = "Save Game";
            SaveGameMenu.Click += SaveGameMenu_Click;
            // 
            // ExitMenu
            // 
            ExitMenu.Name = "ExitMenu";
            ExitMenu.Size = new Size(224, 26);
            ExitMenu.Text = "Exit";
            ExitMenu.Click += ExitMenu_Click;
            // 
            // SettingsMenu
            // 
            SettingsMenu.DropDownItems.AddRange(new ToolStripItem[] { informationPanelToolStripMenuItem, speakToolStripMenuItem });
            SettingsMenu.Name = "SettingsMenu";
            SettingsMenu.Size = new Size(76, 24);
            SettingsMenu.Text = "&Settings";
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(209, 26);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.Checked = true;
            speakToolStripMenuItem.CheckState = CheckState.Checked;
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(209, 26);
            speakToolStripMenuItem.Text = "Speak";
            // 
            // HelpMenu
            // 
            HelpMenu.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator5, AboutButton });
            HelpMenu.Name = "HelpMenu";
            HelpMenu.Size = new Size(55, 24);
            HelpMenu.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(139, 6);
            // 
            // AboutButton
            // 
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(142, 26);
            AboutButton.Text = "&About...";
            AboutButton.Click += aboutToolStripMenuItem_Click;
            // 
            // RestoreGameMenu
            // 
            RestoreGameMenu.Name = "RestoreGameMenu";
            RestoreGameMenu.Size = new Size(224, 26);
            RestoreGameMenu.Text = "Restore Game";
            RestoreGameMenu.Click += RestoreGameMenu_Click;
            // 
            // GameForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(852, 553);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "O'Neillo Game";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }




        #endregion

        private Panel panel1;
        private TextBox P2TextBox;
        private TextBox P1TextBox;
        private Label P2Label;
        private Label P1Label;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button StartGameButton;
        private Label TurnLabel;
        private Label P2PiecesLabel;
        private Label P1PiecesLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem GameMenu;
        private ToolStripMenuItem NewGameMenu;
        private ToolStripMenuItem SettingsMenu;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripMenuItem ExitMenu;
        private ToolStripMenuItem HelpMenu;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem AboutButton;
        private ToolStripMenuItem SaveGameMenu;
        private ToolStripMenuItem RestoreGameMenu;
    }
}
