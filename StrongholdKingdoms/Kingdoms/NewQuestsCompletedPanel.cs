using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000256 RID: 598
	public class NewQuestsCompletedPanel : CustomSelfDrawPanel
	{
		// Token: 0x06001A53 RID: 6739 RVA: 0x0001A5F8 File Offset: 0x000187F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x0001A617 File Offset: 0x00018817
		private void InitializeComponent()
		{
			this.components = new Container();
			base.AutoScaleMode = AutoScaleMode.None;
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x0019FE80 File Offset: 0x0019E080
		public NewQuestsCompletedPanel()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x0001A62B File Offset: 0x0001882B
		public void setCompletedQuests(List<int> quests)
		{
			this.completedQuests = quests;
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x0019FEFC File Offset: 0x0019E0FC
		public void init(Form parent, bool forQuestList, string questTag, int questID)
		{
			this.m_parent = parent;
			base.clearControls();
			this.isQuestList = forQuestList;
			this.questText = questTag;
			this._questID = questID;
			this.mainBackgroundImage.Image = GFXLibrary.mail2_mail_panel_middle_middle;
			this.mainBackgroundImage.ClipRect = new Rectangle(default(Point), base.Size);
			this.mainBackgroundImage.Position = new Point(0, 0);
			this.mainBackgroundImage.Size = base.Size;
			base.addControl(this.mainBackgroundImage);
			this.questsScrollArea.Position = new Point(27, 30);
			this.questsScrollArea.Size = new Size(409, 304);
			this.questsScrollArea.ClipRect = new Rectangle(new Point(0, 0), new Size(409, 304));
			this.mainBackgroundImage.addControl(this.questsScrollArea);
			this.questsScrollBar.Position = new Point(444, 35);
			this.questsScrollBar.Size = new Size(24, 294);
			this.mainBackgroundImage.addControl(this.questsScrollBar);
			this.questsScrollBar.Value = 0;
			this.questsScrollBar.Max = 100;
			this.questsScrollBar.NumVisibleLines = 25;
			this.questsScrollBar.Create(null, null, null, GFXLibrary._24wide_thumb_top, GFXLibrary._24wide_thumb_middle, GFXLibrary._24wide_thumb_bottom);
			this.questsScrollBar.setValueChangeDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ValueChangedDelegate(this.wallScrollBarMoved));
			this.mouseWheelOverlay.Position = this.questsScrollArea.Position;
			this.mouseWheelOverlay.Size = this.questsScrollArea.Size;
			this.mouseWheelOverlay.setMouseWheelDelegate(new CustomSelfDrawPanel.CSDControl.CSD_MouseWheelDelegate(this.mouseWheelMoved));
			this.mainBackgroundImage.addControl(this.mouseWheelOverlay);
			this.overlayImage.Image = GFXLibrary.char_achievementOverlay;
			this.overlayImage.Position = new Point(0, 0);
			this.mainBackgroundImage.addControl(this.overlayImage);
			this.closeButton.ImageNorm = GFXLibrary.int_button_close_normal;
			this.closeButton.ImageOver = GFXLibrary.int_button_close_over;
			this.closeButton.ImageClick = GFXLibrary.int_button_close_in;
			this.closeButton.Position = new Point(base.Width - 40, 0);
			this.closeButton.setClickDelegate(new CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate(this.closeClick), "NewQuestsCompletedPanel_close");
			this.overlayImage.addControl(this.closeButton);
			if (forQuestList)
			{
				this.headerLabel.Font = FontManager.GetFont("Arial", 14f, FontStyle.Bold);
				this.headerLabel.Text = SK.Text("QUESTS_CompletedQuests", "Completed Quests");
			}
			else
			{
				this.headerLabel.Font = FontManager.GetFont("Arial", 11f, FontStyle.Regular);
				this.headerLabel.Text = SK.NoStoreText("Z_QUESTS_" + this.questText) + " - ";
				CustomSelfDrawPanel.CSDLabel csdlabel = this.headerLabel;
				csdlabel.Text += SK.Text("QUESTS_FurtherDetails", "Further Information");
			}
			this.headerLabel.Position = new Point(0, 0);
			this.headerLabel.Size = new Size(base.Width, 30);
			this.headerLabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
			this.headerLabel.Color = global::ARGBColors.White;
			this.headerLabel.DropShadowColor = global::ARGBColors.Black;
			this.overlayImage.addControl(this.headerLabel);
			this.rebuild();
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x0001A634 File Offset: 0x00018834
		private void closeClick()
		{
			this.m_parent.Close();
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x001A02C0 File Offset: 0x0019E4C0
		private void wallScrollBarMoved()
		{
			int value = this.questsScrollBar.Value;
			this.questsScrollArea.Position = new Point(this.questsScrollArea.X, 30 - value);
			this.questsScrollArea.ClipRect = new Rectangle(this.questsScrollArea.ClipRect.X, value, this.questsScrollArea.ClipRect.Width, this.questsScrollArea.ClipRect.Height);
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x0001A641 File Offset: 0x00018841
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

		// Token: 0x06001A5B RID: 6747 RVA: 0x001A0350 File Offset: 0x0019E550
		public void rebuild()
		{
			int num = 0;
			this.questsScrollArea.clearControls();
			if (this.isQuestList)
			{
				int[] array;
				if (this.completedQuests == null)
				{
					NewQuestsData newQuestData = GameEngine.Instance.World.getNewQuestData();
					if (newQuestData == null)
					{
						return;
					}
					array = newQuestData.completedQuests;
				}
				else
				{
					array = this.completedQuests.ToArray();
				}
				for (int i = 0; i < array.Length; i++)
				{
					int quest = array[i];
					NewQuestsCompletedPanel.NewQuestLine newQuestLine = new NewQuestsCompletedPanel.NewQuestLine();
					if (num != 0)
					{
						num += 5;
					}
					newQuestLine.Position = new Point(0, num);
					newQuestLine.init(quest, i);
					this.questsScrollArea.addControl(newQuestLine);
					num += newQuestLine.Height;
				}
			}
			else
			{
				CustomSelfDrawPanel.CSDLabel csdlabel = new CustomSelfDrawPanel.CSDLabel();
				int questID = this._questID;
				if (questID <= 48)
				{
					if (questID <= 16)
					{
						if (questID != 4 && questID != 16)
						{
							goto IL_14F;
						}
					}
					else if (questID != 34 && questID != 48)
					{
						goto IL_14F;
					}
				}
				else if (questID <= 84)
				{
					if (questID != 64 && questID != 84)
					{
						goto IL_14F;
					}
				}
				else if (questID != 101 && questID != 122)
				{
					goto IL_14F;
				}
				if (!GameEngine.Instance.World.isBigpointAccount && !Program.aeriaInstall && !Program.bigpointPartnerInstall && !Program.arcInstall)
				{
					csdlabel.Text = SK.Text("QUESTS_IAF_Help1", "Learn about how inviting your friends to the game can earn you up to $160 worth of crowns.");
					goto IL_16B;
				}
				csdlabel.Text = SK.Text("QUESTS_IAF_Help2", "Why not invite a friend to play Kingdoms? They can fight alongside you and you will help us to further develop the game. ");
				goto IL_16B;
				IL_14F:
				csdlabel.Text = SK.NoStoreText("Z_QUEST_HELP_" + this.questText);
				IL_16B:
				csdlabel.Color = global::ARGBColors.Black;
				csdlabel.Position = new Point(36, 30);
				csdlabel.Size = new Size(this.questsScrollArea.Width, this.questsScrollArea.Height);
				csdlabel.Font = FontManager.GetFont("Arial", 12f, FontStyle.Regular);
				csdlabel.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_CENTER;
				this.mainBackgroundImage.addControl(csdlabel);
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
			this.mainBackgroundImage.invalidate();
		}

		// Token: 0x04002B1D RID: 11037
		private IContainer components;

		// Token: 0x04002B1E RID: 11038
		private CustomSelfDrawPanel.CSDButton closeButton = new CustomSelfDrawPanel.CSDButton();

		// Token: 0x04002B1F RID: 11039
		private CustomSelfDrawPanel.CSDImage mainBackgroundImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B20 RID: 11040
		private CustomSelfDrawPanel.CSDImage overlayImage = new CustomSelfDrawPanel.CSDImage();

		// Token: 0x04002B21 RID: 11041
		private CustomSelfDrawPanel.CSDVertScrollBar questsScrollBar = new CustomSelfDrawPanel.CSDVertScrollBar();

		// Token: 0x04002B22 RID: 11042
		private CustomSelfDrawPanel.CSDArea questsScrollArea = new CustomSelfDrawPanel.CSDArea();

		// Token: 0x04002B23 RID: 11043
		private CustomSelfDrawPanel.CSDControl mouseWheelOverlay = new CustomSelfDrawPanel.CSDControl();

		// Token: 0x04002B24 RID: 11044
		private CustomSelfDrawPanel.CSDLabel headerLabel = new CustomSelfDrawPanel.CSDLabel();

		// Token: 0x04002B25 RID: 11045
		private Form m_parent;

		// Token: 0x04002B26 RID: 11046
		private bool isQuestList = true;

		// Token: 0x04002B27 RID: 11047
		private string questText;

		// Token: 0x04002B28 RID: 11048
		private int _questID;

		// Token: 0x04002B29 RID: 11049
		private List<int> completedQuests;

		// Token: 0x02000257 RID: 599
		public class NewQuestLine : CustomSelfDrawPanel.CSDControl
		{
			// Token: 0x06001A5C RID: 6748 RVA: 0x001A05C8 File Offset: 0x0019E7C8
			public void init(int quest, int position)
			{
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
				base.addControl(this.backgroundImage);
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(quest);
				this.Size = new Size(444, 60);
				this.questImage.Image = GFXLibrary.quest_icons[Math.Min(newQuestDef.questType, GFXLibrary.quest_icons.Length - 1)];
				this.questImage.Position = new Point(0, 6);
				base.addControl(this.questImage);
				this.lblQuestName.Text = SK.NoStoreText("Z_QUESTS_" + newQuestDef.tagString);
				this.lblQuestName.Color = global::ARGBColors.Black;
				this.lblQuestName.Position = new Point(9, 0);
				this.lblQuestName.Size = new Size(400, this.backgroundImage.Height);
				this.lblQuestName.Font = FontManager.GetFont("Arial", 12f, FontStyle.Bold);
				this.lblQuestName.Alignment = CustomSelfDrawPanel.CSD_Text_Alignment.CENTER_LEFT;
				this.backgroundImage.addControl(this.lblQuestName);
			}

			// Token: 0x04002B2A RID: 11050
			private CustomSelfDrawPanel.CSDImage backgroundImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B2B RID: 11051
			private CustomSelfDrawPanel.CSDImage questImage = new CustomSelfDrawPanel.CSDImage();

			// Token: 0x04002B2C RID: 11052
			private CustomSelfDrawPanel.CSDLabel lblQuestName = new CustomSelfDrawPanel.CSDLabel();
		}
	}
}
