using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface LoginInterface
    {
       

        LoginResponse LoginUser(Login login);
    }
}
