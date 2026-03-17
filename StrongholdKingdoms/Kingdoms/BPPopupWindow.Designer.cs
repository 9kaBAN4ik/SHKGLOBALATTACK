namespace Kingdoms
{
	// Token: 0x020000E7 RID: 231
	public partial class BPPopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000703 RID: 1795 RVA: 0x0000BC5F File Offset: 0x00009E5F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0009037C File Offset: 0x0008E57C
		private void InitializeComponent()
		{
			this.createPopupPanel = new global::Kingdoms.BPPopupPanel();
			base.SuspendLayout();
			this.createPopupPanel.ClickThru = false;
			this.createPopupPanel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			this.createPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.createPopupPanel.Name = "createPopupPanel";
			this.createPopupPanel.NoDrawBackground = false;
			this.createPopupPanel.PanelActive = true;
			this.createPopupPanel.SelfDrawBackground = false;
			this.createPopupPanel.Size = new global::System.Drawing.Size(600, 200);
			this.createPopupPanel.StoredGraphics = null;
			this.createPopupPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(600, 200);
			base.ControlBox = false;
			base.Controls.Add(this.createPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(600, 200);
			this.MinimumSize = new global::System.Drawing.Size(600, 200);
			base.Name = "BPPopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScoutPopupWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.CreatePopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400093F RID: 2367
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000940 RID: 2368
		private global::Kingdoms.BPPopupPanel createPopupPanel;
	}
}
