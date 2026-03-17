using System;
using System.Collections.Generic;
using CommonTypes;
using Stronghold.AuthClient;

namespace Kingdoms
{
	// Token: 0x0200013D RID: 317
	internal class ContestCachedData
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x0000EA0D File Offset: 0x0000CC0D
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x0000EA1E File Offset: 0x0000CC1E
		public ContestEntry[] activeLeaderboard
		{
			get
			{
				return this.leaderboardData[this.visibleTier - 1];
			}
			set
			{
				this.leaderboardData[this.visibleTier - 1] = value;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x0000EA30 File Offset: 0x0000CC30
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x0000EA41 File Offset: 0x0000CC41
		public int activeMaxIndex
		{
			get
			{
				return this.m_maxIndex[this.visibleTier - 1];
			}
			set
			{
				this.m_maxIndex[this.visibleTier - 1] = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x0000EA53 File Offset: 0x0000CC53
		// (set) Token: 0x06000BAF RID: 2991 RVA: 0x0000EA64 File Offset: 0x0000CC64
		public int activeTopIndex
		{
			get
			{
				return this.m_topIndexPosition[this.visibleTier - 1];
			}
			set
			{
				this.m_topIndexPosition[this.visibleTier - 1] = value;
			}
		}

		// Token: 0x17000080 RID: 128
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x0000EA76 File Offset: 0x0000CC76
		public int visibleLineCount
		{
			set
			{
				if (value != this.m_visibleLineCount && this.activeLeaderboard != null && this.leaderboardCallback != null)
				{
					this.leaderboardCallback(true);
				}
				this.m_visibleLineCount = value;
			}
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x0000EAA4 File Offset: 0x0000CCA4
		public void RetrieveLeaderboard()
		{
			RemoteServices.Instance.set_GetContestDataRange_UserCallBack(new RemoteServices.GetContestDataRange_UserCallBack(this.RetrieveLeaderboardCallback));
			RemoteServices.Instance.GetContestDataRange(this.ID, this.activeTopIndex, 30, this.visibleTier);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0000EADA File Offset: 0x0000CCDA
		private void RetrieveLeaderboardCallback(GetContestDataRange_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.activeLeaderboard = returnData.contestInfo;
				this.activeMaxIndex = returnData.maxIndex;
			}
			if (this.leaderboardCallback != null)
			{
				this.leaderboardCallback(returnData.Success);
			}
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x000E6044 File Offset: 0x000E4244
		public void RetrieveMetaData()
		{
			XmlRpcContestProvider xmlRpcContestProvider = XmlRpcContestProvider.CreateForEndpoint(URLs.ProfileProtocol, URLs.ProfileServerAddressLogin, URLs.ProfileServerPort, URLs.ProfilePath);
			xmlRpcContestProvider.RetrieveContestMetaData(new XmlRpcContestRequest
			{
				SessionID = RemoteServices.Instance.SessionGuid.ToString().Replace("-", ""),
				UserGUID = RemoteServices.Instance.UserGuid.ToString().Replace("-", ""),
				EventID = new int?(this.ID)
			}, new ContestEndResponseDelegate(this.RetrieveMetaDataCallback), null);
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x000E60F0 File Offset: 0x000E42F0
		private void RetrieveMetaDataCallback(IContestProvider provider, IContestResponse response)
		{
			int? successCode = response.SuccessCode;
			int num = 1;
			if (successCode.GetValueOrDefault() == num & successCode != null)
			{
				this.name = response.ContestName;
				this.description = response.ContestDescription;
				this.prizes = ((XmlRpcContestResponse)response).Prizes;
				this.m_startTime = response.StartTime;
				this.m_endTime = response.EndTime;
			}
			if (this.metaDataCallback != null)
			{
				ContestCachedData.ContestCacheCallbackDelegate contestCacheCallbackDelegate = this.metaDataCallback;
				successCode = response.SuccessCode;
				num = 1;
				contestCacheCallbackDelegate(successCode.GetValueOrDefault() == num & successCode != null);
			}
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x0000EB15 File Offset: 0x0000CD15
		public void RetrieveUserData()
		{
			RemoteServices.Instance.set_GetUserContestData_UserCallBack(new RemoteServices.GetUserContestData_UserCallBack(this.RetrieveUserDataCallback));
			RemoteServices.Instance.GetUserContestData(this.ID);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x000E618C File Offset: 0x000E438C
		private void RetrieveUserDataCallback(GetUserContestData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				bool flag = returnData.Success && returnData.userInfo != null && returnData.userInfo.RankBand > 0;
				this.lastUpdate = returnData.lastUpdate;
				if (flag)
				{
					this.userPosition = returnData.userInfo.Placement;
					this.userRankBand = returnData.userInfo.RankBand;
					this.userScore = returnData.userInfo.Score;
				}
				else
				{
					this.userPosition = 0;
					this.userRankBand = 0;
					this.userScore = 0.0;
				}
				if (this.userDataCallback != null)
				{
					this.userDataCallback(flag && this.userRankBand > 0);
				}
			}
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x000E624C File Offset: 0x000E444C
		public void SetAsVisible()
		{
			if (this.activeLeaderboard == null)
			{
				this.RetrieveLeaderboard();
			}
			else if (this.leaderboardCallback != null)
			{
				this.leaderboardCallback(true);
			}
			if (string.IsNullOrEmpty(this.name))
			{
				this.RetrieveMetaData();
			}
			else if (this.metaDataCallback != null)
			{
				this.metaDataCallback(true);
			}
			if (this.userPosition == 0 && this.userRankBand > 0)
			{
				this.RetrieveUserData();
				return;
			}
			if (this.userDataCallback != null)
			{
				this.userDataCallback(true);
			}
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x000E62D4 File Offset: 0x000E44D4
		public void NextTier()
		{
			if (this.visibleTier >= 3)
			{
				return;
			}
			this.visibleTier++;
			if (this.activeLeaderboard == null)
			{
				this.RetrieveLeaderboard();
				this.RetrieveMetaData();
				return;
			}
			if (this.leaderboardCallback != null)
			{
				this.leaderboardCallback(true);
			}
			if (this.metaDataCallback != null)
			{
				this.metaDataCallback(true);
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x000E6338 File Offset: 0x000E4538
		public void PrevTier()
		{
			if (this.visibleTier <= 1)
			{
				return;
			}
			this.visibleTier--;
			if (this.activeLeaderboard == null)
			{
				this.RetrieveLeaderboard();
				this.RetrieveMetaData();
				return;
			}
			if (this.leaderboardCallback != null)
			{
				this.leaderboardCallback(true);
			}
			if (this.metaDataCallback != null)
			{
				this.metaDataCallback(true);
			}
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0000EB3D File Offset: 0x0000CD3D
		public void ScrollUp()
		{
			if (this.activeTopIndex >= 2)
			{
				this.activeTopIndex = Math.Max(1, this.activeTopIndex - this.m_visibleLineCount);
				this.RetrieveLeaderboard();
			}
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x000E639C File Offset: 0x000E459C
		public void ScrollDown()
		{
			if (this.activeTopIndex <= this.activeMaxIndex - this.m_visibleLineCount)
			{
				this.activeTopIndex = Math.Min(this.activeMaxIndex - this.m_visibleLineCount, this.activeTopIndex + this.m_visibleLineCount);
				this.RetrieveLeaderboard();
			}
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x0000EB67 File Offset: 0x0000CD67
		public void ScrollToTop()
		{
			if (this.activeTopIndex >= 2)
			{
				this.activeTopIndex = 1;
				this.RetrieveLeaderboard();
			}
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0000EB7F File Offset: 0x0000CD7F
		public void ScrollToBottom()
		{
			if (this.activeTopIndex <= this.activeMaxIndex - this.m_visibleLineCount)
			{
				this.activeTopIndex = this.activeMaxIndex - this.m_visibleLineCount;
				this.RetrieveLeaderboard();
			}
		}

		// Token: 0x04000FB8 RID: 4024
		public int ID = -1;

		// Token: 0x04000FB9 RID: 4025
		public int visibleTier = 3;

		// Token: 0x04000FBA RID: 4026
		private int? m_endTime = new int?(0);

		// Token: 0x04000FBB RID: 4027
		private int? m_startTime = new int?(0);

		// Token: 0x04000FBC RID: 4028
		public string name = string.Empty;

		// Token: 0x04000FBD RID: 4029
		public string description = string.Empty;

		// Token: 0x04000FBE RID: 4030
		public int userPosition;

		// Token: 0x04000FBF RID: 4031
		public int userRankBand = 1;

		// Token: 0x04000FC0 RID: 4032
		public double userScore;

		// Token: 0x04000FC1 RID: 4033
		public DateTime lastUpdate = DateTime.MinValue;

		// Token: 0x04000FC2 RID: 4034
		public List<ContestPrizeDefinition> prizes = new List<ContestPrizeDefinition>();

		// Token: 0x04000FC3 RID: 4035
		private ContestEntry[][] leaderboardData = new ContestEntry[3][];

		// Token: 0x04000FC4 RID: 4036
		private int[] m_maxIndex = new int[3];

		// Token: 0x04000FC5 RID: 4037
		private int[] m_topIndexPosition = new int[]
		{
			1,
			1,
			1
		};

		// Token: 0x04000FC6 RID: 4038
		private int m_visibleLineCount = 10;

		// Token: 0x04000FC7 RID: 4039
		public ContestCachedData.ContestCacheCallbackDelegate leaderboardCallback;

		// Token: 0x04000FC8 RID: 4040
		public ContestCachedData.ContestCacheCallbackDelegate metaDataCallback;

		// Token: 0x04000FC9 RID: 4041
		public ContestCachedData.ContestCacheCallbackDelegate userDataCallback;

		// Token: 0x0200013E RID: 318
		// (Invoke) Token: 0x06000BC0 RID: 3008
		public delegate void ContestCacheCallbackDelegate(bool success);
	}
}
