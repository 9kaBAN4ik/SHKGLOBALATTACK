using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004AA RID: 1194
	public class UICardOffer : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x0400363E RID: 13886
		public CustomSelfDrawPanel.CSDImage baseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400363F RID: 13887
		public CustomSelfDrawPanel.CSDImage packImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003640 RID: 13888
		public CustomSelfDrawPanel.CSDImage packOverImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003641 RID: 13889
		public CustomSelfDrawPanel.CSDImage fanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003642 RID: 13890
		public CustomSelfDrawPanel.CSDImage crownImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003643 RID: 13891
		public CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003644 RID: 13892
		public CustomSelfDrawPanel.CSDLabel descLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003645 RID: 13893
		public CustomSelfDrawPanel.CSDLabel cardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003646 RID: 13894
		public CustomSelfDrawPanel.CSDLabel costLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003647 RID: 13895
		public CardTypes.CardOffer Offer;
	}
}
