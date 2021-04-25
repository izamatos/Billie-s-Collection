using System;
using System.IO;
using Infrastructure.Models;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Business
{
    [System.Serializable]
    public static class AlbumServices
    {
        public static void SelectedOption(int option)
        {

            switch (option)
            {
                case 1:
                    CreateNewAlbum();
                    break;
                case 2:
                    ShowAlbuns();
                    break;
                case 3:
                    SearchAlbuns();
                    break;
                case 4:
                    SerachMusicsInAlbum();
                    break;
                case 5:
                    CreatePlaylist();
                    break;
            }
        }

        public static List<Album> ReadAlbuns()
        {
            FileStream stream = new("AlbunsBillie.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new();
            try
            {
                List<Album> novalista = (List<Album>)encoder.Deserialize(stream);

                if (novalista == null)
                {
                    var novaLista = new List<Album>();
                }
                return novalista;

            }
            catch
            {
                var novaLista = new List<Album>();

                return novaLista;
            }
            finally
            {
                stream.Close();
            }
        }
        public static void SaveAlbum(Album newAlbum)
        {
            List<Album> albums = ReadAlbuns();

            albums.Add(newAlbum);

            FileStream stream = new("AlbunsBillie.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new();

            encoder.Serialize(stream, albums);

            stream.Close();
        }

        public static void CreateNewAlbum()
        {
            bool continueCreatingAlbum = false;

            while (!continueCreatingAlbum)
            {
                Console.WriteLine("Album Title: \n");
                string nameAlbum = Console.ReadLine();

                Console.WriteLine("Release year: \n");
                int year = int.Parse(Console.ReadLine());

                Console.WriteLine("Band: \n");
                string nameBand = Console.ReadLine();

                Album newAlbum = new(nameAlbum, year, nameBand);

                newAlbum.CreateNewMusic();

                SaveAlbum(newAlbum);

                if (CheckAnswer("Would you like to create another album?", "Y", "N") == "N")
                    break;
            }
        }
        public static void ShowAlbuns(List<Album> albums = null)
        {
            if (albums == null)
            {
                albums = ReadAlbuns();
            }

            Console.WriteLine("Here are all your Albuns and Musics!");

            foreach (Album album in albums)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine($"#Title: {album.Title} Release Year: {album.Year} Band: {album.Band} Musics: {album.Musics.Count}");

                Console.WriteLine("Musics:");

                foreach (Music music in album.Musics)
                {
                    Console.WriteLine($"{album.Musics.IndexOf(music) + 1}) {music.Title} - Length: {music.Length}  Favorite: {music.IsFavorite}");
                }
                Console.WriteLine("=======================================================");
            }
            WaitForKey();
        }
        public static void ShowMusic(List<Music> musics = null)
        {
            Console.WriteLine("Here are all your Musics!");

            Console.WriteLine("=======================================================");

            foreach (Music music in musics)
            {
                Console.WriteLine($"{musics.IndexOf(music) + 1}) {music.Title} - Length: {music.Length}  Favorite: {music.IsFavorite}");
            }

            Console.WriteLine("=======================================================");

            WaitForKey();
        }

        public static void SearchAlbuns()
        {
            Console.WriteLine("Do you want to search by \n 1 - Title \n 2 - Release Year \n 3 - Band");

            int option = int.Parse(Console.ReadLine());

            List<Album> albums = ReadAlbuns();
            List<Album> answerList = new();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Please, type the album title:");

                    string albumTitle = Console.ReadLine();

                    answerList = albums
                        .Where(album => album.Title.ToLower().Contains(albumTitle.ToLower()))
                        .ToList();
                    break;

                case 2:
                    Console.WriteLine("Please, type the release year:");

                    int releaseYear = int.Parse(Console.ReadLine());

                    answerList = albums
                        .Where(album => album.Year == releaseYear)
                        .ToList();
                    break;

                case 3:
                    Console.WriteLine("Please, type the band name:");

                    string bandName = Console.ReadLine();

                    answerList = albums
                        .Where(album => album.Band.ToLower().Contains(bandName.ToLower()))
                        .ToList();
                    break;
            }

            if (answerList.Count > 0)
                ShowAlbuns(answerList);
            else
            {
                Console.WriteLine("No albums matched your search!");
                WaitForKey();

            }

        }
        public static void SerachMusicsInAlbum()
        {
            Console.WriteLine("Do you want to search by \n 1 - Title \n 2 - Band");

            int option = int.Parse(Console.ReadLine());

            List<Album> albums = ReadAlbuns();

            List<Music> listanswer = new();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Please, type the music title:");

                    string musicTitle = Console.ReadLine();

                    var selectedMusic = albums
                        .Select(albuns => albuns.Musics.Where(music => music.Title.ToLower().Contains(musicTitle.ToLower())).ToList())
                        .ToList();

                    foreach (List<Music> list in selectedMusic)
                    {
                        listanswer.AddRange(list);
                    }

                    break;
                case 2:
                    Console.WriteLine("Please, type the band name:");

                    string bandName = Console.ReadLine();

                    List<List<Music>> selectedMusicBand =
                         albums
                         .Where(album => album.Band.ToLower().Contains(bandName.ToLower()))
                         .Select(album => album.Musics.ToList()).ToList();

                    foreach (List<Music> lista in selectedMusicBand)
                    {
                        listanswer.AddRange(lista);
                    }

                    break;
            }

            if (listanswer.Count > 0)
                ShowMusic(listanswer);

            else
            {
                Console.WriteLine("No musics matched your search!");
                WaitForKey();

            }
        }
        public static void CreatePlaylist()
        {
            List<Album> albums = ReadAlbuns();
            List<Music> favMusic = new();
            List<Music> nonFavMusic = new();
            List<Music> playList = new();

            foreach (var album in albums)
            {

                favMusic.AddRange(album.Musics.Where(x => x.IsFavorite).ToList());
                nonFavMusic.AddRange(album.Musics.Where(x => !x.IsFavorite).ToList());
            }

            decimal lengthPlaylist = 0;

            // metade com musicas favortidas
            foreach (var muiscaFav in favMusic)
            {
                if (muiscaFav.Length + lengthPlaylist > 30)
                    break;

                playList.Add(muiscaFav);

                lengthPlaylist += muiscaFav.Length;
            }

            lengthPlaylist = 0;
            // metade com muisicas nao favoritas
            foreach (var musicaNotFav in nonFavMusic)
            {
                if (musicaNotFav.Length + lengthPlaylist > 30)
                    break;

                playList.Add(musicaNotFav);

                lengthPlaylist += musicaNotFav.Length;
            }

            ShowMusic(playList);
        }
        public static void WaitForKey()
        {
            Console.WriteLine("Press any key to go back to the main menu...");
            Console.ReadKey();
        }
        public static string CheckAnswer(string message, string firstOption, string secondOption)
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

