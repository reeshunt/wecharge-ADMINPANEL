namespace WeCharge_AdminPanel.Models
{
    public class Asset
    {
		public int USER_ID { get; set; }
		public string EQUIPMENT_NAME { get; set; }
		public int FUEL_TYPE_ID { get; set; }
		public string EMAIL { get; set; }
		public string MOBILE_NO { get; set; }
		public bool IS_ACTIVE { get; set; }
		public string CREATED_BY { get; set; }
		public DateTime CREATED_DATE { get; set; }
		public string MODIFIED_BY { get; set; }
		public DateTime MODIFIED_DATE { get; set; }
	}
}
