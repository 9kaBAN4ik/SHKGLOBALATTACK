using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Kingdoms
{
	// Token: 0x0200048A RID: 1162
	public partial class SendMonkWindow : Form
	{
		// Token: 0x06002A4D RID: 10829 RVA: 0x0001F16F File Offset: 0x0001D36F
		public SendMonkWindow()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06002A4E RID: 10830 RVA: 0x0001F192 File Offset: 0x0001D392
		public void init(int villageID)
		{
			this.sendMonkPanel.init(villageID);
		}

		// Token: 0x06002A4F RID: 10831 RVA: 0x0001F1A0 File Offset: 0x0001D3A0
		public void update()
		{
			this.sendMonkPanel.update();
		}

		// Token: 0x06002A50 RID: 10832 RVA: 0x0001F1AD File Offset: 0x0001D3AD
		public void villageLoaded(int villageID)
		{
			this.sendMonkPanel.onVillageLoadUpdate(villageID, true);
		}

		// Token: 0x06002A51 RID: 10833 RVA: 0x0020EE38 File Offset: 0x0020D038
		private void SendMonkPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseReason closeReason = e.CloseReason;
			if (closeReason == CloseReason.UserClosing && !this.closing)
			{
				this.closing = true;
				InterfaceMgr.Instance.closeSendMonkWindow();
			}
		}

		// Token: 0x04003423 RID: 13347
		private bool closing;
	}
}
