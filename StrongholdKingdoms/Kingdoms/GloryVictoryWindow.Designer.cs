namespace Kingdoms
{
	// Token: 0x020001EC RID: 492
	public partial class GloryVictoryWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x060013A2 RID: 5026 RVA: 0x0001558F File Offset: 0x0001378F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0014F580 File Offset: 0x0014D780
		private void InitializeComponent()
		{
			this.gloryVictoryPanel = new global::Kingdoms.GloryVictoryPanel2();
			base.SuspendLayout();
			this.gloryVictoryPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.gloryVictoryPanel.ClickThru = false;
			this.gloryVictoryPanel.Location = new global::System.Drawing.Point(0, 0);
			this.gloryVictoryPanel.Name = "newQuestsCompletedPanel";
			this.gloryVictoryPanel.PanelActive = true;
			this.gloryVictoryPanel.Size = new global::System.Drawing.Size(600, 500);
			this.gloryVictoryPanel.StoredGraphics = null;
			this.gloryVictoryPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(600, 500);
			base.Controls.Add(this.gloryVictoryPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(600, 500);
			this.MinimumSize = new global::System.Drawing.Size(600, 500);
			base.Name = "GloryVictoryWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x040024C2 RID: 9410
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040024C3 RID: 9411
		private global::Kingdoms.GloryVictoryPanel2 gloryVictoryPanel;
	}
}
