using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityInterface _cityInterface;

        public CityController(CityInterface cityInterface)
        {
            _cityInterface = cityInterface;
        }

       

        /// <summary>
        /// Get cities
        /// </summary>
        /// <returns></returns>
        [HttpGet("cities")]
        public IActionResult GetCities()
        {
            var response = _cityInterface.GetAllCities();
            return Ok(response);
        }

        /// <summary>
        /// Get cities by stateid
        /// </summary>
        /// <param name="stateid"></param>
        /// <returns></returns>
        [HttpGet("citiesbystateid")]
        public IActionResult GetCitiesbyStateid(int stateid)
        {
            var response = _cityInterface.GetCitybyState(stateid);
            return Ok(response);
        }
    }
}
