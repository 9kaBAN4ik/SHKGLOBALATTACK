using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000B5 RID: 181
	public partial class AdminInfoPopup : MyFormBase
	{
		// Token: 0x060004F2 RID: 1266 RVA: 0x0000A91E File Offset: 0x00008B1E
		public AdminInfoPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0000A941 File Offset: 0x00008B41
		public static void setMessage(string message)
		{
			AdminInfoPopup.adminMessage = message;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0005F8B4 File Offset: 0x0005DAB4
		public static void showMessage()
		{
			if (AdminInfoPopup.adminMessage.StartsWith("http://") || AdminInfoPopup.adminMessage.StartsWith("https://"))
			{
				string[] array = AdminInfoPopup.adminMessage.Split(AdminInfoPopup.delims);
				if (array.Length != 0)
				{
					VideoWindow.ShowVideo(array[0], false);
					return;
				}
			}
			AdminInfoPopup adminInfoPopup = new AdminInfoPopup();
			adminInfoPopup.btnSend.Visible = false;
			adminInfoPopup.textBox1.ReadOnly = true;
			adminInfoPopup.textBox1.Text = AdminInfoPopup.adminMessage;
			adminInfoPopup.init();
			adminInfoPopup.Show();
			adminInfoPopup.btnExit.Focus();
			AdminInfoPopup.lastPopup = adminInfoPopup;
			RemoteServices.Instance.ShowAdminMessage = false;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0005F958 File Offset: 0x0005DB58
		public static void showAdminEdit()
		{
			AdminInfoPopup adminInfoPopup = new AdminInfoPopup();
			adminInfoPopup.btnSend.Visible = true;
			adminInfoPopup.textBox1.ReadOnly = false;
			adminInfoPopup.textBox1.Text = AdminInfoPopup.adminMessage;
			adminInfoPopup.init();
			adminInfoPopup.Show();
			AdminInfoPopup.lastPopup = adminInfoPopup;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0005F9A8 File Offset: 0x0005DBA8
		public void init()
		{
			this.btnExit.Text = SK.Text("Admin_Exit", "Exit");
			string text = this.Text = (base.Title = SK.Text("Admin_Message", "Admin's Message"));
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0000A949 File Offset: 0x00008B49
		private void btnExit_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("AdminInfoPopup_close");
			base.Close();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0000A960 File Offset: 0x00008B60
		private void btnSend_Click(object sender, EventArgs e)
		{
			RemoteServices.Instance.SetAdminMessage(AdminInfoPopup.lastPopup.textBox1.Text, 0);
			AdminInfoPopup.adminMessage = AdminInfoPopup.lastPopup.textBox1.Text;
		}

		// Token: 0x040005B7 RID: 1463
		private static string adminMessage = "";

		// Token: 0x040005B8 RID: 1464
		private static AdminInfoPopup lastPopup = null;

		// Token: 0x040005B9 RID: 1465
		private static char[] delims = new char[]
		{
			'\n',
			'\r',
			' '
		};
	}
}
