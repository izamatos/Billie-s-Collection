using Business;
using System;

namespace Billie_Album_Collection
{
    public class Program
    {

        public static void Main(string[] args)
        {

            bool closeProgram = false;

            while (!closeProgram)
            {
                Console.Clear();
                Console.WriteLine("=======================================================");
                Console.WriteLine("BILLIE'S ALBUMS COLLECTION");
                Console.WriteLine("=======================================================");
                Console.WriteLine("1 - Register Album\n2 - Display Albums\n3 - Search Albums\n4 - Search Musics\n5 - Create Playlist\n6 - Exit");
                Console.WriteLine("Please, select your option: ");

                string option = (Console.ReadLine());

                int opint = int.Parse(option);

                if (opint == 6) break;

                AlbumServices.SelectedOption(opint);
            }
            Console.Clear();
        }
    }


}
