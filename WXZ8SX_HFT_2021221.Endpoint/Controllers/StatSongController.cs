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
    public class StatSongController : ControllerBase
    {
        ISongLogic _songLogic;
        IHubContext<SignalRHub> hub;

        public StatSongController(ISongLogic songLogic, IHubContext<SignalRHub> hub)
        {
            _songLogic = songLogic;
            this.hub = hub;
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

        // GET statsong/getnumberofalbumsbysongid/5
        [HttpGet("{id}")]
        public int GetNumberOfAlbumsBySongID(int id)
        {
            return _songLogic.GetNumberOfAlbumsBySongId(id);
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

        // GET statsong/getsongsorderedbylength
        [HttpGet]
        public IEnumerable<Song> GetSongsOrderedByLength()
        {
            return _songLogic.GetSongsOrderedByLength();
        }

        // GET statsong/getsongsorderedbyname
        [HttpGet]
        public IEnumerable<Song> GetSongsOrderedByName()
        {
            return _songLogic.GetSongsOrderedByName();
        }

        // GET statsong/getwriternameofsong/5
        [HttpGet("{id}")]
        public string GetWriterNameOfSong(int id)
        {
            return _songLogic.GetWriterNameOfSong(id);
        }
    }
}
