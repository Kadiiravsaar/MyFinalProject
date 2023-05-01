using Buisness.Abstract;
using Buisness.Costants;
using Buisness.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Buisness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidationException = FluentValidation.ValidationException;

namespace Buisness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //ICategoryDal _categoryDal; // bir Entity Manager(ProductManager) başka bir dal'ı enjekte edemez
        ICategoryService _categoryService;     // ancak bu şekilde yapabilirsin 

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
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

            IResult result = BuisnessRules.Run(
                 CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                 CheckIfProductNameExists(product.ProductName),
                 CheckIfCategoryLimitExceded()
                 );

            if (result != null)
            {
                return result;
            }
             
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CategoryCountMuch);
            }

            return new SuccessResult();


        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productDal.GetAll(p => p.ProductName == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProdNameAlready);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
