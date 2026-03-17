namespace Kingdoms
{
	// Token: 0x0200023E RID: 574
	public partial class MedalsPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06001981 RID: 6529 RVA: 0x00019C94 File Offset: 0x00017E94
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x00199058 File Offset: 0x00197258
		private void InitializeComponent()
		{
			this.medalsPopupPanel = new global::Kingdoms.MedalsPopupPanel();
			base.SuspendLayout();
			this.medalsPopupPanel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.medalsPopupPanel.ClickThru = false;
			this.medalsPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.medalsPopupPanel.Name = "medalsPopupPanel";
			this.medalsPopupPanel.PanelActive = true;
			this.medalsPopupPanel.Size = new global::System.Drawing.Size(489, 350);
			this.medalsPopupPanel.StoredGraphics = null;
			this.medalsPopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(489, 350);
			base.Controls.Add(this.medalsPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			this.MaximumSize = new global::System.Drawing.Size(700, 443);
			this.MinimumSize = new global::System.Drawing.Size(475, 350);
			base.Name = "MedalsPopupWindow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			base.ResumeLayout(false);
		}

		// Token: 0x04002A29 RID: 10793
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04002A2A RID: 10794
		private global::Kingdoms.MedalsPopupPanel medalsPopupPanel;
	}
}
