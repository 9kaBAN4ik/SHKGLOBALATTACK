using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020000B6 RID: 182
	public partial class AdminIngameMessage : MyFormBase
	{
		// Token: 0x060004FE RID: 1278 RVA: 0x000601B8 File Offset: 0x0005E3B8
		public AdminIngameMessage()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.Text = (base.Title = "Admin Ingame Message");
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000601FC File Offset: 0x0005E3FC
		private void btnSend_Click(object sender, EventArgs e)
		{
			int num = this.getInt32FromString(this.tbDuration.Text);
			if (num < 1)
			{
				num = 1;
			}
			RemoteServices.Instance.SetAdminMessage(this.tbMaintenanceMessage.Text, 1000 + num);
			base.Close();
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000A9F6 File Offset: 0x00008BF6
		public int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return 0;
			}
			return Convert.ToInt32(text);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0000AA08 File Offset: 0x00008C08
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("AdminIngameMessage_close");
			base.Close();
		}
	}
}
