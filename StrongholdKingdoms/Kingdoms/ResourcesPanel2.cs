using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000479 RID: 1145
	public class ResourcesPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x0600299B RID: 10651 RVA: 0x001FEE34 File Offset: 0x001FD034
		public ResourcesPanel2()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600299C RID: 10652 RVA: 0x001FF284 File Offset: 0x001FD484
		public void init()
		{
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.goods_background;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("ResourcesPanel_Resources", "Resources"));
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(948, 10);
			this.closeButton.CustomTooltipID = 900;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "ResourcesPanel2_close");
			this.mainBackgroundArea.addControl(this.closeButton);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 3, new Point(898, 10));
			Color color = Color.FromArgb(255, 230, 167);
			Color dropShadowColor = Color.FromArgb(85, 76, 55);
			this.stockpileHeaderLabel.Text = SK.Text("BuildingTypes_Stockpile", "Stockpile");
			this.stockpileHeaderLabel.Color = color;
			this.stockpileHeaderLabel.DropShadowColor = dropShadowColor;
			this.stockpileHeaderLabel.Position = new Point(13, 63);
			this.stockpileHeaderLabel.Size = new Size(325, 50);
			this.stockpileHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.stockpileHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.stockpileHeaderLabel);
			this.stockpileLimitLabel.Text = "(0)";
			this.stockpileLimitLabel.Color = Color.FromArgb(255, 230, 167);
			this.stockpileLimitLabel.DropShadowColor = Color.FromArgb(85, 76, 55);
			this.stockpileLimitLabel.Position = new Point(13, 83);
			this.stockpileLimitLabel.Size = new Size(325, 50);
			this.stockpileLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.stockpileLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.stockpileLimitLabel);
			this.woodLabel.Text = "0";
			this.woodLabel.Color = global::ARGBColors.Black;
			this.woodLabel.Position = new Point(13, 151);
			this.woodLabel.Size = new Size(81, 50);
			this.woodLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.woodLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.woodLabel);
			this.stoneLabel.Text = "0";
			this.stoneLabel.Color = global::ARGBColors.Black;
			this.stoneLabel.Position = new Point(93, 151);
			this.stoneLabel.Size = new Size(81, 50);
			this.stoneLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.stoneLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.stoneLabel);
			this.ironLabel.Text = "0";
			this.ironLabel.Color = global::ARGBColors.Black;
			this.ironLabel.Position = new Point(173, 151);
			this.ironLabel.Size = new Size(81, 50);
			this.ironLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.ironLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.ironLabel);
			this.pitchLabel.Text = "0";
			this.pitchLabel.Color = global::ARGBColors.Black;
			this.pitchLabel.Position = new Point(253, 151);
			this.pitchLabel.Size = new Size(81, 50);
			this.pitchLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.pitchLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.pitchLabel);
			this.woodImage.Image = GFXLibrary.com_32_wood_DS;
			this.woodImage.Position = new Point(53 - this.woodImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.woodImage);
			this.stoneImage.Image = GFXLibrary.com_32_stone_DS;
			this.stoneImage.Position = new Point(133 - this.stoneImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.stoneImage);
			this.ironImage.Image = GFXLibrary.com_32_iron_DS;
			this.ironImage.Position = new Point(213 - this.ironImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.ironImage);
			this.pitchImage.Image = GFXLibrary.com_32_pitch_DS;
			this.pitchImage.Position = new Point(293 - this.pitchImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.pitchImage);
			this.woodClickArea.Position = new Point(this.woodLabel.X, this.woodLabel.Y - 50);
			this.woodClickArea.Size = new Size(80, 70);
			this.woodClickArea.Data = 6;
			this.woodClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.woodClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.woodClickArea);
			this.stoneClickArea.Position = new Point(this.stoneLabel.X, this.stoneLabel.Y - 50);
			this.stoneClickArea.Size = new Size(80, 70);
			this.stoneClickArea.Data = 7;
			this.stoneClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.stoneClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.stoneClickArea);
			this.ironClickArea.Position = new Point(this.ironLabel.X, this.ironLabel.Y - 50);
			this.ironClickArea.Size = new Size(80, 70);
			this.ironClickArea.Data = 8;
			this.ironClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.ironClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.ironClickArea);
			this.pitchClickArea.Position = new Point(this.pitchLabel.X, this.pitchLabel.Y - 50);
			this.pitchClickArea.Size = new Size(80, 70);
			this.pitchClickArea.Data = 9;
			this.pitchClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.pitchClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.pitchClickArea);
			this.hallHeaderLabel.Text = SK.Text("BuildingTypes_Village_Hall", "Village Hall");
			this.hallHeaderLabel.Color = color;
			this.hallHeaderLabel.DropShadowColor = dropShadowColor;
			this.hallHeaderLabel.Position = new Point(348, 63);
			this.hallHeaderLabel.Size = new Size(633, 50);
			this.hallHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.hallHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.hallHeaderLabel);
			this.hallLimitLabel.Text = "(0)";
			this.hallLimitLabel.Color = Color.FromArgb(255, 230, 167);
			this.hallLimitLabel.DropShadowColor = Color.FromArgb(85, 76, 55);
			this.hallLimitLabel.Position = new Point(348, 83);
			this.hallLimitLabel.Size = new Size(633, 50);
			this.hallLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.hallLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.hallLimitLabel);
			this.venisonLabel.Text = "0";
			this.venisonLabel.Color = global::ARGBColors.Black;
			this.venisonLabel.Position = new Point(348, 151);
			this.venisonLabel.Size = new Size(81, 50);
			this.venisonLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.venisonLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.venisonLabel);
			this.furnitureLabel.Text = "0";
			this.furnitureLabel.Color = global::ARGBColors.Black;
			this.furnitureLabel.Position = new Point(427, 151);
			this.furnitureLabel.Size = new Size(81, 50);
			this.furnitureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.furnitureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.furnitureLabel);
			this.metalwareLabel.Text = "0";
			this.metalwareLabel.Color = global::ARGBColors.Black;
			this.metalwareLabel.Position = new Point(506, 151);
			this.metalwareLabel.Size = new Size(81, 50);
			this.metalwareLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.metalwareLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.metalwareLabel);
			this.clothesLabel.Text = "0";
			this.clothesLabel.Color = global::ARGBColors.Black;
			this.clothesLabel.Position = new Point(585, 151);
			this.clothesLabel.Size = new Size(81, 50);
			this.clothesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.clothesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.clothesLabel);
			this.wineLabel.Text = "0";
			this.wineLabel.Color = global::ARGBColors.Black;
			this.wineLabel.Position = new Point(664, 151);
			this.wineLabel.Size = new Size(81, 50);
			this.wineLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.wineLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.wineLabel);
			this.saltLabel.Text = "0";
			this.saltLabel.Color = global::ARGBColors.Black;
			this.saltLabel.Position = new Point(743, 151);
			this.saltLabel.Size = new Size(81, 50);
			this.saltLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.saltLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.saltLabel);
			this.spicesLabel.Text = "0";
			this.spicesLabel.Color = global::ARGBColors.Black;
			this.spicesLabel.Position = new Point(822, 151);
			this.spicesLabel.Size = new Size(81, 50);
			this.spicesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.spicesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.spicesLabel);
			this.silkLabel.Text = "0";
			this.silkLabel.Color = global::ARGBColors.Black;
			this.silkLabel.Position = new Point(901, 151);
			this.silkLabel.Size = new Size(81, 50);
			this.silkLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.silkLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.silkLabel);
			this.venisonImage.Image = GFXLibrary.com_32_venison_DS;
			this.venisonImage.Position = new Point(387 - this.venisonImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.venisonImage);
			this.furnitureImage.Image = GFXLibrary.com_32_furniture_DS;
			this.furnitureImage.Position = new Point(466 - this.furnitureImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.furnitureImage);
			this.metalwareImage.Image = GFXLibrary.com_32_metalware_DS;
			this.metalwareImage.Position = new Point(545 - this.metalwareImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.metalwareImage);
			this.clothesImage.Image = GFXLibrary.com_32_clothes_DS;
			this.clothesImage.Position = new Point(624 - this.clothesImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.clothesImage);
			this.wineImage.Image = GFXLibrary.com_32_wine_DS;
			this.wineImage.Position = new Point(703 - this.wineImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.wineImage);
			this.saltImage.Image = GFXLibrary.com_32_salt_DS;
			this.saltImage.Position = new Point(782 - this.saltImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.saltImage);
			this.spicesImage.Image = GFXLibrary.com_32_spices_DS;
			this.spicesImage.Position = new Point(861 - this.spicesImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.spicesImage);
			this.silkImage.Image = GFXLibrary.com_32_silk_DS;
			this.silkImage.Position = new Point(940 - this.silkImage.Size.Width / 2, 102);
			this.mainBackgroundArea.addControl(this.silkImage);
			this.venisonClickArea.Position = new Point(this.venisonLabel.X, this.venisonLabel.Y - 50);
			this.venisonClickArea.Size = new Size(79, 70);
			this.venisonClickArea.Data = 22;
			this.venisonClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.venisonClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.venisonClickArea);
			this.furnitureClickArea.Position = new Point(this.furnitureLabel.X, this.furnitureLabel.Y - 50);
			this.furnitureClickArea.Size = new Size(79, 70);
			this.furnitureClickArea.Data = 21;
			this.furnitureClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.furnitureClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.furnitureClickArea);
			this.metalwareClickArea.Position = new Point(this.metalwareLabel.X, this.metalwareLabel.Y - 50);
			this.metalwareClickArea.Size = new Size(79, 70);
			this.metalwareClickArea.Data = 26;
			this.metalwareClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.metalwareClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.metalwareClickArea);
			this.clothesClickArea.Position = new Point(this.clothesLabel.X, this.clothesLabel.Y - 50);
			this.clothesClickArea.Size = new Size(79, 70);
			this.clothesClickArea.Data = 19;
			this.clothesClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.clothesClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.clothesClickArea);
			this.wineClickArea.Position = new Point(this.wineLabel.X, this.wineLabel.Y - 50);
			this.wineClickArea.Size = new Size(79, 70);
			this.wineClickArea.Data = 33;
			this.wineClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.wineClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.wineClickArea);
			this.saltClickArea.Position = new Point(this.saltLabel.X, this.saltLabel.Y - 50);
			this.saltClickArea.Size = new Size(79, 70);
			this.saltClickArea.Data = 23;
			this.saltClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.saltClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.saltClickArea);
			this.spicesClickArea.Position = new Point(this.spicesLabel.X, this.spicesLabel.Y - 50);
			this.spicesClickArea.Size = new Size(79, 70);
			this.spicesClickArea.Data = 24;
			this.spicesClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.spicesClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.spicesClickArea);
			this.silkClickArea.Position = new Point(this.silkLabel.X, this.silkLabel.Y - 50);
			this.silkClickArea.Size = new Size(79, 70);
			this.silkClickArea.Data = 25;
			this.silkClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.silkClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.silkClickArea);
			this.granaryHeaderLabel.Text = SK.Text("BuildingTypes_Granary", "Granary");
			this.granaryHeaderLabel.Color = color;
			this.granaryHeaderLabel.DropShadowColor = dropShadowColor;
			this.granaryHeaderLabel.Position = new Point(13, 225);
			this.granaryHeaderLabel.Size = new Size(478, 50);
			this.granaryHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.granaryHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.granaryHeaderLabel);
			this.granaryLimitLabel.Text = "(0)";
			this.granaryLimitLabel.Color = Color.FromArgb(255, 230, 167);
			this.granaryLimitLabel.DropShadowColor = Color.FromArgb(85, 76, 55);
			this.granaryLimitLabel.Position = new Point(13, 245);
			this.granaryLimitLabel.Size = new Size(478, 50);
			this.granaryLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.granaryLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.granaryLimitLabel);
			this.applesLabel.Text = "0";
			this.applesLabel.Color = global::ARGBColors.Black;
			this.applesLabel.Position = new Point(13, 313);
			this.applesLabel.Size = new Size(81, 50);
			this.applesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.applesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.applesLabel);
			this.cheeseLabel.Text = "0";
			this.cheeseLabel.Color = global::ARGBColors.Black;
			this.cheeseLabel.Position = new Point(93, 313);
			this.cheeseLabel.Size = new Size(81, 50);
			this.cheeseLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.cheeseLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.cheeseLabel);
			this.meatLabel.Text = "0";
			this.meatLabel.Color = global::ARGBColors.Black;
			this.meatLabel.Position = new Point(173, 313);
			this.meatLabel.Size = new Size(81, 50);
			this.meatLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.meatLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.meatLabel);
			this.vegLabel.Text = "0";
			this.vegLabel.Color = global::ARGBColors.Black;
			this.vegLabel.Position = new Point(333, 313);
			this.vegLabel.Size = new Size(81, 50);
			this.vegLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.vegLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.vegLabel);
			this.breadLabel.Text = "0";
			this.breadLabel.Color = global::ARGBColors.Black;
			this.breadLabel.Position = new Point(253, 313);
			this.breadLabel.Size = new Size(81, 50);
			this.breadLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.breadLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.breadLabel);
			this.fishLabel.Text = "0";
			this.fishLabel.Color = global::ARGBColors.Black;
			this.fishLabel.Position = new Point(413, 313);
			this.fishLabel.Size = new Size(81, 50);
			this.fishLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.fishLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.fishLabel);
			this.applesImage.Image = GFXLibrary.com_32_apples_DS;
			this.applesImage.Position = new Point(53 - this.applesImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.applesImage);
			this.cheeseImage.Image = GFXLibrary.com_32_cheese_DS;
			this.cheeseImage.Position = new Point(133 - this.cheeseImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.cheeseImage);
			this.meatImage.Image = GFXLibrary.com_32_meat_DS;
			this.meatImage.Position = new Point(213 - this.meatImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.meatImage);
			this.vegImage.Image = GFXLibrary.com_32_veg_DS;
			this.vegImage.Position = new Point(373 - this.vegImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.vegImage);
			this.breadImage.Image = GFXLibrary.com_32_bread_DS;
			this.breadImage.Position = new Point(293 - this.breadImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.breadImage);
			this.fishImage.Image = GFXLibrary.com_32_fish_DS;
			this.fishImage.Position = new Point(453 - this.fishImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.fishImage);
			this.applesClickArea.Position = new Point(this.applesLabel.X, this.applesLabel.Y - 50);
			this.applesClickArea.Size = new Size(80, 70);
			this.applesClickArea.Data = 13;
			this.applesClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.applesClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.applesClickArea);
			this.cheeseClickArea.Position = new Point(this.cheeseLabel.X, this.cheeseLabel.Y - 50);
			this.cheeseClickArea.Size = new Size(80, 70);
			this.cheeseClickArea.Data = 17;
			this.cheeseClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.cheeseClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.cheeseClickArea);
			this.meatClickArea.Position = new Point(this.meatLabel.X, this.meatLabel.Y - 50);
			this.meatClickArea.Size = new Size(80, 70);
			this.meatClickArea.Data = 16;
			this.meatClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.meatClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.meatClickArea);
			this.vegClickArea.Position = new Point(this.vegLabel.X, this.vegLabel.Y - 50);
			this.vegClickArea.Size = new Size(80, 70);
			this.vegClickArea.Data = 15;
			this.vegClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.vegClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.vegClickArea);
			this.breadClickArea.Position = new Point(this.breadLabel.X, this.breadLabel.Y - 50);
			this.breadClickArea.Size = new Size(80, 70);
			this.breadClickArea.Data = 14;
			this.breadClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.breadClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.breadClickArea);
			this.fishClickArea.Position = new Point(this.fishLabel.X, this.fishLabel.Y - 50);
			this.fishClickArea.Size = new Size(80, 70);
			this.fishClickArea.Data = 18;
			this.fishClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.fishClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.fishClickArea);
			this.innHeaderLabel.Text = SK.Text("BuildingTypes_Inn", "Inn");
			this.innHeaderLabel.Color = color;
			this.innHeaderLabel.DropShadowColor = dropShadowColor;
			this.innHeaderLabel.Position = new Point(475, 225);
			this.innHeaderLabel.Size = new Size(122, 50);
			this.innHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.innHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.innHeaderLabel);
			this.innLimitLabel.Text = "(0)";
			this.innLimitLabel.Color = Color.FromArgb(255, 230, 167);
			this.innLimitLabel.DropShadowColor = Color.FromArgb(85, 76, 55);
			this.innLimitLabel.Position = new Point(500, 245);
			this.innLimitLabel.Size = new Size(72, 50);
			this.innLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.innLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.innLimitLabel);
			this.aleLabel.Text = "0";
			this.aleLabel.Color = global::ARGBColors.Black;
			this.aleLabel.Position = new Point(475, 313);
			this.aleLabel.Size = new Size(122, 50);
			this.aleLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.aleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.aleLabel);
			this.aleImage.Image = GFXLibrary.com_32_ale_DS;
			this.aleImage.Position = new Point(536 - this.aleImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.aleImage);
			this.aleClickArea.Position = new Point(this.aleLabel.X, this.aleLabel.Y - 50);
			this.aleClickArea.Size = new Size(72, 70);
			this.aleClickArea.Data = 12;
			this.aleClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.aleClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.aleClickArea);
			this.armouryHeaderLabel.Text = SK.Text("BuildingTypes_Armoury", "Armoury");
			this.armouryHeaderLabel.Color = color;
			this.armouryHeaderLabel.DropShadowColor = dropShadowColor;
			this.armouryHeaderLabel.Position = new Point(583, 225);
			this.armouryHeaderLabel.Size = new Size(398, 50);
			this.armouryHeaderLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.armouryHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.armouryHeaderLabel);
			this.armouryLimitLabel.Text = "(0)";
			this.armouryLimitLabel.Color = Color.FromArgb(255, 230, 167);
			this.armouryLimitLabel.DropShadowColor = Color.FromArgb(85, 76, 55);
			this.armouryLimitLabel.Position = new Point(583, 245);
			this.armouryLimitLabel.Size = new Size(398, 50);
			this.armouryLimitLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.armouryLimitLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.armouryLimitLabel);
			this.bowsLabel.Text = "0";
			this.bowsLabel.Color = global::ARGBColors.Black;
			this.bowsLabel.Position = new Point(583, 313);
			this.bowsLabel.Size = new Size(81, 50);
			this.bowsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bowsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.bowsLabel);
			this.pikesLabel.Text = "0";
			this.pikesLabel.Color = global::ARGBColors.Black;
			this.pikesLabel.Position = new Point(663, 313);
			this.pikesLabel.Size = new Size(81, 50);
			this.pikesLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.pikesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.pikesLabel);
			this.armourLabel.Text = "0";
			this.armourLabel.Color = global::ARGBColors.Black;
			this.armourLabel.Position = new Point(743, 313);
			this.armourLabel.Size = new Size(81, 50);
			this.armourLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.armourLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.armourLabel);
			this.swordsLabel.Text = "0";
			this.swordsLabel.Color = global::ARGBColors.Black;
			this.swordsLabel.Position = new Point(823, 313);
			this.swordsLabel.Size = new Size(81, 50);
			this.swordsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.swordsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.swordsLabel);
			this.catapultsLabel.Text = "0";
			this.catapultsLabel.Color = global::ARGBColors.Black;
			this.catapultsLabel.Position = new Point(903, 313);
			this.catapultsLabel.Size = new Size(81, 50);
			this.catapultsLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.catapultsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.mainBackgroundArea.addControl(this.catapultsLabel);
			this.bowsImage.Image = GFXLibrary.com_32_bows_DS;
			this.bowsImage.Position = new Point(623 - this.bowsImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.bowsImage);
			this.pikesImage.Image = GFXLibrary.com_32_pikes_DS;
			this.pikesImage.Position = new Point(703 - this.pikesImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.pikesImage);
			this.armourImage.Image = GFXLibrary.com_32_armour_DS;
			this.armourImage.Position = new Point(783 - this.armourImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.armourImage);
			this.swordsImage.Image = GFXLibrary.com_32_swords_DS;
			this.swordsImage.Position = new Point(863 - this.swordsImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.swordsImage);
			this.catapultsImage.Image = GFXLibrary.com_32_catapults_DS;
			this.catapultsImage.Position = new Point(943 - this.catapultsImage.Size.Width / 2, 264);
			this.mainBackgroundArea.addControl(this.catapultsImage);
			this.bowsClickArea.Position = new Point(this.bowsLabel.X, this.bowsLabel.Y - 50);
			this.bowsClickArea.Size = new Size(80, 70);
			this.bowsClickArea.Data = 29;
			this.bowsClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.bowsClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.bowsClickArea);
			this.pikesClickArea.Position = new Point(this.pikesLabel.X, this.pikesLabel.Y - 50);
			this.pikesClickArea.Size = new Size(80, 70);
			this.pikesClickArea.Data = 28;
			this.pikesClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.pikesClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.pikesClickArea);
			this.armourClickArea.Position = new Point(this.armourLabel.X, this.armourLabel.Y - 50);
			this.armourClickArea.Size = new Size(80, 70);
			this.armourClickArea.Data = 31;
			this.armourClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.armourClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.armourClickArea);
			this.swordsClickArea.Position = new Point(this.swordsLabel.X, this.swordsLabel.Y - 50);
			this.swordsClickArea.Size = new Size(80, 70);
			this.swordsClickArea.Data = 30;
			this.swordsClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.swordsClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.swordsClickArea);
			this.catapultsClickArea.Position = new Point(this.catapultsLabel.X, this.catapultsLabel.Y - 50);
			this.catapultsClickArea.Size = new Size(80, 70);
			this.catapultsClickArea.Data = 32;
			this.catapultsClickArea.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.resourceClicked));
			this.catapultsClickArea.CustomTooltipID = 901;
			this.mainBackgroundArea.addControl(this.catapultsClickArea);
			this.selectedHeadingLabel.Text = SK.Text("ResourcesPanel_Resources", "Resources");
			this.selectedHeadingLabel.Color = Color.FromArgb(224, 203, 146);
			this.selectedHeadingLabel.DropShadowColor = Color.FromArgb(74, 67, 48);
			this.selectedHeadingLabel.Position = new Point(118, 364);
			this.selectedHeadingLabel.Size = new Size(992, 50);
			this.selectedHeadingLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.selectedHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.selectedHeadingLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.selectedHeadingLabel);
			this.selectedResource = -1;
			this.selectedImage.Image = GFXLibrary.com_32_fish_DS;
			this.selectedImage.Position = new Point(25, 354);
			this.selectedImage.Visible = false;
			this.mainBackgroundArea.addControl(this.selectedImage);
			this.dailyProductionHeadingLabel.Text = SK.Text("ResourcesPanel_Daily_Production", "Daily Production") + " :";
			this.dailyProductionHeadingLabel.Color = global::ARGBColors.Black;
			this.dailyProductionHeadingLabel.Position = new Point(63, 441);
			this.dailyProductionHeadingLabel.Size = new Size(400, 50);
			this.dailyProductionHeadingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.dailyProductionHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.dailyProductionHeadingLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.dailyProductionHeadingLabel);
			this.totalBuildingsHeadingLabel.Text = SK.Text("ResourcesPanel_Number_Of_Buildings", "Number of Buildings") + " :";
			this.totalBuildingsHeadingLabel.Color = global::ARGBColors.Black;
			this.totalBuildingsHeadingLabel.Position = new Point(63, 466);
			this.totalBuildingsHeadingLabel.Size = new Size(400, 50);
			this.totalBuildingsHeadingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.totalBuildingsHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.totalBuildingsHeadingLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.totalBuildingsHeadingLabel);
			this.workingBuildingsHeadingLabel.Text = SK.Text("ResourcesPanel_Number_Of_Working_Buildings", "Number of Working Buildings") + " :";
			this.workingBuildingsHeadingLabel.Color = global::ARGBColors.Black;
			this.workingBuildingsHeadingLabel.Position = new Point(63, 491);
			this.workingBuildingsHeadingLabel.Size = new Size(400, 50);
			this.workingBuildingsHeadingLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.workingBuildingsHeadingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.workingBuildingsHeadingLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.workingBuildingsHeadingLabel);
			this.dailyProductionValueLabel.Text = "0";
			this.dailyProductionValueLabel.Color = global::ARGBColors.Black;
			this.dailyProductionValueLabel.Position = new Point(330, 441);
			this.dailyProductionValueLabel.Size = new Size(400, 50);
			this.dailyProductionValueLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.dailyProductionValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.dailyProductionValueLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.dailyProductionValueLabel);
			this.totalBuildingsValueLabel.Text = "0";
			this.totalBuildingsValueLabel.Color = global::ARGBColors.Black;
			this.totalBuildingsValueLabel.Position = new Point(330, 466);
			this.totalBuildingsValueLabel.Size = new Size(400, 50);
			this.totalBuildingsValueLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.totalBuildingsValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.totalBuildingsValueLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.totalBuildingsValueLabel);
			this.workingBuildingsValueLabel.Text = "0";
			this.workingBuildingsValueLabel.Color = global::ARGBColors.Black;
			this.workingBuildingsValueLabel.Position = new Point(330, 491);
			this.workingBuildingsValueLabel.Size = new Size(400, 50);
			this.workingBuildingsValueLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.workingBuildingsValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.workingBuildingsValueLabel.Visible = false;
			this.mainBackgroundArea.addControl(this.workingBuildingsValueLabel);
			this.cardbar.Position = new Point(0, 0);
			this.mainBackgroundArea.addControl(this.cardbar);
			this.cardbar.init(4);
			this.update();
		}

		// Token: 0x0600299D RID: 10653 RVA: 0x00201FCC File Offset: 0x002001CC
		public void update()
		{
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				NumberFormatInfo nfi = GameEngine.NFI;
				VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
				village.getStockpileLevels(stockpileLevels);
				VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
				village.getGranaryLevels(granaryLevels);
				VillageMap.ArmouryLevels armouryLevels = new VillageMap.ArmouryLevels();
				village.getArmouryLevels(armouryLevels);
				VillageMap.TownHallLevels townHallLevels = new VillageMap.TownHallLevels();
				village.getTownHallLevels(townHallLevels);
				VillageMap.InnLevels innLevels = new VillageMap.InnLevels();
				village.getInnLevels(innLevels);
				this.woodLabel.Text = stockpileLevels.woodLevel.ToString("N", nfi);
				this.stoneLabel.Text = stockpileLevels.stoneLevel.ToString("N", nfi);
				this.pitchLabel.Text = stockpileLevels.pitchLevel.ToString("N", nfi);
				this.ironLabel.Text = stockpileLevels.ironLevel.ToString("N", nfi);
				this.aleLabel.Text = innLevels.aleLevel.ToString("N", nfi);
				this.applesLabel.Text = granaryLevels.applesLevel.ToString("N", nfi);
				this.breadLabel.Text = granaryLevels.breadLevel.ToString("N", nfi);
				this.cheeseLabel.Text = granaryLevels.cheeseLevel.ToString("N", nfi);
				this.meatLabel.Text = granaryLevels.meatLevel.ToString("N", nfi);
				this.vegLabel.Text = granaryLevels.vegLevel.ToString("N", nfi);
				this.fishLabel.Text = granaryLevels.fishLevel.ToString("N", nfi);
				this.bowsLabel.Text = armouryLevels.bowsLevel.ToString("N", nfi);
				this.pikesLabel.Text = armouryLevels.pikesLevel.ToString("N", nfi);
				this.swordsLabel.Text = armouryLevels.swordsLevel.ToString("N", nfi);
				this.armourLabel.Text = armouryLevels.armourLevel.ToString("N", nfi);
				this.catapultsLabel.Text = armouryLevels.catapultsLevel.ToString("N", nfi);
				this.clothesLabel.Text = townHallLevels.clothesLevel.ToString("N", nfi);
				this.furnitureLabel.Text = townHallLevels.furnitureLevel.ToString("N", nfi);
				this.saltLabel.Text = townHallLevels.saltLevel.ToString("N", nfi);
				this.wineLabel.Text = townHallLevels.wineLevel.ToString("N", nfi);
				this.venisonLabel.Text = townHallLevels.venisonLevel.ToString("N", nfi);
				this.spicesLabel.Text = townHallLevels.spicesLevel.ToString("N", nfi);
				this.silkLabel.Text = townHallLevels.silkLevel.ToString("N", nfi);
				this.metalwareLabel.Text = townHallLevels.metalwareLevel.ToString("N", nfi);
				this.stockpileLimitLabel.Text = "(" + this.getCap(6).ToString("N", nfi) + ")";
				this.innLimitLabel.Text = "(" + this.getCap(12).ToString("N", nfi) + ")";
				this.granaryLimitLabel.Text = "(" + this.getCap(13).ToString("N", nfi) + ")";
				this.armouryLimitLabel.Text = "(" + this.getCap(29).ToString("N", nfi) + ")";
				this.hallLimitLabel.Text = "(" + this.getCap(23).ToString("N", nfi) + ")";
				if (this.selectedResource >= 0)
				{
					int num = (int)village.getResourceLevel(this.selectedResource);
					this.selectedHeadingLabel.Text = VillageBuildingsData.getResourceNames(this.selectedResource) + ": " + num.ToString("N", nfi);
					double resourceProductionPerDay = village.getResourceProductionPerDay(this.selectedResource);
					this.dailyProductionValueLabel.Text = ((int)resourceProductionPerDay).ToString("N", nfi);
					this.totalBuildingsValueLabel.Text = village.numBuildingsOfType(this.selectedResource).ToString("N", nfi);
					this.workingBuildingsValueLabel.Text = village.numWorkingBuildingsOfType(this.selectedResource).ToString("N", nfi);
				}
				this.cardbar.update();
			}
		}

		// Token: 0x0600299E RID: 10654 RVA: 0x002024AC File Offset: 0x002006AC
		private int getCap(int resourceType)
		{
			double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, resourceType, false);
			num *= CardTypes.getResourceCapMultiplier(resourceType, GameEngine.Instance.cardsManager.UserCardData);
			return (int)num;
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x002024F4 File Offset: 0x002006F4
		private void resourceClicked()
		{
			if (this.ClickedControl != null)
			{
				CustomSelfDrawPanel.CSDControl clickedControl = this.ClickedControl;
				this.selectedResource = clickedControl.Data;
				switch (this.selectedResource)
				{
				case 6:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_wood");
					break;
				case 7:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_stone");
					break;
				case 8:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_iron");
					break;
				case 9:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_pitch");
					break;
				case 12:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_ale");
					break;
				case 13:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_apples");
					break;
				case 14:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_bread");
					break;
				case 15:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_veg");
					break;
				case 16:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_meat");
					break;
				case 17:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_cheese");
					break;
				case 18:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_fish");
					break;
				case 19:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_clothes");
					break;
				case 21:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_furniture");
					break;
				case 22:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_venison");
					break;
				case 23:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_salt");
					break;
				case 24:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_spices");
					break;
				case 25:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_silk");
					break;
				case 26:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_metalware");
					break;
				case 28:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_pikes");
					break;
				case 29:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_bows");
					break;
				case 30:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_swords");
					break;
				case 31:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_armour");
					break;
				case 32:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_catapult");
					break;
				case 33:
					GameEngine.Instance.playInterfaceSound("ResourcesPanel2_resource_clicked_wine");
					break;
				}
				this.selectedHeadingLabel.Visible = true;
				this.selectedImage.Image = GFXLibrary.getCommodity64DSImage(this.selectedResource);
				this.selectedImage.Visible = true;
				this.dailyProductionHeadingLabel.Visible = true;
				this.dailyProductionValueLabel.Visible = true;
				this.totalBuildingsHeadingLabel.Visible = true;
				this.totalBuildingsValueLabel.Visible = true;
				this.workingBuildingsHeadingLabel.Visible = true;
				this.workingBuildingsValueLabel.Visible = true;
				this.update();
			}
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x0000B71E File Offset: 0x0000991E
		public void closeClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(-1);
		}

		// Token: 0x060029A1 RID: 10657 RVA: 0x0001E9B1 File Offset: 0x0001CBB1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060029A2 RID: 10658 RVA: 0x0001E9C1 File Offset: 0x0001CBC1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060029A3 RID: 10659 RVA: 0x0001E9D1 File Offset: 0x0001CBD1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060029A4 RID: 10660 RVA: 0x0001E9E3 File Offset: 0x0001CBE3
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060029A5 RID: 10661 RVA: 0x0001E9F0 File Offset: 0x0001CBF0
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x060029A6 RID: 10662 RVA: 0x0001EA04 File Offset: 0x0001CC04
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060029A7 RID: 10663 RVA: 0x0001EA11 File Offset: 0x0001CC11
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060029A8 RID: 10664 RVA: 0x0001EA1E File Offset: 0x0001CC1E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060029A9 RID: 10665 RVA: 0x002027EC File Offset: 0x002009EC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "ResourcesPanel2";
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x040032E5 RID: 13029
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032E6 RID: 13030
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040032E7 RID: 13031
		private CustomSelfDrawPanel.CSDLabel resourcesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032E8 RID: 13032
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040032E9 RID: 13033
		private CustomSelfDrawPanel.CSDLabel stockpileHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032EA RID: 13034
		private CustomSelfDrawPanel.CSDLabel stockpileLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032EB RID: 13035
		private CustomSelfDrawPanel.CSDLabel woodLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032EC RID: 13036
		private CustomSelfDrawPanel.CSDLabel stoneLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032ED RID: 13037
		private CustomSelfDrawPanel.CSDLabel ironLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032EE RID: 13038
		private CustomSelfDrawPanel.CSDLabel pitchLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032EF RID: 13039
		private CustomSelfDrawPanel.CSDImage woodImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032F0 RID: 13040
		private CustomSelfDrawPanel.CSDImage stoneImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032F1 RID: 13041
		private CustomSelfDrawPanel.CSDImage ironImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032F2 RID: 13042
		private CustomSelfDrawPanel.CSDImage pitchImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040032F3 RID: 13043
		private CustomSelfDrawPanel.CSDArea woodClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040032F4 RID: 13044
		private CustomSelfDrawPanel.CSDArea stoneClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040032F5 RID: 13045
		private CustomSelfDrawPanel.CSDArea ironClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040032F6 RID: 13046
		private CustomSelfDrawPanel.CSDArea pitchClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040032F7 RID: 13047
		private CustomSelfDrawPanel.CSDLabel hallHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032F8 RID: 13048
		private CustomSelfDrawPanel.CSDLabel hallLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032F9 RID: 13049
		private CustomSelfDrawPanel.CSDLabel venisonLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FA RID: 13050
		private CustomSelfDrawPanel.CSDLabel furnitureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FB RID: 13051
		private CustomSelfDrawPanel.CSDLabel metalwareLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FC RID: 13052
		private CustomSelfDrawPanel.CSDLabel clothesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FD RID: 13053
		private CustomSelfDrawPanel.CSDLabel wineLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FE RID: 13054
		private CustomSelfDrawPanel.CSDLabel saltLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040032FF RID: 13055
		private CustomSelfDrawPanel.CSDLabel spicesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003300 RID: 13056
		private CustomSelfDrawPanel.CSDLabel silkLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003301 RID: 13057
		private CustomSelfDrawPanel.CSDImage venisonImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003302 RID: 13058
		private CustomSelfDrawPanel.CSDImage furnitureImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003303 RID: 13059
		private CustomSelfDrawPanel.CSDImage metalwareImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003304 RID: 13060
		private CustomSelfDrawPanel.CSDImage clothesImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003305 RID: 13061
		private CustomSelfDrawPanel.CSDImage wineImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003306 RID: 13062
		private CustomSelfDrawPanel.CSDImage saltImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003307 RID: 13063
		private CustomSelfDrawPanel.CSDImage spicesImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003308 RID: 13064
		private CustomSelfDrawPanel.CSDImage silkImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003309 RID: 13065
		private CustomSelfDrawPanel.CSDArea venisonClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330A RID: 13066
		private CustomSelfDrawPanel.CSDArea furnitureClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330B RID: 13067
		private CustomSelfDrawPanel.CSDArea metalwareClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330C RID: 13068
		private CustomSelfDrawPanel.CSDArea clothesClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330D RID: 13069
		private CustomSelfDrawPanel.CSDArea wineClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330E RID: 13070
		private CustomSelfDrawPanel.CSDArea saltClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400330F RID: 13071
		private CustomSelfDrawPanel.CSDArea spicesClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003310 RID: 13072
		private CustomSelfDrawPanel.CSDArea silkClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003311 RID: 13073
		private CustomSelfDrawPanel.CSDLabel granaryHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003312 RID: 13074
		private CustomSelfDrawPanel.CSDLabel granaryLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003313 RID: 13075
		private CustomSelfDrawPanel.CSDLabel applesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003314 RID: 13076
		private CustomSelfDrawPanel.CSDLabel cheeseLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003315 RID: 13077
		private CustomSelfDrawPanel.CSDLabel meatLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003316 RID: 13078
		private CustomSelfDrawPanel.CSDLabel vegLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003317 RID: 13079
		private CustomSelfDrawPanel.CSDLabel breadLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003318 RID: 13080
		private CustomSelfDrawPanel.CSDLabel fishLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003319 RID: 13081
		private CustomSelfDrawPanel.CSDImage applesImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331A RID: 13082
		private CustomSelfDrawPanel.CSDImage cheeseImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331B RID: 13083
		private CustomSelfDrawPanel.CSDImage meatImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331C RID: 13084
		private CustomSelfDrawPanel.CSDImage vegImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331D RID: 13085
		private CustomSelfDrawPanel.CSDImage breadImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331E RID: 13086
		private CustomSelfDrawPanel.CSDImage fishImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400331F RID: 13087
		private CustomSelfDrawPanel.CSDArea applesClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003320 RID: 13088
		private CustomSelfDrawPanel.CSDArea cheeseClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003321 RID: 13089
		private CustomSelfDrawPanel.CSDArea meatClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003322 RID: 13090
		private CustomSelfDrawPanel.CSDArea vegClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003323 RID: 13091
		private CustomSelfDrawPanel.CSDArea breadClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003324 RID: 13092
		private CustomSelfDrawPanel.CSDArea fishClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003325 RID: 13093
		private CustomSelfDrawPanel.CSDLabel innHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003326 RID: 13094
		private CustomSelfDrawPanel.CSDLabel innLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003327 RID: 13095
		private CustomSelfDrawPanel.CSDLabel aleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003328 RID: 13096
		private CustomSelfDrawPanel.CSDImage aleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003329 RID: 13097
		private CustomSelfDrawPanel.CSDArea aleClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400332A RID: 13098
		private CustomSelfDrawPanel.CSDLabel armouryHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400332B RID: 13099
		private CustomSelfDrawPanel.CSDLabel armouryLimitLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400332C RID: 13100
		private CustomSelfDrawPanel.CSDLabel bowsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400332D RID: 13101
		private CustomSelfDrawPanel.CSDLabel pikesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400332E RID: 13102
		private CustomSelfDrawPanel.CSDLabel armourLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400332F RID: 13103
		private CustomSelfDrawPanel.CSDLabel swordsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003330 RID: 13104
		private CustomSelfDrawPanel.CSDLabel catapultsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003331 RID: 13105
		private CustomSelfDrawPanel.CSDImage bowsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003332 RID: 13106
		private CustomSelfDrawPanel.CSDImage pikesImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003333 RID: 13107
		private CustomSelfDrawPanel.CSDImage armourImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003334 RID: 13108
		private CustomSelfDrawPanel.CSDImage swordsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003335 RID: 13109
		private CustomSelfDrawPanel.CSDImage catapultsImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003336 RID: 13110
		private CustomSelfDrawPanel.CSDArea bowsClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003337 RID: 13111
		private CustomSelfDrawPanel.CSDArea pikesClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003338 RID: 13112
		private CustomSelfDrawPanel.CSDArea armourClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04003339 RID: 13113
		private CustomSelfDrawPanel.CSDArea swordsClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400333A RID: 13114
		private CustomSelfDrawPanel.CSDArea catapultsClickArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400333B RID: 13115
		private CustomSelfDrawPanel.CSDLabel selectedHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400333C RID: 13116
		private CustomSelfDrawPanel.CSDImage selectedImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400333D RID: 13117
		private CustomSelfDrawPanel.CSDLabel dailyProductionHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400333E RID: 13118
		private CustomSelfDrawPanel.CSDLabel dailyProductionValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400333F RID: 13119
		private CustomSelfDrawPanel.CSDLabel totalBuildingsHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003340 RID: 13120
		private CustomSelfDrawPanel.CSDLabel totalBuildingsValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003341 RID: 13121
		private CustomSelfDrawPanel.CSDLabel workingBuildingsHeadingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003342 RID: 13122
		private CustomSelfDrawPanel.CSDLabel workingBuildingsValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003343 RID: 13123
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x04003344 RID: 13124
		private int selectedResource = -1;

		// Token: 0x04003345 RID: 13125
		private DockableControl dockableControl;

		// Token: 0x04003346 RID: 13126
		private IContainer components;
	}
}
