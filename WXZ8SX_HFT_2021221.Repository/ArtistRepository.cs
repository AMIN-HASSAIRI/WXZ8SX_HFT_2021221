using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Repository
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicDbContext musicDbContext) : base(musicDbContext)
        {
        }

        public override Artist GetOne(int id)
        {
            return MusicDbContext.Artists.SingleOrDefault(artist => artist.ArtistId == id);
        }
    }
}
