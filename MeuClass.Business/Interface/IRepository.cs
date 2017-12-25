using MeuClass.Business.ResultData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeuClass.Business.Interface
{
    interface IRepository<TEntry>
    {

        ResultData<TEntry> Insert(TEntry entry);

        ResultData<bool> Delete(TEntry entry);

        ResultData<List<TEntry>> Search(Expression<Func<TEntry, bool>> predicate);

        ResultData<List<TEntry>> GetAll();

        ResultData<TEntry> GetByID(int id);

        ResultData<TEntry> Update(TEntry entry);


    }
}
