namespace Kingdoms
{
	// Token: 0x020001A3 RID: 419
	public partial class EmailOptInPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001003 RID: 4099 RVA: 0x00011BD2 File Offset: 0x0000FDD2
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00117708 File Offset: 0x00115908
		private void InitializeComponent()
		{
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.cbMailOptIn = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(7, 76);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(79, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Search Results";
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
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
			this.btnClose.Location = new global::System.Drawing.Point(336, 115);
			this.btnClose.Name = "btnClose";
			this.btnClose.OffsetPressedContent = true;
			this.btnClose.Padding2 = 5;
			this.btnClose.Size = new global::System.Drawing.Size(110, 27);
			this.btnClose.StretchImage = false;
			this.btnClose.TabIndex = 17;
			this.btnClose.Text = "Close";
			this.btnClose.TextDropShadow = false;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.cbMailOptIn.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.cbMailOptIn.BackColor = global::ARGBColors.Transparent;
			this.cbMailOptIn.Location = new global::System.Drawing.Point(32, 37);
			this.cbMailOptIn.Name = "cbMailOptIn";
			this.cbMailOptIn.Size = new global::System.Drawing.Size(398, 72);
			this.cbMailOptIn.TabIndex = 18;
			this.cbMailOptIn.Text = "Mail Opt In";
			this.cbMailOptIn.UseVisualStyleBackColor = false;
			this.cbMailOptIn.CheckedChanged += new global::System.EventHandler(this.cbMailOptIn_CheckedChanged);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(458, 154);
			base.Controls.Add(this.cbMailOptIn);
			base.Controls.Add(this.btnClose);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "EmailOptInPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Users";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.cbMailOptIn, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04001618 RID: 5656
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001619 RID: 5657
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400161A RID: 5658
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x0400161B RID: 5659
		private global::System.Windows.Forms.CheckBox cbMailOptIn;
	}
}
