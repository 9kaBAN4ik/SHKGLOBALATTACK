using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000100 RID: 256
	public class CapitalForumPostsPanel : CustomSelfDrawPanel, IDockableControl, IForumReplyParent
	{
		// Token: 0x060007E5 RID: 2021 RVA: 0x000A9E6C File Offset: 0x000A806C
		public CapitalForumPostsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x000A9F24 File Offset: 0x000A8124
		public void init(bool resized)
		{
			int height = base.Height;
			CapitalForumPostsPanel.instance = this;
			base.clearControls();
			this.mainBackgroundImage.FillColor = Color.FromArgb(134, 153, 165);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = new Size(base.Width, height);
			base.addControl(this.mainBackgroundImage);
			this.backgroundFade.Image = GFXLibrary.background_top;
			this.backgroundFade.Position = new Point(0, 0);
			this.backgroundFade.Size = new Size(base.Width, this.backgroundFade.Image.Height);
			this.mainBackgroundImage.addControl(this.backgroundFade);
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 9);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.factionLabel.Text = CapitalForumPostsPanel.ThreadTitle;
			this.factionLabel.Color = global::ARGBColors.Black;
			this.factionLabel.Position = new Point(9, -2);
			this.factionLabel.Size = new Size(this.headerLabelsImage.Width - 18, this.headerLabelsImage.Height);
			this.factionLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.factionLabel);
			InterfaceMgr.Instance.setVillageHeading(CapitalForumPostsPanel.ForumTitle);
			this.wallScrollArea.Position = new Point(25, 38);
			this.wallScrollArea.Size = new Size(915, height - 70);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, height - 50 - 20));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(943, 38);
			this.wallScrollBar.Size = new Size(24, height - 70);
			this.mainBackgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.newPostButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.newPostButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.newPostButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.newPostButton.Position = new Point(20, height - 30);
			this.newPostButton.Text.Text = SK.Text("FORUMS_New_Post", "New Post");
			this.newPostButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.newPostButton.TextYOffset = -3;
			this.newPostButton.Text.Color = global::ARGBColors.Black;
			this.newPostButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.newPostClick), "CapitalForumPostsPanel_new_post");
			this.mainBackgroundImage.addControl(this.newPostButton);
			this.backButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.backButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.backButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.backButton.Position = new Point(840, height - 30);
			this.backButton.Text.Text = SK.Text("FORUMS_Back", "Back");
			this.backButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.backButton.TextYOffset = -3;
			this.backButton.Text.Color = global::ARGBColors.Black;
			this.backButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.backClick), "CapitalForumPostsPanel_back");
			this.mainBackgroundImage.addControl(this.backButton);
			if (!resized)
			{
				RemoteServices.Instance.set_GetForumThread_UserCallBack(new RemoteServices.GetForumThread_UserCallBack(this.forumThreadCallback));
				if (this.threadArray[CapitalForumPostsPanel.ThreadID] == null || ((CapitalForumPostsPanel.ForumThreadInfoData)this.threadArray[CapitalForumPostsPanel.ThreadID]).lastTime.Year < 1900)
				{
					RemoteServices.Instance.GetForumThread(CapitalForumPostsPanel.parentForumID, CapitalForumPostsPanel.ThreadID, DateTime.MinValue, true);
				}
				else
				{
					CapitalForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (CapitalForumPostsPanel.ForumThreadInfoData)this.threadArray[CapitalForumPostsPanel.ThreadID];
					RemoteServices.Instance.GetForumThread(CapitalForumPostsPanel.parentForumID, CapitalForumPostsPanel.ThreadID, forumThreadInfoData.lastTime, false);
				}
			}
			this.addPosts();
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0000C873 File Offset: 0x0000AA73
		public void logout()
		{
			this.threadArray = new SparseArray();
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x000AA4F0 File Offset: 0x000A86F0
		private void backClick()
		{
			switch (CapitalForumPostsPanel.areaType)
			{
			case 0:
				InterfaceMgr.Instance.setVillageTabSubMode(1307, false);
				return;
			case 1:
				InterfaceMgr.Instance.setVillageTabSubMode(1207, false);
				return;
			case 2:
				InterfaceMgr.Instance.setVillageTabSubMode(1107, false);
				return;
			case 3:
				InterfaceMgr.Instance.setVillageTabSubMode(1007, false);
				return;
			default:
				return;
			}
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x000AA560 File Offset: 0x000A8760
		private void newPostClick()
		{
			if (this.m_popup == null || !this.m_popup.Created)
			{
				this.m_popup = new FactionNewPostPopup();
				this.m_popup.init(CapitalForumPostsPanel.ThreadID, this, CapitalForumPostsPanel.ThreadTitle);
				this.m_popup.Show();
			}
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0000C880 File Offset: 0x0000AA80
		public void newPost(long threadID, string body)
		{
			RemoteServices.Instance.set_PostToForumThread_UserCallBack(new RemoteServices.PostToForumThread_UserCallBack(this.postToForumThreadCallback));
			RemoteServices.Instance.PostToForumThread(threadID, CapitalForumPostsPanel.parentForumID, body);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x000AA5B0 File Offset: 0x000A87B0
		public void postToForumThreadCallback(PostToForumThread_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumPosts != null && returnData.forumPosts.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (ForumPost forumPost in returnData.forumPosts)
					{
						forumPost.postText = GameEngine.Instance.censorString(forumPost.postText);
					}
				}
				this.importThread(returnData.forumPosts, returnData.threadID);
			}
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x000AA654 File Offset: 0x000A8854
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0000C8A9 File Offset: 0x0000AAA9
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

		// Token: 0x060007EF RID: 2031 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000AA6EC File Offset: 0x000A88EC
		public void forumThreadCallback(GetForumThread_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.forumPosts != null && returnData.forumPosts.Count > 0 && RemoteServices.Instance.UserOptions.profanityFilter)
				{
					foreach (ForumPost forumPost in returnData.forumPosts)
					{
						forumPost.postText = GameEngine.Instance.censorString(forumPost.postText);
					}
				}
				this.importThread(returnData.forumPosts, returnData.threadID);
			}
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x000AA790 File Offset: 0x000A8990
		public void importThread(List<ForumPost> posts, long threadID)
		{
			if (posts != null)
			{
				if (this.threadArray[threadID] == null)
				{
					CapitalForumPostsPanel.ForumThreadInfoData forumThreadInfoData = new CapitalForumPostsPanel.ForumThreadInfoData();
					forumThreadInfoData.threadID = threadID;
					this.threadArray[threadID] = forumThreadInfoData;
				}
				CapitalForumPostsPanel.ForumThreadInfoData forumThreadInfoData2 = (CapitalForumPostsPanel.ForumThreadInfoData)this.threadArray[threadID];
				forumThreadInfoData2.forumPosts = new List<CapitalForumPostsPanel.ForumPostData>();
				foreach (ForumPost forumPost in posts)
				{
					CapitalForumPostsPanel.ForumPostData forumPostData = new CapitalForumPostsPanel.ForumPostData();
					forumPostData.text = forumPost.postText;
					forumPostData.postID = forumPost.postID;
					forumPostData.postTime = forumPost.date;
					forumPostData.userName = forumPost.userName;
					forumPostData.userID = forumPost.userID;
					if (forumPostData.postTime > forumThreadInfoData2.lastTime)
					{
						forumThreadInfoData2.lastTime = forumPostData.postTime;
					}
					forumThreadInfoData2.forumPosts.Add(forumPostData);
				}
				this.addPosts();
			}
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x000AA8A4 File Offset: 0x000A8AA4
		public void addPosts()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.lineList.Clear();
			CapitalForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (CapitalForumPostsPanel.ForumThreadInfoData)this.threadArray[CapitalForumPostsPanel.ThreadID];
			if (forumThreadInfoData != null)
			{
				foreach (CapitalForumPostsPanel.ForumPostData postData in forumThreadInfoData.forumPosts)
				{
					if (num != 0)
					{
						num += 5;
					}
					CapitalForumPostsPanel.FactionsPostLine factionsPostLine = new CapitalForumPostsPanel.FactionsPostLine();
					factionsPostLine.Position = new Point(0, num);
					factionsPostLine.init(postData, num2, this, 0);
					this.wallScrollArea.addControl(factionsPostLine);
					num += factionsPostLine.Height;
					this.lineList.Add(factionsPostLine);
					num2++;
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
			this.update();
			base.Invalidate();
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0000C8DB File Offset: 0x0000AADB
		public void deletePost(long postID)
		{
			RemoteServices.Instance.set_DeleteForumPost_UserCallBack(new RemoteServices.DeleteForumPost_UserCallBack(this.deleteForumPostCallback));
			RemoteServices.Instance.DeleteForumPost(CapitalForumPostsPanel.areaID, CapitalForumPostsPanel.areaType, CapitalForumPostsPanel.ThreadTitle, CapitalForumPostsPanel.parentForumID, CapitalForumPostsPanel.ThreadID, postID);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x000AA9F8 File Offset: 0x000A8BF8
		public void deleteForumPostCallback(DeleteForumPost_ReturnType returnData)
		{
			if (returnData.Success && returnData.postID >= 0L)
			{
				CapitalForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (CapitalForumPostsPanel.ForumThreadInfoData)this.threadArray[CapitalForumPostsPanel.ThreadID];
				if (forumThreadInfoData != null)
				{
					foreach (CapitalForumPostsPanel.ForumPostData forumPostData in forumThreadInfoData.forumPosts)
					{
						if (forumPostData.postID == returnData.postID)
						{
							forumThreadInfoData.forumPosts.Remove(forumPostData);
							this.addPosts();
							break;
						}
					}
				}
			}
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0000C917 File Offset: 0x0000AB17
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0000C927 File Offset: 0x0000AB27
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0000C937 File Offset: 0x0000AB37
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0000C949 File Offset: 0x0000AB49
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0000C956 File Offset: 0x0000AB56
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0000C970 File Offset: 0x0000AB70
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0000C97D File Offset: 0x0000AB7D
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0000C98A File Offset: 0x0000AB8A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x000AAA94 File Offset: 0x000A8C94
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalForumPostsPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000B2E RID: 2862
		public const int PANEL_ID = 48;

		// Token: 0x04000B2F RID: 2863
		public static CapitalForumPostsPanel instance = null;

		// Token: 0x04000B30 RID: 2864
		private SparseArray threadArray = new SparseArray();

		// Token: 0x04000B31 RID: 2865
		public static long ThreadID = -1L;

		// Token: 0x04000B32 RID: 2866
		public static long parentForumID = -1L;

		// Token: 0x04000B33 RID: 2867
		public static string ThreadTitle = "";

		// Token: 0x04000B34 RID: 2868
		public static string ForumTitle = "";

		// Token: 0x04000B35 RID: 2869
		public static int areaID = -1;

		// Token: 0x04000B36 RID: 2870
		public static int areaType = -1;

		// Token: 0x04000B37 RID: 2871
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04000B38 RID: 2872
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B39 RID: 2873
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B3A RID: 2874
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000B3B RID: 2875
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B3C RID: 2876
		private CustomSelfDrawPanel.CSDButton newPostButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B3D RID: 2877
		private CustomSelfDrawPanel.CSDButton backButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B3E RID: 2878
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000B3F RID: 2879
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000B40 RID: 2880
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04000B41 RID: 2881
		private FactionNewPostPopup m_popup;

		// Token: 0x04000B42 RID: 2882
		private List<CapitalForumPostsPanel.FactionsPostLine> lineList = new List<CapitalForumPostsPanel.FactionsPostLine>();

		// Token: 0x04000B43 RID: 2883
		private DockableControl dockableControl;

		// Token: 0x04000B44 RID: 2884
		private IContainer components;

		// Token: 0x02000101 RID: 257
		public class ForumPostData
		{
			// Token: 0x04000B45 RID: 2885
			public string text = "";

			// Token: 0x04000B46 RID: 2886
			public long postID = -1L;

			// Token: 0x04000B47 RID: 2887
			public DateTime postTime = DateTime.MinValue;

			// Token: 0x04000B48 RID: 2888
			public string userName = "";

			// Token: 0x04000B49 RID: 2889
			public int userID = -1;
		}

		// Token: 0x02000102 RID: 258
		public class ForumThreadInfoData
		{
			// Token: 0x04000B4A RID: 2890
			public long threadID = -1L;

			// Token: 0x04000B4B RID: 2891
			public List<CapitalForumPostsPanel.ForumPostData> forumPosts = new List<CapitalForumPostsPanel.ForumPostData>();

			// Token: 0x04000B4C RID: 2892
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x02000103 RID: 259
		public class FactionsPostLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000801 RID: 2049 RVA: 0x000AAB00 File Offset: 0x000A8D00
			public void init(CapitalForumPostsPanel.ForumPostData postData, int position, CapitalForumPostsPanel parent, int yourRank)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_postData = postData;
				Graphics graphics = parent.CreateGraphics();
				Size size = graphics.MeasureString(postData.text, FontManager.GetFont("Arial", 9f, FontStyle.Regular), 840).ToSize();
				graphics.Dispose();
				int num = size.Height + 10;
				if (num < 32)
				{
					num = 32;
				}
				this.clearControls();
				this.Size = new Size(890, 25 + num);
				this.ClipVisible = true;
				this.lightArea1.Size = new Size(850, num);
				this.lightArea1.Position = new Point(40, 25);
				base.addControl(this.lightArea1);
				this.lightArea1.Create(GFXLibrary.int_insetpanel_lighten_top_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_top_right, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_left, GFXLibrary.int_insetpanel_lighten_middle, GFXLibrary.int_insetpanel_lighten_bottom_right);
				NumberFormatInfo nfi = GameEngine.NFI;
				this.userName.Text = postData.userName;
				this.userName.Color = global::ARGBColors.Black;
				this.userName.Position = new Point(9, 3);
				this.userName.Size = new Size(280, 30);
				this.userName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.userName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				base.addControl(this.userName);
				this.dateLabel.Text = postData.postTime.ToShortTimeString() + " " + postData.postTime.ToShortDateString();
				this.dateLabel.Color = global::ARGBColors.Black;
				this.dateLabel.Position = new Point(744, 3);
				this.dateLabel.Size = new Size(161, 30);
				this.dateLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.dateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				base.addControl(this.dateLabel);
				this.bodyLabel.Text = postData.text;
				this.bodyLabel.Color = global::ARGBColors.Black;
				this.bodyLabel.Position = new Point(5, 5);
				this.bodyLabel.Size = new Size(this.lightArea1.Width - 10, num - 5);
				this.bodyLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.bodyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.bodyLabel.setRightClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.copyTextToClipboardClick));
				this.lightArea1.addControl(this.bodyLabel);
				if (RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
				{
					this.deleteThread.ImageNorm = GFXLibrary.trashcan_normal;
					this.deleteThread.ImageOver = GFXLibrary.trashcan_over;
					this.deleteThread.ImageClick = GFXLibrary.trashcan_clicked;
					this.deleteThread.Position = new Point(870, 2);
					this.deleteThread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "CapitalForumPostsPanel_delete");
					base.addControl(this.deleteThread);
				}
				base.invalidate();
			}

			// Token: 0x06000802 RID: 2050 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06000803 RID: 2051 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void clickedLine()
			{
			}

			// Token: 0x06000804 RID: 2052 RVA: 0x000AAE88 File Offset: 0x000A9088
			private void deleteClicked()
			{
				MessageBoxButtons buts = MessageBoxButtons.YesNo;
				DialogResult dialogResult = MyMessageBox.Show(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Post", "Delete This Post"), buts);
				if (dialogResult == DialogResult.Yes)
				{
					this.PopUpOkClick();
				}
			}

			// Token: 0x06000805 RID: 2053 RVA: 0x0000CA3D File Offset: 0x0000AC3D
			private void PopUpOkClick()
			{
				if (this.m_parent != null)
				{
					this.m_parent.deletePost(this.m_postData.postID);
				}
			}

			// Token: 0x06000806 RID: 2054 RVA: 0x0000CA5D File Offset: 0x0000AC5D
			private void copyTextToClipboardClick()
			{
				Clipboard.SetText(this.m_postData.text);
			}

			// Token: 0x04000B4D RID: 2893
			private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

			// Token: 0x04000B4E RID: 2894
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000B4F RID: 2895
			private CustomSelfDrawPanel.CSDLabel userName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B50 RID: 2896
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B51 RID: 2897
			private CustomSelfDrawPanel.CSDLabel bodyLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B52 RID: 2898
			private CustomSelfDrawPanel.CSDButton deleteThread = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04000B53 RID: 2899
			private int m_position = -1000;

			// Token: 0x04000B54 RID: 2900
			private CapitalForumPostsPanel.ForumPostData m_postData;

			// Token: 0x04000B55 RID: 2901
			private CapitalForumPostsPanel m_parent;

			// Token: 0x04000B56 RID: 2902
			private MyMessageBoxPopUp PopUpRef;
		}
	}
}
