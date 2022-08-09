
namespace Space
{
    partial class SpaceInvaders
    {

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceInvaders));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.ScoreNumberLabel = new System.Windows.Forms.Label();
            this.ScoreTextLabel = new System.Windows.Forms.Label();
            this.SpaceShipBox = new System.Windows.Forms.PictureBox();
            this.AlienTimer = new System.Windows.Forms.Timer(this.components);
            this.StartScreenLabel = new System.Windows.Forms.Label();
            this.PlayLabel = new System.Windows.Forms.Label();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.GaveOverLabel = new System.Windows.Forms.Label();
            this.EnterYourName = new System.Windows.Forms.Label();
            this.YourScoreLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ExitGameOverLabel = new System.Windows.Forms.Label();
            this.PlayerScoreLabel = new System.Windows.Forms.Label();
            this.PlayerScorelabel2 = new System.Windows.Forms.Label();
            this.PlayerScorelabel3 = new System.Windows.Forms.Label();
            this.PlayerScorelabel4 = new System.Windows.Forms.Label();
            this.PlayerScorelabel5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceShipBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 10;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // ScoreNumberLabel
            // 
            this.ScoreNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ScoreNumberLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreNumberLabel.Location = new System.Drawing.Point(77, 4);
            this.ScoreNumberLabel.Name = "ScoreNumberLabel";
            this.ScoreNumberLabel.Size = new System.Drawing.Size(115, 36);
            this.ScoreNumberLabel.TabIndex = 0;
            // 
            // ScoreTextLabel
            // 
            this.ScoreTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ScoreTextLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreTextLabel.Location = new System.Drawing.Point(1, 4);
            this.ScoreTextLabel.Name = "ScoreTextLabel";
            this.ScoreTextLabel.Size = new System.Drawing.Size(70, 36);
            this.ScoreTextLabel.TabIndex = 1;
            this.ScoreTextLabel.Text = "Score:";
            this.ScoreTextLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // SpaceShipBox
            // 
            this.SpaceShipBox.BackColor = System.Drawing.Color.Black;
            this.SpaceShipBox.Image = ((System.Drawing.Image)(resources.GetObject("SpaceShipBox.Image")));
            this.SpaceShipBox.Location = new System.Drawing.Point(662, 618);
            this.SpaceShipBox.Name = "SpaceShipBox";
            this.SpaceShipBox.Size = new System.Drawing.Size(85, 84);
            this.SpaceShipBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SpaceShipBox.TabIndex = 2;
            this.SpaceShipBox.TabStop = false;
            this.SpaceShipBox.Click += new System.EventHandler(this.SpaceShipBox_Click);
            // 
            // AlienTimer
            // 
            this.AlienTimer.Interval = 10;
            this.AlienTimer.Tick += new System.EventHandler(this.AlienTimer_Tick);
            // 
            // StartScreenLabel
            // 
            this.StartScreenLabel.AutoSize = true;
            this.StartScreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.StartScreenLabel.ForeColor = System.Drawing.Color.White;
            this.StartScreenLabel.Location = new System.Drawing.Point(12, 40);
            this.StartScreenLabel.Name = "StartScreenLabel";
            this.StartScreenLabel.Size = new System.Drawing.Size(248, 39);
            this.StartScreenLabel.TabIndex = 3;
            this.StartScreenLabel.Text = "SpaceInvaders";
            // 
            // PlayLabel
            // 
            this.PlayLabel.AutoSize = true;
            this.PlayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.PlayLabel.ForeColor = System.Drawing.Color.White;
            this.PlayLabel.Location = new System.Drawing.Point(12, 187);
            this.PlayLabel.Name = "PlayLabel";
            this.PlayLabel.Size = new System.Drawing.Size(85, 39);
            this.PlayLabel.TabIndex = 4;
            this.PlayLabel.Text = "Play";
            this.PlayLabel.Click += new System.EventHandler(this.PlayLabel_Click);
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.AutoSize = true;
            this.HighScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.HighScoreLabel.ForeColor = System.Drawing.Color.White;
            this.HighScoreLabel.Location = new System.Drawing.Point(12, 268);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.Size = new System.Drawing.Size(196, 39);
            this.HighScoreLabel.TabIndex = 5;
            this.HighScoreLabel.Text = "Scoreboard";
            this.HighScoreLabel.Click += new System.EventHandler(this.HighScoreLabel_Click);
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.ExitLabel.ForeColor = System.Drawing.Color.White;
            this.ExitLabel.Location = new System.Drawing.Point(12, 345);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(76, 39);
            this.ExitLabel.TabIndex = 6;
            this.ExitLabel.Text = "Exit";
            this.ExitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            // 
            // GaveOverLabel
            // 
            this.GaveOverLabel.AutoSize = true;
            this.GaveOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.GaveOverLabel.ForeColor = System.Drawing.Color.White;
            this.GaveOverLabel.Location = new System.Drawing.Point(273, 187);
            this.GaveOverLabel.Name = "GaveOverLabel";
            this.GaveOverLabel.Size = new System.Drawing.Size(188, 39);
            this.GaveOverLabel.TabIndex = 7;
            this.GaveOverLabel.Text = "GameOver";
            // 
            // EnterYourName
            // 
            this.EnterYourName.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.EnterYourName.AutoSize = true;
            this.EnterYourName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.EnterYourName.ForeColor = System.Drawing.Color.White;
            this.EnterYourName.Location = new System.Drawing.Point(276, 248);
            this.EnterYourName.Name = "EnterYourName";
            this.EnterYourName.Size = new System.Drawing.Size(147, 22);
            this.EnterYourName.TabIndex = 8;
            this.EnterYourName.Text = "Enter your name:";
            // 
            // YourScoreLabel
            // 
            this.YourScoreLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YourScoreLabel.AutoSize = true;
            this.YourScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.YourScoreLabel.ForeColor = System.Drawing.Color.White;
            this.YourScoreLabel.Location = new System.Drawing.Point(276, 283);
            this.YourScoreLabel.Name = "YourScoreLabel";
            this.YourScoreLabel.Size = new System.Drawing.Size(102, 22);
            this.YourScoreLabel.TabIndex = 9;
            this.YourScoreLabel.Text = "Your score:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(437, 245);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 28);
            this.textBox1.TabIndex = 10;

            // 
            // ExitGameOverLabel
            // 
            this.ExitGameOverLabel.AutoSize = true;
            this.ExitGameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.ExitGameOverLabel.ForeColor = System.Drawing.Color.White;
            this.ExitGameOverLabel.Location = new System.Drawing.Point(276, 322);
            this.ExitGameOverLabel.Name = "ExitGameOverLabel";
            this.ExitGameOverLabel.Size = new System.Drawing.Size(40, 22);
            this.ExitGameOverLabel.TabIndex = 11;
            this.ExitGameOverLabel.Text = "Exit";
            this.ExitGameOverLabel.Click += new System.EventHandler(this.ExitGameOverLabel_Click);
            // 
            // PlayerScoreLabel
            // 
            this.PlayerScoreLabel.AutoSize = true;
            this.PlayerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.PlayerScoreLabel.ForeColor = System.Drawing.Color.White;
            this.PlayerScoreLabel.Location = new System.Drawing.Point(16, 133);
            this.PlayerScoreLabel.Name = "PlayerScoreLabel";
            this.PlayerScoreLabel.Size = new System.Drawing.Size(37, 31);
            this.PlayerScoreLabel.TabIndex = 12;
            this.PlayerScoreLabel.Text = "1.";
            // 
            // PlayerScorelabel2
            // 
            this.PlayerScorelabel2.AutoSize = true;
            this.PlayerScorelabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.PlayerScorelabel2.ForeColor = System.Drawing.Color.White;
            this.PlayerScorelabel2.Location = new System.Drawing.Point(16, 187);
            this.PlayerScorelabel2.Name = "PlayerScorelabel2";
            this.PlayerScorelabel2.Size = new System.Drawing.Size(37, 31);
            this.PlayerScorelabel2.TabIndex = 13;
            this.PlayerScorelabel2.Text = "2.";
            // 
            // PlayerScorelabel3
            // 
            this.PlayerScorelabel3.AutoSize = true;
            this.PlayerScorelabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.PlayerScorelabel3.ForeColor = System.Drawing.Color.White;
            this.PlayerScorelabel3.Location = new System.Drawing.Point(16, 245);
            this.PlayerScorelabel3.Name = "PlayerScorelabel3";
            this.PlayerScorelabel3.Size = new System.Drawing.Size(37, 31);
            this.PlayerScorelabel3.TabIndex = 14;
            this.PlayerScorelabel3.Text = "3.";
            // 
            // PlayerScorelabel4
            // 
            this.PlayerScorelabel4.AutoSize = true;
            this.PlayerScorelabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.PlayerScorelabel4.ForeColor = System.Drawing.Color.White;
            this.PlayerScorelabel4.Location = new System.Drawing.Point(16, 307);
            this.PlayerScorelabel4.Name = "PlayerScorelabel4";
            this.PlayerScorelabel4.Size = new System.Drawing.Size(37, 31);
            this.PlayerScorelabel4.TabIndex = 15;
            this.PlayerScorelabel4.Text = "4.";
            // 
            // PlayerScorelabel5
            // 
            this.PlayerScorelabel5.AutoSize = true;
            this.PlayerScorelabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.PlayerScorelabel5.ForeColor = System.Drawing.Color.White;
            this.PlayerScorelabel5.Location = new System.Drawing.Point(16, 368);
            this.PlayerScorelabel5.Name = "PlayerScorelabel5";
            this.PlayerScorelabel5.Size = new System.Drawing.Size(37, 31);
            this.PlayerScorelabel5.TabIndex = 16;
            this.PlayerScorelabel5.Text = "5.";
            // 
            // SpaceInvaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(860, 727);
            this.Controls.Add(this.PlayerScorelabel5);
            this.Controls.Add(this.PlayerScorelabel4);
            this.Controls.Add(this.PlayerScorelabel3);
            this.Controls.Add(this.PlayerScorelabel2);
            this.Controls.Add(this.PlayerScoreLabel);
            this.Controls.Add(this.ExitGameOverLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.YourScoreLabel);
            this.Controls.Add(this.EnterYourName);
            this.Controls.Add(this.GaveOverLabel);
            this.Controls.Add(this.ExitLabel);
            this.Controls.Add(this.HighScoreLabel);
            this.Controls.Add(this.PlayLabel);
            this.Controls.Add(this.StartScreenLabel);
            this.Controls.Add(this.SpaceShipBox);
            this.Controls.Add(this.ScoreTextLabel);
            this.Controls.Add(this.ScoreNumberLabel);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpaceInvaders";
            this.Text = "SpaceInvaders";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceInvaders_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.SpaceShipBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label ScoreNumberLabel;
        private System.Windows.Forms.Label ScoreTextLabel;
        private System.Windows.Forms.PictureBox SpaceShipBox;
        private System.Windows.Forms.Timer AlienTimer;
        private System.Windows.Forms.Label StartScreenLabel;
        private System.Windows.Forms.Label PlayLabel;
        private System.Windows.Forms.Label HighScoreLabel;
        private System.Windows.Forms.Label ExitLabel;
        private System.Windows.Forms.Label GaveOverLabel;
        private System.Windows.Forms.Label EnterYourName;
        private System.Windows.Forms.Label YourScoreLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label ExitGameOverLabel;
        private System.Windows.Forms.Label PlayerScoreLabel;
        private System.Windows.Forms.Label PlayerScorelabel2;
        private System.Windows.Forms.Label PlayerScorelabel3;
        private System.Windows.Forms.Label PlayerScorelabel4;
        private System.Windows.Forms.Label PlayerScorelabel5;
    }
}

