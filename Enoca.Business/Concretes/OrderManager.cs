using Enoca.Business.Abstracts;
using Enoca.DataAccess.Repositories.IRepositories;
using Enoca.DataAccess.Wrappers.Filters;
using Enoca.Entity.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Business.Concretes
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Order entity)
        {
            _unitOfWork.Order.Add(entity);
            _unitOfWork.Save();
        }

        public Order GetByID(int id)
        {
            return _unitOfWork.Order.GetByID(id);
        }

        public IEnumerable<Order> GetList()
        {
            return _unitOfWork.Order.GetList();
        }

        public List<Order> GetPagedData(PaginationFilter filter)
        {
            return _unitOfWork.Order.GetPagedData(filter);
        }

        public void Remove(Order entity)
        {
            _unitOfWork.Order.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(Order entity)
        {
            _unitOfWork.Order.Update(entity);
            _unitOfWork.Save();
        }
    }
}
