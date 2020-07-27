using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.VaisalaAWS.Dto
{
    public class VaisalaAWSInput: CBaseInput
    {
        public virtual DateTime? Obstime { get; set; }
    }
}
