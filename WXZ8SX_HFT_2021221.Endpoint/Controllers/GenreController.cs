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
    public class GenreController : ControllerBase
    {
        IGenreLogic _genreLogic;

        public GenreController(IGenreLogic genreLogic)
        {
            _genreLogic = genreLogic;
        }
        // GET /genre
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _genreLogic.GetGenres();
        }

        // GET /genre/4
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            return _genreLogic.GetGenre(id);
        }

        // POST /genre
        [HttpPost]
        public void Post([FromBody] Genre value)
        {
            _genreLogic.CreateGenre(value.GenreId, value.GenreName);
        }

        // PUT /genre
        [HttpPut]
        public void Put([FromBody] Genre value)
        {
            _genreLogic.UpdateGenre(value);
        }

        // DELETE /genre/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _genreLogic.RemoveGenre(id);
        }
    }
}
