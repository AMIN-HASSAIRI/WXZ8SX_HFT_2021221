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
        private readonly ISongRepository _songRepository;

        public AlbumLogic(IAlbumRepository albumRepository, ISongRepository songRepository)
        {
            _albumRepository = albumRepository;
            _songRepository = songRepository;
        }

        //CRUD
        #region CRUD
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
            return _albumRepository.GetAll();
        }
        #endregion

        //NON-CRUD
        #region NON-CRUD
        public IEnumerable<KeyValuePair<string, double>> GetLongestSongInEachAlbum()
        {
            var pairs = from x in _songRepository.GetAll()
                        group x by x.Album.AlbumName into g
                        select new KeyValuePair<string, double>
                        (
                            g.Key,
                            g.Max(x => x.Length) 
                        );
            return pairs;
        }
        public IEnumerable<Album> GetAlbumsByArtist(int artistId)
        {
            var albums = _albumRepository.GetAll().Where(album => album.ArtistId == artistId);

            if (albums == null)
            {
                throw new Exception($"This artist ID {artistId} has no albums!");
            }
            return albums;
        }

        public IEnumerable<Album> GetAlbumsByYear(string YYYY)
        {
            var albums = _albumRepository.GetAll().Where(album => album.ReleasedDate.Year == int.Parse(YYYY));

            if (albums.Count() == 0)
            {
                 throw new Exception($"There is no album in this year {YYYY}");
            }
            return albums;
        }
        public string GetGenreNameOfAlbumBySongId(int songId)
        {
            var genreName = _albumRepository.GetAll().FirstOrDefault(c => c.Songs.Any(s => s.SongId == songId)).Genre.GenreName;
            return genreName;
        }
        public string GetArtistNameOfAlbumBySongId(int songId)
        {
            var artistName = _albumRepository.GetAll().FirstOrDefault(c => c.Songs.Any(s => s.SongId == songId)).Artist.ArtistName;
            return artistName;
        }
        public IEnumerable<Album> GetBestAlbums()
        {
            var maxRate = _albumRepository.GetAll().Max(x => x.Rating);
            var bestAlbums = _albumRepository.GetAll().Where(x=>x.Rating == maxRate);
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
        #endregion
    }
}
