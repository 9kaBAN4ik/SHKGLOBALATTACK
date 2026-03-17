using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020000F9 RID: 249
	public class CapitalForumPanel : CustomSelfDrawPanel, IDockableControl, IForumPostParent
	{
		// Token: 0x060007BA RID: 1978 RVA: 0x0000C574 File Offset: 0x0000A774
		public void clearForum()
		{
			this.forumArray = new SparseArray();
			this.lastRefreshTime = DateTime.MinValue;
			this.forumThreadArray = new SparseArray();
			this.currentlySelectedForum = -1L;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x000A885C File Offset: 0x000A6A5C
		public CapitalForumPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000C59F File Offset: 0x0000A79F
		public void setArea(int parishID, int areaType)
		{
			this.selectedAreaID = parishID;
			this.selectedAreaType = areaType;
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x000A898C File Offset: 0x000A6B8C
		public void init(bool resized)
		{
			int height = base.Height;
			CapitalForumPanel.instance = this;
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
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(415, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(549, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			if (this.selectedAreaType == 3)
			{
				this.titleForum = SK.Text("ParishForumPanel_Parish_Forum", "Parish Forum");
			}
			if (this.selectedAreaType == 2)
			{
				this.titleForum = SK.Text("ParishForumPanel_County_Forum", "County Forum");
			}
			if (this.selectedAreaType == 1)
			{
				this.titleForum = SK.Text("ParishForumPanel_Province_Forum", "Province Forum");
			}
			if (this.selectedAreaType == 0)
			{
				this.titleForum = SK.Text("ParishForumPanel_Country_Forum", "Country Forum");
			}
			InterfaceMgr.Instance.setVillageHeading(this.titleForum);
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundImage, 16, new Point(base.Width - 30 + 2, 7), true);
			this.newTopicButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.newTopicButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.newTopicButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.newTopicButton.Position = new Point(20, height - 30);
			this.newTopicButton.Text.Text = SK.Text("FORUMS_New_Topic", "New Topic");
			this.newTopicButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.newTopicButton.TextYOffset = -3;
			this.newTopicButton.Text.Color = global::ARGBColors.Black;
			this.newTopicButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.newTopicClick), "CapitalForumPanel_new_topic");
			this.mainBackgroundImage.addControl(this.newTopicButton);
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
			this.wallScrollArea.Position = new Point(25, 38);
			this.wallScrollArea.Size = new Size(915, height - 80);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, height - 50 - 90 + 60));
			this.mainBackgroundImage.addControl(this.wallScrollArea);
			this.mouseWheelOverlay.Position = this.wallScrollArea.Position;
			this.mouseWheelOverlay.Size = this.wallScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Visible = false;
			this.wallScrollBar.Position = new Point(943, 38);
			this.wallScrollBar.Size = new Size(24, height - 80);
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
			bool flag = false;
			foreach (object obj in this.forumArray)
			{
				CapitalForumPanel.ForumData forumData = (CapitalForumPanel.ForumData)obj;
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

		// Token: 0x060007BE RID: 1982 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x000A9110 File Offset: 0x000A7310
		public void getForumListCallback(GetForumList_ReturnType returnData)
		{
			if (returnData.Success)
			{
				foreach (ForumInfo forumInfo in returnData.forumInfo)
				{
					CapitalForumPanel.ForumData forumData = new CapitalForumPanel.ForumData();
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

		// Token: 0x060007C1 RID: 1985 RVA: 0x000A91E4 File Offset: 0x000A73E4
		public void initForum()
		{
			List<CapitalForumPanel.ForumData> list = new List<CapitalForumPanel.ForumData>();
			foreach (object obj in this.forumArray)
			{
				CapitalForumPanel.ForumData forumData = (CapitalForumPanel.ForumData)obj;
				if (forumData.areaID == this.selectedAreaID && forumData.areaType == this.selectedAreaType)
				{
					list.Add(forumData);
				}
			}
			list.Sort(this.forumComparer);
			bool flag = false;
			foreach (CapitalForumPanel.ForumData forumData2 in list)
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
			if (this.currentlySelectedForum >= 0L)
			{
				RemoteServices.Instance.set_GetForumThreadList_UserCallBack(new RemoteServices.GetForumThreadList_UserCallBack(this.forumThreadListCallback));
				if (this.forumThreadArray[this.currentlySelectedForum] == null || ((CapitalForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum]).lastTime.Year < 1900)
				{
					RemoteServices.Instance.GetForumThreadList(this.currentlySelectedForum, DateTime.MinValue, true);
				}
				else if ((DateTime.Now - ((CapitalForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum]).lastTime).TotalMinutes > 1.0)
				{
					CapitalForumPanel.ForumInfoData forumInfoData = (CapitalForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum];
					RemoteServices.Instance.GetForumThreadList(this.currentlySelectedForum, forumInfoData.lastTime, false);
				}
			}
			this.updateForum();
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x000A93D4 File Offset: 0x000A75D4
		private void forumSelectedClick()
		{
			long dataL = this.ClickedControl.DataL;
			if (dataL != this.currentlySelectedForum)
			{
				this.currentlySelectedForum = dataL;
				this.initForum();
			}
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0000C5AF File Offset: 0x0000A7AF
		private void newTopicClick()
		{
			if (this.m_popup == null || !this.m_popup.Created)
			{
				this.m_popup = new FactionNewTopicPopup();
				this.m_popup.init(this.currentlySelectedForum, this);
				this.m_popup.Show();
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0000C5EE File Offset: 0x0000A7EE
		public void newTopic(long forumID, string heading, string body)
		{
			RemoteServices.Instance.set_NewForumThread_UserCallBack(new RemoteServices.NewForumThread_UserCallBack(this.newForumThreadCallback));
			RemoteServices.Instance.NewForumThread(forumID, heading, body);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000A9404 File Offset: 0x000A7604
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

		// Token: 0x060007C6 RID: 1990 RVA: 0x000A94A8 File Offset: 0x000A76A8
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

		// Token: 0x060007C7 RID: 1991 RVA: 0x000A954C File Offset: 0x000A774C
		public void importThreadList(List<ForumThreadInfo> threadData, long forumID)
		{
			if (threadData != null)
			{
				if (this.forumThreadArray[forumID] == null)
				{
					CapitalForumPanel.ForumInfoData forumInfoData = new CapitalForumPanel.ForumInfoData();
					forumInfoData.forumID = forumID;
					this.forumThreadArray[forumID] = forumInfoData;
				}
				CapitalForumPanel.ForumInfoData forumInfoData2 = (CapitalForumPanel.ForumInfoData)this.forumThreadArray[forumID];
				foreach (ForumThreadInfo forumThreadInfo in threadData)
				{
					CapitalForumPanel.ForumThreadData forumThreadData = new CapitalForumPanel.ForumThreadData();
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
						CapitalForumPanel.ForumThreadData forumThreadData2 = forumInfoData2.forumThreads[i];
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

		// Token: 0x060007C8 RID: 1992 RVA: 0x000A96BC File Offset: 0x000A78BC
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 38 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0000C613 File Offset: 0x0000A813
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

		// Token: 0x060007CA RID: 1994 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x000A9754 File Offset: 0x000A7954
		public void updateForum()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			if (this.currentlySelectedForum >= 0L)
			{
				CapitalForumPanel.ForumInfoData forumInfoData = (CapitalForumPanel.ForumInfoData)this.forumThreadArray[this.currentlySelectedForum];
				if (forumInfoData != null && forumInfoData.forumThreads != null)
				{
					int num2 = 0;
					foreach (CapitalForumPanel.ForumThreadData threadData in forumInfoData.forumThreads)
					{
						CapitalForumPanel.ForumThreadLine forumThreadLine = new CapitalForumPanel.ForumThreadLine();
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

		// Token: 0x060007CC RID: 1996 RVA: 0x0000C645 File Offset: 0x0000A845
		public void deleteTopic(long threadID)
		{
			RemoteServices.Instance.set_DeleteForumThread_UserCallBack(new RemoteServices.DeleteForumThread_UserCallBack(this.deleteForumThreadCallback));
			RemoteServices.Instance.DeleteForumThread(this.selectedAreaID, this.selectedAreaType, this.OrigForumName, this.currentlySelectedForum, threadID);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x000A98BC File Offset: 0x000A7ABC
		public void deleteForumThreadCallback(DeleteForumThread_ReturnType returnData)
		{
			if (returnData.Success && returnData.threadID >= 0L)
			{
				CapitalForumPanel.ForumInfoData forumInfoData = (CapitalForumPanel.ForumInfoData)this.forumThreadArray[returnData.forumID];
				if (forumInfoData != null)
				{
					foreach (CapitalForumPanel.ForumThreadData forumThreadData in forumInfoData.forumThreads)
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

		// Token: 0x060007CE RID: 1998 RVA: 0x0000C680 File Offset: 0x0000A880
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0000C690 File Offset: 0x0000A890
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0000C6A0 File Offset: 0x0000A8A0
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0000C6B2 File Offset: 0x0000A8B2
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0000C6BF File Offset: 0x0000A8BF
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0000C6D9 File Offset: 0x0000A8D9
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0000C6E6 File Offset: 0x0000A8E6
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0000C6F3 File Offset: 0x0000A8F3
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x000A9958 File Offset: 0x000A7B58
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CapitalForumPanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x04000AF9 RID: 2809
		public const int PANEL_ID = 45;

		// Token: 0x04000AFA RID: 2810
		public static CapitalForumPanel instance;

		// Token: 0x04000AFB RID: 2811
		private SparseArray forumArray = new SparseArray();

		// Token: 0x04000AFC RID: 2812
		private SparseArray forumThreadArray = new SparseArray();

		// Token: 0x04000AFD RID: 2813
		private int selectedAreaID = -1;

		// Token: 0x04000AFE RID: 2814
		private int selectedAreaType = -1;

		// Token: 0x04000AFF RID: 2815
		private string OrigForumName = "";

		// Token: 0x04000B00 RID: 2816
		private DateTime lastRefreshTime = DateTime.MinValue;

		// Token: 0x04000B01 RID: 2817
		private CustomSelfDrawPanel.CSDFill mainBackgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04000B02 RID: 2818
		private CustomSelfDrawPanel.CSDImage backgroundFade = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B03 RID: 2819
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B04 RID: 2820
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000B05 RID: 2821
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B06 RID: 2822
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000B07 RID: 2823
		private CustomSelfDrawPanel.CSDLabel threadTitleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B08 RID: 2824
		private CustomSelfDrawPanel.CSDLabel playersLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B09 RID: 2825
		private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000B0A RID: 2826
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04000B0B RID: 2827
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04000B0C RID: 2828
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04000B0D RID: 2829
		private CustomSelfDrawPanel.CSDButton newTopicButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000B0E RID: 2830
		public string titleForum = "";

		// Token: 0x04000B0F RID: 2831
		private long currentlySelectedForum = -1L;

		// Token: 0x04000B10 RID: 2832
		private FactionNewTopicPopup m_popup;

		// Token: 0x04000B11 RID: 2833
		private List<CapitalForumPanel.ForumThreadLine> lineList = new List<CapitalForumPanel.ForumThreadLine>();

		// Token: 0x04000B12 RID: 2834
		public CapitalForumPanel.ForumComparer forumComparer = new CapitalForumPanel.ForumComparer();

		// Token: 0x04000B13 RID: 2835
		private CapitalForumPanel.ThreadComparer threadComparer = new CapitalForumPanel.ThreadComparer();

		// Token: 0x04000B14 RID: 2836
		private DockableControl dockableControl;

		// Token: 0x04000B15 RID: 2837
		private IContainer components;

		// Token: 0x020000FA RID: 250
		public class ForumData
		{
			// Token: 0x04000B16 RID: 2838
			public int areaID = -1;

			// Token: 0x04000B17 RID: 2839
			public int areaType = -1;

			// Token: 0x04000B18 RID: 2840
			public long forumID = -1L;

			// Token: 0x04000B19 RID: 2841
			public string forumTitle = "";

			// Token: 0x04000B1A RID: 2842
			public int numPosts;

			// Token: 0x04000B1B RID: 2843
			public int numReadPosts;

			// Token: 0x04000B1C RID: 2844
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x020000FB RID: 251
		public class ForumThreadData
		{
			// Token: 0x04000B1D RID: 2845
			public string title = "";

			// Token: 0x04000B1E RID: 2846
			public long threadID = -1L;

			// Token: 0x04000B1F RID: 2847
			public DateTime lastTime = DateTime.MinValue;

			// Token: 0x04000B20 RID: 2848
			public string userName = "";

			// Token: 0x04000B21 RID: 2849
			public bool read;
		}

		// Token: 0x020000FC RID: 252
		public class ForumInfoData
		{
			// Token: 0x04000B22 RID: 2850
			public long forumID = -1L;

			// Token: 0x04000B23 RID: 2851
			public List<CapitalForumPanel.ForumThreadData> forumThreads = new List<CapitalForumPanel.ForumThreadData>();

			// Token: 0x04000B24 RID: 2852
			public DateTime lastTime = DateTime.MinValue;
		}

		// Token: 0x020000FD RID: 253
		public class ForumThreadLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x060007DA RID: 2010 RVA: 0x000A99C4 File Offset: 0x000A7BC4
			public void init(CapitalForumPanel.ForumThreadData threadData, int position, CapitalForumPanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_ForumThreadData = threadData;
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
				this.Size = new Size(900, this.backgroundImage.Size.Height);
				this.ClipVisible = true;
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
				if (RemoteServices.Instance.Admin || RemoteServices.Instance.Moderator)
				{
					this.deleteThread.ImageNorm = GFXLibrary.trashcan_normal;
					this.deleteThread.ImageOver = GFXLibrary.trashcan_over;
					this.deleteThread.ImageClick = GFXLibrary.trashcan_clicked;
					this.deleteThread.Position = new Point(870, 4);
					this.deleteThread.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.deleteClicked), "CapitalForumPanel_delete");
					this.backgroundImage.addControl(this.deleteThread);
				}
			}

			// Token: 0x060007DB RID: 2011 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x060007DC RID: 2012 RVA: 0x000A9D34 File Offset: 0x000A7F34
			public void lineClicked()
			{
				GameEngine.Instance.playInterfaceSound("CapitalForumPanel_thread");
				InterfaceMgr.Instance.showCapitalForumPosts(this.m_ForumThreadData.threadID, this.m_parent.currentlySelectedForum, this.m_ForumThreadData.title, this.m_parent.selectedAreaID, this.m_parent.selectedAreaType, this.m_parent.titleForum);
			}

			// Token: 0x060007DD RID: 2013 RVA: 0x000A9D9C File Offset: 0x000A7F9C
			private void deleteClicked()
			{
				this.ClosePopUp();
				InterfaceMgr.Instance.openGreyOutWindow(false);
				this.deletePostPopUp = new MyMessageBoxPopUp();
				this.deletePostPopUp.init(SK.Text("FORUMS_Are_You_Sure", "Are you sure?"), SK.Text("FORUMS_Delete_Topic", "Delete This Topic"), 0, new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.PopUpOkClick));
				this.deletePostPopUp.Show(InterfaceMgr.Instance.getGreyOutWindow());
			}

			// Token: 0x060007DE RID: 2014 RVA: 0x0000C79D File Offset: 0x0000A99D
			private void PopUpOkClick()
			{
				if (this.m_parent != null)
				{
					this.m_parent.deleteTopic(this.m_ForumThreadData.threadID);
				}
				InterfaceMgr.Instance.closeGreyOut();
				this.deletePostPopUp.Close();
			}

			// Token: 0x060007DF RID: 2015 RVA: 0x0000C7D2 File Offset: 0x0000A9D2
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

			// Token: 0x04000B25 RID: 2853
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04000B26 RID: 2854
			private CustomSelfDrawPanel.CSDLabel threadTitleLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B27 RID: 2855
			private CustomSelfDrawPanel.CSDLabel userLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B28 RID: 2856
			private CustomSelfDrawPanel.CSDButton deleteThread = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04000B29 RID: 2857
			private CustomSelfDrawPanel.CSDLabel dateLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04000B2A RID: 2858
			private int m_position = -1000;

			// Token: 0x04000B2B RID: 2859
			private CapitalForumPanel.ForumThreadData m_ForumThreadData;

			// Token: 0x04000B2C RID: 2860
			private CapitalForumPanel m_parent;

			// Token: 0x04000B2D RID: 2861
			private MyMessageBoxPopUp deletePostPopUp;
		}

		// Token: 0x020000FE RID: 254
		public class ForumComparer : IComparer<CapitalForumPanel.ForumData>
		{
			// Token: 0x060007E1 RID: 2017 RVA: 0x0000C805 File Offset: 0x0000AA05
			public int Compare(CapitalForumPanel.ForumData x, CapitalForumPanel.ForumData y)
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

		// Token: 0x020000FF RID: 255
		public class ThreadComparer : IComparer<CapitalForumPanel.ForumThreadData>
		{
			// Token: 0x060007E3 RID: 2019 RVA: 0x0000C837 File Offset: 0x0000AA37
			public int Compare(CapitalForumPanel.ForumThreadData x, CapitalForumPanel.ForumThreadData y)
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
