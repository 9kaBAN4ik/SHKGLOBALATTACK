using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200029E RID: 670
	public class ProtectionEffects
	{
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06001E3C RID: 7740 RVA: 0x001D3A90 File Offset: 0x001D1C90
		public TimeSpan remaining
		{
			get
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				return this.expireTime - currentServerTime;
			}
		}

		// Token: 0x06001E3D RID: 7741 RVA: 0x001D3AB0 File Offset: 0x001D1CB0
		public override string ToString()
		{
			switch (this.Type)
			{
			case ProtectionEffects.protectionType.INTERDICTED:
				return SK.Text("TOUCH_Y_INTERDICTED", "Interdicted") + " " + VillageMap.createBuildTimeString((int)this.remaining.TotalSeconds);
			case ProtectionEffects.protectionType.PEACETIME:
				return SK.Text("TOUCH_Y_PEACETIME", "Peace Time") + " " + VillageMap.createBuildTimeString((int)this.remaining.TotalSeconds);
			case ProtectionEffects.protectionType.EXCOMMUNICATED:
				if (this.isUserVillage)
				{
					return SK.Text("OtherVillagePanel_Excom", "Excommunicated") + " " + VillageMap.createBuildTimeString((int)this.remaining.TotalSeconds);
				}
				return SK.Text("OtherVillagePanel_Excom", "Excommunicated");
			case ProtectionEffects.protectionType.VACATION:
				return SK.Text("VACATION_CANCEL_HEADER", "Vacation Mode is Active");
			default:
				return SK.Text("TOUCH_Y_NoProtection", "No Protection");
			}
		}

		// Token: 0x04002EE6 RID: 12006
		public bool isUserVillage;

		// Token: 0x04002EE7 RID: 12007
		public DateTime expireTime;

		// Token: 0x04002EE8 RID: 12008
		public ProtectionEffects.protectionType Type;

		// Token: 0x0200029F RID: 671
		public enum protectionType
		{
			// Token: 0x04002EEA RID: 12010
			NONE,
			// Token: 0x04002EEB RID: 12011
			INTERDICTED,
			// Token: 0x04002EEC RID: 12012
			PEACETIME,
			// Token: 0x04002EED RID: 12013
			EXCOMMUNICATED,
			// Token: 0x04002EEE RID: 12014
			VACATION
		}
	}
}
