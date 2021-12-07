using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Data;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(MusicDbContext musicDbContext) : base(musicDbContext)
        {
        }

        public override Album GetOne(int id)
        {
            return MusicDbContext.Albums.FirstOrDefault(album => album.AlbumId == id);
        }
    }
}
