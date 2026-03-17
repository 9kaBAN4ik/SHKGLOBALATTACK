using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004D4 RID: 1236
	internal class VillageLostReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06002D9D RID: 11677 RVA: 0x00244354 File Offset: 0x00242554
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.lblMainText.Text = SK.Text("Reports_VillageLost", "Village Lost");
			if (returnData.otherUser.Length == 0)
			{
				this.lblSubTitle.Text = SK.Text("Reports_VillageLost_inactivity", "Village Lost due to Inactivity");
			}
			else if (returnData.reportType == 128)
			{
				this.lblSubTitle.Text = SK.Text("Reports_VillageLost_abandoned", "Village Abandoned");
			}
			else
			{
				this.lblSubTitle.Text = SK.Text("Reports_VillageLost_attacked by", "Attacked By") + " : " + returnData.otherUser;
			}
			this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
		}
	}
}
