using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumLogic(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public void CreateAlbum(int albumId, string albumName, DateTime releasedDate, int numberOfSongs, double rating, double length, int artistId, int genreId)
        {
            Album newAlbum = new Album
            {
                AlbumId = albumId,
                AlbumName = albumName,
                ReleasedDate = releasedDate,
                NumberOfSongs = numberOfSongs,
                Rating = rating,
                Length = length,
                ArtistId = artistId,
                GenreId = genreId
            };
            _albumRepository.Add(newAlbum);
        }

        public Album GetAlbum(int id)
        {
            Album album = _albumRepository.GetOne(id);
            if (album == null)
            {
                throw new Exception("Album does not exist!");
            }
            else
            {
                return album;
            }
        }

        public List<Album> GetAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            List<Album> albumsByArtist = new List<Album>();

            var albums = _albumRepository.GetAll().Where(album => album.ArtistId == artistId);

            if (albums == null)
            {
                throw new Exception($"This artist ID {artistId} has no albums!");
            }

            foreach (Album album in albums)
            {
                albumsByArtist.Add(album);
            }

            return albumsByArtist;
        }

        public List<Album> GetAlbumsByYear(string YYYY)
        {
            List<Album> allAlbums = _albumRepository.GetAll().ToList();

            List<Album> albumsByYear = new List<Album>();

            var albums = allAlbums.Where(album => album.ReleasedDate.Value.ToString().Split("/")[2] == YYYY);

            if (albums == null)
            {
                throw new Exception($"There is no album in this year {YYYY}");
            }
            foreach (Album album in albums)
            {
                albumsByYear.Add(album);
            }

            return albumsByYear;
        }

        public List<Album> GetBestAlbums()
        {
            List<Album> bestAlbums = new List<Album>();

            var albums = _albumRepository.GetAll().OrderByDescending(album => album.Rating).GroupBy(album => album.Rating).First();

            foreach (Album album in albums)
            {
                bestAlbums.Add(album);
            }

            return bestAlbums;
        }

        public Album GetTheLongestAlbum()
        {
            Album longestAlbum = _albumRepository.GetAll().OrderByDescending(album => album.Length).FirstOrDefault();

            return longestAlbum;
        }

        public Album GetTheNewestAlbum()
        {
            Album NewestAlbum = _albumRepository.GetAll().OrderByDescending(album => album.ReleasedDate).FirstOrDefault();

            return NewestAlbum;
        }

        public Album GetTheOldestAlbum()
        {
            Album OldestAlbum = _albumRepository.GetAll().OrderBy(album => album.ReleasedDate).FirstOrDefault();

            return OldestAlbum;
        }

        public Album GetTheShortestAlbum()
        {
            Album shortestAlbum = _albumRepository.GetAll().OrderBy(album => album.Length).FirstOrDefault();

            return shortestAlbum;
        }

        public void RemoveAlbum(int albumId)
        {
            Album album = _albumRepository.GetOne(albumId);

            if (album == null)
            {
                throw new Exception("Album does not exist!");
            }
            _albumRepository.Delete(album);
        }
    }
}
