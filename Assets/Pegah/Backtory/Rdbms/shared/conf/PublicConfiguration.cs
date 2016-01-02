namespace Pegah.SaaS.Config{

	public class PublicConfiguration{
	
		public static string RefreshToken { get; set; }
		public static string AccessToken { get; set; }
		public static long LastRefresh { get; set; }
		public static int ExpireInterval { get; set; }
		public static bool NeedsLogin { get; set; }
		public static bool IsLogin { get; set; }
		public static string Username { get; set; }
		public static string Password { get; set; }
		public static string FileTableId { get; set; }
		public static string ServiceRootUrl { get; set; }
		
		static PublicConfiguration(){
			RefreshToken = "";
			AccessToken = "";
			LastRefresh = 0;
			ExpireInterval = 0;
			NeedsLogin = true;
			IsLogin = false;
			Username = "";
			Password = "";
			FileTableId = "";
			ServiceRootUrl = "";
		}
	}

}
