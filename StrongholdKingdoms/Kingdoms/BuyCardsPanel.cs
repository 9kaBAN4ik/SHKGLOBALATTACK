using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x020000EB RID: 235
	public class BuyCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x00090514 File Offset: 0x0008E714
		public BuyCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00090600 File Offset: 0x0008E800
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * BuyCardsPanel.BorderPadding;
			this.AvailablePanelWidth = 800;
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = base.Size;
			csdextendingPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(csdextendingPanel);
			csdextendingPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDImage
			{
				Image = GFXLibrary.cardpanel_panel_gradient_top_left,
				Size = GFXLibrary.cardpanel_panel_gradient_top_left.Size,
				Position = new Point(0, 0)
			});
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.cardpanel_panel_gradient_bottom_right;
			csdimage.Size = GFXLibrary.cardpanel_panel_gradient_bottom_right.Size;
			csdimage.Position = new Point(csdextendingPanel.Width - csdimage.Width - 6, csdextendingPanel.Height - csdimage.Height - 6);
			csdextendingPanel.addControl(csdimage);
			this.AvailablePanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, 375);
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - 550);
			this.AvailablePanel.Alpha = 0.8f;
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			int width = base.Width;
			int borderPadding = BuyCardsPanel.BorderPadding;
			int width2 = this.AvailablePanel.Width;
			this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			this.closeImage.Size = this.closeImage.Image.Size;
			this.closeImage.setMouseOverDelegate(delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Cards_Close");
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 39, new Point(base.Width - 1 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.greyout.FillColor = Color.FromArgb(215, 25, 25, 25);
			this.greyout.Size = new Size(this.mainBackgroundImage.Width, this.AvailablePanel.Y + this.AvailablePanel.Height);
			this.greyout.Position = new Point(0, 0);
			this.greyout.setClickDelegate(delegate()
			{
			});
			CustomSelfDrawPanel.CSDImage closeGrey = new CustomSelfDrawPanel.CSDImage();
			closeGrey.Image = GFXLibrary.cardpanel_button_close_normal;
			closeGrey.Size = this.closeImage.Image.Size;
			closeGrey.setMouseOverDelegate(delegate
			{
				closeGrey.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				closeGrey.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			closeGrey.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.CloseGrey), "BuyCardsPanel_close_overlay");
			closeGrey.Position = new Point(base.Width - 14 - 17, 10);
			this.greyout.addControl(closeGrey);
			CustomSelfDrawPanel.UICardsButtons uicardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			uicardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(uicardsButtons);
			this.cardButtons = uicardsButtons;
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(935, 64);
			this.labelTitle.Text = SK.Text("BuyCardsPanel_Buy_and_Open_Packs", "Buy and Open Card Packs: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			this.labelBottom.Position = new Point(27, this.AvailablePanel.Y + this.AvailablePanel.Height + 4);
			this.labelBottom.Size = new Size(800, 64);
			this.labelBottom.Text = SK.Text("BuyCardsPanel_Click_To_Open", "Click on a pack to open it");
			this.labelBottom.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelBottom.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.labelBottom.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelBottom);
			this.packWidth = 100;
			this.packX = this.AvailablePanel.X + BuyCardsPanel.BorderPadding;
			this.offerX = this.packX + this.packWidth - 16;
			this.GetOffercontrolList();
			this.AddOfferControls();
			this.UpdatePacks();
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x0000BCD4 File Offset: 0x00009ED4
		public void OpenGrey()
		{
			this.mainBackgroundImage.addControl(this.greyout);
			this.cardButtons.Available = false;
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0000BCFE File Offset: 0x00009EFE
		public void CloseGrey()
		{
			this.mainBackgroundImage.removeControl(this.greyout);
			this.cardButtons.Available = true;
			this.mainBackgroundImage.invalidate();
			this.numRevealCards = 0;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00090CAC File Offset: 0x0008EEAC
		public void UpdatePacks()
		{
			if (BuyCardsPanel.packimage == null)
			{
				BuyCardsPanel.packimage = new Bitmap(this.packWidth, 136);
				using (Graphics graphics = Graphics.FromImage(BuyCardsPanel.packimage))
				{
					graphics.FillRectangle(Brushes.Green, 0, 0, BuyCardsPanel.packimage.Width, BuyCardsPanel.packimage.Height);
				}
			}
			foreach (UICardPack control in this.packControls.Values)
			{
				this.mainBackgroundImage.removeControl(control);
			}
			this.packControls.Clear();
			this.AvailablePanelContent.invalidate();
			int num = this.packWidth;
			int num2 = 0;
			foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (!this.packControls.ContainsKey(GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack.OfferID].Category) && userCardPack.Count > 0)
				{
					num2++;
				}
			}
			if (num2 >= 8)
			{
				num = 75;
			}
			foreach (CardTypes.UserCardPack userCardPack2 in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (!this.packControls.ContainsKey(GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack2.OfferID].Category) && userCardPack2.Count > 0)
				{
					UICardPack packControl = new UICardPack();
					packControl.baseImage = new CustomSelfDrawPanel.CSDImage();
					packControl.baseImage.Image = BuyCardsPanel.packimage;
					packControl.baseImage.Size = BuyCardsPanel.packimage.Size;
					string empty = string.Empty;
					string empty2 = string.Empty;
					string id = string.Empty;
					string category = GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack2.OfferID].Category;
					packControl.OfferID = userCardPack2.OfferID;
					int cardPackTooltipID = GameEngine.Instance.cardPackManager.getCardPackTooltipID(category);
					id = GameEngine.Instance.cardPackManager.getCardPackLocalizedStringID(category);
					packControl.nameText = SK.Text(id);
					packControl.baseImage.Image = GameEngine.Instance.cardPackManager.getCardPackBaseImage(category);
					packControl.overImage.Image = GameEngine.Instance.cardPackManager.getCardPackOverImage(category);
					packControl.addControl(packControl.baseImage);
					packControl.addControl(packControl.overImage);
					packControl.baseImage.Visible = true;
					packControl.overImage.Visible = false;
					packControl.CustomTooltipID = cardPackTooltipID;
					packControl.setMouseOverDelegate(delegate
					{
						packControl.baseImage.Visible = false;
						packControl.overImage.Visible = true;
					}, delegate
					{
						packControl.baseImage.Visible = true;
						packControl.overImage.Visible = false;
					});
					packControl.Size = packControl.baseImage.Size;
					if (this.packControls.Count > 0)
					{
						packControl.Position = new Point(this.AvailablePanel.X + (num + 4) * this.packControls.Count, base.Height - 4 - packControl.Height);
					}
					else
					{
						packControl.Position = new Point(this.AvailablePanel.X, base.Height - 4 - packControl.Height);
					}
					packControl.ClickArea = new Rectangle(8, 0, 75, packControl.Height);
					packControl.PackIDs.Add(userCardPack2.OfferID);
					this.packControls.Add(GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack2.OfferID].Category, packControl);
				}
				else if (userCardPack2.Count > 0)
				{
					this.packControls[GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack2.OfferID].Category].PackIDs.Add(userCardPack2.OfferID);
				}
			}
			foreach (UICardPack uicardPack in this.packControls.Values)
			{
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				csdimage.Image = GFXLibrary.cardpanel_pack_open_circle;
				csdimage.Size = csdimage.Image.Size;
				csdimage.Position = new Point(uicardPack.Width - csdimage.Width - 4, uicardPack.Height - csdimage.Height - csdimage.Height / 2);
				uicardPack.addControl(csdimage);
				uicardPack.nameLabel = new CustomSelfDrawPanel.CSDLabel();
				int num3 = 0;
				foreach (CardTypes.UserCardPack userCardPack3 in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
				{
					if (uicardPack.PackIDs.Contains(userCardPack3.OfferID))
					{
						num3 += userCardPack3.Count;
					}
				}
				uicardPack.nameLabel.Text = num3.ToString();
				uicardPack.nameLabel.Position = new Point(csdimage.X - 2 - 50, csdimage.Y - 2);
				uicardPack.nameLabel.Size = new Size(csdimage.Size.Width + 100, csdimage.Size.Height);
				uicardPack.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				uicardPack.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				uicardPack.nameLabel.Color = global::ARGBColors.Black;
				uicardPack.addControl(uicardPack.nameLabel);
				if (uicardPack.PackIDs.Count > 0)
				{
					uicardPack.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.OpenPack));
					this.mainBackgroundImage.addControl(uicardPack);
				}
			}
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0009140C File Offset: 0x0008F60C
		public void GetOffercontrolList()
		{
			if (BuyCardsPanel.offerimage == null)
			{
				BuyCardsPanel.offerimage = new Bitmap(180, 150);
				using (Graphics graphics = Graphics.FromImage(BuyCardsPanel.offerimage))
				{
					graphics.FillRectangle(Brushes.Green, 0, 0, BuyCardsPanel.offerimage.Width, BuyCardsPanel.offerimage.Height);
				}
			}
			this.OfferList = new List<UICardOffer>();
			foreach (CardTypes.CardOffer cardOffer in GameEngine.Instance.cardPackManager.ProfileCardOffers.Values)
			{
				if (cardOffer.Buyable == 1)
				{
					if (cardOffer.Category == "PLATINUM")
					{
						cardOffer.Buyable = 0;
					}
					else
					{
						UICardOffer off = new UICardOffer();
						off.Offer = cardOffer;
						off.baseImage = new CustomSelfDrawPanel.CSDImage();
						off.baseImage.Position = new Point(0, 20);
						off.packImage = new CustomSelfDrawPanel.CSDImage();
						off.packImage.Position = new Point(10, -7);
						off.packOverImage = new CustomSelfDrawPanel.CSDImage();
						off.packOverImage.Position = new Point(10, -7);
						off.crownImage = new CustomSelfDrawPanel.CSDImage();
						off.crownImage.Position = new Point(330, 16);
						string key = string.Empty;
						string key2 = string.Empty;
						string text = string.Empty;
						string defaultText = string.Empty;
						string category = cardOffer.Category;
						if (category != null)
						{
							uint num = PrivateImplementationDetails.ComputeStringHash(category);
							if (num > 1840469762U)
							{
								if (num <= 2384087216U)
								{
									if (num <= 2020401625U)
									{
										if (num != 1999303592U)
										{
											if (num != 2020401625U)
											{
												goto IL_948;
											}
											if (!(category == "CASTLE"))
											{
												goto IL_948;
											}
											key = "card_pack_castle_standard_normal";
											key2 = "card_pack_castle_standard_over";
											text = "CARD_OFFERS_Castle_Pack";
											defaultText = "Castle Pack";
											goto IL_948;
										}
										else
										{
											if (!(category == "SUPERDEFENCE"))
											{
												goto IL_948;
											}
											goto IL_5DC;
										}
									}
									else if (num != 2135598467U)
									{
										if (num != 2291264053U)
										{
											if (num != 2384087216U)
											{
												goto IL_948;
											}
											if (!(category == "ULTIMATEINDUSTRY"))
											{
												goto IL_948;
											}
											key = "card_pack_Industry_gold_normal";
											key2 = "card_pack_Industry_gold_over";
											text = "CARD_OFFERS_Ultimate_Industry_Pack";
											defaultText = "Ultimate Industry Pack";
											goto IL_948;
										}
										else
										{
											if (!(category == "PLATINUM"))
											{
												goto IL_948;
											}
											key = "card_pack_army_gold_normal";
											key2 = "card_pack_army_gold_over";
											text = "CARD_OFFERS_Platinum_Pack";
											defaultText = "Platinum Pack";
											goto IL_948;
										}
									}
									else if (!(category == "DEFENCE"))
									{
										goto IL_948;
									}
								}
								else if (num <= 3336250060U)
								{
									if (num != 2398591754U)
									{
										if (num != 2669819251U)
										{
											if (num != 3336250060U)
											{
												goto IL_948;
											}
											if (!(category == "RESEARCH"))
											{
												goto IL_948;
											}
											key = "card_pack_research_silver_normal";
											key2 = "card_pack_research_silver_over";
											text = "CARD_OFFERS_Industry_Pack";
											defaultText = "Industry Pack";
											goto IL_948;
										}
										else if (!(category == "DEFENSE"))
										{
											goto IL_948;
										}
									}
									else
									{
										if (!(category == "SUPERINDUSTRY"))
										{
											goto IL_948;
										}
										key = "card_pack_Industry_silver_normal";
										key2 = "card_pack_Industry_silver_over";
										text = "CARD_OFFERS_Super_Industry_Pack";
										defaultText = "Super Industry Pack";
										goto IL_948;
									}
								}
								else if (num != 3400942179U)
								{
									if (num != 3529609855U)
									{
										if (num != 3631079739U)
										{
											goto IL_948;
										}
										if (!(category == "SUPERRANDOM"))
										{
											goto IL_948;
										}
										key = "card_pack_random_silver_normal";
										key2 = "card_pack_random_silver_over";
										text = "CARD_OFFERS_Super_Random_Pack";
										defaultText = "Super Random Pack";
										CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
										csdbutton.ImageNorm = GFXLibrary.mrhp_button_more_info_solid[0];
										csdbutton.ImageOver = GFXLibrary.mrhp_button_more_info_solid[1];
										csdbutton.MoveOnClick = true;
										csdbutton.Position = new Point(270, 100);
										csdbutton.Text.Text = SK.Text("UserInfo_MoreInfo", "More Info");
										if (Program.mySettings.LanguageIdent == "it")
										{
											csdbutton.Text.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
										}
										else
										{
											csdbutton.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
										}
										csdbutton.TextYOffset = -3;
										csdbutton.Text.Position = new Point(-3, 0);
										csdbutton.Text.Color = global::ARGBColors.Black;
										csdbutton.Text.DropShadowColor = Color.FromArgb(60, 90, 100);
										csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.moreSuperClicked));
										off.addControl(csdbutton);
										goto IL_948;
									}
									else
									{
										if (!(category == "INDUSTRY"))
										{
											goto IL_948;
										}
										key = "card_pack_Industry_standard_normal";
										key2 = "card_pack_Industry_standard_over";
										text = "CARD_OFFERS_Industry_Pack";
										defaultText = "Industry Pack";
										goto IL_948;
									}
								}
								else
								{
									if (!(category == "ULTIMATEARMY"))
									{
										goto IL_948;
									}
									key = "card_pack_army_gold_normal";
									key2 = "card_pack_army_gold_over";
									text = "CARD_OFFERS_Ultimate_Army_Pack";
									defaultText = "Ultimate Army Pack";
									goto IL_948;
								}
								key = "card_pack_defence_standard_normal";
								key2 = "card_pack_defence_standard_over";
								text = "CARD_OFFERS_Defense_Pack";
								defaultText = "Defence Pack";
								goto IL_948;
							}
							if (num > 1025969697U)
							{
								if (num <= 1465082808U)
								{
									if (num != 1306248978U)
									{
										if (num != 1465082808U)
										{
											goto IL_948;
										}
										if (!(category == "SUPERDEFENSE"))
										{
											goto IL_948;
										}
										goto IL_5DC;
									}
									else if (!(category == "ULTIMATEDEFENSE"))
									{
										goto IL_948;
									}
								}
								else if (num != 1614633826U)
								{
									if (num != 1752986212U)
									{
										if (num != 1840469762U)
										{
											goto IL_948;
										}
										if (!(category == "ULTIMATEDEFENCE"))
										{
											goto IL_948;
										}
									}
									else
									{
										if (!(category == "ARMY"))
										{
											goto IL_948;
										}
										key = "card_pack_army_standard_normal";
										key2 = "card_pack_army_standard_over";
										text = "CARD_OFFERS_Army_Pack";
										defaultText = "Army Pack";
										goto IL_948;
									}
								}
								else
								{
									if (!(category == "RANDOM"))
									{
										goto IL_948;
									}
									key = "card_pack_random_standard_normal";
									key2 = "card_pack_random_standard_over";
									text = "CARD_OFFERS_Random_Pack";
									defaultText = "Random Pack";
									goto IL_948;
								}
								key = "card_pack_defence_gold_normal";
								key2 = "card_pack_defence_gold_over";
								text = "CARD_OFFERS_Ultimate_Defense_Pack";
								defaultText = "Ultimate Defence Pack";
								goto IL_948;
							}
							if (num <= 253004944U)
							{
								if (num != 207630535U)
								{
									if (num != 253004944U)
									{
										goto IL_948;
									}
									if (!(category == "SUPERFARMING"))
									{
										goto IL_948;
									}
									key = "card_pack_food_silver_normal";
									key2 = "card_pack_food_silver_over";
									text = "CARD_OFFERS_Super_Food_Pack";
									defaultText = "Super Food Pack";
									goto IL_948;
								}
								else
								{
									if (!(category == "FARMING"))
									{
										goto IL_948;
									}
									key = "card_pack_food_standard_normal";
									key2 = "card_pack_food_standard_over";
									text = "CARD_OFFERS_Food_Pack";
									defaultText = "Food Pack";
									goto IL_948;
								}
							}
							else if (num != 364403686U)
							{
								if (num != 453818725U)
								{
									if (num != 1025969697U)
									{
										goto IL_948;
									}
									if (!(category == "ULTIMATERANDOM"))
									{
										goto IL_948;
									}
									key = "card_pack_random_gold_normal";
									key2 = "card_pack_random_gold_over";
									text = "CARD_OFFERS_Ultimate_Random_Pack";
									defaultText = "Ultimate Random Pack";
									CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
									csdbutton2.ImageNorm = GFXLibrary.mrhp_button_more_info_solid[0];
									csdbutton2.ImageOver = GFXLibrary.mrhp_button_more_info_solid[1];
									csdbutton2.MoveOnClick = true;
									csdbutton2.Position = new Point(270, 100);
									csdbutton2.Text.Text = SK.Text("UserInfo_MoreInfo", "More Info");
									if (Program.mySettings.LanguageIdent == "it")
									{
										csdbutton2.Text.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
									}
									else
									{
										csdbutton2.Text.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
									}
									csdbutton2.TextYOffset = -3;
									csdbutton2.Text.Position = new Point(-3, 0);
									csdbutton2.Text.Color = global::ARGBColors.Black;
									csdbutton2.Text.DropShadowColor = Color.FromArgb(60, 90, 100);
									csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.moreUltimateClicked));
									off.addControl(csdbutton2);
									goto IL_948;
								}
								else
								{
									if (!(category == "SUPERARMY"))
									{
										goto IL_948;
									}
									key = "card_pack_army_silver_normal";
									key2 = "card_pack_army_silver_over";
									text = "CARD_OFFERS_Super_Army_Pack";
									defaultText = "Super Army Pack";
									goto IL_948;
								}
							}
							else
							{
								if (!(category == "ULTIMATEFARMING"))
								{
									goto IL_948;
								}
								key = "card_pack_food_gold_normal";
								key2 = "card_pack_food_gold_over";
								text = "CARD_OFFERS_Ultimate_Food_Pack";
								defaultText = "Ultimate Food Pack";
								goto IL_948;
							}
							IL_5DC:
							key = "card_pack_defence_silver_normal";
							key2 = "card_pack_defence_silver_over";
							text = "CARD_OFFERS_Super_Defense_Pack";
							defaultText = "Super Defence Pack";
						}
						IL_948:
						off.baseImage.Image = GFXLibrary.card_offer_background;
						if (GFXLibrary.CardPackImages == null)
						{
							UniversalDebugLog.Log("CARDPACK IMAGES IS NULL");
						}
						UniversalDebugLog.Log("Num packimages: " + GFXLibrary.CardPackImages.Count.ToString());
						off.packImage.Image = GFXLibrary.CardPackImages[key];
						off.packOverImage.Image = GFXLibrary.CardPackImages[key2];
						string text2 = SK.Text(text, defaultText);
						off.crownImage.Image = GFXLibrary.card_offer_pieces[2];
						off.packImage.Visible = true;
						off.packOverImage.Visible = false;
						off.baseImage.setMouseOverDelegate(delegate
						{
							off.packImage.Visible = false;
							off.packOverImage.Visible = true;
							off.baseImage.Image = GFXLibrary.card_offer_background_over;
						}, delegate
						{
							off.packImage.Visible = true;
							off.packOverImage.Visible = false;
							off.baseImage.Image = GFXLibrary.card_offer_background;
						});
						off.nameLabel = new CustomSelfDrawPanel.CSDLabel();
						off.nameLabel.Position = new Point(94, 29);
						off.nameLabel.Text = text2;
						off.nameLabel.Size = new Size(300, 30);
						off.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						off.nameLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
						off.nameLabel.Color = global::ARGBColors.Black;
						off.descLabel = new CustomSelfDrawPanel.CSDLabel();
						off.descLabel.Position = new Point(94, 46);
						off.descLabel.Text = SK.Text(text + "_desc");
						off.descLabel.Size = new Size(245, 45);
						off.descLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						off.descLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						off.descLabel.Color = global::ARGBColors.Black;
						off.cardLabel = new CustomSelfDrawPanel.CSDLabel();
						off.cardLabel.Position = new Point(191, 59);
						off.cardLabel.Text = SK.Text("BUY_CARDS_5_per_pack", "5 Cards per Pack");
						off.cardLabel.Size = new Size(200, 30);
						off.cardLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
						off.cardLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						off.cardLabel.Color = global::ARGBColors.Black;
						off.costLabel = new CustomSelfDrawPanel.CSDLabel();
						off.costLabel.Position = new Point(306, 28);
						off.costLabel.Text = cardOffer.CrownCost.ToString();
						off.costLabel.Size = new Size(40, 30);
						off.costLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
						off.costLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
						off.costLabel.Color = global::ARGBColors.Black;
						off.addControl(off.baseImage);
						off.addControl(off.packImage);
						off.addControl(off.packOverImage);
						off.addControl(off.nameLabel);
						off.addControl(off.descLabel);
						off.addControl(off.crownImage);
						off.addControl(off.cardLabel);
						off.addControl(off.costLabel);
						off.baseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.OfferClicked));
						off.Size = new Size(off.baseImage.Size.Width, 140);
						this.OfferList.Add(off);
					}
				}
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0000BD2F File Offset: 0x00009F2F
		public void moreSuperClicked()
		{
			this.showMorePopup(0);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0000BD38 File Offset: 0x00009F38
		public void moreUltimateClicked()
		{
			this.showMorePopup(1);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0000BD41 File Offset: 0x00009F41
		public void showMorePopup(int mode)
		{
			GameEngine.Instance.openSuperPackInfo(mode);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00092260 File Offset: 0x00090460
		public void AddOfferControls()
		{
			this.OfferList.Sort((UICardOffer first, UICardOffer next) => first.Offer.Sequence.CompareTo(next.Offer.Sequence));
			int num = 100;
			int num2 = 0;
			for (int i = 0; i < this.OfferList.Count; i++)
			{
				UICardOffer uicardOffer = this.OfferList[i];
				uicardOffer.Position = new Point((i & 1) * 330, 5 + num * i);
				this.AvailablePanelContent.addControl(uicardOffer);
				num2 = uicardOffer.Position.Y + uicardOffer.Height + 4;
			}
			this.AvailablePanelContent.Position = new Point(BuyCardsPanel.BorderPadding, 0);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, num2);
			this.AvailablePanelContent.ClipRect = new Rectangle(0, 0, this.AvailablePanel.Width - BuyCardsPanel.BorderPadding, this.AvailablePanel.Height);
			this.AvailablePanel.addControl(this.AvailablePanelContent);
			if (num2 < this.AvailablePanelContent.ClipRect.Height)
			{
				num2 = this.AvailablePanelContent.ClipRect.Height;
			}
			this.scrollbarAvailable.Position = new Point(this.AvailablePanel.Width - BuyCardsPanel.BorderPadding - BuyCardsPanel.BorderPadding / 2, this.AvailablePanel.Y + BuyCardsPanel.BorderPadding / 2);
			this.scrollbarAvailable.Size = new Size(BuyCardsPanel.BorderPadding, this.AvailablePanel.Height - BuyCardsPanel.BorderPadding);
			this.mainBackgroundImage.addControl(this.scrollbarAvailable);
			this.scrollbarAvailable.Value = 0;
			this.scrollbarAvailable.StepSize = 200;
			this.scrollbarAvailable.Max = this.AvailablePanelContent.Height - this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.NumVisibleLines = this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.OffsetTL = new Point(1, 5);
			this.scrollbarAvailable.OffsetBR = new Point(0, -10);
			this.scrollbarAvailable.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.AvailableContentScroll));
			this.scrollbarAvailable.Create(null, null, null, GFXLibrary.cardpanel_scroll_thumb_top, GFXLibrary.cardpanel_scroll_thumb_mid, GFXLibrary.cardpanel_scroll_thumb_botom);
			if (num2 <= this.AvailablePanelContent.ClipRect.Height)
			{
				this.scrollbarAvailable.Visible = false;
			}
			CustomSelfDrawPanel.CSDControl csdcontrol = new CustomSelfDrawPanel.CSDControl();
			csdcontrol.Position = new Point(0, 0);
			csdcontrol.Size = base.Size;
			this.mainBackgroundImage.addControl(csdcontrol);
			this.mainBackgroundImage.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelHandler));
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00092548 File Offset: 0x00090748
		private void mouseWheelHandler(int delta)
		{
			if (delta > 0)
			{
				if (this.scrollbarAvailable.Value - delta * 15 > 0)
				{
					this.scrollbarAvailable.Value += delta * -15;
				}
				else
				{
					this.scrollbarAvailable.Value = 0;
				}
				this.AvailableContentScroll();
				return;
			}
			if (delta < 0)
			{
				if (this.scrollbarAvailable.Value - delta * 15 < this.scrollbarAvailable.Max)
				{
					this.scrollbarAvailable.Value += delta * -15;
				}
				else
				{
					this.scrollbarAvailable.Value = this.scrollbarAvailable.Max;
				}
				this.AvailableContentScroll();
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x000925EC File Offset: 0x000907EC
		private void AvailableContentScroll()
		{
			int value = this.scrollbarAvailable.Value;
			this.AvailablePanelContent.Position = new Point(this.AvailablePanelContent.Position.X, -value);
			this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, value, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanelContent.ClipRect.Height);
			this.AvailablePanelContent.invalidate();
			this.AvailablePanel.invalidate();
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0000BD4E File Offset: 0x00009F4E
		public void OfferClicked()
		{
			this.doOfferClicked(true);
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0009268C File Offset: 0x0009088C
		public void doOfferClicked(bool initialClick)
		{
			if (GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			UICardOffer uicardOffer = (UICardOffer)this.ClickedControl.Parent;
			if (initialClick && uicardOffer.Offer.CrownCost > GameEngine.Instance.World.ProfileCrowns)
			{
				BuyCrownsPopup buyCrownsPopup = new BuyCrownsPopup();
				buyCrownsPopup.init(uicardOffer.Offer.CrownCost - GameEngine.Instance.World.ProfileCrowns, base.ParentForm);
				buyCrownsPopup.Show(base.ParentForm);
				return;
			}
			if (initialClick && Program.mySettings.BuyMultipleCardPacks)
			{
				GameEngine.Instance.playInterfaceSound("BuyCardsPanel_open_offer_open_confirmation");
				base.PanelActive = false;
				this.waitingResponse = false;
				InterfaceMgr.Instance.openConfirmBuyOfferPopup(uicardOffer, new ConfirmBuyOfferPanel.CardClickPlayDelegate(this.doOfferClicked));
				return;
			}
			if (initialClick)
			{
				GameEngine.Instance.playInterfaceSound("BuyCardsPanel_open_offer");
				InterfaceMgr.Instance.BuyOfferMultiple = 0;
			}
			if (uicardOffer.Offer.CrownCost > GameEngine.Instance.World.ProfileCrowns)
			{
				BuyCrownsPopup buyCrownsPopup2 = new BuyCrownsPopup();
				buyCrownsPopup2.init(uicardOffer.Offer.CrownCost - GameEngine.Instance.World.ProfileCrowns, base.ParentForm);
				buyCrownsPopup2.Show(base.ParentForm);
				return;
			}
			if (InterfaceMgr.Instance.BuyOfferMultiple == 0)
			{
				InterfaceMgr.Instance.BuyOfferMultiple = 1;
			}
			string id = string.Empty;
			string category = uicardOffer.Offer.Category;
			if (category != null)
			{
				uint num = PrivateImplementationDetails.ComputeStringHash(category);
				if (num > 1840469762U)
				{
					if (num <= 2384087216U)
					{
						if (num <= 2020401625U)
						{
							if (num != 1999303592U)
							{
								if (num != 2020401625U)
								{
									goto IL_533;
								}
								if (!(category == "CASTLE"))
								{
									goto IL_533;
								}
								id = "CARD_OFFERS_Castle_Pack";
								goto IL_533;
							}
							else
							{
								if (!(category == "SUPERDEFENCE"))
								{
									goto IL_533;
								}
								goto IL_4E5;
							}
						}
						else if (num != 2135598467U)
						{
							if (num != 2291264053U)
							{
								if (num != 2384087216U)
								{
									goto IL_533;
								}
								if (!(category == "ULTIMATEINDUSTRY"))
								{
									goto IL_533;
								}
								id = "CARD_OFFERS_Ultimate_Industry_Pack";
								goto IL_533;
							}
							else
							{
								if (!(category == "PLATINUM"))
								{
									goto IL_533;
								}
								id = "CARD_OFFERS_Platinum_Pack";
								goto IL_533;
							}
						}
						else if (!(category == "DEFENCE"))
						{
							goto IL_533;
						}
					}
					else if (num <= 3336250060U)
					{
						if (num != 2398591754U)
						{
							if (num != 2669819251U)
							{
								if (num != 3336250060U)
								{
									goto IL_533;
								}
								if (!(category == "RESEARCH"))
								{
									goto IL_533;
								}
								id = "CARD_OFFERS_Industry_Pack";
								goto IL_533;
							}
							else if (!(category == "DEFENSE"))
							{
								goto IL_533;
							}
						}
						else
						{
							if (!(category == "SUPERINDUSTRY"))
							{
								goto IL_533;
							}
							id = "CARD_OFFERS_Super_Industry_Pack";
							goto IL_533;
						}
					}
					else if (num != 3400942179U)
					{
						if (num != 3529609855U)
						{
							if (num != 3631079739U)
							{
								goto IL_533;
							}
							if (!(category == "SUPERRANDOM"))
							{
								goto IL_533;
							}
							id = "CARD_OFFERS_Super_Random_Pack";
							goto IL_533;
						}
						else
						{
							if (!(category == "INDUSTRY"))
							{
								goto IL_533;
							}
							id = "CARD_OFFERS_Industry_Pack";
							goto IL_533;
						}
					}
					else
					{
						if (!(category == "ULTIMATEARMY"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Ultimate_Army_Pack";
						goto IL_533;
					}
					id = "CARD_OFFERS_Defense_Pack";
					goto IL_533;
				}
				if (num > 1025969697U)
				{
					if (num <= 1465082808U)
					{
						if (num != 1306248978U)
						{
							if (num != 1465082808U)
							{
								goto IL_533;
							}
							if (!(category == "SUPERDEFENSE"))
							{
								goto IL_533;
							}
							goto IL_4E5;
						}
						else if (!(category == "ULTIMATEDEFENSE"))
						{
							goto IL_533;
						}
					}
					else if (num != 1614633826U)
					{
						if (num != 1752986212U)
						{
							if (num != 1840469762U)
							{
								goto IL_533;
							}
							if (!(category == "ULTIMATEDEFENCE"))
							{
								goto IL_533;
							}
						}
						else
						{
							if (!(category == "ARMY"))
							{
								goto IL_533;
							}
							id = "CARD_OFFERS_Army_Pack";
							goto IL_533;
						}
					}
					else
					{
						if (!(category == "RANDOM"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Random_Pack";
						goto IL_533;
					}
					id = "CARD_OFFERS_Ultimate_Defense_Pack";
					goto IL_533;
				}
				if (num <= 253004944U)
				{
					if (num != 207630535U)
					{
						if (num != 253004944U)
						{
							goto IL_533;
						}
						if (!(category == "SUPERFARMING"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Super_Food_Pack";
						goto IL_533;
					}
					else
					{
						if (!(category == "FARMING"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Food_Pack";
						goto IL_533;
					}
				}
				else if (num != 364403686U)
				{
					if (num != 453818725U)
					{
						if (num != 1025969697U)
						{
							goto IL_533;
						}
						if (!(category == "ULTIMATERANDOM"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Ultimate_Random_Pack";
						goto IL_533;
					}
					else
					{
						if (!(category == "SUPERARMY"))
						{
							goto IL_533;
						}
						id = "CARD_OFFERS_Super_Army_Pack";
						goto IL_533;
					}
				}
				else
				{
					if (!(category == "ULTIMATEFARMING"))
					{
						goto IL_533;
					}
					id = "CARD_OFFERS_Ultimate_Food_Pack";
					goto IL_533;
				}
				IL_4E5:
				id = "CARD_OFFERS_Super_Defense_Pack";
			}
			IL_533:
			string text = SK.Text(id);
			DialogResult dialogResult = MyMessageBox.Show(string.Concat(new string[]
			{
				InterfaceMgr.Instance.BuyOfferMultiple.ToString(),
				" x ",
				text,
				Environment.NewLine,
				SK.Text("BuyCardsPanel_Crowns_Cost", "Crowns Cost"),
				" : ",
				(uicardOffer.Offer.CrownCost * InterfaceMgr.Instance.BuyOfferMultiple).ToString()
			}), SK.Text("BuyCardsPanel_Confirm_Purchase", "Confirm Purchase"), MessageBoxButtons.OKCancel);
			if (dialogResult == DialogResult.OK)
			{
				this.lastoffer = uicardOffer;
				GameEngine.Instance.cardPackManager.PurchasePack(uicardOffer.Offer, new CardsEndResponseUIDelegate(this.buyPackCallback), this);
				this.labelTitle.Text = SK.Text("BuyCardsPanel_Buy_and_Open_Packs", "Buy and Open Card Packs: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00092CBC File Offset: 0x00090EBC
		private void BuyPackAfterConfirmation()
		{
			try
			{
				UICardOffer uicardOffer = this.lastoffer;
				GameEngine.Instance.cardPackManager.PurchasePack(uicardOffer.Offer, new CardsEndResponseUIDelegate(this.buyPackCallback), this);
				this.labelTitle.Text = SK.Text("BuyCardsPanel_Buy_and_Open_Packs", "Buy and Open Card Packs: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
				this.confirmBuyCardPopUp.Close();
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("Exception " + ex.ToString());
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00092D60 File Offset: 0x00090F60
		private void buyPackCallback(ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				this.UpdatePacks();
				return;
			}
			this.labelTitle.Text = SK.Text("BuyCardsPanel_Buy_and_Open_Packs", "Buy and Open Card Packs: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			MyMessageBox.Show(response.Message, SK.Text("GENERIC_Error", "Error"));
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0000BD57 File Offset: 0x00009F57
		private void ClosePopUp()
		{
			if (this.confirmBuyCardPopUp != null)
			{
				if (this.confirmBuyCardPopUp.Created)
				{
					this.confirmBuyCardPopUp.Close();
				}
				this.confirmBuyCardPopUp = null;
			}
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0000BD80 File Offset: 0x00009F80
		public void OpenPack()
		{
			this.doOpenPack(true);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00092DE4 File Offset: 0x00090FE4
		public void doOpenPack(bool initialClick)
		{
			if (GameEngine.Instance.World.WorldEnded || GameEngine.Instance.cardPackManager.openingPack)
			{
				return;
			}
			UICardPack uicardPack = (UICardPack)this.ClickedControl;
			if (initialClick && Program.mySettings.OpenMultipleCardPacks)
			{
				GameEngine.Instance.playInterfaceSound("BuyCardsPanel_open_pack_open_confirmation");
				base.PanelActive = false;
				this.waitingResponse = false;
				InterfaceMgr.Instance.openConfirmOpenPackPopup(uicardPack, new ConfirmOpenPackPanel.CardClickPlayDelegate(this.doOpenPack));
				return;
			}
			if (initialClick)
			{
				GameEngine.Instance.playInterfaceSound("BuyCardsPanel_open_pack");
				InterfaceMgr.Instance.OpenPackMultiple = 0;
			}
			if (!GameEngine.Instance.cardPackManager.TryOpenPack(uicardPack.OfferID, new CardsEndResponseUIDelegate(this.PackOpened), this))
			{
				MyMessageBox.Show(SK.Text("BuyCardsPanel_No_More_Available", "You have no more packs of that type available."), SK.Text("GENERIC_Error", "Error"));
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00092ECC File Offset: 0x000910CC
		public void PackOpened(ICardsResponse response)
		{
			if (response.SuccessCode.Value == 1)
			{
				try
				{
					this.CloseGrey();
					for (int i = 0; i < 50; i++)
					{
						if (this.revealCards[i] != null)
						{
							this.revealCards[i].clearControls();
							this.greyout.removeControl(this.revealCards[i]);
						}
					}
					bool flag = false;
					int num = 0;
					List<UICard> list = new List<UICard>();
					string[] array = response.Strings.Split(";".ToCharArray());
					int num2 = array.Length;
					int num3 = -10 * (num2 / 5 - 1);
					string[] array2 = array;
					foreach (string text in array2)
					{
						string[] array4 = text.Split(",".ToCharArray());
						if (array4.Length == 2)
						{
							GameEngine.Instance.cardsManager.ProfileCards.Add(Convert.ToInt32(array4[0].Trim()), CardTypes.getCardDefinitionFromString(array4[1].Trim()));
							UICard uicard = BuyCardsPanel.makeUICard(CardTypes.getCardDefinitionFromString(array4[1].Trim()), Convert.ToInt32(array4[0].Trim()), GameEngine.Instance.World.getRank() + 1);
							uicard.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardClickPlayTrueFromClickFalseValidate));
							list.Add(uicard);
						}
					}
					list.Sort(UICard.cardsNameComparer);
					foreach (UICard uicard2 in list)
					{
						this.revealCards[num] = uicard2;
						this.revealCards[num].Position = new Point(15 + num % 5 * (200 - num2 / 5) + num / 5 * 5, 95 + num3 + 20 * (num / 5));
						this.greyout.addControl(this.revealCards[num]);
						int cardGrade = this.revealCards[num].Definition.cardGrade;
						if (cardGrade <= 1048576)
						{
							if (cardGrade == 524288 || cardGrade == 1048576)
							{
								goto IL_201;
							}
						}
						else if (cardGrade == 2097152 || cardGrade == 4194304)
						{
							goto IL_201;
						}
						IL_203:
						num++;
						continue;
						IL_201:
						flag = true;
						goto IL_203;
					}
					GFXLibrary.Instance.closeBigCardsLoader();
					this.numRevealCards = num;
					if (flag)
					{
						GameEngine.Instance.playInterfaceSound("BuyCardsPanel_found_rare_card");
					}
					this.OpenGrey();
					this.UpdatePacks();
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(ex.Message, SK.Text("GENERIC_Error", "Error"));
				}
				return;
			}
			MyMessageBox.Show(response.Message, SK.Text("BuyCardsPanel_Could_Not_Open_Pack", "Could not open pack."));
			this.UpdatePacks();
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000931A4 File Offset: 0x000913A4
		public void update()
		{
			this.diamondAnimFrame = (int)((DateTime.Now - this.diamondAnimStartTime).TotalMilliseconds / 33.0);
			for (int i = 0; i < this.numRevealCards; i++)
			{
				UICard uicard = this.revealCards[i];
				if (uicard.Definition.cardGrade == 524288)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond_anim.Length];
					uicard.bigGradeImage.invalidateXtra();
				}
				else if (uicard.Definition.cardGrade == 1048576)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond2_anim.Length];
					uicard.bigGradeImage.invalidateXtra();
				}
				else if (uicard.Definition.cardGrade == 2097152)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond3_anim.Length];
					uicard.bigGradeImage.invalidateXtra();
				}
				else if (uicard.Definition.cardGrade == 262144)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_gold_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_gold_anim.Length];
					uicard.bigGradeImage.invalidateXtra();
				}
				else if (uicard.Definition.cardGrade == 4194304)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_sapphire_anim.Length];
					uicard.bigGradeImage.invalidateXtra();
				}
			}
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0009335C File Offset: 0x0009155C
		public static UICard makeUICard(CardTypes.CardDefinition def, int userid, int playerRank)
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
					uicard.addControl(uicard.bigFrameExtraImage);
					goto IL_52B;
				}
				if (grade != 524288)
				{
					goto IL_52B;
				}
			}
			else if (grade != 1048576 && grade != 2097152)
			{
				if (grade != 4194304)
				{
					goto IL_52B;
				}
				uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
				uicard.bigFrameExtraImage.Position = new Point(0, 0);
				uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
				uicard.addControl(uicard.bigFrameExtraImage);
				goto IL_52B;
			}
			uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigFrameExtraImage.Position = new Point(0, 0);
			uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
			uicard.addControl(uicard.bigFrameExtraImage);
			IL_52B:
			uicard.bigGradeImage.Size = uicard.bigGradeImage.Image.Size;
			uicard.addControl(uicard.bigGradeImage);
			uicard.bigTitle = new CustomSelfDrawPanel.CSDLabel();
			uicard.bigTitle.Text = CardTypes.getDescriptionFromCard(uicard.Definition.id);
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
			csdlabel.Position = new Point(2, 2);
			csdlabel.Size = new Size(uicard.Width, uicard.Height);
			csdlabel.Text = "";
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.Yellow;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			uicard.addControl(csdlabel);
			uicard.countLabel = csdlabel;
			Color color = (playerRank >= uicard.Definition.cardRank) ? global::ARGBColors.White : global::ARGBColors.Red;
			CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel2.Position = new Point(150, 220);
			csdlabel2.Size = new Size(20, 13);
			csdlabel2.Text = uicard.Definition.cardRank.ToString();
			csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			csdlabel2.Color = color;
			csdlabel2.DropShadowColor = global::ARGBColors.Black;
			uicard.addControl(csdlabel2);
			uicard.rankLabel = csdlabel2;
			if (playerRank < uicard.Definition.cardRank)
			{
				uicard.Hilight(global::ARGBColors.Gray);
			}
			else
			{
				uicard.Hilight(global::ARGBColors.White);
			}
			uicard.ScaleAll(0.95);
			return uicard;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0000BDB5 File Offset: 0x00009FB5
		private void cardClickPlayTrueFromClickFalseValidate()
		{
			this.doCardClickPlay(true, false);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0000BDBF File Offset: 0x00009FBF
		private void cardClickPlayFalseFromClickTrueValidate()
		{
			this.doCardClickPlay(false, true);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00093C30 File Offset: 0x00091E30
		private void doCardClickPlay(bool fromClick, bool fromValidate)
		{
			if (GameEngine.Instance.World.WorldEnded || this.waitingResponse || (this.ClickedControl.GetType() != typeof(UICard) && fromClick))
			{
				return;
			}
			UICard uicard = this.lastRequestCard = ((!fromClick) ? this.lastRequestCard : ((UICard)this.ClickedControl));
			this.waitingResponse = true;
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			this.selectedVillage = -1;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (!GameEngine.Instance.World.isCapital(selectedMenuVillage))
			{
				this.selectedVillage = selectedMenuVillage;
			}
			int num = GameEngine.Instance.World.getRank() + 1;
			if (this.lastRequestCard.Definition.cardRank > num)
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
					this.lastRequestCard.Definition.cardRank.ToString()
				}), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				this.waitingResponse = false;
				return;
			}
			if ((this.lastRequestCard.Definition.id == 3109 || this.lastRequestCard.Definition.id == 3110 || this.lastRequestCard.Definition.id == 3111 || this.lastRequestCard.Definition.id == 3112) && GameEngine.Instance.Village != null && GameEngine.Instance.Village.countBuildingType(35) == 0)
			{
				MyMessageBox.Show(SK.Text("PlayCard_No_Inn_Available", "An inn must be built at the current village before this card can be played."));
				this.waitingResponse = false;
				return;
			}
			if (fromClick && Program.mySettings.ConfirmPlayCard)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_open_confirmation");
				base.PanelActive = false;
				this.waitingResponse = false;
				InterfaceMgr.Instance.openConfirmPlayCardPopup(uicard.Definition, new ConfirmPlayCardPanel.CardClickPlayDelegate(this.doCardClickPlay));
				return;
			}
			if (!fromValidate && CardTypes.cardNeedsValidation(CardTypes.getCardType(uicard.Definition.id)))
			{
				this.validateCardPossible(CardTypes.getCardType(uicard.Definition.id), this.selectedVillage);
				return;
			}
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.getCardWindow());
			}
			if (fromClick)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card");
			}
			xmlRpcCardsProvider.PlayUserCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), uicard.UserIDList[0].ToString(), this.selectedVillage.ToString(), RemoteServices.Instance.ProfileWorldID.ToString()), new CardsEndResponseDelegate(this.CardPlayed), this);
			try
			{
				GameEngine.Instance.cardsManager.removeProfileCard(uicard.UserIDList[0]);
				uicard.Visible = false;
			}
			catch (Exception ex)
			{
				MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
			}
			this.greyout.invalidate();
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00093FF0 File Offset: 0x000921F0
		private void CardPlayed(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode == null || response.SuccessCode.Value != 1)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_failed");
				MyMessageBox.Show(CardsManager.translateCardError(response.Message, this.lastRequestCard.Definition.id), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				try
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.lastRequestCard.UserID, CardTypes.getStringFromCard(this.lastRequestCard.Definition.id));
					this.lastRequestCard.Visible = true;
					this.greyout.invalidate();
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
				}
				if (InterfaceMgr.Instance.getCardWindow() != null)
				{
					CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.getCardWindow());
				}
			}
			else
			{
				this.greyout.removeControl(this.lastRequestCard);
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_success");
				GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(this.lastRequestCard.UserID);
				GameEngine.Instance.cardsManager.CardPlayed(this.lastRequestCard.Definition.cardCategory, this.lastRequestCard.Definition.id, this.selectedVillage);
				GameEngine.Instance.cardsManager.addRecentCard(this.lastRequestCard.Definition.id);
			}
			this.waitingResponse = false;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0000BDC9 File Offset: 0x00009FC9
		public void validateCardPossible(int cardType, int villageID)
		{
			RemoteServices.Instance.set_PreValidateCardToBePlayed_UserCallBack(new RemoteServices.PreValidateCardToBePlayed_UserCallBack(this.preValidateCardToBePlayedCallBack));
			RemoteServices.Instance.PreValidateCardToBePlayed(cardType, villageID);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x00094198 File Offset: 0x00092398
		private void ContinuePreValidateCardToBePlayed()
		{
			PreValidateCardToBePlayed_ReturnType preValidateCardToBePlayed_ReturnType = this.returnDataRef;
			if (preValidateCardToBePlayed_ReturnType.canPlayFully)
			{
				this.doCardClickPlay(false, true);
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
						SK.Text("RETURNED_CARD_ERROR_15_21", "Number of Catapults gained will be"),
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
					this.doCardClickPlay(false, true);
					return;
				}
			}
			else if (preValidateCardToBePlayed_ReturnType.otherErrorCode != 0)
			{
				if (preValidateCardToBePlayed_ReturnType.otherErrorCode == -2)
				{
					MyMessageBox.Show(CardsManager.translateCardError("", preValidateCardToBePlayed_ReturnType.cardType, 5), SK.Text("GENERIC_Error", "Error"));
					return;
				}
				if (preValidateCardToBePlayed_ReturnType.otherErrorCode == -3)
				{
					GameEngine.Instance.displayedVillageLost(preValidateCardToBePlayed_ReturnType.villageID, true);
					return;
				}
			}
			else
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
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00095144 File Offset: 0x00093344
		public void preValidateCardToBePlayedCallBack(PreValidateCardToBePlayed_ReturnType returnData)
		{
			this.waitingResponse = false;
			if (!returnData.Success)
			{
				return;
			}
			this.returnDataRef = returnData;
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

		// Token: 0x06000728 RID: 1832 RVA: 0x0000BDED File Offset: 0x00009FED
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000BE0C File Offset: 0x0000A00C
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x0400094E RID: 2382
		private CustomSelfDrawPanel.UICardsButtons cardButtons;

		// Token: 0x0400094F RID: 2383
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000950 RID: 2384
		private List<UICardOffer> OfferList;

		// Token: 0x04000951 RID: 2385
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000952 RID: 2386
		private CustomSelfDrawPanel.CSDLabel labelBottom = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000953 RID: 2387
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000954 RID: 2388
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000955 RID: 2389
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000956 RID: 2390
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000957 RID: 2391
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000958 RID: 2392
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000959 RID: 2393
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400095A RID: 2394
		private CustomSelfDrawPanel.CSDFill greyout = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400095B RID: 2395
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400095C RID: 2396
		private Dictionary<string, UICardPack> packControls = new Dictionary<string, UICardPack>();

		// Token: 0x0400095D RID: 2397
		private int currentCardSection = -1;

		// Token: 0x0400095E RID: 2398
		private bool waitingResponse;

		// Token: 0x0400095F RID: 2399
		private UICard lastRequestCard;

		// Token: 0x04000960 RID: 2400
		private int selectedVillage;

		// Token: 0x04000961 RID: 2401
		private static int BorderPadding = 16;

		// Token: 0x04000962 RID: 2402
		private int ContentWidth;

		// Token: 0x04000963 RID: 2403
		private int AvailablePanelWidth;

		// Token: 0x04000964 RID: 2404
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x04000965 RID: 2405
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000966 RID: 2406
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000967 RID: 2407
		private int packWidth;

		// Token: 0x04000968 RID: 2408
		private int packX;

		// Token: 0x04000969 RID: 2409
		private int offerX;

		// Token: 0x0400096A RID: 2410
		private UICardOffer lastoffer;

		// Token: 0x0400096B RID: 2411
		private UICard[] revealCards = new UICard[50];

		// Token: 0x0400096C RID: 2412
		private int numRevealCards;

		// Token: 0x0400096D RID: 2413
		private static Image packimage = null;

		// Token: 0x0400096E RID: 2414
		private static Image offerimage = null;

		// Token: 0x0400096F RID: 2415
		private MyMessageBoxPopUp confirmBuyCardPopUp;

		// Token: 0x04000970 RID: 2416
		private int diamondAnimFrame;

		// Token: 0x04000971 RID: 2417
		private DateTime diamondAnimStartTime = DateTime.Now;

		// Token: 0x04000972 RID: 2418
		private PreValidateCardToBePlayed_ReturnType returnDataRef;

		// Token: 0x04000973 RID: 2419
		private IContainer components;

		// Token: 0x04000974 RID: 2420
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate5;

		// Token: 0x04000975 RID: 2421
		[CompilerGenerated]
		private static Comparison<UICardOffer> _003C_003E9__CachedAnonymousMethodDelegate11;
	}
}
