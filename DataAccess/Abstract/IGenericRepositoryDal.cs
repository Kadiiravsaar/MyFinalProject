using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
