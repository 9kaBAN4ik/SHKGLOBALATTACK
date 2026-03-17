using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x020004E5 RID: 1253
	public class VillageMapPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06002ECF RID: 11983 RVA: 0x00021FC3 File Offset: 0x000201C3
		// (set) Token: 0x06002ED0 RID: 11984 RVA: 0x00021FCB File Offset: 0x000201CB
		public bool ViewOnly
		{
			get
			{
				return this.viewOnly;
			}
			set
			{
				this.viewOnly = value;
				this.updateForViewOnly();
			}
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06002ED1 RID: 11985 RVA: 0x00021FDA File Offset: 0x000201DA
		public int CurrentTab
		{
			get
			{
				return this.CurrentTab;
			}
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x002587BC File Offset: 0x002569BC
		public VillageMapPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SelfDrawBackground = true;
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x00021FE2 File Offset: 0x000201E2
		public void create()
		{
			this.initPopularityPanel();
			this.initBuildingPanel();
			this.initInfo1Panel();
			this.initInfo2Panel();
			this.initInfo3Panel();
			this.initExtrasPanel();
			this.initInBuildingPanel();
			this.initCapitalPanel();
		}

		// Token: 0x06002ED4 RID: 11988 RVA: 0x002593C8 File Offset: 0x002575C8
		private void updateForViewOnly()
		{
			if (this.ViewOnly)
			{
				this.taxHigherButton.Enabled = false;
				this.taxLowerButton.Enabled = false;
				this.rationsLowerButton.Enabled = false;
				this.rationsHigherButton.Enabled = false;
				this.aleLowerButton.Enabled = false;
				this.aleHigherButton.Enabled = false;
				this.buildTab1Button.Enabled = false;
				this.buildTab2Button.Enabled = false;
				this.buildTab3Button.Enabled = false;
				this.buildTab4Button.Enabled = false;
				this.buildTab5Button.Enabled = false;
			}
			else
			{
				this.taxHigherButton.Enabled = true;
				this.taxLowerButton.Enabled = true;
				this.rationsLowerButton.Enabled = true;
				this.rationsHigherButton.Enabled = true;
				this.aleLowerButton.Enabled = true;
				this.aleHigherButton.Enabled = true;
				this.buildTab1Button.Enabled = true;
				this.buildTab2Button.Enabled = true;
				this.buildTab3Button.Enabled = true;
				this.buildTab4Button.Enabled = true;
				this.buildTab5Button.Enabled = true;
			}
			base.Invalidate();
		}

		// Token: 0x06002ED5 RID: 11989 RVA: 0x002594F4 File Offset: 0x002576F4
		public void initPopularityPanel()
		{
			base.clearControls();
			this.extensionImage.Image = GFXLibrary.r_popularity_panel_extension_back;
			this.extensionImage.Position = new Point(0, 25);
			base.addControl(this.extensionImage);
			this.panelImage.Image = GFXLibrary.r_popularity_panel_back;
			this.panelImage.Position = new Point(0, 25);
			base.addControl(this.panelImage);
			this.indent1Image.Image = GFXLibrary.r_popularity_panel_indent_a;
			this.indent1Image.Position = new Point(8, 35);
			this.indent1Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openTaxExtension));
			this.indent1Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openTaxExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openTaxExtensionLeave));
			this.indent1Image.CustomTooltipID = 123;
			this.panelImage.addControl(this.indent1Image);
			this.popIndent1Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent1Image.Position = new Point(6, 6);
			this.indent1Image.addControl(this.popIndent1Image);
			this.popImage1.Image = GFXLibrary.r_popularity_panel_icon_taxes;
			this.popImage1.Position = new Point(39, -10);
			this.indent1Image.addControl(this.popImage1);
			this.taxLine1Label.Text = "";
			this.taxLine1Label.Color = global::ARGBColors.Black;
			this.taxLine1Label.Position = new Point(34, 1);
			this.taxLine1Label.Size = new Size(this.indent1Image.Width - 24 - 31, this.indent1Image.Height);
			this.taxLine1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.taxLine1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent1Image.addControl(this.taxLine1Label);
			this.taxPopLabel.Text = "";
			this.taxPopLabel.Color = global::ARGBColors.White;
			this.taxPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.taxPopLabel.Position = new Point(0, 0);
			this.taxPopLabel.Size = new Size(this.popIndent1Image.Width, this.popIndent1Image.Height);
			this.taxPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.taxPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent1Image.addControl(this.taxPopLabel);
			this.indent2Image.Image = GFXLibrary.r_popularity_panel_indent_a;
			this.indent2Image.Position = new Point(8, 84);
			this.indent2Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openRationsExtension));
			this.indent2Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openRationsExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openRationsExtensionLeave));
			this.indent2Image.CustomTooltipID = 125;
			this.panelImage.addControl(this.indent2Image);
			this.popIndent2Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent2Image.Position = new Point(6, 6);
			this.indent2Image.addControl(this.popIndent2Image);
			this.popImage2.Image = GFXLibrary.r_popularity_panel_icon_rations;
			this.popImage2.Position = new Point(39, -10);
			this.indent2Image.addControl(this.popImage2);
			this.rationsLine1Label.Text = "";
			this.rationsLine1Label.Color = global::ARGBColors.Black;
			this.rationsLine1Label.Position = new Point(34, 1);
			this.rationsLine1Label.Size = new Size(this.indent2Image.Width - 24 - 31, this.indent2Image.Height);
			this.rationsLine1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.rationsLine1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent2Image.addControl(this.rationsLine1Label);
			this.rationsPopLabel.Text = "";
			this.rationsPopLabel.Color = global::ARGBColors.White;
			this.rationsPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.rationsPopLabel.Position = new Point(0, 0);
			this.rationsPopLabel.Size = new Size(this.popIndent2Image.Width, this.popIndent2Image.Height);
			this.rationsPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.rationsPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent2Image.addControl(this.rationsPopLabel);
			this.indent3Image.Image = GFXLibrary.r_popularity_panel_indent_a;
			this.indent3Image.Position = new Point(8, 133);
			this.indent3Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openAleExtension));
			this.indent3Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openAleExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openAleExtensionLeave));
			this.indent3Image.CustomTooltipID = 127;
			this.panelImage.addControl(this.indent3Image);
			this.popIndent3Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent3Image.Position = new Point(6, 6);
			this.indent3Image.addControl(this.popIndent3Image);
			this.popImage3.Image = GFXLibrary.r_popularity_panel_icon_ale;
			this.popImage3.Position = new Point(39, -10);
			this.indent3Image.addControl(this.popImage3);
			this.aleRationsLine1Label.Text = "";
			this.aleRationsLine1Label.Color = global::ARGBColors.Black;
			this.aleRationsLine1Label.Position = new Point(34, 1);
			this.aleRationsLine1Label.Size = new Size(this.indent3Image.Width - 24 - 31, this.indent3Image.Height);
			this.aleRationsLine1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.aleRationsLine1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent3Image.addControl(this.aleRationsLine1Label);
			this.alePopLabel.Text = "";
			this.alePopLabel.Color = global::ARGBColors.White;
			this.alePopLabel.DropShadowColor = global::ARGBColors.Black;
			this.alePopLabel.Position = new Point(0, 0);
			this.alePopLabel.Size = new Size(this.popIndent3Image.Width, this.popIndent3Image.Height);
			this.alePopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.alePopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent3Image.addControl(this.alePopLabel);
			this.indent4Image.Image = GFXLibrary.r_popularity_panel_indent_b;
			this.indent4Image.Position = new Point(8, 182);
			this.indent4Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openHousingExtension));
			this.indent4Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openHousingExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openHousingExtensionLeave));
			this.indent4Image.CustomTooltipID = 129;
			this.panelImage.addControl(this.indent4Image);
			this.popIndent4Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent4Image.Position = new Point(6, 5);
			this.indent4Image.addControl(this.popIndent4Image);
			this.popImage4.Image = GFXLibrary.r_popularity_panel_icon_housing;
			this.popImage4.Position = new Point(39, -10);
			this.indent4Image.addControl(this.popImage4);
			this.housingLabel.Text = "";
			this.housingLabel.Color = global::ARGBColors.Black;
			this.housingLabel.Position = new Point(39, 0);
			this.housingLabel.Size = new Size(this.indent4Image.Width - 24 - 31, this.indent4Image.Height);
			this.housingLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.housingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent4Image.addControl(this.housingLabel);
			this.housingPopLabel.Text = "";
			this.housingPopLabel.Color = global::ARGBColors.White;
			this.housingPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.housingPopLabel.Position = new Point(0, 0);
			this.housingPopLabel.Size = new Size(this.popIndent4Image.Width, this.popIndent4Image.Height);
			this.housingPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.housingPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent4Image.addControl(this.housingPopLabel);
			this.indent5Image.Image = GFXLibrary.r_popularity_panel_indent_b;
			this.indent5Image.Position = new Point(8, 231);
			this.indent5Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openBuildingExtension));
			this.indent5Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openBuildingExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openBuildingExtensionLeave));
			this.indent5Image.CustomTooltipID = 131;
			this.panelImage.addControl(this.indent5Image);
			this.popIndent5Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent5Image.Position = new Point(6, 5);
			this.indent5Image.addControl(this.popIndent5Image);
			this.popImage5.Image = GFXLibrary.r_popularity_panel_icon_buildings;
			this.popImage5.Position = new Point(39, -10);
			this.indent5Image.addControl(this.popImage5);
			this.buildingPopLabel.Text = "";
			this.buildingPopLabel.Color = global::ARGBColors.White;
			this.buildingPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.buildingPopLabel.Position = new Point(0, 0);
			this.buildingPopLabel.Size = new Size(this.popIndent5Image.Width, this.popIndent5Image.Height);
			this.buildingPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.buildingPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent5Image.addControl(this.buildingPopLabel);
			this.buildingsLabel.Text = "";
			this.buildingsLabel.Color = global::ARGBColors.Black;
			this.buildingsLabel.Position = new Point(39, 0);
			this.buildingsLabel.Size = new Size(this.indent5Image.Width - 24 - 31, this.indent5Image.Height);
			this.buildingsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.buildingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent5Image.addControl(this.buildingsLabel);
			this.indent6Image.Image = GFXLibrary.r_popularity_panel_indent_b;
			this.indent6Image.Position = new Point(8, 280);
			this.indent6Image.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openEventsExtension));
			this.indent6Image.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openEventsExtensionOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.openEventsExtensionLeave));
			this.indent6Image.CustomTooltipID = 133;
			this.panelImage.addControl(this.indent6Image);
			this.popIndent6Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.popIndent6Image.Position = new Point(6, 5);
			this.indent6Image.addControl(this.popIndent6Image);
			this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_plague;
			this.popImage6.Position = new Point(48, 4);
			this.popImage6.Visible = false;
			this.indent6Image.addControl(this.popImage6);
			this.eventsPopLabel.Text = "";
			this.eventsPopLabel.Color = global::ARGBColors.White;
			this.eventsPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.eventsPopLabel.Position = new Point(0, 0);
			this.eventsPopLabel.Size = new Size(this.popIndent5Image.Width, this.popIndent5Image.Height);
			this.eventsPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.eventsPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.popIndent6Image.addControl(this.eventsPopLabel);
			this.eventsLabel.Text = "";
			this.eventsLabel.Color = global::ARGBColors.Black;
			this.eventsLabel.Position = new Point(39, 0);
			this.eventsLabel.Size = new Size(this.indent6Image.Width - 24 - 31, this.indent6Image.Height);
			this.eventsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.eventsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.indent6Image.addControl(this.eventsLabel);
			this.taxLowerButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.taxLowerButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.taxLowerButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.taxLowerButton.Position = new Point(135, 40);
			this.taxLowerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.taxLowerClicked), "VillageMapPanel_tax_lower");
			this.taxLowerButton.CustomTooltipID = 116;
			this.panelImage.addControl(this.taxLowerButton);
			this.taxHigherButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.taxHigherButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.taxHigherButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.taxHigherButton.Position = new Point(159, 40);
			this.taxHigherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.taxHigherClicked), "VillageMapPanel_tax_higher");
			this.taxHigherButton.CustomTooltipID = 115;
			this.panelImage.addControl(this.taxHigherButton);
			this.taxBar.setImages(GFXLibrary.r_popularity_panel_colorbar_green_back, GFXLibrary.r_popularity_panel_colorbar_green_bar_left, GFXLibrary.r_popularity_panel_colorbar_green_bar_mid, GFXLibrary.r_popularity_panel_colorbar_green_bar_right, GFXLibrary.r_popularity_panel_colorbar_red_back, GFXLibrary.r_popularity_panel_colorbar_red_bar_left, GFXLibrary.r_popularity_panel_colorbar_red_bar_mid, GFXLibrary.r_popularity_panel_colorbar_red_bar_right);
			this.taxBar.Number = 0.0;
			this.taxBar.MaxValue = 10.0;
			this.taxBar.Position = new Point(138, 63);
			this.panelImage.addControl(this.taxBar);
			this.taxLowerButtonGlow.Image = GFXLibrary.tutorial_button_glow;
			this.taxLowerButtonGlow.Position = new Point(129, 34);
			this.taxLowerButtonGlow.Visible = false;
			this.panelImage.addControl(this.taxLowerButtonGlow);
			this.rationsLowerButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.rationsLowerButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.rationsLowerButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.rationsLowerButton.Position = new Point(135, 89);
			this.rationsLowerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rationsLowerClicked), "VillageMapPanel_rations_lower");
			this.rationsLowerButton.CustomTooltipID = 118;
			this.panelImage.addControl(this.rationsLowerButton);
			this.rationsHigherButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.rationsHigherButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.rationsHigherButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.rationsHigherButton.Position = new Point(159, 89);
			this.rationsHigherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.rationsHigherClicked), "VillageMapPanel_rations_higher");
			this.rationsHigherButton.CustomTooltipID = 117;
			this.panelImage.addControl(this.rationsHigherButton);
			this.rationsBar.setImages(GFXLibrary.r_popularity_panel_colorbar_green_back, GFXLibrary.r_popularity_panel_colorbar_green_bar_left, GFXLibrary.r_popularity_panel_colorbar_green_bar_mid, GFXLibrary.r_popularity_panel_colorbar_green_bar_right, GFXLibrary.r_popularity_panel_colorbar_red_back, GFXLibrary.r_popularity_panel_colorbar_red_bar_left, GFXLibrary.r_popularity_panel_colorbar_red_bar_mid, GFXLibrary.r_popularity_panel_colorbar_red_bar_right);
			this.rationsBar.Number = 0.0;
			this.rationsBar.MaxValue = 60.0;
			this.rationsBar.Position = new Point(138, 112);
			this.panelImage.addControl(this.rationsBar);
			this.aleLowerButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.aleLowerButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.aleLowerButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.aleLowerButton.Position = new Point(135, 138);
			this.aleLowerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aleLowerClicked), "VillageMapPanel_ale_lower");
			this.aleLowerButton.CustomTooltipID = 120;
			this.panelImage.addControl(this.aleLowerButton);
			this.aleHigherButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.aleHigherButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.aleHigherButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.aleHigherButton.Position = new Point(159, 138);
			this.aleHigherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.aleHigherClicked), "VillageMapPanel_ale_higher");
			this.aleHigherButton.CustomTooltipID = 119;
			this.panelImage.addControl(this.aleHigherButton);
			this.aleRationsBar.setImages(GFXLibrary.r_popularity_panel_colorbar_green_back, GFXLibrary.r_popularity_panel_colorbar_green_bar_left, GFXLibrary.r_popularity_panel_colorbar_green_bar_mid, GFXLibrary.r_popularity_panel_colorbar_green_bar_right, GFXLibrary.r_popularity_panel_colorbar_red_back, GFXLibrary.r_popularity_panel_colorbar_red_bar_left, GFXLibrary.r_popularity_panel_colorbar_red_bar_mid, GFXLibrary.r_popularity_panel_colorbar_red_bar_right);
			this.aleRationsBar.Number = 0.0;
			this.aleRationsBar.MaxValue = 40.0;
			this.aleRationsBar.Position = new Point(138, 161);
			this.panelImage.addControl(this.aleRationsBar);
			this.headerImage.Image = GFXLibrary.r_popularity_bar_back_green;
			this.headerImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.headerClicked));
			this.headerImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.headerMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.headerMouseLeave));
			this.headerImage.Position = new Point(0, 0);
			this.headerImage.CustomTooltipID = 121;
			base.addControl(this.headerImage);
			this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_stand;
			this.immChangeImage.Position = new Point(90, 5);
			this.headerImage.addControl(this.immChangeImage);
			this.arrivesInLabel.Text = "";
			this.arrivesInLabel.Color = global::ARGBColors.Black;
			this.arrivesInLabel.Position = new Point(106, 10);
			this.arrivesInLabel.Size = new Size(82, 20);
			this.arrivesInLabel.Visible = false;
			this.arrivesInLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.headerImage.addControl(this.arrivesInLabel);
			this.arrivesInTimeLabel.Text = "";
			this.arrivesInTimeLabel.Color = global::ARGBColors.Black;
			this.arrivesInTimeLabel.Position = new Point(106, 26);
			this.arrivesInTimeLabel.Size = new Size(82, 20);
			this.arrivesInTimeLabel.Visible = false;
			this.arrivesInTimeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.headerImage.addControl(this.arrivesInTimeLabel);
			this.popularityLabel.Text = "";
			this.popularityLabel.Color = global::ARGBColors.White;
			this.popularityLabel.DropShadowColor = global::ARGBColors.Black;
			this.popularityLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.popularityLabel.Position = new Point(5, 16);
			this.popularityLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.popularityLabel.Size = new Size(56, 24);
			this.headerImage.addControl(this.popularityLabel);
			this.headerGlowImage.Image = GFXLibrary.r_popularity_bar_back_glow;
			this.headerGlowImage.Position = new Point(0, 0);
			this.headerGlowImage.Visible = false;
			base.addControl(this.headerGlowImage);
			this.panelFaderImage.Image = GFXLibrary.r_popularity_panel_back;
			this.panelFaderImage.Position = new Point(0, 0);
			this.panelFaderImage.Alpha = 0f;
			this.panelImage.addControl(this.panelFaderImage);
			this.currentHeight = 1;
			this.targetHeight = 0;
			this.extensionHeaderLabel.Text = "";
			this.extensionHeaderLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.extensionHeaderLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			}
			else
			{
				this.extensionHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.extensionHeaderLabel.Position = new Point(0, 45);
			this.extensionHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.extensionHeaderLabel.Size = new Size(194, 24);
			this.extensionImage.addControl(this.extensionHeaderLabel);
			this.taxExtensionArea.Size = new Size(167, 115);
			this.taxExtensionArea.Position = new Point(12, 45);
			this.taxExtensionArea.Visible = false;
			this.extensionImage.addControl(this.taxExtensionArea);
			this.taxExtentionLabel.Text = SK.Text("VillageMapPanel_Daily_Finances", "Daily Finances");
			this.taxExtentionLabel.Color = global::ARGBColors.Black;
			this.taxExtentionLabel.Position = new Point(10, 25);
			this.taxExtentionLabel.Size = new Size(167, 17);
			this.taxExtensionArea.addControl(this.taxExtentionLabel);
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.taxDayLabel.Text = SK.Text("VillageMapPanel_Tax_Income", "Tax Income");
				this.taxDayLabel.Color = global::ARGBColors.Black;
				this.taxDayLabel.Position = new Point(10, 41);
				this.taxDayLabel.Size = new Size(167, 17);
				this.taxExtensionArea.addControl(this.taxDayLabel);
				this.taxDayValueLabel.Text = "";
				this.taxDayValueLabel.Color = global::ARGBColors.Black;
				this.taxDayValueLabel.Position = new Point(100, 53);
				this.taxDayValueLabel.Size = new Size(167 - this.taxDayValueLabel.X - 10, 17);
				this.taxDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.taxExtensionArea.addControl(this.taxDayValueLabel);
				this.parishTaxDayLabel.Text = SK.Text("VillageMapPanel_Parish_Tithe", "Parish Tithe");
				this.parishTaxDayLabel.Color = global::ARGBColors.Black;
				this.parishTaxDayLabel.Position = new Point(10, 66);
				this.parishTaxDayLabel.Size = new Size(167, 17);
				this.taxExtensionArea.addControl(this.parishTaxDayLabel);
				this.parishTaxDayValueLabel.Text = "";
				this.parishTaxDayValueLabel.Color = global::ARGBColors.Black;
				this.parishTaxDayValueLabel.Position = new Point(100, 66);
				this.parishTaxDayValueLabel.Size = new Size(167 - this.taxDayValueLabel.X - 10, 17);
				this.parishTaxDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.taxExtensionArea.addControl(this.parishTaxDayValueLabel);
			}
			else
			{
				this.taxDayLabel.Text = SK.Text("VillageMapPanel_Tax_Income", "Tax Income");
				this.taxDayLabel.Color = global::ARGBColors.Black;
				this.taxDayLabel.Position = new Point(10, 45);
				this.taxDayLabel.Size = new Size(167, 17);
				this.taxExtensionArea.addControl(this.taxDayLabel);
				this.taxDayValueLabel.Text = "";
				this.taxDayValueLabel.Color = global::ARGBColors.Black;
				this.taxDayValueLabel.Position = new Point(100, 45);
				this.taxDayValueLabel.Size = new Size(167 - this.taxDayValueLabel.X - 10, 17);
				this.taxDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.taxExtensionArea.addControl(this.taxDayValueLabel);
				this.parishTaxDayLabel.Text = SK.Text("VillageMapPanel_Parish_Tithe", "Parish Tithe");
				this.parishTaxDayLabel.Color = global::ARGBColors.Black;
				this.parishTaxDayLabel.Position = new Point(10, 61);
				this.parishTaxDayLabel.Size = new Size(167, 17);
				this.taxExtensionArea.addControl(this.parishTaxDayLabel);
				this.parishTaxDayValueLabel.Text = "";
				this.parishTaxDayValueLabel.Color = global::ARGBColors.Black;
				this.parishTaxDayValueLabel.Position = new Point(100, 61);
				this.parishTaxDayValueLabel.Size = new Size(167 - this.taxDayValueLabel.X - 10, 17);
				this.parishTaxDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.taxExtensionArea.addControl(this.parishTaxDayValueLabel);
			}
			this.rationsExtensionArea.Size = new Size(167, 115);
			this.rationsExtensionArea.Position = new Point(12, 45);
			this.rationsExtensionArea.Visible = false;
			this.extensionImage.addControl(this.rationsExtensionArea);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.rationsDayLabel.Text = SK.Text("VillageMapPanel_Food_Eaten", "Food Eaten Per Day") + ":";
				this.rationsDayLabel.Color = global::ARGBColors.Black;
				this.rationsDayLabel.Position = new Point(5, 19);
				this.rationsDayLabel.Size = new Size(167, 17);
				this.rationsDayLabel.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.rationsDayLabel);
				this.rationsDayValueLabel.Text = "";
				this.rationsDayValueLabel.Color = global::ARGBColors.Black;
				this.rationsDayValueLabel.Position = new Point(100, 28);
				this.rationsDayValueLabel.Size = new Size(167 - this.rationsDayValueLabel.X - 10, 17);
				this.rationsDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.rationsDayValueLabel.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.rationsDayValueLabel);
				this.rationsDay2Label.Text = SK.Text("VillageMapPanel_Food_Made", "Food Made Per Day") + ":";
				this.rationsDay2Label.Color = global::ARGBColors.Black;
				this.rationsDay2Label.Position = new Point(5, 39);
				this.rationsDay2Label.Size = new Size(167, 17);
				this.rationsDay2Label.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.rationsDay2Label);
				this.rationsDay2ValueLabel.Text = "";
				this.rationsDay2ValueLabel.Color = global::ARGBColors.Black;
				this.rationsDay2ValueLabel.Position = new Point(100, 48);
				this.rationsDay2ValueLabel.Size = new Size(167 - this.rationsDay2ValueLabel.X - 10, 17);
				this.rationsDay2ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.rationsDay2ValueLabel.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.rationsDay2ValueLabel);
				this.foodTypesEatenLabel.Text = SK.Text("VillageMapPanel_Types_Fully_Eaten", "Types Fully Eaten");
				this.foodTypesEatenLabel.Color = global::ARGBColors.Black;
				this.foodTypesEatenLabel.Position = new Point(5, 61);
				this.foodTypesEatenLabel.Size = new Size(167, 17);
				this.foodTypesEatenLabel.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.foodTypesEatenLabel);
				this.numFoodTypesEatenLabel.Text = "0";
				this.numFoodTypesEatenLabel.Color = global::ARGBColors.Black;
				this.numFoodTypesEatenLabel.Position = new Point(100, 70);
				this.numFoodTypesEatenLabel.Size = new Size(167 - this.numFoodTypesEatenLabel.X - 10, 17);
				this.numFoodTypesEatenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.numFoodTypesEatenLabel.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
				this.rationsExtensionArea.addControl(this.numFoodTypesEatenLabel);
			}
			else
			{
				this.rationsDayLabel.Text = SK.Text("VillageMapPanel_Food_Eaten", "Food Eaten Per Day") + ":";
				this.rationsDayLabel.Color = global::ARGBColors.Black;
				this.rationsDayLabel.Position = new Point(10, 25);
				this.rationsDayLabel.Size = new Size(167, 17);
				this.rationsExtensionArea.addControl(this.rationsDayLabel);
				this.rationsDayValueLabel.Text = "";
				this.rationsDayValueLabel.Color = global::ARGBColors.Black;
				this.rationsDayValueLabel.Position = new Point(100, 25);
				this.rationsDayValueLabel.Size = new Size(167 - this.rationsDayValueLabel.X - 10, 17);
				this.rationsDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.rationsExtensionArea.addControl(this.rationsDayValueLabel);
				this.rationsDay2Label.Text = SK.Text("VillageMapPanel_Food_Made", "Food Made Per Day") + ":";
				this.rationsDay2Label.Color = global::ARGBColors.Black;
				this.rationsDay2Label.Position = new Point(10, 41);
				this.rationsDay2Label.Size = new Size(167, 17);
				this.rationsExtensionArea.addControl(this.rationsDay2Label);
				this.rationsDay2ValueLabel.Text = "";
				this.rationsDay2ValueLabel.Color = global::ARGBColors.Black;
				this.rationsDay2ValueLabel.Position = new Point(100, 41);
				this.rationsDay2ValueLabel.Size = new Size(167 - this.rationsDay2ValueLabel.X - 10, 17);
				this.rationsDay2ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.rationsExtensionArea.addControl(this.rationsDay2ValueLabel);
				this.foodTypesEatenLabel.Text = SK.Text("VillageMapPanel_Types_Fully_Eaten", "Types Fully Eaten");
				this.foodTypesEatenLabel.Color = global::ARGBColors.Black;
				this.foodTypesEatenLabel.Position = new Point(10, 57);
				this.foodTypesEatenLabel.Size = new Size(167, 17);
				this.rationsExtensionArea.addControl(this.foodTypesEatenLabel);
				this.numFoodTypesEatenLabel.Text = "0";
				this.numFoodTypesEatenLabel.Color = global::ARGBColors.Black;
				this.numFoodTypesEatenLabel.Position = new Point(100, 57);
				this.numFoodTypesEatenLabel.Size = new Size(167 - this.numFoodTypesEatenLabel.X - 10, 17);
				this.numFoodTypesEatenLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.rationsExtensionArea.addControl(this.numFoodTypesEatenLabel);
			}
			this.aleExtensionArea.Size = new Size(167, 115);
			this.aleExtensionArea.Position = new Point(12, 45);
			this.aleExtensionArea.Visible = false;
			this.extensionImage.addControl(this.aleExtensionArea);
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.aleRationsDayLabel.Text = SK.Text("VillageMapPanel_Ale_Drunk_Per_Day", "Ale Drank Per Day") + ":";
				this.aleRationsDayLabel.Color = global::ARGBColors.Black;
				this.aleRationsDayLabel.Position = new Point(10, 25);
				this.aleRationsDayLabel.Size = new Size(167, 17);
				this.aleExtensionArea.addControl(this.aleRationsDayLabel);
				this.aleRationsDayValueLabel.Text = "";
				this.aleRationsDayValueLabel.Color = global::ARGBColors.Black;
				this.aleRationsDayValueLabel.Position = new Point(100, 36);
				this.aleRationsDayValueLabel.Size = new Size(167 - this.aleRationsDayValueLabel.X - 10, 17);
				this.aleRationsDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.aleExtensionArea.addControl(this.aleRationsDayValueLabel);
				this.aleRationsDay2Label.Text = SK.Text("VillageMapPanel_Ale_Made_Per_Day", "Ale Made Per Day") + ":";
				this.aleRationsDay2Label.Color = global::ARGBColors.Black;
				this.aleRationsDay2Label.Position = new Point(10, 49);
				this.aleRationsDay2Label.Size = new Size(167, 17);
				this.aleExtensionArea.addControl(this.aleRationsDay2Label);
				this.aleRationsDay2ValueLabel.Text = "";
				this.aleRationsDay2ValueLabel.Color = global::ARGBColors.Black;
				this.aleRationsDay2ValueLabel.Position = new Point(100, 60);
				this.aleRationsDay2ValueLabel.Size = new Size(167 - this.aleRationsDay2ValueLabel.X - 10, 17);
				this.aleRationsDay2ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.aleExtensionArea.addControl(this.aleRationsDay2ValueLabel);
			}
			else
			{
				this.aleRationsDayLabel.Text = SK.Text("VillageMapPanel_Ale_Drunk_Per_Day", "Ale Drank Per Day") + ":";
				this.aleRationsDayLabel.Color = global::ARGBColors.Black;
				this.aleRationsDayLabel.Position = new Point(10, 25);
				this.aleRationsDayLabel.Size = new Size(167, 17);
				this.aleExtensionArea.addControl(this.aleRationsDayLabel);
				this.aleRationsDayValueLabel.Text = "";
				this.aleRationsDayValueLabel.Color = global::ARGBColors.Black;
				this.aleRationsDayValueLabel.Position = new Point(100, 25);
				this.aleRationsDayValueLabel.Size = new Size(167 - this.aleRationsDayValueLabel.X - 10, 17);
				this.aleRationsDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.aleExtensionArea.addControl(this.aleRationsDayValueLabel);
				this.aleRationsDay2Label.Text = SK.Text("VillageMapPanel_Ale_Made_Per_Day", "Ale Made Per Day") + ":";
				this.aleRationsDay2Label.Color = global::ARGBColors.Black;
				this.aleRationsDay2Label.Position = new Point(10, 41);
				this.aleRationsDay2Label.Size = new Size(167, 17);
				this.aleExtensionArea.addControl(this.aleRationsDay2Label);
				this.aleRationsDay2ValueLabel.Text = "";
				this.aleRationsDay2ValueLabel.Color = global::ARGBColors.Black;
				this.aleRationsDay2ValueLabel.Position = new Point(100, 41);
				this.aleRationsDay2ValueLabel.Size = new Size(167 - this.aleRationsDay2ValueLabel.X - 10, 17);
				this.aleRationsDay2ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.aleExtensionArea.addControl(this.aleRationsDay2ValueLabel);
			}
			this.buildingExtensionArea.Size = new Size(167, 115);
			this.buildingExtensionArea.Position = new Point(12, 45);
			this.buildingExtensionArea.Visible = false;
			this.extensionImage.addControl(this.buildingExtensionArea);
			if (Program.mySettings.LanguageIdent == "pt" || Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it")
			{
				this.positiveBuildingsHeader.Text = SK.Text("VillageMapPanel_Popular_Buildings", "Popular Buildings") + ":";
				this.positiveBuildingsHeader.Color = global::ARGBColors.Black;
				this.positiveBuildingsHeader.Position = new Point(10, 25);
				this.positiveBuildingsHeader.Size = new Size(167, 17);
				this.buildingExtensionArea.addControl(this.positiveBuildingsHeader);
				this.positiveBuildingsLabel.Text = "";
				this.positiveBuildingsLabel.Color = global::ARGBColors.Black;
				this.positiveBuildingsLabel.Position = new Point(100, 36);
				this.positiveBuildingsLabel.Size = new Size(167 - this.positiveBuildingsLabel.X - 10, 17);
				this.positiveBuildingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.buildingExtensionArea.addControl(this.positiveBuildingsLabel);
				this.negativeBuildingsHeader.Text = SK.Text("VillageMapPanel_Unpopular_Buildings", "Unpopular Buildings") + ":";
				this.negativeBuildingsHeader.Color = global::ARGBColors.Black;
				this.negativeBuildingsHeader.Position = new Point(10, 49);
				this.negativeBuildingsHeader.Size = new Size(167, 17);
				this.buildingExtensionArea.addControl(this.negativeBuildingsHeader);
				this.negativeBuildingsLabel.Text = "";
				this.negativeBuildingsLabel.Color = global::ARGBColors.Black;
				this.negativeBuildingsLabel.Position = new Point(100, 60);
				this.negativeBuildingsLabel.Size = new Size(167 - this.negativeBuildingsLabel.X - 10, 17);
				this.negativeBuildingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.buildingExtensionArea.addControl(this.negativeBuildingsLabel);
			}
			else
			{
				this.positiveBuildingsHeader.Text = SK.Text("VillageMapPanel_Popular_Buildings", "Popular Buildings") + ":";
				this.positiveBuildingsHeader.Color = global::ARGBColors.Black;
				this.positiveBuildingsHeader.Position = new Point(10, 25);
				this.positiveBuildingsHeader.Size = new Size(167, 17);
				this.buildingExtensionArea.addControl(this.positiveBuildingsHeader);
				this.positiveBuildingsLabel.Text = "";
				this.positiveBuildingsLabel.Color = global::ARGBColors.Black;
				this.positiveBuildingsLabel.Position = new Point(100, 25);
				this.positiveBuildingsLabel.Size = new Size(167 - this.positiveBuildingsLabel.X - 10, 17);
				this.positiveBuildingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.buildingExtensionArea.addControl(this.positiveBuildingsLabel);
				this.negativeBuildingsHeader.Text = SK.Text("VillageMapPanel_Unpopular_Buildings", "Unpopular Buildings") + ":";
				this.negativeBuildingsHeader.Color = global::ARGBColors.Black;
				this.negativeBuildingsHeader.Position = new Point(10, 41);
				this.negativeBuildingsHeader.Size = new Size(167, 17);
				this.buildingExtensionArea.addControl(this.negativeBuildingsHeader);
				this.negativeBuildingsLabel.Text = "";
				this.negativeBuildingsLabel.Color = global::ARGBColors.Black;
				this.negativeBuildingsLabel.Position = new Point(100, 41);
				this.negativeBuildingsLabel.Size = new Size(167 - this.negativeBuildingsLabel.X - 10, 17);
				this.negativeBuildingsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.buildingExtensionArea.addControl(this.negativeBuildingsLabel);
			}
			this.housingExtensionArea.Size = new Size(167, 115);
			this.housingExtensionArea.Position = new Point(12, 45);
			this.housingExtensionArea.Visible = false;
			this.extensionImage.addControl(this.housingExtensionArea);
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.populationLabel.Text = SK.Text("VillageMapPanel_Population", "Population") + ":";
				this.populationLabel.Color = global::ARGBColors.Black;
				this.populationLabel.Position = new Point(10, 19);
				this.populationLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.populationLabel);
				this.populationValueLabel.Text = "";
				this.populationValueLabel.Color = global::ARGBColors.Black;
				this.populationValueLabel.Position = new Point(100, 28);
				this.populationValueLabel.Size = new Size(167 - this.populationValueLabel.X - 10, 17);
				this.populationValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.housingExtensionArea.addControl(this.populationValueLabel);
				this.housingCapacityLabel.Text = SK.Text("VillageMapPanel_Housing_Capacity", "Housing Capacity") + ":";
				this.housingCapacityLabel.Color = global::ARGBColors.Black;
				this.housingCapacityLabel.Position = new Point(10, 39);
				this.housingCapacityLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.housingCapacityLabel);
				this.housingCapacityValueLabel.Text = "";
				this.housingCapacityValueLabel.Color = global::ARGBColors.Black;
				this.housingCapacityValueLabel.Position = new Point(100, 48);
				this.housingCapacityValueLabel.Size = new Size(167 - this.housingCapacityValueLabel.X - 10, 17);
				this.housingCapacityValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.housingExtensionArea.addControl(this.housingCapacityValueLabel);
				this.housingOccupancyLabel.Text = SK.Text("VillageMapPanel_Housing_Occupancy", "Housing Occupancy") + ":";
				this.housingOccupancyLabel.Color = global::ARGBColors.Black;
				this.housingOccupancyLabel.Position = new Point(10, 61);
				this.housingOccupancyLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.housingOccupancyLabel);
				this.housingOccupancyValueLabel.Text = "";
				this.housingOccupancyValueLabel.Color = global::ARGBColors.Black;
				this.housingOccupancyValueLabel.Position = new Point(100, 70);
				this.housingOccupancyValueLabel.Size = new Size(167 - this.housingOccupancyValueLabel.X - 10, 17);
				this.housingOccupancyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.housingExtensionArea.addControl(this.housingOccupancyValueLabel);
			}
			else
			{
				this.populationLabel.Text = SK.Text("VillageMapPanel_Population", "Population") + ":";
				this.populationLabel.Color = global::ARGBColors.Black;
				this.populationLabel.Position = new Point(10, 25);
				this.populationLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.populationLabel);
				this.populationValueLabel.Text = "";
				this.populationValueLabel.Color = global::ARGBColors.Black;
				this.populationValueLabel.Position = new Point(100, 25);
				this.populationValueLabel.Size = new Size(167 - this.populationValueLabel.X - 10, 17);
				this.populationValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.housingExtensionArea.addControl(this.populationValueLabel);
				this.housingCapacityLabel.Text = SK.Text("VillageMapPanel_Housing_Capacity", "Housing Capacity") + ":";
				this.housingCapacityLabel.Color = global::ARGBColors.Black;
				this.housingCapacityLabel.Position = new Point(10, 41);
				this.housingCapacityLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.housingCapacityLabel);
				this.housingCapacityValueLabel.Text = "";
				this.housingCapacityValueLabel.Color = global::ARGBColors.Black;
				this.housingCapacityValueLabel.Position = new Point(100, 41);
				this.housingCapacityValueLabel.Size = new Size(167 - this.housingCapacityValueLabel.X - 10, 17);
				this.housingCapacityValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.housingExtensionArea.addControl(this.housingCapacityValueLabel);
				this.housingOccupancyLabel.Text = SK.Text("VillageMapPanel_Housing_Occupancy", "Housing Occupancy") + ":";
				this.housingOccupancyLabel.Color = global::ARGBColors.Black;
				this.housingOccupancyLabel.Position = new Point(10, 57);
				this.housingOccupancyLabel.Size = new Size(167, 17);
				this.housingExtensionArea.addControl(this.housingOccupancyLabel);
				if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "it")
				{
					this.housingOccupancyValueLabel.Text = "";
					this.housingOccupancyValueLabel.Color = global::ARGBColors.Black;
					this.housingOccupancyValueLabel.Position = new Point(100, 68);
					this.housingOccupancyValueLabel.Size = new Size(167 - this.housingOccupancyValueLabel.X - 10, 17);
					this.housingOccupancyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.housingExtensionArea.addControl(this.housingOccupancyValueLabel);
				}
				else
				{
					this.housingOccupancyValueLabel.Text = "";
					this.housingOccupancyValueLabel.Color = global::ARGBColors.Black;
					this.housingOccupancyValueLabel.Position = new Point(100, 57);
					this.housingOccupancyValueLabel.Size = new Size(167 - this.housingOccupancyValueLabel.X - 10, 17);
					this.housingOccupancyValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.housingExtensionArea.addControl(this.housingOccupancyValueLabel);
				}
			}
			this.eventsExtensionArea.Size = new Size(167, 115);
			this.eventsExtensionArea.Position = new Point(12, 45);
			this.eventsExtensionArea.Visible = false;
			this.extensionImage.addControl(this.eventsExtensionArea);
			this.eventHeaderLabel.Text = SK.Text("VillageMapPanel_Events", "Events");
			this.eventHeaderLabel.Color = global::ARGBColors.Black;
			this.eventHeaderLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.eventHeaderLabel.Position = new Point(0, 0);
			this.eventHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.eventHeaderLabel.Size = new Size(194, 24);
			this.eventsExtensionArea.addControl(this.eventHeaderLabel);
			this.eventCountLabel.Text = "0/0";
			this.eventCountLabel.Color = global::ARGBColors.Black;
			this.eventCountLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.eventCountLabel.Position = new Point(56, 0);
			this.eventCountLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.eventCountLabel.Size = new Size(110, 24);
			this.eventsExtensionArea.addControl(this.eventCountLabel);
			this.eventPopImage.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			this.eventPopImage.Position = new Point(5, 18);
			this.eventsExtensionArea.addControl(this.eventPopImage);
			this.eventExtPopLabel.Text = "0";
			this.eventExtPopLabel.Color = global::ARGBColors.White;
			this.eventExtPopLabel.DropShadowColor = global::ARGBColors.Black;
			this.eventExtPopLabel.Position = new Point(0, 0);
			this.eventExtPopLabel.Size = new Size(this.eventPopImage.Width, this.eventPopImage.Height);
			this.eventExtPopLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.eventExtPopLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.eventPopImage.addControl(this.eventExtPopLabel);
			this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_plague;
			this.eventTypeImage.Position = new Point(48, 18);
			this.eventsExtensionArea.addControl(this.eventTypeImage);
			this.eventBarImage.Image = GFXLibrary.r_popularity_panel_events_textbar_green;
			this.eventBarImage.Position = new Point(5, 46);
			this.eventsExtensionArea.addControl(this.eventBarImage);
			this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Test_Events", "Test Event");
			this.eventTitleLabel.Color = global::ARGBColors.White;
			this.eventTitleLabel.Position = new Point(5, 0);
			this.eventTitleLabel.Size = new Size(this.eventBarImage.Width - 10, this.eventBarImage.Height);
			this.eventTitleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.eventTitleLabel.Font = FontManager.GetFont("Arial", 6.5f, FontStyle.Regular);
			this.eventBarImage.addControl(this.eventTitleLabel);
			this.eventDaysLabel.Text = "00d";
			this.eventDaysLabel.Color = global::ARGBColors.Black;
			this.eventDaysLabel.Position = new Point(0, 62);
			this.eventDaysLabel.Size = new Size(63, 25);
			this.eventDaysLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.eventDaysLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.eventsExtensionArea.addControl(this.eventDaysLabel);
			this.eventTimeLabel.Text = "00h:00m:00s";
			this.eventTimeLabel.Color = global::ARGBColors.Black;
			this.eventTimeLabel.Position = new Point(64, 66);
			this.eventTimeLabel.Size = new Size(100, 25);
			this.eventTimeLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			this.eventTimeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.eventsExtensionArea.addControl(this.eventTimeLabel);
			this.eventLowerButton.ImageNorm = GFXLibrary.r_arrow_small_left_norm;
			this.eventLowerButton.ImageOver = GFXLibrary.r_arrow_small_left_over;
			this.eventLowerButton.Position = new Point(69, 3);
			this.eventLowerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.eventShownLowerClicked), "VillageMapPanel_events_lower");
			this.eventsExtensionArea.addControl(this.eventLowerButton);
			this.eventHigherButton.ImageNorm = GFXLibrary.r_arrow_small_right_norm;
			this.eventHigherButton.ImageOver = GFXLibrary.r_arrow_small_right_over;
			this.eventHigherButton.Position = new Point(138, 3);
			this.eventHigherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.eventShownHigherClicked), "VillageMapPanel_events_higher");
			this.eventsExtensionArea.addControl(this.eventHigherButton);
			this.eventPopImage.Visible = false;
			this.eventTypeImage.Visible = false;
			this.eventBarImage.Visible = false;
			this.eventDaysLabel.Visible = false;
			this.eventTimeLabel.Visible = false;
			this.currentExtensionHeight = 1;
			this.targetExtensionHeight = 0;
		}

		// Token: 0x06002ED6 RID: 11990 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showGoldChange(double currentGold, double goldRate)
		{
		}

		// Token: 0x06002ED7 RID: 11991 RVA: 0x0025CADC File Offset: 0x0025ACDC
		public void showPopEvents(PopEventData[] popEvents, DateTime curTime)
		{
			int num = 0;
			bool flag = false;
			if (popEvents != null)
			{
				this.eventsLabel.Text = popEvents.Length.ToString();
			}
			else
			{
				this.eventsLabel.Text = "0";
			}
			int num2 = 0;
			if (popEvents.Length == 2)
			{
				num2 = 1;
			}
			else if (popEvents.Length == 2)
			{
				num2 = 2;
			}
			if (popEvents != null && popEvents.Length != 0)
			{
				PopEventData popEventData = null;
				PopEventData popEventData2 = null;
				foreach (PopEventData popEventData3 in popEvents)
				{
					num += popEventData3.eventEffect;
					if (popEventData == null || popEventData3.eventEffect < popEventData.eventEffect)
					{
						popEventData = popEventData3;
					}
					if (popEventData2 == null || popEventData3.eventEffect > popEventData2.eventEffect)
					{
						popEventData2 = popEventData3;
					}
				}
				PopEventData popEventData4 = (num < 0) ? popEventData : popEventData2;
				if (popEventData4 != null)
				{
					flag = true;
					int eventType = popEventData4.eventType;
					if (eventType <= 10102)
					{
						if (eventType <= 10021)
						{
							if (eventType == 1)
							{
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_beginner;
								goto IL_438;
							}
							switch (eventType)
							{
							case 10001:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_5;
								goto IL_438;
							case 10002:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_3;
								goto IL_438;
							case 10003:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_5;
								goto IL_438;
							case 10011:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_5;
								goto IL_438;
							case 10012:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_4;
								goto IL_438;
							case 10013:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_3;
								goto IL_438;
							case 10014:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_2;
								goto IL_438;
							case 10015:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_1;
								goto IL_438;
							case 10016:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_neutral;
								goto IL_438;
							case 10017:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_1;
								goto IL_438;
							case 10018:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_2;
								goto IL_438;
							case 10019:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_3;
								goto IL_438;
							case 10020:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_4;
								goto IL_438;
							case 10021:
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_5;
								goto IL_438;
							}
						}
						else
						{
							if (eventType == 10101)
							{
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_blessing;
								goto IL_438;
							}
							if (eventType == 10102)
							{
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_inquisition;
								goto IL_438;
							}
						}
					}
					else if (eventType <= 11010)
					{
						switch (eventType)
						{
						case 11001:
							this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_bandits;
							goto IL_438;
						case 11002:
							this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_wolves;
							goto IL_438;
						case 11003:
							if (num < 0)
							{
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
								goto IL_438;
							}
							this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_castle_green;
							goto IL_438;
						default:
							if (eventType == 11010)
							{
								this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_plague;
								goto IL_438;
							}
							break;
						}
					}
					else
					{
						if (eventType == 11020)
						{
							this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
							goto IL_438;
						}
						if (eventType == 20001)
						{
							this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
							goto IL_438;
						}
					}
					this.popImage6.Image = GFXLibrary.r_popularity_panel_events_illustration_plague;
					IL_438:
					this.eventsLabel.Visible = true;
					this.popImage6.Visible = true;
					this.eventPopImage.Visible = true;
					this.eventTypeImage.Visible = true;
					this.eventBarImage.Visible = true;
					this.eventDaysLabel.Visible = true;
					this.eventTimeLabel.Visible = true;
					if (this.currentEventID >= popEvents.Length)
					{
						this.currentEventID = 0;
					}
					else if (this.currentEventID < 0)
					{
						this.currentEventID = popEvents.Length - 1;
					}
					PopEventData popEventData5 = popEvents[this.currentEventID];
					bool flag2 = true;
					int eventType2 = popEventData5.eventType;
					if (eventType2 <= 10102)
					{
						switch (eventType2)
						{
						case 10001:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Bad_Weather", "Bad Weather");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_5;
							goto IL_CE4;
						case 10002:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Good_Weather", "Good Weather");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_3;
							goto IL_CE4;
						case 10003:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Drought", "Drought");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_5;
							goto IL_CE4;
						case 10004:
						case 10005:
						case 10006:
						case 10007:
						case 10008:
						case 10009:
						case 10010:
							break;
						case 10011:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Storms", "Storms");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_5;
							goto IL_CE4;
						case 10012:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Heavy_Rain", "Heavy Rain");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_4;
							goto IL_CE4;
						case 10013:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Rain", "Rain");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_3;
							goto IL_CE4;
						case 10014:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Showers", "Showers");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_2;
							goto IL_CE4;
						case 10015:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Drizzle", "Drizzle");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_bad_1;
							goto IL_CE4;
						case 10016:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Overcast", "Overcast");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_neutral;
							goto IL_CE4;
						case 10017:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Break_In_The_Cloud", "Break in the Cloud");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_1;
							goto IL_CE4;
						case 10018:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Sunny_Spells", "Sunny Spells");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_2;
							goto IL_CE4;
						case 10019:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Fine_Weather", "Fine Weather");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_3;
							goto IL_CE4;
						case 10020:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Bright_Sunshine", "Bright Sunshine");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_4;
							goto IL_CE4;
						case 10021:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Heatwave", "Heatwave");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_weather_good_5;
							goto IL_CE4;
						default:
							if (eventType2 == 10101)
							{
								this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Blessing", "Blessing");
								this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
								this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_blessing;
								goto IL_CE4;
							}
							if (eventType2 == 10102)
							{
								this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Inquisition", "Inquisition");
								this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
								this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_inquisition;
								goto IL_CE4;
							}
							break;
						}
					}
					else if (eventType2 <= 11010)
					{
						switch (eventType2)
						{
						case 11001:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Bandit_Camps", "Bandit Camps");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							flag2 = false;
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_bandits;
							goto IL_CE4;
						case 11002:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Wolf_Lairs", "Wolf Lairs");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							flag2 = false;
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_wolves;
							goto IL_CE4;
						case 11003:
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_AI_Castles", "AI Castles");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							flag2 = false;
							if (popEventData5.eventEffect >= 0)
							{
								this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_castle_green;
								goto IL_CE4;
							}
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
							goto IL_CE4;
						default:
							if (eventType2 == 11010)
							{
								this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Disease", "Disease");
								this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
								flag2 = false;
								this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_plague;
								goto IL_CE4;
							}
							break;
						}
					}
					else
					{
						if (eventType2 == 11020)
						{
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Castle_Not_Enclosed", "Castle Not Enclosed");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
							flag2 = false;
							goto IL_CE4;
						}
						if (eventType2 == 20001)
						{
							this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Festival", "Festival");
							this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
							this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_castle;
							goto IL_CE4;
						}
					}
					if (this.currentEventID + num2 == 0)
					{
						this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Beginner_Help", "Beginner Help");
					}
					else if (this.currentEventID + num2 == 1)
					{
						this.eventTitleLabel.Text = SK.Text("VillageMapPanel_Welcome_Bonus", "Welcome Bonus");
					}
					else if (this.currentEventID + num2 == 2)
					{
						this.eventTitleLabel.Text = SK.Text("VillageMapPanel_New_Player_Bonus", "New Player Bonus");
					}
					this.eventExtPopLabel.Text = popEventData5.eventEffect.ToString();
					this.eventTypeImage.Image = GFXLibrary.r_popularity_panel_events_illustration_beginner;
					IL_CE4:
					if (flag2)
					{
						int num3 = (int)(popEventData5.endTime - curTime).TotalSeconds;
						if (num3 < 0)
						{
							num3 = 0;
						}
						int num4 = num3 % 60;
						int num5 = num3 / 60 % 60;
						int num6 = num3 / 3600 % 24;
						int num7 = num3 / 86400;
						string text = "";
						string text2 = "";
						text = text + num7.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
						if (num6 < 10)
						{
							text2 += "0";
						}
						text2 = text2 + num6.ToString() + SK.Text("VillageMap_Hour_Abbrev", "h") + ":";
						if (num5 < 10)
						{
							text2 += "0";
						}
						text2 = text2 + num5.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m") + ":";
						if (num4 < 10)
						{
							text2 += "0";
						}
						text2 = text2 + num4.ToString() + SK.Text("VillageMap_Second_Abbrev", "s");
						this.eventDaysLabel.Text = text;
						this.eventTimeLabel.Text = text2;
					}
					else
					{
						this.eventDaysLabel.Text = "";
						this.eventTimeLabel.Text = "";
					}
					if (popEventData5.eventEffect < 0)
					{
						this.eventPopImage.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
						this.eventBarImage.Image = GFXLibrary.r_popularity_panel_events_textbar_red;
					}
					else if (popEventData5.eventEffect >= 0)
					{
						this.eventPopImage.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
						this.eventBarImage.Image = GFXLibrary.r_popularity_panel_events_textbar_green;
					}
					this.eventCountLabel.Text = (this.currentEventID + 1).ToString() + "/" + popEvents.Length.ToString();
				}
			}
			if (!flag)
			{
				this.eventPopImage.Visible = false;
				this.eventTypeImage.Visible = false;
				this.eventBarImage.Visible = false;
				this.eventsLabel.Visible = false;
				this.eventDaysLabel.Visible = false;
				this.eventTimeLabel.Visible = false;
				this.popImage6.Visible = false;
			}
			this.eventsPopLabel.Text = num.ToString();
			if (num < 0)
			{
				this.popIndent6Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
				return;
			}
			if (num > 0)
			{
				this.popIndent6Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
				return;
			}
			this.popIndent6Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
		}

		// Token: 0x06002ED8 RID: 11992 RVA: 0x00022014 File Offset: 0x00020214
		public void eventShownLowerClicked()
		{
			this.currentEventID--;
		}

		// Token: 0x06002ED9 RID: 11993 RVA: 0x00022024 File Offset: 0x00020224
		public void eventShownHigherClicked()
		{
			this.currentEventID++;
		}

		// Token: 0x06002EDA RID: 11994 RVA: 0x0025DA7C File Offset: 0x0025BC7C
		public void showMigration(int popularity, string timeLeftString, int totalPeople, int housingCapacity)
		{
			if (popularity >= 0)
			{
				this.headerImage.Image = GFXLibrary.r_popularity_bar_back_green;
			}
			else if (popularity < 0)
			{
				this.headerImage.Image = GFXLibrary.r_popularity_bar_back_red;
			}
			else
			{
				this.headerImage.Image = GFXLibrary.r_popularity_bar_back_yellow;
			}
			this.popularityLabel.Text = popularity.ToString();
			if (popularity == 0)
			{
				this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_stand;
			}
			else if (popularity < 0)
			{
				int immigrationNumberOfPeasantsLeaving = VillageBuildingsData.getImmigrationNumberOfPeasantsLeaving(popularity);
				if (immigrationNumberOfPeasantsLeaving <= 1)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 2)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x2;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 3)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x3;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 4)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x4;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 5)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x5;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 6)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x6;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 7)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x7;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 8)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x8;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 9)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x9;
				}
				else if (immigrationNumberOfPeasantsLeaving <= 10)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_out_x10;
				}
			}
			else
			{
				int immigrationNumberOfPeasants = VillageBuildingsData.getImmigrationNumberOfPeasants(popularity);
				if (immigrationNumberOfPeasants <= 1)
				{
					this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_in;
				}
				else
				{
					switch (immigrationNumberOfPeasants)
					{
					case 2:
						this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_in_x2;
						break;
					case 3:
						this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_in_x3;
						break;
					case 4:
						this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_in_x4;
						break;
					case 5:
						this.immChangeImage.Image = GFXLibrary.r_popularity_bar_walker_in_x5;
						break;
					}
				}
			}
			if (timeLeftString.Length > 0)
			{
				this.arrivesInLabel.Visible = true;
				this.arrivesInTimeLabel.Visible = true;
				this.arrivesInTimeLabel.Text = timeLeftString;
				if (popularity > 0)
				{
					this.arrivesInLabel.Text = SK.Text("VillageMapPanel_Arrives_In_X", "Arrives in") + " :";
				}
				else
				{
					this.arrivesInLabel.Text = SK.Text("VillageMapPanel_Leaves_In_X", "Leaves in") + " :";
				}
			}
			else
			{
				this.arrivesInLabel.Visible = false;
				this.arrivesInTimeLabel.Visible = false;
			}
			if (housingCapacity > 0)
			{
				this.housingLabel.Text = (totalPeople * 100 / housingCapacity).ToString() + "%";
			}
			this.housingOccupancyValueLabel.Text = this.housingLabel.Text;
			double housingPopularityLevel = VillageBuildingsData.getHousingPopularityLevel(totalPeople, housingCapacity);
			this.housingPopLabel.Text = housingPopularityLevel.ToString();
			if (housingPopularityLevel < 0.0)
			{
				this.popIndent4Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
			}
			else if (housingPopularityLevel > 0.0)
			{
				this.popIndent4Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			}
			else
			{
				this.popIndent4Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
			}
			this.housingCapacityValueLabel.Text = housingCapacity.ToString();
			this.populationValueLabel.Text = totalPeople.ToString();
		}

		// Token: 0x06002EDB RID: 11995 RVA: 0x0025DE48 File Offset: 0x0025C048
		public void showStats(int taxLevel, int rationsLevel, int aleRationsLevel, int popularity, double popularityChange, string timeLeftString, double effectiveRationsLevel, int numFoodTypesEaten, double effectiveAleRationsLevel, double housingChangeLevel)
		{
			if (this.extensionType == 0)
			{
				switch (taxLevel)
				{
				case 0:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Large_Bribe", "Large Bribe");
					break;
				case 1:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Medium_Bribe", "Medium Bribe");
					break;
				case 2:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Small_Bribe", "Small Bribe");
					break;
				case 3:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_No_Tax", "No Tax");
					break;
				case 4:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Low_Tax", "Low Tax");
					break;
				case 5:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Normal_Tax", "Normal Tax");
					break;
				case 6:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_High_Tax", "High Tax");
					break;
				case 7:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Very_High_Tax", "Very High Tax");
					break;
				case 8:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Extreme_Tax", "Extreme Tax");
					break;
				case 9:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Cruel_Tax", "Cruel Tax");
					break;
				case 10:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Very_Cruel_Tax", "Very Cruel Tax");
					break;
				case 11:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Extremely_Cruel_Tax", "Extremely Cruel Tax");
					break;
				case 12:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Savage_Tax", "Savage Tax");
					break;
				case 13:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Tax_Levels_Diabolic_Tax", "Diabolic Tax");
					break;
				}
			}
			string text = "";
			switch (rationsLevel)
			{
			case 0:
				text = "0";
				break;
			case 1:
				text = "1/4";
				break;
			case 2:
				text = "1/2";
				break;
			case 3:
				text = "x1";
				break;
			case 4:
				text = "x2";
				break;
			case 5:
				text = "x3";
				break;
			case 6:
				text = "x4";
				break;
			}
			if (this.extensionType == 1)
			{
				switch (rationsLevel)
				{
				case 0:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_No_Rations", "No Rations");
					break;
				case 1:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Meagre_Rations", "Meagre Rations");
					break;
				case 2:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Half_Rations", "Half Rations");
					break;
				case 3:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Normal_Rations", "Normal Rations");
					break;
				case 4:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Double_Rations", "Double Rations");
					break;
				case 5:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Triple_Rations", "Triple Rations");
					break;
				case 6:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Quad_Rations", "Quad Rations");
					break;
				}
			}
			if ((double)rationsLevel == effectiveRationsLevel)
			{
				this.rationsLine1Label.Color = global::ARGBColors.Black;
				this.rationsBar.clearMarker();
			}
			else
			{
				this.rationsLine1Label.Color = global::ARGBColors.Red;
				this.rationsBar.setMarker((double)(rationsLevel * 10));
			}
			this.rationsLine1Label.Text = text;
			string text2 = "";
			switch (aleRationsLevel)
			{
			case 0:
				text2 = "0";
				break;
			case 1:
				text2 = "x1";
				break;
			case 2:
				text2 = "x2";
				break;
			case 3:
				text2 = "x3";
				break;
			case 4:
				text2 = "x4";
				break;
			}
			if (this.extensionType == 2)
			{
				switch (aleRationsLevel)
				{
				case 0:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_No_Ale_Rations", "No Ale Rations");
					break;
				case 1:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Low_Ale_Rations", "Low Ale Rations");
					break;
				case 2:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Medium_Ale_Rations", "Medium Ale Rations");
					break;
				case 3:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_High_Ale_Rations", "High Ale Rations");
					break;
				case 4:
					this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Very_High_Ale_Rations", "Very High Ale Rations");
					break;
				}
			}
			if ((double)aleRationsLevel == effectiveAleRationsLevel)
			{
				this.aleRationsLine1Label.Color = global::ARGBColors.Black;
				this.aleRationsBar.clearMarker();
			}
			else
			{
				this.aleRationsLine1Label.Color = global::ARGBColors.Red;
				this.aleRationsBar.setMarker((double)(aleRationsLevel * 10));
			}
			this.aleRationsLine1Label.Text = text2;
			this.numFoodTypesEatenLabel.Text = numFoodTypesEaten.ToString();
			double num = (double)VillageBuildingsData.getTaxPopularityLevel(taxLevel);
			this.taxPopLabel.Text = num.ToString();
			this.taxBar.Number = (double)taxLevel;
			this.taxBar.MaxValue = (double)CardTypes.getMaxTaxLevel(GameEngine.Instance.cardsManager.UserCardData);
			if (num < 0.0)
			{
				this.popIndent1Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
			}
			else if (num > 0.0)
			{
				this.popIndent1Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			}
			else
			{
				this.popIndent1Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
			}
			double num2 = VillageBuildingsData.getRationsPopularityLevel(effectiveRationsLevel, GameEngine.Instance.LocalWorldData, GameEngine.Instance.cardsManager.UserCardData);
			if (effectiveRationsLevel > 0.0)
			{
				num2 += VillageBuildingsData.getNumFoodTypesEatenPopularityLevel(numFoodTypesEaten);
			}
			this.rationsPopLabel.Text = num2.ToString();
			this.rationsBar.Number = (double)((int)(effectiveRationsLevel * 10.0));
			if (num2 < 0.0)
			{
				this.popIndent2Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
			}
			else if (num2 > 0.0)
			{
				this.popIndent2Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
			}
			else
			{
				this.popIndent2Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
			}
			double aleRationsPopularityLevel = VillageBuildingsData.getAleRationsPopularityLevel(effectiveAleRationsLevel, GameEngine.Instance.LocalWorldData, GameEngine.Instance.cardsManager.UserCardData);
			this.alePopLabel.Text = aleRationsPopularityLevel.ToString();
			this.aleRationsBar.Number = (double)((int)effectiveAleRationsLevel * 10);
			if (aleRationsPopularityLevel < 0.0)
			{
				this.popIndent3Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
				return;
			}
			if (aleRationsPopularityLevel > 0.0)
			{
				this.popIndent3Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
				return;
			}
			this.popIndent3Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
		}

		// Token: 0x06002EDC RID: 11996 RVA: 0x0025E550 File Offset: 0x0025C750
		public void showBuildingInfo(int numPositiveBuildings, int numNegativeBuildings, int numPopularityBuildings)
		{
			double buildingsTypePopularityLevel = VillageBuildingsData.getBuildingsTypePopularityLevel(numPositiveBuildings, numNegativeBuildings, GameEngine.Instance.cardsManager.UserCardData);
			this.buildingPopLabel.Text = buildingsTypePopularityLevel.ToString();
			if (buildingsTypePopularityLevel < 0.0)
			{
				this.popIndent5Image.Image = GFXLibrary.r_popularity_panel_circle_inset_red;
				this.buildingsLabel.Color = global::ARGBColors.Red;
			}
			else if (buildingsTypePopularityLevel > 0.0)
			{
				this.popIndent5Image.Image = GFXLibrary.r_popularity_panel_circle_inset_green;
				this.buildingsLabel.Color = global::ARGBColors.Green;
			}
			else
			{
				this.popIndent5Image.Image = GFXLibrary.r_popularity_panel_circle_inset_tan;
				this.buildingsLabel.Color = global::ARGBColors.Black;
			}
			this.buildingsLabel.Text = numPopularityBuildings.ToString();
			this.negativeBuildingsLabel.Text = "";
			if (numPositiveBuildings > 0)
			{
				this.positiveBuildingsLabel.Text = "+";
			}
			else
			{
				this.positiveBuildingsLabel.Text = "";
			}
			if (numNegativeBuildings > 0)
			{
				this.negativeBuildingsLabel.Text = "-";
			}
			else
			{
				this.negativeBuildingsLabel.Text = "";
			}
			CustomSelfDrawPanel.CSDLabel csdlabel = this.positiveBuildingsLabel;
			csdlabel.Text += numPositiveBuildings.ToString();
			CustomSelfDrawPanel.CSDLabel csdlabel2 = this.negativeBuildingsLabel;
			csdlabel2.Text += numNegativeBuildings.ToString();
		}

		// Token: 0x06002EDD RID: 11997 RVA: 0x0025E6BC File Offset: 0x0025C8BC
		public void showDayRates(double goldDayRate, double dailyFoodConsumption, double dailyAleConsumption, double foodProductionRate, double aleProductionRate, int parishTax)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			this.taxDayValueLabel.Text = "0";
			if (goldDayRate > 0.0)
			{
				this.taxDayValueLabel.Text = "+" + goldDayRate.ToString("N", nfi);
			}
			else if (goldDayRate < 0.0)
			{
				this.taxDayValueLabel.Text = goldDayRate.ToString("N", nfi);
			}
			this.taxLine1Label.Text = this.taxDayValueLabel.Text;
			if (parishTax >= 0)
			{
				this.parishTaxDayLabel.Text = SK.Text("VillageMapPanel_Parish_Tithe", "Parish Tithe");
				this.parishTaxDayValueLabel.Text = parishTax.ToString("N", nfi);
				this.parishTaxDayValueLabel.Color = global::ARGBColors.Red;
			}
			else
			{
				this.parishTaxDayLabel.Text = SK.Text("VillageMapPanel_Parish_Bribe", "Parish Bribe");
				this.parishTaxDayValueLabel.Text = (-parishTax).ToString("N", nfi);
				this.parishTaxDayValueLabel.Color = global::ARGBColors.Black;
			}
			this.rationsDayValueLabel.Text = "0";
			if (dailyFoodConsumption > 0.0)
			{
				this.rationsDayValueLabel.Text = ((int)(dailyFoodConsumption + 0.01)).ToString("N", nfi);
			}
			this.rationsDay2ValueLabel.Text = ((int)(foodProductionRate + 0.01)).ToString("N", nfi);
			this.aleRationsDayValueLabel.Text = "0";
			if (dailyAleConsumption > 0.0)
			{
				this.aleRationsDayValueLabel.Text = ((int)(dailyAleConsumption + 0.01)).ToString("N", nfi);
			}
			this.aleRationsDay2ValueLabel.Text = ((int)(aleProductionRate + 0.01)).ToString("N", nfi);
		}

		// Token: 0x06002EDE RID: 11998 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void btnResources_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06002EDF RID: 11999 RVA: 0x0025E8A8 File Offset: 0x0025CAA8
		public void run()
		{
			if (this.taxLowerButtonGlow.Visible)
			{
				this.glowFade++;
				if (this.glowFade < 20)
				{
					this.taxLowerButtonGlow.Alpha = (float)this.glowFade / 20f / 2f + 0.5f;
				}
				else if (this.glowFade < 40)
				{
					this.taxLowerButtonGlow.Alpha = (float)(40 - this.glowFade) / 20f / 2f + 0.5f;
				}
				else
				{
					this.taxLowerButtonGlow.Alpha = 0.5f;
					this.glowFade = 0;
				}
				this.taxLowerButtonGlow.invalidate();
			}
			this.PopularityPanelUpdate();
			this.InBuildingPanelUpdate();
		}

		// Token: 0x06002EE0 RID: 12000 RVA: 0x00022034 File Offset: 0x00020234
		private void closePopularityPanel()
		{
			this.headerImage.CustomTooltipID = 121;
			this.targetHeight = 0;
			this.targetExtensionHeight = 0;
			this.reopenExtension = false;
		}

		// Token: 0x06002EE1 RID: 12001 RVA: 0x0025E964 File Offset: 0x0025CB64
		private void PopularityPanelUpdate()
		{
			bool flag = false;
			if (!this.m_villageIsCapital)
			{
				if (this.currentHeight != this.targetHeight)
				{
					if (this.currentHeight < this.targetHeight)
					{
						this.currentHeight += 50;
						if (this.currentHeight > this.targetHeight)
						{
							this.currentHeight = this.targetHeight;
						}
					}
					else
					{
						this.currentHeight -= 50;
						if (this.currentHeight < this.targetHeight)
						{
							this.currentHeight = this.targetHeight;
						}
					}
					this.panelImage.Y = 25 - (335 - this.currentHeight);
					this.panelImage.ClipRect = new Rectangle(0, 335 - this.currentHeight, this.panelImage.Width, this.currentHeight);
					flag = true;
					float num = (float)this.currentHeight / 335f * 2f - 1f;
					if (num < 0f)
					{
						num = 0f;
					}
					this.panelFaderImage.Alpha = 1f - num;
				}
				if (this.currentHeight == 0)
				{
					this.panelImage.Visible = false;
				}
				else
				{
					this.panelImage.Visible = true;
				}
				if (this.currentExtensionHeight != this.targetExtensionHeight || flag)
				{
					if (this.currentExtensionHeight < this.targetExtensionHeight)
					{
						this.currentExtensionHeight += 50;
						if (this.currentExtensionHeight > this.targetExtensionHeight)
						{
							this.currentExtensionHeight = this.targetExtensionHeight;
						}
					}
					else
					{
						this.currentExtensionHeight -= 50;
						if (this.currentExtensionHeight <= this.targetExtensionHeight)
						{
							this.currentExtensionHeight = this.targetExtensionHeight;
							if (this.reopenExtension)
							{
								this.targetExtensionHeight = 122;
								this.reopenExtension = false;
								this.extensionType = this.nextExtensionType;
								this.initExtentsion(this.extensionType);
							}
						}
					}
					this.extensionImage.Y = this.currentHeight - (144 - this.currentExtensionHeight);
					this.extensionImage.ClipRect = new Rectangle(0, 144 - this.currentExtensionHeight, this.extensionImage.Width, this.currentExtensionHeight);
					flag = true;
				}
				if (this.currentExtensionHeight == 0)
				{
					this.extensionImage.Visible = false;
				}
				else
				{
					this.extensionImage.Visible = true;
				}
				int num2 = this.calcBuildTabYPos();
				this.buildHeaderArea.Y = num2;
				if (this.currentBuildingHeight != this.targetBuildingHeight || flag)
				{
					if (this.currentBuildingHeight < this.targetBuildingHeight)
					{
						this.currentBuildingHeight += 50;
						if (this.currentBuildingHeight > this.targetBuildingHeight)
						{
							this.currentBuildingHeight = this.targetBuildingHeight;
						}
					}
					else
					{
						this.currentBuildingHeight -= 50;
						if (this.currentBuildingHeight <= this.targetBuildingHeight)
						{
							this.currentBuildingHeight = this.targetBuildingHeight;
							if (this.targetBuildingHeight == 0)
							{
								this.setBuildingTab(-1);
							}
						}
					}
					this.buildPanelImage.Y = 25 - (422 - this.currentBuildingHeight) + num2;
					this.buildPanelImage.ClipRect = new Rectangle(0, 422 - this.currentBuildingHeight, this.buildPanelImage.Width, this.currentBuildingHeight);
					flag = true;
					float num3 = (float)this.currentBuildingHeight / 422f * 2f - 1f;
					if (num3 < 0f)
					{
						num3 = 0f;
					}
					this.buildPanelFaderImage.Alpha = 1f - num3;
				}
				if (this.currentBuildingHeight == 0)
				{
					this.buildPanelImage.Visible = false;
				}
				else
				{
					this.buildPanelImage.Visible = true;
				}
				int num4 = this.calcInfoTabYPos();
				int num5 = num4 + Math.Max(this.currentInfo1Height + 25, 55) - 55;
				this.info1HeaderPanelImage.Y = num5;
				if (this.currentInBuildingHeight != this.targetInBuildingHeight || flag)
				{
					if (this.currentInBuildingHeight < this.targetInBuildingHeight)
					{
						this.currentInBuildingHeight += 50;
						if (this.currentInBuildingHeight > this.targetInBuildingHeight)
						{
							this.currentInBuildingHeight = this.targetInBuildingHeight;
						}
					}
					else
					{
						this.currentInBuildingHeight -= 50;
						if (this.currentInBuildingHeight <= this.targetInBuildingHeight)
						{
							this.currentInBuildingHeight = this.targetInBuildingHeight;
							if (this.targetInBuildingHeight == 0)
							{
								this.inBuildingHeaderPanelImage.Visible = false;
								this.inBuildingPanelImage.Visible = false;
							}
						}
					}
					this.inBuildingPanelImage.Y = 25 - (335 - this.currentInBuildingHeight) + num5;
					this.inBuildingPanelImage.Y += 55;
					this.inBuildingHeaderPanelImage.Y = num5 + 55;
					this.inBuildingPanelImage.ClipRect = new Rectangle(0, 335 - this.currentInBuildingHeight, this.inBuildingPanelImage.Width, this.currentInBuildingHeight);
					flag = true;
					float num6 = (float)this.currentInBuildingHeight / 335f * 2f - 1f;
					if (num6 < 0f)
					{
						num6 = 0f;
					}
					this.inBuildingFaderImage.Alpha = 1f - num6;
				}
				if (this.currentInBuildingHeight == 0)
				{
					this.inBuildingPanelImage.Visible = false;
				}
				else
				{
					this.inBuildingPanelImage.Visible = true;
				}
				this.info1HeaderPanelImage.Y = num4;
				if (this.currentInfo1Height != this.targetInfo1Height || flag)
				{
					if (this.currentInfo1Height < this.targetInfo1Height)
					{
						this.currentInfo1Height += 50;
						if (this.currentInfo1Height > this.targetInfo1Height)
						{
							this.currentInfo1Height = this.targetInfo1Height;
						}
					}
					else
					{
						this.currentInfo1Height -= 50;
						if (this.currentInfo1Height <= this.targetInfo1Height)
						{
							this.currentInfo1Height = this.targetInfo1Height;
						}
					}
					this.info1PanelImage.Y = 25 - (335 - this.currentInfo1Height) + num4;
					int currentResolution = GameEngine.Instance.CurrentResolution;
					this.info1PanelImage.ClipRect = new Rectangle(0, 335 - this.currentInfo1Height, this.info1PanelImage.Width, this.currentInfo1Height);
					flag = true;
					float num7 = (float)this.currentInfo1Height / 335f * 2f - 1f;
					if (num7 < 0f)
					{
						num7 = 0f;
					}
					this.info1PanelFaderImage.Alpha = 1f - num7;
				}
				if (this.currentInfo1Height == 0)
				{
					this.info1PanelImage.Visible = false;
				}
				else
				{
					this.info1PanelImage.Visible = true;
				}
				int num8 = this.calcInfo2TabYPos();
				this.info2HeaderPanelImage.Y = num8;
				this.info3HeaderPanelImage.Y = num8 + 55;
				this.extrasHeaderPanelImage.Y = num4;
			}
			else
			{
				int num9 = this.calcCapitalBuildTabYPos();
				this.buildHeaderArea.Y = num9;
				if (this.currentBuildingHeight != this.targetBuildingHeight || flag)
				{
					if (this.currentBuildingHeight < this.targetBuildingHeight)
					{
						this.currentBuildingHeight += 50;
						if (this.currentBuildingHeight > this.targetBuildingHeight)
						{
							this.currentBuildingHeight = this.targetBuildingHeight;
						}
					}
					else
					{
						this.currentBuildingHeight -= 50;
						if (this.currentBuildingHeight <= this.targetBuildingHeight)
						{
							this.currentBuildingHeight = this.targetBuildingHeight;
							if (this.targetBuildingHeight == 0)
							{
								this.setBuildingTab(-1);
							}
						}
					}
					this.buildPanelImage.Y = 25 - (422 - this.currentBuildingHeight) + num9;
					this.buildPanelImage.ClipRect = new Rectangle(0, 422 - this.currentBuildingHeight, this.buildPanelImage.Width, this.currentBuildingHeight);
					flag = true;
					float num10 = (float)this.currentBuildingHeight / 422f * 2f - 1f;
					if (num10 < 0f)
					{
						num10 = 0f;
					}
					this.buildPanelFaderImage.Alpha = 1f - num10;
				}
				if (this.currentBuildingHeight == 0)
				{
					this.buildPanelImage.Visible = false;
				}
				else
				{
					this.buildPanelImage.Visible = true;
				}
				int num11 = this.calcTop10YPos();
				int num12 = num11;
				this.capitalTop10HeaderImage.Y = num11;
				if (GameEngine.Instance.Village != null && this.currentTopGiversHeight > 0 && !GameEngine.Instance.World.isRegionCapital(GameEngine.Instance.Village.VillageID) && this.targetTopGiversHeight > 0)
				{
					this.targetTopGiversHeight = 0;
					this.currentTopGiversHeight = 1;
				}
				if (this.currentTopGiversHeight != this.targetTopGiversHeight || flag)
				{
					if (this.currentTopGiversHeight < this.targetTopGiversHeight)
					{
						this.currentTopGiversHeight += 50;
						if (this.currentTopGiversHeight > this.targetTopGiversHeight)
						{
							this.currentTopGiversHeight = this.targetTopGiversHeight;
						}
					}
					else
					{
						this.currentTopGiversHeight -= 50;
						if (this.currentTopGiversHeight <= this.targetTopGiversHeight)
						{
							this.currentTopGiversHeight = this.targetTopGiversHeight;
						}
					}
					this.capitalTop10PanelImage.Y = 25 - (422 - this.currentTopGiversHeight) + num11;
					this.capitalTop10PanelImage.ClipRect = new Rectangle(0, 422 - this.currentTopGiversHeight, this.capitalTop10PanelImage.Width, this.currentTopGiversHeight);
					flag = true;
					float num13 = (float)this.currentTopGiversHeight / 422f * 2f - 1f;
					if (num13 < 0f)
					{
						num13 = 0f;
					}
					this.capitalTop10PanelFaderImage.Alpha = 1f - num13;
				}
				if (this.currentTopGiversHeight == 0)
				{
					this.capitalTop10PanelImage.Visible = false;
				}
				else
				{
					this.capitalTop10PanelImage.Visible = true;
					num12 += Math.Max(this.currentTopGiversHeight - 55, 0);
				}
				if (this.currentInBuildingHeight != this.targetInBuildingHeight || flag)
				{
					if (this.currentInBuildingHeight < this.targetInBuildingHeight)
					{
						this.currentInBuildingHeight += 50;
						if (this.currentInBuildingHeight > this.targetInBuildingHeight)
						{
							this.currentInBuildingHeight = this.targetInBuildingHeight;
						}
					}
					else
					{
						this.currentInBuildingHeight -= 50;
						if (this.currentInBuildingHeight <= this.targetInBuildingHeight)
						{
							this.currentInBuildingHeight = this.targetInBuildingHeight;
							if (this.targetInBuildingHeight == 0)
							{
								this.inBuildingHeaderPanelImage.Visible = false;
								this.inBuildingPanelImage.Visible = false;
							}
						}
					}
					this.inBuildingPanelImage.Y = 25 - (335 - this.currentInBuildingHeight) + num12;
					this.inBuildingPanelImage.Y += 55;
					this.inBuildingHeaderPanelImage.Y = num12 + 55;
					this.inBuildingPanelImage.ClipRect = new Rectangle(0, 335 - this.currentInBuildingHeight, this.inBuildingPanelImage.Width, this.currentInBuildingHeight);
					flag = true;
					float num14 = (float)this.currentInBuildingHeight / 290f * 2f - 1f;
					if (num14 < 0f)
					{
						num14 = 0f;
					}
					this.inBuildingFaderImage.Alpha = 1f - num14;
				}
				if (this.currentInBuildingHeight == 0)
				{
					this.inBuildingPanelImage.Visible = false;
				}
				else
				{
					this.inBuildingPanelImage.Visible = true;
				}
			}
			if (flag)
			{
				base.Invalidate();
			}
		}

		// Token: 0x06002EE2 RID: 12002 RVA: 0x0025F460 File Offset: 0x0025D660
		private void headerClicked()
		{
			this.headerImage.CustomTooltipID = 122;
			this.closeBuildingPanel();
			this.closeInBuildingPanel();
			this.closeInfo1Panel();
			if (this.currentHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_popularity_header_open");
				this.targetHeight = 335;
				this.openExtension(0);
				if (GameEngine.Instance.World.getTutorialStage() == 103)
				{
					this.taxLowerButtonGlow.Visible = true;
				}
				else
				{
					this.taxLowerButtonGlow.Visible = false;
				}
			}
			else if (this.currentHeight == 335)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_popularity_header_close");
				this.closePopularityPanel();
			}
			this.showExtras();
		}

		// Token: 0x06002EE3 RID: 12003 RVA: 0x00022058 File Offset: 0x00020258
		private void headerMouseOver()
		{
			this.headerGlowImage.Visible = true;
		}

		// Token: 0x06002EE4 RID: 12004 RVA: 0x00022066 File Offset: 0x00020266
		private void headerMouseLeave()
		{
			this.headerGlowImage.Visible = false;
		}

		// Token: 0x06002EE5 RID: 12005 RVA: 0x0025F50C File Offset: 0x0025D70C
		private void taxLowerClicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.changeStats(-1, 0, 0);
				if (!GameEngine.Instance.World.TutorialIsAdvancing() && GameEngine.Instance.World.getTutorialStage() == 103)
				{
					GameEngine.Instance.World.handleQuestObjectiveHappening(14);
				}
			}
			if (this.isExtensionOpen())
			{
				this.extensionType = 0;
				this.initExtentsion(this.extensionType);
				return;
			}
			this.openExtension(0);
		}

		// Token: 0x06002EE6 RID: 12006 RVA: 0x0025F598 File Offset: 0x0025D798
		private void taxHigherClicked()
		{
			if (!this.ViewOnly)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeStats(1, 0, 0);
				}
				if (this.isExtensionOpen())
				{
					this.extensionType = 0;
					this.initExtentsion(this.extensionType);
					return;
				}
				this.openExtension(0);
			}
		}

		// Token: 0x06002EE7 RID: 12007 RVA: 0x0025F5F0 File Offset: 0x0025D7F0
		private void rationsLowerClicked()
		{
			if (!this.ViewOnly)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeStats(0, -1, 0);
				}
				if (this.isExtensionOpen())
				{
					this.extensionType = 1;
					this.initExtentsion(this.extensionType);
					return;
				}
				this.openExtension(1);
			}
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x0025F648 File Offset: 0x0025D848
		private void rationsHigherClicked()
		{
			if (!this.ViewOnly)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeStats(0, 1, 0);
				}
				if (this.isExtensionOpen())
				{
					this.extensionType = 1;
					this.initExtentsion(this.extensionType);
					return;
				}
				this.openExtension(1);
			}
		}

		// Token: 0x06002EE9 RID: 12009 RVA: 0x0025F6A0 File Offset: 0x0025D8A0
		private void aleLowerClicked()
		{
			if (!this.ViewOnly)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeStats(0, 0, -1);
				}
				if (this.isExtensionOpen())
				{
					this.extensionType = 2;
					this.initExtentsion(this.extensionType);
					return;
				}
				this.openExtension(2);
			}
		}

		// Token: 0x06002EEA RID: 12010 RVA: 0x0025F6F8 File Offset: 0x0025D8F8
		private void aleHigherClicked()
		{
			if (!this.ViewOnly)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeStats(0, 0, 1);
				}
				if (this.isExtensionOpen())
				{
					this.extensionType = 2;
					this.initExtentsion(this.extensionType);
					return;
				}
				this.openExtension(2);
			}
		}

		// Token: 0x06002EEB RID: 12011 RVA: 0x0025F750 File Offset: 0x0025D950
		private void openTaxExtension()
		{
			int num = 0;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_tax");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_tax");
			}
			this.openExtension(0);
		}

		// Token: 0x06002EEC RID: 12012 RVA: 0x00022074 File Offset: 0x00020274
		private void openTaxExtensionOver()
		{
			this.indent1Image.Image = GFXLibrary.r_popularity_panel_indent_a_over;
			this.popImage1.Image = GFXLibrary.r_popularity_panel_icon_taxes_over;
		}

		// Token: 0x06002EED RID: 12013 RVA: 0x000220A0 File Offset: 0x000202A0
		private void openTaxExtensionLeave()
		{
			this.indent1Image.Image = GFXLibrary.r_popularity_panel_indent_a;
			this.popImage1.Image = GFXLibrary.r_popularity_panel_icon_taxes;
		}

		// Token: 0x06002EEE RID: 12014 RVA: 0x0025F7C4 File Offset: 0x0025D9C4
		private void openRationsExtension()
		{
			int num = 1;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_rations");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_rations");
			}
			this.openExtension(1);
		}

		// Token: 0x06002EEF RID: 12015 RVA: 0x000220CC File Offset: 0x000202CC
		private void openRationsExtensionOver()
		{
			this.indent2Image.Image = GFXLibrary.r_popularity_panel_indent_a_over;
			this.popImage2.Image = GFXLibrary.r_popularity_panel_icon_rations_over;
		}

		// Token: 0x06002EF0 RID: 12016 RVA: 0x000220F8 File Offset: 0x000202F8
		private void openRationsExtensionLeave()
		{
			this.indent2Image.Image = GFXLibrary.r_popularity_panel_indent_a;
			this.popImage2.Image = GFXLibrary.r_popularity_panel_icon_rations;
		}

		// Token: 0x06002EF1 RID: 12017 RVA: 0x0025F838 File Offset: 0x0025DA38
		private void openAleExtension()
		{
			int num = 2;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_ale");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_ale");
			}
			this.openExtension(2);
		}

		// Token: 0x06002EF2 RID: 12018 RVA: 0x00022124 File Offset: 0x00020324
		private void openAleExtensionOver()
		{
			this.popImage3.Image = GFXLibrary.r_popularity_panel_icon_ale_over;
			this.indent3Image.Image = GFXLibrary.r_popularity_panel_indent_a_over;
		}

		// Token: 0x06002EF3 RID: 12019 RVA: 0x00022150 File Offset: 0x00020350
		private void openAleExtensionLeave()
		{
			this.popImage3.Image = GFXLibrary.r_popularity_panel_icon_ale;
			this.indent3Image.Image = GFXLibrary.r_popularity_panel_indent_a;
		}

		// Token: 0x06002EF4 RID: 12020 RVA: 0x0025F8AC File Offset: 0x0025DAAC
		private void openBuildingExtension()
		{
			int num = 4;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_buildings_ext");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_buildings_ext");
			}
			this.openExtension(4);
		}

		// Token: 0x06002EF5 RID: 12021 RVA: 0x0002217C File Offset: 0x0002037C
		private void openBuildingExtensionOver()
		{
			this.indent5Image.Image = GFXLibrary.r_popularity_panel_indent_b_over;
			this.popImage5.Image = GFXLibrary.r_popularity_panel_icon_buildings_over;
		}

		// Token: 0x06002EF6 RID: 12022 RVA: 0x000221A8 File Offset: 0x000203A8
		private void openBuildingExtensionLeave()
		{
			this.indent5Image.Image = GFXLibrary.r_popularity_panel_indent_b;
			this.popImage5.Image = GFXLibrary.r_popularity_panel_icon_buildings;
		}

		// Token: 0x06002EF7 RID: 12023 RVA: 0x0025F920 File Offset: 0x0025DB20
		private void openHousingExtension()
		{
			int num = 3;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_housing");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_housing");
			}
			this.openExtension(3);
		}

		// Token: 0x06002EF8 RID: 12024 RVA: 0x000221D4 File Offset: 0x000203D4
		private void openHousingExtensionOver()
		{
			this.indent4Image.Image = GFXLibrary.r_popularity_panel_indent_b_over;
			this.popImage4.Image = GFXLibrary.r_popularity_panel_icon_housing_over;
		}

		// Token: 0x06002EF9 RID: 12025 RVA: 0x00022200 File Offset: 0x00020400
		private void openHousingExtensionLeave()
		{
			this.indent4Image.Image = GFXLibrary.r_popularity_panel_indent_b;
			this.popImage4.Image = GFXLibrary.r_popularity_panel_icon_housing;
		}

		// Token: 0x06002EFA RID: 12026 RVA: 0x0025F994 File Offset: 0x0025DB94
		private void openEventsExtension()
		{
			int num = 5;
			if (this.currentExtensionHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_open_events");
			}
			else if (this.isExtensionOpen() && this.extensionType != num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_extension_changed");
			}
			else if (this.isExtensionOpen() && this.extensionType == num)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_close_events");
			}
			this.openExtension(5);
		}

		// Token: 0x06002EFB RID: 12027 RVA: 0x0002222C File Offset: 0x0002042C
		private void openEventsExtensionOver()
		{
			this.indent6Image.Image = GFXLibrary.r_popularity_panel_indent_b_over;
		}

		// Token: 0x06002EFC RID: 12028 RVA: 0x00022243 File Offset: 0x00020443
		private void openEventsExtensionLeave()
		{
			this.indent6Image.Image = GFXLibrary.r_popularity_panel_indent_b;
		}

		// Token: 0x06002EFD RID: 12029 RVA: 0x0002225A File Offset: 0x0002045A
		private bool isExtensionOpen()
		{
			return this.currentExtensionHeight == 122;
		}

		// Token: 0x06002EFE RID: 12030 RVA: 0x0025FA08 File Offset: 0x0025DC08
		private void openExtension(int newType)
		{
			this.indent1Image.CustomTooltipID = 123;
			this.indent2Image.CustomTooltipID = 125;
			this.indent3Image.CustomTooltipID = 127;
			this.indent4Image.CustomTooltipID = 129;
			this.indent5Image.CustomTooltipID = 131;
			this.indent6Image.CustomTooltipID = 133;
			if (this.currentExtensionHeight == 0)
			{
				this.extensionType = newType;
				this.targetExtensionHeight = 122;
				this.initExtentsion(newType);
				return;
			}
			if (this.isExtensionOpen() && this.extensionType != newType)
			{
				this.extensionType = newType;
				this.initExtentsion(newType);
				return;
			}
			if (this.isExtensionOpen() && this.extensionType == newType)
			{
				this.targetExtensionHeight = 0;
			}
		}

		// Token: 0x06002EFF RID: 12031 RVA: 0x0025FAC4 File Offset: 0x0025DCC4
		private void initExtentsion(int type)
		{
			switch (type)
			{
			case 0:
				this.indent1Image.CustomTooltipID = 124;
				break;
			case 1:
				this.indent2Image.CustomTooltipID = 126;
				break;
			case 2:
				this.indent3Image.CustomTooltipID = 128;
				break;
			case 3:
				this.indent4Image.CustomTooltipID = 130;
				break;
			case 4:
				this.indent5Image.CustomTooltipID = 132;
				break;
			case 5:
				this.indent6Image.CustomTooltipID = 134;
				break;
			}
			this.taxExtensionArea.Visible = false;
			this.rationsExtensionArea.Visible = false;
			this.aleExtensionArea.Visible = false;
			this.buildingExtensionArea.Visible = false;
			this.housingExtensionArea.Visible = false;
			this.eventsExtensionArea.Visible = false;
			switch (type)
			{
			case 0:
				this.taxExtensionArea.Visible = true;
				return;
			case 1:
				this.rationsExtensionArea.Visible = true;
				return;
			case 2:
				this.aleExtensionArea.Visible = true;
				return;
			case 3:
				this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Housing", "Housing");
				this.housingExtensionArea.Visible = true;
				return;
			case 4:
				this.extensionHeaderLabel.Text = SK.Text("VillageMapPanel_Buildings", "Buildings");
				this.buildingExtensionArea.Visible = true;
				return;
			case 5:
				this.extensionHeaderLabel.Text = "";
				this.eventsExtensionArea.Visible = true;
				return;
			default:
				return;
			}
		}

		// Token: 0x06002F00 RID: 12032 RVA: 0x0025FC50 File Offset: 0x0025DE50
		public void initBuildingPanel()
		{
			int num = this.calcBuildTabYPos();
			this.buildPanelImage.Image = GFXLibrary.r_building_panel_back;
			this.buildPanelImage.Position = new Point(0, num + 25);
			base.addControl(this.buildPanelImage);
			this.building1Button.Position = new Point(6, 14);
			this.building1Button.Visible = false;
			this.building1Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building1Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building1Button);
			this.building1Image.Image = GFXLibrary.building_icon_circle;
			this.building1Image.Alpha = 0.65f;
			this.building1Image.Position = new Point(64, 59);
			this.building1Button.addControl(this.building1Image);
			this.building1Label.Text = "0";
			this.building1Label.Color = global::ARGBColors.Black;
			this.building1Label.Position = new Point(0, -2);
			this.building1Label.Size = this.building1Image.Size;
			this.building1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building1Image.addControl(this.building1Label);
			this.building2Button.Position = new Point(88, 14);
			this.building2Button.Visible = false;
			this.building2Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building2Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building2Button);
			this.building2Image.Image = GFXLibrary.building_icon_circle;
			this.building2Image.Alpha = 0.65f;
			this.building2Image.Position = new Point(64, 59);
			this.building2Button.addControl(this.building2Image);
			this.building2Label.Text = "0";
			this.building2Label.Color = global::ARGBColors.Black;
			this.building2Label.Position = new Point(0, -2);
			this.building2Label.Size = this.building2Image.Size;
			this.building2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building2Image.addControl(this.building2Label);
			this.building3Button.Position = new Point(6, 89);
			this.building3Button.Visible = false;
			this.building3Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building3Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building3Button);
			this.building3Image.Image = GFXLibrary.building_icon_circle;
			this.building3Image.Alpha = 0.65f;
			this.building3Image.Position = new Point(64, 59);
			this.building3Button.addControl(this.building3Image);
			this.building3Label.Text = "0";
			this.building3Label.Color = global::ARGBColors.Black;
			this.building3Label.Position = new Point(0, -2);
			this.building3Label.Size = this.building3Image.Size;
			this.building3Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building3Image.addControl(this.building3Label);
			this.building4Button.Position = new Point(88, 89);
			this.building4Button.Visible = false;
			this.building4Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building4Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building4Button);
			this.building4Image.Image = GFXLibrary.building_icon_circle;
			this.building4Image.Alpha = 0.65f;
			this.building4Image.Position = new Point(64, 59);
			this.building4Button.addControl(this.building4Image);
			this.building4Label.Text = "0";
			this.building4Label.Color = global::ARGBColors.Black;
			this.building4Label.Position = new Point(0, -2);
			this.building4Label.Size = this.building4Image.Size;
			this.building4Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building4Image.addControl(this.building4Label);
			this.building5Button.Position = new Point(6, 164);
			this.building5Button.Visible = false;
			this.building5Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building5Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building5Button);
			this.building5Image.Image = GFXLibrary.building_icon_circle;
			this.building5Image.Alpha = 0.65f;
			this.building5Image.Position = new Point(64, 59);
			this.building5Button.addControl(this.building5Image);
			this.building5Label.Text = "0";
			this.building5Label.Color = global::ARGBColors.Black;
			this.building5Label.Position = new Point(0, -2);
			this.building5Label.Size = this.building5Image.Size;
			this.building5Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building5Image.addControl(this.building5Label);
			this.building6Button.Position = new Point(88, 164);
			this.building6Button.Visible = false;
			this.building6Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building6Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building6Button);
			this.building6Image.Image = GFXLibrary.building_icon_circle;
			this.building6Image.Alpha = 0.65f;
			this.building6Image.Position = new Point(64, 59);
			this.building6Button.addControl(this.building6Image);
			this.building6Label.Text = "0";
			this.building6Label.Color = global::ARGBColors.Black;
			this.building6Label.Position = new Point(0, -2);
			this.building6Label.Size = this.building6Image.Size;
			this.building6Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building6Image.addControl(this.building6Label);
			this.building7Button.Position = new Point(6, 239);
			this.building7Button.Visible = false;
			this.building7Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building7Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building7Button);
			this.building7Image.Image = GFXLibrary.building_icon_circle;
			this.building7Image.Alpha = 0.65f;
			this.building7Image.Position = new Point(64, 59);
			this.building7Button.addControl(this.building7Image);
			this.building7Label.Text = "0";
			this.building7Label.Color = global::ARGBColors.Black;
			this.building7Label.Position = new Point(0, -2);
			this.building7Label.Size = this.building7Image.Size;
			this.building7Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building7Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building7Image.addControl(this.building7Label);
			this.building8Button.Position = new Point(88, 239);
			this.building8Button.Visible = false;
			this.building8Button.ClickArea = new Rectangle(10, 10, 85, 85);
			this.building8Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.placeBuildingClick), "VillageMapPanel_place_building");
			this.building8Button.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.placeBuildingMouseLeave));
			this.buildPanelImage.addControl(this.building8Button);
			this.building8Image.Image = GFXLibrary.building_icon_circle;
			this.building8Image.Alpha = 0.65f;
			this.building8Image.Position = new Point(64, 59);
			this.building8Button.addControl(this.building8Image);
			this.building8Label.Text = "0";
			this.building8Label.Color = global::ARGBColors.Black;
			this.building8Label.Position = new Point(0, -2);
			this.building8Label.Size = this.building8Image.Size;
			this.building8Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.building8Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.building8Image.addControl(this.building8Label);
			this.buildHeaderArea.Position = new Point(0, num);
			this.buildHeaderArea.Size = new Size(196, 62);
			base.addControl(this.buildHeaderArea);
			this.setBuildingTab(-1);
			this.buildTab1Button.Position = new Point(0, 0);
			this.buildTab1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buildingTab1Clicked));
			this.buildHeaderArea.addControl(this.buildTab1Button);
			this.buildTab2Button.Position = new Point(44, 0);
			this.buildTab2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buildingTab2Clicked));
			this.buildHeaderArea.addControl(this.buildTab2Button);
			this.buildTab3Button.Position = new Point(81, 0);
			this.buildTab3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buildingTab3Clicked));
			this.buildHeaderArea.addControl(this.buildTab3Button);
			this.buildTab4Button.Position = new Point(118, 0);
			this.buildTab4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buildingTab4Clicked));
			this.buildHeaderArea.addControl(this.buildTab4Button);
			this.buildTab5Button.Position = new Point(154, 0);
			this.buildTab5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buildingTab5Clicked));
			this.buildHeaderArea.addControl(this.buildTab5Button);
			this.buildInfoImage.Image = GFXLibrary.r_building_panel_inset;
			this.buildInfoImage.Position = new Point(12, 327);
			this.buildPanelImage.addControl(this.buildInfoImage);
			this.buildTypeLabel.Text = "";
			this.buildTypeLabel.Color = global::ARGBColors.Black;
			this.buildTypeLabel.Position = new Point(13, 4);
			this.buildTypeLabel.Visible = false;
			if (Program.mySettings.LanguageIdent == "pl" || Program.mySettings.LanguageIdent == "tr" || Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.buildTypeLabel.Size = new Size(161, 20);
				this.buildTypeLabel.Font = FontManager.GetFont("Arial", 7.5f);
			}
			else
			{
				this.buildTypeLabel.Size = new Size(141, 20);
				this.buildTypeLabel.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.buildInfoImage.addControl(this.buildTypeLabel);
			this.buildTimeImage.Image = GFXLibrary.r_building_panel_inset_icon_time;
			this.buildTimeImage.Position = new Point(13, 22);
			this.buildInfoImage.addControl(this.buildTimeImage);
			this.buildTimeLabel.Text = "";
			this.buildTimeLabel.Color = global::ARGBColors.Black;
			this.buildTimeLabel.Position = new Point(40, 26);
			this.buildTimeLabel.Size = new Size(120, 20);
			this.buildTimeLabel.Visible = false;
			this.buildInfoImage.addControl(this.buildTimeLabel);
			this.buildWoodImage.Image = GFXLibrary.r_building_panel_inset_icon_wood;
			this.buildWoodImage.Position = new Point(13, 40);
			this.buildInfoImage.addControl(this.buildWoodImage);
			this.buildWoodLabel.Text = "0";
			this.buildWoodLabel.Color = global::ARGBColors.Black;
			this.buildWoodLabel.Position = new Point(40, 44);
			this.buildWoodLabel.Size = new Size(46, 20);
			this.buildWoodLabel.Visible = false;
			this.buildInfoImage.addControl(this.buildWoodLabel);
			this.buildStoneImage.Image = GFXLibrary.r_building_panel_inset_icon_stone;
			this.buildStoneImage.Position = new Point(13, 58);
			this.buildInfoImage.addControl(this.buildStoneImage);
			this.buildStoneLabel.Text = "0";
			this.buildStoneLabel.Color = global::ARGBColors.Black;
			this.buildStoneLabel.Position = new Point(40, 62);
			this.buildStoneLabel.Size = new Size(46, 20);
			this.buildStoneLabel.Visible = false;
			this.buildInfoImage.addControl(this.buildStoneLabel);
			this.buildGoldImage.Image = GFXLibrary.r_building_panel_inset_icon_gold;
			this.buildGoldImage.Position = new Point(86, 40);
			this.buildInfoImage.addControl(this.buildGoldImage);
			this.buildGoldLabel.Text = "0";
			this.buildGoldLabel.Color = global::ARGBColors.Black;
			this.buildGoldLabel.Position = new Point(113, 44);
			this.buildGoldLabel.Size = new Size(46, 20);
			this.buildGoldLabel.Visible = false;
			this.buildInfoImage.addControl(this.buildGoldLabel);
			this.buildTooltipArea.Position = new Point(13, 22);
			this.buildTooltipArea.Size = new Size(150, 56);
			this.buildTooltipArea.CustomTooltipID = 140;
			this.buildInfoImage.addControl(this.buildTooltipArea);
			this.buildCapitalHelp.ImageNorm = GFXLibrary.help_normal;
			this.buildCapitalHelp.ImageOver = GFXLibrary.help_over;
			this.buildCapitalHelp.ImageClick = GFXLibrary.help_pushed;
			this.buildCapitalHelp.Position = new Point(143, 64);
			this.buildCapitalHelp.Visible = false;
			this.buildCapitalHelp.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.helpClicked), "VillageMapPanel_help");
			this.buildInfoImage.addControl(this.buildCapitalHelp);
			this.buildDonationTypeImage.Image = this.getCapitalBuildingDonationTypeImage(103);
			this.buildDonationTypeImage.setSizeToImage();
			this.buildDonationTypeImage.Position = new Point(this.buildCapitalHelp.Rectangle.Right - this.buildDonationTypeImage.Width, this.buildTimeLabel.Y - 17);
			this.buildDonationTypeImage.CustomTooltipID = 147;
			this.buildInfoImage.addControl(this.buildDonationTypeImage);
			this.buildDonationTypeImage.Visible = false;
			this.buildPanelFaderImage.Image = GFXLibrary.r_building_panel_back;
			this.buildPanelFaderImage.Position = new Point(0, 0);
			this.buildPanelFaderImage.Alpha = 0f;
			this.buildPanelImage.addControl(this.buildPanelFaderImage);
			this.clearBuildingInfo();
			this.currentBuildingHeight = 1;
			this.targetBuildingHeight = 0;
		}

		// Token: 0x06002F01 RID: 12033 RVA: 0x00022266 File Offset: 0x00020466
		private void openBuildingTab()
		{
			this.closeTopGivers();
			this.closeInBuildingPanel();
			this.closePopularityPanel();
			this.closeInfo1Panel();
			this.targetBuildingHeight = 422;
			this.showExtras();
		}

		// Token: 0x06002F02 RID: 12034 RVA: 0x00022291 File Offset: 0x00020491
		private void closeBuildingPanel()
		{
			this.targetBuildingHeight = 0;
		}

		// Token: 0x06002F03 RID: 12035 RVA: 0x00260E28 File Offset: 0x0025F028
		private void buildingTab1Clicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (this.currentBuildingHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_open");
				this.openBuildingTab();
			}
			else
			{
				if (this.currentTab == 0 || this.currentTab >= 1000)
				{
					GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_close");
					this.closeBuildingPanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_clicked");
			}
			this.setBuildingTab(0);
		}

		// Token: 0x06002F04 RID: 12036 RVA: 0x00260EA0 File Offset: 0x0025F0A0
		private void buildingTab2Clicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (this.currentBuildingHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_open");
				this.openBuildingTab();
			}
			else
			{
				if (this.currentTab == 1)
				{
					GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_close");
					this.closeBuildingPanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_clicked");
			}
			this.setBuildingTab(1);
		}

		// Token: 0x06002F05 RID: 12037 RVA: 0x00260F0C File Offset: 0x0025F10C
		private void buildingTab3Clicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (this.currentBuildingHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_open");
				this.openBuildingTab();
			}
			else
			{
				if (this.currentTab == 2)
				{
					GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_close");
					this.closeBuildingPanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_clicked");
			}
			this.setBuildingTab(2);
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x00260F78 File Offset: 0x0025F178
		private void buildingTab4Clicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (this.currentBuildingHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_open");
				this.openBuildingTab();
			}
			else
			{
				if (this.currentTab == 3)
				{
					GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_close");
					this.closeBuildingPanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_clicked");
			}
			this.setBuildingTab(3);
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x00260FE4 File Offset: 0x0025F1E4
		private void buildingTab5Clicked()
		{
			if (this.ViewOnly)
			{
				return;
			}
			if (this.currentBuildingHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_open");
				this.openBuildingTab();
			}
			else
			{
				if (this.currentTab == 4)
				{
					GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_close");
					this.closeBuildingPanel();
					return;
				}
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_buildings_tab_clicked");
			}
			this.setBuildingTab(4);
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x0002229A File Offset: 0x0002049A
		public void villageReshowAfterStockpilePlaced()
		{
			if (this.currentTab >= 0)
			{
				this.setBuildingTab(this.currentTab);
				return;
			}
			this.setBuildingTab(1);
		}

		// Token: 0x06002F09 RID: 12041 RVA: 0x000222B9 File Offset: 0x000204B9
		public bool isVillageMapPanelOnFoodTab()
		{
			return this.currentTab == 2;
		}

		// Token: 0x06002F0A RID: 12042 RVA: 0x000222C7 File Offset: 0x000204C7
		public bool isVillageMapPanelOnIndustryTab()
		{
			return this.currentTab == 1;
		}

		// Token: 0x06002F0B RID: 12043 RVA: 0x000222D5 File Offset: 0x000204D5
		public bool isVillageMapPanelOnPopularityBar()
		{
			return this.currentHeight > 0;
		}

		// Token: 0x06002F0C RID: 12044 RVA: 0x00261050 File Offset: 0x0025F250
		private void setBuildingTab(int tab)
		{
			this.buildTab1Button.CustomTooltipData = 0;
			this.buildTab2Button.CustomTooltipData = 0;
			this.buildTab3Button.CustomTooltipData = 0;
			this.buildTab4Button.CustomTooltipData = 0;
			this.buildTab5Button.CustomTooltipData = 0;
			this.currentTab = tab;
			if (!this.m_villageIsCapital)
			{
				this.buildTab1Button.Position = new Point(0, 0);
				this.buildTab2Button.Position = new Point(44, 0);
				this.buildTab3Button.Position = new Point(81, 0);
				this.buildTab4Button.Position = new Point(118, 0);
				this.buildTab5Button.Position = new Point(154, 0);
				this.buildTab5Button.Visible = true;
				this.buildTab1Button.ImageNorm = GFXLibrary.r_building_bar_tab1_norm;
				this.buildTab1Button.ImageOver = GFXLibrary.r_building_bar_tab1_over;
				this.buildTab1Button.ImageClick = GFXLibrary.r_building_bar_tab1_in;
				this.buildTab1Button.CustomTooltipID = 101;
				this.buildTab2Button.ImageNorm = GFXLibrary.r_building_bar_tab2_norm;
				this.buildTab2Button.ImageOver = GFXLibrary.r_building_bar_tab2_over;
				this.buildTab2Button.ImageClick = GFXLibrary.r_building_bar_tab2_in;
				this.buildTab2Button.CustomTooltipID = 102;
				this.buildTab3Button.ImageNorm = GFXLibrary.r_building_bar_tab3_norm;
				this.buildTab3Button.ImageOver = GFXLibrary.r_building_bar_tab3_over;
				this.buildTab3Button.ImageClick = GFXLibrary.r_building_bar_tab3_in;
				this.buildTab3Button.CustomTooltipID = 103;
				this.buildTab4Button.ImageNorm = GFXLibrary.r_building_bar_tab4_norm;
				this.buildTab4Button.ImageOver = GFXLibrary.r_building_bar_tab4_over;
				this.buildTab4Button.ImageClick = GFXLibrary.r_building_bar_tab4_in;
				this.buildTab4Button.CustomTooltipID = 104;
				this.buildTab5Button.ImageNorm = GFXLibrary.r_building_bar_tab5_norm;
				this.buildTab5Button.ImageOver = GFXLibrary.r_building_bar_tab5_over;
				this.buildTab5Button.ImageClick = GFXLibrary.r_building_bar_tab5_in;
				this.buildTab5Button.CustomTooltipID = 105;
			}
			else
			{
				this.buildTab1Button.Position = new Point(0, 0);
				this.buildTab2Button.Position = new Point(51, 0);
				this.buildTab3Button.Position = new Point(98, 0);
				this.buildTab4Button.Position = new Point(145, 0);
				this.buildTab5Button.Visible = false;
				this.buildTab1Button.ImageNorm = GFXLibrary.townscreen_castle_normal;
				this.buildTab1Button.ImageOver = GFXLibrary.townscreen_castle_over;
				this.buildTab1Button.ImageClick = GFXLibrary.townscreen_castle_over;
				this.buildTab1Button.CustomTooltipID = 106;
				this.buildTab2Button.ImageNorm = GFXLibrary.townscreen_army_normal;
				this.buildTab2Button.ImageOver = GFXLibrary.townscreen_army_over;
				this.buildTab2Button.ImageClick = GFXLibrary.townscreen_army_over;
				this.buildTab2Button.CustomTooltipID = 107;
				this.buildTab3Button.ImageNorm = GFXLibrary.townscreen_civil_normal;
				this.buildTab3Button.ImageOver = GFXLibrary.townscreen_civil_over;
				this.buildTab3Button.ImageClick = GFXLibrary.townscreen_civil_over;
				this.buildTab3Button.CustomTooltipID = 108;
				this.buildTab4Button.ImageNorm = GFXLibrary.townscreen_guild_normal;
				this.buildTab4Button.ImageOver = GFXLibrary.townscreen_guild_over;
				this.buildTab4Button.ImageClick = GFXLibrary.townscreen_guild_over;
				this.buildTab4Button.CustomTooltipID = 109;
			}
			int num = tab;
			if (tab - 1112 <= 4)
			{
				num = 3;
			}
			switch (num)
			{
			case -1:
				break;
			default:
				this.buildTab1Button.CustomTooltipData = 1;
				if (!this.m_villageIsCapital)
				{
					this.buildTab1Button.ImageNorm = GFXLibrary.r_building_bar_tab1_arrow_norm;
					this.buildTab1Button.ImageOver = GFXLibrary.r_building_bar_tab1_arrow_over;
					this.buildTab1Button.ImageClick = GFXLibrary.r_building_bar_tab1_arrow_in;
				}
				else
				{
					this.buildTab1Button.ImageNorm = GFXLibrary.townscreen_castle_selected;
					this.buildTab1Button.ImageOver = GFXLibrary.townscreen_castle_selected;
					this.buildTab1Button.ImageClick = GFXLibrary.townscreen_castle_selected;
				}
				break;
			case 1:
				this.buildTab2Button.CustomTooltipData = 1;
				if (!this.m_villageIsCapital)
				{
					this.buildTab2Button.ImageNorm = GFXLibrary.r_building_bar_tab2_arrow_norm;
					this.buildTab2Button.ImageOver = GFXLibrary.r_building_bar_tab2_arrow_over;
					this.buildTab2Button.ImageClick = GFXLibrary.r_building_bar_tab2_arrow_in;
				}
				else
				{
					this.buildTab2Button.ImageNorm = GFXLibrary.townscreen_army_selected;
					this.buildTab2Button.ImageOver = GFXLibrary.townscreen_army_selected;
					this.buildTab2Button.ImageClick = GFXLibrary.townscreen_army_selected;
				}
				break;
			case 2:
				this.buildTab3Button.CustomTooltipData = 1;
				if (!this.m_villageIsCapital)
				{
					this.buildTab3Button.ImageNorm = GFXLibrary.r_building_bar_tab3_arrow_norm;
					this.buildTab3Button.ImageOver = GFXLibrary.r_building_bar_tab3_arrow_over;
					this.buildTab3Button.ImageClick = GFXLibrary.r_building_bar_tab3_arrow_in;
				}
				else
				{
					this.buildTab3Button.ImageNorm = GFXLibrary.townscreen_civil_selected;
					this.buildTab3Button.ImageOver = GFXLibrary.townscreen_civil_selected;
					this.buildTab3Button.ImageClick = GFXLibrary.townscreen_civil_selected;
				}
				break;
			case 3:
				this.buildTab4Button.CustomTooltipData = 1;
				if (!this.m_villageIsCapital)
				{
					this.buildTab4Button.ImageNorm = GFXLibrary.r_building_bar_tab4_arrow_norm;
					this.buildTab4Button.ImageOver = GFXLibrary.r_building_bar_tab4_arrow_over;
					this.buildTab4Button.ImageClick = GFXLibrary.r_building_bar_tab4_arrow_in;
				}
				else
				{
					this.buildTab4Button.ImageNorm = GFXLibrary.townscreen_guild_selected;
					this.buildTab4Button.ImageOver = GFXLibrary.townscreen_guild_selected;
					this.buildTab4Button.ImageClick = GFXLibrary.townscreen_guild_selected;
				}
				break;
			case 4:
				this.buildTab5Button.CustomTooltipData = 1;
				this.buildTab5Button.ImageNorm = GFXLibrary.r_building_bar_tab5_arrow_norm;
				this.buildTab5Button.ImageOver = GFXLibrary.r_building_bar_tab5_arrow_over;
				this.buildTab5Button.ImageClick = GFXLibrary.r_building_bar_tab5_arrow_in;
				break;
			}
			this.resetBuildingIcons();
			switch (tab)
			{
			case 0:
				if (!this.m_villageIsCapital)
				{
					switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
					{
					case 3:
					case 4:
						this.addBuildingIcon(1, GFXLibrary.r_building_panel_bld_civ_house_2, GFXLibrary.r_building_panel_bld_civ_house_2_over);
						break;
					case 5:
					case 6:
						this.addBuildingIcon(1, GFXLibrary.r_building_panel_bld_civ_house_3, GFXLibrary.r_building_panel_bld_civ_house_3_over);
						break;
					case 7:
					case 8:
						this.addBuildingIcon(1, GFXLibrary.r_building_panel_bld_civ_house_4, GFXLibrary.r_building_panel_bld_civ_house_4_over);
						break;
					case 9:
					case 10:
						this.addBuildingIcon(1, GFXLibrary.r_building_panel_bld_civ_house_5, GFXLibrary.r_building_panel_bld_civ_house_5_over);
						break;
					default:
						this.addBuildingIcon(1, GFXLibrary.r_building_panel_bld_civ_house_1, GFXLibrary.r_building_panel_bld_civ_house_1_over);
						break;
					}
					this.addBuildingIcon(1001, GFXLibrary.r_building_panel_bld_civ_dec_sub_category, GFXLibrary.r_building_panel_bld_civ_dec_sub_category_over);
					this.addBuildingIcon(1003, GFXLibrary.r_building_panel_bld_civ_ent_sub_category, GFXLibrary.r_building_panel_bld_civ_ent_sub_category_over);
					this.addBuildingIcon(1000, GFXLibrary.r_building_panel_bld_civ_rel_sub_category, GFXLibrary.r_building_panel_bld_civ_rel_sub_category_over);
					this.addBuildingIcon(1002, GFXLibrary.r_building_panel_bld_civ_jus_sub_category, GFXLibrary.r_building_panel_bld_civ_jus_sub_category_over);
					return;
				}
				this.addBuildingIcon(103, GFXLibrary.townbuilding_architectsguild_normal, GFXLibrary.townbuilding_architectsguild_over);
				this.addBuildingIcon(104, GFXLibrary.townbuilding_Labourersbillets_normal, GFXLibrary.townbuilding_Labourersbillets_over);
				this.addBuildingIcon(105, GFXLibrary.townbuilding_castellanshouse_normal, GFXLibrary.townbuilding_castellanshouse_over);
				this.addBuildingIcon(106, GFXLibrary.townbuilding_sergeantsatarmsoffice_normal, GFXLibrary.townbuilding_sergeantsatarmsoffice_over);
				this.addBuildingIcon(107, GFXLibrary.townbuilding_stables_normal, GFXLibrary.townbuilding_stables_over);
				this.addBuildingIcon(121, GFXLibrary.townbuilding_turretmaker_normal, GFXLibrary.townbuilding_turretmaker_over);
				this.addBuildingIcon(122, GFXLibrary.townbuilding_tunnellorsguild_normal, GFXLibrary.townbuilding_tunnellorsguild_over);
				this.addBuildingIcon(123, GFXLibrary.townbuilding_ballistamaker_normal, GFXLibrary.townbuilding_ballistamaker_over);
				return;
			case 1:
				if (!this.m_villageIsCapital)
				{
					this.addBuildingIcon(2, GFXLibrary.r_building_panel_bld_icon_ind_stockpile, GFXLibrary.r_building_panel_bld_icon_ind_stockpile_over);
					this.addBuildingIcon(6, GFXLibrary.r_building_panel_bld_icon_ind_woodcutters_hut, GFXLibrary.r_building_panel_bld_icon_ind_woodcutters_hut_over);
					this.addBuildingIcon(7, GFXLibrary.r_building_panel_bld_icon_ind_stone_quarry, GFXLibrary.r_building_panel_bld_icon_ind_stone_quarry_over);
					this.addBuildingIcon(8, GFXLibrary.r_building_panel_bld_icon_ind_iron_mine, GFXLibrary.r_building_panel_bld_icon_ind_iron_mine_over);
					this.addBuildingIcon(9, GFXLibrary.r_building_panel_bld_icon_ind_pitch_rig, GFXLibrary.r_building_panel_bld_icon_ind_pitch_rig_over);
					this.addBuildingIcon(78, GFXLibrary.r_building_panel_bld_icon_ind_market, GFXLibrary.r_building_panel_bld_icon_ind_market_over);
					return;
				}
				this.addBuildingIcon(108, GFXLibrary.townbuilding_barracks_normal, GFXLibrary.townbuilding_barracks_over);
				this.addBuildingIcon(109, GFXLibrary.townbuilding_peasntshall_normal, GFXLibrary.townbuilding_peasntshall_over);
				this.addBuildingIcon(110, GFXLibrary.townbuilding_archeryrange_normal, GFXLibrary.townbuilding_archeryrange_over);
				this.addBuildingIcon(111, GFXLibrary.townbuilding_pikemandrillyard_normal, GFXLibrary.townbuilding_pikemandrillyard_over);
				this.addBuildingIcon(112, GFXLibrary.townbuilding_combatarena_normal, GFXLibrary.townbuilding_combatarena_over);
				this.addBuildingIcon(113, GFXLibrary.townbuilding_siegeengineersguild_normal, GFXLibrary.townbuilding_siegeengineersguild_over);
				this.addBuildingIcon(115, GFXLibrary.townbuilding_militaryschool_normal, GFXLibrary.townbuilding_militaryschool_over);
				this.addBuildingIcon(116, GFXLibrary.townbuilding_supplydepot_normal, GFXLibrary.townbuilding_supplydepot_over);
				return;
			case 2:
				if (!this.m_villageIsCapital)
				{
					this.addBuildingIcon(3, GFXLibrary.r_building_panel_bld_icon_food_granary, GFXLibrary.r_building_panel_bld_icon_food_granary_over);
					this.addBuildingIcon(35, GFXLibrary.r_building_panel_bld_icon_food_inn, GFXLibrary.r_building_panel_bld_icon_food_inn_over);
					this.addBuildingIcon(13, GFXLibrary.r_building_panel_bld_icon_food_apple_orchard, GFXLibrary.r_building_panel_bld_icon_food_apple_orchard_over);
					this.addBuildingIcon(17, GFXLibrary.r_building_panel_bld_icon_food_dairy_farm, GFXLibrary.r_building_panel_bld_icon_food_dairy_farm_over);
					this.addBuildingIcon(16, GFXLibrary.r_building_panel_bld_icon_food_pig_farm, GFXLibrary.r_building_panel_bld_icon_food_pig_farm_over);
					this.addBuildingIcon(14, GFXLibrary.r_building_panel_bld_icon_food_bakery, GFXLibrary.r_building_panel_bld_icon_food_bakery_over);
					this.addBuildingIcon(15, GFXLibrary.r_building_panel_bld_icon_food_vegetable_farm, GFXLibrary.r_building_panel_bld_icon_food_vegetable_farm_over);
					this.addBuildingIcon(18, GFXLibrary.r_building_panel_bld_icon_food_fishing_jetty, GFXLibrary.r_building_panel_bld_icon_food_fishing_jetty_over);
					this.addBuildingIcon(12, GFXLibrary.r_building_panel_bld_icon_food_brewery, GFXLibrary.r_building_panel_bld_icon_food_brewery_over);
					return;
				}
				this.addBuildingIcon(117, GFXLibrary.townbuilding_townhall_normal, GFXLibrary.townbuilding_townhall_over);
				this.addBuildingIcon(118, GFXLibrary.townbuilding_church_normal, GFXLibrary.townbuilding_church_over);
				this.addBuildingIcon(119, GFXLibrary.townbuilding_towngarden_normal, GFXLibrary.townbuilding_towngarden_over);
				this.addBuildingIcon(120, GFXLibrary.townbuilding_statue_normal, GFXLibrary.townbuilding_statue_over);
				return;
			case 3:
				if (!this.m_villageIsCapital)
				{
					this.addBuildingIcon(29, GFXLibrary.r_building_panel_bld_icon_mil_fletcher, GFXLibrary.r_building_panel_bld_icon_mil_fletcher_over);
					this.addBuildingIcon(31, GFXLibrary.r_building_panel_bld_icon_mil_armourer, GFXLibrary.r_building_panel_bld_icon_mil_armourer_over);
					this.addBuildingIcon(28, GFXLibrary.r_building_panel_bld_icon_mil_pole_turner, GFXLibrary.r_building_panel_bld_icon_mil_pole_turner_over);
					this.addBuildingIcon(30, GFXLibrary.r_building_panel_bld_icon_mil_blacksmith, GFXLibrary.r_building_panel_bld_icon_mil_blacksmith_over);
					this.addBuildingIcon(32, GFXLibrary.r_building_panel_bld_icon_mil_siege_workshop, GFXLibrary.r_building_panel_bld_icon_mil_siege_workshop_over);
					return;
				}
				this.addBuildingIcon(1112, GFXLibrary.townbuilding_resource_normal, GFXLibrary.townbuilding_resource_over);
				this.addBuildingIcon(1113, GFXLibrary.townbuilding_food_ale_normal, GFXLibrary.townbuilding_food_ale_over);
				this.addBuildingIcon(1114, GFXLibrary.townbuilding_banquette_normal, GFXLibrary.townbuilding_banquette_over);
				this.addBuildingIcon(1115, GFXLibrary.townbuilding_weapons_normal, GFXLibrary.townbuilding_weapons_over);
				this.addBuildingIcon(1116, GFXLibrary.townbuilding_banquette_food_normal, GFXLibrary.townbuilding_banquette_food_over);
				return;
			case 4:
				if (!this.m_villageIsCapital)
				{
					this.addBuildingIcon(22, GFXLibrary.r_building_panel_bld_icon_hon_hunters_hut, GFXLibrary.r_building_panel_bld_icon_hon_hunters_hut_over);
					this.addBuildingIcon(21, GFXLibrary.r_building_panel_bld_icon_hon_carpenters_workshop, GFXLibrary.r_building_panel_bld_icon_hon_carpenters_workshop_over);
					this.addBuildingIcon(26, GFXLibrary.r_building_panel_bld_icon_hon_metalworks_workshop, GFXLibrary.r_building_panel_bld_icon_hon_metalworks_workshop_over);
					this.addBuildingIcon(19, GFXLibrary.r_building_panel_bld_icon_hon_tailers_workshop, GFXLibrary.r_building_panel_bld_icon_hon_tailers_workshop_over);
					this.addBuildingIcon(33, GFXLibrary.r_building_panel_bld_icon_hon_vinyard, GFXLibrary.r_building_panel_bld_icon_hon_vinyard_over);
					this.addBuildingIcon(23, GFXLibrary.r_building_panel_bld_icon_hon_salt_pan, GFXLibrary.r_building_panel_bld_icon_hon_salt_pan_over);
					this.addBuildingIcon(24, GFXLibrary.r_building_panel_bld_icon_hon_spice_docs, GFXLibrary.r_building_panel_bld_icon_hon_spice_docs_over);
					this.addBuildingIcon(25, GFXLibrary.r_building_panel_bld_icon_hon_silk_docs, GFXLibrary.r_building_panel_bld_icon_hon_silk_docs_over);
					return;
				}
				break;
			default:
				switch (tab)
				{
				case 1000:
					this.addBuildingIcon(1004, GFXLibrary.r_building_panel_bld_civ_rel_shrine_sml_variant, GFXLibrary.r_building_panel_bld_civ_rel_shrine_sml_variant_over);
					this.addBuildingIcon(1005, GFXLibrary.r_building_panel_bld_civ_rel_shrine_lrg_variant, GFXLibrary.r_building_panel_bld_civ_rel_shrine_lrg_variant_over);
					this.addBuildingIcon(34, GFXLibrary.r_building_panel_bld_civ_rel_small_church, GFXLibrary.r_building_panel_bld_civ_rel_small_church_over);
					this.addBuildingIcon(36, GFXLibrary.r_building_panel_bld_civ_rel_medium_church, GFXLibrary.r_building_panel_bld_civ_rel_medium_church_over);
					this.addBuildingIcon(37, GFXLibrary.r_building_panel_bld_civ_rel_large_church, GFXLibrary.r_building_panel_bld_civ_rel_large_church_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1001:
					this.addBuildingIcon(1008, GFXLibrary.r_building_panel_bld_civ_dec_garden_lrg_variant, GFXLibrary.r_building_panel_bld_civ_dec_garden_lrg_variant_over);
					this.addBuildingIcon(1006, GFXLibrary.r_building_panel_bld_civ_dec_garden_sml_variant, GFXLibrary.r_building_panel_bld_civ_dec_garden_sml_variant_over);
					this.addBuildingIcon(1111, GFXLibrary.r_building_panel_bld_civ_dec_statue_lrg_variant, GFXLibrary.r_building_panel_bld_civ_dec_statue_lrg_variant_over);
					this.addBuildingIcon(1010, GFXLibrary.r_building_panel_bld_civ_dec_statue_sml_variant, GFXLibrary.r_building_panel_bld_civ_dec_statue_sml_variant_over);
					this.addBuildingIcon(60, GFXLibrary.r_building_panel_bld_civ_dec_dovecote, GFXLibrary.r_building_panel_bld_civ_dec_dovecote_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1002:
					this.addBuildingIcon(61, GFXLibrary.r_building_panel_bld_jus_stocks, GFXLibrary.r_building_panel_bld_jus_stocks_over);
					this.addBuildingIcon(62, GFXLibrary.r_building_panel_bld_jus_burning_post, GFXLibrary.r_building_panel_bld_jus_burning_post_over);
					this.addBuildingIcon(64, GFXLibrary.r_building_panel_bld_jus_stretching_rack, GFXLibrary.r_building_panel_bld_jus_stretching_rack_over);
					this.addBuildingIcon(63, GFXLibrary.r_building_panel_bld_jus_gibbet, GFXLibrary.r_building_panel_bld_jus_gibbet_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1003:
					this.addBuildingIcon(67, GFXLibrary.r_building_panel_bld_ent_theatre, GFXLibrary.r_building_panel_bld_ent_theatre_over);
					this.addBuildingIcon(68, GFXLibrary.r_building_panel_bld_ent_jesters_court, GFXLibrary.r_building_panel_bld_ent_jesters_court_over);
					this.addBuildingIcon(66, GFXLibrary.r_building_panel_bld_ent_dancing_bear, GFXLibrary.r_building_panel_bld_ent_dancing_bear_over);
					this.addBuildingIcon(69, GFXLibrary.r_building_panel_bld_ent_troubadours_arbor, GFXLibrary.r_building_panel_bld_ent_troubadours_arbor_over);
					this.addBuildingIcon(65, GFXLibrary.r_building_panel_bld_ent_maypole, GFXLibrary.r_building_panel_bld_ent_maypole_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1004:
					this.addBuildingIcon(70, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_01, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_01_over);
					this.addBuildingIcon(71, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_02, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_02_over);
					this.addBuildingIcon(72, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_03, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_03_over);
					this.addBuildingIcon(73, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_04, GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_04_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1005:
					this.addBuildingIcon(74, GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_01, GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_01_over);
					this.addBuildingIcon(75, GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_02, GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_02_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1006:
					this.addBuildingIcon(38, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_01, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_01_over);
					this.addBuildingIcon(41, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_02, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_02_over);
					this.addBuildingIcon(42, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_03, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_03_over);
					this.addBuildingIcon(43, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_04, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_04_over);
					this.addBuildingIcon(44, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_05, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_05_over);
					this.addBuildingIcon(45, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_06, GFXLibrary.r_building_panel_bld_civ_dec_small_garden_06_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1007:
				case 1009:
					break;
				case 1008:
					this.addBuildingIcon(49, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_01png, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_01png_over);
					this.addBuildingIcon(50, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_02, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_02_over);
					this.addBuildingIcon(51, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_03, GFXLibrary.r_building_panel_bld_civ_dec_large_garden_03_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				case 1010:
					this.addBuildingIcon(54, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_01, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_01_over);
					this.addBuildingIcon(55, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_02, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_02_over);
					this.addBuildingIcon(56, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_03, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_03_over);
					this.addBuildingIcon(57, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_04, GFXLibrary.r_building_panel_bld_civ_dec_small_statue_04_over);
					this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
					return;
				default:
					switch (tab)
					{
					case 1111:
						this.addBuildingIcon(58, GFXLibrary.r_building_panel_bld_civ_dec_large_statue_01, GFXLibrary.r_building_panel_bld_civ_dec_large_statue_01_over);
						this.addBuildingIcon(59, GFXLibrary.r_building_panel_bld_civ_dec_large_statue_02, GFXLibrary.r_building_panel_bld_civ_dec_large_statue_02_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						return;
					case 1112:
						this.addBuildingIcon(79, GFXLibrary.townbuilding_Woodcutter_normal, GFXLibrary.townbuilding_Woodcutter_over);
						this.addBuildingIcon(80, GFXLibrary.townbuilding_stonequarry_normal, GFXLibrary.townbuilding_stonequarry_over);
						this.addBuildingIcon(81, GFXLibrary.townbuilding_iron_normal, GFXLibrary.townbuilding_iron_over);
						this.addBuildingIcon(82, GFXLibrary.townbuilding_pitch_normal, GFXLibrary.townbuilding_pitch_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						return;
					case 1113:
						this.addBuildingIcon(84, GFXLibrary.townbuilding_apples_normal, GFXLibrary.townbuilding_apples_over);
						this.addBuildingIcon(85, GFXLibrary.townbuilding_cheese_normal, GFXLibrary.townbuilding_cheese_over);
						this.addBuildingIcon(86, GFXLibrary.townbuilding_meat_normal, GFXLibrary.townbuilding_meat_over);
						this.addBuildingIcon(87, GFXLibrary.townbuilding_bread_normal, GFXLibrary.townbuilding_bread_over);
						this.addBuildingIcon(88, GFXLibrary.townbuilding_veg_normal, GFXLibrary.townbuilding_veg_over);
						this.addBuildingIcon(89, GFXLibrary.townbuilding_fish_normal, GFXLibrary.townbuilding_fish_over);
						this.addBuildingIcon(83, GFXLibrary.townbuilding_ale_normal, GFXLibrary.townbuilding_ale_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						return;
					case 1114:
						this.addBuildingIcon(98, GFXLibrary.townbuilding_carpenter_normal, GFXLibrary.townbuilding_carpenter_over);
						this.addBuildingIcon(100, GFXLibrary.townbuilding_metalware_normal, GFXLibrary.townbuilding_metalware_over);
						this.addBuildingIcon(99, GFXLibrary.townbuilding_tailor_normal, GFXLibrary.townbuilding_tailor_over);
						this.addBuildingIcon(102, GFXLibrary.townbuilding_silk_normal, GFXLibrary.townbuilding_silk_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						return;
					case 1115:
						this.addBuildingIcon(90, GFXLibrary.townbuilding_bows_normal, GFXLibrary.townbuilding_bows_over);
						this.addBuildingIcon(91, GFXLibrary.townbuilding_pikes_normal, GFXLibrary.townbuilding_pikes_over);
						this.addBuildingIcon(92, GFXLibrary.townbuilding_armour_normal, GFXLibrary.townbuilding_armour_over);
						this.addBuildingIcon(93, GFXLibrary.townbuilding_sword_normal, GFXLibrary.townbuilding_sword_over);
						this.addBuildingIcon(94, GFXLibrary.townbuilding_catapults_normal, GFXLibrary.townbuilding_catapults_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						break;
					case 1116:
						this.addBuildingIcon(95, GFXLibrary.townbuilding_venison_normal, GFXLibrary.townbuilding_venison_over);
						this.addBuildingIcon(96, GFXLibrary.townbuilding_wine_normal, GFXLibrary.townbuilding_wine_over);
						this.addBuildingIcon(97, GFXLibrary.townbuilding_salt_normal, GFXLibrary.townbuilding_salt_over);
						this.addBuildingIcon(101, GFXLibrary.townbuilding_spice_normal, GFXLibrary.townbuilding_spice_over);
						this.addBuildingIcon(2000, GFXLibrary.r_building_panel_bld_back, GFXLibrary.r_building_panel_bld_back_over);
						return;
					default:
						return;
					}
					break;
				}
				break;
			}
		}

		// Token: 0x06002F0D RID: 12045 RVA: 0x00262250 File Offset: 0x00260450
		private void resetBuildingIcons()
		{
			this.currentBuildingIcon = 0;
			this.building1Button.Visible = false;
			this.building2Button.Visible = false;
			this.building3Button.Visible = false;
			this.building4Button.Visible = false;
			this.building5Button.Visible = false;
			this.building6Button.Visible = false;
			this.building7Button.Visible = false;
			this.building8Button.Visible = false;
			this.building1Image.Visible = false;
			this.building2Image.Visible = false;
			this.building3Image.Visible = false;
			this.building4Image.Visible = false;
			this.building5Image.Visible = false;
			this.building6Image.Visible = false;
			this.building7Image.Visible = false;
			this.building8Image.Visible = false;
		}

		// Token: 0x06002F0E RID: 12046 RVA: 0x00262324 File Offset: 0x00260524
		private void addBuildingIcon(int buildingType, BaseImage newImage, BaseImage overImage)
		{
			if (GameEngine.Instance.World.WorldEnded || (!this.m_villageIsCapital && buildingType != 2 && GameEngine.Instance.Village != null && GameEngine.Instance.Village.countBuildingType(2) == 0) || GameEngine.Instance.Village == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDImage csdimage = null;
			bool flag = true;
			bool flag2 = false;
			if (buildingType < GameEngine.Instance.LocalWorldData.constrMaxCount.Length && buildingType >= 0)
			{
				if (buildingType == 115 && !GameEngine.Instance.World.FourthAgeWorld)
				{
					flag = false;
				}
				int capitalType = GameEngine.Instance.World.getCapitalType(GameEngine.Instance.Village.VillageID);
				int constrMaxCount = GameEngine.Instance.LocalWorldData.getConstrMaxCount(buildingType, capitalType);
				int num = GameEngine.Instance.Village.countBuildingType(buildingType);
				if (constrMaxCount <= num)
				{
					flag = false;
				}
				else if (constrMaxCount - num > 1)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel;
					switch (this.currentBuildingIcon)
					{
					case 0:
						csdimage = this.building1Image;
						csdlabel = this.building1Label;
						break;
					case 1:
						csdimage = this.building2Image;
						csdlabel = this.building2Label;
						break;
					case 2:
						csdimage = this.building3Image;
						csdlabel = this.building3Label;
						break;
					case 3:
						csdimage = this.building4Image;
						csdlabel = this.building4Label;
						break;
					case 4:
						csdimage = this.building5Image;
						csdlabel = this.building5Label;
						break;
					case 5:
						csdimage = this.building6Image;
						csdlabel = this.building6Label;
						break;
					case 6:
						csdimage = this.building7Image;
						csdlabel = this.building7Label;
						break;
					case 7:
						csdimage = this.building8Image;
						csdlabel = this.building8Label;
						break;
					default:
						return;
					}
					csdimage.Visible = true;
					csdlabel.Text = (constrMaxCount - num).ToString();
				}
			}
			int villageMapType = GameEngine.Instance.Village.VillageMapType;
			bool flag3 = false;
			if (buildingType == 2000)
			{
				flag3 = true;
				this.currentBuildingIcon = 7;
			}
			else if (buildingType >= 1000)
			{
				if (this.testSubMenu(buildingType, villageMapType))
				{
					flag3 = true;
					if (!this.testSubMenuAnyLeft(buildingType, villageMapType))
					{
						flag2 = true;
					}
				}
			}
			else if ((this.m_villageIsCapital && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(buildingType, villageMapType)) || (!this.m_villageIsCapital && VillageBuildingsData.isThisBuildingTypeAvailable(buildingType, villageMapType, GameEngine.Instance.World.UserResearchData)))
			{
				flag3 = true;
			}
			if (flag3)
			{
				CustomSelfDrawPanel.CSDButton csdbutton;
				switch (this.currentBuildingIcon)
				{
				case 0:
					csdbutton = this.building1Button;
					break;
				case 1:
					csdbutton = this.building2Button;
					break;
				case 2:
					csdbutton = this.building3Button;
					break;
				case 3:
					csdbutton = this.building4Button;
					break;
				case 4:
					csdbutton = this.building5Button;
					break;
				case 5:
					csdbutton = this.building6Button;
					break;
				case 6:
					csdbutton = this.building7Button;
					break;
				case 7:
					csdbutton = this.building8Button;
					break;
				default:
					return;
				}
				csdbutton.ImageNorm = newImage;
				csdbutton.ImageOver = overImage;
				csdbutton.Visible = true;
				csdbutton.Enabled = flag;
				if (flag && flag2)
				{
					csdbutton.Alpha = 0.5f;
				}
				else
				{
					csdbutton.Alpha = 1f;
				}
				csdbutton.Data = buildingType;
				csdbutton.CustomTooltipID = 100;
				csdbutton.CustomTooltipData = buildingType;
				this.currentBuildingIcon++;
				return;
			}
			if (csdimage != null)
			{
				csdimage.Visible = false;
			}
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x00262664 File Offset: 0x00260864
		private bool testSubMenu(int buildingType, int landType)
		{
			switch (buildingType)
			{
			case 1000:
				return this.testSubMenu(1004, landType) || this.testSubMenu(1005, landType) || VillageBuildingsData.isThisBuildingTypeAvailable(34, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(36, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(37, landType, GameEngine.Instance.World.UserResearchData);
			case 1001:
				return this.testSubMenu(1006, landType) || this.testSubMenu(1008, landType) || this.testSubMenu(1010, landType) || this.testSubMenu(1111, landType) || VillageBuildingsData.isThisBuildingTypeAvailable(60, landType, GameEngine.Instance.World.UserResearchData);
			case 1002:
				return VillageBuildingsData.isThisBuildingTypeAvailable(61, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(62, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(63, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(64, landType, GameEngine.Instance.World.UserResearchData);
			case 1003:
				return VillageBuildingsData.isThisBuildingTypeAvailable(65, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(66, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(67, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(68, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(69, landType, GameEngine.Instance.World.UserResearchData);
			case 1004:
				return VillageBuildingsData.isThisBuildingTypeAvailable(70, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(71, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(72, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(73, landType, GameEngine.Instance.World.UserResearchData);
			case 1005:
				return VillageBuildingsData.isThisBuildingTypeAvailable(74, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(75, landType, GameEngine.Instance.World.UserResearchData);
			case 1006:
				return VillageBuildingsData.isThisBuildingTypeAvailable(38, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(41, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(42, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(43, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(44, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(45, landType, GameEngine.Instance.World.UserResearchData);
			case 1007:
				return false;
			case 1008:
				return VillageBuildingsData.isThisBuildingTypeAvailable(49, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(50, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(51, landType, GameEngine.Instance.World.UserResearchData);
			case 1009:
				return false;
			case 1010:
				return VillageBuildingsData.isThisBuildingTypeAvailable(54, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(55, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(56, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(57, landType, GameEngine.Instance.World.UserResearchData);
			default:
				switch (buildingType)
				{
				case 1111:
					return VillageBuildingsData.isThisBuildingTypeAvailable(58, landType, GameEngine.Instance.World.UserResearchData) || VillageBuildingsData.isThisBuildingTypeAvailable(59, landType, GameEngine.Instance.World.UserResearchData);
				case 1112:
					return VillageBuildingsData.isThisBuildingTypeAvailableInCapital(79, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(80, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(81, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(82, landType);
				case 1113:
					return VillageBuildingsData.isThisBuildingTypeAvailableInCapital(84, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(86, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(85, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(87, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(88, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(89, landType);
				case 1114:
					return VillageBuildingsData.isThisBuildingTypeAvailableInCapital(98, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(100, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(99, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(102, landType);
				case 1115:
					return VillageBuildingsData.isThisBuildingTypeAvailableInCapital(90, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(91, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(92, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(93, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(94, landType);
				case 1116:
					return VillageBuildingsData.isThisBuildingTypeAvailableInCapital(95, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(96, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(97, landType) || VillageBuildingsData.isThisBuildingTypeAvailableInCapital(101, landType);
				default:
					return false;
				}
				break;
			}
		}

		// Token: 0x06002F10 RID: 12048 RVA: 0x00262C00 File Offset: 0x00260E00
		private bool anyBuildingsLeftToPlace(int buildingType)
		{
			if (buildingType == 115 && !GameEngine.Instance.World.FourthAgeWorld)
			{
				return false;
			}
			int capitalType = GameEngine.Instance.World.getCapitalType(GameEngine.Instance.Village.VillageID);
			int constrMaxCount = GameEngine.Instance.LocalWorldData.getConstrMaxCount(buildingType, capitalType);
			int num = GameEngine.Instance.Village.countBuildingType(buildingType);
			return constrMaxCount > num;
		}

		// Token: 0x06002F11 RID: 12049 RVA: 0x00262C70 File Offset: 0x00260E70
		private bool testSubMenuAnyLeft(int buildingType, int landType)
		{
			switch (buildingType)
			{
			case 1000:
				return this.testSubMenuAnyLeft(1004, landType) || this.testSubMenuAnyLeft(1005, landType) || (this.anyBuildingsLeftToPlace(34) && VillageBuildingsData.isThisBuildingTypeAvailable(34, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(36) && VillageBuildingsData.isThisBuildingTypeAvailable(36, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(37) && VillageBuildingsData.isThisBuildingTypeAvailable(37, landType, GameEngine.Instance.World.UserResearchData));
			case 1001:
				return this.testSubMenuAnyLeft(1006, landType) || this.testSubMenuAnyLeft(1008, landType) || this.testSubMenuAnyLeft(1010, landType) || this.testSubMenuAnyLeft(1111, landType) || (this.anyBuildingsLeftToPlace(60) && VillageBuildingsData.isThisBuildingTypeAvailable(60, landType, GameEngine.Instance.World.UserResearchData));
			case 1002:
				return (this.anyBuildingsLeftToPlace(61) && VillageBuildingsData.isThisBuildingTypeAvailable(61, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(62) && VillageBuildingsData.isThisBuildingTypeAvailable(62, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(63) && VillageBuildingsData.isThisBuildingTypeAvailable(63, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(64) && VillageBuildingsData.isThisBuildingTypeAvailable(64, landType, GameEngine.Instance.World.UserResearchData));
			case 1003:
				return (this.anyBuildingsLeftToPlace(65) && VillageBuildingsData.isThisBuildingTypeAvailable(65, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(66) && VillageBuildingsData.isThisBuildingTypeAvailable(66, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(67) && VillageBuildingsData.isThisBuildingTypeAvailable(67, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(68) && VillageBuildingsData.isThisBuildingTypeAvailable(68, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(69) && VillageBuildingsData.isThisBuildingTypeAvailable(69, landType, GameEngine.Instance.World.UserResearchData));
			case 1004:
				return (this.anyBuildingsLeftToPlace(70) && VillageBuildingsData.isThisBuildingTypeAvailable(70, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(71) && VillageBuildingsData.isThisBuildingTypeAvailable(71, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(72) && VillageBuildingsData.isThisBuildingTypeAvailable(72, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(73) && VillageBuildingsData.isThisBuildingTypeAvailable(73, landType, GameEngine.Instance.World.UserResearchData));
			case 1005:
				return (this.anyBuildingsLeftToPlace(74) && VillageBuildingsData.isThisBuildingTypeAvailable(74, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(75) && VillageBuildingsData.isThisBuildingTypeAvailable(75, landType, GameEngine.Instance.World.UserResearchData));
			case 1006:
				return (this.anyBuildingsLeftToPlace(38) && VillageBuildingsData.isThisBuildingTypeAvailable(38, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(41) && VillageBuildingsData.isThisBuildingTypeAvailable(41, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(42) && VillageBuildingsData.isThisBuildingTypeAvailable(42, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(43) && VillageBuildingsData.isThisBuildingTypeAvailable(43, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(44) && VillageBuildingsData.isThisBuildingTypeAvailable(44, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(45) && VillageBuildingsData.isThisBuildingTypeAvailable(45, landType, GameEngine.Instance.World.UserResearchData));
			case 1007:
				return false;
			case 1008:
				return (this.anyBuildingsLeftToPlace(49) && VillageBuildingsData.isThisBuildingTypeAvailable(49, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(50) && VillageBuildingsData.isThisBuildingTypeAvailable(50, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(51) && VillageBuildingsData.isThisBuildingTypeAvailable(51, landType, GameEngine.Instance.World.UserResearchData));
			case 1009:
				return false;
			case 1010:
				return (this.anyBuildingsLeftToPlace(54) && VillageBuildingsData.isThisBuildingTypeAvailable(54, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(55) && VillageBuildingsData.isThisBuildingTypeAvailable(55, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(56) && VillageBuildingsData.isThisBuildingTypeAvailable(56, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(57) && VillageBuildingsData.isThisBuildingTypeAvailable(57, landType, GameEngine.Instance.World.UserResearchData));
			default:
				switch (buildingType)
				{
				case 1111:
					return (this.anyBuildingsLeftToPlace(58) && VillageBuildingsData.isThisBuildingTypeAvailable(58, landType, GameEngine.Instance.World.UserResearchData)) || (this.anyBuildingsLeftToPlace(59) && VillageBuildingsData.isThisBuildingTypeAvailable(59, landType, GameEngine.Instance.World.UserResearchData));
				case 1112:
					return (this.anyBuildingsLeftToPlace(79) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(79, landType)) || (this.anyBuildingsLeftToPlace(80) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(80, landType)) || (this.anyBuildingsLeftToPlace(81) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(81, landType)) || (this.anyBuildingsLeftToPlace(82) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(82, landType));
				case 1113:
					return (this.anyBuildingsLeftToPlace(84) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(84, landType)) || (this.anyBuildingsLeftToPlace(86) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(86, landType)) || (this.anyBuildingsLeftToPlace(85) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(85, landType)) || (this.anyBuildingsLeftToPlace(87) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(87, landType)) || (this.anyBuildingsLeftToPlace(88) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(88, landType)) || (this.anyBuildingsLeftToPlace(89) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(89, landType));
				case 1114:
					return (this.anyBuildingsLeftToPlace(98) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(98, landType)) || (this.anyBuildingsLeftToPlace(100) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(100, landType)) || (this.anyBuildingsLeftToPlace(99) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(99, landType)) || (this.anyBuildingsLeftToPlace(102) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(102, landType));
				case 1115:
					return (this.anyBuildingsLeftToPlace(90) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(90, landType)) || (this.anyBuildingsLeftToPlace(91) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(91, landType)) || (this.anyBuildingsLeftToPlace(92) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(92, landType)) || (this.anyBuildingsLeftToPlace(93) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(93, landType)) || (this.anyBuildingsLeftToPlace(94) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(94, landType));
				case 1116:
					return (this.anyBuildingsLeftToPlace(95) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(95, landType)) || (this.anyBuildingsLeftToPlace(96) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(96, landType)) || (this.anyBuildingsLeftToPlace(97) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(97, landType)) || (this.anyBuildingsLeftToPlace(101) && VillageBuildingsData.isThisBuildingTypeAvailableInCapital(101, landType));
				default:
					return false;
				}
				break;
			}
		}

		// Token: 0x06002F12 RID: 12050 RVA: 0x00263448 File Offset: 0x00261648
		private void placeBuildingMouseOver()
		{
			if (this.buildingBeingPlaced || this.OverControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.OverControl;
			int data = csdbutton.Data;
			if (data < 124)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.startPlaceBuilding_ShowPanel(data, VillageBuildingsData.getBuildingName(data), false);
				}
				return;
			}
			switch (data)
			{
			case 1000:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Religious_Buildings", "Religious Buildings"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1001:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Decorative_Buildings", "Decorative Buildings"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1002:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Justice_Buildings", "Justice Buildings"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1003:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Entertainment_Buildings", "Entertainment Buildings"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1004:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Small_Shrines", "Small Shrines"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1005:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Large_Shrines", "Large Shrines"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1006:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Formal_Gardens", "Formal Gardens"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1007:
			case 1009:
				break;
			case 1008:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Flower_Beds", "Flower Beds"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			case 1010:
				this.setBuildingInfo(SK.Text("VillageMapPanel_Gilded_Statues", "Gilded Statues"), 0, 0, 0, 0, 0, "", -1, -1);
				return;
			default:
				if (data == 1111)
				{
					this.setBuildingInfo(SK.Text("VillageMapPanel_Stone_Statues", "Stone Statues"), 0, 0, 0, 0, 0, "", -1, -1);
					return;
				}
				if (data != 2000)
				{
					return;
				}
				this.setBuildingInfo(SK.Text("VillageMapPanel_Back", "Back"), 0, 0, 0, 0, 0, "", -1, -1);
				break;
			}
		}

		// Token: 0x06002F13 RID: 12051 RVA: 0x000222E3 File Offset: 0x000204E3
		private void placeBuildingMouseLeave()
		{
			if (!this.buildingBeingPlaced)
			{
				this.clearBuildingInfo();
			}
		}

		// Token: 0x06002F14 RID: 12052 RVA: 0x00263668 File Offset: 0x00261868
		private void placeBuildingClick()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			if (data < 124)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.startPlaceBuilding(data, false);
					GameEngine.Instance.Village.startPlaceBuilding_ShowPanel(data, VillageBuildingsData.getBuildingName(data), true);
					this.buildingBeingPlaced = true;
					InterfaceMgr.Instance.closeTutorialWindow();
					return;
				}
			}
			else
			{
				if (data == 2000)
				{
					int num = this.currentTab;
					if (num <= 1010)
					{
						if (num - 1004 <= 1)
						{
							this.setBuildingTab(1000);
							return;
						}
						if (num - 1006 > 4)
						{
							goto IL_C2;
						}
					}
					else if (num != 1111)
					{
						if (num - 1112 > 4)
						{
							goto IL_C2;
						}
						this.setBuildingTab(3);
						return;
					}
					this.setBuildingTab(1001);
					return;
					IL_C2:
					this.setBuildingTab(0);
					return;
				}
				this.setBuildingTab(data);
			}
		}

		// Token: 0x06002F15 RID: 12053 RVA: 0x000222F3 File Offset: 0x000204F3
		public void refreshCurrentTab()
		{
			this.setBuildingTab(this.currentTab);
		}

		// Token: 0x06002F16 RID: 12054 RVA: 0x00263748 File Offset: 0x00261948
		public void clearBuildingInfo()
		{
			this.buildingBeingPlaced = false;
			this.buildTypeLabel.Visible = false;
			this.buildTimeLabel.Visible = false;
			this.buildWoodLabel.Visible = false;
			this.buildGoldLabel.Visible = false;
			this.buildStoneLabel.Visible = false;
			this.buildCapitalHelp.Visible = false;
			this.buildDonationTypeImage.Visible = false;
		}

		// Token: 0x06002F17 RID: 12055 RVA: 0x002637B0 File Offset: 0x002619B0
		public BaseImage getCapitalBuildingDonationTypeImage(int buildingType)
		{
			BaseImage result = null;
			switch (buildingType)
			{
			case 79:
			case 80:
			case 81:
			case 82:
			case 90:
			case 91:
			case 92:
			case 93:
			case 94:
			case 107:
			case 110:
				result = GFXLibrary.donate_type_food;
				break;
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 95:
			case 96:
			case 97:
			case 98:
			case 99:
			case 100:
			case 101:
			case 102:
			case 105:
			case 109:
				result = GFXLibrary.donate_type_resources;
				break;
			case 103:
			case 113:
			case 114:
			case 117:
			case 118:
			case 119:
				result = GFXLibrary.donate_type_banquet;
				break;
			case 106:
			case 111:
			case 112:
			case 115:
			case 121:
			case 122:
			case 123:
				result = GFXLibrary.donate_type_weapons;
				break;
			}
			return result;
		}

		// Token: 0x06002F18 RID: 12056 RVA: 0x002638A0 File Offset: 0x00261AA0
		public void setBuildingInfo(string buildingName, int woodCost, int stoneCost, int clayCost, int goldCost, int flagsNeeded, string buildTime, int buildingType, int realBuildingType)
		{
			int num = -1;
			if (CardTypes.isFreeBuildingPlacement(GameEngine.Instance.cardsManager.UserCardData, realBuildingType, ref num))
			{
				woodCost = 0;
				stoneCost = 0;
				goldCost = 0;
				flagsNeeded = 0;
				buildTime = "";
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			VillageMap village = GameEngine.Instance.Village;
			this.clearBuildingInfo();
			this.buildTypeLabel.Text = buildingName;
			this.buildTimeLabel.Text = buildTime;
			this.buildTypeLabel.Visible = true;
			this.buildTimeLabel.Visible = true;
			if (woodCost > 0)
			{
				this.buildWoodLabel.Text = woodCost.ToString("N", nfi);
				this.buildWoodLabel.Visible = true;
				this.buildWoodLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(6) < (double)woodCost)
				{
					this.buildWoodLabel.Color = global::ARGBColors.Red;
				}
			}
			if (stoneCost > 0)
			{
				this.buildStoneLabel.Text = stoneCost.ToString("N", nfi);
				this.buildStoneLabel.Visible = true;
				this.buildStoneLabel.Color = global::ARGBColors.Black;
				if (village != null && village.getResourceLevel(7) < (double)stoneCost)
				{
					this.buildStoneLabel.Color = global::ARGBColors.Red;
				}
			}
			if (goldCost > 0)
			{
				this.buildGoldLabel.Text = goldCost.ToString("N", nfi);
				this.buildGoldLabel.Visible = true;
				this.buildGoldLabel.Color = global::ARGBColors.Black;
				double num2 = 0.0;
				if (village != null)
				{
					num2 = (GameEngine.Instance.World.isCapital(village.VillageID) ? village.m_capitalGold : GameEngine.Instance.World.getCurrentGold());
				}
				if (num2 < (double)goldCost)
				{
					this.buildGoldLabel.Color = global::ARGBColors.Red;
				}
			}
			if (flagsNeeded > 0)
			{
				this.buildStoneLabel.Text = flagsNeeded.ToString("N", nfi);
				this.buildStoneLabel.Visible = true;
				this.buildStoneLabel.Color = global::ARGBColors.Black;
				if (village != null && village.numParishFlags() < flagsNeeded)
				{
					this.buildStoneLabel.Color = global::ARGBColors.Red;
				}
			}
			if (buildingType >= 79)
			{
				this.buildCapitalHelp.Visible = true;
				this.currentSelectedBuildingType = buildingType;
			}
			BaseImage capitalBuildingDonationTypeImage = this.getCapitalBuildingDonationTypeImage(realBuildingType);
			if (capitalBuildingDonationTypeImage != null)
			{
				this.buildDonationTypeImage.Visible = true;
				this.buildDonationTypeImage.Image = capitalBuildingDonationTypeImage;
				return;
			}
			this.buildDonationTypeImage.Visible = false;
		}

		// Token: 0x06002F19 RID: 12057 RVA: 0x00022301 File Offset: 0x00020501
		public int TUTORIAL_getBuildTabYPos()
		{
			return this.calcBuildTabYPos();
		}

		// Token: 0x06002F1A RID: 12058 RVA: 0x00263B0C File Offset: 0x00261D0C
		private int calcBuildTabYPos()
		{
			int num = 25 + this.currentHeight + Math.Max(this.currentExtensionHeight - 25, 0);
			if (num < 55)
			{
				num = 55;
			}
			return num;
		}

		// Token: 0x06002F1B RID: 12059 RVA: 0x00022309 File Offset: 0x00020509
		private int calcCapitalBuildTabYPos()
		{
			return 135;
		}

		// Token: 0x06002F1C RID: 12060 RVA: 0x00263B3C File Offset: 0x00261D3C
		private int calcTop10YPos()
		{
			int num = 25 + this.currentBuildingHeight;
			if (num < 55)
			{
				num = 55;
			}
			return num + 135;
		}

		// Token: 0x06002F1D RID: 12061 RVA: 0x00263B64 File Offset: 0x00261D64
		public void initInfo1Panel()
		{
			int num = this.calcInfoTabYPos();
			this.info1PanelImage.Image = GFXLibrary.r_popularity_panel_back;
			this.info1PanelImage.Position = new Point(0, num + 25);
			base.addControl(this.info1PanelImage);
			this.info1HeaderPanelImage.Image = GFXLibrary.infobar_01;
			this.info1HeaderPanelImage.Position = new Point(0, num);
			this.info1HeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info1MouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info1MouseLeave));
			this.info1HeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.info1Clicked));
			this.info1HeaderPanelImage.CustomTooltipID = 111;
			base.addControl(this.info1HeaderPanelImage);
			this.info1HeaderHonourImage.Image = GFXLibrary.com_32_honour;
			this.info1HeaderHonourImage.Position = new Point(15, 8);
			this.info1HeaderPanelImage.addControl(this.info1HeaderHonourImage);
			this.info1HeaderHonourAmount.Text = "";
			this.info1HeaderHonourAmount.Color = global::ARGBColors.Black;
			this.info1HeaderHonourAmount.Position = new Point(28, 17);
			this.info1HeaderHonourAmount.Size = new Size(149, 20);
			this.info1HeaderHonourAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1HeaderHonourAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1HeaderPanelImage.addControl(this.info1HeaderHonourAmount);
			int num2 = 25;
			this.info1ChurchLabel.Text = SK.Text("VillageMapPanel_Churches", "Churches");
			this.info1ChurchLabel.Color = global::ARGBColors.Black;
			this.info1ChurchLabel.Position = new Point(15, 35);
			this.info1ChurchLabel.Size = new Size(122, 20);
			this.info1ChurchLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1ChurchLabel);
			this.info1ChurchAmount.Text = "0";
			this.info1ChurchAmount.Color = global::ARGBColors.Black;
			this.info1ChurchAmount.Position = new Point(95, 35);
			this.info1ChurchAmount.Size = new Size(82, 20);
			this.info1ChurchAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1ChurchAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1ChurchAmount);
			this.info1DecorativeLabel.Text = SK.Text("VillageMapPanel_Decorative", "Decorative");
			this.info1DecorativeLabel.Color = global::ARGBColors.Black;
			this.info1DecorativeLabel.Position = new Point(15, 35 + num2);
			this.info1DecorativeLabel.Size = new Size(120, 20);
			this.info1DecorativeLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1DecorativeLabel);
			this.info1DecorativeAmount.Text = "0";
			this.info1DecorativeAmount.Color = global::ARGBColors.Black;
			this.info1DecorativeAmount.Position = new Point(95, 35 + num2);
			this.info1DecorativeAmount.Size = new Size(82, 20);
			this.info1DecorativeAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1DecorativeAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1DecorativeAmount);
			this.info1JusticeLabel.Text = SK.Text("VillageMapPanel_Justice", "Justice");
			this.info1JusticeLabel.Color = global::ARGBColors.Black;
			this.info1JusticeLabel.Position = new Point(15, 35 + num2 * 2);
			this.info1JusticeLabel.Size = new Size(122, 20);
			this.info1JusticeLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1JusticeLabel);
			this.info1JusticeAmount.Text = "0";
			this.info1JusticeAmount.Color = global::ARGBColors.Black;
			this.info1JusticeAmount.Position = new Point(95, 35 + num2 * 2);
			this.info1JusticeAmount.Size = new Size(82, 20);
			this.info1JusticeAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1JusticeAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1JusticeAmount);
			this.info1ArtsLabel.Text = SK.Text("VillageMapPanel_Arts_Research", "Arts Research");
			this.info1ArtsLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.info1ArtsLabel.Position = new Point(15, 35 + num2 * 3 - 10);
				this.info1ArtsLabel.Size = new Size(122, 40);
				this.info1ArtsLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.info1ArtsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else
			{
				this.info1ArtsLabel.Position = new Point(15, 35 + num2 * 3);
				this.info1ArtsLabel.Size = new Size(122, 20);
				this.info1ArtsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.info1ArtsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			}
			this.info1PanelImage.addControl(this.info1ArtsLabel);
			this.info1ArtsAmount.Text = "0";
			this.info1ArtsAmount.Color = global::ARGBColors.Black;
			this.info1ArtsAmount.Position = new Point(95, 35 + num2 * 3);
			this.info1ArtsAmount.Size = new Size(82, 20);
			this.info1ArtsAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1ArtsAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1ArtsAmount);
			this.info1ParishLabel.Text = SK.Text("VillageMapPanel_Parish_Bonus", "Parish Bonus");
			this.info1ParishLabel.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "pt")
			{
				this.info1ParishLabel.Position = new Point(15, 35 + num2 * 4 - 10);
				this.info1ParishLabel.Size = new Size(122, 40);
				this.info1ParishLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
				this.info1ParishLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			}
			else
			{
				this.info1ParishLabel.Position = new Point(15, 35 + num2 * 4);
				this.info1ParishLabel.Size = new Size(122, 20);
				this.info1ParishLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.info1ParishLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			}
			this.info1PanelImage.addControl(this.info1ParishLabel);
			this.info1ParishAmount.Text = "0";
			this.info1ParishAmount.Color = global::ARGBColors.Black;
			this.info1ParishAmount.Position = new Point(95, 35 + num2 * 4);
			this.info1ParishAmount.Size = new Size(82, 20);
			this.info1ParishAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1ParishAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1ParishAmount);
			this.info1CardsLabel.Text = SK.Text("VillageMapPanel_Cards", "Cards");
			this.info1CardsLabel.Color = global::ARGBColors.Black;
			this.info1CardsLabel.Position = new Point(15, 35 + num2 * 5);
			this.info1CardsLabel.Size = new Size(122, 20);
			this.info1CardsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1CardsLabel);
			this.info1CardsAmount.Text = "0";
			this.info1CardsAmount.Color = global::ARGBColors.Black;
			this.info1CardsAmount.Position = new Point(95, 35 + num2 * 5);
			this.info1CardsAmount.Size = new Size(82, 20);
			this.info1CardsAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1CardsAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1CardsAmount);
			this.info1BlackLine1Label.Text = "----------";
			this.info1BlackLine1Label.Color = global::ARGBColors.Black;
			this.info1BlackLine1Label.Position = new Point(15, 35 + num2 * 6 - 5);
			this.info1BlackLine1Label.Size = new Size(162, 20);
			this.info1BlackLine1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1BlackLine1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1BlackLine1Label);
			this.info1BlackLine1aLabel.Text = "----------";
			this.info1BlackLine1aLabel.Color = global::ARGBColors.Black;
			this.info1BlackLine1aLabel.Position = new Point(12, 35 + num2 * 6 - 5);
			this.info1BlackLine1aLabel.Size = new Size(162, 20);
			this.info1BlackLine1aLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1BlackLine1aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1BlackLine1aLabel);
			this.info1PopularityLabel.Text = SK.Text("VillageMapPanel_Multiplier", "Multiplier");
			this.info1PopularityLabel.Color = global::ARGBColors.Black;
			this.info1PopularityLabel.Position = new Point(15, 35 + num2 * 7);
			this.info1PopularityLabel.Size = new Size(120, 20);
			this.info1PopularityLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1PopularityLabel);
			this.info1PopularityAmount.Text = "0";
			this.info1PopularityAmount.Color = global::ARGBColors.Black;
			this.info1PopularityAmount.Position = new Point(95, 35 + num2 * 7);
			this.info1PopularityAmount.Size = new Size(82, 20);
			this.info1PopularityAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PopularityAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1PopularityAmount);
			this.info1HonourCalc2.Text = "";
			this.info1HonourCalc2.Color = global::ARGBColors.Black;
			this.info1HonourCalc2.Position = new Point(80, 35 + num2 * 8);
			this.info1HonourCalc2.Size = new Size(70, 20);
			this.info1HonourCalc2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1HonourCalc2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1HonourCalc2);
			this.info1BlackLine2Label.Text = "----------";
			this.info1BlackLine2Label.Color = global::ARGBColors.Black;
			this.info1BlackLine2Label.Position = new Point(15, 35 + num2 * 9);
			this.info1BlackLine2Label.Size = new Size(162, 20);
			this.info1BlackLine2Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1BlackLine2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1BlackLine2Label);
			this.info1BlackLine2aLabel.Text = "----------";
			this.info1BlackLine2aLabel.Color = global::ARGBColors.Black;
			this.info1BlackLine2aLabel.Position = new Point(12, 35 + num2 * 9);
			this.info1BlackLine2aLabel.Size = new Size(162, 20);
			this.info1BlackLine2aLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1BlackLine2aLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1BlackLine2aLabel);
			this.info1HonourPerDayLabel.Text = SK.Text("VillageMapPanel_Honour_Per_Day", "Honour per Day");
			this.info1HonourPerDayLabel.Color = global::ARGBColors.Black;
			this.info1HonourPerDayLabel.Position = new Point(15, 35 + num2 * 10);
			this.info1HonourPerDayLabel.Size = new Size(162, 20);
			this.info1HonourPerDayLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1PanelImage.addControl(this.info1HonourPerDayLabel);
			this.info1HonourPerDayAmount.Text = "0";
			this.info1HonourPerDayAmount.Color = global::ARGBColors.Black;
			this.info1HonourPerDayAmount.Position = new Point(95, 35 + num2 * 10);
			this.info1HonourPerDayAmount.Size = new Size(82, 20);
			this.info1HonourPerDayAmount.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.info1HonourPerDayAmount.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.info1PanelImage.addControl(this.info1HonourPerDayAmount);
			this.info1PopImage.Image = GFXLibrary.popularityFace;
			this.info1PopImage.Position = new Point(150, 35 + num2 * 8 - 7);
			this.info1PanelImage.addControl(this.info1PopImage);
			this.info1PanelFaderImage.Image = GFXLibrary.r_popularity_panel_back;
			this.info1PanelFaderImage.Position = new Point(0, 0);
			this.info1PanelFaderImage.Alpha = 0f;
			this.info1PanelImage.addControl(this.info1PanelFaderImage);
			this.currentInfo1Height = 1;
			this.targetInfo1Height = 0;
		}

		// Token: 0x06002F1E RID: 12062 RVA: 0x0026495C File Offset: 0x00262B5C
		public int calcInfoTabYPos()
		{
			int num = this.calcBuildTabYPos();
			int num2 = 25 + this.currentBuildingHeight;
			if (num2 < 55)
			{
				num2 = 55;
			}
			return num2 + num;
		}

		// Token: 0x06002F1F RID: 12063 RVA: 0x00022310 File Offset: 0x00020510
		public bool isHonourTabOpen()
		{
			return this.targetInfo1Height == 335;
		}

		// Token: 0x06002F20 RID: 12064 RVA: 0x00264988 File Offset: 0x00262B88
		private void info1Clicked()
		{
			if (!GameEngine.Instance.World.isQuestObjectiveComplete(10001))
			{
				GameEngine.Instance.World.handleQuestObjectiveHappening(10001);
			}
			else
			{
				GameEngine.Instance.World.advanceTutorialOLD();
			}
			this.info1HeaderPanelImage.CustomTooltipID = 112;
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInBuildingPanel();
			if (this.currentInfo1Height == 0)
			{
				this.targetInfo1Height = 335;
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_honour_header_open");
				return;
			}
			if (this.currentInfo1Height == 335)
			{
				this.closeInfo1Panel();
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_honour_header_close");
			}
		}

		// Token: 0x06002F21 RID: 12065 RVA: 0x00022322 File Offset: 0x00020522
		public void closeInfo1Panel()
		{
			this.info1HeaderPanelImage.CustomTooltipID = 111;
			this.targetInfo1Height = 0;
		}

		// Token: 0x06002F22 RID: 12066 RVA: 0x00022338 File Offset: 0x00020538
		private void info1MouseOver()
		{
			this.info1HeaderPanelImage.Image = GFXLibrary.infobar_01_over;
		}

		// Token: 0x06002F23 RID: 12067 RVA: 0x0002234F File Offset: 0x0002054F
		private void info1MouseLeave()
		{
			this.info1HeaderPanelImage.Image = GFXLibrary.infobar_01;
		}

		// Token: 0x06002F24 RID: 12068 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showHonour()
		{
		}

		// Token: 0x06002F25 RID: 12069 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showHonourPopularity(double popularity)
		{
		}

		// Token: 0x06002F26 RID: 12070 RVA: 0x00264A34 File Offset: 0x00262C34
		public void showHonourBuildings(int numChurches, int numChapels, int numCathedrals, int numSmallGardens, int numLargeGardens, int numSmallStatues, int numLargeStatues, int numDovecotes, int numStocks, int numBurningPosts, int numGibbets, int numRacks, double popularitylevel, int parishBonus)
		{
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			double num = 0.0;
			if (numChapels > 0)
			{
				num += localWorldData.HonourBuilding_Chapel * (double)numChapels;
			}
			if (numChurches > 0)
			{
				num += localWorldData.HonourBuilding_Church * (double)numChurches;
			}
			if (numCathedrals > 0)
			{
				num += localWorldData.HonourBuilding_Cathedral * (double)numCathedrals;
			}
			double num2 = 0.0;
			double num3 = 0.0;
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				VillageMapBuilding villageMapBuilding = village.findBuildingType(0);
				if (villageMapBuilding != null)
				{
					foreach (VillageMapBuilding villageMapBuilding2 in village.Buildings)
					{
						if (villageMapBuilding2.isComplete())
						{
							double num4 = 0.0;
							bool flag = true;
							switch (villageMapBuilding2.buildingType)
							{
							case 38:
							case 41:
							case 42:
							case 43:
							case 44:
							case 45:
								num4 = localWorldData.HonourBuilding_SmallGarden;
								break;
							case 49:
							case 50:
							case 51:
								num4 = localWorldData.HonourBuilding_LargeGarden;
								break;
							case 54:
							case 55:
							case 56:
							case 57:
								num4 = localWorldData.HonourBuilding_SmallStatue;
								break;
							case 58:
							case 59:
								num4 = localWorldData.HonourBuilding_LargeStatue;
								break;
							case 60:
								num4 = localWorldData.HonourBuilding_Dovecote;
								break;
							case 61:
								flag = false;
								num4 = localWorldData.HonourBuilding_Stocks;
								break;
							case 62:
								flag = false;
								num4 = localWorldData.HonourBuilding_BurningPost;
								break;
							case 63:
								flag = false;
								num4 = localWorldData.HonourBuilding_Gibbet;
								break;
							case 64:
								flag = false;
								num4 = localWorldData.HonourBuilding_Rack;
								break;
							}
							if (num4 != 0.0)
							{
								double num5 = VillageBuildingsData.calcHonourRateBasedOnDistance(num4, villageMapBuilding.buildingLocation, villageMapBuilding2.buildingLocation);
								if (flag)
								{
									num2 += num5;
								}
								else
								{
									num3 += num5;
								}
							}
						}
					}
				}
			}
			double popToHonourFromCards = CardTypes.getPopToHonourFromCards(GameEngine.Instance.cardsManager.UserCardData);
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num *= 4.0;
				num2 *= 4.0;
				num3 *= 4.0;
			}
			double num6 = (double)ResearchData.artsResearchAffect[(int)GameEngine.Instance.World.UserResearchData.Research_Arts];
			double num7 = num + num2 + num3 + num6 + (double)parishBonus + popToHonourFromCards;
			double num8 = 0.0;
			if (popularitylevel > 0.0)
			{
				num8 = popularitylevel * num7;
			}
			NumberFormatInfo nfi_D = GameEngine.NFI_D;
			NumberFormatInfo nfi = GameEngine.NFI;
			this.info1ChurchAmount.Text = num.ToString("N", nfi);
			if (num2 == Math.Floor(num2))
			{
				this.info1DecorativeAmount.Text = num2.ToString("N", nfi);
			}
			else
			{
				this.info1DecorativeAmount.Text = num2.ToString("N", nfi_D);
			}
			if (num3 == Math.Floor(num3))
			{
				this.info1JusticeAmount.Text = num3.ToString("N", nfi);
			}
			else
			{
				this.info1JusticeAmount.Text = num3.ToString("N", nfi_D);
			}
			this.info1ArtsAmount.Text = ((int)num6).ToString("N", nfi);
			if (num7 == Math.Floor(num7))
			{
				this.info1PopularityAmount.Text = num7.ToString("N", nfi);
			}
			else
			{
				this.info1PopularityAmount.Text = num7.ToString("N", nfi_D);
			}
			this.info1ParishAmount.Text = parishBonus.ToString("N", nfi);
			this.info1CardsAmount.Text = popToHonourFromCards.ToString("N", nfi);
			this.info1HonourCalc2.Text = " x  " + Math.Max((int)popularitylevel, 0).ToString("N", nfi);
			double num9 = num7 * (double)((int)popularitylevel);
			if (this.ViewOnly)
			{
				num9 = ((GameEngine.Instance.Village == null) ? 0.0 : GameEngine.Instance.Village.ViewHonour);
			}
			if (num9 < 0.0)
			{
				num9 = 0.0;
			}
			this.info1HeaderHonourAmount.Text = ((int)num9).ToString("N", nfi);
			if (num8 == Math.Floor(num8))
			{
				this.info1HonourPerDayAmount.Text = num8.ToString("N", nfi);
				return;
			}
			this.info1HonourPerDayAmount.Text = num8.ToString("N", nfi_D);
		}

		// Token: 0x06002F27 RID: 12071 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void showHonourBanquet(double honourAmount, DateTime lastBanquetDate)
		{
		}

		// Token: 0x06002F28 RID: 12072 RVA: 0x00264EE8 File Offset: 0x002630E8
		public void initInfo2Panel()
		{
			int y = this.calcInfo2TabYPos();
			this.info2HeaderPanelImage.Image = GFXLibrary.infobar_02;
			this.info2HeaderPanelImage.Position = new Point(0, y);
			this.info2HeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info2MouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info2MouseLeave));
			this.info2HeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.info2Clicked));
			base.addControl(this.info2HeaderPanelImage);
			this.info2HeaderPanelGlowImage.Image = GFXLibrary.infobar_02_over;
			this.info2HeaderPanelGlowImage.Position = new Point(0, 0);
			this.info2HeaderPanelGlowImage.Visible = false;
			this.info2HeaderPanelImage.addControl(this.info2HeaderPanelGlowImage);
		}

		// Token: 0x06002F29 RID: 12073 RVA: 0x00022366 File Offset: 0x00020566
		private void info2Clicked()
		{
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInBuildingPanel();
			this.closeInfo1Panel();
		}

		// Token: 0x06002F2A RID: 12074 RVA: 0x00264FB0 File Offset: 0x002631B0
		private int calcInfo2TabYPos()
		{
			int num = this.calcInfoTabYPos();
			int num2 = 25 + this.currentInfo1Height;
			if (num2 < 55)
			{
				num2 = 55;
			}
			return num2 + num;
		}

		// Token: 0x06002F2B RID: 12075 RVA: 0x00022380 File Offset: 0x00020580
		private void info2MouseOver()
		{
			this.info2HeaderPanelGlowImage.Visible = true;
		}

		// Token: 0x06002F2C RID: 12076 RVA: 0x0002238E File Offset: 0x0002058E
		private void info2MouseLeave()
		{
			this.info2HeaderPanelGlowImage.Visible = false;
		}

		// Token: 0x06002F2D RID: 12077 RVA: 0x00264FDC File Offset: 0x002631DC
		public void initInfo3Panel()
		{
			int y = this.calcInfo2TabYPos() + 55;
			this.info3HeaderPanelImage.Image = GFXLibrary.infobar_03;
			this.info3HeaderPanelImage.Position = new Point(0, y);
			this.info3HeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info3MouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.info3MouseLeave));
			this.info3HeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.info3Clicked));
			base.addControl(this.info3HeaderPanelImage);
			this.info3HeaderPanelGlowImage.Image = GFXLibrary.infobar_03_over;
			this.info3HeaderPanelGlowImage.Position = new Point(0, 0);
			this.info3HeaderPanelGlowImage.Visible = false;
			this.info3HeaderPanelImage.addControl(this.info3HeaderPanelGlowImage);
		}

		// Token: 0x06002F2E RID: 12078 RVA: 0x00022366 File Offset: 0x00020566
		private void info3Clicked()
		{
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInBuildingPanel();
			this.closeInfo1Panel();
		}

		// Token: 0x06002F2F RID: 12079 RVA: 0x0002239C File Offset: 0x0002059C
		private void info3MouseOver()
		{
			this.info3HeaderPanelGlowImage.Visible = true;
		}

		// Token: 0x06002F30 RID: 12080 RVA: 0x000223AA File Offset: 0x000205AA
		private void info3MouseLeave()
		{
			this.info3HeaderPanelGlowImage.Visible = false;
		}

		// Token: 0x06002F31 RID: 12081 RVA: 0x002650A4 File Offset: 0x002632A4
		public void initExtrasPanel()
		{
			int y = this.calcInfoTabYPos();
			this.extrasHeaderPanelImage.Image = GFXLibrary.extrasbar_01;
			this.extrasHeaderPanelImage.Position = new Point(0, y);
			this.extrasHeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.extrasMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.extrasMouseLeave));
			this.extrasHeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.extrasClicked), "VillageMapPanel_extras_header");
			this.extrasHeaderPanelImage.Visible = false;
			this.extrasHeaderPanelImage.CustomTooltipID = 110;
			base.addControl(this.extrasHeaderPanelImage);
			this.extrasHeaderPanelGlowImage.Image = GFXLibrary.extrasbar_01_over;
			this.extrasHeaderPanelGlowImage.Position = new Point(0, 0);
			this.extrasHeaderPanelGlowImage.Visible = false;
			this.extrasHeaderPanelImage.addControl(this.extrasHeaderPanelGlowImage);
		}

		// Token: 0x06002F32 RID: 12082 RVA: 0x00265188 File Offset: 0x00263388
		private void extrasClicked()
		{
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInBuildingPanel();
			this.closeInfo1Panel();
			this.extrasHeaderPanelImage.Visible = false;
			this.info1HeaderPanelImage.Visible = true;
			this.info2HeaderPanelImage.Visible = true;
			this.info3HeaderPanelImage.Visible = true;
		}

		// Token: 0x06002F33 RID: 12083 RVA: 0x000223B8 File Offset: 0x000205B8
		private void extrasMouseOver()
		{
			this.extrasHeaderPanelGlowImage.Visible = true;
		}

		// Token: 0x06002F34 RID: 12084 RVA: 0x000223C6 File Offset: 0x000205C6
		private void extrasMouseLeave()
		{
			this.extrasHeaderPanelGlowImage.Visible = false;
		}

		// Token: 0x06002F35 RID: 12085 RVA: 0x000223D4 File Offset: 0x000205D4
		public void showExtras()
		{
			if (!this.m_villageIsCapital)
			{
				this.extrasHeaderPanelImage.Visible = false;
				this.info1HeaderPanelImage.Visible = true;
				this.info2HeaderPanelImage.Visible = false;
				this.info3HeaderPanelImage.Visible = false;
			}
		}

		// Token: 0x06002F36 RID: 12086 RVA: 0x002651E0 File Offset: 0x002633E0
		public void initInBuildingPanel()
		{
			int y = this.calcInfoTabYPos() + 55 + 55 + 55;
			this.inBuildingPanelImage.Image = GFXLibrary.r_popularity_panel_back;
			this.inBuildingPanelImage.Position = new Point(0, 25);
			base.addControl(this.inBuildingPanelImage);
			this.inBuildingPanelImage.Visible = false;
			this.inBuildingHeaderPanelImage.Image = GFXLibrary.r_building_bar_building_info_norm;
			this.inBuildingHeaderPanelImage.Position = new Point(0, y);
			this.inBuildingHeaderPanelImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.inBuildngMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.inBuildngMouseLeave));
			this.inBuildingHeaderPanelImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.inBuildngClicked), "VillageMapPanel_inbuilding_header");
			this.inBuildingHeaderPanelImage.CustomTooltipID = 113;
			this.inBuildingHeaderPanelImage.CustomTooltipData = -1;
			base.addControl(this.inBuildingHeaderPanelImage);
			this.inBuildingHeaderPanelImage.Visible = false;
			this.inBuildingTypeImage.Position = new Point(0, -23);
			this.inBuildingHeaderPanelImage.addControl(this.inBuildingTypeImage);
			this.inBuildingMoveButton.Position = new Point(129, 2);
			this.inBuildingMoveButton.ImageNorm = GFXLibrary.but_move_building_normal;
			this.inBuildingMoveButton.ImageOver = GFXLibrary.but_move_building_over;
			this.inBuildingMoveButton.ImageClick = GFXLibrary.but_move_building_pushed;
			this.inBuildingMoveButton.CustomTooltipID = 114;
			this.inBuildingMoveButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.moveBuildingClick), "VillageMapPanel_move_building");
			this.inBuildingHeaderPanelImage.addControl(this.inBuildingMoveButton);
			this.inBuildingHelpButton.Position = new Point(100, 18);
			this.inBuildingHelpButton.ImageNorm = GFXLibrary.help_normal;
			this.inBuildingHelpButton.ImageOver = GFXLibrary.help_over;
			this.inBuildingHelpButton.ImageClick = GFXLibrary.help_pushed;
			this.inBuildingHelpButton.Visible = false;
			this.inBuildingHelpButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.helpClicked), "VillageMapPanel_inbulding_help");
			this.inBuildingHeaderPanelImage.addControl(this.inBuildingHelpButton);
			this.inBuildingName.Text = "";
			this.inBuildingName.Color = global::ARGBColors.Black;
			this.inBuildingName.DropShadowColor = global::ARGBColors.White;
			this.inBuildingName.Size = new Size(this.inBuildingPanelImage.Width - 24, 40);
			this.inBuildingName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.inBuildingName.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.inBuildingName.Position = new Point(8, 70);
			this.inBuildingTypeImage.addControl(this.inBuildingName);
			this.inBuildingCompleteLabel.Text = "";
			this.inBuildingCompleteLabel.Color = global::ARGBColors.Black;
			this.inBuildingCompleteLabel.Position = new Point(8, 52);
			this.inBuildingCompleteLabel.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingCompleteLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.inBuildingCompleteLabel.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingCompleteLabel);
			this.inBuildingCompleteLabel2.Text = "";
			this.inBuildingCompleteLabel2.Color = global::ARGBColors.Black;
			this.inBuildingCompleteLabel2.Position = new Point(8, 70);
			this.inBuildingCompleteLabel2.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingCompleteLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.inBuildingCompleteLabel2.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingCompleteLabel2);
			this.inBuildingDonateButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingDonateButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingDonateButton.Position = new Point(21, 240);
			this.inBuildingDonateButton.Text.Text = SK.Text("VillageMapPanel_Donate_Resources", "Donate Resources");
			this.inBuildingDonateButton.TextYOffset = -1;
			this.inBuildingDonateButton.Text.Color = global::ARGBColors.Black;
			this.inBuildingDonateButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.donateClick), "VillageMapPanel_donate");
			this.inBuildingDonateButton.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingDonateButton);
			this.inBuildingDeleteButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingDeleteButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingDeleteButton.Position = new Point(21, 275);
			this.inBuildingDeleteButton.Text.Text = SK.Text("VillageMapPanel_Delete_This_Building", "Delete this Building");
			this.inBuildingDeleteButton.TextYOffset = -1;
			this.inBuildingDeleteButton.Text.Color = global::ARGBColors.Black;
			this.inBuildingDeleteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteBuildingClick), "VillageMapPanel_delete");
			this.inBuildingDeleteButton.Enabled = true;
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.inBuildingDeleteButton.Text.Font = FontManager.GetFont("Arial", 7.5f, FontStyle.Regular);
			}
			else
			{
				this.inBuildingDeleteButton.Text.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
			}
			this.inBuildingPanelImage.addControl(this.inBuildingDeleteButton);
			if (this.m_villageIsCapital && VillageMap.getCurrentServerTime() < GameEngine.Instance.Village.m_captialNextDelete)
			{
				this.inBuildingDeleteButton.Enabled = false;
				string text = SK.Text("VillageMapPanel_Next_Delete", "Next Delete : ") + " < ";
				int num = (int)((GameEngine.Instance.Village.m_captialNextDelete - VillageMap.getCurrentServerTime()).TotalHours + 1.0);
				text = text + num.ToString() + " ";
				text = ((num != 1) ? (text + SK.Text("VillageMapPanel_Hours", "Hours")) : (text + SK.Text("VillageMapPanel_Hour", "Hour")));
				this.inBuildingDeleteButton.Text.Text = text;
			}
			this.inBuildingAllIndustryOnButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingAllIndustryOnButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingAllIndustryOnButton.Position = new Point(21, 238);
			this.inBuildingAllIndustryOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_On", "Turn All On");
			this.inBuildingAllIndustryOnButton.TextYOffset = -1;
			this.inBuildingAllIndustryOnButton.Text.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pt")
			{
				this.inBuildingAllIndustryOnButton.Text.Font = FontManager.GetFont("Arial", 7.5f);
			}
			else
			{
				this.inBuildingAllIndustryOnButton.Text.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.inBuildingAllIndustryOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllIndustryOnClicked), "VillageMapPanel_all_on");
			this.inBuildingPanelImage.addControl(this.inBuildingAllIndustryOnButton);
			this.inBuildingIndustryAllOnButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingIndustryAllOnButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingIndustryAllOnButton.Position = new Point(21, 201);
			this.inBuildingIndustryAllOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_On", "Turn All On");
			this.inBuildingIndustryAllOnButton.TextYOffset = -1;
			this.inBuildingIndustryAllOnButton.Text.Color = global::ARGBColors.Black;
			this.inBuildingIndustryAllOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllOnClicked), "VillageMapPanel_all_on");
			this.inBuildingPanelImage.addControl(this.inBuildingIndustryAllOnButton);
			this.inBuildingIndustryThisOnButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingIndustryThisOnButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingIndustryThisOnButton.Position = new Point(21, 164);
			this.inBuildingIndustryThisOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_This_On", "Turn This On");
			this.inBuildingIndustryThisOnButton.TextYOffset = -1;
			this.inBuildingIndustryThisOnButton.Text.Color = global::ARGBColors.Black;
			this.inBuildingIndustryThisOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnThisOnClicked), "VillageMapPanel_this_on");
			this.inBuildingPanelImage.addControl(this.inBuildingIndustryThisOnButton);
			this.inBuildingFaderImage.Image = GFXLibrary.r_popularity_panel_back;
			this.inBuildingFaderImage.Position = new Point(0, 0);
			this.inBuildingFaderImage.Alpha = 0f;
			this.inBuildingPanelImage.addControl(this.inBuildingFaderImage);
			this.currentInBuildingHeight = 1;
			this.targetInBuildingHeight = 0;
			this.inBuildingGenericButton.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingGenericButton.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingGenericButton.Position = new Point(21, 158);
			this.inBuildingGenericButton.Text.Text = "";
			this.inBuildingGenericButton.TextYOffset = -1;
			this.inBuildingGenericButton.Text.Color = global::ARGBColors.Black;
			this.inBuildingGenericButton.Visible = false;
			this.inBuildingGenericButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.genericButtonClicked), "VillageMapPanel_generic_1");
			this.inBuildingPanelImage.addControl(this.inBuildingGenericButton);
			this.inBuildingGenericButton2.ImageNorm = GFXLibrary.int_but_delete_norm;
			this.inBuildingGenericButton2.ImageOver = GFXLibrary.int_but_delete_over;
			this.inBuildingGenericButton2.Position = new Point(21, 117);
			this.inBuildingGenericButton2.Text.Text = "";
			this.inBuildingGenericButton2.TextYOffset = -1;
			this.inBuildingGenericButton2.Text.Color = global::ARGBColors.Black;
			this.inBuildingGenericButton2.Visible = false;
			this.inBuildingGenericButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.genericButtonClicked2), "VillageMapPanel_generic_2");
			this.inBuildingPanelImage.addControl(this.inBuildingGenericButton2);
			this.inBuildingMakeWeaponLabel0.Text = SK.Text("VillageMapPanel_Producing_Per_Day", "Producing Per Day");
			this.inBuildingMakeWeaponLabel0.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel0.Position = new Point(8, 82);
			this.inBuildingMakeWeaponLabel0.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel0.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingMakeWeaponLabel0.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel0);
			this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Production_Efficiency", "Production Efficiency");
			this.inBuildingMakeWeaponLabel1.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel1.Position = new Point(8, 100);
			this.inBuildingMakeWeaponLabel1.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.inBuildingMakeWeaponLabel1.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel1);
			this.inBuildingMakeWeaponLabel2.Text = "100%";
			this.inBuildingMakeWeaponLabel2.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel2.Position = new Point(8, 100);
			this.inBuildingMakeWeaponLabel2.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingMakeWeaponLabel2.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel2);
			this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Production_Efficiency", "Production Efficiency");
			this.inBuildingMakeWeaponLabel3.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel3.Position = new Point(8, 118);
			this.inBuildingMakeWeaponLabel3.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.inBuildingMakeWeaponLabel3.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel3);
			this.inBuildingMakeWeaponLabel4.Text = "100%";
			this.inBuildingMakeWeaponLabel4.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel4.Position = new Point(8, 118);
			this.inBuildingMakeWeaponLabel4.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingMakeWeaponLabel4.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel4);
			this.inBuildingMakeWeaponLabel5.Text = SK.Text("VillageMapPanel_Cost_Each", "Cost Each");
			this.inBuildingMakeWeaponLabel5.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel5.Position = new Point(8, 136);
			this.inBuildingMakeWeaponLabel5.Size = new Size(this.inBuildingPanelImage.Width - 24, 20);
			this.inBuildingMakeWeaponLabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.inBuildingMakeWeaponLabel5.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel5);
			this.inBuildingMakeWeaponLabel6.Text = "0";
			this.inBuildingMakeWeaponLabel6.Color = global::ARGBColors.Black;
			this.inBuildingMakeWeaponLabel6.Position = new Point(8, 136);
			this.inBuildingMakeWeaponLabel6.Size = new Size(this.inBuildingPanelImage.Width - 24 - 18, 20);
			this.inBuildingMakeWeaponLabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingMakeWeaponLabel6.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponLabel6);
			this.inBuildingMakeWeaponImage1.Position = new Point(this.inBuildingPanelImage.Width - 20 - 16, 118);
			this.inBuildingMakeWeaponImage1.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponImage1);
			this.inBuildingMakeWeaponImage2.Position = new Point(this.inBuildingPanelImage.Width - 20 - 16 - 16, 118);
			this.inBuildingMakeWeaponImage2.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponImage2);
			this.inBuildingMakeWeaponImage3.Position = new Point(this.inBuildingPanelImage.Width - 20 - 16 + 4, 136);
			this.inBuildingMakeWeaponImage3.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponImage3);
			this.inBuildingMakeWeaponImage4.Position = new Point(this.inBuildingPanelImage.Width - 20 - 16 + 2 - 16, 136);
			this.inBuildingMakeWeaponImage4.Visible = false;
			this.inBuildingPanelImage.addControl(this.inBuildingMakeWeaponImage4);
			this.inBuildingCapitalResourceLevelLabel1.Text = SK.Text("VillageMapPanel_Current_Level", "Current Level");
			this.inBuildingCapitalResourceLevelLabel1.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLevelLabel1.Position = new Point(20, 78);
			this.inBuildingCapitalResourceLevelLabel1.Size = new Size(120, 20);
			this.inBuildingCapitalResourceLevelLabel1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.inBuildingCapitalResourceLevelLabel1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLevelLabel1);
			this.inBuildingCapitalResourceLevelLabel2.Text = "0";
			this.inBuildingCapitalResourceLevelLabel2.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLevelLabel2.Position = new Point(130, 78);
			this.inBuildingCapitalResourceLevelLabel2.Size = new Size(40, 20);
			this.inBuildingCapitalResourceLevelLabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLevelLabel2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLevelLabel2);
			this.inBuildingCapitalResourceLabel1a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel1a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel1a.Position = new Point(28, 108);
			this.inBuildingCapitalResourceLabel1a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel1a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel1a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel1a);
			this.inBuildingCapitalResourceLabel1b.Text = "/";
			this.inBuildingCapitalResourceLabel1b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel1b.Position = new Point(103, 108);
			this.inBuildingCapitalResourceLabel1b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel1b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel1b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel1b);
			this.inBuildingCapitalResourceLabel1c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel1c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel1c.Position = new Point(108, 108);
			this.inBuildingCapitalResourceLabel1c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel1c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel1c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel1c);
			this.inBuildingCapitalResourceImage1.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage1.Position = new Point(15, 108);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage1);
			this.inBuildingCapitalResourceLabel2a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel2a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel2a.Position = new Point(28, 124);
			this.inBuildingCapitalResourceLabel2a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel2a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel2a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel2a);
			this.inBuildingCapitalResourceLabel2b.Text = "/";
			this.inBuildingCapitalResourceLabel2b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel2b.Position = new Point(103, 124);
			this.inBuildingCapitalResourceLabel2b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel2b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel2b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel2b);
			this.inBuildingCapitalResourceLabel2c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel2c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel2c.Position = new Point(108, 124);
			this.inBuildingCapitalResourceLabel2c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel2c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel2c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel2c);
			this.inBuildingCapitalResourceImage2.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage2.Position = new Point(15, 124);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage2);
			this.inBuildingCapitalResourceLabel3a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel3a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel3a.Position = new Point(28, 140);
			this.inBuildingCapitalResourceLabel3a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel3a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel3a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel3a);
			this.inBuildingCapitalResourceLabel3b.Text = "/";
			this.inBuildingCapitalResourceLabel3b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel3b.Position = new Point(103, 140);
			this.inBuildingCapitalResourceLabel3b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel3b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel3b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel3b);
			this.inBuildingCapitalResourceLabel3c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel3c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel3c.Position = new Point(108, 140);
			this.inBuildingCapitalResourceLabel3c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel3c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel3c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel3c);
			this.inBuildingCapitalResourceImage3.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage3.Position = new Point(15, 140);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage3);
			this.inBuildingCapitalResourceLabel4a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel4a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel4a.Position = new Point(28, 156);
			this.inBuildingCapitalResourceLabel4a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel4a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel4a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel4a);
			this.inBuildingCapitalResourceLabel4b.Text = "/";
			this.inBuildingCapitalResourceLabel4b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel4b.Position = new Point(103, 156);
			this.inBuildingCapitalResourceLabel4b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel4b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel4b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel4b);
			this.inBuildingCapitalResourceLabel4c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel4c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel4c.Position = new Point(108, 156);
			this.inBuildingCapitalResourceLabel4c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel4c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel4c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel4c);
			this.inBuildingCapitalResourceImage4.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage4.Position = new Point(15, 156);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage4);
			this.inBuildingCapitalResourceLabel5a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel5a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel5a.Position = new Point(28, 172);
			this.inBuildingCapitalResourceLabel5a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel5a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel5a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel5a);
			this.inBuildingCapitalResourceLabel5b.Text = "/";
			this.inBuildingCapitalResourceLabel5b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel5b.Position = new Point(103, 172);
			this.inBuildingCapitalResourceLabel5b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel5b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel5b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel5b);
			this.inBuildingCapitalResourceLabel5c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel5c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel5c.Position = new Point(108, 172);
			this.inBuildingCapitalResourceLabel5c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel5c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel5c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel5c);
			this.inBuildingCapitalResourceImage5.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage5.Position = new Point(15, 172);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage5);
			this.inBuildingCapitalResourceLabel6a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel6a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel6a.Position = new Point(28, 188);
			this.inBuildingCapitalResourceLabel6a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel6a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel6a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel6a);
			this.inBuildingCapitalResourceLabel6b.Text = "/";
			this.inBuildingCapitalResourceLabel6b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel6b.Position = new Point(103, 188);
			this.inBuildingCapitalResourceLabel6b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel6b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel6b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel6b);
			this.inBuildingCapitalResourceLabel6c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel6c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel6c.Position = new Point(108, 188);
			this.inBuildingCapitalResourceLabel6c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel6c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel6c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel6c);
			this.inBuildingCapitalResourceImage6.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage6.Position = new Point(15, 188);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage6);
			this.inBuildingCapitalResourceLabel7a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel7a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel7a.Position = new Point(28, 204);
			this.inBuildingCapitalResourceLabel7a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel7a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel7a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel7a);
			this.inBuildingCapitalResourceLabel7b.Text = "/";
			this.inBuildingCapitalResourceLabel7b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel7b.Position = new Point(103, 204);
			this.inBuildingCapitalResourceLabel7b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel7b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel7b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel7b);
			this.inBuildingCapitalResourceLabel7c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel7c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel7c.Position = new Point(108, 204);
			this.inBuildingCapitalResourceLabel7c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel7c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel7c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel7c);
			this.inBuildingCapitalResourceImage7.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage7.Position = new Point(15, 204);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage7);
			this.inBuildingCapitalResourceLabel8a.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel8a.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel8a.Position = new Point(28, 220);
			this.inBuildingCapitalResourceLabel8a.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel8a.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel8a.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel8a);
			this.inBuildingCapitalResourceLabel8b.Text = "/";
			this.inBuildingCapitalResourceLabel8b.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel8b.Position = new Point(103, 220);
			this.inBuildingCapitalResourceLabel8b.Size = new Size(10, 20);
			this.inBuildingCapitalResourceLabel8b.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.inBuildingCapitalResourceLabel8b.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel8b);
			this.inBuildingCapitalResourceLabel8c.Text = "1,400,000";
			this.inBuildingCapitalResourceLabel8c.Color = global::ARGBColors.Black;
			this.inBuildingCapitalResourceLabel8c.Position = new Point(108, 220);
			this.inBuildingCapitalResourceLabel8c.Size = new Size(70, 20);
			this.inBuildingCapitalResourceLabel8c.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.inBuildingCapitalResourceLabel8c.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceLabel8c);
			this.inBuildingCapitalResourceImage8.Image = GFXLibrary.com_16_iron;
			this.inBuildingCapitalResourceImage8.Position = new Point(15, 220);
			this.inBuildingPanelImage.addControl(this.inBuildingCapitalResourceImage8);
		}

		// Token: 0x06002F37 RID: 12087 RVA: 0x0002240E File Offset: 0x0002060E
		public VillageMapBuilding getInBuildingBuilding()
		{
			return this.selectedBuilding;
		}

		// Token: 0x06002F38 RID: 12088 RVA: 0x00267020 File Offset: 0x00265220
		public void showInBuildingInfo(VillageMapBuilding building)
		{
			if (building == null)
			{
				this.closeInBuildingPanel();
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			NumberFormatInfo nfi = GameEngine.NFI;
			this.closeTopGivers();
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInfo1Panel();
			this.showExtras();
			if (village != null)
			{
				village.highlightBuilding(building);
			}
			this.inBuildingDonateButton.Visible = false;
			this.inBuildingName.Text = VillageBuildingsData.getBuildingName(building.buildingType);
			if (!this.m_villageIsCapital)
			{
				this.inBuildingHeaderPanelImage.CustomTooltipData = -1;
				this.inBuildingHelpButton.Visible = false;
				int num = this.calcInfoTabYPos() + 55;
				this.targetInBuildingHeight = 335;
				this.inBuildingHeaderPanelImage.Position = new Point(0, num);
				this.inBuildingPanelImage.Position = new Point(0, num + 25);
				this.inBuildingCompleteLabel.Position = new Point(8, 52);
				this.inBuildingCompleteLabel2.Position = new Point(8, 70);
				this.inBuildingDeleteButton.Visible = true;
				if (building.isDeleting())
				{
					this.inBuildingDeleteButton.Text.Text = SK.Text("VillageMapPanel_Cancel_Delete", "Cancel Delete");
					this.inBuildingDeleteButton.Enabled = true;
				}
				else
				{
					this.inBuildingDeleteButton.Text.Text = SK.Text("VillageMapPanel_Delete_This_Building", "Delete this Building");
					if (village.getNumDeleting() >= 3)
					{
						this.inBuildingDeleteButton.Enabled = false;
					}
					else
					{
						this.inBuildingDeleteButton.Enabled = true;
					}
				}
			}
			else
			{
				this.inBuildingHeaderPanelImage.CustomTooltipData = building.buildingType;
				this.inBuildingHelpButton.Visible = true;
				this.currentSelectedBuildingType = building.buildingType;
				int num2 = this.calcTop10YPos();
				int num = num2 + 55;
				this.targetInBuildingHeight = 290;
				this.inBuildingHeaderPanelImage.Position = new Point(0, num);
				int num3 = 45;
				this.inBuildingPanelImage.Position = new Point(0, num + 25 - num3);
				this.inBuildingCompleteLabel.Position = new Point(8, 27 + num3);
				this.inBuildingCompleteLabel2.Position = new Point(8, 45 + num3);
				if (GameEngine.Instance.World.isUserVillage(village.VillageID))
				{
					this.inBuildingDeleteButton.Enabled = true;
					this.inBuildingDeleteButton.Visible = true;
					if (VillageMap.getCurrentServerTime() < GameEngine.Instance.Village.m_captialNextDelete)
					{
						this.inBuildingDeleteButton.Enabled = false;
						string text = SK.Text("VillageMapPanel_Next_Delete", "Next Delete : ") + " < ";
						int num4 = (int)((GameEngine.Instance.Village.m_captialNextDelete - VillageMap.getCurrentServerTime()).TotalHours + 1.0);
						text = text + num4.ToString() + " ";
						text = ((num4 != 1) ? (text + SK.Text("VillageMapPanel_Hours", "Hours")) : (text + SK.Text("VillageMapPanel_Hour", "Hour")));
						this.inBuildingDeleteButton.Text.Text = text;
					}
					else
					{
						this.inBuildingDeleteButton.Text.Text = SK.Text("VillageMapPanel_Delete_This_Building", "Delete this Building");
					}
				}
				else
				{
					this.inBuildingDeleteButton.Visible = false;
				}
			}
			this.inBuildingHeaderPanelImage.Visible = true;
			this.inBuildingPanelImage.Visible = true;
			this.inBuildingGenericButton.Visible = false;
			this.inBuildingGenericButton2.Visible = false;
			this.inBuildingMakeWeaponLabel0.Visible = false;
			this.inBuildingMakeWeaponLabel1.Visible = false;
			this.inBuildingMakeWeaponLabel2.Visible = false;
			this.inBuildingMakeWeaponLabel3.Visible = false;
			this.inBuildingMakeWeaponLabel4.Visible = false;
			this.inBuildingMakeWeaponLabel5.Visible = false;
			this.inBuildingMakeWeaponLabel6.Visible = false;
			this.inBuildingMakeWeaponImage1.Visible = false;
			this.inBuildingMakeWeaponImage2.Visible = false;
			this.inBuildingMakeWeaponImage3.Visible = false;
			this.inBuildingMakeWeaponImage4.Visible = false;
			this.selectedBuilding = building;
			if (this.selectedBuilding != null && ((GameEngine.Instance.World.isAccountPremium() && !this.m_villageIsCapital) || (this.m_villageIsCapital && GameEngine.Instance.World.isUserVillage(village.VillageID))) && !GameEngine.Instance.World.WorldEnded)
			{
				this.inBuildingMoveButton.Visible = true;
			}
			else
			{
				this.inBuildingMoveButton.Visible = false;
			}
			BaseImage b = null;
			switch (this.selectedBuilding.buildingType)
			{
			case 0:
			{
				int rank = GameEngine.Instance.World.getRank();
				b = ((rank < 10) ? GFXLibrary.r_building_panel_bld_civ_hall_1 : ((rank < 15) ? GFXLibrary.r_building_panel_bld_civ_hall_2 : ((rank >= 21) ? GFXLibrary.r_building_panel_bld_civ_hall_3 : GFXLibrary.r_building_panel_bld_civ_hall_3)));
				this.inBuildingDeleteButton.Visible = false;
				if (!this.ViewOnly)
				{
					this.inBuildingGenericButton.Visible = true;
					this.inBuildingGenericButton.Text.Text = SK.Text("VillageMapPanel_Hold_Banquet", "Hold Banquet");
				}
				if (building.isComplete())
				{
					this.inBuildingGenericButton2.Visible = true;
					this.inBuildingGenericButton2.Text.Text = SK.Text("VillageMapPanel_Resources", "Resources");
				}
				break;
			}
			case 1:
			case 39:
			case 40:
			case 76:
			case 77:
				switch (GameEngine.Instance.World.UserResearchData.Research_HousingCapacity)
				{
				case 3:
				case 4:
					b = GFXLibrary.r_building_panel_bld_civ_house_2;
					break;
				case 5:
				case 6:
					b = GFXLibrary.r_building_panel_bld_civ_house_3;
					break;
				case 7:
				case 8:
					b = GFXLibrary.r_building_panel_bld_civ_house_4;
					break;
				case 9:
				case 10:
					b = GFXLibrary.r_building_panel_bld_civ_house_5;
					break;
				default:
					b = GFXLibrary.r_building_panel_bld_civ_house_1;
					break;
				}
				if (village != null)
				{
					int num5 = ResearchData.researchHousingLevels[(int)GameEngine.Instance.World.userResearchData.Research_HousingCapacity];
					VillageMapBuilding villageMapBuilding = village.findBuildingType(0);
					if (villageMapBuilding != null)
					{
						int mapDistance = VillageBuildingsData.getMapDistance(villageMapBuilding.buildingLocation, building.buildingLocation);
						num5 += VillageBuildingsData.getHousingCapacityBasedOnDistance(GameEngine.Instance.LocalWorldData, mapDistance);
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Capacity", "Capacity");
						this.inBuildingMakeWeaponLabel2.Text = num5.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 2:
				b = GFXLibrary.r_building_panel_bld_icon_ind_stockpile;
				this.inBuildingDeleteButton.Visible = false;
				if (building.isComplete())
				{
					this.inBuildingGenericButton.Visible = true;
					this.inBuildingGenericButton.Text.Text = SK.Text("VillageMapPanel_Resources", "Resources");
				}
				break;
			case 3:
				b = GFXLibrary.r_building_panel_bld_icon_food_granary;
				this.inBuildingDeleteButton.Visible = false;
				if (building.isComplete())
				{
					this.inBuildingGenericButton.Visible = true;
					this.inBuildingGenericButton.Text.Text = SK.Text("VillageMapPanel_Resources", "Resources");
				}
				break;
			case 6:
				b = GFXLibrary.r_building_panel_bld_icon_ind_woodcutters_hut;
				break;
			case 7:
				b = GFXLibrary.r_building_panel_bld_icon_ind_stone_quarry;
				break;
			case 8:
				b = GFXLibrary.r_building_panel_bld_icon_ind_iron_mine;
				break;
			case 9:
				b = GFXLibrary.r_building_panel_bld_icon_ind_pitch_rig;
				break;
			case 12:
				b = GFXLibrary.r_building_panel_bld_icon_food_brewery;
				break;
			case 13:
				b = GFXLibrary.r_building_panel_bld_icon_food_apple_orchard;
				break;
			case 14:
				b = GFXLibrary.r_building_panel_bld_icon_food_bakery;
				break;
			case 15:
				b = GFXLibrary.r_building_panel_bld_icon_food_vegetable_farm;
				break;
			case 16:
				b = GFXLibrary.r_building_panel_bld_icon_food_pig_farm;
				break;
			case 17:
				b = GFXLibrary.r_building_panel_bld_icon_food_dairy_farm;
				break;
			case 18:
				b = GFXLibrary.r_building_panel_bld_icon_food_fishing_jetty;
				break;
			case 19:
				b = GFXLibrary.r_building_panel_bld_icon_hon_tailers_workshop;
				break;
			case 21:
				b = GFXLibrary.r_building_panel_bld_icon_hon_carpenters_workshop;
				break;
			case 22:
				b = GFXLibrary.r_building_panel_bld_icon_hon_hunters_hut;
				break;
			case 23:
				b = GFXLibrary.r_building_panel_bld_icon_hon_salt_pan;
				break;
			case 24:
				b = GFXLibrary.r_building_panel_bld_icon_hon_spice_docs;
				break;
			case 25:
				b = GFXLibrary.r_building_panel_bld_icon_hon_silk_docs;
				break;
			case 26:
				b = GFXLibrary.r_building_panel_bld_icon_hon_metalworks_workshop;
				break;
			case 28:
				if (building.isComplete())
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Max_Made_Per_Day", "Max. Made Per Day");
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					if (building.serverCalcRate > 0.0)
					{
						int weaponsPerDayValue = village.getWeaponsPerDayValue(building);
						this.inBuildingMakeWeaponLabel2.Text = weaponsPerDayValue.ToString();
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					this.updateWeaponProductionInfo();
				}
				b = GFXLibrary.r_building_panel_bld_icon_mil_pole_turner;
				break;
			case 29:
				if (building.isComplete())
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Max_Made_Per_Day", "Max. Made Per Day");
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					if (building.serverCalcRate > 0.0)
					{
						int weaponsPerDayValue2 = village.getWeaponsPerDayValue(building);
						this.inBuildingMakeWeaponLabel2.Text = weaponsPerDayValue2.ToString();
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					this.updateWeaponProductionInfo();
				}
				b = GFXLibrary.r_building_panel_bld_icon_mil_fletcher;
				break;
			case 30:
				if (building.isComplete())
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Max_Made_Per_Day", "Max. Made Per Day");
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					if (building.serverCalcRate > 0.0)
					{
						int weaponsPerDayValue3 = village.getWeaponsPerDayValue(building);
						this.inBuildingMakeWeaponLabel2.Text = weaponsPerDayValue3.ToString();
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					this.updateWeaponProductionInfo();
				}
				b = GFXLibrary.r_building_panel_bld_icon_mil_blacksmith;
				break;
			case 31:
				if (building.isComplete())
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Max_Made_Per_Day", "Max. Made Per Day");
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					if (building.serverCalcRate > 0.0)
					{
						int weaponsPerDayValue4 = village.getWeaponsPerDayValue(building);
						this.inBuildingMakeWeaponLabel2.Text = weaponsPerDayValue4.ToString();
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					this.updateWeaponProductionInfo();
				}
				b = GFXLibrary.r_building_panel_bld_icon_mil_armourer;
				break;
			case 32:
				if (building.isComplete())
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Max_Made_Per_Day", "Max. Made Per Day");
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					if (building.serverCalcRate > 0.0)
					{
						double weaponsPerDayValueD = village.getWeaponsPerDayValueD(building);
						this.inBuildingMakeWeaponLabel2.Text = weaponsPerDayValueD.ToString("0.#");
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					this.updateWeaponProductionInfo();
				}
				b = GFXLibrary.r_building_panel_bld_icon_mil_siege_workshop;
				break;
			case 33:
				b = GFXLibrary.r_building_panel_bld_icon_hon_vinyard;
				break;
			case 34:
				b = GFXLibrary.r_building_panel_bld_civ_rel_small_church;
				break;
			case 35:
				b = GFXLibrary.r_building_panel_bld_icon_food_inn;
				this.inBuildingDeleteButton.Visible = false;
				if (building.isComplete())
				{
					this.inBuildingGenericButton.Visible = true;
					this.inBuildingGenericButton.Text.Text = SK.Text("VillageMapPanel_Resources", "Resources");
				}
				break;
			case 36:
				b = GFXLibrary.r_building_panel_bld_civ_rel_medium_church;
				break;
			case 37:
				b = GFXLibrary.r_building_panel_bld_civ_rel_large_church;
				break;
			case 38:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_01;
				break;
			case 41:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_02;
				break;
			case 42:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_03;
				break;
			case 43:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_04;
				break;
			case 44:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_05;
				break;
			case 45:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_garden_06;
				break;
			case 49:
				b = GFXLibrary.r_building_panel_bld_civ_dec_large_garden_01png;
				break;
			case 50:
				b = GFXLibrary.r_building_panel_bld_civ_dec_large_garden_02;
				break;
			case 51:
				b = GFXLibrary.r_building_panel_bld_civ_dec_large_garden_03;
				break;
			case 54:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_statue_01;
				break;
			case 55:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_statue_02;
				break;
			case 56:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_statue_03;
				break;
			case 57:
				b = GFXLibrary.r_building_panel_bld_civ_dec_small_statue_04;
				break;
			case 58:
				b = GFXLibrary.r_building_panel_bld_civ_dec_large_statue_01;
				break;
			case 59:
				b = GFXLibrary.r_building_panel_bld_civ_dec_large_statue_02;
				break;
			case 60:
				b = GFXLibrary.r_building_panel_bld_civ_dec_dovecote;
				break;
			case 61:
				b = GFXLibrary.r_building_panel_bld_jus_stocks;
				break;
			case 62:
				b = GFXLibrary.r_building_panel_bld_jus_burning_post;
				break;
			case 63:
				b = GFXLibrary.r_building_panel_bld_jus_gibbet;
				break;
			case 64:
				b = GFXLibrary.r_building_panel_bld_jus_stretching_rack;
				break;
			case 65:
				b = GFXLibrary.r_building_panel_bld_ent_maypole;
				break;
			case 66:
				b = GFXLibrary.r_building_panel_bld_ent_dancing_bear;
				break;
			case 67:
				b = GFXLibrary.r_building_panel_bld_ent_theatre;
				break;
			case 68:
				b = GFXLibrary.r_building_panel_bld_ent_jesters_court;
				break;
			case 69:
				b = GFXLibrary.r_building_panel_bld_ent_troubadours_arbor;
				break;
			case 70:
				b = GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_01;
				break;
			case 71:
				b = GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_02;
				break;
			case 72:
				b = GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_03;
				break;
			case 73:
				b = GFXLibrary.r_building_panel_bld_civ_rel_small_shrines_04;
				break;
			case 74:
				b = GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_01;
				break;
			case 75:
				b = GFXLibrary.r_building_panel_bld_civ_rel_large_shrines_02;
				break;
			case 78:
				b = GFXLibrary.r_building_panel_bld_icon_ind_market;
				if (building.isComplete() && !this.ViewOnly)
				{
					this.inBuildingGenericButton.Visible = true;
					this.inBuildingGenericButton.Text.Text = SK.Text("VillageMapPanel_Transfer", "Transfer");
					this.inBuildingGenericButton2.Visible = true;
					this.inBuildingGenericButton2.Text.Text = SK.Text("VillageMapPanel_Stock_Exchange", "Stock Exchange");
				}
				break;
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
			int num6 = 1;
			if (GameEngine.Instance.World.ThirdAgeWorld)
			{
				num6 = 4;
			}
			switch (this.selectedBuilding.buildingType)
			{
			case 6:
			case 7:
			case 8:
			case 9:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 33:
				if (building.calcRate != 0.0 && building.complete)
				{
					this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_This_Building", "This Building");
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_All", "All");
					this.inBuildingMakeWeaponLabel0.Visible = true;
					this.inBuildingMakeWeaponLabel1.Visible = true;
					this.inBuildingMakeWeaponLabel2.Visible = true;
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
					if (building.calcRate > 0.0)
					{
						double num7 = 86400.0 / building.calcRate;
						double num8 = CardTypes.adjustPayloadSize(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.getPayloadSize(building.buildingType), building.buildingType);
						num7 *= num8;
						this.inBuildingMakeWeaponLabel2.Text = ((int)num7).ToString("N", nfi);
					}
					else
					{
						this.inBuildingMakeWeaponLabel2.Text = "0";
					}
					if (village != null)
					{
						double resourceProductionPerDay = village.getResourceProductionPerDay(building.buildingType);
						this.inBuildingMakeWeaponLabel4.Text = ((int)resourceProductionPerDay).ToString("N", nfi);
					}
				}
				break;
			case 34:
				this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
				this.inBuildingMakeWeaponLabel2.Text = (GameEngine.Instance.LocalWorldData.HonourBuilding_Chapel * (double)num6).ToString();
				this.inBuildingMakeWeaponLabel1.Visible = true;
				this.inBuildingMakeWeaponLabel2.Visible = true;
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				this.inBuildingMakeWeaponLabel4.Text = GameEngine.Instance.LocalWorldData.FaithPoints_Chapel.ToString();
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				break;
			case 36:
				this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
				this.inBuildingMakeWeaponLabel2.Text = (GameEngine.Instance.LocalWorldData.HonourBuilding_Church * (double)num6).ToString();
				this.inBuildingMakeWeaponLabel1.Visible = true;
				this.inBuildingMakeWeaponLabel2.Visible = true;
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				this.inBuildingMakeWeaponLabel4.Text = GameEngine.Instance.LocalWorldData.FaithPoints_Church.ToString();
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				break;
			case 37:
				this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
				this.inBuildingMakeWeaponLabel2.Text = (GameEngine.Instance.LocalWorldData.HonourBuilding_Cathedral * (double)num6).ToString();
				this.inBuildingMakeWeaponLabel1.Visible = true;
				this.inBuildingMakeWeaponLabel2.Visible = true;
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				this.inBuildingMakeWeaponLabel4.Text = GameEngine.Instance.LocalWorldData.FaithPoints_Cathedral.ToString();
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				break;
			case 38:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding2 = village.findBuildingType(0);
					if (villageMapBuilding2 != null)
					{
						double num9 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_SmallGarden, villageMapBuilding2.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num9.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 49:
			case 50:
			case 51:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding3 = village.findBuildingType(0);
					if (villageMapBuilding3 != null)
					{
						double num10 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_LargeGarden, villageMapBuilding3.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num10.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 54:
			case 55:
			case 56:
			case 57:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding4 = village.findBuildingType(0);
					if (villageMapBuilding4 != null)
					{
						double num11 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_SmallStatue, villageMapBuilding4.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num11.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 58:
			case 59:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding5 = village.findBuildingType(0);
					if (villageMapBuilding5 != null)
					{
						double num12 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_LargeStatue, villageMapBuilding5.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num12.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 60:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding6 = village.findBuildingType(0);
					if (villageMapBuilding6 != null)
					{
						double num13 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Dovecote, villageMapBuilding6.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num13.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 61:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Popularity_Penalty", "Popularity Penalty");
				this.inBuildingMakeWeaponLabel4.Text = "-5";
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding7 = village.findBuildingType(0);
					if (villageMapBuilding7 != null)
					{
						double num14 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Stocks, villageMapBuilding7.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num14.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 62:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Popularity_Penalty", "Popularity Penalty");
				this.inBuildingMakeWeaponLabel4.Text = "-5";
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding8 = village.findBuildingType(0);
					if (villageMapBuilding8 != null)
					{
						double num15 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_BurningPost, villageMapBuilding8.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num15.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 63:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Popularity_Penalty", "Popularity Penalty");
				this.inBuildingMakeWeaponLabel4.Text = "-5";
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding9 = village.findBuildingType(0);
					if (villageMapBuilding9 != null)
					{
						double num16 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Gibbet, villageMapBuilding9.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num16.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 64:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Popularity_Penalty", "Popularity Penalty");
				this.inBuildingMakeWeaponLabel4.Text = "-5";
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding10 = village.findBuildingType(0);
					if (villageMapBuilding10 != null)
					{
						double num17 = VillageBuildingsData.calcHonourRateBasedOnDistance(GameEngine.Instance.LocalWorldData.HonourBuilding_Rack, villageMapBuilding10.buildingLocation, building.buildingLocation) * (double)num6;
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Honour_Bonus", "Honour Bonus");
						this.inBuildingMakeWeaponLabel2.Text = num17.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
				if (village != null)
				{
					VillageMapBuilding villageMapBuilding11 = village.findBuildingType(0);
					if (villageMapBuilding11 != null)
					{
						int mapDistance2 = VillageBuildingsData.getMapDistance(villageMapBuilding11.buildingLocation, building.buildingLocation);
						int buildingPopularityBasedOnDistance = VillageBuildingsData.getBuildingPopularityBasedOnDistance(GameEngine.Instance.LocalWorldData, mapDistance2);
						this.inBuildingMakeWeaponLabel1.Text = SK.Text("VillageMapPanel_Popularity_Bonus", "Popularity Bonus");
						this.inBuildingMakeWeaponLabel2.Text = buildingPopularityBasedOnDistance.ToString();
						this.inBuildingMakeWeaponLabel1.Visible = true;
						this.inBuildingMakeWeaponLabel2.Visible = true;
					}
				}
				break;
			case 70:
			case 71:
			case 72:
			case 73:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				this.inBuildingMakeWeaponLabel4.Text = GameEngine.Instance.LocalWorldData.FaithPoints_SmallShrine.ToString();
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				break;
			case 74:
			case 75:
				this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				this.inBuildingMakeWeaponLabel4.Text = GameEngine.Instance.LocalWorldData.FaithPoints_LargeShrine.ToString();
				this.inBuildingMakeWeaponLabel3.Visible = true;
				this.inBuildingMakeWeaponLabel4.Visible = true;
				break;
			}
			if (!VillageBuildingsData.buildingRequiresWorker(building.buildingType))
			{
				this.inBuildingIndustryAllOnButton.Visible = false;
				this.inBuildingIndustryThisOnButton.Visible = false;
				this.inBuildingAllIndustryOnButton.Visible = false;
			}
			else
			{
				this.inBuildingIndustryAllOnButton.Visible = true;
				this.inBuildingIndustryThisOnButton.Visible = true;
				this.inBuildingAllIndustryOnButton.Visible = true;
			}
			if (building.buildingActive)
			{
				this.inBuildingIndustryThisOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_This_Off", "Turn This Off");
				this.inBuildingIndustryAllOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_Off", "Turn All Off");
				this.inBuildingAllIndustryOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_Industries_Off", "Turn All Industries Off");
				this.inBuildingAllIndustryOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllIndustryOnClicked), "VillageMapPanel_all_industry_off");
				this.inBuildingIndustryAllOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllOnClicked), "VillageMapPanel_all_off");
				this.inBuildingIndustryThisOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnThisOnClicked), "VillageMapPanel_this_off");
			}
			else
			{
				this.inBuildingIndustryThisOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_This_On", "Turn This On");
				this.inBuildingIndustryAllOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_On", "Turn All On");
				this.inBuildingAllIndustryOnButton.Text.Text = SK.Text("VillageMapPanel_Turn_All_Industries_On", "Turn All Industries On");
				this.inBuildingAllIndustryOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllIndustryOnClicked), "VillageMapPanel_all_industry_on");
				this.inBuildingIndustryAllOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnAllOnClicked), "VillageMapPanel_all_on");
				this.inBuildingIndustryThisOnButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.turnThisOnClicked), "VillageMapPanel_this_on");
			}
			this.inBuildingCompleteLabel.Visible = false;
			this.inBuildingCompleteLabel2.Visible = false;
			if (!building.isComplete())
			{
				this.inBuildingCompleteLabel.Visible = true;
				this.inBuildingCompleteLabel2.Visible = true;
				this.inBuildingCompleteLabel.Text = SK.Text("VillageMapPanel_Completion_@", "Completion @");
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (building.completionTime.Date == currentServerTime.Date)
				{
					this.inBuildingCompleteLabel2.Text = SK.Text("VillageMapPanel_Today", "Today") + " " + building.completionTime.ToLongTimeString();
				}
				else
				{
					this.inBuildingCompleteLabel2.Text = building.completionTime.ToShortDateString() + " " + building.completionTime.ToLongTimeString();
				}
			}
			else if (building.isDeleting())
			{
				this.inBuildingCompleteLabel.Visible = true;
				this.inBuildingCompleteLabel2.Visible = true;
				this.inBuildingCompleteLabel.Text = SK.Text("VillageMapPanel_Deletion_@", "Deletion @");
				DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
				if (building.deletionTime.Date == currentServerTime2.Date)
				{
					this.inBuildingCompleteLabel2.Text = SK.Text("VillageMapPanel_Today", "Today") + " " + building.deletionTime.ToLongTimeString();
				}
				else
				{
					this.inBuildingCompleteLabel2.Text = building.deletionTime.ToShortDateString() + " " + building.deletionTime.ToLongTimeString();
				}
			}
			this.inBuildingTypeImage.Image = b;
			if (this.ViewOnly || GameEngine.Instance.World.WorldEnded)
			{
				this.inBuildingDeleteButton.Visible = false;
				this.inBuildingIndustryAllOnButton.Visible = false;
				this.inBuildingAllIndustryOnButton.Visible = false;
				this.inBuildingIndustryThisOnButton.Visible = false;
				this.inBuildingGenericButton.Visible = false;
				this.inBuildingGenericButton2.Visible = false;
			}
			if (this.m_villageIsCapital)
			{
				this.inBuildingName.Text = "";
				this.inBuildingCapitalResourceLevelLabel1.Visible = false;
				this.inBuildingCapitalResourceLevelLabel2.Visible = false;
				this.inBuildingCapitalResourceLabel1a.Visible = false;
				this.inBuildingCapitalResourceLabel1b.Visible = false;
				this.inBuildingCapitalResourceLabel1c.Visible = false;
				this.inBuildingCapitalResourceImage1.Visible = false;
				this.inBuildingCapitalResourceLabel2a.Visible = false;
				this.inBuildingCapitalResourceLabel2b.Visible = false;
				this.inBuildingCapitalResourceLabel2c.Visible = false;
				this.inBuildingCapitalResourceImage2.Visible = false;
				this.inBuildingCapitalResourceLabel3a.Visible = false;
				this.inBuildingCapitalResourceLabel3b.Visible = false;
				this.inBuildingCapitalResourceLabel3c.Visible = false;
				this.inBuildingCapitalResourceImage3.Visible = false;
				this.inBuildingCapitalResourceLabel4a.Visible = false;
				this.inBuildingCapitalResourceLabel4b.Visible = false;
				this.inBuildingCapitalResourceLabel4c.Visible = false;
				this.inBuildingCapitalResourceImage4.Visible = false;
				this.inBuildingCapitalResourceLabel5a.Visible = false;
				this.inBuildingCapitalResourceLabel5b.Visible = false;
				this.inBuildingCapitalResourceLabel5c.Visible = false;
				this.inBuildingCapitalResourceImage5.Visible = false;
				this.inBuildingCapitalResourceLabel6a.Visible = false;
				this.inBuildingCapitalResourceLabel6b.Visible = false;
				this.inBuildingCapitalResourceLabel6c.Visible = false;
				this.inBuildingCapitalResourceImage6.Visible = false;
				this.inBuildingCapitalResourceLabel7a.Visible = false;
				this.inBuildingCapitalResourceLabel7b.Visible = false;
				this.inBuildingCapitalResourceLabel7c.Visible = false;
				this.inBuildingCapitalResourceImage7.Visible = false;
				this.inBuildingCapitalResourceLabel8a.Visible = false;
				this.inBuildingCapitalResourceLabel8b.Visible = false;
				this.inBuildingCapitalResourceLabel8c.Visible = false;
				this.inBuildingCapitalResourceImage8.Visible = false;
				if (building.isComplete())
				{
					int num18 = 0;
					if (village.m_parishCapitalResearchData != null)
					{
						num18 = village.m_parishCapitalResearchData.getCapitalResourceFromBuildingType(this.selectedBuilding.buildingType);
					}
					this.inBuildingCapitalResourceLevelLabel2.Text = num18.ToString("N", nfi);
					int num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 0);
					if (num18 < 0)
					{
						num19 = -1;
					}
					if (num19 >= 0)
					{
						this.inBuildingCapitalResourceLevelLabel1.Visible = true;
						this.inBuildingCapitalResourceLevelLabel2.Visible = true;
						this.inBuildingDonateButton.Visible = true;
					}
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length != 0)
					{
						int requiredResourceTypeLevel = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 0, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel > 0)
						{
							this.inBuildingCapitalResourceLabel1a.Visible = true;
							this.inBuildingCapitalResourceLabel1b.Visible = true;
							this.inBuildingCapitalResourceLabel1c.Visible = true;
							this.inBuildingCapitalResourceImage1.Visible = true;
							this.inBuildingCapitalResourceImage1.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel1a.Text = this.selectedBuilding.capitalResourceLevels[0].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel1c.Text = requiredResourceTypeLevel.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 1);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 1)
					{
						int requiredResourceTypeLevel2 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 1, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel2 > 0)
						{
							this.inBuildingCapitalResourceLabel2a.Visible = true;
							this.inBuildingCapitalResourceLabel2b.Visible = true;
							this.inBuildingCapitalResourceLabel2c.Visible = true;
							this.inBuildingCapitalResourceImage2.Visible = true;
							this.inBuildingCapitalResourceImage2.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel2a.Text = this.selectedBuilding.capitalResourceLevels[1].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel2c.Text = requiredResourceTypeLevel2.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 2);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 2)
					{
						int requiredResourceTypeLevel3 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 2, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel3 > 0)
						{
							this.inBuildingCapitalResourceLabel3a.Visible = true;
							this.inBuildingCapitalResourceLabel3b.Visible = true;
							this.inBuildingCapitalResourceLabel3c.Visible = true;
							this.inBuildingCapitalResourceImage3.Visible = true;
							this.inBuildingCapitalResourceImage3.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel3a.Text = this.selectedBuilding.capitalResourceLevels[2].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel3c.Text = requiredResourceTypeLevel3.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 3);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 3)
					{
						int requiredResourceTypeLevel4 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 3, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel4 > 0)
						{
							this.inBuildingCapitalResourceLabel4a.Visible = true;
							this.inBuildingCapitalResourceLabel4b.Visible = true;
							this.inBuildingCapitalResourceLabel4c.Visible = true;
							this.inBuildingCapitalResourceImage4.Visible = true;
							this.inBuildingCapitalResourceImage4.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel4a.Text = this.selectedBuilding.capitalResourceLevels[3].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel4c.Text = requiredResourceTypeLevel4.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 4);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 4)
					{
						int requiredResourceTypeLevel5 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 4, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel5 > 0)
						{
							this.inBuildingCapitalResourceLabel5a.Visible = true;
							this.inBuildingCapitalResourceLabel5b.Visible = true;
							this.inBuildingCapitalResourceLabel5c.Visible = true;
							this.inBuildingCapitalResourceImage5.Visible = true;
							this.inBuildingCapitalResourceImage5.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel5a.Text = this.selectedBuilding.capitalResourceLevels[4].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel5c.Text = requiredResourceTypeLevel5.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 5);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 5)
					{
						int requiredResourceTypeLevel6 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 5, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel6 > 0)
						{
							this.inBuildingCapitalResourceLabel6a.Visible = true;
							this.inBuildingCapitalResourceLabel6b.Visible = true;
							this.inBuildingCapitalResourceLabel6c.Visible = true;
							this.inBuildingCapitalResourceImage6.Visible = true;
							this.inBuildingCapitalResourceImage6.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel6a.Text = this.selectedBuilding.capitalResourceLevels[5].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel6c.Text = requiredResourceTypeLevel6.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 6);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 6)
					{
						int requiredResourceTypeLevel7 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 6, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel7 > 0)
						{
							this.inBuildingCapitalResourceLabel7a.Visible = true;
							this.inBuildingCapitalResourceLabel7b.Visible = true;
							this.inBuildingCapitalResourceLabel7c.Visible = true;
							this.inBuildingCapitalResourceImage7.Visible = true;
							this.inBuildingCapitalResourceImage7.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel7a.Text = this.selectedBuilding.capitalResourceLevels[6].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel7c.Text = requiredResourceTypeLevel7.ToString("N", nfi);
						}
					}
					num19 = VillageBuildingsData.getRequiredResourceType(this.selectedBuilding.buildingType, 7);
					if (num19 >= 0 && this.selectedBuilding.capitalResourceLevels.Length > 7)
					{
						int requiredResourceTypeLevel8 = VillageBuildingsData.getRequiredResourceTypeLevel(this.selectedBuilding.buildingType, 7, num18, GameEngine.Instance.World.ThirdAgeWorld, GameEngine.Instance.World.FourthAgeWorld, GameEngine.Instance.World.FifthAgeWorld, GameEngine.Instance.World.SeventhAgeWorld, GameEngine.Instance.LocalWorldData.EraWorld);
						if (requiredResourceTypeLevel8 > 0)
						{
							this.inBuildingCapitalResourceLabel8a.Visible = true;
							this.inBuildingCapitalResourceLabel8b.Visible = true;
							this.inBuildingCapitalResourceLabel8c.Visible = true;
							this.inBuildingCapitalResourceImage8.Visible = true;
							this.inBuildingCapitalResourceImage8.Image = VillageMapPanel.getSmallResourceIcon(num19);
							this.inBuildingCapitalResourceLabel8a.Text = this.selectedBuilding.capitalResourceLevels[7].ToString("N", nfi);
							this.inBuildingCapitalResourceLabel8c.Text = requiredResourceTypeLevel8.ToString("N", nfi);
						}
					}
				}
			}
			base.Invalidate();
		}

		// Token: 0x06002F39 RID: 12089 RVA: 0x00269AE4 File Offset: 0x00267CE4
		public static BaseImage getSmallResourceIcon(int buildingType)
		{
			switch (buildingType)
			{
			case 6:
				return GFXLibrary.com_16_wood;
			case 7:
				return GFXLibrary.com_16_stone;
			case 8:
				return GFXLibrary.com_16_iron;
			case 9:
				return GFXLibrary.com_16_pitch;
			case 13:
				return GFXLibrary.com_16_apples;
			case 14:
				return GFXLibrary.com_16_bread;
			case 15:
				return GFXLibrary.com_16_veg;
			case 16:
				return GFXLibrary.com_16_meat;
			case 17:
				return GFXLibrary.com_16_cheese;
			case 18:
				return GFXLibrary.com_16_fish;
			case 19:
				return GFXLibrary.com_16_clothing;
			case 21:
				return GFXLibrary.com_16_furniture;
			case 22:
				return GFXLibrary.com_16_venison;
			case 23:
				return GFXLibrary.com_16_salt;
			case 24:
				return GFXLibrary.com_16_spice;
			case 25:
				return GFXLibrary.com_16_silk;
			case 26:
				return GFXLibrary.com_16_metalwork;
			case 28:
				return GFXLibrary.com_16_pikes;
			case 29:
				return GFXLibrary.com_16_bows;
			case 30:
				return GFXLibrary.com_16_swords;
			case 31:
				return GFXLibrary.com_16_armour;
			case 32:
				return GFXLibrary.com_16_catapults;
			case 33:
				return GFXLibrary.com_16_wine;
			}
			return null;
		}

		// Token: 0x06002F3A RID: 12090 RVA: 0x00269BFC File Offset: 0x00267DFC
		private void updateWeaponProductionInfo()
		{
			this.inBuildingMakeWeaponLabel3.Visible = false;
			this.inBuildingMakeWeaponLabel4.Visible = false;
			this.inBuildingMakeWeaponImage1.Visible = false;
			this.inBuildingMakeWeaponImage2.Visible = false;
			this.inBuildingMakeWeaponLabel6.Size = new Size(this.inBuildingPanelImage.Width - 24 - 18, 20);
			VillageMap village = GameEngine.Instance.Village;
			if (this.selectedBuilding == null || village == null)
			{
				return;
			}
			VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
			village.getArmouryLevels(armouryLevels);
			switch (this.selectedBuilding.buildingType)
			{
			case 28:
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.selectedBuilding.buildingType, false);
				num *= CardTypes.getResourceCapMultiplier(this.selectedBuilding.buildingType, GameEngine.Instance.cardsManager.UserCardData);
				if (num <= armouryLevels.pikesLevel)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Armoury_Full", "Armoury Full");
					this.inBuildingMakeWeaponLabel3.Visible = true;
				}
				else if (armouryLevels.pikesLeftToMake > 0 && village.m_productionRate_Pikes > 0.0)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Next_ready", "Next Ready");
					DateTime currentServerTime = VillageMap.getCurrentServerTime();
					DateTime dateTime = village.m_productionEnd_Pikes;
					DateTime dateTime2 = dateTime;
					double num2 = 1.0 / village.m_productionRate_Pikes;
					TimeSpan value = new TimeSpan(0, 0, -(int)num2);
					while (dateTime2 > currentServerTime)
					{
						dateTime = dateTime2;
						dateTime2 = dateTime2.Add(value);
					}
					int num3 = (int)(dateTime - currentServerTime).TotalSeconds;
					if (num3 < 0)
					{
						num3 = 0;
					}
					this.inBuildingMakeWeaponLabel4.Text = VillageMap.createBuildTimeString(num3);
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
				}
				else if (village.m_productionRate_Pikes > 0.0)
				{
					VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels);
					if (stockpileLevels.woodLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Pike)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_wood;
						this.inBuildingMakeWeaponImage1.Visible = true;
					}
				}
				this.inBuildingMakeWeaponLabel5.Visible = true;
				this.inBuildingMakeWeaponLabel6.Text = GameEngine.Instance.LocalWorldData.weaponCost_Pike.ToString();
				this.inBuildingMakeWeaponLabel6.Visible = true;
				this.inBuildingMakeWeaponImage3.Image = GFXLibrary.com_16_wood;
				this.inBuildingMakeWeaponImage3.Visible = true;
				return;
			}
			case 29:
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.selectedBuilding.buildingType, false);
				num *= CardTypes.getResourceCapMultiplier(this.selectedBuilding.buildingType, GameEngine.Instance.cardsManager.UserCardData);
				if (num <= armouryLevels.bowsLevel)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Armoury_Full", "Armoury Full");
					this.inBuildingMakeWeaponLabel3.Visible = true;
				}
				else if (armouryLevels.bowsLeftToMake > 0 && village.m_productionRate_Bows > 0.0)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Next_ready", "Next Ready");
					DateTime currentServerTime2 = VillageMap.getCurrentServerTime();
					DateTime dateTime3 = village.m_productionEnd_Bows;
					DateTime dateTime4 = dateTime3;
					double num4 = 1.0 / village.m_productionRate_Bows;
					TimeSpan value2 = new TimeSpan(0, 0, -(int)num4);
					while (dateTime4 > currentServerTime2)
					{
						dateTime3 = dateTime4;
						dateTime4 = dateTime4.Add(value2);
					}
					int num5 = (int)(dateTime3 - currentServerTime2).TotalSeconds;
					if (num5 < 0)
					{
						num5 = 0;
					}
					this.inBuildingMakeWeaponLabel4.Text = VillageMap.createBuildTimeString(num5);
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
				}
				else if (village.m_productionRate_Bows > 0.0)
				{
					VillageMap.StockpileLevels stockpileLevels2 = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels2);
					if (stockpileLevels2.woodLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Bow)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_wood;
						this.inBuildingMakeWeaponImage1.Visible = true;
					}
				}
				this.inBuildingMakeWeaponLabel5.Visible = true;
				this.inBuildingMakeWeaponLabel6.Text = GameEngine.Instance.LocalWorldData.weaponCost_Bow.ToString();
				this.inBuildingMakeWeaponLabel6.Visible = true;
				this.inBuildingMakeWeaponImage3.Image = GFXLibrary.com_16_wood;
				this.inBuildingMakeWeaponImage3.Visible = true;
				return;
			}
			case 30:
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.selectedBuilding.buildingType, false);
				num *= CardTypes.getResourceCapMultiplier(this.selectedBuilding.buildingType, GameEngine.Instance.cardsManager.UserCardData);
				if (num <= armouryLevels.swordsLevel)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Armoury_Full", "Armoury Full");
					this.inBuildingMakeWeaponLabel3.Visible = true;
				}
				else if (armouryLevels.swordsLeftToMake > 0 && village.m_productionRate_Swords > 0.0)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Next_ready", "Next Ready");
					DateTime currentServerTime3 = VillageMap.getCurrentServerTime();
					DateTime dateTime5 = village.m_productionEnd_Swords;
					DateTime dateTime6 = dateTime5;
					double num6 = 1.0 / village.m_productionRate_Swords;
					TimeSpan value3 = new TimeSpan(0, 0, -(int)num6);
					while (dateTime6 > currentServerTime3)
					{
						dateTime5 = dateTime6;
						dateTime6 = dateTime6.Add(value3);
					}
					int num7 = (int)(dateTime5 - currentServerTime3).TotalSeconds;
					if (num7 < 0)
					{
						num7 = 0;
					}
					this.inBuildingMakeWeaponLabel4.Text = VillageMap.createBuildTimeString(num7);
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
				}
				else if (village.m_productionRate_Swords > 0.0)
				{
					VillageMap.StockpileLevels stockpileLevels3 = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels3);
					if (stockpileLevels3.ironLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Sword)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_iron;
						this.inBuildingMakeWeaponImage1.Visible = true;
					}
				}
				this.inBuildingMakeWeaponLabel5.Visible = true;
				this.inBuildingMakeWeaponLabel6.Text = GameEngine.Instance.LocalWorldData.weaponCost_Sword.ToString();
				this.inBuildingMakeWeaponLabel6.Visible = true;
				this.inBuildingMakeWeaponImage3.Image = GFXLibrary.com_16_iron;
				this.inBuildingMakeWeaponImage3.Visible = true;
				return;
			}
			case 31:
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.selectedBuilding.buildingType, false);
				num *= CardTypes.getResourceCapMultiplier(this.selectedBuilding.buildingType, GameEngine.Instance.cardsManager.UserCardData);
				if (num <= armouryLevels.armourLevel)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Armoury_Full", "Armoury Full");
					this.inBuildingMakeWeaponLabel3.Visible = true;
				}
				else if (armouryLevels.armourLeftToMake > 0 && village.m_productionRate_Armour > 0.0)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Next_ready", "Next Ready");
					DateTime currentServerTime4 = VillageMap.getCurrentServerTime();
					DateTime dateTime7 = village.m_productionEnd_Armour;
					DateTime dateTime8 = dateTime7;
					double num8 = 1.0 / village.m_productionRate_Armour;
					TimeSpan value4 = new TimeSpan(0, 0, -(int)num8);
					while (dateTime8 > currentServerTime4)
					{
						dateTime7 = dateTime8;
						dateTime8 = dateTime8.Add(value4);
					}
					int num9 = (int)(dateTime7 - currentServerTime4).TotalSeconds;
					if (num9 < 0)
					{
						num9 = 0;
					}
					this.inBuildingMakeWeaponLabel4.Text = VillageMap.createBuildTimeString(num9);
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
				}
				else if (village.m_productionRate_Armour > 0.0)
				{
					VillageMap.StockpileLevels stockpileLevels4 = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels4);
					if (stockpileLevels4.ironLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Armour)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_iron;
						this.inBuildingMakeWeaponImage1.Visible = true;
					}
				}
				this.inBuildingMakeWeaponLabel5.Visible = true;
				this.inBuildingMakeWeaponLabel6.Text = GameEngine.Instance.LocalWorldData.weaponCost_Armour.ToString();
				this.inBuildingMakeWeaponLabel6.Visible = true;
				this.inBuildingMakeWeaponImage3.Image = GFXLibrary.com_16_iron;
				this.inBuildingMakeWeaponImage3.Visible = true;
				return;
			}
			case 32:
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.selectedBuilding.buildingType, false);
				num *= CardTypes.getResourceCapMultiplier(this.selectedBuilding.buildingType, GameEngine.Instance.cardsManager.UserCardData);
				if (num <= armouryLevels.catapultsLevel)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Armoury_Full", "Armoury Full");
					this.inBuildingMakeWeaponLabel3.Visible = true;
				}
				else if (armouryLevels.catapultsLeftToMake > 0 && village.m_productionRate_Catapults > 0.0)
				{
					this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Next_ready", "Next Ready");
					DateTime currentServerTime5 = VillageMap.getCurrentServerTime();
					DateTime dateTime9 = village.m_productionEnd_Catapults;
					DateTime dateTime10 = dateTime9;
					double num10 = 1.0 / village.m_productionRate_Catapults;
					TimeSpan value5 = new TimeSpan(0, 0, -(int)num10);
					while (dateTime10 > currentServerTime5)
					{
						dateTime9 = dateTime10;
						dateTime10 = dateTime10.Add(value5);
					}
					int num11 = (int)(dateTime9 - currentServerTime5).TotalSeconds;
					if (num11 < 0)
					{
						num11 = 0;
					}
					this.inBuildingMakeWeaponLabel4.Text = VillageMap.createBuildTimeString(num11);
					this.inBuildingMakeWeaponLabel3.Visible = true;
					this.inBuildingMakeWeaponLabel4.Visible = true;
				}
				else if (village.m_productionRate_Catapults > 0.0)
				{
					VillageMap.StockpileLevels stockpileLevels5 = new VillageMap.StockpileLevels();
					village.getStockpileLevels(stockpileLevels5);
					bool flag = false;
					if (stockpileLevels5.woodLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Catapult)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_wood;
						this.inBuildingMakeWeaponImage1.Visible = true;
						flag = true;
					}
					if (stockpileLevels5.stoneLevel < (double)GameEngine.Instance.LocalWorldData.weaponCost_Catapult2)
					{
						this.inBuildingMakeWeaponLabel3.Text = SK.Text("VillageMapPanel_Requires", "Requires");
						this.inBuildingMakeWeaponLabel3.Visible = true;
						if (!flag)
						{
							this.inBuildingMakeWeaponImage1.Image = GFXLibrary.com_16_stone;
							this.inBuildingMakeWeaponImage1.Visible = true;
						}
						else
						{
							this.inBuildingMakeWeaponImage2.Image = GFXLibrary.com_16_stone;
							this.inBuildingMakeWeaponImage2.Visible = true;
						}
					}
				}
				this.inBuildingMakeWeaponLabel6.Size = new Size(this.inBuildingPanelImage.Width - 24 - 18 - 16, 20);
				this.inBuildingMakeWeaponLabel5.Visible = true;
				this.inBuildingMakeWeaponLabel6.Text = GameEngine.Instance.LocalWorldData.weaponCost_Catapult.ToString();
				this.inBuildingMakeWeaponLabel6.Visible = true;
				this.inBuildingMakeWeaponImage3.Image = GFXLibrary.com_16_stone;
				this.inBuildingMakeWeaponImage3.Visible = true;
				this.inBuildingMakeWeaponImage4.Image = GFXLibrary.com_16_wood;
				this.inBuildingMakeWeaponImage4.Visible = true;
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06002F3B RID: 12091 RVA: 0x00022416 File Offset: 0x00020616
		public bool isInBuildingPanelOpen()
		{
			return this.currentInBuildingHeight != 0;
		}

		// Token: 0x06002F3C RID: 12092 RVA: 0x0026A878 File Offset: 0x00268A78
		public void closeInBuildingPanel()
		{
			this.selectedBuilding = null;
			if (this.targetInBuildingHeight == 0 && this.currentInBuildingHeight == 0)
			{
				this.inBuildingHeaderPanelImage.Visible = false;
				this.inBuildingPanelImage.Visible = false;
			}
			this.targetInBuildingHeight = 0;
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.clearColouredBuildings();
			}
		}

		// Token: 0x06002F3D RID: 12093 RVA: 0x0026A8D8 File Offset: 0x00268AD8
		public void InBuildingPanelUpdate()
		{
			if (GameEngine.Instance.Village == null)
			{
				return;
			}
			if (this.selectedBuilding != null)
			{
				if (!GameEngine.Instance.Village.isValidBuilding(this.selectedBuilding))
				{
					this.closeInBuildingPanel();
				}
				else if (this.inBuildingCompleteLabel.Visible)
				{
					if (!this.selectedBuilding.isDeleting() && this.selectedBuilding.isComplete())
					{
						this.inBuildingCompleteLabel.Visible = false;
						this.inBuildingCompleteLabel2.Visible = false;
					}
				}
				else
				{
					int buildingType = this.selectedBuilding.buildingType;
					if (buildingType - 28 <= 4)
					{
						this.updateWeaponProductionInfo();
					}
				}
			}
			if (!GameEngine.tabPressed)
			{
				return;
			}
			if ((DateTime.Now - this.lastTabScroll).TotalMilliseconds > 500.0 || GameEngine.tabReleased)
			{
				this.lastTabScroll = DateTime.Now;
				VillageMapBuilding villageMapBuilding;
				if (!GameEngine.Instance.GFX.keyControlled)
				{
					StatTrackingClient.Instance().ActivateTrigger(27, true);
					villageMapBuilding = GameEngine.Instance.Village.getNextBuilding(this.selectedBuilding);
				}
				else
				{
					StatTrackingClient.Instance().ActivateTrigger(27, false);
					villageMapBuilding = GameEngine.Instance.Village.getPreviousBuilding(this.selectedBuilding);
				}
				if (villageMapBuilding != null && villageMapBuilding != this.selectedBuilding)
				{
					this.showInBuildingInfo(villageMapBuilding);
				}
			}
			GameEngine.tabReleased = false;
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x0026AA34 File Offset: 0x00268C34
		public void deleteBuildingClick()
		{
			if (GameEngine.Instance.Village == null || VillageMap.isMovingBuilding())
			{
				return;
			}
			if (GameEngine.Instance.World.isCapital(GameEngine.Instance.Village.VillageID))
			{
				if (!(VillageMap.getCurrentServerTime() >= GameEngine.Instance.Village.m_captialNextDelete))
				{
					return;
				}
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				DialogResult dialogResult = (!GameEngine.Instance.World.SecondAgeWorld) ? MyMessageBox.Show(SK.Text("VillageMapPanel_Delete_Area_You_Sure", "Are you sure you want to delete this building?") + Environment.NewLine + Environment.NewLine + SK.Text("VillageMapPanel_Warning_No_Returned_Resources", "Warning this will not return any resources or flags"), SK.Text("VillageMapPanel_Delete_Bulding", "Delete Building"), buts) : MyMessageBox.Show(string.Concat(new string[]
				{
					SK.Text("VillageMapPanel_Delete_Area_You_Sure", "Are you sure you want to delete this building?"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("VillageMapPanel_Warning_No_Returned_Resources", "Warning this will not return any resources or flags"),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("VillageMapPanel_Warning_No_Bonus_Retained", "If this building is deleted, the parish will not retain the bonus or the ability that it confers")
				}), SK.Text("VillageMapPanel_Delete_Bulding", "Delete Building"), buts);
				if (dialogResult != DialogResult.Yes)
				{
					return;
				}
			}
			if (!this.selectedBuilding.isDeleting())
			{
				if (GameEngine.Instance.Village.getNumDeleting() < 3)
				{
					GameEngine.Instance.Village.deleteBuilding(this.selectedBuilding);
				}
			}
			else
			{
				GameEngine.Instance.Village.cancelDeleteBuilding(this.selectedBuilding);
			}
			this.inBuildingDeleteButton.Visible = false;
			this.showInBuildingInfo(null);
		}

		// Token: 0x06002F3F RID: 12095 RVA: 0x0026ABC8 File Offset: 0x00268DC8
		public void donateClick()
		{
			if (GameEngine.Instance.Village != null)
			{
				Sound.stopVillageEnvironmental();
				InterfaceMgr.Instance.setVillageTabSubMode(1021);
				InterfaceMgr.Instance.capitalDonateResourcesInit(GameEngine.Instance.Village.VillageID, this.selectedBuilding);
			}
		}

		// Token: 0x06002F40 RID: 12096 RVA: 0x00022423 File Offset: 0x00020623
		private void moveBuildingClick()
		{
			if (GameEngine.Instance.Village != null && this.selectedBuilding != null)
			{
				GameEngine.Instance.Village.startMoveBuildings(this.selectedBuilding);
			}
		}

		// Token: 0x06002F41 RID: 12097 RVA: 0x0002244E File Offset: 0x0002064E
		private void inBuildngClicked()
		{
			this.closeInBuildingPanel();
		}

		// Token: 0x06002F42 RID: 12098 RVA: 0x00022456 File Offset: 0x00020656
		private void inBuildngMouseOver()
		{
			this.inBuildingHeaderPanelImage.Image = GFXLibrary.r_building_bar_building_info_over;
		}

		// Token: 0x06002F43 RID: 12099 RVA: 0x0002246D File Offset: 0x0002066D
		private void inBuildngMouseLeave()
		{
			this.inBuildingHeaderPanelImage.Image = GFXLibrary.r_building_bar_building_info_norm;
		}

		// Token: 0x06002F44 RID: 12100 RVA: 0x00022484 File Offset: 0x00020684
		private void stopIndustryResend()
		{
			this.inBuildingAllIndustryOnButton.Enabled = false;
			this.inBuildingIndustryAllOnButton.Enabled = false;
			this.inBuildingIndustryThisOnButton.Enabled = false;
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x000224AA File Offset: 0x000206AA
		public void stopIndustryEnabled()
		{
			this.inBuildingAllIndustryOnButton.Enabled = true;
			this.inBuildingIndustryAllOnButton.Enabled = true;
			this.inBuildingIndustryThisOnButton.Enabled = true;
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x000224D0 File Offset: 0x000206D0
		private void turnAllOffClicked()
		{
			if (GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 0);
			}
			this.showInBuildingInfo(this.selectedBuilding);
			this.stopIndustryResend();
		}

		// Token: 0x06002F47 RID: 12103 RVA: 0x0026AC14 File Offset: 0x00268E14
		private void turnAllIndustryOnClicked()
		{
			if (!this.selectedBuilding.buildingActive)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 5);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			else
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 4);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			this.stopIndustryResend();
		}

		// Token: 0x06002F48 RID: 12104 RVA: 0x0026AC94 File Offset: 0x00268E94
		private void turnAllOnClicked()
		{
			if (!this.selectedBuilding.buildingActive)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 1);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			else
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 0);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			this.stopIndustryResend();
		}

		// Token: 0x06002F49 RID: 12105 RVA: 0x00022506 File Offset: 0x00020706
		private void turnThisOffClicked()
		{
			if (this.selectedBuilding.buildingActive)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 2);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
		}

		// Token: 0x06002F4A RID: 12106 RVA: 0x0026AD14 File Offset: 0x00268F14
		private void turnThisOnClicked()
		{
			if (!this.selectedBuilding.buildingActive)
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 3);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			else
			{
				if (GameEngine.Instance.Village != null)
				{
					GameEngine.Instance.Village.changeBuildngActivity(this.selectedBuilding, 2);
				}
				this.showInBuildingInfo(this.selectedBuilding);
			}
			this.stopIndustryResend();
		}

		// Token: 0x06002F4B RID: 12107 RVA: 0x0026AD94 File Offset: 0x00268F94
		private void genericButtonClicked()
		{
			Sound.stopVillageEnvironmental();
			if (this.selectedBuilding.buildingType == 2 || this.selectedBuilding.buildingType == 3 || this.selectedBuilding.buildingType == 35)
			{
				InterfaceMgr.Instance.setVillageTabSubMode(5);
				return;
			}
			if (this.selectedBuilding.buildingType == 78)
			{
				InterfaceMgr.Instance.setVillageTabSubMode(2);
				return;
			}
			if (this.selectedBuilding.buildingType == 0)
			{
				InterfaceMgr.Instance.setVillageTabSubMode(1);
			}
		}

		// Token: 0x06002F4C RID: 12108 RVA: 0x00022543 File Offset: 0x00020743
		private void genericButtonClicked2()
		{
			Sound.stopVillageEnvironmental();
			if (this.selectedBuilding.buildingType == 78)
			{
				InterfaceMgr.Instance.setVillageTabSubMode(3);
				return;
			}
			if (this.selectedBuilding.buildingType == 0)
			{
				InterfaceMgr.Instance.setVillageTabSubMode(5);
			}
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x0026AE10 File Offset: 0x00269010
		public void showNewInterface()
		{
			this.closeInBuildingPanel();
			this.closeBuildingPanel();
			this.closePopularityPanel();
			this.closeInfo1Panel();
			this.showExtras();
			this.currentEventID = 0;
			this.currentHeight = 1;
			this.currentInBuildingHeight = 1;
			this.currentExtensionHeight = 1;
			this.currentBuildingHeight = 1;
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x0002257D File Offset: 0x0002077D
		public void helpClicked()
		{
			if (this.currentSelectedBuildingType >= 0)
			{
				CapitalHelpBox.openHelpBox(this.currentSelectedBuildingType);
			}
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x0026AE60 File Offset: 0x00269060
		public void showAsVillage(bool asVillage)
		{
			this.m_villageIsCapital = !asVillage;
			this.panelImage.Visible = asVillage;
			this.headerImage.Visible = asVillage;
			this.extensionImage.Visible = asVillage;
			this.buildPanelImage.Visible = true;
			this.buildHeaderArea.Visible = true;
			this.info1HeaderPanelImage.Visible = asVillage;
			this.info1HeaderHonourImage.Visible = asVillage;
			this.info1PanelImage.Visible = asVillage;
			this.info2HeaderPanelImage.Visible = asVillage;
			this.info3HeaderPanelImage.Visible = asVillage;
			this.inBuildingHeaderPanelImage.Visible = false;
			this.inBuildingPanelImage.Visible = false;
			this.capitalPanelImage.Visible = !asVillage;
			this.capitalTop10PanelImage.Visible = !asVillage;
			this.capitalTop10HeaderImage.Visible = !asVillage;
			this.capitalTaxLowerButton.Enabled = true;
			this.capitalTaxHigherButton.Enabled = true;
			if (!asVillage)
			{
				if (!GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.getSelectedMenuVillage()))
				{
					this.capitalTaxLowerButton.Enabled = false;
					this.capitalTaxHigherButton.Enabled = false;
					this.buildPanelImage.Visible = false;
					this.buildHeaderArea.Visible = false;
				}
				this.buildGoldImage.Position = new Point(13, 40);
				this.buildGoldLabel.Position = new Point(40, 44);
				this.buildWoodImage.Visible = false;
				this.buildStoneImage.Image = GFXLibrary.flag_blue_icon;
				this.inBuildingCapitalResourceLevelLabel1.Visible = true;
				this.inBuildingCapitalResourceLevelLabel2.Visible = true;
			}
			else
			{
				this.buildGoldImage.Position = new Point(86, 40);
				this.buildGoldLabel.Position = new Point(113, 44);
				this.buildWoodImage.Visible = true;
				this.buildStoneImage.Image = GFXLibrary.r_building_panel_inset_icon_stone;
				this.inBuildingCapitalResourceLevelLabel1.Visible = false;
				this.inBuildingCapitalResourceLevelLabel2.Visible = false;
			}
			this.inBuildingCapitalResourceLevelLabel1.Visible = false;
			this.inBuildingCapitalResourceLevelLabel2.Visible = false;
			this.inBuildingCapitalResourceLabel1a.Visible = false;
			this.inBuildingCapitalResourceLabel1b.Visible = false;
			this.inBuildingCapitalResourceLabel1c.Visible = false;
			this.inBuildingCapitalResourceImage1.Visible = false;
			this.inBuildingCapitalResourceLabel2a.Visible = false;
			this.inBuildingCapitalResourceLabel2b.Visible = false;
			this.inBuildingCapitalResourceLabel2c.Visible = false;
			this.inBuildingCapitalResourceImage2.Visible = false;
			this.inBuildingCapitalResourceLabel3a.Visible = false;
			this.inBuildingCapitalResourceLabel3b.Visible = false;
			this.inBuildingCapitalResourceLabel3c.Visible = false;
			this.inBuildingCapitalResourceImage3.Visible = false;
			this.inBuildingCapitalResourceLabel4a.Visible = false;
			this.inBuildingCapitalResourceLabel4b.Visible = false;
			this.inBuildingCapitalResourceLabel4c.Visible = false;
			this.inBuildingCapitalResourceImage4.Visible = false;
			this.inBuildingCapitalResourceLabel5a.Visible = false;
			this.inBuildingCapitalResourceLabel5b.Visible = false;
			this.inBuildingCapitalResourceLabel5c.Visible = false;
			this.inBuildingCapitalResourceImage5.Visible = false;
			this.inBuildingCapitalResourceLabel6a.Visible = false;
			this.inBuildingCapitalResourceLabel6b.Visible = false;
			this.inBuildingCapitalResourceLabel6c.Visible = false;
			this.inBuildingCapitalResourceImage6.Visible = false;
			this.inBuildingCapitalResourceLabel7a.Visible = false;
			this.inBuildingCapitalResourceLabel7b.Visible = false;
			this.inBuildingCapitalResourceLabel7c.Visible = false;
			this.inBuildingCapitalResourceImage7.Visible = false;
			this.inBuildingCapitalResourceLabel8a.Visible = false;
			this.inBuildingCapitalResourceLabel8b.Visible = false;
			this.inBuildingCapitalResourceLabel8c.Visible = false;
			this.inBuildingCapitalResourceImage8.Visible = false;
		}

		// Token: 0x06002F50 RID: 12112 RVA: 0x0026B1FC File Offset: 0x002693FC
		public void initCapitalPanel()
		{
			this.capitalPanelImage.Image = GFXLibrary.int_tax_panel_back_semipopulated;
			this.capitalPanelImage.Position = new Point(0, 0);
			base.addControl(this.capitalPanelImage);
			this.capitalTaxLowerButton.ImageNorm = GFXLibrary.r_popularity_panel_but_minus_norm;
			this.capitalTaxLowerButton.ImageOver = GFXLibrary.r_popularity_panel_but_minus_over;
			this.capitalTaxLowerButton.ImageClick = GFXLibrary.r_popularity_panel_but_minus_in;
			this.capitalTaxLowerButton.Position = new Point(132, 8);
			this.capitalTaxLowerButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.capitalTaxLowerClicked), "VillageMapPanel_capital_tax_lower");
			this.capitalPanelImage.addControl(this.capitalTaxLowerButton);
			this.capitalTaxHigherButton.ImageNorm = GFXLibrary.r_popularity_panel_but_plus_norm;
			this.capitalTaxHigherButton.ImageOver = GFXLibrary.r_popularity_panel_but_plus_over;
			this.capitalTaxHigherButton.ImageClick = GFXLibrary.r_popularity_panel_but_plus_in;
			this.capitalTaxHigherButton.Position = new Point(156, 8);
			this.capitalTaxHigherButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.capitalTaxHigherClicked), "VillageMapPanel_capital_tax_higher");
			this.capitalPanelImage.addControl(this.capitalTaxHigherButton);
			this.capitalTaxLine1Label.Text = "0";
			this.capitalTaxLine1Label.Color = global::ARGBColors.Black;
			this.capitalTaxLine1Label.Position = new Point(38, 16);
			this.capitalTaxLine1Label.Size = new Size(80, 20);
			this.capitalTaxLine1Label.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.capitalTaxLine1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.capitalPanelImage.addControl(this.capitalTaxLine1Label);
			this.capitalTaxBar.setImages(GFXLibrary.r_popularity_panel_colorbar_green_back, GFXLibrary.r_popularity_panel_colorbar_green_bar_left, GFXLibrary.r_popularity_panel_colorbar_green_bar_mid, GFXLibrary.r_popularity_panel_colorbar_green_bar_right, GFXLibrary.r_popularity_panel_colorbar_red_back, GFXLibrary.r_popularity_panel_colorbar_red_bar_left, GFXLibrary.r_popularity_panel_colorbar_red_bar_mid, GFXLibrary.r_popularity_panel_colorbar_red_bar_right);
			this.capitalTaxBar.Number = 0.0;
			this.capitalTaxBar.MaxValue = 9.0;
			this.capitalTaxBar.Position = new Point(135, 31);
			this.capitalPanelImage.addControl(this.capitalTaxBar);
			this.capitalTaxPerDayLabel.Text = SK.Text("VillageMapPanel_Tithe_Per_Day", "Tithe Per Day") + ":";
			this.capitalTaxPerDayLabel.Color = global::ARGBColors.Black;
			this.capitalTaxPerDayLabel.Position = new Point(20, 62);
			this.capitalTaxPerDayLabel.Size = new Size(167, 17);
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.capitalTaxPerDayLabel.Font = FontManager.GetFont("Arial", 7.5f);
			}
			else
			{
				this.capitalTaxPerDayLabel.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.capitalPanelImage.addControl(this.capitalTaxPerDayLabel);
			this.capitalTaxPerDayValueLabel.Text = "0";
			this.capitalTaxPerDayValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxPerDayValueLabel.Position = new Point(100, 62);
			this.capitalTaxPerDayValueLabel.Size = new Size(177 - this.capitalTaxPerDayValueLabel.X - 10, 17);
			this.capitalTaxPerDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalPanelImage.addControl(this.capitalTaxPerDayValueLabel);
			this.capitalLastTaxRateLabel.Text = SK.Text("VillageMapPanel_Yesterdays_Tithe", "Yesterday's Tithe Rate") + ":";
			this.capitalLastTaxRateLabel.Color = global::ARGBColors.Black;
			this.capitalLastTaxRateLabel.Position = new Point(20, 81);
			this.capitalLastTaxRateLabel.Size = new Size(167, 17);
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.capitalLastTaxRateLabel.Font = FontManager.GetFont("Arial", 7.5f);
			}
			else
			{
				this.capitalLastTaxRateLabel.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.capitalPanelImage.addControl(this.capitalLastTaxRateLabel);
			this.capitalLastTaxRateValueLabel.Text = "";
			this.capitalLastTaxRateValueLabel.Color = global::ARGBColors.Black;
			this.capitalLastTaxRateValueLabel.Position = new Point(100, 81);
			this.capitalLastTaxRateValueLabel.Size = new Size(177 - this.capitalLastTaxRateValueLabel.X - 10, 17);
			this.capitalLastTaxRateValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalPanelImage.addControl(this.capitalLastTaxRateValueLabel);
			this.capitalOutgoingPerDayLabel.Text = SK.Text("VillageMapPanel_County_Tithe", "County Tithe") + ":";
			this.capitalOutgoingPerDayLabel.Color = global::ARGBColors.Black;
			this.capitalOutgoingPerDayLabel.Position = new Point(20, 100);
			this.capitalOutgoingPerDayLabel.Size = new Size(167, 17);
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.capitalOutgoingPerDayLabel.Font = FontManager.GetFont("Arial", 7.5f);
			}
			else
			{
				this.capitalOutgoingPerDayLabel.Font = FontManager.GetFont("Arial", 8.25f);
			}
			this.capitalPanelImage.addControl(this.capitalOutgoingPerDayLabel);
			this.capitalOutgoingPerDayValueLabel.Text = "0";
			this.capitalOutgoingPerDayValueLabel.Color = global::ARGBColors.Red;
			this.capitalOutgoingPerDayValueLabel.Position = new Point(100, 100);
			this.capitalOutgoingPerDayValueLabel.Size = new Size(177 - this.capitalOutgoingPerDayValueLabel.X - 10, 17);
			this.capitalOutgoingPerDayValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalPanelImage.addControl(this.capitalOutgoingPerDayValueLabel);
			this.capitalTop10PanelImage.Image = GFXLibrary.r_popularity_panel_back;
			this.capitalTop10PanelImage.Position = new Point(0, 295);
			base.addControl(this.capitalTop10PanelImage);
			this.capitalTop10HeaderImage.Image = GFXLibrary.r_building_bar_building_info_norm;
			this.capitalTop10HeaderImage.Position = new Point(0, 270);
			this.capitalTop10HeaderImage.setMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.topGiversMouseOver), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.topGiversMouseLeave));
			this.capitalTop10HeaderImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.openTopGivers));
			base.addControl(this.capitalTop10HeaderImage);
			this.capitalTop10HeaderGlowImage.Image = GFXLibrary.infobar_02_over;
			this.capitalTop10HeaderGlowImage.Position = new Point(0, 0);
			this.capitalTop10HeaderGlowImage.Visible = false;
			this.capitalTop10HeaderImage.addControl(this.capitalTop10HeaderGlowImage);
			this.capitalTaxTopGivers.Text = SK.Text("VillageMapPanel_Top_Givers", "Top Tax Payers");
			this.capitalTaxTopGivers.Color = global::ARGBColors.Black;
			this.capitalTaxTopGivers.Position = new Point(0, -5);
			this.capitalTaxTopGivers.Size = this.capitalTop10HeaderImage.Size;
			this.capitalTaxTopGivers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.capitalTaxTopGivers.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.capitalTop10HeaderImage.addControl(this.capitalTaxTopGivers);
			this.capitalTaxGiver1Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver1Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver1Label.Position = new Point(20, 113);
			this.capitalTaxGiver1Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver1Label);
			this.capitalTaxGiver1ValueLabel.Text = "0";
			this.capitalTaxGiver1ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver1ValueLabel.Position = new Point(100, 113);
			this.capitalTaxGiver1ValueLabel.Size = new Size(177 - this.capitalTaxGiver1ValueLabel.X - 10, 17);
			this.capitalTaxGiver1ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver1ValueLabel);
			this.capitalTaxGiver2Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver2Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver2Label.Position = new Point(20, 130);
			this.capitalTaxGiver2Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver2Label);
			this.capitalTaxGiver2ValueLabel.Text = "0";
			this.capitalTaxGiver2ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver2ValueLabel.Position = new Point(100, 130);
			this.capitalTaxGiver2ValueLabel.Size = new Size(177 - this.capitalTaxGiver2ValueLabel.X - 10, 17);
			this.capitalTaxGiver2ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver2ValueLabel);
			this.capitalTaxGiver3Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver3Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver3Label.Position = new Point(20, 147);
			this.capitalTaxGiver3Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver3Label);
			this.capitalTaxGiver3ValueLabel.Text = "0";
			this.capitalTaxGiver3ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver3ValueLabel.Position = new Point(100, 147);
			this.capitalTaxGiver3ValueLabel.Size = new Size(177 - this.capitalTaxGiver3ValueLabel.X - 10, 17);
			this.capitalTaxGiver3ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver3ValueLabel);
			this.capitalTaxGiver4Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver4Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver4Label.Position = new Point(20, 164);
			this.capitalTaxGiver4Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver4Label);
			this.capitalTaxGiver4ValueLabel.Text = "0";
			this.capitalTaxGiver4ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver4ValueLabel.Position = new Point(100, 164);
			this.capitalTaxGiver4ValueLabel.Size = new Size(177 - this.capitalTaxGiver4ValueLabel.X - 10, 17);
			this.capitalTaxGiver4ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver4ValueLabel);
			this.capitalTaxGiver5Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver5Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver5Label.Position = new Point(20, 181);
			this.capitalTaxGiver5Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver5Label);
			this.capitalTaxGiver5ValueLabel.Text = "0";
			this.capitalTaxGiver5ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver5ValueLabel.Position = new Point(100, 181);
			this.capitalTaxGiver5ValueLabel.Size = new Size(177 - this.capitalTaxGiver5ValueLabel.X - 10, 17);
			this.capitalTaxGiver5ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver5ValueLabel);
			this.capitalTaxGiver6Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver6Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver6Label.Position = new Point(20, 198);
			this.capitalTaxGiver6Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver6Label);
			this.capitalTaxGiver6ValueLabel.Text = "0";
			this.capitalTaxGiver6ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver6ValueLabel.Position = new Point(100, 198);
			this.capitalTaxGiver6ValueLabel.Size = new Size(177 - this.capitalTaxGiver6ValueLabel.X - 10, 17);
			this.capitalTaxGiver6ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver6ValueLabel);
			this.capitalTaxGiver7Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver7Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver7Label.Position = new Point(20, 215);
			this.capitalTaxGiver7Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver7Label);
			this.capitalTaxGiver7ValueLabel.Text = "0";
			this.capitalTaxGiver7ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver7ValueLabel.Position = new Point(100, 215);
			this.capitalTaxGiver7ValueLabel.Size = new Size(177 - this.capitalTaxGiver7ValueLabel.X - 10, 17);
			this.capitalTaxGiver7ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver7ValueLabel);
			this.capitalTaxGiver8Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver8Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver8Label.Position = new Point(20, 232);
			this.capitalTaxGiver8Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver8Label);
			this.capitalTaxGiver8ValueLabel.Text = "0";
			this.capitalTaxGiver8ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver8ValueLabel.Position = new Point(100, 232);
			this.capitalTaxGiver8ValueLabel.Size = new Size(177 - this.capitalTaxGiver8ValueLabel.X - 10, 17);
			this.capitalTaxGiver8ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver8ValueLabel);
			this.capitalTaxGiver9Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver9Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver9Label.Position = new Point(20, 249);
			this.capitalTaxGiver9Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver9Label);
			this.capitalTaxGiver9ValueLabel.Text = "0";
			this.capitalTaxGiver9ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver9ValueLabel.Position = new Point(100, 249);
			this.capitalTaxGiver9ValueLabel.Size = new Size(177 - this.capitalTaxGiver9ValueLabel.X - 10, 17);
			this.capitalTaxGiver9ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver9ValueLabel);
			this.capitalTaxGiver10Label.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.capitalTaxGiver10Label.Color = global::ARGBColors.Black;
			this.capitalTaxGiver10Label.Position = new Point(20, 266);
			this.capitalTaxGiver10Label.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver10Label);
			this.capitalTaxGiver10ValueLabel.Text = "0";
			this.capitalTaxGiver10ValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiver10ValueLabel.Position = new Point(100, 266);
			this.capitalTaxGiver10ValueLabel.Size = new Size(177 - this.capitalTaxGiver10ValueLabel.X - 10, 17);
			this.capitalTaxGiver10ValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiver10ValueLabel);
			this.capitalTaxGiverOthersLabel.Text = SK.Text("VillageMapPanel_Others", "Others");
			this.capitalTaxGiverOthersLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiverOthersLabel.Position = new Point(20, 295);
			this.capitalTaxGiverOthersLabel.Size = new Size(167, 17);
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiverOthersLabel);
			this.capitalTaxGiverOthersValueLabel.Text = "0";
			this.capitalTaxGiverOthersValueLabel.Color = global::ARGBColors.Black;
			this.capitalTaxGiverOthersValueLabel.Position = new Point(100, 295);
			this.capitalTaxGiverOthersValueLabel.Size = new Size(177 - this.capitalTaxGiverOthersValueLabel.X - 10, 17);
			this.capitalTaxGiverOthersValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.capitalTop10PanelImage.addControl(this.capitalTaxGiverOthersValueLabel);
			this.capitalTop10PanelFaderImage.Image = GFXLibrary.r_popularity_panel_back;
			this.capitalTop10PanelFaderImage.Position = new Point(0, 0);
			this.capitalTop10PanelFaderImage.Alpha = 0f;
			this.capitalTop10PanelImage.addControl(this.capitalTop10PanelFaderImage);
			this.showCapitalData(0, 0, null, 0, 0);
		}

		// Token: 0x06002F51 RID: 12113 RVA: 0x0026C38C File Offset: 0x0026A58C
		private void openTopGivers()
		{
			this.closeBuildingPanel();
			this.closeInBuildingPanel();
			if (this.currentTopGiversHeight == 0)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_top_10");
				this.targetTopGiversHeight = 335;
				return;
			}
			if (this.currentTopGiversHeight == 335)
			{
				GameEngine.Instance.playInterfaceSound("VillageMapPanel_top_10_close");
				this.closeTopGivers();
			}
		}

		// Token: 0x06002F52 RID: 12114 RVA: 0x00022593 File Offset: 0x00020793
		private void closeTopGivers()
		{
			this.targetTopGiversHeight = 0;
		}

		// Token: 0x06002F53 RID: 12115 RVA: 0x0002259C File Offset: 0x0002079C
		private void topGiversMouseOver()
		{
			this.capitalTop10HeaderGlowImage.Visible = true;
		}

		// Token: 0x06002F54 RID: 12116 RVA: 0x000225AA File Offset: 0x000207AA
		private void topGiversMouseLeave()
		{
			this.capitalTop10HeaderGlowImage.Visible = false;
		}

		// Token: 0x06002F55 RID: 12117 RVA: 0x0026C3EC File Offset: 0x0026A5EC
		public CustomSelfDrawPanel.CSDLabel getCapitalNameLabel(int index)
		{
			switch (index)
			{
			case 0:
				return this.capitalTaxGiver1Label;
			case 1:
				return this.capitalTaxGiver2Label;
			case 2:
				return this.capitalTaxGiver3Label;
			case 3:
				return this.capitalTaxGiver4Label;
			case 4:
				return this.capitalTaxGiver5Label;
			case 5:
				return this.capitalTaxGiver6Label;
			case 6:
				return this.capitalTaxGiver7Label;
			case 7:
				return this.capitalTaxGiver8Label;
			case 8:
				return this.capitalTaxGiver9Label;
			case 9:
				return this.capitalTaxGiver10Label;
			default:
				return this.capitalTaxGiverOthersLabel;
			}
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x0026C478 File Offset: 0x0026A678
		public CustomSelfDrawPanel.CSDLabel getCapitalValueLabel(int index)
		{
			switch (index)
			{
			case 0:
				return this.capitalTaxGiver1ValueLabel;
			case 1:
				return this.capitalTaxGiver2ValueLabel;
			case 2:
				return this.capitalTaxGiver3ValueLabel;
			case 3:
				return this.capitalTaxGiver4ValueLabel;
			case 4:
				return this.capitalTaxGiver5ValueLabel;
			case 5:
				return this.capitalTaxGiver6ValueLabel;
			case 6:
				return this.capitalTaxGiver7ValueLabel;
			case 7:
				return this.capitalTaxGiver8ValueLabel;
			case 8:
				return this.capitalTaxGiver9ValueLabel;
			case 9:
				return this.capitalTaxGiver10ValueLabel;
			default:
				return this.capitalTaxGiverOthersValueLabel;
			}
		}

		// Token: 0x06002F57 RID: 12119 RVA: 0x0026C504 File Offset: 0x0026A704
		public void showCapitalData(int taxSetting, int parishTax, ParishTaxCalc[] parishTaxPeople, int parentCapitalTaxRate, int lastCapitalTaxRate)
		{
			if (GameEngine.Instance.LocalWorldData != null)
			{
				int alternate_Ruleset = GameEngine.Instance.LocalWorldData.Alternate_Ruleset;
			}
			this.capitalTaxBar.Number = (double)taxSetting;
			switch (taxSetting)
			{
			case -3:
				this.capitalTaxLine1Label.Text = "x-3";
				break;
			case -2:
				this.capitalTaxLine1Label.Text = "x-2";
				break;
			case -1:
				this.capitalTaxLine1Label.Text = "x-1";
				break;
			case 0:
				this.capitalTaxLine1Label.Text = "0";
				break;
			case 1:
				this.capitalTaxLine1Label.Text = "x1";
				break;
			case 2:
				this.capitalTaxLine1Label.Text = "x2";
				break;
			case 3:
				this.capitalTaxLine1Label.Text = "x3";
				break;
			case 4:
				this.capitalTaxLine1Label.Text = "x4";
				break;
			case 5:
				this.capitalTaxLine1Label.Text = "x5";
				break;
			case 6:
				this.capitalTaxLine1Label.Text = "x6";
				break;
			case 7:
				this.capitalTaxLine1Label.Text = "x7";
				break;
			case 8:
				this.capitalTaxLine1Label.Text = "x8";
				break;
			case 9:
				this.capitalTaxLine1Label.Text = "x9";
				break;
			default:
				this.capitalTaxLine1Label.Text = "x" + taxSetting.ToString();
				break;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			this.capitalTaxPerDayValueLabel.Text = parishTax.ToString("N", nfi);
			switch (lastCapitalTaxRate)
			{
			case -3:
				this.capitalLastTaxRateValueLabel.Text = "x-3";
				break;
			case -2:
				this.capitalLastTaxRateValueLabel.Text = "x-2";
				break;
			case -1:
				this.capitalLastTaxRateValueLabel.Text = "x-1";
				break;
			case 0:
				this.capitalLastTaxRateValueLabel.Text = "0";
				break;
			case 1:
				this.capitalLastTaxRateValueLabel.Text = "x1";
				break;
			case 2:
				this.capitalLastTaxRateValueLabel.Text = "x2";
				break;
			case 3:
				this.capitalLastTaxRateValueLabel.Text = "x3";
				break;
			case 4:
				this.capitalLastTaxRateValueLabel.Text = "x4";
				break;
			case 5:
				this.capitalLastTaxRateValueLabel.Text = "x5";
				break;
			case 6:
				this.capitalLastTaxRateValueLabel.Text = "x6";
				break;
			case 7:
				this.capitalLastTaxRateValueLabel.Text = "x7";
				break;
			case 8:
				this.capitalLastTaxRateValueLabel.Text = "x8";
				break;
			case 9:
				this.capitalLastTaxRateValueLabel.Text = "x9";
				break;
			default:
				this.capitalLastTaxRateValueLabel.Text = "x" + lastCapitalTaxRate.ToString();
				break;
			}
			for (int i = 0; i < 11; i++)
			{
				CustomSelfDrawPanel.CSDLabel capitalNameLabel = this.getCapitalNameLabel(i);
				CustomSelfDrawPanel.CSDLabel capitalValueLabel = this.getCapitalValueLabel(i);
				capitalNameLabel.Visible = false;
				capitalValueLabel.Visible = false;
			}
			List<ParishTaxCalc> list = new List<ParishTaxCalc>();
			if (parishTaxPeople != null)
			{
				foreach (ParishTaxCalc item in parishTaxPeople)
				{
					list.Add(item);
				}
			}
			if (taxSetting > 0)
			{
				list.Sort(this.parishTaxComparerPositive);
				this.capitalTaxTopGivers.Text = SK.Text("VillageMapPanel_Top_Givers", "Top Tax Payers");
			}
			else if (taxSetting < 0)
			{
				list.Sort(this.parishTaxComparerNegative);
				this.capitalTaxTopGivers.Text = SK.Text("VillageMapPanel_Top_Receivers", "Top Receivers");
			}
			else
			{
				this.capitalTaxTopGivers.Text = SK.Text("VillageMapPanel_Parish_Members", "Parish Members");
			}
			int num = 0;
			while (num < 10 && num < list.Count)
			{
				CustomSelfDrawPanel.CSDLabel capitalNameLabel2 = this.getCapitalNameLabel(num);
				CustomSelfDrawPanel.CSDLabel capitalValueLabel2 = this.getCapitalValueLabel(num);
				capitalNameLabel2.Visible = true;
				capitalValueLabel2.Visible = true;
				ParishTaxCalc parishTaxCalc = list[num];
				capitalNameLabel2.Text = parishTaxCalc.userName;
				int num2 = parishTaxCalc.tax;
				if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
				{
					num2 *= 2;
				}
				if (num2 >= 0)
				{
					capitalValueLabel2.Text = num2.ToString("N", nfi);
				}
				else
				{
					capitalValueLabel2.Text = (-num2).ToString("N", nfi);
				}
				num++;
			}
			if (list.Count > 10)
			{
				int num3 = 0;
				for (int k = 10; k < list.Count; k++)
				{
					ParishTaxCalc parishTaxCalc2 = list[k];
					int num4 = parishTaxCalc2.tax;
					if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
					{
						num4 *= 2;
					}
					num3 += num4;
				}
				CustomSelfDrawPanel.CSDLabel capitalNameLabel3 = this.getCapitalNameLabel(10);
				CustomSelfDrawPanel.CSDLabel capitalValueLabel3 = this.getCapitalValueLabel(10);
				capitalNameLabel3.Visible = true;
				capitalValueLabel3.Visible = true;
				capitalValueLabel3.Text = num3.ToString("N", nfi);
			}
			if (GameEngine.Instance.World.isRegionCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				this.capitalTop10PanelImage.Visible = true;
				this.capitalTop10HeaderImage.Visible = true;
				this.capitalOutgoingPerDayLabel.Text = SK.Text("VillageMapPanel_County_Tithe", "County Tithe") + ":";
				this.capitalOutgoingPerDayLabel.Visible = true;
				this.capitalOutgoingPerDayValueLabel.Visible = true;
				int num5 = -(parentCapitalTaxRate * GameEngine.Instance.LocalWorldData.BaseTaxForAreaCounty);
				this.capitalOutgoingPerDayValueLabel.Text = num5.ToString("N", nfi);
				return;
			}
			this.capitalTop10PanelImage.Visible = false;
			this.capitalTop10HeaderImage.Visible = false;
			if (GameEngine.Instance.World.isCountyCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				this.capitalOutgoingPerDayLabel.Text = SK.Text("VillageMapPanel_Province_Tithe", "Province Tithe") + ":";
				this.capitalOutgoingPerDayLabel.Visible = true;
				this.capitalOutgoingPerDayValueLabel.Visible = true;
				int num6 = -(parentCapitalTaxRate * GameEngine.Instance.LocalWorldData.BaseTaxForAreaProvince);
				this.capitalOutgoingPerDayValueLabel.Text = num6.ToString("N", nfi);
				return;
			}
			if (GameEngine.Instance.World.isProvinceCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				this.capitalOutgoingPerDayLabel.Text = SK.Text("VillageMapPanel_Country_Tithe", "Country Tithe") + ":";
				this.capitalOutgoingPerDayLabel.Visible = true;
				this.capitalOutgoingPerDayValueLabel.Visible = true;
				int num7 = -(parentCapitalTaxRate * GameEngine.Instance.LocalWorldData.BaseTaxForAreaCountry);
				this.capitalOutgoingPerDayValueLabel.Text = num7.ToString("N", nfi);
				return;
			}
			if (GameEngine.Instance.World.isCountryCapital(InterfaceMgr.Instance.getSelectedMenuVillage()))
			{
				this.capitalOutgoingPerDayLabel.Visible = false;
				this.capitalOutgoingPerDayValueLabel.Visible = false;
			}
		}

		// Token: 0x06002F58 RID: 12120 RVA: 0x000225B8 File Offset: 0x000207B8
		private void capitalTaxLowerClicked()
		{
			if (!this.ViewOnly && GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.changeStats(0, 0, 0, -1);
			}
		}

		// Token: 0x06002F59 RID: 12121 RVA: 0x000225E1 File Offset: 0x000207E1
		private void capitalTaxHigherClicked()
		{
			if (!this.ViewOnly && GameEngine.Instance.Village != null)
			{
				GameEngine.Instance.Village.changeStats(0, 0, 0, 1);
			}
		}

		// Token: 0x06002F5A RID: 12122 RVA: 0x0002260A File Offset: 0x0002080A
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06002F5B RID: 12123 RVA: 0x0002261A File Offset: 0x0002081A
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06002F5C RID: 12124 RVA: 0x0002262A File Offset: 0x0002082A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06002F5D RID: 12125 RVA: 0x0002263C File Offset: 0x0002083C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06002F5E RID: 12126 RVA: 0x00022649 File Offset: 0x00020849
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06002F5F RID: 12127 RVA: 0x00022657 File Offset: 0x00020857
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x00022664 File Offset: 0x00020864
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x00022671 File Offset: 0x00020871
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x0026CC18 File Offset: 0x0026AE18
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Transparent;
			base.Name = "VillageMapPanel";
			base.Size = new Size(196, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04003A5D RID: 14941
		private const int WINDOWS_EXPAND_SPEED = 50;

		// Token: 0x04003A5E RID: 14942
		private const int POPULARITY_WINDOW_SIZE = 335;

		// Token: 0x04003A5F RID: 14943
		private const int EXTENSION_WINDOW_SIZE = 144;

		// Token: 0x04003A60 RID: 14944
		private const int EXTENSION_WINDOW_OPEN_POS = 122;

		// Token: 0x04003A61 RID: 14945
		private const int BUILDING_WINDOW_SIZE = 422;

		// Token: 0x04003A62 RID: 14946
		private const int INBUILDING_WINDOW_SIZE = 335;

		// Token: 0x04003A63 RID: 14947
		private const int INBUILDING_CAPITAL_WINDOW_SIZE = 290;

		// Token: 0x04003A64 RID: 14948
		private const int INFO1_WINDOW_SIZE = 335;

		// Token: 0x04003A65 RID: 14949
		private const int CAPITAL_GIVERS_WINDOW_SIZE = 335;

		// Token: 0x04003A66 RID: 14950
		public const int SUBMENU_RELIGIOUS = 1000;

		// Token: 0x04003A67 RID: 14951
		public const int SUBMENU_DECORATIVE = 1001;

		// Token: 0x04003A68 RID: 14952
		public const int SUBMENU_JUSTICE = 1002;

		// Token: 0x04003A69 RID: 14953
		public const int SUBMENU_ENTERTAINMENT = 1003;

		// Token: 0x04003A6A RID: 14954
		public const int SUBMENU_SMALL_SHRINE = 1004;

		// Token: 0x04003A6B RID: 14955
		public const int SUBMENU_LARGE_SHRINE = 1005;

		// Token: 0x04003A6C RID: 14956
		public const int SUBMENU_SMALL_GARDEN = 1006;

		// Token: 0x04003A6D RID: 14957
		public const int SUBMENU_MEDIUM_GARDEN = 1007;

		// Token: 0x04003A6E RID: 14958
		public const int SUBMENU_LARGE_GARDEN = 1008;

		// Token: 0x04003A6F RID: 14959
		public const int SUBMENU_WATER_GARDEN = 1009;

		// Token: 0x04003A70 RID: 14960
		public const int SUBMENU_SMALL_STATUE = 1010;

		// Token: 0x04003A71 RID: 14961
		public const int SUBMENU_LARGE_STATUE = 1111;

		// Token: 0x04003A72 RID: 14962
		public const int SUBMENU_CAPITAL_RESOURCE = 1112;

		// Token: 0x04003A73 RID: 14963
		public const int SUBMENU_CAPITAL_FOOD = 1113;

		// Token: 0x04003A74 RID: 14964
		public const int SUBMENU_CAPITAL_BANQUET = 1114;

		// Token: 0x04003A75 RID: 14965
		public const int SUBMENU_CAPITAL_WEAPONS = 1115;

		// Token: 0x04003A76 RID: 14966
		public const int SUBMENU_CAPITAL_BANQUET_FOOD = 1116;

		// Token: 0x04003A77 RID: 14967
		public const int SUBMENU_BACK = 2000;

		// Token: 0x04003A78 RID: 14968
		private CustomSelfDrawPanel.CSDImage panelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A79 RID: 14969
		private CustomSelfDrawPanel.CSDImage panelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7A RID: 14970
		private CustomSelfDrawPanel.CSDImage headerImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7B RID: 14971
		private CustomSelfDrawPanel.CSDImage headerGlowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7C RID: 14972
		private CustomSelfDrawPanel.CSDImage indent1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7D RID: 14973
		private CustomSelfDrawPanel.CSDImage indent2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7E RID: 14974
		private CustomSelfDrawPanel.CSDImage indent3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A7F RID: 14975
		private CustomSelfDrawPanel.CSDImage indent4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A80 RID: 14976
		private CustomSelfDrawPanel.CSDImage indent5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A81 RID: 14977
		private CustomSelfDrawPanel.CSDImage indent6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A82 RID: 14978
		private CustomSelfDrawPanel.CSDImage popIndent1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A83 RID: 14979
		private CustomSelfDrawPanel.CSDImage popIndent2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A84 RID: 14980
		private CustomSelfDrawPanel.CSDImage popIndent3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A85 RID: 14981
		private CustomSelfDrawPanel.CSDImage popIndent4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A86 RID: 14982
		private CustomSelfDrawPanel.CSDImage popIndent5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A87 RID: 14983
		private CustomSelfDrawPanel.CSDImage popIndent6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A88 RID: 14984
		private CustomSelfDrawPanel.CSDImage popImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A89 RID: 14985
		private CustomSelfDrawPanel.CSDImage popImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8A RID: 14986
		private CustomSelfDrawPanel.CSDImage popImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8B RID: 14987
		private CustomSelfDrawPanel.CSDImage popImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8C RID: 14988
		private CustomSelfDrawPanel.CSDImage popImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8D RID: 14989
		private CustomSelfDrawPanel.CSDImage popImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8E RID: 14990
		private CustomSelfDrawPanel.CSDImage immChangeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A8F RID: 14991
		private CustomSelfDrawPanel.CSDButton taxLowerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A90 RID: 14992
		private CustomSelfDrawPanel.CSDImage taxLowerButtonGlow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003A91 RID: 14993
		private CustomSelfDrawPanel.CSDButton taxHigherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A92 RID: 14994
		private CustomSelfDrawPanel.CSDButton rationsLowerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A93 RID: 14995
		private CustomSelfDrawPanel.CSDButton rationsHigherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A94 RID: 14996
		private CustomSelfDrawPanel.CSDButton aleLowerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A95 RID: 14997
		private CustomSelfDrawPanel.CSDButton aleHigherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003A96 RID: 14998
		private CustomSelfDrawPanel.CSDLabel taxPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A97 RID: 14999
		private CustomSelfDrawPanel.CSDLabel rationsPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A98 RID: 15000
		private CustomSelfDrawPanel.CSDLabel alePopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A99 RID: 15001
		private CustomSelfDrawPanel.CSDLabel housingPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9A RID: 15002
		private CustomSelfDrawPanel.CSDLabel buildingPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9B RID: 15003
		private CustomSelfDrawPanel.CSDLabel eventsPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9C RID: 15004
		private CustomSelfDrawPanel.CSDLabel arrivesInLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9D RID: 15005
		private CustomSelfDrawPanel.CSDLabel arrivesInTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9E RID: 15006
		private CustomSelfDrawPanel.CSDLabel popularityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003A9F RID: 15007
		private CustomSelfDrawPanel.CSDLabel taxLine1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA0 RID: 15008
		private CustomSelfDrawPanel.CSDLabel rationsLine1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA1 RID: 15009
		private CustomSelfDrawPanel.CSDLabel aleRationsLine1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA2 RID: 15010
		private CustomSelfDrawPanel.CSDLabel foodTypesEatenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA3 RID: 15011
		private CustomSelfDrawPanel.CSDLabel numFoodTypesEatenLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA4 RID: 15012
		private CustomSelfDrawPanel.CSDLabel housingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA5 RID: 15013
		private CustomSelfDrawPanel.CSDLabel buildingsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA6 RID: 15014
		private CustomSelfDrawPanel.CSDLabel eventsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA7 RID: 15015
		private CustomSelfDrawPanel.CSDLabel positiveBuildingsHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA8 RID: 15016
		private CustomSelfDrawPanel.CSDLabel positiveBuildingsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AA9 RID: 15017
		private CustomSelfDrawPanel.CSDLabel negativeBuildingsHeader = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AAA RID: 15018
		private CustomSelfDrawPanel.CSDLabel negativeBuildingsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AAB RID: 15019
		private CustomSelfDrawPanel.CSDColorBar taxBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04003AAC RID: 15020
		private CustomSelfDrawPanel.CSDColorBar rationsBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04003AAD RID: 15021
		private CustomSelfDrawPanel.CSDColorBar aleRationsBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04003AAE RID: 15022
		private CustomSelfDrawPanel.CSDImage extensionImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AAF RID: 15023
		private CustomSelfDrawPanel.CSDLabel extensionHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AB0 RID: 15024
		private CustomSelfDrawPanel.CSDArea taxExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB1 RID: 15025
		private CustomSelfDrawPanel.CSDArea rationsExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB2 RID: 15026
		private CustomSelfDrawPanel.CSDArea aleExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB3 RID: 15027
		private CustomSelfDrawPanel.CSDArea buildingExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB4 RID: 15028
		private CustomSelfDrawPanel.CSDArea housingExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB5 RID: 15029
		private CustomSelfDrawPanel.CSDArea eventsExtensionArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AB6 RID: 15030
		private CustomSelfDrawPanel.CSDLabel taxExtentionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AB7 RID: 15031
		private CustomSelfDrawPanel.CSDLabel taxDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AB8 RID: 15032
		private CustomSelfDrawPanel.CSDLabel taxDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AB9 RID: 15033
		private CustomSelfDrawPanel.CSDLabel parishTaxDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABA RID: 15034
		private CustomSelfDrawPanel.CSDLabel parishTaxDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABB RID: 15035
		private CustomSelfDrawPanel.CSDLabel rationsDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABC RID: 15036
		private CustomSelfDrawPanel.CSDLabel rationsDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABD RID: 15037
		private CustomSelfDrawPanel.CSDLabel rationsDay2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABE RID: 15038
		private CustomSelfDrawPanel.CSDLabel rationsDay2ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ABF RID: 15039
		private CustomSelfDrawPanel.CSDLabel aleRationsDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC0 RID: 15040
		private CustomSelfDrawPanel.CSDLabel aleRationsDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC1 RID: 15041
		private CustomSelfDrawPanel.CSDLabel aleRationsDay2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC2 RID: 15042
		private CustomSelfDrawPanel.CSDLabel aleRationsDay2ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC3 RID: 15043
		private CustomSelfDrawPanel.CSDLabel populationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC4 RID: 15044
		private CustomSelfDrawPanel.CSDLabel populationValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC5 RID: 15045
		private CustomSelfDrawPanel.CSDLabel housingCapacityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC6 RID: 15046
		private CustomSelfDrawPanel.CSDLabel housingCapacityValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC7 RID: 15047
		private CustomSelfDrawPanel.CSDLabel housingOccupancyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC8 RID: 15048
		private CustomSelfDrawPanel.CSDLabel housingOccupancyValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AC9 RID: 15049
		private CustomSelfDrawPanel.CSDLabel eventHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACA RID: 15050
		private CustomSelfDrawPanel.CSDLabel eventCountLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACB RID: 15051
		private CustomSelfDrawPanel.CSDLabel eventExtPopLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACC RID: 15052
		private CustomSelfDrawPanel.CSDLabel eventTitleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACD RID: 15053
		private CustomSelfDrawPanel.CSDLabel eventDaysLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACE RID: 15054
		private CustomSelfDrawPanel.CSDLabel eventTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003ACF RID: 15055
		private CustomSelfDrawPanel.CSDImage eventPopImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AD0 RID: 15056
		private CustomSelfDrawPanel.CSDImage eventTypeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AD1 RID: 15057
		private CustomSelfDrawPanel.CSDImage eventBarImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AD2 RID: 15058
		private CustomSelfDrawPanel.CSDButton eventLowerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AD3 RID: 15059
		private CustomSelfDrawPanel.CSDButton eventHigherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AD4 RID: 15060
		private int currentEventID;

		// Token: 0x04003AD5 RID: 15061
		private bool m_villageIsCapital;

		// Token: 0x04003AD6 RID: 15062
		private bool viewOnly;

		// Token: 0x04003AD7 RID: 15063
		private int glowFade;

		// Token: 0x04003AD8 RID: 15064
		private int currentHeight;

		// Token: 0x04003AD9 RID: 15065
		private int targetHeight;

		// Token: 0x04003ADA RID: 15066
		private int currentExtensionHeight;

		// Token: 0x04003ADB RID: 15067
		private int targetExtensionHeight;

		// Token: 0x04003ADC RID: 15068
		private int currentBuildingHeight;

		// Token: 0x04003ADD RID: 15069
		private int targetBuildingHeight;

		// Token: 0x04003ADE RID: 15070
		private int currentInBuildingHeight;

		// Token: 0x04003ADF RID: 15071
		private int targetInBuildingHeight;

		// Token: 0x04003AE0 RID: 15072
		private int currentInfo1Height;

		// Token: 0x04003AE1 RID: 15073
		private int targetInfo1Height;

		// Token: 0x04003AE2 RID: 15074
		private int currentTopGiversHeight;

		// Token: 0x04003AE3 RID: 15075
		private int targetTopGiversHeight;

		// Token: 0x04003AE4 RID: 15076
		private int extensionType;

		// Token: 0x04003AE5 RID: 15077
		private int nextExtensionType;

		// Token: 0x04003AE6 RID: 15078
		private bool reopenExtension;

		// Token: 0x04003AE7 RID: 15079
		private CustomSelfDrawPanel.CSDImage buildPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AE8 RID: 15080
		private CustomSelfDrawPanel.CSDArea buildHeaderArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AE9 RID: 15081
		private CustomSelfDrawPanel.CSDImage buildPanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AEA RID: 15082
		private CustomSelfDrawPanel.CSDButton buildTab1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AEB RID: 15083
		private CustomSelfDrawPanel.CSDButton buildTab2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AEC RID: 15084
		private CustomSelfDrawPanel.CSDButton buildTab3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AED RID: 15085
		private CustomSelfDrawPanel.CSDButton buildTab4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AEE RID: 15086
		private CustomSelfDrawPanel.CSDButton buildTab5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AEF RID: 15087
		private CustomSelfDrawPanel.CSDImage buildInfoImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AF0 RID: 15088
		private CustomSelfDrawPanel.CSDLabel buildTypeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AF1 RID: 15089
		private CustomSelfDrawPanel.CSDArea buildTooltipArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003AF2 RID: 15090
		private CustomSelfDrawPanel.CSDImage buildTimeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AF3 RID: 15091
		private CustomSelfDrawPanel.CSDLabel buildTimeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AF4 RID: 15092
		private CustomSelfDrawPanel.CSDImage buildWoodImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AF5 RID: 15093
		private CustomSelfDrawPanel.CSDLabel buildWoodLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AF6 RID: 15094
		private CustomSelfDrawPanel.CSDImage buildStoneImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AF7 RID: 15095
		private CustomSelfDrawPanel.CSDLabel buildStoneLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AF8 RID: 15096
		private CustomSelfDrawPanel.CSDImage buildGoldImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AF9 RID: 15097
		private CustomSelfDrawPanel.CSDLabel buildGoldLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003AFA RID: 15098
		private CustomSelfDrawPanel.CSDButton buildCapitalHelp = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AFB RID: 15099
		private CustomSelfDrawPanel.CSDImage buildDonationTypeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003AFC RID: 15100
		private CustomSelfDrawPanel.CSDButton building1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AFD RID: 15101
		private CustomSelfDrawPanel.CSDButton building2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AFE RID: 15102
		private CustomSelfDrawPanel.CSDButton building3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003AFF RID: 15103
		private CustomSelfDrawPanel.CSDButton building4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B00 RID: 15104
		private CustomSelfDrawPanel.CSDButton building5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B01 RID: 15105
		private CustomSelfDrawPanel.CSDButton building6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B02 RID: 15106
		private CustomSelfDrawPanel.CSDButton building7Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B03 RID: 15107
		private CustomSelfDrawPanel.CSDButton building8Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B04 RID: 15108
		private CustomSelfDrawPanel.CSDImage building1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B05 RID: 15109
		private CustomSelfDrawPanel.CSDLabel building1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B06 RID: 15110
		private CustomSelfDrawPanel.CSDImage building2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B07 RID: 15111
		private CustomSelfDrawPanel.CSDLabel building2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B08 RID: 15112
		private CustomSelfDrawPanel.CSDImage building3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B09 RID: 15113
		private CustomSelfDrawPanel.CSDLabel building3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B0A RID: 15114
		private CustomSelfDrawPanel.CSDImage building4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B0B RID: 15115
		private CustomSelfDrawPanel.CSDLabel building4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B0C RID: 15116
		private CustomSelfDrawPanel.CSDImage building5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B0D RID: 15117
		private CustomSelfDrawPanel.CSDLabel building5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B0E RID: 15118
		private CustomSelfDrawPanel.CSDImage building6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B0F RID: 15119
		private CustomSelfDrawPanel.CSDLabel building6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B10 RID: 15120
		private CustomSelfDrawPanel.CSDImage building7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B11 RID: 15121
		private CustomSelfDrawPanel.CSDLabel building7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B12 RID: 15122
		private CustomSelfDrawPanel.CSDImage building8Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B13 RID: 15123
		private CustomSelfDrawPanel.CSDLabel building8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B14 RID: 15124
		private int currentTab = -1;

		// Token: 0x04003B15 RID: 15125
		private int currentBuildingIcon;

		// Token: 0x04003B16 RID: 15126
		private bool buildingBeingPlaced;

		// Token: 0x04003B17 RID: 15127
		private CustomSelfDrawPanel.CSDImage info1HeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B18 RID: 15128
		private CustomSelfDrawPanel.CSDImage info1HeaderHonourImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B19 RID: 15129
		private CustomSelfDrawPanel.CSDLabel info1HeaderHonourAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B1A RID: 15130
		private CustomSelfDrawPanel.CSDImage info1PanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B1B RID: 15131
		private CustomSelfDrawPanel.CSDImage info1PanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B1C RID: 15132
		private CustomSelfDrawPanel.CSDLabel info1BlackLine1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B1D RID: 15133
		private CustomSelfDrawPanel.CSDLabel info1BlackLine1aLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B1E RID: 15134
		private CustomSelfDrawPanel.CSDLabel info1ChurchLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B1F RID: 15135
		private CustomSelfDrawPanel.CSDLabel info1ChurchAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B20 RID: 15136
		private CustomSelfDrawPanel.CSDLabel info1DecorativeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B21 RID: 15137
		private CustomSelfDrawPanel.CSDLabel info1DecorativeAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B22 RID: 15138
		private CustomSelfDrawPanel.CSDLabel info1JusticeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B23 RID: 15139
		private CustomSelfDrawPanel.CSDLabel info1JusticeAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B24 RID: 15140
		private CustomSelfDrawPanel.CSDLabel info1ArtsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B25 RID: 15141
		private CustomSelfDrawPanel.CSDLabel info1ArtsAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B26 RID: 15142
		private CustomSelfDrawPanel.CSDLabel info1ParishLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B27 RID: 15143
		private CustomSelfDrawPanel.CSDLabel info1ParishAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B28 RID: 15144
		private CustomSelfDrawPanel.CSDLabel info1CardsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B29 RID: 15145
		private CustomSelfDrawPanel.CSDLabel info1CardsAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2A RID: 15146
		private CustomSelfDrawPanel.CSDLabel info1PopularityLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2B RID: 15147
		private CustomSelfDrawPanel.CSDLabel info1PopularityAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2C RID: 15148
		private CustomSelfDrawPanel.CSDLabel info1HonourCalc = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2D RID: 15149
		private CustomSelfDrawPanel.CSDLabel info1HonourCalc2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2E RID: 15150
		private CustomSelfDrawPanel.CSDLabel info1HonourPerDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B2F RID: 15151
		private CustomSelfDrawPanel.CSDLabel info1HonourPerDayAmount = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B30 RID: 15152
		private CustomSelfDrawPanel.CSDLabel info1BanquetDate = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B31 RID: 15153
		private CustomSelfDrawPanel.CSDLabel info1BlackLine2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B32 RID: 15154
		private CustomSelfDrawPanel.CSDLabel info1BlackLine2aLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B33 RID: 15155
		private CustomSelfDrawPanel.CSDImage info1PopImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B34 RID: 15156
		private CustomSelfDrawPanel.CSDImage info2HeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B35 RID: 15157
		private CustomSelfDrawPanel.CSDImage info2HeaderPanelGlowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B36 RID: 15158
		private CustomSelfDrawPanel.CSDImage info3HeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B37 RID: 15159
		private CustomSelfDrawPanel.CSDImage info3HeaderPanelGlowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B38 RID: 15160
		private CustomSelfDrawPanel.CSDImage extrasHeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B39 RID: 15161
		private CustomSelfDrawPanel.CSDImage extrasHeaderPanelGlowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B3A RID: 15162
		private CustomSelfDrawPanel.CSDImage inBuildingHeaderPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B3B RID: 15163
		private CustomSelfDrawPanel.CSDImage inBuildingPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B3C RID: 15164
		private CustomSelfDrawPanel.CSDImage inBuildingTypeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B3D RID: 15165
		private CustomSelfDrawPanel.CSDImage inBuildingFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B3E RID: 15166
		private CustomSelfDrawPanel.CSDButton inBuildingMoveButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B3F RID: 15167
		private CustomSelfDrawPanel.CSDButton inBuildingHelpButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B40 RID: 15168
		private CustomSelfDrawPanel.CSDButton inBuildingDeleteButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B41 RID: 15169
		private CustomSelfDrawPanel.CSDButton inBuildingDonateButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B42 RID: 15170
		private CustomSelfDrawPanel.CSDButton inBuildingAllIndustryOnButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B43 RID: 15171
		private CustomSelfDrawPanel.CSDButton inBuildingIndustryAllOnButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B44 RID: 15172
		private CustomSelfDrawPanel.CSDButton inBuildingIndustryThisOnButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B45 RID: 15173
		private CustomSelfDrawPanel.CSDLabel inBuildingName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B46 RID: 15174
		private CustomSelfDrawPanel.CSDLabel inBuildingCompleteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B47 RID: 15175
		private CustomSelfDrawPanel.CSDLabel inBuildingCompleteLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B48 RID: 15176
		private CustomSelfDrawPanel.CSDButton inBuildingGenericButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B49 RID: 15177
		private CustomSelfDrawPanel.CSDButton inBuildingGenericButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B4A RID: 15178
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel0 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B4B RID: 15179
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B4C RID: 15180
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B4D RID: 15181
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B4E RID: 15182
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B4F RID: 15183
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B50 RID: 15184
		private CustomSelfDrawPanel.CSDLabel inBuildingMakeWeaponLabel6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B51 RID: 15185
		private CustomSelfDrawPanel.CSDImage inBuildingMakeWeaponImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B52 RID: 15186
		private CustomSelfDrawPanel.CSDImage inBuildingMakeWeaponImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B53 RID: 15187
		private CustomSelfDrawPanel.CSDImage inBuildingMakeWeaponImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B54 RID: 15188
		private CustomSelfDrawPanel.CSDImage inBuildingMakeWeaponImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B55 RID: 15189
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLevelLabel1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B56 RID: 15190
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLevelLabel2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B57 RID: 15191
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel1a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B58 RID: 15192
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel1b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B59 RID: 15193
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel1c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B5A RID: 15194
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B5B RID: 15195
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel2a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B5C RID: 15196
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel2b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B5D RID: 15197
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel2c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B5E RID: 15198
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B5F RID: 15199
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel3a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B60 RID: 15200
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel3b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B61 RID: 15201
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel3c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B62 RID: 15202
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B63 RID: 15203
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel4a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B64 RID: 15204
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel4b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B65 RID: 15205
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel4c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B66 RID: 15206
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B67 RID: 15207
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel5a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B68 RID: 15208
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel5b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B69 RID: 15209
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel5c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B6A RID: 15210
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B6B RID: 15211
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel6a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B6C RID: 15212
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel6b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B6D RID: 15213
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel6c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B6E RID: 15214
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B6F RID: 15215
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel7a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B70 RID: 15216
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel7b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B71 RID: 15217
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel7c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B72 RID: 15218
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B73 RID: 15219
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel8a = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B74 RID: 15220
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel8b = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B75 RID: 15221
		private CustomSelfDrawPanel.CSDLabel inBuildingCapitalResourceLabel8c = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B76 RID: 15222
		private CustomSelfDrawPanel.CSDImage inBuildingCapitalResourceImage8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B77 RID: 15223
		private VillageMapBuilding selectedBuilding;

		// Token: 0x04003B78 RID: 15224
		private DateTime lastTabScroll = DateTime.MinValue;

		// Token: 0x04003B79 RID: 15225
		private int currentSelectedBuildingType = -1;

		// Token: 0x04003B7A RID: 15226
		private CustomSelfDrawPanel.CSDImage capitalPanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B7B RID: 15227
		private CustomSelfDrawPanel.CSDButton capitalTaxLowerButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B7C RID: 15228
		private CustomSelfDrawPanel.CSDButton capitalTaxHigherButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003B7D RID: 15229
		private CustomSelfDrawPanel.CSDColorBar capitalTaxBar = new CustomSelfDrawPanel.CSDColorBar();

		// Token: 0x04003B7E RID: 15230
		private CustomSelfDrawPanel.CSDLabel capitalTaxLine1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B7F RID: 15231
		private CustomSelfDrawPanel.CSDLabel capitalTaxPerDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B80 RID: 15232
		private CustomSelfDrawPanel.CSDLabel capitalTaxPerDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B81 RID: 15233
		private CustomSelfDrawPanel.CSDLabel capitalLastTaxRateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B82 RID: 15234
		private CustomSelfDrawPanel.CSDLabel capitalLastTaxRateValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B83 RID: 15235
		private CustomSelfDrawPanel.CSDLabel capitalOutgoingPerDayLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B84 RID: 15236
		private CustomSelfDrawPanel.CSDLabel capitalOutgoingPerDayValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B85 RID: 15237
		private CustomSelfDrawPanel.CSDImage capitalTop10PanelImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B86 RID: 15238
		private CustomSelfDrawPanel.CSDImage capitalTop10HeaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B87 RID: 15239
		private CustomSelfDrawPanel.CSDImage capitalTop10HeaderGlowImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B88 RID: 15240
		private CustomSelfDrawPanel.CSDImage capitalTop10PanelFaderImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003B89 RID: 15241
		private CustomSelfDrawPanel.CSDLabel capitalTaxTopGivers = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8A RID: 15242
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8B RID: 15243
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver1ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8C RID: 15244
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8D RID: 15245
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver2ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8E RID: 15246
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B8F RID: 15247
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver3ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B90 RID: 15248
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B91 RID: 15249
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver4ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B92 RID: 15250
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B93 RID: 15251
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver5ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B94 RID: 15252
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B95 RID: 15253
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver6ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B96 RID: 15254
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B97 RID: 15255
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver7ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B98 RID: 15256
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B99 RID: 15257
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver8ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9A RID: 15258
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver9Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9B RID: 15259
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver9ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9C RID: 15260
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver10Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9D RID: 15261
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiver10ValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9E RID: 15262
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiverOthersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003B9F RID: 15263
		private CustomSelfDrawPanel.CSDLabel capitalTaxGiverOthersValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003BA0 RID: 15264
		private VillageMapPanel.ParishTaxComparerPositive parishTaxComparerPositive = new VillageMapPanel.ParishTaxComparerPositive();

		// Token: 0x04003BA1 RID: 15265
		private VillageMapPanel.ParishTaxComparerNegative parishTaxComparerNegative = new VillageMapPanel.ParishTaxComparerNegative();

		// Token: 0x04003BA2 RID: 15266
		private DockableControl dockableControl;

		// Token: 0x04003BA3 RID: 15267
		private IContainer components;

		// Token: 0x020004E6 RID: 1254
		public class ParishTaxComparerPositive : IComparer<ParishTaxCalc>
		{
			// Token: 0x06002F63 RID: 12131 RVA: 0x00022690 File Offset: 0x00020890
			public int Compare(ParishTaxCalc x, ParishTaxCalc y)
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
					if (x.tax < y.tax)
					{
						return 1;
					}
					if (x.tax > y.tax)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020004E7 RID: 1255
		public class ParishTaxComparerNegative : IComparer<ParishTaxCalc>
		{
			// Token: 0x06002F65 RID: 12133 RVA: 0x000226C2 File Offset: 0x000208C2
			public int Compare(ParishTaxCalc y, ParishTaxCalc x)
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
					if (x.tax < y.tax)
					{
						return 1;
					}
					if (x.tax > y.tax)
					{
						return -1;
					}
					return 0;
				}
			}
		}
	}
}
