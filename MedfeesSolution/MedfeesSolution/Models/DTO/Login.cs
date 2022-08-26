namespace MedfeesSolution.Models.DTO
{
    public class Login
    {
        public string userid { get; set; }
        public string password { get; set; }
    }

    public class LoginResponse
    {
        public int? userid { get; set; }
        public int? roleid { get; set; }
        public string? rolename { get; set; }

        public string? username { get; set; }
        public string? email { get; set; }

        public List<AcccessPages> acccesspages { get; set; }
       
    }

    public class AcccessPages
    {
        public int pageid { get; set;}
        public string pagename { get; set; }
        public List<PagePriviliges> pagepriviliges { get; set; }

        public AcccessPages()
        {
            pagepriviliges = new List<PagePriviliges>();

        }
    }

    public class PagePriviliges
    {
        public bool? view { get; set; }
        public bool? create { get; set; }
        public bool? update { get; set; }
        public bool? delete { get; set; }

      

    }


}
