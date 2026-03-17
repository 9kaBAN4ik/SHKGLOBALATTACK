namespace Kingdoms
{
	// Token: 0x02000288 RID: 648
	public partial class PresetPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06001D1C RID: 7452 RVA: 0x0001C640 File Offset: 0x0001A840
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x001C56F8 File Offset: 0x001C38F8
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.PresetPanel();
			base.SuspendLayout();
			base.ClientSize = new global::System.Drawing.Size(700 * global::Kingdoms.InterfaceMgr.UIScale, 480 * global::Kingdoms.InterfaceMgr.UIScale);
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 34);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = base.Size;
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 99;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(this.customPanel);
			this.DoubleBuffered = true;
			base.Name = "PresetPopup";
			base.ShowClose = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.Controls.SetChildIndex(this.customPanel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04002DE0 RID: 11744
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002DE1 RID: 11745
		private global::Kingdoms.PresetPanel customPanel;
	}
}
