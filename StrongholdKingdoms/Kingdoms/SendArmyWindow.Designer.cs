namespace Kingdoms
{
	// Token: 0x02000486 RID: 1158
	public partial class SendArmyWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06002A24 RID: 10788 RVA: 0x0001EFF4 File Offset: 0x0001D1F4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002A25 RID: 10789 RVA: 0x0020B190 File Offset: 0x00209390
		private void InitializeComponent()
		{
			this.sendArmyPanel = new global::Kingdoms.SendArmyPanel();
			base.SuspendLayout();
			this.sendArmyPanel.Location = new global::System.Drawing.Point(0, 0);
			this.sendArmyPanel.Name = "sendArmyPanel";
			this.sendArmyPanel.PanelActive = true;
			this.sendArmyPanel.Size = new global::System.Drawing.Size(700, 482);
			this.sendArmyPanel.StoredGraphics = null;
			this.sendArmyPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 482);
			base.ControlBox = false;
			base.Controls.Add(this.sendArmyPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(700, 482);
			this.MinimumSize = new global::System.Drawing.Size(700, 482);
			base.Name = "SendArmyWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "SendArmyWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.SendArmyWindow_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040033DD RID: 13277
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040033DE RID: 13278
		private global::Kingdoms.SendArmyPanel sendArmyPanel;
	}
}
