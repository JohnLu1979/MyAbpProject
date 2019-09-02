﻿using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CXD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Tide.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CTide))]
    public class CTideDto : Entity<int>
    {
        public virtual DateTime PublicDate { get; set; }
        public virtual string MoonDate { get; set; }
        public virtual DateTime Flood1 { get; set; }
        public virtual DateTime Ebb1 { get; set; }
        public virtual DateTime Flood2 { get; set; }
        public virtual DateTime Ebb2 { get; set; }
        public virtual int CompanyId { get; set; }
    }

}

