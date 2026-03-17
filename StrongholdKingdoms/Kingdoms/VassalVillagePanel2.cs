using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C4 RID: 1220
	public class VassalVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002D27 RID: 11559 RVA: 0x000212CA File Offset: 0x0001F4CA
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002D28 RID: 11560 RVA: 0x000212DA File Offset: 0x0001F4DA
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002D29 RID: 11561 RVA: 0x000212EA File Offset: 0x0001F4EA
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002D2A RID: 11562 RVA: 0x000212FC File Offset: 0x0001F4FC
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002D2B RID: 11563 RVA: 0x00021309 File Offset: 0x0001F509
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002D2C RID: 11564 RVA: 0x00021317 File Offset: 0x0001F517
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002D2D RID: 11565 RVA: 0x00021324 File Offset: 0x0001F524
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002D2E RID: 11566 RVA: 0x00021331 File Offset: 0x0001F531
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D2F RID: 11567 RVA: 0x0023EB38 File Offset: 0x0023CD38
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "VassalVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06002D30 RID: 11568 RVA: 0x0023EB84 File Offset: 0x0023CD84
		public VassalVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002D31 RID: 11569 RVA: 0x0023EC3C File Offset: 0x0023CE3C
		public void init()
		{
			this.attackMode = false;
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			this.drawArea.Size = this.backImage.Size;
			this.drawArea.Position = new Point(0, 0);
			this.drawArea.Visible = true;
			this.backImage.addControl(this.drawArea);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(29, 142);
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendResources), "VassalVillagePanel2_trade");
			this.drawArea.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(64, 142);
			this.attackButton.CustomTooltipID = 2453;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendTroops), "VassalVillagePanel2_attack_from");
			this.drawArea.addControl(this.attackButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(99, 142);
			this.reinforceButton.CustomTooltipID = 2451;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendReinforcements), "VassalVillagePanel2_manage_troops");
			this.drawArea.addControl(this.reinforceButton);
			this.vassalButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.VASSAL);
			this.vassalButton.Position = new Point(134, 142);
			this.vassalButton.CustomTooltipID = 2452;
			this.vassalButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.vassalClick), "VassalVillagePanel2_manage_vassals");
			this.drawArea.addControl(this.vassalButton);
			this.castleButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.LAST_REPORT);
			this.castleButton.Position = new Point(80, 112);
			this.castleButton.CustomTooltipID = 2445;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "VassalVillagePanel2_view_castle_report");
			this.drawArea.addControl(this.castleButton);
			this.lblProtectionType.Text = "";
			this.lblProtectionType.Color = global::ARGBColors.Black;
			this.lblProtectionType.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.lblProtectionType.Position = new Point(0, 38);
			this.lblProtectionType.Size = new Size(this.backImage.Width, 23);
			this.lblProtectionType.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.drawArea.addControl(this.lblProtectionType);
			this.lblProtected.Text = "";
			this.lblProtected.Color = global::ARGBColors.Black;
			this.lblProtected.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.lblProtected.Position = new Point(6, 48);
			this.lblProtected.Size = new Size(this.backImage.Width - 12, 74);
			this.lblProtected.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.drawArea.addControl(this.lblProtected);
			this.leftButton.ImageNorm = GFXLibrary.r_arrow_small_left_norm;
			this.leftButton.ImageOver = GFXLibrary.r_arrow_small_left_over;
			this.leftButton.Position = new Point(5, 50);
			this.leftButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoLeft), "VassalVillagePanel2_protection_left");
			this.leftButton.Visible = false;
			this.drawArea.addControl(this.leftButton);
			this.rightButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.rightButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.rightButton.Position = new Point(170, 50);
			this.rightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoRight), "VassalVillagePanel2_protection_right");
			this.rightButton.Visible = false;
			this.drawArea.addControl(this.rightButton);
			this.updateSize();
			this.numInfos = 0;
			this.selectedProtection = 0;
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x0023F0B8 File Offset: 0x0023D2B8
		private void updateSize()
		{
			bool visible = this.lblProtectionType.Visible;
			int num = 0;
			int num2 = 0;
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
			this.tradeButton.Position = new Point(29, 142 + num);
			this.attackButton.Position = new Point(64, 142 + num);
			this.reinforceButton.Position = new Point(99, 142 + num);
			this.vassalButton.Position = new Point(134, 142 + num);
			this.castleButton.Position = new Point(80, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06002D33 RID: 11571 RVA: 0x0023F194 File Offset: 0x0023D394
		public void update()
		{
			this.backGround.update();
			if (this.attackMode && InterfaceMgr.Instance.SelectedVassalVillage < 0)
			{
				this.backImage.Size = this.backImage.Image.Size;
				this.drawArea.Visible = true;
				this.backGround.updateHeading(GameEngine.Instance.World.getVillageName(this.m_selectedVillage));
			}
			int[] array = new int[3];
			TimeSpan[] array2 = new TimeSpan[3];
			int num = this.numInfos;
			this.numInfos = 0;
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
				}
				array2[this.numInfos] = timeSpan2;
				array[this.numInfos] = 2;
				this.numInfos++;
			}
			if (GameEngine.Instance.World.isVillageVacationProtected(this.m_selectedVillage))
			{
				num2 = 3;
				array[this.numInfos] = 3;
				this.numInfos++;
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
			switch (num2)
			{
			case 1:
			{
				int secsLeft = (int)timeSpan.TotalSeconds;
				string str = VillageMap.createBuildTimeString(secsLeft);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Interdict", "Interdict");
				this.lblProtectionType.Visible = true;
				break;
			}
			case 2:
			{
				int secsLeft2 = (int)timeSpan.TotalSeconds;
				string str2 = VillageMap.createBuildTimeString(secsLeft2);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str2;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Peace", "Peace");
				this.lblProtectionType.Visible = true;
				break;
			}
			case 3:
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked", "Cannot be attacked");
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Vacation", "Vacation Mode");
				this.lblProtectionType.Visible = true;
				break;
			default:
				this.lblProtected.TextDiffOnly = "";
				this.lblProtectionType.TextDiffOnly = "";
				this.lblProtectionType.Visible = false;
				break;
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

		// Token: 0x06002D34 RID: 11572 RVA: 0x0023F544 File Offset: 0x0023D744
		public void updateVassalVillageText(int selectedVillage)
		{
			this.attackMode = false;
			this.m_selectedVillage = selectedVillage;
			string villageNameOrType = GameEngine.Instance.World.getVillageNameOrType(selectedVillage);
			this.backGround.updateHeading(villageNameOrType);
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			this.backGround.setActionFromVillage(InterfaceMgr.Instance.getSelectedMenuVillage(), selectedVillage);
			this.updateSize();
			this.update();
		}

		// Token: 0x06002D35 RID: 11573 RVA: 0x00021350 File Offset: 0x0001F550
		private void sendResources()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openTradeMode(this.m_selectedVillage, false);
			}
		}

		// Token: 0x06002D36 RID: 11574 RVA: 0x0002136C File Offset: 0x0001F56C
		private void castleClick()
		{
			RemoteServices.Instance.set_ViewCastle_UserCallBack(new RemoteServices.ViewCastle_UserCallBack(this.viewCastleCallback));
			RemoteServices.Instance.ViewCastle_Village(this.m_selectedVillage);
		}

		// Token: 0x06002D37 RID: 11575 RVA: 0x0023F5AC File Offset: 0x0023D7AC
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

		// Token: 0x06002D38 RID: 11576 RVA: 0x0023F624 File Offset: 0x0023D824
		private void sendTroops()
		{
			InterfaceMgr.Instance.setVassalAttackMode(this.m_selectedVillage);
			this.attackMode = true;
			this.backImage.Size = new Size(1, 1);
			this.drawArea.Visible = false;
			this.backGround.updateHeading(SK.Text("VassalVillagePanel_Attack_From_Here", "Attack From Here"));
		}

		// Token: 0x06002D39 RID: 11577 RVA: 0x00021394 File Offset: 0x0001F594
		private void vassalClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(8);
		}

		// Token: 0x06002D3A RID: 11578 RVA: 0x000213BB File Offset: 0x0001F5BB
		private void sendReinforcements()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVassalArmiesVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.setVillageTabSubMode(15);
		}

		// Token: 0x06002D3B RID: 11579 RVA: 0x000213F3 File Offset: 0x0001F5F3
		private void infoLeft()
		{
			this.selectedProtection--;
			if (this.selectedProtection < 0)
			{
				this.selectedProtection = this.numInfos - 1;
			}
		}

		// Token: 0x06002D3C RID: 11580 RVA: 0x0002141A File Offset: 0x0001F61A
		private void infoRight()
		{
			this.selectedProtection++;
			if (this.selectedProtection >= this.numInfos)
			{
				this.selectedProtection = 0;
			}
		}

		// Token: 0x04003825 RID: 14373
		private DockableControl dockableControl;

		// Token: 0x04003826 RID: 14374
		private IContainer components;

		// Token: 0x04003827 RID: 14375
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04003828 RID: 14376
		private CustomSelfDrawPanel.CSDArea drawArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003829 RID: 14377
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400382A RID: 14378
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400382B RID: 14379
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400382C RID: 14380
		private CustomSelfDrawPanel.CSDButton vassalButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400382D RID: 14381
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400382E RID: 14382
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400382F RID: 14383
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003830 RID: 14384
		private CustomSelfDrawPanel.CSDButton leftButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003831 RID: 14385
		private CustomSelfDrawPanel.CSDButton rightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003832 RID: 14386
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04003833 RID: 14387
		private bool attackMode;

		// Token: 0x04003834 RID: 14388
		private int selectedProtection;

		// Token: 0x04003835 RID: 14389
		private int numInfos;

		// Token: 0x04003836 RID: 14390
		private int m_selectedVillage = -1;
	}
}
