namespace WeCharge_AdminPanel.Models
{
    public class OrdersViewModel
    {
        public int USER_ID { get; set; }
        public int ADDRESS_ID { get; set; }
        public int VENDOR_ID { get; set; }
        public int FUEL_TYPE_ID { get; set; }
        public int QUANTITY { get; set; }
        public decimal PRICE { get; set; }
        public int TIME_SLOT_ID { get; set; }
        public int PAYMENT_MODE_ID { get; set; }
        public int ASSET_TYPE_ID { get; set; }
        public int ORDER_ID { get; set; }
        public string QR_CODE { get; set; }
        public string DELIVERY_ADDRESS { get; set; }
        public string BILLING_ADDRESS { get; set; }
        public DateTime ORDER_DATETIME { get; set; }
        public decimal DISCOUNT { get; set; }
        public string ORDER_STATUS { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODOFIED_DATE { get; set; }
        public string COUPON_CODE { get; set; }
        public DateTime DATE_OF_DELIVERY { get; set; }

    }
}
