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
    public class AlbumController : ControllerBase
    {
        IAlbumLogic _albumLogic;

        public AlbumController(IAlbumLogic albumLogic)
        {
            _albumLogic = albumLogic;
        }

        //Get Albums
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _albumLogic.GetAlbums();
        }

        // Get Album
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return _albumLogic.GetAlbum(id);
        }
    }
}
