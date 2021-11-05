using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        private readonly IAlbumRepository _albumRepository;

        public void CreateAlbum(int albumId, string albumName, DateTime releasedDate, int numberOfSongs, double rating, double length, int artistId, int genreId)
        {
            Album newAlbum = new Album
            {
                AlbumId = albumId,
                AlbumName = albumName,
                ReleasedDate = releasedDate,
                NumberOfSongs = numberOfSongs,
                Rating = rating,
                Length = length,
                ArtistId = artistId,
                GenreId = genreId
            };
            _albumRepository.Add(newAlbum);
        }

        public Album GetAlbum(int id)
        {
            Album album = _albumRepository.GetOne(id);
            if (album == null)
            {
                throw new Exception("Album does not exist!");
            }
            else
            {
                return album;
            }
        }

        public List<Album> GetAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }

        public void RemoveAlbum(int albumId)
        {
            Album album = _albumRepository.GetOne(albumId);

            if (album == null)
            {
                throw new Exception("Album does not exist!");
            }
            _albumRepository.Delete(album);
        }
    }
}
