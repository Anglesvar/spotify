using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Models.UserAuthInfo
{
    public class UserAuth
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string MobileNumber{ get; set; }
        public string  DisplayName{ get; set; }
    }
}
