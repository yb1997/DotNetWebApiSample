using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PracticeWebApi.Configurations;
using PracticeWebApi.Data.DbContexts;
using PracticeWebApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepo _userRepo;

        public AuthController(ILogger<AuthController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var result = _userRepo.GetAllUsers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser()
        {
            return Ok();
        }
    }
}
