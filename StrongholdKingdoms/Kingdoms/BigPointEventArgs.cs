using System;

namespace Kingdoms
{
	// Token: 0x020000E1 RID: 225
	public class BigPointEventArgs
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x0000B7CF File Offset: 0x000099CF
		public BigPointEventArgs(string u, string t)
		{
			this.userguid = u;
			this.token = t;
		}

		// Token: 0x04000904 RID: 2308
		public string userguid;

		// Token: 0x04000905 RID: 2309
		public string token;
	}
}
