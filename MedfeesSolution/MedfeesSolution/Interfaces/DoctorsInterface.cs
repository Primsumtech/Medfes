using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface DoctorsInterface
    {
        List<Doctor> GetDoctors();

        Task<bool> CreateDoctor(CreateDoctor createDoctors);

        Task<bool> EditDoctor(EditDoctor editDoctor);

        Task<bool> DeleteDoctor(int doctorid);



    }
}
