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
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic _artistLogic;
        IHubContext<SignalRHub> hub;

        public ArtistController(IArtistLogic artistLogic, IHubContext<SignalRHub> hub)
        {
            _artistLogic = artistLogic;
            this.hub = hub;
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
            _artistLogic.CreateArtist(value);
            hub.Clients.All.SendAsync("ArtistCreated", value);
        }

        // PUT /artist
        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            _artistLogic.UpdateArtist(value);
            hub.Clients.All.SendAsync("ArtistUpdated", value);
        }

        // DELETE /artist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = this._artistLogic.GetArtist(id);
            _artistLogic.RemoveArtist(id);
            hub.Clients.All.SendAsync("ArtistDeleted", artistToDelete);
        }
    }
}
