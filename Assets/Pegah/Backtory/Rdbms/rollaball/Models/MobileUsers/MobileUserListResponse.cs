using System;
using System.Collections.Generic;
using Pegah.SaaS.Models;
using Rollaball.Models.MobileUsers;

namespace Rollaball.Models
{
    public class MobileUserListResponse : BaseModel
    {




	
		private int _TotalCount;
		public int TotalCount { get { return _TotalCount; } set { _TotalCount = value; notifyChange("TotalCount", value); } }

		private List<MobileUserEntity> _Data;
		public List<MobileUserEntity> Data { get { return _Data; } set { _Data = value; notifyChange("Data", value); } }


    }
}
namespace Rollaball.Models.MobileUsers { }