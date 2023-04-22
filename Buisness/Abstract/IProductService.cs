using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(int id);

        List<Product> GetAllByCategoryId(int id);

        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<Product> GetByUnitInStock(short min, short max);

        List<Product> GetAllOrderBy();
        List<ProductDetailDto> GetProductDetails();

        IResult AddProduct(Product product);


    }
}
