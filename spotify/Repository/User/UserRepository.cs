using spotify.Models;
using spotify.Models.playlists;
using spotify.Models.songs;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext database)
        {
            this._db = database;
        }
        public bool RegisterUser(AddUserRegistrationRequest RegisterData)
        {
            List<UserAuth> checkDuplicate;
            checkDuplicate = _db.userAuth.Where(a => a.Email.ToLower() == RegisterData.Email.ToLower()).ToList();
            //Checking if User has already Registered 
            if (checkDuplicate.Count == 0)
            {
                if (RegisterData != null)
                {
                    UserAuth userData = new UserAuth();
                    userData.FirstName = RegisterData.FirstName;
                    userData.LastName = RegisterData.LastName;
                    userData.MobileNumber = RegisterData.MobileNumber;
                    userData.Password = RegisterData.Password;
                    userData.Email = RegisterData.Email;
                    userData.DisplayName = RegisterData.DisplayName;
                    //Excluding Id as it should be added dynamically
                    _db.userAuth.Add(userData);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool LoginUser(AddUserLoginRequest loginData)
        {
            if (loginData != null)
            {
                var login = _db.userAuth.Where(a => a.Email == loginData.Email && a.Password == loginData.Password).ToList();
                if (login.Count == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public UserAuth ShowUserInformation(int id)
        {
            UserAuth userProfile = _db.userAuth.Find(id);
            return userProfile;
        }


    }
}
