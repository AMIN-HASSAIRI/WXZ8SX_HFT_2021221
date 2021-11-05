﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXZ8SX_HFT_2021221.Models;
using WXZ8SX_HFT_2021221.Repository;

namespace WXZ8SX_HFT_2021221.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        private readonly IArtistRepository _artistRepository;

        public Artist GetArtist(int artistId)
        {
            Artist artist = _artistRepository.GetOne(artistId);
            if (artist == null)
            {
                throw new Exception("This artist ID does not exists!");
            }
            else
            {
                return artist;
            }
        }

        public List<Artist> GetArtists()
        {
            return _artistRepository.GetAll().ToList();
        }
    }
}
