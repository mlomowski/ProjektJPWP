using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Kanister
        {
        int paliwo;
        int szybkosc;
        public Kanister()
        {
            this.paliwo = 30;
            this.szybkosc = 30;
        }


        public double zebrano() {
            return paliwo; 
        }

        public int sprawdzSzybkosc()
        {
            return szybkosc;
        }

    }
}
