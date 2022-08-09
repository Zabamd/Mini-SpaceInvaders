using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space
{
    public partial class SpaceInvaders : Form
    {
        bool scoreBoardscreen = false;
        bool GameOverScreenBool = true;
        int shooting;
        int BonusScore = 0;
        int lasezrLimit = 3;
        public  int score=0;
        int counter = 0;
        public bool SpaceShipLeftThrusters;
        public bool SpaceShipRightThrusters;
        public int AlienAttackPhaze = 1, AlienArmy = 0;
        PictureBox[] AlienShip;
        PictureBox[] LaserBox=new PictureBox[1000];
        PictureBox[] BonusBox = new PictureBox[1000];
        PictureBox[] AlienBulletsBox = new PictureBox[1000];
        bool laserShot = false;
        bool alienMovmentLeft;
        bool alienMovmentRight;
        int lasercounter=0;
        public int AlienNumber = 0;
        int bonuscounter=0, AlienBulletCounter=0;
        bool bonusDrop = false, AlienShooting=false;
        Random ShootChance = new Random();

        int[,] ship_plan_1 = {
            { 0, 0, 1, 1, 0, 0},
            { 1, 1, 0, 0, 1, 1},
            { 0, 0, 1, 1, 0, 0},
            { 1, 1, 0, 0, 1, 1},
            { 0, 0, 1, 1, 0, 0},
            { 1, 1, 0, 0, 1, 1 },
       };
        int[,] ship_plan_2 = {
            { 1, 1, 2, 2, 1, 1},
            { 2, 1, 1, 1, 1, 2},
            { 0, 0, 1, 1, 0, 0},
            { 1, 1, 0, 0, 1, 1},
            { 0, 0, 1, 1, 0, 0},
            { 1, 1, 0, 0, 1, 1 },
       };
        int[,] ship_plan_3 = {
            { 1, 1, 2, 2, 1, 1},
            { 2, 2, 1, 1, 2, 2},
            { 2, 1, 1, 1, 1, 2},
            { 1, 1, 0, 0, 1, 1},
            { 1, 2, 0, 0, 2, 1},
            { 1, 1, 0, 0, 1, 1 }
       };
        int[,] ship_plan_4 = {
            { 2, 1, 1, 1, 1, 2},
            { 1, 2, 1, 1, 2, 1},
            { 2, 1, 2, 2, 1, 2},
            { 2, 1, 2, 2, 1, 2},
            { 1, 2, 1, 1, 2, 1},
            {2, 1, 1, 1, 1, 2 },
       };

        public SpaceInvaders()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartScreen();                     
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            
            AlienBulletHitDetection();
            ScoreNumberLabel.Text = (score+BonusScore).ToString();
            DropCatchDetection();
            LaserEscapeDetection();
            LaserHitDetection();

            if (SpaceShipLeftThrusters == true)
            {
                if (SpaceShipBox.Left > 0)
                    SpaceShipBox.Left -= 5;
            }
            if (SpaceShipRightThrusters == true)
            {
                if (SpaceShipBox.Left + SpaceShipBox.Width < this.Width)
                    SpaceShipBox.Left += 5;
            }
            if (laserShot == true)
            {
                foreach (Control LaserBox in this.Controls)
                {
                    if (LaserBox is PictureBox && (string)LaserBox.Tag == "Laser")
                    {
                        LaserBox.Top -= 5;
                    }
                }
            }
            if (bonusDrop == true)
            {
                foreach (Control BonusBox in this.Controls)
                {
                    if (BonusBox is PictureBox && (string)BonusBox.Tag == "Bonus")
                    {
                        BonusBox.Top += 5;
                    }
                }
            }
            if (AlienShooting == true)
            {
                foreach (Control AlienBulletBox in this.Controls)
                {
                    if (AlienBulletBox is PictureBox && (string)AlienBulletBox.Tag == "Bullet")
                    {
                        AlienBulletBox.Top += 5;
                    }
                }
            }
            if (alienMovmentLeft == true)
            {
                AlienMovment(alienMovmentRight);
            }
            if (alienMovmentRight == true)
            {
                AlienMovment(alienMovmentRight);
            }
            if (GameOverScreenBool == true)
            {
                DeleteEveryone();
            }

        }
        private void MoveKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    SpaceShipLeftThrusters = true;
                    break;
                case Keys.Left:

                    SpaceShipLeftThrusters = true;
                    break;
                case Keys.D:
                    SpaceShipRightThrusters = true;
                    break;
                case Keys.Right:
                    SpaceShipRightThrusters = true;
                    break;
                case Keys.Space:
                    Shoot();
                    break;
            }
        }

        private void SpaceInvaders_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    SpaceShipLeftThrusters = false;
                    break;
                case Keys.Left:
                    SpaceShipLeftThrusters = false;
                    break;
                case Keys.D:

                    SpaceShipRightThrusters = false;
                    break;
                case Keys.Right:
                    SpaceShipRightThrusters = false;
                    break;

            }
        }

        private void SpaceShipBox_Click(object sender, EventArgs e)
        {

        }

        private void AlienAttack()
        {
            AlienShip = new PictureBox[10000];
            switch (AlienAttackPhaze)
            {
                case 1:
                    for (int i = 0; i < ship_plan_1.GetLength(0); i++)
                    {
                        for (int j = 0; j < ship_plan_1.GetLength(1); j++)
                        {
                            if (ship_plan_1[i, j] == 1)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "Alien";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);

                                AlienArmy++;
                            }
                            if (ship_plan_1[i, j] == 2)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "AlienSuper";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);


                                AlienArmy++;
                            }
                            AlienNumber++;
                        }
                    }
                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("alien.png");
                        }
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("SuperAlien.png");
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < ship_plan_2.GetLength(0); i++)
                    {
                        for (int j = 0; j < ship_plan_2.GetLength(1); j++)
                        {
                            if (ship_plan_2[i, j] == 1)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "Alien";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);

                                AlienArmy++;
                            }
                            if (ship_plan_2[i, j] == 2)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "AlienSuper";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);


                                AlienArmy++;
                            }
                            AlienNumber++;

                        }
                    }
                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("alien.png");
                        }
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("SuperAlien.png");
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < ship_plan_3.GetLength(0); i++)
                    {
                        for (int j = 0; j < ship_plan_3.GetLength(1); j++)
                        {
                            if (ship_plan_3[i, j] == 1)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "Alien";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);


                                AlienArmy++;
                            }
                            if (ship_plan_3[i, j] == 2)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "AlienSuper";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);



                                AlienArmy++;
                            }
                            AlienNumber++;

                        }
                    }
                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("alien.png");
                        }
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("SuperAlien.png");
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < ship_plan_4.GetLength(0); i++)
                    {
                        for (int j = 0; j < ship_plan_4.GetLength(1); j++)
                        {
                            if (ship_plan_4[i, j] == 1)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "Alien";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);



                                AlienArmy++;
                            }
                            if (ship_plan_4[i, j] == 2)
                            {
                                AlienShip[AlienArmy] = new PictureBox();
                                AlienShip[AlienArmy].Tag = "AlienSuper";
                                AlienShip[AlienArmy].Height = 50;
                                AlienShip[AlienArmy].Width = 50;

                                AlienShip[AlienArmy].Left = j * 100;
                                AlienShip[AlienArmy].Top = i * 50 + 50;
                                this.Controls.Add(AlienShip[AlienArmy]);


                                AlienArmy++;
                            }
                            AlienNumber++;

                        }
                    }
                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("alien.png");
                        }
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShip.BackgroundImage = Image.FromFile("SuperAlien.png");
                        }
                    }
                    break;
            }
        }

        private void AlienTimer_Tick(object sender, EventArgs e)
        {
            
            counter++;
            
            if (counter == 100)
            {
                if (alienMovmentRight == true)
                {
                    alienMovmentLeft = true;
                    alienMovmentRight = false;

                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShoot(AlienShip.Left, AlienShip.Top, AlienShip.Width);
                        }
                    }


                }
                else
                {
                    alienMovmentLeft = false;
                    alienMovmentRight = true;
                    GamePhazeCheck();
                    foreach (Control AlienShip in this.Controls)
                    {
                        if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                        {
                            AlienShoot(AlienShip.Left, AlienShip.Top, AlienShip.Width);
                        }
                    }
                }
                counter = 0;
                
            }
            
        }
        private void Shoot()
        {
            if (lasercounter <= lasezrLimit)
            {
                playLaserSound();

                lasercounter++;
                LaserBox[lasercounter] = new PictureBox();
                LaserBox[lasercounter].Tag = "Laser";
                LaserBox[lasercounter].Height = 20;
                LaserBox[lasercounter].Width = 25;
                this.Controls.Add(LaserBox[lasercounter]);

                LaserBox[lasercounter].Left = SpaceShipBox.Left + SpaceShipBox.Width / 2;
                LaserBox[lasercounter].Top = SpaceShipBox.Top - 20;
                laserShot = true;
                LaserBox[lasercounter].Image = Image.FromFile("laser.png");
            }
        }

        private void LaserHitDetection()
        {
            foreach(Control AlienShip in this.Controls)
            {
                foreach(Control LaserBox in this.Controls)
                {
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                    {
                        if (LaserBox is PictureBox && (string)LaserBox.Tag == "Laser")
                        {
                            if (LaserBox.Bounds.IntersectsWith(AlienShip.Bounds))
                            {
                                this.Controls.Remove(AlienShip);
                                this.Controls.Remove(LaserBox);
                                score += 100;
                                AlienNumber--;
                                lasercounter--;
                                playCannonSound();

                         

                            }
                        }
                    }
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                    {
                        if (LaserBox is PictureBox && (string)LaserBox.Tag == "Laser")
                        {
                            if (LaserBox.Bounds.IntersectsWith(AlienShip.Bounds))
                            {
                                Drop(AlienShip.Left,AlienShip.Top,AlienShip.Width);
                                this.Controls.Remove(AlienShip);
                                this.Controls.Remove(LaserBox);
                                score += 300;
                                AlienNumber--;
                                lasercounter--;
                                playCannonSound();


                            }
                        }
                    }
                }
            }
        }
        private void Drop(int Left, int Top, int Width)
        {
            bonuscounter++;
            BonusBox[bonuscounter] = new PictureBox();
            BonusBox[bonuscounter].Tag = "Bonus";
            BonusBox[bonuscounter].Height = 20;
            BonusBox[bonuscounter].Width = 20;
            this.Controls.Add(BonusBox[bonuscounter]);

            BonusBox[bonuscounter].Left = Left + Width / 2;
            BonusBox[bonuscounter].Top = Top;
            bonusDrop = true;
            BonusBox[bonuscounter].Image = Image.FromFile("bonus.png");

        }
        private void DropCatchDetection()
        {
            foreach (Control BonusBox in this.Controls)
            {
                if (BonusBox is PictureBox && (string)BonusBox.Tag == "Bonus")
                {
                    if (BonusBox.Bounds.IntersectsWith(SpaceShipBox.Bounds))
                    {
                        BonusScore += 1000;
                        this.Controls.Remove(BonusBox);
                    }
                }


            }

        }
        private void AlienBulletHitDetection()
        {
            foreach (Control AlienBulletBox in this.Controls)
            {
                if (AlienBulletBox is PictureBox && (string)AlienBulletBox.Tag == "Bullet")
                {
                    if (AlienBulletBox.Bounds.IntersectsWith(SpaceShipBox.Bounds))
                    {
                        
                       this.Controls.Remove(AlienBulletBox);
                        GameOverScreen();
                    }
                }


            }

        }
        private void AlienShoot(int Left, int Top, int Width)
        {
            shooting = ShootChance.Next(0, 100);
            if (shooting < 50)
            {
                AlienBulletCounter++;
                AlienBulletsBox[AlienBulletCounter] = new PictureBox();
                AlienBulletsBox[AlienBulletCounter].Tag = "Bullet";
                AlienBulletsBox[AlienBulletCounter].Height = 10;
                AlienBulletsBox[AlienBulletCounter].Width = 10;
                this.Controls.Add(AlienBulletsBox[AlienBulletCounter]);

                AlienBulletsBox[AlienBulletCounter].Left = Left + Width / 2;
                AlienBulletsBox[AlienBulletCounter].Top = Top;
                AlienShooting = true;
                AlienBulletsBox[AlienBulletCounter].Image = Image.FromFile("bullet.png");
            }

        }
        private void GamePhazeCheck()
        {
            switch (score)
            {
                case 1800:

                    AlienAttackPhaze = 2;
                    AlienAttack();
                    break;

                case 1800 + 3200:
 
                    AlienAttackPhaze = 3;
                    AlienAttack();
                    break;

                case 1800 + 3200 + 5000:
                    AlienAttackPhaze = 4;
                    AlienAttack();
                    break;
            }
            
            if(AlienAttackPhaze == 4 && AlienNumber == 36)
            {
                AlienAttack();
            }
            
              
        }
        private void AlienMovment(bool direction)
        {
            if (direction == true)
            {
                foreach (Control AlienShip in this.Controls)
                {
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                    {
                        AlienShip.Left += 1;
                    }
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                    {
                        AlienShip.Left += 1;
                    }
                }
            }

            if (direction == false)
            {
                foreach (Control AlienShip in this.Controls)
                {
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "Alien")
                    {
                        AlienShip.Left -= 1;
                    }
                    if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                    {
                        AlienShip.Left -= 1;
                    }
                }

            }
        }

        private void PlayLabel_Click(object sender, EventArgs e)
        {
            GameScreen();
            AlienAttackPhaze = 1;
            GameTimer.Start();
            AlienTimer.Start();
        }

        private void HighScoreLabel_Click(object sender, EventArgs e)
        {
            scoreBoardscreen = true;

            PlayerScoreLabel.Location = new Point(16, 133);
            PlayerScorelabel2.Location = new Point(16, 166);
            PlayerScorelabel3.Location = new Point(16, 199);
            PlayerScorelabel4.Location = new Point(16, 232);
            PlayerScorelabel5.Location = new Point(16, 265);
            ExitGameOverLabel.Location = new System.Drawing.Point(16, 298);


            PlayLabel.Location = new System.Drawing.Point(this.Width + 20, 187);
            HighScoreLabel.Location = new System.Drawing.Point(this.Width + 20, 268);
            ExitLabel.Location = new System.Drawing.Point(this.Width + 20, 345);
            this.ScoreNumberLabel.Location = new System.Drawing.Point(this.Width + 20, 4);


            StartScreenLabel.Text = "Scoreboard";

            string savedscore = File.ReadAllText("score.txt");
            string[] PlayersAndScore = savedscore.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<int, string> dict = new SortedDictionary<int, string>();

            for (int i = 0; i < PlayersAndScore.Length; i++)
             {
                if (i % 2 == 0 || i == 0)
                {
                    dict.Add(Int32.Parse(PlayersAndScore[i + 1]), PlayersAndScore[i]);
                }             
             }

             int countDict = 1;

             foreach (var kvp in dict.Reverse())
             {
                 switch (countDict)
                 {
                     case 1:
                         PlayerScoreLabel.Text = "1. " + kvp.Key + " " + kvp.Value.ToString();
                         break;
                     case 2:
                         PlayerScorelabel2.Text = "2. " + kvp.Key + " " + kvp.Value.ToString();
                         break;
                     case 3:
                         PlayerScorelabel3.Text = "3. " + kvp.Key + " " + kvp.Value.ToString();
                         break;
                     case 4:
                         PlayerScorelabel4.Text = "4. " + kvp.Key + " " + kvp.Value.ToString();
                         break;
                     case 5:
                         PlayerScorelabel5.Text = "5. " + kvp.Key + " " + kvp.Value.ToString();
                         break;
                 }
                 countDict++;
             }
            
           
        }

        private void LaserEscapeDetection()
        {
            foreach (Control LaserBox in this.Controls)
            {
                if (LaserBox is PictureBox && (string)LaserBox.Tag == "Laser")
                {
                    if(LaserBox.Top + LaserBox.Height < 0)
                    {
                        this.Controls.Remove(LaserBox);
                        lasercounter--;

                    }
                }
            }
            foreach (Control AlienBulletBox in this.Controls)
            {
                if (AlienBulletBox is PictureBox && (string)AlienBulletBox.Tag == "Bullet")
                {
                    if (AlienBulletBox.Top > this.Height)
                    {

                        this.Controls.Remove(AlienBulletBox);
                      
                    }
                }


            }

        }
        private void StartScreen()
        {
            PlayerScoreLabel.Location = new Point(this.Width+100, 133);
            PlayerScorelabel2.Location = new Point(this.Width + 100, 166);
            PlayerScorelabel3.Location = new Point(this.Width + 100, 199);
            PlayerScorelabel4.Location = new Point(this.Width + 100, 232);
            PlayerScorelabel5.Location = new Point(this.Width + 100, 265);

            GameOverScreenBool = false;
            GameTimer.Stop();
            AlienTimer.Stop();
            DeleteEveryone();
            StartScreenLabel.Location = new System.Drawing.Point(12, 40);
            PlayLabel.Location = new System.Drawing.Point(12, 187);
            HighScoreLabel.Location = new System.Drawing.Point(12, 268);
            ExitLabel.Location = new System.Drawing.Point(12, 345);
            this.ScoreNumberLabel.Location = new System.Drawing.Point(77, 4);

            this.GaveOverLabel.Location = new System.Drawing.Point(this.Width + 200, 187);
            this.EnterYourName.Location = new System.Drawing.Point(this.Width + 200, 251);
            this.YourScoreLabel.Location = new System.Drawing.Point(this.Width + 200, 283);
            
            this.textBox1.Location = new System.Drawing.Point(this.Width + 200, 248);
            this.ExitGameOverLabel.Location = new System.Drawing.Point(this.Width + 200, 325);

            ScoreNumberLabel.ForeColor = Color.Black;
            textBox1.Enabled = false;


        }

        private void ExitGameOverLabel_Click(object sender, EventArgs e)
        {
            if (scoreBoardscreen == true)
            {
                StartScreen();
                scoreBoardscreen = false;
            }
            else
            {
                string line =" "+textBox1.Text + " " + ScoreNumberLabel.Text.ToString();

                using (StreamWriter outputFile = new StreamWriter(("score.txt"), true))
                {
                    outputFile.WriteLine(line);
                }

                StartScreen();
            }
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEveryone()
        {
            foreach (Control BonusBox in this.Controls)
            {
                if (BonusBox is PictureBox && (string)BonusBox.Tag == "Bonus")
                {
                    this.Controls.Remove(BonusBox);
                    
                }
            }
            foreach (Control AlienShip in this.Controls)
            {
                if(AlienShip is PictureBox && (string)AlienShip.Tag=="Alien")
                {
                    this.Controls.Remove(AlienShip);
                }
                if (AlienShip is PictureBox && (string)AlienShip.Tag == "AlienSuper")
                {
                    this.Controls.Remove(AlienShip);
                }              

            }
            foreach (Control LaserBox in this.Controls)
            {
                if (LaserBox is PictureBox && (string)LaserBox.Tag == "Laser")
                {
                    this.Controls.Remove(LaserBox);
                    
                }
            }
            foreach (Control AlienBulletsBox in this.Controls)
            {
                if (AlienBulletsBox is PictureBox && (string)AlienBulletsBox.Tag == "Bullet")
                {
                    this.Controls.Remove(AlienBulletsBox);
                   
                }
            }
            
        }
        private void GameScreen()
        {
            AlienAttackPhaze = 1;
            score = 0;
            BonusScore = 0;
            counter = 0;
            AlienArmy = 0;
            AlienNumber = 0;
            bonuscounter = 0;
            AlienBulletCounter = 0;

            textBox1.Enabled = false;
            textBox1.ReadOnly = true;

            scoreBoardscreen = false;
            GameOverScreenBool = false;  
            lasercounter = 0;


            StartScreenLabel.Location = new System.Drawing.Point(this.Width+200, this.Height + 200);
            PlayLabel.Location = new System.Drawing.Point(this.Width + 200, this.Height + 200);
            HighScoreLabel.Location = new System.Drawing.Point(this.Width + 200, this.Height + 200);
            ExitLabel.Location = new System.Drawing.Point(this.Width + 200, this.Height + 200);
            AlienAttack();
            ScoreNumberLabel.ForeColor = Color.White;
            this.ScoreNumberLabel.Location = new System.Drawing.Point(77, 4);
            textBox1.Enabled = false;
        }
        private void GameOverScreen()
        {
            GameOverScreenBool = true;
            textBox1.Enabled = true;
            textBox1.ReadOnly = false;

            AlienTimer.Stop();
            DeleteEveryone();

            ScoreNumberLabel.ForeColor = Color.White;
            this.GaveOverLabel.Location = new System.Drawing.Point(303, 187);
            this.EnterYourName.Location = new System.Drawing.Point(306, 251);
            this.YourScoreLabel.Location = new System.Drawing.Point(306, 283);
            ScoreNumberLabel.Location = new System.Drawing.Point(467, 283);
            this.textBox1.Location = new System.Drawing.Point(467, 248);
            this.ExitGameOverLabel.Location = new System.Drawing.Point(306, 325);
        }
        private void playLaserSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "LazerSound.wav";
            player.Play();
        }
        private void playCannonSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "Cannon.wav";
            player.Play();
        }
        

    }
}
