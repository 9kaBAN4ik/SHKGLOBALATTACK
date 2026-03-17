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
	// Token: 0x020001CA RID: 458
	public class FactionNewForumPostsPanel : CustomSelfDrawPanel, IDockableControl, IForumReplyParent
	{
		// Token: 0x0600113A RID: 4410 RVA: 0x00124D68 File Offset: 0x00122F68
		public FactionNewForumPostsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x00124E28 File Offset: 0x00123028
		public void init(bool resized)
		{
			int height = base.Height;
			FactionNewForumPostsPanel.instance = this;
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
			this.headerLabelsImage.Position = new Point(25, 9);
			this.mainBackgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.factionLabel.Text = FactionNewForumPostsPanel.ThreadTitle;
			this.factionLabel.Color = global::ARGBColors.Black;
			this.factionLabel.Position = new Point(9, -2);
			this.factionLabel.Size = new Size(this.headerLabelsImage.Width - 18, this.headerLabelsImage.Height);
			this.factionLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.factionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.factionLabel);
			InterfaceMgr.Instance.setVillageHeading(FactionNewForumPostsPanel.ForumTitle);
			this.wallScrollArea.Position = new Point(25, 38);
			this.wallScrollArea.Size = new Size(705, height - 70);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(705, height - 50 - 20));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(733, 38);
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
			this.newPostButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.newPostClick), "FactionNewForumPostsPanel_new_post");
			this.mainBackgroundImage.addControl(this.newPostButton);
			this.backButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.backButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.backButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.backButton.Position = new Point(630, height - 30);
			this.backButton.Text.Text = SK.Text("FORUMS_Back", "Back");
			this.backButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.backButton.TextYOffset = -3;
			this.backButton.Text.Color = global::ARGBColors.Black;
			this.backButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.backClick), "FactionNewForumPostsPanel_back");
			this.mainBackgroundImage.addControl(this.backButton);
			if (!resized)
			{
				RemoteServices.Instance.set_GetForumThread_UserCallBack(new RemoteServices.GetForumThread_UserCallBack(this.forumThreadCallback));
				if (this.threadArray[FactionNewForumPostsPanel.ThreadID] == null || ((FactionNewForumPostsPanel.ForumThreadInfoData)this.threadArray[FactionNewForumPostsPanel.ThreadID]).lastTime.Year < 1900)
				{
					RemoteServices.Instance.GetForumThread(FactionNewForumPostsPanel.parentForumID, FactionNewForumPostsPanel.ThreadID, DateTime.MinValue, true);
				}
				else
				{
					FactionNewForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (FactionNewForumPostsPanel.ForumThreadInfoData)this.threadArray[FactionNewForumPostsPanel.ThreadID];
					RemoteServices.Instance.GetForumThread(FactionNewForumPostsPanel.parentForumID, FactionNewForumPostsPanel.ThreadID, forumThreadInfoData.lastTime, false);
				}
			}
			this.addPosts();
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x00012D74 File Offset: 0x00010F74
		public void update()
		{
			this.sidebar.update();
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x00012D81 File Offset: 0x00010F81
		public void logout()
		{
			this.threadArray = new SparseArray();
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x000102BF File Offset: 0x0000E4BF
		private void backClick()
		{
			InterfaceMgr.Instance.setVillageTabSubMode(45, false);
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x00125414 File Offset: 0x00123614
		private void newPostClick()
		{
			if (this.m_popup == null || !this.m_popup.Created)
			{
				this.m_popup = new FactionNewPostPopup();
				this.m_popup.init(FactionNewForumPostsPanel.ThreadID, this, FactionNewForumPostsPanel.ThreadTitle);
				this.m_popup.Show();
			}
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x00012D8E File Offset: 0x00010F8E
		public void newPost(long threadID, string body)
		{
			RemoteServices.Instance.set_PostToForumThread_UserCallBack(new RemoteServices.PostToForumThread_UserCallBack(this.postToForumThreadCallback));
			RemoteServices.Instance.PostToForumThread(threadID, FactionNewForumPostsPanel.parentForumID, body);
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x00125464 File Offset: 0x00123664
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

		// Token: 0x06001142 RID: 4418 RVA: 0x00125508 File Offset: 0x00123708
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00012DB7 File Offset: 0x00010FB7
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

		// Token: 0x06001144 RID: 4420 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x001255A0 File Offset: 0x001237A0
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

		// Token: 0x06001146 RID: 4422 RVA: 0x00125644 File Offset: 0x00123844
		public void importThread(List<ForumPost> posts, long threadID)
		{
			if (posts != null)
			{
				if (this.threadArray[threadID] == null)
				{
					FactionNewForumPostsPanel.ForumThreadInfoData forumThreadInfoData = new FactionNewForumPostsPanel.ForumThreadInfoData();
					forumThreadInfoData.threadID = threadID;
					this.threadArray[threadID] = forumThreadInfoData;
				}
				FactionNewForumPostsPanel.ForumThreadInfoData forumThreadInfoData2 = (FactionNewForumPostsPanel.ForumThreadInfoData)this.threadArray[threadID];
				forumThreadInfoData2.forumPosts = new List<FactionNewForumPostsPanel.ForumPostData>();
				foreach (ForumPost forumPost in posts)
				{
					FactionNewForumPostsPanel.ForumPostData forumPostData = new FactionNewForumPostsPanel.ForumPostData();
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

		// Token: 0x06001147 RID: 4423 RVA: 0x00125758 File Offset: 0x00123958
		public void addPosts()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			int num2 = 0;
			this.lineList.Clear();
			int yourFactionRank = GameEngine.Instance.World.getYourFactionRank();
			FactionNewForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (FactionNewForumPostsPanel.ForumThreadInfoData)this.threadArray[FactionNewForumPostsPanel.ThreadID];
			if (forumThreadInfoData != null)
			{
				foreach (FactionNewForumPostsPanel.ForumPostData postData in forumThreadInfoData.forumPosts)
				{
					if (num != 0)
					{
						num += 5;
					}
					FactionNewForumPostsPanel.FactionsPostLine factionsPostLine = new FactionNewForumPostsPanel.FactionsPostLine();
					factionsPostLine.Position = new Point(0, num);
					factionsPostLine.init(postData, num2, this, yourFactionRank);
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

		// Token: 0x06001148 RID: 4424 RVA: 0x00012DE9 File Offset: 0x00010FE9
		public void deletePost(long postID)
		{
			RemoteServices.Instance.set_DeleteForumPost_UserCallBack(new RemoteServices.DeleteForumPost_UserCallBack(this.deleteForumPostCallback));
			RemoteServices.Instance.DeleteForumPost(RemoteServices.Instance.UserFactionID, 5, FactionNewForumPostsPanel.ThreadTitle, FactionNewForumPostsPanel.parentForumID, FactionNewForumPostsPanel.ThreadID, postID);
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x001258BC File Offset: 0x00123ABC
		public void deleteForumPostCallback(DeleteForumPost_ReturnType returnData)
		{
			if (returnData.Success && returnData.postID >= 0L)
			{
				FactionNewForumPostsPanel.ForumThreadInfoData forumThreadInfoData = (FactionNewForumPostsPanel.ForumThreadInfoData)this.threadArray[FactionNewForumPostsPanel.ThreadID];
				if (forumThreadInfoData != null)
				{
					foreach (FactionNewForumPostsPanel.ForumPostData forumPostData in forumThreadInfoData.forumPosts)
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

		// Token: 0x0600114A RID: 4426 RVA: 0x00012E26 File Offset: 0x00011026
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x00012E36 File Offset: 0x00011036
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x00012E46 File Offset: 0x00011046
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x00012E58 File Offset: 0x00011058
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x00012E65 File Offset: 0x00011065
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00012E7F File Offset: 0x0001107F
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x00012E8C File Offset: 0x0001108C
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x00012E99 File Offset: 0x00011099
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x00125958 File Offset: 0x00123B58
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "FactionNewForumPostsPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04001763 RID: 5987
		public const int PANEL_ID = 48;

		// Token: 0x04001764 RID: 5988
		public static FactionNewForumPostsPanel instance = null;

		// Token: 0x04001765 RID: 5989
		private SparseArray threadArray = new SparseArray();

		// Token: 0x04001766 RID: 5990
		public static long ThreadID = -1L;

		// Token: 0x04001767 RID: 5991
		public static long parentForumID = -1L;

		// Token: 0x04001768 RID: 5992
		public static string ThreadTitle = "";

		// Token: 0x04001769 RID: 5993
		public static string ForumTitle = "";

		// Token: 0x0400176A RID: 5994
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400176B RID: 5995
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400176C RID: 5996
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400176D RID: 5997
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400176E RID: 5998
		private CustomSelfDrawPanel.CSDLabel factionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400176F RID: 5999
		private CustomSelfDrawPanel.CSDButton newPostButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001770 RID: 6000
		private CustomSelfDrawPanel.CSDButton backButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001771 RID: 6001
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04001772 RID: 6002
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04001773 RID: 6003
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04001774 RID: 6004
		private CustomSelfDrawPanel.FactionPanelSideBar sidebar = new CustomSelfDrawPanel.FactionPanelSideBar();

		// Token: 0x04001775 RID: 6005
		private FactionNewPostPopup m_popup;

		// Token: 0x04001776 RID: 6006
		private List<FactionNewForumPostsPanel.FactionsPostLine> lineList = new List<FactionNewForumPostsPanel.FactionsPostLine>();

		// Token: 0x04001777 RID: 6007
		private DockableControl dockableControl;

		// Token: 0x04001778 RID: 6008
		private IContainer components;

		// Token: 0x020001CB RID: 459
		public class ForumPostData
		{
			// Token: 0x04001779 RID: 6009
			public string text = "";

			// Token: 0x0400177A RID: 6010
			public long postID = -1L;

			// Token: 0x0400177B RID: 6011
			public DateTime postTime = DateTime.MinValue;

			// Token: 0x0400177C RID: 6012
			public string userName = "";

			// Token: 0x0400177D RID: 6013
			public int userID = -1;
		}

		// Token: 0x020001CC RID: 460
		public class ForumThreadInfoData
		{
			// Token: 0x0400177E RID: 6014
			public long threadID = -1L;

			// Token: 0x0400177F RID: 6015
			public List<FactionNewForumPostsPanel.ForumPostData> forumPosts = new List<FactionNewForumPostsPanel.ForumPostData>();

			// Token: 0x04001780 RID: 6016
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x020001CD RID: 461
		public class FactionsPostLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001156 RID: 4438 RVA: 0x001259C4 File Offset: 0x00123BC4
			public void init(FactionNewForumPostsPanel.ForumPostData postData, int position, FactionNewForumPostsPanel parent, int yourRank)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_postData = postData;
				Graphics graphics = parent.CreateGraphics();
				Size size = graphics.MeasureString(postData.text, FontManager.GetFont("Arial", 9f, FontStyle.Regular), 630).ToSize();
				graphics.Dispose();
				int num = size.Height + 10;
				if (num < 32)
				{
					num = 32;
				}
				this.clearControls();
				this.ClipVisible = true;
				this.Size = new Size(680, 25 + num);
				this.lightArea1.Size = new Size(640, num);
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
				this.dateLabel.Position = new Point(534, 3);
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
				if (yourRank == 1 || yourRank == 2 || postData.userID == RemoteServices.Instance.UserID || RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
				{
					this.deleteThread.ImageNorm = GFXLibrary.trashcan_normal;
					this.deleteThread.ImageOver = GFXLibrary.trashcan_over;
					this.deleteThread.ImageClick = GFXLibrary.trashcan_clicked;
					this.deleteThread.Position = new Point(680, 4);
					this.deleteThread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "FactionNewForumPostsPanel_delete_post");
					base.addControl(this.deleteThread);
				}
				base.invalidate();
			}

			// Token: 0x06001157 RID: 4439 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001158 RID: 4440 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void clickedLine()
			{
			}

			// Token: 0x06001159 RID: 4441 RVA: 0x00012F40 File Offset: 0x00011140
			private void PopUpOkClick()
			{
				if (this.m_parent != null)
				{
					this.m_parent.deletePost(this.m_postData.postID);
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.deletePostPopUp.Close();
			}

			// Token: 0x0600115A RID: 4442 RVA: 0x00012F75 File Offset: 0x00011175
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

			// Token: 0x0600115B RID: 4443 RVA: 0x00125D68 File Offset: 0x00123F68
			private void deleteClicked()
			{
				this.ClosePopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.deletePostPopUp = new MyMessageBoxPopUp();
				this.deletePostPopUp.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Post", "Delete This Post"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.PopUpOkClick));
				this.deletePostPopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x0600115C RID: 4444 RVA: 0x00012FA8 File Offset: 0x000111A8
			private void copyTextToClipboardClick()
			{
				Clipboard.SetText(this.m_postData.text);
			}

			// Token: 0x04001781 RID: 6017
			private CustomSelfDrawPanel.CSDExtendingPanel lightArea1 = new CustomSelfDrawPanel.CSDExtendingPanel();

			// Token: 0x04001782 RID: 6018
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001783 RID: 6019
			private CustomSelfDrawPanel.CSDLabel userName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001784 RID: 6020
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001785 RID: 6021
			private CustomSelfDrawPanel.CSDLabel bodyLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001786 RID: 6022
			private CustomSelfDrawPanel.CSDButton deleteThread = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04001787 RID: 6023
			private int m_position = -1000;

			// Token: 0x04001788 RID: 6024
			private FactionNewForumPostsPanel.ForumPostData m_postData;

			// Token: 0x04001789 RID: 6025
			private FactionNewForumPostsPanel m_parent;

			// Token: 0x0400178A RID: 6026
			private MyMessageBoxPopUp deletePostPopUp;
		}
	}
}
