﻿using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class LoginRepository : LoginInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;

        public LoginRepository(medfesContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public  LoginResponse LoginUser(Login login)
        {

            try
            {
                var user =  _context.Users.SingleOrDefault(user=>user.Email== login.loginemail);
                if (user == null)
                {
                    return null;
                }
                if (!HashingHelper.VerifyPasswordHash(login.password, user.Passwordhash, user.Passwordsalt))
                {
                    return null;
                }
                int roleid = user.Roleid.Value;
                var role = _context.Roles.SingleOrDefault(x => x.Roleid == roleid);
                 

                 LoginResponse response =new LoginResponse();
                response.userid = user.Userid;
                response.username = user.Firstname + " " + user.Middlename + " " + user.Lastname;
                response.email = user.Email;
                response.roleid = user.Roleid;
                response.rolename = role.Rolename;
               return (response); 

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}