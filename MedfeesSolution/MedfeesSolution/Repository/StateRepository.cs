using MedfeesSolution.Interfaces;
using MedfeesSolution.Models;
using MedfeesSolution.Models.DTO;
using MedfeesSolution.Hashing;
using AutoMapper;
namespace MedfeesSolution.Repository
{
    public class StateRepository: StateInterface
    {
        private readonly medfesContext _context;
        private readonly IMapper _mapper;
        Errorlog elog = new Errorlog();
        public ErrorLogRepository _er;


        public StateRepository(medfesContext context, IMapper mapper, ErrorLogRepository er)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _er = er;
        }
        public List<State> GetAllStates()
        {  
            try
            {
                var states = _context.States.ToList();
                return states.ToList();
            }
            catch(Exception ex)
            {
                elog.Errormethodname = "State";
                elog.Creadteddate = System.DateTime.Now;
                elog.Errormessage = ex.Message;
                _er.ErrorLogSave(elog);

            }
            return null;

        }


        public List<State> GetStatebyCountry(int countryid)
        {
            try
            {
                var states = _context.States.Where(x=>x.Countryid==countryid);
                return  states.ToList();
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
