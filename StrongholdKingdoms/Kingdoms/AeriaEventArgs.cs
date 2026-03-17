using System;

namespace Kingdoms
{
	// Token: 0x020000BC RID: 188
	public class AeriaEventArgs
	{
		// Token: 0x0600052E RID: 1326 RVA: 0x0000AC59 File Offset: 0x00008E59
		public AeriaEventArgs(string u, string t)
		{
			this.userguid = u;
			this.token = t;
		}

		// Token: 0x040005FE RID: 1534
		public string userguid;

		// Token: 0x040005FF RID: 1535
		public string token;
	}
}
