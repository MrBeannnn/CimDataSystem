﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESWIN.Model.Result.SystemManage
{
    public class UserAuthorizeInfo
    {
        public int? IsSystem { get; set; }
        public List<MenuAuthorizeInfo> MenuAuthorize { get; set; }
    }
}
