using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Logic
{
    public interface IArtistLogic
    {
        IEnumerable<Artist> GetArtists();

        Artist GetArtist(int artistId);

        void CreateArtist(int artistId, string artistName, DateTime dateOfBirth, int numAlbums);

        void RemoveArtist(int artistId);

        IEnumerable<Artist> GetArtistsOrderedByName();

        IEnumerable<Artist> GetArtistsOrderedByBirthDate();

        IEnumerable<Artist> GetArtistsOrderedByNumOfAlbums();

        string GetAlbumNameByArtistId(int artistId);

        IEnumerable<Album> GetAlbumsOfArtist(int artistId);

        void UpdateArtist(Artist artist);

    }
}
