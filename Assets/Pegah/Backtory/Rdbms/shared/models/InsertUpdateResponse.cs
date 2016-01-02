using System;
namespace Pegah.SaaS.Models
{
	public class InsertUpdateResponse	
	{
		public Guid Guid { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public String OwnerId { get; set; }
		public Boolean IsDeleted { get; set; }

	}
}

