namespace Kingdoms
{
	// Token: 0x02000526 RID: 1318
	public partial class WorldsEndWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060033DE RID: 13278 RVA: 0x0002525B File Offset: 0x0002345B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060033DF RID: 13279 RVA: 0x002AE1E8 File Offset: 0x002AC3E8
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.WorldsEndPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(860, 620);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(860, 620);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "WorldsEndWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "WorldsEndWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.WorldsEndWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040040FA RID: 16634
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040040FB RID: 16635
		private global::Kingdoms.WorldsEndPanel customPanel;
	}
}
