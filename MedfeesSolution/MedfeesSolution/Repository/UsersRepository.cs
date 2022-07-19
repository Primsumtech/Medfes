using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
namespace MedfeesSolution.Repository
{
    public class UsersRepository: UsersInterface
    {
        private readonly medfesContext _context;

        public UsersRepository(medfesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<User> GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                return users.ToList();
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }
    }
}
