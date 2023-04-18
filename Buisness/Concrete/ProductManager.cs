using Buisness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product Get(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(c => c.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice > min && x.UnitPrice < max);
        }
        public List<Product> GetByUnitInStock(short min, short max)
        {
           
            var prd =  _productDal.GetAll(x => x.UnitsInStock > min && x.UnitsInStock < max);
            if (prd.Count == 0)
            {
                Console.WriteLine("İçerisi Boş usta");
            }
            return prd;

        }

        public List<Product> GetAllOrderBy()
        {
            var result = _productDal.GetAllOrderBy();
            return result;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            return result;
        }
    }
}
