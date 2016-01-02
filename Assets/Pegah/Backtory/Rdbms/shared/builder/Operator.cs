using System;
namespace Pegah.SaaS.Builder{
	public enum Operator{
		AND,
		OR,
		PLUS,
		MINUS,
		GT,
		GET,
		LT,
		LET,
		EQ,
		NEQ,
		NOT,
		LIKE,
		NotLIKE,
		MULT,
		COUNT,
		SUM,
		MIN,
		MAX,
		AVG,
		IsNull,
		NotNull,
		COUNTDISTINCT,
		SUMDISTINCT,
		MAXDISTINCT,
		MINDISTINCT,
		AVGDISTINCT
	}

	public static class OperatorExtension{
		public static string name(this Operator oper){
			return Enum.GetName (typeof(Operator), oper);
		}

		public static bool contains(this Operator oper, string test) {
			
			foreach (string c in Enum.GetNames(typeof(Operator))) {
				if (c.Equals(test)) {
					return true;
				}
			}
			
			return false;
		}
	}
}