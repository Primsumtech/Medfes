using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class HospitalRepository : HospitalInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public HospitalRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public async Task<bool> CreateHospital(HospitalDTO hospitalDTO)
        {  
            try
            {
               
                    Hospitaltenant hospitaltenant = new Hospitaltenant();
                    hospitaltenant.Hospitalname = hospitalDTO.hospitalname;
                    hospitaltenant.Hospitaluniqueid = hospitalDTO.hospitalname.Substring(0, 4).Trim() + DateTime.Now.ToString("yyyymmdd");
                    hospitaltenant.Stateid = hospitalDTO.stateid;
                    hospitaltenant.Countryid = hospitalDTO.countryid;
                    hospitaltenant.Countrycode = "+91";
                    _context.Hospitaltenants.Add(hospitaltenant);
                    await _context.SaveChangesAsync();

                    Hospitallocation hospitallocation = new Hospitallocation();
                    hospitallocation.Cityid = hospitalDTO.cityid;
                    hospitallocation.Address = hospitalDTO.address;
                    hospitallocation.Address1 = hospitalDTO.address1;
                    hospitallocation.Phonenumber = hospitalDTO.phonenumber;
                    hospitallocation.Hospitaltenantid = hospitaltenant.Hospitaltenantid;
                    hospitallocation.Hospitallocation1 = hospitalDTO.hospitallocation;
                    hospitallocation.Hospitaluniqueid = hospitaltenant.Hospitaluniqueid;
                    _context.Hospitallocations.Add(hospitallocation);
                    await _context.SaveChangesAsync();
                
                
                return true;
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "hospital tenant";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw ex;

            }
            

        }

        public async Task<bool> EditHospital(EditHospitalDTO edithospitalDTO)
        {
            try
            {
                    Hospitaltenant hospitaltenant = new Hospitaltenant();
                    hospitaltenant.Stateid = edithospitalDTO.stateid;
                    hospitaltenant.Countryid = edithospitalDTO.countryid;
                    hospitaltenant.Modifiedon=DateTime.Now;
                    _context.Hospitaltenants.Update(hospitaltenant);
                    await _context.SaveChangesAsync();
                
                for (int i = 0; i < edithospitalDTO.hospitallocationdto.Count; i++)
                {

                    Hospitallocation hospitallocation = new Hospitallocation();
                    hospitallocation.Cityid = edithospitalDTO.hospitallocationdto[i].cityid;
                    hospitallocation.Address = edithospitalDTO.hospitallocationdto[i].address;
                    hospitallocation.Address1 = edithospitalDTO.hospitallocationdto[i].address1;
                    hospitallocation.Phonenumber = edithospitalDTO.hospitallocationdto[i].phonenumber;
                    hospitallocation.Hospitaltenantid = edithospitalDTO.hospitallocationdto[i].hospitaltenantid;
                    hospitallocation.Hospitallocation1 = edithospitalDTO.hospitallocationdto[i].hospitallocation;
                    //hospitallocation.Hospitaluniqueid = edithospitalDTO.hospitallocationdto[i].Hospitaluniqueid;
                   hospitallocation.Modifiedon = DateTime.Now;
                    _context.Hospitallocations.Update(hospitallocation);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                elog.Errormethodname = "hospital tenant and location edit";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw ex;

            }


        }


        public async Task<bool> DeleteHospital(int hospitaltenantid)
        {
            try
            {
                var hospitaltenant = _context.Hospitaltenants.Where(h => h.Hospitaltenantid==hospitaltenantid).FirstOrDefault();
                hospitaltenant.Isactive = false;
                hospitaltenant.Modifiedon = DateTime.Now;
                _context.Hospitaltenants.Update(hospitaltenant);
                await _context.SaveChangesAsync();

              
                return true;
            }
            catch (Exception ex)
            {
                elog.Errormethodname = "hospital tenant delete";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw ex;

            }


        }

    }
}
