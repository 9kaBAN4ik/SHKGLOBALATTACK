using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C6 RID: 1222
	public class ViewAllCardsPanel : CustomSelfDrawPanel, CustomSelfDrawPanel.ICardsPanel
	{
		// Token: 0x06002D45 RID: 11589 RVA: 0x0002147C File Offset: 0x0001F67C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x0002149B File Offset: 0x0001F69B
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06002D47 RID: 11591 RVA: 0x0023F984 File Offset: 0x0023DB84
		public ViewAllCardsPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002D48 RID: 11592 RVA: 0x0023FA80 File Offset: 0x0023DC80
		public void init(int cardSection)
		{
			this.currentCardSection = cardSection;
			base.clearControls();
			this.mainBackgroundImage.Image = GFXLibrary.dummy;
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			this.mainBackgroundImage.Tile = true;
			base.addControl(this.mainBackgroundImage);
			this.ContentWidth = base.Width - 2 * ViewAllCardsPanel.BorderPadding;
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
			this.mainBackgroundImage.addControl(this.AvailablePanel);
			this.AvailablePanel.Create(GFXLibrary.cardpanel_panel_black_top_left, GFXLibrary.cardpanel_panel_black_top_mid, GFXLibrary.cardpanel_panel_black_top_right, GFXLibrary.cardpanel_panel_black_mid_left, GFXLibrary.cardpanel_panel_black_mid_mid, GFXLibrary.cardpanel_panel_black_mid_right, GFXLibrary.cardpanel_panel_black_bottom_left, GFXLibrary.cardpanel_panel_black_bottom_mid, GFXLibrary.cardpanel_panel_black_bottom_right);
			this.cardsInPlay.init(cardSection, 112, false, 14, 3, 0);
			this.cardsInPlay.Position = new Point(0, 5);
			this.AvailablePanel.addControl(this.cardsInPlay);
			int width = base.Width;
			int borderPadding = ViewAllCardsPanel.BorderPadding;
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
			this.labelTitle.Text = SK.Text("ViewAllCardsPanel_Cards_In_Play", "Cards In Play");
			this.labelTitle.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.labelTitle.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.labelTitle.Color = global::ARGBColors.Black;
			this.mainBackgroundImage.addControl(this.labelTitle);
			CustomSelfDrawPanel.UICardsButtons uicardsButtons = new CustomSelfDrawPanel.UICardsButtons((PlayCardsWindow)base.ParentForm);
			uicardsButtons.Position = new Point(808, 37);
			this.mainBackgroundImage.addControl(uicardsButtons);
			this.cardButtons = uicardsButtons;
			if (cardSection != 0)
			{
				CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
				csdbutton.ImageNorm = GFXLibrary.button_cards_all_normal;
				csdbutton.ImageOver = GFXLibrary.button_cards_all_over;
				csdbutton.ImageClick = GFXLibrary.button_cards_all_over;
				csdbutton.Position = new Point(750, 0);
				csdbutton.Text.Text = SK.Text("PlayCardsPanel_All_Your_Cards", "All Your Cards");
				csdbutton.TextYOffset = -3;
				csdbutton.Text.Color = global::ARGBColors.Black;
				csdbutton.Text.Size = new Size(csdbutton.Size.Width - 45, csdbutton.Size.Height);
				csdbutton.Text.Position = new Point(45, 0);
				csdbutton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showAllCardsClick), "PlayCardsPanel_show_all_cards");
				this.mainBackgroundImage.addControl(csdbutton);
			}
			CustomSelfDrawPanel.CSDButton csdbutton2 = new CustomSelfDrawPanel.CSDButton();
			csdbutton2.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			csdbutton2.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			csdbutton2.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			csdbutton2.Position = new Point(580, 515);
			csdbutton2.Text.Text = SK.Text("PlayCardsPanel_Return", "Back To Play Cards");
			csdbutton2.TextYOffset = -2;
			csdbutton2.Text.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "it" || Program.mySettings.LanguageIdent == "tr")
			{
				csdbutton2.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			}
			else
			{
				csdbutton2.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			}
			csdbutton2.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.returnClicked), "PlayCardsPanel_Back_To_PlayCards");
			this.AvailablePanel.addControl(csdbutton2);
			CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
			csdlabel.Position = new Point(27, 563);
			csdlabel.Size = new Size(935, 64);
			csdlabel.Text = SK.Text("ViewAllCardsPanel_Cancel", "Click on a Card Circle to cancel that card.");
			csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			csdlabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			csdlabel.Color = global::ARGBColors.White;
			this.mainBackgroundImage.addControl(csdlabel);
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06002D49 RID: 11593 RVA: 0x000214AF File Offset: 0x0001F6AF
		public void update()
		{
			this.cardsInPlay.update();
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x0000BD89 File Offset: 0x00009F89
		private void closeClick()
		{
			InterfaceMgr.Instance.closePlayCardsWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06002D4B RID: 11595 RVA: 0x000214BD File Offset: 0x0001F6BD
		private void showAllCardsClick()
		{
			((PlayCardsWindow)base.ParentForm).SetCardSection(0);
			this.init(0);
			base.Invalidate();
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x000214DD File Offset: 0x0001F6DD
		private void returnClicked()
		{
			((PlayCardsWindow)base.ParentForm).SwitchPanel(1);
		}

		// Token: 0x0400383B RID: 14395
		private IContainer components;

		// Token: 0x0400383C RID: 14396
		private string strOrderNow = SK.Text("BuyCrownsPanel_Order_Now", "Order Now");

		// Token: 0x0400383D RID: 14397
		private string strCrowns = SK.Text("BuyCrownsPanel_Crowns", "Crowns");

		// Token: 0x0400383E RID: 14398
		private CustomSelfDrawPanel.UICardsButtons cardButtons;

		// Token: 0x0400383F RID: 14399
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003840 RID: 14400
		private CustomSelfDrawPanel.CSDLabel labelTitle = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003841 RID: 14401
		private CustomSelfDrawPanel.CSDLabel labelBottom = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003842 RID: 14402
		private CustomSelfDrawPanel.CSDLabel labelFeedback = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003843 RID: 14403
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003844 RID: 14404
		private CustomSelfDrawPanel.CSDImage buybutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003845 RID: 14405
		private CustomSelfDrawPanel.CSDImage managebutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003846 RID: 14406
		private CustomSelfDrawPanel.CSDImage premiumbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003847 RID: 14407
		private CustomSelfDrawPanel.CSDImage playbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003848 RID: 14408
		private CustomSelfDrawPanel.CSDImage crownsbutton = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003849 RID: 14409
		private CustomSelfDrawPanel.CSDFill greyout = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400384A RID: 14410
		private CustomSelfDrawPanel.CSDImage closeImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400384B RID: 14411
		private int currentCardSection = -1;

		// Token: 0x0400384C RID: 14412
		private static int BorderPadding = 16;

		// Token: 0x0400384D RID: 14413
		private int ContentWidth;

		// Token: 0x0400384E RID: 14414
		private int AvailablePanelWidth;

		// Token: 0x0400384F RID: 14415
		private CustomSelfDrawPanel.CSDExtendingPanel AvailablePanel;

		// Token: 0x04003850 RID: 14416
		private CustomSelfDrawPanel.CSDImage AvailablePanelContent = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003851 RID: 14417
		private CardBarGDI cardsInPlay = new CardBarGDI();

		// Token: 0x04003852 RID: 14418
		private CustomSelfDrawPanel.CSDVertScrollBar scrollbarAvailable = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04003853 RID: 14419
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate5;
	}
}
