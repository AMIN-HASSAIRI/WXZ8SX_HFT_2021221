using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Logic
{
    public interface IGenreLogic
    {
        //CRUD
        void CreateGenre(Genre genre);

        void RemoveGenre(int genreId);

        void UpdateGenre(Genre genre);

        Genre GetGenre(int genreId);

        IEnumerable<Genre> GetGenres();

        //NON-CRUD
        IEnumerable<Album> GetAllAlbumsWithGenre(int genreId);

        IEnumerable<KeyValuePair<string, int>> NumberOfSongsInEachGenre();
    }
}
