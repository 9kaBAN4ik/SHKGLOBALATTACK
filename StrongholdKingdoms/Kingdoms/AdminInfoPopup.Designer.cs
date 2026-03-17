namespace Kingdoms
{
	// Token: 0x020000B5 RID: 181
	public partial class AdminInfoPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x060004F9 RID: 1273 RVA: 0x0000A990 File Offset: 0x00008B90
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x0005F9F4 File Offset: 0x0005DBF4
		private void InitializeComponent()
		{
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.btnExit = new global::Kingdoms.BitmapButton();
			this.btnSend = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.textBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox1.BackColor = global::ARGBColors.White;
			this.textBox1.Location = new global::System.Drawing.Point(12, 46);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new global::System.Drawing.Size(509, 366);
			this.textBox1.TabIndex = 0;
			this.btnExit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnExit.BorderColor = global::ARGBColors.DarkBlue;
			this.btnExit.BorderDrawing = true;
			this.btnExit.FocusRectangleEnabled = false;
			this.btnExit.Image = null;
			this.btnExit.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnExit.ImageBorderEnabled = true;
			this.btnExit.ImageDropShadow = true;
			this.btnExit.ImageFocused = null;
			this.btnExit.ImageInactive = null;
			this.btnExit.ImageMouseOver = null;
			this.btnExit.ImageNormal = null;
			this.btnExit.ImagePressed = null;
			this.btnExit.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnExit.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnExit.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnExit.Location = new global::System.Drawing.Point(425, 422);
			this.btnExit.Name = "btnExit";
			this.btnExit.OffsetPressedContent = true;
			this.btnExit.Padding2 = 5;
			this.btnExit.Size = new global::System.Drawing.Size(96, 23);
			this.btnExit.StretchImage = false;
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "Exit";
			this.btnExit.TextDropShadow = false;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new global::System.EventHandler(this.btnExit_Click);
			this.btnSend.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.btnSend.BorderColor = global::ARGBColors.DarkBlue;
			this.btnSend.BorderDrawing = true;
			this.btnSend.FocusRectangleEnabled = false;
			this.btnSend.Image = null;
			this.btnSend.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnSend.ImageBorderEnabled = true;
			this.btnSend.ImageDropShadow = true;
			this.btnSend.ImageFocused = null;
			this.btnSend.ImageInactive = null;
			this.btnSend.ImageMouseOver = null;
			this.btnSend.ImageNormal = null;
			this.btnSend.ImagePressed = null;
			this.btnSend.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnSend.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnSend.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnSend.Location = new global::System.Drawing.Point(12, 422);
			this.btnSend.Name = "btnSend";
			this.btnSend.OffsetPressedContent = true;
			this.btnSend.Padding2 = 5;
			this.btnSend.Size = new global::System.Drawing.Size(96, 23);
			this.btnSend.StretchImage = false;
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.TextDropShadow = false;
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new global::System.EventHandler(this.btnSend_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(533 * global::Kingdoms.InterfaceMgr.UIScale, 457 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnSend);
			base.Controls.Add(this.btnExit);
			base.Controls.Add(this.textBox1);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AdminInfoPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Admin's Message";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.textBox1, 0);
			base.Controls.SetChildIndex(this.btnExit, 0);
			base.Controls.SetChildIndex(this.btnSend, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040005BA RID: 1466
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005BB RID: 1467
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x040005BC RID: 1468
		private global::Kingdoms.BitmapButton btnExit;

		// Token: 0x040005BD RID: 1469
		private global::Kingdoms.BitmapButton btnSend;
	}
}
