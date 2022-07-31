using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface HospitalInterface
    {
       Task<bool> CreateHospital(HospitalDTO hospitalDTO);

        
    }
}
