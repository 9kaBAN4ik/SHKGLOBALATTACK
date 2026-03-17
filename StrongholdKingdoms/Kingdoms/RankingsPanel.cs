using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002AF RID: 687
	public class RankingsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001EBA RID: 7866 RVA: 0x0001D4B4 File Offset: 0x0001B6B4
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001EBB RID: 7867 RVA: 0x0001D4C4 File Offset: 0x0001B6C4
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001EBC RID: 7868 RVA: 0x0001D4D4 File Offset: 0x0001B6D4
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001EBD RID: 7869 RVA: 0x0001D4E6 File Offset: 0x0001B6E6
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001EBE RID: 7870 RVA: 0x0001D4F3 File Offset: 0x0001B6F3
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
		}

		// Token: 0x06001EBF RID: 7871 RVA: 0x0001D507 File Offset: 0x0001B707
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001EC0 RID: 7872 RVA: 0x0001D514 File Offset: 0x0001B714
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x0001D521 File Offset: 0x0001B721
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x001D9858 File Offset: 0x001D7A58
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			this.MaximumSize = new Size(992, 566);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.Name = "RankingsPanel2";
			base.ResumeLayout(false);
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x001D98C4 File Offset: 0x001D7AC4
		public RankingsPanel()
		{
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.NoDrawBackground = true;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0001D540 File Offset: 0x0001B740
		public void logout()
		{
			RankingsPanel.progressData = null;
			RankingsPanel.lastProgressDownload = DateTime.MinValue;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x001D9A98 File Offset: 0x001D7C98
		public void init(bool initialCall)
		{
			RankingsPanel.animating = false;
			base.clearControls();
			this.progressSlots.Clear();
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 18, new Point(base.Width - 39, 11));
			this.mainBackgroundImage.Image = GFXLibrary.body_background_canvas;
			this.mainBackgroundImage.Position = new Point(0, 0);
			base.addControl(this.mainBackgroundImage);
			this.mainBackgroundArea.Position = new Point(0, 0);
			this.mainBackgroundArea.Size = new Size(992, 566);
			this.mainBackgroundImage.addControl(this.mainBackgroundArea);
			this.filledArea.Position = new Point(0, 0);
			this.filledArea.Size = this.mainBackgroundArea.Size;
			CustomSelfDrawPanel.WikiLinkControl.init(this.mainBackgroundArea, 44, new Point(509, 243));
			this.currentRankLabel.Text = "";
			this.currentRankLabel.Color = Color.FromArgb(224, 203, 146);
			this.currentRankLabel.DropShadowColor = Color.FromArgb(56, 50, 36);
			this.currentRankLabel.Position = new Point(29, 12);
			this.currentRankLabel.Size = new Size(992, 50);
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.currentRankLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Bold);
			}
			else
			{
				this.currentRankLabel.Font = FontManager.GetFont("Arial", 20f, FontStyle.Bold);
			}
			this.currentRankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.mainBackgroundArea.addControl(this.currentRankLabel);
			this.nextRankLabel.Text = "";
			this.nextRankLabel.Color = global::ARGBColors.Black;
			this.nextRankLabel.Position = new Point(0, 17);
			this.nextRankLabel.Size = new Size(767, 50);
			if (Program.mySettings.LanguageIdent == "it")
			{
				this.nextRankLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			}
			else
			{
				this.nextRankLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
			}
			this.nextRankLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.mainBackgroundArea.addControl(this.nextRankLabel);
			this.upgradeButton.Position = new Point(785, 10);
			this.upgradeButton.Size = new Size(168, 38);
			this.upgradeButton.Text.Text = "1,000";
			this.upgradeButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.upgradeButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.upgradeButton.TextYOffset = -1;
			this.upgradeButton.Text.Color = global::ARGBColors.Black;
			this.upgradeButton.ImageIcon = GFXLibrary.com_32_honour_DS;
			this.upgradeButton.ImageIconPosition = new Point(5, -5);
			this.upgradeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.upgradeClick), "RankingsPanel_rank_up_click");
			this.upgradeButton.CustomTooltipID = 400;
			this.upgradeButton.Enabled = false;
			this.mainBackgroundImage.addControl(this.upgradeButton);
			this.upgradeButton.setNormalExtImage(GFXLibrary.int_buttonbar_left_normal, GFXLibrary.int_buttonbar_middle_normal, GFXLibrary.int_buttonbar_right_normal);
			this.upgradeButton.setOverExtImage(GFXLibrary.int_buttonbar_left_over, GFXLibrary.int_buttonbar_middle_over, GFXLibrary.int_buttonbar_right_over);
			if (GameEngine.Instance.World.getRank() == 22)
			{
				this.rankImage01.Image = GFXLibrary.rank_progression_crown_prince;
				this.rankImage01.Position = new Point(8, 53);
				this.rankImage01.CustomTooltipID = 401;
				this.rankImage01.CustomTooltipData = 22;
				this.filledArea.addControl(this.rankImage01);
			}
			else
			{
				this.rankImage01.Image = GFXLibrary.rank_images[44];
				this.rankImage01.Position = new Point(10, 53);
				this.rankImage01.CustomTooltipID = 401;
				this.rankImage01.CustomTooltipData = 0;
				this.filledArea.addControl(this.rankImage01);
				this.rankImage02.Image = GFXLibrary.rank_images[45];
				this.rankImage02.Position = new Point(this.rankImage01.X + this.rankImage01.Width, 53);
				this.rankImage02.CustomTooltipID = 401;
				this.rankImage02.CustomTooltipData = 1;
				this.filledArea.addControl(this.rankImage02);
				this.rankImage03.Image = GFXLibrary.rank_images[46];
				this.rankImage03.Position = new Point(this.rankImage02.X + this.rankImage02.Width, 53);
				this.rankImage03.CustomTooltipID = 401;
				this.rankImage03.CustomTooltipData = 2;
				this.filledArea.addControl(this.rankImage03);
				this.rankImage04.Image = GFXLibrary.rank_images[47];
				this.rankImage04.Position = new Point(this.rankImage03.X + this.rankImage03.Width, 53);
				this.rankImage04.CustomTooltipID = 401;
				this.rankImage04.CustomTooltipData = 3;
				this.filledArea.addControl(this.rankImage04);
				this.rankImage05.Image = GFXLibrary.rank_images[48];
				this.rankImage05.Position = new Point(this.rankImage04.X + this.rankImage04.Width, 53);
				this.rankImage05.CustomTooltipID = 401;
				this.rankImage05.CustomTooltipData = 4;
				this.filledArea.addControl(this.rankImage05);
				this.rankImage06.Image = GFXLibrary.rank_images[49];
				this.rankImage06.Position = new Point(this.rankImage05.X + this.rankImage05.Width, 53);
				this.rankImage06.CustomTooltipID = 401;
				this.rankImage06.CustomTooltipData = 5;
				this.filledArea.addControl(this.rankImage06);
				this.rankImage07.Image = GFXLibrary.rank_images[50];
				this.rankImage07.Position = new Point(this.rankImage06.X + this.rankImage06.Width, 53);
				this.rankImage07.CustomTooltipID = 401;
				this.rankImage07.CustomTooltipData = 6;
				this.filledArea.addControl(this.rankImage07);
				this.rankImage08.Image = GFXLibrary.rank_images[51];
				this.rankImage08.Position = new Point(this.rankImage07.X + this.rankImage07.Width, 53);
				this.rankImage08.CustomTooltipID = 401;
				this.rankImage08.CustomTooltipData = 7;
				this.filledArea.addControl(this.rankImage08);
				this.rankImage09.Image = GFXLibrary.rank_images[52];
				this.rankImage09.Position = new Point(this.rankImage08.X + this.rankImage08.Width, 53);
				this.rankImage09.CustomTooltipID = 401;
				this.rankImage09.CustomTooltipData = 8;
				this.filledArea.addControl(this.rankImage09);
				this.rankImage10.Image = GFXLibrary.rank_images[53];
				this.rankImage10.Position = new Point(this.rankImage09.X + this.rankImage09.Width, 53);
				this.rankImage10.CustomTooltipID = 401;
				this.rankImage10.CustomTooltipData = 9;
				this.filledArea.addControl(this.rankImage10);
				this.rankImage11.Image = GFXLibrary.rank_images[54];
				this.rankImage11.Position = new Point(this.rankImage10.X + this.rankImage10.Width, 53);
				this.rankImage11.CustomTooltipID = 401;
				this.rankImage11.CustomTooltipData = 10;
				this.filledArea.addControl(this.rankImage11);
				this.rankImage12.Image = GFXLibrary.rank_images[55];
				this.rankImage12.Position = new Point(this.rankImage11.X + this.rankImage11.Width, 53);
				this.rankImage12.CustomTooltipID = 401;
				this.rankImage12.CustomTooltipData = 11;
				this.filledArea.addControl(this.rankImage12);
				this.rankImage13.Image = GFXLibrary.rank_images[56];
				this.rankImage13.Position = new Point(this.rankImage12.X + this.rankImage12.Width, 53);
				this.rankImage13.CustomTooltipID = 401;
				this.rankImage13.CustomTooltipData = 12;
				this.filledArea.addControl(this.rankImage13);
				this.rankImage14.Image = GFXLibrary.rank_images[57];
				this.rankImage14.Position = new Point(this.rankImage13.X + this.rankImage13.Width, 53);
				this.rankImage14.CustomTooltipID = 401;
				this.rankImage14.CustomTooltipData = 13;
				this.filledArea.addControl(this.rankImage14);
				this.rankImage15.Image = GFXLibrary.rank_images[58];
				this.rankImage15.Position = new Point(this.rankImage14.X + this.rankImage14.Width, 53);
				this.rankImage15.CustomTooltipID = 401;
				this.rankImage15.CustomTooltipData = 14;
				this.filledArea.addControl(this.rankImage15);
				this.rankImage16.Image = GFXLibrary.rank_images[59];
				this.rankImage16.Position = new Point(this.rankImage15.X + this.rankImage15.Width, 53);
				this.rankImage16.CustomTooltipID = 401;
				this.rankImage16.CustomTooltipData = 15;
				this.filledArea.addControl(this.rankImage16);
				this.rankImage17.Image = GFXLibrary.rank_images[60];
				this.rankImage17.Position = new Point(this.rankImage16.X + this.rankImage16.Width, 53);
				this.rankImage17.CustomTooltipID = 401;
				this.rankImage17.CustomTooltipData = 16;
				this.filledArea.addControl(this.rankImage17);
				this.rankImage18.Image = GFXLibrary.rank_images[61];
				this.rankImage18.Position = new Point(this.rankImage17.X + this.rankImage17.Width, 53);
				this.rankImage18.CustomTooltipID = 401;
				this.rankImage18.CustomTooltipData = 17;
				this.filledArea.addControl(this.rankImage18);
				this.rankImage19.Image = GFXLibrary.rank_images[62];
				this.rankImage19.Position = new Point(this.rankImage18.X + this.rankImage18.Width, 53);
				this.rankImage19.CustomTooltipID = 401;
				this.rankImage19.CustomTooltipData = 18;
				this.filledArea.addControl(this.rankImage19);
				this.rankImage20.Image = GFXLibrary.rank_images[63];
				this.rankImage20.Position = new Point(this.rankImage19.X + this.rankImage19.Width, 53);
				this.rankImage20.CustomTooltipID = 401;
				this.rankImage20.CustomTooltipData = 19;
				this.filledArea.addControl(this.rankImage20);
				this.rankImage21.Image = GFXLibrary.rank_images[64];
				this.rankImage21.Position = new Point(this.rankImage20.X + this.rankImage20.Width, 53);
				this.rankImage21.CustomTooltipID = 401;
				this.rankImage21.CustomTooltipData = 20;
				this.filledArea.addControl(this.rankImage21);
				this.rankImage22.Image = GFXLibrary.rank_images[65];
				this.rankImage22.Position = new Point(this.rankImage21.X + this.rankImage21.Width, 53);
				this.rankImage22.CustomTooltipID = 401;
				this.rankImage22.CustomTooltipData = 21;
				this.filledArea.addControl(this.rankImage22);
			}
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
			int num = localWorldData.ranks_Levels[GameEngine.Instance.World.getRank()];
			if (num > 100)
			{
				num = 1;
			}
			int num2 = 925 / num;
			for (int i = 0; i < num; i++)
			{
				RankingsPanel.CSDSlot csdslot = new RankingsPanel.CSDSlot();
				csdslot.Size = new Size(num2 - 4, 25);
				csdslot.Position = new Point(33 + i * num2, 187);
				this.mainBackgroundImage.addControl(csdslot);
				csdslot.MaxValue = 999999999;
				csdslot.CurrentValue = csdslot.MaxValue;
				csdslot.init(i < rankSubLevel, i >= num - 1);
				this.progressSlots.Add(csdslot);
			}
			RankingsPanel.lastRank = -1;
			RankingsPanel.lastRankSubLevel = -1;
			if (GameEngine.Instance.World.getRank() >= 1 && !GameEngine.Instance.World.TutorialIsAdvancing())
			{
				int tutorialStage = GameEngine.Instance.World.getTutorialStage();
				if (tutorialStage == 7)
				{
					GameEngine.Instance.World.forceTutorialToBeShown();
				}
			}
			List<int> userAchievements = RemoteServices.Instance.UserAchievements;
			this.medalWindow.Position = new Point(9, 213);
			this.medalWindow.init(userAchievements, true, false, 0);
			this.mainBackgroundImage.addControl(this.medalWindow);
			this.filledArea.FillColor = Color.FromArgb(0, 0, 0, 0);
			this.mainBackgroundImage.addControl(this.filledArea);
			this.selectedMedalWindow.Position = new Point(491, 313);
			this.selectedMedalWindow.init(new List<int>(), false, false, -150);
			this.mainBackgroundImage.addControl(this.selectedMedalWindow);
			this.selectedMedalWindow.Visible = false;
			this.medalWindow.setChildWindow(this.selectedMedalWindow);
			this.clearRankAnim();
			TimeSpan timeSpan = DateTime.Now - RankingsPanel.lastProgressDownload;
			if (RankingsPanel.progressData == null || timeSpan.TotalMinutes > 5.0)
			{
				RankingsPanel.lastProgressDownload = DateTime.Now;
				RemoteServices.Instance.set_AchievementProgress_UserCallBack(new RemoteServices.AchievementProgress_UserCallBack(this.achievementProgressCallback));
				RemoteServices.Instance.AchievementProgress();
			}
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0001D552 File Offset: 0x0001B752
		private void achievementProgressCallback(AchievementProgress_ReturnType returnData)
		{
			if (returnData.Success)
			{
				RankingsPanel.progressData = returnData;
			}
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x001DAA98 File Offset: 0x001D8C98
		public static int getProgressValue(int achievement)
		{
			achievement &= 268435455;
			if (achievement <= 194)
			{
				if (achievement <= 67)
				{
					if (achievement <= 34)
					{
						switch (achievement)
						{
						case 1:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_WOLVES_PROTECTOR;
							}
							break;
						case 2:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_BANDITS_LAW_BRINGER;
							}
							break;
						case 3:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_TROOPS_WARRIOR;
							}
							break;
						case 4:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_WOLFLAIRS_WOLF_HUNTER;
							}
							break;
						case 5:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_BANDITCAMPS_WEREGILD;
							}
							break;
						case 6:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_RATSCASTLE_RATTY_LOST_AGAIN;
							}
							break;
						case 7:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_SNAKESCASTLE_SNAKES_DOWNFALL;
							}
							break;
						case 8:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_PIGSCASTLE_SQUEALPIGGY;
							}
							break;
						case 9:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_WOLFSCASTLE_WOLFBANE;
							}
							break;
						case 10:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_FLAGS_FLAG_RAIDER;
							}
							break;
						case 11:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_RAZE_FIRESTARTER;
							}
							break;
						case 12:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_CAPTURE_CONQUEROR;
							}
							break;
						case 13:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_PILLAGE_VIKING;
							}
							break;
						case 14:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_RANSACK_VANDAL;
							}
							break;
						case 15:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_PALADINCASTLE_EVILLORD;
							}
							break;
						case 16:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.ATTACKING_TREASURESCASTLE_TREASUREHUNTER;
							}
							break;
						default:
							if (achievement == 34)
							{
								return -1;
							}
							break;
						}
					}
					else if (achievement != 37)
					{
						switch (achievement)
						{
						case 65:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.CASTLE_FIREBALLISTAS_BALLISTA_CRAZY;
							}
							break;
						case 66:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.CASTLE_POUROIL_FEEL_THE_HEAT;
							}
							break;
						case 67:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.CASTLE_STAKE_TRAPS_DEATHTRAP;
							}
							break;
						}
					}
					else if (RankingsPanel.progressData != null)
					{
						return RankingsPanel.progressData.DEFENDING_KILLATTACKS_VANQUISHER;
					}
				}
				else if (achievement <= 101)
				{
					if (achievement == 100)
					{
						return (int)GameEngine.Instance.World.getCurrentGold();
					}
					if (achievement == 101)
					{
						if (RankingsPanel.progressData != null)
						{
							return RankingsPanel.progressData.VILLAGE_SENDGOODS_CHARITY;
						}
					}
				}
				else
				{
					switch (achievement)
					{
					case 129:
						if (RankingsPanel.progressData != null)
						{
							return RankingsPanel.progressData.MONKS_CUREDISEASE_HEALER;
						}
						break;
					case 130:
						if (RankingsPanel.progressData != null)
						{
							return RankingsPanel.progressData.MONKS_INTERDICT_PEACEBRINGER;
						}
						break;
					case 131:
						if (RankingsPanel.progressData != null)
						{
							return RankingsPanel.progressData.MONKS_INFLUENCE_DIPLOMAT;
						}
						break;
					default:
						switch (achievement)
						{
						case 161:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.SCOUTING_SCOUTRESOURCES_HORSE_MASTER;
							}
							break;
						case 162:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.SCOUTING_UNCOVERSTASHES_LIGHTNING_SPEED;
							}
							break;
						case 163:
							if (RankingsPanel.progressData != null)
							{
								return RankingsPanel.progressData.SCOUTING_PACKETSRETREIVED_MASTER_FORAGER;
							}
							break;
						default:
							if (achievement == 194)
							{
								return -1;
							}
							break;
						}
						break;
					}
				}
			}
			else if (achievement <= 289)
			{
				if (achievement <= 225)
				{
					if (achievement == 195)
					{
						return GameEngine.Instance.World.getCurrentFactionDuration();
					}
					if (achievement == 225)
					{
						return -1;
					}
				}
				else if (achievement != 226)
				{
					if (achievement != 257)
					{
						if (achievement == 289)
						{
							return -1;
						}
					}
					else if (RankingsPanel.progressData != null)
					{
						return RankingsPanel.progressData.MARKET_MAKEGOLD_STOCKBROKER;
					}
				}
				else if (RankingsPanel.progressData != null)
				{
					return RankingsPanel.progressData.RESEARCH_COMPLETED_LEARNED_SCHOLAR;
				}
			}
			else if (achievement <= 321)
			{
				if (achievement != 290)
				{
					if (achievement == 321)
					{
						return -1;
					}
				}
				else if (RankingsPanel.progressData != null)
				{
					return RankingsPanel.progressData.BANQUETING_HONOUR_BANQUET_KING;
				}
			}
			else if (achievement != 353)
			{
				if (achievement != 354)
				{
					switch (achievement)
					{
					case 385:
						return GameEngine.Instance.World.numUserParishes();
					case 386:
						return GameEngine.Instance.World.numUserCounties();
					case 387:
						return GameEngine.Instance.World.numUserProvinces();
					case 388:
						return GameEngine.Instance.World.numUserCountries();
					}
				}
				else if (RankingsPanel.progressData != null)
				{
					return RankingsPanel.progressData.PARISH_PLACEBUILDINGS_SKILLED_RULER;
				}
			}
			else if (RankingsPanel.progressData != null)
			{
				return RankingsPanel.progressData.PARISH_DONATEPACKETS_TEAM_PLAYER;
			}
			return -1;
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x0001D562 File Offset: 0x0001B762
		public static void setRanking(int rank, int rankSubLevel)
		{
			RankingsPanel.lastRank = rank;
			RankingsPanel.lastRankSubLevel = rankSubLevel;
			RankingsPanel.newIn = true;
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x0001D576 File Offset: 0x0001B776
		public void update()
		{
			this.setCurrentRankings(RankingsPanel.lastRank, RankingsPanel.lastRankSubLevel);
			this.updateRankRanim();
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x001DAF48 File Offset: 0x001D9148
		public void setCurrentRankings(int rank, int rankSubLevel)
		{
			bool flag = RankingsPanel.newIn;
			RankingsPanel.newIn = false;
			if (rank != RankingsPanel.lastRank || RankingsPanel.lastRankSubLevel != rankSubLevel)
			{
				flag = true;
			}
			if (rank < 0)
			{
				rank = 0;
			}
			else if (rank >= 23)
			{
				rank = 22;
			}
			RankingsPanel.lastRank = rank;
			RankingsPanel.lastRankSubLevel = rankSubLevel;
			NumberFormatInfo nfi = GameEngine.NFI;
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			this.currentRankLabel.Text = Rankings.getRankingName(localWorldData, rank, rankSubLevel, false, RemoteServices.Instance.UserAvatar.male);
			double num = GameEngine.Instance.World.getCurrentHonour();
			if (rank == 21 && rankSubLevel >= 24)
			{
				this.upgradeButton.Text.Text = 10000000.ToString("N", nfi);
			}
			else if (rank < 22)
			{
				this.upgradeButton.Text.Text = localWorldData.ranks_HonourPerLevel[rank].ToString("N", nfi);
			}
			else
			{
				int num2 = (int)Rankings.calcHonourForCrownPrince(rankSubLevel);
				this.upgradeButton.Text.Text = num2.ToString("N", nfi);
			}
			int num3 = rank;
			int num4 = rankSubLevel + 1;
			if (num4 >= localWorldData.ranks_Levels[rank])
			{
				num4 = 0;
				num3++;
			}
			if (num3 >= 23)
			{
				this.upgradeButton.Enabled = false;
			}
			else
			{
				this.nextRankLabel.Text = Rankings.getRankingName(localWorldData, num3, num4, false, RemoteServices.Instance.UserAvatar.male);
				double num5 = (double)localWorldData.ranks_HonourPerLevel[rank];
				if (rank != 21)
				{
					if (rank == 22)
					{
						num5 = Rankings.calcHonourForCrownPrince(rankSubLevel);
					}
				}
				else if (rankSubLevel >= 24)
				{
					num5 = 10000000.0;
				}
				if (num >= num5)
				{
					this.upgradeButton.Enabled = true;
				}
				else
				{
					this.upgradeButton.Enabled = false;
				}
			}
			int num6 = localWorldData.ranks_Levels[rank];
			if (num6 < 100)
			{
				for (int i = rankSubLevel; i < num6; i++)
				{
					if (i >= this.progressSlots.Count)
					{
						break;
					}
					int currentValue = this.progressSlots[i].CurrentValue;
					if (num < (double)localWorldData.ranks_HonourPerLevel[rank])
					{
						this.progressSlots[i].CurrentValue = (int)num;
						this.progressSlots[i].MaxValue = localWorldData.ranks_HonourPerLevel[rank];
					}
					else
					{
						this.progressSlots[i].CurrentValue = this.progressSlots[i].MaxValue;
					}
					num -= (double)localWorldData.ranks_HonourPerLevel[rank];
					if (currentValue != this.progressSlots[i].CurrentValue)
					{
						this.progressSlots[i].update();
					}
				}
			}
			else
			{
				double num7 = Rankings.calcHonourForCrownPrince(rankSubLevel);
				int index = 0;
				if (num < num7)
				{
					this.progressSlots[index].CurrentValue = (int)num;
					this.progressSlots[index].MaxValue = (int)num7;
				}
				else
				{
					this.progressSlots[index].CurrentValue = (int)num7;
					this.progressSlots[index].MaxValue = (int)num7;
				}
				this.progressSlots[index].update();
			}
			if (flag && rank < 22)
			{
				for (int j = 0; j < 22; j++)
				{
					CustomSelfDrawPanel.CSDImage rankImage = this.getRankImage(j);
					int num8 = j;
					if (rank > j)
					{
						num8 += 22;
					}
					else if (rank < j)
					{
						num8 += 44;
					}
					rankImage.Image = GFXLibrary.rank_images[num8];
				}
			}
			if (GameEngine.Instance.World.WorldEnded)
			{
				this.upgradeButton.Enabled = false;
			}
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x001DB2D0 File Offset: 0x001D94D0
		private CustomSelfDrawPanel.CSDImage getRankImage(int rank)
		{
			switch (rank)
			{
			case 0:
				return this.rankImage01;
			case 1:
				return this.rankImage02;
			case 2:
				return this.rankImage03;
			case 3:
				return this.rankImage04;
			case 4:
				return this.rankImage05;
			case 5:
				return this.rankImage06;
			case 6:
				return this.rankImage07;
			case 7:
				return this.rankImage08;
			case 8:
				return this.rankImage09;
			case 9:
				return this.rankImage10;
			case 10:
				return this.rankImage11;
			case 11:
				return this.rankImage12;
			case 12:
				return this.rankImage13;
			case 13:
				return this.rankImage14;
			case 14:
				return this.rankImage15;
			case 15:
				return this.rankImage16;
			case 16:
				return this.rankImage17;
			case 17:
				return this.rankImage18;
			case 18:
				return this.rankImage19;
			case 19:
				return this.rankImage20;
			case 20:
				return this.rankImage21;
			case 21:
				return this.rankImage22;
			default:
				return null;
			}
		}

		// Token: 0x06001ECC RID: 7884 RVA: 0x001DB3DC File Offset: 0x001D95DC
		private void upgradeClick()
		{
			if (!this.inUpgrade)
			{
				this.ignoreSetCurrent = false;
				this.inUpgrade = true;
				this.upgradeButton.Enabled = false;
				int rankSubLevel = GameEngine.Instance.World.getRankSubLevel();
				int rank = GameEngine.Instance.World.getRank();
				RemoteServices.Instance.set_UpgradeRank_UserCallBack(new RemoteServices.UpgradeRank_UserCallBack(this.upgradeRankCallBack));
				RemoteServices.Instance.UpgradeRank(rank, rankSubLevel);
				if (rankSubLevel + 1 >= GameEngine.Instance.LocalWorldData.ranks_Levels[rank])
				{
					Sound.playVillageEnvironmental(20 + rank, false, true);
					this.ignoreSetCurrent = true;
					this.startRankAnim(rank + 1);
					return;
				}
				GameEngine.Instance.playInterfaceSound("RankingsPanel_subrank_up");
			}
		}

		// Token: 0x06001ECD RID: 7885 RVA: 0x001DB494 File Offset: 0x001D9694
		private void upgradeRankCallBack(UpgradeRank_ReturnType returnData)
		{
			this.inUpgrade = false;
			if (returnData.Success)
			{
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				InterfaceMgr.Instance.setHonour(returnData.currentHonourLevel, returnData.rank);
				GameEngine.Instance.World.setRanking(returnData.rank, returnData.rankSubLevel);
				if (!this.ignoreSetCurrent)
				{
					this.init(false);
					base.Invalidate();
					this.setCurrentRankings(returnData.rank, returnData.rankSubLevel);
				}
				GameEngine.Instance.World.setResearchData(returnData.researchData);
				InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				if (returnData.rank == 1)
				{
					int tutorialStage = GameEngine.Instance.World.getTutorialStage();
					if (tutorialStage == 7)
					{
						GameEngine.Instance.World.forceTutorialToBeShown();
					}
				}
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
				GameEngine.Instance.cardsManager.ResetPremiumOffers();
				GameEngine.Instance.cardsManager.RetrievePremiumOffers();
				return;
			}
			this.upgradeButton.Enabled = true;
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x0001D58E File Offset: 0x0001B78E
		private void clearRankAnim()
		{
			this.doingRankAnim = false;
		}

		// Token: 0x06001ECF RID: 7887 RVA: 0x001DB5CC File Offset: 0x001D97CC
		private void startRankAnim(int rank)
		{
			if (rank <= GFXLibrary.RankAnim_Images.Length)
			{
				this.majorRankUp = rank;
				if (rank == 22)
				{
					this.cpImage.Image = GFXLibrary.rank_progression_crown_prince;
					this.cpImage.Position = new Point(8, 53);
					this.cpImage.Alpha = 0f;
					this.filledArea.addControl(this.cpImage);
				}
				this.animBack.Size = base.Size;
				this.animBack.clearControls();
				this.filledArea.addControl(this.animBack);
				this.scaledImage.Scale = 1.0;
				if (rank == GFXLibrary.RankAnim_Images.Length)
				{
					this.scaledImage.Image = GFXLibrary.RankAnim_Images23;
				}
				else
				{
					this.scaledImage.Image = GFXLibrary.RankAnim_Images[rank];
				}
				this.scaledImage.Position = new Point(0, 0);
				this.scaledImage.Alpha = 0f;
				CustomSelfDrawPanel.CSDControl csdcontrol = this.unscaledArea;
				Point position = new Point((base.Width - this.scaledImage.Image.Width) / 2, 0);
				csdcontrol.Position = position;
				position = (this.startPos = position);
				this.animBack.addControl(this.unscaledArea);
				this.targetScale = 0.22364217252396165;
				this.zoomCount = 0;
				switch (rank)
				{
				case 0:
					this.dx = 0.0;
					this.dy = 0.0;
					this.targetScale = 0.2236024844720497;
					break;
				case 1:
					this.dx = -344.0;
					this.dy = 88.0;
					this.targetScale = 0.21693121693121692;
					break;
				case 2:
					this.dx = -309.0;
					this.dy = 85.0;
					this.targetScale = 0.22419928825622776;
					break;
				case 3:
					this.dx = -271.0;
					this.dy = 83.0;
					this.targetScale = 0.22295081967213115;
					break;
				case 4:
					this.dx = -236.0;
					this.dy = 87.0;
					this.targetScale = 0.22;
					break;
				case 5:
					this.dx = -201.0;
					this.dy = 82.0;
					this.targetScale = 0.22115384615384615;
					break;
				case 6:
					this.dx = -159.0;
					this.dy = 80.0;
					this.targetScale = 0.22468354430379747;
					break;
				case 7:
					this.dx = -108.0;
					this.dy = 75.0;
					this.targetScale = 0.2260061919504644;
					break;
				case 8:
					this.dx = -59.0;
					this.dy = 79.0;
					this.targetScale = 0.22324159021406728;
					break;
				case 9:
					this.dx = -12.0;
					this.dy = 77.0;
					this.targetScale = 0.2238372093023256;
					break;
				case 10:
					this.dx = 38.0;
					this.dy = 78.0;
					this.targetScale = 0.22287390029325513;
					break;
				case 11:
					this.dx = 84.0;
					this.dy = 68.0;
					this.targetScale = 0.22388059701492538;
					break;
				case 12:
					this.dx = 128.0;
					this.dy = 70.0;
					this.targetScale = 0.21965317919075145;
					break;
				case 13:
					this.dx = 161.0;
					this.dy = 71.0;
					this.targetScale = 0.21902017291066284;
					break;
				case 14:
					this.dx = 202.0;
					this.dy = 68.0;
					this.targetScale = 0.21690140845070421;
					break;
				case 15:
					this.dx = 236.0;
					this.dy = 64.0;
					this.targetScale = 0.22131147540983606;
					break;
				case 16:
					this.dx = 273.0;
					this.dy = 65.0;
					this.targetScale = 0.22465753424657534;
					break;
				case 17:
					this.dx = 318.0;
					this.dy = 62.0;
					this.targetScale = 0.22459893048128343;
					break;
				case 18:
					this.dx = 369.0;
					this.dy = 57.0;
					this.targetScale = 0.22564102564102564;
					break;
				case 19:
					this.dx = 414.0;
					this.dy = 61.0;
					this.targetScale = 0.22422680412371135;
					break;
				case 20:
					this.dx = 462.0;
					this.dy = 35.0;
					this.targetScale = 0.2833333333333333;
					break;
				case 21:
					this.dx = 523.0;
					this.dy = 45.0;
					this.targetScale = 0.26112759643916916;
					break;
				case 22:
					this.dx = 54.0;
					this.dy = 50.0;
					this.targetScale = 0.6265060240963856;
					break;
				}
				this.numSteps = (int)((1.0 - this.targetScale) / 0.02);
				this.dx /= (double)this.numSteps;
				this.dy /= (double)this.numSteps;
				this.unscaledArea.addControl(this.scaledImage);
				this.doingRankAnim = true;
				this.fadeCount = 20;
				RankingsPanel.animating = true;
			}
		}

		// Token: 0x06001ED0 RID: 7888 RVA: 0x001DBC80 File Offset: 0x001D9E80
		private void updateRankRanim()
		{
			if (!this.doingRankAnim)
			{
				return;
			}
			if (this.fadeCount > 0)
			{
				this.fadeCount--;
				this.scaledImage.Alpha += 0.05f;
				this.filledArea.FillColor = Color.FromArgb(160 - this.fadeCount * 8, 0, 0, 0);
				return;
			}
			if (this.fadeCount < 0)
			{
				this.fadeCount++;
				this.filledArea.FillColor = Color.FromArgb(-(this.fadeCount * 8), 0, 0, 0);
				if (this.fadeCount == 0)
				{
					this.doingRankAnim = false;
					this.filledArea.removeControl(this.animBack);
					this.filledArea.FillColor = Color.FromArgb(0, 0, 0, 0);
					this.init(false);
					base.Invalidate();
					this.setCurrentRankings(this.majorRankUp, 0);
				}
				return;
			}
			this.zoomCount++;
			this.scaledImage.Scale = 1.0 - (double)this.zoomCount * 0.02;
			this.unscaledArea.Position = new Point(this.startPos.X + (int)(this.dx * (double)this.zoomCount), this.startPos.Y + (int)(this.dy * (double)this.zoomCount));
			if (this.zoomCount >= this.numSteps)
			{
				this.setCurrentRankings(this.majorRankUp, 0);
				this.scaledImage.Scale = this.targetScale;
				this.scaledImage.Alpha = 0f;
				base.Invalidate();
				this.fadeCount = -20;
				return;
			}
			if (this.zoomCount > this.numSteps - 20 && this.cpImage.Alpha < 1f)
			{
				this.cpImage.Alpha += 0.05f;
			}
			base.Invalidate();
		}

		// Token: 0x04002F82 RID: 12162
		private const int medalWindow_area_x = 9;

		// Token: 0x04002F83 RID: 12163
		private const int medalWindow_area_y = 213;

		// Token: 0x04002F84 RID: 12164
		private const double zoomStep = 0.02;

		// Token: 0x04002F85 RID: 12165
		private DockableControl dockableControl;

		// Token: 0x04002F86 RID: 12166
		private IContainer components;

		// Token: 0x04002F87 RID: 12167
		public static AchievementProgress_ReturnType progressData = null;

		// Token: 0x04002F88 RID: 12168
		public static DateTime lastProgressDownload = DateTime.MinValue;

		// Token: 0x04002F89 RID: 12169
		public static bool animating = false;

		// Token: 0x04002F8A RID: 12170
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F8B RID: 12171
		private CustomSelfDrawPanel.CSDArea mainBackgroundArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002F8C RID: 12172
		private CustomSelfDrawPanel.CSDFill filledArea = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002F8D RID: 12173
		private CustomSelfDrawPanel.CSDLabel currentRankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F8E RID: 12174
		private CustomSelfDrawPanel.CSDLabel nextRankLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F8F RID: 12175
		private CustomSelfDrawPanel.CSDImage rankImage01 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F90 RID: 12176
		private CustomSelfDrawPanel.CSDImage rankImage02 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F91 RID: 12177
		private CustomSelfDrawPanel.CSDImage rankImage03 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F92 RID: 12178
		private CustomSelfDrawPanel.CSDImage rankImage04 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F93 RID: 12179
		private CustomSelfDrawPanel.CSDImage rankImage05 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F94 RID: 12180
		private CustomSelfDrawPanel.CSDImage rankImage06 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F95 RID: 12181
		private CustomSelfDrawPanel.CSDImage rankImage07 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F96 RID: 12182
		private CustomSelfDrawPanel.CSDImage rankImage08 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F97 RID: 12183
		private CustomSelfDrawPanel.CSDImage rankImage09 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F98 RID: 12184
		private CustomSelfDrawPanel.CSDImage rankImage10 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F99 RID: 12185
		private CustomSelfDrawPanel.CSDImage rankImage11 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9A RID: 12186
		private CustomSelfDrawPanel.CSDImage rankImage12 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9B RID: 12187
		private CustomSelfDrawPanel.CSDImage rankImage13 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9C RID: 12188
		private CustomSelfDrawPanel.CSDImage rankImage14 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9D RID: 12189
		private CustomSelfDrawPanel.CSDImage rankImage15 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9E RID: 12190
		private CustomSelfDrawPanel.CSDImage rankImage16 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F9F RID: 12191
		private CustomSelfDrawPanel.CSDImage rankImage17 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA0 RID: 12192
		private CustomSelfDrawPanel.CSDImage rankImage18 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA1 RID: 12193
		private CustomSelfDrawPanel.CSDImage rankImage19 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA2 RID: 12194
		private CustomSelfDrawPanel.CSDImage rankImage20 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA3 RID: 12195
		private CustomSelfDrawPanel.CSDImage rankImage21 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA4 RID: 12196
		private CustomSelfDrawPanel.CSDImage rankImage22 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA5 RID: 12197
		private CustomSelfDrawPanel.CSDButton upgradeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002FA6 RID: 12198
		private CustomSelfDrawPanel.CSDImage honourSymbol = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FA7 RID: 12199
		private CustomSelfDrawPanel.MedalWindow medalWindow = new CustomSelfDrawPanel.MedalWindow();

		// Token: 0x04002FA8 RID: 12200
		private CustomSelfDrawPanel.MedalWindow selectedMedalWindow = new CustomSelfDrawPanel.MedalWindow();

		// Token: 0x04002FA9 RID: 12201
		private List<RankingsPanel.CSDSlot> progressSlots = new List<RankingsPanel.CSDSlot>();

		// Token: 0x04002FAA RID: 12202
		private bool allowSharePopup;

		// Token: 0x04002FAB RID: 12203
		private static int lastRank = 0;

		// Token: 0x04002FAC RID: 12204
		private static int lastRankSubLevel = 0;

		// Token: 0x04002FAD RID: 12205
		private static bool newIn = false;

		// Token: 0x04002FAE RID: 12206
		private bool ignoreSetCurrent;

		// Token: 0x04002FAF RID: 12207
		private int majorRankUp;

		// Token: 0x04002FB0 RID: 12208
		private bool inUpgrade;

		// Token: 0x04002FB1 RID: 12209
		private bool doingRankAnim;

		// Token: 0x04002FB2 RID: 12210
		private CustomSelfDrawPanel.CSDArea animBack = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002FB3 RID: 12211
		private CustomSelfDrawPanel.CSDArea unscaledArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002FB4 RID: 12212
		private CustomSelfDrawPanel.CSDImage scaledImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002FB5 RID: 12213
		private double targetScale = 0.2834008097165992;

		// Token: 0x04002FB6 RID: 12214
		private Point startPos;

		// Token: 0x04002FB7 RID: 12215
		private double dx;

		// Token: 0x04002FB8 RID: 12216
		private double dy;

		// Token: 0x04002FB9 RID: 12217
		private int zoomCount;

		// Token: 0x04002FBA RID: 12218
		private int numSteps;

		// Token: 0x04002FBB RID: 12219
		private int fadeCount;

		// Token: 0x04002FBC RID: 12220
		private CustomSelfDrawPanel.CSDImage cpImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x020002B0 RID: 688
		private class CSDSlot : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x17000206 RID: 518
			// (get) Token: 0x06001ED2 RID: 7890 RVA: 0x0001D5C1 File Offset: 0x0001B7C1
			// (set) Token: 0x06001ED3 RID: 7891 RVA: 0x0001D5C9 File Offset: 0x0001B7C9
			public int MaxValue
			{
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
				}
			}

			// Token: 0x17000207 RID: 519
			// (get) Token: 0x06001ED4 RID: 7892 RVA: 0x0001D5D2 File Offset: 0x0001B7D2
			// (set) Token: 0x06001ED5 RID: 7893 RVA: 0x0001D5DA File Offset: 0x0001B7DA
			public int CurrentValue
			{
				get
				{
					return this.currentValue;
				}
				set
				{
					this.currentValue = value;
				}
			}

			// Token: 0x06001ED6 RID: 7894 RVA: 0x001DBE70 File Offset: 0x001DA070
			public void init(bool green, bool ending)
			{
				this.back.Size = this.Size;
				this.back.Position = new Point(0, 0);
				base.addControl(this.back);
				this.back.Create(GFXLibrary.honour_rank_slot_left, GFXLibrary.honour_rank_slot_middle, GFXLibrary.honour_rank_slot_right);
				this.bar.Position = new Point(2, 4);
				this.bar.Size = new Size(base.Width - 4, base.Height - 7);
				base.addControl(this.bar);
				if (green)
				{
					this.bar.Create(GFXLibrary.honour_rank_slot_green_left, GFXLibrary.honour_rank_slot_green_middle, GFXLibrary.honour_rank_slot_green_right);
				}
				else
				{
					this.bar.Create(GFXLibrary.honour_rank_slot_yellow_left, GFXLibrary.honour_rank_slot_yellow_middle, GFXLibrary.honour_rank_slot_yellow_right);
				}
				if (this.currentValue == 0)
				{
					this.bar.Visible = false;
				}
				this.divider.Image = GFXLibrary.honour_rank_slot_divider;
				this.divider.Position = new Point(base.Width - 8, 0);
				if (!ending)
				{
					base.addControl(this.divider);
				}
				this.update();
			}

			// Token: 0x06001ED7 RID: 7895 RVA: 0x001DBFC4 File Offset: 0x001DA1C4
			public void update()
			{
				if (this.currentValue <= 0)
				{
					this.bar.Visible = false;
				}
				else
				{
					this.bar.Visible = true;
					int num = (int)((base.Width - 4 - 30) * this.currentValue / Math.Max(1, this.maxValue));
					this.bar.Size = new Size(num + 30, base.Height - 7);
					this.bar.resize();
				}
				base.invalidate();
			}

			// Token: 0x04002FBD RID: 12221
			private int maxValue = 1;

			// Token: 0x04002FBE RID: 12222
			private int currentValue;

			// Token: 0x04002FBF RID: 12223
			public CustomSelfDrawPanel.CSDHorzExtendingPanel back = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

			// Token: 0x04002FC0 RID: 12224
			public CustomSelfDrawPanel.CSDHorzExtendingPanel bar = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

			// Token: 0x04002FC1 RID: 12225
			public CustomSelfDrawPanel.CSDImage divider = new CustomSelfDrawPanel.CSDImage();
		}
	}
}
