namespace Kingdoms
{
	// Token: 0x02000190 RID: 400
	public partial class CustomTooltip : global::System.Windows.Forms.Form
	{
		// Token: 0x06000F79 RID: 3961 RVA: 0x000113F9 File Offset: 0x0000F5F9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0010923C File Offset: 0x0010743C
		private void InitializeComponent()
		{
			this.customPanel = new global::Kingdoms.CustomTooltipPanel();
			base.SuspendLayout();
			this.customPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.customPanel.Location = new global::System.Drawing.Point(0, 0);
			this.customPanel.Name = "customPanel";
			this.customPanel.Size = new global::System.Drawing.Size(24, 24);
			this.customPanel.StoredGraphics = null;
			this.customPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(24, 24);
			base.ControlBox = false;
			base.Controls.Add(this.customPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new global::System.Drawing.Size(10, 10);
			base.Name = "CustomTooltip";
			base.Opacity = 0.95;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "CustomTooltip";
			base.ResumeLayout(false);
		}

		// Token: 0x0400136E RID: 4974
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400136F RID: 4975
		private global::Kingdoms.CustomTooltipPanel customPanel;
	}
}
