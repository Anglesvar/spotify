using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using spotify.Models;
using spotify.Models.songs;
using spotify.Models.UserPlaylistSongs;
using spotify.Repository.Admin;
using spotify.Request.AddSong;
using spotify.Request.Admin.UpdateSong;
using spotify.Request.AdminLogin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace spotify.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _db;
        private IConfiguration _config;
        public AdminRepository(ApplicationDbContext database, IConfiguration config)
        {
            this._db = database;
            _config = config;
            
        }
        public bool AdminLogin(AddAdminLoginRequest data)
        {
            //Checking if authentication is successful or not
            var login = _db.adminLogin.Where(a => a.Email == data.Email && a.Password == data.Password).ToList();
            if (login.Count != 0)
                return true;
            return false;
        }

        public bool AddSong(AddSongRequest data)
        {
            var checkDuplicate = _db.songs.Where(a => a.SongName.ToLower() == data.SongName.ToLower() || a.SongLink.ToLower() == data.SongName.ToLower()).ToList();
            //Check if data is not empty
            if (data != null && checkDuplicate.Count==0)   
            {
                Song newSong = new Song();
                newSong.SongAlbum = data.SongAlbum;
                newSong.SongArtist = data.SongArtist;
                newSong.SongCoverImage = data.SongCoverImage;
                newSong.SongLink = data.SongLink;
                newSong.SongName = data.SongName;

                _db.songs.Add(newSong);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateSong(UpdateSongRequest data)
        {
            var song = _db.songs.Where(a => a.Id == data.Id).FirstOrDefault();
            if(song!=null && data != null)
            {
                song.SongName = string.IsNullOrEmpty(data.SongName) ? song.SongName : data.SongName;
                song.SongAlbum = string.IsNullOrEmpty(data.SongAlbum) ? song.SongAlbum : data.SongAlbum;
                song.SongArtist = string.IsNullOrEmpty(data.SongArtist) ? song.SongArtist : data.SongArtist;
                song.SongLink = string.IsNullOrEmpty(data.SongLink) ? song.SongLink : data.SongLink;
                song.SongCoverImage = string.IsNullOrEmpty(data.SongCoverImage) ? song.SongCoverImage : data.SongCoverImage;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSong(int id)
        {
            Song song = _db.songs.Find(id);
            if (song == null)
            {
                return false;
            }
            //Removing Song Record from Song Table
            _db.songs.Remove(song);
            
            //Removing Records which to be deleted from UserPlayListSong Table as SongId from SongTable is a foreign key to UserPlayList Table
            var userPlaylistSongs = _db.userPlaylistSongs.Where(a=>a.SongId==id).ToList();
            foreach(UserPlaylistSong playlistSong in userPlaylistSongs)
            {
                _db.userPlaylistSongs.Remove(playlistSong);
            }
            _db.SaveChanges();
            return true;
        }
        public string GenerateJSONWebToken(AddAdminLoginRequest loginData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
