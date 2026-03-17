using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms.Properties;

namespace Kingdoms
{
	// Token: 0x020002A8 RID: 680
	public partial class QuestRewardPopup : MyFormBase
	{
		// Token: 0x06001E89 RID: 7817 RVA: 0x0001D256 File Offset: 0x0001B456
		public QuestRewardPopup()
		{
			this.InitializeComponent();
			this.Font = FontManager.GetFont("Microsoft Sans Serif", 8.25f);
		}

		// Token: 0x06001E8A RID: 7818 RVA: 0x001D78EC File Offset: 0x001D5AEC
		public void init(int quest)
		{
			this.btnOK.Text = SK.Text("GENERIC_OK", "OK");
			this.label1.Text = SK.Text("QuestRewardPopup_Reward", "Reward") + " : ";
			string text = this.Text = (base.Title = SK.Text("QuestRewardPopup_Quest_Reward", "Quest Reward"));
			bool flag = false;
			List<Quests.QuestReward> questRewards = Quests.getQuestRewards(quest, true, GameEngine.NFI);
			string text2 = "";
			bool flag2 = true;
			foreach (Quests.QuestReward questReward in questRewards)
			{
				if (!flag2)
				{
					text2 += ", ";
				}
				else
				{
					flag2 = false;
				}
				text2 += questReward.explanation;
				if (questReward.type == 20004 || questReward.type == 20006)
				{
					flag = true;
				}
			}
			this.lblReward.Text = text2;
			int questsTutorialStage = Tutorials.getQuestsTutorialStage(quest);
			if (questsTutorialStage == -1)
			{
				this.lblInfo.Text = "";
			}
			else
			{
				this.lblInfo.Text = Tutorials.getTutorialRewardText(questsTutorialStage);
			}
			if (flag)
			{
				PlayCardsWindow.resetRewardCardTimer();
			}
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x0001D279 File Offset: 0x0001B479
		private void btnOK_Click(object sender, EventArgs e)
		{
			GameEngine.Instance.playInterfaceSound("QuestRewardPopup_ok");
			base.Close();
		}
	}
}
