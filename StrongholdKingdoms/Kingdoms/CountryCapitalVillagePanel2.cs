using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000148 RID: 328
	public class CountryCapitalVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C1A RID: 3098 RVA: 0x0000F024 File Offset: 0x0000D224
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x0000F034 File Offset: 0x0000D234
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0000F044 File Offset: 0x0000D244
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0000F056 File Offset: 0x0000D256
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0000F063 File Offset: 0x0000D263
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0000F071 File Offset: 0x0000D271
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0000F07E File Offset: 0x0000D27E
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0000F08B File Offset: 0x0000D28B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x000EB210 File Offset: 0x000E9410
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "CountryCapitalVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06000C23 RID: 3107 RVA: 0x000EB25C File Offset: 0x000E945C
		public CountryCapitalVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x000EB2F4 File Offset: 0x000E94F4
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(false, 1503);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 49);
			this.tradeButton.Enabled = false;
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnTradeWith_Click), "CountryCapitalVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(45, 49);
			this.attackButton.Enabled = false;
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "CountryCapitalVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(80, 49);
			this.scoutButton.Enabled = false;
			this.scoutButton.CustomTooltipID = 2412;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "CountryCapitalVillagePanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(115, 49);
			this.reinforceButton.Enabled = false;
			this.reinforceButton.CustomTooltipID = 2413;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendTroops_Click), "CountryCapitalVillagePanel2_reinforce");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			this.monkButton.Position = new Point(150, 49);
			this.monkButton.Enabled = false;
			this.monkButton.CustomTooltipID = 2414;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendMonks_Click), "CountryCapitalVillagePanel2_sendmonks");
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

		// Token: 0x06000C25 RID: 3109 RVA: 0x000EB650 File Offset: 0x000E9850
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

		// Token: 0x06000C26 RID: 3110 RVA: 0x000EB728 File Offset: 0x000E9928
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

		// Token: 0x06000C27 RID: 3111 RVA: 0x000EB83C File Offset: 0x000E9A3C
		public void updateCountryCapitalVillageText(int selectedVillage, int ownVillage)
		{
			this.m_selectedVillage = selectedVillage;
			string villageName = GameEngine.Instance.World.getVillageName(selectedVillage);
			this.backGround.updateHeading(villageName);
			this.backGround.setActionFromVillage(InterfaceMgr.Instance.getSelectedMenuVillage(), selectedVillage);
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
					this.monkButton.Enabled = false;
					this.reinforceButton.Enabled = false;
					flag = false;
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
			if ((this.attackButton.Enabled || this.scoutButton.Enabled) && GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
			{
				VillageData villageData = GameEngine.Instance.World.getVillageData(selectedVillage);
				if (villageData != null)
				{
					if (GameEngine.Instance.World.isHeretic())
					{
						if (villageData.factionID >= 1 && villageData.factionID <= 4)
						{
							this.attackButton.Enabled = false;
							this.scoutButton.Enabled = false;
						}
					}
					else if (villageData.factionID < 1 || villageData.factionID > 4)
					{
						this.attackButton.Enabled = false;
						this.scoutButton.Enabled = false;
					}
				}
			}
			this.updateSize();
			this.update();
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x000EBA5C File Offset: 0x000E9C5C
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

		// Token: 0x06000C29 RID: 3113 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnSendCourtiers_Click()
		{
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0000F0AA File Offset: 0x0000D2AA
		private void btnAttack_Click()
		{
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillage);
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x000EBAEC File Offset: 0x000E9CEC
		private void btnSendTroops_Click()
		{
			if (!GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			}
			else
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			}
			InterfaceMgr.Instance.setCapitalSendTargetVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.setVillageTabSubMode(17);
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0000F0D0 File Offset: 0x0000D2D0
		private void btnScout_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillage, true);
			}
		}

		// Token: 0x06000C2D RID: 3117 RVA: 0x0000F0ED File Offset: 0x0000D2ED
		private void btnSendMonks_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.m_selectedVillage);
			}
		}

		// Token: 0x0400101B RID: 4123
		private DockableControl dockableControl;

		// Token: 0x0400101C RID: 4124
		private IContainer components;

		// Token: 0x0400101D RID: 4125
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x0400101E RID: 4126
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400101F RID: 4127
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001020 RID: 4128
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001021 RID: 4129
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001022 RID: 4130
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001023 RID: 4131
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001024 RID: 4132
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001025 RID: 4133
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04001026 RID: 4134
		private int m_selectedVillage = -1;
	}
}
