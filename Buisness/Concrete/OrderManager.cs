using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order Get(int id)
        {
            return _orderDal.Get(x => x.OrderId == id);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public List<Order> GetAllByEmployeeId(int id)
        {
            var orderByEmployeeId = _orderDal.GetAll(x=>x.EmployeeId == id);
            return orderByEmployeeId;
        }

        
    }
}
