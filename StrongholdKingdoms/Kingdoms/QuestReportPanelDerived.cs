using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002A7 RID: 679
	internal class QuestReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001E86 RID: 7814 RVA: 0x001D7594 File Offset: 0x001D5794
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			short reportType = returnData.reportType;
			switch (reportType)
			{
			case 100:
			{
				this.lblSubTitle.Text = SK.Text("Reports_Quest_Complete", "Completed Quest") + " :";
				int genericData = returnData.genericData1;
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(genericData);
				this.lblSecondaryText.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef.tagString);
				break;
			}
			case 101:
			{
				this.lblSubTitle.Text = SK.Text("Reports_Quest Failed", "Failed Quest") + " :";
				int genericData2 = returnData.genericData1;
				NewQuests.NewQuestDefinition newQuestDef2 = NewQuests.getNewQuestDef(genericData2);
				this.lblSecondaryText.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef2.tagString);
				break;
			}
			case 102:
				this.lblSubTitle.Text = SK.Text("Reports_Spins", "Wheel Spin Prize");
				this.lblSecondaryText.Text = Wheel.getRewardText(returnData.genericData1, returnData.genericData2, this.nfi);
				return;
			default:
				if (reportType - 129 <= 2 || reportType == 136)
				{
					if (returnData.reportType == 129)
					{
						this.lblSubTitle.Text = SK.Text("Reports_AI_Spins", "Wheel Spin Bonus from AI Razing");
					}
					else if (returnData.reportType == 136)
					{
						this.lblSubTitle.Text = SK.Text("Reports_Heretic_Spins", "Wheel Spin Bonus from Player Razing");
					}
					else if (returnData.reportType == 131)
					{
						this.lblSubTitle.Text = SK.Text("Reports_AI_Spins_capture", "Wheel Spin Bonus from AI Capture");
					}
					else
					{
						this.lblSubTitle.Text = SK.Text("Reports_Forage_Spins", "Wheel Spin Bonus from Foraging");
					}
					switch (returnData.genericData1)
					{
					case 2:
						if (returnData.genericData2 <= 1)
						{
							this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins2", "Tier 2 Wheel Spin");
							return;
						}
						this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins2_bonus", "2 Tier 2 Wheel Spins");
						return;
					case 3:
						if (returnData.genericData2 <= 1)
						{
							this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins3", "Tier 3 Wheel Spin");
							return;
						}
						this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins3_bonus", "2 Tier 3 Wheel Spins");
						return;
					case 4:
						if (returnData.genericData2 <= 1)
						{
							this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins4", "Tier 4 Wheel Spin");
							return;
						}
						this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins4_bonus", "2 Tier 4 Wheel Spins");
						return;
					case 5:
						if (returnData.genericData2 <= 1)
						{
							this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins5", "Tier 5 Wheel Spin");
							return;
						}
						this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins5_bonus", "2 Tier 5 Wheel Spins");
						return;
					default:
						if (returnData.genericData2 <= 1)
						{
							this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins1", "Tier 1 Wheel Spin");
							return;
						}
						this.lblSecondaryText.Text = SK.Text("REPORTS_SeasonalWheelSpins1_bonus", "2 Tier 1 Wheel Spins");
						return;
					}
				}
				break;
			}
			this.btnUtility.Visible = true;
			this.btnUtility.Text.Text = SK.Text("GENERIC_Quests", "Quests");
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x0001D22E File Offset: 0x0001B42E
		protected override void utilityClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(5);
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}
	}
}
