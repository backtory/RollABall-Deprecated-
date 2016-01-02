using System;
using System.Collections.Generic;

namespace Pegah.SaaS.Models{
	public class ListRequest{
		public int Start { get; set;}
		public int PageSize{ get; set;}
		public Boolean IncludeDeleted{ get; set;}
		public Boolean IncludeUndeleted{ get; set;}
		public QueryObject QueryObject{ get; set;}
		
		public ListRequest() {
			QueryObject = new QueryObject();
			this.IncludeUndeleted = true;
		}
		
		public ListRequest(int start, int pageSize, Boolean includeDeleted,
		                   Boolean includeUndeleted, QueryObject queryObject) {
			this.Start = start;
			this.PageSize = pageSize;
			this.IncludeDeleted = includeDeleted;
			this.IncludeUndeleted = includeUndeleted;
			this.QueryObject = queryObject;
		}
		
		/**
     * exactly same as "and" function, addCondition is just more user-friendly name
     * @param filter
     * @return
     */
		public ListRequest and(FilterNode filter) {
			QueryObject.And(filter);
			return this;
		}
		
		public ListRequest includeObject(String joinPath) {
			QueryObject.Include(joinPath);
			return this;
		}
		
		/****** Auxiliary methods *****/
		public ListRequest setStartIndex(int start) {
			this.Start = start;
			return this;
		}
		
		public ListRequest setMaxResult(int pageSize) {
			this.PageSize = pageSize;
			return this;
		}
		
		public ListRequest setIncludeDeleted() {
			this.IncludeDeleted = true;
			return this;
		}
		
		public ListRequest excludeDeleted() {
			this.IncludeDeleted = false;
			return this;
		}
		
		public ListRequest setIncludeUndeleted() {
			this.IncludeUndeleted = true;
			return this;
		}
		
		public ListRequest excludeUndeleted() {
			this.IncludeUndeleted = false;
			return this;
		}
		
		public ListRequest setQuery(QueryObject query) {
			this.QueryObject = query;
			return this;
		}
		
		public ListRequest select(params SelectTerm[] terms) {
			if (terms == null || terms.Length == 0) {
				QueryObject.SelectClause = null;
				return this;
			}
			List<SelectTerm> lst = new List<SelectTerm>();
			for (int i = 0; i < terms.Length; i++)
				lst.Add(terms[i]);
			return select(lst);
		}
		
		private ListRequest select(List<SelectTerm> lst) {
			QueryObject.SelectClause = lst;
			return this;
		}
		
		public ListRequest groupBy(params String[] groupByTerms) {
			if (groupByTerms == null || groupByTerms.Length == 0) {
				QueryObject.GroupByTermList = null;
				return this;
			}
			
			List<String> lst = new List<String>();
			for (int i = 0; i < groupByTerms.Length; i++)
				lst.Add(groupByTerms[i]);
			return groupBy(lst);
		}
		
		public ListRequest groupBy(List<String> groupByTerms) {
			QueryObject.GroupByTermList = groupByTerms;
			return this;
		}
		
		public ListRequest addOrderBy(FilterNode node, Boolean isAsc) {
			if (QueryObject.OrderByTermList == null)
				QueryObject.OrderByTermList = new List<OrderNode>();
			
			QueryObject.OrderByTermList.Add(
				new OrderNode(node, isAsc ? OrderTerm.ASC : OrderTerm.DESC));
			
			return this;
		}
		
		public int getStart() {
			return Start;
		}
		
		public int getPageSize() {
			return PageSize;
		}
		
		public Boolean getIncludeDeleted() {
			return IncludeDeleted;
		}
		
		public Boolean getIncludeUndeleted() {
			return IncludeUndeleted;
		}
		
		public QueryObject getQueryObject() {
			return QueryObject;
		}}
}