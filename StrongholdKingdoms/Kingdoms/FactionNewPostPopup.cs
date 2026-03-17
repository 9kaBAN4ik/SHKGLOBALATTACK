using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001CE RID: 462
	public partial class FactionNewPostPopup : MyFormBase
	{
		// Token: 0x0600115E RID: 4446 RVA: 0x00012FBA File Offset: 0x000111BA
		public FactionNewPostPopup()
		{
			this.InitializeComponent();
			this.btnOK.Enabled = false;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x00125E40 File Offset: 0x00124040
		public void init(long threadID, IForumReplyParent parent, string heading)
		{
			this.lblTopic.Text = SK.Text("FORUMS_Topic", "Topic");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			string text = base.Title = (this.Text = SK.Text("FORUMS_New_Post", "New Post"));
			this.ThreadID = threadID;
			this.m_parent = parent;
			this.tbHeading.Text = heading;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x00012FF1 File Offset: 0x000111F1
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewPostPopup_cancel");
			base.Close();
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x00013008 File Offset: 0x00011208
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewPostPopup_ok");
			if (this.m_parent != null)
			{
				this.m_parent.newPost(this.ThreadID, this.tbMainText.Text);
			}
			base.Close();
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x00013043 File Offset: 0x00011243
		private void tbMainText_TextChanged(object sender, EventArgs e)
		{
			if (this.tbMainText.Text.Length > 0)
			{
				this.btnOK.Enabled = true;
				return;
			}
			this.btnOK.Enabled = false;
		}

		// Token: 0x0400178B RID: 6027
		private long ThreadID = -1L;

		// Token: 0x0400178C RID: 6028
		private IForumReplyParent m_parent;
	}
}
