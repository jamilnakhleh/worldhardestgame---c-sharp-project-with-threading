using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace worldhardestgame
{
    class newball
    {
        PictureBox b = new PictureBox();
        Point loc; // start location
        Thread t; //parallel movement 
        Form f;//where ball fall
        static int size = 80;
        Random r = new Random();
        bool quit = false;
        Point p;
        int x,y,locx, locy;
        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        delegate void setTopCallBack(int top);//for context switch

        // new newball for Level 2 ...
        public newball(int x, int y, Form f)
        {
            //se parameters
            loc = new Point(x, y);
            this.f = f;
            //set image
            b.Image = Properties.Resources.blue_ball;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.SetBounds(x, y, 40, 40);//set image location
            f.Controls.Add(b);//add ball to form
            //set thread and start
            t = new Thread(new ThreadStart(fall));
            t.Start();
        }

        // new newball for Level 1 ...
        public newball(int x, int y, Form f,int x1)
        {
            //se parameters
            loc = new Point(x, y);
            this.f = f;
            //set image
            b.Image = Properties.Resources.blue_ball;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.SetBounds(x, y, 40, 40);//set image location
            f.Controls.Add(b);//add ball to form
            //set thread and start
            t = new Thread(new ThreadStart(fall2));
            t.Start();
        }

        //for Level 3  new newball & draw & t1_Tick & move1 & delegate setm1 ... 
        public newball(int x, int y, int locx, int locy, Form f)
        {
            this.f = f;
            this.x = x;
            this.y = y;
            this.locx = locx;
            this.locy = locy;
            b = new PictureBox();
            draw(f, x, y);
            Thread o1 = new Thread(move1);
            o1.IsBackground = true;
            o1.Start();
            t1.Interval = 45;
            t1.Tick += new EventHandler(t1_Tick);
            t1.Start();
        }
        
        void draw(Form f, int x, int y)
        {
            b.Size = new Size(44, 40);
            b.Location = new Point(x, y);
            b.Image = Properties.Resources.blue_ball;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            f.Controls.Add(b);// set object to form.
        }
        void t1_Tick(object sender, EventArgs e)
        {
            b.Left += locx;
            if (b.Left < 0)
            {
                locx = -locx;
            }
            else if (b.Left + 50 > f.ClientSize.Width)
            {
                locx = -locx;
            }
            b.Top += locy;
            if (b.Top < 0)
                locy = -locy;
            else if (b.Top + 50 > f.ClientSize.Height)
                locy = -locy;


        }
        public void move1()
        {
            Random rand = new Random();
            while (!quit)
            {
                Thread.Sleep(1000);
                p = new Point(b.Location.X, b.Location.Y - rand.Next(0, 30));
                setm1(p);
                Thread.Sleep(1000);
                p = new Point(b.Location.X, b.Location.Y + rand.Next(0, 30));
                setm1(p);
            }
        }
        delegate void degm1(Point p);
        public void setm1(Point p)
        {
            if (this.b.InvokeRequired)
            {
                degm1 d = new degm1(setm1);
                f.Invoke(d, new object[] { p });
            }
            else
            {
                this.b.Location = p;
            }
        }
        // Collision Function ...
        public bool Colu(PictureBox bx,int x,int y) // set location of the ball to play again - all forms.
        {
            if (this.b.Bounds.IntersectsWith(bx.Bounds))
            {
                bx.Location = new Point(x, y);
                return true;
            }
            return false;
        }
        // for Level 2 ...
        public void fall()
        {
            while (true)
            {
                if (b.Top + size >= f.Height)
                    setTop(0);
                setTop(r.Next(5, 20));
                Thread.Sleep(35);
            }
        }
        // for Level 1 ...
        public void fall2()
        {
            while (true)
            {
                if (b.Left - size >= f.Width)
                    setTop2(0);
                setTop2(r.Next(30, 35));
                Thread.Sleep(35);
            }
        }
        // for Level 2 ...
        public void setTop(int top)
        { //התבקש לעשות פעולה על אובייקט שנמצא בתהליכון אחר
            if (f.InvokeRequired)
            {
                //צור מצביע לפונקציה
                setTopCallBack d = new setTopCallBack(setTop);
                //בצע מיתוג עם הפונקיצה והערך שיש לשנות
                f.Invoke(d, new object[] { top });
            }
            else
            {
                if (top == 0) // return ball to top of the form
                    b.Top = 0;  
                else
                    b.Top += top;
            }
        }
        // for Level 1 ...
        public void setTop2(int top)
        { //התבקש לעשות פעולה על אובייקט שנמצא בתהליכון אחר
            if (f.InvokeRequired)
            {
                //צור מצביע לפונקציה
                setTopCallBack d = new setTopCallBack(setTop2);
                //בצע מיתוג עם הפונקיצה והערך שיש לשנות
                f.Invoke(d, new object[] { top });
            }
            else
            {
                if (top == 0)
                    b.Left =0;
                else
                    b.Left += top;
            }
        }
    }
}