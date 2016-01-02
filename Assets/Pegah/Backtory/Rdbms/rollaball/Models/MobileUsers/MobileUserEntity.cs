using System;
using System.Collections.Generic;
using Pegah.SaaS.Models;
using Rollaball.Models.MobileUsers;

namespace Rollaball.Models
{
    public class MobileUserEntity : BaseModel
    {
		public const String COLUMN_Guid = "Guid";
		public const String COLUMN_CreationDate = "CreationDate";
		public const String COLUMN_IsDeleted = "IsDeleted";
		public const String COLUMN_LastModifiedDate = "LastModifiedDate";
		public const String COLUMN_Owner_ID = "Owner_ID";
		public const String COLUMN_AccountNonExpired = "Plugin_AccountNonExpired";
		public const String COLUMN_AccountNonLocked = "Plugin_AccountNonLocked";
		public const String COLUMN_CredentialsNonExpired = "Plugin_CredentialsNonExpired";
		public const String COLUMN_EmailAddress = "Plugin_EmailAddress";
		public const String COLUMN_Enabled = "Plugin_Enabled";
		public const String COLUMN_Firstname = "Plugin_Firstname";
		public const String COLUMN_IMEI1 = "Plugin_IMEI1";
		public const String COLUMN_IsAnonymous = "Plugin_IsAnonymous";
		public const String COLUMN_Lastname = "Plugin_Lastname";
		public const String COLUMN_MobilePhoneNumber1 = "Plugin_MobilePhoneNumber1";
		public const String COLUMN_Password = "Plugin_Password";
		public const String COLUMN_Username = "Plugin_Username";




	
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

		private bool _Plugin_AccountNonExpired;
		public bool Plugin_AccountNonExpired { get { return _Plugin_AccountNonExpired; } set { _Plugin_AccountNonExpired = value; notifyChange("Plugin_AccountNonExpired", value); } }

		private bool _Plugin_AccountNonLocked;
		public bool Plugin_AccountNonLocked { get { return _Plugin_AccountNonLocked; } set { _Plugin_AccountNonLocked = value; notifyChange("Plugin_AccountNonLocked", value); } }

		private bool _Plugin_CredentialsNonExpired;
		public bool Plugin_CredentialsNonExpired { get { return _Plugin_CredentialsNonExpired; } set { _Plugin_CredentialsNonExpired = value; notifyChange("Plugin_CredentialsNonExpired", value); } }

		private string _Plugin_EmailAddress;
		public string Plugin_EmailAddress { get { return _Plugin_EmailAddress; } set { _Plugin_EmailAddress = value; notifyChange("Plugin_EmailAddress", value); } }

		private bool _Plugin_Enabled;
		public bool Plugin_Enabled { get { return _Plugin_Enabled; } set { _Plugin_Enabled = value; notifyChange("Plugin_Enabled", value); } }

		private string _Plugin_Firstname;
		public string Plugin_Firstname { get { return _Plugin_Firstname; } set { _Plugin_Firstname = value; notifyChange("Plugin_Firstname", value); } }

		private string _Plugin_IMEI1;
		public string Plugin_IMEI1 { get { return _Plugin_IMEI1; } set { _Plugin_IMEI1 = value; notifyChange("Plugin_IMEI1", value); } }

		private bool _Plugin_IsAnonymous;
		public bool Plugin_IsAnonymous { get { return _Plugin_IsAnonymous; } set { _Plugin_IsAnonymous = value; notifyChange("Plugin_IsAnonymous", value); } }

		private string _Plugin_Lastname;
		public string Plugin_Lastname { get { return _Plugin_Lastname; } set { _Plugin_Lastname = value; notifyChange("Plugin_Lastname", value); } }

		private string _Plugin_MobilePhoneNumber1;
		public string Plugin_MobilePhoneNumber1 { get { return _Plugin_MobilePhoneNumber1; } set { _Plugin_MobilePhoneNumber1 = value; notifyChange("Plugin_MobilePhoneNumber1", value); } }

		private string _Plugin_Password;
		public string Plugin_Password { get { return _Plugin_Password; } set { _Plugin_Password = value; notifyChange("Plugin_Password", value); } }

		private string _Plugin_Username;
		public string Plugin_Username { get { return _Plugin_Username; } set { _Plugin_Username = value; notifyChange("Plugin_Username", value); } }


    }
}
namespace Rollaball.Models.MobileUsers { }