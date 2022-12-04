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
        public Gracz()
        {
            this.stanPaliwa = 100;
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

        
        public void Bonus(double liczba)
        {
            stanPaliwa = liczba;
        }

        public void setPaliwo(double liczba)
        {
            stanPaliwa += liczba;
        }

    }
}
