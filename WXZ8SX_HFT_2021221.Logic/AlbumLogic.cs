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

        public void CreateAlbum(Album album)
        {
            var al = _albumRepository.GetAll().Where(alb => alb.AlbumId == album.AlbumId);
            if (al.Count() > 0)
            {
                throw new Exception($"This {album.AlbumName} is already used!");
            }
            album = new Album
            {
                AlbumId = album.AlbumId,
                AlbumName = album.AlbumName,
                ReleasedDate = album.ReleasedDate,
                NumberOfSongs = album.NumberOfSongs,
                Rating = album.Rating,
                Length = album.Length,
                ArtistId = album.ArtistId,
                GenreId = album.GenreId
            };
            _albumRepository.Add(album);
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

        public IEnumerable<Album> GetAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public IEnumerable<Album> GetAlbumsByArtist(int artistId)
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

        public IEnumerable<Album> GetAlbumsByYear(string YYYY)
        {
            List<Album> albumsByYear = new List<Album>();

            var albums = _albumRepository.GetAll().Where(album => album.ReleasedDate.Year == int.Parse(YYYY));

            if (albums.Count() == 0)
            {
                 throw new Exception($"There is no album in this year {YYYY}");
            }
            else
            {
                foreach (var album in albums)
                {
                    albumsByYear.Add(album);
                }
                return albumsByYear;
            }
        }

        public IEnumerable<Album> GetBestAlbums()
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
        public void UpdateAlbum(Album album)
        {
            var albumToUpdate = _albumRepository.GetOne(album.AlbumId);
            albumToUpdate.AlbumName = album.AlbumName;
            albumToUpdate.ReleasedDate = album.ReleasedDate;
            albumToUpdate.NumberOfSongs = album.NumberOfSongs;
            albumToUpdate.Rating = album.Rating;
            albumToUpdate.Length = album.Length;
            albumToUpdate.ArtistId = album.ArtistId;
            albumToUpdate.GenreId = album.GenreId;
            
            _albumRepository.Update(albumToUpdate);
        }
    }
}
