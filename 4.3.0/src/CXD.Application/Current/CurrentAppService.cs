using CXD.Base;
using CXD.Base.Dto;
using CXD.Current.Dto;
using CXD.SQLQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Current
{
    public class CurrentAppService : CBaseAppService, ICurrentAppService
    {
        private readonly ISqlExecuter _sqlExecuter;
        public CurrentAppService(ISqlExecuter sqlExecuter) : base()
        {
            this._sqlExecuter = sqlExecuter;
        }
        public Task<CDataResult<CurrentDto>> GetCurrentInfo(CurrentInput input)
        {
            //throw new NotImplementedException();

            string sql = "select top 1 * from ViewCurrent";
            sql += " where StationName = '" + input.station_name + "'";
            sql += " order by time desc";
            var list = _sqlExecuter.SqlQuery<CurrentDataDto>(sql);

            var dbResult = list.ToList();
            CurrentDto result = new CurrentDto();
            if (dbResult.Count > 0) {
                var tempData = dbResult[0];
                result.Time = tempData.Time;
                result.StationName = tempData.StationName;
                result.t2 = new CurrentItemDto() { speed = tempData.t2_speed, direct = tempData.t2_direct };
                result.t4 = new CurrentItemDto() { speed = tempData.t4_speed, direct = tempData.t4_direct };
                result.t6 = new CurrentItemDto() { speed = tempData.t6_speed, direct = tempData.t6_direct };
                result.t8 = new CurrentItemDto() { speed = tempData.t8_speed, direct = tempData.t8_direct };
                result.t10 = new CurrentItemDto() { speed = tempData.t10_speed, direct = tempData.t10_direct };
                result.t12 = new CurrentItemDto() { speed = tempData.t12_speed, direct = tempData.t12_direct };
                result.t14 = new CurrentItemDto() { speed = tempData.t14_speed, direct = tempData.t14_direct };
                result.t16 = new CurrentItemDto() { speed = tempData.t16_speed, direct = tempData.t16_direct };
                result.t18 = new CurrentItemDto() { speed = tempData.t18_speed, direct = tempData.t18_direct };
                result.t20 = new CurrentItemDto() { speed = tempData.t20_speed, direct = tempData.t20_direct };
                result.t22 = new CurrentItemDto() { speed = tempData.t22_speed, direct = tempData.t22_direct };
                result.t24 = new CurrentItemDto() { speed = tempData.t24_speed, direct = tempData.t24_direct };
                result.t26 = new CurrentItemDto() { speed = tempData.t26_speed, direct = tempData.t26_direct };
                result.t28 = new CurrentItemDto() { speed = tempData.t28_speed, direct = tempData.t28_direct };
                result.t30 = new CurrentItemDto() { speed = tempData.t30_speed, direct = tempData.t30_direct };
                result.t32 = new CurrentItemDto() { speed = tempData.t32_speed, direct = tempData.t32_direct };
                result.t34 = new CurrentItemDto() { speed = tempData.t34_speed, direct = tempData.t34_direct };
                result.t36 = new CurrentItemDto() { speed = tempData.t36_speed, direct = tempData.t36_direct };
                result.t38 = new CurrentItemDto() { speed = tempData.t38_speed, direct = tempData.t38_direct };
                result.t40 = new CurrentItemDto() { speed = tempData.t40_speed, direct = tempData.t40_direct };
                result.t42 = new CurrentItemDto() { speed = tempData.t42_speed, direct = tempData.t42_direct };
                result.t44 = new CurrentItemDto() { speed = tempData.t44_speed, direct = tempData.t44_direct };
                result.t46 = new CurrentItemDto() { speed = tempData.t46_speed, direct = tempData.t46_direct };
                result.t48 = new CurrentItemDto() { speed = tempData.t48_speed, direct = tempData.t48_direct };
                result.t50 = new CurrentItemDto() { speed = tempData.t50_speed, direct = tempData.t50_direct };
                result.t52 = new CurrentItemDto() { speed = tempData.t52_speed, direct = tempData.t52_direct };
                result.t54 = new CurrentItemDto() { speed = tempData.t54_speed, direct = tempData.t54_direct };
                result.t56 = new CurrentItemDto() { speed = tempData.t56_speed, direct = tempData.t56_direct };
                result.t58 = new CurrentItemDto() { speed = tempData.t58_speed, direct = tempData.t58_direct };
                result.t60 = new CurrentItemDto() { speed = tempData.t60_speed, direct = tempData.t60_direct };
            }

            return Task.FromResult(new CDataResult<CurrentDto>()
            {
                IsSuccess = true,
                ErrorMessage = null,
                Data = result
            });
        }
    }
}
