using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Models;
namespace MedfeesSolution.DataAccess.Patient
{
    public interface IPatientRepository
    {
        Task<Models.Patient> AddPatient(Models.Patient parameters);
    }
}
