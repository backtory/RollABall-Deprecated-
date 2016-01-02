using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Collections.Generic;
namespace Hp.Hamid.HTTP{
	public class HttpSender : MonoBehaviour {
	
		public const String Post = "post";
		public const string Get = "get";

		public void SendRequest(Request request, Action<Request> done){
			StartCoroutine(send(request, done));
		}

		public string MakeGetParams(Dictionary<string, string> data){
			string toReturn = "";
			if(data == null || data.Count == 0){
				return toReturn;
			}
			toReturn += "?";
			int i = 0;
			foreach(string key in data.Keys){
				toReturn += WWW.EscapeURL(key) + "=" +  WWW.EscapeURL(data[key]);
				i++;
				if(i < data.Count){
					toReturn += "&";
				}
			}
			return toReturn;
		}

		IEnumerator send(Request request, Action<Request> done){
			WWW item;
			Uri uri = new Uri(request.Url);
			string safeUrl = uri.AbsoluteUri;
			safeUrl += MakeGetParams(request.GetData);
			if(request.Method.ToLower().Equals(Get)){
				if(request.Headers != null){
					item = new WWW(safeUrl, null, request.Headers);
				}else{
					item = new WWW(safeUrl);
				}
			}else{
				WWWForm form = new WWWForm();
				Dictionary<string, string> headers = new Dictionary<string, string>();
				foreach(string key in form.headers.Keys){
					headers[key] = form.headers[key].ToString();
				}
				if(request.Headers != null)
					foreach(string key in request.Headers.Keys){
						headers[key] = request.Headers[key];
				}
				if(request.PostData == null){
					request.PostData = Encoding.UTF8.GetBytes("{}");
				}
				item = new WWW(safeUrl, request.PostData, headers);
			}
			while(!item.isDone){
				yield return true;
			}
			Response response = new Response();
			if(string.IsNullOrEmpty(item.error)){
				response.IsSuccess = true;
				response.Data = item.bytes;
			}else{
				Debug.Log("failed " + request.Method + " " + safeUrl + " " + item.error);
				response.IsSuccess = false;
			}
			response.Error = item.error;
			string[] statusParts = null;
			if(item.responseHeaders != null && item.responseHeaders.ContainsKey("STATUS")) {
				statusParts = item.responseHeaders["STATUS"].Split(' ');
			}
			if(statusParts != null && statusParts.Length > 1 && !int.TryParse(statusParts[1], out response.Status)) {
				response.Status = 0;
			}
			request.Response = response;

			if(done != null){
				done(request);
			}
		}
	}
	
	public class Request {
		public string Method {get; set;}
		public string Url {get; set;} 
		public byte[] PostData {get; set;}
		public Dictionary<string, string> GetData {get; set;} 
		public Dictionary<string, string> Headers {get; set;} 
		public Response Response {get; internal set;}
	}
	
	public class Response{
		public byte[] Data;
		public bool IsSuccess;
		public string Error;
		public int Status;
		public string Text {get{
				if(Data != null){
					return Encoding.UTF8.GetString(Data);
				}
				return null;
		}}
	}
}