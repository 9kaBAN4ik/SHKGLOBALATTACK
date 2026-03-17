using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000196 RID: 406
	public class CustomTooltipPanel : CustomSelfDrawPanel
	{
		// Token: 0x06000FA9 RID: 4009 RVA: 0x000116BA File Offset: 0x0000F8BA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x00111C8C File Offset: 0x0010FE8C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "CustomTooltipPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x00111CE0 File Offset: 0x0010FEE0
		public CustomTooltipPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x00111DC4 File Offset: 0x0010FFC4
		public void setText(string text, int tooltipID, int data, Form parent, bool force)
		{
			if (tooltipID == 141)
			{
				this.createVillagePeasant(tooltipID, data, parent, force);
				return;
			}
			if (tooltipID == 10000 || tooltipID == 10101)
			{
				this.createCardTooltip(tooltipID, data, parent, force);
				return;
			}
			if (this.lastText != text || force)
			{
				this.lastText = text;
				this.lastTooltip = tooltipID;
				base.clearControls();
				this.tooltipLabel.Text = text;
				this.tooltipLabel.Color = global::ARGBColors.Black;
				this.tooltipLabel.Position = new Point(2, 2);
				this.tooltipLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				Graphics graphics = base.CreateGraphics();
				Size size = graphics.MeasureString(text, this.tooltipLabel.Font, 350).ToSize();
				graphics.Dispose();
				this.tooltipLabel.Size = new Size(size.Width + 1, size.Height + 1);
				Size size2 = new Size(size.Width + 4 + 1, size.Height + 4 + 1);
				if (!size2.Equals(parent.Size))
				{
					parent.Size = size2;
				}
				this.tooltipLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.background.Size = size2;
				this.background.Position = new Point(0, 0);
				base.addControl(this.background);
				this.background.Create(GFXLibrary.cardpanel_grey_9slice_left_top, GFXLibrary.cardpanel_grey_9slice_middle_top, GFXLibrary.cardpanel_grey_9slice_right_top, GFXLibrary.cardpanel_grey_9slice_left_middle, GFXLibrary.cardpanel_grey_9slice_middle_middle, GFXLibrary.cardpanel_grey_9slice_right_middle, GFXLibrary.cardpanel_grey_9slice_left_bottom, GFXLibrary.cardpanel_grey_9slice_middle_bottom, GFXLibrary.cardpanel_grey_9slice_right_bottom);
				this.background.addControl(this.tooltipLabel);
				base.Invalidate();
				parent.Invalidate();
			}
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x000116D9 File Offset: 0x0000F8D9
		public void hidingTooltip()
		{
			this.lastText = "";
			this.lastTooltip = -1;
			this.lastData = -1;
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x00111FBC File Offset: 0x001101BC
		public void createCardTooltip(int tooltipID, int data, Form parent, bool force)
		{
			if (this.lastTooltip != tooltipID || this.lastData != data || force)
			{
				this.lastText = "x";
				this.lastData = data;
				this.lastTooltip = tooltipID;
				parent.Size = new Size(300, 240);
				base.clearControls();
				this.background.Size = parent.Size;
				this.background.Position = new Point(0, 0);
				base.addControl(this.background);
				this.background.Create(GFXLibrary.cardpanel_grey_9slice_left_top, GFXLibrary.cardpanel_grey_9slice_middle_top, GFXLibrary.cardpanel_grey_9slice_right_top, GFXLibrary.cardpanel_grey_9slice_left_middle, GFXLibrary.cardpanel_grey_9slice_middle_middle, GFXLibrary.cardpanel_grey_9slice_right_middle, GFXLibrary.cardpanel_grey_9slice_left_bottom, GFXLibrary.cardpanel_grey_9slice_middle_bottom, GFXLibrary.cardpanel_grey_9slice_right_bottom);
				this.cardTooltipName.Text = CardTypes.getDescriptionFromCard(data);
				this.cardTooltipName.Color = global::ARGBColors.Black;
				this.cardTooltipName.Position = new Point(100, 4);
				this.cardTooltipName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.cardTooltipName.Size = new Size(190, 40);
				this.cardTooltipName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.background.addControl(this.cardTooltipName);
				this.cardTooltipDescription.Text = CardTypes.getEffectTextFromCard(data);
				this.cardTooltipDescription.Color = global::ARGBColors.Black;
				this.cardTooltipDescription.Position = new Point(100, 50);
				this.cardTooltipDescription.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.cardTooltipDescription.Size = new Size(190, 100);
				this.cardTooltipDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.background.addControl(this.cardTooltipDescription);
				this.cardTooltipImage.Image = GFXLibrary.Instance.getCardImageBig(data);
				GFXLibrary.Instance.closeBigCardsLoader();
				this.cardTooltipImage.Position = new Point(4, 4);
				this.cardTooltipImage.Size = new Size(92, 131);
				this.background.addControl(this.cardTooltipImage);
				switch (CardTypes.getColourFromCard(data))
				{
				case 1:
					this.cardTooltipImage2.Image = GFXLibrary.BlueCardOverlayBig;
					break;
				case 2:
					this.cardTooltipImage2.Image = GFXLibrary.GreenCardOverlayBig;
					break;
				case 3:
					this.cardTooltipImage2.Image = GFXLibrary.PurpleCardOverlayBig;
					break;
				case 4:
					this.cardTooltipImage2.Image = GFXLibrary.RedCardOverlayBig;
					break;
				case 5:
					this.cardTooltipImage2.Image = GFXLibrary.YellowCardOverlayBig;
					break;
				}
				this.cardTooltipImage2.Size = this.cardTooltipImage.Size;
				this.cardTooltipImage.addControl(this.cardTooltipImage2);
				if (tooltipID == 10000)
				{
					WorldData localWorldData = GameEngine.Instance.LocalWorldData;
					DateTime currentServerTime = VillageMap.getCurrentServerTime();
					CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
					DateTime d = DateTime.MinValue;
					int num = 0;
					int num2 = userCardData.cards.Length;
					int i = 0;
					while (i < num2)
					{
						int num3 = userCardData.cards[i];
						if (num3 == data)
						{
							d = userCardData.cardsExpiry[i];
							TimeSpan timeSpan = d - currentServerTime;
							CardTypes.getCardDuration(num3);
							num = (int)timeSpan.TotalSeconds;
							if (num < 0)
							{
								num = 0;
							}
							if (timeSpan.TotalDays > 100.0)
							{
								num = -1;
								break;
							}
							break;
						}
						else
						{
							i++;
						}
					}
					if (num < 0)
					{
						this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_EXPIRES", "Expires when used");
					}
					else
					{
						string str = VillageMap.createBuildTimeString(num);
						this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_EXPIRES_IN", "Expires In") + " : " + str;
					}
				}
				else if (CardTypes.getCardSubType(data) == 3072)
				{
					this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_INSTANT", "Instant Card");
				}
				else
				{
					int cardDuration = CardTypes.getCardDuration(data);
					if (cardDuration > 18250 || cardDuration == 0)
					{
						this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_EXPIRES", "Expires when used");
					}
					else
					{
						int secsLeft = cardDuration * 60 * 60;
						string str2 = VillageMap.createBuildTimeString(secsLeft);
						this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_DURATION", "Duration") + " : " + str2;
					}
				}
				this.timeImage.Image = GFXLibrary.r_building_panel_inset_icon_time;
				this.timeImage.Position = new Point(10, 158);
				this.background.addControl(this.timeImage);
				this.cardTooltipTimeLeft.Color = global::ARGBColors.Black;
				this.cardTooltipTimeLeft.Position = new Point(40, 160);
				this.cardTooltipTimeLeft.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.cardTooltipTimeLeft.Size = new Size(250, 40);
				this.cardTooltipTimeLeft.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.background.addControl(this.cardTooltipTimeLeft);
				string text = "";
				double cardEffectValue = CardTypes.getCardEffectValue(data);
				int num4 = (int)cardEffectValue;
				NumberFormatInfo provider = ((double)num4 == cardEffectValue) ? GameEngine.NFI : ((CardTypes.getCardType(data) != 2061) ? GameEngine.NFI_D1 : GameEngine.NFI_D2);
				if (CardTypes.addX(data))
				{
					text = "x" + cardEffectValue.ToString("N", provider);
				}
				else if (CardTypes.addPlus(data))
				{
					text = "+" + cardEffectValue.ToString("N", provider);
				}
				else if (cardEffectValue != 0.0)
				{
					text = cardEffectValue.ToString("N", provider);
				}
				if (CardTypes.addPercent(data))
				{
					text += "%";
				}
				if (text.Length > 0)
				{
					int cardType = CardTypes.getCardType(data);
					if (cardType - 3008 > 2)
					{
						if (cardType - 3077 <= 2)
						{
							int rank = GameEngine.Instance.World.getRank();
							double num5 = (double)GameEngine.Instance.LocalWorldData.ranks_HonourPerLevel[rank];
							num5 *= cardEffectValue;
							text = ((int)num5).ToString("N", GameEngine.NFI);
						}
					}
					else
					{
						text = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_DIPLOMACY", "50% Chance of Averting Enemy Attacks");
					}
					this.cardTooltipEffect.Text = text + " " + CustomTooltipPanel.getCardEffectString(data);
					this.cardTooltipEffect.Color = global::ARGBColors.Black;
					this.cardTooltipEffect.Position = new Point(10, 190);
					this.cardTooltipEffect.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.cardTooltipEffect.Size = new Size(290, 60);
					this.cardTooltipEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.background.addControl(this.cardTooltipEffect);
				}
				else if (tooltipID == 10101)
				{
					this.cardTooltipEffect.Text = CustomTooltipPanel.getCardEffectString(data);
					this.cardTooltipEffect.Color = global::ARGBColors.Black;
					this.cardTooltipEffect.Position = new Point(10, 190);
					this.cardTooltipEffect.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
					this.cardTooltipEffect.Size = new Size(290, 60);
					this.cardTooltipEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.background.addControl(this.cardTooltipEffect);
				}
				else
				{
					this.cardTooltipEffect.Text = "";
				}
				base.Invalidate();
				parent.Invalidate();
				return;
			}
			WorldData localWorldData2 = GameEngine.Instance.LocalWorldData;
			DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
			CardData userCardData2 = GameEngine.Instance.cardsManager.UserCardData;
			DateTime d2 = DateTime.MinValue;
			int num6 = 0;
			int num7 = userCardData2.cards.Length;
			int j = 0;
			while (j < num7)
			{
				int num8 = userCardData2.cards[j];
				if (num8 == data)
				{
					d2 = userCardData2.cardsExpiry[j];
					TimeSpan timeSpan2 = d2 - currentServerTime2;
					CardTypes.getCardDuration(num8);
					num6 = (int)timeSpan2.TotalSeconds;
					if (num6 < 0)
					{
						num6 = 0;
					}
					if (timeSpan2.TotalDays > 100.0)
					{
						num6 = -1;
						break;
					}
					break;
				}
				else
				{
					j++;
				}
			}
			if (num6 < 0)
			{
				this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_EXPIRES", "Expires when used");
				return;
			}
			string str3 = VillageMap.createBuildTimeString(num6);
			this.cardTooltipTimeLeft.Text = SK.Text("TOOLTIP_CARD_EXPIRES_IN", "Expires In") + " : " + str3;
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x00112894 File Offset: 0x00110A94
		public void createVillagePeasant(int tooltipID, int data, Form parent, bool force)
		{
			if (this.lastTooltip != tooltipID || this.lastData != data || force)
			{
				this.lastText = "x";
				this.lastData = data;
				this.lastTooltip = tooltipID;
				Graphics graphics = base.CreateGraphics();
				Font font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				Size size = graphics.MeasureString(SK.Text("TOOLTIP_VILAGEMAP_TOTAL_PEASANTS", "Total Peasants"), font, 800).ToSize();
				Size size2 = graphics.MeasureString(SK.Text("TOOLTIP_VILAGEMAP_UNEMPLOYEED_PEASANTS", "Unemployed Peasants"), font, 800).ToSize();
				Size size3 = graphics.MeasureString(SK.Text("TOOLTIP_VILAGEMAP_HOUSING_CAPACITY", "Housing Capacity"), font, 800).ToSize();
				int num = size.Width;
				if (size2.Width > num)
				{
					num = size2.Width;
				}
				if (size3.Width > num)
				{
					num = size3.Width;
				}
				num += 60;
				graphics.Dispose();
				parent.Size = new Size(num, 100);
				base.clearControls();
				this.background.Size = parent.Size;
				this.background.Position = new Point(0, 0);
				base.addControl(this.background);
				this.background.Create(GFXLibrary.cardpanel_grey_9slice_left_top, GFXLibrary.cardpanel_grey_9slice_middle_top, GFXLibrary.cardpanel_grey_9slice_right_top, GFXLibrary.cardpanel_grey_9slice_left_middle, GFXLibrary.cardpanel_grey_9slice_middle_middle, GFXLibrary.cardpanel_grey_9slice_right_middle, GFXLibrary.cardpanel_grey_9slice_left_bottom, GFXLibrary.cardpanel_grey_9slice_middle_bottom, GFXLibrary.cardpanel_grey_9slice_right_bottom);
				this.peasantsLabel.Text = SK.Text("TOOLTIP_VILAGEMAP_TOTAL_PEASANTS", "Total Peasants");
				this.peasantsLabel.Color = global::ARGBColors.Black;
				this.peasantsLabel.Position = new Point(10, 10);
				this.peasantsLabel.Font = font;
				this.peasantsLabel.Size = new Size(num - 20, 30);
				this.background.addControl(this.peasantsLabel);
				this.peasantsValue.Text = "0";
				this.peasantsValue.Color = global::ARGBColors.Black;
				this.peasantsValue.Position = new Point(10, 10);
				this.peasantsValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.peasantsValue.Size = new Size(num - 20, 30);
				this.peasantsValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.background.addControl(this.peasantsValue);
				this.spareWorkersLabel.Text = SK.Text("TOOLTIP_VILAGEMAP_UNEMPLOYEED_PEASANTS", "Unemployed Peasants");
				this.spareWorkersLabel.Color = global::ARGBColors.Black;
				this.spareWorkersLabel.Position = new Point(10, 40);
				this.spareWorkersLabel.Font = font;
				this.spareWorkersLabel.Size = new Size(num - 20, 30);
				this.background.addControl(this.spareWorkersLabel);
				this.spareWorkersValue.Text = "0";
				this.spareWorkersValue.Color = global::ARGBColors.Black;
				this.spareWorkersValue.Position = new Point(10, 40);
				this.spareWorkersValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.spareWorkersValue.Size = new Size(num - 20, 30);
				this.spareWorkersValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.background.addControl(this.spareWorkersValue);
				this.housingLabel.Text = SK.Text("TOOLTIP_VILAGEMAP_HOUSING_CAPACITY", "Housing Capacity");
				this.housingLabel.Color = global::ARGBColors.Black;
				this.housingLabel.Position = new Point(10, 70);
				this.housingLabel.Font = font;
				this.housingLabel.Size = new Size(num - 20, 30);
				this.background.addControl(this.housingLabel);
				this.housingValue.Text = "0";
				this.housingValue.Color = global::ARGBColors.Black;
				this.housingValue.Position = new Point(10, 70);
				this.housingValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.housingValue.Size = new Size(num - 20, 30);
				this.housingValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.background.addControl(this.housingValue);
				base.Invalidate();
				parent.Invalidate();
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.peasantsValue.Text = village.m_totalPeople.ToString();
				this.spareWorkersValue.Text = village.m_spareWorkers.ToString();
				this.housingValue.Text = village.m_housingCapacity.ToString();
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x00112D88 File Offset: 0x00110F88
		public static string getFullCardEffectString(int data)
		{
			string text = "";
			double cardEffectValue = CardTypes.getCardEffectValue(data);
			int num = (int)cardEffectValue;
			NumberFormatInfo provider = ((double)num == cardEffectValue) ? GameEngine.NFI : ((CardTypes.getCardType(data) != 2061) ? GameEngine.NFI_D1 : GameEngine.NFI_D2);
			if (CardTypes.addX(data))
			{
				text = "x" + cardEffectValue.ToString("N", provider);
			}
			else if (CardTypes.addPlus(data))
			{
				text = "+" + cardEffectValue.ToString("N", provider);
			}
			else if (cardEffectValue != 0.0)
			{
				text = cardEffectValue.ToString("N", provider);
			}
			if (CardTypes.addPercent(data))
			{
				text += "%";
			}
			if (text.Length > 0)
			{
				int cardType = CardTypes.getCardType(data);
				if (cardType - 3008 > 2)
				{
					if (cardType - 3077 <= 2)
					{
						int rank = GameEngine.Instance.World.getRank();
						double num2 = (double)GameEngine.Instance.LocalWorldData.ranks_HonourPerLevel[rank];
						num2 *= cardEffectValue;
						text = ((int)num2).ToString("N", GameEngine.NFI);
					}
				}
				else
				{
					text = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_DIPLOMACY", "50% Chance of Averting Enemy Attacks");
				}
				return text + " " + CustomTooltipPanel.getCardEffectString(data);
			}
			return CustomTooltipPanel.getCardEffectString(data);
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x00112ED8 File Offset: 0x001110D8
		public static string getCardEffectString(int card)
		{
			string result = "";
			int cardType = CardTypes.getCardType(card);
			if (cardType <= 1802)
			{
				if (cardType <= 1039)
				{
					if (cardType <= 542)
					{
						switch (cardType)
						{
						case 257:
						case 258:
						case 259:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MASTER_MASON", "Castle build speed");
							break;
						case 260:
						case 261:
						case 262:
							break;
						case 263:
							result = "";
							break;
						case 264:
						case 267:
						case 268:
							result = "";
							break;
						case 265:
						case 269:
						case 270:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SURPRISE_ATTACK", "Knights Charge");
							break;
						case 266:
						case 271:
						case 272:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_THE_LAST_STAND", "Knights Charge");
							break;
						default:
							switch (cardType)
							{
							case 513:
							case 514:
							case 515:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ORCHARD_MANAGEMENT", "Increase in Apple Production");
								break;
							case 516:
							case 517:
							case 518:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MILK_MAIDS", "Increase in Cheese Production");
								break;
							case 519:
							case 520:
							case 521:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PIG_BREEDING", "Increase in Meat Production");
								break;
							case 522:
							case 523:
							case 524:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_HARVESTING", "Increase in Bread Production");
								break;
							case 525:
							case 526:
							case 527:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_VETERAN_FARMER", "Increase in All Food Production");
								break;
							case 528:
							case 529:
							case 530:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CROPPING", "Increase in Vegetable Production");
								break;
							case 531:
							case 532:
							case 533:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FISHING", "Increase in Fish Production");
								break;
							case 534:
							case 535:
							case 536:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SIMPLE_FEAST", "Increase in Popularity from Rations");
								break;
							case 537:
							case 538:
							case 539:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_HOPS_TENDING", "Increase in Ale Production");
								break;
							case 540:
							case 541:
							case 542:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BAR_KEEPING", "Increase in Popularity from Ale Consumption");
								break;
							}
							break;
						}
					}
					else
					{
						switch (cardType)
						{
						case 769:
						case 770:
						case 771:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_WOODSMAN_SHIP", "Increase in Wood Production");
							break;
						case 772:
						case 773:
						case 774:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_STONE_CRAFT", "Increase in Stone Production");
							break;
						case 775:
						case 776:
						case 777:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IRON_SMELTING", "Increase in Iron Production");
							break;
						case 778:
						case 779:
						case 780:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PITCH_EXTRACTION", "Increase in Pitch Production");
							break;
						case 781:
						case 782:
						case 783:
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_HAULAGE", "Increase in All Raw Material Production");
							break;
						default:
							switch (cardType)
							{
							case 1025:
							case 1026:
							case 1027:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BODKIN_CASTING", "Increase in Bow Production");
								break;
							case 1028:
							case 1029:
							case 1030:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PIKE_CRAFT", "Increase in Pike Production");
								break;
							case 1031:
							case 1032:
							case 1033:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SWORD_CRAFT", "Increase in Sword Production");
								break;
							case 1034:
							case 1035:
							case 1036:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ARMOUR_WORKING", "Increase in Armour Production");
								break;
							case 1037:
							case 1038:
							case 1039:
								result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SIEGE_ENGINEERS", "Increase in Catapult Production");
								break;
							}
							break;
						}
					}
				}
				else if (cardType <= 1539)
				{
					switch (cardType)
					{
					case 1281:
					case 1282:
					case 1283:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_LAVISH_BANQUETING", "Increase in Honour When Holding a Banquet");
						break;
					case 1284:
					case 1285:
					case 1286:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_DEER_STALKING", "Increase in Venison Production");
						break;
					case 1287:
					case 1288:
					case 1289:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FURNITURE_MAKING", "Increase in Furniture Production");
						break;
					case 1290:
					case 1291:
					case 1292:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_METAL_CRAFTS", "Increase in Metalware Production");
						break;
					case 1293:
					case 1294:
					case 1295:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_TAILORING", "Increase in Clothes Production");
						break;
					case 1296:
					case 1297:
					case 1298:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_VINTNERS", "Increase in Wine Production");
						break;
					case 1299:
					case 1300:
					case 1301:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SALT_WORKING", "Increase in Salt Production");
						break;
					case 1302:
					case 1303:
					case 1304:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CULINARY_SKILLS", "Increase in Spice Production");
						break;
					case 1305:
					case 1306:
					case 1307:
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FINE_ATTIRE", "Increase in Silk Production");
						break;
					default:
						if (cardType - 1537 <= 2)
						{
							result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CARTERS", "Increase in Merchant Speed");
						}
						break;
					}
				}
				else if (cardType - 1541 > 2)
				{
					if (cardType - 1800 <= 2)
					{
						result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CONSTRUCTION_TECHNIQUES", "Increase in Village Building Build Speed");
					}
				}
				else
				{
					result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_TRADE_CARAVANS", "Increase in Merchant Carrying Capacity");
				}
			}
			else
			{
				if (cardType <= 2563)
				{
					if (cardType <= 2307)
					{
						switch (cardType)
						{
						case 2049:
						case 2050:
						case 2051:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_POLITICS", "Increase in Monk Votes");
						case 2052:
						case 2053:
						case 2054:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_WEDDINGS", "Increase in Blessing Duration");
						case 2055:
						case 2056:
						case 2057:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_INQUISITION_TECHNIQUES", "Increase in Inquisition Duration");
						case 2058:
						case 2059:
						case 2060:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_HEALING", "Increase in Healing");
						case 2061:
						case 2062:
						case 2063:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PROTECTION", "Increase in duration of interdiction given by monks");
						case 2064:
						case 2065:
						case 2066:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXCOMMUNICATION", "Increase in Excommunication Duration");
						case 2067:
						case 2068:
						case 2069:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ABSOLUTION", "Increase in Excommunication Duration Reduction");
						case 2070:
						case 2071:
						case 2072:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ENVOY", "Increase in Monks Speed");
						default:
							if (cardType - 2305 > 2)
							{
								return result;
							}
							break;
						}
					}
					else
					{
						if (cardType - 2308 <= 2)
						{
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_SCAVENGING", "Increase in Scout Carrying Capacity");
						}
						if (cardType - 2561 > 2)
						{
							return result;
						}
						goto IL_DC0;
					}
				}
				else if (cardType <= 2696)
				{
					if (cardType - 2564 <= 2)
					{
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_RECRUITMENT", "Cost of Troop Recruitment");
					}
					switch (cardType)
					{
					case 2689:
					case 2690:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SCOUTING_RANGE", "Increase in your Honour Range");
					case 2691:
					case 2692:
					case 2693:
						break;
					case 2694:
					case 2695:
					case 2696:
						goto IL_DC0;
					default:
						return result;
					}
				}
				else
				{
					switch (cardType)
					{
					case 2817:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_HOUSEKEEPING", "Increase in House Capacity");
					case 2818:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_GRANARIES", "Increase in Granary Capacity");
					case 2819:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_STOCKPILING", "Increase in Stockpile Capacity");
					case 2820:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_CELLARING", "Increase in Inn Capacity");
					case 2821:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_ARMOURIES", "Increase in Armoury Capacity");
					case 2822:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXPANDED_KEEP_STORAGE", "Increase in Village Hall Capacity");
					case 2823:
					case 2824:
					case 2825:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_CULTURE", "Increase in Popularity To Honour Multiplier");
					case 2826:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FAIRER_JUSTICE", "Reduction in Negative Popularity from Justice Buildings");
					case 2827:
					case 2828:
					case 2829:
					case 2830:
						return "????";
					case 2831:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FESTIVAL", "Popularity Boost");
					case 2832:
					case 2833:
					case 2834:
					case 2835:
					case 2836:
					case 2837:
					case 2838:
					case 2839:
					case 2840:
					case 2841:
					case 2842:
					case 2843:
					case 2844:
					case 2845:
					case 2846:
					case 2847:
					case 2848:
					case 2849:
					case 2850:
					case 2851:
					case 2852:
					case 2853:
					case 2854:
					case 2855:
					case 2856:
					case 2857:
					case 2858:
					case 2859:
					case 2860:
					case 2861:
					case 2862:
					case 2863:
					case 2864:
					case 2865:
					case 2866:
					case 2867:
					case 2868:
					case 2869:
					case 2870:
					case 2871:
					case 2872:
					case 2873:
					case 2874:
					case 2875:
					case 2876:
					case 2877:
					case 2878:
					case 2879:
					case 2880:
					case 2884:
					case 2885:
					case 2886:
					case 2890:
					case 2891:
					case 2892:
					case 2893:
					case 2894:
					case 2895:
					case 2896:
					case 2897:
					case 2898:
					case 2899:
					case 2900:
					case 2901:
					case 2902:
					case 2903:
					case 2904:
					case 2905:
					case 2906:
					case 2907:
					case 2908:
					case 2909:
					case 2910:
					case 2911:
					case 2912:
					case 2913:
					case 2914:
					case 2915:
					case 2916:
					case 2917:
					case 2918:
					case 2919:
					case 2920:
					case 2921:
					case 2922:
					case 2923:
					case 2924:
					case 2925:
					case 2926:
					case 2927:
					case 2928:
					case 2929:
					case 2930:
					case 2931:
					case 2932:
					case 2933:
					case 2934:
					case 2935:
					case 2936:
					case 2937:
					case 2938:
					case 2939:
					case 2940:
					case 2941:
					case 2942:
					case 2943:
					case 2944:
					case 2976:
					case 2977:
					case 2978:
					case 2979:
					case 2980:
					case 2981:
					case 2982:
					case 2983:
					case 2984:
					case 2985:
					case 2986:
					case 2987:
					case 2988:
					case 2989:
					case 2990:
					case 2991:
					case 2992:
					case 2993:
					case 2994:
					case 2995:
					case 2996:
					case 2997:
					case 2998:
					case 2999:
					case 3000:
					case 3001:
					case 3002:
					case 3003:
					case 3004:
					case 3005:
					case 3006:
					case 3007:
					case 3008:
					case 3009:
					case 3010:
					case 3011:
					case 3012:
					case 3013:
					case 3014:
					case 3015:
					case 3016:
					case 3017:
					case 3018:
					case 3019:
					case 3020:
					case 3021:
					case 3022:
					case 3023:
					case 3024:
					case 3025:
					case 3026:
					case 3027:
					case 3028:
					case 3029:
					case 3030:
					case 3054:
					case 3060:
					case 3061:
					case 3062:
					case 3063:
					case 3064:
					case 3065:
					case 3066:
					case 3067:
					case 3068:
					case 3069:
					case 3070:
					case 3071:
					case 3072:
						return result;
					case 2881:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_COMPLETED_CONTRACT", "Trade Completed Immediately");
					case 2882:
					case 2883:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_COMPLETED_CONTRACT", "Trades Completed Immediately");
					case 2887:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_COMPLETED_DELIVERY", "Delivery Completed Immediately");
					case 2888:
					case 2889:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ADVANCED_COMPLETED_DELIVERY", "Deliveries Completed Immediately");
					case 2945:
					case 2946:
					case 2947:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_GUARD_HOUSES", "Extra Spaces for Troops in your Castle");
					case 2948:
					case 2949:
					case 2950:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_WOODEN_DEFENCES", "Stronger Wooden Castle Structures");
					case 2951:
					case 2952:
					case 2953:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_STONE_WALLS", "Stronger Stone Walls");
					case 2954:
					case 2955:
					case 2956:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_STONE_STRUCTURES", "Stronger Stone Structures");
					case 2957:
					case 2958:
					case 2959:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_MOATS", "Deeper Moats");
					case 2960:
					case 2961:
					case 2962:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_PITS", "More Damage from Pits");
					case 2963:
					case 2964:
					case 2965:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IMPROVED_OIL_POTS", "Extra Range of Oil Pots");
					case 2966:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_KNIGHTS_CHARGE", "Increase in Knights Speed");
					case 2967:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXPERT_TURRETS", "Turret Firing Speed");
					case 2968:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXPERT_TUNNELLING", "Troops From a Tunnel");
					case 2969:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXPERT_BALLISTAE", "Ballistae Firing Speed");
					case 2970:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SUPER_TAX", "Extra Tax Band");
					case 2971:
					case 2972:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SUPER_TAX_ADVANCED", "Extra Tax Bands");
					case 2973:
					case 2974:
					case 2975:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_EXTRA_TAX", "Increase in Tax Collected");
					case 3031:
					case 3032:
					case 3033:
					case 3034:
					case 3035:
					case 3036:
					case 3037:
					case 3038:
					case 3039:
					case 3040:
					case 3041:
					case 3042:
					case 3043:
					case 3044:
					case 3045:
					case 3046:
					case 3047:
					case 3048:
					case 3049:
					case 3050:
					case 3051:
					case 3052:
					case 3053:
					case 3055:
					case 3056:
					case 3057:
					case 3058:
					case 3059:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_INSTANT_BUILDING", "Instant building available");
					case 3073:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_RESEARCH_POINT", "Research Point Added");
					case 3074:
					case 3075:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_RESEARCH_POINTS_2", "Research Points Added");
					case 3076:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FLAG", "Flag Added To Parish");
					case 3077:
					case 3078:
					case 3079:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_CHIVALRY", "Honour (Based on your Current Rank)");
					case 3080:
					case 3081:
					case 3082:
					case 3083:
					case 3084:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_GOLD_HORDE", "Gold Added To Your Treasury");
					case 3085:
					case 3086:
					case 3087:
					case 3088:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_APPLE_HAUL", "Apples Added To Your Granary");
					case 3089:
					case 3090:
					case 3091:
					case 3092:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CHEESE_HAUL", "Cheese Added To Your Granary");
					case 3093:
					case 3094:
					case 3095:
					case 3096:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MEAT_HAUL", "Meat Added To Your Granary");
					case 3097:
					case 3098:
					case 3099:
					case 3100:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BREAD_HAUL", "Bread Added To Your Granary");
					case 3101:
					case 3102:
					case 3103:
					case 3104:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_VEGETABLES_HAUL", "Vegetables Added To Your Granary");
					case 3105:
					case 3106:
					case 3107:
					case 3108:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FISH_HAUL", "Fish Added To Your Granary");
					case 3109:
					case 3110:
					case 3111:
					case 3112:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ALE_HAUL", "Ale Added To Your Inn");
					case 3113:
					case 3114:
					case 3115:
					case 3116:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_WOOD_HAUL", "Wood Added To Your Stockpile");
					case 3117:
					case 3118:
					case 3119:
					case 3120:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_STONE_HAUL", "Stone Added To Your Stockpile");
					case 3121:
					case 3122:
					case 3123:
					case 3124:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_IRON_HAUL", "Iron Added To Your Stockpile");
					case 3125:
					case 3126:
					case 3127:
					case 3128:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PITCH_HAUL", "Pitch Added To Your Stockpile");
					case 3129:
					case 3130:
					case 3131:
					case 3132:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_VENISON_HAUL", "Venison Added To Your Keep");
					case 3133:
					case 3134:
					case 3135:
					case 3136:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_FURNITURE_HAUL", "Furniture Added To Your Keep");
					case 3137:
					case 3138:
					case 3139:
					case 3140:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_METALWARE_HAUL", "Metalware Added To Your Keep");
					case 3141:
					case 3142:
					case 3143:
					case 3144:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CLOTHES_HAUL", "Clothes Added To Your Keep");
					case 3145:
					case 3146:
					case 3147:
					case 3148:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_WINE_HAUL", "Wine Added To Your Keep");
					case 3149:
					case 3150:
					case 3151:
					case 3152:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SALT_HAUL", "Salt Added To Your Keep");
					case 3153:
					case 3154:
					case 3155:
					case 3156:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SPICES_HAUL", "Spices Added To Your Keep");
					case 3157:
					case 3158:
					case 3159:
					case 3160:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SILK_HAUL", "Silk Added To Your Keep");
					case 3161:
					case 3162:
					case 3163:
					case 3164:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BOWS_HAUL", "Bows Added To Your Armoury");
					case 3165:
					case 3166:
					case 3167:
					case 3168:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PIKES_HAUL", "Pikes Added To Your Armoury");
					case 3169:
					case 3170:
					case 3171:
					case 3172:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ARMOUR_HAUL", "Armour Added To Your Armoury");
					case 3173:
					case 3174:
					case 3175:
					case 3176:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_SWORDS_HAUL", "Swords Added To Your Armoury");
					case 3177:
					case 3178:
					case 3179:
					case 3180:
						return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CATAPULTS_HAUL", "Catapults Added To Your Armoury");
					default:
						if (cardType - 3201 <= 2)
						{
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_CASTLE_DESIGNER", "Hours of ongoing Castle Construction Completed");
						}
						switch (cardType)
						{
						case 3249:
						case 3250:
						case 3251:
						case 3252:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_ACADEMIC_STUDY", "Hours of Research Completed");
						case 3253:
						case 3254:
						case 3255:
						case 3256:
						case 3257:
						case 3258:
						case 3259:
						case 3260:
						case 3261:
						case 3262:
						case 3263:
							return result;
						case 3264:
						case 3265:
						case 3266:
						case 3267:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_PEASANTS_SMALL", "Peasants");
						case 3268:
						case 3269:
						case 3270:
						case 3271:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_ARCHERS_SMALL", "Archers");
						case 3272:
						case 3273:
						case 3274:
						case 3275:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_PIKEMEN_SMALL", "Pikemen");
						case 3276:
						case 3277:
						case 3278:
						case 3279:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_SWORDSMEN_SMALL", "Swordsmen");
						case 3280:
						case 3281:
						case 3282:
						case 3283:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_CATAPULTS_SMALL", "Catapults");
						case 3284:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_WALL_CONSTRUCTION_TEAM", "Hours of Castle Wall Construction Completed");
						case 3285:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MOAT_DIGGING_TEAM", "Hours of Moat Construction Completed");
						case 3286:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_PIT_CONSTRUCTION_TEAM", "Hours of Castle Pits Construction Completed");
						case 3287:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_SCOUTS_SMALL", "Scout");
						case 3288:
						case 3289:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_SCOUTS_MEDIUM", "Scouts");
						case 3290:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_MONKS_SMALL", "Monk");
						case 3291:
						case 3292:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_MONKS_MEDIUM", "Monks");
						case 3293:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_MERCHANTS_SMALL", "Merchant");
						case 3294:
						case 3295:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_MERCENARIES_MERCHANTS_MEDIUM", "Merchants");
						case 3296:
						case 3297:
						case 3298:
							return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_VILLAGERS_SMALL", "Villagers");
						default:
							return result;
						}
						break;
					}
				}
				return SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_HORSE_BREEDING", "Increase in Scout Speed");
				IL_DC0:
				result = SK.Text("TOOLTIP_CARD_EFFECT_EXPLANATION_CARDTYPE_BASIC_DISCIPLINE", "Increase in Army Speed");
			}
			return result;
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x001142D4 File Offset: 0x001124D4
		public static string getCardDurationString(bool cardInPlay, int cardID)
		{
			if (cardInPlay)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
				DateTime d = DateTime.MinValue;
				int num = 0;
				int num2 = userCardData.cards.Length;
				int i = 0;
				while (i < num2)
				{
					int num3 = userCardData.cards[i];
					if (num3 == cardID)
					{
						d = userCardData.cardsExpiry[i];
						TimeSpan timeSpan = d - currentServerTime;
						CardTypes.getCardDuration(num3);
						num = (int)timeSpan.TotalSeconds;
						if (num < 0)
						{
							num = 0;
						}
						if (timeSpan.TotalDays > 100.0)
						{
							num = -1;
							break;
						}
						break;
					}
					else
					{
						i++;
					}
				}
				if (num < 0)
				{
					return SK.Text("TOOLTIP_CARD_EXPIRES", "Expires when used");
				}
				string str = VillageMap.createBuildTimeString(num);
				return SK.Text("TOOLTIP_CARD_EXPIRES_IN", "Expires In") + " : " + str;
			}
			else
			{
				if (CardTypes.getCardSubType(cardID) == 3072)
				{
					return SK.Text("TOOLTIP_CARD_INSTANT", "Instant Card");
				}
				int cardDuration = CardTypes.getCardDuration(cardID);
				if (cardDuration > 18250 || cardDuration == 0)
				{
					return SK.Text("TOOLTIP_CARD_EXPIRES", "Expires when used");
				}
				int secsLeft = cardDuration * 60 * 60;
				string str2 = VillageMap.createBuildTimeString(secsLeft);
				return SK.Text("TOOLTIP_CARD_DURATION", "Duration") + " : " + str2;
			}
		}

		// Token: 0x040015BD RID: 5565
		public const int MAX_TOOLTIP_WIDTH = 350;

		// Token: 0x040015BE RID: 5566
		private IContainer components;

		// Token: 0x040015BF RID: 5567
		private CustomSelfDrawPanel.CSDLabel tooltipLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015C0 RID: 5568
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040015C1 RID: 5569
		private string lastText = "";

		// Token: 0x040015C2 RID: 5570
		private int lastTooltip = -1;

		// Token: 0x040015C3 RID: 5571
		private int lastData = -1;

		// Token: 0x040015C4 RID: 5572
		private CustomSelfDrawPanel.CSDLabel cardTooltipName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015C5 RID: 5573
		private CustomSelfDrawPanel.CSDLabel cardTooltipDescription = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015C6 RID: 5574
		private CustomSelfDrawPanel.CSDLabel cardTooltipEffect = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015C7 RID: 5575
		private CustomSelfDrawPanel.CSDLabel cardTooltipTimeLeft = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015C8 RID: 5576
		private CustomSelfDrawPanel.CSDImage cardTooltipImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040015C9 RID: 5577
		private CustomSelfDrawPanel.CSDImage cardTooltipImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040015CA RID: 5578
		private CustomSelfDrawPanel.CSDImage timeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040015CB RID: 5579
		private CustomSelfDrawPanel.CSDLabel peasantsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015CC RID: 5580
		private CustomSelfDrawPanel.CSDLabel peasantsValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015CD RID: 5581
		private CustomSelfDrawPanel.CSDLabel housingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015CE RID: 5582
		private CustomSelfDrawPanel.CSDLabel housingValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015CF RID: 5583
		private CustomSelfDrawPanel.CSDLabel spareWorkersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040015D0 RID: 5584
		private CustomSelfDrawPanel.CSDLabel spareWorkersValue = new CustomSelfDrawPanel.CSDLabel();
	}
}
