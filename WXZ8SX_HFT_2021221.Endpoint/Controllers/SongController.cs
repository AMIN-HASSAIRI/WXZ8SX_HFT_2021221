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

        // GET /song/4
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            return _songLogic.GetSong(id);
        }

        // POST /song
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            _songLogic.CreateSong(value.SongId, value.Name,value.Length, value.Writer,value.Singer,value.AlbumId);
        }
    }
}
