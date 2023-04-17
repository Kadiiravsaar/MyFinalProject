using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IGenericRepositoryDal<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T,bool>> expression);
        void Add(T entitiy);
        void Updatet(T entity);
        void Delete(T entity);
       
    }
}
