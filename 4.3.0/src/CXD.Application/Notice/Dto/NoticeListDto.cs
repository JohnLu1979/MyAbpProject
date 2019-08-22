using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CXD.Entities;
using Abp.Domain.Entities.Auditing;

namespace CXD.Notice.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CNotice))]
   public class NoticeListDto : FullAuditedEntity<int>
    {
        public virtual string Title { get; set;}
        public virtual string NewsAuthor { get; set; }
        public virtual int DisplayIndex { get; set; }
            
        public virtual string NewsContent { get; set; }
    }
}
