namespace Kingdoms
{
	// Token: 0x0200046F RID: 1135
	public partial class ReportCapturePopup : global::System.Windows.Forms.Form
	{
		// Token: 0x060028F1 RID: 10481 RVA: 0x0001E370 File Offset: 0x0001C570
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060028F2 RID: 10482 RVA: 0x001F2A8C File Offset: 0x001F0C8C
		private void InitializeComponent()
		{
			this.reportCapturePanel = new global::Kingdoms.ReportCapturePanel();
			this.reportDeletePanel = new global::Kingdoms.ReportDeletePanel();
			base.SuspendLayout();
			this.reportCapturePanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.reportCapturePanel.BackColor = global::ARGBColors.Fuchsia;
			this.reportCapturePanel.Location = new global::System.Drawing.Point(0, 0);
			this.reportCapturePanel.Name = "reportCapturePanel";
			this.reportCapturePanel.Size = new global::System.Drawing.Size(292, 266);
			this.reportCapturePanel.StoredGraphics = null;
			this.reportCapturePanel.TabIndex = 0;
			this.reportDeletePanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.reportDeletePanel.BackColor = global::ARGBColors.Fuchsia;
			this.reportDeletePanel.Location = new global::System.Drawing.Point(0, 0);
			this.reportDeletePanel.Name = "reportDeletePanel";
			this.reportDeletePanel.Size = new global::System.Drawing.Size(292, 266);
			this.reportDeletePanel.StoredGraphics = null;
			this.reportDeletePanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(292, 266);
			base.ControlBox = false;
			base.Controls.Add(this.reportCapturePanel);
			base.Controls.Add(this.reportDeletePanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ReportCapturePopup";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Report Capture";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x0400321B RID: 12827
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400321C RID: 12828
		private global::Kingdoms.ReportCapturePanel reportCapturePanel;

		// Token: 0x0400321D RID: 12829
		private global::Kingdoms.ReportDeletePanel reportDeletePanel;
	}
}
