using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ruch o -10 
            move(-10);
          
        }
        void move(int speed) {
            pictureBox1.Left += speed;
            pictureBox2.Left += speed;
            pictureBox3.Left += speed;
            pictureBox4.Left += speed;    
            pictureBox5.Left += speed;

        }
    }
}
