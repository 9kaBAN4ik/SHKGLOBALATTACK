namespace Kingdoms
{
	// Token: 0x02000251 RID: 593
	public partial class NewAutoSelectVillageWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001A35 RID: 6709 RVA: 0x0001A3FC File Offset: 0x000185FC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x0019E73C File Offset: 0x0019C93C
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.NewAutoSelectVillagePanel();
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
			base.Name = "NewAutoSelectVillageWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "NewAutoSelectVillageWindow";
			base.TransparencyKey = global::ARGBColors.Fuchsia;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.NewAutoSelectVillageWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04002AEF RID: 10991
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002AF0 RID: 10992
		private global::Kingdoms.NewAutoSelectVillagePanel customPanel;
	}
}
