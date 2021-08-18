using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESWIN.Admin.Web.Model
{
    public class ResultModel
    {
            public int code { get; set; }// 1成功 0失败
            public string msg { get; set; }
            public dynamic data { get; set; }
    }
}
