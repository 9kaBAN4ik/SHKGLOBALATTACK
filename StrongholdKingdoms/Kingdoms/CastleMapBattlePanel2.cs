using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000123 RID: 291
	public class CastleMapBattlePanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000A75 RID: 2677 RVA: 0x000D09FC File Offset: 0x000CEBFC
		public CastleMapBattlePanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
			CastleMapBattlePanel2.Instance = this;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0000DE24 File Offset: 0x0000C024
		public void create()
		{
			this.initCastlePlacePanel();
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000D0B04 File Offset: 0x000CED04
		public void initCastlePlacePanel()
		{
			this.backgroundArea.Position = new Point(0, 0);
			this.backgroundArea.Size = base.Size;
			base.addControl(this.backgroundArea);
			this.backPanelImage.Image = GFXLibrary.castlescreen_panelback_A;
			this.backPanelImage.Position = new Point(0, 0);
			this.backgroundArea.addControl(this.backPanelImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(153, 6);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CastleMapBattlePanel2_close");
			this.backgroundArea.addControl(this.closeButton);
			this.attackTypeLabel.Color = global::ARGBColors.Black;
			this.attackTypeLabel.Position = new Point(0, 33);
			this.attackTypeLabel.Size = new Size(this.backPanelImage.Width - 2, 24);
			this.attackTypeLabel.Text = SK.Text("GENERIC_Attack_Type", "Attack Type");
			this.attackTypeLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.attackTypeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.attackTypeLabel);
			this.pillageClockLabel.Color = global::ARGBColors.Black;
			this.pillageClockLabel.Position = new Point(0, 30);
			this.pillageClockLabel.Size = new Size(this.backPanelImage.Width, 80);
			this.pillageClockLabel.Text = "0";
			this.pillageClockLabel.Visible = false;
			this.pillageClockLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.pillageClockLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.pillageClockLabel);
			this.pillageBar.setImages(GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right, GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right);
			this.pillageBar.SetMargin(2, 2, 2, 3);
			this.pillageBar.Number = 0.0;
			this.pillageBar.MaxValue = 1.0;
			this.pillageBar.Visible = false;
			this.pillageBar.Position = new Point(21, 85);
			this.backgroundArea.addControl(this.pillageBar);
			this.pauseButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.pauseButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.pauseButton.Position = new Point(21, 195);
			this.pauseButton.Text.Text = SK.Text("CastleMapBattle_Pause", "Pause");
			this.pauseButton.TextYOffset = 0;
			this.pauseButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.pauseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.togglePauseClick), "CastleMapBattlePanel2_pause");
			this.backPanelImage.addControl(this.pauseButton);
			this.speedButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.speedButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.speedButton.Position = new Point(21, 245);
			this.speedButton.Text.Text = SK.Text("CastleMapBattle_Fast", "Fast");
			this.speedButton.TextYOffset = 0;
			this.speedButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.speedButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleSpeedClick), "CastleMapBattlePanel2_speed");
			this.backPanelImage.addControl(this.speedButton);
			this.heightButton.ImageNorm = GFXLibrary.r_building_miltary_viewmode_normal;
			this.heightButton.ImageOver = GFXLibrary.r_building_miltary_viewmode_over;
			this.heightButton.ImageClick = GFXLibrary.r_building_miltary_viewmode_pushed;
			this.heightButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleHeightClick));
			this.heightButton.Position = new Point(58, 295);
			this.backPanelImage.addControl(this.heightButton);
			this.adminExportAllButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.adminExportAllButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.adminExportAllButton.Position = new Point(21, 195);
			this.adminExportAllButton.Text.Text = "Export";
			this.adminExportAllButton.TextYOffset = 0;
			this.adminExportAllButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.adminExportAllButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exportClick));
			this.adminExportAllButton.Visible = false;
			this.backPanelImage.addControl(this.adminExportAllButton);
			this.viewCastleHeadingLabel.Color = global::ARGBColors.Black;
			this.viewCastleHeadingLabel.Position = new Point(0, 73);
			this.viewCastleHeadingLabel.Size = new Size(this.backPanelImage.Width - 2, 44);
			this.viewCastleHeadingLabel.Text = SK.Text("CastleMapBattle_Castle_Last_Update", "Castle Last Update");
			this.viewCastleHeadingLabel.Visible = false;
			this.viewCastleHeadingLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.viewCastleHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.viewCastleHeadingLabel);
			this.viewCastleLabel.Color = global::ARGBColors.Black;
			this.viewCastleLabel.Position = new Point(0, 108);
			this.viewCastleLabel.Size = new Size(this.backPanelImage.Width - 2, 24);
			this.viewCastleLabel.Text = "...";
			this.viewCastleLabel.Visible = false;
			this.viewCastleLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.viewCastleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.viewCastleLabel);
			this.viewTroopsHeadingLabel.Color = global::ARGBColors.Black;
			this.viewTroopsHeadingLabel.Position = new Point(0, 133);
			this.viewTroopsHeadingLabel.Size = new Size(this.backPanelImage.Width - 2, 44);
			this.viewTroopsHeadingLabel.Text = SK.Text("CastleMapBattle_Troops_Last_Update", "Troops Last Update");
			this.viewTroopsHeadingLabel.Visible = false;
			this.viewTroopsHeadingLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.viewTroopsHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.viewTroopsHeadingLabel);
			this.viewTroopsLabel.Color = global::ARGBColors.Black;
			this.viewTroopsLabel.Position = new Point(0, 168);
			this.viewTroopsLabel.Size = new Size(this.backPanelImage.Width - 2, 24);
			this.viewTroopsLabel.Text = "...";
			this.viewTroopsLabel.Visible = false;
			this.viewTroopsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.viewTroopsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.viewTroopsLabel);
			this.reportHeadingLabel.Color = global::ARGBColors.Black;
			this.reportHeadingLabel.Position = new Point(20, 101);
			this.reportHeadingLabel.Size = new Size(this.backPanelImage.Width - 2 - 40, 34);
			this.reportHeadingLabel.Text = SK.Text("CastleMapBattle_Report_Unavailable", "Report Unavailable To Attacker");
			this.reportHeadingLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.reportHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.reportHeadingLabel);
			this.reportClockLabel.Color = global::ARGBColors.Black;
			this.reportClockLabel.Position = new Point(0, 107);
			this.reportClockLabel.Size = new Size(this.backPanelImage.Width, 80);
			this.reportClockLabel.Text = "0";
			this.reportClockLabel.Visible = false;
			this.reportClockLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.reportClockLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundArea.addControl(this.reportClockLabel);
			this.reportBar.setImages(GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right, GFXLibrary.barracks_fillbar_back, GFXLibrary.barracks_fillbar_fill_left, GFXLibrary.barracks_fillbar_fill_mid, GFXLibrary.barracks_fillbar_fill_right);
			this.reportBar.SetMargin(2, 2, 2, 3);
			this.reportBar.Number = 0.0;
			this.reportBar.MaxValue = 1.0;
			this.reportBar.Visible = false;
			this.reportBar.Position = new Point(21, 160);
			this.backgroundArea.addControl(this.reportBar);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000D14F0 File Offset: 0x000CF6F0
		public void battleMode(bool realBattle, int attackType, bool aiAttack)
		{
			this.m_aiAttack = aiAttack;
			this.m_attackType = attackType;
			CastleMapBattlePanel2.fromReports = true;
			CastleMapBattlePanel2.paused = false;
			CastleMapBattlePanel2.fast = false;
			CastleMapBattlePanel2.high = false;
			this.resultsMode = false;
			this.updateButtons();
			this.speedButton.Visible = realBattle;
			this.pauseButton.Visible = realBattle;
			if (realBattle)
			{
				this.attackTypeLabel.Text = CastlesCommon.getAttackTypeLabel(attackType);
				if (this.attackTypeLabel.Text.Length == 0)
				{
					this.attackTypeLabel.Text = SK.Text("GENERIC_Attacking", "Attacking");
				}
				if (MainMenuBar2.CastleCopyMode)
				{
					this.adminExportAllButton.Visible = true;
					CastleMapBattlePanel2.paused = true;
					this.pauseButton.Text.Text = SK.Text("CastleMapBattle_Resume", "Resume");
					GameEngine.Instance.CastleBattle.pauseBattle();
				}
			}
			else if (attackType >= 0)
			{
				this.attackTypeLabel.Text = GameEngine.Instance.World.getVillageName(attackType);
			}
			else
			{
				switch (attackType)
				{
				case -12:
					this.attackTypeLabel.Text = SK.Text("CommonDataTypes_Royal_Tower", "Royal Tower");
					break;
				case -11:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Treasure_Castle", "Treasure Castle");
					break;
				case -10:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
					break;
				case -9:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Paladin_Castle", "Paladin's Castle");
					break;
				case -8:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Wolfs_Castle", "Wolf's Castle");
					break;
				case -7:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Pigs_Castle", "Pig's Castle");
					break;
				case -6:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Snakes_Castle", "Snake's Castle");
					break;
				case -5:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Rats_Castle", "Rat's Castle");
					break;
				case -4:
					this.attackTypeLabel.Text = SK.Text("GENERIC_An_Empty_Village", "An empty village");
					break;
				case -3:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Wolf_Camp", "Wolf Lair");
					break;
				case -2:
					this.attackTypeLabel.Text = SK.Text("GENERIC_Bandit_Camp", "Bandit Camp");
					break;
				default:
					this.attackTypeLabel.Text = "";
					break;
				}
			}
			this.viewCastleHeadingLabel.Visible = !realBattle;
			this.viewCastleLabel.Visible = !realBattle;
			this.viewTroopsHeadingLabel.Visible = !realBattle;
			this.viewTroopsLabel.Visible = !realBattle;
			if (!realBattle)
			{
				this.pillageClockLabel.Visible = false;
				this.pillageBar.Visible = false;
				this.reportBar.Visible = false;
				this.reportClockLabel.Visible = false;
				this.reportHeadingLabel.Visible = false;
			}
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x000D180C File Offset: 0x000CFA0C
		public void setTimes(DateTime castleTime, DateTime troopTime)
		{
			this.reportHeadingLabel.Visible = false;
			this.pillageBar.Visible = false;
			this.pillageClockLabel.Visible = false;
			if (castleTime == DateTime.MaxValue)
			{
				this.viewCastleLabel.Visible = false;
				this.viewCastleHeadingLabel.Visible = false;
			}
			else if (castleTime == DateTime.MinValue)
			{
				this.viewCastleLabel.Text = SK.Text("CastleMapBattle_None_Available", "None Available");
			}
			else
			{
				this.viewCastleLabel.Text = castleTime.ToShortDateString() + ":" + castleTime.ToShortTimeString();
			}
			if (troopTime == DateTime.MaxValue)
			{
				this.viewTroopsLabel.Visible = false;
				this.viewTroopsHeadingLabel.Visible = false;
				return;
			}
			if (troopTime == DateTime.MinValue)
			{
				this.viewTroopsLabel.Text = SK.Text("CastleMapBattle_None_Available", "None Available");
				return;
			}
			this.viewTroopsLabel.Text = troopTime.ToShortDateString() + ":" + troopTime.ToShortTimeString();
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x000D1924 File Offset: 0x000CFB24
		public void setPillageClock(int pillageClock, int pillageClockMax)
		{
			if (pillageClock < 0)
			{
				this.pillageBar.Visible = false;
				this.pillageClockLabel.Visible = false;
				return;
			}
			this.pillageBar.Visible = true;
			this.pillageClockLabel.Visible = true;
			this.pillageBar.Number = (double)pillageClock;
			this.pillageClockLabel.Text = (pillageClock / 10).ToString();
			this.pillageBar.MaxValue = (double)pillageClockMax;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x000D1998 File Offset: 0x000CFB98
		public void setCastleReportClock(int reportClock, int reportClockMax)
		{
			if (this.m_aiAttack)
			{
				this.reportBar.Visible = false;
				this.reportClockLabel.Visible = false;
				this.reportHeadingLabel.Visible = false;
				return;
			}
			this.reportHeadingLabel.Visible = true;
			if (reportClock < 0)
			{
				this.reportBar.Visible = false;
				this.reportClockLabel.Visible = false;
				this.reportHeadingLabel.Text = SK.Text("CastleMapBattle_Report_Available", "Report Available To Attacker");
				return;
			}
			this.reportHeadingLabel.Text = SK.Text("CastleMapBattle_Report_Unavailable", "Report Unavailable To Attacker");
			this.reportBar.Visible = true;
			this.reportClockLabel.Visible = true;
			this.reportBar.Number = (double)reportClock;
			this.reportClockLabel.Text = (reportClock / 10).ToString();
			this.reportBar.MaxValue = (double)reportClockMax;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0000DE2C File Offset: 0x0000C02C
		public static void fromWorld()
		{
			CastleMapBattlePanel2.Instance.fromWorldInst();
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0000DE38 File Offset: 0x0000C038
		private void fromWorldInst()
		{
			CastleMapBattlePanel2.fromReports = false;
			CastleMapBattlePanel2.paused = false;
			CastleMapBattlePanel2.fast = false;
			CastleMapBattlePanel2.high = false;
			this.resultsMode = false;
			this.updateButtons();
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x000D1A78 File Offset: 0x000CFC78
		private void updateButtons()
		{
			if (this.resultsMode)
			{
				this.pauseButton.Text.Text = SK.Text("CastleMapBattle_View_Report", "View Report");
				return;
			}
			if (CastleMapBattlePanel2.paused)
			{
				this.pauseButton.Text.Text = SK.Text("CastleMapBattle_Resume", "Resume");
			}
			else
			{
				this.pauseButton.Text.Text = SK.Text("CastleMapBattle_Pause", "Pause");
			}
			if (!CastleMapBattlePanel2.fast)
			{
				this.speedButton.Text.Text = SK.Text("CastleMapBattle_Fast_Speed", "Fast Speed");
				return;
			}
			this.speedButton.Text.Text = SK.Text("CastleMapBattle_Normal_Speed", "Normal Speed");
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x000D1B40 File Offset: 0x000CFD40
		private void togglePauseClick()
		{
			if (!this.resultsMode)
			{
				CastleMapBattlePanel2.paused = !CastleMapBattlePanel2.paused;
				if (GameEngine.Instance.CastleBattle != null)
				{
					if (CastleMapBattlePanel2.paused)
					{
						GameEngine.Instance.CastleBattle.pauseBattle();
					}
					else
					{
						GameEngine.Instance.CastleBattle.unpauseBattle();
					}
				}
			}
			else
			{
				this.ShowViewBattleResults(this.m_attackerVictory, this.m_startingTroops, this.m_endingTroops, this.m_villageID, this.m_reportReturnData);
			}
			this.updateButtons();
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0000DE5F File Offset: 0x0000C05F
		private void toggleSpeedClick()
		{
			if (!this.resultsMode)
			{
				CastleMapBattlePanel2.fast = !CastleMapBattlePanel2.fast;
				if (GameEngine.Instance.CastleBattle != null)
				{
					GameEngine.Instance.CastleBattle.setFastPlayback(CastleMapBattlePanel2.fast);
				}
			}
			this.updateButtons();
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x000D1BC4 File Offset: 0x000CFDC4
		private void toggleHeightClick()
		{
			CastleMapBattlePanel2.high = !CastleMapBattlePanel2.high;
			if (GameEngine.Instance.CastleBattle != null)
			{
				GameEngine.Instance.CastleBattle.toggleHeight();
				if (CastleMapBattlePanel2.high)
				{
					GameEngine.Instance.playInterfaceSound("CastleMapBattlePanel2_height_high");
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("CastleMapBattlePanel2_height_low");
				}
			}
			this.updateButtons();
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x0000DE9C File Offset: 0x0000C09C
		private void closeClick()
		{
			if (CastleMapBattlePanel2.fromReports)
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(7);
				return;
			}
			InterfaceMgr.Instance.getMainTabBar().changeTab(0);
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0000DEC6 File Offset: 0x0000C0C6
		public void closePopup(bool exit, bool tutorial)
		{
			if (exit)
			{
				this.closeClick();
			}
			else
			{
				this.resultsMode = true;
				this.speedButton.Visible = false;
				this.updateButtons();
			}
			if (tutorial)
			{
				PostTutorialWindow.CreatePostTutorialWindow(true);
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x000D1C28 File Offset: 0x000CFE28
		public void ShowViewBattleResults(bool attackerVictory, BattleTroopNumbers startingTroops, BattleTroopNumbers endingTroops, int villageID, GetReport_ReturnType reportReturnData)
		{
			this.m_attackerVictory = attackerVictory;
			this.m_startingTroops = startingTroops;
			this.m_endingTroops = endingTroops;
			this.m_villageID = villageID;
			this.m_reportReturnData = reportReturnData;
			if (this.battleResultPopup != null)
			{
				if (this.battleResultPopup.Created)
				{
					this.battleResultPopup.Close();
				}
				this.battleResultPopup = null;
			}
			this.battleResultPopup = new BattleResultPopup();
			this.battleResultPopup.init(attackerVictory, startingTroops, endingTroops, this.m_attackType, villageID, reportReturnData, this);
			if (attackerVictory)
			{
				if (GameEngine.Instance.World.isUserVillage(villageID))
				{
					Sound.playBattleEndDefeatMusic();
				}
				else
				{
					Sound.playBattleEndVictoryMusic();
				}
			}
			else if (GameEngine.Instance.World.isUserVillage(villageID))
			{
				Sound.playBattleEndVictoryMusic();
			}
			else
			{
				Sound.playBattleEndDefeatMusic();
			}
			Form parentForm = InterfaceMgr.Instance.ParentForm;
			Size size = parentForm.Size;
			size.Width -= this.battleResultPopup.Width;
			size.Height -= this.battleResultPopup.Height;
			Point location = parentForm.Location;
			this.battleResultPopup.Location = new Point(location.X + size.Width / 2, location.Y + size.Height / 2);
			this.battleResultPopup.Show(InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x000D1D7C File Offset: 0x000CFF7C
		private void exportClick()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = "";
			saveFileDialog.Filter = "All Save Types (*.*)|*.*";
			saveFileDialog.Title = "Save Castle and attackers Data";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				GameEngine.Instance.CastleBattle.SaveCastleMap(saveFileDialog.FileName);
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0000DEF5 File Offset: 0x0000C0F5
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0000DF05 File Offset: 0x0000C105
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x0000DF15 File Offset: 0x0000C115
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x0000DF27 File Offset: 0x0000C127
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0000DF34 File Offset: 0x0000C134
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x0000DF42 File Offset: 0x0000C142
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x0000DF4F File Offset: 0x0000C14F
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x0000DF5C File Offset: 0x0000C15C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x000D1DD0 File Offset: 0x000CFFD0
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "CastleMapBattlePanel2";
			base.Size = new Size(196, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000E13 RID: 3603
		private static CastleMapBattlePanel2 Instance = null;

		// Token: 0x04000E14 RID: 3604
		private CustomSelfDrawPanel.CSDArea backgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000E15 RID: 3605
		private CustomSelfDrawPanel.CSDImage backPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000E16 RID: 3606
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E17 RID: 3607
		private CustomSelfDrawPanel.CSDLabel attackTypeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E18 RID: 3608
		private CustomSelfDrawPanel.CSDLabel pillageClockLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E19 RID: 3609
		private CustomSelfDrawPanel.CSDButton pauseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E1A RID: 3610
		private CustomSelfDrawPanel.CSDButton speedButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E1B RID: 3611
		private CustomSelfDrawPanel.CSDButton heightButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E1C RID: 3612
		private CustomSelfDrawPanel.CSDLabel viewCastleHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E1D RID: 3613
		private CustomSelfDrawPanel.CSDLabel viewCastleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E1E RID: 3614
		private CustomSelfDrawPanel.CSDLabel viewTroopsHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E1F RID: 3615
		private CustomSelfDrawPanel.CSDLabel viewTroopsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E20 RID: 3616
		private CustomSelfDrawPanel.CSDLabel reportHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E21 RID: 3617
		private CustomSelfDrawPanel.CSDColorBar reportBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04000E22 RID: 3618
		private CustomSelfDrawPanel.CSDColorBar pillageBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04000E23 RID: 3619
		private CustomSelfDrawPanel.CSDLabel reportClockLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000E24 RID: 3620
		private CustomSelfDrawPanel.CSDButton adminExportAllButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000E25 RID: 3621
		public static bool fromReports = true;

		// Token: 0x04000E26 RID: 3622
		private static bool paused = false;

		// Token: 0x04000E27 RID: 3623
		private static bool fast = false;

		// Token: 0x04000E28 RID: 3624
		private static bool high = false;

		// Token: 0x04000E29 RID: 3625
		private bool resultsMode;

		// Token: 0x04000E2A RID: 3626
		private int m_attackType = -1;

		// Token: 0x04000E2B RID: 3627
		private bool m_aiAttack;

		// Token: 0x04000E2C RID: 3628
		private bool m_attackerVictory;

		// Token: 0x04000E2D RID: 3629
		private BattleTroopNumbers m_startingTroops;

		// Token: 0x04000E2E RID: 3630
		private BattleTroopNumbers m_endingTroops;

		// Token: 0x04000E2F RID: 3631
		private int m_villageID = -1;

		// Token: 0x04000E30 RID: 3632
		private GetReport_ReturnType m_reportReturnData;

		// Token: 0x04000E31 RID: 3633
		private BattleResultPopup battleResultPopup;

		// Token: 0x04000E32 RID: 3634
		private DockableControl dockableControl;

		// Token: 0x04000E33 RID: 3635
		private IContainer components;
	}
}
