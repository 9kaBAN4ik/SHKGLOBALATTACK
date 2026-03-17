using System;
using System.Collections;
using System.Linq;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000067 RID: 103
	public class FiltersService : ASubscribed
	{
		// Token: 0x06000313 RID: 787 RVA: 0x00007CE0 File Offset: 0x00005EE0
		internal override void TranslateUI()
		{
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0005000C File Offset: 0x0004E20C
		private bool IsLowerRank(VillageData map)
		{
			LeaderBoardShortData leaderBoardShortData = DX.Info.FirstOrDefault((LeaderBoardShortData u) => u.userID == map.userID);
			int? num = (leaderBoardShortData != null) ? new int?(leaderBoardShortData.rank) : null;
			int? num2 = num;
			int ourRank = this.OurRank;
			return num2.GetValueOrDefault() < ourRank & num2 != null;
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000098F3 File Offset: 0x00007AF3
		private bool IsVisibleUnderVassalFilter(VillageData village)
		{
			return village.connecter == -1 && !village.Capital && village.userID >= 0 && this.IsLowerRank(village);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00050074 File Offset: 0x0004E274
		private bool IsVisibleUnderMonkFilter(VillageData map)
		{
			bool result;
			try
			{
				SparseArray peopleArray = GameEngine.Instance.World.getPeopleArray();
				foreach (object obj in peopleArray)
				{
					WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
					if (localPerson.person.personType == 4 && localPerson.person.state > 0 && (localPerson.person.homeVillageID == map.id || localPerson.person.targetVillageID == map.id))
					{
						return true;
					}
				}
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00009918 File Offset: 0x00007B18
		private bool IsVisibleUnderPaladinFilter(VillageData village)
		{
			return village.special == 15 || village.special == 17;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00050130 File Offset: 0x0004E330
		private bool IsVisibleUnderHouseFilter(int villageId, int house)
		{
			int factionID = GameEngine.Instance.World.getVillageData(villageId).factionID;
			return GameEngine.Instance.World.getHouse(factionID) == house;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00050168 File Offset: 0x0004E368
		public bool CustomFilter(int filterMode, VillageData village)
		{
			if (!base.IsSubscribed)
			{
				return false;
			}
			if (filterMode <= 1020)
			{
				if (filterMode == 12)
				{
					return this.IsVisibleUnderVassalFilter(village);
				}
				if (filterMode - 1001 <= 19)
				{
					return this.IsVisibleUnderHouseFilter(village.id, filterMode - 1000);
				}
			}
			else
			{
				if (filterMode == 90001)
				{
					return this.IsVisibleUnderMonkFilter(village);
				}
				if (filterMode == 90002)
				{
					return this.IsVisibleUnderPaladinFilter(village);
				}
			}
			return false;
		}

		// Token: 0x04000462 RID: 1122
		internal int OurRank;
	}
}
