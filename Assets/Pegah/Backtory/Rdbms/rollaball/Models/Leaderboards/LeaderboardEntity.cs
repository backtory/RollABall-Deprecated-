using System;
using System.Collections.Generic;
using Pegah.SaaS.Models;
using Rollaball.Models.Leaderboards;

namespace Rollaball.Models
{
    public class LeaderboardEntity : BaseModel
    {
		public const String COLUMN_Guid = "Guid";
		public const String COLUMN_CreationDate = "CreationDate";
		public const String COLUMN_IsDeleted = "IsDeleted";
		public const String COLUMN_LastModifiedDate = "LastModifiedDate";
		public const String COLUMN_Owner_ID = "Owner_ID";
		public const String COLUMN_DeviceId = "DeviceId";
		public const String COLUMN_Time = "Time";




	
		private Guid _Guid;
		public Guid Guid { get { return _Guid; } set { _Guid = value; notifyChange("Guid", value); } }

		private DateTime _CreationDate;
		public DateTime CreationDate { get { return _CreationDate; } set { _CreationDate = value; notifyChange("CreationDate", value); } }

		private bool _IsDeleted;
		public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; notifyChange("IsDeleted", value); } }

		private DateTime _LastModifiedDate;
		public DateTime LastModifiedDate { get { return _LastModifiedDate; } set { _LastModifiedDate = value; notifyChange("LastModifiedDate", value); } }

		private Guid _Owner_ID;
		public Guid Owner_ID { get { return _Owner_ID; } set { _Owner_ID = value; notifyChange("Owner_ID", value); } }

		private string _DeviceId;
		public string DeviceId { get { return _DeviceId; } set { _DeviceId = value; notifyChange("DeviceId", value); } }

		private double _Time;
		public double Time { get { return _Time; } set { _Time = value; notifyChange("Time", value); } }


    }
}
namespace Rollaball.Models.Leaderboards { }