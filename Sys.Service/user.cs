using Sys.IService;
using System;

namespace Sys.Service
{
    public class user : Iuser
    {
        public string name()
        {
            return "你好";
        }
    }
}
