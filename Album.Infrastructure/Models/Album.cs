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
                decimal length = decimal.Parse(Console.ReadLine().Replace(".", ","));

                bool isFavorite = CheckAnswer("Is this a favorite music?", "Y", "N") == "Y";

                Music newMusic = new(musicName, length, isFavorite);

                Musics.Add(newMusic);

                if (CheckAnswer("Would you like to add another music?", "Y", "N") == "N")
                    break;
            }
        }

        private static string CheckAnswer(string message, string firstOption, string secondOption)
        {
            string answer = "";

            while (answer.ToLower() != firstOption.ToLower() && answer.ToLower() != secondOption.ToLower())
            {
                Console.WriteLine($"{message} - [{firstOption}/{secondOption}]");

                answer = Console.ReadLine();
            }
            return answer.ToUpper();
        }
    }
}
