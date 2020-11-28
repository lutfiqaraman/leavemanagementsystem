using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Models
{
    public class DetailsLeaveTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Please days should be between 1 and 25")]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
