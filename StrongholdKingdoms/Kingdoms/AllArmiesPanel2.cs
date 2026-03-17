using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x020000C0 RID: 192
	public class AllArmiesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000548 RID: 1352 RVA: 0x00064E28 File Offset: 0x00063028
		public AllArmiesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0000AD6E File Offset: 0x00008F6E
		public void preInit()
		{
			AllArmiesPanel2.sortMode = 8;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00065174 File Offset: 0x00063374
		public void init(bool resized, int newMode)
		{
			if (newMode >= 0)
			{
				AllArmiesPanel2.mode = newMode;
			}
			int height = base.Height;
			AllArmiesPanel2.instance = this;
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
			if (AllArmiesPanel2.mode == 0)
			{
				this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Attacks", "Attacks");
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Merchants", "Merchants");
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Monks", "Monks");
			}
			else if (AllArmiesPanel2.mode == 3)
			{
				this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Scouts", "Scouts");
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				this.parishNameLabel.Text = SK.Text("AllArmiesPanel_Reinforcements", "Reinforcements");
			}
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 20, new Point(base.Width - 44, 3));
			this.attackButton.Position = new Point(614, 4);
			if (AllArmiesPanel2.mode == 0)
			{
				this.attackButton.ImageNorm = GFXLibrary.attack_tabs_comp[0];
				this.attackButton.ImageOver = GFXLibrary.attack_tabs_comp[0];
				this.attackButton.ImageClick = GFXLibrary.attack_tabs_comp[0];
				this.attackButton.CustomTooltipID = 0;
				this.attackButton.MoveOnClick = false;
				this.attackButton.Active = false;
			}
			else
			{
				this.attackButton.ImageNorm = GFXLibrary.attack_tabs_comp[10];
				this.attackButton.ImageOver = GFXLibrary.attack_tabs_comp[5];
				this.attackButton.ImageClick = GFXLibrary.attack_tabs_comp[5];
				this.attackButton.MoveOnClick = true;
				this.attackButton.CustomTooltipID = 2900;
				this.attackButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleToAttacks), "AllArmiesPanel2_attack");
				this.attackButton.Active = true;
			}
			this.headerImage.addControl(this.attackButton);
			this.scoutButton.Position = new Point(678, 4);
			if (AllArmiesPanel2.mode == 3)
			{
				this.scoutButton.ImageNorm = GFXLibrary.attack_tabs_comp[1];
				this.scoutButton.ImageOver = GFXLibrary.attack_tabs_comp[1];
				this.scoutButton.ImageClick = GFXLibrary.attack_tabs_comp[1];
				this.scoutButton.CustomTooltipID = 0;
				this.scoutButton.MoveOnClick = false;
				this.scoutButton.Active = false;
			}
			else
			{
				this.scoutButton.ImageNorm = GFXLibrary.attack_tabs_comp[11];
				this.scoutButton.ImageOver = GFXLibrary.attack_tabs_comp[6];
				this.scoutButton.ImageClick = GFXLibrary.attack_tabs_comp[6];
				this.scoutButton.CustomTooltipID = 2901;
				this.scoutButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleToScouts), "AllArmiesPanel2_scouts");
				this.scoutButton.MoveOnClick = true;
				this.scoutButton.Active = true;
			}
			this.headerImage.addControl(this.scoutButton);
			this.reinforcementsButton.Position = new Point(742, 4);
			if (AllArmiesPanel2.mode == 4)
			{
				this.reinforcementsButton.ImageNorm = GFXLibrary.attack_tabs_comp[2];
				this.reinforcementsButton.ImageOver = GFXLibrary.attack_tabs_comp[2];
				this.reinforcementsButton.ImageClick = GFXLibrary.attack_tabs_comp[2];
				this.reinforcementsButton.CustomTooltipID = 0;
				this.reinforcementsButton.MoveOnClick = false;
				this.reinforcementsButton.Active = false;
			}
			else
			{
				this.reinforcementsButton.ImageNorm = GFXLibrary.attack_tabs_comp[12];
				this.reinforcementsButton.ImageOver = GFXLibrary.attack_tabs_comp[7];
				this.reinforcementsButton.ImageClick = GFXLibrary.attack_tabs_comp[7];
				this.reinforcementsButton.CustomTooltipID = 2902;
				this.reinforcementsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleToReinforcements), "AllArmiesPanel2_reinforcements");
				this.reinforcementsButton.MoveOnClick = true;
				this.reinforcementsButton.Active = true;
			}
			this.headerImage.addControl(this.reinforcementsButton);
			this.tradeButton.Position = new Point(806, 4);
			if (AllArmiesPanel2.mode == 1)
			{
				this.tradeButton.ImageNorm = GFXLibrary.attack_tabs_comp[3];
				this.tradeButton.ImageOver = GFXLibrary.attack_tabs_comp[3];
				this.tradeButton.ImageClick = GFXLibrary.attack_tabs_comp[3];
				this.tradeButton.CustomTooltipID = 0;
				this.tradeButton.MoveOnClick = false;
				this.tradeButton.Active = false;
			}
			else
			{
				this.tradeButton.ImageNorm = GFXLibrary.attack_tabs_comp[13];
				this.tradeButton.ImageOver = GFXLibrary.attack_tabs_comp[8];
				this.tradeButton.ImageClick = GFXLibrary.attack_tabs_comp[8];
				this.tradeButton.CustomTooltipID = 2903;
				this.tradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleToMerchants), "AllArmiesPanel2_trade");
				this.tradeButton.MoveOnClick = true;
				this.tradeButton.Active = true;
			}
			this.headerImage.addControl(this.tradeButton);
			this.monkButton.Position = new Point(870, 4);
			if (AllArmiesPanel2.mode == 2)
			{
				this.monkButton.ImageNorm = GFXLibrary.attack_tabs_comp[4];
				this.monkButton.ImageOver = GFXLibrary.attack_tabs_comp[4];
				this.monkButton.ImageClick = GFXLibrary.attack_tabs_comp[4];
				this.monkButton.CustomTooltipID = 0;
				this.monkButton.MoveOnClick = false;
				this.monkButton.Active = false;
			}
			else
			{
				this.monkButton.ImageNorm = GFXLibrary.attack_tabs_comp[14];
				this.monkButton.ImageOver = GFXLibrary.attack_tabs_comp[9];
				this.monkButton.ImageClick = GFXLibrary.attack_tabs_comp[9];
				this.monkButton.CustomTooltipID = 2904;
				this.monkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.toggleToMonks), "AllArmiesPanel2_monks");
				this.monkButton.MoveOnClick = true;
				this.monkButton.Active = true;
			}
			this.headerImage.addControl(this.monkButton);
			this.blockYSize = (height - 40 - 56) / 2;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(228, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(450, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(828, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			if (AllArmiesPanel2.mode == 1)
			{
				this.divider7Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
				this.divider7Image.Position = new Point(570, 0);
				this.headerLabelsImage.addControl(this.divider7Image);
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.divider7Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
				this.divider7Image.Position = new Point(520, 0);
				this.headerLabelsImage.addControl(this.divider7Image);
			}
			if (AllArmiesPanel2.mode == 0)
			{
				this.outGoingAttacksLabel.Text = SK.Text("AllArmiesPanel_Outgoing_Attacks_To", "Outgoing Attacks To");
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				this.outGoingAttacksLabel.Text = SK.Text("AllArmiesPanel_Your_Trades", "Your Merchants To");
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.outGoingAttacksLabel.Text = SK.Text("AllArmiesPanel_Your_Monks", "Your Monks To");
			}
			else if (AllArmiesPanel2.mode == 3)
			{
				this.outGoingAttacksLabel.Text = SK.Text("AllArmiesPanel_Your_Scouts", "Your Scouting of");
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				this.outGoingAttacksLabel.Text = SK.Text("AllArmiesPanel_Your_Reinforcements", "Outgoing Reinforcements");
			}
			this.outGoingAttacksLabel.Color = global::ARGBColors.Black;
			this.outGoingAttacksLabel.Position = new Point(12, -2);
			this.outGoingAttacksLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.outGoingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingAttacksLabel);
			this.outGoingFromLabel.Text = SK.Text("AllArmiesPanel_From", "From");
			this.outGoingFromLabel.Color = global::ARGBColors.Black;
			this.outGoingFromLabel.Position = new Point(233, -2);
			this.outGoingFromLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.outGoingFromLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingFromLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingFromLabel);
			this.outGoingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.outGoingArrivesLabel.Color = global::ARGBColors.Black;
			this.outGoingArrivesLabel.Position = new Point(833, -2);
			this.outGoingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.outGoingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingArrivesLabel);
			if (AllArmiesPanel2.mode == 1)
			{
				this.outGoingCarryingLabel.Text = SK.Text("AllArmiesPanel_Trader_Carrying", "Carrying");
				this.outGoingCarryingLabel.Color = global::ARGBColors.Black;
				this.outGoingCarryingLabel.Position = new Point(455, -2);
				this.outGoingCarryingLabel.Size = new Size(110, this.headerLabelsImage.Height);
				this.outGoingCarryingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.outGoingCarryingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.headerLabelsImage.addControl(this.outGoingCarryingLabel);
				this.outGoingStatusLabel.Text = SK.Text("AllArmiesPanel_Trader_Status", "Status");
				this.outGoingStatusLabel.Color = global::ARGBColors.Black;
				this.outGoingStatusLabel.Position = new Point(575, -2);
				this.outGoingStatusLabel.Size = new Size(250, this.headerLabelsImage.Height);
				this.outGoingStatusLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.outGoingStatusLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.headerLabelsImage.addControl(this.outGoingStatusLabel);
			}
			if (AllArmiesPanel2.mode == 2)
			{
				this.outGoingStatusLabel.Text = SK.Text("AllArmiesPanel_Monk_Command", "Command");
				this.outGoingStatusLabel.Color = global::ARGBColors.Black;
				this.outGoingStatusLabel.Position = new Point(525, -2);
				this.outGoingStatusLabel.Size = new Size(250, this.headerLabelsImage.Height);
				this.outGoingStatusLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.outGoingStatusLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.headerLabelsImage.addControl(this.outGoingStatusLabel);
			}
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage2.Position = new Point(25, this.blockYSize + 5);
			this.backgroundImage.addControl(this.headerLabelsImage2);
			this.headerLabelsImage2.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider4Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider4Image.Position = new Point(228, 0);
			this.headerLabelsImage2.addControl(this.divider4Image);
			this.divider5Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider5Image.Position = new Point(450, 0);
			this.headerLabelsImage2.addControl(this.divider5Image);
			this.divider6Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider6Image.Position = new Point(828, 0);
			this.headerLabelsImage2.addControl(this.divider6Image);
			if (AllArmiesPanel2.mode == 0)
			{
				this.incomingAttacksLabel.Text = SK.Text("AllArmiesPanel_Incoming_Attacks_From", "Incoming Attacks From");
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				this.incomingAttacksLabel.Text = SK.Text("AllArmiesPanel_Trades_from", "Incoming Merchants From");
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.incomingAttacksLabel.Text = SK.Text("AllArmiesPanel_Incoming_Monks", "Incoming Monks From");
			}
			else if (AllArmiesPanel2.mode == 3)
			{
				this.incomingAttacksLabel.Text = SK.Text("AllArmiesPanel_Incoming_Scouts", "Incoming Scouts From");
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				this.incomingAttacksLabel.Text = SK.Text("AllArmiesPanel_Incoming_Reinforcements", "Incoming Reinforcements From");
			}
			this.incomingAttacksLabel.Color = global::ARGBColors.Black;
			this.incomingAttacksLabel.Position = new Point(12, -2);
			this.incomingAttacksLabel.Size = new Size(224, this.headerLabelsImage.Height);
			this.incomingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingAttacksLabel);
			if (AllArmiesPanel2.mode == 0)
			{
				this.incomingAttackingLabel.Text = SK.Text("GENERIC_Attacking", "Attacking");
			}
			else
			{
				this.incomingAttackingLabel.Text = SK.Text("GENERIC_To", "To");
			}
			this.incomingAttackingLabel.Color = global::ARGBColors.Black;
			this.incomingAttackingLabel.Position = new Point(233, -2);
			this.incomingAttackingLabel.Size = new Size(224, this.headerLabelsImage.Height);
			this.incomingAttackingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingAttackingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingAttackingLabel);
			this.incomingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.incomingArrivesLabel.Color = global::ARGBColors.Black;
			this.incomingArrivesLabel.Position = new Point(833, -2);
			this.incomingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.incomingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingArrivesLabel);
			this.outgoingScrollArea.Position = new Point(25, 40);
			this.outgoingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.outgoingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.outgoingScrollArea);
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollBar.Position = new Point(943, 40);
			this.outgoingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.outgoingScrollBar);
			this.outgoingScrollBar.Value = 0;
			this.outgoingScrollBar.Max = 100;
			this.outgoingScrollBar.NumVisibleLines = 25;
			this.outgoingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.outgoingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.incomingScrollArea.Position = new Point(25, 35 + this.blockYSize + 5);
			this.incomingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.incomingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.incomingScrollArea);
			int value2 = this.incomingScrollBar.Value;
			this.incomingScrollBar.Position = new Point(943, 35 + this.blockYSize + 5);
			this.incomingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.incomingScrollBar);
			this.incomingScrollBar.Value = 0;
			this.incomingScrollBar.Max = 100;
			this.incomingScrollBar.NumVisibleLines = 25;
			this.incomingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.incomingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.incomingWallScrollBarMoved));
			this.smallPeasantImage2.Visible = false;
			if (AllArmiesPanel2.mode == 0)
			{
				this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
				this.smallPeasantImage.Position = new Point(473, -10);
				this.smallPeasantImage.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Width - 60, this.smallPeasantImage.Height);
				this.headerLabelsImage.addControl(this.smallPeasantImage);
				this.smallPeasantImage2.Image = GFXLibrary.barracks_screen_bottom_units;
				this.smallPeasantImage2.Position = new Point(348, -10);
				this.smallPeasantImage2.ClipRect = new Rectangle(this.smallPeasantImage2.Width - 60, 0, 60, this.smallPeasantImage2.Height);
				this.headerLabelsImage.addControl(this.smallPeasantImage2);
				this.smallPeasantImage2.Visible = true;
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
				this.smallPeasantImage.Position = new Point(503, -10);
				this.smallPeasantImage.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Width - 60, this.smallPeasantImage.Height);
				this.headerLabelsImage.addControl(this.smallPeasantImage);
			}
			else if (AllArmiesPanel2.mode == 3)
			{
				this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
				this.smallPeasantImage.Position = new Point(503 - (this.smallPeasantImage.Width - 60) - 8, -10);
				this.smallPeasantImage.ClipRect = new Rectangle(this.smallPeasantImage.Width - 60, 0, 60, this.smallPeasantImage.Height);
				this.headerLabelsImage.addControl(this.smallPeasantImage);
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.smallPeasantImage.Image = GFXLibrary.monk_icon;
				this.smallPeasantImage.Position = new Point(468, -10);
				this.headerLabelsImage.addControl(this.smallPeasantImage);
			}
			if (AllArmiesPanel2.mode == 0 || AllArmiesPanel2.mode == 3)
			{
				SparseArray armyArray = GameEngine.Instance.World.getArmyArray();
				this.armyList.Clear();
				foreach (object obj in armyArray)
				{
					WorldMap.LocalArmyData item = (WorldMap.LocalArmyData)obj;
					this.armyList.Add(item);
				}
				this.armyList.Sort(this.armyComparer);
				if (AllArmiesPanel2.mode == 0)
				{
					this.addArmies();
				}
				else if (AllArmiesPanel2.mode == 3)
				{
					this.addScouts();
				}
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				SparseArray traderArray = GameEngine.Instance.World.getTraderArray();
				this.merchantList.Clear();
				foreach (object obj2 in traderArray)
				{
					WorldMap.LocalTrader item2 = (WorldMap.LocalTrader)obj2;
					this.merchantList.Add(item2);
				}
				this.merchantList.Sort(this.merchantComparer);
				this.addMerchants();
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				SparseArray peopleArray = GameEngine.Instance.World.getPeopleArray();
				this.monkList.Clear();
				foreach (object obj3 in peopleArray)
				{
					WorldMap.LocalPerson item3 = (WorldMap.LocalPerson)obj3;
					this.monkList.Add(item3);
				}
				this.monkList.Sort(this.monkComparer);
				this.addMonks();
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				SparseArray reinforcementsArray = GameEngine.Instance.World.getReinforcementsArray();
				this.reinforcementList.Clear();
				foreach (object obj4 in reinforcementsArray)
				{
					WorldMap.LocalArmyData item4 = (WorldMap.LocalArmyData)obj4;
					this.reinforcementList.Add(item4);
				}
				this.reinforcementList.Sort(this.armyComparer);
				this.addReinforcements();
			}
			if (resized)
			{
				this.outgoingScrollBar.Value = value;
				this.incomingScrollBar.Value = value2;
			}
			if (AllArmiesPanel2.mode == 0)
			{
				this.diplomacyHeaderLabel.Text = SK.Text("AllArmiesPanel_Diplomacy", "Diplomacy");
				this.diplomacyHeaderLabel.Color = global::ARGBColors.White;
				this.diplomacyHeaderLabel.DropShadowColor = global::ARGBColors.Black;
				this.diplomacyHeaderLabel.Position = new Point(20, height - 40 - 40 - 2);
				this.diplomacyHeaderLabel.Size = new Size(100, 30);
				this.diplomacyHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.diplomacyHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.diplomacyHeaderLabel);
				this.diplomacyTextLabel.Text = SK.Text("AllArmiesPanel_Avoiding_Attacks", "Chance of avoiding an Incoming AI / Enemy Attack") + " : ";
				this.diplomacyTextLabel.Color = global::ARGBColors.White;
				this.diplomacyTextLabel.DropShadowColor = global::ARGBColors.Black;
				this.diplomacyTextLabel.Position = new Point(125, height - 40 - 40);
				this.diplomacyTextLabel.Size = new Size(630, 30);
				this.diplomacyTextLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.diplomacyTextLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.backgroundImage.addControl(this.diplomacyTextLabel);
				this.btnDiplomacy.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
				this.btnDiplomacy.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
				this.btnDiplomacy.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
				this.btnDiplomacy.Position = new Point(base.Width - 230, height - 40 - 40 - 4);
				this.btnDiplomacy.Text.Text = SK.Text("AllArmiesPanel_Turn_Off_Diplomacy", "Turn Off Diplomacy");
				this.btnDiplomacy.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnDiplomacy.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnDiplomacy.TextYOffset = -3;
				this.btnDiplomacy.Text.Color = global::ARGBColors.Black;
				this.btnDiplomacy.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.diplomacyClick), "AllArmiesPanel2_diplomacy");
				this.backgroundImage.addControl(this.btnDiplomacy);
				this.updateDiplomacyStatus();
			}
			if (AllArmiesPanel2.mode == 3)
			{
				if ((Math.Abs(AllArmiesPanel2.sortMode) >= 3 && Math.Abs(AllArmiesPanel2.sortMode) <= 7) || Math.Abs(AllArmiesPanel2.sortMode) > 9)
				{
					AllArmiesPanel2.sortMode = 0;
				}
			}
			else if (AllArmiesPanel2.mode == 0 || AllArmiesPanel2.mode == 4)
			{
				if (Math.Abs(AllArmiesPanel2.sortMode) > 8 && Math.Abs(AllArmiesPanel2.sortMode) != 20)
				{
					AllArmiesPanel2.sortMode = 0;
				}
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				if ((Math.Abs(AllArmiesPanel2.sortMode) >= 3 && Math.Abs(AllArmiesPanel2.sortMode) <= 7) || Math.Abs(AllArmiesPanel2.sortMode) == 9 || Math.Abs(AllArmiesPanel2.sortMode) >= 12)
				{
					AllArmiesPanel2.sortMode = 0;
				}
			}
			else if (AllArmiesPanel2.mode == 2 && ((Math.Abs(AllArmiesPanel2.sortMode) >= 3 && Math.Abs(AllArmiesPanel2.sortMode) <= 7) || (Math.Abs(AllArmiesPanel2.sortMode) >= 9 && Math.Abs(AllArmiesPanel2.sortMode) < 12)))
			{
				AllArmiesPanel2.sortMode = 0;
			}
			this.sortArea1.Position = new Point(7, 0);
			this.sortArea1.Size = new Size(214, 24);
			this.sortArea1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			int num = this.sortArea1.CustomTooltipData = (this.sortArea1.Data = 1);
			this.sortArea1.CustomTooltipID = 2905;
			this.headerLabelsImage.addControl(this.sortArea1);
			this.sortArea1a.Position = new Point(7, 0);
			this.sortArea1a.Size = new Size(214, 24);
			this.sortArea1a.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			num = (this.sortArea1a.CustomTooltipData = (this.sortArea1a.Data = 2));
			this.sortArea1a.CustomTooltipID = 2905;
			this.headerLabelsImage2.addControl(this.sortArea1a);
			this.sortArea2.Position = new Point(229, 0);
			this.sortArea2.Size = new Size(214, 24);
			this.sortArea2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			num = (this.sortArea2.CustomTooltipData = (this.sortArea2.Data = 2));
			this.sortArea2.CustomTooltipID = 2905;
			this.headerLabelsImage.addControl(this.sortArea2);
			this.sortArea2a.Position = new Point(229, 0);
			this.sortArea2a.Size = new Size(214, 24);
			this.sortArea2a.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			num = (this.sortArea2a.CustomTooltipData = (this.sortArea2a.Data = 1));
			this.sortArea2a.CustomTooltipID = 2905;
			this.headerLabelsImage2.addControl(this.sortArea2a);
			this.sortArea8.Position = new Point(828, 0);
			this.sortArea8.Size = new Size(100, 24);
			this.sortArea8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			num = (this.sortArea8.CustomTooltipData = (this.sortArea8.Data = 8));
			this.sortArea8.CustomTooltipID = 2905;
			this.headerLabelsImage.addControl(this.sortArea8);
			this.sortArea8a.Position = new Point(828, 0);
			this.sortArea8a.Size = new Size(100, 24);
			this.sortArea8a.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
			num = (this.sortArea8a.CustomTooltipData = (this.sortArea8a.Data = 8));
			this.sortArea8a.CustomTooltipID = 2905;
			this.headerLabelsImage2.addControl(this.sortArea8a);
			if (AllArmiesPanel2.mode == 3)
			{
				this.sortArea3.Position = new Point(477, 0);
				this.sortArea3.Size = new Size(60, 24);
				this.sortArea3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea3.CustomTooltipData = (this.sortArea3.Data = 9));
				this.sortArea3.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea3);
			}
			else if (AllArmiesPanel2.mode == 0)
			{
				this.sortArea3.Position = new Point(447, 0);
				this.sortArea3.Size = new Size(60, 24);
				this.sortArea3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea3.CustomTooltipData = (this.sortArea3.Data = 3));
				this.sortArea3.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea3);
				this.sortArea4.Position = new Point(513, 0);
				this.sortArea4.Size = new Size(60, 24);
				this.sortArea4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea4.CustomTooltipData = (this.sortArea4.Data = 4));
				this.sortArea4.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea4);
				this.sortArea5.Position = new Point(570, 0);
				this.sortArea5.Size = new Size(60, 24);
				this.sortArea5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea5.CustomTooltipData = (this.sortArea5.Data = 5));
				this.sortArea5.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea5);
				this.sortArea6.Position = new Point(631, 0);
				this.sortArea6.Size = new Size(60, 24);
				this.sortArea6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea6.CustomTooltipData = (this.sortArea6.Data = 6));
				this.sortArea6.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea6);
				this.sortArea7.Position = new Point(685, 0);
				this.sortArea7.Size = new Size(60, 24);
				this.sortArea7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea7.CustomTooltipData = (this.sortArea7.Data = 7));
				this.sortArea7.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea7);
				this.sortArea9.Position = new Point(739, 0);
				this.sortArea9.Size = new Size(60, 24);
				this.sortArea9.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea9.CustomTooltipData = (this.sortArea9.Data = 20));
				this.sortArea9.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea9);
			}
			else if (AllArmiesPanel2.mode == 4)
			{
				this.sortArea3.Position = new Point(477, 0);
				this.sortArea3.Size = new Size(60, 24);
				this.sortArea3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea3.CustomTooltipData = (this.sortArea3.Data = 3));
				this.sortArea3.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea3);
				this.sortArea4.Position = new Point(543, 0);
				this.sortArea4.Size = new Size(60, 24);
				this.sortArea4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea4.CustomTooltipData = (this.sortArea4.Data = 4));
				this.sortArea4.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea4);
				this.sortArea5.Position = new Point(600, 0);
				this.sortArea5.Size = new Size(60, 24);
				this.sortArea5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea5.CustomTooltipData = (this.sortArea5.Data = 5));
				this.sortArea5.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea5);
				this.sortArea6.Position = new Point(661, 0);
				this.sortArea6.Size = new Size(60, 24);
				this.sortArea6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea6.CustomTooltipData = (this.sortArea6.Data = 6));
				this.sortArea6.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea6);
				this.sortArea7.Position = new Point(715, 0);
				this.sortArea7.Size = new Size(60, 24);
				this.sortArea7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea7.CustomTooltipData = (this.sortArea7.Data = 7));
				this.sortArea7.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea7);
			}
			else if (AllArmiesPanel2.mode == 1)
			{
				this.sortArea3.Position = new Point(449, 0);
				this.sortArea3.Size = new Size(110, 24);
				this.sortArea3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea3.CustomTooltipData = (this.sortArea3.Data = 10));
				this.sortArea3.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea3);
				this.sortArea4.Position = new Point(569, 0);
				this.sortArea4.Size = new Size(250, 24);
				this.sortArea4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea4.CustomTooltipData = (this.sortArea4.Data = 11));
				this.sortArea4.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea4);
			}
			else if (AllArmiesPanel2.mode == 2)
			{
				this.sortArea3.Position = new Point(457, 0);
				this.sortArea3.Size = new Size(50, 24);
				this.sortArea3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea3.CustomTooltipData = (this.sortArea3.Data = 12));
				this.sortArea3.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea3);
				this.sortArea4.Position = new Point(522, 0);
				this.sortArea4.Size = new Size(300, 24);
				this.sortArea4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortClicked));
				num = (this.sortArea4.CustomTooltipData = (this.sortArea4.Data = 13));
				this.sortArea4.CustomTooltipID = 2905;
				this.headerLabelsImage.addControl(this.sortArea4);
			}
			AllArmiesPanel2.TradersUpdated = false;
			AllArmiesPanel2.MonksUpdated = false;
			base.Invalidate();
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x000679E4 File Offset: 0x00065BE4
		public void update()
		{
			bool flag = false;
			double localTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (AllArmiesPanel2.ArmyLine armyLine in this.armyLineList)
			{
				if (!armyLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.ArmyLine armyLine2 in this.armyLineList2)
			{
				if (!armyLine2.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.MerchantLine merchantLine in this.merchantLineList)
			{
				if (!merchantLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.MerchantLine merchantLine2 in this.merchantLineList2)
			{
				if (!merchantLine2.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.MonkLine monkLine in this.monkLineList)
			{
				if (!monkLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.MonkLine monkLine2 in this.monkLineList2)
			{
				if (!monkLine2.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.ScoutLine scoutLine in this.scoutLineList)
			{
				if (!scoutLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.ScoutLine scoutLine2 in this.scoutLineList2)
			{
				if (!scoutLine2.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.ReinforcementLine reinforcementLine in this.reinforcementLineList)
			{
				if (!reinforcementLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (AllArmiesPanel2.ReinforcementLine reinforcementLine2 in this.reinforcementLineList2)
			{
				if (!reinforcementLine2.update(localTime))
				{
					flag = true;
				}
			}
			if (flag || (InterfaceMgr.Instance.getMainTabBar().isArmiesFlashing() && AllArmiesPanel2.mode == 0) || (AllArmiesPanel2.mode == 1 && AllArmiesPanel2.TradersUpdated) || (AllArmiesPanel2.mode == 2 && AllArmiesPanel2.MonksUpdated))
			{
				DateTime now = DateTime.Now;
				if ((now - this.lastfullUpdate).TotalSeconds > 1.5)
				{
					this.lastfullUpdate = now;
					long highestArmyID = -1L;
					int numAttacks = GameEngine.Instance.World.countIncomingAttacks(ref highestArmyID);
					InterfaceMgr.Instance.getMainTabBar().incomingAttacks(numAttacks, highestArmyID);
					this.init(true, AllArmiesPanel2.mode);
				}
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00067D80 File Offset: 0x00065F80
		public void sortClicked()
		{
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			if (clickedControl != null)
			{
				int data = clickedControl.Data;
				if (data == AllArmiesPanel2.sortMode)
				{
					AllArmiesPanel2.sortMode = -data;
				}
				else
				{
					AllArmiesPanel2.sortMode = data;
				}
				this.init(false, AllArmiesPanel2.mode);
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00067DC4 File Offset: 0x00065FC4
		public void updateDiplomacyStatus()
		{
			if (RemoteServices.Instance.ReportFilters.diplomacyActive)
			{
				this.btnDiplomacy.Text.Text = SK.Text("AllArmiesPanel_Turn_Off_Diplomacy", "Turn Off Diplomacy");
				int num = CardTypes.cards_diplomacyExtraPercent(GameEngine.Instance.cardsManager.UserCardData);
				num += ResearchData.diplomacyPercent[(int)GameEngine.Instance.World.UserResearchData.Research_Diplomacy];
				this.diplomacyTextLabel.Text = SK.Text("AllArmiesPanel_Avoiding_Attacks", "Chance of avoiding an Incoming AI / Enemy Attack") + " : " + num.ToString() + "%";
				return;
			}
			this.btnDiplomacy.Text.Text = SK.Text("AllArmiesPanel_Turn_On_Diplomacy", "Turn On Diplomacy");
			this.diplomacyTextLabel.Text = SK.Text("AllArmiesPanel_Avoiding_Attacks", "Chance of avoiding an Incoming AI / Enemy Attack") + " : 0% (" + SK.Text("AllArmiesPanel_Diplomacy_Is_Off", "Diplomacy is Off") + ")";
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0000AD76 File Offset: 0x00008F76
		public void toggleToAttacks()
		{
			if (this.attackButton.Active)
			{
				this.init(false, 0);
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0000AD8D File Offset: 0x00008F8D
		public void toggleToScouts()
		{
			if (this.scoutButton.Active)
			{
				this.init(false, 3);
			}
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		public void toggleToReinforcements()
		{
			if (this.reinforcementsButton.Active)
			{
				this.init(false, 4);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000ADBB File Offset: 0x00008FBB
		public void toggleToMerchants()
		{
			if (this.tradeButton.Active)
			{
				this.init(false, 1);
			}
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0000ADD2 File Offset: 0x00008FD2
		public void toggleToMonks()
		{
			if (this.monkButton.Active)
			{
				this.init(false, 2);
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00067EC0 File Offset: 0x000660C0
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 40 - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00067F58 File Offset: 0x00066158
		private void incomingWallScrollBarMoved()
		{
			int value = this.incomingScrollBar.Value;
			this.incomingScrollArea.Position = new Point(this.incomingScrollArea.X, 35 + this.blockYSize + 5 - value);
			this.incomingScrollArea.ClipRect = new Rectangle(this.incomingScrollArea.ClipRect.X, value, this.incomingScrollArea.ClipRect.Width, this.incomingScrollArea.ClipRect.Height);
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x00067FFC File Offset: 0x000661FC
		public void addArmies()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.armyLineList.Clear();
			this.armyLineList2.Clear();
			this.merchantLineList.Clear();
			this.merchantLineList2.Clear();
			this.monkLineList.Clear();
			this.monkLineList2.Clear();
			this.scoutLineList.Clear();
			this.scoutLineList2.Clear();
			this.reinforcementLineList.Clear();
			this.reinforcementLineList2.Clear();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalArmyData localArmyData in this.armyList)
			{
				if (localArmyData.numScouts <= 0)
				{
					if ((GameEngine.Instance.World.isUserVillage(localArmyData.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(localArmyData.homeVillageID)) && localArmyData.attackType != 13)
					{
						AllArmiesPanel2.ArmyLine armyLine = new AllArmiesPanel2.ArmyLine();
						if (num != 0)
						{
							num += 5;
						}
						armyLine.Position = new Point(0, num);
						bool showButton = localArmyData.lootType < 0;
						if (localArmyData.localEndTime == 0.0)
						{
							showButton = false;
						}
						else
						{
							double localEndTime = localArmyData.localEndTime;
							if (localArmyData.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) < num6)
							{
								showButton = false;
							}
						}
						armyLine.initSent(num4, localArmyData.targetVillageID, localArmyData.travelFromVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, localArmyData.numScouts, localArmyData.serverEndTime, localArmyData.armyID, showButton, this, localArmyData.lootType >= 0, localArmyData.attackType, localArmyData.numCaptains);
						this.outgoingScrollArea.addControl(armyLine);
						num += armyLine.Height;
						this.armyLineList.Add(armyLine);
						num4++;
					}
					else if (GameEngine.Instance.World.isUserVillage(localArmyData.targetVillageID) && localArmyData.lootType < 0)
					{
						AllArmiesPanel2.ArmyLine armyLine2 = new AllArmiesPanel2.ArmyLine();
						if (num2 != 0)
						{
							num2 += 5;
						}
						if (localArmyData.armyID > num3)
						{
							num3 = localArmyData.armyID;
						}
						armyLine2.Position = new Point(0, num2);
						bool tutorial = false;
						if (localArmyData.attackType == 13)
						{
							tutorial = true;
						}
						if (DX.ControlForm.IsExclusive)
						{
							armyLine2.initSent(num5, localArmyData.travelFromVillageID, localArmyData.targetVillageID, 0, 0, 0, 0, 0, 0, localArmyData.serverEndTime, localArmyData.armyID, false, this, false, localArmyData.attackType, localArmyData.numCaptains);
						}
						else
						{
							armyLine2.initIncoming(num5, localArmyData.travelFromVillageID, localArmyData.targetVillageID, 0, 0, 0, 0, 0, 0, localArmyData.serverEndTime, localArmyData.armyID, false, this, false, tutorial, localArmyData.attackType, localArmyData.numCaptains);
						}
						this.incomingScrollArea.addControl(armyLine2);
						num2 += armyLine2.Height;
						this.armyLineList2.Add(armyLine2);
						num5++;
					}
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000684B4 File Offset: 0x000666B4
		public void addScouts()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.armyLineList.Clear();
			this.armyLineList2.Clear();
			this.merchantLineList.Clear();
			this.merchantLineList2.Clear();
			this.monkLineList.Clear();
			this.monkLineList2.Clear();
			this.scoutLineList.Clear();
			this.scoutLineList2.Clear();
			this.reinforcementLineList.Clear();
			this.reinforcementLineList2.Clear();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalArmyData localArmyData in this.armyList)
			{
				if (localArmyData.numScouts != 0)
				{
					if (GameEngine.Instance.World.isUserVillage(localArmyData.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(localArmyData.homeVillageID))
					{
						AllArmiesPanel2.ScoutLine scoutLine = new AllArmiesPanel2.ScoutLine();
						if (num != 0)
						{
							num += 5;
						}
						scoutLine.Position = new Point(0, num);
						bool showButton = localArmyData.lootType < 0;
						if (localArmyData.localEndTime == 0.0)
						{
							showButton = false;
						}
						else
						{
							double localEndTime = localArmyData.localEndTime;
							if (localArmyData.localStartTime + (double)(GameEngine.Instance.LocalWorldData.AttackCancelDuration * 60) < num6)
							{
								showButton = false;
							}
						}
						scoutLine.initSent(num4, localArmyData.targetVillageID, localArmyData.travelFromVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, localArmyData.numScouts, localArmyData.serverEndTime, localArmyData.armyID, showButton, this, localArmyData.lootType >= 0);
						this.outgoingScrollArea.addControl(scoutLine);
						num += scoutLine.Height;
						this.scoutLineList.Add(scoutLine);
						num4++;
					}
					else if (GameEngine.Instance.World.isUserVillage(localArmyData.targetVillageID) && localArmyData.lootType < 0)
					{
						AllArmiesPanel2.ScoutLine scoutLine2 = new AllArmiesPanel2.ScoutLine();
						if (num2 != 0)
						{
							num2 += 5;
						}
						if (localArmyData.armyID > num3)
						{
							num3 = localArmyData.armyID;
						}
						scoutLine2.Position = new Point(0, num2);
						bool tutorial = false;
						scoutLine2.initIncoming(num5, localArmyData.travelFromVillageID, localArmyData.targetVillageID, 0, 0, 0, 0, 0, 0, localArmyData.serverEndTime, localArmyData.armyID, false, this, false, tutorial, localArmyData.attackType);
						this.incomingScrollArea.addControl(scoutLine2);
						num2 += scoutLine2.Height;
						this.scoutLineList2.Add(scoutLine2);
						num5++;
					}
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x000688F0 File Offset: 0x00066AF0
		public void addReinforcements()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.armyLineList.Clear();
			this.armyLineList2.Clear();
			this.merchantLineList.Clear();
			this.merchantLineList2.Clear();
			this.monkLineList.Clear();
			this.monkLineList2.Clear();
			this.scoutLineList.Clear();
			this.scoutLineList2.Clear();
			this.reinforcementLineList.Clear();
			this.reinforcementLineList2.Clear();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalArmyData localArmyData in this.reinforcementList)
			{
				if (localArmyData.attackType != 21 || !(localArmyData.serverEndTime < VillageMap.getCurrentServerTime()))
				{
					if (GameEngine.Instance.World.isUserVillage(localArmyData.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(localArmyData.homeVillageID))
					{
						AllArmiesPanel2.ReinforcementLine reinforcementLine = new AllArmiesPanel2.ReinforcementLine();
						if (num != 0)
						{
							num += 5;
						}
						reinforcementLine.Position = new Point(0, num);
						reinforcementLine.initSent(num4, localArmyData.targetVillageID, localArmyData.travelFromVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, localArmyData.numScouts, localArmyData.serverEndTime, localArmyData.armyID, localArmyData.attackType == 20, this, localArmyData.attackType == 21);
						this.outgoingScrollArea.addControl(reinforcementLine);
						num += reinforcementLine.Height;
						this.reinforcementLineList.Add(reinforcementLine);
						num4++;
					}
					else if (GameEngine.Instance.World.isUserVillage(localArmyData.targetVillageID))
					{
						AllArmiesPanel2.ReinforcementLine reinforcementLine2 = new AllArmiesPanel2.ReinforcementLine();
						if (num2 != 0)
						{
							num2 += 5;
						}
						reinforcementLine2.Position = new Point(0, num2);
						bool tutorial = false;
						reinforcementLine2.initIncoming(num5, localArmyData.travelFromVillageID, localArmyData.targetVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, localArmyData.numScouts, localArmyData.serverEndTime, localArmyData.armyID, false, this, localArmyData.attackType == 21, tutorial, 0);
						this.incomingScrollArea.addControl(reinforcementLine2);
						num2 += reinforcementLine2.Height;
						this.reinforcementLineList2.Add(reinforcementLine2);
						num5++;
					}
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00068D04 File Offset: 0x00066F04
		public void addMerchants()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.armyLineList.Clear();
			this.armyLineList2.Clear();
			this.merchantLineList.Clear();
			this.merchantLineList2.Clear();
			this.monkLineList.Clear();
			this.monkLineList2.Clear();
			this.scoutLineList.Clear();
			this.scoutLineList2.Clear();
			this.reinforcementLineList.Clear();
			this.reinforcementLineList2.Clear();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalTrader localTrader in this.merchantList)
			{
				if (localTrader.trader.traderState != 0)
				{
					if (GameEngine.Instance.World.isUserVillage(localTrader.trader.homeVillageID) && ((localTrader.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 0.0 || localTrader.trader.traderState == 0 || localTrader.trader.traderState == 1 || localTrader.trader.traderState == 3 || localTrader.trader.traderState == 5))
					{
						AllArmiesPanel2.MerchantLine merchantLine = new AllArmiesPanel2.MerchantLine();
						if (num != 0)
						{
							num += 5;
						}
						merchantLine.Position = new Point(0, num);
						merchantLine.initSent(num4, localTrader.trader.targetVillageID, localTrader.trader.homeVillageID, localTrader.trader.numTraders, localTrader.serverEndTime, localTrader.traderID, this, localTrader.trader.traderState != 0 && localTrader.trader.traderState != 1 && localTrader.trader.traderState != 3 && localTrader.trader.traderState != 5, localTrader.trader.traderState, localTrader.trader.resource, localTrader.trader.amount);
						this.outgoingScrollArea.addControl(merchantLine);
						num += merchantLine.Height;
						this.merchantLineList.Add(merchantLine);
						num4++;
					}
					if (GameEngine.Instance.World.isUserVillage(localTrader.trader.targetVillageID) && !GameEngine.Instance.World.isCapital(localTrader.trader.targetVillageID) && (localTrader.trader.traderState == 0 || localTrader.trader.traderState == 1 || localTrader.trader.traderState == 3 || localTrader.trader.traderState == 5) && (localTrader.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 0.0)
					{
						AllArmiesPanel2.MerchantLine merchantLine2 = new AllArmiesPanel2.MerchantLine();
						if (num2 != 0)
						{
							num2 += 5;
						}
						merchantLine2.Position = new Point(0, num2);
						merchantLine2.initIncoming(num5, localTrader.trader.homeVillageID, localTrader.trader.targetVillageID, 0, localTrader.serverEndTime, localTrader.traderID, this, false);
						this.incomingScrollArea.addControl(merchantLine2);
						num2 += merchantLine2.Height;
						this.merchantLineList2.Add(merchantLine2);
						num5++;
					}
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000691E8 File Offset: 0x000673E8
		public void addMonks()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.armyLineList.Clear();
			this.armyLineList2.Clear();
			this.merchantLineList.Clear();
			this.merchantLineList2.Clear();
			this.monkLineList.Clear();
			this.monkLineList2.Clear();
			this.scoutLineList.Clear();
			this.scoutLineList2.Clear();
			this.reinforcementLineList.Clear();
			this.reinforcementLineList2.Clear();
			long num3 = -1L;
			int num4 = 0;
			int num5 = 0;
			double num6 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalPerson localPerson in this.monkList)
			{
				if (localPerson.person.personType == 4 && localPerson.person.state > 0 && localPerson.parentPerson < 0L)
				{
					if (GameEngine.Instance.World.isUserVillage(localPerson.person.homeVillageID) && (localPerson.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 1.0)
					{
						AllArmiesPanel2.MonkLine monkLine = new AllArmiesPanel2.MonkLine();
						if (num != 0)
						{
							num += 5;
						}
						monkLine.Position = new Point(0, num);
						monkLine.initSent(num4, localPerson.person.targetVillageID, localPerson.person.homeVillageID, localPerson.childrenCount + 1, localPerson.serverEndTime, localPerson.personID, this, localPerson.person.command);
						this.outgoingScrollArea.addControl(monkLine);
						num += monkLine.Height;
						this.monkLineList.Add(monkLine);
						num4++;
					}
					if (GameEngine.Instance.World.isUserVillage(localPerson.person.targetVillageID) && !GameEngine.Instance.World.isCapital(localPerson.person.targetVillageID) && (localPerson.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 1.0)
					{
						AllArmiesPanel2.MonkLine monkLine2 = new AllArmiesPanel2.MonkLine();
						if (num2 != 0)
						{
							num2 += 5;
						}
						monkLine2.Position = new Point(0, num2);
						if (DX.ControlForm.IsExclusive)
						{
							monkLine2.initSent(num4, localPerson.person.homeVillageID, localPerson.person.targetVillageID, localPerson.childrenCount + 1, localPerson.serverEndTime, localPerson.personID, this, localPerson.person.command);
						}
						else
						{
							monkLine2.initIncoming(num5, localPerson.person.homeVillageID, localPerson.person.targetVillageID, 0, localPerson.serverEndTime, localPerson.personID, this);
						}
						this.incomingScrollArea.addControl(monkLine2);
						num2 += monkLine2.Height;
						this.monkLineList2.Add(monkLine2);
						num5++;
					}
				}
			}
			if (num3 > GameEngine.Instance.World.HighestArmyIDSeen)
			{
				GameEngine.Instance.World.HighestArmyIDSeen = num3;
				RemoteServices.Instance.SetHighestArmySeen(num3);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.incomingScrollArea.Size = new Size(this.incomingScrollArea.Width, num2);
			if (num2 < this.incomingScrollBar.Height)
			{
				this.incomingScrollBar.Visible = false;
			}
			else
			{
				this.incomingScrollBar.Visible = true;
				this.incomingScrollBar.NumVisibleLines = this.incomingScrollBar.Height;
				this.incomingScrollBar.Max = num2 - this.incomingScrollBar.Height;
			}
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0006966C File Offset: 0x0006786C
		private void diplomacyClick()
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				bool flag = !RemoteServices.Instance.ReportFilters.diplomacyActive;
				this.btnDiplomacy.Enabled = false;
				RemoteServices.Instance.ReportFilters.diplomacyActive = flag;
				RemoteServices.Instance.set_UpdateDiplomacyStatus_UserCallBack(new RemoteServices.UpdateDiplomacyStatus_UserCallBack(this.UpdateDiplomacyStatusCallBack));
				RemoteServices.Instance.UpdateDiplomacyStatus(flag);
				this.updateDiplomacyStatus();
			}
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000ADF5 File Offset: 0x00008FF5
		public void UpdateDiplomacyStatusCallBack(UpdateDiplomacyStatus_ReturnType returnData)
		{
			this.btnDiplomacy.Enabled = true;
			bool success = returnData.Success;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000AE0A File Offset: 0x0000900A
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0000AE1A File Offset: 0x0000901A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000AE2A File Offset: 0x0000902A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000AE3C File Offset: 0x0000903C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0000AE49 File Offset: 0x00009049
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000AE63 File Offset: 0x00009063
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0000AE70 File Offset: 0x00009070
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0000AE7D File Offset: 0x0000907D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000696E8 File Offset: 0x000678E8
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
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "AllArmiesPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000626 RID: 1574
		public static AllArmiesPanel2 instance = null;

		// Token: 0x04000627 RID: 1575
		public static bool TradersUpdated = false;

		// Token: 0x04000628 RID: 1576
		public static bool MonksUpdated = false;

		// Token: 0x04000629 RID: 1577
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400062A RID: 1578
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400062B RID: 1579
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400062C RID: 1580
		private CustomSelfDrawPanel.CSDButton tradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400062D RID: 1581
		private CustomSelfDrawPanel.CSDButton attackButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400062E RID: 1582
		private CustomSelfDrawPanel.CSDButton monkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400062F RID: 1583
		private CustomSelfDrawPanel.CSDButton scoutButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000630 RID: 1584
		private CustomSelfDrawPanel.CSDButton reinforcementsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000631 RID: 1585
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000632 RID: 1586
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000633 RID: 1587
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000634 RID: 1588
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000635 RID: 1589
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000636 RID: 1590
		private CustomSelfDrawPanel.CSDImage divider4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000637 RID: 1591
		private CustomSelfDrawPanel.CSDImage divider5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000638 RID: 1592
		private CustomSelfDrawPanel.CSDImage divider6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000639 RID: 1593
		private CustomSelfDrawPanel.CSDImage divider7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400063A RID: 1594
		private CustomSelfDrawPanel.CSDLabel outGoingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400063B RID: 1595
		private CustomSelfDrawPanel.CSDLabel outGoingFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400063C RID: 1596
		private CustomSelfDrawPanel.CSDLabel outGoingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400063D RID: 1597
		private CustomSelfDrawPanel.CSDLabel outGoingCarryingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400063E RID: 1598
		private CustomSelfDrawPanel.CSDLabel outGoingStatusLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400063F RID: 1599
		private CustomSelfDrawPanel.CSDLabel incomingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000640 RID: 1600
		private CustomSelfDrawPanel.CSDLabel incomingAttackingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000641 RID: 1601
		private CustomSelfDrawPanel.CSDLabel incomingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000642 RID: 1602
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000643 RID: 1603
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000644 RID: 1604
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000645 RID: 1605
		private CustomSelfDrawPanel.CSDVertScrollBar incomingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000646 RID: 1606
		private CustomSelfDrawPanel.CSDArea incomingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000647 RID: 1607
		private CustomSelfDrawPanel.CSDLabel diplomacyHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000648 RID: 1608
		private CustomSelfDrawPanel.CSDLabel diplomacyTextLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000649 RID: 1609
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400064A RID: 1610
		private CustomSelfDrawPanel.CSDImage smallPeasantImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400064B RID: 1611
		private CustomSelfDrawPanel.CSDButton btnDiplomacy = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400064C RID: 1612
		private int blockYSize;

		// Token: 0x0400064D RID: 1613
		private List<WorldMap.LocalArmyData> armyList = new List<WorldMap.LocalArmyData>();

		// Token: 0x0400064E RID: 1614
		private List<WorldMap.LocalTrader> merchantList = new List<WorldMap.LocalTrader>();

		// Token: 0x0400064F RID: 1615
		private List<WorldMap.LocalPerson> monkList = new List<WorldMap.LocalPerson>();

		// Token: 0x04000650 RID: 1616
		private List<WorldMap.LocalArmyData> reinforcementList = new List<WorldMap.LocalArmyData>();

		// Token: 0x04000651 RID: 1617
		private static int mode = 0;

		// Token: 0x04000652 RID: 1618
		private CustomSelfDrawPanel.CSDArea sortArea1 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000653 RID: 1619
		private CustomSelfDrawPanel.CSDArea sortArea2 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000654 RID: 1620
		private CustomSelfDrawPanel.CSDArea sortArea3 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000655 RID: 1621
		private CustomSelfDrawPanel.CSDArea sortArea4 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000656 RID: 1622
		private CustomSelfDrawPanel.CSDArea sortArea5 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000657 RID: 1623
		private CustomSelfDrawPanel.CSDArea sortArea6 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000658 RID: 1624
		private CustomSelfDrawPanel.CSDArea sortArea7 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000659 RID: 1625
		private CustomSelfDrawPanel.CSDArea sortArea8 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065A RID: 1626
		private CustomSelfDrawPanel.CSDArea sortArea9 = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065B RID: 1627
		private CustomSelfDrawPanel.CSDArea sortArea1a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065C RID: 1628
		private CustomSelfDrawPanel.CSDArea sortArea2a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065D RID: 1629
		private CustomSelfDrawPanel.CSDArea sortArea3a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065E RID: 1630
		private CustomSelfDrawPanel.CSDArea sortArea4a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400065F RID: 1631
		private CustomSelfDrawPanel.CSDArea sortArea5a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000660 RID: 1632
		private CustomSelfDrawPanel.CSDArea sortArea6a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000661 RID: 1633
		private CustomSelfDrawPanel.CSDArea sortArea7a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000662 RID: 1634
		private CustomSelfDrawPanel.CSDArea sortArea8a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000663 RID: 1635
		private CustomSelfDrawPanel.CSDArea sortArea9a = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000664 RID: 1636
		public static int sortMode = 8;

		// Token: 0x04000665 RID: 1637
		private DateTime lastfullUpdate = DateTime.MinValue;

		// Token: 0x04000666 RID: 1638
		private List<AllArmiesPanel2.ArmyLine> armyLineList = new List<AllArmiesPanel2.ArmyLine>();

		// Token: 0x04000667 RID: 1639
		private List<AllArmiesPanel2.ArmyLine> armyLineList2 = new List<AllArmiesPanel2.ArmyLine>();

		// Token: 0x04000668 RID: 1640
		private List<AllArmiesPanel2.ScoutLine> scoutLineList = new List<AllArmiesPanel2.ScoutLine>();

		// Token: 0x04000669 RID: 1641
		private List<AllArmiesPanel2.ScoutLine> scoutLineList2 = new List<AllArmiesPanel2.ScoutLine>();

		// Token: 0x0400066A RID: 1642
		private List<AllArmiesPanel2.ReinforcementLine> reinforcementLineList = new List<AllArmiesPanel2.ReinforcementLine>();

		// Token: 0x0400066B RID: 1643
		private List<AllArmiesPanel2.ReinforcementLine> reinforcementLineList2 = new List<AllArmiesPanel2.ReinforcementLine>();

		// Token: 0x0400066C RID: 1644
		private List<AllArmiesPanel2.MerchantLine> merchantLineList = new List<AllArmiesPanel2.MerchantLine>();

		// Token: 0x0400066D RID: 1645
		private List<AllArmiesPanel2.MerchantLine> merchantLineList2 = new List<AllArmiesPanel2.MerchantLine>();

		// Token: 0x0400066E RID: 1646
		private List<AllArmiesPanel2.MonkLine> monkLineList = new List<AllArmiesPanel2.MonkLine>();

		// Token: 0x0400066F RID: 1647
		private List<AllArmiesPanel2.MonkLine> monkLineList2 = new List<AllArmiesPanel2.MonkLine>();

		// Token: 0x04000670 RID: 1648
		private AllArmiesPanel2.ArmyComparer armyComparer = new AllArmiesPanel2.ArmyComparer();

		// Token: 0x04000671 RID: 1649
		private AllArmiesPanel2.MerchantComparer merchantComparer = new AllArmiesPanel2.MerchantComparer();

		// Token: 0x04000672 RID: 1650
		private AllArmiesPanel2.MonkComparer monkComparer = new AllArmiesPanel2.MonkComparer();

		// Token: 0x04000673 RID: 1651
		private DockableControl dockableControl;

		// Token: 0x04000674 RID: 1652
		private IContainer components;

		// Token: 0x04000675 RID: 1653
		private Panel focusPanel;

		// Token: 0x020000C1 RID: 193
		public class ArmyComparer : IComparer<WorldMap.LocalArmyData>
		{
			// Token: 0x06000568 RID: 1384 RVA: 0x000697D4 File Offset: 0x000679D4
			public int Compare(WorldMap.LocalArmyData x, WorldMap.LocalArmyData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (AllArmiesPanel2.sortMode < 0)
					{
						WorldMap.LocalArmyData localArmyData = x;
						x = y;
						y = localArmyData;
					}
					bool flag = true;
					if (AllArmiesPanel2.mode == 0)
					{
						int num = Math.Abs(AllArmiesPanel2.sortMode);
						if (num - 3 <= 4 || num == 20)
						{
							bool flag2 = false;
							bool flag3 = false;
							if ((GameEngine.Instance.World.isUserVillage(x.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(x.homeVillageID)) && x.attackType != 13)
							{
								flag2 = true;
							}
							if ((GameEngine.Instance.World.isUserVillage(y.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(y.homeVillageID)) && y.attackType != 13)
							{
								flag3 = true;
							}
							if (!flag2 && !flag3)
							{
								flag = false;
							}
							if (!flag2)
							{
								return 1;
							}
							if (!flag3)
							{
								return -1;
							}
						}
					}
					else if (AllArmiesPanel2.mode == 3 && Math.Abs(AllArmiesPanel2.sortMode) == 9)
					{
						bool flag4 = false;
						bool flag5 = false;
						if (GameEngine.Instance.World.isUserVillage(x.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(x.homeVillageID))
						{
							flag4 = true;
						}
						if (GameEngine.Instance.World.isUserVillage(y.travelFromVillageID) || GameEngine.Instance.World.isUserVillage(y.homeVillageID))
						{
							flag5 = true;
						}
						if (!flag4 && !flag5)
						{
							flag = false;
						}
						if (!flag4)
						{
							return 1;
						}
						if (!flag5)
						{
							return -1;
						}
					}
					if (flag)
					{
						int sortMode = AllArmiesPanel2.sortMode;
						switch (sortMode)
						{
						case -20:
							break;
						case -19:
						case -18:
						case -17:
						case -16:
						case -15:
						case -14:
						case -13:
						case -12:
						case -11:
						case -10:
						case 0:
							goto IL_368;
						case -9:
						case 9:
						{
							int num2 = x.numScouts.CompareTo(y.numScouts);
							if (num2 != 0)
							{
								return num2;
							}
							goto IL_368;
						}
						case -8:
						case 8:
						{
							int num3 = x.serverEndTime.CompareTo(y.serverEndTime);
							if (num3 != 0)
							{
								return num3;
							}
							goto IL_368;
						}
						case -7:
						case 7:
						{
							int num4 = x.numCatapults.CompareTo(y.numCatapults);
							if (num4 != 0)
							{
								return num4;
							}
							goto IL_368;
						}
						case -6:
						case 6:
						{
							int num5 = x.numSwordsmen.CompareTo(y.numSwordsmen);
							if (num5 != 0)
							{
								return num5;
							}
							goto IL_368;
						}
						case -5:
						case 5:
						{
							int num6 = x.numPikemen.CompareTo(y.numPikemen);
							if (num6 != 0)
							{
								return num6;
							}
							goto IL_368;
						}
						case -4:
						case 4:
						{
							int num7 = x.numArchers.CompareTo(y.numArchers);
							if (num7 != 0)
							{
								return num7;
							}
							goto IL_368;
						}
						case -3:
						case 3:
						{
							int num8 = x.numPeasants.CompareTo(y.numPeasants);
							if (num8 != 0)
							{
								return num8;
							}
							goto IL_368;
						}
						case -2:
						case 2:
						{
							string villageName = GameEngine.Instance.World.getVillageName(x.travelFromVillageID);
							string villageName2 = GameEngine.Instance.World.getVillageName(y.travelFromVillageID);
							int num9 = villageName.CompareTo(villageName2);
							if (num9 != 0)
							{
								return num9;
							}
							goto IL_368;
						}
						case -1:
						case 1:
						{
							string villageName3 = GameEngine.Instance.World.getVillageName(x.targetVillageID);
							string villageName4 = GameEngine.Instance.World.getVillageName(y.targetVillageID);
							int num10 = villageName3.CompareTo(villageName4);
							if (num10 != 0)
							{
								return num10;
							}
							goto IL_368;
						}
						default:
							if (sortMode != 20)
							{
								goto IL_368;
							}
							break;
						}
						int num11 = x.numCaptains.CompareTo(y.numCaptains);
						if (num11 != 0)
						{
							return num11;
						}
					}
					IL_368:
					if (x.armyID > y.armyID)
					{
						return 1;
					}
					if (x.armyID < y.armyID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020000C2 RID: 194
		public class MerchantComparer : IComparer<WorldMap.LocalTrader>
		{
			// Token: 0x0600056A RID: 1386 RVA: 0x00069B6C File Offset: 0x00067D6C
			public int Compare(WorldMap.LocalTrader x, WorldMap.LocalTrader y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (AllArmiesPanel2.sortMode < 0)
					{
						WorldMap.LocalTrader localTrader = x;
						x = y;
						y = localTrader;
					}
					bool flag = true;
					if (AllArmiesPanel2.sortMode == 10)
					{
						bool flag2 = false;
						bool flag3 = false;
						if (GameEngine.Instance.World.isUserVillage(x.trader.homeVillageID) && ((x.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 0.0 || x.trader.traderState == 0 || x.trader.traderState == 1 || x.trader.traderState == 3 || x.trader.traderState == 5))
						{
							flag2 = true;
						}
						if (GameEngine.Instance.World.isUserVillage(y.trader.homeVillageID) && ((y.serverEndTime - VillageMap.getCurrentServerTime()).TotalSeconds > 0.0 || y.trader.traderState == 0 || y.trader.traderState == 1 || y.trader.traderState == 3 || y.trader.traderState == 5))
						{
							flag3 = true;
						}
						if (!flag2 && !flag3)
						{
							flag = false;
						}
						if (!flag2)
						{
							return 1;
						}
						if (!flag3)
						{
							return -1;
						}
					}
					if (flag)
					{
						int sortMode = AllArmiesPanel2.sortMode;
						switch (sortMode)
						{
						case -11:
							goto IL_30A;
						case -10:
							goto IL_24F;
						case -9:
							goto IL_3A6;
						case -8:
							break;
						default:
							switch (sortMode)
							{
							case -2:
							case 2:
							{
								string villageName = GameEngine.Instance.World.getVillageName(x.trader.homeVillageID);
								string villageName2 = GameEngine.Instance.World.getVillageName(y.trader.homeVillageID);
								int num = villageName.CompareTo(villageName2);
								if (num != 0)
								{
									return num;
								}
								goto IL_3A6;
							}
							case -1:
							case 1:
							{
								string villageName3 = GameEngine.Instance.World.getVillageName(x.trader.targetVillageID);
								string villageName4 = GameEngine.Instance.World.getVillageName(y.trader.targetVillageID);
								int num2 = villageName3.CompareTo(villageName4);
								if (num2 != 0)
								{
									return num2;
								}
								goto IL_3A6;
							}
							case 0:
								goto IL_3A6;
							default:
								switch (sortMode)
								{
								case 8:
									break;
								case 9:
									goto IL_3A6;
								case 10:
									goto IL_24F;
								case 11:
									goto IL_30A;
								default:
									goto IL_3A6;
								}
								break;
							}
							break;
						}
						int num3 = x.serverEndTime.CompareTo(y.serverEndTime);
						if (num3 != 0)
						{
							return num3;
						}
						goto IL_3A6;
						IL_24F:
						int num4 = 0;
						int value = 0;
						int value2 = 0;
						int num5 = 0;
						if (x.trader.traderState == 1 || x.trader.traderState == 3 || x.trader.traderState == 6)
						{
							num4 = x.trader.resource;
							value2 = x.trader.amount;
						}
						if (y.trader.traderState == 1 || y.trader.traderState == 3 || y.trader.traderState == 6)
						{
							value = y.trader.resource;
							num5 = y.trader.amount;
						}
						int num6 = num4.CompareTo(value);
						if (num6 != 0)
						{
							return num6;
						}
						num6 = num5.CompareTo(value2);
						if (num6 != 0)
						{
							return num6;
						}
						goto IL_3A6;
						IL_30A:
						int num7 = 0;
						switch (x.trader.traderState)
						{
						case 1:
							num7 = 1;
							break;
						case 2:
						case 4:
						case 6:
							num7 = 4;
							break;
						case 3:
							num7 = 2;
							break;
						case 5:
							num7 = 3;
							break;
						}
						int value3 = 0;
						switch (y.trader.traderState)
						{
						case 1:
							value3 = 1;
							break;
						case 2:
						case 4:
						case 6:
							value3 = 4;
							break;
						case 3:
							value3 = 2;
							break;
						case 5:
							value3 = 3;
							break;
						}
						int num8 = num7.CompareTo(value3);
						if (num8 != 0)
						{
							return num8;
						}
					}
					IL_3A6:
					if (x.traderID > y.traderID)
					{
						return 1;
					}
					if (x.traderID < y.traderID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020000C3 RID: 195
		public class MonkComparer : IComparer<WorldMap.LocalPerson>
		{
			// Token: 0x0600056C RID: 1388 RVA: 0x00069F40 File Offset: 0x00068140
			public int Compare(WorldMap.LocalPerson x, WorldMap.LocalPerson y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					bool flag = true;
					if (AllArmiesPanel2.sortMode == 10)
					{
						bool flag2 = false;
						bool flag3 = false;
						if ((x.person.personType != 4 || x.person.state <= 0 || x.parentPerson >= 0L) && GameEngine.Instance.World.isUserVillage(x.person.homeVillageID))
						{
							flag2 = true;
						}
						if ((y.person.personType != 4 || y.person.state <= 0 || y.parentPerson >= 0L) && GameEngine.Instance.World.isUserVillage(y.person.homeVillageID))
						{
							flag3 = true;
						}
						if (!flag2 && !flag3)
						{
							flag = false;
						}
						if (!flag2)
						{
							return 1;
						}
						if (!flag3)
						{
							return -1;
						}
					}
					if (flag)
					{
						int sortMode = AllArmiesPanel2.sortMode;
						if (sortMode <= -8)
						{
							if (sortMode == -13)
							{
								goto IL_246;
							}
							if (sortMode == -12)
							{
								goto IL_1E2;
							}
							if (sortMode != -8)
							{
								goto IL_2B0;
							}
						}
						else if (sortMode <= 8)
						{
							switch (sortMode)
							{
							case -2:
							case 2:
							{
								string villageName = GameEngine.Instance.World.getVillageName(x.person.homeVillageID);
								string villageName2 = GameEngine.Instance.World.getVillageName(y.person.homeVillageID);
								int num = villageName.CompareTo(villageName2);
								if (num != 0)
								{
									return num;
								}
								goto IL_2B0;
							}
							case -1:
							case 1:
							{
								string villageName3 = GameEngine.Instance.World.getVillageName(x.person.targetVillageID);
								string villageName4 = GameEngine.Instance.World.getVillageName(y.person.targetVillageID);
								int num2 = villageName3.CompareTo(villageName4);
								if (num2 != 0)
								{
									return num2;
								}
								goto IL_2B0;
							}
							case 0:
								goto IL_2B0;
							default:
								if (sortMode != 8)
								{
									goto IL_2B0;
								}
								break;
							}
						}
						else
						{
							if (sortMode == 12)
							{
								goto IL_1E2;
							}
							if (sortMode != 13)
							{
								goto IL_2B0;
							}
							goto IL_246;
						}
						int num3 = x.serverEndTime.CompareTo(y.serverEndTime);
						if (num3 != 0)
						{
							return num3;
						}
						goto IL_2B0;
						IL_1E2:
						int value = 0;
						int num4 = 0;
						if (GameEngine.Instance.World.isUserVillage(x.person.homeVillageID))
						{
							value = x.childrenCount + 1;
						}
						if (GameEngine.Instance.World.isUserVillage(y.person.homeVillageID))
						{
							num4 = y.childrenCount + 1;
						}
						int num5 = num4.CompareTo(value);
						if (num5 != 0)
						{
							return num5;
						}
						goto IL_2B0;
						IL_246:
						int num6 = 0;
						int value2 = 0;
						if (GameEngine.Instance.World.isUserVillage(x.person.homeVillageID))
						{
							num6 = x.person.command;
						}
						if (GameEngine.Instance.World.isUserVillage(y.person.homeVillageID))
						{
							value2 = y.person.command;
						}
						int num7 = num6.CompareTo(value2);
						if (num7 != 0)
						{
							return num7;
						}
					}
					IL_2B0:
					if (x.personID > y.personID)
					{
						return 1;
					}
					if (x.personID < y.personID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020000C4 RID: 196
		public class ArmyLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x0600056E RID: 1390 RVA: 0x0006A220 File Offset: 0x00068420
			public void initSent(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, int attackType, int numCaptains)
			{
				this.incoming = true;
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, attackType, numCaptains);
			}

			// Token: 0x0600056F RID: 1391 RVA: 0x0006A25C File Offset: 0x0006845C
			public void initIncoming(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool tutorial, int attackType, int numCaptains)
			{
				this.incoming = false;
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, false, tutorial, attackType, numCaptains);
			}

			// Token: 0x06000570 RID: 1392 RVA: 0x0006A298 File Offset: 0x00068498
			private void initText(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool showTroops, bool tutorial, int attackType, int numCaptains)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_army = GameEngine.Instance.World.getArmy(armyID);
				this.m_origLoot = this.m_army.lootType;
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_otherVillageID = otherVillage;
				this.m_arrivalTime = arrivalTime;
				this.m_returning = returning;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				if (!tutorial)
				{
					this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				}
				else
				{
					this.lblVillage.Text = SK.Text("GENERIC_TUTORIAL", "Tutorial");
				}
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblTarget.Text = GameEngine.Instance.World.getVillageNameOrType(otherVillage);
				this.lblTarget.Color = global::ARGBColors.Black;
				this.lblTarget.RolloverColor = global::ARGBColors.White;
				this.lblTarget.Position = new Point(233, 0);
				this.lblTarget.Size = new Size(224, this.backgroundImage.Height);
				this.lblTarget.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblTarget.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblTarget.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblTarget_Click), "AllArmiesPanel2_targetVillage");
				this.backgroundImage.addControl(this.lblTarget);
				this.leftVillageID = villageID;
				this.rightVillageID = otherVillage;
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(833, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				if (showTroops)
				{
					this.lblPeasants.Text = numPeasants.ToString();
					this.lblPeasants.Color = global::ARGBColors.Black;
					this.lblPeasants.Position = new Point(455, 0);
					this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
					this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblPeasants);
					this.lblArchers.Text = numArchers.ToString();
					this.lblArchers.Color = global::ARGBColors.Black;
					this.lblArchers.Position = new Point(515, 0);
					this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
					this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblArchers);
					this.lblPikemen.Text = numPikemen.ToString();
					this.lblPikemen.Color = global::ARGBColors.Black;
					this.lblPikemen.Position = new Point(575, 0);
					this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
					this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblPikemen);
					this.lblSwordsmen.Text = numSwordsmen.ToString();
					this.lblSwordsmen.Color = global::ARGBColors.Black;
					this.lblSwordsmen.Position = new Point(635, 0);
					this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
					this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblSwordsmen);
					this.lblCatapults.Text = numCatapults.ToString();
					this.lblCatapults.Color = global::ARGBColors.Black;
					this.lblCatapults.Position = new Point(695, 0);
					this.lblCatapults.Size = new Size(55, this.backgroundImage.Height);
					this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblCatapults);
					this.lblCaptains.Text = numCaptains.ToString();
					this.lblCaptains.Color = global::ARGBColors.Black;
					this.lblCaptains.Position = new Point(755, 0);
					this.lblCaptains.Size = new Size(55, this.backgroundImage.Height);
					this.lblCaptains.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblCaptains.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblCaptains);
				}
				else if (numCaptains > 0)
				{
					this.imgCaptain.Image = GFXLibrary.barracks_screen_bottom_units;
					this.imgCaptain.Position = new Point(200, -10);
					this.imgCaptain.ClipRect = new Rectangle(this.imgCaptain.Width - 60, 0, 60, this.imgCaptain.Height);
					this.backgroundImage.addControl(this.imgCaptain);
				}
				if (!this.incoming)
				{
					if (attackType == 30)
					{
						this.lblPeasants.Text = SK.Text("AllArmiesSentLine_Vassal_Support", "Vassal Support");
						this.lblPeasants.Color = global::ARGBColors.Black;
						this.lblPeasants.Position = new Point(455, 0);
						this.lblPeasants.Size = new Size(250, this.backgroundImage.Height);
						this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
						this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						this.backgroundImage.addControl(this.lblPeasants);
					}
					if (attackType == 31)
					{
						this.lblPeasants.Text = SK.Text("AllArmiesSentLine_Capital_Support", "Capital Support");
						this.lblPeasants.Color = global::ARGBColors.Black;
						this.lblPeasants.Position = new Point(455, 0);
						this.lblPeasants.Size = new Size(250, this.backgroundImage.Height);
						this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
						this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
						this.backgroundImage.addControl(this.lblPeasants);
					}
				}
				else
				{
					bool flag = false;
					if (attackType == 30)
					{
						this.lblExtraInfo.Text = SK.Text("AllArmiesSentLine_Vassal_Support", "Vassal Support");
						this.lblExtraInfo.Color = global::ARGBColors.Black;
						this.lblExtraInfo.Position = new Point(455, 7);
						this.lblExtraInfo.Size = new Size(360, this.backgroundImage.Height);
						this.lblExtraInfo.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
						this.lblExtraInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.backgroundImage.addControl(this.lblExtraInfo);
						flag = true;
					}
					if (attackType == 31)
					{
						this.lblExtraInfo.Text = SK.Text("AllArmiesSentLine_Capital_Support", "Capital Support");
						this.lblExtraInfo.Color = global::ARGBColors.Black;
						this.lblExtraInfo.Position = new Point(455, 7);
						this.lblExtraInfo.Size = new Size(360, this.backgroundImage.Height);
						this.lblExtraInfo.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
						this.lblExtraInfo.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						this.backgroundImage.addControl(this.lblExtraInfo);
						flag = true;
					}
					if (flag)
					{
						this.lblPeasants.Position = new Point(485, -7);
						this.lblArchers.Position = new Point(545, -7);
						this.lblPikemen.Position = new Point(605, -7);
						this.lblSwordsmen.Position = new Point(665, -7);
						this.lblCatapults.Position = new Point(725, -7);
					}
					bool flag2 = true;
					switch (attackType)
					{
					case 1:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[3];
						goto IL_AB7;
					case 2:
					case 4:
					case 5:
					case 6:
					case 7:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[5];
						goto IL_AB7;
					case 3:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[2];
						goto IL_AB7;
					case 9:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[4];
						goto IL_AB7;
					case 11:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[1];
						goto IL_AB7;
					case 12:
						this.imgAttackType.Image = GFXLibrary.send_army_buttons[0];
						goto IL_AB7;
					}
					flag2 = false;
					IL_AB7:
					if (flag2)
					{
						this.imgAttackType.setSizeToImage();
						this.imgAttackType.setScale(0.4000000059604645);
						this.imgAttackType.Position = new Point(480, -2);
						this.backgroundImage.addControl(this.imgAttackType);
					}
				}
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x06000571 RID: 1393 RVA: 0x0006ADC4 File Offset: 0x00068FC4
			public bool update(double localTime)
			{
				WorldMap.LocalArmyData army = GameEngine.Instance.World.getArmy(this.m_armyID);
				if (army == null || army.lootType != this.m_origLoot)
				{
					return false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
				if (num < 1)
				{
					num = 0;
				}
				this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
				if (this.m_returning)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblArrivalTime;
					csdlabel.Text = csdlabel.Text + " (" + SK.Text("AllArmiesSentLine_Return_Abbreviation", "Rtrn") + ")";
				}
				return true;
			}

			// Token: 0x06000572 RID: 1394 RVA: 0x0006AE74 File Offset: 0x00069074
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x06000573 RID: 1395 RVA: 0x0006AF00 File Offset: 0x00069100
			private void lblTarget_Click()
			{
				if (this.rightVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.rightVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.rightVillageID, false, true, true, false);
				}
			}

			// Token: 0x04000676 RID: 1654
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000677 RID: 1655
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000678 RID: 1656
			private CustomSelfDrawPanel.CSDLabel lblTarget = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000679 RID: 1657
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067A RID: 1658
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067B RID: 1659
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067C RID: 1660
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067D RID: 1661
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067E RID: 1662
			private CustomSelfDrawPanel.CSDLabel lblScouts = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400067F RID: 1663
			private CustomSelfDrawPanel.CSDLabel lblCaptains = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000680 RID: 1664
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000681 RID: 1665
			private CustomSelfDrawPanel.CSDLabel lblExtraInfo = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000682 RID: 1666
			private CustomSelfDrawPanel.CSDImage imgCaptain = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000683 RID: 1667
			private CustomSelfDrawPanel.CSDImage imgAttackType = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000684 RID: 1668
			private int m_position = -1000;

			// Token: 0x04000685 RID: 1669
			private AllArmiesPanel2 m_parent;

			// Token: 0x04000686 RID: 1670
			private int leftVillageID = -1;

			// Token: 0x04000687 RID: 1671
			private int rightVillageID = -1;

			// Token: 0x04000688 RID: 1672
			private int m_villageID = -1;

			// Token: 0x04000689 RID: 1673
			private int m_otherVillageID = -1;

			// Token: 0x0400068A RID: 1674
			private bool m_returning;

			// Token: 0x0400068B RID: 1675
			private long m_armyID = -1L;

			// Token: 0x0400068C RID: 1676
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x0400068D RID: 1677
			private WorldMap.LocalArmyData m_army;

			// Token: 0x0400068E RID: 1678
			private int m_origLoot = -1;

			// Token: 0x0400068F RID: 1679
			private bool incoming = true;
		}

		// Token: 0x020000C5 RID: 197
		public class ReinforcementLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000575 RID: 1397 RVA: 0x0006B084 File Offset: 0x00069284
			public void initSent(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning)
			{
				this.m_sent = true;
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, 0);
			}

			// Token: 0x06000576 RID: 1398 RVA: 0x0006B0BC File Offset: 0x000692BC
			public void initIncoming(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool tutorial, int attackType)
			{
				this.m_sent = false;
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, false, tutorial, attackType);
			}

			// Token: 0x06000577 RID: 1399 RVA: 0x0006B0F4 File Offset: 0x000692F4
			private void initText(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool showTroops, bool tutorial, int attackType)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_army = GameEngine.Instance.World.getReinforcement(armyID);
				this.m_origLoot = this.m_army.lootType;
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_otherVillageID = otherVillage;
				this.m_arrivalTime = arrivalTime;
				this.m_returning = returning;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (this.m_arrivalTime > currentServerTime)
				{
					this.m_moving = true;
					if (!this.m_sent)
					{
					}
				}
				else
				{
					this.m_moving = false;
				}
				this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblTarget.Text = GameEngine.Instance.World.getVillageNameOrType(otherVillage);
				this.lblTarget.Color = global::ARGBColors.Black;
				this.lblTarget.RolloverColor = global::ARGBColors.White;
				this.lblTarget.Position = new Point(233, 0);
				this.lblTarget.Size = new Size(224, this.backgroundImage.Height);
				this.lblTarget.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblTarget.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblTarget.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblTarget_Click), "AllArmiesPanel2_targetVillage");
				this.backgroundImage.addControl(this.lblTarget);
				this.leftVillageID = villageID;
				this.rightVillageID = otherVillage;
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(833, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				this.lblPeasants.Text = numPeasants.ToString();
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.Position = new Point(485, 0);
				this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblPeasants);
				this.lblArchers.Text = numArchers.ToString();
				this.lblArchers.Color = global::ARGBColors.Black;
				this.lblArchers.Position = new Point(545, 0);
				this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
				this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblArchers);
				this.lblPikemen.Text = numPikemen.ToString();
				this.lblPikemen.Color = global::ARGBColors.Black;
				this.lblPikemen.Position = new Point(605, 0);
				this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
				this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblPikemen);
				this.lblSwordsmen.Text = numSwordsmen.ToString();
				this.lblSwordsmen.Color = global::ARGBColors.Black;
				this.lblSwordsmen.Position = new Point(665, 0);
				this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
				this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblSwordsmen);
				this.lblCatapults.Text = numCatapults.ToString();
				this.lblCatapults.Color = global::ARGBColors.Black;
				this.lblCatapults.Position = new Point(725, 0);
				this.lblCatapults.Size = new Size(55, this.backgroundImage.Height);
				this.lblCatapults.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblCatapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblCatapults);
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x06000578 RID: 1400 RVA: 0x0006B6F8 File Offset: 0x000698F8
			public bool update(double localTime)
			{
				if (GameEngine.Instance.World.getReinforcement(this.m_armyID) == null)
				{
					return false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (this.m_arrivalTime.AddSeconds(5.0) < currentServerTime)
				{
					this.lblArrivalTime.Text = "";
					if (this.m_returning && this.m_moving)
					{
						this.m_moving = false;
						return false;
					}
				}
				else
				{
					int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
					if (num < 1)
					{
						num = 0;
					}
					this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
					if (this.m_sent && this.m_moving)
					{
						CustomSelfDrawPanel.CSDLabel csdlabel = this.lblArrivalTime;
						csdlabel.Text = csdlabel.Text + " (" + SK.Text("AllArmiesSentLine_Return_Abbreviation", "Rtrn") + ")";
					}
				}
				return true;
			}

			// Token: 0x06000579 RID: 1401 RVA: 0x0006B7F0 File Offset: 0x000699F0
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x0600057A RID: 1402 RVA: 0x0006B87C File Offset: 0x00069A7C
			private void lblTarget_Click()
			{
				if (this.rightVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.rightVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.rightVillageID, false, true, true, false);
				}
			}

			// Token: 0x04000690 RID: 1680
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000691 RID: 1681
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000692 RID: 1682
			private CustomSelfDrawPanel.CSDLabel lblTarget = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000693 RID: 1683
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000694 RID: 1684
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000695 RID: 1685
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000696 RID: 1686
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000697 RID: 1687
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000698 RID: 1688
			private CustomSelfDrawPanel.CSDLabel lblScouts = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000699 RID: 1689
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x0400069A RID: 1690
			private int m_position = -1000;

			// Token: 0x0400069B RID: 1691
			private AllArmiesPanel2 m_parent;

			// Token: 0x0400069C RID: 1692
			private int leftVillageID = -1;

			// Token: 0x0400069D RID: 1693
			private int rightVillageID = -1;

			// Token: 0x0400069E RID: 1694
			private int m_villageID = -1;

			// Token: 0x0400069F RID: 1695
			private int m_otherVillageID = -1;

			// Token: 0x040006A0 RID: 1696
			private bool m_returning;

			// Token: 0x040006A1 RID: 1697
			private long m_armyID = -1L;

			// Token: 0x040006A2 RID: 1698
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x040006A3 RID: 1699
			private WorldMap.LocalArmyData m_army;

			// Token: 0x040006A4 RID: 1700
			private int m_origLoot = -1;

			// Token: 0x040006A5 RID: 1701
			private bool m_moving;

			// Token: 0x040006A6 RID: 1702
			private bool m_sent;
		}

		// Token: 0x020000C6 RID: 198
		public class ScoutLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x0600057C RID: 1404 RVA: 0x0006B9CC File Offset: 0x00069BCC
			public void initSent(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning)
			{
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, 0);
			}

			// Token: 0x0600057D RID: 1405 RVA: 0x0006B9FC File Offset: 0x00069BFC
			public void initIncoming(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool tutorial, int attackType)
			{
				this.initText(position, villageID, otherVillage, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, false, tutorial, attackType);
			}

			// Token: 0x0600057E RID: 1406 RVA: 0x0006BA30 File Offset: 0x00069C30
			private void initText(int position, int villageID, int otherVillage, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, AllArmiesPanel2 parent, bool returning, bool showTroops, bool tutorial, int attackType)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_army = GameEngine.Instance.World.getArmy(armyID);
				this.m_origLoot = this.m_army.lootType;
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_otherVillageID = otherVillage;
				this.m_arrivalTime = arrivalTime;
				this.m_returning = returning;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				if (!tutorial)
				{
					this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				}
				else
				{
					this.lblVillage.Text = SK.Text("GENERIC_TUTORIAL", "Tutorial");
				}
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblTarget.Text = GameEngine.Instance.World.getVillageNameOrType(otherVillage);
				this.lblTarget.Color = global::ARGBColors.Black;
				this.lblTarget.RolloverColor = global::ARGBColors.White;
				this.lblTarget.Position = new Point(233, 0);
				this.lblTarget.Size = new Size(224, this.backgroundImage.Height);
				this.lblTarget.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblTarget.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblTarget.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblTarget_Click), "AllArmiesPanel2_targetVillage");
				this.backgroundImage.addControl(this.lblTarget);
				this.leftVillageID = villageID;
				this.rightVillageID = otherVillage;
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(833, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				if (showTroops)
				{
					this.lblScouts.Text = numScouts.ToString();
					this.lblScouts.Color = global::ARGBColors.Black;
					this.lblScouts.Position = new Point(485, 0);
					this.lblScouts.Size = new Size(55, this.backgroundImage.Height);
					this.lblScouts.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblScouts.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblScouts);
				}
				if (this.m_origLoot >= 100 && this.m_origLoot < 199)
				{
					this.imgCarrying.Image = GFXLibrary.getCommodity32DSImage(this.m_origLoot - 100);
					this.imgCarrying.Position = new Point(695, -3);
					this.backgroundImage.addControl(this.imgCarrying);
					NumberFormatInfo nfi = GameEngine.NFI;
					this.lblCarryingAmount.Text = this.m_army.lootLevel.ToString("N", nfi);
					this.lblCarryingAmount.Color = global::ARGBColors.Black;
					this.lblCarryingAmount.Position = new Point(635, 0);
					this.lblCarryingAmount.Size = new Size(55, this.backgroundImage.Height);
					this.lblCarryingAmount.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblCarryingAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					this.backgroundImage.addControl(this.lblCarryingAmount);
				}
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x0600057F RID: 1407 RVA: 0x0006BEFC File Offset: 0x0006A0FC
			public bool update(double localTime)
			{
				WorldMap.LocalArmyData army = GameEngine.Instance.World.getArmy(this.m_armyID);
				if (army == null || army.lootType != this.m_origLoot)
				{
					return false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
				if (num < 1)
				{
					num = 0;
				}
				this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
				if (this.m_returning)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblArrivalTime;
					csdlabel.Text = csdlabel.Text + " (" + SK.Text("AllArmiesSentLine_Return_Abbreviation", "Rtrn") + ")";
				}
				return true;
			}

			// Token: 0x06000580 RID: 1408 RVA: 0x0006BFAC File Offset: 0x0006A1AC
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x06000581 RID: 1409 RVA: 0x0006C038 File Offset: 0x0006A238
			private void lblTarget_Click()
			{
				if (this.rightVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.rightVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.rightVillageID, false, true, true, false);
				}
			}

			// Token: 0x040006A7 RID: 1703
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006A8 RID: 1704
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006A9 RID: 1705
			private CustomSelfDrawPanel.CSDLabel lblTarget = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006AA RID: 1706
			private CustomSelfDrawPanel.CSDLabel lblScouts = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006AB RID: 1707
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006AC RID: 1708
			private CustomSelfDrawPanel.CSDLabel lblCarryingAmount = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006AD RID: 1709
			private CustomSelfDrawPanel.CSDImage imgCarrying = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006AE RID: 1710
			private int m_position = -1000;

			// Token: 0x040006AF RID: 1711
			private AllArmiesPanel2 m_parent;

			// Token: 0x040006B0 RID: 1712
			private int leftVillageID = -1;

			// Token: 0x040006B1 RID: 1713
			private int rightVillageID = -1;

			// Token: 0x040006B2 RID: 1714
			private int m_villageID = -1;

			// Token: 0x040006B3 RID: 1715
			private int m_otherVillageID = -1;

			// Token: 0x040006B4 RID: 1716
			private bool m_returning;

			// Token: 0x040006B5 RID: 1717
			private long m_armyID = -1L;

			// Token: 0x040006B6 RID: 1718
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x040006B7 RID: 1719
			private WorldMap.LocalArmyData m_army;

			// Token: 0x040006B8 RID: 1720
			private int m_origLoot = -1;
		}

		// Token: 0x020000C7 RID: 199
		public class MerchantLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000583 RID: 1411 RVA: 0x0006C168 File Offset: 0x0006A368
			public void initSent(int position, int villageID, int otherVillage, int numTraders, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent, bool returning, int traderState, int resource, int amount)
			{
				this.initText(position, villageID, otherVillage, numTraders, arrivalTime, armyID, parent, returning, traderState, resource, amount);
			}

			// Token: 0x06000584 RID: 1412 RVA: 0x0006C190 File Offset: 0x0006A390
			public void initIncoming(int position, int villageID, int otherVillage, int numTraders, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent, bool returning)
			{
				this.initText(position, villageID, otherVillage, numTraders, arrivalTime, armyID, parent, returning, -1, 0, 0);
			}

			// Token: 0x06000585 RID: 1413 RVA: 0x0006C1B4 File Offset: 0x0006A3B4
			private void initText(int position, int villageID, int otherVillage, int numTraders, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent, bool returning, int traderState, int resource, int amount)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_traderState = traderState;
				this.m_army = GameEngine.Instance.World.getTrader(armyID);
				this.m_realTraderState = this.m_army.trader.traderState;
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_otherVillageID = otherVillage;
				this.m_arrivalTime = arrivalTime;
				this.m_returning = returning;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblTarget.Text = GameEngine.Instance.World.getVillageNameOrType(otherVillage);
				this.lblTarget.Color = global::ARGBColors.Black;
				this.lblTarget.RolloverColor = global::ARGBColors.White;
				this.lblTarget.Position = new Point(233, 0);
				this.lblTarget.Size = new Size(224, this.backgroundImage.Height);
				this.lblTarget.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblTarget.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblTarget.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblTarget_Click), "AllArmiesPanel2_targetVillage");
				this.backgroundImage.addControl(this.lblTarget);
				this.leftVillageID = villageID;
				this.rightVillageID = otherVillage;
				if (traderState == 1 || traderState == 3 || traderState == 6 || traderState == 5)
				{
					this.resourceImage.Image = GFXLibrary.getCommodity32DSImage(resource);
					this.resourceImage.Position = new Point(455, -3);
					this.backgroundImage.addControl(this.resourceImage);
					NumberFormatInfo nfi = GameEngine.NFI;
					this.resourceAmount.Text = amount.ToString("N", nfi);
					this.resourceAmount.Color = global::ARGBColors.Black;
					this.resourceAmount.Position = new Point(490, 0);
					this.resourceAmount.Size = new Size(60, this.backgroundImage.Height);
					this.resourceAmount.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.resourceAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
					this.backgroundImage.addControl(this.resourceAmount);
				}
				if (traderState >= 1)
				{
					switch (traderState)
					{
					case 1:
						this.description.Text = SK.Text("SelectArmyPanel_Delivering", "Delivering");
						break;
					case 2:
					case 4:
					case 6:
						this.description.Text = SK.Text("SelectArmyPanel_Returning", "Returning");
						break;
					case 3:
						this.description.Text = SK.Text("SelectArmyPanel_Selling", "Selling");
						break;
					case 5:
						this.description.Text = SK.Text("SelectArmyPanel_Collecting", "Collecting");
						break;
					}
					this.description.Color = global::ARGBColors.Black;
					this.description.Position = new Point(575, 0);
					this.description.Size = new Size(240, this.backgroundImage.Height);
					this.description.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.description.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.description);
				}
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(833, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x06000586 RID: 1414 RVA: 0x0006C6DC File Offset: 0x0006A8DC
			public bool update(double localTime)
			{
				WorldMap.LocalTrader trader = GameEngine.Instance.World.getTrader(this.m_armyID);
				if (trader == null)
				{
					return false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
				if (num < 1)
				{
					num = 0;
				}
				if (trader.trader.traderState != this.m_realTraderState)
				{
					return false;
				}
				this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
				if (this.m_returning)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblArrivalTime;
					csdlabel.Text = csdlabel.Text + " (" + SK.Text("AllArmiesSentLine_Return_Abbreviation", "Rtrn") + ")";
				}
				return true;
			}

			// Token: 0x06000587 RID: 1415 RVA: 0x0006C794 File Offset: 0x0006A994
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x06000588 RID: 1416 RVA: 0x0006C820 File Offset: 0x0006AA20
			private void lblTarget_Click()
			{
				if (this.rightVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.rightVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.rightVillageID, false, true, true, false);
				}
			}

			// Token: 0x040006B9 RID: 1721
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006BA RID: 1722
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006BB RID: 1723
			private CustomSelfDrawPanel.CSDLabel lblTarget = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006BC RID: 1724
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006BD RID: 1725
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006BE RID: 1726
			private int m_position = -1000;

			// Token: 0x040006BF RID: 1727
			private CustomSelfDrawPanel.CSDImage resourceImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006C0 RID: 1728
			private CustomSelfDrawPanel.CSDLabel resourceAmount = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006C1 RID: 1729
			private CustomSelfDrawPanel.CSDLabel description = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006C2 RID: 1730
			private AllArmiesPanel2 m_parent;

			// Token: 0x040006C3 RID: 1731
			private int leftVillageID = -1;

			// Token: 0x040006C4 RID: 1732
			private int rightVillageID = -1;

			// Token: 0x040006C5 RID: 1733
			private int m_villageID = -1;

			// Token: 0x040006C6 RID: 1734
			private int m_otherVillageID = -1;

			// Token: 0x040006C7 RID: 1735
			private bool m_returning;

			// Token: 0x040006C8 RID: 1736
			private long m_armyID = -1L;

			// Token: 0x040006C9 RID: 1737
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x040006CA RID: 1738
			private WorldMap.LocalTrader m_army;

			// Token: 0x040006CB RID: 1739
			private int m_traderState = -1;

			// Token: 0x040006CC RID: 1740
			private int m_realTraderState = -1;
		}

		// Token: 0x020000C8 RID: 200
		public class MonkLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x0600058A RID: 1418 RVA: 0x0006C960 File Offset: 0x0006AB60
			public void initSent(int position, int villageID, int otherVillage, int numTraders, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent, int command)
			{
				this.initText(position, villageID, otherVillage, numTraders, arrivalTime, armyID, parent, command);
			}

			// Token: 0x0600058B RID: 1419 RVA: 0x0006C980 File Offset: 0x0006AB80
			public void initIncoming(int position, int villageID, int otherVillage, int numTraders, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent)
			{
				this.initText(position, villageID, otherVillage, numTraders, arrivalTime, armyID, parent, 0);
			}

			// Token: 0x0600058C RID: 1420 RVA: 0x0006C9A0 File Offset: 0x0006ABA0
			private void initText(int position, int villageID, int otherVillage, int numMonks, DateTime arrivalTime, long armyID, AllArmiesPanel2 parent, int command)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_army = GameEngine.Instance.World.getTrader(armyID);
				this.m_armyID = armyID;
				this.m_villageID = villageID;
				this.m_otherVillageID = otherVillage;
				this.m_arrivalTime = arrivalTime;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.brown_lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.lblVillage.Text = GameEngine.Instance.World.getVillageNameOrType(villageID);
				this.lblVillage.Color = global::ARGBColors.Black;
				this.lblVillage.RolloverColor = global::ARGBColors.White;
				this.lblVillage.Position = new Point(9, 0);
				this.lblVillage.Size = new Size(223, this.backgroundImage.Height);
				this.lblVillage.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblVillage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "AllArmiesPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblTarget.Text = GameEngine.Instance.World.getVillageNameOrType(otherVillage);
				this.lblTarget.Color = global::ARGBColors.Black;
				this.lblTarget.RolloverColor = global::ARGBColors.White;
				this.lblTarget.Position = new Point(233, 0);
				this.lblTarget.Size = new Size(224, this.backgroundImage.Height);
				this.lblTarget.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblTarget.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.lblTarget.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblTarget_Click), "AllArmiesPanel2_targetVillage");
				this.backgroundImage.addControl(this.lblTarget);
				this.leftVillageID = villageID;
				this.rightVillageID = otherVillage;
				if (numMonks > 0)
				{
					this.lblMonks.Text = numMonks.ToString();
					this.lblMonks.Color = global::ARGBColors.Black;
					this.lblMonks.Position = new Point(455, 0);
					this.lblMonks.Size = new Size(55, this.backgroundImage.Height);
					this.lblMonks.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblMonks.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.backgroundImage.addControl(this.lblMonks);
				}
				if (command > 0)
				{
					switch (command)
					{
					case 1:
						this.lblCommand.Text = SK.Text("VillageMapPanel_Blessing", "Blessing");
						break;
					case 2:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Positive_Influence", "Positive Influence");
						break;
					case 3:
						this.lblCommand.Text = SK.Text("VillageMapPanel_Inquisition", "Inquisition");
						break;
					case 4:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Interdiction", "Interdiction");
						break;
					case 5:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Restoration", "Restoration");
						break;
					case 6:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Absolution", "Absolution");
						break;
					case 7:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Excommnunication", "Excommunication");
						break;
					case 8:
						this.lblCommand.Text = SK.Text("SendMonksPanel_Negative_Influence", "Negative Influence");
						break;
					}
					this.lblCommand.Color = global::ARGBColors.Black;
					this.lblCommand.Position = new Point(525, 0);
					this.lblCommand.Size = new Size(300, this.backgroundImage.Height);
					this.lblCommand.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
					this.lblCommand.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.lblCommand);
				}
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(833, 0);
				this.lblArrivalTime.Size = new Size(114, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x0600058D RID: 1421 RVA: 0x0006CECC File Offset: 0x0006B0CC
			public bool update(double localTime)
			{
				if (GameEngine.Instance.World.getPerson(this.m_armyID) == null)
				{
					return false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				int num = (int)((this.m_arrivalTime - currentServerTime).TotalSeconds + 0.5);
				if (num < 1)
				{
					return false;
				}
				this.lblArrivalTime.Text = VillageMap.createBuildTimeString(num);
				if (this.m_returning)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblArrivalTime;
					csdlabel.Text = csdlabel.Text + " (" + SK.Text("AllArmiesSentLine_Return_Abbreviation", "Rtrn") + ")";
				}
				return true;
			}

			// Token: 0x0600058E RID: 1422 RVA: 0x0006CF70 File Offset: 0x0006B170
			private void lblVillage_Click()
			{
				if (this.leftVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.leftVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.leftVillageID, false, true, true, false);
				}
			}

			// Token: 0x0600058F RID: 1423 RVA: 0x0006CFFC File Offset: 0x0006B1FC
			private void lblTarget_Click()
			{
				if (this.rightVillageID >= 0)
				{
					Point villageLocation = GameEngine.Instance.World.getVillageLocation(this.rightVillageID);
					InterfaceMgr.Instance.changeTab(9);
					InterfaceMgr.Instance.changeTab(0);
					InterfaceMgr.Instance.closeParishPanel();
					GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
					InterfaceMgr.Instance.displaySelectedVillagePanel(this.rightVillageID, false, true, true, false);
				}
			}

			// Token: 0x040006CD RID: 1741
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040006CE RID: 1742
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006CF RID: 1743
			private CustomSelfDrawPanel.CSDLabel lblTarget = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006D0 RID: 1744
			private CustomSelfDrawPanel.CSDLabel lblMonks = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006D1 RID: 1745
			private CustomSelfDrawPanel.CSDLabel lblCommand = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006D2 RID: 1746
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040006D3 RID: 1747
			private int m_position = -1000;

			// Token: 0x040006D4 RID: 1748
			private AllArmiesPanel2 m_parent;

			// Token: 0x040006D5 RID: 1749
			private int leftVillageID = -1;

			// Token: 0x040006D6 RID: 1750
			private int rightVillageID = -1;

			// Token: 0x040006D7 RID: 1751
			private int m_villageID = -1;

			// Token: 0x040006D8 RID: 1752
			private int m_otherVillageID = -1;

			// Token: 0x040006D9 RID: 1753
			private bool m_returning;

			// Token: 0x040006DA RID: 1754
			private long m_armyID = -1L;

			// Token: 0x040006DB RID: 1755
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x040006DC RID: 1756
			private WorldMap.LocalTrader m_army;
		}
	}
}
