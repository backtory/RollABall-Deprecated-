using System;

namespace Pegah.SaaS.Config
{
	public interface SaaSConfiguration {
		Guid FileTableId { get; }
		String ApiBaseUrl { get; }
		SaaSDataProvider DataProvider { get; }
		Guid SchemaId { get; }
		String LoggedInUsername { get; }
		String LoggedInUserId { get; }
		void AddPostProcess(SaaSPostProcess postProcess);
		void RemovePostProcess(String processId);
	}
}

