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
	// Token: 0x02000478 RID: 1144
	public class ResearchPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002966 RID: 10598 RVA: 0x001F8028 File Offset: 0x001F6228
		public ResearchPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.NoDrawBackground = true;
		}

		// Token: 0x06002967 RID: 10599 RVA: 0x001F84D0 File Offset: 0x001F66D0
		public void init()
		{
			base.clearControls();
			base.Size = InterfaceMgr.Instance.getMainWindowSize();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_001;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			this.mainBackgroundImage.ClipRect = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
			this.mainBackgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.backgroundClick));
			base.addControl(this.mainBackgroundImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 17, new Point(base.Width - 44, 3));
			int num = 42;
			this.currentResearchBackgroundImage.Image = GFXLibrary.ill_back_bline_0000;
			this.currentResearchBackgroundImage.Position = new Point(19, 2 + num + 20);
			this.mainBackgroundImage.addControl(this.currentResearchBackgroundImage);
			this.currentResearchBackgroundImage2.Image = GFXLibrary.research_ill_none;
			this.currentResearchBackgroundImage2.Position = new Point(19, 2 + num + 20);
			this.mainBackgroundImage.addControl(this.currentResearchBackgroundImage2);
			this.currentResearchImage.Position = new Point(4, 8);
			this.currentResearchImage.Visible = false;
			this.currentResearchBackgroundImage.addControl(this.currentResearchImage);
			this.currentResearchingBarImage.Image = GFXLibrary.ill_back_green_textback;
			this.currentResearchingBarImage.Position = new Point(4, 68);
			this.currentResearchBackgroundImage.addControl(this.currentResearchingBarImage);
			this.currentResearchText.Text = "";
			this.currentResearchText.Color = global::ARGBColors.Black;
			this.currentResearchText.Position = new Point(0, 0);
			this.currentResearchText.Size = new Size(this.currentResearchingBarImage.Width, this.currentResearchingBarImage.Height);
			this.currentResearchText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentResearchText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.currentResearchingBarImage.addControl(this.currentResearchText);
			this.currentResearchCancelButton.ImageNorm = GFXLibrary.techtree_button_normal;
			this.currentResearchCancelButton.ImageOver = GFXLibrary.techtree_button_over;
			this.currentResearchCancelButton.ImageClick = GFXLibrary.techtree_button_in;
			this.currentResearchCancelButton.Position = new Point(17, 123 + num);
			this.mainBackgroundImage.addControl(this.currentResearchCancelButton);
			this.currentResearchCancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.currentResearchCancelButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentResearchCancelButton.TextYOffset = 1;
			this.currentResearchCancelButton.Text.Color = global::ARGBColors.Black;
			this.currentResearchCancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelResearchClick), "ResearchPanel_cancel");
			this.currentResearchInfoBox.Size = new Size(base.Width - 450 + 2 + 15 + 15, 91);
			this.currentResearchInfoBox.Position = new Point(179, 27 + num);
			this.currentResearchInfoBox.Create(GFXLibrary.tech_tree_inset_tall_left, GFXLibrary.tech_tree_inset_tall_mid, GFXLibrary.tech_tree_inset_tall_right);
			this.mainBackgroundImage.addControl(this.currentResearchInfoBox);
			this.currentResearchInfoBoxHeadingText.Text = "";
			this.currentResearchInfoBoxHeadingText.Color = Color.FromArgb(254, 230, 192);
			this.currentResearchInfoBoxHeadingText.Position = new Point(20, 8);
			this.currentResearchInfoBoxHeadingText.Size = new Size(this.currentResearchInfoBox.Width - 40, this.currentResearchingBarImage.Height);
			this.currentResearchInfoBoxHeadingText.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.currentResearchInfoBoxHeadingText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.currentResearchInfoBox.addControl(this.currentResearchInfoBoxHeadingText);
			this.currentResearchInfoBoxRow1Text.Text = "Row of Text 1";
			this.currentResearchInfoBoxRow1Text.Color = Color.FromArgb(254, 230, 192);
			this.currentResearchInfoBoxRow1Text.Position = new Point(20, 30);
			this.currentResearchInfoBoxRow1Text.Size = new Size(this.currentResearchInfoBox.Width - 40, this.currentResearchingBarImage.Height);
			this.currentResearchInfoBoxRow1Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentResearchInfoBoxRow1Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.currentResearchInfoBox.addControl(this.currentResearchInfoBoxRow1Text);
			this.currentResearchInfoBoxRow2Text.Text = "Row of Text 2";
			this.currentResearchInfoBoxRow2Text.Color = Color.FromArgb(254, 230, 192);
			this.currentResearchInfoBoxRow2Text.Position = new Point(20, 49);
			this.currentResearchInfoBoxRow2Text.Size = new Size(this.currentResearchInfoBox.Width - 40, this.currentResearchingBarImage.Height);
			this.currentResearchInfoBoxRow2Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentResearchInfoBoxRow2Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.currentResearchInfoBox.addControl(this.currentResearchInfoBoxRow2Text);
			this.currentResearchInfoBoxRow3Text.Text = "Row of Text 3";
			this.currentResearchInfoBoxRow3Text.Color = Color.FromArgb(254, 230, 192);
			this.currentResearchInfoBoxRow3Text.Position = new Point(20, 66);
			this.currentResearchInfoBoxRow3Text.Size = new Size(this.currentResearchInfoBox.Width - 40, this.currentResearchingBarImage.Height);
			this.currentResearchInfoBoxRow3Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.currentResearchInfoBoxRow3Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.currentResearchInfoBox.addControl(this.currentResearchInfoBoxRow3Text);
			this.queuedResearchArea.Position = new Point(5, 56);
			int num2 = 5;
			this.queuedResearchArea.Size = new Size(500, 50);
			this.currentResearchInfoBox.addControl(this.queuedResearchArea);
			this.queuedResearchImage1.Image = GFXLibrary.research_ill_wine_production;
			this.queuedResearchImage1.Size = new Size(this.queuedResearchImage1.Size.Width / 2, this.queuedResearchImage1.Size.Height / 2);
			this.queuedResearchImage1.Position = new Point(num2, 5);
			this.queuedResearchImage1.Visible = false;
			this.queuedResearchArea.addControl(this.queuedResearchImage1);
			this.queuedResearchImage2.Image = GFXLibrary.research_ill_wine_production;
			this.queuedResearchImage2.Size = new Size(this.queuedResearchImage2.Size.Width / 2, this.queuedResearchImage2.Size.Height / 2);
			this.queuedResearchImage2.Position = new Point(num2 + 81, 5);
			this.queuedResearchImage2.Visible = false;
			this.queuedResearchArea.addControl(this.queuedResearchImage2);
			this.queuedResearchImage3.Image = GFXLibrary.research_ill_wine_production;
			this.queuedResearchImage3.Size = new Size(this.queuedResearchImage3.Size.Width / 2, this.queuedResearchImage3.Size.Height / 2);
			this.queuedResearchImage3.Position = new Point(num2 + 162, 5);
			this.queuedResearchImage3.Visible = false;
			this.queuedResearchArea.addControl(this.queuedResearchImage3);
			this.queuedResearchImage4.Image = GFXLibrary.research_ill_wine_production;
			this.queuedResearchImage4.Size = new Size(this.queuedResearchImage4.Size.Width / 2, this.queuedResearchImage4.Size.Height / 2);
			this.queuedResearchImage4.Position = new Point(num2 + 243, 5);
			this.queuedResearchImage4.Visible = false;
			this.queuedResearchArea.addControl(this.queuedResearchImage4);
			this.queuedResearchImage5.Image = GFXLibrary.research_ill_wine_production;
			this.queuedResearchImage5.Size = new Size(this.queuedResearchImage5.Size.Width / 2, this.queuedResearchImage5.Size.Height / 2);
			this.queuedResearchImage5.Position = new Point(num2 + 324, 5);
			this.queuedResearchImage5.Visible = false;
			this.queuedResearchArea.addControl(this.queuedResearchImage5);
			this.queuedResearchButton1.ImageNorm = GFXLibrary.research_border_research_ill_normal;
			this.queuedResearchButton1.ImageOver = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton1.ImageClick = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton1.Position = new Point(num2 - 1, 4);
			this.queuedResearchButton1.Data = 0;
			this.queuedResearchButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.queuedResearchClick), "ResearchPanel_queued_clicked");
			this.queuedResearchArea.addControl(this.queuedResearchButton1);
			this.queuedResearchButton2.ImageNorm = GFXLibrary.research_border_research_ill_normal;
			this.queuedResearchButton2.ImageOver = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton2.ImageClick = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton2.Position = new Point(num2 - 1 + 81, 4);
			this.queuedResearchButton2.Data = 1;
			this.queuedResearchButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.queuedResearchClick), "ResearchPanel_queued_clicked");
			this.queuedResearchArea.addControl(this.queuedResearchButton2);
			this.queuedResearchButton3.ImageNorm = GFXLibrary.research_border_research_ill_normal;
			this.queuedResearchButton3.ImageOver = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton3.ImageClick = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton3.Position = new Point(num2 - 1 + 162, 4);
			this.queuedResearchButton3.Data = 2;
			this.queuedResearchButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.queuedResearchClick), "ResearchPanel_queued_clicked");
			this.queuedResearchArea.addControl(this.queuedResearchButton3);
			this.queuedResearchButton4.ImageNorm = GFXLibrary.research_border_research_ill_normal;
			this.queuedResearchButton4.ImageOver = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton4.ImageClick = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton4.Position = new Point(num2 - 1 + 243, 4);
			this.queuedResearchButton4.Data = 3;
			this.queuedResearchButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.queuedResearchClick), "ResearchPanel_queued_clicked");
			this.queuedResearchArea.addControl(this.queuedResearchButton4);
			this.queuedResearchButton5.ImageNorm = GFXLibrary.research_border_research_ill_normal;
			this.queuedResearchButton5.ImageOver = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton5.ImageClick = GFXLibrary.research_border_research_ill_over;
			this.queuedResearchButton5.Position = new Point(num2 - 1 + 324, 4);
			this.queuedResearchButton5.Data = 4;
			this.queuedResearchButton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.queuedResearchClick), "ResearchPanel_queued_clicked");
			this.queuedResearchArea.addControl(this.queuedResearchButton5);
			this.queuedResearchNoPremiumText.Text = SK.Text("Research_Queue_Premium", "Research Queue requires a Premium Token");
			this.queuedResearchNoPremiumText.Color = Color.FromArgb(254, 230, 192);
			int num3 = 148 + (base.Width - 992);
			if (num3 < 175)
			{
				num3 = ((!(Program.mySettings.LanguageIdent == "de") && !(Program.mySettings.LanguageIdent == "fr")) ? 175 : 184);
				this.queuedResearchNoPremiumText.Position = new Point(399, -10);
			}
			else
			{
				this.queuedResearchNoPremiumText.Position = new Point(409, -10);
			}
			this.queuedResearchNoPremiumText.Size = new Size(num3, 58);
			this.queuedResearchNoPremiumText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.queuedResearchNoPremiumText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.queuedResearchArea.addControl(this.queuedResearchNoPremiumText);
			this.timeInfoBox.Size = new Size(base.Width - 450 + 2 + 15 + 15, 35);
			this.timeInfoBox.Position = new Point(179, 125 + num);
			this.mainBackgroundImage.addControl(this.timeInfoBox);
			this.timeInfoBox.Create(GFXLibrary.tech_tree_inset_left, GFXLibrary.tech_tree_inset_mid, GFXLibrary.tech_tree_inset_right);
			this.timeProgressBar.Size = new Size(this.timeInfoBox.Size.Width - 14, 22);
			this.timeProgressBar.Position = new Point(7, 7);
			this.timeInfoBox.addControl(this.timeProgressBar);
			this.timeProgressBar.Offset = new Point(5, 3);
			this.timeProgressBar.Create(GFXLibrary.tech_tree_progbar_olive_left, GFXLibrary.tech_tree_progbar_olive_mid, GFXLibrary.tech_tree_progbar_olive_right, GFXLibrary.tech_tree_progbar_green_left, GFXLibrary.tech_tree_progbar_green_mid, GFXLibrary.tech_tree_progbar_green_right);
			this.timeProgressText.Text = "";
			this.timeProgressText.Color = global::ARGBColors.Black;
			this.timeProgressText.Position = new Point(0, 0);
			this.timeProgressText.Size = new Size(this.timeInfoBox.Width, this.timeInfoBox.Height);
			this.timeProgressText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.timeProgressText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.timeInfoBox.addControl(this.timeProgressText);
			this.buyPointInfoBox.Size = new Size(208, 91);
			this.buyPointInfoBox.Position = new Point(base.Width - 244 + 15, 27 + num);
			this.mainBackgroundImage.addControl(this.buyPointInfoBox);
			this.buyPointInfoBox.Create(GFXLibrary.tech_tree_inset_tall_left, GFXLibrary.tech_tree_inset_tall_mid, GFXLibrary.tech_tree_inset_tall_right);
			this.buyPointInfoBox.addControl(this.buyPointButton);
			this.buyPointGold.Image = GFXLibrary.com_32_money;
			this.buyPointGold.Position = new Point(48, 8);
			this.buyPointInfoBox.addControl(this.buyPointGold);
			this.buyPointText.Text = "";
			this.buyPointText.Color = Color.FromArgb(254, 230, 192);
			this.buyPointText.Position = new Point(97, -6);
			this.buyPointText.Size = new Size(100, 60);
			this.buyPointText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.buyPointText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.buyPointInfoBox.addControl(this.buyPointText);
			this.buyPointButton.ImageNorm = GFXLibrary.techtree_button_normal;
			this.buyPointButton.ImageOver = GFXLibrary.techtree_button_over;
			this.buyPointButton.ImageClick = GFXLibrary.techtree_button_in;
			this.buyPointButton.Position = new Point(26, 44);
			this.buyPointButton.Text.Text = SK.Text("Research_Buy_Point", "Buy Point");
			this.buyPointButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.buyPointButton.TextYOffset = 1;
			this.buyPointButton.Text.Color = global::ARGBColors.Black;
			this.buyPointButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyPointClick), "ResearchPanel_buy_point");
			this.pointsInfoBox.Size = new Size(208, 35);
			this.pointsInfoBox.Position = new Point(base.Width - 244 + 15, 125 + num);
			this.mainBackgroundImage.addControl(this.pointsInfoBox);
			this.pointsInfoBox.Create(GFXLibrary.tech_tree_inset_left, GFXLibrary.tech_tree_inset_mid, GFXLibrary.tech_tree_inset_right);
			this.pointsText.Color = Color.FromArgb(254, 230, 192);
			this.pointsText.Text = "";
			this.pointsText.Position = new Point(0, 0);
			this.pointsText.Size = new Size(this.pointsInfoBox.Width, this.pointsInfoBox.Height);
			this.pointsText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.pointsText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.pointsInfoBox.addControl(this.pointsText);
			this.scrollPanelImage.Image = GFXLibrary.body_background_002;
			this.scrollPanelImage.Tile = true;
			this.scrollPanelImage.Position = new Point(20, 242);
			this.scrollPanelImage.Size = new Size(base.Width - 40, base.Height - 205 - 55);
			this.scrollPanelImage.ClipRect = new Rectangle(new Point(0, 0), new Size(base.Width - 40, base.Height - 205 - 55));
			this.mainBackgroundImage.addControl(this.scrollPanelImage);
			this.dragOverlay.Position = this.scrollPanelImage.Position;
			this.dragOverlay.Size = this.scrollPanelImage.Size;
			this.dragOverlay.Visible = true;
			this.dragOverlay.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.windowDragged));
			this.dragOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.dragWindowMouseWheel));
			this.dragOverlay.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.dragWindowMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.dragWindowMouseLeave));
			this.mainBackgroundImage.addControl(this.dragOverlay);
			this.dragOverlay2.Position = this.scrollPanelImage.Position;
			this.dragOverlay2.Size = this.scrollPanelImage.Size;
			this.dragOverlay2.Visible = false;
			this.dragOverlay2.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.listWindowMouseWheel));
			this.mainBackgroundImage.addControl(this.dragOverlay2);
			int num4 = 242;
			int num5 = 20;
			int num6 = base.Width - 20;
			int num7 = base.Height - 205 - 55 + num4;
			this.scrollPanelTopLeftOverlay.Image = GFXLibrary.techtree_inset_edge_topleft;
			this.scrollPanelTopLeftOverlay.Position = new Point(num5, num4);
			this.mainBackgroundImage.addControl(this.scrollPanelTopLeftOverlay);
			this.scrollPanelTopRightOverlay.Image = GFXLibrary.techtree_inset_edge_topright;
			this.scrollPanelTopRightOverlay.Position = new Point(num6 - this.scrollPanelTopRightOverlay.Image.Width, num4);
			this.mainBackgroundImage.addControl(this.scrollPanelTopRightOverlay);
			this.scrollPanelTopMiddleOverlay.Image = GFXLibrary.techtree_inset_edge_top;
			this.scrollPanelTopMiddleOverlay.Position = new Point(num5 + this.scrollPanelTopLeftOverlay.Image.Width, num4);
			this.scrollPanelTopMiddleOverlay.Size = new Size(num6 - num5 - this.scrollPanelTopRightOverlay.Image.Width - this.scrollPanelTopLeftOverlay.Image.Width, this.scrollPanelTopMiddleOverlay.Image.Height);
			this.scrollPanelTopMiddleOverlay.ClipRect = new Rectangle(0, 0, this.scrollPanelTopMiddleOverlay.Size.Width, this.scrollPanelTopMiddleOverlay.Size.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelTopMiddleOverlay);
			this.scrollPanelBottomLeftOverlay.Image = GFXLibrary.techtree_inset_edge_bottomleft;
			this.scrollPanelBottomLeftOverlay.Position = new Point(num5, num7 - this.scrollPanelBottomLeftOverlay.Image.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelBottomLeftOverlay);
			this.scrollPanelLeftOverlay.Image = GFXLibrary.techtree_inset_edge_left;
			this.scrollPanelLeftOverlay.Position = new Point(num5, num4 + this.scrollPanelTopLeftOverlay.Image.Height);
			this.scrollPanelLeftOverlay.Size = new Size(this.scrollPanelLeftOverlay.Image.Width, num7 - num4 - this.scrollPanelTopLeftOverlay.Image.Height - this.scrollPanelBottomLeftOverlay.Image.Height);
			this.scrollPanelLeftOverlay.ClipRect = new Rectangle(0, 0, this.scrollPanelLeftOverlay.Size.Width, this.scrollPanelLeftOverlay.Size.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelLeftOverlay);
			this.scrollPanelBottomRightOverlay.Image = GFXLibrary.techtree_inset_edge_bottomright;
			this.scrollPanelBottomRightOverlay.Position = new Point(num6 - this.scrollPanelBottomRightOverlay.Image.Width, num7 - this.scrollPanelBottomRightOverlay.Image.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelBottomRightOverlay);
			this.scrollPanelRightOverlay.Image = GFXLibrary.techtree_inset_edge_right;
			this.scrollPanelRightOverlay.Position = new Point(num6 - this.scrollPanelRightOverlay.Image.Width, num4 + this.scrollPanelTopRightOverlay.Image.Height);
			this.scrollPanelRightOverlay.Size = new Size(this.scrollPanelRightOverlay.Image.Width, num7 - num4 - this.scrollPanelTopRightOverlay.Image.Height - this.scrollPanelBottomRightOverlay.Image.Height);
			this.scrollPanelRightOverlay.ClipRect = new Rectangle(0, 0, this.scrollPanelRightOverlay.Size.Width, this.scrollPanelRightOverlay.Size.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelRightOverlay);
			this.scrollPanelBottomMiddleOverlay.Image = GFXLibrary.techtree_inset_edge_bottom;
			this.scrollPanelBottomMiddleOverlay.Position = new Point(num5 + this.scrollPanelBottomLeftOverlay.Image.Width, num7 - this.scrollPanelBottomMiddleOverlay.Image.Height);
			this.scrollPanelBottomMiddleOverlay.Size = new Size(num6 - num5 - this.scrollPanelBottomRightOverlay.Image.Width - this.scrollPanelBottomLeftOverlay.Image.Width, this.scrollPanelBottomMiddleOverlay.Image.Height);
			this.scrollPanelBottomMiddleOverlay.ClipRect = new Rectangle(0, 0, this.scrollPanelBottomMiddleOverlay.Size.Width, this.scrollPanelBottomMiddleOverlay.Size.Height);
			this.mainBackgroundImage.addControl(this.scrollPanelBottomMiddleOverlay);
			this.tab1Button.ImageNorm = GFXLibrary.tech_tree_tab_01_normal;
			this.tab1Button.ImageOver = GFXLibrary.tech_tree_tab_01_highlight;
			this.tab1Button.Text.Text = SK.Text("Research_Industry", "Industry");
			this.tab1Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab1Button.Position = new Point(num5, 216);
			this.tab1Button.TextYOffset = -13;
			this.tab1Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab1Button.Data = 0;
			this.tab1Button.ClickArea = new Rectangle(0, 0, this.tab1Button.ImageNorm.Width, 25);
			this.tab1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "ResearchPanel_industry_tab");
			this.mainBackgroundImage.addControl(this.tab1Button);
			this.tab2Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab2Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab2Button.Text.Text = SK.Text("Research_Military", "Military");
			this.tab2Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab2Button.TextYOffset = 0;
			this.tab2Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab2Button.Position = new Point(this.tab1Button.Position.X + this.tab1Button.Width + 2, 216);
			this.tab2Button.Data = 1;
			this.tab2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "ResearchPanel_military_tab");
			this.mainBackgroundImage.addControl(this.tab2Button);
			this.tab3Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab3Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab3Button.Text.Text = SK.Text("Research_Farming", "Farming");
			this.tab3Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab3Button.TextYOffset = 0;
			this.tab3Button.Position = new Point(this.tab2Button.Position.X + this.tab2Button.Width + 2, 216);
			this.tab3Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab3Button.Data = 2;
			this.tab3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "ResearchPanel_farming_tab");
			this.mainBackgroundImage.addControl(this.tab3Button);
			this.tab4Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab4Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab4Button.Text.Text = SK.Text("Research_Education", "Education");
			this.tab4Button.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.tab4Button.TextYOffset = 0;
			this.tab4Button.Position = new Point(this.tab3Button.Position.X + this.tab3Button.Width + 2, 216);
			this.tab4Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab4Button.Data = 3;
			this.tab4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabClicked), "ResearchPanel_education_tab");
			this.mainBackgroundImage.addControl(this.tab4Button);
			this.tabModeTreeButton.ImageNorm = GFXLibrary.tech_tree_tab_tree_normal;
			this.tabModeTreeButton.ImageOver = GFXLibrary.tech_tree_tab_tree_normal;
			this.tabModeTreeButton.Position = new Point(num6 - this.tabModeTreeButton.Width, 216);
			this.tabModeTreeButton.Data = 1;
			this.tabModeTreeButton.ClickArea = new Rectangle(0, 0, this.tabModeTreeButton.Width, 25);
			this.tabModeTreeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabModeClicked), "ResearchPanel_tree_mode");
			this.tabModeTreeButton.CustomTooltipID = 301;
			this.mainBackgroundImage.addControl(this.tabModeTreeButton);
			this.tabModeListButton.ImageNorm = GFXLibrary.tech_tree_tab_list_normal;
			this.tabModeListButton.ImageOver = GFXLibrary.tech_tree_tab_list_normal;
			this.tabModeListButton.Position = new Point(this.tabModeTreeButton.Position.X - this.tabModeListButton.Width - 2, 216);
			this.tabModeListButton.Data = 0;
			this.tabModeListButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tabModeClicked), "ResearchPanel_list_mode");
			this.tabModeListButton.CustomTooltipID = 300;
			this.mainBackgroundImage.addControl(this.tabModeListButton);
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(12);
			this.manageTabs(this.lastTab);
			this.forceUpdate = true;
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x001FA290 File Offset: 0x001F8490
		private BaseImage getBuildingGFX(int building)
		{
			switch (building)
			{
			case 6:
				return GFXLibrary.r_building_panel_bld_icon_ind_woodcutters_hut;
			case 7:
				return GFXLibrary.r_building_panel_bld_icon_ind_stone_quarry;
			case 8:
				return GFXLibrary.r_building_panel_bld_icon_ind_iron_mine;
			case 9:
				return GFXLibrary.r_building_panel_bld_icon_ind_pitch_rig;
			case 12:
				return GFXLibrary.r_building_panel_bld_icon_food_brewery;
			case 13:
				return GFXLibrary.r_building_panel_bld_icon_food_apple_orchard;
			case 14:
				return GFXLibrary.r_building_panel_bld_icon_food_bakery;
			case 15:
				return GFXLibrary.r_building_panel_bld_icon_food_vegetable_farm;
			case 16:
				return GFXLibrary.r_building_panel_bld_icon_food_pig_farm;
			case 17:
				return GFXLibrary.r_building_panel_bld_icon_food_dairy_farm;
			case 18:
				return GFXLibrary.r_building_panel_bld_icon_food_fishing_jetty;
			case 19:
				return GFXLibrary.r_building_panel_bld_icon_hon_tailers_workshop;
			case 21:
				return GFXLibrary.r_building_panel_bld_icon_hon_carpenters_workshop;
			case 22:
				return GFXLibrary.r_building_panel_bld_icon_hon_hunters_hut;
			case 23:
				return GFXLibrary.r_building_panel_bld_icon_hon_salt_pan;
			case 24:
				return GFXLibrary.r_building_panel_bld_icon_hon_spice_docs;
			case 25:
				return GFXLibrary.r_building_panel_bld_icon_hon_silk_docs;
			case 26:
				return GFXLibrary.r_building_panel_bld_icon_hon_metalworks_workshop;
			case 28:
				return GFXLibrary.r_building_panel_bld_icon_mil_pole_turner;
			case 29:
				return GFXLibrary.r_building_panel_bld_icon_mil_fletcher;
			case 30:
				return GFXLibrary.r_building_panel_bld_icon_mil_blacksmith;
			case 31:
				return GFXLibrary.r_building_panel_bld_icon_mil_armourer;
			case 32:
				return GFXLibrary.r_building_panel_bld_icon_mil_siege_workshop;
			case 33:
				return GFXLibrary.r_building_panel_bld_icon_hon_vinyard;
			case 34:
				return GFXLibrary.r_building_panel_bld_civ_rel_small_church;
			case 35:
				return GFXLibrary.r_building_panel_bld_icon_food_inn;
			case 36:
				return GFXLibrary.r_building_panel_bld_civ_rel_medium_church;
			case 37:
				return GFXLibrary.r_building_panel_bld_civ_rel_large_church;
			case 38:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
				return GFXLibrary.r_building_panel_bld_civ_dec_small_garden_01;
			case 49:
			case 50:
			case 51:
				return GFXLibrary.r_building_panel_bld_civ_dec_large_garden_01png;
			case 54:
			case 55:
			case 56:
			case 57:
				return GFXLibrary.r_building_panel_bld_civ_dec_small_statue_01;
			case 58:
			case 59:
				return GFXLibrary.r_building_panel_bld_civ_dec_large_statue_01;
			case 60:
				return GFXLibrary.r_building_panel_bld_civ_dec_dovecote;
			case 61:
				return GFXLibrary.r_building_panel_bld_jus_stocks;
			case 62:
				return GFXLibrary.r_building_panel_bld_jus_burning_post;
			case 63:
				return GFXLibrary.r_building_panel_bld_jus_gibbet;
			case 64:
				return GFXLibrary.r_building_panel_bld_jus_stretching_rack;
			case 65:
				return GFXLibrary.r_building_panel_bld_ent_maypole;
			case 66:
				return GFXLibrary.r_building_panel_bld_ent_dancing_bear;
			case 67:
				return GFXLibrary.r_building_panel_bld_ent_theatre;
			case 68:
				return GFXLibrary.r_building_panel_bld_ent_jesters_court;
			case 69:
				return GFXLibrary.r_building_panel_bld_ent_troubadours_arbor;
			case 70:
			case 71:
			case 72:
			case 73:
				return GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_01;
			case 74:
			case 75:
				return GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_01;
			case 78:
				return GFXLibrary.r_building_panel_bld_icon_ind_market;
			}
			return null;
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x001FA4E0 File Offset: 0x001F86E0
		private BaseImage getCastleGFX(int castlePiece)
		{
			if (castlePiece <= 21)
			{
				switch (castlePiece)
				{
				case 11:
					return GFXLibrary.r_building_miltary_lookouttower;
				case 12:
					return GFXLibrary.r_building_miltary_smalltower;
				case 13:
					return GFXLibrary.r_building_miltary_largetower;
				case 14:
					return GFXLibrary.r_building_miltary_greattower;
				default:
					if (castlePiece == 21)
					{
						return GFXLibrary.r_building_miltary_woodtower;
					}
					break;
				}
			}
			else
			{
				switch (castlePiece)
				{
				case 31:
					return GFXLibrary.r_building_miltary_guardhouse;
				case 32:
					return GFXLibrary.r_building_miltary_smelter;
				case 33:
					return GFXLibrary.r_building_miltary_woodwall;
				case 34:
					return GFXLibrary.r_building_miltary_stonewall;
				case 35:
					return GFXLibrary.r_building_miltary_moat;
				case 36:
					return GFXLibrary.r_building_miltary_killingpits;
				case 37:
					return GFXLibrary.r_building_miltary_gatehouse;
				default:
					switch (castlePiece)
					{
					case 60:
						return GFXLibrary.r_bld_icon_mil_guardhouse_2;
					case 61:
						return GFXLibrary.r_bld_icon_mil_guardhouse_3;
					case 62:
						return GFXLibrary.r_bld_icon_mil_guardhouse_4;
					case 70:
						return GFXLibrary.r_building_miltary_peasent;
					case 71:
						return GFXLibrary.r_building_miltary_swordsman;
					case 72:
						return GFXLibrary.r_building_miltary_archer;
					case 73:
						return GFXLibrary.r_building_miltary_pikemen;
					case 74:
						return GFXLibrary.r_building_miltary_catapult;
					}
					break;
				}
			}
			return null;
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x0001E79D File Offset: 0x0001C99D
		public bool isResearchOnEducationTab()
		{
			return this.lastResearchTab == 3;
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x0001E7AB File Offset: 0x0001C9AB
		private void initIndustryTab()
		{
			this.lastResearchTab = 0;
			this.initTab(ResearchData.industryResearchLayout);
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0001E7BF File Offset: 0x0001C9BF
		private void initMilitaryTab()
		{
			this.lastResearchTab = 1;
			this.initTab(ResearchData.militaryResearchLayout);
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x0001E7D3 File Offset: 0x0001C9D3
		private void initFarmingTab()
		{
			this.lastResearchTab = 2;
			this.initTab(ResearchData.farmingResearchLayout);
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x0001E7E7 File Offset: 0x0001C9E7
		private void initEducationTab()
		{
			this.lastResearchTab = 3;
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
			{
				this.initTab(ResearchData.educationResearchLayout);
				return;
			}
			this.initTab(ResearchData.educationResearchLayout2);
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x001FA600 File Offset: 0x001F8800
		private void initTab(int[] researchlist)
		{
			this.queuedResearchArea.Visible = true;
			this.currentResearchInfoBox.Create(GFXLibrary.research_tech_tree_inset_54_tall_left, GFXLibrary.research_tech_tree_inset_54_tall_mid, GFXLibrary.research_tech_tree_inset_54_tall_right);
			this.currentResearchInfoBoxRow2Text.Visible = false;
			this.currentResearchInfoBoxRow3Text.Visible = false;
			this.dragOverlay.Visible = false;
			this.dragOverlay2.Visible = true;
			this.scrollPanelImage.clearControls();
			this.scrollPanelImage.ClipRect = new Rectangle(new Point(0, 0), new Size(base.Width - 40, base.Height - 205 - 55));
			for (int i = 0; i < 30; i++)
			{
				if (this.startResearchButtons[i] == null)
				{
					this.startResearchButtons[i] = new CustomSelfDrawPanel.CSDButton();
				}
				this.startResearchButtons[i].Visible = false;
				if (this.startResearchImages[i] == null)
				{
					this.startResearchImages[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchImages[i].Visible = false;
				if (this.startResearchOpenBackground[i] == null)
				{
					this.startResearchOpenBackground[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchOpenBackground[i].Visible = false;
				if (this.startResearchHeader[i] == null)
				{
					this.startResearchHeader[i] = new CustomSelfDrawPanel.CSDLabel();
				}
				this.startResearchHeader[i].Visible = false;
				if (this.startResearchText1[i] == null)
				{
					this.startResearchText1[i] = new CustomSelfDrawPanel.CSDLabel();
				}
				this.startResearchText1[i].Visible = false;
				if (this.startResearchText2[i] == null)
				{
					this.startResearchText2[i] = new CustomSelfDrawPanel.CSDLabel();
				}
				this.startResearchText2[i].Visible = false;
				if (this.startResearchDotsBack[i] == null)
				{
					this.startResearchDotsBack[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchDotsBack[i].Visible = false;
				if (this.startResearchDots[i] == null)
				{
					this.startResearchDots[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchDots[i].Visible = false;
				if (this.startResearchDotsYellow[i] == null)
				{
					this.startResearchDotsYellow[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchDotsYellow[i].Visible = false;
				if (this.startResearchOpenResearch[i] == null)
				{
					this.startResearchOpenResearch[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchOpenResearch[i].Visible = false;
				if (this.startResearchOpenResearchOverlay[i] == null)
				{
					this.startResearchOpenResearchOverlay[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchOpenResearchOverlay[i].Visible = false;
				if (this.startResearchOpenResearchOverlayLabel[i] == null)
				{
					this.startResearchOpenResearchOverlayLabel[i] = new CustomSelfDrawPanel.CSDLabel();
				}
				this.startResearchOpenResearchOverlayLabel[i].Visible = false;
				if (this.startResearchOpenBuilding[i] == null)
				{
					this.startResearchOpenBuilding[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchOpenBuilding[i].Visible = false;
				if (this.startResearchShield[i] == null)
				{
					this.startResearchShield[i] = new CustomSelfDrawPanel.CSDImage();
				}
				this.startResearchShield[i].Visible = false;
				if (this.startResearchShieldNumber[i] == null)
				{
					this.startResearchShieldNumber[i] = new CustomSelfDrawPanel.CSDLabel();
				}
				this.startResearchShieldNumber[i].Visible = false;
			}
			if (this.lastData == null)
			{
				return;
			}
			int rank = GameEngine.Instance.World.getRank();
			int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
			int num = -1;
			int num2 = 44;
			int num3 = 34;
			int num4 = 0;
			bool flag = false;
			foreach (int num5 in researchlist)
			{
				if ((int)this.lastData.research[num5] < ResearchData.getNumLevels(num5, rank, GameEngine.Instance.LocalWorldData) && this.lastDataQueued.isResearchStepOpen(num5, (int)this.lastDataQueued.research[num5], rank, rankSubLevel, ref num, ref flag, GameEngine.Instance.LocalWorldData.EraWorld))
				{
					CustomSelfDrawPanel.CSDButton csdbutton = this.startResearchButtons[num4];
					csdbutton.Position = new Point(20, num3);
					if (this.researchAllowed || num5 != this.lastDataQueued.researchingType)
					{
						csdbutton.ImageNorm = GFXLibrary.tech_list_but_big_normal;
						csdbutton.ImageOver = GFXLibrary.tech_list_but_big_over;
						csdbutton.ImageClick = GFXLibrary.tech_list_but_big_in;
					}
					else
					{
						csdbutton.ImageNorm = GFXLibrary.tech_list_but_big_over;
						csdbutton.ImageOver = GFXLibrary.tech_list_but_big_over;
						csdbutton.ImageClick = GFXLibrary.tech_list_but_big_over;
					}
					csdbutton.Data = num5;
					csdbutton.Visible = true;
					csdbutton.Enabled = (this.researchAllowed && (int)this.lastDataQueued.research[num5] < ResearchData.getNumLevels(num5, rank, GameEngine.Instance.LocalWorldData));
					csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.researchClicked), "ResearchPanel_do_research");
					this.scrollPanelImage.addControl(csdbutton);
					CustomSelfDrawPanel.CSDImage csdimage = this.startResearchImages[num4];
					csdimage.Image = GFXLibrary.getResearchIllustration(num5);
					csdimage.Position = new Point(7, 7);
					csdimage.Visible = true;
					csdbutton.addControl(csdimage);
					CustomSelfDrawPanel.CSDLabel csdlabel = this.startResearchHeader[num4];
					csdlabel.Text = ResearchData.getResearchName(num5);
					csdlabel.Color = global::ARGBColors.Black;
					csdlabel.Position = new Point(150, 5);
					csdlabel.Size = new Size(csdbutton.Width - 150, 30);
					csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					csdlabel.Visible = true;
					csdbutton.addControl(csdlabel);
					CustomSelfDrawPanel.CSDLabel csdlabel2 = this.startResearchText1[num4];
					csdlabel2.Text = ResearchData.getDescriptionText(num5, (int)this.lastDataQueued.research[num5]);
					csdlabel2.Color = global::ARGBColors.Black;
					csdlabel2.Size = new Size(csdbutton.Width - 150, 30);
					csdlabel2.Position = new Point(150, 23);
					csdlabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					csdlabel2.Visible = true;
					csdbutton.addControl(csdlabel2);
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.startResearchText2[num4];
					csdlabel3.Text = ResearchData.getEffectText(num5, (int)this.lastDataQueued.research[num5], GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.SixthAgeWorld, GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1, GameEngine.Instance.LocalWorldData);
					csdlabel3.Color = global::ARGBColors.Black;
					csdlabel3.Size = new Size(csdbutton.Width - 150, 30);
					csdlabel3.Position = new Point(150, 53);
					csdlabel3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
					csdlabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					csdlabel3.Visible = true;
					csdbutton.addControl(csdlabel3);
					int numLevels = ResearchData.getNumLevels(num5, rank, GameEngine.Instance.LocalWorldData);
					if (numLevels <= 16)
					{
						csdimage = this.startResearchDotsBack[num4];
						switch (numLevels)
						{
						case 4:
							csdimage.Image = GFXLibrary.tech_tree_dots_black_x04;
							break;
						case 5:
							csdimage.Image = GFXLibrary.tech_tree_dots_black_x05;
							break;
						case 6:
						case 7:
						case 9:
							goto IL_7B2;
						case 8:
							csdimage.Image = GFXLibrary.tech_tree_dots_black_x08;
							break;
						case 10:
							csdimage.Image = GFXLibrary.tech_tree_dots_black_x10;
							break;
						default:
							if (numLevels != 13)
							{
								if (numLevels != 15)
								{
									goto IL_7B2;
								}
								csdimage.Image = GFXLibrary.tech_tree_dots_black_x15;
							}
							else
							{
								csdimage.Image = GFXLibrary.tech_tree_dots_black_x13;
							}
							break;
						}
						IL_7C3:
						csdimage.Position = new Point(csdbutton.Width - 10 - csdimage.Image.Width, 11);
						csdimage.Visible = true;
						csdbutton.addControl(csdimage);
						int num6 = (int)this.lastDataQueued.research[num5];
						int num7 = (int)this.lastData.research[num5];
						if (num6 > 0 && num6 != num7)
						{
							CustomSelfDrawPanel.CSDImage csdimage2 = this.startResearchDotsYellow[num4];
							csdimage2.Image = GFXLibrary.tech_tree_dots_yellow_x16;
							csdimage2.Position = new Point(0, 0);
							csdimage2.ClipRect = new Rectangle(0, 0, -2 + num6 * 10, csdimage2.Height);
							csdimage2.Visible = true;
							csdimage.addControl(csdimage2);
						}
						if (num7 > 0)
						{
							CustomSelfDrawPanel.CSDImage csdimage3 = this.startResearchDots[num4];
							csdimage3.Image = GFXLibrary.tech_tree_dots_green_x16;
							csdimage3.Position = new Point(0, 0);
							csdimage3.ClipRect = new Rectangle(0, 0, -2 + num7 * 10, csdimage3.Height);
							csdimage3.Visible = true;
							csdimage.addControl(csdimage3);
							goto IL_8D9;
						}
						goto IL_8D9;
						IL_7B2:
						csdimage.Image = GFXLibrary.tech_tree_dots_black_x16;
						goto IL_7C3;
					}
					IL_8D9:
					csdimage = this.startResearchOpenBackground[num4];
					csdimage.Image = GFXLibrary.tech_list_insets_X2;
					csdimage.Position = new Point(656, num3);
					csdimage.Visible = true;
					this.scrollPanelImage.addControl(csdimage);
					int num8 = -1;
					int num9 = -1;
					int num10 = -1;
					int openedResearch = ResearchData.getOpenedResearch(num5, (int)(this.lastDataQueued.research[num5] + 1), GameEngine.Instance.LocalWorldData.Alternate_Ruleset, ref num8, ref num9, ref num10);
					if (openedResearch >= 0)
					{
						CustomSelfDrawPanel.CSDImage csdimage4 = this.startResearchOpenResearch[num4];
						csdimage4.Image = GFXLibrary.getResearchIllustration(openedResearch);
						if (csdimage4.Image != null)
						{
							csdimage4.Tooltip = openedResearch * 1000;
							csdimage4.Position = new Point(8, 7);
							csdimage4.Visible = true;
							csdimage.addControl(csdimage4);
							this.lastDataQueued.isResearchStepOpen(openedResearch, 0, rank, rankSubLevel, ref num, ref flag, GameEngine.Instance.LocalWorldData.EraWorld);
							if (num >= 0)
							{
								CustomSelfDrawPanel.CSDImage csdimage5 = this.startResearchShield[num4];
								csdimage5.Image = GFXLibrary.ill_shield;
								csdimage5.Position = new Point(105, 2);
								csdimage5.Visible = true;
								csdimage4.addControl(csdimage5);
								CustomSelfDrawPanel.CSDLabel csdlabel4 = this.startResearchShieldNumber[num4];
								if (num >= 100)
								{
									csdlabel4.Text = (num - 100 + 1).ToString();
								}
								else
								{
									csdlabel4.Text = num.ToString();
								}
								csdlabel4.Color = global::ARGBColors.White;
								csdlabel4.Position = new Point(0, -2);
								csdlabel4.Size = csdimage5.Size;
								csdlabel4.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
								csdlabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
								csdlabel4.Visible = true;
								csdimage5.addControl(csdlabel4);
							}
							CustomSelfDrawPanel.CSDImage csdimage6 = this.startResearchOpenResearchOverlay[num4];
							csdimage6.Image = GFXLibrary.research_ill_overlay;
							csdimage6.Position = new Point(0, 40);
							csdimage6.Visible = true;
							csdimage6.Alpha = 0.5f;
							csdimage4.addControl(csdimage6);
							CustomSelfDrawPanel.CSDLabel csdlabel5 = this.startResearchOpenResearchOverlayLabel[num4];
							csdlabel5.Text = ResearchData.getResearchName(openedResearch);
							csdlabel5.Color = global::ARGBColors.White;
							csdlabel5.Position = new Point(0, 0);
							csdlabel5.Size = csdimage6.Size;
							if (Program.mySettings.LanguageIdent == "tr" && (openedResearch == 14 || openedResearch == 66 || openedResearch == 46 || openedResearch == 41 || openedResearch == 43 || openedResearch == 42))
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							}
							else if (Program.mySettings.LanguageIdent == "pl" && (openedResearch == 14 || openedResearch == 37 || openedResearch == 45 || openedResearch == 50))
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							}
							else if (Program.mySettings.LanguageIdent == "it" && (openedResearch == 17 || openedResearch == 67 || openedResearch == 41))
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							}
							else if (Program.mySettings.LanguageIdent == "pt" && (openedResearch == 0 || openedResearch == 39 || openedResearch == 17 || openedResearch == 66 || openedResearch == 64 || openedResearch == 10 || openedResearch == 43 || openedResearch == 44 || openedResearch == 45 || openedResearch == 46))
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
							}
							else if (Program.mySettings.LanguageIdent == "pt" && (openedResearch == 34 || openedResearch == 42))
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
							}
							else if ((openedResearch == 45 || openedResearch == 43) && Program.mySettings.LanguageIdent == "de")
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
							}
							else
							{
								csdlabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
							}
							csdlabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
							csdlabel5.Visible = true;
							csdimage6.addControl(csdlabel5);
						}
					}
					if (num8 > 0 || num9 > 0 || num10 > 0)
					{
						CustomSelfDrawPanel.CSDImage csdimage7 = this.startResearchOpenBuilding[num4];
						if (num8 > 0)
						{
							csdimage7.Image = this.getBuildingGFX(num8);
						}
						if (num9 > 0)
						{
							csdimage7.Image = this.getCastleGFX(num9);
						}
						if (num10 > 0)
						{
							csdimage7.Image = this.getCastleGFX(num10);
						}
						if (csdimage7.Image != null)
						{
							csdimage7.Position = new Point(197 - csdimage7.Image.Size.Width / 2, 42 - csdimage7.Image.Size.Height / 2);
							csdimage7.Visible = true;
							csdimage.addControl(csdimage7);
						}
					}
					if (num5 == 59)
					{
						ResearchPanel.TUTORIAL_artsTabPos = num3;
					}
					num4++;
					num3 += 80;
					num2 += 80;
				}
			}
			this.startResearchHeaderMain.Text = SK.Text("Research_Choose_Next", "Choose Next Research");
			this.startResearchHeaderMain.Color = global::ARGBColors.Black;
			this.startResearchHeaderMain.Position = new Point(183, 12);
			this.startResearchHeaderMain.Size = new Size(400, 60);
			this.startResearchHeaderMain.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.startResearchHeaderMain.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.scrollPanelImage.addControl(this.startResearchHeaderMain);
			this.startResearchHeaderResearchOpen.Text = SK.Text("Research_Allows", "Allows");
			this.startResearchHeaderResearchOpen.Color = global::ARGBColors.Black;
			this.startResearchHeaderResearchOpen.Position = new Point(656, 12);
			this.startResearchHeaderResearchOpen.Size = new Size(200, 60);
			this.startResearchHeaderResearchOpen.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.startResearchHeaderResearchOpen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.scrollPanelImage.addControl(this.startResearchHeaderResearchOpen);
			this.startResearchHeaderBuildingOpen.Text = SK.Text("Research_Opens", "Opens");
			this.startResearchHeaderBuildingOpen.Color = global::ARGBColors.Black;
			this.startResearchHeaderBuildingOpen.Position = new Point(813, 12);
			this.startResearchHeaderBuildingOpen.Size = new Size(200, 60);
			this.startResearchHeaderBuildingOpen.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.startResearchHeaderBuildingOpen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.scrollPanelImage.addControl(this.startResearchHeaderBuildingOpen);
			int num11 = num2;
			this.startResearchScrollBar.clearControls();
			this.mainBackgroundImage.removeControl(this.startResearchScrollBar);
			if (num2 <= this.scrollPanelImage.ClipRect.Height)
			{
				num2 = this.scrollPanelImage.ClipRect.Height;
				this.startResearchScrollBar.Visible = false;
			}
			else
			{
				this.startResearchScrollBar.Visible = true;
				this.startResearchScrollBar.Position = new Point(base.Width - 20 - 10 - 32, 255);
				this.startResearchScrollBar.Size = new Size(32, this.scrollPanelImage.ClipRect.Height - 13 - 13);
				this.mainBackgroundImage.addControl(this.startResearchScrollBar);
				this.startResearchScrollBar.Value = 0;
				this.startResearchScrollBar.Max = num11 - this.scrollPanelImage.ClipRect.Height;
				this.startResearchScrollBar.NumVisibleLines = this.scrollPanelImage.ClipRect.Height;
				this.startResearchScrollBar.OffsetTL = new Point(1, 5);
				this.startResearchScrollBar.OffsetBR = new Point(0, -10);
				this.startResearchScrollBar.Create(GFXLibrary.scroll_inset_top, GFXLibrary.scroll_inset_mid, GFXLibrary.scroll_inset_bottom, GFXLibrary.scroll_thumb_top, GFXLibrary.scroll_thumb_mid, GFXLibrary.scroll_thumb_bottom);
				this.startResearchScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarMoved));
			}
			this.scrollPanelImage.Size = new Size(this.scrollPanelImage.Size.Width, num2);
			this.scrollPanelImage.Position = new Point(20, 242);
			this.scrollPanelImage.invalidate();
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x001FB7BC File Offset: 0x001F99BC
		private void scrollBarMoved()
		{
			int value = this.startResearchScrollBar.Value;
			this.scrollPanelImage.Position = new Point(this.scrollPanelImage.Position.X, 242 - value);
			this.scrollPanelImage.ClipRect = new Rectangle(this.scrollPanelImage.ClipRect.X, value, this.scrollPanelImage.ClipRect.Width, this.scrollPanelImage.ClipRect.Height);
			this.scrollPanelImage.invalidate();
			this.scrollPanelBottomMiddleOverlay.invalidate();
			this.scrollPanelBottomLeftOverlay.invalidate();
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x0001E819 File Offset: 0x0001CA19
		private void listWindowMouseWheel(int delta)
		{
			if (this.startResearchScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.startResearchScrollBar.scrollDown();
					return;
				}
				if (delta > 0)
				{
					this.startResearchScrollBar.scrollUp();
				}
			}
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x001FB86C File Offset: 0x001F9A6C
		private void tabClicked()
		{
			this.selectedQueueSlot = -1;
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.lastTab)
				{
					this.manageTabs(csdbutton.Data);
				}
			}
		}

		// Token: 0x06002973 RID: 10611 RVA: 0x001FB8B0 File Offset: 0x001F9AB0
		private void tabModeClicked()
		{
			this.selectedQueueSlot = -1;
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (csdbutton.Data != this.tabType)
				{
					this.tabType = csdbutton.Data;
					this.manageTabs(this.lastTab);
				}
			}
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x001FB900 File Offset: 0x001F9B00
		private void manageTabs(int tab)
		{
			this.lastTab = tab;
			this.tab1Button.ImageNorm = GFXLibrary.tech_tree_tab_01_normal;
			this.tab1Button.ImageOver = GFXLibrary.tech_tree_tab_01_highlight;
			this.tab2Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab2Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab3Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab3Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab4Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab4Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			this.tab5Button.ImageNorm = GFXLibrary.tech_tree_tab_normal;
			this.tab5Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
			if (this.tabType == 0)
			{
				this.tabModeListButton.ImageNorm = GFXLibrary.tech_tree_tab_list_highlight;
				this.tabModeListButton.ImageOver = GFXLibrary.tech_tree_tab_list_highlight;
				this.tabModeTreeButton.ImageNorm = GFXLibrary.tech_tree_tab_tree_normal;
				this.tabModeTreeButton.ImageOver = GFXLibrary.tech_tree_tab_tree_highlight;
			}
			else
			{
				this.tabModeListButton.ImageNorm = GFXLibrary.tech_tree_tab_list_normal;
				this.tabModeListButton.ImageOver = GFXLibrary.tech_tree_tab_list_highlight;
				this.tabModeTreeButton.ImageNorm = GFXLibrary.tech_tree_tab_tree_highlight;
				this.tabModeTreeButton.ImageOver = GFXLibrary.tech_tree_tab_tree_highlight;
			}
			this.tab1Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab2Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab3Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab4Button.Text.Color = Color.FromArgb(205, 157, 49);
			this.tab5Button.Text.Color = Color.FromArgb(205, 157, 49);
			switch (tab)
			{
			case 0:
				this.tab1Button.ImageNorm = GFXLibrary.tech_tree_tab_01_highlight;
				this.tab1Button.ImageOver = GFXLibrary.tech_tree_tab_01_highlight;
				this.tab1Button.Text.Color = global::ARGBColors.White;
				if (this.tabType == 0)
				{
					this.initIndustryTab();
					return;
				}
				this.initExploreTab(0);
				return;
			case 1:
				this.tab2Button.ImageNorm = GFXLibrary.tech_tree_tab_highlight;
				this.tab2Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
				this.tab2Button.Text.Color = global::ARGBColors.White;
				if (this.tabType == 0)
				{
					this.initMilitaryTab();
					return;
				}
				this.initExploreTab(1);
				return;
			case 2:
				this.tab3Button.ImageNorm = GFXLibrary.tech_tree_tab_highlight;
				this.tab3Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
				this.tab3Button.Text.Color = global::ARGBColors.White;
				if (this.tabType == 0)
				{
					this.initFarmingTab();
					return;
				}
				this.initExploreTab(2);
				return;
			case 3:
				this.tab4Button.ImageNorm = GFXLibrary.tech_tree_tab_highlight;
				this.tab4Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
				this.tab4Button.Text.Color = global::ARGBColors.White;
				if (this.tabType == 0)
				{
					this.initEducationTab();
					return;
				}
				this.initExploreTab(3);
				return;
			case 4:
				this.tab5Button.ImageNorm = GFXLibrary.tech_tree_tab_highlight;
				this.tab5Button.ImageOver = GFXLibrary.tech_tree_tab_highlight;
				this.tab5Button.Text.Color = global::ARGBColors.White;
				this.initExploreTab(0);
				return;
			default:
				return;
			}
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x001FBCF8 File Offset: 0x001F9EF8
		private void cancelResearchClick()
		{
			if (this.selectedQueueSlot < 0 || (this.lastData != null && this.lastData.research_queueEntries != null && this.selectedQueueSlot < this.lastData.research_queueEntries.Length))
			{
				this.closeCancelResearchPopup();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.cancelResearchPopup = new MyMessageBoxPopUp();
				this.cancelResearchPopup.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("Research_Cancel_Research", "Cancel Research?"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelResearch));
				this.cancelResearchPopup.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x0001E847 File Offset: 0x0001CA47
		private void closeCancelResearchPopup()
		{
			if (this.cancelResearchPopup != null)
			{
				if (this.cancelResearchPopup.Created)
				{
					this.cancelResearchPopup.Close();
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.cancelResearchPopup = null;
			}
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x001FBDA4 File Offset: 0x001F9FA4
		private void cancelResearch()
		{
			if (this.selectedQueueSlot < 0)
			{
				GameEngine.Instance.World.doResearch(-1);
			}
			else if (this.lastData != null && this.lastData.research_queueEntries != null && this.selectedQueueSlot < this.lastData.research_queueEntries.Length)
			{
				GameEngine.Instance.World.CancelQueuedResearch(this.lastData.research_queueEntries[this.selectedQueueSlot], this.selectedQueueSlot);
			}
			this.selectedQueueSlot = -1;
			InterfaceMgr.Instance.closeGreyOut();
			this.cancelResearchPopup.Close();
		}

		// Token: 0x06002978 RID: 10616 RVA: 0x0001E87A File Offset: 0x0001CA7A
		private void backgroundClick()
		{
			this.selectedQueueSlot = -1;
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x0001E883 File Offset: 0x0001CA83
		private void buyPointClick()
		{
			this.selectedQueueSlot = -1;
			GameEngine.Instance.World.buyResearchPoint();
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x001FBE3C File Offset: 0x001FA03C
		private void researchClicked()
		{
			this.selectedQueueSlot = -1;
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				GameEngine.Instance.World.doResearch(data);
			}
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x001FBE7C File Offset: 0x001FA07C
		public void update(bool fullTick)
		{
			this.cardbar.update();
			this.tooltipToShow = -1;
			int num = 0;
			if (base.getToolTip(ref num))
			{
				this.tooltipToShow = num;
			}
			if (fullTick && this.lastData != null)
			{
				this.updateBasedOnResearchData(this.lastData, false);
			}
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x001FBEC8 File Offset: 0x001FA0C8
		private void applyData(ResearchData data)
		{
			int num = -1;
			int level = 0;
			this.researchAllowed = true;
			int num2 = data.research_points;
			if (data.research_queueEntries != null)
			{
				num2 -= data.research_queueEntries.Length;
			}
			if (data.researchingType >= 0)
			{
				if (!data.canDoMoreResearch(GameEngine.Instance.World.isAccountPremium()))
				{
					this.researchAllowed = false;
				}
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (this.selectedQueueSlot >= 0 && (data.research_queueEntries == null || this.selectedQueueSlot >= data.research_queueEntries.Length))
				{
					this.selectedQueueSlot = -1;
				}
				if (this.selectedQueueSlot < 0)
				{
					TimeSpan timeSpan = data.research_completionTime - currentServerTime;
					int num3 = (int)(timeSpan.TotalSeconds + 0.5);
					if (num3 < 0)
					{
						num3 = 0;
					}
					this.timeProgressText.Text = SK.Text("Research_Completed_In", "Completed In") + " : " + VillageMap.createBuildTimeString(num3);
					this.timeProgressText.Visible = true;
					if (GameEngine.Instance.World.isResearchLagging())
					{
						CustomSelfDrawPanel.CSDLabel csdlabel = this.timeProgressText;
						csdlabel.Text = csdlabel.Text + " (" + SK.Text("Research_Lagging", "Research Overdue, Please wait") + ")";
					}
					TimeSpan timeSpan2 = data.calcResearchTime(data.research_pointCount - 1, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
					if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
					{
						timeSpan2 = new TimeSpan(timeSpan2.Ticks / 2L);
					}
					int num4 = (int)timeSpan2.TotalSeconds;
					if (num4 < 1)
					{
						num4 = 1;
					}
					if (num4 == 30 && GameEngine.Instance.World.getTutorialStage() == 5)
					{
						num4 = 11;
					}
					double num5 = timeSpan.TotalSeconds;
					if (num5 < 0.0)
					{
						num5 = 0.0;
					}
					num5 = (double)num4 - num5;
					if (num5 < 0.0)
					{
						num5 = 0.0;
					}
					this.timeProgressBar.setValues(num5, (double)num4);
					this.currentResearchCancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
					num = data.researchingType;
					level = (int)data.research[data.researchingType];
				}
				else
				{
					TimeSpan t = data.research_completionTime - currentServerTime;
					if (this.selectedQueueSlot > 0)
					{
						for (int i = 0; i < this.selectedQueueSlot; i++)
						{
							TimeSpan t2 = data.calcResearchTime(data.research_pointCount + i, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
							if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
							{
								t2 = new TimeSpan(t2.Ticks / 2L);
							}
							t += t2;
						}
					}
					int num6 = (int)(t.TotalSeconds + 0.5);
					if (num6 < 0)
					{
						num6 = 0;
					}
					this.timeProgressText.Text = SK.Text("Research_Starts_In", "Starts In") + " : " + VillageMap.createBuildTimeString(num6);
					this.timeProgressText.Visible = true;
					this.timeProgressBar.setValues(0.0, 0.0);
					num = data.research_queueEntries[this.selectedQueueSlot];
					level = 0;
					this.currentResearchCancelButton.Text.Text = SK.Text("Research_Remove_From_Queue", "Remove From Queue");
				}
				this.currentResearchCancelButton.Enabled = true;
			}
			else
			{
				TimeSpan timeSpan3 = data.calcResearchTime(data.research_pointCount, GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					timeSpan3 = new TimeSpan(timeSpan3.Ticks / 2L);
				}
				int secsLeft = (int)timeSpan3.TotalSeconds;
				this.currentResearchCancelButton.Enabled = false;
				this.timeProgressText.Text = SK.Text("Research_Next_Duration", "Next Research Duration") + " : " + VillageMap.createBuildTimeString(secsLeft);
				this.timeProgressBar.setValues(0.0, 0.0);
			}
			if (this.tooltipToShow >= 0)
			{
				num = this.tooltipToShow / 1000;
				level = this.tooltipToShow % 1000 - 1;
			}
			if (num >= 0)
			{
				this.currentResearchInfoBoxHeadingText.Visible = true;
				this.currentResearchInfoBoxHeadingText.Text = ResearchData.getResearchName(num);
				this.currentResearchText.Text = this.currentResearchInfoBoxHeadingText.Text;
				this.currentResearchText.Visible = true;
				this.currentResearchImage.Image = GFXLibrary.getResearchIllustration(num);
				if (this.currentResearchImage.Image != null)
				{
					this.currentResearchImage.Visible = true;
				}
				else
				{
					this.currentResearchImage.Visible = false;
				}
				this.currentResearchInfoBoxRow1Text.Text = ResearchData.getDescriptionText(num, level);
				this.currentResearchInfoBoxRow2Text.Text = "";
				this.currentResearchInfoBoxRow3Text.Text = ResearchData.getEffectText(num, level, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.SixthAgeWorld, GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1, GameEngine.Instance.LocalWorldData);
				this.currentResearchInfoBoxRow1Text.Visible = true;
				this.currentResearchInfoBoxRow2Text.Visible = this.dragOverlay.Visible;
				this.currentResearchInfoBoxRow3Text.Visible = this.dragOverlay.Visible;
				this.currentResearchBackgroundImage.Visible = true;
				this.currentResearchBackgroundImage2.Visible = false;
				if (Program.mySettings.LanguageIdent == "tr" && (num == 14 || num == 66 || num == 46 || num == 41 || num == 43 || num == 42))
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else if (Program.mySettings.LanguageIdent == "pl" && (num == 14 || num == 37 || num == 45 || num == 50))
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else if (Program.mySettings.LanguageIdent == "it" && (num == 17 || num == 67 || num == 41))
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else if (Program.mySettings.LanguageIdent == "pt" && (num == 0 || num == 39 || num == 17 || num == 66 || num == 64 || num == 10 || num == 43 || num == 44 || num == 45 || num == 46))
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				}
				else if (Program.mySettings.LanguageIdent == "pt" && (num == 34 || num == 42))
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				}
				else
				{
					this.currentResearchText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				}
			}
			else
			{
				this.currentResearchBackgroundImage2.Visible = true;
				this.currentResearchBackgroundImage.Visible = false;
				this.currentResearchInfoBoxRow1Text.Visible = false;
				this.currentResearchInfoBoxRow2Text.Visible = false;
				this.currentResearchInfoBoxRow3Text.Visible = false;
				this.currentResearchText.Visible = false;
				this.currentResearchImage.Visible = false;
				this.currentResearchInfoBoxHeadingText.Text = SK.Text("Research_No_Current", "No current research");
			}
			this.pointsText.Text = SK.Text("Research_Research_Points", "Research Points") + " : " + num2.ToString();
			NumberFormatInfo nfi = GameEngine.NFI;
			if (num2 <= 0)
			{
				this.researchAllowed = false;
			}
			double num7 = data.calcPointGoldCost(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData);
			this.buyPointText.Text = num7.ToString("N", nfi);
			if (num7 <= GameEngine.Instance.World.getCurrentGold())
			{
				this.buyPointButton.Enabled = true;
			}
			else
			{
				this.buyPointButton.Enabled = false;
			}
			this.queuedResearchImage1.Visible = false;
			this.queuedResearchImage2.Visible = false;
			this.queuedResearchImage3.Visible = false;
			this.queuedResearchImage4.Visible = false;
			this.queuedResearchImage5.Visible = false;
			this.queuedResearchImage6.Visible = false;
			this.queuedResearchImage7.Visible = false;
			this.queuedResearchButton1.Enabled = false;
			this.queuedResearchButton2.Enabled = false;
			this.queuedResearchButton3.Enabled = false;
			this.queuedResearchButton4.Enabled = false;
			this.queuedResearchButton5.Enabled = false;
			this.queuedResearchButton6.Enabled = false;
			this.queuedResearchButton7.Enabled = false;
			if (data.research_queueEntries != null && data.research_queueEntries.Length != 0 && data.researchingType >= 0)
			{
				for (int j = 0; j < data.research_queueEntries.Length; j++)
				{
					CustomSelfDrawPanel.CSDImage csdimage = null;
					CustomSelfDrawPanel.CSDButton csdbutton = null;
					switch (j)
					{
					case 0:
						csdimage = this.queuedResearchImage1;
						csdbutton = this.queuedResearchButton1;
						break;
					case 1:
						csdimage = this.queuedResearchImage2;
						csdbutton = this.queuedResearchButton2;
						break;
					case 2:
						csdimage = this.queuedResearchImage3;
						csdbutton = this.queuedResearchButton3;
						break;
					case 3:
						csdimage = this.queuedResearchImage4;
						csdbutton = this.queuedResearchButton4;
						break;
					case 4:
						csdimage = this.queuedResearchImage5;
						csdbutton = this.queuedResearchButton5;
						break;
					case 5:
						csdimage = this.queuedResearchImage6;
						csdbutton = this.queuedResearchButton6;
						break;
					case 6:
						csdimage = this.queuedResearchImage7;
						csdbutton = this.queuedResearchButton7;
						break;
					}
					csdimage.Visible = true;
					csdimage.Image = GFXLibrary.getResearchIllustration(data.research_queueEntries[j]);
					csdimage.Size = new Size(csdimage.Size.Width / 2, csdimage.Size.Height / 2);
					csdimage.CustomTooltipID = 302;
					csdimage.CustomTooltipData = j;
					csdbutton.Enabled = true;
					csdbutton.ImageNorm = GFXLibrary.research_border_research_ill_normal;
					csdbutton.ImageOver = GFXLibrary.research_border_research_ill_over;
					csdbutton.ImageClick = GFXLibrary.research_border_research_ill_over;
					csdbutton.CustomTooltipID = 302;
					csdbutton.CustomTooltipData = j;
				}
			}
			if (this.selectedQueueSlot >= 0)
			{
				CustomSelfDrawPanel.CSDButton csdbutton2 = null;
				switch (this.selectedQueueSlot)
				{
				case 0:
					csdbutton2 = this.queuedResearchButton1;
					break;
				case 1:
					csdbutton2 = this.queuedResearchButton2;
					break;
				case 2:
					csdbutton2 = this.queuedResearchButton3;
					break;
				case 3:
					csdbutton2 = this.queuedResearchButton4;
					break;
				case 4:
					csdbutton2 = this.queuedResearchButton5;
					break;
				case 5:
					csdbutton2 = this.queuedResearchButton6;
					break;
				case 6:
					csdbutton2 = this.queuedResearchButton7;
					break;
				}
				csdbutton2.ImageNorm = GFXLibrary.border_research_ill_selected_normal;
				csdbutton2.ImageOver = GFXLibrary.border_research_ill_selected_normal;
				csdbutton2.ImageClick = GFXLibrary.border_research_ill_selected_normal;
			}
			if (GameEngine.Instance.World.isAccountPremium())
			{
				this.queuedResearchNoPremiumText.Visible = false;
				return;
			}
			this.queuedResearchNoPremiumText.Visible = true;
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x001FCA38 File Offset: 0x001FAC38
		public void updateBasedOnResearchData(ResearchData data, bool localForce)
		{
			if (data == null)
			{
				return;
			}
			this.lastData = data;
			this.lastDataQueued = this.lastData;
			if (this.lastData.researchingType >= 0)
			{
				this.lastDataQueued = data.copyAndAdd(data.researchingType, false);
				if (data.research_queueEntries != null)
				{
					int[] research_queueEntries = data.research_queueEntries;
					foreach (int researchToAdd in research_queueEntries)
					{
						this.lastDataQueued = this.lastDataQueued.copyAndAdd(researchToAdd, true);
					}
				}
			}
			this.applyData(data);
			if (this.lastData != data || this.forceUpdate || localForce)
			{
				int value = this.startResearchScrollBar.Value;
				if (!this.startResearchScrollBar.Visible)
				{
					value = 0;
				}
				this.init();
				this.forceUpdate = false;
				this.applyData(data);
				this.startResearchScrollBar.Value = value;
				this.scrollBarMoved();
			}
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x001FCB14 File Offset: 0x001FAD14
		private void queuedResearchClick()
		{
			CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
			if (clickedControl != null)
			{
				int num = this.selectedQueueSlot = clickedControl.Data;
			}
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x0001E89B File Offset: 0x0001CA9B
		private void ResearchPanel2_SizeChanged(object sender, EventArgs e)
		{
			this.updateBasedOnResearchData(this.lastData, true);
			base.Invalidate();
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x001FCB3C File Offset: 0x001FAD3C
		private void initExploreTab(int mode)
		{
			this.queuedResearchArea.Visible = false;
			this.currentResearchInfoBox.Create(GFXLibrary.tech_tree_inset_tall_left, GFXLibrary.tech_tree_inset_tall_mid, GFXLibrary.tech_tree_inset_tall_right);
			this.scrollPanelImage.clearControls();
			this.startResearchScrollBar.clearControls();
			this.mainBackgroundImage.removeControl(this.startResearchScrollBar);
			this.dragOverlay.Visible = true;
			this.dragOverlay2.Visible = false;
			if (!this.rowsCreated)
			{
				this.rowsCreated = true;
				this.createRows(0, 0, 1, 1, this.industryLayout, this.industryRows, 21, 18);
				this.createRows(0, 0, 1, 1, this.farmingLayout, this.farmingRows, 13, 17);
				this.createRows(0, 0, 1, 1, this.militaryLayout, this.militaryRows, 24, 30);
				this.createRows(0, 0, 1, 1, this.educationLayout, this.educationRows, 27, 26);
				this.createRows(0, 0, 1, 1, this.educationLayout2, this.educationRows2, 26, 26);
			}
			this.resetImageCache();
			this.resetLabelCache();
			switch (mode)
			{
			case 0:
				this.scrollPanelImage.Size = new Size(2780, 2390);
				this.updateRows(0, 0, 1, 1, this.industryLayout, this.industryRows, 21);
				break;
			case 1:
			{
				int num = 20;
				num = ((GameEngine.Instance.World.getRank() != 22) ? (num - 2) : (num + 5));
				this.scrollPanelImage.Size = new Size(num * 150 + 80, 2720);
				this.updateRows(0, 0, 1, 1, this.militaryLayout, this.militaryRows, 24);
				break;
			}
			case 2:
				this.scrollPanelImage.Size = new Size(2630, 1510);
				this.updateRows(0, 0, 1, 1, this.farmingLayout, this.farmingRows, 13);
				break;
			case 3:
				this.scrollPanelImage.Size = new Size(3980, 3050);
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
				{
					this.updateRows(0, 0, 1, 1, this.educationLayout, this.educationRows, 27);
				}
				else
				{
					this.updateRows(0, 0, 1, 1, this.educationLayout2, this.educationRows2, 26);
				}
				break;
			}
			this.realScrollImageSize = this.scrollPanelImage.Size;
			double windowScale = this.m_windowScale;
			this.scrollPanelImage.setChildrensScale(windowScale);
			this.scrollPanelImage.Position = new Point(20, 242);
			this.scrollPanelImage.ClipRect = new Rectangle(new Point(0, 0), new Size(base.Width - 40, base.Height - 205 - 55));
			int num2 = 0;
			int num3 = 0;
			this.lastScrollXPos = 0;
			this.lastScrollYPos = 0;
			this.scrollPanelImage.Position = new Point(20 - num2, 242 - num3);
			this.scrollPanelImage.ClipRect = new Rectangle(this.scrollPanelImage.ClipRect.X + num2, this.scrollPanelImage.ClipRect.Y + num3, this.scrollPanelImage.ClipRect.Width, this.scrollPanelImage.ClipRect.Height);
			this.dragWindowMouseWheel(0);
			base.Invalidate();
		}

		// Token: 0x06002981 RID: 10625 RVA: 0x001FCEAC File Offset: 0x001FB0AC
		private void windowDragged()
		{
			int num = -this.dragOverlay.XDiff;
			int num2 = -this.dragOverlay.YDiff;
			num *= 2;
			num2 *= 2;
			if (this.scrollPanelImage.ClipRect.X + num < 0)
			{
				num = -this.scrollPanelImage.ClipRect.X;
			}
			if (this.scrollPanelImage.ClipRect.Y + num2 < 0)
			{
				num2 = -this.scrollPanelImage.ClipRect.Y;
			}
			double windowScale = this.m_windowScale;
			int num3 = (int)((double)this.scrollPanelImage.Size.Width * windowScale);
			int num4 = (int)((double)this.scrollPanelImage.Size.Height * windowScale);
			if (this.scrollPanelImage.ClipRect.X + num > num3 - this.scrollPanelImage.ClipRect.Width)
			{
				num -= this.scrollPanelImage.ClipRect.X + num - (num3 - this.scrollPanelImage.ClipRect.Width);
			}
			if (this.scrollPanelImage.ClipRect.Y + num2 > num4 - this.scrollPanelImage.ClipRect.Height)
			{
				num2 -= this.scrollPanelImage.ClipRect.Y + num2 - (num4 - this.scrollPanelImage.ClipRect.Height);
			}
			this.scrollPanelImage.Position = new Point(this.scrollPanelImage.Position.X - num, this.scrollPanelImage.Position.Y - num2);
			this.scrollPanelImage.ClipRect = new Rectangle(this.scrollPanelImage.ClipRect.X + num, this.scrollPanelImage.ClipRect.Y + num2, this.scrollPanelImage.ClipRect.Width, this.scrollPanelImage.ClipRect.Height);
			this.scrollPanelImage.invalidate();
			this.lastScrollXPos = (int)((double)(-(double)(this.scrollPanelImage.Position.X - 20) + this.scrollPanelImage.ClipRect.Width / 2) / windowScale);
			this.lastScrollYPos = (int)((double)(-(double)(this.scrollPanelImage.Position.Y - 187 - 55) + this.scrollPanelImage.ClipRect.Height / 2) / windowScale);
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x0001E8B0 File Offset: 0x0001CAB0
		private void dragWindowMouseOver()
		{
			CursorManager.SetCursor(CursorManager.CursorType.Hand, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x0001E8C2 File Offset: 0x0001CAC2
		private void dragWindowMouseLeave()
		{
			CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x001FD154 File Offset: 0x001FB354
		private void dragWindowMouseWheel(int delta)
		{
			double windowScale = this.m_windowScale;
			if (delta < 0)
			{
				if (this.m_windowScaleNotch > 0)
				{
					this.m_windowScaleNotch--;
				}
			}
			else if (delta > 0 && this.m_windowScaleNotch < this.windowScalingValues.Length - 1)
			{
				this.m_windowScaleNotch++;
			}
			this.m_windowScale = this.windowScalingValues[this.m_windowScaleNotch];
			double num = (double)this.realScrollImageSize.Width * this.m_windowScale;
			double num2 = (double)this.realScrollImageSize.Height * this.m_windowScale;
			if (num < (double)this.scrollPanelImage.ClipRect.Width)
			{
				this.scrollPanelImage.Size = new Size((int)((double)this.scrollPanelImage.ClipRect.Width / this.m_windowScale), this.scrollPanelImage.Size.Height);
			}
			else
			{
				this.scrollPanelImage.Size = new Size(this.realScrollImageSize.Width, this.scrollPanelImage.Size.Height);
			}
			if (num2 < (double)this.scrollPanelImage.ClipRect.Height)
			{
				this.scrollPanelImage.Size = new Size(this.scrollPanelImage.Size.Width, (int)((double)this.scrollPanelImage.ClipRect.Height / this.m_windowScale));
			}
			else
			{
				this.scrollPanelImage.Size = new Size(this.scrollPanelImage.Size.Width, this.realScrollImageSize.Height);
			}
			if (windowScale != this.m_windowScale)
			{
				this.rescaleWindow(windowScale, this.m_windowScale);
			}
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x001FD30C File Offset: 0x001FB50C
		private void rescaleWindow(double oldScale, double newScale)
		{
			this.scrollPanelImage.setChildrensScale(newScale);
			int num = (int)((double)(-(double)(this.scrollPanelImage.Position.X - 20) + this.scrollPanelImage.ClipRect.Width / 2) / oldScale);
			int num2 = (int)((double)(-(double)(this.scrollPanelImage.Position.Y - 187 - 55) + this.scrollPanelImage.ClipRect.Height / 2) / oldScale);
			this.lastScrollXPos = num;
			this.lastScrollYPos = num2;
			this.scrollPanelImage.ClipRect = new Rectangle(new Point(0, 0), new Size(base.Width - 40, base.Height - 205 - 55));
			int num3 = (int)((double)num * newScale) - this.scrollPanelImage.ClipRect.Width / 2;
			int num4 = (int)((double)num2 * newScale) - this.scrollPanelImage.ClipRect.Height / 2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if ((double)num3 > (double)this.scrollPanelImage.Size.Width * newScale - (double)this.scrollPanelImage.ClipRect.Width)
			{
				num3 = (int)((double)this.scrollPanelImage.Size.Width * newScale) - this.scrollPanelImage.ClipRect.Width - 1;
			}
			if ((double)num4 > (double)this.scrollPanelImage.Size.Height * newScale - (double)this.scrollPanelImage.ClipRect.Height)
			{
				num3 = (int)((double)this.scrollPanelImage.Size.Height * newScale) - this.scrollPanelImage.ClipRect.Height - 1;
			}
			this.scrollPanelImage.Position = new Point(20 - num3, 242 - num4);
			this.scrollPanelImage.ClipRect = new Rectangle(this.scrollPanelImage.ClipRect.X + num3, this.scrollPanelImage.ClipRect.Y + num4, this.scrollPanelImage.ClipRect.Width, this.scrollPanelImage.ClipRect.Height);
			this.scrollPanelImage.invalidate();
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x001FD568 File Offset: 0x001FB768
		private void createRows(int startColumn, int startRow, int dx, int dy, int[] layout, CustomSelfDrawPanel.CSDImage[][] rows, int numRows, int numColumns)
		{
			GameEngine.Instance.World.getRank();
			for (int i = 0; i < numRows; i++)
			{
				int num = layout[i * 2];
				int num2 = layout[i * 2 + 1];
				int num3 = 1;
				if (num >= 0)
				{
					num3 += ResearchData.getNumLevels(num, 22, GameEngine.Instance.LocalWorldData);
				}
				int y = (i * dy + startRow) * 110 + 40;
				rows[i] = new CustomSelfDrawPanel.CSDImage[numColumns];
				for (int j = 0; j < num3; j++)
				{
					int x = ((j + num2) * dx + startColumn) * 150 + 40;
					CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
					csdimage.Position = new Point(x, y);
					rows[i][j + num2] = csdimage;
					if (j == 0)
					{
						csdimage.Data = 0;
						if (num2 != 0)
						{
							if (num2 == 1)
							{
								x = ((j - 1 + num2) * dx + startColumn) * 150 + 40;
								CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
								csdimage2.Position = new Point(x, y);
								rows[i][j - 1 + num2] = csdimage2;
								for (int k = i - 1; k > 0; k--)
								{
									if (rows[k][j - 1 + num2] != null)
									{
										break;
									}
									int y2 = (k * dy + startRow) * 110 + 40;
									CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
									csdimage3.Position = new Point(x, y2);
									csdimage3.Data = 1;
									rows[k][j - 1 + num2] = csdimage3;
								}
							}
							else
							{
								for (int l = i - 1; l > 0; l--)
								{
									if (rows[l][j + num2] != null)
									{
										break;
									}
									int y3 = (l * dy + startRow) * 110 + 40;
									CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
									csdimage4.Position = new Point(x, y3);
									csdimage4.Data = 1;
									rows[l][j + num2] = csdimage4;
								}
							}
						}
					}
					else
					{
						csdimage.Data = 2;
					}
				}
			}
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x001FD73C File Offset: 0x001FB93C
		private void updateRows(int startColumn, int startRow, int dx, int dy, int[] layout, CustomSelfDrawPanel.CSDImage[][] rows, int numRows)
		{
			int rank = GameEngine.Instance.World.getRank();
			int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
			Font font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			Font font2 = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			Font font3 = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			Font font4 = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
			for (int i = 0; i < numRows; i++)
			{
				int num = layout[i * 2];
				int num2 = layout[i * 2 + 1];
				int num3 = 1;
				if (num >= 0)
				{
					num3 += ResearchData.getNumLevels(num, rank, GameEngine.Instance.LocalWorldData);
				}
				for (int j = 0; j < num3; j++)
				{
					CustomSelfDrawPanel.CSDImage csdimage = rows[i][j + num2];
					csdimage.clearControls();
					this.scrollPanelImage.addControl(csdimage);
					if (j == 0)
					{
						if (num2 == 0)
						{
							csdimage.Image = this.getIllBack(dx, dy, 0, 0, 1, 0, -1);
							CustomSelfDrawPanel.CSDImage nextImage = this.getNextImage();
							nextImage.Position = new Point(3, 7);
							string text = "";
							switch (num)
							{
							case -4:
								nextImage.Image = GFXLibrary.research_ill_education;
								text = SK.Text("Research_Education", "Education");
								break;
							case -3:
								nextImage.Image = GFXLibrary.research_ill_military;
								text = SK.Text("Research_Military", "Military");
								break;
							case -2:
								nextImage.Image = GFXLibrary.research_ill_farming;
								text = SK.Text("Research_Farming", "Farming");
								break;
							case -1:
								nextImage.Image = GFXLibrary.research_ill_industry;
								text = SK.Text("Research_Industry", "Industry");
								break;
							}
							csdimage.addControl(nextImage);
							CustomSelfDrawPanel.CSDLabel nextLabel = this.getNextLabel();
							nextLabel.Text = text;
							nextLabel.Color = global::ARGBColors.Black;
							nextLabel.Position = new Point(6, 71);
							nextLabel.Size = new Size(135, 30);
							nextLabel.Font = font;
							nextLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
							csdimage.addControl(nextLabel);
						}
						else
						{
							csdimage.Tooltip = num * 1000;
							int num4 = 1;
							int num5 = -1;
							bool flag = false;
							int num6 = -1;
							bool flag2 = false;
							bool flag3 = false;
							if (!this.lastDataQueued.isResearchStepOpen(num, j, rank, rankSubLevel, ref num5, ref flag, GameEngine.Instance.LocalWorldData.EraWorld))
							{
								num4 = 2;
							}
							else if (!this.lastData.isResearchStepOpen(num, j, rank, rankSubLevel, ref num6, ref flag2, GameEngine.Instance.LocalWorldData.EraWorld))
							{
								flag3 = true;
							}
							if (num2 == 1)
							{
								bool flag4 = false;
								if (this.lastDataQueued.research[num] > 0 && this.lastData.research[num] == 0)
								{
									flag4 = true;
								}
								if (flag4)
								{
									csdimage.Image = GFXLibrary.ill_back_yline_0101;
								}
								else
								{
									csdimage.Image = this.getIllBack(dx, dy, 0, 1, 0, num4, num);
								}
							}
							else if (flag3)
							{
								csdimage.Image = GFXLibrary.ill_back_yline_1100;
							}
							else
							{
								csdimage.Image = this.getIllBack(dx, dy, 1, 0, 0, num4, num);
							}
							CustomSelfDrawPanel.CSDImage nextImage2 = this.getNextImage();
							nextImage2.Image = GFXLibrary.getResearchIllustration(num);
							nextImage2.Position = new Point(3, 7);
							csdimage.addControl(nextImage2);
							if (num4 != 2)
							{
								CustomSelfDrawPanel.CSDImage nextImage3 = this.getNextImage();
								if (!flag3)
								{
									nextImage3.Image = GFXLibrary.ill_back_green_textback;
								}
								else
								{
									nextImage3.Image = GFXLibrary.ill_back_yellow_textback;
								}
								nextImage3.Position = new Point(4, 68);
								csdimage.addControl(nextImage3);
							}
							else if (num5 > 0)
							{
								CustomSelfDrawPanel.CSDImage nextImage4 = this.getNextImage();
								nextImage4.Image = GFXLibrary.ill_shield;
								nextImage4.Position = new Point(105, 2);
								nextImage4.Visible = true;
								nextImage2.addControl(nextImage4);
								CustomSelfDrawPanel.CSDLabel nextLabel2 = this.getNextLabel();
								if (num5 >= 100)
								{
									nextLabel2.Text = (num5 - 100 + 1).ToString();
								}
								else
								{
									nextLabel2.Text = num5.ToString();
								}
								nextLabel2.Color = global::ARGBColors.White;
								nextLabel2.Position = new Point(0, -2);
								nextLabel2.Size = nextImage4.Size;
								nextLabel2.Font = font2;
								nextLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
								nextLabel2.Visible = true;
								nextImage4.addControl(nextLabel2);
							}
							int num7 = 0;
							CustomSelfDrawPanel.CSDLabel nextLabel3 = this.getNextLabel();
							if (Program.mySettings.LanguageIdent == "tr" && (num == 14 || num == 66 || num == 46 || num == 41 || num == 43 || num == 42))
							{
								nextLabel3.Font = font3;
							}
							else if (Program.mySettings.LanguageIdent == "pl" && (num == 14 || num == 37 || num == 45 || num == 50))
							{
								nextLabel3.Font = font3;
							}
							else if (Program.mySettings.LanguageIdent == "it" && (num == 17 || num == 67 || num == 41))
							{
								nextLabel3.Font = font3;
							}
							else if (Program.mySettings.LanguageIdent == "pt" && (num == 0 || num == 39 || num == 17 || num == 66 || num == 64 || num == 10 || num == 43 || num == 44 || num == 45 || num == 46))
							{
								nextLabel3.Font = font3;
							}
							else if (Program.mySettings.LanguageIdent == "pt" && (num == 34 || num == 42))
							{
								nextLabel3.Font = font4;
								num7 = -5;
							}
							else if ((num == 66 && Program.mySettings.LanguageIdent == "en") || ((num == 45 || num == 43) && Program.mySettings.LanguageIdent == "de"))
							{
								nextLabel3.Font = font3;
							}
							else
							{
								nextLabel3.Font = font;
							}
							nextLabel3.Text = ResearchData.getResearchName(num);
							nextLabel3.Color = global::ARGBColors.Black;
							nextLabel3.Position = new Point(6, 71 + num7);
							nextLabel3.Size = new Size(135, 30);
							nextLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
							csdimage.addControl(nextLabel3);
							if (num2 == 1)
							{
								CustomSelfDrawPanel.CSDImage csdimage2 = rows[i][j - 1 + num2];
								int num8 = 0;
								if (i < numRows - 1)
								{
									CustomSelfDrawPanel.CSDImage csdimage3 = rows[i + 1][j - 1 + num2];
									if (csdimage3 != null)
									{
										num8 = 1;
									}
								}
								if (num8 == 1)
								{
									csdimage2.Image = GFXLibrary.gline_1110;
								}
								else
								{
									csdimage2.Image = GFXLibrary.gline_1100;
								}
								this.scrollPanelImage.addControl(csdimage2);
								for (int k = i - 1; k > 0; k--)
								{
									CustomSelfDrawPanel.CSDImage csdimage4 = rows[k][j - 1 + num2];
									if (csdimage4 != null)
									{
										if (csdimage4.Data != 1)
										{
											break;
										}
										csdimage4.Image = GFXLibrary.gline_vertical;
										this.scrollPanelImage.addControl(csdimage4);
									}
								}
							}
							else
							{
								for (int l = i - 1; l > 0; l--)
								{
									CustomSelfDrawPanel.CSDImage csdimage5 = rows[l][j + num2];
									if (csdimage5 != null)
									{
										if (csdimage5.Data != 1)
										{
											break;
										}
										if (flag3)
										{
											csdimage5.Image = GFXLibrary.yline_vertical;
										}
										else if (num4 == 1)
										{
											csdimage5.Image = GFXLibrary.gline_vertical;
										}
										else
										{
											csdimage5.Image = GFXLibrary.bline_vertical;
										}
										this.scrollPanelImage.addControl(csdimage5);
									}
								}
							}
						}
					}
					else
					{
						csdimage.Tooltip = num * 1000 + j;
						int num9 = 0;
						if (i < numRows - 1)
						{
							CustomSelfDrawPanel.CSDImage csdimage6 = rows[i + 1][j + num2];
							if (csdimage6 != null && (csdimage6.Data == 0 || csdimage6.Data == 1))
							{
								num9 = 1;
							}
						}
						int num10 = 0;
						if (j != num3 - 1)
						{
							num10 = 1;
						}
						bool flag5 = false;
						bool flag6 = false;
						int num11 = -1;
						bool flag7 = false;
						int num12;
						if ((int)this.lastDataQueued.research[num] == j - 1)
						{
							if ((int)this.lastData.research[num] != j - 1)
							{
								flag5 = true;
							}
							if (this.lastDataQueued.isResearchStepOpen(num, j - 1, rank, rankSubLevel, ref num11, ref flag7, GameEngine.Instance.LocalWorldData.EraWorld))
							{
								num12 = 1;
								if (num10 != 0)
								{
									num10 = 2;
								}
								if (num9 != 0)
								{
									num9 = 2;
								}
								if (!this.lastData.isResearchStepOpen(num, j - 1, rank, rankSubLevel, ref num11, ref flag7, GameEngine.Instance.LocalWorldData.EraWorld))
								{
									flag5 = true;
								}
							}
							else
							{
								num12 = 2;
								if (num11 > 0 && flag7)
								{
									flag5 = false;
									CustomSelfDrawPanel.CSDImage nextImage5 = this.getNextImage();
									nextImage5.Image = GFXLibrary.ill_shield;
									nextImage5.Position = new Point(75 - nextImage5.Image.Width / 2, 7);
									nextImage5.Visible = true;
									csdimage.addControl(nextImage5);
									CustomSelfDrawPanel.CSDLabel nextLabel4 = this.getNextLabel();
									if (num11 >= 100)
									{
										nextLabel4.Text = (num11 - 100 + 1).ToString();
									}
									else
									{
										nextLabel4.Text = num11.ToString();
									}
									nextLabel4.Color = global::ARGBColors.White;
									nextLabel4.Position = new Point(0, -2);
									nextLabel4.Size = nextImage5.Size;
									nextLabel4.Font = font2;
									nextLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
									nextLabel4.Visible = true;
									nextImage5.addControl(nextLabel4);
								}
							}
							int num13 = -1;
							int num14 = -1;
							int num15 = -1;
							ResearchData.getOpenedResearch(num, j, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, ref num13, ref num14, ref num15);
							if (num13 >= 0 || num14 > 0 || num15 > 0)
							{
								CustomSelfDrawPanel.CSDImage nextImage6 = this.getNextImage();
								if (num13 >= 0)
								{
									nextImage6.Image = this.getBuildingGFX(num13);
								}
								if (num14 >= 0)
								{
									nextImage6.Image = this.getCastleGFX(num14);
								}
								if (num15 >= 0)
								{
									nextImage6.Image = this.getCastleGFX(num15);
								}
								if (nextImage6.Image != null)
								{
									nextImage6.Position = new Point(112 - nextImage6.Image.Width / 2, 82 - nextImage6.Image.Height / 2);
									nextImage6.Visible = true;
									csdimage.addControl(nextImage6);
								}
							}
						}
						else if ((int)this.lastDataQueued.research[num] < j - 1)
						{
							num12 = 2;
							this.lastDataQueued.isResearchStepOpen(num, j - 1, rank, rankSubLevel, ref num11, ref flag7, GameEngine.Instance.LocalWorldData.EraWorld);
							if (num11 > 0 && flag7)
							{
								CustomSelfDrawPanel.CSDImage nextImage7 = this.getNextImage();
								nextImage7.Image = GFXLibrary.ill_shield;
								nextImage7.Position = new Point(75 - nextImage7.Image.Width / 2, 7);
								nextImage7.Visible = true;
								csdimage.addControl(nextImage7);
								CustomSelfDrawPanel.CSDLabel nextLabel5 = this.getNextLabel();
								if (num11 >= 100)
								{
									nextLabel5.Text = (num11 - 100 + 1).ToString();
								}
								else
								{
									nextLabel5.Text = num11.ToString();
								}
								nextLabel5.Color = global::ARGBColors.White;
								nextLabel5.Position = new Point(0, -2);
								nextLabel5.Size = nextImage7.Size;
								nextLabel5.Font = font2;
								nextLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
								nextLabel5.Visible = true;
								nextImage7.addControl(nextLabel5);
							}
							int num16 = -1;
							int num17 = -1;
							int num18 = -1;
							ResearchData.getOpenedResearch(num, j, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, ref num16, ref num17, ref num18);
							if (num16 >= 0 || num17 > 0 || num18 > 0)
							{
								CustomSelfDrawPanel.CSDImage nextImage8 = this.getNextImage();
								if (num16 >= 0)
								{
									nextImage8.Image = this.getBuildingGFX(num16);
								}
								if (num17 >= 0)
								{
									nextImage8.Image = this.getCastleGFX(num17);
								}
								if (num18 >= 0)
								{
									nextImage8.Image = this.getCastleGFX(num18);
								}
								if (nextImage8.Image != null)
								{
									nextImage8.Position = new Point(112 - nextImage8.Image.Width / 2, 82 - nextImage8.Image.Height / 2);
									nextImage8.Visible = true;
									csdimage.addControl(nextImage8);
								}
							}
						}
						else
						{
							if ((int)this.lastData.research[num] == j - 1)
							{
								if (j > 1)
								{
									flag6 = true;
								}
								flag5 = true;
							}
							else if ((int)this.lastData.research[num] < j - 1)
							{
								flag5 = true;
							}
							num12 = 0;
							if (num9 != 0)
							{
								int num19 = 0;
								int num20 = -1;
								int num21 = -1;
								int openedResearch = ResearchData.getOpenedResearch(num, j, GameEngine.Instance.LocalWorldData.Alternate_Ruleset, ref num19, ref num20, ref num21);
								if (openedResearch >= 0)
								{
									int num22 = -1;
									bool flag8 = false;
									if (!this.lastDataQueued.isResearchStepOpen(openedResearch, 0, rank, rankSubLevel, ref num22, ref flag8, GameEngine.Instance.LocalWorldData.EraWorld))
									{
										num9 = 2;
									}
								}
							}
							if (num10 != 0 && !this.lastDataQueued.isResearchStepOpen(num, j, rank, rankSubLevel, ref num11, ref flag7, GameEngine.Instance.LocalWorldData.EraWorld))
							{
								num10 = 2;
							}
						}
						if (flag6)
						{
							csdimage.Image = this.getTransitionCircle(dx, dy, num12, 0, 1, num9, num10, num, j - 1);
						}
						else if (!flag5)
						{
							csdimage.Image = this.getCircle(dx, dy, num12, 0, 1, num9, num10, num, j - 1);
						}
						else
						{
							csdimage.Image = this.getYellowCircle(dx, dy, num12, 0, 1, num9, num10, num, j - 1);
						}
						CustomSelfDrawPanel.CSDImage nextImage9 = this.getNextImage();
						if (!flag5)
						{
							nextImage9.Image = this.getNumberImage(j, num12);
						}
						else
						{
							nextImage9.Image = this.getNumberImage(j, 2);
						}
						nextImage9.Position = new Point(csdimage.Size.Width / 2 - nextImage9.Size.Width / 2, csdimage.Size.Height / 2 - nextImage9.Size.Height / 2);
						csdimage.addControl(nextImage9);
					}
				}
			}
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x0001E8D4 File Offset: 0x0001CAD4
		private void resetImageCache()
		{
			this.curImageID = 0;
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x001FE590 File Offset: 0x001FC790
		private CustomSelfDrawPanel.CSDImage getNextImage()
		{
			if (this.curImageID >= this.imageCache.Count)
			{
				CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
				this.imageCache.Add(csdimage);
				this.curImageID++;
				return csdimage;
			}
			this.curImageID++;
			return this.imageCache[this.curImageID - 1];
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x0001E8DD File Offset: 0x0001CADD
		private void resetLabelCache()
		{
			this.curLabelID = 0;
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x001FE5F4 File Offset: 0x001FC7F4
		private CustomSelfDrawPanel.CSDLabel getNextLabel()
		{
			if (this.curLabelID >= this.labelCache.Count)
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				this.labelCache.Add(csdlabel);
				this.curLabelID++;
				return csdlabel;
			}
			this.curLabelID++;
			return this.labelCache[this.curLabelID - 1];
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x001FE658 File Offset: 0x001FC858
		private BaseImage getIllBack(int dx, int dy, int up, int left, int down, int right, int research)
		{
			if (dx < 0)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (dy < 0)
			{
				int num2 = up;
				up = down;
				down = num2;
			}
			if (up != 0)
			{
				if (left != 0)
				{
					if (left == 2 || up == 2)
					{
						return GFXLibrary.ill_back_bline_1001;
					}
					return GFXLibrary.ill_back_gline_1001;
				}
				else if (right != 0)
				{
					if (right == 2 || up == 2)
					{
						return GFXLibrary.ill_back_bline_1100;
					}
					return GFXLibrary.ill_back_gline_1100;
				}
				else if (down != 0)
				{
					if (down == 2 || up == 2)
					{
						return GFXLibrary.ill_back_bline_1010;
					}
					return GFXLibrary.ill_back_gline_1010;
				}
				else
				{
					if (up == 2)
					{
						return GFXLibrary.ill_back_bline_1000;
					}
					return GFXLibrary.ill_back_gline_1000;
				}
			}
			else if (down != 0)
			{
				if (left != 0)
				{
					if (left == 2 || down == 2)
					{
						return GFXLibrary.ill_back_bline_0011;
					}
					return GFXLibrary.ill_back_gline_0011;
				}
				else if (right != 0)
				{
					if (right == 2 || down == 2)
					{
						return GFXLibrary.ill_back_bline_0110;
					}
					return GFXLibrary.ill_back_gline_0110;
				}
				else
				{
					if (down == 2)
					{
						return GFXLibrary.ill_back_bline_0010;
					}
					return GFXLibrary.ill_back_gline_0010;
				}
			}
			else if (left != 0)
			{
				if (right != 0)
				{
					if (left == 2 || right == 2)
					{
						return GFXLibrary.ill_back_bline_0101;
					}
					return GFXLibrary.ill_back_gline_0101;
				}
				else
				{
					if (left == 2)
					{
						return GFXLibrary.ill_back_bline_0001;
					}
					return GFXLibrary.ill_back_gline_0001;
				}
			}
			else
			{
				if (right == 0)
				{
					return GFXLibrary.ill_back_bline_0000;
				}
				if (right == 2)
				{
					return GFXLibrary.ill_back_bline_0100;
				}
				return GFXLibrary.ill_back_gline_0100;
			}
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x001FE770 File Offset: 0x001FC970
		private BaseImage getCircle(int dx, int dy, int mode, int up, int left, int down, int right, int research, int level)
		{
			if (dx < 0)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (dy < 0)
			{
				int num2 = up;
				up = down;
				down = num2;
			}
			if (mode != 0)
			{
				if (mode != 1)
				{
					if (down != 0)
					{
						if (right != 0)
						{
							return GFXLibrary.bcf_0111;
						}
						return GFXLibrary.bcf_0011;
					}
					else
					{
						if (right != 0)
						{
							return GFXLibrary.bcf_0101;
						}
						return GFXLibrary.bcf_0001;
					}
				}
				else
				{
					if (up == 0 && right == 0 && down == 2 && left == 1)
					{
						return GFXLibrary.mix_gch_0001_bl_0010;
					}
					if (up == 0 && right == 2 && down == 0 && left == 1)
					{
						return GFXLibrary.mix_gch_0001_bl_0100;
					}
					if (up == 0 && right == 2 && down == 2 && left == 1)
					{
						return GFXLibrary.mix_gch_0001_bl_0110;
					}
					if (down != 0)
					{
						if (right != 0)
						{
							return GFXLibrary.gch_0111;
						}
						return GFXLibrary.gch_0011;
					}
					else
					{
						if (right != 0)
						{
							return GFXLibrary.gch_0101;
						}
						return GFXLibrary.gch_0001;
					}
				}
			}
			else
			{
				if (left == 1 && down == 1 && right == 2)
				{
					return GFXLibrary.mix_gcf_0011_bl_0100;
				}
				if (left == 1 && right == 1 && (up == 2 || down == 2) && down == 2)
				{
					return GFXLibrary.mix_gcf_0101_bl_0010;
				}
				if (left == 1 && (up == 2 || right == 2 || down == 2))
				{
					if (right == 2)
					{
						if (down == 2)
						{
							return GFXLibrary.mix_gcf_0001_bl_0110;
						}
						return GFXLibrary.mix_gcf_0001_bl_0100;
					}
					else if (down == 2)
					{
						return GFXLibrary.mix_gcf_0001_bl_0010;
					}
				}
				if (down != 0)
				{
					if (right != 0)
					{
						return GFXLibrary.gcf_0111;
					}
					return GFXLibrary.gcf_0011;
				}
				else
				{
					if (right != 0)
					{
						return GFXLibrary.gcf_0101;
					}
					return GFXLibrary.gcf_0001;
				}
			}
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x001FE8C8 File Offset: 0x001FCAC8
		private BaseImage getYellowCircle(int dx, int dy, int mode, int up, int left, int down, int right, int research, int level)
		{
			if (dx < 0)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (dy < 0)
			{
				int num2 = up;
				up = down;
				down = num2;
			}
			if (mode != 0)
			{
				if (mode != 1)
				{
					return GFXLibrary.bcf_0001;
				}
				if (up == 0 && right == 0 && down == 2 && left == 1)
				{
					return GFXLibrary.mix_ych_0001_bl_0010;
				}
				if (up == 0 && right == 2 && down == 0 && left == 1)
				{
					return GFXLibrary.mix_ych_0001_bl_0100;
				}
				if (up == 0 && right == 2 && down == 2 && left == 1)
				{
					return GFXLibrary.mix_ych_0001_bl_0110;
				}
				return GFXLibrary.ych_0001;
			}
			else
			{
				if (left == 1 && down == 1 && right == 2)
				{
					return GFXLibrary.mix_ycf_0011_bl_0100;
				}
				if (left == 1 && right == 1 && (up == 2 || down == 2) && down == 2)
				{
					return GFXLibrary.mix_ycf_0101_bl_0010;
				}
				if (left == 1 && (up == 2 || right == 2 || down == 2))
				{
					if (right == 2)
					{
						if (down == 2)
						{
							return GFXLibrary.mix_ycf_0001_bl_0110;
						}
						return GFXLibrary.mix_ycf_0001_bl_0100;
					}
					else if (down == 2)
					{
						return GFXLibrary.mix_ycf_0001_bl_0010;
					}
				}
				if (down != 0)
				{
					if (right != 0)
					{
						return GFXLibrary.ycf_0111;
					}
					return GFXLibrary.ycf_0011;
				}
				else
				{
					if (right != 0)
					{
						return GFXLibrary.ycf_0101;
					}
					return GFXLibrary.ycf_0001;
				}
			}
		}

		// Token: 0x0600298F RID: 10639 RVA: 0x001FE9E4 File Offset: 0x001FCBE4
		private BaseImage getTransitionCircle(int dx, int dy, int mode, int up, int left, int down, int right, int research, int level)
		{
			if (dx < 0)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (dy < 0)
			{
				int num2 = up;
				up = down;
				down = num2;
			}
			if (left == 1 && down == 1 && right == 2)
			{
				return GFXLibrary.ycf_0g1G;
			}
			if (left == 1 && right == 1 && (up == 2 || down == 2) && down == 2)
			{
				return GFXLibrary.ycf_01gG;
			}
			if (left == 1 && (up == 2 || right == 2 || down == 2))
			{
				if (right == 2)
				{
					if (down == 2)
					{
						return GFXLibrary.ycf_0ggG;
					}
					return GFXLibrary.mix_ycf_000G_bl_0100;
				}
				else if (down == 2)
				{
					return GFXLibrary.ycf_00gG;
				}
			}
			if (down != 0)
			{
				if (right != 0)
				{
					return GFXLibrary.ycf_011G;
				}
				return GFXLibrary.ycf_001G;
			}
			else
			{
				if (right != 0)
				{
					return GFXLibrary.ycf_010G;
				}
				return GFXLibrary.ycf_000G;
			}
		}

		// Token: 0x06002990 RID: 10640 RVA: 0x001FEA9C File Offset: 0x001FCC9C
		private BaseImage getNumberImage(int number, int colour)
		{
			switch (number)
			{
			case 1:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_1_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_1_tan;
				}
				return GFXLibrary.tech_number_1_olive;
			case 2:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_2_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_2_tan;
				}
				return GFXLibrary.tech_number_2_olive;
			case 3:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_3_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_3_tan;
				}
				return GFXLibrary.tech_number_3_olive;
			case 4:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_4_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_4_tan;
				}
				return GFXLibrary.tech_number_4_olive;
			case 5:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_5_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_5_tan;
				}
				return GFXLibrary.tech_number_5_olive;
			case 6:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_6_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_6_tan;
				}
				return GFXLibrary.tech_number_6_olive;
			case 7:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_7_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_7_tan;
				}
				return GFXLibrary.tech_number_7_olive;
			case 8:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_8_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_8_tan;
				}
				return GFXLibrary.tech_number_8_olive;
			case 9:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_9_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_9_tan;
				}
				return GFXLibrary.tech_number_9_olive;
			case 10:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_10_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_10_tan;
				}
				return GFXLibrary.tech_number_10_olive;
			case 11:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_11_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_11_tan;
				}
				return GFXLibrary.tech_number_11_olive;
			case 12:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_12_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_12_tan;
				}
				return GFXLibrary.tech_number_12_olive;
			case 13:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_13_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_13_tan;
				}
				return GFXLibrary.tech_number_13_olive;
			case 14:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_14_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_14_tan;
				}
				return GFXLibrary.tech_number_14_olive;
			case 15:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_15_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_15_tan;
				}
				return GFXLibrary.tech_number_15_olive;
			case 16:
				if (colour == 0)
				{
					return GFXLibrary.tech_number_16_green;
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_number_16_tan;
				}
				return GFXLibrary.tech_number_16_olive;
			case 17:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[10];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[0];
				}
				return GFXLibrary.tech_numbers[20];
			case 18:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[11];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[1];
				}
				return GFXLibrary.tech_numbers[21];
			case 19:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[12];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[2];
				}
				return GFXLibrary.tech_numbers[22];
			case 20:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[13];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[3];
				}
				return GFXLibrary.tech_numbers[23];
			case 21:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[14];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[4];
				}
				return GFXLibrary.tech_numbers[24];
			case 22:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[15];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[5];
				}
				return GFXLibrary.tech_numbers[25];
			case 23:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[16];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[6];
				}
				return GFXLibrary.tech_numbers[26];
			case 24:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[17];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[7];
				}
				return GFXLibrary.tech_numbers[27];
			case 25:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[18];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[8];
				}
				return GFXLibrary.tech_numbers[28];
			case 26:
				if (colour == 0)
				{
					return GFXLibrary.tech_numbers[19];
				}
				if (colour != 1)
				{
					return GFXLibrary.tech_numbers[9];
				}
				return GFXLibrary.tech_numbers[29];
			default:
				return GFXLibrary.tech_number_1_green;
			}
		}

		// Token: 0x06002991 RID: 10641 RVA: 0x0001E8E6 File Offset: 0x0001CAE6
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x0001E8F6 File Offset: 0x0001CAF6
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002993 RID: 10643 RVA: 0x0001E906 File Offset: 0x0001CB06
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x0001E918 File Offset: 0x0001CB18
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002995 RID: 10645 RVA: 0x0001E925 File Offset: 0x0001CB25
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06002996 RID: 10646 RVA: 0x0001E939 File Offset: 0x0001CB39
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002997 RID: 10647 RVA: 0x0001E946 File Offset: 0x0001CB46
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002998 RID: 10648 RVA: 0x0001E953 File Offset: 0x0001CB53
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002999 RID: 10649 RVA: 0x0001E972 File Offset: 0x0001CB72
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "ResearchPanel";
			base.SizeChanged += this.ResearchPanel2_SizeChanged;
			base.ResumeLayout(false);
		}

		// Token: 0x0400326A RID: 12906
		private const int topMoveDownOffset = 55;

		// Token: 0x0400326B RID: 12907
		private const int MAX_RESEARCH_LINES = 30;

		// Token: 0x0400326C RID: 12908
		private const int tileSizeX = 150;

		// Token: 0x0400326D RID: 12909
		private const int tileSizeY = 110;

		// Token: 0x0400326E RID: 12910
		private const int tileBorderX = 40;

		// Token: 0x0400326F RID: 12911
		private const int tileBorderY = 40;

		// Token: 0x04003270 RID: 12912
		private const int NUM_INDUSTRY_ROWS = 21;

		// Token: 0x04003271 RID: 12913
		private const int NUM_INDUSTRY_COLUMNS = 18;

		// Token: 0x04003272 RID: 12914
		private const int NUM_MILITARY_ROWS = 24;

		// Token: 0x04003273 RID: 12915
		private const int NUM_MILITARY_COLUMNS = 20;

		// Token: 0x04003274 RID: 12916
		private const int NUM_FARMING_ROWS = 13;

		// Token: 0x04003275 RID: 12917
		private const int NUM_FARMING_COLUMNS = 17;

		// Token: 0x04003276 RID: 12918
		private const int NUM_EDUCATION_ROWS = 27;

		// Token: 0x04003277 RID: 12919
		private const int NUM_EDUCATION_COLUMNS = 26;

		// Token: 0x04003278 RID: 12920
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003279 RID: 12921
		private CustomSelfDrawPanel.CSDImage currentResearchBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400327A RID: 12922
		private CustomSelfDrawPanel.CSDImage currentResearchBackgroundImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400327B RID: 12923
		private CustomSelfDrawPanel.CSDImage currentResearchImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400327C RID: 12924
		private CustomSelfDrawPanel.CSDImage currentResearchingBarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400327D RID: 12925
		private CustomSelfDrawPanel.CSDLabel currentResearchText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400327E RID: 12926
		private CustomSelfDrawPanel.CSDButton currentResearchCancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400327F RID: 12927
		private CustomSelfDrawPanel.CSDHorzExtendingPanel currentResearchInfoBox = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003280 RID: 12928
		private CustomSelfDrawPanel.CSDLabel currentResearchInfoBoxHeadingText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003281 RID: 12929
		private CustomSelfDrawPanel.CSDLabel currentResearchInfoBoxRow1Text = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003282 RID: 12930
		private CustomSelfDrawPanel.CSDLabel currentResearchInfoBoxRow2Text = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003283 RID: 12931
		private CustomSelfDrawPanel.CSDLabel currentResearchInfoBoxRow3Text = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003284 RID: 12932
		private CustomSelfDrawPanel.CSDArea queuedResearchArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003285 RID: 12933
		private CustomSelfDrawPanel.CSDImage queuedResearchImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003286 RID: 12934
		private CustomSelfDrawPanel.CSDImage queuedResearchImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003287 RID: 12935
		private CustomSelfDrawPanel.CSDImage queuedResearchImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003288 RID: 12936
		private CustomSelfDrawPanel.CSDImage queuedResearchImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003289 RID: 12937
		private CustomSelfDrawPanel.CSDImage queuedResearchImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400328A RID: 12938
		private CustomSelfDrawPanel.CSDImage queuedResearchImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400328B RID: 12939
		private CustomSelfDrawPanel.CSDImage queuedResearchImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400328C RID: 12940
		private CustomSelfDrawPanel.CSDButton queuedResearchButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400328D RID: 12941
		private CustomSelfDrawPanel.CSDButton queuedResearchButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400328E RID: 12942
		private CustomSelfDrawPanel.CSDButton queuedResearchButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400328F RID: 12943
		private CustomSelfDrawPanel.CSDButton queuedResearchButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003290 RID: 12944
		private CustomSelfDrawPanel.CSDButton queuedResearchButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003291 RID: 12945
		private CustomSelfDrawPanel.CSDButton queuedResearchButton6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003292 RID: 12946
		private CustomSelfDrawPanel.CSDButton queuedResearchButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003293 RID: 12947
		private CustomSelfDrawPanel.CSDLabel queuedResearchNoPremiumText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003294 RID: 12948
		private CustomSelfDrawPanel.CSDHorzExtendingPanel timeInfoBox = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003295 RID: 12949
		private CustomSelfDrawPanel.CSDHorzProgressBar timeProgressBar = new CustomSelfDrawPanel.CSDHorzProgressBar();

		// Token: 0x04003296 RID: 12950
		private CustomSelfDrawPanel.CSDLabel timeProgressText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003297 RID: 12951
		private CustomSelfDrawPanel.CSDHorzExtendingPanel buyPointInfoBox = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003298 RID: 12952
		private CustomSelfDrawPanel.CSDImage buyPointGold = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003299 RID: 12953
		private CustomSelfDrawPanel.CSDLabel buyPointText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400329A RID: 12954
		private CustomSelfDrawPanel.CSDButton buyPointButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400329B RID: 12955
		private CustomSelfDrawPanel.CSDHorzExtendingPanel pointsInfoBox = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400329C RID: 12956
		private CustomSelfDrawPanel.CSDLabel pointsText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400329D RID: 12957
		private CustomSelfDrawPanel.CSDImage scrollPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400329E RID: 12958
		private CustomSelfDrawPanel.CSDDragPanel dragOverlay = new CustomSelfDrawPanel.CSDDragPanel();

		// Token: 0x0400329F RID: 12959
		private CustomSelfDrawPanel.CSDControl dragOverlay2 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040032A0 RID: 12960
		private CustomSelfDrawPanel.CSDImage scrollPanelTopLeftOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A1 RID: 12961
		private CustomSelfDrawPanel.CSDImage scrollPanelTopMiddleOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A2 RID: 12962
		private CustomSelfDrawPanel.CSDImage scrollPanelTopRightOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A3 RID: 12963
		private CustomSelfDrawPanel.CSDImage scrollPanelLeftOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A4 RID: 12964
		private CustomSelfDrawPanel.CSDImage scrollPanelRightOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A5 RID: 12965
		private CustomSelfDrawPanel.CSDImage scrollPanelBottomLeftOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A6 RID: 12966
		private CustomSelfDrawPanel.CSDImage scrollPanelBottomMiddleOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A7 RID: 12967
		private CustomSelfDrawPanel.CSDImage scrollPanelBottomRightOverlay = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032A8 RID: 12968
		private CustomSelfDrawPanel.CSDButton tab1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032A9 RID: 12969
		private CustomSelfDrawPanel.CSDButton tab2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AA RID: 12970
		private CustomSelfDrawPanel.CSDButton tab3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AB RID: 12971
		private CustomSelfDrawPanel.CSDButton tab4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AC RID: 12972
		private CustomSelfDrawPanel.CSDButton tab5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AD RID: 12973
		private CustomSelfDrawPanel.CSDButton tabModeTreeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AE RID: 12974
		private CustomSelfDrawPanel.CSDButton tabModeListButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032AF RID: 12975
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040032B0 RID: 12976
		private int lastResearchTab = -1;

		// Token: 0x040032B1 RID: 12977
		private CustomSelfDrawPanel.CSDButton[] startResearchButtons = new CustomSelfDrawPanel.CSDButton[30];

		// Token: 0x040032B2 RID: 12978
		private CustomSelfDrawPanel.CSDImage[] startResearchImages = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032B3 RID: 12979
		private CustomSelfDrawPanel.CSDLabel[] startResearchHeader = new CustomSelfDrawPanel.CSDLabel[30];

		// Token: 0x040032B4 RID: 12980
		private CustomSelfDrawPanel.CSDLabel[] startResearchText1 = new CustomSelfDrawPanel.CSDLabel[30];

		// Token: 0x040032B5 RID: 12981
		private CustomSelfDrawPanel.CSDLabel[] startResearchText2 = new CustomSelfDrawPanel.CSDLabel[30];

		// Token: 0x040032B6 RID: 12982
		private CustomSelfDrawPanel.CSDImage[] startResearchDotsBack = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032B7 RID: 12983
		private CustomSelfDrawPanel.CSDImage[] startResearchDots = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032B8 RID: 12984
		private CustomSelfDrawPanel.CSDImage[] startResearchDotsYellow = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032B9 RID: 12985
		private CustomSelfDrawPanel.CSDImage[] startResearchOpenBackground = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032BA RID: 12986
		private CustomSelfDrawPanel.CSDImage[] startResearchOpenResearch = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032BB RID: 12987
		private CustomSelfDrawPanel.CSDImage[] startResearchOpenBuilding = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032BC RID: 12988
		private CustomSelfDrawPanel.CSDImage[] startResearchOpenResearchOverlay = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032BD RID: 12989
		private CustomSelfDrawPanel.CSDLabel[] startResearchOpenResearchOverlayLabel = new CustomSelfDrawPanel.CSDLabel[30];

		// Token: 0x040032BE RID: 12990
		private CustomSelfDrawPanel.CSDImage[] startResearchShield = new CustomSelfDrawPanel.CSDImage[30];

		// Token: 0x040032BF RID: 12991
		private CustomSelfDrawPanel.CSDLabel[] startResearchShieldNumber = new CustomSelfDrawPanel.CSDLabel[30];

		// Token: 0x040032C0 RID: 12992
		private CustomSelfDrawPanel.CSDVertScrollBar startResearchScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040032C1 RID: 12993
		private CustomSelfDrawPanel.CSDLabel startResearchHeaderMain = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032C2 RID: 12994
		private CustomSelfDrawPanel.CSDLabel startResearchHeaderResearchOpen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032C3 RID: 12995
		private CustomSelfDrawPanel.CSDLabel startResearchHeaderBuildingOpen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032C4 RID: 12996
		public static int TUTORIAL_artsTabPos = -10000;

		// Token: 0x040032C5 RID: 12997
		private int lastTab;

		// Token: 0x040032C6 RID: 12998
		private int tabType;

		// Token: 0x040032C7 RID: 12999
		private MyMessageBoxPopUp cancelResearchPopup;

		// Token: 0x040032C8 RID: 13000
		private bool forceUpdate;

		// Token: 0x040032C9 RID: 13001
		private int tooltipToShow = -1;

		// Token: 0x040032CA RID: 13002
		private ResearchData lastData;

		// Token: 0x040032CB RID: 13003
		private ResearchData lastDataQueued;

		// Token: 0x040032CC RID: 13004
		private bool researchAllowed;

		// Token: 0x040032CD RID: 13005
		private int selectedQueueSlot = -1;

		// Token: 0x040032CE RID: 13006
		private int lastScrollXPos;

		// Token: 0x040032CF RID: 13007
		private int lastScrollYPos;

		// Token: 0x040032D0 RID: 13008
		private Size realScrollImageSize;

		// Token: 0x040032D1 RID: 13009
		private double m_windowScale = 1.0;

		// Token: 0x040032D2 RID: 13010
		private int m_windowScaleNotch;

		// Token: 0x040032D3 RID: 13011
		private double[] windowScalingValues = new double[]
		{
			1.0,
			0.5
		};

		// Token: 0x040032D4 RID: 13012
		private int[] industryLayout = new int[]
		{
			-1,
			0,
			0,
			1,
			1,
			1,
			4,
			1,
			3,
			5,
			2,
			2,
			6,
			1,
			38,
			9,
			39,
			8,
			5,
			7,
			69,
			6,
			7,
			5,
			9,
			4,
			8,
			3,
			63,
			2,
			13,
			1,
			14,
			6,
			15,
			5,
			16,
			4,
			17,
			3,
			18,
			2
		};

		// Token: 0x040032D5 RID: 13013
		private int[] farmingLayout = new int[]
		{
			-2,
			0,
			66,
			1,
			64,
			1,
			65,
			1,
			68,
			1,
			12,
			8,
			10,
			7,
			71,
			5,
			70,
			3,
			67,
			2,
			61,
			1,
			11,
			6,
			62,
			3
		};

		// Token: 0x040032D6 RID: 13014
		private int[] militaryLayout = new int[]
		{
			-3,
			0,
			19,
			1,
			84,
			7,
			20,
			6,
			57,
			5,
			21,
			4,
			22,
			3,
			23,
			2,
			24,
			1,
			26,
			6,
			27,
			5,
			28,
			4,
			29,
			3,
			30,
			2,
			75,
			1,
			76,
			3,
			37,
			2,
			78,
			1,
			85,
			2,
			86,
			1,
			74,
			1,
			25,
			2,
			82,
			4,
			73,
			3
		};

		// Token: 0x040032D7 RID: 13015
		private int[] educationLayout = new int[]
		{
			-4,
			0,
			32,
			1,
			33,
			4,
			34,
			3,
			35,
			6,
			36,
			5,
			40,
			2,
			42,
			8,
			43,
			7,
			44,
			6,
			41,
			5,
			45,
			4,
			46,
			3,
			59,
			1,
			48,
			5,
			58,
			6,
			49,
			4,
			50,
			17,
			51,
			16,
			53,
			14,
			54,
			13,
			56,
			12,
			55,
			11,
			52,
			9,
			72,
			10,
			47,
			3,
			60,
			2
		};

		// Token: 0x040032D8 RID: 13016
		private int[] educationLayout2 = new int[]
		{
			-4,
			0,
			32,
			1,
			33,
			4,
			34,
			3,
			35,
			6,
			36,
			5,
			40,
			2,
			42,
			8,
			43,
			7,
			44,
			6,
			41,
			5,
			45,
			4,
			46,
			3,
			59,
			1,
			48,
			5,
			58,
			6,
			49,
			4,
			50,
			17,
			51,
			16,
			54,
			13,
			56,
			12,
			55,
			11,
			52,
			9,
			72,
			10,
			47,
			3,
			60,
			2
		};

		// Token: 0x040032D9 RID: 13017
		private bool rowsCreated;

		// Token: 0x040032DA RID: 13018
		private CustomSelfDrawPanel.CSDImage[][] industryRows = new CustomSelfDrawPanel.CSDImage[21][];

		// Token: 0x040032DB RID: 13019
		private CustomSelfDrawPanel.CSDImage[][] militaryRows = new CustomSelfDrawPanel.CSDImage[24][];

		// Token: 0x040032DC RID: 13020
		private CustomSelfDrawPanel.CSDImage[][] farmingRows = new CustomSelfDrawPanel.CSDImage[13][];

		// Token: 0x040032DD RID: 13021
		private CustomSelfDrawPanel.CSDImage[][] educationRows = new CustomSelfDrawPanel.CSDImage[27][];

		// Token: 0x040032DE RID: 13022
		private CustomSelfDrawPanel.CSDImage[][] educationRows2 = new CustomSelfDrawPanel.CSDImage[26][];

		// Token: 0x040032DF RID: 13023
		private List<CustomSelfDrawPanel.CSDImage> imageCache = new List<CustomSelfDrawPanel.CSDImage>();

		// Token: 0x040032E0 RID: 13024
		private int curImageID;

		// Token: 0x040032E1 RID: 13025
		private List<CustomSelfDrawPanel.CSDLabel> labelCache = new List<CustomSelfDrawPanel.CSDLabel>();

		// Token: 0x040032E2 RID: 13026
		private int curLabelID;

		// Token: 0x040032E3 RID: 13027
		private DockableControl dockableControl;

		// Token: 0x040032E4 RID: 13028
		private IContainer components;
	}
}
