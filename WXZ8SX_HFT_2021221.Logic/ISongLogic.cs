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

        //CRUD
        void CreateSong(Song song);

        void RemoveSong(int songId);

        void UpdateSong(Song song);

        Song GetSong(int songId);

        IEnumerable<Song> GetSongs();

        //NON-CRUD
        DateTime GetDateOfBirthOfSinger(int songId);

        int GetNumberOfAlbumsBySongId(int songId);

        string GetWriterNameOfSong(int songId);

        IEnumerable<Song> GetSongsOrderedByLength();

        IEnumerable<Song> GetSongsOrderedByName();

        Song GetLongestSong();

        Song GetShortestSong();

        string GetAlbumNameOfSong(int songId);
    }
}
