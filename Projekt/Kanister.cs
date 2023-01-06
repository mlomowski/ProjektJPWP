
namespace Projekt
{
    public class Kanister
        {
        int paliwo;
        int szybkosc;
        public Kanister(int speed)
        {
            this.paliwo = 30;
            this.szybkosc = speed+20;
        }

        /// <summary>
        /// Zwraca ustalona wartosc paliwa
        /// </summary>
        /// <returns>paliwo</returns>
        public double zebrano() {
            return paliwo; 
        }

        /// <summary>
        /// zwraca szybkosc kanistra
        /// </summary>
        /// <returns>szybkosc kanistra</returns>
        public int getSpeed()
        {
            return szybkosc;
        }

    }
}
