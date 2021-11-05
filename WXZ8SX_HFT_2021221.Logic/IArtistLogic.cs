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
        List<Artist> GetArtists();

        Artist GetArtist(int artistId);

        void CreateArtist(int artistId, string artistName, DateTime dateOfBirth, int numAlbums);

        void RemoveArtist(int artistId);

        List<Artist> GetArtistsOrderedByName();

        List<Artist> GetArtistsOrderedByBirthDate();

        List<Artist> GetArtistsOrderedByNumOfAlbums();

        string GetAlbumNameByArtistId(int artistId);


    }
}
