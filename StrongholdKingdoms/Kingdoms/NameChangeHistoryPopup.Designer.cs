namespace Kingdoms
{
	// Token: 0x0200024E RID: 590
	public partial class NameChangeHistoryPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001A22 RID: 6690 RVA: 0x0001A2F7 File Offset: 0x000184F7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x0019D8A4 File Offset: 0x0019BAA4
		private void InitializeComponent()
		{
			this.listBox1 = new global::System.Windows.Forms.ListBox();
			this.btnOK = new global::Kingdoms.BitmapButton();
			base.SuspendLayout();
			this.listBox1.Font = new global::System.Drawing.Font("Lucida Console", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 11;
			this.listBox1.Location = new global::System.Drawing.Point(14, 53);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new global::System.Drawing.Size(680, 290);
			this.listBox1.TabIndex = 13;
			this.btnOK.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
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
			this.btnOK.Location = new global::System.Drawing.Point(615, 369);
			this.btnOK.Name = "btnOK";
			this.btnOK.OffsetPressedContent = true;
			this.btnOK.Padding2 = 5;
			this.btnOK.Size = new global::System.Drawing.Size(79, 20);
			this.btnOK.StretchImage = false;
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.TextDropShadow = false;
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new global::System.EventHandler(this.btnOK_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(706, 401);
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.listBox1);
			base.Name = "NameChangeHistoryPopup";
			base.ShowClose = true;
			this.Text = "NameChangeHistoryPopup";
			base.Controls.SetChildIndex(this.listBox1, 0);
			base.Controls.SetChildIndex(this.btnOK, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04002ADB RID: 10971
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002ADC RID: 10972
		private global::System.Windows.Forms.ListBox listBox1;

		// Token: 0x04002ADD RID: 10973
		private global::Kingdoms.BitmapButton btnOK;
	}
}
