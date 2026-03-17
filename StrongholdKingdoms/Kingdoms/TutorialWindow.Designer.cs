namespace Kingdoms
{
	// Token: 0x020004A9 RID: 1193
	public partial class TutorialWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06002BA4 RID: 11172 RVA: 0x000200C1 File Offset: 0x0001E2C1
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002BA5 RID: 11173 RVA: 0x00226F38 File Offset: 0x00225138
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.TutorialPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(776, 203);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(776, 203);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "TutorialWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "TutorialWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x04003639 RID: 13881
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400363A RID: 13882
		private global::Kingdoms.TutorialPanel customPanel;
	}
}
