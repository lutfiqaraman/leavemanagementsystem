using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data.Entities;
using leavemanagementsystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace leavemanagementsystem.Controllers
{
    [Authorize(Roles = "Administrator")]
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
            if (id == 0)
            {
                LeaveType model = new LeaveType();
                return PartialView("_AddEditLeaveType", model);
            } else
            {
                LeaveType model = Repo.GetById(id);
                return PartialView("_AddEditLeaveType", model);
            }
            
        }

        [HttpPost]
        public ActionResult AddEditLeaveType(LeaveType leaveType)
        {
            LeaveType model = leaveType;

            // Create a leave type
            if (model.Id == 0)
            {
                Repo.Create(leaveType);

                if (!ModelState.IsValid)
                    return PartialView("_AddEditLeaveType", model);
            }
            
            // Edit a leave type
            if (model.Id != 0)
            {
                Repo.Update(model);

                if (!ModelState.IsValid)    
                    return PartialView("_AddEditLeaveType", model);
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult DeleteLeaveType(int id)
        {
            LeaveType leaveType = Repo.GetById(id);
            Repo.Delete(leaveType);

            return Json(new
            {
                success = true
            });
        }
    }
}
