using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ESWIN.Admin.Web.Tool
{
    public class ExcelTool
    {
        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>

        public static DataSet ExcelGetDataTable(string excelPath)
        {
            using (FileStream stream = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var result = reader.AsDataSet();
                return result;
            }
        }
    }
}
