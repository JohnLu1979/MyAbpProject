using CXD.Base.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Picture.DTO
{
    public class PictureInput : CBaseInput
    {
        public virtual string Title { get; set; }
        public virtual string ImgUrl { get; set; }

       public string File_Base64 { get; set; }
    }
}
