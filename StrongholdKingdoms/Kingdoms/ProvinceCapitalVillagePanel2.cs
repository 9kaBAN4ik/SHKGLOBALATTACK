using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002A0 RID: 672
	public class ProvinceCapitalVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001E3F RID: 7743 RVA: 0x0001CF15 File Offset: 0x0001B115
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x0001CF25 File Offset: 0x0001B125
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001E41 RID: 7745 RVA: 0x0001CF35 File Offset: 0x0001B135
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x0001CF47 File Offset: 0x0001B147
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001E43 RID: 7747 RVA: 0x0001CF54 File Offset: 0x0001B154
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001E44 RID: 7748 RVA: 0x0001CF62 File Offset: 0x0001B162
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001E45 RID: 7749 RVA: 0x0001CF6F File Offset: 0x0001B16F
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x0001CF7C File Offset: 0x0001B17C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001E47 RID: 7751 RVA: 0x001D3BA4 File Offset: 0x001D1DA4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "ProvinceCapitalVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001E48 RID: 7752 RVA: 0x001D3BF0 File Offset: 0x001D1DF0
		public ProvinceCapitalVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x001D3C88 File Offset: 0x001D1E88
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(false, 1502);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 49);
			this.tradeButton.Enabled = false;
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnTradeWith_Click), "ProvinceCapitalVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(45, 49);
			this.attackButton.Enabled = false;
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "ProvinceCapitalVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(80, 49);
			this.scoutButton.Enabled = false;
			this.scoutButton.CustomTooltipID = 2412;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "ProvinceCapitalVillagePanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(115, 49);
			this.reinforceButton.Enabled = false;
			this.reinforceButton.CustomTooltipID = 2413;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendTroops_Click), "ProvinceCapitalVillagePanel2_reinforce");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			this.monkButton.Position = new Point(150, 49);
			this.monkButton.Enabled = false;
			this.monkButton.CustomTooltipID = 2414;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendMonks_Click), "ProvinceCapitalVillagePanel2_send_monks");
			this.backImage.addControl(this.monkButton);
			this.lblProtectionType.Text = "";
			this.lblProtectionType.Color = global::ARGBColors.Black;
			this.lblProtectionType.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.lblProtectionType.Position = new Point(0, 38);
			this.lblProtectionType.Size = new Size(this.backImage.Width, 23);
			this.lblProtectionType.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backImage.addControl(this.lblProtectionType);
			this.lblProtected.Text = "";
			this.lblProtected.Color = global::ARGBColors.Black;
			this.lblProtected.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.lblProtected.Position = new Point(6, 48);
			this.lblProtected.Size = new Size(this.backImage.Width - 12, 74);
			this.lblProtected.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backImage.addControl(this.lblProtected);
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x001D3FE4 File Offset: 0x001D21E4
		private void updateSize()
		{
			bool visible = this.lblProtectionType.Visible;
			int num = 0;
			if (!visible)
			{
				this.backImage.Image = GFXLibrary.mrhp_world_panel_102;
				num = -95;
			}
			else
			{
				this.backImage.Image = GFXLibrary.mrhp_world_panel_192;
			}
			this.tradeButton.Position = new Point(10, 142 + num);
			this.attackButton.Position = new Point(45, 142 + num);
			this.scoutButton.Position = new Point(80, 142 + num);
			this.reinforceButton.Position = new Point(115, 142 + num);
			this.monkButton.Position = new Point(150, 142 + num);
			this.backGround.invalidate();
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x001D40BC File Offset: 0x001D22BC
		public void update()
		{
			this.backGround.update();
			bool visible = this.lblProtectionType.Visible;
			int num = 0;
			TimeSpan timeSpan = default(TimeSpan);
			if (GameEngine.Instance.World.isVillageInterdictProtected(this.m_selectedVillage))
			{
				DateTime interdictTime = GameEngine.Instance.World.getInterdictTime(this.m_selectedVillage);
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				timeSpan = interdictTime - currentServerTime;
				num = 1;
			}
			if (num == 1)
			{
				int secsLeft = (int)timeSpan.TotalSeconds;
				string str = VillageMap.createBuildTimeStringFull(secsLeft);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Interdict", "Interdict");
				this.lblProtectionType.Visible = true;
			}
			else
			{
				this.lblProtected.TextDiffOnly = "";
				this.lblProtectionType.TextDiffOnly = "";
				this.lblProtectionType.Visible = false;
			}
			if (visible != this.lblProtectionType.Visible)
			{
				this.updateSize();
			}
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x001D41D0 File Offset: 0x001D23D0
		public void updateProvinceCapitalVillageText(int selectedVillage, int ownVillage)
		{
			this.m_selectedVillage = selectedVillage;
			string villageName = GameEngine.Instance.World.getVillageName(selectedVillage);
			this.backGround.updateHeading(villageName);
			this.backGround.setActionFromVillage(ownVillage, selectedVillage);
			if (ownVillage < 0 || !GameEngine.Instance.World.isUserVillage(ownVillage))
			{
				this.scoutButton.Enabled = false;
				this.tradeButton.Enabled = false;
				this.attackButton.Enabled = false;
				this.monkButton.Enabled = false;
				this.reinforceButton.Enabled = false;
			}
			else
			{
				this.scoutButton.Enabled = true;
				this.tradeButton.Enabled = true;
				this.attackButton.Enabled = true;
				this.monkButton.Enabled = true;
				this.reinforceButton.Enabled = true;
				bool flag = true;
				if (GameEngine.Instance.World.isCapital(ownVillage))
				{
					this.scoutButton.Enabled = false;
					flag = false;
					this.monkButton.Enabled = false;
					this.reinforceButton.Enabled = false;
				}
				else
				{
					this.scoutButton.Enabled = true;
				}
				if (selectedVillage < 0 || ownVillage < 0)
				{
					this.tradeButton.Enabled = false;
				}
				else
				{
					if (!GameEngine.Instance.World.allowExchangeTrade(selectedVillage, ownVillage))
					{
						flag = false;
					}
					if (flag)
					{
						this.tradeButton.Enabled = true;
					}
					else
					{
						this.tradeButton.Enabled = false;
					}
				}
			}
			this.updateSize();
			this.update();
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x001D4340 File Offset: 0x001D2540
		private void btnTradeWith_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.selectStockExchange(-1);
				if (!GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
				{
					GameEngine.Instance.SkipVillageTab();
					InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				}
				else
				{
					InterfaceMgr.Instance.getMainTabBar().changeTab(2);
				}
				InterfaceMgr.Instance.setVillageTabSubMode(3);
				InterfaceMgr.Instance.resetVillageReportPanelData();
				InterfaceMgr.Instance.selectStockExchange(this.m_selectedVillage);
			}
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnSendCourtiers_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x0001CF9B File Offset: 0x0001B19B
		private void btnAttack_Click()
		{
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillage);
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x001D43D0 File Offset: 0x001D25D0
		private void btnSendTroops_Click()
		{
			if (!GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			}
			else
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			}
			InterfaceMgr.Instance.setCapitalSendTargetVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.setVillageTabSubMode(17);
		}

		// Token: 0x06001E51 RID: 7761 RVA: 0x0001CFC1 File Offset: 0x0001B1C1
		private void btnScout_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillage, true);
			}
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x0001CFDE File Offset: 0x0001B1DE
		private void btnSendMonks_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.m_selectedVillage);
			}
		}

		// Token: 0x04002EEF RID: 12015
		private DockableControl dockableControl;

		// Token: 0x04002EF0 RID: 12016
		private IContainer components;

		// Token: 0x04002EF1 RID: 12017
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002EF2 RID: 12018
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002EF3 RID: 12019
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002EF4 RID: 12020
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002EF5 RID: 12021
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002EF6 RID: 12022
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002EF7 RID: 12023
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002EF8 RID: 12024
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002EF9 RID: 12025
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002EFA RID: 12026
		private int m_selectedVillage = -1;
	}
}
