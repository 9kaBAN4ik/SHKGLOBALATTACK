using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200013C RID: 316
	public partial class ConnectionErrorWindow : MyFormBase
	{
		// Token: 0x06000BA4 RID: 2980 RVA: 0x000E5C24 File Offset: 0x000E3E24
		public ConnectionErrorWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.lblMessage.Font = FontManager.GetFont("Microsoft Sans Serif", 9f, FontStyle.Bold);
			this.Text = (base.Title = SK.Text("ConnectioError_Title", "Problem with Connection to Server"));
			this.btnLogout.Text = SK.Text("ConnectioError_logout", "Quit to Login Screen");
			this.lblMessage.Text = SK.Text("ConnectioError_message", "Your Stronghold Kingdoms client is having problems connecting to the game servers. Trying to connect to the server again...");
			base.ShowClose = false;
		}

		// Token: 0x06000BA5 RID: 2981 RVA: 0x0000E9D5 File Offset: 0x0000CBD5
		public void init()
		{
			this.startTime = DateTime.Now;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x000E5CDC File Offset: 0x000E3EDC
		public void update()
		{
			if ((DateTime.Now - this.startTime).TotalMinutes > 10.0)
			{
				GameEngine.Instance.forceLogout();
				return;
			}
			if ((DateTime.Now - this.lastRetry).TotalSeconds > 30.0)
			{
				RemoteServices.Instance.clearQueues();
				this.lastRetry = DateTime.Now;
				RemoteServices.Instance.LeaderBoard(-3, -1, -1, DateTime.MinValue);
			}
		}

		// Token: 0x06000BA7 RID: 2983 RVA: 0x0000E9E2 File Offset: 0x0000CBE2
		private void btnLogout_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.forceLogout();
		}

		// Token: 0x04000FB2 RID: 4018
		private static ConnectionErrorWindow popup;

		// Token: 0x04000FB3 RID: 4019
		private DateTime lastRetry = DateTime.MinValue;

		// Token: 0x04000FB4 RID: 4020
		private DateTime startTime = DateTime.MinValue;
	}
}
