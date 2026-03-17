using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002B3 RID: 691
	internal class ReinforcementsReportPanelDerived : GenericReportPanelBasic
	{
		// Token: 0x06001EE6 RID: 7910 RVA: 0x0001D6FB File Offset: 0x0001B8FB
		public ReinforcementsReportPanelDerived()
		{
			base.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new Size(580, 480);
		}

		// Token: 0x06001EE7 RID: 7911 RVA: 0x001DC53C File Offset: 0x001DA73C
		public override void init(IDockableControl parent, Size size, object back)
		{
			base.init(parent, size, back);
			this.valuesPanel = new ReportBattleValuesPanel(this, new Size(this.btnClose.X - this.btnForward.Rectangle.Right - 4, 200));
			this.valuesPanel.Position = new Point(this.btnForward.Rectangle.Right + 2, base.Height - this.valuesPanel.Height);
			string header = SK.Text("GENERIC_Reinforcements", "Reinforcements");
			this.valuesPanel.init(header, false, true);
			if (base.hasBackground())
			{
				this.imgBackground.addControl(this.valuesPanel);
				return;
			}
			base.addControl(this.valuesPanel);
		}

		// Token: 0x06001EE8 RID: 7912 RVA: 0x001DC604 File Offset: 0x001DA804
		public override void setData(GetReport_ReturnType returnData)
		{
			base.setData(returnData);
			this.valuesPanel.setData(returnData.genericData1, returnData.genericData2, returnData.genericData3, returnData.genericData4, returnData.genericData5, 0);
			switch (returnData.reportType)
			{
			case 17:
				this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Sent_Reinforcements_To", "sent reinforcements to");
				this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			case 18:
			{
				CustomSelfDrawPanel.CSDLabel lblMainText = this.lblMainText;
				lblMainText.Text = lblMainText.Text + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Reinforcements_Returned_From", "Reinforcements have returned from");
				this.lblSecondaryText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			}
			case 19:
				this.lblMainText.Text = returnData.otherUser + " (" + GameEngine.Instance.World.getVillageName(returnData.attackingVillage) + ")";
				this.lblSubTitle.Text = SK.Text("Reports_Retrieved_Reinforcements", "has retrieved reinforcements from");
				this.lblSecondaryText.Text = this.reportOwner + " (" + GameEngine.Instance.World.getVillageName(returnData.defendingVillage) + ")";
				break;
			}
			if (returnData.defendingVillage >= 0)
			{
				this.mapTarget = GameEngine.Instance.World.getVillageLocation(returnData.defendingVillage);
				this.targetZoomLevel = 10000.0;
				this.btnUtility.Visible = true;
				this.btnUtility.Text.Text = SK.Text("Reports_Show_On_Map", "Show On Map");
			}
			else
			{
				this.btnUtility.Visible = false;
			}
			this.lblMainText.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackerDoubleClick), "Reports_Attacker_DClick");
			this.lblSecondaryText.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.defenderDoubleClick), "Reports_Defender_DClick");
		}

		// Token: 0x06001EE9 RID: 7913 RVA: 0x001DC8A0 File Offset: 0x001DAAA0
		protected override void utilityClick()
		{
			if (this.mapTarget.X != -1)
			{
				GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
				InterfaceMgr.Instance.changeTab(0);
				GameEngine.Instance.World.startMultiStageZoom(this.targetZoomLevel, (double)this.mapTarget.X, (double)this.mapTarget.Y);
				this.m_parent.closeControl(true);
			}
		}

		// Token: 0x06001EEA RID: 7914 RVA: 0x00076AA0 File Offset: 0x00074CA0
		private void attackerDoubleClick()
		{
			if (this.m_returnData != null)
			{
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_returnData.attackingVillage);
				double targetZoom = 10000.0;
				if (villageLocation.X != -1)
				{
					GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
					InterfaceMgr.Instance.changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(targetZoom, (double)villageLocation.X, (double)villageLocation.Y);
					this.m_parent.closeControl(true);
					InterfaceMgr.Instance.reactiveMainWindow();
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_returnData.attackingVillage, false, true, false, false);
				}
			}
		}

		// Token: 0x06001EEB RID: 7915 RVA: 0x00076B50 File Offset: 0x00074D50
		private void defenderDoubleClick()
		{
			if (this.m_returnData != null)
			{
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.m_returnData.defendingVillage);
				double targetZoom = 10000.0;
				if (villageLocation.X != -1)
				{
					GameEngine.Instance.playInterfaceSound("ReportsGeneric_goto_map");
					InterfaceMgr.Instance.changeTab(0);
					GameEngine.Instance.World.startMultiStageZoom(targetZoom, (double)villageLocation.X, (double)villageLocation.Y);
					this.m_parent.closeControl(true);
					InterfaceMgr.Instance.reactiveMainWindow();
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.m_returnData.defendingVillage, false, true, false, false);
				}
			}
		}

		// Token: 0x04002FCB RID: 12235
		private ReportBattleValuesPanel valuesPanel;

		// Token: 0x04002FCC RID: 12236
		private Point mapTarget = new Point(-1, -1);

		// Token: 0x04002FCD RID: 12237
		private double targetZoomLevel;

		// Token: 0x04002FCE RID: 12238
		protected TroopCount reinforcementsTroopCount;
	}
}
