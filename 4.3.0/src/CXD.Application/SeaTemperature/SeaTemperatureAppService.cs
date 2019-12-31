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
using CXD.SeaTemperature.Dto;
using CXD.SQLQuery;
using CXD.Weather.Dto;

namespace CXD.SeaTemperature
{
    public class SeaTemperatureAppService : CBaseAppService, ISeaTemperatureAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        private readonly IRepository<CSeaTemperature> _seaTemperatureRepository;
        public SeaTemperatureAppService(ISqlExecuter sqlExecuter, IRepository<CSeaTemperature> seaTemperatureRepository) : base()
        {
            this._sqlExecuter = sqlExecuter;
            this._seaTemperatureRepository = seaTemperatureRepository;
        }

        public Task<CDataResults<CSeaTemperatureDto>> GetSeaTemperatureByToday(CSeaTemperatureInput input)
        {
            string sql = "select time as Time,t3 as T3,t6 as T6,t9 as T9,t12 as T12,t20 as T20 from viewSeaTemperature";
            sql += " where station_name = '" + input.StationCode + "'";
            if (input.QueryDateTime.HasValue)
            {
                sql += " and time > '" + input.QueryDateTime.Value.ToString("yyyy-MM-dd") + "'";
            }
            var list = _sqlExecuter.SqlQuery<CSeaTemperatureDto>(sql);
            var result = list.ToList();
            return Task.FromResult(new CDataResults<CSeaTemperatureDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = result.Count
            });
        }
        public Task<CDataResults<CUnusualDto>> GetUnusualData(CSeaTemperatureInput input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  station_name , SUM(CASE WHEN t3 < 0  THEN - 1 WHEN  t3 IS NULL THEN - 1  ELSE  0 END)   AS t3");
            sb.Append(", SUM(CASE WHEN t6 < 0  THEN - 1 WHEN  t6 IS NULL THEN - 1  ELSE  0 END )   AS t6");
            sb.Append("  , SUM(CASE WHEN t9 < 0  THEN - 1 WHEN  t9 IS NULL THEN - 1  ELSE  0 END )   AS t9");
            sb.Append(" , SUM(CASE WHEN t12 < 0  THEN - 1 WHEN  t12 IS NULL THEN - 1  ELSE  0 END )   AS t12");
            sb.Append(" , SUM(CASE WHEN t20 < 0  THEN - 1 WHEN  t20 IS NULL THEN - 1  ELSE  0 END )   AS t20 FROM ViewSeaTemperature");
            sb.Append(" where time >= '" + input.QueryDateTime.Value.ToString("yyyy-MM-dd") + " 00:00:00' and [time] <= '" + input.QueryDateTime.Value.ToString("yyyy-MM-dd") + " 23:59:59'  GROUP BY station_name");
            var list = _sqlExecuter.SqlQuery<CUnusualDto>(sb.ToString());
            var result = list.ToList();
            return Task.FromResult(new CDataResults<CUnusualDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = result.Count
            });
        }

    }

}
