using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public interface IRepository<T> where T : class
    {
        void Create(T t);
        int Delete(T t);
        IList<T> Read();
        int Update(T t);
    }
}