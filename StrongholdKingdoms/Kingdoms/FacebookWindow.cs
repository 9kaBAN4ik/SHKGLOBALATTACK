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
	// Token: 0x020001AE RID: 430
	[ComVisible(true)]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public partial class FacebookWindow : MyFormBase
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600104B RID: 4171 RVA: 0x0011B09C File Offset: 0x0011929C
		// (remove) Token: 0x0600104C RID: 4172 RVA: 0x0011B0D4 File Offset: 0x001192D4
		public event FacebookEventHandler login;

		// Token: 0x0600104F RID: 4175 RVA: 0x0011B264 File Offset: 0x00119464
		public FacebookWindow()
		{
			this.InitializeComponent();
			this.Text = (base.Title = SK.Text("Facebook_LOGIN", "Facebook Login"));
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			this.webBrowser1.ObjectForScripting = this;
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x00011F55 File Offset: 0x00010155
		public void IframeLogin(object userguid, object token)
		{
			this.onlogin(new FacebookEventArgs((string)userguid, (string)token));
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00011F6E File Offset: 0x0001016E
		protected virtual void onlogin(FacebookEventArgs e)
		{
			this.login(this, e);
			this.FacebookLogin(e.userguid);
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0011B2CC File Offset: 0x001194CC
		public static void ShowFacebookLogin(string url, string urlFirst, ProfileLoginWindow parent, FacebookEventHandler loginCallback)
		{
			if (FacebookWindow.instance != null)
			{
				try
				{
					FacebookWindow.instance.Close();
					FacebookWindow.instance = null;
				}
				catch (Exception)
				{
				}
			}
			FacebookWindow.vidLoaded = false;
			FacebookWindow facebookWindow = new FacebookWindow();
			FacebookWindow.m_parent = parent;
			Point location = new Point(parent.Location.X + (parent.Width - facebookWindow.Width) / 2, parent.Location.Y + (parent.Height - facebookWindow.Height) / 2);
			facebookWindow.closeCallback = new MyFormBase.MFBClose(FacebookWindow.closing);
			facebookWindow.Location = location;
			facebookWindow.Show(parent);
			FacebookWindow.instance = facebookWindow;
			if (loginCallback != null)
			{
				FacebookWindow facebookWindow2 = FacebookWindow.instance;
				facebookWindow2.login = (FacebookEventHandler)Delegate.Combine(facebookWindow2.login, loginCallback);
			}
			while (!FacebookWindow.vidLoaded)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			Thread.Sleep(500);
			if (urlFirst.Length > 0)
			{
				FacebookWindow.futureURL = url;
				url = urlFirst;
			}
			facebookWindow.webBrowser1.Navigate(url);
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0011B3E0 File Offset: 0x001195E0
		public static void ShowFacebookLogin(string url, string urlFirst, Form parent)
		{
			if (FacebookWindow.instance != null)
			{
				try
				{
					FacebookWindow.instance.Close();
					FacebookWindow.instance = null;
				}
				catch (Exception)
				{
				}
			}
			FacebookWindow.vidLoaded = false;
			FacebookWindow facebookWindow = new FacebookWindow();
			FacebookWindow.m_parent = null;
			Form form = facebookWindow;
			Point location = new Point(parent.Location.X + (parent.Width - facebookWindow.Width) / 2, parent.Location.Y + (parent.Height - facebookWindow.Height) / 2);
			form.Location = location;
			facebookWindow.Show(parent);
			FacebookWindow.instance = facebookWindow;
			while (!FacebookWindow.vidLoaded)
			{
				Thread.Sleep(100);
				Application.DoEvents();
			}
			Thread.Sleep(500);
			if (urlFirst.Length > 0)
			{
				FacebookWindow.futureURL = url;
				url = urlFirst;
			}
			facebookWindow.webBrowser1.Navigate(url);
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x00011F89 File Offset: 0x00010189
		public static void closing()
		{
			if (FacebookWindow.m_parent != null)
			{
				FacebookWindow.m_parent.FacebookClose();
			}
			FacebookWindow.instance = null;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x00011FA2 File Offset: 0x000101A2
		private void FacebookLogin(string userGuid)
		{
			if (FacebookWindow.m_parent != null)
			{
				FacebookWindow.m_parent.FacebookLogin(userGuid, "");
			}
			base.Close();
			FacebookWindow.instance = null;
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00011FC7 File Offset: 0x000101C7
		private void FacebookWindow_Load(object sender, EventArgs e)
		{
			FacebookWindow.vidLoaded = true;
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0011B4C4 File Offset: 0x001196C4
		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (FacebookWindow.futureURL.Length > 0)
			{
				for (int i = 0; i < 50; i++)
				{
					Thread.Sleep(100);
					Application.DoEvents();
				}
				string urlString = FacebookWindow.futureURL;
				FacebookWindow.futureURL = "";
				this.webBrowser1.Navigate(urlString);
			}
		}

		// Token: 0x0400166A RID: 5738
		private static FacebookWindow instance = null;

		// Token: 0x0400166B RID: 5739
		private static ProfileLoginWindow m_parent = null;

		// Token: 0x0400166C RID: 5740
		public static bool vidLoaded = false;

		// Token: 0x0400166D RID: 5741
		public static string futureURL = "";
	}
}
