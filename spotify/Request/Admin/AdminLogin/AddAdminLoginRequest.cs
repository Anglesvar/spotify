using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.AdminLogin
{
    public class AddAdminLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
