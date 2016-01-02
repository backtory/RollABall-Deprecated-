using System.Collections.Generic;
using Pegah.SaaS.Utility;
using Pegah.SaaS.Models;
using Pegah.SaaS.Builder;
using Pegah.SaaS.Config;
using System;
using Rollaball;
using Rollaball.Models;


namespace Rollaball.Services {
	public class LeaderboardsService {

        public void customList<T>(ListRequest request, Action<T> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/list?start={start}&pageSize={pageSize}&includeDeleted={includeDeleted}&includeUndeleted={includeUndeleted}";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "customList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            

			pathParams.Add("start", request.Start);
			pathParams.Add("pageSize", request.PageSize);
			pathParams.Add("includeDeleted", request.IncludeDeleted);
			pathParams.Add("includeUndeleted", request.IncludeUndeleted);


			postData = request.QueryObject;

            HttpHelper.sendRequest<T> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "customList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "customList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void list(ListRequest request, Action<LeaderboardListResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/list?start={start}&pageSize={pageSize}&includeDeleted={includeDeleted}&includeUndeleted={includeUndeleted}";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "list", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            

			pathParams.Add("start", request.Start);
			pathParams.Add("pageSize", request.PageSize);
			pathParams.Add("includeDeleted", request.IncludeDeleted);
			pathParams.Add("includeUndeleted", request.IncludeUndeleted);


			postData = request.QueryObject;

            HttpHelper.sendRequest<LeaderboardListResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "list", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "list", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void create(LeaderboardEntity request, Action<InsertUpdateResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/create_and_get";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "create", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = new ContentCreateBuilder().build(request);

            HttpHelper.sendRequest<InsertUpdateResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   			new ContentCreateBuilder().update(request,_object);

                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "create", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "create", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void createList(List<LeaderboardEntity> request, Action<InsertUpdateListResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/create_all";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "createList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = new ContentCreateBuilder().buildList(request);

            HttpHelper.sendRequest<InsertUpdateListResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   			new ContentCreateBuilder().updateAll(request,_object);

                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "createList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "createList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void updateList(List<LeaderboardEntity> request, Action<InsertUpdateListResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/update_all";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "updateList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = new ContentUpdateBuilder().buildList(request);

            HttpHelper.sendRequest<InsertUpdateListResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   			new ContentUpdateBuilder().updateAll(request,_object);

                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "updateList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "updateList", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void update(LeaderboardEntity request, Action<InsertUpdateResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/update_single";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "update", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = new ContentUpdateBuilder().build(request);

            HttpHelper.sendRequest<InsertUpdateResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   			new ContentUpdateBuilder().update(request,_object);

                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "update", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "update", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void deleteleaderboard(DeleteRequest request, Action<QueryOutputNumber> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/delete";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "deleteleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = request.ContentIds;

            HttpHelper.sendRequest<QueryOutputNumber> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "deleteleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "deleteleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void restoreleaderboard(RestoreRequest request, Action<QueryOutputNumber> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/649075d1-b067-425b-bb02-f4680445d4f0/restore";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "restoreleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = request.ContentIds;

            HttpHelper.sendRequest<QueryOutputNumber> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "leaderboard", "restoreleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "leaderboard", "restoreleaderboard", url, "649075d1-b067-425b-bb02-f4680445d4f0", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }	}
}
