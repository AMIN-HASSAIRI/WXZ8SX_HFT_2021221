using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Logic
{
    public interface IAlbumLogic
    {
        IEnumerable<Album> GetAlbums();

        Album GetAlbum(int id);

        void CreateAlbum(Album album);

        void RemoveAlbum(int albumId);

        Album GetTheOldestAlbum();

        Album GetTheNewestAlbum();

        IEnumerable<Album> GetBestAlbums();

        IEnumerable<Album> GetAlbumsByYear(string YYYY);

        Album GetTheLongestAlbum();

        Album GetTheShortestAlbum();

        IEnumerable<Album> GetAlbumsByArtist(int artistId);

        void UpdateAlbum(Album album);
    }
}
