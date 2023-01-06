using System;
using System.Windows.Forms;

namespace Projekt
{
    static class Program
    {
        /// <summary>
        /// Wywołanie Form1
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
