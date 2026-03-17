using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000139 RID: 313
	public class ConfirmPlayCardPanel : CustomSelfDrawPanel
	{
		// Token: 0x06000B93 RID: 2963 RVA: 0x0000E944 File Offset: 0x0000CB44
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x0000E963 File Offset: 0x0000CB63
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x000E54CC File Offset: 0x000E36CC
		public ConfirmPlayCardPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x000E554C File Offset: 0x000E374C
		public void init(CardTypes.CardDefinition def, ConfirmPlayCardPanel.CardClickPlayDelegate callback)
		{
			this.m_callback = callback;
			base.clearControls();
			this.background.Size = base.Size;
			this.background.Position = new Point(0, 0);
			base.addControl(this.background);
			this.background.Create(GFXLibrary.cardpanel_grey_9slice_left_top, GFXLibrary.cardpanel_grey_9slice_middle_top, GFXLibrary.cardpanel_grey_9slice_right_top, GFXLibrary.cardpanel_grey_9slice_left_middle, GFXLibrary.cardpanel_grey_9slice_middle_middle, GFXLibrary.cardpanel_grey_9slice_right_middle, GFXLibrary.cardpanel_grey_9slice_left_bottom, GFXLibrary.cardpanel_grey_9slice_middle_bottom, GFXLibrary.cardpanel_grey_9slice_right_bottom);
			this.topLeftImage.Image = GFXLibrary.cardpanel_grey_9slice_gradation_top_left;
			this.topLeftImage.Position = new Point(0, 0);
			this.background.addControl(this.topLeftImage);
			this.bottomRightImage.Image = GFXLibrary.cardpanel_grey_9slice_gradation_bottom;
			this.bottomRightImage.Position = new Point(this.background.Width - this.bottomRightImage.Image.Width, this.background.Height - this.bottomRightImage.Image.Height);
			this.background.addControl(this.bottomRightImage);
			UICard uicard = BuyCardsPanel.makeUICard(def, RemoteServices.Instance.UserID, 10000);
			GFXLibrary.Instance.closeBigCardsLoader();
			uicard.Position = new Point(117, 50);
			this.background.addControl(uicard);
			this.confirmLabel.Text = SK.Text("ConfirmPlayCardPanel_Are_You_Sure", "Are you sure you want to play this card?");
			this.confirmLabel.Color = global::ARGBColors.Black;
			this.confirmLabel.Position = new Point(0, 10);
			this.confirmLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.confirmLabel.Size = new Size(this.background.Width, 50);
			this.confirmLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.confirmLabel);
			this.confirmButton.Text.Text = SK.Text("ConfirmPlayCardPanel_Play_Card", "Play Card");
			this.confirmButton.TextYOffset = -2;
			this.confirmButton.Text.Color = global::ARGBColors.Black;
			this.confirmButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.confirmButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.confirmButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.confirmButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.confirmButton.Position = new Point(230, 310);
			this.confirmButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playCard), "ConfirmPlayCardPanel_confirm_play_card");
			this.background.addControl(this.confirmButton);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.TextYOffset = -2;
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.cancelButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.cancelButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.cancelButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.cancelButton.Position = new Point(30, 310);
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "ConfirmPlayCardPanel_cancel");
			this.background.addControl(this.cancelButton);
			this.confirmCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.confirmCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.confirmCheck.Position = new Point(20, 360);
			this.confirmCheck.Checked = true;
			this.confirmCheck.CBLabel.Text = SK.Text("ConfirmPlayCardPanel_Always", "Always confirm playing cards?");
			this.confirmCheck.CBLabel.Color = global::ARGBColors.Black;
			this.confirmCheck.CBLabel.Position = new Point(20, -1);
			this.confirmCheck.CBLabel.Size = new Size(360, 35);
			this.confirmCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.background.addControl(this.confirmCheck);
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x000E5A20 File Offset: 0x000E3C20
		private void closeClick()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.ConfirmPlayCard = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.closeConfirmPlayCardPopup();
			Form cardWindow = InterfaceMgr.Instance.getCardWindow();
			if (cardWindow != null)
			{
				cardWindow.TopMost = true;
				cardWindow.TopMost = false;
			}
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x000E5A78 File Offset: 0x000E3C78
		private void playCard()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.ConfirmPlayCard = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.closeConfirmPlayCardPopup();
			Form cardWindow = InterfaceMgr.Instance.getCardWindow();
			if (cardWindow != null)
			{
				cardWindow.TopMost = true;
				cardWindow.TopMost = false;
			}
			if (this.m_callback != null)
			{
				this.m_callback(false, false);
			}
		}

		// Token: 0x04000FA5 RID: 4005
		private IContainer components;

		// Token: 0x04000FA6 RID: 4006
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FA7 RID: 4007
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000FA8 RID: 4008
		private CustomSelfDrawPanel.CSDLabel confirmLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FA9 RID: 4009
		private CustomSelfDrawPanel.CSDButton confirmButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FAA RID: 4010
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FAB RID: 4011
		private CustomSelfDrawPanel.CSDCheckBox confirmCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04000FAC RID: 4012
		private CustomSelfDrawPanel.CSDImage topLeftImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FAD RID: 4013
		private CustomSelfDrawPanel.CSDImage bottomRightImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FAE RID: 4014
		private ConfirmPlayCardPanel.CardClickPlayDelegate m_callback;

		// Token: 0x0200013A RID: 314
		// (Invoke) Token: 0x06000B9B RID: 2971
		public delegate void CardClickPlayDelegate(bool fromClick, bool fromValidate);
	}
}
