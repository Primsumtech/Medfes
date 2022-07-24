namespace MedfeesSolution.Models.DTO
{
    public class Login
    {
        public string? loginemail { get; set; }
        public string? password { get; set; }
    }

    public class LoginResponse
    {
        public int? userid { get; set; }
        public int? roleid { get; set; }
        public string? rolename { get; set; }

        public string? username { get; set; }
        public string? email { get; set; }
       
    }

}
