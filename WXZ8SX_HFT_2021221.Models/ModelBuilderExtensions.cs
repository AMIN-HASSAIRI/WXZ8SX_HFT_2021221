using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXZ8SX_HFT_2021221.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumId = 1,
                    AlbumName = "D'eux",
                    ReleasedDate = DateTime.Parse("03/30/1995"),
                    NumberOfSongs = 12,
                    Rating = 4.7,
                    Length = 47.16,
                    ArtistId = 1,
                    GenreId = 1
                },
                new Album
                {
                    AlbumId = 2,
                    AlbumName = "A New Day Has Come",
                    ReleasedDate = DateTime.Parse("03/22/2002"),
                    NumberOfSongs = 17,
                    Rating = 4.7,
                    Length = 72.14,
                    ArtistId = 1,
                    GenreId = 1
                },
                new Album
                {
                    AlbumId = 3,
                    AlbumName = "Dangerous",
                    ReleasedDate = DateTime.Parse("11/26/1991"),
                    NumberOfSongs = 14,
                    Rating = 4.8,
                    Length = 77.03,
                    ArtistId = 2,
                    GenreId = 11
                },
                new Album
                {
                    AlbumId = 4,
                    AlbumName = "Bad",
                    ReleasedDate = DateTime.Parse("08/31/1987"),
                    NumberOfSongs = 11,
                    Rating = 4.8,
                    Length = 48.40,
                    ArtistId = 2,
                    GenreId = 11
                },
                new Album
                {
                    AlbumId = 5,
                    AlbumName = "Catch a Fire",
                    ReleasedDate = DateTime.Parse("04/13/1973"),
                    NumberOfSongs = 11,
                    Rating = 4.8,
                    Length = 37.51,
                    ArtistId = 3,
                    GenreId = 12
                },
                new Album
                {
                    AlbumId = 6,
                    AlbumName = "Queen",
                    ReleasedDate = DateTime.Parse("08/10/2018"),
                    NumberOfSongs = 19,
                    Rating = 4.7,
                    Length = 66.19,
                    ArtistId = 4,
                    GenreId = 8
                },
                new Album
                {
                    AlbumId = 7,
                    AlbumName = "Future Nostalgia",
                    ReleasedDate = DateTime.Parse("03/27/2020"),
                    NumberOfSongs = 11,
                    Rating = 4.8,
                    Length = 37.17,
                    ArtistId = 5,
                    GenreId = 1
                },
                new Album
                {
                    AlbumId = 8,
                    AlbumName = "In My Memory",
                    ReleasedDate = DateTime.Parse("04/15/2001"),
                    NumberOfSongs = 9,
                    Rating = 4.7,
                    Length = 68.19,
                    ArtistId = 6,
                    GenreId = 6
                }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId = 1,
                    GenreName = "Pop"
                },
                new Genre
                {
                    GenreId = 2,
                    GenreName = "Metal"
                },
                new Genre
                {
                    GenreId = 3,
                    GenreName = "Rock"
                },
                new Genre
                {
                    GenreId = 4,
                    GenreName = "Flamenco"
                },
                new Genre
                {
                    GenreId = 5,
                    GenreName = "Jazz"
                },
                new Genre
                {
                    GenreId = 6,
                    GenreName = "House"
                },
                new Genre
                {
                    GenreId = 7,
                    GenreName = "Hip Hop"
                },
                new Genre
                {
                    GenreId = 8,
                    GenreName = "Rap"
                },
                new Genre
                {
                    GenreId = 9,
                    GenreName = "Folk"
                },
                new Genre
                {
                    GenreId = 10,
                    GenreName = "Latin"
                },
                new Genre
                {
                    GenreId = 11,
                    GenreName = "R&B and soul"
                },
                new Genre
                {
                    GenreId = 12,
                    GenreName = "Reggae"
                }
                );

            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ArtistId = 1,
                    ArtistName = "Celine Dion",
                    DateOfBirth = DateTime.Parse("03/30/1968"),
                    NumberOfAlbums = 27
                },
                new Artist
                {
                    ArtistId = 2,
                    ArtistName = "Michael Jackson",
                    DateOfBirth = DateTime.Parse("08/29/1958"),
                    NumberOfAlbums = 10
                },
                new Artist
                {
                    ArtistId = 3,
                    ArtistName = "Bob Marley",
                    DateOfBirth = DateTime.Parse("02/06/1945"),
                    NumberOfAlbums = 13
                },
                new Artist
                {
                    ArtistId = 4,
                    ArtistName = "Nicki Minaj",
                    DateOfBirth = DateTime.Parse("12/08/1982"),
                    NumberOfAlbums = 4
                },
                new Artist
                {
                    ArtistId = 5,
                    ArtistName = "Dua Lipa",
                    DateOfBirth = DateTime.Parse("08/22/1995"),
                    NumberOfAlbums = 2
                },
                new Artist
                {
                    ArtistId = 6,
                    ArtistName = "Tiesto",
                    DateOfBirth = DateTime.Parse("01/17/1969"),
                    NumberOfAlbums = 6
                }
                );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Name = "Pour que tu m'aime encore",
                    Length = 4.14,
                    Writer = "Jean-Jacques Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 2,
                    Name = "Le Ballet",
                    Length = 4.23,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 3,
                    Name = "Regarde-moi",
                    Length = 3.57,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 4,
                    Name = "Je sais pas",
                    Length = 4.33,
                    Writer = "Goldman, JKapler",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 5,
                    Name = "La memoire d'Abraham",
                    Length = 3.50,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 6,
                    Name = "Cherche encore",
                    Length = 3.24,
                    Writer = "Erick Benzi",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 7,
                    Name = "Destin",
                    Length = 4.15,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 8,
                    Name = "Les derniers seront les premiers",
                    Length = 3.33,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 9,
                    Name = "J'irai ou tu iras",
                    Length = 3.26,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 10,
                    Name = "J'attendais",
                    Length = 4.24,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 11,
                    Name = "Priere paienne",
                    Length = 4.10,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 12,
                    Name = "Vole",
                    Length = 2.57,
                    Writer = "Goldman",
                    Singer = "Celine Dion",
                    AlbumId = 1
                },
                new Song
                {
                    SongId = 13,
                    Name = "I'm Alive",
                    Length = 3.30,
                    Writer = "Kristian Lundin, Andreas Carlsson",
                    Singer = "Celine Dion",
                    AlbumId = 2
                }
                ,
                new Song
                {
                    SongId = 14,
                    Name = "Right in Front of You",
                    Length = 4.13,
                    Writer = "Steve Morales, Sheppard Solomon, Kara DioGuardi",
                    Singer = "Celine Dion",
                    AlbumId = 2
                }
                ,
                new Song
                {
                    SongId = 15,
                    Name = "Have You Ever Been in Love",
                    Length = 4.08,
                    Writer = "Anders Bagge, Peer Åström, Tom Nichols, Daryl Hall, Laila Bagge",
                    Singer = "Celine Dion",
                    AlbumId = 2
                }
                ,
                new Song
                {
                    SongId = 16,
                    Name = "Rain, Tax (It's Inevitable)",
                    Length = 3.25,
                    Writer = "Terry Britten, Charlie Dore",
                    Singer = "Celine Dion",
                    AlbumId = 2
                }
                ,
                new Song
                {
                    SongId = 17,
                    Name = "A New Day Has Come",
                    Length = 4.23,
                    Writer = "Aldo Nova, Stephan Moccio",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 18,
                    Name = "Ten Days",
                    Length = 3.37,
                    Writer = "Nova, Maxime Le Forestier, Gérald de Palmas",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 19,
                    Name = "Goodbye's (The Saddest Word)",
                    Length = 5.19,
                    Writer = "Robert John Mutt Lange",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 20,
                    Name = "Prayer",
                    Length = 5.34,
                    Writer = "Corey Hart",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 21,
                    Name = "I Surrender",
                    Length = 4.47,
                    Writer = "Louis Biancaniello, Sam Watters",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 22,
                    Name = "At Last",
                    Length = 4.17,
                    Writer = "Mack Gordon, Harry Warren",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 23,
                    Name = "Super Love",
                    Length = 4.16,
                    Writer = "Roche, Shelly Peiken",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 24,
                    Name = "Sorry for Love",
                    Length = 4.10,
                    Writer = "DioGuardi, Bagge, Åström, Arnthor Birgisson",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 25,
                    Name = "Aun Existe Amor",
                    Length = 3.52,
                    Writer = "Riccardo Cocciante, Ignacio Ballesteros-Diaz",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 26,
                    Name = "The Greatest Reward",
                    Length = 3.28,
                    Writer = "Pascal Obispo, Carlsson, Jörgen Elofsson, Lionel Florence, Patrice Guirao",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 27,
                    Name = "When the Wrong One Loves You Right",
                    Length = 3.48,
                    Writer = "Martin Briley, Francis Galluccio, Marjorie Maye",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 28,
                    Name = "A New Day Has Come",
                    Length = 5.42,
                    Writer = "Nova, Moccio",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 29,
                    Name = "Nature Boy",
                    Length = 2.57,
                    Writer = "eden ahbez",
                    Singer = "Celine Dion",
                    AlbumId = 2
                },
                new Song
                {
                    SongId = 30,
                    Name = "Jam",
                    Length = 5.39,
                    Writer = "Michael Jackson, René Moore, Bruce Swedien, Teddy Riley",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 31,
                    Name = "Why You Wanna Trip on Me",
                    Length = 5.24,
                    Writer = "RileyBernard Belle",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 32,
                    Name = "In the Closet",
                    Length = 6.32,
                    Writer = "Jackson, Riley",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 33,
                    Name = "She Drives Me Wild",
                    Length = 3.42,
                    Writer = "Jackson, Riley, Aqil Davidson",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 34,
                    Name = "Can't Let Her Get Away",
                    Length = 4.59,
                    Writer = "Jackson, Riley",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 35,
                    Name = "Heal the World",
                    Length = 6.25,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 36,
                    Name = "Black or White",
                    Length = 4.16,
                    Writer = "Jackson, Bill Bottrell",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 37,
                    Name = "Who Is It",
                    Length = 6.35,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 38,
                    Name = "Give In to Me",
                    Length = 5.30,
                    Writer = "Jackson, Bottrell",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 39,
                    Name = "Will You Be There",
                    Length = 7.41,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 40,
                    Name = "Keep the Faith",
                    Length = 5.57,
                    Writer = "Jackson, Glen Ballard, Siedah Garrett",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 41,
                    Name = "Gone Too Soon",
                    Length = 3.22,
                    Writer = "Larry Grossman, Buz Kohan",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 42,
                    Name = "Dangerous",
                    Length = 6.57,
                    Writer = "Jackson, Bottrell, Riley",
                    Singer = "Michael Jackson",
                    AlbumId = 3
                },
                new Song
                {
                    SongId = 43,
                    Name = "Bad",
                    Length = 4.08,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 44,
                    Name = "The Way You Make Me Feel",
                    Length = 4.59,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 45,
                    Name = "Speed Demon",
                    Length = 4.03,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 46,
                    Name = "Liberian Girl",
                    Length = 3.55,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 47,
                    Name = "Just Good Friends",
                    Length = 4.09,
                    Writer = "Terry Britten, Graham Lyle",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 48,
                    Name = "Another Part of Me",
                    Length = 3.55,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 49,
                    Name = "Man in the Mirror",
                    Length = 5.21,
                    Writer = "Siedah Garrett, Glen Ballard",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 50,
                    Name = "I Just Can't Stop Loving You",
                    Length = 4.27,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 51,
                    Name = "Dirty Diana",
                    Length = 4.42,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 52,
                    Name = "Smooth Criminal",
                    Length = 4.20,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 53,
                    Name = "Leave Me Alone",
                    Length = 4.41,
                    Writer = "Jackson",
                    Singer = "Michael Jackson",
                    AlbumId = 4
                },
                new Song
                {
                    SongId = 54,
                    Name = "Concrete Jungle",
                    Length = 4.11,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 55,
                    Name = "Stir It Up",
                    Length = 3.37,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 56,
                    Name = "High Tide or Low Tide",
                    Length = 4.40,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 57,
                    Name = "Stop That Train",
                    Length = 3.52,
                    Writer = "Tosh",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 58,
                    Name = "400 Years",
                    Length = 2.57,
                    Writer = "Tosh",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 59,
                    Name = "Baby We've Got a Date (Rock It Baby)",
                    Length = 4.00,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 60,
                    Name = "Midnight Ravers",
                    Length = 5.05,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 61,
                    Name = "All Day All Night",
                    Length = 3.26,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 62,
                    Name = "Slave Driver",
                    Length = 2.52,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 63,
                    Name = "Kinky Reggae",
                    Length = 3.40,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 64,
                    Name = "No More Trouble",
                    Length = 5.13,
                    Writer = "Bob Marley",
                    Singer = "Bob Marley",
                    AlbumId = 5
                },
                new Song
                {
                    SongId = 65,
                    Name = "Ganja Burn",
                    Length = 4.54,
                    Writer = "Onika Maraj, Jeremy Reid, Jairus Mozee",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 66,
                    Name = "Majesty",
                    Length = 4.55,
                    Writer = "Maraj, Timothy McKenzie, Marshall Mathers, Luis Resto",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 67,
                    Name = "Barbie Dreams",
                    Length = 4.39,
                    Writer = "Maraj, Rashad Smith, Melvin Hough II, Rivelino Raoul Wouter, Christopher Wallace, James Brown, Fred Wesley",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 68,
                    Name = "Rich Sex",
                    Length = 3.12,
                    Writer = "Maraj, Dwayne Carter, Reid, Jawara Headley, Aubry Delaine",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 69,
                    Name = "Hard White",
                    Length = 3.13,
                    Writer = "Maraj, Matthew Samuels, Ramon Ibanga Jr., Brittany Hazzard",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 70,
                    Name = "Bed",
                    Length = 3.09,
                    Writer = "Maraj, Benjamin Diehl, Gamal Lewis, Brett Bailey, Mescon David Asher, Dwayne Chin-Quee",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 71,
                    Name = "Thought I Knew You",
                    Length = 3.18,
                    Writer = "Maraj, Abel Tesfaye, Hazzard, Reid",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 72,
                    Name = "Run & Hide",
                    Length = 2.34,
                    Writer = "Maraj, Hazzard, Rupert Thomas Jr., Masamune Kudo",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 73,
                    Name = "Chun Swae",
                    Length = 6.10,
                    Writer = "Maraj, Khalif Brown, Leland Wayne",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 74,
                    Name = "Chun-Li",
                    Length = 3.11,
                    Writer = "Maraj, Reid",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 75,
                    Name = "LLC",
                    Length = 3.41,
                    Writer = "Maraj, Rasool Diaz, Wesley Dees, Jason Fox",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 76,
                    Name = "Good Form",
                    Length = 3.19,
                    Writer = "Maraj, Michael Williams II, Asheton Hogan",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 77,
                    Name = "Nip Tuck",
                    Length = 3.27,
                    Writer = "Maraj, Hazzard, Jeremy Coleman, Daniel Johnson, June Nawakii",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 78,
                    Name = "2 Lit 2 Late",
                    Length = 0.55,
                    Writer = "Maraj, Hazzard, Gramma, Adam King Feeney",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 79,
                    Name = "Come See About Me",
                    Length = 4.06,
                    Writer = "Maraj, Hazzard, Christopher Braide, Henry Walter",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 80,
                    Name = "Sir",
                    Length = 3.44,
                    Writer = "Maraj, Nayvadius Wilburn, Wayne, Xavier Dotson",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 81,
                    Name = "Miami",
                    Length = 3.10,
                    Writer = "Maraj, Shane Lindstrom, Diaz, Douglas Patterson",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 82,
                    Name = "Coco Chanel",
                    Length = 3.44,
                    Writer = "Maraj, Joshua Adams, Inga Marchand, Ashley Bannister, Dillon Hart Francis, Sonny Moore",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 83,
                    Name = "Inspirations Outro",
                    Length = 0.58,
                    Writer = "Maraj, Adams, Bannister, Dillon, Moore",
                    Singer = "Nicki Minaj",
                    AlbumId = 6
                },
                new Song
                {
                    SongId = 84,
                    Name = "Future Nostalgia",
                    Length = 3.04,
                    Writer = "Dua Lipa, Jeff Bhasker, Clarence Coffee Jr",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 85,
                    Name = "Don't Start Now",
                    Length = 3.03,
                    Writer = "Dua Lipa, Caroline Ailin, Emily Warren, Ian Kirkpatrick",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 86,
                    Name = "Cool",
                    Length = 3.29,
                    Writer = "Dua Lipa, Camille Purcell, Tove Lo, Shakka Philip, Benjamin Kohn, Thomas Barnes, Peter Kelleher",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 87,
                    Name = "Physical",
                    Length = 3.13,
                    Writer = "Dua Lipa, Jason Evigan, Clarence Coffee, JrSarah Hudson",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 88,
                    Name = "Levitating",
                    Length = 3.23,
                    Writer = "Dua Lipa, Clarence Coffee, JrSarah Hudson,Stephen Kozmeniuk",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 89,
                    Name = "Pretty Please",
                    Length = 3.14,
                    Writer = "Dua Lipa, Julia Michaels, Caroline Ailin, Ian Kirkpatrick",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 90,
                    Name = "Hallucinate",
                    Length = 3.28,
                    Writer = "Dua Lipa, Samuel Lewis, Sophie Cooke",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 91,
                    Name = "Love Again",
                    Length = 3.18,
                    Writer = "Dua Lipa, Clarence Coffee, JrStephen Kozmeniuk, Chelcee Grimes, Bing Crosby, Max Wartell, Irving Wallman",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 92,
                    Name = "Break My Heart",
                    Length = 3.41,
                    Writer = "Dua Lipa, Andrew Wotman, Ali Tamposi, Stefan Johnson, Jordan Johnson, Andrew Farriss, Michael Hutchence",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 93,
                    Name = "Good in Bed",
                    Length = 3.38,
                    Writer = "Dua Lipa, Michael Schulz, Melanie Fontana, Taylor Upsahl, David Biral, Denzel Baptiste",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 94,
                    Name = "Boys Will Be Boys",
                    Length = 2.46,
                    Writer = "Dua LipaKennediJustin TranterJason Evigan",
                    Singer = "Dua Lipa",
                    AlbumId = 7
                },
                new Song
                {
                    SongId = 95,
                    Name = "Magik Journey",
                    Length = 9.58,
                    Writer = "Tiësto, Geert Huinink",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 96,
                    Name = "Close to You",
                    Length = 5.01,
                    Writer = "Tiësto, Sarah Bettens",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 97,
                    Name = "Dallas 4 PM",
                    Length = 6.43,
                    Writer = "Tiësto",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 98,
                    Name = "In My Memory",
                    Length = 6.07,
                    Writer = "Tiësto, Nicola Hitchcock",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 99,
                    Name = "Obsession",
                    Length = 9.07,
                    Writer = "Tiësto, Tom Holkenborg",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 100,
                    Name = "Battleship Grey",
                    Length = 5.13,
                    Writer = "Tiësto, Kirsty Hawkshaw",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 101,
                    Name = "Flight 643",
                    Length = 9.01,
                    Writer = "Tiësto",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 102,
                    Name = "Lethal Industry",
                    Length = 6.46,
                    Writer = "Tiësto",
                    Singer = "Tiesto",
                    AlbumId = 8
                },
                new Song
                {
                    SongId = 103,
                    Name = "Suburban Train",
                    Length = 8.26,
                    Writer = "Tiësto, Ronald van Gelderen",
                    Singer = "Tiesto",
                    AlbumId = 8
                }
                );
        }
    }
}
