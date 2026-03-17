using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x0200026A RID: 618
	public class ParishVotePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001B8F RID: 7055 RVA: 0x0001B667 File Offset: 0x00019867
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x0001B677 File Offset: 0x00019877
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x0001B687 File Offset: 0x00019887
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x0001B699 File Offset: 0x00019899
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001B93 RID: 7059 RVA: 0x0001B6A6 File Offset: 0x000198A6
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x0001B6C0 File Offset: 0x000198C0
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x0001B6CD File Offset: 0x000198CD
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x0001B6DA File Offset: 0x000198DA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x001ADE94 File Offset: 0x001AC094
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
			base.Name = "ParishVotePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x001ADF80 File Offset: 0x001AC180
		public ParishVotePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x001AE140 File Offset: 0x001AC340
		public void init(bool resized)
		{
			int num = this.m_currentVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(num);
			int height = base.Height;
			ParishVotePanel.instance = this;
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
			this.parishNameLabel.Text = GameEngine.Instance.World.getParishName(parishFromVillageID);
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.illustrationImage.Image = GFXLibrary.parishwall_village_illlustration_01;
			this.illustrationImage.Position = new Point(17, 5);
			this.backgroundImage.addControl(this.illustrationImage);
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Steward", "Steward") + " : ";
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
			this.proclamationButton.CustomTooltipID = 4200;
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
			this.votesAvailableLabel.Position = new Point(31, 12);
			this.votesAvailableLabel.Size = new Size(300, 40);
			this.votesAvailableLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.votesAvailableLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.wallInfoImage.addControl(this.votesAvailableLabel);
			this.votesAvailableLabelValue.Text = "0";
			this.votesAvailableLabelValue.Color = global::ARGBColors.Black;
			this.votesAvailableLabelValue.Position = new Point(307, 12);
			this.votesAvailableLabelValue.Size = new Size(100, 40);
			this.votesAvailableLabelValue.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.votesAvailableLabelValue.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.votesAvailableLabelValue.Visible = true;
			this.wallInfoImage.addControl(this.votesAvailableLabelValue);
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
				ParishVotePanel.StoredParishInfo storedParishInfo = (ParishVotePanel.StoredParishInfo)this.parishList[parishFromVillageID];
				bool flag = false;
				if (storedParishInfo == null || (DateTime.Now - storedParishInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedParishInfo.lastReturnData == null)
				{
					flag = true;
				}
				this.m_currentVillage = num;
				if (this.currentParish != parishFromVillageID)
				{
					this.parishMembers.Clear();
					this.currentLeaderID = -1;
					this.electedLeaderID = -1;
					this.currentLeaderName = "";
					this.electedLeaderName = "";
					this.m_userIDOnCurrent = -1;
				}
				this.currentParish = parishFromVillageID;
				if (flag)
				{
					this.voteCap = 9999999;
					RemoteServices.Instance.set_GetParishMembersList_UserCallBack(new RemoteServices.GetParishMembersList_UserCallBack(this.getParishMembersListCallback));
					RemoteServices.Instance.GetParishMembersList(this.m_currentVillage);
				}
				this.nextElectionTime = DateTime.MinValue;
				this.votingAllowed = false;
				this.addPlayers();
				if (!flag)
				{
					this.getParishMembersListCallback(storedParishInfo.lastReturnData);
					return;
				}
			}
			else
			{
				this.addPlayers();
			}
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x001AEE70 File Offset: 0x001AD070
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

		// Token: 0x06001B9B RID: 7067 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void createParishWall(WallInfo[] wallInfos)
		{
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateWallArea()
		{
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x001AEEF8 File Offset: 0x001AD0F8
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 158 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001B9F RID: 7071 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001BA0 RID: 7072 RVA: 0x001AEF94 File Offset: 0x001AD194
		public void getParishMembersListCallback(GetParishMembersList_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			ParishVotePanel.StoredParishInfo storedParishInfo = (ParishVotePanel.StoredParishInfo)this.parishList[returnData.parishID];
			if (storedParishInfo == null)
			{
				storedParishInfo = new ParishVotePanel.StoredParishInfo();
				this.parishList[returnData.parishID] = storedParishInfo;
			}
			storedParishInfo.m_lastUpdateTime = DateTime.Now;
			storedParishInfo.lastReturnData = returnData;
			if (this.currentParish == returnData.parishID)
			{
				this.votingAllowed = returnData.votingAllowed;
				if (this.parishMembers == null)
				{
					this.parishMembers = new List<ParishMember>();
				}
				else
				{
					this.parishMembers.Clear();
				}
				if (returnData.parishMembers != null)
				{
					this.parishMembers.AddRange(returnData.parishMembers);
				}
				this.lastProclamationTime = returnData.lastProclamation;
				this.m_userIDOnCurrent = -1;
				this.electedLeaderID = returnData.leaderID;
				this.electedLeaderName = returnData.leaderName;
				this.currentLeaderID = returnData.leaderID;
				this.currentLeaderName = returnData.leaderName;
				this.voteCapLabelValue.Text = returnData.voteCap.ToString();
				this.voteCap = returnData.voteCap;
				this.addPlayers();
			}
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x001AF0B0 File Offset: 0x001AD2B0
		public void addPlayers()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int yourVotes = 0;
			if (this.parishMembers != null)
			{
				foreach (ParishMember parishMember in this.parishMembers)
				{
					if (parishMember.userID == RemoteServices.Instance.UserID)
					{
						yourVotes = parishMember.numSpareVotes;
						break;
					}
				}
				if (GameEngine.Instance.World.getRank() + 1 < GameEngine.Instance.LocalWorldData.MinParishVoteRank)
				{
					int minParishVoteRank = GameEngine.Instance.LocalWorldData.MinParishVoteRank;
					yourVotes = 0;
					this.votesAvailableLabel.Text = string.Concat(new string[]
					{
						SK.Text("ParishPanel_Rank_Required", "Rank Required"),
						" : ",
						Rankings.getRankingName(minParishVoteRank - 1),
						" ( ",
						minParishVoteRank.ToString(),
						" )"
					});
					this.votesAvailableLabel.Size = new Size(400, 40);
					this.votesAvailableLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
					this.voteCapLabelValue.Visible = false;
					this.voteCapLabel.Visible = false;
					this.votesAvailableLabelValue.Visible = false;
				}
				else
				{
					this.votesAvailableLabelValue.Text = yourVotes.ToString();
				}
				this.parishMembers.Sort(this.parishMemberComparer);
				int num2 = 0;
				foreach (ParishMember parishMember2 in this.parishMembers)
				{
					ParishVotePanel.VoteLine voteLine = new ParishVotePanel.VoteLine();
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
					voteLine.init(parishMember2.userName, parishMember2.userID, parishMember2.rank, parishMember2.points, this.votingAllowed, parishMember2.numSpareVotes, parishMember2.numVotesReceived, parishMember2.factionID, yourVotes, num2, this);
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
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Steward", "Steward") + " : " + this.currentLeaderName;
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

		// Token: 0x06001BA2 RID: 7074 RVA: 0x0001B6F9 File Offset: 0x000198F9
		public void voteChanged(int userID)
		{
			RemoteServices.Instance.set_MakeParishVote_UserCallBack(new RemoteServices.MakeParishVote_UserCallBack(this.makeParishVoteCallback));
			RemoteServices.Instance.MakeParishVote(this.m_currentVillage, userID);
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x001AF480 File Offset: 0x001AD680
		private void makeParishVoteCallback(MakeParishVote_ReturnType returnData)
		{
			if (returnData.Success && returnData.returnData != null)
			{
				this.getParishMembersListCallback(returnData.returnData);
				InterfaceMgr.Instance.flushParishFrontPageInfo(returnData.returnData.parishID);
				int countyIDFromParishID = GameEngine.Instance.World.getCountyIDFromParishID(returnData.returnData.parishID);
				if (countyIDFromParishID >= 0 && CountyVotePanel.instance != null)
				{
					CountyVotePanel.instance.flagCountyDirty(countyIDFromParishID);
				}
				GameEngine.Instance.forceFullTick();
			}
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x001AF4FC File Offset: 0x001AD6FC
		private void sendProclamation()
		{
			ParishVotePanel.StoredParishInfo storedParishInfo = (ParishVotePanel.StoredParishInfo)this.parishList[this.currentParish];
			if (storedParishInfo != null)
			{
				storedParishInfo.m_lastUpdateTime = DateTime.MinValue;
			}
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(21);
			InterfaceMgr.Instance.sendProclamation(4, GameEngine.Instance.World.getParishFromVillageID(this.m_currentVillage));
		}

		// Token: 0x04002C35 RID: 11317
		private DockableControl dockableControl;

		// Token: 0x04002C36 RID: 11318
		private IContainer components;

		// Token: 0x04002C37 RID: 11319
		private Panel focusPanel;

		// Token: 0x04002C38 RID: 11320
		public static ParishVotePanel instance;

		// Token: 0x04002C39 RID: 11321
		private SparseArray parishList = new SparseArray();

		// Token: 0x04002C3A RID: 11322
		private List<ParishMember> parishMembers = new List<ParishMember>();

		// Token: 0x04002C3B RID: 11323
		private int currentParish = -1;

		// Token: 0x04002C3C RID: 11324
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x04002C3D RID: 11325
		private DateTime lastProclamationTime = DateTime.MinValue;

		// Token: 0x04002C3E RID: 11326
		private int electedLeaderID = -1;

		// Token: 0x04002C3F RID: 11327
		private string electedLeaderName = "";

		// Token: 0x04002C40 RID: 11328
		private int currentLeaderID = -1;

		// Token: 0x04002C41 RID: 11329
		private string currentLeaderName = "";

		// Token: 0x04002C42 RID: 11330
		private bool votingAllowed;

		// Token: 0x04002C43 RID: 11331
		private int m_userIDOnCurrent = -1;

		// Token: 0x04002C44 RID: 11332
		private int m_currentVillage = -1;

		// Token: 0x04002C45 RID: 11333
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002C46 RID: 11334
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002C47 RID: 11335
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C48 RID: 11336
		private CustomSelfDrawPanel.CSDImage illustrationImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C49 RID: 11337
		private CustomSelfDrawPanel.CSDLabel stewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4A RID: 11338
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4B RID: 11339
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4C RID: 11340
		private CustomSelfDrawPanel.CSDLabel voteCapLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4D RID: 11341
		private CustomSelfDrawPanel.CSDLabel voteCapLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4E RID: 11342
		private CustomSelfDrawPanel.CSDLabel voteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C4F RID: 11343
		private CustomSelfDrawPanel.CSDLabel eligibleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C50 RID: 11344
		private CustomSelfDrawPanel.CSDLabel FactionsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C51 RID: 11345
		private CustomSelfDrawPanel.CSDLabel votesReceivedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C52 RID: 11346
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002C53 RID: 11347
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002C54 RID: 11348
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C55 RID: 11349
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C56 RID: 11350
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002C57 RID: 11351
		private CustomSelfDrawPanel.CSDButton proclamationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002C58 RID: 11352
		private CustomSelfDrawPanel.CSDLabel proclamationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002C59 RID: 11353
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002C5A RID: 11354
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002C5B RID: 11355
		private int voteCap = 9999999;

		// Token: 0x04002C5C RID: 11356
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x04002C5D RID: 11357
		private List<ParishVotePanel.VoteLine> lineList = new List<ParishVotePanel.VoteLine>();

		// Token: 0x04002C5E RID: 11358
		private ParishVotePanel.ParishMemberComparer parishMemberComparer = new ParishVotePanel.ParishMemberComparer();

		// Token: 0x0200026B RID: 619
		public class StoredParishInfo
		{
			// Token: 0x04002C5F RID: 11359
			public GetParishMembersList_ReturnType lastReturnData;

			// Token: 0x04002C60 RID: 11360
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}

		// Token: 0x0200026C RID: 620
		public class ParishMemberComparer : IComparer<ParishMember>
		{
			// Token: 0x06001BA6 RID: 7078 RVA: 0x000EE5E8 File Offset: 0x000EC7E8
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

		// Token: 0x0200026D RID: 621
		public class VoteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001BA8 RID: 7080 RVA: 0x001AF570 File Offset: 0x001AD770
			public void init(string playerName, int userID, int rank, int points, bool votingAllowed, int numSpareVotes, int numReceivedVotes, int factionID, int yourVotes, int position, ParishVotePanel parent)
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
				this.voteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked), "ParishVotePanel_vote");
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
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null && controlForm.IsExclusive)
				{
					this.personName.Text = string.Format("{0} ({1})", playerName, numSpareVotes);
				}
				else
				{
					this.personName.Text = playerName;
				}
				this.personName.Color = global::ARGBColors.Black;
				this.personName.Position = new Point(136, 0);
				this.personName.Size = new Size(225, this.backgroundImage.Height);
				this.personName.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.personName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.personName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClick), "ParishVotePanel_user");
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

			// Token: 0x06001BA9 RID: 7081 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001BAA RID: 7082 RVA: 0x0001B735 File Offset: 0x00019935
			public void lineClicked()
			{
				if (this.m_parent != null)
				{
					this.voteButton.Enabled = false;
					this.m_parent.voteChanged(this.m_userID);
				}
			}

			// Token: 0x06001BAB RID: 7083 RVA: 0x001AFC7C File Offset: 0x001ADE7C
			private void playerClick()
			{
				if (this.m_userID >= 0)
				{
					InterfaceMgr.Instance.closeParishPanel();
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = this.m_userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06001BAC RID: 7084 RVA: 0x0001B75C File Offset: 0x0001995C
			private void factionClick()
			{
				if (this.m_factionID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("ParishVotePanel_faction");
					InterfaceMgr.Instance.closeParishPanel();
					InterfaceMgr.Instance.showFactionPanel(this.m_factionID);
				}
			}

			// Token: 0x04002C61 RID: 11361
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002C62 RID: 11362
			private CustomSelfDrawPanel.CSDLabel personName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002C63 RID: 11363
			private CustomSelfDrawPanel.CSDLabel votesLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002C64 RID: 11364
			private CustomSelfDrawPanel.CSDButton voteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002C65 RID: 11365
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002C66 RID: 11366
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002C67 RID: 11367
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002C68 RID: 11368
			private int m_position = -1000;

			// Token: 0x04002C69 RID: 11369
			private int m_userID = -1;

			// Token: 0x04002C6A RID: 11370
			private int m_factionID = -1;

			// Token: 0x04002C6B RID: 11371
			private ParishVotePanel m_parent;
		}
	}
}
