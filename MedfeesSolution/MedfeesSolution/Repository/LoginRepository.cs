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
        Errorlog elog=new Errorlog();
        public ErrorLogRepository _er;
        public LoginRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }


        public  LoginResponse LoginUser(Login login)
        {

            try
            {
                var user =  _context.Users.SingleOrDefault(user=>user.Email== login.userid);
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
                 var pri=_context.Privileges.Where(x=>x.Roleid==role.Roleid).ToList();

                List<AcccessPages> aplist=new List<AcccessPages>();
                foreach (var p in pri)
                {
                    var pg=_context.Pages.Where(x=>x.Pageid==p.Pageid);
                    AcccessPages ap=new AcccessPages();
                    ap.pageid=pg.Select(x=>x.Pageid).FirstOrDefault();
                    ap.pagename=pg.Select(y=>y.Pagename).FirstOrDefault();
                    PagePriviliges pagePriviliges=new PagePriviliges();
                    pagePriviliges.view = p.Pview;
                    pagePriviliges.create = p.Pcreate;
                    pagePriviliges.update = p.Pedit;
                    pagePriviliges.delete = p.Pdelete;
                    ap.pagepriviliges.Add(pagePriviliges);
                    aplist.Add(ap);
                }

                 LoginResponse response =new LoginResponse();
                response.userid = user.Userid;
                response.username = user.Firstname + " " + user.Middlename + " " + user.Lastname;
                response.email = user.Email;
                response.roleid = user.Roleid;
                response.rolename = role.Rolename;
                response.acccesspages = aplist;
                return (response); 

            }
            catch (Exception ex)
            {
                elog.Errormethodname = "LoginUser";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw ex;
                
            }

        }

    }
}
