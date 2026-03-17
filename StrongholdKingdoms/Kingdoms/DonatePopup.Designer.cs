namespace Kingdoms
{
	// Token: 0x020001A0 RID: 416
	public partial class DonatePopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000FEB RID: 4075 RVA: 0x00011A37 File Offset: 0x0000FC37
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x00117224 File Offset: 0x00115424
		private void InitializeComponent()
		{
			this.donatePanel = new global::Kingdoms.DonatePanel();
			base.SuspendLayout();
			this.donatePanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.donatePanel.BackColor = global::ARGBColors.Fuchsia;
			this.donatePanel.Location = new global::System.Drawing.Point(0, 0);
			this.donatePanel.Name = "donatePanel";
			this.donatePanel.Size = new global::System.Drawing.Size(292, 266);
			this.donatePanel.StoredGraphics = null;
			this.donatePanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(292, 266);
			base.ControlBox = false;
			base.Controls.Add(this.donatePanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "DonatePopup";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Donation";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x0400160B RID: 5643
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400160C RID: 5644
		private global::Kingdoms.DonatePanel donatePanel;
	}
}
