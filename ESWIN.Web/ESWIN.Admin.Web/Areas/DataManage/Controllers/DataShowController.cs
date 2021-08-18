using ESWIN.Admin.Web.Controllers;
using ESWIN.Admin.Web.Model;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ESWIN.Admin.Web.Areas.DataManage.Controllers
{
    [Area("DataManage")]
    public class DataShowController : Controller
    {
        //用来获取路径相关
        private IHostingEnvironment _hostingEnvironment;

        public DataShowController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [AuthorizeFilter("DataManage:Index")]
        public IActionResult Index()
        {
            return View();
        }
        //导入功能
        [HttpPost]
        public IActionResult Import(IFormFile excelfile)
        {
            DataTable table = new DataTable();//用来暂存读取到的数据
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = $"{Guid.NewGuid()}.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Create))
                {
                    excelfile.CopyTo(fs);
                    fs.Flush();  //清空stream缓存
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;//指定EPPlus使用非商业证书
                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;

                    for (int i = 1; i <= rowCount; i++)
                    {
                        DataRow dataRow = table.NewRow();
                        for (int j = 1; j <= ColCount; j++)
                        {
                            if (i == 1)
                            {
                                if (worksheet.Cells[i, j].Value != null)
                                {
                                    DataColumn column = new DataColumn(worksheet.Cells[i, j].Value.ToString());
                                    table.Columns.Add(column);
                                }
                            }
                            else
                            {
                                dataRow[j - 1] = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : null;

                            }
                        }
                    }
                    return Content(" <script>alert('请先登录');history.go(-1);</script>");
                    
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
