using MedfeesSolution.Dtos.Patient;

namespace MedfeesSolution.BusinessProcess.Patient
{
    public interface IPatientBP
    {
        Task<Models.Patient> AddPatient(AddEditPatinetRequestDto parameters);

        Task<List<Models.Patient>> GetPatients();

        Task<PatinetResultDto> GetPatientById(string patientid);

        Task<PatinetResultDto> UpdatePatient(AddEditPatinetRequestDto parameters);

        Task DeletePatientById(string patientid);
    }
}
