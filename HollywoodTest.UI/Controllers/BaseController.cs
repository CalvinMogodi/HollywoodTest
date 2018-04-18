using HollywoodTest.Shared.Models;
using HollywoodTest.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HollywoodTest.Shared.Enums;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        private ErrorService errorService = new ErrorService();

        protected void ShowResult(ResultCode ResultCode, string title,string message)
        {
            this.TempData["ToastrTitle"] = title;
            switch (ResultCode)
            {
                case ResultCode.Success:
                    this.TempData["ToastrSuccess"] = message;
                    break;
                case ResultCode.Warning :
                    this.TempData["ToastrWarning"] = message;
                    break;
                case ResultCode.Error:
                    this.TempData["ToastrError"] = message;
                    break;
                case ResultCode.Info:
                default:
                    this.TempData["ToastrInfo"] = message;
                    break;
            }
        }

        /// <summary>
        ///     Log exception to database and redirect user to error view 
        /// </summary>
        /// <param name="exceptionContext">
        ///     The exception context.
        /// </param>
        /// <returns>
        ///     Error View
        /// </returns>
        protected override void OnException(ExceptionContext filterContext)
        {
            ErrorLog errorLog = new ErrorLog() {
                ErrorMessage = filterContext.Exception.Message,
                Source = filterContext.Exception.Source,
                Date = DateTime.Now
            };
            errorService.Log(errorLog);
            base.OnException(filterContext);
        }

    }
}