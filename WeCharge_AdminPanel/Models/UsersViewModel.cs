namespace WeCharge_AdminPanel.Models
{
    public class UsersViewModel
    {
		public int ROLE_ID { get; set; }
		public string FULL_NAME { get; set; }
		public string MOBILE_NO { get; set; }
		public string EMAIL { get; set; }
		public string PASSWORD_HASH { get; set; }
		public string CREATED_BY { get; set; }
		public DateTime CREATED_DATE { get; set; }
		public string MODIFIED_BY { get; set; }
		public DateTime MODOFIED_DATE { get; set; }
		public string IMAGE_PATH { get; set; }
		public bool IS_ACTIVE { get; set; }
	}
}
