using System;
using System.Collections.Generic;
using ESWIN.Model.Param.SystemManage;

namespace ESWIN.Model.Param.OrganizationManage
{
    public class NewsListParam : BaseAreaParam
    {
        public string NewsTitle { get; set; }
        public int? NewsType { get; set; }
        public string NewsTag { get; set; }
    }
}
