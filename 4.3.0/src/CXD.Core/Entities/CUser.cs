using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
    [Table("zzd_user")]
    public class CUser:Entity<int>
    {
        public virtual int CompanyId { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserType { get; set; }

    }
}
