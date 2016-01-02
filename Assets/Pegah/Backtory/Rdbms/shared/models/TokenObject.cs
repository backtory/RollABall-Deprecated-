using System;
using fastJSON;


namespace Pegah.SaaS.Models{
	public class TokenObject{
		[Display("access_token")]
		public string Access_token { get; set; }

		[Display("token_type")]
		public string Token_type { get; set; }
		
		[Display("refresh_token")]
		public string Refresh_token { get; set; }
		
		[Display("expires_in")]
		public string Expires_in { get; set; }
		
		[Display("scope")]
		public string Scope { get; set; }
		
		[Display("userName")]
		public string UserName { get; set; }
		
		[Display("userId")]
		public string UserId { get; set; }
	}
}

