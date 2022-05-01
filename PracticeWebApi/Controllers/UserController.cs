using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok();
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserRequest request)
        {
            Random random = new Random();
            var newUser = new User 
            { 
                Id = random.Next(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
            };
            return Created($"/User/{newUser.Id}", newUser);
        }

        [HttpPatch]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest request)
        {

            return Ok();
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok();
        }
    }
}
