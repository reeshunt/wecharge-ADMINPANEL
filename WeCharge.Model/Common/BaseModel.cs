using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeCharge.Model.Common
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}
