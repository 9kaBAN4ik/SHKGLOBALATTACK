namespace Kingdoms
{
	// Token: 0x02000219 RID: 537
	public partial class LostVillageWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001696 RID: 5782 RVA: 0x00017DCF File Offset: 0x00015FCF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001697 RID: 5783 RVA: 0x001671E4 File Offset: 0x001653E4
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.LostVillagePanel();
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
			base.Name = "LostVillageWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "LostVillageWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.LostVillageWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040026E9 RID: 9961
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040026EA RID: 9962
		private global::Kingdoms.LostVillagePanel customPanel;
	}
}
