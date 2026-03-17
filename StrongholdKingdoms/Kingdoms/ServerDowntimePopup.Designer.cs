namespace Kingdoms
{
	// Token: 0x0200048B RID: 1163
	public partial class ServerDowntimePopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06002A55 RID: 10837 RVA: 0x0001F1D7 File Offset: 0x0001D3D7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A56 RID: 10838 RVA: 0x0020F090 File Offset: 0x0020D290
		private void InitializeComponent()
		{
			this.btnClose = new global::Kingdoms.BitmapButton();
			this.lblHeader = new global::System.Windows.Forms.Label();
			this.lblMinutes = new global::System.Windows.Forms.Label();
			this.lblExplanation = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.BackColor = global::System.Drawing.Color.FromArgb(203, 215, 223);
			this.btnClose.Location = new global::System.Drawing.Point(274, 188);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 13;
			this.btnClose.Text = "OK";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.lblHeader.BackColor = global::ARGBColors.Transparent;
			this.lblHeader.Location = new global::System.Drawing.Point(33, 50);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new global::System.Drawing.Size(295, 29);
			this.lblHeader.TabIndex = 14;
			this.lblHeader.Text = "There is a Planned Downtime in";
			this.lblHeader.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblMinutes.BackColor = global::ARGBColors.Transparent;
			this.lblMinutes.Location = new global::System.Drawing.Point(33, 85);
			this.lblMinutes.Name = "lblMinutes";
			this.lblMinutes.Size = new global::System.Drawing.Size(295, 29);
			this.lblMinutes.TabIndex = 15;
			this.lblMinutes.Text = "X Minutes";
			this.lblMinutes.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.lblExplanation.BackColor = global::ARGBColors.Transparent;
			this.lblExplanation.Location = new global::System.Drawing.Point(33, 120);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new global::System.Drawing.Size(295, 53);
			this.lblExplanation.TabIndex = 16;
			this.lblExplanation.Text = "Please ensure you have logged out safely in advance of this downtime.";
			this.lblExplanation.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(361 * global::Kingdoms.InterfaceMgr.UIScale, 223 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.lblExplanation);
			base.Controls.Add(this.lblMinutes);
			base.Controls.Add(this.lblHeader);
			base.Controls.Add(this.btnClose);
			base.Name = "ServerDowntimePopup";
			base.ShowClose = true;
			this.Text = "ServerDowntimePopup";
			base.Controls.SetChildIndex(this.btnClose, 0);
			base.Controls.SetChildIndex(this.lblHeader, 0);
			base.Controls.SetChildIndex(this.lblMinutes, 0);
			base.Controls.SetChildIndex(this.lblExplanation, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04003424 RID: 13348
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003425 RID: 13349
		private global::Kingdoms.BitmapButton btnClose;

		// Token: 0x04003426 RID: 13350
		private global::System.Windows.Forms.Label lblHeader;

		// Token: 0x04003427 RID: 13351
		private global::System.Windows.Forms.Label lblMinutes;

		// Token: 0x04003428 RID: 13352
		private global::System.Windows.Forms.Label lblExplanation;
	}
}
