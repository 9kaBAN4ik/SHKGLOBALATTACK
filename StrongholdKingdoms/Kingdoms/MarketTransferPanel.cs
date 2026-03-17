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
	// Token: 0x0200023B RID: 571
	public class MarketTransferPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600193A RID: 6458 RVA: 0x00019A60 File Offset: 0x00017C60
		public static List<WorldMap.VillageNameItem> VillageHistory
		{
			get
			{
				return MarketTransferPanel.villageHistory;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x0600193B RID: 6459 RVA: 0x00019A67 File Offset: 0x00017C67
		public static List<WorldMap.VillageNameItem> VillageFavourites
		{
			get
			{
				return MarketTransferPanel.villageFavourites;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x00019A6E File Offset: 0x00017C6E
		public int SelectedTargetVillage
		{
			get
			{
				return this.selectedTargetVillage;
			}
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00019A76 File Offset: 0x00017C76
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x00019A86 File Offset: 0x00017C86
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00019A96 File Offset: 0x00017C96
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x00019AA8 File Offset: 0x00017CA8
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00019AB5 File Offset: 0x00017CB5
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x00019AC9 File Offset: 0x00017CC9
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x00019AD6 File Offset: 0x00017CD6
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00019AE3 File Offset: 0x00017CE3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x00190358 File Offset: 0x0018E558
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "MarketTransferPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x001903C4 File Offset: 0x0018E5C4
		public static void addHistory(List<GenericVillageHistoryData> newData)
		{
			MarketTransferPanel.villageHistory.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					villageNameItem.villageName = GameEngine.Instance.World.getVillageName(genericVillageHistoryData.villageID);
					MarketTransferPanel.villageHistory.Add(villageNameItem);
				}
			}
		}

		// Token: 0x06001947 RID: 6471 RVA: 0x00190450 File Offset: 0x0018E650
		public static void addFavourites(List<GenericVillageHistoryData> newData)
		{
			MarketTransferPanel.villageFavourites.Clear();
			if (newData != null)
			{
				foreach (GenericVillageHistoryData genericVillageHistoryData in newData)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					villageNameItem.villageID = genericVillageHistoryData.villageID;
					MarketTransferPanel.villageFavourites.Add(villageNameItem);
				}
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x001904C4 File Offset: 0x0018E6C4
		public MarketTransferPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00190AC0 File Offset: 0x0018ECC0
		public void init()
		{
			MarketTransferPanel.instance = this;
			base.clearControls();
			this.lastSeaConditions = -1;
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("MarketTradeScreen_Trade_With_Village", "Trade with Village"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "MarketTransferPanel_close");
			this.closeButton.CustomTooltipID = 801;
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
			this.newTradingButton.ImageNorm = GFXLibrary.se_tabs[0];
			this.newTradingButton.ImageOver = GFXLibrary.se_tabs[1];
			this.newTradingButton.ImageClick = GFXLibrary.se_tabs[1];
			this.newTradingButton.Position = new Point(20, -17);
			this.newTradingButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.stockExchangeClick), "MarketTransferPanel_stock_exchange");
			this.newTradingButton.ClickArea = new Rectangle(95, 0, 94, 25);
			this.newTradingButton.CustomTooltipID = 806;
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
			this.lightArea2.Size = new Size(251, 329);
			this.lightArea2.Position = new Point(21, 102);
			this.midWindow.addControl(this.lightArea2);
			this.lightArea2.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.storedHeadingLabel.Text = SK.Text("MarketTradeScreen_At_Target", "At Target");
			this.storedHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.storedHeadingLabel.Position = new Point(0, -35);
			this.storedHeadingLabel.Size = new Size(251, 30);
			this.storedHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.storedHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea2.addControl(this.storedHeadingLabel);
			this.exchangeNameBar.Size = new Size(270, 31);
			this.exchangeNameBar.Position = new Point(11, 9);
			this.exchangeNameBar.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick));
			this.midWindow.addControl(this.exchangeNameBar);
			this.exchangeNameBar.Create(GFXLibrary.int_lineitem_inset_left, GFXLibrary.int_lineitem_inset_middle, GFXLibrary.int_lineitem_inset_right);
			this.exchangeNameLabel.Text = SK.Text("TRADE_Select_Village", "Select Village");
			this.exchangeNameLabel.Color = Color.FromArgb(196, 161, 85);
			this.exchangeNameLabel.Position = new Point(17, 7);
			this.exchangeNameLabel.Size = new Size(this.exchangeNameBar.Size.Width - 17 - 20, this.exchangeNameBar.Size.Height - 13);
			this.exchangeNameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.exchangeNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
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
			this.tabButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "MarketTransferPanel_resources_tab");
			this.tabButton1.Enabled = true;
			this.tabButton1.CustomTooltipID = 802;
			this.leftWindow.addControl(this.tabButton1);
			this.tabButton2.ImageNorm = GFXLibrary.int_storage_tab_02_normal;
			this.tabButton2.ImageOver = GFXLibrary.int_storage_tab_02_over;
			this.tabButton2.Position = new Point(83, -13);
			this.tabButton2.MoveOnClick = false;
			this.tabButton2.Data = 2;
			this.tabButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "MarketTransferPanel_food_tab");
			this.tabButton2.Enabled = true;
			this.tabButton2.CustomTooltipID = 803;
			this.leftWindow.addControl(this.tabButton2);
			this.tabButton3.ImageNorm = GFXLibrary.int_storage_tab_03_normal;
			this.tabButton3.ImageOver = GFXLibrary.int_storage_tab_03_over;
			this.tabButton3.Position = new Point(161, -13);
			this.tabButton3.MoveOnClick = false;
			this.tabButton3.Data = 3;
			this.tabButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "MarketTransferPanel_weapons_tab");
			this.tabButton3.Enabled = true;
			this.tabButton3.CustomTooltipID = 804;
			this.leftWindow.addControl(this.tabButton3);
			this.tabButton4.ImageNorm = GFXLibrary.int_storage_tab_04_normal;
			this.tabButton4.ImageOver = GFXLibrary.int_storage_tab_04_over;
			this.tabButton4.Position = new Point(239, -13);
			this.tabButton4.MoveOnClick = false;
			this.tabButton4.Data = 4;
			this.tabButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "MarketTransferPanel_banquetting_tab");
			this.tabButton4.Enabled = true;
			this.tabButton4.CustomTooltipID = 805;
			this.leftWindow.addControl(this.tabButton4);
			this.sendWindow.Size = new Size(336, 145);
			this.sendWindow.Position = new Point(637, 272);
			this.mainBackgroundArea.addControl(this.sendWindow);
			this.sendWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.sendSubWindow.Size = new Size(147, 50);
			this.sendSubWindow.Position = new Point(178, 32);
			this.sendWindow.addControl(this.sendSubWindow);
			this.sendSubWindow.Create(GFXLibrary.int_insetpanel_b_top_left, GFXLibrary.int_insetpanel_b_middle_top, GFXLibrary.int_insetpanel_b_top_right, GFXLibrary.int_insetpanel_b_middle_left, GFXLibrary.int_insetpanel_b_middle, GFXLibrary.int_insetpanel_b_middle_right, GFXLibrary.int_insetpanel_b_bottom_left, GFXLibrary.int_insetpanel_b_middle_bottom, GFXLibrary.int_insetpanel_b_bottom_right);
			this.sendHeadingLabel.Text = SK.Text("MarketTradeScreen_Send", "Send") + " ";
			this.sendHeadingLabel.Color = global::ARGBColors.Black;
			this.sendHeadingLabel.Position = new Point(90, -30);
			this.sendHeadingLabel.Size = new Size(246, 30);
			this.sendHeadingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			this.sendHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_LEFT;
			this.sendWindow.addControl(this.sendHeadingLabel);
			this.sendHeadingImage.Image = null;
			this.sendHeadingImage.Position = new Point(5, -50);
			this.sendWindow.addControl(this.sendHeadingImage);
			this.sendNumber.Text = "0";
			this.sendNumber.Color = Color.FromArgb(196, 161, 85);
			this.sendNumber.Position = new Point(63, -6);
			this.sendNumber.Size = new Size(70, 30);
			this.sendNumber.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sendNumber.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sendSubWindow.addControl(this.sendNumber);
			this.sendEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.sendEditButton.ImageOver = GFXLibrary.faction_pen;
			this.sendEditButton.ImageClick = GFXLibrary.faction_pen;
			this.sendEditButton.MoveOnClick = true;
			this.sendEditButton.OverBrighten = true;
			this.sendEditButton.Position = new Point(7, 5);
			this.sendEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "MarketTradeScreen_editValue");
			this.sendSubWindow.addControl(this.sendEditButton);
			this.sendButton.Position = new Point(177, 94);
			this.sendButton.Size = new Size(153, 38);
			this.sendButton.Text.Text = SK.Text("MarketTradeScreen_Send", "Send");
			this.sendButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sendButton.TextYOffset = -1;
			this.sendButton.Text.Color = global::ARGBColors.Black;
			this.sendButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendClick), "MarketTransferPanel_send");
			this.sendWindow.addControl(this.sendButton);
			this.sendButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.sendButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.sendTrack.Position = new Point(21, 41);
			this.sendTrack.Margin = new Rectangle(3, -1, 1, 0);
			this.sendTrack.Value = 0;
			this.sendTrack.Max = 1;
			this.sendTrack.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
			this.sendWindow.addControl(this.sendTrack);
			this.sendTrack.Create(GFXLibrary.int_slidebar_ruler, GFXLibrary.int_slidebar_thumb_middle_normal, GFXLibrary.int_slidebar_thumb_left_normal, GFXLibrary.int_slidebar_thumb_right_normal, GFXLibrary.int_slidebar_thumb_middle_in, GFXLibrary.int_slidebar_thumb_middle_over);
			this.sendMin.Text = "0";
			this.sendMin.Color = global::ARGBColors.Black;
			this.sendMin.Position = new Point(-2, 74);
			this.sendMin.Size = new Size(50, 30);
			this.sendMin.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.sendMin.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.sendWindow.addControl(this.sendMin);
			this.sendMax.Text = "0";
			this.sendMax.Color = global::ARGBColors.Black;
			this.sendMax.Position = new Point(126, 74);
			this.sendMax.Size = new Size(50, 30);
			this.sendMax.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
			this.sendMax.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.sendWindow.addControl(this.sendMax);
			this.sendNumberPackets.Text = SK.Text("TradeScreen_Merchants", "Merchants") + " : 0";
			this.sendNumberPackets.Color = Color.FromArgb(196, 161, 85);
			this.sendNumberPackets.Position = new Point(161, 44);
			this.sendNumberPackets.Size = new Size(150, 30);
			this.sendNumberPackets.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sendNumberPackets.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sendWindow.addControl(this.sendNumberPackets);
			this.highlightLine1.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine1.Position = new Point(153, 111);
			this.highlightLine1.Size = new Size(177, 31);
			this.leftWindow.addControl(this.highlightLine1);
			this.highlightLine2.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine2.Position = new Point(153, 151);
			this.highlightLine2.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine2);
			this.highlightLine3.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine3.Position = new Point(153, 191);
			this.highlightLine3.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine3);
			this.highlightLine4.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine4.Position = new Point(153, 231);
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
			this.storedLabel1.Text = "?";
			this.storedLabel1.Color = global::ARGBColors.Black;
			this.storedLabel1.Position = new Point(198, 1);
			this.storedLabel1.Size = new Size(251, 31);
			this.storedLabel1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine1.addControl(this.storedLabel1);
			this.storedLabel2.Text = "?";
			this.storedLabel2.Color = global::ARGBColors.Black;
			this.storedLabel2.Position = new Point(198, 1);
			this.storedLabel2.Size = new Size(251, 31);
			this.storedLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine2.addControl(this.storedLabel2);
			this.storedLabel3.Text = "?";
			this.storedLabel3.Color = global::ARGBColors.Black;
			this.storedLabel3.Position = new Point(198, 1);
			this.storedLabel3.Size = new Size(251, 31);
			this.storedLabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine3.addControl(this.storedLabel3);
			this.storedLabel4.Text = "?";
			this.storedLabel4.Color = global::ARGBColors.Black;
			this.storedLabel4.Position = new Point(198, 1);
			this.storedLabel4.Size = new Size(251, 31);
			this.storedLabel4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine4.addControl(this.storedLabel4);
			this.storedLabel5.Text = "?";
			this.storedLabel5.Color = global::ARGBColors.Black;
			this.storedLabel5.Position = new Point(198, 1);
			this.storedLabel5.Size = new Size(251, 31);
			this.storedLabel5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine5.addControl(this.storedLabel5);
			this.storedLabel6.Text = "?";
			this.storedLabel6.Color = global::ARGBColors.Black;
			this.storedLabel6.Position = new Point(198, 1);
			this.storedLabel6.Size = new Size(251, 31);
			this.storedLabel6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine6.addControl(this.storedLabel6);
			this.storedLabel7.Text = "?";
			this.storedLabel7.Color = global::ARGBColors.Black;
			this.storedLabel7.Position = new Point(198, 1);
			this.storedLabel7.Size = new Size(251, 31);
			this.storedLabel7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine7.addControl(this.storedLabel7);
			this.storedLabel8.Text = "?";
			this.storedLabel8.Color = global::ARGBColors.Black;
			this.storedLabel8.Position = new Point(198, 1);
			this.storedLabel8.Size = new Size(251, 31);
			this.storedLabel8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.storedLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.highlightLine8.addControl(this.storedLabel8);
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
			this.villageSelectPanelTab1.ImageNorm = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.ImageOver = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.ImageClick = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.Size = new Size(138, 20);
			this.villageSelectPanelTab1.Position = new Point(0, 3);
			this.villageSelectPanelTab1.Text.Text = SK.Text("MarketTradeScreen_Own", "Own");
			this.villageSelectPanelTab1.TextYOffset = -1;
			this.villageSelectPanelTab1.Data = 0;
			this.villageSelectPanelTab1.MoveOnClick = false;
			this.villageSelectPanelTab1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectPanelTab1.Text.Color = global::ARGBColors.Black;
			this.villageSelectPanelTab1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageTabClicked), "MarketTransferPanel_own_villages");
			this.villageSelectPanel.addControl(this.villageSelectPanelTab1);
			this.villageSelectPanelTab2.ImageNorm = GFXLibrary.tab_villagename_back;
			this.villageSelectPanelTab2.ImageOver = GFXLibrary.tab_villagename_over;
			this.villageSelectPanelTab2.ImageClick = GFXLibrary.tab_villagename_over;
			this.villageSelectPanelTab2.Size = new Size(138, 20);
			this.villageSelectPanelTab2.Position = new Point(138, 3);
			this.villageSelectPanelTab2.Text.Text = SK.Text("MarketTradeScreen_Recent", "Recent");
			this.villageSelectPanelTab2.TextYOffset = -1;
			this.villageSelectPanelTab2.Data = 1;
			this.villageSelectPanelTab2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectPanelTab2.Text.Color = global::ARGBColors.Black;
			this.villageSelectPanelTab2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageTabClicked), "MarketTransferPanel_recent_villages");
			this.villageSelectPanel.addControl(this.villageSelectPanelTab2);
			this.villageSelectVillage1.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageNorm = null;
			this.villageSelectVillage1.Size = new Size(232, 16);
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
			this.villageSelectVillage2.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage2.ImageNorm = null;
			this.villageSelectVillage2.Size = new Size(232, 16);
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
			this.villageSelectVillage3.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage3.ImageNorm = null;
			this.villageSelectVillage3.Size = new Size(232, 16);
			this.villageSelectVillage3.Position = new Point(20, 57);
			this.villageSelectVillage3.Text.Text = "Village 1";
			this.villageSelectVillage3.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectVillage3.Text.Position = new Point(5, 0);
			this.villageSelectVillage3.Text.Size = new Size(this.villageSelectVillage3.Width - 10, this.villageSelectVillage3.Height);
			this.villageSelectVillage3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.villageSelectVillage3.TextYOffset = 0;
			this.villageSelectVillage3.Text.Color = Color.FromArgb(196, 161, 85);
			this.villageSelectVillage3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageClicked));
			this.villageSelectVillage3.Data = 2;
			this.villageSelectPanel.addControl(this.villageSelectVillage3);
			this.villageSelectVillage4.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage4.ImageNorm = null;
			this.villageSelectVillage4.Size = new Size(232, 16);
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
			this.villageSelectVillage5.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage5.ImageNorm = null;
			this.villageSelectVillage5.Size = new Size(232, 16);
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
			this.villageSelectVillage6.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage6.ImageNorm = null;
			this.villageSelectVillage6.Size = new Size(232, 16);
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
			this.villageSelectVillage7.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage7.ImageNorm = null;
			this.villageSelectVillage7.Size = new Size(232, 16);
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
			this.villageSelectVillage8.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage8.ImageNorm = null;
			this.villageSelectVillage8.Size = new Size(232, 16);
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
			this.villageSelectVillage9.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage9.ImageNorm = null;
			this.villageSelectVillage9.Size = new Size(232, 16);
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
			this.villageSelectVillage10.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage10.ImageNorm = null;
			this.villageSelectVillage10.Size = new Size(232, 16);
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
			this.villageSelectVillage11.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage11.ImageNorm = null;
			this.villageSelectVillage11.Size = new Size(232, 16);
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
			this.villageSelectVillage12.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage12.ImageNorm = null;
			this.villageSelectVillage12.Size = new Size(232, 16);
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
			this.villageSelectVillage13.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage13.ImageNorm = null;
			this.villageSelectVillage13.Size = new Size(232, 16);
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
			this.villageSelectVillage14.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage14.ImageNorm = null;
			this.villageSelectVillage14.Size = new Size(232, 16);
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
			this.villageSelectVillage15.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage15.ImageNorm = null;
			this.villageSelectVillage15.Size = new Size(232, 16);
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
			this.villageSelectVillage16.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage16.ImageNorm = null;
			this.villageSelectVillage16.Size = new Size(232, 16);
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
			this.villageSelectVillage17.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage17.ImageNorm = null;
			this.villageSelectVillage17.Size = new Size(232, 16);
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
			this.worldMapButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.findOnWorldClicked), "MarketTransferPanel_find_on_map");
			this.villageSelectPanel.addControl(this.worldMapButton);
			this.villageOwnPageUp.ImageNorm = GFXLibrary.int_button_droparrow_up_normal;
			this.villageOwnPageUp.ImageOver = GFXLibrary.int_button_droparrow_up_over;
			this.villageOwnPageUp.ImageClick = GFXLibrary.int_button_droparrow_up_down;
			this.villageOwnPageUp.Position = new Point(200, 314);
			this.villageOwnPageUp.MoveOnClick = false;
			this.villageOwnPageUp.Data = 0;
			this.villageOwnPageUp.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnPageClicked), "MarketTransferPanel_page_up");
			this.villageSelectPanel.addControl(this.villageOwnPageUp);
			this.villageOwnPageDown.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.villageOwnPageDown.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.villageOwnPageDown.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.villageOwnPageDown.Position = new Point(230, 314);
			this.villageOwnPageDown.MoveOnClick = false;
			this.villageOwnPageDown.Data = 1;
			this.villageOwnPageDown.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnPageClicked), "MarketTransferPanel_page_down");
			this.villageSelectPanel.addControl(this.villageOwnPageDown);
			this.villageTabMode = 0;
			this.villageTabOwnPage = 0;
			this.updateVillageHistory();
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundArea.addControl(this.cardbar);
			this.cardbar.init(1);
			this.seaConditionsImage.Image = GFXLibrary.sea_conditions[0];
			this.seaConditionsImage.Position = new Point(328, 112);
			this.seaConditionsImage.CustomTooltipID = 23000;
			this.mainBackgroundArea.addControl(this.seaConditionsImage);
			this.lastTab = -1;
			this.manageTabs(1);
			this.updateDeliveryTime(-1);
			if (this.selectedTargetVillage >= 0)
			{
				this.resetBackupData();
				this.resume(this.selectedTargetVillage, false);
				this.selectHighlightLine(0);
			}
			this.update();
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x001966F8 File Offset: 0x001948F8
		public void update()
		{
			if (this.currentResource >= 0)
			{
				this.currentResourcePacketSize = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
			}
			this.updateValues();
			this.cardbar.update();
			this.updateDeliveryTime(this.selectedTargetVillage);
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00196748 File Offset: 0x00194948
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

		// Token: 0x0600194C RID: 6476 RVA: 0x00019B02 File Offset: 0x00017D02
		public void logout()
		{
			this.selectedTargetVillage = -1;
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00196784 File Offset: 0x00194984
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

		// Token: 0x0600194E RID: 6478 RVA: 0x00196970 File Offset: 0x00194B70
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
			this.sendHeadingLabel.Text = SK.Text("MarketTradeScreen_Send", "Send") + " " + VillageBuildingsData.getResourceNames(this.currentResource);
			this.sendHeadingImage.Image = GFXLibrary.getCommodity64DSImage(this.currentResource);
			this.sendTrack.Max = 500000000;
			this.sendTrack.Value = 500000000;
			this.showSendWindow();
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00196AA8 File Offset: 0x00194CA8
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

		// Token: 0x06001950 RID: 6480 RVA: 0x00196B38 File Offset: 0x00194D38
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

		// Token: 0x06001951 RID: 6481 RVA: 0x00196BE4 File Offset: 0x00194DE4
		private void initArmouryTab()
		{
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

		// Token: 0x06001952 RID: 6482 RVA: 0x00196C80 File Offset: 0x00194E80
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

		// Token: 0x06001953 RID: 6483 RVA: 0x00196D38 File Offset: 0x00194F38
		private void rowClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.currentResource)
				{
					this.sendTrack.Max = 500000000;
					this.sendTrack.Value = 500000000;
					GameEngine.Instance.playInterfaceSound("MarketTransferPanel_resource_clicked");
					this.selectHighlightLine(this.getLineFromResource(csdbutton.Data));
					base.Invalidate();
				}
			}
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00196DB0 File Offset: 0x00194FB0
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

		// Token: 0x06001955 RID: 6485 RVA: 0x00196F00 File Offset: 0x00195100
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

		// Token: 0x06001956 RID: 6486 RVA: 0x00196F30 File Offset: 0x00195130
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
			rowStored.Text = "?";
			if (stockLevel >= 0)
			{
				rowStored.Text = stockLevel.ToString("N", nfi);
			}
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00196F98 File Offset: 0x00195198
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

		// Token: 0x06001958 RID: 6488 RVA: 0x00197008 File Offset: 0x00195208
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

		// Token: 0x06001959 RID: 6489 RVA: 0x00197078 File Offset: 0x00195278
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

		// Token: 0x0600195A RID: 6490 RVA: 0x001970E8 File Offset: 0x001952E8
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

		// Token: 0x0600195B RID: 6491 RVA: 0x00197158 File Offset: 0x00195358
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

		// Token: 0x0600195C RID: 6492 RVA: 0x0019722C File Offset: 0x0019542C
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

		// Token: 0x0600195D RID: 6493 RVA: 0x00197300 File Offset: 0x00195500
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

		// Token: 0x0600195E RID: 6494 RVA: 0x00019B0B File Offset: 0x00017D0B
		private void exchangeArrowClick()
		{
			if (this.exchangeArrowButton.Data == 0)
			{
				GameEngine.Instance.playInterfaceSound("MarketTransferPanel_village_list_open");
				this.showVillagePanel(true);
				return;
			}
			GameEngine.Instance.playInterfaceSound("MarketTransferPanel_village_list_close");
			this.showVillagePanel(false);
		}

		// Token: 0x0600195F RID: 6495 RVA: 0x001973D4 File Offset: 0x001955D4
		private void villageTabClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			if (csdbutton.Data != this.villageTabMode)
			{
				if (csdbutton.Data == 0)
				{
					this.villageSelectPanelTab1.ImageNorm = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab1.ImageOver = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab1.ImageClick = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab1.MoveOnClick = false;
					this.villageSelectPanelTab2.ImageNorm = GFXLibrary.tab_villagename_back;
					this.villageSelectPanelTab2.ImageOver = GFXLibrary.tab_villagename_over;
					this.villageSelectPanelTab2.ImageClick = GFXLibrary.tab_villagename_over;
					this.villageSelectPanelTab2.MoveOnClick = true;
				}
				else
				{
					this.villageSelectPanelTab2.ImageNorm = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab2.ImageOver = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab2.ImageClick = GFXLibrary.tab_villagename_forward;
					this.villageSelectPanelTab2.MoveOnClick = false;
					this.villageSelectPanelTab1.ImageNorm = GFXLibrary.tab_villagename_back;
					this.villageSelectPanelTab1.ImageOver = GFXLibrary.tab_villagename_over;
					this.villageSelectPanelTab1.ImageClick = GFXLibrary.tab_villagename_over;
					this.villageSelectPanelTab1.MoveOnClick = true;
					this.villageTabOwnPage = 0;
				}
				this.villageTabMode = csdbutton.Data;
				this.updateVillageHistory();
			}
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x0019755C File Offset: 0x0019575C
		private void turnPageClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			if (csdbutton.Data == 0)
			{
				this.villageTabOwnPage--;
				if (this.villageTabOwnPage < 0)
				{
					this.villageTabOwnPage = 0;
				}
			}
			else
			{
				this.villageTabOwnPage++;
			}
			this.updateVillageHistory();
		}

		// Token: 0x06001961 RID: 6497 RVA: 0x001975BC File Offset: 0x001957BC
		private void villageClicked()
		{
			if (this.ClickedControl != null)
			{
				GameEngine.Instance.playInterfaceSound("MarketTransferPanel_village_clicked");
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				this.BACKUP_resource = this.currentResource;
				this.BACKUP_sendLevel = this.sendTrack.Value;
				this.resume(csdbutton.Data, true);
				this.showVillagePanel(false);
			}
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x00197620 File Offset: 0x00195820
		private void villageRecentDeleteClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				RemoteServices.Instance.UpdateVillageFavourites(7, data);
				foreach (WorldMap.VillageNameItem villageNameItem in MarketTransferPanel.villageHistory)
				{
					if (villageNameItem.villageID == data)
					{
						MarketTransferPanel.villageHistory.Remove(villageNameItem);
						this.updateVillageHistory();
						break;
					}
				}
			}
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x001976B0 File Offset: 0x001958B0
		private void villageFavouriteClicked()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			bool flag = false;
			foreach (WorldMap.VillageNameItem villageNameItem in MarketTransferPanel.villageFavourites)
			{
				if (villageNameItem.villageID == data)
				{
					flag = true;
					MarketTransferPanel.villageFavourites.Remove(villageNameItem);
					break;
				}
			}
			if (flag)
			{
				RemoteServices.Instance.UpdateVillageFavourites(1, data);
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
			RemoteServices.Instance.UpdateVillageFavourites(0, data);
			WorldMap.VillageNameItem villageNameItem2 = new WorldMap.VillageNameItem();
			villageNameItem2.villageID = data;
			villageNameItem2.villageName = GameEngine.Instance.World.getVillageName(data);
			MarketTransferPanel.villageFavourites.Add(villageNameItem2);
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

		// Token: 0x06001964 RID: 6500 RVA: 0x00197808 File Offset: 0x00195A08
		private void showVillagePanel(bool show)
		{
			this.villageSelectPanel.Visible = show;
			if (show)
			{
				this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_up_normal;
				this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_up_over;
				this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_up_down;
				this.exchangeArrowButton.Data = 1;
				this.updateVillageHistory();
				return;
			}
			this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.exchangeArrowButton.Data = 0;
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x001978C4 File Offset: 0x00195AC4
		public void updateValues()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				WorldData localWorldData = GameEngine.Instance.LocalWorldData;
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = null;
				if (this.selectedTargetVillage >= 0 && GameEngine.Instance.World.isUserVillage(this.selectedTargetVillage))
				{
					stockExchangeInfo = this.lastVillageData;
				}
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
						this.setRowValues(0, (int)stockpileLevels.woodLevel, stockExchangeInfo.woodLevel, -1);
						this.setRowValues(1, (int)stockpileLevels.stoneLevel, stockExchangeInfo.stoneLevel, -1);
						this.setRowValues(2, (int)stockpileLevels.ironLevel, stockExchangeInfo.ironLevel, -1);
						this.setRowValues(3, (int)stockpileLevels.pitchLevel, stockExchangeInfo.pitchLevel, -1);
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
						this.setRowValues(0, (int)granaryLevels.applesLevel, stockExchangeInfo.applesLevel, -1);
						this.setRowValues(1, (int)granaryLevels.cheeseLevel, stockExchangeInfo.cheeseLevel, -1);
						this.setRowValues(2, (int)granaryLevels.meatLevel, stockExchangeInfo.meatLevel, -1);
						this.setRowValues(3, (int)granaryLevels.breadLevel, stockExchangeInfo.breadLevel, -1);
						this.setRowValues(4, (int)granaryLevels.vegLevel, stockExchangeInfo.vegLevel, -1);
						this.setRowValues(5, (int)granaryLevels.fishLevel, stockExchangeInfo.fishLevel, -1);
						this.setRowValues(6, (int)innLevels.aleLevel, stockExchangeInfo.aleLevel, -1);
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
						this.setRowValues(0, (int)armouryLevels.bowsLevel, stockExchangeInfo.bowsLevel, -1);
						this.setRowValues(1, (int)armouryLevels.pikesLevel, stockExchangeInfo.pikesLevel, -1);
						this.setRowValues(2, (int)armouryLevels.armourLevel, stockExchangeInfo.armourLevel, -1);
						this.setRowValues(3, (int)armouryLevels.swordsLevel, stockExchangeInfo.swordsLevel, -1);
						this.setRowValues(4, (int)armouryLevels.catapultsLevel, stockExchangeInfo.catapultsLevel, -1);
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
						this.setRowValues(0, (int)townHallLevels.venisonLevel, stockExchangeInfo.venisonLevel, -1);
						this.setRowValues(1, (int)townHallLevels.furnitureLevel, stockExchangeInfo.furnitureLevel, -1);
						this.setRowValues(2, (int)townHallLevels.metalwareLevel, stockExchangeInfo.metalwareLevel, -1);
						this.setRowValues(3, (int)townHallLevels.clothesLevel, stockExchangeInfo.clothesLevel, -1);
						this.setRowValues(4, (int)townHallLevels.wineLevel, stockExchangeInfo.wineLevel, -1);
						this.setRowValues(5, (int)townHallLevels.saltLevel, stockExchangeInfo.saltLevel, -1);
						this.setRowValues(6, (int)townHallLevels.spicesLevel, stockExchangeInfo.spicesLevel, -1);
						this.setRowValues(7, (int)townHallLevels.silkLevel, stockExchangeInfo.silkLevel, -1);
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
			this.showSendWindow();
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x00197E2C File Offset: 0x0019602C
		public void updateVillageHistory()
		{
			for (int i = 0; i < 17; i++)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = this.getVillageHistory(i);
				csdbutton.Visible = false;
				CustomSelfDrawPanel.CSDButton villageHistoryFavourite = this.getVillageHistoryFavourite(i);
				villageHistoryFavourite.Visible = false;
				CustomSelfDrawPanel.CSDButton villageHistoryDelete = this.getVillageHistoryDelete(i);
				villageHistoryDelete.Visible = false;
			}
			if (this.villageTabMode == 0)
			{
				List<WorldMap.VillageNameItem> userVillageNamesList = GameEngine.Instance.World.getUserVillageNamesList();
				List<WorldMap.VillageNameItem> list = new List<WorldMap.VillageNameItem>();
				foreach (WorldMap.VillageNameItem villageNameItem in userVillageNamesList)
				{
					if (villageNameItem.villageID >= 0)
					{
						list.Add(villageNameItem);
					}
				}
				int num = 0;
				int num2 = this.villageTabOwnPage * 16;
				while (num < 16 && num2 < list.Count)
				{
					if (num2 < list.Count)
					{
						WorldMap.VillageNameItem villageNameItem2 = list[num2];
						CustomSelfDrawPanel.CSDButton csdbutton2 = this.getVillageHistory(num);
						csdbutton2.Visible = true;
						csdbutton2.Text.Text = GameEngine.Instance.World.getVillageName(villageNameItem2.villageID);
						csdbutton2.Data = villageNameItem2.villageID;
					}
					num2++;
					num++;
				}
				if (list.Count > 16)
				{
					this.villageOwnPageDown.Visible = true;
					this.villageOwnPageUp.Visible = true;
					if (this.villageTabOwnPage == 0)
					{
						this.villageOwnPageUp.Visible = false;
						return;
					}
					if (this.villageTabOwnPage >= (list.Count - 1) / 16)
					{
						this.villageOwnPageDown.Visible = false;
						return;
					}
				}
				else
				{
					this.villageOwnPageDown.Visible = false;
					this.villageOwnPageUp.Visible = false;
				}
				return;
			}
			this.villageOwnPageDown.Visible = false;
			this.villageOwnPageUp.Visible = false;
			int num3 = 0;
			while (num3 < 17 && num3 < MarketTransferPanel.villageFavourites.Count)
			{
				WorldMap.VillageNameItem villageNameItem3 = MarketTransferPanel.villageFavourites[num3];
				CustomSelfDrawPanel.CSDButton csdbutton3 = this.getVillageHistory(num3);
				csdbutton3.Visible = true;
				csdbutton3.Text.Text = GameEngine.Instance.World.getExchangeName(villageNameItem3.villageID);
				csdbutton3.Data = villageNameItem3.villageID;
				CustomSelfDrawPanel.CSDButton villageHistoryFavourite2 = this.getVillageHistoryFavourite(num3);
				villageHistoryFavourite2.ImageNorm = GFXLibrary.star_market_1;
				villageHistoryFavourite2.Visible = true;
				villageHistoryFavourite2.Data = villageNameItem3.villageID;
				villageHistoryFavourite2.CustomTooltipID = 811;
				CustomSelfDrawPanel.CSDButton villageHistoryDelete2 = this.getVillageHistoryDelete(num3);
				villageHistoryDelete2.Data = villageNameItem3.villageID;
				num3++;
			}
			int num4 = 0;
			while (num3 < 17 && num4 < MarketTransferPanel.villageHistory.Count)
			{
				WorldMap.VillageNameItem villageNameItem4 = MarketTransferPanel.villageHistory[num4];
				bool flag = false;
				foreach (WorldMap.VillageNameItem villageNameItem5 in MarketTransferPanel.villageFavourites)
				{
					if (villageNameItem5.villageID == villageNameItem4.villageID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					CustomSelfDrawPanel.CSDButton csdbutton4 = this.getVillageHistory(num3);
					csdbutton4.Visible = true;
					csdbutton4.Text.Text = GameEngine.Instance.World.getExchangeName(villageNameItem4.villageID);
					csdbutton4.Data = villageNameItem4.villageID;
					CustomSelfDrawPanel.CSDButton villageHistoryFavourite3 = this.getVillageHistoryFavourite(num3);
					villageHistoryFavourite3.ImageNorm = GFXLibrary.star_market_2;
					villageHistoryFavourite3.Visible = true;
					villageHistoryFavourite3.Data = villageNameItem4.villageID;
					villageHistoryFavourite3.CustomTooltipID = 812;
					CustomSelfDrawPanel.CSDButton villageHistoryDelete3 = this.getVillageHistoryDelete(num3);
					villageHistoryDelete3.Visible = true;
					villageHistoryDelete3.Data = villageNameItem4.villageID;
					villageHistoryDelete3.CustomTooltipID = 813;
					num3++;
				}
				num4++;
			}
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x001981F0 File Offset: 0x001963F0
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
				GameEngine.Instance.World.getVillageRegion(village.VillageID);
				int x2 = villageLocation2.X;
				int y2 = villageLocation2.Y;
				GameEngine.Instance.World.getVillageRegion(villageID);
				double num = (double)((x - x2) * (x - x2) + (y - y2) * (y - y2));
				num = Math.Sqrt(num);
				num *= localWorldData.traderMoveSpeed * localWorldData.gamePlaySpeed;
				num = GameEngine.Instance.World.UserResearchData.adjustTradeTimes(num);
				num *= CardTypes.cards_adjustTradeTimes(GameEngine.Instance.cardsManager.UserCardData);
				num = CardTypes.cards_adjustTradeTimesCompleteDelivery(GameEngine.Instance.cardsManager.UserCardData, num);
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

		// Token: 0x06001968 RID: 6504 RVA: 0x00198434 File Offset: 0x00196634
		private void showSendWindow()
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			bool visible = this.sendWindow.Visible;
			this.sendWindow.Visible = false;
			if (GameEngine.Instance.World.UserResearchData.Research_Merchant_Guilds == 0 || GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village != null && this.currentResource >= 0)
			{
				int num = (int)village.getResourceLevel(this.currentResource);
				int num2 = this.numFreeTraders * GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
				if (num > num2)
				{
					num = num2;
				}
				int max = this.sendTrack.Max;
				if (num > max)
				{
					this.sendTrack.Max = num;
				}
				else if (num < max)
				{
					if (this.sendTrack.Value > num)
					{
						this.sendTrack.Value = num;
					}
					this.sendTrack.Max = num;
				}
				this.sendMax.Text = this.sendTrack.Max.ToString("N", nfi);
				this.sendNumber.Text = this.sendTrack.Value.ToString("N", nfi);
				int num3 = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
				if (num3 == 0)
				{
					num3 = 1;
				}
				this.sendNumberPackets.Text = SK.Text("TradeScreen_Merchants", "Merchants") + " : " + ((this.sendTrack.Value + (num3 - 1)) / num3).ToString("N", nfi);
				if (num > 0 && num2 > 0 && this.selectedTargetVillage >= 0)
				{
					this.sendWindow.Visible = true;
				}
			}
			this.validateSendButtons();
			if (visible != this.sendWindow.Visible)
			{
				this.mainBackgroundImage.invalidate();
			}
		}

		// Token: 0x06001969 RID: 6505 RVA: 0x00198610 File Offset: 0x00196810
		private void validateSendButtons()
		{
			if (!this.sendWindow.Visible)
			{
				this.sendButton.Enabled = false;
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village == null)
			{
				this.sendButton.Enabled = false;
				return;
			}
			if (this.selectedTargetVillage < 0 || this.selectedTargetVillage == village.VillageID)
			{
				this.sendButton.Enabled = false;
				return;
			}
			if (this.sendTrack.Value > 0 && this.sendTrack.Value <= (int)village.getResourceLevel(this.currentResource))
			{
				this.sendButton.Enabled = true;
				return;
			}
			this.sendButton.Enabled = false;
		}

		// Token: 0x0600196A RID: 6506 RVA: 0x001986BC File Offset: 0x001968BC
		private void findOnWorldClicked()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.BACKUP_resource = this.currentResource;
				this.BACKUP_sendLevel = this.sendTrack.Value;
				GameEngine.Instance.World.zoomToVillage(village.VillageID);
				InterfaceMgr.Instance.getMainTabBar().selectDummyTab(3);
			}
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00019B47 File Offset: 0x00017D47
		private void tracksMoved()
		{
			this.showSendWindow();
			this.sendWindow.invalidate();
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x00019B5A File Offset: 0x00017D5A
		public void resetBackupData()
		{
			this.BACKUP_resource = -1;
			this.BACKUP_sendLevel = 500000000;
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x00019B6E File Offset: 0x00017D6E
		public void backupData()
		{
			this.BACKUP_resource = this.currentResource;
			this.BACKUP_sendLevel = this.sendTrack.Value;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x0019871C File Offset: 0x0019691C
		public void resume(int villageID, bool keepInfo)
		{
			this.tabButton1.Enabled = true;
			this.tabButton2.Enabled = true;
			this.tabButton3.Enabled = true;
			this.tabButton4.Enabled = true;
			if (keepInfo)
			{
				this.currentResource = this.BACKUP_resource;
			}
			else
			{
				this.BACKUP_sendLevel = 0;
				this.currentResource = 0;
				this.BACKUP_resource = -1;
			}
			if (villageID < 0)
			{
				this.selectedTargetVillage = -1;
				return;
			}
			this.selectedTargetVillage = villageID;
			this.lastVillageData = null;
			if (GameEngine.Instance.World.isUserVillage(this.selectedTargetVillage))
			{
				bool flag = true;
				if (this.stockExchanges[this.selectedTargetVillage] != null)
				{
					StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[this.selectedTargetVillage];
					if ((DateTime.Now - stockExchangeInfo.lastTime).TotalMinutes < 3.0)
					{
						flag = false;
					}
					this.lastVillageData = stockExchangeInfo;
				}
				if (flag)
				{
					RemoteServices.Instance.set_GetStockExchangeData_UserCallBack(new RemoteServices.GetStockExchangeData_UserCallBack(this.getStockExchangeDataCallback));
					RemoteServices.Instance.GetStockExchangeData(villageID, false);
				}
			}
			this.updateDeliveryTime(villageID);
			this.exchangeNameLabel.Text = GameEngine.Instance.World.getVillageName(villageID);
			if (GameEngine.Instance.World.isCapital(villageID))
			{
				if (this.BACKUP_resource != 6 && this.BACKUP_resource != 7 && this.BACKUP_resource != 8 && this.BACKUP_resource != 9)
				{
					this.BACKUP_resource = -1;
					this.manageTabs(1);
				}
				this.tabButton2.Enabled = false;
				this.tabButton3.Enabled = false;
				this.tabButton4.Enabled = false;
			}
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
				this.sendTrack.Max = 500000000;
				this.sendTrack.Value = this.BACKUP_sendLevel;
			}
			this.updateValues();
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x00019B8D File Offset: 0x00017D8D
		private void floatingValueCB(int value)
		{
			this.sendTrack.Value = value;
			this.updateValues();
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x001989B8 File Offset: 0x00196BB8
		private void editSendValue()
		{
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.floatingValueCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(620 + base.Location.X + 217, 360 + base.Location.Y + 120 - 50));
			FloatingInput.open(point.X, point.Y, this.sendTrack.Value, this.sendTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x00198A58 File Offset: 0x00196C58
		private void sendClick()
		{
			this.validateSendButtons();
			if (!this.sendButton.Enabled)
			{
				return;
			}
			DateTime now = DateTime.Now;
			if ((now - this.lastTradeTime).TotalSeconds < 2.0)
			{
				return;
			}
			this.lastTradeTime = now;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.dirtyStockExchangeInfo(this.selectedTargetVillage);
				village.sendResources(this.selectedTargetVillage, this.currentResource, this.sendTrack.Value);
				this.addVillageToHistory(this.selectedTargetVillage);
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

		// Token: 0x06001973 RID: 6515 RVA: 0x00198C54 File Offset: 0x00196E54
		private void addVillageToHistory(int villageID)
		{
			bool flag = false;
			foreach (WorldMap.VillageNameItem villageNameItem in MarketTransferPanel.villageHistory)
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
				villageNameItem2.villageName = GameEngine.Instance.World.getVillageName(villageID);
				MarketTransferPanel.villageHistory.Add(villageNameItem2);
				this.updateVillageHistory();
			}
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00198CE8 File Offset: 0x00196EE8
		public void dirtyStockExchangeInfo(int selectedStockExchange)
		{
			if (this.stockExchanges[selectedStockExchange] != null)
			{
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = (StockExchangePanel.StockExchangeInfo)this.stockExchanges[selectedStockExchange];
				stockExchangeInfo.lastTime = DateTime.MinValue;
			}
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00198D20 File Offset: 0x00196F20
		public void getStockExchangeDataCallback(GetStockExchangeData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				StockExchangePanel.StockExchangeInfo stockExchangeInfo = new StockExchangePanel.StockExchangeInfo();
				stockExchangeInfo.villageID = returnData.villageID;
				stockExchangeInfo.lastTime = DateTime.Now;
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
				this.lastVillageData = stockExchangeInfo;
				this.stockExchanges[returnData.villageID] = stockExchangeInfo;
				this.updateValues();
			}
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00019BA1 File Offset: 0x00017DA1
		public void stockExchangeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(3);
		}

		// Token: 0x0400298F RID: 10639
		private DockableControl dockableControl;

		// Token: 0x04002990 RID: 10640
		private IContainer components;

		// Token: 0x04002991 RID: 10641
		public static MarketTransferPanel instance = null;

		// Token: 0x04002992 RID: 10642
		private static List<WorldMap.VillageNameItem> villageHistory = new List<WorldMap.VillageNameItem>();

		// Token: 0x04002993 RID: 10643
		private static List<WorldMap.VillageNameItem> villageFavourites = new List<WorldMap.VillageNameItem>();

		// Token: 0x04002994 RID: 10644
		public static MarketTransferPanel.VillageHistoryComparer villageHistoryComparer = new MarketTransferPanel.VillageHistoryComparer();

		// Token: 0x04002995 RID: 10645
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002996 RID: 10646
		private CustomSelfDrawPanel.CSDImage tradeWithImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002997 RID: 10647
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002998 RID: 10648
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002999 RID: 10649
		private CustomSelfDrawPanel.CSDButton newTradingButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400299A RID: 10650
		private CustomSelfDrawPanel.CSDExtendingPanel leftWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400299B RID: 10651
		private CustomSelfDrawPanel.CSDExtendingPanel midWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400299C RID: 10652
		private CustomSelfDrawPanel.CSDExtendingPanel infoWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400299D RID: 10653
		private CustomSelfDrawPanel.CSDLabel sendHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400299E RID: 10654
		private CustomSelfDrawPanel.CSDImage sendHeadingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400299F RID: 10655
		private CustomSelfDrawPanel.CSDExtendingPanel sendWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040029A0 RID: 10656
		private CustomSelfDrawPanel.CSDExtendingPanel sendSubWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040029A1 RID: 10657
		private CustomSelfDrawPanel.CSDLabel sendNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029A2 RID: 10658
		private CustomSelfDrawPanel.CSDLabel sendMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029A3 RID: 10659
		private CustomSelfDrawPanel.CSDLabel sendMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029A4 RID: 10660
		private CustomSelfDrawPanel.CSDButton sendButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029A5 RID: 10661
		private CustomSelfDrawPanel.CSDTrackBar sendTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040029A6 RID: 10662
		private CustomSelfDrawPanel.CSDLabel sendNumberPackets = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029A7 RID: 10663
		private CustomSelfDrawPanel.CSDButton sendEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029A8 RID: 10664
		private CustomSelfDrawPanel.CSDLabel localHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029A9 RID: 10665
		private CustomSelfDrawPanel.CSDLabel storedHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029AA RID: 10666
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040029AB RID: 10667
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea2 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040029AC RID: 10668
		private CustomSelfDrawPanel.CSDHorzExtendingPanel exchangeNameBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040029AD RID: 10669
		private CustomSelfDrawPanel.CSDLabel exchangeNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029AE RID: 10670
		private CustomSelfDrawPanel.CSDButton exchangeArrowButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029AF RID: 10671
		private CustomSelfDrawPanel.CSDExtendingPanel deliveryTimeArea = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040029B0 RID: 10672
		private CustomSelfDrawPanel.CSDLabel deliveryTimeAreaLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029B1 RID: 10673
		private CustomSelfDrawPanel.CSDButton tabButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029B2 RID: 10674
		private CustomSelfDrawPanel.CSDButton tabButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029B3 RID: 10675
		private CustomSelfDrawPanel.CSDButton tabButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029B4 RID: 10676
		private CustomSelfDrawPanel.CSDButton tabButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029B5 RID: 10677
		private CustomSelfDrawPanel.CSDImage highlightLine1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029B6 RID: 10678
		private CustomSelfDrawPanel.CSDImage highlightLine2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029B7 RID: 10679
		private CustomSelfDrawPanel.CSDImage highlightLine3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029B8 RID: 10680
		private CustomSelfDrawPanel.CSDImage highlightLine4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029B9 RID: 10681
		private CustomSelfDrawPanel.CSDImage highlightLine5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029BA RID: 10682
		private CustomSelfDrawPanel.CSDImage highlightLine6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029BB RID: 10683
		private CustomSelfDrawPanel.CSDImage highlightLine7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029BC RID: 10684
		private CustomSelfDrawPanel.CSDImage highlightLine8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029BD RID: 10685
		private CustomSelfDrawPanel.CSDButton selectRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029BE RID: 10686
		private CustomSelfDrawPanel.CSDButton selectRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029BF RID: 10687
		private CustomSelfDrawPanel.CSDButton selectRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C0 RID: 10688
		private CustomSelfDrawPanel.CSDButton selectRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C1 RID: 10689
		private CustomSelfDrawPanel.CSDButton selectRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C2 RID: 10690
		private CustomSelfDrawPanel.CSDButton selectRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C3 RID: 10691
		private CustomSelfDrawPanel.CSDButton selectRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C4 RID: 10692
		private CustomSelfDrawPanel.CSDButton selectRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029C5 RID: 10693
		private CustomSelfDrawPanel.CSDLabel localLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029C6 RID: 10694
		private CustomSelfDrawPanel.CSDLabel localLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029C7 RID: 10695
		private CustomSelfDrawPanel.CSDLabel localLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029C8 RID: 10696
		private CustomSelfDrawPanel.CSDLabel localLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029C9 RID: 10697
		private CustomSelfDrawPanel.CSDLabel localLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CA RID: 10698
		private CustomSelfDrawPanel.CSDLabel localLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CB RID: 10699
		private CustomSelfDrawPanel.CSDLabel localLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CC RID: 10700
		private CustomSelfDrawPanel.CSDLabel localLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CD RID: 10701
		private CustomSelfDrawPanel.CSDLabel storedLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CE RID: 10702
		private CustomSelfDrawPanel.CSDLabel storedLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029CF RID: 10703
		private CustomSelfDrawPanel.CSDLabel storedLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D0 RID: 10704
		private CustomSelfDrawPanel.CSDLabel storedLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D1 RID: 10705
		private CustomSelfDrawPanel.CSDLabel storedLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D2 RID: 10706
		private CustomSelfDrawPanel.CSDLabel storedLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D3 RID: 10707
		private CustomSelfDrawPanel.CSDLabel storedLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D4 RID: 10708
		private CustomSelfDrawPanel.CSDLabel storedLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D5 RID: 10709
		private CustomSelfDrawPanel.CSDLabel traderCapacityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D6 RID: 10710
		private CustomSelfDrawPanel.CSDLabel traderCapacityValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D7 RID: 10711
		private CustomSelfDrawPanel.CSDLabel tradersAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D8 RID: 10712
		private CustomSelfDrawPanel.CSDLabel tradersAvailableValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029D9 RID: 10713
		private CustomSelfDrawPanel.CSDImage traderIconImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029DA RID: 10714
		private CustomSelfDrawPanel.CSDImage villageSelectPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040029DB RID: 10715
		private CustomSelfDrawPanel.CSDButton villageSelectPanelTab1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029DC RID: 10716
		private CustomSelfDrawPanel.CSDButton villageSelectPanelTab2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029DD RID: 10717
		private CustomSelfDrawPanel.CSDLabel villageSelectPanelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040029DE RID: 10718
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029DF RID: 10719
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E0 RID: 10720
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E1 RID: 10721
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E2 RID: 10722
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E3 RID: 10723
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E4 RID: 10724
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E5 RID: 10725
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E6 RID: 10726
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E7 RID: 10727
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E8 RID: 10728
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029E9 RID: 10729
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029EA RID: 10730
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029EB RID: 10731
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029EC RID: 10732
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029ED RID: 10733
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029EE RID: 10734
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029EF RID: 10735
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F0 RID: 10736
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F1 RID: 10737
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F2 RID: 10738
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F3 RID: 10739
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F4 RID: 10740
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F5 RID: 10741
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F6 RID: 10742
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F7 RID: 10743
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F8 RID: 10744
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029F9 RID: 10745
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FA RID: 10746
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FB RID: 10747
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FC RID: 10748
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FD RID: 10749
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FE RID: 10750
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040029FF RID: 10751
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17Delete = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A00 RID: 10752
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A01 RID: 10753
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A02 RID: 10754
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A03 RID: 10755
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A04 RID: 10756
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A05 RID: 10757
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A06 RID: 10758
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A07 RID: 10759
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A08 RID: 10760
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A09 RID: 10761
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0A RID: 10762
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0B RID: 10763
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0C RID: 10764
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0D RID: 10765
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0E RID: 10766
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A0F RID: 10767
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A10 RID: 10768
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17Favourite = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A11 RID: 10769
		private CustomSelfDrawPanel.CSDButton villageOwnPageUp = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A12 RID: 10770
		private CustomSelfDrawPanel.CSDButton villageOwnPageDown = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A13 RID: 10771
		private CustomSelfDrawPanel.CSDButton worldMapButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002A14 RID: 10772
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04002A15 RID: 10773
		private CustomSelfDrawPanel.CSDImage seaConditionsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002A16 RID: 10774
		private int lastSeaConditions = -1;

		// Token: 0x04002A17 RID: 10775
		private int selectedTargetVillage = -1;

		// Token: 0x04002A18 RID: 10776
		private int lastTab = -1;

		// Token: 0x04002A19 RID: 10777
		private int currentResource = -1;

		// Token: 0x04002A1A RID: 10778
		private int currentResourcePacketSize = 1;

		// Token: 0x04002A1B RID: 10779
		private int BACKUP_resource = -1;

		// Token: 0x04002A1C RID: 10780
		private int BACKUP_sendLevel;

		// Token: 0x04002A1D RID: 10781
		private int villageTabMode;

		// Token: 0x04002A1E RID: 10782
		private int villageTabOwnPage;

		// Token: 0x04002A1F RID: 10783
		private int numTraders;

		// Token: 0x04002A20 RID: 10784
		private int numFreeTraders;

		// Token: 0x04002A21 RID: 10785
		private DateTime lastTradeTime = DateTime.MinValue;

		// Token: 0x04002A22 RID: 10786
		public SparseArray stockExchanges = new SparseArray();

		// Token: 0x04002A23 RID: 10787
		private StockExchangePanel.StockExchangeInfo lastVillageData;

		// Token: 0x0200023C RID: 572
		public class VillageHistoryComparer : IComparer<WorldMap.VillageNameItem>
		{
			// Token: 0x06001978 RID: 6520 RVA: 0x00019BD4 File Offset: 0x00017DD4
			public int Compare(WorldMap.VillageNameItem x, WorldMap.VillageNameItem y)
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
					return x.villageName.CompareTo(y.villageName);
				}
			}
		}
	}
}
