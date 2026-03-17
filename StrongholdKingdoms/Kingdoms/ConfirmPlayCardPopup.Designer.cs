namespace Kingdoms
{
	// Token: 0x0200013B RID: 315
	public partial class ConfirmPlayCardPopup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000BA2 RID: 2978 RVA: 0x0000E9B6 File Offset: 0x0000CBB6
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000BA3 RID: 2979 RVA: 0x000E5B18 File Offset: 0x000E3D18
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.ConfirmPlayCardPopup));
			this.confirmPanel = new global::Kingdoms.ConfirmPlayCardPanel();
			base.SuspendLayout();
			global::System.Drawing.Size size = new global::System.Drawing.Size(400, 400);
			this.confirmPanel.Location = new global::System.Drawing.Point(0, 0);
			this.confirmPanel.Name = "confirmPanel";
			this.confirmPanel.Size = size;
			this.confirmPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = size;
			base.ControlBox = false;
			base.Controls.Add(this.confirmPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ConfirmPlayCardPopup";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ConfirmPlayCardPopup";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.ConfirmPlayCardPopup_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000FB0 RID: 4016
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000FB1 RID: 4017
		private global::Kingdoms.ConfirmPlayCardPanel confirmPanel;
	}
}
