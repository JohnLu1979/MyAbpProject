using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Entities;
using CXD.Tide;
using CXD.Tide.Dto;
using CXD.App.Common;
using System.IO;

namespace CXD.WmtRain
{
    public class TideAppService : CBaseAppService, ITideAppService
    {

        private readonly IRepository<CTide, int> _TideRepository;

        public TideAppService(
            IRepository<CTide, int> TideRepository

            ) : base()
        {
            this._TideRepository = TideRepository;

        }

        public Task<CDataResults<CTideDto>> GetTides(CTideInput input)
        {
            //Extract data from DB
            var query = this._TideRepository.GetAll();
            if (input.PublicDateFrom.HasValue) {
                query = query.Where(r => r.PublicDate >= input.PublicDateFrom);
            }
            if (input.PublicDateTo.HasValue)
            {
                query = query.Where(r => r.PublicDate <= input.PublicDateTo);
            }
            var total = query.Count();
            if (input.pageNumber.HasValue && input.pageNumber.Value > 0 && input.pageSize.HasValue)
            {
                query = query.OrderByDescending(r => r.Id).Take(input.pageSize.Value * input.pageNumber.Value).Skip(input.pageSize.Value * (input.pageNumber.Value - 1));
            }
            else {
                query = query.OrderByDescending(r => r.Id);
            }

            var result = query.ToList().MapTo<List<CTideDto>>();

            return Task.FromResult(new CDataResults<CTideDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = total
            });
        }

        public CDataResult<int> AddTide(CTideInput input) {
            var newTide = new CTide()
            {
                PublicDate = input.PublicDate,
                MoonDate = input.MoonDate,
                Ebb1 =input.Ebb1,
                Ebb2 = input.Ebb2,
                Flood1 = input.Flood1,
                Flood2 = input.Flood2
            };

            var newTideId = this._TideRepository.InsertAndGetId(newTide);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = newTideId
            };
        }

        public CDataResult<CTideDto> UpdateTide(CTideInput input)
        {
            var result = new CDataResult<CTideDto>()
            {
                IsSuccess = false,
                ErrorMessage = null,
                Data = null
            };
            var Tide = this._TideRepository.Get(input.Id);
            if (Tide == null) {
                result.IsSuccess = false;
            }
            Tide.PublicDate = input.PublicDate;
            Tide.MoonDate = input.MoonDate;
            Tide.Ebb1 = input.Ebb1;
            Tide.Ebb2 = input.Ebb2;
            Tide.Flood1 = input.Flood1;
            Tide.Flood2 = input.Flood2;

            var updatedTide = this._TideRepository.Update(Tide);

            if (updatedTide == null)
            {
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                result.Data = updatedTide.MapTo<CTideDto>();
            }
            return result;
        }

        public CDataResult<int> DeleteTide(CTideInput input) {
            this._TideRepository.Delete(input.Id);
            return new CDataResult<int>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = 1
            };
        }

        public CDataResult<CTideDto> GetTide(CTideInput input)
        {
            var Tide = this._TideRepository.Get(input.Id);
            if (Tide == null)
            {
                return new CDataResult<CTideDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = null,
                    Data = null
                };
            }
            else
            {
                return new CDataResult<CTideDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = Tide.MapTo<CTideDto>()
                };
            }
        }

        public CDataResult<string> ExportTides()
        {
            List<CTide> tides  =this._TideRepository.GetAll().ToList();
            string sheetName = "潮汐时间表";
            const int columnCount = 6;
            string[] header = new string[columnCount] { "公历日期", "阴历日期", "涨潮", "退潮", "涨潮", "退潮" };
            Func<CTide, object>[] propertySelectors = new Func<CTide, object>[columnCount] {
                new Func<CTide, string>(l => l.PublicDate.ToString("yyyy-MM-dd")),
                new Func<CTide, string>(l => l.MoonDate),
                new Func<CTide, string>(l => l.Flood1.ToString("HH:mm:ss")),
                new Func<CTide, string>(l => l.Ebb1.ToString("HH:mm:ss")),
                new Func<CTide, string>(l => l.Flood2.ToString("HH:mm:ss")),
                new Func<CTide, string>(l => l.Ebb2.ToString("HH:mm:ss"))
            };
            string filePath = ExcelExporter<CTide>.GenerateFile("Tide_",sheetName,tides,header,propertySelectors);

            return new CDataResult<string>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = filePath
            };
        }

        public CDataResult<bool> ImportTides(CTideInput input)
        {
            byte[] buffer = Convert.FromBase64String(input.File_Base64);
            MemoryStream ms = new MemoryStream(buffer);
            string sheetName = "潮汐时间表";
            string defaultDatePrefix = "1980-01-01 ";
            List<object[]> dataList = ExcelExporter<CTide>.ReadFile(ms, sheetName,20000,6,2);
            List<CTide> tideList = new List<CTide>();
            for (int i = 0; i < dataList.Count; i++)
            {
                object[] tideData = dataList[i];
                CTide tide = new CTide();
                DateTime publicDate;
                if (!DateTime.TryParse(tideData[0].ToString(), out publicDate)) continue;
                tide.PublicDate = publicDate;                
                tide.MoonDate = tideData[1].ToString();
                DateTime flood1Time;
                if (!DateTime.TryParse(defaultDatePrefix + tideData[2].ToString(), out flood1Time)) continue;
                tide.Flood1 = flood1Time;
                DateTime ebb1Time;
                if (!DateTime.TryParse(defaultDatePrefix + tideData[3].ToString(), out ebb1Time)) continue;
                tide.Ebb1 = ebb1Time;
                DateTime flood2Time;
                if (!DateTime.TryParse(defaultDatePrefix + tideData[4].ToString(), out flood2Time)) continue;
                tide.Flood2 = flood2Time;
                DateTime ebb2Time;
                if (!DateTime.TryParse(defaultDatePrefix + tideData[5].ToString(), out ebb2Time)) continue;
                tide.Ebb2 = ebb2Time;
                tideList.Add(tide);
            }
            List<CTide> oldTides = _TideRepository.GetAll().ToList();
            for (int i = 0; i < oldTides.Count; i++)
            {
                _TideRepository.Delete(oldTides[i]);
            }
            for (int i = 0; i < tideList.Count; i++)
            {
                _TideRepository.Insert(tideList[i]);
            }
            return new CDataResult<bool>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = true
            };
        }
    }

}
