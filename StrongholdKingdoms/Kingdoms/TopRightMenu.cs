using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200049D RID: 1181
	public class TopRightMenu : CustomSelfDrawPanel
	{
		// Token: 0x06002B32 RID: 11058 RVA: 0x00222418 File Offset: 0x00220618
		public TopRightMenu()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002B33 RID: 11059 RVA: 0x002224C8 File Offset: 0x002206C8
		public void init()
		{
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.menubar_top;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(463, 120);
			base.addControl(this.mainBackgroundImage);
			this.btnVillageLeft.ImageNorm = GFXLibrary.villagename_button_left_normal;
			this.btnVillageLeft.ImageOver = GFXLibrary.villagename_button_left_highlight;
			this.btnVillageLeft.ImageClick = GFXLibrary.villagename_button_left_selected;
			this.btnVillageLeft.Position = new Point(5, 29);
			this.btnVillageLeft.CustomTooltipID = 20;
			this.btnVillageLeft.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnVillageLeft_Click));
			this.mainBackgroundImage.addControl(this.btnVillageLeft);
			this.btnVillagesRight.ImageNorm = GFXLibrary.villagename_button_right_normal;
			this.btnVillagesRight.ImageOver = GFXLibrary.villagename_button_right_highlight;
			this.btnVillagesRight.ImageClick = GFXLibrary.villagename_button_right_selected;
			this.btnVillagesRight.Position = new Point(24, 29);
			this.btnVillagesRight.CustomTooltipID = 20;
			this.btnVillagesRight.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.btnVillagesRight_Click));
			this.mainBackgroundImage.addControl(this.btnVillagesRight);
			this.villageButton.Image = GFXLibrary.villagename_body;
			this.villageButton.Position = new Point(49, 29);
			this.mainBackgroundImage.addControl(this.villageButton);
			this.lblVillageName.Position = new Point(20, -1);
			this.lblVillageName.Size = new Size(this.villageButton.Size.Width - 35, this.villageButton.Height);
			this.lblVillageName.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblVillageName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.lblVillageName.Color = global::ARGBColors.Black;
			this.lblVillageName.CustomTooltipID = 21;
			this.lblVillageName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillageName_Click));
			this.villageButton.addControl(this.lblVillageName);
			this.mainTabBar1.Position = new Point(3, 51);
			this.mainTabBar1.Size = new Size(460, 40);
			this.mainBackgroundImage.addControl(this.mainTabBar1);
			this.villageTabBar1.Position = new Point(3, 88);
			this.villageTabBar1.Size = new Size(460, 40);
			this.mainBackgroundImage.addControl(this.villageTabBar1);
			this.factionTabBar1.Position = new Point(3, 88);
			this.factionTabBar1.Size = new Size(460, 40);
			this.factionTabBar1.Visible = false;
			this.mainBackgroundImage.addControl(this.factionTabBar1);
			this.mainMenuBar.Position = new Point(0, 0);
			this.mainMenuBar.Size = new Size(base.Width, 25);
			this.mainBackgroundImage.addControl(this.mainMenuBar);
			this.mainTabBar1.init();
			this.villageTabBar1.init();
			this.factionTabBar1.init();
			this.mainMenuBar.init2();
			this.resize();
		}

		// Token: 0x06002B34 RID: 11060 RVA: 0x0001FB68 File Offset: 0x0001DD68
		public MainTabBar2 getMainTabBar()
		{
			return this.mainTabBar1;
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x0001FB70 File Offset: 0x0001DD70
		public VillageTabBar2 getVillageTabBar()
		{
			return this.villageTabBar1;
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x0001FB78 File Offset: 0x0001DD78
		public FactionTabBar2 getFactionTabBar()
		{
			return this.factionTabBar1;
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x0001FB80 File Offset: 0x0001DD80
		private void btnWorldClick()
		{
			GFXLibrary.Instance.changeView(GFXLibrary.getPanelDescFromID(201));
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06002B38 RID: 11064 RVA: 0x0001FBA6 File Offset: 0x0001DDA6
		public void setSelectedVillageName(string villageName, bool asCapital)
		{
			this.lblVillageName.Text = villageName;
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x0001FBB4 File Offset: 0x0001DDB4
		private void btnVillageClick()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_left");
			InterfaceMgr.Instance.centerOnVillage();
		}

		// Token: 0x06002B3A RID: 11066 RVA: 0x0001FBCF File Offset: 0x0001DDCF
		private void btnVillageLeft_Click()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_left");
			InterfaceMgr.Instance.selectedVillageNameLeft();
		}

		// Token: 0x06002B3B RID: 11067 RVA: 0x0001FBEA File Offset: 0x0001DDEA
		private void btnVillagesRight_Click()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_right");
			InterfaceMgr.Instance.selectedVillageNameRight();
		}

		// Token: 0x06002B3C RID: 11068 RVA: 0x00222848 File Offset: 0x00220A48
		private void lblVillageName_Click()
		{
			if ((this.villageListMenu != null && this.villageListMenu.Visible) || InterfaceMgr.Instance.menuPopupClosedRecently())
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_droplist_close");
				InterfaceMgr.Instance.closeMenuPopup();
				return;
			}
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_droplist_open");
			this.villageListMenu = new MenuPopup();
			this.villageListMenu.setCallBack(new MenuPopup.MenuCallback(this.comboVillageList_SelectionChangeCommitted));
			this.villageListMenu.setDoubleClickCallBack(new MenuPopup.MenuCallback(this.doubleClickedItem));
			this.villageListMenu.setLineHeight(15);
			this.villageListMenu.closeOnClickOnly();
			this.villageListMenu.mouseOverDelegates(new MenuPopup.MenuItemRolloverDelegate(this.mouseOverItem), new MenuPopup.MenuItemRolloverDelegate(this.mouseLeaveItem));
			this.villageListMenu.setBackColour(Color.FromArgb(255, 186, 175, 163));
			Point point = base.PointToScreen(this.villageButton.Position);
			this.villageListMenu.setPosition(point.X + 18, point.Y + 21);
			List<WorldMap.VillageNameItem> userVillageNamesListAndCapitals = GameEngine.Instance.World.getUserVillageNamesListAndCapitals();
			int num = 0;
			foreach (WorldMap.VillageNameItem villageNameItem in userVillageNamesListAndCapitals)
			{
				if (villageNameItem.capital)
				{
					break;
				}
				if (villageNameItem.villageID < 0)
				{
					break;
				}
				num++;
			}
			if (num >= 3)
			{
				CustomSelfDrawPanel.CSDControl csdcontrol = this.villageListMenu.addMenuItem(SK.Text("Menu_Your_Villages", "Your Villages") + " (" + num.ToString() + ")", -1);
				csdcontrol.Enabled = false;
			}
			else
			{
				CustomSelfDrawPanel.CSDControl csdcontrol2 = this.villageListMenu.addMenuItem(SK.Text("Menu_Your_Villages", "Your Villages"), -1);
				csdcontrol2.Enabled = false;
			}
			this.villageListMenu.addBar();
			bool flag = false;
			foreach (WorldMap.VillageNameItem villageNameItem2 in userVillageNamesListAndCapitals)
			{
				if (villageNameItem2.villageID < 0)
				{
					this.villageListMenu.newColumn();
					flag = true;
				}
				bool bold = false;
				if (flag && GameEngine.Instance.World.isUserVillage(villageNameItem2.villageID))
				{
					bold = true;
				}
				CustomSelfDrawPanel.CSDControl csdcontrol3 = this.villageListMenu.addMenuItem(villageNameItem2.villageName, villageNameItem2.villageID, bold);
				if (villageNameItem2.villageID < 0)
				{
					csdcontrol3.Enabled = false;
					this.villageListMenu.addBar();
				}
			}
			this.villageListMenu.showMenu();
			MainWindow.captureCloseMenuEvent = true;
		}

		// Token: 0x06002B3D RID: 11069 RVA: 0x00222B00 File Offset: 0x00220D00
		private void mouseOverItem(int id)
		{
			this.villageListMenu.clearHighlights();
			if (id >= 0)
			{
				List<WorldMap.VillageNameItem> userVillageNamesListAndCapitals = GameEngine.Instance.World.getUserVillageNamesListAndCapitals();
				if (GameEngine.Instance.World.isRegionCapital(id))
				{
					int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(id);
					this.highlightRegionsVillages(parishFromVillageID, userVillageNamesListAndCapitals);
					int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(id);
					int countyCapitalVillage = GameEngine.Instance.World.getCountyCapitalVillage(countyFromVillageID);
					this.villageListMenu.highlightByID(countyCapitalVillage, this.highlightColour);
					int provinceFromVillageID = GameEngine.Instance.World.getProvinceFromVillageID(id);
					int provinceCapital = GameEngine.Instance.World.getProvinceCapital(provinceFromVillageID);
					this.villageListMenu.highlightByID(provinceCapital, this.highlightColour);
					int countryFromVillageID = GameEngine.Instance.World.getCountryFromVillageID(id);
					int countryCapital = GameEngine.Instance.World.getCountryCapital(countryFromVillageID);
					this.villageListMenu.highlightByID(countryCapital, this.highlightColour);
					return;
				}
				if (GameEngine.Instance.World.isCountyCapital(id))
				{
					int countyFromVillageID2 = GameEngine.Instance.World.getCountyFromVillageID(id);
					this.highlightCountiesVillages(countyFromVillageID2, userVillageNamesListAndCapitals);
					int provinceFromVillageID2 = GameEngine.Instance.World.getProvinceFromVillageID(id);
					int provinceCapital2 = GameEngine.Instance.World.getProvinceCapital(provinceFromVillageID2);
					this.villageListMenu.highlightByID(provinceCapital2, this.highlightColour);
					int countryFromVillageID2 = GameEngine.Instance.World.getCountryFromVillageID(id);
					int countryCapital2 = GameEngine.Instance.World.getCountryCapital(countryFromVillageID2);
					this.villageListMenu.highlightByID(countryCapital2, this.highlightColour);
					return;
				}
				if (GameEngine.Instance.World.isProvinceCapital(id))
				{
					int provinceFromVillageID3 = GameEngine.Instance.World.getProvinceFromVillageID(id);
					this.highlightProvincesVillages(provinceFromVillageID3, userVillageNamesListAndCapitals);
					int countryFromVillageID3 = GameEngine.Instance.World.getCountryFromVillageID(id);
					int countryCapital3 = GameEngine.Instance.World.getCountryCapital(countryFromVillageID3);
					this.villageListMenu.highlightByID(countryCapital3, this.highlightColour);
					return;
				}
				if (GameEngine.Instance.World.isCountryCapital(id))
				{
					int countryFromVillageID4 = GameEngine.Instance.World.getCountryFromVillageID(id);
					this.highlightCountriesVillages(countryFromVillageID4, userVillageNamesListAndCapitals);
					return;
				}
				int parishFromVillageID2 = GameEngine.Instance.World.getParishFromVillageID(id);
				int parishCapital = GameEngine.Instance.World.getParishCapital(parishFromVillageID2);
				this.villageListMenu.highlightByID(parishCapital, this.highlightColour);
				int countyFromVillageID3 = GameEngine.Instance.World.getCountyFromVillageID(id);
				int countyCapitalVillage2 = GameEngine.Instance.World.getCountyCapitalVillage(countyFromVillageID3);
				this.villageListMenu.highlightByID(countyCapitalVillage2, this.highlightColour);
				int provinceFromVillageID4 = GameEngine.Instance.World.getProvinceFromVillageID(id);
				int provinceCapital3 = GameEngine.Instance.World.getProvinceCapital(provinceFromVillageID4);
				this.villageListMenu.highlightByID(provinceCapital3, this.highlightColour);
				int countryFromVillageID5 = GameEngine.Instance.World.getCountryFromVillageID(id);
				int countryCapital4 = GameEngine.Instance.World.getCountryCapital(countryFromVillageID5);
				this.villageListMenu.highlightByID(countryCapital4, this.highlightColour);
			}
		}

		// Token: 0x06002B3E RID: 11070 RVA: 0x00222E18 File Offset: 0x00221018
		private void highlightRegionsVillages(int testRegionID, List<WorldMap.VillageNameItem> namesList)
		{
			foreach (WorldMap.VillageNameItem villageNameItem in namesList)
			{
				if (villageNameItem.villageID >= 0 && !villageNameItem.capital)
				{
					int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(villageNameItem.villageID);
					if (parishFromVillageID == testRegionID)
					{
						this.villageListMenu.highlightByID(villageNameItem.villageID, this.highlightColour);
					}
				}
			}
		}

		// Token: 0x06002B3F RID: 11071 RVA: 0x00222EA4 File Offset: 0x002210A4
		private void highlightCountiesVillages(int testCountyID, List<WorldMap.VillageNameItem> namesList)
		{
			foreach (WorldMap.VillageNameItem villageNameItem in namesList)
			{
				if (villageNameItem.villageID >= 0 && (GameEngine.Instance.World.isRegionCapital(villageNameItem.villageID) || !villageNameItem.capital))
				{
					int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(villageNameItem.villageID);
					if (countyFromVillageID == testCountyID)
					{
						this.villageListMenu.highlightByID(villageNameItem.villageID, this.highlightColour);
					}
				}
			}
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x00222F44 File Offset: 0x00221144
		private void highlightProvincesVillages(int testProvinceID, List<WorldMap.VillageNameItem> namesList)
		{
			foreach (WorldMap.VillageNameItem villageNameItem in namesList)
			{
				if (villageNameItem.villageID >= 0 && (GameEngine.Instance.World.isRegionCapital(villageNameItem.villageID) || GameEngine.Instance.World.isCountyCapital(villageNameItem.villageID) || !villageNameItem.capital))
				{
					int provinceFromVillageID = GameEngine.Instance.World.getProvinceFromVillageID(villageNameItem.villageID);
					if (provinceFromVillageID == testProvinceID)
					{
						this.villageListMenu.highlightByID(villageNameItem.villageID, this.highlightColour);
					}
				}
			}
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x00223000 File Offset: 0x00221200
		private void highlightCountriesVillages(int testCountryID, List<WorldMap.VillageNameItem> namesList)
		{
			foreach (WorldMap.VillageNameItem villageNameItem in namesList)
			{
				if (villageNameItem.villageID >= 0 && (GameEngine.Instance.World.isRegionCapital(villageNameItem.villageID) || GameEngine.Instance.World.isCountyCapital(villageNameItem.villageID) || GameEngine.Instance.World.isProvinceCapital(villageNameItem.villageID) || !villageNameItem.capital))
				{
					int countryFromVillageID = GameEngine.Instance.World.getCountryFromVillageID(villageNameItem.villageID);
					if (countryFromVillageID == testCountryID)
					{
						this.villageListMenu.highlightByID(villageNameItem.villageID, this.highlightColour);
					}
				}
			}
		}

		// Token: 0x06002B42 RID: 11074 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void mouseLeaveItem(int id)
		{
		}

		// Token: 0x06002B43 RID: 11075 RVA: 0x0001FC05 File Offset: 0x0001DE05
		private void comboVillageList_SelectionChangeCommitted(int id)
		{
			if (id >= 0)
			{
				GameEngine.Instance.playInterfaceSound("WorldMapScreen_village_droplist_selected");
				InterfaceMgr.Instance.selectUserVillage(id, true);
			}
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x0001FC26 File Offset: 0x0001DE26
		private void doubleClickedItem(int id)
		{
			if (id >= 0)
			{
				if (!GameEngine.Instance.World.isCapital(id))
				{
					InterfaceMgr.Instance.getMainTabBar().changeTab(1);
					return;
				}
				InterfaceMgr.Instance.getMainTabBar().changeTab(2);
			}
		}

		// Token: 0x06002B45 RID: 11077 RVA: 0x0001FC5F File Offset: 0x0001DE5F
		public void showVillageTab(bool state)
		{
			if (state)
			{
				base.Invalidate();
			}
			this.villageTabBar1.Visible = state;
			if (state)
			{
				base.Invalidate();
			}
		}

		// Token: 0x06002B46 RID: 11078 RVA: 0x0001FC7F File Offset: 0x0001DE7F
		public void showFactionTabBar(bool state)
		{
			this.factionTabBar1.Visible = state;
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x002230D4 File Offset: 0x002212D4
		public void resize()
		{
			this.mainBackgroundImage.Size = new Size(base.Width, 120);
			this.btnVillageLeft.Position = new Point(-458 + base.Width, this.btnVillageLeft.Position.Y);
			this.btnVillagesRight.Position = new Point(-439 + base.Width, this.btnVillagesRight.Position.Y);
			this.villageButton.Position = new Point(-414 + base.Width, this.villageButton.Position.Y);
			this.factionTabBar1.Position = new Point(-460 + base.Width, this.factionTabBar1.Position.Y);
			this.mainTabBar1.Position = new Point(-460 + base.Width, this.mainTabBar1.Position.Y);
			this.villageTabBar1.Position = new Point(-460 + base.Width, this.villageTabBar1.Position.Y);
			this.factionTabBar1.Position = new Point(-460 + base.Width, this.factionTabBar1.Position.Y);
			this.mainMenuBar.Size = new Size(base.Width, 25);
			this.mainMenuBar.resize();
			base.Invalidate();
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x0001FC8D File Offset: 0x0001DE8D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x0022326C File Offset: 0x0022146C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			this.MinimumSize = new Size(463, 0);
			base.Name = "TopRightMenu";
			base.Size = new Size(463, 120);
			base.ResumeLayout(false);
		}

		// Token: 0x040035EC RID: 13804
		private CustomSelfDrawPanel.CSDButton worldmapButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035ED RID: 13805
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035EE RID: 13806
		private CustomSelfDrawPanel.CSDButton btnVillagesRight = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035EF RID: 13807
		private CustomSelfDrawPanel.CSDButton btnVillageLeft = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040035F0 RID: 13808
		private CustomSelfDrawPanel.CSDImage villageButton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035F1 RID: 13809
		private CustomSelfDrawPanel.CSDLabel lblVillageName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040035F2 RID: 13810
		private MainTabBar2 mainTabBar1 = new MainTabBar2();

		// Token: 0x040035F3 RID: 13811
		private VillageTabBar2 villageTabBar1 = new VillageTabBar2();

		// Token: 0x040035F4 RID: 13812
		private FactionTabBar2 factionTabBar1 = new FactionTabBar2();

		// Token: 0x040035F5 RID: 13813
		public MainMenuBar2 mainMenuBar = new MainMenuBar2();

		// Token: 0x040035F6 RID: 13814
		private MenuPopup villageListMenu;

		// Token: 0x040035F7 RID: 13815
		private Color highlightColour = Color.FromArgb(232, 230, 228);

		// Token: 0x040035F8 RID: 13816
		private IContainer components;
	}
}
