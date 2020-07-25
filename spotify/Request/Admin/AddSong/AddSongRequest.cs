using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.AddSong
{
    public class AddSongRequest
    {
        public string SongName { get; set; }
        public string SongLink { get; set; }
        public string SongArtist { get; set; }
        public string SongAlbum { get; set; }
        public string SongCoverImage { get; set; }
    }
}
