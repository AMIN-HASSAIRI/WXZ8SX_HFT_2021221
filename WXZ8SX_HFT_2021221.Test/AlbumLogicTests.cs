using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Repository;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Logic;

namespace WXZ8SX_HFT_2021221.Test
{
    [TestFixture]
    public class AlbumLogicTests
    {
        [Test]
        public void GetAlbumsByYear_Positive_Test()
        {
            Mock<IAlbumRepository> albumRepoMock = new Mock<IAlbumRepository>();

            albumRepoMock.Setup(mock => mock.GetOne(1))
                .Returns(new Album
                {
                    AlbumId = 1,
                    AlbumName = "Test1",
                    ReleasedDate = DateTime.Parse("05/22/2000"),
                    NumberOfSongs = 11,
                    Rating = 4.5,

                });
            IAlbumLogic logic = new AlbumLogic(albumRepoMock.Object);

            Assert.That(() => logic.GetAlbumsByYear("2000"), Throws.Nothing);
        }
    }
}
