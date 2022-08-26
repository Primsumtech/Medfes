using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Models;
namespace MedfeesSolution.DataAccess.Patient
{
    public interface IPatientRepository
    {
        Task<Models.Patient> AddPatient(Models.Patient parameters);

        Task<List<Models.Patient>> GetPatients();

        Task<Models.Patient> GetPatientById(string patientid);

        Task DeletePatientById(string patientid);
    }
}
