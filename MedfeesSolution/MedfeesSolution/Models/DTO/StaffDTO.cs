﻿namespace MedfeesSolution.Models.DTO
{
    public class StaffDTO
    {
    }
    public class CreateStaff
    {

        public int? Hospitaltenantid { get; set; }       
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobilenumeber { get; set; }
        public string Education { get; set; }
        public string Emailid { get; set; }
        public string Gender { get; set; }
        public string Licenseno { get; set; }
        public DateTime Licenseexpirydate { get; set; }
        public int? Emergencycontactno { get; set; }
        public int? Aadharno { get; set; }
        public string Pancardno { get; set; }
        public int? City { get; set; }
        public int? State { get; set; }
        public int? Pincode { get; set; }
        public int? Country { get; set; }
        public DateTime? Joiningdate { get; set; }
        public int? Roleid { get; set; }
        public bool? Isactive { get; set; }
        //public string Uploadimage { get; set; }
    }
}
