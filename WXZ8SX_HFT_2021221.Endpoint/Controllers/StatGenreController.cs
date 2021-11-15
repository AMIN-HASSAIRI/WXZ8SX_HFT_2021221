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
    public class StatGenreController : ControllerBase
    {
        IGenreLogic _genreLogic;

        public StatGenreController(IGenreLogic genreLogic)
        {
            _genreLogic = genreLogic;
        }

        // GET statgenre/getallalbumswithgenre/4
        [HttpGet("{id}")]
        public IEnumerable<Album> GetAllAlbumsWithGenre(int id)
        {
            return _genreLogic.GetAllAlbumsWithGenre(id);
        }
    }
}
