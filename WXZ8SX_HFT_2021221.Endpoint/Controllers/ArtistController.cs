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

        // GET /artist/4
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            return _artistLogic.GetArtist(id);
        }

        // POST /artist
        [HttpPost]
        public void Post([FromBody] Artist value)
        {
            _artistLogic.CreateArtist(value.ArtistId, value.ArtistName, value.DateOfBirth, value.NumberOfAlbums);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            _artistLogic.UpdateArtist(value);
        }

        // DELETE /artist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _artistLogic.RemoveArtist(id);
        }
    }
}
