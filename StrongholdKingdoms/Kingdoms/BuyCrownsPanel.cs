using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x020000F0 RID: 240
	public class BuyCrownsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x0000BF88 File Offset: 0x0000A188
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0000BFA7 File Offset: 0x0000A1A7
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x000951DC File Offset: 0x000933DC
		public BuyCrownsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x000952F8 File Offset: 0x000934F8
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * BuyCrownsPanel.BorderPadding;
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
			this.AvailablePanel.Size = new Size(this.AvailablePanelWidth, 550);
			this.AvailablePanel.Position = new Point(8, base.Height - 8 - 550);
			this.AvailablePanel.Alpha = 0.8f;
			int width = base.Width;
			int borderPadding = BuyCrownsPanel.BorderPadding;
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
			this.closeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			this.closeImage.Position = new Point(base.Width - 14 - 17, 10);
			this.mainBackgroundImage.addControl(this.closeImage);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 38, new Point(base.Width - 1 - 17 - 50 + 3, 5), true);
			CustomSelfDrawPanel.CSDFill csdfill = new CustomSelfDrawPanel.CSDFill();
			csdfill.FillColor = Color.FromArgb(255, 130, 129, 126);
			csdfill.Size = new Size(base.Width - 10, 1);
			csdfill.Position = new Point(5, 34);
			this.mainBackgroundImage.addControl(csdfill);
			this.greyout.FillColor = Color.FromArgb(215, 25, 25, 25);
			this.greyout.Size = new Size(this.mainBackgroundImage.Width, this.AvailablePanel.Y + this.AvailablePanel.Height);
			this.greyout.Position = new Point(0, 0);
			this.greyout.setClickDelegate(delegate()
			{
			});
			CustomSelfDrawPanel.CSDImage closeGrey = new CustomSelfDrawPanel.CSDImage();
			closeGrey.Image = GFXLibrary.cardpanel_button_close_normal;
			closeGrey.Size = this.closeImage.Image.Size;
			closeGrey.setMouseOverDelegate(delegate
			{
				closeGrey.Image = GFXLibrary.cardpanel_button_close_over;
			}, delegate
			{
				closeGrey.Image = GFXLibrary.cardpanel_button_close_normal;
			});
			closeGrey.Position = new Point(base.Width - 14 - 17, 10);
			this.greyout.addControl(closeGrey);
			this.labelTitle.Position = new Point(27, 8);
			this.labelTitle.Size = new Size(935, 64);
			this.labelTitle.Text = SK.Text("BuyCrownsPanel_Buy_Crowns", "Buy Crowns");
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			CustomSelfDrawPanel.UICardsButtons uicardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			uicardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(uicardsButtons);
			this.cardButtons = uicardsButtons;
			List<ProductInfo> list = new List<ProductInfo>();
			if (Program.steamActive)
			{
				this.PlayerCountry = "UK";
				this.PlayerCurrency = "GBP";
				this.PlayerLanguage = MySettings.load().LanguageIdent;
				XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthResponse xmlRpcAuthResponse = xmlRpcAuthProvider.SteamGetProductList(new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", null, null, null, null)
				{
					SteamID = Program.steamID,
					SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""),
					Culture = this.PlayerLanguage,
					Currency = this.PlayerCurrency,
					Country = this.PlayerCountry
				}, null, this, 15000);
				list = xmlRpcAuthResponse.ProductList;
			}
			else if (Program.aeriaInstall)
			{
				XmlRpcAuthProvider xmlRpcAuthProvider2 = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthRequest req = new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", null, null, null, null);
				XmlRpcAuthResponse xmlRpcAuthResponse2 = null;
				this.storedAeriaPoints = xmlRpcAuthProvider2.AeriaGetBalance(req, null, this, 15000, ref xmlRpcAuthResponse2);
				list = xmlRpcAuthResponse2.ProductList;
				this.buyAPButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.buyAPButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.buyAPButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.buyAPButton.Position = new Point(317, 73);
				this.buyAPButton.Text.Text = this.storedAeriaPoints.ToString();
				this.buyAPButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
				this.buyAPButton.Text.Size = new Size(this.buyAPButton.Width / 2 - 3, this.buyAPButton.Height);
				this.buyAPButton.TextYOffset = -2;
				this.buyAPButton.Text.Color = global::ARGBColors.Black;
				this.buyAPButton.ImageIcon = GFXLibrary.aeriaPoints;
				this.buyAPButton.ImageIconPosition = new Point(this.buyAPButton.Width / 2 + 3, 1);
				this.buyAPButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.buyAPButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.purchaseAP));
				this.buyAPButton.CustomTooltipID = 10350;
				this.mainBackgroundImage.addControl(this.buyAPButton);
			}
			int num = 66;
			int num2 = 94;
			int num3 = -1;
			if (Program.aeriaInstall)
			{
				num = 132;
			}
			NumberFormatInfo nfi = GameEngine.NFI;
			NumberFormatInfo nfi_D = GameEngine.NFI_D2;
			foreach (ProductInfo productInfo in list)
			{
				num3++;
				int num4 = num2;
				if (Program.steamActive)
				{
					if (num3 > 3)
					{
						if (num3 == 4)
						{
							num = 132;
						}
						num4 += 350;
					}
				}
				else if (Program.aeriaInstall && num3 > 2)
				{
					if (num3 == 3)
					{
						num = 132;
					}
					num4 += 350;
				}
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDLabel csdlabel2 = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDLabel csdlabel3 = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDLabel csdlabel4 = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDLabel csdlabel5 = new CustomSelfDrawPanel.CSDLabel();
				CustomSelfDrawPanel.CSDImage csdimage2 = new CustomSelfDrawPanel.CSDImage();
				CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();
				CustomSelfDrawPanel.CSDImage orderbutton = new CustomSelfDrawPanel.CSDImage();
				crownsbutton.Image = GFXLibrary.cardpanel_payment_button_crowns_normal;
				crownsbutton.Position = new Point(num4, num);
				crownsbutton.Height = crownsbutton.Image.Height;
				crownsbutton.Width = crownsbutton.Image.Width;
				crownsbutton.setMouseOverDelegate(delegate
				{
					crownsbutton.Image = GFXLibrary.cardpanel_payment_button_crowns_over;
				}, delegate
				{
					crownsbutton.Image = GFXLibrary.cardpanel_payment_button_crowns_normal;
				});
				crownsbutton.Tag = productInfo;
				crownsbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				this.mainBackgroundImage.addControl(crownsbutton);
				num4 += crownsbutton.Width + 32;
				orderbutton.Image = GFXLibrary.cardpanel_payment_button_greywhite_normal;
				orderbutton.Position = new Point(num4, num + 18 + 3);
				orderbutton.Height = orderbutton.Image.Height;
				orderbutton.Width = orderbutton.Image.Width;
				orderbutton.setMouseOverDelegate(delegate
				{
					orderbutton.Image = GFXLibrary.cardpanel_payment_button_greywhite_over;
				}, delegate
				{
					orderbutton.Image = GFXLibrary.cardpanel_payment_button_greywhite_normal;
				});
				orderbutton.Tag = productInfo;
				orderbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				csdlabel5.Text = this.strOrderNow;
				csdlabel5.Position = new Point(0, 0);
				csdlabel5.Width = orderbutton.Width;
				csdlabel5.Height = orderbutton.Height;
				csdlabel5.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				csdlabel5.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				orderbutton.addControl(csdlabel5);
				csdlabel5.Tag = productInfo;
				csdlabel5.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				int num5 = 14;
				int num6 = 0;
				if (Program.mySettings.LanguageIdent == "fr")
				{
					num5 = 13;
					num6 = -5;
				}
				csdlabel.Text = productInfo.Strikethrough.ToString();
				csdlabel.Position = new Point(116 + num6, 21);
				csdlabel.Width = 300;
				csdlabel.Height = 24;
				csdlabel.Font = FontManager.GetFont("Arial", (float)num5, FontStyle.Strikeout);
				csdlabel.Color = global::ARGBColors.Black;
				crownsbutton.addControl(csdlabel);
				csdlabel.Tag = productInfo;
				csdlabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				csdlabel.Size = csdlabel.TextSizeX;
				csdlabel2.Text = productInfo.Crowns.ToString();
				csdlabel2.Position = new Point(csdlabel.X + csdlabel.Width, csdlabel.Y);
				csdlabel2.Font = FontManager.GetFont("Arial", (float)num5, FontStyle.Bold);
				csdlabel2.Color = global::ARGBColors.Purple;
				csdlabel2.Width = 300;
				csdlabel2.Height = 24;
				crownsbutton.addControl(csdlabel2);
				csdlabel2.Tag = productInfo;
				csdlabel2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				csdlabel2.Size = csdlabel2.TextSizeX;
				csdlabel3.Text = this.strCrowns;
				csdlabel3.Position = new Point(csdlabel2.X + csdlabel2.Width + num6, csdlabel2.Y);
				csdlabel3.Font = FontManager.GetFont("Arial", (float)num5, FontStyle.Bold);
				csdlabel3.Color = global::ARGBColors.Black;
				csdlabel3.Size = new Size(300, 24);
				crownsbutton.addControl(csdlabel3);
				csdlabel3.Tag = productInfo;
				csdlabel3.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				csdlabel3.Size = csdlabel3.TextSizeX;
				if (Program.aeriaInstall)
				{
					csdlabel4.Text = " " + ((int)productInfo.Cost).ToString("F", nfi);
				}
				else
				{
					csdlabel4.Text = productInfo.Currency + " " + productInfo.Cost.ToString("F", nfi_D);
				}
				csdlabel4.Position = new Point(csdlabel.X, csdlabel.Y + csdlabel.Height + 4);
				csdlabel4.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				csdlabel4.Color = global::ARGBColors.Black;
				csdlabel4.Size = new Size(300, 24);
				crownsbutton.addControl(csdlabel4);
				csdlabel4.Tag = productInfo;
				csdlabel4.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.productclick));
				csdlabel4.Size = csdlabel4.TextSizeX;
				if (Program.aeriaInstall)
				{
					csdimage2.Image = GFXLibrary.aeriaPoints;
					csdlabel4.Position = new Point(csdlabel.X + 20, csdlabel.Y + csdlabel.Height);
					csdimage2.Position = new Point(csdlabel.X, csdlabel.Y + csdlabel.Height + 4 - 2 - 3);
					csdimage2.Tag = productInfo;
					crownsbutton.addControl(csdimage2);
				}
				num += crownsbutton.Height + 40;
			}
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x000961B0 File Offset: 0x000943B0
		private void productclick()
		{
			if (Program.steamActive)
			{
				ProductInfo productInfo = (ProductInfo)this.ClickedControl.Tag;
				XmlRpcAuthProvider xmlRpcAuthProvider = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthRequest xmlRpcAuthRequest = new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), null, null, null);
				xmlRpcAuthRequest.Culture = this.PlayerLanguage;
				xmlRpcAuthRequest.Currency = this.PlayerCurrency;
				xmlRpcAuthRequest.Country = this.PlayerCountry;
				xmlRpcAuthRequest.SteamID = Program.steamID;
				xmlRpcAuthRequest.ItemID = productInfo.ProductID.ToString();
				InterfaceMgr.Instance.closeAllPopups();
				XmlRpcAuthResponse xmlRpcAuthResponse = xmlRpcAuthProvider.SteamPaymentInit(xmlRpcAuthRequest, null, this, 15000);
				if (!(xmlRpcAuthResponse.SuccessCode != 0))
				{
					MessageBox.Show(xmlRpcAuthResponse.Message);
					return;
				}
				Program.forceSteamDXOverlay();
				return;
			}
			else
			{
				if (!Program.aeriaInstall)
				{
					return;
				}
				ProductInfo productInfo2 = (ProductInfo)this.ClickedControl.Tag;
				string txtMessage = string.Concat(new string[]
				{
					SK.Text("EmptyVillagePanel_Buy_Village", "Purchase"),
					Environment.NewLine,
					Environment.NewLine,
					productInfo2.Crowns.ToString(),
					" ",
					SK.Text("BuyCrownsPanel_Crowns", "Crowns"),
					Environment.NewLine,
					productInfo2.Cost.ToString(),
					" Aeria Points"
				});
				if (MyMessageBox.Show(txtMessage, SK.Text("ManageCandsPanel_Confirm_Purchase_Crowns", "Confirm Crowns Purchase"), MessageBoxButtons.YesNo) != DialogResult.Yes)
				{
					return;
				}
				int crowns = productInfo2.Crowns;
				XmlRpcAuthProvider xmlRpcAuthProvider2 = XmlRpcAuthProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfilePath);
				XmlRpcAuthResponse xmlRpcAuthResponse2 = xmlRpcAuthProvider2.AeriaMakePayment(new XmlRpcAuthRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""), "", "", "", RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""), null, null, null)
				{
					ItemID = crowns.ToString(),
					OrderID = productInfo2.Cost.ToString()
				}, null, this, 15000);
				if (!(xmlRpcAuthResponse2.SuccessCode != 0))
				{
					if (xmlRpcAuthResponse2.Message[0] != '2' || xmlRpcAuthResponse2.Message[1] != '0' || xmlRpcAuthResponse2.Message[2] != '5')
					{
						MessageBox.Show(xmlRpcAuthResponse2.Message);
						return;
					}
					if (MyMessageBox.Show(SK.Text("ManageCandsPanel_Purchase_Failed_Buy_Points", "You don't have enough Aeria Points for this purchase. Do you wish to purchase Aeria Points now?"), SK.Text("ManageCandsPanel_Purchase_Failed", "Purchase Failed"), MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						this.purchaseAP();
						return;
					}
				}
				else
				{
					GameEngine.Instance.World.ProfileCrowns += productInfo2.Crowns;
					MyMessageBox.Show(SK.Text("ManageCandsPanel_Successful_Purchase", "Your purchase has been successfully completed"), SK.Text("ManageCandsPanel_Crowns_Purchased", "Crowns Purchased"));
					this.closeClick();
				}
				return;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x00096520 File Offset: 0x00094720
		public void purchaseAP()
		{
			new Process
			{
				StartInfo = 
				{
					FileName = "https://billing.aeriagames.com/"
				}
			}.Start();
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0000BD89 File Offset: 0x00009F89
		public void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x0400097D RID: 2429
		private IContainer components;

		// Token: 0x0400097E RID: 2430
		private string strOrderNow = SK.Text("BuyCrownsPanel_Order_Now", "Order Now");

		// Token: 0x0400097F RID: 2431
		private string strCrowns = SK.Text("BuyCrownsPanel_Crowns", "Crowns");

		// Token: 0x04000980 RID: 2432
		private string PlayerCountry;

		// Token: 0x04000981 RID: 2433
		private string PlayerCurrency;

		// Token: 0x04000982 RID: 2434
		private string PlayerLanguage;

		// Token: 0x04000983 RID: 2435
		private int storedAeriaPoints;

		// Token: 0x04000984 RID: 2436
		private CustomSelfDrawPanel.UICardsButtons cardButtons;

		// Token: 0x04000985 RID: 2437
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000986 RID: 2438
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000987 RID: 2439
		private CustomSelfDrawPanel.CSDLabel labelBottom = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000988 RID: 2440
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000989 RID: 2441
		private CustomSelfDrawPanel.CSDLabel labelPoints = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400098A RID: 2442
		private CustomSelfDrawPanel.CSDImage APImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400098B RID: 2443
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400098C RID: 2444
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400098D RID: 2445
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400098E RID: 2446
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400098F RID: 2447
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000990 RID: 2448
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000991 RID: 2449
		private CustomSelfDrawPanel.CSDFill greyout = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04000992 RID: 2450
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000993 RID: 2451
		private CustomSelfDrawPanel.CSDButton buyAPButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000994 RID: 2452
		private Dictionary<string, UICardPack> packControls = new Dictionary<string, UICardPack>();

		// Token: 0x04000995 RID: 2453
		private int currentCardSection = -1;

		// Token: 0x04000996 RID: 2454
		private static int BorderPadding = 16;

		// Token: 0x04000997 RID: 2455
		private int ContentWidth;

		// Token: 0x04000998 RID: 2456
		private int AvailablePanelWidth;

		// Token: 0x04000999 RID: 2457
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x0400099A RID: 2458
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400099B RID: 2459
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400099C RID: 2460
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate9;
	}
}
