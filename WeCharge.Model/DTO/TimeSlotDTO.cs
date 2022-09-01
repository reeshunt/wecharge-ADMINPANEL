using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
    public class TimeSlotDTO:BaseModel
    {
        public string TimeSlot { get; set; }
        public int TotalRecords { get; set; }
        public TimeSpan TIME_SLOT_FROM { get; set; }
        public TimeSpan TIME_SLOT_TO { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
    }
}
