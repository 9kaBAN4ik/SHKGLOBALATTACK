namespace Kingdoms
{
	// Token: 0x020000F6 RID: 246
	public partial class BuyVillagePopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000774 RID: 1908 RVA: 0x0000C363 File Offset: 0x0000A563
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0009C768 File Offset: 0x0009A968
		private void InitializeComponent()
		{
			this.buyVillagePopupPanel = new global::Kingdoms.BuyVillagePopupPanel();
			base.SuspendLayout();
			this.buyVillagePopupPanel.ClickThru = false;
			this.buyVillagePopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.buyVillagePopupPanel.Name = "buyVillagePopupPanel";
			this.buyVillagePopupPanel.PanelActive = true;
			this.buyVillagePopupPanel.Size = new global::System.Drawing.Size(700, 503);
			this.buyVillagePopupPanel.StoredGraphics = null;
			this.buyVillagePopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 503);
			base.ControlBox = false;
			base.Controls.Add(this.buyVillagePopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(700, 503);
			this.MinimumSize = new global::System.Drawing.Size(700, 503);
			base.Name = "BuyVillagePopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "BuyVillagePopupWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.BuyVillagePopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000A27 RID: 2599
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000A28 RID: 2600
		private global::Kingdoms.BuyVillagePopupPanel buyVillagePopupPanel;
	}
}
