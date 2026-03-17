using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001C9 RID: 457
	public partial class FactionNewForumPopup : MyFormBase
	{
		// Token: 0x06001131 RID: 4401 RVA: 0x00012C77 File Offset: 0x00010E77
		public FactionNewForumPopup()
		{
			this.InitializeComponent();
			this.btnOK.Enabled = false;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x001247A0 File Offset: 0x001229A0
		public void init(FactionNewForumPanel parent)
		{
			this.lblTopic.Text = SK.Text("FORUMS_Sub_Name", "Forum Sub Name");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			string text = base.Title = (this.Text = SK.Text("FORUMS_New_Sub_Forum", "New Sub Forum"));
			this.m_parent = parent;
			this.btnOK.Enabled = false;
			this.tbForumName.Focus();
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x00012CA6 File Offset: 0x00010EA6
		public void setFocus()
		{
			this.tbForumName.Focus();
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x00012CB4 File Offset: 0x00010EB4
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewForumPopup_cancel");
			base.Close();
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x00012CCB File Offset: 0x00010ECB
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewForumPopup_ok");
			if (this.m_parent != null)
			{
				this.m_parent.createNewForum(this.tbForumName.Text);
			}
			base.Close();
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x00012D00 File Offset: 0x00010F00
		private void tbForumName_TextChanged(object sender, EventArgs e)
		{
			if (this.tbForumName.Text.Length > 0)
			{
				this.btnOK.Enabled = true;
				return;
			}
			this.btnOK.Enabled = false;
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x00012D2E File Offset: 0x00010F2E
		private void tbForumName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13 && this.tbForumName.Text.Length > 0)
			{
				this.btnOK_Click(sender, e);
			}
		}

		// Token: 0x0400175D RID: 5981
		private FactionNewForumPanel m_parent;
	}
}
