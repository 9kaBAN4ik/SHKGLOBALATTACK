namespace Kingdoms
{
	// Token: 0x020004A4 RID: 1188
	public partial class TutorialArrowWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06002B7D RID: 11133 RVA: 0x0001FF1C File Offset: 0x0001E11C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x002242D8 File Offset: 0x002224D8
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.TutorialArrowWindow));
			this.customPanel = new global::Kingdoms.TutorialArrowPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.PanelActive = true;
			this.customPanel.Size = new global::System.Drawing.Size(64, 64);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Fuchsia;
			base.ClientSize = new global::System.Drawing.Size(64, 64);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MinimumSize = new global::System.Drawing.Size(64, 64);
			base.Name = "TutorialArrowWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "TutorialArrowWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.ResumeLayout(false);
		}

		// Token: 0x04003616 RID: 13846
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003617 RID: 13847
		private global::Kingdoms.TutorialArrowPanel customPanel;
	}
}
