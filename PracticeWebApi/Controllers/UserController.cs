using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApi.Business.Models;
using PracticeWebApi.Business.Services;
using PracticeWebApi.Models;
using PracticeWebApi.Models.Request;
using System;
using System.Collections.Generic;

namespace PracticeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }


        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserByUserId(int userId)
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserRequest request)
        {
            var userInfo = new User 
            { 
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
            };

            var newUser = _userService.AddNewUser(userInfo);


            return Created($"/User/{newUser.UserId}", newUser);
        }

        [HttpPatch]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {
            var userInfo = new User
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
            };

            var updatedUser = _userService.UpdateUser(userInfo);

            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
