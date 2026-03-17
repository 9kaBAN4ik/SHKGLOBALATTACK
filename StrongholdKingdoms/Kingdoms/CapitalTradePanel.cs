using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000107 RID: 263
	public class CapitalTradePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0000CC5A File Offset: 0x0000AE5A
		public static List<WorldMap.VillageNameItem> ExchangeHistory
		{
			get
			{
				return CapitalTradePanel.exchangeHistory;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x0000CC61 File Offset: 0x0000AE61
		public static List<WorldMap.VillageNameItem> ExchangeFavourites
		{
			get
			{
				return CapitalTradePanel.exchangeFavourites;
			}
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x000AD90C File Offset: 0x000ABB0C
		public static void addHistory(GenericVillageHistoryData[] newData)
		{
			CapitalTradePanel.exchangeHistory.Clear();
			if (newData == null)
			{
				return;
			}
			foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
			{
				WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
				if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
				{
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					CapitalTradePanel.exchangeHistory.Add(villageNameItem);
				}
			}
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x000AD970 File Offset: 0x000ABB70
		public static void addFavourites(GenericVillageHistoryData[] newData)
		{
			CapitalTradePanel.exchangeFavourites.Clear();
			if (newData == null)
			{
				return;
			}
			foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
			{
				WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
				if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
				{
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					CapitalTradePanel.exchangeFavourites.Add(villageNameItem);
				}
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x000AD9D4 File Offset: 0x000ABBD4
		public CapitalTradePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x000ADD20 File Offset: 0x000ABF20
		public void init()
		{
			CapitalTradePanel.instance = this;
			base.clearControls();
			int num = 70;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			this.stockExchangeLabel.Text = SK.Text("CapitalTradePanel_", "Purchase Goods");
			this.stockExchangeLabel.Color = Color.FromArgb(224, 203, 146);
			this.stockExchangeLabel.DropShadowColor = Color.FromArgb(74, 67, 48);
			this.stockExchangeLabel.Position = new Point(9, 9);
			this.stockExchangeLabel.Size = new Size(992, 50);
			this.stockExchangeLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.stockExchangeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundArea.addControl(this.stockExchangeLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CapitalTradePanel_close");
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 12, new Point(898, 10));
			this.midWindow.Size = new Size(228, 449 - num - 150);
			this.midWindow.Position = new Point(375, 124);
			this.mainBackgroundArea.addControl(this.midWindow);
			this.midWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.leftWindow.Size = new Size(335, 449 - num - 150);
			this.leftWindow.Position = new Point(45, 124);
			this.mainBackgroundArea.addControl(this.leftWindow);
			this.leftWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.lightArea1.Size = new Size(97, 179);
			this.lightArea1.Position = new Point(216, 102 - num);
			this.leftWindow.addControl(this.lightArea1);
			this.lightArea1.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.localHeadingLabel.Text = SK.Text("TRADE_Local", "Local");
			this.localHeadingLabel.Color = Color.FromArgb(196, 161, 85 - num);
			this.localHeadingLabel.Position = new Point(0, -35);
			this.localHeadingLabel.Size = new Size(97, 30);
			this.localHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.localHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea1.addControl(this.localHeadingLabel);
			this.lightArea2.Size = new Size(97, 179);
			this.lightArea2.Position = new Point(21, 102 - num);
			this.midWindow.addControl(this.lightArea2);
			this.lightArea2.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.storedHeadingLabel.Text = SK.Text("TRADE_At_Exchange", "At Exchange");
			this.storedHeadingLabel.Color = Color.FromArgb(196, 161, 85 - num);
			this.storedHeadingLabel.Position = new Point(0, -35);
			this.storedHeadingLabel.Size = new Size(97, 30);
			this.storedHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.storedHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea2.addControl(this.storedHeadingLabel);
			this.lightArea3.Size = new Size(77, 179);
			this.lightArea3.Position = new Point(129, 102 - num);
			this.midWindow.addControl(this.lightArea3);
			this.lightArea3.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.BuyPriceHeadingLabel.Text = SK.Text("CapitalTradePanel_Buy_Price", "Buy Price");
			this.BuyPriceHeadingLabel.Color = Color.FromArgb(196, 161, 85 - num);
			this.BuyPriceHeadingLabel.Position = new Point(-30, -35);
			this.BuyPriceHeadingLabel.Size = new Size(137, 30);
			this.BuyPriceHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.BuyPriceHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea3.addControl(this.BuyPriceHeadingLabel);
			this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_normal;
			this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_over;
			this.tabButton1.Position = new Point(2, -13);
			this.tabButton1.MoveOnClick = false;
			this.tabButton1.Data = 1;
			this.tabButton1.Visible = false;
			this.leftWindow.addControl(this.tabButton1);
			this.buyWindow.Size = new Size(336, 145);
			this.buyWindow.Position = new Point(627, 166);
			this.mainBackgroundArea.addControl(this.buyWindow);
			this.buyWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.buySubWindow.Size = new Size(147, 50);
			this.buySubWindow.Position = new Point(178, 32);
			this.buyWindow.addControl(this.buySubWindow);
			this.buySubWindow.Create(GFXLibrary.int_insetpanel_b_top_left, GFXLibrary.int_insetpanel_b_middle_top, GFXLibrary.int_insetpanel_b_top_right, GFXLibrary.int_insetpanel_b_middle_left, GFXLibrary.int_insetpanel_b_middle, GFXLibrary.int_insetpanel_b_middle_right, GFXLibrary.int_insetpanel_b_bottom_left, GFXLibrary.int_insetpanel_b_middle_bottom, GFXLibrary.int_insetpanel_b_bottom_right);
			this.buyHeadingLabel.Text = SK.Text("CapitalTradePanel_Buy", "Buy") + " ";
			this.buyHeadingLabel.Color = global::ARGBColors.Black;
			this.buyHeadingLabel.Position = new Point(90, -30);
			this.buyHeadingLabel.Size = new Size(246, 30);
			this.buyHeadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.buyHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.buyWindow.addControl(this.buyHeadingLabel);
			this.buyHeadingImage.Image = null;
			this.buyHeadingImage.Position = new Point(5, -50);
			this.buyWindow.addControl(this.buyHeadingImage);
			this.buyTaxLabel.Text = SK.Text("CapitalTradePanel_25_Tax", "+25% Tax");
			this.buyTaxLabel.Color = Color.FromArgb(196, 161, 85);
			this.buyTaxLabel.Position = new Point(21, 108);
			this.buyTaxLabel.Size = new Size(74, 30);
			this.buyTaxLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyTaxLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.buyWindow.addControl(this.buyTaxLabel);
			this.buyCostLabel.Text = SK.Text("CapitalTradePanel_Cost", "Cost") + ":";
			this.buyCostLabel.Color = Color.FromArgb(196, 161, 85);
			this.buyCostLabel.Position = new Point(0, 13);
			this.buyCostLabel.Size = new Size(74, 30);
			this.buyCostLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyCostLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.buySubWindow.addControl(this.buyCostLabel);
			this.buyNumber.Text = "0";
			this.buyNumber.Color = Color.FromArgb(196, 161, 85);
			this.buyNumber.Position = new Point(63, -4);
			this.buyNumber.Size = new Size(70, 30);
			this.buyNumber.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyNumber.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.buySubWindow.addControl(this.buyNumber);
			this.buyCostValue.Text = "0";
			this.buyCostValue.Color = Color.FromArgb(196, 161, 85);
			this.buyCostValue.Position = new Point(63, 13);
			this.buyCostValue.Size = new Size(70, 30);
			this.buyCostValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyCostValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.buySubWindow.addControl(this.buyCostValue);
			this.sendEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.sendEditButton.ImageOver = GFXLibrary.faction_pen;
			this.sendEditButton.ImageClick = GFXLibrary.faction_pen;
			this.sendEditButton.MoveOnClick = true;
			this.sendEditButton.OverBrighten = true;
			this.sendEditButton.Position = new Point(7, 5);
			this.sendEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "CapitalTradePanel_editValue");
			this.buySubWindow.addControl(this.sendEditButton);
			this.buyButton.Position = new Point(177, 94);
			this.buyButton.Size = new Size(153, 38);
			this.buyButton.Text.Text = SK.Text("CapitalTradePanel_Buy", "Buy");
			this.buyButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyButton.TextYOffset = -1;
			this.buyButton.Text.Color = global::ARGBColors.Black;
			this.buyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyClick), "CapitalTradePanel_buy");
			this.buyWindow.addControl(this.buyButton);
			this.buyButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.buyButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.buyTrack.Position = new Point(21, 41);
			this.buyTrack.Margin = new Rectangle(3, -1, 1, 0);
			this.buyTrack.Value = 0;
			this.buyTrack.Max = 1;
			this.buyTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.buyWindow.addControl(this.buyTrack);
			this.buyTrack.Create(GFXLibrary.int_slidebar_ruler, GFXLibrary.int_slidebar_thumb_middle_normal, GFXLibrary.int_slidebar_thumb_left_normal, GFXLibrary.int_slidebar_thumb_right_normal, GFXLibrary.int_slidebar_thumb_middle_in, GFXLibrary.int_slidebar_thumb_middle_over);
			this.buyMin.Text = "0";
			this.buyMin.Color = global::ARGBColors.Black;
			this.buyMin.Position = new Point(-2, 74);
			this.buyMin.Size = new Size(50, 30);
			this.buyMin.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.buyMin.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.buyWindow.addControl(this.buyMin);
			this.buyMax.Text = "0";
			this.buyMax.Color = global::ARGBColors.Black;
			this.buyMax.Position = new Point(126, 74);
			this.buyMax.Size = new Size(50, 30);
			this.buyMax.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.buyMax.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.buyWindow.addControl(this.buyMax);
			this.highlightLine1.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine1.Position = new Point(153, 111 - num + 5);
			this.highlightLine1.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine1);
			this.highlightLine2.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine2.Position = new Point(153, 111 - num + 5 + 40);
			this.highlightLine2.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine2);
			this.highlightLine3.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine3.Position = new Point(153, 111 - num + 5 + 80);
			this.highlightLine3.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine3);
			this.highlightLine4.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine4.Position = new Point(153, 111 - num + 5 + 120);
			this.highlightLine4.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine4);
			this.highlightLine5.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine5.Position = new Point(153, 271);
			this.highlightLine5.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine5);
			this.highlightLine6.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine6.Position = new Point(153, 311);
			this.highlightLine6.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine6);
			this.highlightLine7.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine7.Position = new Point(153, 351);
			this.highlightLine7.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine7);
			this.highlightLine8.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine8.Position = new Point(153, 391);
			this.highlightLine8.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine8);
			this.selectRow1.Position = new Point(-134, -3);
			this.selectRow1.Size = new Size(191, 38);
			this.selectRow1.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow1.Text.Position = new Point(91, 0);
			this.selectRow1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow1.TextYOffset = -1;
			this.selectRow1.Text.Color = global::ARGBColors.Black;
			this.selectRow1.ImageIconPosition = new Point(46, -3);
			this.selectRow1.createSubText("0");
			this.selectRow1.Text2.Size = new Size(46, this.selectRow1.Text2.Size.Height);
			this.selectRow1.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine1.addControl(this.selectRow1);
			this.selectRow1.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow1.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow2.Position = new Point(-134, -3);
			this.selectRow2.Size = new Size(191, 38);
			this.selectRow2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow2.Text.Position = new Point(91, 0);
			this.selectRow2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow2.TextYOffset = -1;
			this.selectRow2.Text.Color = global::ARGBColors.Black;
			this.selectRow2.ImageIconPosition = new Point(46, -3);
			this.selectRow2.createSubText("0");
			this.selectRow2.Text2.Size = new Size(46, this.selectRow2.Text2.Size.Height);
			this.selectRow2.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine2.addControl(this.selectRow2);
			this.selectRow2.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow2.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow3.Position = new Point(-134, -3);
			this.selectRow3.Size = new Size(191, 38);
			this.selectRow3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow3.Text.Position = new Point(91, 0);
			this.selectRow3.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow3.TextYOffset = -1;
			this.selectRow3.Text.Color = global::ARGBColors.Black;
			this.selectRow3.ImageIconPosition = new Point(46, -3);
			this.selectRow3.createSubText("0");
			this.selectRow3.Text2.Size = new Size(46, this.selectRow3.Text2.Size.Height);
			this.selectRow3.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine3.addControl(this.selectRow3);
			this.selectRow3.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow3.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow4.Position = new Point(-134, -3);
			this.selectRow4.Size = new Size(191, 38);
			this.selectRow4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow4.Text.Position = new Point(91, 0);
			this.selectRow4.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow4.TextYOffset = -1;
			this.selectRow4.Text.Color = global::ARGBColors.Black;
			this.selectRow4.ImageIconPosition = new Point(46, -3);
			this.selectRow4.createSubText("0");
			this.selectRow4.Text2.Size = new Size(46, this.selectRow4.Text2.Size.Height);
			this.selectRow4.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine4.addControl(this.selectRow4);
			this.selectRow4.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow4.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow5.Position = new Point(-134, -3);
			this.selectRow5.Size = new Size(191, 38);
			this.selectRow5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow5.Text.Position = new Point(91, 0);
			this.selectRow5.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow5.TextYOffset = -1;
			this.selectRow5.Text.Color = global::ARGBColors.Black;
			this.selectRow5.ImageIconPosition = new Point(46, -3);
			this.selectRow5.createSubText("0");
			this.selectRow5.Text2.Size = new Size(46, this.selectRow5.Text2.Size.Height);
			this.selectRow5.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine5.addControl(this.selectRow5);
			this.selectRow5.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow5.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow6.Position = new Point(-134, -3);
			this.selectRow6.Size = new Size(191, 38);
			this.selectRow6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow6.Text.Position = new Point(91, 0);
			this.selectRow6.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow6.TextYOffset = -1;
			this.selectRow6.Text.Color = global::ARGBColors.Black;
			this.selectRow6.ImageIconPosition = new Point(46, -3);
			this.selectRow6.createSubText("0");
			this.selectRow6.Text2.Size = new Size(46, this.selectRow6.Text2.Size.Height);
			this.selectRow6.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine6.addControl(this.selectRow6);
			this.selectRow6.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow6.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow7.Position = new Point(-134, -3);
			this.selectRow7.Size = new Size(191, 38);
			this.selectRow7.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow7.Text.Position = new Point(91, 0);
			this.selectRow7.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow7.TextYOffset = -1;
			this.selectRow7.Text.Color = global::ARGBColors.Black;
			this.selectRow7.ImageIconPosition = new Point(46, -3);
			this.selectRow7.createSubText("0");
			this.selectRow7.Text2.Size = new Size(46, this.selectRow7.Text2.Size.Height);
			this.selectRow7.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine7.addControl(this.selectRow7);
			this.selectRow7.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow7.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow8.Position = new Point(-134, -3);
			this.selectRow8.Size = new Size(191, 38);
			this.selectRow8.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow8.Text.Position = new Point(91, 0);
			this.selectRow8.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow8.TextYOffset = -1;
			this.selectRow8.Text.Color = global::ARGBColors.Black;
			this.selectRow8.ImageIconPosition = new Point(46, -3);
			this.selectRow8.createSubText("0");
			this.selectRow8.Text2.Size = new Size(46, this.selectRow8.Text2.Size.Height);
			this.selectRow8.Text2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.selectRow8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine8.addControl(this.selectRow8);
			this.selectRow8.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow8.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.localLabel1.Text = "0";
			this.localLabel1.Color = global::ARGBColors.Black;
			this.localLabel1.Position = new Point(63, 1);
			this.localLabel1.Size = new Size(97, 31);
			this.localLabel1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine1.addControl(this.localLabel1);
			this.localLabel2.Text = "0";
			this.localLabel2.Color = global::ARGBColors.Black;
			this.localLabel2.Position = new Point(63, 1);
			this.localLabel2.Size = new Size(97, 31);
			this.localLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine2.addControl(this.localLabel2);
			this.localLabel3.Text = "0";
			this.localLabel3.Color = global::ARGBColors.Black;
			this.localLabel3.Position = new Point(63, 1);
			this.localLabel3.Size = new Size(97, 31);
			this.localLabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine3.addControl(this.localLabel3);
			this.localLabel4.Text = "0";
			this.localLabel4.Color = global::ARGBColors.Black;
			this.localLabel4.Position = new Point(63, 1);
			this.localLabel4.Size = new Size(97, 31);
			this.localLabel4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine4.addControl(this.localLabel4);
			this.localLabel5.Text = "0";
			this.localLabel5.Color = global::ARGBColors.Black;
			this.localLabel5.Position = new Point(63, 1);
			this.localLabel5.Size = new Size(97, 31);
			this.localLabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine5.addControl(this.localLabel5);
			this.localLabel6.Text = "0";
			this.localLabel6.Color = global::ARGBColors.Black;
			this.localLabel6.Position = new Point(63, 1);
			this.localLabel6.Size = new Size(97, 31);
			this.localLabel6.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine6.addControl(this.localLabel6);
			this.localLabel7.Text = "0";
			this.localLabel7.Color = global::ARGBColors.Black;
			this.localLabel7.Position = new Point(63, 1);
			this.localLabel7.Size = new Size(97, 31);
			this.localLabel7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine7.addControl(this.localLabel7);
			this.localLabel8.Text = "0";
			this.localLabel8.Color = global::ARGBColors.Black;
			this.localLabel8.Position = new Point(63, 1);
			this.localLabel8.Size = new Size(97, 31);
			this.localLabel8.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.localLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine8.addControl(this.localLabel8);
			this.storedLabel1.Text = "0";
			this.storedLabel1.Color = global::ARGBColors.Black;
			this.storedLabel1.Position = new Point(198, 1);
			this.storedLabel1.Size = new Size(97, 31);
			this.storedLabel1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine1.addControl(this.storedLabel1);
			this.storedLabel2.Text = "0";
			this.storedLabel2.Color = global::ARGBColors.Black;
			this.storedLabel2.Position = new Point(198, 1);
			this.storedLabel2.Size = new Size(97, 31);
			this.storedLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine2.addControl(this.storedLabel2);
			this.storedLabel3.Text = "0";
			this.storedLabel3.Color = global::ARGBColors.Black;
			this.storedLabel3.Position = new Point(198, 1);
			this.storedLabel3.Size = new Size(97, 31);
			this.storedLabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine3.addControl(this.storedLabel3);
			this.storedLabel4.Text = "0";
			this.storedLabel4.Color = global::ARGBColors.Black;
			this.storedLabel4.Position = new Point(198, 1);
			this.storedLabel4.Size = new Size(97, 31);
			this.storedLabel4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine4.addControl(this.storedLabel4);
			this.storedLabel5.Text = "0";
			this.storedLabel5.Color = global::ARGBColors.Black;
			this.storedLabel5.Position = new Point(198, 1);
			this.storedLabel5.Size = new Size(97, 31);
			this.storedLabel5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine5.addControl(this.storedLabel5);
			this.storedLabel6.Text = "0";
			this.storedLabel6.Color = global::ARGBColors.Black;
			this.storedLabel6.Position = new Point(198, 1);
			this.storedLabel6.Size = new Size(97, 31);
			this.storedLabel6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine6.addControl(this.storedLabel6);
			this.storedLabel7.Text = "0";
			this.storedLabel7.Color = global::ARGBColors.Black;
			this.storedLabel7.Position = new Point(198, 1);
			this.storedLabel7.Size = new Size(97, 31);
			this.storedLabel7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine7.addControl(this.storedLabel7);
			this.storedLabel8.Text = "0";
			this.storedLabel8.Color = global::ARGBColors.Black;
			this.storedLabel8.Position = new Point(198, 1);
			this.storedLabel8.Size = new Size(97, 31);
			this.storedLabel8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine8.addControl(this.storedLabel8);
			this.priceLabel1.Text = "0";
			this.priceLabel1.Color = global::ARGBColors.Black;
			this.priceLabel1.Position = new Point(306, 1);
			this.priceLabel1.Size = new Size(77, 31);
			this.priceLabel1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine1.addControl(this.priceLabel1);
			this.priceLabel2.Text = "0";
			this.priceLabel2.Color = global::ARGBColors.Black;
			this.priceLabel2.Position = new Point(306, 1);
			this.priceLabel2.Size = new Size(77, 31);
			this.priceLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine2.addControl(this.priceLabel2);
			this.priceLabel3.Text = "0";
			this.priceLabel3.Color = global::ARGBColors.Black;
			this.priceLabel3.Position = new Point(306, 1);
			this.priceLabel3.Size = new Size(77, 31);
			this.priceLabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine3.addControl(this.priceLabel3);
			this.priceLabel4.Text = "0";
			this.priceLabel4.Color = global::ARGBColors.Black;
			this.priceLabel4.Position = new Point(306, 1);
			this.priceLabel4.Size = new Size(77, 31);
			this.priceLabel4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine4.addControl(this.priceLabel4);
			this.priceLabel5.Text = "0";
			this.priceLabel5.Color = global::ARGBColors.Black;
			this.priceLabel5.Position = new Point(306, 1);
			this.priceLabel5.Size = new Size(77, 31);
			this.priceLabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine5.addControl(this.priceLabel5);
			this.priceLabel6.Text = "0";
			this.priceLabel6.Color = global::ARGBColors.Black;
			this.priceLabel6.Position = new Point(306, 1);
			this.priceLabel6.Size = new Size(77, 31);
			this.priceLabel6.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine6.addControl(this.priceLabel6);
			this.priceLabel7.Text = "0";
			this.priceLabel7.Color = global::ARGBColors.Black;
			this.priceLabel7.Position = new Point(306, 1);
			this.priceLabel7.Size = new Size(77, 31);
			this.priceLabel7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine7.addControl(this.priceLabel7);
			this.priceLabel8.Text = "0";
			this.priceLabel8.Color = global::ARGBColors.Black;
			this.priceLabel8.Position = new Point(306, 1);
			this.priceLabel8.Size = new Size(77, 31);
			this.priceLabel8.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine8.addControl(this.priceLabel8);
			this.lastTab = -1;
			this.manageTabs(1);
			if (this.selectedStockExchange >= 0)
			{
				this.resetBackupData();
				this.selectStockExchange(this.selectedStockExchange);
				this.selectHighlightLine(0);
			}
			this.update();
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0000CC68 File Offset: 0x0000AE68
		public void update()
		{
			this.updateValues();
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x000B06F8 File Offset: 0x000AE8F8
		private void tabClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.lastTab)
				{
					this.manageTabs(csdbutton.Data);
				}
			}
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x000B0734 File Offset: 0x000AE934
		private void manageTabs(int tabID)
		{
			if (tabID != this.lastTab)
			{
				this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_normal;
				this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_over;
				if (tabID == 1)
				{
					this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_selected;
					this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_selected;
					this.selectHighlightLine(0);
					this.initStockpileTab();
					this.selectHighlightLine(0);
				}
				this.lastTab = tabID;
				base.Invalidate();
			}
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x000B07C4 File Offset: 0x000AE9C4
		private void selectHighlightLine(int line)
		{
			this.highlightLine1.Image = null;
			this.highlightLine2.Image = null;
			this.highlightLine3.Image = null;
			this.highlightLine4.Image = null;
			this.highlightLine5.Image = null;
			this.highlightLine6.Image = null;
			this.highlightLine7.Image = null;
			this.highlightLine8.Image = null;
			CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
			this.currentResource = rowButton.Data;
			CustomSelfDrawPanel.CSDImage rowHighlight = this.getRowHighlight(line);
			rowHighlight.Image = GFXLibrary.int_white_highlight_bar;
			rowHighlight.Size = new Size(400, 31);
			this.currentResourcePacketSize = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
			this.buyHeadingLabel.Text = SK.Text("CapitalTradePanel_Buy", "Buy") + " : " + VillageBuildingsData.getResourceNames(this.currentResource);
			this.buyHeadingImage.Image = GFXLibrary.getCommodity64DSImage(this.currentResource);
			this.buyTrack.Max = 50000;
			this.buyTrack.Value = 50000;
			this.showBuySellWindow();
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x000B08FC File Offset: 0x000AEAFC
		private void initStockpileTab()
		{
			this.highlightLine1.Visible = true;
			this.highlightLine2.Visible = true;
			this.highlightLine3.Visible = true;
			this.highlightLine4.Visible = true;
			this.highlightLine5.Visible = false;
			this.highlightLine6.Visible = false;
			this.highlightLine7.Visible = false;
			this.highlightLine8.Visible = false;
			this.setRowInfo(0, 6);
			this.setRowInfo(1, 7);
			this.setRowInfo(2, 8);
			this.setRowInfo(3, 9);
			this.setRowInfo(4, 12);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void initGranaryTab()
		{
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void initArmouryTab()
		{
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void initHallTab()
		{
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000B0994 File Offset: 0x000AEB94
		private void rowClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.currentResource)
				{
					this.buyTrack.Max = 50000;
					this.buyTrack.Value = 50000;
					GameEngine.Instance.playInterfaceSound("CapitalTradePanel_line_clicked");
					this.selectHighlightLine(this.getLineFromResource(csdbutton.Data));
					base.Invalidate();
				}
			}
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x000B0A0C File Offset: 0x000AEC0C
		private void setRowInfo(int line, int resource)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
			rowButton.ImageIcon = GFXLibrary.getCommodity32DSImage(resource);
			rowButton.Text.Text = VillageBuildingsData.getResourceNames(resource);
			rowButton.Data = resource;
			int num = GameEngine.Instance.LocalWorldData.traderCarryingLevels[resource];
			rowButton.Text2.Text = num.ToString("N", nfi);
			if (!(Program.mySettings.LanguageIdent == "pt"))
			{
				rowButton.Size = new Size(191, 38);
				rowButton.UseTextSize = false;
				rowButton.Text.Size = rowButton.Size;
				rowButton.Text.Position = new Point(91, 0);
				return;
			}
			if (resource == 22 || resource == 26)
			{
				rowButton.Size = new Size(191, 38);
				rowButton.UseTextSize = true;
				rowButton.Text.Size = new Size(100, 38);
				rowButton.Text.Position = new Point(91, 0);
				return;
			}
			rowButton.Size = new Size(191, 38);
			rowButton.UseTextSize = false;
			rowButton.Text.Size = rowButton.Size;
			rowButton.Text.Position = new Point(91, 0);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x000B0B5C File Offset: 0x000AED5C
		private int getLineFromResource(int resource)
		{
			for (int i = 0; i < 8; i++)
			{
				CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(i);
				if (rowButton.Data == resource)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x000B0B8C File Offset: 0x000AED8C
		private void setRowValues(int row, int localValue, int stockLevel, int priceValue)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			CustomSelfDrawPanel.CSDLabel rowLocal = this.getRowLocal(row);
			rowLocal.Text = "";
			if (localValue >= 0)
			{
				rowLocal.Text = localValue.ToString("N", nfi);
			}
			CustomSelfDrawPanel.CSDLabel rowStored = this.getRowStored(row);
			rowStored.Text = "";
			if (stockLevel >= 0)
			{
				rowStored.Text = stockLevel.ToString("N", nfi);
			}
			CustomSelfDrawPanel.CSDLabel rowPrice = this.getRowPrice(row);
			rowPrice.Text = "";
			if (priceValue >= 0)
			{
				rowPrice.Text = priceValue.ToString("N", nfi);
			}
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x000B0C20 File Offset: 0x000AEE20
		private CustomSelfDrawPanel.CSDButton getRowButton(int row)
		{
			switch (row)
			{
			case 0:
				return this.selectRow1;
			case 1:
				return this.selectRow2;
			case 2:
				return this.selectRow3;
			case 3:
				return this.selectRow4;
			case 4:
				return this.selectRow5;
			case 5:
				return this.selectRow6;
			case 6:
				return this.selectRow7;
			case 7:
				return this.selectRow8;
			default:
				return null;
			}
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x000B0C90 File Offset: 0x000AEE90
		private CustomSelfDrawPanel.CSDImage getRowHighlight(int row)
		{
			switch (row)
			{
			case 0:
				return this.highlightLine1;
			case 1:
				return this.highlightLine2;
			case 2:
				return this.highlightLine3;
			case 3:
				return this.highlightLine4;
			case 4:
				return this.highlightLine5;
			case 5:
				return this.highlightLine6;
			case 6:
				return this.highlightLine7;
			case 7:
				return this.highlightLine8;
			default:
				return null;
			}
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000B0D00 File Offset: 0x000AEF00
		private CustomSelfDrawPanel.CSDLabel getRowLocal(int row)
		{
			switch (row)
			{
			case 0:
				return this.localLabel1;
			case 1:
				return this.localLabel2;
			case 2:
				return this.localLabel3;
			case 3:
				return this.localLabel4;
			case 4:
				return this.localLabel5;
			case 5:
				return this.localLabel6;
			case 6:
				return this.localLabel7;
			case 7:
				return this.localLabel8;
			default:
				return null;
			}
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x000B0D70 File Offset: 0x000AEF70
		private CustomSelfDrawPanel.CSDLabel getRowStored(int row)
		{
			switch (row)
			{
			case 0:
				return this.storedLabel1;
			case 1:
				return this.storedLabel2;
			case 2:
				return this.storedLabel3;
			case 3:
				return this.storedLabel4;
			case 4:
				return this.storedLabel5;
			case 5:
				return this.storedLabel6;
			case 6:
				return this.storedLabel7;
			case 7:
				return this.storedLabel8;
			default:
				return null;
			}
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x000B0DE0 File Offset: 0x000AEFE0
		private CustomSelfDrawPanel.CSDLabel getRowPrice(int row)
		{
			switch (row)
			{
			case 0:
				return this.priceLabel1;
			case 1:
				return this.priceLabel2;
			case 2:
				return this.priceLabel3;
			case 3:
				return this.priceLabel4;
			case 4:
				return this.priceLabel5;
			case 5:
				return this.priceLabel6;
			case 6:
				return this.priceLabel7;
			case 7:
				return this.priceLabel8;
			default:
				return null;
			}
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0000CC70 File Offset: 0x0000AE70
		private CustomSelfDrawPanel.CSDButton getVillageHistory(int line)
		{
			return null;
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x000B0E50 File Offset: 0x000AF050
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				if (this.selectedStockExchange < 0)
				{
					this.selectStockExchange(village.VillageID);
				}
				CapitalTradePanel.StockExchangeInfo stockExchangeInfo = null;
				if (this.selectedStockExchange >= 0 && this.stockExchanges[this.selectedStockExchange] != null)
				{
					stockExchangeInfo = (CapitalTradePanel.StockExchangeInfo)this.stockExchanges[this.selectedStockExchange];
				}
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				int num = this.lastTab;
				if (num == 1)
				{
					VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels);
					VillageMap.InnLevels levels = new VillageMap.InnLevels();
					village.getInnLevels(levels);
					if (stockExchangeInfo == null)
					{
						this.setRowValues(0, (int)stockpileLevels.woodLevel, -1, -1);
						this.setRowValues(1, (int)stockpileLevels.stoneLevel, -1, -1);
						this.setRowValues(2, (int)stockpileLevels.ironLevel, -1, -1);
						this.setRowValues(3, (int)stockpileLevels.pitchLevel, -1, -1);
					}
					else
					{
						this.setRowValues(0, (int)stockpileLevels.woodLevel, stockExchangeInfo.woodLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(6), 6));
						this.setRowValues(1, (int)stockpileLevels.stoneLevel, stockExchangeInfo.stoneLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(7), 7));
						this.setRowValues(2, (int)stockpileLevels.ironLevel, stockExchangeInfo.ironLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(8), 8));
						this.setRowValues(3, (int)stockpileLevels.pitchLevel, stockExchangeInfo.pitchLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(9), 9));
					}
				}
			}
			else
			{
				for (int i = 0; i < 8; i++)
				{
					this.setRowValues(i, -1, -1, -1);
				}
			}
			this.showBuySellWindow();
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000B0FF4 File Offset: 0x000AF1F4
		private void showBuySellWindow()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			bool visible = this.buyWindow.Visible;
			this.buyWindow.Visible = false;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null && this.currentResource >= 0 && GameEngine.Instance.World.isUserVillage(village.VillageID) && this.selectedStockExchange >= 0 && this.stockExchanges[this.selectedStockExchange] != null)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				CapitalTradePanel.StockExchangeInfo stockExchangeInfo = (CapitalTradePanel.StockExchangeInfo)this.stockExchanges[this.selectedStockExchange];
				village.getResourceLevel(this.currentResource);
				int level = stockExchangeInfo.getLevel(this.currentResource);
				int num = TradingCalcs.calcGoldCost(localWorldData, level, this.currentResource, level + this.buyTrack.Value);
				if (level > 0)
				{
					this.buyWindow.Visible = true;
					int num2 = (int)GameEngine.Instance.World.getCurrentGold();
					int num3 = level;
					int num4 = num2 / num;
					int max = this.buyTrack.Max;
					if (num3 > max)
					{
						this.buyTrack.Max = num3;
					}
					else if (num3 < max)
					{
						if (this.buyTrack.Value > num3)
						{
							this.buyTrack.Value = num3;
						}
						this.buyTrack.Max = num3;
					}
					int num5 = this.buyTrack.Value * num / this.currentResourcePacketSize;
					if (num5 <= 0 && this.buyTrack.Value > 0)
					{
						num5 = 1;
					}
					this.buyCostValue.Text = num5.ToString("N", nfi);
					this.buyNumber.Text = this.buyTrack.Value.ToString("N", nfi);
					this.buyMax.Text = this.buyTrack.Max.ToString("N", nfi);
				}
			}
			this.validateBuySellButtons();
			if (visible != this.buyWindow.Visible)
			{
				this.mainBackgroundImage.invalidate();
			}
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0000CC73 File Offset: 0x0000AE73
		private void validateBuySellButtons()
		{
			if (this.buyWindow.Visible && this.buyTrack.Value > 0)
			{
				this.buyButton.Enabled = true;
				return;
			}
			this.buyButton.Enabled = false;
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x000B1204 File Offset: 0x000AF404
		private void findOnWorldClicked()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.BACKUP_resource = this.currentResource;
				this.BACKUP_buyLevel = this.buyTrack.Value;
				GameEngine.Instance.World.zoomToVillage(village.VillageID);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(4);
				InterfaceMgr.Instance.StockExchangeBuyingVillage = village.VillageID;
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0000CCA9 File Offset: 0x0000AEA9
		private void tracksMoved()
		{
			this.showBuySellWindow();
			this.buyWindow.invalidate();
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0000CCBC File Offset: 0x0000AEBC
		public void resetBackupData()
		{
			this.BACKUP_resource = -1;
			this.BACKUP_buyLevel = 50000;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x000B1274 File Offset: 0x000AF474
		public void selectStockExchange(int villageID)
		{
			if (villageID < 0)
			{
				this.selectedStockExchange = -1;
				return;
			}
			this.selectedStockExchange = villageID;
			RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.getStockExchangeDataCallback));
			RemoteServices.Instance.GetStockExchangeData(villageID, true);
			this.currentResource = this.BACKUP_resource;
			if (this.BACKUP_resource >= 0)
			{
				this.lastTab = -1;
				switch (this.BACKUP_resource)
				{
				case 6:
				case 7:
				case 8:
				case 9:
				case 12:
					this.manageTabs(1);
					break;
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					this.manageTabs(2);
					break;
				case 19:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
				case 26:
				case 33:
					this.manageTabs(4);
					break;
				case 28:
				case 29:
				case 30:
				case 31:
				case 32:
					this.manageTabs(3);
					break;
				}
				int lineFromResource = this.getLineFromResource(this.BACKUP_resource);
				this.selectHighlightLine(lineFromResource);
				this.buyTrack.Max = 500000;
				this.buyTrack.Value = this.BACKUP_buyLevel;
			}
			this.updateValues();
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0000CCD0 File Offset: 0x0000AED0
		private void floatingValueCB(int value)
		{
			this.buyTrack.Value = value;
			this.updateValues();
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x000B13B4 File Offset: 0x000AF5B4
		private void editSendValue()
		{
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.floatingValueCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(620 + base.Location.X + 217, 254 + base.Location.Y + 120 - 50));
			FloatingInput.open(point.X, point.Y, this.buyTrack.Value, this.buyTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x000B1454 File Offset: 0x000AF654
		private void buyClick()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				village.stockExchangeTrade(village.VillageID, this.currentResource, this.buyTrack.Value, true);
			}
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x000B1490 File Offset: 0x000AF690
		public void getStockExchangeDataCallback(GetStockExchangeData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				CapitalTradePanel.StockExchangeInfo stockExchangeInfo = new CapitalTradePanel.StockExchangeInfo();
				stockExchangeInfo.villageID = returnData.villageID;
				stockExchangeInfo.woodLevel = returnData.woodLevel;
				stockExchangeInfo.stoneLevel = returnData.stoneLevel;
				stockExchangeInfo.ironLevel = returnData.ironLevel;
				stockExchangeInfo.pitchLevel = returnData.pitchLevel;
				stockExchangeInfo.aleLevel = returnData.aleLevel;
				stockExchangeInfo.applesLevel = returnData.applesLevel;
				stockExchangeInfo.breadLevel = returnData.breadLevel;
				stockExchangeInfo.meatLevel = returnData.meatLevel;
				stockExchangeInfo.cheeseLevel = returnData.cheeseLevel;
				stockExchangeInfo.vegLevel = returnData.vegLevel;
				stockExchangeInfo.fishLevel = returnData.fishLevel;
				stockExchangeInfo.bowsLevel = returnData.bowsLevel;
				stockExchangeInfo.pikesLevel = returnData.pikesLevel;
				stockExchangeInfo.swordsLevel = returnData.swordsLevel;
				stockExchangeInfo.armourLevel = returnData.armourLevel;
				stockExchangeInfo.catapultsLevel = returnData.catapultsLevel;
				stockExchangeInfo.furnitureLevel = returnData.furnitureLevel;
				stockExchangeInfo.clothesLevel = returnData.clothesLevel;
				stockExchangeInfo.saltLevel = returnData.saltLevel;
				stockExchangeInfo.venisonLevel = returnData.venisonLevel;
				stockExchangeInfo.silkLevel = returnData.silkLevel;
				stockExchangeInfo.spicesLevel = returnData.spicesLevel;
				stockExchangeInfo.metalwareLevel = returnData.metalwareLevel;
				stockExchangeInfo.wineLevel = returnData.wineLevel;
				this.stockExchanges[returnData.villageID] = stockExchangeInfo;
				int lineFromResource = this.getLineFromResource(this.currentResource);
				this.selectHighlightLine(lineFromResource);
				this.updateValues();
			}
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0000CD04 File Offset: 0x0000AF04
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0000CD16 File Offset: 0x0000AF16
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0000CD23 File Offset: 0x0000AF23
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0000CD37 File Offset: 0x0000AF37
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0000CD44 File Offset: 0x0000AF44
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0000CD51 File Offset: 0x0000AF51
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x000B1608 File Offset: 0x000AF808
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalTradePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B98 RID: 2968
		public static CapitalTradePanel instance = null;

		// Token: 0x04000B99 RID: 2969
		private static List<WorldMap.VillageNameItem> exchangeHistory = new List<WorldMap.VillageNameItem>();

		// Token: 0x04000B9A RID: 2970
		private static List<WorldMap.VillageNameItem> exchangeFavourites = new List<WorldMap.VillageNameItem>();

		// Token: 0x04000B9B RID: 2971
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B9C RID: 2972
		private CustomSelfDrawPanel.CSDImage stockExchangeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B9D RID: 2973
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000B9E RID: 2974
		private CustomSelfDrawPanel.CSDLabel stockExchangeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B9F RID: 2975
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BA0 RID: 2976
		private CustomSelfDrawPanel.CSDExtendingPanel leftWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BA1 RID: 2977
		private CustomSelfDrawPanel.CSDExtendingPanel midWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BA2 RID: 2978
		private CustomSelfDrawPanel.CSDLabel buyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BA3 RID: 2979
		private CustomSelfDrawPanel.CSDImage buyHeadingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BA4 RID: 2980
		private CustomSelfDrawPanel.CSDExtendingPanel buyWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BA5 RID: 2981
		private CustomSelfDrawPanel.CSDExtendingPanel buySubWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BA6 RID: 2982
		private CustomSelfDrawPanel.CSDLabel buyNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BA7 RID: 2983
		private CustomSelfDrawPanel.CSDLabel buyCostLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BA8 RID: 2984
		private CustomSelfDrawPanel.CSDLabel buyCostValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BA9 RID: 2985
		private CustomSelfDrawPanel.CSDLabel buyTaxLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BAA RID: 2986
		private CustomSelfDrawPanel.CSDLabel buyMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BAB RID: 2987
		private CustomSelfDrawPanel.CSDLabel buyMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BAC RID: 2988
		private CustomSelfDrawPanel.CSDButton buyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BAD RID: 2989
		private CustomSelfDrawPanel.CSDTrackBar buyTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000BAE RID: 2990
		private CustomSelfDrawPanel.CSDButton sendEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BAF RID: 2991
		private CustomSelfDrawPanel.CSDLabel localHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BB0 RID: 2992
		private CustomSelfDrawPanel.CSDLabel storedHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BB1 RID: 2993
		private CustomSelfDrawPanel.CSDLabel BuyPriceHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BB2 RID: 2994
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BB3 RID: 2995
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea2 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BB4 RID: 2996
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea3 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000BB5 RID: 2997
		private CustomSelfDrawPanel.CSDButton tabButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BB6 RID: 2998
		private CustomSelfDrawPanel.CSDImage highlightLine1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BB7 RID: 2999
		private CustomSelfDrawPanel.CSDImage highlightLine2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BB8 RID: 3000
		private CustomSelfDrawPanel.CSDImage highlightLine3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BB9 RID: 3001
		private CustomSelfDrawPanel.CSDImage highlightLine4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BBA RID: 3002
		private CustomSelfDrawPanel.CSDImage highlightLine5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BBB RID: 3003
		private CustomSelfDrawPanel.CSDImage highlightLine6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BBC RID: 3004
		private CustomSelfDrawPanel.CSDImage highlightLine7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BBD RID: 3005
		private CustomSelfDrawPanel.CSDImage highlightLine8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000BBE RID: 3006
		private CustomSelfDrawPanel.CSDButton selectRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BBF RID: 3007
		private CustomSelfDrawPanel.CSDButton selectRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC0 RID: 3008
		private CustomSelfDrawPanel.CSDButton selectRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC1 RID: 3009
		private CustomSelfDrawPanel.CSDButton selectRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC2 RID: 3010
		private CustomSelfDrawPanel.CSDButton selectRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC3 RID: 3011
		private CustomSelfDrawPanel.CSDButton selectRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC4 RID: 3012
		private CustomSelfDrawPanel.CSDButton selectRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC5 RID: 3013
		private CustomSelfDrawPanel.CSDButton selectRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BC6 RID: 3014
		private CustomSelfDrawPanel.CSDLabel localLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BC7 RID: 3015
		private CustomSelfDrawPanel.CSDLabel localLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BC8 RID: 3016
		private CustomSelfDrawPanel.CSDLabel localLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BC9 RID: 3017
		private CustomSelfDrawPanel.CSDLabel localLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCA RID: 3018
		private CustomSelfDrawPanel.CSDLabel localLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCB RID: 3019
		private CustomSelfDrawPanel.CSDLabel localLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCC RID: 3020
		private CustomSelfDrawPanel.CSDLabel localLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCD RID: 3021
		private CustomSelfDrawPanel.CSDLabel localLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCE RID: 3022
		private CustomSelfDrawPanel.CSDLabel storedLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BCF RID: 3023
		private CustomSelfDrawPanel.CSDLabel storedLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD0 RID: 3024
		private CustomSelfDrawPanel.CSDLabel storedLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD1 RID: 3025
		private CustomSelfDrawPanel.CSDLabel storedLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD2 RID: 3026
		private CustomSelfDrawPanel.CSDLabel storedLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD3 RID: 3027
		private CustomSelfDrawPanel.CSDLabel storedLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD4 RID: 3028
		private CustomSelfDrawPanel.CSDLabel storedLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD5 RID: 3029
		private CustomSelfDrawPanel.CSDLabel storedLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD6 RID: 3030
		private CustomSelfDrawPanel.CSDLabel priceLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD7 RID: 3031
		private CustomSelfDrawPanel.CSDLabel priceLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD8 RID: 3032
		private CustomSelfDrawPanel.CSDLabel priceLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BD9 RID: 3033
		private CustomSelfDrawPanel.CSDLabel priceLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BDA RID: 3034
		private CustomSelfDrawPanel.CSDLabel priceLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BDB RID: 3035
		private CustomSelfDrawPanel.CSDLabel priceLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BDC RID: 3036
		private CustomSelfDrawPanel.CSDLabel priceLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BDD RID: 3037
		private CustomSelfDrawPanel.CSDLabel priceLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000BDE RID: 3038
		private CustomSelfDrawPanel.CSDButton worldMapButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000BDF RID: 3039
		private int selectedStockExchange = -1;

		// Token: 0x04000BE0 RID: 3040
		private int lastTab = -1;

		// Token: 0x04000BE1 RID: 3041
		private int currentResource = -1;

		// Token: 0x04000BE2 RID: 3042
		private int currentResourcePacketSize = 1;

		// Token: 0x04000BE3 RID: 3043
		private int BACKUP_resource = -1;

		// Token: 0x04000BE4 RID: 3044
		private int BACKUP_buyLevel;

		// Token: 0x04000BE5 RID: 3045
		public SparseArray stockExchanges = new SparseArray();

		// Token: 0x04000BE6 RID: 3046
		private DockableControl dockableControl;

		// Token: 0x04000BE7 RID: 3047
		private IContainer components;

		// Token: 0x02000108 RID: 264
		public class StockExchangeInfo
		{
			// Token: 0x06000863 RID: 2147 RVA: 0x000B1674 File Offset: 0x000AF874
			public int getLevel(int resource)
			{
				switch (resource)
				{
				case 6:
					return this.woodLevel;
				case 7:
					return this.stoneLevel;
				case 8:
					return this.ironLevel;
				case 9:
					return this.pitchLevel;
				case 12:
					return this.aleLevel;
				case 13:
					return this.applesLevel;
				case 14:
					return this.breadLevel;
				case 15:
					return this.vegLevel;
				case 16:
					return this.meatLevel;
				case 17:
					return this.cheeseLevel;
				case 18:
					return this.fishLevel;
				case 19:
					return this.clothesLevel;
				case 21:
					return this.furnitureLevel;
				case 22:
					return this.venisonLevel;
				case 23:
					return this.saltLevel;
				case 24:
					return this.spicesLevel;
				case 25:
					return this.silkLevel;
				case 26:
					return this.metalwareLevel;
				case 28:
					return this.pikesLevel;
				case 29:
					return this.bowsLevel;
				case 30:
					return this.swordsLevel;
				case 31:
					return this.armourLevel;
				case 32:
					return this.catapultsLevel;
				case 33:
					return this.wineLevel;
				}
				return 0;
			}

			// Token: 0x06000864 RID: 2148 RVA: 0x0000CD8C File Offset: 0x0000AF8C
			public int getFakeLevel(int resource)
			{
				return this.getLevel(resource);
			}

			// Token: 0x04000BE8 RID: 3048
			public int villageID = -1;

			// Token: 0x04000BE9 RID: 3049
			public int woodLevel;

			// Token: 0x04000BEA RID: 3050
			public int stoneLevel;

			// Token: 0x04000BEB RID: 3051
			public int ironLevel;

			// Token: 0x04000BEC RID: 3052
			public int pitchLevel;

			// Token: 0x04000BED RID: 3053
			public int aleLevel;

			// Token: 0x04000BEE RID: 3054
			public int applesLevel;

			// Token: 0x04000BEF RID: 3055
			public int breadLevel;

			// Token: 0x04000BF0 RID: 3056
			public int meatLevel;

			// Token: 0x04000BF1 RID: 3057
			public int cheeseLevel;

			// Token: 0x04000BF2 RID: 3058
			public int vegLevel;

			// Token: 0x04000BF3 RID: 3059
			public int fishLevel;

			// Token: 0x04000BF4 RID: 3060
			public int bowsLevel;

			// Token: 0x04000BF5 RID: 3061
			public int pikesLevel;

			// Token: 0x04000BF6 RID: 3062
			public int swordsLevel;

			// Token: 0x04000BF7 RID: 3063
			public int armourLevel;

			// Token: 0x04000BF8 RID: 3064
			public int catapultsLevel;

			// Token: 0x04000BF9 RID: 3065
			public int furnitureLevel;

			// Token: 0x04000BFA RID: 3066
			public int clothesLevel;

			// Token: 0x04000BFB RID: 3067
			public int saltLevel;

			// Token: 0x04000BFC RID: 3068
			public int venisonLevel;

			// Token: 0x04000BFD RID: 3069
			public int silkLevel;

			// Token: 0x04000BFE RID: 3070
			public int spicesLevel;

			// Token: 0x04000BFF RID: 3071
			public int metalwareLevel;

			// Token: 0x04000C00 RID: 3072
			public int wineLevel;
		}
	}
}
