using System;

namespace Pegah.SaaS.Config
{
	public class SaaSServiceInfo {
		public Boolean IsAsync { get; set; }
		public String ClassName { get; set; }
		public String MethodName { get; set; }
		public String Url { get; set; }
		public String TableId { get; set; }
		public String SchemaId { get; set; }

		public SaaSServiceInfo() { }
		public SaaSServiceInfo(Boolean isAsync, String className, String methodName, String url, String tableId, String schemaId) {
			IsAsync = isAsync;
			ClassName = className;
			MethodName = methodName;
			Url = url;
			TableId = tableId;
			SchemaId = schemaId;
		}
	}
}

