using CXD.Base.Dto;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Tide.Dto
{
    public class CTideInput : CBaseInput
    {
        public string File_Base64 { get; set; }
        public virtual DateTime? PublicDateFrom { get; set; }
        public virtual DateTime? PublicDateTo { get; set; }
        public virtual DateTime PublicDate { get; set; }
        public virtual string MoonDate { get; set; }
        public virtual DateTime Flood1 { get; set; }
        public virtual DateTime Ebb1 { get; set; }
        public virtual DateTime Flood2 { get; set; }
        public virtual DateTime Ebb2 { get; set; }
    }
}
