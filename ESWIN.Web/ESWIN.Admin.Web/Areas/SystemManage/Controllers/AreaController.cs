using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ESWIN.Util;
using ESWIN.Util.Model;
using ESWIN.Entity;
using ESWIN.Model;
using ESWIN.Admin.Web.Controllers;
using ESWIN.Entity.SystemManage;
using ESWIN.Business.SystemManage;
using ESWIN.Model.Param.SystemManage;
using ESWIN.Model.Result;

namespace ESWIN.Admin.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class AreaController : BaseController
    {
        private AreaBLL areaBLL = new AreaBLL();

        #region 视图功能
        [AuthorizeFilter("system:area:view")]
        public IActionResult AreaIndex()
        {
            return View();
        }

        public IActionResult AreaForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:area:search")]
        public async Task<IActionResult> GetListJson(AreaListParam param)
        {
            TData<List<AreaEntity>> obj = await areaBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:area:search")]
        public async Task<IActionResult> GetPageListJson(AreaListParam param, Pagination pagination)
        {
            TData<List<AreaEntity>> obj = await areaBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetZtreeAreaListJson(AreaListParam param)
        {
            TData<List<ZtreeInfo>> obj = await areaBLL.GetZtreeAreaList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<AreaEntity> obj = await areaBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:area:add,ystem:area:edit")]
        public async Task<IActionResult> SaveFormJson(AreaEntity entity)
        {
            TData<string> obj = await areaBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:area:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await areaBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
