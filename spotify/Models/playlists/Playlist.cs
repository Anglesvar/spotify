using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Models.playlists
{
    public class Playlist
    {
        public int Id{ get; set; }
        public string PlayListName{ get; set; }
        public int OwnerId{ get; set; }
    }
}
