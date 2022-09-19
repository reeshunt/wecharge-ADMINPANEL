using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
    public class UserDTO :BaseModel
    {
		public int ROLE_ID { get; set; }
		public string FULL_NAME { get; set; }
		public string MOBILE_NO { get; set; }
		public string EMAIL { get; set; }
		public string PASSWORD_HASH { get; set; }
		public string CREATED_BY { get; set; }
		public DateTime CREATED_DATE { get; set; }
		public string MODIFIED_BY { get; set; }
		public DateTime MODOFIED_DATE { get; set; }
		public string IMAGE_PATH { get; set; }
		public bool IS_ACTIVE { get; set; }
		public int TotalRecords { get; set; }
		public string ROLENAME { get; set; }
	}
}
