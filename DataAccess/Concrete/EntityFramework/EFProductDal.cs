﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {
        public void Add(Product entitiy)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var prod = context.Set<Product>().SingleOrDefault(expression);
                return prod;
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return expression == null ? context.Set<Product>().ToList(): context.Set<Product>().Where(expression).ToList();
            }
        }

      

        public void Updatet(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
