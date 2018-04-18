using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Interface
{
    public interface IErrorLogRepository
    {
        void Create(ErrorLog errorLog);
    }
}
