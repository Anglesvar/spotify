using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spotify.Models;
using spotify.Models.songs;
using spotify.Repository.Admin;
using spotify.Request.AddSong;
using spotify.Request.Admin.UpdateSong;
using spotify.Request.AdminLogin;

namespace spotify.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("adminlogin")]
        public IActionResult PostAdminLogin(AddAdminLoginRequest loginData)
        {
            var result = repository.AdminLogin(loginData);
            IActionResult response = Unauthorized(new{ message = "Admin Authorization Failed"});
            if (result)
            {
                var JSONToken = repository.GenerateJSONWebToken(loginData);
                return Ok(new { token= JSONToken, message = "Login Successful" });
            }
            return response;
        }

        
        [HttpPost("addsong")]
        public IActionResult PostSong(AddSongRequest songData)
        {
            var result = repository.AddSong(songData);
            if (result)
            {
                return Ok(new { message = "Song Added Successfully" });
            }
            return BadRequest(new { message = "Song Already exists" });
        }

        [HttpPut("updatesong")]
        public IActionResult PutUpdateSong(UpdateSongRequest songData)
        {
            return Ok(repository.UpdateSong(songData));
        }

        [HttpDelete("deletesong")]
        public IActionResult DeleteSong(int id)
        {
            //return Ok(repository.DeleteSong(id));
            if (repository.DeleteSong(id))
            {
                return Ok(new { message = "Song Deleted Successfully" });
            }
            else
            {
                return BadRequest(new { message = "Deletion UnSuccessful" });
            }
        }
        /*[HttpPut("follow")]
        public IActionResult FollowArtist(int songId)
        {
            if (repository.UpdateFollowArtist(songId))
                return Ok(new { message = "Follow artist done" });
            else
                return BadRequest(new { message = "Error following Artist" });
        }*/
    }
}
