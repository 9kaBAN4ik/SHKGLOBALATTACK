using System;
using System.Threading;
using System.Windows.Forms;

namespace Upgrade.Services
{
	// Token: 0x0200003C RID: 60
	internal class FeedService : ABaseService, IDisposable
	{
		// Token: 0x06000233 RID: 563 RVA: 0x000092D4 File Offset: 0x000074D4
		internal FeedService(WebBrowser webBrowser, NotifyIcon notifyIcon, Log log) : base(log)
		{
			this.WebBrowserFeed = webBrowser;
			this.WindowsNotifyIcon = notifyIcon;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000092F2 File Offset: 0x000074F2
		public override void ConcreteAction()
		{
			this.WebBrowserFeed.Refresh();
			base.SleepOrExit(10000);
			DX.ControlForm.BeginInvoke(new MethodInvoker(delegate()
			{
				this.WebBrowser_DocumentCompleted();
			}));
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00048CA4 File Offset: 0x00046EA4
		private void WebBrowser_DocumentCompleted()
		{
			try
			{
				HtmlElement elementById = this.WebBrowserFeed.Document.GetElementById("revision");
				if (elementById == null)
				{
					this.Log(LNG.Print("Unknown feed revision"), ControlForm.Tab.Main, false);
				}
				else
				{
					int num = int.Parse(elementById.GetAttribute("value"));
					this.Log(string.Format("{0}: {1}", LNG.Print("Feed revision"), num), ControlForm.Tab.Main, false);
					if (this.FeedRevision != 0 && num > this.FeedRevision && this.ShouldNotify)
					{
						this.WindowsNotifyIcon.Visible = true;
						this.WindowsNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
						this.WindowsNotifyIcon.BalloonTipText = "SHKEducations Bot Feed Update";
						this.WindowsNotifyIcon.BalloonTipTitle = "SHK Bot";
						this.WindowsNotifyIcon.ShowBalloonTip(5000);
						this.Log(LNG.Print("Pushing notification"), ControlForm.Tab.Main, false);
						this._closeNotifyIconTimer = new System.Threading.Timer(delegate(object state)
						{
							this.WindowsNotifyIcon.Visible = false;
						}, null, 10000, 0);
						try
						{
							ControlForm controlForm = DX.ControlForm;
							if (controlForm != null)
							{
								controlForm.SelectTab("tabPage_Feed");
							}
						}
						catch (Exception ex)
						{
							DX.ShowErrorMessage(ex);
						}
					}
					this.FeedRevision = num;
				}
			}
			catch (Exception ex2)
			{
				ABaseService.ReportError(ex2, ControlForm.Tab.Main);
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00009322 File Offset: 0x00007522
		public void Dispose()
		{
			this.WebBrowserFeed.Dispose();
			this._closeNotifyIconTimer.Dispose();
			this.WindowsNotifyIcon.Dispose();
		}

		// Token: 0x040003BB RID: 955
		internal bool ShouldNotify = true;

		// Token: 0x040003BC RID: 956
		private int FeedRevision;

		// Token: 0x040003BD RID: 957
		private NotifyIcon WindowsNotifyIcon;

		// Token: 0x040003BE RID: 958
		private System.Threading.Timer _closeNotifyIconTimer;

		// Token: 0x040003BF RID: 959
		private WebBrowser WebBrowserFeed;
	}
}
