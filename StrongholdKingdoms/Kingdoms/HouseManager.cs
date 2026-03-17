using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001FD RID: 509
	public class HouseManager
	{
		// Token: 0x06001426 RID: 5158 RVA: 0x00015C60 File Offset: 0x00013E60
		public void UpdateGloryPoints(HouseManager.HouseInfoUpdatedCallback callback)
		{
			this.UpdateGloryPoints(callback, false);
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x00015C6A File Offset: 0x00013E6A
		public void UpdateGloryPoints(HouseManager.HouseInfoUpdatedCallback callback, bool ignoreTest)
		{
			this.OnUpdate = callback;
			if (ignoreTest || GameEngine.Instance.World.testGloryPointsUpdate())
			{
				RemoteServices.Instance.set_GetHouseGloryPoints_UserCallBack(new RemoteServices.GetHouseGloryPoints_UserCallBack(this.GetHouseGloryPointsCallBack));
				RemoteServices.Instance.GetHouseGloryPoints();
			}
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x0015A084 File Offset: 0x00158284
		private void GetHouseGloryPointsCallBack(GetHouseGloryPoints_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.HouseGloryPoints = returnData.gloryPoints;
				GameEngine.Instance.World.HouseGloryRoundData = returnData.gloryRoundData;
				if (this.OnUpdate != null)
				{
					this.OnUpdate();
				}
			}
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0015A0D8 File Offset: 0x001582D8
		public void selfJoinHouse(RemoteServices.SelfJoinHouse_UserCallBack callback, int houseID)
		{
			this.joinHouseCallback = callback;
			RemoteServices.Instance.set_SelfJoinHouse_UserCallBack(new RemoteServices.SelfJoinHouse_UserCallBack(this.selfJoinHouseCallback));
			RemoteServices.Instance.SelfJoinHouse(RemoteServices.Instance.UserFactionID, houseID, GameEngine.Instance.World.StoredFactionChangesPos);
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0015A128 File Offset: 0x00158328
		public void selfJoinHouseCallback(SelfJoinHouse_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.factionsList != null)
				{
					GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
				}
				GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
			}
			if (this.joinHouseCallback != null)
			{
				this.joinHouseCallback(returnData);
			}
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0015A1B4 File Offset: 0x001583B4
		public void LeaveHouse(int houseID, HouseManager.HouseInfoUpdatedCallback callback)
		{
			RemoteServices.Instance.set_LeaveHouse_UserCallBack(new RemoteServices.LeaveHouse_UserCallBack(this.leaveHouseCallback));
			RemoteServices.Instance.LeaveHouse(RemoteServices.Instance.UserFactionID, houseID, GameEngine.Instance.World.StoredFactionChangesPos);
			this.OnUpdate = callback;
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x0015A204 File Offset: 0x00158404
		private void leaveHouseCallback(LeaveHouse_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.factionsList != null)
				{
					GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
				}
				GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
				GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x00015CA7 File Offset: 0x00013EA7
		public void houseVote(int targetFaction, bool application, bool vote, HouseManager.HouseInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_HouseVote_UserCallBack(new RemoteServices.HouseVote_UserCallBack(this.houseVoteCallback));
			RemoteServices.Instance.HouseVote(targetFaction, application, vote, GameEngine.Instance.World.StoredFactionChangesPos);
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0015A290 File Offset: 0x00158490
		private void houseVoteCallback(HouseVote_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.factionsList != null)
				{
					GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
				}
				GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x0015A31C File Offset: 0x0015851C
		public void houseVoteHouseLeader(int targetFaction, HouseManager.HouseInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			int houseID = 0;
			FactionData yourFaction = GameEngine.Instance.World.YourFaction;
			if (yourFaction != null)
			{
				houseID = yourFaction.houseID;
			}
			RemoteServices.Instance.set_HouseVoteHouseLeader_UserCallBack(new RemoteServices.HouseVoteHouseLeader_UserCallBack(this.houseVoteHouseLeaderCallback));
			RemoteServices.Instance.HouseVoteHouseLeader(RemoteServices.Instance.UserFactionID, houseID, targetFaction, GameEngine.Instance.World.StoredFactionChangesPos);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0015A388 File Offset: 0x00158588
		private void houseVoteHouseLeaderCallback(HouseVoteHouseLeader_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.factionsList != null)
				{
					GameEngine.Instance.World.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
				}
				GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.HouseVoteInfo = returnData.m_houseVoteData;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x040025E2 RID: 9698
		private HouseManager.HouseInfoUpdatedCallback OnUpdate;

		// Token: 0x040025E3 RID: 9699
		private RemoteServices.SelfJoinHouse_UserCallBack joinHouseCallback;

		// Token: 0x020001FE RID: 510
		// (Invoke) Token: 0x06001433 RID: 5171
		public delegate void HouseInfoUpdatedCallback();
	}
}
