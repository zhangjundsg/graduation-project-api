using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Model
{
    public enum ResponseCode:int
    {
        Success=200,
        ValidationError=233,
        CodeError= 255,
        ValidationFailed=201,
        NotFound =404,
    }
}
