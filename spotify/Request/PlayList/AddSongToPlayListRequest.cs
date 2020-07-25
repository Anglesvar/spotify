using spotify.Models.playlists;
using spotify.Models.songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.PlayList
{
    public class AddSongToPlayListRequest
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public int OwnerId { get; set; }
    }
}
