using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstracts
{
    public interface ICarrierService:IGenericService<Carrier>
    {
        public Carrier GetCarrierByOrder(int carrierId);
        public List<Carrier> GetPagedData(PaginationFilter filter);
    }
}
