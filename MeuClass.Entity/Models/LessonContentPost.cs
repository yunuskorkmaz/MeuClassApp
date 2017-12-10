using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    class LessonContentPost
    {
        public int LessonContentPostID { get; set; }
        public LessonContent LessonContent { get; set; }
        public string Answer { get; set; }
        public FileUpload FileUpload { get; set; }
        public DateTime RecordTime { get; set; }
    }
}
