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
    public class StatSongController : ControllerBase
    {
        ISongLogic _songLogic;

        public StatSongController(ISongLogic songLogic)
        {
            _songLogic = songLogic;
        }

        // GET statsong/getalbumnameofsong/4
        [HttpGet("{id}")]
        public string GetAlbumNameOfSong(int id)
        {
            return _songLogic.GetAlbumNameOfSong(id);
        }

        // GET statsong/getdateofbirthofsinger/3
        [HttpGet("{id}")]
        public DateTime GetDateOfBirthOfSinger(int id)
        {
            return _songLogic.GetDateOfBirthOfSinger(id);
        }

        // GET statsong/getlongestsong
        [HttpGet]
        public Song GetLongestSong()
        {
            return _songLogic.GetLongestSong();
        }

        // GET statsong/getshortestsong
        [HttpGet]
        public Song GetShortestSong()
        {
            return _songLogic.GetShortestSong();
        }
    }
}
