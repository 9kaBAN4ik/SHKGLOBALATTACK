using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020002B1 RID: 689
	public partial class ReasonPopup : MyFormBase
	{
		// Token: 0x06001ED9 RID: 7897 RVA: 0x0001D613 File Offset: 0x0001B813
		public ReasonPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x001DC060 File Offset: 0x001DA260
		public void init(UserInfoScreen parent)
		{
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.label1.Text = SK.Text("ReasonPopup_Enter_Reason", "Enter Reason For this Action");
			string text = this.Text = (base.Title = SK.Text("ReasonPopup_Reason", "Reason"));
			this.m_parent = parent;
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x001DC0E4 File Offset: 0x001DA2E4
		public void initResources(AGUR parent, int resource)
		{
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.label1.Text = SK.Text("ReasonPopup_Enter_Reason", "Enter Reason For this Action");
			string text = this.Text = (base.Title = SK.Text("ReasonPopup_Reason", "Reason") + " : " + VillageBuildingsData.getResourceNames(resource));
			this.m_agur = parent;
		}

		// Token: 0x06001EDC RID: 7900 RVA: 0x0001D636 File Offset: 0x0001B836
		private void btnCancel_Click(object sender, EventArgs e)
		{
			if (this.m_parent != null)
			{
				this.m_parent.setReasonString("");
			}
			if (this.m_agur != null)
			{
				this.m_agur.setReasonString("");
			}
			base.Close();
		}

		// Token: 0x06001EDD RID: 7901 RVA: 0x001DC178 File Offset: 0x001DA378
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.tbReason.Text.Length > 0)
			{
				if (this.m_parent != null)
				{
					this.m_parent.setReasonString(this.tbReason.Text);
				}
				if (this.m_agur != null)
				{
					this.m_agur.setReasonString(this.tbReason.Text);
				}
				base.Close();
			}
		}

		// Token: 0x04002FC2 RID: 12226
		private UserInfoScreen m_parent;

		// Token: 0x04002FC3 RID: 12227
		private AGUR m_agur;
	}
}
