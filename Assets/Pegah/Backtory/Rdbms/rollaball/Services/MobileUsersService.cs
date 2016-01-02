using System.Collections.Generic;
using Pegah.SaaS.Utility;
using Pegah.SaaS.Models;
using Pegah.SaaS.Builder;
using Pegah.SaaS.Config;
using System;
using Rollaball;
using Rollaball.Models;


namespace Rollaball.Services {
	public class MobileUsersService {

        public void list(ListRequest request, Action<MobileUserListResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/25e2169f-49a0-4eae-8ace-18e8b867ced8/list?start={start}&pageSize={pageSize}&includeDeleted={includeDeleted}&includeUndeleted={includeUndeleted}";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "list", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            

			pathParams.Add("start", request.Start);
			pathParams.Add("pageSize", request.PageSize);
			pathParams.Add("includeDeleted", request.IncludeDeleted);
			pathParams.Add("includeUndeleted", request.IncludeUndeleted);


			postData = request.QueryObject;

            HttpHelper.sendRequest<MobileUserListResponse> (
                "post",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "list", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "list", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void deleteMobileUser(DeleteRequest request, Action<DeleteResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/25e2169f-49a0-4eae-8ace-18e8b867ced8/delete";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "deleteMobileUser", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            



			postData = request.ContentIds;

            HttpHelper.sendRequest<DeleteResponse> (
                "delete",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "deleteMobileUser", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "deleteMobileUser", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void update(MobileUserEntity request, Action<InsertUpdateResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/content/25e2169f-49a0-4eae-8ace-18e8b867ced8/update_single";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "update", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
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
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "update", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "update", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void signUp(MobileUserEntity request, Action<InsertUpdateResponse> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/user/25e2169f-49a0-4eae-8ace-18e8b867ced8/register";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "signUp", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
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
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "signUp", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "signUp", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void logIn(LogInRequest request, Action<TokenObject> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "oauth/token?grant_type=password&client_id=saas-trusted-client&username={username}&password={password}&schema_id=596b84af-6fcd-420c-9f04-389b09d4d78c";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "logIn", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            

			pathParams.Add("username", request.Username);
			pathParams.Add("password", request.Password);



            HttpHelper.sendRequest<TokenObject> (
                "get",
                url,
                pathParams,
                postData,
                (_object) => {
                   			RollaballConfiguration.instance().DataProvider.save("SAAS_access_token",_object.Access_token);
				RollaballConfiguration.instance().DataProvider.save("SAAS_refresh_token",_object.Refresh_token);
				RollaballConfiguration.instance().DataProvider.save("SAAS_token_type",_object.Token_type);
				RollaballConfiguration.instance().DataProvider.save("SAAS_expires_in",_object.Expires_in);
				RollaballConfiguration.instance().DataProvider.save("SAAS_scope",_object.Scope);
				RollaballConfiguration.instance().DataProvider.save("SAAS_user_id",_object.UserId);
				RollaballConfiguration.instance().DataProvider.save("SAAS_token_time",DateUtility.getCurrentTime());
				RollaballConfiguration.instance().DataProvider.save("SAAS_user_name",request.Username);
				RollaballConfiguration.instance().DataProvider.save("SAAS_password",request.Password);

                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "logIn", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "logIn", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }        public void userInfo(UserInfo request, Action<MobileUserEntity> success, Action<int> failed = null) {
            String accessToken = RollaballConfiguration.instance().DataProvider.Load("SAAS_access_token");
            String url = RollaballConfiguration.serviceRootUrl + "api/user/25e2169f-49a0-4eae-8ace-18e8b867ced8/userInfo?username={username}";
            
            RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "userInfo", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
            Dictionary<string, object> queryParams = new Dictionary<string, object> ();
            Dictionary<string, object> pathParams = new Dictionary<string, object> ();
            object postData = null;
            




            HttpHelper.sendRequest<MobileUserEntity> (
                "get",
                url,
                pathParams,
                postData,
                (_object) => {
                   
                   success(_object);
                   RollaballConfiguration.instance().ServiceSucceed(true, "MobileUser", "userInfo", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                },
                (x) =>  {
                   failed(x);
                   RollaballConfiguration.instance().ServiceFailed(true, "MobileUser", "userInfo", url, "25e2169f-49a0-4eae-8ace-18e8b867ced8", "596b84af-6fcd-420c-9f04-389b09d4d78c");
                }
            );
        }	}
}
