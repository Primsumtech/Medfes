using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Models;

namespace MedfeesSolution.DataAccess.Patient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly medfesContext _context;

        public PatientRepository(medfesContext context)
        {
            _context = context;
        }

            
        public async Task<Models.Patient> AddPatient(Models.Patient parameters)
        {

            try
            {
                Models.Patient patient = parameters;

                _context.AddAsync(patient);
                await _context.SaveChangesAsync();

                return patient;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }

}
