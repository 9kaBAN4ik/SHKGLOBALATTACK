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
	// Token: 0x0200014B RID: 331
	public class CountryVotePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x0000F1D1 File Offset: 0x0000D3D1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0000F1E1 File Offset: 0x0000D3E1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0000F1F1 File Offset: 0x0000D3F1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0000F203 File Offset: 0x0000D403
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0000F210 File Offset: 0x0000D410
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0000F22A File Offset: 0x0000D42A
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0000F237 File Offset: 0x0000D437
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x0000F244 File Offset: 0x0000D444
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x000ECD34 File Offset: 0x000EAF34
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
			base.Name = "CountryVotePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x000ECE20 File Offset: 0x000EB020
		public CountryVotePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x000ECFE0 File Offset: 0x000EB1E0
		public void init(bool resized)
		{
			int num = this.m_currentVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int countryFromVillageID = GameEngine.Instance.World.getCountryFromVillageID(num);
			int height = base.Height;
			CountryVotePanel.instance = this;
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
			this.parishNameLabel.Text = GameEngine.Instance.World.getVillageName(this.m_currentVillage) + " (" + GameEngine.Instance.World.getCountryName(countryFromVillageID) + ")";
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.illustrationImage.Image = GFXLibrary.parishwall_village_illlustration_04;
			this.illustrationImage.Position = new Point(17, 5);
			this.backgroundImage.addControl(this.illustrationImage);
			this.stewardLabel.Text = "";
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
			this.proclamationButton.CustomTooltipID = 4203;
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
				CountryVotePanel.StoredCountryInfo storedCountryInfo = (CountryVotePanel.StoredCountryInfo)this.countryList[countryFromVillageID];
				bool flag = false;
				if (storedCountryInfo == null || (DateTime.Now - storedCountryInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedCountryInfo.lastReturnData == null)
				{
					flag = true;
				}
				this.m_currentVillage = num;
				if (this.currentCountry != countryFromVillageID)
				{
					this.countryMembers.Clear();
					this.currentLeaderID = -1;
					this.electedLeaderID = -1;
					this.currentLeaderName = "";
					this.electedLeaderName = "";
					this.m_userIDOnCurrent = -1;
				}
				this.currentCountry = countryFromVillageID;
				if (flag)
				{
					RemoteServices.Instance.set_GetCountryElectionInfo_UserCallBack(new RemoteServices.GetCountryElectionInfo_UserCallBack(this.getCountryElectionInfoCallback));
					RemoteServices.Instance.GetCountryElectionInfo(this.m_currentVillage);
				}
				this.nextElectionTime = DateTime.MinValue;
				this.votingAllowed = false;
				this.addPlayers();
				if (!flag)
				{
					this.getCountryElectionInfoCallback(storedCountryInfo.lastReturnData);
					return;
				}
			}
			else
			{
				this.addPlayers();
			}
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x000EDD84 File Offset: 0x000EBF84
		public void update()
		{
			if (this.proclamationLabel.Visible)
			{
				TimeSpan timeSpan = VillageMap.getCurrentServerTime() - this.lastProclamationTime;
				if (timeSpan.TotalDays >= 3.0)
				{
					this.proclamationLabel.Visible = false;
					this.proclamationButton.Enabled = true;
					return;
				}
				this.proclamationLabel.Text = SK.Text("Proclamations_time_to_go", "Time before next Proclamation : ") + VillageMap.createBuildTimeString(259200 - (int)timeSpan.TotalSeconds);
			}
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void createParishWall(WallInfo[] wallInfos)
		{
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateWallArea()
		{
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x000EDE0C File Offset: 0x000EC00C
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 158 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x000EDEA8 File Offset: 0x000EC0A8
		public void getCountryElectionInfoCallback(GetCountryElectionInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			CountryVotePanel.StoredCountryInfo storedCountryInfo = (CountryVotePanel.StoredCountryInfo)this.countryList[returnData.countryID];
			if (storedCountryInfo == null)
			{
				storedCountryInfo = new CountryVotePanel.StoredCountryInfo();
				this.countryList[returnData.countryID] = storedCountryInfo;
			}
			storedCountryInfo.m_lastUpdateTime = DateTime.Now;
			storedCountryInfo.lastReturnData = returnData;
			if (this.currentCountry == returnData.countryID)
			{
				this.votingAllowed = returnData.votingAllowed;
				if (this.countryMembers == null)
				{
					this.countryMembers = new List<ParishMember>();
				}
				else
				{
					this.countryMembers.Clear();
				}
				if (returnData.countryMembers != null)
				{
					this.countryMembers.AddRange(returnData.countryMembers);
					int num = 0;
					foreach (ParishMember parishMember in this.countryMembers)
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
					this.votesAvailableLabel.Text = SK.Text("CountryPanel_All_Provinces_Needed", "All Provinces need to be active before an election is held");
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
				this.currentLeaderMale = returnData.leaderMale;
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

		// Token: 0x06000C54 RID: 3156 RVA: 0x000EE264 File Offset: 0x000EC464
		public void addPlayers()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int yourVotes = 0;
			if (this.countryMembers != null)
			{
				foreach (ParishMember parishMember in this.countryMembers)
				{
					if (parishMember.userID == RemoteServices.Instance.UserID)
					{
						yourVotes = parishMember.numSpareVotes;
						break;
					}
				}
				this.countryMembers.Sort(this.parishMemberComparer);
				int num2 = 0;
				foreach (ParishMember parishMember2 in this.countryMembers)
				{
					CountryVotePanel.VoteLine voteLine = new CountryVotePanel.VoteLine();
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
			if (this.currentLeaderMale)
			{
				this.stewardLabel.Text = SK.Text("ParishWallPanel_King", "King") + " : " + this.currentLeaderName;
			}
			else
			{
				this.stewardLabel.Text = SK.Text("ParishWallPanel_Queen", "Queen") + " : " + this.currentLeaderName;
			}
			this.m_userIDOnCurrent = this.currentLeaderID;
			TimeSpan timeSpan = VillageMap.getCurrentServerTime() - this.lastProclamationTime;
			if (this.currentLeaderID == RemoteServices.Instance.UserID)
			{
				this.proclamationButton.Visible = true;
				if (timeSpan.TotalDays >= 3.0)
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

		// Token: 0x06000C55 RID: 3157 RVA: 0x0000F263 File Offset: 0x0000D463
		public void voteChanged(int userID)
		{
			RemoteServices.Instance.set_MakeCountryVote_UserCallBack(new RemoteServices.MakeCountryVote_UserCallBack(this.makeCountryVoteCallback));
			RemoteServices.Instance.MakeCountryVote(this.m_currentVillage, userID);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0000F28C File Offset: 0x0000D48C
		private void makeCountryVoteCallback(MakeCountryVote_ReturnType returnData)
		{
			if (returnData.Success && returnData.returnData != null)
			{
				this.getCountryElectionInfoCallback(returnData.returnData);
				GameEngine.Instance.forceFullTick();
			}
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x000EE574 File Offset: 0x000EC774
		private void sendProclamation()
		{
			CountryVotePanel.StoredCountryInfo storedCountryInfo = (CountryVotePanel.StoredCountryInfo)this.countryList[this.currentCountry];
			if (storedCountryInfo != null)
			{
				storedCountryInfo.m_lastUpdateTime = DateTime.MinValue;
			}
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(21);
			InterfaceMgr.Instance.sendProclamation(7, GameEngine.Instance.World.getCountryFromVillageID(this.m_currentVillage));
		}

		// Token: 0x04001047 RID: 4167
		private DockableControl dockableControl;

		// Token: 0x04001048 RID: 4168
		private IContainer components;

		// Token: 0x04001049 RID: 4169
		private Panel focusPanel;

		// Token: 0x0400104A RID: 4170
		public static CountryVotePanel instance;

		// Token: 0x0400104B RID: 4171
		private SparseArray countryList = new SparseArray();

		// Token: 0x0400104C RID: 4172
		private int voteCap = 100000;

		// Token: 0x0400104D RID: 4173
		private List<ParishMember> countryMembers = new List<ParishMember>();

		// Token: 0x0400104E RID: 4174
		private int currentCountry = -1;

		// Token: 0x0400104F RID: 4175
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x04001050 RID: 4176
		private DateTime lastProclamationTime = DateTime.MinValue;

		// Token: 0x04001051 RID: 4177
		private int electedLeaderID = -1;

		// Token: 0x04001052 RID: 4178
		private string electedLeaderName = "";

		// Token: 0x04001053 RID: 4179
		private int currentLeaderID = -1;

		// Token: 0x04001054 RID: 4180
		private bool currentLeaderMale;

		// Token: 0x04001055 RID: 4181
		private string currentLeaderName = "";

		// Token: 0x04001056 RID: 4182
		private bool votingAllowed;

		// Token: 0x04001057 RID: 4183
		private int m_userIDOnCurrent = -1;

		// Token: 0x04001058 RID: 4184
		private int m_currentVillage = -1;

		// Token: 0x04001059 RID: 4185
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x0400105A RID: 4186
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400105B RID: 4187
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400105C RID: 4188
		private CustomSelfDrawPanel.CSDImage illustrationImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400105D RID: 4189
		private CustomSelfDrawPanel.CSDLabel stewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400105E RID: 4190
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400105F RID: 4191
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001060 RID: 4192
		private CustomSelfDrawPanel.CSDLabel voteCapLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001061 RID: 4193
		private CustomSelfDrawPanel.CSDLabel voteCapLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001062 RID: 4194
		private CustomSelfDrawPanel.CSDLabel voteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001063 RID: 4195
		private CustomSelfDrawPanel.CSDLabel eligibleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001064 RID: 4196
		private CustomSelfDrawPanel.CSDLabel FactionsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001065 RID: 4197
		private CustomSelfDrawPanel.CSDLabel votesReceivedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001066 RID: 4198
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04001067 RID: 4199
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04001068 RID: 4200
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001069 RID: 4201
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400106A RID: 4202
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400106B RID: 4203
		private CustomSelfDrawPanel.CSDButton proclamationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400106C RID: 4204
		private CustomSelfDrawPanel.CSDLabel proclamationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400106D RID: 4205
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x0400106E RID: 4206
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x0400106F RID: 4207
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x04001070 RID: 4208
		private List<CountryVotePanel.VoteLine> lineList = new List<CountryVotePanel.VoteLine>();

		// Token: 0x04001071 RID: 4209
		private CountryVotePanel.ParishMemberComparer parishMemberComparer = new CountryVotePanel.ParishMemberComparer();

		// Token: 0x0200014C RID: 332
		public class StoredCountryInfo
		{
			// Token: 0x04001072 RID: 4210
			public GetCountryElectionInfo_ReturnType lastReturnData;

			// Token: 0x04001073 RID: 4211
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}

		// Token: 0x0200014D RID: 333
		public class ParishMemberComparer : IComparer<ParishMember>
		{
			// Token: 0x06000C59 RID: 3161 RVA: 0x000EE5E8 File Offset: 0x000EC7E8
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

		// Token: 0x0200014E RID: 334
		public class VoteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06000C5B RID: 3163 RVA: 0x000EE638 File Offset: 0x000EC838
			public void init(string playerName, int userID, int rank, int points, bool votingAllowed, int numSpareVotes, int numReceivedVotes, int parishID, int factionID, int yourVotes, int position, CountryVotePanel parent)
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
				this.voteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked), "CountryVotePanel_vote");
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
				this.personName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClick), "CountryVotePanel_user_clicked");
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

			// Token: 0x06000C5C RID: 3164 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06000C5D RID: 3165 RVA: 0x0000F2C7 File Offset: 0x0000D4C7
			public void lineClicked()
			{
				if (this.m_parent != null)
				{
					this.voteButton.Enabled = false;
					this.m_parent.voteChanged(this.m_userID);
				}
			}

			// Token: 0x06000C5E RID: 3166 RVA: 0x000EED10 File Offset: 0x000ECF10
			private void playerClick()
			{
				if (this.m_userID >= 0)
				{
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = this.m_userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06000C5F RID: 3167 RVA: 0x0000F2EE File Offset: 0x0000D4EE
			private void factionClick()
			{
				if (this.m_factionID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("CountryVotePanel_faction");
					InterfaceMgr.Instance.showFactionPanel(this.m_factionID);
				}
			}

			// Token: 0x04001074 RID: 4212
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04001075 RID: 4213
			private CustomSelfDrawPanel.CSDLabel personName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001076 RID: 4214
			private CustomSelfDrawPanel.CSDLabel votesLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001077 RID: 4215
			private CustomSelfDrawPanel.CSDButton voteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04001078 RID: 4216
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04001079 RID: 4217
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400107A RID: 4218
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x0400107B RID: 4219
			private int m_position = -1000;

			// Token: 0x0400107C RID: 4220
			private int m_userID = -1;

			// Token: 0x0400107D RID: 4221
			private int m_factionID = -1;

			// Token: 0x0400107E RID: 4222
			private CountryVotePanel m_parent;
		}
	}
}
