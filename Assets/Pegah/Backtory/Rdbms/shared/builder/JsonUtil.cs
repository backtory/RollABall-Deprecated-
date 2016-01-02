using System;
namespace Pegah.SaaS.Builder{
	public class JsonUtil{
		public static fastJSON.JSONParameters getDefaultParameters(){
			fastJSON.JSONParameters parameters = new fastJSON.JSONParameters ();
			parameters.UseExtensions = false;
			parameters.UsingGlobalTypes = false;
			parameters.EnableAnonymousTypes = false;
			parameters.SerializeNullValues = false;
			parameters.SerializeToLowerCamelCaseNames = true;
			return parameters;
		}
	}
}