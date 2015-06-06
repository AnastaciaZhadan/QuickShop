using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace QSDataAccess
{
    public interface IRepository<T>
    {
        bool Insert(T item);
        T GetById(int id);
        bool Save();
        bool Delete(T item);
    }
}
