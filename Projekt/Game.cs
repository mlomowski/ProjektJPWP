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

        public Game()
        {
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

        public double sprawdzPaliwo()
        {
            double stanPaliwa = gracz.getPaliwo();
            return stanPaliwa;
        }

        public int sprawdzSzybkość()
        {
            return speed;
        }





    } 
}
