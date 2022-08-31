using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
    public class DashboardCountDTO : BaseModel
    {
        public int	TOTAL_ORDER { get; set; }
        public int	TOTAL_USER { get; set; }
        public int	TOTAL_SUPPLIER { get; set; }
        public int	TOTAL_BOWSER_ORDER { get; set; }
        public int	TOTAL_DIESEL_ORDER { get; set; }
        public int	TOTAL_CORPORATE_USER { get; set; }
        public int	TOTAL_INDIVIDUAL_USER { get; set; }
       

    }
}
