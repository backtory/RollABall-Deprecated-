using System.Collections.Generic;
using Pegah.SaaS.Config;
using System;

namespace Rollaball {
	public class RollaballConfiguration : SaaSConfiguration {
		public const String serviceRootUrl = "http://rdbms2.backtory.com/";
		public const String fileTableId = "6d465747-0a39-4e70-b776-b3d7aab58895";

		private static RollaballConfiguration _instance = new RollaballConfiguration();

		private RollaballConfiguration() {
		}

		private static SaaSDataProvider dataProvider;
		private List<SaaSPostProcess> postProcesses = new List<SaaSPostProcess>();

		public SaaSDataProvider DataProvider
		{
			get { return dataProvider; }
		}

		public static void initialize(SaaSDataProvider dp) {
			dataProvider = dp;
			// TODO: RefreshTokenInterceptor refreshTokenInterceptor = new RefreshTokenInterceptor(instance());
			// TODO: httpClient.interceptors().add(refreshTokenInterceptor);
		}

		public Guid FileTableId 
		{
			get {
				return new Guid(fileTableId);
			}
		}

		public String ApiBaseUrl
		{
			get { return serviceRootUrl; }
		}

		public static RollaballConfiguration instance() {
			return _instance;
		}

		public Guid SchemaId
		{
			get { return new Guid("596b84af-6fcd-420c-9f04-389b09d4d78c"); }
		}

	public String LoggedInUsername
		{
			get {
				return dataProvider.KeyExists ("SAAS_user_name")
					? dataProvider.Load ("SAAS_user_name")
						: null;
			}
		}

		public String LoggedInUserId
		{
			get {
				return dataProvider.KeyExists ("SAAS_user_id")
					? dataProvider.Load ("SAAS_user_id")
						: null;
			}
		}

		public void AddPostProcess(SaaSPostProcess postProcess) {
			foreach (SaaSPostProcess process in postProcesses)
				if (process.ProcessId == postProcess.ProcessId)
					throw new Exception("Duplicate process with same id: " + postProcess.ProcessId);

			postProcesses.Add(postProcess);
		}

		public void RemovePostProcess(String processId) {
			postProcesses.RemoveAll (x => x.ProcessId == processId);
		}

		public void ServiceStarted(Boolean isAsync, String className, String methodName, String url, String tableId, String schemaId) {
			foreach (SaaSPostProcess process in postProcesses)
				process.ServiceStarted(new SaaSServiceInfo(isAsync, className, methodName, url, tableId, schemaId));
		}

		public void ServiceFailed(Boolean isAsync, String className, String methodName, String url, String tableId, String schemaId) {
			foreach (SaaSPostProcess process in postProcesses)
				process.ServiceFailed(new SaaSServiceInfo(isAsync, className, methodName, url, tableId, schemaId));
		}

		public void ServiceSucceed(Boolean isAsync, String className, String methodName, String url, String tableId, String schemaId) {
			foreach (SaaSPostProcess process in postProcesses)
				process.ServiceSucceed(new SaaSServiceInfo(isAsync, className, methodName, url, tableId, schemaId));
		}
	}
}