using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020001DD RID: 477
	public class FreeCardsPanel : CustomSelfDrawPanel
	{
		// Token: 0x0600120D RID: 4621 RVA: 0x00013A09 File Offset: 0x00011C09
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00013A28 File Offset: 0x00011C28
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x0012EEFC File Offset: 0x0012D0FC
		public FreeCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0012F23C File Offset: 0x0012D43C
		public void init(bool initialCall)
		{
			this.freeCardInfo = GameEngine.Instance.World.FreeCardInfo;
			if (!this.freeCardInfo.VeteranStages[0] && initialCall)
			{
				RemoteServices.Instance.set_InitialiseFreeCards_UserCallBack(new RemoteServices.InitialiseFreeCards_UserCallBack(this.initialiseFreeCardsCallback));
				RemoteServices.Instance.InitialiseFreeCards();
			}
			else if (initialCall && DateTime.Now.Subtract(FreeCardsPanel.lastVeteranLevelTime).TotalSeconds > 120.0)
			{
				this.UpdateVeteranLevelData();
				FreeCardsPanel.lastVeteranLevelTime = DateTime.Now;
			}
			TimeSpan timeSpan = this.freeCardInfo.timeUntilNextFreeCard();
			bool flag = false;
			if (timeSpan.TotalSeconds <= 0.0 && this.freeCardInfo.VeteranStages[0] && this.freeCardInfo.CurrentVeteranLevel > 0)
			{
				flag = true;
			}
			int num = 46;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.MainPanel.Size = base.Size;
			this.MainPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.MainPanel);
			this.MainPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.cardpanel_panel_gradient_top_left;
			csdimage.Size = GFXLibrary.cardpanel_panel_gradient_top_left.Size;
			csdimage.Position = new Point(0, 0);
			this.MainPanel.addControl(csdimage);
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = GFXLibrary.cardpanel_panel_gradient_bottom_right;
			csdimage2.Size = GFXLibrary.cardpanel_panel_gradient_bottom_right.Size;
			csdimage2.Position = new Point(this.MainPanel.Width - csdimage2.Width - 6, this.MainPanel.Height - csdimage2.Height - 6);
			this.MainPanel.addControl(csdimage2);
			this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			this.closeImage.Size = this.closeImage.Image.Size;
			this.closeImage.setMouseOverDelegate(delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Cards_Close");
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.closeImage.CustomTooltipID = 10100;
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			CustomSelfDrawPanel.CSDFill csdfill2 = new CustomSelfDrawPanel.CSDFill();
			csdfill2.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill2.Size = new Size(base.Width - 10, 1);
			csdfill2.Position = new Point(5, 116);
			this.mainBackgroundImage.addControl(csdfill2);
			this.labelTitle.Position = new Point(27, 5);
			this.labelTitle.Size = new Size(600, 64);
			this.labelTitle.Text = SK.Text("FreeCardsPanel_Free_Cards", "Free Cards");
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			if (this.freeCardInfo.CurrentVeteranLevel > 0 && !flag)
			{
				this.greenArea.Size = new Size(955, num * this.freeCardInfo.CurrentVeteranLevel);
				this.greenArea.Position = new Point(20, 123);
				this.mainBackgroundImage.addControl(this.greenArea);
				this.greenArea.Create(GFXLibrary.free_card_screen_green_panel_top_left, GFXLibrary.free_card_screen_green_panel_top_mid, GFXLibrary.free_card_screen_green_panel_top_right, GFXLibrary.free_card_screen_green_panel_mid_left, GFXLibrary.free_card_screen_green_panel_mid_mid, GFXLibrary.free_card_screen_green_panel_mid_right, GFXLibrary.free_card_screen_green_panel_bottom_left, GFXLibrary.free_card_screen_green_panel_bottom_mid, GFXLibrary.free_card_screen_green_panel_bottom_right);
			}
			this.timeProgress.Position = new Point(128, 85);
			this.timeProgress.Size = new Size(210, 6);
			this.mainBackgroundImage.addControl(this.timeProgress);
			this.timeProgress.Create(GFXLibrary.free_card_screen_progbar_left, GFXLibrary.free_card_screen_progbar_mid, GFXLibrary.free_card_screen_progbar_right, GFXLibrary.free_card_screen_progbar_fill, GFXLibrary.free_card_screen_progbar_fill, GFXLibrary.free_card_screen_progbar_fill);
			this.timeProgress.setValues(this.freeCardInfo.durationHours() - timeSpan.TotalHours, this.freeCardInfo.durationHours());
			this.labelVeteranLevel.Position = new Point(125, 36);
			this.labelVeteranLevel.Size = new Size(600, 64);
			this.labelVeteranLevel.Text = SK.Text("FreeCardsPanel_Level", "Kingdoms Veteran Level") + " : " + this.freeCardInfo.CurrentVeteranLevel.ToString();
			this.labelVeteranLevel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelVeteranLevel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.labelVeteranLevel.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelVeteranLevel);
			this.labelFreeCards.Position = new Point(128, 64);
			this.labelFreeCards.Size = new Size(600, 64);
			this.labelFreeCards.Text = SK.Text("FreeCardsPanel_Cards_Per_Week", "Cards per week") + " : " + this.freeCardInfo.freeCardsPerWeek().ToString();
			this.labelFreeCards.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelFreeCards.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.labelFreeCards.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelFreeCards);
			string text = SK.Text("FreeCardsPanel_Next_Card", "Next Card") + ": ";
			if (timeSpan.TotalSeconds >= 1.0 && timeSpan.TotalDays < 100.0 && this.freeCardInfo.CurrentVeteranLevel > 0)
			{
				text += VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds);
			}
			this.labelNextCards.Position = new Point(128, 97);
			this.labelNextCards.Size = new Size(600, 64);
			this.labelNextCards.Text = text;
			this.labelNextCards.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelNextCards.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.labelNextCards.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelNextCards);
			if (this.freeCardInfo.CurrentVeteranLevel > 0)
			{
				this.crestImage.Image = GFXLibrary.free_card_screen_wax_array[this.freeCardInfo.CurrentVeteranLevel - 1];
				this.crestImage.Position = new Point(21, 35);
				this.mainBackgroundImage.addControl(this.crestImage);
			}
			if (!flag)
			{
				int x = 25;
				int num2 = 123;
				int x2 = 155;
				int num3 = 131;
				int x3 = 190;
				int num4 = 135;
				int x4 = 540;
				int num5 = 131;
				this.cards1Image.Image = this.getCardImage(0);
				this.cards1Image.Position = new Point(x, num2);
				this.mainBackgroundImage.addControl(this.cards1Image);
				this.cards1Label.Position = new Point(-5, -5);
				this.cards1Label.Size = this.cards1Image.Size;
				this.cards1Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(1).ToString();
				this.cards1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards1Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards1Label.Color = global::ARGBColors.White;
				this.cards1Label.DropShadowColor = global::ARGBColors.Black;
				this.cards1Image.addControl(this.cards1Label);
				this.tick1Image.Image = this.getTickImage(0);
				this.tick1Image.Position = new Point(x2, num3);
				this.mainBackgroundImage.addControl(this.tick1Image);
				this.description1Label.Position = new Point(x3, num4);
				this.description1Label.Size = new Size(600, 64);
				this.description1Label.Text = SK.Text("FreeCardsPanel__Site_Village", "Site Village");
				this.description1Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description1Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description1Label.Color = this.getTextColour(0);
				this.mainBackgroundImage.addControl(this.description1Label);
				this.level1Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.level1Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.level1Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.level1Button.Position = new Point(x4, num5);
				this.level1Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
				this.level1Button.TextYOffset = -2;
				this.level1Button.Text.Color = this.getButtonTextColour(0);
				this.level1Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.level1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
				this.level1Button.Data = 0;
				this.level1Button.Visible = this.isButtonVisible(0);
				this.level1Button.Enabled = this.isButtonEnabled(0);
				this.mainBackgroundImage.addControl(this.level1Button);
				this.cards2Image.Image = this.getCardImage(1);
				this.cards2Image.Position = new Point(x, num2 + num);
				this.mainBackgroundImage.addControl(this.cards2Image);
				this.cards2Label.Position = new Point(-5, -5);
				this.cards2Label.Size = this.cards1Image.Size;
				this.cards2Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(2).ToString();
				this.cards2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards2Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards2Label.Color = global::ARGBColors.White;
				this.cards2Label.DropShadowColor = global::ARGBColors.Black;
				this.cards2Image.addControl(this.cards2Label);
				this.tick2Image.Image = this.getTickImage(1);
				this.tick2Image.Position = new Point(x2, num3 + num);
				this.mainBackgroundImage.addControl(this.tick2Image);
				this.description2Label.Position = new Point(x3, num4 + num);
				this.description2Label.Size = new Size(600, 64);
				this.description2Label.Text = SK.Text("FreeCardsPanel_Rank_Yokel", "Get to Rank of Yokel") + " (3)";
				this.description2Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description2Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description2Label.Color = this.getTextColour(1);
				this.mainBackgroundImage.addControl(this.description2Label);
				this.level2Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.level2Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.level2Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.level2Button.Position = new Point(x4, num5 + num);
				this.level2Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
				this.level2Button.TextYOffset = -2;
				this.level2Button.Text.Color = this.getButtonTextColour(1);
				this.level2Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.level2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
				this.level2Button.Data = 1;
				this.level2Button.Visible = this.isButtonVisible(1);
				this.level2Button.Enabled = this.isButtonEnabled(1);
				this.mainBackgroundImage.addControl(this.level2Button);
				this.cards3Image.Image = this.getCardImage(2);
				this.cards3Image.Position = new Point(x, num2 + 2 * num);
				this.mainBackgroundImage.addControl(this.cards3Image);
				this.cards3Label.Position = new Point(-5, -5);
				this.cards3Label.Size = this.cards1Image.Size;
				this.cards3Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(3).ToString();
				this.cards3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards3Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards3Label.Color = global::ARGBColors.White;
				this.cards3Label.DropShadowColor = global::ARGBColors.Black;
				this.cards3Image.addControl(this.cards3Label);
				this.tick3Image.Image = this.getTickImage(2);
				this.tick3Image.Position = new Point(x2, num3 + 2 * num);
				this.mainBackgroundImage.addControl(this.tick3Image);
				this.description3Label.Position = new Point(x3, num4 + 2 * num);
				this.description3Label.Size = new Size(600, 64);
				this.description3Label.Text = SK.Text("FreeCardsPanel_Rank_Villein", "Get to Rank of Villein") + " (6)";
				this.description3Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description3Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description3Label.Color = this.getTextColour(2);
				this.mainBackgroundImage.addControl(this.description3Label);
				this.level3Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.level3Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.level3Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.level3Button.Position = new Point(x4, num5 + 2 * num);
				this.level3Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
				this.level3Button.TextYOffset = -2;
				this.level3Button.Text.Color = this.getButtonTextColour(2);
				this.level3Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.level3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
				this.level3Button.Data = 2;
				this.level3Button.Visible = this.isButtonVisible(2);
				this.level3Button.Enabled = this.isButtonEnabled(2);
				this.mainBackgroundImage.addControl(this.level3Button);
				this.cards4Image.Image = this.getCardImage(3);
				this.cards4Image.Position = new Point(x, num2 + 3 * num);
				this.mainBackgroundImage.addControl(this.cards4Image);
				this.cards4Label.Position = new Point(-5, -5);
				this.cards4Label.Size = this.cards1Image.Size;
				this.cards4Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(4).ToString();
				this.cards4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards4Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards4Label.Color = global::ARGBColors.White;
				this.cards4Label.DropShadowColor = global::ARGBColors.Black;
				this.cards4Image.addControl(this.cards4Label);
				this.tick4Image.Image = this.getTickImage(3);
				this.tick4Image.Position = new Point(x2, num3 + 3 * num);
				this.mainBackgroundImage.addControl(this.tick4Image);
				this.description4Label.Position = new Point(x3, num4 + 3 * num);
				this.description4Label.Size = new Size(600, 64);
				this.description4Label.Text = SK.Text("FreeCardsPanel_First_Purchase_Crowns", "First Purchase of Crowns");
				this.description4Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description4Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description4Label.Color = this.getTextColour(3);
				this.mainBackgroundImage.addControl(this.description4Label);
				this.level4Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.level4Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.level4Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.level4Button.Position = new Point(x4, num5 + 3 * num);
				this.level4Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
				this.level4Button.TextYOffset = -2;
				this.level4Button.Text.Color = this.getButtonTextColour(3);
				this.level4Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.level4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
				this.level4Button.Data = 3;
				this.level4Button.Visible = this.isButtonVisible(3);
				this.level4Button.Enabled = this.isButtonEnabled(3);
				this.mainBackgroundImage.addControl(this.level4Button);
				this.cards5Image.Image = this.getCardImage(4);
				this.cards5Image.Position = new Point(x, num2 + 4 * num);
				this.mainBackgroundImage.addControl(this.cards5Image);
				this.cards5Label.Position = new Point(-5, -5);
				this.cards5Label.Size = this.cards1Image.Size;
				this.cards5Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(5).ToString();
				this.cards5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards5Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards5Label.Color = global::ARGBColors.White;
				this.cards5Label.DropShadowColor = global::ARGBColors.Black;
				this.cards5Image.addControl(this.cards5Label);
				this.tick5Image.Image = this.getTickImage(4);
				this.tick5Image.Position = new Point(x2, num3 + 4 * num);
				this.mainBackgroundImage.addControl(this.tick5Image);
				this.description5Label.Position = new Point(x3, num4 + 4 * num);
				this.description5Label.Size = new Size(600, 64);
				this.description5Label.Text = SK.Text("FreeCardsPanel_Rank_Commoner", "Get to Rank of Commoner") + " (9)";
				this.description5Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description5Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description5Label.Color = this.getTextColour(4);
				this.mainBackgroundImage.addControl(this.description5Label);
				this.level5Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.level5Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.level5Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.level5Button.Position = new Point(x4, num5 + 4 * num);
				this.level5Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
				this.level5Button.TextYOffset = -2;
				this.level5Button.Text.Color = this.getButtonTextColour(4);
				this.level5Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.level5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
				this.level5Button.Data = 4;
				this.level5Button.Visible = this.isButtonVisible(4);
				this.level5Button.Enabled = this.isButtonEnabled(4);
				this.mainBackgroundImage.addControl(this.level5Button);
				this.cards6Image.Image = this.getCardImage(5);
				this.cards6Image.Position = new Point(x, num2 + 5 * num);
				this.mainBackgroundImage.addControl(this.cards6Image);
				this.cards6Label.Position = new Point(-5, -5);
				this.cards6Label.Size = this.cards1Image.Size;
				this.cards6Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(6).ToString();
				this.cards6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards6Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards6Label.Color = global::ARGBColors.White;
				this.cards6Label.DropShadowColor = global::ARGBColors.Black;
				this.cards6Image.addControl(this.cards6Label);
				this.tick6Image.Image = this.getTickImage(5);
				this.tick6Image.Position = new Point(x2, num3 + 5 * num);
				this.mainBackgroundImage.addControl(this.tick6Image);
				this.description6Label.Position = new Point(x3, num4 + 5 * num);
				this.description6Label.Size = new Size(600, 64);
				this.description6Label.Text = SK.Text("FreeCardsPanel_Donate_Resources", "Donate Resources to your Parish Capital");
				this.description6Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description6Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description6Label.Color = this.getTextColour(5);
				this.mainBackgroundImage.addControl(this.description6Label);
				if (!GameEngine.Instance.World.InviteSystemNotImplemented)
				{
					this.level6Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.level6Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.level6Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.level6Button.Position = new Point(x4, num5 + 5 * num);
					this.level6Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
					this.level6Button.TextYOffset = -2;
					this.level6Button.Text.Color = this.getButtonTextColour(5);
					this.level6Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.level6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
					this.level6Button.Data = 5;
					this.level6Button.Visible = this.isButtonVisible(5);
					this.level6Button.Enabled = this.isButtonEnabled(5);
					this.mainBackgroundImage.addControl(this.level6Button);
				}
				this.cards7Image.Image = this.getCardImage(6);
				this.cards7Image.Position = new Point(x, num2 + 6 * num);
				this.mainBackgroundImage.addControl(this.cards7Image);
				this.cards7Label.Position = new Point(-5, -5);
				this.cards7Label.Size = this.cards1Image.Size;
				this.cards7Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(7).ToString();
				this.cards7Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards7Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards7Label.Color = global::ARGBColors.White;
				this.cards7Label.DropShadowColor = global::ARGBColors.Black;
				this.cards7Image.addControl(this.cards7Label);
				this.tick7Image.Image = this.getTickImage(6);
				this.tick7Image.Position = new Point(x2, num3 + 6 * num);
				this.mainBackgroundImage.addControl(this.tick7Image);
				this.description7Label.Position = new Point(x3, num4 + 6 * num);
				this.description7Label.Size = new Size(600, 64);
				this.description7Label.Text = SK.Text("FreeCardsPanel_Rank_Yeoman", "Get to Rank of Yeoman") + " (11)";
				this.description7Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description7Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description7Label.Color = this.getTextColour(6);
				this.mainBackgroundImage.addControl(this.description7Label);
				if (!GameEngine.Instance.World.InviteSystemNotImplemented)
				{
					this.level7Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.level7Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.level7Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.level7Button.Position = new Point(x4, num5 + 6 * num);
					this.level7Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
					this.level7Button.TextYOffset = -2;
					this.level7Button.Text.Color = this.getButtonTextColour(6);
					this.level7Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.level7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
					this.level7Button.Data = 6;
					this.level7Button.Visible = this.isButtonVisible(6);
					this.level7Button.Enabled = this.isButtonEnabled(6);
					this.mainBackgroundImage.addControl(this.level7Button);
				}
				this.cards8Image.Image = this.getCardImage(7);
				this.cards8Image.Position = new Point(x, num2 + 7 * num);
				this.mainBackgroundImage.addControl(this.cards8Image);
				this.cards8Label.Position = new Point(-5, -5);
				this.cards8Label.Size = this.cards1Image.Size;
				this.cards8Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(8).ToString();
				this.cards8Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards8Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards8Label.Color = global::ARGBColors.White;
				this.cards8Label.DropShadowColor = global::ARGBColors.Black;
				this.cards8Image.addControl(this.cards8Label);
				this.tick8Image.Image = this.getTickImage(7);
				this.tick8Image.Position = new Point(x2, num3 + 7 * num);
				this.mainBackgroundImage.addControl(this.tick8Image);
				this.description8Label.Position = new Point(x3, num4 + 7 * num);
				this.description8Label.Size = new Size(600, 64);
				this.description8Label.Text = SK.Text("FreeCardsPanel_Factions", "Create or Join a Faction");
				this.description8Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description8Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description8Label.Color = this.getTextColour(7);
				this.mainBackgroundImage.addControl(this.description8Label);
				if (!GameEngine.Instance.World.InviteSystemNotImplemented)
				{
					this.level8Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.level8Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.level8Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.level8Button.Position = new Point(x4, num5 + 7 * num);
					this.level8Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
					this.level8Button.TextYOffset = -2;
					this.level8Button.Text.Color = this.getButtonTextColour(7);
					this.level8Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.level8Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
					this.level8Button.Data = 7;
					this.level8Button.Visible = this.isButtonVisible(7);
					this.level8Button.Enabled = this.isButtonEnabled(7);
					this.mainBackgroundImage.addControl(this.level8Button);
				}
				this.cards9Image.Image = this.getCardImage(8);
				this.cards9Image.Position = new Point(x, num2 + 8 * num);
				this.mainBackgroundImage.addControl(this.cards9Image);
				this.cards9Label.Position = new Point(-6, -5);
				this.cards9Label.Size = this.cards1Image.Size;
				this.cards9Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(9).ToString();
				this.cards9Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards9Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards9Label.Color = global::ARGBColors.White;
				this.cards9Label.DropShadowColor = global::ARGBColors.Black;
				this.cards9Image.addControl(this.cards9Label);
				this.tick9Image.Image = this.getTickImage(8);
				this.tick9Image.Position = new Point(x2, num3 + 8 * num);
				this.mainBackgroundImage.addControl(this.tick9Image);
				this.description9Label.Position = new Point(x3, num4 + 8 * num);
				this.description9Label.Size = new Size(600, 64);
				this.description9Label.Text = SK.Text("FreeCardsPanel_Second_Crowns", "Second purchase of Crowns");
				this.description9Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description9Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description9Label.Color = this.getTextColour(8);
				this.mainBackgroundImage.addControl(this.description9Label);
				if (!GameEngine.Instance.World.InviteSystemNotImplemented)
				{
					this.level9Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.level9Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.level9Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.level9Button.Position = new Point(x4, num5 + 8 * num);
					this.level9Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
					this.level9Button.TextYOffset = -2;
					this.level9Button.Text.Color = this.getButtonTextColour(8);
					this.level9Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.level9Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
					this.level9Button.Data = 8;
					this.level9Button.Visible = this.isButtonVisible(8);
					this.level9Button.Enabled = this.isButtonEnabled(8);
					this.mainBackgroundImage.addControl(this.level9Button);
				}
				this.cards10Image.Image = this.getCardImage(9);
				this.cards10Image.Position = new Point(x, num2 + 9 * num);
				this.mainBackgroundImage.addControl(this.cards10Image);
				this.cards10Label.Position = new Point(-6, -5);
				this.cards10Label.Size = this.cards1Image.Size;
				this.cards10Label.Text = GameEngine.Instance.World.FreeCardInfo.freeCardsPerWeek(10).ToString();
				this.cards10Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.cards10Label.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
				this.cards10Label.Color = global::ARGBColors.White;
				this.cards10Label.DropShadowColor = global::ARGBColors.Black;
				this.cards10Image.addControl(this.cards10Label);
				this.tick10Image.Image = this.getTickImage(9);
				this.tick10Image.Position = new Point(x2, num3 + 9 * num);
				this.mainBackgroundImage.addControl(this.tick10Image);
				this.description10Label.Position = new Point(x3, num4 + 9 * num);
				this.description10Label.Size = new Size(600, 64);
				this.description10Label.Text = SK.Text("FreeCardsPanel_Rank_Squire", "Get to Rank of Squire") + " (15)";
				this.description10Label.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.description10Label.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.description10Label.Color = this.getTextColour(9);
				this.mainBackgroundImage.addControl(this.description10Label);
				if (!GameEngine.Instance.World.InviteSystemNotImplemented)
				{
					this.level10Button.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.level10Button.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.level10Button.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.level10Button.Position = new Point(x4, num5 + 9 * num);
					this.level10Button.Text.Text = SK.Text("FreeCardsPanel_Increase_Level", "Increase Level");
					this.level10Button.TextYOffset = -2;
					this.level10Button.Text.Color = this.getButtonTextColour(9);
					this.level10Button.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.level10Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.increaseLevel), "FreeCardsPanel_increase_level");
					this.level10Button.Data = 9;
					this.level10Button.Visible = this.isButtonVisible(9);
					this.level10Button.Enabled = this.isButtonEnabled(9);
					this.mainBackgroundImage.addControl(this.level10Button);
				}
				if (this.freeCardInfo.VeteranStages[2] && !this.isButtonVisible(3) && !this.freeCardInfo.VeteranStages[3])
				{
					this.buyCrownsButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.buyCrownsButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.buyCrownsButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.buyCrownsButton.Position = new Point(x4, num5 + 3 * num);
					this.buyCrownsButton.Text.Text = SK.Text("BuyCrownsPanel_Buy_Crowns", "Buy Crowns");
					this.buyCrownsButton.TextYOffset = -2;
					this.buyCrownsButton.Text.Color = global::ARGBColors.Black;
					this.buyCrownsButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.buyCrownsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyCrowns));
					this.buyCrownsButton.Data = 3;
					this.buyCrownsButton.Visible = true;
					this.buyCrownsButton.Enabled = true;
					this.mainBackgroundImage.addControl(this.buyCrownsButton);
				}
				else if (this.freeCardInfo.VeteranStages[7] && !this.isButtonVisible(8) && !this.freeCardInfo.VeteranStages[8])
				{
					this.buyCrownsButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
					this.buyCrownsButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
					this.buyCrownsButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
					this.buyCrownsButton.Position = new Point(x4, num5 + 8 * num);
					this.buyCrownsButton.Text.Text = SK.Text("BuyCrownsPanel_Buy_Crowns", "Buy Crowns");
					this.buyCrownsButton.TextYOffset = -2;
					this.buyCrownsButton.Text.Color = global::ARGBColors.Black;
					this.buyCrownsButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.buyCrownsButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.buyCrowns));
					this.buyCrownsButton.Data = 3;
					this.buyCrownsButton.Visible = true;
					this.buyCrownsButton.Enabled = true;
					this.mainBackgroundImage.addControl(this.buyCrownsButton);
				}
			}
			else
			{
				this.parchmentImage.Image = GFXLibrary.you_got_free_card_screen_parchment;
				this.parchmentImage.Position = new Point(175, 125);
				this.mainBackgroundImage.addControl(this.parchmentImage);
				this.cardBackImage.Image = GFXLibrary.you_got_free_card_screen_cardback;
				this.cardBackImage.Position = new Point(226, 40);
				this.cardBackImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.revealCard), "FreeCardsPanel_reveal_card");
				this.parchmentImage.addControl(this.cardBackImage);
				this.revealButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
				this.revealButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
				this.revealButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
				this.revealButton.Position = new Point(248, 310);
				this.revealButton.Text.Text = SK.Text("FreeCardsPanel_Reveal", "Reveal");
				this.revealButton.TextYOffset = -2;
				this.revealButton.Text.Color = global::ARGBColors.Black;
				this.revealButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.revealButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.revealCard), "FreeCardsPanel_reveal_card");
				this.parchmentImage.addControl(this.revealButton);
				if (!GameEngine.Instance.World.isBigpointAccount && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
				{
					CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
					csdbutton.ImageNorm = GFXLibrary.banner_ad_friend;
					csdbutton.OverBrighten = true;
					csdbutton.Position = new Point(201, this.parchmentImage.Y + 400 - 10);
					csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.friendClicked), "FreeCardsPanel_invite_friend");
					this.mainBackgroundImage.addControl(csdbutton);
				}
			}
			this.fanImage.Image = GFXLibrary.free_card_screen_card_fan;
			this.fanImage.Position = new Point(650, 6);
			this.mainBackgroundImage.addControl(this.fanImage);
			base.Invalidate();
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00131C68 File Offset: 0x0012FE68
		private BaseImage getCardImage(int row)
		{
			int num = 0;
			switch (row)
			{
			case 0:
				num = 0;
				break;
			case 1:
				num = 2;
				break;
			case 2:
				num = 4;
				break;
			case 3:
				num = 6;
				break;
			case 4:
				num = 8;
				break;
			case 5:
				num = 8;
				break;
			case 6:
				num = 8;
				break;
			case 7:
				num = 8;
				break;
			case 8:
				num = 10;
				break;
			case 9:
				num = 12;
				break;
			}
			if (row + 1 == this.freeCardInfo.CurrentVeteranLevel)
			{
				num++;
			}
			return GFXLibrary.free_card_screen_cardback_array[num];
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x00013A3C File Offset: 0x00011C3C
		private bool isButtonVisible(int row)
		{
			return row + 1 > this.freeCardInfo.CurrentVeteranLevel && this.freeCardInfo.VeteranStages[row];
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x00013A5D File Offset: 0x00011C5D
		private bool isButtonEnabled(int row)
		{
			return row == this.freeCardInfo.CurrentVeteranLevel;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x00013A70 File Offset: 0x00011C70
		private BaseImage getTickImage(int row)
		{
			if (this.freeCardInfo.VeteranStages[row])
			{
				return GFXLibrary.checkbox_checked;
			}
			return GFXLibrary.checkbox_unchecked;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00013A8C File Offset: 0x00011C8C
		private Color getTextColour(int row)
		{
			if (this.freeCardInfo.VeteranStages[row])
			{
				return global::ARGBColors.Green;
			}
			return global::ARGBColors.Gray;
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00013AA8 File Offset: 0x00011CA8
		private Color getButtonTextColour(int row)
		{
			if (this.isButtonEnabled(row))
			{
				return global::ARGBColors.Black;
			}
			return global::ARGBColors.Gray;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00131CEC File Offset: 0x0012FEEC
		public void update()
		{
			string text = SK.Text("FreeCardsPanel_Next_Card", "Next Card") + ": ";
			TimeSpan timeSpan = this.freeCardInfo.timeUntilNextFreeCard();
			if (timeSpan.TotalSeconds >= 1.0 && timeSpan.TotalDays < 100.0 && this.freeCardInfo.CurrentVeteranLevel > 0)
			{
				text += VillageMap.createBuildTimeString((int)timeSpan.TotalSeconds);
			}
			this.labelNextCards.Text = text;
			this.timeProgress.setValues(this.freeCardInfo.durationHours() - timeSpan.TotalHours, this.freeCardInfo.durationHours());
		}

		// Token: 0x06001218 RID: 4632 RVA: 0x00013ABE File Offset: 0x00011CBE
		private void closeClick()
		{
			InterfaceMgr.Instance.closeFreeCardsPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001219 RID: 4633 RVA: 0x00131D9C File Offset: 0x0012FF9C
		private void increaseLevel()
		{
			if (this.freeCardInfo.CurrentVeteranLevel < 10 && (!this.inIncreaseLevel || (DateTime.Now - this.lastIncreaseLevelClick).TotalSeconds >= 60.0))
			{
				this.inIncreaseLevel = true;
				this.lastIncreaseLevelClick = DateTime.Now;
				XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
				xmlRpcCardsProvider.veteranLevelUp(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""))
				{
					SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
				}, new CardsEndResponseDelegate(this.increaseLevelCallback), this);
			}
		}

		// Token: 0x0600121A RID: 4634 RVA: 0x00131E84 File Offset: 0x00130084
		private void buyCrowns()
		{
			InterfaceMgr.Instance.openPlayCardsWindow(0);
			PlayCardsWindow playCardsWindow = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
			playCardsWindow.GetCrowns();
		}

		// Token: 0x0600121B RID: 4635 RVA: 0x00131EB4 File Offset: 0x001300B4
		private void increaseLevelCallback(ICardsProvider provider, ICardsResponse response)
		{
			this.inIncreaseLevel = false;
			if (response.SuccessCode.Value == 1)
			{
				bool[] array = new bool[10];
				int num = 0;
				bool flag;
				if (((XmlRpcCardsResponse)response).VeteranLevel1 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel1;
					int num3 = 1;
					flag = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag = false;
				}
				array[num] = flag;
				int num4 = 1;
				bool flag2;
				if (((XmlRpcCardsResponse)response).VeteranLevel2 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel2;
					int num3 = 1;
					flag2 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag2 = false;
				}
				array[num4] = flag2;
				int num5 = 2;
				bool flag3;
				if (((XmlRpcCardsResponse)response).VeteranLevel3 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel3;
					int num3 = 1;
					flag3 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag3 = false;
				}
				array[num5] = flag3;
				int num6 = 3;
				bool flag4;
				if (((XmlRpcCardsResponse)response).VeteranLevel4 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel4;
					int num3 = 1;
					flag4 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag4 = false;
				}
				array[num6] = flag4;
				int num7 = 4;
				bool flag5;
				if (((XmlRpcCardsResponse)response).VeteranLevel5 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel5;
					int num3 = 1;
					flag5 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag5 = false;
				}
				array[num7] = flag5;
				int num8 = 5;
				bool flag6;
				if (((XmlRpcCardsResponse)response).VeteranLevel6 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel6;
					int num3 = 1;
					flag6 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag6 = false;
				}
				array[num8] = flag6;
				int num9 = 6;
				bool flag7;
				if (((XmlRpcCardsResponse)response).VeteranLevel7 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel7;
					int num3 = 1;
					flag7 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag7 = false;
				}
				array[num9] = flag7;
				int num10 = 7;
				bool flag8;
				if (((XmlRpcCardsResponse)response).VeteranLevel8 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel8;
					int num3 = 1;
					flag8 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag8 = false;
				}
				array[num10] = flag8;
				int num11 = 8;
				bool flag9;
				if (((XmlRpcCardsResponse)response).VeteranLevel9 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel9;
					int num3 = 1;
					flag9 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag9 = false;
				}
				array[num11] = flag9;
				int num12 = 9;
				bool flag10;
				if (((XmlRpcCardsResponse)response).VeteranLevel10 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel10;
					int num3 = 1;
					flag10 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag10 = false;
				}
				array[num12] = flag10;
				bool[] stages = array;
				GameEngine.Instance.World.importFreeCardData(((XmlRpcCardsResponse)response).VeteranCurrentLevel.Value, stages, DateTime.Now.AddSeconds((double)((XmlRpcCardsResponse)response).VeteranSecondsLeft.Value), DateTime.Now);
			}
			else
			{
				MyMessageBox.Show(SK.Text("FreeCardsPanel_Unable_Increase", "Unable to increase level."), SK.Text("GENERIC_Error", "Error"));
			}
			this.init(false);
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x00013AEA File Offset: 0x00011CEA
		private void revealCard()
		{
			this.revealCard(false);
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x001321AC File Offset: 0x001303AC
		private void revealCard(bool showAd)
		{
			if (FreeCardsPanel.inRevealClick)
			{
				if ((DateTime.Now - FreeCardsPanel.lastRevealClick).TotalSeconds < 30.0)
				{
					return;
				}
				FreeCardsPanel.inRevealClick = false;
			}
			FreeCardsPanel.inRevealClick = true;
			FreeCardsPanel.lastRevealClick = DateTime.Now;
			FreeCardsPanel._lastInstance = this;
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			xmlRpcCardsProvider.getFreeCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""))
			{
				SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
			}, new CardsEndResponseDelegate(FreeCardsPanel.revealCardCallback), this);
			this.revealButton.Enabled = false;
		}

		// Token: 0x0600121E RID: 4638 RVA: 0x00132294 File Offset: 0x00130494
		private void revealCardCallbackPanel(ICardsProvider provider, ICardsResponse response)
		{
			FreeCardsPanel.inRevealClick = false;
			try
			{
				string[] array = response.Strings.Split(";".ToCharArray());
				string[] array2 = array;
				foreach (string text in array2)
				{
					string[] array4 = text.Split(",".ToCharArray());
					if (array4.Length == 2)
					{
						GameEngine.Instance.cardsManager.ProfileCards.Add(Convert.ToInt32(array4[0].Trim()), CardTypes.getCardDefinitionFromString(array4[1].Trim()));
						UICard uicard = BuyCardsPanel.makeUICard(CardTypes.getCardDefinitionFromString(array4[1].Trim()), Convert.ToInt32(array4[0].Trim()), GameEngine.Instance.World.getRank() + 1);
						uicard.Position = new Point(12, 11);
						uicard.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardClicked), "FreeCardsPanel_play_card");
						this.cardBackImage.addControl(uicard);
						this.revealButton.Visible = false;
						base.Invalidate();
					}
				}
				this.revealButton.Enabled = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600121F RID: 4639 RVA: 0x001323D0 File Offset: 0x001305D0
		private static void revealCardCallback(ICardsProvider provider, ICardsResponse response)
		{
			FreeCardsPanel.inRevealClick = false;
			if (response.SuccessCode.Value == 1)
			{
				try
				{
					if (FreeCardsPanel._lastInstance != null)
					{
						try
						{
							FreeCardsPanel._lastInstance.Invoke(new CardsEndResponseDelegate(FreeCardsPanel._lastInstance.revealCardCallbackPanel), new object[]
							{
								provider,
								response
							});
						}
						catch (Exception)
						{
						}
						FreeCardsPanel._lastInstance = null;
					}
					GFXLibrary.Instance.closeBigCardsLoader();
					bool[] array = new bool[10];
					int num = 0;
					bool flag;
					if (((XmlRpcCardsResponse)response).VeteranLevel1 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel1;
						int num3 = 1;
						flag = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag = false;
					}
					array[num] = flag;
					int num4 = 1;
					bool flag2;
					if (((XmlRpcCardsResponse)response).VeteranLevel2 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel2;
						int num3 = 1;
						flag2 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag2 = false;
					}
					array[num4] = flag2;
					int num5 = 2;
					bool flag3;
					if (((XmlRpcCardsResponse)response).VeteranLevel3 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel3;
						int num3 = 1;
						flag3 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag3 = false;
					}
					array[num5] = flag3;
					int num6 = 3;
					bool flag4;
					if (((XmlRpcCardsResponse)response).VeteranLevel4 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel4;
						int num3 = 1;
						flag4 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag4 = false;
					}
					array[num6] = flag4;
					int num7 = 4;
					bool flag5;
					if (((XmlRpcCardsResponse)response).VeteranLevel5 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel5;
						int num3 = 1;
						flag5 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag5 = false;
					}
					array[num7] = flag5;
					int num8 = 5;
					bool flag6;
					if (((XmlRpcCardsResponse)response).VeteranLevel6 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel6;
						int num3 = 1;
						flag6 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag6 = false;
					}
					array[num8] = flag6;
					int num9 = 6;
					bool flag7;
					if (((XmlRpcCardsResponse)response).VeteranLevel7 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel7;
						int num3 = 1;
						flag7 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag7 = false;
					}
					array[num9] = flag7;
					int num10 = 7;
					bool flag8;
					if (((XmlRpcCardsResponse)response).VeteranLevel8 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel8;
						int num3 = 1;
						flag8 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag8 = false;
					}
					array[num10] = flag8;
					int num11 = 8;
					bool flag9;
					if (((XmlRpcCardsResponse)response).VeteranLevel9 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel9;
						int num3 = 1;
						flag9 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag9 = false;
					}
					array[num11] = flag9;
					int num12 = 9;
					bool flag10;
					if (((XmlRpcCardsResponse)response).VeteranLevel10 != null)
					{
						int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel10;
						int num3 = 1;
						flag10 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag10 = false;
					}
					array[num12] = flag10;
					bool[] stages = array;
					GameEngine.Instance.World.importFreeCardData(((XmlRpcCardsResponse)response).VeteranCurrentLevel.Value, stages, DateTime.Now.AddSeconds((double)((XmlRpcCardsResponse)response).VeteranSecondsLeft.Value), DateTime.Now);
					return;
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(ex.Message, SK.Text("GENERIC_Error", "Error"));
					return;
				}
			}
			MyMessageBox.Show(response.Message, SK.Text("FreeCardsPanel_Cannot_Free_Card", "Could not get free card."));
		}

		// Token: 0x06001220 RID: 4640 RVA: 0x00013AF3 File Offset: 0x00011CF3
		private void cardClicked()
		{
			InterfaceMgr.Instance.closeFreeCardsPopup();
			InterfaceMgr.Instance.openPlayCardsWindow(0);
		}

		// Token: 0x06001221 RID: 4641 RVA: 0x00132750 File Offset: 0x00130950
		public void UpdateVeteranLevelData()
		{
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			xmlRpcCardsProvider.getVeteranLevel(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""))
			{
				SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
			}, new CardsEndResponseDelegate(this.getVeteranLevelCallback), this);
		}

		// Token: 0x06001222 RID: 4642 RVA: 0x001327E8 File Offset: 0x001309E8
		private void getVeteranLevelCallback(ICardsProvider provider, ICardsResponse response)
		{
			if (response.SuccessCode.Value == 1)
			{
				bool[] array = new bool[10];
				int num = 0;
				bool flag;
				if (((XmlRpcCardsResponse)response).VeteranLevel1 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel1;
					int num3 = 1;
					flag = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag = false;
				}
				array[num] = flag;
				int num4 = 1;
				bool flag2;
				if (((XmlRpcCardsResponse)response).VeteranLevel2 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel2;
					int num3 = 1;
					flag2 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag2 = false;
				}
				array[num4] = flag2;
				int num5 = 2;
				bool flag3;
				if (((XmlRpcCardsResponse)response).VeteranLevel3 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel3;
					int num3 = 1;
					flag3 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag3 = false;
				}
				array[num5] = flag3;
				int num6 = 3;
				bool flag4;
				if (((XmlRpcCardsResponse)response).VeteranLevel4 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel4;
					int num3 = 1;
					flag4 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag4 = false;
				}
				array[num6] = flag4;
				int num7 = 4;
				bool flag5;
				if (((XmlRpcCardsResponse)response).VeteranLevel5 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel5;
					int num3 = 1;
					flag5 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag5 = false;
				}
				array[num7] = flag5;
				int num8 = 5;
				bool flag6;
				if (((XmlRpcCardsResponse)response).VeteranLevel6 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel6;
					int num3 = 1;
					flag6 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag6 = false;
				}
				array[num8] = flag6;
				int num9 = 6;
				bool flag7;
				if (((XmlRpcCardsResponse)response).VeteranLevel7 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel7;
					int num3 = 1;
					flag7 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag7 = false;
				}
				array[num9] = flag7;
				int num10 = 7;
				bool flag8;
				if (((XmlRpcCardsResponse)response).VeteranLevel8 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel8;
					int num3 = 1;
					flag8 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag8 = false;
				}
				array[num10] = flag8;
				int num11 = 8;
				bool flag9;
				if (((XmlRpcCardsResponse)response).VeteranLevel9 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel9;
					int num3 = 1;
					flag9 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag9 = false;
				}
				array[num11] = flag9;
				int num12 = 9;
				bool flag10;
				if (((XmlRpcCardsResponse)response).VeteranLevel10 != null)
				{
					int? num2 = ((XmlRpcCardsResponse)response).VeteranLevel10;
					int num3 = 1;
					flag10 = (num2.GetValueOrDefault() == num3 & num2 != null);
				}
				else
				{
					flag10 = false;
				}
				array[num12] = flag10;
				bool[] stages = array;
				GameEngine.Instance.World.importFreeCardData(((XmlRpcCardsResponse)response).VeteranCurrentLevel.Value, stages, DateTime.Now.AddSeconds((double)((XmlRpcCardsResponse)response).VeteranSecondsLeft.Value), DateTime.Now);
			}
			this.init(false);
		}

		// Token: 0x06001223 RID: 4643 RVA: 0x00013B0B File Offset: 0x00011D0B
		private void initialiseFreeCardsCallback(InitialiseFreeCards_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.UpdateVeteranLevelData();
			}
		}

		// Token: 0x06001224 RID: 4644 RVA: 0x00132AB0 File Offset: 0x00130CB0
		private void friendClicked()
		{
			string fileName = string.Concat(new string[]
			{
				URLs.InviteAFriendURL,
				"?webtoken=",
				RemoteServices.Instance.WebToken,
				"&lang=",
				Program.mySettings.LanguageIdent.ToLower(),
				"&colour=",
				GFXLibrary.invite_ad_colour.ToString()
			});
			try
			{
				Process.Start(fileName);
			}
			catch (Exception)
			{
				MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
			}
		}

		// Token: 0x06001225 RID: 4645 RVA: 0x00132B74 File Offset: 0x00130D74
		private void RevealCardCallbackPanelBG(ICardsResponse response)
		{
			FreeCardsPanel.inRevealClick = false;
			string[] array = response.Strings.Split(";".ToCharArray());
			ControlForm controlForm = DX.ControlForm;
			if (controlForm != null)
			{
				controlForm.Log(LNG.Print("Decode the card"), ControlForm.Tab.Main, false);
			}
			foreach (string text in array)
			{
				string[] array3 = text.Split(",".ToCharArray());
				if (array3.Length == 2)
				{
					ControlForm controlForm2 = DX.ControlForm;
					if (controlForm2 != null)
					{
						controlForm2.Log(LNG.Print("Create the card"), ControlForm.Tab.Main, false);
					}
					GameEngine.Instance.cardsManager.ProfileCards.Add(Convert.ToInt32(array3[0].Trim()), CardTypes.getCardDefinitionFromString(array3[1].Trim()));
					UICard uicard = BuyCardsPanel.makeUICard(CardTypes.getCardDefinitionFromString(array3[1].Trim()), Convert.ToInt32(array3[0].Trim()), GameEngine.Instance.World.getRank() + 1);
					ControlForm controlForm3 = DX.ControlForm;
					if (controlForm3 != null)
					{
						controlForm3.Log(LNG.Print("Free card is") + ": " + CardTypes.getDescriptionFromCard(uicard.Definition.id), ControlForm.Tab.Main, false);
					}
				}
			}
		}

		// Token: 0x06001226 RID: 4646 RVA: 0x00132CA8 File Offset: 0x00130EA8
		private static void RevealCardCallbackBG(ICardsProvider provider, ICardsResponse response)
		{
			ControlForm controlForm = DX.ControlForm;
			if (controlForm != null)
			{
				controlForm.Log(LNG.Print("Reading response"), ControlForm.Tab.Main, false);
			}
			FreeCardsPanel.inRevealClick = false;
			if (response.SuccessCode.Value == 1)
			{
				ControlForm controlForm2 = DX.ControlForm;
				if (controlForm2 != null)
				{
					controlForm2.Log(LNG.Print("Response is successfull"), ControlForm.Tab.Main, false);
				}
				try
				{
					if (FreeCardsPanel._lastInstance != null)
					{
						ControlForm controlForm3 = DX.ControlForm;
						if (controlForm3 != null)
						{
							controlForm3.Log(LNG.Print("Start revealing the card"), ControlForm.Tab.Main, false);
						}
						FreeCardsPanel._lastInstance.RevealCardCallbackPanelBG(response);
						FreeCardsPanel._lastInstance = null;
					}
					GFXLibrary.Instance.closeBigCardsLoader();
					XmlRpcCardsResponse xmlRpcCardsResponse = (XmlRpcCardsResponse)response;
					bool[] array = new bool[10];
					int num = 0;
					bool flag;
					if (xmlRpcCardsResponse.VeteranLevel1 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel1;
						int num3 = 1;
						flag = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag = false;
					}
					array[num] = flag;
					int num4 = 1;
					bool flag2;
					if (xmlRpcCardsResponse.VeteranLevel2 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel2;
						int num3 = 1;
						flag2 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag2 = false;
					}
					array[num4] = flag2;
					int num5 = 2;
					bool flag3;
					if (xmlRpcCardsResponse.VeteranLevel3 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel3;
						int num3 = 1;
						flag3 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag3 = false;
					}
					array[num5] = flag3;
					int num6 = 3;
					bool flag4;
					if (xmlRpcCardsResponse.VeteranLevel4 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel4;
						int num3 = 1;
						flag4 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag4 = false;
					}
					array[num6] = flag4;
					int num7 = 4;
					bool flag5;
					if (xmlRpcCardsResponse.VeteranLevel5 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel5;
						int num3 = 1;
						flag5 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag5 = false;
					}
					array[num7] = flag5;
					int num8 = 5;
					bool flag6;
					if (xmlRpcCardsResponse.VeteranLevel6 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel6;
						int num3 = 1;
						flag6 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag6 = false;
					}
					array[num8] = flag6;
					int num9 = 6;
					bool flag7;
					if (xmlRpcCardsResponse.VeteranLevel7 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel7;
						int num3 = 1;
						flag7 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag7 = false;
					}
					array[num9] = flag7;
					int num10 = 7;
					bool flag8;
					if (xmlRpcCardsResponse.VeteranLevel8 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel8;
						int num3 = 1;
						flag8 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag8 = false;
					}
					array[num10] = flag8;
					int num11 = 8;
					bool flag9;
					if (xmlRpcCardsResponse.VeteranLevel9 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel9;
						int num3 = 1;
						flag9 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag9 = false;
					}
					array[num11] = flag9;
					int num12 = 9;
					bool flag10;
					if (xmlRpcCardsResponse.VeteranLevel10 != null)
					{
						int? num2 = xmlRpcCardsResponse.VeteranLevel10;
						int num3 = 1;
						flag10 = (num2.GetValueOrDefault() == num3 & num2 != null);
					}
					else
					{
						flag10 = false;
					}
					array[num12] = flag10;
					bool[] stages = array;
					GameEngine.Instance.World.importFreeCardData(xmlRpcCardsResponse.VeteranCurrentLevel.Value, stages, DateTime.Now.AddSeconds((double)xmlRpcCardsResponse.VeteranSecondsLeft.Value), DateTime.Now);
					return;
				}
				catch (Exception ex)
				{
					ControlForm controlForm4 = DX.ControlForm;
					if (controlForm4 != null)
					{
						controlForm4.Log(SK.Text("GENERIC_Error", "Error"), ControlForm.Tab.Main, false);
					}
					ABaseService.ReportError(ex, ControlForm.Tab.Main);
					return;
				}
			}
			ControlForm controlForm5 = DX.ControlForm;
			if (controlForm5 == null)
			{
				return;
			}
			controlForm5.Log(SK.Text("FreeCardsPanel_Cannot_Free_Card", "Could not get free card.") + ": " + response.Message, ControlForm.Tab.Main, true);
		}

		// Token: 0x06001227 RID: 4647 RVA: 0x00132FFC File Offset: 0x001311FC
		internal void RevealCardBG()
		{
			if (FreeCardsPanel.inRevealClick)
			{
				if ((DateTime.Now - FreeCardsPanel.lastRevealClick).TotalSeconds < 30.0)
				{
					return;
				}
				FreeCardsPanel.inRevealClick = false;
			}
			FreeCardsPanel.inRevealClick = true;
			FreeCardsPanel.lastRevealClick = DateTime.Now;
			FreeCardsPanel._lastInstance = this;
			XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
			xmlRpcCardsProvider.getFreeCard(new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""))
			{
				SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "")
			}, new CardsEndResponseDelegate(FreeCardsPanel.RevealCardCallbackBG), this);
			this.revealButton.Enabled = false;
		}

		// Token: 0x04001856 RID: 6230
		private IContainer components;

		// Token: 0x04001857 RID: 6231
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001858 RID: 6232
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001859 RID: 6233
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400185A RID: 6234
		private CustomSelfDrawPanel.CSDLabel labelVeteranLevel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400185B RID: 6235
		private CustomSelfDrawPanel.CSDLabel labelFreeCards = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400185C RID: 6236
		private CustomSelfDrawPanel.CSDLabel labelNextCards = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400185D RID: 6237
		private CustomSelfDrawPanel.CSDExtendingPanel greenArea = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400185E RID: 6238
		private CustomSelfDrawPanel.CSDExtendingPanel MainPanel = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400185F RID: 6239
		private CustomSelfDrawPanel.CSDHorzProgressBar timeProgress = new CustomSelfDrawPanel.CSDHorzProgressBar();

		// Token: 0x04001860 RID: 6240
		private CustomSelfDrawPanel.CSDImage fanImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001861 RID: 6241
		private CustomSelfDrawPanel.CSDImage crestImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001862 RID: 6242
		private CustomSelfDrawPanel.CSDImage cards1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001863 RID: 6243
		private CustomSelfDrawPanel.CSDImage cards2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001864 RID: 6244
		private CustomSelfDrawPanel.CSDImage cards3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001865 RID: 6245
		private CustomSelfDrawPanel.CSDImage cards4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001866 RID: 6246
		private CustomSelfDrawPanel.CSDImage cards5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001867 RID: 6247
		private CustomSelfDrawPanel.CSDImage cards6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001868 RID: 6248
		private CustomSelfDrawPanel.CSDImage cards7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001869 RID: 6249
		private CustomSelfDrawPanel.CSDImage cards8Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400186A RID: 6250
		private CustomSelfDrawPanel.CSDImage cards9Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400186B RID: 6251
		private CustomSelfDrawPanel.CSDImage cards10Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400186C RID: 6252
		private CustomSelfDrawPanel.CSDLabel cards1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400186D RID: 6253
		private CustomSelfDrawPanel.CSDLabel cards2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400186E RID: 6254
		private CustomSelfDrawPanel.CSDLabel cards3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400186F RID: 6255
		private CustomSelfDrawPanel.CSDLabel cards4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001870 RID: 6256
		private CustomSelfDrawPanel.CSDLabel cards5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001871 RID: 6257
		private CustomSelfDrawPanel.CSDLabel cards6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001872 RID: 6258
		private CustomSelfDrawPanel.CSDLabel cards7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001873 RID: 6259
		private CustomSelfDrawPanel.CSDLabel cards8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001874 RID: 6260
		private CustomSelfDrawPanel.CSDLabel cards9Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001875 RID: 6261
		private CustomSelfDrawPanel.CSDLabel cards10Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001876 RID: 6262
		private CustomSelfDrawPanel.CSDImage tick1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001877 RID: 6263
		private CustomSelfDrawPanel.CSDImage tick2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001878 RID: 6264
		private CustomSelfDrawPanel.CSDImage tick3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001879 RID: 6265
		private CustomSelfDrawPanel.CSDImage tick4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187A RID: 6266
		private CustomSelfDrawPanel.CSDImage tick5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187B RID: 6267
		private CustomSelfDrawPanel.CSDImage tick6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187C RID: 6268
		private CustomSelfDrawPanel.CSDImage tick7Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187D RID: 6269
		private CustomSelfDrawPanel.CSDImage tick8Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187E RID: 6270
		private CustomSelfDrawPanel.CSDImage tick9Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400187F RID: 6271
		private CustomSelfDrawPanel.CSDImage tick10Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001880 RID: 6272
		private CustomSelfDrawPanel.CSDLabel description1Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001881 RID: 6273
		private CustomSelfDrawPanel.CSDLabel description2Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001882 RID: 6274
		private CustomSelfDrawPanel.CSDLabel description3Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001883 RID: 6275
		private CustomSelfDrawPanel.CSDLabel description4Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001884 RID: 6276
		private CustomSelfDrawPanel.CSDLabel description5Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001885 RID: 6277
		private CustomSelfDrawPanel.CSDLabel description6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001886 RID: 6278
		private CustomSelfDrawPanel.CSDLabel description7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001887 RID: 6279
		private CustomSelfDrawPanel.CSDLabel description8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001888 RID: 6280
		private CustomSelfDrawPanel.CSDLabel description9Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001889 RID: 6281
		private CustomSelfDrawPanel.CSDLabel description10Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188A RID: 6282
		private CustomSelfDrawPanel.CSDLabel comingSoon6Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188B RID: 6283
		private CustomSelfDrawPanel.CSDLabel comingSoon7Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188C RID: 6284
		private CustomSelfDrawPanel.CSDLabel comingSoon8Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188D RID: 6285
		private CustomSelfDrawPanel.CSDLabel comingSoon9Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188E RID: 6286
		private CustomSelfDrawPanel.CSDLabel comingSoon10Label = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400188F RID: 6287
		private CustomSelfDrawPanel.CSDButton level1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001890 RID: 6288
		private CustomSelfDrawPanel.CSDButton level2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001891 RID: 6289
		private CustomSelfDrawPanel.CSDButton level3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001892 RID: 6290
		private CustomSelfDrawPanel.CSDButton level4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001893 RID: 6291
		private CustomSelfDrawPanel.CSDButton level5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001894 RID: 6292
		private CustomSelfDrawPanel.CSDButton level6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001895 RID: 6293
		private CustomSelfDrawPanel.CSDButton level7Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001896 RID: 6294
		private CustomSelfDrawPanel.CSDButton level8Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001897 RID: 6295
		private CustomSelfDrawPanel.CSDButton level9Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001898 RID: 6296
		private CustomSelfDrawPanel.CSDButton level10Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001899 RID: 6297
		private CustomSelfDrawPanel.CSDButton buyCrownsButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400189A RID: 6298
		private CustomSelfDrawPanel.CSDImage parchmentImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400189B RID: 6299
		private CustomSelfDrawPanel.CSDImage cardBackImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400189C RID: 6300
		private CustomSelfDrawPanel.CSDButton revealButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400189D RID: 6301
		private CustomSelfDrawPanel.CSDLabel comingsoon = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400189E RID: 6302
		private FreeCardsData freeCardInfo;

		// Token: 0x0400189F RID: 6303
		private static DateTime lastVeteranLevelTime = DateTime.MinValue;

		// Token: 0x040018A0 RID: 6304
		private bool inIncreaseLevel;

		// Token: 0x040018A1 RID: 6305
		private DateTime lastIncreaseLevelClick = DateTime.MinValue;

		// Token: 0x040018A2 RID: 6306
		private static DateTime lastRevealClick = DateTime.MinValue;

		// Token: 0x040018A3 RID: 6307
		private static bool inRevealClick = false;

		// Token: 0x040018A4 RID: 6308
		private static FreeCardsPanel _lastInstance = null;
	}
}
