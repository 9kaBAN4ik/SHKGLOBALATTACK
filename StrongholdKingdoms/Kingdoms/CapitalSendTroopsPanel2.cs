using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000106 RID: 262
	public class CapitalSendTroopsPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x000ABC70 File Offset: 0x000A9E70
		public CapitalSendTroopsPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x000ABE40 File Offset: 0x000AA040
		public void init(bool resized)
		{
			int height = base.Height;
			CapitalSendTroopsPanel2.instance = this;
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
			this.cardbar.Position = new Point(0, 4);
			this.backgroundImage.addControl(this.cardbar);
			this.cardbar.init(6);
			InterfaceMgr.Instance.getSelectedMenuVillage();
			this.parishNameLabel.Text = SK.Text("CapitalSendTroops_Send_Troops_To_Capital", "Send Troops to Capital") + " : " + GameEngine.Instance.World.getVillageNameOrType(this.m_selectedVillage);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.trackBackImage.Image = GFXLibrary.capital_troops_back;
			this.trackBackImage.Position = new Point(231, 80);
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
			this.catapultName.Text = SK.Text("GENERIC_Catapults", "Catapults");
			this.catapultName.Position = new Point(-50, num + 160);
			this.catapultName.Size = new Size(142, 40);
			this.catapultName.Color = global::ARGBColors.Black;
			this.catapultName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultName);
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
			this.catapultStoredValue.Text = "0";
			this.catapultStoredValue.Position = new Point(56, num + 160);
			this.catapultStoredValue.Size = new Size(142, 40);
			this.catapultStoredValue.Color = global::ARGBColors.Black;
			this.catapultStoredValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultStoredValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultStoredValue);
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
			this.catapultSendValue.Text = "0";
			this.catapultSendValue.Position = new Point(56, num + 160);
			this.catapultSendValue.Size = new Size(402, 40);
			this.catapultSendValue.Color = global::ARGBColors.Black;
			this.catapultSendValue.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.catapultSendValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.trackBackImage.addControl(this.catapultSendValue);
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
			this.catapultTrack.Position = new Point(207, 175);
			this.catapultTrack.Size = new Size(203, 23);
			this.catapultTrack.Max = 100;
			if (!resized)
			{
				this.catapultTrack.Value = 0;
			}
			this.catapultTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.trackBackImage.addControl(this.catapultTrack);
			this.catapultTrack.Create(null, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider, GFXLibrary.reinforce_slider);
			this.catapultEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.catapultEditButton.ImageOver = GFXLibrary.faction_pen;
			this.catapultEditButton.ImageClick = GFXLibrary.faction_pen;
			this.catapultEditButton.MoveOnClick = true;
			this.catapultEditButton.OverBrighten = true;
			this.catapultEditButton.Position = new Point(420, 172);
			this.catapultEditButton.Data = 5;
			this.catapultEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "SendArmyPanel_editValue");
			this.trackBackImage.addControl(this.catapultEditButton);
			this.btnSend.ImageNorm = GFXLibrary.brown_mail2_button_blue_141wide_normal;
			this.btnSend.ImageOver = GFXLibrary.brown_mail2_button_blue_141wide_over;
			this.btnSend.ImageClick = GFXLibrary.brown_mail2_button_blue_141wide_pushed;
			this.btnSend.Position = new Point(360, 205);
			this.btnSend.Text.Text = SK.Text("VassalArmiesPanel_", "Send");
			this.btnSend.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnSend.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnSend.TextYOffset = -3;
			this.btnSend.Text.Color = global::ARGBColors.Black;
			this.btnSend.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendClick), "CapitalSendTroopsPanel2_send");
			this.btnSend.Enabled = false;
			this.trackBackImage.addControl(this.btnSend);
			this.updateValues();
			this.barrackSpaceLabel.Text = SK.Text("CapitalSendTroops_Current_Barracks_Space", "Current Barracks Space") + " : 0";
			this.barrackSpaceLabel.Position = new Point(0, 335);
			this.barrackSpaceLabel.Size = new Size(base.Width, 40);
			this.barrackSpaceLabel.Color = global::ARGBColors.Black;
			this.barrackSpaceLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.barrackSpaceLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundImage.addControl(this.barrackSpaceLabel);
			this.warningLabel.Text = SK.Text("CapitalSendTroops_Warning", "Warning: Once the barracks is full any other troops sent will be lost");
			this.warningLabel.Position = new Point(0, 365);
			this.warningLabel.Size = new Size(base.Width, 40);
			this.warningLabel.Color = global::ARGBColors.Black;
			this.warningLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.warningLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.backgroundImage.addControl(this.warningLabel);
			this.btnClose.ImageNorm = GFXLibrary.brown_misc_button_blue_210wide_normal;
			this.btnClose.ImageOver = GFXLibrary.brown_misc_button_blue_210wide_over;
			this.btnClose.ImageClick = GFXLibrary.brown_misc_button_blue_210wide_pushed;
			this.btnClose.Position = new Point(base.Width - 230, height - 40 - 40 - 4);
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.btnClose.TextYOffset = -3;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CapitalSendTroopsPanel2_close");
			this.backgroundImage.addControl(this.btnClose);
			if (!resized)
			{
				this.barrackSpace = 0;
				if (this.m_selectedVillage >= 0)
				{
					RemoteServices.Instance.set_GetCapitalBarracksSpace_UserCallBack(new RemoteServices.GetCapitalBarracksSpace_UserCallBack(this.GetCapitalBarracksSpaceCallBack));
					RemoteServices.Instance.GetCapitalBarracksSpace(InterfaceMgr.Instance.getSelectedMenuVillage(), this.m_selectedVillage);
					return;
				}
			}
			else
			{
				this.barrackSpaceLabel.Text = SK.Text("CapitalSendTroops_Current_Barracks_Space", "Current Barracks Space") + " : " + this.barrackSpace.ToString();
			}
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x000AD324 File Offset: 0x000AB524
		private void GetCapitalBarracksSpaceCallBack(GetCapitalBarracksSpace_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.barrackSpace = returnData.currentBarracksSpace;
				if (returnData.currentBarracksSpace >= 0)
				{
					this.barrackSpaceLabel.Text = SK.Text("CapitalSendTroops_Current_Barracks_Space", "Current Barracks Space") + " : " + this.barrackSpace.ToString();
					return;
				}
				this.barrackSpaceLabel.Text = SK.Text("CapitalSendTroops_Current_Barracks_Space", "Current Barracks Space") + " : 0";
			}
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0000CB6D File Offset: 0x0000AD6D
		public void update()
		{
			this.cardbar.update();
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x000AD3A4 File Offset: 0x000AB5A4
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
				this.peasantsTrack.Max = village.m_numPeasants;
				this.archerTrack.Max = village.m_numArchers;
				this.pikemanTrack.Max = village.m_numPikemen;
				this.swordsmanTrack.Max = village.m_numSwordsmen;
				this.catapultTrack.Max = village.m_numCatapults;
				this.updateSlider();
			}
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x000AD48C File Offset: 0x000AB68C
		public void updateSlider()
		{
			this.peasantSendValue.Text = this.peasantsTrack.Value.ToString();
			this.archerSendValue.Text = this.archerTrack.Value.ToString();
			this.pikemanSendValue.Text = this.pikemanTrack.Value.ToString();
			this.swordsmanSendValue.Text = this.swordsmanTrack.Value.ToString();
			this.catapultSendValue.Text = this.catapultTrack.Value.ToString();
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value + this.catapultTrack.Value;
				if (num > 0 && village.VillageID != this.m_selectedVillage)
				{
					this.btnSend.Enabled = true;
					return;
				}
				this.btnSend.Enabled = false;
			}
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0000CB7B File Offset: 0x0000AD7B
		public void tracksMoved()
		{
			this.updateSlider();
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x000AD5A4 File Offset: 0x000AB7A4
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
			case 5:
				this.currentTrack = this.catapultTrack;
				num += 160;
				break;
			}
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.setTrackCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(base.Location.X + 680, base.Location.Y + num));
			FloatingInput.open(point.X, point.Y, this.currentTrack.Value, this.currentTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0000CB83 File Offset: 0x0000AD83
		private void setTrackCB(int value)
		{
			if (this.currentTrack != null)
			{
				this.currentTrack.Value = value;
				this.updateSlider();
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0000CB9F File Offset: 0x0000AD9F
		private void closeClick()
		{
			this.m_selectedVillage = -1;
			InterfaceMgr.Instance.changeTab(0);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0000CBB3 File Offset: 0x0000ADB3
		public void setTargetVillage(int villageID)
		{
			if (villageID >= 0)
			{
				this.m_selectedVillage = villageID;
				return;
			}
			this.m_selectedVillage = -1;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x000AD6C8 File Offset: 0x000AB8C8
		private void sendClick()
		{
			int num = this.peasantsTrack.Value + this.archerTrack.Value + this.pikemanTrack.Value + this.swordsmanTrack.Value + this.catapultTrack.Value;
			if (num > 0)
			{
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					RemoteServices.Instance.set_SendTroopsToCapital_UserCallBack(new RemoteServices.SendTroopsToCapital_UserCallBack(this.sendTroopsToCapitalCallback));
					RemoteServices.Instance.SendTroopsToCapital(village.VillageID, this.m_selectedVillage, this.peasantsTrack.Value, this.archerTrack.Value, this.pikemanTrack.Value, this.swordsmanTrack.Value, this.catapultTrack.Value);
				}
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x000AD788 File Offset: 0x000AB988
		public void sendTroopsToCapitalCallback(SendTroopsToCapital_ReturnType returnData)
		{
			if (returnData.Success)
			{
				ArmyReturnData[] armyReturnData = new ArmyReturnData[]
				{
					returnData.armyData
				};
				GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
				InterfaceMgr.Instance.getMainTabBar().changeTab(9);
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				VillageMap village = GameEngine.Instance.getVillage(returnData.villageID);
				if (village == null)
				{
					return;
				}
				village.addTroops(-returnData.numPeasants, -returnData.numArchers, -returnData.numPikemen, -returnData.numSwordsmen, -returnData.numCatapults);
			}
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0000CBC8 File Offset: 0x0000ADC8
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0000CBD8 File Offset: 0x0000ADD8
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0000CBFA File Offset: 0x0000ADFA
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0000CC07 File Offset: 0x0000AE07
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0000CC21 File Offset: 0x0000AE21
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0000CC2E File Offset: 0x0000AE2E
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0000CC3B File Offset: 0x0000AE3B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x000AD820 File Offset: 0x000ABA20
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
			base.Name = "CapitalSendTroopsPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B6D RID: 2925
		public static CapitalSendTroopsPanel2 instance;

		// Token: 0x04000B6E RID: 2926
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000B6F RID: 2927
		private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B70 RID: 2928
		private CustomSelfDrawPanel.CSDImage backgroundLeftEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B71 RID: 2929
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04000B72 RID: 2930
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B73 RID: 2931
		private CustomSelfDrawPanel.CSDImage villageBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B74 RID: 2932
		private CustomSelfDrawPanel.CSDImage trackBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B75 RID: 2933
		private CustomSelfDrawPanel.CSDLabel peasantName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B76 RID: 2934
		private CustomSelfDrawPanel.CSDLabel archerName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B77 RID: 2935
		private CustomSelfDrawPanel.CSDLabel pikemanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B78 RID: 2936
		private CustomSelfDrawPanel.CSDLabel swordsmanName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B79 RID: 2937
		private CustomSelfDrawPanel.CSDLabel catapultName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7A RID: 2938
		private CustomSelfDrawPanel.CSDLabel peasantStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7B RID: 2939
		private CustomSelfDrawPanel.CSDLabel archerStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7C RID: 2940
		private CustomSelfDrawPanel.CSDLabel pikemanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7D RID: 2941
		private CustomSelfDrawPanel.CSDLabel swordsmanStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7E RID: 2942
		private CustomSelfDrawPanel.CSDLabel catapultStoredValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B7F RID: 2943
		private CustomSelfDrawPanel.CSDLabel peasantSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B80 RID: 2944
		private CustomSelfDrawPanel.CSDLabel archerSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B81 RID: 2945
		private CustomSelfDrawPanel.CSDLabel pikemanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B82 RID: 2946
		private CustomSelfDrawPanel.CSDLabel swordsmanSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B83 RID: 2947
		private CustomSelfDrawPanel.CSDLabel catapultSendValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B84 RID: 2948
		private CustomSelfDrawPanel.CSDTrackBar peasantsTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000B85 RID: 2949
		private CustomSelfDrawPanel.CSDTrackBar archerTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000B86 RID: 2950
		private CustomSelfDrawPanel.CSDTrackBar pikemanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000B87 RID: 2951
		private CustomSelfDrawPanel.CSDTrackBar swordsmanTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000B88 RID: 2952
		private CustomSelfDrawPanel.CSDTrackBar catapultTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000B89 RID: 2953
		private CustomSelfDrawPanel.CSDButton peasantsEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8A RID: 2954
		private CustomSelfDrawPanel.CSDButton archerEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8B RID: 2955
		private CustomSelfDrawPanel.CSDButton pikemanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8C RID: 2956
		private CustomSelfDrawPanel.CSDButton swordsmanEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8D RID: 2957
		private CustomSelfDrawPanel.CSDButton catapultEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8E RID: 2958
		private CustomSelfDrawPanel.CSDButton btnSend = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B8F RID: 2959
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B90 RID: 2960
		private CustomSelfDrawPanel.CSDLabel warningLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B91 RID: 2961
		private CustomSelfDrawPanel.CSDLabel barrackSpaceLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B92 RID: 2962
		private int m_selectedVillage = -1;

		// Token: 0x04000B93 RID: 2963
		private int barrackSpace;

		// Token: 0x04000B94 RID: 2964
		private CustomSelfDrawPanel.CSDTrackBar currentTrack;

		// Token: 0x04000B95 RID: 2965
		private DockableControl dockableControl;

		// Token: 0x04000B96 RID: 2966
		private IContainer components;

		// Token: 0x04000B97 RID: 2967
		private Panel focusPanel;
	}
}
