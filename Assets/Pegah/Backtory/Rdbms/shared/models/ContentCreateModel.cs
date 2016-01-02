using System.Collections.Generic;
namespace Pegah.SaaS.Models{
	public class ContentCreateModel{
		public List<StringPair> FieldMap { get; set; }
		public ContentCreateModel(){
			this.FieldMap = new List<StringPair> ();
		}
	}
}
