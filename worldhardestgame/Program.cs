using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
namespace worldhardestgame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
            Thread thread = new Thread(ThreadStart);
          
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        
            Thread thread2 = new Thread(ThreadStart2);

            thread2.TrySetApartmentState(ApartmentState.STA);
            thread2.Start();
            */
            Application.Run(new Form1());
        }
      /*private static void ThreadStart()
        {
             Application.Run(new Level2());
        }
        */
    }
}
