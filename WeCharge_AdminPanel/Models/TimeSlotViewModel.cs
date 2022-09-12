
using Microsoft.Build.Framework;

namespace WeCharge_AdminPanel.Models
{
    public class TimeSlotViewModel
    {
        public int ID { get; set; }
        public TimeSpan TIME_SLOT_FROM { get; set; }
        public TimeSpan TIME_SLOT_TO { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
    }
}
