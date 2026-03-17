using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using StatTracking;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000276 RID: 630
	public class PlayCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x06001C14 RID: 7188 RVA: 0x0001BB56 File Offset: 0x00019D56
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x0001BB75 File Offset: 0x00019D75
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x001B4A34 File Offset: 0x001B2C34
		public PlayCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x001B4BB8 File Offset: 0x001B2DB8
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * PlayCardsPanel.BorderPadding;
			this.AvailablePanelWidth = 800;
			this.InplayPanelWidth = this.ContentWidth - PlayCardsPanel.BorderPadding - this.AvailablePanelWidth;
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
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, 550);
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - 550);
			this.AvailablePanel.Alpha = 0.8f;
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			this.sortBack.Image = GFXLibrary.sort_back;
			this.sortBack.Position = new Point(12, this.AvailablePanel.Height - 37);
			this.sortBack.Visible = true;
			this.AvailablePanel.addControl(this.sortBack);
			this.sortByName.ImageNorm = GFXLibrary.sort_normal;
			this.sortByName.ImageOver = GFXLibrary.sort_over;
			this.sortByName.ImageClick = GFXLibrary.sort_in;
			this.sortByName.Position = new Point(7, 4);
			this.sortByName.Text.Text = SK.Text("Card_Sorting_Name", "Sort By Name");
			this.sortByName.Text.Color = global::ARGBColors.White;
			this.sortByName.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sortByName.TextYOffset = -1;
			this.sortByName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByNameClicked), "PlayCardsPanel_sort_by_name");
			this.sortBack.addControl(this.sortByName);
			this.sortByType.ImageNorm = GFXLibrary.sort_normal;
			this.sortByType.ImageOver = GFXLibrary.sort_over;
			this.sortByType.ImageClick = GFXLibrary.sort_in;
			this.sortByType.Position = new Point(228, 4);
			this.sortByType.Text.Text = SK.Text("Card_Sorting_Type", "Sort By Type");
			this.sortByType.Text.Color = global::ARGBColors.White;
			this.sortByType.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sortByType.TextYOffset = -1;
			this.sortByType.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByTypeClicked), "PlayCardsPanel_sort_by_type");
			this.sortBack.addControl(this.sortByType);
			this.sortByQuantity.ImageNorm = GFXLibrary.sort_normal;
			this.sortByQuantity.ImageOver = GFXLibrary.sort_over;
			this.sortByQuantity.ImageClick = GFXLibrary.sort_in;
			this.sortByQuantity.Position = new Point(449, 4);
			this.sortByQuantity.Text.Text = SK.Text("Card_Sorting_Quantity", "Sort By Quantity");
			this.sortByQuantity.Text.Color = global::ARGBColors.White;
			this.sortByQuantity.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sortByQuantity.TextYOffset = -1;
			this.sortByQuantity.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByQuantityClicked), "PlayCardsPanel_sort_by_type");
			this.sortBack.addControl(this.sortByQuantity);
			this.sortByRarity.ImageNorm = GFXLibrary.sort_normal;
			this.sortByRarity.ImageOver = GFXLibrary.sort_over;
			this.sortByRarity.ImageClick = GFXLibrary.sort_in;
			this.sortByRarity.Position = new Point(368, 4);
			this.sortByRarity.Text.Text = SK.Text("Card_Sorting_Rarity", "Sort By Rarity");
			this.sortByRarity.Text.Color = global::ARGBColors.White;
			this.sortByRarity.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sortByRarity.TextYOffset = -1;
			this.sortByRarity.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByRarityClicked), "PlayCardsPanel_sort_by_rarity");
			this.compressButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.compressButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.compressButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.compressButton.Position = new Point(677, 16);
			this.compressButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.compressClicked), "PlayCardsPanel_compress_cards");
			this.sortBack.addControl(this.compressButton);
			this.expandButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.expandButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.expandButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.expandButton.Position = new Point(677, -2);
			this.expandButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.expandClicked), "PlayCardsPanel_expand_cards");
			this.sortBack.addControl(this.expandButton);
			if (this.sortByMode == 0 || this.sortByMode == 2)
			{
				this.sortByName.Alpha = 0.5f;
				this.sortByType.Alpha = 1f;
				this.sortByQuantity.Alpha = 0.5f;
			}
			else if (this.sortByMode == 1 || this.sortByMode == 3)
			{
				this.sortByName.Alpha = 1f;
				this.sortByType.Alpha = 0.5f;
				this.sortByQuantity.Alpha = 0.5f;
			}
			else if (this.sortByMode == 7 || this.sortByMode == 8)
			{
				this.sortByName.Alpha = 0.5f;
				this.sortByType.Alpha = 0.5f;
				this.sortByQuantity.Alpha = 1f;
			}
			else
			{
				this.sortByName.Alpha = 1f;
				this.sortByType.Alpha = 1f;
				this.sortByQuantity.Alpha = 1f;
			}
			int width = base.Width;
			int borderPadding = PlayCardsPanel.BorderPadding;
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
			this.closeImage.CustomTooltipID = 10100;
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 25, new Point(base.Width - 1 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			CustomSelfDrawPanel.UICardsButtons uicardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			uicardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(uicardsButtons);
			uicardsButtons.offersButton.Visible = GameEngine.Instance.cardsManager.PremiumOfferAvailable();
			uicardsButtons.inviteButton.Visible = !GameEngine.Instance.cardsManager.PremiumOfferAvailable();
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(600, 64);
			this.labelTitle.Text = "";
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			if (cardSection != 0)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = GFXLibrary.button_cards_all_normal;
				csdbutton.ImageOver = GFXLibrary.button_cards_all_over;
				csdbutton.ImageClick = GFXLibrary.button_cards_all_over;
				csdbutton.Position = new Point(390, 0);
				csdbutton.Text.Text = SK.Text("PlayCardsPanel_All_Your_Cards", "All Your Cards");
				csdbutton.TextYOffset = -3;
				csdbutton.Text.Color = global::ARGBColors.Black;
				csdbutton.Text.Size = new Size(csdbutton.Size.Width - 45, csdbutton.Size.Height);
				csdbutton.Text.Position = new Point(45, 0);
				csdbutton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showAllCardsClick), "PlayCardsPanel_show_all_cards");
				this.mainBackgroundImage.addControl(csdbutton);
			}
			CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
			csdbutton2.ImageNorm = GFXLibrary.button_cards_in_play_normal;
			csdbutton2.ImageOver = GFXLibrary.button_cards_in_play_over;
			csdbutton2.ImageClick = GFXLibrary.button_cards_in_play_over;
			csdbutton2.Position = new Point(570, 0);
			csdbutton2.Text.Text = SK.Text("PlayCardsPanel_Cards_In_Play", "Cards In Play");
			csdbutton2.TextYOffset = -3;
			csdbutton2.Text.Color = global::ARGBColors.Black;
			csdbutton2.Text.Size = new Size(csdbutton2.Size.Width - 30, csdbutton2.Size.Height);
			csdbutton2.Text.Position = new Point(30, 0);
			csdbutton2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showCardsInPlay), "PlayCardsPanel_cards_in_play");
			this.mainBackgroundImage.addControl(csdbutton2);
			this.searchButton.ImageNorm = GFXLibrary.int_statsscreen_search_button_normal;
			this.searchButton.ImageOver = GFXLibrary.int_statsscreen_search_button_over;
			this.searchButton.ImageClick = GFXLibrary.int_statsscreen_search_button_pushed;
			this.searchButton.Position = new Point(811, 7);
			this.searchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchClicked), "StatsPanel_search");
			this.searchButton.CustomTooltipID = 10319;
			this.searchButton.Visible = true;
			this.mainBackgroundImage.addControl(this.searchButton);
			this.clearSearchButton.ImageNorm = GFXLibrary.int_statsscreen_search_clear_button_normal;
			this.clearSearchButton.ImageOver = GFXLibrary.int_statsscreen_search_clear_button_over;
			this.clearSearchButton.ImageClick = GFXLibrary.int_statsscreen_search_clear_button_pushed;
			this.clearSearchButton.Position = new Point(740, 7);
			this.clearSearchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clearSearchClicked), "StatsPanel_clear_search");
			this.clearSearchButton.Visible = false;
			this.clearSearchButton.CustomTooltipID = 10320;
			this.mainBackgroundImage.addControl(this.clearSearchButton);
			CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
			cardDefinition.cardCategory = cardSection;
			if (GameEngine.Instance.World.getTutorialStage() == 8 || GameEngine.Instance.World.getTutorialStage() == 12)
			{
				cardDefinition.rewardcard = true;
			}
			cardDefinition.rewardcard = true;
			GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "", ((PlayCardsWindow)base.ParentForm).getNameSearchText());
			if (cardSection < 15)
			{
				this.sectionName = CardSections.getName(cardSection);
			}
			else
			{
				this.sectionName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(CardFilters.getName2(cardSection).ToLower());
			}
			this.labelTitle.Text = this.sectionName + " : " + GameEngine.Instance.cardsManager.ProfileCardsSearch.Count.ToString();
			this.GetCardsAvailable(false);
			this.RenderCards();
			this.mainBackgroundImage.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelHandler));
			if (cardSection == 0)
			{
				this.InitFilters();
			}
			if (cardSection == 0)
			{
				((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = !this.searchButton.Visible;
			}
			else
			{
				((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
			}
			base.Invalidate();
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x001B5AD0 File Offset: 0x001B3CD0
		private void InitFilters()
		{
			foreach (CustomSelfDrawPanel.CSDButton control in this.FilterButtons)
			{
				this.mainBackgroundImage.removeControl(control);
			}
			this.FilterButtons.Clear();
			int num = 0;
			if (this.usingRecentFilter)
			{
				num = 1048576;
			}
			else if (GameEngine.Instance.cardsManager.lastUserCardSearchCriteria.cardRank != 0)
			{
				num = 2097152;
			}
			else if (GameEngine.Instance.cardsManager.lastUserCardSearchCriteria != null)
			{
				num = GameEngine.Instance.cardsManager.lastUserCardSearchCriteria.newCardCategoryFilter;
			}
			int num2 = 0;
			this.addFilterButton(0, GFXLibrary.CardFilters_All, num2++, num);
			if ((num & 4096) != 0)
			{
				this.addFilterButton(4096, GFXLibrary.CardFilters_Food, num2++, num);
				this.addFilterButton(4097, GFXLibrary.CardFilters_Apples, num2++, num);
				this.addFilterButton(4098, GFXLibrary.CardFilters_Cheese, num2++, num);
				this.addFilterButton(4099, GFXLibrary.CardFilters_Meat, num2++, num);
				this.addFilterButton(4100, GFXLibrary.CardFilters_Bread, num2++, num);
				this.addFilterButton(4101, GFXLibrary.CardFilters_Veg, num2++, num);
				this.addFilterButton(4102, GFXLibrary.CardFilters_Fish, num2++, num);
				this.addFilterButton(4103, GFXLibrary.cardTypeButtons[111], GFXLibrary.cardTypeButtons[112], GFXLibrary.cardTypeButtons[113], num2++, num);
			}
			else
			{
				this.addFilterButton(4096, GFXLibrary.CardFilters_Food, num2++, num);
			}
			if ((num & 8192) != 0)
			{
				this.addFilterButton(8192, GFXLibrary.CardFilters_Resources, num2++, num);
				this.addFilterButton(8193, GFXLibrary.cardTypeButtons[0], GFXLibrary.cardTypeButtons[1], GFXLibrary.cardTypeButtons[2], num2++, num);
				this.addFilterButton(8194, GFXLibrary.cardTypeButtons[3], GFXLibrary.cardTypeButtons[4], GFXLibrary.cardTypeButtons[5], num2++, num);
				this.addFilterButton(8195, GFXLibrary.cardTypeButtons[6], GFXLibrary.cardTypeButtons[7], GFXLibrary.cardTypeButtons[8], num2++, num);
				this.addFilterButton(8196, GFXLibrary.cardTypeButtons[9], GFXLibrary.cardTypeButtons[10], GFXLibrary.cardTypeButtons[11], num2++, num);
			}
			else
			{
				this.addFilterButton(8192, GFXLibrary.CardFilters_Resources, num2++, num);
			}
			if ((num & 16384) != 0)
			{
				this.addFilterButton(16384, GFXLibrary.CardFilters_Honour, num2++, num);
				this.addFilterButton(16385, GFXLibrary.cardTypeButtons[12], GFXLibrary.cardTypeButtons[13], GFXLibrary.cardTypeButtons[14], num2++, num);
				this.addFilterButton(16386, GFXLibrary.cardTypeButtons[15], GFXLibrary.cardTypeButtons[16], GFXLibrary.cardTypeButtons[17], num2++, num);
				this.addFilterButton(16387, GFXLibrary.cardTypeButtons[18], GFXLibrary.cardTypeButtons[19], GFXLibrary.cardTypeButtons[20], num2++, num);
				this.addFilterButton(16388, GFXLibrary.cardTypeButtons[21], GFXLibrary.cardTypeButtons[22], GFXLibrary.cardTypeButtons[23], num2++, num);
				this.addFilterButton(16389, GFXLibrary.cardTypeButtons[24], GFXLibrary.cardTypeButtons[25], GFXLibrary.cardTypeButtons[26], num2++, num);
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Salt)
				{
					this.addFilterButton(16390, GFXLibrary.cardTypeButtons[27], GFXLibrary.cardTypeButtons[28], GFXLibrary.cardTypeButtons[29], num2++, num);
				}
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Spice)
				{
					this.addFilterButton(16391, GFXLibrary.cardTypeButtons[30], GFXLibrary.cardTypeButtons[31], GFXLibrary.cardTypeButtons[32], num2++, num);
				}
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Silk)
				{
					this.addFilterButton(16392, GFXLibrary.cardTypeButtons[33], GFXLibrary.cardTypeButtons[34], GFXLibrary.cardTypeButtons[35], num2++, num);
				}
			}
			else
			{
				this.addFilterButton(16384, GFXLibrary.CardFilters_Honour, num2++, num);
			}
			if ((num & 32768) != 0)
			{
				this.addFilterButton(32768, GFXLibrary.CardFilters_Weapons2, num2++, num);
				this.addFilterButton(32769, GFXLibrary.cardTypeButtons[36], GFXLibrary.cardTypeButtons[37], GFXLibrary.cardTypeButtons[38], num2++, num);
				this.addFilterButton(32770, GFXLibrary.cardTypeButtons[39], GFXLibrary.cardTypeButtons[40], GFXLibrary.cardTypeButtons[41], num2++, num);
				this.addFilterButton(32771, GFXLibrary.cardTypeButtons[42], GFXLibrary.cardTypeButtons[43], GFXLibrary.cardTypeButtons[44], num2++, num);
				this.addFilterButton(32772, GFXLibrary.cardTypeButtons[45], GFXLibrary.cardTypeButtons[46], GFXLibrary.cardTypeButtons[47], num2++, num);
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Catapults)
				{
					this.addFilterButton(32773, GFXLibrary.cardTypeButtons[48], GFXLibrary.cardTypeButtons[49], GFXLibrary.cardTypeButtons[50], num2++, num);
				}
			}
			else
			{
				this.addFilterButton(32768, GFXLibrary.CardFilters_Weapons2, num2++, num);
			}
			if ((num & 65536) != 0)
			{
				this.addFilterButton(65536, GFXLibrary.CardFilters_Castle, num2++, num);
				this.addFilterButton(65537, GFXLibrary.cardTypeButtons[51], GFXLibrary.cardTypeButtons[52], GFXLibrary.cardTypeButtons[53], num2++, num);
				this.addFilterButton(65538, GFXLibrary.cardTypeButtons[54], GFXLibrary.cardTypeButtons[55], GFXLibrary.cardTypeButtons[56], num2++, num);
				this.addFilterButton(65539, GFXLibrary.cardTypeButtons[57], GFXLibrary.cardTypeButtons[58], GFXLibrary.cardTypeButtons[59], num2++, num);
				this.addFilterButton(65540, GFXLibrary.cardTypeButtons[60], GFXLibrary.cardTypeButtons[61], GFXLibrary.cardTypeButtons[62], num2++, num);
			}
			else
			{
				this.addFilterButton(65536, GFXLibrary.CardFilters_Castle, num2++, num);
			}
			if ((num & 131072) != 0)
			{
				this.addFilterButton(131072, GFXLibrary.CardFilters_Army, num2++, num);
				this.addFilterButton(131073, GFXLibrary.cardTypeButtons[63], GFXLibrary.cardTypeButtons[64], GFXLibrary.cardTypeButtons[65], num2++, num);
				this.addFilterButton(131074, GFXLibrary.cardTypeButtons[66], GFXLibrary.cardTypeButtons[67], GFXLibrary.cardTypeButtons[68], num2++, num);
				this.addFilterButton(131075, GFXLibrary.cardTypeButtons[69], GFXLibrary.cardTypeButtons[70], GFXLibrary.cardTypeButtons[71], num2++, num);
				this.addFilterButton(131076, GFXLibrary.cardTypeButtons[72], GFXLibrary.cardTypeButtons[73], GFXLibrary.cardTypeButtons[74], num2++, num);
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Strategy)
				{
					this.addFilterButton(131077, GFXLibrary.cardTypeButtons[75], GFXLibrary.cardTypeButtons[76], GFXLibrary.cardTypeButtons[77], num2++, num);
				}
			}
			else
			{
				this.addFilterButton(131072, GFXLibrary.CardFilters_Army, num2++, num);
			}
			if ((num & 262144) != 0)
			{
				this.addFilterButton(262144, GFXLibrary.CardFilters_Specialist, num2++, num);
				this.addFilterButton(262145, GFXLibrary.cardTypeButtons[78], GFXLibrary.cardTypeButtons[79], GFXLibrary.cardTypeButtons[80], num2++, num);
				this.addFilterButton(262146, GFXLibrary.cardTypeButtons[81], GFXLibrary.cardTypeButtons[82], GFXLibrary.cardTypeButtons[83], num2++, num);
				this.addFilterButton(262147, GFXLibrary.cardTypeButtons[84], GFXLibrary.cardTypeButtons[85], GFXLibrary.cardTypeButtons[86], num2++, num);
				this.addFilterButton(262148, GFXLibrary.cardTypeButtons[87], GFXLibrary.cardTypeButtons[88], GFXLibrary.cardTypeButtons[89], num2++, num);
				this.addFilterButton(262149, GFXLibrary.cardTypeButtons[90], GFXLibrary.cardTypeButtons[91], GFXLibrary.cardTypeButtons[92], num2++, num);
				this.addFilterButton(262150, GFXLibrary.cardTypeButtons[93], GFXLibrary.cardTypeButtons[94], GFXLibrary.cardTypeButtons[95], num2++, num);
				if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Capacity)
				{
					this.addFilterButton(262151, GFXLibrary.cardTypeButtons[96], GFXLibrary.cardTypeButtons[97], GFXLibrary.cardTypeButtons[98], num2++, num);
				}
				this.addFilterButton(262152, GFXLibrary.cardTypeButtons[99], GFXLibrary.cardTypeButtons[100], GFXLibrary.cardTypeButtons[101], num2++, num);
			}
			else
			{
				this.addFilterButton(262144, GFXLibrary.CardFilters_Specialist, num2++, num);
			}
			if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_Parish)
			{
				if ((num & 524288) != 0)
				{
					this.addFilterButton(524288, GFXLibrary.CardFilters_Parish, num2++, num);
				}
				else
				{
					this.addFilterButton(524288, GFXLibrary.CardFilters_Parish, num2++, num);
				}
			}
			this.addFilterButton(1048576, GFXLibrary.card_type_buttons_recent_normal, GFXLibrary.card_type_buttons_recent_over, GFXLibrary.card_type_buttons_recent_in, num2++, num);
			this.addFilterButton(2097152, GFXLibrary.CardFilters_Playable, num2++, num);
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x0001BB89 File Offset: 0x00019D89
		private void addFilterButton(int category, BaseImage[] buttonImage, int index, int currentFilter)
		{
			this.addFilterButton(category, buttonImage[GFXLibrary.ButtonStateNormal], buttonImage[GFXLibrary.ButtonStateOver], buttonImage[GFXLibrary.ButtonStatePressed], index, currentFilter);
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x001B6430 File Offset: 0x001B4630
		private void addFilterButton(int category, BaseImage normalImage, BaseImage overImage, BaseImage clickedImage, int index, int currentFilter)
		{
			CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
			if (currentFilter == category)
			{
				csdbutton.ImageNorm = overImage;
				csdbutton.ImageOver = overImage;
				csdbutton.ImageClick = overImage;
				csdbutton.Data = category;
				csdbutton.CustomTooltipData = category;
				csdbutton.CustomTooltipID = 10105;
				csdbutton.ClipRect = new Rectangle(0, 6, 51, 22);
				csdbutton.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - 84, this.AvailablePanel.Y + 8 + index * 24);
			}
			else
			{
				csdbutton.ImageNorm = normalImage;
				csdbutton.ImageOver = overImage;
				csdbutton.ImageClick = clickedImage;
				csdbutton.Data = category;
				csdbutton.CustomTooltipData = category;
				csdbutton.CustomTooltipID = 10105;
				csdbutton.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - 84, this.AvailablePanel.Y + 8 + index * 24);
				csdbutton.ClipRect = new Rectangle(0, 6, 51, 22);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.NewFilterClick), "PlayCardsPanel_filter");
			}
			this.FilterButtons.Add(csdbutton);
			this.mainBackgroundImage.addControl(csdbutton);
		}

		// Token: 0x06001C1B RID: 7195 RVA: 0x001B658C File Offset: 0x001B478C
		public void NewFilterClick()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			if (!this.waitingResponse)
			{
				CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
				int data = csdbutton.Data;
				this.usingRecentFilter = (data == 1048576);
				if (data == 2097152)
				{
					cardDefinition.cardRank = GameEngine.Instance.World.getRank() + 1;
				}
				else
				{
					cardDefinition.newCardCategoryFilter = data;
				}
				GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "", ((PlayCardsWindow)base.ParentForm).getNameSearchText());
				if ((data & 255) == 0)
				{
					if (!this.searchButton.Visible && !((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible)
					{
						this.searchButton.Visible = true;
					}
					((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = !this.searchButton.Visible;
				}
				else
				{
					((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
					this.searchButton.Visible = false;
				}
				this.InitFilters();
			}
			this.labelTitle.Text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(CardFilters.getName2(csdbutton.CustomTooltipData).ToLower()) + " : " + GameEngine.Instance.cardsManager.countCardsInCategory(csdbutton.CustomTooltipData).ToString();
			if (this.usingRecentFilter)
			{
				this.sortBack.Visible = false;
				this.GetCardsRecent();
				((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
				this.searchButton.Visible = false;
			}
			else
			{
				this.GetCardsAvailable(true);
			}
			this.clearSearchButton.Visible = ((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible;
			int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
			this.scrollbarAvailable.Value = 0;
			this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
			this.AvailableContentScroll();
			base.Invalidate();
		}

		// Token: 0x06001C1C RID: 7196 RVA: 0x001B67B8 File Offset: 0x001B49B8
		public void FilterClick()
		{
			if (!this.waitingResponse)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
				if (data != 999)
				{
					cardDefinition.cardFilter = data;
				}
				else
				{
					cardDefinition.cardColour = 2;
				}
				GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "", ((PlayCardsWindow)base.ParentForm).getNameSearchText());
			}
			this.GetCardsAvailable(true);
			int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
			this.scrollbarAvailable.Value = 0;
			this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
			this.AvailableContentScroll();
			base.Invalidate();
		}

		// Token: 0x06001C1D RID: 7197 RVA: 0x001B6888 File Offset: 0x001B4A88
		public void searchClicked()
		{
			this.searchButton.Visible = false;
			this.clearSearchButton.Visible = true;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = true;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Focus();
			this.handleSearchTextChanged();
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x0001BBAA File Offset: 0x00019DAA
		public void forceSearch()
		{
			this.searchButton.Visible = false;
			this.clearSearchButton.Visible = true;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = true;
			this.handleSearchTextChanged();
		}

		// Token: 0x06001C1F RID: 7199 RVA: 0x0001BBE0 File Offset: 0x00019DE0
		private void clearSearchClicked()
		{
			this.searchButton.Visible = true;
			this.clearSearchButton.Visible = false;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
			this.handleSearchTextChanged();
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x001B68E0 File Offset: 0x001B4AE0
		public void handleSearchTextChanged()
		{
			GameEngine.Instance.cardsManager.searchProfileCardsRedoLast(((PlayCardsWindow)base.ParentForm).getNameSearchText());
			this.GetCardsAvailable(false);
			int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
			this.scrollbarAvailable.Value = 0;
			this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
			this.AvailableContentScroll();
			base.Invalidate();
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x001B6974 File Offset: 0x001B4B74
		private void GetCardsAvailable(bool redosearch)
		{
			if (redosearch)
			{
				GameEngine.Instance.cardsManager.searchProfileCardsRedoLast();
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int key in GameEngine.Instance.cardsManager.ProfileCardsSearch)
			{
				int id = GameEngine.Instance.cardsManager.ProfileCards[key].id;
				if (dictionary.ContainsKey(id))
				{
					Dictionary<int, int> dictionary2 = dictionary;
					int key2 = id;
					int num = dictionary2[key2];
					dictionary2[key2] = num + 1;
				}
				else
				{
					dictionary.Add(id, 1);
				}
			}
			foreach (UICard uicard in this.UICardList)
			{
				uicard.clearControls();
				if (uicard.Parent != null)
				{
					uicard.Parent.removeControl(uicard);
				}
			}
			this.UICardList.Clear();
			int num2 = GameEngine.Instance.World.getRank() + 1;
			foreach (int num3 in GameEngine.Instance.cardsManager.ProfileCardsSearch)
			{
				int id2 = GameEngine.Instance.cardsManager.ProfileCards[num3].id;
				try
				{
					if (dictionary.ContainsKey(id2))
					{
						UICard uicard2 = new UICard();
						uicard2.cardCount = dictionary[id2];
						uicard2.UserID = num3;
						uicard2.UserIDList.Add(num3);
						uicard2.Definition = GameEngine.Instance.cardsManager.ProfileCards[num3];
						switch (uicard2.Definition.cardColour)
						{
						case 1:
							uicard2.bigFrame = GFXLibrary.BlueCardOverlayBig;
							uicard2.bigFrameOver = GFXLibrary.BlueCardOverlayBigOver;
							break;
						case 2:
							uicard2.bigFrame = GFXLibrary.GreenCardOverlayBig;
							uicard2.bigFrameOver = GFXLibrary.GreenCardOverlayBigOver;
							break;
						case 3:
							uicard2.bigFrame = GFXLibrary.PurpleCardOverlayBig;
							uicard2.bigFrameOver = GFXLibrary.PurpleCardOverlayBigOver;
							break;
						case 4:
							uicard2.bigFrame = GFXLibrary.RedCardOverlayBig;
							uicard2.bigFrameOver = GFXLibrary.RedCardOverlayBigOver;
							break;
						case 5:
							uicard2.bigFrame = GFXLibrary.YellowCardOverlayBig;
							uicard2.bigFrameOver = GFXLibrary.YellowCardOverlayBigOver;
							break;
						}
						uicard2.bigImage = GFXLibrary.Instance.getCardImageBig(uicard2.Definition.id);
						uicard2.Size = uicard2.bigFrame.Size;
						uicard2.CustomTooltipID = 10101;
						uicard2.CustomTooltipData = uicard2.Definition.id;
						uicard2.bigGradeImage = new CustomSelfDrawPanel.CSDImage();
						int grade = CardTypes.getGrade(uicard2.Definition.cardGrade);
						if (grade <= 262144)
						{
							if (grade == 65536)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width, 0);
								goto IL_544;
							}
							if (grade == 131072)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.CardGradeSilver;
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width, 0);
								goto IL_544;
							}
							if (grade == 262144)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.card_gold_anim[0];
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width - 3, 0);
								goto IL_544;
							}
						}
						else if (grade <= 1048576)
						{
							if (grade == 524288)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.card_diamond_anim[0];
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width - 3, -2);
								goto IL_544;
							}
							if (grade == 1048576)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[0];
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width - 3, -7);
								goto IL_544;
							}
						}
						else
						{
							if (grade == 2097152)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[0];
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width - 3, -10);
								goto IL_544;
							}
							if (grade == 4194304)
							{
								uicard2.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[0];
								uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width - 3, -12);
								goto IL_544;
							}
						}
						uicard2.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
						uicard2.bigGradeImage.Position = new Point(uicard2.Width - uicard2.bigGradeImage.Width, 0);
						IL_544:
						uicard2.bigBaseImage = new CustomSelfDrawPanel.CSDImage();
						uicard2.bigBaseImage.Position = new Point(10, 11);
						uicard2.bigBaseImage.Size = uicard2.bigImage.Size;
						uicard2.bigBaseImage.Image = uicard2.bigImage;
						uicard2.addControl(uicard2.bigBaseImage);
						uicard2.bigFrameImage = new CustomSelfDrawPanel.CSDImage();
						uicard2.bigFrameImage.Position = new Point(0, 0);
						uicard2.bigFrameImage.Size = uicard2.bigFrame.Size;
						uicard2.bigFrameImage.Image = uicard2.bigFrame;
						uicard2.addControl(uicard2.bigFrameImage);
						if (grade <= 524288)
						{
							if (grade == 262144)
							{
								uicard2.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
								uicard2.bigFrameExtraImage.Position = new Point(0, 0);
								uicard2.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_gold;
								uicard2.addControl(uicard2.bigFrameExtraImage);
								goto IL_713;
							}
							if (grade != 524288)
							{
								goto IL_713;
							}
						}
						else if (grade != 1048576 && grade != 2097152)
						{
							if (grade != 4194304)
							{
								goto IL_713;
							}
							uicard2.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
							uicard2.bigFrameExtraImage.Position = new Point(0, 0);
							uicard2.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
							uicard2.addControl(uicard2.bigFrameExtraImage);
							goto IL_713;
						}
						uicard2.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
						uicard2.bigFrameExtraImage.Position = new Point(0, 0);
						uicard2.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
						uicard2.addControl(uicard2.bigFrameExtraImage);
						IL_713:
						uicard2.bigGradeImage.Size = uicard2.bigGradeImage.Image.Size;
						uicard2.addControl(uicard2.bigGradeImage);
						uicard2.bigTitle = new CustomSelfDrawPanel.CSDLabel();
						uicard2.bigTitle.Text = CardTypes.getDescriptionFromCard(uicard2.Definition.id);
						uicard2.bigTitle.Size = new Size(110, 48);
						uicard2.bigTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						if ((uicard2.Definition.id == 1801 || uicard2.Definition.id == 1542 || uicard2.Definition.id == 3137 || uicard2.Definition.id == 1290 || uicard2.Definition.id == 1541 || uicard2.Definition.id == 1543) && Program.mySettings.LanguageIdent == "de")
						{
							uicard2.bigTitle.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						}
						else
						{
							uicard2.bigTitle.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						}
						uicard2.bigTitle.Color = global::ARGBColors.White;
						uicard2.bigTitle.DropShadowColor = global::ARGBColors.Black;
						uicard2.bigTitle.Position = new Point(38, 12);
						uicard2.addControl(uicard2.bigTitle);
						uicard2.bigEffect = new CustomSelfDrawPanel.CSDLabel();
						uicard2.bigEffect.Text = uicard2.Definition.EffectText;
						uicard2.bigEffect.Size = new Size(150, 64);
						uicard2.bigEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						uicard2.bigEffect.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
						if (Program.mySettings.LanguageIdent == "de" && CardTypes.isGermanSmallDesc(uicard2.Definition.id))
						{
							uicard2.bigEffect.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
						}
						uicard2.bigEffect.Color = global::ARGBColors.White;
						uicard2.bigEffect.DropShadowColor = global::ARGBColors.Black;
						uicard2.bigEffect.Position = new Point(14, 174);
						uicard2.addControl(uicard2.bigEffect);
						CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
						csdlabel.Position = new Point(2, 2);
						csdlabel.Size = new Size(uicard2.Width, uicard2.Height);
						csdlabel.Text = "";
						csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						csdlabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
						csdlabel.Color = global::ARGBColors.Yellow;
						csdlabel.DropShadowColor = global::ARGBColors.Black;
						uicard2.addControl(csdlabel);
						uicard2.countLabel = csdlabel;
						if (num2 < uicard2.Definition.cardRank)
						{
							Color red = global::ARGBColors.Red;
						}
						else
						{
							Color white = global::ARGBColors.White;
						}
						CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
						csdlabel2.Position = new Point(150, 220);
						csdlabel2.Size = new Size(20, 13);
						csdlabel2.Text = uicard2.Definition.cardRank.ToString();
						csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
						csdlabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
						csdlabel2.Color = global::ARGBColors.White;
						csdlabel2.DropShadowColor = global::ARGBColors.Black;
						uicard2.addControl(csdlabel2);
						uicard2.rankLabel = csdlabel2;
						uicard2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardClickPlay));
						uicard2.ScaleAll(0.95);
						this.UICardList.Add(uicard2);
						dictionary.Remove(id2);
						if (num2 < uicard2.Definition.cardRank)
						{
							uicard2.Hilight(global::ARGBColors.Gray);
						}
						else
						{
							uicard2.Hilight(global::ARGBColors.White);
						}
					}
					else
					{
						foreach (UICard uicard3 in this.UICardList)
						{
							if (uicard3.Definition.id == id2)
							{
								uicard3.UserIDList.Add(num3);
								break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					UniversalDebugLog.Log("EXCEPTION " + ex.ToString());
				}
			}
			GFXLibrary.Instance.closeBigCardsLoader();
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x001B75A8 File Offset: 0x001B57A8
		private int RefreshCards(CustomSelfDrawPanel.CSDImage content, List<UICard> list, int width)
		{
			int[] array = null;
			if (GameEngine.Instance.cardsManager.lastUserCardSearchCriteria != null)
			{
				int newCardCategoryFilter = GameEngine.Instance.cardsManager.lastUserCardSearchCriteria.newCardCategoryFilter;
				if (newCardCategoryFilter <= 16392)
				{
					switch (newCardCategoryFilter)
					{
					case 4097:
						array = CardTypes.newCategories_ApplesOrder;
						break;
					case 4098:
						array = CardTypes.newCategories_CheeseOrder;
						break;
					case 4099:
						array = CardTypes.newCategories_MeatOrder;
						break;
					case 4100:
						array = CardTypes.newCategories_BreadOrder;
						break;
					case 4101:
						array = CardTypes.newCategories_VegOrder;
						break;
					case 4102:
						array = CardTypes.newCategories_FishOrder;
						break;
					case 4103:
						array = CardTypes.newCategories_AleOrder;
						break;
					default:
						switch (newCardCategoryFilter)
						{
						case 8193:
							array = CardTypes.newCategories_WoodOrder;
							break;
						case 8194:
							array = CardTypes.newCategories_StoneOrder;
							break;
						case 8195:
							array = CardTypes.newCategories_IronOrder;
							break;
						case 8196:
							array = CardTypes.newCategories_PitchOrder;
							break;
						default:
							switch (newCardCategoryFilter)
							{
							case 16385:
								array = CardTypes.newCategories_VenisonOrder;
								break;
							case 16386:
								array = CardTypes.newCategories_FurnitureOrder;
								break;
							case 16387:
								array = CardTypes.newCategories_MetalwareOrder;
								break;
							case 16388:
								array = CardTypes.newCategories_ClothesOrder;
								break;
							case 16389:
								array = CardTypes.newCategories_WineOrder;
								break;
							case 16390:
								array = CardTypes.newCategories_SaltOrder;
								break;
							case 16391:
								array = CardTypes.newCategories_SpicesOrder;
								break;
							case 16392:
								array = CardTypes.newCategories_SilkOrder;
								break;
							}
							break;
						}
						break;
					}
				}
				else if (newCardCategoryFilter <= 65540)
				{
					switch (newCardCategoryFilter)
					{
					case 32769:
						array = CardTypes.newCategories_BowsOrder;
						break;
					case 32770:
						array = CardTypes.newCategories_PikesOrder;
						break;
					case 32771:
						array = CardTypes.newCategories_ArmourOrder;
						break;
					case 32772:
						array = CardTypes.newCategories_SwordsOrder;
						break;
					case 32773:
						array = CardTypes.newCategories_CatapultsOrder;
						break;
					default:
						switch (newCardCategoryFilter)
						{
						case 65537:
							array = CardTypes.newCategories_CastleConOrder;
							break;
						case 65538:
							array = CardTypes.newCategories_DefencesOrder;
							break;
						case 65539:
							array = CardTypes.newCategories_WallsOrder;
							break;
						case 65540:
							array = CardTypes.newCategories_KnightsOrder;
							break;
						}
						break;
					}
				}
				else
				{
					switch (newCardCategoryFilter)
					{
					case 131073:
						array = CardTypes.newCategories_ScoutingOrder;
						break;
					case 131074:
						array = CardTypes.newCategories_SpeedOrder;
						break;
					case 131075:
						array = CardTypes.newCategories_RecruitmentOrder;
						break;
					case 131076:
						array = CardTypes.newCategories_TroopsOrder;
						break;
					case 131077:
						array = CardTypes.newCategories_DiplomacyOrder;
						break;
					default:
						switch (newCardCategoryFilter)
						{
						case 262145:
							array = CardTypes.newCategories_TradeOrder;
							break;
						case 262146:
							array = CardTypes.newCategories_ReligionOrder;
							break;
						case 262147:
							array = CardTypes.newCategories_HonourOrder;
							break;
						case 262148:
							array = CardTypes.newCategories_GoldOrder;
							break;
						case 262149:
							array = CardTypes.newCategories_PopOrder;
							break;
						case 262150:
							array = CardTypes.newCategories_ResearchOrder;
							break;
						case 262151:
							array = CardTypes.newCategories_CapacityOrder;
							break;
						case 262152:
							array = CardTypes.newCategories_ConstructionOrder;
							break;
						}
						break;
					}
				}
			}
			if (GameEngine.Instance.World.getTutorialStage() == 8)
			{
				list.Sort(UICard.TUT2cardsNameComparer);
			}
			else if (GameEngine.Instance.World.getTutorialStage() == 12)
			{
				list.Sort(UICard.TUTcardsNameComparer);
			}
			else if (this.sortByMode == 0)
			{
				list.Sort(UICard.cardsNameComparer);
			}
			else if (this.sortByMode == 1)
			{
				list.Sort(UICard.cardsIDComparer);
			}
			else if (this.sortByMode == 2)
			{
				list.Sort(UICard.cardsNameComparerReverse);
			}
			else if (this.sortByMode == 3)
			{
				list.Sort(UICard.cardsIDComparerReverse);
			}
			else if (this.sortByMode == 7)
			{
				list.Sort(UICard.cardsQuantityComparer);
			}
			else if (this.sortByMode == 8)
			{
				list.Sort(UICard.cardsQuantityComparerReverse);
			}
			int num = GameEngine.Instance.World.getRank() + 1;
			content.clearDirectControlsOnly();
			foreach (UICard uicard in this.dummyCards)
			{
				uicard.clearControls();
			}
			this.dummyCards.Clear();
			int num2 = 0;
			int num3 = 16;
			int num4 = 0;
			if (this.currentCardSection == 0)
			{
				num3 = 0;
			}
			if (array != null)
			{
				this.sortBack.Visible = false;
				this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, this.AvailablePanelContent.ClipRect.Y, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanel.Height - PlayCardsPanel.BorderPadding * 2);
				int num5 = 0;
				int num6 = -1;
				for (int i = 0; i < array.Length; i += 3)
				{
					if (array[i + 2] != num6)
					{
						int num7 = array[i];
						int num8 = array[i + 1] * 178;
						int num9 = (array[i + 2] - num5) * 237;
						bool flag = false;
						UICard uicard2 = null;
						foreach (UICard uicard3 in list)
						{
							if (CardTypes.getCardType(uicard3.Definition.id) == num7)
							{
								flag = true;
								uicard2 = uicard3;
							}
						}
						CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(num7);
						if (!flag && (cardDefinition.cardRank <= 0 || cardDefinition.cardRarity <= 0 || cardDefinition.available != 1) && num8 == 0)
						{
							bool flag2 = false;
							int cardType = CardTypes.getCardType(num7);
							if (cardType >= 3031 && cardType <= 3061)
							{
								for (int j = 0; j < array.Length; j += 3)
								{
									if (array[j + 2] == array[i + 2] && num7 != array[j])
									{
										CardTypes.CardDefinition cardDefinition2 = CardTypes.getCardDefinition(array[j]);
										if (cardDefinition2.available == 1)
										{
											array[j + 1]--;
											flag2 = true;
										}
									}
								}
							}
							if (!flag2)
							{
								num5++;
								num6 = array[i + 2];
								goto IL_883;
							}
						}
						if (num9 + 237 > num2)
						{
							num2 = num9 + 237;
						}
						if (flag)
						{
							uicard2.Position = new Point(num8, num9);
							content.addControl(uicard2);
							if (num < uicard2.Definition.cardRank || uicard2.UserIDList.Count == 0)
							{
								uicard2.rankLabel.Color = global::ARGBColors.Red;
								uicard2.Hilight(global::ARGBColors.Gray);
							}
							else
							{
								uicard2.rankLabel.Color = global::ARGBColors.White;
								uicard2.Hilight(global::ARGBColors.White);
							}
							if (uicard2.cardCount > 1)
							{
								uicard2.countLabel.Text = uicard2.cardCount.ToString();
								if (uicard2.cardCount >= 100)
								{
									uicard2.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
								}
								else
								{
									uicard2.countLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
								}
							}
						}
						else if (cardDefinition.cardRank > 0 && cardDefinition.cardRarity > 0 && cardDefinition.available == 1)
						{
							UICard uicard4 = BuyCardsPanel.makeUICard(cardDefinition, RemoteServices.Instance.UserID, 10000);
							uicard4.Position = new Point(num8, num9);
							content.addControl(uicard4);
							uicard4.addControl(new CustomSelfDrawPanel.CSDFill
							{
								FillColor = Color.FromArgb(170, 0, 0, 0),
								Alpha = 0.2f,
								Position = new Point(2, 1),
								Size = new Size(uicard4.Size.Width - 2 - 4, uicard4.Size.Height - 1 - 5)
							});
							this.dummyCards.Add(uicard4);
							uicard4.CustomTooltipID = 10101;
							uicard4.CustomTooltipData = num7;
							CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
							if (cardDefinition.cardPoints > 0)
							{
								csdlabel.Text = SK.Text("CARDS_GetCard", "Get Card");
								csdlabel.Data = cardDefinition.id;
								csdlabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.linkToBuy));
							}
							else
							{
								csdlabel.Text = SK.Text("CARDS_No_Cards", "No Cards");
							}
							csdlabel.Position = new Point(num8 + 3, num9 + 5);
							csdlabel.Size = new Size(157, 217);
							csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
							csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
							csdlabel.Color = global::ARGBColors.White;
							csdlabel.CustomTooltipID = 10101;
							csdlabel.CustomTooltipData = num7;
							content.addControl(csdlabel);
						}
					}
					IL_883:;
				}
			}
			else
			{
				if (!this.usingRecentFilter)
				{
					this.sortBack.Visible = true;
				}
				this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, this.AvailablePanelContent.ClipRect.Y, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanel.Height - PlayCardsPanel.BorderPadding * 2 - 24);
				int num10 = 0;
				int num11 = 0;
				foreach (UICard uicard5 in list)
				{
					uicard5.Position = new Point(num3, num4);
					content.addControl(uicard5);
					num11 = num4;
					if (num3 > width)
					{
						num3 = 16;
						if (this.currentCardSection == 0)
						{
							num3 = 0;
						}
						num4 = (this.compressedCards ? (num4 + 58) : (num4 + (uicard5.Height + 8)));
					}
					else
					{
						num3 += uicard5.Width + 12;
					}
					if (this.compressedCards && num10 < list.Count - 4)
					{
						uicard5.ClipRect = new Rectangle(0, 0, uicard5.Width, 60);
						uicard5.bigEffect.Visible = false;
						uicard5.rankLabel.Visible = false;
					}
					else
					{
						uicard5.ClipRect = Rectangle.Empty;
						uicard5.bigEffect.Visible = true;
						uicard5.rankLabel.Visible = true;
					}
					if (this.compressedCards)
					{
						content.addControl(new CustomSelfDrawPanel.CSDLine
						{
							Position = new Point(uicard5.Position.X + 3, uicard5.Position.Y + 1),
							Size = new Size(uicard5.Width - 7, 0),
							LineColor = Color.FromArgb(128, global::ARGBColors.Black)
						});
					}
					num10++;
					if (num < uicard5.Definition.cardRank || uicard5.UserIDList.Count == 0)
					{
						uicard5.rankLabel.Color = global::ARGBColors.Red;
						uicard5.Hilight(global::ARGBColors.Gray);
					}
					else
					{
						uicard5.rankLabel.Color = global::ARGBColors.White;
						uicard5.Hilight(global::ARGBColors.White);
					}
					if (uicard5.cardCount > 1)
					{
						uicard5.countLabel.Text = uicard5.cardCount.ToString();
						if (uicard5.cardCount >= 100)
						{
							uicard5.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
						}
						else
						{
							uicard5.countLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
						}
					}
				}
				if (list.Count > 0)
				{
					num2 = num11 + list[0].Height + 8;
				}
			}
			PlayCardsPanel.disableCardsInPlay(this.UICardList);
			content.invalidate();
			return num2;
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x001B8174 File Offset: 0x001B6374
		private void linkToBuy()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = (CustomSelfDrawPanel.CSDLabel)this.ClickedControl;
				if (this.usingRecentFilter)
				{
					((PlayCardsWindow)base.ParentForm).SwitchToManageAndFilter(((UICard)this.ClickedControl.Parent).Definition.newCardCategoryFilter, csdlabel.Data);
					return;
				}
				((PlayCardsWindow)base.ParentForm).SwitchToManageAndFilter(GameEngine.Instance.cardsManager.lastUserCardSearchCriteria.newCardCategoryFilter, csdlabel.Data);
			}
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x001B81F8 File Offset: 0x001B63F8
		private void mouseWheelHandler(int delta)
		{
			if (((delta > 0 && this.scrollbarAvailable.Value - delta * 15 > 0) || (delta < 0 && this.scrollbarAvailable.Value - delta * 15 < this.scrollbarAvailable.Max)) && !this.waitingResponse)
			{
				this.scrollbarAvailable.Value += delta * -15;
				this.AvailableContentScroll();
			}
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x001890B8 File Offset: 0x001872B8
		public void UpdateScrollbar(CustomSelfDrawPanel.CSDVertScrollBar bar, CustomSelfDrawPanel.CSDImage content)
		{
			bar.Visible = (content.Height > content.ClipRect.Height);
			bar.Max = content.Height - content.ClipRect.Height;
			bar.NumVisibleLines = content.ClipRect.Height;
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x001B8264 File Offset: 0x001B6464
		public void RenderCards()
		{
			int num = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.AvailablePanelContent.Position = new Point(PlayCardsPanel.BorderPadding, PlayCardsPanel.BorderPadding);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, num);
			this.AvailablePanelContent.ClipRect = new Rectangle(0, 0, this.AvailablePanel.Width - PlayCardsPanel.BorderPadding, this.AvailablePanel.Height - PlayCardsPanel.BorderPadding * 2 - 24);
			this.AvailablePanel.addControl(this.AvailablePanelContent);
			if (num < this.AvailablePanelContent.ClipRect.Height)
			{
				num = this.AvailablePanelContent.ClipRect.Height;
			}
			this.scrollbarAvailable.Position = new Point(this.AvailablePanel.Width - PlayCardsPanel.BorderPadding - PlayCardsPanel.BorderPadding / 2, this.AvailablePanel.Y + PlayCardsPanel.BorderPadding / 2);
			this.scrollbarAvailable.Size = new Size(PlayCardsPanel.BorderPadding, this.AvailablePanel.Height - PlayCardsPanel.BorderPadding - 10);
			this.mainBackgroundImage.addControl(this.scrollbarAvailable);
			this.scrollbarAvailable.Value = 0;
			this.scrollbarAvailable.StepSize = 200;
			this.scrollbarAvailable.Max = this.AvailablePanelContent.Height - this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.NumVisibleLines = this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.OffsetTL = new Point(1, 5);
			this.scrollbarAvailable.OffsetBR = new Point(0, -10);
			this.scrollbarAvailable.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.AvailableContentScroll));
			this.scrollbarAvailable.Create(null, null, null, GFXLibrary.cardpanel_scroll_thumb_top, GFXLibrary.cardpanel_scroll_thumb_mid, GFXLibrary.cardpanel_scroll_thumb_botom);
			if (num <= this.AvailablePanelContent.ClipRect.Height)
			{
				this.scrollbarAvailable.Visible = false;
			}
			else
			{
				this.scrollbarAvailable.Visible = true;
			}
			int height = this.AvailablePanelContent.Height;
			int height2 = this.AvailablePanelContent.ClipRect.Height;
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x001B84C8 File Offset: 0x001B66C8
		private void AvailableContentScroll()
		{
			int value = this.scrollbarAvailable.Value;
			this.AvailablePanelContent.Position = new Point(this.AvailablePanelContent.Position.X, PlayCardsPanel.BorderPadding - value);
			this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, value, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanelContent.ClipRect.Height);
			this.AvailablePanelContent.invalidate();
			this.AvailablePanel.invalidate();
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x001B856C File Offset: 0x001B676C
		private void InplayContentScroll()
		{
			int value = this.scrollbarInplay.Value;
			this.InplayPanelContent.Position = new Point(this.InplayPanelContent.Position.X, PlayCardsPanel.BorderPadding - value);
			this.InplayPanelContent.ClipRect = new Rectangle(this.InplayPanelContent.ClipRect.X, value, this.InplayPanelContent.ClipRect.Width, this.InplayPanelContent.ClipRect.Height);
			this.InplayPanelContent.invalidate();
			this.AvailablePanel.invalidate();
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x0001BC16 File Offset: 0x00019E16
		private void cardClickPlay()
		{
			this.doCardClickPlay(true, false);
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x001B8610 File Offset: 0x001B6810
		private void doCardClickPlay(bool fromClick, bool fromValidate)
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				try
				{
					if (!this.waitingResponse)
					{
						if (this.ClickedControl.GetType() == typeof(UICard) || !fromClick)
						{
							UICard uicard = this.lastRequestCard = ((!fromClick) ? this.lastRequestCard : ((UICard)this.ClickedControl));
							this.waitingResponse = true;
							XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
							this.selectedVillage = -1;
							int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
							if (!GameEngine.Instance.World.isCapital(selectedMenuVillage) || CardTypes.getCardType(uicard.Definition.id) == 3076)
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
							}
							else if ((this.lastRequestCard.Definition.id == 3109 || this.lastRequestCard.Definition.id == 3110 || this.lastRequestCard.Definition.id == 3111 || this.lastRequestCard.Definition.id == 3112) && GameEngine.Instance.Village != null && GameEngine.Instance.Village.countBuildingType(35) == 0)
							{
								MyMessageBox.Show(SK.Text("PlayCard_No_Inn_Available", "An inn must be built at the current village before this card can be played."));
								this.waitingResponse = false;
							}
							else
							{
								if (fromClick && Program.mySettings.ConfirmPlayCard)
								{
									GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_open_confirmation");
									base.PanelActive = false;
									this.waitingResponse = false;
									InterfaceMgr.Instance.openConfirmPlayCardPopup(uicard.Definition, new ConfirmPlayCardPanel.CardClickPlayDelegate(this.doCardClickPlay));
									goto IL_635;
								}
								if (fromValidate || !CardTypes.cardNeedsValidation(CardTypes.getCardType(uicard.Definition.id)))
								{
									try
									{
										if (InterfaceMgr.Instance.getCardWindow() != null)
										{
											CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.getCardWindow());
										}
										if (fromClick)
										{
											GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card");
										}
										xmlRpcCardsProvider.PlayUserCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), uicard.UserIDList[0].ToString(), this.selectedVillage.ToString(), RemoteServices.Instance.ProfileWorldID.ToString()), new CardsEndResponseDelegate(this.CardPlayed), this);
										GameEngine.Instance.cardsManager.removeProfileCard(uicard.UserIDList[0]);
										if (this.lastRequestCard.cardCount > 1 || this.usingRecentFilter)
										{
											this.lastRequestUserID = uicard.UserIDList[0];
											this.lastRequestCard.UserIDList.Remove(uicard.UserIDList[0]);
											this.lastRequestCard.cardCount--;
											if (this.lastRequestCard.cardCount > 1)
											{
												this.lastRequestCard.countLabel.Text = this.lastRequestCard.cardCount.ToString();
												if (this.lastRequestCard.cardCount >= 100)
												{
													this.lastRequestCard.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
												}
												else
												{
													this.lastRequestCard.countLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
												}
											}
											else
											{
												this.lastRequestCard.countLabel.Text = "";
												if (this.usingRecentFilter && this.lastRequestCard.cardCount < 1)
												{
													this.lastRequestCard.buyCardsLabel.Visible = true;
													this.lastRequestCard.Hilight(global::ARGBColors.Gray);
													this.lastRequestCard.setClickDelegate(null);
													this.lastRequestCard.buyCardsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.linkToBuy));
												}
											}
											this.AvailablePanelContent.invalidate();
											if (this.usingRecentFilter)
											{
												this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
											}
										}
										else
										{
											this.UICardList.Remove(this.lastRequestCard);
											this.lastRequestUserID = uicard.UserIDList[0];
											int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
											this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
											this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
										}
										goto IL_5B2;
									}
									catch (Exception ex)
									{
										MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
										goto IL_5B2;
									}
								}
								this.validateCardPossible(CardTypes.getCardType(uicard.Definition.id), this.selectedVillage);
								goto IL_635;
							}
						}
						IL_5B2:
						if (this.usingRecentFilter)
						{
							this.labelTitle.Text = SK.Text("CARDFILTER_RECENT2", "Recent") + " : " + GameEngine.Instance.cardsManager.countCardsInCategory(1048576).ToString();
						}
						else
						{
							this.labelTitle.Text = this.sectionName + " : " + GameEngine.Instance.cardsManager.ProfileCardsSearch.Count.ToString();
						}
					}
					IL_635:;
				}
				catch (Exception ex2)
				{
					UniversalDebugLog.Log(ex2.ToString());
				}
			}
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x0001BC20 File Offset: 0x00019E20
		public void validateCardPossible(int cardType, int villageID)
		{
			RemoteServices.Instance.set_PreValidateCardToBePlayed_UserCallBack(new RemoteServices.PreValidateCardToBePlayed_UserCallBack(this.preValidateCardToBePlayedCallBack));
			RemoteServices.Instance.PreValidateCardToBePlayed(cardType, villageID);
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x001B8C98 File Offset: 0x001B6E98
		public void preValidateCardToBePlayedCallBack(PreValidateCardToBePlayed_ReturnType returnData)
		{
			this.waitingResponse = false;
			if (returnData.Success)
			{
				if (CardTypes.isMercenaryTroopCardType(returnData.cardType) && returnData.otherErrorCode == 9999)
				{
					string str = SK.Text("RETURNED_CARD_ERROR_UNIT_SPACE", "There is not enough unit space to accomodate these troops. If troops are dispatched from this village some may be lost upon their return.");
					DialogResult dialogResult = MyMessageBox.Show(str + Environment.NewLine + Environment.NewLine + SK.Text("PlayCard_Still_Play", "Do you still wish to Play this Card?"), SK.Text("PlayCards_Confirm_play", "Confirm Play Card"), MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.No)
					{
						return;
					}
				}
				if (returnData.canPlayFully)
				{
					this.doCardClickPlay(false, true);
					return;
				}
				if (returnData.canPlayPartially)
				{
					string str2 = "";
					switch (returnData.cardType)
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
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_5", "Amount of Food gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3109:
					case 3110:
					case 3111:
					case 3112:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_6", "Amount of Ale gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
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
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_7", "Amount of Resources gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
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
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_8", "Amount of Honour Goods gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
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
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_9", "Number of Weapons gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3169:
					case 3170:
					case 3171:
					case 3172:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_10", "Amount of Armour gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3177:
					case 3178:
					case 3179:
					case 3180:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_11", "Number of Catapults gained will be"),
							" : ",
							returnData.numCanPlay.ToString()
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
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_1", "Number of Troops that can be recruited"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3287:
					case 3288:
					case 3289:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_2", "Number of Scouts that can be recruited"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3290:
					case 3291:
					case 3292:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_3", "Number of Monks that can be recruited"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					case 3293:
					case 3294:
					case 3295:
						str2 = string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE2", "There isn't enough room to fully play this card."),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_15_4", "Number of Merchants that can be recruited"),
							" : ",
							returnData.numCanPlay.ToString()
						});
						break;
					}
					DialogResult dialogResult2 = MyMessageBox.Show(str2 + Environment.NewLine + Environment.NewLine + SK.Text("PlayCard_Still_Play", "Do you still wish to Play this Card?"), SK.Text("PlayCards_Confirm_play", "Confirm Play Card"), MessageBoxButtons.YesNo);
					if (dialogResult2 == DialogResult.Yes)
					{
						this.doCardClickPlay(false, true);
						return;
					}
				}
				else if (returnData.otherErrorCode != 0)
				{
					if (returnData.otherErrorCode == -2)
					{
						MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 5), SK.Text("GENERIC_Error", "Error"));
					}
					else if (returnData.otherErrorCode == -3)
					{
						GameEngine.Instance.displayedVillageLost(returnData.villageID, true);
					}
				}
				else
				{
					new MyMessageBoxPopUp();
					switch (returnData.cardType)
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
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_101", "Not enough space in the Granary.")
						}), SK.Text("GENERIC_Error", "Error"));
						break;
					case 3109:
					case 3110:
					case 3111:
					case 3112:
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_102", "Not enough space in the Inn.")
						}), SK.Text("GENERIC_Error", "Error"));
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
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_103", "Not enough space on the Stockpile.")
						}), SK.Text("GENERIC_Error", "Error"));
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
						MyMessageBox.Show(string.Concat(new string[]
						{
							SK.Text("RETURNED_CARD_ERROR_BASE", "Could not play"),
							Environment.NewLine,
							Environment.NewLine,
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_104", "Not enough space in the Village Hall.")
						}), SK.Text("GENERIC_Error", "Error"));
						break;
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
							CardTypes.getDescriptionFromCard(returnData.cardType),
							Environment.NewLine,
							Environment.NewLine,
							SK.Text("RETURNED_CARD_ERROR_105", "Not enough space in the Armoury.")
						}), SK.Text("GENERIC_Error", "Error"));
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
						MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 1), SK.Text("GENERIC_Error", "Error"));
						break;
					case 3287:
					case 3288:
					case 3289:
						MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 2), SK.Text("GENERIC_Error", "Error"));
						break;
					case 3290:
					case 3291:
					case 3292:
						MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 3), SK.Text("GENERIC_Error", "Error"));
						break;
					case 3293:
					case 3294:
					case 3295:
						MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 4), SK.Text("GENERIC_Error", "Error"));
						break;
					}
				}
			}
			UniversalDebugLog.Log("Failed");
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x001B9CEC File Offset: 0x001B7EEC
		public void CardPlayed(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode == null || response.SuccessCode.Value != 1)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_failed");
				MyMessageBox.Show(CardsManager.translateCardError(response.Message, this.lastRequestCard.Definition.id), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				try
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.lastRequestUserID, CardTypes.getStringFromCard(this.lastRequestCard.Definition.id));
					this.GetCardsAvailable(true);
					int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
					this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
					this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
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
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_success");
				GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(this.lastRequestUserID);
				GameEngine.Instance.cardsManager.addRecentCard(this.lastRequestCard.Definition.id);
				if (this.lastRequestCard.UserIDList.Count > 0)
				{
					this.lastRequestCard.UserID = this.lastRequestCard.UserIDList[0];
				}
				if (CardTypes.getBasicUniqueCardType(this.lastRequestCard.Definition.id) != -1)
				{
					PlayCardsPanel.disableCardsInPlay(CardTypes.getBasicUniqueCardType(this.lastRequestCard.Definition.id), this.UICardList);
					this.AvailablePanelContent.invalidate();
				}
				GameEngine.Instance.cardsManager.CardPlayed(this.lastRequestCard.Definition.cardCategory, this.lastRequestCard.Definition.id, this.selectedVillage);
				StatTrackingClient.Instance().ActivateTrigger(15, this.usingRecentFilter);
				StatTrackingClient.Instance().ActivateTrigger(17, ((PlayCardsWindow)base.ParentForm).getNameSearchText().Length > 0 && this.clearSearchButton.Visible);
				StatTrackingClient.Instance().ActivateTrigger(6, this.lastRequestCard.Definition.id);
				if (GameEngine.Instance.World.getTutorialStage() == 8 || GameEngine.Instance.World.getTutorialStage() == 12)
				{
					InterfaceMgr.Instance.closePlayCardsWindow();
					InterfaceMgr.Instance.ParentForm.TopMost = true;
					InterfaceMgr.Instance.ParentForm.TopMost = false;
				}
			}
			this.waitingResponse = false;
			if (this.usingRecentFilter)
			{
				this.labelTitle.Text = SK.Text("CardPanel_Recent", "Recently Played") + " : " + GameEngine.Instance.cardsManager.countCardsInCategory(1048576).ToString();
				return;
			}
			this.labelTitle.Text = this.sectionName + " : " + GameEngine.Instance.cardsManager.ProfileCardsSearch.Count.ToString();
		}

		// Token: 0x06001C2E RID: 7214 RVA: 0x001BA05C File Offset: 0x001B825C
		private void cardMouseOver()
		{
			if (this.OverControl.GetType() == typeof(UICard))
			{
				UICard uicard = (UICard)this.OverControl;
				uicard.Hilight(global::ARGBColors.White);
				this.LastMouseoverCard = uicard;
			}
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x0001BC44 File Offset: 0x00019E44
		private void cardMouseLeave()
		{
			if (this.LastMouseoverCard != null)
			{
				this.LastMouseoverCard.Hilight(global::ARGBColors.LightGray);
			}
		}

		// Token: 0x06001C30 RID: 7216 RVA: 0x0001BC5E File Offset: 0x00019E5E
		private void showAllCardsClick()
		{
			((PlayCardsWindow)base.ParentForm).SetCardSection(0);
			this.init(0);
			base.Invalidate();
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x0001BC7E File Offset: 0x00019E7E
		private void showCardsInPlay()
		{
			((PlayCardsWindow)base.ParentForm).SwitchPanel(8);
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x001BA0A0 File Offset: 0x001B82A0
		public void update()
		{
			int num = (int)((DateTime.Now - this.diamondAnimStartTime).TotalMilliseconds / 33.0);
			foreach (UICard uicard in this.UICardList)
			{
				if (this.diamondAnimFrame != num)
				{
					BaseImage baseImage = null;
					if (uicard.Definition.cardGrade == 524288)
					{
						baseImage = GFXLibrary.card_diamond_anim[num / 1 % GFXLibrary.card_diamond_anim.Length];
					}
					else if (uicard.Definition.cardGrade == 2097152)
					{
						baseImage = GFXLibrary.card_diamond3_anim[num / 1 % GFXLibrary.card_diamond3_anim.Length];
					}
					else if (uicard.Definition.cardGrade == 1048576)
					{
						baseImage = GFXLibrary.card_diamond2_anim[num / 1 % GFXLibrary.card_diamond2_anim.Length];
					}
					else if (uicard.Definition.cardGrade == 262144)
					{
						baseImage = GFXLibrary.card_gold_anim[num / 1 % GFXLibrary.card_gold_anim.Length];
					}
					else if (uicard.Definition.cardGrade == 4194304)
					{
						baseImage = GFXLibrary.card_sapphire_anim[num / 1 % GFXLibrary.card_sapphire_anim.Length];
					}
					if (baseImage != null)
					{
						uicard.bigGradeImage.Image = baseImage;
						uicard.bigGradeImage.invalidateXtra();
					}
				}
			}
			this.diamondAnimFrame = num;
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x001BA220 File Offset: 0x001B8420
		private void UpdateAlpha()
		{
			if (this.bigCardAlpha == this.bigCardAlphaTarget)
			{
				return;
			}
			if (this.bigCardAlpha < this.bigCardAlphaTarget)
			{
				this.bigCardAlpha += PlayCardsPanel.fadeStep;
				if (this.bigCardAlpha > this.bigCardAlphaTarget)
				{
					this.bigCardAlpha = this.bigCardAlphaTarget;
				}
			}
			else
			{
				this.bigCardAlpha -= PlayCardsPanel.fadeStep;
				if (this.bigCardAlpha < this.bigCardAlphaTarget)
				{
					this.bigCardAlpha = this.bigCardAlphaTarget;
				}
			}
			this.SetBigCardAlpha(this.bigCardAlpha);
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void SetBigCardAlpha(float alpha)
		{
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void ShowBigCard(UICard card)
		{
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void HideBigCard()
		{
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x0001BC91 File Offset: 0x00019E91
		public void navigateTest()
		{
			this.Navigate(2);
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x000195C1 File Offset: 0x000177C1
		private void Navigate(int panelType)
		{
			((PlayCardsWindow)base.ParentForm).SwitchPanel(panelType);
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x001BA2B0 File Offset: 0x001B84B0
		private void sortByNameClicked()
		{
			if (this.sortByMode != 0)
			{
				this.sortByMode = 0;
			}
			else
			{
				this.sortByMode = 2;
			}
			this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.sortByName.Alpha = 0.5f;
			this.sortByType.Alpha = 1f;
			this.sortByQuantity.Alpha = 0.5f;
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x001BA320 File Offset: 0x001B8520
		private void sortByTypeClicked()
		{
			if (this.sortByMode != 1)
			{
				this.sortByMode = 1;
			}
			else
			{
				this.sortByMode = 3;
			}
			this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.sortByName.Alpha = 1f;
			this.sortByType.Alpha = 0.5f;
			this.sortByQuantity.Alpha = 0.5f;
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x001BA390 File Offset: 0x001B8590
		private void sortByQuantityClicked()
		{
			if (this.sortByMode != 7)
			{
				this.sortByMode = 7;
			}
			else
			{
				this.sortByMode = 8;
			}
			this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.sortByName.Alpha = 0.5f;
			this.sortByType.Alpha = 0.5f;
			this.sortByQuantity.Alpha = 1f;
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void sortByRarityClicked()
		{
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x001BA400 File Offset: 0x001B8600
		private void compressClicked()
		{
			if (!this.compressedCards)
			{
				this.compressedCards = true;
				this.scrollbarAvailable.Value = 0;
				int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
				this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
				this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
				this.AvailableContentScroll();
				base.Invalidate();
			}
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x001BA47C File Offset: 0x001B867C
		private void expandClicked()
		{
			if (this.compressedCards)
			{
				this.compressedCards = false;
				this.scrollbarAvailable.Value = 0;
				int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
				this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
				this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
				this.AvailableContentScroll();
				base.Invalidate();
			}
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x001BA4F8 File Offset: 0x001B86F8
		private void GetCardsRecent()
		{
			this.UICardList.Clear();
			List<UICard> list = new List<UICard>();
			int playerRank = GameEngine.Instance.World.getRank() + 1;
			CardTypes.CardDefinition[] cardList = CardTypes.cardList;
			foreach (CardTypes.CardDefinition cardDefinition in cardList)
			{
				if (GameEngine.Instance.cardsManager.recentCards.Contains(cardDefinition.id))
				{
					List<int> list2 = new List<int>();
					foreach (int num in GameEngine.Instance.cardsManager.ProfileCards.Keys)
					{
						if (GameEngine.Instance.cardsManager.ProfileCards[num].id == cardDefinition.id)
						{
							list2.Add(num);
						}
					}
					list.Add(this.makeUICard(cardDefinition, list2, playerRank));
				}
			}
			foreach (int num2 in GameEngine.Instance.cardsManager.recentCards)
			{
				foreach (UICard uicard in list)
				{
					if (uicard.Definition.id == num2)
					{
						this.UICardList.Add(uicard);
					}
				}
			}
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x001BA6A0 File Offset: 0x001B88A0
		private UICard makeUICard(CardTypes.CardDefinition def, List<int> userid, int playerRank)
		{
			UICard uicard = new UICard();
			uicard.cardCount = userid.Count;
			if (uicard.cardCount > 0)
			{
				uicard.UserID = userid[0];
			}
			else
			{
				uicard.UserID = -1;
			}
			foreach (int item in userid)
			{
				uicard.UserIDList.Add(item);
			}
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
			default:
				uicard.bigFrame = GFXLibrary.GreenCardOverlayBig;
				uicard.bigFrameOver = GFXLibrary.GreenCardOverlayBigOver;
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
					goto IL_3ED;
				}
				if (grade == 131072)
				{
					uicard.bigGradeImage.Image = GFXLibrary.CardGradeSilver;
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
					goto IL_3ED;
				}
				if (grade == 262144)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_gold_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, 0);
					goto IL_3ED;
				}
			}
			else if (grade <= 1048576)
			{
				if (grade == 524288)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -2);
					goto IL_3ED;
				}
				if (grade == 1048576)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -7);
					goto IL_3ED;
				}
			}
			else
			{
				if (grade == 2097152)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -10);
					goto IL_3ED;
				}
				if (grade == 4194304)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -12);
					goto IL_3ED;
				}
			}
			uicard.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
			uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
			IL_3ED:
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
					goto IL_594;
				}
				if (grade != 524288)
				{
					goto IL_594;
				}
			}
			else if (grade != 1048576 && grade != 2097152)
			{
				if (grade != 4194304)
				{
					goto IL_594;
				}
				uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
				uicard.bigFrameExtraImage.Position = new Point(0, 0);
				uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
				uicard.addControl(uicard.bigFrameExtraImage);
				goto IL_594;
			}
			uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigFrameExtraImage.Position = new Point(0, 0);
			uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
			uicard.addControl(uicard.bigFrameExtraImage);
			IL_594:
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
			if (uicard.cardCount > 1)
			{
				csdlabel.Text = uicard.cardCount.ToString();
			}
			else
			{
				csdlabel.Text = "";
			}
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
			csdlabel2.Text = "";
			csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			csdlabel2.Color = color;
			csdlabel2.DropShadowColor = global::ARGBColors.Black;
			uicard.addControl(csdlabel2);
			uicard.rankLabel = csdlabel2;
			if (def.cardPoints > 0)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel3 = new CustomSelfDrawPanel.CSDLabel();
				csdlabel3.Text = SK.Text("CARDS_GetCard", "Get Card");
				csdlabel3.Position = new Point(0, 0);
				csdlabel3.Size = new Size(157, 217);
				csdlabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdlabel3.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				csdlabel3.Color = global::ARGBColors.White;
				csdlabel3.Data = def.id;
				csdlabel3.Visible = (uicard.cardCount == 0);
				uicard.buyCardsLabel = csdlabel3;
				uicard.addControl(csdlabel3);
				if (uicard.cardCount == 0)
				{
					uicard.buyCardsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.linkToBuy));
				}
			}
			if (uicard.cardCount == 0)
			{
				uicard.Hilight(global::ARGBColors.Gray);
			}
			else
			{
				uicard.Hilight(global::ARGBColors.White);
				uicard.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardClickPlay));
			}
			uicard.ScaleAll(0.95);
			return uicard;
		}

		// Token: 0x06001C42 RID: 7234 RVA: 0x001BB0CC File Offset: 0x001B92CC
		public static void disableCardsInPlay(List<UICard> cardList)
		{
			CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			List<int> list = new List<int>();
			int num = userCardData.cards.Length;
			for (int i = 0; i < num; i++)
			{
				int basicUniqueCardType = CardTypes.getBasicUniqueCardType(CardTypes.getCardType(userCardData.cards[i]));
				if (!list.Contains(basicUniqueCardType) && basicUniqueCardType != -1)
				{
					list.Add(basicUniqueCardType);
				}
			}
			foreach (UICard uicard in cardList)
			{
				if (uicard.Enabled && list.Contains(CardTypes.getBasicUniqueCardType(uicard.Definition.id)))
				{
					uicard.Hilight(global::ARGBColors.Gray);
				}
			}
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x001BB19C File Offset: 0x001B939C
		public static void disableCardsInPlay(int basicType, List<UICard> cardList)
		{
			foreach (UICard uicard in cardList)
			{
				if (uicard.Enabled && basicType == CardTypes.getBasicUniqueCardType(uicard.Definition.id))
				{
					uicard.Hilight(global::ARGBColors.Gray);
				}
			}
		}

		// Token: 0x04002CF3 RID: 11507
		private IContainer components;

		// Token: 0x04002CF4 RID: 11508
		private DateTime lastUpdatedProgressBars = DateTime.Now.AddSeconds(30.0);

		// Token: 0x04002CF5 RID: 11509
		private DateTime lastTickCall = DateTime.Now.AddSeconds(-60.0);

		// Token: 0x04002CF6 RID: 11510
		private DateTime lastRefresh = DateTime.Now;

		// Token: 0x04002CF7 RID: 11511
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002CF8 RID: 11512
		private List<UICard> UICardList = new List<UICard>();

		// Token: 0x04002CF9 RID: 11513
		private List<UICard> UICardListInplay = new List<UICard>();

		// Token: 0x04002CFA RID: 11514
		private CustomSelfDrawPanel.CSDButton searchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002CFB RID: 11515
		private CustomSelfDrawPanel.CSDButton clearSearchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002CFC RID: 11516
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002CFD RID: 11517
		private UICard LastMouseoverCard;

		// Token: 0x04002CFE RID: 11518
		private float bigCardAlphaTarget = 1f;

		// Token: 0x04002CFF RID: 11519
		private float bigCardAlpha;

		// Token: 0x04002D00 RID: 11520
		private static float fadeStep = 0.1f;

		// Token: 0x04002D01 RID: 11521
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D02 RID: 11522
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D03 RID: 11523
		private int currentCardSection = -1;

		// Token: 0x04002D04 RID: 11524
		private string sectionName;

		// Token: 0x04002D05 RID: 11525
		private static int BorderPadding = 16;

		// Token: 0x04002D06 RID: 11526
		private int ContentWidth;

		// Token: 0x04002D07 RID: 11527
		private int AvailablePanelWidth;

		// Token: 0x04002D08 RID: 11528
		private int InplayPanelWidth;

		// Token: 0x04002D09 RID: 11529
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x04002D0A RID: 11530
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D0B RID: 11531
		private CustomSelfDrawPanel.CSDImage InplayPanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D0C RID: 11532
		private int sortByMode = -1;

		// Token: 0x04002D0D RID: 11533
		private CustomSelfDrawPanel.CSDImage sortBack = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D0E RID: 11534
		private CustomSelfDrawPanel.CSDButton sortByName = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D0F RID: 11535
		private CustomSelfDrawPanel.CSDButton sortByType = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D10 RID: 11536
		private CustomSelfDrawPanel.CSDButton sortByQuantity = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D11 RID: 11537
		private CustomSelfDrawPanel.CSDButton sortByRarity = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D12 RID: 11538
		private CustomSelfDrawPanel.CSDButton compressButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D13 RID: 11539
		private CustomSelfDrawPanel.CSDButton expandButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D14 RID: 11540
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D15 RID: 11541
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarInplay = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D16 RID: 11542
		private UICard lastRequestCard;

		// Token: 0x04002D17 RID: 11543
		private bool waitingResponse;

		// Token: 0x04002D18 RID: 11544
		private bool usingRecentFilter;

		// Token: 0x04002D19 RID: 11545
		private Bitmap greenbar = new Bitmap(29, 3);

		// Token: 0x04002D1A RID: 11546
		private int selectedVillage;

		// Token: 0x04002D1B RID: 11547
		private List<CustomSelfDrawPanel.CSDButton> FilterButtons = new List<CustomSelfDrawPanel.CSDButton>();

		// Token: 0x04002D1C RID: 11548
		private bool compressedCards;

		// Token: 0x04002D1D RID: 11549
		private List<UICard> dummyCards = new List<UICard>();

		// Token: 0x04002D1E RID: 11550
		private int lastRequestUserID;

		// Token: 0x04002D1F RID: 11551
		private int diamondAnimFrame;

		// Token: 0x04002D20 RID: 11552
		private DateTime diamondAnimStartTime = DateTime.Now;
	}
}
