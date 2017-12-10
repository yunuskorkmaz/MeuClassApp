using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    class LessonContent
    {
        public int LessonContentID { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public FileUpload FileUpload { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime DeleteTime { get; set; }
        public DateTime WorkStartTime { get; set; }
        public DateTime WorkFinishTime { get; set; }
        public Lesson Lesson { get; set; }
    }
}
