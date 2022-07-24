using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class UsersRepository: UsersInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(medfesContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

        public async Task<bool> CreateUser(CreateEditUserDTO createEditUserDTO)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(createEditUserDTO.password, out passwordHash, out passwordSalt);

            User userData = _mapper.Map<User>(createEditUserDTO);
            userData.Passwordhash = passwordHash;
            userData.Passwordsalt = passwordSalt;
            _context.Users.Add(userData);
            await _context.SaveChangesAsync();
            if (userData.Userid > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }
        
    }
}
