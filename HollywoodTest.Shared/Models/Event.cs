using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Shared.Models
{
    public class Event
    {
        public long EventID { get; set; }
        [Required]
        public long TournamentID { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public short EventNumber { get; set; }
        [Required]
        public DateTime EventDateTime { get; set; }
        [Required]
        public DateTime EventEndDateTime { get; set; }
        [Required]
        public bool AutoClose { get; set; }
        public Tournament Tournament { get; set; }
        public List<EventDetail> EventDetails { get; set; }
    }
}
