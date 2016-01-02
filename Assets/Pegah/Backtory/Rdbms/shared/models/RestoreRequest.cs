using System.Collections.Generic;

namespace Pegah.SaaS.Models{
	public class RestoreRequest{
		public List<string> ContentIds { get; set; }

		public RestoreRequest(){
			this.ContentIds = new List<string> ();
		}
	}
}