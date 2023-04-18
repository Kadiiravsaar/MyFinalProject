using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; // global değişken denir

        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }

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
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllOrderBy()
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Updatet(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
