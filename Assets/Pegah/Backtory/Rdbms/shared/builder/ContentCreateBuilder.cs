using System.Reflection;
using Pegah.SaaS.Models;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Pegah.SaaS.Builder{
	public class ContentCreateBuilder {
		public ContentCreateModel build<T>(T t) where T : BaseModel {
			ContentCreateModel createModel = new ContentCreateModel();
			if (t.__changes() == null)
				return createModel;
			
			createModel.FieldMap = new List<StringPair>();
			foreach (var key in t.__changes().Keys)
				createModel.FieldMap.Add(new StringPair(key, t.__changes()[key]));
			
			return createModel;
		}
		
		public List<ContentCreateModel> buildList<T>(List<T> ts) where T : BaseModel {
			List<ContentCreateModel> result = new List<ContentCreateModel>();
			if (ts == null)
				return result;
			
			foreach (T item in ts)
				result.Add(build(item));
			
			return result;
		}
		
		public void update(BaseModel request, InsertUpdateResponse obj) {
			if (request == null)
				return;
			
			var cls = request.GetType();
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
		
		public void updateAll<T>(List<T> request, InsertUpdateListResponse obj) where T : BaseModel{
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
