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
    public class SongController : ControllerBase
    {
        ISongLogic _songLogic;
        IHubContext<SignalRHub> hub;

        public SongController(ISongLogic songLogic, IHubContext<SignalRHub> hub)
        {
            _songLogic = songLogic;
            this.hub = hub;
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
            _songLogic.CreateSong(value);
            hub.Clients.All.SendAsync("SongCreated", value);
        }

        // PUT /song
        [HttpPut]
        public void Put([FromBody] Song value)
        {
            _songLogic.UpdateSong(value);
            hub.Clients.All.SendAsync("SongUpdated", value);
        }

        // DELETE /song/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = this._songLogic.GetSong(id);
            _songLogic.RemoveSong(id);
            hub.Clients.All.SendAsync("GenreDeleted", songToDelete);
        }
    }
}
