using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface StateInterface
    {
        List<State> GetAllStates();

        List<State> GetStatebyCountry(int countryid);

       
    }
}
