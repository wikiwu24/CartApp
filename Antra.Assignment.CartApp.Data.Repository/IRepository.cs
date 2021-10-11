using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Assignment.CartApp.Data.Repository
{
    public interface IRepository<T> where T: class
    {
        int Insert(T item);
        //int Update(T item);
        //int Delete(int id);
        IEnumerable<T> GetAll();
    }
}
