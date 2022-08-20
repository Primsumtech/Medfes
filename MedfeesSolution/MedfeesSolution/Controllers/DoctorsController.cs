using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorsInterface _doctorsInterface;

        public DoctorsController(DoctorsInterface doctorsInterface)
        {
            _doctorsInterface = doctorsInterface;
        }

        [HttpGet("getdoctors")]
        public IActionResult GetDoctors()
        {
            var doctor = _doctorsInterface.GetDoctors();
            return Ok(doctor);
        }


        [HttpPost("createdoctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctor createDocotor)
        {
            bool doctor = await _doctorsInterface.CreateDoctor(createDocotor);
            return Ok(doctor);
        }

        [HttpPost("editdoctor")]
        public async Task<IActionResult> EditDoctor(EditDoctor editDoctor)
        {
            bool doctor = await _doctorsInterface.EditDoctor(editDoctor);
            return Ok(doctor);
        }

        [HttpDelete("deletedoctor")]
        public async Task<IActionResult> DeleteDoctor(int doctorid)
        {
            bool doctor = await _doctorsInterface.DeleteDoctor(doctorid);
            return Ok(doctor);
        }
    }
}
