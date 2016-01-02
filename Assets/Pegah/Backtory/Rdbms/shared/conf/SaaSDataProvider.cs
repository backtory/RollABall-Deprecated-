using System;

namespace Pegah.SaaS.Config
{
	public interface SaaSDataProvider {
		void save(String key, String value);
		String Load(String key);
		bool KeyExists(String key);
		void Remove(String key);
	}
}

