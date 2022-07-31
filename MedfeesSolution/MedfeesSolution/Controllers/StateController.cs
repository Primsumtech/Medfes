using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/state")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateInterface _stateInterface;

        public StateController(StateInterface stateInterface)
        {
            _stateInterface = stateInterface;
        }

       

        /// <summary>
        /// Get states
        /// </summary>
        /// <returns></returns>
        [HttpGet("states")]
        public IActionResult GetStates()
        {
            var response = _stateInterface.GetAllStates();
            return Ok(response);
        }

        /// <summary>
        /// Get state by countryid
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        [HttpGet("statesbycountryid")]
        public IActionResult GetState(int countryid)
        {
            var response = _stateInterface.GetStatebyCountry(countryid);
            return Ok(response);
        }
    }
}
