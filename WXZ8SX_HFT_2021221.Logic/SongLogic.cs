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
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;

        public SongLogic(ISongRepository songRepository, IAlbumRepository albumRepository)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
        }

        //CRUD
        #region CRUD
        public void CreateSong(Song song)
        {
            if (_songRepository.GetOne(song.SongId) == null)
            {
                song = new Song
                {
                    SongId = song.SongId,
                    Name = song.Name,
                    Length = song.Length,
                    Writer = song.Writer,
                    Singer = song.Singer,
                    AlbumId = song.AlbumId
                };
                _songRepository.Add(song);
            }
            else
            {
                throw new Exception($"This song Id {song.SongId} is already used!");
            }
        }
        public void RemoveSong(int songId)
        {
            Song song = _songRepository.GetOne(songId);

            if (song == null)
            {
                throw new Exception("Invalid Song ID!");
            }
            else
            {
                _songRepository.Delete(song);
            }
        }
        public void UpdateSong(Song song)
        {
            var songToUpdate = _songRepository.GetOne(song.SongId);
            songToUpdate.Name = song.Name;
            songToUpdate.Length = song.Length;
            songToUpdate.Writer = song.Writer;
            songToUpdate.Singer = song.Singer;
            songToUpdate.AlbumId = song.AlbumId;

            _songRepository.Update(songToUpdate);
        }
        public Song GetSong(int songId)
        {
            return _songRepository.GetOne(songId);
        }
        public IEnumerable<Song> GetSongs()
        {
            return _songRepository.GetAll();
        }
        #endregion

        //NON-CRUD
        #region NON-CRUD
        public string GetAlbumNameOfSong(int songId)
        {
            Song ssong = _songRepository.GetOne(songId);
            if (ssong == null)
            {
                throw new Exception($"There is no such song ID: {songId}!");
            }
            var albumName = _songRepository.GetAll().FirstOrDefault(song => song.SongId == songId).Album.AlbumName;

            return albumName;
        }

        public DateTime GetDateOfBirthOfSinger(int songId)
        {
            Song song = _songRepository.GetOne(songId);
            if (song == null)
            {
                throw new Exception($"This song ID: {songId} does not exists!");
            }
            var artistDateOfBirth = _albumRepository.GetAll().FirstOrDefault(c => c.Songs.Any(s => s.SongId == songId))
                .Artist.DateOfBirth;

            return artistDateOfBirth;
        }
        public int GetNumberOfAlbumsBySongId(int songId)
        {
            Song song = _songRepository.GetOne(songId);
            if (song == null)
            {
                throw new Exception($"This song ID: {songId} does not exists!");
            }
            var numOfAlbums = _albumRepository.GetAll().FirstOrDefault(c => c.Songs.Any(s => s.SongId == songId)).Artist.NumberOfAlbums;

            return numOfAlbums;

        }
        public Song GetLongestSong()
        {
            Song longestSong = _songRepository.GetAll().OrderBy(song => song.Length).Last();

            return longestSong;
        }

        public Song GetShortestSong()
        {
            Song shortestSong = _songRepository.GetAll().OrderBy(song => song.Length).First();

            return shortestSong;
        }

        public IEnumerable<Song> GetSongsOrderedByLength()
        {
            var songs = _songRepository.GetAll().OrderBy(song => song.Length);

            return songs;
        }

        public IEnumerable<Song> GetSongsOrderedByName()
        {
            var songs = _songRepository.GetAll().OrderBy(song => song.Name);

            return songs;
        }

        public string GetWriterNameOfSong(int songId)
        {
            string writerName = _songRepository.GetOne(songId).Writer;

            if (writerName == null)
            {
                throw new Exception("Invalid Song ID!");
            }
            return writerName;
        }
        #endregion
    }
}
