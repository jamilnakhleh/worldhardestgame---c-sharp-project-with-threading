using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
namespace worldhardestgame
{
    public partial class Level2 : Form
    {
        public Level2()
        {
            InitializeComponent();
        }

        bool right, left, Up, Down,W, S, D, A,redder, blacker,finalRED,finalBLACK,keyBLACK;
        int countRED = 0,countBLACK = 0;
        PictureBox[] Alien = new PictureBox[4];
        PictureBox[] PLA = new PictureBox[4];
        newball[] B = new newball[5];

        private void pictureBox3_Move(object sender, EventArgs e)
        {
            for (int j = 0; j< 5; j++)
            {
                if (B[j].Colu(pictureBox3, 53, 66) == true)
                {
                    if (countRED == 30)
                    {
                        redder = true;
                    }
                    else
                    {
                        countRED = countRED + 1;
                        toolStripStatusLabel1.Text = "Death for RED : " + countRED + "/30";
                        pictureBox3.Location = new Point(53, 66);
                    }
                }
            }
            if (redder == true)
            {
                pictureBox3.Location = new Point(53, 66);
                playR.Stop();
                pictureBox3.Image = imageList1.Images[1];
                if (blacker == true)
                {
                    PLAYERB.Location = new Point(53, 140);
                    plaB.Stop();
                    PLAYERB.Image = imageList1.Images[0];
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                    MessageBox.Show("Ya Losers :D");
                    LEVEL4.Visible = true;
                }
                else if (keyBLACK == true)
                {
                    LEVEL4.Visible = true;
                }
            }
            else if (redder == false)
            {
                if (blacker == true)
                {
                    if (finalRED == true)
                    {
                        timer2.Stop();
                        timer3.Stop();
                        timer4.Stop();
                        timer5.Stop();
                    }

                    PLAYERB.Location = new Point(53, 140);
                    plaB.Stop();
                    PLAYERB.Image = imageList1.Images[0];

                }
            }
            if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
               
                finalRED = true;
                playR.Stop();
             // kaftor level 3... 
               LEVEL4.Visible = true;
                pictureBox3.Image = imageList1.Images[3];  
                // fsh 7aje 2elo
                if (blacker == true)
                {
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                   
                    LEVEL4.Visible = true;
                }
                if (finalBLACK == true)
                {
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                   
                    LEVEL4.Visible = true;
                }
            }
            // fsh 7aje 2elo
            if (pictureBox3.Left >= this.Width - 50)
            {

                pictureBox3.Left -= 5;
            }
            if (pictureBox3.Left < 0)
            {

                pictureBox3.Left += 5;
            }
            if (pictureBox3.Top >= this.Height - 50)
            {

                pictureBox3.Top -= 50;
            }
            if (pictureBox3.Top <= 0)
            {
                pictureBox3.Top += 10;
            }
     
        }

        private void Level2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Up = true;
            if (e.KeyCode == Keys.Down)
                Down = true;
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Left)
                left = true;

            if (e.KeyCode == Keys.W)
                W = true;
            if (e.KeyCode == Keys.S)
                S = true;
            if (e.KeyCode == Keys.D)
                D = true;
            if (e.KeyCode == Keys.A)
                A = true;
        }

        private void Level2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Up = false;
            if (e.KeyCode == Keys.Down)
                Down = false;
            if (e.KeyCode == Keys.Right)
                right = false;
            if (e.KeyCode == Keys.Left)
                left = false;
            if (e.KeyCode == Keys.W)
                W = false;
            if (e.KeyCode == Keys.S)
                S = false;
            if (e.KeyCode == Keys.D)
                D = false;
            if (e.KeyCode == Keys.A)
                A = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Up == true)
                pictureBox3.Top -= 5;
            if (Down == true)
                pictureBox3.Top += 5;
            if (right == true)
                pictureBox3.Left += 5;
            if (left == true)
                pictureBox3.Left -= 5;
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                B[i] = new newball(i + 130 + i * 120, i + 120, this);
            }

            playR.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            timer5.Enabled = true;
        }

        private void plaB_Tick(object sender, EventArgs e)
        {
            if (W == true)
                PLAYERB.Top -= 5;
            if (S == true)
                PLAYERB.Top += 5;
            if (D == true)
                PLAYERB.Left += 5;
            if (A == true)
                PLAYERB.Left -= 5;
        }

        private void PLAYERB_Move(object sender, EventArgs e)
        {
            for (int h = 0; h < 5; h++)
            {
                if (B[h].Colu(PLAYERB, 53, 140) == true)
                {
                    if (countBLACK == 30)
                    {
                        blacker = true;
                    }
                    else
                    {
                        countBLACK = countBLACK + 1;
                        toolStripStatusLabel3.Text = "Death for BLACK : " + countBLACK + "/30";
                        PLAYERB.Location = new Point(53, 140);
                    }
                }
            }
            if (redder == true)
            {
                pictureBox3.Location = new Point(53, 66);
                playR.Stop();
                pictureBox3.Image = imageList1.Images[1];
                if (blacker == true)
                {
                    PLAYERB.Location = new Point(53, 140);
                    plaB.Stop();
                    PLAYERB.Image = imageList1.Images[0];
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                    MessageBox.Show("Ya Losers :D");
                   
                    LEVEL4.Visible = true;
                }
                else if (keyBLACK == true)
                {
                
                    LEVEL4.Visible = true;
                }


            }
            else if (redder == false)
            {
                if (blacker == true)
                {
                    if (finalRED == true)
                    {
                        timer2.Stop();
                        timer3.Stop();
                        timer4.Stop();
                        timer5.Stop();
                    }

                    PLAYERB.Location = new Point(53, 140);
                    plaB.Stop();
                    PLAYERB.Image = imageList1.Images[0];

                }
            }
            if (PLAYERB.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                keyBLACK = true;
                finalBLACK = true;
                plaB.Stop();

                PLAYERB.Image = imageList1.Images[2];
                if (redder == true)
                {
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();
                  
                    LEVEL4.Visible = true;
                }
                if (finalRED == true)
                {
                    timer2.Stop();
                    timer3.Stop();
                    timer4.Stop();
                    timer5.Stop();

                  
                    LEVEL4.Visible = true;
                }

            }
            if (PLAYERB.Left >= this.Width - 50)
            {
                PLAYERB.Left -= 5;
            }
            if (PLAYERB.Left < 0)
            {

                PLAYERB.Left += 5;
            }
            if (PLAYERB.Top >= this.Height - 50)
            {

                PLAYERB.Top -= 50;
            }
            if (PLAYERB.Top <= 0)
            {
                PLAYERB.Top += 10;
            }
        }

        private void Level2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);  
        }

        private void LEVEL4_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            plaB.Stop();
            playR.Stop();
            this.Hide();
            Level4 L4 = new Level4();
            L4.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {

        }     
    }
}