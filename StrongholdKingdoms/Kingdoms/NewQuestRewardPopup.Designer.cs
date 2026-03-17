namespace Kingdoms
{
	// Token: 0x02000255 RID: 597
	public partial class NewQuestRewardPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06001A51 RID: 6737 RVA: 0x0001A5D9 File Offset: 0x000187D9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x0019FD44 File Offset: 0x0019DF44
		private void InitializeComponent()
		{
			this.newQuestRewardPanel = new global::Kingdoms.NewQuestRewardPanel();
			base.SuspendLayout();
			this.newQuestRewardPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.newQuestRewardPanel.BackColor = global::ARGBColors.Fuchsia;
			this.newQuestRewardPanel.ClickThru = false;
			this.newQuestRewardPanel.Location = new global::System.Drawing.Point(0, 0);
			this.newQuestRewardPanel.Name = "newQuestRewardPanel";
			this.newQuestRewardPanel.PanelActive = true;
			this.newQuestRewardPanel.Size = new global::System.Drawing.Size(500, 472);
			this.newQuestRewardPanel.StoredGraphics = null;
			this.newQuestRewardPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.ClientSize = new global::System.Drawing.Size(500, 472);
			base.ControlBox = false;
			base.Controls.Add(this.newQuestRewardPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "NewQuestRewardPopup";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Report Capture";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x04002B1B RID: 11035
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002B1C RID: 11036
		private global::Kingdoms.NewQuestRewardPanel newQuestRewardPanel;
	}
}
