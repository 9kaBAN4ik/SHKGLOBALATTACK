using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x02000214 RID: 532
	public partial class LoginHistoryPopup : Form
	{
		// Token: 0x06001659 RID: 5721 RVA: 0x00017A87 File Offset: 0x00015C87
		public LoginHistoryPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.loginHistory = GameEngine.Instance.World.getLoginHistory(true);
			this.updateList();
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x00017AC6 File Offset: 0x00015CC6
		public void update()
		{
			if (this.loginHistory == null)
			{
				this.loginHistory = GameEngine.Instance.World.getLoginHistory(false);
				this.updateList();
			}
		}

		// Token: 0x0600165B RID: 5723 RVA: 0x00160804 File Offset: 0x0015EA04
		public void updateList()
		{
			if (this.loginHistory != null)
			{
				this.pnlList.Controls.Clear();
				int num = 0;
				foreach (LoginHistoryInfo loginHistoryInfo in this.loginHistory)
				{
					LoginHistoryPanelLine loginHistoryPanelLine = new LoginHistoryPanelLine();
					loginHistoryPanelLine.Location = new Point(0, num);
					loginHistoryPanelLine.init(loginHistoryInfo.ipAddress, loginHistoryInfo.LastLogin, loginHistoryInfo.duration);
					this.pnlList.Controls.Add(loginHistoryPanelLine);
					num += loginHistoryPanelLine.Height;
				}
				this.pnlList.ResumeLayout(false);
				this.pnlList.PerformLayout();
			}
		}

		// Token: 0x0600165C RID: 5724 RVA: 0x00009024 File Offset: 0x00007224
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0400269E RID: 9886
		private List<LoginHistoryInfo> loginHistory;
	}
}
