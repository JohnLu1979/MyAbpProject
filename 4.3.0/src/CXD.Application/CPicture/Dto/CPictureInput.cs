using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.CPictureService.Dto
{
    public class CPictureInput : CBaseInput
    {
        public virtual string Title { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual int DisplayIndex { get; set; }
        public virtual string ImgUrl { get; set; }
        public string File_Base64 { get; set; }
    }
}
