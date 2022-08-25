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
    }
}
