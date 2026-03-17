using System;
using System.Collections.Generic;

namespace Kingdoms
{
	// Token: 0x020004AB RID: 1195
	public class UICardPack : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x04003648 RID: 13896
		public int OfferID;

		// Token: 0x04003649 RID: 13897
		public CustomSelfDrawPanel.CSDImage baseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400364A RID: 13898
		public CustomSelfDrawPanel.CSDImage overImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400364B RID: 13899
		public CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400364C RID: 13900
		public CustomSelfDrawPanel.CSDLabel descriptionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400364D RID: 13901
		public List<int> PackIDs = new List<int>();

		// Token: 0x0400364E RID: 13902
		public string nameText = string.Empty;
	}
}
