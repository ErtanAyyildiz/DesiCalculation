using Enoca.DataAccess.Abstracts;
using Enoca.DataAccess.Concrete;
using Enoca.DataAccess.MsEntityFramework;
using Enoca.DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnocaContext _db;

        public UnitOfWork(EnocaContext db)
        {
            _db = db;
            Order = new OrderDal(_db);
            Carrier = new CarrierDal(_db);
            CarrierConfiguration = new CarrierConfigurationDal(_db);
        }

        public IOrderDal Order { get; private set; }
        public ICarrierDal Carrier { get; private set; }
        public ICarrierConfigurationDal CarrierConfiguration { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
