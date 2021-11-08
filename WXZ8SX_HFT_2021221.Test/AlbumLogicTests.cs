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
            this.AlbumLogic = new AlbumLogic(albumRepoMock.Object);
        }
        [Test]
        public void GetAlbumsByYear_Positive_Test()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByYear("1999").Count, Is.EqualTo(1));
        }
        [Test]
        public void GetAlbumsByYear_Empty_Test()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByYear("2020") , Is.Empty);
        }
        [Test]
        public void GetAlbumsByArtistId_Positive()
        {
            Assert.That(this.AlbumLogic.GetAlbumsByArtist(5), Is.Not.Null);
        }
        private IQueryable<Album> FakeAlbumObjects()
        {
            Album a0 = new Album() { AlbumId = 1, AlbumName = "Test0", ReleasedDate = DateTime.Parse("03/12/1999"),NumberOfSongs = 13,GenreId = 2, ArtistId=6};
            Album a1 = new Album() { AlbumId = 2, AlbumName = "Test1", ReleasedDate = DateTime.Parse("02/21/2005"),NumberOfSongs = 9,GenreId = 3, ArtistId=3};
            Album a2 = new Album() { AlbumId = 3, AlbumName = "Test2", ReleasedDate = DateTime.Parse("03/19/1989"),NumberOfSongs = 7,GenreId = 2, ArtistId=5};
            Album a3 = new Album() { AlbumId = 4, AlbumName = "Test3", ReleasedDate = DateTime.Parse("08/13/2011"),NumberOfSongs = 5,GenreId = 6, ArtistId=7};
            Album a4 = new Album() { AlbumId = 5, AlbumName = "Test4", ReleasedDate = DateTime.Parse("04/29/2006"),NumberOfSongs = 12,GenreId = 4, ArtistId=1 };

            List<Album> albums = new List<Album> { a0, a1, a2, a3, a4 };
            return albums.AsQueryable();
        }
    }
}
