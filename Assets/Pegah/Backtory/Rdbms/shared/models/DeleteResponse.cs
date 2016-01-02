using System.Collections.Generic;

namespace Pegah.SaaS.Models{
	public class DeleteResponse{
		public List<QueryOutput> DeleteIDOutputList { get; set; }

		public DeleteResponse(){
			this.DeleteIDOutputList = new List<QueryOutput>();
		}
	}
}