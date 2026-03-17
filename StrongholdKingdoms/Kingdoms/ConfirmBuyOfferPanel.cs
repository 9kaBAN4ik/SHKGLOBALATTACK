using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000133 RID: 307
	public class ConfirmBuyOfferPanel : CustomSelfDrawPanel
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0000E755 File Offset: 0x0000C955
		public int Multiple
		{
			get
			{
				return (int)this.numMultiple.Value;
			}
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x000E3A90 File Offset: 0x000E1C90
		public ConfirmBuyOfferPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x000E3B18 File Offset: 0x000E1D18
		public void init(CardTypes.CardOffer offer, string name, ConfirmBuyOfferPanel.CardClickPlayDelegate callback, ConfirmBuyOfferPopup parent)
		{
			this.m_parent = parent;
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
			int profileCrowns = GameEngine.Instance.World.ProfileCrowns;
			int crownCost = offer.CrownCost;
			int value = (int)Math.Floor((double)profileCrowns / crownCost);
			this.numMultiple = new NumericUpDown();
			base.Controls.Add(this.numMultiple);
			this.numMultiple.Minimum = 1m;
			this.numMultiple.Maximum = value;
			this.numMultiple.Increment = 1m;
			this.numMultiple.Left = base.Width / 2 - this.numMultiple.Width / 2;
			this.numMultiple.Top = base.Height / 2 - this.numMultiple.Height / 2;
			this.numMultiple.DecimalPlaces = 0;
			this.numMultiple.KeyUp += this.numMultiple_KeyUp;
			this.confirmLabel.Color = global::ARGBColors.Black;
			this.confirmLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.confirmLabel.Position = new Point(20, 10);
			this.confirmLabel.Size = new Size(this.background.Width - 40, 80);
			this.confirmLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.confirmLabel.Text = SK.Text("ConfirmBuyOffer_PleaseConfirm", "Please Confirm how many of this type of card pack you want to buy.");
			this.background.addControl(this.confirmLabel);
			this.packTypeLabel.Text = name;
			this.packTypeLabel.Position = new Point(20, 100);
			this.packTypeLabel.Color = global::ARGBColors.Black;
			this.packTypeLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.packTypeLabel.Size = new Size(this.background.Width - 40, 80);
			this.packTypeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.packTypeLabel);
			this.confirmButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.confirmButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.confirmButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.confirmButton.Position = new Point(230, 190);
			this.confirmButton.TextYOffset = -2;
			this.confirmButton.Text.Color = global::ARGBColors.Black;
			if (Program.mySettings.LanguageIdent == "pl")
			{
				this.confirmButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			else
			{
				this.confirmButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			}
			this.confirmButton.Text.Text = SK.Text("ConfirmBuyOffer_BuyOffer", "Buy Offer");
			this.confirmButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playCard), "ConfirmBuyOfferPanel_confirm_buy_pack");
			this.background.addControl(this.confirmButton);
			this.cancelButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.cancelButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.cancelButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.cancelButton.Position = new Point(30, 190);
			this.cancelButton.TextYOffset = -2;
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "ConfirmBuyOfferPanel_cancel");
			this.background.addControl(this.cancelButton);
			this.confirmCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.confirmCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.confirmCheck.Position = new Point(20, 240);
			this.confirmCheck.Checked = true;
			this.confirmCheck.CBLabel.Text = SK.Text("ConfirmBuyOffer_AlwaysAsk", "Always ask to buy multiple card packs.");
			this.confirmCheck.CBLabel.Color = global::ARGBColors.Black;
			this.confirmCheck.CBLabel.Position = new Point(20, -1);
			this.confirmCheck.CBLabel.Size = new Size(360, 35);
			this.confirmCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.background.addControl(this.confirmCheck);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x000E4158 File Offset: 0x000E2358
		private void numMultiple_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (int.Parse(this.numMultiple.Text) < this.numMultiple.Minimum || int.Parse(this.numMultiple.Text) > this.numMultiple.Maximum)
				{
					this.numMultiple.Text = "";
					this.numMultiple.Value = this.numMultiple.Minimum;
				}
			}
			catch (Exception)
			{
				this.numMultiple.Text = "";
				this.numMultiple.Value = this.numMultiple.Minimum;
			}
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x000E4214 File Offset: 0x000E2414
		private void closeClick()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.BuyMultipleCardPacks = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.closeConfirmBuyOfferPopup();
			Form cardWindow = InterfaceMgr.Instance.getCardWindow();
			if (cardWindow != null)
			{
				cardWindow.TopMost = true;
				cardWindow.TopMost = false;
			}
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x000E426C File Offset: 0x000E246C
		private void playCard()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.BuyMultipleCardPacks = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.BuyOfferMultiple = (int)this.numMultiple.Value;
			InterfaceMgr.Instance.closeConfirmBuyOfferPopup();
			Form cardWindow = InterfaceMgr.Instance.getCardWindow();
			if (cardWindow != null)
			{
				cardWindow.TopMost = true;
				cardWindow.TopMost = false;
			}
			if (this.m_callback != null)
			{
				this.m_callback(false);
			}
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x000E42F0 File Offset: 0x000E24F0
		private void clickPlus()
		{
			NumericUpDown numericUpDown = this.numMultiple;
			decimal value = ++numericUpDown.Value;
			numericUpDown.Value = value;
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x000E4318 File Offset: 0x000E2518
		private void clickMinus()
		{
			NumericUpDown numericUpDown = this.numMultiple;
			decimal value = --numericUpDown.Value;
			numericUpDown.Value = value;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0000E767 File Offset: 0x0000C967
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0000E786 File Offset: 0x0000C986
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04000F7E RID: 3966
		private NumericUpDown numMultiple;

		// Token: 0x04000F7F RID: 3967
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F80 RID: 3968
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000F81 RID: 3969
		private CustomSelfDrawPanel.CSDLabel confirmLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000F82 RID: 3970
		private CustomSelfDrawPanel.CSDButton confirmButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F83 RID: 3971
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F84 RID: 3972
		private CustomSelfDrawPanel.CSDCheckBox confirmCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04000F85 RID: 3973
		private CustomSelfDrawPanel.CSDLabel packTypeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000F86 RID: 3974
		private CustomSelfDrawPanel.CSDImage topLeftImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000F87 RID: 3975
		private CustomSelfDrawPanel.CSDImage bottomRightImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000F88 RID: 3976
		private ConfirmBuyOfferPanel.CardClickPlayDelegate m_callback;

		// Token: 0x04000F89 RID: 3977
		private ConfirmBuyOfferPopup m_parent;

		// Token: 0x04000F8A RID: 3978
		private IContainer components;

		// Token: 0x02000134 RID: 308
		// (Invoke) Token: 0x06000B6F RID: 2927
		public delegate void CardClickPlayDelegate(bool fromClick);
	}
}
