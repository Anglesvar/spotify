using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Request.User.UserLogin
{
    public class AddUserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
