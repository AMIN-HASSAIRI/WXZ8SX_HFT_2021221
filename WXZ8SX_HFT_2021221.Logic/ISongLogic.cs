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
        IEnumerable<Song> GetSongs();

        Song GetSong(int songId);

        void CreateSong(int songId, string songName, double songLength, string writer, string singer, int albumId);

        void RemoveSong(int songId);

        string GetWriterNameOfSong(int songId);

        DateTime GetDateOfBirthOfSinger(int songId);

        IEnumerable<Song> GetSongsOrderedByLength();

        IEnumerable<Song> GetSongsOrderedByName();

        Song GetLongestSong();

        Song GetShortestSong();

        string GetAlbumNameOfSong(int songId);

    }
}
