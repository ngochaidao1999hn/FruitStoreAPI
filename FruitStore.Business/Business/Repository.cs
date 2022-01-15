using FruitStore.Business.Interfaces;
using FruitStore.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.Business.Business
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public fruitstoreContext _context;
        public DbSet<T> table;
        public Repository(fruitstoreContext context) {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                table.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = table;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByID(int Id)
        {
            return await table.FindAsync(Id);
        }

        public async Task<bool> Insert(T entity)
        {
            try
            {
                table.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                table.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
