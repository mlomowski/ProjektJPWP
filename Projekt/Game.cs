using System;
using System.Drawing;
using System.IO;


namespace Projekt
{
    public class Game
    {
        public int pkt;
        public int speed=30;
        public Gracz gracz;
        public Kanister kanister;
        public Przeszkoda przeszkoda;
        public Game()
        {
            this.kanister = new Kanister(speed);
            this.przeszkoda = new Przeszkoda(speed);
            this.pkt = 0;
            this.gracz = new Gracz();
            this.speed = 20;
        }
        /// <summary>
        /// zmniejszanie paliwa
        /// </summary>
        public void Update()
        {
                gracz.zmianaPaliwa();
        }
        /// <summary>
        /// ustalenie koloru paliwa
        /// </summary>
        /// <returns>kolor paliwa</returns>
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
        /// <summary>
        /// sprawdza punkty
        /// </summary>
        /// <returns>punkty</returns>
      public double sprawdzPunkty()
        {
            return pkt;
        }
        /// <summary>
        /// sprawdza szybkosc gry
        /// </summary>
        /// <returns>szybkosc gry</returns>
       public int sprawdzSzybkoscGry()
        {
            return speed;
        }
        /// <summary>
        /// sprawdza szybkosc kanistra
        /// </summary>
        /// <returns>szybkosc kanistra</returns>
        public int sprawdzSzybkoscKanistra()
        {
            int temp = kanister.getSpeed();
            return temp;
        }
        /// <summary>
        /// sprawdza szybkosc przeszkod
        /// </summary>
        /// <returns>szybkosc przeszkod</returns>
        public int sprawdzSzybkoscPrzeszody()
        {
            int temp = przeszkoda.getSpeed();
            return temp;
        }


        /// <summary>
        /// sprawdza ilość paliwa
        /// </summary>
        /// <returns>ilość paliwa</returns>
        public double sprawdzPaliwo()
        {
            double stanPaliwa = gracz.getPaliwo();
            return stanPaliwa;
        }
        /// <summary>
        /// zwiększa szybkość gry
        /// </summary>
        public void zwiekszSzybkosc()
        {
            if(speed < 60)
            {
                przeszkoda.setSpeed();
            }
            
        }
        int temp =0;

       /// <summary>
       /// sygnalizacja zebrania kanistra, dodanie punktu oraz bonusu
       /// </summary>
       /// <returns>kolor paliwa (sygnalizator zebrania)</returns>
        public Color zebranoKanister()
        {
            //sygnalizator zebrania kanistra i dodanie punktu
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
        /// <summary>
        /// przeczytanie zachwowanej w pliku wartości (najwyższy wynik)
        /// </summary>
        /// <returns>wynik</returns>
        public String czytajWynik()
        {
       
            StreamReader reader = new StreamReader("Tabela.txt");
            String wynik;
            wynik = reader.ReadLine();
            reader.Close();
            return wynik;
        }
        /// <summary>
        /// zapisanie nowego najwyższego wyniku do pliku
        /// </summary>
        public void zapiszWynik() 
        {
            StreamWriter writer = new StreamWriter("Tabela.txt");
            writer.WriteLine(pkt);
            writer.Close();
        }

        /// <summary>
        /// sprawdzenie czy nowy wynik jest większy od poprzedniego, wtedy nadpisanie wyniku oraz zmiana szybkosci gry na 0
        /// </summary>
        /// <returns>szybkosc gry</returns>
        public int gameOver()
        {
            int temp = Int32.Parse(czytajWynik());
            //zapisywany jest tylko wynik wyzszy niz poprzedni
            if (pkt > temp) 
            {
                zapiszWynik();
            }
            speed = 0;
            return speed;
        }


    } 
}
