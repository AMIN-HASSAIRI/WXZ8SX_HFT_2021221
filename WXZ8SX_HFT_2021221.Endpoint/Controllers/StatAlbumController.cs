using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Logic;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatAlbumController : ControllerBase
    {
        IAlbumLogic _albumLogic;

        public StatAlbumController(IAlbumLogic albumLogic)
        {
            _albumLogic = albumLogic;
        }

        // GET statalbum/getalbumsbyartist/4
        [HttpGet("{id}")]
        public IEnumerable<Album> GetAlbumsByArtist(int id)
        {
            return _albumLogic.GetAlbumsByArtist(id);
        }

        // GET statalbum/getalbumsbyyear/2002
        [HttpGet("{YYYY}")]
        public IEnumerable<Album> GetAlbumsByYear(string YYYY)
        {
            return _albumLogic.GetAlbumsByYear(YYYY);
        }

        // GET statalbum/getbestalbums
        [HttpGet]
        public IEnumerable<Album> GetBestAlbums()
        {
            return _albumLogic.GetBestAlbums();
        }

        // GET statalbum/getthelongestalbum
        [HttpGet]
        public Album GetTheLongestAlbum()
        {
            return _albumLogic.GetTheLongestAlbum();
        }

        // GET statalbum/getthenewestalbum
        [HttpGet]
        public Album GetTheNewestAlbum()
        {
            return _albumLogic.GetTheNewestAlbum();
        }

        // GET statalbum/gettheoldestalbum
        [HttpGet]
        public Album GetTheOldestAlbum()
        {
            return _albumLogic.GetTheOldestAlbum();
        }

        // GET statalbum/gettheshortestalbum
        [HttpGet]
        public Album GetTheShortestAlbum()
        {
            return _albumLogic.GetTheShortestAlbum();
        }
    }
}
