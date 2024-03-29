﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Repository;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Logic;
using Microsoft.EntityFrameworkCore;
using WXZ8SX_HFT_2021221.Data;

namespace WXZ8SX_HFT_2021221.Test
{
    [TestFixture]
    public class AlbumLogicTests
    {
        private AlbumLogic AlbumLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IAlbumRepository> albumRepoMock = new Mock<IAlbumRepository>();
            Mock<ISongRepository> songRepoMock = new Mock<ISongRepository>();

            //Arrange
            albumRepoMock.Setup(mock => mock.GetOne(It.IsAny<int>()))
                  .Returns(new Album
                  {
                      AlbumId = 1,
                      AlbumName = "Test1",
                      ReleasedDate = DateTime.Parse("05/22/2000"),
                      NumberOfSongs = 11,
                      Rating = 4.5,
                      Length = 35,
                      ArtistId = 2,
                      GenreId = 3
                  });
            albumRepoMock.Setup(x => x.GetAll()).Returns(this.FakeAlbumObjects);
            songRepoMock.Setup(x => x.GetAll()).Returns(this.FakeSongObjects);
            this.AlbumLogic = new AlbumLogic(albumRepoMock.Object, songRepoMock.Object);
        }
        [Test]
        public void GetOne_AlbumId_Positive_Test()
        {
            var album = this.AlbumLogic.GetAlbum(1);
            Assert.That(album.AlbumName, Is.EqualTo("Test1"));
        }
        [Test]
        public void GetAlbumsByYear_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByYear("1999").Count, Is.EqualTo(1));
        }
        [Test]
        public void GetAlbumsByYear_Empty_Test()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByYear("2020"), Is.Not.Empty);
        }
        [Test]
        public void GetAlbumsByArtistId_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByArtist(5), Is.Not.Null);
        }
        [Test]
        public void GetTheOldestAlbum_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetTheOldestAlbum().ReleasedDate.ToString("MM/dd/yyyy"), Is.EqualTo("03/19/1989"));
        }
        [Test]
        public void GetTheNewestAlbum_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetTheNewestAlbum().ReleasedDate.ToString("MM/dd/yyyy"), Is.EqualTo("08/13/2020"));
        }
        [Test]
        public void GetBestAlbums_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetBestAlbums().Count, Is.GreaterThan(1));
        }
        [Test]
        public void GetTheLongestAlbum_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetTheLongestAlbum().Length, Is.EqualTo(36.66));
        }
        [Test]
        public void GetTheShortestAlbum_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetTheShortestAlbum().Length, Is.EqualTo(15.22));
        }
        [Test]
        public void GetAlbumsByYear_Negative_Test()
        {
            Assert.Throws(typeof(Exception) , () => this.AlbumLogic.GetAlbumsByYear("2024"));
        }
        [Test]
        public void CreateAlbum_Negative_Test()
        {
            //Arrange
            Album album = new Album { AlbumId = 1, AlbumName = "TestN", ReleasedDate = DateTime.Parse("06/22/2021"), NumberOfSongs = 11, Rating = 4.50, Length = 26, ArtistId = 3, GenreId = 2 };

            //Assert
            Assert.Throws(typeof(Exception),()=>this.AlbumLogic.CreateAlbum(album));
        }
        private IQueryable<Album> FakeAlbumObjects()
        {
            Album a0 = new Album() { AlbumId = 1, AlbumName = "Test0", ReleasedDate = DateTime.Parse("03/12/1999"),NumberOfSongs = 13,GenreId = 2, ArtistId=6, Rating = 4.8, Length = 36.66};
            Album a1 = new Album() { AlbumId = 2, AlbumName = "Test1", ReleasedDate = DateTime.Parse("02/21/2005"),NumberOfSongs = 9,GenreId = 3, ArtistId=3, Rating = 3.7 , Length = 27.30};
            Album a2 = new Album() { AlbumId = 3, AlbumName = "Test2", ReleasedDate = DateTime.Parse("03/19/1989"),NumberOfSongs = 7,GenreId = 2, ArtistId=5 , Rating = 4.8 , Length = 19.00};
            Album a3 = new Album() { AlbumId = 4, AlbumName = "Test3", ReleasedDate = DateTime.Parse("08/13/2020"),NumberOfSongs = 5,GenreId = 6, ArtistId=7 , Rating = 3.9 , Length = 15.22};
            Album a4 = new Album() { AlbumId = 5, AlbumName = "Test4", ReleasedDate = DateTime.Parse("04/29/2006"),NumberOfSongs = 12,GenreId = 4, ArtistId=1 , Rating = 2.0, Length = 25.20};

            List<Album> albums = new List<Album> { a0, a1, a2, a3, a4 };
            return albums.AsQueryable();
        }
        private IQueryable<Song> FakeSongObjects()
        {
            Song s0 = new Song() { SongId = 1, Name = "SongTest0" , Length = 0.22, Writer = "WriterTest0", Singer = "Singer0", AlbumId = 1};
            Song s1 = new Song() { SongId = 2, Name = "SongTest1" , Length = 0.59, Writer = "WriterTest1", Singer = "Singer1", AlbumId = 5};
            Song s2 = new Song() { SongId = 3, Name = "SongTest2" , Length = 1.92, Writer = "WriterTest2", Singer = "Singer2", AlbumId = 3};
            Song s3 = new Song() { SongId = 4, Name = "SongTest3" , Length = 2.53, Writer = "WriterTest3", Singer = "Singer3", AlbumId = 2};
            Song s4 = new Song() { SongId = 5, Name = "SongTest4" , Length = 1.55, Writer = "WriterTest4", Singer = "Singer4", AlbumId = 1};

            List<Song> songs = new List<Song> { s0, s1, s2, s3, s4};
            return songs.AsQueryable();
        }
    }
}
