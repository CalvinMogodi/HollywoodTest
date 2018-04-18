using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace HollywoodTest.UI.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        public bool IsAuthorized { get; set; }
        public bool IsAdministrator { get; set; }
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
            //Log.Error(filterContext.Exception.Message, filterContext.Exception);
            base.OnException(filterContext);
        }

    }
}