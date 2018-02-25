using MeuClass.Business.ResultData;
using MeuClass.Data;
using System;
using System.Collections.Generic;

namespace MeuClass.Business.Repository
{
    public class UserTypeRepository : BaseRepository<UserType>
    {
        public static UserTypeRepository Instance = new UserTypeRepository();
        public ResultData<List<UserType>> GetAll()
        {

            using (this)
            {
                var result = _GetAll();

                try
                {

                    if (result != null)
                    {
                        return ResultData<List<UserType>>.Instance.Fill(true, result);
                    }
                    else
                    {
                        return ResultData<List<UserType>>.Instance.Fill(false, "hata");
                    }
                }
                catch (Exception ex)
                {
                    return ResultData<List<UserType>>.Instance.Fill(false, ex.Message);
                }
            }
        }
    }
}
