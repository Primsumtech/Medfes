using MedfeesSolution.Utilities.DateFormater;
using System.Text.Json.Serialization;

namespace MedfeesSolution.Dtos.Patient
{
    public class AddPatinetRequestDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilenumber { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
       
        public DateTime DOB { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string BloodGroup { get; set; }
        public int AdhaarNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public byte[] Image { get; set; }

        #region - Second container
        public string EmergencyContactNo { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAadharNo { get; set; }
        public string NomineeContactNumber { get; set; }
        public string NomineeRelation { get; set; }
        #endregion

        #region - Insurance Details
        public string InsuredName { get; set; }
        public string PolicyNo { get; set; }
        public string InsuredFromTo { get; set; }
        public string Insurer { get; set; }
        public string InsuranceType { get; set; }
        public string Status { get; set; }
        public byte[] UploadInsurance { get; set; }
        #endregion

        #region - Social Details
        public string Profession { get; set; }
        public string Education { get; set; }
        public string MaritalStatus { get; set; }
        public string DriverLicenseNo { get; set; }
        public string PassportNo { get; set; }
        public string PanNo { get; set; }
        public string EmployerName { get; set; }
        public string EmployeeID { get; set; }
        public byte[] UploadIdentifiaction { get; set; }
        #endregion
    }
}
