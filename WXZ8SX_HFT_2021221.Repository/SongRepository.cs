using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Repository
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(MusicDbContext musicDbContext) : base(musicDbContext)
        {
        }

        public override Song GetOne(int id)
        {
            return MusicDbContext.Songs.SingleOrDefault(song => song.SongId == id);
        }
    }
}
