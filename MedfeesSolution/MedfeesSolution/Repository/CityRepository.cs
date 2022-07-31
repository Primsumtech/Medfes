using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class CityRepository : CityInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public CityRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public List<City> GetAllCities()
        {  
            try
            {
                var cities = _context.Cities.ToList();
                return cities.ToList();
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "city";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

            }
            return null;

        }


        public List<City> GetCitybyState(int stateid)
        {
            try
            {
                var cities = _context.Cities.Where(x=>x.Stateid==stateid);
                return cities.ToList();
            }
            catch (Exception ex)
            {
                elog.Errormethodname = "State";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

            }
            return null;

        }


    }
}
