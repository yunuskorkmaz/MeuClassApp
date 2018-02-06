using MeuClass.Business.ResultData;
using MeuClass.Data;

namespace MeuClass.Business.Repository
{
    public class UserTypeRepository : BaseRepository<UserType>
    {
        public static UserTypeRepository Instance = new UserTypeRepository();
        public ResultData<UserType> GetAll(UserType usertype)
        {


            var result = GetAll(usertype);
            if (result.Success == true)
            {
                return ResultData<UserType>.Instance.Fill(true, result.Data);
            }
            else
            {
                return ResultData<UserType>.Instance.Fill(false, result.Message);
            }

        }
    }
}
