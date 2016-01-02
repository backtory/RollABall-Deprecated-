using System;
using Pegah.SaaS.Builder;

namespace Pegah.SaaS.Models
{
	public class Exp {
		
		private static String stringOf(Object value) {
			String rawValue = null;
			if (value != null) {
				if (value is DateTime)
					rawValue = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss. fff");
				else
					rawValue = value.ToString();
			}
			return rawValue;
		}
		public static FilterNode equalsTo(String property, Object value) {
			return new FilterNode(new FilterNode(property),
			                      Operator.EQ.ToString(),
			                      new FilterNode(stringOf(value)));
		}
		
		public static FilterNode isNull(String property) {
			
			return new FilterNode(new FilterNode(property),
			                      Operator.IsNull.ToString(),
			                      new FilterNode(
				));
		}
		
		public static FilterNode notNull(String property) {
			return new FilterNode(new FilterNode(property),
			                      Operator.NotNull.ToString(),
			                      new FilterNode());
		}
		
		public static FilterNode notEqualsTo(String property, Object value) {
			return new FilterNode(new FilterNode(property),
			                      Operator.NEQ.ToString(),
			                      new FilterNode(stringOf(value)));
		}
		
		public static FilterNode lessThanOrEqual(String property, Object value) {
			return new FilterNode(new FilterNode(property),
			                      Operator.LET.ToString(),
			                      new FilterNode(stringOf(value)));
		}
		
		public static FilterNode greaterThanOrEqual(String property, Object value) {
			return new FilterNode(new FilterNode(property),
			                      Operator.GET.ToString(),
			                      new FilterNode(stringOf(value)));
		}
		
		public static FilterNode between(String property, Object lowerBoundInclusive, Object upperBoundInclusive) {
			return and(
				lessThanOrEqual(property, upperBoundInclusive),
				greaterThanOrEqual(property, lowerBoundInclusive)
				);
		}
		
		public static FilterNode and(params FilterNode[] filterNodes) {
			if (filterNodes == null || filterNodes.Length < 2)
				throw new Exception("At least two operands are needed for AND");
			
			FilterNode result = null;
			foreach (FilterNode node in filterNodes) {
				if (result == null) {
					result = node;
				} else {
					FilterNode temp = new FilterNode(result, Operator.AND.ToString(), node);
					result = temp;
				}
			}
			return result;
		}
		
		public static FilterNode or(params FilterNode[] filterNodes) {
			if (filterNodes == null || filterNodes.Length < 2)
				throw new Exception("At least two operands are needed for AND");
			
			FilterNode result = null;
			foreach (FilterNode node in filterNodes) {
				if (result == null) {
					result = node;
				} else {
					FilterNode temp = new FilterNode(result, Operator.OR.ToString(), node);
					result = temp;
				}
			}
			return result;
		}
		
		public static SelectTerm selectProperty(String propertyName, String alias) {
			return new SelectTerm(property(propertyName), alias);
		}
		
		public static SelectTerm count(String propertyName, String alias) {
			return aggregate(Operator.COUNT.ToString(), propertyName, alias);
		}
		
		public static SelectTerm max(String propertyName, String alias) {
			return aggregate(Operator.MAX.ToString(), propertyName, alias);
		}
		
		public static SelectTerm min(String propertyName, String alias) {
			return aggregate(Operator.MIN.ToString(), propertyName, alias);
		}
		
		public static SelectTerm average(String propertyName, String alias) {
			return aggregate(Operator.AVG.ToString(), propertyName, alias);
		}
		
		public static SelectTerm aggregate(String function, String propertyName, String alias) {
			return new SelectTerm(new FilterNode(new FilterNode(propertyName), function, null), alias);
		}
		
		public static FilterNode property(String propertyName) {
			return new FilterNode(propertyName);
		}
	}
}

