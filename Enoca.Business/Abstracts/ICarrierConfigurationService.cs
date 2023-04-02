using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Abstracts
{
    public interface ICarrierConfigurationService:IGenericService<CarrierConfiguration>
    {
        public List<CarrierConfiguration> GetPagedData(PaginationFilter filter);
        public CarrierConfiguration GetCarrierConfigurationByCarrierId(int carrierId);
        public CarrierConfiguration ClosestCarrierConfig(int orderDesi);
    }
}
