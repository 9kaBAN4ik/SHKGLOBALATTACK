namespace Kingdoms
{
	// Token: 0x0200025C RID: 604
	public partial class NewSelectVillageAreaWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001AA0 RID: 6816 RVA: 0x0001A9E8 File Offset: 0x00018BE8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001AA1 RID: 6817 RVA: 0x001A50F4 File Offset: 0x001A32F4
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.NewSelectVillageAreaPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(1082, 682);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(1082, 682);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "NewSelectVillageAreaWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NewSelectVillageAreaWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.NewSelectVillageAreaWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04002B74 RID: 11124
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002B75 RID: 11125
		private global::Kingdoms.NewSelectVillageAreaPanel customPanel;
	}
}
