namespace Kingdoms
{
	// Token: 0x0200019B RID: 411
	public partial class DisbandUnitsPopup : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000FC9 RID: 4041 RVA: 0x0001181F File Offset: 0x0000FA1F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00116064 File Offset: 0x00114264
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
			base.ClientSize = new global::System.Drawing.Size(292 * global::Kingdoms.InterfaceMgr.UIScale, 207 * global::Kingdoms.InterfaceMgr.UIScale);
			base.Controls.Add(this.customPanel);
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.Name = "DisbandUnitsPopup";
			base.ShowClose = true;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Disband";
			base.Controls.SetChildIndex(this.customPanel, 0);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040015F2 RID: 5618
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040015F3 RID: 5619
		private global::Kingdoms.DisbandTroopsPanel customPanel;
	}
}
