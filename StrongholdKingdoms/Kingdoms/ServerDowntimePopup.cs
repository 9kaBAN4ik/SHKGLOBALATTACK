using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200048B RID: 1163
	public partial class ServerDowntimePopup : MyFormBase
	{
		// Token: 0x06002A52 RID: 10834 RVA: 0x0020EE6C File Offset: 0x0020D06C
		public ServerDowntimePopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.Text = (base.Title = SK.Text("ServerDowntime_Scheduled_DownTime", "Scheduled Server Maintenance"));
			this.lblHeader.Text = SK.Text("ServerDowntime_Planned", "There is a Planned Downtime in");
			this.lblMinutes.Text = "0 " + SK.Text("ServerDowntime_Minutes", "Minutes");
			this.lblExplanation.Text = SK.Text("ServerDowntime_Explanation", "Please ensure you have logged out safely in advance of this downtime.");
			this.lblHeader.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.lblMinutes.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
			this.lblExplanation.Font = FontManager.GetFont("Microsoft Sans Serif", 10f);
		}

		// Token: 0x06002A53 RID: 10835 RVA: 0x0020EF60 File Offset: 0x0020D160
		public void show(int minutes)
		{
			if (InterfaceMgr.Instance.ParentForm != null)
			{
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.Focus();
				InterfaceMgr.Instance.ParentForm.BringToFront();
				InterfaceMgr.Instance.ParentForm.Focus();
				InterfaceMgr.Instance.ParentForm.TopMost = false;
			}
			if (minutes <= 120)
			{
				this.lblMinutes.Text = minutes.ToString() + " " + SK.Text("ServerDowntime_Minutes", "Minutes");
			}
			else
			{
				this.lblMinutes.Text = (minutes / 60).ToString() + " " + SK.Text("VillageMapPanel_Hours", "Hours");
			}
			bool flag = false;
			Form activeForm = Form.ActiveForm;
			if (activeForm != null && activeForm.ProductName == base.ProductName && activeForm.WindowState == FormWindowState.Normal)
			{
				flag = true;
			}
			if (flag)
			{
				base.Show(activeForm);
			}
			else
			{
				base.Show();
			}
			base.TopMost = false;
			base.TopMost = true;
			base.Focus();
			base.BringToFront();
			base.Focus();
			base.TopMost = false;
		}

		// Token: 0x06002A54 RID: 10836 RVA: 0x0001F1BC File Offset: 0x0001D3BC
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("ServerDowntimePopup_close");
			GameEngine.Instance.clearDowntimePopup();
		}
	}
}
