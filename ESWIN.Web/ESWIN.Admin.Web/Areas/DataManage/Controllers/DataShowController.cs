using ESWIN.Admin.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESWIN.Admin.Web.Areas.DataManage.Controllers
{
    [Area("DataManage")]
    public class DataShowController : Controller
    {
        [AuthorizeFilter("DataManage:Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
