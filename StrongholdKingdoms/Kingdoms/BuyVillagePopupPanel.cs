using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000F5 RID: 245
	public class BuyVillagePopupPanel : CustomSelfDrawPanel
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x000969BC File Offset: 0x00094BBC
		public BuyVillagePopupPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00096F38 File Offset: 0x00095138
		public void init(int villageID, bool buy)
		{
			this.buying = buy;
			this.m_villageID = villageID;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.backgroundBottomEdge.Image = GFXLibrary.popup_border_bottom;
			this.backgroundBottomEdge.Position = new Point(0, base.Height - 2);
			base.addControl(this.backgroundBottomEdge);
			this.backgroundRightEdge.Image = GFXLibrary.popup_border_rhs;
			this.backgroundRightEdge.Position = new Point(base.Width - 2, 0);
			this.backgroundRightEdge.Size = new Size(this.backgroundRightEdge.Image.Width, this.backgroundRightEdge.Image.Height + 60);
			base.addControl(this.backgroundRightEdge);
			this.titleImage.Image = GFXLibrary.popup_title_bar;
			this.titleImage.Position = new Point(0, 0);
			base.addControl(this.titleImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(659, 4);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "BuyVillagePopupPanel_close");
			this.titleImage.addControl(this.closeButton);
			this.cardbar.Position = new Point(0, 4 + this.titleImage.Image.Height);
			this.mainBackgroundImage.addControl(this.cardbar);
			this.cardbar.init(6);
			if (this.buying)
			{
				this.headingLabel.Text = SK.Text("BuyVillage_Establish_Village", "Establish Village");
				this.headingLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.headingLabel.Position = new Point(20, 5);
			}
			else
			{
				this.headingLabel.Position = new Point(20, 9);
				this.headingLabel.Text = SK.Text("BuyVillagePopup_Convert_Options", "Convert Village Options") + " : " + GameEngine.Instance.World.getVillageName(villageID);
				this.headingLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			}
			this.headingLabel.Color = global::ARGBColors.White;
			this.headingLabel.DropShadowColor = global::ARGBColors.Black;
			this.headingLabel.Size = new Size(700, 32);
			this.headingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.titleImage.addControl(this.headingLabel);
			this.inset.Position = new Point(11, 104);
			this.inset.Size = new Size(646, 368);
			this.mainBackgroundImage.addControl(this.inset);
			this.inset.Create(GFXLibrary.villageType_inset_top, GFXLibrary.villageType_inset_mid, GFXLibrary.villageType_inset_bottom);
			this.scrollArea.Position = new Point(31, 107);
			this.scrollArea.Size = new Size(610, 365);
			this.scrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(610, 364));
			this.mainBackgroundImage.addControl(this.scrollArea);
			this.mouseWheelOverlay.Position = this.scrollArea.Position;
			this.mouseWheelOverlay.Size = this.scrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			this.scrollBar.Position = new Point(661, 103);
			this.scrollBar.Size = new Size(32, 368);
			this.mainBackgroundImage.addControl(this.scrollBar);
			this.scrollBar.Value = 0;
			this.scrollBar.Max = 547;
			this.scrollBar.NumVisibleLines = 368;
			this.scrollBar.Create(null, null, null, GFXLibrary.scroll_thumb_top, GFXLibrary.scroll_thumb_mid, GFXLibrary.scroll_thumb_bottom);
			this.scrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.scrollBarMoved));
			int num = 10;
			int num2 = -14;
			int num3 = 13;
			this.bigButton1.ImageNorm = GFXLibrary.villageType_illustrations[0];
			this.bigButton1.ImageOver = GFXLibrary.villageType_illustrations[1];
			this.bigButton1.Position = new Point(0, num);
			this.bigButton1.Text.Text = SK.Text("MapTypes_Lowland", "Lowland");
			this.bigButton1.Text.Color = global::ARGBColors.White;
			this.bigButton1.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton1.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton1.Text.Position = new Point(10, 53);
			this.bigButton1.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton1.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_lowland");
			this.bigButton1.Data = 0;
			this.scrollArea.addControl(this.bigButton1);
			this.featuresImage1.Image = GFXLibrary.villageType_types[1];
			this.featuresImage1.Position = new Point(292, num + num2);
			this.featuresImage1.Visible = true;
			this.scrollArea.addControl(this.featuresImage1);
			this.description1.Text = SK.Text("MapTypesDescription_Lowland", "A balanced location with good space and no drawbacks.");
			this.description1.Position = new Point(5, 41 + num3);
			this.description1.Size = new Size(this.featuresImage1.Width - 10, this.featuresImage1.Height - 20);
			this.description1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description1.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage1.addControl(this.description1);
			this.featuresOverImage1.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage1.Position = new Point(292, num + num2);
			this.featuresOverImage1.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage1);
			this.featuresLabela1.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela1.Position = new Point(5, 7 + num3);
			this.featuresLabela1.Size = new Size(this.featuresImage1.Width - 10, this.featuresImage1.Height - 20);
			this.featuresLabela1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabela1);
			Size textSize = this.featuresLabela1.TextSize;
			this.featuresLabeld1.Text = SK.Text("NewVillage_Medium", "Medium");
			this.featuresLabeld1.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld1.Size = new Size(this.featuresImage1.Width - 10 - textSize.Width - 5, this.featuresImage1.Height - 20);
			this.featuresLabeld1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabeld1);
			this.featuresLabelb1.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb1.Position = new Point(5, 31 + num3);
			this.featuresLabelb1.Size = new Size(this.featuresImage1.Width - 10, this.featuresImage1.Height - 20);
			this.featuresLabelb1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabelb1);
			textSize = this.featuresLabelb1.TextSize;
			this.featuresLabele1.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele1.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele1.Size = new Size(this.featuresImage1.Width - 10 - textSize.Width - 5, this.featuresImage1.Height - 20);
			this.featuresLabele1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabele1);
			this.featuresLabelc1.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc1.Position = new Point(5, 55 + num3);
			this.featuresLabelc1.Size = new Size(this.featuresImage1.Width - 10, this.featuresImage1.Height - 20);
			this.featuresLabelc1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabelc1);
			textSize = this.featuresLabelc1.TextSize;
			this.featuresLabelf1.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabelf1.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf1.Size = new Size(this.featuresImage1.Width - 10 - textSize.Width - 5, this.featuresImage1.Height - 20);
			this.featuresLabelf1.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf1.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage1.addControl(this.featuresLabelf1);
			this.helpButton1.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton1.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton1.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton1.Position = new Point(this.featuresImage1.Position.X + 278, this.featuresImage1.Position.Y + num3 - 8);
			this.helpButton1.Data = 0;
			this.helpButton1.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver1), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave1));
			this.scrollArea.addControl(this.helpButton1);
			this.bigButton2.ImageNorm = GFXLibrary.villageType_illustrations[2];
			this.bigButton2.ImageOver = GFXLibrary.villageType_illustrations[3];
			this.bigButton2.Position = new Point(0, num + 630);
			this.bigButton2.Text.Text = SK.Text("MapTypes_Highland", "Highland");
			this.bigButton2.Text.Color = global::ARGBColors.White;
			this.bigButton2.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton2.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton2.Text.Position = new Point(10, 53);
			this.bigButton2.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_highland");
			this.bigButton2.Data = 1;
			this.scrollArea.addControl(this.bigButton2);
			this.featuresImage2.Image = GFXLibrary.villageType_types[2];
			this.featuresImage2.Position = new Point(292, num + num2 + 630);
			this.featuresImage2.Visible = true;
			this.scrollArea.addControl(this.featuresImage2);
			this.description2.Text = SK.Text("MapTypesDescription_Highland", "A good mix of resources and the rocky outcrops help castle design but space is a little limited.");
			if (Program.mySettings.LanguageIdent == "de" || Program.mySettings.LanguageIdent == "tr")
			{
				this.description2.Position = new Point(5, 36 + num3);
			}
			else
			{
				this.description2.Position = new Point(5, 41 + num3);
			}
			this.description2.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			if (Program.mySettings.LanguageIdent == "tr")
			{
				this.description2.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			}
			else
			{
				this.description2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			}
			this.description2.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage2.addControl(this.description2);
			this.featuresOverImage2.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage2.Position = new Point(292, num + num2 + 630);
			this.featuresOverImage2.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage2);
			this.featuresLabela2.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela2.Position = new Point(5, 7 + num3);
			this.featuresLabela2.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.featuresLabela2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabela2);
			textSize = this.featuresLabela2.TextSize;
			this.featuresLabeld2.Text = SK.Text("NewVillage_Medium", "Medium");
			this.featuresLabeld2.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld2.Size = new Size(this.featuresImage2.Width - 10 - textSize.Width - 5, this.featuresImage2.Height - 20);
			this.featuresLabeld2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabeld2);
			this.featuresLabelb2.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb2.Position = new Point(5, 31 + num3);
			this.featuresLabelb2.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.featuresLabelb2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabelb2);
			textSize = this.featuresLabelb2.TextSize;
			this.featuresLabele2.Text = SK.Text("NewVillage_Medium", "Medium");
			this.featuresLabele2.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele2.Size = new Size(this.featuresImage2.Width - 10 - textSize.Width - 5, this.featuresImage2.Height - 20);
			this.featuresLabele2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabele2);
			this.featuresLabelc2.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc2.Position = new Point(5, 55 + num3);
			this.featuresLabelc2.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.featuresLabelc2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabelc2);
			textSize = this.featuresLabelc2.TextSize;
			this.featuresLabelf2.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabelf2.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf2.Size = new Size(this.featuresImage2.Width - 10 - textSize.Width - 5, this.featuresImage2.Height - 20);
			this.featuresLabelf2.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf2.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage2.addControl(this.featuresLabelf2);
			this.helpButton2.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton2.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton2.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton2.Position = new Point(this.featuresImage2.Position.X + 278, this.featuresImage2.Position.Y + num3 - 8);
			this.helpButton2.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver2), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave2));
			this.scrollArea.addControl(this.helpButton2);
			this.bigButton3.ImageNorm = GFXLibrary.villageType_illustrations[4];
			this.bigButton3.ImageOver = GFXLibrary.villageType_illustrations[5];
			this.bigButton3.Position = new Point(0, num + 720);
			this.bigButton3.Text.Text = SK.Text("MapTypes_Mountain_Peak", "Mountain Peak");
			this.bigButton3.Text.Color = global::ARGBColors.White;
			this.bigButton3.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton3.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton3.Text.Position = new Point(10, 53);
			this.bigButton3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_mountain_peak");
			this.bigButton3.Data = 4;
			this.scrollArea.addControl(this.bigButton3);
			this.featuresImage3.Image = GFXLibrary.villageType_types[3];
			this.featuresImage3.Position = new Point(292, num + num2 + 720);
			this.featuresImage3.Visible = true;
			this.scrollArea.addControl(this.featuresImage3);
			this.description3.Text = SK.Text("MapTypesDescription_Mountain_Peak", "Iron is plentiful in this mountain top stronghold.");
			this.description3.Position = new Point(5, 41 + num3);
			this.description3.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description3.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage3.addControl(this.description3);
			this.featuresOverImage3.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage3.Position = new Point(292, num + num2 + 720);
			this.featuresOverImage3.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage3);
			this.featuresLabela3.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela3.Position = new Point(5, 7 + num3);
			this.featuresLabela3.Size = new Size(this.featuresImage3.Width - 10, this.featuresImage3.Height - 20);
			this.featuresLabela3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabela3);
			textSize = this.featuresLabela3.TextSize;
			this.featuresLabeld3.Text = SK.Text("NewVillage_Medium", "Medium");
			this.featuresLabeld3.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld3.Size = new Size(this.featuresImage3.Width - 10 - textSize.Width - 5, this.featuresImage3.Height - 20);
			this.featuresLabeld3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabeld3);
			this.featuresLabelb3.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb3.Position = new Point(5, 31 + num3);
			this.featuresLabelb3.Size = new Size(this.featuresImage3.Width - 10, this.featuresImage3.Height - 20);
			this.featuresLabelb3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabelb3);
			textSize = this.featuresLabelb3.TextSize;
			this.featuresLabele3.Text = SK.Text("NewVillage_High", "High");
			this.featuresLabele3.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele3.Size = new Size(this.featuresImage3.Width - 10 - textSize.Width - 5, this.featuresImage3.Height - 20);
			this.featuresLabele3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabele3);
			this.featuresLabelc3.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc3.Position = new Point(5, 55 + num3);
			this.featuresLabelc3.Size = new Size(this.featuresImage3.Width - 10, this.featuresImage3.Height - 20);
			this.featuresLabelc3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabelc3);
			textSize = this.featuresLabelc3.TextSize;
			this.featuresLabelf3.Text = SK.Text("ResourceType_Iron", "Iron");
			this.featuresLabelf3.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf3.Size = new Size(this.featuresImage3.Width - 10 - textSize.Width - 5, this.featuresImage3.Height - 20);
			this.featuresLabelf3.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf3.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage3.addControl(this.featuresLabelf3);
			this.helpButton3.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton3.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton3.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton3.Position = new Point(this.featuresImage3.Position.X + 278, this.featuresImage3.Position.Y + num3 - 8);
			this.helpButton3.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver3), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave3));
			this.scrollArea.addControl(this.helpButton3);
			this.bigButton4.ImageNorm = GFXLibrary.villageType_illustrations[6];
			this.bigButton4.ImageOver = GFXLibrary.villageType_illustrations[7];
			this.bigButton4.Position = new Point(0, num + 270);
			this.bigButton4.Text.Text = SK.Text("MapTypes_River", "River") + " 1";
			this.bigButton4.Text.Color = global::ARGBColors.White;
			this.bigButton4.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton4.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton4.Text.Position = new Point(10, 53);
			this.bigButton4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_river_1");
			this.bigButton4.Data = 2;
			this.scrollArea.addControl(this.bigButton4);
			this.featuresImage4.Image = GFXLibrary.villageType_types[5];
			this.featuresImage4.Position = new Point(292, num + num2 + 270);
			this.featuresImage4.Visible = true;
			this.scrollArea.addControl(this.featuresImage4);
			this.description4.Text = SK.Text("MapTypesDescription_River1", "Limited resources here are made up for by the benefits the river brings.");
			this.description4.Position = new Point(5, 41 + num3);
			this.description4.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description4.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage4.addControl(this.description4);
			this.featuresOverImage4.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage4.Position = new Point(292, num + num2 + 270);
			this.featuresOverImage4.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage4);
			this.featuresLabela4.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela4.Position = new Point(5, 7 + num3);
			this.featuresLabela4.Size = new Size(this.featuresImage4.Width - 10, this.featuresImage4.Height - 20);
			this.featuresLabela4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabela4);
			textSize = this.featuresLabela4.TextSize;
			this.featuresLabeld4.Text = SK.Text("NewVillage_High", "High");
			this.featuresLabeld4.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld4.Size = new Size(this.featuresImage4.Width - 10 - textSize.Width - 5, this.featuresImage4.Height - 20);
			this.featuresLabeld4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabeld4);
			this.featuresLabelb4.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb4.Position = new Point(5, 31 + num3);
			this.featuresLabelb4.Size = new Size(this.featuresImage4.Width - 10, this.featuresImage4.Height - 20);
			this.featuresLabelb4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabelb4);
			textSize = this.featuresLabelb4.TextSize;
			this.featuresLabele4.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele4.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele4.Size = new Size(this.featuresImage4.Width - 10 - textSize.Width - 5, this.featuresImage4.Height - 20);
			this.featuresLabele4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabele4);
			this.featuresLabelc4.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc4.Position = new Point(5, 55 + num3);
			this.featuresLabelc4.Size = new Size(this.featuresImage4.Width - 10, this.featuresImage4.Height - 20);
			this.featuresLabelc4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabelc4);
			textSize = this.featuresLabelc4.TextSize;
			this.featuresLabelf4.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabelf4.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf4.Size = new Size(this.featuresImage4.Width - 10 - textSize.Width - 5, this.featuresImage4.Height - 20);
			this.featuresLabelf4.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf4.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage4.addControl(this.featuresLabelf4);
			this.helpButton4.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton4.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton4.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton4.Position = new Point(this.featuresImage4.Position.X + 278, this.featuresImage4.Position.Y + num3 - 8);
			this.helpButton4.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver4), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave4));
			this.scrollArea.addControl(this.helpButton4);
			this.bigButton5.ImageNorm = GFXLibrary.villageType_illustrations[8];
			this.bigButton5.ImageOver = GFXLibrary.villageType_illustrations[9];
			this.bigButton5.Position = new Point(0, num + 360);
			this.bigButton5.Text.Text = SK.Text("MapTypes_River", "River") + " 2";
			this.bigButton5.Text.Color = global::ARGBColors.White;
			this.bigButton5.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton5.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton5.Text.Position = new Point(10, 53);
			this.bigButton5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_river_2");
			this.bigButton5.Data = 3;
			this.scrollArea.addControl(this.bigButton5);
			this.featuresImage5.Image = GFXLibrary.villageType_types[4];
			this.featuresImage5.Position = new Point(292, num + num2 + 360);
			this.featuresImage5.Visible = true;
			this.scrollArea.addControl(this.featuresImage5);
			this.description5.Text = SK.Text("MapTypesDescription_River2", "Limited resources here are made up for by the benefits the river brings.");
			this.description5.Position = new Point(5, 41 + num3);
			this.description5.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description5.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage5.addControl(this.description5);
			this.featuresOverImage5.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage5.Position = new Point(292, num + num2 + 360);
			this.featuresOverImage5.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage5);
			this.featuresLabela5.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela5.Position = new Point(5, 7 + num3);
			this.featuresLabela5.Size = new Size(this.featuresImage5.Width - 10, this.featuresImage5.Height - 20);
			this.featuresLabela5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabela5);
			textSize = this.featuresLabela5.TextSize;
			this.featuresLabeld5.Text = SK.Text("NewVillage_High", "High");
			this.featuresLabeld5.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld5.Size = new Size(this.featuresImage5.Width - 10 - textSize.Width - 5, this.featuresImage5.Height - 20);
			this.featuresLabeld5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabeld5);
			this.featuresLabelb5.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb5.Position = new Point(5, 31 + num3);
			this.featuresLabelb5.Size = new Size(this.featuresImage5.Width - 10, this.featuresImage5.Height - 20);
			this.featuresLabelb5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabelb5);
			textSize = this.featuresLabelb5.TextSize;
			this.featuresLabele5.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele5.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele5.Size = new Size(this.featuresImage5.Width - 10 - textSize.Width - 5, this.featuresImage5.Height - 20);
			this.featuresLabele5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabele5);
			this.featuresLabelc5.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc5.Position = new Point(5, 55 + num3);
			this.featuresLabelc5.Size = new Size(this.featuresImage5.Width - 10, this.featuresImage5.Height - 20);
			this.featuresLabelc5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabelc5);
			textSize = this.featuresLabelc5.TextSize;
			this.featuresLabelf5.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabelf5.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf5.Size = new Size(this.featuresImage5.Width - 10 - textSize.Width - 5, this.featuresImage5.Height - 20);
			this.featuresLabelf5.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf5.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage5.addControl(this.featuresLabelf5);
			this.helpButton5.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton5.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton5.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton5.Position = new Point(this.featuresImage5.Position.X + 278, this.featuresImage5.Position.Y + num3 - 8);
			this.helpButton5.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver5), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave5));
			this.scrollArea.addControl(this.helpButton5);
			this.bigButton6.ImageNorm = GFXLibrary.villageType_illustrations[10];
			this.bigButton6.ImageOver = GFXLibrary.villageType_illustrations[11];
			this.bigButton6.Position = new Point(0, num + 180);
			this.bigButton6.Text.Text = SK.Text("MapTypes_Salt_Flat", "Salt Flat");
			this.bigButton6.Text.Color = global::ARGBColors.White;
			this.bigButton6.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton6.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton6.Text.Position = new Point(10, 53);
			this.bigButton6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_salt_flat");
			this.bigButton6.Data = 5;
			this.scrollArea.addControl(this.bigButton6);
			this.featuresImage6.Image = GFXLibrary.villageType_types[6];
			this.featuresImage6.Position = new Point(292, num + num2 + 180);
			this.featuresImage6.Visible = true;
			this.scrollArea.addControl(this.featuresImage6);
			this.description6.Text = SK.Text("MapTypesDescription_Salt_Flat", "The only place to collect salt. Limited resources and some space limitations.");
			this.description6.Position = new Point(5, 41 + num3);
			this.description6.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description6.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage6.addControl(this.description6);
			this.featuresOverImage6.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage6.Position = new Point(292, num + num2 + 180);
			this.featuresOverImage6.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage6);
			this.featuresLabela6.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela6.Position = new Point(5, 7 + num3);
			this.featuresLabela6.Size = new Size(this.featuresImage6.Width - 10, this.featuresImage6.Height - 20);
			this.featuresLabela6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabela6);
			textSize = this.featuresLabela6.TextSize;
			this.featuresLabeld6.Text = SK.Text("NewVillage_Low", "Low");
			this.featuresLabeld6.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld6.Size = new Size(this.featuresImage6.Width - 10 - textSize.Width - 5, this.featuresImage6.Height - 20);
			this.featuresLabeld6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabeld6);
			this.featuresLabelb6.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb6.Position = new Point(5, 31 + num3);
			this.featuresLabelb6.Size = new Size(this.featuresImage6.Width - 10, this.featuresImage6.Height - 20);
			this.featuresLabelb6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabelb6);
			textSize = this.featuresLabelb6.TextSize;
			this.featuresLabele6.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele6.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele6.Size = new Size(this.featuresImage6.Width - 10 - textSize.Width - 5, this.featuresImage6.Height - 20);
			this.featuresLabele6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabele6);
			this.featuresLabelc6.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc6.Position = new Point(5, 55 + num3);
			this.featuresLabelc6.Size = new Size(this.featuresImage6.Width - 10, this.featuresImage6.Height - 20);
			this.featuresLabelc6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabelc6);
			textSize = this.featuresLabelc6.TextSize;
			this.featuresLabelf6.Text = SK.Text("ResourceType_Clothes", "Clothes");
			this.featuresLabelf6.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf6.Size = new Size(this.featuresImage6.Width - 10 - textSize.Width - 5, this.featuresImage6.Height - 20);
			this.featuresLabelf6.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf6.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage6.addControl(this.featuresLabelf6);
			this.helpButton6.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton6.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton6.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton6.Position = new Point(this.featuresImage6.Position.X + 278, this.featuresImage6.Position.Y + num3 - 8);
			this.helpButton6.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver6), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave6));
			this.scrollArea.addControl(this.helpButton6);
			this.bigButton7.ImageNorm = GFXLibrary.villageType_illustrations[12];
			this.bigButton7.ImageOver = GFXLibrary.villageType_illustrations[13];
			this.bigButton7.Position = new Point(0, num + 450);
			this.bigButton7.Text.Text = SK.Text("MapTypes_Marsh", "Marsh");
			this.bigButton7.Text.Color = global::ARGBColors.White;
			this.bigButton7.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton7.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton7.Text.Position = new Point(10, 53);
			this.bigButton7.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton7.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_marsh");
			this.bigButton7.Data = 6;
			this.scrollArea.addControl(this.bigButton7);
			this.featuresImage7.Image = GFXLibrary.villageType_types[7];
			this.featuresImage7.Position = new Point(292, num + num2 + 450);
			this.featuresImage7.Visible = true;
			this.scrollArea.addControl(this.featuresImage7);
			this.description7.Text = SK.Text("MapTypesDescription_Marsh", "Pitch is abundant here, although wood and stone are scarce.");
			this.description7.Position = new Point(5, 41 + num3);
			this.description7.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description7.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage7.addControl(this.description7);
			this.featuresOverImage7.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage7.Position = new Point(292, num + num2 + 450);
			this.featuresOverImage7.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage7);
			this.featuresLabela7.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela7.Position = new Point(5, 7 + num3);
			this.featuresLabela7.Size = new Size(this.featuresImage7.Width - 10, this.featuresImage7.Height - 20);
			this.featuresLabela7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabela7);
			textSize = this.featuresLabela7.TextSize;
			this.featuresLabeld7.Text = SK.Text("NewVillage_Low", "Low");
			this.featuresLabeld7.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld7.Size = new Size(this.featuresImage7.Width - 10 - textSize.Width - 5, this.featuresImage7.Height - 20);
			this.featuresLabeld7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabeld7);
			this.featuresLabelb7.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb7.Position = new Point(5, 31 + num3);
			this.featuresLabelb7.Size = new Size(this.featuresImage7.Width - 10, this.featuresImage7.Height - 20);
			this.featuresLabelb7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabelb7);
			textSize = this.featuresLabelb7.TextSize;
			this.featuresLabele7.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele7.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele7.Size = new Size(this.featuresImage7.Width - 10 - textSize.Width - 5, this.featuresImage7.Height - 20);
			this.featuresLabele7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabele7);
			this.featuresLabelc7.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc7.Position = new Point(5, 55 + num3);
			this.featuresLabelc7.Size = new Size(this.featuresImage7.Width - 10, this.featuresImage7.Height - 20);
			this.featuresLabelc7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabelc7);
			textSize = this.featuresLabelc7.TextSize;
			this.featuresLabelf7.Text = SK.Text("ResourceType_Catapults", "Catapults") + ", " + SK.Text("ResourceType_Meat", "Meat");
			this.featuresLabelf7.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf7.Size = new Size(this.featuresImage7.Width - 10 - textSize.Width - 5, this.featuresImage7.Height - 20);
			this.featuresLabelf7.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf7.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage7.addControl(this.featuresLabelf7);
			this.helpButton7.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton7.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton7.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton7.Position = new Point(this.featuresImage7.Position.X + 278, this.featuresImage7.Position.Y + num3 - 8);
			this.helpButton7.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver7), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave7));
			this.scrollArea.addControl(this.helpButton7);
			this.bigButton8.ImageNorm = GFXLibrary.villageType_illustrations[14];
			this.bigButton8.ImageOver = GFXLibrary.villageType_illustrations[15];
			this.bigButton8.Position = new Point(0, num + 540);
			this.bigButton8.Text.Text = SK.Text("MapTypes_Plains", "Plains");
			this.bigButton8.Text.Color = global::ARGBColors.White;
			this.bigButton8.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton8.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton8.Text.Position = new Point(10, 53);
			this.bigButton8.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton8.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_plains");
			this.bigButton8.Data = 7;
			this.scrollArea.addControl(this.bigButton8);
			this.featuresImage8.Image = GFXLibrary.villageType_types[8];
			this.featuresImage8.Position = new Point(292, num + num2 + 540);
			this.featuresImage8.Visible = true;
			this.scrollArea.addControl(this.featuresImage8);
			this.description8.Text = SK.Text("MapTypesDescription_Plains", "Wheat grows really well on the plains, but the vast space available comes at a cost in reduced resources.");
			if (Program.mySettings.LanguageIdent == "de")
			{
				this.description8.Position = new Point(5, 36 + num3);
			}
			else
			{
				this.description8.Position = new Point(5, 41 + num3);
			}
			this.description8.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description8.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage8.addControl(this.description8);
			this.featuresOverImage8.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage8.Position = new Point(292, num + num2 + 540);
			this.featuresOverImage8.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage8);
			this.featuresLabela8.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela8.Position = new Point(5, 7 + num3);
			this.featuresLabela8.Size = new Size(this.featuresImage8.Width - 10, this.featuresImage8.Height - 20);
			this.featuresLabela8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabela8);
			textSize = this.featuresLabela8.TextSize;
			this.featuresLabeld8.Text = SK.Text("NewVillage_VeryHigh", "Very High");
			this.featuresLabeld8.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld8.Size = new Size(this.featuresImage8.Width - 10 - textSize.Width - 5, this.featuresImage8.Height - 20);
			this.featuresLabeld8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabeld8);
			this.featuresLabelb8.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb8.Position = new Point(5, 31 + num3);
			this.featuresLabelb8.Size = new Size(this.featuresImage8.Width - 10, this.featuresImage8.Height - 20);
			this.featuresLabelb8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabelb8);
			textSize = this.featuresLabelb8.TextSize;
			this.featuresLabele8.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele8.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele8.Size = new Size(this.featuresImage8.Width - 10 - textSize.Width - 5, this.featuresImage8.Height - 20);
			this.featuresLabele8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabele8);
			this.featuresLabelc8.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc8.Position = new Point(5, 55 + num3);
			this.featuresLabelc8.Size = new Size(this.featuresImage8.Width - 10, this.featuresImage8.Height - 20);
			this.featuresLabelc8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabelc8);
			textSize = this.featuresLabelc8.TextSize;
			this.featuresLabelf8.Text = SK.Text("NewVillage_Wheat", "Wheat") + ", " + SK.Text("ResourceType_Cheese", "Cheese");
			this.featuresLabelf8.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf8.Size = new Size(this.featuresImage8.Width - 10 - textSize.Width - 5, this.featuresImage8.Height - 20);
			this.featuresLabelf8.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf8.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage8.addControl(this.featuresLabelf8);
			this.helpButton8.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton8.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton8.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton8.Position = new Point(this.featuresImage8.Position.X + 278, this.featuresImage8.Position.Y + num3 - 8);
			this.helpButton8.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver8), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave8));
			this.scrollArea.addControl(this.helpButton8);
			this.bigButton9.ImageNorm = GFXLibrary.villageType_illustrations[16];
			this.bigButton9.ImageOver = GFXLibrary.villageType_illustrations[17];
			this.bigButton9.Position = new Point(0, num + 90);
			this.bigButton9.Text.Text = SK.Text("MapTypes_Valley_Side", "Valley Side");
			this.bigButton9.Text.Color = global::ARGBColors.White;
			this.bigButton9.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton9.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton9.Text.Position = new Point(10, 53);
			this.bigButton9.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton9.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_valley_side");
			this.bigButton9.Data = 8;
			this.scrollArea.addControl(this.bigButton9);
			this.featuresImage9.Image = GFXLibrary.villageType_types[9];
			this.featuresImage9.Position = new Point(292, num + num2 + 90);
			this.featuresImage9.Visible = true;
			this.scrollArea.addControl(this.featuresImage9);
			this.description9.Text = SK.Text("MapTypesDescription_Valley_Side", "A perfect site for growing vines, slightly limited resources but good space.");
			if (Program.mySettings.LanguageIdent == "tr")
			{
				this.description9.Position = new Point(5, 41 + num3 - 5);
			}
			else
			{
				this.description9.Position = new Point(5, 41 + num3);
			}
			this.description9.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			if (Program.mySettings.LanguageIdent == "tr")
			{
				this.description9.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			}
			else
			{
				this.description9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			}
			this.description9.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage9.addControl(this.description9);
			this.featuresOverImage9.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage9.Position = new Point(292, num + num2 + 90);
			this.featuresOverImage9.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage9);
			this.featuresLabela9.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela9.Position = new Point(5, 7 + num3);
			this.featuresLabela9.Size = new Size(this.featuresImage9.Width - 10, this.featuresImage9.Height - 20);
			this.featuresLabela9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabela9);
			textSize = this.featuresLabela9.TextSize;
			this.featuresLabeld9.Text = SK.Text("NewVillage_VeryHigh", "Very High");
			this.featuresLabeld9.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld9.Size = new Size(this.featuresImage9.Width - 10 - textSize.Width - 5, this.featuresImage9.Height - 20);
			this.featuresLabeld9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabeld9);
			this.featuresLabelb9.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb9.Position = new Point(5, 31 + num3);
			this.featuresLabelb9.Size = new Size(this.featuresImage9.Width - 10, this.featuresImage9.Height - 20);
			this.featuresLabelb9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabelb9);
			textSize = this.featuresLabelb9.TextSize;
			this.featuresLabele9.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabele9.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele9.Size = new Size(this.featuresImage9.Width - 10 - textSize.Width - 5, this.featuresImage9.Height - 20);
			this.featuresLabele9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabele9);
			this.featuresLabelc9.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc9.Position = new Point(5, 55 + num3);
			this.featuresLabelc9.Size = new Size(this.featuresImage9.Width - 10, this.featuresImage9.Height - 20);
			this.featuresLabelc9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabelc9);
			textSize = this.featuresLabelc9.TextSize;
			this.featuresLabelf9.Text = SK.Text("NewVillage_None", "None");
			this.featuresLabelf9.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf9.Size = new Size(this.featuresImage9.Width - 10 - textSize.Width - 5, this.featuresImage9.Height - 20);
			this.featuresLabelf9.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf9.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage9.addControl(this.featuresLabelf9);
			this.helpButton9.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton9.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton9.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton9.Position = new Point(this.featuresImage9.Position.X + 278, this.featuresImage9.Position.Y + num3 - 8);
			this.helpButton9.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver9), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave9));
			this.scrollArea.addControl(this.helpButton9);
			this.bigButton10.ImageNorm = GFXLibrary.villageType_illustrations[18];
			this.bigButton10.ImageOver = GFXLibrary.villageType_illustrations[19];
			this.bigButton10.Position = new Point(0, num + 810);
			this.bigButton10.Text.Text = SK.Text("MapTypes_Forest", "Forest");
			this.bigButton10.Text.Color = global::ARGBColors.White;
			this.bigButton10.Text.DropShadowColor = global::ARGBColors.Black;
			this.bigButton10.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.bigButton10.Text.Position = new Point(10, 53);
			this.bigButton10.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.bigButton10.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyVillage), "BuyVillagePopupPanel_forest");
			this.bigButton10.Data = 9;
			this.scrollArea.addControl(this.bigButton10);
			this.featuresImage10.Image = GFXLibrary.villageType_types[10];
			this.featuresImage10.Position = new Point(292, num + num2 + 810);
			this.featuresImage10.Visible = true;
			this.scrollArea.addControl(this.featuresImage10);
			this.description10.Text = SK.Text("MapTypesDescription_Forest", "Wood is everywhere here and grows strongly - but resources are limited.");
			this.description10.Position = new Point(5, 41 + num3);
			this.description10.Size = new Size(this.featuresImage2.Width - 10, this.featuresImage2.Height - 20);
			this.description10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.description10.Color = Color.FromArgb(255, 254, 220);
			this.featuresImage10.addControl(this.description10);
			this.featuresOverImage10.Image = GFXLibrary.villageType_types[0];
			this.featuresOverImage10.Position = new Point(292, num + num2 + 810);
			this.featuresOverImage10.Visible = false;
			this.scrollArea.addControl(this.featuresOverImage10);
			this.featuresLabela10.Text = SK.Text("NewVillage_Space", "Space") + ":";
			this.featuresLabela10.Position = new Point(5, 7 + num3);
			this.featuresLabela10.Size = new Size(this.featuresImage10.Width - 10, this.featuresImage10.Height - 20);
			this.featuresLabela10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabela10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabela10);
			textSize = this.featuresLabela10.TextSize;
			this.featuresLabeld10.Text = SK.Text("NewVillage_Low", "Low");
			this.featuresLabeld10.Position = new Point(5 + textSize.Width + 5, 7 + num3);
			this.featuresLabeld10.Size = new Size(this.featuresImage10.Width - 10 - textSize.Width - 5, this.featuresImage10.Height - 20);
			this.featuresLabeld10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabeld10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabeld10);
			this.featuresLabelb10.Text = SK.Text("NewVillage_Castle", "Castle natural defenses") + ":";
			this.featuresLabelb10.Position = new Point(5, 31 + num3);
			this.featuresLabelb10.Size = new Size(this.featuresImage10.Width - 10, this.featuresImage10.Height - 20);
			this.featuresLabelb10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelb10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabelb10);
			textSize = this.featuresLabelb10.TextSize;
			this.featuresLabele10.Text = SK.Text("NewVillage_VeryHigh", "Very High");
			this.featuresLabele10.Position = new Point(5 + textSize.Width + 5, 31 + num3);
			this.featuresLabele10.Size = new Size(this.featuresImage10.Width - 10 - textSize.Width - 5, this.featuresImage10.Height - 20);
			this.featuresLabele10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabele10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabele10);
			this.featuresLabelc10.Text = SK.Text("NewVillage_Production", "Production bonus to") + ":";
			this.featuresLabelc10.Position = new Point(5, 55 + num3);
			this.featuresLabelc10.Size = new Size(this.featuresImage10.Width - 10, this.featuresImage10.Height - 20);
			this.featuresLabelc10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.featuresLabelc10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabelc10);
			textSize = this.featuresLabelc10.TextSize;
			this.featuresLabelf10.Text = string.Concat(new string[]
			{
				SK.Text("ResourceTypeWood", "Wood"),
				", ",
				SK.Text("ResourceType_Furniture", "Furniture"),
				", ",
				SK.Text("ResourceType_Venison", "Venison")
			});
			this.featuresLabelf10.Position = new Point(5 + textSize.Width + 5, 55 + num3);
			this.featuresLabelf10.Size = new Size(this.featuresImage10.Width - 10 - textSize.Width - 5, this.featuresImage10.Height - 20);
			this.featuresLabelf10.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.featuresLabelf10.Color = Color.FromArgb(255, 254, 220);
			this.featuresOverImage10.addControl(this.featuresLabelf10);
			this.helpButton10.ImageNorm = GFXLibrary.villageType_helpButton[0];
			this.helpButton10.ImageOver = GFXLibrary.villageType_helpButton[1];
			this.helpButton10.ImageClick = GFXLibrary.villageType_helpButton[1];
			this.helpButton10.Position = new Point(this.featuresImage10.Position.X + 278, this.featuresImage10.Position.Y + num3 - 8);
			this.helpButton10.setButtonMouseOverDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpOver10), new CustomSelfDrawPanel.CSDControl.CSD_MouseOverDelegate(this.helpLeave10));
			this.scrollArea.addControl(this.helpButton10);
			if (this.buying)
			{
				this.peaceTimeCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.peaceTimeCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.peaceTimeCheck.Position = new Point(21, 472);
				this.peaceTimeCheck.Checked = true;
				this.peaceTimeCheck.CBLabel.Text = SK.Text("BuyVillagePopup_3_Day_Peace_Time", "3 Day Peace Time ");
				this.peaceTimeCheck.CBLabel.Color = global::ARGBColors.White;
				this.peaceTimeCheck.CBLabel.DropShadowColor = global::ARGBColors.Black;
				this.peaceTimeCheck.CBLabel.Position = new Point(25, 6);
				this.peaceTimeCheck.CBLabel.Size = new Size(600, 25);
				this.peaceTimeCheck.CBLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				this.peaceTimeCheck.Visible = true;
				this.mainBackgroundImage.addControl(this.peaceTimeCheck);
				this.convertLabel.Visible = false;
				return;
			}
			this.peaceTimeCheck.Visible = false;
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0009C1A4 File Offset: 0x0009A3A4
		private void scrollBarMoved()
		{
			int value = this.scrollBar.Value;
			this.scrollArea.Position = new Point(this.scrollArea.X, 107 - value);
			this.scrollArea.ClipRect = new Rectangle(this.scrollArea.ClipRect.X, value, this.scrollArea.ClipRect.Width, this.scrollArea.ClipRect.Height);
			this.scrollArea.invalidate();
			this.inset.invalidate();
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0000C0C9 File Offset: 0x0000A2C9
		private void mouseWheelMoved(int delta)
		{
			if (delta < 0)
			{
				this.scrollBar.scrollDown(40);
				return;
			}
			if (delta > 0)
			{
				this.scrollBar.scrollUp(40);
			}
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0000C0EE File Offset: 0x0000A2EE
		public void update()
		{
			this.cardbar.update();
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0000C0FC File Offset: 0x0000A2FC
		private void helpOver1()
		{
			this.featuresImage1.Visible = false;
			this.featuresOverImage1.Visible = true;
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0000C116 File Offset: 0x0000A316
		private void helpLeave1()
		{
			this.featuresImage1.Visible = true;
			this.featuresOverImage1.Visible = false;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0000C130 File Offset: 0x0000A330
		private void helpOver2()
		{
			this.featuresImage2.Visible = false;
			this.featuresOverImage2.Visible = true;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x0000C14A File Offset: 0x0000A34A
		private void helpLeave2()
		{
			this.featuresImage2.Visible = true;
			this.featuresOverImage2.Visible = false;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000C164 File Offset: 0x0000A364
		private void helpOver3()
		{
			this.featuresImage3.Visible = false;
			this.featuresOverImage3.Visible = true;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0000C17E File Offset: 0x0000A37E
		private void helpLeave3()
		{
			this.featuresImage3.Visible = true;
			this.featuresOverImage3.Visible = false;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x0000C198 File Offset: 0x0000A398
		private void helpOver4()
		{
			this.featuresImage4.Visible = false;
			this.featuresOverImage4.Visible = true;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0000C1B2 File Offset: 0x0000A3B2
		private void helpLeave4()
		{
			this.featuresImage4.Visible = true;
			this.featuresOverImage4.Visible = false;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0000C1CC File Offset: 0x0000A3CC
		private void helpOver5()
		{
			this.featuresImage5.Visible = false;
			this.featuresOverImage5.Visible = true;
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0000C1E6 File Offset: 0x0000A3E6
		private void helpLeave5()
		{
			this.featuresImage5.Visible = true;
			this.featuresOverImage5.Visible = false;
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0000C200 File Offset: 0x0000A400
		private void helpOver6()
		{
			this.featuresImage6.Visible = false;
			this.featuresOverImage6.Visible = true;
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0000C21A File Offset: 0x0000A41A
		private void helpLeave6()
		{
			this.featuresImage6.Visible = true;
			this.featuresOverImage6.Visible = false;
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x0000C234 File Offset: 0x0000A434
		private void helpOver7()
		{
			this.featuresImage7.Visible = false;
			this.featuresOverImage7.Visible = true;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x0000C24E File Offset: 0x0000A44E
		private void helpLeave7()
		{
			this.featuresImage7.Visible = true;
			this.featuresOverImage7.Visible = false;
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x0000C268 File Offset: 0x0000A468
		private void helpOver8()
		{
			this.featuresImage8.Visible = false;
			this.featuresOverImage8.Visible = true;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0000C282 File Offset: 0x0000A482
		private void helpLeave8()
		{
			this.featuresImage8.Visible = true;
			this.featuresOverImage8.Visible = false;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0000C29C File Offset: 0x0000A49C
		private void helpOver9()
		{
			this.featuresImage9.Visible = false;
			this.featuresOverImage9.Visible = true;
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x0000C2B6 File Offset: 0x0000A4B6
		private void helpLeave9()
		{
			this.featuresImage9.Visible = true;
			this.featuresOverImage9.Visible = false;
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0000C2D0 File Offset: 0x0000A4D0
		private void helpOver10()
		{
			this.featuresImage10.Visible = false;
			this.featuresOverImage10.Visible = true;
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		private void helpLeave10()
		{
			this.featuresImage10.Visible = true;
			this.featuresOverImage10.Visible = false;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0000C304 File Offset: 0x0000A504
		private void closeClick()
		{
			InterfaceMgr.Instance.closeBuyVillagePopupWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0009C23C File Offset: 0x0009A43C
		private void buyVillage()
		{
			if (this.ClickedControl == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			if (this.buying)
			{
				bool @checked = this.peaceTimeCheck.Checked;
				RemoteServices.Instance.set_BuyVillage_UserCallBack(new RemoteServices.BuyVillage_UserCallBack(this.buyVillageCallback));
				RemoteServices.Instance.BuyVillage(InterfaceMgr.Instance.getSelectedMenuVillage(), this.m_villageID, data, GameEngine.Instance.World.CurrentVillageFactionsPos, @checked);
				this.closeClick();
				return;
			}
			MessageBoxButtons buts = MessageBoxButtons.YesNo;
			int num = 0;
			VillageMap village = GameEngine.Instance.getVillage(this.m_villageID);
			if (village != null)
			{
				num = village.countBuildings();
			}
			DialogResult dialogResult = (num > 0) ? MyMessageBox.Show(string.Concat(new string[]
			{
				SK.Text("BuyVillagePopup_Convert_Will_Destroy2", "Converting your village type will destroy all buildings in it and once converted it can not be reversed."),
				Environment.NewLine,
				SK.Text("BuyVillagePopup_Are_You_REALLY_Sure", "Are you REALLY Sure you want to do this and that you have selected the correct village?"),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("BuyVillagePopup_To_Be_Converted", "The Village to be converted is : "),
				Environment.NewLine,
				Environment.NewLine,
				GameEngine.Instance.World.getVillageName(this.m_villageID),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("BuyVillagePopup_Num_Buildings", "The number of buildings in this village : "),
				num.ToString(),
				Environment.NewLine,
				Environment.NewLine,
				"."
			}), SK.Text("BuyVillagePopup_Warning_Convert", "Warning: Convert Village?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0) : MyMessageBox.Show(string.Concat(new string[]
			{
				SK.Text("BuyVillagePopup_Convert_Will_Destroy2", "Converting your village type will destroy all buildings in it and once converted it can not be reversed."),
				Environment.NewLine,
				SK.Text("BuyVillagePopup_Are_You_REALLY_Sure", "Are you REALLY Sure you want to do this and that you have selected the correct village?"),
				Environment.NewLine,
				Environment.NewLine,
				SK.Text("BuyVillagePopup_To_Be_Converted", "The Village to be converted is : "),
				Environment.NewLine,
				Environment.NewLine,
				GameEngine.Instance.World.getVillageName(this.m_villageID),
				Environment.NewLine,
				Environment.NewLine,
				"."
			}), SK.Text("BuyVillagePopup_Warning_Convert", "Warning: Convert Village?"), buts, MessageBoxIcon.None, MessageBoxDefaultButton.Button2, 0);
			if (dialogResult == DialogResult.Yes)
			{
				RemoteServices.Instance.set_ConvertVillage_UserCallBack(new RemoteServices.ConvertVillage_UserCallBack(this.convertVillageCallback));
				RemoteServices.Instance.ConvertVillage(this.m_villageID, data);
				this.closeClick();
			}
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0009C4CC File Offset: 0x0009A6CC
		private void buyVillageCallback(BuyVillage_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				if (returnData.armyData != null)
				{
					ArmyReturnData[] armyReturnData = new ArmyReturnData[]
					{
						returnData.armyData
					};
					GameEngine.Instance.World.doGetArmyData(armyReturnData, null, false);
					VillageMap village = GameEngine.Instance.getVillage(returnData.m_villageID);
					if (village != null)
					{
						village.m_numCaptains--;
					}
				}
				if (InterfaceMgr.Instance.SelectedVillage >= 0 && GameEngine.Instance.World.isUserVillage(InterfaceMgr.Instance.SelectedVillage))
				{
					InterfaceMgr.Instance.closeSelectedVillagePanel();
					return;
				}
			}
			else
			{
				MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("BuyVillagePopup_Error", "BuyVillage Error"));
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0009C5A4 File Offset: 0x0009A7A4
		private void convertVillageCallback(ConvertVillage_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.villageID >= 0)
				{
					GameEngine.Instance.flushVillage(returnData.villageID);
					GameEngine.Instance.downloadCurrentVillage();
					return;
				}
				if (returnData.villageID == -2)
				{
					TimeSpan timeSpan = returnData.nextTime - VillageMap.getCurrentServerTime();
					string str = (timeSpan.Days <= 0) ? string.Format("{0:D1} " + SK.Text("MENU_hours_short", "hrs") + ", {1:D2} " + SK.Text("MENU_minutes_short", "mins"), timeSpan.Hours, timeSpan.Minutes) : string.Format(string.Concat(new string[]
					{
						"{0:D2} ",
						SK.Text("MENU_days", "days"),
						", {1:D2} ",
						SK.Text("MENU_hours_short", "hrs"),
						", {2:D2} ",
						SK.Text("MENU_minutes_short", "mins")
					}), timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
					MyMessageBox.Show(SK.Text("MENU_Cannot_Change_Type", "You cannot change this Village's Type for") + " : " + str, SK.Text("MENU_Change_Type_Error", "Change Village Type Error"));
					return;
				}
			}
			else
			{
				if (returnData.m_errorCode == ErrorCodes.ErrorCode.CANT_ABANDON_WITH_INCOMING_ATTACKS)
				{
					MyMessageBox.Show(SK.Text("MENU_Cannot_Change_Incoming_Attacks", "You cannot change your village type while you have incoming attacks"), SK.Text("MENU_Change_Type_Error", "Change Village Type Error"));
					return;
				}
				MyMessageBox.Show(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), SK.Text("MENU_Change_Type_Error", "Change Village Type Error"));
			}
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0000C330 File Offset: 0x0000A530
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0000C34F File Offset: 0x0000A54F
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x040009A8 RID: 2472
		private const int CardYOffset = 60;

		// Token: 0x040009A9 RID: 2473
		private bool buying = true;

		// Token: 0x040009AA RID: 2474
		private int m_villageID = -1;

		// Token: 0x040009AB RID: 2475
		private CardBarGDI cardbar = new CardBarGDI();

		// Token: 0x040009AC RID: 2476
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009AD RID: 2477
		private CustomSelfDrawPanel.CSDImage titleImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009AE RID: 2478
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009AF RID: 2479
		private CustomSelfDrawPanel.CSDImage backgroundRightEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009B0 RID: 2480
		private CustomSelfDrawPanel.CSDImage backgroundBottomEdge = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009B1 RID: 2481
		private CustomSelfDrawPanel.CSDLabel headingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009B2 RID: 2482
		private CustomSelfDrawPanel.CSDVertExtendingPanel inset = new CustomSelfDrawPanel.CSDVertExtendingPanel();

		// Token: 0x040009B3 RID: 2483
		private CustomSelfDrawPanel.CSDVertScrollBar scrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040009B4 RID: 2484
		private CustomSelfDrawPanel.CSDArea scrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040009B5 RID: 2485
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x040009B6 RID: 2486
		private CustomSelfDrawPanel.CSDButton bigButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009B7 RID: 2487
		private CustomSelfDrawPanel.CSDButton bigButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009B8 RID: 2488
		private CustomSelfDrawPanel.CSDButton bigButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009B9 RID: 2489
		private CustomSelfDrawPanel.CSDButton bigButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BA RID: 2490
		private CustomSelfDrawPanel.CSDButton bigButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BB RID: 2491
		private CustomSelfDrawPanel.CSDButton bigButton6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BC RID: 2492
		private CustomSelfDrawPanel.CSDButton bigButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BD RID: 2493
		private CustomSelfDrawPanel.CSDButton bigButton8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BE RID: 2494
		private CustomSelfDrawPanel.CSDButton bigButton9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009BF RID: 2495
		private CustomSelfDrawPanel.CSDButton bigButton10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009C0 RID: 2496
		private CustomSelfDrawPanel.CSDImage featuresImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C1 RID: 2497
		private CustomSelfDrawPanel.CSDImage featuresImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C2 RID: 2498
		private CustomSelfDrawPanel.CSDImage featuresImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C3 RID: 2499
		private CustomSelfDrawPanel.CSDImage featuresImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C4 RID: 2500
		private CustomSelfDrawPanel.CSDImage featuresImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C5 RID: 2501
		private CustomSelfDrawPanel.CSDImage featuresImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C6 RID: 2502
		private CustomSelfDrawPanel.CSDImage featuresImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C7 RID: 2503
		private CustomSelfDrawPanel.CSDImage featuresImage8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C8 RID: 2504
		private CustomSelfDrawPanel.CSDImage featuresImage9 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009C9 RID: 2505
		private CustomSelfDrawPanel.CSDImage featuresImage10 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009CA RID: 2506
		private CustomSelfDrawPanel.CSDLabel description1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009CB RID: 2507
		private CustomSelfDrawPanel.CSDLabel description2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009CC RID: 2508
		private CustomSelfDrawPanel.CSDLabel description3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009CD RID: 2509
		private CustomSelfDrawPanel.CSDLabel description4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009CE RID: 2510
		private CustomSelfDrawPanel.CSDLabel description5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009CF RID: 2511
		private CustomSelfDrawPanel.CSDLabel description6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009D0 RID: 2512
		private CustomSelfDrawPanel.CSDLabel description7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009D1 RID: 2513
		private CustomSelfDrawPanel.CSDLabel description8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009D2 RID: 2514
		private CustomSelfDrawPanel.CSDLabel description9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009D3 RID: 2515
		private CustomSelfDrawPanel.CSDLabel description10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009D4 RID: 2516
		private CustomSelfDrawPanel.CSDButton helpButton1 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009D5 RID: 2517
		private CustomSelfDrawPanel.CSDButton helpButton2 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009D6 RID: 2518
		private CustomSelfDrawPanel.CSDButton helpButton3 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009D7 RID: 2519
		private CustomSelfDrawPanel.CSDButton helpButton4 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009D8 RID: 2520
		private CustomSelfDrawPanel.CSDButton helpButton5 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009D9 RID: 2521
		private CustomSelfDrawPanel.CSDButton helpButton6 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009DA RID: 2522
		private CustomSelfDrawPanel.CSDButton helpButton7 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009DB RID: 2523
		private CustomSelfDrawPanel.CSDButton helpButton8 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009DC RID: 2524
		private CustomSelfDrawPanel.CSDButton helpButton9 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009DD RID: 2525
		private CustomSelfDrawPanel.CSDButton helpButton10 = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040009DE RID: 2526
		private CustomSelfDrawPanel.CSDImage featuresOverImage1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009DF RID: 2527
		private CustomSelfDrawPanel.CSDImage featuresOverImage2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E0 RID: 2528
		private CustomSelfDrawPanel.CSDImage featuresOverImage3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E1 RID: 2529
		private CustomSelfDrawPanel.CSDImage featuresOverImage4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E2 RID: 2530
		private CustomSelfDrawPanel.CSDImage featuresOverImage5 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E3 RID: 2531
		private CustomSelfDrawPanel.CSDImage featuresOverImage6 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E4 RID: 2532
		private CustomSelfDrawPanel.CSDImage featuresOverImage7 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E5 RID: 2533
		private CustomSelfDrawPanel.CSDImage featuresOverImage8 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E6 RID: 2534
		private CustomSelfDrawPanel.CSDImage featuresOverImage9 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E7 RID: 2535
		private CustomSelfDrawPanel.CSDImage featuresOverImage10 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040009E8 RID: 2536
		private CustomSelfDrawPanel.CSDLabel featuresLabela1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009E9 RID: 2537
		private CustomSelfDrawPanel.CSDLabel featuresLabelb1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009EA RID: 2538
		private CustomSelfDrawPanel.CSDLabel featuresLabelc1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009EB RID: 2539
		private CustomSelfDrawPanel.CSDLabel featuresLabeld1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009EC RID: 2540
		private CustomSelfDrawPanel.CSDLabel featuresLabele1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009ED RID: 2541
		private CustomSelfDrawPanel.CSDLabel featuresLabelf1 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009EE RID: 2542
		private CustomSelfDrawPanel.CSDLabel featuresLabela2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009EF RID: 2543
		private CustomSelfDrawPanel.CSDLabel featuresLabelb2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F0 RID: 2544
		private CustomSelfDrawPanel.CSDLabel featuresLabelc2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F1 RID: 2545
		private CustomSelfDrawPanel.CSDLabel featuresLabeld2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F2 RID: 2546
		private CustomSelfDrawPanel.CSDLabel featuresLabele2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F3 RID: 2547
		private CustomSelfDrawPanel.CSDLabel featuresLabelf2 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F4 RID: 2548
		private CustomSelfDrawPanel.CSDLabel featuresLabela3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F5 RID: 2549
		private CustomSelfDrawPanel.CSDLabel featuresLabelb3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F6 RID: 2550
		private CustomSelfDrawPanel.CSDLabel featuresLabelc3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F7 RID: 2551
		private CustomSelfDrawPanel.CSDLabel featuresLabeld3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F8 RID: 2552
		private CustomSelfDrawPanel.CSDLabel featuresLabele3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009F9 RID: 2553
		private CustomSelfDrawPanel.CSDLabel featuresLabelf3 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FA RID: 2554
		private CustomSelfDrawPanel.CSDLabel featuresLabela4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FB RID: 2555
		private CustomSelfDrawPanel.CSDLabel featuresLabelb4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FC RID: 2556
		private CustomSelfDrawPanel.CSDLabel featuresLabelc4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FD RID: 2557
		private CustomSelfDrawPanel.CSDLabel featuresLabeld4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FE RID: 2558
		private CustomSelfDrawPanel.CSDLabel featuresLabele4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040009FF RID: 2559
		private CustomSelfDrawPanel.CSDLabel featuresLabelf4 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A00 RID: 2560
		private CustomSelfDrawPanel.CSDLabel featuresLabela5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A01 RID: 2561
		private CustomSelfDrawPanel.CSDLabel featuresLabelb5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A02 RID: 2562
		private CustomSelfDrawPanel.CSDLabel featuresLabelc5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A03 RID: 2563
		private CustomSelfDrawPanel.CSDLabel featuresLabeld5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A04 RID: 2564
		private CustomSelfDrawPanel.CSDLabel featuresLabele5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A05 RID: 2565
		private CustomSelfDrawPanel.CSDLabel featuresLabelf5 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A06 RID: 2566
		private CustomSelfDrawPanel.CSDLabel featuresLabela6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A07 RID: 2567
		private CustomSelfDrawPanel.CSDLabel featuresLabelb6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A08 RID: 2568
		private CustomSelfDrawPanel.CSDLabel featuresLabelc6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A09 RID: 2569
		private CustomSelfDrawPanel.CSDLabel featuresLabeld6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0A RID: 2570
		private CustomSelfDrawPanel.CSDLabel featuresLabele6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0B RID: 2571
		private CustomSelfDrawPanel.CSDLabel featuresLabelf6 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0C RID: 2572
		private CustomSelfDrawPanel.CSDLabel featuresLabela7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0D RID: 2573
		private CustomSelfDrawPanel.CSDLabel featuresLabelb7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0E RID: 2574
		private CustomSelfDrawPanel.CSDLabel featuresLabelc7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A0F RID: 2575
		private CustomSelfDrawPanel.CSDLabel featuresLabeld7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A10 RID: 2576
		private CustomSelfDrawPanel.CSDLabel featuresLabele7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A11 RID: 2577
		private CustomSelfDrawPanel.CSDLabel featuresLabelf7 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A12 RID: 2578
		private CustomSelfDrawPanel.CSDLabel featuresLabela8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A13 RID: 2579
		private CustomSelfDrawPanel.CSDLabel featuresLabelb8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A14 RID: 2580
		private CustomSelfDrawPanel.CSDLabel featuresLabelc8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A15 RID: 2581
		private CustomSelfDrawPanel.CSDLabel featuresLabeld8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A16 RID: 2582
		private CustomSelfDrawPanel.CSDLabel featuresLabele8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A17 RID: 2583
		private CustomSelfDrawPanel.CSDLabel featuresLabelf8 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A18 RID: 2584
		private CustomSelfDrawPanel.CSDLabel featuresLabela9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A19 RID: 2585
		private CustomSelfDrawPanel.CSDLabel featuresLabelb9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1A RID: 2586
		private CustomSelfDrawPanel.CSDLabel featuresLabelc9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1B RID: 2587
		private CustomSelfDrawPanel.CSDLabel featuresLabeld9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1C RID: 2588
		private CustomSelfDrawPanel.CSDLabel featuresLabele9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1D RID: 2589
		private CustomSelfDrawPanel.CSDLabel featuresLabelf9 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1E RID: 2590
		private CustomSelfDrawPanel.CSDLabel featuresLabela10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A1F RID: 2591
		private CustomSelfDrawPanel.CSDLabel featuresLabelb10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A20 RID: 2592
		private CustomSelfDrawPanel.CSDLabel featuresLabelc10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A21 RID: 2593
		private CustomSelfDrawPanel.CSDLabel featuresLabeld10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A22 RID: 2594
		private CustomSelfDrawPanel.CSDLabel featuresLabele10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A23 RID: 2595
		private CustomSelfDrawPanel.CSDLabel featuresLabelf10 = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A24 RID: 2596
		private CustomSelfDrawPanel.CSDCheckBox peaceTimeCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04000A25 RID: 2597
		private CustomSelfDrawPanel.CSDLabel convertLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000A26 RID: 2598
		private IContainer components;
	}
}
