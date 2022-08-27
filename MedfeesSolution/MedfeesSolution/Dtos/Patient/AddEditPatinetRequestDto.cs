using System.ComponentModel.DataAnnotations;

namespace MedfeesSolution.Dtos.Patient
{
    public class AddEditPatinetRequestDto : BasePatient
    {
        [Required(AllowEmptyStrings =false)]
        [MaxLength(30) ]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(12)]
        public string Mobilenumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Emailid { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string BloodGroup { get; set; }

        public int AdhaarNo { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string State { get; set; }

        [Required]
        public int PinCode { get; set; }

        public byte[] Image { get; set; }

        #region - Second container

        [Required(AllowEmptyStrings = false)]
        [MaxLength(12)]
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
