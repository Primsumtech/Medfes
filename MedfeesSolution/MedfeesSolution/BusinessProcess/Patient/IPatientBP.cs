using MedfeesSolution.Dtos.Patient;

namespace MedfeesSolution.BusinessProcess.Patient
{
    public interface IPatientBP
    {
       
        Task<Models.Patient> AddPatient(AddPatinetRequestDto parameters);
    }
}
