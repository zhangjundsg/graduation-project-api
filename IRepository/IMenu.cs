﻿using Sys.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.IRepository
{
    public interface IMenu: IBaseRepository<Sys_Menu>
    {
        List<Sys_Menu> MenuInfo(int UserID);
    }
}
