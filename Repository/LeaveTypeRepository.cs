using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using leavemanagementsystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public ApplicationDbContext DbContext { get; private set; }

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public bool Create(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetAll()
        {
            throw new NotImplementedException();
        }

        public LeaveType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int leaveTypeId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            throw new NotImplementedException();
        }
    }
}
