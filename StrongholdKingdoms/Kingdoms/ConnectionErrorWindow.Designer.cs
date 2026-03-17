namespace Kingdoms
{
	// Token: 0x0200013C RID: 316
	public partial class ConnectionErrorWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000BA8 RID: 2984 RVA: 0x0000E9EE File Offset: 0x0000CBEE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x000E5D64 File Offset: 0x000E3F64
		private void InitializeComponent()
		{
			this.btnLogout = new global::Kingdoms.BitmapButton();
			this.lblMessage = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			base.ClientSize = new global::System.Drawing.Size(424, 149);
			this.btnLogout.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnLogout.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnLogout.BorderColor = global::ARGBColors.DarkBlue;
			this.btnLogout.BorderDrawing = true;
			this.btnLogout.FocusRectangleEnabled = false;
			this.btnLogout.Image = null;
			this.btnLogout.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnLogout.ImageBorderEnabled = true;
			this.btnLogout.ImageDropShadow = true;
			this.btnLogout.ImageFocused = null;
			this.btnLogout.ImageInactive = null;
			this.btnLogout.ImageMouseOver = null;
			this.btnLogout.ImageNormal = null;
			this.btnLogout.ImagePressed = null;
			this.btnLogout.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnLogout.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnLogout.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnLogout.Size = new global::System.Drawing.Size(191, 26);
			this.btnLogout.Location = new global::System.Drawing.Point(221, 111);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.OffsetPressedContent = true;
			this.btnLogout.Padding2 = 5;
			this.btnLogout.StretchImage = false;
			this.btnLogout.TabIndex = 20;
			this.btnLogout.Text = "Quit to Login Screen";
			this.btnLogout.TextDropShadow = false;
			this.btnLogout.UseVisualStyleBackColor = false;
			this.btnLogout.Click += new global::System.EventHandler(this.btnLogout_Click);
			this.lblMessage.BackColor = global::ARGBColors.Transparent;
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Location = new global::System.Drawing.Point(11, 34);
			this.lblMessage.Size = new global::System.Drawing.Size(401, 69);
			this.lblMessage.TabIndex = 21;
			this.lblMessage.Text = "label1";
			this.lblMessage.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(128, 145, 156);
			base.Controls.Add(this.lblMessage);
			base.Controls.Add(this.btnLogout);
			base.Name = "ConnectionErrorWindow";
			base.ShowClose = true;
			this.Text = "ConnectionErrorWindow";
			base.Controls.SetChildIndex(this.btnLogout, 0);
			base.Controls.SetChildIndex(this.lblMessage, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000FB5 RID: 4021
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000FB6 RID: 4022
		private global::Kingdoms.BitmapButton btnLogout;

		// Token: 0x04000FB7 RID: 4023
		private global::System.Windows.Forms.Label lblMessage;
	}
}
