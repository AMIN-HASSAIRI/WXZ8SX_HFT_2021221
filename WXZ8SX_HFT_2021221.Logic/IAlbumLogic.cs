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

        //CRUD
        void CreateAlbum(Album album);

        void RemoveAlbum(int albumId);

        void UpdateAlbum(Album album);

        Album GetAlbum(int id);

        IEnumerable<Album> GetAlbums();

        //NON-CRUD
        IEnumerable<KeyValuePair<string, double>> GetLongestSongInEachAlbum();

        string GetGenreNameOfAlbumBySongId(int songId);

        string GetArtistNameOfAlbumBySongId(int songId);

        IEnumerable<Album> GetAlbumsByArtist(int artistId);

        IEnumerable<Album> GetBestAlbums();

        IEnumerable<Album> GetAlbumsByYear(string YYYY);

        Album GetTheLongestAlbum();

        Album GetTheShortestAlbum();

        Album GetTheOldestAlbum();

        Album GetTheNewestAlbum();
    }
}
