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
        //CRUD
        void CreateArtist(Artist artist);

        void RemoveArtist(int artistId);

        void UpdateArtist(Artist artist);

        Artist GetArtist(int artistId);

        IEnumerable<Artist> GetArtists();


        //NON-CRUD
        string GetAlbumNameByArtistId(int artistId);

        IEnumerable<Album> GetAlbumsOfArtist(int artistId);

        IEnumerable<Artist> GetArtistsOrderedByName();

        IEnumerable<Artist> GetArtistsOrderedByBirthDate();

        IEnumerable<Artist> GetArtistsOrderedByNumOfAlbums();
    }
}
