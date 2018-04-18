using HollywoodTest.DataAccess.Interface;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Repository
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        #region Properties
        private readonly HollywoodTestEntities _db;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public ErrorLogRepository(HollywoodTestEntities db)
        {
            _db = db;
        }

        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorLog"></param>
        public void Create(ErrorLog errorLog)
        {
            _db.prtbErrorLog_Insert(errorLog.ErrorMessage, errorLog.Source, errorLog.Date);
        }
        #endregion
    }
}
