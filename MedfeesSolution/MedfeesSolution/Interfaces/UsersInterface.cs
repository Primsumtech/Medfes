using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;

namespace MedfeesSolution.Interfaces
{
    public interface UsersInterface
    {
        List<User> GetUsers();

        Task<bool> CreateUser(CreateEditUserDTO createEditUserDTO);
    }
}
