using Gymbokning.Validations;
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

        [Required(ErrorMessage = "Please enter name!")]
        [MinLength(2, ErrorMessage = "Minimum length: 2 character!")]
        [MaxLength(40, ErrorMessage = "Maximum length: 40 character!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description!")]
        [MinLength(5, ErrorMessage = "Minimum length: 5 character!")]
        [MaxLength(800, ErrorMessage = "Maximum length: 800 character!")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Please enter start time!")]
        [Display(Name = "Start time")]
        [StartTimeCheck]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm}")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please enter length of the gymclass!")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59 in HH:MM format.")]
        //Range(typeof(TimeSpan), "00:00", "01:59")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Duration { get; set; }



        public DateTime EndTime { get { return StartTime + Duration; } }

        //Navigation
        public ICollection<ApplicationUserGymClass> AttendingMembers { get; set; }

   
    }
}
