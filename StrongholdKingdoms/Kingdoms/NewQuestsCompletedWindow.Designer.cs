namespace Kingdoms
{
	// Token: 0x02000258 RID: 600
	public partial class NewQuestsCompletedWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001A5E RID: 6750 RVA: 0x0001A68F File Offset: 0x0001888F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x001A0728 File Offset: 0x0019E928
		private void InitializeComponent()
		{
			this.newQuestsCompletedPanel = new global::Kingdoms.NewQuestsCompletedPanel();
			base.SuspendLayout();
			this.newQuestsCompletedPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.newQuestsCompletedPanel.ClickThru = false;
			this.newQuestsCompletedPanel.Location = new global::System.Drawing.Point(0, 0);
			this.newQuestsCompletedPanel.Name = "newQuestsCompletedPanel";
			this.newQuestsCompletedPanel.PanelActive = true;
			this.newQuestsCompletedPanel.Size = new global::System.Drawing.Size(489, 350);
			this.newQuestsCompletedPanel.StoredGraphics = null;
			this.newQuestsCompletedPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(489, 350);
			base.Controls.Add(this.newQuestsCompletedPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(700, 443);
			this.MinimumSize = new global::System.Drawing.Size(475, 350);
			base.Name = "NewQuestsCompletedWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x04002B2D RID: 11053
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002B2E RID: 11054
		private global::Kingdoms.NewQuestsCompletedPanel newQuestsCompletedPanel;
	}
}
