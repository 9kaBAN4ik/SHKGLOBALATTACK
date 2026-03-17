namespace Kingdoms
{
	// Token: 0x020004C9 RID: 1225
	public partial class ViewMailPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06002D5B RID: 11611 RVA: 0x0002159B File Offset: 0x0001F79B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x00240458 File Offset: 0x0023E658
		private void InitializeComponent()
		{
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.tbBody = new global::System.Windows.Forms.TextBox();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.lbFrom = new global::System.Windows.Forms.Label();
			this.lblFromName = new global::System.Windows.Forms.Label();
			this.lbDate = new global::System.Windows.Forms.Label();
			this.lbDateValue = new global::System.Windows.Forms.Label();
			this.btnCopyClipboard = new global::Kingdoms.BitmapButton();
			this.btnCopySelected = new global::Kingdoms.BitmapButton();
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
			this.btnClose.Location = new global::System.Drawing.Point(676, 487);
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
			this.tbBody.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tbBody.BackColor = global::ARGBColors.White;
			this.tbBody.ForeColor = global::ARGBColors.Black;
			this.tbBody.Location = new global::System.Drawing.Point(14, 82);
			this.tbBody.Multiline = true;
			this.tbBody.Name = "textBox1";
			this.tbBody.ReadOnly = true;
			this.tbBody.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.tbBody.Size = new global::System.Drawing.Size(772, 399);
			this.tbBody.TabIndex = 18;
			this.textBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBox2.BackColor = global::ARGBColors.White;
			this.textBox2.ForeColor = global::ARGBColors.Black;
			this.textBox2.Location = new global::System.Drawing.Point(14, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new global::System.Drawing.Size(772, 20);
			this.textBox2.TabIndex = 19;
			this.lbFrom.AutoSize = true;
			this.lbFrom.BackColor = global::ARGBColors.Transparent;
			this.lbFrom.ForeColor = global::ARGBColors.White;
			this.lbFrom.Location = new global::System.Drawing.Point(18, 39);
			this.lbFrom.Name = "lbFrom";
			this.lbFrom.Size = new global::System.Drawing.Size(35, 13);
			this.lbFrom.TabIndex = 20;
			this.lbFrom.Text = "label1";
			this.lblFromName.AutoSize = true;
			this.lblFromName.BackColor = global::ARGBColors.Transparent;
			this.lblFromName.ForeColor = global::ARGBColors.White;
			this.lblFromName.Location = new global::System.Drawing.Point(83, 39);
			this.lblFromName.Name = "lblFromName";
			this.lblFromName.Size = new global::System.Drawing.Size(35, 13);
			this.lblFromName.TabIndex = 21;
			this.lblFromName.Text = "label1";
			this.lbDate.AutoSize = true;
			this.lbDate.BackColor = global::ARGBColors.Transparent;
			this.lbDate.ForeColor = global::ARGBColors.White;
			this.lbDate.Location = new global::System.Drawing.Point(594, 39);
			this.lbDate.Name = "lbDate";
			this.lbDate.Size = new global::System.Drawing.Size(35, 13);
			this.lbDate.TabIndex = 22;
			this.lbDate.Text = "label1";
			this.lbDateValue.AutoSize = true;
			this.lbDateValue.BackColor = global::ARGBColors.Transparent;
			this.lbDateValue.ForeColor = global::ARGBColors.White;
			this.lbDateValue.Location = new global::System.Drawing.Point(656, 39);
			this.lbDateValue.Name = "lbDateValue";
			this.lbDateValue.Size = new global::System.Drawing.Size(35, 13);
			this.lbDateValue.TabIndex = 23;
			this.lbDateValue.Text = "label1";
			this.btnCopyClipboard.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCopyClipboard.BorderColor = global::ARGBColors.DarkBlue;
			this.btnCopyClipboard.BorderDrawing = true;
			this.btnCopyClipboard.FocusRectangleEnabled = false;
			this.btnCopyClipboard.Image = null;
			this.btnCopyClipboard.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnCopyClipboard.ImageBorderEnabled = true;
			this.btnCopyClipboard.ImageDropShadow = true;
			this.btnCopyClipboard.ImageFocused = null;
			this.btnCopyClipboard.ImageInactive = null;
			this.btnCopyClipboard.ImageMouseOver = null;
			this.btnCopyClipboard.ImageNormal = null;
			this.btnCopyClipboard.ImagePressed = null;
			this.btnCopyClipboard.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnCopyClipboard.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnCopyClipboard.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnCopyClipboard.Location = new global::System.Drawing.Point(14, 487);
			this.btnCopyClipboard.Name = "btnCopyClipboard";
			this.btnCopyClipboard.OffsetPressedContent = true;
			this.btnCopyClipboard.Padding2 = 5;
			this.btnCopyClipboard.Size = new global::System.Drawing.Size(216, 27);
			this.btnCopyClipboard.StretchImage = false;
			this.btnCopyClipboard.TabIndex = 24;
			this.btnCopyClipboard.Text = "Copy All to Clipboard";
			this.btnCopyClipboard.TextDropShadow = false;
			this.btnCopyClipboard.UseVisualStyleBackColor = true;
			this.btnCopyClipboard.Click += new global::System.EventHandler(this.btnCopyClipboard_Click);
			this.btnCopySelected.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnCopySelected.BorderColor = global::ARGBColors.DarkBlue;
			this.btnCopySelected.BorderDrawing = true;
			this.btnCopySelected.FocusRectangleEnabled = false;
			this.btnCopySelected.Image = null;
			this.btnCopySelected.ImageBorderColor = global::ARGBColors.Chocolate;
			this.btnCopySelected.ImageBorderEnabled = true;
			this.btnCopySelected.ImageDropShadow = true;
			this.btnCopySelected.ImageFocused = null;
			this.btnCopySelected.ImageInactive = null;
			this.btnCopySelected.ImageMouseOver = null;
			this.btnCopySelected.ImageNormal = null;
			this.btnCopySelected.ImagePressed = null;
			this.btnCopySelected.InnerBorderColor = global::ARGBColors.LightGray;
			this.btnCopySelected.InnerBorderColor_Focus = global::ARGBColors.LightBlue;
			this.btnCopySelected.InnerBorderColor_MouseOver = global::ARGBColors.Gold;
			this.btnCopySelected.Location = new global::System.Drawing.Point(236, 487);
			this.btnCopySelected.Name = "btnCopySelected";
			this.btnCopySelected.OffsetPressedContent = true;
			this.btnCopySelected.Padding2 = 5;
			this.btnCopySelected.Size = new global::System.Drawing.Size(216, 27);
			this.btnCopySelected.StretchImage = false;
			this.btnCopySelected.TabIndex = 25;
			this.btnCopySelected.Text = "Copy Selected to Clipboard";
			this.btnCopySelected.TextDropShadow = false;
			this.btnCopySelected.UseVisualStyleBackColor = true;
			this.btnCopySelected.Click += new global::System.EventHandler(this.btnCopySelected_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(798, 526);
			base.Controls.Add(this.btnCopySelected);
			base.Controls.Add(this.btnCopyClipboard);
			base.Controls.Add(this.lbDateValue);
			base.Controls.Add(this.lbDate);
			base.Controls.Add(this.lblFromName);
			base.Controls.Add(this.lbFrom);
			base.Controls.Add(this.textBox2);
			base.Controls.Add(this.tbBody);
			base.Controls.Add(this.btnClose);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "ViewMailPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Users";
			base.TopMost = true;
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.tbBody, 0);
			base.Controls.SetChildIndex(this.textBox2, 0);
			base.Controls.SetChildIndex(this.lbFrom, 0);
			base.Controls.SetChildIndex(this.lblFromName, 0);
			base.Controls.SetChildIndex(this.lbDate, 0);
			base.Controls.SetChildIndex(this.lbDateValue, 0);
			base.Controls.SetChildIndex(this.btnCopyClipboard, 0);
			base.Controls.SetChildIndex(this.btnCopySelected, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04003859 RID: 14425
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400385A RID: 14426
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400385B RID: 14427
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x0400385C RID: 14428
		private global::System.Windows.Forms.TextBox tbBody;

		// Token: 0x0400385D RID: 14429
		private global::System.Windows.Forms.TextBox textBox2;

		// Token: 0x0400385E RID: 14430
		private global::System.Windows.Forms.Label lbFrom;

		// Token: 0x0400385F RID: 14431
		private global::System.Windows.Forms.Label lblFromName;

		// Token: 0x04003860 RID: 14432
		private global::System.Windows.Forms.Label lbDate;

		// Token: 0x04003861 RID: 14433
		private global::System.Windows.Forms.Label lbDateValue;

		// Token: 0x04003862 RID: 14434
		private global::Kingdoms.BitmapButton btnCopyClipboard;

		// Token: 0x04003863 RID: 14435
		private global::Kingdoms.BitmapButton btnCopySelected;
	}
}
