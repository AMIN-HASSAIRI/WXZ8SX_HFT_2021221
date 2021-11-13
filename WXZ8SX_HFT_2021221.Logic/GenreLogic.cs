using System;
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

        public IEnumerable<Album> GetAllAlbumsWithGenre(int genreId)
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

        public IEnumerable<Genre> GetGenres()
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
        public void UpdateGenre(Genre genre)
        {
            var genreToUpdate = _genreRepository.GetOne(genre.GenreId);
            genreToUpdate.GenreName = genre.GenreName;

            _genreRepository.Update(genreToUpdate);
        }

    }
}
