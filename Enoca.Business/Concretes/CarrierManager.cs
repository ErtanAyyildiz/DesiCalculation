using Enoca.Business.Abstracts;
using Enoca.DataAccess.Repositories.IRepositories;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;

namespace Enoca.Business.Concretes
{
    public class CarrierManager : ICarrierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarrierManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Carrier entity)
        {
            _unitOfWork.Carrier.Add(entity);
            _unitOfWork.Save();
        }

        public Carrier GetByID(int id)
        {
            return _unitOfWork.Carrier.GetByID(id);
        }

        public Carrier GetCarrierByOrder(int carrierId)
        {
            return _unitOfWork.Carrier.GetCarrierByOrder(carrierId);
        }

        public IEnumerable<Carrier> GetList()
        {
            return _unitOfWork.Carrier.GetList();
        }

        public List<Carrier> GetPagedData(PaginationFilter filter)
        {
            return _unitOfWork.Carrier.GetPagedData(filter);
        }

        public void Remove(Carrier entity)
        {
            _unitOfWork.Carrier.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(Carrier entity)
        {
            _unitOfWork.Carrier.Update(entity);
            _unitOfWork.Save();
        }
    }
}
