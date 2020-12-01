using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem.Contracts
{
    public interface IRepositoryBase<T> where T: class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        void Delete(T entity);
        bool Save();
    }
}
