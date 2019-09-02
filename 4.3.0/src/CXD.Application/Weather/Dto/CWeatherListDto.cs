using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Weather.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CWeather))]
    public class CWeatherDto : FullAuditedEntity<int>
    {
        public virtual string Title { get; set; }
        public virtual WeatherType Type { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual string Content { get; set; }
    }

}

