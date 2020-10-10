﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Models
{
    public class LeaveAllocationViewModel
    {
        public int Id { get; set; }

        [Required]
        public int NumberOfDays { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public EmployeeViewModal Employee { get; set; }
        
        public string EmployeeId { get; set; }

        public DetailsLeaveTypeViewModel LeaveType { get; set; }
        
        public int LeaveTypeId { get; set; }
        
        public IEnumerable<SelectListItem> Employees { get; set; }
        
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}
