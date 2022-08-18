using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface StaffInterface
    {
        List<staff> GetStaff();

        Task<bool> CreateStaff(CreateStaff createStaff);



    }
}
