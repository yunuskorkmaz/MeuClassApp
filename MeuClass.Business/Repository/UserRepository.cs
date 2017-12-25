using MeuClass.Business.ResultData;
using MeuClass.Data;
using System.Linq;

namespace MeuClass.Business.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public static UserRepository Instance = new UserRepository();

        public ResultData<User> CheckAuth(string schoolNumber, string password)
        {
            var result = Search(a => a.SchoolNumber == schoolNumber && a.Password == password);

            if (result.Success == true)
            {
                if (result.Data == null)
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

        public ResultData<User> Add(User user)
        {
            var result = Insert(user);

            if(result.Success == true)
            {
                return ResultData<User>.Instance.Fill(true, result.Data);
            }
            else
            {
                return ResultData<User>.Instance.Fill(false, result.Message);
            }
        }


    }
}
