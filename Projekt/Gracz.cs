using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Gracz
    {
        public double stanPaliwa;
        public Kanister kanister;
        public Gracz(double paliwo)
        {
            this.stanPaliwa = paliwo;
        }
        
        public void zmianaPaliwa()
        {
            this.stanPaliwa-=0.6;
        }

        //Metoda zwraca stan paliwa
        public double getPaliwo()
        {
            return stanPaliwa;
        }

        int temp = 0;
        public void setPaliwo()
        {
            temp++;

            if (stanPaliwa > 70)
            {
                stanPaliwa = 100;
            }

           else
            {
                stanPaliwa += kanister.zebrano();
            }

            if (temp == 10 && stanPaliwa<150)
            {
                stanPaliwa = 150;

            }
            if (temp == 20 && stanPaliwa < 180)
            {
                stanPaliwa = 180;

            }
            if (temp == 30 && stanPaliwa < 200)
            {
                stanPaliwa = 200;
                temp = 0;
            }

        }


    }
}
