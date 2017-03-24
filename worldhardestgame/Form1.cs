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
using System.Threading.Tasks;

namespace worldhardestgame
{
    public partial class Form1 : Form
    {
        Boolean isWork = false;
        Stopwatch sw = new Stopwatch();
        bool right, left, Up, Down;
        Level2 L2 = new Level2();
        newball[] B = new newball[2]; // form 1
        int chances = 0;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Death : " + chances + "/30";
            B[0] = new newball(0 + 130 + 0 * 120, 0 + 105, this, 1);
            B[1] = new newball(1 + 130 + 1 * 120, 1 + 180, this, 1);    

            if (isWork == true) //STOPWATCH timer code
            {
                isWork = false; //stop work
                sw.Stop(); //stop stopwatch
                sw.Reset(); //reset read value
                tmSW.Stop(); //stop sw timer
                lblTimer.Text = "0:00:00"; //reset label
               
            }
            else
            {
                isWork = true; //start work
                sw.Start(); //start stopwatch
                tmSW.Start(); //start sw timer
            }

           
        }
       
        private void Form1_KeyDown(object sender, KeyEventArgs e) //recognize the keys
        {
            if (e.KeyCode == Keys.Up)
                Up = true;
            if (e.KeyCode == Keys.Down)
                Down = true;
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Left)
                left = true;
        }
        private void timer3_Tick(object sender, EventArgs e) // move the ball 
        {
            if (Up == true)
                pictureBox4.Top -= 5;
            if (Down == true)
                pictureBox4.Top += 5;
            if (right == true)
                pictureBox4.Left += 5;
            if (left == true)
                pictureBox4.Left -= 5;

           
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Up = false;
            if (e.KeyCode == Keys.Down)
                Down = false;
            if (e.KeyCode == Keys.Right)
                right = false;
            if (e.KeyCode == Keys.Left)
                left = false;
        }
       
        private void pictureBox4_Move(object sender, EventArgs e)
        {
            // check collision 
            if (B[0].Colu(pictureBox4, 156, 12) == true || B[1].Colu(pictureBox4, 156, 12) == true) 
            {
                yellowBALL.Visible = true;
                if (chances == 30)
                {
                    this.Hide();
                    L2.Show();
                    toolStripStatusLabel1.Text = "Death : " + chances + "/30";
                }
                else
                {
                    chances++;
                    toolStripStatusLabel1.Text = "Death : " + chances + "/30";
                }
            }

            if (pictureBox4.Bounds.IntersectsWith(yellowBALL.Bounds))
            {
                yellowBALL.Visible = false;
            }
            else
                if (pictureBox4.Bounds.IntersectsWith(pictureBox3.Bounds)) // check if the player take the yellow ball and get the green box
                {
                    if(yellowBALL.Visible == false)
                    {
                    this.Hide();
                    L2.Show();
                    }
                }
        }
        
        private void tmSW_Tick(object sender, EventArgs e)
        {
            int h1 = sw.Elapsed.Hours;
            int m1 = sw.Elapsed.Minutes;
            int s1 = sw.Elapsed.Seconds;
            //display time
            toolStripStatusLabel2.Text = h1 + ":";
            if (m1 < 10)
                toolStripStatusLabel2.Text += "0" + m1 + ":";
            else
                toolStripStatusLabel2.Text += m1 + ":";
            if (s1 < 10)
                toolStripStatusLabel2.Text += "0" + s1;
            else
                toolStripStatusLabel2.Text += s1;
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
             Environment.Exit(1);
        }
    }
}