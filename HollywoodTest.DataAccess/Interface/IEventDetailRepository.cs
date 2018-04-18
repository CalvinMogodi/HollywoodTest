using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Interface
{
    public interface IEventDetailRepository
    {
        int Create(EventDetail eventDetail);
        bool Update(EventDetail eventDetail);
        List<prtbEventDetail_GetByEventID_Result> GetByEventID(long eventID);
        bool Delete(long eventDetailID);
    }
}
