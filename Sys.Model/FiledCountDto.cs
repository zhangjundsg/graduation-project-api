using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class FiledCountDto
    {
        public int Passed { get; set; }
        public int Rejected { get; set; }
        public int NotAudited { get; set; }
        public int NewUserAdd { get; set; }
        public int Dimission { get; set; }
    }
}
