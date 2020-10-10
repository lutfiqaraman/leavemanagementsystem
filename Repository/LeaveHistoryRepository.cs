using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using leavemanagementsystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        public ApplicationDbContext DbContext { get; private set; }

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public bool Create(LeaveHistory entity)
        {
            DbContext.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            DbContext.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> GetAll()
        {
            List<LeaveHistory> leaveHistories = DbContext.LeaveHistories.ToList();
            return leaveHistories;
        }

        public LeaveHistory GetById(int id)
        {
            LeaveHistory leaveHistory = DbContext.LeaveHistories.Find(id);
            return leaveHistory;
        }

        public bool Save()
        {
            int numberOfRecordsChanged = DbContext.SaveChanges();
            return numberOfRecordsChanged > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            DbContext.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
