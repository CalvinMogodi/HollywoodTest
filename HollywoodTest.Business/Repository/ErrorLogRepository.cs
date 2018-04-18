using HollywoodTest.Business.Interface;
using HollywoodTest.DataAccess;
using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Business.Repository
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        #region Properties
        private readonly DataAccess.Interface.IErrorLogRepository _dataAccessErrorLogRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the event detail repository class.
        /// </summary>
        /// <param name="db">The database.</param>
        public ErrorLogRepository()
        {
            HollywoodTestEntities hollywoodTestEntities = new HollywoodTestEntities();
            _dataAccessErrorLogRepository = new DataAccess.Repository.ErrorLogRepository(hollywoodTestEntities);
        }

        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorLog"></param>
        public void Log(ErrorLog errorLog)
        {
            _dataAccessErrorLogRepository.Create(errorLog);
        }
        #endregion
    }
}
