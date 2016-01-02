using System.Collections.Generic;
using System;

namespace Pegah.SaaS.Models{
	public class ContentUpdateModel{
		public List<StringPair> FieldMap { get; set; }
		public Guid EntityId { get; set; }
		public ContentUpdateModel() {
			this.FieldMap =  new List<StringPair>();
		}
	}
}