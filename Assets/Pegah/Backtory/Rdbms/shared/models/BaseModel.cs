using System;
using System.Collections.Generic;

namespace Pegah.SaaS.Models
{
	public class BaseModel
	{
		private Dictionary<String, String> fieldsMap = new Dictionary<String, String>();
		
		protected void notifyChange<T>(String property, T value) {
			if (property != null && property.Equals("Guid"))
				return;
			if (fieldsMap.ContainsKey(property))
				fieldsMap.Remove(property);
					
			String rawValue = null;
			if (value != null) {
				if (value is DateTime)
				{
					Object tempObject = value;
					rawValue = ((DateTime)tempObject).ToString("yyyy-MM-dd HH:mm:ss. fff");
				}
				else if (typeof(T).IsEnum) 
				{
					object underlyingValue = Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()));
					rawValue = underlyingValue.ToString();
					//var intValue = "Dlakjflk".toen
				}
				else
					rawValue = value.ToString();
			}
			
			fieldsMap[property] = rawValue;
		}
		
		public Dictionary<String, String> __changes() {
			return fieldsMap;
		}
	}
}

