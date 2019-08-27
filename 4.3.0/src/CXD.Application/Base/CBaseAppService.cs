using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CXD.Base
{
    public class CBaseAppService: CXDAppServiceBase
    {
        public CBaseAppService()
        {
        }
        protected bool Base64StringToFile(String fileData, string fileName)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(fileData);
                Stream s = new FileStream(fileName, FileMode.Append);

                s.Write(arr, 0, arr.Length);

                s.Close();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        protected String FileToBase64String(string fileName)
        {
            try
            {
                Stream s = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] arr = new byte[s.Length];
                s.Read(arr, 0, arr.Length);
                s.Close();
                return Convert.ToBase64String(arr);
            }
            catch
            {
                return null;
            }
        }

        protected string GenerateNewFileName(int randomNum)
        {
            var fileNameBuilder = new StringBuilder();

            fileNameBuilder = fileNameBuilder.Append(DateTime.Now.ToString("yyyyMMddHHmmss")).Append("_");
            fileNameBuilder = fileNameBuilder.Append(new Random().Next(randomNum));
            fileNameBuilder = fileNameBuilder.Append(".").Append("jpeg");
            return fileNameBuilder.ToString();
        }

        protected string GetFileURL(string path, string fileName)
        {
            var urlBuilder = new StringBuilder(path);
            if (!path.StartsWith("/"))
            {
                urlBuilder = urlBuilder.Insert(0, "/");
            }
            if (!path.EndsWith("/"))
            {
                urlBuilder = urlBuilder.Append("/");
            }
            urlBuilder = urlBuilder.Append(fileName);
            return urlBuilder.ToString();
        }
        protected string GetFilePath(string path, string fileName)
        {
            string newFileName = string.Empty;
            newFileName = Path.Combine(HttpContext.Current.Server.MapPath(@"\"), path);
            newFileName = Path.Combine(newFileName, fileName);
            return newFileName;
        }
    }
}
