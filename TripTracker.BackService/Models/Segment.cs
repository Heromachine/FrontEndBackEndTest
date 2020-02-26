using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TripTracker.BackService.Models
{
    public class Segment
    {
        public int Id { get; set;  }

        [Required]
        public int TripID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset StartDateTime { get; set; }

        [Required]
        public DateTimeOffset EndDateTime { get; set; }
        
    }
}
