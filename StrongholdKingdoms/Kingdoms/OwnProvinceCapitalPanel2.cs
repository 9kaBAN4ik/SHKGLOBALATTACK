using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000265 RID: 613
	public class OwnProvinceCapitalPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B34 RID: 6964 RVA: 0x0001B129 File Offset: 0x00019329
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x0001B139 File Offset: 0x00019339
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x0001B149 File Offset: 0x00019349
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x0001B15B File Offset: 0x0001935B
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x0001B168 File Offset: 0x00019368
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x0001B176 File Offset: 0x00019376
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x0001B183 File Offset: 0x00019383
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x0001B190 File Offset: 0x00019390
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x001AB6C4 File Offset: 0x001A98C4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "OwnProvinceCapitalPanel2";
			base.Size = new Size(199, 213);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x001AB710 File Offset: 0x001A9910
		public OwnProvinceCapitalPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x001AB7A8 File Offset: 0x001A99A8
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 10000);
			base.addControl(this.backGround);
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(80, 142);
			this.tradeButton.CustomTooltipID = 2441;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradeClick), "OwnProvinceCapitalPanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.villageButton.ImageNorm = GFXLibrary.int_world_icon_village;
			this.villageButton.OverBrighten = true;
			this.villageButton.MoveOnClick = true;
			this.villageButton.Position = new Point(29, 112);
			this.villageButton.CustomTooltipID = 2437;
			this.villageButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClick), "OwnProvinceCapitalPanel2_view_village");
			this.backImage.addControl(this.villageButton);
			this.castleButton.ImageNorm = GFXLibrary.int_world_icon_castle;
			this.castleButton.OverBrighten = true;
			this.castleButton.MoveOnClick = true;
			this.castleButton.Position = new Point(64, 112);
			this.castleButton.CustomTooltipID = 2438;
			this.castleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.castleClick), "OwnProvinceCapitalPanel2_view_castle");
			this.backImage.addControl(this.castleButton);
			this.resourcesButton.ImageNorm = GFXLibrary.int_world_icon_resource;
			this.resourcesButton.OverBrighten = true;
			this.resourcesButton.MoveOnClick = true;
			this.resourcesButton.Position = new Point(99, 112);
			this.resourcesButton.CustomTooltipID = 2439;
			this.resourcesButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourcesClick), "OwnProvinceCapitalPanel2_view_resources");
			this.backImage.addControl(this.resourcesButton);
			this.troopsButton.ImageNorm = GFXLibrary.int_world_icon_troops;
			this.troopsButton.OverBrighten = true;
			this.troopsButton.MoveOnClick = true;
			this.troopsButton.Position = new Point(134, 112);
			this.troopsButton.CustomTooltipID = 2442;
			this.troopsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.troopsClick), "OwnProvinceCapitalPanel2_make_troops");
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

		// Token: 0x06001B3F RID: 6975 RVA: 0x001ABB4C File Offset: 0x001A9D4C
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

		// Token: 0x06001B40 RID: 6976 RVA: 0x001ABC28 File Offset: 0x001A9E28
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

		// Token: 0x06001B41 RID: 6977 RVA: 0x001ABD3C File Offset: 0x001A9F3C
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

		// Token: 0x06001B42 RID: 6978 RVA: 0x0001AF29 File Offset: 0x00019129
		private void villageClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(0);
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x0001AF4B File Offset: 0x0001914B
		private void castleClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(1);
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x0001AF6D File Offset: 0x0001916D
		private void resourcesClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1005);
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x0001AF8E File Offset: 0x0001918E
		private void troopsClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.setVillageTabSubMode(1004);
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x0001AFAF File Offset: 0x000191AF
		private void tradeClick()
		{
			InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			InterfaceMgr.Instance.getVillageTabBar().changeTab(3);
		}

		// Token: 0x04002BFD RID: 11261
		private DockableControl dockableControl;

		// Token: 0x04002BFE RID: 11262
		private IContainer components;

		// Token: 0x04002BFF RID: 11263
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x04002C00 RID: 11264
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C01 RID: 11265
		private CustomSelfDrawPanel.CSDButton villageButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C02 RID: 11266
		private CustomSelfDrawPanel.CSDButton castleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C03 RID: 11267
		private CustomSelfDrawPanel.CSDButton resourcesButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C04 RID: 11268
		private CustomSelfDrawPanel.CSDButton troopsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C05 RID: 11269
		private CustomSelfDrawPanel.CSDLabel lblProtected = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C06 RID: 11270
		private CustomSelfDrawPanel.CSDLabel lblProtectionType = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C07 RID: 11271
		private CustomSelfDrawPanel.CSDImage backImage;

		// Token: 0x04002C08 RID: 11272
		private int m_selectedVillage = -1;
	}
}
