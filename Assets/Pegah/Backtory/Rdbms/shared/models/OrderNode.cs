using System;
using Pegah.SaaS.Models;


namespace Pegah.SaaS.Models {
	public class OrderNode
	{
		public OrderNode(FilterNode node, OrderTerm term) {
			this.filterNode = node;
			this.term = term;
		}
		
		public FilterNode filterNode { get; set;}
		public OrderTerm term { get; set;}
	}
}

