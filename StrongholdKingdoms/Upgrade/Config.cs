using System;
using System.Collections.Generic;

namespace Upgrade
{
	// Token: 0x02000013 RID: 19
	internal class Config
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00007E0B File Offset: 0x0000600B
		internal Config(string alias, string email, List<string> settings, DateTime whenChecked)
		{
			this.Alias = alias;
			this.Email = email;
			this.Settings = settings;
			this.Checked = whenChecked;
		}

		// Token: 0x04000068 RID: 104
		internal string Alias;

		// Token: 0x04000069 RID: 105
		internal string Email;

		// Token: 0x0400006A RID: 106
		internal List<string> Settings;

		// Token: 0x0400006B RID: 107
		internal DateTime Checked;
	}
}
