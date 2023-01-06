
namespace Projekt
{
    public class Gracz
    {
        public double stanPaliwa;
        public Gracz()
        {
            this.stanPaliwa = 100;
        }
        
        /// <summary>
        /// zmniejsza paliwo o zadana jednostke
        /// </summary>
        public void zmianaPaliwa()
        {
            this.stanPaliwa-=0.6;
        }

        /// <summary>
        /// zwraca stan paliwa
        /// </summary>
        /// <returns>paliwo</returns>
        public double getPaliwo()
        {
            return stanPaliwa;
        }

        /// <summary>
        /// przekazanie bonusu
        /// </summary>
        /// <param name="liczba"></param>
        public void Bonus(double liczba)
        {
            stanPaliwa = liczba;
        }

        /// <summary>
        /// odnowienie paliwa
        /// </summary>
        /// <param name="liczba"></param>
        public void setPaliwo(double liczba)
        {
            stanPaliwa += liczba;
        }

    }
}
