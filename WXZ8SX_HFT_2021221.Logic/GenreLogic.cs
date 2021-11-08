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

        public void CreateGenre(int genreId, string genreName)
        {
            if (_genreRepository.GetOne(genreId) == null)
            {
                Genre newGenre = new Genre
                {
                    GenreId = genreId,
                    GenreName = genreName
                };
                _genreRepository.Add(newGenre);
            }
            else
            {
                throw new Exception($"this genre Id {genreId} is already exists!");
            }
        }

        public List<Album> GetAllAlbumsWithGenre(int genreId)
        {
            var genre = _genreRepository.GetOne(genreId);
            if (genre == null)
            {
                throw new Exception($"Invalid genre ID: {genreId}");
            }
            List<Album> albumsGenre = new List<Album>();
            var albums = _albumRepository.GetAll().Where(album => album.GenreId == genre.GenreId);
            foreach (Album al in albums)
            {
                albumsGenre.Add(al);
            }
            return albumsGenre;
        }

        public Genre GetGenre(int genreId)
        {
            return _genreRepository.GetOne(genreId);
        }

        public List<Genre> GetGenres()
        {
            return _genreRepository.GetAll().ToList();
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
    }
}
