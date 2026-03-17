using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200027A RID: 634
	public class PremiumCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x06001C77 RID: 7287 RVA: 0x001BD184 File Offset: 0x001BB384
		public PremiumCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x001BD2D0 File Offset: 0x001BB4D0
		public void init(int cardSection)
		{
			this.inSend = false;
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * PremiumCardsPanel.BorderPadding;
			this.AvailablePanelWidth = 800;
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = base.Size;
			csdextendingPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(csdextendingPanel);
			csdextendingPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			csdextendingPanel.addControl(new CustomSelfDrawPanel.CSDImage
			{
				Image = GFXLibrary.cardpanel_panel_gradient_top_left,
				Size = GFXLibrary.cardpanel_panel_gradient_top_left.Size,
				Position = new Point(0, 0)
			});
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.cardpanel_panel_gradient_bottom_right;
			csdimage.Size = GFXLibrary.cardpanel_panel_gradient_bottom_right.Size;
			csdimage.Position = new Point(csdextendingPanel.Width - csdimage.Width - 6, csdextendingPanel.Height - csdimage.Height - 6);
			csdextendingPanel.addControl(csdimage);
			this.AvailablePanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, 385);
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - 385);
			this.AvailablePanel.Alpha = 0.8f;
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			int width = base.Width;
			int borderPadding = PremiumCardsPanel.BorderPadding;
			int width2 = this.AvailablePanel.Width;
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
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 37, new Point(base.Width - 1 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.greyout.FillColor = Color.FromArgb(215, 25, 25, 25);
			this.greyout.Size = new Size(this.mainBackgroundImage.Width, this.mainBackgroundImage.Height);
			this.greyout.Position = new Point(0, 0);
			this.cardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			this.cardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(this.cardsButtons);
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(935, 64);
			this.labelTitle.Text = SK.Text("PremiumCardsPanel_Buy_and_Open_Packs", "Buy and Play Premium Tokens: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4112)
			{
				this.maxExpirySeconds = 604800.0;
			}
			else if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4114)
			{
				this.maxExpirySeconds = 2592000.0;
			}
			else if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4113)
			{
				this.maxExpirySeconds = 172800.0;
			}
			else if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4116)
			{
				this.maxExpirySeconds = 0.0;
			}
			this.currentExpirySeconds = GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime()).TotalSeconds;
			this.expiryDays = this.currentExpirySeconds / 86400.0;
			this.expiryHours = this.currentExpirySeconds % 86400.0 / 3600.0;
			this.expiryMinutes = this.currentExpirySeconds % 3600.0 / 60.0;
			if (this.maxExpirySeconds > 0.0)
			{
				double num = this.currentExpirySeconds / this.maxExpirySeconds;
				this.expiryBarCurrent = Convert.ToInt32(Math.Floor(num * (double)PremiumCardsPanel.expiryBarMax));
			}
			else
			{
				this.expiryBarCurrent = -1;
			}
			if (GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
			{
				this.premiumTokenImage = GFXLibrary.PremiumTokens[GameEngine.Instance.cardsManager.UserCardData.premiumCard][0];
			}
			else
			{
				this.premiumTokenImage = GFXLibrary.PremiumTokens[4112][0];
			}
			this.PremiumInplayImage.Visible = false;
			this.PremiumInplayImage.Image = this.premiumTokenImage;
			this.PremiumInplayImage.Size = this.premiumTokenImage.Size;
			this.PremiumInplayImage.Position = new Point(this.AvailablePanel.X + this.AvailablePanel.Width - 32 - this.PremiumInplayImage.Width, this.cardsButtons.Y + 8);
			this.PremiumInplayImage.setMouseOverDelegate(delegate
			{
				if (GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
				{
					this.PremiumInplayImage.Image = GFXLibrary.PremiumTokens[GameEngine.Instance.cardsManager.UserCardData.premiumCard][1];
				}
			}, delegate
			{
				if (GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
				{
					this.PremiumInplayImage.Image = GFXLibrary.PremiumTokens[GameEngine.Instance.cardsManager.UserCardData.premiumCard][0];
				}
			});
			this.mainBackgroundImage.addControl(this.PremiumInplayImage);
			if (this.expiryBarCurrent >= 0)
			{
				this.TimerOuter = new CustomSelfDrawPanel.CSDFill();
				this.TimerInner = new CustomSelfDrawPanel.CSDFill();
			}
			else
			{
				this.TimerInner = null;
				this.TimerOuter = null;
			}
			this.PremiumTokensLabel = new CustomSelfDrawPanel.CSDLabel();
			this.PremiumTokensLabel.Position = new Point(this.AvailablePanel.X + 32, this.AvailablePanel.Y - 24);
			this.PremiumTokensLabel.Size = new Size(450, 32);
			this.PremiumTokensLabel.Text = SK.Text("PremiumCardsPanel_Current_Tokens", "Current Premium Tokens") + " : " + GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Count.ToString() + ((GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Count > 0) ? (" (" + SK.Text("PremiumCardsPanel_Click_To_Play", "click one to play") + ")") : "");
			this.PremiumTokensLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.PremiumTokensLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.PremiumTokensLabel.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.PremiumTokensLabel);
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			BaseImage cardpanel_premium_ad = GFXLibrary.cardpanel_premium_ad;
			csdimage2.Image = cardpanel_premium_ad;
			csdimage2.Size = cardpanel_premium_ad.Size;
			csdimage2.Position = new Point(0, 0);
			CustomSelfDrawPanel.CSDImage PremiumAdvert31 = new CustomSelfDrawPanel.CSDImage();
			CustomSelfDrawPanel.CSDImage PremiumAdvert30 = new CustomSelfDrawPanel.CSDImage();
			BaseImage AdImage31 = GFXLibrary.premiumAdvert7;
			BaseImage AdImage7_over = GFXLibrary.premiumAdvert7_over;
			BaseImage AdImage30 = GFXLibrary.premiumAdvert30;
			BaseImage AdImage30_over = GFXLibrary.premiumAdvert30_over;
			PremiumAdvert31.Image = AdImage31;
			PremiumAdvert31.Size = AdImage31.Size;
			PremiumAdvert31.Position = new Point(0, 0);
			this.AvailablePanelContent.addControl(PremiumAdvert31);
			PremiumAdvert30.Image = AdImage30;
			PremiumAdvert30.Size = AdImage30.Size;
			PremiumAdvert30.Position = new Point(363, 0);
			this.AvailablePanelContent.addControl(PremiumAdvert30);
			PremiumAdvert31.Data = 4112;
			PremiumAdvert30.Data = 4114;
			PremiumAdvert31.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickedOffer), "PremiumCardsPanel_buy_premium");
			PremiumAdvert30.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickedOffer), "PremiumCardsPanel_buy_premium");
			PremiumAdvert31.setMouseOverDelegate(delegate
			{
				PremiumAdvert31.Image = AdImage7_over;
			}, delegate
			{
				PremiumAdvert31.Image = AdImage31;
			});
			PremiumAdvert30.setMouseOverDelegate(delegate
			{
				PremiumAdvert30.Image = AdImage30_over;
			}, delegate
			{
				PremiumAdvert30.Image = AdImage30;
			});
			csdimage2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickedOffer), "PremiumCardsPanel_buy_premium");
			csdimage2.Data = 4112;
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(0, csdimage2.Height + 8);
			csdlabel.Size = new Size(600, 32);
			csdlabel.Text = SK.Text("PremiumCardsPanel_Benefits", "Premium Benefits");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			csdlabel.Color = global::ARGBColors.Gold;
			this.AvailablePanelContent.addControl(csdlabel);
			CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel2.Position = new Point(0, csdimage2.Height + 8 + csdlabel.Height + 4);
			csdlabel2.Size = new Size(600, 30);
			csdlabel2.Text = SK.Text("PremiumCardsPanel_Building_Queue", "Building Queue");
			csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel2.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel2.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel2);
			CustomSelfDrawPanel.CSDLabel csdlabel3 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel3.Position = new Point(110, csdlabel2.Y + csdlabel2.Height + 4 - 11);
			csdlabel3.Size = new Size(590, 50);
			csdlabel3.Text = SK.Text("PremiumCardsPanel_Buildings_Queue_Info", "This allows up to 5 buildings to be queued for construction in the village. You can also move all buildings within your village screen.");
			csdlabel3.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel3.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel3.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel3);
			CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
			csdimage3.Image = GFXLibrary.premiumIcons[0];
			csdimage3.Position = new Point(4, csdlabel2.Y + csdlabel2.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage3);
			CustomSelfDrawPanel.CSDLabel csdlabel4 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel4.Position = new Point(0, csdlabel3.Y + csdlabel3.Height + 4);
			csdlabel4.Size = new Size(600, 30);
			csdlabel4.Text = SK.Text("PremiumCardsPanel_Research_Queue", "Research Queue");
			csdlabel4.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel4.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel4.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel4);
			CustomSelfDrawPanel.CSDLabel csdlabel5 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel5.Position = new Point(110, csdlabel4.Y + csdlabel4.Height + 4 - 11);
			csdlabel5.Size = new Size(590, 50);
			csdlabel5.Text = SK.Text("PremiumCardsPanel_Research_Queue_Info", "This allows up to 5 researches to be queued in the research screen.");
			csdlabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel5.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel5);
			CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
			csdimage4.Image = GFXLibrary.premiumIcons[1];
			csdimage4.Position = new Point(4, csdlabel4.Y + csdlabel4.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage4);
			CustomSelfDrawPanel.CSDLabel csdlabel6 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel6.Position = new Point(0, csdlabel5.Y + csdlabel5.Height + 4);
			csdlabel6.Size = new Size(600, 30);
			csdlabel6.Text = SK.Text("PremiumCardsPanel_Auto_Trading", "Auto Trading");
			csdlabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel6.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel6.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel6);
			CustomSelfDrawPanel.CSDLabel csdlabel7 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel7.Position = new Point(110, csdlabel6.Y + csdlabel6.Height + 4 - 11);
			csdlabel7.Size = new Size(590, 50);
			csdlabel7.Text = SK.Text("PremiumCardsPanel_Auto_Trading_Info", "This allows the trade one type of good to the parish capitals market automatically while you are logged out.") + " (" + SK.Text("PremiumCardsPanel_Auto_Extra", "Activates once every 2 to 4 hours.") + ")";
			csdlabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel7.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel7.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel7);
			CustomSelfDrawPanel.CSDImage csdimage5 = new CustomSelfDrawPanel.CSDImage();
			csdimage5.Image = GFXLibrary.premiumIcons[2];
			csdimage5.Position = new Point(4, csdlabel6.Y + csdlabel6.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage5);
			CustomSelfDrawPanel.CSDLabel csdlabel8 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel8.Position = new Point(0, csdlabel7.Y + csdlabel7.Height + 4);
			csdlabel8.Size = new Size(600, 30);
			csdlabel8.Text = SK.Text("PremiumCardsPanel_Auto_Scouting", "Auto Scouting");
			csdlabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel8.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel8.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel8);
			CustomSelfDrawPanel.CSDLabel csdlabel9 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel9.Position = new Point(110, csdlabel8.Y + csdlabel8.Height + 4 - 11);
			csdlabel9.Size = new Size(590, 50);
			csdlabel9.Text = SK.Text("PremiumCardsPanel_Auto_Scouting_Info", "This will send out all available scouts to stashes within the parish the village is located, automatically while you are logged out.") + " (" + SK.Text("PremiumCardsPanel_Auto_Extra", "Activates once every 2 to 4 hours.") + ")";
			csdlabel9.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel9.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel9.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel9);
			CustomSelfDrawPanel.CSDImage csdimage6 = new CustomSelfDrawPanel.CSDImage();
			csdimage6.Image = GFXLibrary.premiumIcons[3];
			csdimage6.Position = new Point(4, csdlabel8.Y + csdlabel8.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage6);
			CustomSelfDrawPanel.CSDLabel csdlabel10 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel10.Position = new Point(0, csdlabel9.Y + csdlabel9.Height + 4);
			csdlabel10.Size = new Size(600, 30);
			csdlabel10.Text = SK.Text("PremiumCardsPanel_Auto_Attacking", "Auto Attacking");
			csdlabel10.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel10.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel10.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel10);
			CustomSelfDrawPanel.CSDLabel csdlabel11 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel11.Position = new Point(110, csdlabel10.Y + csdlabel10.Height + 4 - 11);
			csdlabel11.Size = new Size(590, 50);
			csdlabel11.Text = SK.Text("PremiumCardsPanel_Auto_Attacking_Info", "This will send out attacks to chosen targets automatically while you are logged out.") + " (" + SK.Text("PremiumCardsPanel_Auto_Extra", "Activates once every 2 to 4 hours.") + ")";
			csdlabel11.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel11.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel11.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel11);
			CustomSelfDrawPanel.CSDImage csdimage7 = new CustomSelfDrawPanel.CSDImage();
			csdimage7.Image = GFXLibrary.premiumIcons[4];
			csdimage7.Position = new Point(4, csdlabel10.Y + csdlabel10.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage7);
			CustomSelfDrawPanel.CSDLabel csdlabel12 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel12.Position = new Point(0, csdlabel11.Y + csdlabel11.Height + 4);
			csdlabel12.Size = new Size(600, 30);
			csdlabel12.Text = SK.Text("PremiumCardsPanel_Auto_Recruit", "Auto Recruit");
			csdlabel12.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel12.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel12.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel12);
			CustomSelfDrawPanel.CSDLabel csdlabel13 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel13.Position = new Point(110, csdlabel12.Y + csdlabel12.Height + 4 - 11);
			csdlabel13.Size = new Size(590, 50);
			csdlabel13.Text = SK.Text("PremiumCardsPanel_Auto_Recruit_Info", "This will automatically conscript idle peasants to your army.") + " (" + SK.Text("PremiumCardsPanel_Auto_Extra", "Activates once every 2 to 4 hours.") + ")";
			csdlabel13.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel13.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel13.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel13);
			CustomSelfDrawPanel.CSDImage csdimage8 = new CustomSelfDrawPanel.CSDImage();
			csdimage8.Image = GFXLibrary.premiumIcons[5];
			csdimage8.Position = new Point(4, csdlabel12.Y + csdlabel12.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage8);
			CustomSelfDrawPanel.CSDLabel csdlabel14 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel14.Position = new Point(0, csdlabel13.Y + csdlabel13.Height + 4);
			csdlabel14.Size = new Size(600, 30);
			csdlabel14.Text = SK.Text("PremiumCardsPanel_Village_Overview", "Village Overview");
			csdlabel14.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel14.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel14.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel14);
			CustomSelfDrawPanel.CSDLabel csdlabel15 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel15.Position = new Point(110, csdlabel14.Y + csdlabel14.Height + 4 - 11);
			csdlabel15.Size = new Size(590, 50);
			csdlabel15.Text = SK.Text("PremiumCardsPanel_Village_Overview_Info", "This allows players to keep track of essential information on all their villages, such as income from taxes, housing capacity, popularity and more.");
			csdlabel15.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel15.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel15.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel15);
			CustomSelfDrawPanel.CSDImage csdimage9 = new CustomSelfDrawPanel.CSDImage();
			csdimage9.Image = GFXLibrary.premiumIcons[6];
			csdimage9.Position = new Point(4, csdlabel14.Y + csdlabel14.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage9);
			CustomSelfDrawPanel.CSDLabel csdlabel16 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel16.Position = new Point(0, csdlabel15.Y + csdlabel15.Height + 4);
			csdlabel16.Size = new Size(600, 30);
			csdlabel16.Text = SK.Text("PremiumCardsPanel_Vacation_Mode", "Vacation Mode");
			csdlabel16.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel16.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel16.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel16);
			CustomSelfDrawPanel.CSDLabel csdlabel17 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel17.Position = new Point(110, csdlabel16.Y + csdlabel16.Height + 4 - 11);
			csdlabel17.Size = new Size(590, 50);
			csdlabel17.Text = SK.Text("PremiumCardsPanel_Vacation_Mode_Info", "This allows players to protect their villages from attack for up to 15 days.");
			csdlabel17.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel17.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel17.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel17);
			CustomSelfDrawPanel.CSDImage csdimage10 = new CustomSelfDrawPanel.CSDImage();
			csdimage10.Image = GFXLibrary.premiumIcons[7];
			csdimage10.Position = new Point(4, csdlabel16.Y + csdlabel16.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage10);
			CustomSelfDrawPanel.CSDLabel csdlabel18 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel18.Position = new Point(0, csdlabel17.Y + csdlabel17.Height + 4);
			csdlabel18.Size = new Size(600, 30);
			csdlabel18.Text = SK.Text("PremiumCardsPanel_AdvancedTrading", "Advanced Trading Option");
			csdlabel18.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel18.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			csdlabel18.Color = global::ARGBColors.Goldenrod;
			this.AvailablePanelContent.addControl(csdlabel18);
			CustomSelfDrawPanel.CSDLabel csdlabel19 = new CustomSelfDrawPanel.CSDLabel();
			csdlabel19.Position = new Point(110, csdlabel18.Y + csdlabel18.Height + 4 - 11);
			csdlabel19.Size = new Size(590, 50);
			csdlabel19.Text = SK.Text("PremiumCardsPanel_AdvancedTrading_Info", "This allows players to find the best prices for goods in nearby Markets.");
			csdlabel19.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			csdlabel19.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			csdlabel19.Color = global::ARGBColors.White;
			this.AvailablePanelContent.addControl(csdlabel19);
			CustomSelfDrawPanel.CSDImage csdimage11 = new CustomSelfDrawPanel.CSDImage();
			csdimage11.Image = GFXLibrary.premiumIcons[8];
			csdimage11.Position = new Point(4, csdlabel18.Y + csdlabel18.Height + 4 - 10);
			this.AvailablePanelContent.addControl(csdimage11);
			int num2 = csdlabel19.Y + csdlabel19.Height + 6;
			this.AvailablePanelContent.Position = new Point(PremiumCardsPanel.BorderPadding, PremiumCardsPanel.BorderPadding);
			this.AvailablePanelContent.Size = new Size(this.AvailablePanel.Width, num2);
			this.AvailablePanelContent.ClipRect = new Rectangle(0, 0, this.AvailablePanel.Width - PremiumCardsPanel.BorderPadding, this.AvailablePanel.Height - PremiumCardsPanel.BorderPadding * 2);
			this.AvailablePanel.addControl(this.AvailablePanelContent);
			if (num2 < this.AvailablePanelContent.ClipRect.Height)
			{
				num2 = this.AvailablePanelContent.ClipRect.Height;
			}
			this.scrollbarAvailable.Position = new Point(this.AvailablePanel.Width - PremiumCardsPanel.BorderPadding - PremiumCardsPanel.BorderPadding / 2, this.AvailablePanel.Y + PremiumCardsPanel.BorderPadding / 2);
			this.scrollbarAvailable.Size = new Size(PremiumCardsPanel.BorderPadding, this.AvailablePanel.Height - PremiumCardsPanel.BorderPadding);
			this.mainBackgroundImage.addControl(this.scrollbarAvailable);
			this.scrollbarAvailable.Value = 0;
			this.scrollbarAvailable.StepSize = 200;
			this.scrollbarAvailable.Max = this.AvailablePanelContent.Height - this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.NumVisibleLines = this.AvailablePanelContent.ClipRect.Height;
			this.scrollbarAvailable.OffsetTL = new Point(1, 5);
			this.scrollbarAvailable.OffsetBR = new Point(0, -10);
			this.scrollbarAvailable.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.AvailableContentScroll));
			this.scrollbarAvailable.Create(null, null, null, GFXLibrary.cardpanel_scroll_thumb_top, GFXLibrary.cardpanel_scroll_thumb_mid, GFXLibrary.cardpanel_scroll_thumb_botom);
			if (num2 <= this.AvailablePanelContent.ClipRect.Height)
			{
				this.scrollbarAvailable.Visible = false;
			}
			this.expiryLabel = new CustomSelfDrawPanel.CSDLabel();
			if (this.TimerInner != null)
			{
				this.ExpiryBar = new CustomSelfDrawPanel.CSDHorzProgressBar();
				this.ExpiryBar.Size = new Size(170, 0);
				this.ExpiryBar.Position = new Point(this.PremiumInplayImage.X - 13, this.PremiumInplayImage.Y + this.PremiumInplayImage.Height);
				this.ExpiryBar.Create(GFXLibrary.cardpanel_prem_timer_back_left, GFXLibrary.cardpanel_prem_timer_back_mid, GFXLibrary.cardpanel_prem_timer_back_right, GFXLibrary.cardpanel_prem_timer_fill_left, GFXLibrary.cardpanel_prem_timer_fill_mid, GFXLibrary.cardpanel_prem_timer_fill_right);
				this.ExpiryBar.setValues(this.currentExpirySeconds, this.maxExpirySeconds);
				this.mainBackgroundImage.addControl(this.ExpiryBar);
				this.expiryLabel.Position = new Point(this.ExpiryBar.X, this.ExpiryBar.Y + this.ExpiryBar.Height);
				this.expiryLabel.Size = new Size(this.ExpiryBar.Width, 16);
			}
			else
			{
				this.expiryLabel.Position = new Point(this.PremiumInplayImage.X - 13, this.PremiumInplayImage.Y + this.PremiumInplayImage.Height);
				this.expiryLabel.Size = new Size(170, 16);
			}
			this.expiryLabel.Visible = false;
			this.expiryLabel.Text = string.Concat(new string[]
			{
				Math.Floor(this.expiryDays).ToString().PadLeft(2, '0'),
				":",
				Math.Floor(this.expiryHours).ToString().PadLeft(2, '0'),
				":",
				Math.Floor(this.expiryMinutes).ToString().PadLeft(2, '0'),
				" (",
				SK.Text("PremiumCardsPanel_Day_Hour_Minute", "dd:hh:mm"),
				")"
			});
			this.expiryLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.expiryLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.expiryLabel.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.expiryLabel);
			this.UpdatePremiumTokens();
			this.UpdateExpiry();
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x001BEF1C File Offset: 0x001BD11C
		private void ClickedToken()
		{
			if (GameEngine.Instance.World.WorldEnded || this.inSend)
			{
				return;
			}
			int data = this.ClickedControl.Data;
			int type = GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens[data].Type;
			DateTime dateTime = VillageMap.getCurrentServerTime();
			if (GameEngine.Instance.premiumTokenManager.PremiumInPlay)
			{
				this.currentExpirySeconds = GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry.Subtract(VillageMap.getCurrentServerTime()).TotalSeconds;
				dateTime = dateTime.AddSeconds(this.currentExpirySeconds);
				if (GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens[data].Type == 4113 && GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4113)
				{
					MyMessageBox.Show(SK.Text("PremiumCardsPanel_Already_In_Play_2_2", "You cannot extend a 2 day Premium Token using another 2 day Premium Token."), SK.Text("GENERIC_Error", "Error"));
					return;
				}
				if (MyMessageBox.Show(SK.Text("PremiumCardsPanel_ExtendToken", "You currently have a Premium Token in play, do you wish to extend this by playing another Token?"), SK.Text("PremiumCardsPanel_ExtendWarning", "Extend Premium Token"), MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			else
			{
				string text = "";
				switch (GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens[data].Type)
				{
				case 4112:
					text = SK.Text("PremiumCardsPanel_7day", "7 Day Premium Token");
					break;
				case 4113:
					text = SK.Text("TOOLTIPS_QUEST_REWARD_PREMIUM_CARD", "2 Day Premium Token");
					break;
				case 4114:
					text = SK.Text("PremiumCardsPanel_30day", "30 Day Premium Token");
					break;
				}
				if (MyMessageBox.Show(string.Concat(new string[]
				{
					text,
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("PremiumCardsPanel_PlayToken", "You are about to play this Premium Token. This Premium Token will only affect the current game world."),
					Environment.NewLine,
					Environment.NewLine,
					SK.Text("PremiumCardsPanel_PlayToken2", "Are you sure you wish to play this Token?")
				}), SK.Text("PremiumCardsPanel_PlayToken_Header", "Play Premium Token"), MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
			}
			this.inSend = true;
			CardTypes.PremiumToken userToken = GameEngine.Instance.premiumTokenManager.getUserToken(data);
			GameEngine.Instance.premiumTokenManager.PlayToken(userToken, new CardsEndResponseDelegate(this.PlayedToken), this);
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.getCardWindow());
			}
			this.UpdatePremiumTokens();
			this.UpdateExpiry();
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x001BF18C File Offset: 0x001BD38C
		private void ExtendOrPlayPremiumToken()
		{
			try
			{
				this.inSend = true;
				int data = this.ClickedControl.Data;
				CardTypes.PremiumToken userToken = GameEngine.Instance.premiumTokenManager.getUserToken(data);
				GameEngine.Instance.premiumTokenManager.PlayToken(userToken, new CardsEndResponseDelegate(this.PlayedToken), this);
				if (InterfaceMgr.Instance.getCardWindow() != null)
				{
					CursorManager.SetCursor(CursorManager.CursorType.WaitCursor, InterfaceMgr.Instance.getCardWindow());
				}
				this.UpdatePremiumTokens();
				this.UpdateExpiry();
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log(ex.ToString());
			}
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x0001BECE File Offset: 0x0001A0CE
		private void PlayPremiumToken()
		{
			this.ExtendOrPlayPremiumToken();
			this.playPremiumPopup.Close();
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x0001BEE1 File Offset: 0x0001A0E1
		private void ClosePlayPremiumPopUp()
		{
			if (this.playPremiumPopup != null)
			{
				if (this.playPremiumPopup.Created)
				{
					this.playPremiumPopup.Close();
				}
				this.playPremiumPopup = null;
			}
		}

		// Token: 0x06001C7D RID: 7293 RVA: 0x0001BF0A File Offset: 0x0001A10A
		private void ExtendPremiumToken()
		{
			this.ExtendOrPlayPremiumToken();
			this.extendPremiumPopUp.Close();
		}

		// Token: 0x06001C7E RID: 7294 RVA: 0x0001BF1D File Offset: 0x0001A11D
		private void CloseExtendPremiumPopUp()
		{
			if (this.extendPremiumPopUp != null)
			{
				if (this.extendPremiumPopUp.Created)
				{
					this.extendPremiumPopUp.Close();
				}
				this.extendPremiumPopUp = null;
			}
		}

		// Token: 0x06001C7F RID: 7295 RVA: 0x001BF224 File Offset: 0x001BD424
		private void BoughtTokenPopUp()
		{
			try
			{
				GameEngine.Instance.premiumTokenManager.buyToken(this.ClickedControl.Data, new CardsEndResponseDelegate(this.BoughtOffer), this);
				this.labelTitle.Text = SK.Text("PremiumCardsPanel_Buy_and_Open_Packs", "Buy and Play Premium Tokens: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log(ex.ToString());
			}
			this.CloseBuyTokenPopUp();
		}

		// Token: 0x06001C80 RID: 7296 RVA: 0x0001BF46 File Offset: 0x0001A146
		private void CloseBuyTokenPopUp()
		{
			if (this.buyTokenPopUp != null)
			{
				if (this.buyTokenPopUp.Created)
				{
					this.buyTokenPopUp.Close();
				}
				this.buyTokenPopUp = null;
			}
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x001BF2B8 File Offset: 0x001BD4B8
		private void PlayedToken(ICardsProvider provider, ICardsResponse response)
		{
			this.inSend = false;
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				MyMessageBox.Show(CardsManager.translateCardError(response.Message, 0), SK.Text("GENERIC_Error", "Error"));
			}
			this.UpdatePremiumTokens();
			this.UpdateExpiry();
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.getCardWindow());
			}
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x001BF334 File Offset: 0x001BD534
		private void ClickedOffer()
		{
			if (GameEngine.Instance.World.WorldEnded)
			{
				return;
			}
			int num = 30;
			if (this.ClickedControl.Data == 4112)
			{
				num = 30;
			}
			else if (this.ClickedControl.Data == 4114)
			{
				num = 100;
			}
			if (GameEngine.Instance.World.ProfileCrowns < num)
			{
				BuyCrownsPopup buyCrownsPopup = new BuyCrownsPopup();
				buyCrownsPopup.init(num - GameEngine.Instance.World.ProfileCrowns, base.ParentForm);
				buyCrownsPopup.Show(base.ParentForm);
				return;
			}
			if (!this.buying)
			{
				this.buying = true;
				string txtMessage = "";
				if (this.ClickedControl.Data == 4112)
				{
					txtMessage = SK.Text("PremiumCardsPanel_7Day_Premium", "Buy one 7-Day Premium Token for 30 Crowns?  To activate the Premium Token you must click on it to set it into play on the game world.") + Environment.NewLine;
				}
				else if (this.ClickedControl.Data == 4114)
				{
					txtMessage = SK.Text("PremiumCardsPanel_30Day_Premium", "Buy one 30-Day Premium Token for 100 Crowns?  To activate the Premium Token you must click on it to set it into play on the game world.") + Environment.NewLine;
				}
				if (MyMessageBox.Show(txtMessage, SK.Text("BuyCardsPanel_Confirm_Purchase", "Confirm Purchase"), MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					this.BoughtTokenPopUp();
					this.labelTitle.Text = SK.Text("PremiumCardsPanel_Buy_and_Open_Packs", "Buy and Play Premium Tokens: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
					return;
				}
				this.buying = false;
			}
		}

		// Token: 0x06001C83 RID: 7299 RVA: 0x001BF498 File Offset: 0x001BD698
		private void BoughtOffer(ICardsProvider provider, ICardsResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (!(successCode.GetValueOrDefault() == num & successCode != null))
			{
				MyMessageBox.Show(response.Message, SK.Text("BuyCardsPanel_Error_Report", "ERROR: Please report this error message"));
				this.labelTitle.Text = SK.Text("PremiumCardsPanel_Buy_and_Open_Packs", "Buy and Play Premium Tokens: Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString();
			}
			else
			{
				this.UpdatePremiumTokens();
			}
			this.buying = false;
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x001BF524 File Offset: 0x001BD724
		private void AvailableContentScroll()
		{
			int value = this.scrollbarAvailable.Value;
			this.AvailablePanelContent.Position = new Point(this.AvailablePanelContent.Position.X, PremiumCardsPanel.BorderPadding - value);
			this.AvailablePanelContent.ClipRect = new Rectangle(this.AvailablePanelContent.ClipRect.X, value, this.AvailablePanelContent.ClipRect.Width, this.AvailablePanelContent.ClipRect.Height);
			this.AvailablePanelContent.invalidate();
			this.AvailablePanel.invalidate();
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x001BF5C8 File Offset: 0x001BD7C8
		public void UpdatePremiumTokens()
		{
			foreach (CustomSelfDrawPanel.CSDImage control in this.PremiumTokens)
			{
				this.mainBackgroundImage.removeControl(control);
			}
			this.PremiumTokens.Clear();
			int num = 45;
			int num2 = 0;
			foreach (CardTypes.PremiumToken premiumToken in GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Values)
			{
				if ((premiumToken.Type & 4112) == 4112 && GFXLibrary.PremiumTokens.ContainsKey(premiumToken.Type))
				{
					num2++;
				}
			}
			if (num2 > 24)
			{
				num = 15;
			}
			else if (num2 > 16)
			{
				num = 20;
			}
			else if (num2 > 11)
			{
				num = 30;
			}
			int num3 = 0;
			foreach (CardTypes.PremiumToken premiumToken2 in GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Values)
			{
				if ((premiumToken2.Type & 4112) == 4112 && GFXLibrary.PremiumTokens.ContainsKey(premiumToken2.Type))
				{
					CustomSelfDrawPanel.CSDImage im = new CustomSelfDrawPanel.CSDImage();
					im.Data = premiumToken2.UserPremiumTokenID;
					im.Position = new Point(this.AvailablePanel.X + 32 + num3 * num, this.cardsButtons.Y + 8);
					im.Size = this.premiumTokenImage.Size;
					BaseImage normalImage = GFXLibrary.PremiumTokens[premiumToken2.Type][0];
					BaseImage overImage = GFXLibrary.PremiumTokens[premiumToken2.Type][1];
					im.Image = normalImage;
					im.setMouseOverDelegate(delegate
					{
						im.Image = overImage;
					}, delegate
					{
						im.Image = normalImage;
					});
					this.PremiumTokens.Add(im);
					this.mainBackgroundImage.addControl(im);
					im.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClickedToken), "PremiumCardsPanel_play_token");
					num3++;
					if (num3 == 32)
					{
						break;
					}
				}
			}
			this.mainBackgroundImage.invalidate();
			this.PremiumTokensLabel.Text = SK.Text("PremiumCardsPanel_Current_Tokens", "Current Premium Tokens") + " : " + GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Count.ToString() + ((GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Count > 0) ? (" (" + SK.Text("PremiumCardsPanel_Click_To_Play", "click one to play") + ")") : "");
		}

		// Token: 0x06001C86 RID: 7302 RVA: 0x001BF91C File Offset: 0x001BDB1C
		public void UpdateExpiry()
		{
			if (GameEngine.Instance.premiumTokenManager.PremiumInPlay && GameEngine.Instance.premiumTokenManager.ExpiryTimeSpan.TotalSeconds > 0.0 && GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
			{
				if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4112)
				{
					this.maxExpirySeconds = 604800.0;
				}
				else if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4114)
				{
					this.maxExpirySeconds = 2592000.0;
				}
				else if (GameEngine.Instance.cardsManager.UserCardData.premiumCard == 4113)
				{
					this.maxExpirySeconds = 172800.0;
				}
				if (GameEngine.Instance.cardsManager.UserCardData.premiumCard > 0)
				{
					this.PremiumInplayImage.Image = GFXLibrary.PremiumTokens[GameEngine.Instance.cardsManager.UserCardData.premiumCard][0];
				}
				else
				{
					this.PremiumInplayImage.Image = GFXLibrary.PremiumTokens[4112][0];
				}
				this.PremiumInplayImage.Visible = true;
				if (this.ExpiryBar != null)
				{
					this.ExpiryBar.Visible = true;
				}
				this.expiryLabel.Visible = true;
				this.currentExpirySeconds = GameEngine.Instance.premiumTokenManager.ExpiryTimeSpan.TotalSeconds;
				this.expiryDays = this.currentExpirySeconds / 86400.0;
				this.expiryHours = this.currentExpirySeconds % 86400.0 / 3600.0;
				this.expiryMinutes = this.currentExpirySeconds % 3600.0 / 60.0;
				if (this.TimerInner != null)
				{
					this.ExpiryBar.setValues(this.currentExpirySeconds, this.maxExpirySeconds);
				}
				this.expiryLabel.Text = string.Concat(new string[]
				{
					Math.Floor(this.expiryDays).ToString().PadLeft(2, '0'),
					":",
					Math.Floor(this.expiryHours).ToString().PadLeft(2, '0'),
					":",
					Math.Floor(this.expiryMinutes).ToString().PadLeft(2, '0'),
					" (",
					SK.Text("PremiumCardsPanel_Day_Hour_Minute", "dd:hh:mm"),
					")"
				});
				this.lastminute = VillageMap.getCurrentServerTime().Minute;
				return;
			}
			this.PremiumInplayImage.Visible = false;
			this.expiryLabel.Visible = false;
			if (this.ExpiryBar != null)
			{
				this.ExpiryBar.Visible = false;
			}
		}

		// Token: 0x06001C87 RID: 7303 RVA: 0x001BFC08 File Offset: 0x001BDE08
		public void update()
		{
			if (this.lastminute != VillageMap.getCurrentServerTime().Minute)
			{
				this.UpdateExpiry();
			}
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x0001BF6F File Offset: 0x0001A16F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x0001BF8E File Offset: 0x0001A18E
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04002D4D RID: 11597
		private CustomSelfDrawPanel.CSDHorzProgressBar ExpiryBar;

		// Token: 0x04002D4E RID: 11598
		private CustomSelfDrawPanel.UICardsButtons cardsButtons;

		// Token: 0x04002D4F RID: 11599
		private Image premiumTokenImage;

		// Token: 0x04002D50 RID: 11600
		private CustomSelfDrawPanel.CSDFill TimerOuter;

		// Token: 0x04002D51 RID: 11601
		private CustomSelfDrawPanel.CSDFill TimerInner;

		// Token: 0x04002D52 RID: 11602
		private List<CustomSelfDrawPanel.CSDImage> PremiumTokens = new List<CustomSelfDrawPanel.CSDImage>();

		// Token: 0x04002D53 RID: 11603
		private CustomSelfDrawPanel.CSDLabel PremiumTokensLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D54 RID: 11604
		private CustomSelfDrawPanel.CSDImage PremiumInplayImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D55 RID: 11605
		private Size InnerBarDimentions = new Size(196, 12);

		// Token: 0x04002D56 RID: 11606
		private Size OuterBardimentions = new Size(200, 16);

		// Token: 0x04002D57 RID: 11607
		private CustomSelfDrawPanel.CSDLabel expiryLabel;

		// Token: 0x04002D58 RID: 11608
		private double currentExpirySeconds;

		// Token: 0x04002D59 RID: 11609
		private double maxExpirySeconds = 604800.0;

		// Token: 0x04002D5A RID: 11610
		private double expiryDays;

		// Token: 0x04002D5B RID: 11611
		private double expiryHours;

		// Token: 0x04002D5C RID: 11612
		private double expiryMinutes;

		// Token: 0x04002D5D RID: 11613
		private int lastminute;

		// Token: 0x04002D5E RID: 11614
		private static int expiryBarMax = 200;

		// Token: 0x04002D5F RID: 11615
		private int expiryBarCurrent;

		// Token: 0x04002D60 RID: 11616
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D61 RID: 11617
		private List<UICard> UICardList = new List<UICard>();

		// Token: 0x04002D62 RID: 11618
		private List<UICard> UICardListInplay = new List<UICard>();

		// Token: 0x04002D63 RID: 11619
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D64 RID: 11620
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D65 RID: 11621
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D66 RID: 11622
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D67 RID: 11623
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D68 RID: 11624
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D69 RID: 11625
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D6A RID: 11626
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D6B RID: 11627
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D6C RID: 11628
		private CustomSelfDrawPanel.CSDFill greyout = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002D6D RID: 11629
		private int currentCardSection = -1;

		// Token: 0x04002D6E RID: 11630
		private static int BorderPadding = 16;

		// Token: 0x04002D6F RID: 11631
		private int ContentWidth;

		// Token: 0x04002D70 RID: 11632
		private int AvailablePanelWidth;

		// Token: 0x04002D71 RID: 11633
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x04002D72 RID: 11634
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D73 RID: 11635
		private CustomSelfDrawPanel.CSDImage InplayPanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D74 RID: 11636
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D75 RID: 11637
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarInplay = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D76 RID: 11638
		private Bitmap greenbar = new Bitmap(29, 3);

		// Token: 0x04002D77 RID: 11639
		private bool inSend;

		// Token: 0x04002D78 RID: 11640
		private MyMessageBoxPopUp playPremiumPopup;

		// Token: 0x04002D79 RID: 11641
		private MyMessageBoxPopUp extendPremiumPopUp;

		// Token: 0x04002D7A RID: 11642
		private MyMessageBoxPopUp buyTokenPopUp;

		// Token: 0x04002D7B RID: 11643
		private bool buying;

		// Token: 0x04002D7C RID: 11644
		private IContainer components;
	}
}
