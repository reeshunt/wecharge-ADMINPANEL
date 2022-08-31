using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model
{
    [Table("TBL_R_PAYMENT_MODE")]
    public class PaymentMode:BaseModel
    {
        public string MODE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
        public int ROLE_ID { get; set; }

    }
}
