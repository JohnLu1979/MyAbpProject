using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
    public enum WeatherType {
        Short_Term = 1,
        Xun = 2,
        Month = 3,
        Quater = 4,
        Year = 5,
        Month_Report = 6
    }
    public class CWeather:FullAuditedEntity<int>
    {
        public virtual string Title { get; set; }
        public virtual WeatherType Type { get; set; }
        public virtual string Content { get; set; }        
    }
}
