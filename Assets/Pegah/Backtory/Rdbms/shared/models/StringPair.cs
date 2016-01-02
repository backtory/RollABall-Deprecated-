namespace Pegah.SaaS.Models{
	public class StringPair{
		public string Key { get; set; }
		public string Value { get; set; }

		public StringPair(string key, string value){
			this.Key = key;
			this.Value = value;
		}

		public StringPair(){

		}
	}	
}
