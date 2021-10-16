using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WXZ8SX_HFT_2021221.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfSongs = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfAlbums = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Writer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Singer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "AlbumName", "ArtistId", "GenreId", "Length", "NumberOfSongs", "Rating", "ReleasedDate" },
                values: new object[,]
                {
                    { 1, "D'eux", 1, 1, 47.159999999999997, 12, 4.7000000000000002, new DateTime(1995, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "A New Day Has Come", 1, 1, 72.140000000000001, 17, 4.7000000000000002, new DateTime(2002, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Dangerous", 2, 11, 77.030000000000001, 14, 4.7999999999999998, new DateTime(1991, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Bad", 2, 11, 48.399999999999999, 11, 4.7999999999999998, new DateTime(1987, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Catch a Fire", 3, 12, 37.509999999999998, 11, 4.7999999999999998, new DateTime(1973, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Queen", 4, 8, 66.189999999999998, 19, 4.7000000000000002, new DateTime(2018, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Future Nostalgia", 5, 1, 37.170000000000002, 11, 4.7999999999999998, new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "In My Memory", 6, 6, 68.189999999999998, 9, 4.7000000000000002, new DateTime(2001, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName", "DateOfBirth", "NumberOfAlbums" },
                values: new object[,]
                {
                    { 6, "Tiesto", new DateTime(1969, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, "Dua Lipa", new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "Nicki Minaj", new DateTime(1982, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 2, "Michael Jackson", new DateTime(1958, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 1, "Celine Dion", new DateTime(1968, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 27 },
                    { 3, "Bob Marley", new DateTime(1945, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 8, "Rap" },
                    { 12, "Reggae" },
                    { 10, "Latin" },
                    { 9, "Folk" },
                    { 7, "Hip Hop" },
                    { 11, "R&B and soul" },
                    { 5, "Jazz" },
                    { 4, "Flamenco" },
                    { 3, "Rock" },
                    { 2, "Metal" },
                    { 6, "House" },
                    { 1, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[,]
                {
                    { 67, 6, 4.3899999999999997, "Barbie Dreams", "Nicki Minaj", "Maraj, Rashad Smith, Melvin Hough II, Rivelino Raoul Wouter, Christopher Wallace, James Brown, Fred Wesley" },
                    { 68, 6, 3.1200000000000001, "Rich Sex", "Nicki Minaj", "Maraj, Dwayne Carter, Reid, Jawara Headley, Aubry Delaine" },
                    { 69, 6, 3.1299999999999999, "Hard White", "Nicki Minaj", "Maraj, Matthew Samuels, Ramon Ibanga Jr., Brittany Hazzard" },
                    { 70, 6, 3.0899999999999999, "Bed", "Nicki Minaj", "Maraj, Benjamin Diehl, Gamal Lewis, Brett Bailey, Mescon David Asher, Dwayne Chin-Quee" },
                    { 72, 6, 2.3399999999999999, "Run & Hide", "Nicki Minaj", "Maraj, Hazzard, Rupert Thomas Jr., Masamune Kudo" },
                    { 66, 6, 4.5499999999999998, "Majesty", "Nicki Minaj", "Maraj, Timothy McKenzie, Marshall Mathers, Luis Resto" },
                    { 73, 6, 6.0999999999999996, "Chun Swae", "Nicki Minaj", "Maraj, Khalif Brown, Leland Wayne" },
                    { 74, 6, 3.1099999999999999, "Chun-Li", "Nicki Minaj", "Maraj, Reid" },
                    { 75, 6, 3.4100000000000001, "LLC", "Nicki Minaj", "Maraj, Rasool Diaz, Wesley Dees, Jason Fox" },
                    { 71, 6, 3.1800000000000002, "Thought I Knew You", "Nicki Minaj", "Maraj, Abel Tesfaye, Hazzard, Reid" },
                    { 65, 6, 4.54, "Ganja Burn", "Nicki Minaj", "Onika Maraj, Jeremy Reid, Jairus Mozee" },
                    { 62, 5, 2.52, "Slave Driver", "Bob Marley", "Bob Marley" },
                    { 63, 5, 3.3999999999999999, "Kinky Reggae", "Bob Marley", "Bob Marley" },
                    { 61, 5, 3.2599999999999998, "All Day All Night", "Bob Marley", "Bob Marley" },
                    { 60, 5, 5.0499999999999998, "Midnight Ravers", "Bob Marley", "Bob Marley" },
                    { 59, 5, 4.0, "Baby We've Got a Date (Rock It Baby)", "Bob Marley", "Bob Marley" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[,]
                {
                    { 58, 5, 2.5699999999999998, "400 Years", "Bob Marley", "Tosh" },
                    { 57, 5, 3.52, "Stop That Train", "Bob Marley", "Tosh" },
                    { 56, 5, 4.4000000000000004, "High Tide or Low Tide", "Bob Marley", "Bob Marley" },
                    { 55, 5, 3.3700000000000001, "Stir It Up", "Bob Marley", "Bob Marley" },
                    { 54, 5, 4.1100000000000003, "Concrete Jungle", "Bob Marley", "Bob Marley" },
                    { 76, 6, 3.1899999999999999, "Good Form", "Nicki Minaj", "Maraj, Michael Williams II, Asheton Hogan" },
                    { 64, 5, 5.1299999999999999, "No More Trouble", "Bob Marley", "Bob Marley" },
                    { 77, 6, 3.27, "Nip Tuck", "Nicki Minaj", "Maraj, Hazzard, Jeremy Coleman, Daniel Johnson, June Nawakii" },
                    { 90, 7, 3.2799999999999998, "Hallucinate", "Dua Lipa", "Dua Lipa, Samuel Lewis, Sophie Cooke" },
                    { 79, 6, 4.0599999999999996, "Come See About Me", "Nicki Minaj", "Maraj, Hazzard, Christopher Braide, Henry Walter" },
                    { 101, 8, 9.0099999999999998, "Flight 643", "Tiesto", "Tiësto" },
                    { 100, 8, 5.1299999999999999, "Battleship Grey", "Tiesto", "Tiësto, Kirsty Hawkshaw" },
                    { 99, 8, 9.0700000000000003, "Obsession", "Tiesto", "Tiësto, Tom Holkenborg" },
                    { 98, 8, 6.0700000000000003, "In My Memory", "Tiesto", "Tiësto, Nicola Hitchcock" },
                    { 97, 8, 6.4299999999999997, "Dallas 4 PM", "Tiesto", "Tiësto" },
                    { 96, 8, 5.0099999999999998, "Close to You", "Tiesto", "Tiësto, Sarah Bettens" },
                    { 95, 8, 9.5800000000000001, "Magik Journey", "Tiesto", "Tiësto, Geert Huinink" },
                    { 94, 7, 2.46, "Boys Will Be Boys", "Dua Lipa", "Dua LipaKennediJustin TranterJason Evigan" },
                    { 93, 7, 3.3799999999999999, "Good in Bed", "Dua Lipa", "Dua Lipa, Michael Schulz, Melanie Fontana, Taylor Upsahl, David Biral, Denzel Baptiste" },
                    { 92, 7, 3.4100000000000001, "Break My Heart", "Dua Lipa", "Dua Lipa, Andrew Wotman, Ali Tamposi, Stefan Johnson, Jordan Johnson, Andrew Farriss, Michael Hutchence" },
                    { 78, 6, 0.55000000000000004, "2 Lit 2 Late", "Nicki Minaj", "Maraj, Hazzard, Gramma, Adam King Feeney" },
                    { 91, 7, 3.1800000000000002, "Love Again", "Dua Lipa", "Dua Lipa, Clarence Coffee, JrStephen Kozmeniuk, Chelcee Grimes, Bing Crosby, Max Wartell, Irving Wallman" },
                    { 89, 7, 3.1400000000000001, "Pretty Please", "Dua Lipa", "Dua Lipa, Julia Michaels, Caroline Ailin, Ian Kirkpatrick" },
                    { 88, 7, 3.23, "Levitating", "Dua Lipa", "Dua Lipa, Clarence Coffee, JrSarah Hudson,Stephen Kozmeniuk" },
                    { 87, 7, 3.1299999999999999, "Physical", "Dua Lipa", "Dua Lipa, Jason Evigan, Clarence Coffee, JrSarah Hudson" },
                    { 86, 7, 3.29, "Cool", "Dua Lipa", "Dua Lipa, Camille Purcell, Tove Lo, Shakka Philip, Benjamin Kohn, Thomas Barnes, Peter Kelleher" },
                    { 85, 7, 3.0299999999999998, "Don't Start Now", "Dua Lipa", "Dua Lipa, Caroline Ailin, Emily Warren, Ian Kirkpatrick" },
                    { 84, 7, 3.04, "Future Nostalgia", "Dua Lipa", "Dua Lipa, Jeff Bhasker, Clarence Coffee Jr" },
                    { 83, 6, 0.57999999999999996, "Inspirations Outro", "Nicki Minaj", "Maraj, Adams, Bannister, Dillon, Moore" },
                    { 82, 6, 3.4399999999999999, "Coco Chanel", "Nicki Minaj", "Maraj, Joshua Adams, Inga Marchand, Ashley Bannister, Dillon Hart Francis, Sonny Moore" },
                    { 81, 6, 3.1000000000000001, "Miami", "Nicki Minaj", "Maraj, Shane Lindstrom, Diaz, Douglas Patterson" },
                    { 80, 6, 3.4399999999999999, "Sir", "Nicki Minaj", "Maraj, Nayvadius Wilburn, Wayne, Xavier Dotson" },
                    { 53, 4, 4.4100000000000001, "Leave Me Alone", "Michael Jackson", "Jackson" },
                    { 52, 4, 4.2000000000000002, "Smooth Criminal", "Michael Jackson", "Jackson" },
                    { 39, 3, 7.4100000000000001, "Will You Be There", "Michael Jackson", "Jackson" },
                    { 50, 4, 4.2699999999999996, "I Just Can't Stop Loving You", "Michael Jackson", "Jackson" },
                    { 22, 2, 4.1699999999999999, "At Last", "Celine Dion", "Mack Gordon, Harry Warren" },
                    { 21, 2, 4.4699999999999998, "I Surrender", "Celine Dion", "Louis Biancaniello, Sam Watters" },
                    { 20, 2, 5.3399999999999999, "Prayer", "Celine Dion", "Corey Hart" },
                    { 19, 2, 5.1900000000000004, "Goodbye's (The Saddest Word)", "Celine Dion", "Robert John Mutt Lange" },
                    { 18, 2, 3.3700000000000001, "Ten Days", "Celine Dion", "Nova, Maxime Le Forestier, Gérald de Palmas" },
                    { 17, 2, 4.2300000000000004, "A New Day Has Come", "Celine Dion", "Aldo Nova, Stephan Moccio" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[,]
                {
                    { 16, 2, 3.25, "Rain, Tax (It's Inevitable)", "Celine Dion", "Terry Britten, Charlie Dore" },
                    { 15, 2, 4.0800000000000001, "Have You Ever Been in Love", "Celine Dion", "Anders Bagge, Peer Åström, Tom Nichols, Daryl Hall, Laila Bagge" },
                    { 14, 2, 4.1299999999999999, "Right in Front of You", "Celine Dion", "Steve Morales, Sheppard Solomon, Kara DioGuardi" },
                    { 13, 2, 3.2999999999999998, "I'm Alive", "Celine Dion", "Kristian Lundin, Andreas Carlsson" },
                    { 23, 2, 4.1600000000000001, "Super Love", "Celine Dion", "Roche, Shelly Peiken" },
                    { 12, 1, 2.5699999999999998, "Vole", "Celine Dion", "Goldman" },
                    { 10, 1, 4.2400000000000002, "J'attendais", "Celine Dion", "Goldman" },
                    { 9, 1, 3.2599999999999998, "J'irai ou tu iras", "Celine Dion", "Goldman" },
                    { 8, 1, 3.3300000000000001, "Les derniers seront les premiers", "Celine Dion", "Goldman" },
                    { 7, 1, 4.1500000000000004, "Destin", "Celine Dion", "Goldman" },
                    { 6, 1, 3.2400000000000002, "Cherche encore", "Celine Dion", "Erick Benzi" },
                    { 5, 1, 3.5, "La memoire d'Abraham", "Celine Dion", "Goldman" },
                    { 4, 1, 4.3300000000000001, "Je sais pas", "Celine Dion", "Goldman, JKapler" },
                    { 3, 1, 3.5699999999999998, "Regarde-moi", "Celine Dion", "Goldman" },
                    { 2, 1, 4.2300000000000004, "Le Ballet", "Celine Dion", "Goldman" },
                    { 1, 1, 4.1399999999999997, "Pour que tu m'aime encore", "Celine Dion", "Jean-Jacques Goldman" },
                    { 11, 1, 4.0999999999999996, "Priere paienne", "Celine Dion", "Goldman" },
                    { 24, 2, 4.0999999999999996, "Sorry for Love", "Celine Dion", "DioGuardi, Bagge, Åström, Arnthor Birgisson" },
                    { 25, 2, 3.52, "Aun Existe Amor", "Celine Dion", "Riccardo Cocciante, Ignacio Ballesteros-Diaz" },
                    { 26, 2, 3.2799999999999998, "The Greatest Reward", "Celine Dion", "Pascal Obispo, Carlsson, Jörgen Elofsson, Lionel Florence, Patrice Guirao" },
                    { 49, 4, 5.21, "Man in the Mirror", "Michael Jackson", "Siedah Garrett, Glen Ballard" },
                    { 48, 4, 3.5499999999999998, "Another Part of Me", "Michael Jackson", "Jackson" },
                    { 47, 4, 4.0899999999999999, "Just Good Friends", "Michael Jackson", "Terry Britten, Graham Lyle" },
                    { 46, 4, 3.5499999999999998, "Liberian Girl", "Michael Jackson", "Jackson" },
                    { 45, 4, 4.0300000000000002, "Speed Demon", "Michael Jackson", "Jackson" },
                    { 44, 4, 4.5899999999999999, "The Way You Make Me Feel", "Michael Jackson", "Jackson" },
                    { 43, 4, 4.0800000000000001, "Bad", "Michael Jackson", "Jackson" },
                    { 42, 3, 6.5700000000000003, "Dangerous", "Michael Jackson", "Jackson, Bottrell, Riley" },
                    { 41, 3, 3.2200000000000002, "Gone Too Soon", "Michael Jackson", "Larry Grossman, Buz Kohan" },
                    { 40, 3, 5.5700000000000003, "Keep the Faith", "Michael Jackson", "Jackson, Glen Ballard, Siedah Garrett" },
                    { 102, 8, 6.46, "Lethal Industry", "Tiesto", "Tiësto" },
                    { 38, 3, 5.2999999999999998, "Give In to Me", "Michael Jackson", "Jackson, Bottrell" },
                    { 37, 3, 6.3499999999999996, "Who Is It", "Michael Jackson", "Jackson" },
                    { 36, 3, 4.1600000000000001, "Black or White", "Michael Jackson", "Jackson, Bill Bottrell" },
                    { 35, 3, 6.25, "Heal the World", "Michael Jackson", "Jackson" },
                    { 34, 3, 4.5899999999999999, "Can't Let Her Get Away", "Michael Jackson", "Jackson, Riley" },
                    { 33, 3, 3.4199999999999999, "She Drives Me Wild", "Michael Jackson", "Jackson, Riley, Aqil Davidson" },
                    { 32, 3, 6.3200000000000003, "In the Closet", "Michael Jackson", "Jackson, Riley" },
                    { 31, 3, 5.2400000000000002, "Why You Wanna Trip on Me", "Michael Jackson", "RileyBernard Belle" },
                    { 30, 3, 5.3899999999999997, "Jam", "Michael Jackson", "Michael Jackson, René Moore, Bruce Swedien, Teddy Riley" },
                    { 29, 2, 2.5699999999999998, "Nature Boy", "Celine Dion", "eden ahbez" },
                    { 28, 2, 5.4199999999999999, "A New Day Has Come", "Celine Dion", "Nova, Moccio" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[] { 27, 2, 3.48, "When the Wrong One Loves You Right", "Celine Dion", "Martin Briley, Francis Galluccio, Marjorie Maye" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[] { 51, 4, 4.4199999999999999, "Dirty Diana", "Michael Jackson", "Jackson" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "Length", "Name", "Singer", "Writer" },
                values: new object[] { 103, 8, 8.2599999999999998, "Suburban Train", "Tiesto", "Tiësto, Ronald van Gelderen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
