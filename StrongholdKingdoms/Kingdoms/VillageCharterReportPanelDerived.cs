using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004CD RID: 1229
	internal class VillageCharterReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06002D79 RID: 11641 RVA: 0x00242E24 File Offset: 0x00241024
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.lblSubTitle.Text = SK.Text("Reports_purchased_charter_Failed", "Has Failed to Purchase Village Charter");
			this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
			switch (returnData.reportType)
			{
			case 93:
				this.lblSubTitle.Text = SK.Text("Reports_purchased_charter", "Has Purchased Village Charter");
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.defendingVillage);
				break;
			case 94:
				this.lblFurther.Text = SK.Text("Reports_purchased_charter_Failed_gold", "You had insufficient Gold to purchase this Charter when your Captain arrived at the village.");
				break;
			case 95:
				this.lblFurther.Text = SK.Text("Reports_purchased_charter_Failed_bought", "Someone has purchased this Charter before your captain arrived.");
				break;
			case 96:
				this.lblFurther.Text = SK.Text("Reports_purchased_charter_Failed_too_many", "You already have your maximum number of villages and cannot buy this Charter.");
				break;
			}
			if (returnData.reportType != 93)
			{
				base.showFurtherInfo();
			}
			if (this.m_returnData.defendingVillage >= 0)
			{
				this.mapTarget = GameEngine.Instance.World.getVillageLocation(this.m_returnData.defendingVillage);
				this.targetZoomLevel = 10000.0;
				this.btnUtility.Visible = true;
				this.btnUtility.Text.Text = SK.Text("Reports_Show_On_Map", "Show On Map");
			}
		}

		// Token: 0x06002D7A RID: 11642 RVA: 0x00242FA0 File Offset: 0x002411A0
		protected override void utilityClick()
		{
			if (this.mapTarget.X != -1)
			{
				GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
				InterfaceMgr.Instance.changeTab(0);
				GameEngine.Instance.World.startMultiStageZoom(this.targetZoomLevel, (double)this.mapTarget.X, (double)this.mapTarget.Y);
				this.m_parent.closeControl(true);
				InterfaceMgr.Instance.reactiveMainWindow();
			}
		}

		// Token: 0x0400389B RID: 14491
		private Point mapTarget = new Point(-1, -1);

		// Token: 0x0400389C RID: 14492
		private double targetZoomLevel;
	}
}
