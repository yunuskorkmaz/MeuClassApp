using MeuClass.Business.ResultData;
using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuClass.Business.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public static UserRepository Instance = new UserRepository();

        public ResultData<User> CheckAuth(string schoolNumber, string password)
        {
            var result = _search(a => a.SchoolNumber == schoolNumber && a.Password == password);

            if (result.Success == true)
            {
                if (result.Data.Count == 0)
                {
                    return ResultData<User>.Instance.Fill(false, "Kullanıcı adı yada şifre yanlış");
                }
                else
                {
                    return ResultData<User>.Instance.Fill(true, result.Data.FirstOrDefault());
                }
            }
            else
            {
                return ResultData<User>.Instance.Fill(false, result.Message);
            }


        }

        public ResultData<int> GetUserType(int id)
        {
            var result = _search(a => a.UserID == id);

            if (result.Success == true)
            {
                var typeid = (int)result.Data.FirstOrDefault().UserTypeID;
                return ResultData<int>.Instance.Fill(true, typeid);
            }
            else
            {
                return ResultData<int>.Instance.Fill(false, result.Message);
            }
        }

        public ResultData<User> Add(User user)
        {
            var result = _insert(user);

            if (result.Success == true)
            {
                return ResultData<User>.Instance.Fill(true, result.Data);
            }
            else
            {
                return ResultData<User>.Instance.Fill(false, result.Message);
            }
        }

        public ResultData<User> Update_User(User user)
        {
            try
            {
                var result = _update(user);
                if (result.Success == true)
                {
                    return ResultData<User>.Instance.Fill(true, result.Data);

                }
                else
                {
                    return ResultData<User>.Instance.Fill(false, "Hata Oluştu");
                }
            }
            catch (Exception ex)
            {
                return ResultData<User>.Instance.Fill(false, ex.Message);
            }

        }

        public ResultData<List<User>> GetList()
        {
            try
            {
                var result = _getAll();
                if (result.Success == true)
                {
                    return (ResultData<List<User>>.Instance.Fill(true, result.Data));

                }
                else
                {
                    return ResultData<List<User>>.Instance.Fill(false, result.Data);
                }

            }
            catch (Exception ex)
            {
                return ResultData<List<User>>.Instance.Fill(false, "İşlem yapılırken hata oluştu" + ex.ToString());
            }

        }
    }


}

