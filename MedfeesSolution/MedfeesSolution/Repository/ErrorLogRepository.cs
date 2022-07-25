using MedfeesSolution.Models;
namespace MedfeesSolution.Repository
{
    public class ErrorLogRepository
    {


        private readonly medfesContext _context;

        public ErrorLogRepository(medfesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
          
        }

        /// <summary>
        /// Method for saving error log details
        /// </summary>
        /// <param name="elog"></param>
        public void ErrorLogSave(Errorlog elog)
        {
            _context.Errorlogs.Add(elog);
            _context.SaveChanges();
        }
    }

   
}
