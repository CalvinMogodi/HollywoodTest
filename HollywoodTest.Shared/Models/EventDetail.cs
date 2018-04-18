using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodTest.Shared.Models
{
    public class EventDetail
    {
        public long EventDetailID { get; set; }
        [Required]
        public long EventID { get; set; }
        [Required]
        public long EventDetailStatusID { get; set; }
        [Required]
        public string EventDetailName { get; set; }
        [Required]
        public short EventDetailNumber { get; set; }
        [Required]
        public decimal EventDetailsOdd { get; set; }
        [Required]
        public short FinishingPosition { get; set; }
        [Required]
        public bool FirstTimer { get; set; }
        public Event Event { get; set; }
    }
}
