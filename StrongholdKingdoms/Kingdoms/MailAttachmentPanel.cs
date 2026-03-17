using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200021B RID: 539
	public class MailAttachmentPanel : CustomSelfDrawPanel
	{
		// Token: 0x060016A7 RID: 5799 RVA: 0x00167F98 File Offset: 0x00166198
		public MailAttachmentPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x001680E8 File Offset: 0x001662E8
		public void clearContents(bool includeLinks)
		{
			if (includeLinks)
			{
				this.linkList.Clear();
			}
			this.playerSearchList.populate(new List<CustomSelfDrawPanel.CSDListItem>());
			this.villageSearchList.populate(new List<CustomSelfDrawPanel.CSDListItem>());
			this.regionSearchList.populate(new List<CustomSelfDrawPanel.CSDListItem>());
			this.villageTabButton.Active = false;
			this.villageTabButton.Alpha = 0.5f;
			this.villageTabButton.CustomTooltipID = 518;
			this.playerAddButton.Enabled = false;
			this.villageAddButton.Enabled = false;
			this.regionAddButton.Enabled = false;
			this.selectedVillage = null;
			this.selectedLine = null;
			this.changeTabIcons(-1);
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x00168198 File Offset: 0x00166398
		public void init(Size parentSize, MailAttachmentPopup parent, MailScreen parentMail)
		{
			base.Size = parentSize;
			this.m_parent = parent;
			this.m_mailParent = parentMail;
			this.btnClose.Text.Text = SK.Text("GENERIC_Close", "Close");
			this.btnClose.ImageNorm = GFXLibrary.button_132_normal;
			this.btnClose.ImageOver = GFXLibrary.button_132_over;
			this.btnClose.ImageClick = GFXLibrary.button_132_in;
			this.btnClose.setSizeToImage();
			this.btnClose.Position = new Point(base.Width / 2 - this.btnClose.Width / 2, base.Height - this.btnClose.Height - 5);
			this.btnClose.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.btnClose.TextYOffset = -2;
			this.btnClose.Text.Color = global::ARGBColors.Black;
			this.btnClose.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "Mail_Attachment_Close");
			this.btnClose.Enabled = true;
			base.addControl(this.btnClose);
			this.initIconArea();
		}

		// Token: 0x060016AA RID: 5802 RVA: 0x001682DC File Offset: 0x001664DC
		private void initIconArea()
		{
			this.parentArea.Position = new Point(10, 10);
			this.parentArea.Size = new Size(base.Width - 20, base.Height - 20);
			base.addControl(this.parentArea);
			this.backImage.Image = GFXLibrary.mail2_new_mail_tab_panel;
			this.backImage.Position = new Point(0, 0);
			this.backImage.setSizeToImage();
			this.backImage.Visible = true;
			this.parentArea.addControl(this.backImage);
			this.changeTabIcons(-1);
			this.playerTabButton.Position = this.backImage.Position;
			this.playerTabButton.setSizeToImage();
			this.playerTabButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerTabClick), "Attachment_Player_Tab");
			this.playerTabButton.CustomTooltipID = 505;
			this.parentArea.addControl(this.playerTabButton);
			this.playerSearchArea.Position = new Point(this.backImage.X, this.playerTabButton.Rectangle.Bottom);
			this.playerSearchArea.Size = new Size(this.backImage.Width, this.backImage.Height - this.playerTabButton.Height);
			this.parentArea.addControl(this.playerSearchArea);
			this.playerSearchList.Size = new Size(160, 216);
			this.playerSearchList.Position = new Point(this.playerSearchArea.Width / 2 - this.playerSearchList.Width / 2, 40);
			this.playerSearchArea.addControl(this.playerSearchList);
			this.playerSearchList.Create(12, 18);
			this.playerSearchList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.playerListClick));
			this.playerSearchList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.playerListDoubleClick));
			this.playerAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.playerAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.playerAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.playerAddButton.setSizeToImage();
			this.playerAddButton.Position = new Point(this.playerSearchArea.Width / 2 - this.playerAddButton.Width / 2, this.playerSearchList.Rectangle.Bottom + 5);
			this.playerAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.playerAddButton.TextYOffset = -2;
			this.playerAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.playerAddButton.Text.Color = global::ARGBColors.Black;
			this.playerAddButton.Enabled = false;
			this.playerAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerAddClick), "Attachments_Add_Player");
			this.playerSearchArea.addControl(this.playerAddButton);
			this.playerSearchArea.Visible = false;
			this.villageTabButton.Position = new Point(this.playerTabButton.Rectangle.Right, this.playerTabButton.Y);
			this.villageTabButton.setSizeToImage();
			this.villageTabButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageTabClick), "Attachment_Village_Tab");
			this.parentArea.addControl(this.villageTabButton);
			this.villageTabButton.Enabled = true;
			this.villageTabButton.Active = false;
			this.villageTabButton.Alpha = 0.5f;
			this.villageTabButton.CustomTooltipID = 518;
			this.villageSearchArea.Position = new Point(this.backImage.X, this.playerTabButton.Rectangle.Bottom);
			this.villageSearchArea.Size = new Size(this.backImage.Width, this.backImage.Height - this.playerTabButton.Height);
			this.parentArea.addControl(this.villageSearchArea);
			this.villageUserLabel.Color = global::ARGBColors.Black;
			this.villageUserLabel.Position = new Point(1, 1);
			this.villageUserLabel.Size = new Size(this.villageSearchArea.Width - 7, 24);
			this.villageUserLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.villageUserLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.villageSearchArea.addControl(this.villageUserLabel);
			this.villageSearchList.Size = new Size(160, 216);
			this.villageSearchList.Position = new Point(this.villageSearchArea.Width / 2 - this.villageSearchList.Width / 2, 40);
			this.villageSearchList.Create(12, 18);
			this.villageSearchList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.villageListClick));
			this.villageSearchList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.villageListDoubleClick));
			this.villageAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.villageAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.villageAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.villageAddButton.setSizeToImage();
			this.villageAddButton.Position = new Point(this.villageSearchArea.Width / 2 - this.villageAddButton.Width / 2, this.villageSearchList.Rectangle.Bottom + 5);
			this.villageAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.villageAddButton.TextYOffset = -2;
			this.villageAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.villageAddButton.Text.Color = global::ARGBColors.Black;
			this.villageAddButton.Enabled = false;
			this.villageAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.villageAddClick), "Attachments_Add_Village");
			this.villageSearchArea.addControl(this.villageAddButton);
			this.villageScrollArea.Position = new Point(5, 16);
			this.villageScrollArea.Size = new Size(this.villageSearchArea.Width - 39, this.villageSearchArea.Height - 84);
			this.villageScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(this.villageSearchArea.Width - 39, this.villageSearchArea.Height - 84));
			this.villageSearchArea.addControl(this.villageScrollArea);
			this.villageBar.Position = new Point(this.villageScrollArea.Rectangle.Right, this.villageScrollArea.Y);
			this.villageBar.Size = new Size(24, this.villageScrollArea.Height);
			this.villageSearchArea.addControl(this.villageBar);
			this.villageBar.Value = 0;
			this.villageBar.Max = 100;
			this.villageBar.NumVisibleLines = 5;
			this.villageBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.villageBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.villageScrollBarMoved));
			this.villageSearchArea.Visible = false;
			this.regionTabButton.Position = new Point(this.villageTabButton.Rectangle.Right, this.villageTabButton.Y);
			this.regionTabButton.setSizeToImage();
			this.regionTabButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionTabClick), "Attachment_Faction_Tab");
			this.regionTabButton.CustomTooltipID = 512;
			this.parentArea.addControl(this.regionTabButton);
			this.regionSearchArea.Position = new Point(this.backImage.X, this.playerTabButton.Rectangle.Bottom);
			this.regionSearchArea.Size = new Size(this.backImage.Width, this.backImage.Height - this.playerTabButton.Height);
			this.parentArea.addControl(this.regionSearchArea);
			this.regionSearchList.Size = new Size(160, 216);
			this.regionSearchList.Position = new Point(this.regionSearchArea.Width / 2 - this.regionSearchList.Width / 2, 40);
			this.regionSearchArea.addControl(this.regionSearchList);
			this.regionSearchList.Create(12, 18);
			this.regionSearchList.setLineClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.regionListClick));
			this.regionSearchList.setDoubleClickedDelegate(new CustomSelfDrawPanel.CSDListBox.CSD_LineClickedDelegate(this.regionListDoubleClick));
			this.regionAddButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.regionAddButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.regionAddButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.regionAddButton.setSizeToImage();
			this.regionAddButton.Position = new Point(this.regionSearchArea.Width / 2 - this.regionAddButton.Width / 2, this.regionSearchList.Rectangle.Bottom + 5);
			this.regionAddButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.regionAddButton.TextYOffset = -2;
			this.regionAddButton.Text.Text = SK.Text("MailScreen_Add", "Add");
			this.regionAddButton.Text.Color = global::ARGBColors.Black;
			this.regionAddButton.Enabled = false;
			this.regionAddButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.regionAddClick), "Attachments_Add_Region");
			this.regionSearchArea.addControl(this.regionAddButton);
			this.regionSearchArea.Visible = false;
			this.currentTabButton.Position = new Point(this.regionTabButton.Rectangle.Right, this.regionTabButton.Y);
			this.currentTabButton.setSizeToImage();
			this.currentTabButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.listTabclick), "Attachment_List_Tab");
			this.currentTabButton.CustomTooltipID = 513;
			this.parentArea.addControl(this.currentTabButton);
			this.currentAttachmentArea.Position = new Point(this.backImage.X, this.playerTabButton.Rectangle.Bottom);
			this.currentAttachmentArea.Size = new Size(this.backImage.Width, this.backImage.Height - this.playerTabButton.Height);
			this.parentArea.addControl(this.currentAttachmentArea);
			this.currentAttachmentScrollArea.Position = new Point(5, 10);
			this.currentAttachmentScrollArea.Size = new Size(this.currentAttachmentArea.Width - 39, this.currentAttachmentArea.Height - 60);
			this.currentAttachmentScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(this.currentAttachmentArea.Width - 39, this.currentAttachmentArea.Height - 60));
			this.currentAttachmentArea.addControl(this.currentAttachmentScrollArea);
			this.currentAttachmentBar.Position = new Point(this.currentAttachmentScrollArea.Rectangle.Right, this.currentAttachmentScrollArea.Y);
			this.currentAttachmentBar.Size = new Size(24, this.currentAttachmentScrollArea.Height);
			this.currentAttachmentArea.addControl(this.currentAttachmentBar);
			this.currentAttachmentBar.Value = 0;
			this.currentAttachmentBar.Max = 100;
			this.currentAttachmentBar.NumVisibleLines = 5;
			this.currentAttachmentBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.currentAttachmentBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.currentScrollBarMoved));
			this.removeLinkButton.ImageNorm = GFXLibrary.mail2_button_thin_normal;
			this.removeLinkButton.ImageOver = GFXLibrary.mail2_button_thin_over;
			this.removeLinkButton.ImageClick = GFXLibrary.mail2_button_thin_in;
			this.removeLinkButton.setSizeToImage();
			this.removeLinkButton.Position = new Point(this.currentAttachmentArea.Width / 2 - this.removeLinkButton.Width / 2, this.playerSearchList.Rectangle.Bottom + 5);
			this.removeLinkButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.removeLinkButton.TextYOffset = -2;
			this.removeLinkButton.Text.Text = SK.Text("GENERIC_Remove", "Remove");
			this.removeLinkButton.Text.Color = global::ARGBColors.Black;
			this.removeLinkButton.Enabled = false;
			this.removeLinkButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.removeLinkLine), "Attachments_Remove_Link");
			this.currentAttachmentArea.addControl(this.removeLinkButton);
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x00017EF4 File Offset: 0x000160F4
		private void playerTabClick()
		{
			this.changeTabIcons(0);
		}

		// Token: 0x060016AC RID: 5804 RVA: 0x001690A0 File Offset: 0x001672A0
		private void villageTabClick()
		{
			if (this.playerSearchList.getSelectedItem() != null)
			{
				if (this.villageUserLabel.Text == this.playerSearchList.getSelectedItem().Text)
				{
					this.changeTabIcons(1);
					return;
				}
				this.villageUserLabel.Text = this.playerSearchList.getSelectedItem().Text;
				this.loadVillageList(this.playerSearchList.getSelectedItem().Text);
			}
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x00017EFD File Offset: 0x000160FD
		private void factionTabClick()
		{
			this.changeTabIcons(2);
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x00017F06 File Offset: 0x00016106
		private void listTabclick()
		{
			this.changeTabIcons(3);
			this.initCurrentAttachments();
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x00169118 File Offset: 0x00167318
		private void changeTabIcons(int tab)
		{
			this.currentTab = tab;
			this.playerTabButton.ImageNorm = GFXLibrary.mail2_attach_player_normal;
			this.playerTabButton.ImageOver = GFXLibrary.mail2_attach_player_over;
			this.playerTabButton.ImageClick = GFXLibrary.mail2_attach_player_normal;
			this.playerSearchArea.Visible = false;
			this.villageTabButton.ImageNorm = GFXLibrary.mail2_attach_village_normal;
			this.villageTabButton.ImageOver = GFXLibrary.mail2_attach_village_over;
			this.villageTabButton.ImageClick = GFXLibrary.mail2_attach_village_normal;
			this.villageSearchArea.Visible = false;
			this.regionTabButton.ImageNorm = GFXLibrary.mail2_attach_parish_normal;
			this.regionTabButton.ImageOver = GFXLibrary.mail2_attach_parish_over;
			this.regionTabButton.ImageClick = GFXLibrary.mail2_attach_parish_normal;
			this.regionSearchArea.Visible = false;
			this.currentTabButton.ImageNorm = GFXLibrary.mail2_attach_current_normal;
			this.currentTabButton.ImageOver = GFXLibrary.mail2_attach_current_over;
			this.currentTabButton.ImageClick = GFXLibrary.mail2_attach_current_normal;
			this.currentAttachmentArea.Visible = false;
			switch (tab)
			{
			case 0:
				this.playerTabButton.ImageNorm = GFXLibrary.mail2_attach_player_selected;
				this.playerTabButton.ImageOver = GFXLibrary.mail2_attach_player_selected;
				this.playerTabButton.ImageClick = GFXLibrary.mail2_attach_player_selected;
				this.playerSearchArea.Visible = true;
				this.m_parent.setTextBoxVisible(1);
				return;
			case 1:
				this.villageTabButton.ImageNorm = GFXLibrary.mail2_attach_village_selected;
				this.villageTabButton.ImageOver = GFXLibrary.mail2_attach_village_selected;
				this.villageTabButton.ImageClick = GFXLibrary.mail2_attach_village_selected;
				this.villageSearchArea.Visible = true;
				this.m_parent.setTextBoxVisible(-1);
				return;
			case 2:
				this.regionTabButton.ImageNorm = GFXLibrary.mail2_attach_parish_selected;
				this.regionTabButton.ImageOver = GFXLibrary.mail2_attach_parish_selected;
				this.regionTabButton.ImageClick = GFXLibrary.mail2_attach_parish_selected;
				this.regionSearchArea.Visible = true;
				this.m_parent.setTextBoxVisible(3);
				return;
			case 3:
				this.currentTabButton.ImageNorm = GFXLibrary.mail2_attach_current_selected;
				this.currentTabButton.ImageOver = GFXLibrary.mail2_attach_current_selected;
				this.currentTabButton.ImageClick = GFXLibrary.mail2_attach_current_selected;
				this.currentAttachmentArea.Visible = true;
				this.m_parent.setTextBoxVisible(-1);
				return;
			default:
				this.m_parent.setTextBoxVisible(-1);
				return;
			}
		}

		// Token: 0x060016B0 RID: 5808 RVA: 0x001693DC File Offset: 0x001675DC
		public void setReadOnly(bool value)
		{
			this.readOnly = value;
			if (this.readOnly)
			{
				this.playerTabButton.Enabled = false;
				this.playerSearchArea.Visible = false;
				this.villageTabButton.Active = false;
				this.villageTabButton.Alpha = 0.5f;
				this.villageTabButton.CustomTooltipID = 518;
				this.villageSearchArea.Visible = false;
				this.regionTabButton.Enabled = false;
				this.regionSearchArea.Visible = false;
				this.removeLinkButton.Visible = false;
				this.changeTabIcons(3);
				return;
			}
			this.playerTabButton.Enabled = true;
			this.playerSearchArea.Visible = true;
			if (this.playerSearchList.getSelectedItem() != null)
			{
				this.villageTabButton.Active = true;
				this.villageTabButton.Alpha = 1f;
				this.villageTabButton.CustomTooltipID = 511;
			}
			this.villageSearchArea.Visible = true;
			this.regionTabButton.Enabled = true;
			this.regionSearchArea.Visible = true;
			this.removeLinkButton.Visible = true;
			this.changeTabIcons(-1);
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x001694FC File Offset: 0x001676FC
		public void searchPlayerUpdateCallback(string textInput)
		{
			int num = this.currentTab;
			if (num != 0)
			{
				int num2 = num - 1;
				return;
			}
			RemoteServices.Instance.set_GetMailUserSearch_UserCallBack(new RemoteServices.GetMailUserSearch_UserCallBack(this.getMailUserSearchCallback));
			RemoteServices.Instance.GetMailUserSearch(textInput);
			this.searchText = "";
			this.searchText = textInput;
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x00169550 File Offset: 0x00167750
		private void playerListClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.playerAddButton.Enabled = (this.playerSearchList.getSelectedItem() != null);
			this.villageTabButton.Active = this.playerAddButton.Enabled;
			this.villageTabButton.Alpha = (this.playerAddButton.Enabled ? 1f : 0.5f);
			this.villageTabButton.CustomTooltipID = (this.playerAddButton.Enabled ? 511 : 518);
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x00017F15 File Offset: 0x00016115
		private void playerListDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.addPlayer(item);
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x00017F1E File Offset: 0x0001611E
		private void playerAddClick()
		{
			if (this.playerSearchList.getSelectedItem() != null)
			{
				this.addPlayer(this.playerSearchList.getSelectedItem());
			}
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x001695D4 File Offset: 0x001677D4
		private void addPlayer(CustomSelfDrawPanel.CSDListItem item)
		{
			bool flag = false;
			foreach (MailLink mailLink in this.linkList)
			{
				if (mailLink.linkType == 1 && mailLink.objectName == item.Text)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				MailLink mailLink2 = new MailLink();
				mailLink2.linkType = 1;
				mailLink2.objectName = item.Text;
				mailLink2.objectID = -1;
				this.linkList.Add(mailLink2);
				this.playerSearchList.highlightedItems.Add(item);
				this.playerSearchList.updateEntries();
			}
		}

		// Token: 0x060016B6 RID: 5814 RVA: 0x0016968C File Offset: 0x0016788C
		private void getMailUserSearchCallback(GetMailUserSearch_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			if (returnData.mailUsersSearch != null)
			{
				this.playerSearchList.highlightedItems.Clear();
				string[] mailUsersSearch = returnData.mailUsersSearch;
				foreach (string text in mailUsersSearch)
				{
					CustomSelfDrawPanel.CSDListItem csdlistItem = new CustomSelfDrawPanel.CSDListItem();
					csdlistItem.Text = text;
					list.Add(csdlistItem);
					foreach (MailLink mailLink in this.linkList)
					{
						if (mailLink.linkType == 1 && mailLink.objectName.ToLower() == text.ToLower())
						{
							this.playerSearchList.highlightedItems.Add(csdlistItem);
						}
					}
				}
			}
			string userName = RemoteServices.Instance.UserName;
			if (userName.ToLower().Contains(this.searchText.ToLower()))
			{
				CustomSelfDrawPanel.CSDListItem csdlistItem2 = new CustomSelfDrawPanel.CSDListItem();
				csdlistItem2.Text = userName;
				list.Add(csdlistItem2);
				foreach (MailLink mailLink2 in this.linkList)
				{
					if (mailLink2.linkType == 1 && mailLink2.objectName.ToLower() == userName.ToLower())
					{
						this.playerSearchList.highlightedItems.Add(csdlistItem2);
					}
				}
			}
			this.playerSearchList.populate(list);
			this.playerAddButton.Enabled = (this.playerSearchList.getSelectedItem() != null);
			this.villageTabButton.Active = this.playerAddButton.Enabled;
			this.villageTabButton.Alpha = (this.playerAddButton.Enabled ? 1f : 0.5f);
			this.villageTabButton.CustomTooltipID = (this.playerAddButton.Enabled ? 511 : 518);
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x00017F3E File Offset: 0x0001613E
		private void loadVillageList(string targetUser)
		{
			RemoteServices.Instance.set_GetOtherUserVillageIDList_UserCallBack(new RemoteServices.GetOtherUserVillageIDList_UserCallBack(this.villageUserInfoCallback));
			RemoteServices.Instance.GetOtherUserVillageIDList(targetUser);
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x001698A8 File Offset: 0x00167AA8
		public void villageUserInfoCallback(GetOtherUserVillageIDList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				List<CustomSelfDrawPanel.CSDListItem> items = new List<CustomSelfDrawPanel.CSDListItem>();
				this.villageSearchList.populate(items);
				List<VillageData> list = new List<VillageData>();
				List<VillageData> list2 = new List<VillageData>();
				List<VillageData> list3 = new List<VillageData>();
				List<VillageData> list4 = new List<VillageData>();
				List<VillageData> list5 = new List<VillageData>();
				foreach (int villageID in returnData.userVillageList)
				{
					VillageData villageData = GameEngine.Instance.World.getVillageData(villageID);
					if (villageData != null)
					{
						if (villageData.regionCapital)
						{
							list2.Add(villageData);
						}
						else if (villageData.countyCapital)
						{
							list3.Add(villageData);
						}
						else if (villageData.provinceCapital)
						{
							list4.Add(villageData);
						}
						else if (villageData.countryCapital)
						{
							list5.Add(villageData);
						}
						else
						{
							list.Add(villageData);
						}
					}
				}
				this.villageLines.Clear();
				this.villageScrollArea.clearControls();
				this.villageSearchArea.invalidate();
				int num = 0;
				int num2 = 0;
				foreach (VillageData data in list)
				{
					MailAttachmentPanel.VillageLine villageLine = new MailAttachmentPanel.VillageLine();
					if (num != 0)
					{
						num += 2;
					}
					villageLine.Position = new Point(3, num);
					villageLine.init(num2, this.villageScrollArea.Width - 2, data, 1, this);
					this.villageScrollArea.addControl(villageLine);
					num += villageLine.Height;
					this.villageLines.Add(villageLine);
					num2++;
				}
				foreach (VillageData data2 in list2)
				{
					MailAttachmentPanel.VillageLine villageLine2 = new MailAttachmentPanel.VillageLine();
					if (num != 0)
					{
						num += 2;
					}
					villageLine2.Position = new Point(3, num);
					villageLine2.init(num2, this.villageScrollArea.Width, data2, 2, this);
					this.villageScrollArea.addControl(villageLine2);
					num += villageLine2.Height;
					this.villageLines.Add(villageLine2);
					num2++;
				}
				foreach (VillageData data3 in list3)
				{
					MailAttachmentPanel.VillageLine villageLine3 = new MailAttachmentPanel.VillageLine();
					if (num != 0)
					{
						num += 2;
					}
					villageLine3.Position = new Point(3, num);
					villageLine3.init(num2, this.villageScrollArea.Width, data3, 3, this);
					this.villageScrollArea.addControl(villageLine3);
					num += villageLine3.Height;
					this.villageLines.Add(villageLine3);
					num2++;
				}
				foreach (VillageData data4 in list4)
				{
					MailAttachmentPanel.VillageLine villageLine4 = new MailAttachmentPanel.VillageLine();
					if (num != 0)
					{
						num += 2;
					}
					villageLine4.Position = new Point(3, num);
					villageLine4.init(num2, this.villageScrollArea.Width, data4, 4, this);
					this.villageScrollArea.addControl(villageLine4);
					num += villageLine4.Height;
					this.villageLines.Add(villageLine4);
					num2++;
				}
				foreach (VillageData data5 in list5)
				{
					MailAttachmentPanel.VillageLine villageLine5 = new MailAttachmentPanel.VillageLine();
					if (num != 0)
					{
						num += 2;
					}
					villageLine5.Position = new Point(3, num);
					villageLine5.init(num2, this.villageScrollArea.Width, data5, 5, this);
					this.villageScrollArea.addControl(villageLine5);
					num += villageLine5.Height;
					this.villageLines.Add(villageLine5);
					num2++;
				}
				this.villageAddButton.Enabled = false;
				this.villageScrollArea.Size = new Size(this.villageScrollArea.Width, num);
				if (num < this.villageBar.Height)
				{
					this.villageBar.Visible = false;
				}
				else
				{
					this.villageBar.Visible = true;
					this.villageBar.NumVisibleLines = this.villageBar.Height;
					this.villageBar.Max = num - this.villageBar.Height;
				}
				this.villageScrollArea.invalidate();
				this.villageBar.invalidate();
				this.changeTabIcons(1);
			}
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x00017F61 File Offset: 0x00016161
		private void villageListClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.villageAddButton.Enabled = (this.villageSearchList.getSelectedItem() != null);
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x00017F7C File Offset: 0x0001617C
		private void villageListDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.addVillage(item);
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x00017F85 File Offset: 0x00016185
		private void villageAddClick()
		{
			if (this.selectedVillage != null)
			{
				this.addVillage(this.selectedVillage);
			}
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x00169D78 File Offset: 0x00167F78
		private void addVillage(CustomSelfDrawPanel.CSDListItem item)
		{
			bool flag = false;
			foreach (MailLink mailLink in this.linkList)
			{
				if (mailLink.linkType == 2 && mailLink.objectID == item.Data)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				MailLink mailLink2 = new MailLink();
				mailLink2.linkType = 2;
				mailLink2.objectName = item.Text;
				mailLink2.objectID = item.Data;
				this.linkList.Add(mailLink2);
				MyMessageBox.Show(SK.Text("Attachments__Added", "Added to mail"));
			}
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x00169E28 File Offset: 0x00168028
		private void addVillage(MailAttachmentPanel.VillageLine line)
		{
			bool flag = false;
			foreach (MailLink mailLink in this.linkList)
			{
				if (mailLink.linkType == 2 && mailLink.objectID == line.villageID)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				MailLink mailLink2 = new MailLink();
				mailLink2.linkType = 2;
				mailLink2.objectName = line.nameLabel.Text;
				mailLink2.objectID = line.villageID;
				this.linkList.Add(mailLink2);
				line.isAdded = true;
				line.invalidate();
			}
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x00169ED8 File Offset: 0x001680D8
		private void villageScrollBarMoved()
		{
			int value = this.villageBar.Value;
			this.villageScrollArea.Position = new Point(this.villageScrollArea.X, 24 - value);
			this.villageScrollArea.ClipRect = new Rectangle(this.villageScrollArea.ClipRect.X, value, this.villageScrollArea.ClipRect.Width, this.villageScrollArea.ClipRect.Height);
			this.villageScrollArea.invalidate();
			this.villageBar.invalidate();
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x00169F70 File Offset: 0x00168170
		public void setSelectedVillage(MailAttachmentPanel.VillageLine inputLine)
		{
			this.selectedVillage = inputLine;
			foreach (MailAttachmentPanel.VillageLine villageLine in this.villageLines)
			{
				villageLine.isSelected(villageLine == inputLine);
				villageLine.invalidate();
			}
			this.villageAddButton.Enabled = (this.selectedVillage != null);
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x00169FE8 File Offset: 0x001681E8
		public void searchRegionUpdateCallback(string textInput)
		{
			if (this.regionNames == null)
			{
				this.regionNames = GameEngine.Instance.World.getParishNameList();
			}
			List<CustomSelfDrawPanel.CSDListItem> list = new List<CustomSelfDrawPanel.CSDListItem>();
			this.regionSearchList.highlightedItems.Clear();
			string[] array = this.regionNames;
			foreach (string text in array)
			{
				if (text.ToLower().Contains(textInput.ToLower()))
				{
					CustomSelfDrawPanel.CSDListItem csdlistItem = new CustomSelfDrawPanel.CSDListItem();
					csdlistItem.Text = text;
					csdlistItem.Data = GameEngine.Instance.World.getParishIDFromName(text);
					list.Add(csdlistItem);
					foreach (MailLink mailLink in this.linkList)
					{
						if (mailLink.linkType == 3 && mailLink.objectName.ToLower() == text.ToLower())
						{
							this.regionSearchList.highlightedItems.Add(csdlistItem);
						}
					}
				}
			}
			this.regionSearchList.populate(list);
			this.regionAddButton.Enabled = (this.playerSearchList.getSelectedItem() != null);
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x00017F9B File Offset: 0x0001619B
		private void regionListClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.regionAddButton.Enabled = (this.regionSearchList.getSelectedItem() != null);
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x00017FB6 File Offset: 0x000161B6
		private void regionListDoubleClick(CustomSelfDrawPanel.CSDListItem item)
		{
			this.addRegion(item);
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x00017FBF File Offset: 0x000161BF
		private void regionAddClick()
		{
			if (this.regionSearchList.getSelectedItem() != null)
			{
				this.addRegion(this.regionSearchList.getSelectedItem());
			}
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x0016A130 File Offset: 0x00168330
		private void addRegion(CustomSelfDrawPanel.CSDListItem item)
		{
			bool flag = false;
			foreach (MailLink mailLink in this.linkList)
			{
				if (mailLink.linkType == 3 && mailLink.objectName == item.Text)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				MailLink mailLink2 = new MailLink();
				mailLink2.linkType = 3;
				mailLink2.objectName = item.Text;
				mailLink2.objectID = item.Data;
				this.linkList.Add(mailLink2);
				this.regionSearchList.highlightedItems.Add(item);
				this.regionSearchList.clearSelectedItem();
			}
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0016A1EC File Offset: 0x001683EC
		public void initCurrentAttachments()
		{
			this.lineList.Clear();
			this.currentAttachmentScrollArea.clearControls();
			this.currentAttachmentArea.invalidate();
			int num = 0;
			int num2 = 0;
			foreach (MailLink link in this.linkList)
			{
				MailAttachmentPanel.LinkLine linkLine = new MailAttachmentPanel.LinkLine();
				if (num != 0)
				{
					num += 2;
				}
				linkLine.Position = new Point(3, num);
				linkLine.init(link, num2, this.currentAttachmentScrollArea.Width - 6, this.readOnly, this);
				this.currentAttachmentScrollArea.addControl(linkLine);
				num += linkLine.Height;
				this.lineList.Add(linkLine);
				num2++;
			}
			this.removeLinkButton.Enabled = (this.linkList.Count > 0);
			this.currentAttachmentScrollArea.Size = new Size(this.currentAttachmentScrollArea.Width, num);
			if (num < this.currentAttachmentBar.Height)
			{
				this.currentAttachmentBar.Visible = false;
			}
			else
			{
				this.currentAttachmentBar.Visible = true;
				this.currentAttachmentBar.NumVisibleLines = this.currentAttachmentBar.Height;
				this.currentAttachmentBar.Max = num - this.currentAttachmentBar.Height;
			}
			this.currentAttachmentScrollArea.invalidate();
			this.currentAttachmentBar.invalidate();
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x0016A360 File Offset: 0x00168560
		private void currentScrollBarMoved()
		{
			int value = this.currentAttachmentBar.Value;
			this.currentAttachmentScrollArea.Position = new Point(this.currentAttachmentScrollArea.X, -value);
			this.currentAttachmentScrollArea.ClipRect = new Rectangle(this.currentAttachmentScrollArea.ClipRect.X, value, this.currentAttachmentScrollArea.ClipRect.Width, this.currentAttachmentScrollArea.ClipRect.Height);
			this.currentAttachmentScrollArea.invalidate();
			this.currentAttachmentBar.invalidate();
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0016A3F8 File Offset: 0x001685F8
		public void setSelectedLine(MailAttachmentPanel.LinkLine inputLine)
		{
			this.selectedLine = inputLine;
			foreach (MailAttachmentPanel.LinkLine linkLine in this.lineList)
			{
				linkLine.isSelected(linkLine == inputLine);
				linkLine.invalidate();
			}
			this.removeLinkButton.Enabled = (this.selectedLine != null);
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x0016A470 File Offset: 0x00168670
		private void removeLinkLine()
		{
			if (this.selectedLine == null)
			{
				return;
			}
			this.linkList.Remove(this.selectedLine.parentLink);
			this.initCurrentAttachments();
			this.removeLinkButton.Enabled = false;
			CustomSelfDrawPanel.CSDListItem csdlistItem = null;
			switch (this.selectedLine.parentLink.linkType)
			{
			case 1:
				foreach (CustomSelfDrawPanel.CSDListItem csdlistItem2 in this.playerSearchList.highlightedItems)
				{
					if (csdlistItem2.Text == this.selectedLine.parentLink.objectName)
					{
						csdlistItem = csdlistItem2;
					}
				}
				if (csdlistItem != null)
				{
					this.playerSearchList.highlightedItems.Remove(csdlistItem);
					this.playerSearchList.updateEntries();
					if (this.playerSearchList.getSelectedItem() == csdlistItem)
					{
						this.playerSearchList.clearSelectedItem();
						this.villageTabButton.Active = false;
						this.villageTabButton.Alpha = 0.5f;
						this.villageTabButton.CustomTooltipID = 518;
						return;
					}
				}
				break;
			case 2:
				foreach (MailAttachmentPanel.VillageLine villageLine in this.villageLines)
				{
					if (villageLine.nameLabel.Text.ToLower() == this.selectedLine.parentLink.objectName.ToLower())
					{
						villageLine.isAdded = false;
					}
				}
				break;
			case 3:
				foreach (CustomSelfDrawPanel.CSDListItem csdlistItem3 in this.regionSearchList.highlightedItems)
				{
					if (csdlistItem3.Text.ToLower() == this.selectedLine.parentLink.objectName.ToLower())
					{
						csdlistItem = csdlistItem3;
					}
				}
				if (csdlistItem != null)
				{
					this.regionSearchList.highlightedItems.Remove(csdlistItem);
					this.regionSearchList.clearSelectedItem();
					return;
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x00017FDF File Offset: 0x000161DF
		public void closeClick()
		{
			GameEngine.Instance.playInterfaceSound("ReportsGeneric_close");
			this.m_parent.closeControl(true);
			InterfaceMgr.Instance.reactiveMainWindow();
		}

		// Token: 0x040026FD RID: 9981
		public List<MailLink> linkList = new List<MailLink>();

		// Token: 0x040026FE RID: 9982
		private CustomSelfDrawPanel.CSDButton btnClose = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040026FF RID: 9983
		private MailAttachmentPopup m_parent;

		// Token: 0x04002700 RID: 9984
		private MailScreen m_mailParent;

		// Token: 0x04002701 RID: 9985
		private CustomSelfDrawPanel.CSDArea parentArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002702 RID: 9986
		private CustomSelfDrawPanel.CSDButton playerTabButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002703 RID: 9987
		private CustomSelfDrawPanel.CSDArea playerSearchArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002704 RID: 9988
		private CustomSelfDrawPanel.CSDListBox playerSearchList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x04002705 RID: 9989
		private CustomSelfDrawPanel.CSDButton playerAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002706 RID: 9990
		private CustomSelfDrawPanel.CSDButton villageTabButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002707 RID: 9991
		private CustomSelfDrawPanel.CSDArea villageSearchArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002708 RID: 9992
		private CustomSelfDrawPanel.CSDLabel villageUserLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002709 RID: 9993
		private CustomSelfDrawPanel.CSDListBox villageSearchList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x0400270A RID: 9994
		private CustomSelfDrawPanel.CSDButton villageAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400270B RID: 9995
		private CustomSelfDrawPanel.CSDArea villageScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400270C RID: 9996
		private CustomSelfDrawPanel.CSDVertScrollBar villageBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400270D RID: 9997
		private CustomSelfDrawPanel.CSDButton regionTabButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400270E RID: 9998
		private CustomSelfDrawPanel.CSDArea regionSearchArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400270F RID: 9999
		private CustomSelfDrawPanel.CSDListBox regionSearchList = new CustomSelfDrawPanel.CSDListBox();

		// Token: 0x04002710 RID: 10000
		private CustomSelfDrawPanel.CSDButton regionAddButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002711 RID: 10001
		private CustomSelfDrawPanel.CSDButton currentTabButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002712 RID: 10002
		private CustomSelfDrawPanel.CSDArea currentAttachmentArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002713 RID: 10003
		private CustomSelfDrawPanel.CSDArea currentAttachmentScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002714 RID: 10004
		private CustomSelfDrawPanel.CSDVertScrollBar currentAttachmentBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002715 RID: 10005
		private CustomSelfDrawPanel.CSDButton removeLinkButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002716 RID: 10006
		private CustomSelfDrawPanel.CSDImage backImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002717 RID: 10007
		private int currentTab = -1;

		// Token: 0x04002718 RID: 10008
		private bool readOnly;

		// Token: 0x04002719 RID: 10009
		private string searchText = "";

		// Token: 0x0400271A RID: 10010
		private List<MailAttachmentPanel.VillageLine> villageLines = new List<MailAttachmentPanel.VillageLine>();

		// Token: 0x0400271B RID: 10011
		private MailAttachmentPanel.VillageLine selectedVillage;

		// Token: 0x0400271C RID: 10012
		private string[] regionNames;

		// Token: 0x0400271D RID: 10013
		private List<MailAttachmentPanel.LinkLine> lineList = new List<MailAttachmentPanel.LinkLine>();

		// Token: 0x0400271E RID: 10014
		private MailAttachmentPanel.LinkLine selectedLine;

		// Token: 0x0200021C RID: 540
		public class VillageLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x170001AF RID: 431
			// (set) Token: 0x060016CA RID: 5834 RVA: 0x00018006 File Offset: 0x00016206
			public bool isAdded
			{
				set
				{
					this.isAddedFlag = value;
					if (value)
					{
						this.nameLabel.Color = global::ARGBColors.Chartreuse;
						return;
					}
					this.nameLabel.Color = global::ARGBColors.Black;
				}
			}

			// Token: 0x060016CB RID: 5835 RVA: 0x0016A6AC File Offset: 0x001688AC
			public void init(int position, int width, VillageData data, int villageSize, MailAttachmentPanel parent)
			{
				this.m_parent = parent;
				this.villageID = data.id;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.char_line_01;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.char_line_02;
				}
				this.backgroundImage.Position = new Point(0, 5);
				base.addControl(this.backgroundImage);
				this.Size = new Size(width, 30);
				if (GameEngine.Instance.World.isCapital(this.villageID))
				{
					int num = 0;
					if (GameEngine.Instance.World.isRegionCapital(this.villageID))
					{
						num = 0;
					}
					else if (GameEngine.Instance.World.isCountyCapital(this.villageID))
					{
						num = 1;
					}
					else if (GameEngine.Instance.World.isProvinceCapital(this.villageID))
					{
						num = 2;
					}
					else if (GameEngine.Instance.World.isCountryCapital(this.villageID))
					{
						num = 3;
					}
					this.sizeImage.Image = GFXLibrary.char_position[num + 4];
					this.sizeImage.Position = new Point(5, -4);
					this.backgroundImage.addControl(this.sizeImage);
				}
				else
				{
					int villageSize2 = GameEngine.Instance.World.getVillageSize(this.villageID);
					this.sizeImage.Image = GFXLibrary.char_village_icons[villageSize2];
					this.sizeImage.Position = new Point(-10, -18);
					this.backgroundImage.addControl(this.sizeImage);
				}
				this.nameLabel.Color = (this.isAddedFlag ? global::ARGBColors.Chartreuse : global::ARGBColors.Black);
				this.nameLabel.Position = new Point(35, -10);
				this.nameLabel.Size = new Size(base.Width, this.backgroundImage.Height + 20);
				this.nameLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.nameLabel.Text = data.m_villageName;
				this.backgroundImage.addControl(this.nameLabel);
				this.sizeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.nameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
			}

			// Token: 0x060016CC RID: 5836 RVA: 0x00018033 File Offset: 0x00016233
			public void isSelected(bool value)
			{
				this.nameLabel.Font = FontManager.GetFont("Arial", 8.25f, value ? FontStyle.Bold : FontStyle.Regular);
			}

			// Token: 0x060016CD RID: 5837 RVA: 0x00018056 File Offset: 0x00016256
			private void lineClicked()
			{
				this.m_parent.setSelectedVillage(this);
			}

			// Token: 0x0400271F RID: 10015
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002720 RID: 10016
			private CustomSelfDrawPanel.CSDImage sizeImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002721 RID: 10017
			public CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002722 RID: 10018
			public int villageID = -1;

			// Token: 0x04002723 RID: 10019
			public bool isAddedFlag;

			// Token: 0x04002724 RID: 10020
			private MailAttachmentPanel m_parent;
		}

		// Token: 0x0200021D RID: 541
		public class LinkLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060016CF RID: 5839 RVA: 0x0016A940 File Offset: 0x00168B40
			public void init(MailLink link, int position, int width, bool isClickable, MailAttachmentPanel parent)
			{
				this.m_parent = parent;
				this.parentLink = link;
				this.clickable = isClickable;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.char_line_01;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.char_line_02;
				}
				this.backgroundImage.Position = new Point(0, 5);
				base.addControl(this.backgroundImage);
				this.Size = new Size(width, 30);
				this.nameLabel.Color = global::ARGBColors.Black;
				this.nameLabel.RolloverColor = global::ARGBColors.White;
				this.nameLabel.Position = new Point(1, -10);
				this.nameLabel.Size = new Size(base.Width, this.backgroundImage.Height + 20);
				this.nameLabel.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.nameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.nameLabel.Text = this.parentLink.objectName;
				this.backgroundImage.addControl(this.nameLabel);
				switch (this.parentLink.linkType)
				{
				case 1:
					this.linkTypeImage.Image = GFXLibrary.mail2_attach_type_player;
					this.backgroundImage.CustomTooltipID = 515;
					this.nameLabel.CustomTooltipID = 515;
					this.linkTypeImage.CustomTooltipID = 515;
					break;
				case 2:
					this.linkTypeImage.Image = GFXLibrary.mail2_attach_type_village;
					this.backgroundImage.CustomTooltipID = 516;
					this.nameLabel.CustomTooltipID = 516;
					this.linkTypeImage.CustomTooltipID = 516;
					break;
				case 3:
					this.linkTypeImage.Image = GFXLibrary.mail2_attach_type_parish;
					this.backgroundImage.CustomTooltipID = 517;
					this.nameLabel.CustomTooltipID = 517;
					this.linkTypeImage.CustomTooltipID = 517;
					break;
				}
				this.linkTypeImage.setSizeToImage();
				this.linkTypeImage.Position = new Point(base.Width - this.linkTypeImage.Width, 0);
				base.addControl(this.linkTypeImage);
				this.backgroundImage.Width = base.Width - this.linkTypeImage.Width / 2;
				this.linkTypeImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.nameLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
			}

			// Token: 0x060016D0 RID: 5840 RVA: 0x00018094 File Offset: 0x00016294
			public void isSelected(bool value)
			{
				this.nameLabel.Font = FontManager.GetFont("Arial", 8.25f, value ? FontStyle.Bold : FontStyle.Regular);
			}

			// Token: 0x060016D1 RID: 5841 RVA: 0x0016AC18 File Offset: 0x00168E18
			private void lineClicked()
			{
				this.m_parent.setSelectedLine(this);
				Point villageLocation = new Point(-1, -1);
				if (!this.clickable)
				{
					return;
				}
				switch (this.parentLink.linkType)
				{
				case 1:
					RemoteServices.Instance.set_GetUserIDFromName_UserCallBack(new RemoteServices.GetUserIDFromName_UserCallBack(this.getUserIDFromNameCallback));
					RemoteServices.Instance.GetUserIDFromName(this.parentLink.objectName);
					return;
				case 2:
					villageLocation = GameEngine.Instance.World.getVillageLocation(this.parentLink.objectID);
					if (villageLocation.X != -1)
					{
						InterfaceMgr.Instance.changeTab(0);
						GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
						InterfaceMgr.Instance.displaySelectedVillagePanel(this.parentLink.objectID, false, true, false, false);
						InterfaceMgr.Instance.reactiveMainWindow();
						return;
					}
					MyMessageBox.Show(SK.Text("Attachment_Invalid", "This attachment is invalid"));
					return;
				case 3:
				{
					int parishCapital = GameEngine.Instance.World.getParishCapital(this.parentLink.objectID);
					if (parishCapital == -1)
					{
						MyMessageBox.Show(SK.Text("Attachment_Invalid", "This attachment is invalid"));
						return;
					}
					villageLocation = GameEngine.Instance.World.getVillageLocation(parishCapital);
					if (villageLocation.X != -1)
					{
						InterfaceMgr.Instance.changeTab(0);
						GameEngine.Instance.World.startMultiStageZoom(1000.0, (double)villageLocation.X, (double)villageLocation.Y);
						InterfaceMgr.Instance.displaySelectedVillagePanel(parishCapital, false, true, false, false);
						InterfaceMgr.Instance.reactiveMainWindow();
						return;
					}
					MyMessageBox.Show(SK.Text("Attachment_Invalid", "This attachment is invalid"));
					return;
				}
				default:
					return;
				}
			}

			// Token: 0x060016D2 RID: 5842 RVA: 0x0016ADD4 File Offset: 0x00168FD4
			private void getUserIDFromNameCallback(GetUserIDFromName_ReturnType returnData)
			{
				if (returnData.Success && returnData.userID != -1)
				{
					InterfaceMgr.Instance.changeTab(0);
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = returnData.userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x04002725 RID: 10021
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002726 RID: 10022
			private CustomSelfDrawPanel.CSDImage linkTypeImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002727 RID: 10023
			private CustomSelfDrawPanel.CSDLabel nameLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002728 RID: 10024
			public MailLink parentLink;

			// Token: 0x04002729 RID: 10025
			private bool clickable;

			// Token: 0x0400272A RID: 10026
			private MailAttachmentPanel m_parent;
		}
	}
}
