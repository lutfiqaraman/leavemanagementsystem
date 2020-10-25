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
            if (id == 0)
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
        public ActionResult AddEditLeaveType(LeaveType model)
        {
            model.DateCreated = DateTime.Now;
            Repo.Create(model);

            if (!ModelState.IsValid)
                return PartialView("_AddEditLeaveType", model);

            return RedirectToAction("Index");
        }
    }
}
