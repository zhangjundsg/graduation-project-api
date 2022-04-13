using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class FileUpdaloadOption
    {
        public bool isUpdate { get; set; }
        public string filePath { get; set; }
        public int fileSize { get; set; }
        public string fileType { get; set; }
    }
}
