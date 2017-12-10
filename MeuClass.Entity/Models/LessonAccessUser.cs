using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    class LessonAccessUser
    {
        public int LessonAccessUserID { get; set; }
        public Lesson Lesson { get; set; }
        public User User { get; set; }
    }
}
