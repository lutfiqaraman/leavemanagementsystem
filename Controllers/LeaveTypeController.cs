using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data.Entities;
using leavemanagementsystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace leavemanagementsystem.Controllers
{
    public class LeaveTypeController : Controller
    {
        public ILeaveTypeRepository Repo { get; private set; }
        public IMapper Mapper { get; private set; }
        

        public LeaveTypeController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            Repo = leaveTypeRepository;
            Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetLeaveTypes()
        {
            List<LeaveType> leaveTypes = Repo.GetAll().ToList();
            List<DetailsLeaveTypeViewModel> model =
                Mapper.Map<List<LeaveType>, List<DetailsLeaveTypeViewModel>>(leaveTypes);

            return Json(model);
        }

        [HttpGet]
        public IActionResult AddEditLeaveType(int id = 0)
        {
            return View(new LeaveType());
        }

        [HttpPost]
        public IActionResult AddEditLeaveType()
        {
            return View()
        }
    }
}
