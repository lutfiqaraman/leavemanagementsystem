using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
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
            List<DetailsLeaveTypeViewModel> listLeaveTypes = GetLeaveTypes();
            return View(listLeaveTypes);
        }

        public JsonResult GetLeaveType()
        {
            List<DetailsLeaveTypeViewModel> leaveTypes = GetLeaveTypes();

            JsonResult result = Json(new
            {
                data = leaveTypes
            });

            return result;
        }

        public List<DetailsLeaveTypeViewModel> GetLeaveTypes()
        {
            List<LeaveType> leaveTypes = Repo.GetAll().ToList();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveType, DetailsLeaveTypeViewModel>();
            });

            Mapper = config.CreateMapper();

            List<DetailsLeaveTypeViewModel> detailsLeaveTypeViewModels =
                Mapper.Map<List<LeaveType>, List<DetailsLeaveTypeViewModel>>(leaveTypes);

            return detailsLeaveTypeViewModels;
        }

        [HttpGet]
        public ActionResult AddEditLeaveType(int id = 0)
        {
            var model = new LeaveType();
            return PartialView("_AddEditLeaveType", model);
        }

        [HttpPost]
        public ActionResult AddEditLeaveType(LeaveType leaveType)
        {
            LeaveType model = leaveType;

            if (model.Id == 0)
            {
                Repo.Create(leaveType);

                if (!ModelState.IsValid)
                    return PartialView("_AddEditLeaveType", model);

            } else 
            {
                if (!ModelState.IsValid)
                {
                    Repo.Update(model);
                    return PartialView("_AddEditLeaveType", model);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
