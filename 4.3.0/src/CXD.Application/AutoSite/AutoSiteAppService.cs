using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.SQLQuery;
using CXD.VaisalaAWS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.AutoSite
{
    public class AutoSiteAppService : CBaseAppService, IAutoSiteAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        public AutoSiteAppService(ISqlExecuter sqlExecuter) : base()
        {
            this._sqlExecuter = sqlExecuter;
        }
        public Task<CDataResults<VaisalaAWSListDto>> GetAutoSiteDataByToday()
        {

            var result = GetAutoSiteByToday();

            return Task.FromResult(new CDataResults<VaisalaAWSListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = result.Count
            });
        }

        public Task<CDataResult<VaisalaAWSListDto>> GetLastAutoSiteByToday()
        {
            var result = GetAutoSiteByToday();
            if (result != null && result.Count > 0)
            {
                return Task.FromResult(new CDataResult<VaisalaAWSListDto>()
                {
                    IsSuccess = true,
                    ErrorMessage = null,
                    Data = result[0]
                });
            }
            else
            {
                return Task.FromResult(new CDataResult<VaisalaAWSListDto>()
                {
                    IsSuccess = false,
                    ErrorMessage = "No Data.",
                    Data = null
                });
            }
        }

        private List<VaisalaAWSListDto> GetAutoSiteByToday()
        {
            string sql = "select CONVERT(varchar(100), obstime, 8) as obstime,RTRIM(Sno) as Sno,RTRIM(Dm) as Dm, RTRIM(Sm) as Sm, RTRIM(Ta) as Ta, RTRIM(Ua) as Ua, RTRIM(Pa) as Pa from VaisalaAWS";
            DateTime firstDay = DateTime.Today.Date;
            DateTime endDay = firstDay.Date.AddDays(1);
            sql += " where obstime >= '" + firstDay.ToString("yyyy-MM-dd") + "'";
            sql += " and obstime < '" + endDay.ToString("yyyy-MM-dd") + "'";
            sql += " order by obstime desc";
            var list = _sqlExecuter.SqlQuery<VaisalaAWSListDto>(sql);
            return list.ToList();
        }
    }
}
