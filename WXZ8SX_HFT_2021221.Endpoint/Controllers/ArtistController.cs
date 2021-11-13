using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Logic;
using WXZ8SX_HFT_2021221.Models;

namespace WXZ8SX_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic _artistLogic;

        public ArtistController(IArtistLogic artistLogic)
        {
            _artistLogic = artistLogic;
        }

        // GET /artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return _artistLogic.GetArtists();
        }
    }
}
