using System.Collections;

namespace Pegah.SaaS.Models{
	public class FilterNode
	{	
		public string Op { get; set; }
		public FilterNode Right { get; set; }
		public FilterNode Left {get; set;}

		public FilterNode (){
		}

		public FilterNode (string op){
			this.Op = op;
		}

		public FilterNode(FilterNode left, string op, FilterNode right){
			this.Left = left;
			this.Op = op;
			this.Right = right;
		}
	}
}