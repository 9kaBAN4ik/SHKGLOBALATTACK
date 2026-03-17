namespace Kingdoms
{
	// Token: 0x020001C9 RID: 457
	public partial class FactionNewForumPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001138 RID: 4408 RVA: 0x00012D55 File Offset: 0x00010F55
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0012483C File Offset: 0x00122A3C
		private void InitializeComponent()
		{
			this.tbForumName = new global::System.Windows.Forms.TextBox();
			this.lblTopic = new global::System.Windows.Forms.Label();
			this.btnCancel = new global::Kingdoms.BitmapButton();
			this.btnOK = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.tbForumName.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tbForumName.Location = new global::System.Drawing.Point(162, 50);
			this.tbForumName.MaxLength = 99;
			this.tbForumName.Name = "tbForumName";
			this.tbForumName.Size = new global::System.Drawing.Size(460, 20);
			this.tbForumName.TabIndex = 4;
			this.tbForumName.TextChanged += new global::System.EventHandler(this.tbForumName_TextChanged);
			this.tbForumName.KeyUp += new global::System.Windows.Forms.KeyEventHandler(this.tbForumName_KeyUp);
			this.lblTopic.AutoSize = true;
			this.lblTopic.BackColor = global::ARGBColors.Transparent;
			this.lblTopic.Location = new global::System.Drawing.Point(7, 53);
			this.lblTopic.Name = "lblTopic";
			this.lblTopic.Size = new global::System.Drawing.Size(89, 13);
			this.lblTopic.TabIndex = 5;
			this.lblTopic.Text = "Forum Sub Name";
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
			this.btnCancel.Location = new global::System.Drawing.Point(498, 85);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.OffsetPressedContent = true;
			this.btnCancel.Padding2 = 5;
			this.btnCancel.Size = new global::System.Drawing.Size(124, 27);
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
			this.btnOK.Location = new global::System.Drawing.Point(368, 85);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(124, 27);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(642 * global::Kingdoms.InterfaceMgr.UIScale, 127 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.btnCancel);
			base.Controls.Add(this.lblTopic);
			base.Controls.Add(this.tbForumName);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "FactionNewForumPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "New Sub Forum";
			base.Controls.SetChildIndex(this.tbForumName, 0);
			base.Controls.SetChildIndex(this.lblTopic, 0);
			base.Controls.SetChildIndex(this.btnCancel, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400175E RID: 5982
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400175F RID: 5983
		private global::System.Windows.Forms.TextBox tbForumName;

		// Token: 0x04001760 RID: 5984
		private global::System.Windows.Forms.Label lblTopic;

		// Token: 0x04001761 RID: 5985
		private global::Kingdoms.BitmapButton btnCancel;

		// Token: 0x04001762 RID: 5986
		private global::Kingdoms.BitmapButton btnOK;
	}
}
