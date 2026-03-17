using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000252 RID: 594
	public class NewQuestRewardPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001A37 RID: 6711 RVA: 0x0001A41B File Offset: 0x0001861B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x0019E878 File Offset: 0x0019CA78
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = global::ARGBColors.White;
			base.Name = "NewQuestRewardPanel";
			base.Size = new Size(600, 55);
			base.ResumeLayout(false);
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x0019E8D8 File Offset: 0x0019CAD8
		public NewQuestRewardPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x0019EA08 File Offset: 0x0019CC08
		public void init(int questID, int villageID, NewQuestsPanel questPanel, NewQuestRewardPopup parent)
		{
			this.m_questID = questID;
			this.m_villageID = -1;
			this.m_questPanel = questPanel;
			base.clearControls();
			bool flag = false;
			if (GameEngine.Instance.World.YourHouse > 0)
			{
				flag = true;
			}
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				flag = false;
			}
			List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
			NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(questID);
			int num = ((newQuestDef.reward_apples > 0 || newQuestDef.reward_stone > 0 || newQuestDef.reward_wood > 0) && userVillageIDList.Count > 1) ? ((newQuestDef.getRewardGlory() <= 0 || !flag) ? 410 : 492) : ((newQuestDef.getRewardGlory() <= 0 || !flag) ? 200 : 270);
			parent.Size = new Size(550, num);
			this.headerBarImage.Position = new Point(0, 0);
			this.headerBarImage.Size = new Size(base.Width, 30);
			base.addControl(this.headerBarImage);
			this.headerBarImage.Create(GFXLibrary.messageboxtop_left, GFXLibrary.messageboxtop_middle, GFXLibrary.messageboxtop_right);
			this.backgroundImage.SpecialGradient = true;
			this.backgroundImage.Position = new Point(0, 30);
			this.backgroundImage.Size = new Size(base.Width, num - 30);
			base.addControl(this.backgroundImage);
			this.captureLabel.Text = SK.Text("QuestLine_Collect_Reward", "Collect Reward");
			this.captureLabel.Color = global::ARGBColors.White;
			this.captureLabel.Position = new Point(13, 7);
			this.captureLabel.Size = new Size(335, 20);
			this.captureLabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.captureLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.headerBarImage.addControl(this.captureLabel);
			this.strip1.Image = GFXLibrary.quest_popup_hz_strip_02;
			this.strip1.Position = new Point(4, 4);
			this.backgroundImage.addControl(this.strip1);
			this.questIcon.Image = GFXLibrary.quest_icons[Math.Min(newQuestDef.questType, GFXLibrary.quest_icons.Length - 1)];
			this.questIcon.Position = new Point(12, 12);
			this.backgroundImage.addControl(this.questIcon);
			this.lblQuestName.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef.tagString);
			this.lblQuestName.Color = global::ARGBColors.Black;
			this.lblQuestName.Position = new Point(70, 26);
			this.lblQuestName.Size = new Size(700, 30);
			this.lblQuestName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
			this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_LEFT;
			this.backgroundImage.addControl(this.lblQuestName);
			this.strip2.Image = GFXLibrary.quest_popup_hz_strip_01;
			this.strip2.Position = new Point(24, 79);
			this.backgroundImage.addControl(this.strip2);
			NewQuestsPanel.addRewardIcons(this.backgroundImage, new Point(30, 80), newQuestDef, 0);
			this.collectButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.collectButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.collectButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.collectButton.Position = new Point(385, 87);
			this.collectButton.Text.Text = SK.Text("QUESTS_Collect", "Collect");
			this.collectButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.collectButton.Text.Color = global::ARGBColors.Black;
			this.collectButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.okClicked), "NewQuests_Collect_Clicked");
			this.backgroundImage.addControl(this.collectButton);
			if (newQuestDef.reward_charges.Length > 0)
			{
				this.chargesImage.Image = GFXLibrary.quest_rewards[9];
				this.chargesImage.Position = new Point(25, num - 82);
				this.chargesImage.CustomTooltipID = 3212;
				this.backgroundImage.addControl(this.chargesImage);
			}
			if (newQuestDef.reward_apples > 0 || newQuestDef.reward_stone > 0 || newQuestDef.reward_wood > 0)
			{
				if (userVillageIDList.Count > 1)
				{
					this.strip4.Image = GFXLibrary.quest_popup_hz_strip_03;
					this.strip4.Position = new Point(24, 151);
					this.backgroundImage.addControl(this.strip4);
					this.collectButton.Enabled = false;
					this.villageIcon.Image = GFXLibrary.char_village_icons[5];
					this.villageIcon.Position = new Point(30, 148);
					this.backgroundImage.addControl(this.villageIcon);
					if (Program.mySettings.LanguageIdent == "fr")
					{
						this.targetVillageLabel.Text = "Village Cible";
					}
					else
					{
						this.targetVillageLabel.Text = SK.Text("VillageArmiesPanel_Target_Village", "Target Village");
					}
					this.targetVillageLabel.Color = global::ARGBColors.Black;
					this.targetVillageLabel.Position = new Point(0, 130);
					this.targetVillageLabel.Size = new Size(base.Width, 30);
					this.targetVillageLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.targetVillageLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
					this.backgroundImage.addControl(this.targetVillageLabel);
					this.villageNameLabel.Text = SK.Text("QUESTS_Pick_a_Village", "Pick a Village");
					this.villageNameLabel.Color = global::ARGBColors.Black;
					this.villageNameLabel.Position = new Point(90, 146);
					this.villageNameLabel.Size = new Size(base.Width - 90, this.villageIcon.Height);
					this.villageNameLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
					this.villageNameLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
					this.backgroundImage.addControl(this.villageNameLabel);
					this.questsScrollArea.Position = new Point(61, 200);
					this.questsScrollArea.Size = new Size(390, 115);
					this.questsScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(390, 115));
					this.backgroundImage.addControl(this.questsScrollArea);
					this.insetImage.Position = new Point(55, 198);
					this.insetImage.Size = new Size(440, 119);
					this.backgroundImage.addControl(this.insetImage);
					this.insetImage.Create(GFXLibrary.quest_popup_inset_top, GFXLibrary.quest_popup_inset_middle, GFXLibrary.quest_popup_inset_bottom);
					this.questsScrollBar.Position = new Point(461, 205);
					this.questsScrollBar.Size = new Size(24, 105);
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
					this.addVillages(true);
				}
				else if (userVillageIDList.Count > 0)
				{
					this.m_villageID = userVillageIDList[0];
				}
			}
			if (newQuestDef.getRewardGlory() > 0 && flag)
			{
				this.orLabel.Text = SK.Text("QUESTS_or", "Or");
				this.orLabel.Color = global::ARGBColors.Black;
				this.orLabel.Position = new Point(0, num - 145);
				this.orLabel.Size = new Size(base.Width, 30);
				this.orLabel.Font = FontManager.GetFont("Arial", 10f, FontStyle.Bold);
				this.orLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.TOP_CENTER;
				this.backgroundImage.addControl(this.orLabel);
				this.strip3.Image = GFXLibrary.quest_popup_hz_strip_01;
				this.strip3.Position = new Point(24, num - 123 - 1);
				this.backgroundImage.addControl(this.strip3);
				NewQuestsPanel.addRewardIcons(this.backgroundImage, new Point(30, num - 123), newQuestDef, -1);
				this.collectGloryButton.ImageNorm = GFXLibrary.misc_button_blue_210wide_normal;
				this.collectGloryButton.ImageOver = GFXLibrary.misc_button_blue_210wide_over;
				this.collectGloryButton.ImageClick = GFXLibrary.misc_button_blue_210wide_pushed;
				this.collectGloryButton.Position = new Point(316, num - 123 + 8 - 1);
				this.collectGloryButton.Text.Text = SK.Text("QUESTS_Collect_Glory", "Collect Glory");
				this.collectGloryButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
				this.collectGloryButton.Text.Color = global::ARGBColors.Black;
				this.collectGloryButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.okGloryClicked), "NewQuests_Collect_Glory_Clicked");
				this.backgroundImage.addControl(this.collectGloryButton);
			}
			this.cancelButton.ImageNorm = GFXLibrary.mail2_button_blue_141wide_normal;
			this.cancelButton.ImageOver = GFXLibrary.mail2_button_blue_141wide_over;
			this.cancelButton.ImageClick = GFXLibrary.mail2_button_blue_141wide_pushed;
			this.cancelButton.Position = new Point(385, num - 75);
			this.cancelButton.Text.Text = SK.Text("GENERIC_Cancel", "Cancel");
			this.cancelButton.Text.Font = FontManager.GetFont("Arial", 9f, FontStyle.Bold);
			this.cancelButton.Text.Color = global::ARGBColors.Black;
			this.cancelButton.setClickDelegate(delegate()
			{
				InterfaceMgr.Instance.closeNewQuestRewardPopup();
				InterfaceMgr.Instance.ParentForm.TopMost = true;
				InterfaceMgr.Instance.ParentForm.TopMost = false;
			}, "NewQuests_Cancel");
			this.backgroundImage.addControl(this.cancelButton);
			base.Invalidate();
			parent.Invalidate();
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x0019F568 File Offset: 0x0019D768
		private void wallScrollBarMoved()
		{
			int value = this.questsScrollBar.Value;
			this.questsScrollArea.Position = new Point(this.questsScrollArea.X, 200 - value);
			this.questsScrollArea.ClipRect = new Rectangle(this.questsScrollArea.ClipRect.X, value, this.questsScrollArea.ClipRect.Width, this.questsScrollArea.ClipRect.Height);
			this.questsScrollArea.invalidate();
			this.questsScrollBar.invalidate();
			this.insetImage.invalidate();
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x0001A43A File Offset: 0x0001863A
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

		// Token: 0x06001A3D RID: 6717 RVA: 0x0019F610 File Offset: 0x0019D810
		public void okClicked()
		{
			this.m_questDef = NewQuests.getNewQuestDef(this.m_questID);
			VillageMap village = GameEngine.Instance.getVillage(this.m_villageID);
			if (village == null)
			{
				this.confirmAvailableSpace();
				return;
			}
			VillageMap.StockpileLevels stockpileLevels = new VillageMap.StockpileLevels();
			VillageMap.GranaryLevels granaryLevels = new VillageMap.GranaryLevels();
			village.getStockpileLevels(stockpileLevels);
			village.getGranaryLevels(granaryLevels);
			bool flag = false;
			if (this.m_questDef.reward_apples > 0)
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, 18, false);
				num *= CardTypes.getResourceCapMultiplier(18, GameEngine.Instance.cardsManager.UserCardData);
				double value = num - granaryLevels.fishLevel;
				if (Convert.ToInt32(value) < this.m_questDef.reward_apples)
				{
					flag = true;
				}
			}
			if (this.m_questDef.reward_stone > 0 && !flag)
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, 7, false);
				num *= CardTypes.getResourceCapMultiplier(7, GameEngine.Instance.cardsManager.UserCardData);
				double value = num - stockpileLevels.stoneLevel;
				if (Convert.ToInt32(value) < this.m_questDef.reward_stone)
				{
					flag = true;
				}
			}
			if (this.m_questDef.reward_wood > 0 && !flag)
			{
				double num = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, 6, false);
				num *= CardTypes.getResourceCapMultiplier(6, GameEngine.Instance.cardsManager.UserCardData);
				double value = num - stockpileLevels.woodLevel;
				if (Convert.ToInt32(value) < this.m_questDef.reward_wood)
				{
					flag = true;
				}
			}
			if (!flag || MyMessageBox.Show(SK.Text("Quest_Reward_Insufficient_Space", "You do not have enough room to store all of the reward at this village. Are you sure you want to send the reward to this village?"), SK.Text("Quest_Reward_Insufficient_Space_header", "Insufficient Space"), MessageBoxButtons.YesNo) != DialogResult.No)
			{
				this.CompleteQuest();
			}
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x0019F7F8 File Offset: 0x0019D9F8
		private void CompleteQuest()
		{
			this.m_questPanel.doCompleteQuest(this.m_questID, this.m_villageID, false);
			InterfaceMgr.Instance.closeNewQuestRewardPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x0001A45F File Offset: 0x0001865F
		public void okGloryClicked()
		{
			if (MyMessageBox.Show(SK.Text("Quest_Reward_Glory_Confirm", "If you select this option you will receive glory points, but no other rewards. Do you wish to continue?"), SK.Text("Quest_Reward_Glory_Title", "Confirm Selection"), MessageBoxButtons.YesNo) != DialogResult.No)
			{
				this.StillRecieveGloryPoints();
			}
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x0001A48E File Offset: 0x0001868E
		private void StillRecieveGloryPoints()
		{
			this.m_questPanel.doCompleteQuest(this.m_questID, -1, true);
			InterfaceMgr.Instance.closeNewQuestRewardPopup();
			InterfaceMgr.Instance.ParentForm.TopMost = true;
			InterfaceMgr.Instance.ParentForm.TopMost = false;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void update()
		{
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x0019F848 File Offset: 0x0019DA48
		private void addVillages(bool autoSelect)
		{
			List<int> userVillageIDList = GameEngine.Instance.World.getUserVillageIDList();
			userVillageIDList.Sort(UserInfoScreen2.villageComparer);
			this.questsScrollArea.clearControls();
			int num = 0;
			for (int i = 0; i < userVillageIDList.Count; i++)
			{
				int num2 = userVillageIDList[i];
				NewQuestRewardPanel.NewQuestVillageLine newQuestVillageLine = new NewQuestRewardPanel.NewQuestVillageLine();
				newQuestVillageLine.Position = new Point(0, num);
				bool selected = num2 == this.m_villageID;
				newQuestVillageLine.init(num2, this, i, selected);
				this.questsScrollArea.addControl(newQuestVillageLine);
				num += newQuestVillageLine.Height;
			}
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
			if (autoSelect && userVillageIDList.Count == 1)
			{
				this.villageSelected(userVillageIDList[0]);
			}
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x0019F97C File Offset: 0x0019DB7C
		public void villageSelected(int villageID)
		{
			this.villageNameLabel.Text = GameEngine.Instance.World.getVillageName(villageID);
			this.collectButton.Enabled = true;
			this.m_villageID = villageID;
			int villageSize = GameEngine.Instance.World.getVillageSize(villageID);
			this.villageIcon.Image = GFXLibrary.char_village_icons[villageSize];
			int value = this.questsScrollBar.Value;
			this.addVillages(false);
			this.questsScrollBar.Value = value;
			this.questsScrollBar.scrollDown(0);
			this.wallScrollBarMoved();
			base.Invalidate();
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x0019FA18 File Offset: 0x0019DC18
		public void confirmAvailableSpace()
		{
			if (!this.m_awaitingResponse)
			{
				if (!this.m_AppleChecked && this.m_questDef.reward_apples > 0)
				{
					this.m_buildingType = 18;
					this.checkResource();
					return;
				}
				if (!this.m_WoodChecked && this.m_questDef.reward_wood > 0)
				{
					this.m_buildingType = 6;
					this.checkResource();
					return;
				}
				if (!this.m_StoneChecked && this.m_questDef.reward_stone > 0)
				{
					this.m_buildingType = 7;
					this.checkResource();
					return;
				}
				if ((this.m_AppleAvailable && this.m_WoodAvailable && this.m_StoneAvailable) || MyMessageBox.Show(SK.Text("Quest_Reward_Insufficient_Space", "You do not have enough room to store all of the reward at this village. Are you sure you want to send the reward to this village?"), SK.Text("Quest_Reward_Insufficient_Space_header", "Insufficient Space"), MessageBoxButtons.YesNo) != DialogResult.No)
				{
					this.CompleteQuest();
				}
			}
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x0001A4CD File Offset: 0x000186CD
		public void checkResource()
		{
			this.m_awaitingResponse = true;
			RemoteServices.Instance.set_GetResourceLevel_UserCallBack(new RemoteServices.GetResourceLevel_UserCallBack(this.checkResourceCallBack));
			RemoteServices.Instance.GetResourceLevel(this.m_villageID, this.m_buildingType);
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x0019FAE4 File Offset: 0x0019DCE4
		public void checkResourceCallBack(GetResourceLevel_ReturnType returnData)
		{
			this.m_awaitingResponse = false;
			double value = GameEngine.Instance.World.UserResearchData.getResourceCap(GameEngine.Instance.LocalWorldData, this.m_buildingType, false) - returnData.uncappedLevel;
			int buildingType = this.m_buildingType;
			if (buildingType != 6)
			{
				if (buildingType != 7)
				{
					if (buildingType != 18)
					{
						return;
					}
					this.m_AppleChecked = true;
					this.m_AppleAvailable = (Convert.ToInt32(value) >= this.m_questDef.reward_apples);
				}
				else
				{
					this.m_StoneChecked = true;
					this.m_StoneAvailable = (Convert.ToInt32(value) >= this.m_questDef.reward_stone);
				}
			}
			else
			{
				this.m_WoodChecked = true;
				this.m_WoodAvailable = (Convert.ToInt32(value) >= this.m_questDef.reward_wood);
			}
			this.confirmAvailableSpace();
		}

		// Token: 0x04002AF1 RID: 10993
		private IContainer components;

		// Token: 0x04002AF2 RID: 10994
		private CustomSelfDrawPanel.CSDHorzExtendingPanel headerBarImage = new CustomSelfDrawPanel.CSDHorzExtendingPanel();

		// Token: 0x04002AF3 RID: 10995
		private CustomSelfDrawPanel.CSDLabel captureLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AF4 RID: 10996
		private CustomSelfDrawPanel.CSDFill backgroundImage = new CustomSelfDrawPanel.CSDFill();

		// Token: 0x04002AF5 RID: 10997
		private CustomSelfDrawPanel.CSDButton collectButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AF6 RID: 10998
		private CustomSelfDrawPanel.CSDButton collectGloryButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AF7 RID: 10999
		private CustomSelfDrawPanel.CSDButton cancelButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002AF8 RID: 11000
		private CustomSelfDrawPanel.CSDImage strip1 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AF9 RID: 11001
		private CustomSelfDrawPanel.CSDImage strip2 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AFA RID: 11002
		private CustomSelfDrawPanel.CSDImage strip3 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AFB RID: 11003
		private CustomSelfDrawPanel.CSDImage strip4 = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AFC RID: 11004
		private CustomSelfDrawPanel.CSDImage questIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002AFD RID: 11005
		private CustomSelfDrawPanel.CSDLabel lblQuestName = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AFE RID: 11006
		private CustomSelfDrawPanel.CSDLabel orLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002AFF RID: 11007
		private CustomSelfDrawPanel.CSDImage villageIcon = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B00 RID: 11008
		private CustomSelfDrawPanel.CSDLabel targetVillageLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B01 RID: 11009
		private CustomSelfDrawPanel.CSDLabel villageNameLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B02 RID: 11010
		private CustomSelfDrawPanel.CSDImage chargesImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B03 RID: 11011
		private CustomSelfDrawPanel.CSDVertScrollBar questsScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002B04 RID: 11012
		private CustomSelfDrawPanel.CSDArea questsScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002B05 RID: 11013
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002B06 RID: 11014
		private CustomSelfDrawPanel.CSDVertExtendingPanel insetImage = new CustomSelfDrawPanel.CSDVertExtendingPanel();

		// Token: 0x04002B07 RID: 11015
		private int m_questID = -1;

		// Token: 0x04002B08 RID: 11016
		private int m_villageID = -1;

		// Token: 0x04002B09 RID: 11017
		private NewQuestsPanel m_questPanel;

		// Token: 0x04002B0A RID: 11018
		private NewQuests.NewQuestDefinition m_questDef;

		// Token: 0x04002B0B RID: 11019
		private bool m_AppleChecked;

		// Token: 0x04002B0C RID: 11020
		private bool m_AppleAvailable = true;

		// Token: 0x04002B0D RID: 11021
		private bool m_WoodChecked;

		// Token: 0x04002B0E RID: 11022
		private bool m_WoodAvailable = true;

		// Token: 0x04002B0F RID: 11023
		private bool m_StoneChecked;

		// Token: 0x04002B10 RID: 11024
		private bool m_StoneAvailable = true;

		// Token: 0x04002B11 RID: 11025
		private int m_buildingType;

		// Token: 0x04002B12 RID: 11026
		private bool m_awaitingResponse;

		// Token: 0x04002B13 RID: 11027
		[CompilerGenerated]
		private static CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate _003C_003E9__CachedAnonymousMethodDelegate1;

		// Token: 0x02000253 RID: 595
		public class NewQuestVillageLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001A47 RID: 6727 RVA: 0x0019FBB0 File Offset: 0x0019DDB0
			public void init(int villageID, NewQuestRewardPanel parent, int position, bool selected)
			{
				this.m_villageID = villageID;
				this.m_parent = parent;
				this.clearControls();
				if (selected)
				{
					this.backgroundImage.Image = GFXLibrary.quest_popup_inset_highlight;
					this.backgroundImage.Position = new Point(0, 5);
					this.backgroundImage.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
					base.addControl(this.backgroundImage);
				}
				base.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				this.Size = new Size(390, 34);
				int villageSize = GameEngine.Instance.World.getVillageSize(villageID);
				this.villageIcon.Image = GFXLibrary.char_village_icons[villageSize];
				this.villageIcon.Position = new Point(0, -8);
				this.villageIcon.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.addControl(this.villageIcon);
				this.villageName.Text = GameEngine.Instance.World.getVillageName(villageID);
				this.villageName.Color = global::ARGBColors.Black;
				this.villageName.Position = new Point(50, 0);
				this.villageName.Size = new Size(330, base.Height);
				this.villageName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.villageName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.villageName.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.lineClicked));
				base.addControl(this.villageName);
			}

			// Token: 0x06001A48 RID: 6728 RVA: 0x0000A849 File Offset: 0x00008A49
			public bool update(double localTime)
			{
				return true;
			}

			// Token: 0x06001A49 RID: 6729 RVA: 0x0001A502 File Offset: 0x00018702
			private void lineClicked()
			{
				GameEngine.Instance.playInterfaceSound("NewQuests_Village_Clicked");
				this.m_parent.villageSelected(this.m_villageID);
			}

			// Token: 0x04002B14 RID: 11028
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B15 RID: 11029
			private CustomSelfDrawPanel.CSDImage villageIcon = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B16 RID: 11030
			private CustomSelfDrawPanel.CSDLabel villageName = new CustomSelfDrawPanel.CSDLabel();

			// Token: 0x04002B17 RID: 11031
			private NewQuestRewardPanel m_parent;

			// Token: 0x04002B18 RID: 11032
			private int m_villageID = -1;
		}
	}
}
