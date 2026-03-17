using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x02000145 RID: 325
	public class ContestsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x000E93E0 File Offset: 0x000E75E0
		private int potentialLineCount
		{
			get
			{
				int num = GFXLibrary.lineitem_strip_02_dark.Height * 4 / 3;
				return (int)Math.Floor((double)((float)this.leaderboardInset.Height / (float)num));
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x0000EE5D File Offset: 0x0000D05D
		private int actualLineCount
		{
			get
			{
				return Math.Min(this.potentialLineCount, this.leaderboardData.activeLeaderboard.Length);
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0000EE77 File Offset: 0x0000D077
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0000EE87 File Offset: 0x0000D087
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0000EE97 File Offset: 0x0000D097
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0000EEA9 File Offset: 0x0000D0A9
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0000EEB6 File Offset: 0x0000D0B6
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0000EECA File Offset: 0x0000D0CA
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0000EED7 File Offset: 0x0000D0D7
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x000E64C4 File Offset: 0x000E46C4
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

		// Token: 0x06000BFF RID: 3071 RVA: 0x000E9414 File Offset: 0x000E7614
		public ContestsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x000E9584 File Offset: 0x000E7784
		public void init(bool resized)
		{
			base.clearControls();
			if (!resized)
			{
				Program.mySettings.LastContestViewed = GameEngine.Instance.World.contestID;
			}
			CustomSelfDrawPanel.CSDExtendingPanel csdextendingPanel = new CustomSelfDrawPanel.CSDExtendingPanel();
			csdextendingPanel.Position = new Point(0, 0);
			csdextendingPanel.Size = base.Size;
			csdextendingPanel.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
			base.addControl(csdextendingPanel);
			this.leaderboardInset.Size = new Size(base.Width / 2 - 50, base.Height - 200);
			this.leaderboardInset.Position = new Point(40, 150);
			csdextendingPanel.addControl(this.leaderboardInset);
			this.leaderboardInset.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.prizesInset.Size = new Size(base.Width / 2 - 50, base.Height / 4);
			this.prizesInset.Position = new Point(base.Width / 2 + 10, this.leaderboardInset.Y);
			csdextendingPanel.addControl(this.prizesInset);
			this.prizesInset.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			this.titleBar.Size = new Size(base.Width - 240, GFXLibrary.contestTitleLeft.Height);
			this.titleBar.Position = new Point(120, 20);
			this.titleBar.Create(GFXLibrary.contestTitleLeft, GFXLibrary.contestTitleMid, GFXLibrary.contestTitleRight);
			csdextendingPanel.addControl(this.titleBar);
			this.titleLabel.Text = GameEngine.Instance.World.contestName;
			this.titleLabel.Color = global::ARGBColors.Black;
			this.titleLabel.Size = new Size(base.Width, GFXLibrary.contestTitleLeft.Height);
			this.titleLabel.Position = new Point(0, 20);
			this.titleLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.titleLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.titleLabel);
			this.descriptionLabel.Text = GameEngine.Instance.World.contestDescription;
			this.descriptionLabel.Color = global::ARGBColors.Black;
			this.descriptionLabel.Size = new Size(base.Width, 20);
			this.descriptionLabel.Position = new Point(0, this.titleLabel.Rectangle.Bottom + 10);
			this.descriptionLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Regular);
			this.descriptionLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.descriptionLabel);
			this.leftTrumpet.Image = GFXLibrary.contestTrumpetLeftSmall;
			this.leftTrumpet.setSizeToImage();
			this.leftTrumpet.Position = new Point(15, 15);
			csdextendingPanel.addControl(this.leftTrumpet);
			this.rightTrumpet.Image = GFXLibrary.contestTrumpetRightSmall;
			this.rightTrumpet.setSizeToImage();
			this.rightTrumpet.Position = new Point(base.Width - this.rightTrumpet.Width - 15, 15);
			csdextendingPanel.addControl(this.rightTrumpet);
			int contestBand = ContestsPanel.GetContestBand(GameEngine.Instance.World.getRank());
			this.leaderboardHeaderLabel.Text = SK.Text("Event_Leaderboard_Header", "Leaderboard");
			switch (contestBand)
			{
			case 1:
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = this.leaderboardHeaderLabel;
				csdlabel.Text = csdlabel.Text + " (" + SK.Text("TOUCH_Z_Commoners", "Commoners") + ")";
				break;
			}
			case 2:
			{
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.leaderboardHeaderLabel;
				csdlabel2.Text = csdlabel2.Text + " (" + SK.Text("TOUCH_Z_Gentry", "Gentry") + ")";
				break;
			}
			case 3:
			{
				CustomSelfDrawPanel.CSDLabel csdlabel3 = this.leaderboardHeaderLabel;
				csdlabel3.Text = csdlabel3.Text + " (" + SK.Text("TOUCH_Z_Nobility", "Nobility") + ")";
				break;
			}
			}
			this.leaderboardHeaderLabel.Color = global::ARGBColors.Black;
			this.leaderboardHeaderLabel.Size = new Size(this.leaderboardInset.Width * 4 / 5, GFXLibrary.contestTitleLeft.Height);
			this.leaderboardHeaderLabel.Position = new Point(this.leaderboardInset.X + this.leaderboardInset.Width / 5, this.leaderboardInset.Y - this.leaderboardHeaderLabel.Height - 2);
			this.leaderboardHeaderLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.leaderboardHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.leaderboardHeaderLabel.CustomTooltipID = 25003;
			this.leaderboardHeaderLabel.CustomTooltipData = contestBand;
			csdextendingPanel.addControl(this.leaderboardHeaderLabel);
			this.prevTierButton.ImageNorm = GFXLibrary.contestArrowLeft;
			this.prevTierButton.ImageOver = GFXLibrary.contestArrowLeft;
			this.prevTierButton.ImageClick = GFXLibrary.contestArrowLeft;
			this.prevTierButton.setSizeToImage();
			this.prevTierButton.Position = new Point(this.leaderboardInset.X, this.leaderboardHeaderLabel.Y + this.leaderboardHeaderLabel.Height / 2 - this.prevTierButton.Height / 2);
			this.prevTierButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewPrevTier), "Contest_prev_tier");
			csdextendingPanel.addControl(this.prevTierButton);
			this.nextTierButton.ImageNorm = GFXLibrary.contestArrowRight;
			this.nextTierButton.ImageOver = GFXLibrary.contestArrowRight;
			this.nextTierButton.ImageClick = GFXLibrary.contestArrowRight;
			this.nextTierButton.setSizeToImage();
			this.nextTierButton.Position = new Point(this.leaderboardInset.Rectangle.Right - this.prevTierButton.Width, this.leaderboardHeaderLabel.Y + this.leaderboardHeaderLabel.Height / 2 - this.nextTierButton.Height / 2);
			this.nextTierButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ViewNextTier), "Contest_next_tier");
			csdextendingPanel.addControl(this.nextTierButton);
			this.prizesHeaderLabel.Text = SK.Text("Event_Prizes_Header", "Prizes");
			this.prizesHeaderLabel.Color = global::ARGBColors.Black;
			this.prizesHeaderLabel.Size = new Size(this.prizesInset.Width, 30);
			this.prizesHeaderLabel.Position = new Point(this.prizesInset.X, this.prizesInset.Y - this.prizesHeaderLabel.Height - 3);
			this.prizesHeaderLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			this.prizesHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			csdextendingPanel.addControl(this.prizesHeaderLabel);
			this.playerRankHeaderLabel.Text = SK.Text("Event_Your_Position", "Your position") + ": ";
			this.playerRankHeaderLabel.Color = global::ARGBColors.Black;
			this.playerRankHeaderLabel.Size = new Size(base.Width / 4, 40);
			this.playerRankHeaderLabel.Position = new Point(base.Width / 2, this.prizesInset.Rectangle.Bottom + 20);
			this.playerRankHeaderLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.playerRankHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.playerRankHeaderLabel);
			this.playerRankValueLabel.Color = global::ARGBColors.Black;
			this.playerRankValueLabel.Size = new Size(this.playerRankHeaderLabel.Width, 40);
			this.playerRankValueLabel.Position = new Point(this.playerRankHeaderLabel.X, this.playerRankHeaderLabel.Rectangle.Bottom + 5);
			this.playerRankValueLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.playerRankValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.playerRankValueLabel);
			this.playerScoreHeaderLabel.Text = SK.Text("Event_Your_Score", "Your score") + ": ";
			this.playerScoreHeaderLabel.Color = global::ARGBColors.Black;
			this.playerScoreHeaderLabel.Size = new Size(base.Width / 4, 40);
			this.playerScoreHeaderLabel.Position = new Point(base.Width * 3 / 4, this.playerRankHeaderLabel.Y);
			this.playerScoreHeaderLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			this.playerScoreHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.playerScoreHeaderLabel);
			this.playerScoreValueLabel.Color = global::ARGBColors.Black;
			this.playerScoreValueLabel.Size = new Size(this.playerScoreHeaderLabel.Width, 40);
			this.playerScoreValueLabel.Position = new Point(this.playerScoreHeaderLabel.X, this.playerScoreHeaderLabel.Rectangle.Bottom + 5);
			this.playerScoreValueLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Bold);
			this.playerScoreValueLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.playerScoreValueLabel);
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
			TimeSpan timeSpan = d - VillageMap.getCurrentServerTime();
			int num = (int)timeSpan.TotalSeconds / 86400;
			int num2 = (int)timeSpan.TotalSeconds / 3600 % 24;
			int num3 = (int)timeSpan.TotalSeconds / 60 % 60;
			string text = "";
			if (num > 0)
			{
				text = text + num.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
			}
			if (num2 > 0)
			{
				if (num2 < 10)
				{
					text += "0";
				}
				text = text + num2.ToString() + SK.Text("VillageMap_Hour_Abbrev", "h");
			}
			if (num3 > 0)
			{
				if (num3 < 10)
				{
					text += "0";
				}
				text = text + num3.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m");
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.timeRemainingLabel.Text = SK.Text("Event_Time_Remaining", "Ends in") + " ";
				CustomSelfDrawPanel.CSDLabel csdlabel4 = this.timeRemainingLabel;
				csdlabel4.Text = csdlabel4.Text + Environment.NewLine + text;
			}
			this.timeRemainingLabel.Color = global::ARGBColors.Black;
			this.timeRemainingLabel.Size = new Size(this.prizesInset.Width, 50);
			this.timeRemainingLabel.Position = new Point(this.prizesInset.X, this.playerScoreValueLabel.Rectangle.Bottom);
			this.timeRemainingLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.timeRemainingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.timeRemainingLabel);
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
			this.timeRemainingLabel.Color = global::ARGBColors.Black;
			this.timeRemainingLabel.Size = new Size(this.prizesInset.Width, 50);
			this.timeRemainingLabel.Position = new Point(this.prizesInset.X, this.playerScoreValueLabel.Rectangle.Bottom);
			this.timeRemainingLabel.Font = FontManager.GetFont("Arial", 16f, FontStyle.Regular);
			this.timeRemainingLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.timeRemainingLabel);
			this.lastUpdateLabel.Color = global::ARGBColors.Black;
			this.lastUpdateLabel.Size = new Size(this.leaderboardInset.Width, 20);
			this.lastUpdateLabel.Position = new Point(this.leaderboardInset.X, this.leaderboardInset.Rectangle.Bottom + 2);
			this.lastUpdateLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Regular);
			this.lastUpdateLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			csdextendingPanel.addControl(this.lastUpdateLabel);
			this.historyButton = new CustomSelfDrawPanel.CSDButton();
			this.historyButton.ImageNorm = GFXLibrary.button_132_normal;
			this.historyButton.ImageOver = GFXLibrary.button_132_over;
			this.historyButton.ImageClick = GFXLibrary.button_132_in;
			this.historyButton.setSizeToImage();
			this.historyButton.Text.Text = SK.Text("Tourneys_Past", "Past Tourneys");
			this.historyButton.Position = new Point(base.Width - this.historyButton.Width - 30, base.Height - this.historyButton.Height - 30);
			this.historyButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.OnHistoryClicked));
			csdextendingPanel.addControl(this.historyButton);
			this.prizeContentInset.Size = new Size(400, 400);
			this.prizeContentInset.Position = new Point(base.Width / 2 - this.prizeContentInset.Width / 2, base.Height / 2 - this.prizeContentInset.Height / 2);
			csdextendingPanel.addControl(this.prizeContentInset);
			this.prizeContentInset.Visible = false;
			if (new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime).AddHours(1.5) > VillageMap.getCurrentServerTime())
			{
				this.timeRemainingLabel.Text = SK.Text("Tourney_Awaiting_Scores", "Tourney under way - awaiting initial scores");
				this.playerRankValueLabel.Text = "-";
				this.playerScoreValueLabel.Text = "-";
				this.leaderboardData = new ContestCachedData();
				this.leaderboardData.metaDataCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.UpdateMetaData);
				this.leaderboardData.ID = GameEngine.Instance.World.contestID;
				this.leaderboardData.RetrieveMetaData();
				return;
			}
			if (!resized)
			{
				this.leaderboardData = new ContestCachedData();
				this.leaderboardData.leaderboardCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.PopulateLeaderboard);
				this.leaderboardData.userDataCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.UpdateUserInfo);
				this.leaderboardData.metaDataCallback = new ContestCachedData.ContestCacheCallbackDelegate(this.UpdateMetaData);
				this.leaderboardData.ID = GameEngine.Instance.World.contestID;
				this.leaderboardData.visibleTier = contestBand;
				this.leaderboardData.visibleLineCount = this.potentialLineCount;
				this.leaderboardData.SetAsVisible();
				return;
			}
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.leaderboardData.visibleLineCount = this.potentialLineCount;
				this.leaderboardData.SetAsVisible();
			}
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x000EA88C File Offset: 0x000E8A8C
		public void update()
		{
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
			TimeSpan timeSpan = d - VillageMap.getCurrentServerTime();
			int num = (int)timeSpan.TotalSeconds / 86400;
			int num2 = (int)timeSpan.TotalSeconds / 3600 % 24;
			int num3 = (int)timeSpan.TotalSeconds / 60 % 60;
			string text = "";
			if (num > 0)
			{
				text = text + num.ToString() + SK.Text("VillageMap_Day_Abbrev", "d") + ":";
			}
			if (num2 > 0)
			{
				if (num2 < 10)
				{
					text += "0";
				}
				text = text + num2.ToString() + SK.Text("VillageMap_Hour_Abbrev", "h");
			}
			if (num3 > 0)
			{
				if (num3 < 10)
				{
					text += "0";
				}
				text = text + num3.ToString() + SK.Text("VillageMap_Minute_Abbrev", "m");
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.timeRemainingLabel.TextDiffOnly = SK.Text("Event_Time_Remaining", "Ends in") + " " + Environment.NewLine + text;
			}
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x000EA9D0 File Offset: 0x000E8BD0
		private void PopulateLeaderboard(bool success)
		{
			this.nextTierButton.Enabled = (this.leaderboardData.visibleTier < 3);
			this.prevTierButton.Enabled = (this.leaderboardData.visibleTier > 1);
			if (success)
			{
				this.ClearLeaderboard();
				int num = GFXLibrary.lineitem_strip_02_dark.Height * 4 / 3;
				int num2 = (int)Math.Floor((double)((float)(this.leaderboardInset.Height - num * this.potentialLineCount) / (float)(this.potentialLineCount + 1)));
				int num3 = num2;
				for (int i = 0; i < this.actualLineCount; i++)
				{
					ContestRankLine contestRankLine = new ContestRankLine();
					contestRankLine.init(this.leaderboardData.activeLeaderboard[i], this.leaderboardInset, i % 2 == 1);
					contestRankLine.Position = new Point(0, num3);
					this.leaderboardInset.addControl(contestRankLine);
					num3 += contestRankLine.Height + num2;
				}
				this.leaderboardHeaderLabel.Text = SK.Text("Event_Leaderboard_Header", "Leaderboard");
				switch (this.leaderboardData.visibleTier)
				{
				case 1:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel = this.leaderboardHeaderLabel;
					csdlabel.Text = csdlabel.Text + " (" + SK.Text("TOUCH_Z_Commoners", "Commoners") + ")";
					break;
				}
				case 2:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel2 = this.leaderboardHeaderLabel;
					csdlabel2.Text = csdlabel2.Text + " (" + SK.Text("TOUCH_Z_Gentry", "Gentry") + ")";
					break;
				}
				case 3:
				{
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.leaderboardHeaderLabel;
					csdlabel3.Text = csdlabel3.Text + " (" + SK.Text("TOUCH_Z_Nobility", "Nobility") + ")";
					break;
				}
				}
				this.leaderboardHeaderLabel.CustomTooltipData = this.leaderboardData.visibleTier;
				base.Invalidate();
			}
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x000EABB0 File Offset: 0x000E8DB0
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

		// Token: 0x06000C04 RID: 3076 RVA: 0x000EAC64 File Offset: 0x000E8E64
		private void UpdateMetaData(bool success)
		{
			if (success)
			{
				this.ClearPrizes();
				int num = 2;
				foreach (ContestPrizeDefinition contestPrizeDefinition in this.leaderboardData.prizes)
				{
					if (contestPrizeDefinition.RankTier + 1 == this.leaderboardData.visibleTier)
					{
						this.prizesHeaderLabel.Text = contestPrizeDefinition.Content.Name;
						ContestPrizeLine contestPrizeLine = new ContestPrizeLine();
						contestPrizeLine.init(contestPrizeDefinition, this.prizesInset, this);
						contestPrizeLine.Position = new Point(2, num);
						this.prizesInset.addControl(contestPrizeLine);
						num += contestPrizeLine.Height + 2;
					}
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x000EAD2C File Offset: 0x000E8F2C
		private void ClearPrizes()
		{
			List<CustomSelfDrawPanel.CSDControl> list = new List<CustomSelfDrawPanel.CSDControl>();
			foreach (CustomSelfDrawPanel.CSDControl csdcontrol in this.prizesInset.Controls)
			{
				if (csdcontrol.GetType() == typeof(ContestPrizeLine))
				{
					list.Add(csdcontrol);
				}
			}
			foreach (CustomSelfDrawPanel.CSDControl control in list)
			{
				this.prizesInset.removeControl(control);
			}
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x000EADE0 File Offset: 0x000E8FE0
		private void UpdateUserInfo(bool success)
		{
			if (success)
			{
				this.playerScoreValueLabel.Text = ((int)Math.Floor(this.leaderboardData.userScore)).ToString();
				this.playerRankValueLabel.Text = this.leaderboardData.userPosition.ToString();
			}
			if (this.leaderboardData != null && this.leaderboardData.lastUpdate != DateTime.MinValue)
			{
				TimeSpan timeSpan = VillageMap.getCurrentServerTime() - this.leaderboardData.lastUpdate;
				this.m_LastLocalUpdate = this.leaderboardData.lastUpdate;
				this.lastUpdateLabel.Text = SK.Text("Events_Last_Update", "Time since last update") + ": ";
				CustomSelfDrawPanel.CSDLabel csdlabel = this.lastUpdateLabel;
				csdlabel.Text = csdlabel.Text + ": " + Math.Floor(timeSpan.TotalMinutes).ToString() + SK.Text("VillageMap_Minute_Abbrev", "m");
				return;
			}
			this.lastUpdateLabel.Text = "";
			this.m_LastLocalUpdate = DateTime.MinValue;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0000EF03 File Offset: 0x0000D103
		private void ViewNextTier()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.nextTierButton.Enabled = false;
				this.prevTierButton.Enabled = false;
				this.leaderboardData.NextTier();
			}
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0000EF35 File Offset: 0x0000D135
		private void ViewPrevTier()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.nextTierButton.Enabled = false;
				this.prevTierButton.Enabled = false;
				this.leaderboardData.PrevTier();
			}
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0000EF67 File Offset: 0x0000D167
		private void LeaderboardScrollUp()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.leaderboardData.ScrollUp();
			}
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0000EF81 File Offset: 0x0000D181
		private void LeaderboardScrollDown()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.leaderboardData.ScrollDown();
			}
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0000EF9B File Offset: 0x0000D19B
		private void LeaderboardScrollTop()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.leaderboardData.ScrollToTop();
			}
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0000EFB5 File Offset: 0x0000D1B5
		private void LeaderboardScrollBottom()
		{
			if (this.leaderboardData.activeLeaderboard != null)
			{
				this.leaderboardData.ScrollToBottom();
			}
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x000EAEFC File Offset: 0x000E90FC
		public void OnPrizeInfoClicked()
		{
			CustomSelfDrawPanel.CSDButton csdbutton = (CustomSelfDrawPanel.CSDButton)this.ClickedControl;
			int data = csdbutton.Data;
			foreach (ContestPrizeDefinition contestPrizeDefinition in this.leaderboardData.prizes)
			{
				if (contestPrizeDefinition.Content.ID == data)
				{
					this.prizeContentInset.clearControls();
					CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
					csdimage.Image = GFXLibrary.castlescreen_panelback_A;
					csdimage.Size = this.prizeContentInset.Size;
					this.prizeContentInset.addControl(csdimage);
					this.prizeContentInset.Create(GFXLibrary._9sclice_generic_top_left, GFXLibrary._9sclice_generic_top_mid, GFXLibrary._9sclice_generic_top_right, GFXLibrary._9sclice_generic_mid_left, GFXLibrary._9sclice_generic_mid_mid, GFXLibrary._9sclice_generic_mid_right, GFXLibrary._9sclice_generic_bottom_left, GFXLibrary._9sclice_generic_bottom_mid, GFXLibrary._9sclice_generic_bottom_right);
					this.prizeContentInsetHeaderLabel = new CustomSelfDrawPanel.CSDLabel();
					this.prizeContentInsetHeaderLabel.Text = contestPrizeDefinition.Content.Name;
					this.prizeContentInsetHeaderLabel.Color = global::ARGBColors.Black;
					this.prizeContentInsetHeaderLabel.Size = new Size(this.prizeContentInset.Width, this.prizeContentInset.Height / 4 - 20);
					this.prizeContentInsetHeaderLabel.Position = new Point(0, 20);
					this.prizeContentInsetHeaderLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
					this.prizeContentInsetHeaderLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.prizeContentInset.addControl(this.prizeContentInsetHeaderLabel);
					this.closePrizeButton = new CustomSelfDrawPanel.CSDButton();
					this.closePrizeButton.ImageNorm = GFXLibrary.button_132_in_gold;
					this.closePrizeButton.ImageOver = GFXLibrary.button_132_over_gold;
					this.closePrizeButton.ImageClick = GFXLibrary.button_132_in_gold;
					this.closePrizeButton.setSizeToImage();
					this.closePrizeButton.Text.Text = SK.Text("GENERIC_Close", "Close");
					this.closePrizeButton.Position = new Point(this.prizeContentInset.Width / 2 - this.closePrizeButton.Width / 2, this.prizeContentInset.Height - this.closePrizeButton.Height - 10);
					this.closePrizeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.ClosePrizeInfo));
					this.prizeContentInset.addControl(this.closePrizeButton);
					this.m_PrizeContent.clearControls();
					this.prizeContentInset.Visible = true;
					this.m_PrizeContent.init(contestPrizeDefinition, this.prizeContentInset, 20, 30, this.prizeContentInsetHeaderLabel.Height);
					this.prizeContentInset.addControl(this.m_PrizeContent);
					this.prizeContentInset.invalidate();
					base.Invalidate();
					break;
				}
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x0000EFCF File Offset: 0x0000D1CF
		public void ClosePrizeInfo()
		{
			this.prizeContentInset.Visible = false;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x0000EFDD File Offset: 0x0000D1DD
		private void OnHistoryClicked()
		{
			GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
			InterfaceMgr.Instance.getMainTabBar().selectDummyTab(31);
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0000EFFF File Offset: 0x0000D1FF
		public void logout()
		{
			this.leaderboardData = null;
			this.m_LastLocalUpdate = DateTime.MinValue;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x0000F013 File Offset: 0x0000D213
		public static int GetContestBand(int rank)
		{
			if (rank >= 18)
			{
				return 3;
			}
			if (rank >= 12)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x04000FF9 RID: 4089
		private DockableControl dockableControl;

		// Token: 0x04000FFA RID: 4090
		private IContainer components;

		// Token: 0x04000FFB RID: 4091
		private List<ContestPrizeDefinition> m_Prizes = new List<ContestPrizeDefinition>();

		// Token: 0x04000FFC RID: 4092
		private CustomSelfDrawPanel.CSDLabel titleLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FFD RID: 4093
		private CustomSelfDrawPanel.CSDLabel descriptionLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04000FFE RID: 4094
		private CustomSelfDrawPanel.CSDHorzExtendingPanel titleBar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04000FFF RID: 4095
		private CustomSelfDrawPanel.CSDImage leftTrumpet = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001000 RID: 4096
		private CustomSelfDrawPanel.CSDImage rightTrumpet = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04001001 RID: 4097
		private CustomSelfDrawPanel.CSDLabel leaderboardHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001002 RID: 4098
		private CustomSelfDrawPanel.CSDLabel prizesHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001003 RID: 4099
		private CustomSelfDrawPanel.CSDLabel prizeContentHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001004 RID: 4100
		private CustomSelfDrawPanel.CSDLabel prizeContentInsetHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001005 RID: 4101
		private CustomSelfDrawPanel.CSDLabel playerRankHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001006 RID: 4102
		private CustomSelfDrawPanel.CSDLabel playerScoreHeaderLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001007 RID: 4103
		private CustomSelfDrawPanel.CSDLabel playerRankValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001008 RID: 4104
		private CustomSelfDrawPanel.CSDLabel playerScoreValueLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04001009 RID: 4105
		private CustomSelfDrawPanel.CSDLabel lastUpdateLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400100A RID: 4106
		private CustomSelfDrawPanel.CSDLabel timeRemainingLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x0400100B RID: 4107
		private CustomSelfDrawPanel.CSDExtendingPanel leaderboardInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400100C RID: 4108
		private CustomSelfDrawPanel.CSDExtendingPanel prizesInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400100D RID: 4109
		private CustomSelfDrawPanel.CSDExtendingPanel prizeContentInset = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x0400100E RID: 4110
		private CustomSelfDrawPanel.CSDButton closePrizeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400100F RID: 4111
		private CustomSelfDrawPanel.CSDButton topButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001010 RID: 4112
		private CustomSelfDrawPanel.CSDButton upButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001011 RID: 4113
		private CustomSelfDrawPanel.CSDButton downButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001012 RID: 4114
		private CustomSelfDrawPanel.CSDButton bottomButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001013 RID: 4115
		private CustomSelfDrawPanel.CSDButton historyButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001014 RID: 4116
		private CustomSelfDrawPanel.CSDButton nextTierButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001015 RID: 4117
		private CustomSelfDrawPanel.CSDButton prevTierButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04001016 RID: 4118
		private ContestsPanel.AsyncDelegate m_PrizeRequestDel;

		// Token: 0x04001017 RID: 4119
		private ContestsPanel.ResponseDelegate m_PrizeResponseDel;

		// Token: 0x04001018 RID: 4120
		private ContestCachedData leaderboardData;

		// Token: 0x04001019 RID: 4121
		private DateTime m_LastLocalUpdate = DateTime.MinValue;

		// Token: 0x0400101A RID: 4122
		private ContestPrizeList m_PrizeContent = new ContestPrizeList();

		// Token: 0x02000146 RID: 326
		// (Invoke) Token: 0x06000C13 RID: 3091
		private delegate void AsyncDelegate();

		// Token: 0x02000147 RID: 327
		// (Invoke) Token: 0x06000C17 RID: 3095
		private delegate void ResponseDelegate(bool success);
	}
}
