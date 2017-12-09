using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    public class BlockedUser
    {
        public int ID { get; set; }

        public User User { get; set; }

        public User BlockUser { get; set; }

        public DateTime Date { get; set; }

    }
}
