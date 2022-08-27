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
            try
            {
                return await _context.Patients.FirstOrDefaultAsync(p => p.Patientid == patientid);
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

        public async Task<Models.Patient> UpdatePatient(AddEditPatinetRequestDto parameters)
        {
            Models.Patient patient = null;
            try
            {
                patient = await _context.Patients.FirstOrDefaultAsync(p => p.Patientid == parameters.PatientId);

                if (patient == null)
                {
                    throw new Exception($"Invalid patent id: {parameters.PatientId}");
                }

                patient.Firstname = parameters.Firstname;
                patient.Lastname = parameters.Lastname;
                patient.Address = parameters.Address;
                patient.Emailid = parameters.Emailid;
                patient.Mobilenumber = parameters.Mobilenumber;
                patient.Gender = parameters.Gender;
                patient.DOB = parameters.DOB;
                patient.FatherName = parameters.FatherName;
                patient.MotherName = parameters.MotherName;
                patient.BloodGroup = parameters.BloodGroup;
                patient.AdhaarNo = parameters.AdhaarNo;
                patient.Address = parameters.Address;
                patient.City = parameters.City;
                patient.State = parameters.State;
                patient.PinCode = parameters.PinCode;
                patient.Image = parameters.Image;

                patient.EmergencyContactNo = parameters.EmergencyContactNo;
                patient.EmergencyContactName = parameters.EmergencyContactName;
                patient.EmergencyContactRelation = parameters.EmergencyContactRelation;
                patient.NomineeName = parameters.NomineeName;
                patient.NomineeAadharNo = parameters.NomineeAadharNo;
                patient.NomineeContactNumber = parameters.NomineeContactNumber;
                patient.NomineeRelation = parameters.NomineeRelation;

                patient.InsuredName = parameters.InsuredName;
                patient.PolicyNo = parameters.PolicyNo;
                patient.InsuredFromTo = parameters.InsuredFromTo;
                patient.Insurer = parameters.Insurer;
                patient.InsuranceType = parameters.InsuranceType;
                patient.Status = parameters.Status;
                patient.UploadInsurance = parameters.UploadInsurance;

                patient.Profession = parameters.Profession;
                patient.Education = parameters.Education;
                patient.MaritalStatus = parameters.MaritalStatus;
                patient.DriverLicenseNo = parameters.DriverLicenseNo;
                patient.PassportNo = parameters.PassportNo;
                patient.PanNo = parameters.PanNo;
                patient.EmployerName = parameters.EmployerName;
                patient.EmployeeID = parameters.EmployeeID;
                patient.UploadIdentifiaction = parameters.UploadIdentifiaction;

                _context.Patients.Update(patient);
                await _context.SaveChangesAsync();

                return patient;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting patient.", ex);
            }

        }
    }

}
