using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal : ICategoryDal
    {
        public void Add(Category entitiy)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var category = context.Entry(entitiy);
                category.State = EntityState.Added;
            }
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> expression)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return context.Set<Category>().SingleOrDefault(expression);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> expression = null)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return expression == null ? context.Set<Category>().ToList() : context.Set<Category>().Where(expression).ToList();
            }
        }

        public void Updatet(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
