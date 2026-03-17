using System;
using CommonTypes;
using Upgrade;

namespace Kingdoms
{
	// Token: 0x02000521 RID: 1313
	public class WorldMapFilter
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x0600337B RID: 13179 RVA: 0x00024EA0 File Offset: 0x000230A0
		// (set) Token: 0x0600337C RID: 13180 RVA: 0x00024EA8 File Offset: 0x000230A8
		public bool FilterActive
		{
			get
			{
				return this.filterActive;
			}
			set
			{
				this.filterActive = value;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x0600337D RID: 13181 RVA: 0x00024EB1 File Offset: 0x000230B1
		public int FilterMode
		{
			get
			{
				return this.filterMode;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x0600337E RID: 13182 RVA: 0x00024EB9 File Offset: 0x000230B9
		// (set) Token: 0x0600337F RID: 13183 RVA: 0x00024EC1 File Offset: 0x000230C1
		public bool FilterAlwaysShowYourVillages
		{
			get
			{
				return this.filterAlwaysShowYourVillages;
			}
			set
			{
				this.filterAlwaysShowYourVillages = value;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06003380 RID: 13184 RVA: 0x00024ECA File Offset: 0x000230CA
		// (set) Token: 0x06003381 RID: 13185 RVA: 0x00024ED2 File Offset: 0x000230D2
		public bool FilterShowHouseSymbols
		{
			get
			{
				return this.filterShowHouseSymbols;
			}
			set
			{
				this.filterShowHouseSymbols = value;
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06003382 RID: 13186 RVA: 0x00024EDB File Offset: 0x000230DB
		// (set) Token: 0x06003383 RID: 13187 RVA: 0x00024EE3 File Offset: 0x000230E3
		public bool FilterShowFactionSymbols
		{
			get
			{
				return this.filterShowFactionSymbols;
			}
			set
			{
				this.filterShowFactionSymbols = value;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06003384 RID: 13188 RVA: 0x00024EEC File Offset: 0x000230EC
		// (set) Token: 0x06003385 RID: 13189 RVA: 0x00024EF4 File Offset: 0x000230F4
		public bool FilterShowUserSymbols
		{
			get
			{
				return this.filterShowUserSymbols;
			}
			set
			{
				this.filterShowUserSymbols = value;
			}
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x00024EFD File Offset: 0x000230FD
		public void setFilterMode(int mode)
		{
			if (mode == 0)
			{
				this.FilterActive = false;
				return;
			}
			this.FilterActive = true;
			this.filterMode = mode;
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x002A6D24 File Offset: 0x002A4F24
		private bool visibleUnderAIFilter(VillageData village)
		{
			switch (village.special)
			{
			case 3:
			case 5:
			case 7:
			case 9:
			case 11:
			case 13:
			case 15:
			case 17:
				return true;
			}
			return SpecialVillageTypes.IS_TREASURE_CASTLE(village.special) || SpecialVillageTypes.IS_ROYAL_TOWER(village.special);
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x002A6DA0 File Offset: 0x002A4FA0
		public bool showVillage(VillageData village)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return true;
			}
			if (this.filterAlwaysShowYourVillages && village.userID == RemoteServices.Instance.UserID)
			{
				return true;
			}
			switch (this.filterMode)
			{
			case 1:
			{
				if (village.userID < 0)
				{
					return false;
				}
				if (village.userID == RemoteServices.Instance.UserID)
				{
					return true;
				}
				int userFactionID = RemoteServices.Instance.UserFactionID;
				if (userFactionID < 0 || village.factionID < 0)
				{
					return false;
				}
				if (village.factionID == userFactionID)
				{
					return true;
				}
				break;
			}
			case 2:
			{
				if (village.userID < 0)
				{
					return false;
				}
				if (village.userID == RemoteServices.Instance.UserID)
				{
					return true;
				}
				int userFactionID2 = RemoteServices.Instance.UserFactionID;
				if (userFactionID2 < 0 || village.factionID < 0)
				{
					return false;
				}
				if (village.factionID == userFactionID2)
				{
					return true;
				}
				FactionData faction = GameEngine.Instance.World.getFaction(userFactionID2);
				FactionData faction2 = GameEngine.Instance.World.getFaction(village.factionID);
				if (faction == null || faction2 == null)
				{
					return false;
				}
				if (faction.houseID == faction2.houseID && faction.houseID != 0)
				{
					return true;
				}
				break;
			}
			case 3:
				if (GameEngine.Instance.World.isForagingSpecial(village.id))
				{
					return true;
				}
				if (GameEngine.Instance.World.isForagingVillage(village.id))
				{
					return true;
				}
				break;
			case 4:
			case 5:
				if (GameEngine.Instance.World.isVillageTrading(village.id))
				{
					return true;
				}
				if (village.Capital)
				{
					return true;
				}
				if (GameEngine.Instance.World.isVillageMarketTrading(village.id))
				{
					return true;
				}
				break;
			case 6:
				if (GameEngine.Instance.World.isVillageInvolvedInAttacks(village.id))
				{
					return true;
				}
				break;
			case 7:
			{
				if (village.userID < 0)
				{
					return false;
				}
				if (village.userID == RemoteServices.Instance.UserID)
				{
					return true;
				}
				int userFactionID3 = RemoteServices.Instance.UserFactionID;
				if (userFactionID3 >= 0 || village.factionID < 0)
				{
					return false;
				}
				FactionData faction3 = GameEngine.Instance.World.getFaction(village.factionID);
				if (faction3 == null)
				{
					return false;
				}
				if (faction3.openForApplications)
				{
					return true;
				}
				break;
			}
			case 8:
				return GameEngine.Instance.World.isVillageInvolvedInAIAttacks(village.id) || this.visibleUnderAIFilter(village);
			case 9:
				if (this.visibleUnderAIFilter(village))
				{
					return true;
				}
				if (!village.Capital && village.userID > 0)
				{
					return true;
				}
				break;
			case 10:
				if (village.countyCapital)
				{
					return true;
				}
				break;
			case 11:
				return false;
			default:
			{
				ControlForm controlForm = DX.ControlForm;
				return controlForm != null && controlForm.FiltersService.CustomFilter(this.filterMode, village);
			}
			}
			return false;
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x002A7054 File Offset: 0x002A5254
		public int showVillage(int villageID)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return villageID;
			}
			VillageData villageData = GameEngine.Instance.World.getVillageData(villageID);
			if (villageData == null)
			{
				return -1;
			}
			if (this.showVillage(villageData))
			{
				return villageID;
			}
			return -1;
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x002A709C File Offset: 0x002A529C
		public bool showArmy(WorldMap.LocalArmyData army)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return true;
			}
			int num = this.filterMode;
			if (num != 3)
			{
				if (num != 6)
				{
					if (num == 8)
					{
						if (army.lootType < 0)
						{
							VillageData villageData = GameEngine.Instance.World.getVillageData(army.targetVillageID);
							if (villageData != null)
							{
								switch (villageData.special)
								{
								case 3:
								case 5:
								case 7:
								case 9:
								case 11:
								case 13:
								case 15:
								case 17:
									return true;
								}
								if (SpecialVillageTypes.IS_TREASURE_CASTLE(villageData.special))
								{
									return true;
								}
								if (SpecialVillageTypes.IS_ROYAL_TOWER(villageData.special))
								{
									return true;
								}
							}
						}
					}
				}
				else if (GameEngine.Instance.World.isAttackingArmy(army.armyID))
				{
					return true;
				}
			}
			else if (GameEngine.Instance.World.isForagingArmy(army.armyID))
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x00024F18 File Offset: 0x00023118
		public bool showReinforcements(WorldMap.LocalArmyData army)
		{
			return !this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0;
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x002A71A4 File Offset: 0x002A53A4
		public long showReinforcements(long reinfID)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return reinfID;
			}
			WorldMap.LocalArmyData reinforcement = GameEngine.Instance.World.getReinforcement(reinfID);
			if (reinforcement == null)
			{
				return -1L;
			}
			if (this.showReinforcements(reinforcement))
			{
				return reinfID;
			}
			return -1L;
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x002A71EC File Offset: 0x002A53EC
		public bool showPeople(WorldMap.LocalPerson person)
		{
			if (this.FilterActive && InterfaceMgr.Instance.WorldMapMode == 0)
			{
				if (this.filterMode == 90001 && person.person.personType == 4)
				{
					ControlForm controlForm = DX.ControlForm;
					if (controlForm != null && controlForm.FiltersService.IsSubscribed)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x002A7244 File Offset: 0x002A5444
		public long showPeople(long personID)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return personID;
			}
			WorldMap.LocalPerson person = GameEngine.Instance.World.getPerson(personID);
			if (person == null)
			{
				return -1L;
			}
			if (this.showPeople(person))
			{
				return personID;
			}
			return -1L;
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x002A728C File Offset: 0x002A548C
		public bool showTrader(WorldMap.LocalTrader trader)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return true;
			}
			int num = this.filterMode;
			if (num - 4 <= 1)
			{
				if (trader.trader.traderState == 1 || trader.trader.traderState == 2)
				{
					return true;
				}
				if (trader.trader.traderState > 2 && trader.trader.traderState <= 6)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x002A72FC File Offset: 0x002A54FC
		public long showTrader(long traderID)
		{
			if (!this.FilterActive || InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return traderID;
			}
			WorldMap.LocalTrader trader = GameEngine.Instance.World.getTrader(traderID);
			if (trader == null)
			{
				return -1L;
			}
			if (this.showTrader(trader))
			{
				return traderID;
			}
			return -1L;
		}

		// Token: 0x0400403C RID: 16444
		public const int MAPFILTER_OFF = 0;

		// Token: 0x0400403D RID: 16445
		public const int MAPFILTER_PRESET_YOUR_FACTION = 1;

		// Token: 0x0400403E RID: 16446
		public const int MAPFILTER_PRESET_YOUR_HOUSE = 2;

		// Token: 0x0400403F RID: 16447
		public const int MAPFILTER_PRESET_FORAGING = 3;

		// Token: 0x04004040 RID: 16448
		public const int MAPFILTER_PRESET_TRADERS = 4;

		// Token: 0x04004041 RID: 16449
		public const int MAPFILTER_PRESET_MARKETS = 5;

		// Token: 0x04004042 RID: 16450
		public const int MAPFILTER_PRESET_ATTACKS = 6;

		// Token: 0x04004043 RID: 16451
		public const int MAPFILTER_PRESET_OPEN_FACTIONS = 7;

		// Token: 0x04004044 RID: 16452
		public const int MAPFILTER_PRESET_AI_ONLY = 8;

		// Token: 0x04004045 RID: 16453
		public const int MAPFILTER_PRESET_ATTACK_FROM_VASSAL = 9;

		// Token: 0x04004046 RID: 16454
		public const int MAPFILTER_PRESET_COUNTY_CAPITALS = 10;

		// Token: 0x04004047 RID: 16455
		public const int MAPFILTER_PRESET_HIDE_ALL = 11;

		// Token: 0x04004048 RID: 16456
		public const int MAPFILTER_CUSTOM = 10000;

		// Token: 0x04004049 RID: 16457
		private bool filterActive;

		// Token: 0x0400404A RID: 16458
		private int filterMode;

		// Token: 0x0400404B RID: 16459
		private bool filterAlwaysShowYourVillages = true;

		// Token: 0x0400404C RID: 16460
		private bool filterShowHouseSymbols = true;

		// Token: 0x0400404D RID: 16461
		private bool filterShowFactionSymbols = true;

		// Token: 0x0400404E RID: 16462
		private bool filterShowUserSymbols = true;
	}
}
