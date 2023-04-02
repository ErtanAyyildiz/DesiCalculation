using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstracts
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetByID(int id);
        IEnumerable<T> GetList();
    }
}
