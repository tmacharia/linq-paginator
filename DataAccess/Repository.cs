using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T> : IBaseInterface, IRepository<T> where T : class
    {
        private IDbContext _context;

        public Repository(IDbContext context)
        {
            _context = context;
        }
        public int Count => _context.GetDbSet<T>().Count();

        public T First => _context.GetDbSet<T>().First();
        public Task<T> FirstAsync => _context.GetDbSet<T>().FirstAsync();

        public IQueryable<T> List => _context.GetDbSet<T>();
        public Task<List<T>> ListAsync => _context.GetDbSet<T>().ToListAsync();
        private IQueryable<T> All()
        {
            return _context.GetDbSet<T>()
                           .AsQueryable();
        }
        public IQueryable<T> ListWith<TProperty>(Expression<Func<T, TProperty>> navPropertyPath)
        {
            return _context.GetDbSet<T>()
                           .Include(navPropertyPath);
        }
        public T Update(T entity)
        {
            _context.GetDbSet<T>().Attach(entity);
            _context.SetModified(entity);

            return entity;
        }
        public T[] UpdateMany(T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                _context.SetModified(entities[i]);
            }

            return entities;
        }
        public T Create(T entity)
        {
            return _context.Create(entity);
        }

        public T[] CreateMany(T[] entities)
        {
            entities.ForEach(x =>
            {
                x = _context.Create(x);
            });

            return entities;
        }

        #region Get Section
        public T GetById(int Id)
        {
            return _context.GetDbSet<T>()
                           .FirstOrDefault(x => x.GetPropertyValue<T,int>("Id") == Id);
        }
        public T GetById(Guid uuid)
        {
            return _context.GetDbSet<T>()
                           .FirstOrDefault(x => x.GetPropertyValue<T,Guid>("uuid") == uuid);
        }

        public T GetWith<TProperty>(int Id, Expression<Func<T,TProperty>> navPropertyPath)
        {
            return _context.GetDbSet<T>()
                           .Include(navPropertyPath)
                           .FirstOrDefault(x => x.GetPropertyValue<T,int>("Id") == Id);
        }
        public T GetWith<TProperty>(Expression<Func<T, TProperty>> navPropertyPath, Func<T, bool> predicate)
        {
            return _context.GetDbSet<T>()
                           .Include(navPropertyPath)
                           .FirstOrDefault(predicate);
        }
        public T GetByObject(T entity)
        {
            return _context.GetDbSet<T>().Find(entity);
        }
        public T GetWhere(Func<T, bool> stringFunc)
        {
            return _context.GetDbSet<T>().FirstOrDefault(stringFunc);
        }
        public T GetByGuid(Func<T, bool> uuidFunc)
        {
            return _context.GetDbSet<T>().First(uuidFunc);
        }
        public IEnumerable<T> Get(Func<T, bool> expression)
        {
            return _context.GetDbSet<T>().Where(expression);
        }
        #endregion



        public bool Remove(T entity)
        {
            _context.GetDbSet<T>().Remove(entity);

            return true;
        }
        public bool Remove(int Id)
        {
            var item = GetById(Id);


            Remove(item);

            return true;
        }
        public bool RemoveMany(int[] ids)
        {
            try
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    Remove(ids[i]);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveMany(T[] entities)
        {
            try
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    Remove(entities[i]);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                base.DisposeItem(ref _context);
            }

            base.Dispose(isDisposing);
        }
    }
}
