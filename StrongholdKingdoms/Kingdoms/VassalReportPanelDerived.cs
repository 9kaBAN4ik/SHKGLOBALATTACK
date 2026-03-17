using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C0 RID: 1216
	internal class VassalReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06002CFD RID: 11517 RVA: 0x0023E188 File Offset: 0x0023C388
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			short reportType = returnData.reportType;
			if (reportType != 15)
			{
				if (reportType != 16)
				{
					switch (reportType)
					{
					case 46:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Offers_Liege_lord", "offers to be liege lord of");
						this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						this.villageID = returnData.defendingVillage;
						break;
					case 47:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Accepted_Liege_Lord", "has accepted your liege lord offer and becomes your vassal to");
						this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.attackingVillage);
						this.villageID = returnData.attackingVillage;
						break;
					case 48:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Has_declined_Liege_lord_Offer", "has declined your liege lord offer from");
						this.lblSecondaryText.Text = GameEngine.Instance.World.getVillageName(returnData.attackingVillage);
						this.villageID = returnData.attackingVillage;
						break;
					case 49:
						this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
						this.lblSubTitle.Text = SK.Text("Reports_Withdrawn_Liege_Lord_Offer", "has withdrawn the liege lord offer for");
						this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
						this.villageID = returnData.defendingVillage;
						break;
					}
				}
				else
				{
					CustomSelfDrawPanel.CSDLabel lblMainText = this.lblMainText;
					lblMainText.Text = lblMainText.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
					this.lblSubTitle.Text = SK.Text("Reports_No_Longer_Liege_Lord", "No longer has a liege lord");
					this.lblSecondaryText.Text = "";
					this.villageID = returnData.attackingVillage;
				}
			}
			else
			{
				CustomSelfDrawPanel.CSDLabel lblMainText2 = this.lblMainText;
				lblMainText2.Text = lblMainText2.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Has_Lost_Vassal", "Has Lost a Vassal");
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				this.villageID = returnData.attackingVillage;
				this.lblFurther.Text = SK.Text("Reports_Troops_Lost", "Troops Lost") + " : " + returnData.genericData1.ToString("N", this.nfi);
				this.lblFurther.Visible = true;
				base.addControl(this.lblFurther);
			}
			if (GameEngine.Instance.World.isUserVillage(this.villageID))
			{
				this.btnUtility.Text.Text = SK.Text("GENERIC_Vassals", "Vassals");
				this.btnUtility.Visible = true;
				return;
			}
			this.btnUtility.Visible = false;
		}

		// Token: 0x06002CFE RID: 11518 RVA: 0x0023E5A0 File Offset: 0x0023C7A0
		protected override void utilityClick()
		{
			if (this.villageID >= 0)
			{
				GameEngine.Instance.playInterfaceSound("VassalLostReportPanel_vassals");
				InterfaceMgr.Instance.selectUserVillage(this.villageID, false);
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setVillageTabSubMode(8);
				this.m_parent.closeControl(true);
				InterfaceMgr.Instance.reactiveMainWindow();
			}
		}

		// Token: 0x04003819 RID: 14361
		private int villageID = -1;
	}
}
