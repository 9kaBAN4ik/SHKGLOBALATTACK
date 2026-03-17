namespace Kingdoms
{
	// Token: 0x02000215 RID: 533
	public partial class LogoutOptionsWindow2 : global::System.Windows.Forms.Form
	{
		// Token: 0x06001664 RID: 5732 RVA: 0x00017B36 File Offset: 0x00015D36
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001665 RID: 5733 RVA: 0x00160C80 File Offset: 0x0015EE80
		private void InitializeComponent()
		{
			new global::System.ComponentModel.ComponentResourceManager(typeof(global::Kingdoms.LogoutOptionsWindow2));
			this.currentPanel = new global::Kingdoms.LogoutPanel();
			base.SuspendLayout();
			this.currentPanel.Location = new global::System.Drawing.Point(0, 0);
			this.currentPanel.Name = "logoutPanel";
			this.currentPanel.Size = new global::System.Drawing.Size(1000, 600);
			this.currentPanel.StoredGraphics = null;
			this.currentPanel.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1000, 600);
			base.ControlBox = false;
			base.Controls.Add(this.currentPanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = global::Kingdoms.Properties.Resources.shk_icon;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "LogoutOptionsWindow2";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "LogoutOptionsWindow2";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Logout_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x040026A6 RID: 9894
		private global::System.ComponentModel.IContainer components;

		// Token: 0x040026A7 RID: 9895
		private global::Kingdoms.LogoutPanel currentPanel;
	}
}
