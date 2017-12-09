using MeuClass.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
