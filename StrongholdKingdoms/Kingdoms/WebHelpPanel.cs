using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004F3 RID: 1267
	public class WebHelpPanel : UserControl, IDockableControl
	{
		// Token: 0x0600301C RID: 12316 RVA: 0x0002305E File Offset: 0x0002125E
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600301D RID: 12317 RVA: 0x0002306E File Offset: 0x0002126E
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600301E RID: 12318 RVA: 0x0002307E File Offset: 0x0002127E
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600301F RID: 12319 RVA: 0x00023090 File Offset: 0x00021290
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06003020 RID: 12320 RVA: 0x0002309D File Offset: 0x0002129D
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
		}

		// Token: 0x06003021 RID: 12321 RVA: 0x000230AB File Offset: 0x000212AB
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06003022 RID: 12322 RVA: 0x000230B8 File Offset: 0x000212B8
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06003023 RID: 12323 RVA: 0x000230C5 File Offset: 0x000212C5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06003024 RID: 12324 RVA: 0x00279054 File Offset: 0x00277254
		private void InitializeComponent()
		{
			this.geckoWebBrowser1 = new KingdomsBrowserGecko();
			base.SuspendLayout();
			this.geckoWebBrowser1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.geckoWebBrowser1.Location = new Point(0, 0);
			this.geckoWebBrowser1.MinimumSize = new Size(20, 20);
			this.geckoWebBrowser1.Name = "geckoWebBrowser1";
			this.geckoWebBrowser1.Size = new Size(413, 350);
			this.geckoWebBrowser1.TabIndex = 280;
			this.geckoWebBrowser1.ClientFeedback += this.geckoWebBrowser1_ClientFeedback;
			base.Controls.Add(this.geckoWebBrowser1);
			base.Name = "WebHelpPanel";
			base.Size = new Size(413, 350);
			base.ResumeLayout(false);
		}

		// Token: 0x06003025 RID: 12325 RVA: 0x000230E4 File Offset: 0x000212E4
		public WebHelpPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
		}

		// Token: 0x06003026 RID: 12326 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void recreateWebControl()
		{
		}

		// Token: 0x06003027 RID: 12327 RVA: 0x000230FE File Offset: 0x000212FE
		public void openPage(string address)
		{
			this.geckoWebBrowser1.Navigate(new Uri(address));
		}

		// Token: 0x06003028 RID: 12328 RVA: 0x00279130 File Offset: 0x00277330
		public void openUrl(string address)
		{
			this.recreateWebControl();
			if (!string.IsNullOrEmpty(address) && !address.Equals("about:blank"))
			{
				if (!address.StartsWith("http://") && !address.StartsWith("https://"))
				{
					address = "http://" + address;
				}
				try
				{
					Cursor.Current = Cursors.WaitCursor;
					IDictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(new KeyValuePair<string, string>("uid", RemoteServices.Instance.UserGuid.ToString("N")));
					dictionary.Add(new KeyValuePair<string, string>("sid", RemoteServices.Instance.SessionGuid.ToString("N")));
					int num = -1;
					int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
					if (!GameEngine.Instance.World.isCapital(selectedMenuVillage))
					{
						num = selectedMenuVillage;
					}
					dictionary.Add(new KeyValuePair<string, string>("CurrentvillageID", num.ToString()));
					dictionary.Add(new KeyValuePair<string, string>("CurrentWorldID", GameEngine.Instance.World.GetGlobalWorldID().ToString()));
					this.geckoWebBrowser1.Navigate(new Uri(address), dictionary);
					Cursor.Current = Cursors.Default;
				}
				catch (UriFormatException)
				{
				}
			}
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void GoBack()
		{
		}

		// Token: 0x0600302A RID: 12330 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void GoForward()
		{
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void webBrowserHelp_CanGoBackChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600302C RID: 12332 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void webBrowserHelp_CanGoForwardChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600302D RID: 12333 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void webBrowserHelp_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
		}

		// Token: 0x0600302E RID: 12334 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void webBrowserHelp_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
		}

		// Token: 0x0600302F RID: 12335 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void updateCurrentCardsCallback(UpdateCurrentCards_ReturnType returnData)
		{
		}

		// Token: 0x06003030 RID: 12336 RVA: 0x00279278 File Offset: 0x00277478
		private void geckoWebBrowser1_ClientFeedback(object sender, EventArgs e)
		{
			foreach (string text in this.geckoWebBrowser1.PageValues.Keys)
			{
				if (text != "")
				{
					string text2 = this.geckoWebBrowser1.PageValues[text];
					if (text.Trim().ToLowerInvariant() == "openlink")
					{
						text2 = text2.Replace("%2F", "/");
						Process.Start("http://" + text2);
					}
				}
			}
		}

		// Token: 0x04003C8C RID: 15500
		private DockableControl dockableControl;

		// Token: 0x04003C8D RID: 15501
		private IContainer components;

		// Token: 0x04003C8E RID: 15502
		private KingdomsBrowserGecko geckoWebBrowser1;
	}
}
