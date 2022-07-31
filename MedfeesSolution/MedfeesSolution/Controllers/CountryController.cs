using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Interfaces;

namespace MedfeesSolution.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryInterface _countryInterface;

        public CountryController(CountryInterface countryInterface)
        {
            _countryInterface = countryInterface;
        }

       

        /// <summary>
        /// Get countries
        /// </summary>
        /// <returns></returns>
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var response = _countryInterface.GetAllCountries();
            return Ok(response);
        }
    }
}
