using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        public static int pkt = 0;
        public static double paliwo = 100;
        public static int speed = 20;
        public static int enemie_speed = 20;
        public Game Game;
        public Gracz gracz;


        public Form1()
        {
            InitializeComponent();
            this.Game = new Game();
            
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sprawdzanie stanu paliwa i przypisanie koloru do aktualnej wartości, jeżeli kolor to czarny to przerwij rozgrywkę
            if (Game.sprawdzPaliwo() > 0)
            {
                label1.ForeColor = Game.kolorPaliwa();
                label1.Text = "Paliwo= " + Math.Round(Game.sprawdzPaliwo());
                Game.Update();
                droga(-Game.sprawdzSzybkość());
            }
            else {
                gameover(Game.sprawdzPunkty());
            }
      
        }

        //Zakończenie rozgrywki
        void gameover(double pkt) {
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
