using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Interfaces
{
    public interface IRepository<T> where T:class
    {
        public Task<List<T>> GetAll();
        public Task<List<T>> Get(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        public Task<T> GetByID(int Id);
        public Task<bool> Insert(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(T entity);
        
    }
}
