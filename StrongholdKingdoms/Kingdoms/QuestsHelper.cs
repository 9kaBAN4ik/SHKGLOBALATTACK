using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020002A9 RID: 681
	internal class QuestsHelper
	{
		// Token: 0x06001E8E RID: 7822 RVA: 0x001D7E44 File Offset: 0x001D6044
		public static int GetTarget(int questID)
		{
			int result = 0;
			if (questID >= 0)
			{
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(questID);
				if (questID != 29)
				{
					if (questID != 66)
					{
						if (questID != 146)
						{
							result = newQuestDef.parameter;
						}
						else
						{
							result = 8;
						}
					}
					else
					{
						result = 6;
					}
				}
				else
				{
					result = 4;
				}
			}
			return result;
		}

		// Token: 0x06001E8F RID: 7823 RVA: 0x001D7E88 File Offset: 0x001D6088
		public static int GetProgress(NewQuestsData questData)
		{
			int result = 0;
			if (questData != null && questData.questID >= 0)
			{
				NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(questData.questID);
				if (questData.completionState >= 0 && QuestsHelper.isQuestComplete(questData))
				{
					result = QuestsHelper.GetTarget(questData.questID);
				}
				else if (newQuestDef.parameter > 0 || questData.questID == 66 || questData.questID == 146 || questData.questID == 29)
				{
					int questID = questData.questID;
					if (questID <= 67)
					{
						if (questID <= 29)
						{
							if (questID != 5 && questID != 20)
							{
								if (questID != 29)
								{
									goto IL_119;
								}
								goto IL_10B;
							}
						}
						else if (questID != 42)
						{
							if (questID == 66)
							{
								goto IL_10B;
							}
							if (questID != 67)
							{
								goto IL_119;
							}
						}
					}
					else if (questID <= 140)
					{
						if (questID != 99 && questID != 125 && questID != 140)
						{
							goto IL_119;
						}
					}
					else if (questID <= 148)
					{
						if (questID == 146)
						{
							goto IL_10B;
						}
						if (questID != 148)
						{
							goto IL_119;
						}
					}
					else if (questID != 157 && questID != 167)
					{
						goto IL_119;
					}
					double currentGold = GameEngine.Instance.World.getCurrentGold();
					double num = currentGold - (double)questData.startingData;
					return (int)num;
					IL_10B:
					return QuestsHelper.bitCount(questData.data);
					IL_119:
					result = questData.data;
				}
			}
			return result;
		}

		// Token: 0x06001E90 RID: 7824 RVA: 0x001D7FB8 File Offset: 0x001D61B8
		private static bool shouldAutoCompleteOnMobile(int QuestID)
		{
			if (QuestID <= 34)
			{
				if (QuestID <= 4)
				{
					if (QuestID != 1 && QuestID != 4)
					{
						return false;
					}
				}
				else if (QuestID != 16 && QuestID != 34)
				{
					return false;
				}
			}
			else if (QuestID <= 64)
			{
				if (QuestID != 48 && QuestID != 64)
				{
					return false;
				}
			}
			else if (QuestID != 84 && QuestID != 101 && QuestID != 122)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06001E91 RID: 7825 RVA: 0x001D8008 File Offset: 0x001D6208
		public static bool IsInviteFriendQuest(int questID)
		{
			if (questID <= 48)
			{
				if (questID <= 16)
				{
					if (questID != 4 && questID != 16)
					{
						return false;
					}
				}
				else if (questID != 34 && questID != 48)
				{
					return false;
				}
			}
			else if (questID <= 84)
			{
				if (questID != 64 && questID != 84)
				{
					return false;
				}
			}
			else if (questID != 101 && questID != 122)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06001E92 RID: 7826 RVA: 0x001D8054 File Offset: 0x001D6254
		public static int bitCount(int n)
		{
			int num = 0;
			while (n != 0)
			{
				num++;
				n &= n - 1;
			}
			return num;
		}

		// Token: 0x06001E93 RID: 7827 RVA: 0x001D8074 File Offset: 0x001D6274
		public static bool isQuestComplete(NewQuestsData questData)
		{
			if (questData.completionState > 0 && questData.questID >= 0)
			{
				return true;
			}
			NewQuests.NewQuestDefinition newQuestDef = NewQuests.getNewQuestDef(questData.questID);
			if (newQuestDef == null)
			{
				return false;
			}
			int questID = questData.questID;
			if (questID <= 67)
			{
				if (questID <= 29)
				{
					if (questID != 5 && questID != 20)
					{
						if (questID != 29)
						{
							goto IL_F3;
						}
						if (questData.data == 15)
						{
							return true;
						}
						return false;
					}
				}
				else if (questID != 42)
				{
					if (questID != 66)
					{
						if (questID != 67)
						{
							goto IL_F3;
						}
					}
					else
					{
						if (questData.data == 63)
						{
							return true;
						}
						return false;
					}
				}
			}
			else if (questID <= 140)
			{
				if (questID != 99 && questID != 125 && questID != 140)
				{
					goto IL_F3;
				}
			}
			else if (questID <= 148)
			{
				if (questID != 146)
				{
					if (questID != 148)
					{
						goto IL_F3;
					}
				}
				else
				{
					if (questData.data == 255)
					{
						return true;
					}
					return false;
				}
			}
			else if (questID != 157 && questID != 167)
			{
				goto IL_F3;
			}
			double currentGold = GameEngine.Instance.World.getCurrentGold();
			double num = currentGold - (double)questData.startingData;
			if (num >= (double)newQuestDef.parameter)
			{
				return true;
			}
			return false;
			IL_F3:
			if (newQuestDef.parameter == 0)
			{
				if (questData.data > 0)
				{
					return true;
				}
			}
			else if (questData.data >= newQuestDef.parameter)
			{
				return true;
			}
			return false;
		}

		// Token: 0x06001E94 RID: 7828 RVA: 0x001D8198 File Offset: 0x001D6398
		public static string GetObjectiveString(NewQuests.NewQuestDefinition def)
		{
			int id = def.ID;
			if (id <= 48)
			{
				if (id <= 16)
				{
					if (id != 4 && id != 16)
					{
						goto IL_53;
					}
				}
				else if (id != 34 && id != 48)
				{
					goto IL_53;
				}
			}
			else if (id <= 84)
			{
				if (id != 64 && id != 84)
				{
					goto IL_53;
				}
			}
			else if (id != 101 && id != 122)
			{
				goto IL_53;
			}
			return SK.Text("QUESTS_Spread_New_description", "Learn about Invite a Friend");
			IL_53:
			return SK.NoStoreText("Z_QUEST_DESCRIPTIONS_" + def.tagString);
		}

		// Token: 0x04002F56 RID: 12118
		public static bool questReadyToHandIn;
	}
}
