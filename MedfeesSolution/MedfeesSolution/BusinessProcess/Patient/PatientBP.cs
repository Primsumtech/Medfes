using AutoMapper;
using MedfeesSolution.DataAccess.Patient;
using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Hashing;

namespace MedfeesSolution.BusinessProcess.Patient
{
    public class PatientBP : IPatientBP
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientBP(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<Models.Patient> AddPatient(AddPatinetRequestDto parameters)
        {
            Models.Patient result = null;
            try
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(parameters.Password, out passwordHash, out passwordSalt);

                Models.Patient patient = new Models.Patient();
                patient.Firstname = parameters.Firstname;
                patient.Lastname = parameters.Lastname;
                patient.Address = parameters.Address;
                patient.Emailid = parameters.Emailid;
                patient.Mobilenumber = parameters.Mobilenumber;
                patient.Gender = parameters.Gender;
                patient.Passwordhash = passwordHash;
                patient.Passwordsalt = passwordSalt;
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

                result = await _patientRepository.AddPatient(patient);

                return result ?? new Models.Patient();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Models.Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Models.Patient> GetPatientById(string patientid)
        {
            if (string.IsNullOrEmpty(patientid))
            {
                throw new Exception($"Invalid patent id: {patientid}");
            }

            return await _patientRepository.GetPatientById(patientid);
        }

        public async Task DeletePatientById(string patientid)
        {
            if (string.IsNullOrEmpty(patientid))
            {
                throw new Exception($"Invalid patent id: {patientid}");
            }

            await _patientRepository.DeletePatientById(patientid);
        }
    }
}
