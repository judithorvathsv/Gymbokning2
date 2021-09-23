using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required(ErrorMessage = "The Password is required! Minimum length: 5, should contain uppercase and digit. ")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long. ", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter firstname!")]
        [MinLength(2, ErrorMessage = "Minimum length: 2 character!")]
        [MaxLength(40, ErrorMessage = "Maximum length: 40 character!")]
        [RegularExpression("[-a-zA-Z. ]+", ErrorMessage = "Invalid firstname!")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter lastname!")]
        [MinLength(2, ErrorMessage = "Minimum length: 2 character!")]
        [MaxLength(40, ErrorMessage = "Maximum length: 40 character!")]
        [RegularExpression("[-a-zA-Z. ]+", ErrorMessage = "Invalid lastname!")]
        [Display(Name = "Lastname")] 
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " +LastName; } }

        public DateTime StartTime { get; set; }

        public DateTime TimeOfRegistration { get; set; }

        //navigation
        public ICollection<ApplicationUserGymClass> AttendedClasses { get; set; }


    }
}
