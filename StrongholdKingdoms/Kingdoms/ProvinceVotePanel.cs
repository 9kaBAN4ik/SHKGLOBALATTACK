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
	// Token: 0x020002A3 RID: 675
	public class ProvinceVotePanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001E67 RID: 7783 RVA: 0x0001D0E7 File Offset: 0x0001B2E7
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001E68 RID: 7784 RVA: 0x0001D0F7 File Offset: 0x0001B2F7
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001E69 RID: 7785 RVA: 0x0001D107 File Offset: 0x0001B307
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001E6A RID: 7786 RVA: 0x0001D119 File Offset: 0x0001B319
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001E6B RID: 7787 RVA: 0x0001D126 File Offset: 0x0001B326
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001E6C RID: 7788 RVA: 0x0001D140 File Offset: 0x0001B340
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001E6D RID: 7789 RVA: 0x0001D14D File Offset: 0x0001B34D
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x0001D15A File Offset: 0x0001B35A
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001E6F RID: 7791 RVA: 0x001D5584 File Offset: 0x001D3784
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
			base.Name = "ProvinceVotePanel";
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x001D5670 File Offset: 0x001D3870
		public ProvinceVotePanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001E71 RID: 7793 RVA: 0x001D5830 File Offset: 0x001D3A30
		public void init(bool resized)
		{
			int num = this.m_currentVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			int provinceFromVillageID = GameEngine.Instance.World.getProvinceFromVillageID(num);
			int height = base.Height;
			ProvinceVotePanel.instance = this;
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
			this.parishNameLabel.Text = GameEngine.Instance.World.getVillageName(this.m_currentVillage) + " (" + GameEngine.Instance.World.getProvinceName(provinceFromVillageID) + ")";
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.illustrationImage.Image = GFXLibrary.parishwall_village_illlustration_03;
			this.illustrationImage.Position = new Point(17, 5);
			this.backgroundImage.addControl(this.illustrationImage);
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Governor", "Governor") + " : ";
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
			this.proclamationButton.Visible = false;
			this.proclamationButton.CustomTooltipID = 4202;
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
				ProvinceVotePanel.StoredProvinceInfo storedProvinceInfo = (ProvinceVotePanel.StoredProvinceInfo)this.provinceList[provinceFromVillageID];
				bool flag = false;
				if (storedProvinceInfo == null || (DateTime.Now - storedProvinceInfo.m_lastUpdateTime).TotalMinutes > 2.0 || storedProvinceInfo.lastReturnData == null)
				{
					flag = true;
				}
				this.m_currentVillage = num;
				if (this.currentProvince != provinceFromVillageID)
				{
					this.provinceMembers.Clear();
					this.currentLeaderID = -1;
					this.electedLeaderID = -1;
					this.currentLeaderName = "";
					this.electedLeaderName = "";
					this.m_userIDOnCurrent = -1;
				}
				this.currentProvince = provinceFromVillageID;
				if (flag)
				{
					RemoteServices.Instance.set_GetProvinceElectionInfo_UserCallBack(new RemoteServices.GetProvinceElectionInfo_UserCallBack(this.getProvinceElectionInfoCallback));
					RemoteServices.Instance.GetProvinceElectionInfo(this.m_currentVillage);
				}
				this.nextElectionTime = DateTime.MinValue;
				this.votingAllowed = false;
				this.addPlayers();
				if (!flag)
				{
					this.getProvinceElectionInfoCallback(storedProvinceInfo.lastReturnData);
					return;
				}
			}
			else
			{
				this.addPlayers();
			}
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x001D65E8 File Offset: 0x001D47E8
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

		// Token: 0x06001E73 RID: 7795 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001E74 RID: 7796 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void createParishWall(WallInfo[] wallInfos)
		{
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void updateWallArea()
		{
		}

		// Token: 0x06001E76 RID: 7798 RVA: 0x001D6670 File Offset: 0x001D4870
		private void wallScrollBarMoved()
		{
			int value = this.wallScrollBar.Value;
			this.wallScrollArea.Position = new Point(this.wallScrollArea.X, 158 - value);
			this.wallScrollArea.ClipRect = new Rectangle(this.wallScrollArea.ClipRect.X, value, this.wallScrollArea.ClipRect.Width, this.wallScrollArea.ClipRect.Height);
			this.wallScrollArea.invalidate();
			this.wallScrollBar.invalidate();
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001E78 RID: 7800 RVA: 0x001D670C File Offset: 0x001D490C
		public void getProvinceElectionInfoCallback(GetProvinceElectionInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			ProvinceVotePanel.StoredProvinceInfo storedProvinceInfo = (ProvinceVotePanel.StoredProvinceInfo)this.provinceList[returnData.provinceID];
			if (storedProvinceInfo == null)
			{
				storedProvinceInfo = new ProvinceVotePanel.StoredProvinceInfo();
				this.provinceList[returnData.provinceID] = storedProvinceInfo;
			}
			storedProvinceInfo.m_lastUpdateTime = DateTime.Now;
			storedProvinceInfo.lastReturnData = returnData;
			if (this.currentProvince == returnData.provinceID)
			{
				this.votingAllowed = returnData.votingAllowed;
				if (this.provinceMembers == null)
				{
					this.provinceMembers = new List<ParishMember>();
				}
				else
				{
					this.provinceMembers.Clear();
				}
				if (returnData.provinceMembers != null)
				{
					this.provinceMembers.AddRange(returnData.provinceMembers);
					int num = 0;
					foreach (ParishMember parishMember in this.provinceMembers)
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
					this.votesAvailableLabel.Text = SK.Text("ProvincePanel_Need_More_Counties", "More Counties need to be active before an election is held");
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

		// Token: 0x06001E79 RID: 7801 RVA: 0x001D6ABC File Offset: 0x001D4CBC
		public void addPlayers()
		{
			this.wallScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			int yourVotes = 0;
			if (this.provinceMembers != null)
			{
				foreach (ParishMember parishMember in this.provinceMembers)
				{
					if (parishMember.userID == RemoteServices.Instance.UserID)
					{
						yourVotes = parishMember.numSpareVotes;
						break;
					}
				}
				this.provinceMembers.Sort(this.parishMemberComparer);
				int num2 = 0;
				foreach (ParishMember parishMember2 in this.provinceMembers)
				{
					ProvinceVotePanel.VoteLine voteLine = new ProvinceVotePanel.VoteLine();
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
			this.stewardLabel.Text = SK.Text("ParishWallPanel_Governor", "Governor") + " : " + this.currentLeaderName;
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

		// Token: 0x06001E7A RID: 7802 RVA: 0x0001D179 File Offset: 0x0001B379
		public void voteChanged(int userID)
		{
			RemoteServices.Instance.set_MakeProvinceVote_UserCallBack(new RemoteServices.MakeProvinceVote_UserCallBack(this.makeProvinceVoteCallback));
			RemoteServices.Instance.MakeProvinceVote(this.m_currentVillage, userID);
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x0001D1A2 File Offset: 0x0001B3A2
		private void makeProvinceVoteCallback(MakeProvinceVote_ReturnType returnData)
		{
			if (returnData.Success && returnData.returnData != null)
			{
				this.getProvinceElectionInfoCallback(returnData.returnData);
				GameEngine.Instance.forceFullTick();
			}
		}

		// Token: 0x06001E7C RID: 7804 RVA: 0x001D6D98 File Offset: 0x001D4F98
		private void sendProclamation()
		{
			ProvinceVotePanel.StoredProvinceInfo storedProvinceInfo = (ProvinceVotePanel.StoredProvinceInfo)this.provinceList[this.currentProvince];
			if (storedProvinceInfo != null)
			{
				storedProvinceInfo.m_lastUpdateTime = DateTime.MinValue;
			}
			GameEngine.Instance.playInterfaceSound("UserInfoScreen_send_mail");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTabFast(21);
			InterfaceMgr.Instance.sendProclamation(6, GameEngine.Instance.World.getProvinceFromVillageID(this.m_currentVillage));
		}

		// Token: 0x04002F1A RID: 12058
		private DockableControl dockableControl;

		// Token: 0x04002F1B RID: 12059
		private IContainer components;

		// Token: 0x04002F1C RID: 12060
		private Panel focusPanel;

		// Token: 0x04002F1D RID: 12061
		public static ProvinceVotePanel instance;

		// Token: 0x04002F1E RID: 12062
		private SparseArray provinceList = new SparseArray();

		// Token: 0x04002F1F RID: 12063
		private int voteCap = 100000;

		// Token: 0x04002F20 RID: 12064
		private List<ParishMember> provinceMembers = new List<ParishMember>();

		// Token: 0x04002F21 RID: 12065
		private int currentProvince = -1;

		// Token: 0x04002F22 RID: 12066
		private DateTime nextElectionTime = DateTime.MinValue;

		// Token: 0x04002F23 RID: 12067
		private DateTime lastProclamationTime = DateTime.MinValue;

		// Token: 0x04002F24 RID: 12068
		private int electedLeaderID = -1;

		// Token: 0x04002F25 RID: 12069
		private string electedLeaderName = "";

		// Token: 0x04002F26 RID: 12070
		private int currentLeaderID = -1;

		// Token: 0x04002F27 RID: 12071
		private string currentLeaderName = "";

		// Token: 0x04002F28 RID: 12072
		private bool votingAllowed;

		// Token: 0x04002F29 RID: 12073
		private int m_userIDOnCurrent = -1;

		// Token: 0x04002F2A RID: 12074
		private int m_currentVillage = -1;

		// Token: 0x04002F2B RID: 12075
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002F2C RID: 12076
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F2D RID: 12077
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F2E RID: 12078
		private CustomSelfDrawPanel.CSDImage illustrationImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F2F RID: 12079
		private CustomSelfDrawPanel.CSDLabel stewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F30 RID: 12080
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F31 RID: 12081
		private CustomSelfDrawPanel.CSDLabel votesAvailableLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F32 RID: 12082
		private CustomSelfDrawPanel.CSDLabel voteCapLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F33 RID: 12083
		private CustomSelfDrawPanel.CSDLabel voteCapLabelValue = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F34 RID: 12084
		private CustomSelfDrawPanel.CSDLabel voteLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F35 RID: 12085
		private CustomSelfDrawPanel.CSDLabel eligibleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F36 RID: 12086
		private CustomSelfDrawPanel.CSDLabel FactionsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F37 RID: 12087
		private CustomSelfDrawPanel.CSDLabel votesReceivedLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F38 RID: 12088
		private CustomSelfDrawPanel.CSDExtendingPanel wallInfoImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F39 RID: 12089
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002F3A RID: 12090
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F3B RID: 12091
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F3C RID: 12092
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F3D RID: 12093
		private CustomSelfDrawPanel.CSDButton proclamationButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002F3E RID: 12094
		private CustomSelfDrawPanel.CSDLabel proclamationLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F3F RID: 12095
		private CustomSelfDrawPanel.CSDVertScrollBar wallScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002F40 RID: 12096
		private CustomSelfDrawPanel.CSDArea wallScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002F41 RID: 12097
		private List<WallInfo> wallList = new List<WallInfo>();

		// Token: 0x04002F42 RID: 12098
		private List<ProvinceVotePanel.VoteLine> lineList = new List<ProvinceVotePanel.VoteLine>();

		// Token: 0x04002F43 RID: 12099
		private ProvinceVotePanel.ParishMemberComparer parishMemberComparer = new ProvinceVotePanel.ParishMemberComparer();

		// Token: 0x020002A4 RID: 676
		public class StoredProvinceInfo
		{
			// Token: 0x04002F44 RID: 12100
			public GetProvinceElectionInfo_ReturnType lastReturnData;

			// Token: 0x04002F45 RID: 12101
			public DateTime m_lastUpdateTime = DateTime.MinValue;
		}

		// Token: 0x020002A5 RID: 677
		public class ParishMemberComparer : IComparer<ParishMember>
		{
			// Token: 0x06001E7E RID: 7806 RVA: 0x000EE5E8 File Offset: 0x000EC7E8
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

		// Token: 0x020002A6 RID: 678
		public class VoteLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001E80 RID: 7808 RVA: 0x001D6E0C File Offset: 0x001D500C
			public void init(string playerName, int userID, int rank, int points, bool votingAllowed, int numSpareVotes, int numReceivedVotes, int parishID, int factionID, int yourVotes, int position, ProvinceVotePanel parent)
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
				this.voteButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked), "ProvinceVotePanel_vote");
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
				this.personName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.playerClick), "ProvinceVotePanel_user_clicked");
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

			// Token: 0x06001E81 RID: 7809 RVA: 0x00007CE0 File Offset: 0x00005EE0
			public void update()
			{
			}

			// Token: 0x06001E82 RID: 7810 RVA: 0x0001D1DD File Offset: 0x0001B3DD
			public void lineClicked()
			{
				if (this.m_parent != null)
				{
					this.voteButton.Enabled = false;
					this.m_parent.voteChanged(this.m_userID);
				}
			}

			// Token: 0x06001E83 RID: 7811 RVA: 0x001D74E4 File Offset: 0x001D56E4
			private void playerClick()
			{
				if (this.m_userID >= 0)
				{
					WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
					cachedUserInfo.userID = this.m_userID;
					InterfaceMgr.Instance.showUserInfoScreen(cachedUserInfo);
				}
			}

			// Token: 0x06001E84 RID: 7812 RVA: 0x0001D204 File Offset: 0x0001B404
			private void factionClick()
			{
				if (this.m_factionID >= 0)
				{
					GameEngine.Instance.playInterfaceSound("ProvinceVotePanel_faction");
					InterfaceMgr.Instance.showFactionPanel(this.m_factionID);
				}
			}

			// Token: 0x04002F46 RID: 12102
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002F47 RID: 12103
			private CustomSelfDrawPanel.CSDLabel personName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F48 RID: 12104
			private CustomSelfDrawPanel.CSDLabel votesLabel = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F49 RID: 12105
			private CustomSelfDrawPanel.CSDButton voteButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002F4A RID: 12106
			private CustomSelfDrawPanel.CSDLabel factionName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F4B RID: 12107
			private CustomSelfDrawPanel.CSDImage houseImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002F4C RID: 12108
			private CustomSelfDrawPanel.CSDImage shieldImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002F4D RID: 12109
			private int m_position = -1000;

			// Token: 0x04002F4E RID: 12110
			private int m_userID = -1;

			// Token: 0x04002F4F RID: 12111
			private int m_factionID = -1;

			// Token: 0x04002F50 RID: 12112
			private ProvinceVotePanel m_parent;
		}
	}
}
