using HollywoodTest.Business.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HollywoodTest.API.Controllers
{
    public class ErrorLogController : ApiController
    {
        #region Properties
        private readonly IErrorLogRepository errorLogRepository;
        #endregion

        #region Constructor
        public ErrorLogController(IErrorLogRepository errorLogRepository)
        {
            this.errorLogRepository = errorLogRepository;
        }

        #endregion

        #region Action Methods

        // POST: api/ErrorLog
        [HttpPost]
        public void Log(ErrorLog errorLog)
        {
            errorLogRepository.Log(errorLog);
        }

        #endregion
    }
}
