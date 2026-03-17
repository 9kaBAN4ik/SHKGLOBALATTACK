using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x0200022B RID: 555
	public partial class MailUserPopup : MyFormBase
	{
		// Token: 0x0600180C RID: 6156 RVA: 0x0017D9E8 File Offset: 0x0017BBE8
		public MailUserPopup()
		{
			this.InitializeComponent();
			this.label4.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
			this.m_searchTimer = new System.Threading.Timer(new TimerCallback(this.timerCallbackFunction), null, 1, 500);
			RemoteServices.Instance.set_GetMailUserSearch_UserCallBack(new RemoteServices.GetMailUserSearch_UserCallBack(this.getMailUserSearchCallback));
		}

		// Token: 0x0600180D RID: 6157 RVA: 0x0017DA74 File Offset: 0x0017BC74
		public void setAsMail()
		{
			this.btnCancel.Visible = false;
			this.btnClose.Text = SK.Text("GENERIC_Close", "Close");
			this.btnAdd.Text = SK.Text("MailUserPopup_Add", "Add");
			this.label1.Text = SK.Text("MailUserPopup_Recent", "Recent");
			this.label2.Text = SK.Text("MailUserPopup_Favourites", "Favourites");
			this.label3.Text = SK.Text("MailUserPopup_Search_Results", "Search Results");
			this.label4.Text = SK.Text("MailUserPopup_Recipients", "Recipients");
			this.label5.Text = SK.Text("MailUserPopup_Player_Search", "Search for Player Name");
			this.btnAddToFavourites.Text = SK.Text("MailUserPopup_Add_To_Favourites", "Add to Favourites");
			this.btnSearch.Text = SK.Text("MailUserPopup_Search", "Search");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			string text = this.Text = (base.Title = SK.Text("MailUserPopup_Add_Users", "Add Users"));
			this.btnClose.Enabled = true;
			this.forwardPopup = false;
		}

		// Token: 0x0600180E RID: 6158 RVA: 0x0017DBC8 File Offset: 0x0017BDC8
		public void setAsReportForward()
		{
			this.btnCancel.Visible = true;
			this.btnClose.Text = SK.Text("MailUserPopup_Forward", "Forward");
			this.btnAdd.Text = SK.Text("MailUserPopup_Add", "Add");
			this.btnRemove.Text = SK.Text("MailUserPopup_Remove", "Remove");
			this.label1.Text = SK.Text("MailUserPopup_Recent", "Recent");
			this.label2.Text = SK.Text("MailUserPopup_Favourites", "Favourites");
			this.label3.Text = SK.Text("MailUserPopup_Search_Results", "Search Results");
			this.label4.Text = SK.Text("MailUserPopup_Recipients", "Recipients");
			this.label5.Text = SK.Text("MailUserPopup_Player_Search", "Search for Player Name");
			this.btnAddToFavourites.Text = SK.Text("MailUserPopup_Add_To_Favourites", "Add to Favourites");
			this.btnSearch.Text = SK.Text("MailUserPopup_Search", "Search");
			this.btnCancel.Text = SK.Text("GENERIC_Cancel", "Cancel");
			string text = this.Text = (base.Title = SK.Text("MailUserPopup_Add_Users", "Add Users"));
			this.btnRemoveFromFavourites.Text = SK.Text("MailUserPopup_Remove_From_Favourites", "Remove from Favourites");
			this.btnClose.Enabled = false;
			this.btnRemove.Enabled = false;
			this.btnRemoveFromFavourites.Enabled = false;
			this.forwardPopup = true;
		}

		// Token: 0x0600180F RID: 6159 RVA: 0x0017DD68 File Offset: 0x0017BF68
		public void setParent(IMailUserInterface parent, string[] history, string[] favourites, string[] recipients)
		{
			this.parentPopup = parent;
			if (history != null)
			{
				foreach (string item in history)
				{
					this.listBoxRecent.Items.Add(item);
				}
			}
			if (favourites != null)
			{
				foreach (string item2 in favourites)
				{
					this.listBoxFavourites.Items.Add(item2);
				}
			}
			if (recipients != null)
			{
				foreach (string item3 in recipients)
				{
					this.listBoxRecipients.Items.Add(item3);
				}
			}
			this.btnSearch.Enabled = false;
			this.btnAdd.Enabled = false;
			this.btnAddToFavourites.Enabled = false;
		}

		// Token: 0x06001810 RID: 6160 RVA: 0x0017DE30 File Offset: 0x0017C030
		private void timerCallbackFunction(object o)
		{
			if (Monitor.TryEnter(this.searchTimerLock))
			{
				try
				{
					this.updateSearch();
				}
				finally
				{
					Monitor.Exit(this.searchTimerLock);
				}
			}
		}

		// Token: 0x06001811 RID: 6161 RVA: 0x0017DE70 File Offset: 0x0017C070
		private void updateSearch()
		{
			if (this.lastUpdateTime == 0.0)
			{
				return;
			}
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (currentMilliseconds - this.lastUpdateTime > 2000.0)
			{
				this.lastUpdateTime = 0.0;
				if (this.textBoxNewRecipient.Text.Length > 2)
				{
					RemoteServices.Instance.GetMailUserSearch(this.textBoxNewRecipient.Text);
				}
			}
		}

		// Token: 0x06001812 RID: 6162 RVA: 0x0017DEE0 File Offset: 0x0017C0E0
		public void getMailUserSearchCallback(GetMailUserSearch_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			this.listBoxSearch.Items.Clear();
			if (returnData.mailUsersSearch != null)
			{
				string[] mailUsersSearch = returnData.mailUsersSearch;
				foreach (string item in mailUsersSearch)
				{
					this.listBoxSearch.Items.Add(item);
				}
			}
		}

		// Token: 0x06001813 RID: 6163 RVA: 0x00018FB4 File Offset: 0x000171B4
		private void btnClose_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MailUserPopup_close");
			this.m_searchTimer.Dispose();
			this.parentPopup.popupClosed(true);
			base.Close();
		}

		// Token: 0x06001814 RID: 6164 RVA: 0x00009024 File Offset: 0x00007224
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06001815 RID: 6165 RVA: 0x0017DF3C File Offset: 0x0017C13C
		private void btnAdd_Click(object sender, EventArgs e)
		{
			string selectedName = this.getSelectedName();
			if (!(selectedName == "") && !this.listBoxRecipients.Items.Contains(selectedName))
			{
				GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
				this.parentPopup.addRecipient(selectedName);
				if (!this.listBoxRecipients.Items.Contains(selectedName))
				{
					this.listBoxRecipients.Items.Add(selectedName);
				}
				this.btnAdd.Enabled = false;
				this.btnRemove.Enabled = true;
				this.btnClose.Enabled = true;
			}
		}

		// Token: 0x06001816 RID: 6166 RVA: 0x0017DFD4 File Offset: 0x0017C1D4
		private void textBoxNewRecipient_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r')
			{
				return;
			}
			if (this.textBoxNewRecipient.Text.Length > 0)
			{
				GameEngine.Instance.playInterfaceSound("MailUserPopup_search");
				RemoteServices.Instance.GetMailUserSearch(this.textBoxNewRecipient.Text);
				if (this.listBoxSearch.SelectedIndex != -1)
				{
					BitmapButton bitmapButton = this.btnAdd;
					BitmapButton bitmapButton2 = this.btnRemove;
					BitmapButton bitmapButton3 = this.btnAddToFavourites;
					bool enabled = this.btnRemoveFromFavourites.Enabled = false;
					bool enabled2 = bitmapButton3.Enabled = enabled;
					bool enabled3 = bitmapButton2.Enabled = enabled2;
					bitmapButton.Enabled = enabled3;
				}
			}
			e.Handled = true;
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x00018FE2 File Offset: 0x000171E2
		private void textBoxNewRecipient_KeyUp(object sender, KeyEventArgs e)
		{
			this.lastUpdateTime = DXTimer.GetCurrentMilliseconds();
			if (this.textBoxNewRecipient.Text.Length == 0)
			{
				this.btnSearch.Enabled = false;
				return;
			}
			this.btnSearch.Enabled = true;
		}

		// Token: 0x06001818 RID: 6168 RVA: 0x0017E084 File Offset: 0x0017C284
		private void listBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxSearch.SelectedIndex >= 0)
			{
				this.listBoxRecent.ClearSelected();
				this.listBoxRecipients.ClearSelected();
				this.listBoxFavourites.ClearSelected();
				this.btnAdd.Enabled = !this.listBoxRecipients.Items.Contains(this.listBoxSearch.SelectedItem.ToString());
				this.btnRemove.Enabled = !this.btnAdd.Enabled;
				this.btnAddToFavourites.Enabled = !this.listBoxFavourites.Items.Contains(this.listBoxSearch.SelectedItem.ToString());
				this.btnRemoveFromFavourites.Enabled = !this.btnAddToFavourites.Enabled;
			}
		}

		// Token: 0x06001819 RID: 6169 RVA: 0x0017E154 File Offset: 0x0017C354
		private void listBoxRecent_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxRecent.SelectedIndex >= 0)
			{
				this.listBoxSearch.ClearSelected();
				this.listBoxRecipients.ClearSelected();
				this.listBoxFavourites.ClearSelected();
				this.btnAdd.Enabled = !this.listBoxRecipients.Items.Contains(this.listBoxRecent.SelectedItem.ToString());
				this.btnRemove.Enabled = !this.btnAdd.Enabled;
				this.btnAddToFavourites.Enabled = !this.listBoxFavourites.Items.Contains(this.listBoxRecent.SelectedItem.ToString());
				this.btnRemoveFromFavourites.Enabled = !this.btnAddToFavourites.Enabled;
			}
		}

		// Token: 0x0600181A RID: 6170 RVA: 0x0017E224 File Offset: 0x0017C424
		private void listBoxFavourites_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxFavourites.SelectedIndex >= 0)
			{
				this.listBoxRecent.ClearSelected();
				this.listBoxRecipients.ClearSelected();
				this.listBoxSearch.ClearSelected();
				this.btnAdd.Enabled = !this.listBoxRecipients.Items.Contains(this.listBoxFavourites.SelectedItem.ToString());
				this.btnRemove.Enabled = !this.btnAdd.Enabled;
				this.btnAddToFavourites.Enabled = false;
				this.btnRemoveFromFavourites.Enabled = true;
			}
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x0017E2C4 File Offset: 0x0017C4C4
		private void listBoxRecipients_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxRecipients.SelectedIndex >= 0)
			{
				this.listBoxRecent.ClearSelected();
				this.listBoxSearch.ClearSelected();
				this.listBoxFavourites.ClearSelected();
				this.btnAdd.Enabled = false;
				this.btnRemove.Enabled = true;
				this.btnAddToFavourites.Enabled = !this.listBoxFavourites.Items.Contains(this.listBoxRecipients.SelectedItem.ToString());
				this.btnRemoveFromFavourites.Enabled = !this.btnAddToFavourites.Enabled;
			}
		}

		// Token: 0x0600181C RID: 6172 RVA: 0x0017E364 File Offset: 0x0017C564
		private void btnAddToFavourites_Click(object sender, EventArgs e)
		{
			string selectedName = this.getSelectedName();
			if (!(selectedName == "") && !this.listBoxFavourites.Items.Contains(selectedName))
			{
				GameEngine.Instance.playInterfaceSound("MailUserPopup_add_to_favourites");
				if (!this.listBoxFavourites.Items.Contains(selectedName))
				{
					this.listBoxFavourites.Items.Add(selectedName);
					RemoteServices.Instance.AddUserToFavourites(selectedName);
					GenericReportPanelBasic.ForceHistoryRefresh();
					this.btnAddToFavourites.Enabled = false;
					this.btnRemoveFromFavourites.Enabled = true;
				}
			}
		}

		// Token: 0x0600181D RID: 6173 RVA: 0x0017E3F4 File Offset: 0x0017C5F4
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.lastUpdateTime = 0.0;
			if (this.textBoxNewRecipient.Text.Length > 0)
			{
				GameEngine.Instance.playInterfaceSound("MailUserPopup_search");
				RemoteServices.Instance.GetMailUserSearch(this.textBoxNewRecipient.Text);
				if (this.listBoxSearch.SelectedIndex != -1)
				{
					BitmapButton bitmapButton = this.btnAdd;
					BitmapButton bitmapButton2 = this.btnRemove;
					BitmapButton bitmapButton3 = this.btnAddToFavourites;
					bool enabled = this.btnRemoveFromFavourites.Enabled = false;
					bool enabled2 = bitmapButton3.Enabled = enabled;
					bool enabled3 = bitmapButton2.Enabled = enabled2;
					bitmapButton.Enabled = enabled3;
				}
			}
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x0017E4A4 File Offset: 0x0017C6A4
		private void listBoxRecent_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBoxRecent.SelectedIndex < 0)
			{
				return;
			}
			GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
			if (!this.listBoxRecipients.Items.Contains(this.listBoxRecent.SelectedItem.ToString()))
			{
				this.parentPopup.addRecipient(this.listBoxRecent.SelectedItem.ToString());
				this.listBoxRecipients.Items.Add(this.listBoxRecent.SelectedItem.ToString());
				this.btnAdd.Enabled = false;
				this.btnClose.Enabled = true;
				this.btnRemove.Enabled = true;
				return;
			}
			this.listBoxRecipients.Items.Remove(this.listBoxRecent.SelectedItem.ToString());
			this.btnAdd.Enabled = true;
			this.btnRemove.Enabled = false;
			if (this.forwardPopup && this.listBoxRecipients.Items.Count <= 0)
			{
				this.btnClose.Enabled = false;
			}
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x0017E5B4 File Offset: 0x0017C7B4
		private void listBoxFavourites_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBoxFavourites.SelectedIndex < 0)
			{
				return;
			}
			GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
			if (!this.listBoxRecipients.Items.Contains(this.listBoxFavourites.SelectedItem.ToString()))
			{
				this.parentPopup.addRecipient(this.listBoxFavourites.SelectedItem.ToString());
				this.listBoxRecipients.Items.Add(this.listBoxFavourites.SelectedItem.ToString());
				this.btnAdd.Enabled = false;
				this.btnClose.Enabled = true;
				this.btnRemove.Enabled = true;
				return;
			}
			this.listBoxRecipients.Items.Remove(this.listBoxFavourites.SelectedItem.ToString());
			this.btnAdd.Enabled = true;
			this.btnRemove.Enabled = false;
			if (this.forwardPopup && this.listBoxRecipients.Items.Count <= 0)
			{
				this.btnClose.Enabled = false;
			}
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x0017E6C4 File Offset: 0x0017C8C4
		private void listBoxSearch_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBoxSearch.SelectedIndex < 0)
			{
				return;
			}
			GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
			if (!this.listBoxRecipients.Items.Contains(this.listBoxSearch.SelectedItem.ToString()))
			{
				this.parentPopup.addRecipient(this.listBoxSearch.SelectedItem.ToString());
				this.listBoxRecipients.Items.Add(this.listBoxSearch.SelectedItem.ToString());
				this.btnAdd.Enabled = false;
				this.btnClose.Enabled = true;
				this.btnRemove.Enabled = true;
				return;
			}
			this.listBoxRecipients.Items.Remove(this.listBoxSearch.SelectedItem.ToString());
			this.btnAdd.Enabled = true;
			this.btnRemove.Enabled = false;
			if (this.forwardPopup && this.listBoxRecipients.Items.Count <= 0)
			{
				this.btnClose.Enabled = false;
			}
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x0017E7D4 File Offset: 0x0017C9D4
		private void listBoxRecipients_DoubleClick(object sender, EventArgs e)
		{
			if (this.listBoxRecipients.SelectedIndex >= 0)
			{
				this.btnRemove.Enabled = false;
				this.btnAdd.Enabled = false;
				this.btnAddToFavourites.Enabled = false;
				this.btnRemoveFromFavourites.Enabled = false;
				GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
				this.listBoxRecipients.Items.Remove(this.listBoxRecipients.SelectedItem.ToString());
				if (this.forwardPopup && this.listBoxRecipients.Items.Count <= 0)
				{
					this.btnClose.Enabled = false;
				}
			}
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x0017E878 File Offset: 0x0017CA78
		private void btnRemoveFromFavourites_Click(object sender, EventArgs e)
		{
			string selectedName = this.getSelectedName();
			if (!(selectedName == ""))
			{
				BitmapButton bitmapButton = this.btnAddToFavourites;
				BitmapButton bitmapButton2 = this.btnRemove;
				bool enabled = this.btnAdd.Enabled = (this.listBoxFavourites.SelectedIndex == -1);
				bool enabled2 = bitmapButton2.Enabled = enabled;
				bitmapButton.Enabled = enabled2;
				this.btnRemoveFromFavourites.Enabled = false;
				GameEngine.Instance.playInterfaceSound("MailUserPopup_add_to_favourites");
				RemoteServices.Instance.RemoveUserFromFavourites(selectedName);
				this.listBoxFavourites.Items.Remove(selectedName);
				GenericReportPanelBasic.ForceHistoryRefresh();
			}
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x0017E918 File Offset: 0x0017CB18
		private void btnRemove_Click(object sender, EventArgs e)
		{
			string selectedName = this.getSelectedName();
			if (!(selectedName == "") && this.listBoxRecipients.Items.Contains(selectedName))
			{
				BitmapButton bitmapButton = this.btnAddToFavourites;
				BitmapButton bitmapButton2 = this.btnRemoveFromFavourites;
				bool enabled = this.btnAdd.Enabled = (this.listBoxRecipients.SelectedIndex == -1);
				bool enabled2 = bitmapButton2.Enabled = enabled;
				bitmapButton.Enabled = enabled2;
				this.btnRemove.Enabled = false;
				GameEngine.Instance.playInterfaceSound("MailUserPopup_add");
				this.listBoxRecipients.Items.Remove(selectedName);
				if (this.forwardPopup && this.listBoxRecipients.Items.Count <= 0)
				{
					this.btnClose.Enabled = false;
				}
			}
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x0001901A File Offset: 0x0001721A
		private void MailUserPopup_FormClosing(object sender, FormClosingEventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("MailUserPopup_cancel");
			this.m_searchTimer.Dispose();
			this.parentPopup.popupClosed(false);
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x0017E9E8 File Offset: 0x0017CBE8
		private string getSelectedName()
		{
			if (this.listBoxSearch.SelectedIndex != -1)
			{
				return this.listBoxSearch.SelectedItem.ToString();
			}
			if (this.listBoxRecent.SelectedIndex != -1)
			{
				return this.listBoxRecent.SelectedItem.ToString();
			}
			if (this.listBoxRecipients.SelectedIndex != -1)
			{
				return this.listBoxRecipients.SelectedItem.ToString();
			}
			if (this.listBoxFavourites.SelectedIndex != -1)
			{
				return this.listBoxFavourites.SelectedItem.ToString();
			}
			return "";
		}

		// Token: 0x040028BB RID: 10427
		private System.Threading.Timer m_searchTimer;

		// Token: 0x040028BC RID: 10428
		private IMailUserInterface parentPopup;

		// Token: 0x040028BD RID: 10429
		private bool forwardPopup;

		// Token: 0x040028BE RID: 10430
		private object searchTimerLock = false;

		// Token: 0x040028BF RID: 10431
		private double lastUpdateTime;
	}
}
