namespace Kingdoms
{
	// Token: 0x02000279 RID: 633
	public partial class PostTutorialWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001C70 RID: 7280 RVA: 0x0001BE6A File Offset: 0x0001A06A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001C71 RID: 7281 RVA: 0x001BCF54 File Offset: 0x001BB154
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.PostTutorialPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.ClickThru = false;
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(625, 668);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(625, 668);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "PostTutorialWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PostTutorialWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.PostTutorialWindow_FormClosed);
			base.ResumeLayout(false);
		}

		// Token: 0x04002D49 RID: 11593
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002D4A RID: 11594
		private global::Kingdoms.PostTutorialPanel customPanel;
	}
}
