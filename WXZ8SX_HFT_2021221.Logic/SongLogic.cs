using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class SongLogic : ISongLogic
    {
        protected readonly ISongRepository _songRepository;

        public void CreateSong(int songId, string songName, double songLength, string writer, string singer, int albumId)
        {
            Song newSong = new Song
            {
                SongId = songId,
                Name = songName,
                Length = songLength,
                Writer = writer,
                Singer = singer,
                AlbumId = albumId
            };
            _songRepository.Add(newSong);
        }

        public Song GetSong(int songId)
        {
            return _songRepository.GetOne(songId);
        }

        public List<Song> GetSongs()
        {
            return _songRepository.GetAll().ToList();
        }
    }
}
