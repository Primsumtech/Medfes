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

       
        /// <summary>
        /// Create hospital
        /// </summary>
        /// <param name="hospitalDTO"></param>
        /// <returns></returns>
        [HttpPost("createhospital")]
        public async Task<IActionResult> CreateHospital(HospitalDTO hospitalDTO)
        {
            bool response =await _hospitalInterface.CreateHospital(hospitalDTO);
            return Ok(response);
        }

        /// <summary>
        /// Edit hospital and location details
        /// </summary>
        /// <param name="hospitalDTO"></param>
        /// <returns></returns>
        [HttpPost("edithospital")]
        public async Task<IActionResult> EditHospital(HospitalDTO hospitalDTO)
        {
            bool response = await _hospitalInterface.CreateHospital(hospitalDTO);
            return Ok(response);
        }
        
        /// <summary>
        /// delete hospital
        /// </summary>
        /// <param name="hospitaltenantid"></param>
        /// <returns></returns>
        [HttpDelete("deletehospital")]
        public async Task<IActionResult> DeleteHospital(int hospitaltenantid)
        {
            bool response = await _hospitalInterface.DeleteHospital(hospitaltenantid);
            return Ok(response);
        }
    }
}
