using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000264 RID: 612
	public class OwnParishCapitalPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B1E RID: 6942 RVA: 0x001AA9E4 File Offset: 0x001A8BE4
		public OwnParishCapitalPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x001AAAB0 File Offset: 0x001A8CB0
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(80, 142);
			this.tradeButton.CustomTooltipID = 2441;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradeClick), "OwnParishCapitalPanel2_trade");
			this.backImage.addControl(this.tradeButton);
			if (GameEngine.Instance.World.MapEditing)
			{
				this.mapEdit.ImageNorm = GFXLibrary.faction_pen;
				this.mapEdit.ImageOver = GFXLibrary.faction_pen;
				this.mapEdit.ImageClick = GFXLibrary.faction_pen;
				this.mapEdit.MoveOnClick = true;
				this.mapEdit.OverBrighten = true;
				this.mapEdit.Position = new Point(150, 142);
				this.mapEdit.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.mapEditClicked));
				this.backImage.addControl(this.mapEdit);
			}
			this.villageButton.ImageNorm = GFXLibrary.int_world_icon_village;
			this.villageButton.OverBrighten = true;
			this.villageButton.MoveOnClick = true;
			this.villageButton.Position = new Point(29, 112);
			this.villageButton.CustomTooltipID = 2437;
			this.villageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClick), "OwnParishCapitalPanel2_view_village");
			this.backImage.addControl(this.villageButton);
			this.castleButton.ImageNorm = GFXLibrary.int_world_icon_castle;
			this.castleButton.OverBrighten = true;
			this.castleButton.MoveOnClick = true;
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2438;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OwnParishCapitalPanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			this.resourcesButton.ImageNorm = GFXLibrary.int_world_icon_resource;
			this.resourcesButton.OverBrighten = true;
			this.resourcesButton.MoveOnClick = true;
			this.resourcesButton.Position = new Point(99, 112);
			this.resourcesButton.CustomTooltipID = 2439;
			this.resourcesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourcesClick), "OwnParishCapitalPanel2_view_resources");
			this.backImage.addControl(this.resourcesButton);
			this.troopsButton.ImageNorm = GFXLibrary.int_world_icon_troops;
			this.troopsButton.OverBrighten = true;
			this.troopsButton.MoveOnClick = true;
			this.troopsButton.Position = new Point(134, 112);
			this.troopsButton.CustomTooltipID = 2442;
			this.troopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopsClick), "OwnParishCapitalPanel2_make_troops");
			this.backImage.addControl(this.troopsButton);
			this.lblPlagueValue.Text = "";
			this.lblPlagueValue.Color = global::ARGBColors.Black;
			this.lblPlagueValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.lblPlagueValue.Position = new Point(82, 10);
			this.lblPlagueValue.Size = new Size(48, 22);
			this.lblPlagueValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backImage.addControl(this.lblPlagueValue);
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
			this.leftButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoLeft), "OwnParishCapitalPanel2_protection_left");
			this.leftButton.Visible = false;
			this.backImage.addControl(this.leftButton);
			this.rightButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.rightButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.rightButton.Position = new Point(170, 50);
			this.rightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.infoRight), "OwnParishCapitalPanel2_protection_right");
			this.rightButton.Visible = false;
			this.backImage.addControl(this.rightButton);
			this.lastPlague = -100;
			this.numInfos = 0;
			this.selectedProtection = 0;
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x001AB088 File Offset: 0x001A9288
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
			this.tradeButton.Position = new Point(80, 142 + num);
			this.mapEdit.Position = new Point(150, 142 + num);
			this.villageButton.Position = new Point(29, 112 + num + num2);
			this.castleButton.Position = new Point(64, 112 + num + num2);
			this.resourcesButton.Position = new Point(99, 112 + num + num2);
			this.troopsButton.Position = new Point(134, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x001AB180 File Offset: 0x001A9380
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

		// Token: 0x06001B22 RID: 6946 RVA: 0x001AB5C4 File Offset: 0x001A97C4
		public void updateOwnVillageText(int selectedVillage)
		{
			this.lastPlague = -100;
			this.m_selectedVillage = selectedVillage;
			string villageName = GameEngine.Instance.World.getVillageName(selectedVillage);
			this.backGround.updateHeading(villageName);
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			this.backGround.setActionFromVillage(selectedVillage, -1);
			this.lblPlagueValue.TextDiffOnly = "";
			this.updateSize();
			this.update();
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x0001AF29 File Offset: 0x00019129
		private void villageClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(0);
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x0001AF4B File Offset: 0x0001914B
		private void castleClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x0001AF6D File Offset: 0x0001916D
		private void resourcesClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1005);
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x0001AF8E File Offset: 0x0001918E
		private void troopsClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1004);
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x0001AFAF File Offset: 0x000191AF
		private void tradeClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(3);
		}

		// Token: 0x06001B28 RID: 6952 RVA: 0x0001B057 File Offset: 0x00019257
		private void infoLeft()
		{
			this.selectedProtection--;
			if (this.selectedProtection < 0)
			{
				this.selectedProtection = this.numInfos - 1;
			}
		}

		// Token: 0x06001B29 RID: 6953 RVA: 0x0001B07E File Offset: 0x0001927E
		private void infoRight()
		{
			this.selectedProtection++;
			if (this.selectedProtection >= this.numInfos)
			{
				this.selectedProtection = 0;
			}
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x001AB634 File Offset: 0x001A9834
		private void mapEditClicked()
		{
			RenameVillagePopup renameVillagePopup = new RenameVillagePopup();
			renameVillagePopup.setParishVillageID(this.m_selectedVillage, GameEngine.Instance.World.getVillageName(this.m_selectedVillage));
			renameVillagePopup.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x0001B0A3 File Offset: 0x000192A3
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x0001B0B3 File Offset: 0x000192B3
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x0001B0C3 File Offset: 0x000192C3
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B2E RID: 6958 RVA: 0x0001B0D5 File Offset: 0x000192D5
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B2F RID: 6959 RVA: 0x0001B0E2 File Offset: 0x000192E2
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001B30 RID: 6960 RVA: 0x0001B0F0 File Offset: 0x000192F0
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B31 RID: 6961 RVA: 0x0001B0FD File Offset: 0x000192FD
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B32 RID: 6962 RVA: 0x0001B10A File Offset: 0x0001930A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x001AB678 File Offset: 0x001A9878
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OwnParishCapitalPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x04002BEA RID: 11242
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002BEB RID: 11243
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BEC RID: 11244
		private CustomSelfDrawPanel.CSDButton villageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BED RID: 11245
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BEE RID: 11246
		private CustomSelfDrawPanel.CSDButton resourcesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BEF RID: 11247
		private CustomSelfDrawPanel.CSDButton troopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BF0 RID: 11248
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BF1 RID: 11249
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BF2 RID: 11250
		private CustomSelfDrawPanel.CSDButton leftButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BF3 RID: 11251
		private CustomSelfDrawPanel.CSDButton rightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BF4 RID: 11252
		private CustomSelfDrawPanel.CSDLabel lblPlagueValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BF5 RID: 11253
		private CustomSelfDrawPanel.CSDButton mapEdit = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BF6 RID: 11254
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002BF7 RID: 11255
		private int lastPlague = -100;

		// Token: 0x04002BF8 RID: 11256
		private int selectedProtection;

		// Token: 0x04002BF9 RID: 11257
		private int numInfos;

		// Token: 0x04002BFA RID: 11258
		private int m_selectedVillage = -1;

		// Token: 0x04002BFB RID: 11259
		private DockableControl dockableControl;

		// Token: 0x04002BFC RID: 11260
		private IContainer components;
	}
}
