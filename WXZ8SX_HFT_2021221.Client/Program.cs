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
    }
}
