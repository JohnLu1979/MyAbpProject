using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXD.Current.Dto
{
    public class CurrentDataDto
    {
        public virtual DateTime Time { get; set; }
        public virtual string StationName { get; set; }
        public virtual decimal t2_speed { get; set; }
        public virtual decimal t2_direct { get; set; }
        public virtual decimal t4_speed { get; set; }
        public virtual decimal t4_direct { get; set; }
        public virtual decimal t6_speed { get; set; }
        public virtual decimal t6_direct { get; set; }
        public virtual decimal t8_speed { get; set; }
        public virtual decimal t8_direct { get; set; }
        public virtual decimal t10_speed { get; set; }
        public virtual decimal t10_direct { get; set; }
        public virtual decimal t12_speed { get; set; }
        public virtual decimal t12_direct { get; set; }
        public virtual decimal t14_speed { get; set; }
        public virtual decimal t14_direct { get; set; }
        public virtual decimal t16_speed { get; set; }
        public virtual decimal t16_direct { get; set; }
        public virtual decimal t18_speed { get; set; }
        public virtual decimal t18_direct { get; set; }
        public virtual decimal t20_speed { get; set; }
        public virtual decimal t20_direct { get; set; }
        public virtual decimal t22_speed { get; set; }
        public virtual decimal t22_direct { get; set; }
        public virtual decimal t24_speed { get; set; }
        public virtual decimal t24_direct { get; set; }
        public virtual decimal t26_speed { get; set; }
        public virtual decimal t26_direct { get; set; }
        public virtual decimal t28_speed { get; set; }
        public virtual decimal t28_direct { get; set; }
        public virtual decimal t30_speed { get; set; }
        public virtual decimal t30_direct { get; set; }
        public virtual decimal t32_speed { get; set; }
        public virtual decimal t32_direct { get; set; }
        public virtual decimal t34_speed { get; set; }
        public virtual decimal t34_direct { get; set; }
        public virtual decimal t36_speed { get; set; }
        public virtual decimal t36_direct { get; set; }
        public virtual decimal t38_speed { get; set; }
        public virtual decimal t38_direct { get; set; }
        public virtual decimal t40_speed { get; set; }
        public virtual decimal t40_direct { get; set; }
        public virtual decimal t42_speed { get; set; }
        public virtual decimal t42_direct { get; set; }
        public virtual decimal t44_speed { get; set; }
        public virtual decimal t44_direct { get; set; }
        public virtual decimal t46_speed { get; set; }
        public virtual decimal t46_direct { get; set; }
        public virtual decimal t48_speed { get; set; }
        public virtual decimal t48_direct { get; set; }
        public virtual decimal t50_speed { get; set; }
        public virtual decimal t50_direct { get; set; }
        public virtual decimal t52_speed { get; set; }
        public virtual decimal t52_direct { get; set; }
        public virtual decimal t54_speed { get; set; }
        public virtual decimal t54_direct { get; set; }
        public virtual decimal t56_speed { get; set; }
        public virtual decimal t56_direct { get; set; }
        public virtual decimal t58_speed { get; set; }
        public virtual decimal t58_direct { get; set; }
        public virtual decimal t60_speed { get; set; }
        public virtual decimal t60_direct { get; set; }
    }
    public class CurrentItemDto {
        public virtual decimal speed { get; set; }
        public virtual decimal direct { get; set; }
    }
    public class CurrentDto
    {
        public virtual DateTime Time { get; set; }
        public virtual string StationName { get; set; }
        public virtual CurrentItemDto t2 { get; set; }
        public virtual CurrentItemDto t4 { get; set; }
        public virtual CurrentItemDto t6 { get; set; }
        public virtual CurrentItemDto t8 { get; set; }
        public virtual CurrentItemDto t10 { get; set; }
        public virtual CurrentItemDto t12 { get; set; }
        public virtual CurrentItemDto t14 { get; set; }
        public virtual CurrentItemDto t16 { get; set; }
        public virtual CurrentItemDto t18 { get; set; }
        public virtual CurrentItemDto t20 { get; set; }
        public virtual CurrentItemDto t22 { get; set; }
        public virtual CurrentItemDto t24 { get; set; }
        public virtual CurrentItemDto t26 { get; set; }
        public virtual CurrentItemDto t28 { get; set; }
        public virtual CurrentItemDto t30 { get; set; }
        public virtual CurrentItemDto t32 { get; set; }
        public virtual CurrentItemDto t34 { get; set; }
        public virtual CurrentItemDto t36 { get; set; }
        public virtual CurrentItemDto t38 { get; set; }
        public virtual CurrentItemDto t40 { get; set; }
        public virtual CurrentItemDto t42 { get; set; }
        public virtual CurrentItemDto t44 { get; set; }
        public virtual CurrentItemDto t46 { get; set; }
        public virtual CurrentItemDto t48 { get; set; }
        public virtual CurrentItemDto t50 { get; set; }
        public virtual CurrentItemDto t52 { get; set; }
        public virtual CurrentItemDto t54 { get; set; }
        public virtual CurrentItemDto t56 { get; set; }
        public virtual CurrentItemDto t58 { get; set; }
        public virtual CurrentItemDto t60 { get; set; }
    }
}
