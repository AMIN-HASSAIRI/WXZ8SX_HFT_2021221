using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Logic
{
    public interface ISongLogic
    {
        List<Song> GetSongs();

        Song GetSong(int songId);

    }
}
