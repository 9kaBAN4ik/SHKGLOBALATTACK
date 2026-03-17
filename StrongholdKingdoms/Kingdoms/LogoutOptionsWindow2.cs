using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;
using StatTracking;

namespace Kingdoms
{
	// Token: 0x02000215 RID: 533
	public partial class LogoutOptionsWindow2 : Form
	{
		// Token: 0x0600165F RID: 5727 RVA: 0x00160BD0 File Offset: 0x0015EDD0
		public LogoutOptionsWindow2()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			base.TransparencyKey = Color.FromArgb(255, 255, 0, 255);
			this.BackColor = base.TransparencyKey;
		}

		// Token: 0x06001660 RID: 5728 RVA: 0x00017B0B File Offset: 0x00015D0B
		public void init(bool normalLogout)
		{
			this.currentPanel.init(normalLogout, false);
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x00017B1A File Offset: 0x00015D1A
		public void init(bool normalLogout, bool advertOnly)
		{
			this.currentPanel.init(normalLogout, advertOnly);
		}

		// Token: 0x06001662 RID: 5730 RVA: 0x00017B29 File Offset: 0x00015D29
		public void update()
		{
			this.currentPanel.update();
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x00160C28 File Offset: 0x0015EE28
		private void Logout_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !LogoutOptionsWindow2.closing)
			{
				LogoutOptionsWindow2.closing = true;
				this.currentPanel.vacationModeCloseCheck();
				this.currentPanel.closePopup();
				StatTrackingClient.Instance().ActivateTrigger(26, false);
				InterfaceMgr.Instance.closeLogoutWindow();
			}
		}

		// Token: 0x040026A5 RID: 9893
		public static bool closing;
	}
}
