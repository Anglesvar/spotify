using spotify.Models.playlists;
using spotify.Models.UserAuthInfo;
using spotify.Models.UserPlaylistSongs;
using spotify.Request.PlayList;
using spotify.Request.User.UserLogin;
using spotify.Request.User.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.User
{
    public interface IUserRepository
    {
        public bool RegisterUser(AddUserRegistrationRequest data);
        public int LoginUser(AddUserLoginRequest data);
        public UserAuth ShowUserInformation(int id);
        
    }
}
