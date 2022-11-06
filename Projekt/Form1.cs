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


        int speed = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //ruch o -10 
            droga(-speed);
            kanister(-speed);
            przeszkoda(-speed);
          //test
        }
        
        
        //ruch pasow
        void droga(int speed) {
            if (pictureBox1.Left >= -180) { pictureBox1.Left += speed; }
            else pictureBox1.Left = 1280;

            if (pictureBox2.Left >= -180) { pictureBox2.Left += speed; }
            else pictureBox2.Left = 1280;

            if (pictureBox3.Left >= -180) { pictureBox3.Left += speed; }
            else pictureBox3.Left = 1280;

            if (pictureBox4.Left >= -180) { pictureBox4.Left += speed; }
            else pictureBox4.Left = 1280;

            if (pictureBox5.Left >= -180) { pictureBox5.Left += speed; }
            else pictureBox5.Left = 1280;
            
            if (pictureBox6.Left >= -180) { pictureBox6.Left += speed; }
            else pictureBox6.Left = 1280;
        }


        //zawijanie kanistrow
        Random rand = new Random();
        int x, y;
        void kanister(int speed) {
            if (Kanister.Left >= -180) { Kanister.Left += speed; }
            else {
                x= 1280;
                y = rand.Next(100, 700);
                Kanister.Location = new Point(x, y);
            } 
        }
        //zawijanie przeszkod
        void przeszkoda(int speed) {
        
        
        
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Auto.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }
        private void Kanister_MouseMove(object sender, MouseEventArgs e)
        {
            x = 1280;
            y = rand.Next(100, 700);
            Kanister.Location = new Point(x, y);
        }
    }
}
