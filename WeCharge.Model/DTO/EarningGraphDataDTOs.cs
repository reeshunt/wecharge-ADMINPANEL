using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
	public class EarningGraphDataDTOs :BaseModel
	{
		public string MONTH { get; set; }
		public string YEAR { get; set; }
		public decimal EARNING { get; set; }
	}
}
