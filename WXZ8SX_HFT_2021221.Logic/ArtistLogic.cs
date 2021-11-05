using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        private readonly IArtistRepository _artistRepository;

        public void CreateArtist(int artistId, string artistName, DateTime dateOfBirth, int numAlbums)
        {
            Artist newArtist = new Artist
            {
                ArtistId = artistId,
                ArtistName = artistName,
                DateOfBirth = dateOfBirth,
                NumberOfAlbums = numAlbums
            };
            _artistRepository.Add(newArtist);
        }

        public Artist GetArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception("This artist ID does not exists!");
            }
            else
            {
                return artist;
            }
        }

        public List<Artist> GetArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public List<Artist> GetArtistsOrderedByName()
        {
            List<Artist> allArtists = _artistRepository.GetAll().ToList();

            List<Artist> orderedArtists = new List<Artist>();

            var artists = allArtists.OrderBy(artist => artist.ArtistName);

            foreach (Artist artist in artists)
            {
                orderedArtists.Add(artist);
            }
            return orderedArtists;
        }

        public void RemoveArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);

            if (artist == null)
            {
                throw new Exception("This artist ID does not exists!");
            }
            _artistRepository.Delete(artist);
        }
    }
}
