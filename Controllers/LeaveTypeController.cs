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
            LeaveType model = Repo.GetById(id);

            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LeaveType, DetailsLeaveTypeViewModel>();
            });

            DetailsLeaveTypeViewModel detailsLeaveTypeViewModel = 
                config.CreateMapper().Map<DetailsLeaveTypeViewModel>(model);

            if (id == 0)
                return PartialView("_AddEditLeaveType", detailsLeaveTypeViewModel);
            else
                return PartialView("_AddEditLeaveType", detailsLeaveTypeViewModel);

        }

        [HttpPost]
        public ActionResult AddEditLeaveType(DetailsLeaveTypeViewModel leaveTypeViewModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DetailsLeaveTypeViewModel, LeaveType>();
            });

            LeaveType leaveType = config.CreateMapper().Map<LeaveType>(leaveTypeViewModel);

            // Create OR Edit a leave type
            if (leaveType.Id == 0)
            {
                Repo.Create(leaveType);

                if (!ModelState.IsValid)
                    return PartialView("_AddEditLeaveType", leaveTypeViewModel);
            } else 
            {
                Repo.Update(leaveType);

                if (!ModelState.IsValid)
                    return PartialView("_AddEditLeaveType", leaveTypeViewModel);
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
