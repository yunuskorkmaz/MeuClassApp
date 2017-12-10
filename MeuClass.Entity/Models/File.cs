using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Entity.Models
{
    class FileUpload
    {
        public int FileUploadID { get; set; }
        public User User { get; set; }
        public string FileLink { get; set; }
        public string FileTemporaryLink { get; set; }
        public string FileInfo { get; set; }
        public string FileTitle { get; set; }
        public DateTime UploadTime { get; set; }

    }
}
