using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface CityInterface
    {
        List<City> GetAllCities();

        List<City> GetCitybyState(int stateid);

       
    }
}
