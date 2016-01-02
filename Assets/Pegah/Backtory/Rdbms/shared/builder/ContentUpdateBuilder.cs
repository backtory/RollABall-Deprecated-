using System.Reflection;
using Pegah.SaaS.Models;
using System;
using Pegah.SaaS.Builder;
using System.Collections.Generic;
using UnityEngine;

namespace Pegah.SaaS.Builder{
	public class ContentUpdateBuilder{
		public ContentUpdateModel build(BaseModel model) {
			ContentUpdateModel updateModel = new ContentUpdateModel();
			if(model == null)
				throw new Exception("Model is null");
			try {
				Dictionary<String, String> changes = model.__changes();
				Guid guid = new Guid(model
						.GetType()
						.GetProperty("Guid")
						.GetValue(model, null)
						.ToString());
				updateModel.EntityId = guid;
				updateModel.FieldMap = new List<StringPair>();

				foreach (String key in changes.Keys) {
					updateModel.FieldMap.Add(new StringPair(key, changes[key]));
				}
				
				return updateModel;
			} catch {
				throw;
			}
		}
		
		public List<ContentUpdateModel> buildList<T>(List<T> ts) where T : BaseModel {
			List<ContentUpdateModel> result = new List<ContentUpdateModel>();
			if (ts == null)
				return result;
			
			foreach (T item in ts)
				result.Add(build(item));
			
			return result;
		}
		
		public void update(BaseModel request, InsertUpdateResponse obj) {
			if (request == null)
				return;
			Type cls = request.GetType();
			try {
				cls.GetProperty("Guid").SetValue(request, obj.Guid, null);
				cls.GetProperty("CreationDate").SetValue(request, obj.CreationDate, null);
				cls.GetProperty("LastModifiedDate").SetValue(request, obj.LastModifiedDate, null);

				cls.GetProperty("Owner_ID").SetValue(request, obj.OwnerId, null);
				cls.GetProperty("IsDeleted").SetValue(request, obj.IsDeleted, null);

				var field = cls.BaseType.GetField("fieldsMap", BindingFlags.Instance | BindingFlags.NonPublic);
				field.SetValue(request, new Dictionary<string, string>());
			} catch {
				throw;
			}
		}
		
		public void updateAll<T>(List<T> request, InsertUpdateListResponse obj) where T : BaseModel {
			if (request == null && obj == null)
				return;
			if (request == null || obj == null || obj.Results == null
			    || request.Count != obj.Results.Count)
				throw new Exception("Request or Object are null or not equal size");
			
			for (int i = 0; i < request.Count; i++)
				update(request[i], obj.Results[i]);
		}
		
		
	}
}
