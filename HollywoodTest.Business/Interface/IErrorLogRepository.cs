using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Business.Interface
{
    public interface IErrorLogRepository
    {
        void Log(ErrorLog errorLog);
    }
}
