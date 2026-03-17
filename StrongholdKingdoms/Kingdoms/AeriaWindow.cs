using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000BE RID: 190
	[ComVisible(true)]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public partial class AeriaWindow : MyFormBase
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000533 RID: 1331 RVA: 0x00063808 File Offset: 0x00061A08
		// (remove) Token: 0x06000534 RID: 1332 RVA: 0x00063840 File Offset: 0x00061A40
		public event AeriaEventHandler login;

		// Token: 0x06000537 RID: 1335 RVA: 0x000639D0 File Offset: 0x00061BD0
		public AeriaWindow()
		{
			this.InitializeComponent();
			this.Text = (base.Title = SK.Text("AERIA_LOGIN", "Aeria Games Login"));
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			this.webBrowser1.ObjectForScripting = this;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0000AC8E File Offset: 0x00008E8E
		public void AeriaLogin(object userguid, object aeriatoken)
		{
			this.onlogin(new AeriaEventArgs((string)userguid, (string)aeriatoken));
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0000ACA7 File Offset: 0x00008EA7
		protected virtual void onlogin(AeriaEventArgs e)
		{
			this.login(this, e);
			this.aeriaLogin(e.userguid);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00063A38 File Offset: 0x00061C38
		public static void ShowAeriaLogin(string url, string urlFirst, ProfileLoginWindow parent, AeriaEventHandler loginCallback)
		{
			if (AeriaWindow.instance != null)
			{
				try
				{
					AeriaWindow.instance.Close();
					AeriaWindow.instance = null;
				}
				catch (Exception)
				{
				}
			}
			AeriaWindow.vidLoaded = false;
			AeriaWindow aeriaWindow = new AeriaWindow();
			AeriaWindow.m_parent = parent;
			Point location = new Point(parent.Location.X + (parent.Width - aeriaWindow.Width) / 2, parent.Location.Y + (parent.Height - aeriaWindow.Height) / 2);
			aeriaWindow.closeCallback = new MyFormBase.MFBClose(AeriaWindow.closing);
			aeriaWindow.Location = location;
			aeriaWindow.Show(parent);
			AeriaWindow.instance = aeriaWindow;
			AeriaWindow aeriaWindow2 = AeriaWindow.instance;
			aeriaWindow2.login = (AeriaEventHandler)Delegate.Combine(aeriaWindow2.login, loginCallback);
			while (!AeriaWindow.vidLoaded)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			Thread.Sleep(500);
			if (urlFirst.Length > 0)
			{
				AeriaWindow.futureURL = url;
				url = urlFirst;
			}
			aeriaWindow.webBrowser1.Navigate(url);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0000ACC2 File Offset: 0x00008EC2
		public static void closing()
		{
			if (AeriaWindow.m_parent != null)
			{
				AeriaWindow.m_parent.aeriaClose();
			}
			AeriaWindow.instance = null;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0000ACDB File Offset: 0x00008EDB
		private void aeriaLogin(string userGuid)
		{
			if (AeriaWindow.m_parent != null)
			{
				AeriaWindow.m_parent.aeriaLogin(userGuid, "");
			}
			base.Close();
			AeriaWindow.instance = null;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000AD00 File Offset: 0x00008F00
		private void AeriaWindow_Load(object sender, EventArgs e)
		{
			AeriaWindow.vidLoaded = true;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00063B48 File Offset: 0x00061D48
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (AeriaWindow.futureURL.Length > 0)
			{
				for (int i = 0; i < 50; i++)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
				string urlString = AeriaWindow.futureURL;
				AeriaWindow.futureURL = "";
				this.webBrowser1.Navigate(urlString);
			}
		}

		// Token: 0x04000602 RID: 1538
		private static AeriaWindow instance = null;

		// Token: 0x04000603 RID: 1539
		private static ProfileLoginWindow m_parent = null;

		// Token: 0x04000604 RID: 1540
		public static bool vidLoaded = false;

		// Token: 0x04000605 RID: 1541
		public static string futureURL = "";
	}
}
