using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Data.Entities
{
    public class LeaveType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 25, ErrorMessage = "Please days should be between 1 and 25")]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }

        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
