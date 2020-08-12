using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Current.Dto
{
    public class CurrentInput : CBaseInput
    {
        public virtual string station_name { get; set; }
    }
}
