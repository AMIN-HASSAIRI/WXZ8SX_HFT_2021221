using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Logic;

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
    }
}
