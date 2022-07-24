using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginInterface _loginInterface;

        public LoginController(LoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }

       


        [HttpPost("loginuser")]
        public IActionResult LoginUser(Login login)
        {
            var response = _loginInterface.LoginUser(login);
            return Ok(response);
        }
    }
}
