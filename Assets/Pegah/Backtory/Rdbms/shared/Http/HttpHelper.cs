using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using Hp.Hamid.HTTP;
//using HTTP;
using Pegah.SaaS.Builder;
using UnityEngine;
using Pegah.SaaS.Models;


namespace Pegah.SaaS.Utility{
	public class HttpHelper{

		public static void sendRequest<T>(string method, string uri, Dictionary<string, object> pathParams,
		                                  object json, Action<T> success, Action<int> failed = null){
			string finalUri = replaceInPath (uri, pathParams);
			string jsonText = null;
			if (json != null) {
				jsonText = fastJSON.JSON.ToJSON(json, JsonUtil.getDefaultParameters());
			}
			Request req = new Request {Method = method, Url = finalUri};
			if(!method.ToLower().Equals("get")){
				req.PostData = getByteArray (jsonText);
				Dictionary<string, string> headers = new Dictionary<string, string>();
				headers.Add("Content-Type", "application/json");
				req.Headers= headers;
			}
			HttpManager.Instance.SendRequest (req, (request) => {
					Response response = request.Response;
					if(response != null && response.IsSuccess) {
						T toReturn = (T)fastJSON.JSON.ToObject(response.Text, typeof(T));
						if(success != null){
						success(toReturn);
						}
					}else {
						if(failed != null){
							failed(response.Status);
						}
					}
			});
			
//			Request req = new Request(method, finalUri);
//			req.AddHeader("Content-Type", "application/json");
//			req.bytes = getByteArray(jsonText);
//			req.Send((done) => {
//				Debug.Log(done.state);
//			});			
		}

		public static T sendRequestSync<T>(string method, string uri, Dictionary<string, object> pathParams, object json){
			T toReturn = default(T);
			sendRequest<T> (method, uri, pathParams, json, (result) => {
				toReturn = result;
			}, (state) => {
				throw new IOException("error in connection error " + state);
			});
			return toReturn;
		}
		
		public static byte[] getByteArray(string text){
			if (text != null) {
				return Encoding.UTF8.GetBytes(text);
			}
			return null;
		}

		public static string replaceInPath(string path, Dictionary<string, object> parameters){
			string toReturn = path;
			if(path != null && parameters != null){
				foreach(string key in parameters.Keys){
					toReturn = toReturn.Replace("{" + key + "}" , parameters[key].ToString());
				}
			}
			return toReturn;
		}
	}
}
