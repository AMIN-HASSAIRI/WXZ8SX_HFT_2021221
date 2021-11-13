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
    public class StatArtistController : ControllerBase
    {
        IArtistLogic _artistLogic;

        public StatArtistController(IArtistLogic artistLogic)
        {
            _artistLogic = artistLogic;
        }

        // GET statartist/getalbumnamebyartistid/4
        [HttpGet("{id}")]
        public string GetAlbumNameByArtistId(int id)
        {
            return _artistLogic.GetAlbumNameByArtistId(id);
        }

        // GET statartist/getalbumsofartist/3
        [HttpGet("{id}")]
        public IEnumerable<Album> GetAlbumsOfArtist(int id)
        {
            return _artistLogic.GetAlbumsOfArtist(id);
        }

        // GET statartist/getartist/4
        [HttpGet("{id}")]
        public Artist GetArtist(int id)
        {
            return _artistLogic.GetArtist(id);
        }

        // GET statartist/getartists
        [HttpGet]
        public IEnumerable<Artist> GetArtists()
        {
            return _artistLogic.GetArtists();
        }
    }
}
