using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeCharge.Model.Common;

namespace WeCharge.Model.DTO
{
    public class OrdersDTO :BaseModel
    {
        public int	ORDER_ID { get; set; }
        public string QR_CODE { get; set; }
        public int	USER_ID { get; set; }
        public int	ADDRESS_ID { get; set; }
        public int	VENDOR_ID { get; set; }
        public int	FUEL_TYPE_ID { get; set; }
        public decimal	PRICE { get; set; }
        public int	QUANTITY { get; set; }
        public string	DELIVERY_ADDRESS { get; set; }
        public string	BILLING_ADDRESS { get; set; }
        public DateTime	ORDER_DATETIME { get; set; }
        public string	ORDER_DATETIME_STR { get; set; }
        public int	TIME_SLOT_ID { get; set; }
        public decimal	DISCOUNT { get; set; }
        public int	PAYMENT_MODE_ID { get; set; }
        public int	COUPON_ID { get; set; }
        public int	ASSET_TYPE_ID { get; set; }
        public string	ORDER_STATUS { get; set; }
        public string	FULL_NAME { get; set; }
        public bool	IS_ACTIVE { get; set; }
        public string	CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string	MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
        public string FUEL_TYPE_NAME { get; set; }
        //public TimeOnly TIME_SLOT_FROM {  get; set; }
        //public TimeOnly TIME_SLOT_TO { get; set; }
        public string  MODE { get; set; }
        public string EQUIPMENT_NAME { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE_NO { get; set; }
        public int TotalRecords { get; set; }

    }
}
