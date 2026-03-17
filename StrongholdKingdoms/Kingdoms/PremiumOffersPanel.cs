using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200027D RID: 637
	public class PremiumOffersPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x06001C98 RID: 7320 RVA: 0x0001C07D File Offset: 0x0001A27D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C99 RID: 7321 RVA: 0x0001C09C File Offset: 0x0001A29C
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06001C9A RID: 7322 RVA: 0x001BFCE8 File Offset: 0x001BDEE8
		public PremiumOffersPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001C9B RID: 7323 RVA: 0x001BFDA0 File Offset: 0x001BDFA0
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * PremiumOffersPanel.BorderPadding;
			this.AvailablePanelWidth = this.ContentWidth - 150 - 40;
			this.InplayPanelWidth = this.ContentWidth - PremiumOffersPanel.BorderPadding - this.AvailablePanelWidth;
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Size = base.Size;
			csdextendingPanel.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(csdextendingPanel);
			csdextendingPanel.Create(GFXLibrary.cardpanel_panel_back_top_left, GFXLibrary.cardpanel_panel_back_top_mid, GFXLibrary.cardpanel_panel_back_top_right, GFXLibrary.cardpanel_panel_back_mid_left, GFXLibrary.cardpanel_panel_back_mid_mid, GFXLibrary.cardpanel_panel_back_mid_right, GFXLibrary.cardpanel_panel_back_bottom_left, GFXLibrary.cardpanel_panel_back_bottom_mid, GFXLibrary.cardpanel_panel_back_bottom_right);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.InsetPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			this.InsetPanel.Position = new Point(PremiumOffersPanel.BorderPadding, PremiumOffersPanel.BorderPadding * 2 + 10);
			this.InsetPanel.Size = new Size(this.AvailablePanelWidth, base.Height - this.InsetPanel.Position.Y - PremiumOffersPanel.BorderPadding - 10);
			this.mainBackgroundImage.addControl(this.InsetPanel);
			this.InsetPanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			int width = base.Width;
			int borderPadding = PremiumOffersPanel.BorderPadding;
			int width2 = this.InsetPanel.Width;
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
			this.closeImage.CustomTooltipID = 10100;
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.mainBackgroundImage.addControl(this.closeImage);
			this.cardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			this.cardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(this.cardsButtons);
			this.InsetPanel.addControl(this.OfferListPanel);
			this.InsetPanel.addControl(this.ContentPanel);
			this.mainBackgroundImage.addControl(this.OfferListScrollbar);
			this.mainBackgroundImage.addControl(this.ContentScrollbar);
			CustomSelfDrawPanel.CSDControl csdcontrol = new CustomSelfDrawPanel.CSDControl();
			csdcontrol.Position = new Point(0, 0);
			csdcontrol.Size = base.Size;
			this.mainBackgroundImage.addControl(csdcontrol);
			this.mainBackgroundImage.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelHandler));
			this.backButton.ImageNorm = GFXLibrary.button_132_normal;
			this.backButton.ImageOver = GFXLibrary.button_132_over;
			this.backButton.ImageClick = GFXLibrary.button_132_in;
			this.backButton.setSizeToImage();
			this.backButton.Position = new Point(this.InsetPanel.Width / 4 - this.backButton.Width / 2, this.InsetPanel.Height - 30 - this.backButton.Height / 2);
			this.backButton.Text.Text = SK.Text("FORUMS_Back", "Back");
			this.backButton.Text.Color = global::ARGBColors.Black;
			Font font = this.backButton.Text.Font = (this.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold));
			this.backButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showOfferList));
			this.InsetPanel.addControl(this.backButton);
			this.labelCost.Size = new Size(this.InsetPanel.Width / 4, 64);
			this.labelCost.Position = new Point(this.InsetPanel.Width / 4, this.InsetPanel.Height - 30 - this.labelCost.Height / 2);
			this.labelCost.Text = "";
			this.labelCost.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.labelCost.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelCost.Color = global::ARGBColors.White;
			this.InsetPanel.addControl(this.labelCost);
			this.crownsIcon.Image = GFXLibrary.card_offer_pieces[2];
			this.crownsIcon.setSizeToImage();
			this.crownsIcon.Position = new Point(this.InsetPanel.Width / 2 + PremiumOffersPanel.BorderPadding, this.InsetPanel.Height - 30 - this.crownsIcon.Height / 2);
			this.InsetPanel.addControl(this.crownsIcon);
			this.purchaseButton.ImageNorm = GFXLibrary.button_132_normal_gold;
			this.purchaseButton.ImageOver = GFXLibrary.button_132_over_gold;
			this.purchaseButton.ImageClick = GFXLibrary.button_132_in_gold;
			this.purchaseButton.setSizeToImage();
			this.purchaseButton.Position = new Point(this.InsetPanel.Width * 3 / 4 - this.purchaseButton.Width / 2, this.InsetPanel.Height - 30 - this.purchaseButton.Height / 2);
			this.purchaseButton.Text.Text = SK.Text("EmptyVillagePanel_Buy_Village", "Purchase");
			this.purchaseButton.Text.Color = global::ARGBColors.Black;
			font = (this.purchaseButton.Text.Font = (this.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold)));
			this.purchaseButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.confirmPurchaseOffer));
			this.InsetPanel.addControl(this.purchaseButton);
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(780, 64);
			this.labelTitle.Text = "";
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			this.showOfferList();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06001C9C RID: 7324 RVA: 0x001C057C File Offset: 0x001BE77C
		private void mouseWheelHandler(int delta)
		{
			if (delta > 0)
			{
				if (this.OfferListPanel.Visible)
				{
					if (this.OfferListScrollbar.Value - delta * 15 > 0)
					{
						this.OfferListScrollbar.Value += delta * -15;
					}
					else
					{
						this.OfferListScrollbar.Value = 0;
					}
					this.OfferListScroll();
					return;
				}
				if (this.ContentPanel.Visible)
				{
					if (this.ContentScrollbar.Value - delta * 15 > 0)
					{
						this.ContentScrollbar.Value += delta * -15;
					}
					else
					{
						this.ContentScrollbar.Value = 0;
					}
					this.ContentScroll();
					return;
				}
			}
			else
			{
				if (delta >= 0)
				{
					return;
				}
				if (this.OfferListPanel.Visible)
				{
					if (this.OfferListScrollbar.Value - delta * 15 < this.OfferListScrollbar.Max)
					{
						this.OfferListScrollbar.Value += delta * -15;
					}
					else
					{
						this.OfferListScrollbar.Value = this.OfferListScrollbar.Max;
					}
					this.OfferListScroll();
					return;
				}
				if (this.ContentPanel.Visible)
				{
					if (this.ContentScrollbar.Value - delta * 15 < this.ContentScrollbar.Max)
					{
						this.ContentScrollbar.Value += delta * -15;
					}
					else
					{
						this.ContentScrollbar.Value = this.ContentScrollbar.Max;
					}
					this.ContentScroll();
				}
			}
		}

		// Token: 0x06001C9D RID: 7325 RVA: 0x001C06EC File Offset: 0x001BE8EC
		private void OfferListScroll()
		{
			if (this.OfferListScrollbar.Visible)
			{
				int value = this.OfferListScrollbar.Value;
				this.OfferListPanel.Position = new Point(this.OfferListPanel.Position.X, -value);
				this.OfferListPanel.ClipRect = new Rectangle(this.OfferListPanel.ClipRect.X, value, this.OfferListPanel.ClipRect.Width, this.OfferListPanel.ClipRect.Height);
				this.OfferListPanel.invalidate();
				this.InsetPanel.invalidate();
			}
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x001C079C File Offset: 0x001BE99C
		private void ContentScroll()
		{
			if (this.ContentScrollbar.Visible)
			{
				int value = this.ContentScrollbar.Value;
				this.ContentPanel.Position = new Point(this.ContentPanel.Position.X, -value);
				this.ContentPanel.ClipRect = new Rectangle(this.ContentPanel.ClipRect.X, value, this.ContentPanel.ClipRect.Width, this.ContentPanel.ClipRect.Height);
				this.ContentPanel.invalidate();
				this.InsetPanel.invalidate();
			}
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x001C084C File Offset: 0x001BEA4C
		private void viewClick()
		{
			int data = CustomSelfDrawPanel.StaticClickedControl.Data;
			if (data < 0)
			{
				PlayCardsWindow playCardsWindow = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
				playCardsWindow.GetCrowns("&click=saleindicator");
				return;
			}
			this.showOfferContent();
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x001C088C File Offset: 0x001BEA8C
		private void showOfferList()
		{
			this.OfferListPanel.clearControls();
			int num = 5;
			DateTime currentServerTime = VillageMap.getCurrentServerTime();
			DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleStartTime);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleEndTime);
			this.labelTitle.Text = SK.Text("TOUCH_Z_PurchaseSpecialOffer", "Purchase Special Offer");
			if (t <= currentServerTime && dateTime > currentServerTime)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = GFXLibrary.offer_sale_normal;
				csdbutton.ImageOver = GFXLibrary.offer_sale_over;
				csdbutton.Position = new Point(this.InsetPanel.Width / 2 - csdbutton.ImageNorm.Width / 2, num);
				csdbutton.Data = -1;
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.viewClick));
				this.OfferListPanel.addControl(csdbutton);
				num += csdbutton.ImageNorm.Height;
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				csdlabel.Size = new Size(csdbutton.Width * 2 / 3, 55);
				csdlabel.Position = new Point(csdbutton.Width * 2 / 3 - csdlabel.Width / 2, 20);
				csdlabel.Text = SK.Text("TOUCH_Z_Sale", "Sale").ToUpper();
				csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				csdlabel.Font = FontManager.GetFont("Arial", 40f, FontStyle.Bold);
				csdlabel.Color = global::ARGBColors.White;
				csdlabel.DropShadowColor = global::ARGBColors.DarkRed;
				csdbutton.addControl(csdlabel);
				CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
				csdlabel2.Size = new Size(csdbutton.Width * 2 / 3, 45);
				csdlabel2.Position = new Point(csdbutton.Width * 2 / 3 - csdlabel2.Width / 2, csdlabel.Rectangle.Bottom);
				csdlabel2.Text = GameEngine.Instance.World.salePercentage.ToString() + "%";
				CustomSelfDrawPanel.CSDLabel csdlabel3 = csdlabel2;
				csdlabel3.Text += " ";
				CustomSelfDrawPanel.CSDLabel csdlabel4 = csdlabel2;
				csdlabel4.Text += SK.Text("TOUCH_Z_ExtraCrowns", "Extra Crowns");
				csdlabel2.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				csdlabel2.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
				csdlabel2.Color = global::ARGBColors.White;
				csdbutton.addControl(csdlabel2);
				TimeSpan timeSpan = dateTime - currentServerTime;
				CustomSelfDrawPanel.CSDLabel csdlabel5 = new CustomSelfDrawPanel.CSDLabel();
				csdlabel5.Size = new Size(csdbutton.Width * 2 / 3, 25);
				csdlabel5.Position = new Point(csdbutton.Width * 2 / 3 - csdlabel5.Width / 2, csdbutton.Height * 3 / 4 - csdlabel5.Height / 2);
				csdlabel5.Text = VillageMap.createBuildTimeVariable((int)timeSpan.TotalSeconds);
				csdlabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				csdlabel5.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				csdlabel5.Color = global::ARGBColors.White;
				csdlabel5.DropShadowColor = global::ARGBColors.Black;
				csdbutton.addControl(csdlabel5);
				csdbutton.dataObject = null;
			}
			PremiumOfferData[] premiumOffers = GameEngine.Instance.cardsManager.PremiumOffers;
			for (int i = 0; i < premiumOffers.Length; i++)
			{
				CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
				DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)premiumOffers[i].ExpirationTimestamp);
				if (!(currentServerTime >= dateTime2) && !premiumOffers[i].HasBeenPurchased)
				{
					int offerType = premiumOffers[i].OfferType;
					if (offerType != 1)
					{
						csdbutton2.ImageNorm = GFXLibrary.offer_special_normal;
						csdbutton2.ImageOver = GFXLibrary.offer_special_over;
					}
					else if (premiumOffers[i].Multiplier < 5)
					{
						csdbutton2.ImageNorm = GFXLibrary.offer_bundle_1_normal;
						csdbutton2.ImageOver = GFXLibrary.offer_bundle_1_over;
					}
					else if (premiumOffers[i].Multiplier < 10)
					{
						csdbutton2.ImageNorm = GFXLibrary.offer_bundle_2_normal;
						csdbutton2.ImageOver = GFXLibrary.offer_bundle_2_over;
					}
					else
					{
						csdbutton2.ImageNorm = GFXLibrary.offer_bundle_3_normal;
						csdbutton2.ImageOver = GFXLibrary.offer_bundle_3_over;
					}
					csdbutton2.Position = new Point(this.InsetPanel.Width / 2 - csdbutton2.ImageNorm.Width / 2, num);
					csdbutton2.Data = premiumOffers[i].OfferID;
					csdbutton2.dataObject = premiumOffers[i];
					string text = premiumOffers[i].Name;
					int rank;
					if (premiumOffers[i].OfferType == 1 && int.TryParse(text, out rank))
					{
						text = Rankings.getRankingName(rank, RemoteServices.Instance.UserAvatar.male);
					}
					CustomSelfDrawPanel.CSDLabel csdlabel6 = new CustomSelfDrawPanel.CSDLabel();
					csdlabel6.Size = new Size(csdbutton2.Width * 2 / 3, 38);
					csdlabel6.Position = new Point(csdbutton2.Width * 2 / 3 - csdlabel6.Width / 2, 20);
					csdlabel6.Text = text;
					csdlabel6.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					if (text.Length > 21)
					{
						csdlabel6.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
					}
					else
					{
						csdlabel6.Font = FontManager.GetFont("Arial", 24f, FontStyle.Bold);
					}
					csdlabel6.Color = global::ARGBColors.White;
					csdlabel6.DropShadowColor = global::ARGBColors.Black;
					csdbutton2.addControl(csdlabel6);
					string description = premiumOffers[i].Description;
					CustomSelfDrawPanel.CSDLabel csdlabel7 = new CustomSelfDrawPanel.CSDLabel();
					csdlabel7.Size = new Size(csdbutton2.Width * 2 / 3 - 50, 25);
					csdlabel7.Position = new Point(csdbutton2.Width * 2 / 3 - csdlabel7.Width / 2, csdlabel6.Rectangle.Bottom);
					csdlabel7.Text = description;
					csdlabel7.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					if (description.Length > 40)
					{
						csdlabel7.Font = FontManager.GetFont("Arial", 8f, FontStyle.Bold);
					}
					else
					{
						csdlabel7.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					}
					csdlabel7.Color = global::ARGBColors.WhiteSmoke;
					csdbutton2.addControl(csdlabel7);
					if (premiumOffers[i].Multiplier > 1)
					{
						CustomSelfDrawPanel.CSDLabel csdlabel8 = new CustomSelfDrawPanel.CSDLabel();
						csdlabel8.Size = new Size(csdbutton2.Width * 2 / 3, 25);
						csdlabel8.Position = new Point(csdbutton2.Width * 2 / 3 - csdlabel8.Width / 2, csdlabel7.Rectangle.Bottom);
						csdlabel8.Text = string.Format(" - x{0} {1}!", premiumOffers[i].Multiplier, SK.Text("TOUCH_Z_Value", "Value"));
						csdlabel8.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
						csdlabel8.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
						csdlabel8.Color = global::ARGBColors.White;
						csdlabel8.DropShadowColor = global::ARGBColors.Black;
						csdbutton2.addControl(csdlabel8);
					}
					TimeSpan timeSpan2 = dateTime2 - currentServerTime;
					CustomSelfDrawPanel.CSDLabel csdlabel9 = new CustomSelfDrawPanel.CSDLabel();
					csdlabel9.Size = new Size(csdbutton2.Width * 2 / 3, 25);
					csdlabel9.Position = new Point(csdbutton2.Width * 2 / 3 - csdlabel9.Width / 2, csdbutton2.Height * 3 / 4 - csdlabel9.Height / 2);
					csdlabel9.Text = VillageMap.createBuildTimeVariable((int)timeSpan2.TotalSeconds);
					csdlabel9.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					csdlabel9.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					csdlabel9.Color = global::ARGBColors.White;
					csdlabel9.DropShadowColor = global::ARGBColors.Black;
					csdbutton2.addControl(csdlabel9);
					csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showOfferContent));
					this.OfferListPanel.addControl(csdbutton2);
					num += csdbutton2.ImageNorm.Height;
				}
			}
			this.OfferListPanel.Position = new Point(0, 0);
			this.OfferListPanel.Size = new Size(this.InsetPanel.Width, num);
			this.OfferListPanel.ClipRect = new Rectangle(0, 0, this.InsetPanel.Width, this.InsetPanel.Height);
			if (num < this.OfferListPanel.ClipRect.Height)
			{
				num = this.OfferListPanel.ClipRect.Height;
			}
			this.OfferListScrollbar.Position = new Point(this.InsetPanel.Width - PremiumOffersPanel.BorderPadding - PremiumOffersPanel.BorderPadding / 2, this.InsetPanel.Y + PremiumOffersPanel.BorderPadding / 2);
			this.OfferListScrollbar.Size = new Size(PremiumOffersPanel.BorderPadding, this.InsetPanel.Height - PremiumOffersPanel.BorderPadding);
			this.OfferListScrollbar.Value = 0;
			this.OfferListScrollbar.StepSize = 200;
			this.OfferListScrollbar.Max = this.OfferListPanel.Height - this.OfferListPanel.ClipRect.Height;
			this.OfferListScrollbar.NumVisibleLines = this.OfferListPanel.ClipRect.Height;
			this.OfferListScrollbar.OffsetTL = new Point(1, 5);
			this.OfferListScrollbar.OffsetBR = new Point(0, -10);
			this.OfferListScrollbar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.OfferListScroll));
			this.OfferListScrollbar.Create(null, null, null, GFXLibrary.cardpanel_scroll_thumb_top, GFXLibrary.cardpanel_scroll_thumb_mid, GFXLibrary.cardpanel_scroll_thumb_botom);
			this.OfferListScrollbar.Visible = (num > this.OfferListPanel.ClipRect.Height);
			this.OfferListPanel.Visible = true;
			this.ContentPanel.Visible = false;
			this.ContentScrollbar.Visible = false;
			this.purchaseButton.Visible = false;
			this.backButton.Visible = false;
			this.labelCost.Visible = false;
			this.crownsIcon.Visible = false;
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x001C12FC File Offset: 0x001BF4FC
		private void showOfferContent()
		{
			if (CustomSelfDrawPanel.StaticClickedControl.dataObject == null)
			{
				return;
			}
			this.selectedOffer = (PremiumOfferData)CustomSelfDrawPanel.StaticClickedControl.dataObject;
			PremiumOfferContentData content = this.selectedOffer.Content;
			if (this.selectedOffer.HasBeenPurchased)
			{
				return;
			}
			this.purchaseButton.Enabled = true;
			this.backButton.Enabled = true;
			int rank;
			if (this.selectedOffer.OfferType == 1 && int.TryParse(this.selectedOffer.Name, out rank))
			{
				this.labelTitle.Text = Rankings.getRankingName(rank, RemoteServices.Instance.UserAvatar.male);
			}
			else
			{
				this.labelTitle.Text = this.selectedOffer.Name;
			}
			CustomSelfDrawPanel.CSDLabel csdlabel = this.labelTitle;
			csdlabel.Text += ": ";
			CustomSelfDrawPanel.CSDLabel csdlabel2 = this.labelTitle;
			csdlabel2.Text += this.selectedOffer.CrownsPrice.ToString();
			CustomSelfDrawPanel.CSDLabel csdlabel3 = this.labelTitle;
			csdlabel3.Text = csdlabel3.Text + " " + SK.Text("BuyCrownsPanel_Crowns", "Crowns");
			CustomSelfDrawPanel.CSDLabel csdlabel4 = this.labelTitle;
			csdlabel4.Text += " (";
			CustomSelfDrawPanel.CSDLabel csdlabel5 = this.labelTitle;
			string text = csdlabel5.Text;
			csdlabel5.Text = string.Concat(new string[]
			{
				text,
				SK.Text("LogoutPanel_Crowns_In_Treasury", "Crowns in your treasury"),
				" : ",
				GameEngine.Instance.World.ProfileCrowns.ToString(),
				")"
			});
			this.labelCost.Text = this.selectedOffer.CrownsPrice.ToString();
			this.ContentPanel.clearControls();
			this.offerYPos = 5;
			this.offerItemCount = 0;
			content.Cards.Sort(delegate(ContestPrizeCardDefinition c1, ContestPrizeCardDefinition c2)
			{
				if (c1 == null)
				{
					return -1;
				}
				if (c2 == null)
				{
					return 1;
				}
				if (c2.Amount != c1.Amount)
				{
					return c1.Amount.CompareTo(c2.Amount);
				}
				return c2.Name.CompareTo(c1.Name);
			});
			foreach (ContestPrizeCardDefinition contestPrizeCardDefinition in content.Cards)
			{
				CardTypes.CardDefinition cardDefinition = CardTypes.getCardDefinition(contestPrizeCardDefinition.ID);
				UICard uicard = BuyCardsPanel.makeUICard(cardDefinition, 0, GameEngine.Instance.World.getRank() + 1);
				uicard.ScaleAll(0.5);
				string text2 = CardTypes.getDescriptionFromCard(CardTypes.getCardTypeFromString(cardDefinition.name));
				text2 = text2 + " x" + contestPrizeCardDefinition.Amount.ToString();
				this.AddContentItem(uicard, text2);
			}
			foreach (ContestPrizePackDefinition contestPrizePackDefinition in content.CardPacks)
			{
				if (string.IsNullOrEmpty(contestPrizePackDefinition.Name))
				{
					CardTypes.CardOffer cardOffer = GameEngine.Instance.cardPackManager.GetCardOffer(contestPrizePackDefinition.OfferID);
					contestPrizePackDefinition.Name = SK.Text(GameEngine.Instance.cardPackManager.getCardPackLocalizedStringID(cardOffer.Category));
				}
			}
			content.CardPacks.Sort(delegate(ContestPrizePackDefinition c1, ContestPrizePackDefinition c2)
			{
				if (c1 == null)
				{
					return -1;
				}
				if (c2 == null)
				{
					return 1;
				}
				if (c2.Amount != c1.Amount)
				{
					return c1.Amount.CompareTo(c2.Amount);
				}
				return c2.Name.CompareTo(c1.Name);
			});
			foreach (ContestPrizePackDefinition contestPrizePackDefinition2 in content.CardPacks)
			{
				CardTypes.CardOffer cardOffer2 = GameEngine.Instance.cardPackManager.GetCardOffer(contestPrizePackDefinition2.OfferID);
				BaseImage cardPackOverImage = GameEngine.Instance.cardPackManager.getCardPackOverImage(cardOffer2.Category);
				string text3 = SK.Text(GameEngine.Instance.cardPackManager.getCardPackLocalizedStringID(cardOffer2.Category));
				text3 = text3 + " x" + contestPrizePackDefinition2.Amount.ToString();
				this.AddContentItem(cardPackOverImage, text3, 1.0);
			}
			for (int i = 0; i < content.Tokens.Count; i++)
			{
				ContestPrizeTokenDefinition contestPrizeTokenDefinition = content.Tokens[i];
				if (contestPrizeTokenDefinition.Amount > 0)
				{
					string text4 = "x " + contestPrizeTokenDefinition.Amount.ToString() + " " + SK.Text("CARDTYPE_GENERIC_PREMIUM", "Premium Token");
					this.AddContentItem(GFXLibrary.PremiumTokens[contestPrizeTokenDefinition.TokenType][0], text4, 1.0);
				}
			}
			for (int j = 0; j < content.Wheelspins.Length; j++)
			{
				int num = content.Wheelspins[j];
				if (num > 0)
				{
					string text5 = SK.Text("GENERIC_Wheel_Spins", "Wheel Spins");
					if (j < 5)
					{
						text5 = text5 + " (" + SK.Text("Event_Tier", "Tier");
						object obj = text5;
						text5 = string.Concat(new object[]
						{
							obj,
							" ",
							j + 1,
							") x",
							num
						});
					}
					switch (j)
					{
					case 0:
						this.AddContentItem(GFXLibrary.offer_wheel_spin1, text5, 1.0);
						break;
					case 1:
						this.AddContentItem(GFXLibrary.offer_wheel_spin2, text5, 1.0);
						break;
					case 2:
						this.AddContentItem(GFXLibrary.offer_wheel_spin3, text5, 1.0);
						break;
					case 3:
						this.AddContentItem(GFXLibrary.offer_wheel_spin4, text5, 1.0);
						break;
					case 4:
						this.AddContentItem(GFXLibrary.offer_wheel_spin5, text5, 1.0);
						break;
					default:
						this.AddContentItem(GFXLibrary.offer_wheel_spin, text5, 1.0);
						break;
					}
				}
			}
			if (content.Gold > 0)
			{
				string text6 = SK.Text("GENERIC_Gold", "Gold");
				text6 = text6 + " x" + content.Gold.ToString();
				this.AddContentItem(GFXLibrary.offer_gold, text6, 1.0);
			}
			if (content.Honour > 0)
			{
				string text7 = SK.Text("GENERIC_Honour", "Honour");
				text7 = text7 + " x" + content.Honour.ToString();
				this.AddContentItem(GFXLibrary.offer_honour, text7, 1.0);
			}
			if (content.Faith > 0)
			{
				string text8 = SK.Text("VillageMapPanel_Faith_Points", "Faith Points");
				text8 = text8 + " x" + content.Faith.ToString();
				this.AddContentItem(GFXLibrary.offer_faith, text8, 1.0);
			}
			if (content.Charges.Count > 0)
			{
				string text9 = SK.Text("TOUCH_Z_ShieldCharges", "Shield Charges");
				text9 = text9 + " x" + content.Charges.Count.ToString();
				this.AddContentItem(GFXLibrary.offer_shield, text9, 1.0);
			}
			this.ContentPanel.Position = new Point(0, 0);
			this.ContentPanel.Size = new Size(this.InsetPanel.Width, this.offerYPos);
			this.ContentPanel.ClipRect = new Rectangle(0, 0, this.InsetPanel.Width, this.InsetPanel.Height - 60);
			if (this.offerYPos < this.ContentPanel.ClipRect.Height)
			{
				this.offerYPos = this.ContentPanel.ClipRect.Height;
			}
			this.ContentScrollbar.Position = new Point(this.InsetPanel.Width - PremiumOffersPanel.BorderPadding - PremiumOffersPanel.BorderPadding / 2, this.InsetPanel.Y + PremiumOffersPanel.BorderPadding / 2);
			this.ContentScrollbar.Size = new Size(PremiumOffersPanel.BorderPadding, this.InsetPanel.Height - PremiumOffersPanel.BorderPadding * 2 - 60);
			this.ContentScrollbar.Value = 0;
			this.ContentScrollbar.StepSize = 200;
			this.ContentScrollbar.Max = this.ContentPanel.Height - this.ContentPanel.ClipRect.Height;
			this.ContentScrollbar.NumVisibleLines = this.ContentPanel.ClipRect.Height;
			this.ContentScrollbar.OffsetTL = new Point(1, 5);
			this.ContentScrollbar.OffsetBR = new Point(0, -10);
			this.ContentScrollbar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.ContentScroll));
			this.ContentScrollbar.Create(null, null, null, GFXLibrary.cardpanel_scroll_thumb_top, GFXLibrary.cardpanel_scroll_thumb_mid, GFXLibrary.cardpanel_scroll_thumb_botom);
			this.ContentScrollbar.Visible = (this.offerYPos > this.ContentPanel.ClipRect.Height);
			this.ContentPanel.Visible = true;
			this.purchaseButton.Visible = true;
			this.backButton.Visible = true;
			this.labelCost.Visible = true;
			this.crownsIcon.Visible = true;
			this.OfferListPanel.Visible = false;
			this.OfferListScrollbar.Visible = false;
			this.mainBackgroundImage.invalidate();
			this.trackViewedOffer();
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x001C1C70 File Offset: 0x001BFE70
		private void AddContentItem(BaseImage img, string text, double scale)
		{
			this.AddContentItem(new CustomSelfDrawPanel.CSDImage
			{
				Image = img,
				Scale = scale
			}, text);
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x001C1CA0 File Offset: 0x001BFEA0
		private void AddContentItem(CustomSelfDrawPanel.CSDControl ctrl, string text)
		{
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.card_offer_background;
			ctrl.Position = new Point(PremiumOffersPanel.BorderPadding * 2, csdimage.Height / 2 - ctrl.Height / 2);
			csdimage.addControl(ctrl);
			csdimage.addControl(new CustomSelfDrawPanel.CSDLabel
			{
				Size = new Size(csdimage.Width * 2 / 3, csdimage.Height),
				Position = new Point(csdimage.Width / 3, 0),
				Text = text,
				Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER,
				Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold),
				Color = global::ARGBColors.Black,
				DropShadowColor = global::ARGBColors.White
			});
			int num = Math.Max(csdimage.Height, ctrl.Height);
			csdimage.Position = new Point((this.offerItemCount % 2 == 0) ? PremiumOffersPanel.BorderPadding : (this.InsetPanel.Width - csdimage.Width - PremiumOffersPanel.BorderPadding * 3), this.offerYPos + num / 2 - csdimage.Height / 2);
			this.ContentPanel.addControl(csdimage);
			this.offerYPos += num - PremiumOffersPanel.BorderPadding * 2;
			this.offerItemCount++;
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x001C1DF0 File Offset: 0x001BFFF0
		private void confirmPurchaseOffer()
		{
			this.purchaseButton.Enabled = false;
			this.backButton.Enabled = false;
			if (!this.selectedOffer.HasBeenPurchased && !this.bAwaitingPurchase)
			{
				string text = SK.Text("TOUCH_Z_ConfirmationSpecialOffer", "Are you sure you want to buy this Special Offer?");
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					Environment.NewLine,
					Environment.NewLine,
					"(",
					this.selectedOffer.CrownsPrice,
					" "
				});
				text = text + SK.Text("BuyCrownsPanel_Crowns", "Crowns") + ")";
				DialogResult dialogResult = MyMessageBox.Show(text, SK.Text("BuyCardsPanel_Confirm_Purchase", "Confirm Purchase"), MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.purchaseOfferClick();
					return;
				}
				this.purchaseButton.Enabled = true;
				this.backButton.Enabled = true;
			}
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x001C1EDC File Offset: 0x001C00DC
		private void purchaseOfferClick()
		{
			if (!this.bAwaitingPurchase)
			{
				if (this.selectedOffer.CrownsPrice > GameEngine.Instance.World.ProfileCrowns)
				{
					this.purchaseButton.Enabled = true;
					this.backButton.Enabled = true;
					BuyCrownsPopup buyCrownsPopup = new BuyCrownsPopup();
					buyCrownsPopup.init(this.selectedOffer.CrownsPrice - GameEngine.Instance.World.ProfileCrowns, base.ParentForm);
					buyCrownsPopup.Show(base.ParentForm);
					return;
				}
				this.bAwaitingPurchase = true;
				XmlRpcPremiumOffersProvider xmlRpcPremiumOffersProvider = XmlRpcPremiumOffersProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				xmlRpcPremiumOffersProvider.PurchaseSpecialOffer(new XmlRpcPremiumOffersRequest
				{
					UserGUID = RemoteServices.Instance.UserGuidProfileSite,
					SessionGUID = RemoteServices.Instance.SessionGuidProfileSite,
					WorldID = new int?(RemoteServices.Instance.ProfileWorldID),
					OfferID = new int?(this.selectedOffer.OfferID)
				}, new PremiumOffersEndResponseDelegate(this.purchaseOfferCallback), null);
			}
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x001C1FE8 File Offset: 0x001C01E8
		private void purchaseOfferCallback(IPremiumOffersProvider sender, IPremiumOffersResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				this.selectedOffer.HasBeenPurchased = true;
				this.labelTitle.Text = SK.Text("ManageCandsPanel_Successful_Purchase", "Your purchase has been successfully completed");
				GameEngine.Instance.World.ProfileCrowns -= this.selectedOffer.CrownsPrice;
				GameEngine.Instance.World.addGold((double)this.selectedOffer.Content.Gold);
				GameEngine.Instance.World.addHonour((double)this.selectedOffer.Content.Honour);
				GameEngine.Instance.World.addFaithPoints((double)this.selectedOffer.Content.Faith);
				foreach (ContestPrizeCardDefinition contestPrizeCardDefinition in ((XmlRpcPremiumOffersResponse)response).CardsUniqueIDs)
				{
					string stringFromCard = CardTypes.getStringFromCard(contestPrizeCardDefinition.ID);
					foreach (int id in contestPrizeCardDefinition.UniqueIDs)
					{
						GameEngine.Instance.cardsManager.addProfileCard(id, stringFromCard);
					}
				}
				foreach (ContestPrizePackDefinition contestPrizePackDefinition in this.selectedOffer.Content.CardPacks)
				{
					GameEngine.Instance.cardPackManager.addCardPack(contestPrizePackDefinition.OfferID, contestPrizePackDefinition.Amount);
				}
				for (int i = 0; i < this.selectedOffer.Content.Wheelspins.Length; i++)
				{
					GameEngine.Instance.World.addTickets(i, this.selectedOffer.Content.Wheelspins[i]);
				}
				foreach (ContestPrizeTokenDefinition contestPrizeTokenDefinition in this.selectedOffer.Content.Tokens)
				{
					foreach (int userPremiumTokenID in contestPrizeTokenDefinition.UniqueIDs)
					{
						CardTypes.PremiumToken premiumToken = new CardTypes.PremiumToken();
						premiumToken.Reward = 0;
						premiumToken.Type = contestPrizeTokenDefinition.TokenType;
						premiumToken.UserPremiumTokenID = userPremiumTokenID;
						premiumToken.WorldID = RemoteServices.Instance.ProfileWorldID;
						GameEngine.Instance.premiumTokenManager.AddToken(premiumToken);
					}
				}
				this.purchaseButton.Enabled = false;
				this.purchaseButton.Visible = false;
				this.crownsIcon.Visible = false;
				this.labelCost.Visible = true;
				this.backButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.leavePanelClick));
			}
			else
			{
				this.purchaseButton.Enabled = true;
				MyMessageBox.Show(response.ErrorMessage, SK.Text("GENERIC_Error", "Error"));
				this.backButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showOfferList));
			}
			this.bAwaitingPurchase = false;
			this.backButton.Enabled = true;
			GameEngine.Instance.cardsManager.RetrievePremiumOffers();
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x001C2384 File Offset: 0x001C0584
		private void trackViewedOffer()
		{
			XmlRpcPremiumOffersProvider xmlRpcPremiumOffersProvider = XmlRpcPremiumOffersProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			xmlRpcPremiumOffersProvider.TrackViewedOffer(new XmlRpcPremiumOffersRequest
			{
				UserGUID = RemoteServices.Instance.UserGuidProfileSite,
				SessionGUID = RemoteServices.Instance.SessionGuidProfileSite,
				WorldID = new int?(RemoteServices.Instance.ProfileWorldID),
				OfferID = new int?(this.selectedOffer.OfferID)
			}, new PremiumOffersEndResponseDelegate(this.trackOfferViewedCallback), null);
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void trackOfferViewedCallback(IPremiumOffersProvider sender, IPremiumOffersResponse response)
		{
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x0001C0B0 File Offset: 0x0001A2B0
		private void leavePanelClick()
		{
			((PlayCardsWindow)base.ParentForm).SetCardSection(0);
			if (this.selectedOffer.Content.CardPacks.Count > 0)
			{
				((PlayCardsWindow)base.ParentForm).SwitchPanel(2);
			}
		}

		// Token: 0x04002D87 RID: 11655
		private IContainer components;

		// Token: 0x04002D88 RID: 11656
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D89 RID: 11657
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D8A RID: 11658
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D8B RID: 11659
		private CustomSelfDrawPanel.UICardsButtons cardsButtons;

		// Token: 0x04002D8C RID: 11660
		private int currentCardSection = -1;

		// Token: 0x04002D8D RID: 11661
		private static int BorderPadding = 16;

		// Token: 0x04002D8E RID: 11662
		private int ContentWidth;

		// Token: 0x04002D8F RID: 11663
		private int AvailablePanelWidth;

		// Token: 0x04002D90 RID: 11664
		private int InplayPanelWidth;

		// Token: 0x04002D91 RID: 11665
		private CustomSelfDrawPanel.CSDExtendingPanel InsetPanel;

		// Token: 0x04002D92 RID: 11666
		private CustomSelfDrawPanel.CSDImage OfferListPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D93 RID: 11667
		private CustomSelfDrawPanel.CSDVertScrollBar OfferListScrollbar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D94 RID: 11668
		private CustomSelfDrawPanel.CSDImage ContentPanel = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D95 RID: 11669
		private CustomSelfDrawPanel.CSDVertScrollBar ContentScrollbar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002D96 RID: 11670
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D97 RID: 11671
		private CustomSelfDrawPanel.CSDButton purchaseButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D98 RID: 11672
		private CustomSelfDrawPanel.CSDButton backButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002D99 RID: 11673
		private CustomSelfDrawPanel.CSDLabel labelCost = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002D9A RID: 11674
		private CustomSelfDrawPanel.CSDImage crownsIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002D9B RID: 11675
		private int offerYPos = 5;

		// Token: 0x04002D9C RID: 11676
		private int offerItemCount;

		// Token: 0x04002D9D RID: 11677
		private PremiumOfferData selectedOffer;

		// Token: 0x04002D9E RID: 11678
		private bool bAwaitingPurchase;

		// Token: 0x04002D9F RID: 11679
		[CompilerGenerated]
		private static Comparison<ContestPrizeCardDefinition> _003C_003E9__CachedAnonymousMethodDelegate4;

		// Token: 0x04002DA0 RID: 11680
		[CompilerGenerated]
		private static Comparison<ContestPrizePackDefinition> _003C_003E9__CachedAnonymousMethodDelegate5;
	}
}
