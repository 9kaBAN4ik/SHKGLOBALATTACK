namespace Kingdoms
{
	// Token: 0x0200019A RID: 410
	public partial class DisbandTroopsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000FC5 RID: 4037 RVA: 0x000117D6 File Offset: 0x0000F9D6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x00115F0C File Offset: 0x0011410C
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.DisbandTroopsPanel();
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
			base.ClientSize = new global::System.Drawing.Size(292 * global::Kingdoms.InterfaceMgr.UIScale, 203 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.customPanel);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "DisbandTroopsPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Disband";
			base.Controls.SetChildIndex(this.customPanel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040015EF RID: 5615
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040015F0 RID: 5616
		private global::Kingdoms.DisbandTroopsPanel customPanel;
	}
}
