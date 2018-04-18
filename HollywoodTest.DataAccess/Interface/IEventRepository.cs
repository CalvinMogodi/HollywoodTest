using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Interface
{
    public interface IEventRepository
    {
        int Create(Event _event);
        bool Update(Event _event);
        List<prtbEvent_GetByTournamentID_Result> GetByTournamentID(long tournamentID);
        bool Delete(long eventID);
    }
}
