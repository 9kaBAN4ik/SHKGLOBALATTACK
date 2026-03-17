using System;
using CommonTypes;

namespace Kingdoms
{
	// Token: 0x020004C2 RID: 1218
	public class VassalsManager
	{
		// Token: 0x06002D0F RID: 11535 RVA: 0x000210F3 File Offset: 0x0001F2F3
		public VassalInfo GetLiegeLord()
		{
			return this.liegeLordInfo;
		}

		// Token: 0x06002D10 RID: 11536 RVA: 0x000210FB File Offset: 0x0001F2FB
		public VassalInfo[] GetVassals()
		{
			return this.cachedVassalInfo;
		}

		// Token: 0x06002D11 RID: 11537 RVA: 0x00021103 File Offset: 0x0001F303
		public VassalRequestInfo[] GetRequestsSentByYou()
		{
			return this.cachedRequestsSentByYou;
		}

		// Token: 0x06002D12 RID: 11538 RVA: 0x0002110B File Offset: 0x0001F30B
		public VassalRequestInfo[] GetRequestsSentToYou()
		{
			return this.cachedRequestsSentToYou;
		}

		// Token: 0x06002D13 RID: 11539 RVA: 0x00021113 File Offset: 0x0001F313
		public void LoadVassals(int villageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			this.cachedVassalInfo = null;
			this.OnUpdate = callback;
			RemoteServices.Instance.set_VassalInfo_UserCallBack(new RemoteServices.VassalInfo_UserCallBack(this.vassalInfoCallBack));
			RemoteServices.Instance.VassalInfo(villageID);
		}

		// Token: 0x06002D14 RID: 11540 RVA: 0x0023E924 File Offset: 0x0023CB24
		private void vassalInfoCallBack(VassalInfo_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.importVassals(returnData.liegeLordInfo, returnData.vassals);
				this.importVassalRequests(returnData.requestsYouveMade, returnData.requestsOfYou);
				GameEngine.Instance.World.updateUserVassals();
				if (this.OnUpdate != null)
				{
					this.OnUpdate();
				}
			}
		}

		// Token: 0x06002D15 RID: 11541 RVA: 0x00021144 File Offset: 0x0001F344
		public void importVassals(VassalInfo liegeLord, VassalInfo[] vassals)
		{
			this.liegeLordInfo = liegeLord;
			this.cachedVassalInfo = vassals;
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x00021154 File Offset: 0x0001F354
		public void importVassalRequests(VassalRequestInfo[] requestsYouveSent, VassalRequestInfo[] requestsOfYou)
		{
			this.cachedRequestsSentByYou = requestsYouveSent;
			this.cachedRequestsSentToYou = requestsOfYou;
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x0023E980 File Offset: 0x0023CB80
		public void AskSomeoneToBeYourVassal(int villageID, int targetVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (villageID >= 0 && targetVillageID >= 0 && !GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_SendVassalRequest_UserCallBack(new RemoteServices.SendVassalRequest_UserCallBack(this.askSomeoneToBeYourVassalCallBack));
				RemoteServices.Instance.SendVassalRequest(villageID, targetVillageID);
			}
		}

		// Token: 0x06002D18 RID: 11544 RVA: 0x0023E9D0 File Offset: 0x0023CBD0
		private void askSomeoneToBeYourVassalCallBack(SendVassalRequest_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			VillageMap village = GameEngine.Instance.Village;
			if (village != null)
			{
				this.importVassalRequests(returnData.requestsYouveMade, returnData.requestsOfYou);
				if (this.OnUpdate != null)
				{
					this.OnUpdate();
				}
			}
		}

		// Token: 0x06002D19 RID: 11545 RVA: 0x0023EA1C File Offset: 0x0023CC1C
		public void BreakFromYourLiegeLord(int theirVillageID, int yourVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (theirVillageID >= 0 && yourVillageID >= 0 && !GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_BreakLiegeLord_UserCallBack(new RemoteServices.BreakLiegeLord_UserCallBack(this.breakFromYourLiegeLordCallBack));
				RemoteServices.Instance.BreakLiegeLord(theirVillageID, yourVillageID);
				GameEngine.Instance.World.breakVassal(theirVillageID, yourVillageID);
			}
		}

		// Token: 0x06002D1A RID: 11546 RVA: 0x00021164 File Offset: 0x0001F364
		private void breakFromYourLiegeLordCallBack(BreakLiegeLord_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.importVassals(returnData.liegeLordInfo, returnData.vassals);
				GameEngine.Instance.World.updateUserVassals();
				if (this.OnUpdate != null)
				{
					this.OnUpdate();
				}
			}
		}

		// Token: 0x06002D1B RID: 11547 RVA: 0x0023EA7C File Offset: 0x0023CC7C
		public void BreakFromYourVassal(int yourVillageID, int theirVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (theirVillageID >= 0 && yourVillageID >= 0 && !GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_BreakVassalage_UserCallBack(new RemoteServices.BreakVassalage_UserCallBack(this.breakVassalageCallBack));
				RemoteServices.Instance.BreakVassalage(yourVillageID, theirVillageID);
				GameEngine.Instance.World.breakVassal(yourVillageID, theirVillageID);
			}
		}

		// Token: 0x06002D1C RID: 11548 RVA: 0x000211A2 File Offset: 0x0001F3A2
		private void breakVassalageCallBack(BreakVassalage_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.importVassals(returnData.liegeLordInfo, returnData.vassals);
				GameEngine.Instance.World.updateUserVassals();
				if (this.OnUpdate != null)
				{
					this.OnUpdate();
				}
			}
		}

		// Token: 0x06002D1D RID: 11549 RVA: 0x000211E0 File Offset: 0x0001F3E0
		public void AcceptRequest(int theirVillageID, int yourVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_HandleVassalRequest_UserCallBack(new RemoteServices.HandleVassalRequest_UserCallBack(this.handleVassalRequestCallBack));
				RemoteServices.Instance.AcceptVassalRequest(theirVillageID, yourVillageID);
			}
		}

		// Token: 0x06002D1E RID: 11550 RVA: 0x0002121C File Offset: 0x0001F41C
		public void DeclineRequest(int theirVillageID, int yourVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_HandleVassalRequest_UserCallBack(new RemoteServices.HandleVassalRequest_UserCallBack(this.handleVassalRequestCallBack));
				RemoteServices.Instance.DeclineVassalRequest(theirVillageID, yourVillageID);
			}
		}

		// Token: 0x06002D1F RID: 11551 RVA: 0x00021258 File Offset: 0x0001F458
		public void CancelRequest(int theirVillageID, int yourVillageID, VassalsManager.VassalsUpdatedCallback callback)
		{
			if (!GameEngine.Instance.World.WorldEnded)
			{
				this.OnUpdate = callback;
				RemoteServices.Instance.set_HandleVassalRequest_UserCallBack(new RemoteServices.HandleVassalRequest_UserCallBack(this.handleVassalRequestCallBack));
				RemoteServices.Instance.CancelVassalRequest(yourVillageID, theirVillageID);
			}
		}

		// Token: 0x06002D20 RID: 11552 RVA: 0x0023EADC File Offset: 0x0023CCDC
		public void handleVassalRequestCallBack(HandleVassalRequest_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.importVassals(returnData.liegeLordInfo, returnData.vassals);
				this.importVassalRequests(returnData.requestsYouveMade, returnData.requestsOfYou);
				GameEngine.Instance.World.updateUserVassals();
			}
			if (this.OnUpdate != null)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x06002D21 RID: 11553 RVA: 0x00021294 File Offset: 0x0001F494
		public void Reset()
		{
			this.liegeLordInfo.villageID = -1;
			this.cachedVassalInfo = null;
			this.cachedRequestsSentByYou = null;
			this.cachedRequestsSentToYou = null;
		}

		// Token: 0x04003820 RID: 14368
		private VassalInfo liegeLordInfo = new VassalInfo();

		// Token: 0x04003821 RID: 14369
		private VassalInfo[] cachedVassalInfo;

		// Token: 0x04003822 RID: 14370
		private VassalRequestInfo[] cachedRequestsSentByYou;

		// Token: 0x04003823 RID: 14371
		private VassalRequestInfo[] cachedRequestsSentToYou;

		// Token: 0x04003824 RID: 14372
		private VassalsManager.VassalsUpdatedCallback OnUpdate;

		// Token: 0x020004C3 RID: 1219
		// (Invoke) Token: 0x06002D24 RID: 11556
		public delegate void VassalsUpdatedCallback();
	}
}
