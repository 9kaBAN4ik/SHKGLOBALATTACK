using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using StatTracking;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000233 RID: 563
	public class ManageCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x0600189F RID: 6303 RVA: 0x00019525 File Offset: 0x00017725
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00019544 File Offset: 0x00017744
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x001827D8 File Offset: 0x001809D8
		public ManageCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00182BC4 File Offset: 0x00180DC4
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * ManageCardsPanel.BorderPadding;
			this.AvailablePanelWidth = 800;
			this.InplayPanelWidth = this.ContentWidth - ManageCardsPanel.BorderPadding - this.AvailablePanelWidth;
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
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - 375);
			this.AvailablePanel.Alpha = 0.8f;
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			int width = base.Width;
			int borderPadding = ManageCardsPanel.BorderPadding;
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
			this.closeImage.CustomTooltipID = 10100;
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 40, new Point(base.Width - 1 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.cardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			this.cardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(this.cardsButtons);
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(600, 64);
			this.labelTitle.Text = "";
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			this.labelTitlePoints.Position = new Point(27, 8);
			this.labelTitlePoints.Size = new Size(600, 64);
			this.labelTitlePoints.Text = "";
			this.labelTitlePoints.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitlePoints.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitlePoints.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitlePoints);
			this.imageTitlePoints.Image = GFXLibrary.cardpanel_manage_card_points_icon;
			this.imageTitlePoints.Position = new Point(400, 5);
			this.mainBackgroundImage.addControl(this.imageTitlePoints);
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
			this.addPointsData();
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(2 * ManageCardsPanel.BorderPadding + this.AvailablePanelWidth, ManageCardsPanel.BorderPadding);
			csdlabel.Size = new Size(300, 64);
			csdlabel.Text = SK.Text("ManageCandsPanel_Cards_In_Play", "Cards In Play");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.White;
			csdlabel.DropShadowColor = global::ARGBColors.Black;
			this.cardTitle = new CustomSelfDrawPanel.CSDLabel();
			this.cardTitle.Position = new Point(16, 40);
			this.cardTitle.Size = new Size(600, 64);
			this.cardTitle.Text = string.Empty;
			this.cardTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.cardTitle.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.cardTitle.Color = global::ARGBColors.White;
			this.cardTitle.DropShadowColor = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.cardTitle);
			this.labelFeedback = new CustomSelfDrawPanel.CSDLabel();
			this.labelFeedback.Position = new Point(16, 500);
			this.labelFeedback.Size = new Size(600, 64);
			this.labelFeedback.Text = "";
			this.labelFeedback.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelFeedback.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.labelFeedback.Color = global::ARGBColors.White;
			this.labelFeedback.DropShadowColor = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelFeedback);
			this.buttonCash = new CustomSelfDrawPanel.CSDImage();
			this.buttonBonus = new CustomSelfDrawPanel.CSDImage();
			this.buttonCatalog = new CustomSelfDrawPanel.CSDImage();
			this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_normal;
			this.buttonCash.Size = this.buttonCash.Image.Size;
			this.buttonBonus.Image = GFXLibrary.cardpanel_button_blue_normal;
			this.buttonBonus.Size = this.buttonBonus.Image.Size;
			this.buttonCatalog.Image = GFXLibrary.cardpanel_button_blue_normal;
			this.buttonCatalog.Size = this.buttonCash.Image.Size;
			this.buttonCash.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width / 2 - this.buttonCash.Width, this.cardsButtons.Y + 4);
			this.buttonBonus.Position = new Point(this.buttonCash.X, this.buttonCash.Y);
			this.buttonCatalog.Position = new Point(this.buttonCash.X - this.buttonCash.Width, this.buttonCash.Y);
			this.buttonBonus.setMouseOverDelegate(delegate
			{
				this.buttonBonus.Image = GFXLibrary.cardpanel_button_blue_over;
			}, delegate
			{
				this.buttonBonus.Image = GFXLibrary.cardpanel_button_blue_normal;
			});
			this.buttonCash.setMouseOverDelegate(delegate
			{
				this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_over;
			}, delegate
			{
				this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_normal;
			});
			this.buttonCatalog.setMouseOverDelegate(delegate
			{
				this.buttonCatalog.Image = GFXLibrary.cardpanel_button_blue_over;
			}, delegate
			{
				this.buttonCatalog.Image = GFXLibrary.cardpanel_button_blue_normal;
			});
			this.buttonBonus.Visible = false;
			this.buttonCash.Visible = true;
			this.fastCashIn = Program.mySettings.fastCashIn;
			this.fastCashInCheckBox = new CustomSelfDrawPanel.CSDCheckBox();
			this.fastCashInCheckBox.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.fastCashInCheckBox.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.fastCashInCheckBox.Position = new Point(this.AvailablePanel.X + 590, this.cardsButtons.Y + 160);
			this.fastCashInCheckBox.Checked = this.fastCashIn;
			this.fastCashInCheckBox.CBLabel.Text = SK.Text("ManageCards_multicashin", "Multi-Cash In");
			this.fastCashInCheckBox.CBLabel.Color = global::ARGBColors.Black;
			this.fastCashInCheckBox.CBLabel.Position = new Point(20, -1);
			this.fastCashInCheckBox.CBLabel.Size = new Size(250, 25);
			this.fastCashInCheckBox.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.fastCashInCheckBox.setCheckChangedDelegate(delegate
			{
				Program.mySettings.fastCashIn = (this.fastCashIn = this.fastCashInCheckBox.Checked);
				this.RefreshSet();
			});
			this.mainBackgroundImage.addControl(this.fastCashInCheckBox);
			this.buyAndPlayCheckBox = new CustomSelfDrawPanel.CSDCheckBox();
			this.buyAndPlayCheckBox.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.buyAndPlayCheckBox.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.buyAndPlayCheckBox.Position = new Point(this.AvailablePanel.X + 100, this.cardsButtons.Y + 92);
			this.buyAndPlayCheckBox.Checked = false;
			this.buyAndPlayCheckBox.Visible = false;
			this.buyAndPlayCheckBox.CBLabel.Text = SK.Text("ManageCards_buyAndPlay", "Play Card Immediately");
			this.buyAndPlayCheckBox.CBLabel.Color = global::ARGBColors.Black;
			this.buyAndPlayCheckBox.CBLabel.Position = new Point(20, -1);
			this.buyAndPlayCheckBox.CBLabel.Size = new Size(250, 25);
			this.buyAndPlayCheckBox.CBLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.buyAndPlayCheckBox.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.buyAndPlayCheckChanged));
			this.mainBackgroundImage.addControl(this.buyAndPlayCheckBox);
			CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel2.Position = new Point(0, -2);
			csdlabel2.Size = this.buttonCash.Size;
			csdlabel2.Text = SK.Text("ManageCandsPanel_Cash_In", "Cash In");
			csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel2.Color = global::ARGBColors.Black;
			this.buttonCash.addControl(csdlabel2);
			CustomSelfDrawPanel.CSDLabel csdlabel3 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel3.Position = new Point(0, -2);
			csdlabel3.Size = this.buttonCash.Size;
			csdlabel3.Text = SK.Text("ManageCandsPanel_Cash_In", "Cash In");
			csdlabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdlabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel3.Color = global::ARGBColors.Black;
			this.buttonBonus.addControl(csdlabel3);
			this.labelBuyCash = new CustomSelfDrawPanel.CSDLabel();
			this.labelBuyCash.Position = new Point(0, -2);
			this.labelBuyCash.Size = this.buttonCash.Size;
			this.labelBuyCash.Text = SK.Text("ManageCandsPanel_Get_Cards", "Get Cards");
			this.labelBuyCash.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.labelBuyCash.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.labelBuyCash.Color = global::ARGBColors.Black;
			this.LabelClickToRemove = new CustomSelfDrawPanel.CSDLabel();
			this.LabelClickToRemove.Position = new Point(this.AvailablePanel.X, this.cardsButtons.Y);
			this.LabelClickToRemove.Size = new Size(600, 18);
			this.LabelClickToRemove.Text = "";
			this.LabelClickToRemove.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.LabelClickToRemove.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.LabelClickToRemove.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.LabelClickToRemove);
			this.buttonCatalog.addControl(this.labelBuyCash);
			this.buttonCatalog.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.SwitchToBuy), "ManageCardsPanel_switch_to_buy_cards");
			if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count < 5)
			{
				this.buttonCash.Colorise = global::ARGBColors.Gray;
				this.buttonCash.setMouseOverDelegate(null, null);
				this.buttonCash.setClickDelegate(null);
			}
			else
			{
				this.buttonCash.Colorise = global::ARGBColors.White;
				this.buttonCash.setMouseOverDelegate(delegate
				{
					this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_over;
				}, delegate
				{
					this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_normal;
				});
				this.buttonCash.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.CashClick), "ManageCardsPanel_switch_to_cash_in");
			}
			this.LayoutPanelMode = (this.PanelMode = ManageCardsPanel.PANEL_MODE_CASH);
			CardTypes.CardDefinition filter = new CardTypes.CardDefinition();
			GameEngine.Instance.cardsManager.searchProfileCards(filter, "", ((PlayCardsWindow)base.ParentForm).getNameSearchText());
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
			this.ResizeAvailable(375);
			this.GetCardsAvailable(false);
			this.RenderCards(this.UICardList);
			this.InitEmptyCards();
			this.InitDynamicPanel();
			this.RefreshSet();
			this.CatalogFilterDefinition.cardCategory = 0;
			this.CatalogFilterDefinition.cardColour = 0;
			this.InitCatalog();
			CustomSelfDrawPanel.CSDControl csdcontrol = new CustomSelfDrawPanel.CSDControl();
			csdcontrol.Position = new Point(0, 0);
			csdcontrol.Size = base.Size;
			this.mainBackgroundImage.addControl(csdcontrol);
			this.mainBackgroundImage.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelHandler));
			this.InitFilters();
			this.InitTabs();
			this.mainBackgroundImage.invalidate();
			GameEngine.shiftPressedAlways = false;
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00183C10 File Offset: 0x00181E10
		private void InitTabs()
		{
			this.TabSelector.Image = GFXLibrary.cardpanel_manage_tabs_white_left;
			this.TabSelector.Size = this.TabSelector.Image.Size;
			this.TabSelector.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - this.TabSelector.Width, this.DynamicPanel.Y - this.TabSelector.Height + 6);
			this.mainBackgroundImage.addControl(this.TabSelector);
			this.TabCashArea.Position = new Point(79, 0);
			this.TabCashArea.Size = new Size(118, 30);
			this.TabCashArea.CustomTooltipID = 10103;
			this.TabSelector.addControl(this.TabCashArea);
			this.TabBuyArea.Position = new Point(196, 0);
			this.TabBuyArea.Size = new Size(118, 30);
			this.TabBuyArea.CustomTooltipID = 10104;
			this.TabSelector.addControl(this.TabBuyArea);
			this.TabSelector.ClickArea = new Rectangle(196, 0, 118, 30);
			this.TabSelector.setClickDelegate(delegate()
			{
				if (!this.cashingIn && !this.buyingCard)
				{
					if (this.PanelMode == ManageCardsPanel.PANEL_MODE_CASH)
					{
						GameEngine.Instance.playInterfaceSound("ManageCardsPanel_switch_to_buy_cards");
						this.SwitchToBuy();
						this.TabSelector.Image = GFXLibrary.cardpanel_manage_tabs_white_right;
						this.TabSelector.ClickArea = new Rectangle(79, 0, 118, 30);
						return;
					}
					GameEngine.Instance.playInterfaceSound("ManageCardsPanel_switch_to_cash_in");
					this.SwitchToCash();
					this.TabSelector.Image = GFXLibrary.cardpanel_manage_tabs_white_left;
					this.TabSelector.ClickArea = new Rectangle(196, 0, 118, 30);
				}
			});
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00183D70 File Offset: 0x00181F70
		private void InitFilters()
		{
			foreach (CustomSelfDrawPanel.CSDButton control in this.FilterButtons)
			{
				this.mainBackgroundImage.removeControl(control);
			}
			this.FilterButtons.Clear();
			int num = 0;
			if (GameEngine.Instance.cardsManager.lastUserCardSearchCriteria != null)
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
					return;
				}
				this.addFilterButton(524288, GFXLibrary.CardFilters_Parish, num2++, num);
			}
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00019558 File Offset: 0x00017758
		private void addFilterButton(int category, BaseImage[] buttonImage, int index, int currentFilter)
		{
			this.addFilterButton(category, buttonImage[GFXLibrary.ButtonStateNormal], buttonImage[GFXLibrary.ButtonStateOver], buttonImage[GFXLibrary.ButtonStatePressed], index, currentFilter);
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00184668 File Offset: 0x00182868
		private void addFilterButton(int category, BaseImage normalImage, BaseImage overImage, BaseImage clickedImage, int index, int currentFilter)
		{
			int num = 23;
			int num2 = 3;
			if (GameEngine.Instance.cardsManager.NewCategoriesAvailable_FullHeight)
			{
				num = 21;
				num2 = 4;
			}
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
				csdbutton.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - 84, this.AvailablePanel.Y + num2 + index * num);
			}
			else
			{
				csdbutton.ImageNorm = normalImage;
				csdbutton.ImageOver = overImage;
				csdbutton.ImageClick = clickedImage;
				csdbutton.Data = category;
				csdbutton.CustomTooltipData = category;
				csdbutton.CustomTooltipID = 10105;
				csdbutton.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - 84, this.AvailablePanel.Y + num2 + index * num);
				csdbutton.ClipRect = new Rectangle(0, 6, 51, 22);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.NewFilterClick), "PlayCardsPanel_filter");
			}
			this.FilterButtons.Add(csdbutton);
			this.mainBackgroundImage.addControl(csdbutton);
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x001847E0 File Offset: 0x001829E0
		public void NewFilterClick()
		{
			if (this.cashingIn || this.buyingCard)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_CASH)
			{
				CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
				cardDefinition.newCardCategoryFilter = data;
				this.CatalogFilterDefinition = new CardTypes.CardDefinition();
				this.CatalogFilterDefinition.newCardCategoryFilter = data;
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
				GameEngine.Instance.cardsManager.searchProfileCards(cardDefinition, "", ((PlayCardsWindow)base.ParentForm).getNameSearchText());
				this.SwitchToCash();
			}
			else if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
			{
				this.CatalogFilterDefinition = new CardTypes.CardDefinition();
				this.CatalogFilterDefinition.newCardCategoryFilter = data;
				CardTypes.CardDefinition cardDefinition2 = new CardTypes.CardDefinition();
				cardDefinition2.newCardCategoryFilter = data;
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
				GameEngine.Instance.cardsManager.lastUserCardSearchCriteria = cardDefinition2;
				GameEngine.Instance.cardsManager.lastUserCardNameFilter = ((PlayCardsWindow)base.ParentForm).getNameSearchText();
				this.SwitchToBuy();
			}
			this.clearSearchButton.Visible = ((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible;
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00184A00 File Offset: 0x00182C00
		private void searchClicked()
		{
			this.searchButton.Visible = false;
			this.clearSearchButton.Visible = true;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = true;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Focus();
			this.handleSearchTextChanged();
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00019579 File Offset: 0x00017779
		private void clearSearchClicked()
		{
			this.searchButton.Visible = true;
			this.clearSearchButton.Visible = false;
			((PlayCardsWindow)base.ParentForm).tbSearchBox.Visible = false;
			this.handleSearchTextChanged();
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00184A58 File Offset: 0x00182C58
		public void handleSearchTextChanged()
		{
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_CASH)
			{
				GameEngine.Instance.cardsManager.searchProfileCardsRedoLast(((PlayCardsWindow)base.ParentForm).getNameSearchText());
				this.SwitchToCash();
				return;
			}
			GameEngine.Instance.cardsManager.lastUserCardNameFilter = ((PlayCardsWindow)base.ParentForm).getNameSearchText();
			this.SwitchToBuy();
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00184AC0 File Offset: 0x00182CC0
		private void mouseWheelHandler(int delta)
		{
			if (((delta > 0 && this.scrollbarAvailable.Value - delta * 15 > 0) || (delta < 0 && this.scrollbarAvailable.Value - delta * 15 < this.scrollbarAvailable.Max)) && !this.cashingIn && !this.buyingCard)
			{
				this.scrollbarAvailable.Value += delta * -15;
				this.AvailableContentScroll();
			}
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00184B34 File Offset: 0x00182D34
		private void InitDynamicPanel()
		{
			this.DynamicPanel.Position = new Point((this.EmptyCards[4].X + this.EmptyCards[4].Width) / 2 - 6, this.EmptyCards[0].Y / 2);
			this.DynamicPanel.Size = new Size(this.cardsButtons.X - this.DynamicPanel.Position.X, this.EmptyCards[0].Height / 2);
			this.DynamicLabel = new CustomSelfDrawPanel.CSDLabel();
			this.DynamicLabel.Position = new Point(0, 0);
			this.DynamicLabel.Size = this.DynamicPanel.Size;
			if (!this.fastCashIn)
			{
				this.DynamicLabel.Text = this.TextEmptySet;
			}
			else
			{
				this.DynamicLabel.Text = this.TextEmptyMultiSet;
			}
			this.DynamicLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.DynamicLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.DynamicLabel.Color = global::ARGBColors.Black;
			this.DynamicPanel.addControl(this.DynamicLabel);
			this.DynamicLabel.Visible = true;
			this.DynamicButton = new CustomSelfDrawPanel.CSDImage();
			this.DynamicButton.Image = GFXLibrary.cardpanel_cashin_normal;
			this.DynamicButton.Size = this.DynamicButton.Image.Size;
			this.DynamicButton.Position = new Point(this.DynamicPanel.Width / 2 - this.DynamicButton.Width / 2, this.DynamicPanel.Height / 2 - this.DynamicButton.Height / 2);
			this.DynamicPanel.addControl(this.DynamicButton);
			this.DynamicButton.Visible = false;
			this.DynamicButton.setMouseOverDelegate(delegate
			{
				this.DynamicButton.Image = GFXLibrary.cardpanel_cashin_over;
			}, delegate
			{
				this.DynamicButton.Image = GFXLibrary.cardpanel_cashin_normal;
			});
			this.DynamicButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.CashClick), "ManageCardsPanel_switch_to_cash_in");
			this.DynamicButtonLabel = new CustomSelfDrawPanel.CSDLabel();
			this.DynamicButtonLabel.Position = new Point(119, 21);
			this.DynamicButtonLabel.Size = new Size(144, 66);
			this.DynamicButtonLabel.Text = SK.Text("ManageCandsPanel_Cash_In", "Cash In");
			this.DynamicButtonLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			if (Program.mySettings.LanguageIdent == "ru")
			{
				this.DynamicButtonLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			}
			else
			{
				this.DynamicButtonLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			}
			this.DynamicButtonLabel.Color = global::ARGBColors.Black;
			this.DynamicButtonLabel.Visible = true;
			this.DynamicButton.addControl(this.DynamicButtonLabel);
			this.mainBackgroundImage.addControl(this.DynamicPanel);
			this.InitSpinners();
		}

		// Token: 0x060018AD RID: 6317 RVA: 0x00184E3C File Offset: 0x0018303C
		private void ResizeAvailable(int height)
		{
			this.mainBackgroundImage.removeControl(this.scrollbarAvailable);
			this.mainBackgroundImage.removeControl(this.AvailablePanel);
			this.AvailablePanel.clearDirectControlsOnly();
			this.AvailablePanelContent.clearDirectControlsOnly();
			this.AvailablePanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			this.scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, height);
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - height);
			this.AvailablePanel.Alpha = 0.8f;
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			this.mainBackgroundImage.invalidate();
			this.sortBack.clearControls();
			this.sortBack.Image = GFXLibrary.sort_back;
			this.sortBack.Position = new Point(8, this.AvailablePanel.Height - 37);
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
			this.sortByName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByNameClicked), "ManageCardsPanel_sort_by_name");
			this.sortBack.addControl(this.sortByName);
			this.sortByType.ImageNorm = GFXLibrary.sort_normal;
			this.sortByType.ImageOver = GFXLibrary.sort_over;
			this.sortByType.ImageClick = GFXLibrary.sort_in;
			this.sortByType.Position = new Point(228, 4);
			this.sortByType.Text.Text = SK.Text("Card_Sorting_Type", "Sort By Type");
			this.sortByType.Text.Color = global::ARGBColors.White;
			this.sortByType.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.sortByType.TextYOffset = -1;
			this.sortByType.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sortByTypeClicked), "ManageCardsPanel_sort_by_type");
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
			this.compressButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.compressButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.compressButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.compressButton.Position = new Point(673, 16);
			this.compressButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.compressClicked), "ManageCardsPanel_compressed_cards");
			this.sortBack.addControl(this.compressButton);
			this.expandButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.expandButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.expandButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.expandButton.Position = new Point(673, -2);
			this.expandButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.expandClicked), "ManageCardsPanel_expand_cards");
			this.sortBack.addControl(this.expandButton);
			if (this.sortByMode == 0 || this.sortByMode == 2)
			{
				this.sortByName.Alpha = 0.5f;
				this.sortByType.Alpha = 1f;
				this.sortByQuantity.Alpha = 0.5f;
				return;
			}
			if (this.sortByMode == 1 || this.sortByMode == 3)
			{
				this.sortByName.Alpha = 1f;
				this.sortByType.Alpha = 0.5f;
				this.sortByQuantity.Alpha = 0.5f;
				return;
			}
			if (this.sortByMode == 7 || this.sortByMode == 8)
			{
				this.sortByName.Alpha = 0.5f;
				this.sortByType.Alpha = 0.5f;
				this.sortByQuantity.Alpha = 1f;
				return;
			}
			this.sortByName.Alpha = 1f;
			this.sortByType.Alpha = 1f;
			this.sortByQuantity.Alpha = 1f;
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x00185458 File Offset: 0x00183658
		public void SwitchToBuy()
		{
			if (this.cashingIn || this.buyingCard)
			{
				return;
			}
			this.LayoutPanelMode = ManageCardsPanel.PANEL_MODE_BUY;
			this.InitCatalog();
			this.ResizeAvailable(375);
			this.buttonCatalog.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.SwitchToCash), "ManageCardsPanel_switch_to_cash_in");
			this.RenderCards(this.CardCatalog);
			this.labelTitle.Text = SK.Text("ManageCandsPanel_Get_New_Cards_Points", "Get New Cards: Current Card Points");
			this.addPointsData();
			if (GameEngine.Instance.World.FakeCardPoints > 0)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitlePoints;
				csdlabel.Text = csdlabel.Text + " (+" + GameEngine.Instance.World.FakeCardPoints.ToString() + ")";
			}
			this.DynamicButton.Visible = false;
			this.DynamicButtonLabel.Visible = false;
			this.DynamicLabel.Visible = true;
			this.fastCashInCheckBox.Visible = false;
			if (this.failedPurchaseCard != -1)
			{
				int profileCardpoints = GameEngine.Instance.World.ProfileCardpoints;
				int num = this.failedPurchaseCost;
				foreach (UICard uicard in this.ShoppingCart)
				{
					num += uicard.Definition.cardPoints;
				}
				if (num <= profileCardpoints)
				{
					GameEngine.Instance.cardsManager.ShoppingCartCards.Add(this.failedPurchaseCard);
					this.failedPurchaseCard = -1;
					this.failedPurchaseCost = -1;
				}
			}
			this.RefreshCart();
			CustomSelfDrawPanel.CSDImage[] emptyCards = this.EmptyCards;
			foreach (CustomSelfDrawPanel.CSDImage csdcontrol in emptyCards)
			{
				csdcontrol.Visible = false;
			}
			UICard[] setCards = this.SetCards;
			foreach (UICard uicard2 in setCards)
			{
				uicard2.Visible = false;
			}
			this.buttonCatalog.Colorise = global::ARGBColors.Gray;
			this.buttonCatalog.setMouseOverDelegate(null, null);
			this.buttonCatalog.setClickDelegate(null);
			this.buttonCash.Colorise = global::ARGBColors.White;
			this.buttonCash.setMouseOverDelegate(delegate
			{
				this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_over;
			}, delegate
			{
				this.buttonCash.Image = GFXLibrary.cardpanel_button_blue_normal;
			});
			this.buttonCash.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.SwitchToCash), "ManageCardsPanel_switch_to_cash_in");
			if (GameEngine.Instance.World.getTutorialStage() != 102)
			{
				this.InitFilters();
			}
			else
			{
				foreach (CustomSelfDrawPanel.CSDButton control in this.FilterButtons)
				{
					this.mainBackgroundImage.removeControl(control);
				}
				this.FilterButtons.Clear();
			}
			this.PanelMode = ManageCardsPanel.PANEL_MODE_BUY;
			this.buyAndPlayCheckBox.Visible = (this.ShoppingCart.Count == 1 && GameEngine.Instance.World.getTutorialStage() != 102);
			this.buyAndPlayCheckBox.Checked = false;
			this.sortByQuantity.Text.Text = SK.Text("Card_Sorting_Price", "Sort By Price");
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x001857A4 File Offset: 0x001839A4
		private void addPointsData()
		{
			Graphics graphics = base.CreateGraphics();
			Size size = graphics.MeasureString(this.labelTitle.Text, this.labelTitle.Font, 1000).ToSize();
			graphics.Dispose();
			this.imageTitlePoints.Position = new Point(this.labelTitle.X + size.Width + 5, 5);
			this.labelTitlePoints.Position = new Point(this.labelTitle.X + size.Width + 35, this.labelTitle.Y);
			this.labelTitlePoints.Text = GameEngine.Instance.World.ProfileCardpoints.ToString();
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00185860 File Offset: 0x00183A60
		private void SwitchToCash()
		{
			if (!this.cashingIn && !this.buyingCard)
			{
				this.LayoutPanelMode = ManageCardsPanel.PANEL_MODE_CASH;
				GameEngine.Instance.cardsManager.searchProfileCardsRedoLast();
				this.ResizeAvailable(375);
				this.GetCardsAvailable(false);
				this.RenderCards(this.UICardList);
				this.InitEmptyCards();
				this.RefreshSet();
				this.InitSpinners();
				this.buttonCatalog.Position = new Point(this.buttonCash.X - this.buttonCash.Width, this.buttonCash.Y);
				this.buttonCatalog.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.SwitchToBuy), "ManageCardsPanel_switch_to_buy_cards");
				this.labelBuyCash.Text = SK.Text("ManageCandsPanel_Get_Cards", "Get Cards");
				this.labelTitle.Text = SK.Text("ManageCandsPanel_Cash_In_Card_Points", "Cash in Cards: Current Card Points");
				this.addPointsData();
				if (GameEngine.Instance.World.FakeCardPoints > 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitlePoints;
					csdlabel.Text = csdlabel.Text + " (+" + GameEngine.Instance.World.FakeCardPoints.ToString() + ")";
				}
				foreach (UICard uicard in this.ShoppingCart)
				{
					uicard.Visible = false;
				}
				this.fastCashInCheckBox.Visible = true;
				this.buttonCash.Colorise = global::ARGBColors.Gray;
				this.buttonCash.setMouseOverDelegate(null, null);
				this.buttonCash.setClickDelegate(null);
				this.buttonCatalog.Colorise = global::ARGBColors.White;
				this.buttonCatalog.setMouseOverDelegate(delegate
				{
					this.buttonCatalog.Image = GFXLibrary.cardpanel_button_blue_over;
				}, delegate
				{
					this.buttonCatalog.Image = GFXLibrary.cardpanel_button_blue_normal;
				});
				this.buttonCatalog.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.SwitchToBuy), "ManageCardsPanel_switch_to_buy_cards");
				this.InitFilters();
				this.PanelMode = ManageCardsPanel.PANEL_MODE_CASH;
				this.buyAndPlayCheckBox.Visible = false;
				this.sortByQuantity.Text.Text = SK.Text("Card_Sorting_Quantity", "Sort By Quantity");
			}
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x00185AA4 File Offset: 0x00183CA4
		private void InitCatalog()
		{
			if (GameEngine.Instance.World.getTutorialStage() == 102)
			{
				if (this.CardCatalog != null)
				{
					foreach (UICard uicard in this.CardCatalog)
					{
						uicard.clearControls();
						if (uicard.Parent != null)
						{
							uicard.Parent.removeControl(uicard);
						}
					}
				}
				this.CardCatalog.Clear();
				this.CardCatalog = new List<UICard>();
				UICard uicard2 = this.makeUICard(CardTypes.getCardDefinition(3113), 0, GameEngine.Instance.World.getRank() + 1);
				GFXLibrary.Instance.closeBigCardsLoader();
				this.CardCatalog.Add(uicard2);
				uicard2.countLabel.Text = uicard2.Definition.cardPoints.ToString();
				if (uicard2.Definition.cardPoints >= 100)
				{
					uicard2.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
				}
				uicard2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickCardCart), "ManageCardsPanel_purchase_card");
			}
			else
			{
				string nameSearchText = ((PlayCardsWindow)base.ParentForm).getNameSearchText();
				if (this.CardCatalog != null)
				{
					foreach (UICard uicard3 in this.CardCatalog)
					{
						uicard3.clearControls();
						if (uicard3.Parent != null)
						{
							uicard3.Parent.removeControl(uicard3);
						}
					}
				}
				this.CardCatalog.Clear();
				this.CardCatalog = new List<UICard>();
				CardTypes.CardDefinition[] cardList = CardTypes.cardList;
				foreach (CardTypes.CardDefinition cardDefinition in cardList)
				{
					if (cardDefinition.cardRank > 0 && cardDefinition.cardRarity > 0 && cardDefinition.available == 1 && cardDefinition.cardPoints > 0 && (this.CatalogFilterDefinition.cardCategory == 0 || this.CatalogFilterDefinition.cardCategory == cardDefinition.cardCategory) && (this.CatalogFilterDefinition.cardColour == 0 || this.CatalogFilterDefinition.cardColour == cardDefinition.cardColour) && (this.CatalogFilterDefinition.newCardCategoryFilter == 0 || CardTypes.isCardInNewCategory(cardDefinition.id, this.CatalogFilterDefinition.newCardCategoryFilter)) && (nameSearchText.Length == 0 || CardTypes.containsName(cardDefinition.id, nameSearchText)))
					{
						UICard uicard4 = this.makeUICard(cardDefinition, 0, GameEngine.Instance.World.getRank() + 1);
						this.CardCatalog.Add(uicard4);
						uicard4.countLabel.Text = uicard4.Definition.cardPoints.ToString();
						if (uicard4.Definition.cardPoints >= 100)
						{
							uicard4.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
						}
						uicard4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickCardCart), "ManageCardsPanel_purchase_card");
					}
				}
				GFXLibrary.Instance.closeBigCardsLoader();
			}
			this.CardCatalog.Sort(delegate(UICard card1, UICard card2)
			{
				if (card1.Definition.cardPoints == card2.Definition.cardPoints)
				{
					return CardTypes.getDescriptionFromCard(card1.Definition.id).CompareTo(CardTypes.getDescriptionFromCard(card2.Definition.id));
				}
				return card1.Definition.cardPoints.CompareTo(card2.Definition.cardPoints);
			});
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x00185E0C File Offset: 0x0018400C
		private void ClickBuyMultiple()
		{
			if (GameEngine.Instance.World.WorldEnded || this.cashingIn || this.buyingCard)
			{
				return;
			}
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest();
			xmlRpcCardsRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			xmlRpcCardsRequest.WorldID = RemoteServices.Instance.ProfileWorldID.ToString();
			xmlRpcCardsRequest.CardString = "";
			if (GameEngine.Instance.World.getTutorialStage() == 102)
			{
				xmlRpcCardsRequest.CardPoints = new int?(1);
			}
			this.newcardcost = 0;
			for (int i = 0; i < this.ShoppingCart.Count; i++)
			{
				XmlRpcCardsRequest xmlRpcCardsRequest2 = xmlRpcCardsRequest;
				xmlRpcCardsRequest2.CardString += this.ShoppingCart[i].Definition.name;
				this.newcardcost += this.ShoppingCart[i].Definition.cardPoints;
				if (i < this.ShoppingCart.Count - 1)
				{
					XmlRpcCardsRequest xmlRpcCardsRequest3 = xmlRpcCardsRequest;
					xmlRpcCardsRequest3.CardString += ",";
				}
			}
			this.newcardnames = xmlRpcCardsRequest.CardString;
			xmlRpcCardsProvider.buyMultipleCards(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.MultipleCallback), this);
			this.buyingCard = true;
			this.cardsButtons.Available = false;
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x00185FC4 File Offset: 0x001841C4
		private void MultipleCallback(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				string text = response.Strings.TrimEnd(",".ToCharArray());
				string[] array = this.newcardnames.Split(",".ToCharArray());
				string[] array2 = text.Split(",".ToCharArray());
				for (int i = 0; i < array.Length; i++)
				{
					int key = Convert.ToInt32(array2[array.Length - 1 - i].Trim());
					GameEngine.Instance.cardsManager.ProfileCards.Add(key, CardTypes.getCardDefinitionFromString(array[i].Trim()));
					if (GameEngine.Instance.cardsManager.ProfileCards[key].id == 3113)
					{
						GameEngine.Instance.World.handleQuestObjectiveHappening(10007);
					}
				}
				if (GameEngine.Instance.World.getTutorialStage() == 102)
				{
					GameEngine.Instance.World.FakeCardPoints = 0;
				}
				else
				{
					GameEngine.Instance.World.ProfileCardpoints -= this.newcardcost;
				}
				this.labelTitle.Text = SK.Text("ManageCandsPanel_Get_New_Cards_Points", "Get New Cards: Current Card Points");
				this.addPointsData();
				if (GameEngine.Instance.World.FakeCardPoints > 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitlePoints;
					csdlabel.Text = csdlabel.Text + " (+" + GameEngine.Instance.World.FakeCardPoints.ToString() + ")";
				}
				if (GameEngine.Instance.World.getTutorialStage() == 102)
				{
					this.closeClick();
				}
				if (array2.Length == 1 && this.buyAndPlayCheckBox.Checked)
				{
					int userID = Convert.ToInt32(array2[0].Trim());
					this.autoPlayCard(userID, CardTypes.getCardDefinitionFromString(array[0].Trim()), true, false);
				}
			}
			else
			{
				MyMessageBox.Show(response.Message, SK.Text("GENERIC_Error", "Error"));
			}
			this.cardsButtons.Available = true;
			this.buyingCard = false;
			GameEngine.Instance.cardsManager.ShoppingCartCards.Clear();
			this.RefreshCart();
			this.LabelClickToRemove.Text = "";
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x0018620C File Offset: 0x0018440C
		private void InitSpinners()
		{
			this.DynamicPanel.removeControl(this.SlotHolder);
			this.SlotHolder = new CustomSelfDrawPanel.CSDImage();
			this.SlotHolder.Image = GFXLibrary.CardSlotFrame;
			this.SlotHolder.Position = new Point(this.DynamicPanel.Width / 2 - this.SlotHolder.Width / 2, this.DynamicPanel.Height / 2 - this.SlotHolder.Height / 2);
			this.SlotHolder.Size = GFXLibrary.CardSlotFrame.Size;
			this.DynamicPanel.addControl(this.SlotHolder);
			this.SlotHolder.Visible = false;
			for (int i = 0; i < this.SlotAnims.Length; i++)
			{
				this.SlotHolder.removeControl(this.SlotAnims[i]);
				this.SlotAnims[i] = new CustomSelfDrawPanel.CSDImageAnim();
				this.SlotAnims[i].Position = new Point(11 + i * 61, 11);
				this.SlotAnims[i].SetFrames(GFXLibrary.CardSlotAnimFrames);
				this.SlotAnims[i].Size = GFXLibrary.CardSlotAnimFrames[0].Size;
				this.SlotAnims[i].FrameData = GFXLibrary.CardSlotAnimData;
				this.SlotAnims[i].Playing = false;
				this.SlotHolder.addControl(this.SlotAnims[i]);
				this.SlotAnims[i].Visible = false;
			}
			for (int j = 0; j < this.SymbolScrollers.Length; j++)
			{
				this.DynamicPanel.removeControl(this.SymbolScrollers[j]);
				this.SymbolScrollers[j] = new CustomSelfDrawPanel.CSDVertImageScroller();
				this.SymbolScrollers[j].init(new Point(j * (GFXLibrary.cardpanel_symbol_crown.Width - 10), 0), new BaseImage[]
				{
					GFXLibrary.cardpanel_symbol_apple,
					GFXLibrary.cardpanel_symbol_crown,
					GFXLibrary.cardpanel_symbol_hawk,
					GFXLibrary.cardpanel_symbol_jester,
					GFXLibrary.cardpanel_symbol_shield,
					GFXLibrary.cardpanel_symbol_tower,
					GFXLibrary.cardpanel_symbol_wolf
				}, new int[]
				{
					16777216,
					1073741824,
					67108864,
					536870912,
					134217728,
					268435456,
					33554432
				});
				this.DynamicPanel.addControl(this.SymbolScrollers[j]);
				this.SymbolScrollers[j].Visible = false;
			}
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x00186450 File Offset: 0x00184650
		private void CashClick()
		{
			if (GameEngine.Instance.World.WorldEnded || this.cashingIn || this.buyingCard)
			{
				return;
			}
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest();
			xmlRpcCardsRequest.UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", "");
			xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
			string text = "";
			this.NumCardsCachingIn = 0;
			UICard[] setCards = this.SetCards;
			foreach (UICard uicard in setCards)
			{
				if (uicard.Visible)
				{
					if (text.Length > 0)
					{
						text += ",";
					}
					text += uicard.UserID.ToString();
					this.NumCardsCachingIn++;
				}
			}
			xmlRpcCardsRequest.CardString = text;
			xmlRpcCardsProvider.cashInCards(xmlRpcCardsRequest, new CardsEndResponseDelegate(this.CashClickCallback), this);
			for (int j = 0; j < this.SlotAnims.Length; j++)
			{
				this.SlotAnims[j].Visible = true;
				this.SlotAnims[j].Playing = !this.fastCashIn;
			}
			this.SlotHolder.Visible = true;
			this.cashingIn = true;
			this.lastCashResponse = null;
			this.cardsButtons.Available = false;
			this.spinspeed = 64;
			this.spinstart = DateTime.Now;
			if (!this.fastCashIn && !this.playingSpinSound)
			{
				this.playingSpinSound = true;
				GameEngine.Instance.playInterfaceSound("CardSpinners_spin");
				for (int k = 0; k < 5; k++)
				{
					this.spinSoundStopPlayed[k] = false;
				}
				this.spinSoundSoundID = 1;
			}
			this.mainBackgroundImage.invalidate();
			this.DynamicLabel.Visible = false;
		}

		// Token: 0x060018B6 RID: 6326 RVA: 0x0018665C File Offset: 0x0018485C
		private void CashClickCallback(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				StatTrackingClient.Instance().ActivateTrigger(19, null);
				foreach (int key in GameEngine.Instance.cardsManager.ProfileCardsSet)
				{
					GameEngine.Instance.cardsManager.ProfileCards.Remove(key);
				}
				GameEngine.Instance.cardsManager.ProfileCardsSet.Clear();
				this.fastCashInCheckBox.Enabled = true;
				this.lastCashResponse = (XmlRpcCardsResponse)response;
				GameEngine.Instance.World.ProfileCardpoints += response.Newpoints.Value;
				return;
			}
			MyMessageBox.Show(response.Message, SK.Text("GENERIC_Error", "Error"));
			this.GetCardsAvailable(true);
			int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
			this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
			this.cashingIn = false;
			this.cardsButtons.Available = true;
			this.InitEmptyCards();
			this.RefreshSet();
			this.InitSpinners();
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x001867D4 File Offset: 0x001849D4
		private void ClickCardUnset()
		{
			if (!this.cashingIn && !this.buyingCard)
			{
				if (GameEngine.shiftPressedAlways)
				{
					GameEngine.Instance.cardsManager.ProfileCardsSet.Clear();
				}
				else
				{
					UICard uicard = (UICard)this.ClickedControl;
					GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(uicard.UserID);
				}
				this.GetCardsAvailable(true);
				int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
				this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
				this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
				this.RefreshSet();
				this.LabelClickToRemove.Text = "";
				if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count > 5)
				{
					this.fastCashInCheckBox.Enabled = false;
					return;
				}
				this.fastCashInCheckBox.Enabled = true;
			}
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x000195AF File Offset: 0x000177AF
		private void ClickCardSet()
		{
			this.ClickCardSet(true);
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x001868D0 File Offset: 0x00184AD0
		private void ClickCardSet(bool initialCall)
		{
			if (this.cashingIn || this.buyingCard)
			{
				return;
			}
			if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count < 5 || (GameEngine.Instance.cardsManager.ProfileCardsSet.Count < 60 && this.fastCashIn))
			{
				UICard uicard = (UICard)this.ClickedControl;
				if (uicard.cardCount > 1 && uicard.UserIDList.Count > 1)
				{
					int num = uicard.UserIDList[0];
					if (GameEngine.Instance.cardsManager.ProfileCards[num].rewardcard)
					{
						GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set_error");
						MyMessageBox.Show(SK.Text("ManageCandsPanel_Cannot_Cash_Rewards", "You cannot cash in reward cards."), SK.Text("GENERIC_Error", "Error"));
					}
					else
					{
						uicard.UserIDList.Remove(num);
						uicard.cardCount--;
						if (uicard.cardCount > 1)
						{
							uicard.countLabel.Text = uicard.cardCount.ToString();
							if (uicard.cardCount >= 100)
							{
								uicard.countLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
							}
							else
							{
								uicard.countLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
							}
						}
						else
						{
							uicard.countLabel.Text = "";
						}
						this.AvailablePanelContent.invalidate();
						uicard.UserID = uicard.UserIDList[0];
						if (!GameEngine.Instance.cardsManager.ProfileCardsSet.Contains(num))
						{
							if (initialCall)
							{
								GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set");
							}
							if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count >= 5)
							{
								int index = GameEngine.Instance.cardsManager.ProfileCardsSet.Count % 5;
								int item = GameEngine.Instance.cardsManager.ProfileCardsSet[index];
								GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(item);
								GameEngine.Instance.cardsManager.ProfileCardsSet.Insert(index, num);
								GameEngine.Instance.cardsManager.ProfileCardsSet.Add(item);
							}
							else
							{
								GameEngine.Instance.cardsManager.ProfileCardsSet.Add(num);
							}
							if (GameEngine.shiftPressedAlways)
							{
								this.ClickCardSet(false);
							}
						}
						else
						{
							MyMessageBox.Show(SK.Text("ManageCandsPanel_Already_In_Set", "It appears that card is already in the set."), SK.Text("GENERIC_Error", "Error"));
						}
					}
				}
				else if (uicard.UserIDList.Count > 0 && GameEngine.Instance.cardsManager.ProfileCards[uicard.UserIDList[0]].rewardcard)
				{
					GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set_error");
					MyMessageBox.Show(SK.Text("ManageCandsPanel_Cannot_Cash_Rewards", "You cannot cash in reward cards."), SK.Text("GENERIC_Error", "Error"));
				}
				else
				{
					this.UICardList.Remove(uicard);
					int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
					this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
					this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
					if (uicard.UserIDList.Count > 0)
					{
						uicard.UserID = uicard.UserIDList[0];
						int item2 = uicard.UserIDList[0];
						if (!GameEngine.Instance.cardsManager.ProfileCardsSet.Contains(item2))
						{
							GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set");
							if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count >= 5)
							{
								int index2 = GameEngine.Instance.cardsManager.ProfileCardsSet.Count % 5;
								int item3 = GameEngine.Instance.cardsManager.ProfileCardsSet[index2];
								GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(item3);
								GameEngine.Instance.cardsManager.ProfileCardsSet.Insert(index2, item2);
								GameEngine.Instance.cardsManager.ProfileCardsSet.Add(item3);
							}
							else
							{
								GameEngine.Instance.cardsManager.ProfileCardsSet.Add(item2);
							}
						}
						else
						{
							GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set_error");
							MyMessageBox.Show(SK.Text("ManageCandsPanel_Already_In_Set", "It appears that card is already in the set."), SK.Text("GENERIC_Error", "Error"));
						}
					}
					else
					{
						GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set_error");
						MyMessageBox.Show(SK.Text("ManageCandsPanel_Not_Own_Card", "It appears you do not own that card."), SK.Text("GENERIC_Error", "Error"));
					}
				}
				if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count > 5)
				{
					this.fastCashInCheckBox.Enabled = false;
				}
				else
				{
					this.fastCashInCheckBox.Enabled = true;
				}
				this.RefreshSet();
				return;
			}
			GameEngine.Instance.playInterfaceSound("ManageCardsPanel_cash_in_card_set_full_error");
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x00186DDC File Offset: 0x00184FDC
		private void RefreshCart()
		{
			foreach (UICard control in this.ShoppingCart)
			{
				this.mainBackgroundImage.removeControl(control);
			}
			this.ShoppingCart.Clear();
			int num = 0;
			int num2 = 0;
			foreach (int cardType in GameEngine.Instance.cardsManager.ShoppingCartCards)
			{
				UICard newcard = this.makeUICard(CardTypes.getCardDefinition(cardType), num, GameEngine.Instance.World.getRank() + 1);
				newcard.setMouseOverDelegate(delegate
				{
					this.LabelClickToRemove.Text = this.TextRemove + CardTypes.getDescriptionFromCard(newcard.Definition.id);
					newcard.MouseOver();
				}, delegate
				{
					this.LabelClickToRemove.Text = "";
					newcard.MouseOut();
				});
				this.mainBackgroundImage.addControl(newcard);
				newcard.ScaleAll(0.5);
				newcard.Position = new Point(Convert.ToInt32(Math.Floor((double)this.EmptyCards[0].X * 0.5)) + num * 16, Convert.ToInt32(Math.Floor((double)this.EmptyCards[0].Y * 0.5)));
				newcard.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickCardUncart), "ManageCardsPanel_un_purchase_card");
				newcard.Visible = true;
				this.ShoppingCart.Add(newcard);
				num++;
				num2 += newcard.Definition.cardPoints;
			}
			GFXLibrary.Instance.closeBigCardsLoader();
			if (this.ShoppingCart.Count == 0)
			{
				this.DynamicLabel.Color = global::ARGBColors.Black;
				this.DynamicLabel.setClickDelegate(null);
				this.DynamicLabel.setMouseOverDelegate(null, null);
				this.DynamicLabel.Text = this.TextCartEmpty;
				this.DynamicButton.Visible = false;
				this.DynamicButtonLabel.Visible = false;
				this.DynamicLabel.Visible = true;
			}
			else
			{
				this.DynamicLabel.setClickDelegate(null);
				this.DynamicLabel.setMouseOverDelegate(null, null);
				this.DynamicLabel.Text = "";
				this.DynamicLabel.Text = string.Concat(new string[]
				{
					Environment.NewLine,
					Environment.NewLine,
					Environment.NewLine,
					Environment.NewLine,
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("ManageCandsPanel_Cards_Points_Value", "Card Point Value"),
					" : ",
					num2.ToString()
				});
				this.DynamicButton.Visible = true;
				this.DynamicButtonLabel.Visible = true;
				this.DynamicButtonLabel.Text = SK.Text("ManageCandsPanel_Get_Cards", "Get Cards");
				this.DynamicButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickBuyMultiple), "ManageCardsPanel_get_cards");
			}
			this.buyAndPlayCheckBox.Visible = (this.ShoppingCart.Count == 1 && GameEngine.Instance.World.getTutorialStage() != 102);
			this.buyAndPlayCheckBox.Checked = false;
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x0018717C File Offset: 0x0018537C
		private void ClickCardUncart()
		{
			this.LabelClickToRemove.Text = "";
			UICard uicard = (UICard)this.ClickedControl;
			GameEngine.Instance.cardsManager.ShoppingCartCards.RemoveAt(uicard.UserID);
			this.RefreshCart();
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x001871C8 File Offset: 0x001853C8
		private void ClickCardCart()
		{
			UICard uicard = (UICard)this.ClickedControl;
			this.addCardToCard(uicard.Definition.id, true);
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x001871F4 File Offset: 0x001853F4
		public void addCardToCard(int cardType, bool showMessages)
		{
			CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(cardType);
			int num = 0;
			foreach (UICard uicard in this.ShoppingCart)
			{
				num += uicard.Definition.cardPoints;
			}
			num += cardDefinition.cardPoints;
			int num2 = (GameEngine.Instance.World.getTutorialStage() != 102) ? GameEngine.Instance.World.ProfileCardpoints : GameEngine.Instance.World.FakeCardPoints;
			if (num > num2)
			{
				this.failedPurchaseCard = cardType;
				this.failedPurchaseCost = cardDefinition.cardPoints;
				if (showMessages)
				{
					bool flag = MyMessageBox.Show(SK.Text("ManageCandsPanel_Not_Enough_Points", "That would cost more Card Points than you currently have. Would you like to trade existing cards for more points?"), SK.Text("ManageCandsPanel_Not_Enough_Points_Heading", "Not Enough Card Points"), MessageBoxButtons.YesNo) == DialogResult.Yes;
					StatTrackingClient.Instance().ActivateTrigger(18, flag);
					StatTrackingClient.Instance().ActivateTrigger(22, cardType);
					if (flag)
					{
						this.SwitchToCash();
						this.TabSelector.Image = GFXLibrary.cardpanel_manage_tabs_white_left;
						this.TabSelector.ClickArea = new Rectangle(196, 0, 118, 30);
					}
				}
				if (GameEngine.Instance.World.getTutorialStage() == 102)
				{
					GameEngine.Instance.World.handleQuestObjectiveHappening(10007);
					return;
				}
			}
			else if (GameEngine.Instance.cardsManager.ShoppingCartCards.Count > 24)
			{
				if (showMessages)
				{
					MyMessageBox.Show(SK.Text("ManageCandsPanel_Cards_Limit", "You may only buy up to 25 cards at a time."), SK.Text("ManageCandsPanel_Cards_Limit_Heading", "Maximum Reached"));
					return;
				}
			}
			else
			{
				StatTrackingClient.Instance().ActivateTrigger(20, cardType);
				GameEngine.Instance.cardsManager.ShoppingCartCards.Add(cardType);
				this.RefreshCart();
			}
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x001873D8 File Offset: 0x001855D8
		private void RefreshSet()
		{
			for (int i = 59; i >= 0; i--)
			{
				if (this.SetCards[i] != null)
				{
					this.mainBackgroundImage.removeControl(this.SetCards[i]);
				}
				if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count > i)
				{
					this.SetCards[i] = this.makeUICard(GameEngine.Instance.cardsManager.ProfileCards[GameEngine.Instance.cardsManager.ProfileCardsSet[i]], GameEngine.Instance.cardsManager.ProfileCardsSet[i], GameEngine.Instance.World.getRank() + 1);
					this.mainBackgroundImage.addControl(this.SetCards[i]);
					this.SetCards[i].ScaleAll(0.5);
					int x = Convert.ToInt32(Math.Floor((double)this.EmptyCards[i % 5].X * 0.5)) + i / 5;
					int y = Convert.ToInt32(Math.Floor((double)this.EmptyCards[i % 5].Y * 0.5)) - i / 5 * 2;
					this.SetCards[i].Position = new Point(x, y);
					this.SetCards[i].setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickCardUnset), "ManageCardsPanel_remove_card");
					UICard deelgatecard = this.SetCards[i];
					this.SetCards[i].setMouseOverDelegate(delegate
					{
						this.LabelClickToRemove.Text = this.TextRemoveSet + CardTypes.getDescriptionFromCard(deelgatecard.Definition.id);
						deelgatecard.MouseOver();
					}, delegate
					{
						this.LabelClickToRemove.Text = "";
						deelgatecard.MouseOut();
					});
					this.SetCards[i].Visible = true;
					if (i < 5)
					{
						this.EmptyCards[i].Visible = false;
					}
				}
				else
				{
					this.SetCards[i].Visible = false;
					if (i < 5)
					{
						this.EmptyCards[i].Visible = true;
					}
				}
			}
			GFXLibrary.Instance.closeBigCardsLoader();
			this.labelTitle.Text = SK.Text("ManageCandsPanel_Cash_In_Cards_Title", "Cash in Cards: Current Card Points");
			this.addPointsData();
			if (GameEngine.Instance.World.FakeCardPoints > 0)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitlePoints;
				csdlabel.Text = csdlabel.Text + " (+" + GameEngine.Instance.World.FakeCardPoints.ToString() + ")";
			}
			this.DynamicLabel.Text = this.TextCash;
			this.DynamicLabel.Color = global::ARGBColors.Black;
			this.DynamicLabel.setClickDelegate(null);
			this.DynamicLabel.setMouseOverDelegate(null, null);
			this.DynamicLabel.Visible = true;
			this.DynamicButton.Visible = false;
			if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count == 0)
			{
				if (!this.fastCashIn)
				{
					this.DynamicLabel.Text = this.TextEmptySet;
				}
				else
				{
					this.DynamicLabel.Text = this.TextEmptyMultiSet;
				}
			}
			else if (GameEngine.Instance.cardsManager.ProfileCardsSet.Count >= 5)
			{
				this.DynamicLabel.Text = this.TextCash;
				this.DynamicLabel.Visible = false;
				this.DynamicButton.Visible = true;
				this.DynamicButtonLabel.Visible = true;
				this.DynamicButtonLabel.Text = SK.Text("ManageCandsPanel_Cash_In", "Cash In") + " (" + GameEngine.Instance.cardsManager.ProfileCardsSet.Count.ToString() + ")";
				this.DynamicButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.CashClick), "ManageCardsPanel_cash_in_cards");
			}
			else
			{
				this.DynamicLabel.Text = this.TextIncompleteSetStart + (5 - GameEngine.Instance.cardsManager.ProfileCardsSet.Count).ToString();
			}
			this.DynamicPanel.invalidate();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x001877CC File Offset: 0x001859CC
		private void InitEmptyCards()
		{
			for (int i = 0; i < 5; i++)
			{
				if (this.EmptyCards[i] != null)
				{
					this.mainBackgroundImage.removeControl(this.EmptyCards[i]);
				}
				this.EmptyCards[i] = new CustomSelfDrawPanel.CSDImage();
				this.EmptyCards[i].Image = GFXLibrary.CardBackBig;
				this.EmptyCards[i].Size = this.EmptyCards[i].Image.Size;
				this.EmptyCards[i].Scale = 0.5;
				this.mainBackgroundImage.addControl(this.EmptyCards[i]);
				this.EmptyCards[i].Position = new Point(i * this.EmptyCards[i].Width + this.AvailablePanel.X + 8, (this.buttonCash.Y + this.buttonCash.Height) * 2 + 8);
				this.EmptyCards[i].Visible = true;
			}
			for (int j = 0; j < 60; j++)
			{
				this.SetCards[j] = new UICard();
				this.SetCards[j].Visible = false;
			}
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x001878F4 File Offset: 0x00185AF4
		private void GetCardsAvailable(bool redosearch)
		{
			if (redosearch)
			{
				GameEngine.Instance.cardsManager.searchProfileCardsRedoLast();
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int num in GameEngine.Instance.cardsManager.ProfileCardsSearch)
			{
				int id = GameEngine.Instance.cardsManager.ProfileCards[num].id;
				if (!GameEngine.Instance.cardsManager.ProfileCardsSet.Contains(num))
				{
					if (dictionary.ContainsKey(id))
					{
						Dictionary<int, int> dictionary2 = dictionary;
						int key = id;
						int num2 = dictionary2[key];
						dictionary2[key] = num2 + 1;
					}
					else
					{
						dictionary.Add(id, 1);
					}
				}
			}
			UICard uicard = null;
			foreach (UICard uicard2 in this.UICardList)
			{
				uicard2.clearControls();
				if (uicard2.Parent != null)
				{
					uicard2.Parent.removeControl(uicard2);
				}
			}
			this.UICardList.Clear();
			int num3 = GameEngine.Instance.World.getRank() + 1;
			foreach (int num4 in GameEngine.Instance.cardsManager.ProfileCardsSearch)
			{
				int id2 = GameEngine.Instance.cardsManager.ProfileCards[num4].id;
				if (dictionary.ContainsKey(id2) && !GameEngine.Instance.cardsManager.ProfileCardsSet.Contains(num4))
				{
					UICard uicard3 = new UICard();
					uicard3.cardCount = dictionary[id2];
					uicard3.UserID = num4;
					uicard3.UserIDList.Add(num4);
					uicard3.Definition = GameEngine.Instance.cardsManager.ProfileCards[num4];
					switch (uicard3.Definition.cardColour)
					{
					case 1:
						uicard3.bigFrame = GFXLibrary.BlueCardOverlayBig;
						uicard3.bigFrameOver = GFXLibrary.BlueCardOverlayBigOver;
						break;
					case 2:
						uicard3.bigFrame = GFXLibrary.GreenCardOverlayBig;
						uicard3.bigFrameOver = GFXLibrary.GreenCardOverlayBigOver;
						break;
					case 3:
						uicard3.bigFrame = GFXLibrary.PurpleCardOverlayBig;
						uicard3.bigFrameOver = GFXLibrary.PurpleCardOverlayBigOver;
						break;
					case 4:
						uicard3.bigFrame = GFXLibrary.RedCardOverlayBig;
						uicard3.bigFrameOver = GFXLibrary.RedCardOverlayBigOver;
						break;
					case 5:
						uicard3.bigFrame = GFXLibrary.YellowCardOverlayBig;
						uicard3.bigFrameOver = GFXLibrary.YellowCardOverlayBigOver;
						break;
					}
					try
					{
						uicard3.bigImage = GFXLibrary.Instance.getCardImageBig(uicard3.Definition.id);
					}
					catch (Exception)
					{
						continue;
					}
					uicard3.Size = uicard3.bigFrame.Size;
					uicard3.CustomTooltipID = 10101;
					uicard3.CustomTooltipData = uicard3.Definition.id;
					uicard3.bigGradeImage = new CustomSelfDrawPanel.CSDImage();
					int grade = CardTypes.getGrade(uicard3.Definition.cardGrade);
					if (grade <= 262144)
					{
						if (grade != 65536)
						{
							if (grade != 131072)
							{
								if (grade != 262144)
								{
									goto IL_548;
								}
								uicard3.bigGradeImage.Image = GFXLibrary.card_gold_anim[0];
								uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width - 3, 0);
							}
							else
							{
								uicard3.bigGradeImage.Image = GFXLibrary.CardGradeSilver;
								uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width, 0);
							}
						}
						else
						{
							uicard3.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
							uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width, 0);
						}
					}
					else if (grade <= 1048576)
					{
						if (grade != 524288)
						{
							if (grade != 1048576)
							{
								goto IL_548;
							}
							uicard3.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[0];
							uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width - 3, -7);
						}
						else
						{
							uicard3.bigGradeImage.Image = GFXLibrary.card_diamond_anim[0];
							uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width - 3, -2);
						}
					}
					else if (grade != 2097152)
					{
						if (grade != 4194304)
						{
							goto IL_548;
						}
						uicard3.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[0];
						uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width - 3, -12);
					}
					else
					{
						uicard3.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[0];
						uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width - 3, -10);
					}
					IL_584:
					uicard3.bigBaseImage = new CustomSelfDrawPanel.CSDImage();
					uicard3.bigBaseImage.Position = new Point(10, 11);
					uicard3.bigBaseImage.Size = uicard3.bigImage.Size;
					uicard3.bigBaseImage.Image = uicard3.bigImage;
					uicard3.addControl(uicard3.bigBaseImage);
					uicard3.bigFrameImage = new CustomSelfDrawPanel.CSDImage();
					uicard3.bigFrameImage.Position = new Point(0, 0);
					uicard3.bigFrameImage.Size = uicard3.bigFrame.Size;
					uicard3.bigFrameImage.Image = uicard3.bigFrame;
					uicard3.addControl(uicard3.bigFrameImage);
					if (grade <= 524288)
					{
						if (grade != 262144)
						{
							if (grade == 524288)
							{
								goto IL_6CB;
							}
						}
						else
						{
							uicard3.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
							uicard3.bigFrameExtraImage.Position = new Point(0, 0);
							uicard3.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_gold;
							uicard3.addControl(uicard3.bigFrameExtraImage);
						}
					}
					else
					{
						if (grade == 1048576 || grade == 2097152)
						{
							goto IL_6CB;
						}
						if (grade == 4194304)
						{
							uicard3.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
							uicard3.bigFrameExtraImage.Position = new Point(0, 0);
							uicard3.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
							uicard3.addControl(uicard3.bigFrameExtraImage);
						}
					}
					IL_753:
					uicard3.bigGradeImage.Size = uicard3.bigGradeImage.Image.Size;
					uicard3.addControl(uicard3.bigGradeImage);
					uicard3.bigTitle = new CustomSelfDrawPanel.CSDLabel();
					uicard3.bigTitle.Text = CardTypes.getDescriptionFromCard(uicard3.Definition.id);
					uicard3.bigTitle.Size = new Size(110, 48);
					uicard3.bigTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					if ((uicard3.Definition.id == 1801 || uicard3.Definition.id == 1542 || uicard3.Definition.id == 3137 || uicard3.Definition.id == 1290 || uicard3.Definition.id == 1541 || uicard3.Definition.id == 1543) && Program.mySettings.LanguageIdent == "de")
					{
						uicard3.bigTitle.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
					}
					else
					{
						uicard3.bigTitle.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					}
					uicard3.bigTitle.Color = global::ARGBColors.White;
					uicard3.bigTitle.DropShadowColor = global::ARGBColors.Black;
					uicard3.bigTitle.Position = new Point(38, 12);
					uicard3.addControl(uicard3.bigTitle);
					uicard3.bigEffect = new CustomSelfDrawPanel.CSDLabel();
					uicard3.bigEffect.Text = uicard3.Definition.EffectText;
					uicard3.bigEffect.Size = new Size(150, 64);
					uicard3.bigEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					uicard3.bigEffect.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					if (Program.mySettings.LanguageIdent == "de" && CardTypes.isGermanSmallDesc(uicard3.Definition.id))
					{
						uicard3.bigEffect.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
					}
					uicard3.bigEffect.Color = global::ARGBColors.White;
					uicard3.bigEffect.DropShadowColor = global::ARGBColors.Black;
					uicard3.bigEffect.Position = new Point(14, 174);
					uicard3.addControl(uicard3.bigEffect);
					CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
					csdlabel.Position = new Point(2, 2);
					csdlabel.Size = new Size(uicard3.Width, uicard3.Height);
					csdlabel.Text = "";
					csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					csdlabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
					csdlabel.Color = global::ARGBColors.Yellow;
					csdlabel.DropShadowColor = global::ARGBColors.Black;
					uicard3.addControl(csdlabel);
					uicard3.countLabel = csdlabel;
					if (num3 < uicard3.Definition.cardRank)
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
					csdlabel2.Text = uicard3.Definition.cardRank.ToString();
					csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					csdlabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					csdlabel2.Color = global::ARGBColors.White;
					csdlabel2.DropShadowColor = global::ARGBColors.Black;
					uicard3.addControl(csdlabel2);
					uicard3.rankLabel = csdlabel2;
					uicard3.ScaleAll(0.95);
					this.UICardList.Add(uicard3);
					dictionary.Remove(id2);
					uicard = uicard3;
					if (num3 < uicard3.Definition.cardRank)
					{
						uicard3.Hilight(global::ARGBColors.Gray);
					}
					else
					{
						uicard3.Hilight(global::ARGBColors.White);
					}
					uicard3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickCardSet));
					continue;
					IL_6CB:
					uicard3.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
					uicard3.bigFrameExtraImage.Position = new Point(0, 0);
					uicard3.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
					uicard3.addControl(uicard3.bigFrameExtraImage);
					goto IL_753;
					IL_548:
					uicard3.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
					uicard3.bigGradeImage.Position = new Point(uicard3.Width - uicard3.bigGradeImage.Width, 0);
					goto IL_584;
				}
				if (uicard != null && !GameEngine.Instance.cardsManager.ProfileCardsSet.Contains(num4))
				{
					uicard.UserIDList.Add(num4);
				}
			}
			GFXLibrary.Instance.closeBigCardsLoader();
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x0018850C File Offset: 0x0018670C
		public void setFilter(int filterGroup)
		{
			this.CatalogFilterDefinition = new CardTypes.CardDefinition();
			this.CatalogFilterDefinition.newCardCategoryFilter = filterGroup;
			CardTypes.CardDefinition cardDefinition = new CardTypes.CardDefinition();
			cardDefinition.newCardCategoryFilter = filterGroup;
			GameEngine.Instance.cardsManager.lastUserCardSearchCriteria = cardDefinition;
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x00188550 File Offset: 0x00186750
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
			if (this.sortByMode == 0)
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
				if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
				{
					list.Sort(UICard.cardsPriceComparer);
				}
				else
				{
					list.Sort(UICard.cardsQuantityComparer);
				}
			}
			else if (this.sortByMode == 8)
			{
				if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
				{
					list.Sort(UICard.cardsPriceComparerReverse);
				}
				else
				{
					list.Sort(UICard.cardsQuantityComparerReverse);
				}
			}
			int num = GameEngine.Instance.World.getRank() + 1;
			content.clearDirectControlsOnly();
			foreach (UICard uicard in this.dummyCards)
			{
				uicard.clearControls();
			}
			this.dummyCards.Clear();
			int num2 = 0;
			if (array != null)
			{
				this.sortBack.Visible = false;
				this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, this.AvailablePanelContent.ClipRect.Y, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanel.Height - ManageCardsPanel.BorderPadding * 2);
				int num3 = 0;
				int num4 = -1;
				for (int i = 0; i < array.Length; i += 3)
				{
					if (array[i + 2] != num4)
					{
						int num5 = array[i];
						int num6 = array[i + 1] * 178;
						int num7 = (array[i + 2] - num3) * 237;
						bool flag = false;
						UICard uicard2 = null;
						foreach (UICard uicard3 in list)
						{
							if (CardTypes.getCardType(uicard3.Definition.id) == num5)
							{
								flag = true;
								uicard2 = uicard3;
							}
						}
						CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(num5);
						if (!flag && (cardDefinition.cardRank <= 0 || cardDefinition.cardRarity <= 0 || cardDefinition.available != 1 || (cardDefinition.cardPoints <= 0 && this.LayoutPanelMode == ManageCardsPanel.PANEL_MODE_BUY)) && num6 == 0)
						{
							bool flag2 = false;
							int cardType = CardTypes.getCardType(num5);
							if (cardType >= 3031 && cardType <= 3061)
							{
								for (int j = 0; j < array.Length; j += 3)
								{
									if (array[j + 2] == array[i + 2] && num5 != array[j])
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
								num3++;
								num4 = array[i + 2];
								goto IL_841;
							}
						}
						if (num7 + 237 > num2)
						{
							num2 = num7 + 237;
						}
						if (flag)
						{
							uicard2.Position = new Point(num6, num7);
							content.addControl(uicard2);
							if (num < uicard2.Definition.cardRank)
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
						else if (cardDefinition.cardRank > 0 && cardDefinition.cardRarity > 0 && cardDefinition.available == 1 && (cardDefinition.cardPoints > 0 || this.LayoutPanelMode != ManageCardsPanel.PANEL_MODE_BUY))
						{
							UICard uicard4 = BuyCardsPanel.makeUICard(cardDefinition, RemoteServices.Instance.UserID, 10000);
							uicard4.Position = new Point(num6, num7);
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
							uicard4.CustomTooltipData = num5;
							content.addControl(new CustomSelfDrawPanel.CSDLabel
							{
								Text = SK.Text("CARDS_No_Cards", "No Cards"),
								Position = new Point(num6 + 3, num7 + 5),
								Size = new Size(157, 217),
								Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER,
								Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold),
								Color = global::ARGBColors.White,
								CustomTooltipID = 10101,
								CustomTooltipData = num5
							});
						}
					}
					IL_841:;
				}
			}
			else
			{
				this.sortBack.Visible = true;
				this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, this.AvailablePanelContent.ClipRect.Y, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanel.Height - ManageCardsPanel.BorderPadding * 2 - 20);
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				int num11 = 0;
				foreach (UICard uicard5 in list)
				{
					uicard5.Position = new Point(num8, num9);
					content.addControl(uicard5);
					num11 = num9;
					if (num8 > width)
					{
						num8 = 0;
						num9 = (this.compressedCards ? (num9 + 58) : (num9 + (uicard5.Height + 8)));
					}
					else
					{
						num8 += uicard5.Width + 12;
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
					if (num < uicard5.Definition.cardRank)
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
			content.invalidate();
			return num2;
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x001890B8 File Offset: 0x001872B8
		public void UpdateScrollbar(CustomSelfDrawPanel.CSDVertScrollBar bar, CustomSelfDrawPanel.CSDImage content)
		{
			bar.Visible = (content.Height > content.ClipRect.Height);
			bar.Max = content.Height - content.ClipRect.Height;
			bar.NumVisibleLines = content.ClipRect.Height;
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00189110 File Offset: 0x00187310
		public void RenderCards(List<UICard> list)
		{
			int num = this.RefreshCards(this.AvailablePanelContent, list, 500);
			this.AvailablePanelContent.Position = new Point(12, 8);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, num);
			if (this.sortBack.Visible)
			{
				this.AvailablePanelContent.ClipRect = new Rectangle(0, 0, this.AvailablePanel.Width - ManageCardsPanel.BorderPadding, this.AvailablePanel.Height - ManageCardsPanel.BorderPadding * 2 - 20);
			}
			else
			{
				this.AvailablePanelContent.ClipRect = new Rectangle(0, 0, this.AvailablePanel.Width - ManageCardsPanel.BorderPadding, this.AvailablePanel.Height - ManageCardsPanel.BorderPadding * 2 + 16);
			}
			this.AvailablePanel.addControl(this.AvailablePanelContent);
			if (num < this.AvailablePanelContent.ClipRect.Height)
			{
				num = this.AvailablePanelContent.ClipRect.Height;
			}
			this.scrollbarAvailable.Position = new Point(this.AvailablePanel.Width - ManageCardsPanel.BorderPadding - ManageCardsPanel.BorderPadding / 2, this.AvailablePanel.Y + ManageCardsPanel.BorderPadding / 2);
			this.scrollbarAvailable.Size = new Size(ManageCardsPanel.BorderPadding, this.AvailablePanel.Height - ManageCardsPanel.BorderPadding);
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
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0018937C File Offset: 0x0018757C
		private void AvailableContentScroll()
		{
			int value = this.scrollbarAvailable.Value;
			this.AvailablePanelContent.Position = new Point(this.AvailablePanelContent.Position.X, 8 - value);
			this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, value, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanelContent.ClipRect.Height);
			this.AvailablePanelContent.invalidate();
			this.AvailablePanel.invalidate();
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x0018941C File Offset: 0x0018761C
		public void AddFloatingText(string text)
		{
			CustomSelfDrawPanel.CSDFloatingText csdfloatingText = new CustomSelfDrawPanel.CSDFloatingText();
			int dy = -5;
			if (this.fastCashIn)
			{
				dy = -1;
			}
			csdfloatingText.init(new Point(this.EmptyCards[0].X, this.EmptyCards[0].Y), new Size(this.EmptyCards[0].Width * 5, this.EmptyCards[0].Height), global::ARGBColors.Yellow, global::ARGBColors.Black, 0, dy, -10, text, 32, 33.0, 3000.0, DXTimer.GetCurrentMilliseconds(), this.mainBackgroundImage);
			this.floatingLabels.Add(csdfloatingText);
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x001894BC File Offset: 0x001876BC
		public void update()
		{
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			foreach (CustomSelfDrawPanel.CSDFloatingText csdfloatingText in this.floatingLabels)
			{
				csdfloatingText.move(currentMilliseconds);
			}
			if (this.cashingIn)
			{
				if (this.lastCashResponse != null && (DateTime.Now - this.spinstart).TotalSeconds > 1.0 && this.spinspeed > 32)
				{
					this.spinspeed /= 2;
					this.spinstart = DateTime.Now;
				}
				for (int i = 0; i < 5; i++)
				{
					if (this.spinspeed == 32)
					{
						if (!this.SlotAnims[i].Animate(currentMilliseconds, this.lastCashResponse.SymbolList[i]) && !this.spinSoundStopPlayed[i])
						{
							this.spinSoundStopPlayed[i] = true;
							if ((DateTime.Now - this.spinSoundStopLastTime).TotalMilliseconds > 500.0)
							{
								GameEngine.Instance.playInterfaceSound("CardSpinners_stop_" + this.spinSoundSoundID.ToString());
								this.spinSoundStopLastTime = DateTime.Now;
							}
							this.spinSoundSoundID++;
						}
					}
					else
					{
						this.SlotAnims[i].Animate(currentMilliseconds);
					}
					if (!this.SlotAnims[i].Playing && this.lastCashResponse != null)
					{
						this.SlotAnims[i].Image = GFXLibrary.CardSlotStillSymbols[this.lastCashResponse.SymbolList[i]];
					}
				}
				this.DynamicPanel.invalidate();
				if (!this.SlotAnims[0].Playing && !this.SlotAnims[1].Playing && !this.SlotAnims[2].Playing && !this.SlotAnims[3].Playing && !this.SlotAnims[4].Playing && this.lastCashResponse != null)
				{
					GameEngine.Instance.AudioEngine.Stop("CardSpinners_spin");
					this.playingSpinSound = false;
					if (!this.showingbonus)
					{
						this.floatingLabels.Clear();
						int num = this.NumCardsCachingIn * 5;
						if (this.lastCashResponse.Newpoints.Value == num)
						{
							this.AddFloatingText(string.Concat(new string[]
							{
								"+",
								this.lastCashResponse.Newpoints.Value.ToString(),
								" ",
								SK.Text("ManageCandsPanel_Card_Points", "Card Points"),
								"! ",
								SK.Text("ManageCandsPanel_No_Bonus", "No Bonus")
							}));
							GameEngine.Instance.playInterfaceSound("CardSpinners_bonus0");
						}
						else
						{
							this.AddFloatingText(string.Concat(new string[]
							{
								"+",
								this.lastCashResponse.Newpoints.Value.ToString(),
								" ",
								SK.Text("ManageCandsPanel_Card_Points", "Card Points"),
								"! (",
								SK.Text("ManageCandsPanel_Bonus", "Bonus"),
								" ",
								(this.lastCashResponse.Newpoints.Value - num).ToString(),
								")"
							}));
							GameEngine.Instance.playInterfaceSound("CardSpinners_bonus" + (this.lastCashResponse.Newpoints.Value - num).ToString());
						}
						this.labelTitle.Text = SK.Text("ManageCandsPanel_Cash_In_Cards_Title", "Cash in Cards: Current Card Points");
						this.addPointsData();
						if (GameEngine.Instance.World.FakeCardPoints > 0)
						{
							CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitlePoints;
							csdlabel.Text = csdlabel.Text + " (+" + GameEngine.Instance.World.FakeCardPoints.ToString() + ")";
						}
						this.showingbonus = true;
					}
					else
					{
						bool flag = true;
						foreach (CustomSelfDrawPanel.CSDFloatingText csdfloatingText2 in this.floatingLabels)
						{
							if (csdfloatingText2.live)
							{
								flag = false;
							}
						}
						if (flag)
						{
							this.GetCardsAvailable(true);
							int height = this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
							this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
							this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
							this.RefreshSet();
							this.cashingIn = false;
							this.cardsButtons.Available = true;
							this.InitEmptyCards();
							this.InitSpinners();
							this.showingbonus = false;
							this.cashingIn = false;
							this.cardsButtons.Available = true;
							this.LabelClickToRemove.Text = "";
						}
					}
				}
			}
			this.diamondAnimFrame = (int)((DateTime.Now - this.diamondAnimStartTime).TotalMilliseconds / 33.0);
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_CASH)
			{
				using (List<UICard>.Enumerator enumerator3 = this.UICardList.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						UICard uicard = enumerator3.Current;
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
					return;
				}
			}
			foreach (UICard uicard2 in this.CardCatalog)
			{
				if (uicard2.Definition.cardGrade == 524288)
				{
					uicard2.bigGradeImage.Image = GFXLibrary.card_diamond_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond_anim.Length];
					uicard2.bigGradeImage.invalidateXtra();
				}
				else if (uicard2.Definition.cardGrade == 1048576)
				{
					uicard2.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond2_anim.Length];
					uicard2.bigGradeImage.invalidateXtra();
				}
				else if (uicard2.Definition.cardGrade == 2097152)
				{
					uicard2.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_diamond3_anim.Length];
					uicard2.bigGradeImage.invalidateXtra();
				}
				else if (uicard2.Definition.cardGrade == 262144)
				{
					uicard2.bigGradeImage.Image = GFXLibrary.card_gold_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_gold_anim.Length];
					uicard2.bigGradeImage.invalidateXtra();
				}
				else if (uicard2.Definition.cardGrade == 4194304)
				{
					uicard2.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[this.diamondAnimFrame / 1 % GFXLibrary.card_sapphire_anim.Length];
					uicard2.bigGradeImage.invalidateXtra();
				}
			}
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x000195B8 File Offset: 0x000177B8
		public void navigateTest()
		{
			this.Navigate(2);
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x000195C1 File Offset: 0x000177C1
		private void Navigate(int panelType)
		{
			((PlayCardsWindow)base.ParentForm).SwitchPanel(panelType);
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x00189DD4 File Offset: 0x00187FD4
		private UICard makeUICard(CardTypes.CardDefinition def, int userid, int playerRank)
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
					goto IL_39C;
				}
				if (grade == 131072)
				{
					uicard.bigGradeImage.Image = GFXLibrary.CardGradeSilver;
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
					goto IL_39C;
				}
				if (grade == 262144)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_gold_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, 0);
					goto IL_39C;
				}
			}
			else if (grade <= 1048576)
			{
				if (grade == 524288)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -2);
					goto IL_39C;
				}
				if (grade == 1048576)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond2_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -7);
					goto IL_39C;
				}
			}
			else
			{
				if (grade == 2097152)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_diamond3_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -10);
					goto IL_39C;
				}
				if (grade == 4194304)
				{
					uicard.bigGradeImage.Image = GFXLibrary.card_sapphire_anim[0];
					uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width - 3, -12);
					goto IL_39C;
				}
			}
			uicard.bigGradeImage.Image = GFXLibrary.CardGradeBronze;
			uicard.bigGradeImage.Position = new Point(uicard.Width - uicard.bigGradeImage.Width, 0);
			IL_39C:
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
					goto IL_543;
				}
				if (grade != 524288)
				{
					goto IL_543;
				}
			}
			else if (grade != 1048576 && grade != 2097152)
			{
				if (grade != 4194304)
				{
					goto IL_543;
				}
				uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
				uicard.bigFrameExtraImage.Position = new Point(0, 0);
				uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_sapphire;
				uicard.addControl(uicard.bigFrameExtraImage);
				goto IL_543;
			}
			uicard.bigFrameExtraImage = new CustomSelfDrawPanel.CSDImage();
			uicard.bigFrameExtraImage.Position = new Point(0, 0);
			uicard.bigFrameExtraImage.Image = GFXLibrary.card_frame_overlay_diamond;
			uicard.addControl(uicard.bigFrameExtraImage);
			IL_543:
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

		// Token: 0x060018CC RID: 6348 RVA: 0x000195D4 File Offset: 0x000177D4
		public bool TUTORIAL_cardsInCart()
		{
			return this.ShoppingCart.Count > 0;
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x0018A6C0 File Offset: 0x001888C0
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
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
			{
				this.RefreshCards(this.AvailablePanelContent, this.CardCatalog, 500);
			}
			else
			{
				this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			}
			this.sortByName.Alpha = 0.5f;
			this.sortByType.Alpha = 1f;
			this.sortByQuantity.Alpha = 0.5f;
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x0018A754 File Offset: 0x00188954
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
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
			{
				this.RefreshCards(this.AvailablePanelContent, this.CardCatalog, 500);
			}
			else
			{
				this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			}
			this.sortByName.Alpha = 1f;
			this.sortByType.Alpha = 0.5f;
			this.sortByQuantity.Alpha = 0.5f;
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x0018A7EC File Offset: 0x001889EC
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
			if (this.PanelMode == ManageCardsPanel.PANEL_MODE_BUY)
			{
				this.RefreshCards(this.AvailablePanelContent, this.CardCatalog, 500);
			}
			else
			{
				this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500);
			}
			this.sortByName.Alpha = 0.5f;
			this.sortByType.Alpha = 0.5f;
			this.sortByQuantity.Alpha = 1f;
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x0018A884 File Offset: 0x00188A84
		private void compressClicked()
		{
			if (!this.compressedCards)
			{
				this.compressedCards = true;
				this.scrollbarAvailable.Value = 0;
				int height = (this.PanelMode != ManageCardsPanel.PANEL_MODE_BUY) ? this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500) : this.RefreshCards(this.AvailablePanelContent, this.CardCatalog, 500);
				this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
				this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
				this.AvailableContentScroll();
				base.Invalidate();
			}
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x0018A92C File Offset: 0x00188B2C
		private void expandClicked()
		{
			if (this.compressedCards)
			{
				this.compressedCards = false;
				this.scrollbarAvailable.Value = 0;
				int height = (this.PanelMode != ManageCardsPanel.PANEL_MODE_BUY) ? this.RefreshCards(this.AvailablePanelContent, this.UICardList, 500) : this.RefreshCards(this.AvailablePanelContent, this.CardCatalog, 500);
				this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, height);
				this.UpdateScrollbar(this.scrollbarAvailable, this.AvailablePanelContent);
				this.AvailableContentScroll();
				base.Invalidate();
			}
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x0018A9D4 File Offset: 0x00188BD4
		private void buyAndPlayCheckChanged()
		{
			if (this.buyAndPlayCheckBox.Checked)
			{
				this.DynamicButtonLabel.Text = SK.Text("ManageCandsPanel_Get_And_Play_Card", "Get and Play Card");
				return;
			}
			this.DynamicButtonLabel.Text = SK.Text("ManageCandsPanel_Get_Cards", "Get Cards");
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x000195E4 File Offset: 0x000177E4
		public void autoPlayCardDelegate(bool fromClick, bool fromValidate)
		{
			this.autoPlayCard(this.autoCardUserID, this.autoCardDef, fromClick, fromValidate);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x0018AA24 File Offset: 0x00188C24
		private void autoPlayCard(int userID, CardTypes.CardDefinition def, bool fromClick, bool fromValidate)
		{
			if (GameEngine.Instance.World.WorldEnded || this.waitingResponse)
			{
				return;
			}
			this.waitingResponse = true;
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			int villageID = -1;
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (!GameEngine.Instance.World.isCapital(selectedMenuVillage))
			{
				villageID = selectedMenuVillage;
			}
			int num = GameEngine.Instance.World.getRank() + 1;
			if (def.cardRank > num)
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
					def.cardRank.ToString()
				}), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				this.waitingResponse = false;
				return;
			}
			this.autoCardUserID = userID;
			this.autoCardVillageID = villageID;
			this.autoCardDef = def;
			if (fromClick && Program.mySettings.ConfirmPlayCard)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_open_confirmation");
				base.PanelActive = false;
				this.waitingResponse = false;
				InterfaceMgr.Instance.openConfirmPlayCardPopup(this.autoCardDef, new ConfirmPlayCardPanel.CardClickPlayDelegate(this.autoPlayCardDelegate));
				return;
			}
			if (!fromValidate && CardTypes.cardNeedsValidation(CardTypes.getCardType(this.autoCardDef.id)))
			{
				this.validateCardPossible(CardTypes.getCardType(this.autoCardDef.id), villageID);
				return;
			}
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.getCardWindow());
			}
			GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card");
			StatTrackingClient.Instance().ActivateTrigger(16, this.buyAndPlayCheckBox.Checked);
			xmlRpcCardsProvider.PlayUserCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), userID.ToString(), villageID.ToString(), RemoteServices.Instance.ProfileWorldID.ToString()), new CardsEndResponseDelegate(this.CardPlayed), this);
			try
			{
				GameEngine.Instance.cardsManager.removeProfileCard(userID);
			}
			catch (Exception ex)
			{
				MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
			}
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x0018ACE8 File Offset: 0x00188EE8
		private void CardPlayed(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode == null || response.SuccessCode.Value != 1)
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_failed");
				MyMessageBox.Show(CardsManager.translateCardError(response.Message, this.autoCardDef.id), SK.Text("BuyCardsPanel_Cannot_Play_Cards", "Could not play card."));
				try
				{
					GameEngine.Instance.cardsManager.addProfileCard(this.autoCardUserID, CardTypes.getStringFromCard(this.autoCardDef.id));
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(ex.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
				}
				if (InterfaceMgr.Instance.getCardWindow() != null)
				{
					CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.getCardWindow());
				}
				StatTrackingClient.Instance().ActivateTrigger(16, false);
			}
			else
			{
				GameEngine.Instance.playInterfaceSound("PlayCardsPanel_play_card_success");
				GameEngine.Instance.cardsManager.ProfileCardsSet.Remove(this.autoCardUserID);
				GameEngine.Instance.cardsManager.CardPlayed(this.autoCardDef.cardCategory, this.autoCardDef.id, this.autoCardVillageID);
				GameEngine.Instance.cardsManager.addRecentCard(this.autoCardDef.id);
				StatTrackingClient.Instance().ActivateTrigger(6, this.autoCardDef.id);
			}
			this.waitingResponse = false;
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000195FA File Offset: 0x000177FA
		public void validateCardPossible(int cardType, int villageID)
		{
			RemoteServices.Instance.set_PreValidateCardToBePlayed_UserCallBack(new RemoteServices.PreValidateCardToBePlayed_UserCallBack(this.preValidateCardToBePlayedCallBack));
			RemoteServices.Instance.PreValidateCardToBePlayed(cardType, villageID);
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x0018AE6C File Offset: 0x0018906C
		public void preValidateCardToBePlayedCallBack(PreValidateCardToBePlayed_ReturnType returnData)
		{
			this.waitingResponse = false;
			if (!returnData.Success)
			{
				return;
			}
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
				this.autoPlayCardDelegate(false, true);
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
					this.autoPlayCardDelegate(false, true);
					return;
				}
			}
			else if (returnData.otherErrorCode != 0)
			{
				if (returnData.otherErrorCode == -2)
				{
					MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 5), SK.Text("GENERIC_Error", "Error"));
					return;
				}
				if (returnData.otherErrorCode == -3)
				{
					GameEngine.Instance.displayedVillageLost(returnData.villageID, true);
					return;
				}
			}
			else
			{
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
						CardTypes.getDescriptionFromCard(returnData.cardType),
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
						CardTypes.getDescriptionFromCard(returnData.cardType),
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
						CardTypes.getDescriptionFromCard(returnData.cardType),
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
						CardTypes.getDescriptionFromCard(returnData.cardType),
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
					MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 1), SK.Text("GENERIC_Error", "Error"));
					return;
				case 3287:
				case 3288:
				case 3289:
					MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 2), SK.Text("GENERIC_Error", "Error"));
					return;
				case 3290:
				case 3291:
				case 3292:
					MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 3), SK.Text("GENERIC_Error", "Error"));
					return;
				case 3293:
				case 3294:
				case 3295:
					MyMessageBox.Show(CardsManager.translateCardError("", returnData.cardType, 4), SK.Text("GENERIC_Error", "Error"));
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x040028F8 RID: 10488
		private const int MAX_CASHIN_CARDS = 60;

		// Token: 0x040028F9 RID: 10489
		private IContainer components;

		// Token: 0x040028FA RID: 10490
		private CustomSelfDrawPanel.CSDImage TabSelector = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040028FB RID: 10491
		private CustomSelfDrawPanel.CSDArea TabBuyArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040028FC RID: 10492
		private CustomSelfDrawPanel.CSDArea TabCashArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040028FD RID: 10493
		private CustomSelfDrawPanel.CSDButton searchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028FE RID: 10494
		private CustomSelfDrawPanel.CSDButton clearSearchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040028FF RID: 10495
		public int PanelMode;

		// Token: 0x04002900 RID: 10496
		public int LayoutPanelMode;

		// Token: 0x04002901 RID: 10497
		public static int PANEL_MODE_CASH = 1;

		// Token: 0x04002902 RID: 10498
		public static int PANEL_MODE_BUY = 2;

		// Token: 0x04002903 RID: 10499
		private CardTypes.CardDefinition CatalogFilterDefinition = new CardTypes.CardDefinition();

		// Token: 0x04002904 RID: 10500
		private List<CustomSelfDrawPanel.CSDButton> FilterButtons = new List<CustomSelfDrawPanel.CSDButton>();

		// Token: 0x04002905 RID: 10501
		private CustomSelfDrawPanel.CSDImageAnim[] SlotAnims = new CustomSelfDrawPanel.CSDImageAnim[5];

		// Token: 0x04002906 RID: 10502
		private CustomSelfDrawPanel.CSDImage SlotHolder = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002907 RID: 10503
		private CustomSelfDrawPanel.CSDLabel LabelClickToRemove = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002908 RID: 10504
		private string TextRemove = SK.Text("ManageCandsPanel_Cancel_Purchase", "Click Card to cancel purchase") + ": ";

		// Token: 0x04002909 RID: 10505
		private string TextRemoveSet = SK.Text("ManageCandsPanel_Remove_From_Set", "Click Card to remove from set") + ": ";

		// Token: 0x0400290A RID: 10506
		private string TextEmptySet = SK.Text("ManageCandsPanel_Make_Set", "Click on cards below to make a set of 5");

		// Token: 0x0400290B RID: 10507
		private string TextEmptyMultiSet = SK.Text("ManageCandsPanel_Make_MultiSet", "Click on cards below to make a set of at least 5");

		// Token: 0x0400290C RID: 10508
		private string TextIncompleteSetStart = SK.Text("ManageCandsPanel_Choose_More", "More Cards Needed") + ": ";

		// Token: 0x0400290D RID: 10509
		private string TextCash = SK.Text("ManageCandsPanel_Cash_In_Here", "Click Here to cash in!");

		// Token: 0x0400290E RID: 10510
		private string TextCartEmpty = SK.Text("ManageCandsPanel_Buy", "Click on cards below to buy them");

		// Token: 0x0400290F RID: 10511
		private string TextCartFull = SK.Text("ManageCandsPanel_Confirm,", "Click Here to confirm purchase!");

		// Token: 0x04002910 RID: 10512
		private CustomSelfDrawPanel.CSDImage DynamicPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002911 RID: 10513
		private CustomSelfDrawPanel.CSDLabel DynamicLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002912 RID: 10514
		private CustomSelfDrawPanel.CSDImage DynamicButton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002913 RID: 10515
		private CustomSelfDrawPanel.CSDLabel DynamicButtonLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002914 RID: 10516
		private CustomSelfDrawPanel.CSDVertImageScroller[] SymbolScrollers = new CustomSelfDrawPanel.CSDVertImageScroller[5];

		// Token: 0x04002915 RID: 10517
		private List<CustomSelfDrawPanel.CSDFloatingText> floatingLabels = new List<CustomSelfDrawPanel.CSDFloatingText>();

		// Token: 0x04002916 RID: 10518
		public bool showingbonus;

		// Token: 0x04002917 RID: 10519
		private DateTime lastUpdatedProgressBars = DateTime.Now.AddSeconds(30.0);

		// Token: 0x04002918 RID: 10520
		private DateTime lastTickCall = DateTime.Now.AddSeconds(-60.0);

		// Token: 0x04002919 RID: 10521
		private DateTime lastRefresh = DateTime.Now;

		// Token: 0x0400291A RID: 10522
		private CustomSelfDrawPanel.CSDImage buttonCash = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400291B RID: 10523
		private CustomSelfDrawPanel.CSDImage buttonBonus = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400291C RID: 10524
		private CustomSelfDrawPanel.CSDImage buttonCatalog = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400291D RID: 10525
		private CustomSelfDrawPanel.CSDLabel labelBuyCash = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400291E RID: 10526
		private CustomSelfDrawPanel.UICardsButtons cardsButtons;

		// Token: 0x0400291F RID: 10527
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002920 RID: 10528
		private List<UICard> UICardList = new List<UICard>();

		// Token: 0x04002921 RID: 10529
		private List<UICard> UICardListInplay = new List<UICard>();

		// Token: 0x04002922 RID: 10530
		private List<UICard> CardCatalog = new List<UICard>();

		// Token: 0x04002923 RID: 10531
		private List<UICard> ShoppingCart = new List<UICard>();

		// Token: 0x04002924 RID: 10532
		private CustomSelfDrawPanel.CSDImage[] EmptyCards = new CustomSelfDrawPanel.CSDImage[5];

		// Token: 0x04002925 RID: 10533
		private UICard[] SetCards = new UICard[60];

		// Token: 0x04002926 RID: 10534
		private CustomSelfDrawPanel.CSDLabel cardTitle;

		// Token: 0x04002927 RID: 10535
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002928 RID: 10536
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002929 RID: 10537
		private CustomSelfDrawPanel.CSDLabel labelTitlePoints = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400292A RID: 10538
		private CustomSelfDrawPanel.CSDImage imageTitlePoints = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400292B RID: 10539
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400292C RID: 10540
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400292D RID: 10541
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400292E RID: 10542
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400292F RID: 10543
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002930 RID: 10544
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002931 RID: 10545
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002932 RID: 10546
		private CustomSelfDrawPanel.CSDCheckBox fastCashInCheckBox = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002933 RID: 10547
		private CustomSelfDrawPanel.CSDCheckBox buyAndPlayCheckBox = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04002934 RID: 10548
		private int currentCardSection = -1;

		// Token: 0x04002935 RID: 10549
		private static int BorderPadding = 16;

		// Token: 0x04002936 RID: 10550
		private int ContentWidth;

		// Token: 0x04002937 RID: 10551
		private int AvailablePanelWidth;

		// Token: 0x04002938 RID: 10552
		private int InplayPanelWidth;

		// Token: 0x04002939 RID: 10553
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x0400293A RID: 10554
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400293B RID: 10555
		private CustomSelfDrawPanel.CSDImage InplayPanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400293C RID: 10556
		private int sortByMode = -1;

		// Token: 0x0400293D RID: 10557
		private CustomSelfDrawPanel.CSDImage sortBack = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400293E RID: 10558
		private CustomSelfDrawPanel.CSDButton sortByName = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400293F RID: 10559
		private CustomSelfDrawPanel.CSDButton sortByType = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002940 RID: 10560
		private CustomSelfDrawPanel.CSDButton sortByQuantity = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002941 RID: 10561
		private CustomSelfDrawPanel.CSDButton compressButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002942 RID: 10562
		private CustomSelfDrawPanel.CSDButton expandButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002943 RID: 10563
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002944 RID: 10564
		private Bitmap greenbar = new Bitmap(29, 3);

		// Token: 0x04002945 RID: 10565
		private CustomSelfDrawPanel.CSDControl[] Spinners = new CustomSelfDrawPanel.CSDControl[5];

		// Token: 0x04002946 RID: 10566
		private CustomSelfDrawPanel.CSDControl[] SpinnerInners = new CustomSelfDrawPanel.CSDControl[5];

		// Token: 0x04002947 RID: 10567
		private Dictionary<int, int> symbolOffsets = new Dictionary<int, int>();

		// Token: 0x04002948 RID: 10568
		private int[] SymbolTargets = new int[5];

		// Token: 0x04002949 RID: 10569
		private bool[] spinning = new bool[5];

		// Token: 0x0400294A RID: 10570
		private bool cashingIn;

		// Token: 0x0400294B RID: 10571
		private bool fastCashIn;

		// Token: 0x0400294C RID: 10572
		private bool buyingCard;

		// Token: 0x0400294D RID: 10573
		private DateTime spinstart;

		// Token: 0x0400294E RID: 10574
		private int spinspeed;

		// Token: 0x0400294F RID: 10575
		private XmlRpcCardsResponse lastCashResponse;

		// Token: 0x04002950 RID: 10576
		private string newcardnames = "";

		// Token: 0x04002951 RID: 10577
		private int newcardcost;

		// Token: 0x04002952 RID: 10578
		private CardTypes.CardDefinition newcarddef;

		// Token: 0x04002953 RID: 10579
		private int NumCardsCachingIn;

		// Token: 0x04002954 RID: 10580
		private int failedPurchaseCard = -1;

		// Token: 0x04002955 RID: 10581
		private int failedPurchaseCost = -1;

		// Token: 0x04002956 RID: 10582
		private bool compressedCards;

		// Token: 0x04002957 RID: 10583
		private List<UICard> dummyCards = new List<UICard>();

		// Token: 0x04002958 RID: 10584
		private int diamondAnimFrame;

		// Token: 0x04002959 RID: 10585
		private DateTime diamondAnimStartTime = DateTime.Now;

		// Token: 0x0400295A RID: 10586
		private bool playingSpinSound;

		// Token: 0x0400295B RID: 10587
		private bool[] spinSoundStopPlayed = new bool[5];

		// Token: 0x0400295C RID: 10588
		private int spinSoundSoundID;

		// Token: 0x0400295D RID: 10589
		private DateTime spinSoundStopLastTime = DateTime.MinValue;

		// Token: 0x0400295E RID: 10590
		private int autoCardUserID;

		// Token: 0x0400295F RID: 10591
		private CardTypes.CardDefinition autoCardDef;

		// Token: 0x04002960 RID: 10592
		private int autoCardVillageID;

		// Token: 0x04002961 RID: 10593
		private bool waitingResponse;

		// Token: 0x04002962 RID: 10594
		[CompilerGenerated]
		private static Comparison<UICard> _003C_003E9__CachedAnonymousMethodDelegate19;
	}
}
