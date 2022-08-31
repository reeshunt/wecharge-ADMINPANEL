using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
    public class FeedbackDTO : BaseModel
    {
        public int TotalRecords { get; set; }
        public int ORDER_ID { get; set; }
        public int FEEDBACK_ID { get; set; }
        public string FEEDBACK_VALUE { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string FEEDBACK_NAME { get; set; }
        public string ISSUE_NAME { get; set; }
        public int ISSUE_ID { get; set; }

    }
}
