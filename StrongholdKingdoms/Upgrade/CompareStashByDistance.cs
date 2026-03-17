using System;
using System.Collections.Generic;

namespace Upgrade
{
	// Token: 0x02000034 RID: 52
	internal class CompareStashByDistance : IComparer<StashDistance>
	{
		// Token: 0x06000205 RID: 517 RVA: 0x000090F3 File Offset: 0x000072F3
		public int Compare(StashDistance x, StashDistance y)
		{
			if (x.Distance > y.Distance)
			{
				return 1;
			}
			if (x.Distance < y.Distance)
			{
				return -1;
			}
			return 0;
		}
	}
}
