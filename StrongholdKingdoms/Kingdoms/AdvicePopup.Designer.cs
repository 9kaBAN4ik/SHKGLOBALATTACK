namespace Kingdoms
{
	// Token: 0x020000BB RID: 187
	public partial class AdvicePopup : global::System.Windows.Forms.Form
	{
		// Token: 0x0600052C RID: 1324 RVA: 0x0000AC3A File Offset: 0x00008E3A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x000636D0 File Offset: 0x000618D0
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.AdvicePanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "FirstTimePanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(600, 300);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(600, 300);
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(600, 300);
			this.MinimumSize = new global::System.Drawing.Size(600, 300);
			base.Name = "AdviceWindow";
			base.Opacity = 0.9;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x040005FC RID: 1532
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040005FD RID: 1533
		private global::Kingdoms.AdvicePanel customPanel;
	}
}
