using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;

namespace Kingdoms
{
	// Token: 0x02000259 RID: 601
	public class NewQuestsPanel : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001A62 RID: 6754 RVA: 0x0001A6D1 File Offset: 0x000188D1
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x0001A6E1 File Offset: 0x000188E1
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x0001A6F1 File Offset: 0x000188F1
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x0001A703 File Offset: 0x00018903
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x0001A710 File Offset: 0x00018910
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x0001A72A File Offset: 0x0001892A
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x0001A737 File Offset: 0x00018937
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x0001A744 File Offset: 0x00018944
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x001A08C4 File Offset: 0x0019EAC4
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
			base.Size = new Size(992, 566);
			base.Name = "NewQuestsPanel";
			base.ResumeLayout(false);
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x001A09B0 File Offset: 0x0019EBB0
		public NewQuestsPanel()
		{
			NewQuestsPanel.Instance = this;
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x001A0B04 File Offset: 0x0019ED04
		public void init(bool resized)
		{
			int height = base.Height;
			NewQuestsPanel.Instance = this;
			base.clearControls();
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			CustomSelfDrawPanel.WikiLinkControl.init(this.headerImage, 19, new Point(base.Width - 44, 3));
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.underlayImage.Image = GFXLibrary.quest_screen_warm;
			this.underlayImage.Position = new Point(6, 0);
			this.backgroundImage.addControl(this.underlayImage);
			this.questImage.Image = GFXLibrary.quest_screen_top;
			this.questImage.Position = new Point(21, 18);
			this.backgroundImage.addControl(this.questImage);
			this.parishNameLabel.Text = SK.Text("QuestPanel_Quests", "Quests");
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.questsScrollArea.Position = new Point(40, 230);
			this.questsScrollArea.Size = new Size(880, height - 230 - 20 - 40);
			this.questsScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(880, height - 230 - 20 - 40));
			this.backgroundImage.addControl(this.questsScrollArea);
			this.insetImage.Position = new Point(21, 220);
			this.insetImage.Size = new Size(947, height - 230 - 20 - 40 + 20);
			this.backgroundImage.addControl(this.insetImage);
			this.insetImage.Create(GFXLibrary.quest_9sclice_grey_inset_top_left, GFXLibrary.quest_9sclice_grey_inset_top_mid, GFXLibrary.quest_9sclice_grey_inset_top_right, GFXLibrary.quest_9sclice_grey_inset_mid_left, GFXLibrary.quest_9sclice_grey_inset_mid_mid, GFXLibrary.quest_9sclice_grey_inset_mid_right, GFXLibrary.quest_9sclice_grey_inset_bottom_left, GFXLibrary.quest_9sclice_grey_inset_bottom_mid, GFXLibrary.quest_9sclice_grey_inset_bottom_right);
			int value = this.questsScrollBar.Value;
			this.questsScrollBar.Position = new Point(930, 230);
			this.questsScrollBar.Size = new Size(24, height - 230 - 20 - 40);
			this.backgroundImage.addControl(this.questsScrollBar);
			this.questsScrollBar.Value = 0;
			this.questsScrollBar.Max = 100;
			this.questsScrollBar.NumVisibleLines = 25;
			this.questsScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.questsScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.mouseWheelOverlay.Position = this.questsScrollArea.Position;
			this.mouseWheelOverlay.Size = this.questsScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.backgroundImage.addControl(this.mouseWheelOverlay);
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData != null && newQuestData.questID >= 0)
			{
				int num = 0;
				int num2 = 1;
				int num3 = 0;
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(newQuestData.questID);
				NewQuestsPanel.addRewardIcons(this.questImage, new Point(170, 75), newQuestDef, 1);
				this.questIcon.Image = GFXLibrary.quest_icons[Math.Min(newQuestDef.questType, GFXLibrary.quest_icons.Length - 1)];
				this.questIcon.Position = new Point(170, 16);
				this.questImage.addControl(this.questIcon);
				this.lblQuestName.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef.tagString);
				this.lblQuestName.Color = global::ARGBColors.Black;
				this.lblQuestName.Position = new Point(220, 19);
				this.lblQuestName.Size = new Size(700, 30);
				this.lblQuestName.Font = FontManager.GetFont("Arial", 13f, FontStyle.Bold);
				this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.questImage.addControl(this.lblQuestName);
				NumberFormatInfo nfi = GameEngine.NFI;
				this.lblQuestDescription.Text = SK.Text("QUEST_PANEL_DESCRIPTION_OBJECTIVE", "Objective");
				CustomSelfDrawPanel.CSDLabel csdlabel = this.lblQuestDescription;
				csdlabel.Text += " - ";
				int questID = newQuestData.questID;
				if (questID <= 48)
				{
					if (questID <= 16)
					{
						if (questID != 4 && questID != 16)
						{
							goto IL_66C;
						}
					}
					else if (questID != 34 && questID != 48)
					{
						goto IL_66C;
					}
				}
				else if (questID <= 84)
				{
					if (questID != 64 && questID != 84)
					{
						goto IL_66C;
					}
				}
				else if (questID != 101 && questID != 122)
				{
					goto IL_66C;
				}
				CustomSelfDrawPanel.CSDLabel csdlabel2 = this.lblQuestDescription;
				csdlabel2.Text += SK.Text("QUESTS_Spread_New_description", "Learn about Invite a Friend");
				goto IL_6ED;
				IL_66C:
				if (newQuestDef.parameter > 0)
				{
					CustomSelfDrawPanel.CSDLabel csdlabel3 = this.lblQuestDescription;
					csdlabel3.Text = csdlabel3.Text + SK.NoStoreText("Z_QUEST_DESCRIPTIONS_" + newQuestDef.tagString) + " : " + newQuestDef.parameter.ToString("N", nfi);
				}
				else
				{
					CustomSelfDrawPanel.CSDLabel csdlabel4 = this.lblQuestDescription;
					csdlabel4.Text += SK.NoStoreText("Z_QUEST_DESCRIPTIONS_" + newQuestDef.tagString);
				}
				IL_6ED:
				this.lblQuestDescription.Color = global::ARGBColors.Black;
				this.lblQuestDescription.RolloverColor = global::ARGBColors.White;
				this.lblQuestDescription.Position = new Point(220, 42);
				this.lblQuestDescription.Size = new Size(740, 50);
				this.lblQuestDescription.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
				this.lblQuestDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.lblQuestDescription.Data = newQuestData.questID;
				this.lblQuestDescription.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.OpenFurtherInformation));
				this.lblQuestDescription.Tag = newQuestDef.tagString;
				this.questImage.addControl(this.lblQuestDescription);
				if (newQuestData.completionState >= 0 && QuestsHelper.isQuestComplete(newQuestData) && !GameEngine.Instance.World.WorldEnded)
				{
					this.completeGlow2.Image = GFXLibrary.quest_button_glow;
					this.completeGlow2.Position = new Point(632, 132);
					this.completeGlow2.Alpha = 1f;
					this.questImage.addControl(this.completeGlow2);
					this.completeGlow.Image = GFXLibrary.quest_button_glow;
					this.completeGlow.Position = new Point(632, 132);
					this.completeGlow.Alpha = 1f;
					this.questImage.addControl(this.completeGlow);
					this.glowValue = 0;
					this.abandonButton.Enabled = false;
					this.completeButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
					this.completeButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.completeButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
					this.completeButton.Position = new Point(648, 149);
					this.completeButton.Text.Text = SK.Text("QUESTS_Complete", "Complete");
					this.completeButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.completeButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.completeButton.TextYOffset = -3;
					this.completeButton.Text.Color = global::ARGBColors.Black;
					this.completeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.completeQuest), "NewQuests_Complete_Clicked");
					this.completeButton.Enabled = true;
					this.questImage.addControl(this.completeButton);
					int questID2 = newQuestData.questID;
					if (questID2 <= 67)
					{
						if (questID2 <= 29)
						{
							if (questID2 != 5 && questID2 != 20)
							{
								if (questID2 != 29)
								{
									goto IL_A41;
								}
								num2 = (num = 4);
								goto IL_A4C;
							}
						}
						else if (questID2 != 42)
						{
							if (questID2 == 66)
							{
								num2 = (num = 6);
								goto IL_A4C;
							}
							if (questID2 != 67)
							{
								goto IL_A41;
							}
						}
					}
					else if (questID2 <= 140)
					{
						if (questID2 != 99 && questID2 != 125 && questID2 != 140)
						{
							goto IL_A41;
						}
					}
					else if (questID2 <= 148)
					{
						if (questID2 == 146)
						{
							num2 = (num = 8);
							goto IL_A4C;
						}
						if (questID2 != 148)
						{
							goto IL_A41;
						}
					}
					else if (questID2 != 157 && questID2 != 167)
					{
						goto IL_A41;
					}
					num2 = (num = newQuestDef.parameter);
					goto IL_A4C;
					IL_A41:
					num2 = (num = newQuestDef.parameter);
					IL_A4C:
					if (num2 == 0)
					{
						num = (num2 = 1);
					}
					num3 = num;
				}
				else
				{
					this.abandonButton.Enabled = true;
					if (GameEngine.Instance.World.WorldEnded)
					{
						this.abandonButton.Enabled = false;
					}
					if (newQuestDef.parameter > 0 || newQuestData.questID == 66 || newQuestData.questID == 146 || newQuestData.questID == 29)
					{
						int questID3 = newQuestData.questID;
						if (questID3 <= 67)
						{
							if (questID3 <= 20)
							{
								if (questID3 <= 5)
								{
									if (questID3 == 4)
									{
										goto IL_C4D;
									}
									if (questID3 != 5)
									{
										goto IL_C62;
									}
								}
								else
								{
									if (questID3 == 16)
									{
										goto IL_C4D;
									}
									if (questID3 != 20)
									{
										goto IL_C62;
									}
								}
							}
							else if (questID3 <= 34)
							{
								if (questID3 == 29)
								{
									num = QuestsHelper.bitCount(newQuestData.data);
									num2 = 4;
									num3 = num;
									goto IL_C75;
								}
								if (questID3 != 34)
								{
									goto IL_C62;
								}
								goto IL_C4D;
							}
							else if (questID3 != 42)
							{
								if (questID3 == 48)
								{
									goto IL_C4D;
								}
								switch (questID3)
								{
								case 64:
									goto IL_C4D;
								case 65:
									goto IL_C62;
								case 66:
									num = QuestsHelper.bitCount(newQuestData.data);
									num2 = 6;
									num3 = num;
									goto IL_C75;
								case 67:
									break;
								default:
									goto IL_C62;
								}
							}
						}
						else if (questID3 <= 125)
						{
							if (questID3 <= 99)
							{
								if (questID3 == 84)
								{
									goto IL_C4D;
								}
								if (questID3 != 99)
								{
									goto IL_C62;
								}
							}
							else
							{
								if (questID3 == 101 || questID3 == 122)
								{
									goto IL_C4D;
								}
								if (questID3 != 125)
								{
									goto IL_C62;
								}
							}
						}
						else if (questID3 <= 146)
						{
							if (questID3 != 140)
							{
								if (questID3 != 146)
								{
									goto IL_C62;
								}
								num = QuestsHelper.bitCount(newQuestData.data);
								num2 = 8;
								num3 = num;
								goto IL_C75;
							}
						}
						else if (questID3 != 148 && questID3 != 157 && questID3 != 167)
						{
							goto IL_C62;
						}
						double currentGold = GameEngine.Instance.World.getCurrentGold();
						double num4 = currentGold - (double)newQuestData.startingData;
						num3 = (int)num4;
						if (num4 < 0.0)
						{
							num4 = 0.0;
						}
						num = (int)num4;
						num2 = newQuestDef.parameter;
						goto IL_C75;
						IL_C4D:
						num = newQuestData.data;
						num2 = newQuestDef.parameter;
						num3 = num;
						goto IL_C75;
						IL_C62:
						num = newQuestData.data;
						num2 = newQuestDef.parameter;
						num3 = num;
					}
				}
				IL_C75:
				this.questProgressBar.Position = new Point(162, 124);
				this.questProgressBar.Size = new Size(766, 22);
				this.questProgressBar.Offset = new Point(0, 0);
				this.questImage.addControl(this.questProgressBar);
				this.questProgressBar.Create(null, null, null, GFXLibrary.quest_screen_progbar_left, GFXLibrary.quest_screen_progbar_mid, GFXLibrary.quest_screen_progbar_right);
				this.questProgressBar.setValues((double)num, (double)num2);
				this.progressTextLabel.Text = num3.ToString("N", nfi) + " / " + num2.ToString("N", nfi);
				this.progressTextLabel.Color = global::ARGBColors.White;
				this.progressTextLabel.Position = new Point(0, -1);
				this.progressTextLabel.Size = new Size(this.questProgressBar.Width, this.questProgressBar.Height);
				this.progressTextLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
				this.progressTextLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.questProgressBar.addControl(this.progressTextLabel);
				this.abandonButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.abandonButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.abandonButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.abandonButton.Position = new Point(798, 149);
				this.abandonButton.Text.Text = SK.Text("QUESTS_Abandon", "Abandon");
				this.abandonButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.abandonButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.abandonButton.TextYOffset = -3;
				this.abandonButton.Text.Color = global::ARGBColors.Black;
				this.abandonButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.abandonQuest), "NewQuests_Abandon_Started_Quest_Clicked");
				this.abandonButton.Enabled = true;
				this.questImage.addControl(this.abandonButton);
				int questID4 = newQuestData.questID;
				if (questID4 <= 48)
				{
					if (questID4 <= 16)
					{
						if (questID4 != 4 && questID4 != 16)
						{
							goto IL_FD4;
						}
					}
					else if (questID4 != 34 && questID4 != 48)
					{
						goto IL_FD4;
					}
				}
				else if (questID4 <= 84)
				{
					if (questID4 != 64 && questID4 != 84)
					{
						goto IL_FD4;
					}
				}
				else if (questID4 != 101 && questID4 != 122)
				{
					goto IL_FD4;
				}
				if (!GameEngine.Instance.World.isBigpointAccount && !Program.aeriaInstall && !Program.bigpointPartnerInstall && !Program.arcInstall)
				{
					CustomSelfDrawPanel.CSDButton csdbutton = new CustomSelfDrawPanel.CSDButton();
					csdbutton.ImageNorm = GFXLibrary.banner_ad_friend_quest;
					csdbutton.OverBrighten = true;
					csdbutton.Position = new Point(152, 5);
					csdbutton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.friendClicked), "LogoutPanel_invite_a_friend");
					this.questImage.addControl(csdbutton);
					this.lblQuestDescription.Text = "";
					this.lblQuestName.Text = "";
				}
				else
				{
					this.lblQuestDescription.Text = SK.Text("QUESTS_Spread_New_description", "Learn about Invite a Friend");
				}
				IL_FD4:
				if (newQuestDef.timed > 0)
				{
					if (newQuestData.completionState == 0)
					{
						TimeSpan t = new TimeSpan(newQuestDef.timed, 0, 0);
						int secsLeft = (int)(t - (VillageMap.getCurrentServerTime() - newQuestData.startTime)).TotalSeconds;
						this.timeLeftLabel.Text = SK.Text("QUESTS_TimeRemaining", "Time Remaining") + " : " + VillageMap.createBuildTimeStringFull(secsLeft);
						this.timeLeftLabel.Color = global::ARGBColors.Black;
						this.timeLeftLabel.Position = new Point(170, 145);
						this.timeLeftLabel.Size = new Size(760, 50);
						this.timeLeftLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
						this.timeLeftLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						this.timeLeftLabel.Visible = true;
						this.questImage.addControl(this.timeLeftLabel);
					}
					else if (newQuestData.completionState < 0)
					{
						this.timeLeftLabel.Text = SK.Text("QUESTS_QuestFailed", "Quest Failed");
						this.timeLeftLabel.Color = global::ARGBColors.Black;
						this.timeLeftLabel.Position = new Point(170, 145);
						this.timeLeftLabel.Size = new Size(760, 50);
						this.timeLeftLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
						this.timeLeftLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
						this.timeLeftLabel.Visible = true;
						this.questImage.addControl(this.timeLeftLabel);
					}
				}
			}
			else
			{
				this.lblQuestName.Text = SK.Text("QUESTS_No_Active_Quest", "No Active Quest");
				this.lblQuestName.Color = global::ARGBColors.Black;
				this.lblQuestName.Position = new Point(170, 19);
				this.lblQuestName.Size = new Size(700, 30);
				this.lblQuestName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
				this.questImage.addControl(this.lblQuestName);
			}
			this.completedQuestsLabel.Text = SK.Text("QUESTS_CompletedQuests", "Completed Quests") + " : " + newQuestData.totalCompleted.ToString();
			this.completedQuestsLabel.Color = global::ARGBColors.Black;
			this.completedQuestsLabel.RolloverColor = global::ARGBColors.White;
			this.completedQuestsLabel.Position = new Point(170, 165);
			this.completedQuestsLabel.Size = new Size(460, 50);
			this.completedQuestsLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
			this.completedQuestsLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.completedQuestsLabel.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.showCompletedQuests));
			this.questImage.addControl(this.completedQuestsLabel);
			this.tutorialText.Text = SK.Text("Quest_Tutorial_Inprogress", "The Tutorial is currently in progress. Please finish or quit the Tutorial to access Quests.");
			this.tutorialText.Color = global::ARGBColors.Black;
			this.tutorialText.Position = this.questsScrollArea.Position;
			this.tutorialText.Size = this.questsScrollArea.Size;
			this.tutorialText.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.tutorialText.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
			this.questImage.addControl(this.tutorialText);
			if (!resized)
			{
				this.m_selectedQuest = -1;
				TimeSpan timeSpan = DateTime.Now - this.lastFullUpdateTime;
				RemoteServices.Instance.set_GetQuestData_UserCallBack(new RemoteServices.GetQuestData_UserCallBack(this.getQuestDataCallback));
				if (timeSpan.TotalMinutes > 1.0)
				{
					RemoteServices.Instance.GetQuestData(true);
				}
				else
				{
					RemoteServices.Instance.GetQuestData(false);
				}
			}
			this.rebuild(this.m_selectedQuest);
			if (resized)
			{
				this.questsScrollBar.Value = value;
				this.questsScrollBar.scrollDown(0);
				this.wallScrollBarMoved();
			}
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x0001A763 File Offset: 0x00018963
		private void getQuestDataCallback(GetQuestData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.setNewQuestData(returnData.m_newQuestsData);
				this.init(true);
				NewQuestsPanel.handleClientSideQuestReporting(true);
			}
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x0001A78F File Offset: 0x0001898F
		protected void startQuest(int questID)
		{
			RemoteServices.Instance.set_StartNewQuest_UserCallBack(new RemoteServices.StartNewQuest_UserCallBack(this.startNewQuestCallback));
			RemoteServices.Instance.StartNewQuest(questID);
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x0001A7B2 File Offset: 0x000189B2
		private void startNewQuestCallback(StartNewQuest_ReturnType returnData)
		{
			bool success = returnData.Success;
			if (returnData.m_newQuestsData != null)
			{
				GameEngine.Instance.World.setNewQuestData(returnData.m_newQuestsData);
				this.init(true);
			}
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x001A1F0C File Offset: 0x001A010C
		public void update()
		{
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData != null && newQuestData.questID >= 0 && newQuestData.completionState == 0)
			{
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(newQuestData.questID);
				if (newQuestDef.timed > 0)
				{
					TimeSpan t = new TimeSpan(newQuestDef.timed, 0, 0);
					int num = (int)(t - (VillageMap.getCurrentServerTime() - newQuestData.startTime)).TotalSeconds;
					if (num < 0)
					{
						num = 0;
					}
					this.timeLeftLabel.TextDiffOnly = SK.Text("QUESTS_TimeRemaining", "Time Remaining") + " : " + VillageMap.createBuildTimeStringFull(num);
				}
				else
				{
					this.timeLeftLabel.Visible = false;
				}
			}
			else if (newQuestData.completionState < 0)
			{
				this.timeLeftLabel.TextDiffOnly = SK.Text("QUESTS_QuestFailed", "Quest Failed");
				this.timeLeftLabel.Visible = true;
			}
			else
			{
				this.timeLeftLabel.Visible = false;
			}
			this.glowValue += 15;
			if (this.glowValue > 511)
			{
				this.glowValue -= 511;
			}
			int num2 = this.glowValue;
			if (num2 > 255)
			{
				num2 = 511 - num2;
			}
			this.completeGlow.Alpha = (float)num2 / 255f;
			this.completeGlow.invalidate();
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x001A2070 File Offset: 0x001A0270
		private void wallScrollBarMoved()
		{
			int value = this.questsScrollBar.Value;
			this.questsScrollArea.Position = new Point(this.questsScrollArea.X, 230 - value);
			this.questsScrollArea.ClipRect = new Rectangle(this.questsScrollArea.ClipRect.X, value, this.questsScrollArea.ClipRect.Width, this.questsScrollArea.ClipRect.Height);
			this.questsScrollArea.invalidate();
			this.questsScrollBar.invalidate();
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x0001A7DF File Offset: 0x000189DF
		private void mouseWheelMoved(int delta)
		{
			if (delta < 0)
			{
				this.questsScrollBar.scrollDown(40);
				return;
			}
			if (delta > 0)
			{
				this.questsScrollBar.scrollUp(40);
			}
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x001A210C File Offset: 0x001A030C
		private void windowDragged()
		{
			int num = -this.dragOverlay.YDiff;
			int width = this.questsScrollArea.Size.Width;
			int num2 = (int)((double)this.questsScrollArea.Size.Height);
			if (this.questsScrollArea.ClipRect.Y + num < 0)
			{
				num = -this.questsScrollArea.ClipRect.Y;
			}
			if (this.questsScrollArea.ClipRect.Y + num > num2 - this.questsScrollArea.ClipRect.Height)
			{
				num -= this.questsScrollArea.ClipRect.Y + num - (num2 - this.questsScrollArea.ClipRect.Height);
			}
			this.questsScrollArea.Position = new Point(this.questsScrollArea.Position.X, this.questsScrollArea.Position.Y - num);
			this.questsScrollArea.ClipRect = new Rectangle(this.questsScrollArea.ClipRect.X, this.questsScrollArea.ClipRect.Y + num, this.questsScrollArea.ClipRect.Width, this.questsScrollArea.ClipRect.Height);
			this.questsScrollArea.invalidate();
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x001A227C File Offset: 0x001A047C
		public void expandQuest(int quest)
		{
			this.m_selectedQuest = quest;
			int value = this.questsScrollBar.Value;
			this.rebuild(quest);
			this.questsScrollBar.Value = value;
		}

		// Token: 0x06001A76 RID: 6774 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x001A22B0 File Offset: 0x001A04B0
		private void completeQuest()
		{
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData != null)
			{
				InterfaceMgr.Instance.openNewQuestRewardPopup(newQuestData.questID, -1, this);
			}
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x0001A804 File Offset: 0x00018A04
		public void doCompleteQuest(int questID, int villageID, bool glory)
		{
			this.completeButton.Enabled = false;
			RemoteServices.Instance.set_CompleteAbandonNewQuest_UserCallBack(new RemoteServices.CompleteAbandonNewQuest_UserCallBack(this.completeAbandonNewQuestCallback));
			RemoteServices.Instance.CompleteNewQuest(questID, glory, villageID);
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x001A22E4 File Offset: 0x001A04E4
		private void abandonQuest()
		{
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData != null)
			{
				this.abandonButton.Enabled = false;
				RemoteServices.Instance.set_CompleteAbandonNewQuest_UserCallBack(new RemoteServices.CompleteAbandonNewQuest_UserCallBack(this.completeAbandonNewQuestCallback));
				RemoteServices.Instance.AbandonNewQuest(-1);
			}
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x0001A835 File Offset: 0x00018A35
		private void abandonQuest(int questID)
		{
			RemoteServices.Instance.set_CompleteAbandonNewQuest_UserCallBack(new RemoteServices.CompleteAbandonNewQuest_UserCallBack(this.completeAbandonNewQuestCallback));
			RemoteServices.Instance.AbandonNewQuest(questID);
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0001A858 File Offset: 0x00018A58
		private void restoreQuests()
		{
			RemoteServices.Instance.set_CompleteAbandonNewQuest_UserCallBack(new RemoteServices.CompleteAbandonNewQuest_UserCallBack(this.completeAbandonNewQuestCallback));
			RemoteServices.Instance.AbandonNewQuest(-2);
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x001A2334 File Offset: 0x001A0534
		private void completeAbandonNewQuestCallback(CompleteAbandonNewQuest_ReturnType returnData)
		{
			this.abandonButton.Enabled = true;
			if (returnData.Success)
			{
				if (returnData.goldGiven)
				{
					GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				}
				if (returnData.honourGiven)
				{
					GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				}
				if (returnData.fpGiven)
				{
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				}
				if (returnData.premiumCardsGiven)
				{
					CardTypes.PremiumToken premiumToken = new CardTypes.PremiumToken();
					premiumToken.Reward = 1;
					premiumToken.UserPremiumTokenID = returnData.premiumCardID;
					premiumToken.WorldID = RemoteServices.Instance.ProfileWorldID;
					premiumToken.Type = 4113;
					GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Add(returnData.premiumCardID, premiumToken);
				}
				if (returnData.cardPacksGiven > 0)
				{
					int num = 1;
					if (GameEngine.Instance.cardPackManager.ProfileUserCardPacks.ContainsKey(num))
					{
						CardTypes.UserCardPack userCardPack = GameEngine.Instance.cardPackManager.ProfileUserCardPacks[num];
						userCardPack.Count += returnData.cardPacksGiven;
					}
					else
					{
						CardTypes.UserCardPack userCardPack2 = new CardTypes.UserCardPack();
						userCardPack2.OfferID = num;
						userCardPack2.Count = returnData.cardPacksGiven;
						GameEngine.Instance.cardPackManager.ProfileUserCardPacks[num] = userCardPack2;
					}
				}
				if (returnData.gloryGiven)
				{
					GameEngine.Instance.World.clearGloryHistory();
				}
				if (returnData.villageUpdated >= 0)
				{
					GameEngine.Instance.flushVillage(returnData.villageUpdated);
				}
				if (returnData.ticketsGiven > 0)
				{
					GameEngine.Instance.World.addTickets(-1, returnData.ticketsGiven);
				}
			}
			else if (returnData.m_errorCode == ErrorCodes.ErrorCode.NEW_QUESTS_FAILED_REWARD)
			{
				MyMessageBox.Show(SK.Text("QUESTS_failed_reward_body", "We have been unable to give the correct reward for this quest, please wait a few minutes and try again. If this doesn't work, please contact support."), SK.Text("QUESTS_failed_reward", "Quest Reward Error"));
			}
			if (returnData.m_newQuestsData != null)
			{
				GameEngine.Instance.World.setNewQuestData(returnData.m_newQuestsData);
				this.init(true);
			}
		}

		// Token: 0x06001A7D RID: 6781 RVA: 0x0001A87C File Offset: 0x00018A7C
		private void showCompletedQuests()
		{
			InterfaceMgr.Instance.openNewQuestsCompletedPopup(null);
		}

		// Token: 0x06001A7E RID: 6782 RVA: 0x001A253C File Offset: 0x001A073C
		public void rebuild(int activeQuest)
		{
			bool allowStart = true;
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData == null)
			{
				return;
			}
			if (newQuestData.questID >= 0)
			{
				allowStart = false;
			}
			int[] array = newQuestData.availableQuests;
			if (array == null)
			{
				array = new int[0];
			}
			this.questsScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			if (!GameEngine.Instance.World.isTutorialActive())
			{
				double num2 = DXTimer.GetCurrentMilliseconds() / 1000.0;
				int i;
				for (i = 0; i < array.Length; i++)
				{
					int num3 = array[i];
					if (num3 > 0)
					{
						NewQuestsPanel.NewQuestLine newQuestLine = new NewQuestsPanel.NewQuestLine();
						if (num != 0)
						{
							num += 5;
						}
						newQuestLine.Position = new Point(0, num);
						newQuestLine.init(num3, this, i, activeQuest, allowStart, false);
						this.questsScrollArea.addControl(newQuestLine);
						num += newQuestLine.Height;
						this.lineList.Add(newQuestLine);
					}
				}
				if (newQuestData.numAbandonedQuests > 0)
				{
					NewQuestsPanel.NewQuestLine newQuestLine2 = new NewQuestsPanel.NewQuestLine();
					if (num != 0)
					{
						num += 5;
					}
					newQuestLine2.Position = new Point(0, num);
					newQuestLine2.init(-newQuestData.numAbandonedQuests, this, i, activeQuest, allowStart, false);
					this.questsScrollArea.addControl(newQuestLine2);
					num += newQuestLine2.Height;
					this.lineList.Add(newQuestLine2);
				}
				this.tutorialText.Visible = false;
			}
			else
			{
				this.tutorialText.Visible = true;
			}
			num += 5;
			this.questsScrollArea.Size = new Size(this.questsScrollArea.Width, num);
			if (num < this.questsScrollBar.Height)
			{
				this.questsScrollBar.Visible = false;
			}
			else
			{
				this.questsScrollBar.Visible = true;
				this.questsScrollBar.NumVisibleLines = this.questsScrollBar.Height;
				this.questsScrollBar.Max = num - this.questsScrollBar.Height;
			}
			this.questsScrollArea.invalidate();
			this.questsScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x06001A7F RID: 6783 RVA: 0x001A2738 File Offset: 0x001A0938
		public void OpenFurtherInformation()
		{
			int data = CustomSelfDrawPanel.StaticClickedControl.Data;
			InterfaceMgr.Instance.openNewQuestFurtherTextPopup((string)CustomSelfDrawPanel.StaticClickedControl.Tag, data);
		}

		// Token: 0x06001A80 RID: 6784 RVA: 0x001A276C File Offset: 0x001A096C
		public static void addRewardIcons(CustomSelfDrawPanel.CSDControl parentControl, Point baseLocation, NewQuests.NewQuestDefinition def, int gloryMode)
		{
			if (def == null)
			{
				return;
			}
			CustomSelfDrawPanel.CSDLabel csdlabel = null;
			if (gloryMode > 0)
			{
				csdlabel = new CustomSelfDrawPanel.CSDLabel();
				csdlabel.Color = global::ARGBColors.Black;
				csdlabel.Position = baseLocation;
				csdlabel.Size = new Size(110, GFXLibrary.quest_rewards[0].Height);
				csdlabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
				csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				parentControl.addControl(csdlabel);
				baseLocation.X += 100;
			}
			int num = 0;
			if (def.reward_charges.Length > 0 && gloryMode == 1)
			{
				parentControl.addControl(NewQuestsPanel.createRewardIcon(9, -1, new Point(baseLocation.X, baseLocation.Y + 2), 3212));
				baseLocation.X += 60;
				num++;
				if (def.getRewardGlory() > 0 && gloryMode != 0 && GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1 && gloryMode > 0)
				{
					parentControl.addControl(new CustomSelfDrawPanel.CSDLabel
					{
						Text = "+",
						Color = global::ARGBColors.Black,
						Position = new Point(baseLocation.X - 18 - 2, baseLocation.Y + 12 - 2),
						Size = new Size(50, 30),
						Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold),
						Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER
					});
					baseLocation.X += 30;
				}
			}
			if (gloryMode >= 0)
			{
				if (def.reward_honour > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(1, def.reward_honour, baseLocation, 3203));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_gold > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(2, def.reward_gold, baseLocation, 3204));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_wood > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(3, def.reward_wood, baseLocation, 3205));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_stone > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(4, def.reward_stone, baseLocation, 3206));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_apples > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(12, def.reward_apples, baseLocation, 3214));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_card_pack > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(6, def.reward_card_pack, baseLocation, 3208));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_2day_premium > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(7, def.reward_2day_premium, baseLocation, 3209));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_faithpoints > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(8, def.reward_faithpoints, baseLocation, 3210));
					baseLocation.X += 120;
					num++;
				}
				if (def.reward_tickets > 0)
				{
					parentControl.addControl(NewQuestsPanel.createRewardIcon(10, def.reward_tickets, baseLocation, 3213));
					baseLocation.X += 120;
					num++;
				}
			}
			if (def.getRewardGlory() > 0 && gloryMode != 0 && GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1)
			{
				if (gloryMode > 0)
				{
					parentControl.addControl(new CustomSelfDrawPanel.CSDLabel
					{
						Text = SK.Text("QUESTS_or", "Or"),
						Color = global::ARGBColors.Black,
						Position = new Point(baseLocation.X, baseLocation.Y + 12),
						Size = new Size(50, 30),
						Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold),
						Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER
					});
					baseLocation.X += 50;
				}
				parentControl.addControl(NewQuestsPanel.createRewardIcon(0, def.getRewardGlory(), baseLocation, 3211));
				baseLocation.X += 120;
				num++;
			}
			if (csdlabel != null)
			{
				if (num == 1)
				{
					csdlabel.Text = SK.Text("QUEST_Reward", "Reward");
					return;
				}
				csdlabel.Text = SK.Text("QUEST_Rewards", "Rewards");
			}
		}

		// Token: 0x06001A81 RID: 6785 RVA: 0x001A2BE8 File Offset: 0x001A0DE8
		public static CustomSelfDrawPanel.CSDImage createRewardIcon(int iconID, int value, Point Location, int tooltipID)
		{
			CustomSelfDrawPanel.CSDImage csdimage = new CustomSelfDrawPanel.CSDImage();
			csdimage.Image = GFXLibrary.quest_rewards[iconID];
			csdimage.Position = Location;
			csdimage.CustomTooltipID = tooltipID;
			if (value >= 0)
			{
				csdimage.addControl(new CustomSelfDrawPanel.CSDLabel
				{
					Text = value.ToString(),
					Color = global::ARGBColors.Black,
					Position = new Point(47, 0),
					Size = new Size(80, csdimage.Image.Height),
					Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold),
					Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT,
					CustomTooltipID = tooltipID
				});
			}
			return csdimage;
		}

		// Token: 0x06001A82 RID: 6786 RVA: 0x001A2C90 File Offset: 0x001A0E90
		public static void handleClientSideQuestReporting(bool timeRestricted)
		{
			NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
			if (newQuestData == null || newQuestData.questID < 0 || newQuestData.completionState != 0)
			{
				return;
			}
			int questID = newQuestData.questID;
			if (questID <= 67)
			{
				if (questID <= 34)
				{
					if (questID <= 16)
					{
						if (questID - 4 > 1 && questID != 16)
						{
							return;
						}
					}
					else if (questID != 20 && questID != 34)
					{
						return;
					}
				}
				else if (questID <= 48)
				{
					if (questID != 42 && questID != 48)
					{
						return;
					}
				}
				else if (questID != 64 && questID != 67)
				{
					return;
				}
			}
			else if (questID <= 122)
			{
				if (questID <= 99)
				{
					if (questID != 84 && questID != 99)
					{
						return;
					}
				}
				else if (questID != 101 && questID != 122)
				{
					return;
				}
			}
			else if (questID <= 140)
			{
				if (questID != 125 && questID != 140)
				{
					return;
				}
			}
			else if (questID != 148 && questID != 157 && questID != 167)
			{
				return;
			}
			if (QuestsHelper.isQuestComplete(newQuestData) && (!timeRestricted || (DateTime.Now - NewQuestsPanel.m_lastQuestReportingUpdate).TotalSeconds >= 300.0))
			{
				NewQuestsPanel.m_lastQuestReportingUpdate = DateTime.Now;
				RemoteServices.Instance.set_CompleteAbandonNewQuest_UserCallBack(new RemoteServices.CompleteAbandonNewQuest_UserCallBack(NewQuestsPanel.completeAbandonNewQuestCallbackStatic));
				RemoteServices.Instance.AbandonNewQuest(-3);
			}
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x001A2DB4 File Offset: 0x001A0FB4
		private static void completeAbandonNewQuestCallbackStatic(CompleteAbandonNewQuest_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.goldGiven)
				{
					GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				}
				if (returnData.honourGiven)
				{
					GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				}
				if (returnData.fpGiven)
				{
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				}
				if (returnData.premiumCardsGiven)
				{
					CardTypes.PremiumToken premiumToken = new CardTypes.PremiumToken();
					premiumToken.Reward = 1;
					premiumToken.UserPremiumTokenID = returnData.premiumCardID;
					premiumToken.WorldID = RemoteServices.Instance.ProfileWorldID;
					premiumToken.Type = 4113;
					GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Add(returnData.premiumCardID, premiumToken);
				}
				if (returnData.cardPacksGiven > 0)
				{
					int num = 1;
					if (GameEngine.Instance.cardPackManager.ProfileUserCardPacks.ContainsKey(num))
					{
						CardTypes.UserCardPack userCardPack = GameEngine.Instance.cardPackManager.ProfileUserCardPacks[num];
						userCardPack.Count += returnData.cardPacksGiven;
					}
					else
					{
						CardTypes.UserCardPack userCardPack2 = new CardTypes.UserCardPack();
						userCardPack2.OfferID = num;
						userCardPack2.Count = returnData.cardPacksGiven;
						GameEngine.Instance.cardPackManager.ProfileUserCardPacks[num] = userCardPack2;
					}
				}
				if (returnData.gloryGiven)
				{
					GameEngine.Instance.World.clearGloryHistory();
				}
				if (returnData.villageUpdated >= 0)
				{
					GameEngine.Instance.flushVillage(returnData.villageUpdated);
				}
				if (returnData.ticketsGiven > 0)
				{
					GameEngine.Instance.World.addTickets(-1, returnData.ticketsGiven);
				}
			}
			else if (returnData.m_errorCode == ErrorCodes.ErrorCode.NEW_QUESTS_FAILED_REWARD)
			{
				MyMessageBox.Show(SK.Text("QUESTS_failed_reward_body", "We have been unable to give the correct reward for this quest, please wait a few minutes and try again. If this doesn't work, please contact support."), SK.Text("QUESTS_failed_reward", "Quest Reward Error"));
			}
			if (returnData.m_newQuestsData != null)
			{
				GameEngine.Instance.World.setNewQuestData(returnData.m_newQuestsData);
			}
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x00132AB0 File Offset: 0x00130CB0
		private void friendClicked()
		{
			string fileName = string.Concat(new string[]
			{
				URLs.InviteAFriendURL,
				"?webtoken=",
				RemoteServices.Instance.WebToken,
				"&lang=",
				Program.mySettings.LanguageIdent.ToLower(),
				"&colour=",
				GFXLibrary.invite_ad_colour.ToString()
			});
			try
			{
				Process.Start(fileName);
			}
			catch (Exception)
			{
				MyMessageBox.Show(SK.Text("ERROR_Browser1", "Stronghold Kingdoms encountered an error when trying to open your system's Default Web Browser. Please check that your web browser is working correctly and there are no unresponsive copies showing in task manager->Processes and then try again.") + Environment.NewLine + Environment.NewLine + SK.Text("ERROR_Browser2", "If this problem persists, please contact support."), SK.Text("ERROR_Browser3", "Error opening Web Browser"));
			}
		}

		// Token: 0x04002B2F RID: 11055
		private DockableControl dockableControl;

		// Token: 0x04002B30 RID: 11056
		private IContainer components;

		// Token: 0x04002B31 RID: 11057
		private Panel focusPanel;

		// Token: 0x04002B32 RID: 11058
		public static NewQuestsPanel Instance = null;

		// Token: 0x04002B33 RID: 11059
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002B34 RID: 11060
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002B35 RID: 11061
		private CustomSelfDrawPanel.CSDExtendingPanel insetImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002B36 RID: 11062
		private CustomSelfDrawPanel.CSDImage underlayImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B37 RID: 11063
		private CustomSelfDrawPanel.CSDImage questImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B38 RID: 11064
		private CustomSelfDrawPanel.CSDImage questIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B39 RID: 11065
		private CustomSelfDrawPanel.CSDLabel lblQuestName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B3A RID: 11066
		private CustomSelfDrawPanel.CSDLabel lblQuestDescription = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B3B RID: 11067
		private CustomSelfDrawPanel.CSDHorzProgressBar questProgressBar = new CustomSelfDrawPanel.CSDHorzProgressBar();

		// Token: 0x04002B3C RID: 11068
		private CustomSelfDrawPanel.CSDLabel progressTextLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B3D RID: 11069
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B3E RID: 11070
		private CustomSelfDrawPanel.CSDVertScrollBar questsScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002B3F RID: 11071
		private CustomSelfDrawPanel.CSDArea questsScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002B40 RID: 11072
		private CustomSelfDrawPanel.CSDDragPanel dragOverlay = new CustomSelfDrawPanel.CSDDragPanel();

		// Token: 0x04002B41 RID: 11073
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002B42 RID: 11074
		private CustomSelfDrawPanel.CSDButton completeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B43 RID: 11075
		private CustomSelfDrawPanel.CSDImage completeGlow = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B44 RID: 11076
		private CustomSelfDrawPanel.CSDImage completeGlow2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B45 RID: 11077
		private CustomSelfDrawPanel.CSDButton abandonButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B46 RID: 11078
		private CustomSelfDrawPanel.CSDLabel completedQuestsLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B47 RID: 11079
		private CustomSelfDrawPanel.CSDLabel timeLeftLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B48 RID: 11080
		private CustomSelfDrawPanel.CSDLabel tutorialText = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B49 RID: 11081
		private int glowValue;

		// Token: 0x04002B4A RID: 11082
		private int m_selectedQuest = -1;

		// Token: 0x04002B4B RID: 11083
		private DateTime lastFullUpdateTime = DateTime.MinValue;

		// Token: 0x04002B4C RID: 11084
		private List<NewQuestsPanel.NewQuestLine> lineList = new List<NewQuestsPanel.NewQuestLine>();

		// Token: 0x04002B4D RID: 11085
		private static DateTime m_lastQuestReportingUpdate = DateTime.MinValue;

		// Token: 0x0200025A RID: 602
		public class NewQuestLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001A86 RID: 6790 RVA: 0x001A2FA8 File Offset: 0x001A11A8
			public void init(int quest, NewQuestsPanel parent, int position, int activeQuest, bool allowStart, bool completed)
			{
				this.m_quest = quest;
				this.m_activeQuest = activeQuest;
				this.m_parent = parent;
				this.clearControls();
				if ((position & 1) == 0)
				{
					this.backgroundImage.Image = GFXLibrary.quest_screen_bar1;
				}
				else
				{
					this.backgroundImage.Image = GFXLibrary.quest_screen_bar2;
				}
				this.backgroundImage.Position = new Point(60, 11);
				if (!completed)
				{
					this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				}
				base.addControl(this.backgroundImage);
				if (quest < 0)
				{
					this.lblQuestName.Text = SK.Text("QUESTS_AbandonedQuests", "Abandoned Quests : ") + (-quest).ToString();
					this.lblQuestName.Color = global::ARGBColors.Black;
					if (activeQuest != quest)
					{
						this.lblQuestName.RolloverColor = global::ARGBColors.White;
					}
					this.lblQuestName.Position = new Point(9, 0);
					this.lblQuestName.Size = new Size(700, this.backgroundImage.Height);
					this.lblQuestName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
					this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.lblQuestName);
					this.startQuestButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
					this.startQuestButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
					this.startQuestButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
					this.startQuestButton.Position = new Point(670, 6);
					this.startQuestButton.Text.Text = SK.Text("QUESTS_Restore", "Restore");
					this.startQuestButton.Text.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
					this.startQuestButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
					this.startQuestButton.TextYOffset = -3;
					this.startQuestButton.Text.Color = global::ARGBColors.Black;
					this.startQuestButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.restoreQuests), "NewQuests_Restore_Quests_Clicked");
					this.backgroundImage.addControl(this.startQuestButton);
					this.Size = new Size(880, 60);
					return;
				}
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(quest);
				if (!completed)
				{
					base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				}
				if (activeQuest != quest || completed)
				{
					this.Size = new Size(880, 60);
				}
				else
				{
					this.Size = new Size(880, 130);
					NumberFormatInfo nfi = GameEngine.NFI;
					int id = newQuestDef.ID;
					if (id <= 48)
					{
						if (id <= 16)
						{
							if (id != 4 && id != 16)
							{
								goto IL_315;
							}
						}
						else if (id != 34 && id != 48)
						{
							goto IL_315;
						}
					}
					else if (id <= 84)
					{
						if (id != 64 && id != 84)
						{
							goto IL_315;
						}
					}
					else if (id != 101 && id != 122)
					{
						goto IL_315;
					}
					CustomSelfDrawPanel.CSDLabel csdlabel = this.lblQuestDescription;
					csdlabel.Text += SK.Text("QUESTS_Spread_New_description", "Learn about Invite a Friend");
					goto IL_391;
					IL_315:
					if (newQuestDef.parameter > 0)
					{
						CustomSelfDrawPanel.CSDLabel csdlabel2 = this.lblQuestDescription;
						csdlabel2.Text = csdlabel2.Text + SK.NoStoreText("Z_QUEST_DESCRIPTIONS_" + newQuestDef.tagString) + " : " + newQuestDef.parameter.ToString("N", nfi);
					}
					else
					{
						CustomSelfDrawPanel.CSDLabel csdlabel3 = this.lblQuestDescription;
						csdlabel3.Text += SK.NoStoreText("Z_QUEST_DESCRIPTIONS_" + newQuestDef.tagString);
					}
					IL_391:
					this.lblQuestDescription.Color = global::ARGBColors.Black;
					this.lblQuestDescription.RolloverColor = global::ARGBColors.White;
					this.lblQuestDescription.Position = new Point(175, 57);
					this.lblQuestDescription.Size = new Size(760, 50);
					this.lblQuestDescription.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
					this.lblQuestDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					this.lblQuestDescription.Data = newQuestDef.ID;
					this.lblQuestDescription.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.OpenFurtherInformation));
					this.lblQuestDescription.Tag = newQuestDef.tagString;
					base.addControl(this.lblQuestDescription);
					this.lblObjective.Text = SK.Text("QUEST_PANEL_DESCRIPTION_OBJECTIVE", "Objective");
					this.lblObjective.Color = global::ARGBColors.Black;
					this.lblObjective.Position = new Point(70, 57);
					this.lblObjective.Size = new Size(760, 50);
					this.lblObjective.Font = FontManager.GetFont("Arial", 11f, FontStyle.Bold);
					this.lblObjective.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
					base.addControl(this.lblObjective);
					NewQuestsPanel.addRewardIcons(this, new Point(70, 95), newQuestDef, 1);
				}
				this.questImage.Image = GFXLibrary.quest_icons[Math.Min(newQuestDef.questType, GFXLibrary.quest_icons.Length - 1)];
				this.questImage.Position = new Point(0, 6);
				if (!completed)
				{
					this.questImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				}
				base.addControl(this.questImage);
				this.lblQuestName.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef.tagString);
				this.lblQuestName.Color = global::ARGBColors.Black;
				if (activeQuest != quest && !completed)
				{
					this.lblQuestName.RolloverColor = global::ARGBColors.White;
				}
				this.lblQuestName.Position = new Point(9, 0);
				this.lblQuestName.Size = new Size(700, this.backgroundImage.Height);
				this.lblQuestName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				if (!completed)
				{
					this.lblQuestName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				}
				this.backgroundImage.addControl(this.lblQuestName);
				if (!GameEngine.Instance.World.WorldEnded)
				{
					if (allowStart && !completed)
					{
						this.startQuestButton.ImageNorm = GFXLibrary.quest_checkboxes[0];
						this.startQuestButton.ImageOver = GFXLibrary.quest_checkboxes[2];
						this.startQuestButton.Position = new Point(715, 6);
						this.startQuestButton.MoveOnClick = true;
						this.startQuestButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.startQuest), "NewQuests_Start_Quest_Clicked");
						this.startQuestButton.CustomTooltipID = 3201;
						this.backgroundImage.addControl(this.startQuestButton);
					}
					if (!completed)
					{
						this.abandonQuestButton.ImageNorm = GFXLibrary.quest_checkboxes[1];
						this.abandonQuestButton.ImageOver = GFXLibrary.quest_checkboxes[3];
						this.abandonQuestButton.Position = new Point(765, 6);
						this.abandonQuestButton.MoveOnClick = true;
						this.abandonQuestButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.abandonQuest), "NewQuests_Abandon_Clicked");
						this.abandonQuestButton.CustomTooltipID = 3202;
						this.backgroundImage.addControl(this.abandonQuestButton);
					}
				}
			}

			// Token: 0x06001A87 RID: 6791 RVA: 0x0000A849 File Offset: 0x00008A49
			public bool update(double localTime)
			{
				return true;
			}

			// Token: 0x06001A88 RID: 6792 RVA: 0x001A2738 File Offset: 0x001A0938
			public void OpenFurtherInformation()
			{
				int data = CustomSelfDrawPanel.StaticClickedControl.Data;
				InterfaceMgr.Instance.openNewQuestFurtherTextPopup((string)CustomSelfDrawPanel.StaticClickedControl.Tag, data);
			}

			// Token: 0x06001A89 RID: 6793 RVA: 0x0001A89B File Offset: 0x00018A9B
			private void lineClicked()
			{
				if (this.m_activeQuest != this.m_quest)
				{
					GameEngine.Instance.playInterfaceSound("NewQuests_Expand_Quest_Description");
					this.m_parent.expandQuest(this.m_quest);
				}
			}

			// Token: 0x06001A8A RID: 6794 RVA: 0x0001A8CB File Offset: 0x00018ACB
			private void startQuest()
			{
				if (this.m_parent != null)
				{
					this.m_parent.startQuest(this.m_quest);
				}
			}

			// Token: 0x06001A8B RID: 6795 RVA: 0x0001A8E6 File Offset: 0x00018AE6
			private void abandonQuest()
			{
				if (this.m_parent != null)
				{
					this.m_parent.abandonQuest(this.m_quest);
				}
			}

			// Token: 0x06001A8C RID: 6796 RVA: 0x0001A901 File Offset: 0x00018B01
			private void restoreQuests()
			{
				if (this.m_parent != null)
				{
					this.m_parent.restoreQuests();
				}
			}

			// Token: 0x04002B4E RID: 11086
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B4F RID: 11087
			private CustomSelfDrawPanel.CSDImage questImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B50 RID: 11088
			private CustomSelfDrawPanel.CSDLabel lblQuestName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002B51 RID: 11089
			private CustomSelfDrawPanel.CSDLabel lblQuestDescription = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002B52 RID: 11090
			private CustomSelfDrawPanel.CSDLabel lblObjective = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002B53 RID: 11091
			private CustomSelfDrawPanel.CSDButton startQuestButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002B54 RID: 11092
			private CustomSelfDrawPanel.CSDButton abandonQuestButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002B55 RID: 11093
			private CustomSelfDrawPanel.CSDButton furtherTextButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002B56 RID: 11094
			private NewQuestsPanel m_parent;

			// Token: 0x04002B57 RID: 11095
			private int m_quest = -1;

			// Token: 0x04002B58 RID: 11096
			private int m_activeQuest = -1;
		}
	}
}
