using MeuClass.Business.ResultData;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MeuClass.Business.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public static UserRepository Instance = new UserRepository();

        public ResultData<User> CheckAuth(string schoolNumber, string password)
        {
            using (this)
            {
                try
                {
                    var result = _Get(a => (a.SchoolNumber == schoolNumber || a.MailAddress == schoolNumber) && a.Password == password);

                    if (result != null)
                    {
                        return ResultData<User>.Instance.Fill(true, result);
                    }
                    else
                    {
                        return ResultData<User>.Instance.Fill(false, "Kullanıcı adı yada şifre yanlış");
                    }
                }
                catch (Exception ex)
                {
                    return ResultData<User>.Instance.Fill(false, ex.Message);
                }
            }
        }


        public ResultData<List<User>> Search(Expression<Func<User, bool>> predicate)
        {
            using (this)
            {
                try
                {
                    var result = _GetAll(predicate);

                    return ResultData<List<User>>.Instance.Fill(true, result.ToList());
                }
                catch(Exception ex)
                {
                    return ResultData<List<User>>.Instance.Fill(false, ex.Message);
                }
               
            }
        }


        public ResultData<User> Add(User user)
        {
            try
            {
                using (this)
                {
                    var result = _Add(user);
                    SaveChanges();

                    if (result != null)
                    {
                        return ResultData<User>.Instance.Fill(true, result);
                    }
                    else
                    {
                        return ResultData<User>.Instance.Fill(false, "Bir Hata Oluştu");
                    }
                }

            }
            catch (Exception ex)
            {
                return ResultData<User>.Instance.Fill(false, ex.Message);
            }

        }

        public ResultData<int> GetUserType(int id)
        {
            using (this)
            {
                var result = _GetById(id);
                return ResultData<int>.Instance.Fill(true, (int)result.UserTypeID);
            }
        }


    }
}
