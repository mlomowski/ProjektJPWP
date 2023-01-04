using System;
using System.Drawing;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Form1 : Form
    {
        public Game Game;
        Random rand = new Random();
        int x, y;
        int ctr = 0;
        int los = 1;

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
                droga(-Game.sprawdzSzybkoscPrzeszody()-5);
                kanister(-Game.sprawdzSzybkoscKanistra());
                przeszkoda(-Game.sprawdzSzybkoscPrzeszody());
            }
            else {
                gameover(Game.sprawdzPunkty());
            }

        }

        //Zakończenie rozgrywki
        void gameover(double pkt) {
            Game.gameOver();
            label2.Visible = true;
            button1.Visible = true;
            label1.Visible = false;
            Auto.Visible = false;
            timer1.Enabled = false;
            Przeszkoda.Visible = false;
            Przeszkoda2.Visible = false;
            Kanister.Visible = false;
        }

        //ruch pasow
        void droga(int speed) {
            if (pictureBox1.Left >= -190) { pictureBox1.Left += speed; }
            else pictureBox1.Left = 1280;

            if (pictureBox2.Left >= -190) { pictureBox2.Left += speed; }
            else pictureBox2.Left = 1280;

            if (pictureBox3.Left >= -190) { pictureBox3.Left += speed; }
            else pictureBox3.Left = 1280;

            if (pictureBox4.Left >= -190) { pictureBox4.Left += speed; }
            else pictureBox4.Left = 1280;

            if (pictureBox6.Left >= -190) { pictureBox6.Left += speed; }
            else pictureBox6.Left = 1280;
        }


        //zawijanie kanistrow i interakcje z samochodem

        void kanister(int speed) {
            if (Kanister.Left >= -180) { Kanister.Left += speed; }
            else {
                x = 1300;
                y = rand.Next(100, 700);
                while( y > 350 && y < 720)
                {
                    y = rand.Next(100, 700);
                }
                Kanister.Location = new Point(x, y);
            }
            if (Auto.Bounds.IntersectsWith(Kanister.Bounds)) {

                //gdy zebrano kanister
                label1.ForeColor = Game.zebranoKanister();


                //zmiana napisu
                Punkty.Text = "Punkty= " + Game.sprawdzPunkty();

                //losowanie nowej lokalizacji kanistra
                x = 1680;
                y = rand.Next(100, 700);
                while ( y > 250 && y < 600)
                {
                    y = rand.Next(100, 750);
                }
                Kanister.Location = new Point(x, y);

                //warunek sprawdzający czy kanister nie generuje się na przeszkodzie
                while (Kanister.Location == Przeszkoda.Location)
                {
                    y = rand.Next(100, 700);
                    Kanister.Location = new Point(x, y);
                }
            }
        }

        //zachowanie przeszkody
        void przeszkoda(int enemie_speed)
        {
            //Losowanie przeszody oraz położenia przeszkody
            if (los == 1)
            {
                //ukrywam niepotrzebna przeszkode
                Przeszkoda.Visible = true;
                Przeszkoda2.Visible = false;
       
                if (Przeszkoda.Left >= -580) { Przeszkoda.Left += enemie_speed; }
                else
                {

                    if (enemie_speed < 70) { enemie_speed += 10; }
                    los = rand.Next(1, 3);
                    x = 1500;
                    y = rand.Next(100, 700);
                    Przeszkoda.Location = new Point(x, y);
                    Game.zwiekszSzybkosc();
                }


            }

            else {

                Przeszkoda.Visible = false;
                Przeszkoda2.Visible = true;
                if (Przeszkoda2.Left >= -580) { Przeszkoda2.Left += enemie_speed; }
                else
                {
                    if (enemie_speed < 70) { enemie_speed += 10; }
                    los = rand.Next(1, 3);
                    x = 1500;
                    y = rand.Next(100, 700);
                    Przeszkoda2.Location = new Point(x, y);
                    Game.zwiekszSzybkosc();
                }

            }
           

            //zachowanie przy zetknięciu z graczem
            if (Auto.Bounds.IntersectsWith(Przeszkoda.Bounds))
            {
                gameover(Game.sprawdzPunkty());
            }
            if (Auto.Bounds.IntersectsWith(Przeszkoda2.Bounds))
            {
                gameover(Game.sprawdzPunkty());
            }

        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        //guzik do odczytania najwyzszego wyniku
        private void button1_Click(object sender, EventArgs e)
        {
            if (ctr == 0)
            {
                ctr = 1;
                label3.Text = Game.czytajWynik();
                label3.Visible = true;
            }
            else 
            {
                ctr = 0;
                label3.Visible = false;
            }

        }



        //obsługa myszy
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Auto.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
