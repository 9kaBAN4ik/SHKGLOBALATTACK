namespace Kingdoms
{
	// Token: 0x0200048A RID: 1162
	public partial class SendMonkWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06002A4B RID: 10827 RVA: 0x0001F150 File Offset: 0x0001D350
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A4C RID: 10828 RVA: 0x0020ED18 File Offset: 0x0020CF18
		private void InitializeComponent()
		{
			this.sendMonkPanel = new global::Kingdoms.SendMonkPanel();
			base.SuspendLayout();
			this.sendMonkPanel.Location = new global::System.Drawing.Point(0, 0);
			this.sendMonkPanel.Name = "sendMonkPanel";
			this.sendMonkPanel.PanelActive = true;
			this.sendMonkPanel.Size = new global::System.Drawing.Size(700, 482);
			this.sendMonkPanel.StoredGraphics = null;
			this.sendMonkPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 482);
			base.ControlBox = false;
			base.Controls.Add(this.sendMonkPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(700, 482);
			this.MinimumSize = new global::System.Drawing.Size(700, 482);
			base.Name = "SendMonkWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "SendMonkWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.SendMonkPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04003421 RID: 13345
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04003422 RID: 13346
		private global::Kingdoms.SendMonkPanel sendMonkPanel;
	}
}
