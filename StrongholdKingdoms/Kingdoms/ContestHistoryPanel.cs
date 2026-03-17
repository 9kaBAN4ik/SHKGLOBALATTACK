using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x0200013F RID: 319
	public class ContestHistoryPanel : CustomSelfDrawPanel
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x0000EBAF File Offset: 0x0000CDAF
		private ContestCachedData visibleContest
		{
			get
			{
				if (this.contestData.Count == 0)
				{
					return null;
				}
				return this.contestData[this.visibleContestIndex];
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000E6490 File Offset: 0x000E4690
		private int potentialLineCount
		{
			get
			{
				int num = GFXLibrary.lineitem_strip_02_dark.Height * 5 / 4;
				return (int)Math.Floor((double)((float)this.leaderboardInset.Height / (float)num));
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0000EBD1 File Offset: 0x0000CDD1
		private int actualLineCount
		{
			get
			{
				return Math.Min(this.potentialLineCount, this.visibleContest.activeLeaderboard.Length);
			}
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0000EBEB File Offset: 0x0000CDEB
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0000EBFB File Offset: 0x0000CDFB
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0000EC0B File Offset: 0x0000CE0B
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0000EC1D File Offset: 0x0000CE1D
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0000EC2A File Offset: 0x0000CE2A
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0000EC3E File Offset: 0x0000CE3E
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0000EC4B File Offset: 0x0000CE4B
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x0000EC58 File Offset: 0x0000CE58
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x000E64C4 File Offset: 0x000E46C4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 594);
			base.Name = "EventsPanel";
			base.Size = new Size(992, 594);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x000E6538 File Offset: 0x000E4738
		public ContestHistoryPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x000E6664 File Offset: 0x000E4864
		public void init(bool resized)
		{
			base.clearControls();
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Position = new Point(0, 0);
			csdextendingPanel.Size = base.Size;
			csdextendingPanel.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			base.addControl(csdextendingPanel);
			this.panelHeaderLabel.Text = SK.Text("Tourneys_Past", "Past Tourneys");
			this.panelHeaderLabel.Color = global::ARGBColors.Black;
			this.panelHeaderLabel.Size = new Size(base.Width, 50);
			this.panelHeaderLabel.Position = new Point(0, 20);
			this.panelHeaderLabel.Font = FontManager.GetFont("Arial", 24f, FontStyle.Bold);
			this.panelHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.panelHeaderLabel);
			this.leaderboardInset.Size = new Size(base.Width / 2 - 20, base.Height - 300);
			this.leaderboardInset.Position = new Point(base.Width / 2 - this.leaderboardInset.Width / 2, 200);
			csdextendingPanel.addControl(this.leaderboardInset);
			this.leaderboardInset.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.topButton.ImageNorm = GFXLibrary.page_top_norrmal;
			this.topButton.ImageOver = GFXLibrary.page_top_over;
			this.topButton.ImageClick = GFXLibrary.page_top_pushed;
			this.topButton.setSizeToImage();
			int x = this.leaderboardInset.Width - this.topButton.Width - 2;
			this.topButton.Position = new Point(x, 4);
			this.topButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LeaderboardScrollTop), "StatsPanel_scroll_top");
			this.leaderboardInset.addControl(this.topButton);
			this.upButton.ImageNorm = GFXLibrary.page_up_normal;
			this.upButton.ImageOver = GFXLibrary.page_up_over;
			this.upButton.ImageClick = GFXLibrary.page_up_pushed;
			this.upButton.setSizeToImage();
			this.upButton.Position = new Point(x, this.topButton.Rectangle.Bottom + 2);
			this.upButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LeaderboardScrollUp), "StatsPanel_scroll_up");
			this.leaderboardInset.addControl(this.upButton);
			this.bottomButton.ImageNorm = GFXLibrary.page_bottom_normal;
			this.bottomButton.ImageOver = GFXLibrary.page_bottom_over;
			this.bottomButton.ImageClick = GFXLibrary.page_bottom_pushed;
			this.bottomButton.setSizeToImage();
			this.bottomButton.Position = new Point(x, this.leaderboardInset.Height - this.bottomButton.Height - 2);
			this.bottomButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LeaderboardScrollBottom), "StatsPanel_scroll_bottom");
			this.leaderboardInset.addControl(this.bottomButton);
			this.downButton.ImageNorm = GFXLibrary.page_down_normal;
			this.downButton.ImageOver = GFXLibrary.page_down_over;
			this.downButton.ImageClick = GFXLibrary.page_down_pushed;
			this.downButton.setSizeToImage();
			this.downButton.Position = new Point(x, this.bottomButton.Position.Y - 2 - this.downButton.Height);
			this.downButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.LeaderboardScrollDown), "StatsPanel_scroll_down");
			this.leaderboardInset.addControl(this.downButton);
			this.titleLabel.Text = "";
			this.titleLabel.Color = global::ARGBColors.Black;
			this.titleLabel.Size = new Size(csdextendingPanel.Width, 160);
			this.titleLabel.Position = new Point(0, 80);
			this.titleLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.titleLabel);
			this.tierBar.Size = new Size(csdextendingPanel.Width / 4, GFXLibrary.int_statsscreen_iconbar_left.Height);
			this.tierBar.Position = new Point(csdextendingPanel.Width / 2 - this.tierBar.Width / 2, this.leaderboardInset.Y - this.tierBar.Height - 5);
			this.tierBar.Create(GFXLibrary.contestTitleLeft, GFXLibrary.contestTitleMid, GFXLibrary.contestTitleRight);
			csdextendingPanel.addControl(this.tierBar);
			this.tierLabel.Color = global::ARGBColors.Black;
			this.tierLabel.Size = this.tierBar.Size;
			this.tierLabel.Position = new Point(this.tierBar.X, this.tierBar.Y + 2);
			this.tierLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.tierLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.tierLabel);
			this.playerRankHeaderLabel.Text = SK.Text("Event_Final_Position", "Your final position") + ": ";
			this.playerRankHeaderLabel.Color = global::ARGBColors.Black;
			this.playerRankHeaderLabel.Size = new Size(this.leaderboardInset.Width, 25);
			this.playerRankHeaderLabel.Position = new Point(this.leaderboardInset.X, this.leaderboardInset.Rectangle.Bottom + 5);
			this.playerRankHeaderLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.playerRankHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.playerRankHeaderLabel);
			this.playerRankValueLabel.Color = global::ARGBColors.Black;
			this.playerRankValueLabel.Size = new Size(this.leaderboardInset.Width, 30);
			this.playerRankValueLabel.Position = new Point(this.playerRankHeaderLabel.X, this.playerRankHeaderLabel.Rectangle.Bottom + 10);
			this.playerRankValueLabel.Font = FontManager.GetFont("Arial", 15f, FontStyle.Bold);
			this.playerRankValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.playerRankValueLabel);
			this.prevTierButton.ImageNorm = GFXLibrary.contestArrowLeft;
			this.prevTierButton.ImageOver = GFXLibrary.contestArrowLeft;
			this.prevTierButton.ImageClick = GFXLibrary.contestArrowLeft;
			this.prevTierButton.setSizeToImage();
			this.prevTierButton.Position = new Point(this.tierBar.X - this.prevTierButton.Width - 2, this.tierBar.Y + this.tierBar.Height / 2 - this.prevTierButton.Height / 2);
			this.prevTierButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewPrevTier), "Contest_history_prev_tier");
			csdextendingPanel.addControl(this.prevTierButton);
			this.nextTierButton.ImageNorm = GFXLibrary.contestArrowRight;
			this.nextTierButton.ImageOver = GFXLibrary.contestArrowRight;
			this.nextTierButton.ImageClick = GFXLibrary.contestArrowRight;
			this.nextTierButton.setSizeToImage();
			this.nextTierButton.Position = new Point(this.tierBar.Rectangle.Right + 2, this.tierBar.Y + this.tierBar.Height / 2 - this.nextTierButton.Height / 2);
			this.nextTierButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewNextTier), "Contest_history_next_tier");
			csdextendingPanel.addControl(this.nextTierButton);
			this.prevContestButton.ImageNorm = GFXLibrary.contestArrowLeft;
			this.prevContestButton.ImageOver = GFXLibrary.contestArrowLeft;
			this.prevContestButton.ImageClick = GFXLibrary.contestArrowLeft;
			this.prevContestButton.setSizeToImage();
			this.prevContestButton.Position = new Point(this.leaderboardInset.X - this.prevContestButton.Width - 2, this.titleLabel.Y);
			this.prevContestButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewPrevContest), "Contest_history_prev_contest");
			csdextendingPanel.addControl(this.prevContestButton);
			this.nextContestButton.ImageNorm = GFXLibrary.contestArrowRight;
			this.nextContestButton.ImageOver = GFXLibrary.contestArrowRight;
			this.nextContestButton.ImageClick = GFXLibrary.contestArrowRight;
			this.nextContestButton.setSizeToImage();
			this.nextContestButton.Position = new Point(this.leaderboardInset.Rectangle.Right, this.titleLabel.Y);
			this.nextContestButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewNextContest), "Contest_history_next_contest");
			csdextendingPanel.addControl(this.nextContestButton);
			this.leftSupport.Image = GFXLibrary.contestSupportHorse;
			this.leftSupport.setSizeToImage();
			this.leftSupport.Position = new Point(this.leaderboardInset.X - this.leftSupport.Width, this.leaderboardInset.Y + this.leaderboardInset.Height / 2 - this.leftSupport.Height / 2 + 50);
			csdextendingPanel.addControl(this.leftSupport);
			this.rightSupport.Image = GFXLibrary.contestSupportLion;
			this.rightSupport.setSizeToImage();
			this.rightSupport.Position = new Point(this.leaderboardInset.Rectangle.Right, this.leaderboardInset.Y + this.leaderboardInset.Height / 2 - this.rightSupport.Height / 2 + 50);
			csdextendingPanel.addControl(this.rightSupport);
			this.leftTrumpet.Image = GFXLibrary.contestTrumpetLeft;
			this.leftTrumpet.setSizeToImage();
			this.leftTrumpet.Position = new Point(10, 10);
			csdextendingPanel.addControl(this.leftTrumpet);
			this.rightTrumpet.Image = GFXLibrary.contestTrumpetRight;
			this.rightTrumpet.setSizeToImage();
			this.rightTrumpet.Position = new Point(base.Width - this.rightTrumpet.Width - 10, 10);
			csdextendingPanel.addControl(this.rightTrumpet);
			if (GameEngine.Instance.World.contestID > 0)
			{
				DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime);
				DateTime t2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
				if (t <= VillageMap.getCurrentServerTime() && t2 > VillageMap.getCurrentServerTime())
				{
					this.activeButton = new CustomSelfDrawPanel.CSDButton();
					this.activeButton.ImageNorm = GFXLibrary.button_132_normal;
					this.activeButton.ImageOver = GFXLibrary.button_132_over;
					this.activeButton.ImageClick = GFXLibrary.button_132_in;
					this.activeButton.setSizeToImage();
					this.activeButton.Text.Text = SK.Text("Tourneys_Active", "Active Tourney");
					this.activeButton.Position = new Point(base.Width - this.activeButton.Width - 30, base.Height - this.activeButton.Height - 30);
					this.activeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showActiveContest));
					csdextendingPanel.addControl(this.activeButton);
				}
			}
			if (!resized && this.contestData.Count == 0)
			{
				this.initialised = false;
				this.contestData = new List<ContestCachedData>();
				this.RetrieveIDList();
				this.nextTierButton.Enabled = false;
				this.prevTierButton.Enabled = false;
				this.nextContestButton.Enabled = false;
				this.prevContestButton.Enabled = false;
				this.prevContestButton.Visible = false;
				this.nextContestButton.Visible = false;
				this.prevTierButton.Visible = false;
				this.nextTierButton.Visible = false;
				this.tierBar.Visible = false;
				this.playerRankHeaderLabel.Visible = false;
				return;
			}
			if (this.visibleContest != null && this.visibleContestIndex > -1)
			{
				this.visibleContest.visibleLineCount = this.potentialLineCount;
				this.titleLabel.Text = this.visibleContest.name;
				this.PopulateLeaderboard(true);
				this.UpdatePlayerInfo(true);
			}
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0000EC77 File Offset: 0x0000CE77
		private void showActiveContest()
		{
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(30);
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0000EC8A File Offset: 0x0000CE8A
		private void LeaderboardScrollUp()
		{
			if (this.visibleContest != null)
			{
				this.visibleContest.ScrollUp();
			}
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0000EC9F File Offset: 0x0000CE9F
		private void LeaderboardScrollTop()
		{
			if (this.visibleContest != null)
			{
				this.visibleContest.ScrollToTop();
			}
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
		private void LeaderboardScrollDown()
		{
			if (this.visibleContest != null)
			{
				this.visibleContest.ScrollDown();
			}
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0000ECC9 File Offset: 0x0000CEC9
		private void LeaderboardScrollBottom()
		{
			if (this.visibleContest != null)
			{
				this.visibleContest.ScrollToBottom();
			}
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0000ECDE File Offset: 0x0000CEDE
		private void ViewNextTier()
		{
			if (this.visibleContestIndex >= 0)
			{
				this.DisableButtons();
				this.visibleContest.NextTier();
			}
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0000ECFA File Offset: 0x0000CEFA
		private void ViewPrevTier()
		{
			if (this.visibleContestIndex >= 0)
			{
				this.DisableButtons();
				this.visibleContest.PrevTier();
			}
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0000ED16 File Offset: 0x0000CF16
		private void ViewNextContest()
		{
			if (this.visibleContestIndex >= 0 && this.visibleContestIndex > 0)
			{
				this.visibleContestIndex--;
				if (this.visibleContest != null)
				{
					this.DisableButtons();
					this.visibleContest.SetAsVisible();
				}
			}
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x000E7448 File Offset: 0x000E5648
		private void ViewPrevContest()
		{
			if (this.visibleContestIndex >= 0 && this.visibleContestIndex < this.contestIDs.Length - 1)
			{
				this.visibleContestIndex++;
				if (this.visibleContest != null)
				{
					this.DisableButtons();
					this.visibleContest.SetAsVisible();
				}
			}
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0000ED51 File Offset: 0x0000CF51
		private void DisableButtons()
		{
			this.nextTierButton.Enabled = false;
			this.prevTierButton.Enabled = false;
			this.nextContestButton.Enabled = false;
			this.prevContestButton.Enabled = false;
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x000E7498 File Offset: 0x000E5698
		private void UpdateButtons()
		{
			this.nextTierButton.Enabled = (this.visibleContest.visibleTier < 3);
			this.prevTierButton.Enabled = (this.visibleContest.visibleTier > 1);
			this.nextContestButton.Enabled = (this.visibleContestIndex > 0 && this.contestIDs[this.visibleContestIndex - 1] > 0);
			this.prevContestButton.Enabled = (this.visibleContestIndex < this.contestIDs.Length - 1 && this.contestIDs[this.visibleContestIndex + 1] > 0);
		}

		// Token: 0x06000BDD RID: 3037 RVA: 0x0000ED83 File Offset: 0x0000CF83
		private void RetrieveIDList()
		{
			this.contestData.Clear();
			RemoteServices.Instance.set_GetContestHistoryIDs_UserCallBack(new RemoteServices.GetContestHistoryIDs_UserCallBack(this.RetrieveIDListCallback));
			RemoteServices.Instance.GetContestHistoryIDs();
		}

		// Token: 0x06000BDE RID: 3038 RVA: 0x000E7534 File Offset: 0x000E5734
		private void RetrieveIDListCallback(GetContestHistoryIDs_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			this.initialised = true;
			this.contestIDs = returnData.contestIDs;
			if (this.contestIDs.Length == 0)
			{
				return;
			}
			for (int i = 0; i < this.contestIDs.Length; i++)
			{
				if (this.contestIDs[i] != 0)
				{
					ContestCachedData contestCachedData = new ContestCachedData();
					contestCachedData.leaderboardCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.PopulateLeaderboard);
					contestCachedData.metaDataCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.UpdateContestName);
					contestCachedData.userDataCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.UpdatePlayerInfo);
					contestCachedData.ID = this.contestIDs[i];
					contestCachedData.visibleLineCount = this.potentialLineCount;
					this.contestData.Add(contestCachedData);
				}
			}
			if (this.contestData.Count > 0)
			{
				this.visibleContestIndex = 0;
				this.visibleContest.SetAsVisible();
				this.prevContestButton.Visible = true;
				this.nextContestButton.Visible = true;
				this.prevTierButton.Visible = true;
				this.nextTierButton.Visible = true;
				this.tierBar.Visible = true;
				this.playerRankHeaderLabel.Visible = true;
				this.UpdateButtons();
				return;
			}
			this.prevContestButton.Visible = false;
			this.nextContestButton.Visible = false;
			this.prevTierButton.Visible = false;
			this.nextTierButton.Visible = false;
			this.tierBar.Visible = false;
			this.playerRankHeaderLabel.Visible = false;
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x000E76A0 File Offset: 0x000E58A0
		private void PopulateLeaderboard(bool success)
		{
			if (!this.initialised)
			{
				return;
			}
			this.UpdateButtons();
			if (success)
			{
				this.ClearLeaderboard();
				int num = GFXLibrary.lineitem_strip_02_dark.Height * 4 / 3;
				int num2 = (int)Math.Floor((double)((float)(this.leaderboardInset.Height - num * this.potentialLineCount) / (float)(this.potentialLineCount + 1)));
				int num3 = num2;
				for (int i = 0; i < this.actualLineCount; i++)
				{
					ContestRankLine contestRankLine = new ContestRankLine();
					contestRankLine.init(this.visibleContest.activeLeaderboard[i], this.leaderboardInset, i % 2 == 1);
					contestRankLine.Position = new Point(0, num3);
					this.leaderboardInset.addControl(contestRankLine);
					num3 += contestRankLine.Height + num2;
				}
				this.leaderboardInset.invalidate();
				switch (this.visibleContest.visibleTier)
				{
				case 1:
					this.tierLabel.Text = SK.Text("TOUCH_Z_Commoners", "Commoners");
					break;
				case 2:
					this.tierLabel.Text = SK.Text("TOUCH_Z_Gentry", "Gentry");
					break;
				case 3:
					this.tierLabel.Text = SK.Text("TOUCH_Z_Nobility", "Nobility");
					break;
				}
				this.tierLabel.CustomTooltipID = 25003;
				this.tierLabel.CustomTooltipData = this.visibleContest.visibleTier;
			}
		}

		// Token: 0x06000BE0 RID: 3040 RVA: 0x000E7808 File Offset: 0x000E5A08
		private void ClearLeaderboard()
		{
			List<CustomSelfDrawPanel.CSDControl> list = new List<CustomSelfDrawPanel.CSDControl>();
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.leaderboardInset.Controls)
			{
				if (csdcontrol.GetType() == typeof(ContestRankLine))
				{
					list.Add(csdcontrol);
				}
			}
			foreach (CustomSelfDrawPanel.CSDControl control in list)
			{
				this.leaderboardInset.removeControl(control);
			}
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x000E78BC File Offset: 0x000E5ABC
		private void UpdatePlayerInfo(bool success)
		{
			if (!this.initialised)
			{
				return;
			}
			if (success && this.visibleContest.userRankBand > 0)
			{
				this.playerRankHeaderLabel.Text = SK.Text("Event_Final_Position", "Your final position") + ": ";
				this.playerRankValueLabel.Text = this.visibleContest.userPosition.ToString() + " (";
				switch (this.visibleContest.userRankBand)
				{
				case 1:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.playerRankValueLabel;
					csdlabel.Text += SK.Text("TOUCH_Z_Commoners", "Commoners");
					break;
				}
				case 2:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel2 = this.playerRankValueLabel;
					csdlabel2.Text += SK.Text("TOUCH_Z_Gentry", "Gentry");
					break;
				}
				case 3:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.playerRankValueLabel;
					csdlabel3.Text += SK.Text("TOUCH_Z_Nobility", "Nobility");
					break;
				}
				}
				CustomSelfDrawPanel.CSDLabel csdlabel4 = this.playerRankValueLabel;
				csdlabel4.Text += ")";
				this.playerRankValueLabel.CustomTooltipID = 25003;
				this.playerRankValueLabel.CustomTooltipData = this.visibleContest.userRankBand;
				return;
			}
			this.playerRankHeaderLabel.Text = "";
			this.playerRankValueLabel.Text = "";
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		private void UpdateContestName(bool success)
		{
			if (this.initialised)
			{
				this.titleLabel.Text = this.visibleContest.name;
				this.UpdateButtons();
			}
		}

		// Token: 0x06000BE3 RID: 3043 RVA: 0x0000EDD6 File Offset: 0x0000CFD6
		public void logout()
		{
			this.contestData.Clear();
			this.contestIDs = null;
		}

		// Token: 0x04000FCA RID: 4042
		private DockableControl dockableControl;

		// Token: 0x04000FCB RID: 4043
		private IContainer components;

		// Token: 0x04000FCC RID: 4044
		private CustomSelfDrawPanel.CSDLabel panelHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FCD RID: 4045
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FCE RID: 4046
		private CustomSelfDrawPanel.CSDLabel tierLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FCF RID: 4047
		private CustomSelfDrawPanel.CSDLabel endDateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FD0 RID: 4048
		private CustomSelfDrawPanel.CSDHorzExtendingPanel tierBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000FD1 RID: 4049
		private CustomSelfDrawPanel.CSDButton activeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD2 RID: 4050
		private CustomSelfDrawPanel.CSDExtendingPanel leaderboardInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04000FD3 RID: 4051
		private CustomSelfDrawPanel.CSDButton topButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD4 RID: 4052
		private CustomSelfDrawPanel.CSDButton upButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD5 RID: 4053
		private CustomSelfDrawPanel.CSDButton downButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD6 RID: 4054
		private CustomSelfDrawPanel.CSDButton bottomButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD7 RID: 4055
		private CustomSelfDrawPanel.CSDButton nextContestButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD8 RID: 4056
		private CustomSelfDrawPanel.CSDButton prevContestButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FD9 RID: 4057
		private CustomSelfDrawPanel.CSDButton nextTierButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FDA RID: 4058
		private CustomSelfDrawPanel.CSDButton prevTierButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04000FDB RID: 4059
		private CustomSelfDrawPanel.CSDLabel playerRankHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FDC RID: 4060
		private CustomSelfDrawPanel.CSDLabel playerRankValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FDD RID: 4061
		private CustomSelfDrawPanel.CSDImage leftSupport = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FDE RID: 4062
		private CustomSelfDrawPanel.CSDImage rightSupport = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FDF RID: 4063
		private CustomSelfDrawPanel.CSDImage leftTrumpet = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FE0 RID: 4064
		private CustomSelfDrawPanel.CSDImage rightTrumpet = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04000FE1 RID: 4065
		private bool initialised;

		// Token: 0x04000FE2 RID: 4066
		private int[] contestIDs;

		// Token: 0x04000FE3 RID: 4067
		private int visibleContestIndex = -1;

		// Token: 0x04000FE4 RID: 4068
		private List<ContestCachedData> contestData = new List<ContestCachedData>();
	}
}
