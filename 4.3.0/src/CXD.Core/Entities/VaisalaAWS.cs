using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
    public class VaisalaAWS:Entity
    {
        public virtual DateTime Obstime { get; set; }
        public virtual string Sno { get; set; }
        public virtual string Dm { get; set; }
        public virtual string Sm { get; set; }
        public virtual string Ta { get; set; }
        public virtual string Tp { get; set; }
        public virtual string Ua { get; set; }
        public virtual string Pa { get; set; }
        public virtual string Rc { get; set; }
        public virtual string Rd { get; set; }
        public virtual string Ri { get; set; }
        public virtual string Hc { get; set; }
        public virtual string Th { get; set; }
        public virtual string Vh { get; set; }
        public virtual string Vs { get; set; }
        public virtual string Vr { get; set; }
    }
}
