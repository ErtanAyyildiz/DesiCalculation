using Enoca.DataAccess.Abstracts;
using Enoca.DataAccess.Concrete;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using Enoca.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.MsEntityFramework
{
    public class CarrierConfigurationDal : Repository<CarrierConfiguration>,ICarrierConfigurationDal
    {
        private readonly EnocaContext _db;
        public CarrierConfigurationDal(EnocaContext db) : base(db)
        {
            _db = db;
        }

        public CarrierConfiguration ClosestCarrierConfig(int orderDesi)
        {
            return _db.CarrierConfigurations
                .OrderBy(x => Math.Abs(x.CarrierMaxDesi - orderDesi))
                .First();
        }

        public CarrierConfiguration GetCarrierConfigurationByCarrierId(int carrierId)
        {
            return _db.CarrierConfigurations
                .Where(c => c.CarrierId == carrierId)
                .First();
        }

        public List<CarrierConfiguration> GetPagedData(PaginationFilter filter)
        {
            return _db.CarrierConfigurations
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToList();
        }
    }
}
