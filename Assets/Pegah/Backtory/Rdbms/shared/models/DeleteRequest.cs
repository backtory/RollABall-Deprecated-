using System.Collections.Generic;

namespace Pegah.SaaS.Models{
	public class DeleteRequest{
		public List<string> ContentIds { get; set; }
		public DeleteRequest(){
			this.ContentIds =  new List<string>();
		}

	}
}