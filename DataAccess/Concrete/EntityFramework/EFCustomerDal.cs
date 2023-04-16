using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : ICustomerDal
    {
        public void Add(Customer entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {

            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<Customer>().SingleOrDefault(expression);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> expression = null)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return expression == null ? context.Set<Customer>().ToList() : context.Set<Customer>().Where(expression).ToList();
            }
        }

        public void Updatet(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
