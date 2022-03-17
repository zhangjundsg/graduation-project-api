using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public class UpdateMenuDto
    {
        public int roleID { get; set; }
        public List<int> menuID { get; set; }
    }
}
