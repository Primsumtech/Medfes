using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersInterface _usersInterface;

        public UsersController(UsersInterface usersInterface)
        {
            _usersInterface = usersInterface;
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = _usersInterface.GetUsers();
            return Ok(users);
        }
    }
}
