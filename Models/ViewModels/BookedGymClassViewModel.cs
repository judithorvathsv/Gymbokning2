using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Models.ViewModels
{
    public class BookedGymClassViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string Description { get; set; }

        [Display(Name = "Booked")]
        public bool ApplicationUserGymClassIsBooked { get; set; }

    }
}
