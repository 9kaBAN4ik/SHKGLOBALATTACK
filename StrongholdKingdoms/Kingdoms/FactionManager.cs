using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020001BD RID: 445
	public class FactionManager
	{
		// Token: 0x060010B5 RID: 4277 RVA: 0x0001247B File Offset: 0x0001067B
		public void ApplyToFaction(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionApplication_UserCallBack(new RemoteServices.FactionApplication_UserCallBack(this.factionApplicationCallback));
			RemoteServices.Instance.FactionApplication(factionID);
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0011E9FC File Offset: 0x0011CBFC
		private void factionApplicationCallback(FactionApplication_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionInvites = returnData.invites;
				GameEngine.Instance.World.FactionApplications = returnData.applications;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x000124A5 File Offset: 0x000106A5
		public void MakeAlly(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(factionID, 1);
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x000124D0 File Offset: 0x000106D0
		public void MakeEnemy(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(factionID, -1);
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x000124FB File Offset: 0x000106FB
		public void BreakAlliance(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_CreateFactionRelationship_UserCallBack(new RemoteServices.CreateFactionRelationship_UserCallBack(this.createFactionRelationshipCallback));
			RemoteServices.Instance.CreateFactionRelationship(factionID, 0);
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0011EA54 File Offset: 0x0011CC54
		private void createFactionRelationshipCallback(CreateFactionRelationship_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
				GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0011EAAC File Offset: 0x0011CCAC
		public void declineClicked(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			if (GameEngine.Instance.World.YourFaction != null && factionID == GameEngine.Instance.World.YourFaction.factionID)
			{
				RemoteServices.Instance.set_FactionReplyToInvite_UserCallBack(new RemoteServices.FactionReplyToInvite_UserCallBack(this.factionReplyToInviteCallback));
				RemoteServices.Instance.FactionReplyToInvite(factionID, false);
				return;
			}
			RemoteServices.Instance.set_FactionApplication_UserCallBack(new RemoteServices.FactionApplication_UserCallBack(this.factionCancelApplicationCallback));
			RemoteServices.Instance.FactionApplicationCancel(factionID);
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0011E9FC File Offset: 0x0011CBFC
		public void factionCancelApplicationCallback(FactionApplication_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionInvites = returnData.invites;
				GameEngine.Instance.World.FactionApplications = returnData.applications;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x00012526 File Offset: 0x00010726
		public void acceptClicked(int factionID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionReplyToInvite_UserCallBack(new RemoteServices.FactionReplyToInvite_UserCallBack(this.factionReplyToInviteCallback));
			RemoteServices.Instance.FactionReplyToInvite(factionID, true);
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0011EB2C File Offset: 0x0011CD2C
		private void factionReplyToInviteCallback(FactionReplyToInvite_ReturnType returnData)
		{
			ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.FactionInvites = returnData.invites;
				GameEngine.Instance.World.FactionApplications = returnData.applications;
				if (returnData.yourFaction != null)
				{
					GameEngine.Instance.World.updateYourVillageFactions(returnData.yourFaction.factionID);
					GameEngine.Instance.World.FactionAllies = returnData.yourAllies;
					GameEngine.Instance.World.FactionEnemies = returnData.yourEnemies;
					GameEngine.Instance.World.HouseAllies = returnData.yourHouseAllies;
					GameEngine.Instance.World.HouseEnemies = returnData.yourHouseEnemies;
				}
				else
				{
					GameEngine.Instance.World.updateYourVillageFactions(-1);
				}
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x00012551 File Offset: 0x00010751
		public void RejectApplication(int userID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.factionApplicationProcessingCallback));
			RemoteServices.Instance.FactionApplicationReject(userID);
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x0001257B File Offset: 0x0001077B
		public void AcceptApplication(int userID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionApplicationProcessing_UserCallBack(new RemoteServices.FactionApplicationProcessing_UserCallBack(this.factionApplicationProcessingCallback));
			RemoteServices.Instance.FactionApplicationAccept(userID);
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0011EC54 File Offset: 0x0011CE54
		private void factionApplicationProcessingCallback(FactionApplicationProcessing_ReturnType returnData)
		{
			bool success = returnData.Success;
			if (returnData.members != null)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x000125A5 File Offset: 0x000107A5
		public void WithdrawInvite(int userID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionWithdrawInvite_UserCallBack(new RemoteServices.FactionWithdrawInvite_UserCallBack(this.factionWithdrawInviteCallback));
			RemoteServices.Instance.FactionWithdrawInvite(userID);
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x000125CF File Offset: 0x000107CF
		private void factionWithdrawInviteCallback(FactionWithdrawInvite_ReturnType returnData)
		{
			if (returnData.members != null)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0011ECB4 File Offset: 0x0011CEB4
		public void Promote(FactionMemberData memberData, FactionManager.FactionInfoUpdatedCallback callback)
		{
			int rank = memberData.status;
			if (memberData.status == 0)
			{
				rank = 2;
			}
			if (memberData.status == 2)
			{
				rank = 1;
			}
			this.changeRank(memberData.userID, rank, callback);
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0011ECEC File Offset: 0x0011CEEC
		public void Demote(FactionMemberData memberData, FactionManager.FactionInfoUpdatedCallback callback)
		{
			int rank = memberData.status;
			if (memberData.status == 1)
			{
				rank = 2;
			}
			if (memberData.status == 2)
			{
				rank = 0;
			}
			this.changeRank(memberData.userID, rank, callback);
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x00012607 File Offset: 0x00010807
		private void changeRank(int userID, int rank, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionChangeMemberStatus_UserCallBack(new RemoteServices.FactionChangeMemberStatus_UserCallBack(this.factionChangeMemberStatusCallback));
			RemoteServices.Instance.FactionChangeMemberStatus(userID, rank);
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x00012632 File Offset: 0x00010832
		public void dismissMember(int userID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionChangeMemberStatus_UserCallBack(new RemoteServices.FactionChangeMemberStatus_UserCallBack(this.factionChangeMemberStatusCallback));
			RemoteServices.Instance.FactionChangeMemberStatus(userID, -2);
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0011ED24 File Offset: 0x0011CF24
		private void factionChangeMemberStatusCallback(FactionChangeMemberStatus_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0001265E File Offset: 0x0001085E
		public void voteLeaderChange(int userID, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionLeadershipVote_UserCallBack(new RemoteServices.FactionLeadershipVote_UserCallBack(this.factionLeadershipVoteCallback));
			RemoteServices.Instance.FactionLeadershipVote(RemoteServices.Instance.UserFactionID, userID);
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0011ED7C File Offset: 0x0011CF7C
		private void factionLeadershipVoteCallback(FactionLeadershipVote_ReturnType returnData)
		{
			if (returnData.Success)
			{
				GameEngine.Instance.World.YourFactionVote = returnData.yourLeaderVote;
				if (returnData.leaderChanged)
				{
					RemoteServices.Instance.UserFactionID = returnData.yourFaction.factionID;
					GameEngine.Instance.World.YourFaction = returnData.yourFaction;
					GameEngine.Instance.World.FactionMembers = returnData.members;
					GameEngine.Instance.World.FactionInvites = returnData.invites;
					GameEngine.Instance.World.FactionApplications = returnData.applications;
				}
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x00012692 File Offset: 0x00010892
		public bool IsPlayerInFaction(int factionID)
		{
			return GameEngine.Instance.World.YourFaction != null && factionID == GameEngine.Instance.World.YourFaction.factionID;
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x000126BF File Offset: 0x000108BF
		public void createFaction(string factionName, string factionAbbreviation, string factionMotta, int flagdata, FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.CreateFaction(factionName, factionAbbreviation, factionMotta, flagdata);
			RemoteServices.Instance.set_CreateFaction_UserCallBack(new RemoteServices.CreateFaction_UserCallBack(this.createFactionCallback));
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0011EE34 File Offset: 0x0011D034
		private void createFactionCallback(CreateFaction_ReturnType returnData)
		{
			if (returnData.Success && returnData.yourFaction != null)
			{
				RemoteServices.Instance.UserFactionID = returnData.yourFaction.factionID;
				GameEngine.Instance.World.YourFaction = returnData.yourFaction;
				GameEngine.Instance.World.FactionMembers = returnData.members;
				GameEngine.Instance.World.FactionAllies = null;
				GameEngine.Instance.World.FactionEnemies = null;
				GameEngine.Instance.World.HouseAllies = null;
				GameEngine.Instance.World.HouseEnemies = null;
				GameEngine.Instance.World.LastUpdatedCrowns = DateTime.MinValue;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x000126EE File Offset: 0x000108EE
		public void leaveFaction(FactionManager.FactionInfoUpdatedCallback callback)
		{
			this.OnUpdate = callback;
			RemoteServices.Instance.set_FactionLeave_UserCallBack(new RemoteServices.FactionLeave_UserCallBack(this.leaveFactionCallback));
			RemoteServices.Instance.FactionLeave();
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x0011EF04 File Offset: 0x0011D104
		private void leaveFactionCallback(FactionLeave_ReturnType returnData)
		{
			if (returnData.Success)
			{
				RemoteServices.Instance.UserFactionID = -1;
				GameEngine.Instance.World.FactionMembers = null;
				GameEngine.Instance.World.FactionInvites = returnData.invites;
				GameEngine.Instance.World.FactionApplications = returnData.applications;
				GameEngine.Instance.World.FactionAllies = null;
				GameEngine.Instance.World.FactionEnemies = null;
				GameEngine.Instance.World.HouseAllies = null;
				GameEngine.Instance.World.HouseEnemies = null;
				GameEngine.Instance.World.HouseInfo = returnData.m_houseData;
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate(returnData.Success);
			}
		}

		// Token: 0x040016D1 RID: 5841
		private FactionManager.FactionInfoUpdatedCallback OnUpdate;

		// Token: 0x020001BE RID: 446
		// (Invoke) Token: 0x060010D2 RID: 4306
		public delegate void FactionInfoUpdatedCallback(bool success);
	}
}
