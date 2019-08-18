using Abp.Collections.Extensions;
using Abp.Web.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CXD.Api.Common
{
    public static class ExcelExporter<T>
    {
        /// <summary>
        /// 导出Excel文件
        /// </summary>
        /// <returns></returns>
        public static AjaxResponse GetFileResponse(string fileName, string sheetName, IList<T> dtoList, string[] header, Func<T, object>[] propertySelectors)
        {
            AjaxResponse res = new AjaxResponse();
            try
            {
                byte[] data = ExportExcelStream(sheetName, dtoList, header, propertySelectors);

                var Response = HttpContext.Current.Response;
                //Response.Clear();
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                //Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
                //Response.BinaryWrite(data);
                //Response.End();
                // 清除缓存区流中的所有内容输出
                Response.Clear();
                // 设置缓冲输出为true,后台编辑的文件写到内存流中了
                Response.Buffer = true;
                // 设置编码格式 ContentEncoding是管字节流到文本的，而Charset是管在浏览器中显示的
               //Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                Response.Charset = "UTF-8";
                // 将HTTP头添加到输出流，指定默认名
                Response.AddHeader("Content-Disposition", string.Format(@"attachment;filename={0}", fileName));
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                // 设置输出流的HTTP MIME类型为application/vnd.ms-excel
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Length", data.Length.ToString());
                // 将指定的文件写入HTTP内容输出流
                Response.OutputStream.Write(data, 0, data.Length);
                //防止文件名含中文出现乱码而进行编码
                // Response.BinaryWrite(bytes);
                // 向客户端发送当前所有缓冲的输出
                Response.Flush();
                // 将当前所有缓冲的输出关闭
                Response.Close();
                
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Error = new ErrorInfo();
                res.Error.Code = 500;
                res.Error.Message = "导出数据错误";
                res.Error.Details = ex.ToString();
            }

            return res;
        }

        public static byte[] ExportExcelStream(string sheetName, IList<T> dtoList, string[] header, Func<T, object>[] propertySelectors)
        {
            return CreateExcelStream(
                    excelPackage =>
                    {
                        var sheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                        sheet.OutLineApplyStyle = true;
                        AddHeader(sheet, header);
                        AddObjects(sheet, 2, dtoList, propertySelectors);

                        for (var i = 1; i <= header.Length; i++)
                        {
                            sheet.Column(i).AutoFit();
                        }
                    });
        }

        public static byte[] CreateExcelStream(Action<ExcelPackage> creator)
        {
            using (var excelPackage = new ExcelPackage())
            {
                creator(excelPackage);
                MemoryStream ms = new MemoryStream();
                excelPackage.SaveAs(ms);
                FileStream fs = new FileStream(@"e:\test.xlsx", FileMode.Create);
                excelPackage.SaveAs(fs);
                fs.Close();
                return ms.GetBuffer();
            }
        }

        public static void AddHeader(ExcelWorksheet sheet, params string[] headerTexts)
        {
            if (headerTexts.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < headerTexts.Length; i++)
            {
                AddHeader(sheet, i + 1, headerTexts[i]);
            }
        }

        public static void AddHeader(ExcelWorksheet sheet, int columnIndex, string headerText)
        {
            sheet.Cells[1, columnIndex].Value = headerText;
            sheet.Cells[1, columnIndex].Style.Font.Bold = true;
        }

        public static void AddObjects<T>(ExcelWorksheet sheet, int startRowIndex, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            if (items.IsNullOrEmpty() || propertySelectors.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < items.Count; i++)
            {
                for (var j = 0; j < propertySelectors.Length; j++)
                {
                    sheet.Cells[i + startRowIndex, j + 1].Value = propertySelectors[j](items[i]);
                }
            }
        }
    }
}
