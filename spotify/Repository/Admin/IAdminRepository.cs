using Microsoft.AspNetCore.Identity;
using spotify.Models;
using spotify.Models.songs;
using spotify.Request.AddSong;
using spotify.Request.Admin.UpdateSong;
using spotify.Request.AdminLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.Admin
{
    public interface IAdminRepository
    {
        public bool AdminLogin(AddAdminLoginRequest data);
        public bool AddSong(AddSongRequest data);
        public bool UpdateSong(UpdateSongRequest data);
        public bool DeleteSong(int id);
        //public bool UpdateFollowArtist(int Id);

        public string GenerateJSONWebToken(AddAdminLoginRequest loginData);
    }
}
