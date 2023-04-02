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
    public class OrderDal : Repository<Order>,IOrderDal
    {
        private readonly EnocaContext _db;
        public OrderDal(EnocaContext db) : base(db)
        {
            _db = db;
        }

        public List<Order> GetPagedData(PaginationFilter filter)
        {
            return _db.Orders
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();
        }
    }
}
