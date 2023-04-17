using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EFGenericRepository<Product, AppDbContext>, IProductDal
    {
        public List<Product> GetAllOrderBy()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = context.Products.OrderBy(x=>x.ProductName).ToList();
                return result;
            }
        }
    }
}
