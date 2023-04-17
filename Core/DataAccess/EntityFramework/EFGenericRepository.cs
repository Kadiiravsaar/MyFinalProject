using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EFGenericRepository<T, TContext> : IEntityRepository<T>
        where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(T entitiy)
        {
            using (TContext context = new TContext())
            {
                var category = context.Entry(entitiy);
                category.State = EntityState.Added;
            }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(expression);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            using (TContext context = new TContext())
            {
                return expression == null ? context.Set<T>().ToList() : context.Set<T>().Where(expression).ToList();
            }
        }

        public void Updatet(T entity)
        {
            using (TContext context = new TContext())
            {
                var category = context.Entry(entity);
                category.State = EntityState.Modified;
            }
        }
    }
}
