using System;
using System.Collections.Generic;

namespace Upgrade
{
	// Token: 0x02000036 RID: 54
	public class VillageTradeInfo
	{
		// Token: 0x06000209 RID: 521 RVA: 0x00009116 File Offset: 0x00007316
		public VillageTradeInfo(TradeType[] tradeTypes, List<int> quickTargets, bool isTrading)
		{
			this.TradeTypes = tradeTypes;
			this.QuickTargets = quickTargets;
			this.IsTrading = isTrading;
		}

		// Token: 0x0400039F RID: 927
		public TradeType[] TradeTypes;

		// Token: 0x040003A0 RID: 928
		public List<int> QuickTargets;

		// Token: 0x040003A1 RID: 929
		public bool IsTrading;
	}
}
