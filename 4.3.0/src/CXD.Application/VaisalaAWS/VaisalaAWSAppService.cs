using Abp.Domain.Repositories;
using CXD.Base;
using CXD.Base.Dto;
using CXD.Entities;
using CXD.SQLQuery;
using CXD.vaisala_wxt536_view.Dto;
using CXD.VaisalaAWS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.VaisalaAWS
{
    public class VaisalaAWSAppService : CBaseAppService, IVaisalaAWSAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        private readonly IRepository<CXD.Entities.VaisalaAWS> _vaisalaAWSRepository;
        public VaisalaAWSAppService(ISqlExecuter sqlExecuter, IRepository<CXD.Entities.VaisalaAWS> vaisalaAWSRepository) : base()
        {
            this._sqlExecuter = sqlExecuter;
            this._vaisalaAWSRepository = vaisalaAWSRepository;
        }
        public Task<CDataResults<VaisalaAWSTaListDto>> GetVaisalaAWSTaByMonth()
        {
            string sql = "select obstime,ta from VaisalaAWS";
            DateTime firstDay = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime endDay = firstDay.Date.AddMonths(1);
            sql += " where obstime >= '" + firstDay.ToString("yyyy-MM-dd") + "'";
            sql += " and obstime < '" + endDay.ToString("yyyy-MM-dd") + "'";         
            sql += " order by obstime";
            var list = _sqlExecuter.SqlQuery<VaisalaAWSTaListDto>(sql);
            
            var dbResult = list.ToList();
            List<VaisalaAWSTaListDto> result = new List<VaisalaAWSTaListDto>();
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                decimal ta = 0;
                int taCount = 0;
                foreach (var item in dbResult)
                {
                    if (item.Obstime.Day == i)
                    {
                        decimal tempTa;
                        if (decimal.TryParse(item.Ta, out tempTa))
                        {
                            ta += tempTa;
                            taCount++;
                        }
                    }
                }
                if (taCount > 0)
                {
                    var aveTa = ta / taCount;
                    DateTime monthDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);
                    result.Add(new VaisalaAWSTaListDto() { Obstime = monthDate, Ta = decimal.Round(aveTa, 1).ToString() });
                }
            }

            return Task.FromResult(new CDataResults<VaisalaAWSTaListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = result.Count
            });
        }

        public Task<CDataResults<VaisalaAWSTaListDto>> GetVaisalaAWSTaByToday()
        {
            string sql = "select obstime,ta from VaisalaAWS";
            DateTime nextDate = DateTime.Today.AddDays(1);
            sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";           
            sql += " order by obstime";

            var list = _sqlExecuter.SqlQuery<VaisalaAWSTaListDto>(sql);
            var dbResult = list.ToList();
            List<VaisalaAWSTaListDto> result = new List<VaisalaAWSTaListDto>();
            for (int i = 0; i <= DateTime.Now.Hour; i++)
            {
                decimal ta = 0;
                int taCount = 0;
                foreach (var item in dbResult)
                {
                    if (item.Obstime.Hour == i)
                    {
                        decimal tempTa;
                        if (decimal.TryParse(item.Ta, out tempTa))
                        {
                            ta += tempTa;
                            taCount++;
                        }
                    }
                }
                if (taCount > 0)
                {
                    var aveTa = ta / taCount;
                    result.Add(new VaisalaAWSTaListDto() { Obstime = DateTime.Today.AddHours(i), Ta = decimal.Round(aveTa, 1).ToString() });
                }
            }
            return Task.FromResult(new CDataResults<VaisalaAWSTaListDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result,
                Total = result.Count
            });
        }

        public Task<CDataResult<VaisalaAWSTaShelfDto>> GetVaisalaAWSTaShelfByToday()
        {
            VaisalaAWSTaShelfDto result = new VaisalaAWSTaShelfDto();
            result.currentTa = string.Empty;
            result.maxTa = string.Empty;
            result.minTa = string.Empty;
            result.averageTa = string.Empty;
            DateTime nextDate = DateTime.Today.AddDays(1);
            string sql = "select top 1 cast(ta as decimal) from VaisalaAWS";
            sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";

            var currentTa = _sqlExecuter.SqlQuery<decimal>(sql);
            if (currentTa.Count() > 0)
            {
                result.currentTa = Decimal.Round(currentTa.First(), 1).ToString();
            }

            sql = "select count(*) as c from VaisalaAWS";
            sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";

            var countTa = _sqlExecuter.SqlQuery<int>(sql);
            if (countTa.First() > 0)
            {
                sql = "select max(cast(ta as decimal)) as ta from VaisalaAWS";
                sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";

                var maxTa = _sqlExecuter.SqlQuery<decimal>(sql);
                if (maxTa.FirstOrDefault() > 0)
                {
                    result.maxTa = Decimal.Round(maxTa.First(), 1).ToString();
                }

                sql = "select min(cast(ta as decimal)) as ta from VaisalaAWS";
                sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";

                var minTa = _sqlExecuter.SqlQuery<decimal>(sql);
                if (minTa.Count() > 0)
                {
                    result.minTa = Decimal.Round(minTa.First(), 1).ToString();
                }

                sql = "select avg(cast(ta as decimal)) as ta from VaisalaAWS";
                sql += " where obstime >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                sql += " and obstime < '" + nextDate.ToString("yyyy-MM-dd") + "'";

                var averageTa = _sqlExecuter.SqlQuery<decimal>(sql);
                if (averageTa.Count() > 0)
                {
                    result.averageTa = Decimal.Round(averageTa.First(), 1).ToString();
                }
            }

            return Task.FromResult(new CDataResult<VaisalaAWSTaShelfDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result
            });
        }
    }
}
