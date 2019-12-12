using CXD.Base.Dto;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.SeaTemperature.Dto
{
    public class CSeaTemperatureInput : CBaseInput
    {
        public string StationCode { get; set; }
        public DateTime? QueryDateTime { get; set; }
    }
}
