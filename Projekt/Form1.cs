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

        /// <summary>
        /// W tej pętli wykonywany jest ruch elementów 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sprawdzanie stanu paliwa i przypisanie koloru do aktualnej wartosci
            if (Game.sprawdzPaliwo() > 0)
            {
                label1.ForeColor = Game.kolorPaliwa();
                label1.Text = "Paliwo= " + Math.Round(Game.sprawdzPaliwo());
                Game.Update();
                droga(-Game.sprawdzSzybkoscPrzeszody()-5);
                kanister(-Game.sprawdzSzybkoscKanistra());
                przeszkoda(-Game.sprawdzSzybkoscPrzeszody());
            }
            //jezeli paliwo to 0 to koniec gry
            else {
                gameover(Game.sprawdzPunkty());
            }

        }


        /// <summary>
        /// Zakończenie gry
        /// </summary>
        /// <param name="pkt"></param>
        //Zakonczenie rozgrywki
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

        /// <summary>
        /// ruch pasów oraz ich zapętlenie
        /// </summary>
        /// <param name="speed"></param>
        void droga(int speed) {
            //jezeli sa dalej niz na -190 to porusz o speed, jezeli nie to ustaw pozycje na 1280
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

            if (pictureBox7.Left >= -190) { pictureBox7.Left += speed; }
            else pictureBox7.Left = 1280;

            if (pictureBox8.Left >= -190) { pictureBox8.Left += speed; }
            else pictureBox8.Left = 1280;

        }


        /// <summary>
        /// zachhowanie kanistra, co jeżeli kanister zniknie lub zostanie zebrany, interakcje z kanistrem
        /// </summary>
        /// <param name="speed"></param>

        void kanister(int speed) {
            if (Kanister.Left >= -180) { Kanister.Left += speed; }
            else {
                //jezeli uciekl kanister
                x = 1300;
                y = rand.Next(100, 700);
                //kanister pojawia sie albo nad albo pod pasami
                while( y > 350 && y < 720)
                {
                    y = rand.Next(100, 700);
                }
                Kanister.Location = new Point(x, y);
            }
            //zebranie kanistra
            if (Auto.Bounds.IntersectsWith(Kanister.Bounds)) {

                //powiadomienie o zebranym kanistrze
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

        /// <summary>
        /// zachowanie przeszkody
        /// </summary>
        /// <param name="enemie_speed"></param>
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
                    //losuje nowa przeszkode
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
           

            //zachowanie przy zetknieciu z graczem
            if (Auto.Bounds.IntersectsWith(Przeszkoda.Bounds))
            {
                gameover(Game.sprawdzPunkty());
            }
            if (Auto.Bounds.IntersectsWith(Przeszkoda2.Bounds))
            {
                gameover(Game.sprawdzPunkty());
            }

        }
    
        /// <summary>
        /// guzik reset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        /// <summary>
        /// guzik do sprawdzania najwyższego wyniku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// obsługa myszy oraz wyśrodkowanie samochhodu na kursor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Auto.Location = new Point(Cursor.Position.X-150, Cursor.Position.Y-100);
        }
    }
}
