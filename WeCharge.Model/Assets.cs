using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model
{
#nullable disable
    [Dapper.Contrib.Extensions.Table("TBL_M_ASSETS")]
    public class Assets : BaseModel
    {
		[Required]
		public int? USER_ID { get; set; }
		[Required]
		public string EQUIPMENT_NAME { get; set; }
		public int FUEL_TYPE_ID { get; set; }
		[Required]
		public string EMAIL { get; set; }
		[Required]
		public string MOBILE_NO { get; set; }
		public bool IS_ACTIVE { get; set; }
		public string CREATED_BY { get; set; }
		public DateTime CREATED_DATE { get; set; }
		public string MODIFIED_BY { get; set; }
		public DateTime MODIFIED_DATE { get; set; }
    }
}
