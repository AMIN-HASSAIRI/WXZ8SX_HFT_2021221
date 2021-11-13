using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Logic;

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

        // GET stat/artist/4
        [HttpGet("{id}")]
        public string GetAlbumNameByArtistId(int id)
        {
            return _artistLogic.GetAlbumNameByArtistId(id);
        }

    }
}
