namespace Kingdoms
{
	// Token: 0x020000E3 RID: 227
	[global::System.Security.Permissions.PermissionSet(global::System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	public partial class BigPointWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x060006A6 RID: 1702 RVA: 0x0000B85F File Offset: 0x00009A5F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0008E55C File Offset: 0x0008C75C
		private void InitializeComponent()
		{
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			this.panel5 = new global::Kingdoms.BPForgottenPasswordPanel();
			base.SuspendLayout();
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new global::System.Drawing.Point(2, 32);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new global::System.Drawing.Size(519, 525);
			this.webBrowser1.TabIndex = 13;
			this.webBrowser1.DocumentCompleted += new global::System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			this.panel5.BackColor = global::System.Drawing.Color.White;
			this.panel5.Location = new global::System.Drawing.Point(2, 556);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(519, 35);
			this.panel5.TabIndex = 14;
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::System.Drawing.Color.FromArgb(0, 0, 0);
			base.ClientSize = new global::System.Drawing.Size(523, 593);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.webBrowser1);
			base.Name = "BigPointWindow";
			base.ShowBar = true;
			base.ShowClose = true;
			this.Text = "BigPointWindow";
			base.Load += new global::System.EventHandler(this.BigPointWindow_Load);
			base.Controls.SetChildIndex(this.webBrowser1, 0);
			base.Controls.SetChildIndex(this.panel5, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x0400090A RID: 2314
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400090B RID: 2315
		private global::System.Windows.Forms.WebBrowser webBrowser1;

		// Token: 0x0400090C RID: 2316
		private global::Kingdoms.BPForgottenPasswordPanel panel5;
	}
}
