using System.Collections.Generic;
namespace Pegah.SaaS.Models{
	public class UpdateResponse{
		public List<QueryOutput> UpdateIDOutputList { get; set; }

		public UpdateResponse(){
			this.UpdateIDOutputList = new List<QueryOutput> ();
		}
	}
}