using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using leavemanagementsystem.Data.Entities;
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
            DbContext.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            DbContext.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> GetAll()
        {
            List<LeaveType> leaveTypes = DbContext.LeaveTypes.ToList();
            return leaveTypes;
        }

        public LeaveType GetById(int id)
        {
            LeaveType leaveType = DbContext.LeaveTypes.Find(id);
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int leaveTypeId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            int numberOfRecordsChanged = DbContext.SaveChanges();
            return numberOfRecordsChanged > 0;
        }

        public bool Update(LeaveType entity)
        {
            DbContext.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
