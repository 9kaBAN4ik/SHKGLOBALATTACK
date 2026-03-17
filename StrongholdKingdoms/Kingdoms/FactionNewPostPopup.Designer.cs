namespace Kingdoms
{
	// Token: 0x020001CE RID: 462
	public partial class FactionNewPostPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001163 RID: 4451 RVA: 0x00013071 File Offset: 0x00011271
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x00125ED8 File Offset: 0x001240D8
		private void InitializeComponent()
		{
			this.tbHeading = new global::System.Windows.Forms.TextBox();
			this.lblTopic = new global::System.Windows.Forms.Label();
			this.tbMainText = new global::System.Windows.Forms.TextBox();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.btnOK = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.tbHeading.BackColor = global::System.Drawing.Color.FromArgb(134, 153, 165);
			this.tbHeading.Location = new global::System.Drawing.Point(122, 38);
			this.tbHeading.MaxLength = 99;
			this.tbHeading.Name = "tbHeading";
			this.tbHeading.ReadOnly = true;
			this.tbHeading.Size = new global::System.Drawing.Size(500, 20);
			this.tbHeading.TabIndex = 4;
			this.lblTopic.AutoSize = true;
			this.lblTopic.BackColor = global::ARGBColors.Transparent;
			this.lblTopic.Location = new global::System.Drawing.Point(12, 41);
			this.lblTopic.Name = "lblTopic";
			this.lblTopic.Size = new global::System.Drawing.Size(34, 13);
			this.lblTopic.TabIndex = 5;
			this.lblTopic.Text = "Topic";
			this.tbMainText.Location = new global::System.Drawing.Point(15, 64);
			this.tbMainText.Multiline = true;
			this.tbMainText.Name = "tbMainText";
			this.tbMainText.Size = new global::System.Drawing.Size(607, 291);
			this.tbMainText.TabIndex = 1;
			this.tbMainText.TextChanged += new global::System.EventHandler(this.tbMainText_TextChanged);
			this.btnCancel.BorderColor = global::ARGBColors.DarkBlue;
			this.btnCancel.BorderDrawing = true;
			this.btnCancel.FocusRectangleEnabled = false;
			this.btnCancel.Image = null;
			this.btnCancel.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnCancel.ImageBorderEnabled = true;
			this.btnCancel.ImageDropShadow = true;
			this.btnCancel.ImageFocused = null;
			this.btnCancel.ImageInactive = null;
			this.btnCancel.ImageMouseOver = null;
			this.btnCancel.ImageNormal = null;
			this.btnCancel.ImagePressed = null;
			this.btnCancel.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnCancel.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnCancel.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnCancel.Location = new global::System.Drawing.Point(498, 368);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(124, 29);
			this.btnCancel.StretchImage = false;
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextDropShadow = false;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnOK.BorderColor = global::ARGBColors.DarkBlue;
			this.btnOK.BorderDrawing = true;
			this.btnOK.FocusRectangleEnabled = false;
			this.btnOK.Image = null;
			this.btnOK.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnOK.ImageBorderEnabled = true;
			this.btnOK.ImageDropShadow = true;
			this.btnOK.ImageFocused = null;
			this.btnOK.ImageInactive = null;
			this.btnOK.ImageMouseOver = null;
			this.btnOK.ImageNormal = null;
			this.btnOK.ImagePressed = null;
			this.btnOK.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnOK.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnOK.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnOK.Location = new global::System.Drawing.Point(368, 368);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(124, 29);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(642 * global::Kingdoms.InterfaceMgr.UIScale, 407 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.lblTopic);
			base.Controls.Add(this.tbHeading);
			base.Controls.Add(this.tbMainText);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "FactionNewPostPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New post";
			base.Controls.SetChildIndex(this.tbMainText, 0);
			base.Controls.SetChildIndex(this.tbHeading, 0);
			base.Controls.SetChildIndex(this.lblTopic, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400178D RID: 6029
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400178E RID: 6030
		private global::System.Windows.Forms.TextBox tbHeading;

		// Token: 0x0400178F RID: 6031
		private global::System.Windows.Forms.Label lblTopic;

		// Token: 0x04001790 RID: 6032
		private global::System.Windows.Forms.TextBox tbMainText;

		// Token: 0x04001791 RID: 6033
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04001792 RID: 6034
		private global::Kingdoms.BitmapButton btnOK;
	}
}
