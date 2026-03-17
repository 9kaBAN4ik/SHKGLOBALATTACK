using System;

namespace Upgrade
{
	// Token: 0x02000035 RID: 53
	public class TradeType
	{
		// Token: 0x06000207 RID: 519 RVA: 0x000483CC File Offset: 0x000465CC
		internal TradeType Clone()
		{
			return new TradeType
			{
				ResourceId = this.ResourceId,
				Sell = this.Sell,
				MinSellPrice = this.MinSellPrice,
				SellLimit = this.SellLimit,
				Buy = this.Buy,
				MaxBuyPrice = this.MaxBuyPrice,
				BuyLimit = this.BuyLimit
			};
		}

		// Token: 0x04000398 RID: 920
		public byte ResourceId;

		// Token: 0x04000399 RID: 921
		public bool Sell;

		// Token: 0x0400039A RID: 922
		public int MinSellPrice;

		// Token: 0x0400039B RID: 923
		public int SellLimit;

		// Token: 0x0400039C RID: 924
		public bool Buy;

		// Token: 0x0400039D RID: 925
		public int MaxBuyPrice;

		// Token: 0x0400039E RID: 926
		public int BuyLimit;
	}
}
