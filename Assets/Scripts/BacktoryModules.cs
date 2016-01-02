using System;
using Pegah.SaaS.Models;
using UnityEngine;
using System.Collections.Generic;
using Rollaball.Models;
using Rollaball.Services;

namespace AssemblyCSharp
{
	public class BacktoryModules
	{
		public BacktoryModules () {
		}
		
		public static void createItem(LeaderboardEntity request) {
			LeaderboardsService leaderboardsService = new LeaderboardsService ();
			leaderboardsService.create (request, (InsertUpdateResponse insertUpdateResponse) => {
				Debug.Log("successful " + "create Ad: " + insertUpdateResponse.Guid);
			}, (int resultCode) => {
				Debug.Log("failure " + "create Ad: " + resultCode);
			});
		}
		
		public static void listOfAds(ListRequest request, String message) {
			request.PageSize = 10;
			LeaderboardsService leaderboardsService = new LeaderboardsService ();
			leaderboardsService.list (request, (LeaderboardListResponse leaderboardListResponse) => {
				Debug.Log("successful " + message + ": " + leaderboardListResponse.TotalCount + " " + leaderboardListResponse.Data[0].Time);
			}, (int resultCode) => {
				Debug.Log("failure " + message + ": " + resultCode + "");
			});
		}
		
		public static void updateItem(LeaderboardEntity request) {
			LeaderboardsService leaderboardsService = new LeaderboardsService ();
			leaderboardsService.update (request, (InsertUpdateResponse insertUpdateResponse) => {
				Debug.Log("successful " + "update Ad: " + insertUpdateResponse.Guid);
			}, (int resultCode) => {
				Debug.Log("failure " + "update Ad: " + resultCode);
			});
		}
		
		public static void register(MobileUserEntity mobileUserEntity) {
			MobileUsersService mobileUsersService = new MobileUsersService ();
			mobileUsersService.signUp (mobileUserEntity, (InsertUpdateResponse insertUpdateResponse) => {
				Debug.Log("successful " + "register: " + insertUpdateResponse.Guid);
			}, (int resultCode) => {
				Debug.Log("failure " + "register:" + resultCode);
			});
		}
		
		public static void login(LogInRequest logInRequest) {
			MobileUsersService mobileUsersService = new MobileUsersService ();
			mobileUsersService.logIn (logInRequest, (TokenObject tokenObject) => {
				Debug.Log("successful " + "login: " + tokenObject.ToString());
			}, (int resultCode) => {
				Debug.Log("failure " + "login:" + resultCode);
			});
		}

		public static void saveOrUpdate(LeaderboardEntity leaderboardEntity){
			LeaderboardsService leaderboardsService = new LeaderboardsService ();
			ListRequest request = new ListRequest ()
				.and (Exp.equalsTo(LeaderboardEntity.COLUMN_DeviceId, leaderboardEntity.DeviceId));

			leaderboardsService.list (request, (LeaderboardListResponse leaderboardListResponse) => {
				if (leaderboardListResponse.TotalCount == 0){
					createItem(leaderboardEntity);
					Debug.Log("create leaderboardEntity");
				} else {
					LeaderboardEntity tmp = leaderboardListResponse.Data[0];
					Debug.Log("update leaderboardEntity: " + tmp.Time + " " + leaderboardEntity.Time);
					if (tmp.Time > leaderboardEntity.Time){
						tmp.Time = leaderboardEntity.Time;
						updateItem(tmp);
					}
				}
			}, (int resultCode) => {
				Debug.Log("failure: " + resultCode + "");
			});
		}

		public static void getHighScore(Action <LeaderboardListResponse> successfullAction, Action <int> failureAction){
			LeaderboardsService leaderboardsService = new LeaderboardsService ();
			ListRequest request = new ListRequest ().addOrderBy (Exp.property (LeaderboardEntity.COLUMN_Time), true);
			leaderboardsService.list (request, successfullAction, failureAction);
		}
	}
}
