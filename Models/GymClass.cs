using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime EndTime { get { return StartTime + Duration; } }

        public String Description { get; set; }

        public ICollection<ApplicationUserGymClass> AttendingMembers { get; set; }

   
    }
}
