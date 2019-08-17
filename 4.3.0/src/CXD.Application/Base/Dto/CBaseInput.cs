using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Base.Dto
{
    public class CBaseInput:Entity<int>
    {
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
    }
}