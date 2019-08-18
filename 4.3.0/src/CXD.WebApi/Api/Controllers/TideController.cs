using Abp.Domain.Repositories;
using Abp.Web.Models;
using Abp.WebApi.Controllers;
using CXD.Api.Common;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Api.Controllers
{
    public class TideController: AbpApiController
    {
        private readonly IRepository<CTide, int> _tideRepository;

        public TideController(IRepository<CTide, int> tideRepository)
        {
            this._tideRepository = tideRepository;
        }
        /// <summary>
        /// 导出列表到Excel
        /// </summary>
        /// <param name="search">查询条件对象</param>
        public AjaxResponse ExportListToExcel()
        {
            int rowCount = 0;
            var list = this._tideRepository.GetAll().Select(t => new TideList {
                PublicDate = t.PublicDate.ToString(),
                MoonDate = t.MoonDate,
                Flood1 = t.Flood1.ToString(),
                Ebb1 = t.Ebb1.ToString(),
                Flood2 = t.Flood2.ToString(),
                Ebb2 = t.Ebb2.ToString()
            }).ToList();
            string fileName = "List.xlsx";
            string sheetName = "列表";
            const int columnCount = 6;
            string[] header = new string[columnCount] { "公历日期", "阴历日期", "涨潮", "退潮", "涨潮", "退潮" };
            Func<TideList, object>[] propertySelectors = new Func<TideList, object>[columnCount] {
                new Func<TideList, string>(l => l.PublicDate),
                new Func<TideList, string>(l => l.MoonDate),
                new Func<TideList, string>(l => l.Flood1),
                new Func<TideList, string>(l => l.Ebb1),
                new Func<TideList, string>(l => l.Flood2),
                new Func<TideList, string>(l => l.Ebb2)
            };
            return ExcelExporter<TideList>.GetFileResponse(fileName, sheetName, list, header, propertySelectors);
        }

        //public async Task<IActionResult> FileSave(List<IFormFile> files)
        //{
        //    var files = Request.Form.Files;
        //    long size = files.Sum(f => f.Length);
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    string contentRootPath = _hostingEnvironment.ContentRootPath;
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {

        //            string fileExt = GetFileExt(formFile.FileName); //文件扩展名，不含“.”
        //            long fileSize = formFile.Length; //获得文件大小，以字节为单位
        //            string newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
        //            var filePath = webRootPath + "/upload/" + newFileName;
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {

        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    return Ok(new { count = files.Count, size });
        //}
    }
    public class TideList
    {
        public string PublicDate { get; set; }
        public string MoonDate { get; set; }
        public string Flood1 { get; set; }
        public string Ebb1 { get; set; }
        public string Flood2 { get; set; }
        public string Ebb2 { get; set; }
    }
}
