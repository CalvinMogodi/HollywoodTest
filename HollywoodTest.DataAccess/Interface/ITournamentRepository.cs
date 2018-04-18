using HollywoodTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.DataAccess.Interface
{
    public interface ITournamentRepository
    {
        int Create(Tournament tournament);
        bool Update(Tournament tournament);
        List<prtbTournament_GetAll_Result> GetAll();
        bool Delete(long eventID);
    }
}
