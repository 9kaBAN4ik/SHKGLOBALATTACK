using System;
using System.Drawing;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000269 RID: 617
	internal class ParishElectionReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001B8C RID: 7052 RVA: 0x001ADC2C File Offset: 0x001ABE2C
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.lblMainText.Text = returnData.otherUser;
			this.lblSubTitle.Text = SK.Text("Reports_Is_Elected_For", "Is Elected For");
			short reportType = returnData.reportType;
			if (reportType <= 53)
			{
				if (reportType != 28)
				{
					if (reportType == 53)
					{
						this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.genericData8) + " / " + GameEngine.Instance.World.getCountyName(GameEngine.Instance.World.getCountyFromVillageID(returnData.genericData8));
					}
				}
				else
				{
					this.lblSecondaryText.Text = GameEngine.Instance.World.getParishNameFromVillageID(returnData.genericData8);
				}
			}
			else if (reportType != 74)
			{
				if (reportType == 75)
				{
					this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.genericData8) + " / " + GameEngine.Instance.World.getCountryName(GameEngine.Instance.World.getCountryFromVillageID(returnData.genericData8));
				}
			}
			else
			{
				this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.genericData8) + " / " + GameEngine.Instance.World.getProvinceName(GameEngine.Instance.World.getProvinceFromVillageID(returnData.genericData8));
			}
			if (returnData.genericData8 >= 0)
			{
				this.mapTarget = GameEngine.Instance.World.getVillageLocation(returnData.genericData8);
				this.targetZoomLevel = 10000.0;
				this.btnUtility.Text.Text = SK.Text("Reports_Show_On_Map", "Show On Map");
				this.btnUtility.Visible = true;
				return;
			}
			this.btnUtility.Visible = false;
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x001ADE1C File Offset: 0x001AC01C
		protected override void utilityClick()
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
			if (this.mapTarget.X != -1)
			{
				InterfaceMgr.Instance.changeTab(0);
				GameEngine.Instance.World.startMultiStageZoom(this.targetZoomLevel, (double)this.mapTarget.X, (double)this.mapTarget.Y);
				this.m_parent.closeControl(true);
				InterfaceMgr.Instance.reactiveMainWindow();
			}
		}

		// Token: 0x04002C33 RID: 11315
		private Point mapTarget = new Point(-1, -1);

		// Token: 0x04002C34 RID: 11316
		private double targetZoomLevel;
	}
}
