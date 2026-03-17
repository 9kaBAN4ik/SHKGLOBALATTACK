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
	// Token: 0x02000494 RID: 1172
	public class StatsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06002A95 RID: 10901 RVA: 0x0001F65E File Offset: 0x0001D85E
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002A96 RID: 10902 RVA: 0x0001F66E File Offset: 0x0001D86E
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002A97 RID: 10903 RVA: 0x0001F67E File Offset: 0x0001D87E
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002A98 RID: 10904 RVA: 0x0001F690 File Offset: 0x0001D890
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002A99 RID: 10905 RVA: 0x0001F69D File Offset: 0x0001D89D
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x0001F6B1 File Offset: 0x0001D8B1
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x0001F6BE File Offset: 0x0001D8BE
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x0001F6CB File Offset: 0x0001D8CB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A9D RID: 10909 RVA: 0x002107DC File Offset: 0x0020E9DC
		private void InitializeComponent()
		{
			this.searchInput = new TextBox();
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.searchInput.BackColor = Color.FromArgb(140, 153, 161);
			this.searchInput.BorderStyle = BorderStyle.None;
			this.searchInput.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.searchInput.Location = new Point(653, 15);
			this.searchInput.MaxLength = 40;
			this.searchInput.Multiline = true;
			this.searchInput.Name = "searchInput";
			this.searchInput.Size = new Size(200, 22);
			this.searchInput.TabIndex = 100;
			this.searchInput.Text = "Search";
			this.searchInput.WordWrap = false;
			this.searchInput.KeyPress += this.searchInput_KeyPress;
			this.searchInput.Enter += this.searchInput_Enter;
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 1;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			base.Controls.Add(this.searchInput);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 594);
			base.Name = "StatsPanel";
			base.Size = new Size(992, 594);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06002A9E RID: 10910 RVA: 0x002109E0 File Offset: 0x0020EBE0
		public StatsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			this.searchInput.Font = FontManager.GetFont("Microsoft Sans Serif", 12f, FontStyle.Regular);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002A9F RID: 10911 RVA: 0x00210D88 File Offset: 0x0020EF88
		public void init(bool resized)
		{
			base.clearControls();
			this.numVariCats = 8;
			if (this.currentCategory == 18)
			{
				this.currentCategory = -1;
				this.categoryScrollPos = 0;
			}
			this.focusPanel.Focus();
			if (!resized)
			{
				this.currentUserLine = -10000;
				this.initialTextInTextbox = true;
				this.searchInput.Text = SK.Text("Stats_Seaarch", "Search");
				this.inSearchResults = false;
			}
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.categoryLabel.Text = "[" + SK.Text("Stats_Category", "Category") + "]";
			this.categoryLabel.Color = global::ARGBColors.White;
			this.categoryLabel.DropShadowColor = global::ARGBColors.Black;
			this.categoryLabel.Position = new Point(35, 11);
			this.categoryLabel.Size = new Size(300, 35);
			this.categoryLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.categoryLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.categoryLabel);
			this.categoryDescription.Text = "[" + SK.Text("Stats_Description", "Description") + "]";
			this.categoryDescription.Color = global::ARGBColors.White;
			this.categoryDescription.DropShadowColor = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it")
			{
				this.categoryDescription.Position = new Point(100, 3);
				this.categoryDescription.Size = new Size(360, 50);
				this.categoryDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else if (Program.mySettings.LanguageIdent == "pt")
			{
				this.categoryDescription.Position = new Point(100, 3);
				this.categoryDescription.Size = new Size(300, 50);
				this.categoryDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else
			{
				this.categoryDescription.Position = new Point(100, 18);
				this.categoryDescription.Size = new Size(500, 30);
				this.categoryDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			}
			this.categoryDescription.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.mainBackgroundImage.addControl(this.categoryDescription);
			int num = base.Height - 594;
			this.mainInsetTopTopImage.Image = GFXLibrary.int_statsscreen_maininset_top_top;
			this.mainInsetTopTopImage.Position = new Point(30, 103);
			this.mainBackgroundImage.addControl(this.mainInsetTopTopImage);
			this.mainInsetTopMiddleImage.Image = GFXLibrary.int_statsscreen_maininset_top_middle;
			this.mainInsetTopMiddleImage.Position = new Point(30, 143);
			this.mainInsetTopMiddleImage.Size = new Size(this.mainInsetTopMiddleImage.Image.Width, 90 + num / 2);
			this.mainBackgroundImage.addControl(this.mainInsetTopMiddleImage);
			this.mainInsetTopBottomImage.Image = GFXLibrary.int_statsscreen_maininset_top_bottom;
			this.mainInsetTopBottomImage.Position = new Point(30, 233 + num / 2);
			this.mainBackgroundImage.addControl(this.mainInsetTopBottomImage);
			this.mainInsetMidImage.Image = GFXLibrary.int_statsscreen_maininset_middle;
			this.mainInsetMidImage.Position = new Point(30, 308 + num / 2);
			this.mainInsetMidImage.Size = new Size(this.mainInsetMidImage.Image.Width, 222 + num / 2);
			this.mainBackgroundImage.addControl(this.mainInsetMidImage);
			this.mainInsetBottomImage.Image = GFXLibrary.int_statsscreen_maininset_bottom;
			this.mainInsetBottomImage.Position = new Point(30, 530 + num / 2 * 2);
			this.mainBackgroundImage.addControl(this.mainInsetBottomImage);
			this.searchInsetImage.Image = GFXLibrary.int_statsscreen_search_inset;
			this.searchInsetImage.Position = new Point(638, 9);
			this.mainBackgroundImage.addControl(this.searchInsetImage);
			this.searchButton.ImageNorm = GFXLibrary.int_statsscreen_search_button_normal;
			this.searchButton.ImageOver = GFXLibrary.int_statsscreen_search_button_over;
			this.searchButton.ImageClick = GFXLibrary.int_statsscreen_search_button_pushed;
			this.searchButton.Position = new Point(244, 4);
			this.searchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.searchClicked), "StatsPanel_search");
			this.searchInsetImage.addControl(this.searchButton);
			this.clearSearchButton.ImageNorm = GFXLibrary.int_statsscreen_search_clear_button_normal;
			this.clearSearchButton.ImageOver = GFXLibrary.int_statsscreen_search_clear_button_over;
			this.clearSearchButton.ImageClick = GFXLibrary.int_statsscreen_search_clear_button_pushed;
			this.clearSearchButton.Position = new Point(241 - this.clearSearchButton.ImageNorm.Size.Width, 4);
			this.clearSearchButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.clearSearchClicked), "StatsPanel_clear_search");
			this.clearSearchButton.Visible = this.inSearchResults;
			this.searchInsetImage.addControl(this.clearSearchButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 28, new Point(598, 8));
			this.fixedIconBar.Position = new Point(37, 57);
			this.fixedIconBar.Size = new Size(314, 1);
			this.mainBackgroundImage.addControl(this.fixedIconBar);
			this.fixedIconBar.Create(GFXLibrary.int_statsscreen_iconbar_left, GFXLibrary.int_statsscreen_iconbar_middle, GFXLibrary.int_statsscreen_iconbar_right);
			this.scrollIconBar.Position = new Point(375, 57);
			this.scrollIconBar.Size = new Size(572, 1);
			this.mainBackgroundImage.addControl(this.scrollIconBar);
			this.scrollIconBar.Create(GFXLibrary.int_statsscreen_iconbar_left, GFXLibrary.int_statsscreen_iconbar_middle, GFXLibrary.int_statsscreen_iconbar_right);
			this.fixedButton1.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.fixedButton1.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.fixedButton1.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.fixedButton1.Position = new Point(-14, -7);
			this.fixedButton1.Data = -1;
			this.fixedButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedButton1.CustomTooltipID = 1300;
			this.fixedButton1.CustomTooltipData = -1;
			this.fixedIconBar.addControl(this.fixedButton1);
			this.fixedButton2.ImageNorm = GFXLibrary.catagory_icons_rank_normal;
			this.fixedButton2.ImageOver = GFXLibrary.catagory_icons_rank_over;
			this.fixedButton2.ImageClick = GFXLibrary.catagory_icons_rank_pushed;
			this.fixedButton2.Position = new Point(46, -7);
			this.fixedButton2.Data = -5;
			this.fixedButton2.CustomTooltipID = 1300;
			this.fixedButton2.CustomTooltipData = -5;
			this.fixedButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedIconBar.addControl(this.fixedButton2);
			this.fixedButton3.ImageNorm = GFXLibrary.catagory_icons_villages_normal;
			this.fixedButton3.ImageOver = GFXLibrary.catagory_icons_villages_over;
			this.fixedButton3.ImageClick = GFXLibrary.catagory_icons_villages_pushed;
			this.fixedButton3.Position = new Point(106, -7);
			this.fixedButton3.Data = -6;
			this.fixedButton3.CustomTooltipID = 1300;
			this.fixedButton3.CustomTooltipData = -6;
			this.fixedButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedIconBar.addControl(this.fixedButton3);
			this.fixedButton4.ImageNorm = GFXLibrary.catagory_icons_factions_normal;
			this.fixedButton4.ImageOver = GFXLibrary.catagory_icons_factions_over;
			this.fixedButton4.ImageClick = GFXLibrary.catagory_icons_factions_pushed;
			this.fixedButton4.Position = new Point(166, -7);
			this.fixedButton4.Data = -2;
			this.fixedButton4.CustomTooltipID = 1300;
			this.fixedButton4.CustomTooltipData = -2;
			this.fixedButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedIconBar.addControl(this.fixedButton4);
			this.fixedButton5.ImageNorm = GFXLibrary.catagory_icons_houses_normal;
			this.fixedButton5.ImageOver = GFXLibrary.catagory_icons_houses_over;
			this.fixedButton5.ImageClick = GFXLibrary.catagory_icons_houses_pushed;
			this.fixedButton5.Position = new Point(226, -7);
			this.fixedButton5.Data = -3;
			this.fixedButton5.CustomTooltipID = 1300;
			this.fixedButton5.CustomTooltipData = -3;
			this.fixedButton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedIconBar.addControl(this.fixedButton5);
			this.fixedButton7.ImageNorm = GFXLibrary.catagory_icons_parishflags_normal;
			this.fixedButton7.ImageOver = GFXLibrary.catagory_icons_parishflags_over;
			this.fixedButton7.ImageClick = GFXLibrary.catagory_icons_parishflags_pushed;
			this.fixedButton7.Position = new Point(286, -7);
			this.fixedButton7.Data = -4;
			this.fixedButton7.CustomTooltipID = 1300;
			this.fixedButton7.CustomTooltipData = -4;
			this.fixedButton7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.fixedIconBar.addControl(this.fixedButton7);
			this.variButton1.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton1.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton1.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton1.Position = new Point(38, -7);
			this.variButton1.Data = 0;
			this.variButton1.CustomTooltipID = 1300;
			this.variButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton1);
			this.variButton2.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton2.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton2.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton2.Position = new Point(88, -7);
			this.variButton2.Data = 1;
			this.variButton2.CustomTooltipID = 1300;
			this.variButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton2);
			this.variButton3.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton3.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton3.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton3.Position = new Point(138, -7);
			this.variButton3.Data = 2;
			this.variButton3.CustomTooltipID = 1300;
			this.variButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton3);
			this.variButton4.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton4.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton4.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton4.Position = new Point(188, -7);
			this.variButton4.Data = 3;
			this.variButton4.CustomTooltipID = 1300;
			this.variButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton4);
			this.variButton5.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton5.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton5.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton5.Position = new Point(238, -7);
			this.variButton5.Data = 4;
			this.variButton5.CustomTooltipID = 1300;
			this.variButton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton5);
			this.variButton6.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton6.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton6.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton6.Position = new Point(288, -7);
			this.variButton6.Data = 5;
			this.variButton6.CustomTooltipID = 1300;
			this.variButton6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton6);
			this.variButton7.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton7.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton7.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton7.Position = new Point(338, -7);
			this.variButton7.Data = 6;
			this.variButton7.CustomTooltipID = 1300;
			this.variButton7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton7);
			this.variButton8.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton8.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton8.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton8.Position = new Point(388, -7);
			this.variButton8.Data = 7;
			this.variButton8.CustomTooltipID = 1300;
			this.variButton8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton8);
			this.variButton9.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton9.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton9.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton9.Position = new Point(438, -7);
			this.variButton9.Data = 8;
			this.variButton9.CustomTooltipID = 1300;
			this.variButton9.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton9);
			this.variButton10.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.variButton10.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.variButton10.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.variButton10.Position = new Point(488, -7);
			this.variButton10.Data = 9;
			this.variButton10.CustomTooltipID = 1300;
			this.variButton10.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryClicked));
			this.scrollIconBar.addControl(this.variButton10);
			this.variButtonLeft.ImageNorm = GFXLibrary.int_statsscreen_iconbar_arrow_left_normal;
			this.variButtonLeft.ImageOver = GFXLibrary.int_statsscreen_iconbar_arrow_left_over;
			this.variButtonLeft.ImageClick = GFXLibrary.int_statsscreen_iconbar_arrow_left_pressed;
			this.variButtonLeft.Position = new Point(6, -10);
			this.variButtonLeft.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryLeftClicked), "StatsPanel_category_left");
			this.scrollIconBar.addControl(this.variButtonLeft);
			this.variButtonRight.ImageNorm = GFXLibrary.int_statsscreen_iconbar_arrow_right_normal;
			this.variButtonRight.ImageOver = GFXLibrary.int_statsscreen_iconbar_arrow_right_over;
			this.variButtonRight.ImageClick = GFXLibrary.int_statsscreen_iconbar_arrow_right_pressed;
			this.variButtonRight.Position = new Point(538, -10);
			this.variButtonRight.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.categoryRightClicked), "StatsPanel_category_right");
			this.scrollIconBar.addControl(this.variButtonRight);
			this.mainEntry1.Position = new Point(39, 114);
			this.mainBackgroundImage.addControl(this.mainEntry1);
			this.mainEntry2.Position = new Point(39, 163);
			this.mainBackgroundImage.addControl(this.mainEntry2);
			this.mainEntry3.Position = new Point(39, 212);
			this.mainBackgroundImage.addControl(this.mainEntry3);
			this.mainEntry4.Position = new Point(39, 261);
			this.mainBackgroundImage.addControl(this.mainEntry4);
			this.mainEntry5.Position = new Point(39, 310);
			this.mainBackgroundImage.addControl(this.mainEntry5);
			this.mainEntry6.Position = new Point(39, 359);
			this.mainBackgroundImage.addControl(this.mainEntry6);
			this.mainEntry7.Position = new Point(39, 408);
			this.mainBackgroundImage.addControl(this.mainEntry7);
			this.mainEntry8.Position = new Point(39, 457);
			this.mainBackgroundImage.addControl(this.mainEntry8);
			this.mainEntry9.Position = new Point(39, 506);
			this.mainBackgroundImage.addControl(this.mainEntry9);
			this.mainEntry10.Position = new Point(39, 555);
			this.mainBackgroundImage.addControl(this.mainEntry10);
			this.mainEntry11.Position = new Point(39, 604);
			this.mainBackgroundImage.addControl(this.mainEntry11);
			this.mainEntry12.Position = new Point(39, 653);
			this.mainBackgroundImage.addControl(this.mainEntry12);
			this.mainEntry13.Position = new Point(39, 702);
			this.mainBackgroundImage.addControl(this.mainEntry13);
			this.mainEntry14.Position = new Point(39, 751);
			this.mainBackgroundImage.addControl(this.mainEntry14);
			this.mainEntry15.Position = new Point(39, 800);
			this.mainBackgroundImage.addControl(this.mainEntry15);
			this.mainEntry16.Position = new Point(39, 849);
			this.mainBackgroundImage.addControl(this.mainEntry16);
			this.mainEntry17.Position = new Point(39, 898);
			this.mainBackgroundImage.addControl(this.mainEntry17);
			this.mainEntry18.Position = new Point(39, 947);
			this.mainBackgroundImage.addControl(this.mainEntry18);
			this.mainEntry19.Position = new Point(39, 996);
			this.mainBackgroundImage.addControl(this.mainEntry19);
			this.mainEntry20.Position = new Point(39, 1045);
			this.mainBackgroundImage.addControl(this.mainEntry20);
			this.topEntry1.Position = new Point(528, 114);
			this.topEntry1.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry1);
			this.topEntry2.Position = new Point(528, 163);
			this.topEntry2.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry2);
			this.topEntry3.Position = new Point(528, 212);
			this.topEntry3.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry3);
			this.topEntry4.Position = new Point(528, 261);
			this.topEntry4.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry4);
			this.topEntry5.Position = new Point(528, 310);
			this.topEntry5.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry5);
			this.topEntry6.Position = new Point(528, 359);
			this.topEntry6.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry6);
			this.topEntry7.Position = new Point(528, 408);
			this.topEntry7.setAsTopEntry();
			this.mainBackgroundImage.addControl(this.topEntry7);
			StatsPanel.NUM_VISIBLE_LINES = 9 + num / 49;
			if (StatsPanel.NUM_VISIBLE_LINES > 20)
			{
				StatsPanel.NUM_VISIBLE_LINES = 20;
			}
			this.numExtraTopLines = num / 2 / 49;
			if (!resized)
			{
				this.mainEntry1.init(this.currentCategory, -1000, 0);
				this.mainEntry2.init(this.currentCategory, -1001, 1);
				this.mainEntry3.init(this.currentCategory, -1002, 2);
				this.mainEntry4.init(this.currentCategory, -1003, 3);
				this.mainEntry5.init(this.currentCategory, -1004, 4);
				this.mainEntry6.init(this.currentCategory, -1005, 5);
				this.mainEntry7.init(this.currentCategory, -1006, 6);
				this.mainEntry8.init(this.currentCategory, -1007, 7);
				this.mainEntry9.init(this.currentCategory, -1008, 8);
				if (StatsPanel.NUM_VISIBLE_LINES >= 10)
				{
					this.mainEntry10.init(this.currentCategory, -1009, 9);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 11)
				{
					this.mainEntry11.init(this.currentCategory, -1009, 10);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 12)
				{
					this.mainEntry12.init(this.currentCategory, -1009, 11);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 13)
				{
					this.mainEntry13.init(this.currentCategory, -1009, 12);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 14)
				{
					this.mainEntry14.init(this.currentCategory, -1009, 13);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 15)
				{
					this.mainEntry15.init(this.currentCategory, -1009, 14);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 16)
				{
					this.mainEntry16.init(this.currentCategory, -1009, 15);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 17)
				{
					this.mainEntry17.init(this.currentCategory, -1009, 16);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 18)
				{
					this.mainEntry18.init(this.currentCategory, -1009, 17);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 19)
				{
					this.mainEntry19.init(this.currentCategory, -1009, 18);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 20)
				{
					this.mainEntry20.init(this.currentCategory, -1009, 19);
				}
				this.topEntry1.init(this.currentCategory, 1, 0);
				this.topEntry2.init(this.currentCategory, 2, 1);
				this.topEntry3.init(this.currentCategory, 3, 2);
				if (this.numExtraTopLines > 0)
				{
					this.topEntry4.init(this.currentCategory, 4, 3);
				}
				if (this.numExtraTopLines > 1)
				{
					this.topEntry5.init(this.currentCategory, 5, 4);
				}
				if (this.numExtraTopLines > 2)
				{
					this.topEntry6.init(this.currentCategory, 6, 5);
				}
				if (this.numExtraTopLines > 3)
				{
					this.topEntry7.init(this.currentCategory, 7, 6);
				}
			}
			else
			{
				this.updateEntries();
			}
			int num2 = num / 2;
			this.secondInsetImage.Position = new Point(552, 316 + num2);
			this.secondInsetImage.Size = new Size(1, 248 + num / 2);
			this.mainBackgroundImage.addControl(this.secondInsetImage);
			this.secondInsetImage.Create(GFXLibrary.int_statsscreen_secondinset_top, GFXLibrary.int_statsscreen_secondinset_middle, GFXLibrary.int_statsscreen_secondinset_bottom);
			this.selfEntry1.Position = new Point(572, 338 + num2);
			this.selfEntry1.init(0, this);
			this.mainBackgroundImage.addControl(this.selfEntry1);
			this.selfEntry2.Position = new Point(572, 408 + num2);
			this.selfEntry2.init(1, this);
			this.mainBackgroundImage.addControl(this.selfEntry2);
			this.selfEntry3.Position = new Point(572, 478 + num2);
			this.selfEntry3.init(2, this);
			this.mainBackgroundImage.addControl(this.selfEntry3);
			this.selfEntry4.Position = new Point(572, 548 + num2);
			this.selfEntry4.init(3, this);
			this.mainBackgroundImage.addControl(this.selfEntry4);
			this.selfEntry5.Position = new Point(572, 618 + num2);
			this.selfEntry5.init(4, this);
			this.mainBackgroundImage.addControl(this.selfEntry5);
			this.selfEntry6.Position = new Point(572, 688 + num2);
			this.selfEntry6.init(5, this);
			this.mainBackgroundImage.addControl(this.selfEntry6);
			this.selfEntry7.Position = new Point(572, 758 + num2);
			this.selfEntry7.init(6, this);
			this.mainBackgroundImage.addControl(this.selfEntry7);
			int num3 = num / 2 / 70;
			this.selfEntry4.Visible = (num3 >= 1);
			this.selfEntry5.Visible = (num3 >= 2);
			this.selfEntry6.Visible = (num3 >= 3);
			this.selfEntry7.Visible = (num3 >= 4);
			this.topButton.ImageNorm = GFXLibrary.page_top_norrmal;
			this.topButton.ImageOver = GFXLibrary.page_top_over;
			this.topButton.ImageClick = GFXLibrary.page_top_pushed;
			this.topButton.Position = new Point(464, 114);
			this.topButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scrollToTopClicked), "StatsPanel_scroll_top");
			this.mainBackgroundImage.addControl(this.topButton);
			this.upButton.ImageNorm = GFXLibrary.page_up_normal;
			this.upButton.ImageOver = GFXLibrary.page_up_over;
			this.upButton.ImageClick = GFXLibrary.page_up_pushed;
			this.upButton.Position = new Point(464, this.topButton.Position.Y + 2 + this.topButton.ImageNorm.Height);
			this.upButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scrollUpClicked), "StatsPanel_scroll_up");
			this.mainBackgroundImage.addControl(this.upButton);
			this.bottomButton.ImageNorm = GFXLibrary.page_bottom_normal;
			this.bottomButton.ImageOver = GFXLibrary.page_bottom_over;
			this.bottomButton.ImageClick = GFXLibrary.page_bottom_pushed;
			this.bottomButton.Position = new Point(464, base.Height - 42 - this.bottomButton.ImageNorm.Height);
			this.bottomButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scrollToBottomClicked), "StatsPanel_scroll_bottom");
			this.mainBackgroundImage.addControl(this.bottomButton);
			this.downButton.ImageNorm = GFXLibrary.page_down_normal;
			this.downButton.ImageOver = GFXLibrary.page_down_over;
			this.downButton.ImageClick = GFXLibrary.page_down_pushed;
			this.downButton.Position = new Point(464, this.bottomButton.Position.Y - 2 - this.downButton.ImageNorm.Height);
			this.downButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.scrollDownClicked), "StatsPanel_scroll_down");
			this.mainBackgroundImage.addControl(this.downButton);
			this.updateLabel.Text = "";
			this.updateLabel.Color = global::ARGBColors.Black;
			this.updateLabel.Position = new Point(50, base.Height - 22);
			this.updateLabel.Size = new Size(500, 25);
			this.updateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.updateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.updateLabel);
			this.bestRankingsLabel.Text = SK.Text("Stats_Best_Ranking", "Your Best Rankings");
			this.bestRankingsLabel.Color = global::ARGBColors.White;
			this.bestRankingsLabel.Position = new Point(570, 292 + num / 2);
			this.bestRankingsLabel.Size = new Size(300, 25);
			this.bestRankingsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.bestRankingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundImage.addControl(this.bestRankingsLabel);
			this.updateVariIcons();
			if (!resized)
			{
				this.newCategory();
			}
		}

		// Token: 0x06002AA0 RID: 10912 RVA: 0x00212D28 File Offset: 0x00210F28
		private void updateVariIcons()
		{
			this.fixedButton1.ImageNorm = GFXLibrary.catagory_icons_points_normal;
			this.fixedButton1.ImageOver = GFXLibrary.catagory_icons_points_over;
			this.fixedButton1.ImageClick = GFXLibrary.catagory_icons_points_pushed;
			this.fixedButton2.ImageNorm = GFXLibrary.catagory_icons_rank_normal;
			this.fixedButton2.ImageOver = GFXLibrary.catagory_icons_rank_over;
			this.fixedButton2.ImageClick = GFXLibrary.catagory_icons_rank_pushed;
			this.fixedButton3.ImageNorm = GFXLibrary.catagory_icons_villages_normal;
			this.fixedButton3.ImageOver = GFXLibrary.catagory_icons_villages_over;
			this.fixedButton3.ImageClick = GFXLibrary.catagory_icons_villages_pushed;
			this.fixedButton4.ImageNorm = GFXLibrary.catagory_icons_factions_normal;
			this.fixedButton4.ImageOver = GFXLibrary.catagory_icons_factions_over;
			this.fixedButton4.ImageClick = GFXLibrary.catagory_icons_factions_pushed;
			this.fixedButton5.ImageNorm = GFXLibrary.catagory_icons_houses_normal;
			this.fixedButton5.ImageOver = GFXLibrary.catagory_icons_houses_over;
			this.fixedButton5.ImageClick = GFXLibrary.catagory_icons_houses_pushed;
			this.fixedButton7.ImageNorm = GFXLibrary.catagory_icons_parishflags_normal;
			this.fixedButton7.ImageOver = GFXLibrary.catagory_icons_parishflags_over;
			this.fixedButton7.ImageClick = GFXLibrary.catagory_icons_parishflags_pushed;
			for (int i = 0; i < 10; i++)
			{
				CustomSelfDrawPanel.CSDButton variButton = this.getVariButton(i);
				this.setButtonGFX(variButton, i + this.categoryScrollPos);
			}
			if (this.currentCategory < 0)
			{
				switch (this.currentCategory)
				{
				case -6:
					this.fixedButton3.ImageNorm = GFXLibrary.catagory_icons_villages_pushed;
					this.fixedButton3.ImageOver = GFXLibrary.catagory_icons_villages_pushed;
					this.fixedButton3.ImageClick = GFXLibrary.catagory_icons_villages_pushed;
					break;
				case -5:
					this.fixedButton2.ImageNorm = GFXLibrary.catagory_icons_rank_pushed;
					this.fixedButton2.ImageOver = GFXLibrary.catagory_icons_rank_pushed;
					this.fixedButton2.ImageClick = GFXLibrary.catagory_icons_rank_pushed;
					break;
				case -4:
					this.fixedButton7.ImageNorm = GFXLibrary.catagory_icons_parishflags_pushed;
					this.fixedButton7.ImageOver = GFXLibrary.catagory_icons_parishflags_pushed;
					this.fixedButton7.ImageClick = GFXLibrary.catagory_icons_parishflags_pushed;
					break;
				case -3:
					this.fixedButton5.ImageNorm = GFXLibrary.catagory_icons_houses_pushed;
					this.fixedButton5.ImageOver = GFXLibrary.catagory_icons_houses_pushed;
					this.fixedButton5.ImageClick = GFXLibrary.catagory_icons_houses_pushed;
					break;
				case -2:
					this.fixedButton4.ImageNorm = GFXLibrary.catagory_icons_factions_pushed;
					this.fixedButton4.ImageOver = GFXLibrary.catagory_icons_factions_pushed;
					this.fixedButton4.ImageClick = GFXLibrary.catagory_icons_factions_pushed;
					break;
				case -1:
					this.fixedButton1.ImageNorm = GFXLibrary.catagory_icons_points_pushed;
					this.fixedButton1.ImageOver = GFXLibrary.catagory_icons_points_pushed;
					this.fixedButton1.ImageClick = GFXLibrary.catagory_icons_points_pushed;
					break;
				}
			}
			if (this.categoryScrollPos <= 0)
			{
				this.variButtonLeft.Enabled = false;
			}
			else
			{
				this.variButtonLeft.Enabled = true;
			}
			if (this.categoryScrollPos >= this.numVariCats)
			{
				this.variButtonRight.Enabled = false;
				return;
			}
			this.variButtonRight.Enabled = true;
		}

		// Token: 0x06002AA1 RID: 10913 RVA: 0x002130E8 File Offset: 0x002112E8
		private CustomSelfDrawPanel.CSDButton getVariButton(int i)
		{
			switch (i)
			{
			case 0:
				return this.variButton1;
			case 1:
				return this.variButton2;
			case 2:
				return this.variButton3;
			case 3:
				return this.variButton4;
			case 4:
				return this.variButton5;
			case 5:
				return this.variButton6;
			case 6:
				return this.variButton7;
			case 7:
				return this.variButton8;
			case 8:
				return this.variButton9;
			case 9:
				return this.variButton10;
			default:
				return this.variButton1;
			}
		}

		// Token: 0x06002AA2 RID: 10914 RVA: 0x00213174 File Offset: 0x00211374
		public void setButtonGFX(CustomSelfDrawPanel.CSDButton button, int position)
		{
			int num = button.CustomTooltipData = this.mapVariButtonPositionToType(position);
			BaseImage b = null;
			BaseImage b2 = null;
			BaseImage b3 = null;
			button.Enabled = true;
			switch (num)
			{
			case 0:
				b = GFXLibrary.catagory_icons_pillager_normal;
				b2 = GFXLibrary.catagory_icons_pillager_over;
				b3 = GFXLibrary.catagory_icons_pillager_pushed;
				break;
			case 1:
				b = GFXLibrary.catagory_icons_defender_normal;
				b2 = GFXLibrary.catagory_icons_defender_over;
				b3 = GFXLibrary.catagory_icons_defender_pushed;
				break;
			case 2:
				b = GFXLibrary.catagory_icons_destroyer_normal;
				b2 = GFXLibrary.catagory_icons_destroyer_over;
				b3 = GFXLibrary.catagory_icons_destroyer_pushed;
				break;
			case 3:
				b = GFXLibrary.catagory_icons_wolfbane_normal;
				b2 = GFXLibrary.catagory_icons_wolfbane_over;
				b3 = GFXLibrary.catagory_icons_wolfbane_pushed;
				break;
			case 4:
				b = GFXLibrary.catagory_icons_banditslayer_normal;
				b2 = GFXLibrary.catagory_icons_banditslayer_over;
				b3 = GFXLibrary.catagory_icons_banditslayer_pushed;
				break;
			case 5:
				b = GFXLibrary.catagory_icons_aikiller_normal;
				b2 = GFXLibrary.catagory_icons_aikiller_over;
				b3 = GFXLibrary.catagory_icons_aikiller_pushed;
				break;
			case 6:
				b = GFXLibrary.catagory_icons_merchant_normal;
				b2 = GFXLibrary.catagory_icons_merchant_over;
				b3 = GFXLibrary.catagory_icons_merchant_pushed;
				break;
			case 7:
				b = GFXLibrary.catagory_icons_forger_normal;
				b2 = GFXLibrary.catagory_icons_forger_over;
				b3 = GFXLibrary.catagory_icons_forger_pushed;
				break;
			case 8:
				b = GFXLibrary.catagory_icons_worker_normal;
				b2 = GFXLibrary.catagory_icons_worker_over;
				b3 = GFXLibrary.catagory_icons_worker_pushed;
				break;
			case 9:
				b = GFXLibrary.catagory_icons_farmer_normal;
				b2 = GFXLibrary.catagory_icons_farmer_over;
				b3 = GFXLibrary.catagory_icons_farmer_pushed;
				break;
			case 10:
				b = GFXLibrary.catagory_icons_brewer_normal;
				b2 = GFXLibrary.catagory_icons_brewer_over;
				b3 = GFXLibrary.catagory_icons_brewer_pushed;
				break;
			case 11:
				b = GFXLibrary.catagory_icons_blacksmith_normal;
				b2 = GFXLibrary.catagory_icons_blacksmith_over;
				b3 = GFXLibrary.catagory_icons_blacksmith_pushed;
				break;
			case 12:
				b = GFXLibrary.catagory_icons_banquet_normal;
				b2 = GFXLibrary.catagory_icons_banquet_over;
				b3 = GFXLibrary.catagory_icons_banquet_pushed;
				break;
			case 13:
				b = GFXLibrary.catagory_icons_achiever_normal;
				b2 = GFXLibrary.catagory_icons_achiever_over;
				b3 = GFXLibrary.catagory_icons_achiever_pushed;
				break;
			case 14:
				b = GFXLibrary.catagory_icons_donator_normal;
				b2 = GFXLibrary.catagory_icons_donator_over;
				b3 = GFXLibrary.catagory_icons_donator_pushed;
				break;
			case 15:
				b = GFXLibrary.catagory_icons_capture_normal;
				b2 = GFXLibrary.catagory_icons_capture_over;
				b3 = GFXLibrary.catagory_icons_capture_pushed;
				break;
			case 16:
				b = GFXLibrary.catagory_icons_raze_normal;
				b2 = GFXLibrary.catagory_icons_raze_over;
				b3 = GFXLibrary.catagory_icons_raze_pushed;
				break;
			case 17:
				b = GFXLibrary.catagory_icons_glory_normal;
				b2 = GFXLibrary.catagory_icons_glory_over;
				b3 = GFXLibrary.catagory_icons_glory_pushed;
				break;
			case 18:
				b = GFXLibrary.catagory_icons_killstreak_normal;
				b2 = GFXLibrary.catagory_icons_killstreak_over;
				b3 = GFXLibrary.catagory_icons_killstreak_pushed;
				break;
			}
			if (num == this.currentCategory)
			{
				button.ImageNorm = b3;
				button.ImageOver = b3;
				button.ImageClick = b3;
			}
			else
			{
				button.ImageNorm = b;
				button.ImageOver = b2;
				button.ImageClick = b3;
			}
			this.categoryLabel.Text = StatsPanel.getCategoryTitle(this.currentCategory);
			this.categoryDescription.Text = StatsPanel.getCategoryDescription(this.currentCategory);
			Graphics graphics = base.CreateGraphics();
			Size size = graphics.MeasureString(this.categoryLabel.Text, this.categoryLabel.Font, 100000).ToSize();
			graphics.Dispose();
			this.categoryDescription.Position = new Point(this.categoryLabel.X + size.Width + 5, this.categoryDescription.Y);
		}

		// Token: 0x06002AA3 RID: 10915 RVA: 0x00213484 File Offset: 0x00211684
		public void categoryClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				int data = csdbutton.Data;
				int num = this.currentCategory;
				if (data < 0)
				{
					this.currentCategory = data;
				}
				else
				{
					this.currentCategory = this.mapVariButtonPositionToType(data + this.categoryScrollPos);
				}
				if (num != this.currentCategory)
				{
					GameEngine.Instance.playInterfaceSound("StatsPanel_category_changed");
					this.updateVariIcons();
					this.newCategory();
				}
			}
		}

		// Token: 0x06002AA4 RID: 10916 RVA: 0x0001F6EA File Offset: 0x0001D8EA
		public void changeCategory(int category)
		{
			if (category != this.currentCategory)
			{
				this.currentCategory = category;
				this.updateVariIcons();
				this.newCategory();
			}
		}

		// Token: 0x06002AA5 RID: 10917 RVA: 0x0001F708 File Offset: 0x0001D908
		public void categoryLeftClicked()
		{
			if (this.categoryScrollPos > 0)
			{
				this.categoryScrollPos--;
				this.updateVariIcons();
			}
		}

		// Token: 0x06002AA6 RID: 10918 RVA: 0x0001F727 File Offset: 0x0001D927
		public void categoryRightClicked()
		{
			if (this.categoryScrollPos < this.numVariCats)
			{
				this.categoryScrollPos++;
				this.updateVariIcons();
			}
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x0001F74B File Offset: 0x0001D94B
		public int mapVariButtonPositionToType(int position)
		{
			return position;
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x002134F8 File Offset: 0x002116F8
		public void update()
		{
			if (this.currentUserLine == -1000 && GameEngine.Instance.World.isLeaderboardCategoryPopulated(this.currentCategory))
			{
				int maxLeaderboardEntries = GameEngine.Instance.World.getMaxLeaderboardEntries(this.currentCategory);
				this.currentUserLine = GameEngine.Instance.World.findSelfInLeaderboard(this.currentCategory) - StatsPanel.NUM_VISIBLE_LINES / 2;
				if (this.currentUserLine > maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1))
				{
					this.currentUserLine = maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1);
				}
				if (this.currentUserLine < 1)
				{
					this.currentUserLine = 1;
				}
				this.updateEntries();
			}
			this.mainEntry1.update();
			this.mainEntry2.update();
			this.mainEntry3.update();
			this.mainEntry4.update();
			this.mainEntry5.update();
			this.mainEntry6.update();
			this.mainEntry7.update();
			this.mainEntry8.update();
			this.mainEntry9.update();
			if (StatsPanel.NUM_VISIBLE_LINES >= 10)
			{
				this.mainEntry10.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 11)
			{
				this.mainEntry11.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 12)
			{
				this.mainEntry12.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 13)
			{
				this.mainEntry13.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 14)
			{
				this.mainEntry14.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 15)
			{
				this.mainEntry15.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 16)
			{
				this.mainEntry16.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 17)
			{
				this.mainEntry17.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 18)
			{
				this.mainEntry18.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 19)
			{
				this.mainEntry19.update();
			}
			if (StatsPanel.NUM_VISIBLE_LINES >= 20)
			{
				this.mainEntry20.update();
			}
			this.topEntry1.update();
			this.topEntry2.update();
			this.topEntry3.update();
			if (this.numExtraTopLines > 0)
			{
				this.topEntry4.update();
			}
			if (this.numExtraTopLines > 1)
			{
				this.topEntry5.update();
			}
			if (this.numExtraTopLines > 2)
			{
				this.topEntry6.update();
			}
			if (this.numExtraTopLines > 3)
			{
				this.topEntry7.update();
			}
			if (this.initialTextInTextbox || this.searchInput.Text.Length < 4 || this.currentCategory == -2 || this.currentCategory == -3 || this.currentCategory == -4 || GameEngine.Instance.World.downloadingLeaderboard())
			{
				if (this.currentCategory == -4 || this.currentCategory == -3 || this.currentCategory == -2 || GameEngine.Instance.World.downloadingLeaderboard())
				{
					this.searchButton.Enabled = false;
				}
				else if (this.initialTextInTextbox || this.searchInput.Text.Length == 0)
				{
					this.searchButton.Enabled = true;
				}
				else
				{
					this.searchButton.Enabled = false;
				}
			}
			else
			{
				this.searchButton.Enabled = true;
			}
			this.clearSearchButton.Visible = this.inSearchResults;
			if (GameEngine.Instance.World.downloadingLeaderboard())
			{
				this.topButton.Enabled = false;
				this.upButton.Enabled = false;
				this.downButton.Enabled = false;
				this.bottomButton.Enabled = false;
			}
			else
			{
				this.topButton.Enabled = true;
				this.upButton.Enabled = true;
				this.downButton.Enabled = true;
				this.bottomButton.Enabled = true;
			}
			DateTime lastLeaderboardUpdate = GameEngine.Instance.World.getLastLeaderboardUpdate();
			if (lastLeaderboardUpdate == DateTime.MinValue)
			{
				this.updateLabel.Visible = false;
			}
			else
			{
				this.updateLabel.Visible = true;
				this.updateLabel.Text = string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Last_Updated", "last updated"),
					"   :   ",
					lastLeaderboardUpdate.ToShortDateString(),
					":",
					lastLeaderboardUpdate.ToShortTimeString(),
					")"
				});
			}
			if (GameEngine.Instance.World.areSelfStandingsDirty())
			{
				this.selfEntry1.init(0, this);
				this.selfEntry2.init(1, this);
				this.selfEntry3.init(2, this);
				this.selfEntry4.init(3, this);
				this.selfEntry5.init(4, this);
				this.selfEntry6.init(5, this);
				this.selfEntry7.init(6, this);
			}
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x00213998 File Offset: 0x00211B98
		public void newCategory()
		{
			this.inSearchResults = false;
			if (GameEngine.Instance.World.isLeaderboardCategoryPopulated(this.currentCategory))
			{
				this.currentUserLine = GameEngine.Instance.World.findSelfInLeaderboard(this.currentCategory) - StatsPanel.NUM_VISIBLE_LINES / 2;
				int maxLeaderboardEntries = GameEngine.Instance.World.getMaxLeaderboardEntries(this.currentCategory);
				if (this.currentUserLine > maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1))
				{
					this.currentUserLine = maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1);
				}
				if (this.currentUserLine < 1)
				{
					this.currentUserLine = 1;
				}
			}
			else
			{
				this.currentUserLine = -1000;
			}
			this.updateEntries();
		}

		// Token: 0x06002AAA RID: 10922 RVA: 0x00213A40 File Offset: 0x00211C40
		public void updateEntries()
		{
			if (!this.inSearchResults)
			{
				this.mainEntry1.init(this.currentCategory, this.currentUserLine, 0);
				this.mainEntry2.init(this.currentCategory, this.currentUserLine + 1, 1);
				this.mainEntry3.init(this.currentCategory, this.currentUserLine + 2, 2);
				this.mainEntry4.init(this.currentCategory, this.currentUserLine + 3, 3);
				this.mainEntry5.init(this.currentCategory, this.currentUserLine + 4, 4);
				this.mainEntry6.init(this.currentCategory, this.currentUserLine + 5, 5);
				this.mainEntry7.init(this.currentCategory, this.currentUserLine + 6, 6);
				this.mainEntry8.init(this.currentCategory, this.currentUserLine + 7, 7);
				this.mainEntry9.init(this.currentCategory, this.currentUserLine + 8, 8);
				if (StatsPanel.NUM_VISIBLE_LINES >= 10)
				{
					this.mainEntry10.init(this.currentCategory, this.currentUserLine + 9, 9);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 11)
				{
					this.mainEntry11.init(this.currentCategory, this.currentUserLine + 10, 10);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 12)
				{
					this.mainEntry12.init(this.currentCategory, this.currentUserLine + 11, 11);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 13)
				{
					this.mainEntry13.init(this.currentCategory, this.currentUserLine + 12, 12);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 14)
				{
					this.mainEntry14.init(this.currentCategory, this.currentUserLine + 13, 13);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 15)
				{
					this.mainEntry15.init(this.currentCategory, this.currentUserLine + 14, 14);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 16)
				{
					this.mainEntry16.init(this.currentCategory, this.currentUserLine + 15, 15);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 17)
				{
					this.mainEntry17.init(this.currentCategory, this.currentUserLine + 16, 16);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 18)
				{
					this.mainEntry18.init(this.currentCategory, this.currentUserLine + 17, 17);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 19)
				{
					this.mainEntry19.init(this.currentCategory, this.currentUserLine + 18, 18);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 20)
				{
					this.mainEntry20.init(this.currentCategory, this.currentUserLine + 19, 19);
				}
			}
			else
			{
				this.mainEntry1.init(this.currentCategory, this.getSearchEntry(this.searchLocation), 0);
				this.mainEntry2.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 1), 1);
				this.mainEntry3.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 2), 2);
				this.mainEntry4.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 3), 3);
				this.mainEntry5.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 4), 4);
				this.mainEntry6.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 5), 5);
				this.mainEntry7.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 6), 6);
				this.mainEntry8.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 7), 7);
				this.mainEntry9.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 8), 8);
				if (StatsPanel.NUM_VISIBLE_LINES >= 10)
				{
					this.mainEntry10.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 9), 9);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 11)
				{
					this.mainEntry11.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 10), 10);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 12)
				{
					this.mainEntry12.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 11), 11);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 13)
				{
					this.mainEntry13.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 12), 12);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 14)
				{
					this.mainEntry14.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 13), 13);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 15)
				{
					this.mainEntry15.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 14), 14);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 16)
				{
					this.mainEntry16.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 15), 15);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 17)
				{
					this.mainEntry17.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 16), 16);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 18)
				{
					this.mainEntry18.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 17), 17);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 19)
				{
					this.mainEntry19.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 18), 18);
				}
				if (StatsPanel.NUM_VISIBLE_LINES >= 20)
				{
					this.mainEntry20.init(this.currentCategory, this.getSearchEntry(this.searchLocation + 19), 19);
				}
			}
			this.topEntry1.init(this.currentCategory, 1, 0);
			this.topEntry2.init(this.currentCategory, 2, 1);
			this.topEntry3.init(this.currentCategory, 3, 2);
			if (this.numExtraTopLines > 0)
			{
				this.topEntry4.init(this.currentCategory, 4, 3);
			}
			if (this.numExtraTopLines > 1)
			{
				this.topEntry5.init(this.currentCategory, 5, 4);
			}
			if (this.numExtraTopLines > 2)
			{
				this.topEntry6.init(this.currentCategory, 6, 5);
			}
			if (this.numExtraTopLines > 3)
			{
				this.topEntry7.init(this.currentCategory, 7, 6);
			}
		}

		// Token: 0x06002AAB RID: 10923 RVA: 0x00214080 File Offset: 0x00212280
		public void scrollToTopClicked()
		{
			if (GameEngine.Instance.World.downloadingLeaderboard())
			{
				return;
			}
			if (!this.inSearchResults)
			{
				if (this.currentUserLine != 1)
				{
					this.currentUserLine = 1;
					this.updateEntries();
					return;
				}
			}
			else if (this.searchLocation != 0)
			{
				this.searchLocation = 0;
				this.updateEntries();
			}
		}

		// Token: 0x06002AAC RID: 10924 RVA: 0x002140D4 File Offset: 0x002122D4
		public void scrollUpClicked()
		{
			if (GameEngine.Instance.World.downloadingLeaderboard())
			{
				return;
			}
			if (!this.inSearchResults)
			{
				int num = this.currentUserLine;
				num -= StatsPanel.NUM_VISIBLE_LINES;
				if (num < 1)
				{
					num = 1;
				}
				if (num != this.currentUserLine)
				{
					this.currentUserLine = num;
					this.updateEntries();
					if (!GameEngine.Instance.World.downloadingLeaderboard() && num != 1)
					{
						GameEngine.Instance.World.leaderboardLookHigher(this.currentCategory, num, StatsPanel.NUM_VISIBLE_LINES);
						return;
					}
				}
			}
			else
			{
				int num2 = this.searchLocation;
				num2 -= StatsPanel.NUM_VISIBLE_LINES;
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num2 != this.searchLocation)
				{
					this.searchLocation = num2;
					this.updateEntries();
				}
			}
		}

		// Token: 0x06002AAD RID: 10925 RVA: 0x00214184 File Offset: 0x00212384
		public void scrollDownClicked()
		{
			if (GameEngine.Instance.World.downloadingLeaderboard())
			{
				return;
			}
			if (!this.inSearchResults)
			{
				int maxLeaderboardEntries = GameEngine.Instance.World.getMaxLeaderboardEntries(this.currentCategory);
				int num = this.currentUserLine;
				num += StatsPanel.NUM_VISIBLE_LINES;
				if (num > maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1))
				{
					num = maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1);
				}
				if (num < 1)
				{
					num = 1;
				}
				if (num != this.currentUserLine)
				{
					this.currentUserLine = num;
					this.updateEntries();
					if (!GameEngine.Instance.World.downloadingLeaderboard())
					{
						GameEngine.Instance.World.leaderboardLookLower(this.currentCategory, num, StatsPanel.NUM_VISIBLE_LINES);
					}
				}
				return;
			}
			int num2 = this.getMaxSearchResults() - 1;
			int num3 = this.searchLocation;
			num3 += StatsPanel.NUM_VISIBLE_LINES;
			if (num3 > num2 - StatsPanel.NUM_VISIBLE_LINES)
			{
				num3 = num2 - (StatsPanel.NUM_VISIBLE_LINES - 1);
				if (num3 < 0)
				{
					num3 = 0;
				}
			}
			if (num3 != this.searchLocation)
			{
				this.searchLocation = num3;
				this.updateEntries();
			}
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x0021427C File Offset: 0x0021247C
		public void scrollToBottomClicked()
		{
			if (GameEngine.Instance.World.downloadingLeaderboard())
			{
				return;
			}
			if (!this.inSearchResults)
			{
				int maxLeaderboardEntries = GameEngine.Instance.World.getMaxLeaderboardEntries(this.currentCategory);
				if (maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1) != this.currentUserLine)
				{
					this.currentUserLine = maxLeaderboardEntries - (StatsPanel.NUM_VISIBLE_LINES - 1);
					if (this.currentUserLine > 1)
					{
						this.updateEntries();
						return;
					}
					this.currentUserLine = 1;
				}
				return;
			}
			int num = this.getMaxSearchResults() - 1;
			if (num - (StatsPanel.NUM_VISIBLE_LINES - 1) != this.searchLocation)
			{
				this.searchLocation = num - (StatsPanel.NUM_VISIBLE_LINES - 1);
				if (this.searchLocation < 0)
				{
					this.searchLocation = 0;
				}
				this.updateEntries();
			}
		}

		// Token: 0x06002AAF RID: 10927 RVA: 0x00214330 File Offset: 0x00212530
		public static string getCategoryTitle(int category)
		{
			switch (category)
			{
			case -6:
				return SK.Text("STATS_CATEGORY_TITLE_NUMVILLAGES", "Villages");
			case -5:
				return SK.Text("STATS_CATEGORY_TITLE_RANK", "Rank");
			case -4:
				return SK.Text("STATS_CATEGORY_TITLE_PARISH_FLAGS", "Parish Flags");
			case -3:
				return SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House");
			case -2:
				return SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction");
			case -1:
				return SK.Text("STATS_CATEGORY_TITLE_POINTS", "Points");
			case 0:
				return SK.Text("STATS_CATEGORY_TITLE_PILLAGER", "Pillager");
			case 1:
				return SK.Text("STATS_CATEGORY_TITLE_DEFENDER", "Defender");
			case 2:
				return SK.Text("STATS_CATEGORY_TITLE_DESTROYER", "Destroyer");
			case 3:
				return SK.Text("STATS_CATEGORY_TITLE_WOLFSBANE", "Wolfs Bane");
			case 4:
				return SK.Text("STATS_CATEGORY_TITLE_BANDIT_KILLER", "Bandit Killer");
			case 5:
				return SK.Text("STATS_CATEGORY_TITLE_AI_KILLER", "AI Killer");
			case 6:
				return SK.Text("STATS_CATEGORY_TITLE_MERCHANT", "Merchant");
			case 7:
				return SK.Text("STATS_CATEGORY_TITLE_FORAGER", "Forager");
			case 8:
				return SK.Text("STATS_CATEGORY_TITLE_WORKER", "Worker");
			case 9:
				return SK.Text("STATS_CATEGORY_TITLE_FARMER", "Farmer");
			case 10:
				return SK.Text("STATS_CATEGORY_TITLE_BREWER", "Brewer");
			case 11:
				return SK.Text("STATS_CATEGORY_TITLE_WEAPONSMITH", "Weaponsmith");
			case 12:
				return SK.Text("STATS_CATEGORY_TITLE_BANQUETTER", "Banquetter");
			case 13:
				return SK.Text("STATS_CATEGORY_TITLE_QUESTER", "Quester");
			case 14:
				return SK.Text("STATS_CATEGORY_TITLE_DONATER", "Donator");
			case 15:
				return SK.Text("STATS_CATEGORY_TITLE_CAPTURE", "Conqueror");
			case 16:
				return SK.Text("STATS_CATEGORY_TITLE_RAZE", "Annihilator");
			case 17:
				return SK.Text("STATS_CATEGORY_TITLE_GLORY", "Glory Hunter");
			case 18:
				return SK.Text("STATS_CATEGORY_TITLE_KILL_STREAK", "Crusader");
			default:
				return "";
			}
		}

		// Token: 0x06002AB0 RID: 10928 RVA: 0x00214544 File Offset: 0x00212744
		public static string getCategoryDescription(int category)
		{
			switch (category)
			{
			case -6:
				return SK.Text("Stats_Most_Villages_Owned", "Most Villages owned");
			case -5:
				return SK.Text("Stats_Highest_Rank", "Highest Rank");
			case -4:
				return SK.Text("Stats_Most_Parish_Flags", "Most Parish Flags");
			case -3:
				return SK.Text("Stats_Most_House_Points", "Most House Points");
			case -2:
				return SK.Text("Stats_Most_Faction_Points", "Most Faction Points");
			case -1:
				return SK.Text("Stats_Most_Points", "Most points");
			case 0:
				return SK.Text("Stats_Most_Pillaged", "Most goods pillaged from others");
			case 1:
				return SK.Text("Stats_Most_Invaders_Killed", "Most invading troops killed at the castle walls");
			case 2:
				return SK.Text("Stats_Most_Ransacked", "Most buildings ransacked in someone else's castle");
			case 3:
				return SK.Text("Stats_Most_Wolves_Killed", "Most wolves killed");
			case 4:
				return SK.Text("Stats_Most_Bandits_Killed", "Most bandits killed");
			case 5:
				return SK.Text("Stats_Most_AI_Killed", "Most AI Troops Killed");
			case 6:
				return SK.Text("Stats_Most_Goods_Traded", "Most goods traded");
			case 7:
				return SK.Text("Stats_Most_Goods_Scouted", "Most goods scouted from the map");
			case 8:
				return SK.Text("Stats_Most_Stockpike_Goods", "Most stockpile goods produced (updated daily)");
			case 9:
				return SK.Text("Stats_Most_Food_Produced", "Most foods produced (updated daily)");
			case 10:
				return SK.Text("Stats_Most_Ale_Produced", "Most Ale produced (updated daily)");
			case 11:
				return SK.Text("Stats_Most_Weapons_Produced", "Most weapons produced (updated daily)");
			case 12:
				return SK.Text("Stats_Most_Banquetting_Oroduced", "Most banqueting goods produced (updated daily)");
			case 13:
				return SK.Text("Stats_Most_Quests_Completed", "Most Quests Completed");
			case 14:
				return SK.Text("Stats_Most_Dontations", "Most Capital Donations (as 'Packets')");
			case 15:
				return SK.Text("Stats_Most_Captures", "Most Villages Captured");
			case 16:
				return SK.Text("Stats_Most_Razes", "Most Villages Razed");
			case 17:
				return SK.Text("Stats_Most_Glory", "Most Glory Gained");
			case 18:
				return SK.Text("Stats_Most_KillStreak", "Longest Kill Streak");
			default:
				return "";
			}
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0001F74E File Offset: 0x0001D94E
		private void searchInput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.searchClicked();
				e.Handled = true;
			}
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0001F767 File Offset: 0x0001D967
		private void searchInput_Enter(object sender, EventArgs e)
		{
			if (this.initialTextInTextbox)
			{
				this.initialTextInTextbox = false;
				this.searchInput.Text = "";
			}
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x00214758 File Offset: 0x00212958
		public void searchClicked()
		{
			if (!GameEngine.Instance.World.downloadingLeaderboard())
			{
				if (this.searchInput.Text.Length >= 4 && this.currentCategory != -3 && this.currentCategory != -4 && !this.initialTextInTextbox)
				{
					GameEngine.Instance.World.leaderboardSearch(this.currentCategory, this.searchInput.Text);
					return;
				}
				if (this.initialTextInTextbox || this.searchInput.Text.Length == 0)
				{
					this.inSearchResults = false;
					this.updateEntries();
				}
			}
		}

		// Token: 0x06002AB4 RID: 10932 RVA: 0x0001F788 File Offset: 0x0001D988
		public void searchComplete(LeaderBoardSearchResults results)
		{
			this.m_results = results;
			this.inSearchResults = true;
			this.searchLocation = 0;
			this.currentUserLine = 1;
			this.updateEntries();
		}

		// Token: 0x06002AB5 RID: 10933 RVA: 0x0001F7AC File Offset: 0x0001D9AC
		private int getSearchEntry(int entryID)
		{
			if (entryID >= this.m_results.entries.Count)
			{
				return -999999;
			}
			return this.m_results.entries[entryID];
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		private int getMaxSearchResults()
		{
			return this.m_results.entries.Count;
		}

		// Token: 0x06002AB7 RID: 10935 RVA: 0x0001F7EA File Offset: 0x0001D9EA
		private void clearSearchClicked()
		{
			this.clearSearchButton.Visible = false;
			this.inSearchResults = false;
			this.updateEntries();
		}

		// Token: 0x04003484 RID: 13444
		public const int MIN_TEXT_LENGTH_FOR_SEARCH = 4;

		// Token: 0x04003485 RID: 13445
		private DockableControl dockableControl;

		// Token: 0x04003486 RID: 13446
		private IContainer components;

		// Token: 0x04003487 RID: 13447
		private TextBox searchInput;

		// Token: 0x04003488 RID: 13448
		private Panel focusPanel;

		// Token: 0x04003489 RID: 13449
		public static int NUM_VISIBLE_LINES = 9;

		// Token: 0x0400348A RID: 13450
		private bool initialTextInTextbox = true;

		// Token: 0x0400348B RID: 13451
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400348C RID: 13452
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400348D RID: 13453
		private CustomSelfDrawPanel.CSDLabel categoryLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400348E RID: 13454
		private CustomSelfDrawPanel.CSDLabel categoryDescription = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400348F RID: 13455
		private CustomSelfDrawPanel.CSDImage mainInsetTopTopImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003490 RID: 13456
		private CustomSelfDrawPanel.CSDImage mainInsetTopMiddleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003491 RID: 13457
		private CustomSelfDrawPanel.CSDImage mainInsetTopBottomImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003492 RID: 13458
		private CustomSelfDrawPanel.CSDImage mainInsetMidImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003493 RID: 13459
		private CustomSelfDrawPanel.CSDImage mainInsetBottomImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003494 RID: 13460
		private CustomSelfDrawPanel.CSDVertExtendingPanel secondInsetImage = new CustomSelfDrawPanel.CSDVertExtendingPanel();

		// Token: 0x04003495 RID: 13461
		private CustomSelfDrawPanel.CSDImage searchInsetImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003496 RID: 13462
		private CustomSelfDrawPanel.CSDButton searchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003497 RID: 13463
		private CustomSelfDrawPanel.CSDHorzExtendingPanel fixedIconBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003498 RID: 13464
		private CustomSelfDrawPanel.CSDHorzExtendingPanel scrollIconBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04003499 RID: 13465
		private CustomSelfDrawPanel.CSDButton fixedButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349A RID: 13466
		private CustomSelfDrawPanel.CSDButton fixedButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349B RID: 13467
		private CustomSelfDrawPanel.CSDButton fixedButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349C RID: 13468
		private CustomSelfDrawPanel.CSDButton fixedButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349D RID: 13469
		private CustomSelfDrawPanel.CSDButton fixedButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349E RID: 13470
		private CustomSelfDrawPanel.CSDButton fixedButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400349F RID: 13471
		private CustomSelfDrawPanel.CSDImage fixedBarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040034A0 RID: 13472
		private CustomSelfDrawPanel.CSDButton variButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A1 RID: 13473
		private CustomSelfDrawPanel.CSDButton variButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A2 RID: 13474
		private CustomSelfDrawPanel.CSDButton variButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A3 RID: 13475
		private CustomSelfDrawPanel.CSDButton variButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A4 RID: 13476
		private CustomSelfDrawPanel.CSDButton variButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A5 RID: 13477
		private CustomSelfDrawPanel.CSDButton variButton6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A6 RID: 13478
		private CustomSelfDrawPanel.CSDButton variButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A7 RID: 13479
		private CustomSelfDrawPanel.CSDButton variButton8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A8 RID: 13480
		private CustomSelfDrawPanel.CSDButton variButton9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034A9 RID: 13481
		private CustomSelfDrawPanel.CSDButton variButton10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034AA RID: 13482
		private CustomSelfDrawPanel.CSDButton variButtonLeft = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034AB RID: 13483
		private CustomSelfDrawPanel.CSDButton variButtonRight = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034AC RID: 13484
		private StatsPanel.StatsEntry mainEntry1 = new StatsPanel.StatsEntry();

		// Token: 0x040034AD RID: 13485
		private StatsPanel.StatsEntry mainEntry2 = new StatsPanel.StatsEntry();

		// Token: 0x040034AE RID: 13486
		private StatsPanel.StatsEntry mainEntry3 = new StatsPanel.StatsEntry();

		// Token: 0x040034AF RID: 13487
		private StatsPanel.StatsEntry mainEntry4 = new StatsPanel.StatsEntry();

		// Token: 0x040034B0 RID: 13488
		private StatsPanel.StatsEntry mainEntry5 = new StatsPanel.StatsEntry();

		// Token: 0x040034B1 RID: 13489
		private StatsPanel.StatsEntry mainEntry6 = new StatsPanel.StatsEntry();

		// Token: 0x040034B2 RID: 13490
		private StatsPanel.StatsEntry mainEntry7 = new StatsPanel.StatsEntry();

		// Token: 0x040034B3 RID: 13491
		private StatsPanel.StatsEntry mainEntry8 = new StatsPanel.StatsEntry();

		// Token: 0x040034B4 RID: 13492
		private StatsPanel.StatsEntry mainEntry9 = new StatsPanel.StatsEntry();

		// Token: 0x040034B5 RID: 13493
		private StatsPanel.StatsEntry mainEntry10 = new StatsPanel.StatsEntry();

		// Token: 0x040034B6 RID: 13494
		private StatsPanel.StatsEntry mainEntry11 = new StatsPanel.StatsEntry();

		// Token: 0x040034B7 RID: 13495
		private StatsPanel.StatsEntry mainEntry12 = new StatsPanel.StatsEntry();

		// Token: 0x040034B8 RID: 13496
		private StatsPanel.StatsEntry mainEntry13 = new StatsPanel.StatsEntry();

		// Token: 0x040034B9 RID: 13497
		private StatsPanel.StatsEntry mainEntry14 = new StatsPanel.StatsEntry();

		// Token: 0x040034BA RID: 13498
		private StatsPanel.StatsEntry mainEntry15 = new StatsPanel.StatsEntry();

		// Token: 0x040034BB RID: 13499
		private StatsPanel.StatsEntry mainEntry16 = new StatsPanel.StatsEntry();

		// Token: 0x040034BC RID: 13500
		private StatsPanel.StatsEntry mainEntry17 = new StatsPanel.StatsEntry();

		// Token: 0x040034BD RID: 13501
		private StatsPanel.StatsEntry mainEntry18 = new StatsPanel.StatsEntry();

		// Token: 0x040034BE RID: 13502
		private StatsPanel.StatsEntry mainEntry19 = new StatsPanel.StatsEntry();

		// Token: 0x040034BF RID: 13503
		private StatsPanel.StatsEntry mainEntry20 = new StatsPanel.StatsEntry();

		// Token: 0x040034C0 RID: 13504
		private StatsPanel.StatsEntry topEntry1 = new StatsPanel.StatsEntry();

		// Token: 0x040034C1 RID: 13505
		private StatsPanel.StatsEntry topEntry2 = new StatsPanel.StatsEntry();

		// Token: 0x040034C2 RID: 13506
		private StatsPanel.StatsEntry topEntry3 = new StatsPanel.StatsEntry();

		// Token: 0x040034C3 RID: 13507
		private StatsPanel.StatsEntry topEntry4 = new StatsPanel.StatsEntry();

		// Token: 0x040034C4 RID: 13508
		private StatsPanel.StatsEntry topEntry5 = new StatsPanel.StatsEntry();

		// Token: 0x040034C5 RID: 13509
		private StatsPanel.StatsEntry topEntry6 = new StatsPanel.StatsEntry();

		// Token: 0x040034C6 RID: 13510
		private StatsPanel.StatsEntry topEntry7 = new StatsPanel.StatsEntry();

		// Token: 0x040034C7 RID: 13511
		private StatsPanel.SelfStatsEntry selfEntry1 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034C8 RID: 13512
		private StatsPanel.SelfStatsEntry selfEntry2 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034C9 RID: 13513
		private StatsPanel.SelfStatsEntry selfEntry3 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034CA RID: 13514
		private StatsPanel.SelfStatsEntry selfEntry4 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034CB RID: 13515
		private StatsPanel.SelfStatsEntry selfEntry5 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034CC RID: 13516
		private StatsPanel.SelfStatsEntry selfEntry6 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034CD RID: 13517
		private StatsPanel.SelfStatsEntry selfEntry7 = new StatsPanel.SelfStatsEntry();

		// Token: 0x040034CE RID: 13518
		private CustomSelfDrawPanel.CSDButton topButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034CF RID: 13519
		private CustomSelfDrawPanel.CSDButton upButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034D0 RID: 13520
		private CustomSelfDrawPanel.CSDButton downButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034D1 RID: 13521
		private CustomSelfDrawPanel.CSDButton bottomButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034D2 RID: 13522
		private CustomSelfDrawPanel.CSDButton clearSearchButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040034D3 RID: 13523
		private CustomSelfDrawPanel.CSDLabel updateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040034D4 RID: 13524
		private CustomSelfDrawPanel.CSDLabel bestRankingsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040034D5 RID: 13525
		private int categoryScrollPos;

		// Token: 0x040034D6 RID: 13526
		private int currentCategory = -1;

		// Token: 0x040034D7 RID: 13527
		private int currentUserLine = -10000;

		// Token: 0x040034D8 RID: 13528
		private int numExtraTopLines;

		// Token: 0x040034D9 RID: 13529
		private int numVariCats = 8;

		// Token: 0x040034DA RID: 13530
		private bool inSearchResults;

		// Token: 0x040034DB RID: 13531
		private int searchLocation;

		// Token: 0x040034DC RID: 13532
		private LeaderBoardSearchResults m_results = new LeaderBoardSearchResults();

		// Token: 0x02000495 RID: 1173
		public class StatsEntry : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002AB9 RID: 10937 RVA: 0x002147F0 File Offset: 0x002129F0
			public void init(int category, int leaderboardPosition, int screenLocation)
			{
				this.m_category = category;
				this.m_position = leaderboardPosition;
				this.m_screenLine = screenLocation;
				this.m_validData = false;
				LeaderBoardEntryData leaderBoardEntryData = null;
				if (leaderboardPosition != -999999)
				{
					leaderBoardEntryData = GameEngine.Instance.World.getLeaderboardEntry(category, leaderboardPosition, StatsPanel.NUM_VISIBLE_LINES);
					if (leaderBoardEntryData != null)
					{
						this.m_validData = true;
					}
				}
				else
				{
					leaderBoardEntryData = new LeaderBoardEntryData();
					leaderBoardEntryData.dummy = true;
					this.m_validData = true;
				}
				this.clearControls();
				if ((screenLocation & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.int_statsscreen_listbar_darker;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.int_statsscreen_listbar_lighter;
				}
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.houseImage.Image = GFXLibrary.house_flag_001;
				this.houseImage.Position = new Point(68, 0);
				this.houseImage.Visible = false;
				this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.houseImage.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
				this.backgroundImage.addControl(this.houseImage);
				this.playerName.Text = SK.Text("Stats_Getting_Data", "Getting Data");
				this.playerName.Color = global::ARGBColors.Black;
				this.playerName.Position = new Point(129, 0);
				this.playerName.Size = new Size(188, this.backgroundImage.Height);
				this.playerName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.playerName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.playerName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.playerName.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
				this.backgroundImage.addControl(this.playerName);
				this.positionLabel.Text = "0";
				this.positionLabel.Color = global::ARGBColors.Black;
				this.positionLabel.Position = new Point(6, 0);
				this.positionLabel.Size = new Size(56, this.backgroundImage.Height);
				this.positionLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.positionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.positionLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.positionLabel.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
				this.backgroundImage.addControl(this.positionLabel);
				this.valueLabel.Text = "0";
				this.valueLabel.Color = global::ARGBColors.Black;
				this.valueLabel.Position = new Point(9, 0);
				this.valueLabel.Size = new Size(380, this.backgroundImage.Height);
				this.valueLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.valueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.valueLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.valueLabel.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
				this.backgroundImage.addControl(this.valueLabel);
				int num = -1;
				if (leaderBoardEntryData == null)
				{
					return;
				}
				if (!leaderBoardEntryData.dummy)
				{
					this.playerName.Color = global::ARGBColors.Black;
					this.valueLabel.Color = global::ARGBColors.Black;
					this.positionLabel.Color = global::ARGBColors.Black;
					if (this.m_category >= 0 || this.m_category == -1 || this.m_category == -5 || this.m_category == -6)
					{
						if (leaderBoardEntryData.entryID == RemoteServices.Instance.UserID)
						{
							this.playerName.Color = global::ARGBColors.White;
							this.valueLabel.Color = global::ARGBColors.White;
							this.positionLabel.Color = global::ARGBColors.White;
						}
						num = leaderBoardEntryData.entryID;
					}
					else if (this.m_category == -2)
					{
						if (leaderBoardEntryData.entryID == RemoteServices.Instance.UserFactionID)
						{
							this.playerName.Color = global::ARGBColors.White;
							this.valueLabel.Color = global::ARGBColors.White;
							this.positionLabel.Color = global::ARGBColors.White;
						}
					}
					else if (this.m_category == -3)
					{
						if (leaderBoardEntryData.entryID == GameEngine.Instance.World.getHouse(RemoteServices.Instance.UserFactionID))
						{
							this.playerName.Color = global::ARGBColors.White;
							this.valueLabel.Color = global::ARGBColors.White;
							this.positionLabel.Color = global::ARGBColors.White;
						}
					}
					else if (this.m_category == -4)
					{
						List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
						foreach (int villageID in userVillageIDList)
						{
							if (GameEngine.Instance.World.isCapital(villageID))
							{
								if (GameEngine.Instance.World.isRegionCapital(villageID))
								{
									int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(villageID);
									if (leaderBoardEntryData.entryID == parishFromVillageID)
									{
										this.playerName.Color = global::ARGBColors.White;
										this.valueLabel.Color = global::ARGBColors.White;
										this.positionLabel.Color = global::ARGBColors.White;
										break;
									}
								}
							}
							else
							{
								int parishFromVillageID2 = GameEngine.Instance.World.getParishFromVillageID(villageID);
								if (leaderBoardEntryData.entryID == parishFromVillageID2)
								{
									this.playerName.Color = global::ARGBColors.White;
									this.valueLabel.Color = global::ARGBColors.White;
									this.positionLabel.Color = global::ARGBColors.White;
									break;
								}
							}
						}
					}
					this.playerName.Text = leaderBoardEntryData.name;
					NumberFormatInfo nfi = GameEngine.NFI;
					if (this.m_category != -5)
					{
						this.valueLabel.Text = leaderBoardEntryData.value.ToString("N", nfi);
						this.valueLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					}
					else
					{
						int num2 = leaderBoardEntryData.value / 100;
						int rankSubLevel = leaderBoardEntryData.value % 100;
						if (num2 >= 22)
						{
							num2 = 22;
							rankSubLevel = leaderBoardEntryData.value - 2200;
						}
						this.valueLabel.Text = Rankings.getRankingName(GameEngine.Instance.LocalWorldData, num2, rankSubLevel, leaderBoardEntryData.male);
						this.valueLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
						if (Program.mySettings.LanguageIdent == "it")
						{
							this.valueLabel.Position = new Point(269, 0);
							this.valueLabel.Size = new Size(120, this.backgroundImage.Height);
						}
					}
					this.m_entryID = leaderBoardEntryData.entryID;
					this.positionLabel.Text = leaderBoardEntryData.standing.ToString("N", nfi);
					if (leaderBoardEntryData.house > 0)
					{
						this.houseImage.Visible = true;
						switch (leaderBoardEntryData.house)
						{
						case 1:
							this.houseImage.Image = GFXLibrary.house_flag_001;
							break;
						case 2:
							this.houseImage.Image = GFXLibrary.house_flag_002;
							break;
						case 3:
							this.houseImage.Image = GFXLibrary.house_flag_003;
							break;
						case 4:
							this.houseImage.Image = GFXLibrary.house_flag_004;
							break;
						case 5:
							this.houseImage.Image = GFXLibrary.house_flag_005;
							break;
						case 6:
							this.houseImage.Image = GFXLibrary.house_flag_006;
							break;
						case 7:
							this.houseImage.Image = GFXLibrary.house_flag_007;
							break;
						case 8:
							this.houseImage.Image = GFXLibrary.house_flag_008;
							break;
						case 9:
							this.houseImage.Image = GFXLibrary.house_flag_009;
							break;
						case 10:
							this.houseImage.Image = GFXLibrary.house_flag_010;
							break;
						case 11:
							this.houseImage.Image = GFXLibrary.house_flag_011;
							break;
						case 12:
							this.houseImage.Image = GFXLibrary.house_flag_012;
							break;
						case 13:
							this.houseImage.Image = GFXLibrary.house_flag_013;
							break;
						case 14:
							this.houseImage.Image = GFXLibrary.house_flag_014;
							break;
						case 15:
							this.houseImage.Image = GFXLibrary.house_flag_015;
							break;
						case 16:
							this.houseImage.Image = GFXLibrary.house_flag_016;
							break;
						case 17:
							this.houseImage.Image = GFXLibrary.house_flag_017;
							break;
						case 18:
							this.houseImage.Image = GFXLibrary.house_flag_018;
							break;
						case 19:
							this.houseImage.Image = GFXLibrary.house_flag_019;
							break;
						case 20:
							this.houseImage.Image = GFXLibrary.house_flag_020;
							break;
						}
					}
					if (num >= 0 && this.topEntry)
					{
						this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(num, 25, 28);
						if (this.shieldImage.Image != null)
						{
							this.shieldImage.Position = new Point(16, 8);
							this.shieldImage.Visible = true;
							this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
							this.shieldImage.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineRightClicked));
							this.backgroundImage.addControl(this.shieldImage);
							return;
						}
					}
				}
				else
				{
					this.playerName.Text = "";
					this.valueLabel.Text = "";
					this.positionLabel.Text = "";
					this.houseImage.Visible = false;
				}
			}

			// Token: 0x06002ABA RID: 10938 RVA: 0x0001F80E File Offset: 0x0001DA0E
			public void setAsTopEntry()
			{
				this.topEntry = true;
			}

			// Token: 0x06002ABB RID: 10939 RVA: 0x002152B4 File Offset: 0x002134B4
			public void update()
			{
				if (!this.m_validData)
				{
					LeaderBoardEntryData leaderboardEntry = GameEngine.Instance.World.getLeaderboardEntry(this.m_category, this.m_position, StatsPanel.NUM_VISIBLE_LINES);
					if (leaderboardEntry != null)
					{
						this.init(this.m_category, this.m_position, this.m_screenLine);
					}
				}
			}

			// Token: 0x06002ABC RID: 10940 RVA: 0x00215308 File Offset: 0x00213508
			public void lineClicked()
			{
				GameEngine.Instance.playInterfaceSound("StatsPanel_entry_clicked");
				switch (this.m_category)
				{
				case -4:
					return;
				case -3:
					if (this.m_entryID >= 0)
					{
						InterfaceMgr.Instance.showHousePanel(this.m_entryID);
					}
					return;
				case -2:
					if (this.m_entryID >= 0)
					{
						InterfaceMgr.Instance.showFactionPanel(this.m_entryID);
					}
					return;
				default:
					if (this.m_entryID >= 0)
					{
						InterfaceMgr.Instance.changeTab(0);
						WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
						cachedUserInfo.userID = this.m_entryID;
						InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
					}
					return;
				}
			}

			// Token: 0x06002ABD RID: 10941 RVA: 0x002153A8 File Offset: 0x002135A8
			public void lineRightClicked()
			{
				if (base.csd != null && base.csd.ClickedControl != null && base.csd.ClickedControl.Parent != null)
				{
					CustomSelfDrawPanel.CSDControl parent = base.csd.ClickedControl.Parent;
					while (parent != null && parent.GetType() != typeof(StatsPanel.StatsEntry))
					{
						parent = parent.Parent;
					}
					if (parent != null)
					{
						GameEngine.Instance.playInterfaceSound("StatsPanel_entry_clicked");
						CustomSelfDrawPanel.CSDLabel csdlabel = ((StatsPanel.StatsEntry)parent).playerName;
						Clipboard.SetText(csdlabel.Text);
					}
				}
			}

			// Token: 0x040034DD RID: 13533
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034DE RID: 13534
			private CustomSelfDrawPanel.CSDLabel playerName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034DF RID: 13535
			private CustomSelfDrawPanel.CSDLabel positionLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034E0 RID: 13536
			private CustomSelfDrawPanel.CSDLabel valueLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034E1 RID: 13537
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034E2 RID: 13538
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034E3 RID: 13539
			private int m_category = -1000;

			// Token: 0x040034E4 RID: 13540
			private int m_position = -1000;

			// Token: 0x040034E5 RID: 13541
			private int m_screenLine;

			// Token: 0x040034E6 RID: 13542
			private int m_entryID = -1;

			// Token: 0x040034E7 RID: 13543
			private bool m_validData;

			// Token: 0x040034E8 RID: 13544
			private bool topEntry;
		}

		// Token: 0x02000496 RID: 1174
		public class SelfStatsEntry : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06002ABF RID: 10943 RVA: 0x002154A8 File Offset: 0x002136A8
			public void init(int row, StatsPanel parent)
			{
				this.m_parent = parent;
				this.m_position = row;
				LeaderBoardSelfRankings leaderboardBestRanking = GameEngine.Instance.World.getLeaderboardBestRanking(row);
				this.clearControls();
				this.m_category = -1000;
				if (leaderboardBestRanking == null || leaderboardBestRanking.value == 0)
				{
					return;
				}
				if ((row & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.int_statsscreen_secondinset_bar_darker;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.int_statsscreen_secondinset_bar_lighter;
				}
				this.m_category = leaderboardBestRanking.category;
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				NumberFormatInfo nfi = GameEngine.NFI;
				this.amountLine.Text = GameEngine.Instance.World.GetLeaderboardCategoryScore(leaderboardBestRanking.category, leaderboardBestRanking.value, GameEngine.Instance.LocalWorldData);
				this.sectionImage.Image = GFXLibrary.GetLeaderboardCategoryIcon(leaderboardBestRanking.category);
				this.sectionImage.Position = new Point(15, 14);
				this.sectionImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.sectionImage);
				if (leaderboardBestRanking.oldPlace != leaderboardBestRanking.place)
				{
					string text;
					if (leaderboardBestRanking.oldPlace >= leaderboardBestRanking.place)
					{
						text = (leaderboardBestRanking.oldPlace - leaderboardBestRanking.place).ToString();
						this.changeImage.Image = GFXLibrary.arrow_up;
					}
					else
					{
						text = (leaderboardBestRanking.place - leaderboardBestRanking.oldPlace).ToString();
						this.changeImage.Image = GFXLibrary.arrow_down;
					}
					this.changeImage.Position = new Point(333, 12);
					this.changeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
					this.backgroundImage.addControl(this.changeImage);
					this.changeLabel.Text = text;
					this.changeLabel.Color = global::ARGBColors.White;
					this.changeLabel.Position = new Point(0, 12);
					this.changeLabel.Size = new Size(333, 25);
					this.changeLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.changeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.changeLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
					this.backgroundImage.addControl(this.changeLabel);
				}
				this.categoryLabel.Text = string.Concat(new string[]
				{
					StatsPanel.getCategoryTitle(leaderboardBestRanking.category),
					" - ",
					SK.Text("Stats_Ranked", "Ranked"),
					" ",
					leaderboardBestRanking.place.ToString("N", nfi)
				});
				this.categoryLabel.Color = global::ARGBColors.White;
				this.categoryLabel.Position = new Point(76, 12);
				this.categoryLabel.Size = new Size(275, 25);
				this.categoryLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.categoryLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.categoryLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.categoryLabel);
				this.amountLine.Color = global::ARGBColors.White;
				this.amountLine.Position = new Point(76, 37);
				this.amountLine.Size = new Size(275, this.backgroundImage.Height);
				this.amountLine.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
				this.amountLine.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.amountLine.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.amountLine);
				base.invalidate();
			}

			// Token: 0x06002AC0 RID: 10944 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06002AC1 RID: 10945 RVA: 0x0001F817 File Offset: 0x0001DA17
			public void lineClicked()
			{
				if (this.m_category != -1000 && this.m_parent != null)
				{
					GameEngine.Instance.playInterfaceSound("StatsPanel_entry_clicked");
					this.m_parent.changeCategory(this.m_category);
				}
			}

			// Token: 0x040034E9 RID: 13545
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034EA RID: 13546
			private CustomSelfDrawPanel.CSDLabel categoryLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034EB RID: 13547
			private CustomSelfDrawPanel.CSDLabel amountLine = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034EC RID: 13548
			private CustomSelfDrawPanel.CSDImage sectionImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034ED RID: 13549
			private CustomSelfDrawPanel.CSDLabel changeLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040034EE RID: 13550
			private CustomSelfDrawPanel.CSDImage changeImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040034EF RID: 13551
			private int m_position = -1000;

			// Token: 0x040034F0 RID: 13552
			private int m_category = -1000;

			// Token: 0x040034F1 RID: 13553
			private StatsPanel m_parent;
		}
	}
}
