namespace Kingdoms
{
	// Token: 0x02000290 RID: 656
	public partial class PrizeClaimWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001D3B RID: 7483 RVA: 0x0001C68D File Offset: 0x0001A88D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x001C6F38 File Offset: 0x001C5138
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.PrizeClaimPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(500, 400);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(500, 400);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "PrizeClaimWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PrizeClaimWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.PrizeClaimWindow_FormClosed);
		}

		// Token: 0x04002E04 RID: 11780
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002E05 RID: 11781
		private global::Kingdoms.PrizeClaimPanel customPanel;
	}
}
