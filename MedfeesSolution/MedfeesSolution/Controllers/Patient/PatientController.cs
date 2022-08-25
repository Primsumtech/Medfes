using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MedfeesSolution.BusinessProcess.Patient;
using MedfeesSolution.Dtos.Patient;

namespace MedfeesSolution.Controllers.Patient
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBP _patientBP;

        public PatientController(IPatientBP patientBP)
        {
            _patientBP = patientBP;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddPatient([FromBody] AddPatinetRequestDto parameters)
        {
            if (parameters == null)
            {
                return new BadRequestResult();
            }
            Models.Patient result = await _patientBP.AddPatient(parameters);
            return Ok(result);
        }
    }
}
