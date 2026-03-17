using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonTypes;
using Kingdoms;

namespace Upgrade.Services
{
	// Token: 0x02000069 RID: 105
	internal class FreeMonitorService : ABaseService
	{
		// Token: 0x0600031D RID: 797 RVA: 0x000501D8 File Offset: 0x0004E3D8
		internal FreeMonitorService(Log log, DataGridView gridView, CheckedListBox checkedListBox) : base(log)
		{
			this._gridView = gridView;
			this._checkedListBox = checkedListBox;
			for (int i = 0; i < this._checkedListBox.Items.Count; i++)
			{
				this._checkedListBox.SetItemChecked(i, true);
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00050224 File Offset: 0x0004E424
		public override void ConcreteAction()
		{
			ControlForm controlForm = DX.ControlForm;
			Label lastUpdate = (controlForm != null) ? controlForm.label_FreeMonitorLastUpdateValue : null;
			if (lastUpdate != null)
			{
				lastUpdate.BeginInvoke(new MethodInvoker(delegate()
				{
					lastUpdate.Text = DateTime.Now.ToString();
				}));
			}
			
			ControlForm controlForm2 = DX.ControlForm;
			Label numResearches = (controlForm2 != null) ? controlForm2.label_NumResearchesInQueueValue : null;
			bool isPremium = GameEngine.Instance.World.isAccountPremium();
			if (numResearches != null)
			{
				numResearches.BeginInvoke(new MethodInvoker(delegate()
				{
					numResearches.Text = string.Format("{0}/{1}", ResearchService.CountResearchesInQueue(), isPremium ? 6 : 1);
				}));
			}
			
			this._gridView.Rows.Clear();
			WorldData localWorldData = GameEngine.Instance.LocalWorldData;
			CardData userCardData = GameEngine.Instance.cardsManager.UserCardData;
			byte research_Scouts = GameEngine.Instance.World.UserResearchData.Research_Scouts;
			int num = ResearchData.numMerchantGuildsTraders[(int)GameEngine.Instance.World.userResearchData.Research_Merchant_Guilds];
			int num2 = isPremium ? localWorldData.buildingQueueMaxLength : 1;
			List<int> list = new List<int>();
			foreach (VillageData villageData in GameEngine.Instance.World.VillageList)
			{
				if (PredatorService.IsPrey(villageData.special, -1))
				{
					list.Add(villageData.id);
				}
			}
			int honourRange = PredatorService.GetHonourRangeOrDefault();
			List<int> list2 = new List<int>(this.SelectedVillages);
			foreach (int villageId in list2)
			{
				VillageMap village = GameEngine.Instance.getVillage(villageId);
				VillageData villageData2 = GameEngine.Instance.World.getVillageData(villageId);
				if (village != null)
				{
					string villageName = GameEngine.Instance.World.getVillageName(villageId);
					string radarLevels = string.Empty;
					DateTime currentServerTime = VillageMap.getCurrentServerTime();
					TimeSpan t = village.m_interdictionTime - currentServerTime;
					if (t > TimeSpan.FromSeconds(1.0))
					{
						radarLevels = radarLevels + "ID: " + VillageMap.createBuildTimeString((int)t.TotalSeconds) + "\r\n";
					}
					TimeSpan t2 = village.m_excommunicationTime - currentServerTime;
					if (t2 > TimeSpan.FromSeconds(1.0))
					{
						radarLevels = radarLevels + "Xcom: " + VillageMap.createBuildTimeString((int)t2.TotalSeconds) + "\r\n";
					}
					TimeSpan t3 = villageData2.peaceTime - currentServerTime;
					if (t3 > TimeSpan.FromSeconds(1.0))
					{
						radarLevels = radarLevels + "Peace: " + VillageMap.createBuildTimeString((int)t3.TotalSeconds) + "\r\n";
					}
					string scouts = string.Format("Free: {0}\r\nTotal: {1}\r\nMax: {2}", village.m_numScouts, village.calcTotalScouts() + village.LocallyMade_Scouts, research_Scouts);
					string merchants = string.Format("Free: {0}\r\nTotal: {1}\r\nMax: {2}", village.m_numTradersAtHome, village.numTraders(), village.countWorkingMarkets() * num);
					string recruits = string.Format("Free: {0}\r\nTotal: {1}\r\nMax: {2}", village.m_spareWorkers, village.m_totalPeople, village.m_housingCapacity);
					int banquet = village.banqueting.GetHighestAvailableBanquet(village);
					string popularity = string.Concat(new string[]
					{
						string.Format("Tax: {0}\r\n", VillageBuildingsData.getTaxPopularityLevel(village.m_taxLevel)),
						string.Format("Rations: {0}\r\n", VillageBuildingsData.getRationsPopularityLevel((double)village.m_rationsLevel, localWorldData, userCardData) + VillageBuildingsData.getNumFoodTypesEatenPopularityLevel(village.m_numFoodTypesEaten)),
						string.Format("Ale: {0}\r\n", VillageBuildingsData.getAleRationsPopularityLevel((double)village.m_aleRationsLevel, localWorldData, userCardData)),
						string.Format("Housing: {0}\r\n", VillageBuildingsData.getHousingPopularityLevel(village.m_totalPeople, village.m_housingCapacity)),
						string.Format("Buildings: {0}\r\n", VillageBuildingsData.getBuildingsTypePopularityLevel(village.m_numPositiveBuildings, village.m_numNegativeBuildings, GameEngine.Instance.cardsManager.UserCardData)),
						string.Format("Total: {0}", village.getPopularity())
					});
					string faithPoints = village.CalcDailyFaithPoints().ToString();
					ResearchData parishCapitalResearchData = village.m_parishCapitalResearchData;
					byte? b = (parishCapitalResearchData != null) ? new byte?(parishCapitalResearchData.Research_Theology) : null;
					byte? b2 = b;
					int? num3 = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
					int num4 = 0;
					if (num3.GetValueOrDefault() > num4 & num3 != null)
					{
						faithPoints += string.Format(" (+{0})", (int)(b * 6));
					}
					string constQueue = string.Format("{0}/{1}", village.countNumBuildingsConstructing(), num2);
					CastleMap castle = (CastleMap)GameEngine.Instance.Castles[villageId];
					int num5 = (int)(castle.completeTime - currentServerTime).TotalSeconds;
					string completeTime = (num5 > 1) ? VillageMap.createBuildTimeString(num5) : "Castle complete";
					int aiCount = 0;
					foreach (int ai in list)
					{
						if (GameEngine.Instance.World.getDistance(ai, villageId) <= (double)honourRange)
						{
							aiCount++;
						}
					}
					
					// Capture variables for delegate
					string vName = villageName;
					string rLevels = radarLevels;
					string merch = merchants;
					string scou = scouts;
					string recr = recruits;
					int banq = banquet;
					string pop = popularity;
					string faith = faithPoints;
					string cQueue = constQueue;
					bool castleDamaged = castle.castleDamaged;
					bool castleEnclosed = village.m_castleEnclosed;
					string compTime = completeTime;
					int aiCnt = aiCount;
					int numCaptains = village.m_numCaptains;
					
					this._gridView.BeginInvoke(new MethodInvoker(delegate()
					{
						this._gridView.Rows.Add(new object[]
						{
							vName,
							rLevels,
							merch,
							scou,
							recr,
							banq,
							pop,
							faith,
							cQueue,
							castleDamaged,
							castleEnclosed,
							compTime,
							aiCnt,
							numCaptains
						});
					}));
				}
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00050920 File Offset: 0x0004EB20
		internal override void TranslateUI()
		{
			for (int i = 0; i < this._checkedListBox.Items.Count; i++)
			{
				this._checkedListBox.Items[i] = this._gridView.Columns[i + 1].HeaderText;
			}
		}

		// Token: 0x04000464 RID: 1124
		private DataGridView _gridView;

		// Token: 0x04000465 RID: 1125
		private CheckedListBox _checkedListBox;
	}
}
