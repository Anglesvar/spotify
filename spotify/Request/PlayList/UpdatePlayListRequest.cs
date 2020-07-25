using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.PlayList
{
    public class UpdatePlayListRequest:AddPlayListRequest
    {
        public int Id { get; set; }
    }
}
