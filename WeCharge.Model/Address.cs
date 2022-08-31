using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model
{
    [Table("TBL_M_ADDRESS")]
    public class Address:BaseModel
    {
        public int USER_ID { get; set; }
        public string ADDRESS_TITLE { get; set; }
        public string FULL_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string ADDRESS_CONTACT { get; set; }
        public string ADDRESS_PINCODE { get; set; }
        public string GST_NO { get; set; }
        public string ADDRESS_TAG { get; set; }
        public bool IS_DEFAULT_ADDRESS { get; set; }
        public bool IS_BILLING_ADDRESS { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
    }
}
