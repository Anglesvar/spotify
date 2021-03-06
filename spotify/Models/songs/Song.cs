﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Models.songs
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public string SongLink{ get; set; }
        public string SongArtist { get; set; }
        public string SongAlbum { get; set; }
        public string SongCoverImage { get; set; }
    }
}
