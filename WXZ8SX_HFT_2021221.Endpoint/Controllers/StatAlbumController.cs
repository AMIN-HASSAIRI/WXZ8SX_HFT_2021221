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

        // GET stat/getalbumsbyartist/4
        [HttpGet("{id}")]
        public IEnumerable<Album> GetAlbumsByArtist(int id)
        {
            return _albumLogic.GetAlbumsByArtist(id);
        }


    }
}
