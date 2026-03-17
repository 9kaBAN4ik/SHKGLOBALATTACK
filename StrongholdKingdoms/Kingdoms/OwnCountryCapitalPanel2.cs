using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000262 RID: 610
	public class OwnCountryCapitalPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001AF8 RID: 6904 RVA: 0x0001AEA3 File Offset: 0x000190A3
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001AF9 RID: 6905 RVA: 0x0001AEB3 File Offset: 0x000190B3
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001AFA RID: 6906 RVA: 0x0001AEC3 File Offset: 0x000190C3
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001AFB RID: 6907 RVA: 0x0001AED5 File Offset: 0x000190D5
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001AFC RID: 6908 RVA: 0x0001AEE2 File Offset: 0x000190E2
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001AFD RID: 6909 RVA: 0x0001AEF0 File Offset: 0x000190F0
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001AFE RID: 6910 RVA: 0x0001AEFD File Offset: 0x000190FD
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001AFF RID: 6911 RVA: 0x0001AF0A File Offset: 0x0001910A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x001A9C44 File Offset: 0x001A7E44
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OwnCountryCapitalPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B01 RID: 6913 RVA: 0x001A9C90 File Offset: 0x001A7E90
		public OwnCountryCapitalPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B02 RID: 6914 RVA: 0x001A9D28 File Offset: 0x001A7F28
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(80, 142);
			this.tradeButton.CustomTooltipID = 2441;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradeClick), "OwnCountryCapitalPanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.villageButton.ImageNorm = GFXLibrary.int_world_icon_village;
			this.villageButton.OverBrighten = true;
			this.villageButton.MoveOnClick = true;
			this.villageButton.Position = new Point(29, 112);
			this.villageButton.CustomTooltipID = 2437;
			this.villageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClick), "OwnCountryCapitalPanel2_view_village");
			this.backImage.addControl(this.villageButton);
			this.castleButton.ImageNorm = GFXLibrary.int_world_icon_castle;
			this.castleButton.OverBrighten = true;
			this.castleButton.MoveOnClick = true;
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2438;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OwnCountryCapitalPanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			this.resourcesButton.ImageNorm = GFXLibrary.int_world_icon_resource;
			this.resourcesButton.OverBrighten = true;
			this.resourcesButton.MoveOnClick = true;
			this.resourcesButton.Position = new Point(99, 112);
			this.resourcesButton.CustomTooltipID = 2439;
			this.resourcesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourcesClick), "OwnCountryCapitalPanel2_view_resources");
			this.backImage.addControl(this.resourcesButton);
			this.troopsButton.ImageNorm = GFXLibrary.int_world_icon_troops;
			this.troopsButton.OverBrighten = true;
			this.troopsButton.MoveOnClick = true;
			this.troopsButton.Position = new Point(134, 112);
			this.troopsButton.CustomTooltipID = 2442;
			this.troopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopsClick), "OwnCountryCapitalPanel2_make_troops");
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

		// Token: 0x06001B03 RID: 6915 RVA: 0x001AA0CC File Offset: 0x001A82CC
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

		// Token: 0x06001B04 RID: 6916 RVA: 0x001AA1A8 File Offset: 0x001A83A8
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

		// Token: 0x06001B05 RID: 6917 RVA: 0x001AA2BC File Offset: 0x001A84BC
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

		// Token: 0x06001B06 RID: 6918 RVA: 0x0001AF29 File Offset: 0x00019129
		private void villageClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(0);
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x0001AF4B File Offset: 0x0001914B
		private void castleClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B08 RID: 6920 RVA: 0x0001AF6D File Offset: 0x0001916D
		private void resourcesClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1005);
		}

		// Token: 0x06001B09 RID: 6921 RVA: 0x0001AF8E File Offset: 0x0001918E
		private void troopsClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1004);
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x0001AFAF File Offset: 0x000191AF
		private void tradeClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(3);
		}

		// Token: 0x04002BD2 RID: 11218
		private DockableControl dockableControl;

		// Token: 0x04002BD3 RID: 11219
		private IContainer components;

		// Token: 0x04002BD4 RID: 11220
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002BD5 RID: 11221
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BD6 RID: 11222
		private CustomSelfDrawPanel.CSDButton villageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BD7 RID: 11223
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BD8 RID: 11224
		private CustomSelfDrawPanel.CSDButton resourcesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BD9 RID: 11225
		private CustomSelfDrawPanel.CSDButton troopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002BDA RID: 11226
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BDB RID: 11227
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002BDC RID: 11228
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002BDD RID: 11229
		private int m_selectedVillage = -1;
	}
}
