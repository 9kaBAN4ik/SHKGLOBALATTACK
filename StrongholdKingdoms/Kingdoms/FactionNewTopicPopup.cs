using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020001CF RID: 463
	public partial class FactionNewTopicPopup : MyFormBase
	{
		// Token: 0x06001167 RID: 4455 RVA: 0x000130AF File Offset: 0x000112AF
		public FactionNewTopicPopup()
		{
			this.InitializeComponent();
			this.btnOK.Enabled = false;
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x00126A28 File Offset: 0x00124C28
		public void init(long forumID, IForumPostParent parent)
		{
			this.lblTopic.Text = SK.Text("FORUMS_Topic", "Topic");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			string text = base.Title = (this.Text = SK.Text("FORUMS_New_Topic", "New Topic"));
			this.ForumID = forumID;
			this.m_parent = parent;
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x000130E6 File Offset: 0x000112E6
		private void btnCancel_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewTopicPopup_cancel");
			base.Close();
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x00126AB4 File Offset: 0x00124CB4
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("FactionNewTopicPopup_ok");
			if (this.m_parent != null)
			{
				this.m_parent.newTopic(this.ForumID, this.tbHeading.Text, this.tbMainText.Text);
			}
			base.Close();
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x00126B08 File Offset: 0x00124D08
		private void tbHeading_TextChanged(object sender, EventArgs e)
		{
			if (this.tbHeading.Text.Length > 0 && this.tbMainText.Text.Length > 0)
			{
				this.btnOK.Enabled = true;
				return;
			}
			this.btnOK.Enabled = false;
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x00126B08 File Offset: 0x00124D08
		private void tbMainText_TextChanged(object sender, EventArgs e)
		{
			if (this.tbHeading.Text.Length > 0 && this.tbMainText.Text.Length > 0)
			{
				this.btnOK.Enabled = true;
				return;
			}
			this.btnOK.Enabled = false;
		}

		// Token: 0x04001799 RID: 6041
		private long ForumID = -1L;

		// Token: 0x0400179A RID: 6042
		private IForumPostParent m_parent;
	}
}
