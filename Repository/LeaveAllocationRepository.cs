using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using leavemanagementsystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        public ApplicationDbContext DbContext { get; private set; }

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public bool Create(Data.Entities.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Add(entity);
            return Save();
        }

        public void Delete(Data.Entities.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Remove(entity);
            DbContext.SaveChanges();
        }

        public ICollection<Data.Entities.LeaveAllocation> GetAll()
        {
            List<LeaveAllocation> leaveAllocations = DbContext.LeaveAllocations.ToList();
            return leaveAllocations;
        }

        public Data.Entities.LeaveAllocation GetById(int id)
        {
            LeaveAllocation leaveAllocation = DbContext.LeaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool Save()
        {
            int numberOfRecordsChanged = DbContext.SaveChanges();
            return numberOfRecordsChanged > 0;
        }

        public bool Update(Data.Entities.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
