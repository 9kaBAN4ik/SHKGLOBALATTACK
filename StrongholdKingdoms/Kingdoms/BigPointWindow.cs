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
	// Token: 0x020000E3 RID: 227
	[ComVisible(true)]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public partial class BigPointWindow : MyFormBase
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600069C RID: 1692 RVA: 0x0008E324 File Offset: 0x0008C524
		// (remove) Token: 0x0600069D RID: 1693 RVA: 0x0008E35C File Offset: 0x0008C55C
		public event BigPointEventHandler login;

		// Token: 0x0600069E RID: 1694 RVA: 0x0008E394 File Offset: 0x0008C594
		public BigPointWindow()
		{
			this.InitializeComponent();
			this.Text = (base.Title = SK.Text("BIGPOINT_LOGIN", "Bigpoint Login"));
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			this.webBrowser1.ObjectForScripting = this;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0000B7E5 File Offset: 0x000099E5
		public void IframeLogin(object userguid, object token)
		{
			this.onlogin(new BigPointEventArgs((string)userguid, (string)token));
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0000B7FE File Offset: 0x000099FE
		protected virtual void onlogin(BigPointEventArgs e)
		{
			this.login(this, e);
			this.bigpointLogin(e.userguid);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0008E3FC File Offset: 0x0008C5FC
		public static void ShowBigPointLogin(string url, string urlFirst, ProfileLoginWindow parent, BigPointEventHandler loginCallback)
		{
			if (BigPointWindow.instance != null)
			{
				try
				{
					BigPointWindow.instance.Close();
					BigPointWindow.instance = null;
				}
				catch (Exception)
				{
				}
			}
			BigPointWindow.vidLoaded = false;
			BigPointWindow bigPointWindow = new BigPointWindow();
			BigPointWindow.m_parent = parent;
			Point location = new Point(parent.Location.X + (parent.Width - bigPointWindow.Width) / 2, parent.Location.Y + (parent.Height - bigPointWindow.Height) / 2);
			bigPointWindow.closeCallback = new MyFormBase.MFBClose(BigPointWindow.closing);
			bigPointWindow.Location = location;
			bigPointWindow.Show(parent);
			BigPointWindow.instance = bigPointWindow;
			BigPointWindow bigPointWindow2 = BigPointWindow.instance;
			bigPointWindow2.login = (BigPointEventHandler)Delegate.Combine(bigPointWindow2.login, loginCallback);
			while (!BigPointWindow.vidLoaded)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			Thread.Sleep(500);
			if (urlFirst.Length > 0)
			{
				BigPointWindow.futureURL = url;
				url = urlFirst;
			}
			bigPointWindow.webBrowser1.Navigate(url);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0000B819 File Offset: 0x00009A19
		public static void closing()
		{
			if (BigPointWindow.m_parent != null)
			{
				BigPointWindow.m_parent.bigpointClose();
			}
			BigPointWindow.instance = null;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0000B832 File Offset: 0x00009A32
		private void bigpointLogin(string userGuid)
		{
			if (BigPointWindow.m_parent != null)
			{
				BigPointWindow.m_parent.bigpointLogin(userGuid, "");
			}
			base.Close();
			BigPointWindow.instance = null;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0000B857 File Offset: 0x00009A57
		private void BigPointWindow_Load(object sender, EventArgs e)
		{
			BigPointWindow.vidLoaded = true;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0008E50C File Offset: 0x0008C70C
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (BigPointWindow.futureURL.Length > 0)
			{
				for (int i = 0; i < 50; i++)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
				string urlString = BigPointWindow.futureURL;
				BigPointWindow.futureURL = "";
				this.webBrowser1.Navigate(urlString);
			}
		}

		// Token: 0x04000906 RID: 2310
		private static BigPointWindow instance = null;

		// Token: 0x04000907 RID: 2311
		private static ProfileLoginWindow m_parent = null;

		// Token: 0x04000908 RID: 2312
		public static bool vidLoaded = false;

		// Token: 0x04000909 RID: 2313
		public static string futureURL = "";
	}
}
