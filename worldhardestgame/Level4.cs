using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace worldhardestgame
{
    public partial class Level4 : Form
    {
        public int locx, locy, x, y,x1,y1;
        public bool isOn;
        bool Up, Down, right, left;
        public Level4()
        {
            InitializeComponent();
        }
        newball b, b2;
        int chances = 0;
        private void Level4_Load(object sender, EventArgs e)
        {
            Chance.Text = "Chance : " + chances+"/30";
            Random rand = new Random();
            x = rand.Next(0, this.ClientSize.Width - 50);
            y = rand.Next(0, this.ClientSize.Height - 50);
            x1 = rand.Next(0, this.ClientSize.Width - 50);
            y1 = rand.Next(0, this.ClientSize.Height - 50);
       
            // 4,19 - moving 2ana5e more than 2ofke.
            b = new newball(x, y, 4, 19, this);
            b2 = new newball(x1, y1, 4, 19, this);
        }

        private void Level4_KeyDown(object sender, KeyEventArgs e)
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
       
        private void Level4_KeyUp(object sender, KeyEventArgs e)
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
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Up == true)
                pictureBox1.Top -= 5;
            if (Down == true)
                pictureBox1.Top += 5;
            if (right == true)
                pictureBox1.Left += 5;
            if (left == true)
                pictureBox1.Left -= 5;
        }

        private void pictureBox1_Move_1(object sender, EventArgs e)
        {
            if (b.Colu(pictureBox1, 184, 35) == true || b2.Colu(pictureBox1, 184, 35) == true)
            {
                if (chances == 30)
                {   
                    Environment.Exit(1);
                }
                else
                {
                    chances++;
                    Chance.Text = "Chance : " + chances + "/30";
                }
            }
            if (pictureBox1.Left >= this.Width - 50)
            {
                pictureBox1.Left -= 5;
            }
            if (pictureBox1.Left < 0)
            {
                pictureBox1.Left += 5;
            }
            if (pictureBox1.Top >= this.Height - 50)
            {
                pictureBox1.Top -= 50;
            }
            if (pictureBox1.Top <= 0)
            {
                pictureBox1.Top += 10;
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                timer1.Stop();
                MessageBox.Show("WIN :D");
                Application.Exit();
            }
        }
        private void Level4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}