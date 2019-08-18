using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Notice.Dto
{
  public  class NoticeInput:CBaseInput
    {
        public virtual string Title { get; set; }
    }
}
