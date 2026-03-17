namespace Kingdoms
{
	// Token: 0x02000138 RID: 312
	public partial class ConfirmOpenPackPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000B91 RID: 2961 RVA: 0x0000E925 File Offset: 0x0000CB25
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000E53B8 File Offset: 0x000E35B8
		private void InitializeComponent()
		{
			this.confirmPanel = new global::Kingdoms.ConfirmOpenPackPanel();
			base.SuspendLayout();
			this.confirmPanel.ClickThru = false;
			this.confirmPanel.Location = new global::System.Drawing.Point(0, 0);
			this.confirmPanel.Name = "confirmPanel";
			this.confirmPanel.PanelActive = true;
			this.confirmPanel.Size = new global::System.Drawing.Size(400, 280);
			this.confirmPanel.StoredGraphics = null;
			this.confirmPanel.TabIndex = 0;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(400, 280);
			base.ControlBox = false;
			base.Controls.Add(this.confirmPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ConfirmOpenPackPopup";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ConfirmPlayCardPopup";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ConfirmPlayCardPopup_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000FA3 RID: 4003
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000FA4 RID: 4004
		private global::Kingdoms.ConfirmOpenPackPanel confirmPanel;
	}
}
