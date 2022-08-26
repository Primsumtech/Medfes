using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Models;
using Microsoft.EntityFrameworkCore;

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
            catch (Exception ex)
            {
                throw new Exception($"Error while adding patient.", ex);
            }
        }

        public async Task<List<Models.Patient>> GetPatients()
        {
            List<Models.Patient> result = null;
            try
            {
                result =  await _context.Patients.ToListAsync();
                return result ?? new List<Models.Patient>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error while retrieving patients.", ex);
            }
        }

        public async Task<Models.Patient> GetPatientById(string patientid)
        {
            Models.Patient result = null;
            try
            {
                result = await _context.Patients.FirstOrDefaultAsync(p => p.Patientid == patientid);
                return result ?? new Models.Patient();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error while retrieving patient.", ex);
            }
        }

        public async Task DeletePatientById(string patientid)
        {
            Models.Patient patient = null;
            try
            {
                patient = await _context.Patients.FirstOrDefaultAsync(p => p.Patientid == patientid);
                if (patient == null)
                {
                    throw new Exception($"Invalid patent id: {patientid}");
                }

                _context.Remove(patient);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting patient.", ex);
            }
        }
    }

}
