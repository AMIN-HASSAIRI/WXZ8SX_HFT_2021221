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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatGenreController : ControllerBase
    {
        IGenreLogic _genreLogic;
        IHubContext<SignalRHub> hub;

        public StatGenreController(IGenreLogic genreLogic, IHubContext<SignalRHub> hub)
        {
            _genreLogic = genreLogic;
            this.hub = hub;
        }

        // GET statgenre/getallalbumswithgenre/4
        [HttpGet("{id}")]
        public IEnumerable<Album> GetAllAlbumsWithGenre(int id)
        {
            return _genreLogic.GetAllAlbumsWithGenre(id);
        }

        // GET statgenre/numberofsongsineachgenre
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfSongsInEachGenre()
        {
            return _genreLogic.NumberOfSongsInEachGenre();   
        }
    }
}
