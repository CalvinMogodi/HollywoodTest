using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Shared.Models
{
    public class Tournament
    {
        public long TournamentID { get; set; }
        [Required]
        public string TournamentName { get; set; }
        public List<Event> Events { get; set; }
    }
}
