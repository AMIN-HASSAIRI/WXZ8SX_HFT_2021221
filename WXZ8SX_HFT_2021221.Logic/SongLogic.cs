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
        protected readonly IAlbumRepository _albumRepository;
        protected readonly IArtistRepository _artistRepository;

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

        public string GetAlbumNameOfSong(int songId)
        {
            Song song = _songRepository.GetOne(songId);
            if (song == null)
            {
                throw new Exception($"There is no such song ID: {songId}!");
            }
            string albumName = _songRepository.GetAll().FirstOrDefault(song => song.SongId == songId).Album.AlbumName;

            return albumName;
        }

        public DateTime GetDateOfBirthOfSinger(int songId)
        {
            Song song = _songRepository.GetOne(songId);
            if (song == null)
            {
                throw new Exception($"This song ID: {songId} does not exists!");
            }
            Album album = _albumRepository.GetAll().Where(album => album.AlbumId == song.AlbumId).SingleOrDefault();

            Artist artist = _artistRepository.GetAll().Where(artist => artist.ArtistId == album.ArtistId).SingleOrDefault();

            if (artist.DateOfBirth is DateTime artistBirthday)
            {
                return artistBirthday.Date;
            }
            else
            {
                throw new Exception("Invalid date of birth!");
            }
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

        public Song GetSong(int songId)
        {
            return _songRepository.GetOne(songId);
        }

        public List<Song> GetSongs()
        {
            return _songRepository.GetAll().ToList();
        }

        public List<Song> GetSongsOrderedByLength()
        {
            List<Song> orderedSongs = new List<Song>();

            var songs = _songRepository.GetAll().OrderBy(song => song.Length);

            foreach (Song song in songs)
            {
                orderedSongs.Add(song);
            }
            return orderedSongs;
        }

        public List<Song> GetSongsOrderedByName()
        {
            List<Song> orderedSongs = new List<Song>();

            var songs = _songRepository.GetAll().OrderBy(song => song.Name);

            foreach (Song song in songs)
            {
                orderedSongs.Add(song);
            }
            return orderedSongs;
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
    }
}
