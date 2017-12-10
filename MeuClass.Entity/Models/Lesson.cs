using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    class Lesson
    {
        public int LessonID { get; set; }
        public string LessonCode { get; set; }
        public User User { get; set; }
    }
}
