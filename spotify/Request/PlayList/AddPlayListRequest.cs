using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.PlayList
{
    public class AddPlayListRequest
    {
        public string PlayListName { get; set; }
        public int OwnerId { get; set; }
    }
}
