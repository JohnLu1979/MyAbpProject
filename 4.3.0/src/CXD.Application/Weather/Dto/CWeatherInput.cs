using CXD.Base.Dto;
using CXD.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Weather.Dto
{
    public class CWeatherInput : CBaseInput
    {
        public virtual string Title { get; set; }
        public virtual WeatherType Type { get; set; }
        public virtual string Content { get; set; }
    }
}
