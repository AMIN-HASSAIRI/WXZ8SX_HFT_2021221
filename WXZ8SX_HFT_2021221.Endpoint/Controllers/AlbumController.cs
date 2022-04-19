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
    public class AlbumController : ControllerBase
    {
        IAlbumLogic _albumLogic;
        IHubContext<SignalRHub> hub;

        public AlbumController(IAlbumLogic albumLogic, IHubContext<SignalRHub> hub)
        {
            _albumLogic = albumLogic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("AlbumCreated", value);
        }

        // PUT /album
        [HttpPut]
        public void Put([FromBody] Album value)
        {
            _albumLogic.UpdateAlbum(value);
            hub.Clients.All.SendAsync("AlbumUpdated", value);
        }

        // DELETE /album/6
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var albumToDelete = this._albumLogic.GetAlbum(id);
            _albumLogic.RemoveAlbum(id);
            hub.Clients.All.SendAsync("AlbumDeleted", albumToDelete);
        }
    }
}
