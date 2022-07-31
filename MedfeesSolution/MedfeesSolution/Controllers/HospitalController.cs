using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/hospital")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalInterface _hospitalInterface;

        public HospitalController(HospitalInterface hospitalInterface)
        {
            _hospitalInterface = hospitalInterface;
        }

       

        [HttpPost("createhospital")]
        public async Task<IActionResult> CreateHospital(HospitalDTO hospitalDTO)
        {
            bool response =await _hospitalInterface.CreateHospital(hospitalDTO);
            return Ok(response);
        }
    }
}
