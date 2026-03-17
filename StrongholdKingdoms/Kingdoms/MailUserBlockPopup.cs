using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200022A RID: 554
	public partial class MailUserBlockPopup : MyFormBase
	{
		// Token: 0x06001801 RID: 6145 RVA: 0x00018EDD File Offset: 0x000170DD
		public MailUserBlockPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			CustomTooltipManager.addTooltipToSystemControl(this.cbAggressive, 504);
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0017C248 File Offset: 0x0017A448
		public static void ShowPopup(MailScreen parent, string newBlockedUser)
		{
			Timer timer = new Timer();
			timer.Interval = 30;
			timer.Tick += MailUserBlockPopup.tooltipCallbackFunction;
			timer.Tag = "0";
			timer.Enabled = true;
			MailUserBlockPopup mailUserBlockPopup = new MailUserBlockPopup();
			mailUserBlockPopup.init(parent, newBlockedUser);
			mailUserBlockPopup.ShowDialog(InterfaceMgr.Instance.ParentForm);
			mailUserBlockPopup.Dispose();
			timer.Stop();
			timer.Dispose();
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x00018F1B File Offset: 0x0001711B
		private static void tooltipCallbackFunction(object sender, EventArgs ee)
		{
			InterfaceMgr.Instance.runTooltips();
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x0017C2B8 File Offset: 0x0017A4B8
		public void init(MailScreen parent, string newBlockedUser)
		{
			this.m_parent = parent;
			this.blockedNames = this.m_parent.mailController.getBlockedList();
			if (newBlockedUser.Length > 0 && !this.blockedNames.Contains(newBlockedUser))
			{
				this.blockedNames.Add(newBlockedUser);
				this.m_parent.mailController.updateBlockedList(this.blockedNames);
			}
			this.listBoxSearch.Items.Clear();
			foreach (string item in this.blockedNames)
			{
				this.listBoxSearch.Items.Add(item);
			}
			base.Title = SK.Text("MailBlock_title", "Manage Blocked Mail Users");
			this.btnRemoveBlock.Text = SK.Text("MailBlock_remove", "Remove");
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.cbAggressive.Text = SK.Text("MailBlock", "Aggressive Blocking");
			this.cbAggressive.Checked = this.m_parent.mailController.AggressiveBlocking;
			this.btnRemoveBlock.Enabled = false;
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x00018F27 File Offset: 0x00017127
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MailUserBlockPopup_close");
			base.Close();
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x00018F3E File Offset: 0x0001713E
		private void listBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxSearch.SelectedIndex >= 0)
			{
				this.btnRemoveBlock.Enabled = true;
			}
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x00018F5A File Offset: 0x0001715A
		private void listBoxSearch_DoubleClick(object sender, EventArgs e)
		{
			int selectedIndex = this.listBoxSearch.SelectedIndex;
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x0017C408 File Offset: 0x0017A608
		private void btnRemoveBlock_Click(object sender, EventArgs e)
		{
			if (this.listBoxSearch.SelectedIndex >= 0)
			{
				GameEngine.Instance.playInterfaceSound("MailUserBlockPopup_remove");
				string item = (string)this.listBoxSearch.Items[this.listBoxSearch.SelectedIndex];
				this.blockedNames.Remove(item);
				this.m_parent.mailController.updateBlockedList(this.blockedNames);
				this.listBoxSearch.Items.Clear();
				foreach (string item2 in this.blockedNames)
				{
					this.listBoxSearch.Items.Add(item2);
				}
				this.btnRemoveBlock.Enabled = false;
			}
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x00018F68 File Offset: 0x00017168
		private void cbAggressive_CheckedChanged(object sender, EventArgs e)
		{
			this.m_parent.mailController.AggressiveBlocking = this.cbAggressive.Checked;
			this.m_parent.mailController.saveBlockedList();
		}

		// Token: 0x040028A7 RID: 10407
		private MailScreen m_parent;

		// Token: 0x040028A8 RID: 10408
		private List<string> blockedNames = new List<string>();
	}
}
