using AutoMapper;
using leavemanagementsystem.Data.Entities;
using leavemanagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Mapping
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<LeaveType, DetailsLeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeViewModel>().ReverseMap();

            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();

            CreateMap<LeaveHistory, LeaveHistoryViewModel>().ReverseMap();

            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
