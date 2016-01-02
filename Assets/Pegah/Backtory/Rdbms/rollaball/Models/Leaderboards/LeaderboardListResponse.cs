using System;
using System.Collections.Generic;
using Pegah.SaaS.Models;
using Rollaball.Models.Leaderboards;

namespace Rollaball.Models
{
    public class LeaderboardListResponse : BaseModel
    {




	
		private int _TotalCount;
		public int TotalCount { get { return _TotalCount; } set { _TotalCount = value; notifyChange("TotalCount", value); } }

		private List<LeaderboardEntity> _Data;
		public List<LeaderboardEntity> Data { get { return _Data; } set { _Data = value; notifyChange("Data", value); } }


    }
}
namespace Rollaball.Models.Leaderboards { }