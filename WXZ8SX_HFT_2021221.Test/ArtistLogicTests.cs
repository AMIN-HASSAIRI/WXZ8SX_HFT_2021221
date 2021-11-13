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
    public class ArtistLogicTests
    {
        private ArtistLogic ArtistLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IArtistRepository> artistRepoMock = new Mock<IArtistRepository>();
            Mock<IAlbumRepository> albumRepoMock = new Mock<IAlbumRepository>();
            artistRepoMock.Setup(x => x.GetOne(It.IsAny<int>()))
                .Returns(new Artist()
                {
                    ArtistId = 1, 
                    ArtistName = "Test111",
                    NumberOfAlbums = 6,
                    DateOfBirth = DateTime.Parse("03/22/2000"),
                });
            artistRepoMock.Setup(x => x.GetAll()).Returns(this.FakeArtistObjects);
            albumRepoMock.Setup(x => x.GetAll()).Returns(this.FakeAlbumObjects);

            this.ArtistLogic = new ArtistLogic(artistRepoMock.Object, albumRepoMock.Object);
        }
        [Test]
        public void GetAlbumNameByArtistId_Positive_Test()
        {
            Assert.That(this.ArtistLogic.GetAlbumNameByArtistId(1), Is.EqualTo("Test0"));
        }
        [Test]
        public void GetAlbumsOfArtist_Positive_Test()
        {
            Assert.That(this.ArtistLogic.GetAlbumsOfArtist(7), Is.Not.Null);
        }
        [Test]
        public void GetArtists_Positive_Test()
        {
            Assert.That(this.ArtistLogic.GetArtists(), Is.Not.Null);
        }
        [Test]
        public void GetArtistsOrderedByBirthDate_Positive_Test()
        {
            var order = this.ArtistLogic.GetArtistsOrderedByBirthDate();
            Assert.That(order.ElementAt(0).DateOfBirth, Is.LessThan(order.ElementAt(1).DateOfBirth));
        }
        [Test]
        public void GetArtist_Negative_Test()
        {
            Assert.Throws(typeof(Exception), () => this.ArtistLogic.GetArtist(6));
        }
        [Test]
        public void RemoveArtist_Negative_Test()
        {
            Assert.That(() => this.ArtistLogic.RemoveArtist(6), Throws.Nothing);
        }
        [Test]
        public void CreateArtist_Negative_Test()
        {
            //Arrange
            Artist newArtist = new Artist 
            {
                ArtistId = 6,
                ArtistName = "",
                DateOfBirth = DateTime.Parse("02/27/2001"),
                NumberOfAlbums = 11,
            };
            Artist newArtist2 = new Artist
            {
                ArtistId = 4,
                ArtistName = "Nicki",
                DateOfBirth = DateTime.Parse("12/17/2005"),
                NumberOfAlbums = 7,
            };
            //Act
            //Assert
            Assert.Throws(typeof(ArgumentNullException), () => this.ArtistLogic.CreateArtist(newArtist));
            Assert.Throws(typeof(Exception), () => this.ArtistLogic.CreateArtist(newArtist2));
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
        private IQueryable<Artist> FakeArtistObjects()
        {
            Artist a0 = new Artist() { ArtistId = 1, ArtistName = "Test01", DateOfBirth = DateTime.Parse("03/16/2011"), NumberOfAlbums = 2 };
            Artist a1 = new Artist() { ArtistId = 2, ArtistName = "Test02", DateOfBirth = DateTime.Parse("07/22/1999"), NumberOfAlbums = 6 };
            Artist a2 = new Artist() { ArtistId = 3, ArtistName = "Test03", DateOfBirth = DateTime.Parse("11/12/1992"), NumberOfAlbums = 3 };
            Artist a3 = new Artist() { ArtistId = 4, ArtistName = "Test04", DateOfBirth = DateTime.Parse("08/23/1998"), NumberOfAlbums = 4 };
            Artist a4 = new Artist() { ArtistId = 5, ArtistName = "Test05", DateOfBirth = DateTime.Parse("09/16/1993"), NumberOfAlbums = 7 };


            List<Artist> artists = new List<Artist> { a0, a1, a2, a3, a4 };

            return artists.AsQueryable();
        }
    }
}
