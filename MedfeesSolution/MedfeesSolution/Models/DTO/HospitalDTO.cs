namespace MedfeesSolution.Models.DTO
{
    public class HospitalDTO
    {
       
        public string? hospitalname { get; set; }
        public int? stateid { get; set; }
        public int? countryid { get; set; }
        public string hospitallocation { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public int? cityid { get; set; }

        public string logoname { get; set; }
        public string hospitallogo { get; set; }


    }

    public class EditHospitalDTO
    {
        public int hospitaltenantid { get; set; }

        public string hospitalname { get; set; }
        public int? stateid { get; set; }
        public int? countryid { get; set; }

        public List<HospitalLocationDTO> hospitallocationdto {get;set;}
    }

    public class HospitalLocationDTO
    {
        public int hospitallocationid { get;set; }
        public int hospitaltenantid { get; set; }
        public string hospitallocation { get; set; }

        public string phonenumber { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public int cityid { get; set; }

    }
}
