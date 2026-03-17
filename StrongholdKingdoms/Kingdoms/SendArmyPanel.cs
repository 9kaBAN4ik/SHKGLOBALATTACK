using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000485 RID: 1157
	public class SendArmyPanel : CustomSelfDrawPanel
	{
		// Token: 0x06002A15 RID: 10773 RVA: 0x00208264 File Offset: 0x00206464
		public SendArmyPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x00208460 File Offset: 0x00206660
		public void init(int parentFromVillage, int fromVillageID, int toVillageID, string villageName, double distance, BattleHonourData honourData, bool gotCaptain, CastleMapAttackerSetupPanel parent)
		{
			this.m_fromVillage = parentFromVillage;
			this.m_toVillage = toVillageID;
			this.m_travelFromVillage = fromVillageID;
			this.m_parent = parent;
			this.m_battleHonourData = honourData;
			this.m_selectedPenalty = 0;
			this.toCapital = false;
			this.m_captureHonourCost = 0;
			this.m_lastSeaConditions = -1;
			base.clearControls();
			int num = 39;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, num);
			this.mainBackgroundImage.Size = new Size(base.Size.Width, base.Size.Height - num);
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.backgroundBottomEdge.Image = GFXLibrary.popup_border_bottom;
			this.backgroundBottomEdge.Position = new Point(0, base.Height - 2);
			base.addControl(this.backgroundBottomEdge);
			this.backgroundRightEdge.Image = GFXLibrary.popup_border_rhs;
			this.backgroundRightEdge.Position = new Point(base.Width - 2, num);
			base.addControl(this.backgroundRightEdge);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(659, 5);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "SendArmyPanel_close");
			this.titleImage.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.titleImage, 33, new Point(609, 5));
			this.cardbar.Position = new Point(0, 4);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(6);
			this.gfxImage.Image = GFXLibrary.send_army_illustration;
			this.gfxImage.Position = new Point(25, 77);
			this.mainBackgroundImage.addControl(this.gfxImage);
			this.targetVillageLabel.Text = villageName;
			this.targetVillageLabel.Color = global::ARGBColors.White;
			this.targetVillageLabel.DropShadowColor = global::ARGBColors.Black;
			this.targetVillageLabel.Position = new Point(5, 10);
			this.targetVillageLabel.Size = new Size(this.gfxImage.Width - 10 - 14 - 20, 32);
			this.targetVillageLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.targetVillageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.gfxImage.addControl(this.targetVillageLabel);
			if (AttackTargetsPanel.isFavourite(toVillageID))
			{
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_1;
				this.targetVillageFavourite.CustomTooltipID = 2107;
			}
			else
			{
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_3;
				this.targetVillageFavourite.CustomTooltipID = 2018;
			}
			this.targetVillageFavourite.OverBrighten = true;
			this.targetVillageFavourite.Position = new Point(this.gfxImage.Width - 20 - 16, 10);
			this.targetVillageFavourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.targetVillageFavourite.Data = 0;
			this.gfxImage.addControl(this.targetVillageFavourite);
			this.sliderImage.Position = new Point(273, 304);
			this.sliderImage.Margin = new Rectangle(90, 70, 19, 25);
			this.sliderImage.Value = 0;
			this.sliderImage.Max = 10;
			this.sliderImage.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.mainBackgroundImage.addControl(this.sliderImage);
			this.sliderImage.Create(GFXLibrary.send_army_slider, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar, GFXLibrary.scout_screen_slider_bar);
			this.sliderValueLabel.Text = "100%";
			this.sliderValueLabel.Color = global::ARGBColors.White;
			this.sliderValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.sliderValueLabel.Position = new Point(11, 65);
			this.sliderValueLabel.Size = new Size(64, 32);
			this.sliderValueLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sliderValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.sliderImage.addControl(this.sliderValueLabel);
			this.sliderHeaderLabel.Text = "";
			this.sliderHeaderLabel.Color = global::ARGBColors.White;
			this.sliderHeaderLabel.DropShadowColor = global::ARGBColors.Black;
			this.sliderHeaderLabel.Position = new Point(63, 15);
			this.sliderHeaderLabel.Size = new Size(135, 32);
			this.sliderHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sliderHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.sliderImage.addControl(this.sliderHeaderLabel);
			this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[24];
			this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[24];
			this.sliderButton.Position = new Point(-5, -8);
			this.sliderButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sliderClick), "SendArmyPanel_change_type");
			this.sliderImage.addControl(this.sliderButton);
			this.arrowImage.Image = GFXLibrary.send_army_timer;
			this.arrowImage.Position = new Point(33, 304);
			this.mainBackgroundImage.addControl(this.arrowImage);
			this.buttonIndentImage.Image = GFXLibrary.monk_screen_buttongroup_inset;
			this.buttonIndentImage.Position = new Point(503, 77);
			this.mainBackgroundImage.addControl(this.buttonIndentImage);
			this.villageActionLabel.Text = "";
			this.villageActionLabel.Color = global::ARGBColors.White;
			this.villageActionLabel.DropShadowColor = global::ARGBColors.Black;
			this.villageActionLabel.Position = new Point(31, 243);
			this.villageActionLabel.Size = new Size(340, 30);
			this.villageActionLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.villageActionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.villageActionLabel);
			this.tooltipLabel.Text = "";
			this.tooltipLabel.Color = global::ARGBColors.White;
			this.tooltipLabel.DropShadowColor = global::ARGBColors.Black;
			this.tooltipLabel.Position = new Point(31, 266);
			this.tooltipLabel.Size = new Size(340, 60);
			this.tooltipLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tooltipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.tooltipLabel);
			this.honourPenaltyLabel.Text = SK.Text("LaunchAttackPopup_Honour_Penalty", "Honour Penalty");
			this.honourPenaltyLabel.Color = global::ARGBColors.White;
			this.honourPenaltyLabel.DropShadowColor = global::ARGBColors.Black;
			this.honourPenaltyLabel.Position = new Point(270, 247);
			this.honourPenaltyLabel.Size = new Size(180, 60);
			this.honourPenaltyLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.honourPenaltyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.honourPenaltyLabel);
			this.honourPenaltyValueLabel.Text = "0,000,000";
			this.honourPenaltyValueLabel.Color = Color.FromArgb(18, 255, 0);
			this.honourPenaltyValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.honourPenaltyValueLabel.Position = new Point(270, 267);
			this.honourPenaltyValueLabel.Size = new Size(180, 60);
			this.honourPenaltyValueLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.honourPenaltyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.honourPenaltyValueLabel);
			this.honourPenaltyImage.Image = GFXLibrary.com_32_honour;
			this.honourPenaltyImage.Position = new Point(450, 247);
			base.addControl(this.honourPenaltyImage);
			this.captureCostLabel.Text = SK.Text("LaunchAttackPopup_Honour_Capture", "Capture Cost");
			this.captureCostLabel.Color = global::ARGBColors.White;
			this.captureCostLabel.DropShadowColor = global::ARGBColors.Black;
			this.captureCostLabel.Position = new Point(270, 287);
			this.captureCostLabel.Size = new Size(180, 60);
			this.captureCostLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.captureCostLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.captureCostLabel);
			this.captureCostValueLabel.Text = "10,000,000";
			this.captureCostValueLabel.Color = Color.FromArgb(18, 255, 0);
			this.captureCostValueLabel.DropShadowColor = global::ARGBColors.Black;
			this.captureCostValueLabel.Position = new Point(270, 307);
			this.captureCostValueLabel.Size = new Size(180, 60);
			this.captureCostValueLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.captureCostValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundImage.addControl(this.captureCostValueLabel);
			this.captureCostImage.Image = GFXLibrary.com_32_honour;
			this.captureCostImage.Position = new Point(450, 287 + num);
			base.addControl(this.captureCostImage);
			this.needCaptainLabel.Text = SK.Text("LaunchAttackPopup_Need_Captain", "Need Captain");
			this.needCaptainLabel.Color = global::ARGBColors.White;
			this.needCaptainLabel.DropShadowColor = global::ARGBColors.Black;
			this.needCaptainLabel.Position = new Point(500, 358);
			this.needCaptainLabel.Size = new Size(180, 32);
			this.needCaptainLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.needCaptainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.needCaptainLabel.Visible = false;
			this.mainBackgroundImage.addControl(this.needCaptainLabel);
			this.storedPreCardDistance = distance;
			distance = GameEngine.Instance.World.adjustIfIslandTravel(distance, this.m_travelFromVillage, this.m_toVillage);
			distance *= CardTypes.getArmySpeed(GameEngine.Instance.cardsManager.UserCardData);
			string text = VillageMap.createBuildTimeString((int)distance);
			this.timeLabel.Text = text;
			this.timeLabel.Color = global::ARGBColors.White;
			this.timeLabel.DropShadowColor = global::ARGBColors.Black;
			this.timeLabel.Position = new Point(0, 23);
			this.timeLabel.Size = new Size(191, 24);
			this.timeLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.timeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.arrowImage.addControl(this.timeLabel);
			this.errorLabel.Text = "Error Message Here";
			this.errorLabel.Color = global::ARGBColors.White;
			this.errorLabel.DropShadowColor = global::ARGBColors.Black;
			this.errorLabel.Position = new Point(0, 411);
			this.errorLabel.Size = new Size(this.mainBackgroundImage.Width, 32);
			this.errorLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.errorLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.mainBackgroundImage.addControl(this.errorLabel);
			this.actionButton_GoldRaid.Enabled = false;
			bool flag = true;
			bool flag2 = true;
			this.updateButtons(-1);
			this.actionButton_Vandalise.Position = new Point(10, 12);
			this.actionButton_Vandalise.Data = 0;
			this.actionButton_Vandalise.CustomTooltipID = 2100;
			this.actionButton_Vandalise.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_vandalise");
			this.buttonIndentImage.addControl(this.actionButton_Vandalise);
			this.actionButton_Pillage.Position = new Point(84, 12);
			this.actionButton_Pillage.Data = 1;
			this.actionButton_Pillage.CustomTooltipID = 2102;
			this.actionButton_Pillage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_pillage");
			this.buttonIndentImage.addControl(this.actionButton_Pillage);
			this.actionButton_Ransack.Position = new Point(10, 99);
			this.actionButton_Ransack.Data = 2;
			this.actionButton_Ransack.CustomTooltipID = 2103;
			this.actionButton_Ransack.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_ransack");
			this.buttonIndentImage.addControl(this.actionButton_Ransack);
			this.actionButton_Raze.Position = new Point(84, 99);
			this.actionButton_Raze.Data = 3;
			this.actionButton_Raze.CustomTooltipID = 2104;
			this.actionButton_Raze.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_raze");
			this.buttonIndentImage.addControl(this.actionButton_Raze);
			this.actionButton_Capture.Position = new Point(10, 186);
			this.actionButton_Capture.Data = 4;
			this.actionButton_Capture.CustomTooltipID = 2101;
			this.actionButton_Capture.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_capture");
			this.buttonIndentImage.addControl(this.actionButton_Capture);
			this.actionButton_GoldRaid.Position = new Point(84, 186);
			this.actionButton_GoldRaid.Data = 5;
			this.actionButton_GoldRaid.CustomTooltipID = 2105;
			this.actionButton_GoldRaid.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.changeCommand), "SendArmyPanel_command_gold_raid");
			this.buttonIndentImage.addControl(this.actionButton_GoldRaid);
			int special = GameEngine.Instance.World.getSpecial(toVillageID);
			int num2;
			switch (special)
			{
			case 3:
			case 4:
				num2 = 24;
				goto IL_114A;
			case 5:
			case 6:
				num2 = 25;
				goto IL_114A;
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				num2 = 28;
				goto IL_114A;
			case 15:
			case 16:
			case 17:
			case 18:
				num2 = 53;
				goto IL_114A;
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
				break;
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 48:
			case 49:
			case 50:
				num2 = 54;
				goto IL_114A;
			case 51:
			case 52:
			case 53:
			case 54:
			case 55:
			case 56:
			case 57:
			case 58:
			case 59:
			case 60:
				num2 = 55;
				goto IL_114A;
			case 61:
			case 62:
			case 63:
			case 64:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
				num2 = 56;
				goto IL_114A;
			case 71:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
				num2 = 57;
				goto IL_114A;
			case 81:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				num2 = 58;
				goto IL_114A;
			default:
				if (special - 200 <= 20)
				{
					num2 = 65;
					goto IL_114A;
				}
				break;
			}
			num2 = ((!GameEngine.Instance.World.isRegionCapital(toVillageID)) ? ((!GameEngine.Instance.World.isCountyCapital(toVillageID)) ? ((!GameEngine.Instance.World.isProvinceCapital(toVillageID)) ? ((!GameEngine.Instance.World.isCountryCapital(toVillageID)) ? GameEngine.Instance.World.getVillageSize(toVillageID) : 52) : 51) : 50) : 49);
			IL_114A:
			this.targetImage.Image = GFXLibrary.scout_screen_icons[num2];
			this.targetImage.Position = new Point(143, 15);
			this.arrowImage.addControl(this.targetImage);
			this.maxPillageValue = ResearchData.pillageLevels[(int)GameEngine.Instance.World.UserResearchData.Research_Pillaging];
			this.maxRansackValue = ResearchData.ransackLevels[(int)GameEngine.Instance.World.UserResearchData.Research_Ransack];
			this.maxGoldRaidValue = 50;
			this.launchButton.ImageNorm = GFXLibrary.button_with_inset_normal;
			this.launchButton.ImageOver = GFXLibrary.button_with_inset_over;
			this.launchButton.ImageClick = GFXLibrary.button_with_inset_pushed;
			this.launchButton.Position = new Point(520, 377);
			this.launchButton.Text.Text = SK.Text("ScoutPopup_Go", "Go");
			this.launchButton.Text.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.launchButton.TextYOffset = 1;
			this.launchButton.Text.Color = global::ARGBColors.Black;
			this.launchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.launch), "SendArmyPanel_launch");
			this.launchButton.Enabled = false;
			this.mainBackgroundImage.addControl(this.launchButton);
			bool flag3 = false;
			int rank = GameEngine.Instance.World.getRank();
			if (GameEngine.Instance.World.isCapital(fromVillageID) && GameEngine.Instance.World.isSpecial(toVillageID) && (SpecialVillageTypes.IS_TREASURE_CASTLE(GameEngine.Instance.World.getSpecial(toVillageID)) || SpecialVillageTypes.IS_ROYAL_TOWER(GameEngine.Instance.World.getSpecial(toVillageID))))
			{
				flag = false;
				this.actionButton_Capture.Visible = false;
				this.actionButton_Pillage.Visible = false;
				this.actionButton_Ransack.Visible = false;
				flag2 = false;
				this.actionButton_Raze.Visible = false;
				this.actionButton_GoldRaid.Visible = false;
				this.launchButton.Enabled = false;
				flag3 = true;
			}
			else if (GameEngine.Instance.World.isCapital(toVillageID))
			{
				this.toCapital = true;
				this.actionButton_Capture.Enabled = false;
				this.actionButton_Pillage.Enabled = false;
				this.actionButton_Ransack.Enabled = false;
				this.actionButton_Raze.Enabled = false;
				flag2 = false;
				if (GameEngine.Instance.World.isCapital(fromVillageID))
				{
					this.capitalToCapital = true;
					this.actionButton_GoldRaid.Enabled = true;
				}
				else
				{
					this.actionButton_GoldRaid.Enabled = false;
				}
			}
			else
			{
				if (SpecialVillageTypes.IS_ROYAL_TOWER(GameEngine.Instance.World.getSpecial(toVillageID)))
				{
					this.actionButton_Capture.Enabled = true;
				}
				else if (GameEngine.Instance.World.canUserOwnMoreVillages() && !GameEngine.Instance.World.isUserVillage(toVillageID))
				{
					this.actionButton_Capture.Enabled = true;
					NumberFormatInfo nfi = GameEngine.NFI;
					if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
					{
						this.m_captureHonourCost = ResearchData.getVillageBuyHonourCost(GameEngine.Instance.World.numVillagesOwned());
						if (this.m_captureHonourCost > 0 && GameEngine.Instance.World.FourthAgeWorld && GameEngine.Instance.World.numVillagesOwned() < GameEngine.Instance.World.MostAge4Villages)
						{
							this.m_captureHonourCost = 0;
						}
					}
					this.captureCostValueLabel.Text = this.m_captureHonourCost.ToString("N", nfi);
				}
				else
				{
					this.actionButton_Capture.Enabled = false;
				}
				if (GameEngine.Instance.World.getCurrentHonour() > 0.0 && (GameEngine.Instance.World.getVillageUserID(toVillageID) >= 0 || (GameEngine.Instance.LocalWorldData.AIWorld && GameEngine.Instance.World.isSpecialAIPlayer(toVillageID))) && rank >= GameEngine.Instance.LocalWorldData.RazeMinRank - 1)
				{
					if (!GameEngine.Instance.LocalWorldData.EraWorld || GameEngine.Instance.LocalWorldData.AIWorld)
					{
						this.actionButton_Raze.Enabled = true;
					}
					else if (honourData != null)
					{
						if (honourData.defenderRank < 8)
						{
							this.actionButton_Raze.Enabled = false;
						}
						else
						{
							this.actionButton_Raze.Enabled = true;
						}
					}
					else
					{
						this.actionButton_Raze.Enabled = true;
					}
				}
				else
				{
					this.actionButton_Raze.Enabled = false;
				}
				if (GameEngine.Instance.World.isCapital(fromVillageID))
				{
					flag = false;
					this.actionButton_Capture.Visible = false;
					this.actionButton_Pillage.Visible = false;
					this.actionButton_Ransack.Visible = false;
					flag2 = false;
					this.actionButton_Raze.Visible = false;
					this.actionButton_GoldRaid.Visible = false;
					this.launchButton.Enabled = true;
					this.actionButton_Vandalise.CustomTooltipID = 2106;
					this.updateButtons(0);
				}
				else if (GameEngine.Instance.LocalWorldData.AIWorld && GameEngine.Instance.World.isSpecialAIPlayer(toVillageID))
				{
					this.actionButton_Pillage.Visible = false;
					this.actionButton_Ransack.Visible = false;
					this.actionButton_GoldRaid.Visible = false;
					this.actionButton_Raze.Visible = false;
					this.actionButton_Vandalise.CustomTooltipID = 2106;
					this.actionButton_Capture.Position = new Point(84, 12);
				}
				else if (!GameEngine.Instance.World.isSpecial(toVillageID) && GameEngine.Instance.World.getVillageUserID(toVillageID) >= 0)
				{
					if (GameEngine.Instance.World.UserResearchData.Research_Ransack == 0)
					{
						this.actionButton_Ransack.Enabled = false;
					}
					else
					{
						this.actionButton_Ransack.Enabled = true;
					}
				}
				else if (SpecialVillageTypes.IS_ROYAL_TOWER(GameEngine.Instance.World.getSpecial(toVillageID)))
				{
					this.actionButton_Pillage.Visible = false;
					this.actionButton_Ransack.Visible = false;
					flag2 = false;
					this.actionButton_Raze.Visible = false;
					this.actionButton_GoldRaid.Visible = false;
					this.actionButton_Vandalise.Visible = false;
					if (!gotCaptain)
					{
						this.noCaptain = true;
					}
					this.updateButtons(4);
				}
				else
				{
					flag = false;
					this.actionButton_Capture.Visible = false;
					this.actionButton_Pillage.Visible = false;
					this.actionButton_Ransack.Visible = false;
					flag2 = false;
					this.actionButton_Raze.Visible = false;
					this.actionButton_GoldRaid.Visible = false;
					this.launchButton.Enabled = true;
					this.actionButton_Vandalise.CustomTooltipID = 2106;
					this.updateButtons(0);
				}
				if (parentFromVillage != fromVillageID)
				{
					flag = false;
					this.actionButton_Capture.Visible = false;
					flag2 = false;
					this.actionButton_Raze.Visible = false;
				}
			}
			if ((flag2 || (flag && !this.capitalToCapital)) && !gotCaptain)
			{
				this.noCaptain = true;
			}
			this.titleImage.Image = GFXLibrary.popup_title_bar;
			this.titleImage.Position = new Point(0, 0);
			base.addControl(this.titleImage);
			this.titleLabel.Text = SK.Text("GENERIC_Launch_Attack", "Launch Attack");
			this.titleLabel.Color = global::ARGBColors.White;
			this.titleLabel.DropShadowColor = global::ARGBColors.Black;
			this.titleLabel.Position = new Point(20, 5);
			this.titleLabel.Size = new Size(base.Width, 32);
			this.titleLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.titleImage.addControl(this.titleLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(659, 5);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "SendArmyPanel_close");
			this.titleImage.addControl(this.closeButton);
			if (flag3)
			{
				this.errorLabel.Visible = true;
				if (SpecialVillageTypes.IS_ROYAL_TOWER(GameEngine.Instance.World.getSpecial(toVillageID)))
				{
					this.errorLabel.Text = SK.Text("LaunchAttackPopup_Not_Attack_RT_From_Capitals", "You cannot attack Royal Towers from Capitals.");
				}
				else
				{
					this.errorLabel.Text = SK.Text("LaunchAttackPopup_Not_Attack_TC_From_Capitals", "You cannot attack Treasure Castles from Capitals.");
				}
			}
			else if (special >= 100 && special <= 199)
			{
				this.errorLabel.Text = SK.Text("LaunchAttackPopup_No_Honour_Out_Of_Range_Stash", "No Honour will be received, the stash is out of range.");
			}
			else
			{
				switch (special)
				{
				case 3:
					this.errorLabel.Text = SK.Text("LaunchAttackPopup_No_Honour_Out_Of_Range_Bandit", "No Honour will be received, the Bandit Camp is out of range.");
					goto IL_1AC7;
				case 5:
					this.errorLabel.Text = SK.Text("LaunchAttackPopup_No_Honour_Out_Of_Range_Wolf", "No Honour will be received, the Wolf Lair is out of range.");
					goto IL_1AC7;
				case 7:
				case 9:
				case 11:
				case 13:
					this.errorLabel.Text = SK.Text("LaunchAttackPopup_No_Honour_Out_Of_Range_AI", "No Honour will be received, the AI Castle is out of range.");
					goto IL_1AC7;
				}
				this.errorLabel.Text = SK.Text("LaunchAttackPopup_No_Honour_Out_Of_Range_Village", "No Honour will be received, the village is out of range.");
			}
			IL_1AC7:
			this.errorLabel.Visible = GameEngine.Instance.World.isScoutHonourOutOfRange(fromVillageID, toVillageID);
			if (special == 15 || special == 17 || SpecialVillageTypes.IS_TREASURE_CASTLE(special))
			{
				this.errorLabel.Visible = true;
				this.errorLabel.Text = SK.Text("LaunchAttackPopup_Paladin_No_Honour", "No honour will be received for destroying this type of AI castle");
			}
			if (GameEngine.Instance.World.isIslandTravel(this.m_travelFromVillage, this.m_toVillage))
			{
				int num3 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num3 < 0)
				{
					num3 = 0;
				}
				else if (num3 >= 9)
				{
					num3 = 8;
				}
				this.m_lastSeaConditions = num3;
				this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num3];
				this.seaConditionsImage.Position = new Point(97, 358);
				this.seaConditionsImage.CustomTooltipID = 23000 + num3;
				this.mainBackgroundImage.addControl(this.seaConditionsImage);
			}
		}

		// Token: 0x06002A17 RID: 10775 RVA: 0x0020A02C File Offset: 0x0020822C
		public void changeCommand()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				this.updateButtons(data);
			}
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x0020A05C File Offset: 0x0020825C
		public void updateButtons(int type)
		{
			this.currentCommand = type;
			this.actionButton_Vandalise.ImageNorm = GFXLibrary.send_army_buttons[1];
			this.actionButton_Vandalise.ImageOver = GFXLibrary.send_army_buttons[7];
			this.actionButton_Pillage.ImageNorm = GFXLibrary.send_army_buttons[5];
			this.actionButton_Pillage.ImageOver = GFXLibrary.send_army_buttons[11];
			this.actionButton_Ransack.ImageNorm = GFXLibrary.send_army_buttons[2];
			this.actionButton_Ransack.ImageOver = GFXLibrary.send_army_buttons[8];
			this.actionButton_Raze.ImageNorm = GFXLibrary.send_army_buttons[4];
			this.actionButton_Raze.ImageOver = GFXLibrary.send_army_buttons[10];
			this.actionButton_Capture.ImageNorm = GFXLibrary.send_army_buttons[3];
			this.actionButton_Capture.ImageOver = GFXLibrary.send_army_buttons[9];
			this.actionButton_GoldRaid.ImageNorm = GFXLibrary.send_army_buttons[0];
			this.actionButton_GoldRaid.ImageOver = GFXLibrary.send_army_buttons[6];
			this.gfxImage.Visible = true;
			this.m_selectedPenalty = 0;
			this.sliderImage.Visible = false;
			this.arrowImage.Visible = true;
			this.tooltipLabel.Visible = true;
			this.villageActionLabel.Visible = true;
			this.needCaptainLabel.Visible = false;
			this.honourPenaltyImage.Visible = false;
			this.honourPenaltyLabel.Visible = false;
			this.honourPenaltyValueLabel.Visible = false;
			this.captureCostImage.Visible = false;
			this.captureCostLabel.Visible = false;
			this.captureCostValueLabel.Visible = false;
			switch (type)
			{
			case 0:
			{
				this.actionButton_Vandalise.ImageNorm = GFXLibrary.send_army_buttons[13];
				this.actionButton_Vandalise.ImageOver = GFXLibrary.send_army_buttons[19];
				this.launchButton.Enabled = true;
				if (this.actionButton_Vandalise.CustomTooltipID == 2100)
				{
					this.villageActionLabel.Text = SK.Text("LaunchAttackPopup_Vandalise", "Vandalise");
				}
				else
				{
					this.villageActionLabel.Text = SK.Text("GENERIC_Attack", "Attack");
				}
				int special = GameEngine.Instance.World.getSpecial(this.m_toVillage);
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(special))
				{
					this.villageActionLabel.Text = SK.Text("LaunchAttackPopup_Attack_tooltip_treasure_castle", "Attack a Treasure Castle.");
					this.tooltipLabel.Size = new Size(640, 60);
					this.buttonIndentImage.Visible = false;
					this.gfxImage.Position = new Point(120, 77);
					this.tooltipLabel.Text = SK.Text("CastleMap_TC_Message", "Treasure chests are below ground and cannot be seen by troops until they are on an immediately adjacent tile, otherwise they march to the keep as normal.");
				}
				else
				{
					this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Attack_tooltip", "Attack an enemy castle.");
				}
				int num = 0;
				if (!GameEngine.Instance.World.isCapital(this.m_fromVillage))
				{
					if (this.m_battleHonourData != null)
					{
						this.m_battleHonourData.attackType = 11;
						num = CastlesCommon.calcBattleHonourCost(this.m_battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
					}
					if (num > 0)
					{
						this.showHonourPenalty(num);
					}
				}
				break;
			}
			case 1:
			{
				this.actionButton_Pillage.ImageNorm = GFXLibrary.send_army_buttons[17];
				this.actionButton_Pillage.ImageOver = GFXLibrary.send_army_buttons[23];
				this.sliderImage.Visible = true;
				this.launchButton.Enabled = true;
				this.sliderImage.Value = 0;
				this.sliderImage.Max = this.maxPillageValue - 1;
				this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Stockpile", "Stockpile");
				this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[24];
				this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[30];
				this.currentPillageType = 0;
				this.villageActionLabel.Text = SK.Text("GENERIC_Pillage", "Pillage");
				this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Pillage_tooltip", "Steal resources from an enemy.");
				int num2 = 0;
				if (!GameEngine.Instance.World.isCapital(this.m_fromVillage))
				{
					if (this.m_battleHonourData != null)
					{
						this.m_battleHonourData.attackType = 2;
						num2 = CastlesCommon.calcBattleHonourCost(this.m_battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
					}
					if (num2 > 0)
					{
						this.showHonourPenalty(num2);
					}
				}
				break;
			}
			case 2:
			{
				this.actionButton_Ransack.ImageNorm = GFXLibrary.send_army_buttons[14];
				this.actionButton_Ransack.ImageOver = GFXLibrary.send_army_buttons[20];
				this.sliderImage.Visible = true;
				this.launchButton.Enabled = true;
				this.sliderImage.Value = 0;
				this.sliderImage.Max = this.maxRansackValue - 1;
				this.sliderHeaderLabel.Text = SK.Text("LaunchAttackPopup_Max_Buildings", "Max Buildings");
				this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[29];
				this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[29];
				this.villageActionLabel.Text = SK.Text("GENERIC_Ransack", "Ransack");
				this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Ransack_tooltip", "Destroy enemy village buildings.");
				int num3 = 0;
				if (!GameEngine.Instance.World.isCapital(this.m_fromVillage))
				{
					if (this.m_battleHonourData != null)
					{
						this.m_battleHonourData.attackType = 3;
						num3 = CastlesCommon.calcBattleHonourCost(this.m_battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
					}
					if (num3 > 0)
					{
						this.showHonourPenalty(num3);
					}
				}
				break;
			}
			case 3:
			{
				this.actionButton_Raze.ImageNorm = GFXLibrary.send_army_buttons[16];
				this.actionButton_Raze.ImageOver = GFXLibrary.send_army_buttons[22];
				if (this.noCaptain)
				{
					this.launchButton.Enabled = false;
				}
				else
				{
					this.launchButton.Enabled = true;
				}
				this.needCaptainLabel.Visible = this.noCaptain;
				this.villageActionLabel.Text = SK.Text("GENERIC_Raze", "Raze");
				this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Raze_tooltip", "Completely destroy target.");
				int num4 = 0;
				if (!GameEngine.Instance.World.isCapital(this.m_fromVillage))
				{
					if (this.m_battleHonourData != null)
					{
						this.m_battleHonourData.attackType = 9;
						num4 = CastlesCommon.calcBattleHonourCost(this.m_battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
					}
					if (num4 > 0)
					{
						this.showHonourPenalty(num4);
					}
				}
				break;
			}
			case 4:
			{
				this.actionButton_Capture.ImageNorm = GFXLibrary.send_army_buttons[15];
				this.actionButton_Capture.ImageOver = GFXLibrary.send_army_buttons[21];
				if (this.noCaptain)
				{
					this.launchButton.Enabled = false;
				}
				else
				{
					this.launchButton.Enabled = true;
				}
				this.needCaptainLabel.Visible = this.noCaptain;
				this.villageActionLabel.Text = SK.Text("GENERIC_Capture", "Capture");
				int special2 = GameEngine.Instance.World.getSpecial(this.m_toVillage);
				if (SpecialVillageTypes.IS_ROYAL_TOWER(special2))
				{
					this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Capture_tooltip_RT", "Capture Royal Tower.");
					this.tooltipLabel.Size = new Size(640, 60);
					this.buttonIndentImage.Visible = false;
					this.gfxImage.Position = new Point(120, 77);
				}
				else
				{
					this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Capture_tooltip", "Captures enemy village.");
				}
				if (this.m_captureHonourCost > 0)
				{
					this.captureCostLabel.Visible = true;
					this.captureCostValueLabel.Visible = true;
					this.captureCostImage.Visible = true;
				}
				if (!GameEngine.Instance.World.isCapital(this.m_toVillage) && !this.capitalToCapital)
				{
					int num5 = 0;
					if (!GameEngine.Instance.World.isCapital(this.m_fromVillage))
					{
						if (this.m_battleHonourData != null)
						{
							if (this.m_captureAllowed)
							{
								this.m_battleHonourData.attackType = 1;
							}
							else
							{
								this.m_battleHonourData.attackType = 11;
							}
							num5 = CastlesCommon.calcBattleHonourCost(this.m_battleHonourData, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, GameEngine.Instance.LocalWorldData.EraWorld);
						}
						if (num5 > 0 || this.m_captureHonourCost > 0)
						{
							this.showHonourPenalty(num5, this.m_captureHonourCost);
						}
					}
				}
				break;
			}
			case 5:
				this.actionButton_GoldRaid.ImageNorm = GFXLibrary.send_army_buttons[12];
				this.actionButton_GoldRaid.ImageOver = GFXLibrary.send_army_buttons[18];
				this.sliderImage.Visible = true;
				this.launchButton.Enabled = true;
				this.sliderImage.Value = 0;
				this.sliderImage.Max = this.maxGoldRaidValue - 1;
				this.sliderHeaderLabel.Text = SK.Text("GENERIC_Gold", "Gold");
				this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[28];
				this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[28];
				this.villageActionLabel.Text = SK.Text("GENERIC_Gold_Raid", "Gold Raid");
				this.tooltipLabel.Text = SK.Text("LaunchAttackPopup_Goldraid_tooltip", "Steals gold from capital.");
				break;
			}
			this.tracksMoved();
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x0020AA6C File Offset: 0x00208C6C
		private void showHonourPenalty(int penalty)
		{
			if (!this.toCapital)
			{
				NumberFormatInfo nfi = GameEngine.NFI;
				this.honourPenaltyValueLabel.Text = penalty.ToString("N", nfi);
				this.m_selectedPenalty = penalty;
				this.honourPenaltyValueLabel.Visible = true;
				this.honourPenaltyLabel.Visible = true;
				this.honourPenaltyImage.Visible = true;
				this.honourPenaltyValueLabel.Color = Color.FromArgb(18, 255, 0);
				if (penalty > 0 && GameEngine.Instance.World.getCurrentHonour() <= 0.0)
				{
					this.launchButton.Enabled = false;
					this.honourPenaltyValueLabel.Color = Color.FromArgb(255, 18, 0);
				}
			}
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x0020AB28 File Offset: 0x00208D28
		private void showHonourPenalty(int penalty, int captureCost)
		{
			if (!this.toCapital)
			{
				NumberFormatInfo nfi = GameEngine.NFI;
				this.honourPenaltyValueLabel.Text = penalty.ToString("N", nfi);
				this.m_selectedPenalty = penalty;
				this.honourPenaltyValueLabel.Visible = true;
				this.honourPenaltyLabel.Visible = true;
				this.honourPenaltyImage.Visible = true;
				this.honourPenaltyValueLabel.Color = Color.FromArgb(18, 255, 0);
				this.captureCostValueLabel.Color = Color.FromArgb(18, 255, 0);
				if ((penalty > 0 && GameEngine.Instance.World.getCurrentHonour() <= 0.0) || (captureCost > 0 && GameEngine.Instance.World.getCurrentHonour() < (double)captureCost))
				{
					this.launchButton.Enabled = false;
					this.honourPenaltyValueLabel.Color = Color.FromArgb(255, 18, 0);
					this.captureCostValueLabel.Color = Color.FromArgb(255, 18, 0);
				}
			}
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x0020AC2C File Offset: 0x00208E2C
		public void update()
		{
			this.cardbar.update();
			double num = this.storedPreCardDistance * CardTypes.getArmySpeed(GameEngine.Instance.cardsManager.UserCardData);
			num = GameEngine.Instance.World.adjustIfIslandTravel(num, this.m_travelFromVillage, this.m_toVillage);
			string textDiffOnly = VillageMap.createBuildTimeString((int)num);
			this.timeLabel.TextDiffOnly = textDiffOnly;
			if (this.m_lastSeaConditions != -1)
			{
				int num2 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 >= 9)
				{
					num2 = 8;
				}
				if (this.m_lastSeaConditions != num2)
				{
					this.m_lastSeaConditions = num2;
					this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num2];
					this.seaConditionsImage.CustomTooltipID = 23000 + num2;
				}
			}
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x0020ACF8 File Offset: 0x00208EF8
		private void tracksMoved()
		{
			if (this.currentCommand == 2)
			{
				this.sliderValueLabel.Text = (this.sliderImage.Value + 1).ToString();
				return;
			}
			this.sliderValueLabel.Text = (this.sliderImage.Value + 1).ToString() + "%";
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x0020AD5C File Offset: 0x00208F5C
		private void sliderClick()
		{
			if (this.currentCommand == 1)
			{
				this.currentPillageType++;
				if (this.currentPillageType >= 5)
				{
					this.currentPillageType = 0;
				}
				if (this.currentPillageType == 0)
				{
					this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Stockpile", "Stockpile");
					this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[24];
					this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[30];
					return;
				}
				if (this.currentPillageType == 1)
				{
					this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Granary", "Granary");
					this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[25];
					this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[31];
					return;
				}
				if (this.currentPillageType == 2)
				{
					this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Inn", "Inn");
					this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[34];
					this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[35];
					return;
				}
				if (this.currentPillageType == 3)
				{
					this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Village_Hall", "Village Hall");
					this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[27];
					this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[33];
					return;
				}
				if (this.currentPillageType == 4)
				{
					this.sliderHeaderLabel.Text = SK.Text("BuildingTypes_Armoury", "Armoury");
					this.sliderButton.ImageNorm = GFXLibrary.send_army_buttons[26];
					this.sliderButton.ImageOver = GFXLibrary.send_army_buttons[32];
				}
			}
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x0020AF38 File Offset: 0x00209138
		private void villageFavouriteClicked()
		{
			if (AttackTargetsPanel.isFavourite(this.m_toVillage))
			{
				AttackTargetsPanel.removeFavourite(this.m_toVillage);
				this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_3;
				this.targetVillageFavourite.CustomTooltipID = 2018;
				return;
			}
			AttackTargetsPanel.addFavourite(this.m_toVillage);
			this.targetVillageFavourite.ImageNorm = GFXLibrary.star_market_1;
			this.targetVillageFavourite.CustomTooltipID = 2107;
		}

		// Token: 0x06002A1F RID: 10783 RVA: 0x0001EF8B File Offset: 0x0001D18B
		private void closeClick()
		{
			GameEngine.Instance.EnableMouseClicks();
			InterfaceMgr.Instance.closeLaunchAttackPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06002A20 RID: 10784 RVA: 0x0020AFB4 File Offset: 0x002091B4
		private void launch()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (this.currentCommand == 4)
			{
				if (this.m_captureAllowed)
				{
					num = 1;
					num3 = this.m_captureHonourCost;
				}
				else
				{
					num = 11;
				}
			}
			if (this.currentCommand == 5 && this.capitalToCapital)
			{
				num = 12;
				num2 = this.sliderImage.Value + 1;
			}
			if (this.currentCommand == 3)
			{
				num = 9;
			}
			if (this.currentCommand == 1)
			{
				switch (this.currentPillageType)
				{
				case 1:
					num = 4;
					break;
				case 2:
					num = 6;
					break;
				case 3:
					num = 5;
					break;
				case 4:
					num = 7;
					break;
				default:
					num = 2;
					break;
				}
				num2 = this.sliderImage.Value + 1;
			}
			if (this.currentCommand == 2)
			{
				num = 3;
				num2 = this.sliderImage.Value + 1;
			}
			if (this.currentCommand == 0)
			{
				num = 11;
			}
			this.attackTypeRef = num;
			this.pillageValueRef = num2;
			if (this.m_selectedPenalty > 0 || num3 > 0)
			{
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				NumberFormatInfo nfi = GameEngine.NFI;
				DialogResult dialogResult = MyMessageBox.Show(string.Concat(new string[]
				{
					SK.Text("LaunchAttackPopup_Penalty_Warning", "This attack will cost you an Honour Penalty."),
					Environment.NewLine,
					SK.Text("GENERIC_Honour_Cost", "Honour Cost"),
					" : ",
					(this.m_selectedPenalty + num3).ToString("N", nfi),
					Environment.NewLine,
					SK.Text("LaunchAttackPopup_Continue", "Continue?")
				}), SK.Text("LaunchAttackPopup_Confirm_Attack", "Confirm Attack"), buts);
				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}
			this.Attack();
		}

		// Token: 0x06002A21 RID: 10785 RVA: 0x0020B140 File Offset: 0x00209340
		private void Attack()
		{
			GameEngine.Instance.CastleAttackerSetup.setupLaunchArmy(this.attackTypeRef, this.pillageValueRef, 0);
			GameEngine.Instance.CastleAttackerSetup.launchArmy(false);
			this.m_parent.launched();
			GameEngine.Instance.EnableMouseClicks();
		}

		// Token: 0x06002A22 RID: 10786 RVA: 0x0001EFC1 File Offset: 0x0001D1C1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A23 RID: 10787 RVA: 0x0001EFE0 File Offset: 0x0001D1E0
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x040033A3 RID: 13219
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033A4 RID: 13220
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040033A5 RID: 13221
		private CustomSelfDrawPanel.CSDImage titleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033A6 RID: 13222
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033A7 RID: 13223
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033A8 RID: 13224
		private CustomSelfDrawPanel.CSDImage backgroundRightEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033A9 RID: 13225
		private CustomSelfDrawPanel.CSDImage backgroundBottomEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033AA RID: 13226
		private CustomSelfDrawPanel.CSDImage gfxImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033AB RID: 13227
		private CustomSelfDrawPanel.CSDImage arrowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033AC RID: 13228
		private CustomSelfDrawPanel.CSDImage targetImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033AD RID: 13229
		private CustomSelfDrawPanel.CSDImage buttonIndentImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033AE RID: 13230
		private CustomSelfDrawPanel.CSDLabel villageActionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033AF RID: 13231
		private CustomSelfDrawPanel.CSDLabel timeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033B0 RID: 13232
		private CustomSelfDrawPanel.CSDLabel tooltipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033B1 RID: 13233
		private CustomSelfDrawPanel.CSDLabel needCaptainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033B2 RID: 13234
		private CustomSelfDrawPanel.CSDButton launchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033B3 RID: 13235
		private CustomSelfDrawPanel.CSDTrackBar sliderImage = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040033B4 RID: 13236
		private CustomSelfDrawPanel.CSDLabel sliderValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033B5 RID: 13237
		private CustomSelfDrawPanel.CSDLabel sliderHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033B6 RID: 13238
		private CustomSelfDrawPanel.CSDButton sliderButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033B7 RID: 13239
		private CustomSelfDrawPanel.CSDButton actionButton_Vandalise = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033B8 RID: 13240
		private CustomSelfDrawPanel.CSDButton actionButton_Pillage = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033B9 RID: 13241
		private CustomSelfDrawPanel.CSDButton actionButton_Ransack = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033BA RID: 13242
		private CustomSelfDrawPanel.CSDButton actionButton_Raze = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033BB RID: 13243
		private CustomSelfDrawPanel.CSDButton actionButton_Capture = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033BC RID: 13244
		private CustomSelfDrawPanel.CSDButton actionButton_GoldRaid = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033BD RID: 13245
		private CustomSelfDrawPanel.CSDLabel targetVillageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033BE RID: 13246
		private CustomSelfDrawPanel.CSDButton targetVillageFavourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040033BF RID: 13247
		private CustomSelfDrawPanel.CSDLabel errorLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033C0 RID: 13248
		private CustomSelfDrawPanel.CSDLabel honourPenaltyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033C1 RID: 13249
		private CustomSelfDrawPanel.CSDLabel honourPenaltyValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033C2 RID: 13250
		private CustomSelfDrawPanel.CSDLabel captureCostLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033C3 RID: 13251
		private CustomSelfDrawPanel.CSDLabel captureCostValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040033C4 RID: 13252
		private CustomSelfDrawPanel.CSDImage honourPenaltyImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033C5 RID: 13253
		private CustomSelfDrawPanel.CSDImage captureCostImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033C6 RID: 13254
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040033C7 RID: 13255
		private int m_selectedPenalty;

		// Token: 0x040033C8 RID: 13256
		private int m_captureHonourCost;

		// Token: 0x040033C9 RID: 13257
		private CastleMapAttackerSetupPanel m_parent;

		// Token: 0x040033CA RID: 13258
		private bool m_captureAllowed = true;

		// Token: 0x040033CB RID: 13259
		private bool capitalToCapital;

		// Token: 0x040033CC RID: 13260
		private bool toCapital;

		// Token: 0x040033CD RID: 13261
		private int m_toVillage = -1;

		// Token: 0x040033CE RID: 13262
		private int m_fromVillage = -1;

		// Token: 0x040033CF RID: 13263
		private int m_travelFromVillage = -1;

		// Token: 0x040033D0 RID: 13264
		private BattleHonourData m_battleHonourData;

		// Token: 0x040033D1 RID: 13265
		private int currentPillageType;

		// Token: 0x040033D2 RID: 13266
		private bool noCaptain;

		// Token: 0x040033D3 RID: 13267
		private int maxPillageValue = 1;

		// Token: 0x040033D4 RID: 13268
		private int maxRansackValue = 1;

		// Token: 0x040033D5 RID: 13269
		private int maxGoldRaidValue = 1;

		// Token: 0x040033D6 RID: 13270
		private double storedPreCardDistance;

		// Token: 0x040033D7 RID: 13271
		private int m_lastSeaConditions = -1;

		// Token: 0x040033D8 RID: 13272
		private int currentCommand = -1;

		// Token: 0x040033D9 RID: 13273
		private DateTime lastLaunchTime = DateTime.MinValue;

		// Token: 0x040033DA RID: 13274
		private int attackTypeRef;

		// Token: 0x040033DB RID: 13275
		private int pillageValueRef;

		// Token: 0x040033DC RID: 13276
		private IContainer components;
	}
}
