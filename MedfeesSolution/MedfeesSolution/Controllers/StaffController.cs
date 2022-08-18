using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffInterface _staffInterface;

        public StaffController(StaffInterface staffInterface)
        {
            _staffInterface = staffInterface;
        }

        [HttpGet("getstaff")]
        public IActionResult GetStaff()
        {
            var staff = _staffInterface.GetStaff();
            return Ok(staff);
        }


        [HttpPost("createstaff")]
        public async Task<IActionResult> CreateStaff(CreateStaff createStaff)
        {
            bool staff =await _staffInterface.CreateStaff(createStaff);
            return Ok(staff);
        }
    }
}
