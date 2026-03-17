using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000263 RID: 611
	public class OwnCountyCapitalPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B0B RID: 6923 RVA: 0x0001AFD1 File Offset: 0x000191D1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B0C RID: 6924 RVA: 0x0001AFE1 File Offset: 0x000191E1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B0D RID: 6925 RVA: 0x0001AFF1 File Offset: 0x000191F1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B0E RID: 6926 RVA: 0x0001B003 File Offset: 0x00019203
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x0001B010 File Offset: 0x00019210
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x0001B01E File Offset: 0x0001921E
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x0001B02B File Offset: 0x0001922B
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x0001B038 File Offset: 0x00019238
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x001AA314 File Offset: 0x001A8514
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OwnCountyCapitalPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x001AA360 File Offset: 0x001A8560
		public OwnCountyCapitalPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x001AA3F8 File Offset: 0x001A85F8
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(80, 142);
			this.tradeButton.CustomTooltipID = 2441;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradeClick), "OwnCountyCapitalPanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.villageButton.ImageNorm = GFXLibrary.int_world_icon_village;
			this.villageButton.OverBrighten = true;
			this.villageButton.MoveOnClick = true;
			this.villageButton.Position = new Point(29, 112);
			this.villageButton.CustomTooltipID = 2437;
			this.villageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClick), "OwnCountyCapitalPanel2_view_village");
			this.backImage.addControl(this.villageButton);
			this.castleButton.ImageNorm = GFXLibrary.int_world_icon_castle;
			this.castleButton.OverBrighten = true;
			this.castleButton.MoveOnClick = true;
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2438;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OwnCountyCapitalPanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			this.resourcesButton.ImageNorm = GFXLibrary.int_world_icon_resource;
			this.resourcesButton.OverBrighten = true;
			this.resourcesButton.MoveOnClick = true;
			this.resourcesButton.Position = new Point(99, 112);
			this.resourcesButton.CustomTooltipID = 2439;
			this.resourcesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourcesClick), "OwnCountyCapitalPanel2_view_resources");
			this.backImage.addControl(this.resourcesButton);
			this.troopsButton.ImageNorm = GFXLibrary.int_world_icon_troops;
			this.troopsButton.OverBrighten = true;
			this.troopsButton.MoveOnClick = true;
			this.troopsButton.Position = new Point(134, 112);
			this.troopsButton.CustomTooltipID = 2442;
			this.troopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopsClick), "OwnCountyCapitalPanel2_make_troops");
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
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x001AA79C File Offset: 0x001A899C
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
			this.tradeButton.Position = new Point(80, 142 + num);
			this.villageButton.Position = new Point(29, 112 + num + num2);
			this.castleButton.Position = new Point(64, 112 + num + num2);
			this.resourcesButton.Position = new Point(99, 112 + num + num2);
			this.troopsButton.Position = new Point(134, 112 + num + num2);
			this.backGround.invalidate();
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x001AA878 File Offset: 0x001A8A78
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

		// Token: 0x06001B18 RID: 6936 RVA: 0x001AA98C File Offset: 0x001A8B8C
		public void updateOwnVillageText(int selectedVillage)
		{
			this.m_selectedVillage = selectedVillage;
			string villageName = GameEngine.Instance.World.getVillageName(selectedVillage);
			this.backGround.updateHeading(villageName);
			this.backGround.updatePanelTypeFromVillageID(selectedVillage);
			this.backGround.setActionFromVillage(selectedVillage, -1);
			this.updateSize();
			this.update();
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x0001AF29 File Offset: 0x00019129
		private void villageClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(0);
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x0001AF4B File Offset: 0x0001914B
		private void castleClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0001AF6D File Offset: 0x0001916D
		private void resourcesClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1005);
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0001AF8E File Offset: 0x0001918E
		private void troopsClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1004);
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x0001AFAF File Offset: 0x000191AF
		private void tradeClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(3);
		}

		// Token: 0x04002BDE RID: 11230
		private DockableControl dockableControl;

		// Token: 0x04002BDF RID: 11231
		private IContainer components;

		// Token: 0x04002BE0 RID: 11232
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002BE1 RID: 11233
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BE2 RID: 11234
		private CustomSelfDrawPanel.CSDButton villageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BE3 RID: 11235
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BE4 RID: 11236
		private CustomSelfDrawPanel.CSDButton resourcesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BE5 RID: 11237
		private CustomSelfDrawPanel.CSDButton troopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BE6 RID: 11238
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BE7 RID: 11239
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BE8 RID: 11240
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002BE9 RID: 11241
		private int m_selectedVillage = -1;
	}
}
