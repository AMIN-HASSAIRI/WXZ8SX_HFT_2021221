using ConsoleTools;
using System;
using System.Linq;
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
               .Add(">> DELETE SONG", () => DeleteSong())
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

            var subMenuList = new ConsoleMenu()
               .Add(">> LIST ALBUMS", () => GetAllAlbums())
               .Add(">> LIST GENRES", () => GetAllGenres())
               .Add(">> LIST ARTISTS", () => GetAllArtists())
               .Add(">> LIST SONGS", () => GetAllSongs()) //ERROR!!
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

            var subMenuGetById = new ConsoleMenu()
               .Add(">> GET ALBUM BY ID", () => GetAlbumById())
               .Add(">> GET GENRE BY ID", () => GetGenreById())
               .Add(">> GET ARTIST BY ID", () => GetArtistById())
               .Add(">> GET SONG BY ID", () => GetSongById()) //ERROR!!
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

            subMenuGetById.Show();
            //menu.Show();

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

        #region DELETE METHODS
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
        private static void DeleteSong()
        {
            try
            {
                Console.WriteLine("::DELETE SONG::");
                Console.WriteLine("INSERT THE ID OF THE SONG TO BE DELETED!");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine($"THIS SONG NAME: {(rest.Get<Song>(id, "song")).Name} WILL BE DELETED!");
                rest.Delete(id, "song");
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
        #endregion

        #region GETALL LIST METHODS
        private static void GetAllAlbums()
        {
            Console.WriteLine("\n::ALL ALBUMS::\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}",
                "ID","Album Name", "Date Of Release", "Number Of Songs", "Rating", 
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var allAlbums = rest.Get<Album>("album");
            string data = "";
            foreach (var item in allAlbums)
            {
                data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}\n",
                    item.AlbumId, item.AlbumName,
                    item.ReleasedDate, item.NumberOfSongs, item.Rating,
                    item.ArtistId, item.GenreId);
            }
            Console.WriteLine(data);

            Console.ReadLine();
        }
        private static void GetAllGenres()
        {
            Console.WriteLine("\n::ALL GENRES::\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-25}", "ID", "Genre Name");
            Console.ResetColor();

            var allGenres = rest.Get<Genre>("genre");
            string data = "";
            foreach (var item in allGenres)
            {
                data += String.Format("{0,4} {1,-25}\n", item.GenreId, item.GenreName);
            }
            Console.WriteLine(data);

            Console.ReadLine();
        }
        private static void GetAllArtists()
        {
            Console.WriteLine("\n::ALL ARTISTS::\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
            Console.ResetColor();

            var allArtists = rest.Get<Artist>("artist");
            string data = "";
            foreach (var item in allArtists)
            {
                data += String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                    item.ArtistId, item.ArtistName, item.DateOfBirth, item.NumberOfAlbums);
            }
            Console.WriteLine(data);

            Console.ReadLine();
        }
        private static void GetAllSongs()
        {
            Console.WriteLine("\n::ALL SONGS::\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}",
                "ID", "Song Name", "Length","Writer","Singer","Album ID");
            Console.ResetColor();

            var allSongs = rest.Get<Song>("song");
            string data = "";
            foreach (var item in allSongs)
            {
                data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}\n",
                    item.SongId, item.Name, item.Length, item.Writer, item.Singer, item.AlbumId);
            }
            Console.WriteLine(data);

            Console.ReadLine();
        }
        #endregion

        private static void GetAlbumById()
        {
            Console.WriteLine("\n::GET ALBUM BY ID::\n");
            Console.WriteLine("INSERT ALBUM ID!");
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();
            try
            {
                var album = rest.GetSingle<Album>($"album/{id}");
                string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}\n",
                    album.AlbumId, album.AlbumName,
                    album.ReleasedDate, album.NumberOfSongs, album.Rating,
                    album.ArtistId, album.GenreId);
                Console.WriteLine(data);
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
        private static void GetGenreById()
        {
            Console.WriteLine("\n::GET GENRE BY ID::\n");
            Console.WriteLine("INSERT GENRE ID!");
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-25}", "ID", "Genre Name");
            Console.ResetColor();
            try
            {
                var genre = rest.GetSingle<Genre>($"genre/{id}");
                string data = String.Format("{0,4} {1,-25}\n", genre.GenreId, genre.GenreName);
                Console.WriteLine(data);
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
        private static void GetArtistById()
        {
            Console.WriteLine("\n::GET ARTIST BY ID::\n");
            Console.WriteLine("INSERT ARTIST ID!");
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                             "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
            Console.ResetColor();
            try
            {
                var artist = rest.GetSingle<Artist>($"artist/{id}");
                string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                    artist.ArtistId, artist.ArtistName, artist.DateOfBirth, artist.NumberOfAlbums);
                Console.WriteLine(data);
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
        private static void GetSongById()
        {
            Console.WriteLine("\n::GET SONG BY ID::\n");
            Console.WriteLine("INSERT SONG ID!");
            int id = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();
            try
            {
                var song = rest.GetSingle<Song>($"song/{id}");
                string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}\n",
                    song.SongId, song.Name, song.Length, song.Writer, song.Singer, song.AlbumId);
                Console.WriteLine(data);
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
