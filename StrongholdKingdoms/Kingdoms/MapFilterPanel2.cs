using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000237 RID: 567
	public class MapFilterPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060018F4 RID: 6388 RVA: 0x00019769 File Offset: 0x00017969
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x00019779 File Offset: 0x00017979
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x00019789 File Offset: 0x00017989
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x0001979B File Offset: 0x0001799B
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x000197A8 File Offset: 0x000179A8
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x000197B6 File Offset: 0x000179B6
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x000197C3 File Offset: 0x000179C3
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x000197D0 File Offset: 0x000179D0
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x0018C078 File Offset: 0x0018A278
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "MapFilterPanel2";
			base.Size = new Size(199, 273);
			base.ResumeLayout(false);
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x0018C0C4 File Offset: 0x0018A2C4
		public MapFilterPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x0018C1AC File Offset: 0x0018A3AC
		public void init()
		{
			base.clearControls();
			this.backImage = this.backGround.init(true, 1506);
			this.backGround.updateHeading(SK.Text("MapFilterSelectPanel_Map_Filtering", "Map Filtering"));
			base.addControl(this.backGround);
			this.backGround.Size = new Size(200, 800);
			this.backImage.Size = new Size(200, 800);
			base.Size = new Size(200, 800);
			this.selectedImage.Image = GFXLibrary.mrhp_world_icons_filter_selected;
			this.selectedImage.Position = new Point(6, 45);
			this.selectedImage.Visible = false;
			this.backImage.addControl(this.selectedImage);
			CustomSelfDrawPanel.CSDButton vassalsButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.VASSAL);
			vassalsButton.Position = new Point(10, 42);
			vassalsButton.CustomTooltipID = 2446;
			vassalsButton.setClickDelegate(delegate()
			{
				GameEngine.Instance.World.worldMapFilter.setFilterMode(12);
				this.selectedImage.Position = vassalsButton.Position;
				this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
				this.selectedImage.Visible = true;
				this.backImage.invalidate();
			}, "OtherVillagePanel2_make_vassal");
			this.backImage.addControl(vassalsButton);
			CustomSelfDrawPanel.CSDButton monkButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.MONK);
			monkButton.Position = new Point(10, 76);
			monkButton.CustomTooltipID = 2414;
			monkButton.setClickDelegate(delegate()
			{
				GameEngine.Instance.World.worldMapFilter.setFilterMode(90001);
				this.selectedImage.Position = monkButton.Position;
				this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
				this.selectedImage.Visible = true;
				this.backImage.invalidate();
			}, "OtherVillagePanel2_sendmonks");
			this.backImage.addControl(monkButton);
			CustomSelfDrawPanel.CSDButton paladinButton = new CustomSelfDrawPanel.CSDButton
			{
				ImageNorm = GFXLibrary.wl_moving_unit_icons[25],
				ImageOver = GFXLibrary.wl_moving_unit_icons[25],
				ImageClick = GFXLibrary.wl_moving_unit_icons[25],
				Position = new Point(150, 42),
				CustomTooltipID = 2448
			};
			paladinButton.setClickDelegate(delegate()
			{
				GameEngine.Instance.World.worldMapFilter.setFilterMode(90002);
				this.selectedImage.Position = paladinButton.Position;
				this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
				this.selectedImage.Visible = true;
				this.backImage.invalidate();
			}, "OtherVillagePanel2_attack");
			this.backImage.addControl(paladinButton);
			int i = 1;
			int num = 251;
			while (i <= 20)
			{
				Point position = new Point(47, num);
				if (i % 2 == 0)
				{
					position.X += 60;
					position.Y -= 15;
				}
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton
				{
					ImageNorm = GFXLibrary.house_circles_medium[i - 1],
					ImageOver = GFXLibrary.house_circles_medium[i - 1 + 20],
					Position = position,
					MoveOnClick = true,
					CustomTooltipID = 2307,
					CustomTooltipData = i,
					Data = i,
					Active = true
				};
				CustomSelfDrawPanel.CSDControl csdcontrol = csdbutton;
				CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate clickDelegate = delegate()
				{
					GameEngine.Instance.playInterfaceSound("FactionPanelSideBar_house");
					int data = this.ClickedControl.Data;
					GameEngine.Instance.World.worldMapFilter.setFilterMode(1000 + data);
					this.selectedImage.Position = this.ClickedControl.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					this.backImage.invalidate();
				};
				csdcontrol.setClickDelegate(clickDelegate);
				this.backImage.addControl(csdbutton);
				i++;
				num += 25;
			}
			this.tradeButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.TRADE);
			this.tradeButton.Position = new Point(115, 42);
			this.tradeButton.CustomTooltipID = 2454;
			this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradeClick), "MapFilterPanel2_trade");
			this.backImage.addControl(this.tradeButton);
			this.attackButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.ATTACK);
			this.attackButton.Position = new Point(80, 76);
			this.attackButton.CustomTooltipID = 2455;
			this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.attackClick), "MapFilterPanel2_attack");
			this.backImage.addControl(this.attackButton);
			this.scoutButton = MainRightHandPanel.getMRHPButton(MainRightHandPanel.MRHPButton.SCOUT);
			this.scoutButton.Position = new Point(45, 76);
			this.scoutButton.CustomTooltipID = 2456;
			this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scoutsClick), "MapFilterPanel2_scout");
			this.backImage.addControl(this.scoutButton);
			this.houseButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[6];
			this.houseButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[13];
			this.houseButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[20];
			this.houseButton.Position = new Point(45, 42);
			this.houseButton.CustomTooltipID = 2457;
			this.houseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.houseClick), "MapFilterPanel2_house");
			this.backImage.addControl(this.houseButton);
			this.factionButton.ImageNorm = GFXLibrary.mrhp_world_icons_rhs_array[36];
			this.factionButton.ImageOver = GFXLibrary.mrhp_world_icons_rhs_array[37];
			this.factionButton.ImageClick = GFXLibrary.mrhp_world_icons_rhs_array[38];
			this.factionButton.Position = new Point(80, 42);
			if (RemoteServices.Instance.UserFactionID >= 0)
			{
				this.factionButton.CustomTooltipID = 2458;
			}
			else
			{
				this.factionButton.CustomTooltipID = 2461;
			}
			this.factionButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick), "MapFilterPanel2_faction");
			this.backImage.addControl(this.factionButton);
			this.aiButton.ImageNorm = GFXLibrary.mrhp_button_filter_ai[0];
			this.aiButton.ImageOver = GFXLibrary.mrhp_button_filter_ai[1];
			this.aiButton.ImageClick = GFXLibrary.mrhp_button_filter_ai[2];
			this.aiButton.Position = new Point(115, 76);
			this.aiButton.CustomTooltipID = 2462;
			this.aiButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aiClick), "MapFilterPanel2_ai");
			this.backImage.addControl(this.aiButton);
			this.yourVillages.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.yourVillages.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.yourVillages.Position = new Point(15, 117);
			this.yourVillages.Checked = GameEngine.Instance.World.worldMapFilter.FilterAlwaysShowYourVillages;
			this.yourVillages.CBLabel.Text = SK.Text("MapFilterPanel_Always_Show_Your_Villages", "Always Show Your Villages");
			this.yourVillages.CBLabel.Color = global::ARGBColors.Black;
			this.yourVillages.CBLabel.Position = new Point(20, -1);
			this.yourVillages.CBLabel.Size = new Size(180, 25);
			this.yourVillages.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.yourVillages.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.yourToggled));
			this.backImage.addControl(this.yourVillages);
			this.diplomacyLabel.Text = SK.Text("MapFilterPanel_Diplomacy", "Diplomacy Symbols");
			this.diplomacyLabel.Position = new Point(5, 137);
			this.diplomacyLabel.Color = global::ARGBColors.Black;
			this.diplomacyLabel.Size = new Size(180, 25);
			this.diplomacyLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.diplomacyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.backImage.addControl(this.diplomacyLabel);
			this.houseSymbols.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.houseSymbols.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.houseSymbols.Position = new Point(15, 157);
			this.houseSymbols.Checked = GameEngine.Instance.World.worldMapFilter.FilterShowHouseSymbols;
			this.houseSymbols.CBLabel.Text = SK.Text("MapFilterPanel_Show_House_Symbols", "Show House Symbols");
			this.houseSymbols.CBLabel.Color = global::ARGBColors.Black;
			this.houseSymbols.CBLabel.Position = new Point(20, -1);
			this.houseSymbols.CBLabel.Size = new Size(180, 25);
			this.houseSymbols.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.houseSymbols.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.houseToggled));
			this.backImage.addControl(this.houseSymbols);
			this.factionSymbols.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.factionSymbols.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.factionSymbols.Position = new Point(15, 177);
			this.factionSymbols.Checked = GameEngine.Instance.World.worldMapFilter.FilterShowFactionSymbols;
			this.factionSymbols.CBLabel.Text = SK.Text("MapFilterPanel_Show_Faction_Symbols", "Show Faction Symbols");
			this.factionSymbols.CBLabel.Color = global::ARGBColors.Black;
			this.factionSymbols.CBLabel.Position = new Point(20, -1);
			this.factionSymbols.CBLabel.Size = new Size(180, 25);
			this.factionSymbols.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.factionSymbols.Data = 0;
			this.factionSymbols.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.factionToggled));
			this.backImage.addControl(this.factionSymbols);
			this.userSymbols.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.userSymbols.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.userSymbols.Position = new Point(15, 197);
			this.userSymbols.Checked = GameEngine.Instance.World.worldMapFilter.FilterShowUserSymbols;
			this.userSymbols.CBLabel.Text = SK.Text("MapFilterPanel_Show_User_Symbols", "Show Player Symbols");
			this.userSymbols.CBLabel.Color = global::ARGBColors.Black;
			this.userSymbols.CBLabel.Position = new Point(20, -1);
			this.userSymbols.CBLabel.Size = new Size(180, 25);
			this.userSymbols.CBLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.userSymbols.Data = 0;
			this.userSymbols.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.userToggled));
			this.backImage.addControl(this.userSymbols);
			this.searchButton.ImageNorm = GFXLibrary.mrhp_button_filter_search[0];
			this.searchButton.ImageOver = GFXLibrary.mrhp_button_filter_search[1];
			this.searchButton.ImageClick = GFXLibrary.mrhp_button_filter_search[2];
			this.searchButton.Position = new Point(103, 215);
			this.searchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchFilter), "StatsPanel_search");
			this.searchButton.CustomTooltipID = 2460;
			this.backImage.addControl(this.searchButton);
			this.clearButton.ImageNorm = GFXLibrary.mrhp_button_filter_off[0];
			this.clearButton.ImageOver = GFXLibrary.mrhp_button_filter_off[1];
			this.clearButton.ImageClick = GFXLibrary.mrhp_button_filter_off[2];
			this.clearButton.Position = new Point(19, 215);
			this.clearButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clearFilter), "MapFilterPanel2_clear");
			this.clearButton.CustomTooltipID = 2459;
			this.backImage.addControl(this.clearButton);
			this.cancelButton.ImageNorm = GFXLibrary.mrhp_button_80_normal;
			this.cancelButton.ImageOver = GFXLibrary.mrhp_button_80_over;
			this.cancelButton.ImageClick = GFXLibrary.mrhp_button_80_pushed;
			this.cancelButton.Position = new Point(103, 215);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.cancelButton.Text.Size = new Size(this.cancelButton.ImageNorm.Size.Width - 6, this.cancelButton.ImageNorm.Size.Height);
			this.cancelButton.TextYOffset = -3;
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MapFilterPanel2_close");
			this.backImage.invalidate();
			InterfaceMgr.Instance.closeArmySelectedPanel();
			InterfaceMgr.Instance.closeTraderInfoPanel();
			InterfaceMgr.Instance.closeReinforcementSelectedPanel();
			InterfaceMgr.Instance.closePersonInfoPanel();
			InterfaceMgr.Instance.closeSelectedVillagePanel();
			int filterMode = GameEngine.Instance.World.worldMapFilter.FilterMode;
			if (GameEngine.Instance.World.worldMapFilter.FilterActive)
			{
				switch (filterMode)
				{
				case 0:
					break;
				case 1:
				case 7:
					this.selectedImage.Position = this.factionButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 2:
					this.selectedImage.Position = this.houseButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 3:
					this.selectedImage.Position = this.scoutButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 4:
					this.selectedImage.Position = this.tradeButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 5:
					this.selectedImage.Position = this.tradeButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 6:
					this.selectedImage.Position = this.attackButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					return;
				case 8:
					this.selectedImage.Position = this.aiButton.Position;
					this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
					this.selectedImage.Visible = true;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x000197EF File Offset: 0x000179EF
		public void update()
		{
			this.backGround.update();
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x0018D230 File Offset: 0x0018B430
		private void factionClick()
		{
			if (RemoteServices.Instance.UserFactionID >= 0)
			{
				GameEngine.Instance.World.worldMapFilter.setFilterMode(1);
			}
			else
			{
				GameEngine.Instance.World.worldMapFilter.setFilterMode(7);
			}
			this.selectedImage.Position = this.factionButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x0018D2E0 File Offset: 0x0018B4E0
		private void houseClick()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(2);
			this.selectedImage.Position = this.houseButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x0018D36C File Offset: 0x0018B56C
		private void tradeClick()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(4);
			this.selectedImage.Position = this.tradeButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001903 RID: 6403 RVA: 0x0018D3F8 File Offset: 0x0018B5F8
		private void scoutsClick()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(3);
			this.selectedImage.Position = this.scoutButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001904 RID: 6404 RVA: 0x0018D484 File Offset: 0x0018B684
		private void attackClick()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(6);
			this.selectedImage.Position = this.attackButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001905 RID: 6405 RVA: 0x0018D510 File Offset: 0x0018B710
		private void aiClick()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(8);
			this.selectedImage.Position = this.aiButton.Position;
			this.selectedImage.Position = new Point(this.selectedImage.Position.X - 5, this.selectedImage.Position.Y - 5);
			this.selectedImage.Visible = true;
			this.backImage.invalidate();
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x000197FC File Offset: 0x000179FC
		private void yourToggled()
		{
			GameEngine.Instance.World.worldMapFilter.FilterAlwaysShowYourVillages = this.yourVillages.Checked;
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x0001981D File Offset: 0x00017A1D
		private void houseToggled()
		{
			GameEngine.Instance.World.worldMapFilter.FilterShowHouseSymbols = this.houseSymbols.Checked;
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x0001983E File Offset: 0x00017A3E
		private void factionToggled()
		{
			GameEngine.Instance.World.worldMapFilter.FilterShowFactionSymbols = this.factionSymbols.Checked;
		}

		// Token: 0x06001909 RID: 6409 RVA: 0x0001985F File Offset: 0x00017A5F
		private void userToggled()
		{
			GameEngine.Instance.World.worldMapFilter.FilterShowUserSymbols = this.userSymbols.Checked;
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00019880 File Offset: 0x00017A80
		private void clearFilter()
		{
			GameEngine.Instance.World.worldMapFilter.setFilterMode(0);
			this.selectedImage.Visible = false;
			this.backImage.invalidate();
		}

		// Token: 0x0600190B RID: 6411 RVA: 0x000198AE File Offset: 0x00017AAE
		private void closeClick()
		{
			InterfaceMgr.Instance.clearControls();
			InterfaceMgr.Instance.showMapFilterSelectPanel(true, true);
			InterfaceMgr.Instance.selectCurrentUserVillage();
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x0018D59C File Offset: 0x0018B79C
		private void searchFilter()
		{
			SearchForVillagePopup searchForVillagePopup = new SearchForVillagePopup();
			searchForVillagePopup.ShowDialog(InterfaceMgr.Instance.ParentForm);
			searchForVillagePopup.Dispose();
		}

		// Token: 0x04002969 RID: 10601
		private DockableControl dockableControl;

		// Token: 0x0400296A RID: 10602
		private IContainer components;

		// Token: 0x0400296B RID: 10603
		private CustomSelfDrawPanel.MRHP_Background backGround = new CustomSelfDrawPanel.MRHP_Background();

		// Token: 0x0400296C RID: 10604
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400296D RID: 10605
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400296E RID: 10606
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400296F RID: 10607
		private CustomSelfDrawPanel.CSDButton houseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002970 RID: 10608
		private CustomSelfDrawPanel.CSDButton factionButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002971 RID: 10609
		private CustomSelfDrawPanel.CSDButton aiButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002972 RID: 10610
		private CustomSelfDrawPanel.CSDImage selectedImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002973 RID: 10611
		private CustomSelfDrawPanel.CSDCheckBox yourVillages = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002974 RID: 10612
		private CustomSelfDrawPanel.CSDLabel diplomacyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002975 RID: 10613
		private CustomSelfDrawPanel.CSDCheckBox houseSymbols = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002976 RID: 10614
		private CustomSelfDrawPanel.CSDCheckBox factionSymbols = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002977 RID: 10615
		private CustomSelfDrawPanel.CSDCheckBox userSymbols = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002978 RID: 10616
		private CustomSelfDrawPanel.CSDButton clearButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002979 RID: 10617
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400297A RID: 10618
		private CustomSelfDrawPanel.CSDButton searchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400297B RID: 10619
		private CustomSelfDrawPanel.CSDImage backImage;
	}
}
