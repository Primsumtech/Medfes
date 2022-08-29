using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MedfeesSolution.BusinessProcess.Patient;
using MedfeesSolution.Dtos.Patient;
using MedfeesSolution.Repository;
using MedfeesSolution.Models;

namespace MedfeesSolution.Controllers.Patient
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientBP _patientBP;
        public ErrorLogRepository _errorLogRepository;
        Errorlog errorLog = new Errorlog();

        public PatientController(ErrorLogRepository errorLogRepository, IPatientBP patientBP)
        {
            _errorLogRepository = errorLogRepository;
            _patientBP = patientBP;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddPatient([FromBody] AddEditPatinetRequestDto parameters)
        {
            try
            {
                if (parameters == null)
                {
                    return new BadRequestResult();
                }
                Models.Patient result = await _patientBP.AddPatient(parameters);
                return Ok(result);
            }
            catch (Exception exception)
            {
                errorLog.Errormethodname = "AddPatient";
                errorLog.Creadteddate = DateTime.Now;
                errorLog.Errormessage = exception.Message;
               _errorLogRepository.ErrorLogSave(errorLog);
                throw;
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetPatients()
        {

            try
            {
                List<Models.Patient> result = await _patientBP.GetPatients();
                return Ok(result);
            }
            catch (Exception exception)
            {
                errorLog.Errormethodname = "GetPatients";
                errorLog.Creadteddate = DateTime.Now;
                errorLog.Errormessage = exception.Message;
                _errorLogRepository.ErrorLogSave(errorLog);
                throw;
            }
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetPatientById([FromQuery] BasePatient parameters)
        {
            try
            {
                PatinetResultDto result = await _patientBP.GetPatientById(parameters.PatientId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                errorLog.Errormethodname = "GetPatientById";
                errorLog.Creadteddate = DateTime.Now;
                errorLog.Errormessage = exception.Message;
                _errorLogRepository.ErrorLogSave(errorLog);
                throw;
            }
        }

        [HttpPut("update")]

        public async Task<IActionResult> UpdatePatient([FromBody] AddEditPatinetRequestDto parameters)
        {

            try
            {
                if (parameters == null)
                {
                    return new BadRequestResult();
                }

                PatinetResultDto result = await _patientBP.UpdatePatient(parameters);

                return Ok(result);
            }
            catch (Exception exception)
            {
                errorLog.Errormethodname = "UpdatePatient";
                errorLog.Creadteddate = DateTime.Now;
                errorLog.Errormessage = exception.Message;
                _errorLogRepository.ErrorLogSave(errorLog);
                throw;
            }

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeletePatientById([FromQuery] BasePatient parameters)
        {
            try
            {
                await _patientBP.DeletePatientById(parameters.PatientId);
                return Ok();
            }
            catch (Exception exception)
            {
                errorLog.Errormethodname = "DeletePatientById";
                errorLog.Creadteddate = DateTime.Now;
                errorLog.Errormessage = exception.Message;
                _errorLogRepository.ErrorLogSave(errorLog);
                throw;
            }
        }
    }
}
