using AutoMapper;
using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data.Entities;
using leavemanagementsystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace leavemanagementsystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        public ILeaveTypeRepository LeaveTypeRepo { get; private set; }
        public ILeaveAllocationRepository LeaveAllocationRepo { get; private set; }
        public IMapper Mapper { get; private set; }

        public LeaveAllocationController(IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepo, 
            ILeaveAllocationRepository leaveAllocationRepo)
        {
            Mapper = mapper;
            LeaveTypeRepo = leaveTypeRepo;
            LeaveAllocationRepo = leaveAllocationRepo;
        }
        
        public ActionResult Index()
        {
            List<LeaveAllocationViewModel> listLeaveAllocations = MappingLeaveAllocations();
            return View(listLeaveAllocations);
        }

        public JsonResult GetLeaveAllocation()
        {
            List<LeaveAllocationViewModel> leaveAllocation = MappingLeaveAllocations();
               
            JsonResult result = Json(new
            {
                data = leaveAllocation
            });

            return result;
        }

        public List<LeaveAllocationViewModel> MappingLeaveAllocations()
        {
            List<LeaveAllocation> leaveAllocation = LeaveAllocationRepo.GetAll().ToList();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveAllocation, LeaveAllocationViewModel>();
            });

            Mapper = config.CreateMapper();

            List<LeaveAllocationViewModel> leaveAllocationViewModels =
                Mapper.Map<List<LeaveAllocation>, List<LeaveAllocationViewModel>>(leaveAllocation);

            return leaveAllocationViewModels;
        }
    }
}
