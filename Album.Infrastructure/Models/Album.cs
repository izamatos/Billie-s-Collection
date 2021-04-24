using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    [System.Serializable]
    public class Album
    {
        public string Title;
        public int Year;
        public string Band;
        public List<Music> Musics;

        public Album(string title, int year, string band)
        {
            Title = title;
            Year = year;
            Band = band;
            Musics = new List<Music>();
        }

        public void CreateNewMusic()
        {
            bool continueCreatingMusic = false;

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Now, you're gonna add musics for {Title}");

            while (!continueCreatingMusic)
            {
                Console.WriteLine("Type the music title:");
                string musicName = Console.ReadLine();

                Console.WriteLine("Music Length:");
                decimal length = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Is it a favorite song? [S/N]");
                string resposta = Console.ReadLine();

                bool isFavorite = resposta.ToUpper() == "S";

                Music newMusic = new(musicName, length, isFavorite);

                Musics.Add(newMusic);

                Console.WriteLine("Do you want to add some more music? [S/N]");
                string option = Console.ReadLine();

                if (option.ToUpper() == "N")
                    break;
            }
        }
    }
}
