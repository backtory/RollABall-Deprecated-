using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace Hp.Hamid.HTTP{
	public class HttpManager {
		private static HttpManager _instance;

		public static HttpManager Instance {get {
				return _instance ?? (_instance = new HttpManager());
			}}

		private HttpSender getMainObject(){
			HttpSender[] list = UnityEngine.Object.FindObjectsOfType<HttpSender> ();
			if(list == null || list.Length == 0){
				GameObject item = new GameObject("HttpSender");
				item.AddComponent<HttpSender>();
				return item.GetComponent<HttpSender>();
			}
			return list[0];
		}
		
		public void SendRequest(Request request, Action<Request> callback){
			this.getMainObject().SendRequest(request, callback);
		}
	
	}
}
