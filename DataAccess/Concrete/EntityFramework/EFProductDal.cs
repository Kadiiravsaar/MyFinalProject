using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                var result = context.Products.OrderByDescending(x => x.ProductId).ToList();
                return result;
            }
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.ProductId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitInStock = p.UnitsInStock
                             };
                return result.ToList();
            }
        }
    }
}
