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
    public class StatSongController : ControllerBase
    {
        ISongLogic _songLogic;

        public StatSongController(ISongLogic songLogic)
        {
            _songLogic = songLogic;
        }
    }
}
