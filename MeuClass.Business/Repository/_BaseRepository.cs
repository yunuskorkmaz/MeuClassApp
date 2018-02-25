using MeuClass.Business.Interface;
using MeuClass.Business.ResultData;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace MeuClass.Business.Repository
{
    public class BaseRepository<TEntry> : IDisposable where TEntry : class
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<TEntry> _dbSet;

        public BaseRepository()
        {
           
            _dbContext = new ClassAppContext();
            _dbSet = _dbContext.Set<TEntry>();
        }


        public List<TEntry> _GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<TEntry> _GetAll(Expression<Func<TEntry, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


        public TEntry _GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntry _Get(Expression<Func<TEntry, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public TEntry _Add(TEntry entity)
        {
           return _dbSet.Add(entity);
        }

        public TEntry _Update(TEntry entity)
        {
           var _entity = _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _entity;
        }


        public void _Delete(TEntry entity)
        {
           
               
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            
        }

        public void _Delete(int id)
        {
            var entity = _GetById(id);
            if (entity == null) return;
            else
            {
                _Delete(entity);
            }
        }




        public bool SaveChanges()
        {
            try
            {
                return Convert.ToBoolean(_dbContext.SaveChanges());
            }
            catch
            {
                return false ;
            }
        }

        #region IDisposable Members
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
