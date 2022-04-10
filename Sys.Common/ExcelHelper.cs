using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sys.Common
{
    public class ExcelHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList">数据</param>
        /// <param name="headers">表头</param>
        /// <returns></returns>
        public static byte[] CreateExcelFromList<T>(List<T> dataList, List<string> headers)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                //创建sheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("My sheet");
                worksheet.Cells.LoadFromCollection(dataList, true);
                //表头字段
                for (int i = 0; i < headers.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }
                return package.GetAsByteArray();
            }
           
        }
    }
}
