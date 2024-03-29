﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;

        public GenreLogic(IGenreRepository genreRepository, IAlbumRepository albumRepository)
        {
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
        }

        //CRUD
        #region CRUD
        public void CreateGenre(Genre genre)
        {
            if (_genreRepository.GetOne(genre.GenreId) == null)
            {
                genre = new Genre
                {
                    GenreId = genre.GenreId,
                    GenreName = genre.GenreName
                };
                _genreRepository.Add(genre);
            }
            else
            {
                throw new Exception($"this genre Id {genre.GenreId} is already exists!");
            }
        }
        public void RemoveGenre(int genreId)
        {
            Genre genre = _genreRepository.GetOne(genreId);
            if (genre == null)
            {
                throw new Exception("Genre does not exist!");
            }
            _genreRepository.Delete(genre);
        }
        public void UpdateGenre(Genre genre)
        {
            var genreToUpdate = _genreRepository.GetOne(genre.GenreId);
            genreToUpdate.GenreName = genre.GenreName;

            _genreRepository.Update(genreToUpdate);
        }
        public Genre GetGenre(int genreId)
        {
            return _genreRepository.GetOne(genreId);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }
        #endregion

        //NON-CRUD
        #region NON-CRUD
        public IEnumerable<Album> GetAllAlbumsWithGenre(int genreId)
        {
            var genre = _genreRepository.GetOne(genreId);
            if (genre == null)
            {
                throw new Exception($"Invalid genre ID: {genreId}");
            }

            var results = _albumRepository.GetAll().Where(al => al.GenreId == genreId);

            return results;
        }
        public IEnumerable<KeyValuePair<string, int>> NumberOfSongsInEachGenre()
        {
            var pairs = from x in _albumRepository.GetAll()
                      group x by x.Genre.GenreName into g
                      select new KeyValuePair<string, int>
                      (
                          g.Key,
                          g.Sum(s => s.NumberOfSongs)
                      );
            return pairs;
        }
        #endregion
    }
}
