using System.Collections.Generic;
namespace Pegah.SaaS.Models{
	public class UpdateRequest{
		public List<ContentUpdateModel> Models { get; set; }

		public UpdateRequest(){
			this.Models =  new List<ContentUpdateModel>();
		}
	}
}