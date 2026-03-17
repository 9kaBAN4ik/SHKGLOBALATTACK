using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002AD RID: 685
	public class RankFacebookPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001EB2 RID: 7858 RVA: 0x0001D408 File Offset: 0x0001B608
		public RankFacebookPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			RankFacebookPanel.shareClicked = false;
		}

		// Token: 0x06001EB3 RID: 7859 RVA: 0x001D9430 File Offset: 0x001D7630
		public void init(RankFacebookPopup parent)
		{
			this.m_parent = parent;
			base.Size = this.m_parent.Size;
			this.BackColor = global::ARGBColors.Transparent;
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Alpha = 0.1f;
			csdimage.Image = GFXLibrary.formations_img;
			csdimage.Scale = 5.0;
			csdimage.Position = new Point(0, 0);
			csdimage.Size = base.Size;
			base.addControl(csdimage);
			this.mainLabel.Text = SK.Text("FACEBOOK_SHARE_Info_Body", "Congratulations on Reaching Rank 10 (Thane). Share this achievement on Facebook and receive a free Random Card Pack!");
			this.mainLabel.Color = global::ARGBColors.Black;
			this.mainLabel.Position = new Point(10, 0);
			this.mainLabel.Size = new Size(430, 75);
			this.mainLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
			this.mainLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdimage.addControl(this.mainLabel);
			this.facebookShareButton.ImageNorm = GFXLibrary.facebookBrownNorm;
			this.facebookShareButton.ImageOver = GFXLibrary.facebookBrownOver;
			this.facebookShareButton.ImageClick = GFXLibrary.facebookBrownClick;
			this.facebookShareButton.Position = new Point(20, 80);
			this.facebookShareButton.UseTextSize = true;
			this.facebookShareButton.Text.Text = SK.Text("FACEBOOK_Share", "Share");
			this.facebookShareButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.facebookShareButton.Text.Position = new Point(20, 2);
			this.facebookShareButton.Text.Size = new Size(110, 21);
			this.facebookShareButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.facebookShareButton.TextYOffset = 0;
			this.facebookShareButton.Text.Color = global::ARGBColors.Black;
			this.facebookShareButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.facebookShareClicked));
			csdimage.addControl(this.facebookShareButton);
			this.closeButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.closeButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.closeButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.closeButton.Position = new Point(290, 80);
			this.closeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.closeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.closeButton.TextYOffset = -3;
			this.closeButton.Text.Color = global::ARGBColors.Black;
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick));
			csdimage.addControl(this.closeButton);
		}

		// Token: 0x06001EB4 RID: 7860 RVA: 0x0001D443 File Offset: 0x0001B643
		private void facebookShareClicked()
		{
			RankFacebookPanel.shareClicked = true;
			this.closeClick();
		}

		// Token: 0x06001EB5 RID: 7861 RVA: 0x0001D451 File Offset: 0x0001B651
		private void closeClick()
		{
			if (this.m_parent != null)
			{
				this.m_parent.Close();
			}
		}

		// Token: 0x04002F7B RID: 12155
		public static bool shareClicked;

		// Token: 0x04002F7C RID: 12156
		private RankFacebookPopup m_parent;

		// Token: 0x04002F7D RID: 12157
		private CustomSelfDrawPanel.CSDLabel mainLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F7E RID: 12158
		private CustomSelfDrawPanel.CSDButton facebookShareButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002F7F RID: 12159
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();
	}
}
