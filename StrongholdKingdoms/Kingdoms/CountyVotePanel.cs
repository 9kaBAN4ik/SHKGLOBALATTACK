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
	// Token: 0x02000152 RID: 338
	public class CountyVotePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C89 RID: 3209 RVA: 0x0000F4EA File Offset: 0x0000D6EA
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x0000F4FA File Offset: 0x0000D6FA
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x0000F50A File Offset: 0x0000D70A
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x0000F51C File Offset: 0x0000D71C
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x0000F529 File Offset: 0x0000D729
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0000F543 File Offset: 0x0000D743
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x0000F550 File Offset: 0x0000D750
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x0000F55D File Offset: 0x0000D75D
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x000F0850 File Offset: 0x000EEA50
		private void InitializeComponent()
		{
			this.focusPanel = new Panel();
			base.SuspendLayout();
			this.focusPanel.BackColor = global::ARGBColors.Transparent;
			this.focusPanel.ForeColor = global::ARGBColors.Transparent;
			this.focusPanel.Location = new Point(988, 3);
			this.focusPanel.Name = "focusPanel";
			this.focusPanel.Size = new Size(1, 1);
			this.focusPanel.TabIndex = 0;
			base.AutoScaleMode = AutoScaleMode.None;
			base.Controls.Add(this.focusPanel);
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Name = "CountyVotePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x000F093C File Offset: 0x000EEB3C
		public CountyVotePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x000F0AFC File Offset: 0x000EECFC
		public void init(bool resized)
		{
			int num = this.m_currentVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(num);
			int height = base.Height;
			CountyVotePanel.instance = this;
			base.clearControls();
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			CustomSelfDrawPanel.WikiLinkControl.init(this.backgroundImage, 15, new Point(base.Width - 44, 3));
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 129);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(95, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.divider2Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider2Image.Position = new Point(366, 0);
			this.headerLabelsImage.addControl(this.divider2Image);
			this.divider3Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider3Image.Position = new Point(627, 0);
			this.headerLabelsImage.addControl(this.divider3Image);
			this.parishNameLabel.Text = GameEngine.Instance.World.getVillageName(this.m_currentVillage) + " (" + GameEngine.Instance.World.getCountyName(countyFromVillageID) + ")";
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.illustrationImage.Image = GFXLibrary.parishwall_village_illlustration_02;
			this.illustrationImage.Position = new Point(17, 5);
			this.backgroundImage.addControl(this.illustrationImage);
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Sheriff", "Sheriff") + " : ";
			this.stewardLabel.Color = global::ARGBColors.Black;
			this.stewardLabel.Position = new Point(5, 5);
			this.stewardLabel.Size = new Size(this.illustrationImage.Width - 6, 30);
			this.stewardLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
			this.stewardLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.illustrationImage.addControl(this.stewardLabel);
			this.proclamationButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
			this.proclamationButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
			this.proclamationButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
			this.proclamationButton.Position = new Point(base.Width - 220, 7);
			this.proclamationButton.Text.Text = SK.Text("Capitials_Proclamation", "Send Proclamation");
			this.proclamationButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.proclamationButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.proclamationButton.TextYOffset = -3;
			this.proclamationButton.Text.Color = global::ARGBColors.Black;
			this.proclamationButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.sendProclamation));
			this.proclamationButton.CustomTooltipID = 4201;
			this.proclamationButton.Visible = false;
			this.headerImage.addControl(this.proclamationButton);
			this.proclamationLabel.Text = "";
			this.proclamationLabel.Color = global::ARGBColors.White;
			this.proclamationLabel.DropShadowColor = global::ARGBColors.Black;
			this.proclamationLabel.Position = new Point(20, 0);
			this.proclamationLabel.Size = new Size(base.Width - 40 - 220, 40);
			this.proclamationLabel.Font = FontManager.GetFont("Arial", 8f, FontStyle.Regular);
			this.proclamationLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_RIGHT;
			this.proclamationLabel.Visible = false;
			this.headerImage.addControl(this.proclamationLabel);
			this.wallInfoImage.Size = new Size(440, 85);
			this.wallInfoImage.Position = new Point(460, 20);
			this.backgroundImage.addControl(this.wallInfoImage);
			this.wallInfoImage.Create(GFXLibrary.mail2_rounded_rectangle_tan_upper_left, GFXLibrary.mail2_rounded_rectangle_tan_upper_middle, GFXLibrary.mail2_rounded_rectangle_tan_upper_right, GFXLibrary.mail2_rounded_rectangle_tan_middle_left, GFXLibrary.mail2_rounded_rectangle_tan_middle_middle, GFXLibrary.mail2_rounded_rectangle_tan_middle_right, GFXLibrary.mail2_rounded_rectangle_tan_bottom_left, GFXLibrary.mail2_rounded_rectangle_tan_bottom_middle, GFXLibrary.mail2_rounded_rectangle_tan_bottom_right);
			this.wallScrollArea.Position = new Point(25, 158);
			this.wallScrollArea.Size = new Size(915, height - 212);
			this.wallScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, height - 212));
			this.backgroundImage.addControl(this.wallScrollArea);
			int value = this.wallScrollBar.Value;
			this.wallScrollBar.Position = new Point(943, 158);
			this.wallScrollBar.Size = new Size(24, height - 212);
			this.backgroundImage.addControl(this.wallScrollBar);
			this.wallScrollBar.Value = 0;
			this.wallScrollBar.Max = 100;
			this.wallScrollBar.NumVisibleLines = 25;
			this.wallScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.wallScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.votesAvailableLabel.Text = SK.Text("GENERIC_Votes_Available", "Votes Available") + " :";
			this.votesAvailableLabel.Color = global::ARGBColors.Black;
			this.votesAvailableLabel.Position = new Point(31, 27);
			this.votesAvailableLabel.Size = new Size(300, 40);
			this.votesAvailableLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.votesAvailableLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.wallInfoImage.addControl(this.votesAvailableLabel);
			this.votesAvailableLabelValue.Text = "0";
			this.votesAvailableLabelValue.Color = global::ARGBColors.Black;
			this.votesAvailableLabelValue.Position = new Point(307, 27);
			this.votesAvailableLabelValue.Size = new Size(100, 40);
			this.votesAvailableLabelValue.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.votesAvailableLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.votesAvailableLabelValue.Visible = true;
			this.wallInfoImage.addControl(this.votesAvailableLabelValue);
			this.voteCapLabel.Visible = false;
			if (GameEngine.Instance.World.SecondAgeWorld || GameEngine.Instance.LocalWorldData.EraWorld || GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.votesAvailableLabel.Position = new Point(31, 12);
				this.votesAvailableLabelValue.Position = new Point(307, 12);
				this.voteCapLabel.Text = SK.Text("ParishPanel_Current_Vote_cap", "Current Vote Cap") + " :";
				this.voteCapLabel.Color = global::ARGBColors.Black;
				this.voteCapLabel.Position = new Point(31, 42);
				this.voteCapLabel.Size = new Size(300, 40);
				this.voteCapLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
				this.voteCapLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.voteCapLabel.Visible = true;
				this.wallInfoImage.addControl(this.voteCapLabel);
				this.voteCapLabelValue.Text = "0";
				this.voteCapLabelValue.Color = global::ARGBColors.Black;
				this.voteCapLabelValue.Position = new Point(307, 42);
				this.voteCapLabelValue.Size = new Size(100, 40);
				this.voteCapLabelValue.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
				this.voteCapLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
				this.voteCapLabelValue.Visible = true;
				this.wallInfoImage.addControl(this.voteCapLabelValue);
			}
			this.voteLabel.Text = SK.Text("GENERIC_Vote", "Vote");
			this.voteLabel.Color = global::ARGBColors.Black;
			this.voteLabel.Position = new Point(15, -2);
			this.voteLabel.Size = new Size(81, this.headerLabelsImage.Height);
			this.voteLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.voteLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.voteLabel);
			this.eligibleLabel.Text = SK.Text("GENERIC_Eligible_Candidates", "Eligible Candidates");
			this.eligibleLabel.Color = global::ARGBColors.Black;
			this.eligibleLabel.Position = new Point(106, -2);
			this.eligibleLabel.Size = new Size(250, this.headerLabelsImage.Height);
			this.eligibleLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.eligibleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.eligibleLabel);
			this.FactionsLabel.Text = SK.Text("STATS_CATEGORY_TITLE_FACTION", "Faction");
			this.FactionsLabel.Color = global::ARGBColors.Black;
			this.FactionsLabel.Position = new Point(376, -2);
			this.FactionsLabel.Size = new Size(247, this.headerLabelsImage.Height);
			this.FactionsLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.FactionsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.FactionsLabel);
			this.votesReceivedLabel.Text = SK.Text("GENERIC_Votes_Received", "Votes Received");
			this.votesReceivedLabel.Color = global::ARGBColors.Black;
			this.votesReceivedLabel.Position = new Point(635, -2);
			this.votesReceivedLabel.Size = new Size(300, this.headerLabelsImage.Height);
			this.votesReceivedLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.votesReceivedLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.votesReceivedLabel);
			if (!resized)
			{
				CountyVotePanel.StoredCountyInfo storedCountyInfo = (CountyVotePanel.StoredCountyInfo)this.countyList[countyFromVillageID];
				bool flag = false;
				if (storedCountyInfo == null || (DateTime.Now - storedCountyInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedCountyInfo.lastReturnData == null)
				{
					flag = true;
				}
				this.m_currentVillage = num;
				if (this.currentCounty != countyFromVillageID)
				{
					this.countyMembers.Clear();
					this.currentLeaderID = -1;
					this.electedLeaderID = -1;
					this.currentLeaderName = "";
					this.electedLeaderName = "";
					this.m_userIDOnCurrent = -1;
				}
				this.currentCounty = countyFromVillageID;
				if (flag)
				{
					RemoteServices.Instance.set_GetCountyElectionInfo_UserCallBack(new RemoteServices.GetCountyElectionInfo_UserCallBack(this.getCountyElectionInfoCallback));
					RemoteServices.Instance.GetCountyElectionInfo(this.m_currentVillage);
				}
				this.nextElectionTime = DateTime.MinValue;
				this.votingAllowed = false;
				this.addPlayers();
				if (!flag)
				{
					this.getCountyElectionInfoCallback(storedCountyInfo.lastReturnData);
					return;
				}
			}
			else
			{
				this.addPlayers();
			}
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x000F18B4 File Offset: 0x000EFAB4
		public void update()
		{
			if (this.proclamationLabel.Visible)
			{
				TimeSpan timeSpan = VillageMap.getCurrentServerTime() - this.lastProclamationTime;
				if (timeSpan.TotalDays >= 7.0)
				{
					this.proclamationLabel.Visible = false;
					this.proclamationButton.Enabled = true;
					return;
				}
				this.proclamationLabel.Text = SK.Text("Proclamations_time_to_go", "Time before next Proclamation : ") + VillageMap.createBuildTimeString(604800 - (int)timeSpan.TotalSeconds);
			}
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void createParishWall(WallInfo[] wallInfos)
		{
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateWallArea()
		{
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x000F193C File Offset: 0x000EFB3C
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 158 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x000F19D8 File Offset: 0x000EFBD8
		public void getCountyElectionInfoCallback(GetCountyElectionInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			CountyVotePanel.StoredCountyInfo storedCountyInfo = (CountyVotePanel.StoredCountyInfo)this.countyList[returnData.countyID];
			if (storedCountyInfo == null)
			{
				storedCountyInfo = new CountyVotePanel.StoredCountyInfo();
				this.countyList[returnData.countyID] = storedCountyInfo;
			}
			storedCountyInfo.m_lastUpdateTime = DateTime.Now;
			storedCountyInfo.lastReturnData = returnData;
			if (this.currentCounty == returnData.countyID)
			{
				this.votingAllowed = returnData.votingAllowed;
				if (this.countyMembers == null)
				{
					this.countyMembers = new List<ParishMember>();
				}
				else
				{
					this.countyMembers.Clear();
				}
				if (returnData.countyMembers != null)
				{
					this.countyMembers.AddRange(returnData.countyMembers);
					int num = 0;
					foreach (ParishMember parishMember in this.countyMembers)
					{
						if (parishMember.userID == RemoteServices.Instance.UserID)
						{
							num = parishMember.numSpareVotes;
							break;
						}
					}
					this.votesAvailableLabelValue.Text = num.ToString();
				}
				else
				{
					this.votesAvailableLabel.Text = SK.Text("CountyPanel_More_Parishes_Needed", "More Parishes need to be active before an election is held");
					this.votesAvailableLabel.Position = new Point(31, 12);
					this.votesAvailableLabel.Size = new Size(400, 100);
					this.votesAvailableLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
					this.votesAvailableLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.votesAvailableLabelValue.Visible = false;
					this.wallInfoImage.invalidate();
				}
				this.m_userIDOnCurrent = -1;
				this.electedLeaderID = returnData.leaderID;
				this.electedLeaderName = returnData.leaderName;
				this.lastProclamationTime = returnData.lastProclamation;
				this.currentLeaderID = returnData.leaderID;
				this.currentLeaderName = returnData.leaderName;
				this.voteCap = returnData.voteCap;
				if (GameEngine.Instance.LocalWorldData.AIWorld && this.voteCap < 100000 && !this.voteCapLabel.Visible)
				{
					this.votesAvailableLabel.Position = new Point(31, 12);
					this.votesAvailableLabelValue.Position = new Point(307, 12);
					this.voteCapLabel.Text = SK.Text("ParishPanel_Current_Vote_cap", "Current Vote Cap") + " :";
					this.voteCapLabel.Color = global::ARGBColors.Black;
					this.voteCapLabel.Position = new Point(31, 42);
					this.voteCapLabel.Size = new Size(300, 40);
					this.voteCapLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.voteCapLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.voteCapLabel.Visible = true;
					this.wallInfoImage.addControl(this.voteCapLabel);
					this.voteCapLabelValue.Text = "0";
					this.voteCapLabelValue.Color = global::ARGBColors.Black;
					this.voteCapLabelValue.Position = new Point(307, 42);
					this.voteCapLabelValue.Size = new Size(100, 40);
					this.voteCapLabelValue.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
					this.voteCapLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
					this.voteCapLabelValue.Visible = true;
					this.wallInfoImage.addControl(this.voteCapLabelValue);
					this.wallInfoImage.invalidate();
				}
				this.voteCapLabelValue.Text = returnData.voteCap.ToString();
				this.addPlayers();
			}
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x000F1D88 File Offset: 0x000EFF88
		public void addPlayers()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int yourVotes = 0;
			if (this.countyMembers != null)
			{
				foreach (ParishMember parishMember in this.countyMembers)
				{
					if (parishMember.userID == RemoteServices.Instance.UserID)
					{
						yourVotes = parishMember.numSpareVotes;
						break;
					}
				}
				this.countyMembers.Sort(this.parishMemberComparer);
				int num2 = 0;
				foreach (ParishMember parishMember2 in this.countyMembers)
				{
					CountyVotePanel.VoteLine voteLine = new CountyVotePanel.VoteLine();
					if (num != 0)
					{
						num += 5;
					}
					voteLine.Position = new Point(0, num);
					int numVotesReceived = parishMember2.numVotesReceived;
					if (numVotesReceived > this.voteCap)
					{
						numVotesReceived = this.voteCap;
					}
					voteLine.init(parishMember2.userName, parishMember2.userID, parishMember2.rank, parishMember2.points, this.votingAllowed, parishMember2.numSpareVotes, numVotesReceived, parishMember2.areaID, parishMember2.factionID, yourVotes, num2, this);
					this.wallScrollArea.addControl(voteLine);
					num += voteLine.Height;
					this.lineList.Add(voteLine);
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
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Sheriff", "Sheriff") + " : " + this.currentLeaderName;
			this.m_userIDOnCurrent = this.currentLeaderID;
			TimeSpan timeSpan = VillageMap.getCurrentServerTime() - this.lastProclamationTime;
			if (this.currentLeaderID == RemoteServices.Instance.UserID)
			{
				this.proclamationButton.Visible = true;
				if (timeSpan.TotalDays >= 7.0)
				{
					this.proclamationButton.Enabled = true;
					this.proclamationLabel.Visible = false;
				}
				else
				{
					this.proclamationButton.Enabled = false;
					this.proclamationLabel.Visible = true;
				}
			}
			else
			{
				this.proclamationButton.Visible = false;
				this.proclamationLabel.Visible = false;
			}
			this.update();
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x0000F57C File Offset: 0x0000D77C
		public void voteChanged(int userID)
		{
			RemoteServices.Instance.set_MakeCountyVote_UserCallBack(new RemoteServices.MakeCountyVote_UserCallBack(this.makeCountyVoteCallback));
			RemoteServices.Instance.MakeCountyVote(this.m_currentVillage, userID);
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x0000F5A5 File Offset: 0x0000D7A5
		private void makeCountyVoteCallback(MakeCountyVote_ReturnType returnData)
		{
			if (returnData.Success && returnData.returnData != null)
			{
				this.getCountyElectionInfoCallback(returnData.returnData);
				GameEngine.Instance.forceFullTick();
			}
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x000F2064 File Offset: 0x000F0264
		private void sendProclamation()
		{
			CountyVotePanel.StoredCountyInfo storedCountyInfo = (CountyVotePanel.StoredCountyInfo)this.countyList[this.currentCounty];
			if (storedCountyInfo != null)
			{
				storedCountyInfo.m_lastUpdateTime = DateTime.MinValue;
			}
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(21);
			InterfaceMgr.Instance.sendProclamation(5, GameEngine.Instance.World.getCountyFromVillageID(this.m_currentVillage));
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x000F20D8 File Offset: 0x000F02D8
		public void flagCountyDirty(int countyID)
		{
			CountyVotePanel.StoredCountyInfo storedCountyInfo = (CountyVotePanel.StoredCountyInfo)this.countyList[countyID];
			if (storedCountyInfo != null)
			{
				storedCountyInfo.m_lastUpdateTime = DateTime.MinValue;
			}
		}

		// Token: 0x040010AA RID: 4266
		private DockableControl dockableControl;

		// Token: 0x040010AB RID: 4267
		private IContainer components;

		// Token: 0x040010AC RID: 4268
		private Panel focusPanel;

		// Token: 0x040010AD RID: 4269
		public static CountyVotePanel instance;

		// Token: 0x040010AE RID: 4270
		private SparseArray countyList = new SparseArray();

		// Token: 0x040010AF RID: 4271
		private int voteCap = 100000;

		// Token: 0x040010B0 RID: 4272
		private List<ParishMember> countyMembers = new List<ParishMember>();

		// Token: 0x040010B1 RID: 4273
		private int currentCounty = -1;

		// Token: 0x040010B2 RID: 4274
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x040010B3 RID: 4275
		private DateTime lastProclamationTime = DateTime.MinValue;

		// Token: 0x040010B4 RID: 4276
		private int electedLeaderID = -1;

		// Token: 0x040010B5 RID: 4277
		private string electedLeaderName = "";

		// Token: 0x040010B6 RID: 4278
		private int currentLeaderID = -1;

		// Token: 0x040010B7 RID: 4279
		private string currentLeaderName = "";

		// Token: 0x040010B8 RID: 4280
		private bool votingAllowed;

		// Token: 0x040010B9 RID: 4281
		private int m_userIDOnCurrent = -1;

		// Token: 0x040010BA RID: 4282
		private int m_currentVillage = -1;

		// Token: 0x040010BB RID: 4283
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040010BC RID: 4284
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040010BD RID: 4285
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010BE RID: 4286
		private CustomSelfDrawPanel.CSDImage illustrationImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040010BF RID: 4287
		private CustomSelfDrawPanel.CSDLabel stewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C0 RID: 4288
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C1 RID: 4289
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C2 RID: 4290
		private CustomSelfDrawPanel.CSDLabel voteCapLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C3 RID: 4291
		private CustomSelfDrawPanel.CSDLabel voteCapLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C4 RID: 4292
		private CustomSelfDrawPanel.CSDLabel voteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C5 RID: 4293
		private CustomSelfDrawPanel.CSDLabel eligibleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C6 RID: 4294
		private CustomSelfDrawPanel.CSDLabel FactionsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C7 RID: 4295
		private CustomSelfDrawPanel.CSDLabel votesReceivedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010C8 RID: 4296
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x040010C9 RID: 4297
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x040010CA RID: 4298
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040010CB RID: 4299
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040010CC RID: 4300
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x040010CD RID: 4301
		private CustomSelfDrawPanel.CSDButton proclamationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x040010CE RID: 4302
		private CustomSelfDrawPanel.CSDLabel proclamationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x040010CF RID: 4303
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x040010D0 RID: 4304
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x040010D1 RID: 4305
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x040010D2 RID: 4306
		private List<CountyVotePanel.VoteLine> lineList = new List<CountyVotePanel.VoteLine>();

		// Token: 0x040010D3 RID: 4307
		private CountyVotePanel.ParishMemberComparer parishMemberComparer = new CountyVotePanel.ParishMemberComparer();

		// Token: 0x02000153 RID: 339
		public class StoredCountyInfo
		{
			// Token: 0x040010D4 RID: 4308
			public GetCountyElectionInfo_ReturnType lastReturnData;

			// Token: 0x040010D5 RID: 4309
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}

		// Token: 0x02000154 RID: 340
		public class ParishMemberComparer : IComparer<ParishMember>
		{
			// Token: 0x06000CA1 RID: 3233 RVA: 0x000EE5E8 File Offset: 0x000EC7E8
			public int Compare(ParishMember x, ParishMember y)
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
					if (x.numVotesReceived < y.numVotesReceived)
					{
						return 1;
					}
					if (x.numVotesReceived > y.numVotesReceived)
					{
						return -1;
					}
					return x.userName.CompareTo(y.userName);
				}
			}
		}

		// Token: 0x02000155 RID: 341
		public class VoteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000CA3 RID: 3235 RVA: 0x000F2108 File Offset: 0x000F0308
			public void init(string playerName, int userID, int rank, int points, bool votingAllowed, int numSpareVotes, int numReceivedVotes, int parishID, int factionID, int yourVotes, int position, CountyVotePanel parent)
			{
				this.m_parent = parent;
				this.m_position = position;
				this.m_userID = userID;
				this.m_factionID = factionID;
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
				base.addControl(this.backgroundImage);
				this.Size = this.backgroundImage.Size;
				this.voteButton.ImageNorm = GFXLibrary.parishwall_button_vote_checked_normal;
				this.voteButton.ImageOver = GFXLibrary.parishwall_button_vote_checked_over;
				this.voteButton.Position = new Point(8, 4);
				this.voteButton.Text.Text = SK.Text("GENERIC_Vote", "Vote");
				this.voteButton.Text.Color = global::ARGBColors.Black;
				this.voteButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.voteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked), "CountyVotePanel_vote");
				this.backgroundImage.addControl(this.voteButton);
				if (yourVotes > 0 && !GameEngine.Instance.World.WorldEnded)
				{
					this.voteButton.Enabled = true;
				}
				else
				{
					this.voteButton.Enabled = false;
				}
				NumberFormatInfo nfi = GameEngine.NFI;
				int num = 0;
				if (factionID >= 0)
				{
					FactionData faction = GameEngine.Instance.World.getFaction(factionID);
					if (faction != null)
					{
						this.factionName.Text = faction.factionNameAbrv;
						int houseID = faction.houseID;
						if (houseID > 0)
						{
							this.houseImage.Image = GFXLibrary.house_flag_001_small;
							switch (houseID)
							{
							case 1:
								this.houseImage.Image = GFXLibrary.house_flag_001_small;
								break;
							case 2:
								this.houseImage.Image = GFXLibrary.house_flag_002_small;
								break;
							case 3:
								this.houseImage.Image = GFXLibrary.house_flag_003_small;
								break;
							case 4:
								this.houseImage.Image = GFXLibrary.house_flag_004_small;
								break;
							case 5:
								this.houseImage.Image = GFXLibrary.house_flag_005_small;
								break;
							case 6:
								this.houseImage.Image = GFXLibrary.house_flag_006_small;
								break;
							case 7:
								this.houseImage.Image = GFXLibrary.house_flag_007_small;
								break;
							case 8:
								this.houseImage.Image = GFXLibrary.house_flag_008_small;
								break;
							case 9:
								this.houseImage.Image = GFXLibrary.house_flag_009_small;
								break;
							case 10:
								this.houseImage.Image = GFXLibrary.house_flag_010_small;
								break;
							case 11:
								this.houseImage.Image = GFXLibrary.house_flag_011_small;
								break;
							case 12:
								this.houseImage.Image = GFXLibrary.house_flag_012_small;
								break;
							case 13:
								this.houseImage.Image = GFXLibrary.house_flag_013_small;
								break;
							case 14:
								this.houseImage.Image = GFXLibrary.house_flag_014_small;
								break;
							case 15:
								this.houseImage.Image = GFXLibrary.house_flag_015_small;
								break;
							case 16:
								this.houseImage.Image = GFXLibrary.house_flag_016_small;
								break;
							case 17:
								this.houseImage.Image = GFXLibrary.house_flag_017_small;
								break;
							case 18:
								this.houseImage.Image = GFXLibrary.house_flag_018_small;
								break;
							case 19:
								this.houseImage.Image = GFXLibrary.house_flag_019_small;
								break;
							case 20:
								this.houseImage.Image = GFXLibrary.house_flag_020_small;
								break;
							}
							this.houseImage.Position = new Point(377, 5);
							this.houseImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick));
							this.backgroundImage.addControl(this.houseImage);
							num = 32;
						}
					}
					else
					{
						this.factionName.Text = "";
					}
				}
				else
				{
					this.factionName.Text = "";
				}
				this.factionName.Color = global::ARGBColors.Black;
				this.factionName.Position = new Point(377 + num, 0);
				this.factionName.Size = new Size(210, this.backgroundImage.Height);
				this.factionName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.factionName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				if (factionID >= 0)
				{
					this.factionName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.factionClick));
				}
				this.backgroundImage.addControl(this.factionName);
				this.personName.Text = playerName;
				this.personName.Color = global::ARGBColors.Black;
				this.personName.Position = new Point(136, 0);
				this.personName.Size = new Size(225, this.backgroundImage.Height);
				this.personName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.personName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.personName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClick), "CountyVotePanel_user_clicked");
				this.backgroundImage.addControl(this.personName);
				this.votesLabel.Text = numReceivedVotes.ToString("N", nfi);
				this.votesLabel.Color = global::ARGBColors.Black;
				this.votesLabel.Position = new Point(635, 0);
				this.votesLabel.Size = new Size(150, this.backgroundImage.Height);
				this.votesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.votesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.votesLabel);
				this.shieldImage.Image = GameEngine.Instance.World.getWorldShield(userID, 25, 28);
				if (this.shieldImage.Image != null)
				{
					this.shieldImage.Position = new Point(106, 1);
					this.shieldImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClick));
					this.backgroundImage.addControl(this.shieldImage);
				}
				base.invalidate();
			}

			// Token: 0x06000CA4 RID: 3236 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06000CA5 RID: 3237 RVA: 0x0000F5E0 File Offset: 0x0000D7E0
			public void lineClicked()
			{
				if (this.m_parent != null)
				{
					this.voteButton.Enabled = false;
					this.m_parent.voteChanged(this.m_userID);
				}
			}

			// Token: 0x06000CA6 RID: 3238 RVA: 0x000F27E0 File Offset: 0x000F09E0
			private void playerClick()
			{
				if (this.m_userID >= 0)
				{
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = this.m_userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06000CA7 RID: 3239 RVA: 0x0000F607 File Offset: 0x0000D807
			private void factionClick()
			{
				if (this.m_factionID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("CountyVotePanel_faction");
					InterfaceMgr.Instance.showFactionPanel(this.m_factionID);
				}
			}

			// Token: 0x040010D6 RID: 4310
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040010D7 RID: 4311
			private CustomSelfDrawPanel.CSDLabel personName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040010D8 RID: 4312
			private CustomSelfDrawPanel.CSDLabel votesLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040010D9 RID: 4313
			private CustomSelfDrawPanel.CSDButton voteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x040010DA RID: 4314
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x040010DB RID: 4315
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040010DC RID: 4316
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x040010DD RID: 4317
			private int m_position = -1000;

			// Token: 0x040010DE RID: 4318
			private int m_userID = -1;

			// Token: 0x040010DF RID: 4319
			private int m_factionID = -1;

			// Token: 0x040010E0 RID: 4320
			private CountyVotePanel m_parent;
		}
	}
}
