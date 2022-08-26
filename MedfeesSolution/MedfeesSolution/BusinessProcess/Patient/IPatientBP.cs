using MedfeesSolution.Dtos.Patient;

namespace MedfeesSolution.BusinessProcess.Patient
{
    public interface IPatientBP
    {
        Task<Models.Patient> AddPatient(AddPatinetRequestDto parameters);
        Task<List<Models.Patient>> GetPatients();
        Task<Models.Patient> GetPatientById(string patientid);
        Task DeletePatientById(string patientid);
    }
}
