using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020000F8 RID: 248
	public class CapitalDonateResourcesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000790 RID: 1936 RVA: 0x0000C48D File Offset: 0x0000A68D
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0000C49D File Offset: 0x0000A69D
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0000C4AD File Offset: 0x0000A6AD
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0000C4BF File Offset: 0x0000A6BF
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0000C4CC File Offset: 0x0000A6CC
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0000C4ED File Offset: 0x0000A6ED
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0000C4FA File Offset: 0x0000A6FA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000A0E00 File Offset: 0x0009F000
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalDonateResourcesPanel22";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x000A0E6C File Offset: 0x0009F06C
		public CapitalDonateResourcesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void init()
		{
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000A1324 File Offset: 0x0009F524
		public void init(int villageID, VillageMapBuilding selectedBuilding)
		{
			this.m_capitalVillageID = villageID;
			this.m_building = selectedBuilding;
			CapitalDonateResourcesPanel2.instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("DonateScreen_Donate_to", "Donate to Capital Building"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "CapitalDonateResourcesPanel2_close");
			this.closeButton.CustomTooltipID = 801;
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 42, new Point(898, 10));
			this.illustration.Image = GFXLibrary.donate_illustration;
			this.illustration.Position = new Point(622, 41);
			this.mainBackgroundArea.addControl(this.illustration);
			this.midWindow.Size = new Size(228, 409);
			this.midWindow.Position = new Point(366, 144);
			this.mainBackgroundArea.addControl(this.midWindow);
			this.midWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.leftWindow.Size = new Size(335, 409);
			this.leftWindow.Position = new Point(36, 144);
			this.mainBackgroundArea.addControl(this.leftWindow);
			this.leftWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.topWindow.Size = new Size(557, 124);
			this.topWindow.Position = new Point(36, 14);
			this.topWindow.CustomTooltipID = 1900;
			this.mainBackgroundArea.addControl(this.topWindow);
			this.topWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
			this.buildingImage.Image = GFXLibrary.townbuilding_archeryrange_normal;
			this.buildingImage.Position = new Point(0, 0);
			this.topWindow.addControl(this.buildingImage);
			int num = 11;
			this.buildingTypeName.Text = "";
			this.buildingTypeName.Color = Color.FromArgb(196, 161, 85);
			this.buildingTypeName.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.buildingTypeName.Position = new Point(96, num);
			this.buildingTypeName.Size = new Size(240, 30);
			this.buildingTypeName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.buildingTypeName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.buildingTypeName);
			this.currentLevelName.Text = SK.Text("DonateScreen_Current_Level", "Current Level") + " : ";
			this.currentLevelName.Color = Color.FromArgb(196, 161, 85);
			this.currentLevelName.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.currentLevelName.Position = new Point(336, num);
			this.currentLevelName.Size = new Size(240, 30);
			this.currentLevelName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.currentLevelName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.currentLevelName);
			this.lblCurrentEffectLevelLabel.Text = SK.Text("DonateScreen_Current_Level_Effect", "Current Level Effect") + " : ";
			this.lblCurrentEffectLevelLabel.Color = Color.FromArgb(196, 161, 85);
			this.lblCurrentEffectLevelLabel.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.lblCurrentEffectLevelLabel.Position = new Point(96, num + 25);
			this.lblCurrentEffectLevelLabel.Size = new Size(160, 50);
			this.lblCurrentEffectLevelLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.lblCurrentEffectLevelLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.lblCurrentEffectLevelLabel);
			this.lblCurrentLevelEffect.Text = "";
			this.lblCurrentLevelEffect.Color = Color.FromArgb(196, 161, 85);
			this.lblCurrentLevelEffect.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.lblCurrentLevelEffect.Position = new Point(261, num + 25);
			this.lblCurrentLevelEffect.Size = new Size(280, 50);
			this.lblCurrentLevelEffect.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.lblCurrentLevelEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.lblCurrentLevelEffect);
			this.lblNextLevelEffectLabel.Text = SK.Text("DonateScreen_Next_Level_Effect", "Next Level Effect") + " : ";
			this.lblNextLevelEffectLabel.Color = Color.FromArgb(196, 161, 85);
			this.lblNextLevelEffectLabel.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.lblNextLevelEffectLabel.Position = new Point(96, num + 61);
			this.lblNextLevelEffectLabel.Size = new Size(160, 50);
			this.lblNextLevelEffectLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.lblNextLevelEffectLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.lblNextLevelEffectLabel);
			this.lblNextLevelEffect.Text = "";
			this.lblNextLevelEffect.Color = Color.FromArgb(196, 161, 85);
			this.lblNextLevelEffect.DropShadowColor = Color.FromArgb(64, 64, 64);
			this.lblNextLevelEffect.Position = new Point(261, num + 61);
			this.lblNextLevelEffect.Size = new Size(280, 50);
			this.lblNextLevelEffect.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			this.lblNextLevelEffect.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.topWindow.addControl(this.lblNextLevelEffect);
			this.lightArea1.Size = new Size(97, 329);
			this.lightArea1.Position = new Point(216, 62);
			this.leftWindow.addControl(this.lightArea1);
			this.lightArea1.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.localHeadingLabel.Text = SK.Text("TRADE_Local", "Local");
			this.localHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.localHeadingLabel.Position = new Point(0, -35);
			this.localHeadingLabel.Size = new Size(97, 30);
			this.localHeadingLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.localHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea1.addControl(this.localHeadingLabel);
			this.lightArea2.Size = new Size(186, 329);
			this.lightArea2.Position = new Point(21, 62);
			this.midWindow.addControl(this.lightArea2);
			this.lightArea2.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
			this.storedHeadingLabel.Text = SK.Text("DonateScreen_For_Level", "For Level") + " : 6";
			this.storedHeadingLabel.Color = Color.FromArgb(196, 161, 85);
			this.storedHeadingLabel.Position = new Point(0, -65);
			this.storedHeadingLabel.Size = new Size(186, 30);
			this.storedHeadingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.storedHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_CENTER;
			this.lightArea2.addControl(this.storedHeadingLabel);
			this.exchangeNameBar.Size = new Size(205, 31);
			this.exchangeNameBar.Position = new Point(11, 9);
			this.exchangeNameBar.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick), "CapitalDonateResourcesPanel2_select");
			this.leftWindow.addControl(this.exchangeNameBar);
			this.exchangeNameBar.Create(GFXLibrary.int_lineitem_inset_left, GFXLibrary.int_lineitem_inset_middle, GFXLibrary.int_lineitem_inset_right);
			this.exchangeNameLabel.Text = SK.Text("TRADE_Select_Village", "Select Village");
			this.exchangeNameLabel.Color = Color.FromArgb(196, 161, 85);
			this.exchangeNameLabel.Position = new Point(17, 7);
			this.exchangeNameLabel.Size = new Size(this.exchangeNameBar.Size.Width - 17 - 20, this.exchangeNameBar.Size.Height - 13);
			this.exchangeNameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.exchangeNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.exchangeNameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick), "CapitalDonateResourcesPanel2_select");
			this.exchangeNameBar.addControl(this.exchangeNameLabel);
			this.exchangeArrowButton.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.exchangeArrowButton.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.exchangeArrowButton.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.exchangeArrowButton.Position = new Point(181, 7);
			this.exchangeArrowButton.MoveOnClick = false;
			this.exchangeArrowButton.Data = 0;
			this.exchangeArrowButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.exchangeArrowClick), "CapitalDonateResourcesPanel2_select");
			this.exchangeNameBar.addControl(this.exchangeArrowButton);
			this.sendWindow.Size = new Size(336, 145);
			this.sendWindow.Position = new Point(622, 372);
			this.sendWindow.Visible = false;
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
			this.sendNumberPackets.Text = SK.Text("DonateScreen_Packets", "Packets") + " : 0";
			this.sendNumberPackets.Color = Color.FromArgb(196, 161, 85);
			this.sendNumberPackets.Position = new Point(-17, 12);
			this.sendNumberPackets.Size = new Size(150, 30);
			this.sendNumberPackets.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sendNumberPackets.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.BOTTOM_RIGHT;
			this.sendSubWindow.addControl(this.sendNumberPackets);
			this.sendButton.Position = new Point(177, 94);
			this.sendButton.Size = new Size(153, 38);
			this.sendButton.Text.Text = SK.Text("MarketTradeScreen_Send", "Send");
			this.sendButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.sendButton.TextYOffset = -1;
			this.sendButton.Text.Color = global::ARGBColors.Black;
			this.sendButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendClick), "CapitalDonateResourcesPanel2_send");
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
			this.sendEditButton.ImageNorm = GFXLibrary.faction_pen;
			this.sendEditButton.ImageOver = GFXLibrary.faction_pen;
			this.sendEditButton.ImageClick = GFXLibrary.faction_pen;
			this.sendEditButton.MoveOnClick = true;
			this.sendEditButton.OverBrighten = true;
			this.sendEditButton.Position = new Point(7, 5);
			this.sendEditButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.editSendValue), "CapitalDonateResourcesPanel2_editValue");
			this.sendSubWindow.addControl(this.sendEditButton);
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
			this.highlightLine1.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine1.Position = new Point(153, 71);
			this.highlightLine1.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine1);
			this.highlightLine2.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine2.Position = new Point(153, 111);
			this.highlightLine2.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine2);
			this.highlightLine3.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine3.Position = new Point(153, 151);
			this.highlightLine3.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine3);
			this.highlightLine4.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine4.Position = new Point(153, 191);
			this.highlightLine4.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine4);
			this.highlightLine5.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine5.Position = new Point(153, 231);
			this.highlightLine5.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine5);
			this.highlightLine6.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine6.Position = new Point(153, 271);
			this.highlightLine6.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine6);
			this.highlightLine7.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine7.Position = new Point(153, 311);
			this.highlightLine7.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine7);
			this.highlightLine8.Image = GFXLibrary.int_white_highlight_bar;
			this.highlightLine8.Position = new Point(153, 351);
			this.highlightLine8.Size = new Size(400, 31);
			this.leftWindow.addControl(this.highlightLine8);
			this.selectRow1.Position = new Point(-134, -3);
			this.selectRow1.Size = new Size(191, 38);
			this.selectRow1.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow1.Text.Position = new Point(71, 0);
			this.selectRow1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow1.TextYOffset = -1;
			this.selectRow1.Text.Color = global::ARGBColors.Black;
			this.selectRow1.ImageIconPosition = new Point(26, -3);
			this.selectRow1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine1.addControl(this.selectRow1);
			this.selectRow1.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow1.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow2.Position = new Point(-134, -3);
			this.selectRow2.Size = new Size(191, 38);
			this.selectRow2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow2.Text.Position = new Point(71, 0);
			this.selectRow2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow2.TextYOffset = -1;
			this.selectRow2.Text.Color = global::ARGBColors.Black;
			this.selectRow2.ImageIconPosition = new Point(26, -3);
			this.selectRow2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine2.addControl(this.selectRow2);
			this.selectRow2.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow2.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow3.Position = new Point(-134, -3);
			this.selectRow3.Size = new Size(191, 38);
			this.selectRow3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow3.Text.Position = new Point(71, 0);
			this.selectRow3.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow3.TextYOffset = -1;
			this.selectRow3.Text.Color = global::ARGBColors.Black;
			this.selectRow3.ImageIconPosition = new Point(26, -3);
			this.selectRow3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine3.addControl(this.selectRow3);
			this.selectRow3.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow3.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow4.Position = new Point(-134, -3);
			this.selectRow4.Size = new Size(191, 38);
			this.selectRow4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow4.Text.Position = new Point(71, 0);
			this.selectRow4.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow4.TextYOffset = -1;
			this.selectRow4.Text.Color = global::ARGBColors.Black;
			this.selectRow4.ImageIconPosition = new Point(26, -3);
			this.selectRow4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine4.addControl(this.selectRow4);
			this.selectRow4.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow4.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow5.Position = new Point(-134, -3);
			this.selectRow5.Size = new Size(191, 38);
			this.selectRow5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow5.Text.Position = new Point(71, 0);
			this.selectRow5.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow5.TextYOffset = -1;
			this.selectRow5.Text.Color = global::ARGBColors.Black;
			this.selectRow5.ImageIconPosition = new Point(26, -3);
			this.selectRow5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine5.addControl(this.selectRow5);
			this.selectRow5.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow5.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow6.Position = new Point(-134, -3);
			this.selectRow6.Size = new Size(191, 38);
			this.selectRow6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow6.Text.Position = new Point(71, 0);
			this.selectRow6.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow6.TextYOffset = -1;
			this.selectRow6.Text.Color = global::ARGBColors.Black;
			this.selectRow6.ImageIconPosition = new Point(26, -3);
			this.selectRow6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine6.addControl(this.selectRow6);
			this.selectRow6.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow6.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow7.Position = new Point(-134, -3);
			this.selectRow7.Size = new Size(191, 38);
			this.selectRow7.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow7.Text.Position = new Point(71, 0);
			this.selectRow7.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow7.TextYOffset = -1;
			this.selectRow7.Text.Color = global::ARGBColors.Black;
			this.selectRow7.ImageIconPosition = new Point(26, -3);
			this.selectRow7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rowClicked));
			this.highlightLine7.addControl(this.selectRow7);
			this.selectRow7.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.selectRow7.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			this.selectRow8.Position = new Point(-134, -3);
			this.selectRow8.Size = new Size(191, 38);
			this.selectRow8.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.selectRow8.Text.Position = new Point(71, 0);
			this.selectRow8.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.selectRow8.TextYOffset = -1;
			this.selectRow8.Text.Color = global::ARGBColors.Black;
			this.selectRow8.ImageIconPosition = new Point(26, -3);
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
			this.storedLabel1.Text = "/";
			this.storedLabel1.Color = global::ARGBColors.Black;
			this.storedLabel1.Position = new Point(101, 1);
			this.storedLabel1.Size = new Size(186, 31);
			this.storedLabel1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine1.addControl(this.storedLabel1);
			this.storedLabel2.Text = "/";
			this.storedLabel2.Color = global::ARGBColors.Black;
			this.storedLabel2.Position = new Point(101, 1);
			this.storedLabel2.Size = new Size(186, 31);
			this.storedLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine2.addControl(this.storedLabel2);
			this.storedLabel3.Text = "/";
			this.storedLabel3.Color = global::ARGBColors.Black;
			this.storedLabel3.Position = new Point(101, 1);
			this.storedLabel3.Size = new Size(186, 31);
			this.storedLabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine3.addControl(this.storedLabel3);
			this.storedLabel4.Text = "/";
			this.storedLabel4.Color = global::ARGBColors.Black;
			this.storedLabel4.Position = new Point(101, 1);
			this.storedLabel4.Size = new Size(186, 31);
			this.storedLabel4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine4.addControl(this.storedLabel4);
			this.storedLabel5.Text = "/";
			this.storedLabel5.Color = global::ARGBColors.Black;
			this.storedLabel5.Position = new Point(101, 1);
			this.storedLabel5.Size = new Size(186, 31);
			this.storedLabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine5.addControl(this.storedLabel5);
			this.storedLabel6.Text = "/";
			this.storedLabel6.Color = global::ARGBColors.Black;
			this.storedLabel6.Position = new Point(101, 1);
			this.storedLabel6.Size = new Size(186, 31);
			this.storedLabel6.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine6.addControl(this.storedLabel6);
			this.storedLabel7.Text = "?";
			this.storedLabel7.Color = global::ARGBColors.Black;
			this.storedLabel7.Position = new Point(101, 1);
			this.storedLabel7.Size = new Size(186, 31);
			this.storedLabel7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine7.addControl(this.storedLabel7);
			this.storedLabel8.Text = "/";
			this.storedLabel8.Color = global::ARGBColors.Black;
			this.storedLabel8.Position = new Point(101, 1);
			this.storedLabel8.Size = new Size(186, 31);
			this.storedLabel8.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.storedLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.highlightLine8.addControl(this.storedLabel8);
			this.priceLabel1.Text = "0";
			this.priceLabel1.Color = global::ARGBColors.Black;
			this.priceLabel1.Position = new Point(288, 1);
			this.priceLabel1.Size = new Size(97, 31);
			this.priceLabel1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine1.addControl(this.priceLabel1);
			this.priceLabel2.Text = "0";
			this.priceLabel2.Color = global::ARGBColors.Black;
			this.priceLabel2.Position = new Point(288, 1);
			this.priceLabel2.Size = new Size(97, 31);
			this.priceLabel2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine2.addControl(this.priceLabel2);
			this.priceLabel3.Text = "0";
			this.priceLabel3.Color = global::ARGBColors.Black;
			this.priceLabel3.Position = new Point(288, 1);
			this.priceLabel3.Size = new Size(97, 31);
			this.priceLabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine3.addControl(this.priceLabel3);
			this.priceLabel4.Text = "0";
			this.priceLabel4.Color = global::ARGBColors.Black;
			this.priceLabel4.Position = new Point(288, 1);
			this.priceLabel4.Size = new Size(97, 31);
			this.priceLabel4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine4.addControl(this.priceLabel4);
			this.priceLabel5.Text = "0";
			this.priceLabel5.Color = global::ARGBColors.Black;
			this.priceLabel5.Position = new Point(288, 1);
			this.priceLabel5.Size = new Size(97, 31);
			this.priceLabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine5.addControl(this.priceLabel5);
			this.priceLabel6.Text = "0";
			this.priceLabel6.Color = global::ARGBColors.Black;
			this.priceLabel6.Position = new Point(288, 1);
			this.priceLabel6.Size = new Size(97, 31);
			this.priceLabel6.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine6.addControl(this.priceLabel6);
			this.priceLabel7.Text = "0";
			this.priceLabel7.Color = global::ARGBColors.Black;
			this.priceLabel7.Position = new Point(288, 1);
			this.priceLabel7.Size = new Size(97, 31);
			this.priceLabel7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine7.addControl(this.priceLabel7);
			this.priceLabel8.Text = "0";
			this.priceLabel8.Color = global::ARGBColors.Black;
			this.priceLabel8.Position = new Point(288, 1);
			this.priceLabel8.Size = new Size(97, 31);
			this.priceLabel8.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.priceLabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.highlightLine8.addControl(this.priceLabel8);
			this.villageSelectPanel.Image = GFXLibrary.int_villagelist_panel;
			this.villageSelectPanel.Size = new Size(this.villageSelectPanel.Image.Width, 337);
			this.villageSelectPanel.Position = new Point(53, 180);
			this.villageSelectPanel.Visible = false;
			this.mainBackgroundArea.addControl(this.villageSelectPanel);
			this.villageSelectPanelTab1.ImageNorm = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.ImageOver = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.ImageClick = GFXLibrary.tab_villagename_forward;
			this.villageSelectPanelTab1.Size = new Size(138, 20);
			this.villageSelectPanelTab1.Position = new Point(0, 3);
			this.villageSelectPanelTab1.Text.Text = SK.Text("GENERIC_Villages", "Villages");
			this.villageSelectPanelTab1.TextYOffset = -1;
			this.villageSelectPanelTab1.Data = 0;
			this.villageSelectPanelTab1.MoveOnClick = false;
			this.villageSelectPanelTab1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageSelectPanelTab1.Text.Color = global::ARGBColors.Black;
			this.villageSelectPanel.addControl(this.villageSelectPanelTab1);
			this.villageSelectVillage1.ImageNorm = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageOver = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageClick = GFXLibrary.int_villagelist_panel_highlight;
			this.villageSelectVillage1.ImageNorm = null;
			this.villageSelectVillage1.Size = new Size(232, 16);
			this.villageSelectVillage1.Position = new Point(3, 21);
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
			this.villageSelectVillage2.Position = new Point(3, 39);
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
			this.villageSelectVillage3.Position = new Point(3, 57);
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
			this.villageSelectVillage4.Position = new Point(3, 75);
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
			this.villageSelectVillage5.Position = new Point(3, 93);
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
			this.villageSelectVillage6.Position = new Point(3, 111);
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
			this.villageSelectVillage7.Position = new Point(3, 129);
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
			this.villageSelectVillage8.Position = new Point(3, 147);
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
			this.villageSelectVillage9.Size = new Size(232, 16);
			this.villageSelectVillage9.ImageNorm = null;
			this.villageSelectVillage9.Position = new Point(3, 165);
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
			this.villageSelectVillage10.Position = new Point(3, 183);
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
			this.villageSelectVillage11.Position = new Point(3, 201);
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
			this.villageSelectVillage12.Position = new Point(3, 219);
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
			this.villageSelectVillage13.Position = new Point(3, 237);
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
			this.villageSelectVillage14.Position = new Point(3, 255);
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
			this.villageSelectVillage15.Position = new Point(3, 273);
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
			this.villageSelectVillage16.Position = new Point(3, 291);
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
			this.villageSelectVillage17.Position = new Point(3, 309);
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
			this.villageOwnPageUp.ImageNorm = GFXLibrary.int_button_droparrow_up_normal;
			this.villageOwnPageUp.ImageOver = GFXLibrary.int_button_droparrow_up_over;
			this.villageOwnPageUp.ImageClick = GFXLibrary.int_button_droparrow_up_down;
			this.villageOwnPageUp.Position = new Point(135, 314);
			this.villageOwnPageUp.MoveOnClick = false;
			this.villageOwnPageUp.Data = 0;
			this.villageOwnPageUp.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnPageClicked), "CapitalDonateResourcesPanel2_page_up");
			this.villageSelectPanel.addControl(this.villageOwnPageUp);
			this.villageOwnPageDown.ImageNorm = GFXLibrary.int_button_droparrow_normal;
			this.villageOwnPageDown.ImageOver = GFXLibrary.int_button_droparrow_over;
			this.villageOwnPageDown.ImageClick = GFXLibrary.int_button_droparrow_down;
			this.villageOwnPageDown.Position = new Point(165, 314);
			this.villageOwnPageDown.MoveOnClick = false;
			this.villageOwnPageDown.Data = 1;
			this.villageOwnPageDown.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnPageClicked), "CapitalDonateResourcesPanel2_page_down");
			this.villageSelectPanel.addControl(this.villageOwnPageDown);
			this.villageTabOwnPage = 0;
			this.updateVillageHistory();
			this.sendAllowed = true;
			this.currentSelectedVillageID = -1;
			this.currentSelectedRow = -1;
			this.currentResource = -1;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null && village.m_parishCapitalResearchData != null)
			{
				if (village.VillageID != villageID)
				{
					return;
				}
				this.updateScreenInfo(selectedBuilding, village, true);
				RemoteServices.Instance.set_GetVillageInfoForDonateCapitalGoods_UserCallBack(new RemoteServices.GetVillageInfoForDonateCapitalGoods_UserCallBack(this.GetVillageInfoForDonateCapitalGoods_callback));
				RemoteServices.Instance.GetVillageInfoForDonateCapitalGoods(villageID, selectedBuilding.buildingType);
			}
			this.validateSendButtons();
			this.update();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000A58F0 File Offset: 0x000A3AF0
		public void updateScreenInfo(VillageMapBuilding selectedBuilding, VillageMap vm, bool resetRadios)
		{
			if (vm == null || selectedBuilding == null)
			{
				return;
			}
			this.lblNextLevelEffect.Text = "";
			this.lblCurrentLevelEffect.Text = "";
			NumberFormatInfo nfi = GameEngine.NFI;
			int num = vm.m_parishCapitalResearchData.getCapitalResourceFromBuildingType(selectedBuilding.buildingType);
			CapitalDonateResourcesPanel2.capitalTooltipText = VillageBuildingsData.getCapitalBuildingHelpText(selectedBuilding.buildingType);
			int capitalResearchFromBuildingType = ResearchData.getCapitalResearchFromBuildingType(selectedBuilding.buildingType);
			int num2 = ResearchData.getNumLevels(capitalResearchFromBuildingType);
			if (capitalResearchFromBuildingType != 49 && capitalResearchFromBuildingType != 60)
			{
				if (capitalResearchFromBuildingType == 74)
				{
					if (GameEngine.Instance.World.FifthAgeWorld)
					{
						num2 = 5;
					}
					else if (GameEngine.Instance.World.FourthAgeWorld)
					{
						num2 = 3;
					}
				}
			}
			else
			{
				num2 = 10;
			}
			if (GameEngine.Instance.World.SeventhAgeWorld)
			{
				num2 = ResearchData.seventhAgeCapitalResearchLevels(num2, capitalResearchFromBuildingType);
			}
			else if (GameEngine.Instance.World.FourthAgeWorld)
			{
				num2 = ResearchData.fourthAgeCapitalResearchLevels(num2, capitalResearchFromBuildingType);
			}
			else if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num2 = ResearchData.thirdAgeCapitalResearchLevels(num2, capitalResearchFromBuildingType);
			}
			if (num >= num2)
			{
				this.sendAllowed = false;
				this.storedHeadingLabel.Visible = false;
			}
			else
			{
				this.storedHeadingLabel.Visible = true;
			}
			this.storedHeadingLabel.Text = SK.Text("DonateScreen_For_Level", "For Level") + " : " + (num + 1).ToString();
			this.sendAllowed = true;
			BaseImage b = GFXLibrary.townbuilding_archeryrange_normal;
			switch (selectedBuilding.buildingType)
			{
			case 79:
				b = GFXLibrary.townbuilding_Woodcutter_normal;
				break;
			case 80:
				b = GFXLibrary.townbuilding_stonequarry_normal;
				break;
			case 81:
				b = GFXLibrary.townbuilding_iron_normal;
				break;
			case 82:
				b = GFXLibrary.townbuilding_pitch_normal;
				break;
			case 83:
				b = GFXLibrary.townbuilding_ale_normal;
				break;
			case 84:
				b = GFXLibrary.townbuilding_apples_normal;
				break;
			case 85:
				b = GFXLibrary.townbuilding_cheese_normal;
				break;
			case 86:
				b = GFXLibrary.townbuilding_meat_normal;
				break;
			case 87:
				b = GFXLibrary.townbuilding_bread_normal;
				break;
			case 88:
				b = GFXLibrary.townbuilding_veg_normal;
				break;
			case 89:
				b = GFXLibrary.townbuilding_fish_normal;
				break;
			case 90:
				b = GFXLibrary.townbuilding_bows_normal;
				break;
			case 91:
				b = GFXLibrary.townbuilding_pikes_normal;
				break;
			case 92:
				b = GFXLibrary.townbuilding_armour_normal;
				break;
			case 93:
				b = GFXLibrary.townbuilding_sword_normal;
				break;
			case 94:
				b = GFXLibrary.townbuilding_catapults_normal;
				break;
			case 95:
				b = GFXLibrary.townbuilding_venison_normal;
				break;
			case 96:
				b = GFXLibrary.townbuilding_wine_normal;
				break;
			case 97:
				b = GFXLibrary.townbuilding_salt_normal;
				break;
			case 98:
				b = GFXLibrary.townbuilding_carpenter_normal;
				break;
			case 99:
				b = GFXLibrary.townbuilding_tailor_normal;
				break;
			case 100:
				b = GFXLibrary.townbuilding_metalware_normal;
				break;
			case 101:
				b = GFXLibrary.townbuilding_spice_normal;
				break;
			case 102:
				b = GFXLibrary.townbuilding_silk_normal;
				break;
			case 103:
				b = GFXLibrary.townbuilding_architectsguild_normal;
				break;
			case 104:
				b = GFXLibrary.townbuilding_Labourersbillets_normal;
				break;
			case 105:
				b = GFXLibrary.townbuilding_castellanshouse_normal;
				break;
			case 106:
				b = GFXLibrary.townbuilding_sergeantsatarmsoffice_normal;
				break;
			case 107:
				b = GFXLibrary.townbuilding_stables_normal;
				break;
			case 108:
				b = GFXLibrary.townbuilding_barracks_normal;
				break;
			case 109:
				b = GFXLibrary.townbuilding_peasntshall_normal;
				break;
			case 110:
				b = GFXLibrary.townbuilding_archeryrange_normal;
				break;
			case 111:
				b = GFXLibrary.townbuilding_pikemandrillyard_normal;
				break;
			case 112:
				b = GFXLibrary.townbuilding_combatarena_normal;
				break;
			case 113:
				b = GFXLibrary.townbuilding_siegeengineersguild_normal;
				break;
			case 114:
				b = GFXLibrary.townbuilding_officersquarters_normal;
				break;
			case 115:
				b = GFXLibrary.townbuilding_militaryschool_normal;
				break;
			case 116:
				b = GFXLibrary.townbuilding_supplydepot_normal;
				break;
			case 117:
				b = GFXLibrary.townbuilding_townhall_normal;
				break;
			case 118:
				b = GFXLibrary.townbuilding_church_normal;
				break;
			case 119:
				b = GFXLibrary.townbuilding_towngarden_normal;
				break;
			case 120:
				b = GFXLibrary.townbuilding_statue_normal;
				break;
			case 121:
				b = GFXLibrary.townbuilding_turretmaker_normal;
				break;
			case 122:
				b = GFXLibrary.townbuilding_tunnellorsguild_normal;
				break;
			case 123:
				b = GFXLibrary.townbuilding_ballistamaker_normal;
				break;
			}
			this.buildingImage.Image = b;
			this.buildingTypeName.Text = VillageBuildingsData.getBuildingName(selectedBuilding.buildingType);
			this.currentLevelName.Text = SK.Text("DonateScreen_Current_Level", "Current Level") + " : " + num.ToString();
			switch (selectedBuilding.buildingType)
			{
			case 79:
			case 80:
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
			case 91:
			case 92:
			case 93:
			case 94:
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 100:
			case 101:
			case 102:
				if (num < ResearchData.ParishResearchIncreases_Guilds.Length && num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((ResearchData.ParishResearchIncreases_Guilds[num + 1] - 1.0 + 9.999999747378752E-06) * 100.0)).ToString() + "%";
				}
				if (num > 0)
				{
					if (num >= ResearchData.ParishResearchIncreases_Guilds.Length)
					{
						num = ResearchData.ParishResearchIncreases_Guilds.Length - 1;
					}
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((ResearchData.ParishResearchIncreases_Guilds[num] - 1.0 + 9.999999747378752E-06) * 100.0)).ToString() + "%";
				}
				break;
			case 103:
				if (num < 8)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					switch (num)
					{
					case 0:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Wood_Walls", "Allows access to Wooden Walls and Wooden Gate Houses");
						break;
					case 1:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Wooden_Platforms", "Allows access to Wooden Platforms");
						break;
					case 2:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Stone_Walls", "Allows access to Stone Walls");
						break;
					case 3:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Lookout_Tower", "Allows access to Lookout Tower");
						break;
					case 4:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Small_Tower", "Allows access to Small Tower");
						break;
					case 5:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Gate_House", "Allows access to Gate House");
						break;
					case 6:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Large_Tower", "Allows access to Large Tower");
						break;
					case 7:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Great_Tower", "Allows access to Great Tower");
						break;
					}
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					switch (num)
					{
					case 1:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Wood_Walls", "Allows access to Wooden Walls and Wooden Gate Houses");
						break;
					case 2:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Wooden_Platforms", "Allows access to Wooden Platforms");
						break;
					case 3:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Stone_Walls", "Allows access to Stone Walls");
						break;
					case 4:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Lookout_Tower", "Allows access to Lookout Tower");
						break;
					case 5:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Small_Tower", "Allows access to Small Tower");
						break;
					case 6:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Gate_House", "Allows access to Gate House");
						break;
					case 7:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Large_Tower", "Allows access to Large Tower");
						break;
					case 8:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Allows_Great_Tower", "Allows access to Great Tower");
						break;
					}
				}
				break;
			case 105:
				if (num < 10)
				{
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Keep_Level", "Keep Level") + " : " + (num + 1).ToString();
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
				}
				if (num > 0)
				{
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Keep_Level", "Keep Level") + " : " + num.ToString();
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
				}
				break;
			case 106:
				if (num < 10)
				{
					switch (num)
					{
					case 0:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Guard_Houses", "Access to Guard Houses.") + " ";
						break;
					case 2:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Killing_Pits", "Access to Killing Pits.") + " ";
						break;
					case 3:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Wood", "Upgrade Guard Houses to Wood.") + " ";
						break;
					case 4:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Smelters", "Access to Smelters and Oil Pots.") + " ";
						break;
					case 6:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Moats", "Access to Moats.") + " ";
						break;
					case 7:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Stone", "Upgrade Guard Houses to Stone.") + " ";
						break;
					case 9:
						this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Iron", "Upgrade Guard Houses with Iron Hoardings.") + " ";
						break;
					}
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblNextLevelEffect;
					csdlabel.Text = csdlabel.Text + SK.Text("CapitalDonateResourcesPanel_Boost_To_Armour", "Boost to armour") + " : ";
					double num3 = (double)ResearchData.defencesResearch[num + 1];
					num3 = (1.0 - num3) * 100.0;
					CustomSelfDrawPanel.CSDLabel csdlabel2 = this.lblNextLevelEffect;
					csdlabel2.Text = csdlabel2.Text + ((int)num3).ToString() + "%";
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
				}
				if (num > 0)
				{
					switch (num)
					{
					case 1:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Guard_Houses", "Access to Guard Houses.") + " ";
						break;
					case 3:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Killing_Pits", "Access to Killing Pits.") + " ";
						break;
					case 4:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Wood", "Upgrade Guard Houses to Wood.") + " ";
						break;
					case 5:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Smelters", "Access to Smelters and Oil Pots.") + " ";
						break;
					case 7:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Access_Moats", "Access to Moats.") + " ";
						break;
					case 8:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Stone", "Upgrade Guard Houses to Stone.") + " ";
						break;
					case 10:
						this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Upgrade_Guard_Houses_Iron", "Upgrade Guard Houses with Iron Hoardings.") + " ";
						break;
					}
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.lblCurrentLevelEffect;
					csdlabel3.Text = csdlabel3.Text + SK.Text("CapitalDonateResourcesPanel_Boost_To_Armour", "Boost to armour") + " : ";
					double num4 = (double)ResearchData.defencesResearch[num];
					num4 = (1.0 - num4) * 100.0;
					CustomSelfDrawPanel.CSDLabel csdlabel4 = this.lblCurrentLevelEffect;
					csdlabel4.Text = csdlabel4.Text + ((int)num4).ToString() + "%";
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
				}
				break;
			case 107:
				if (num < 10)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Knights", "Knights") + " : " + (num + 1).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Knights", "Knights") + " : " + num.ToString();
				}
				break;
			case 109:
				if (num < 10 && num > 1)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((ResearchData.conscriptionBonus[num + 1] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((ResearchData.conscriptionBonus[num] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				break;
			case 110:
				if (num < 10 && num > 1)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((ResearchData.longBowBonus[num + 1] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((ResearchData.longBowBonus[num] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				break;
			case 111:
				if (num < 10 && num > 1)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((ResearchData.pikeBonus[num + 1] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((ResearchData.pikeBonus[num] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				break;
			case 112:
				if (num < 10 && num > 1)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((ResearchData.swordBonus[num + 1] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((ResearchData.swordBonus[num] - 1f + 1E-05f) * 100f)).ToString() + "%";
				}
				break;
			case 113:
				if (num < 10 && num > 1)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = "+" + ((int)((1.0 - ResearchData.catapultFireRate[num + 1] + 9.999999747378752E-06) * 100.0)).ToString() + "%";
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = "+" + ((int)((1.0 - ResearchData.catapultFireRate[num] + 9.999999747378752E-06) * 100.0)).ToString() + "%";
				}
				break;
			case 115:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_MilitarySchool", "Bombards") + " : " + (num + 1).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_MilitarySchool", "Bombards") + " : " + num.ToString();
				}
				break;
			case 117:
				if (num < 10)
				{
					int num5 = vm.numCapitalBuildings();
					int num6;
					switch (num5)
					{
					case 0:
						num6 = 4;
						break;
					case 1:
						num6 = 6;
						break;
					case 2:
						num6 = 8;
						break;
					case 3:
						num6 = 10;
						break;
					case 4:
						num6 = 12;
						break;
					case 5:
						num6 = 14;
						break;
					case 6:
						num6 = 16;
						break;
					case 7:
						num6 = 18;
						break;
					case 8:
						num6 = 20;
						break;
					case 9:
						num6 = 22;
						break;
					case 10:
						num6 = 24;
						break;
					default:
						num6 = 24 + (num5 - 10);
						break;
					}
					int num7 = num6 * 60;
					num7 = (int)((double)num7 * ResearchData.ParishTownHallIncreases_Guilds[num + 1]);
					if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
					{
						num7 /= 4;
					}
					TimeSpan timeSpan = new TimeSpan(0, num7, 0);
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Construction_Time", "Construction Time") + " : " + VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds);
				}
				if (num > 0)
				{
					int num8 = vm.numCapitalBuildings();
					int num9;
					switch (num8)
					{
					case 0:
						num9 = 4;
						break;
					case 1:
						num9 = 6;
						break;
					case 2:
						num9 = 8;
						break;
					case 3:
						num9 = 10;
						break;
					case 4:
						num9 = 12;
						break;
					case 5:
						num9 = 14;
						break;
					case 6:
						num9 = 16;
						break;
					case 7:
						num9 = 18;
						break;
					case 8:
						num9 = 20;
						break;
					case 9:
						num9 = 22;
						break;
					case 10:
						num9 = 24;
						break;
					default:
						num9 = 24 + (num8 - 10);
						break;
					}
					int num10 = num9 * 60;
					num10 = (int)((double)num10 * ResearchData.ParishTownHallIncreases_Guilds[num]);
					if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
					{
						num10 /= 4;
					}
					TimeSpan timeSpan2 = new TimeSpan(0, num10, 0);
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Construction_Time", "Construction Time") + " : " + VillageMap.createBuildTimeString((int)timeSpan2.TotalSeconds);
				}
				break;
			case 118:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Faith_Points_Per_Day", "Faith Points Per Day") + " : " + ((num + 1) * 6).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Faith_Points_Per_Day", "Faith Points Per Day") + " : " + (num * 6).ToString();
				}
				break;
			case 119:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Popularity_Honour_Multiplier", "Popularity-Honour Multiplier") + " : +" + (num + 1).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Popularity_Honour_Multiplier", "Popularity-Honour Multiplier") + " : +" + num.ToString();
				}
				break;
			case 121:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Turrets", "Turrets") + " : " + (num + 1).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Turrets", "Turrets") + " : " + num.ToString();
				}
				break;
			case 122:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Tunneller_Peasants", "Tunneller Peasants") + " : " + ((num + 1) * 5).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Tunneller_Peasants", "Tunneller Peasants") + " : " + (num * 5).ToString();
				}
				break;
			case 123:
				if (num < num2)
				{
					this.lblNextLevelEffectLabel.Visible = true;
					this.lblNextLevelEffect.Visible = true;
					this.lblNextLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Ballista_Towers", "Ballista Towers") + " : " + (num + 1).ToString();
				}
				if (num > 0)
				{
					this.lblCurrentEffectLevelLabel.Visible = true;
					this.lblCurrentLevelEffect.Visible = true;
					this.lblCurrentLevelEffect.Text = SK.Text("CapitalDonateResourcesPanel_Ballista_Towers", "Ballista Towers") + " : " + num.ToString();
				}
				break;
			}
			this.highlightLine1.Visible = false;
			this.highlightLine2.Visible = false;
			this.highlightLine3.Visible = false;
			this.highlightLine4.Visible = false;
			this.highlightLine5.Visible = false;
			this.highlightLine6.Visible = false;
			this.highlightLine7.Visible = false;
			this.highlightLine8.Visible = false;
			this.highlightLine1.Image = null;
			this.highlightLine2.Image = null;
			this.highlightLine3.Image = null;
			this.highlightLine4.Image = null;
			this.highlightLine5.Image = null;
			this.highlightLine6.Image = null;
			this.highlightLine7.Image = null;
			this.highlightLine8.Image = null;
			int requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 0);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length != 0)
			{
				int requiredResourceTypeLevel = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 0, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel > 0)
				{
					this.highlightLine1.Visible = true;
					this.storedLabel1.Text = selectedBuilding.capitalResourceLevels[0].ToString("N", nfi) + " / ";
					this.priceLabel1.Text = requiredResourceTypeLevel.ToString("N", nfi);
					this.setDonateRowInfo(0, requiredResourceType);
					this.currentLevelsNeeded[0, 0] = selectedBuilding.capitalResourceLevels[0];
					this.currentLevelsNeeded[0, 1] = requiredResourceTypeLevel;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 1);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 1)
			{
				int requiredResourceTypeLevel2 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 1, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel2 > 0)
				{
					this.highlightLine2.Visible = true;
					this.storedLabel2.Text = selectedBuilding.capitalResourceLevels[1].ToString("N", nfi) + " / ";
					this.priceLabel2.Text = requiredResourceTypeLevel2.ToString("N", nfi);
					this.setDonateRowInfo(1, requiredResourceType);
					this.currentLevelsNeeded[1, 0] = selectedBuilding.capitalResourceLevels[1];
					this.currentLevelsNeeded[1, 1] = requiredResourceTypeLevel2;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 2);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 2)
			{
				int requiredResourceTypeLevel3 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 2, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel3 > 0)
				{
					this.highlightLine3.Visible = true;
					this.storedLabel3.Text = selectedBuilding.capitalResourceLevels[2].ToString("N", nfi) + " / ";
					this.priceLabel3.Text = requiredResourceTypeLevel3.ToString("N", nfi);
					this.setDonateRowInfo(2, requiredResourceType);
					this.currentLevelsNeeded[2, 0] = selectedBuilding.capitalResourceLevels[2];
					this.currentLevelsNeeded[2, 1] = requiredResourceTypeLevel3;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 3);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 3)
			{
				int requiredResourceTypeLevel4 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 3, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel4 > 0)
				{
					this.highlightLine4.Visible = true;
					this.storedLabel4.Text = selectedBuilding.capitalResourceLevels[3].ToString("N", nfi) + " / ";
					this.priceLabel4.Text = requiredResourceTypeLevel4.ToString("N", nfi);
					this.setDonateRowInfo(3, requiredResourceType);
					this.currentLevelsNeeded[3, 0] = selectedBuilding.capitalResourceLevels[3];
					this.currentLevelsNeeded[3, 1] = requiredResourceTypeLevel4;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 4);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 4)
			{
				int requiredResourceTypeLevel5 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 4, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel5 > 0)
				{
					this.highlightLine5.Visible = true;
					this.storedLabel5.Text = selectedBuilding.capitalResourceLevels[4].ToString("N", nfi) + " / ";
					this.priceLabel5.Text = requiredResourceTypeLevel5.ToString("N", nfi);
					this.setDonateRowInfo(4, requiredResourceType);
					this.currentLevelsNeeded[4, 0] = selectedBuilding.capitalResourceLevels[4];
					this.currentLevelsNeeded[4, 1] = requiredResourceTypeLevel5;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 5);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 5)
			{
				int requiredResourceTypeLevel6 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 5, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel6 > 0)
				{
					this.highlightLine6.Visible = true;
					this.storedLabel6.Text = selectedBuilding.capitalResourceLevels[5].ToString("N", nfi) + " / ";
					this.priceLabel6.Text = requiredResourceTypeLevel6.ToString("N", nfi);
					this.setDonateRowInfo(5, requiredResourceType);
					this.currentLevelsNeeded[5, 0] = selectedBuilding.capitalResourceLevels[5];
					this.currentLevelsNeeded[5, 1] = requiredResourceTypeLevel6;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 6);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 6)
			{
				int requiredResourceTypeLevel7 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 6, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel7 > 0)
				{
					this.highlightLine7.Visible = true;
					this.storedLabel7.Text = selectedBuilding.capitalResourceLevels[6].ToString("N", nfi) + " / ";
					this.priceLabel7.Text = requiredResourceTypeLevel7.ToString("N", nfi);
					this.setDonateRowInfo(6, requiredResourceType);
					this.currentLevelsNeeded[6, 0] = selectedBuilding.capitalResourceLevels[6];
					this.currentLevelsNeeded[6, 1] = requiredResourceTypeLevel7;
				}
			}
			requiredResourceType = VillageBuildingsData.getRequiredResourceType(selectedBuilding.buildingType, 7);
			if (requiredResourceType >= 0 && selectedBuilding.capitalResourceLevels.Length > 7)
			{
				int requiredResourceTypeLevel8 = VillageBuildingsData.getRequiredResourceTypeLevel(selectedBuilding.buildingType, 7, num, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
				if (requiredResourceTypeLevel8 > 0)
				{
					this.highlightLine8.Visible = true;
					this.storedLabel8.Text = selectedBuilding.capitalResourceLevels[7].ToString("N", nfi) + " / ";
					this.priceLabel8.Text = requiredResourceTypeLevel8.ToString("N", nfi);
					this.setDonateRowInfo(7, requiredResourceType);
					this.currentLevelsNeeded[7, 0] = selectedBuilding.capitalResourceLevels[7];
					this.currentLevelsNeeded[7, 1] = requiredResourceTypeLevel8;
				}
			}
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000A7900 File Offset: 0x000A5B00
		private void setDonateRowInfo(int line, int resource)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
			rowButton.ImageIcon = GFXLibrary.getCommodity32DSImage(resource);
			rowButton.Text.Text = VillageBuildingsData.getResourceNames(resource);
			rowButton.Data = resource;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000A7944 File Offset: 0x000A5B44
		public void GetVillageInfoForDonateCapitalGoods_callback(GetVillageInfoForDonateCapitalGoods_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.villageInfo = returnData.villageInfo;
				this.updateVillageHistory();
				this.updateVillageView(-1);
				this.showVillagePanel(false);
				if (this.villageInfo != null && this.villageInfo.Count > 0)
				{
					this.updateLocalValues(this.villageInfo[0].villageID);
				}
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0000C519 File Offset: 0x0000A719
		private void updateVillageView(int selectedVillageID)
		{
			if (this.villageInfo != null)
			{
				this.updateLocalValues(selectedVillageID);
			}
			this.validateSendButtons();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x000A79A8 File Offset: 0x000A5BA8
		private void selectHighlightLine(int line)
		{
			this.currentSelectedRow = line;
			this.highlightLine1.Image = null;
			this.highlightLine2.Image = null;
			this.highlightLine3.Image = null;
			this.highlightLine4.Image = null;
			this.highlightLine5.Image = null;
			this.highlightLine6.Image = null;
			this.highlightLine7.Image = null;
			this.highlightLine8.Image = null;
			if (line >= 0 && line < 8)
			{
				CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
				this.currentResource = rowButton.Data;
				CustomSelfDrawPanel.CSDImage rowHighlight = this.getRowHighlight(line);
				rowHighlight.Image = GFXLibrary.int_white_highlight_bar;
				rowHighlight.Size = new Size(400, 31);
			}
			if (this.currentResource >= 0 && this.currentResource < 124)
			{
				this.currentResourcePacketSize = GameEngine.Instance.LocalWorldData.traderCarryingLevels[this.currentResource];
				this.sendHeadingLabel.Text = SK.Text("CapitalDonate_Donate", "Donate") + " : " + VillageBuildingsData.getResourceNames(this.currentResource);
				this.sendHeadingImage.Image = GFXLibrary.getCommodity64DSImage(this.currentResource);
			}
			this.sendTrack.Max = 500000000;
			this.sendTrack.Value = 500000000;
			this.showSendWindow(true);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000A7B04 File Offset: 0x000A5D04
		private void rowClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.currentResource)
				{
					this.sendTrack.Max = 500000000;
					this.sendTrack.Value = 500000000;
					GameEngine.Instance.playInterfaceSound("CapitalDonateResourcesPanel2_line_clicked");
					this.selectHighlightLine(this.getLineFromResource(csdbutton.Data));
					base.Invalidate();
				}
			}
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x000A7900 File Offset: 0x000A5B00
		private void setRowInfo(int line, int resource)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			CustomSelfDrawPanel.CSDButton rowButton = this.getRowButton(line);
			rowButton.ImageIcon = GFXLibrary.getCommodity32DSImage(resource);
			rowButton.Text.Text = VillageBuildingsData.getResourceNames(resource);
			rowButton.Data = resource;
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x000A7B7C File Offset: 0x000A5D7C
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

		// Token: 0x060007A5 RID: 1957 RVA: 0x000A7BAC File Offset: 0x000A5DAC
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

		// Token: 0x060007A6 RID: 1958 RVA: 0x000A7C1C File Offset: 0x000A5E1C
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

		// Token: 0x060007A7 RID: 1959 RVA: 0x000A7C8C File Offset: 0x000A5E8C
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

		// Token: 0x060007A8 RID: 1960 RVA: 0x000A7CFC File Offset: 0x000A5EFC
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

		// Token: 0x060007A9 RID: 1961 RVA: 0x000A7D6C File Offset: 0x000A5F6C
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

		// Token: 0x060007AA RID: 1962 RVA: 0x0000C530 File Offset: 0x0000A730
		private void exchangeArrowClick()
		{
			if (this.exchangeArrowButton.Data == 0)
			{
				this.showVillagePanel(true);
				return;
			}
			this.showVillagePanel(false);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x000A7E40 File Offset: 0x000A6040
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

		// Token: 0x060007AC RID: 1964 RVA: 0x000A7EA0 File Offset: 0x000A60A0
		private void villageClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				GameEngine.Instance.playInterfaceSound("CapitalDonateResourcesPanel2_village_clicked");
				this.updateLocalValues(csdbutton.Data);
				this.showVillagePanel(false);
				if (this.currentSelectedRow >= 0)
				{
					this.selectHighlightLine(this.currentSelectedRow);
					this.sendWindow.invalidate();
				}
				this.validateSendButtons();
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x000A7F0C File Offset: 0x000A610C
		private void updateLocalValues(int villageid)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageDonateInfo villageDonateInfo = null;
			foreach (VillageDonateInfo villageDonateInfo2 in this.villageInfo)
			{
				if (villageDonateInfo2.villageID == villageid)
				{
					villageDonateInfo = villageDonateInfo2;
					break;
				}
			}
			if (villageDonateInfo != null)
			{
				this.localLabel1.Text = villageDonateInfo.resourceLevel1.ToString("N", nfi);
				this.localLabel2.Text = villageDonateInfo.resourceLevel2.ToString("N", nfi);
				this.localLabel3.Text = villageDonateInfo.resourceLevel3.ToString("N", nfi);
				this.localLabel4.Text = villageDonateInfo.resourceLevel4.ToString("N", nfi);
				this.localLabel5.Text = villageDonateInfo.resourceLevel5.ToString("N", nfi);
				this.localLabel6.Text = villageDonateInfo.resourceLevel6.ToString("N", nfi);
				this.localLabel7.Text = villageDonateInfo.resourceLevel7.ToString("N", nfi);
				this.localLabel8.Text = villageDonateInfo.resourceLevel8.ToString("N", nfi);
				this.currentSelectedVillageID = villageDonateInfo.villageID;
				this.exchangeNameLabel.Text = GameEngine.Instance.World.getVillageName(villageDonateInfo.villageID);
				this.sendTrack.Max = 500000000;
				this.sendTrack.Value = 500000000;
				this.showSendWindow(false);
			}
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x000A80A8 File Offset: 0x000A62A8
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

		// Token: 0x060007AF RID: 1967 RVA: 0x000A8164 File Offset: 0x000A6364
		public void updateVillageHistory()
		{
			for (int i = 0; i < 17; i++)
			{
				CustomSelfDrawPanel.CSDButton villageHistory = this.getVillageHistory(i);
				villageHistory.Visible = false;
			}
			if (this.villageInfo == null)
			{
				return;
			}
			int num = 0;
			int num2 = this.villageTabOwnPage * 16;
			while (num < 16 && num2 < this.villageInfo.Count)
			{
				if (num2 < this.villageInfo.Count)
				{
					VillageDonateInfo villageDonateInfo = this.villageInfo[num2];
					CustomSelfDrawPanel.CSDButton villageHistory2 = this.getVillageHistory(num);
					villageHistory2.Visible = true;
					villageHistory2.Text.Text = GameEngine.Instance.World.getVillageName(villageDonateInfo.villageID);
					villageHistory2.Data = villageDonateInfo.villageID;
				}
				num2++;
				num++;
			}
			if (this.villageInfo.Count > 16)
			{
				this.villageOwnPageDown.Visible = true;
				this.villageOwnPageUp.Visible = true;
				if (this.villageTabOwnPage == 0)
				{
					this.villageOwnPageUp.Visible = false;
					return;
				}
				if (this.villageTabOwnPage >= (this.villageInfo.Count - 1) / 16)
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
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000A8298 File Offset: 0x000A6498
		private void showSendWindow(bool autoSetLevel)
		{
			if (!this.sendAllowed)
			{
				this.sendWindow.Visible = false;
				return;
			}
			if (this.currentSelectedVillageID < 0 || this.currentSelectedRow < 0)
			{
				this.sendWindow.Visible = false;
				return;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.sendWindow.Visible = true;
			foreach (VillageDonateInfo villageDonateInfo in this.villageInfo)
			{
				if (villageDonateInfo.villageID == this.currentSelectedVillageID)
				{
					if (this.sendTrack.Value >= 500000000)
					{
						this.sendTrack.Value = 0;
						int num = 0;
						switch (this.currentSelectedRow)
						{
						case 0:
							num = villageDonateInfo.resourceLevel1;
							break;
						case 1:
							num = villageDonateInfo.resourceLevel2;
							break;
						case 2:
							num = villageDonateInfo.resourceLevel3;
							break;
						case 3:
							num = villageDonateInfo.resourceLevel4;
							break;
						case 4:
							num = villageDonateInfo.resourceLevel5;
							break;
						case 5:
							num = villageDonateInfo.resourceLevel6;
							break;
						case 6:
							num = villageDonateInfo.resourceLevel7;
							break;
						case 7:
							num = villageDonateInfo.resourceLevel8;
							break;
						}
						if (num < 0)
						{
							num = 0;
						}
						this.sendTrack.Max = num;
						if (autoSetLevel && this.currentSelectedRow >= 0 && this.currentSelectedRow < 8)
						{
							int num2 = this.currentLevelsNeeded[this.currentSelectedRow, 0];
							int num3 = this.currentLevelsNeeded[this.currentSelectedRow, 1];
							if (num2 < num3)
							{
								int num4 = num3 - num2;
								if (num >= num4)
								{
									this.sendTrack.Value = num4;
								}
								else
								{
									this.sendTrack.Value = num;
								}
							}
						}
					}
					this.sendMax.Text = this.sendTrack.Max.ToString("N", nfi);
					this.sendNumber.Text = this.sendTrack.Value.ToString("N", nfi);
					this.sendNumberPackets.Text = SK.Text("DonateScreen_Packets", "Packets") + " : " + (this.sendTrack.Value / this.currentResourcePacketSize).ToString("N", nfi);
					break;
				}
			}
			this.validateSendButtons();
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x000A84FC File Offset: 0x000A66FC
		private void validateSendButtons()
		{
			bool visible = false;
			if (this.currentSelectedVillageID >= 0 && this.currentSelectedRow >= 0 && this.sendTrack.Value > 0)
			{
				visible = true;
			}
			this.sendButton.Visible = visible;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0000C54E File Offset: 0x0000A74E
		private void tracksMoved()
		{
			this.showSendWindow(false);
			this.sendWindow.invalidate();
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x000A853C File Offset: 0x000A673C
		private void floatingValueCB(int value)
		{
			this.sendTrack.Value = value;
			NumberFormatInfo nfi = GameEngine.NFI;
			this.sendMax.Text = this.sendTrack.Max.ToString("N", nfi);
			this.sendNumber.Text = this.sendTrack.Value.ToString("N", nfi);
			this.sendNumberPackets.Text = SK.Text("DonateScreen_Packets", "Packets") + " : " + (this.sendTrack.Value / this.currentResourcePacketSize).ToString("N", nfi);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x000A85E8 File Offset: 0x000A67E8
		private void editSendValue()
		{
			InterfaceMgr.Instance.setFloatingValueSentDelegate(new InterfaceMgr.FloatingValueSent(this.floatingValueCB));
			Point point = InterfaceMgr.Instance.ParentForm.PointToScreen(new Point(620 + base.Location.X + 217, 460 + base.Location.Y + 120 - 50));
			FloatingInput.open(point.X, point.Y, this.sendTrack.Value, this.sendTrack.Max, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000A8688 File Offset: 0x000A6888
		private void sendClick()
		{
			this.validateSendButtons();
			if (this.sendButton.Visible)
			{
				this.sendButton.Visible = false;
				DateTime now = DateTime.Now;
				if ((now - this.lastTradeTime).TotalSeconds >= 2.0)
				{
					this.lastTradeTime = now;
					this.btnDonate_Click();
				}
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000A86E8 File Offset: 0x000A68E8
		private void btnDonate_Click()
		{
			int value = this.sendTrack.Value;
			int num = this.currentResource;
			int num2 = this.currentSelectedVillageID;
			if (value > 0 && num >= 0 && num2 >= 0)
			{
				RemoteServices.Instance.set_DonateCapitalGoods_UserCallBack(new RemoteServices.DonateCapitalGoods_UserCallBack(this.DonateCapitalGoodsCallback));
				RemoteServices.Instance.DonateCapitalGoods(this.m_capitalVillageID, num2, num, value, this.m_building.buildingType, this.m_building.buildingID);
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x000A875C File Offset: 0x000A695C
		private void DonateCapitalGoodsCallback(DonateCapitalGoods_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			this.villageInfo = returnData.villageInfo;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null && returnData.updateBuildingData != null)
			{
				village.importVillageBuildings(new List<VillageBuildingReturnData>
				{
					returnData.updateBuildingData
				}, false);
				village.m_parishCapitalResearchData = returnData.researchData;
				if (GameEngine.Instance.World.SeventhAgeWorld)
				{
					village.m_parishCapitalResearchData.seventhAge = true;
				}
			}
			this.updateScreenInfo(this.m_building, village, false);
			this.updateVillageView(this.currentSelectedVillageID);
			InterfaceMgr.Instance.flushParishFrontPageInfo(GameEngine.Instance.World.getParishFromVillageID(this.currentSelectedVillageID));
			this.sendTrack.Max = 500000000;
			this.sendTrack.Value = 500000000;
			this.showSendWindow(false);
			this.currentSelectedRow = -1;
			this.currentResource = -1;
			this.selectHighlightLine(this.currentSelectedRow);
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x04000A86 RID: 2694
		private DockableControl dockableControl;

		// Token: 0x04000A87 RID: 2695
		private IContainer components;

		// Token: 0x04000A88 RID: 2696
		public static CapitalDonateResourcesPanel2 instance = null;

		// Token: 0x04000A89 RID: 2697
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A8A RID: 2698
		private CustomSelfDrawPanel.CSDImage tradeWithImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A8B RID: 2699
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000A8C RID: 2700
		private CustomSelfDrawPanel.CSDLabel tradeWithLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A8D RID: 2701
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000A8E RID: 2702
		private CustomSelfDrawPanel.CSDImage illustration = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A8F RID: 2703
		private CustomSelfDrawPanel.CSDImage buildingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A90 RID: 2704
		private CustomSelfDrawPanel.CSDExtendingPanel topWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000A91 RID: 2705
		private CustomSelfDrawPanel.CSDLabel buildingTypeName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A92 RID: 2706
		private CustomSelfDrawPanel.CSDLabel currentLevelName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A93 RID: 2707
		private CustomSelfDrawPanel.CSDLabel effectDescription = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A94 RID: 2708
		private CustomSelfDrawPanel.CSDLabel lblCurrentEffectLevelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A95 RID: 2709
		private CustomSelfDrawPanel.CSDLabel lblNextLevelEffectLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A96 RID: 2710
		private CustomSelfDrawPanel.CSDLabel lblCurrentLevelEffect = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A97 RID: 2711
		private CustomSelfDrawPanel.CSDLabel lblNextLevelEffect = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A98 RID: 2712
		private CustomSelfDrawPanel.CSDExtendingPanel leftWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000A99 RID: 2713
		private CustomSelfDrawPanel.CSDExtendingPanel midWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000A9A RID: 2714
		private CustomSelfDrawPanel.CSDLabel sendHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A9B RID: 2715
		private CustomSelfDrawPanel.CSDImage sendHeadingImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000A9C RID: 2716
		private CustomSelfDrawPanel.CSDExtendingPanel sendWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000A9D RID: 2717
		private CustomSelfDrawPanel.CSDExtendingPanel sendSubWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000A9E RID: 2718
		private CustomSelfDrawPanel.CSDLabel sendNumber = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A9F RID: 2719
		private CustomSelfDrawPanel.CSDLabel sendNumberPackets = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AA0 RID: 2720
		private CustomSelfDrawPanel.CSDLabel sendMin = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AA1 RID: 2721
		private CustomSelfDrawPanel.CSDLabel sendMax = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AA2 RID: 2722
		private CustomSelfDrawPanel.CSDButton sendButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AA3 RID: 2723
		private CustomSelfDrawPanel.CSDTrackBar sendTrack = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x04000AA4 RID: 2724
		private CustomSelfDrawPanel.CSDButton sendEditButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AA5 RID: 2725
		private CustomSelfDrawPanel.CSDLabel localHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AA6 RID: 2726
		private CustomSelfDrawPanel.CSDLabel storedHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AA7 RID: 2727
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000AA8 RID: 2728
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea2 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000AA9 RID: 2729
		private CustomSelfDrawPanel.CSDHorzExtendingPanel exchangeNameBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000AAA RID: 2730
		private CustomSelfDrawPanel.CSDLabel exchangeNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AAB RID: 2731
		private CustomSelfDrawPanel.CSDButton exchangeArrowButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AAC RID: 2732
		private CustomSelfDrawPanel.CSDImage highlightLine1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AAD RID: 2733
		private CustomSelfDrawPanel.CSDImage highlightLine2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AAE RID: 2734
		private CustomSelfDrawPanel.CSDImage highlightLine3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AAF RID: 2735
		private CustomSelfDrawPanel.CSDImage highlightLine4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AB0 RID: 2736
		private CustomSelfDrawPanel.CSDImage highlightLine5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AB1 RID: 2737
		private CustomSelfDrawPanel.CSDImage highlightLine6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AB2 RID: 2738
		private CustomSelfDrawPanel.CSDImage highlightLine7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AB3 RID: 2739
		private CustomSelfDrawPanel.CSDImage highlightLine8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AB4 RID: 2740
		private CustomSelfDrawPanel.CSDButton selectRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AB5 RID: 2741
		private CustomSelfDrawPanel.CSDButton selectRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AB6 RID: 2742
		private CustomSelfDrawPanel.CSDButton selectRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AB7 RID: 2743
		private CustomSelfDrawPanel.CSDButton selectRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AB8 RID: 2744
		private CustomSelfDrawPanel.CSDButton selectRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AB9 RID: 2745
		private CustomSelfDrawPanel.CSDButton selectRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ABA RID: 2746
		private CustomSelfDrawPanel.CSDButton selectRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ABB RID: 2747
		private CustomSelfDrawPanel.CSDButton selectRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ABC RID: 2748
		private CustomSelfDrawPanel.CSDLabel localLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ABD RID: 2749
		private CustomSelfDrawPanel.CSDLabel localLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ABE RID: 2750
		private CustomSelfDrawPanel.CSDLabel localLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ABF RID: 2751
		private CustomSelfDrawPanel.CSDLabel localLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC0 RID: 2752
		private CustomSelfDrawPanel.CSDLabel localLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC1 RID: 2753
		private CustomSelfDrawPanel.CSDLabel localLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC2 RID: 2754
		private CustomSelfDrawPanel.CSDLabel localLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC3 RID: 2755
		private CustomSelfDrawPanel.CSDLabel localLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC4 RID: 2756
		private CustomSelfDrawPanel.CSDLabel storedLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC5 RID: 2757
		private CustomSelfDrawPanel.CSDLabel storedLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC6 RID: 2758
		private CustomSelfDrawPanel.CSDLabel storedLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC7 RID: 2759
		private CustomSelfDrawPanel.CSDLabel storedLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC8 RID: 2760
		private CustomSelfDrawPanel.CSDLabel storedLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AC9 RID: 2761
		private CustomSelfDrawPanel.CSDLabel storedLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACA RID: 2762
		private CustomSelfDrawPanel.CSDLabel storedLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACB RID: 2763
		private CustomSelfDrawPanel.CSDLabel storedLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACC RID: 2764
		private CustomSelfDrawPanel.CSDLabel priceLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACD RID: 2765
		private CustomSelfDrawPanel.CSDLabel priceLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACE RID: 2766
		private CustomSelfDrawPanel.CSDLabel priceLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000ACF RID: 2767
		private CustomSelfDrawPanel.CSDLabel priceLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD0 RID: 2768
		private CustomSelfDrawPanel.CSDLabel priceLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD1 RID: 2769
		private CustomSelfDrawPanel.CSDLabel priceLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD2 RID: 2770
		private CustomSelfDrawPanel.CSDLabel priceLabel7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD3 RID: 2771
		private CustomSelfDrawPanel.CSDLabel priceLabel8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD4 RID: 2772
		private CustomSelfDrawPanel.CSDImage villageSelectPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000AD5 RID: 2773
		private CustomSelfDrawPanel.CSDButton villageSelectPanelTab1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AD6 RID: 2774
		private CustomSelfDrawPanel.CSDButton villageSelectPanelTab2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AD7 RID: 2775
		private CustomSelfDrawPanel.CSDLabel villageSelectPanelLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000AD8 RID: 2776
		private CustomSelfDrawPanel.CSDButton villageSelectVillage1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AD9 RID: 2777
		private CustomSelfDrawPanel.CSDButton villageSelectVillage2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADA RID: 2778
		private CustomSelfDrawPanel.CSDButton villageSelectVillage3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADB RID: 2779
		private CustomSelfDrawPanel.CSDButton villageSelectVillage4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADC RID: 2780
		private CustomSelfDrawPanel.CSDButton villageSelectVillage5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADD RID: 2781
		private CustomSelfDrawPanel.CSDButton villageSelectVillage6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADE RID: 2782
		private CustomSelfDrawPanel.CSDButton villageSelectVillage7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000ADF RID: 2783
		private CustomSelfDrawPanel.CSDButton villageSelectVillage8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE0 RID: 2784
		private CustomSelfDrawPanel.CSDButton villageSelectVillage9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE1 RID: 2785
		private CustomSelfDrawPanel.CSDButton villageSelectVillage10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE2 RID: 2786
		private CustomSelfDrawPanel.CSDButton villageSelectVillage11 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE3 RID: 2787
		private CustomSelfDrawPanel.CSDButton villageSelectVillage12 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE4 RID: 2788
		private CustomSelfDrawPanel.CSDButton villageSelectVillage13 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE5 RID: 2789
		private CustomSelfDrawPanel.CSDButton villageSelectVillage14 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE6 RID: 2790
		private CustomSelfDrawPanel.CSDButton villageSelectVillage15 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE7 RID: 2791
		private CustomSelfDrawPanel.CSDButton villageSelectVillage16 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE8 RID: 2792
		private CustomSelfDrawPanel.CSDButton villageSelectVillage17 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AE9 RID: 2793
		private CustomSelfDrawPanel.CSDButton villageOwnPageUp = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AEA RID: 2794
		private CustomSelfDrawPanel.CSDButton villageOwnPageDown = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AEB RID: 2795
		private CustomSelfDrawPanel.CSDButton worldMapButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AEC RID: 2796
		private CustomSelfDrawPanel.CSDButton stockExchangeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000AED RID: 2797
		private VillageMapBuilding m_building;

		// Token: 0x04000AEE RID: 2798
		private int m_capitalVillageID = -1;

		// Token: 0x04000AEF RID: 2799
		private bool sendAllowed;

		// Token: 0x04000AF0 RID: 2800
		public static string capitalTooltipText = "";

		// Token: 0x04000AF1 RID: 2801
		public int[,] currentLevelsNeeded = new int[8, 2];

		// Token: 0x04000AF2 RID: 2802
		private int currentSelectedVillageID = -1;

		// Token: 0x04000AF3 RID: 2803
		private List<VillageDonateInfo> villageInfo;

		// Token: 0x04000AF4 RID: 2804
		private int currentResource = -1;

		// Token: 0x04000AF5 RID: 2805
		private int currentResourcePacketSize = 1;

		// Token: 0x04000AF6 RID: 2806
		private int currentSelectedRow = -1;

		// Token: 0x04000AF7 RID: 2807
		private int villageTabOwnPage;

		// Token: 0x04000AF8 RID: 2808
		private DateTime lastTradeTime = DateTime.MinValue;
	}
}
