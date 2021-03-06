﻿using CXD.Base.Dto;
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
        public virtual string FloodTime1 { get; set; }
        public virtual string FloodHigh1 { get; set; }
        public virtual string FloodTime2 { get; set; }
        public virtual string FloodHigh2 { get; set; }
        public virtual string FloodTime3 { get; set; }
        public virtual string FloodHigh3 { get; set; }
        public virtual string FloodTime4 { get; set; }
        public virtual string FloodHigh4 { get; set; }
        public virtual string StationCode { get; set; }
        public virtual int CompanyId { get; set; }
    }
}
