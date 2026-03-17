using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004A8 RID: 1192
	public class TutorialPanel : CustomSelfDrawPanel
	{
		// Token: 0x06002B90 RID: 11152 RVA: 0x00020040 File Offset: 0x0001E240
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002B91 RID: 11153 RVA: 0x00224C24 File Offset: 0x00222E24
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			base.Name = "TutorialPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06002B92 RID: 11154 RVA: 0x00224C78 File Offset: 0x00222E78
		public TutorialPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06002B93 RID: 11155 RVA: 0x00224D54 File Offset: 0x00222F54
		public void setText(int tutorialID, Form parent, bool force)
		{
			this.lastTutorialID = tutorialID;
			TutorialPanel.m_parent = parent;
			base.clearControls();
			this.transparentBackground.Size = base.Size;
			this.transparentBackground.FillColor = Color.FromArgb(255, 0, 255);
			base.addControl(this.transparentBackground);
			this.background.Position = new Point(0, 0);
			this.background.Image = GFXLibrary.tutorial_background;
			this.background.Size = new Size(this.background.Image.Width, this.background.Image.Height);
			base.addControl(this.background);
			this.advisor.Image = GFXLibrary.tutorial_longarm1;
			int num = 0;
			if (tutorialID != -25)
			{
				switch (tutorialID)
				{
				case 0:
					this.advisor.Image = GFXLibrary.tutorial_longarm3;
					break;
				case 1:
				case 4:
				case 9:
					break;
				case 2:
					num = 2;
					this.advisor.Image = GFXLibrary.tutorial_longarm6;
					break;
				case 3:
					num = 4;
					this.advisor.Image = GFXLibrary.tutorial_longarm2;
					break;
				case 5:
					num = 5;
					this.advisor.Image = GFXLibrary.tutorial_longarm1;
					break;
				case 6:
					num = 6;
					this.advisor.Image = GFXLibrary.tutorial_longarm11;
					break;
				case 7:
					num = 7;
					this.advisor.Image = GFXLibrary.tutorial_longarm2;
					break;
				case 8:
					num = 8;
					this.advisor.Image = GFXLibrary.tutorial_longarm3;
					break;
				case 10:
					num = 11;
					this.advisor.Image = GFXLibrary.tutorial_longarm11;
					break;
				case 11:
					num = 12;
					this.advisor.Image = GFXLibrary.tutorial_longarm8;
					break;
				case 12:
					num = 13;
					this.advisor.Image = GFXLibrary.tutorial_longarm6;
					break;
				default:
					switch (tutorialID)
					{
					case 100:
						num = 1;
						this.advisor.Image = GFXLibrary.tutorial_longarm2;
						break;
					case 101:
						num = 3;
						this.advisor.Image = GFXLibrary.tutorial_longarm5;
						break;
					case 102:
						num = 9;
						this.advisor.Image = GFXLibrary.tutorial_longarm5;
						break;
					case 103:
						num = 10;
						this.advisor.Image = GFXLibrary.tutorial_longarm1;
						break;
					case 104:
						num = 14;
						this.advisor.Image = GFXLibrary.tutorial_longarm10;
						break;
					case 105:
						num = 15;
						this.advisor.Image = GFXLibrary.tutorial_longarm1;
						break;
					}
					break;
				}
			}
			else
			{
				num = -1;
			}
			this.advisor.Position = new Point(5, base.Height - this.advisor.Image.Height - 3);
			base.addControl(this.advisor);
			try
			{
				this.illustration.Image = GFXLibrary.tutorial_illustrations[num];
				this.illustration.Position = new Point(618, 31);
				this.illustration.ClipRect = new Rectangle(0, 0, 150, 172);
				this.background.addControl(this.illustration);
			}
			catch (Exception)
			{
			}
			if (tutorialID == -25)
			{
				this.headerLabel.Text = SK.Text("QuestRewardPopup_Reward", "Reward");
			}
			else
			{
				this.headerLabel.Text = Tutorials.getTutorialHeaderText(tutorialID);
			}
			this.headerLabel.Color = global::ARGBColors.Black;
			this.headerLabel.Position = new Point(0, 2);
			this.headerLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.headerLabel.Size = new Size(this.background.Width - 30, 40);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.headerLabel);
			this.bodyLabel.Text = Tutorials.getTutorialBodyText(tutorialID);
			this.rewardLabel.Text = "";
			this.rewardLabel.Color = global::ARGBColors.Black;
			this.rewardLabel.Position = new Point(120, 40);
			this.rewardLabel.Font = FontManager.GetFont("Arial", 13f, FontStyle.Bold);
			this.rewardLabel.Size = new Size(510, 138);
			this.rewardLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.background.addControl(this.rewardLabel);
			this.bodyLabel.Color = global::ARGBColors.Black;
			this.bodyLabel.Position = new Point(120, 32);
			this.bodyLabel.Font = FontManager.GetFont("Arial", 13f, FontStyle.Bold);
			this.bodyLabel.Size = new Size(510, 138);
			this.bodyLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.background.addControl(this.bodyLabel);
			if (this.bodyLabel.TextSize.Height > 120)
			{
				this.bodyLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				if (this.bodyLabel.TextSize.Height > 120)
				{
					this.bodyLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				}
			}
			int num2 = this.lastStageID;
			for (int i = 0; i < Tutorials.tutorialOrdering.Length; i++)
			{
				if (Tutorials.tutorialOrdering[i] == tutorialID)
				{
					num2 = i;
					break;
				}
			}
			this.lastStageID = num2;
			this.stageLabel.Text = (num2 + 1).ToString() + "/15";
			this.stageLabel.Color = global::ARGBColors.Black;
			this.stageLabel.Position = new Point(372, 7);
			this.stageLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.stageLabel.Size = new Size(318, 58);
			this.stageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_RIGHT;
			this.background.addControl(this.stageLabel);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(this.background.Size.Width - 40, 0);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeTutorial), "TutorialPanel_close");
			this.background.addControl(this.closeButton);
			this.minimizeButton.ImageNorm = GFXLibrary.minimize_Normal;
			this.minimizeButton.ImageOver = GFXLibrary.minimize_Over;
			this.minimizeButton.Position = new Point(this.background.Size.Width - 40 - 40, 0);
			this.minimizeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(TutorialPanel.minimizeTutorial), "TutorialPanel_minimize");
			this.background.addControl(this.minimizeButton);
			bool flag = false;
			QuestsPanel2.Instance.downloadedQuestInfo = false;
			if (tutorialID != -100)
			{
				if (!this.hasCollectableReward())
				{
					this.advanceButton.ImageNorm = GFXLibrary.tutorial_button_normal;
					this.advanceButton.ImageOver = GFXLibrary.tutorial_button_over;
					this.advanceButton.Position = new Point(280, 169);
					this.advanceButton.Text.Text = SK.Text("QuestRewardPopup_Next", "Next");
					this.advanceButton.TextYOffset = -3;
					this.advanceButton.Text.Color = global::ARGBColors.White;
					this.advanceButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.advanceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.advanceTutorial), "TutorialPanel_advance");
					this.advanceButton.Visible = true;
					this.advanceButton.Enabled = this.isNextButtonAvailable(ref flag);
					this.background.addControl(this.advanceButton);
					this.collectRewardButton.Visible = false;
				}
				else
				{
					this.advanceButton.ImageNorm = GFXLibrary.tutorial_button_normal;
					this.advanceButton.ImageOver = GFXLibrary.tutorial_button_over;
					this.advanceButton.Position = new Point(380, 169);
					this.advanceButton.Text.Text = SK.Text("QuestRewardPopup_Next", "Next");
					this.advanceButton.TextYOffset = -3;
					this.advanceButton.Text.Color = global::ARGBColors.White;
					this.advanceButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.advanceButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.advanceTutorial), "TutorialPanel_advance");
					this.advanceButton.Visible = false;
					this.advanceButton.Enabled = false;
					this.background.addControl(this.advanceButton);
					this.collectRewardButton.ImageNorm = GFXLibrary.tutorial_button_normal;
					this.collectRewardButton.ImageOver = GFXLibrary.tutorial_button_over;
					this.collectRewardButton.Position = new Point(280, 169);
					this.collectRewardButton.Text.Text = SK.Text("QuestRewardPopup_Collect_Reward", "Collect Reward");
					this.collectRewardButton.TextYOffset = -3;
					this.collectRewardButton.Text.Color = global::ARGBColors.White;
					if (Program.mySettings.LanguageIdent == "fr")
					{
						this.collectRewardButton.Text.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
					}
					else
					{
						this.collectRewardButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					}
					this.collectRewardButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.collectReward), "TutorialPanel_collect_reward");
					this.collectRewardButton.Visible = true;
					if (tutorialID == -25)
					{
						this.collectRewardButton.Enabled = true;
					}
					else
					{
						this.collectRewardButton.Enabled = false;
					}
					this.background.addControl(this.collectRewardButton);
				}
			}
			else
			{
				this.cancelButton.ImageNorm = GFXLibrary.tutorial_button_normal;
				this.cancelButton.ImageOver = GFXLibrary.tutorial_button_over;
				this.cancelButton.Position = new Point(180, 169);
				this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
				this.cancelButton.TextYOffset = -3;
				this.cancelButton.Text.Color = global::ARGBColors.White;
				this.cancelButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.cancelButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.cancelTutorialQuit), "TutorialPanel_cancel");
				this.cancelButton.Visible = true;
				this.background.addControl(this.cancelButton);
				this.quitButton.ImageNorm = GFXLibrary.tutorial_button_normal;
				this.quitButton.ImageOver = GFXLibrary.tutorial_button_over;
				this.quitButton.Position = new Point(380, 169);
				this.quitButton.Text.Text = SK.Text("QuestRewardPopup_Exit_Tutorial", "Exit Tutorial");
				this.quitButton.TextYOffset = -3;
				this.quitButton.Text.Color = global::ARGBColors.White;
				this.quitButton.Text.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.quitButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.quitTutorial), "TutorialPanel_quit");
				this.quitButton.Visible = true;
				this.background.addControl(this.quitButton);
			}
			if (tutorialID == 104)
			{
				this.advanceButton.Text.Text = SK.Text("QuestRewardPopup_Complete_The_Tutorial", "Complete the Tutorial");
				if (Program.mySettings.LanguageIdent.ToLower() == "de")
				{
					this.advanceButton.Text.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				}
			}
			base.Invalidate();
			if (parent != null)
			{
				parent.Invalidate();
			}
			if (flag && !GameEngine.Instance.World.TutorialIsAdvancing())
			{
				this.advanceTutorial();
				return;
			}
			this.update();
		}

		// Token: 0x06002B94 RID: 11156 RVA: 0x00225A78 File Offset: 0x00223C78
		public void advanceTutorial()
		{
			GameEngine.Instance.World.advanceTutorial();
			if (GameEngine.Instance.World.getTutorialStage() == 104)
			{
				int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
				Point villageLocation = GameEngine.Instance.World.getVillageLocation(selectedMenuVillage);
				InterfaceMgr.Instance.changeTab(0);
				GameEngine.Instance.World.startMultiStageZoom(10000.0, (double)villageLocation.X, (double)villageLocation.Y);
				InterfaceMgr.Instance.selectTutorialArmy();
				this.collectRewardButton.Visible = false;
				this.advanceButton.Visible = false;
			}
		}

		// Token: 0x06002B95 RID: 11157 RVA: 0x00225B18 File Offset: 0x00223D18
		public static void minimizeTutorial()
		{
			TutorialArrowWindow tutorialArrowWindow = InterfaceMgr.Instance.getTutorialArrowWindow();
			if (tutorialArrowWindow != null && TutorialArrowWindow.lastParent == TutorialPanel.m_parent)
			{
				InterfaceMgr.Instance.closeTutorialArrowWindow();
			}
			InterfaceMgr.Instance.closeTutorialWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06002B96 RID: 11158 RVA: 0x0002005F File Offset: 0x0001E25F
		public void cancelTutorialQuit()
		{
			this.setText(this.preClosingTutorialID, TutorialPanel.m_parent, true);
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x00225B74 File Offset: 0x00223D74
		public void quitTutorial()
		{
			GameEngine.Instance.World.endTutorial();
			InterfaceMgr.Instance.closeTutorialWindow();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
			InterfaceMgr.Instance.closeTutorialArrowWindow();
		}

		// Token: 0x06002B98 RID: 11160 RVA: 0x00020073 File Offset: 0x0001E273
		public void closeTutorial()
		{
			this.preClosingTutorialID = this.lastTutorialID;
			this.setText(-100, TutorialPanel.m_parent, true);
		}

		// Token: 0x06002B99 RID: 11161 RVA: 0x00225BC4 File Offset: 0x00223DC4
		public void collectReward()
		{
			PizzazzPopupWindow.closePizzazz();
			this.collectRewardButton.Visible = false;
			int tutorialQuest = Tutorials.getTutorialQuest(GameEngine.Instance.World.getTutorialStage());
			QuestsPanel2.Instance.completeQuest(tutorialQuest);
		}

		// Token: 0x06002B9A RID: 11162 RVA: 0x00225C04 File Offset: 0x00223E04
		public void update()
		{
			bool flag = false;
			if (!this.isNextButtonAvailable(ref flag))
			{
				this.advanceButton.Enabled = false;
				this.collectRewardButton.Enabled = false;
				this.updateTutorialArrow();
				return;
			}
			if (this.hasCollectableReward())
			{
				if (!this.advanceButton.Enabled && !this.collectRewardButton.Enabled)
				{
					if (!QuestsPanel2.Instance.downloadedQuestInfo)
					{
						int tutorialStage = GameEngine.Instance.World.getTutorialStage();
						if ((tutorialStage != 7 || (GameEngine.Instance.World.getRank() > 0 && !RankingsPanel.animating)) && !QuestsPanel2.Instance.downloadingQuestInfo)
						{
							QuestsPanel2.Instance.downloadQuestInfo();
						}
					}
					else
					{
						int tutorialQuest = Tutorials.getTutorialQuest(GameEngine.Instance.World.getTutorialStage());
						this.collectRewardButton.Enabled = QuestsPanel2.Instance.isRewardAvailable(tutorialQuest);
						if (!this.collectRewardButton.Enabled && !GameEngine.Instance.World.TutorialIsAdvancing())
						{
							this.advanceTutorial();
						}
						else if (this.collectRewardButton.Enabled)
						{
							this.replaceWithRewardText();
						}
					}
				}
				else
				{
					bool enabled = this.collectRewardButton.Enabled;
					int tutorialQuest2 = Tutorials.getTutorialQuest(GameEngine.Instance.World.getTutorialStage());
					this.collectRewardButton.Enabled = QuestsPanel2.Instance.isRewardAvailable(tutorialQuest2);
					if (!this.collectRewardButton.Enabled && !GameEngine.Instance.World.TutorialIsAdvancing())
					{
						this.advanceTutorial();
					}
					else if (this.collectRewardButton.Enabled && !enabled)
					{
						this.replaceWithRewardText();
					}
				}
			}
			else
			{
				this.advanceButton.Enabled = true;
				if (flag && !GameEngine.Instance.World.TutorialIsAdvancing())
				{
					this.advanceTutorial();
				}
			}
			if (this.advanceButton.Enabled)
			{
				if (InterfaceMgr.Instance.ParentForm.WindowState != FormWindowState.Maximized)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(this.advanceButton.Position.X + this.advanceButton.Width / 2 + this.background.Position.X, this.advanceButton.Position.Y + this.advanceButton.Height + this.background.Position.Y - 5), AnchorStyles.Top | AnchorStyles.Left, TutorialPanel.m_parent);
					return;
				}
				TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(this.advanceButton.Position.X + this.background.Position.X - 5, this.advanceButton.Position.Y + this.advanceButton.Height / 2 + this.background.Position.Y - 1), AnchorStyles.Top | AnchorStyles.Left, TutorialPanel.m_parent);
				return;
			}
			else
			{
				if (!this.collectRewardButton.Enabled)
				{
					InterfaceMgr.Instance.closeTutorialArrowWindow();
					return;
				}
				if (InterfaceMgr.Instance.ParentForm.WindowState != FormWindowState.Maximized)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(this.collectRewardButton.Position.X + this.collectRewardButton.Width / 2 + this.background.Position.X, this.collectRewardButton.Position.Y + this.collectRewardButton.Height + this.background.Position.Y - 5), AnchorStyles.Top | AnchorStyles.Left, TutorialPanel.m_parent);
					return;
				}
				TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(this.collectRewardButton.Position.X + this.background.Position.X - 5, this.collectRewardButton.Position.Y + this.collectRewardButton.Height / 2 + this.background.Position.Y - 1), AnchorStyles.Top | AnchorStyles.Left, TutorialPanel.m_parent);
				return;
			}
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void closing()
		{
		}

		// Token: 0x06002B9C RID: 11164 RVA: 0x00226014 File Offset: 0x00224214
		public bool isNextButtonAvailable(ref bool autoAdvance)
		{
			autoAdvance = false;
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			switch (tutorialStage)
			{
			case 1:
				return true;
			case 2:
				if (GameEngine.Instance.Village != null)
				{
					bool flag = GameEngine.Instance.Village.allowTutorialAdvance();
					if (flag)
					{
						autoAdvance = true;
					}
					return flag;
				}
				return false;
			case 3:
				return GameEngine.Instance.Village != null && GameEngine.Instance.Village.allowTutorialAdvance();
			case 4:
			case 9:
				break;
			case 5:
				return GameEngine.Instance.World.UserResearchData.Research_Arts > 1;
			case 6:
			{
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE && GameEngine.Instance.Village != null && InterfaceMgr.Instance.isVillageHonourTabOpen())
				{
					return true;
				}
				int tutorialQuest = Tutorials.getTutorialQuest(GameEngine.Instance.World.getTutorialStage());
				return QuestsPanel2.Instance.isQuestComplete(tutorialQuest);
			}
			case 7:
				return GameEngine.Instance.World.getRank() > 0;
			case 8:
				return GameEngine.Instance.World.isQuestObjectiveComplete(7);
			case 10:
			{
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_CASTLE && GameEngine.Instance.Castle != null)
				{
					return true;
				}
				int tutorialQuest2 = Tutorials.getTutorialQuest(GameEngine.Instance.World.getTutorialStage());
				return QuestsPanel2.Instance.isQuestComplete(tutorialQuest2);
			}
			case 11:
				return GameEngine.Instance.Castle != null && GameEngine.Instance.Castle.isTutorialEnclosedComplete();
			case 12:
				return GameEngine.Instance.World.isQuestObjectiveComplete(11);
			default:
				switch (tutorialStage)
				{
				case 100:
					if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
					{
						autoAdvance = true;
						return true;
					}
					return false;
				case 101:
					return GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_QUESTS && GameEngine.Instance.World.isQuestComplete(1);
				case 102:
					return GameEngine.Instance.World.isQuestObjectiveComplete(13);
				case 103:
					return GameEngine.Instance.World.isQuestObjectiveComplete(14);
				case 104:
					return true;
				case 105:
					return true;
				case 110:
					return true;
				}
				break;
			}
			return false;
		}

		// Token: 0x06002B9D RID: 11165 RVA: 0x00226264 File Offset: 0x00224464
		public bool hasCollectableReward()
		{
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			switch (tutorialStage)
			{
			case 2:
			case 3:
			case 5:
			case 6:
			case 7:
			case 8:
			case 10:
			case 11:
			case 12:
				break;
			case 4:
			case 9:
				return false;
			default:
				if (tutorialStage - 102 > 1)
				{
					return false;
				}
				break;
			}
			return true;
		}

		// Token: 0x06002B9E RID: 11166 RVA: 0x002262C0 File Offset: 0x002244C0
		public void invisiUpdate()
		{
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			if (tutorialStage - 2 <= 1 || tutorialStage == 11)
			{
				this.updateTutorialArrow();
			}
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x002262F0 File Offset: 0x002244F0
		public void updateTutorialArrow()
		{
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			switch (tutorialStage)
			{
			case -1:
				goto IL_90D;
			case 0:
			case 4:
			case 9:
				return;
			case 1:
				break;
			case 2:
			{
				if ((GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE && GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE) || InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (InterfaceMgr.Instance.getVillageTabBar().getCurrentTab() != 0)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(381, 121), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (!InterfaceMgr.Instance.isVillageMapPanelOnFoodTab())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(94, 226 + InterfaceMgr.Instance.getVillageMapPanelBuildTabPos() - 55), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				bool flag = true;
				if (GameEngine.Instance.Village != null && GameEngine.Instance.Village.findBuildingTypeIncludingConstructing(13) != null)
				{
					flag = false;
				}
				if (flag)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(57, 301), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			}
			case 3:
			{
				if ((GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE && GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE) || InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (InterfaceMgr.Instance.getVillageTabBar().getCurrentTab() != 0)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(381, 121), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (!InterfaceMgr.Instance.isVillageMapPanelOnIndustryTab())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(131, 226 + InterfaceMgr.Instance.getVillageMapPanelBuildTabPos() - 55), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				bool flag2 = true;
				bool flag3 = false;
				if (GameEngine.Instance.Village != null && GameEngine.Instance.Village.findBuildingTypeIncludingConstructing(6) != null)
				{
					flag2 = false;
					if (GameEngine.Instance.Village.findBuildingType(6) != null && GameEngine.Instance.Village.findBuildingTypeIncludingConstructing(7) == null)
					{
						flag3 = true;
					}
				}
				if (flag2)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(57, 301), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (flag3)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(141, 397), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			}
			case 5:
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_RESEARCH)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(278, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (ResearchPanel.TUTORIAL_artsTabPos < -9999)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(605, 334), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (GameEngine.Instance.World.UserResearchData.researchingType < 0)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(42, 370 + ResearchPanel.TUTORIAL_artsTabPos), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			case 6:
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE || InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (!InterfaceMgr.Instance.isVillageHonourTabOpen())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(195, 151 + InterfaceMgr.Instance.getVillageMapPanelHonourTabPos()), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			case 7:
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_RANKINGS)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(228, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(872, 137), AnchorStyles.None, InterfaceMgr.Instance.ParentForm);
				return;
			case 8:
			{
				if (!InterfaceMgr.Instance.isCardPopupOpen())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(InterfaceMgr.Instance.getTopLeftMenu().getCardAreaXPos() + 87, 80), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (InterfaceMgr.Instance.isConfirmPlayCardPopup())
				{
					ConfirmPlayCardPopup confirmPlayCardPopup = InterfaceMgr.Instance.getConfirmPlayCardPopup();
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(300, 340), AnchorStyles.Top | AnchorStyles.Left, confirmPlayCardPopup);
					return;
				}
				PlayCardsWindow playCardsWindow = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
				if (playCardsWindow != null)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(105, 293), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			}
			case 10:
				if ((GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE && GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE) || InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(331, 121), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				return;
			case 11:
				if ((GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE && GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE) || InterfaceMgr.Instance.isSelectedVillageACapital())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_CASTLE)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(331, 121), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (GameEngine.Instance.Castle.InBuilderMode)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(140, 685), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (!InterfaceMgr.Instance.TUTORIAL_openedWoodTab())
				{
					GameEngine.Instance.Castle.tutorialAutoPlace();
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(120, 174), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				}
				TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(138, 264), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
				return;
			case 12:
			{
				if (!InterfaceMgr.Instance.isCardPopupOpen())
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(InterfaceMgr.Instance.getTopLeftMenu().getCardAreaXPos() + 87, 80), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
					return;
				}
				if (InterfaceMgr.Instance.isConfirmPlayCardPopup())
				{
					ConfirmPlayCardPopup confirmPlayCardPopup2 = InterfaceMgr.Instance.getConfirmPlayCardPopup();
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(300, 340), AnchorStyles.Top | AnchorStyles.Left, confirmPlayCardPopup2);
					return;
				}
				PlayCardsWindow playCardsWindow2 = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
				GameEngine.Instance.cardsManager.countPlayableCardsInCardSection(0);
				if (playCardsWindow2 != null)
				{
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(105, 293), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow2);
					return;
				}
				InterfaceMgr.Instance.closeTutorialArrowWindow();
				return;
			}
			default:
				switch (tutorialStage)
				{
				case 100:
					break;
				case 101:
					if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_QUESTS)
					{
						TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(177, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
						return;
					}
					TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(QuestsPanel2.questXPos + 649 + 230 - 12, 208), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
					return;
				case 102:
				{
					if (!InterfaceMgr.Instance.isCardPopupOpen())
					{
						TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(InterfaceMgr.Instance.getTopLeftMenu().getCardAreaXPos() + 87, 80), AnchorStyles.Top | AnchorStyles.Left, InterfaceMgr.Instance.ParentForm);
						return;
					}
					PlayCardsWindow playCardsWindow3 = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
					if (playCardsWindow3 == null)
					{
						return;
					}
					if (!playCardsWindow3.isCardWindowOnManage())
					{
						if (GameEngine.Instance.World.isBigpointAccount || Program.bigpointInstall || Program.aeriaInstall || Program.bigpointPartnerInstall)
						{
							TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(813, 151), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow3);
							return;
						}
						TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(813, 206), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow3);
						return;
					}
					else
					{
						if (playCardsWindow3.CardPanelManage.PanelMode == ManageCardsPanel.PANEL_MODE_CASH)
						{
							TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(740, 70), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow3);
							return;
						}
						if (!playCardsWindow3.CardPanelManage.TUTORIAL_cardsInCart())
						{
							TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(92, 459), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow3);
							return;
						}
						TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(627, 170), AnchorStyles.Top | AnchorStyles.Left, playCardsWindow3);
						return;
					}
					break;
				}
				case 103:
					if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE)
					{
						TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
						return;
					}
					if (!InterfaceMgr.Instance.isVillageMapPanelOnPopularityBar())
					{
						TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(200, 150), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
						return;
					}
					TutorialArrowWindow.CreateTutorialArrowWindow(false, new Point(64, 203), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
					return;
				case 104:
					goto IL_90D;
				case 105:
					InterfaceMgr.Instance.closeTutorialArrowWindow();
					return;
				default:
					return;
				}
				break;
			}
			if (GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_VILLAGE)
			{
				TutorialArrowWindow.CreateTutorialArrowWindow(true, new Point(382, 85), AnchorStyles.Top | AnchorStyles.Right, InterfaceMgr.Instance.ParentForm);
				return;
			}
			InterfaceMgr.Instance.closeTutorialArrowWindow();
			return;
			IL_90D:
			InterfaceMgr.Instance.closeTutorialArrowWindow();
		}

		// Token: 0x06002BA0 RID: 11168 RVA: 0x0002008F File Offset: 0x0001E28F
		public static void logout()
		{
			TutorialPanel.shownPizzazz.Clear();
			InterfaceMgr.Instance.closeTutorialWindow();
			InterfaceMgr.Instance.closeTutorialArrowWindow();
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x00226C14 File Offset: 0x00224E14
		public void replaceWithRewardText()
		{
			this.headerLabel.Text = SK.Text("QuestRewardPopup_Reward", "Reward");
			int tutorialStage = GameEngine.Instance.World.getTutorialStage();
			int tutorialQuest = Tutorials.getTutorialQuest(tutorialStage);
			List<Quests.QuestReward> questRewards = Quests.getQuestRewards(tutorialQuest, true, GameEngine.NFI);
			string text = "";
			bool flag = true;
			foreach (Quests.QuestReward questReward in questRewards)
			{
				if (!flag)
				{
					text += ", ";
				}
				else
				{
					flag = false;
				}
				text += questReward.explanation;
			}
			this.rewardLabel.Text = text;
			this.bodyLabel.Text = Environment.NewLine + Tutorials.getTutorialRewardText(tutorialStage);
			this.bodyLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
			if (this.bodyLabel.TextSize.Height > 120)
			{
				this.bodyLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			}
			this.illustration.Image = null;
			switch (tutorialStage)
			{
			case 0:
				this.advisor.Image = GFXLibrary.tutorial_longarm3;
				break;
			case 1:
			case 4:
			case 9:
				break;
			case 2:
				this.advisor.Image = GFXLibrary.tutorial_longarm5;
				break;
			case 3:
				this.advisor.Image = GFXLibrary.tutorial_longarm3;
				break;
			case 5:
				this.advisor.Image = GFXLibrary.tutorial_longarm12;
				break;
			case 6:
				this.advisor.Image = GFXLibrary.tutorial_longarm12;
				break;
			case 7:
				this.advisor.Image = GFXLibrary.tutorial_longarm4;
				break;
			case 8:
				this.advisor.Image = GFXLibrary.tutorial_longarm12;
				break;
			case 10:
				this.advisor.Image = GFXLibrary.tutorial_longarm12;
				break;
			case 11:
				this.advisor.Image = GFXLibrary.tutorial_longarm1;
				break;
			case 12:
				this.advisor.Image = GFXLibrary.tutorial_longarm7;
				break;
			default:
				switch (tutorialStage)
				{
				case 100:
					this.advisor.Image = GFXLibrary.tutorial_longarm2;
					break;
				case 102:
					this.advisor.Image = GFXLibrary.tutorial_longarm12;
					break;
				case 103:
					this.advisor.Image = GFXLibrary.tutorial_longarm7;
					break;
				case 104:
					this.advisor.Image = GFXLibrary.tutorial_longarm7;
					break;
				case 105:
					this.advisor.Image = GFXLibrary.tutorial_longarm1;
					break;
				}
				break;
			}
			if (!TutorialPanel.shownPizzazz.Contains(tutorialStage))
			{
				PizzazzPopupWindow.showPizzazzTutorial(tutorialStage);
				TutorialPanel.shownPizzazz.Add(tutorialStage);
			}
		}

		// Token: 0x04003623 RID: 13859
		private const int EXTRA_WIDTH = 110;

		// Token: 0x04003624 RID: 13860
		private IContainer components;

		// Token: 0x04003625 RID: 13861
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003626 RID: 13862
		private CustomSelfDrawPanel.CSDLabel bodyLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003627 RID: 13863
		private CustomSelfDrawPanel.CSDLabel rewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003628 RID: 13864
		private CustomSelfDrawPanel.CSDButton advanceButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003629 RID: 13865
		private CustomSelfDrawPanel.CSDButton continueButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400362A RID: 13866
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400362B RID: 13867
		private CustomSelfDrawPanel.CSDButton minimizeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400362C RID: 13868
		private CustomSelfDrawPanel.CSDButton collectRewardButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x0400362D RID: 13869
		private CustomSelfDrawPanel.CSDImage background = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x0400362E RID: 13870
		private CustomSelfDrawPanel.CSDFill transparentBackground = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x0400362F RID: 13871
		private CustomSelfDrawPanel.CSDImage advisor = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003630 RID: 13872
		private CustomSelfDrawPanel.CSDImage illustration = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04003631 RID: 13873
		private CustomSelfDrawPanel.CSDButton quitButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003632 RID: 13874
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04003633 RID: 13875
		private CustomSelfDrawPanel.CSDLabel stageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04003634 RID: 13876
		private int lastTutorialID = -1;

		// Token: 0x04003635 RID: 13877
		private static Form m_parent = null;

		// Token: 0x04003636 RID: 13878
		private int lastStageID;

		// Token: 0x04003637 RID: 13879
		private int preClosingTutorialID = -6;

		// Token: 0x04003638 RID: 13880
		private static List<int> shownPizzazz = new List<int>();
	}
}
