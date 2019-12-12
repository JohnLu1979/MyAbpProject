using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.SeaTemperature.Dto
{
    public class CSeaTemperatureDto
    {
        // public virtual string StationName { get; set; }
        public virtual DateTime? Time { get; set; }
        public virtual decimal? T3 { get; set; }
        public virtual decimal? T6 { get; set; }
        public virtual decimal? T9 { get; set; }
        public virtual decimal? T12 { get; set; }
        public virtual decimal? T20 { get; set; }
    }

}

