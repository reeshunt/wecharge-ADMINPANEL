﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model
{
    [Dapper.Contrib.Extensions.Table("TBL_M_WALLET")]
    public class Wallet:BaseModel
    {
        public int USER_ID { get; set; }
        public double Balance { get; set; }
        public string? CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string? MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
    }
}
