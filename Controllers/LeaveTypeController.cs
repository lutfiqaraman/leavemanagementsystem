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

        public ActionResult Index()
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

        public ActionResult AddEditLeaveType(int? id)
        {
            LeaveType model = new LeaveType();
            return PartialView("_AddEditLeaveType", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddEditLeaveType(LeaveType model)
        {
            if (!ModelState.IsValid)
                return PartialView("_AddEditLeaveType", model);

            return RedirectToAction("Index");
        }
    }
}
