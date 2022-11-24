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
        public static int pkt = 0;
        public static double paliwo = 100;
        public static int speed = 20;
        public static int enemie_speed = speed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //ruch o -10 i zmniejszanie paliwa
            paliwo-=0.6;
            if(paliwo > 100) { label1.ForeColor = Color.DarkOrange; }
            if (paliwo < 100 && paliwo > 50) { label1.ForeColor = Color.Green; }
            if (paliwo > 30 && paliwo < 50) { label1.ForeColor = Color.Yellow; }
            if (paliwo < 30) label1.ForeColor = Color.Red;

            //zakończenie gry gdy paliwo spadnie poniżej 1 lub gra dalej
            if (paliwo < 1)
            {
                gameover(pkt);
            }
            else {
                //wypisanie zaokrąglonej do liczby całkowitej wartości paliwa
                label1.Text = "Paliwo= " + Math.Round(paliwo);
                
                droga(-speed);
                kanister(-speed-15);
                przeszkoda(-enemie_speed);
                
            }
      
        }

        //Zakończenie rozgrywki
        void gameover(int pkt) {
            speed = 0;
            label2.Visible = true;
            label1.Visible = false;
            Auto.Visible = false;
            timer1.Enabled = false;
            Przeszkoda.Visible = false;
            Kanister.Visible = false;
         
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
        

        //zawijanie kanistrow i interakcje z samochodem
        Random rand = new Random();
        int x, y;
        int temp =0;
        void kanister(int speed) {
            if (Kanister.Left >= -180) { Kanister.Left += speed; }
            else {
                x= 1300;
                y = rand.Next(100, 700);
                Kanister.Location = new Point(x, y);
            }
            if (Auto.Bounds.IntersectsWith(Kanister.Bounds)) {
                temp++;
                pkt++;
               
                if(paliwo < 100)
                {
                    label1.ForeColor = Color.Violet;
                    if (paliwo > 70) { paliwo = 100; } 
                    else paliwo += 30;
                }

                //bonusy ułatwiające grę

                if (temp == 10)
                {
                    paliwo = 150;
                }
                if (temp == 20)
                {
                    paliwo = 180; 
                }
                if (temp == 30)
                {
                    enemie_speed = -speed;
                    temp = 0; 
                }
                

                //zmiana napisu
                Punkty.Text = "Punkty= " + pkt;

                //losowanie nowej lokalizacji kanistra
                x = 1680;
                y = rand.Next(100, 700);
                Kanister.Location = new Point(x, y);

                //warunek sprawdzający czy kanister nie generuje się na przeszkodzie
                while(Kanister.Location== Przeszkoda.Location)
                {
                    Kanister.Location = new Point(x, y);
                }
            }
        }

        //zachowanie przeszkody
        void przeszkoda(int enemie_speed)
        {
            //ustanowienie maksymalnej prędkości i losowanie nowego położenia przeszkody
            if (Przeszkoda.Left >= -580) { Przeszkoda.Left += enemie_speed; }
            else
            {
                if(enemie_speed < 70) { enemie_speed += 10; }
                x = 1500;
                y = rand.Next(100, 700);
                Przeszkoda.Location = new Point(x, y);
            }
            //zachowanie przy zetknięciu z graczem
            if (Auto.Bounds.IntersectsWith(Przeszkoda.Bounds))
            {
                gameover(pkt);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        //obsługa myszy
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Auto.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
