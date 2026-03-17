using System;
using System.Collections.Generic;

namespace Upgrade.Services
{
	// Token: 0x02000092 RID: 146
	internal class TradeRoute
	{
		// Token: 0x060003E0 RID: 992 RVA: 0x000569D0 File Offset: 0x00054BD0
		public TradeRoute(string name, bool enabled, List<int> from, List<int> to, List<int> resources, int keepMinimum, int maxMerchantsPerTransaction, int sendMaximum, bool isDistanceLimited, int distanceLimit)
		{
			this.Name = name;
			this.Enabled = enabled;
			this.From = from;
			this.To = to;
			this.SortedRecipients = new Dictionary<int, List<int>>();
			this.Resources = resources;
			this.KeepMinimum = keepMinimum;
			this.MaxMerchantsPerTransaction = maxMerchantsPerTransaction;
			this.SendMaximum = sendMaximum;
			this.IsDistanceLimited = isDistanceLimited;
			this.DistanceLimit = distanceLimit;
		}

		// Token: 0x0400051C RID: 1308
		public string Name;

		// Token: 0x0400051D RID: 1309
		public bool Enabled;

		// Token: 0x0400051E RID: 1310
		public List<int> From;

		// Token: 0x0400051F RID: 1311
		public List<int> To;

		// Token: 0x04000520 RID: 1312
		public Dictionary<int, List<int>> SortedRecipients;

		// Token: 0x04000521 RID: 1313
		public List<int> Resources;

		// Token: 0x04000522 RID: 1314
		public int KeepMinimum;

		// Token: 0x04000523 RID: 1315
		public int MaxMerchantsPerTransaction;

		// Token: 0x04000524 RID: 1316
		public int SendMaximum;

		// Token: 0x04000525 RID: 1317
		public bool IsDistanceLimited;

		// Token: 0x04000526 RID: 1318
		public int DistanceLimit;
	}
}
