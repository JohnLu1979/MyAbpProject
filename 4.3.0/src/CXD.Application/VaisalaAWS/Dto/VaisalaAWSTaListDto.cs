using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.VaisalaAWS.Dto
{
    public class VaisalaAWSTaListDto
    {
        public virtual DateTime Obstime { get; set; }
        public virtual string Ta { get; set; }
    }
    public class VaisalaAWSTaShelfDto { 
        public virtual string currentTa { get; set; }
        public virtual string maxTa { get; set; }
        public virtual string minTa { get; set; }
        public virtual string averageTa { get; set; }
    }
}
