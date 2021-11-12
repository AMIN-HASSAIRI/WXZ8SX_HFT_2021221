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

        public void CreateArtist(int artistId, string artistName, DateTime dateOfBirth, int numAlbums)
        {
            if (_artistRepository.GetOne(artistId) == null)
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
            else if (artistName == "")
            {
                throw new ArgumentNullException("The artist name must not be empty!");
            }
            else if (_artistRepository.GetOne(artistId) != null)
            {
                throw new Exception($"This artist ID: {artistId} is already used!");
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

        public List<Album> GetAlbumsOfArtist(int artistId)
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

        public List<Artist> GetArtists()
        {
            return _artistRepository.GetAll().ToList();
        }

        public List<Artist> GetArtistsOrderedByBirthDate()
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

        public List<Artist> GetArtistsOrderedByNumOfAlbums()
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
    }
}
