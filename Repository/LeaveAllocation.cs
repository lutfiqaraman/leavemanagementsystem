using leavemanagementsystem.Contracts;
using leavemanagementsystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Repository
{
    public class LeaveAllocation : ILeaveAllocation
    {
        public ApplicationDbContext DbContext { get; private set; }

        public LeaveAllocation(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public bool Create(Data.Models.LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Data.Models.LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Data.Models.LeaveAllocation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Data.Models.LeaveAllocation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Data.Models.LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
