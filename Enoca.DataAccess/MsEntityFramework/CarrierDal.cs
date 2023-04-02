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
    public class CarrierDal : Repository<Carrier>,ICarrierDal
    {
        private readonly EnocaContext _db;
        public CarrierDal(EnocaContext db) : base(db)
        {
            _db = db;
        }

        public Carrier GetCarrierByOrder(int carrierId)
        {
            return _db.Carriers
                .Where(c => c.CarrierId == carrierId)
                .First();
        }

        public List<Carrier> GetPagedData(PaginationFilter filter)
        {
            return _db.Carriers
               .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
               .ToList();
        }
    }
}
