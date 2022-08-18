using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class StaffRepository : StaffInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public StaffRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public List<staff> GetStaff()
        {  
            try
            {
                var staff = _context.staff.ToList();
                return staff.ToList();
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "staff";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

                throw;
            }
           
        }

        public async Task<bool> CreateStaff(CreateStaff createStaff)
        {
            try {

                var random = new Random();
                int randomnumber = random.Next();
                string   suniqueid = char.ToUpper(createStaff.Firstname[0]).ToString()+char.ToUpper(createStaff.Lastname[0]).ToString()+ randomnumber;

                //byte[] bytes = System.Convert.FromBase64String(createStaff.Uploadimage);

                staff staffData = _mapper.Map<staff>(createStaff);
                staffData.Staffuniqueid=suniqueid;
               // staffData.Uploadimage = bytes;
                _context.staff.Add(staffData);
                await _context.SaveChangesAsync();
                if (staffData.Staffid > 0)
                {
                    return true;
                }


            }
            catch(Exception ex) 
            {
                elog.Errormethodname = "create staff";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw;
            }
            return false;
           
           
           
        }
        
    }
}
