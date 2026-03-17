using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x020002AA RID: 682
	public class QuestsPanel2 : CustomSelfDrawPanel, IDockableControl
	{
		// Token: 0x06001E96 RID: 7830 RVA: 0x0001D2AF File Offset: 0x0001B4AF
		public void initProperties(bool dockable, string title, ContainerControl parent)
		{
			this.dockableControl.initProperties(dockable, title, parent);
		}

		// Token: 0x06001E97 RID: 7831 RVA: 0x0001D2BF File Offset: 0x0001B4BF
		public void display(ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(parent, x, y);
		}

		// Token: 0x06001E98 RID: 7832 RVA: 0x0001D2CF File Offset: 0x0001B4CF
		public void display(bool asPopup, ContainerControl parent, int x, int y)
		{
			this.dockableControl.display(asPopup, parent, x, y);
		}

		// Token: 0x06001E99 RID: 7833 RVA: 0x0001D2E1 File Offset: 0x0001B4E1
		public void controlDockToggle()
		{
			this.dockableControl.controlDockToggle();
		}

		// Token: 0x06001E9A RID: 7834 RVA: 0x0001D2EE File Offset: 0x0001B4EE
		public void closeControl(bool includePopups)
		{
			this.dockableControl.closeControl(includePopups);
			base.clearControls();
			this.closing();
		}

		// Token: 0x06001E9B RID: 7835 RVA: 0x0001D308 File Offset: 0x0001B508
		public bool isVisible()
		{
			return this.dockableControl.isVisible();
		}

		// Token: 0x06001E9C RID: 7836 RVA: 0x0001D315 File Offset: 0x0001B515
		public bool isPopup()
		{
			return this.dockableControl.isPopup();
		}

		// Token: 0x06001E9D RID: 7837 RVA: 0x0001D322 File Offset: 0x0001B522
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001E9E RID: 7838 RVA: 0x001D8210 File Offset: 0x001D6410
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
			base.Name = "QuestsPanel2";
			this.MaximumSize = new Size(992, 10000);
			this.MinimumSize = new Size(992, 566);
			base.Size = new Size(992, 566);
			base.ResumeLayout(false);
		}

		// Token: 0x06001E9F RID: 7839 RVA: 0x001D82FC File Offset: 0x001D64FC
		public QuestsPanel2()
		{
			QuestsPanel2.Instance = this;
			this.dockableControl = new DockableControl(this);
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.focusPanel.Focus();
		}

		// Token: 0x06001EA0 RID: 7840 RVA: 0x001D8410 File Offset: 0x001D6610
		public void init(bool resized)
		{
			int height = base.Height;
			QuestsPanel2.questXPos = base.Location.X;
			QuestsPanel2.Instance = this;
			base.clearControls();
			this.headerImage.Size = new Size(base.Width, 40);
			this.headerImage.Position = new Point(0, 0);
			base.addControl(this.headerImage);
			this.headerImage.Create(GFXLibrary.mail2_titlebar_left, GFXLibrary.mail2_titlebar_middle, GFXLibrary.mail2_titlebar_right);
			this.backgroundImage.Size = new Size(base.Width, height - 40);
			this.backgroundImage.Position = new Point(0, 40);
			base.addControl(this.backgroundImage);
			this.backgroundImage.Create(GFXLibrary.mail2_mail_panel_upper_left, GFXLibrary.mail2_mail_panel_upper_middle, GFXLibrary.mail2_mail_panel_upper_right, GFXLibrary.mail2_mail_panel_middle_left, GFXLibrary.mail2_mail_panel_middle_middle, GFXLibrary.mail2_mail_panel_middle_right, GFXLibrary.mail2_mail_panel_lower_left, GFXLibrary.mail2_mail_panel_lower_middle, GFXLibrary.mail2_mail_panel_lower_right);
			this.parishNameLabel.Text = SK.Text("QuestPanel_TutorialQuests", "Tutorial Quests");
			this.parishNameLabel.Color = global::ARGBColors.White;
			this.parishNameLabel.DropShadowColor = global::ARGBColors.Black;
			this.parishNameLabel.Position = new Point(20, 0);
			this.parishNameLabel.Size = new Size(base.Width - 40, 40);
			this.parishNameLabel.Font = FontManager.GetFont("Arial", 18f, FontStyle.Regular);
			this.parishNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerImage.addControl(this.parishNameLabel);
			this.blockYSize = height - 40 - 56;
			this.headerLabelsImage.Size = new Size(base.Width - 25 - 23, 28);
			this.headerLabelsImage.Position = new Point(25, 5);
			this.backgroundImage.addControl(this.headerLabelsImage);
			this.headerLabelsImage.Create(GFXLibrary.mail2_field_bar_mail_left, GFXLibrary.mail2_field_bar_mail_middle, GFXLibrary.mail2_field_bar_mail_right);
			this.divider1Image.Image = GFXLibrary.mail2_field_bar_mail_divider;
			this.divider1Image.Position = new Point(490, 0);
			this.headerLabelsImage.addControl(this.divider1Image);
			this.objectivesLabel.Text = SK.Text("QuestsPanel_Objectives", "Objectives");
			this.objectivesLabel.Color = global::ARGBColors.Black;
			this.objectivesLabel.Position = new Point(12, -2);
			this.objectivesLabel.Size = new Size(323, this.headerLabelsImage.Height);
			this.objectivesLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.objectivesLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.objectivesLabel);
			this.statusLabel.Text = SK.Text("QuestsPanel_Status", "Status");
			this.statusLabel.Color = global::ARGBColors.Black;
			this.statusLabel.Position = new Point(496, -2);
			this.statusLabel.Size = new Size(223, this.headerLabelsImage.Height);
			this.statusLabel.Font = FontManager.GetFont("Arial", 9f, FontStyle.Regular);
			this.statusLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
			this.headerLabelsImage.addControl(this.statusLabel);
			this.outgoingScrollArea.Position = new Point(25, 40);
			this.outgoingScrollArea.Size = new Size(915, this.blockYSize - 40 - 10);
			this.outgoingScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(915, this.blockYSize - 40 - 10));
			this.backgroundImage.addControl(this.outgoingScrollArea);
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollBar.Position = new Point(943, 40);
			this.outgoingScrollBar.Size = new Size(24, this.blockYSize - 40 - 10);
			this.backgroundImage.addControl(this.outgoingScrollBar);
			this.outgoingScrollBar.Value = 0;
			this.outgoingScrollBar.Max = 100;
			this.outgoingScrollBar.NumVisibleLines = 25;
			this.outgoingScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.outgoingScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			if (!resized)
			{
				this.downloadQuestInfo();
			}
			this.rebuild();
			if (resized)
			{
				this.outgoingScrollBar.Value = value;
			}
		}

		// Token: 0x06001EA1 RID: 7841 RVA: 0x0001D341 File Offset: 0x0001B541
		public void downloadQuestInfo()
		{
			this.downloadedQuestInfo = false;
			this.downloadingQuestInfo = true;
			this.completedActiveQuests = null;
			RemoteServices.Instance.set_GetQuestStatus_UserCallBack(new RemoteServices.GetQuestStatus_UserCallBack(this.GetQuestStatusCallback));
			RemoteServices.Instance.GetQuestStatus();
		}

		// Token: 0x06001EA2 RID: 7842 RVA: 0x0001D378 File Offset: 0x0001B578
		public void GetQuestStatusCallback(GetQuestStatus_ReturnType returnData)
		{
			this.downloadedQuestInfo = true;
			this.downloadingQuestInfo = false;
			if (returnData.Success)
			{
				GameEngine.Instance.World.setTutorialInfo(returnData.m_tutorialInfo);
				this.completedActiveQuests = returnData.m_preCompletedQuests;
				this.rebuild();
			}
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x001D8910 File Offset: 0x001D6B10
		public void update()
		{
			double localTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (QuestsPanel2.QuestLine questLine in this.lineList)
			{
				questLine.update(localTime);
			}
		}

		// Token: 0x06001EA4 RID: 7844 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void logout()
		{
		}

		// Token: 0x06001EA5 RID: 7845 RVA: 0x001D8974 File Offset: 0x001D6B74
		private void wallScrollBarMoved()
		{
			int value = this.outgoingScrollBar.Value;
			this.outgoingScrollArea.Position = new Point(this.outgoingScrollArea.X, 40 - value);
			this.outgoingScrollArea.ClipRect = new Rectangle(this.outgoingScrollArea.ClipRect.X, value, this.outgoingScrollArea.ClipRect.Width, this.outgoingScrollArea.ClipRect.Height);
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
		}

		// Token: 0x06001EA6 RID: 7846 RVA: 0x0000ADE9 File Offset: 0x00008FE9
		public void closing()
		{
			InterfaceMgr.Instance.closeDonatePopup();
		}

		// Token: 0x06001EA7 RID: 7847 RVA: 0x001D8A0C File Offset: 0x001D6C0C
		public void rebuild()
		{
			int[] activeQuests = GameEngine.Instance.World.getActiveQuests();
			this.outgoingScrollArea.clearControls();
			int num = 0;
			this.lineList.Clear();
			double num2 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			for (int i = 0; i < activeQuests.Length; i++)
			{
				int quest = activeQuests[i];
				int completeState = 0;
				if (this.completedActiveQuests != null && i < this.completedActiveQuests.Length)
				{
					completeState = ((!this.completedActiveQuests[i]) ? 1 : 2);
				}
				QuestsPanel2.QuestLine questLine = new QuestsPanel2.QuestLine();
				if (num != 0)
				{
					num += 5;
				}
				questLine.Position = new Point(0, num);
				questLine.init(quest, this, completeState, i);
				this.outgoingScrollArea.addControl(questLine);
				num += questLine.Height;
				this.lineList.Add(questLine);
			}
			this.outgoingScrollArea.Size = new Size(this.outgoingScrollArea.Width, num);
			if (num < this.outgoingScrollBar.Height)
			{
				this.outgoingScrollBar.Visible = false;
			}
			else
			{
				this.outgoingScrollBar.Visible = true;
				this.outgoingScrollBar.NumVisibleLines = this.outgoingScrollBar.Height;
				this.outgoingScrollBar.Max = num - this.outgoingScrollBar.Height;
			}
			this.outgoingScrollArea.invalidate();
			this.outgoingScrollBar.invalidate();
			this.backgroundImage.invalidate();
			this.update();
		}

		// Token: 0x06001EA8 RID: 7848 RVA: 0x001D8B70 File Offset: 0x001D6D70
		public bool isRewardAvailable(int quest)
		{
			int[] activeQuests = GameEngine.Instance.World.getActiveQuests();
			for (int i = 0; i < activeQuests.Length; i++)
			{
				if (this.completedActiveQuests != null && i < this.completedActiveQuests.Length && this.completedActiveQuests[i] && activeQuests[i] == quest)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001EA9 RID: 7849 RVA: 0x001D8BC4 File Offset: 0x001D6DC4
		public bool isQuestComplete(int quest)
		{
			int[] completedQuests = GameEngine.Instance.World.getCompletedQuests();
			for (int i = 0; i < completedQuests.Length; i++)
			{
				if (completedQuests[i] == quest)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001EAA RID: 7850 RVA: 0x001D8BF8 File Offset: 0x001D6DF8
		public void completeQuest(int quest)
		{
			if (!this.inCompleteQuest || (DateTime.Now - this.completedQuestTime).TotalMinutes >= 2.0)
			{
				this.completedQuestTime = DateTime.Now;
				this.inCompleteQuest = true;
				RemoteServices.Instance.set_CompleteQuest_UserCallBack(new RemoteServices.CompleteQuest_UserCallBack(this.CompleteQuestCallback));
				RemoteServices.Instance.CompleteQuest(quest);
			}
		}

		// Token: 0x06001EAB RID: 7851 RVA: 0x001D8C64 File Offset: 0x001D6E64
		public void CompleteQuestCallback(CompleteQuest_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.setTutorialInfo(returnData.m_tutorialInfo);
				this.completedActiveQuests = returnData.m_preCompletedQuests;
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_QUESTS)
				{
					this.rebuild();
				}
				if (returnData.questCompleted >= 0)
				{
					List<Quests.QuestReward> questRewards = Quests.getQuestRewards(returnData.questCompleted, false, null);
					foreach (Quests.QuestReward questReward in questRewards)
					{
						switch (questReward.type)
						{
						case 20000:
						{
							List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
							if (userVillageIDList.Count != 1)
							{
								GameEngine.Instance.flushVillages();
								if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
								{
									GameEngine.Instance.downloadCurrentVillage();
								}
							}
							else if (userVillageIDList.Count == 1)
							{
								VillageMap village = GameEngine.Instance.getVillage(userVillageIDList[0]);
								if (village != null)
								{
									village.addResources(questReward.data, questReward.amount);
								}
							}
							break;
						}
						case 20001:
							GameEngine.Instance.World.addGold((double)questReward.amount);
							break;
						case 20002:
							GameEngine.Instance.World.addHonour((double)questReward.amount);
							break;
						case 20003:
							GameEngine.Instance.World.addResearchPoints(questReward.amount);
							break;
						case 20004:
							if (returnData.cardAdded >= 0)
							{
								if (questReward.data != 4113)
								{
									GameEngine.Instance.cardsManager.addProfileCard(returnData.cardAdded, CardTypes.getStringFromCard(questReward.data));
								}
								else
								{
									CardTypes.PremiumToken premiumToken = new CardTypes.PremiumToken();
									premiumToken.Reward = 1;
									premiumToken.UserPremiumTokenID = returnData.cardAdded;
									premiumToken.WorldID = RemoteServices.Instance.ProfileWorldID;
									premiumToken.Type = 4113;
									bool flag = false;
									if (GameEngine.Instance.cardsManager.UserCardData.premiumCard <= 0)
									{
										XmlRpcCardsProvider xmlRpcCardsProvider = XmlRpcCardsProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressCards, URLs.ProfileServerPort, URLs.ProfileCardPath);
										XmlRpcCardsRequest xmlRpcCardsRequest = new XmlRpcCardsRequest(RemoteServices.Instance.UserGuid.ToString().Replace("-", ""));
										xmlRpcCardsRequest.SessionGUID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", "");
										xmlRpcCardsRequest.WorldID = RemoteServices.Instance.ProfileWorldID.ToString();
										xmlRpcCardsRequest.UserCardID = returnData.cardAdded.ToString();
										if (premiumToken.Type == 4112)
										{
											xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM";
										}
										if (premiumToken.Type == 4113)
										{
											xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM2";
										}
										if (premiumToken.Type == 4114)
										{
											xmlRpcCardsRequest.CardString = "CARDTYPE_PREMIUM30";
										}
										XmlRpcCardsResponse xmlRpcCardsResponse = xmlRpcCardsProvider.playPremium(xmlRpcCardsRequest, 6000);
										int? successCode = xmlRpcCardsResponse.SuccessCode;
										int num = 1;
										if (!(successCode.GetValueOrDefault() == num & successCode != null))
										{
											flag = true;
											MyMessageBox.Show(xmlRpcCardsResponse.Message, "Error playing premium");
										}
										else
										{
											GameEngine.Instance.cardsManager.CardPlayed(-1, premiumToken.Type, -1);
										}
									}
									else
									{
										flag = true;
									}
									if (flag)
									{
										GameEngine.Instance.premiumTokenManager.ProfilePremiumTokens.Add(returnData.cardAdded, premiumToken);
									}
								}
							}
							break;
						case 20006:
							GameEngine.Instance.World.FakeCardPoints += questReward.amount;
							break;
						}
					}
					bool flag2 = false;
					foreach (Quests.QuestReward questReward2 in questRewards)
					{
						if (questReward2.type == 20004 || questReward2.type == 20006)
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						PlayCardsWindow.resetRewardCardTimer();
					}
				}
			}
			this.inCompleteQuest = false;
		}

		// Token: 0x04002F57 RID: 12119
		private DockableControl dockableControl;

		// Token: 0x04002F58 RID: 12120
		private IContainer components;

		// Token: 0x04002F59 RID: 12121
		private Panel focusPanel;

		// Token: 0x04002F5A RID: 12122
		public static QuestsPanel2 Instance;

		// Token: 0x04002F5B RID: 12123
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002F5C RID: 12124
		private CustomSelfDrawPanel.CSDExtendingPanel backgroundImage = new CustomSelfDrawPanel.CSDExtendingPanel();

		// Token: 0x04002F5D RID: 12125
		private CustomSelfDrawPanel.CSDLabel parishNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F5E RID: 12126
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerLabelsImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002F5F RID: 12127
		private CustomSelfDrawPanel.CSDImage divider1Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F60 RID: 12128
		private CustomSelfDrawPanel.CSDImage divider2Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F61 RID: 12129
		private CustomSelfDrawPanel.CSDImage divider3Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F62 RID: 12130
		private CustomSelfDrawPanel.CSDImage divider4Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F63 RID: 12131
		private CustomSelfDrawPanel.CSDImage divider5Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F64 RID: 12132
		private CustomSelfDrawPanel.CSDImage divider6Image = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002F65 RID: 12133
		private CustomSelfDrawPanel.CSDLabel objectivesLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F66 RID: 12134
		private CustomSelfDrawPanel.CSDLabel statusLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F67 RID: 12135
		private CustomSelfDrawPanel.CSDLabel rewardLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002F68 RID: 12136
		private CustomSelfDrawPanel.CSDVertScrollBar outgoingScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002F69 RID: 12137
		private CustomSelfDrawPanel.CSDArea outgoingScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002F6A RID: 12138
		private int blockYSize;

		// Token: 0x04002F6B RID: 12139
		private List<WorldMap.LocalArmyData> armyList = new List<WorldMap.LocalArmyData>();

		// Token: 0x04002F6C RID: 12140
		public static int questXPos;

		// Token: 0x04002F6D RID: 12141
		private bool[] completedActiveQuests;

		// Token: 0x04002F6E RID: 12142
		public bool downloadingQuestInfo;

		// Token: 0x04002F6F RID: 12143
		public bool downloadedQuestInfo;

		// Token: 0x04002F70 RID: 12144
		private List<QuestsPanel2.QuestLine> lineList = new List<QuestsPanel2.QuestLine>();

		// Token: 0x04002F71 RID: 12145
		private bool inCompleteQuest;

		// Token: 0x04002F72 RID: 12146
		private DateTime completedQuestTime = DateTime.MinValue;

		// Token: 0x04002F73 RID: 12147
		private QuestsPanel2.ArmyComparer armyComparer = new QuestsPanel2.ArmyComparer();

		// Token: 0x020002AB RID: 683
		public class ArmyComparer : IComparer<WorldMap.LocalArmyData>
		{
			// Token: 0x06001EAC RID: 7852 RVA: 0x0001D3B7 File Offset: 0x0001B5B7
			public int Compare(WorldMap.LocalArmyData x, WorldMap.LocalArmyData y)
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
					if (x.armyID > y.armyID)
					{
						return 1;
					}
					if (x.armyID < y.armyID)
					{
						return -1;
					}
					return 0;
				}
			}
		}

		// Token: 0x020002AC RID: 684
		public class QuestLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001EAE RID: 7854 RVA: 0x001D90C0 File Offset: 0x001D72C0
			public void init(int quest, QuestsPanel2 parent, int completeState, int position)
			{
				this.m_quest = quest;
				this.m_parent = parent;
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
				this.lblQuestDescription.Text = Quests.getQuestText(quest);
				this.lblQuestDescription.Color = global::ARGBColors.Black;
				this.lblQuestDescription.RolloverColor = global::ARGBColors.White;
				this.lblQuestDescription.Position = new Point(9, 0);
				this.lblQuestDescription.Size = new Size(480, this.backgroundImage.Height);
				this.lblQuestDescription.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblQuestDescription.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblQuestDescription);
				this.collectButton.Visible = false;
				switch (completeState)
				{
				case -1:
					this.lblStatus.Visible = false;
					break;
				case 0:
					this.lblStatus.Text = "?";
					break;
				case 1:
					this.lblStatus.Text = SK.Text("QuestLine_Not_Complete", "Objective not complete");
					break;
				case 2:
					this.lblStatus.Text = SK.Text("QuestLine_Complete", "Objective Complete");
					if (!GameEngine.Instance.World.WorldEnded)
					{
						this.collectButton.Visible = true;
					}
					break;
				}
				this.lblStatus.Color = global::ARGBColors.Black;
				this.lblStatus.RolloverColor = global::ARGBColors.White;
				this.lblStatus.Position = new Point(496, 0);
				this.lblStatus.Size = new Size(288, this.backgroundImage.Height);
				this.lblStatus.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.lblStatus.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblStatus);
				this.collectButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
				this.collectButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
				this.collectButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
				this.collectButton.Position = new Point(774, 4);
				this.collectButton.Text.Text = SK.Text("QuestLine_Collect_Reward", "Collect Reward");
				this.collectButton.Text.Color = global::ARGBColors.Black;
				this.collectButton.Text.Font = FontManager.GetFont("Arial", 8.25f, FontStyle.Regular);
				this.collectButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked), "QuestsPanel2_collect");
				this.backgroundImage.addControl(this.collectButton);
			}

			// Token: 0x06001EAF RID: 7855 RVA: 0x0000A849 File Offset: 0x00008A49
			public bool update(double localTime)
			{
				return true;
			}

			// Token: 0x06001EB0 RID: 7856 RVA: 0x0001D3E9 File Offset: 0x0001B5E9
			private void lineClicked()
			{
				this.collectButton.Enabled = false;
				this.m_parent.completeQuest(this.m_quest);
			}

			// Token: 0x04002F74 RID: 12148
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002F75 RID: 12149
			private CustomSelfDrawPanel.CSDLabel lblQuestDescription = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F76 RID: 12150
			private CustomSelfDrawPanel.CSDLabel lblStatus = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F77 RID: 12151
			private CustomSelfDrawPanel.CSDLabel lblReward = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002F78 RID: 12152
			private CustomSelfDrawPanel.CSDButton collectButton = new CustomSelfDrawPanel.CSDButton();

			// Token: 0x04002F79 RID: 12153
			private QuestsPanel2 m_parent;

			// Token: 0x04002F7A RID: 12154
			private int m_quest = -1;
		}
	}
}
