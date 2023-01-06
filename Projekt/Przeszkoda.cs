
namespace Projekt
{
    public class Przeszkoda
    {
        int speed;

        public Przeszkoda(int szybkosc)
        {
            this.speed = szybkosc+10;
        }

        public int getSpeed()
        {
            return speed;
        }
        public void setSpeed()
        {
            this.speed += 5;
        }
    }
}
