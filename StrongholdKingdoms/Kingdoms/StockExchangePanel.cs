using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using StatTracking;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x02000497 RID: 1175
	public class StockExchangePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06002AC3 RID: 10947 RVA: 0x0001F84E File Offset: 0x0001DA4E
		public static List<WorldMap.VillageNameItem> ExchangeHistory
		{
			get
			{
				return StockExchangePanel.exchangeHistory;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06002AC4 RID: 10948 RVA: 0x0001F855 File Offset: 0x0001DA55
		public static List<WorldMap.VillageNameItem> ExchangeFavourites
		{
			get
			{
				return StockExchangePanel.exchangeFavourites;
			}
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x0001F85C File Offset: 0x0001DA5C
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002AC6 RID: 10950 RVA: 0x0001F86C File Offset: 0x0001DA6C
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002AC7 RID: 10951 RVA: 0x0001F87C File Offset: 0x0001DA7C
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002AC8 RID: 10952 RVA: 0x0001F88E File Offset: 0x0001DA8E
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x0001F89B File Offset: 0x0001DA9B
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x0001F8AF File Offset: 0x0001DAAF
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0001F8BC File Offset: 0x0001DABC
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x0001F8C9 File Offset: 0x0001DAC9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x0021593C File Offset: 0x00213B3C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "StockExchangePanel";
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06002ACE RID: 10958 RVA: 0x002159A8 File Offset: 0x00213BA8
		public static void addHistory(List<GenericVillageHistoryData> newData)
		{
			StockExchangePanel.exchangeHistory.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
					{
						villageNameItem.villageID = genericVillageHistoryData.villageID;
						StockExchangePanel.exchangeHistory.Add(villageNameItem);
					}
				}
			}
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x00215A30 File Offset: 0x00213C30
		public static void addFavourites(List<GenericVillageHistoryData> newData)
		{
			StockExchangePanel.exchangeFavourites.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					if (GameEngine.Instance.World.isCapital(genericVillageHistoryData.villageID))
					{
						villageNameItem.villageID = genericVillageHistoryData.villageID;
						StockExchangePanel.exchangeFavourites.Add(villageNameItem);
					}
				}
			}
		}

		// Token: 0x06002AD0 RID: 10960 RVA: 0x00215AB8 File Offset: 0x00213CB8
		public StockExchangePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002AD1 RID: 10961 RVA: 0x0021627C File Offset: 0x0021447C
		public void init()
		{
			this.lastPremiumType = GameEngine.Instance.World.isAccountPremium();
			StockExchangePanel.instance = this;
			base.clearControls();
			this.lastSeaConditions = -1;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("TRADE_Stock_Exchange", "Stock Exchange"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "StockExchangePanel_close");
			this.closeButton.CustomTooltipID = 800;
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 4, new Point(898, 10));
			this.midWindow.Size = new Size(293, 449);
			this.midWindow.Position = new Point(349, 74);
			this.mainBackgroundArea.addControl(this.midWindow);
			this.midWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.leftWindow.Size = new Size(335, 449);
			this.leftWindow.Position = new Point(19, 74);
			this.mainBackgroundArea.addControl(this.leftWindow);
			this.leftWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.newTradingButton.ImageNorm = GFXLibrary.se_tabs[2];
			this.newTradingButton.ImageOver = GFXLibrary.se_tabs[3];
			this.newTradingButton.ImageClick = GFXLibrary.se_tabs[3];
			this.newTradingButton.Position = new Point(20, -17);
			this.newTradingButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradingClick), "StockExchangePanel_trading");
			this.newTradingButton.ClickArea = new Rectangle(0, 0, 95, 25);
			this.newTradingButton.CustomTooltipID = 807;
			this.midWindow.addControl(this.newTradingButton);
			this.lightArea1.Size = new Size(97, 329);
			this.lightArea1.Position = new Point(216, 102);
			this.leftWindow.addControl(this.lightArea1);
			this.lightArea1.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.localHeadingLabel.Text = SK.Text("TRADE_Local", "Local");
			this.localHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.localHeadingLabel.Position = new Point(0, -35);
			this.localHeadingLabel.Size = new Size(97, 30);
			this.localHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.localHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea1.addControl(this.localHeadingLabel);
			this.lightArea2.Size = new Size(97, 329);
			this.lightArea2.Position = new Point(21, 102);
			this.midWindow.addControl(this.lightArea2);
			this.lightArea2.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.storedHeadingLabel.Text = SK.Text("TRADE_At_Exchange", "At Exchange");
			this.storedHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.storedHeadingLabel.Position = new Point(0, -35);
			this.storedHeadingLabel.Size = new Size(97, 30);
			this.storedHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.storedHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea2.addControl(this.storedHeadingLabel);
			this.lightArea3.Size = new Size(77, 329);
			this.lightArea3.Position = new Point(129, 102);
			this.midWindow.addControl(this.lightArea3);
			this.lightArea3.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.BuyPriceHeadingLabel.Text = SK.Text("TRADE_Price", "Price");
			this.BuyPriceHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.BuyPriceHeadingLabel.Position = new Point(0, -35);
			this.BuyPriceHeadingLabel.Size = new Size(77, 30);
			this.BuyPriceHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.BuyPriceHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea3.addControl(this.BuyPriceHeadingLabel);
			this.exchangeNameBar.Size = new Size(270, 31);
			this.exchangeNameBar.Position = new Point(11, 9);
			this.exchangeNameBar.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick));
			this.midWindow.addControl(this.exchangeNameBar);
			this.exchangeNameBar.Create(GFXLibrary.int_lineitem_inset_left, GFXLibrary.int_lineitem_inset_middle, GFXLibrary.int_lineitem_inset_right);
			this.exchangeNameLabel.Text = SK.Text("TRADE_Selected_Exchange", "Select Exchange");
			this.exchangeNameLabel.Color = Color.FromArgb(196, 161, 85);
			this.exchangeNameLabel.Position = new Point(17, 7);
			this.exchangeNameLabel.Size = new Size(this.exchangeNameBar.Size.Width - 17 - 20, this.exchangeNameBar.Size.Height - 13);
			this.exchangeNameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.exchangeNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.exchangeNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick));
			this.exchangeNameBar.addControl(this.exchangeNameLabel);
			this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.exchangeArrowButton.Position = new Point(246, 7);
			this.exchangeArrowButton.MoveOnClick = false;
			this.exchangeArrowButton.Data = 0;
			this.exchangeArrowButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick));
			this.exchangeNameBar.addControl(this.exchangeArrowButton);
			this.deliveryTimeArea.Size = new Size(258, 32);
			this.deliveryTimeArea.Position = new Point(16, 43);
			this.midWindow.addControl(this.deliveryTimeArea);
			this.deliveryTimeArea.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.deliveryTimeAreaLabel.Text = SK.Text("TRADE_Delivery_Time", "Delivery Time") + ":   88m 44s";
			this.deliveryTimeAreaLabel.Color = global::ARGBColors.Black;
			this.deliveryTimeAreaLabel.Position = new Point(0, 0);
			this.deliveryTimeAreaLabel.Size = this.deliveryTimeArea.Size;
			this.deliveryTimeAreaLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.deliveryTimeAreaLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.deliveryTimeArea.addControl(this.deliveryTimeAreaLabel);
			this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_normal;
			this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_over;
			this.tabButton1.Position = new Point(2, -13);
			this.tabButton1.MoveOnClick = false;
			this.tabButton1.Data = 1;
			this.tabButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "StockExchangePanel_resource_tab");
			this.tabButton1.CustomTooltipID = 802;
			this.leftWindow.addControl(this.tabButton1);
			this.tabButton2.ImageNorm = GFXLibrary.int_storage_tab_02_normal;
			this.tabButton2.ImageOver = GFXLibrary.int_storage_tab_02_over;
			this.tabButton2.Position = new Point(83, -13);
			this.tabButton2.MoveOnClick = false;
			this.tabButton2.Data = 2;
			this.tabButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "StockExchangePanel_food_tab");
			this.tabButton2.CustomTooltipID = 803;
			this.leftWindow.addControl(this.tabButton2);
			this.tabButton3.ImageNorm = GFXLibrary.int_storage_tab_03_normal;
			this.tabButton3.ImageOver = GFXLibrary.int_storage_tab_03_over;
			this.tabButton3.Position = new Point(161, -13);
			this.tabButton3.MoveOnClick = false;
			this.tabButton3.Data = 3;
			this.tabButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "StockExchangePanel_weapons_tab");
			this.tabButton3.CustomTooltipID = 804;
			this.leftWindow.addControl(this.tabButton3);
			this.tabButton4.ImageNorm = GFXLibrary.int_storage_tab_04_normal;
			this.tabButton4.ImageOver = GFXLibrary.int_storage_tab_04_over;
			this.tabButton4.Position = new Point(239, -13);
			this.tabButton4.MoveOnClick = false;
			this.tabButton4.Data = 4;
			this.tabButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "StockExchangePanel_banquetting_tab");
			this.tabButton4.CustomTooltipID = 805;
			this.leftWindow.addControl(this.tabButton4);
			this.buyWindow.Size = new Size(336, 145);
			this.buyWindow.Position = new Point(637, 74);
			this.mainBackgroundArea.addControl(this.buyWindow);
			this.buyWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.buySubWindow.Size = new Size(147, 50);
			this.buySubWindow.Position = new Point(178, 32);
			this.buyWindow.addControl(this.buySubWindow);
			this.buySubWindow.Create(GFXLibrary.int_insetpanel_b_top_left, GFXLibrary.int_insetpanel_b_middle_top, GFXLibrary.int_insetpanel_b_top_right, GFXLibrary.int_insetpanel_b_middle_left, GFXLibrary.int_insetpanel_b_middle, GFXLibrary.int_insetpanel_b_middle_right, GFXLibrary.int_insetpanel_b_bottom_left, GFXLibrary.int_insetpanel_b_middle_bottom, GFXLibrary.int_insetpanel_b_bottom_right);
			this.buyHeadingLabel.Text = SK.Text("TRADE_Buy", "Buy") + " ";
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
			this.buyButton.Position = new Point(177, 94);
			this.buyButton.Size = new Size(153, 38);
			this.buyButton.Text.Text = SK.Text("CapitalTradePanel_Buy", "Buy");
			this.buyButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buyButton.TextYOffset = -1;
			this.buyButton.Text.Color = global::ARGBColors.Black;
			this.buyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyClick), "StockExchangePanel_buy");
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
			this.sellWindow.Size = new Size(336, 145);
			this.sellWindow.Position = new Point(637, 272);
			this.mainBackgroundArea.addControl(this.sellWindow);
			this.sellWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.sellSubWindow.Size = new Size(147, 50);
			this.sellSubWindow.Position = new Point(178, 32);
			this.sellWindow.addControl(this.sellSubWindow);
			this.sellSubWindow.Create(GFXLibrary.int_insetpanel_b_top_left, GFXLibrary.int_insetpanel_b_middle_top, GFXLibrary.int_insetpanel_b_top_right, GFXLibrary.int_insetpanel_b_middle_left, GFXLibrary.int_insetpanel_b_middle, GFXLibrary.int_insetpanel_b_middle_right, GFXLibrary.int_insetpanel_b_bottom_left, GFXLibrary.int_insetpanel_b_middle_bottom, GFXLibrary.int_insetpanel_b_bottom_right);
			this.sellHeadingLabel.Text = SK.Text("CapitalTradePanel_Sell", "Sell") + " ";
			this.sellHeadingLabel.Color = global::ARGBColors.Black;
			this.sellHeadingLabel.Position = new Point(90, -30);
			this.sellHeadingLabel.Size = new Size(246, 30);
			this.sellHeadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.sellHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.sellWindow.addControl(this.sellHeadingLabel);
			this.sellHeadingImage.Image = null;
			this.sellHeadingImage.Position = new Point(5, -50);
			this.sellWindow.addControl(this.sellHeadingImage);
			this.sellCostLabel.Text = SK.Text("TRADE_Income", "Income") + ":";
			this.sellCostLabel.Color = Color.FromArgb(196, 161, 85);
			this.sellCostLabel.Position = new Point(-10, 13);
			this.sellCostLabel.Size = new Size(84, 30);
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.sellCostLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			}
			else
			{
				this.sellCostLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.sellCostLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sellSubWindow.addControl(this.sellCostLabel);
			this.sellNumber.Text = "0";
			this.sellNumber.Color = Color.FromArgb(196, 161, 85);
			this.sellNumber.Position = new Point(63, -4);
			this.sellNumber.Size = new Size(70, 30);
			this.sellNumber.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sellNumber.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sellSubWindow.addControl(this.sellNumber);
			this.sellCostValue.Text = "0";
			this.sellCostValue.Color = Color.FromArgb(196, 161, 85);
			this.sellCostValue.Position = new Point(63, 13);
			this.sellCostValue.Size = new Size(70, 30);
			this.sellCostValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sellCostValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sellSubWindow.addControl(this.sellCostValue);
			this.sellButton.Position = new Point(177, 94);
			this.sellButton.Size = new Size(153, 38);
			this.sellButton.Text.Text = SK.Text("CapitalTradePanel_Sell", "Sell");
			this.sellButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sellButton.TextYOffset = -1;
			this.sellButton.Text.Color = global::ARGBColors.Black;
			this.sellButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sellClick), "StockExchangePanel_sell");
			this.sellWindow.addControl(this.sellButton);
			this.sellButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.sellButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.sellTrack.Position = new Point(21, 41);
			this.sellTrack.Margin = new Rectangle(3, -1, 1, 0);
			this.sellTrack.Value = 0;
			this.sellTrack.Max = 1;
			this.sellTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.sellWindow.addControl(this.sellTrack);
			this.sellTrack.Create(GFXLibrary.int_slidebar_ruler, GFXLibrary.int_slidebar_thumb_middle_normal, GFXLibrary.int_slidebar_thumb_left_normal, GFXLibrary.int_slidebar_thumb_right_normal, GFXLibrary.int_slidebar_thumb_middle_in, GFXLibrary.int_slidebar_thumb_middle_over);
			this.sellMin.Text = "0";
			this.sellMin.Color = global::ARGBColors.Black;
			this.sellMin.Position = new Point(-2, 74);
			this.sellMin.Size = new Size(50, 30);
			this.sellMin.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.sellMin.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.sellWindow.addControl(this.sellMin);
			this.sellMax.Text = "0";
			this.sellMax.Color = global::ARGBColors.Black;
			this.sellMax.Position = new Point(126, 74);
			this.sellMax.Size = new Size(50, 30);
			this.sellMax.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.sellMax.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.sellWindow.addControl(this.sellMax);
			this.fourthAgeMessage.Text = SK.Text("TRADE_NO_WEAPONS_4TH_AGE", "Weapons cannot be bought or sold in this Age.");
			this.fourthAgeMessage.Color = Color.FromArgb(196, 161, 85);
			this.fourthAgeMessage.Position = new Point(16, 111);
			this.fourthAgeMessage.Size = new Size(300, 100);
			this.fourthAgeMessage.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.fourthAgeMessage.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.fourthAgeMessage.Visible = false;
			this.leftWindow.addControl(this.fourthAgeMessage);
			this.highlightLine1.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine1.Position = new Point(153, 111);
			this.highlightLine1.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine1);
			this.highlightLine2.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine2.Position = new Point(153, 151);
			this.highlightLine2.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine2);
			this.highlightLine3.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine3.Position = new Point(153, 191);
			this.highlightLine3.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine3);
			this.highlightLine4.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine4.Position = new Point(153, 231);
			this.highlightLine4.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine4);
			this.highlightLine5.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine5.Position = new Point(153, 271);
			this.highlightLine5.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine5);
			this.highlightLine6.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine6.Position = new Point(153, 311);
			this.highlightLine6.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine6);
			this.highlightLine7.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine7.Position = new Point(153, 351);
			this.highlightLine7.Size = new Size(465, 31);
			this.leftWindow.addControl(this.highlightLine7);
			this.highlightLine8.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine8.Position = new Point(153, 391);
			this.highlightLine8.Size = new Size(465, 31);
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
			this.highestPriceRow1.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow1.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow1.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow1.Position = new Point(389, -2);
			this.highestPriceRow1.Data = 0;
			this.highestPriceRow1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow1.CustomTooltipID = 814;
			this.highestPriceRow1.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow1.Alpha = (this.highestPriceRow1.Active ? 1f : 0.5f);
			this.highlightLine1.addControl(this.highestPriceRow1);
			this.highestPriceRow2.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow2.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow2.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow2.Position = new Point(389, -2);
			this.highestPriceRow2.Data = 1;
			this.highestPriceRow2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow2.CustomTooltipID = 814;
			this.highestPriceRow2.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow2.Alpha = (this.highestPriceRow2.Active ? 1f : 0.5f);
			this.highlightLine2.addControl(this.highestPriceRow2);
			this.highestPriceRow3.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow3.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow3.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow3.Position = new Point(389, -2);
			this.highestPriceRow3.Data = 2;
			this.highestPriceRow3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow3.CustomTooltipID = 814;
			this.highestPriceRow3.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow3.Alpha = (this.highestPriceRow3.Active ? 1f : 0.5f);
			this.highlightLine3.addControl(this.highestPriceRow3);
			this.highestPriceRow4.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow4.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow4.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow4.Position = new Point(389, -2);
			this.highestPriceRow4.Data = 3;
			this.highestPriceRow4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow4.CustomTooltipID = 814;
			this.highestPriceRow4.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow4.Alpha = (this.highestPriceRow4.Active ? 1f : 0.5f);
			this.highlightLine4.addControl(this.highestPriceRow4);
			this.highestPriceRow5.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow5.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow5.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow5.Position = new Point(389, -2);
			this.highestPriceRow5.Data = 4;
			this.highestPriceRow5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow5.CustomTooltipID = 814;
			this.highestPriceRow5.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow5.Alpha = (this.highestPriceRow5.Active ? 1f : 0.5f);
			this.highlightLine5.addControl(this.highestPriceRow5);
			this.highestPriceRow6.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow6.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow6.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow6.Position = new Point(389, -2);
			this.highestPriceRow6.Data = 5;
			this.highestPriceRow6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow6.CustomTooltipID = 814;
			this.highestPriceRow6.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow6.Alpha = (this.highestPriceRow6.Active ? 1f : 0.5f);
			this.highlightLine6.addControl(this.highestPriceRow6);
			this.highestPriceRow7.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow7.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow7.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow7.Position = new Point(389, -2);
			this.highestPriceRow7.Data = 6;
			this.highestPriceRow7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow7.CustomTooltipID = 814;
			this.highestPriceRow7.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow7.Alpha = (this.highestPriceRow7.Active ? 1f : 0.5f);
			this.highlightLine7.addControl(this.highestPriceRow7);
			this.highestPriceRow8.ImageNorm = GFXLibrary.int_hilow_buttons[0];
			this.highestPriceRow8.ImageOver = GFXLibrary.int_hilow_buttons[1];
			this.highestPriceRow8.ImageClick = GFXLibrary.int_hilow_buttons[2];
			this.highestPriceRow8.Position = new Point(389, -2);
			this.highestPriceRow8.Data = 7;
			this.highestPriceRow8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.highestPricedClicked));
			this.highestPriceRow8.CustomTooltipID = 814;
			this.highestPriceRow8.Active = GameEngine.Instance.World.isAccountPremium();
			this.highestPriceRow8.Alpha = (this.highestPriceRow8.Active ? 1f : 0.5f);
			this.highlightLine8.addControl(this.highestPriceRow8);
			this.lowestPriceRow1.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow1.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow1.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow1.Position = new Point(425, -2);
			this.lowestPriceRow1.Data = 0;
			this.lowestPriceRow1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow1.CustomTooltipID = 815;
			this.lowestPriceRow1.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow1.Alpha = (this.highestPriceRow1.Active ? 1f : 0.5f);
			this.highlightLine1.addControl(this.lowestPriceRow1);
			this.lowestPriceRow2.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow2.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow2.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow2.Position = new Point(425, -2);
			this.lowestPriceRow2.Data = 1;
			this.lowestPriceRow2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow2.CustomTooltipID = 815;
			this.lowestPriceRow2.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow2.Alpha = (this.lowestPriceRow2.Active ? 1f : 0.5f);
			this.highlightLine2.addControl(this.lowestPriceRow2);
			this.lowestPriceRow3.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow3.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow3.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow3.Position = new Point(425, -2);
			this.lowestPriceRow3.Data = 2;
			this.lowestPriceRow3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow3.CustomTooltipID = 815;
			this.lowestPriceRow3.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow3.Alpha = (this.lowestPriceRow3.Active ? 1f : 0.5f);
			this.highlightLine3.addControl(this.lowestPriceRow3);
			this.lowestPriceRow4.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow4.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow4.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow4.Position = new Point(425, -2);
			this.lowestPriceRow4.Data = 3;
			this.lowestPriceRow4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow4.CustomTooltipID = 815;
			this.lowestPriceRow4.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow4.Alpha = (this.lowestPriceRow4.Active ? 1f : 0.5f);
			this.highlightLine4.addControl(this.lowestPriceRow4);
			this.lowestPriceRow5.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow5.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow5.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow5.Position = new Point(425, -2);
			this.lowestPriceRow5.Data = 4;
			this.lowestPriceRow5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow5.CustomTooltipID = 815;
			this.lowestPriceRow5.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow5.Alpha = (this.lowestPriceRow5.Active ? 1f : 0.5f);
			this.highlightLine5.addControl(this.lowestPriceRow5);
			this.lowestPriceRow6.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow6.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow6.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow6.Position = new Point(425, -2);
			this.lowestPriceRow6.Data = 5;
			this.lowestPriceRow6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow6.CustomTooltipID = 815;
			this.lowestPriceRow6.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow6.Alpha = (this.lowestPriceRow6.Active ? 1f : 0.5f);
			this.highlightLine6.addControl(this.lowestPriceRow6);
			this.lowestPriceRow7.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow7.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow7.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow7.Position = new Point(425, -2);
			this.lowestPriceRow7.Data = 6;
			this.lowestPriceRow7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow7.CustomTooltipID = 815;
			this.lowestPriceRow7.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow7.Alpha = (this.lowestPriceRow7.Active ? 1f : 0.5f);
			this.highlightLine7.addControl(this.lowestPriceRow7);
			this.lowestPriceRow8.ImageNorm = GFXLibrary.int_hilow_buttons[3];
			this.lowestPriceRow8.ImageOver = GFXLibrary.int_hilow_buttons[4];
			this.lowestPriceRow8.ImageClick = GFXLibrary.int_hilow_buttons[5];
			this.lowestPriceRow8.Position = new Point(425, -2);
			this.lowestPriceRow8.Data = 7;
			this.lowestPriceRow8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lowestPricedClicked));
			this.lowestPriceRow8.CustomTooltipID = 815;
			this.lowestPriceRow8.Active = GameEngine.Instance.World.isAccountPremium();
			this.lowestPriceRow8.Alpha = (this.lowestPriceRow8.Active ? 1f : 0.5f);
			this.highlightLine8.addControl(this.lowestPriceRow8);
			this.infoWindow.Size = new Size(336, 65);
			this.infoWindow.Position = new Point(637, 459);
			this.mainBackgroundArea.addControl(this.infoWindow);
			this.infoWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.traderCapacityLabel.Text = SK.Text("MarketTradeScreen_Merchant_Capacity", "Merchant Capacity");
			this.traderCapacityLabel.Color = Color.FromArgb(196, 161, 85);
			this.traderCapacityLabel.Position = new Point(105, -1);
			this.traderCapacityLabel.Size = new Size(231, 30);
			this.traderCapacityLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.traderCapacityLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.infoWindow.addControl(this.traderCapacityLabel);
			this.traderCapacityValue.Text = "0";
			this.traderCapacityValue.Color = Color.FromArgb(196, 161, 85);
			this.traderCapacityValue.Position = new Point(232, -1);
			this.traderCapacityValue.Size = new Size(80, 30);
			this.traderCapacityValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.traderCapacityValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.infoWindow.addControl(this.traderCapacityValue);
			this.tradersAvailableLabel.Text = SK.Text("MarketTradeScreen_Merchant_Available", "Merchants Available");
			this.tradersAvailableLabel.Color = Color.FromArgb(196, 161, 85);
			this.tradersAvailableLabel.Position = new Point(105, 18);
			this.tradersAvailableLabel.Size = new Size(231, 30);
			this.tradersAvailableLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.tradersAvailableLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.infoWindow.addControl(this.tradersAvailableLabel);
			this.tradersAvailableValue.Text = "0";
			this.tradersAvailableValue.Color = Color.FromArgb(196, 161, 85);
			this.tradersAvailableValue.Position = new Point(232, 18);
			this.tradersAvailableValue.Size = new Size(80, 30);
			this.tradersAvailableValue.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.tradersAvailableValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.infoWindow.addControl(this.tradersAvailableValue);
			this.traderIconImage.Image = GFXLibrary.int_icon_trader;
			this.traderIconImage.Position = new Point(16, -26);
			this.infoWindow.addControl(this.traderIconImage);
			this.villageSelectPanel.Image = GFXLibrary.int_villagelist_panel;
			this.villageSelectPanel.Position = new Point(356, 109);
			this.villageSelectPanel.Visible = false;
			this.mainBackgroundArea.addControl(this.villageSelectPanel);
			this.villageSelectPanelHeader.Image = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectPanelHeader.Position = new Point(3, 3);
			this.villageSelectPanelHeader.Size = new Size(this.villageSelectPanel.Width - 14, this.villageSelectPanelHeader.Image.Height);
			this.villageSelectPanel.addControl(this.villageSelectPanelHeader);
			this.villageSelectPanelLabel.Text = SK.Text("MarketTradeScreen_Recent_Exchanges", "Recent Exchanges");
			this.villageSelectPanelLabel.Color = global::ARGBColors.Black;
			this.villageSelectPanelLabel.Position = new Point(5, -1);
			this.villageSelectPanelLabel.Size = new Size(this.villageSelectPanelHeader.Size.Width - 10, this.villageSelectPanelHeader.Size.Height);
			this.villageSelectPanelLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectPanelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectPanelHeader.addControl(this.villageSelectPanelLabel);
			this.villageSelectVillage1.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageNorm = null;
			this.villageSelectVillage1.Position = new Point(20, 21);
			this.villageSelectVillage1.Text.Text = "Village 1";
			this.villageSelectVillage1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage1.Text.Position = new Point(5, 0);
			this.villageSelectVillage1.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage1.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage1.TextYOffset = 0;
			this.villageSelectVillage1.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage1.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage1);
			this.villageSelectVillage1Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage1Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage1Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage1Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage1Delete.Position = new Point(255, 21);
			this.villageSelectVillage1Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage1Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage1Delete);
			this.villageSelectVillage1Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage1Favourite.OverBrighten = true;
			this.villageSelectVillage1Favourite.Position = new Point(1, 19);
			this.villageSelectVillage1Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage1Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage1Favourite);
			this.villageSelectVillage2.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageNorm = null;
			this.villageSelectVillage2.Position = new Point(20, 39);
			this.villageSelectVillage2.Text.Text = "Village 2";
			this.villageSelectVillage2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage2.Text.Position = new Point(5, 0);
			this.villageSelectVillage2.Text.Size = new Size(this.villageSelectVillage2.Width - 10, this.villageSelectVillage2.Height);
			this.villageSelectVillage2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage2.TextYOffset = 0;
			this.villageSelectVillage2.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage2.Data = 1;
			this.villageSelectPanel.addControl(this.villageSelectVillage2);
			this.villageSelectVillage2Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage2Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage2Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage2Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage2Delete.Position = new Point(255, 39);
			this.villageSelectVillage2Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage2Delete.Data = 1;
			this.villageSelectPanel.addControl(this.villageSelectVillage2Delete);
			this.villageSelectVillage2Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage2Favourite.OverBrighten = true;
			this.villageSelectVillage2Favourite.Position = new Point(1, 37);
			this.villageSelectVillage2Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage2Favourite.Data = 1;
			this.villageSelectPanel.addControl(this.villageSelectVillage2Favourite);
			this.villageSelectVillage3.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageNorm = null;
			this.villageSelectVillage3.Position = new Point(20, 57);
			this.villageSelectVillage3.Text.Text = "Village 3";
			this.villageSelectVillage3.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage3.Text.Position = new Point(5, 0);
			this.villageSelectVillage3.Text.Size = new Size(this.villageSelectVillage3.Width - 10, this.villageSelectVillage3.Height);
			this.villageSelectVillage3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage3.TextYOffset = 0;
			this.villageSelectVillage3.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage3.Data = 2;
			this.villageSelectPanel.addControl(this.villageSelectVillage3);
			this.villageSelectVillage3Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage3Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage3Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage3Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage3Delete.Position = new Point(255, 57);
			this.villageSelectVillage3Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage3Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage3Delete);
			this.villageSelectVillage3Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage3Favourite.OverBrighten = true;
			this.villageSelectVillage3Favourite.Position = new Point(1, 55);
			this.villageSelectVillage3Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage3Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage3Favourite);
			this.villageSelectVillage4.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageNorm = null;
			this.villageSelectVillage4.Position = new Point(20, 75);
			this.villageSelectVillage4.Text.Text = "Village 4";
			this.villageSelectVillage4.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage4.Text.Position = new Point(5, 0);
			this.villageSelectVillage4.Text.Size = new Size(this.villageSelectVillage4.Width - 10, this.villageSelectVillage4.Height);
			this.villageSelectVillage4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage4.TextYOffset = 0;
			this.villageSelectVillage4.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage4.Data = 3;
			this.villageSelectPanel.addControl(this.villageSelectVillage4);
			this.villageSelectVillage4Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage4Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage4Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage4Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage4Delete.Position = new Point(255, 75);
			this.villageSelectVillage4Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage4Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage4Delete);
			this.villageSelectVillage4Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage4Favourite.OverBrighten = true;
			this.villageSelectVillage4Favourite.Position = new Point(1, 73);
			this.villageSelectVillage4Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage4Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage4Favourite);
			this.villageSelectVillage5.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageNorm = null;
			this.villageSelectVillage5.Position = new Point(20, 93);
			this.villageSelectVillage5.Text.Text = "Village 5";
			this.villageSelectVillage5.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage5.Text.Position = new Point(5, 0);
			this.villageSelectVillage5.Text.Size = new Size(this.villageSelectVillage5.Width - 10, this.villageSelectVillage5.Height);
			this.villageSelectVillage5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage5.TextYOffset = 0;
			this.villageSelectVillage5.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage5.Data = 4;
			this.villageSelectPanel.addControl(this.villageSelectVillage5);
			this.villageSelectVillage5Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage5Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage5Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage5Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage5Delete.Position = new Point(255, 93);
			this.villageSelectVillage5Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage5Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage5Delete);
			this.villageSelectVillage5Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage5Favourite.OverBrighten = true;
			this.villageSelectVillage5Favourite.Position = new Point(1, 91);
			this.villageSelectVillage5Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage5Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage5Favourite);
			this.villageSelectVillage6.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageNorm = null;
			this.villageSelectVillage6.Position = new Point(20, 111);
			this.villageSelectVillage6.Text.Text = "Village 6";
			this.villageSelectVillage6.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage6.Text.Position = new Point(5, 0);
			this.villageSelectVillage6.Text.Size = new Size(this.villageSelectVillage6.Width - 10, this.villageSelectVillage6.Height);
			this.villageSelectVillage6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage6.TextYOffset = 0;
			this.villageSelectVillage6.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage6.Data = 5;
			this.villageSelectPanel.addControl(this.villageSelectVillage6);
			this.villageSelectVillage6Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage6Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage6Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage6Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage6Delete.Position = new Point(255, 111);
			this.villageSelectVillage6Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage6Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage6Delete);
			this.villageSelectVillage6Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage6Favourite.OverBrighten = true;
			this.villageSelectVillage6Favourite.Position = new Point(1, 109);
			this.villageSelectVillage6Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage6Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage6Favourite);
			this.villageSelectVillage7.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageNorm = null;
			this.villageSelectVillage7.Position = new Point(20, 129);
			this.villageSelectVillage7.Text.Text = "Village 7";
			this.villageSelectVillage7.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage7.Text.Position = new Point(5, 0);
			this.villageSelectVillage7.Text.Size = new Size(this.villageSelectVillage7.Width - 10, this.villageSelectVillage7.Height);
			this.villageSelectVillage7.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage7.TextYOffset = 0;
			this.villageSelectVillage7.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage7.Data = 6;
			this.villageSelectPanel.addControl(this.villageSelectVillage7);
			this.villageSelectVillage7Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage7Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage7Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage7Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage7Delete.Position = new Point(255, 129);
			this.villageSelectVillage7Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage7Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage7Delete);
			this.villageSelectVillage7Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage7Favourite.OverBrighten = true;
			this.villageSelectVillage7Favourite.Position = new Point(1, 127);
			this.villageSelectVillage7Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage7Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage7Favourite);
			this.villageSelectVillage8.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageNorm = null;
			this.villageSelectVillage8.Position = new Point(20, 147);
			this.villageSelectVillage8.Text.Text = "Village 8";
			this.villageSelectVillage8.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage8.Text.Position = new Point(5, 0);
			this.villageSelectVillage8.Text.Size = new Size(this.villageSelectVillage8.Width - 10, this.villageSelectVillage8.Height);
			this.villageSelectVillage8.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage8.TextYOffset = 0;
			this.villageSelectVillage8.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage8.Data = 7;
			this.villageSelectPanel.addControl(this.villageSelectVillage8);
			this.villageSelectVillage8Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage8Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage8Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage8Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage8Delete.Position = new Point(255, 147);
			this.villageSelectVillage8Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage8Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage8Delete);
			this.villageSelectVillage8Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage8Favourite.OverBrighten = true;
			this.villageSelectVillage8Favourite.Position = new Point(1, 145);
			this.villageSelectVillage8Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage8Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage8Favourite);
			this.villageSelectVillage9.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageNorm = null;
			this.villageSelectVillage9.Position = new Point(20, 165);
			this.villageSelectVillage9.Text.Text = "Village 9";
			this.villageSelectVillage9.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage9.Text.Position = new Point(5, 0);
			this.villageSelectVillage9.Text.Size = new Size(this.villageSelectVillage9.Width - 10, this.villageSelectVillage9.Height);
			this.villageSelectVillage9.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage9.TextYOffset = 0;
			this.villageSelectVillage9.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage9.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage9.Data = 8;
			this.villageSelectPanel.addControl(this.villageSelectVillage9);
			this.villageSelectVillage9Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage9Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage9Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage9Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage9Delete.Position = new Point(255, 165);
			this.villageSelectVillage9Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage9Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage9Delete);
			this.villageSelectVillage9Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage9Favourite.OverBrighten = true;
			this.villageSelectVillage9Favourite.Position = new Point(1, 163);
			this.villageSelectVillage9Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage9Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage9Favourite);
			this.villageSelectVillage10.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageNorm = null;
			this.villageSelectVillage10.Position = new Point(20, 183);
			this.villageSelectVillage10.Text.Text = "Village 10";
			this.villageSelectVillage10.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage10.Text.Position = new Point(5, 0);
			this.villageSelectVillage10.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage10.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage10.TextYOffset = 0;
			this.villageSelectVillage10.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage10.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage10.Data = 9;
			this.villageSelectPanel.addControl(this.villageSelectVillage10);
			this.villageSelectVillage10Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage10Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage10Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage10Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage10Delete.Position = new Point(255, 183);
			this.villageSelectVillage10Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage10Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage10Delete);
			this.villageSelectVillage10Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage10Favourite.OverBrighten = true;
			this.villageSelectVillage10Favourite.Position = new Point(1, 181);
			this.villageSelectVillage10Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage10Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage10Favourite);
			this.villageSelectVillage11.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageNorm = null;
			this.villageSelectVillage11.Position = new Point(20, 201);
			this.villageSelectVillage11.Text.Text = "Village 11";
			this.villageSelectVillage11.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage11.Text.Position = new Point(5, 0);
			this.villageSelectVillage11.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage11.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage11.TextYOffset = 0;
			this.villageSelectVillage11.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage11.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage11.Data = 10;
			this.villageSelectPanel.addControl(this.villageSelectVillage11);
			this.villageSelectVillage11Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage11Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage11Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage11Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage11Delete.Position = new Point(255, 201);
			this.villageSelectVillage11Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage11Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage11Delete);
			this.villageSelectVillage11Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage11Favourite.OverBrighten = true;
			this.villageSelectVillage11Favourite.Position = new Point(1, 199);
			this.villageSelectVillage11Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage11Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage11Favourite);
			this.villageSelectVillage12.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageNorm = null;
			this.villageSelectVillage12.Position = new Point(20, 219);
			this.villageSelectVillage12.Text.Text = "Village 12";
			this.villageSelectVillage12.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage12.Text.Position = new Point(5, 0);
			this.villageSelectVillage12.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage12.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage12.TextYOffset = 0;
			this.villageSelectVillage12.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage12.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage12.Data = 11;
			this.villageSelectPanel.addControl(this.villageSelectVillage12);
			this.villageSelectVillage12Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage12Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage12Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage12Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage12Delete.Position = new Point(255, 219);
			this.villageSelectVillage12Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage12Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage12Delete);
			this.villageSelectVillage12Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage12Favourite.OverBrighten = true;
			this.villageSelectVillage12Favourite.Position = new Point(1, 217);
			this.villageSelectVillage12Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage12Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage12Favourite);
			this.villageSelectVillage13.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageNorm = null;
			this.villageSelectVillage13.Position = new Point(20, 237);
			this.villageSelectVillage13.Text.Text = "Village 13";
			this.villageSelectVillage13.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage13.Text.Position = new Point(5, 0);
			this.villageSelectVillage13.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage13.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage13.TextYOffset = 0;
			this.villageSelectVillage13.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage13.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage13.Data = 12;
			this.villageSelectPanel.addControl(this.villageSelectVillage13);
			this.villageSelectVillage13Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage13Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage13Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage13Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage13Delete.Position = new Point(255, 237);
			this.villageSelectVillage13Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage13Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage13Delete);
			this.villageSelectVillage13Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage13Favourite.OverBrighten = true;
			this.villageSelectVillage13Favourite.Position = new Point(1, 235);
			this.villageSelectVillage13Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage13Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage13Favourite);
			this.villageSelectVillage14.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageNorm = null;
			this.villageSelectVillage14.Position = new Point(20, 255);
			this.villageSelectVillage14.Text.Text = "Village 14";
			this.villageSelectVillage14.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage14.Text.Position = new Point(5, 0);
			this.villageSelectVillage14.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage14.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage14.TextYOffset = 0;
			this.villageSelectVillage14.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage14.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage14.Data = 13;
			this.villageSelectPanel.addControl(this.villageSelectVillage14);
			this.villageSelectVillage14Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage14Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage14Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage14Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage14Delete.Position = new Point(255, 255);
			this.villageSelectVillage14Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage14Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage14Delete);
			this.villageSelectVillage14Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage14Favourite.OverBrighten = true;
			this.villageSelectVillage14Favourite.Position = new Point(1, 253);
			this.villageSelectVillage14Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage14Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage14Favourite);
			this.villageSelectVillage15.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageNorm = null;
			this.villageSelectVillage15.Position = new Point(20, 273);
			this.villageSelectVillage15.Text.Text = "Village 15";
			this.villageSelectVillage15.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage15.Text.Position = new Point(5, 0);
			this.villageSelectVillage15.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage15.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage15.TextYOffset = 0;
			this.villageSelectVillage15.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage15.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage15.Data = 14;
			this.villageSelectPanel.addControl(this.villageSelectVillage15);
			this.villageSelectVillage15Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage15Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage15Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage15Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage15Delete.Position = new Point(255, 273);
			this.villageSelectVillage15Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage15Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage15Delete);
			this.villageSelectVillage15Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage15Favourite.OverBrighten = true;
			this.villageSelectVillage15Favourite.Position = new Point(1, 271);
			this.villageSelectVillage15Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage15Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage15Favourite);
			this.villageSelectVillage16.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageNorm = null;
			this.villageSelectVillage16.Position = new Point(20, 291);
			this.villageSelectVillage16.Text.Text = "Village 16";
			this.villageSelectVillage16.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage16.Text.Position = new Point(5, 0);
			this.villageSelectVillage16.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage16.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage16.TextYOffset = 0;
			this.villageSelectVillage16.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage16.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage16.Data = 15;
			this.villageSelectPanel.addControl(this.villageSelectVillage16);
			this.villageSelectVillage16Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage16Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage16Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage16Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage16Delete.Position = new Point(255, 291);
			this.villageSelectVillage16Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage16Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage16Delete);
			this.villageSelectVillage16Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage16Favourite.OverBrighten = true;
			this.villageSelectVillage16Favourite.Position = new Point(1, 289);
			this.villageSelectVillage16Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage16Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage16Favourite);
			this.villageSelectVillage17.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageNorm = null;
			this.villageSelectVillage17.Position = new Point(20, 309);
			this.villageSelectVillage17.Text.Text = "Village 17";
			this.villageSelectVillage17.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage17.Text.Position = new Point(5, 0);
			this.villageSelectVillage17.Text.Size = new Size(this.villageSelectVillage1.Width - 10, this.villageSelectVillage1.Height);
			this.villageSelectVillage17.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage17.TextYOffset = 0;
			this.villageSelectVillage17.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage17.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage17.Data = 16;
			this.villageSelectPanel.addControl(this.villageSelectVillage17);
			this.villageSelectVillage17Delete.ImageNorm = GFXLibrary.trashcan_normal;
			this.villageSelectVillage17Delete.ImageOver = GFXLibrary.trashcan_over;
			this.villageSelectVillage17Delete.ImageClick = GFXLibrary.trashcan_clicked;
			this.villageSelectVillage17Delete.Size = new Size(GFXLibrary.trashcan_normal.Width * 3 / 4, GFXLibrary.trashcan_normal.Height * 3 / 4);
			this.villageSelectVillage17Delete.Position = new Point(255, 309);
			this.villageSelectVillage17Delete.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageRecentDeleteClicked), "FactionNewForumPanel_delete_thread");
			this.villageSelectVillage17Delete.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage17Delete);
			this.villageSelectVillage17Favourite.ImageNorm = GFXLibrary.star_market_1;
			this.villageSelectVillage17Favourite.OverBrighten = true;
			this.villageSelectVillage17Favourite.Position = new Point(1, 307);
			this.villageSelectVillage17Favourite.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageFavouriteClicked));
			this.villageSelectVillage17Favourite.Data = 0;
			this.villageSelectPanel.addControl(this.villageSelectVillage17Favourite);
			this.worldMapButton.ImageNorm = GFXLibrary.int_button_findonmap_normal;
			this.worldMapButton.ImageOver = GFXLibrary.int_button_findonmap_over;
			this.worldMapButton.ImageClick = GFXLibrary.int_button_findonmap_in;
			this.worldMapButton.Position = new Point(56, 344);
			this.worldMapButton.Text.Text = SK.Text("MarketTradeScreen_Find_On_Map", "Find on map");
			this.worldMapButton.TextYOffset = -5;
			this.worldMapButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.worldMapButton.Text.Color = global::ARGBColors.Black;
			this.worldMapButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.findOnWorldClicked), "StockExchangePanel_find_on_map");
			this.villageSelectPanel.addControl(this.worldMapButton);
			if (GameEngine.Instance.World.UserResearchData.Research_Merchant_Guilds == 0)
			{
				this.leftWindow.Visible = false;
				this.midWindow.Visible = false;
				this.buyWindow.Visible = false;
				this.sellWindow.Visible = false;
				this.infoWindow.Visible = false;
				this.noResearchWindow.Size = new Size(739, 150);
				this.noResearchWindow.Position = new Point(126, (base.Height - 150) / 2);
				this.mainBackgroundImage.addControl(this.noResearchWindow);
				this.noResearchWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
				this.noResearchText.Text = SK.Text("Trade_Need_Research", "You don't currently have the required 'Merchant Guilds' research level to trade with other villages and exchanges. To begin trading you must research 'Merchant Guilds', place a Market in your village and recruit at least one Merchant.");
				this.noResearchText.Color = Color.FromArgb(224, 203, 146);
				this.noResearchText.Position = new Point(20, 0);
				this.noResearchText.Size = new Size(this.noResearchWindow.Width - 40, this.noResearchWindow.Height);
				this.noResearchText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.noResearchText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.noResearchWindow.addControl(this.noResearchText);
				this.currentResource = -1;
			}
			else
			{
				this.leftWindow.Visible = true;
				this.midWindow.Visible = true;
				this.buyWindow.Visible = true;
				this.sellWindow.Visible = true;
				this.infoWindow.Visible = true;
			}
			this.advancedOptions.CheckedImage = GFXLibrary.mrhp_world_filter_check[0];
			this.advancedOptions.UncheckedImage = GFXLibrary.mrhp_world_filter_check[1];
			this.advancedOptions.Position = new Point(20, 450);
			this.advancedOptions.Checked = Program.mySettings.AdvancedTrading;
			this.advancedOptions.CBLabel.Text = SK.Text("StockExchangePanel_advanced_options", "Show Advanced Trade Options");
			this.advancedOptions.CBLabel.Color = global::ARGBColors.Black;
			this.advancedOptions.CBLabel.Position = new Point(20, -1);
			this.advancedOptions.CBLabel.Size = new Size(this.midWindow.Width, 35);
			this.advancedOptions.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.advancedOptions.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.advancedToggle));
			this.midWindow.addControl(this.advancedOptions);
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundArea.addControl(this.cardbar);
			this.cardbar.init(1);
			this.updateExchangeHistory();
			this.seaConditionsImage.Image = GFXLibrary.sea_conditions[0];
			this.seaConditionsImage.Position = new Point(328, 112);
			this.seaConditionsImage.CustomTooltipID = 23000;
			this.seaConditionsImage.Visible = false;
			this.mainBackgroundArea.addControl(this.seaConditionsImage);
			this.lastTab = -1;
			this.manageTabs(1);
			this.updateDeliveryTime(-1);
			if (this.selectedStockExchange >= 0)
			{
				this.resetBackupData();
				this.selectStockExchange(this.selectedStockExchange);
				this.selectHighlightLine(0);
			}
			this.updateAdvancedOptions();
			this.update();
		}

		// Token: 0x06002AD2 RID: 10962 RVA: 0x0021D8CC File Offset: 0x0021BACC
		public void update()
		{
			if (this.currentResource >= 0)
			{
				this.currentResourcePacketSize = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
				this.currentResourcePacketSizeREAL = this.currentResourcePacketSize;
				this.currentResourcePacketSize = CardTypes.adjustTraderCarryLevels(GameEngine.Instance.cardsManager.UserCardData, this.currentResourcePacketSize);
			}
			this.updateValues();
			this.cardbar.update();
			this.updateDeliveryTime(this.selectedStockExchange);
			if (this.lastPremiumType != GameEngine.Instance.World.isAccountPremium())
			{
				this.lastPremiumType = GameEngine.Instance.World.isAccountPremium();
				this.updateAdvancedOptions();
			}
		}

		// Token: 0x06002AD3 RID: 10963 RVA: 0x0021D97C File Offset: 0x0021BB7C
		private void updateAdvancedOptions()
		{
			if (GameEngine.Instance.World.isAccountPremium() && Program.mySettings.AdvancedTrading)
			{
				for (int i = 0; i < 8; i++)
				{
					CustomSelfDrawPanel.CSDButton rowHighestButton = this.getRowHighestButton(i);
					CustomSelfDrawPanel.CSDButton rowLowestButton = this.getRowLowestButton(i);
					CustomSelfDrawPanel.CSDLabel rowStored = this.getRowStored(i);
					CustomSelfDrawPanel.CSDLabel rowPrice = this.getRowPrice(i);
					if (rowPrice.Text.Length > 0)
					{
						rowHighestButton.Visible = true;
						rowLowestButton.Visible = true;
					}
					else
					{
						rowHighestButton.Visible = false;
						rowLowestButton.Visible = false;
					}
					rowStored.Position = new Point(198, 1);
					rowPrice.Position = new Point(306, 1);
				}
				this.lightArea2.Position = new Point(21, 102);
				this.lightArea3.Position = new Point(129, 102);
			}
			else
			{
				for (int j = 0; j < 8; j++)
				{
					CustomSelfDrawPanel.CSDButton rowHighestButton2 = this.getRowHighestButton(j);
					rowHighestButton2.Visible = false;
					CustomSelfDrawPanel.CSDButton rowLowestButton2 = this.getRowLowestButton(j);
					rowLowestButton2.Visible = false;
					CustomSelfDrawPanel.CSDLabel rowStored2 = this.getRowStored(j);
					rowStored2.Position = new Point(230, 1);
					CustomSelfDrawPanel.CSDLabel rowPrice2 = this.getRowPrice(j);
					rowPrice2.Position = new Point(338, 1);
				}
				this.lightArea2.Position = new Point(53, 102);
				this.lightArea3.Position = new Point(161, 102);
			}
			this.advancedOptions.Visible = GameEngine.Instance.World.isAccountPremium();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06002AD4 RID: 10964 RVA: 0x0001F8E8 File Offset: 0x0001DAE8
		private void advancedToggle()
		{
			if (this.advancedOptions.Checked)
			{
				StatTrackingClient.Instance().ActivateTrigger(10, 0);
			}
			Program.mySettings.AdvancedTrading = this.advancedOptions.Checked;
			this.updateAdvancedOptions();
		}

		// Token: 0x06002AD5 RID: 10965 RVA: 0x0021DB18 File Offset: 0x0021BD18
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

		// Token: 0x06002AD6 RID: 10966 RVA: 0x0001F924 File Offset: 0x0001DB24
		public void logout()
		{
			this.selectedStockExchange = -1;
		}

		// Token: 0x06002AD7 RID: 10967 RVA: 0x0021DB54 File Offset: 0x0021BD54
		private void manageTabs(int tabID)
		{
			if (tabID != this.lastTab)
			{
				this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_normal;
				this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_over;
				this.tabButton2.ImageNorm = GFXLibrary.int_storage_tab_02_normal;
				this.tabButton2.ImageOver = GFXLibrary.int_storage_tab_02_over;
				this.tabButton3.ImageNorm = GFXLibrary.int_storage_tab_03_normal;
				this.tabButton3.ImageOver = GFXLibrary.int_storage_tab_03_over;
				this.tabButton4.ImageNorm = GFXLibrary.int_storage_tab_04_normal;
				this.tabButton4.ImageOver = GFXLibrary.int_storage_tab_04_over;
				this.fourthAgeMessage.Visible = false;
				this.localHeadingLabel.Visible = true;
				this.lightArea1.Visible = true;
				switch (tabID)
				{
				case 1:
					this.tabButton1.ImageNorm = GFXLibrary.int_storage_tab_01_selected;
					this.tabButton1.ImageOver = GFXLibrary.int_storage_tab_01_selected;
					this.selectHighlightLine(0);
					this.initStockpileTab();
					this.selectHighlightLine(0);
					break;
				case 2:
					this.tabButton2.ImageNorm = GFXLibrary.int_storage_tab_02_selected;
					this.tabButton2.ImageOver = GFXLibrary.int_storage_tab_02_selected;
					this.selectHighlightLine(0);
					this.initGranaryTab();
					this.selectHighlightLine(0);
					break;
				case 3:
					this.tabButton3.ImageNorm = GFXLibrary.int_storage_tab_03_selected;
					this.tabButton3.ImageOver = GFXLibrary.int_storage_tab_03_selected;
					this.selectHighlightLine(0);
					this.initArmouryTab();
					this.selectHighlightLine(0);
					break;
				case 4:
					this.tabButton4.ImageNorm = GFXLibrary.int_storage_tab_04_selected;
					this.tabButton4.ImageOver = GFXLibrary.int_storage_tab_04_selected;
					this.selectHighlightLine(0);
					this.initHallTab();
					this.selectHighlightLine(0);
					break;
				}
				this.lastTab = tabID;
				base.Invalidate();
			}
		}

		// Token: 0x06002AD8 RID: 10968 RVA: 0x0021DD64 File Offset: 0x0021BF64
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
			rowHighlight.Size = new Size(465, 31);
			this.currentResourcePacketSize = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
			this.currentResourcePacketSizeREAL = this.currentResourcePacketSize;
			this.currentResourcePacketSize = CardTypes.adjustTraderCarryLevels(GameEngine.Instance.cardsManager.UserCardData, this.currentResourcePacketSize);
			this.buyHeadingLabel.Text = SK.Text("CapitalTradePanel_Buy", "Buy") + " : " + VillageBuildingsData.getResourceNames(this.currentResource);
			this.sellHeadingLabel.Text = SK.Text("CapitalTradePanel_Sell", "Sell") + " : " + VillageBuildingsData.getResourceNames(this.currentResource);
			this.buyHeadingImage.Image = GFXLibrary.getCommodity64DSImage(this.currentResource);
			this.sellHeadingImage.Image = GFXLibrary.getCommodity64DSImage(this.currentResource);
			this.buyTrack.Max = 50000;
			this.sellTrack.Max = 50000;
			if (this.lastHighlightResource != this.currentResource)
			{
				this.lastHighlightResource = this.currentResource;
				this.buyTrack.Value = 50000;
				this.sellTrack.Value = 50000;
			}
			this.showBuySellWindow();
		}

		// Token: 0x06002AD9 RID: 10969 RVA: 0x0021DF4C File Offset: 0x0021C14C
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
		}

		// Token: 0x06002ADA RID: 10970 RVA: 0x0021DFDC File Offset: 0x0021C1DC
		private void initGranaryTab()
		{
			this.highlightLine1.Visible = true;
			this.highlightLine2.Visible = true;
			this.highlightLine3.Visible = true;
			this.highlightLine4.Visible = true;
			this.highlightLine5.Visible = true;
			this.highlightLine6.Visible = true;
			this.highlightLine7.Visible = true;
			this.highlightLine8.Visible = false;
			this.setRowInfo(0, 13);
			this.setRowInfo(1, 17);
			this.setRowInfo(2, 16);
			this.setRowInfo(3, 14);
			this.setRowInfo(4, 15);
			this.setRowInfo(5, 18);
			this.setRowInfo(6, 12);
		}

		// Token: 0x06002ADB RID: 10971 RVA: 0x0021E088 File Offset: 0x0021C288
		private void initArmouryTab()
		{
			if (!GameEngine.Instance.LocalWorldData.EraWorld && GameEngine.Instance.World.FourthAgeWorld && !GameEngine.Instance.World.SixthAgeWorld)
			{
				this.highlightLine1.Visible = false;
				this.highlightLine2.Visible = false;
				this.highlightLine3.Visible = false;
				this.highlightLine4.Visible = false;
				this.highlightLine5.Visible = false;
				this.highlightLine6.Visible = false;
				this.highlightLine7.Visible = false;
				this.highlightLine8.Visible = false;
				this.fourthAgeMessage.Visible = true;
				this.localHeadingLabel.Visible = false;
				this.lightArea1.Visible = false;
				return;
			}
			this.highlightLine1.Visible = true;
			this.highlightLine2.Visible = true;
			this.highlightLine3.Visible = true;
			this.highlightLine4.Visible = true;
			this.highlightLine5.Visible = true;
			this.highlightLine6.Visible = false;
			this.highlightLine7.Visible = false;
			this.highlightLine8.Visible = false;
			this.setRowInfo(0, 29);
			this.setRowInfo(1, 28);
			this.setRowInfo(2, 31);
			this.setRowInfo(3, 30);
			this.setRowInfo(4, 32);
		}

		// Token: 0x06002ADC RID: 10972 RVA: 0x0021E1E4 File Offset: 0x0021C3E4
		private void initHallTab()
		{
			this.highlightLine1.Visible = true;
			this.highlightLine2.Visible = true;
			this.highlightLine3.Visible = true;
			this.highlightLine4.Visible = true;
			this.highlightLine5.Visible = true;
			this.highlightLine6.Visible = true;
			this.highlightLine7.Visible = true;
			this.highlightLine8.Visible = true;
			this.setRowInfo(0, 22);
			this.setRowInfo(1, 21);
			this.setRowInfo(2, 26);
			this.setRowInfo(3, 19);
			this.setRowInfo(4, 33);
			this.setRowInfo(5, 23);
			this.setRowInfo(6, 24);
			this.setRowInfo(7, 25);
		}

		// Token: 0x06002ADD RID: 10973 RVA: 0x0021E29C File Offset: 0x0021C49C
		private void rowClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.currentResource)
				{
					this.buyTrack.Max = 50000;
					this.buyTrack.Value = 50000;
					this.sellTrack.Max = 50000;
					this.sellTrack.Value = 50000;
					GameEngine.Instance.playInterfaceSound("StockExchangePanel_resource_clicked");
					this.selectHighlightLine(this.getLineFromResource(csdbutton.Data));
					base.Invalidate();
				}
			}
		}

		// Token: 0x06002ADE RID: 10974 RVA: 0x0021E338 File Offset: 0x0021C538
		private void setRowInfo(int line, int resource)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
			rowButton.ImageIcon = GFXLibrary.getCommodity32DSImage(resource);
			rowButton.Text.Text = VillageBuildingsData.getResourceNames(resource);
			rowButton.Data = resource;
			int numSpaces = GameEngine.Instance.LocalWorldData.traderCarryingLevels[resource];
			numSpaces = CardTypes.adjustTraderCarryLevels(GameEngine.Instance.cardsManager.UserCardData, numSpaces);
			rowButton.Text2.Text = numSpaces.ToString("N", nfi);
			CustomSelfDrawPanel.CSDButton rowHighestButton = this.getRowHighestButton(line);
			rowHighestButton.Data = resource;
			CustomSelfDrawPanel.CSDButton rowLowestButton = this.getRowLowestButton(line);
			rowLowestButton.Data = resource;
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

		// Token: 0x06002ADF RID: 10975 RVA: 0x0021E4BC File Offset: 0x0021C6BC
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

		// Token: 0x06002AE0 RID: 10976 RVA: 0x0021E4EC File Offset: 0x0021C6EC
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
			if (GameEngine.Instance.World.isAccountPremium() && Program.mySettings.AdvancedTrading)
			{
				CustomSelfDrawPanel.CSDButton rowHighestButton = this.getRowHighestButton(row);
				rowHighestButton.Visible = (priceValue >= 0);
				CustomSelfDrawPanel.CSDButton rowLowestButton = this.getRowLowestButton(row);
				rowLowestButton.Visible = (priceValue >= 0);
			}
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x0021E5CC File Offset: 0x0021C7CC
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

		// Token: 0x06002AE2 RID: 10978 RVA: 0x0021E63C File Offset: 0x0021C83C
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

		// Token: 0x06002AE3 RID: 10979 RVA: 0x0021E6AC File Offset: 0x0021C8AC
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

		// Token: 0x06002AE4 RID: 10980 RVA: 0x0021E71C File Offset: 0x0021C91C
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

		// Token: 0x06002AE5 RID: 10981 RVA: 0x0021E78C File Offset: 0x0021C98C
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

		// Token: 0x06002AE6 RID: 10982 RVA: 0x0021E7FC File Offset: 0x0021C9FC
		private CustomSelfDrawPanel.CSDButton getRowHighestButton(int row)
		{
			switch (row)
			{
			case 0:
				return this.highestPriceRow1;
			case 1:
				return this.highestPriceRow2;
			case 2:
				return this.highestPriceRow3;
			case 3:
				return this.highestPriceRow4;
			case 4:
				return this.highestPriceRow5;
			case 5:
				return this.highestPriceRow6;
			case 6:
				return this.highestPriceRow7;
			case 7:
				return this.highestPriceRow8;
			default:
				return null;
			}
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x0021E86C File Offset: 0x0021CA6C
		private CustomSelfDrawPanel.CSDButton getRowLowestButton(int row)
		{
			switch (row)
			{
			case 0:
				return this.lowestPriceRow1;
			case 1:
				return this.lowestPriceRow2;
			case 2:
				return this.lowestPriceRow3;
			case 3:
				return this.lowestPriceRow4;
			case 4:
				return this.lowestPriceRow5;
			case 5:
				return this.lowestPriceRow6;
			case 6:
				return this.lowestPriceRow7;
			case 7:
				return this.lowestPriceRow8;
			default:
				return null;
			}
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x0021E8DC File Offset: 0x0021CADC
		private CustomSelfDrawPanel.CSDButton getVillageHistory(int line)
		{
			switch (line)
			{
			case 0:
				return this.villageSelectVillage1;
			case 1:
				return this.villageSelectVillage2;
			case 2:
				return this.villageSelectVillage3;
			case 3:
				return this.villageSelectVillage4;
			case 4:
				return this.villageSelectVillage5;
			case 5:
				return this.villageSelectVillage6;
			case 6:
				return this.villageSelectVillage7;
			case 7:
				return this.villageSelectVillage8;
			case 8:
				return this.villageSelectVillage9;
			case 9:
				return this.villageSelectVillage10;
			case 10:
				return this.villageSelectVillage11;
			case 11:
				return this.villageSelectVillage12;
			case 12:
				return this.villageSelectVillage13;
			case 13:
				return this.villageSelectVillage14;
			case 14:
				return this.villageSelectVillage15;
			case 15:
				return this.villageSelectVillage16;
			case 16:
				return this.villageSelectVillage17;
			default:
				return null;
			}
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x0021E9B0 File Offset: 0x0021CBB0
		private CustomSelfDrawPanel.CSDButton getVillageHistoryFavourite(int line)
		{
			switch (line)
			{
			case 0:
				return this.villageSelectVillage1Favourite;
			case 1:
				return this.villageSelectVillage2Favourite;
			case 2:
				return this.villageSelectVillage3Favourite;
			case 3:
				return this.villageSelectVillage4Favourite;
			case 4:
				return this.villageSelectVillage5Favourite;
			case 5:
				return this.villageSelectVillage6Favourite;
			case 6:
				return this.villageSelectVillage7Favourite;
			case 7:
				return this.villageSelectVillage8Favourite;
			case 8:
				return this.villageSelectVillage9Favourite;
			case 9:
				return this.villageSelectVillage10Favourite;
			case 10:
				return this.villageSelectVillage11Favourite;
			case 11:
				return this.villageSelectVillage12Favourite;
			case 12:
				return this.villageSelectVillage13Favourite;
			case 13:
				return this.villageSelectVillage14Favourite;
			case 14:
				return this.villageSelectVillage15Favourite;
			case 15:
				return this.villageSelectVillage16Favourite;
			case 16:
				return this.villageSelectVillage17Favourite;
			default:
				return null;
			}
		}

		// Token: 0x06002AEA RID: 10986 RVA: 0x0021EA84 File Offset: 0x0021CC84
		private CustomSelfDrawPanel.CSDButton getVillageHistoryDelete(int line)
		{
			switch (line)
			{
			case 0:
				return this.villageSelectVillage1Delete;
			case 1:
				return this.villageSelectVillage2Delete;
			case 2:
				return this.villageSelectVillage3Delete;
			case 3:
				return this.villageSelectVillage4Delete;
			case 4:
				return this.villageSelectVillage5Delete;
			case 5:
				return this.villageSelectVillage6Delete;
			case 6:
				return this.villageSelectVillage7Delete;
			case 7:
				return this.villageSelectVillage8Delete;
			case 8:
				return this.villageSelectVillage9Delete;
			case 9:
				return this.villageSelectVillage10Delete;
			case 10:
				return this.villageSelectVillage11Delete;
			case 11:
				return this.villageSelectVillage12Delete;
			case 12:
				return this.villageSelectVillage13Delete;
			case 13:
				return this.villageSelectVillage14Delete;
			case 14:
				return this.villageSelectVillage15Delete;
			case 15:
				return this.villageSelectVillage16Delete;
			case 16:
				return this.villageSelectVillage17Delete;
			default:
				return null;
			}
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x0021EB58 File Offset: 0x0021CD58
		private void highestPricedClicked()
		{
			if (GameEngine.Instance.World.isAccountPremium())
			{
				int data = this.ClickedControl.Data;
				int num = 100000000;
				int villageID = this.selectedStockExchange;
				int num2 = 1000000000;
				int villageID2 = this.selectedStockExchange;
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					villageID2 = village.VillageID;
				}
				foreach (int num3 in this.closeCapitalsToTest)
				{
					if (this.stockExchanges[num3] != null)
					{
						StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[num3];
						int level = stockExchangeInfo.getLevel(data);
						if (level < num2)
						{
							num2 = level;
							villageID = num3;
							num = GameEngine.Instance.World.getSquareDistance(villageID2, num3);
						}
						else if (level == num2)
						{
							int squareDistance = GameEngine.Instance.World.getSquareDistance(villageID2, num3);
							if (squareDistance < num)
							{
								villageID = num3;
								num = squareDistance;
							}
						}
					}
				}
				this.BACKUP_resource = data;
				this.selectStockExchange(villageID);
			}
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x0021EC80 File Offset: 0x0021CE80
		private void lowestPricedClicked()
		{
			if (GameEngine.Instance.World.isAccountPremium())
			{
				int data = this.ClickedControl.Data;
				int num = 100000000;
				int villageID = this.selectedStockExchange;
				int num2 = -1;
				int villageID2 = this.selectedStockExchange;
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					villageID2 = village.VillageID;
				}
				foreach (int num3 in this.closeCapitalsToTest)
				{
					if (this.stockExchanges[num3] != null)
					{
						StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[num3];
						int level = stockExchangeInfo.getLevel(data);
						if (level > num2)
						{
							num2 = level;
							villageID = num3;
							num = GameEngine.Instance.World.getSquareDistance(villageID2, num3);
						}
						else if (level == num2)
						{
							int squareDistance = GameEngine.Instance.World.getSquareDistance(villageID2, num3);
							if (squareDistance < num)
							{
								villageID = num3;
								num = squareDistance;
							}
						}
					}
				}
				this.BACKUP_resource = data;
				this.selectStockExchange(villageID);
			}
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x0001F92D File Offset: 0x0001DB2D
		private void exchangeArrowClick()
		{
			if (this.exchangeArrowButton.Data == 0)
			{
				GameEngine.Instance.playInterfaceSound("StockExchangePanel_village_list_open");
				this.showVillagePanel(true);
				return;
			}
			GameEngine.Instance.playInterfaceSound("StockExchangePanel_village_list_close");
			this.showVillagePanel(false);
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x0021EDA4 File Offset: 0x0021CFA4
		private void villageClicked()
		{
			if (this.ClickedControl != null)
			{
				GameEngine.Instance.playInterfaceSound("StockExchangePanel_village_clicked");
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				this.BACKUP_resource = this.currentResource;
				this.BACKUP_buyLevel = this.buyTrack.Value;
				this.BACKUP_sellLevel = this.sellTrack.Value;
				this.selectStockExchange(csdbutton.Data);
				this.showVillagePanel(false);
			}
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x0021EE18 File Offset: 0x0021D018
		private void villageRecentDeleteClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				RemoteServices.Instance.UpdateVillageFavourites(6, data);
				foreach (WorldMap.VillageNameItem villageNameItem in StockExchangePanel.exchangeHistory)
				{
					if (villageNameItem.villageID == data)
					{
						StockExchangePanel.exchangeHistory.Remove(villageNameItem);
						this.updateExchangeHistory();
						break;
					}
				}
			}
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x0021EEA8 File Offset: 0x0021D0A8
		private void villageFavouriteClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			bool flag = false;
			foreach (WorldMap.VillageNameItem villageNameItem in StockExchangePanel.exchangeFavourites)
			{
				if (villageNameItem.villageID == data)
				{
					flag = true;
					StockExchangePanel.exchangeFavourites.Remove(villageNameItem);
					break;
				}
			}
			if (flag)
			{
				RemoteServices.Instance.UpdateVillageFavourites(3, data);
				csdbutton.ImageNorm = GFXLibrary.star_market_2;
				for (int i = 0; i < 17; i++)
				{
					CustomSelfDrawPanel.CSDButton villageHistoryDelete = this.getVillageHistoryDelete(i);
					if (villageHistoryDelete.Data == csdbutton.Data)
					{
						villageHistoryDelete.Visible = true;
						return;
					}
				}
				return;
			}
			RemoteServices.Instance.UpdateVillageFavourites(2, data);
			WorldMap.VillageNameItem villageNameItem2 = new WorldMap.VillageNameItem();
			villageNameItem2.villageID = data;
			villageNameItem2.villageName = GameEngine.Instance.World.getExchangeName(data);
			StockExchangePanel.exchangeFavourites.Add(villageNameItem2);
			csdbutton.ImageNorm = GFXLibrary.star_market_1;
			for (int j = 0; j < 17; j++)
			{
				CustomSelfDrawPanel.CSDButton villageHistoryDelete2 = this.getVillageHistoryDelete(j);
				if (villageHistoryDelete2.Data == csdbutton.Data)
				{
					villageHistoryDelete2.Visible = false;
					return;
				}
			}
		}

		// Token: 0x06002AF1 RID: 10993 RVA: 0x0021F000 File Offset: 0x0021D200
		private void showVillagePanel(bool show)
		{
			this.villageSelectPanel.Visible = show;
			if (show)
			{
				this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_up_normal;
				this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_up_over;
				this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_up_down;
				this.exchangeArrowButton.Data = 1;
				this.updateExchangeHistory();
				return;
			}
			this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.exchangeArrowButton.Data = 0;
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x0021F0BC File Offset: 0x0021D2BC
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = null;
				if (this.selectedStockExchange >= 0 && this.stockExchanges[this.selectedStockExchange] != null)
				{
					stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[this.selectedStockExchange];
					this.updateDeliveryTime(this.selectedStockExchange);
				}
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				switch (this.lastTab)
				{
				case 1:
				{
					VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels);
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
					break;
				}
				case 2:
				{
					VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
					village.getGranaryLevels(granaryLevels);
					VillageMap.InnLevels innLevels = new VillageMap.InnLevels();
					village.getInnLevels(innLevels);
					if (stockExchangeInfo == null)
					{
						this.setRowValues(0, (int)granaryLevels.applesLevel, -1, -1);
						this.setRowValues(1, (int)granaryLevels.cheeseLevel, -1, -1);
						this.setRowValues(2, (int)granaryLevels.meatLevel, -1, -1);
						this.setRowValues(3, (int)granaryLevels.breadLevel, -1, -1);
						this.setRowValues(4, (int)granaryLevels.vegLevel, -1, -1);
						this.setRowValues(5, (int)granaryLevels.fishLevel, -1, -1);
						this.setRowValues(6, (int)innLevels.aleLevel, -1, -1);
					}
					else
					{
						this.setRowValues(0, (int)granaryLevels.applesLevel, stockExchangeInfo.applesLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(13), 13));
						this.setRowValues(1, (int)granaryLevels.cheeseLevel, stockExchangeInfo.cheeseLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(17), 17));
						this.setRowValues(2, (int)granaryLevels.meatLevel, stockExchangeInfo.meatLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(16), 16));
						this.setRowValues(3, (int)granaryLevels.breadLevel, stockExchangeInfo.breadLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(14), 14));
						this.setRowValues(4, (int)granaryLevels.vegLevel, stockExchangeInfo.vegLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(15), 15));
						this.setRowValues(5, (int)granaryLevels.fishLevel, stockExchangeInfo.fishLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(18), 18));
						this.setRowValues(6, (int)innLevels.aleLevel, stockExchangeInfo.aleLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(12), 12));
					}
					break;
				}
				case 3:
				{
					VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
					village.getArmouryLevels(armouryLevels);
					if (stockExchangeInfo == null)
					{
						this.setRowValues(0, (int)armouryLevels.bowsLevel, -1, -1);
						this.setRowValues(1, (int)armouryLevels.pikesLevel, -1, -1);
						this.setRowValues(2, (int)armouryLevels.armourLevel, -1, -1);
						this.setRowValues(3, (int)armouryLevels.swordsLevel, -1, -1);
						this.setRowValues(4, (int)armouryLevels.catapultsLevel, -1, -1);
					}
					else
					{
						this.setRowValues(0, (int)armouryLevels.bowsLevel, stockExchangeInfo.bowsLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(29), 29));
						this.setRowValues(1, (int)armouryLevels.pikesLevel, stockExchangeInfo.pikesLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(28), 28));
						this.setRowValues(2, (int)armouryLevels.armourLevel, stockExchangeInfo.armourLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(31), 31));
						this.setRowValues(3, (int)armouryLevels.swordsLevel, stockExchangeInfo.swordsLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(30), 30));
						this.setRowValues(4, (int)armouryLevels.catapultsLevel, stockExchangeInfo.catapultsLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(32), 32));
					}
					break;
				}
				case 4:
				{
					VillageMap.TownHallLevels townHallLevels = new VillageMap.TownHallLevels();
					village.getTownHallLevels(townHallLevels);
					if (stockExchangeInfo == null)
					{
						this.setRowValues(0, (int)townHallLevels.venisonLevel, -1, -1);
						this.setRowValues(1, (int)townHallLevels.furnitureLevel, -1, -1);
						this.setRowValues(2, (int)townHallLevels.metalwareLevel, -1, -1);
						this.setRowValues(3, (int)townHallLevels.clothesLevel, -1, -1);
						this.setRowValues(4, (int)townHallLevels.wineLevel, -1, -1);
						this.setRowValues(5, (int)townHallLevels.saltLevel, -1, -1);
						this.setRowValues(6, (int)townHallLevels.spicesLevel, -1, -1);
						this.setRowValues(7, (int)townHallLevels.silkLevel, -1, -1);
					}
					else
					{
						this.setRowValues(0, (int)townHallLevels.venisonLevel, stockExchangeInfo.venisonLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(22), 22));
						this.setRowValues(1, (int)townHallLevels.furnitureLevel, stockExchangeInfo.furnitureLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(21), 21));
						this.setRowValues(2, (int)townHallLevels.metalwareLevel, stockExchangeInfo.metalwareLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(26), 26));
						this.setRowValues(3, (int)townHallLevels.clothesLevel, stockExchangeInfo.clothesLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(19), 19));
						this.setRowValues(4, (int)townHallLevels.wineLevel, stockExchangeInfo.wineLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(33), 33));
						this.setRowValues(5, (int)townHallLevels.saltLevel, stockExchangeInfo.saltLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(23), 23));
						this.setRowValues(6, (int)townHallLevels.spicesLevel, stockExchangeInfo.spicesLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(24), 24));
						this.setRowValues(7, (int)townHallLevels.silkLevel, stockExchangeInfo.silkLevel, TradingCalcs.calcSellCost(localWorldData, stockExchangeInfo.getFakeLevel(25), 25));
					}
					break;
				}
				}
				this.numTraders = village.numTraders();
				this.numFreeTraders = village.numFreeTraders();
				if (this.numFreeTraders > this.numTraders)
				{
					village.refreshTraderNumbers();
				}
				this.tradersAvailableValue.Text = this.numFreeTraders.ToString() + "/" + this.numTraders.ToString();
				int num = this.currentResourcePacketSize * this.numFreeTraders;
				this.traderCapacityValue.Text = num.ToString("N", nfi);
			}
			else
			{
				for (int i = 0; i < 8; i++)
				{
					this.setRowValues(i, -1, -1, -1);
				}
				this.tradersAvailableValue.Text = "0/0";
				this.traderCapacityValue.Text = "0";
			}
			this.showBuySellWindow();
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x0021F7A0 File Offset: 0x0021D9A0
		public void updateExchangeHistory()
		{
			for (int i = 0; i < 17; i++)
			{
				CustomSelfDrawPanel.CSDButton villageHistory = this.getVillageHistory(i);
				villageHistory.Visible = false;
				CustomSelfDrawPanel.CSDButton villageHistoryFavourite = this.getVillageHistoryFavourite(i);
				villageHistoryFavourite.Visible = false;
				CustomSelfDrawPanel.CSDButton villageHistoryDelete = this.getVillageHistoryDelete(i);
				villageHistoryDelete.Visible = false;
			}
			int num = 0;
			while (num < 17 && num < StockExchangePanel.exchangeFavourites.Count)
			{
				WorldMap.VillageNameItem villageNameItem = StockExchangePanel.exchangeFavourites[num];
				CustomSelfDrawPanel.CSDButton villageHistory2 = this.getVillageHistory(num);
				villageHistory2.Visible = true;
				villageHistory2.Text.Text = GameEngine.Instance.World.getExchangeName(villageNameItem.villageID);
				villageHistory2.Data = villageNameItem.villageID;
				CustomSelfDrawPanel.CSDButton villageHistoryFavourite2 = this.getVillageHistoryFavourite(num);
				villageHistoryFavourite2.ImageNorm = GFXLibrary.star_market_1;
				villageHistoryFavourite2.Visible = true;
				villageHistoryFavourite2.Data = villageNameItem.villageID;
				villageHistoryFavourite2.CustomTooltipID = 808;
				CustomSelfDrawPanel.CSDButton villageHistoryDelete2 = this.getVillageHistoryDelete(num);
				villageHistoryDelete2.Data = villageNameItem.villageID;
				num++;
			}
			int num2 = 0;
			while (num < 17 && num2 < StockExchangePanel.exchangeHistory.Count)
			{
				WorldMap.VillageNameItem villageNameItem2 = StockExchangePanel.exchangeHistory[num2];
				bool flag = false;
				foreach (WorldMap.VillageNameItem villageNameItem3 in StockExchangePanel.exchangeFavourites)
				{
					if (villageNameItem3.villageID == villageNameItem2.villageID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					CustomSelfDrawPanel.CSDButton villageHistory3 = this.getVillageHistory(num);
					villageHistory3.Visible = true;
					villageHistory3.Text.Text = GameEngine.Instance.World.getExchangeName(villageNameItem2.villageID);
					villageHistory3.Data = villageNameItem2.villageID;
					CustomSelfDrawPanel.CSDButton villageHistoryFavourite3 = this.getVillageHistoryFavourite(num);
					villageHistoryFavourite3.ImageNorm = GFXLibrary.star_market_2;
					villageHistoryFavourite3.Visible = true;
					villageHistoryFavourite3.Data = villageNameItem2.villageID;
					villageHistoryFavourite3.CustomTooltipID = 809;
					CustomSelfDrawPanel.CSDButton villageHistoryDelete3 = this.getVillageHistoryDelete(num);
					villageHistoryDelete3.Visible = true;
					villageHistoryDelete3.Data = villageNameItem2.villageID;
					villageHistoryDelete3.CustomTooltipID = 810;
					num++;
				}
				num2++;
			}
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x0021F9E4 File Offset: 0x0021DBE4
		private void updateDeliveryTime(int villageID)
		{
			VillageMap village = GameEngine.Instance.Village;
			if (villageID >= 0 && village != null)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(village.VillageID);
				Point villageLocation2 = GameEngine.Instance.World.getVillageLocation(villageID);
				int x = villageLocation.X;
				int y = villageLocation.Y;
				int villageRegion = GameEngine.Instance.World.getVillageRegion(village.VillageID);
				int x2 = villageLocation2.X;
				int y2 = villageLocation2.Y;
				int villageRegion2 = GameEngine.Instance.World.getVillageRegion(villageID);
				double num;
				if (villageRegion != villageRegion2)
				{
					num = (double)((x - x2) * (x - x2) + (y - y2) * (y - y2));
					num = Math.Sqrt(num);
					num *= localWorldData.traderMoveSpeed * localWorldData.gamePlaySpeed;
				}
				else
				{
					num = localWorldData.traderStockExchangeSameRegionTime;
				}
				num = GameEngine.Instance.World.UserResearchData.adjustTradeTimes(num);
				num *= CardTypes.cards_adjustTradeTimes(GameEngine.Instance.cardsManager.UserCardData);
				num = CardTypes.cards_adjustTradeTimesCompleteContract(GameEngine.Instance.cardsManager.UserCardData, num);
				num = GameEngine.Instance.World.adjustIfIslandTravel(num, village.VillageID, villageID);
				string str = VillageMap.createBuildTimeString((int)num);
				this.deliveryTimeAreaLabel.TextDiffOnly = SK.Text("TRADE_Delivery_Time", "Delivery Time") + ":  " + str;
				if (!GameEngine.Instance.World.isIslandTravel(village.VillageID, villageID))
				{
					this.seaConditionsImage.Visible = false;
					return;
				}
				this.seaConditionsImage.Visible = true;
				int num2 = GameEngine.Instance.World.SpecialSeaConditionsData + 4;
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 >= 9)
				{
					num2 = 8;
				}
				if (this.lastSeaConditions != num2)
				{
					this.lastSeaConditions = num2;
					this.seaConditionsImage.Image = GFXLibrary.sea_conditions[num2];
					this.seaConditionsImage.CustomTooltipID = 23000 + num2;
					return;
				}
			}
			else
			{
				this.deliveryTimeAreaLabel.TextDiffOnly = SK.Text("TRADE_Delivery_Time", "Delivery Time") + ":  ";
				this.seaConditionsImage.Visible = false;
				this.lastSeaConditions = -1;
			}
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x0021FC38 File Offset: 0x0021DE38
		private void showBuySellWindow()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			bool visible = this.buyWindow.Visible;
			bool visible2 = this.sellWindow.Visible;
			this.buyWindow.Visible = false;
			this.sellWindow.Visible = false;
			if (GameEngine.Instance.World.UserResearchData.Research_Merchant_Guilds == 0 || GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village != null && this.currentResource >= 0 && this.selectedStockExchange >= 0 && this.stockExchanges[this.selectedStockExchange] != null && this.currentResource > 0)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[this.selectedStockExchange];
				int num = (int)village.getResourceLevel(this.currentResource);
				int level = stockExchangeInfo.getLevel(this.currentResource);
				int num2 = this.numFreeTraders;
				int num3 = TradingCalcs.calcGoldCost(localWorldData, level, this.currentResource, level - this.buyTrack.Value * this.currentResourcePacketSize);
				int num4 = TradingCalcs.calcGoldCost(localWorldData, level, this.currentResource, level + this.sellTrack.Value * this.currentResourcePacketSize);
				if (num >= this.currentResourcePacketSize)
				{
					this.sellWindow.Visible = true;
					int num5 = num / this.currentResourcePacketSize;
					if (num5 > num2)
					{
						num5 = num2;
					}
					int max = this.sellTrack.Max;
					if (num5 > max)
					{
						this.sellTrack.Max = num5;
					}
					else if (num5 < max)
					{
						if (this.sellTrack.Value > num5)
						{
							this.sellTrack.Value = num5;
						}
						this.sellTrack.Max = num5;
					}
					int num6 = num4;
					num6 = TradingCalcs.calcSellCost(localWorldData, num6);
					num6 *= this.sellTrack.Value;
					num6 = num6 * this.currentResourcePacketSize / this.currentResourcePacketSizeREAL;
					this.sellCostValue.Text = num6.ToString("N", nfi);
					this.sellNumber.Text = (this.sellTrack.Value * this.currentResourcePacketSize).ToString("N", nfi);
					this.sellMax.Text = (this.sellTrack.Max * this.currentResourcePacketSize).ToString("N", nfi);
					this.sellHeadingImage.invalidate();
				}
				if (level >= this.currentResourcePacketSize)
				{
					this.buyWindow.Visible = true;
					int num7 = (int)GameEngine.Instance.World.getCurrentGold();
					int num8 = level / this.currentResourcePacketSize;
					int num9 = num7 / num3;
					if (num2 > num9)
					{
						num2 = num9;
					}
					if (num8 > num2)
					{
						num8 = num2;
					}
					int max2 = this.buyTrack.Max;
					if (num8 > max2)
					{
						this.buyTrack.Max = num8;
					}
					else if (num8 < max2)
					{
						if (this.buyTrack.Value > num8)
						{
							this.buyTrack.Value = num8;
						}
						this.buyTrack.Max = num8;
					}
					num3 = num3 * this.currentResourcePacketSize / this.currentResourcePacketSizeREAL;
					this.buyCostValue.Text = (this.buyTrack.Value * num3).ToString("N", nfi);
					this.buyNumber.Text = (this.buyTrack.Value * this.currentResourcePacketSize).ToString("N", nfi);
					this.buyMax.Text = (this.buyTrack.Max * this.currentResourcePacketSize).ToString("N", nfi);
					this.buyHeadingImage.invalidate();
				}
			}
			if (this.buyWindow.Visible || this.sellWindow.Visible)
			{
				this.stockExchangeImage.Alpha = 0.15f;
			}
			else
			{
				this.stockExchangeImage.Alpha = 1f;
			}
			this.validateBuySellButtons();
			if (visible != this.buyWindow.Visible || visible2 != this.sellWindow.Visible)
			{
				this.mainBackgroundImage.invalidate();
			}
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x00220058 File Offset: 0x0021E258
		private void validateBuySellButtons()
		{
			if (this.buyWindow.Visible && this.buyTrack.Value > 0)
			{
				this.buyButton.Enabled = true;
			}
			else
			{
				this.buyButton.Enabled = false;
			}
			if (this.sellWindow.Visible && this.sellTrack.Value > 0)
			{
				this.sellButton.Enabled = true;
				return;
			}
			this.sellButton.Enabled = false;
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x002200D0 File Offset: 0x0021E2D0
		private void findOnWorldClicked()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.BACKUP_resource = this.currentResource;
				this.BACKUP_sellLevel = this.sellTrack.Value;
				this.BACKUP_buyLevel = this.buyTrack.Value;
				GameEngine.Instance.World.zoomToVillage(village.VillageID);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(4);
				InterfaceMgr.Instance.StockExchangeBuyingVillage = village.VillageID;
			}
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x0001F969 File Offset: 0x0001DB69
		private void tracksMoved()
		{
			this.showBuySellWindow();
			this.buyWindow.invalidate();
			this.sellWindow.invalidate();
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x0001F987 File Offset: 0x0001DB87
		public void resetBackupData()
		{
			this.BACKUP_resource = -1;
			this.BACKUP_sellLevel = 50000;
			this.BACKUP_buyLevel = 50000;
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x00220150 File Offset: 0x0021E350
		public void selectStockExchange(int villageID)
		{
			if (villageID == -2)
			{
				villageID = this.selectedStockExchange;
			}
			if (villageID < 0)
			{
				this.selectedStockExchange = -1;
				return;
			}
			this.selectedStockExchange = villageID;
			bool flag = true;
			if (GameEngine.Instance.World.isAccountPremium())
			{
				flag = false;
				int num = villageID;
				VillageMap village = GameEngine.Instance.Village;
				if (village != null)
				{
					num = village.VillageID;
				}
				List<StockExchangePanel.ClosestCapitalSortItem> list = new List<StockExchangePanel.ClosestCapitalSortItem>();
				List<int> capitalList = GameEngine.Instance.World.getCapitalList();
				foreach (int num2 in capitalList)
				{
					if (num2 != villageID)
					{
						int squareDistance = GameEngine.Instance.World.getSquareDistance(num, num2);
						if (squareDistance < 40000 && GameEngine.Instance.World.allowExchangeTrade(num2, num))
						{
							list.Add(new StockExchangePanel.ClosestCapitalSortItem
							{
								distance = squareDistance,
								villageID = num2
							});
						}
					}
				}
				this.closeCapitalsToTest.Clear();
				this.closeCapitalsToTest.Add(villageID);
				list.Sort((StockExchangePanel.ClosestCapitalSortItem a, StockExchangePanel.ClosestCapitalSortItem b) => a.distance.CompareTo(b.distance));
				if (list.Count > 20)
				{
					list.RemoveRange(20, list.Count - 20);
				}
				List<int> list2 = new List<int>();
				foreach (StockExchangePanel.ClosestCapitalSortItem closestCapitalSortItem in list)
				{
					this.closeCapitalsToTest.Add(closestCapitalSortItem.villageID);
					bool flag2 = true;
					if (this.stockExchanges[closestCapitalSortItem.villageID] != null)
					{
						StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[closestCapitalSortItem.villageID];
						if ((DateTime.Now - stockExchangeInfo.lastTime).TotalMinutes < 1.0)
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						list2.Add(closestCapitalSortItem.villageID);
					}
				}
				if (list2.Count > 0)
				{
					RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.getStockExchangeDataCallback));
					RemoteServices.Instance.GetStockExchangePremiumData(villageID, list2.ToArray());
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				bool flag3 = true;
				if (this.stockExchanges[this.selectedStockExchange] != null)
				{
					StockExchangePanel.StockExchangeInfo stockExchangeInfo2 = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[this.selectedStockExchange];
					if ((DateTime.Now - stockExchangeInfo2.lastTime).TotalMinutes < 1.0)
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.getStockExchangeDataCallback));
					RemoteServices.Instance.GetStockExchangeData(villageID, true);
				}
			}
			this.updateDeliveryTime(villageID);
			this.exchangeNameLabel.Text = GameEngine.Instance.World.getExchangeName(villageID);
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
					this.manageTabs(1);
					break;
				case 12:
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
				this.buyTrack.Max = 50000;
				this.buyTrack.Value = this.BACKUP_buyLevel;
				this.sellTrack.Max = 50000;
				this.sellTrack.Value = this.BACKUP_sellLevel;
			}
			this.updateValues();
		}

		// Token: 0x06002AFB RID: 11003 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06002AFC RID: 11004 RVA: 0x00220568 File Offset: 0x0021E768
		private void BuyClickConinue()
		{
			VillageMap village = GameEngine.Instance.Village;
			village.stockExchangeTrade(this.selectedStockExchange, this.currentResource, this.buyTrack.Value * this.currentResourcePacketSize, true);
			this.addVillageToHistory(this.selectedStockExchange);
			string tag = "";
			switch (this.currentResource)
			{
			case 6:
				tag = "MarketResource_Wood";
				break;
			case 7:
				tag = "MarketResource_Stone";
				break;
			case 8:
				tag = "MarketResource_Iron";
				break;
			case 9:
				tag = "MarketResource_Pitch";
				break;
			case 12:
				tag = "MarketResource_Ale";
				break;
			case 13:
				tag = "MarketResource_Apples";
				break;
			case 14:
				tag = "MarketResource_Bread";
				break;
			case 15:
				tag = "MarketResource_Veg";
				break;
			case 16:
				tag = "MarketResource_Meat";
				break;
			case 17:
				tag = "MarketResource_Cheese";
				break;
			case 18:
				tag = "MarketResource_Fish";
				break;
			case 19:
				tag = "MarketResource_Clothes";
				break;
			case 21:
				tag = "MarketResource_Furniture";
				break;
			case 22:
				tag = "MarketResource_Venison";
				break;
			case 23:
				tag = "MarketResource_Salt";
				break;
			case 24:
				tag = "MarketResource_Spices";
				break;
			case 25:
				tag = "MarketResource_Salt";
				break;
			case 26:
				tag = "MarketResource_Metalware";
				break;
			case 28:
				tag = "MarketResource_Pikes";
				break;
			case 29:
				tag = "MarketResource_Bows";
				break;
			case 30:
				tag = "MarketResource_Swords";
				break;
			case 31:
				tag = "MarketResource_Armour";
				break;
			case 32:
				tag = "MarketResource_Catapults";
				break;
			case 33:
				tag = "MarketResource_Wine";
				break;
			}
			Sound.playDelayedInterfaceSound(tag, 100);
		}

		// Token: 0x06002AFD RID: 11005 RVA: 0x00220718 File Offset: 0x0021E918
		private void buyClick()
		{
			DateTime now = DateTime.Now;
			if ((now - this.lastTradeTime).TotalSeconds < 3.0)
			{
				return;
			}
			this.lastTradeTime = now;
			VillageMap village = GameEngine.Instance.Village;
			if (village == null)
			{
				return;
			}
			this.dirtyStockExchangeInfo(this.selectedStockExchange);
			double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.currentResource, GameEngine.Instance.cardsManager.UserCardData, false) - village.getResourceLevel(this.currentResource);
			int value = this.buyTrack.Value * this.currentResourcePacketSize;
			if (num < Convert.ToDouble(value))
			{
				if (MyMessageBox.Show(SK.Text("Stock_Exchange_Space_Warning", "You do not have enough space to store all of the goods. Do you wish to continue with the trade? You will receive :") + " " + Convert.ToInt32(num).ToString(), SK.Text("Stock_Exchange_Space_Warning_Title", "Insufficient Storage Space"), MessageBoxButtons.YesNo) != DialogResult.No)
				{
					this.BuyClickConinue();
					return;
				}
			}
			else
			{
				this.BuyClickConinue();
			}
		}

		// Token: 0x06002AFE RID: 11006 RVA: 0x0022081C File Offset: 0x0021EA1C
		private void sellClick()
		{
			DateTime now = DateTime.Now;
			if ((now - this.lastTradeTime).TotalSeconds < 3.0)
			{
				return;
			}
			this.lastTradeTime = now;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.dirtyStockExchangeInfo(this.selectedStockExchange);
				village.stockExchangeTrade(this.selectedStockExchange, this.currentResource, this.sellTrack.Value * this.currentResourcePacketSize, false);
				this.addVillageToHistory(this.selectedStockExchange);
				string tag = "";
				switch (this.currentResource)
				{
				case 6:
					tag = "MarketResource_Wood";
					break;
				case 7:
					tag = "MarketResource_Stone";
					break;
				case 8:
					tag = "MarketResource_Iron";
					break;
				case 9:
					tag = "MarketResource_Pitch";
					break;
				case 12:
					tag = "MarketResource_Ale";
					break;
				case 13:
					tag = "MarketResource_Apples";
					break;
				case 14:
					tag = "MarketResource_Bread";
					break;
				case 15:
					tag = "MarketResource_Veg";
					break;
				case 16:
					tag = "MarketResource_Meat";
					break;
				case 17:
					tag = "MarketResource_Cheese";
					break;
				case 18:
					tag = "MarketResource_Fish";
					break;
				case 19:
					tag = "MarketResource_Clothes";
					break;
				case 21:
					tag = "MarketResource_Furniture";
					break;
				case 22:
					tag = "MarketResource_Venison";
					break;
				case 23:
					tag = "MarketResource_Salt";
					break;
				case 24:
					tag = "MarketResource_Spices";
					break;
				case 25:
					tag = "MarketResource_Salt";
					break;
				case 26:
					tag = "MarketResource_Metalware";
					break;
				case 28:
					tag = "MarketResource_Pikes";
					break;
				case 29:
					tag = "MarketResource_Bows";
					break;
				case 30:
					tag = "MarketResource_Swords";
					break;
				case 31:
					tag = "MarketResource_Armour";
					break;
				case 32:
					tag = "MarketResource_Catapults";
					break;
				case 33:
					tag = "MarketResource_Wine";
					break;
				}
				Sound.playDelayedInterfaceSound(tag, 100);
			}
		}

		// Token: 0x06002AFF RID: 11007 RVA: 0x00220A0C File Offset: 0x0021EC0C
		private void addVillageToHistory(int villageID)
		{
			bool flag = false;
			foreach (WorldMap.VillageNameItem villageNameItem in StockExchangePanel.exchangeHistory)
			{
				if (villageNameItem.villageID == villageID)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				WorldMap.VillageNameItem villageNameItem2 = new WorldMap.VillageNameItem();
				villageNameItem2.villageID = villageID;
				villageNameItem2.villageName = GameEngine.Instance.World.getExchangeName(villageID);
				StockExchangePanel.exchangeHistory.Add(villageNameItem2);
				this.updateExchangeHistory();
			}
		}

		// Token: 0x06002B00 RID: 11008 RVA: 0x00220AA0 File Offset: 0x0021ECA0
		public void getStockExchangeDataCallback(GetStockExchangeData_ReturnType returnData)
		{
			ControlForm controlForm = DX.ControlForm;
			if (controlForm != null)
			{
				controlForm.GetService<TradeService>().RecieveStockExchangeData(returnData);
			}
			if (returnData.Success)
			{
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = new StockExchangePanel.StockExchangeInfo();
				stockExchangeInfo.lastTime = DateTime.Now;
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
				if (returnData.otherVillages != null)
				{
					foreach (GetStockExchangeData_ReturnType getStockExchangeData_ReturnType in returnData.otherVillages)
					{
						StockExchangePanel.StockExchangeInfo stockExchangeInfo2 = new StockExchangePanel.StockExchangeInfo();
						stockExchangeInfo2.lastTime = DateTime.Now.AddMinutes(1.0);
						stockExchangeInfo2.villageID = getStockExchangeData_ReturnType.villageID;
						stockExchangeInfo2.woodLevel = getStockExchangeData_ReturnType.woodLevel;
						stockExchangeInfo2.stoneLevel = getStockExchangeData_ReturnType.stoneLevel;
						stockExchangeInfo2.ironLevel = getStockExchangeData_ReturnType.ironLevel;
						stockExchangeInfo2.pitchLevel = getStockExchangeData_ReturnType.pitchLevel;
						stockExchangeInfo2.aleLevel = getStockExchangeData_ReturnType.aleLevel;
						stockExchangeInfo2.applesLevel = getStockExchangeData_ReturnType.applesLevel;
						stockExchangeInfo2.breadLevel = getStockExchangeData_ReturnType.breadLevel;
						stockExchangeInfo2.meatLevel = getStockExchangeData_ReturnType.meatLevel;
						stockExchangeInfo2.cheeseLevel = getStockExchangeData_ReturnType.cheeseLevel;
						stockExchangeInfo2.vegLevel = getStockExchangeData_ReturnType.vegLevel;
						stockExchangeInfo2.fishLevel = getStockExchangeData_ReturnType.fishLevel;
						stockExchangeInfo2.bowsLevel = getStockExchangeData_ReturnType.bowsLevel;
						stockExchangeInfo2.pikesLevel = getStockExchangeData_ReturnType.pikesLevel;
						stockExchangeInfo2.swordsLevel = getStockExchangeData_ReturnType.swordsLevel;
						stockExchangeInfo2.armourLevel = getStockExchangeData_ReturnType.armourLevel;
						stockExchangeInfo2.catapultsLevel = getStockExchangeData_ReturnType.catapultsLevel;
						stockExchangeInfo2.furnitureLevel = getStockExchangeData_ReturnType.furnitureLevel;
						stockExchangeInfo2.clothesLevel = getStockExchangeData_ReturnType.clothesLevel;
						stockExchangeInfo2.saltLevel = getStockExchangeData_ReturnType.saltLevel;
						stockExchangeInfo2.venisonLevel = getStockExchangeData_ReturnType.venisonLevel;
						stockExchangeInfo2.silkLevel = getStockExchangeData_ReturnType.silkLevel;
						stockExchangeInfo2.spicesLevel = getStockExchangeData_ReturnType.spicesLevel;
						stockExchangeInfo2.metalwareLevel = getStockExchangeData_ReturnType.metalwareLevel;
						stockExchangeInfo2.wineLevel = getStockExchangeData_ReturnType.wineLevel;
						this.stockExchanges[getStockExchangeData_ReturnType.villageID] = stockExchangeInfo2;
					}
				}
				int lineFromResource = this.getLineFromResource(this.currentResource);
				this.selectHighlightLine(lineFromResource);
				this.updateValues();
			}
		}

		// Token: 0x06002B01 RID: 11009 RVA: 0x00220E10 File Offset: 0x0021F010
		public void dirtyStockExchangeInfo(int selectedStockExchange)
		{
			if (this.stockExchanges[selectedStockExchange] != null)
			{
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[selectedStockExchange];
				stockExchangeInfo.lastTime = DateTime.MinValue;
			}
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x0001F9A6 File Offset: 0x0001DBA6
		public void tradingClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(2);
		}

		// Token: 0x06002B03 RID: 11011 RVA: 0x0001F9B3 File Offset: 0x0001DBB3
		public void newVillageLoaded()
		{
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x040034F2 RID: 13554
		public const int CLOSEST_SEARCH_NUMBER = 20;

		// Token: 0x040034F3 RID: 13555
		private DockableControl dockableControl;

		// Token: 0x040034F4 RID: 13556
		private IContainer components;

		// Token: 0x040034F5 RID: 13557
		public static StockExchangePanel instance = null;

		// Token: 0x040034F6 RID: 13558
		private static List<WorldMap.VillageNameItem> exchangeHistory = new List<WorldMap.VillageNameItem>();

		// Token: 0x040034F7 RID: 13559
		private static List<WorldMap.VillageNameItem> exchangeFavourites = new List<WorldMap.VillageNameItem>();

		// Token: 0x040034F8 RID: 13560
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040034F9 RID: 13561
		private CustomSelfDrawPanel.CSDImage stockExchangeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040034FA RID: 13562
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040034FB RID: 13563
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034FC RID: 13564
		private CustomSelfDrawPanel.CSDButton newTradingButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034FD RID: 13565
		private CustomSelfDrawPanel.CSDExtendingPanel leftWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040034FE RID: 13566
		private CustomSelfDrawPanel.CSDExtendingPanel midWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040034FF RID: 13567
		private CustomSelfDrawPanel.CSDExtendingPanel infoWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003500 RID: 13568
		private CustomSelfDrawPanel.CSDLabel buyHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003501 RID: 13569
		private CustomSelfDrawPanel.CSDImage buyHeadingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003502 RID: 13570
		private CustomSelfDrawPanel.CSDExtendingPanel buyWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003503 RID: 13571
		private CustomSelfDrawPanel.CSDExtendingPanel buySubWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003504 RID: 13572
		private CustomSelfDrawPanel.CSDLabel buyNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003505 RID: 13573
		private CustomSelfDrawPanel.CSDLabel buyCostLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003506 RID: 13574
		private CustomSelfDrawPanel.CSDLabel buyCostValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003507 RID: 13575
		private CustomSelfDrawPanel.CSDLabel buyMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003508 RID: 13576
		private CustomSelfDrawPanel.CSDLabel buyMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003509 RID: 13577
		private CustomSelfDrawPanel.CSDButton buyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400350A RID: 13578
		private CustomSelfDrawPanel.CSDTrackBar buyTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x0400350B RID: 13579
		private CustomSelfDrawPanel.CSDLabel buyTaxLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400350C RID: 13580
		private CustomSelfDrawPanel.CSDLabel sellHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400350D RID: 13581
		private CustomSelfDrawPanel.CSDImage sellHeadingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400350E RID: 13582
		private CustomSelfDrawPanel.CSDExtendingPanel sellWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400350F RID: 13583
		private CustomSelfDrawPanel.CSDExtendingPanel sellSubWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003510 RID: 13584
		private CustomSelfDrawPanel.CSDLabel sellNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003511 RID: 13585
		private CustomSelfDrawPanel.CSDLabel sellCostLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003512 RID: 13586
		private CustomSelfDrawPanel.CSDLabel sellCostValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003513 RID: 13587
		private CustomSelfDrawPanel.CSDLabel sellMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003514 RID: 13588
		private CustomSelfDrawPanel.CSDLabel sellMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003515 RID: 13589
		private CustomSelfDrawPanel.CSDButton sellButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003516 RID: 13590
		private CustomSelfDrawPanel.CSDTrackBar sellTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04003517 RID: 13591
		private CustomSelfDrawPanel.CSDLabel localHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003518 RID: 13592
		private CustomSelfDrawPanel.CSDLabel storedHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003519 RID: 13593
		private CustomSelfDrawPanel.CSDLabel BuyPriceHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400351A RID: 13594
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400351B RID: 13595
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea2 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400351C RID: 13596
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea3 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400351D RID: 13597
		private CustomSelfDrawPanel.CSDHorzExtendingPanel exchangeNameBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400351E RID: 13598
		private CustomSelfDrawPanel.CSDLabel exchangeNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400351F RID: 13599
		private CustomSelfDrawPanel.CSDButton exchangeArrowButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003520 RID: 13600
		private CustomSelfDrawPanel.CSDExtendingPanel deliveryTimeArea = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04003521 RID: 13601
		private CustomSelfDrawPanel.CSDLabel deliveryTimeAreaLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003522 RID: 13602
		private CustomSelfDrawPanel.CSDButton tabButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003523 RID: 13603
		private CustomSelfDrawPanel.CSDButton tabButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003524 RID: 13604
		private CustomSelfDrawPanel.CSDButton tabButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003525 RID: 13605
		private CustomSelfDrawPanel.CSDButton tabButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003526 RID: 13606
		private CustomSelfDrawPanel.CSDLabel fourthAgeMessage = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003527 RID: 13607
		private CustomSelfDrawPanel.CSDImage highlightLine1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003528 RID: 13608
		private CustomSelfDrawPanel.CSDImage highlightLine2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003529 RID: 13609
		private CustomSelfDrawPanel.CSDImage highlightLine3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352A RID: 13610
		private CustomSelfDrawPanel.CSDImage highlightLine4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352B RID: 13611
		private CustomSelfDrawPanel.CSDImage highlightLine5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352C RID: 13612
		private CustomSelfDrawPanel.CSDImage highlightLine6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352D RID: 13613
		private CustomSelfDrawPanel.CSDImage highlightLine7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352E RID: 13614
		private CustomSelfDrawPanel.CSDImage highlightLine8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400352F RID: 13615
		private CustomSelfDrawPanel.CSDButton selectRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003530 RID: 13616
		private CustomSelfDrawPanel.CSDButton selectRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003531 RID: 13617
		private CustomSelfDrawPanel.CSDButton selectRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003532 RID: 13618
		private CustomSelfDrawPanel.CSDButton selectRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003533 RID: 13619
		private CustomSelfDrawPanel.CSDButton selectRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003534 RID: 13620
		private CustomSelfDrawPanel.CSDButton selectRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003535 RID: 13621
		private CustomSelfDrawPanel.CSDButton selectRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003536 RID: 13622
		private CustomSelfDrawPanel.CSDButton selectRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003537 RID: 13623
		private CustomSelfDrawPanel.CSDLabel localLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003538 RID: 13624
		private CustomSelfDrawPanel.CSDLabel localLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003539 RID: 13625
		private CustomSelfDrawPanel.CSDLabel localLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353A RID: 13626
		private CustomSelfDrawPanel.CSDLabel localLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353B RID: 13627
		private CustomSelfDrawPanel.CSDLabel localLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353C RID: 13628
		private CustomSelfDrawPanel.CSDLabel localLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353D RID: 13629
		private CustomSelfDrawPanel.CSDLabel localLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353E RID: 13630
		private CustomSelfDrawPanel.CSDLabel localLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400353F RID: 13631
		private CustomSelfDrawPanel.CSDLabel storedLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003540 RID: 13632
		private CustomSelfDrawPanel.CSDLabel storedLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003541 RID: 13633
		private CustomSelfDrawPanel.CSDLabel storedLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003542 RID: 13634
		private CustomSelfDrawPanel.CSDLabel storedLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003543 RID: 13635
		private CustomSelfDrawPanel.CSDLabel storedLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003544 RID: 13636
		private CustomSelfDrawPanel.CSDLabel storedLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003545 RID: 13637
		private CustomSelfDrawPanel.CSDLabel storedLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003546 RID: 13638
		private CustomSelfDrawPanel.CSDLabel storedLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003547 RID: 13639
		private CustomSelfDrawPanel.CSDLabel priceLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003548 RID: 13640
		private CustomSelfDrawPanel.CSDLabel priceLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003549 RID: 13641
		private CustomSelfDrawPanel.CSDLabel priceLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354A RID: 13642
		private CustomSelfDrawPanel.CSDLabel priceLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354B RID: 13643
		private CustomSelfDrawPanel.CSDLabel priceLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354C RID: 13644
		private CustomSelfDrawPanel.CSDLabel priceLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354D RID: 13645
		private CustomSelfDrawPanel.CSDLabel priceLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354E RID: 13646
		private CustomSelfDrawPanel.CSDLabel priceLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400354F RID: 13647
		private CustomSelfDrawPanel.CSDButton lowestPriceRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003550 RID: 13648
		private CustomSelfDrawPanel.CSDButton lowestPriceRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003551 RID: 13649
		private CustomSelfDrawPanel.CSDButton lowestPriceRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003552 RID: 13650
		private CustomSelfDrawPanel.CSDButton lowestPriceRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003553 RID: 13651
		private CustomSelfDrawPanel.CSDButton lowestPriceRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003554 RID: 13652
		private CustomSelfDrawPanel.CSDButton lowestPriceRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003555 RID: 13653
		private CustomSelfDrawPanel.CSDButton lowestPriceRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003556 RID: 13654
		private CustomSelfDrawPanel.CSDButton lowestPriceRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003557 RID: 13655
		private CustomSelfDrawPanel.CSDButton highestPriceRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003558 RID: 13656
		private CustomSelfDrawPanel.CSDButton highestPriceRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003559 RID: 13657
		private CustomSelfDrawPanel.CSDButton highestPriceRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355A RID: 13658
		private CustomSelfDrawPanel.CSDButton highestPriceRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355B RID: 13659
		private CustomSelfDrawPanel.CSDButton highestPriceRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355C RID: 13660
		private CustomSelfDrawPanel.CSDButton highestPriceRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355D RID: 13661
		private CustomSelfDrawPanel.CSDButton highestPriceRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355E RID: 13662
		private CustomSelfDrawPanel.CSDButton highestPriceRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400355F RID: 13663
		private CustomSelfDrawPanel.CSDLabel traderCapacityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003560 RID: 13664
		private CustomSelfDrawPanel.CSDLabel traderCapacityValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003561 RID: 13665
		private CustomSelfDrawPanel.CSDLabel tradersAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003562 RID: 13666
		private CustomSelfDrawPanel.CSDLabel tradersAvailableValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003563 RID: 13667
		private CustomSelfDrawPanel.CSDImage traderIconImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003564 RID: 13668
		private CustomSelfDrawPanel.CSDImage villageSelectPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003565 RID: 13669
		private CustomSelfDrawPanel.CSDImage villageSelectPanelHeader = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003566 RID: 13670
		private CustomSelfDrawPanel.CSDLabel villageSelectPanelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003567 RID: 13671
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003568 RID: 13672
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003569 RID: 13673
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356A RID: 13674
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356B RID: 13675
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356C RID: 13676
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356D RID: 13677
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356E RID: 13678
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400356F RID: 13679
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003570 RID: 13680
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003571 RID: 13681
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003572 RID: 13682
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003573 RID: 13683
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003574 RID: 13684
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003575 RID: 13685
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003576 RID: 13686
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003577 RID: 13687
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003578 RID: 13688
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003579 RID: 13689
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357A RID: 13690
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357B RID: 13691
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357C RID: 13692
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357D RID: 13693
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357E RID: 13694
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400357F RID: 13695
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003580 RID: 13696
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003581 RID: 13697
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003582 RID: 13698
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003583 RID: 13699
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003584 RID: 13700
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003585 RID: 13701
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003586 RID: 13702
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003587 RID: 13703
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003588 RID: 13704
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003589 RID: 13705
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358A RID: 13706
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358B RID: 13707
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358C RID: 13708
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358D RID: 13709
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358E RID: 13710
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400358F RID: 13711
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003590 RID: 13712
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003591 RID: 13713
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003592 RID: 13714
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003593 RID: 13715
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003594 RID: 13716
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003595 RID: 13717
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003596 RID: 13718
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003597 RID: 13719
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003598 RID: 13720
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003599 RID: 13721
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400359A RID: 13722
		private CustomSelfDrawPanel.CSDButton worldMapButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400359B RID: 13723
		private CustomSelfDrawPanel.CSDCheckBox advancedOptions = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x0400359C RID: 13724
		private CustomSelfDrawPanel.CSDExtendingPanel noResearchWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400359D RID: 13725
		private CustomSelfDrawPanel.CSDLabel noResearchText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400359E RID: 13726
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x0400359F RID: 13727
		private bool lastPremiumType;

		// Token: 0x040035A0 RID: 13728
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040035A1 RID: 13729
		private int lastSeaConditions = -1;

		// Token: 0x040035A2 RID: 13730
		private int selectedStockExchange = -1;

		// Token: 0x040035A3 RID: 13731
		private int lastTab = -1;

		// Token: 0x040035A4 RID: 13732
		private int currentResource = -1;

		// Token: 0x040035A5 RID: 13733
		private int currentResourcePacketSize = 1;

		// Token: 0x040035A6 RID: 13734
		private int currentResourcePacketSizeREAL = 1;

		// Token: 0x040035A7 RID: 13735
		private int BACKUP_resource = -1;

		// Token: 0x040035A8 RID: 13736
		private int BACKUP_sellLevel;

		// Token: 0x040035A9 RID: 13737
		private int BACKUP_buyLevel;

		// Token: 0x040035AA RID: 13738
		private int lastHighlightResource = -1;

		// Token: 0x040035AB RID: 13739
		private int numTraders;

		// Token: 0x040035AC RID: 13740
		private int numFreeTraders;

		// Token: 0x040035AD RID: 13741
		private List<int> closeCapitalsToTest = new List<int>();

		// Token: 0x040035AE RID: 13742
		private DateTime lastTradeTime = DateTime.MinValue;

		// Token: 0x040035AF RID: 13743
		public SparseArray stockExchanges = new SparseArray();

		// Token: 0x040035B0 RID: 13744
		[CompilerGenerated]
		private static Comparison<StockExchangePanel.ClosestCapitalSortItem> _003C_003E9__CachedAnonymousMethodDelegate1;

		// Token: 0x02000498 RID: 1176
		public class ClosestCapitalSortItem
		{
			// Token: 0x040035B1 RID: 13745
			public int villageID = -1;

			// Token: 0x040035B2 RID: 13746
			public int distance;
		}

		// Token: 0x02000499 RID: 1177
		public class StockExchangeInfo
		{
			// Token: 0x06002B06 RID: 11014 RVA: 0x00220E48 File Offset: 0x0021F048
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

			// Token: 0x06002B07 RID: 11015 RVA: 0x0001F9EB File Offset: 0x0001DBEB
			public int getFakeLevel(int resource)
			{
				return this.getLevel(resource);
			}

			// Token: 0x040035B3 RID: 13747
			public DateTime lastTime = DateTime.MinValue;

			// Token: 0x040035B4 RID: 13748
			public int villageID = -1;

			// Token: 0x040035B5 RID: 13749
			public int woodLevel;

			// Token: 0x040035B6 RID: 13750
			public int stoneLevel;

			// Token: 0x040035B7 RID: 13751
			public int ironLevel;

			// Token: 0x040035B8 RID: 13752
			public int pitchLevel;

			// Token: 0x040035B9 RID: 13753
			public int aleLevel;

			// Token: 0x040035BA RID: 13754
			public int applesLevel;

			// Token: 0x040035BB RID: 13755
			public int breadLevel;

			// Token: 0x040035BC RID: 13756
			public int meatLevel;

			// Token: 0x040035BD RID: 13757
			public int cheeseLevel;

			// Token: 0x040035BE RID: 13758
			public int vegLevel;

			// Token: 0x040035BF RID: 13759
			public int fishLevel;

			// Token: 0x040035C0 RID: 13760
			public int bowsLevel;

			// Token: 0x040035C1 RID: 13761
			public int pikesLevel;

			// Token: 0x040035C2 RID: 13762
			public int swordsLevel;

			// Token: 0x040035C3 RID: 13763
			public int armourLevel;

			// Token: 0x040035C4 RID: 13764
			public int catapultsLevel;

			// Token: 0x040035C5 RID: 13765
			public int furnitureLevel;

			// Token: 0x040035C6 RID: 13766
			public int clothesLevel;

			// Token: 0x040035C7 RID: 13767
			public int saltLevel;

			// Token: 0x040035C8 RID: 13768
			public int venisonLevel;

			// Token: 0x040035C9 RID: 13769
			public int silkLevel;

			// Token: 0x040035CA RID: 13770
			public int spicesLevel;

			// Token: 0x040035CB RID: 13771
			public int metalwareLevel;

			// Token: 0x040035CC RID: 13772
			public int wineLevel;
		}
	}
}
