using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001A3 RID: 419
	public partial class EmailOptInPopup : MyFormBase
	{
		// Token: 0x06001000 RID: 4096 RVA: 0x0011768C File Offset: 0x0011588C
		public EmailOptInPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			base.ShowClose = false;
			this.cbMailOptIn.Text = SK.Text("EMAIL_OptIn", "Please Tick here if you would like us to contact you via email with information related to Stronghold Kingdoms, including exclusive offers and competitions.");
			this.cbMailOptIn.Checked = false;
			base.Title = (this.Text = SK.Text("EMAIL_OptInHeader", "Stronghold Kingdoms Email Preferences"));
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00011B9D File Offset: 0x0000FD9D
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MailUserBlockPopup_close");
			if (this.m_Parent != null)
			{
				this.m_Parent.SetEmailOptInState(this.cbMailOptIn.Checked);
			}
			base.Close();
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void cbMailOptIn_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04001617 RID: 5655
		public ProfileLoginWindow m_Parent;
	}
}
