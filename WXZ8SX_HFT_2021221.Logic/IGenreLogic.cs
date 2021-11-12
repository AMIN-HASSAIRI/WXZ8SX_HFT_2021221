﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Logic
{
    public interface IGenreLogic
    {
        IEnumerable<Genre> GetGenres();

        Genre GetGenre(int genreId);

        void CreateGenre(int genreId, string genreName);

        void RemoveGenre(int genreId);

        IEnumerable<Album> GetAllAlbumsWithGenre(int genreId);

    }
}
