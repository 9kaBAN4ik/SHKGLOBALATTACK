using System;
using System.Globalization;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x02000245 RID: 581
	public class MonksManager
	{
		// Token: 0x060019B5 RID: 6581 RVA: 0x00199F20 File Offset: 0x00198120
		public string getDescription(int command, double hours, int numMonks)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			switch (command)
			{
			case 1:
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Increase_Popularity", "Increase Popularity within the Parish by :"),
					" ",
					numMonks.ToString(),
					" (",
					SK.Text("TOOLTIP_CARD_DURATION", "Duration"),
					" : ",
					hours.ToString("N", nfi),
					" ",
					SK.Text("ResearchEffect_X_Hours", "hours"),
					")"
				});
			case 2:
			case 8:
			{
				int votes = this.getVotes(numMonks);
				if (votes != 1)
				{
					return string.Concat(new string[]
					{
						SK.Text("SendMonksPanel_Send_Influence", "Influence Election by :"),
						" ",
						votes.ToString(),
						" ",
						SK.Text("SendMonksPanel_X_Votes", "votes")
					});
				}
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Send_Influence", "Influence Election by :"),
					" ",
					votes.ToString(),
					" ",
					SK.Text("SendMonksPanel_X_Vote", "vote")
				});
			}
			case 3:
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Descrease_Popularity", "Decrease Popularity within the Parish by :"),
					" ",
					numMonks.ToString(),
					" (",
					SK.Text("TOOLTIP_CARD_DURATION", "Duration"),
					" : ",
					hours.ToString("N", nfi),
					" ",
					SK.Text("ResearchEffect_X_Hours", "hours"),
					")"
				});
			case 4:
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Protect", "Protect the Village from attack for :"),
					" ",
					hours.ToString(),
					" ",
					SK.Text("ResearchEffect_X_Hours", "hours")
				});
			case 5:
			{
				string str = this.getRestoration(numMonks).ToString();
				return SK.Text("SendMonksPanel_Remove_Disease", "Points of Disease healed :") + " " + str;
			}
			case 6:
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Reduce_Excommunication", "Reduce Excommunication Time in Village by :"),
					" ",
					hours.ToString("N", nfi),
					" ",
					SK.Text("ResearchEffect_X_Hours", "hours")
				});
			case 7:
				return string.Concat(new string[]
				{
					SK.Text("SendMonksPanel_Remove_Powers", "Remove Church powers from the Village for :"),
					" ",
					hours.ToString("N", nfi),
					" ",
					SK.Text("ResearchEffect_X_Hours", "hours")
				});
			default:
				return "Select an ability";
			}
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x0019A228 File Offset: 0x00198428
		public double getEffectDuration(int command, int numMonks)
		{
			double num = 0.0;
			int num2 = (int)GameEngine.Instance.World.UserResearchData.Research_Marriage;
			if (num2 < 1)
			{
				num2 = 1;
			}
			int num3 = (int)GameEngine.Instance.World.UserResearchData.Research_Confirmation;
			if (num3 < 1)
			{
				num3 = 1;
			}
			int num4 = (int)GameEngine.Instance.World.UserResearchData.Research_Confession;
			if (num4 < 1)
			{
				num4 = 1;
			}
			int num5 = (int)GameEngine.Instance.World.UserResearchData.Research_ExtremeUnction;
			if (num5 < 1)
			{
				num5 = 1;
			}
			switch (command)
			{
			case 1:
				num = (double)ResearchData.blessingTimes[num2];
				num *= CardTypes.getBlessingMultipier(GameEngine.Instance.cardsManager.UserCardData);
				break;
			case 3:
				num = (double)ResearchData.confirmationTimes[num3];
				num *= CardTypes.getInquisitionMultipier(GameEngine.Instance.cardsManager.UserCardData);
				break;
			case 4:
				num = (double)(numMonks * 4);
				num = (double)CardTypes.adjustInterdictionLevel(GameEngine.Instance.cardsManager.UserCardData, (int)num);
				break;
			case 6:
				num = (double)(ResearchData.confessionTimes[num4] * numMonks);
				num = CardTypes.adjustAbsolutionLevel(GameEngine.Instance.cardsManager.UserCardData, num);
				break;
			case 7:
				num = (double)(ResearchData.extremeUnctionTimes[num5] * numMonks);
				num = CardTypes.adjustExcommunicationLevel(GameEngine.Instance.cardsManager.UserCardData, num);
				break;
			}
			return num;
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x0019A384 File Offset: 0x00198584
		public int getRestoration(int numMonks)
		{
			int num = (int)GameEngine.Instance.World.UserResearchData.Research_Baptism;
			if (num < 1)
			{
				num = 1;
			}
			int currentLevel = numMonks * ResearchData.baptismRestoreAmount[num];
			return CardTypes.adjustRestorationLevel(GameEngine.Instance.cardsManager.UserCardData, currentLevel);
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x0019A3CC File Offset: 0x001985CC
		public int getVotes(int numMonks)
		{
			int influenceMultipier = CardTypes.getInfluenceMultipier(GameEngine.Instance.cardsManager.UserCardData);
			return influenceMultipier * numMonks;
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x0019A3F4 File Offset: 0x001985F4
		public int getBasePoints(int command, int targetVillageID, int targetUserRank)
		{
			switch (command)
			{
			case 1:
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Blessings;
			case 2:
			case 8:
				if (GameEngine.Instance.World.isCountyCapital(targetVillageID))
				{
					return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Influence * 2;
				}
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Influence;
			case 3:
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Inquisition;
			case 4:
				if (GameEngine.Instance.World.isCapital(targetVillageID))
				{
					return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Interdicts * 10;
				}
				return TradingCalcs.adjustInterdictionCostByTargetRank(GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Interdicts, targetUserRank, GameEngine.Instance.World.SecondAgeWorld);
			case 5:
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Restoration;
			case 6:
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Absolution;
			case 7:
				return GameEngine.Instance.LocalWorldData.MonkCommandPointsCost_Excommunication;
			default:
				return 0;
			}
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x0019A500 File Offset: 0x00198700
		public void sendMonks(RemoteServices.SendPeople_UserCallBack uicallback, int numMonks, int currentCommand, int votedUser)
		{
			this.m_uicallback = uicallback;
			if (numMonks > 0)
			{
				int data = -1;
				if (currentCommand == 2 || currentCommand == 8)
				{
					data = votedUser;
				}
				RemoteServices.Instance.set_SendPeople_UserCallBack(new RemoteServices.SendPeople_UserCallBack(this.sendPeopleCallback));
				RemoteServices.Instance.SendPeople(InterfaceMgr.Instance.OwnSelectedVillage, InterfaceMgr.Instance.SelectedVillage, 4, numMonks, currentCommand, data);
				AllVillagesPanel.travellersChanged();
			}
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x0019A564 File Offset: 0x00198764
		public void sendPeopleCallback(SendPeople_ReturnType returnData)
		{
			try
			{
				if (returnData.Success)
				{
					GameEngine.Instance.World.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
					GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("Got Exception sending monks: " + ex.Message.ToString());
			}
			if (this.m_uicallback != null)
			{
				this.m_uicallback(returnData);
			}
		}

		// Token: 0x04002A45 RID: 10821
		private RemoteServices.SendPeople_UserCallBack m_uicallback;
	}
}
