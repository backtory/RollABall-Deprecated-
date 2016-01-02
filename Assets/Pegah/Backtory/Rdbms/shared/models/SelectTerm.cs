using System;
using Pegah.SaaS.Models;


namespace Pegah.SaaS.Models {
	public class SelectTerm
	{
		public SelectTerm(FilterNode node, String alias) {
			this.node = node;
			this.alias = alias;
		}
		
		public FilterNode node { get; set; }
		public String alias { get; set; }
	}
}

