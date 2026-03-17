using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020004EA RID: 1258
	public class VillageReinforcementsPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002F7A RID: 12154 RVA: 0x000227E6 File Offset: 0x000209E6
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x000227F6 File Offset: 0x000209F6
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002F7C RID: 12156 RVA: 0x00022806 File Offset: 0x00020A06
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002F7D RID: 12157 RVA: 0x00022818 File Offset: 0x00020A18
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002F7E RID: 12158 RVA: 0x00022825 File Offset: 0x00020A25
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06002F7F RID: 12159 RVA: 0x0002283F File Offset: 0x00020A3F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x0002284C File Offset: 0x00020A4C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002F81 RID: 12161 RVA: 0x00022859 File Offset: 0x00020A59
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002F82 RID: 12162 RVA: 0x0026D060 File Offset: 0x0026B260
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
			base.Name = "VillageReinforcementsPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002F83 RID: 12163 RVA: 0x0026D14C File Offset: 0x0026B34C
		public VillageReinforcementsPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06002F84 RID: 12164 RVA: 0x0026D41C File Offset: 0x0026B61C
		public void init(bool resized)
		{
			int height = base.Height;
			this.yOffset = 0;
			if (this.m_selectedVillage >= 0)
			{
				this.yOffset = 276;
			}
			VillageReinforcementsPanel2.instance = this;
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
			if (this.m_selectedVillage >= 0)
			{
				this.cardbar.Position = new Point(0, 4);
				this.backgroundImage.addControl(this.cardbar);
				this.cardbar.init(6);
			}
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.CreateX(GFXLibrary.mail_top_drag_bar_left, GFXLibrary.mail_top_drag_bar_middle, GFXLibrary.mail_top_drag_bar_right, -2, 2);
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			this.parishNameLabel.Text = SK.Text("GENERIC_Reinforcements", "Reinforcements") + " : " + GameEngine.Instance.World.getVillageNameOrType(selectedMenuVillage);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			if (this.m_selectedVillage >= 0)
			{
				this.villageBackImage.Image = GFXLibrary.reinforce_back_left;
				this.villageBackImage.Position = new Point(105, 81);
				this.backgroundImage.addControl(this.villageBackImage);
				this.targetVillageLabel.Text = SK.Text("VillageReinforcementsPanel_Target_Village", "Target Village");
				this.targetVillageLabel.Color = global::ARGBColors.Black;
				this.targetVillageLabel.Position = new Point(0, 22);
				this.targetVillageLabel.Size = new Size(this.villageBackImage.Width, 40);
				this.targetVillageLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.targetVillageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.villageBackImage.addControl(this.targetVillageLabel);
				this.targetVillageName.Text = GameEngine.Instance.World.getVillageName(this.m_selectedVillage);
				this.targetVillageName.Color = global::ARGBColors.Black;
				this.targetVillageName.Position = new Point(0, 78);
				this.targetVillageName.Size = new Size(this.villageBackImage.Width, 80);
				this.targetVillageName.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.targetVillageName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
				this.villageBackImage.addControl(this.targetVillageName);
				this.targetVillageImage.Image = GFXLibrary.scout_screen_icons[GameEngine.Instance.World.getVillageSize(this.m_selectedVillage)];
				this.targetVillageImage.Position = new Point(48, 42);
				this.villageBackImage.addControl(this.targetVillageImage);
				this.trackBackImage.Image = GFXLibrary.reinforce_back_right;
				this.trackBackImage.Position = new Point(427, 80);
				this.backgroundImage.addControl(this.trackBackImage);
				int num = 14;
				this.peasantName.Text = SK.Text("GENERIC_Peasants", "Peasants");
				this.peasantName.Position = new Point(-50, num);
				this.peasantName.Size = new Size(142, 40);
				this.peasantName.Color = global::ARGBColors.Black;
				this.peasantName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.peasantName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.peasantName);
				this.archerName.Text = SK.Text("GENERIC_Archers", "Archers");
				this.archerName.Position = new Point(-50, num + 40);
				this.archerName.Size = new Size(142, 40);
				this.archerName.Color = global::ARGBColors.Black;
				this.archerName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.archerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.archerName);
				this.pikemanName.Text = SK.Text("GENERIC_Pikemen", "Pikemen");
				this.pikemanName.Position = new Point(-50, num + 80);
				this.pikemanName.Size = new Size(142, 40);
				this.pikemanName.Color = global::ARGBColors.Black;
				this.pikemanName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pikemanName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.pikemanName);
				this.swordsmanName.Text = SK.Text("GENERIC_Swordsmen", "Swordsmen");
				this.swordsmanName.Position = new Point(-50, num + 120);
				this.swordsmanName.Size = new Size(142, 40);
				this.swordsmanName.Color = global::ARGBColors.Black;
				this.swordsmanName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.swordsmanName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.swordsmanName);
				this.peasantStoredValue.Text = "0";
				this.peasantStoredValue.Position = new Point(56, num);
				this.peasantStoredValue.Size = new Size(142, 40);
				this.peasantStoredValue.Color = global::ARGBColors.Black;
				this.peasantStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.peasantStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.peasantStoredValue);
				this.archerStoredValue.Text = "0";
				this.archerStoredValue.Position = new Point(56, num + 40);
				this.archerStoredValue.Size = new Size(142, 40);
				this.archerStoredValue.Color = global::ARGBColors.Black;
				this.archerStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.archerStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.archerStoredValue);
				this.pikemanStoredValue.Text = "0";
				this.pikemanStoredValue.Position = new Point(56, num + 80);
				this.pikemanStoredValue.Size = new Size(142, 40);
				this.pikemanStoredValue.Color = global::ARGBColors.Black;
				this.pikemanStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pikemanStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.pikemanStoredValue);
				this.swordsmanStoredValue.Text = "0";
				this.swordsmanStoredValue.Position = new Point(56, num + 120);
				this.swordsmanStoredValue.Size = new Size(142, 40);
				this.swordsmanStoredValue.Color = global::ARGBColors.Black;
				this.swordsmanStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.swordsmanStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.swordsmanStoredValue);
				this.peasantSendValue.Text = "0";
				this.peasantSendValue.Position = new Point(56, num);
				this.peasantSendValue.Size = new Size(402, 40);
				this.peasantSendValue.Color = global::ARGBColors.Black;
				this.peasantSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.peasantSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.peasantSendValue);
				this.archerSendValue.Text = "0";
				this.archerSendValue.Position = new Point(56, num + 40);
				this.archerSendValue.Size = new Size(402, 40);
				this.archerSendValue.Color = global::ARGBColors.Black;
				this.archerSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.archerSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.archerSendValue);
				this.pikemanSendValue.Text = "0";
				this.pikemanSendValue.Position = new Point(56, num + 80);
				this.pikemanSendValue.Size = new Size(402, 40);
				this.pikemanSendValue.Color = global::ARGBColors.Black;
				this.pikemanSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.pikemanSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.pikemanSendValue);
				this.swordsmanSendValue.Text = "0";
				this.swordsmanSendValue.Position = new Point(56, num + 120);
				this.swordsmanSendValue.Size = new Size(402, 40);
				this.swordsmanSendValue.Color = global::ARGBColors.Black;
				this.swordsmanSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.swordsmanSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.trackBackImage.addControl(this.swordsmanSendValue);
				this.peasantsTrack.Position = new Point(207, 15);
				this.peasantsTrack.Size = new Size(203, 23);
				this.peasantsTrack.Max = 100;
				if (!resized)
				{
					this.peasantsTrack.Value = 0;
				}
				this.peasantsTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
				this.trackBackImage.addControl(this.peasantsTrack);
				this.peasantsTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
				this.peasantsEditButton.ImageNorm = GFXLibrary.faction_pen;
				this.peasantsEditButton.ImageOver = GFXLibrary.faction_pen;
				this.peasantsEditButton.ImageClick = GFXLibrary.faction_pen;
				this.peasantsEditButton.MoveOnClick = true;
				this.peasantsEditButton.OverBrighten = true;
				this.peasantsEditButton.Position = new Point(420, 12);
				this.peasantsEditButton.Data = 1;
				this.peasantsEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
				this.trackBackImage.addControl(this.peasantsEditButton);
				this.archerTrack.Position = new Point(207, 55);
				this.archerTrack.Size = new Size(203, 23);
				this.archerTrack.Max = 100;
				if (!resized)
				{
					this.archerTrack.Value = 0;
				}
				this.archerTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
				this.trackBackImage.addControl(this.archerTrack);
				this.archerTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
				this.archerEditButton.ImageNorm = GFXLibrary.faction_pen;
				this.archerEditButton.ImageOver = GFXLibrary.faction_pen;
				this.archerEditButton.ImageClick = GFXLibrary.faction_pen;
				this.archerEditButton.MoveOnClick = true;
				this.archerEditButton.OverBrighten = true;
				this.archerEditButton.Position = new Point(420, 52);
				this.archerEditButton.Data = 2;
				this.archerEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
				this.trackBackImage.addControl(this.archerEditButton);
				this.pikemanTrack.Position = new Point(207, 95);
				this.pikemanTrack.Size = new Size(203, 23);
				this.pikemanTrack.Max = 100;
				if (!resized)
				{
					this.pikemanTrack.Value = 0;
				}
				this.pikemanTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
				this.trackBackImage.addControl(this.pikemanTrack);
				this.pikemanTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
				this.pikemanEditButton.ImageNorm = GFXLibrary.faction_pen;
				this.pikemanEditButton.ImageOver = GFXLibrary.faction_pen;
				this.pikemanEditButton.ImageClick = GFXLibrary.faction_pen;
				this.pikemanEditButton.MoveOnClick = true;
				this.pikemanEditButton.OverBrighten = true;
				this.pikemanEditButton.Position = new Point(420, 92);
				this.pikemanEditButton.Data = 3;
				this.pikemanEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
				this.trackBackImage.addControl(this.pikemanEditButton);
				this.swordsmanTrack.Position = new Point(207, 135);
				this.swordsmanTrack.Size = new Size(203, 23);
				this.swordsmanTrack.Max = 100;
				if (!resized)
				{
					this.swordsmanTrack.Value = 0;
				}
				this.swordsmanTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
				this.trackBackImage.addControl(this.swordsmanTrack);
				this.swordsmanTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
				this.swordsmanEditButton.ImageNorm = GFXLibrary.faction_pen;
				this.swordsmanEditButton.ImageOver = GFXLibrary.faction_pen;
				this.swordsmanEditButton.ImageClick = GFXLibrary.faction_pen;
				this.swordsmanEditButton.MoveOnClick = true;
				this.swordsmanEditButton.OverBrighten = true;
				this.swordsmanEditButton.Position = new Point(420, 132);
				this.swordsmanEditButton.Data = 4;
				this.swordsmanEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
				this.trackBackImage.addControl(this.swordsmanEditButton);
				this.btnSend.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
				this.btnSend.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
				this.btnSend.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
				this.btnSend.Position = new Point(360, 165);
				this.btnSend.Text.Text = SK.Text("VassalArmiesPanel_", "Send");
				this.btnSend.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.btnSend.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.btnSend.TextYOffset = -3;
				this.btnSend.Text.Color = global::ARGBColors.Black;
				this.btnSend.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendClick), "VillageReinforcementsPanel2_send");
				this.btnSend.Enabled = false;
				this.trackBackImage.addControl(this.btnSend);
				this.updateValues();
			}
			this.blockYSize = (height - this.yOffset - 40 - 56) / 2;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5 + this.yOffset);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider2Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(300, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(553, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.outGoingAttacksLabel.Text = SK.Text("VillageArmiesPanel_Target_Village", "Target Village");
			this.outGoingAttacksLabel.Color = global::ARGBColors.Black;
			this.outGoingAttacksLabel.Position = new Point(12, -2);
			this.outGoingAttacksLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.outGoingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingAttacksLabel);
			this.outGoingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.outGoingArrivesLabel.Color = global::ARGBColors.Black;
			this.outGoingArrivesLabel.Position = new Point(558, -2);
			this.outGoingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.outGoingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.outGoingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.outGoingArrivesLabel);
			this.headerLabelsImage2.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage2.Position = new Point(25, this.blockYSize + 5 + this.yOffset);
			this.backgroundImage.addControl(this.headerLabelsImage2);
			this.headerLabelsImage2.Create(GFXLibrary.brown_mail2_field_bar_mail_left, GFXLibrary.brown_mail2_field_bar_mail_middle, GFXLibrary.brown_mail2_field_bar_mail_right);
			this.divider5Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider5Image.Position = new Point(300, 0);
			this.headerLabelsImage2.addControl(this.divider5Image);
			this.divider6Image.Image = GFXLibrary.brown_mail2_field_bar_mail_divider;
			this.divider6Image.Position = new Point(553, 0);
			this.headerLabelsImage2.addControl(this.divider6Image);
			this.incomingAttacksLabel.Text = SK.Text("VillageArmiesPanel_From", "From") + ":";
			this.incomingAttacksLabel.Color = global::ARGBColors.Black;
			this.incomingAttacksLabel.Position = new Point(12, -2);
			this.incomingAttacksLabel.Size = new Size(224, this.headerLabelsImage.Height);
			this.incomingAttacksLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingAttacksLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingAttacksLabel);
			this.incomingArrivesLabel.Text = SK.Text("AllArmiesPanel_Arrives", "Arrives");
			this.incomingArrivesLabel.Color = global::ARGBColors.Black;
			this.incomingArrivesLabel.Position = new Point(558, -2);
			this.incomingArrivesLabel.Size = new Size(114, this.headerLabelsImage.Height);
			this.incomingArrivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.incomingArrivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage2.addControl(this.incomingArrivesLabel);
			this.outgoingScrollArea.Position = new Point(25, 40 + this.yOffset);
			this.outgoingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.outgoingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.outgoingScrollArea);
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollBar.Position = new Point(943, 40 + this.yOffset);
			this.outgoingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.outgoingScrollBar);
			this.outgoingScrollBar.Value = 0;
			this.outgoingScrollBar.Max = 100;
			this.outgoingScrollBar.NumVisibleLines = 25;
			this.outgoingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.outgoingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.incomingScrollArea.Position = new Point(25, 35 + this.blockYSize + 5 + this.yOffset);
			this.incomingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.incomingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.incomingScrollArea);
			int value2 = this.incomingScrollBar.Value;
			this.incomingScrollBar.Position = new Point(943, 35 + this.blockYSize + 5 + this.yOffset);
			this.incomingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.incomingScrollBar);
			this.incomingScrollBar.Value = 0;
			this.incomingScrollBar.Max = 100;
			this.incomingScrollBar.NumVisibleLines = 25;
			this.incomingScrollBar.Create(null, null, null, GFXLibrary.brown_24wide_thumb_top, GFXLibrary.brown_24wide_thumb_middle, GFXLibrary.brown_24wide_thumb_bottom);
			this.incomingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.incomingWallScrollBarMoved));
			this.smallPeasantImage.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage.Position = new Point(323, -10);
			this.smallPeasantImage.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Width - 120, this.smallPeasantImage.Height);
			this.headerLabelsImage.addControl(this.smallPeasantImage);
			this.smallPeasantImage2.Image = GFXLibrary.armies_screen_troops;
			this.smallPeasantImage2.Position = new Point(323, -10);
			this.smallPeasantImage2.ClipRect = new Rectangle(0, 0, this.smallPeasantImage.Width - 120, this.smallPeasantImage.Height);
			this.headerLabelsImage2.addControl(this.smallPeasantImage2);
			if (!resized)
			{
				SparseArray reinforcementsArray = GameEngine.Instance.World.getReinforcementsArray();
				this.reinforcementList.Clear();
				foreach (object obj in reinforcementsArray)
				{
					WorldMap.LocalArmyData item = (WorldMap.LocalArmyData)obj;
					this.reinforcementList.Add(item);
				}
				this.reinforcementList.Sort(this.armyComparer);
			}
			this.addArmies();
			if (resized)
			{
				this.outgoingScrollBar.Value = value;
				this.incomingScrollBar.Value = value2;
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
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "VillageReinforcementsPanel2_close");
			this.backgroundImage.addControl(this.btnClose);
		}

		// Token: 0x06002F85 RID: 12165 RVA: 0x0026EEA4 File Offset: 0x0026D0A4
		public void update()
		{
			if (this.m_selectedVillage >= 0)
			{
				this.cardbar.update();
			}
			bool flag = false;
			double localTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (VillageReinforcementsPanel2.ArmyLine armyLine in this.lineList)
			{
				if (!armyLine.update(localTime))
				{
					flag = true;
				}
			}
			foreach (VillageReinforcementsPanel2.ArmyLine armyLine2 in this.lineList2)
			{
				if (!armyLine2.update(localTime))
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.init(false);
			}
		}

		// Token: 0x06002F86 RID: 12166 RVA: 0x0026EF78 File Offset: 0x0026D178
		public void updateValues()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.peasantStoredValue.Text = village.m_numPeasants.ToString();
				this.archerStoredValue.Text = village.m_numArchers.ToString();
				this.pikemanStoredValue.Text = village.m_numPikemen.ToString();
				this.swordsmanStoredValue.Text = village.m_numSwordsmen.ToString();
				this.peasantsTrack.Max = village.m_numPeasants;
				this.archerTrack.Max = village.m_numArchers;
				this.pikemanTrack.Max = village.m_numPikemen;
				this.swordsmanTrack.Max = village.m_numSwordsmen;
				this.updateSlider();
			}
		}

		// Token: 0x06002F87 RID: 12167 RVA: 0x0026F038 File Offset: 0x0026D238
		public void updateSlider()
		{
			this.peasantSendValue.Text = this.peasantsTrack.Value.ToString();
			this.archerSendValue.Text = this.archerTrack.Value.ToString();
			this.pikemanSendValue.Text = this.pikemanTrack.Value.ToString();
			this.swordsmanSendValue.Text = this.swordsmanTrack.Value.ToString();
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value;
				if (num > 0 && village.VillageID != this.m_selectedVillage)
				{
					this.btnSend.Enabled = true;
					return;
				}
				this.btnSend.Enabled = false;
			}
		}

		// Token: 0x06002F88 RID: 12168 RVA: 0x00022878 File Offset: 0x00020A78
		public void tracksMoved()
		{
			this.updateSlider();
		}

		// Token: 0x06002F89 RID: 12169 RVA: 0x0026F128 File Offset: 0x0026D328
		private void editSendValue()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int num = 252;
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
			}
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.setTrackCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(base.Location.X + 870, base.Location.Y + num));
			FloatingInput.open(point.X, point.Y, this.currentTrack.Value, this.currentTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06002F8A RID: 12170 RVA: 0x00022880 File Offset: 0x00020A80
		private void setTrackCB(int value)
		{
			if (this.currentTrack != null)
			{
				this.currentTrack.Value = value;
				this.updateSlider();
			}
		}

		// Token: 0x06002F8B RID: 12171 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06002F8C RID: 12172 RVA: 0x0026F234 File Offset: 0x0026D434
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 40 + this.yOffset - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06002F8D RID: 12173 RVA: 0x0026F2D4 File Offset: 0x0026D4D4
		private void incomingWallScrollBarMoved()
		{
			int value = this.incomingScrollBar.Value;
			this.incomingScrollArea.Position = new Point(this.incomingScrollArea.X, 35 + this.blockYSize + 5 + this.yOffset - value);
			this.incomingScrollArea.ClipRect = new Rectangle(this.incomingScrollArea.ClipRect.X, value, this.incomingScrollArea.ClipRect.Width, this.incomingScrollArea.ClipRect.Height);
			this.incomingScrollArea.invalidate();
			this.incomingScrollBar.invalidate();
		}

		// Token: 0x06002F8E RID: 12174 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06002F8F RID: 12175 RVA: 0x0026F37C File Offset: 0x0026D57C
		public void addArmies()
		{
			this.outgoingScrollArea.clearControls();
			this.incomingScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.lineList.Clear();
			this.lineList2.Clear();
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int num3 = 0;
			int num4 = 0;
			double num5 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (WorldMap.LocalArmyData localArmyData in this.reinforcementList)
			{
				if (localArmyData.homeVillageID == selectedMenuVillage)
				{
					VillageReinforcementsPanel2.ArmyLine armyLine = new VillageReinforcementsPanel2.ArmyLine();
					if (num != 0)
					{
						num += 5;
					}
					armyLine.Position = new Point(0, num);
					armyLine.initSent(num3, localArmyData.targetVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, 0, localArmyData.serverEndTime, localArmyData.armyID, localArmyData.attackType == 20, this, localArmyData.attackType == 21);
					this.outgoingScrollArea.addControl(armyLine);
					num += armyLine.Height;
					this.lineList.Add(armyLine);
					num3++;
				}
				if (localArmyData.targetVillageID == selectedMenuVillage && localArmyData.attackType == 20)
				{
					VillageReinforcementsPanel2.ArmyLine armyLine2 = new VillageReinforcementsPanel2.ArmyLine();
					if (num2 != 0)
					{
						num2 += 5;
					}
					armyLine2.Position = new Point(0, num2);
					armyLine2.initIncoming(num4, localArmyData.homeVillageID, localArmyData.numPeasants, localArmyData.numArchers, localArmyData.numPikemen, localArmyData.numSwordsmen, localArmyData.numCatapults, 0, localArmyData.serverEndTime, localArmyData.armyID, true, this, localArmyData.attackType == 21);
					this.incomingScrollArea.addControl(armyLine2);
					num2 += armyLine2.Height;
					this.lineList2.Add(armyLine2);
					num4++;
				}
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

		// Token: 0x06002F90 RID: 12176 RVA: 0x0002289C File Offset: 0x00020A9C
		private void closeClick()
		{
			if (!InterfaceMgr.Instance.isSelectedVillageACapital())
			{
				InterfaceMgr.Instance.setVillageTabSubMode(4);
				return;
			}
			InterfaceMgr.Instance.setVillageTabSubMode(1004);
		}

		// Token: 0x06002F91 RID: 12177 RVA: 0x0026F6A8 File Offset: 0x0026D8A8
		public void showPopup(long reinforcementID)
		{
			this.closePopup();
			WorldMap.LocalArmyData reinforcement = GameEngine.Instance.World.getReinforcement(reinforcementID);
			if (reinforcement != null)
			{
				this.popup = new ReinforcementsRetrievalPopup();
				this.popup.init(this, reinforcementID, reinforcement.numPeasants, reinforcement.numArchers, reinforcement.numPikemen, reinforcement.numSwordsmen, reinforcement.numCatapults);
				this.popup.Show();
			}
		}

		// Token: 0x06002F92 RID: 12178 RVA: 0x000228C5 File Offset: 0x00020AC5
		public void closePopup()
		{
			if (this.popup != null && this.popup.Created)
			{
				this.popup.Close();
				this.popup = null;
			}
		}

		// Token: 0x06002F93 RID: 12179 RVA: 0x000228EE File Offset: 0x00020AEE
		public void resume()
		{
			this.setReinforcementVillage(this.m_selectedVillage);
		}

		// Token: 0x06002F94 RID: 12180 RVA: 0x000228FC File Offset: 0x00020AFC
		public void setReinforcementVillage(int villageID)
		{
			if (villageID >= 0)
			{
				this.m_selectedVillage = villageID;
			}
			else
			{
				this.m_selectedVillage = -1;
			}
			this.init(false);
		}

		// Token: 0x06002F95 RID: 12181 RVA: 0x0026F710 File Offset: 0x0026D910
		private void sendClick()
		{
			int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value;
			if (num > 0)
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					RemoteServices.Instance.set_SendReinforcements_UserCallBack(new RemoteServices.SendReinforcements_UserCallBack(this.sendReinforcementsCallback));
					RemoteServices.Instance.SendReinforcements(village.VillageID, this.m_selectedVillage, this.peasantsTrack.Value, this.archerTrack.Value, this.pikemanTrack.Value, this.swordsmanTrack.Value, 0);
				}
			}
		}

		// Token: 0x06002F96 RID: 12182 RVA: 0x0026F7B8 File Offset: 0x0026D9B8
		public void sendReinforcementsCallback(SendReinforcements_ReturnType returnData)
		{
			if (returnData.Success)
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null && village.VillageID == returnData.villageID)
				{
					village.importResourcesAndStats(returnData.villageResourcesAndStats, returnData.currentTime);
				}
				GameEngine.Instance.World.addReinforcementArmy(returnData.armyData);
				this.resume();
			}
		}

		// Token: 0x04003BB3 RID: 15283
		private const int extraYForCards = 76;

		// Token: 0x04003BB4 RID: 15284
		private DockableControl dockableControl;

		// Token: 0x04003BB5 RID: 15285
		private IContainer components;

		// Token: 0x04003BB6 RID: 15286
		private Panel focusPanel;

		// Token: 0x04003BB7 RID: 15287
		public static VillageReinforcementsPanel2 instance;

		// Token: 0x04003BB8 RID: 15288
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04003BB9 RID: 15289
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003BBA RID: 15290
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BBB RID: 15291
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BBC RID: 15292
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BBD RID: 15293
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003BBE RID: 15294
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BBF RID: 15295
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BC0 RID: 15296
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BC1 RID: 15297
		private CustomSelfDrawPanel.CSDImage divider4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BC2 RID: 15298
		private CustomSelfDrawPanel.CSDImage divider5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BC3 RID: 15299
		private CustomSelfDrawPanel.CSDImage divider6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BC4 RID: 15300
		private CustomSelfDrawPanel.CSDLabel outGoingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BC5 RID: 15301
		private CustomSelfDrawPanel.CSDLabel outGoingFromLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BC6 RID: 15302
		private CustomSelfDrawPanel.CSDLabel outGoingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BC7 RID: 15303
		private CustomSelfDrawPanel.CSDLabel incomingAttacksLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BC8 RID: 15304
		private CustomSelfDrawPanel.CSDLabel incomingAttackingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BC9 RID: 15305
		private CustomSelfDrawPanel.CSDLabel incomingArrivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BCA RID: 15306
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage2 = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003BCB RID: 15307
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003BCC RID: 15308
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003BCD RID: 15309
		private CustomSelfDrawPanel.CSDVertScrollBar incomingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003BCE RID: 15310
		private CustomSelfDrawPanel.CSDArea incomingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003BCF RID: 15311
		private CustomSelfDrawPanel.CSDLabel diplomacyHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BD0 RID: 15312
		private CustomSelfDrawPanel.CSDLabel diplomacyTextLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BD1 RID: 15313
		private CustomSelfDrawPanel.CSDImage smallPeasantImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BD2 RID: 15314
		private CustomSelfDrawPanel.CSDImage smallPeasantImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BD3 RID: 15315
		private CustomSelfDrawPanel.CSDImage villageBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BD4 RID: 15316
		private CustomSelfDrawPanel.CSDImage trackBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BD5 RID: 15317
		private CustomSelfDrawPanel.CSDLabel targetVillageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BD6 RID: 15318
		private CustomSelfDrawPanel.CSDLabel targetVillageName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BD7 RID: 15319
		private CustomSelfDrawPanel.CSDImage targetVillageImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003BD8 RID: 15320
		private CustomSelfDrawPanel.CSDLabel peasantName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BD9 RID: 15321
		private CustomSelfDrawPanel.CSDLabel archerName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDA RID: 15322
		private CustomSelfDrawPanel.CSDLabel pikemanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDB RID: 15323
		private CustomSelfDrawPanel.CSDLabel swordsmanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDC RID: 15324
		private CustomSelfDrawPanel.CSDLabel peasantStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDD RID: 15325
		private CustomSelfDrawPanel.CSDLabel archerStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDE RID: 15326
		private CustomSelfDrawPanel.CSDLabel pikemanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BDF RID: 15327
		private CustomSelfDrawPanel.CSDLabel swordsmanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BE0 RID: 15328
		private CustomSelfDrawPanel.CSDLabel peasantSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BE1 RID: 15329
		private CustomSelfDrawPanel.CSDLabel archerSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BE2 RID: 15330
		private CustomSelfDrawPanel.CSDLabel pikemanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BE3 RID: 15331
		private CustomSelfDrawPanel.CSDLabel swordsmanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BE4 RID: 15332
		private CustomSelfDrawPanel.CSDTrackBar peasantsTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003BE5 RID: 15333
		private CustomSelfDrawPanel.CSDTrackBar archerTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003BE6 RID: 15334
		private CustomSelfDrawPanel.CSDTrackBar pikemanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003BE7 RID: 15335
		private CustomSelfDrawPanel.CSDTrackBar swordsmanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003BE8 RID: 15336
		private CustomSelfDrawPanel.CSDButton peasantsEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BE9 RID: 15337
		private CustomSelfDrawPanel.CSDButton archerEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BEA RID: 15338
		private CustomSelfDrawPanel.CSDButton pikemanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BEB RID: 15339
		private CustomSelfDrawPanel.CSDButton swordsmanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BEC RID: 15340
		private CustomSelfDrawPanel.CSDButton catapultEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BED RID: 15341
		private CustomSelfDrawPanel.CSDButton btnSend = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BEE RID: 15342
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003BEF RID: 15343
		private int blockYSize;

		// Token: 0x04003BF0 RID: 15344
		private List<WorldMap.LocalArmyData> reinforcementList = new List<WorldMap.LocalArmyData>();

		// Token: 0x04003BF1 RID: 15345
		private int m_selectedVillage = -1;

		// Token: 0x04003BF2 RID: 15346
		private int yOffset;

		// Token: 0x04003BF3 RID: 15347
		private CustomSelfDrawPanel.CSDTrackBar currentTrack;

		// Token: 0x04003BF4 RID: 15348
		private List<VillageReinforcementsPanel2.ArmyLine> lineList = new List<VillageReinforcementsPanel2.ArmyLine>();

		// Token: 0x04003BF5 RID: 15349
		private List<VillageReinforcementsPanel2.ArmyLine> lineList2 = new List<VillageReinforcementsPanel2.ArmyLine>();

		// Token: 0x04003BF6 RID: 15350
		private VillageReinforcementsPanel2.ArmyComparer armyComparer = new VillageReinforcementsPanel2.ArmyComparer();

		// Token: 0x04003BF7 RID: 15351
		private ReinforcementsRetrievalPopup popup;

		// Token: 0x020004EB RID: 1259
		public class ArmyComparer : IComparer<WorldMap.LocalArmyData>
		{
			// Token: 0x06002F97 RID: 12183 RVA: 0x0001D3B7 File Offset: 0x0001B5B7
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

		// Token: 0x020004EC RID: 1260
		public class ArmyLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002F99 RID: 12185 RVA: 0x0026F818 File Offset: 0x0026DA18
			public void initSent(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageReinforcementsPanel2 parent, bool returning)
			{
				this.m_sent = true;
				this.initText(position, villageID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, 0);
			}

			// Token: 0x06002F9A RID: 12186 RVA: 0x0026F84C File Offset: 0x0026DA4C
			public void initIncoming(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageReinforcementsPanel2 parent, bool returning)
			{
				this.m_sent = false;
				this.initText(position, villageID, numPeasants, numArchers, numPikemen, numSwordsmen, numCatapults, numScouts, arrivalTime, armyID, showButton, parent, returning, true, false, 0);
			}

			// Token: 0x06002F9B RID: 12187 RVA: 0x0026F880 File Offset: 0x0026DA80
			private void initText(int position, int villageID, int numPeasants, int numArchers, int numPikemen, int numSwordsmen, int numCatapults, int numScouts, DateTime arrivalTime, long armyID, bool showButton, VillageReinforcementsPanel2 parent, bool returning, bool showTroops, bool tutorial, int attackType)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.ClipVisible = true;
				this.m_reinforcement = GameEngine.Instance.World.getReinforcement(armyID);
				this.m_reinforcementID = armyID;
				this.m_villageID = villageID;
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
				this.lblVillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lblVillage_Click), "VillageReinforcementsPanel2_village");
				this.backgroundImage.addControl(this.lblVillage);
				this.lblReturning.Text = SK.Text("VillageArmySentLine_Returning", "Returning");
				this.lblReturning.Color = global::ARGBColors.Black;
				this.lblReturning.Position = new Point(821, 0);
				this.lblReturning.Size = new Size(110, this.backgroundImage.Height);
				this.lblReturning.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblReturning.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblReturning);
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (this.m_arrivalTime > currentServerTime)
				{
					this.m_moving = true;
					if (!this.m_sent)
					{
						showButton = false;
					}
				}
				else
				{
					this.m_moving = false;
				}
				if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
				{
					showButton = false;
				}
				this.lblReturning.Visible = !showButton;
				if (!showButton)
				{
					if (this.m_returning)
					{
						this.lblReturning.Text = SK.Text("VillageArmySentLine_Returning", "Returning");
					}
					else
					{
						this.lblReturning.Text = "";
					}
				}
				this.leftVillageID = villageID;
				this.lblArrivalTime.Text = "";
				this.lblArrivalTime.Color = global::ARGBColors.Black;
				this.lblArrivalTime.Position = new Point(558, 0);
				this.lblArrivalTime.Size = new Size(174, this.backgroundImage.Height);
				this.lblArrivalTime.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArrivalTime.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblArrivalTime);
				this.lblPeasants.Text = numPeasants.ToString();
				this.lblPeasants.Color = global::ARGBColors.Black;
				this.lblPeasants.Position = new Point(305, 0);
				this.lblPeasants.Size = new Size(55, this.backgroundImage.Height);
				this.lblPeasants.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPeasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblPeasants);
				this.lblArchers.Text = numArchers.ToString();
				this.lblArchers.Color = global::ARGBColors.Black;
				this.lblArchers.Position = new Point(365, 0);
				this.lblArchers.Size = new Size(55, this.backgroundImage.Height);
				this.lblArchers.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblArchers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblArchers);
				this.lblPikemen.Text = numPikemen.ToString();
				this.lblPikemen.Color = global::ARGBColors.Black;
				this.lblPikemen.Position = new Point(425, 0);
				this.lblPikemen.Size = new Size(55, this.backgroundImage.Height);
				this.lblPikemen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblPikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblPikemen);
				this.lblSwordsmen.Text = numSwordsmen.ToString();
				this.lblSwordsmen.Color = global::ARGBColors.Black;
				this.lblSwordsmen.Position = new Point(485, 0);
				this.lblSwordsmen.Size = new Size(55, this.backgroundImage.Height);
				this.lblSwordsmen.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblSwordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.backgroundImage.addControl(this.lblSwordsmen);
				if (showButton)
				{
					this.btnCancel.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
					this.btnCancel.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
					this.btnCancel.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
					this.btnCancel.Position = new Point(760, 3);
					if (this.m_sent)
					{
						this.btnCancel.Text.Text = SK.Text("VillageReinforcementSentLine_Retrieve", "Retrieve");
					}
					else
					{
						this.btnCancel.Text.Text = SK.Text("VillageReinforcementSentLine_Return", "Return");
					}
					this.btnCancel.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.btnCancel.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.btnCancel.TextYOffset = -3;
					this.btnCancel.Text.Color = global::ARGBColors.Black;
					this.btnCancel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelClick), "VillageReinforcementsPanel2_cancel");
					this.backgroundImage.addControl(this.btnCancel);
				}
				this.update(DXTimer.GetCurrentMilliseconds() / 1000.0);
				base.invalidate();
			}

			// Token: 0x06002F9C RID: 12188 RVA: 0x0026FF34 File Offset: 0x0026E134
			public bool update(double localTime)
			{
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
				}
				return true;
			}

			// Token: 0x06002F9D RID: 12189 RVA: 0x0026FFC4 File Offset: 0x0026E1C4
			private void cancelClick()
			{
				if (this.m_sent)
				{
					if (this.m_parent != null)
					{
						RemoteServices.Instance.set_ReturnReinforcements_UserCallBack(new RemoteServices.ReturnReinforcements_UserCallBack(this.returnReinforcementsCallBack));
						this.m_parent.showPopup(this.m_reinforcementID);
						return;
					}
				}
				else
				{
					RemoteServices.Instance.set_ReturnReinforcements_UserCallBack(new RemoteServices.ReturnReinforcements_UserCallBack(this.returnReinforcementsCallBack));
					RemoteServices.Instance.ReturnReinforcements(this.m_reinforcementID);
				}
			}

			// Token: 0x06002F9E RID: 12190 RVA: 0x00270030 File Offset: 0x0026E230
			private void returnReinforcementsCallBack(ReturnReinforcements_ReturnType returnData)
			{
				if (returnData.Success)
				{
					if (returnData.armyData != null)
					{
						GameEngine.Instance.World.addReinforcementArmy(returnData.armyData);
					}
					if (returnData.armyData2 != null)
					{
						GameEngine.Instance.World.addReinforcementArmy(returnData.armyData2);
					}
					if (this.m_parent != null)
					{
						this.m_parent.init(false);
					}
				}
			}

			// Token: 0x06002F9F RID: 12191 RVA: 0x00270094 File Offset: 0x0026E294
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

			// Token: 0x04003BF8 RID: 15352
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04003BF9 RID: 15353
			private CustomSelfDrawPanel.CSDLabel lblVillage = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFA RID: 15354
			private CustomSelfDrawPanel.CSDLabel lblReturning = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFB RID: 15355
			private CustomSelfDrawPanel.CSDLabel lblPeasants = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFC RID: 15356
			private CustomSelfDrawPanel.CSDLabel lblArchers = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFD RID: 15357
			private CustomSelfDrawPanel.CSDLabel lblPikemen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFE RID: 15358
			private CustomSelfDrawPanel.CSDLabel lblSwordsmen = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003BFF RID: 15359
			private CustomSelfDrawPanel.CSDLabel lblCatapults = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C00 RID: 15360
			private CustomSelfDrawPanel.CSDLabel lblArrivalTime = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04003C01 RID: 15361
			private CustomSelfDrawPanel.CSDButton btnCancel = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04003C02 RID: 15362
			private int m_position = -1000;

			// Token: 0x04003C03 RID: 15363
			private VillageReinforcementsPanel2 m_parent;

			// Token: 0x04003C04 RID: 15364
			private int leftVillageID = -1;

			// Token: 0x04003C05 RID: 15365
			private int m_villageID = -1;

			// Token: 0x04003C06 RID: 15366
			private bool m_returning;

			// Token: 0x04003C07 RID: 15367
			private long m_reinforcementID = -1L;

			// Token: 0x04003C08 RID: 15368
			private DateTime m_arrivalTime = DateTime.Now;

			// Token: 0x04003C09 RID: 15369
			private WorldMap.LocalArmyData m_reinforcement;

			// Token: 0x04003C0A RID: 15370
			private bool m_sent;

			// Token: 0x04003C0B RID: 15371
			private bool m_moving;
		}
	}
}
