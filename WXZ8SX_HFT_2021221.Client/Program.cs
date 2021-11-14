using ConsoleTools;
using System;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Client
{
    class Program
    {
        static RestService rest = new RestService("http://localhost:49755");

        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            var subMenuCreate = new ConsoleMenu()
               .Add(">> CREATE ALBUM", () => CreateAlbum())
               .Add(">> CREATE GENRE", () => CreateGenre())
               .Add(">> CREATE ARTIST", () => CreateArtist())
               .Add(">> CREATE SONG", () => CreateSong())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Main menu";
                   config.EnableWriteTitle = true;
                   config.EnableBreadcrumb = true;
               });
            
            var subMenuDelete = new ConsoleMenu()
               .Add(">> DELETE ALBUM", () => DeleteAlbum())
               .Add(">> DELETE GENRE", () => DeleteGenre())
               .Add(">> DELETE ARTIST", () => DeleteArtist())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Main menu";
                   config.EnableWriteTitle = true;
                   config.EnableBreadcrumb = true;
               });
            //var menu = new ConsoleMenu(args, level: 0)
            //   .Add(">> GET ALBUMS", () => GetAlbums())
            //   .Add("Close", ConsoleMenu.Close)
            //   .Add("Exit", () => Environment.Exit(0))
            //   .Configure(config =>
            //   {
            //       config.Selector = "--> ";
            //       config.EnableFilter = true;
            //       config.Title = "Main menu";
            //       config.EnableWriteTitle = true;
            //       config.EnableBreadcrumb = true;
            //   });

            subMenuCreate.Show();
            //menu.Show();

        }
        private static void GetAlbums()
        {
            var allAlbums = rest.Get<Album>("album");
            foreach (var item in allAlbums)
            {
                Console.WriteLine(item.AlbumName);
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        #region CREATE METHODS
        private static void CreateAlbum()
        {
            try
            {
                Console.WriteLine("::CREATING A NEW ALBUM::");
                Console.WriteLine("INSERT ALBUM NAME!");
                string name = Console.ReadLine();
                Console.WriteLine("INSERT DATE OF RELEASED OF THE ALBUM IN THIS FORMAT (MM/dd/yyyy)!");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NUMBER OF SONGS OF THE ALBUM!");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("INSERT THE RATING OF ALBUM (MUST BE BETWEEN 0.0 AND 5.0)!");
                double rating = double.Parse(Console.ReadLine());
                Console.WriteLine("INSERT ARTIST ID!");
                int artId = int.Parse(Console.ReadLine());
                Console.WriteLine("INSERT GENRE ID!");
                int genId = int.Parse(Console.ReadLine());
                rest.Post<Album>(new Album() 
                {
                    AlbumName = name,
                    ReleasedDate = date,
                    NumberOfSongs = num,
                    Rating = rating,
                    ArtistId = artId,
                    GenreId = genId,
                }, "album");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void CreateGenre()
        {
            try
            {
                Console.WriteLine("::CREATE GENRE::");
                Console.WriteLine("INSERT GENRE NAME!");
                string name = Console.ReadLine();
                rest.Post<Genre>(new Genre()
                {
                    GenreName = name,
                }, "genre");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void CreateArtist()
        {
            try
            {
                Console.WriteLine("::CREATE ARTIST::");
                Console.WriteLine("INSERT ARTIST NAME!");
                string name = Console.ReadLine();
                Console.WriteLine("INSERT DATE OF BIRTH OF THE ARTIST! (MM/dd/yyyy)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NUMBER OF ALBUMS!");
                int num = int.Parse(Console.ReadLine());
                rest.Post<Artist>(new Artist()
                {
                    ArtistName = name,
                    DateOfBirth = date,
                    NumberOfAlbums = num,
                }, "artist");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void CreateSong()
        {
            try
            {
                Console.WriteLine("::CREATE SONG::");
                Console.WriteLine("INSERT SONG NAME!");
                string name = Console.ReadLine();
                Console.WriteLine("INSERT SONG LENGTH!");
                double length = double.Parse(Console.ReadLine());
                Console.WriteLine("INSERT THE WRITER OF THE SONG!");
                string writer = Console.ReadLine();
                Console.WriteLine("INSERT THE SINGER OF THE SONG!");
                string singer = Console.ReadLine();
                Console.WriteLine("INSERT ALBUM ID!");
                int albumId = int.Parse(Console.ReadLine());
                rest.Post<Song>(new Song()
                {
                    Name = name,
                    Length = length,
                    Writer = writer,
                    Singer = singer,
                    AlbumId = albumId,
                }, "song");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        #endregion

        private static void DeleteAlbum()
        {
            try
            {
                Console.WriteLine("::DELETE ALBUM::");
                Console.WriteLine("INSERT THE ID OF THE ALBUM TO BE DELETED!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"THIS ALBUM NAME: {(rest.Get<Album>(id, "album")).AlbumName} WILL BE DELETED!");
                rest.Delete(id, "album");
                Console.WriteLine("DELETED!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void DeleteGenre()
        {
            try
            {
                Console.WriteLine("::DELETE GENRE::");
                Console.WriteLine("INSERT THE ID OF THE GENRE TO BE DELETED!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"THIS GENRE NAME: {(rest.Get<Genre>(id, "genre")).GenreName} WILL BE DELETED!");
                rest.Delete(id, "genre");
                Console.WriteLine("DELETED!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void DeleteArtist()
        {
            try
            {
                Console.WriteLine("::DELETE ARTIST::");
                Console.WriteLine("INSERT THE ID OF THE ARTIST TO BE DELETED!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"THIS ARTIST NAME: {(rest.Get<Artist>(id, "artist")).ArtistName} WILL BE DELETED!");
                rest.Delete(id, "artist");
                Console.WriteLine("DELETED!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
