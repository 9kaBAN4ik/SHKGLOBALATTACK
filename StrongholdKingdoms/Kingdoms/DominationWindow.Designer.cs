namespace Kingdoms
{
	// Token: 0x0200019E RID: 414
	public partial class DominationWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000FDF RID: 4063 RVA: 0x000119AF File Offset: 0x0000FBAF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x00116798 File Offset: 0x00114998
		private void InitializeComponent()
		{
			this.lblDuration = new global::System.Windows.Forms.Label();
			this.lblDominationInfo = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.lblDuration.BackColor = global::ARGBColors.Transparent;
			this.lblDuration.ForeColor = global::ARGBColors.Black;
			this.lblDuration.Location = new global::System.Drawing.Point(3, 98);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new global::System.Drawing.Size(419, 20);
			this.lblDuration.TabIndex = 16;
			this.lblDuration.Text = "0";
			this.lblDuration.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDominationInfo.BackColor = global::ARGBColors.Transparent;
			this.lblDominationInfo.ForeColor = global::ARGBColors.Black;
			this.lblDominationInfo.Location = new global::System.Drawing.Point(0, 53);
			this.lblDominationInfo.Name = "lblDominationInfo";
			this.lblDominationInfo.Size = new global::System.Drawing.Size(422, 24);
			this.lblDominationInfo.TabIndex = 17;
			this.lblDominationInfo.Text = "Domination World will end in";
			this.lblDominationInfo.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnClose.BorderColor = global::ARGBColors.DarkBlue;
			this.btnClose.BorderDrawing = true;
			this.btnClose.FocusRectangleEnabled = false;
			this.btnClose.Image = null;
			this.btnClose.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnClose.ImageBorderEnabled = true;
			this.btnClose.ImageDropShadow = true;
			this.btnClose.ImageFocused = null;
			this.btnClose.ImageInactive = null;
			this.btnClose.ImageMouseOver = null;
			this.btnClose.ImageNormal = null;
			this.btnClose.ImagePressed = null;
			this.btnClose.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnClose.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnClose.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnClose.Location = new global::System.Drawing.Point(283, 144);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(129, 26);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 20;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(128, 145, 156);
			base.ClientSize = new global::System.Drawing.Size(424 * global::Kingdoms.InterfaceMgr.UIScale, 182 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.lblDominationInfo);
			base.Controls.Add(this.lblDuration);
			base.Name = "DominationWindow";
			base.ShowClose = true;
			this.Text = "DominationWindow";
			base.Controls.SetChildIndex(this.lblDuration, 0);
			base.Controls.SetChildIndex(this.lblDominationInfo, 0);
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04001604 RID: 5636
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001605 RID: 5637
		private global::System.Windows.Forms.Label lblDuration;

		// Token: 0x04001606 RID: 5638
		private global::System.Windows.Forms.Label lblDominationInfo;

		// Token: 0x04001607 RID: 5639
		private global::Kingdoms.BitmapButton btnClose;
	}
}
