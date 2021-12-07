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
        private readonly IAlbumRepository _albumRepository;

        public ArtistLogic(IArtistRepository artistRepository, IAlbumRepository albumRepository)
        {
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
        }

        //CRUD
        #region CRUD
        public void CreateArtist(Artist artist)
        {
            if (_artistRepository.GetOne(artist.ArtistId) == null)
            {
                artist = new Artist
                {
                    ArtistId = artist.ArtistId,
                    ArtistName = artist.ArtistName,
                    DateOfBirth = artist.DateOfBirth,
                    NumberOfAlbums = artist.NumberOfAlbums
                };
                _artistRepository.Add(artist);
            }
            else if (artist.ArtistName == "")
            {
                throw new ArgumentNullException("The artist name must not be empty!");
            }
            else if (_artistRepository.GetOne(artist.ArtistId) != null)
            {
                throw new Exception($"This artist ID: {artist.ArtistId} is already used!");
            }
        }
        public void RemoveArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);

            if (_artistRepository.GetOne(artistId) == null)
            {
                throw new Exception("This artist ID does not exists!");
            }
            else
            {
                _artistRepository.Delete(artist);
            }
        }
        public void UpdateArtist(Artist artist)
        {
            var artistToUpdate = _artistRepository.GetOne(artist.ArtistId);
            artistToUpdate.ArtistName = artist.ArtistName;
            artistToUpdate.DateOfBirth = artist.DateOfBirth;
            artistToUpdate.NumberOfAlbums = artist.NumberOfAlbums;

            _artistRepository.Update(artistToUpdate);
        }
        public Artist GetArtist(int artistId)
        {
            var artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception("This artist ID does not exists!");
            }
            else
            {
                return artist;
            }
        }
        public IEnumerable<Artist> GetArtists()
        {
            return _artistRepository.GetAll();
        }
        #endregion

        //NON-CRUD
        #region NON-CRUD
        public string GetAlbumNameByArtistId(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception($"There is no artist ID: {artistId}");
            }
            string albumName = _albumRepository.GetAll().FirstOrDefault(album => album.AlbumId == artist.ArtistId).AlbumName;
            return albumName;
        }

        public IEnumerable<Album> GetAlbumsOfArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception($"This artist ID: {artistId} does not exists!");
            }
            var artistAlbums = _albumRepository.GetAll().Where(album => album.ArtistId == artist.ArtistId);
            return artistAlbums;
        }

        public IEnumerable<Artist> GetArtistsOrderedByBirthDate()
        {
            var artists = _artistRepository.GetAll().OrderBy(artist => artist.DateOfBirth);

            return artists;
        }

        public IEnumerable<Artist> GetArtistsOrderedByName()
        {
            var artists = _artistRepository.GetAll().OrderBy(artist => artist.ArtistName);

            return artists;
        }

        public IEnumerable<Artist> GetArtistsOrderedByNumOfAlbums()
        {
            var artists = _artistRepository.GetAll().OrderBy(artist => artist.NumberOfAlbums);

            return artists;
        }
        #endregion
    }
}
