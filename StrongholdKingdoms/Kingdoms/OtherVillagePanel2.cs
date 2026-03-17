using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000261 RID: 609
	public class OtherVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001ADD RID: 6877 RVA: 0x0001ACF6 File Offset: 0x00018EF6
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x0001AD06 File Offset: 0x00018F06
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x0001AD16 File Offset: 0x00018F16
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x0001AD28 File Offset: 0x00018F28
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x0001AD35 File Offset: 0x00018F35
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x0001AD43 File Offset: 0x00018F43
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0001AD50 File Offset: 0x00018F50
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x0001AD5D File Offset: 0x00018F5D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x001A8C8C File Offset: 0x001A6E8C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OtherVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x001A8CD8 File Offset: 0x001A6ED8
		public OtherVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x001A8DA8 File Offset: 0x001A6FA8
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 142);
			this.tradeButton.CustomTooltipID = 2410;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendResources), "OtherVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(45, 142);
			this.attackButton.CustomTooltipID = 2411;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendTroops), "OtherVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(80, 142);
			this.scoutButton.CustomTooltipID = 2412;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendScouts), "OtherVillagePanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.REINFORCE);
			this.reinforceButton.Position = new Point(115, 142);
			this.reinforceButton.CustomTooltipID = 2413;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendReinforcements), "OtherVillagePanel2_reinforce");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			this.monkButton.Position = new Point(150, 142);
			this.monkButton.CustomTooltipID = 2414;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendMonks), "OtherVillagePanel2_sendmonks");
			this.backImage.addControl(this.monkButton);
			this.vassalButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.VASSAL);
			this.vassalButton.Position = new Point(115, 112);
			this.vassalButton.CustomTooltipID = 2446;
			this.vassalButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.vassalClick), "OtherVillagePanel2_make_vassal");
			this.backImage.addControl(this.vassalButton);
			this.castleButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.LAST_REPORT);
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2445;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OtherVillagePanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			if (RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
			{
				this.renameButton.ImageNorm = GFXLibrary.faction_pen;
				this.renameButton.OverBrighten = true;
				this.renameButton.MoveOnClick = true;
				this.renameButton.Position = new Point(139, 57);
				this.renameButton.CustomTooltipID = 10390;
				this.renameButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resetNameClick));
				this.backImage.addControl(this.renameButton);
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
			this.leftButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoLeft), "OtherVillagePanel2_protection_left");
			this.leftButton.Visible = false;
			this.backImage.addControl(this.leftButton);
			this.rightButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.rightButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.rightButton.Position = new Point(170, 50);
			this.rightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoRight), "OtherVillagePanel2_protection_right");
			this.rightButton.Visible = false;
			this.backImage.addControl(this.rightButton);
			this.updateSize();
			this.numInfos = 0;
			this.selectedProtection = 0;
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x001A9328 File Offset: 0x001A7528
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
			this.tradeButton.Position = new Point(10, 142 + num);
			this.attackButton.Position = new Point(45, 142 + num);
			this.scoutButton.Position = new Point(80, 142 + num);
			this.reinforceButton.Position = new Point(115, 142 + num);
			this.monkButton.Position = new Point(150, 142 + num);
			this.vassalButton.Position = new Point(96, 112 + num + num2);
			this.castleButton.Position = new Point(64, 112 + num + num2);
			this.renameButton.Position = new Point(149, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x001A9450 File Offset: 0x001A7650
		public void update()
		{
			this.backGround.update();
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
				string str = VillageMap.createBuildTimeStringFull(secsLeft);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Interdict", "Interdict");
				this.lblProtectionType.Visible = true;
				break;
			}
			case 2:
			{
				int secsLeft2 = (int)timeSpan.TotalSeconds;
				string str2 = VillageMap.createBuildTimeStringFull(secsLeft2);
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
				GameEngine.Instance.World.getVillageFaction(InterfaceMgr.Instance.OwnSelectedVillage);
				GameEngine.Instance.World.getVillageFaction(this.m_selectedVillage);
				if (GameEngine.Instance.World.isUserVillage(this.m_selectedVillage))
				{
					this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Attack_Own_Village", "Cannot attack your own village");
					this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Your_Village", "Your Village");
					this.lblProtectionType.Visible = true;
				}
				else
				{
					this.lblProtected.TextDiffOnly = "";
					this.lblProtectionType.Visible = false;
				}
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

		// Token: 0x06001AEA RID: 6890 RVA: 0x001A9824 File Offset: 0x001A7A24
		public void updateOtherVillageText(int selectedVillage)
		{
			this.m_selectedVillage = selectedVillage;
			this.backGround.updateHeading(GameEngine.Instance.World.getVillageName(selectedVillage));
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			this.backGround.setActionFromVillage(InterfaceMgr.Instance.getSelectedMenuVillage(), selectedVillage);
			if (GameEngine.Instance.World.isCapital(InterfaceMgr.Instance.OwnSelectedVillage))
			{
				this.tradeButton.Enabled = false;
				this.vassalButton.Enabled = false;
				this.monkButton.Enabled = false;
				this.scoutButton.Enabled = false;
				if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
				{
					this.attackButton.Enabled = false;
					this.reinforceButton.Enabled = false;
				}
				else
				{
					this.attackButton.Enabled = true;
					this.reinforceButton.Enabled = true;
				}
			}
			else
			{
				this.attackButton.Enabled = true;
				this.reinforceButton.Enabled = true;
				this.tradeButton.Enabled = true;
				this.scoutButton.Enabled = true;
				this.monkButton.Enabled = true;
				int num = GameEngine.Instance.World.numVassalsAllowed();
				int num2 = GameEngine.Instance.World.countVassals();
				if (num > num2)
				{
					this.vassalButton.Enabled = true;
				}
				else
				{
					this.vassalButton.Enabled = false;
				}
			}
			if ((this.attackButton.Enabled || this.scoutButton.Enabled || this.vassalButton.Enabled) && GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
			{
				VillageData villageData = GameEngine.Instance.World.getVillageData(selectedVillage);
				if (villageData != null)
				{
					if (GameEngine.Instance.World.isHeretic())
					{
						this.vassalButton.Enabled = false;
						if (villageData.factionID == 4)
						{
							this.attackButton.Enabled = false;
							this.scoutButton.Enabled = false;
						}
					}
					else if (villageData.factionID != 4)
					{
						this.attackButton.Enabled = false;
						this.scoutButton.Enabled = false;
					}
				}
			}
			this.updateSize();
			this.update();
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x001A9A4C File Offset: 0x001A7C4C
		public void forceDisable()
		{
			this.attackButton.Enabled = false;
			this.vassalButton.Enabled = false;
			this.reinforceButton.Enabled = false;
			this.scoutButton.Enabled = false;
			this.monkButton.Enabled = false;
			this.tradeButton.Enabled = false;
		}

		// Token: 0x06001AEC RID: 6892 RVA: 0x0001AD7C File Offset: 0x00018F7C
		private void sendResources()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openTradeMode(this.m_selectedVillage, false);
			}
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x0001AD98 File Offset: 0x00018F98
		private void sendTroops()
		{
			if (this.m_selectedVillage >= 0)
			{
				GameEngine.Instance.preAttackSetup(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.OwnSelectedVillage, this.m_selectedVillage);
			}
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x0001ADC7 File Offset: 0x00018FC7
		private void sendScouts()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openScoutPopupWindow(this.m_selectedVillage, true);
			}
		}

		// Token: 0x06001AEF RID: 6895 RVA: 0x0001ADE4 File Offset: 0x00018FE4
		private void sendMonks()
		{
			if (this.m_selectedVillage >= 0)
			{
				InterfaceMgr.Instance.openSendMonkWindow(this.m_selectedVillage);
			}
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x0001AE00 File Offset: 0x00019000
		private void resetNameClick()
		{
			if (MyMessageBox.Show(SK.Text("Mod_Reset_Default", "Are you sure you want to reset the village name to its default?"), SK.Text("Mod_Confirm", "Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.ResetName();
			}
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x001A9AA4 File Offset: 0x001A7CA4
		private void ResetName()
		{
			int selectedVillage = InterfaceMgr.Instance.SelectedVillage;
			RemoteServices.Instance.VillageResetName(selectedVillage);
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x0001AE2F File Offset: 0x0001902F
		private void castleClick()
		{
			RemoteServices.Instance.set_ViewCastle_UserCallBack(new RemoteServices.ViewCastle_UserCallBack(this.viewCastleCallback));
			RemoteServices.Instance.ViewCastle_Village(this.m_selectedVillage);
		}

		// Token: 0x06001AF3 RID: 6899 RVA: 0x001A9AC8 File Offset: 0x001A7CC8
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

		// Token: 0x06001AF4 RID: 6900 RVA: 0x001A9B40 File Offset: 0x001A7D40
		private void vassalClick()
		{
			if (!GameEngine.Instance.World.WorldEnded && this.m_selectedVillage >= 0)
			{
				GameEngine.Instance.SkipVillageTab();
				InterfaceMgr.Instance.getMainTabBar().changeTab(1);
				InterfaceMgr.Instance.setVillageTabSubMode(8);
				InterfaceMgr.Instance.resetVillageReportPanelData();
				InterfaceMgr.Instance.selectVassalTarget(this.m_selectedVillage);
			}
		}

		// Token: 0x06001AF5 RID: 6901 RVA: 0x001A9BA8 File Offset: 0x001A7DA8
		private void sendReinforcements()
		{
			if (!GameEngine.Instance.World.WorldEnded && this.m_selectedVillage >= 0)
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
				InterfaceMgr.Instance.setVillageTabSubMode(6);
				InterfaceMgr.Instance.getVillageTabBar().changeTabGfxOnly(9);
				InterfaceMgr.Instance.setReinforcementVillage(this.m_selectedVillage);
			}
		}

		// Token: 0x06001AF6 RID: 6902 RVA: 0x0001AE57 File Offset: 0x00019057
		private void infoLeft()
		{
			this.selectedProtection--;
			if (this.selectedProtection < 0)
			{
				this.selectedProtection = this.numInfos - 1;
			}
		}

		// Token: 0x06001AF7 RID: 6903 RVA: 0x0001AE7E File Offset: 0x0001907E
		private void infoRight()
		{
			this.selectedProtection++;
			if (this.selectedProtection >= this.numInfos)
			{
				this.selectedProtection = 0;
			}
		}

		// Token: 0x04002BBE RID: 11198
		private DockableControl dockableControl;

		// Token: 0x04002BBF RID: 11199
		private IContainer components;

		// Token: 0x04002BC0 RID: 11200
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002BC1 RID: 11201
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC2 RID: 11202
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC3 RID: 11203
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC4 RID: 11204
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC5 RID: 11205
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC6 RID: 11206
		private CustomSelfDrawPanel.CSDButton vassalButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC7 RID: 11207
		private CustomSelfDrawPanel.CSDButton renameButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC8 RID: 11208
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BC9 RID: 11209
		private CustomSelfDrawPanel.CSDButton leftButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BCA RID: 11210
		private CustomSelfDrawPanel.CSDButton rightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BCB RID: 11211
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BCC RID: 11212
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BCD RID: 11213
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002BCE RID: 11214
		private int selectedProtection;

		// Token: 0x04002BCF RID: 11215
		private int numInfos;

		// Token: 0x04002BD0 RID: 11216
		private int m_selectedVillage = -1;

		// Token: 0x04002BD1 RID: 11217
		private MyMessageBoxPopUp PopUpRef;
	}
}
