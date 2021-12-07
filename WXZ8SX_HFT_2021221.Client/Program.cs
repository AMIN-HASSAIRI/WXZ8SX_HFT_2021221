using ConsoleTools;
using System;
using System.Collections.Generic;
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

            #region SUB-MENU CRUD
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
                   config.Title = "Sub menu ==> CREATE";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
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
                   config.Title = "Sub menu ==> DELETE";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuList = new ConsoleMenu()
               .Add(">> LIST ALBUMS", () => GetAllAlbums())
               .Add(">> LIST GENRES", () => GetAllGenres())
               .Add(">> LIST ARTISTS", () => GetAllArtists())
               .Add(">> LIST SONGS", () => GetAllSongs()) 
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> SHOW ALL";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuGetById = new ConsoleMenu()
               .Add(">> GET ALBUM BY ID", () => GetAlbumById())
               .Add(">> GET GENRE BY ID", () => GetGenreById())
               .Add(">> GET ARTIST BY ID", () => GetArtistById())
               .Add(">> GET SONG BY ID", () => GetSongById()) 
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> SHOW SINGLE";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuUpdate = new ConsoleMenu()
               .Add(">> UPDATE ALBUM", () => UpdateAlbum())
               .Add(">> UPDATE GENRE", () => UpdateGenre())
               .Add(">> UPDATE ARTIST", () => UpdateArtist())
               .Add(">> UPDATE SONG", () => UpdateSong())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> UPDATE";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });
            #endregion

            var subMenuCRUD = new ConsoleMenu()
               .Add(">> C - CREATE", () => subMenuCreate.Show())
               .Add(">> R - READ ALL", () => subMenuList.Show())
               .Add(">> R - READ ", () => subMenuGetById.Show())
               .Add(">> U - UPDATE", () => subMenuUpdate.Show())
               .Add(">> D - DELETE", () => subMenuDelete.Show())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            #region SUB-MENU NON CRUD
            var subMenuAlbumNonCRUD = new ConsoleMenu()
               .Add(">> GET ALBUMS BY ARTIST ID", () => GetAlbumsByArtistId())
               .Add(">> GET ALBUMS BY YEAR", () => GetAlbumsByYear())
               .Add(">> GET BEST ALBUMS", () => GetBestAlbums())
               .Add(">> GET THE LONGEST ALBUM", () => GetTheLongestAlbum())
               .Add(">> GET THE NEWEST ALBUM", () => GetTheNewestAlbum())
               .Add(">> GET THE OLDEST ALBUM", () => GetTheOldestAlbum())
               .Add(">> GET THE SHORTEST ALBUM", () => GetTheShortestAlbum())
               .Add(">> GET THE GENRE NAME OF ALBUM BY SONG ID", () => GetGenreNameOfAlbumBySongId())
               .Add(">> GET THE ARTIST NAME BY SONG ID", () => GetArtistNameOfAlbumBySongId())
               .Add(">> GET THE LONGEST SONG IN EACH ALBUM", () => GetLongestSongInEachAlbum())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> ALBUM NON-CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuGenreNonCRUD = new ConsoleMenu()
               .Add(">> GET ALL ALBUMS WITH GENRE", () => GetAllAlbumsWithGenre())
               .Add(">> GET NUMBER OF SONGS IN EACH GENRE", () => NumberOfSongsInEachGenre())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> GENRE NON-CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuArtistNonCRUD = new ConsoleMenu()
               .Add(">> GET ALBUM NAME BY ARTIST ID", () => GetAlbumNameByArtistId())
               .Add(">> GET ALBUMS OF ARTIST", () => GetAlbumsOfArtist())
               .Add(">> GET ARTISTS ORDERED BY DATE OF BIRTH", () => GetArtistsOrderedByBirthDate())
               .Add(">> GET ARTISTS ORDERED BY BY NAME", () => GetArtistsOrderedByName())
               .Add(">> GET ARTISTS ORDERED BY NUMBER OF ALBUMS", () => GetArtistsOrderedByNumOfAlbums())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> ARTIST NON-CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            var subMenuSongNonCRUD = new ConsoleMenu()
               .Add(">> GET ALBUM NAME OF SONG BY SONG ID", () => GetAlbumNameOfSong())
               .Add(">> GET DATE OF BIRTH OF SINGER BY SONG ID", () => GetDateOfBirthOfSinger())
               .Add(">> GET THE LONGEST SONG", () => GetLongestSong())
               .Add(">> GET THE SHORTEST SONG", () => GetShortestSong())
               .Add(">> GET ALL SONGS ORDERED BY LENGTH", () => GetSongsOrderedByLength())
               .Add(">> GET ALL SONGS ORDERED BY NAME", () => GetSongsOrderedByName())
               .Add(">> GET WRITER NAME OF SONG BY SONG ID", () => GetWriterNameOfSong())
               .Add(">> GET NUMBER OF ALBUMS BY SONG ID", () => GetNumberOfAlbumsBySongId())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> SONG NON-CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });
            #endregion

            var subMenuNonCRUD = new ConsoleMenu()
               .Add(">> ALBUM NON CRUD FUNCTIONALITIES", () => subMenuAlbumNonCRUD.Show())
               .Add(">> GENRE NON CRUD FUNCTIONALITIES", () => subMenuGenreNonCRUD.Show())
               .Add(">> ARTIST NON CRUD FUNCTIONALITIES", () => subMenuArtistNonCRUD.Show())
               .Add(">> SONG NON CRUD FUNCTIONALITIES", () => subMenuSongNonCRUD.Show())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Sub menu ==> NON-CRUD";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            ///////////////////////////////////////////////////////////////////////////////////////
            var menu = new ConsoleMenu(args, level: 0)
               .Add(">> ENTER TO CRUD FUNCTIONALITIES", () => subMenuCRUD.Show())
               .Add(">> ENTER TO NONCRUD FUNCTIONALITIES", () => subMenuNonCRUD.Show())
               .Add("Close", ConsoleMenu.Close)
               .Add("Exit", () => Environment.Exit(0))
               .Configure(config =>
               {
                   config.Selector = "--> ";
                   config.EnableFilter = true;
                   config.Title = "Main menu ==> MUSIC TIME";
                   config.EnableWriteTitle = true;
                   config.SelectedItemBackgroundColor = ConsoleColor.Yellow;
               });

            menu.Show();
        }

        #region CREATE METHODS
        private static void CreateAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<CREATING A NEW ALBUM>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT ALBUM NAME!");
                string name = Console.ReadLine();
                Console.WriteLine("INSERT DATE OF RELEASED OF THE ALBUM IN THIS FORMAT (MM/dd/yyyy)!");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NUMBER OF SONGS OF THE ALBUM!");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine("INSERT THE LENGTH OF THE ALBUM!");
                double length = double.Parse(Console.ReadLine());
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
                    Length = length,
                    Rating = rating,
                    ArtistId = artId,
                    GenreId = genId,
                }, "album");
                Console.WriteLine("NEW ALBUM WAS CREATED!");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<CREATE GENRE>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT GENRE NAME!");
                string name = Console.ReadLine();
                rest.Post<Genre>(new Genre()
                {
                    GenreName = name,
                }, "genre");
                Console.WriteLine("NEW GENRE WAS CREATED!");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<CREATE ARTIST>>\n");
            Console.ResetColor();
            try
            {
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
                Console.WriteLine("NEW ARTIST WAS CREATED!");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<CREATE SONG>>\n");
            Console.ResetColor();
            try
            {
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
                Console.WriteLine("NEW SONG WAS CREATED!");
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<DELETE ALBUM>>\n");
            Console.ResetColor();
            try
            {
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<DELETE GENRE>>\n");
            Console.ResetColor();
            try
            {
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<DELETE ARTIST>>\n");
            Console.ResetColor();
            try
            {
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<DELETE SONG>>\n");
            Console.ResetColor();
            try
            {
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALL ALBUMS>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var allAlbums = rest.Get<Album>("album");
            string data = "";
            foreach (var item in allAlbums)
            {
                data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    item.AlbumId, item.AlbumName,
                    item.ReleasedDate, item.NumberOfSongs, item.Length ,item.Rating,
                    item.ArtistId, item.GenreId);
            }
            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetAllGenres()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALL GENRES>>\n");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALL ARTISTS>>\n");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALL SONGS>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();

            var allSongs = rest.Get<Song>("song");
            string data = "";
            foreach (var item in allSongs)
            {
                data += String.Format("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}\n",
                    item.SongId, item.Name, item.Length, item.Writer, item.Singer, item.AlbumId);
            }
            Console.WriteLine(data);
            Console.ReadLine();
        }
        #endregion

        #region GETBYID METHODS
        private static void GetAlbumById()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALBUM BY ID>>\n");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET GENRE BY ID>>\n");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ARTIST BY ID>>\n");
            Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET SONG BY ID>>\n");
            Console.ResetColor();
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
        #endregion

        #region UPDATE METHODS
        private static void UpdateAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<UPDATE ALBUM>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT ALBUM ID TO BE UPDATED");
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

                Console.WriteLine("INSERT NEW NAME FOR THE ALBUM!");
                album.AlbumName = Console.ReadLine();
                Console.WriteLine("INSERT NEW DATE OF RELEASE OF THE ALBUM (MM/dd/yyyy)!");
                album.ReleasedDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NEW NUMBER OF SONGS OF THE ALBUM!");
                album.NumberOfSongs = int.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NEW RATING OF THE ALBUM!");
                album.Rating = double.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NEW ARTIST ID OF THE ALBUM!");
                album.ArtistId = int.Parse(Console.ReadLine());
                Console.WriteLine("INSERT NEW GENRE ID OF THE ALBUM!");
                album.GenreId = int.Parse(Console.ReadLine());
                rest.Put<Album>(album, "album");

                string newData = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}\n",
                                  album.AlbumId, album.AlbumName,
                                  album.ReleasedDate, album.NumberOfSongs, album.Rating,
                                  album.ArtistId, album.GenreId);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10}",
                    "ID", "Album Name", "Date Of Release", "Number Of Songs", "Rating",
                    "Artist ID", "Genre ID");
                Console.ResetColor();
                Console.WriteLine("ALBUM WAS UPDATED!");
                Console.WriteLine(newData);
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
        private static void UpdateGenre()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<UPDATE GENRE>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT GENRE ID TO BE UPDATED");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-25}", "ID", "Genre Name");
                Console.ResetColor();

                var genre = rest.GetSingle<Genre>($"genre/{id}");
                string data = String.Format("{0,4} {1,-25}\n", genre.GenreId, genre.GenreName);
                Console.WriteLine(data);

                Console.WriteLine("INSERT NEW NAME FOR THE GENRE!");
                string newName = Console.ReadLine();
                genre.GenreName = newName;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-25}", "ID", "Genre Name");
                Console.ResetColor();
                data = String.Format("{0,4} {1,-25}\n", genre.GenreId, genre.GenreName);
                Console.WriteLine(data);
                Console.ReadLine();
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
        private static void UpdateArtist()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<UPDATE ARTIST>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT ARTIST ID TO BE UPDATED");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                                 "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
                Console.ResetColor();

                var artist = rest.GetSingle<Artist>($"artist/{id}");
                string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                    artist.ArtistId, artist.ArtistName, artist.DateOfBirth, artist.NumberOfAlbums);
                Console.WriteLine(data);

                Console.WriteLine("INSERT NEW NAME FOR THE ARTIST!");
                string newName = Console.ReadLine();
                artist.ArtistName = newName;
                Console.WriteLine("INSERT NEW DATE OF BIRTH OF THE ARTIST (MM/dd/yyyy)!");
                DateTime newDate = DateTime.Parse(Console.ReadLine());
                artist.DateOfBirth = newDate;
                Console.WriteLine("INSERT NEW NUMBER OF ALBUMS!");
                int newNum = int.Parse(Console.ReadLine());
                artist.NumberOfAlbums = newNum;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                                 "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
                Console.ResetColor();
                data = String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                    artist.ArtistId, artist.ArtistName, artist.DateOfBirth, artist.NumberOfAlbums);
                Console.WriteLine(data);
                Console.ReadLine();
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
        private static void UpdateSong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<UPDATE SONG>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT SONG ID TO BE UPDATED");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}",
                    "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
                Console.ResetColor();
                var song = rest.GetSingle<Song>($"song/{id}");
                string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}\n",
                    song.SongId, song.Name, song.Length, song.Writer, song.Singer, song.AlbumId);
                Console.WriteLine(data);

                Console.WriteLine("INSERT NEW NAME OF THE SONG!");
                string newName = Console.ReadLine();
                song.Name = newName;
                Console.WriteLine("INSERT NEW LENGTH OF THE SONG (0.0)!");
                double newLength = double.Parse(Console.ReadLine());
                song.Length = newLength;
                Console.WriteLine("INSERT NEW WRITER OF THE SONG!");
                string newWriter = Console.ReadLine();
                song.Writer = newWriter;
                Console.WriteLine("INSERT NEW SINGER OF THE SONG!");
                string newSinger = Console.ReadLine();
                song.Singer = newSinger;
                Console.WriteLine("INSERT NEW ALBUM ID OF THE SONG!");
                int newAlbumId = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}",
                    "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
                Console.ResetColor();
                data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}\n",
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
        #endregion

        #region NONCRUD ALBUM METHODS
        private static void GetAlbumsByArtistId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALBUMS BY ARTIST ID>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT ARTIST ID!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
                Console.ResetColor();

                var Albums = rest.Get<Album>($"statalbum/getalbumsbyartist/{id}");
                string data = "";
                foreach (var item in Albums)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                        item.AlbumId, item.AlbumName,
                        item.ReleasedDate, item.NumberOfSongs, item.Length, item.Rating,
                        item.ArtistId, item.GenreId);
                }
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
        private static void GetAlbumsByYear()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<ALBUMS BY YEAR>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT THE YEAR (yyyy)!");
            try
            {
                int yyyy = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
                Console.ResetColor();

                var albums = rest.Get<Album>($"statalbum/getalbumsbyyear/{yyyy}");
                string data = "";
                foreach (var item in albums)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                        item.AlbumId, item.AlbumName,
                        item.ReleasedDate, item.NumberOfSongs, item.Length, item.Rating,
                        item.ArtistId, item.GenreId);
                }
                Console.WriteLine(data);

                Console.ReadLine();
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
        private static void GetGenreNameOfAlbumBySongId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET GENRE NAME BY SONG ID>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            Console.WriteLine("INSERT THE SONG ID!");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var genreName = rest.GetSingle<string>($"statalbum/getgenrenameofalbumbysongid/{id}");
                Console.WriteLine($"THE GENRE NAME CONCERNING THIS SONG ID: ({id}) IS : {genreName}");
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
        private static void GetArtistNameOfAlbumBySongId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ARTIST NAME OF ALBUM BY SONG ID>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ResetColor();
            Console.WriteLine("INSERT THE SONG ID!");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var artistName = rest.GetSingle<string>($"statalbum/getartistnameofalbumbysongid/{id}");
                Console.WriteLine($"THE ARTIST NAME CONCERNING THIS SONG ID: ({id}) IS : {artistName}");
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
        private static void GetBestAlbums()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET BEST ALBUMS>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var albums = rest.Get<Album>($"statalbum/getbestalbums");
            string data = "";
            foreach (var item in albums)
            {
                data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    item.AlbumId, item.AlbumName,
                    item.ReleasedDate, item.NumberOfSongs,item.Length ,item.Rating,
                    item.ArtistId, item.GenreId);
            }
            Console.WriteLine(data);

            Console.ReadLine();
        }
        private static void GetTheLongestAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE LONGEST ALBUM>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var album = rest.GetSingle<Album>($"statalbum/getthelongestalbum");


            String data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    album.AlbumId, album.AlbumName,
                    album.ReleasedDate, album.NumberOfSongs, album.Length, album.Rating,
                    album.ArtistId, album.GenreId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetTheNewestAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE NEWEST ALBUM>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var album = rest.GetSingle<Album>($"statalbum/getthenewestalbum");


            String data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    album.AlbumId, album.AlbumName,
                    album.ReleasedDate, album.NumberOfSongs, album.Length, album.Rating,
                    album.ArtistId, album.GenreId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetTheOldestAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE OLDEST ALBUM>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var album = rest.GetSingle<Album>($"statalbum/gettheoldestalbum");


            String data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    album.AlbumId, album.AlbumName,
                    album.ReleasedDate, album.NumberOfSongs, album.Length, album.Rating,
                    album.ArtistId, album.GenreId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetTheShortestAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE SHORTEST ALBUM>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
            Console.ResetColor();

            var album = rest.GetSingle<Album>($"statalbum/gettheshortestalbum");

            String data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                    album.AlbumId, album.AlbumName,
                    album.ReleasedDate, album.NumberOfSongs, album.Length, album.Rating,
                    album.ArtistId, album.GenreId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetLongestSongInEachAlbum()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET LONGEST SONG IN EACH ALBUM>>\n");
            Console.ResetColor();
            List<KeyValuePair<string, double>> pairs = rest.GetPairs<string, double>("statalbum/getlongestsongineachalbum");

            foreach (KeyValuePair<string, double> pair in pairs)
            {
                Console.WriteLine($"ALBUM NAME: {pair.Key}  ====>  LONGEST SONG: {pair.Value}");
            }
            Console.ReadKey();
        }
        #endregion

        #region NONCRUD GENRE METHODS
        private static void GetAllAlbumsWithGenre()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALL ALBUMS WITH GENRE>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT GENRE ID!");
                int id = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
                Console.ResetColor();

                var albums = rest.Get<Album>($"statgenre/getallalbumswithgenre/{id}");
                string data = "";
                foreach (var item in albums)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                        item.AlbumId, item.AlbumName,
                        item.ReleasedDate, item.NumberOfSongs, item.Length, item.Rating,
                        item.ArtistId, item.GenreId);
                }
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
        private static void NumberOfSongsInEachGenre()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET NUMBER OF SONGS IN EACH GENRE>>\n");
            Console.ResetColor();
            List<KeyValuePair<string, int>> pairs = rest.GetPairs<string,int>("statgenre/numberofsongsineachgenre");

            foreach (KeyValuePair<string, int> pair in pairs)
            {
                Console.WriteLine($"GENRE NAME: {pair.Key}  ====>  NOMBER OF SONGS: {pair.Value}");
            }
            Console.ReadKey();
        }
        #endregion

        #region NONCRUD ARTIST METHODS
        private static void GetAlbumNameByArtistId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALBUM NAME BY ARTIST ID>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT ARTIST ID!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                string albumName = rest.GetSingle<string>($"statartist/getalbumnamebyartistid/{id}");
                Console.WriteLine($"ALBUM NAME: {albumName}");
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
        private static void GetAlbumsOfArtist()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALBUMS OF ARTIST>>\n");
            Console.ResetColor();
            Console.WriteLine("INSERT ARTIST ID!");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var albums = rest.Get<Album>($"statartist/getalbumsofartist/{id}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}",
                "ID", "Album Name", "Date Of Release", "Number Of Songs", "Length", "Rating",
                "Artist ID", "Genre ID");
                Console.ResetColor();

                string data = "";
                foreach (var item in albums)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-10} {5,-10} {6,-10} {7,-10}\n",
                        item.AlbumId, item.AlbumName,
                        item.ReleasedDate, item.NumberOfSongs, item.Length, item.Rating,
                        item.ArtistId, item.GenreId);
                }
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
        private static void GetArtistsOrderedByBirthDate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ARTISTS ORDERED BY DATE OF BIRTH>>\n");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                    "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
                Console.ResetColor();

                var artists = rest.Get<Artist>($"statartist/getartistsorderedbybirthdate");

                string data = "";
                foreach (var item in artists)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                        item.ArtistId, item.ArtistName, item.DateOfBirth, item.NumberOfAlbums);
                }
                Console.WriteLine(data);
                Console.ReadLine();
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
        private static void GetArtistsOrderedByName()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ARTISTS ORDERED BY NAME>>\n");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                    "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
                Console.ResetColor();

                var artists = rest.Get<Artist>($"statartist/getartistsorderedbyname");

                string data = "";
                foreach (var item in artists)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                        item.ArtistId, item.ArtistName, item.DateOfBirth, item.NumberOfAlbums);
                }
                Console.WriteLine(data);
                Console.ReadLine();
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
        private static void GetArtistsOrderedByNumOfAlbums()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ARTISTS ORDERED BY NUMBER OF ALBUMS>>\n");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20}",
                    "ID", "Artist Name", "Date Of Birth", "Number Of Albums");
                Console.ResetColor();

                var artists = rest.Get<Artist>($"statartist/getartistsorderedbynumofalbums");

                string data = "";
                foreach (var item in artists)
                {
                    data += String.Format("{0,4} {1,-20} {2,-25} {3,-20}\n",
                        item.ArtistId, item.ArtistName, item.DateOfBirth, item.NumberOfAlbums);
                }
                Console.WriteLine(data);
                Console.ReadLine();
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

        #region NONCRUD SONG METHODS
        private static void GetAlbumNameOfSong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALBUM NAME OF SONG BY SONG ID>>\n");
            Console.ResetColor();
            try
            {
                int id = int.Parse(Console.ReadLine());
                var albumName = rest.GetSingle<string>($"statsong/getalbumnameofsong/{id}");
                
                Console.WriteLine($"\nTHE ALBUM NAME RELATED TO SONG ID {id} IS: {albumName} ");
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
        private static void GetDateOfBirthOfSinger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET DATE OF BIRTH OF SINGER BY SONG ID>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT SONG ID!");
                int id = int.Parse(Console.ReadLine());
                var dateOfBirth = rest.GetSingle<DateTime>($"statsong/getdateofbirthofsinger/{id}");
                Console.WriteLine($"DATE OF BIRTH IS: {dateOfBirth}");
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
        private static void GetNumberOfAlbumsBySongId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET NUMBER OF ALBUMS BY SONG ID>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT ID SONG!");
                int id = int.Parse(Console.ReadLine());
                var albumnNum = rest.GetSingle<int>($"statsong/getnumberofalbumsbysongid/{id}");
                Console.WriteLine($"THE NUMBER OF ALBUMS IS: {albumnNum}");
                Console.ResetColor();
                Console.ReadLine();
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
        private static void GetLongestSong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE LONGEST SONG>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();

            var song = rest.GetSingle<Song>($"statsong/getlongestsong");
            string data = String.Format("{0,4} {1,-20} {2,-25} {3,-20} {4,-20} {5,-20}\n",
                    song.SongId, song.Name, song.Length, song.Writer, song.Singer, song.AlbumId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetShortestSong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET THE SHORTEST SONG>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-15} {2,-25} {3,-40} {4,-20} {5,-30}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();

            var song = rest.GetSingle<Song>($"statsong/getshortestsong");
            string data = String.Format("{0,4} {1,-15} {2,-25} {3,-40} {4,-20} {5,-30}\n",
                    song.SongId, song.Name, song.Length, song.Writer, song.Singer, song.AlbumId);

            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetSongsOrderedByLength()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALL SONGS ORDERED BY LENGTH>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();

            var songs = rest.Get<Song>($"statsong/getsongsorderedbylength");
            string data = "";
            foreach (var item in songs)
            {
                data += String.Format("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}\n",
                    item.SongId, item.Name, item.Length, item.Writer, item.Singer, item.AlbumId);
            }
            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetSongsOrderedByName()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET ALL SONGS ORDERED BY NAME>>\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}",
                "ID", "Song Name", "Length", "Writer", "Singer", "Album ID");
            Console.ResetColor();

            var songs = rest.Get<Song>($"statsong/getsongsorderedbyname");
            string data = "";
            foreach (var item in songs)
            {
                data += String.Format("{0,4} {1,-36} {2,-7} {3,-107} {4,-20} {5,-4}\n",
                    item.SongId, item.Name, item.Length, item.Writer, item.Singer, item.AlbumId);
            }
            Console.WriteLine(data);
            Console.ReadLine();
        }
        private static void GetWriterNameOfSong()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t<<GET WRITER NAME OF SONG BY SONG ID>>\n");
            Console.ResetColor();
            try
            {
                Console.WriteLine("INSERT SONG ID");
                int id = int.Parse(Console.ReadLine());
                var writerName = rest.GetSingle<string>($"statsong/getwriternameofsong/{id}");
                Console.WriteLine($"WRITER NAME IS: {writerName}");
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
    }
}
