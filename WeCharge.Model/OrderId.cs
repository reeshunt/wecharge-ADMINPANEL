using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model
{
    [Table("TBL_R_ORDER_ID")]
    public class OrderId : BaseModel
    {
        public long ORDER_ID { get; set; }
    }
}
