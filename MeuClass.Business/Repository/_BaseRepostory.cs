using MeuClass.Business.Interface;
using MeuClass.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MeuClass.Business.Repository
{
    public class BaseRepostory<TEntry> : IRepository<TEntry> where  TEntry : class
    {
        public bool Delete(TEntry entry)
        {
            using (var db = new DataContext())
            {
             var removed = db.Set<TEntry>().Remove(entry);

                db.SaveChanges();
                if(removed == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public List<TEntry> GetAll()
        {
            using (var db =  new DataContext())
            {
                return db.Set<TEntry>().ToList();
            }
        }

        public TEntry GetByID(int id)
        {
            using (var db = new DataContext())
            {
               return db.Set<TEntry>().Find(id);
            }
        }

        public TEntry Insert(TEntry entry)
        {
            using (var db = new DataContext())
            {
               var addedEntry = db.Set<TEntry>().Add(entry);
                db.SaveChanges();
                
                return addedEntry;
            }
        }

        public List<TEntry> Search(Expression<Func<TEntry, bool>> where)
        {
            using (var db =  new DataContext())
            {
                return db.Set<TEntry>().Where(where).ToList();
            }
        }

        public TEntry Update(TEntry entry)
        {
            using (var db =  new DataContext())
            {
                var updatedEntry = db.Set<TEntry>().Attach(entry);
                db.SaveChanges();
                return updatedEntry;
            }
              
        }
    }
}
