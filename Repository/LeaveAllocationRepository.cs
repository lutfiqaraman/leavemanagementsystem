using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using leavemanagementsystem.Data.Models;
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

        public bool Create(Data.Models.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Delete(Data.Models.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Remove(entity);
            return Save();
        }

        public ICollection<Data.Models.LeaveAllocation> GetAll()
        {
            List<LeaveAllocation> leaveAllocations = DbContext.LeaveAllocations.ToList();
            return leaveAllocations;
        }

        public Data.Models.LeaveAllocation GetById(int id)
        {
            LeaveAllocation leaveAllocation = DbContext.LeaveAllocations.Find(id);
            return leaveAllocation;
        }

        public bool Save()
        {
            int numberOfRecordsChanged = DbContext.SaveChanges();
            return numberOfRecordsChanged > 0;
        }

        public bool Update(Data.Models.LeaveAllocation entity)
        {
            DbContext.LeaveAllocations.Update(entity);
            return Save();
        }
    }
}
