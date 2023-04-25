using Buisness.Abstract;
using Buisness.Costants;
using Buisness.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;

namespace Buisness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetById(int id)
        {
            if (_productDal.Get(x => x.ProductId == id) == null)
            {
                return new ErrorDataResult<Product>(Messages.ProductNotId);
            }
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id), Messages.Product);

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintTenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice > min && x.UnitPrice < max));
        }

        public IDataResult<List<Product>> GetByUnitInStock(short min, short max)
        {
            if (min < 0)
            {
                return new ErrorDataResult<List<Product>>(Messages.ProductEmpty);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitsInStock > min && x.UnitsInStock < max));

        }

        public IDataResult<List<Product>> GetAllOrderBy()
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAllOrderBy());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintTenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))] // Add metodunu doğrula => productValidator de ki kurallara göre (kurallar ValidationAspect yazılıyor)
        public IResult AddProduct(Product product)
        {

            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
