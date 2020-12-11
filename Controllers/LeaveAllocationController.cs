using AutoMapper;
using leavemanagementsystem.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        public ILeaveTypeRepository LeaveTypeRepo { get; private set; }
        public ILeaveAllocationRepository LeaveAllocationRepo { get; private set; }
        public IMapper Mapper { get; private set; }

        public LeaveAllocationController(
            IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepo, 
            ILeaveAllocationRepository leaveAllocationRepo)
        {
            Mapper = mapper;
            LeaveTypeRepo = leaveTypeRepo;
            LeaveAllocationRepo = leaveAllocationRepo;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
