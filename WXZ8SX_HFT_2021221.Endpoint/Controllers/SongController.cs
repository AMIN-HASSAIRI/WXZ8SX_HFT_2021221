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
    public class SongController : ControllerBase
    {
        ISongLogic _songLogic;

        public SongController(ISongLogic songLogic)
        {
            _songLogic = songLogic;
        }

        // GET /song
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _songLogic.GetSongs();
        }
    }
}
