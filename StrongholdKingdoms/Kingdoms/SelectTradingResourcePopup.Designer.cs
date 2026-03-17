namespace Kingdoms
{
	// Token: 0x02000484 RID: 1156
	public partial class SelectTradingResourcePopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06002A13 RID: 10771 RVA: 0x0001EF6C File Offset: 0x0001D16C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x0020813C File Offset: 0x0020633C
		private void InitializeComponent()
		{
			this.selectTradingResourcePanel = new global::Kingdoms.SelectTradingResourcePanel();
			base.SuspendLayout();
			this.selectTradingResourcePanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.selectTradingResourcePanel.BackColor = global::ARGBColors.Yellow;
			this.selectTradingResourcePanel.Location = new global::System.Drawing.Point(0, 0);
			this.selectTradingResourcePanel.Name = "selectTradingResourcePanel";
			this.selectTradingResourcePanel.Size = new global::System.Drawing.Size(292, 266);
			this.selectTradingResourcePanel.StoredGraphics = null;
			this.selectTradingResourcePanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(292, 266);
			base.ControlBox = false;
			base.Controls.Add(this.selectTradingResourcePanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "SelectTradingResourcePopup";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Donation";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x040033A1 RID: 13217
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040033A2 RID: 13218
		private global::Kingdoms.SelectTradingResourcePanel selectTradingResourcePanel;
	}
}
