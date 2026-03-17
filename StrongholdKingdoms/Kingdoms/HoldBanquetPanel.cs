using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x020001EF RID: 495
	public class HoldBanquetPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x060013B4 RID: 5044 RVA: 0x0014FAD4 File Offset: 0x0014DCD4
		public HoldBanquetPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00150100 File Offset: 0x0014E300
		public void init()
		{
			HoldBanquetPanel.Instance = this;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("BanquetScreen_Banqueting", "Banqueting"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "HoldBanquetPanel_close");
			this.closeButton.CustomTooltipID = 1000;
			base.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 7, new Point(898, 10));
			int research_Craftsmanship = (int)GameEngine.Instance.World.UserResearchData.Research_Craftsmanship;
			int num = research_Craftsmanship;
			if (num > 0)
			{
				int num2 = 80;
				int num3 = 20;
				int num4 = 13;
				int num5 = 0;
				int num6 = num * num2 + num3 + num4;
				if (num6 < 156)
				{
					num5 = (156 - num6) / 2;
					num6 = 156;
					num3 += num5;
				}
				this.resourcesBox.Size = new Size(num6, 67);
				this.resourcesBox.Position = new Point(160 + (8 - num) * (num2 / 2) - num5, 79);
				this.mainBackgroundImage.addControl(this.resourcesBox);
				this.resourcesBox.Create(GFXLibrary.int_insetbar_a_left, GFXLibrary.int_insetbar_a_middle, GFXLibrary.int_insetbar_a_right);
				if (num >= 1)
				{
					this.resourceLevelImages1.Image = GFXLibrary.com_64_venison_DS;
					this.resourceLevelImages1.Position = new Point(num3 + 42 - 45, -37);
					this.resourcesBox.addControl(this.resourceLevelImages1);
					this.resourceLevelText1.Text = "100";
					this.resourceLevelText1.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText1.Position = new Point(num3, 45);
					this.resourceLevelText1.Size = new Size(83, 12);
					this.resourceLevelText1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText1);
				}
				if (num >= 2)
				{
					this.resourceLevelImages2.Image = GFXLibrary.com_64_furniture_DS;
					this.resourceLevelImages2.Position = new Point(num3 + 42 - 45 + num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages2);
					this.resourceLevelText2.Text = "100";
					this.resourceLevelText2.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText2.Position = new Point(num3 + num2, 45);
					this.resourceLevelText2.Size = new Size(83, 12);
					this.resourceLevelText2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText2);
				}
				if (num >= 3)
				{
					this.resourceLevelImages3.Image = GFXLibrary.com_64_metalware_DS;
					this.resourceLevelImages3.Position = new Point(num3 + 42 - 45 + 2 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages3);
					this.resourceLevelText3.Text = "100";
					this.resourceLevelText3.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText3.Position = new Point(num3 + 2 * num2, 45);
					this.resourceLevelText3.Size = new Size(83, 12);
					this.resourceLevelText3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText3);
				}
				if (num >= 4)
				{
					this.resourceLevelImages4.Image = GFXLibrary.com_64_clothes_DS;
					this.resourceLevelImages4.Position = new Point(num3 + 42 - 45 + 3 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages4);
					this.resourceLevelText4.Text = "100";
					this.resourceLevelText4.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText4.Position = new Point(num3 + 3 * num2, 45);
					this.resourceLevelText4.Size = new Size(83, 12);
					this.resourceLevelText4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText4);
				}
				if (num >= 5)
				{
					this.resourceLevelImages5.Image = GFXLibrary.com_64_wine_DS;
					this.resourceLevelImages5.Position = new Point(num3 + 42 - 45 + 4 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages5);
					this.resourceLevelText5.Text = "100";
					this.resourceLevelText5.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText5.Position = new Point(num3 + 4 * num2, 45);
					this.resourceLevelText5.Size = new Size(83, 12);
					this.resourceLevelText5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText5);
				}
				if (num >= 6)
				{
					this.resourceLevelImages6.Image = GFXLibrary.com_64_salt_DS;
					this.resourceLevelImages6.Position = new Point(num3 + 42 - 45 + 5 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages6);
					this.resourceLevelText6.Text = "100";
					this.resourceLevelText6.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText6.Position = new Point(num3 + 5 * num2, 45);
					this.resourceLevelText6.Size = new Size(83, 12);
					this.resourceLevelText6.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText6);
				}
				if (num >= 7)
				{
					this.resourceLevelImages7.Image = GFXLibrary.com_64_spices_DS;
					this.resourceLevelImages7.Position = new Point(num3 + 42 - 45 + 6 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages7);
					this.resourceLevelText7.Text = "100";
					this.resourceLevelText7.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText7.Position = new Point(num3 + 6 * num2, 45);
					this.resourceLevelText7.Size = new Size(83, 12);
					this.resourceLevelText7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText7);
				}
				if (num >= 8)
				{
					this.resourceLevelImages8.Image = GFXLibrary.com_64_silk_DS;
					this.resourceLevelImages8.Position = new Point(num3 + 42 - 45 + 7 * num2, -37);
					this.resourcesBox.addControl(this.resourceLevelImages8);
					this.resourceLevelText8.Text = "100";
					this.resourceLevelText8.Color = Color.FromArgb(224, 203, 146);
					this.resourceLevelText8.Position = new Point(num3 + 7 * num2, 45);
					this.resourceLevelText8.Size = new Size(83, 12);
					this.resourceLevelText8.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.resourceLevelText8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.resourcesBox.addControl(this.resourceLevelText8);
				}
				this.mainWindow.Size = new Size(739, 399);
				this.mainWindow.Position = new Point(131, 157);
				this.mainBackgroundImage.addControl(this.mainWindow);
				this.mainWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
				this.heading1.Text = SK.Text("BanquetScreen_Goods", "Goods");
				this.heading1.Color = Color.FromArgb(224, 203, 146);
				this.heading1.Position = new Point(23, 20);
				this.heading1.Size = new Size(351, 20);
				this.heading1.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.heading1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainWindow.addControl(this.heading1);
				this.lightArea1.Size = new Size(351, 330);
				this.lightArea1.Position = new Point(23, 47);
				this.mainWindow.addControl(this.lightArea1);
				this.lightArea1.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
				this.heading2.Text = SK.Text("BanquetScreen_Multiplier", "Multiplier");
				this.heading2.Color = Color.FromArgb(224, 203, 146);
				this.heading2.Position = new Point(350, 20);
				this.heading2.Size = new Size(113, 20);
				this.heading2.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.heading2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainWindow.addControl(this.heading2);
				this.lightArea2.Size = new Size(53, 330);
				this.lightArea2.Position = new Point(380, 47);
				this.mainWindow.addControl(this.lightArea2);
				this.lightArea2.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
				this.heading3.Text = SK.Text("GENERIC_Honour", "Honour");
				this.heading3.Color = Color.FromArgb(224, 203, 146);
				this.heading3.Position = new Point(439, 20);
				this.heading3.Size = new Size(119, 20);
				this.heading3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.heading3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainWindow.addControl(this.heading3);
				this.lightArea3.Size = new Size(119, 330);
				this.lightArea3.Position = new Point(439, 47);
				this.mainWindow.addControl(this.lightArea3);
				this.lightArea3.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
				this.heading4.Text = SK.Text("BanquetScreen_Hold_Banquet", "Hold Banquet");
				this.heading4.Color = Color.FromArgb(224, 203, 146);
				this.heading4.Position = new Point(565, 20);
				this.heading4.Size = new Size(163, 20);
				this.heading4.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.heading4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainWindow.addControl(this.heading4);
				this.banquetRow1.Position = new Point(0, 55);
				this.banquetRow1.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow1);
				this.banquetRow2.Position = new Point(0, 95);
				this.banquetRow2.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow2);
				this.banquetRow3.Position = new Point(0, 135);
				this.banquetRow3.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow3);
				this.banquetRow4.Position = new Point(0, 175);
				this.banquetRow4.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow4);
				this.banquetRow5.Position = new Point(0, 215);
				this.banquetRow5.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow5);
				this.banquetRow6.Position = new Point(0, 255);
				this.banquetRow6.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow6);
				this.banquetRow7.Position = new Point(0, 295);
				this.banquetRow7.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow7);
				this.banquetRow8.Position = new Point(0, 335);
				this.banquetRow8.Size = new Size(734, 40);
				this.mainWindow.addControl(this.banquetRow8);
				this.leftBracket1.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket1.Position = new Point(74, 2);
				this.banquetRow1.addControl(this.leftBracket1);
				this.rightBracket1.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket1.Position = new Point(120, 2);
				this.banquetRow1.addControl(this.rightBracket1);
				this.type1Row1.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row1.Position = new Point(84, -2);
				this.banquetRow1.addControl(this.type1Row1);
				this.numResourcesRow1.Text = "100";
				this.numResourcesRow1.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow1.Position = new Point(23, -1);
				this.numResourcesRow1.Size = new Size(45, 40);
				this.numResourcesRow1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow1.addControl(this.numResourcesRow1);
				this.xShadowRow1.Image = GFXLibrary.int_multiplyer_shadow_x1;
				this.xShadowRow1.Position = new Point(396, 13);
				this.banquetRow1.addControl(this.xShadowRow1);
				this.xRow1.Text = "x1";
				this.xRow1.Color = Color.FromArgb(62, 237, 46);
				this.xRow1.Position = new Point(380, -1);
				this.xRow1.Size = new Size(53, 40);
				this.xRow1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow1.addControl(this.xRow1);
				this.honourRow1.Text = "= 100";
				this.honourRow1.Color = Color.FromArgb(224, 203, 146);
				this.honourRow1.Position = new Point(439, -1);
				this.honourRow1.Size = new Size(75, 40);
				this.honourRow1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow1.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow1.addControl(this.honourRow1);
				this.honourImageRow1.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow1.Position = new Point(518, -2);
				this.banquetRow1.addControl(this.honourImageRow1);
				this.holdBandquetRow1.Position = new Point(565, 1);
				this.holdBandquetRow1.Size = new Size(163, 38);
				this.holdBandquetRow1.Text.Text = SK.Text("BanquetScreen_Size_1", "Humble");
				this.holdBandquetRow1.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow1.TextYOffset = -1;
				this.holdBandquetRow1.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow1.Data = 0;
				this.holdBandquetRow1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_humble");
				this.banquetRow1.addControl(this.holdBandquetRow1);
				this.holdBandquetRow1.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow1.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket2.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket2.Position = new Point(74, 2);
				this.banquetRow2.addControl(this.leftBracket2);
				this.rightBracket2.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket2.Position = new Point(152, 2);
				this.banquetRow2.addControl(this.rightBracket2);
				this.type1Row2.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row2.Position = new Point(84, -2);
				this.banquetRow2.addControl(this.type1Row2);
				this.type2Row2.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row2.Position = new Point(116, -2);
				this.banquetRow2.addControl(this.type2Row2);
				this.numResourcesRow2.Text = "100";
				this.numResourcesRow2.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow2.Position = new Point(23, -1);
				this.numResourcesRow2.Size = new Size(45, 40);
				this.numResourcesRow2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow2.addControl(this.numResourcesRow2);
				this.xShadowRow2.Image = GFXLibrary.int_multiplyer_shadow_x1;
				this.xShadowRow2.Position = new Point(396, 13);
				this.banquetRow2.addControl(this.xShadowRow2);
				this.xRow2.Text = "x4";
				this.xRow2.Color = Color.FromArgb(62, 237, 46);
				this.xRow2.Position = new Point(380, -1);
				this.xRow2.Size = new Size(53, 40);
				this.xRow2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow2.addControl(this.xRow2);
				this.honourRow2.Text = "= 100";
				this.honourRow2.Color = Color.FromArgb(224, 203, 146);
				this.honourRow2.Position = new Point(439, -1);
				this.honourRow2.Size = new Size(75, 40);
				this.honourRow2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow2.addControl(this.honourRow2);
				this.honourImageRow2.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow2.Position = new Point(518, -2);
				this.banquetRow2.addControl(this.honourImageRow2);
				this.holdBandquetRow2.Position = new Point(565, 1);
				this.holdBandquetRow2.Size = new Size(163, 38);
				this.holdBandquetRow2.Text.Text = SK.Text("BanquetScreen_Size_2", "Modest");
				this.holdBandquetRow2.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow2.TextYOffset = -1;
				this.holdBandquetRow2.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow2.Data = 1;
				this.holdBandquetRow2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_modest");
				this.banquetRow2.addControl(this.holdBandquetRow2);
				this.holdBandquetRow2.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow2.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket3.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket3.Position = new Point(74, 2);
				this.banquetRow3.addControl(this.leftBracket3);
				this.rightBracket3.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket3.Position = new Point(184, 2);
				this.banquetRow3.addControl(this.rightBracket3);
				this.type1Row3.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row3.Position = new Point(84, -2);
				this.banquetRow3.addControl(this.type1Row3);
				this.type2Row3.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row3.Position = new Point(116, -2);
				this.banquetRow3.addControl(this.type2Row3);
				this.type3Row3.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row3.Position = new Point(148, -2);
				this.banquetRow3.addControl(this.type3Row3);
				this.numResourcesRow3.Text = "100";
				this.numResourcesRow3.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow3.Position = new Point(23, -1);
				this.numResourcesRow3.Size = new Size(45, 40);
				this.numResourcesRow3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow3.addControl(this.numResourcesRow3);
				this.xShadowRow3.Image = GFXLibrary.int_multiplyer_shadow_x1;
				this.xShadowRow3.Position = new Point(396, 13);
				this.banquetRow3.addControl(this.xShadowRow3);
				this.xRow3.Text = "x9";
				this.xRow3.Color = Color.FromArgb(62, 237, 46);
				this.xRow3.Position = new Point(380, -1);
				this.xRow3.Size = new Size(53, 40);
				this.xRow3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow3.addControl(this.xRow3);
				this.honourRow3.Text = "= 100";
				this.honourRow3.Color = Color.FromArgb(224, 203, 146);
				this.honourRow3.Position = new Point(439, -1);
				this.honourRow3.Size = new Size(75, 40);
				this.honourRow3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow3.addControl(this.honourRow3);
				this.honourImageRow3.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow3.Position = new Point(518, -2);
				this.banquetRow3.addControl(this.honourImageRow3);
				this.holdBandquetRow3.Position = new Point(565, 1);
				this.holdBandquetRow3.Size = new Size(163, 38);
				this.holdBandquetRow3.Text.Text = SK.Text("BanquetScreen_Size_3", "Fine");
				this.holdBandquetRow3.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow3.TextYOffset = -1;
				this.holdBandquetRow3.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow3.Data = 2;
				this.holdBandquetRow3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_fine");
				this.banquetRow3.addControl(this.holdBandquetRow3);
				this.holdBandquetRow3.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow3.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket4.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket4.Position = new Point(74, 2);
				this.banquetRow4.addControl(this.leftBracket4);
				this.rightBracket4.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket4.Position = new Point(216, 2);
				this.banquetRow4.addControl(this.rightBracket4);
				this.type1Row4.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row4.Position = new Point(84, -2);
				this.banquetRow4.addControl(this.type1Row4);
				this.type2Row4.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row4.Position = new Point(116, -2);
				this.banquetRow4.addControl(this.type2Row4);
				this.type3Row4.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row4.Position = new Point(148, -2);
				this.banquetRow4.addControl(this.type3Row4);
				this.type4Row4.Image = GFXLibrary.com_32_clothes_DS;
				this.type4Row4.Position = new Point(180, -2);
				this.banquetRow4.addControl(this.type4Row4);
				this.numResourcesRow4.Text = "100";
				this.numResourcesRow4.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow4.Position = new Point(23, -1);
				this.numResourcesRow4.Size = new Size(45, 40);
				this.numResourcesRow4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow4.addControl(this.numResourcesRow4);
				this.xShadowRow4.Image = GFXLibrary.int_multiplyer_shadow_x2;
				this.xShadowRow4.Position = new Point(394, 13);
				this.banquetRow4.addControl(this.xShadowRow4);
				this.xRow4.Text = "x16";
				this.xRow4.Color = Color.FromArgb(62, 237, 46);
				this.xRow4.Position = new Point(380, -1);
				this.xRow4.Size = new Size(53, 40);
				this.xRow4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow4.addControl(this.xRow4);
				this.honourRow4.Text = "= 100";
				this.honourRow4.Color = Color.FromArgb(224, 203, 146);
				this.honourRow4.Position = new Point(439, -1);
				this.honourRow4.Size = new Size(75, 40);
				this.honourRow4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow4.addControl(this.honourRow4);
				this.honourImageRow4.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow4.Position = new Point(518, -2);
				this.banquetRow4.addControl(this.honourImageRow4);
				this.holdBandquetRow4.Position = new Point(565, 1);
				this.holdBandquetRow4.Size = new Size(163, 38);
				this.holdBandquetRow4.Text.Text = SK.Text("BanquetScreen_Size_4", "Impressive");
				this.holdBandquetRow4.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow4.TextYOffset = -1;
				this.holdBandquetRow4.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow4.Data = 3;
				this.holdBandquetRow4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_impressive");
				this.banquetRow4.addControl(this.holdBandquetRow4);
				this.holdBandquetRow4.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow4.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket5.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket5.Position = new Point(74, 2);
				this.banquetRow5.addControl(this.leftBracket5);
				this.rightBracket5.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket5.Position = new Point(248, 2);
				this.banquetRow5.addControl(this.rightBracket5);
				this.type1Row5.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row5.Position = new Point(84, -2);
				this.banquetRow5.addControl(this.type1Row5);
				this.type2Row5.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row5.Position = new Point(116, -2);
				this.banquetRow5.addControl(this.type2Row5);
				this.type3Row5.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row5.Position = new Point(148, -2);
				this.banquetRow5.addControl(this.type3Row5);
				this.type4Row5.Image = GFXLibrary.com_32_clothes_DS;
				this.type4Row5.Position = new Point(180, -2);
				this.banquetRow5.addControl(this.type4Row5);
				this.type5Row5.Image = GFXLibrary.com_32_wine_DS;
				this.type5Row5.Position = new Point(212, -2);
				this.banquetRow5.addControl(this.type5Row5);
				this.numResourcesRow5.Text = "100";
				this.numResourcesRow5.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow5.Position = new Point(23, -1);
				this.numResourcesRow5.Size = new Size(45, 40);
				this.numResourcesRow5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow5.addControl(this.numResourcesRow5);
				this.xShadowRow5.Image = GFXLibrary.int_multiplyer_shadow_x2;
				this.xShadowRow5.Position = new Point(394, 13);
				this.banquetRow5.addControl(this.xShadowRow5);
				this.xRow5.Text = "x35";
				this.xRow5.Color = Color.FromArgb(62, 237, 46);
				this.xRow5.Position = new Point(380, -1);
				this.xRow5.Size = new Size(53, 40);
				this.xRow5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow5.addControl(this.xRow5);
				this.honourRow5.Text = "= 100";
				this.honourRow5.Color = Color.FromArgb(224, 203, 146);
				this.honourRow5.Position = new Point(439, -1);
				this.honourRow5.Size = new Size(75, 40);
				this.honourRow5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow5.addControl(this.honourRow5);
				this.honourImageRow5.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow5.Position = new Point(518, -2);
				this.banquetRow5.addControl(this.honourImageRow5);
				this.holdBandquetRow5.Position = new Point(565, 1);
				this.holdBandquetRow5.Size = new Size(163, 38);
				this.holdBandquetRow5.Text.Text = SK.Text("BanquetScreen_Size_5", "Grand");
				this.holdBandquetRow5.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow5.TextYOffset = -1;
				this.holdBandquetRow5.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow5.Data = 4;
				this.holdBandquetRow5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_grand");
				this.banquetRow5.addControl(this.holdBandquetRow5);
				this.holdBandquetRow5.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow5.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket6.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket6.Position = new Point(74, 2);
				this.banquetRow6.addControl(this.leftBracket6);
				this.rightBracket6.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket6.Position = new Point(280, 2);
				this.banquetRow6.addControl(this.rightBracket6);
				this.type1Row6.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row6.Position = new Point(84, -2);
				this.banquetRow6.addControl(this.type1Row6);
				this.type2Row6.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row6.Position = new Point(116, -2);
				this.banquetRow6.addControl(this.type2Row6);
				this.type3Row6.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row6.Position = new Point(148, -2);
				this.banquetRow6.addControl(this.type3Row6);
				this.type4Row6.Image = GFXLibrary.com_32_clothes_DS;
				this.type4Row6.Position = new Point(180, -2);
				this.banquetRow6.addControl(this.type4Row6);
				this.type5Row6.Image = GFXLibrary.com_32_wine_DS;
				this.type5Row6.Position = new Point(212, -2);
				this.banquetRow6.addControl(this.type5Row6);
				this.type6Row6.Image = GFXLibrary.com_32_salt_DS;
				this.type6Row6.Position = new Point(244, -2);
				this.banquetRow6.addControl(this.type6Row6);
				this.numResourcesRow6.Text = "100";
				this.numResourcesRow6.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow6.Position = new Point(23, -1);
				this.numResourcesRow6.Size = new Size(45, 40);
				this.numResourcesRow6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow6.addControl(this.numResourcesRow6);
				this.xShadowRow6.Image = GFXLibrary.int_multiplyer_shadow_x2;
				this.xShadowRow6.Position = new Point(394, 13);
				this.banquetRow6.addControl(this.xShadowRow6);
				this.xRow6.Text = "x60";
				this.xRow6.Color = Color.FromArgb(62, 237, 46);
				this.xRow6.Position = new Point(380, -1);
				this.xRow6.Size = new Size(53, 40);
				this.xRow6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow6.addControl(this.xRow6);
				this.honourRow6.Text = "= 100";
				this.honourRow6.Color = Color.FromArgb(224, 203, 146);
				this.honourRow6.Position = new Point(439, -1);
				this.honourRow6.Size = new Size(75, 40);
				this.honourRow6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow6.addControl(this.honourRow6);
				this.honourImageRow6.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow6.Position = new Point(518, -2);
				this.banquetRow6.addControl(this.honourImageRow6);
				this.holdBandquetRow6.Position = new Point(565, 1);
				this.holdBandquetRow6.Size = new Size(163, 38);
				this.holdBandquetRow6.Text.Text = SK.Text("BanquetScreen_Size_6", "Magnificent");
				this.holdBandquetRow6.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow6.TextYOffset = -1;
				this.holdBandquetRow6.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow6.Data = 5;
				this.holdBandquetRow6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_magnificent");
				this.banquetRow6.addControl(this.holdBandquetRow6);
				this.holdBandquetRow6.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow6.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket7.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket7.Position = new Point(74, 2);
				this.banquetRow7.addControl(this.leftBracket7);
				this.rightBracket7.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket7.Position = new Point(312, 2);
				this.banquetRow7.addControl(this.rightBracket7);
				this.type1Row7.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row7.Position = new Point(84, -2);
				this.banquetRow7.addControl(this.type1Row7);
				this.type2Row7.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row7.Position = new Point(116, -2);
				this.banquetRow7.addControl(this.type2Row7);
				this.type3Row7.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row7.Position = new Point(148, -2);
				this.banquetRow7.addControl(this.type3Row7);
				this.type4Row7.Image = GFXLibrary.com_32_clothes_DS;
				this.type4Row7.Position = new Point(180, -2);
				this.banquetRow7.addControl(this.type4Row7);
				this.type5Row7.Image = GFXLibrary.com_32_wine_DS;
				this.type5Row7.Position = new Point(212, -2);
				this.banquetRow7.addControl(this.type5Row7);
				this.type6Row7.Image = GFXLibrary.com_32_salt_DS;
				this.type6Row7.Position = new Point(244, -2);
				this.banquetRow7.addControl(this.type6Row7);
				this.type7Row7.Image = GFXLibrary.com_32_spices_DS;
				this.type7Row7.Position = new Point(276, -2);
				this.banquetRow7.addControl(this.type7Row7);
				this.numResourcesRow7.Text = "100";
				this.numResourcesRow7.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow7.Position = new Point(23, -1);
				this.numResourcesRow7.Size = new Size(45, 40);
				this.numResourcesRow7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow7.addControl(this.numResourcesRow7);
				this.xShadowRow7.Image = GFXLibrary.int_multiplyer_shadow_x3;
				this.xShadowRow7.Position = new Point(393, 13);
				this.banquetRow7.addControl(this.xShadowRow7);
				this.xRow7.Text = "x98";
				this.xRow7.Color = Color.FromArgb(62, 237, 46);
				this.xRow7.Position = new Point(380, -1);
				this.xRow7.Size = new Size(53, 40);
				this.xRow7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow7.addControl(this.xRow7);
				this.honourRow7.Text = "= 100";
				this.honourRow7.Color = Color.FromArgb(224, 203, 146);
				this.honourRow7.Position = new Point(439, -1);
				this.honourRow7.Size = new Size(75, 40);
				this.honourRow7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow7.addControl(this.honourRow7);
				this.honourImageRow7.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow7.Position = new Point(518, -2);
				this.banquetRow7.addControl(this.honourImageRow7);
				this.holdBandquetRow7.Position = new Point(565, 1);
				this.holdBandquetRow7.Size = new Size(163, 38);
				this.holdBandquetRow7.Text.Text = SK.Text("BanquetScreen_Size_7", "Majestic");
				this.holdBandquetRow7.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow7.TextYOffset = -1;
				this.holdBandquetRow7.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow7.Data = 6;
				this.holdBandquetRow7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_majestic");
				this.banquetRow7.addControl(this.holdBandquetRow7);
				this.holdBandquetRow7.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow7.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				this.leftBracket8.Image = GFXLibrary.int_parenthesis_left;
				this.leftBracket8.Position = new Point(74, 2);
				this.banquetRow8.addControl(this.leftBracket8);
				this.rightBracket8.Image = GFXLibrary.int_parenthesis_right;
				this.rightBracket8.Position = new Point(344, 2);
				this.banquetRow8.addControl(this.rightBracket8);
				this.type1Row8.Image = GFXLibrary.com_32_venison_DS;
				this.type1Row8.Position = new Point(84, -2);
				this.banquetRow8.addControl(this.type1Row8);
				this.type2Row8.Image = GFXLibrary.com_32_furniture_DS;
				this.type2Row8.Position = new Point(116, -2);
				this.banquetRow8.addControl(this.type2Row8);
				this.type3Row8.Image = GFXLibrary.com_32_metalware_DS;
				this.type3Row8.Position = new Point(148, -2);
				this.banquetRow8.addControl(this.type3Row8);
				this.type4Row8.Image = GFXLibrary.com_32_clothes_DS;
				this.type4Row8.Position = new Point(180, -2);
				this.banquetRow8.addControl(this.type4Row8);
				this.type5Row8.Image = GFXLibrary.com_32_wine_DS;
				this.type5Row8.Position = new Point(212, -2);
				this.banquetRow8.addControl(this.type5Row8);
				this.type6Row8.Image = GFXLibrary.com_32_salt_DS;
				this.type6Row8.Position = new Point(244, -2);
				this.banquetRow8.addControl(this.type6Row8);
				this.type7Row8.Image = GFXLibrary.com_32_spices_DS;
				this.type7Row8.Position = new Point(276, -2);
				this.banquetRow8.addControl(this.type7Row8);
				this.type8Row8.Image = GFXLibrary.com_32_silk_DS;
				this.type8Row8.Position = new Point(308, -2);
				this.banquetRow8.addControl(this.type8Row8);
				this.numResourcesRow8.Text = "100";
				this.numResourcesRow8.Color = Color.FromArgb(224, 203, 146);
				this.numResourcesRow8.Position = new Point(23, -1);
				this.numResourcesRow8.Size = new Size(45, 40);
				this.numResourcesRow8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.numResourcesRow8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow8.addControl(this.numResourcesRow8);
				this.xShadowRow8.Image = GFXLibrary.int_multiplyer_shadow_x3;
				this.xShadowRow8.Position = new Point(393, 13);
				this.banquetRow8.addControl(this.xShadowRow8);
				this.xRow8.Text = "x160";
				this.xRow8.Color = Color.FromArgb(62, 237, 46);
				this.xRow8.Position = new Point(380, -1);
				this.xRow8.Size = new Size(53, 40);
				this.xRow8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.xRow8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.banquetRow8.addControl(this.xRow8);
				this.honourRow8.Text = "= 100";
				this.honourRow8.Color = Color.FromArgb(224, 203, 146);
				this.honourRow8.Position = new Point(439, -1);
				this.honourRow8.Size = new Size(75, 40);
				this.honourRow8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.honourRow8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.banquetRow8.addControl(this.honourRow8);
				this.honourImageRow8.Image = GFXLibrary.com_32_honor_on_larger_dropshadow;
				this.honourImageRow8.Position = new Point(518, -2);
				this.banquetRow8.addControl(this.honourImageRow8);
				this.holdBandquetRow8.Position = new Point(565, 1);
				this.holdBandquetRow8.Size = new Size(163, 38);
				this.holdBandquetRow8.Text.Text = SK.Text("BanquetScreen_Size_8", "Exquisite");
				this.holdBandquetRow8.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.holdBandquetRow8.TextYOffset = -1;
				this.holdBandquetRow8.Text.Color = global::ARGBColors.Black;
				this.holdBandquetRow8.Data = 7;
				this.holdBandquetRow8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.holdBanquetClick), "HoldBanquetPanel_exquisite");
				this.banquetRow8.addControl(this.holdBandquetRow8);
				this.holdBandquetRow8.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
				this.holdBandquetRow8.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
				if (GameEngine.Instance.Village != null && GameEngine.Instance.Village.banqueting != null)
				{
					this.xRow1.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.HUMBLE).ToString();
					this.xRow2.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.MODEST).ToString();
					this.xRow3.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.FINE).ToString();
					this.xRow4.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.IMPRESSIVE).ToString();
					this.xRow5.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.GRAND).ToString();
					this.xRow6.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.MAGNIFICENT).ToString();
					this.xRow7.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.MAJESTIC).ToString();
					this.xRow8.Text = "x" + Banqueting.getHonourMultiplier(Banqueting.Level.EXQUISITE).ToString();
				}
			}
			else
			{
				this.noResearchWindow.Size = new Size(739, 150);
				this.noResearchWindow.Position = new Point(126, (base.Height - 150) / 2);
				this.mainBackgroundImage.addControl(this.noResearchWindow);
				this.noResearchWindow.Create(GFXLibrary.int_insetpanel_a_top_left, GFXLibrary.int_insetpanel_a_middle_top, GFXLibrary.int_insetpanel_a_top_right, GFXLibrary.int_insetpanel_a_middle_left, GFXLibrary.int_insetpanel_a_middle, GFXLibrary.int_insetpanel_a_middle_right, GFXLibrary.int_insetpanel_a_bottom_left, GFXLibrary.int_insetpanel_a_middle_bottom, GFXLibrary.int_insetpanel_a_bottom_right);
				this.noResearchText.Text = SK.Text("BanquetScreen_Need_Research", "You don't currently have the required 'Banqueting' research level to hold a banquet. To begin holding banquets you must research 'Banqueting', 'Hunting' and place a Hunter's Hut in your village.");
				this.noResearchText.Color = Color.FromArgb(224, 203, 146);
				this.noResearchText.Position = new Point(20, 0);
				this.noResearchText.Size = new Size(this.noResearchWindow.Width - 40, this.noResearchWindow.Height);
				this.noResearchText.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.noResearchText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.noResearchWindow.addControl(this.noResearchText);
			}
			this.cardbar.Position = new Point(0, 0);
			base.addControl(this.cardbar);
			this.cardbar.init(3);
			this.updateLevels(true);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0001568E File Offset: 0x0001388E
		public void update()
		{
			if (this.cardbar.update())
			{
				this.updateLevels(true);
				return;
			}
			this.updateLevels(false);
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0015395C File Offset: 0x00151B5C
		public void updateLevels(bool force)
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				village.banqueting.updateLevels(force);
				NumberFormatInfo nfi = GameEngine.NFI;
				int researchLevel = village.banqueting.researchLevel;
				this.banquetRow1.Visible = (researchLevel >= 1);
				this.banquetRow2.Visible = (researchLevel >= 2);
				this.banquetRow3.Visible = (researchLevel >= 3);
				this.banquetRow4.Visible = (researchLevel >= 4);
				this.banquetRow5.Visible = (researchLevel >= 5);
				this.banquetRow6.Visible = (researchLevel >= 6);
				this.banquetRow7.Visible = (researchLevel >= 7);
				this.banquetRow8.Visible = (researchLevel >= 8);
				this.resourceLevelText1.Text = village.banqueting.resourceLevels[0].ToString("N", nfi);
				this.resourceLevelText2.Text = village.banqueting.resourceLevels[1].ToString("N", nfi);
				this.resourceLevelText3.Text = village.banqueting.resourceLevels[2].ToString("N", nfi);
				this.resourceLevelText4.Text = village.banqueting.resourceLevels[3].ToString("N", nfi);
				this.resourceLevelText5.Text = village.banqueting.resourceLevels[4].ToString("N", nfi);
				this.resourceLevelText6.Text = village.banqueting.resourceLevels[5].ToString("N", nfi);
				this.resourceLevelText7.Text = village.banqueting.resourceLevels[6].ToString("N", nfi);
				this.resourceLevelText8.Text = village.banqueting.resourceLevels[7].ToString("N", nfi);
				this.holdBandquetRow1.Enabled = false;
				this.holdBandquetRow2.Enabled = false;
				this.holdBandquetRow3.Enabled = false;
				this.holdBandquetRow4.Enabled = false;
				this.holdBandquetRow5.Enabled = false;
				this.holdBandquetRow6.Enabled = false;
				this.holdBandquetRow7.Enabled = false;
				this.holdBandquetRow8.Enabled = false;
				this.holdBandquetRow1.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow2.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow3.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow4.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow5.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow6.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow7.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.holdBandquetRow8.Text.Color = Color.FromArgb(127, global::ARGBColors.Black);
				this.numResourcesRow1.Text = "0";
				this.honourRow1.Text = "0";
				this.numResourcesRow2.Text = "0";
				this.honourRow2.Text = "0";
				this.numResourcesRow3.Text = "0";
				this.honourRow3.Text = "0";
				this.numResourcesRow4.Text = "0";
				this.honourRow4.Text = "0";
				this.numResourcesRow5.Text = "0";
				this.honourRow5.Text = "0";
				this.numResourcesRow6.Text = "0";
				this.honourRow6.Text = "0";
				this.numResourcesRow7.Text = "0";
				this.honourRow7.Text = "0";
				this.numResourcesRow8.Text = "0";
				this.honourRow8.Text = "0";
				this.honourImageRow1.Alpha = 0.5f;
				this.honourImageRow2.Alpha = 0.5f;
				this.honourImageRow3.Alpha = 0.5f;
				this.honourImageRow4.Alpha = 0.5f;
				this.honourImageRow5.Alpha = 0.5f;
				this.honourImageRow6.Alpha = 0.5f;
				this.honourImageRow7.Alpha = 0.5f;
				this.honourImageRow8.Alpha = 0.5f;
				this.honourRow1.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow2.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow3.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow4.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow5.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow6.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow7.Color = Color.FromArgb(127, 224, 203, 146);
				this.honourRow8.Color = Color.FromArgb(127, 224, 203, 146);
				this.xRow1.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow2.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow3.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow4.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow5.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow6.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow7.Color = Color.FromArgb(127, 62, 237, 46);
				this.xRow8.Color = Color.FromArgb(127, 62, 237, 46);
				this.rightBracket1.Position = new Point(88, 2);
				this.rightBracket2.Position = new Point(88, 2);
				this.rightBracket3.Position = new Point(88, 2);
				this.rightBracket4.Position = new Point(88, 2);
				this.rightBracket5.Position = new Point(88, 2);
				this.rightBracket6.Position = new Point(88, 2);
				this.rightBracket7.Position = new Point(88, 2);
				this.rightBracket8.Position = new Point(88, 2);
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						CustomSelfDrawPanel.CSDImage typePanel = this.getTypePanel(i + 1, j);
						if (typePanel != null)
						{
							typePanel.Visible = false;
						}
					}
				}
				for (int k = 0; k < 8; k++)
				{
					Banqueting.Level level = (Banqueting.Level)k;
					int banquetSize = village.banqueting.getBanquetSize(level);
					if (banquetSize > 0)
					{
						switch (level)
						{
						case Banqueting.Level.HUMBLE:
							this.numResourcesRow1.Text = banquetSize.ToString("N", nfi);
							this.honourRow1.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow1.Enabled = true;
							this.honourImageRow1.Alpha = 1f;
							this.honourRow1.Color = Color.FromArgb(224, 203, 146);
							this.xRow1.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket1.Position = new Point(120, 2);
							this.leftBracket1.Alpha = 1f;
							this.rightBracket1.Alpha = 1f;
							this.holdBandquetRow1.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.MODEST:
							this.numResourcesRow2.Text = banquetSize.ToString("N", nfi);
							this.honourRow2.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.honourImageRow2.Alpha = 1f;
							this.xRow2.Color = Color.FromArgb(62, 237, 46);
							this.honourRow2.Color = Color.FromArgb(224, 203, 146);
							this.holdBandquetRow2.Enabled = true;
							this.rightBracket2.Position = new Point(152, 2);
							this.leftBracket2.Alpha = 1f;
							this.rightBracket2.Alpha = 1f;
							this.holdBandquetRow2.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.FINE:
							this.numResourcesRow3.Text = banquetSize.ToString("N", nfi);
							this.honourRow3.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow3.Enabled = true;
							this.honourImageRow3.Alpha = 1f;
							this.honourRow3.Color = Color.FromArgb(224, 203, 146);
							this.xRow3.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket3.Position = new Point(184, 2);
							this.leftBracket3.Alpha = 1f;
							this.rightBracket3.Alpha = 1f;
							this.holdBandquetRow3.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.IMPRESSIVE:
							this.numResourcesRow4.Text = banquetSize.ToString("N", nfi);
							this.honourRow4.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow4.Enabled = true;
							this.honourImageRow4.Alpha = 1f;
							this.honourRow4.Color = Color.FromArgb(224, 203, 146);
							this.xRow4.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket4.Position = new Point(216, 2);
							this.leftBracket4.Alpha = 1f;
							this.rightBracket4.Alpha = 1f;
							this.holdBandquetRow4.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.GRAND:
							this.numResourcesRow5.Text = banquetSize.ToString("N", nfi);
							this.honourRow5.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow5.Enabled = true;
							this.honourImageRow5.Alpha = 1f;
							this.honourRow5.Color = Color.FromArgb(224, 203, 146);
							this.xRow5.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket5.Position = new Point(248, 2);
							this.leftBracket5.Alpha = 1f;
							this.rightBracket5.Alpha = 1f;
							this.holdBandquetRow5.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.MAGNIFICENT:
							this.numResourcesRow6.Text = banquetSize.ToString("N", nfi);
							this.honourRow6.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow6.Enabled = true;
							this.honourImageRow6.Alpha = 1f;
							this.honourRow6.Color = Color.FromArgb(224, 203, 146);
							this.xRow6.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket6.Position = new Point(280, 2);
							this.leftBracket6.Alpha = 1f;
							this.rightBracket6.Alpha = 1f;
							this.holdBandquetRow6.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.MAJESTIC:
							this.numResourcesRow7.Text = banquetSize.ToString("N", nfi);
							this.honourRow7.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow7.Enabled = true;
							this.honourImageRow7.Alpha = 1f;
							this.honourRow7.Color = Color.FromArgb(224, 203, 146);
							this.xRow7.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket7.Position = new Point(312, 2);
							this.leftBracket7.Alpha = 1f;
							this.rightBracket7.Alpha = 1f;
							this.holdBandquetRow7.Text.Color = global::ARGBColors.Black;
							break;
						case Banqueting.Level.EXQUISITE:
							this.numResourcesRow8.Text = banquetSize.ToString("N", nfi);
							this.honourRow8.Text = village.banqueting.getBanquetHonour(level).ToString("N", nfi);
							this.holdBandquetRow8.Enabled = true;
							this.honourImageRow8.Alpha = 1f;
							this.honourRow8.Color = Color.FromArgb(224, 203, 146);
							this.xRow8.Color = Color.FromArgb(62, 237, 46);
							this.rightBracket8.Position = new Point(344, 2);
							this.leftBracket8.Alpha = 1f;
							this.rightBracket8.Alpha = 1f;
							this.holdBandquetRow8.Text.Color = global::ARGBColors.Black;
							break;
						}
						int num = 0;
						for (int l = 0; l < 8; l++)
						{
							if (village.banqueting.banquetLevels[k, l] > 0)
							{
								CustomSelfDrawPanel.CSDImage typePanel2 = this.getTypePanel(k + 1, num++);
								if (typePanel2 != null)
								{
									typePanel2.Image = this.getImage(l);
									typePanel2.Visible = true;
								}
							}
						}
					}
				}
				if (GameEngine.Instance.World.WorldEnded)
				{
					this.holdBandquetRow1.Enabled = false;
					this.holdBandquetRow2.Enabled = false;
					this.holdBandquetRow3.Enabled = false;
					this.holdBandquetRow4.Enabled = false;
					this.holdBandquetRow5.Enabled = false;
					this.holdBandquetRow6.Enabled = false;
					this.holdBandquetRow7.Enabled = false;
					this.holdBandquetRow8.Enabled = false;
				}
			}
			base.Invalidate();
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x00154910 File Offset: 0x00152B10
		private BaseImage getImage(int resource)
		{
			switch (resource)
			{
			case 0:
				return GFXLibrary.com_32_venison_DS;
			case 1:
				return GFXLibrary.com_32_furniture_DS;
			case 2:
				return GFXLibrary.com_32_metalware_DS;
			case 3:
				return GFXLibrary.com_32_clothes_DS;
			case 4:
				return GFXLibrary.com_32_wine_DS;
			case 5:
				return GFXLibrary.com_32_salt_DS;
			case 6:
				return GFXLibrary.com_32_spices_DS;
			case 7:
				return GFXLibrary.com_32_silk_DS;
			default:
				return null;
			}
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x00154978 File Offset: 0x00152B78
		private CustomSelfDrawPanel.CSDImage getTypePanel(int banquetSize, int column)
		{
			switch (banquetSize)
			{
			case 1:
				if (column == 0)
				{
					return this.type1Row1;
				}
				break;
			case 2:
				if (column == 0)
				{
					return this.type1Row2;
				}
				if (column == 1)
				{
					return this.type2Row2;
				}
				break;
			case 3:
				switch (column)
				{
				case 0:
					return this.type1Row3;
				case 1:
					return this.type2Row3;
				case 2:
					return this.type3Row3;
				}
				break;
			case 4:
				switch (column)
				{
				case 0:
					return this.type1Row4;
				case 1:
					return this.type2Row4;
				case 2:
					return this.type3Row4;
				case 3:
					return this.type4Row4;
				}
				break;
			case 5:
				switch (column)
				{
				case 0:
					return this.type1Row5;
				case 1:
					return this.type2Row5;
				case 2:
					return this.type3Row5;
				case 3:
					return this.type4Row5;
				case 4:
					return this.type5Row5;
				}
				break;
			case 6:
				switch (column)
				{
				case 0:
					return this.type1Row6;
				case 1:
					return this.type2Row6;
				case 2:
					return this.type3Row6;
				case 3:
					return this.type4Row6;
				case 4:
					return this.type5Row6;
				case 5:
					return this.type6Row6;
				}
				break;
			case 7:
				switch (column)
				{
				case 0:
					return this.type1Row7;
				case 1:
					return this.type2Row7;
				case 2:
					return this.type3Row7;
				case 3:
					return this.type4Row7;
				case 4:
					return this.type5Row7;
				case 5:
					return this.type6Row7;
				case 6:
					return this.type7Row7;
				}
				break;
			case 8:
				switch (column)
				{
				case 0:
					return this.type1Row8;
				case 1:
					return this.type2Row8;
				case 2:
					return this.type3Row8;
				case 3:
					return this.type4Row8;
				case 4:
					return this.type5Row8;
				case 5:
					return this.type6Row8;
				case 6:
					return this.type7Row8;
				case 7:
					return this.type8Row8;
				}
				break;
			}
			return null;
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x00154B84 File Offset: 0x00152D84
		public void holdBanquetClick()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
				if (GameEngine.Instance.Village.banqueting.holdBanquet(csdbutton.Data))
				{
					csdbutton.Enabled = false;
				}
			}
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x000156AC File Offset: 0x000138AC
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x000156BC File Offset: 0x000138BC
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x000156CC File Offset: 0x000138CC
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x000156DE File Offset: 0x000138DE
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x000156EB File Offset: 0x000138EB
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x060013C1 RID: 5057 RVA: 0x000156FF File Offset: 0x000138FF
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060013C2 RID: 5058 RVA: 0x0001570C File Offset: 0x0001390C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00015719 File Offset: 0x00013919
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00154BC8 File Offset: 0x00152DC8
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Name = "HoldBanquetPanel2";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040024CA RID: 9418
		private const int imageSpacing = 32;

		// Token: 0x040024CB RID: 9419
		public static HoldBanquetPanel Instance;

		// Token: 0x040024CC RID: 9420
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024CD RID: 9421
		private CustomSelfDrawPanel.CSDLabel banquetLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024CE RID: 9422
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040024CF RID: 9423
		private CustomSelfDrawPanel.CSDHorzExtendingPanel resourcesBox = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040024D0 RID: 9424
		private CustomSelfDrawPanel.CSDImage resourceLevelImages1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024D1 RID: 9425
		private CustomSelfDrawPanel.CSDLabel resourceLevelText1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024D2 RID: 9426
		private CustomSelfDrawPanel.CSDImage resourceLevelImages2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024D3 RID: 9427
		private CustomSelfDrawPanel.CSDLabel resourceLevelText2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024D4 RID: 9428
		private CustomSelfDrawPanel.CSDImage resourceLevelImages3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024D5 RID: 9429
		private CustomSelfDrawPanel.CSDLabel resourceLevelText3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024D6 RID: 9430
		private CustomSelfDrawPanel.CSDImage resourceLevelImages4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024D7 RID: 9431
		private CustomSelfDrawPanel.CSDLabel resourceLevelText4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024D8 RID: 9432
		private CustomSelfDrawPanel.CSDImage resourceLevelImages5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024D9 RID: 9433
		private CustomSelfDrawPanel.CSDLabel resourceLevelText5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024DA RID: 9434
		private CustomSelfDrawPanel.CSDImage resourceLevelImages6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024DB RID: 9435
		private CustomSelfDrawPanel.CSDLabel resourceLevelText6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024DC RID: 9436
		private CustomSelfDrawPanel.CSDImage resourceLevelImages7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024DD RID: 9437
		private CustomSelfDrawPanel.CSDLabel resourceLevelText7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024DE RID: 9438
		private CustomSelfDrawPanel.CSDImage resourceLevelImages8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024DF RID: 9439
		private CustomSelfDrawPanel.CSDLabel resourceLevelText8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024E0 RID: 9440
		private CustomSelfDrawPanel.CSDExtendingPanel mainWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040024E1 RID: 9441
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040024E2 RID: 9442
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea2 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040024E3 RID: 9443
		private CustomSelfDrawPanel.CSDExtendingPanel lightArea3 = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040024E4 RID: 9444
		private CustomSelfDrawPanel.CSDLabel heading1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024E5 RID: 9445
		private CustomSelfDrawPanel.CSDLabel heading2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024E6 RID: 9446
		private CustomSelfDrawPanel.CSDLabel heading3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024E7 RID: 9447
		private CustomSelfDrawPanel.CSDLabel heading4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024E8 RID: 9448
		private CustomSelfDrawPanel.CSDControl banquetRow1 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024E9 RID: 9449
		private CustomSelfDrawPanel.CSDControl banquetRow2 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024EA RID: 9450
		private CustomSelfDrawPanel.CSDControl banquetRow3 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024EB RID: 9451
		private CustomSelfDrawPanel.CSDControl banquetRow4 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024EC RID: 9452
		private CustomSelfDrawPanel.CSDControl banquetRow5 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024ED RID: 9453
		private CustomSelfDrawPanel.CSDControl banquetRow6 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024EE RID: 9454
		private CustomSelfDrawPanel.CSDControl banquetRow7 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024EF RID: 9455
		private CustomSelfDrawPanel.CSDControl banquetRow8 = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040024F0 RID: 9456
		private CustomSelfDrawPanel.CSDImage leftBracket1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024F1 RID: 9457
		private CustomSelfDrawPanel.CSDImage rightBracket1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024F2 RID: 9458
		private CustomSelfDrawPanel.CSDImage type1Row1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024F3 RID: 9459
		private CustomSelfDrawPanel.CSDLabel numResourcesRow1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024F4 RID: 9460
		private CustomSelfDrawPanel.CSDLabel xRow1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024F5 RID: 9461
		private CustomSelfDrawPanel.CSDImage xShadowRow1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024F6 RID: 9462
		private CustomSelfDrawPanel.CSDLabel honourRow1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024F7 RID: 9463
		private CustomSelfDrawPanel.CSDImage honourImageRow1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024F8 RID: 9464
		private CustomSelfDrawPanel.CSDButton holdBandquetRow1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040024F9 RID: 9465
		private CustomSelfDrawPanel.CSDImage leftBracket2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024FA RID: 9466
		private CustomSelfDrawPanel.CSDImage rightBracket2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024FB RID: 9467
		private CustomSelfDrawPanel.CSDImage type1Row2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024FC RID: 9468
		private CustomSelfDrawPanel.CSDImage type2Row2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040024FD RID: 9469
		private CustomSelfDrawPanel.CSDLabel numResourcesRow2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024FE RID: 9470
		private CustomSelfDrawPanel.CSDLabel xRow2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040024FF RID: 9471
		private CustomSelfDrawPanel.CSDImage xShadowRow2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002500 RID: 9472
		private CustomSelfDrawPanel.CSDLabel honourRow2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002501 RID: 9473
		private CustomSelfDrawPanel.CSDImage honourImageRow2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002502 RID: 9474
		private CustomSelfDrawPanel.CSDButton holdBandquetRow2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002503 RID: 9475
		private CustomSelfDrawPanel.CSDImage leftBracket3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002504 RID: 9476
		private CustomSelfDrawPanel.CSDImage rightBracket3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002505 RID: 9477
		private CustomSelfDrawPanel.CSDImage type1Row3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002506 RID: 9478
		private CustomSelfDrawPanel.CSDImage type2Row3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002507 RID: 9479
		private CustomSelfDrawPanel.CSDImage type3Row3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002508 RID: 9480
		private CustomSelfDrawPanel.CSDLabel numResourcesRow3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002509 RID: 9481
		private CustomSelfDrawPanel.CSDLabel xRow3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400250A RID: 9482
		private CustomSelfDrawPanel.CSDImage xShadowRow3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400250B RID: 9483
		private CustomSelfDrawPanel.CSDLabel honourRow3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400250C RID: 9484
		private CustomSelfDrawPanel.CSDImage honourImageRow3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400250D RID: 9485
		private CustomSelfDrawPanel.CSDButton holdBandquetRow3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400250E RID: 9486
		private CustomSelfDrawPanel.CSDImage leftBracket4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400250F RID: 9487
		private CustomSelfDrawPanel.CSDImage rightBracket4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002510 RID: 9488
		private CustomSelfDrawPanel.CSDImage type1Row4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002511 RID: 9489
		private CustomSelfDrawPanel.CSDImage type2Row4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002512 RID: 9490
		private CustomSelfDrawPanel.CSDImage type3Row4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002513 RID: 9491
		private CustomSelfDrawPanel.CSDImage type4Row4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002514 RID: 9492
		private CustomSelfDrawPanel.CSDLabel numResourcesRow4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002515 RID: 9493
		private CustomSelfDrawPanel.CSDLabel xRow4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002516 RID: 9494
		private CustomSelfDrawPanel.CSDImage xShadowRow4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002517 RID: 9495
		private CustomSelfDrawPanel.CSDLabel honourRow4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002518 RID: 9496
		private CustomSelfDrawPanel.CSDImage honourImageRow4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002519 RID: 9497
		private CustomSelfDrawPanel.CSDButton holdBandquetRow4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400251A RID: 9498
		private CustomSelfDrawPanel.CSDImage leftBracket5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400251B RID: 9499
		private CustomSelfDrawPanel.CSDImage rightBracket5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400251C RID: 9500
		private CustomSelfDrawPanel.CSDImage type1Row5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400251D RID: 9501
		private CustomSelfDrawPanel.CSDImage type2Row5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400251E RID: 9502
		private CustomSelfDrawPanel.CSDImage type3Row5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400251F RID: 9503
		private CustomSelfDrawPanel.CSDImage type4Row5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002520 RID: 9504
		private CustomSelfDrawPanel.CSDImage type5Row5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002521 RID: 9505
		private CustomSelfDrawPanel.CSDLabel numResourcesRow5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002522 RID: 9506
		private CustomSelfDrawPanel.CSDLabel xRow5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002523 RID: 9507
		private CustomSelfDrawPanel.CSDImage xShadowRow5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002524 RID: 9508
		private CustomSelfDrawPanel.CSDLabel honourRow5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002525 RID: 9509
		private CustomSelfDrawPanel.CSDImage honourImageRow5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002526 RID: 9510
		private CustomSelfDrawPanel.CSDButton holdBandquetRow5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002527 RID: 9511
		private CustomSelfDrawPanel.CSDImage leftBracket6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002528 RID: 9512
		private CustomSelfDrawPanel.CSDImage rightBracket6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002529 RID: 9513
		private CustomSelfDrawPanel.CSDImage type1Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252A RID: 9514
		private CustomSelfDrawPanel.CSDImage type2Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252B RID: 9515
		private CustomSelfDrawPanel.CSDImage type3Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252C RID: 9516
		private CustomSelfDrawPanel.CSDImage type4Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252D RID: 9517
		private CustomSelfDrawPanel.CSDImage type5Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252E RID: 9518
		private CustomSelfDrawPanel.CSDImage type6Row6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400252F RID: 9519
		private CustomSelfDrawPanel.CSDLabel numResourcesRow6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002530 RID: 9520
		private CustomSelfDrawPanel.CSDLabel xRow6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002531 RID: 9521
		private CustomSelfDrawPanel.CSDImage xShadowRow6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002532 RID: 9522
		private CustomSelfDrawPanel.CSDLabel honourRow6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002533 RID: 9523
		private CustomSelfDrawPanel.CSDImage honourImageRow6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002534 RID: 9524
		private CustomSelfDrawPanel.CSDButton holdBandquetRow6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002535 RID: 9525
		private CustomSelfDrawPanel.CSDImage leftBracket7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002536 RID: 9526
		private CustomSelfDrawPanel.CSDImage rightBracket7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002537 RID: 9527
		private CustomSelfDrawPanel.CSDImage type1Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002538 RID: 9528
		private CustomSelfDrawPanel.CSDImage type2Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002539 RID: 9529
		private CustomSelfDrawPanel.CSDImage type3Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400253A RID: 9530
		private CustomSelfDrawPanel.CSDImage type4Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400253B RID: 9531
		private CustomSelfDrawPanel.CSDImage type5Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400253C RID: 9532
		private CustomSelfDrawPanel.CSDImage type6Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400253D RID: 9533
		private CustomSelfDrawPanel.CSDImage type7Row7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400253E RID: 9534
		private CustomSelfDrawPanel.CSDLabel numResourcesRow7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400253F RID: 9535
		private CustomSelfDrawPanel.CSDLabel xRow7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002540 RID: 9536
		private CustomSelfDrawPanel.CSDImage xShadowRow7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002541 RID: 9537
		private CustomSelfDrawPanel.CSDLabel honourRow7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002542 RID: 9538
		private CustomSelfDrawPanel.CSDImage honourImageRow7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002543 RID: 9539
		private CustomSelfDrawPanel.CSDButton holdBandquetRow7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002544 RID: 9540
		private CustomSelfDrawPanel.CSDImage leftBracket8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002545 RID: 9541
		private CustomSelfDrawPanel.CSDImage rightBracket8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002546 RID: 9542
		private CustomSelfDrawPanel.CSDImage type1Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002547 RID: 9543
		private CustomSelfDrawPanel.CSDImage type2Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002548 RID: 9544
		private CustomSelfDrawPanel.CSDImage type3Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002549 RID: 9545
		private CustomSelfDrawPanel.CSDImage type4Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400254A RID: 9546
		private CustomSelfDrawPanel.CSDImage type5Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400254B RID: 9547
		private CustomSelfDrawPanel.CSDImage type6Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400254C RID: 9548
		private CustomSelfDrawPanel.CSDImage type7Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400254D RID: 9549
		private CustomSelfDrawPanel.CSDImage type8Row8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400254E RID: 9550
		private CustomSelfDrawPanel.CSDLabel numResourcesRow8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400254F RID: 9551
		private CustomSelfDrawPanel.CSDLabel xRow8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002550 RID: 9552
		private CustomSelfDrawPanel.CSDImage xShadowRow8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002551 RID: 9553
		private CustomSelfDrawPanel.CSDLabel honourRow8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002552 RID: 9554
		private CustomSelfDrawPanel.CSDImage honourImageRow8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002553 RID: 9555
		private CustomSelfDrawPanel.CSDButton holdBandquetRow8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002554 RID: 9556
		private CustomSelfDrawPanel.CSDExtendingPanel noResearchWindow = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002555 RID: 9557
		private CustomSelfDrawPanel.CSDLabel noResearchText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002556 RID: 9558
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04002557 RID: 9559
		private DockableControl dockableControl;

		// Token: 0x04002558 RID: 9560
		private IContainer components;
	}
}
