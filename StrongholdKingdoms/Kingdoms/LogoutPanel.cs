using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x02000216 RID: 534
	public class LogoutPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001666 RID: 5734 RVA: 0x00017B55 File Offset: 0x00015D55
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001667 RID: 5735 RVA: 0x00017B74 File Offset: 0x00015D74
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x00160DB0 File Offset: 0x0015EFB0
		public LogoutPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x00160F8C File Offset: 0x0015F18C
		public void init(bool normalLogout, bool advertOnly)
		{
			this.m_normalLogout = normalLogout;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
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
			if (LogoutPanel.hrImage == null)
			{
				LogoutPanel.hrImage = new Bitmap(base.Width - 10, 1);
				using (Graphics graphics = Graphics.FromImage(LogoutPanel.hrImage))
				{
					graphics.Clear(Color.FromArgb(255, 130, 129, 126));
				}
			}
			CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
			csdimage2.Image = LogoutPanel.hrImage;
			csdimage2.Size = LogoutPanel.hrImage.Size;
			csdimage2.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdimage2);
			this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			this.closeImage.Size = this.closeImage.Image.Size;
			this.closeImage.setMouseOverDelegate(delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				this.closeImage.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "LogoutPanel_close");
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.closeImage.CustomTooltipID = 1400;
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 41, new Point(base.Width - 14 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDImage csdimage3 = new CustomSelfDrawPanel.CSDImage();
			csdimage3.Image = GFXLibrary.logout_background_lhs;
			csdimage3.Position = new Point(4, 40);
			csdextendingPanel.addControl(csdimage3);
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(600, 64);
			if (advertOnly)
			{
				this.labelTitle.Text = SK.Text("LogoutPanel_Expiration", "Premium Token Expired");
			}
			else
			{
				this.labelTitle.Text = SK.Text("LogoutPanel_Logout", "Logout");
			}
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			NumberFormatInfo nfi = GameEngine.NFI;
			this.labelCrowns.Position = new Point(0, 8);
			this.labelCrowns.Size = new Size(900, 64);
			this.labelCrowns.Text = SK.Text("LogoutPanel_Crowns_In_Treasury", "Crowns in your treasury") + " : " + GameEngine.Instance.World.ProfileCrowns.ToString("N", nfi);
			this.labelCrowns.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.labelCrowns.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelCrowns.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelCrowns);
			CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			if (userCardData.premiumCard == 0 || GameEngine.Instance.World.WorldEnded)
			{
				this.premium = false;
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = GFXLibrary.logout_ad_1premfor30crown_01;
				csdbutton.ImageOver = GFXLibrary.logout_ad_1premfor30crown_01_over;
				csdbutton.Position = new Point(375, 50);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cardsClicked), "LogoutPanel_premium");
				this.mainBackgroundImage.addControl(csdbutton);
				int num = 35;
				int num2 = 53;
				CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel2 = new CustomSelfDrawPanel.CSDExtendingPanel();
				csdextendingPanel2.Size = new Size(594, 356);
				csdextendingPanel2.Position = new Point(csdimage3.Position.X + 372, csdimage3.Position.Y + 76 + 19);
				csdextendingPanel2.Alpha = 0.1f;
				this.mainBackgroundImage.addControl(csdextendingPanel2);
				csdextendingPanel2.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Premium_1", "With premium you command"),
					Position = new Point(0, 5),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width, 50),
					Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Premium_2", "even when you are offline!"),
					Position = new Point(0, 33),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width, 50),
					Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_BuildQueue_1", "Build-queue, build up to 5 buildings in your village at one time."),
					Position = new Point(65, num2),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_BuildQueue_2", "Research queue, 5 more items can be added to your research queue."),
					Position = new Point(65, num2 + num),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Scouting_1", "Use Auto scouting to forage for goods."),
					Position = new Point(65, num2 + num * 2),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Scouting_2", "Auto Trade - lets you set and trade the surplus of one goods type."),
					Position = new Point(65, num2 + num * 3),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Attacks_1", "Specify targets and Auto Attack will dispatch your armies."),
					Position = new Point(65, num2 + num * 4),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Attacks_2", "Keep your army topped up with Auto Recruit."),
					Position = new Point(65, num2 + num * 5),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Overview", "Keep track of key stats across all your villages with the Village Overview."),
					Position = new Point(65, num2 + num * 6),
					Color = global::ARGBColors.Black,
					Size = new Size(csdextendingPanel2.Width - 75, 50),
					Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.icon_building,
					Position = new Point(18, num2 + 7)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.icon_research,
					Position = new Point(18, num2 + 7 + num)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.wl_moving_unit_icons[2],
					Position = new Point(15, num2 + 5 + num * 2)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.wl_moving_unit_icons[1],
					Position = new Point(15, num2 + 5 + num * 3)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.wl_moving_unit_icons[0],
					Position = new Point(15, num2 + 5 + num * 4)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.wl_moving_unit_icons[0],
					Position = new Point(15, num2 + 5 + num * 5)
				});
				csdextendingPanel2.addControl(new CustomSelfDrawPanel.CSDImage
				{
					Image = GFXLibrary.wl_moving_unit_icons[4],
					Position = new Point(15, num2 + 5 + num * 6)
				});
			}
			else
			{
				this.premium = true;
				CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel3 = new CustomSelfDrawPanel.CSDExtendingPanel();
				csdextendingPanel3.Size = new Size(594, 432);
				csdextendingPanel3.Alpha = 0.1f;
				csdextendingPanel3.Position = new Point(csdimage3.Position.X + 372, csdimage3.Position.Y + 20);
				this.mainBackgroundImage.addControl(csdextendingPanel3);
				csdextendingPanel3.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
				CustomSelfDrawPanel.CSDImage csdimage4 = new CustomSelfDrawPanel.CSDImage();
				if (userCardData.premiumCard == 4114)
				{
					csdimage4.Image = GFXLibrary.logout_premium_token_30;
				}
				else if (userCardData.premiumCard == 4113)
				{
					csdimage4.Image = GFXLibrary.logout_premium_token_2;
				}
				else if (userCardData.premiumCard == 4116)
				{
					csdimage4.Image = GFXLibrary.logout_premium_token_extendable;
				}
				else
				{
					csdimage4.Image = GFXLibrary.logout_premium_token;
				}
				csdimage4.Position = new Point(-8, -8);
				csdimage4.CustomTooltipID = 1421;
				csdimage3.addControl(csdimage4);
				CustomSelfDrawPanel.CSDImage csdimage5 = new CustomSelfDrawPanel.CSDImage();
				csdimage5.Image = GFXLibrary.logout_gradation_band;
				csdimage5.Position = new Point(38, 30);
				csdextendingPanel3.addControl(csdimage5);
				CustomSelfDrawPanel.CSDImage csdimage6 = new CustomSelfDrawPanel.CSDImage();
				csdimage6.Image = GFXLibrary.wl_moving_unit_icons[1];
				csdimage6.Position = new Point(-4, -4);
				csdimage6.setClickDelegate(delegate()
				{
					this.tradingCheck.Checked = !this.tradingCheck.Checked;
					this.tradingToggled();
				}, "Generic_check_box_toggled");
				csdimage6.CustomTooltipID = 1401;
				csdimage5.addControl(csdimage6);
				this.tradingCheck.Position = new Point(-30, 2);
				this.tradingCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.tradingCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.tradingCheck.Checked = RemoteServices.Instance.UserOptions.autoTrade;
				this.tradingCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.tradingToggled));
				this.tradingCheck.CustomTooltipID = 1401;
				csdimage5.addControl(this.tradingCheck);
				csdimage5.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_Trading", "Auto Trading"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage5.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.tradingArea.Position = new Point(135, -20);
				this.tradingArea.Size = new Size(428, csdimage5.Height + 41);
				this.tradingArea.Visible = this.tradingCheck.Checked;
				csdimage5.addControl(this.tradingArea);
				int num3 = RemoteServices.Instance.UserOptions.autoTradeResource;
				if (num3 == -1)
				{
					num3 = 6;
				}
				this.tradingCircleButton.ImageNorm = GFXLibrary.logout_bits[7];
				this.tradingCircleButton.ImageOver = GFXLibrary.logout_bits[8];
				this.tradingCircleButton.Position = new Point(0, 1);
				this.tradingCircleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.tradingResourceClicked), "LogoutPanel_resources");
				this.tradingCircleButton.CustomTooltipID = 1407;
				this.tradingCircleButton.CustomTooltipData = num3;
				this.tradingArea.addControl(this.tradingCircleButton);
				this.tradingResourceImage.Image = GFXLibrary.getCommodity64DSImage(num3);
				this.tradingResourceImage.Size = new Size(69, 69);
				this.tradingResourceImage.Data = num3;
				this.tradingResourceImage.Position = new Point(0, 0);
				this.tradingCircleButton.addControl(this.tradingResourceImage);
				this.tradingTrackBar.Position = new Point(215, 25);
				this.tradingTrackBar.Margin = new Rectangle(73, -4, 0, 0);
				this.tradingTrackBar.Max = 100;
				this.tradingTrackBar.Value = RemoteServices.Instance.UserOptions.autoTradePercent;
				this.tradingTrackBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.tracksMoved));
				this.tradingArea.addControl(this.tradingTrackBar);
				this.tradingTrackBar.CustomTooltipID = 1408;
				this.tradingTrackBar.Create(GFXLibrary.logout_slider_back, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.tradingPercentLabel.Text = "0%";
				this.tradingPercentLabel.Position = new Point(0, 0);
				this.tradingPercentLabel.Color = global::ARGBColors.Black;
				this.tradingPercentLabel.Size = new Size(58, 23);
				this.tradingPercentLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.tradingPercentLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.tradingTrackBar.addControl(this.tradingPercentLabel);
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				csdlabel.Text = SK.Text("LogoutPanel_Trade_Over", "Trade Over");
				csdlabel.Position = new Point(0, 0);
				csdlabel.Color = global::ARGBColors.Black;
				csdlabel.Size = new Size(210, this.tradingArea.Height);
				csdlabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.tradingArea.addControl(csdlabel);
				this.tracksMoved();
				CustomSelfDrawPanel.CSDImage csdimage7 = new CustomSelfDrawPanel.CSDImage();
				csdimage7.Image = GFXLibrary.logout_gradation_band;
				csdimage7.Position = new Point(38, 100);
				csdextendingPanel3.addControl(csdimage7);
				CustomSelfDrawPanel.CSDImage csdimage8 = new CustomSelfDrawPanel.CSDImage();
				csdimage8.Image = GFXLibrary.wl_moving_unit_icons[2];
				csdimage8.Position = new Point(-4, -4);
				csdimage8.setClickDelegate(delegate()
				{
					this.scoutingCheck.Checked = !this.scoutingCheck.Checked;
					this.scoutingToggled();
				}, "Generic_check_box_toggled");
				csdimage8.CustomTooltipID = 1402;
				csdimage7.addControl(csdimage8);
				this.scoutingCheck.Position = new Point(-30, 2);
				this.scoutingCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.scoutingCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.scoutingCheck.Checked = RemoteServices.Instance.UserOptions.autoScout;
				this.scoutingCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.scoutingToggled));
				this.scoutingCheck.CustomTooltipID = 1402;
				csdimage7.addControl(this.scoutingCheck);
				csdimage7.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_Scouting", "Auto Scouting"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage7.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.scoutingArea.Position = new Point(135, -20);
				this.scoutingArea.Size = new Size(428, csdimage7.Height + 41);
				this.scoutingArea.Visible = this.scoutingCheck.Checked;
				csdimage7.addControl(this.scoutingArea);
				CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
				csdlabel2.Text = SK.Text("LogoutPanel_Auto_Scouting2", "Scout within your Parishes");
				csdlabel2.Position = new Point(0, 0);
				csdlabel2.Color = global::ARGBColors.Black;
				csdlabel2.Size = new Size(398, this.scoutingArea.Height);
				csdlabel2.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
				csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.scoutingArea.addControl(csdlabel2);
				CustomSelfDrawPanel.CSDImage csdimage9 = new CustomSelfDrawPanel.CSDImage();
				csdimage9.Image = GFXLibrary.logout_bits[14];
				csdimage9.Position = new Point(0, 1);
				this.scoutingArea.addControl(csdimage9);
				CustomSelfDrawPanel.CSDImage csdimage10 = new CustomSelfDrawPanel.CSDImage();
				csdimage10.Image = GFXLibrary.logout_gradation_band;
				csdimage10.Position = new Point(38, 170);
				csdextendingPanel3.addControl(csdimage10);
				CustomSelfDrawPanel.CSDImage csdimage11 = new CustomSelfDrawPanel.CSDImage();
				csdimage11.Image = GFXLibrary.wl_moving_unit_icons[24];
				csdimage11.Position = new Point(-4, -4);
				csdimage11.setClickDelegate(delegate()
				{
					this.attackCheck.Checked = !this.attackCheck.Checked;
					this.attackToggled();
				}, "Generic_check_box_toggled");
				csdimage11.CustomTooltipID = 1403;
				csdimage10.addControl(csdimage11);
				this.attackCheck.Position = new Point(-30, 2);
				this.attackCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.attackCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.attackCheck.Checked = RemoteServices.Instance.UserOptions.autoAttack;
				this.attackCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.attackToggled));
				this.attackCheck.CustomTooltipID = 1403;
				csdimage10.addControl(this.attackCheck);
				csdimage10.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_Attack", "Auto Attack"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage10.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.attackArea.Position = new Point(135, -20);
				this.attackArea.Size = new Size(428, csdimage10.Height + 40);
				this.attackArea.Visible = this.attackCheck.Checked;
				csdimage10.addControl(this.attackArea);
				this.attackCheck_Bandits.Position = new Point(0, 1);
				this.attackCheck_Bandits.CheckedImage = GFXLibrary.logout_bits[2];
				this.attackCheck_Bandits.UncheckedImage = GFXLibrary.logout_bits[0];
				this.attackCheck_Bandits.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.attackCheck_Bandits.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.attackCheck_Bandits.Checked = RemoteServices.Instance.UserOptions.autoAttackBandit;
				this.attackCheck_Bandits.CustomTooltipID = 1409;
				this.attackArea.addControl(this.attackCheck_Bandits);
				CustomSelfDrawPanel.CSDImage csdimage12 = new CustomSelfDrawPanel.CSDImage();
				csdimage12.Image = GFXLibrary.scout_screen_icons[24];
				csdimage12.Position = new Point(-20, -11);
				this.attackCheck_Bandits.addControl(csdimage12);
				this.attackCheck_Wolves.Position = new Point(85, 1);
				this.attackCheck_Wolves.CheckedImage = GFXLibrary.logout_bits[2];
				this.attackCheck_Wolves.UncheckedImage = GFXLibrary.logout_bits[0];
				this.attackCheck_Wolves.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.attackCheck_Wolves.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.attackCheck_Wolves.Checked = RemoteServices.Instance.UserOptions.autoAttackWolf;
				this.attackCheck_Wolves.CustomTooltipID = 1410;
				this.attackArea.addControl(this.attackCheck_Wolves);
				CustomSelfDrawPanel.CSDImage csdimage13 = new CustomSelfDrawPanel.CSDImage();
				csdimage13.Image = GFXLibrary.scout_screen_icons[25];
				csdimage13.Position = new Point(-8, -14);
				this.attackCheck_Wolves.addControl(csdimage13);
				this.attackCheck_AI.Position = new Point(170, 1);
				this.attackCheck_AI.CheckedImage = GFXLibrary.logout_bits[2];
				this.attackCheck_AI.UncheckedImage = GFXLibrary.logout_bits[0];
				this.attackCheck_AI.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.attackCheck_AI.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.attackCheck_AI.Checked = RemoteServices.Instance.UserOptions.autoAttackAI;
				this.attackCheck_AI.CustomTooltipID = 1411;
				this.attackArea.addControl(this.attackCheck_AI);
				CustomSelfDrawPanel.CSDImage csdimage14 = new CustomSelfDrawPanel.CSDImage();
				csdimage14.Image = GFXLibrary.scout_screen_icons[28];
				csdimage14.Position = new Point(-17, -11);
				this.attackCheck_AI.addControl(csdimage14);
				CustomSelfDrawPanel.CSDImage csdimage15 = new CustomSelfDrawPanel.CSDImage();
				csdimage15.Image = GFXLibrary.logout_gradation_band;
				csdimage15.Position = new Point(38, 240);
				csdextendingPanel3.addControl(csdimage15);
				CustomSelfDrawPanel.CSDImage csdimage16 = new CustomSelfDrawPanel.CSDImage();
				csdimage16.Image = GFXLibrary.wl_moving_unit_icons[0];
				csdimage16.Position = new Point(-4, -4);
				csdimage16.setClickDelegate(delegate()
				{
					this.recruitCheck.Checked = !this.recruitCheck.Checked;
					this.recruitToggled();
				}, "Generic_check_box_toggled");
				csdimage16.CustomTooltipID = 1404;
				csdimage15.addControl(csdimage16);
				this.recruitCheck.Position = new Point(-30, 2);
				this.recruitCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.recruitCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.recruitCheck.Checked = RemoteServices.Instance.UserOptions.autoRecruit;
				this.recruitCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggled));
				this.recruitCheck.CustomTooltipID = 1404;
				csdimage15.addControl(this.recruitCheck);
				csdimage15.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_Recruit", "Auto Recruit"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage15.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.recruitArea.Position = new Point(135, -20);
				this.recruitArea.Size = new Size(428, csdimage15.Height + 40 + 40 + 30);
				this.recruitArea.Visible = this.recruitCheck.Checked;
				csdimage15.addControl(this.recruitArea);
				this.recruitCheck_Peasants.Position = new Point(0, 1);
				this.recruitCheck_Peasants.CheckedImage = GFXLibrary.logout_bits[2];
				this.recruitCheck_Peasants.UncheckedImage = GFXLibrary.logout_bits[0];
				this.recruitCheck_Peasants.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.recruitCheck_Peasants.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.recruitCheck_Peasants.Checked = RemoteServices.Instance.UserOptions.autoRecruitPeasants;
				this.recruitCheck_Peasants.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggledUnit));
				this.recruitCheck_Peasants.CustomTooltipID = 1412;
				this.recruitArea.addControl(this.recruitCheck_Peasants);
				this.recruitTrackBar_Peasants.Position = new Point(this.recruitCheck_Peasants.Position.X + 3, 75);
				this.recruitTrackBar_Peasants.Margin = new Rectangle(0, -4, 0, 0);
				this.recruitTrackBar_Peasants.Max = 50;
				this.recruitTrackBar_Peasants.Value = RemoteServices.Instance.UserOptions.autoRecruitPeasants_Caps / 10;
				this.recruitTrackBar_Peasants.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.recruitTracksMoved));
				this.recruitArea.addControl(this.recruitTrackBar_Peasants);
				this.recruitTrackBar_Peasants.Create(GFXLibrary.logout_slider_back2, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.recruitNumber_Peasants.Text = "0";
				this.recruitNumber_Peasants.Position = new Point(this.recruitCheck_Peasants.Position.X, 105);
				this.recruitNumber_Peasants.Color = global::ARGBColors.Black;
				this.recruitNumber_Peasants.Size = new Size(this.recruitCheck_Peasants.Width, 20);
				this.recruitNumber_Peasants.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.recruitNumber_Peasants.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.recruitArea.addControl(this.recruitNumber_Peasants);
				CustomSelfDrawPanel.CSDImage csdimage17 = new CustomSelfDrawPanel.CSDImage();
				csdimage17.Image = GFXLibrary.logout_bits[9];
				csdimage17.Position = new Point(0, 0);
				this.recruitCheck_Peasants.addControl(csdimage17);
				this.recruitCheck_Archers.Position = new Point(85, 1);
				this.recruitCheck_Archers.CheckedImage = GFXLibrary.logout_bits[2];
				this.recruitCheck_Archers.UncheckedImage = GFXLibrary.logout_bits[0];
				this.recruitCheck_Archers.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.recruitCheck_Archers.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.recruitCheck_Archers.Checked = RemoteServices.Instance.UserOptions.autoRecruitArchers;
				this.recruitCheck_Archers.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggledUnit));
				this.recruitCheck_Archers.CustomTooltipID = 1413;
				this.recruitArea.addControl(this.recruitCheck_Archers);
				this.recruitTrackBar_Archers.Position = new Point(this.recruitCheck_Archers.Position.X + 3, 75);
				this.recruitTrackBar_Archers.Margin = new Rectangle(0, -4, 0, 0);
				this.recruitTrackBar_Archers.Max = 50;
				this.recruitTrackBar_Archers.Value = RemoteServices.Instance.UserOptions.autoRecruitArchers_Caps / 10;
				this.recruitTrackBar_Archers.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.recruitTracksMoved));
				this.recruitArea.addControl(this.recruitTrackBar_Archers);
				this.recruitTrackBar_Archers.Create(GFXLibrary.logout_slider_back2, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.recruitNumber_Archers.Text = "0";
				this.recruitNumber_Archers.Position = new Point(this.recruitCheck_Archers.Position.X, 105);
				this.recruitNumber_Archers.Color = global::ARGBColors.Black;
				this.recruitNumber_Archers.Size = new Size(this.recruitCheck_Archers.Width, 20);
				this.recruitNumber_Archers.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.recruitNumber_Archers.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.recruitArea.addControl(this.recruitNumber_Archers);
				CustomSelfDrawPanel.CSDImage csdimage18 = new CustomSelfDrawPanel.CSDImage();
				csdimage18.Image = GFXLibrary.logout_bits[10];
				csdimage18.Position = new Point(0, 0);
				this.recruitCheck_Archers.addControl(csdimage18);
				this.recruitCheck_Pikemen.Position = new Point(170, 1);
				this.recruitCheck_Pikemen.CheckedImage = GFXLibrary.logout_bits[2];
				this.recruitCheck_Pikemen.UncheckedImage = GFXLibrary.logout_bits[0];
				this.recruitCheck_Pikemen.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.recruitCheck_Pikemen.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.recruitCheck_Pikemen.Checked = RemoteServices.Instance.UserOptions.autoRecruitPikemen;
				this.recruitCheck_Pikemen.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggledUnit));
				this.recruitCheck_Pikemen.CustomTooltipID = 1414;
				this.recruitArea.addControl(this.recruitCheck_Pikemen);
				this.recruitTrackBar_Pikemen.Position = new Point(this.recruitCheck_Pikemen.Position.X + 3, 75);
				this.recruitTrackBar_Pikemen.Margin = new Rectangle(0, -4, 0, 0);
				this.recruitTrackBar_Pikemen.Max = 50;
				this.recruitTrackBar_Pikemen.Value = RemoteServices.Instance.UserOptions.autoRecruitPikemen_Caps / 10;
				this.recruitTrackBar_Pikemen.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.recruitTracksMoved));
				this.recruitArea.addControl(this.recruitTrackBar_Pikemen);
				this.recruitTrackBar_Pikemen.Create(GFXLibrary.logout_slider_back2, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.recruitNumber_Pikemen.Text = "0";
				this.recruitNumber_Pikemen.Position = new Point(this.recruitCheck_Pikemen.Position.X, 105);
				this.recruitNumber_Pikemen.Color = global::ARGBColors.Black;
				this.recruitNumber_Pikemen.Size = new Size(this.recruitCheck_Pikemen.Width, 20);
				this.recruitNumber_Pikemen.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.recruitNumber_Pikemen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.recruitArea.addControl(this.recruitNumber_Pikemen);
				CustomSelfDrawPanel.CSDImage csdimage19 = new CustomSelfDrawPanel.CSDImage();
				csdimage19.Image = GFXLibrary.logout_bits[11];
				csdimage19.Position = new Point(0, 0);
				this.recruitCheck_Pikemen.addControl(csdimage19);
				this.recruitCheck_Swordsmen.Position = new Point(255, 1);
				this.recruitCheck_Swordsmen.CheckedImage = GFXLibrary.logout_bits[2];
				this.recruitCheck_Swordsmen.UncheckedImage = GFXLibrary.logout_bits[0];
				this.recruitCheck_Swordsmen.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.recruitCheck_Swordsmen.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.recruitCheck_Swordsmen.Checked = RemoteServices.Instance.UserOptions.autoRecruitSwordsmen;
				this.recruitCheck_Swordsmen.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggledUnit));
				this.recruitCheck_Swordsmen.CustomTooltipID = 1415;
				this.recruitArea.addControl(this.recruitCheck_Swordsmen);
				this.recruitTrackBar_Swordsmen.Position = new Point(this.recruitCheck_Swordsmen.Position.X + 3, 75);
				this.recruitTrackBar_Swordsmen.Margin = new Rectangle(0, -4, 0, 0);
				this.recruitTrackBar_Swordsmen.Max = 50;
				this.recruitTrackBar_Swordsmen.Value = RemoteServices.Instance.UserOptions.autoRecruitSwordsmen_Caps / 10;
				this.recruitTrackBar_Swordsmen.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.recruitTracksMoved));
				this.recruitArea.addControl(this.recruitTrackBar_Swordsmen);
				this.recruitTrackBar_Swordsmen.Create(GFXLibrary.logout_slider_back2, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.recruitNumber_Swordsmen.Text = "0";
				this.recruitNumber_Swordsmen.Position = new Point(this.recruitCheck_Swordsmen.Position.X, 105);
				this.recruitNumber_Swordsmen.Color = global::ARGBColors.Black;
				this.recruitNumber_Swordsmen.Size = new Size(this.recruitCheck_Swordsmen.Width, 20);
				this.recruitNumber_Swordsmen.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.recruitNumber_Swordsmen.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.recruitArea.addControl(this.recruitNumber_Swordsmen);
				CustomSelfDrawPanel.CSDImage csdimage20 = new CustomSelfDrawPanel.CSDImage();
				csdimage20.Image = GFXLibrary.logout_bits[12];
				csdimage20.Position = new Point(0, 0);
				this.recruitCheck_Swordsmen.addControl(csdimage20);
				this.recruitCheck_Catapults.Position = new Point(340, 1);
				this.recruitCheck_Catapults.CheckedImage = GFXLibrary.logout_bits[2];
				this.recruitCheck_Catapults.UncheckedImage = GFXLibrary.logout_bits[0];
				this.recruitCheck_Catapults.CheckedOverImage = GFXLibrary.logout_bits[3];
				this.recruitCheck_Catapults.UncheckedOverImage = GFXLibrary.logout_bits[1];
				this.recruitCheck_Catapults.Checked = RemoteServices.Instance.UserOptions.autoRecruitCatapults;
				this.recruitCheck_Catapults.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.recruitToggledUnit));
				this.recruitCheck_Catapults.CustomTooltipID = 1416;
				this.recruitArea.addControl(this.recruitCheck_Catapults);
				this.recruitTrackBar_Catapults.Position = new Point(this.recruitCheck_Catapults.Position.X + 3, 75);
				this.recruitTrackBar_Catapults.Margin = new Rectangle(0, -4, 0, 0);
				this.recruitTrackBar_Catapults.Max = 50;
				this.recruitTrackBar_Catapults.Value = RemoteServices.Instance.UserOptions.autoRecruitCatapults_Caps / 5;
				this.recruitTrackBar_Catapults.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.recruitTracksMoved));
				this.recruitArea.addControl(this.recruitTrackBar_Catapults);
				this.recruitTrackBar_Catapults.Create(GFXLibrary.logout_slider_back2, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb, GFXLibrary.logout_slider_thumb);
				this.recruitNumber_Catapults.Text = "0";
				this.recruitNumber_Catapults.Position = new Point(this.recruitCheck_Catapults.Position.X, 105);
				this.recruitNumber_Catapults.Color = global::ARGBColors.Black;
				this.recruitNumber_Catapults.Size = new Size(this.recruitCheck_Catapults.Width, 20);
				this.recruitNumber_Catapults.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.recruitNumber_Catapults.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.recruitArea.addControl(this.recruitNumber_Catapults);
				CustomSelfDrawPanel.CSDImage csdimage21 = new CustomSelfDrawPanel.CSDImage();
				csdimage21.Image = GFXLibrary.logout_bits[13];
				csdimage21.Position = new Point(0, 0);
				this.recruitCheck_Catapults.addControl(csdimage21);
				this.recruitmentInfoLabel.Text = SK.Text("Logout_Recruitment_Cap", "Set Recruitment Cap");
				this.recruitmentInfoLabel.Position = new Point(-7, 125);
				this.recruitmentInfoLabel.Color = global::ARGBColors.Black;
				this.recruitmentInfoLabel.Size = new Size(this.recruitArea.Width, 23);
				this.recruitmentInfoLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.recruitmentInfoLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.recruitArea.addControl(this.recruitmentInfoLabel);
				this.recruitTracksMoved();
				this.updateRecruitVisibility();
				CustomSelfDrawPanel.CSDImage csdimage22 = new CustomSelfDrawPanel.CSDImage();
				csdimage22.Image = GFXLibrary.logout_gradation_band;
				csdimage22.Position = new Point(38, 310);
				csdimage22.Visible = false;
				csdextendingPanel3.addControl(csdimage22);
				CustomSelfDrawPanel.CSDImage csdimage23 = new CustomSelfDrawPanel.CSDImage();
				csdimage23.Image = GFXLibrary.wl_moving_unit_icons[1];
				csdimage23.Position = new Point(-4, -4);
				csdimage23.setClickDelegate(delegate()
				{
					this.transferCheck.Checked = !this.transferCheck.Checked;
					this.transferToggled();
				}, "Generic_check_box_toggled");
				csdimage23.CustomTooltipID = 1406;
				csdimage22.addControl(csdimage23);
				this.transferCheck.Position = new Point(-30, 2);
				this.transferCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.transferCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.transferCheck.Checked = false;
				this.transferCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.transferToggled));
				this.transferCheck.CustomTooltipID = 1406;
				csdimage22.addControl(this.transferCheck);
				csdimage22.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_transfer", "Auto Transfer"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage22.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.transferArea.Position = new Point(135, -20);
				this.transferArea.Size = new Size(428, csdimage22.Height + 40);
				this.transferArea.Visible = this.transferCheck.Checked;
				csdimage22.addControl(this.transferArea);
				CustomSelfDrawPanel.CSDImage csdimage24 = new CustomSelfDrawPanel.CSDImage();
				csdimage24.Image = GFXLibrary.logout_gradation_band;
				csdimage24.Position = new Point(38, 380);
				csdimage24.Visible = false;
				csdextendingPanel3.addControl(csdimage24);
				CustomSelfDrawPanel.CSDImage csdimage25 = new CustomSelfDrawPanel.CSDImage();
				csdimage25.Image = GFXLibrary.wl_moving_unit_icons[25];
				csdimage25.Position = new Point(-4, -4);
				csdimage25.setClickDelegate(delegate()
				{
					this.repairCheck.Checked = !this.repairCheck.Checked;
					this.repairToggled();
				}, "Generic_check_box_toggled");
				csdimage25.CustomTooltipID = 1405;
				csdimage24.addControl(csdimage25);
				this.repairCheck.Position = new Point(-30, 2);
				this.repairCheck.CheckedImage = GFXLibrary.checkbox_checked;
				this.repairCheck.UncheckedImage = GFXLibrary.checkbox_unchecked;
				this.repairCheck.Checked = false;
				this.repairCheck.setCheckChangedDelegate(new CustomSelfDrawPanel.CSDCheckBox.CSD_CheckChangedDelegate(this.repairToggled));
				this.repairCheck.CustomTooltipID = 1405;
				csdimage24.addControl(this.repairCheck);
				csdimage24.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = SK.Text("LogoutPanel_Auto_Rebuild", "Auto Rebuild"),
					Position = new Point(40, 0),
					Color = global::ARGBColors.Black,
					Size = new Size(140, csdimage24.Height),
					Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT
				});
				this.repairArea.Position = new Point(135, -20);
				this.repairArea.Size = new Size(428, csdimage24.Height + 40);
				this.repairArea.Visible = this.repairCheck.Checked;
				csdimage24.addControl(this.repairArea);
				CustomSelfDrawPanel.CSDImage csdimage26 = new CustomSelfDrawPanel.CSDImage();
				csdimage26.Image = GFXLibrary.logout_bits[4];
				csdimage26.Position = new Point(0, 0);
				this.repairArea.addControl(csdimage26);
			}
			if (!GameEngine.Instance.World.isBigpointAccount && !Program.bigpointInstall && !Program.aeriaInstall && !Program.bigpointPartnerInstall)
			{
				CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
				csdbutton2.ImageNorm = GFXLibrary.banner_ad_friend;
				csdbutton2.OverBrighten = true;
				csdbutton2.Position = new Point(375, 496);
				csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.friendClicked), "LogoutPanel_invite_a_friend");
				this.mainBackgroundImage.addControl(csdbutton2);
			}
			if (normalLogout && !advertOnly)
			{
				CustomSelfDrawPanel.CSDButton csdbutton3 = new CustomSelfDrawPanel.CSDButton();
				csdbutton3.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				csdbutton3.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				csdbutton3.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				csdbutton3.Position = new Point(423, 453);
				csdbutton3.Text.Text = SK.Text("LogoutPanel_Swap_Worlds", "Swap Worlds");
				csdbutton3.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdbutton3.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				csdbutton3.TextYOffset = -2;
				csdbutton3.Text.Color = global::ARGBColors.Black;
				csdbutton3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.doLogout), "LogoutPanel_swap_worlds");
				csdbutton3.CustomTooltipID = 1420;
				csdextendingPanel.addControl(csdbutton3);
				this.logoutPressed = false;
			}
			if (!advertOnly)
			{
				CustomSelfDrawPanel.CSDButton csdbutton4 = new CustomSelfDrawPanel.CSDButton();
				csdbutton4.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				csdbutton4.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				csdbutton4.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				csdbutton4.Position = new Point(787, 453);
				csdbutton4.Text.Text = SK.Text("GENERIC_Exit", "Exit");
				csdbutton4.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdbutton4.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				csdbutton4.TextYOffset = -2;
				csdbutton4.Text.Color = global::ARGBColors.Black;
				csdbutton4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.doQuit), "LogoutPanel_exit");
				csdbutton4.CustomTooltipID = 1418;
				csdextendingPanel.addControl(csdbutton4);
			}
			if (normalLogout && !advertOnly)
			{
				CustomSelfDrawPanel.CSDButton csdbutton5 = new CustomSelfDrawPanel.CSDButton();
				csdbutton5.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				csdbutton5.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				csdbutton5.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				csdbutton5.Position = new Point(605, 453);
				csdbutton5.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
				csdbutton5.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdbutton5.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				csdbutton5.TextYOffset = -2;
				csdbutton5.Text.Color = global::ARGBColors.Black;
				csdbutton5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "LogoutPanel_cancel");
				csdbutton5.CustomTooltipID = 1419;
				csdextendingPanel.addControl(csdbutton5);
			}
			else if (advertOnly)
			{
				CustomSelfDrawPanel.CSDButton csdbutton6 = new CustomSelfDrawPanel.CSDButton();
				csdbutton6.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				csdbutton6.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				csdbutton6.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				csdbutton6.Position = new Point(605, 453);
				csdbutton6.Text.Text = SK.Text("GENERIC_OK", "OK");
				csdbutton6.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdbutton6.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				csdbutton6.TextYOffset = -2;
				csdbutton6.Text.Color = global::ARGBColors.Black;
				csdbutton6.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "LogoutPanel_cancel");
				csdextendingPanel.addControl(csdbutton6);
			}
			this.update();
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x0600166B RID: 5739 RVA: 0x00163F5C File Offset: 0x0016215C
		private void closeClick()
		{
			StatTrackingClient.Instance().ActivateTrigger(26, false);
			if (this.m_normalLogout)
			{
				this.closePopup();
				InterfaceMgr.Instance.closeLogoutWindow();
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.TopMost = false;
				return;
			}
			this.doQuit();
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x00163FBC File Offset: 0x001621BC
		private void doLogout()
		{
			if (!this.logoutPressed)
			{
				this.logoutPressed = true;
				Sound.stopVillageEnvironmental();
				if (InterfaceMgr.Instance.ParentForm != null)
				{
					InterfaceMgr.Instance.ParentForm.Hide();
				}
				if (!this.premium)
				{
					LoggingOutPopup.open(true, false, false, false, false, false, false, 6, 0, false, false, false, false, false, false, 500, 500, 500, 500, 250);
				}
				else
				{
					LoggingOutPopup.open(true, this.scoutingCheck.Checked, this.tradingCheck.Checked, this.attackCheck.Checked, this.attackCheck_Wolves.Checked, this.attackCheck_Bandits.Checked, this.attackCheck_AI.Checked, this.tradingResourceImage.Data, this.tradingTrackBar.Value, this.recruitCheck.Checked, this.recruitCheck_Peasants.Checked, this.recruitCheck_Archers.Checked, this.recruitCheck_Pikemen.Checked, this.recruitCheck_Swordsmen.Checked, this.recruitCheck_Catapults.Checked, this.recruitTrackBar_Peasants.Value * 10, this.recruitTrackBar_Archers.Value * 10, this.recruitTrackBar_Pikemen.Value * 10, this.recruitTrackBar_Swordsmen.Value * 10, this.recruitTrackBar_Catapults.Value * 5);
				}
				this.closePopup();
				InterfaceMgr.Instance.closeLogoutWindow();
			}
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0016412C File Offset: 0x0016232C
		private void doQuit()
		{
			Sound.stopVillageEnvironmental();
			if (!this.premium)
			{
				RemoteServices.Instance.LogOut(true, false, false, false, false, false, false, 6, 0, false, false, false, false, false, false, 500, 500, 500, 500, 250);
			}
			else
			{
				RemoteServices.Instance.LogOut(true, this.scoutingCheck.Checked, this.tradingCheck.Checked, this.attackCheck.Checked, this.attackCheck_Wolves.Checked, this.attackCheck_Bandits.Checked, this.attackCheck_AI.Checked, this.tradingResourceImage.Data, this.tradingTrackBar.Value, this.recruitCheck.Checked, this.recruitCheck_Peasants.Checked, this.recruitCheck_Archers.Checked, this.recruitCheck_Pikemen.Checked, this.recruitCheck_Swordsmen.Checked, this.recruitCheck_Catapults.Checked, this.recruitTrackBar_Peasants.Value * 10, this.recruitTrackBar_Archers.Value * 10, this.recruitTrackBar_Pikemen.Value * 10, this.recruitTrackBar_Swordsmen.Value * 10, this.recruitTrackBar_Catapults.Value * 5);
			}
			GameEngine.Instance.sessionExpired(-1);
			GameEngine.Instance.FlagQuitGame();
			this.closePopup();
			LogoutOptionsWindow2.closing = true;
			InterfaceMgr.Instance.closeLogoutWindow();
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x00164294 File Offset: 0x00162494
		private void cardsClicked()
		{
			StatTrackingClient.Instance().ActivateTrigger(26, true);
			this.closePopup();
			InterfaceMgr.Instance.closeLogoutWindow();
			PlayCardsWindow playCardsWindow = InterfaceMgr.Instance.openPlayCardsWindow(0);
			playCardsWindow.SwitchPanel(4);
		}

		// Token: 0x0600166F RID: 5743 RVA: 0x00132AB0 File Offset: 0x00130CB0
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

		// Token: 0x06001670 RID: 5744 RVA: 0x00017B88 File Offset: 0x00015D88
		private void tradingToggled()
		{
			this.tradingArea.Visible = this.tradingCheck.Checked;
		}

		// Token: 0x06001671 RID: 5745 RVA: 0x00017BA0 File Offset: 0x00015DA0
		private void scoutingToggled()
		{
			this.scoutingArea.Visible = this.scoutingCheck.Checked;
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x00017BB8 File Offset: 0x00015DB8
		private void attackToggled()
		{
			this.attackArea.Visible = this.attackCheck.Checked;
		}

		// Token: 0x06001673 RID: 5747 RVA: 0x00017BD0 File Offset: 0x00015DD0
		private void recruitToggled()
		{
			this.recruitArea.Visible = this.recruitCheck.Checked;
			this.mainBackgroundImage.invalidate();
			this.updateRecruitVisibility();
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x00017BF9 File Offset: 0x00015DF9
		private void transferToggled()
		{
			this.transferArea.Visible = this.transferCheck.Checked;
		}

		// Token: 0x06001675 RID: 5749 RVA: 0x00017C11 File Offset: 0x00015E11
		private void repairToggled()
		{
			this.repairArea.Visible = this.repairCheck.Checked;
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x001642D8 File Offset: 0x001624D8
		private void tradingResourceClicked()
		{
			if (!this.closePopup())
			{
				this.m_resourcePopup = new SelectTradingResourcePopup();
				Point point = this.tradingCircleButton.getPanelPosition();
				point = new Point(point.X + this.tradingCircleButton.Width / 2 - 300, point.Y + this.tradingCircleButton.Height + 20);
				point = base.Parent.PointToScreen(point);
				this.m_resourcePopup.init(this.tradingResourceImage.Data, point, this, (LogoutOptionsWindow2)base.Parent);
			}
		}

		// Token: 0x06001677 RID: 5751 RVA: 0x00017C29 File Offset: 0x00015E29
		public void vacationModeCloseCheck()
		{
			if (!this.m_normalLogout)
			{
				this.doQuit();
			}
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0016436C File Offset: 0x0016256C
		public bool closePopup()
		{
			bool result = false;
			if (this.m_resourcePopup != null)
			{
				if (this.m_resourcePopup.Created)
				{
					this.m_resourcePopup.Close();
					result = true;
				}
				this.m_resourcePopup = null;
			}
			return result;
		}

		// Token: 0x06001679 RID: 5753 RVA: 0x001643A8 File Offset: 0x001625A8
		public void resourceSelected(int resource)
		{
			this.tradingResourceImage.Image = GFXLibrary.getCommodity64DSImage(resource);
			this.tradingResourceImage.Size = new Size(69, 69);
			this.tradingResourceImage.Data = resource;
			this.tradingCircleButton.CustomTooltipData = resource;
			this.closePopup();
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x00164400 File Offset: 0x00162600
		public void tracksMoved()
		{
			this.tradingPercentLabel.Text = this.tradingTrackBar.Value.ToString() + "%";
		}

		// Token: 0x0600167B RID: 5755 RVA: 0x00164438 File Offset: 0x00162638
		public void recruitTracksMoved()
		{
			this.recruitNumber_Peasants.Text = (this.recruitTrackBar_Peasants.Value * 10).ToString();
			this.recruitNumber_Archers.Text = (this.recruitTrackBar_Archers.Value * 10).ToString();
			this.recruitNumber_Pikemen.Text = (this.recruitTrackBar_Pikemen.Value * 10).ToString();
			this.recruitNumber_Swordsmen.Text = (this.recruitTrackBar_Swordsmen.Value * 10).ToString();
			this.recruitNumber_Catapults.Text = (this.recruitTrackBar_Catapults.Value * 5).ToString();
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x00017C39 File Offset: 0x00015E39
		public void recruitToggledUnit()
		{
			this.updateRecruitVisibility();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x0600167D RID: 5757 RVA: 0x001644EC File Offset: 0x001626EC
		public void updateRecruitVisibility()
		{
			CustomSelfDrawPanel.CSDTrackBar csdtrackBar = this.recruitTrackBar_Peasants;
			bool visible = this.recruitNumber_Peasants.Visible = this.recruitCheck_Peasants.Checked;
			csdtrackBar.Visible = visible;
			CustomSelfDrawPanel.CSDTrackBar csdtrackBar2 = this.recruitTrackBar_Archers;
			bool visible2 = this.recruitNumber_Archers.Visible = this.recruitCheck_Archers.Checked;
			csdtrackBar2.Visible = visible2;
			CustomSelfDrawPanel.CSDTrackBar csdtrackBar3 = this.recruitTrackBar_Pikemen;
			bool visible3 = this.recruitNumber_Pikemen.Visible = this.recruitCheck_Pikemen.Checked;
			csdtrackBar3.Visible = visible3;
			CustomSelfDrawPanel.CSDTrackBar csdtrackBar4 = this.recruitTrackBar_Swordsmen;
			bool visible4 = this.recruitNumber_Swordsmen.Visible = this.recruitCheck_Swordsmen.Checked;
			csdtrackBar4.Visible = visible4;
			CustomSelfDrawPanel.CSDTrackBar csdtrackBar5 = this.recruitTrackBar_Catapults;
			bool visible5 = this.recruitNumber_Catapults.Visible = this.recruitCheck_Catapults.Checked;
			csdtrackBar5.Visible = visible5;
		}

		// Token: 0x040026A8 RID: 9896
		private const int CHECK_HORZ_SPACING = 85;

		// Token: 0x040026A9 RID: 9897
		private IContainer components;

		// Token: 0x040026AA RID: 9898
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026AB RID: 9899
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026AC RID: 9900
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026AD RID: 9901
		private CustomSelfDrawPanel.CSDLabel labelCrowns = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026AE RID: 9902
		private CustomSelfDrawPanel.CSDCheckBox tradingCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026AF RID: 9903
		private CustomSelfDrawPanel.CSDCheckBox scoutingCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B0 RID: 9904
		private CustomSelfDrawPanel.CSDCheckBox attackCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B1 RID: 9905
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B2 RID: 9906
		private CustomSelfDrawPanel.CSDCheckBox repairCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B3 RID: 9907
		private CustomSelfDrawPanel.CSDCheckBox transferCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B4 RID: 9908
		private CustomSelfDrawPanel.CSDCheckBox attackCheck_Bandits = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B5 RID: 9909
		private CustomSelfDrawPanel.CSDCheckBox attackCheck_Wolves = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B6 RID: 9910
		private CustomSelfDrawPanel.CSDCheckBox attackCheck_AI = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B7 RID: 9911
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck_Peasants = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B8 RID: 9912
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck_Archers = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026B9 RID: 9913
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck_Pikemen = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026BA RID: 9914
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck_Swordsmen = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026BB RID: 9915
		private CustomSelfDrawPanel.CSDCheckBox recruitCheck_Catapults = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x040026BC RID: 9916
		private CustomSelfDrawPanel.CSDTrackBar recruitTrackBar_Peasants = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026BD RID: 9917
		private CustomSelfDrawPanel.CSDTrackBar recruitTrackBar_Archers = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026BE RID: 9918
		private CustomSelfDrawPanel.CSDTrackBar recruitTrackBar_Pikemen = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026BF RID: 9919
		private CustomSelfDrawPanel.CSDTrackBar recruitTrackBar_Swordsmen = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026C0 RID: 9920
		private CustomSelfDrawPanel.CSDTrackBar recruitTrackBar_Catapults = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026C1 RID: 9921
		private CustomSelfDrawPanel.CSDLabel recruitNumber_Peasants = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C2 RID: 9922
		private CustomSelfDrawPanel.CSDLabel recruitNumber_Archers = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C3 RID: 9923
		private CustomSelfDrawPanel.CSDLabel recruitNumber_Pikemen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C4 RID: 9924
		private CustomSelfDrawPanel.CSDLabel recruitNumber_Swordsmen = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C5 RID: 9925
		private CustomSelfDrawPanel.CSDLabel recruitNumber_Catapults = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C6 RID: 9926
		private CustomSelfDrawPanel.CSDLabel recruitmentInfoLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026C7 RID: 9927
		private CustomSelfDrawPanel.CSDArea tradingArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026C8 RID: 9928
		private CustomSelfDrawPanel.CSDArea scoutingArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026C9 RID: 9929
		private CustomSelfDrawPanel.CSDArea attackArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026CA RID: 9930
		private CustomSelfDrawPanel.CSDArea recruitArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026CB RID: 9931
		private CustomSelfDrawPanel.CSDArea repairArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026CC RID: 9932
		private CustomSelfDrawPanel.CSDArea transferArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040026CD RID: 9933
		private CustomSelfDrawPanel.CSDButton tradingCircleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040026CE RID: 9934
		private CustomSelfDrawPanel.CSDImage tradingResourceImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040026CF RID: 9935
		private CustomSelfDrawPanel.CSDTrackBar tradingTrackBar = new CustomSelfDrawPanel.CSDTrackBar();

		// Token: 0x040026D0 RID: 9936
		private CustomSelfDrawPanel.CSDLabel tradingPercentLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040026D1 RID: 9937
		private static Image hrImage;

		// Token: 0x040026D2 RID: 9938
		private bool premium;

		// Token: 0x040026D3 RID: 9939
		private bool m_normalLogout = true;

		// Token: 0x040026D4 RID: 9940
		private bool logoutPressed;

		// Token: 0x040026D5 RID: 9941
		private SelectTradingResourcePopup m_resourcePopup;

		// Token: 0x02000217 RID: 535
		private class ResourceItem
		{
			// Token: 0x06001686 RID: 5766 RVA: 0x00017D40 File Offset: 0x00015F40
			public ResourceItem(string name, int id)
			{
				this.resourceName = name;
				this.resourceBuildingID = id;
			}

			// Token: 0x06001687 RID: 5767 RVA: 0x00017D56 File Offset: 0x00015F56
			public override string ToString()
			{
				return this.resourceName;
			}

			// Token: 0x040026D6 RID: 9942
			public string resourceName;

			// Token: 0x040026D7 RID: 9943
			public int resourceBuildingID;
		}
	}
}
