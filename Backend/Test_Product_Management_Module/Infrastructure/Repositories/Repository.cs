using Domain.BaseEntity;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntityClass
    {

        #region Private Variables And Controller
        private readonly MainDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(MainDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        #endregion

        #region GetAll
        public async Task<ICollection<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<T> GetById(int id)
        {
            return await _entities.SingleOrDefaultAsync(e => e.id == id);
        }
        #endregion

        #region GetByName
        public async Task<T> GetByName(string name)
        {
            return await _entities.FindAsync(name);
        }
        #endregion

        #region GetLast
        public T GetLast()
        {
            return _entities.LastOrDefault();
        }
        #endregion

        #region Insert
        public async Task<bool> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _entities.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Update
        public async Task<bool> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result != null)
            {
                return true;
            }
            else
                return false;
        }
        /*public async Task<bool> Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }*/

        #endregion

        #region Find
        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _entities.FirstOrDefaultAsync(match);
        }
        #endregion

        #region FindAll
        public async Task<ICollection<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await _entities.Where(match).ToListAsync();
        }

       
        #endregion
    }
}
