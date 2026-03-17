using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200010A RID: 266
	public class CardBarGDI : CustomSelfDrawPanel.CSDControl
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x0000CE55 File Offset: 0x0000B055
		public void init(int cardSection)
		{
			this.init(cardSection, 10, true, 14, 0, 0);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x000B1858 File Offset: 0x000AFA58
		public void init(int cardSection, int numVisible, bool extras, int cardsPerRow, int xExtra, int yExtra)
		{
			this.numCardCirclesVisible = numVisible;
			this.showExtras = extras;
			this.clearControls();
			this.currentCardSection = cardSection;
			if (numVisible == 10 && this.showExtras)
			{
				this.Size = new Size(980, 162);
			}
			else
			{
				this.Size = new Size(800, 625);
			}
			if (this.showExtras)
			{
				this.mainText.Color = global::ARGBColors.White;
				this.mainText.DropShadowColor = global::ARGBColors.Black;
				this.mainText.Position = new Point(10, -50);
				this.mainText.Size = new Size(980, 162);
				this.mainText.Text = "";
				this.mainText.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
				this.mainText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.cardTextTimer = 210;
				base.addControl(this.mainText);
			}
			int num = 10;
			int num2 = 5;
			this.cardCircles.Clear();
			for (int i = 0; i < this.numCardCirclesVisible; i++)
			{
				CardBarGDI.CardCircle cardCircle = new CardBarGDI.CardCircle();
				cardCircle.init(this.currentCardSection, extras);
				cardCircle.Position = new Point(num, num2);
				base.addControl(cardCircle);
				this.cardCircles.Add(cardCircle);
				if ((i + 1) % cardsPerRow == 0)
				{
					num = 10;
					num2 += 162 + yExtra;
				}
				else
				{
					num += 53 + xExtra;
				}
			}
			if (this.showExtras)
			{
				this.circleCards.Position = new Point(num, 1);
				this.circleCards.Image = GFXLibrary.card_circles_card;
				this.circleCards.Data = -1;
				this.circleCards.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.circleClicked));
				this.circleCards.CustomTooltipID = 10001;
				base.addControl(this.circleCards);
				this.circleCardsText.Color = global::ARGBColors.White;
				this.circleCardsText.DropShadowColor = global::ARGBColors.Black;
				this.circleCardsText.Position = new Point(0, 25);
				this.circleCardsText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.circleCardsText.Size = new Size(this.circleCards.Width - 1, 38);
				this.circleCardsText.Text = "5";
				this.circleCardsText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.circleCards.addControl(this.circleCardsText);
				num += 53;
				this.suggestedExpand.Image = GFXLibrary.cardbar_expand[0];
				this.suggestedExpand.Position = new Point(53 * this.displayedCards.Count + 16 + this.circleCards.Width, 18);
				this.suggestedExpand.Data = 0;
				this.suggestedExpand.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickExpand));
				this.suggestedExpand.CustomTooltipID = 10002;
				this.suggestedExpand.Visible = true;
				this.suggestedExpand.Enabled = true;
				base.addControl(this.suggestedExpand);
				this.suggestedCollapse.Image = GFXLibrary.cardbar_collapse[0];
				this.suggestedCollapse.Position = new Point(16 + this.circleCards.Width, 18);
				this.suggestedCollapse.Data = 0;
				this.suggestedCollapse.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickCollapse));
				this.suggestedCollapse.CustomTooltipID = 10003;
				this.suggestedCollapse.Visible = false;
				this.suggestedCollapse.Enabled = false;
				base.addControl(this.suggestedCollapse);
				this.suggestedNext.Image = GFXLibrary.cardbar_right[1];
				this.suggestedNext.Position = new Point(57 + this.circleCards.Width + 495, 18);
				this.suggestedNext.Data = 0;
				this.suggestedNext.Visible = false;
				this.suggestedNext.Enabled = false;
				this.suggestedNext.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickGoRight));
				this.suggestedNext.CustomTooltipID = 10004;
				base.addControl(this.suggestedNext);
				this.suggestedPrev.Image = GFXLibrary.cardbar_left[1];
				this.suggestedPrev.Position = new Point(57 + this.circleCards.Width, 18);
				this.suggestedPrev.Data = 0;
				this.suggestedPrev.Visible = false;
				this.suggestedPrev.Enabled = false;
				this.suggestedPrev.Alpha = 0.5f;
				this.suggestedPrev.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickGoLeft));
				this.suggestedPrev.CustomTooltipID = 10005;
				base.addControl(this.suggestedPrev);
			}
			this.refresh();
			if (this.lastAvailableToPlay == 0)
			{
				this.mainText.Text = SK.Text("CardBarGDI_Click_To_Buy", "Click to Buy Cards");
			}
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x000B1D6C File Offset: 0x000AFF6C
		public void refresh()
		{
			this.displayedCards.Clear();
			this.newDisplayedCards.Clear();
			this.suggestedCards.Clear();
			this.suggestedCardsValid = false;
			this.suggestedCardCounts.Clear();
			foreach (UICard control in this.suggestedDisplayedCards)
			{
				base.removeControl(control);
			}
			this.suggestedDisplayedCards.Clear();
			this.suggestedExpand.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickExpand));
			this.lastAvailableToPlay = -1;
			this.update();
			PlayCardsPanel.disableCardsInPlay(this.suggestedDisplayedCards);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void flagAsRendered()
		{
			this.Dirty = false;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x000B1E30 File Offset: 0x000B0030
		private bool equalCards(List<CardBarGDI.DisplayCardInfo> list1, List<CardBarGDI.DisplayCardInfo> list2)
		{
			if (list1.Count != list2.Count)
			{
				return false;
			}
			int count = list1.Count;
			for (int i = 0; i < count; i++)
			{
				if (!list1[i].equals(list2[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x000B1E78 File Offset: 0x000B0078
		public bool update()
		{
			this.newDisplayedCards.Clear();
			CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			int num = userCardData.cards.Length;
			for (int i = 0; i < num; i++)
			{
				int num2 = userCardData.cards[i];
				int cardCategory = CardTypes.getCardCategory(num2);
				if (cardCategory == this.currentCardSection || this.currentCardSection == 0 || (this.currentCardSection == 9 && (cardCategory == 6 || cardCategory == 7)))
				{
					DateTime d = userCardData.cardsExpiry[i];
					TimeSpan timeSpan = d - currentServerTime;
					int cardDuration = CardTypes.getCardDuration(num2);
					int num3 = (int)timeSpan.TotalMinutes;
					if (num3 < 0)
					{
						num3 = 0;
					}
					int num4 = num3 * 64 / (cardDuration * 60);
					if (num4 < 0)
					{
						num4 = 0;
					}
					else if (num4 >= 64)
					{
						num4 = 63;
					}
					if (timeSpan.TotalDays > 100.0)
					{
						num4 = 64;
					}
					CardBarGDI.DisplayCardInfo displayCardInfo = new CardBarGDI.DisplayCardInfo();
					displayCardInfo.card = num2;
					displayCardInfo.currentFrame = num4;
					displayCardInfo.effect = CardTypes.getCardEffectValue(num2);
					displayCardInfo.imageID = this.getCardImage(num2) - 1;
					this.newDisplayedCards.Add(displayCardInfo);
				}
			}
			int num5 = GameEngine.Instance.cardsManager.countPlayableCardsInCardSection(this.currentCardSection);
			bool flag = false;
			if (num5 != this.lastAvailableToPlay)
			{
				flag = true;
			}
			if (!this.equalCards(this.displayedCards, this.newDisplayedCards))
			{
				flag = true;
				this.displayedCards.Clear();
				foreach (CardBarGDI.DisplayCardInfo item in this.newDisplayedCards)
				{
					this.displayedCards.Add(item);
				}
			}
			if (this.showExtras && this.cardTextTimer > 0)
			{
				this.cardTextTimer--;
				if (this.cardTextTimer <= 0)
				{
					this.mainText.Visible = false;
					flag = true;
				}
				else if (this.cardTextTimer < 10)
				{
					this.mainText.Color = Color.FromArgb(this.cardTextTimer * 25, this.cardTextTimer * 25, this.cardTextTimer * 25, this.cardTextTimer * 25);
					this.mainText.DropShadowColor = Color.FromArgb(this.cardTextTimer * 25, 0, 0, 0);
					flag = true;
				}
			}
			if (this.showExtras && !this.suggestedCardsValid)
			{
				CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
				cardDefinition.cardCategory = this.currentCardSection;
				GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "meta", GameEngine.Instance.cardsManager.lastUserCardNameFilter);
				int num6 = GameEngine.Instance.World.getRank() + 1;
				foreach (int num7 in GameEngine.Instance.cardsManager.ProfileCardsSearch)
				{
					if (GameEngine.Instance.cardsManager.ProfileCards[num7].cardRank <= num6 && GameEngine.Instance.cardsManager.ProfileCards[num7].id != 3076)
					{
						int id = GameEngine.Instance.cardsManager.ProfileCards[num7].id;
						if (this.suggestedCardCounts.ContainsKey(id))
						{
							using (List<UICard>.Enumerator enumerator3 = this.suggestedCards.GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									UICard uicard = enumerator3.Current;
									if (uicard.Definition.id == GameEngine.Instance.cardsManager.ProfileCards[num7].id)
									{
										uicard.UserIDList.Add(num7);
										uicard.cardCount++;
										uicard.countLabel.Text = uicard.cardCount.ToString();
									}
								}
								continue;
							}
						}
						this.suggestedCardCounts.Add(GameEngine.Instance.cardsManager.ProfileCards[num7].id, 1);
						UICard item2 = this.makeUICard(GameEngine.Instance.cardsManager.ProfileCards[num7], num7, num6);
						this.suggestedCards.Add(item2);
					}
				}
				CustomSelfDrawPanel.CSDImage csdimage = this.suggestedExpand;
				bool visible = this.suggestedExpand.Enabled = (this.suggestedCards.Count != 0);
				csdimage.Visible = visible;
				this.suggestedCardsValid = true;
			}
			if (this.showExtras && !this.animationComplete)
			{
				this.animationComplete = true;
				if (!this.suggestedExpand.Visible)
				{
					for (int j = 0; j < this.suggestedDisplayedCards.Count; j++)
					{
						if (this.suggestedDisplayedCards[j].Position.X < this.BASE_CARD_POS + 47 * j)
						{
							this.animationComplete = false;
							this.suggestedDisplayedCards[j].X = Math.Min(this.suggestedDisplayedCards[j].Position.X + 70, this.BASE_CARD_POS + 47 * j);
						}
					}
				}
				this.Dirty = true;
				base.invalidate();
			}
			if (this.showExtras && this.animatedCard != null && this.animationCounter < 30)
			{
				int num8 = (this.animationCounter % 10 + 11) * 12;
				this.animatedCard.Hilight(Color.FromArgb(num8, num8, num8));
				this.animationCounter++;
				if (this.animationCounter == 10)
				{
					this.animatedCard.Y -= 2;
				}
				this.Dirty = true;
				base.invalidate();
			}
			else if (this.showExtras && this.animatedCard != null)
			{
				this.animatedCard.Hilight(global::ARGBColors.White);
				this.animatedCard = null;
				this.Dirty = true;
				base.invalidate();
			}
			if (this.showExtras && this.suggestedNext.Data > 0)
			{
				CustomSelfDrawPanel.CSDImage csdimage2 = this.suggestedNext;
				int data = csdimage2.Data;
				csdimage2.Data = data - 1;
				if (this.suggestedNext.Data == 0)
				{
					this.suggestedNext.Image = GFXLibrary.cardbar_right[1];
					this.Dirty = true;
					base.invalidate();
				}
			}
			if (this.showExtras && this.suggestedPrev.Data > 0)
			{
				CustomSelfDrawPanel.CSDImage csdimage3 = this.suggestedPrev;
				int data = csdimage3.Data;
				csdimage3.Data = data - 1;
				if (this.suggestedPrev.Data == 0)
				{
					this.suggestedPrev.Image = GFXLibrary.cardbar_left[1];
					this.Dirty = true;
					base.invalidate();
				}
			}
			if (flag)
			{
				this.Dirty = true;
				this.lastAvailableToPlay = num5;
				int count = this.displayedCards.Count;
				if (count > this.numCardCirclesVisible)
				{
					count = this.numCardCirclesVisible;
				}
				this.circleCardsText.Text = num5.ToString();
				if (this.suggestedDisplayedCards.Count != 0)
				{
					base.invalidate();
					return true;
				}
				for (int k = 0; k < this.numCardCirclesVisible; k++)
				{
					CardBarGDI.CardCircle circle = this.getCircle(k);
					circle.Visible = false;
				}
				for (int l = 0; l < count; l++)
				{
					CardBarGDI.CardCircle circle2 = this.getCircle(l);
					CardBarGDI.DisplayCardInfo displayCardInfo2 = this.displayedCards[l];
					circle2.Image = GFXLibrary.card_circles_timer[displayCardInfo2.currentFrame];
					circle2.Visible = true;
					circle2.FXImage = GFXLibrary.card_circles_icons[displayCardInfo2.imageID];
					circle2.scaleFXImage(displayCardInfo2.imageID == 33);
					int num9 = (int)displayCardInfo2.effect;
					NumberFormatInfo provider = ((double)num9 != displayCardInfo2.effect) ? GameEngine.NFI_D1 : GameEngine.NFI;
					string text = CardTypes.addX(displayCardInfo2.card) ? ("x" + displayCardInfo2.effect.ToString("N", provider)) : (CardTypes.addPlus(displayCardInfo2.card) ? ("+" + displayCardInfo2.effect.ToString("N", provider)) : ((displayCardInfo2.effect == 0.0) ? "" : displayCardInfo2.effect.ToString("N", provider)));
					if (CardTypes.addPercent(displayCardInfo2.card))
					{
						text += "%";
					}
					circle2.Text = text;
					circle2.CustomTooltipID = 10000;
					circle2.CustomTooltipData = displayCardInfo2.card;
				}
				if (this.showExtras)
				{
					this.circleCards.X = 10 + 53 * count;
					this.suggestedExpand.X = 53 * count + 16 + this.circleCards.Width;
					this.mainText.X = this.circleCards.X + 53 + 5;
				}
				base.invalidate();
			}
			return flag;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0000CE6E File Offset: 0x0000B06E
		public void circleClicked()
		{
			GameEngine.Instance.playInterfaceSound("WorldMap_cards_opened_from_map");
			InterfaceMgr.Instance.openPlayCardsWindow(this.currentCardSection);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x000B27E0 File Offset: 0x000B09E0
		public void clickExpand()
		{
			for (int i = 0; i < this.numCardCirclesVisible; i++)
			{
				this.cardCircles[i].Visible = false;
			}
			this.circleCards.Position = new Point(10, 1);
			foreach (UICard uicard in this.suggestedCards)
			{
				if (this.suggestedDisplayedCards.Count < 10)
				{
					this.suggestedDisplayedCards.Add(uicard);
					uicard.Position = new Point(this.BASE_CARD_POS, 1);
					base.addControl(uicard);
				}
			}
			CustomSelfDrawPanel.CSDImage csdimage = this.suggestedExpand;
			bool visible = this.suggestedExpand.Enabled = false;
			csdimage.Visible = visible;
			CustomSelfDrawPanel.CSDImage csdimage2 = this.suggestedNext;
			bool enabled = this.suggestedNext.Visible = (this.suggestedCards.Count > 10);
			csdimage2.Enabled = enabled;
			this.suggestedPrev.Visible = true;
			this.suggestedPrev.Enabled = false;
			this.suggestedPrev.Alpha = 0.5f;
			CustomSelfDrawPanel.CSDImage csdimage3 = this.suggestedCollapse;
			bool enabled2 = this.suggestedCollapse.Visible = true;
			csdimage3.Enabled = enabled2;
			this.animationComplete = false;
			this.Dirty = true;
			base.invalidate();
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000B2950 File Offset: 0x000B0B50
		public void clickCollapse()
		{
			int num = 0;
			while (num < this.displayedCards.Count && num < this.numCardCirclesVisible)
			{
				this.cardCircles[num].Visible = true;
				num++;
			}
			foreach (UICard control in this.suggestedDisplayedCards)
			{
				base.removeControl(control);
			}
			this.suggestedDisplayedCards.Clear();
			CustomSelfDrawPanel.CSDImage csdimage = this.suggestedExpand;
			bool enabled = this.suggestedExpand.Visible = true;
			csdimage.Enabled = enabled;
			CustomSelfDrawPanel.CSDImage csdimage2 = this.suggestedNext;
			bool enabled2 = this.suggestedNext.Visible = false;
			csdimage2.Enabled = enabled2;
			CustomSelfDrawPanel.CSDImage csdimage3 = this.suggestedPrev;
			bool enabled3 = this.suggestedPrev.Visible = false;
			csdimage3.Enabled = enabled3;
			CustomSelfDrawPanel.CSDImage csdimage4 = this.suggestedCollapse;
			bool enabled4 = this.suggestedCollapse.Visible = false;
			csdimage4.Enabled = enabled4;
			this.animationComplete = false;
			this.refresh();
			this.Dirty = true;
			base.invalidate();
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x000B2A8C File Offset: 0x000B0C8C
		public void clickGoRight()
		{
			int num = this.suggestedCards.IndexOf(this.suggestedDisplayedCards[this.suggestedDisplayedCards.Count - 1]) + 1;
			foreach (UICard control in this.suggestedDisplayedCards)
			{
				base.removeControl(control);
			}
			this.suggestedDisplayedCards.Clear();
			int num2 = num;
			while (num2 < this.suggestedCards.Count && this.suggestedDisplayedCards.Count != 10)
			{
				this.suggestedDisplayedCards.Add(this.suggestedCards[num2]);
				this.suggestedCards[num2].Position = new Point(this.BASE_CARD_POS, 1);
				base.addControl(this.suggestedCards[num2]);
				num2++;
			}
			CustomSelfDrawPanel.CSDImage csdimage = this.suggestedNext;
			bool enabled = this.suggestedNext.Visible = (this.suggestedDisplayedCards[this.suggestedDisplayedCards.Count - 1] != this.suggestedCards[this.suggestedCards.Count - 1]);
			csdimage.Enabled = enabled;
			this.suggestedNext.Data = 5;
			this.suggestedNext.Image = GFXLibrary.cardbar_right[2];
			this.animationComplete = false;
			this.suggestedPrev.Enabled = true;
			this.suggestedPrev.Alpha = 1f;
			this.suggestedPrev.CustomTooltipID = 10005;
			this.Dirty = true;
			base.invalidate();
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x000B2C3C File Offset: 0x000B0E3C
		public void clickGoLeft()
		{
			if (this.suggestedDisplayedCards[0] == this.suggestedCards[0])
			{
				return;
			}
			int num = this.suggestedCards.IndexOf(this.suggestedDisplayedCards[0]) - 10;
			foreach (UICard control in this.suggestedDisplayedCards)
			{
				base.removeControl(control);
			}
			this.suggestedDisplayedCards.Clear();
			int num2 = num;
			while (num2 < this.suggestedCards.Count && this.suggestedDisplayedCards.Count != 10)
			{
				this.suggestedDisplayedCards.Add(this.suggestedCards[num2]);
				this.suggestedCards[num2].Position = new Point(this.BASE_CARD_POS, 1);
				base.addControl(this.suggestedCards[num2]);
				num2++;
			}
			CustomSelfDrawPanel.CSDImage csdimage = this.suggestedNext;
			bool enabled = this.suggestedNext.Visible = (this.suggestedDisplayedCards[this.suggestedDisplayedCards.Count - 1] != this.suggestedCards[this.suggestedCards.Count - 1]);
			csdimage.Enabled = enabled;
			this.suggestedPrev.Data = 5;
			this.suggestedPrev.Image = GFXLibrary.cardbar_left[2];
			if (this.suggestedDisplayedCards[0] == this.suggestedCards[0])
			{
				this.suggestedPrev.Enabled = false;
				this.suggestedPrev.Alpha = 0.5f;
			}
			this.animationComplete = false;
			this.Dirty = true;
			base.invalidate();
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x000B2E08 File Offset: 0x000B1008
		private CardBarGDI.CardCircle getCircle(int index)
		{
			if (index < this.cardCircles.Count)
			{
				return this.cardCircles[index];
			}
			if (this.cardCircles.Count == 0)
			{
				CardBarGDI.CardCircle item = new CardBarGDI.CardCircle();
				this.cardCircles.Add(item);
			}
			return this.cardCircles[0];
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x000B2E5C File Offset: 0x000B105C
		private int getCardImage(int card)
		{
			card = CardTypes.getCardType(card);
			if (card <= 1802)
			{
				if (card <= 1039)
				{
					if (card <= 542)
					{
						switch (card)
						{
						case 257:
						case 258:
						case 259:
							return 40;
						case 260:
						case 261:
						case 262:
							break;
						case 263:
							return 57;
						case 264:
						case 267:
						case 268:
							return 94;
						case 265:
						case 269:
						case 270:
							return 35;
						case 266:
						case 271:
						case 272:
							return 58;
						default:
							switch (card)
							{
							case 513:
							case 514:
							case 515:
								return 3;
							case 516:
							case 517:
							case 518:
								return 8;
							case 519:
							case 520:
							case 521:
								return 14;
							case 522:
							case 523:
							case 524:
								return 6;
							case 525:
							case 526:
							case 527:
								return 11;
							case 528:
							case 529:
							case 530:
								return 25;
							case 531:
							case 532:
							case 533:
								return 10;
							case 534:
							case 535:
							case 536:
								return 50;
							case 537:
							case 538:
							case 539:
								return 2;
							case 540:
							case 541:
							case 542:
								return 51;
							}
							break;
						}
					}
					else
					{
						switch (card)
						{
						case 769:
						case 770:
						case 771:
							return 28;
						case 772:
						case 773:
						case 774:
							return 23;
						case 775:
						case 776:
						case 777:
							return 13;
						case 778:
						case 779:
						case 780:
							return 19;
						case 781:
						case 782:
						case 783:
							return 52;
						default:
							switch (card)
							{
							case 1025:
							case 1026:
							case 1027:
								return 5;
							case 1028:
							case 1029:
							case 1030:
								return 18;
							case 1031:
							case 1032:
							case 1033:
								return 24;
							case 1034:
							case 1035:
							case 1036:
								return 4;
							case 1037:
							case 1038:
							case 1039:
								return 7;
							}
							break;
						}
					}
				}
				else if (card <= 1539)
				{
					switch (card)
					{
					case 1281:
					case 1282:
					case 1283:
						return 1;
					case 1284:
					case 1285:
					case 1286:
						return 26;
					case 1287:
					case 1288:
					case 1289:
						return 12;
					case 1290:
					case 1291:
					case 1292:
						return 15;
					case 1293:
					case 1294:
					case 1295:
						return 9;
					case 1296:
					case 1297:
					case 1298:
						return 27;
					case 1299:
					case 1300:
					case 1301:
						return 20;
					case 1302:
					case 1303:
					case 1304:
						return 22;
					case 1305:
					case 1306:
					case 1307:
						return 21;
					default:
						if (card - 1537 <= 2)
						{
							return 34;
						}
						break;
					}
				}
				else
				{
					if (card - 1541 <= 2)
					{
						return 89;
					}
					if (card - 1800 <= 2)
					{
						return 93;
					}
				}
			}
			else if (card <= 2696)
			{
				if (card <= 2313)
				{
					switch (card)
					{
					case 2049:
					case 2050:
					case 2051:
						return 32;
					case 2052:
					case 2053:
					case 2054:
						return 39;
					case 2055:
					case 2056:
					case 2057:
						return 86;
					case 2058:
					case 2059:
					case 2060:
						return 87;
					case 2061:
					case 2062:
					case 2063:
						return 59;
					case 2064:
					case 2065:
					case 2066:
						return 102;
					case 2067:
					case 2068:
					case 2069:
						return 101;
					case 2070:
					case 2071:
					case 2072:
						return 32;
					default:
						switch (card)
						{
						case 2305:
						case 2306:
						case 2307:
							return 33;
						case 2308:
							return 98;
						case 2309:
							return 99;
						case 2310:
							return 100;
						case 2311:
						case 2312:
						case 2313:
							return 36;
						}
						break;
					}
				}
				else
				{
					switch (card)
					{
					case 2561:
					case 2562:
					case 2563:
						return 95;
					case 2564:
					case 2565:
					case 2566:
						return 96;
					case 2567:
					case 2568:
					case 2569:
						return 97;
					default:
						switch (card)
						{
						case 2689:
						case 2690:
							return 53;
						case 2691:
						case 2692:
						case 2693:
							return 33;
						case 2694:
						case 2695:
						case 2696:
							return 95;
						}
						break;
					}
				}
			}
			else if (card <= 2883)
			{
				switch (card)
				{
				case 2817:
					return 37;
				case 2818:
					return 38;
				case 2819:
					return 41;
				case 2820:
					return 56;
				case 2821:
					return 88;
				case 2822:
					return 42;
				case 2823:
				case 2824:
				case 2825:
					return 1;
				case 2826:
					return 103;
				default:
					if (card - 2881 <= 2)
					{
						return 34;
					}
					break;
				}
			}
			else
			{
				if (card - 2887 <= 2)
				{
					return 106;
				}
				switch (card)
				{
				case 2945:
				case 2946:
				case 2947:
					return 43;
				case 2948:
				case 2949:
				case 2950:
					return 44;
				case 2951:
				case 2952:
				case 2953:
					return 45;
				case 2954:
				case 2955:
				case 2956:
					return 46;
				case 2957:
				case 2958:
				case 2959:
					return 47;
				case 2960:
				case 2961:
				case 2962:
					return 48;
				case 2963:
				case 2964:
				case 2965:
					return 49;
				case 2966:
					return 54;
				case 2967:
					return 55;
				case 2968:
					return 92;
				case 2969:
					return 91;
				case 2970:
				case 2971:
				case 2972:
					return 90;
				case 2973:
				case 2974:
				case 2975:
					return 16;
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
				case 3037:
				case 3054:
					break;
				case 3031:
					return 60;
				case 3032:
					return 61;
				case 3033:
					return 62;
				case 3034:
					return 63;
				case 3035:
					return 64;
				case 3036:
					return 65;
				case 3038:
					return 105;
				case 3039:
					return 66;
				case 3040:
					return 67;
				case 3041:
					return 68;
				case 3042:
					return 69;
				case 3043:
					return 70;
				case 3044:
					return 71;
				case 3045:
					return 72;
				case 3046:
					return 73;
				case 3047:
					return 74;
				case 3048:
					return 75;
				case 3049:
					return 76;
				case 3050:
					return 77;
				case 3051:
					return 78;
				case 3052:
					return 79;
				case 3053:
					return 80;
				case 3055:
					return 81;
				case 3056:
					return 82;
				case 3057:
					return 83;
				case 3058:
					return 84;
				case 3059:
					return 85;
				default:
					if (card == 3076)
					{
						return 104;
					}
					break;
				}
			}
			return 29;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x000B3548 File Offset: 0x000B1748
		public void toggleActive(bool value)
		{
			float alpha = 1f;
			if (!value)
			{
				alpha = 0.5f;
				this.suggestedPrevActive = this.suggestedPrev.Enabled;
				this.suggestedPrev.Enabled = false;
				this.suggestedPrev.Alpha = 0.5f;
			}
			else
			{
				this.suggestedPrev.Enabled = this.suggestedPrevActive;
				this.suggestedPrev.Alpha = (this.suggestedPrevActive ? 1f : 0.5f);
			}
			CustomSelfDrawPanel.CSDImage csdimage = this.circleCards;
			CustomSelfDrawPanel.CSDImage csdimage2 = this.suggestedExpand;
			CustomSelfDrawPanel.CSDImage csdimage3 = this.suggestedCollapse;
			float alpha2 = this.suggestedNext.Alpha = alpha;
			float alpha3 = csdimage3.Alpha = alpha2;
			float num = csdimage.Alpha = (csdimage2.Alpha = alpha3);
			foreach (UICard uicard in this.suggestedDisplayedCards)
			{
				uicard.Enabled = value;
				uicard.setAlpha(alpha);
			}
			foreach (CardBarGDI.CardCircle cardCircle in this.cardCircles)
			{
				cardCircle.Enabled = value;
				cardCircle.setAlpha(alpha);
			}
			CustomSelfDrawPanel.CSDImage csdimage4 = this.circleCards;
			CustomSelfDrawPanel.CSDImage csdimage5 = this.suggestedExpand;
			CustomSelfDrawPanel.CSDImage csdimage6 = this.suggestedCollapse;
			this.suggestedNext.Enabled = value;
			csdimage6.Enabled = value;
			csdimage5.Enabled = value;
			csdimage4.Enabled = value;
			base.invalidate();
			this.Dirty = true;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000B3714 File Offset: 0x000B1914
		public UICard makeUICard(CardTypes.CardDefinition def, int userid, int playerRank)
		{
			UICard uicard = new UICard();
			uicard.UserID = userid;
			uicard.UserIDList.Add(userid);
			uicard.Definition = def;
			switch (uicard.Definition.cardColour)
			{
			case 1:
				uicard.bigFrame = GFXLibrary.BlueCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.BlueCardOverlayBigOver;
				break;
			case 2:
				uicard.bigFrame = GFXLibrary.GreenCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.GreenCardOverlayBigOver;
				break;
			case 3:
				uicard.bigFrame = GFXLibrary.PurpleCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.PurpleCardOverlayBigOver;
				break;
			case 4:
				uicard.bigFrame = GFXLibrary.RedCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.RedCardOverlayBigOver;
				break;
			case 5:
				uicard.bigFrame = GFXLibrary.YellowCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.YellowCardOverlayBigOver;
				break;
			}
			uicard.bigImage = GFXLibrary.Instance.getCardImageBig(uicard.Definition.id);
			uicard.Size = uicard.bigFrame.Size;
			uicard.CustomTooltipID = 10101;
			uicard.CustomTooltipData = uicard.Definition.id;
			uicard.bigGradeImage = new CustomSelfDrawPanel.CSDImage();
			int grade = CardTypes.getGrade(uicard.Definition.cardGrade);
			if (grade <= 262144)
			{
				if (grade == 65536)
				{
					uicard.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
					goto IL_384;
				}
				if (grade == 131072)
				{
					uicard.bigGradeImage.Image = GFXLibrary.CardGradeSilver;
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
					goto IL_384;
				}
				if (grade == 262144)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_gold_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, 0);
					goto IL_384;
				}
			}
			else if (grade <= 1048576)
			{
				if (grade == 524288)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -2);
					goto IL_384;
				}
				if (grade == 1048576)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -7);
					goto IL_384;
				}
			}
			else
			{
				if (grade == 2097152)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -10);
					goto IL_384;
				}
				if (grade == 4194304)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -12);
					goto IL_384;
				}
			}
			uicard.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
			uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
			IL_384:
			uicard.bigGradeImage.Alpha = 0f;
			uicard.bigBaseImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigBaseImage.Position = new Point(10, 11);
			uicard.bigBaseImage.Size = uicard.bigImage.Size;
			uicard.bigBaseImage.Image = uicard.bigImage;
			uicard.addControl(uicard.bigBaseImage);
			uicard.bigFrameImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigFrameImage.Position = new Point(0, 0);
			uicard.bigFrameImage.Size = uicard.bigFrame.Size;
			uicard.bigFrameImage.Image = uicard.bigFrame;
			uicard.addControl(uicard.bigFrameImage);
			if (grade <= 524288)
			{
				if (grade == 262144)
				{
					uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
					uicard.bigFrameExtraImage.Position = new Point(0, 0);
					uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_gold;
					uicard.bigFrameExtraImage.Alpha = 0f;
					uicard.addControl(uicard.bigFrameExtraImage);
					goto IL_56E;
				}
				if (grade != 524288)
				{
					goto IL_56E;
				}
			}
			else if (grade != 1048576 && grade != 2097152)
			{
				if (grade != 4194304)
				{
					goto IL_56E;
				}
				uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
				uicard.bigFrameExtraImage.Position = new Point(0, 0);
				uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
				uicard.bigFrameExtraImage.Alpha = 0f;
				uicard.addControl(uicard.bigFrameExtraImage);
				goto IL_56E;
			}
			uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigFrameExtraImage.Position = new Point(0, 0);
			uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
			uicard.bigFrameExtraImage.Alpha = 0f;
			uicard.addControl(uicard.bigFrameExtraImage);
			IL_56E:
			uicard.bigGradeImage.Size = uicard.bigGradeImage.Image.Size;
			uicard.addControl(uicard.bigGradeImage);
			uicard.bigTitle = new CustomSelfDrawPanel.CSDLabel();
			uicard.bigTitle.Text = "";
			uicard.bigTitle.Size = new Size(110, 48);
			uicard.bigTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			if ((uicard.Definition.id == 1801 || uicard.Definition.id == 1542 || uicard.Definition.id == 3137 || uicard.Definition.id == 1290 || uicard.Definition.id == 1541 || uicard.Definition.id == 1543) && Program.mySettings.LanguageIdent == "de")
			{
				uicard.bigTitle.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			else
			{
				uicard.bigTitle.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			}
			uicard.bigTitle.Color = global::ARGBColors.White;
			uicard.bigTitle.DropShadowColor = global::ARGBColors.Black;
			uicard.bigTitle.Position = new Point(38, 12);
			uicard.addControl(uicard.bigTitle);
			uicard.bigEffect = new CustomSelfDrawPanel.CSDLabel();
			uicard.bigEffect.Text = uicard.Definition.EffectText;
			uicard.bigEffect.Size = new Size(150, 64);
			uicard.bigEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			uicard.bigEffect.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			if (Program.mySettings.LanguageIdent == "de" && CardTypes.isGermanSmallDesc(uicard.Definition.id))
			{
				uicard.bigEffect.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			}
			uicard.bigEffect.Color = global::ARGBColors.White;
			uicard.bigEffect.DropShadowColor = global::ARGBColors.Black;
			uicard.bigEffect.Position = new Point(14, 174);
			uicard.addControl(uicard.bigEffect);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, Convert.ToInt32((double)uicard.Height * 0.72));
			csdlabel.Size = new Size(uicard.Width, uicard.Height / 4);
			csdlabel.Text = "1";
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel.Font = FontManager.GetFont("Arial", 36f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			uicard.addControl(csdlabel);
			uicard.countLabel = csdlabel;
			CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel2.Text = "";
			uicard.addControl(csdlabel2);
			uicard.rankLabel = csdlabel2;
			uicard.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clickPlayDelegate));
			uicard.ScaleAll(0.25 * (double)InterfaceMgr.UIScale);
			return uicard;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0000CE90 File Offset: 0x0000B090
		private void clickPlayDelegate()
		{
			this.clickPlay(true, false);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000B3FA8 File Offset: 0x000B21A8
		private void clickPlay(bool fromClick, bool fromValidate)
		{
			if (this.waitingResponse || GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			if (CustomSelfDrawPanel.StaticClickedControl != null && fromClick)
			{
				this.clickedCard = (UICard)CustomSelfDrawPanel.StaticClickedControl;
			}
			if (this.clickedCard != null)
			{
				this.waitingResponse = true;
				XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
				UICard uicard = this.clickedCard;
				this.selectedVillage = -1;
				int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (!GameEngine.Instance.World.isCapital(selectedMenuVillage) || CardTypes.getCardType(uicard.Definition.id) == 3076)
				{
					this.selectedVillage = selectedMenuVillage;
				}
				int num = GameEngine.Instance.World.getRank() + 1;
				if (uicard.Definition.cardRank > num)
				{
					MyMessageBox.Show(string.Concat(new string[]
					{
						SK.Text("BuyCardsPanel_Rank_Too_low", "Your rank is too low to play this card."),
						Environment.NewLine,
						SK.Text("BuyCardsPanel_Current_Rank", "Current Rank"),
						" : ",
						num.ToString(),
						Environment.NewLine,
						SK.Text("BuyCardsPanel_Required_Rank", "Required Rank"),
						" : ",
						uicard.Definition.cardRank.ToString()
					}), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
					this.waitingResponse = false;
					return;
				}
				if ((uicard.Definition.id == 3109 || uicard.Definition.id == 3110 || uicard.Definition.id == 3111 || uicard.Definition.id == 3112) && GameEngine.Instance.Village != null && GameEngine.Instance.Village.countBuildingType(35) == 0)
				{
					MyMessageBox.Show(SK.Text("PlayCard_No_Inn_Available", "An inn must be built at the current village before this card can be played."));
					this.waitingResponse = false;
					return;
				}
				if (fromClick && Program.mySettings.ConfirmPlayCard)
				{
					GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_open_confirmation");
					this.waitingResponse = false;
					InterfaceMgr.Instance.openConfirmPlayCardPopup(uicard.Definition, new ConfirmPlayCardPanel.CardClickPlayDelegate(this.clickPlay));
					return;
				}
				if (!fromValidate && CardTypes.cardNeedsValidation(CardTypes.getCardType(uicard.Definition.id)))
				{
					this.validateCardPossible(CardTypes.getCardType(uicard.Definition.id), this.selectedVillage);
					return;
				}
				try
				{
					if (fromClick)
					{
						GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card");
					}
					this.animationCounter = 0;
					this.animatedCard = this.clickedCard;
					this.animatedCard.Y += 2;
					xmlRpcCardsProvider.PlayUserCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), uicard.UserIDList[0].ToString(), this.selectedVillage.ToString(), RemoteServices.Instance.ProfileWorldID.ToString()), new CardsEndResponseDelegate(this.cardPlayed), InterfaceMgr.Instance.getDXBasePanel());
					GameEngine.Instance.cardsManager.removeProfileCard(uicard.UserIDList[0]);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0000CE9A File Offset: 0x0000B09A
		public void validateCardPossible(int cardType, int villageID)
		{
			RemoteServices.Instance.set_PreValidateCardToBePlayed_UserCallBack(new RemoteServices.PreValidateCardToBePlayed_UserCallBack(this.preValidateCardToBePlayedCallBack));
			RemoteServices.Instance.PreValidateCardToBePlayed(cardType, villageID);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0000CEBE File Offset: 0x0000B0BE
		public void cardClickPlayFalseFromClickTrueValidate()
		{
			this.clickPlay(false, true);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000B432C File Offset: 0x000B252C
		private void ContinuePreValidateCardToBePlayed()
		{
			PreValidateCardToBePlayed_ReturnType preValidateCardToBePlayed_ReturnType = this.returnDataRef;
			if (preValidateCardToBePlayed_ReturnType.canPlayFully)
			{
				this.clickPlay(false, true);
				return;
			}
			if (preValidateCardToBePlayed_ReturnType.canPlayPartially)
			{
				string str = "";
				switch (preValidateCardToBePlayed_ReturnType.cardType)
				{
				case 3085:
				case 3086:
				case 3087:
				case 3088:
				case 3089:
				case 3090:
				case 3091:
				case 3092:
				case 3093:
				case 3094:
				case 3095:
				case 3096:
				case 3097:
				case 3098:
				case 3099:
				case 3100:
				case 3101:
				case 3102:
				case 3103:
				case 3104:
				case 3105:
				case 3106:
				case 3107:
				case 3108:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_5", "Amount of Food gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3109:
				case 3110:
				case 3111:
				case 3112:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_6", "Amount of Ale gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3113:
				case 3114:
				case 3115:
				case 3116:
				case 3117:
				case 3118:
				case 3119:
				case 3120:
				case 3121:
				case 3122:
				case 3123:
				case 3124:
				case 3125:
				case 3126:
				case 3127:
				case 3128:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_7", "Amount of Resources gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3129:
				case 3130:
				case 3131:
				case 3132:
				case 3133:
				case 3134:
				case 3135:
				case 3136:
				case 3137:
				case 3138:
				case 3139:
				case 3140:
				case 3141:
				case 3142:
				case 3143:
				case 3144:
				case 3145:
				case 3146:
				case 3147:
				case 3148:
				case 3149:
				case 3150:
				case 3151:
				case 3152:
				case 3153:
				case 3154:
				case 3155:
				case 3156:
				case 3157:
				case 3158:
				case 3159:
				case 3160:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_8", "Amount of Honour Goods gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3161:
				case 3162:
				case 3163:
				case 3164:
				case 3165:
				case 3166:
				case 3167:
				case 3168:
				case 3173:
				case 3174:
				case 3175:
				case 3176:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_9", "Number of Weapons gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3169:
				case 3170:
				case 3171:
				case 3172:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_10", "Amount of Armour gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3177:
				case 3178:
				case 3179:
				case 3180:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_11", "Number of Catapults gained will be"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3264:
				case 3265:
				case 3266:
				case 3267:
				case 3268:
				case 3269:
				case 3270:
				case 3271:
				case 3272:
				case 3273:
				case 3274:
				case 3275:
				case 3276:
				case 3277:
				case 3278:
				case 3279:
				case 3280:
				case 3281:
				case 3282:
				case 3283:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_1", "Number of Troops that can be recruited"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3287:
				case 3288:
				case 3289:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_2", "Number of Scouts that can be recruited"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3290:
				case 3291:
				case 3292:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_3", "Number of Monks that can be recruited"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				case 3293:
				case 3294:
				case 3295:
					str = string.Concat(new string[]
					{
						SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
						Environment.NewLine,
						Environment.NewLine,
						CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
						Environment.NewLine,
						Environment.NewLine,
						SK.Text("RETURNED_CARD_ERROR_15_4", "Number of Merchants that can be recruited"),
						" : ",
						preValidateCardToBePlayed_ReturnType.numCanPlay.ToString()
					});
					break;
				}
				DialogResult dialogResult = MyMessageBox.Show(str + Environment.NewLine + Environment.NewLine + SK.Text("PlayCard_Still_Play", "Do you still wish to Play this Card?"), SK.Text("PlayCards_Confirm_play", "Confirm Play Card"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.clickPlay(false, true);
					return;
				}
				this.clickedCard.Hilight(global::ARGBColors.White);
				return;
			}
			else
			{
				this.clickedCard.Hilight(global::ARGBColors.White);
				if (preValidateCardToBePlayed_ReturnType.otherErrorCode == 0)
				{
					switch (preValidateCardToBePlayed_ReturnType.cardType)
					{
					case 3085:
					case 3086:
					case 3087:
					case 3088:
					case 3089:
					case 3090:
					case 3091:
					case 3092:
					case 3093:
					case 3094:
					case 3095:
					case 3096:
					case 3097:
					case 3098:
					case 3099:
					case 3100:
					case 3101:
					case 3102:
					case 3103:
					case 3104:
					case 3105:
					case 3106:
					case 3107:
					case 3108:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_101", "Not enough space in the Granary.")
						}), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3109:
					case 3110:
					case 3111:
					case 3112:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_102", "Not enough space in the Inn.")
						}), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3113:
					case 3114:
					case 3115:
					case 3116:
					case 3117:
					case 3118:
					case 3119:
					case 3120:
					case 3121:
					case 3122:
					case 3123:
					case 3124:
					case 3125:
					case 3126:
					case 3127:
					case 3128:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_103", "Not enough space on the Stockpile.")
						}), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3129:
					case 3130:
					case 3131:
					case 3132:
					case 3133:
					case 3134:
					case 3135:
					case 3136:
					case 3137:
					case 3138:
					case 3139:
					case 3140:
					case 3141:
					case 3142:
					case 3143:
					case 3144:
					case 3145:
					case 3146:
					case 3147:
					case 3148:
					case 3149:
					case 3150:
					case 3151:
					case 3152:
					case 3153:
					case 3154:
					case 3155:
					case 3156:
					case 3157:
					case 3158:
					case 3159:
					case 3160:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_104", "Not enough space in the Village Hall.")
						}), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3161:
					case 3162:
					case 3163:
					case 3164:
					case 3165:
					case 3166:
					case 3167:
					case 3168:
					case 3169:
					case 3170:
					case 3171:
					case 3172:
					case 3173:
					case 3174:
					case 3175:
					case 3176:
					case 3177:
					case 3178:
					case 3179:
					case 3180:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(preValidateCardToBePlayed_ReturnType.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_105", "Not enough space in the Armoury.")
						}), SK.Text("GENERIC_Error", "Error"));
						break;
					case 3181:
					case 3182:
					case 3183:
					case 3184:
					case 3185:
					case 3186:
					case 3187:
					case 3188:
					case 3189:
					case 3190:
					case 3191:
					case 3192:
					case 3193:
					case 3194:
					case 3195:
					case 3196:
					case 3197:
					case 3198:
					case 3199:
					case 3200:
					case 3201:
					case 3202:
					case 3203:
					case 3204:
					case 3205:
					case 3206:
					case 3207:
					case 3208:
					case 3209:
					case 3210:
					case 3211:
					case 3212:
					case 3213:
					case 3214:
					case 3215:
					case 3216:
					case 3217:
					case 3218:
					case 3219:
					case 3220:
					case 3221:
					case 3222:
					case 3223:
					case 3224:
					case 3225:
					case 3226:
					case 3227:
					case 3228:
					case 3229:
					case 3230:
					case 3231:
					case 3232:
					case 3233:
					case 3234:
					case 3235:
					case 3236:
					case 3237:
					case 3238:
					case 3239:
					case 3240:
					case 3241:
					case 3242:
					case 3243:
					case 3244:
					case 3245:
					case 3246:
					case 3247:
					case 3248:
					case 3249:
					case 3250:
					case 3251:
					case 3252:
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
					case 3284:
					case 3285:
					case 3286:
						break;
					case 3264:
					case 3265:
					case 3266:
					case 3267:
					case 3268:
					case 3269:
					case 3270:
					case 3271:
					case 3272:
					case 3273:
					case 3274:
					case 3275:
					case 3276:
					case 3277:
					case 3278:
					case 3279:
					case 3280:
					case 3281:
					case 3282:
					case 3283:
						MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 1), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3287:
					case 3288:
					case 3289:
						MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 2), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3290:
					case 3291:
					case 3292:
						MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 3), SK.Text("GENERIC_Error", "Error"));
						return;
					case 3293:
					case 3294:
					case 3295:
						MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 4), SK.Text("GENERIC_Error", "Error"));
						return;
					default:
						return;
					}
					return;
				}
				if (preValidateCardToBePlayed_ReturnType.otherErrorCode == -2)
				{
					MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 5), SK.Text("GENERIC_Error", "Error"));
					return;
				}
				if (preValidateCardToBePlayed_ReturnType.otherErrorCode == -3)
				{
					GameEngine.Instance.displayedVillageLost(preValidateCardToBePlayed_ReturnType.villageID, true);
				}
				return;
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000B52F0 File Offset: 0x000B34F0
		public void preValidateCardToBePlayedCallBack(PreValidateCardToBePlayed_ReturnType returnData)
		{
			this.waitingResponse = false;
			this.returnDataRef = returnData;
			if (!returnData.Success)
			{
				return;
			}
			if (CardTypes.isMercenaryTroopCardType(returnData.cardType) && returnData.otherErrorCode == 9999)
			{
				string str = SK.Text("RETURNED_CARD_ERROR_UNIT_SPACE", "There is not enough unit space to accomodate these troops. If troops are dispatched from this village some may be lost upon their return.");
				DialogResult dialogResult = MyMessageBox.Show(str + Environment.NewLine + Environment.NewLine + SK.Text("PlayCard_Still_Play", "Do you still wish to Play this Card?"), SK.Text("PlayCards_Confirm_play", "Confirm Play Card"), MessageBoxButtons.YesNo);
				if (dialogResult != DialogResult.No && dialogResult == DialogResult.Yes)
				{
					this.ContinuePreValidateCardToBePlayed();
					return;
				}
			}
			else
			{
				this.ContinuePreValidateCardToBePlayed();
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000B5388 File Offset: 0x000B3588
		private void cardPlayed(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode == null || response.SuccessCode.Value != 1)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_failed");
				MyMessageBox.Show(CardsManager.translateCardError(response.Message, this.clickedCard.Definition.id), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				try
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.clickedCard.UserIDList[0], CardTypes.getStringFromCard(this.clickedCard.Definition.id));
					goto IL_269;
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
					goto IL_269;
				}
			}
			GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_success");
			GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(this.clickedCard.UserIDList[0]);
			GameEngine.Instance.cardsManager.addRecentCard(this.clickedCard.Definition.id);
			if (this.clickedCard.UserIDList.Count > 0)
			{
				this.clickedCard.UserID = this.clickedCard.UserIDList[0];
			}
			GameEngine.Instance.cardsManager.CardPlayed(this.clickedCard.Definition.cardCategory, this.clickedCard.Definition.id, this.selectedVillage);
			if (this.clickedCard.cardCount > 1)
			{
				this.clickedCard.UserIDList.Remove(this.clickedCard.UserID);
				this.clickedCard.UserID = this.clickedCard.UserIDList[0];
				this.clickedCard.cardCount--;
				this.clickedCard.countLabel.Text = this.clickedCard.cardCount.ToString();
			}
			else
			{
				this.clickedCard.setClickDelegate(null);
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				csdimage.Position = new Point(0, 0);
				csdimage.Size = this.clickedCard.bigImage.Size;
				csdimage.Image = GFXLibrary.CardBackBig;
				csdimage.setScale(0.25);
				this.clickedCard.CustomTooltipID = 0;
				this.clickedCard.CustomTooltipData = -1;
				this.clickedCard.addControl(csdimage);
			}
			IL_269:
			this.Dirty = true;
			base.invalidate();
			this.clickedCard = null;
			this.waitingResponse = false;
		}

		// Token: 0x04000C04 RID: 3076
		private const int BASE_CIRCLE_XPOS = 10;

		// Token: 0x04000C05 RID: 3077
		private const int BASE_CIRCLE_STRIDE = 53;

		// Token: 0x04000C06 RID: 3078
		private const int BASE_HEIGHT = 162;

		// Token: 0x04000C07 RID: 3079
		private CustomSelfDrawPanel.CSDLabel mainText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C08 RID: 3080
		private List<CardBarGDI.CardCircle> cardCircles = new List<CardBarGDI.CardCircle>();

		// Token: 0x04000C09 RID: 3081
		private CustomSelfDrawPanel.CSDImage circleCards = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C0A RID: 3082
		private CustomSelfDrawPanel.CSDLabel circleCardsText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000C0B RID: 3083
		private CustomSelfDrawPanel.CSDImage suggestedExpand = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C0C RID: 3084
		private CustomSelfDrawPanel.CSDImage suggestedCollapse = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C0D RID: 3085
		private CustomSelfDrawPanel.CSDImage suggestedNext = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C0E RID: 3086
		private CustomSelfDrawPanel.CSDImage suggestedPrev = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000C0F RID: 3087
		private int cardTextTimer;

		// Token: 0x04000C10 RID: 3088
		private int numCardCirclesVisible = 10;

		// Token: 0x04000C11 RID: 3089
		private bool showExtras;

		// Token: 0x04000C12 RID: 3090
		private int lastAvailableToPlay = -1;

		// Token: 0x04000C13 RID: 3091
		public int currentCardSection = -1;

		// Token: 0x04000C14 RID: 3092
		public bool Dirty;

		// Token: 0x04000C15 RID: 3093
		private List<CardBarGDI.DisplayCardInfo> displayedCards = new List<CardBarGDI.DisplayCardInfo>();

		// Token: 0x04000C16 RID: 3094
		private List<CardBarGDI.DisplayCardInfo> newDisplayedCards = new List<CardBarGDI.DisplayCardInfo>();

		// Token: 0x04000C17 RID: 3095
		private List<UICard> suggestedCards = new List<UICard>();

		// Token: 0x04000C18 RID: 3096
		private List<UICard> suggestedDisplayedCards = new List<UICard>();

		// Token: 0x04000C19 RID: 3097
		private Dictionary<int, int> suggestedCardCounts = new Dictionary<int, int>();

		// Token: 0x04000C1A RID: 3098
		private bool animationComplete = true;

		// Token: 0x04000C1B RID: 3099
		private bool suggestedCardsValid;

		// Token: 0x04000C1C RID: 3100
		private int BASE_CARD_POS = 140;

		// Token: 0x04000C1D RID: 3101
		private bool suggestedPrevActive;

		// Token: 0x04000C1E RID: 3102
		private UICard clickedCard;

		// Token: 0x04000C1F RID: 3103
		private UICard animatedCard;

		// Token: 0x04000C20 RID: 3104
		private int animationCounter = 10;

		// Token: 0x04000C21 RID: 3105
		private PreValidateCardToBePlayed_ReturnType returnDataRef;

		// Token: 0x04000C22 RID: 3106
		private bool waitingResponse;

		// Token: 0x04000C23 RID: 3107
		private int selectedVillage = -1;

		// Token: 0x0200010B RID: 267
		private class DisplayCardInfo
		{
			// Token: 0x06000884 RID: 2180 RVA: 0x0000CEC8 File Offset: 0x0000B0C8
			public bool equals(CardBarGDI.DisplayCardInfo dci)
			{
				return dci.card == this.card && dci.currentFrame == this.currentFrame && dci.imageID == this.imageID && dci.effect == this.effect;
			}

			// Token: 0x04000C24 RID: 3108
			public int card;

			// Token: 0x04000C25 RID: 3109
			public int currentFrame = -1;

			// Token: 0x04000C26 RID: 3110
			public int imageID = -1;

			// Token: 0x04000C27 RID: 3111
			public double effect;
		}

		// Token: 0x0200010C RID: 268
		public class CardCircle : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x1700005B RID: 91
			// (set) Token: 0x06000886 RID: 2182 RVA: 0x0000CF1B File Offset: 0x0000B11B
			public BaseImage Image
			{
				set
				{
					this.circle1.Image = value;
				}
			}

			// Token: 0x1700005C RID: 92
			// (set) Token: 0x06000887 RID: 2183 RVA: 0x0000CF2E File Offset: 0x0000B12E
			public BaseImage FXImage
			{
				set
				{
					this.circle1SubImage.Image = value;
				}
			}

			// Token: 0x1700005D RID: 93
			// (set) Token: 0x06000888 RID: 2184 RVA: 0x0000CF41 File Offset: 0x0000B141
			public string Text
			{
				set
				{
					this.circle1Text.Text = value;
				}
			}

			// Token: 0x06000889 RID: 2185 RVA: 0x000B5708 File Offset: 0x000B3908
			public void init(int cardSection, bool extras)
			{
				this.m_cardSection = cardSection;
				this.circle1.Position = new Point(0, 0);
				this.circle1.Image = GFXLibrary.card_circles_timer[0];
				this.circle1.Data = 10;
				if (extras)
				{
					this.circle1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.circleClicked));
				}
				else
				{
					this.circle1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.circleClickedCancel));
				}
				base.addControl(this.circle1);
				this.circle1SubImage.Position = new Point(-6, 0);
				this.circle1SubImage.Image = GFXLibrary.popularityFace;
				this.circle1.addControl(this.circle1SubImage);
				this.circle1Text.Color = global::ARGBColors.White;
				this.circle1Text.DropShadowColor = global::ARGBColors.Black;
				this.circle1Text.Position = new Point(0, 20);
				this.circle1Text.Size = new Size(this.circle1.Width - 5, 31);
				this.circle1Text.Text = "??";
				this.circle1Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.circle1Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.circle1.addControl(this.circle1Text);
				this.Size = this.circle1.Size;
			}

			// Token: 0x0600088A RID: 2186 RVA: 0x000B5878 File Offset: 0x000B3A78
			public void scaleFXImage(bool state)
			{
				if (!state)
				{
					this.circle1SubImage.Scale = 1.0;
					this.circle1SubImage.Position = new Point(-6, 0);
					return;
				}
				this.circle1SubImage.Scale = 0.75;
				this.circle1SubImage.Position = new Point(4, 10);
			}

			// Token: 0x0600088B RID: 2187 RVA: 0x0000CF4F File Offset: 0x0000B14F
			public void setAlpha(float value)
			{
				this.circle1.Alpha = value;
				this.circle1SubImage.Alpha = value;
			}

			// Token: 0x0600088C RID: 2188 RVA: 0x0000CF69 File Offset: 0x0000B169
			public void circleClicked()
			{
				GameEngine.Instance.playInterfaceSound("WorldMap_cards_opened_from_map");
				InterfaceMgr.Instance.openPlayCardsWindow(this.m_cardSection);
			}

			// Token: 0x0600088D RID: 2189 RVA: 0x000B58D8 File Offset: 0x000B3AD8
			public void circleClickedCancel()
			{
				int customTooltipData = base.CustomTooltipData;
				GameEngine.Instance.playInterfaceSound("WorldMap_cards_opened_from_map");
				DialogResult dialogResult = MyMessageBox.Show(string.Concat(new string[]
				{
					CardTypes.getDescriptionFromCard(customTooltipData),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("ViewCards_Cancel_Card_1", "Are you sure you wish to cancel this card?"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("ViewCards_Cancel_Card_2", "If you cancel this card, the effect of the card will end and you will lose the card."),
					Environment.NewLine,
					Environment.NewLine
				}), SK.Text("ViewCards_Cancel_Card", "Cancel Card in Play"), MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, 0);
				if (dialogResult == DialogResult.Yes)
				{
					this.cancelCardSharedFunction(customTooltipData);
				}
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x0000CF8B File Offset: 0x0000B18B
			private void CancelCardClicked()
			{
				this.cancelCardSharedFunction(base.CustomTooltipData);
				this.cancelCardPopUp.Close();
			}

			// Token: 0x0600088F RID: 2191 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
			private void ClosePopUp()
			{
				if (this.cancelCardPopUp != null)
				{
					if (this.cancelCardPopUp.Created)
					{
						this.cancelCardPopUp.Close();
					}
					this.cancelCardPopUp = null;
				}
			}

			// Token: 0x06000890 RID: 2192 RVA: 0x0000CFCD File Offset: 0x0000B1CD
			private void cancelCardSharedFunction(int cardType)
			{
				if (!GameEngine.Instance.World.WorldEnded)
				{
					RemoteServices.Instance.set_CancelCard_UserCallBack(new RemoteServices.CancelCard_UserCallBack(this.cancelCardCallback));
					RemoteServices.Instance.CancelCard(cardType);
				}
			}

			// Token: 0x06000891 RID: 2193 RVA: 0x0000D001 File Offset: 0x0000B201
			private void cancelCardCallback(CancelCard_ReturnType returnData)
			{
				if (returnData.Success && returnData.m_cardData != null)
				{
					GameEngine.Instance.cardsManager.UserCardData = returnData.m_cardData;
				}
			}

			// Token: 0x04000C28 RID: 3112
			private CustomSelfDrawPanel.CSDImage circle1 = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000C29 RID: 3113
			private CustomSelfDrawPanel.CSDImage circle1SubImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000C2A RID: 3114
			private CustomSelfDrawPanel.CSDLabel circle1Text = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000C2B RID: 3115
			private int m_cardSection;

			// Token: 0x04000C2C RID: 3116
			private MyMessageBoxPopUp cancelCardPopUp;
		}
	}
}
