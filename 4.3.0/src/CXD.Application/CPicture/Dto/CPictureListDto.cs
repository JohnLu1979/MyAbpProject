using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.CPictureService.Dto
{
    [AutoMapFrom(typeof(CXD.Entities.CPicture))]
    public  class CPictureListDto: FullAuditedEntity<int>
    {
        public virtual string Title { get; set; }
        public virtual string ImgUrl { get; set; }
    }
}
