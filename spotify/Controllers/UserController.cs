﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spotify.Models.UserAuthInfo;
using spotify.Repository.User;
using spotify.Request.PlayList;
using spotify.Request.User.UserLogin;
using spotify.Request.User.UserRegistration;

namespace spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("register")]
        public IActionResult PostRegisterUser(AddUserRegistrationRequest registrationData)
        {
            var success = repository.RegisterUser(registrationData);
            if (success)
            {
                return Ok(success);
            }
            else
            {
                return Unauthorized(new { message = "User already Exists, Duplication not allowed." });
            }

        }
        [HttpPost("login")]
        public IActionResult PostLoginUser(AddUserLoginRequest loginData)
        {
            var success = repository.LoginUser(loginData);
            if (success!=0)
                return Ok(new { message = "Login Successful" ,ownerId = success});
            else
                return Unauthorized(new { message = "Authorization Failed" });
        }

        [HttpPost("getuserinfo")]
        public IActionResult GetUserInfo(int id)
        {
            var result = repository.ShowUserInformation(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                var message =  " Requested Data with id "+id+" Not Found ";
                return NotFound(message);
            }
        }

        
    }
}
