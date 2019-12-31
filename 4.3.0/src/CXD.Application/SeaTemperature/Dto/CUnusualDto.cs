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
  public  class CUnusualDto
    {
        public virtual string station_name { get; set; }
        public virtual int? T3 { get; set; }
        public virtual int? T6 { get; set; }
        public virtual int? T9 { get; set; }
        public virtual int? T12 { get; set; }
        public virtual int? T20 { get; set; }
    }
}
