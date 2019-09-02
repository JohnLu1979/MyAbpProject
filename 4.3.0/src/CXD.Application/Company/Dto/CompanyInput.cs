using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Company.Dto
{
  public   class CompanyInput : CBaseInput
    {
        public virtual string CompanyName { get; set; }
        public virtual string CompanyAddress { get; set; }
        public virtual string Contactor { get; set; }
        public virtual string Mobile { get; set; }
    }
}
