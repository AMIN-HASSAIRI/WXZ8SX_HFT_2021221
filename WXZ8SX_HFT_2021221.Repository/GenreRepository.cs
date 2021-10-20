using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicDbContext musicDbContext) : base(musicDbContext)
        {
        }

        public override Genre GetOne(int id)
        {
            return MusicDbContext.Genres.SingleOrDefault(genre => genre.GenreId == id);
        }
    }
}
