using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020004BE RID: 1214
	public class VassalArmiesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002CD0 RID: 11472 RVA: 0x0023B3A8 File Offset: 0x002395A8
		public VassalArmiesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x0023B618 File Offset: 0x00239818
		public void init(bool resized)
		{
			int height = base.Height;
			VassalArmiesPanel2.instance = this;
			base.clearControls();
			this.backgroundImage.Image = GFXLibrary.body_background_002;
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Tile = true;
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundLeftEdge.Image = GFXLibrary.body_background_canvas_left_edge;
			this.backgroundLeftEdge.Position = new Point(0, 0);
			this.backgroundLeftEdge.Size = new Size(this.backgroundLeftEdge.Image.Width, height - 40);
			this.backgroundLeftEdge.Tile = true;
			this.backgroundImage.addControl(this.backgroundLeftEdge);
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.CreateX(GFXLibrary.mail_top_drag_bar_left, GFXLibrary.mail_top_drag_bar_middle, GFXLibrary.mail_top_drag_bar_right, -2, 2);
			this.parishNameLabel.Text = SK.Text("Vassal_Manage_Vassal_Troops", "Manage Vassal Troops") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_vassalVillageID);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.cardbar.Position = new Point(0, 4);
			this.backgroundImage.addControl(this.cardbar);
			this.cardbar.init(6);
			this.atVassalLabel.Text = SK.Text("Vassal_StationedTroops", "Stationed Troops");
			this.atVassalLabel.Position = new Point(115, 58);
			this.atVassalLabel.Size = new Size(220, 40);
			this.atVassalLabel.Color = global::ARGBColors.Black;
			this.atVassalLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.atVassalLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.backgroundImage.addControl(this.atVassalLabel);
			this.troopsAvailableToSendLabel.Text = SK.Text("Vassal_AvailableToSend", "Troops Available to Send");
			this.troopsAvailableToSendLabel.Position = new Point(355, 58);
			this.troopsAvailableToSendLabel.Size = new Size(520, 40);
			this.troopsAvailableToSendLabel.Color = global::ARGBColors.Black;
			this.troopsAvailableToSendLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.troopsAvailableToSendLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.backgroundImage.addControl(this.troopsAvailableToSendLabel);
			this.trackBackImage.Image = GFXLibrary.reinforce_Vassal_screen_back;
			this.trackBackImage.Position = new Point(100, 100);
			this.backgroundImage.addControl(this.trackBackImage);
			int num = 14;
			this.peasantName2.Text = SK.Text("GENERIC_Peasants", "Peasants");
			this.peasantName2.Position = new Point(-50, num);
			this.peasantName2.Size = new Size(142, 40);
			this.peasantName2.Color = global::ARGBColors.Black;
			this.peasantName2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.peasantName2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.peasantName2);
			this.archerName2.Text = SK.Text("GENERIC_Archers", "Archers");
			this.archerName2.Position = new Point(-50, num + 40);
			this.archerName2.Size = new Size(142, 40);
			this.archerName2.Color = global::ARGBColors.Black;
			this.archerName2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.archerName2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.archerName2);
			this.pikemanName2.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
			this.pikemanName2.Position = new Point(-50, num + 80);
			this.pikemanName2.Size = new Size(142, 40);
			this.pikemanName2.Color = global::ARGBColors.Black;
			this.pikemanName2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pikemanName2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.pikemanName2);
			this.swordsmanName2.Text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
			this.swordsmanName2.Position = new Point(-50, num + 120);
			this.swordsmanName2.Size = new Size(142, 40);
			this.swordsmanName2.Color = global::ARGBColors.Black;
			this.swordsmanName2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.swordsmanName2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.swordsmanName2);
			this.catapultName2.Text = SK.Text("GENERIC_Catapults", "Catapults");
			this.catapultName2.Position = new Point(-50, num + 160);
			this.catapultName2.Size = new Size(142, 40);
			this.catapultName2.Color = global::ARGBColors.Black;
			this.catapultName2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultName2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultName2);
			this.stationedTotalLabel.Text = SK.Text("GENERIC_Total_Troops", "Total Troops");
			this.stationedTotalLabel.Position = new Point(-50, num + 200);
			this.stationedTotalLabel.Size = new Size(142, 40);
			this.stationedTotalLabel.Color = global::ARGBColors.Black;
			this.stationedTotalLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.stationedTotalLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.stationedTotalLabel);
			this.maxValueLabel.Text = SK.Text("GENERIC_Max_Troops", "Max Troops");
			this.maxValueLabel.Position = new Point(-50, num + 240);
			this.maxValueLabel.Size = new Size(142, 40);
			this.maxValueLabel.Color = global::ARGBColors.Black;
			this.maxValueLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.maxValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.maxValueLabel);
			this.peasantStationedValue.Text = "0";
			this.peasantStationedValue.Position = new Point(56, num);
			this.peasantStationedValue.Size = new Size(142, 40);
			this.peasantStationedValue.Color = global::ARGBColors.Black;
			this.peasantStationedValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.peasantStationedValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.peasantStationedValue);
			this.archerStationedValue.Text = "0";
			this.archerStationedValue.Position = new Point(56, num + 40);
			this.archerStationedValue.Size = new Size(142, 40);
			this.archerStationedValue.Color = global::ARGBColors.Black;
			this.archerStationedValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.archerStationedValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.archerStationedValue);
			this.pikemanStationedValue.Text = "0";
			this.pikemanStationedValue.Position = new Point(56, num + 80);
			this.pikemanStationedValue.Size = new Size(142, 40);
			this.pikemanStationedValue.Color = global::ARGBColors.Black;
			this.pikemanStationedValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pikemanStationedValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.pikemanStationedValue);
			this.swordsmanStationedValue.Text = "0";
			this.swordsmanStationedValue.Position = new Point(56, num + 120);
			this.swordsmanStationedValue.Size = new Size(142, 40);
			this.swordsmanStationedValue.Color = global::ARGBColors.Black;
			this.swordsmanStationedValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.swordsmanStationedValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.swordsmanStationedValue);
			this.catapultStationedValue.Text = "0";
			this.catapultStationedValue.Position = new Point(56, num + 160);
			this.catapultStationedValue.Size = new Size(142, 40);
			this.catapultStationedValue.Color = global::ARGBColors.Black;
			this.catapultStationedValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultStationedValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultStationedValue);
			this.stationedTotalValue.Text = "0";
			this.stationedTotalValue.Position = new Point(56, num + 200);
			this.stationedTotalValue.Size = new Size(142, 40);
			this.stationedTotalValue.Color = global::ARGBColors.Black;
			this.stationedTotalValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.stationedTotalValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.stationedTotalValue);
			this.maxValue.Text = "0";
			this.maxValue.Position = new Point(56, num + 240);
			this.maxValue.Size = new Size(142, 40);
			this.maxValue.Color = global::ARGBColors.Black;
			this.maxValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.maxValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.maxValue);
			this.peasantName.Text = SK.Text("GENERIC_Peasants", "Peasants");
			this.peasantName.Position = new Point(190, num);
			this.peasantName.Size = new Size(142, 40);
			this.peasantName.Color = global::ARGBColors.Black;
			this.peasantName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.peasantName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.peasantName);
			this.archerName.Text = SK.Text("GENERIC_Archers", "Archers");
			this.archerName.Position = new Point(190, num + 40);
			this.archerName.Size = new Size(142, 40);
			this.archerName.Color = global::ARGBColors.Black;
			this.archerName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.archerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.archerName);
			this.pikemanName.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
			this.pikemanName.Position = new Point(190, num + 80);
			this.pikemanName.Size = new Size(142, 40);
			this.pikemanName.Color = global::ARGBColors.Black;
			this.pikemanName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pikemanName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.pikemanName);
			this.swordsmanName.Text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
			this.swordsmanName.Position = new Point(190, num + 120);
			this.swordsmanName.Size = new Size(142, 40);
			this.swordsmanName.Color = global::ARGBColors.Black;
			this.swordsmanName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.swordsmanName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.swordsmanName);
			this.catapultName.Text = SK.Text("GENERIC_Catapults", "Catapults");
			this.catapultName.Position = new Point(190, num + 160);
			this.catapultName.Size = new Size(142, 40);
			this.catapultName.Color = global::ARGBColors.Black;
			this.catapultName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultName);
			this.peasantStoredValue.Text = "0";
			this.peasantStoredValue.Position = new Point(296, num);
			this.peasantStoredValue.Size = new Size(142, 40);
			this.peasantStoredValue.Color = global::ARGBColors.Black;
			this.peasantStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.peasantStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.peasantStoredValue);
			this.archerStoredValue.Text = "0";
			this.archerStoredValue.Position = new Point(296, num + 40);
			this.archerStoredValue.Size = new Size(142, 40);
			this.archerStoredValue.Color = global::ARGBColors.Black;
			this.archerStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.archerStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.archerStoredValue);
			this.pikemanStoredValue.Text = "0";
			this.pikemanStoredValue.Position = new Point(296, num + 80);
			this.pikemanStoredValue.Size = new Size(142, 40);
			this.pikemanStoredValue.Color = global::ARGBColors.Black;
			this.pikemanStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pikemanStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.pikemanStoredValue);
			this.swordsmanStoredValue.Text = "0";
			this.swordsmanStoredValue.Position = new Point(296, num + 120);
			this.swordsmanStoredValue.Size = new Size(142, 40);
			this.swordsmanStoredValue.Color = global::ARGBColors.Black;
			this.swordsmanStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.swordsmanStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.swordsmanStoredValue);
			this.catapultStoredValue.Text = "0";
			this.catapultStoredValue.Position = new Point(296, num + 160);
			this.catapultStoredValue.Size = new Size(142, 40);
			this.catapultStoredValue.Color = global::ARGBColors.Black;
			this.catapultStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultStoredValue);
			this.peasantSendValue.Text = "0";
			this.peasantSendValue.Position = new Point(296, num);
			this.peasantSendValue.Size = new Size(402, 40);
			this.peasantSendValue.Color = global::ARGBColors.Black;
			this.peasantSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.peasantSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.peasantSendValue);
			this.archerSendValue.Text = "0";
			this.archerSendValue.Position = new Point(296, num + 40);
			this.archerSendValue.Size = new Size(402, 40);
			this.archerSendValue.Color = global::ARGBColors.Black;
			this.archerSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.archerSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.archerSendValue);
			this.pikemanSendValue.Text = "0";
			this.pikemanSendValue.Position = new Point(296, num + 80);
			this.pikemanSendValue.Size = new Size(402, 40);
			this.pikemanSendValue.Color = global::ARGBColors.Black;
			this.pikemanSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.pikemanSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.pikemanSendValue);
			this.swordsmanSendValue.Text = "0";
			this.swordsmanSendValue.Position = new Point(296, num + 120);
			this.swordsmanSendValue.Size = new Size(402, 40);
			this.swordsmanSendValue.Color = global::ARGBColors.Black;
			this.swordsmanSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.swordsmanSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.swordsmanSendValue);
			this.catapultSendValue.Text = "0";
			this.catapultSendValue.Position = new Point(296, num + 160);
			this.catapultSendValue.Size = new Size(402, 40);
			this.catapultSendValue.Color = global::ARGBColors.Black;
			this.catapultSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultSendValue);
			this.peasantsTrack.Position = new Point(447, 15);
			this.peasantsTrack.Size = new Size(203, 23);
			this.peasantsTrack.Max = 100;
			if (!resized)
			{
				this.peasantsTrack.Value = 0;
			}
			this.peasantsTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved0));
			this.trackBackImage.addControl(this.peasantsTrack);
			this.peasantsTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.peasantsEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.peasantsEditButton.ImageOver = GFXLibrary.faction_pen;
			this.peasantsEditButton.ImageClick = GFXLibrary.faction_pen;
			this.peasantsEditButton.MoveOnClick = true;
			this.peasantsEditButton.OverBrighten = true;
			this.peasantsEditButton.Position = new Point(659, 12);
			this.peasantsEditButton.Data = 1;
			this.peasantsEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.peasantsEditButton);
			this.archerTrack.Position = new Point(447, 55);
			this.archerTrack.Size = new Size(203, 23);
			this.archerTrack.Max = 100;
			if (!resized)
			{
				this.archerTrack.Value = 0;
			}
			this.archerTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved1));
			this.trackBackImage.addControl(this.archerTrack);
			this.archerTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.archerEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.archerEditButton.ImageOver = GFXLibrary.faction_pen;
			this.archerEditButton.ImageClick = GFXLibrary.faction_pen;
			this.archerEditButton.MoveOnClick = true;
			this.archerEditButton.OverBrighten = true;
			this.archerEditButton.Position = new Point(659, 52);
			this.archerEditButton.Data = 2;
			this.archerEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.archerEditButton);
			this.pikemanTrack.Position = new Point(447, 95);
			this.pikemanTrack.Size = new Size(203, 23);
			this.pikemanTrack.Max = 100;
			if (!resized)
			{
				this.pikemanTrack.Value = 0;
			}
			this.pikemanTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved2));
			this.trackBackImage.addControl(this.pikemanTrack);
			this.pikemanTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.pikemanEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.pikemanEditButton.ImageOver = GFXLibrary.faction_pen;
			this.pikemanEditButton.ImageClick = GFXLibrary.faction_pen;
			this.pikemanEditButton.MoveOnClick = true;
			this.pikemanEditButton.OverBrighten = true;
			this.pikemanEditButton.Position = new Point(659, 92);
			this.pikemanEditButton.Data = 3;
			this.pikemanEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.pikemanEditButton);
			this.swordsmanTrack.Position = new Point(447, 135);
			this.swordsmanTrack.Size = new Size(203, 23);
			this.swordsmanTrack.Max = 100;
			if (!resized)
			{
				this.swordsmanTrack.Value = 0;
			}
			this.swordsmanTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved3));
			this.trackBackImage.addControl(this.swordsmanTrack);
			this.swordsmanTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.swordsmanEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.swordsmanEditButton.ImageOver = GFXLibrary.faction_pen;
			this.swordsmanEditButton.ImageClick = GFXLibrary.faction_pen;
			this.swordsmanEditButton.MoveOnClick = true;
			this.swordsmanEditButton.OverBrighten = true;
			this.swordsmanEditButton.Position = new Point(659, 132);
			this.swordsmanEditButton.Data = 4;
			this.swordsmanEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.swordsmanEditButton);
			this.catapultTrack.Position = new Point(447, 175);
			this.catapultTrack.Size = new Size(203, 23);
			this.catapultTrack.Max = 100;
			if (!resized)
			{
				this.catapultTrack.Value = 0;
			}
			this.catapultTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved4));
			this.trackBackImage.addControl(this.catapultTrack);
			this.catapultTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.catapultEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.catapultEditButton.ImageOver = GFXLibrary.faction_pen;
			this.catapultEditButton.ImageClick = GFXLibrary.faction_pen;
			this.catapultEditButton.MoveOnClick = true;
			this.catapultEditButton.OverBrighten = true;
			this.catapultEditButton.Position = new Point(659, 172);
			this.catapultEditButton.Data = 5;
			this.catapultEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.catapultEditButton);
			this.btnSend.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
			this.btnSend.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
			this.btnSend.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
			this.btnSend.Position = new Point(600, 205);
			this.btnSend.Text.Text = SK.Text("VassalArmiesPanel_", "Send");
			this.btnSend.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnSend.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnSend.TextYOffset = -3;
			this.btnSend.Text.Color = global::ARGBColors.Black;
			this.btnSend.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendClick), "VassalArmiesPanel2_send");
			this.btnSend.Enabled = false;
			this.trackBackImage.addControl(this.btnSend);
			if (GameEngine.Instance.World.isVassal(this.m_playerVillageID, this.m_vassalVillageID))
			{
				this.btnSend.Visible = true;
			}
			else
			{
				this.btnSend.Visible = false;
			}
			this.updateValues();
			if (!resized)
			{
				RemoteServices.Instance.set_GetVassalArmyInfo_UserCallBack(new RemoteServices.GetVassalArmyInfo_UserCallBack(this.getVassalArmyInfoCallback));
				RemoteServices.Instance.GetVassalArmyInfo(this.m_vassalVillageID, 0, -1);
			}
			this.btnClose.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnClose.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnClose.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnClose.Position = new Point(base.Width - 230, height - 40 - 40 - 4);
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnClose.TextYOffset = -3;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "VassalArmiesPanel2_close");
			this.backgroundImage.addControl(this.btnClose);
		}

		// Token: 0x06002CD2 RID: 11474 RVA: 0x00020DF8 File Offset: 0x0001EFF8
		public void update()
		{
			this.cardbar.update();
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x0023D294 File Offset: 0x0023B494
		public void getVassalArmyInfoCallback(GetVassalArmyInfo_ReturnType returnData)
		{
			if (returnData != null && returnData.Success && this.m_vassalVillageID == returnData.vassalVillageID)
			{
				VassalsOverview.AddVassalToCache(returnData);
				this.peasantStationedValue.Text = (returnData.numStationedTroops_Peasants + returnData.numAttackingTroops_Peasants + returnData.numEnrouteTroops_Peasants).ToString();
				this.archerStationedValue.Text = (returnData.numStationedTroops_Archers + returnData.numAttackingTroops_Archers + returnData.numEnrouteTroops_Archers).ToString();
				this.pikemanStationedValue.Text = (returnData.numStationedTroops_Pikemen + returnData.numAttackingTroops_Pikemen + returnData.numEnrouteTroops_Pikemen).ToString();
				this.swordsmanStationedValue.Text = (returnData.numStationedTroops_Swordsmen + returnData.numAttackingTroops_Swordsmen + returnData.numEnrouteTroops_Swordsmen).ToString();
				this.catapultStationedValue.Text = (returnData.numStationedTroops_Catapults + returnData.numAttackingTroops_Catapults + returnData.numEnrouteTroops_Catapults).ToString();
				int num = ResearchData.commandResearchTroopLevels[(int)GameEngine.Instance.World.userResearchData.Research_Command];
				this.maxValue.Text = num.ToString();
				int totalTroops = returnData.TotalTroops;
				this.stationedTotalValue.Text = totalTroops.ToString();
				this.m_maxCanSend = num - totalTroops;
				if (this.m_maxCanSend < 0)
				{
					this.m_maxCanSend = 0;
				}
				this.peasantsTrack.Value = 0;
				this.archerTrack.Value = 0;
				this.pikemanTrack.Value = 0;
				this.swordsmanTrack.Value = 0;
				this.catapultTrack.Value = 0;
				this.peasantsTrack.Max = 0;
				this.archerTrack.Max = 0;
				this.pikemanTrack.Max = 0;
				this.swordsmanTrack.Max = 0;
				this.catapultTrack.Max = 0;
				this.updateValues();
				this.btnSend.Enabled = false;
			}
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x0023D478 File Offset: 0x0023B678
		public void updateValues()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.peasantStoredValue.Text = village.m_numPeasants.ToString();
				this.archerStoredValue.Text = village.m_numArchers.ToString();
				this.pikemanStoredValue.Text = village.m_numPikemen.ToString();
				this.swordsmanStoredValue.Text = village.m_numSwordsmen.ToString();
				this.catapultStoredValue.Text = village.m_numCatapults.ToString();
				this.peasantsTrack.Max = Math.Max(Math.Min(village.m_numPeasants, this.m_maxCanSend), 0);
				this.archerTrack.Max = Math.Max(Math.Min(village.m_numArchers, this.m_maxCanSend), 0);
				this.pikemanTrack.Max = Math.Max(Math.Min(village.m_numPikemen, this.m_maxCanSend), 0);
				this.swordsmanTrack.Max = Math.Max(Math.Min(village.m_numSwordsmen, this.m_maxCanSend), 0);
				this.catapultTrack.Max = Math.Max(Math.Min(village.m_numCatapults, this.m_maxCanSend), 0);
				this.updateSlider();
			}
		}

		// Token: 0x06002CD5 RID: 11477 RVA: 0x0023D5B4 File Offset: 0x0023B7B4
		public void updateSlider()
		{
			this.peasantSendValue.Text = this.peasantsTrack.Value.ToString();
			this.archerSendValue.Text = this.archerTrack.Value.ToString();
			this.pikemanSendValue.Text = this.pikemanTrack.Value.ToString();
			this.swordsmanSendValue.Text = this.swordsmanTrack.Value.ToString();
			this.catapultSendValue.Text = this.catapultTrack.Value.ToString();
			int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value + this.catapultTrack.Value;
			if (num > 0)
			{
				this.btnSend.Enabled = true;
				return;
			}
			this.btnSend.Enabled = false;
		}

		// Token: 0x06002CD6 RID: 11478 RVA: 0x0023D6B0 File Offset: 0x0023B8B0
		public void updateSliderValues(int type)
		{
			int i = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value + this.catapultTrack.Value;
			int num = i;
			if (i > this.m_maxCanSend)
			{
				if (this.m_maxCanSend == 0)
				{
					this.peasantsTrack.Value = 0;
					this.archerTrack.Value = 0;
					this.pikemanTrack.Value = 0;
					this.swordsmanTrack.Value = 0;
					this.catapultTrack.Value = 0;
					return;
				}
				i -= this.m_maxCanSend;
				int num2 = 0;
				while (i > 0)
				{
					if (num2 != type)
					{
						switch (num2)
						{
						case 0:
							if (this.peasantsTrack.Value > 0)
							{
								CustomSelfDrawPanel.CSDTrackBar csdtrackBar = this.peasantsTrack;
								int value = csdtrackBar.Value;
								csdtrackBar.Value = value - 1;
								i--;
							}
							break;
						case 1:
							if (this.archerTrack.Value > 0)
							{
								CustomSelfDrawPanel.CSDTrackBar csdtrackBar2 = this.archerTrack;
								int value = csdtrackBar2.Value;
								csdtrackBar2.Value = value - 1;
								i--;
							}
							break;
						case 2:
							if (this.pikemanTrack.Value > 0)
							{
								CustomSelfDrawPanel.CSDTrackBar csdtrackBar3 = this.pikemanTrack;
								int value = csdtrackBar3.Value;
								csdtrackBar3.Value = value - 1;
								i--;
							}
							break;
						case 3:
							if (this.swordsmanTrack.Value > 0)
							{
								CustomSelfDrawPanel.CSDTrackBar csdtrackBar4 = this.swordsmanTrack;
								int value = csdtrackBar4.Value;
								csdtrackBar4.Value = value - 1;
								i--;
							}
							break;
						case 4:
							if (this.catapultTrack.Value > 0)
							{
								CustomSelfDrawPanel.CSDTrackBar csdtrackBar5 = this.catapultTrack;
								int value = csdtrackBar5.Value;
								csdtrackBar5.Value = value - 1;
								i--;
							}
							break;
						}
					}
					num2++;
					if (num2 >= 5)
					{
						num2 = 0;
					}
				}
			}
			this.peasantSendValue.Text = this.peasantsTrack.Value.ToString();
			this.archerSendValue.Text = this.archerTrack.Value.ToString();
			this.pikemanSendValue.Text = this.pikemanTrack.Value.ToString();
			this.swordsmanSendValue.Text = this.swordsmanTrack.Value.ToString();
			this.catapultSendValue.Text = this.catapultTrack.Value.ToString();
			if (num > 0)
			{
				this.btnSend.Enabled = true;
				return;
			}
			this.btnSend.Enabled = false;
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x00020E06 File Offset: 0x0001F006
		public void tracksMoved0()
		{
			if (this.allowSliderUpdate)
			{
				this.allowSliderUpdate = false;
				this.updateSliderValues(0);
				this.allowSliderUpdate = true;
			}
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x00020E25 File Offset: 0x0001F025
		public void tracksMoved1()
		{
			if (this.allowSliderUpdate)
			{
				this.allowSliderUpdate = false;
				this.updateSliderValues(1);
				this.allowSliderUpdate = true;
			}
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x00020E44 File Offset: 0x0001F044
		public void tracksMoved2()
		{
			if (this.allowSliderUpdate)
			{
				this.allowSliderUpdate = false;
				this.updateSliderValues(2);
				this.allowSliderUpdate = true;
			}
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x00020E63 File Offset: 0x0001F063
		public void tracksMoved3()
		{
			if (this.allowSliderUpdate)
			{
				this.allowSliderUpdate = false;
				this.updateSliderValues(3);
				this.allowSliderUpdate = true;
			}
		}

		// Token: 0x06002CDB RID: 11483 RVA: 0x00020E82 File Offset: 0x0001F082
		public void tracksMoved4()
		{
			if (this.allowSliderUpdate)
			{
				this.allowSliderUpdate = false;
				this.updateSliderValues(4);
				this.allowSliderUpdate = true;
			}
		}

		// Token: 0x06002CDC RID: 11484 RVA: 0x0023D91C File Offset: 0x0023BB1C
		private void editSendValue()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int num = 272;
			switch (csdbutton.Data)
			{
			case 1:
				this.currentTrack = this.peasantsTrack;
				break;
			case 2:
				this.currentTrack = this.archerTrack;
				num += 40;
				break;
			case 3:
				this.currentTrack = this.pikemanTrack;
				num += 80;
				break;
			case 4:
				this.currentTrack = this.swordsmanTrack;
				num += 120;
				break;
			case 5:
				this.currentTrack = this.catapultTrack;
				num += 160;
				break;
			}
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.setTrackCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(base.Location.X + 783, base.Location.Y + num));
			FloatingInput.open(point.X, point.Y, this.currentTrack.Value, this.currentTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06002CDD RID: 11485 RVA: 0x00020EA1 File Offset: 0x0001F0A1
		private void setTrackCB(int value)
		{
			if (this.currentTrack != null)
			{
				this.currentTrack.Value = value;
				this.updateSlider();
			}
		}

		// Token: 0x06002CDE RID: 11486 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06002CDF RID: 11487 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06002CE0 RID: 11488 RVA: 0x00020EBD File Offset: 0x0001F0BD
		private void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(8);
		}

		// Token: 0x06002CE1 RID: 11489 RVA: 0x00020ECA File Offset: 0x0001F0CA
		public void setVassalArmiesVillage(int villageID)
		{
			if (villageID >= 0)
			{
				this.m_vassalVillageID = villageID;
				this.m_playerVillageID = InterfaceMgr.Instance.getSelectedMenuVillage();
				return;
			}
			this.m_vassalVillageID = -1;
		}

		// Token: 0x06002CE2 RID: 11490 RVA: 0x0023DA40 File Offset: 0x0023BC40
		private void sendClick()
		{
			int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value + this.catapultTrack.Value;
			if (num > 0)
			{
				VillageMap village = GameEngine.Instance.getVillage(this.m_playerVillageID);
				if (village != null)
				{
					RemoteServices.Instance.set_SendTroopsToVassal_UserCallBack(new RemoteServices.SendTroopsToVassal_UserCallBack(this.sendTroopsToVassalCallback));
					RemoteServices.Instance.SendTroopsToVassal(village.VillageID, this.m_vassalVillageID, this.peasantsTrack.Value, this.archerTrack.Value, this.pikemanTrack.Value, this.swordsmanTrack.Value, this.catapultTrack.Value);
					this.allowSliderUpdate = false;
					this.peasantsTrack.Value = 0;
					this.archerTrack.Value = 0;
					this.pikemanTrack.Value = 0;
					this.swordsmanTrack.Value = 0;
					this.catapultTrack.Value = 0;
					this.updateSliderValues(0);
					this.allowSliderUpdate = true;
					this.btnSend.Enabled = false;
				}
			}
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x0023DB68 File Offset: 0x0023BD68
		public void sendTroopsToVassalCallback(SendTroopsToVassal_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.vassalArmyReturnData != null)
				{
					this.getVassalArmyInfoCallback(returnData.vassalArmyReturnData);
				}
				if (returnData.armyData != null)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
					if (village != null)
					{
						village.addTroops(-returnData.numPeasants, -returnData.numArchers, -returnData.numPikemen, -returnData.numSwordsmen, -returnData.numCatapults);
					}
					this.updateValues();
				}
			}
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x00020EEF File Offset: 0x0001F0EF
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002CE5 RID: 11493 RVA: 0x00020EFF File Offset: 0x0001F0FF
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x00020F0F File Offset: 0x0001F10F
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002CE7 RID: 11495 RVA: 0x00020F21 File Offset: 0x0001F121
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002CE8 RID: 11496 RVA: 0x00020F2E File Offset: 0x0001F12E
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06002CE9 RID: 11497 RVA: 0x00020F48 File Offset: 0x0001F148
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x00020F55 File Offset: 0x0001F155
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x00020F62 File Offset: 0x0001F162
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002CEC RID: 11500 RVA: 0x0023DC04 File Offset: 0x0023BE04
		private void InitializeComponent()
		{
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "VassalArmiesPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040037D8 RID: 14296
		public static VassalArmiesPanel2 instance;

		// Token: 0x040037D9 RID: 14297
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040037DA RID: 14298
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040037DB RID: 14299
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040037DC RID: 14300
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037DD RID: 14301
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040037DE RID: 14302
		private CustomSelfDrawPanel.CSDImage trackBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040037DF RID: 14303
		private CustomSelfDrawPanel.CSDLabel atVassalLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E0 RID: 14304
		private CustomSelfDrawPanel.CSDLabel troopsAvailableToSendLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E1 RID: 14305
		private CustomSelfDrawPanel.CSDLabel peasantName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E2 RID: 14306
		private CustomSelfDrawPanel.CSDLabel archerName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E3 RID: 14307
		private CustomSelfDrawPanel.CSDLabel pikemanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E4 RID: 14308
		private CustomSelfDrawPanel.CSDLabel swordsmanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E5 RID: 14309
		private CustomSelfDrawPanel.CSDLabel catapultName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E6 RID: 14310
		private CustomSelfDrawPanel.CSDLabel peasantName2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E7 RID: 14311
		private CustomSelfDrawPanel.CSDLabel archerName2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E8 RID: 14312
		private CustomSelfDrawPanel.CSDLabel pikemanName2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037E9 RID: 14313
		private CustomSelfDrawPanel.CSDLabel swordsmanName2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037EA RID: 14314
		private CustomSelfDrawPanel.CSDLabel catapultName2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037EB RID: 14315
		private CustomSelfDrawPanel.CSDLabel peasantStationedValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037EC RID: 14316
		private CustomSelfDrawPanel.CSDLabel archerStationedValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037ED RID: 14317
		private CustomSelfDrawPanel.CSDLabel pikemanStationedValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037EE RID: 14318
		private CustomSelfDrawPanel.CSDLabel swordsmanStationedValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037EF RID: 14319
		private CustomSelfDrawPanel.CSDLabel catapultStationedValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F0 RID: 14320
		private CustomSelfDrawPanel.CSDLabel stationedTotalLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F1 RID: 14321
		private CustomSelfDrawPanel.CSDLabel maxValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F2 RID: 14322
		private CustomSelfDrawPanel.CSDLabel stationedTotalValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F3 RID: 14323
		private CustomSelfDrawPanel.CSDLabel maxValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F4 RID: 14324
		private CustomSelfDrawPanel.CSDLabel peasantStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F5 RID: 14325
		private CustomSelfDrawPanel.CSDLabel archerStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F6 RID: 14326
		private CustomSelfDrawPanel.CSDLabel pikemanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F7 RID: 14327
		private CustomSelfDrawPanel.CSDLabel swordsmanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F8 RID: 14328
		private CustomSelfDrawPanel.CSDLabel catapultStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037F9 RID: 14329
		private CustomSelfDrawPanel.CSDLabel peasantSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037FA RID: 14330
		private CustomSelfDrawPanel.CSDLabel archerSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037FB RID: 14331
		private CustomSelfDrawPanel.CSDLabel pikemanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037FC RID: 14332
		private CustomSelfDrawPanel.CSDLabel swordsmanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037FD RID: 14333
		private CustomSelfDrawPanel.CSDLabel catapultSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040037FE RID: 14334
		private CustomSelfDrawPanel.CSDTrackBar peasantsTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040037FF RID: 14335
		private CustomSelfDrawPanel.CSDTrackBar archerTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003800 RID: 14336
		private CustomSelfDrawPanel.CSDTrackBar pikemanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003801 RID: 14337
		private CustomSelfDrawPanel.CSDTrackBar swordsmanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003802 RID: 14338
		private CustomSelfDrawPanel.CSDTrackBar catapultTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003803 RID: 14339
		private CustomSelfDrawPanel.CSDButton peasantsEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003804 RID: 14340
		private CustomSelfDrawPanel.CSDButton archerEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003805 RID: 14341
		private CustomSelfDrawPanel.CSDButton pikemanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003806 RID: 14342
		private CustomSelfDrawPanel.CSDButton swordsmanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003807 RID: 14343
		private CustomSelfDrawPanel.CSDButton catapultEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003808 RID: 14344
		private CustomSelfDrawPanel.CSDButton btnSend = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003809 RID: 14345
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400380A RID: 14346
		private int m_vassalVillageID = -1;

		// Token: 0x0400380B RID: 14347
		private int m_playerVillageID = -1;

		// Token: 0x0400380C RID: 14348
		private int m_maxCanSend;

		// Token: 0x0400380D RID: 14349
		private bool allowSliderUpdate = true;

		// Token: 0x0400380E RID: 14350
		private CustomSelfDrawPanel.CSDTrackBar currentTrack;

		// Token: 0x0400380F RID: 14351
		private DockableControl dockableControl;

		// Token: 0x04003810 RID: 14352
		private IContainer components;

		// Token: 0x04003811 RID: 14353
		private Panel focusPanel;
	}
}
