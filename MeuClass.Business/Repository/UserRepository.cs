using MeuClass.Data;
using System.Linq;

namespace MeuClass.Business.Repository
{
    public class UserRepository : BaseRepostory<User>
    {
        public static UserRepository Instance = new UserRepository();

        public User CheckAuth(string schoolNumber, string password)
        {
           var controlUser =  Search(a => a.SchoolNumber == schoolNumber && a.Password == password).FirstOrDefault();

            if (controlUser == null)
                return null;
            else
                return controlUser;        
        }

        public User Add(User user)
        {
            return Insert(user);
        }

        
    }
}
