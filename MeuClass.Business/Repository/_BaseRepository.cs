using MeuClass.Business.Interface;
using MeuClass.Business.ResultData;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MeuClass.Business.Repository
{
    public class BaseRepository<TEntry>  where TEntry : class
    {
        private ClassAppContext db;

        public BaseRepository()
        {
            db = new ClassAppContext();
        }

        public ResultData<bool> _delete(TEntry entry)
        {
            var db = new ClassAppContext();
            
                try
                {
                    db.Set<TEntry>().Remove(entry);
                    db.SaveChanges();

                    return ResultData<bool>.Instance.Fill(true, true);
                }
                catch (Exception ex)
                {
                    return ResultData<bool>.Instance.Fill(false, "İşlem yapılırken hata oluştu." + ex.ToString());
                }


            
        }

        public ResultData<List<TEntry>> _getAll()
        {
            var db = new ClassAppContext();
            
                try
                {
                    var result = db.Set<TEntry>().ToList();
                    return ResultData<List<TEntry>>.Instance.Fill(true, result);
                }
                catch (Exception ex)
                {
                    return ResultData<List<TEntry>>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
                }

            
        }

        public ResultData<TEntry> _getByID(int id)
        {
            var db = new ClassAppContext();
            
                try
                {
                    var result = db.Set<TEntry>().Find(id);
                    return ResultData<TEntry>.Instance.Fill(true, result);
                }
                catch(Exception ex)
                {
                    return ResultData<TEntry>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
                }


            
        }

        public ResultData<TEntry> _insert(TEntry entry)
        {
            using (var db = new ClassAppContext())
            {
                try
                {
                    var addedEntry = db.Set<TEntry>().Add(entry);
                    db.SaveChanges();
                    return ResultData<TEntry>.Instance.Fill(true, addedEntry);
                }
                catch(Exception ex)
                {
                    return ResultData<TEntry>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
                }
            }
        }

        public ResultData<List<TEntry>> _search(Expression<Func<TEntry, bool>> where)
        {
            var db = new ClassAppContext();
            
                try
                {
                    var result =  db.Set<TEntry>().Where(where).ToList();
                    return ResultData<List<TEntry>>.Instance.Fill(true, result);
                }
                catch(Exception ex)
                {
                    return ResultData<List<TEntry>>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
                }
                
            
        }

        public ResultData<TEntry> _update(TEntry entry)
        {
            var db = new ClassAppContext();
            
                try
                {    
                    var updatedEntry = db.Set<TEntry>().Attach(entry);
                    var up = db.Entry(updatedEntry);
                    up.State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return ResultData<TEntry>.Instance.Fill(true, updatedEntry);
                }
                catch(Exception ex)
                {
                    return ResultData<TEntry>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
                }
            

        }
    }
}
