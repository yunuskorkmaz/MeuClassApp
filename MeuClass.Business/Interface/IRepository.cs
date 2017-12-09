using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Business.Interface
{
    interface IRepository<TEntry>
    {

         TEntry Insert(TEntry entry);

        bool Delete(TEntry entry);

        List<TEntry> Search(Expression<Func<TEntry, bool>> predicate);

        List<TEntry> GetAll();

        TEntry GetByID(int id);

        TEntry Update(TEntry entry);


    }
}
