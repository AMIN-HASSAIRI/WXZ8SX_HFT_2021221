using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Test
{
    [TestFixture]
    public class AlbumRepositoryTests
    {
        private MusicDbContext Context { get; set; }

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder<MusicDbContext> contextBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True";

            contextBuilder.UseSqlServer(connectionString);

            Context = new MusicDbContext(contextBuilder.Options);

            Context.Albums.AddRange(
                new Album { AlbumName = "Test1", ReleasedDate = DateTime.Parse("09/15/2020"), NumberOfSongs = 11, Rating = 4.8, Length = 66.30 },
                new Album { AlbumName = "Test2", ReleasedDate = DateTime.Parse("12/08/2018"), NumberOfSongs = 13, Rating = 4.9, Length = 55.30 },
                new Album { AlbumName = "Test3", ReleasedDate = DateTime.Parse("05/29/2021"), NumberOfSongs = 9, Rating = 4.2, Length = 44.30 }
                );
            Context.SaveChanges();
        }
        [Test]
        public void GetOne_InvalidId_Test()
        {
            //ARRANGE


            IAlbumRepository repository = new AlbumRepository(Context);

            //ACT

            Album album = repository.GetOne(9999);

            //ASSERT

            Assert.Null(album);
        }
        [Test]
        public void GetAll_Test()
        {
            //ARRANGE

            IAlbumRepository repository = new AlbumRepository(Context);

            //ACT
            List<Album> albums = repository.GetAll().ToList();

            //ASSERT
            Assert.NotNull(albums);
            Assert.True(albums.Count > 0);
        }
        [TearDown]
        public void TearDown()
        {
            Context.Albums.RemoveRange(Context.Albums.ToArray());
            Context.Genres.RemoveRange(Context.Genres.ToArray());
            Context.Artists.RemoveRange(Context.Artists.ToArray());
            Context.Songs.RemoveRange(Context.Songs.ToArray());

            Context.SaveChanges();
        }
    }
}
