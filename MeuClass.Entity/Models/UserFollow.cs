using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    public class UserFollow
    {
        public int ID { get; set; }

        public User User { get; set; }

        public User FollowingUser { get; set; }

        public DateTime Date { get; set; }
    }
}
