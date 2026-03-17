namespace Kingdoms
{
	// Token: 0x020001CF RID: 463
	public partial class FactionNewTopicPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001165 RID: 4453 RVA: 0x00013090 File Offset: 0x00011290
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0012647C File Offset: 0x0012467C
		private void InitializeComponent()
		{
			this.tbHeading = new global::System.Windows.Forms.TextBox();
			this.lblTopic = new global::System.Windows.Forms.Label();
			this.tbMainText = new global::System.Windows.Forms.TextBox();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.btnOK = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.tbHeading.Location = new global::System.Drawing.Point(122, 38);
			this.tbHeading.MaxLength = 99;
			this.tbHeading.Name = "tbHeading";
			this.tbHeading.Size = new global::System.Drawing.Size(500, 20);
			this.tbHeading.TabIndex = 0;
			this.tbHeading.TextChanged += new global::System.EventHandler(this.tbHeading_TextChanged);
			this.lblTopic.AutoSize = true;
			this.lblTopic.BackColor = global::ARGBColors.Transparent;
			this.lblTopic.Location = new global::System.Drawing.Point(12, 41);
			this.lblTopic.Name = "lblTopic";
			this.lblTopic.Size = new global::System.Drawing.Size(34, 13);
			this.lblTopic.TabIndex = 1;
			this.lblTopic.Text = "Topic";
			this.tbMainText.Location = new global::System.Drawing.Point(15, 64);
			this.tbMainText.Multiline = true;
			this.tbMainText.Name = "tbMainText";
			this.tbMainText.Size = new global::System.Drawing.Size(607, 291);
			this.tbMainText.TabIndex = 2;
			this.tbMainText.TextChanged += new global::System.EventHandler(this.tbMainText_TextChanged);
			this.btnCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
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
			this.btnOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
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
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(642 * global::Kingdoms.InterfaceMgr.UIScale, 407 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.tbMainText);
			base.Controls.Add(this.lblTopic);
			base.Controls.Add(this.tbHeading);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "FactionNewTopicPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Topic";
			base.Controls.SetChildIndex(this.tbHeading, 0);
			base.Controls.SetChildIndex(this.lblTopic, 0);
			base.Controls.SetChildIndex(this.tbMainText, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04001793 RID: 6035
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001794 RID: 6036
		private global::System.Windows.Forms.TextBox tbHeading;

		// Token: 0x04001795 RID: 6037
		private global::System.Windows.Forms.Label lblTopic;

		// Token: 0x04001796 RID: 6038
		private global::System.Windows.Forms.TextBox tbMainText;

		// Token: 0x04001797 RID: 6039
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04001798 RID: 6040
		private global::Kingdoms.BitmapButton btnOK;
	}
}
