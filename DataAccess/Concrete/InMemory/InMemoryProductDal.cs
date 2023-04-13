using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            Product productDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productDelete);
        }
       
        public List<Product> GetAll()
        {
            return _products; 
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _products.Where(x=>x.CategoryId==id).ToList();
        }

        public void UpdateProduct(Product product)
        {
            Product prdouctToUpdate = _products.SingleOrDefault(x=>x.ProductId == product.ProductId);
            product.ProductName = prdouctToUpdate.ProductName;
            product.CategoryId = prdouctToUpdate.CategoryId;
            product.UnitPrice = prdouctToUpdate.UnitPrice;
            product.UnitsInStock = prdouctToUpdate.UnitsInStock;
        }
    }
}
