using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000268 RID: 616
	public class ParishCapitalVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B73 RID: 7027 RVA: 0x0001B494 File Offset: 0x00019694
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x0001B4A4 File Offset: 0x000196A4
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B75 RID: 7029 RVA: 0x0001B4B4 File Offset: 0x000196B4
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B76 RID: 7030 RVA: 0x0001B4C6 File Offset: 0x000196C6
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B77 RID: 7031 RVA: 0x0001B4D3 File Offset: 0x000196D3
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001B78 RID: 7032 RVA: 0x0001B4E1 File Offset: 0x000196E1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B79 RID: 7033 RVA: 0x0001B4EE File Offset: 0x000196EE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B7A RID: 7034 RVA: 0x0001B4FB File Offset: 0x000196FB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B7B RID: 7035 RVA: 0x001ACCF4 File Offset: 0x001AAEF4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "ParishCapitalVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B7C RID: 7036 RVA: 0x001ACD40 File Offset: 0x001AAF40
		public ParishCapitalVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B7D RID: 7037 RVA: 0x001ACE18 File Offset: 0x001AB018
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			base.addControl(this.backImage);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 49);
			this.tradeButton.Enabled = false;
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnTradeWith_Click), "ParishCapitalVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(45, 49);
			this.attackButton.Enabled = false;
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnAttack_Click), "ParishCapitalVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(80, 49);
			this.scoutButton.Enabled = false;
			this.scoutButton.CustomTooltipID = 2412;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnScout_Click), "ParishCapitalVillagePanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(115, 49);
			this.reinforceButton.Enabled = false;
			this.reinforceButton.CustomTooltipID = 2413;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendTroops_Click), "ParishCapitalVillagePanel2_reinforce");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			this.monkButton.Position = new Point(150, 49);
			this.monkButton.Enabled = false;
			this.monkButton.CustomTooltipID = 2414;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnSendMonks_Click), "ParishCapitalVillagePanel2_sendmonks");
			this.backImage.addControl(this.monkButton);
			this.castleButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.LAST_REPORT);
			this.castleButton.Position = new Point(82, 112);
			this.castleButton.CustomTooltipID = 2445;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "ParishCapitalVillagePanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			if (GameEngine.Instance.World.MapEditing)
			{
				this.mapEdit.ImageNorm = GFXLibrary.faction_pen;
				this.mapEdit.ImageOver = GFXLibrary.faction_pen;
				this.mapEdit.ImageClick = GFXLibrary.faction_pen;
				this.mapEdit.MoveOnClick = true;
				this.mapEdit.OverBrighten = true;
				this.mapEdit.Position = new Point(168, 112);
				this.mapEdit.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mapEditClicked));
				this.backImage.addControl(this.mapEdit);
			}
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
			this.leftButton.ImageNorm = GFXLibrary.r_arrow_small_left_norm;
			this.leftButton.ImageOver = GFXLibrary.r_arrow_small_left_over;
			this.leftButton.Position = new Point(5, 50);
			this.leftButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoLeft), "ParishCapitalVillagePanel2_protection_left");
			this.leftButton.Visible = false;
			this.backImage.addControl(this.leftButton);
			this.rightButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.rightButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.rightButton.Position = new Point(170, 50);
			this.rightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoRight), "ParishCapitalVillagePanel2_protection_right");
			this.rightButton.Visible = false;
			this.backImage.addControl(this.rightButton);
			this.lblPlagueValue.Text = "";
			this.lblPlagueValue.Color = global::ARGBColors.Black;
			this.lblPlagueValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.lblPlagueValue.Position = new Point(82, 10);
			this.lblPlagueValue.Size = new Size(48, 22);
			this.lblPlagueValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backImage.addControl(this.lblPlagueValue);
			this.lastPlague = -100;
			this.numInfos = 0;
			this.selectedProtection = 0;
		}

		// Token: 0x06001B7E RID: 7038 RVA: 0x001AD40C File Offset: 0x001AB60C
		private void updateSize()
		{
			bool visible = this.lblProtectionType.Visible;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (!visible)
			{
				this.backImage.Image = GFXLibrary.mrhp_world_panel_132;
				num = -63;
				num2 = -4;
			}
			else
			{
				this.backImage.Image = GFXLibrary.mrhp_world_panel_192;
			}
			if (!this.castleButton.Visible)
			{
				num3 = -15;
			}
			this.tradeButton.Position = new Point(10, 142 + num + num3);
			this.attackButton.Position = new Point(45, 142 + num + num3);
			this.scoutButton.Position = new Point(80, 142 + num + num3);
			this.reinforceButton.Position = new Point(115, 142 + num + num3);
			this.monkButton.Position = new Point(150, 142 + num + num3);
			this.castleButton.Position = new Point(82, 112 + num + num2);
			this.mapEdit.Position = new Point(168, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06001B7F RID: 7039 RVA: 0x001AD538 File Offset: 0x001AB738
		public void update()
		{
			this.backGround.update();
			int[] array = new int[3];
			TimeSpan[] array2 = new TimeSpan[3];
			int num = this.numInfos;
			this.numInfos = 0;
			int parishPlagueLevel = GameEngine.Instance.World.getParishPlagueLevel(this.m_selectedVillage);
			if (parishPlagueLevel != this.lastPlague)
			{
				if (parishPlagueLevel <= 0)
				{
					this.backGround.updatePanelType(1500);
					this.lblPlagueValue.TextDiffOnly = "";
				}
				else if (this.lastPlague <= 0)
				{
					this.backGround.updatePanelType(1504);
					this.lblPlagueValue.TextDiffOnly = parishPlagueLevel.ToString();
				}
				this.backGround.setTooltipData(parishPlagueLevel);
				this.lastPlague = parishPlagueLevel;
			}
			bool visible = this.lblProtectionType.Visible;
			int num2 = 0;
			TimeSpan timeSpan = default(TimeSpan);
			if (GameEngine.Instance.World.isVillageInterdictProtected(this.m_selectedVillage))
			{
				DateTime interdictTime = GameEngine.Instance.World.getInterdictTime(this.m_selectedVillage);
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				timeSpan = interdictTime - currentServerTime;
				num2 = 1;
				array2[this.numInfos] = timeSpan;
				array[this.numInfos] = num2;
				this.numInfos++;
			}
			if (GameEngine.Instance.World.isVillagePeaceTimeProtected(this.m_selectedVillage))
			{
				DateTime peaceTime = GameEngine.Instance.World.getPeaceTime(this.m_selectedVillage);
				DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
				TimeSpan timeSpan2 = peaceTime - currentServerTime2;
				if (timeSpan2 > timeSpan)
				{
					timeSpan = timeSpan2;
					num2 = 2;
					array2[this.numInfos] = timeSpan;
					array[this.numInfos] = num2;
					this.numInfos++;
				}
			}
			if (this.numInfos > 0)
			{
				if (this.selectedProtection < this.numInfos)
				{
					num2 = array[this.numInfos - 1 - this.selectedProtection];
					timeSpan = array2[this.numInfos - 1 - this.selectedProtection];
				}
				else
				{
					this.selectedProtection = 0;
				}
			}
			if (num2 != 1)
			{
				if (num2 != 2)
				{
					this.lblProtected.TextDiffOnly = "";
					this.lblProtectionType.TextDiffOnly = "";
					this.lblProtectionType.Visible = false;
				}
				else
				{
					int secsLeft = (int)timeSpan.TotalSeconds;
					string str = VillageMap.createBuildTimeStringFull(secsLeft);
					this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str;
					this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Peace", "Peace");
					this.lblProtectionType.Visible = true;
				}
			}
			else
			{
				int secsLeft2 = (int)timeSpan.TotalSeconds;
				string str2 = VillageMap.createBuildTimeStringFull(secsLeft2);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str2;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Interdict", "Interdict");
				this.lblProtectionType.Visible = true;
			}
			if (visible != this.lblProtectionType.Visible)
			{
				this.updateSize();
				if (!visible)
				{
					this.selectedProtection = 0;
				}
			}
			if (num != this.numInfos)
			{
				if (this.numInfos >= 2)
				{
					this.leftButton.Visible = true;
					this.rightButton.Visible = true;
					return;
				}
				this.leftButton.Visible = false;
				this.rightButton.Visible = false;
			}
		}

		// Token: 0x06001B80 RID: 7040 RVA: 0x001AD898 File Offset: 0x001ABA98
		public void updateParishCapitalVillageText(int selectedVillage, int ownVillage)
		{
			bool flag = true;
			this.m_selectedVillage = selectedVillage;
			this.lastPlague = -100;
			this.lblPlagueValue.TextDiffOnly = "";
			string villageName = GameEngine.Instance.World.getVillageName(selectedVillage);
			this.backGround.updateHeading(villageName);
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
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
				if (GameEngine.Instance.World.isCapital(ownVillage))
				{
					this.scoutButton.Enabled = false;
					this.tradeButton.Enabled = false;
					this.reinforceButton.Enabled = false;
					this.monkButton.Enabled = false;
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
			if (!GameEngine.Instance.World.doesUserHaveVillageInParishByCapital(this.m_selectedVillage))
			{
				this.castleButton.Visible = true;
			}
			else
			{
				this.castleButton.Visible = false;
			}
			this.updateSize();
			this.update();
		}

		// Token: 0x06001B81 RID: 7041 RVA: 0x001ADB10 File Offset: 0x001ABD10
		private void btnTradeWith_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.selectStockExchange(-1);
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setVillageTabSubMode(3);
				InterfaceMgr.Instance.resetVillageReportPanelData();
				InterfaceMgr.Instance.selectStockExchange(this.m_selectedVillage);
			}
		}

		// Token: 0x06001B82 RID: 7042 RVA: 0x0001B51A File Offset: 0x0001971A
		private void btnSendCourtiers_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.showParishPanel(0);
			}
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0001B530 File Offset: 0x00019730
		private void btnAttack_Click()
		{
			GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillage);
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0001B556 File Offset: 0x00019756
		private void btnSendTroops_Click()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setCapitalSendTargetVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.setVillageTabSubMode(17);
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0001B58E File Offset: 0x0001978E
		private void btnScout_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillage, true);
			}
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0001B5AB File Offset: 0x000197AB
		private void btnSendMonks_Click()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.m_selectedVillage);
			}
		}

		// Token: 0x06001B87 RID: 7047 RVA: 0x0001B5C7 File Offset: 0x000197C7
		private void castleClick()
		{
			if (!GameEngine.Instance.World.doesUserHaveVillageInParishByCapital(this.m_selectedVillage))
			{
				RemoteServices.Instance.set_ViewCastle_UserCallBack(new RemoteServices.ViewCastle_UserCallBack(this.viewCastleCallback));
				RemoteServices.Instance.ViewCastle_Village(this.m_selectedVillage);
			}
		}

		// Token: 0x06001B88 RID: 7048 RVA: 0x001ADB70 File Offset: 0x001ABD70
		public void viewCastleCallback(ViewCastle_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.closeControl(true);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(6);
				GameEngine.Instance.InitCastleView(returnData.castleMapSnapshot, returnData.castleTroopsSnapshot, returnData.keepLevel, 0, returnData.defencesLevel, returnData.villageID, returnData.landType);
				CastleMapBattlePanel2.fromWorld();
				InterfaceMgr.Instance.castleBattleTimes(returnData.lastCastleTime, returnData.lastTroopTime);
			}
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0001B606 File Offset: 0x00019806
		private void infoLeft()
		{
			this.selectedProtection--;
			if (this.selectedProtection < 0)
			{
				this.selectedProtection = this.numInfos - 1;
			}
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x0001B62D File Offset: 0x0001982D
		private void infoRight()
		{
			this.selectedProtection++;
			if (this.selectedProtection >= this.numInfos)
			{
				this.selectedProtection = 0;
			}
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x001ADBE8 File Offset: 0x001ABDE8
		private void mapEditClicked()
		{
			RenameVillagePopup renameVillagePopup = new RenameVillagePopup();
			renameVillagePopup.setParishVillageID(this.m_selectedVillage, GameEngine.Instance.World.getVillageName(this.m_selectedVillage));
			renameVillagePopup.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x04002C1F RID: 11295
		private DockableControl dockableControl;

		// Token: 0x04002C20 RID: 11296
		private IContainer components;

		// Token: 0x04002C21 RID: 11297
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002C22 RID: 11298
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C23 RID: 11299
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C24 RID: 11300
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C25 RID: 11301
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C26 RID: 11302
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C27 RID: 11303
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C28 RID: 11304
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C29 RID: 11305
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C2A RID: 11306
		private CustomSelfDrawPanel.CSDButton leftButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C2B RID: 11307
		private CustomSelfDrawPanel.CSDButton rightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C2C RID: 11308
		private CustomSelfDrawPanel.CSDLabel lblPlagueValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C2D RID: 11309
		private CustomSelfDrawPanel.CSDButton mapEdit = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C2E RID: 11310
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002C2F RID: 11311
		private int lastPlague = -100;

		// Token: 0x04002C30 RID: 11312
		private int selectedProtection;

		// Token: 0x04002C31 RID: 11313
		private int numInfos;

		// Token: 0x04002C32 RID: 11314
		private int m_selectedVillage = -1;
	}
}
