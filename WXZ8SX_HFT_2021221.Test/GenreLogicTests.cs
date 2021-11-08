using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Logic;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Test
{
    [TestFixture]
    public class GenreLogicTests
    {
        private GenreLogic GenreLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IGenreRepository> genreRepoMock = new Mock<IGenreRepository>();
            Mock<IAlbumRepository> albumRepoMock = new Mock<IAlbumRepository>();
            genreRepoMock.Setup(x => x.GetOne(It.IsAny<int>()))
                .Returns(new Genre()
                {
                    GenreId = 1,
                    GenreName = "Rap"
                });
            genreRepoMock.Setup(x => x.GetAll()).Returns(this.FakeGenreObjects);
            albumRepoMock.Setup(x => x.GetAll()).Returns(this.FakeAlbumObjects);

            this.GenreLogic = new GenreLogic(genreRepoMock.Object, albumRepoMock.Object);
        }
        [Test]
        public void GetGenres_Positive_Test()
        {
            Assert.That(this.GenreLogic.GetGenres().Count, Is.EqualTo(5));
        }
        [Test]
        public void GetAllAlbumsWithGenre_Positive_Test()
        {
            Assert.That(this.GenreLogic.GetAllAlbumsWithGenre(1).Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveGenre_Positive_Test()
        {
            Assert.That(() => this.GenreLogic.RemoveGenre(1), Throws.Nothing);
        }
        [Test]
        public void CreateGenre_Negative_Test()
        {
            Assert.Throws(typeof(Exception), () => this.GenreLogic.CreateGenre(1, "Test5"));
        }

        private IQueryable<Album> FakeAlbumObjects()
        {
            Album a0 = new Album() { AlbumId = 1, AlbumName = "Test0", ReleasedDate = DateTime.Parse("03/12/1999"), NumberOfSongs = 13, GenreId = 1, ArtistId = 6, Rating = 4.8, Length = 36.66 };
            Album a1 = new Album() { AlbumId = 2, AlbumName = "Test1", ReleasedDate = DateTime.Parse("02/21/2005"), NumberOfSongs = 9, GenreId = 3, ArtistId = 3, Rating = 3.7, Length = 27.30 };
            Album a2 = new Album() { AlbumId = 3, AlbumName = "Test2", ReleasedDate = DateTime.Parse("03/19/1989"), NumberOfSongs = 7, GenreId = 5, ArtistId = 5, Rating = 4.8, Length = 19.00 };
            Album a3 = new Album() { AlbumId = 4, AlbumName = "Test3", ReleasedDate = DateTime.Parse("08/13/2020"), NumberOfSongs = 5, GenreId = 1, ArtistId = 7, Rating = 3.9, Length = 15.22 };
            Album a4 = new Album() { AlbumId = 5, AlbumName = "Test4", ReleasedDate = DateTime.Parse("04/29/2006"), NumberOfSongs = 12, GenreId = 4, ArtistId = 1, Rating = 2.0, Length = 25.20 };

            List<Album> albums = new List<Album> { a0, a1, a2, a3, a4 };

            return albums.AsQueryable();
        }
        private IQueryable<Genre> FakeGenreObjects()
        {
            Genre g0 = new Genre() { GenreId = 1, GenreName = "Pop" };
            Genre g1 = new Genre() { GenreId = 2, GenreName = "Jazz" };
            Genre g2 = new Genre() { GenreId = 3, GenreName = "RNB" };
            Genre g3 = new Genre() { GenreId = 4, GenreName = "Techno" };
            Genre g4 = new Genre() { GenreId = 5, GenreName = "Blues" };


            List<Genre> genres = new List<Genre> { g0, g1, g2, g3, g4 };

            return genres.AsQueryable();
        }
    }
}
