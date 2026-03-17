namespace Kingdoms
{
	// Token: 0x020000BE RID: 190
	[global::System.Security.Permissions.PermissionSet(global::System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
	public partial class AeriaWindow : global::Kingdoms.MyFormBase
	{
		// Token: 0x06000535 RID: 1333 RVA: 0x0000AC6F File Offset: 0x00008E6F
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00063878 File Offset: 0x00061A78
		private void InitializeComponent()
		{
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new global::System.Drawing.Point(2, 32);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new global::System.Drawing.Size(420, 440);
			this.webBrowser1.TabIndex = 13;
			this.webBrowser1.DocumentCompleted += new global::System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = global::ARGBColors.Black;
			base.ClientSize = new global::System.Drawing.Size(424, 474);
			base.Controls.Add(this.webBrowser1);
			base.Name = "AeriaWindow";
			base.ShowClose = true;
			this.Text = "AeriaWindow";
			base.Load += new global::System.EventHandler(this.AeriaWindow_Load);
			base.Controls.SetChildIndex(this.webBrowser1, 0);
			base.ResumeLayout(false);
		}

		// Token: 0x04000600 RID: 1536
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000601 RID: 1537
		private global::System.Windows.Forms.WebBrowser webBrowser1;
	}
}
