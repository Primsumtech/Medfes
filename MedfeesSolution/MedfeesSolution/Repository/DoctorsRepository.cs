using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class DoctorsRepository : DoctorsInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public DoctorsRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public List<Doctor> GetDoctors()
        {  
            try
            {
                var doctors = _context.Doctors.ToList();
                return doctors.ToList();
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "doctors";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

                throw;
            }
           
        }

        public async Task<bool> CreateDoctor(CreateDoctor createDoctor)
        {
            try {

                var random = new Random();
                int randomnumber = random.Next();
                string   suniqueid = char.ToUpper(createDoctor.Firstname[0]).ToString()+char.ToUpper(createDoctor.Lastname[0]).ToString()+ randomnumber;

                //byte[] bytes = System.Convert.FromBase64String(createStaff.Uploadimage);

                Doctor doctorData = _mapper.Map<Doctor>(createDoctor);
                doctorData.Doctoruniqueid=suniqueid;
                // doctorData.Uploadimage = bytes;
                _context.Doctors.Add(doctorData);
                await _context.SaveChangesAsync();
                if (doctorData.Doctorid > 0)
                {
                    return true;
                }


            }
            catch(Exception ex) 
            {
                elog.Errormethodname = "create doctor";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
                throw;
            }
            return false;
           
           
           
        }


        public async Task<bool> EditDoctor(EditDoctor editDcotor)
        {
            try
            {

                var dr = _context.Doctors.Where(x => x.Doctorid==editDcotor.Doctorid).FirstOrDefault();
                dr.Pincode = editDcotor.Pincode;
                dr.Licenseexpirydate = editDcotor.Licenseexpirydate;
                dr.Hospitaltenantid= editDcotor.Hospitaltenantid;
                dr.Gender = editDcotor.Gender;
                dr.Emailid = editDcotor.Emailid;
                dr.Emergencycontactno = editDcotor.Emergencycontactno;
                dr.Education= editDcotor.Education;
                dr.City = editDcotor.City;
                dr.Aadharno = editDcotor.Aadharno;
                dr.Country = editDcotor.Country;
                dr.Firstname = editDcotor.Firstname;
                dr.Lastname = editDcotor.Lastname;
                dr.Licenseno = editDcotor.Licenseno;
                dr.Pancardno = editDcotor.Pancardno;
                dr.Docdesigid = editDcotor.Docdesigid;
                dr.Modifiedon = DateTime.Now;
               
                _context.Doctors.Update(dr);
                await _context.SaveChangesAsync();
              

            }
            catch (Exception ex)
            {
                elog.Errormethodname = "edit docotr";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);
               // throw;
                return false;
            }
            return true;

        }

        public async Task<bool> DeleteDoctor(int doctorid)
        {
            try
            {

                var dr = _context.Doctors.Where(x => x.Doctorid == doctorid).FirstOrDefault();
                dr.Isactive = false;
                dr.Modifiedon = DateTime.Now;
                _context.Doctors.Update(dr);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                elog.Errormethodname = "delete doctor";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);               
                return false;
            }
            return true;



        }


    }
}
