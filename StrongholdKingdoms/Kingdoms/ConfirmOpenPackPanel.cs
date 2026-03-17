using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000136 RID: 310
	public class ConfirmOpenPackPanel : CustomSelfDrawPanel
	{
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0000E82C File Offset: 0x0000CA2C
		public int Multiple
		{
			get
			{
				return (int)this.numMultiple.Value;
			}
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x000E4484 File Offset: 0x000E2684
		public ConfirmOpenPackPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x000E455C File Offset: 0x000E275C
		public void init(UICardPack pack, ConfirmOpenPackPanel.CardClickPlayDelegate callback, ConfirmOpenPackPopup parent)
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
			string category = GameEngine.Instance.cardPackManager.ProfileCardOffers[pack.PackIDs[0]].Category;
			int num = 0;
			foreach (CardTypes.UserCardPack userCardPack in GameEngine.Instance.cardPackManager.ProfileUserCardPacks.Values)
			{
				if (GameEngine.Instance.cardPackManager.ProfileCardOffers[userCardPack.OfferID].Category == category)
				{
					num += userCardPack.Count;
				}
			}
			if (num > 10)
			{
				num = 10;
			}
			int value = num;
			this.numMultiple = new NumericUpDown();
			base.Controls.Add(this.numMultiple);
			this.numMultiple.Minimum = 1m;
			this.numMultiple.Maximum = value;
			this.numMultiple.Increment = 1m;
			this.numMultiple.Left = base.Width / 2 - this.numMultiple.Width / 2;
			this.numMultiple.Top = base.Height / 2 - this.numMultiple.Height / 2 - 20;
			this.numMultiple.DecimalPlaces = 0;
			this.numMultiple.KeyUp += this.numMultiple_KeyUp;
			this.confirmLabel.Color = global::ARGBColors.Black;
			this.confirmLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.confirmLabel.Text = SK.Text("ConfirmOpenPack_HowMany", "How many packs of this type would you like to open?");
			this.confirmLabel.Position = new Point(20, 10);
			this.confirmLabel.Size = new Size(this.background.Width - 40, 80);
			this.confirmLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.confirmLabel);
			this.packTypeLabel.Text = pack.nameText;
			this.packTypeLabel.Color = global::ARGBColors.Black;
			this.packTypeLabel.Position = new Point(20, 80);
			this.packTypeLabel.Size = new Size(this.background.Width - 40, 80);
			this.packTypeLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.packTypeLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.background.addControl(this.packTypeLabel);
			this.confirmButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.confirmButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.confirmButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.confirmButton.TextYOffset = -2;
			this.confirmButton.Text.Color = global::ARGBColors.Black;
			this.confirmButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.confirmButton.Position = new Point(230, 190);
			this.confirmButton.Text.Text = SK.Text("ConfirmOpenPack_OpenPacks", "Open Packs");
			this.confirmButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playCard), "ConfirmOpenPackPanel_confirm_open_pack");
			this.background.addControl(this.confirmButton);
			this.minButton.ImageNorm = GFXLibrary.building_icon_circle;
			this.minButton.ImageOver = GFXLibrary.building_icon_circle;
			this.minButton.ImageClick = GFXLibrary.building_icon_circle;
			this.minButton.Position = new Point(this.numMultiple.Left, 135);
			this.minButton.Text.Text = this.numMultiple.Minimum.ToString();
			this.minButton.TextYOffset = -1;
			this.minButton.Text.Color = global::ARGBColors.Black;
			this.minButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.minButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.minAmount), "SetOpenPackAmount_Minimum");
			this.background.addControl(this.minButton);
			this.middleButton.ImageNorm = GFXLibrary.building_icon_circle;
			this.middleButton.ImageOver = GFXLibrary.building_icon_circle;
			this.middleButton.ImageClick = GFXLibrary.building_icon_circle;
			this.middleButton.Position = new Point(this.numMultiple.Left + this.numMultiple.Width / 2 - this.middleButton.Width / 2, 135);
			this.middleButton.TextYOffset = -1;
			this.middleButton.Text.Text = ((int)(this.numMultiple.Minimum + this.numMultiple.Maximum) / 2).ToString();
			this.middleButton.Text.Color = global::ARGBColors.Black;
			this.middleButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.middleButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.middleAmount), "SetOpenPackAmount_Middle");
			this.background.addControl(this.middleButton);
			this.maxButton.ImageNorm = GFXLibrary.building_icon_circle;
			this.maxButton.ImageOver = GFXLibrary.building_icon_circle;
			this.maxButton.ImageClick = GFXLibrary.building_icon_circle;
			this.maxButton.Position = new Point(this.numMultiple.Left + this.numMultiple.Width - this.maxButton.Width, 135);
			this.maxButton.TextYOffset = -1;
			this.maxButton.Text.Text = this.numMultiple.Maximum.ToString();
			this.maxButton.Text.Color = global::ARGBColors.Black;
			this.maxButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.maxButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.maxAmount), "SetOpenPackAmount_Maximum");
			this.background.addControl(this.maxButton);
			this.left.Position = new Point(this.numMultiple.Left - 5, this.numMultiple.Top - 5);
			this.left.Height = this.minButton.Position.Y + this.minButton.Height - this.left.Position.Y + 5;
			this.left.LineColor = global::ARGBColors.Black;
			this.left.Width = 0;
			this.background.addControl(this.left);
			this.right.Position = new Point(this.numMultiple.Right + 5, this.numMultiple.Top - 5);
			this.right.Height = this.minButton.Position.Y + this.minButton.Height - this.right.Position.Y + 5;
			this.right.LineColor = global::ARGBColors.Black;
			this.right.Width = 0;
			this.background.addControl(this.right);
			this.top.Position = new Point(this.numMultiple.Left - 5, this.numMultiple.Top - 5);
			this.top.Width = this.right.Position.X - this.left.Position.X;
			this.top.LineColor = global::ARGBColors.Black;
			this.top.Height = 0;
			this.background.addControl(this.top);
			this.bottom.Position = new Point(this.numMultiple.Left - 5, this.minButton.Position.Y + this.minButton.Height + 5);
			this.bottom.Width = this.right.Position.X - this.left.Position.X;
			this.bottom.LineColor = global::ARGBColors.Black;
			this.bottom.Height = 0;
			this.background.addControl(this.bottom);
			this.cancelButton.ImageNorm = GFXLibrary.cardpanel_button_blue_normal;
			this.cancelButton.ImageOver = GFXLibrary.cardpanel_button_blue_over;
			this.cancelButton.ImageClick = GFXLibrary.cardpanel_button_blue_pressed;
			this.cancelButton.Position = new Point(30, 190);
			this.cancelButton.TextYOffset = -2;
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "ConfirmOpenPackPanel_cancel");
			this.background.addControl(this.cancelButton);
			this.confirmCheck.CheckedImage = GFXLibrary.reports_checkbox_checked;
			this.confirmCheck.UncheckedImage = GFXLibrary.reports_checkbox_empty;
			this.confirmCheck.Position = new Point(20, 360);
			this.confirmCheck.Position = new Point(20, 240);
			this.confirmCheck.Checked = true;
			this.confirmCheck.CBLabel.Text = SK.Text("ConfirmOpenPack_AlwaysAsk", "Always ask to open multiple packs?");
			this.confirmCheck.CBLabel.Color = global::ARGBColors.Black;
			this.confirmCheck.CBLabel.Position = new Point(20, -1);
			this.confirmCheck.CBLabel.Size = new Size(360, 35);
			this.confirmCheck.CBLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.background.addControl(this.confirmCheck);
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x000E5184 File Offset: 0x000E3384
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

		// Token: 0x06000B7E RID: 2942 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x000E5240 File Offset: 0x000E3440
		private void closeClick()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.OpenMultipleCardPacks = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.OpenPackMultiple = (int)this.numMultiple.Value;
			InterfaceMgr.Instance.closeConfirmOpenPackPopup();
			Form cardWindow = InterfaceMgr.Instance.getCardWindow();
			if (cardWindow != null)
			{
				cardWindow.TopMost = true;
				cardWindow.TopMost = false;
			}
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x000E52B0 File Offset: 0x000E34B0
		private void playCard()
		{
			if (!this.confirmCheck.Checked)
			{
				Program.mySettings.OpenMultipleCardPacks = false;
				Program.mySettings.Save();
			}
			InterfaceMgr.Instance.OpenPackMultiple = (int)this.numMultiple.Value;
			InterfaceMgr.Instance.closeConfirmOpenPackPopup();
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

		// Token: 0x06000B81 RID: 2945 RVA: 0x0000E83E File Offset: 0x0000CA3E
		private void minAmount()
		{
			this.numMultiple.Value = 1m;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x0000E850 File Offset: 0x0000CA50
		private void middleAmount()
		{
			this.numMultiple.Value = (int)((this.numMultiple.Minimum + this.numMultiple.Maximum) / 2m);
		}

		// Token: 0x06000B83 RID: 2947 RVA: 0x0000E88D File Offset: 0x0000CA8D
		private void maxAmount()
		{
			this.numMultiple.Value = this.numMultiple.Maximum;
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x000E5334 File Offset: 0x000E3534
		private void clickPlus()
		{
			NumericUpDown numericUpDown = this.numMultiple;
			decimal value = ++numericUpDown.Value;
			numericUpDown.Value = value;
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x000E535C File Offset: 0x000E355C
		private void clickMinus()
		{
			NumericUpDown numericUpDown = this.numMultiple;
			decimal value = --numericUpDown.Value;
			numericUpDown.Value = value;
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x0000E8A5 File Offset: 0x0000CAA5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x04000F8E RID: 3982
		private NumericUpDown numMultiple;

		// Token: 0x04000F8F RID: 3983
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F90 RID: 3984
		private CustomSelfDrawPanel.CSDExtendingPanel background = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000F91 RID: 3985
		private CustomSelfDrawPanel.CSDLabel confirmLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000F92 RID: 3986
		private CustomSelfDrawPanel.CSDButton confirmButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F93 RID: 3987
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F94 RID: 3988
		private CustomSelfDrawPanel.CSDButton minButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F95 RID: 3989
		private CustomSelfDrawPanel.CSDButton maxButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F96 RID: 3990
		private CustomSelfDrawPanel.CSDButton middleButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000F97 RID: 3991
		private CustomSelfDrawPanel.CSDCheckBox confirmCheck = new CustomSelfDrawPanel.CSDCheckBox();

		// Token: 0x04000F98 RID: 3992
		private CustomSelfDrawPanel.CSDLine left = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04000F99 RID: 3993
		private CustomSelfDrawPanel.CSDLine right = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04000F9A RID: 3994
		private CustomSelfDrawPanel.CSDLine top = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04000F9B RID: 3995
		private CustomSelfDrawPanel.CSDLine bottom = new CustomSelfDrawPanel.CSDLine();

		// Token: 0x04000F9C RID: 3996
		private CustomSelfDrawPanel.CSDLabel packTypeLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000F9D RID: 3997
		private CustomSelfDrawPanel.CSDImage topLeftImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000F9E RID: 3998
		private CustomSelfDrawPanel.CSDImage bottomRightImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000F9F RID: 3999
		private ConfirmOpenPackPanel.CardClickPlayDelegate m_callback;

		// Token: 0x04000FA0 RID: 4000
		private ConfirmOpenPackPopup m_parent;

		// Token: 0x04000FA1 RID: 4001
		private IContainer components;

		// Token: 0x02000137 RID: 311
		// (Invoke) Token: 0x06000B89 RID: 2953
		public delegate void CardClickPlayDelegate(bool fromClick);
	}
}
