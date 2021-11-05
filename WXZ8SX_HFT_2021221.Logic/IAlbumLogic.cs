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
        List<Album> GetAlbums();

        Album GetAlbum(int id);

        void CreateAlbum(int albumId, string albumName, DateTime releasedDate, int numberOfSongs, double rating,
                  double length, int artistId, int genreId);

    }
}
