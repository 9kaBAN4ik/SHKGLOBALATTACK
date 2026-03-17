using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200014F RID: 335
	public class CountyCapitalVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C61 RID: 3169 RVA: 0x0000F318 File Offset: 0x0000D518
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0000F328 File Offset: 0x0000D528
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0000F338 File Offset: 0x0000D538
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0000F34A File Offset: 0x0000D54A
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0000F357 File Offset: 0x0000D557
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0000F365 File Offset: 0x0000D565
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0000F372 File Offset: 0x0000D572
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0000F37F File Offset: 0x0000D57F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x000EEDC0 File Offset: 0x000ECFC0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "CountyCapitalVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x000EEE0C File Offset: 0x000ED00C
		public CountyCapitalVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x000EEEA4 File Offset: 0x000ED0A4
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(false, 1501);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 49);
			this.tradeButton.Enabled = false;
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnTradeWith_Click), "CountyCapitalVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(45, 49);
			this.attackButton.Enabled = false;
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "CountyCapitalVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(80, 49);
			this.scoutButton.Enabled = false;
			this.scoutButton.CustomTooltipID = 2412;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "CountyCapitalVillagePanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(115, 49);
			this.reinforceButton.Enabled = false;
			this.reinforceButton.CustomTooltipID = 2413;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendTroops_Click), "CountyCapitalVillagePanel2_reinforce");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			this.monkButton.Position = new Point(150, 49);
			this.monkButton.Enabled = false;
			this.monkButton.CustomTooltipID = 2414;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendMonks_Click), "CountyCapitalVillagePanel2_sendmonks");
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

		// Token: 0x06000C6C RID: 3180 RVA: 0x000EF200 File Offset: 0x000ED400
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

		// Token: 0x06000C6D RID: 3181 RVA: 0x000EF2D8 File Offset: 0x000ED4D8
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

		// Token: 0x06000C6E RID: 3182 RVA: 0x000EF3EC File Offset: 0x000ED5EC
		public void updateCountyCapitalVillageText(int selectedVillage, int ownVillage)
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

		// Token: 0x06000C6F RID: 3183 RVA: 0x000EF60C File Offset: 0x000ED80C
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

		// Token: 0x06000C70 RID: 3184 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnSendCourtiers_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x0000F39E File Offset: 0x0000D59E
		private void btnAttack_Click()
		{
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillage);
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x000EF69C File Offset: 0x000ED89C
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

		// Token: 0x06000C73 RID: 3187 RVA: 0x0000F3C4 File Offset: 0x0000D5C4
		private void btnScout_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillage, true);
			}
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x0000F3E1 File Offset: 0x0000D5E1
		private void btnSendMonks_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.m_selectedVillage);
			}
		}

		// Token: 0x0400107F RID: 4223
		private DockableControl dockableControl;

		// Token: 0x04001080 RID: 4224
		private IContainer components;

		// Token: 0x04001081 RID: 4225
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04001082 RID: 4226
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001083 RID: 4227
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001084 RID: 4228
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001085 RID: 4229
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001086 RID: 4230
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001087 RID: 4231
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001088 RID: 4232
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001089 RID: 4233
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x0400108A RID: 4234
		private int m_selectedVillage = -1;
	}
}
