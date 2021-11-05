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

        public void CreateGenre(int genreId, string genreName)
        {
            Genre newGenre = new Genre
            {
                GenreId = genreId,
                GenreName = genreName
            };
            _genreRepository.Add(newGenre);
        }

        public Genre GetGenre(int genreId)
        {
            return _genreRepository.GetOne(genreId);
        }

        public List<Genre> GetGenres()
        {
            return _genreRepository.GetAll().ToList();
        }
    }
}
