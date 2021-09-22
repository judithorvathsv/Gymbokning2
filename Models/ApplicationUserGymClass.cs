using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gymbokning.Models
{
    public class ApplicationUserGymClass
    {
        //Navigations
        public int GymClassId { get; set; }
        public virtual GymClass GymClass { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
