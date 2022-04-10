using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class FiledList
    {
        public List<FiledOper> fileList { get; set; }
        public int totalPage { get; set; }
    }
}
