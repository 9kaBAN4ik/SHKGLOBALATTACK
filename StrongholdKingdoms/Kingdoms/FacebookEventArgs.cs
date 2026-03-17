using System;

namespace Kingdoms
{
	// Token: 0x020001AC RID: 428
	public class FacebookEventArgs
	{
		// Token: 0x06001046 RID: 4166 RVA: 0x00011F20 File Offset: 0x00010120
		public FacebookEventArgs(string u, string t)
		{
			this.userguid = u;
			this.token = t;
		}

		// Token: 0x04001666 RID: 5734
		public string userguid;

		// Token: 0x04001667 RID: 5735
		public string token;
	}
}
