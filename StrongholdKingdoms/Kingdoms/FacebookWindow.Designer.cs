namespace Kingdoms
{
	// Token: 0x020001AE RID: 430
	[global::System.Security.Permissions.PermissionSet(global::System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	public partial class FacebookWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x0600104D RID: 4173 RVA: 0x00011F36 File Offset: 0x00010136
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0011B10C File Offset: 0x0011930C
		private void InitializeComponent()
		{
			this.webBrowser1 = new global::Kingdoms.ExtendedWebBrowser();
			base.SuspendLayout();
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new global::System.Drawing.Point(2, 32);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new global::System.Drawing.Size(919, 585);
			this.webBrowser1.TabIndex = 13;
			this.webBrowser1.DocumentCompleted += new global::System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(923, 619);
			base.Controls.Add(this.webBrowser1);
			base.Name = "FacebookWindow";
			base.ShowClose = true;
			this.Text = "FacebookWindow";
			base.Load += new global::System.EventHandler(this.FacebookWindow_Load);
			base.Controls.SetChildIndex(this.webBrowser1, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04001668 RID: 5736
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04001669 RID: 5737
		private global::Kingdoms.ExtendedWebBrowser webBrowser1;
	}
}
