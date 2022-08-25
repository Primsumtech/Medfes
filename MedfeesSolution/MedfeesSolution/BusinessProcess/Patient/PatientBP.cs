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

                result = await _patientRepository.AddPatient(patient);

                return result ?? new Models.Patient();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
