
namespace Projekt
{
    public class Przeszkoda
    {
        int speed;

        public Przeszkoda(int szybkosc)
        {
            this.speed = szybkosc+10;
        }

        /// <summary>
        /// zwraca szybkosc przeszkody
        /// </summary>
        /// <returns>szybkosc przeszkody</returns>
        public int getSpeed()
        {
            return speed;
        }

        /// <summary>
        /// ustawia szybkosc przeszkody
        /// </summary>
        public void setSpeed()
        {
            this.speed += 5;
        }
    }
}
