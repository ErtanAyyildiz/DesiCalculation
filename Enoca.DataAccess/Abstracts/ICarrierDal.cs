using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using Enoca.Entity.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Abstracts
{
    public interface ICarrierDal:IRepository<Carrier>
    {
        public Carrier GetCarrierByOrder(int carrierId);
        public List<Carrier> GetPagedData(PaginationFilter filter);

    }
}
