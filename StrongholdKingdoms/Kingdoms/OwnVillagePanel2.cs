using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000266 RID: 614
	public class OwnVillagePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B47 RID: 6983 RVA: 0x0001B1AF File Offset: 0x000193AF
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x0001B1BF File Offset: 0x000193BF
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x0001B1CF File Offset: 0x000193CF
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x0001B1E1 File Offset: 0x000193E1
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x0001B1EE File Offset: 0x000193EE
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x0001B1FC File Offset: 0x000193FC
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x0001B209 File Offset: 0x00019409
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B4E RID: 6990 RVA: 0x0001B216 File Offset: 0x00019416
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B4F RID: 6991 RVA: 0x001ABD94 File Offset: 0x001A9F94
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OwnVillagePanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B50 RID: 6992 RVA: 0x001ABDE0 File Offset: 0x001A9FE0
		public OwnVillagePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B51 RID: 6993 RVA: 0x001ABEBC File Offset: 0x001AA0BC
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(10, 142);
			this.tradeButton.CustomTooltipID = 2431;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendResources), "OwnVillagePanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[1];
			this.attackButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[8];
			this.attackButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[15];
			this.attackButton.Position = new Point(45, 142);
			this.attackButton.CustomTooltipID = 2432;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendTroops), "OwnVillagePanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[3];
			this.scoutButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[10];
			this.scoutButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[17];
			this.scoutButton.Position = new Point(80, 142);
			this.scoutButton.CustomTooltipID = 2433;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendScouts), "OwnVillagePanel2_scouts");
			this.backImage.addControl(this.scoutButton);
			this.reinforceButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[2];
			this.reinforceButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[9];
			this.reinforceButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[16];
			this.reinforceButton.Position = new Point(115, 142);
			this.reinforceButton.CustomTooltipID = 2434;
			this.reinforceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendReinforcements), "OwnVillagePanel2_reinforcements");
			this.backImage.addControl(this.reinforceButton);
			this.monkButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[4];
			this.monkButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[11];
			this.monkButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[18];
			this.monkButton.Position = new Point(150, 142);
			this.monkButton.CustomTooltipID = 2435;
			this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendMonks), "OwnVillagePanel2_monks");
			this.backImage.addControl(this.monkButton);
			this.villageButton.ImageNorm = GFXLibrary.int_world_icon_village;
			this.villageButton.OverBrighten = true;
			this.villageButton.MoveOnClick = true;
			this.villageButton.Position = new Point(29, 112);
			this.villageButton.CustomTooltipID = 2437;
			this.villageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClick), "OwnVillagePanel2_village");
			this.backImage.addControl(this.villageButton);
			this.castleButton.ImageNorm = GFXLibrary.int_world_icon_castle;
			this.castleButton.OverBrighten = true;
			this.castleButton.MoveOnClick = true;
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2438;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OwnVillagePanel2_castle");
			this.backImage.addControl(this.castleButton);
			this.resourcesButton.ImageNorm = GFXLibrary.int_world_icon_resource;
			this.resourcesButton.OverBrighten = true;
			this.resourcesButton.MoveOnClick = true;
			this.resourcesButton.Position = new Point(99, 112);
			this.resourcesButton.CustomTooltipID = 2439;
			this.resourcesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourcesClick), "OwnVillagePanel2_resources");
			this.backImage.addControl(this.resourcesButton);
			this.troopsButton.ImageNorm = GFXLibrary.int_world_icon_troops;
			this.troopsButton.OverBrighten = true;
			this.troopsButton.MoveOnClick = true;
			this.troopsButton.Position = new Point(134, 112);
			this.troopsButton.CustomTooltipID = 2440;
			this.troopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopsClick), "OwnVillagePanel2_troops");
			this.backImage.addControl(this.troopsButton);
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
			this.leftButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoLeft), "OwnVillagePanel2_protection_left");
			this.leftButton.Visible = false;
			this.backImage.addControl(this.leftButton);
			this.rightButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.rightButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.rightButton.Position = new Point(170, 50);
			this.rightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoRight), "OwnVillagePanel2_protection_right");
			this.rightButton.Visible = false;
			this.backImage.addControl(this.rightButton);
			this.updateSize();
			this.numInfos = 0;
			this.selectedProtection = 0;
		}

		// Token: 0x06001B52 RID: 6994 RVA: 0x001AC5D4 File Offset: 0x001AA7D4
		private void updateSize()
		{
			bool visible = this.lblProtected.Visible;
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
			this.villageButton.Position = new Point(29, 112 + num + num2);
			this.castleButton.Position = new Point(64, 112 + num + num2);
			this.resourcesButton.Position = new Point(99, 112 + num + num2);
			this.troopsButton.Position = new Point(134, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06001B53 RID: 6995 RVA: 0x001AC714 File Offset: 0x001AA914
		public void update()
		{
			this.backGround.update();
			int[] array = new int[3];
			TimeSpan[] array2 = new TimeSpan[3];
			int num = this.numInfos;
			this.numInfos = 0;
			bool visible = this.lblProtected.Visible;
			int num2 = 0;
			TimeSpan timeSpan = default(TimeSpan);
			if (GameEngine.Instance.World.isVillageExcommunicated(this.m_selectedVillage))
			{
				DateTime excommunicationTime = GameEngine.Instance.World.getExcommunicationTime(this.m_selectedVillage);
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				timeSpan = excommunicationTime - currentServerTime;
				num2 = 3;
				array2[this.numInfos] = timeSpan;
				array[this.numInfos] = num2;
				this.numInfos++;
			}
			if (GameEngine.Instance.World.isVillageInterdictProtected(this.m_selectedVillage))
			{
				DateTime interdictTime = GameEngine.Instance.World.getInterdictTime(this.m_selectedVillage);
				DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
				timeSpan = interdictTime - currentServerTime2;
				num2 = 1;
				array2[this.numInfos] = timeSpan;
				array[this.numInfos] = num2;
				this.numInfos++;
			}
			if (GameEngine.Instance.World.isVillagePeaceTimeProtected(this.m_selectedVillage))
			{
				DateTime peaceTime = GameEngine.Instance.World.getPeaceTime(this.m_selectedVillage);
				DateTime currentServerTime3 = VillageMap.getCurrentServerTime();
				TimeSpan timeSpan2 = peaceTime - currentServerTime3;
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
				num2 = 4;
				array[this.numInfos] = 4;
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
				this.lblProtected.Visible = true;
				break;
			}
			case 2:
			{
				int secsLeft2 = (int)timeSpan.TotalSeconds;
				string str2 = VillageMap.createBuildTimeStringFull(secsLeft2);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked_For_X_Time", "Cannot be attacked for") + " : " + str2;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Peace", "Peace");
				this.lblProtectionType.Visible = true;
				this.lblProtected.Visible = true;
				break;
			}
			case 3:
			{
				int secsLeft3 = (int)timeSpan.TotalSeconds;
				string str3 = VillageMap.createBuildTimeStringFull(secsLeft3);
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Excom_For_X_Time", "No Monks for") + " : " + str3;
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Excom", "Excommunicated");
				this.lblProtectionType.Visible = true;
				this.lblProtected.Visible = true;
				break;
			}
			case 4:
				this.lblProtected.TextDiffOnly = SK.Text("OtherVillagePanel_Cannot_Be_Attacked", "Cannot be attacked");
				this.lblProtectionType.TextDiffOnly = SK.Text("OtherVillagePanel_Vacation", "Vacation Mode");
				this.lblProtectionType.Visible = true;
				this.lblProtected.Visible = true;
				break;
			default:
				this.lblProtectionType.Visible = false;
				this.lblProtected.Visible = false;
				break;
			}
			if (visible != this.lblProtected.Visible)
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

		// Token: 0x06001B54 RID: 6996 RVA: 0x001ACB58 File Offset: 0x001AAD58
		public void updateOwnVillageText(int selectedVillage)
		{
			this.m_selectedVillage = selectedVillage;
			this.backGround.updateHeading(GameEngine.Instance.World.getVillageName(selectedVillage));
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			this.backGround.setActionFromVillage(selectedVillage, -1);
			this.updateSize();
			this.update();
		}

		// Token: 0x06001B55 RID: 6997 RVA: 0x0001B235 File Offset: 0x00019435
		private void btnSendOutResources_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-3);
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x0001B267 File Offset: 0x00019467
		private void btnSendTroops_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-5);
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x0001B299 File Offset: 0x00019499
		private void imgVillage_Click(object sender, EventArgs e)
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
		}

		// Token: 0x06001B58 RID: 7000 RVA: 0x0001B2AB File Offset: 0x000194AB
		private void imgCastle_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B59 RID: 7001 RVA: 0x0001B2D7 File Offset: 0x000194D7
		private void imgResources_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(5);
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x0001B2FE File Offset: 0x000194FE
		private void imgTroops_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(4);
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x0001B325 File Offset: 0x00019525
		private void lblVillageName_Click(object sender, EventArgs e)
		{
			if (this.m_selectedVillage >= 0)
			{
				GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			}
		}

		// Token: 0x06001B5C RID: 7004 RVA: 0x0001B299 File Offset: 0x00019499
		private void villageClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
		}

		// Token: 0x06001B5D RID: 7005 RVA: 0x0001B2AB File Offset: 0x000194AB
		private void castleClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B5E RID: 7006 RVA: 0x0001B2D7 File Offset: 0x000194D7
		private void resourcesClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(5);
		}

		// Token: 0x06001B5F RID: 7007 RVA: 0x0001B2FE File Offset: 0x000194FE
		private void troopsClick()
		{
			GameEngine.Instance.SkipVillageTab();
			InterfaceMgr.Instance.getMainTabBar().changeTab(1);
			InterfaceMgr.Instance.setVillageTabSubMode(4);
		}

		// Token: 0x06001B60 RID: 7008 RVA: 0x0001B345 File Offset: 0x00019545
		private void btnScouts_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-7);
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x0001B377 File Offset: 0x00019577
		private void btnSendReinforcements_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-11);
		}

		// Token: 0x06001B62 RID: 7010 RVA: 0x0001B3A9 File Offset: 0x000195A9
		private void btnSendSpies_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-14);
		}

		// Token: 0x06001B63 RID: 7011 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnK_Click()
		{
		}

		// Token: 0x06001B64 RID: 7012 RVA: 0x0001B235 File Offset: 0x00019435
		private void sendResources()
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-3);
		}

		// Token: 0x06001B65 RID: 7013 RVA: 0x0001B267 File Offset: 0x00019467
		private void sendTroops()
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-5);
		}

		// Token: 0x06001B66 RID: 7014 RVA: 0x0001B345 File Offset: 0x00019545
		private void sendScouts()
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-7);
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x0001B377 File Offset: 0x00019577
		private void sendReinforcements()
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-11);
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x0001B3A9 File Offset: 0x000195A9
		private void sendMonks()
		{
			GameEngine.Instance.World.zoomToVillage(this.m_selectedVillage);
			InterfaceMgr.Instance.resetVillageReportPanelData();
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(-14);
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x0001B3DB File Offset: 0x000195DB
		private void infoLeft()
		{
			this.selectedProtection--;
			if (this.selectedProtection < 0)
			{
				this.selectedProtection = this.numInfos - 1;
			}
		}

		// Token: 0x06001B6A RID: 7018 RVA: 0x0001B402 File Offset: 0x00019602
		private void infoRight()
		{
			this.selectedProtection++;
			if (this.selectedProtection >= this.numInfos)
			{
				this.selectedProtection = 0;
			}
		}

		// Token: 0x04002C09 RID: 11273
		private DockableControl dockableControl;

		// Token: 0x04002C0A RID: 11274
		private IContainer components;

		// Token: 0x04002C0B RID: 11275
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002C0C RID: 11276
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C0D RID: 11277
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C0E RID: 11278
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C0F RID: 11279
		private CustomSelfDrawPanel.CSDButton reinforceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C10 RID: 11280
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C11 RID: 11281
		private CustomSelfDrawPanel.CSDButton villageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C12 RID: 11282
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C13 RID: 11283
		private CustomSelfDrawPanel.CSDButton resourcesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C14 RID: 11284
		private CustomSelfDrawPanel.CSDButton troopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C15 RID: 11285
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C16 RID: 11286
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C17 RID: 11287
		private CustomSelfDrawPanel.CSDButton leftButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C18 RID: 11288
		private CustomSelfDrawPanel.CSDButton rightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C19 RID: 11289
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002C1A RID: 11290
		private int selectedProtection;

		// Token: 0x04002C1B RID: 11291
		private int numInfos;

		// Token: 0x04002C1C RID: 11292
		private int m_selectedVillage = -1;
	}
}
