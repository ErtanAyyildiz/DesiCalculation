using Enoca.Business.Abstracts;
using Enoca.DataAccess.Repositories.IRepositories;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;

namespace Enoca.Business.Concretes
{
    public class CarrierConfigurationManager : ICarrierConfigurationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarrierConfigurationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(CarrierConfiguration entity)
        {
            _unitOfWork.CarrierConfiguration.Add(entity);
            _unitOfWork.Save();
        }

        public CarrierConfiguration GetByID(int id)
        {
            return _unitOfWork.CarrierConfiguration.GetByID(id);
        }

        public IEnumerable<CarrierConfiguration> GetList()
        {
            return _unitOfWork.CarrierConfiguration.GetList();
        }

        public List<CarrierConfiguration> GetPagedData(PaginationFilter filter)
        {
            return _unitOfWork.CarrierConfiguration.GetPagedData(filter);
        }

        public void Remove(CarrierConfiguration entity)
        {
            _unitOfWork.CarrierConfiguration.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(CarrierConfiguration entity)
        {
            _unitOfWork.CarrierConfiguration.Update(entity);
            _unitOfWork.Save();
        }
    }
}
