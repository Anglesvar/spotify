using spotify.Request.AddSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.Admin.UpdateSong
{
    public class UpdateSongRequest: AddSongRequest
    {
        public int Id { get; set; }
    }
}
