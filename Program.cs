using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ColeçaoDeAlbunsBillie
{
    class Program
    {
        static List<Collection> albums = new List<Collection>();

        enum Menu { Register = 1, SearchA, SearchM, Playlist, Exit }


        static void Main(string[] args)
        {
            Load();
            bool ChoseExit = false;

            while (!ChoseExit)
            {
                Console.WriteLine("=============================");
                Console.WriteLine("BILLIE'S ALBUMS COLLECTION");
                Console.WriteLine("=============================");
                Console.WriteLine("1 - Register Album\n2 - Search Album\n3 - Search Music\n4 - Create Playlist\n5 - Exit");
                Console.WriteLine("Please, select your option: ");
                string option = (Console.ReadLine());
                int opint = int.Parse(option);

                if (opint > 0 && opint < 6)

                {
                    Menu choice = (Menu)opint;

                    switch (choice)
                    {
                        case Menu.Register:
                            Register();
                            break;
                        case Menu.SearchA:
                            break;
                        case Menu.SearchM:
                            break;
                        case Menu.Playlist:
                            break;
                        case Menu.Exit:
                            ChoseExit = true;
                            break;
                    }
                }

                else
                {
                    ChoseExit = true;
                }
                Console.Clear();
            }
        }
        static void Register()
        {
            Console.WriteLine("Register your album");
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Release year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Group: ");
            string group = Console.ReadLine();
            Save();

        }

        static void List()
        {
            Console.WriteLine("List of registered albums");
            int i = 0;
            foreach (Collection alb in albums)
            {
                Console.WriteLine($"ID: {i}");
                alb.Show();
                i++;
            }
        }
        static void Save()
        {
            FileStream stream = new FileStream("collection.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, albums);

            stream.Close();
        }
        static void Load()
        {
            FileStream stream = new FileStream("collection.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                albums = (List<Collection>)encoder.Deserialize(stream);

                if (albums == null)
                {
                    albums = new List<Collection>();
                }
            }
            catch (Exception e)
            {
                albums = new List<Collection>();
            }

            stream.Close();
        }
    }













}


