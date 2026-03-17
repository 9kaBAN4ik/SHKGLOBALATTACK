namespace Kingdoms
{
	// Token: 0x020002AE RID: 686
	public partial class RankFacebookPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001EB6 RID: 7862 RVA: 0x0001D466 File Offset: 0x0001B666
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001EB7 RID: 7863 RVA: 0x001D9738 File Offset: 0x001D7938
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.RankFacebookPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 34);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = base.Size;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(450, 150);
			base.Controls.Add(this.customPanel);
			this.DoubleBuffered = true;
			base.Name = "RankFacebookPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Formations";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.Controls.SetChildIndex(this.customPanel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002F80 RID: 12160
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002F81 RID: 12161
		private global::Kingdoms.RankFacebookPanel customPanel;
	}
}
