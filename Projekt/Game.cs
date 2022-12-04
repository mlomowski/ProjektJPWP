using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Game
    {
        public int pkt;
        public int speed;
        public Gracz gracz;
        public Kanister kanister;

        public Game()
        {
            this.kanister = new Kanister();
            this.pkt = 0;
            this.gracz = new Gracz();
            this.speed = 20;
        }

        public void Update()
        {
                gracz.zmianaPaliwa(); 
        }

        public Color kolorPaliwa()
        {
            //dodanie zmiennej kolor i zwrócenie wartości koloru zależnie od paliwa
            Color kolor = new Color();
            double stanPaliwa = gracz.getPaliwo();
            if (stanPaliwa > 100) { kolor = Color.DarkOrange; }
            if (stanPaliwa < 100 && stanPaliwa > 50) { kolor = Color.Green; }
            if (stanPaliwa > 30 && stanPaliwa < 50) { kolor = Color.Yellow; }
            if (stanPaliwa < 30) { kolor = Color.Red; };
            if (stanPaliwa < 1) { kolor = Color.Black; }
            return kolor;
        }

      public double sprawdzPunkty()
        {
            return pkt;
        }

       public int sprawdzSzybkoscGry()
        {
            return speed;
        }
        public int sprawdzSzybkoscKanistra()
        {
            int temp = kanister.sprawdzSzybkosc();
            return temp;
        }



        public double sprawdzPaliwo()
        {
            double stanPaliwa = gracz.getPaliwo();
            return stanPaliwa;
        }


        int temp =0;
        public Color zebranoKanister()
        {
            Color color = Color.Violet;
            pkt++;
            temp++;
            double temp2 = gracz.getPaliwo();
          
            //bonusy
            if (temp == 10 && temp2 < 150)
            {
                gracz.Bonus(150);
                return color;
            }

            if (temp == 20 && temp2 < 180)
            {
                gracz.Bonus(180);
                return color;
            }

            if (temp == 30 && temp2 < 200)
            {
                gracz.Bonus(200);
                temp = 0;
                return color;
            }


            if (temp2 > 70 && temp2 < 100)
            {
                gracz.Bonus(100);
                return color;
            }
            else if (temp2 < 100)
            {
                gracz.setPaliwo(kanister.zebrano());
                return color;
            }
            else
                return color;

        }

        public int gameOver()
        {
            speed = 0;
            return speed;
        }

    } 
}
