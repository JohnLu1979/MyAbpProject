using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Entities
{
    [Table("viewSeaTemperature")]
    public class CSeaTemperature:Entity
    {
        [Column("station_name")]
        public virtual string StationName { get; set; }
        [Column("time")]
        public virtual DateTime? Time { get; set; }
        [Column("t3")]
        public virtual double T3 { get; set; }
        [Column("t6")]
        public virtual double T6 { get; set; }
        [Column("t9")]
        public virtual double T9 { get; set; }
        [Column("t12")]
        public virtual double T12 { get; set; }
        [Column("t20")]
        public virtual double T20 { get; set; }
    }
}
