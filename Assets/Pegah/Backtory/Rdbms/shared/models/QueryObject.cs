using System.Collections.Generic;
using Pegah.SaaS.Builder;
using System;

namespace Pegah.SaaS.Models{
	public class QueryObject{
		public List<String> GroupByTermList { get; set; }
		public List<SelectTerm> SelectClause { get; set; }
		public FilterNode WhereClause { get; set; }
		public List<OrderNode> OrderByTermList { get; set; }
		public List<String> JoinAppendix { get; set; }
		
		public QueryObject And(FilterNode filterNode) {
			if (WhereClause == null)
				WhereClause = filterNode;
			else
				WhereClause = new FilterNode(WhereClause, Operator.AND.ToString(), filterNode);
			return this;
		}
		
		public QueryObject Include(String joinPath) {
			if (JoinAppendix == null)
				JoinAppendix = new List<String>();
			JoinAppendix.Add(joinPath);
			return this;
		}
	}
}

