using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuClass.Models
{
    public class LessonDetailViewModel
    {
        public Lesson Lesson { get; set; }
        public User Teacher { get; set; }
    }
}