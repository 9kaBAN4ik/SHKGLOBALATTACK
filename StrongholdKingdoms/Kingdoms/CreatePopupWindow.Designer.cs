namespace Kingdoms
{
	// Token: 0x02000157 RID: 343
	public partial class CreatePopupWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x0000F935 File Offset: 0x0000DB35
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x000F5218 File Offset: 0x000F3418
		private void InitializeComponent()
		{
			this.createPopupPanel = new global::Kingdoms.CreatePopupPanel();
			base.SuspendLayout();
			this.createPopupPanel.Location = new global::System.Drawing.Point(0, 0);
			this.createPopupPanel.Name = "scoutPopupPanel";
			this.createPopupPanel.Size = new global::System.Drawing.Size(700, 463);
			this.createPopupPanel.StoredGraphics = null;
			this.createPopupPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(700, 463);
			base.ControlBox = false;
			base.Controls.Add(this.createPopupPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new global::System.Drawing.Size(700, 463);
			this.MinimumSize = new global::System.Drawing.Size(700, 463);
			base.Name = "ScoutPopupWindow";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ScoutPopupWindow";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.CreatePopupPanel_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x0400112D RID: 4397
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400112E RID: 4398
		private global::Kingdoms.CreatePopupPanel createPopupPanel;
	}
}
