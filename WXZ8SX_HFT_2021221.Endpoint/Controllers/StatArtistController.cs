using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Endpoint.Services;
using WXZ8SX_HFT_2021221.Logic;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatArtistController : ControllerBase
    {
        IArtistLogic _artistLogic;
        IHubContext<SignalRHub> hub;

        public StatArtistController(IArtistLogic artistLogic, IHubContext<SignalRHub> hub)
        {
            _artistLogic = artistLogic;
            this.hub = hub;
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

        // GET statartist/getartistsorderedbybirthdate
        [HttpGet]
        public IEnumerable<Artist> GetArtistsOrderedByBirthDate()
        {
            return _artistLogic.GetArtistsOrderedByBirthDate();
        }

        // GET statartist/getartistsorderedbyname
        [HttpGet]
        public IEnumerable<Artist> GetArtistsOrderedByName()
        {
            return _artistLogic.GetArtistsOrderedByName();
        }

        // GET statartist/getartistsorderedbynumofalbums
        [HttpGet]
        public IEnumerable<Artist> GetArtistsOrderedByNumOfAlbums()
        {
            return _artistLogic.GetArtistsOrderedByNumOfAlbums();
        }
    }
}
