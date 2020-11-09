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
            List<DetailsLeaveTypeViewModel> listLeaveTypes = GetLeaveTypes();
            return Json(listLeaveTypes);
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
        public ActionResult AddEditLeaveType(int? id)
        {
            if ( id == 0  || String.IsNullOrEmpty(id.ToString()) )
            {
                LeaveType model = new LeaveType();
                return PartialView("_AddEditLeaveType", model);
            }
            else
            {
                var model = Repo.GetById((int)id);
                return PartialView("_AddEditLeaveType", model);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddEditLeaveType(LeaveType leaveType)
        {
            if (leaveType.Id == 0)
            {
                leaveType.DateCreated = DateTime.Now;
                Repo.Create(leaveType);

                if (!ModelState.IsValid)
                    return PartialView("_AddEditLeaveType", leaveType);

            } else
            {
                if (!ModelState.IsValid)
                {
                    Repo.Update(leaveType);
                    return PartialView("_AddEditLeaveType", leaveType);
                }
                
            }

            return RedirectToAction("Index");
        }
    }
}
