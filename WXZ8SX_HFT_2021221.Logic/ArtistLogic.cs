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

        public string GetAlbumNameByArtistId(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception($"There is no artist ID: {artistId}");
            }
            List<Album> allAlbums = _albumRepository.GetAll().ToList();
            Album album = allAlbums.Where(album => album.AlbumId == artist.ArtistId).SingleOrDefault();
            return album.AlbumName;
        }

        public IEnumerable<Album> GetAlbumsOfArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception($"This artist ID: {artistId} does not exists!");
            }
            List<Album> artistAlbums = _albumRepository.GetAll().Where(album => album.ArtistId == artist.ArtistId).ToList();
            return artistAlbums;
        }

        public Artist GetArtist(int artistId)
        {
            var artistsCount = _artistRepository.GetAll().Count();
            var artist = _artistRepository.GetOne(artistId);
            if (artistId > artistsCount)
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
            return _artistRepository.GetAll().ToList();
        }

        public IEnumerable<Artist> GetArtistsOrderedByBirthDate()
        {
            List<Artist> allArtists = _artistRepository.GetAll().ToList();

            List<Artist> orderedArtists = new List<Artist>();

            var artists = allArtists.OrderBy(artist => artist.DateOfBirth);

            foreach (Artist artist in artists)
            {
                orderedArtists.Add(artist);
            }
            return orderedArtists;
        }

        public IEnumerable<Artist> GetArtistsOrderedByName()
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

        public IEnumerable<Artist> GetArtistsOrderedByNumOfAlbums()
        {
            List<Artist> allArtists = _artistRepository.GetAll().ToList();

            List<Artist> orderedArtists = new List<Artist>();

            var artists = allArtists.OrderBy(artist => artist.NumberOfAlbums);

            foreach (Artist artist in artists)
            {
                orderedArtists.Add(artist);
            }
            return orderedArtists;
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

    }
}
