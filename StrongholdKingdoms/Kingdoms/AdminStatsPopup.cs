using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000B7 RID: 183
	public partial class AdminStatsPopup : MyFormBase
	{
		// Token: 0x06000504 RID: 1284 RVA: 0x0000AA3E File Offset: 0x00008C3E
		public AdminStatsPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00060AF8 File Offset: 0x0005ECF8
		public void init(GetAdminStats_ReturnType returnData)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			string text = this.Text = (base.Title = "Admin Info");
			this.lblNumUsersLoggedIn.Text = returnData.usersLoggedIn.ToString("N", nfi);
			this.lblLast24.Text = returnData.usersLogged24Hours.ToString("N", nfi);
			this.lblLast3.Text = returnData.usersLogged3Days.ToString("N", nfi);
			this.lblLast7.Text = returnData.usersLogged7Days.ToString("N", nfi);
			this.lblNumActiveUsers.Text = returnData.usersActiveLastHour.ToString("N", nfi);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00009024 File Offset: 0x00007224
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
