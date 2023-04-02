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
    public interface ICarrierConfigurationDal:IRepository<CarrierConfiguration>
    {
        public List<CarrierConfiguration> GetPagedData(PaginationFilter filter);
    }
}
