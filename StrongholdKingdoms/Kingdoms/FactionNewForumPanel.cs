using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001C2 RID: 450
	public class FactionNewForumPanel : CustomSelfDrawPanel, IDockableControl, IForumPostParent
	{
		// Token: 0x06001100 RID: 4352 RVA: 0x000128EA File Offset: 0x00010AEA
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001101 RID: 4353 RVA: 0x000128FA File Offset: 0x00010AFA
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x0001290A File Offset: 0x00010B0A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x0001291C File Offset: 0x00010B1C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00012929 File Offset: 0x00010B29
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x00012943 File Offset: 0x00010B43
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x00012950 File Offset: 0x00010B50
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x0001295D File Offset: 0x00010B5D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x00121E1C File Offset: 0x0012001C
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionNewForumPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x0001297C File Offset: 0x00010B7C
		public void clearForum()
		{
			this.forumArray = new SparseArray();
			this.lastRefreshTime = DateTime.MinValue;
			this.forumThreadArray = new SparseArray();
			this.currentlySelectedForum = -1L;
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x00121E88 File Offset: 0x00120088
		public FactionNewForumPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x001220C0 File Offset: 0x001202C0
		public void init(bool resized)
		{
			int height = base.Height;
			FactionNewForumPanel.instance = this;
			base.clearControls();
			this.sidebar.addSideBar(6, this);
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width - 200, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width - 200, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23 - 200, 28);
			this.headerLabelsImage.Position = new Point(25, 69);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(415, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(549, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsPanel_Faction_Forum", "Faction Forum"));
			this.newTopicButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.newTopicButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.newTopicButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.newTopicButton.Position = new Point(20, height - 30);
			this.newTopicButton.Text.Text = SK.Text("FORUMS_New_Topic", "New Topic");
			this.newTopicButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.newTopicButton.TextYOffset = -3;
			this.newTopicButton.Text.Color = global::ARGBColors.Black;
			this.newTopicButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.newTopicClick), "FactionNewForumPanel_new_topic");
			this.mainBackgroundImage.addControl(this.newTopicButton);
			this.createForumButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.createForumButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.createForumButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.createForumButton.Position = new Point(330, height - 30);
			this.createForumButton.Text.Text = SK.Text("FORUMS_Create_New_Sub_Forum", "Create New Sub Forum");
			this.createForumButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.createForumButton.TextYOffset = -3;
			this.createForumButton.Text.Color = global::ARGBColors.Black;
			this.createForumButton.Visible = false;
			this.createForumButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.createForumClick), "FactionNewForumPanel_create_forum");
			this.mainBackgroundImage.addControl(this.createForumButton);
			this.deleteForumButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.deleteForumButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.deleteForumButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.deleteForumButton.Position = new Point(560, height - 30);
			this.deleteForumButton.Text.Text = SK.Text("FORUMS_Delete_Sub_Forum", "Delete Sub Forum");
			this.deleteForumButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.deleteForumButton.TextYOffset = -3;
			this.deleteForumButton.Text.Color = global::ARGBColors.Black;
			this.deleteForumButton.Visible = false;
			this.deleteForumButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteForumClicked), "FactionNewForumPanel_delete_forum");
			this.mainBackgroundImage.addControl(this.deleteForumButton);
			this.threadTitleLabel.Text = SK.Text("FactionInvites_Thread_Title", "Thread Title");
			this.threadTitleLabel.Color = global::ARGBColors.Black;
			this.threadTitleLabel.Position = new Point(9, -2);
			this.threadTitleLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.threadTitleLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.threadTitleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.threadTitleLabel);
			this.playersLabel.Text = SK.Text("VillageMapPanel_Player", "Player");
			this.playersLabel.Color = global::ARGBColors.Black;
			this.playersLabel.Position = new Point(420, -2);
			this.playersLabel.Size = new Size(140, this.headerLabelsImage.Height);
			this.playersLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.playersLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.playersLabel);
			this.dateLabel.Text = SK.Text("FactionInvites_Last_Post_Date", "Last Post Date");
			this.dateLabel.Color = global::ARGBColors.Black;
			this.dateLabel.Position = new Point(554, -2);
			this.dateLabel.Size = new Size(160, this.headerLabelsImage.Height);
			this.dateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.dateLabel);
			this.wallScrollArea.Position = new Point(25, 98);
			this.wallScrollArea.Size = new Size(705, height - 140);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 50 - 90));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(733, 98);
			this.wallScrollBar.Size = new Size(24, height - 140);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			if (resized)
			{
				this.initForum();
				return;
			}
			this.selectedAreaID = RemoteServices.Instance.UserFactionID;
			this.selectedAreaType = 5;
			bool flag = false;
			foreach (object obj in this.forumArray)
			{
				FactionNewForumPanel.ForumData forumData = (FactionNewForumPanel.ForumData)obj;
				if (forumData.areaID == this.selectedAreaID && forumData.areaType == this.selectedAreaType)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				RemoteServices.Instance.set_GetForumList_UserCallBack(new RemoteServices.GetForumList_UserCallBack(this.getForumListCallback));
				RemoteServices.Instance.GetForumList(this.selectedAreaID, this.selectedAreaType);
				return;
			}
			if ((DateTime.Now - this.lastRefreshTime).TotalMinutes > 5.0)
			{
				RemoteServices.Instance.set_GetForumList_UserCallBack(new RemoteServices.GetForumList_UserCallBack(this.getForumListCallback));
				RemoteServices.Instance.GetForumList(this.selectedAreaID, this.selectedAreaType);
			}
			this.initForum();
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x000129A7 File Offset: 0x00010BA7
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x001229D0 File Offset: 0x00120BD0
		public void getForumListCallback(GetForumList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				foreach (ForumInfo forumInfo in returnData.forumInfo)
				{
					FactionNewForumPanel.ForumData forumData = new FactionNewForumPanel.ForumData();
					forumData.areaID = forumInfo.areaID;
					forumData.areaType = forumInfo.areaType;
					forumData.forumID = forumInfo.forumID;
					forumData.forumTitle = forumInfo.forumTitle;
					forumData.lastTime = forumInfo.lastDate;
					forumData.numPosts = forumInfo.numPosts;
					forumData.numReadPosts = forumInfo.numReadPosts;
					this.forumArray[forumData.forumID] = forumData;
				}
				this.lastRefreshTime = DateTime.Now;
				this.initForum();
			}
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x00122AA4 File Offset: 0x00120CA4
		public void initForum()
		{
			this.mainBackgroundImage.removeControl(this.forum1Button);
			this.mainBackgroundImage.removeControl(this.forum2Button);
			this.mainBackgroundImage.removeControl(this.forum3Button);
			this.mainBackgroundImage.removeControl(this.forum4Button);
			this.mainBackgroundImage.removeControl(this.forum5Button);
			this.mainBackgroundImage.removeControl(this.forum6Button);
			this.mainBackgroundImage.removeControl(this.forum7Button);
			List<FactionNewForumPanel.ForumData> list = new List<FactionNewForumPanel.ForumData>();
			foreach (object obj in this.forumArray)
			{
				FactionNewForumPanel.ForumData forumData = (FactionNewForumPanel.ForumData)obj;
				if (forumData.areaID == RemoteServices.Instance.UserFactionID && forumData.areaType == 5)
				{
					list.Add(forumData);
				}
			}
			list.Sort(this.forumComparer);
			bool flag = false;
			foreach (FactionNewForumPanel.ForumData forumData2 in list)
			{
				if (forumData2.forumID == this.currentlySelectedForum)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (list.Count > 0)
				{
					this.currentlySelectedForum = list[0].forumID;
				}
				else
				{
					this.currentlySelectedForum = -1L;
				}
			}
			int count = list.Count;
			int[] array = null;
			switch (count)
			{
			case 1:
				array = this.forums1Positions;
				break;
			case 2:
				array = this.forums2Positions;
				break;
			case 3:
				array = this.forums3Positions;
				break;
			case 4:
				array = this.forums4Positions;
				break;
			case 5:
				array = this.forums5Positions;
				break;
			case 6:
				array = this.forums6Positions;
				break;
			case 7:
				array = this.forums7Positions;
				break;
			}
			if (count >= 1)
			{
				this.forum1Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum1Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum1Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum1Button.Position = new Point(array[0], array[1]);
				this.forum1Button.Text.Text = SK.Text("FORUMS_General", "General");
				this.forum1Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum1Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum1Button.TextYOffset = -3;
				this.forum1Button.Text.Color = global::ARGBColors.Black;
				this.forum1Button.Text.clearDropShadow();
				this.forum1Button.DataL = list[0].forumID;
				this.forum1Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum1Button);
				this.forum1Button.Active = true;
				if (this.forum1Button.DataL == this.currentlySelectedForum)
				{
					this.forum1Button.Active = false;
					this.forum1Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum1Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum1Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum1Button.Text.Text);
					this.forum1Button.Text.Color = global::ARGBColors.White;
					this.forum1Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[0].forumTitle;
				}
			}
			if (count >= 2)
			{
				this.forum2Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum2Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum2Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum2Button.Position = new Point(array[2], array[3]);
				this.forum2Button.Text.Text = list[1].forumTitle;
				this.forum2Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum2Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum2Button.TextYOffset = -3;
				this.forum2Button.Text.Color = global::ARGBColors.Black;
				this.forum2Button.Text.clearDropShadow();
				this.forum2Button.DataL = list[1].forumID;
				this.forum2Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum2Button);
				if (this.forum2Button.DataL == this.currentlySelectedForum)
				{
					this.forum2Button.Active = false;
					this.forum2Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum2Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum2Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum2Button.Text.Text);
					this.forum2Button.Text.Color = global::ARGBColors.White;
					this.forum2Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[1].forumTitle;
				}
			}
			if (count >= 3)
			{
				this.forum3Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum3Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum3Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum3Button.Position = new Point(array[4], array[5]);
				this.forum3Button.Text.Text = list[2].forumTitle;
				this.forum3Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum3Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum3Button.TextYOffset = -3;
				this.forum3Button.Text.Color = global::ARGBColors.Black;
				this.forum3Button.Text.clearDropShadow();
				this.forum3Button.DataL = list[2].forumID;
				this.forum3Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum3Button);
				if (this.forum3Button.DataL == this.currentlySelectedForum)
				{
					this.forum3Button.Active = false;
					this.forum3Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum3Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum3Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum3Button.Text.Text);
					this.forum3Button.Text.Color = global::ARGBColors.White;
					this.forum3Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[2].forumTitle;
				}
			}
			if (count >= 4)
			{
				this.forum4Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum4Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum4Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum4Button.Position = new Point(array[6], array[7]);
				this.forum4Button.Text.Text = list[3].forumTitle;
				this.forum4Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum4Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum4Button.TextYOffset = -3;
				this.forum4Button.Text.Color = global::ARGBColors.Black;
				this.forum4Button.Text.clearDropShadow();
				this.forum4Button.DataL = list[3].forumID;
				this.forum4Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum4Button);
				if (this.forum4Button.DataL == this.currentlySelectedForum)
				{
					this.forum4Button.Active = false;
					this.forum4Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum4Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum4Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum4Button.Text.Text);
					this.forum4Button.Text.Color = global::ARGBColors.White;
					this.forum4Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[3].forumTitle;
				}
			}
			if (count >= 5)
			{
				this.forum5Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum5Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum5Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum5Button.Position = new Point(array[8], array[9]);
				this.forum5Button.Text.Text = list[4].forumTitle;
				this.forum5Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum5Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum5Button.TextYOffset = -3;
				this.forum5Button.Text.Color = global::ARGBColors.Black;
				this.forum5Button.Text.clearDropShadow();
				this.forum5Button.DataL = list[4].forumID;
				this.forum5Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum5Button);
				if (this.forum5Button.DataL == this.currentlySelectedForum)
				{
					this.forum5Button.Active = false;
					this.forum5Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum5Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum5Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum5Button.Text.Text);
					this.forum5Button.Text.Color = global::ARGBColors.White;
					this.forum5Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[4].forumTitle;
				}
			}
			if (count >= 6)
			{
				this.forum6Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum6Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum6Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum6Button.Position = new Point(array[10], array[11]);
				this.forum6Button.Text.Text = list[5].forumTitle;
				this.forum6Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum6Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum6Button.TextYOffset = -3;
				this.forum6Button.Text.Color = global::ARGBColors.Black;
				this.forum6Button.Text.clearDropShadow();
				this.forum6Button.DataL = list[5].forumID;
				this.forum6Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum6Button);
				if (this.forum6Button.DataL == this.currentlySelectedForum)
				{
					this.forum6Button.Active = false;
					this.forum6Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum6Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum6Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum6Button.Text.Text);
					this.forum6Button.Text.Color = global::ARGBColors.White;
					this.forum6Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[5].forumTitle;
				}
			}
			if (count >= 7)
			{
				this.forum7Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.forum7Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.forum7Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.forum7Button.Position = new Point(array[12], array[13]);
				this.forum7Button.Text.Text = list[6].forumTitle;
				this.forum7Button.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.forum7Button.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.forum7Button.TextYOffset = -3;
				this.forum7Button.Text.Color = global::ARGBColors.Black;
				this.forum7Button.Text.clearDropShadow();
				this.forum7Button.DataL = list[6].forumID;
				this.forum7Button.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.forumSelectedClick), "FactionNewForumPanel_change_forum");
				this.mainBackgroundImage.addControl(this.forum7Button);
				if (this.forum7Button.DataL == this.currentlySelectedForum)
				{
					this.forum7Button.Active = false;
					this.forum7Button.ImageNorm = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum7Button.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.forum7Button.ImageClick = GFXLibrary.mail2_button_blue_141wide_over;
					InterfaceMgr.Instance.setVillageHeading(SK.Text("FactionsSidebar_Forum", "Forum") + " : " + this.forum7Button.Text.Text);
					this.forum7Button.Text.Color = global::ARGBColors.White;
					this.forum7Button.Text.DropShadowColor = global::ARGBColors.Black;
					this.OrigForumName = list[6].forumTitle;
				}
			}
			if (this.currentlySelectedForum >= 0L)
			{
				int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
				if (yourFactionRank == 1 || yourFactionRank == 2)
				{
					if (count < GameEngine.Instance.LocalWorldData.Faction_MaxUserForums + 1)
					{
						this.createForumButton.Visible = true;
					}
					else
					{
						this.createForumButton.Visible = false;
					}
					if (this.forum1Button.DataL != this.currentlySelectedForum)
					{
						this.deleteForumButton.Visible = true;
					}
					else
					{
						this.deleteForumButton.Visible = false;
					}
				}
				else
				{
					this.createForumButton.Visible = false;
					this.deleteForumButton.Visible = false;
				}
				RemoteServices.Instance.set_GetForumThreadList_UserCallBack(new RemoteServices.GetForumThreadList_UserCallBack(this.forumThreadListCallback));
				if (this.forumThreadArray[this.currentlySelectedForum] == null || ((FactionNewForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum]).lastTime.Year < 1900)
				{
					RemoteServices.Instance.GetForumThreadList(this.currentlySelectedForum, DateTime.MinValue, true);
				}
				else if ((DateTime.Now - ((FactionNewForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum]).lastTime).TotalMinutes > 1.0)
				{
					FactionNewForumPanel.ForumInfoData forumInfoData = (FactionNewForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum];
					RemoteServices.Instance.GetForumThreadList(this.currentlySelectedForum, forumInfoData.lastTime, false);
				}
			}
			this.updateForum();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00123BAC File Offset: 0x00121DAC
		private void forumSelectedClick()
		{
			long dataL = this.ClickedControl.DataL;
			if (dataL != this.currentlySelectedForum)
			{
				this.currentlySelectedForum = dataL;
				this.initForum();
			}
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x000129B4 File Offset: 0x00010BB4
		private void newTopicClick()
		{
			if (this.m_popup == null || !this.m_popup.Created)
			{
				this.m_popup = new FactionNewTopicPopup();
				this.m_popup.init(this.currentlySelectedForum, this);
				this.m_popup.Show();
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x000129F3 File Offset: 0x00010BF3
		public void newTopic(long forumID, string heading, string body)
		{
			RemoteServices.Instance.set_NewForumThread_UserCallBack(new RemoteServices.NewForumThread_UserCallBack(this.newForumThreadCallback));
			RemoteServices.Instance.NewForumThread(forumID, heading, body);
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00123BDC File Offset: 0x00121DDC
		public void newForumThreadCallback(NewForumThread_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumThreadInfo != null && returnData.forumThreadInfo.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (ForumThreadInfo forumThreadInfo in returnData.forumThreadInfo)
					{
						forumThreadInfo.threadTitle = GameEngine.Instance.censorString(forumThreadInfo.threadTitle);
					}
				}
				this.importThreadList(returnData.forumThreadInfo, returnData.forumID);
			}
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x00123C80 File Offset: 0x00121E80
		private void createForumClick()
		{
			if (this.m_forumPopup == null || !this.m_forumPopup.Created)
			{
				this.m_forumPopup = new FactionNewForumPopup();
				this.m_forumPopup.init(this);
				this.m_forumPopup.Show();
				this.m_forumPopup.setFocus();
			}
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00012A18 File Offset: 0x00010C18
		public void createNewForum(string forumName)
		{
			RemoteServices.Instance.set_CreateForum_UserCallBack(new RemoteServices.CreateForum_UserCallBack(this.createForumCallback));
			RemoteServices.Instance.CreateForum(this.selectedAreaID, this.selectedAreaType, forumName);
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x00123CD0 File Offset: 0x00121ED0
		public void createForumCallback(CreateForum_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumInfo != null)
				{
					FactionNewForumPanel.ForumData forumData = new FactionNewForumPanel.ForumData();
					forumData.areaID = returnData.forumInfo.areaID;
					forumData.areaType = returnData.forumInfo.areaType;
					forumData.forumID = returnData.forumInfo.forumID;
					forumData.forumTitle = returnData.forumInfo.forumTitle;
					forumData.lastTime = returnData.forumInfo.lastDate;
					forumData.numPosts = returnData.forumInfo.numPosts;
					forumData.numReadPosts = returnData.forumInfo.numReadPosts;
					this.forumArray[forumData.forumID] = forumData;
				}
				this.initForum();
			}
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00123D88 File Offset: 0x00121F88
		private void PopUpOkClick()
		{
			RemoteServices.Instance.set_DeleteForum_UserCallBack(new RemoteServices.DeleteForum_UserCallBack(this.deleteForumCallback));
			RemoteServices.Instance.DeleteForum(this.selectedAreaID, 5, this.currentlySelectedForum);
			InterfaceMgr.Instance.closeGreyOut();
			this.deletePostPopUp.Close();
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00012A47 File Offset: 0x00010C47
		private void ClosePopUp()
		{
			if (this.deletePostPopUp != null)
			{
				if (this.deletePostPopUp.Created)
				{
					this.deletePostPopUp.Close();
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.deletePostPopUp = null;
			}
		}

		// Token: 0x06001119 RID: 4377 RVA: 0x00123DD8 File Offset: 0x00121FD8
		private void deleteForumClicked()
		{
			this.ClosePopUp();
			InterfaceMgr.Instance.openGreyOutWindow(false);
			this.deletePostPopUp = new MyMessageBoxPopUp();
			this.deletePostPopUp.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Sub_Forum", "Delete Sub Forum"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.PopUpOkClick));
			this.deletePostPopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x00012A7A File Offset: 0x00010C7A
		public void deleteForumCallback(DeleteForum_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumID >= 0L)
				{
					this.forumArray[returnData.forumID] = null;
				}
				this.currentlySelectedForum = -1L;
				this.initForum();
			}
		}

		// Token: 0x0600111B RID: 4379 RVA: 0x00123E50 File Offset: 0x00122050
		public void forumThreadListCallback(GetForumThreadList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumThreadInfo != null && returnData.forumThreadInfo.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (ForumThreadInfo forumThreadInfo in returnData.forumThreadInfo)
					{
						forumThreadInfo.threadTitle = GameEngine.Instance.censorString(forumThreadInfo.threadTitle);
					}
				}
				this.importThreadList(returnData.forumThreadInfo, returnData.forumID);
			}
		}

		// Token: 0x0600111C RID: 4380 RVA: 0x00123EF4 File Offset: 0x001220F4
		public void importThreadList(List<ForumThreadInfo> threadData, long forumID)
		{
			if (threadData != null)
			{
				if (this.forumThreadArray[forumID] == null)
				{
					FactionNewForumPanel.ForumInfoData forumInfoData = new FactionNewForumPanel.ForumInfoData();
					forumInfoData.forumID = forumID;
					this.forumThreadArray[forumID] = forumInfoData;
				}
				FactionNewForumPanel.ForumInfoData forumInfoData2 = (FactionNewForumPanel.ForumInfoData)this.forumThreadArray[forumID];
				foreach (ForumThreadInfo forumThreadInfo in threadData)
				{
					FactionNewForumPanel.ForumThreadData forumThreadData = new FactionNewForumPanel.ForumThreadData();
					forumThreadData.title = forumThreadInfo.threadTitle;
					forumThreadData.threadID = forumThreadInfo.threadID;
					forumThreadData.lastTime = forumThreadInfo.lastDate;
					forumThreadData.userName = forumThreadInfo.userName;
					forumThreadData.read = forumThreadInfo.threadRead;
					if (forumThreadData.lastTime > forumInfoData2.lastTime)
					{
						forumInfoData2.lastTime = forumThreadData.lastTime;
					}
					bool flag = false;
					for (int i = 0; i < forumInfoData2.forumThreads.Count; i++)
					{
						FactionNewForumPanel.ForumThreadData forumThreadData2 = forumInfoData2.forumThreads[i];
						if (forumThreadData2.threadID == forumThreadData.threadID)
						{
							forumInfoData2.forumThreads[i] = forumThreadData;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						forumInfoData2.forumThreads.Add(forumThreadData);
					}
				}
				forumInfoData2.forumThreads.Sort(this.threadComparer);
				this.updateForum();
			}
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x00124064 File Offset: 0x00122264
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 98 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x0600111E RID: 4382 RVA: 0x00012AAE File Offset: 0x00010CAE
		private void mouseWheelMoved(int delta)
		{
			if (this.wallScrollBar.Visible)
			{
				if (delta < 0)
				{
					this.wallScrollBar.scrollDown(40);
					return;
				}
				if (delta > 0)
				{
					this.wallScrollBar.scrollUp(40);
				}
			}
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x001240FC File Offset: 0x001222FC
		public void updateForum()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			if (this.currentlySelectedForum >= 0L)
			{
				FactionNewForumPanel.ForumInfoData forumInfoData = (FactionNewForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum];
				if (forumInfoData != null && forumInfoData.forumThreads != null)
				{
					int num2 = 0;
					foreach (FactionNewForumPanel.ForumThreadData threadData in forumInfoData.forumThreads)
					{
						FactionNewForumPanel.ForumThreadLine forumThreadLine = new FactionNewForumPanel.ForumThreadLine();
						if (num != 0)
						{
							num += 5;
						}
						forumThreadLine.Position = new Point(0, num);
						forumThreadLine.init(threadData, num2, this);
						this.wallScrollArea.addControl(forumThreadLine);
						num += forumThreadLine.Height;
						this.lineList.Add(forumThreadLine);
						num2++;
					}
				}
			}
			this.wallScrollArea.Size = new Size(this.wallScrollArea.Width, num);
			if (num < this.wallScrollBar.Height)
			{
				this.wallScrollBar.Visible = false;
			}
			else
			{
				this.wallScrollBar.Visible = true;
				this.wallScrollBar.NumVisibleLines = this.wallScrollBar.Height;
				this.wallScrollBar.Max = num - this.wallScrollBar.Height;
			}
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x00012AE0 File Offset: 0x00010CE0
		public void deleteTopic(long threadID)
		{
			RemoteServices.Instance.set_DeleteForumThread_UserCallBack(new RemoteServices.DeleteForumThread_UserCallBack(this.deleteForumThreadCallback));
			RemoteServices.Instance.DeleteForumThread(this.selectedAreaID, 5, this.OrigForumName, this.currentlySelectedForum, threadID);
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x00124264 File Offset: 0x00122464
		public void deleteForumThreadCallback(DeleteForumThread_ReturnType returnData)
		{
			if (returnData.Success && returnData.threadID >= 0L)
			{
				FactionNewForumPanel.ForumInfoData forumInfoData = (FactionNewForumPanel.ForumInfoData)this.forumThreadArray[returnData.forumID];
				if (forumInfoData != null)
				{
					foreach (FactionNewForumPanel.ForumThreadData forumThreadData in forumInfoData.forumThreads)
					{
						if (forumThreadData.threadID == returnData.threadID)
						{
							forumInfoData.forumThreads.Remove(forumThreadData);
							this.updateForum();
							break;
						}
					}
				}
			}
		}

		// Token: 0x04001716 RID: 5910
		public const int PANEL_ID = 45;

		// Token: 0x04001717 RID: 5911
		private DockableControl dockableControl;

		// Token: 0x04001718 RID: 5912
		private IContainer components;

		// Token: 0x04001719 RID: 5913
		public static FactionNewForumPanel instance;

		// Token: 0x0400171A RID: 5914
		private SparseArray forumArray = new SparseArray();

		// Token: 0x0400171B RID: 5915
		private SparseArray forumThreadArray = new SparseArray();

		// Token: 0x0400171C RID: 5916
		private int selectedAreaID = -1;

		// Token: 0x0400171D RID: 5917
		private int selectedAreaType = -1;

		// Token: 0x0400171E RID: 5918
		private string OrigForumName = "";

		// Token: 0x0400171F RID: 5919
		private DateTime lastRefreshTime = DateTime.MinValue;

		// Token: 0x04001720 RID: 5920
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04001721 RID: 5921
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001722 RID: 5922
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001723 RID: 5923
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001724 RID: 5924
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001725 RID: 5925
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001726 RID: 5926
		private CustomSelfDrawPanel.CSDLabel threadTitleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001727 RID: 5927
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001728 RID: 5928
		private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001729 RID: 5929
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400172A RID: 5930
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400172B RID: 5931
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x0400172C RID: 5932
		private CustomSelfDrawPanel.CSDButton forum1Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400172D RID: 5933
		private CustomSelfDrawPanel.CSDButton forum2Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400172E RID: 5934
		private CustomSelfDrawPanel.CSDButton forum3Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400172F RID: 5935
		private CustomSelfDrawPanel.CSDButton forum4Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001730 RID: 5936
		private CustomSelfDrawPanel.CSDButton forum5Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001731 RID: 5937
		private CustomSelfDrawPanel.CSDButton forum6Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001732 RID: 5938
		private CustomSelfDrawPanel.CSDButton forum7Button = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001733 RID: 5939
		private CustomSelfDrawPanel.CSDButton newTopicButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001734 RID: 5940
		private CustomSelfDrawPanel.CSDButton createForumButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001735 RID: 5941
		private CustomSelfDrawPanel.CSDButton deleteForumButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001736 RID: 5942
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x04001737 RID: 5943
		private int[] forums1Positions = new int[]
		{
			326,
			24
		};

		// Token: 0x04001738 RID: 5944
		private int[] forums2Positions = new int[]
		{
			251,
			24,
			402,
			24
		};

		// Token: 0x04001739 RID: 5945
		private int[] forums3Positions = new int[]
		{
			175,
			24,
			326,
			24,
			477,
			24
		};

		// Token: 0x0400173A RID: 5946
		private int[] forums4Positions = new int[]
		{
			100,
			24,
			251,
			24,
			402,
			24,
			553,
			24
		};

		// Token: 0x0400173B RID: 5947
		private int[] forums5Positions = new int[]
		{
			175,
			7,
			326,
			7,
			477,
			7,
			251,
			40,
			402,
			40
		};

		// Token: 0x0400173C RID: 5948
		private int[] forums6Positions = new int[]
		{
			175,
			7,
			326,
			7,
			477,
			7,
			175,
			40,
			326,
			40,
			477,
			40
		};

		// Token: 0x0400173D RID: 5949
		private int[] forums7Positions = new int[]
		{
			100,
			7,
			251,
			7,
			402,
			7,
			553,
			7,
			175,
			40,
			326,
			40,
			477,
			40
		};

		// Token: 0x0400173E RID: 5950
		private long currentlySelectedForum = -1L;

		// Token: 0x0400173F RID: 5951
		private FactionNewTopicPopup m_popup;

		// Token: 0x04001740 RID: 5952
		private FactionNewForumPopup m_forumPopup;

		// Token: 0x04001741 RID: 5953
		private MyMessageBoxPopUp deletePostPopUp;

		// Token: 0x04001742 RID: 5954
		private List<FactionNewForumPanel.ForumThreadLine> lineList = new List<FactionNewForumPanel.ForumThreadLine>();

		// Token: 0x04001743 RID: 5955
		public FactionNewForumPanel.ForumComparer forumComparer = new FactionNewForumPanel.ForumComparer();

		// Token: 0x04001744 RID: 5956
		private FactionNewForumPanel.ThreadComparer threadComparer = new FactionNewForumPanel.ThreadComparer();

		// Token: 0x020001C3 RID: 451
		public class ForumData
		{
			// Token: 0x04001745 RID: 5957
			public int areaID = -1;

			// Token: 0x04001746 RID: 5958
			public int areaType = -1;

			// Token: 0x04001747 RID: 5959
			public long forumID = -1L;

			// Token: 0x04001748 RID: 5960
			public string forumTitle = "";

			// Token: 0x04001749 RID: 5961
			public int numPosts;

			// Token: 0x0400174A RID: 5962
			public int numReadPosts;

			// Token: 0x0400174B RID: 5963
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x020001C4 RID: 452
		public class ForumThreadData
		{
			// Token: 0x0400174C RID: 5964
			public string title = "";

			// Token: 0x0400174D RID: 5965
			public long threadID = -1L;

			// Token: 0x0400174E RID: 5966
			public DateTime lastTime = DateTime.MinValue;

			// Token: 0x0400174F RID: 5967
			public string userName = "";

			// Token: 0x04001750 RID: 5968
			public bool read;
		}

		// Token: 0x020001C5 RID: 453
		public class ForumInfoData
		{
			// Token: 0x04001751 RID: 5969
			public long forumID = -1L;

			// Token: 0x04001752 RID: 5970
			public List<FactionNewForumPanel.ForumThreadData> forumThreads = new List<FactionNewForumPanel.ForumThreadData>();

			// Token: 0x04001753 RID: 5971
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x020001C6 RID: 454
		public class ForumThreadLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001126 RID: 4390 RVA: 0x00124300 File Offset: 0x00122500
			public void init(FactionNewForumPanel.ForumThreadData threadData, int position, FactionNewForumPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_ForumThreadData = threadData;
				this.ClipVisible = true;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_light;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.lineitem_strip_02_dark;
				}
				this.backgroundImage.Position = new Point(0, 0);
				this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				FontStyle style = FontStyle.Regular;
				if (!threadData.read)
				{
					style = FontStyle.Bold;
				}
				this.threadTitleLabel.Text = threadData.title;
				this.threadTitleLabel.Color = global::ARGBColors.Black;
				this.threadTitleLabel.Position = new Point(8, 0);
				this.threadTitleLabel.Size = new Size(410, this.backgroundImage.Height);
				this.threadTitleLabel.Font = FontManager.GetFont("Arial", 9f, style);
				this.threadTitleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.threadTitleLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.threadTitleLabel);
				this.userLabel.Text = threadData.userName;
				this.userLabel.Color = global::ARGBColors.Black;
				this.userLabel.Position = new Point(420, 0);
				this.userLabel.Size = new Size(134, this.backgroundImage.Height);
				this.userLabel.Font = FontManager.GetFont("Arial", 9f, style);
				this.userLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.userLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.userLabel);
				this.dateLabel.Text = threadData.lastTime.ToShortTimeString() + " " + threadData.lastTime.ToShortDateString();
				this.dateLabel.Color = global::ARGBColors.Black;
				this.dateLabel.Position = new Point(554, 0);
				this.dateLabel.Size = new Size(171, this.backgroundImage.Height);
				this.dateLabel.Font = FontManager.GetFont("Arial", 9f, style);
				this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.dateLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.backgroundImage.addControl(this.dateLabel);
				base.invalidate();
				int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
				if (yourFactionRank == 1 || yourFactionRank == 2 || RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
				{
					this.deleteThread.ImageNorm = GFXLibrary.trashcan_normal;
					this.deleteThread.ImageOver = GFXLibrary.trashcan_over;
					this.deleteThread.ImageClick = GFXLibrary.trashcan_clicked;
					this.deleteThread.Position = new Point(680, 4);
					this.deleteThread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "FactionNewForumPanel_delete_thread");
					this.backgroundImage.addControl(this.deleteThread);
				}
			}

			// Token: 0x06001127 RID: 4391 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001128 RID: 4392 RVA: 0x00124678 File Offset: 0x00122878
			public void lineClicked()
			{
				GameEngine.Instance.playInterfaceSound("FactionNewForumPanel_thread_clicked");
				InterfaceMgr.Instance.showFactionForumPosts(this.m_ForumThreadData.threadID, this.m_parent.currentlySelectedForum, this.m_ForumThreadData.title, SK.Text("FactionsPanel_Faction_Forum", "Faction Forum"));
			}

			// Token: 0x06001129 RID: 4393 RVA: 0x00012BA1 File Offset: 0x00010DA1
			private void PopUpOkClick()
			{
				if (this.m_parent != null)
				{
					this.m_parent.deleteTopic(this.m_ForumThreadData.threadID);
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.PopUp.Close();
			}

			// Token: 0x0600112A RID: 4394 RVA: 0x00012BD6 File Offset: 0x00010DD6
			private void ClosePopUp()
			{
				if (this.PopUp != null)
				{
					if (this.PopUp.Created)
					{
						this.PopUp.Close();
					}
					InterfaceMgr.Instance.closeGreyOut();
					this.PopUp = null;
				}
			}

			// Token: 0x0600112B RID: 4395 RVA: 0x001246D0 File Offset: 0x001228D0
			private void deleteClicked()
			{
				this.ClosePopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.PopUp = new MyMessageBoxPopUp();
				this.PopUp.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Topic", "Delete This Topic"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.PopUpOkClick));
				this.PopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x04001754 RID: 5972
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001755 RID: 5973
			private CustomSelfDrawPanel.CSDLabel threadTitleLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001756 RID: 5974
			private CustomSelfDrawPanel.CSDLabel userLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001757 RID: 5975
			private CustomSelfDrawPanel.CSDButton deleteThread = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04001758 RID: 5976
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001759 RID: 5977
			private int m_position = -1000;

			// Token: 0x0400175A RID: 5978
			private FactionNewForumPanel.ForumThreadData m_ForumThreadData;

			// Token: 0x0400175B RID: 5979
			private FactionNewForumPanel m_parent;

			// Token: 0x0400175C RID: 5980
			private MyMessageBoxPopUp PopUp;
		}

		// Token: 0x020001C7 RID: 455
		public class ForumComparer : IComparer<FactionNewForumPanel.ForumData>
		{
			// Token: 0x0600112D RID: 4397 RVA: 0x00012C09 File Offset: 0x00010E09
			public int Compare(FactionNewForumPanel.ForumData x, FactionNewForumPanel.ForumData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.forumID > y.forumID)
					{
						return 1;
					}
					if (x.forumID < y.forumID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020001C8 RID: 456
		public class ThreadComparer : IComparer<FactionNewForumPanel.ForumThreadData>
		{
			// Token: 0x0600112F RID: 4399 RVA: 0x00012C3B File Offset: 0x00010E3B
			public int Compare(FactionNewForumPanel.ForumThreadData x, FactionNewForumPanel.ForumThreadData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.lastTime < y.lastTime)
					{
						return 1;
					}
					if (x.lastTime > y.lastTime)
					{
						return -1;
					}
					return 0;
				}
			}
		}
	}
}
