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

        // GET /album
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _albumLogic.GetAlbums();
        }

        // GET /album/3
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            return _albumLogic.GetAlbum(id);
        }

        // POST /album
        [HttpPost]
        public void Post([FromBody] Album value)
        {
            _albumLogic.CreateAlbum(value);
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            _albumLogic.UpdateAlbum(value);
        }

        // DELETE /album/6
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _albumLogic.RemoveAlbum(id);
        }
    }
}
