using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class CountryRepository: CountryInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public CountryRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public List<Country> GetAllCountries()
        {  
            try
            {
                var countries = _context.Countries.ToList();
                return countries.ToList();
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "Country";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

            }
            return null;

        }

        
    }
}
