using System;

namespace Pegah.SaaS.Config
{
	public interface SaaSPostProcess {
		String ProcessId { get; }
		void ServiceStarted(SaaSServiceInfo serviceInfo);
		void ServiceFailed(SaaSServiceInfo serviceInfo);
		void ServiceSucceed(SaaSServiceInfo serviceInfo);
	}
}

