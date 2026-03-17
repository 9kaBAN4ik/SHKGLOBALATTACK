using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CommonTypes;
using DXGraphics;
using StatTracking;
using Stronghold.AuthClient;
using Stronghold.ShieldClient;
using Upgrade;
using Upgrade.Services;

namespace Kingdoms
{
	// Token: 0x020004FB RID: 1275
	public class WorldMap
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06003062 RID: 12386 RVA: 0x00023333 File Offset: 0x00021533
		// (set) Token: 0x06003063 RID: 12387 RVA: 0x0002333B File Offset: 0x0002153B
		public long HighestArmyIDSeen
		{
			get
			{
				return this.highestArmySeen;
			}
			set
			{
				this.highestArmySeen = value;
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06003064 RID: 12388 RVA: 0x00023344 File Offset: 0x00021544
		// (set) Token: 0x06003065 RID: 12389 RVA: 0x0002335F File Offset: 0x0002155F
		public int MostAge4Villages
		{
			get
			{
				if (!GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
				{
					return this.m_mostAge4Villages;
				}
				return 0;
			}
			set
			{
				this.m_mostAge4Villages = value;
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06003066 RID: 12390 RVA: 0x00023368 File Offset: 0x00021568
		public ResearchData UserResearchData
		{
			get
			{
				return this.userResearchData;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06003067 RID: 12391 RVA: 0x00023370 File Offset: 0x00021570
		// (set) Token: 0x06003068 RID: 12392 RVA: 0x00023378 File Offset: 0x00021578
		public int NumVacationsAvailable
		{
			get
			{
				return this.numVacationsAvailable;
			}
			set
			{
				this.numVacationsAvailable = value;
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06003069 RID: 12393 RVA: 0x00023381 File Offset: 0x00021581
		// (set) Token: 0x0600306A RID: 12394 RVA: 0x00023389 File Offset: 0x00021589
		public bool VacationNot30Days
		{
			get
			{
				return this.vacationNot30Days;
			}
			set
			{
				this.vacationNot30Days = value;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x0600306B RID: 12395 RVA: 0x00023392 File Offset: 0x00021592
		public FreeCardsData FreeCardInfo
		{
			get
			{
				return this.freeCardInfo;
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x0600306C RID: 12396 RVA: 0x0002339A File Offset: 0x0002159A
		// (set) Token: 0x0600306D RID: 12397 RVA: 0x000233A2 File Offset: 0x000215A2
		public bool InviteSystemNotImplemented
		{
			get
			{
				return this.inviteSystemNotImplemented;
			}
			set
			{
				this.inviteSystemNotImplemented = value;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x0600306E RID: 12398 RVA: 0x000233AB File Offset: 0x000215AB
		// (set) Token: 0x0600306F RID: 12399 RVA: 0x000233B3 File Offset: 0x000215B3
		public bool MapEditing
		{
			get
			{
				return this.mapEditing;
			}
			set
			{
				this.mapEditing = value;
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06003070 RID: 12400 RVA: 0x000233BC File Offset: 0x000215BC
		public string MapDataFilename
		{
			get
			{
				return this.mapDataFilename;
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06003071 RID: 12401 RVA: 0x000233C4 File Offset: 0x000215C4
		// (set) Token: 0x06003072 RID: 12402 RVA: 0x000233CC File Offset: 0x000215CC
		public bool WorldEnded
		{
			get
			{
				return this.worldEnded;
			}
			set
			{
				this.worldEnded = value;
				if (!this.worldEnded)
				{
					this.worldEnded_message = false;
				}
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06003073 RID: 12403 RVA: 0x000233E4 File Offset: 0x000215E4
		// (set) Token: 0x06003074 RID: 12404 RVA: 0x000233EC File Offset: 0x000215EC
		public bool WorldEnded_message
		{
			get
			{
				return this.worldEnded_message;
			}
			set
			{
				this.worldEnded_message = value;
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06003075 RID: 12405 RVA: 0x000233F5 File Offset: 0x000215F5
		public int WorldMapType
		{
			get
			{
				return this.currentMapType;
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06003076 RID: 12406 RVA: 0x0027E508 File Offset: 0x0027C708
		public string WorldDefaultLanguage
		{
			get
			{
				WorldMapType mapData = GameEngine.Instance.WorldMapTypesData.getMapData(this.currentMapType);
				if (mapData.mapName.ToLower() == "uk.wmpData".ToLower())
				{
					return "en";
				}
				if (mapData.mapName.ToLower() == "de.wmpData".ToLower())
				{
					return "de";
				}
				if (mapData.mapName.ToLower() == "fr.wmpData".ToLower())
				{
					return "fr";
				}
				if (mapData.mapName.ToLower() == "ru.wmpData".ToLower())
				{
					return "ru";
				}
				if (mapData.mapName.ToLower() == "es.wmpData".ToLower())
				{
					return "es";
				}
				if (mapData.mapName.ToLower() == "pl.wmpData".ToLower())
				{
					return "pl";
				}
				if (mapData.mapName.ToLower() == "sa.wmpData".ToLower())
				{
					return "pt";
				}
				if (mapData.mapName.ToLower() == "it.wmpData".ToLower())
				{
					return "it";
				}
				if (mapData.mapName.ToLower() == "tr.wmpData".ToLower())
				{
					return "tr";
				}
				if (mapData.mapName.ToLower() == "ch.wmpData".ToLower())
				{
					return "zh";
				}
				return "en";
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06003077 RID: 12407 RVA: 0x000233FD File Offset: 0x000215FD
		public bool SmallMapFont
		{
			get
			{
				return this.smallMapFont;
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06003078 RID: 12408 RVA: 0x00023405 File Offset: 0x00021605
		public long StoredVillageFactionPos
		{
			get
			{
				return this.storedVillageFactionsPos;
			}
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06003079 RID: 12409 RVA: 0x0002340D File Offset: 0x0002160D
		public long StoredFactionChangesPos
		{
			get
			{
				return this.storedFactionChangesPos;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x0600307A RID: 12410 RVA: 0x00023405 File Offset: 0x00021605
		public long CurrentVillageFactionsPos
		{
			get
			{
				return this.storedVillageFactionsPos;
			}
		}

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x0600307B RID: 12411 RVA: 0x00023415 File Offset: 0x00021615
		// (set) Token: 0x0600307C RID: 12412 RVA: 0x0002341D File Offset: 0x0002161D
		public bool SecondAgeWorld
		{
			get
			{
				return this.secondAgeWorld;
			}
			set
			{
				this.secondAgeWorld = value;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600307D RID: 12413 RVA: 0x00023426 File Offset: 0x00021626
		// (set) Token: 0x0600307E RID: 12414 RVA: 0x0002342E File Offset: 0x0002162E
		public bool ThirdAgeWorld
		{
			get
			{
				return this.thirdAgeWorld;
			}
			set
			{
				this.thirdAgeWorld = value;
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600307F RID: 12415 RVA: 0x00023437 File Offset: 0x00021637
		// (set) Token: 0x06003080 RID: 12416 RVA: 0x0002343F File Offset: 0x0002163F
		public bool FourthAgeWorld
		{
			get
			{
				return this.fourthAgeWorld;
			}
			set
			{
				this.fourthAgeWorld = value;
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06003081 RID: 12417 RVA: 0x00023448 File Offset: 0x00021648
		// (set) Token: 0x06003082 RID: 12418 RVA: 0x00023450 File Offset: 0x00021650
		public bool FifthAgeWorld
		{
			get
			{
				return this.fifthAgeWorld;
			}
			set
			{
				this.fifthAgeWorld = value;
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06003083 RID: 12419 RVA: 0x00023459 File Offset: 0x00021659
		// (set) Token: 0x06003084 RID: 12420 RVA: 0x00023461 File Offset: 0x00021661
		public bool SixthAgeWorld
		{
			get
			{
				return this.sixthAgeWorld;
			}
			set
			{
				this.sixthAgeWorld = value;
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06003085 RID: 12421 RVA: 0x0002346A File Offset: 0x0002166A
		// (set) Token: 0x06003086 RID: 12422 RVA: 0x00023472 File Offset: 0x00021672
		public bool SeventhAgeWorld
		{
			get
			{
				return this.seventhAgeWorld;
			}
			set
			{
				this.seventhAgeWorld = value;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06003087 RID: 12423 RVA: 0x0002347B File Offset: 0x0002167B
		public bool FirstAgeWorld
		{
			get
			{
				return !this.SecondAgeWorld && !this.ThirdAgeWorld && !this.FourthAgeWorld && !this.FifthAgeWorld && !this.SixthAgeWorld && !this.SeventhAgeWorld;
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06003088 RID: 12424 RVA: 0x000234B0 File Offset: 0x000216B0
		// (set) Token: 0x06003089 RID: 12425 RVA: 0x000234B8 File Offset: 0x000216B8
		public HouseData[] HouseInfo
		{
			get
			{
				return this.m_houseData;
			}
			set
			{
				this.m_houseData = value;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x0600308A RID: 12426 RVA: 0x000234C1 File Offset: 0x000216C1
		// (set) Token: 0x0600308B RID: 12427 RVA: 0x000234C9 File Offset: 0x000216C9
		public HouseVoteData HouseVoteInfo
		{
			get
			{
				return this.m_houseVoteData;
			}
			set
			{
				this.m_houseVoteData = value;
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x0600308C RID: 12428 RVA: 0x000234D2 File Offset: 0x000216D2
		// (set) Token: 0x0600308D RID: 12429 RVA: 0x000234DA File Offset: 0x000216DA
		public FactionMemberData[] FactionMembers
		{
			get
			{
				return this.m_factionMembers;
			}
			set
			{
				this.m_factionMembers = value;
				this.lastTimeOwnMembersUpdated = DateTime.Now;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x0600308E RID: 12430 RVA: 0x000234EE File Offset: 0x000216EE
		// (set) Token: 0x0600308F RID: 12431 RVA: 0x000234F6 File Offset: 0x000216F6
		public FactionInviteData[] FactionInvites
		{
			get
			{
				return this.m_factionInvites;
			}
			set
			{
				this.m_factionInvites = value;
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06003090 RID: 12432 RVA: 0x000234FF File Offset: 0x000216FF
		// (set) Token: 0x06003091 RID: 12433 RVA: 0x00023507 File Offset: 0x00021707
		public List<FactionInviteData> FactionApplications
		{
			get
			{
				return this.m_factionApplications;
			}
			set
			{
				this.m_factionApplications = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06003092 RID: 12434 RVA: 0x00023510 File Offset: 0x00021710
		// (set) Token: 0x06003093 RID: 12435 RVA: 0x00023518 File Offset: 0x00021718
		public int[] FactionAllies
		{
			get
			{
				return this.m_factionAllies;
			}
			set
			{
				this.m_factionAllies = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06003094 RID: 12436 RVA: 0x00023521 File Offset: 0x00021721
		// (set) Token: 0x06003095 RID: 12437 RVA: 0x00023529 File Offset: 0x00021729
		public int[] FactionEnemies
		{
			get
			{
				return this.m_factionEnemies;
			}
			set
			{
				this.m_factionEnemies = value;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06003096 RID: 12438 RVA: 0x00023532 File Offset: 0x00021732
		// (set) Token: 0x06003097 RID: 12439 RVA: 0x0002353A File Offset: 0x0002173A
		public int YourFactionVote
		{
			get
			{
				return this.m_factionLeaderVote;
			}
			set
			{
				this.m_factionLeaderVote = value;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06003098 RID: 12440 RVA: 0x00023543 File Offset: 0x00021743
		// (set) Token: 0x06003099 RID: 12441 RVA: 0x0002354B File Offset: 0x0002174B
		public int[] HouseAllies
		{
			get
			{
				return this.m_houseAllies;
			}
			set
			{
				this.m_houseAllies = value;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x0600309A RID: 12442 RVA: 0x00023554 File Offset: 0x00021754
		// (set) Token: 0x0600309B RID: 12443 RVA: 0x0002355C File Offset: 0x0002175C
		public int[] HouseEnemies
		{
			get
			{
				return this.m_houseEnemies;
			}
			set
			{
				this.m_houseEnemies = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x0600309C RID: 12444 RVA: 0x00023565 File Offset: 0x00021765
		// (set) Token: 0x0600309D RID: 12445 RVA: 0x0002356D File Offset: 0x0002176D
		public int[] HouseGloryPoints
		{
			get
			{
				return this.m_gloryPoints;
			}
			set
			{
				this.m_gloryPoints = value;
				this.lastHouseGloryPointsUpdate = DateTime.Now;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600309E RID: 12446 RVA: 0x00023581 File Offset: 0x00021781
		// (set) Token: 0x0600309F RID: 12447 RVA: 0x00023589 File Offset: 0x00021789
		public GloryRoundData HouseGloryRoundData
		{
			get
			{
				return this.m_gloryRoundData;
			}
			set
			{
				this.m_gloryRoundData = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060030A0 RID: 12448 RVA: 0x00023592 File Offset: 0x00021792
		public int YourHouse
		{
			get
			{
				FactionData yourFaction = this.YourFaction;
				if (yourFaction == null)
				{
					return 0;
				}
				return yourFaction.houseID;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060030A1 RID: 12449 RVA: 0x000235A5 File Offset: 0x000217A5
		// (set) Token: 0x060030A2 RID: 12450 RVA: 0x000235D0 File Offset: 0x000217D0
		public FactionData YourFaction
		{
			get
			{
				if (RemoteServices.Instance.UserFactionID >= 0)
				{
					return (FactionData)this.m_factionData[RemoteServices.Instance.UserFactionID];
				}
				return null;
			}
			set
			{
				if (value != null && value.factionID >= 0)
				{
					this.m_factionData[value.factionID] = value;
					RemoteServices.Instance.UserFactionID = value.factionID;
					return;
				}
				RemoteServices.Instance.UserFactionID = -1;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060030A3 RID: 12451 RVA: 0x0027E684 File Offset: 0x0027C884
		// (set) Token: 0x060030A4 RID: 12452 RVA: 0x0002360C File Offset: 0x0002180C
		public int SpecialSeaConditionsData
		{
			get
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (currentServerTime.Day == this.seaConditionsDay)
				{
					if (currentServerTime.Hour < 19)
					{
						return this.seaConditionsEarly;
					}
					return this.seaConditionsLate;
				}
				else
				{
					if (currentServerTime.Day == 1 && this.seaConditionsDay > 25)
					{
						return this.seaConditionsLate;
					}
					return 0;
				}
			}
			set
			{
				this.seaConditionsDay = value >> 16;
				this.seaConditionsEarly = (value >> 8 & 255) - 4;
				this.seaConditionsLate = (value & 255) - 4;
			}
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060030A5 RID: 12453 RVA: 0x00023638 File Offset: 0x00021838
		// (set) Token: 0x060030A6 RID: 12454 RVA: 0x00023640 File Offset: 0x00021840
		public List<UserRelationship> UserRelations
		{
			get
			{
				return this.userRelations;
			}
			set
			{
				if (value != null)
				{
					this.userRelations = value;
				}
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060030A7 RID: 12455 RVA: 0x0002364C File Offset: 0x0002184C
		// (set) Token: 0x060030A8 RID: 12456 RVA: 0x00023654 File Offset: 0x00021854
		public List<UserMarker> UserMarkers
		{
			get
			{
				return this.userMarkers;
			}
			set
			{
				if (value != null)
				{
					this.userMarkers = value;
				}
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060030A9 RID: 12457 RVA: 0x00023660 File Offset: 0x00021860
		// (set) Token: 0x060030AA RID: 12458 RVA: 0x0002367C File Offset: 0x0002187C
		public int KillStreakCount
		{
			get
			{
				if (this.KillStreakTimer < VillageMap.getCurrentServerTime())
				{
					return 0;
				}
				return this.m_KillStreakCount;
			}
			set
			{
				this.m_KillStreakCount = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060030AB RID: 12459 RVA: 0x00023685 File Offset: 0x00021885
		public bool LinelessMaps
		{
			get
			{
				return this.bLinelessMap && !this.overrideLinelessMap;
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060030AC RID: 12460 RVA: 0x0002369A File Offset: 0x0002189A
		// (set) Token: 0x060030AD RID: 12461 RVA: 0x000236A2 File Offset: 0x000218A2
		public double ScreenCentreY
		{
			get
			{
				return this.m_screenCentreY;
			}
			set
			{
				this.m_screenCentreY = value;
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060030AE RID: 12462 RVA: 0x000236AB File Offset: 0x000218AB
		// (set) Token: 0x060030AF RID: 12463 RVA: 0x000236B3 File Offset: 0x000218B3
		public double ScreenCentreX
		{
			get
			{
				return this.m_screenCentreX;
			}
			set
			{
				this.m_screenCentreX = value;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060030B0 RID: 12464 RVA: 0x000236BC File Offset: 0x000218BC
		// (set) Token: 0x060030B1 RID: 12465 RVA: 0x000236C4 File Offset: 0x000218C4
		public bool DrawDebugNames
		{
			get
			{
				return this.drawDebugNames;
			}
			set
			{
				this.drawDebugNames = value;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060030B2 RID: 12466 RVA: 0x000236CD File Offset: 0x000218CD
		// (set) Token: 0x060030B3 RID: 12467 RVA: 0x000236D5 File Offset: 0x000218D5
		public bool DrawDebugVillageNames
		{
			get
			{
				return this.drawDebugVillageNames;
			}
			set
			{
				this.drawDebugVillageNames = value;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060030B4 RID: 12468 RVA: 0x000236DE File Offset: 0x000218DE
		public double WorldScale
		{
			get
			{
				return this.m_worldScale;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060030B5 RID: 12469 RVA: 0x000236E6 File Offset: 0x000218E6
		// (set) Token: 0x060030B6 RID: 12470 RVA: 0x0027E6DC File Offset: 0x0027C8DC
		public double WorldZoom
		{
			get
			{
				return 27.0 - this.m_worldZoomInverted;
			}
			set
			{
				this.m_worldZoomInverted = 27.0 - value;
				if (this.m_worldZoomInverted >= 23.0)
				{
					this.m_worldScale = 1.0 / (this.m_worldZoomInverted - 22.0);
					return;
				}
				this.m_worldScale = 24.0 - this.m_worldZoomInverted;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060030B7 RID: 12471 RVA: 0x000236F8 File Offset: 0x000218F8
		public VillageData rolloverTargetVillage
		{
			get
			{
				if (this.m_rolloverTargetVillageNoDelay > 0 && this.m_rolloverTargetVillageNoDelay < GameEngine.Instance.World.villageList.Length)
				{
					return this.villageList[this.m_rolloverTargetVillageNoDelay];
				}
				return null;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060030B8 RID: 12472 RVA: 0x0002372B File Offset: 0x0002192B
		public double ZoomChange
		{
			get
			{
				return this.m_zoomChangeThisFrame;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060030B9 RID: 12473 RVA: 0x00023733 File Offset: 0x00021933
		public bool DragModeActive
		{
			get
			{
				return this.dragMode;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060030BA RID: 12474 RVA: 0x0002373B File Offset: 0x0002193B
		public double ZoomCap
		{
			get
			{
				return this.m_zoomCap;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060030BB RID: 12475 RVA: 0x00023743 File Offset: 0x00021943
		// (set) Token: 0x060030BC RID: 12476 RVA: 0x0002374B File Offset: 0x0002194B
		public bool Zooming
		{
			get
			{
				return this.m_zooming;
			}
			set
			{
				this.m_zooming = value;
			}
		}

		// Token: 0x060030BD RID: 12477 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static void LogArmyErrorIfUnity(string s)
		{
		}

		// Token: 0x060030BE RID: 12478 RVA: 0x0027E744 File Offset: 0x0027C944
		public bool checkRecentRetrievalSend(long armyID)
		{
			foreach (WorldMap.ArmyRetrieveData armyRetrieveData in this.requestedReturnedArmyIDs)
			{
				if (armyRetrieveData.armyID == armyID)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060030BF RID: 12479 RVA: 0x0027E7A0 File Offset: 0x0027C9A0
		public void updateArmyRetrievalData()
		{
			if (this.requestedReturnedArmyIDs.Count > 0)
			{
				DateTime now = DateTime.Now;
				List<WorldMap.ArmyRetrieveData> list = new List<WorldMap.ArmyRetrieveData>();
				foreach (WorldMap.ArmyRetrieveData armyRetrieveData in this.requestedReturnedArmyIDs)
				{
					if (armyRetrieveData.expiryTime < now)
					{
						if (!this.isArmyReallyReturning(armyRetrieveData.armyID))
						{
							RemoteServices.Instance.RetrieveAttackResult(armyRetrieveData.armyID, GameEngine.Instance.World.StoredVillageFactionPos);
							this.requestedReturnedArmyIDs.Remove(armyRetrieveData);
							break;
						}
						list.Add(armyRetrieveData);
					}
				}
				foreach (WorldMap.ArmyRetrieveData item in list)
				{
					this.requestedReturnedArmyIDs.Remove(item);
				}
			}
		}

		// Token: 0x060030C0 RID: 12480 RVA: 0x00023754 File Offset: 0x00021954
		public void RemoveArmy(long id)
		{
			this.armyArray[id] = null;
		}

		// Token: 0x060030C1 RID: 12481 RVA: 0x00023763 File Offset: 0x00021963
		public void SetArmy(WorldMap.LocalArmyData army)
		{
			this.armyArray[army.armyID] = army;
		}

		// Token: 0x060030C2 RID: 12482 RVA: 0x00023777 File Offset: 0x00021977
		public WorldMap.LocalArmyData GetArmyByID(long id)
		{
			return (WorldMap.LocalArmyData)this.armyArray[id];
		}

		// Token: 0x060030C3 RID: 12483 RVA: 0x0002378A File Offset: 0x0002198A
		public void RemoveReinforcementArmy(long id)
		{
			this.reinforcementArray[id] = null;
		}

		// Token: 0x060030C4 RID: 12484 RVA: 0x00023799 File Offset: 0x00021999
		public void SetReinforcementArmy(WorldMap.LocalArmyData army)
		{
			this.reinforcementArray[army.armyID] = army;
		}

		// Token: 0x060030C5 RID: 12485 RVA: 0x000237AD File Offset: 0x000219AD
		public WorldMap.LocalArmyData GetReinformcementArmyByID(long id)
		{
			return (WorldMap.LocalArmyData)this.reinforcementArray[id];
		}

		// Token: 0x060030C6 RID: 12486 RVA: 0x0027E8A0 File Offset: 0x0027CAA0
		public void retrieveArmies()
		{
			this.highestDownloadedArmy = -1L;
			this.armyArray.Clear();
			RemoteServices.Instance.set_GetArmyData_UserCallBack(new RemoteServices.GetArmyData_UserCallBack(this.getArmyData));
			RemoteServices.Instance.set_RetrieveAttackResult_UserCallBack(new RemoteServices.RetrieveAttackResult_UserCallBack(this.retrieveAttackResultCallback));
			RemoteServices.Instance.GetArmyData(-2L);
		}

		// Token: 0x060030C7 RID: 12487 RVA: 0x000237C0 File Offset: 0x000219C0
		public void getArmiesIfNewAttacks()
		{
			RemoteServices.Instance.GetArmyData(this.highestDownloadedArmy);
		}

		// Token: 0x060030C8 RID: 12488 RVA: 0x000237D2 File Offset: 0x000219D2
		public void addExistingArmy(long armyID)
		{
			this.rememberedExistingArmies.Add(armyID);
		}

		// Token: 0x060030C9 RID: 12489 RVA: 0x0027E8FC File Offset: 0x0027CAFC
		public void getArmyData(GetArmyData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.m_newQuestsData != null)
				{
					this.setNewQuestData(returnData.m_newQuestsData);
				}
				this.loadingErrored = false;
				SparseArray sparseArray = new SparseArray();
				if (returnData.existingArmies != null)
				{
					foreach (long num in returnData.existingArmies)
					{
						sparseArray[num] = num;
					}
				}
				if (returnData.armyData != null)
				{
					this.doGetArmyData(returnData.armyData, returnData.reinforcementData, true);
					this.highestArmySeen = returnData.armyHighestSeen;
					foreach (object obj in this.armyArray)
					{
						WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
						localArmyData.singlyAdded = false;
					}
					if (returnData.existingArmies != null)
					{
						foreach (ArmyReturnData armyReturnData in returnData.armyData)
						{
							if (sparseArray[armyReturnData.armyID] == null)
							{
								sparseArray[armyReturnData.armyID] = armyReturnData.armyID;
								returnData.existingArmies.Add(armyReturnData.armyID);
							}
						}
					}
					GameEngine.Instance.setServerDownTime(returnData.serverDowntime);
				}
				List<long> list = new List<long>();
				if (returnData.armyDataNew != null)
				{
					this.doGetArmyData(returnData.armyDataNew, returnData.reinforcementData, false);
					foreach (object obj2 in this.armyArray)
					{
						WorldMap.LocalArmyData localArmyData2 = (WorldMap.LocalArmyData)obj2;
						list.Add(localArmyData2.armyID);
						localArmyData2.singlyAdded = false;
					}
					if (returnData.existingArmies == null)
					{
						goto IL_2A3;
					}
					using (List<ArmyReturnData>.Enumerator enumerator5 = returnData.armyDataNew.GetEnumerator())
					{
						while (enumerator5.MoveNext())
						{
							ArmyReturnData armyReturnData2 = enumerator5.Current;
							if (sparseArray[armyReturnData2.armyID] == null)
							{
								sparseArray[armyReturnData2.armyID] = armyReturnData2.armyID;
								returnData.existingArmies.Add(armyReturnData2.armyID);
							}
						}
						goto IL_2A3;
					}
				}
				if (returnData.existingArmies != null)
				{
					foreach (object obj3 in this.armyArray)
					{
						WorldMap.LocalArmyData localArmyData3 = (WorldMap.LocalArmyData)obj3;
						list.Add(localArmyData3.armyID);
					}
				}
				IL_2A3:
				if (returnData.existingArmies != null)
				{
					List<long> existingArmies = returnData.existingArmies;
					existingArmies.AddRange(this.rememberedExistingArmies);
					sparseArray.Clear();
					foreach (long num2 in existingArmies)
					{
						sparseArray[num2] = num2;
					}
					WorldMap.LocalArmyData.groupCurrentTime = DXTimer.GetCurrentMilliseconds();
					foreach (long num3 in list)
					{
						if (sparseArray[num3] == null)
						{
							WorldMap.LocalArmyData armyByID = this.GetArmyByID(num3);
							if (armyByID != null)
							{
								if (armyByID.attackType == 13 && (VillageMap.getCurrentServerTime() - armyByID.serverEndTime).TotalSeconds < 10.0)
								{
									continue;
								}
								if (RemoteServices.Instance.UserID == armyByID.userID && armyByID.lootType >= 0)
								{
									armyByID.localEndTime = armyByID.localStartTime + 1.0;
									armyByID.updatePosition();
								}
							}
							this.RemoveArmy(num3);
						}
					}
				}
				long num4 = -1L;
				foreach (object obj4 in this.armyArray)
				{
					WorldMap.LocalArmyData localArmyData4 = (WorldMap.LocalArmyData)obj4;
					if (localArmyData4.armyID > num4 && !localArmyData4.singlyAdded)
					{
						num4 = localArmyData4.armyID;
					}
				}
				this.highestDownloadedArmy = num4;
			}
			else
			{
				this.loadingErrored = true;
			}
			if (this.doSelectTutorialArmy)
			{
				this.doSelectTutorialArmy = false;
				InterfaceMgr.Instance.selectTutorialArmy();
			}
			this.rememberedExistingArmies.Clear();
		}

		// Token: 0x060030CA RID: 12490 RVA: 0x0027EDD8 File Offset: 0x0027CFD8
		public void updateExistingArmies(long[] existingArmiesX)
		{
			List<long> list = new List<long>();
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				list.Add(localArmyData.armyID);
			}
			SparseArray sparseArray = new SparseArray();
			foreach (long num in existingArmiesX)
			{
				sparseArray[num] = num;
			}
			WorldMap.LocalArmyData.groupCurrentTime = DXTimer.GetCurrentMilliseconds();
			foreach (long num2 in list)
			{
				if (sparseArray[num2] == null)
				{
					WorldMap.LocalArmyData armyByID = this.GetArmyByID(num2);
					if (armyByID != null && RemoteServices.Instance.UserID == armyByID.userID && armyByID.lootType >= 0)
					{
						armyByID.localEndTime = armyByID.localStartTime + 1.0;
						armyByID.updatePosition();
					}
					this.RemoveArmy(num2);
				}
			}
		}

		// Token: 0x060030CB RID: 12491 RVA: 0x0027EF10 File Offset: 0x0027D110
		public int countIncomingAttacks(ref long highestAttackingArmy)
		{
			int num = 0;
			highestAttackingArmy = -1L;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (this.isUserVillage(localArmyData.targetVillageID) && localArmyData.lootType < 0 && localArmyData.attackType != 30 && localArmyData.attackType != 31)
				{
					num++;
					if (localArmyData.armyID > highestAttackingArmy)
					{
						highestAttackingArmy = localArmyData.armyID;
					}
				}
			}
			return num;
		}

		// Token: 0x060030CC RID: 12492 RVA: 0x0027EFAC File Offset: 0x0027D1AC
		public void doGetArmyData(IEnumerable<ArmyReturnData> armyReturnData, IEnumerable<ArmyReturnData> reinforcementReturnData, bool clearArray)
		{
			if (armyReturnData != null)
			{
				WorldMap.LogArmyErrorIfUnity("Got some armies");
				SparseArray sparseArray = new SparseArray();
				foreach (object obj in this.armyArray)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
					sparseArray[localArmyData.armyID] = localArmyData.requestSent;
				}
				if (clearArray)
				{
					if (armyReturnData != null)
					{
						this.armyArray.Clear();
					}
					if (reinforcementReturnData != null)
					{
						this.reinforcementArray.Clear();
					}
				}
				WorldMap.LocalArmyData.groupCurrentTime = DXTimer.GetCurrentMilliseconds();
				if (armyReturnData != null)
				{
					WorldMap.LogArmyErrorIfUnity("Going to add armies to array");
					int num = 0;
					foreach (ArmyReturnData data in armyReturnData)
					{
						num++;
						this.addArmyToArray(data, ref sparseArray, clearArray);
					}
					WorldMap.LogArmyErrorIfUnity("Should have added " + num.ToString() + " armies");
				}
				if (reinforcementReturnData != null)
				{
					WorldMap.LogArmyErrorIfUnity("Going to add armies to reinforcement array");
					foreach (ArmyReturnData data2 in reinforcementReturnData)
					{
						this.addArmyToArray(data2, ref sparseArray, false);
					}
				}
				IEnumerator enumerator4 = this.armyArray.GetEnumerator();
				while (enumerator4.MoveNext())
				{
						object obj2 = enumerator4.Current;
						WorldMap.LocalArmyData localArmyData2 = (WorldMap.LocalArmyData)obj2;
						if (localArmyData2.lootType == 95)
						{
							double lootLevel = localArmyData2.lootLevel;
							localArmyData2.lootType = 1;
							long id = localArmyData2.armyID - (long)localArmyData2.lootLevel;
							if (this.GetArmyByID(id) != null)
							{
								WorldMap.LocalArmyData armyByID = this.GetArmyByID(id);
								armyByID.dead = true;
							}
						}
				}
			}
			else
			{
				WorldMap.LogArmyErrorIfUnity("Failed to load armies");
			}
		}

	// Token: 0x060030CD RID: 12493 RVA: 0x000237E0 File Offset: 0x000219E0
	public void deleteArmy(long armyID)
	{
			this.RemoveArmy(armyID);
		}

		// Token: 0x060030CE RID: 12494 RVA: 0x0027F1B0 File Offset: 0x0027D3B0
		public void addReinforcementArmy(ArmyReturnData data)
		{
			WorldMap.LocalArmyData.groupCurrentTime = DXTimer.GetCurrentMilliseconds();
			SparseArray sparseArray = null;
			this.addArmyToArray(data, ref sparseArray, false);
		}

		// Token: 0x060030CF RID: 12495 RVA: 0x0027F1D4 File Offset: 0x0027D3D4
		public void AddFakeArmy(ArmyReturnData data)
		{
			SparseArray sparseArray = new SparseArray();
			this.addArmyToArray(data, ref sparseArray, false);
		}

		// Token: 0x060030D0 RID: 12496 RVA: 0x0027F1F4 File Offset: 0x0027D3F4
		private void addArmyToArray(ArmyReturnData data, ref SparseArray armyRequestSentFlag, bool singleAdd)
		{
			WorldMap.LocalArmyData localArmyData = new WorldMap.LocalArmyData();
			localArmyData.armyID = data.armyID;
			localArmyData.homeVillageID = data.homeVillageID;
			localArmyData.travelFromVillageID = data.travelFromVillageID;
			localArmyData.userID = data.userID;
			localArmyData.attackType = data.attackType;
			localArmyData.targetVillageID = data.targetVillageID;
			localArmyData.numPeasants = data.numPeasants;
			localArmyData.numArchers = data.numArchers;
			localArmyData.numPikemen = data.numPikemen;
			localArmyData.numSwordsmen = data.numSwordsmen;
			localArmyData.numCatapults = data.numCatapults;
			localArmyData.numCaptains = data.numCaptains;
			localArmyData.numScouts = data.numScouts;
			localArmyData.captainsCommand = data.captainsCommand;
			localArmyData.carryingFlag = data.carryingFlag;
			localArmyData.lootLevel = data.lootLevel;
			localArmyData.lootType = data.lootType;
			localArmyData.lootData = data.lootData;
			localArmyData.aiPlayer = data.aiPlayer;
			localArmyData.seaTravel = this.isIslandTravel(data.travelFromVillageID, data.targetVillageID);
			localArmyData.reinforcements = data.reinforcements;
			if (singleAdd)
			{
				localArmyData.singlyAdded = true;
			}
			try
			{
				if (localArmyData.targetVillageID >= 0 && localArmyData.targetVillageID < this.villageList.Length)
				{
					localArmyData.createJourney(data.startTime, data.curTime, data.endTime);
					localArmyData.targetDisplayX = (double)this.villageList[data.targetVillageID].x;
					localArmyData.targetDisplayY = (double)this.villageList[data.targetVillageID].y;
				}
				else
				{
					localArmyData.serverEndTime = data.curTime;
				}
				if (localArmyData.travelFromVillageID < this.villageList.Length)
				{
					localArmyData.baseDisplayX = (double)this.villageList[data.travelFromVillageID].x;
					localArmyData.baseDisplayY = (double)this.villageList[data.travelFromVillageID].y;
				}
				if (!localArmyData.reinforcements && armyRequestSentFlag != null && armyRequestSentFlag[localArmyData.armyID] != null)
				{
					localArmyData.requestSent = (bool)armyRequestSentFlag[localArmyData.armyID];
				}
				localArmyData.updatePosition();
				if (!data.reinforcements)
				{
					this.SetArmy(localArmyData);
				}
				else
				{
					this.reinforcementArray[data.armyID] = localArmyData;
				}
			}
			catch
			{
			}
		}

		// Token: 0x060030D1 RID: 12497 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void armyAttackCallback(ArmyAttack_ReturnType returnData)
		{
		}

		// Token: 0x060030D2 RID: 12498 RVA: 0x0027F44C File Offset: 0x0027D64C
		public void retrieveAttackResultCallback(RetrieveAttackResult_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.armyData != null)
			{
				if (this.tutorialArmyID != -1L && returnData.armyData.armyID == this.tutorialArmyID)
				{
					this.tutorialArmyID = -1L;
					TutorialBattleReportPopup tutorialBattleReportPopup = new TutorialBattleReportPopup();
					tutorialBattleReportPopup.init();
					tutorialBattleReportPopup.Show(InterfaceMgr.Instance.ParentForm);
				}
				if (this.isUserVillage(returnData.armyData.targetVillageID) || this.isUserRelatedVillage(returnData.armyData.targetVillageID))
				{
					GameEngine.Instance.flushVillage(returnData.armyData.targetVillageID);
				}
				WorldMap.LocalArmyData armyByID = this.GetArmyByID(returnData.armyData.armyID);
				if (armyByID == null)
				{
					return;
				}
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					CastleRepairService castleRepairService = controlForm.CastleRepairService;
					if (castleRepairService != null)
					{
						castleRepairService.LaunchCastleRepair(armyByID);
					}
				}
				if (returnData.armyData.dead)
				{
					this.RemoveArmy(returnData.armyData.armyID);
					return;
				}
				this.doGetArmyData(new ArmyReturnData[]
				{
					returnData.armyData
				}, null, false);
				if (returnData.reinforcementData != null)
				{
					this.doGetArmyData(null, returnData.reinforcementData, true);
				}
			}
			if (returnData.villageUpdateList != null)
			{
				if (returnData.userVillageList != null)
				{
					bool flag = this.retrievingUserVillages;
					this.retrievingUserVillages = true;
					this.processVillageFactionChangesList(returnData.villageUpdateList, returnData.currentVillageChangePos);
					this.retrievingUserVillages = flag;
				}
				else
				{
					this.processVillageFactionChangesList(returnData.villageUpdateList, returnData.currentVillageChangePos);
				}
			}
			else if (returnData.villageOwnerFactions != null)
			{
				this.processVillageFactionList(returnData.villageOwnerFactions, returnData.currentVillageChangePos);
			}
			if (returnData.userVillageList != null)
			{
				GameEngine.Instance.World.doGetUserVillages(returnData.userVillageList, returnData.userVillageNameList);
			}
			this.setPoints(returnData.currentPoints);
			this.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
			this.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
			this.setNumMadeCaptains(returnData.numMadeCaptains);
			if (returnData.cardData != null)
			{
				GameEngine.Instance.cardsManager.UserCardData = returnData.cardData;
			}
		}

		// Token: 0x060030D3 RID: 12499 RVA: 0x0027F64C File Offset: 0x0027D84C
		private long findNearestArmyFromScreenPos(Point mousePos, ref double bestDist)
		{
			if (InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return -1L;
			}
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestArmyFromMapPos(num, num2, ref bestDist);
			}
			return -1L;
		}

		// Token: 0x060030D4 RID: 12500 RVA: 0x0027F6F4 File Offset: 0x0027D8F4
		private long findNearestArmyFromMapPos(double mapX, double mapY, ref double bestDist)
		{
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			long result = -1L;
			double num = 2.25;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (worldMapFilter.showArmy(localArmyData))
				{
					double num2 = (localArmyData.displayX - mapX) * (localArmyData.displayX - mapX) + (localArmyData.displayY - mapY) * (localArmyData.displayY - mapY);
					if (num2 < num)
					{
						num = num2;
						result = localArmyData.armyID;
					}
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x060030D5 RID: 12501 RVA: 0x0027F7B0 File Offset: 0x0027D9B0
		private long findNearestReinforcementFromScreenPos(Point mousePos, ref double bestDist)
		{
			if (InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return -1L;
			}
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestReinforcementFromMapPos(num, num2, ref bestDist);
			}
			return -1L;
		}

		// Token: 0x060030D6 RID: 12502 RVA: 0x0027F858 File Offset: 0x0027DA58
		private long findNearestReinforcementFromMapPos(double mapX, double mapY, ref double bestDist)
		{
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			long result = -1L;
			double num = 2.25;
			double num2 = DXTimer.GetCurrentMilliseconds() / 1000.0;
			foreach (object obj in this.reinforcementArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.localEndTime != 0.0 && localArmyData.localEndTime >= num2 && worldMapFilter.showReinforcements(localArmyData))
				{
					double num3 = (localArmyData.displayX - mapX) * (localArmyData.displayX - mapX) + (localArmyData.displayY - mapY) * (localArmyData.displayY - mapY);
					if (num3 < num)
					{
						num = num3;
						result = localArmyData.armyID;
					}
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x060030D7 RID: 12503 RVA: 0x0027F944 File Offset: 0x0027DB44
		public bool isArmyMoving(long armyID)
		{
			WorldMap.LocalArmyData armyByID = this.GetArmyByID(armyID);
			return armyByID != null && armyByID.targetVillageID >= 0;
		}

		// Token: 0x060030D8 RID: 12504 RVA: 0x0027F968 File Offset: 0x0027DB68
		public bool isArmyReallyReturning(long armyID)
		{
			WorldMap.LocalArmyData armyByID = this.GetArmyByID(armyID);
			return armyByID == null || armyByID.lootType != 10000;
		}

		// Token: 0x060030D9 RID: 12505 RVA: 0x000237E9 File Offset: 0x000219E9
		public WorldMap.LocalArmyData getArmy(long armyID)
		{
			if (armyID >= 0L)
			{
				return this.GetArmyByID(armyID);
			}
			return null;
		}

		// Token: 0x060030DA RID: 12506 RVA: 0x000237F9 File Offset: 0x000219F9
		public SparseArray getArmyArray()
		{
			return this.armyArray;
		}

		// Token: 0x060030DB RID: 12507 RVA: 0x0027F990 File Offset: 0x0027DB90
		public int countYourArmyTroops(int villageID)
		{
			int num = 0;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.travelFromVillageID == villageID && localArmyData.homeVillageID == villageID)
				{
					num += localArmyData.numPeasants;
					num += localArmyData.numArchers;
					num += localArmyData.numPikemen;
					num += localArmyData.numSwordsmen;
					num += localArmyData.numCatapults;
				}
			}
			return num;
		}

		// Token: 0x060030DC RID: 12508 RVA: 0x0027FA24 File Offset: 0x0027DC24
		public int countYourArmyScouts(int villageID)
		{
			int num = 0;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.homeVillageID == villageID)
				{
					num += localArmyData.numScouts;
				}
			}
			return num;
		}

		// Token: 0x060030DD RID: 12509 RVA: 0x0027FA8C File Offset: 0x0027DC8C
		public int countYourArmyCaptains(int villageID)
		{
			int num = 0;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.travelFromVillageID == villageID)
				{
					num += localArmyData.numCaptains;
				}
			}
			return num;
		}

		// Token: 0x060030DE RID: 12510 RVA: 0x00023801 File Offset: 0x00021A01
		public WorldMap.LocalArmyData getReinforcement(long armyID)
		{
			if (armyID >= 0L)
			{
				return (WorldMap.LocalArmyData)this.reinforcementArray[armyID];
			}
			return null;
		}

		// Token: 0x060030DF RID: 12511 RVA: 0x0002381B File Offset: 0x00021A1B
		public SparseArray getReinforcementsArray()
		{
			return this.reinforcementArray;
		}

		// Token: 0x060030E0 RID: 12512 RVA: 0x0027FAF4 File Offset: 0x0027DCF4
		public void getReinforceTotals(int villageID, ref int numPeasants, ref int numArchers, ref int numPikemen, ref int numSwordsmen)
		{
			numPeasants = 0;
			numArchers = 0;
			numPikemen = 0;
			numSwordsmen = 0;
			int num = 0;
			foreach (object obj in this.reinforcementArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.targetVillageID == villageID && localArmyData.serverEndTime < VillageMap.getCurrentServerTime())
				{
					numPeasants += localArmyData.numPeasants;
					numArchers += localArmyData.numArchers;
					numPikemen += localArmyData.numPikemen;
					numSwordsmen += localArmyData.numSwordsmen;
					num += localArmyData.numCatapults;
				}
			}
		}

		// Token: 0x060030E1 RID: 12513 RVA: 0x0027FBAC File Offset: 0x0027DDAC
		public int countYourReinforcementTroops(int villageID)
		{
			int num = 0;
			foreach (object obj in this.reinforcementArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.homeVillageID == villageID)
				{
					num += localArmyData.numPeasants;
					num += localArmyData.numArchers;
					num += localArmyData.numPikemen;
					num += localArmyData.numSwordsmen;
					num += localArmyData.numCatapults;
				}
			}
			return num;
		}

		// Token: 0x060030E2 RID: 12514 RVA: 0x0027FC38 File Offset: 0x0027DE38
		public void getTotalTroopsOutOfVillage(int villageID, ref int numPeasants, ref int numArchers, ref int numPikemen, ref int numSwordsmen, ref int numCatapults, ref int numCaptains, ref int numReinfPeasants, ref int numReinfArchers, ref int numReinfPikemen, ref int numReinfSwordsmen, ref int numReinfCatapults, ref int numReinfCaptains)
		{
			numPeasants = 0;
			numArchers = 0;
			numPikemen = 0;
			numSwordsmen = 0;
			numCatapults = 0;
			numCaptains = 0;
			numReinfPeasants = 0;
			numReinfArchers = 0;
			numReinfPikemen = 0;
			numReinfSwordsmen = 0;
			numReinfCatapults = 0;
			numReinfCaptains = 0;
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.travelFromVillageID == villageID && localArmyData.homeVillageID == villageID)
				{
					numPeasants += localArmyData.numPeasants;
					numArchers += localArmyData.numArchers;
					numPikemen += localArmyData.numPikemen;
					numSwordsmen += localArmyData.numSwordsmen;
					numCatapults += localArmyData.numCatapults;
					numCaptains += localArmyData.numCaptains;
				}
			}
			foreach (object obj2 in this.reinforcementArray)
			{
				WorldMap.LocalArmyData localArmyData2 = (WorldMap.LocalArmyData)obj2;
				if (localArmyData2.travelFromVillageID == villageID)
				{
					numReinfPeasants += localArmyData2.numPeasants;
					numReinfArchers += localArmyData2.numArchers;
					numReinfPikemen += localArmyData2.numPikemen;
					numReinfSwordsmen += localArmyData2.numSwordsmen;
					numReinfCatapults += localArmyData2.numCatapults;
				}
			}
		}

		// Token: 0x060030E3 RID: 12515 RVA: 0x0027FDA8 File Offset: 0x0027DFA8
		public static string getPeopleStatusString(int remaining, int total, double[] returnTimes)
		{
			if (remaining > 0 || total == 0)
			{
				return remaining.ToString();
			}
			double num = 0.0;
			double num2 = double.MaxValue;
			if (returnTimes != null && returnTimes.Length != 0)
			{
				for (int i = 0; i < returnTimes.Length; i++)
				{
					if (returnTimes[i] < num2)
					{
						num2 = returnTimes[i];
					}
				}
				double num3 = DXTimer.GetCurrentMilliseconds() / 1000.0;
				num = num2 - num3;
				if (num < 0.0)
				{
					num = 0.0;
				}
			}
			return VillageMap.createBuildTimeString((int)num);
		}

		// Token: 0x060030E4 RID: 12516 RVA: 0x0027FE28 File Offset: 0x0027E028
		public double[] getScoutTimes()
		{
			if (this.thisVillageArmies == null)
			{
				return null;
			}
			List<double> list = new List<double>();
			for (int i = 0; i < this.thisVillageArmies.Count; i++)
			{
				long index = this.thisVillageArmies[i];
				if (this.armyArray[index] != null)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)this.armyArray[index];
					if (localArmyData.isScouts())
					{
						bool flag = localArmyData.lootType >= 0;
						double num = localArmyData.localEndTime;
						if (!flag)
						{
							num += (double)(localArmyData.serverEndTime - localArmyData.serverStartTime).Seconds;
						}
						list.Add(num);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060030E5 RID: 12517 RVA: 0x0027FEDC File Offset: 0x0027E0DC
		public void updateArmies()
		{
			try
			{
				List<long> list = new List<long>();
				WorldMap.LocalArmyData.groupCurrentTime = DXTimer.GetCurrentMilliseconds();
				foreach (object obj in this.armyArray)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
					localArmyData.updatePosition();
					if (localArmyData.dead)
					{
						list.Add(localArmyData.armyID);
					}
				}
				foreach (long index in list)
				{
					this.armyArray.RemoveAt(index);
				}
				List<long> list2 = new List<long>();
				foreach (object obj2 in this.reinforcementArray)
				{
					WorldMap.LocalArmyData localArmyData2 = (WorldMap.LocalArmyData)obj2;
					localArmyData2.updatePosition();
					if (localArmyData2.dead)
					{
						list2.Add(localArmyData2.armyID);
					}
				}
				foreach (long index2 in list2)
				{
					this.reinforcementArray.RemoveAt(index2);
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("exception updating armies " + ex.ToString());
			}
		}

		// Token: 0x060030E6 RID: 12518 RVA: 0x00023823 File Offset: 0x00021A23
		public bool isForagingArmy(long armyID)
		{
			return this.scoutsForaging[armyID] != null;
		}

		// Token: 0x060030E7 RID: 12519 RVA: 0x00023836 File Offset: 0x00021A36
		public bool isForagingVillage(int villageID)
		{
			return this.scoutsVillageForaging[villageID] != null;
		}

		// Token: 0x060030E8 RID: 12520 RVA: 0x00023849 File Offset: 0x00021A49
		public bool isAttackingArmy(long armyID)
		{
			return this.attackingArmies[armyID] != null;
		}

		// Token: 0x060030E9 RID: 12521 RVA: 0x0002385C File Offset: 0x00021A5C
		public bool isVillageInvolvedInAttacks(int villageID)
		{
			return this.villagesInvolvedInAttacks[villageID] != null;
		}

		// Token: 0x060030EA RID: 12522 RVA: 0x0002386F File Offset: 0x00021A6F
		public bool isVillageInvolvedInAIAttacks(int villageID)
		{
			return this.villagesInvolvedInAIAttacks[villageID] != null;
		}

		// Token: 0x060030EB RID: 12523 RVA: 0x002800B8 File Offset: 0x0027E2B8
		public long getTutorialArmyID()
		{
			foreach (object obj in this.armyArray)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.attackType == 13)
				{
					return localArmyData.armyID;
				}
			}
			return -1L;
		}

		// Token: 0x060030EC RID: 12524 RVA: 0x00280124 File Offset: 0x0027E324
		public void drawArmies(RectangleF screenRect, bool normalMode)
		{
			this.alphaPulse += 20;
			if (this.alphaPulse > 755)
			{
				this.alphaPulse -= 3011;
			}
			if (this.alphaPulse > 255)
			{
				this.alphaValue = 255;
			}
			else if (this.alphaPulse >= 0)
			{
				this.alphaValue = this.alphaPulse;
			}
			else
			{
				this.alphaValue = -2000 - this.alphaPulse;
				if (this.alphaValue < 0)
				{
					this.alphaValue = 0;
				}
			}
			try
			{
				this.scoutsForaging.Clear();
				this.scoutsVillageForaging.Clear();
				this.villagesInvolvedInAttacks.Clear();
				this.attackingArmies.Clear();
				this.villagesInvolvedInAIAttacks.Clear();
				float num = (float)this.m_worldScale / 28f / 0.6f;
				if (num < 0.1f)
				{
					num = 0.1f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				List<long> list = new List<long>();
				WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
				this.armyIconsFilter.Clear();
				float localScale = num;
				bool filtering = worldMapFilter.FilterActive && InterfaceMgr.Instance.WorldMapMode == 0;
				foreach (object obj in this.armyArray)
				{
					WorldMap.LocalArmyData army = (WorldMap.LocalArmyData)obj;
					this.DrawArmy(army, localScale, num, filtering, worldMapFilter, list, normalMode, screenRect, false);
				}
				foreach (long index in list)
				{
					this.armyArray.RemoveAt(index);
				}
				foreach (object obj2 in this.reinforcementArray)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj2;
					if (localArmyData.visible && localArmyData.isVisible(screenRect) && worldMapFilter.showReinforcements(localArmyData))
					{
						int spriteNo = 1;
						this.villageSprite.PosX = (float)(localArmyData.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						this.villageSprite.PosY = (float)(localArmyData.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						this.villageSprite.SpriteNo = spriteNo;
						this.villageSprite.Center = new PointF(44f, 44f);
						this.villageSprite.RotationAngle = SpriteWrapper.getFacing(localArmyData.BasePoint(), localArmyData.TargetPoint());
						this.villageSprite.Scale = num;
						this.villageSprite.Update();
						this.doDraw(this.villageSprite);
						spriteNo = 5;
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						this.villageSprite.SpriteNo = spriteNo;
						this.villageSprite.Center = new PointF(44f, 44f);
						this.villageSprite.Scale = num;
						this.villageSprite.Update();
						this.doDraw(this.villageSprite);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060030ED RID: 12525 RVA: 0x002804EC File Offset: 0x0027E6EC
		private bool DrawArmy(WorldMap.LocalArmyData army, float localScale, float scale, bool filtering, WorldMapFilter filter, List<long> armiesDead, bool normalMode, RectangleF screenRect, bool visChecked)
		{
			if (army.dead)
			{
				armiesDead.Add(army.armyID);
				return false;
			}
			if (!normalMode && army.attackType != 17)
			{
				return false;
			}
			bool flag = true;
			if (filtering)
			{
				if (army.isScouts())
				{
					if (this.isForagingSpecial(army.targetVillageID))
					{
						this.scoutsForaging[army.armyID] = army.armyID;
						this.scoutsVillageForaging[army.homeVillageID] = army.homeVillageID;
					}
					else
					{
						this.attackingArmies[army.armyID] = army.armyID;
						this.villagesInvolvedInAttacks[army.homeVillageID] = army.homeVillageID;
						this.villagesInvolvedInAttacks[army.targetVillageID] = army.targetVillageID;
					}
				}
				else
				{
					this.attackingArmies[army.armyID] = army.armyID;
					this.villagesInvolvedInAttacks[army.homeVillageID] = army.homeVillageID;
					this.villagesInvolvedInAttacks[army.targetVillageID] = army.targetVillageID;
				}
				flag = filter.showArmy(army);
				if (flag)
				{
					this.villagesInvolvedInAIAttacks[army.homeVillageID] = army.homeVillageID;
					this.villagesInvolvedInAIAttacks[army.targetVillageID] = army.targetVillageID;
				}
			}
			if ((!visChecked && !army.isVisible(screenRect)) || !flag)
			{
				return false;
			}
			localScale = scale;
			if (army.attackType == 17 && localScale < 0.5f)
			{
				localScale = 0.5f;
			}
			this.villageSprite.PosX = (float)(army.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			this.villageSprite.PosY = (float)(army.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			int index = (int)this.villageSprite.PosX / 3 * 100000 + (int)this.villageSprite.PosY / 3;
			if (this.armyIconsFilter[index] != null)
			{
				return false;
			}
			this.armyIconsFilter[index] = 1;
			int num = 2;
			int num2 = 6;
			if (army.attackType == 31 || army.attackType == 30)
			{
				num2 = 5;
				num = 1;
			}
			else if (army.isScouts())
			{
				num2 = 14;
				num = 2;
				if (army.userID != RemoteServices.Instance.UserID)
				{
					num2++;
					num++;
					if (GameEngine.Instance.LocalWorldData.AIWorld)
					{
						switch (this.villageList[army.travelFromVillageID].special)
						{
						case 7:
						case 8:
							num2 = 403;
							num = 404;
							break;
						case 9:
						case 10:
							num2 = 407;
							num = 408;
							break;
						case 11:
						case 12:
							num2 = 411;
							num = 412;
							break;
						case 13:
						case 14:
							num2 = 415;
							num = 416;
							break;
						}
					}
				}
			}
			else if (army.isCaptainAttack())
			{
				num2 = 384;
				num = 2;
				if (army.userID != RemoteServices.Instance.UserID)
				{
					num2++;
					num++;
					if (GameEngine.Instance.LocalWorldData.AIWorld)
					{
						int special = this.villageList[army.travelFromVillageID].special;
						switch (special)
						{
						case 7:
						case 8:
							num2 = 405;
							num = 404;
							break;
						case 9:
						case 10:
							num2 = 409;
							num = 408;
							break;
						case 11:
						case 12:
							num2 = 413;
							num = 412;
							break;
						case 13:
						case 14:
							num2 = 417;
							num = 416;
							break;
						default:
							if (special == 30)
							{
								bool flag2 = false;
								int special2 = this.villageList[army.targetVillageID].special;
								if (special2 - 7 <= 7)
								{
									num2 = 5;
									num = 1;
									flag2 = true;
								}
								if (!flag2)
								{
									switch (army.aiPlayer)
									{
									case 0:
										num2 = 405;
										num = 404;
										break;
									case 1:
										num2 = 409;
										num = 408;
										break;
									case 2:
										num2 = 413;
										num = 412;
										break;
									case 3:
										num2 = 417;
										num = 416;
										break;
									}
								}
							}
							break;
						}
					}
				}
			}
			else if (army.userID != RemoteServices.Instance.UserID)
			{
				num2 = 7;
				num = 3;
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					int special3 = this.villageList[army.travelFromVillageID].special;
					switch (special3)
					{
					case 7:
					case 8:
						num2 = 402;
						num = 404;
						break;
					case 9:
					case 10:
						num2 = 406;
						num = 408;
						break;
					case 11:
					case 12:
						num2 = 410;
						num = 412;
						break;
					case 13:
					case 14:
						num2 = 414;
						num = 416;
						break;
					default:
						if (special3 == 30)
						{
							bool flag3 = false;
							int special4 = this.villageList[army.targetVillageID].special;
							if (special4 - 7 <= 7)
							{
								num2 = 5;
								num = 1;
								flag3 = true;
							}
							if (!flag3)
							{
								VillageData villageData = this.villageList[army.targetVillageID];
								if (villageData.visible && villageData.userID <= 0 && villageData.special == 0)
								{
									switch (army.aiPlayer)
									{
									case 0:
										num2 = 405;
										num = 404;
										break;
									case 1:
										num2 = 409;
										num = 408;
										break;
									case 2:
										num2 = 413;
										num = 412;
										break;
									case 3:
										num2 = 417;
										num = 416;
										break;
									}
									flag3 = true;
								}
							}
							if (!flag3)
							{
								switch (army.aiPlayer)
								{
								case 0:
									num2 = 402;
									num = 404;
									break;
								case 1:
									num2 = 406;
									num = 408;
									break;
								case 2:
									num2 = 410;
									num = 412;
									break;
								case 3:
									num2 = 414;
									num = 416;
									break;
								}
							}
						}
						break;
					}
				}
			}
			if (this.DrawingArmyArrows)
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = num;
				this.villageSprite.Center = new PointF(44f, 44f);
				this.villageSprite.RotationAngle = SpriteWrapper.getFacing(army.BasePoint(), army.TargetPoint());
				this.villageSprite.Scale = localScale;
				this.villageSprite.Update();
				this.doDraw(this.villageSprite);
			}
			this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
			this.villageSprite.SpriteNo = num2;
			this.villageSprite.Center = new PointF(44f, 44f);
			this.villageSprite.Scale = localScale;
			this.villageSprite.Update();
			this.doDraw(this.villageSprite);
			if (army.seaTravel)
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				if (num <= 404)
				{
					switch (num)
					{
					case 0:
						this.villageSprite.SpriteNo = 425;
						break;
					case 1:
						this.villageSprite.SpriteNo = 426;
						break;
					case 2:
						this.villageSprite.SpriteNo = 427;
						break;
					case 3:
						this.villageSprite.SpriteNo = 428;
						break;
					default:
						if (num == 404)
						{
							this.villageSprite.SpriteNo = 429;
						}
						break;
					}
				}
				else if (num != 408)
				{
					if (num != 412)
					{
						if (num == 416)
						{
							this.villageSprite.SpriteNo = 432;
						}
					}
					else
					{
						this.villageSprite.SpriteNo = 431;
					}
				}
				else
				{
					this.villageSprite.SpriteNo = 430;
				}
				this.villageSprite.Center = new PointF(44f, 44f);
				this.villageSprite.ColorToUse = Color.FromArgb(this.alphaValue, global::ARGBColors.White);
				this.villageSprite.Scale = localScale;
				this.villageSprite.Update();
				this.doDraw(this.villageSprite);
			}
			if (army.carryingFlag)
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
				this.villageSprite.SpriteNo = 29;
				this.villageSprite.Center = new PointF(44f, 59f);
				this.villageSprite.Scale = localScale;
				this.villageSprite.Update();
				this.doDraw(this.villageSprite);
			}
			return true;
		}

		// Token: 0x060030EE RID: 12526 RVA: 0x00023882 File Offset: 0x00021A82
		private void doDraw(SpriteWrapper wrapper)
		{
			wrapper.DrawAndClear();
		}

		// Token: 0x060030EF RID: 12527 RVA: 0x0002388A File Offset: 0x00021A8A
		private bool isInWolfsRevenge()
		{
			return !(this.wolfsRevengeEnd < VillageMap.getCurrentServerTime());
		}

		// Token: 0x060030F0 RID: 12528 RVA: 0x00280DE8 File Offset: 0x0027EFE8
		public void updateAIInvasions()
		{
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				int[] invasionVillages = AIWorldSettings.getInvasionVillages(GameEngine.Instance.LocalWorldData.EUAIWorld);
				int[] array = invasionVillages;
				foreach (int index in array)
				{
					this.invasionMarkerState[index] = 0;
				}
				foreach (object obj in this.armyArray)
				{
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
					if (localArmyData.attackType == 17)
					{
						this.invasionMarkerState[localArmyData.homeVillageID] = 2;
					}
				}
				if (this.invasionInfo != null)
				{
					DateTime t = VillageMap.getCurrentServerTime().AddDays(10.0);
					foreach (AIWorldInvasionData aiworldInvasionData in this.invasionInfo)
					{
						if (aiworldInvasionData.date < t && this.invasionMarkerState[aiworldInvasionData.invasionVillageID] != null && (int)this.invasionMarkerState[aiworldInvasionData.invasionVillageID] != 2)
						{
							this.invasionMarkerState[aiworldInvasionData.invasionVillageID] = 1;
						}
					}
				}
			}
		}

		// Token: 0x060030F1 RID: 12529 RVA: 0x000238A1 File Offset: 0x00021AA1
		public int getAIInvasionMarkerState(int villageID)
		{
			if (this.invasionMarkerState[villageID] == null)
			{
				return 0;
			}
			return (int)this.invasionMarkerState[villageID];
		}

		// Token: 0x060030F2 RID: 12530 RVA: 0x00280F70 File Offset: 0x0027F170
		public DateTime getNextAIInvasionDate(int villageID)
		{
			foreach (AIWorldInvasionData aiworldInvasionData in this.invasionInfo)
			{
				if (aiworldInvasionData.invasionVillageID == villageID)
				{
					return aiworldInvasionData.date;
				}
			}
			return DateTime.MinValue;
		}

		// Token: 0x060030F3 RID: 12531 RVA: 0x00280FD8 File Offset: 0x0027F1D8
		public void monitorAIInvasionActivity()
		{
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				if (this.lastInvasionInfoTime < DateTime.Now)
				{
					this.downloadAIInvasionInfo();
					return;
				}
				if (this.lastUpdateInvasionInfoTime < DateTime.Now)
				{
					this.lastUpdateInvasionInfoTime = DateTime.Now.AddMinutes(5.0);
					this.updateAIInvasions();
				}
			}
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x00281044 File Offset: 0x0027F244
		public void downloadAIInvasionInfo()
		{
			this.wolfsRevengeStart = DateTime.MinValue;
			this.wolfsRevengeEnd = DateTime.MinValue;
			this.lastInvasionInfoTime = DateTime.Now.AddHours(1.0);
			this.lastUpdateInvasionInfoTime = DateTime.Now.AddMinutes(5.0);
			RemoteServices.Instance.set_GetInvasionInfo_UserCallBack(new RemoteServices.GetInvasionInfo_UserCallBack(this.GetInvasionInfo_callback));
			RemoteServices.Instance.GetInvasionInfo();
		}

		// Token: 0x060030F5 RID: 12533 RVA: 0x002810C0 File Offset: 0x0027F2C0
		public void GetInvasionInfo_callback(GetInvasionInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			this.aiWorldGloryWinLevel = returnData.gloryRoundWinPoints;
			this.invasionInfo = returnData.invasions;
			if (this.invasionInfo == null)
			{
				this.invasionInfo = new List<AIWorldInvasionData>();
			}
			for (int i = 0; i < this.invasionInfo.Count; i++)
			{
				AIWorldInvasionData aiworldInvasionData = this.invasionInfo[i];
				if (aiworldInvasionData.invasionID == -12345)
				{
					AIWorldInvasionData aiworldInvasionData2 = this.invasionInfo[i + 1];
					this.wolfsRevengeStart = aiworldInvasionData.date;
					this.wolfsRevengeEnd = aiworldInvasionData2.date;
					this.invasionInfo.Remove(aiworldInvasionData);
					this.invasionInfo.Remove(aiworldInvasionData2);
					break;
				}
			}
			this.updateAIInvasions();
		}

		// Token: 0x060030F6 RID: 12534 RVA: 0x0012C738 File Offset: 0x0012A938
		public int getInt32FromString(string text)
		{
			if (text.Length == 0)
			{
				return 0;
			}
			try
			{
				return Convert.ToInt32(text);
			}
			catch (Exception)
			{
			}
			return 0;
		}

		// Token: 0x060030F7 RID: 12535 RVA: 0x0028117C File Offset: 0x0027F37C
		public double getDoubleFromString(string text)
		{
			if (text.Length == 0)
			{
				return 0.0;
			}
			try
			{
				return Convert.ToDouble(text);
			}
			catch (Exception)
			{
			}
			return 0.0;
		}

		// Token: 0x060030F8 RID: 12536 RVA: 0x002811C4 File Offset: 0x0027F3C4
		private bool isVisible(RectangleF screenRect, float displayX, float displayY)
		{
			return screenRect.Top - 50f <= displayY && screenRect.Left - 50f <= displayX && screenRect.Bottom + 50f >= displayY && screenRect.Right + 50f >= displayX;
		}

		// Token: 0x060030F9 RID: 12537 RVA: 0x0028121C File Offset: 0x0027F41C
		private bool isVisibleClose(RectangleF screenRect, float displayX, float displayY)
		{
			return screenRect.Top - 5f <= displayY && screenRect.Left - 5f <= displayX && screenRect.Bottom + 5f >= displayY && screenRect.Right + 5f >= displayX;
		}

		// Token: 0x060030FA RID: 12538 RVA: 0x00281274 File Offset: 0x0027F474
		public void initFW()
		{
			for (int i = 0; i < 25; i++)
			{
				WorldMap.FWData fwdata = new WorldMap.FWData();
				fwdata.spriteID = this.fwSpriteIDs[i] + 95;
				fwdata.numToSpawn = 25;
				fwdata.symmetrical = false;
				fwdata.randomStartRotation = false;
				fwdata.rotateSpeed = 0f;
				fwdata.rotateClockwise = true;
				fwdata.startScale = 1f;
				fwdata.scaleSpeed = 0f;
				fwdata.scaleTarget = 1f;
				fwdata.fadeInTime = 0;
				fwdata.fadeOutTime = 300;
				fwdata.fadeRate = 0.06f;
				fwdata.initialVelocity = 0.3f;
				fwdata.maxVelocity = 0.3f;
				fwdata.acceleration = 0f;
				fwdata.speedVariance = 0.3f;
				fwdata.childFirework = 0;
				this.fwDataList[i] = fwdata;
			}
			this.fwChickenOrder[0] = 1;
			this.fwSheepOrder[0] = 1;
			this.fwJesterOrder[0] = 1;
			this.fwPigOrder[0] = 1;
			string[] array = this.fwSourceData.Split(new char[]
			{
				','
			});
			int num = 0;
			this.totalNumFW = this.getInt32FromString(array[num++]);
			this.totalNumFWBusy = this.getInt32FromString(array[num++]);
			this.totalNumFWCrazy = this.getInt32FromString(array[num++]);
			this.fwNormalChance = this.getInt32FromString(array[num++]);
			this.fwBusyChance = this.getInt32FromString(array[num++]);
			this.fwCrazyChance = this.getInt32FromString(array[num++]);
			this.fwCycle = this.getInt32FromString(array[num++]);
			for (int j = 0; j < 3; j++)
			{
				this.fwChickenOrder[j] = this.getInt32FromString(array[num++]);
				this.fwSheepOrder[j] = this.getInt32FromString(array[num++]);
				this.fwJesterOrder[j] = this.getInt32FromString(array[num++]);
				this.fwPigOrder[j] = this.getInt32FromString(array[num++]);
			}
			for (int k = 0; k < 25; k++)
			{
				WorldMap.FWData fwdata2 = this.fwDataList[k];
				fwdata2.numToSpawn = this.getInt32FromString(array[num++]);
				fwdata2.symmetrical = (this.getInt32FromString(array[num++]) > 0);
				fwdata2.randomStartRotation = (this.getInt32FromString(array[num++]) > 0);
				fwdata2.rotateSpeed = (float)this.getDoubleFromString(array[num++]);
				fwdata2.rotateClockwise = (this.getInt32FromString(array[num++]) > 0);
				fwdata2.startScale = (float)this.getDoubleFromString(array[num++]);
				fwdata2.scaleSpeed = (float)this.getDoubleFromString(array[num++]);
				fwdata2.scaleTarget = (float)this.getDoubleFromString(array[num++]);
				fwdata2.fadeInTime = this.getInt32FromString(array[num++]);
				fwdata2.fadeOutTime = this.getInt32FromString(array[num++]);
				fwdata2.fadeRate = (float)this.getDoubleFromString(array[num++]);
				fwdata2.initialVelocity = (float)this.getDoubleFromString(array[num++]);
				fwdata2.maxVelocity = (float)this.getDoubleFromString(array[num++]);
				fwdata2.acceleration = (float)this.getDoubleFromString(array[num++]);
				fwdata2.speedVariance = (float)this.getDoubleFromString(array[num++]);
				fwdata2.childFirework = this.getInt32FromString(array[num++]);
			}
		}

		// Token: 0x060030FB RID: 12539 RVA: 0x000238C4 File Offset: 0x00021AC4
		public void clearFW()
		{
			this.clusters.Clear();
			this.fwMode = 0;
			this.fwTick = 0;
			this.fwDisplayClock = 0f;
		}

		// Token: 0x060030FC RID: 12540 RVA: 0x002815EC File Offset: 0x0027F7EC
		public void updateFW()
		{
			if (this.fwDisplayClock > 1800f)
			{
				return;
			}
			int num = this.totalNumFW;
			this.fwTick++;
			if (this.fwDisplayClock > 1590f)
			{
				this.fwMode = 2;
			}
			else if (this.fwTick > this.fwCycle * 30)
			{
				this.fwTick = 0;
				int num2 = this.fwNormalChance + this.fwBusyChance + this.fwCrazyChance;
				if (num2 > 0)
				{
					Random random = new Random();
					int num3 = random.Next(num2);
					if (num3 < this.fwNormalChance)
					{
						this.fwMode = 0;
					}
					this.fwMode = 1;
				}
			}
			switch (this.fwMode)
			{
			case 0:
				num = this.totalNumFW;
				break;
			case 1:
				num = this.totalNumFWBusy;
				break;
			case 2:
				num = this.totalNumFWCrazy;
				break;
			}
			if (this.clusters.Count >= num)
			{
				return;
			}
			double num4 = (double)this.m_screenWidth / this.m_worldScale;
			double num5 = (double)this.m_screenHeight / this.m_worldScale;
			RectangleF screenRect = new RectangleF((float)(this.m_screenCentreX - num4 / 2.0), (float)(this.m_screenCentreY - num5 / 2.0), (float)num4, (float)num5);
			List<VillageData> list = new List<VillageData>();
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				if (villageData.visible && this.isVisibleClose(screenRect, (float)villageData.x, (float)villageData.y))
				{
					list.Add(villageData);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			DateTime now = DateTime.Now;
			Random random2 = new Random();
			int num6 = num - this.clusters.Count;
			for (int j = 0; j < num6; j++)
			{
				WorldMap.ClusterBase clusterBase = new WorldMap.ClusterBase();
				WorldMap.ClusterBase clusterBase2 = clusterBase;
				int num7 = this.fwUnique;
				this.fwUnique = num7 + 1;
				clusterBase2.unique = num7;
				clusterBase.type = random2.Next(4);
				float num8 = 1f;
				switch (clusterBase.type)
				{
				case 0:
					clusterBase.fwS = this.fwJesterOrder;
					num8 = 1.5f;
					break;
				case 1:
					clusterBase.fwS = this.fwChickenOrder;
					num8 = 0.5f;
					break;
				case 2:
					clusterBase.fwS = this.fwSheepOrder;
					num8 = 0.66f;
					break;
				case 3:
					clusterBase.fwS = this.fwPigOrder;
					num8 = 1f;
					break;
				}
				VillageData villageData2 = list[random2.Next(list.Count)];
				clusterBase.startVillage = villageData2.id;
				float num9 = (float)random2.Next(15, 24);
				PointF point = new PointF(num9 * num8, 0f);
				point = GameEngine.Instance.GFX.rotatePoint(point, (float)random2.Next(360));
				clusterBase.targetX = (int)villageData2.x + (int)point.X;
				clusterBase.targetY = (int)villageData2.y + (int)point.Y;
				clusterBase.startTime = now;
				clusterBase.endTime = now.AddSeconds((double)num9 / 10.0);
				clusterBase.spriteID = clusterBase.type + 456;
				this.clusters.Add(clusterBase);
				list.Remove(villageData2);
				if (list.Count <= 0)
				{
					break;
				}
			}
		}

		// Token: 0x060030FD RID: 12541 RVA: 0x00281958 File Offset: 0x0027FB58
		public void drawFW(RectangleF screenRect)
		{
			float num = (float)this.m_worldScale / 28f / 0.6f;
			float num2 = 1f;
			this.fwDisplayClock += num2;
			if (num < 0.1f)
			{
				num = 0.1f;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			DateTime now = DateTime.Now;
			Random random = new Random();
			List<WorldMap.ClusterBase> list = new List<WorldMap.ClusterBase>();
			foreach (WorldMap.ClusterBase clusterBase in this.clusters)
			{
				if (clusterBase.parentVisible)
				{
					TimeSpan timeSpan = now - clusterBase.startTime;
					TimeSpan timeSpan2 = clusterBase.endTime - clusterBase.startTime;
					float num3 = (float)(timeSpan.TotalMilliseconds / timeSpan2.TotalMilliseconds);
					if (num3 > 1f)
					{
						num3 = 1f;
					}
					if (clusterBase.endTime <= now)
					{
						clusterBase.parentVisible = false;
						for (int i = 0; i < 3; i++)
						{
							int num4 = clusterBase.fwS[i];
							if (num4 > 0)
							{
								WorldMap.FWData fwdata = this.fwDataList[num4];
								int spriteID = fwdata.spriteID;
								int numToSpawn = fwdata.numToSpawn;
								for (int j = 0; j < numToSpawn; j++)
								{
									WorldMap.Burst burst = new WorldMap.Burst();
									WorldMap.Burst burst2 = burst;
									int num5 = this.fwUnique;
									this.fwUnique = num5 + 1;
									burst2.unique = num5;
									burst.definition = fwdata;
									burst.startX = (float)clusterBase.targetX;
									burst.startY = (float)clusterBase.targetY;
									float num6 = 1f;
									if (burst.definition.speedVariance != 0f)
									{
										num6 += (float)(random.NextDouble() * (double)burst.definition.speedVariance - (double)burst.definition.speedVariance / 2.0);
									}
									PointF point = new PointF(num6, 0f);
									point = ((!burst.definition.symmetrical) ? GameEngine.Instance.GFX.rotatePoint(point, (float)random.Next(360)) : GameEngine.Instance.GFX.rotatePoint(point, (float)j * 360f / (float)numToSpawn));
									if (burst.definition.randomStartRotation)
									{
										burst.curRotation = (float)random.Next(360);
									}
									burst.rotationValue = burst.definition.rotateSpeed;
									if (!burst.definition.rotateClockwise)
									{
										burst.rotationValue = 0f - burst.rotationValue;
									}
									burst.scale = burst.definition.startScale;
									if (burst.definition.startScale != burst.definition.scaleTarget)
									{
										burst.scaleDiff = burst.definition.scaleSpeed;
										if (burst.definition.startScale > burst.definition.scaleTarget)
										{
											burst.scaleDiff = 0f - burst.scaleDiff;
										}
									}
									burst.dX = point.X;
									burst.dY = point.Y;
									burst.speed = burst.definition.initialVelocity;
									if (burst.definition.initialVelocity != burst.definition.maxVelocity)
									{
										burst.acceleration = burst.definition.acceleration;
										if (burst.definition.initialVelocity > burst.definition.maxVelocity)
										{
											burst.acceleration = 0f - burst.acceleration;
										}
									}
									burst.startTime = now;
									burst.spriteID = spriteID;
									clusterBase.bursts.Add(burst);
								}
							}
						}
					}
					VillageData villageData = this.villageList[clusterBase.startVillage];
					float num7 = (float)villageData.x;
					float num8 = (float)villageData.y;
					float num9 = ((float)clusterBase.targetX - num7) * num3 + num7;
					float num10 = ((float)clusterBase.targetY - num8) * num3 + num8;
					if (this.isVisible(screenRect, num9, num10))
					{
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						this.villageSprite.SpriteNo = clusterBase.spriteID;
						this.villageSprite.PosX = (num9 - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						this.villageSprite.PosY = (num10 - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						this.villageSprite.Center = new PointF(44f, 44f);
						this.villageSprite.Scale = num;
						this.villageSprite.Update();
						this.doDraw(this.villageSprite);
					}
				}
				if (!clusterBase.parentVisible)
				{
					List<WorldMap.Burst> list2 = new List<WorldMap.Burst>();
					List<WorldMap.Burst> list3 = new List<WorldMap.Burst>();
					foreach (WorldMap.Burst burst3 in clusterBase.bursts)
					{
						TimeSpan timeSpan3 = now - burst3.startTime;
						switch (burst3.fadeState)
						{
						case 0:
						{
							int num11 = (int)timeSpan3.TotalMilliseconds;
							if (num11 > burst3.definition.fadeInTime)
							{
								burst3.fadeState = 1;
							}
							break;
						}
						case 1:
							burst3.alpha += burst3.definition.fadeRate;
							if (burst3.alpha >= 1f)
							{
								burst3.alpha = 1f;
								burst3.fadeState = 2;
							}
							break;
						case 2:
						{
							int num12 = (int)timeSpan3.TotalMilliseconds;
							if (num12 > burst3.definition.fadeOutTime)
							{
								burst3.fadeState = 3;
							}
							break;
						}
						case 3:
							burst3.alpha -= burst3.definition.fadeRate;
							if (burst3.alpha <= 0f)
							{
								burst3.alpha = 0f;
								burst3.fadeState = 4;
							}
							break;
						}
						if (burst3.fadeState == 4)
						{
							list2.Add(burst3);
							if (burst3.definition.childFirework > 0)
							{
								int childFirework = burst3.definition.childFirework;
								if (childFirework > 0)
								{
									WorldMap.FWData fwdata2 = this.fwDataList[childFirework];
									int spriteID2 = fwdata2.spriteID;
									int numToSpawn2 = fwdata2.numToSpawn;
									for (int k = 0; k < numToSpawn2; k++)
									{
										WorldMap.Burst burst4 = new WorldMap.Burst();
										WorldMap.Burst burst5 = burst4;
										int num5 = this.fwUnique;
										this.fwUnique = num5 + 1;
										burst5.unique = num5;
										burst4.definition = fwdata2;
										burst4.startX = burst3.startX;
										burst4.startY = burst3.startY;
										float num13 = 1f;
										if (burst4.definition.speedVariance != 0f)
										{
											num13 += (float)(random.NextDouble() * (double)burst4.definition.speedVariance - (double)burst4.definition.speedVariance / 2.0);
										}
										PointF point2 = new PointF(num13, 0f);
										point2 = ((!burst4.definition.symmetrical) ? GameEngine.Instance.GFX.rotatePoint(point2, (float)random.Next(360)) : GameEngine.Instance.GFX.rotatePoint(point2, (float)k * 360f / (float)numToSpawn2));
										if (burst4.definition.randomStartRotation)
										{
											burst4.curRotation = (float)random.Next(360);
										}
										burst4.rotationValue = burst4.definition.rotateSpeed;
										if (!burst4.definition.rotateClockwise)
										{
											burst4.rotationValue = 0f - burst4.rotationValue;
										}
										burst4.scale = burst4.definition.startScale;
										if (burst4.definition.startScale != burst4.definition.scaleTarget)
										{
											burst4.scaleDiff = burst4.definition.scaleSpeed;
											if (burst4.definition.startScale > burst4.definition.scaleTarget)
											{
												burst4.scaleDiff = 0f - burst4.scaleDiff;
											}
										}
										burst4.dX = point2.X;
										burst4.dY = point2.Y;
										burst4.speed = burst4.definition.initialVelocity;
										if (burst4.definition.initialVelocity != burst4.definition.maxVelocity)
										{
											burst4.acceleration = burst4.definition.acceleration;
											if (burst4.definition.initialVelocity > burst4.definition.maxVelocity)
											{
												burst4.acceleration = 0f - burst4.acceleration;
											}
										}
										burst4.startTime = now;
										burst4.spriteID = spriteID2;
										list3.Add(burst4);
									}
								}
							}
						}
						float startX = burst3.startX;
						float startY = burst3.startY;
						burst3.startX += burst3.dX * burst3.speed * num2;
						burst3.startY += burst3.dY * burst3.speed * num2;
						if (burst3.acceleration != 0f)
						{
							burst3.speed += burst3.acceleration * num2;
							if (burst3.acceleration > 0f)
							{
								if (burst3.speed >= burst3.definition.maxVelocity)
								{
									burst3.speed = burst3.definition.maxVelocity;
									burst3.acceleration = 0f;
								}
							}
							else if (burst3.speed <= burst3.definition.maxVelocity)
							{
								burst3.speed = burst3.definition.maxVelocity;
								burst3.acceleration = 0f;
							}
						}
						if (burst3.rotationValue != 0f)
						{
							burst3.curRotation += burst3.rotationValue * num2;
							if (burst3.curRotation < 0f)
							{
								burst3.curRotation += 360f;
							}
							else if (burst3.curRotation >= 360f)
							{
								burst3.curRotation -= 360f;
							}
						}
						if (burst3.scaleDiff > 0f)
						{
							burst3.scale += burst3.scaleDiff * num2;
							if (burst3.scale > burst3.definition.scaleTarget)
							{
								burst3.scale = burst3.definition.scaleTarget;
							}
						}
						else if (burst3.scaleDiff < 0f)
						{
							burst3.scale += burst3.scaleDiff * num2;
							if (burst3.scale < burst3.definition.scaleTarget)
							{
								burst3.scale = burst3.definition.scaleTarget;
							}
						}
						if (this.isVisible(screenRect, startX, startY))
						{
							this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
							this.villageSprite.SpriteNo = burst3.spriteID;
							this.villageSprite.PosX = (startX - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							this.villageSprite.PosY = (startY - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							this.villageSprite.Center = new PointF(44f, 44f);
							this.villageSprite.ColorToUse = Color.FromArgb((int)(burst3.alpha * 255f), global::ARGBColors.White);
							this.villageSprite.RotationAngle = burst3.curRotation;
							this.villageSprite.Scale = burst3.scale * num;
							this.villageSprite.Update();
							this.doDraw(this.villageSprite);
						}
					}
					if (list2.Count > 0)
					{
						foreach (WorldMap.Burst item in list2)
						{
							clusterBase.bursts.Remove(item);
						}
					}
					if (list3.Count > 0)
					{
						clusterBase.bursts.AddRange(list3);
					}
					if (clusterBase.bursts.Count == 0)
					{
						list.Add(clusterBase);
					}
				}
			}
			if (list.Count > 0)
			{
				foreach (WorldMap.ClusterBase item2 in list)
				{
					this.clusters.Remove(item2);
				}
			}
		}

		// Token: 0x060030FE RID: 12542 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void initUserVillages()
		{
		}

		// Token: 0x060030FF RID: 12543 RVA: 0x000238EA File Offset: 0x00021AEA
		public void retrieveUserVillages(bool force)
		{
			if (!this.retrievingUserVillages || force)
			{
				this.retrievingUserVillages = true;
				RemoteServices.Instance.set_GetUserVillages_UserCallBack(new RemoteServices.GetUserVillages_UserCallBack(this.getUserVillages));
				RemoteServices.Instance.GetUserVillages();
			}
		}

		// Token: 0x06003100 RID: 12544 RVA: 0x00023920 File Offset: 0x00021B20
		public bool isRetrievingUserVillages()
		{
			return this.retrievingUserVillages;
		}

		// Token: 0x06003101 RID: 12545 RVA: 0x00282648 File Offset: 0x00280848
		public void getUserVillages(GetUserVillages_ReturnType returnData)
		{
			this.retrievingUserVillages = false;
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.doGetUserVillages(returnData.userVillageList, returnData.userVillageNameList);
				this.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				this.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				this.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				this.setRanking(returnData.rank, returnData.rankSubLevel);
				return;
			}
			this.loadingErrored = true;
		}

		// Token: 0x06003102 RID: 12546 RVA: 0x002826D0 File Offset: 0x002808D0
		public void updateUserCapitals(int[] userCapitals)
		{
			foreach (int villageID in userCapitals)
			{
				if (!this.isUserVillage(villageID))
				{
					this.addUserVillage(villageID);
				}
			}
			if (this.m_userVillages != null)
			{
				bool flag = false;
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.capital)
					{
						bool flag2 = false;
						for (int j = 0; j < userCapitals.Length; j++)
						{
							if (userCapitals[j] == userVillageData.villageID)
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					this.retrieveUserVillages(false);
				}
			}
			this.sortUserVillages();
			this.updateUserRelatedVillages();
		}

		// Token: 0x06003103 RID: 12547 RVA: 0x0028279C File Offset: 0x0028099C
		public void addUserVillage(int villageID)
		{
			bool flag = false;
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.villageID == villageID)
					{
						this.villageList[userVillageData.villageID].userVillageID = num;
						flag = true;
						break;
					}
					num++;
				}
				if (!flag)
				{
					WorldMap.UserVillageData userVillageData2 = new WorldMap.UserVillageData();
					userVillageData2.villageID = villageID;
					this.m_userVillages.Add(userVillageData2);
					this.villageList[userVillageData2.villageID].userVillageID = this.m_userVillages.Count - 1;
				}
				this.sortUserVillages();
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.AddVillage(villageID);
				}
			}
			this.updateUserRelatedVillages();
		}

		// Token: 0x06003104 RID: 12548 RVA: 0x00023928 File Offset: 0x00021B28
		public void setWorldStartDate(DateTime startDate)
		{
			this.m_worldStartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 0);
		}

		// Token: 0x06003105 RID: 12549 RVA: 0x00282878 File Offset: 0x00280A78
		public int getGameDay()
		{
			return (int)(VillageMap.getCurrentServerTime() - this.m_worldStartDate).TotalDays;
		}

		// Token: 0x06003106 RID: 12550 RVA: 0x0002394E File Offset: 0x00021B4E
		public void setGoldData(double goldLevel, double goldRate)
		{
			this.m_userGoldLevel = goldLevel;
			this.m_userGoldIncomeRate = goldRate;
			this.m_lastGoldUpdate = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06003107 RID: 12551 RVA: 0x00023969 File Offset: 0x00021B69
		public void setHonourData(double honourLevel, double honourRate)
		{
			this.m_userHonourLevel = honourLevel;
			this.m_userHonourIncomeRate = honourRate;
			this.m_lastHonourUpdate = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x00023984 File Offset: 0x00021B84
		public void setFaithPointsData(double faithPointsLevel, double faithPointsRate)
		{
			this.m_userFaithPointsLevel = faithPointsLevel;
			this.m_userFaithPointsRate = faithPointsRate;
			this.m_lastFaithPointsUpdate = DXTimer.GetCurrentMilliseconds();
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x0002399F File Offset: 0x00021B9F
		public void setPoints(int points)
		{
			this.m_userPoints = points;
		}

		// Token: 0x0600310A RID: 12554 RVA: 0x000239A8 File Offset: 0x00021BA8
		public void setNumMadeCaptains(int numCaptains)
		{
			this.m_numMadeCaptains = numCaptains;
		}

		// Token: 0x0600310B RID: 12555 RVA: 0x000239B1 File Offset: 0x00021BB1
		public void setRanking(int rank, int rankSubLevel)
		{
			this.m_userRank = rank;
			this.m_userRankSubLevel = rankSubLevel;
			InterfaceMgr.Instance.setRank(rank);
		}

		// Token: 0x0600310C RID: 12556 RVA: 0x000239CC File Offset: 0x00021BCC
		public void reSetRanking()
		{
			InterfaceMgr.Instance.setRank(this.m_userRank);
		}

		// Token: 0x0600310D RID: 12557 RVA: 0x000239DE File Offset: 0x00021BDE
		public bool isUserVillage(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].userVillageID != -1;
		}

		// Token: 0x0600310E RID: 12558 RVA: 0x00023A04 File Offset: 0x00021C04
		public bool isUserRelatedVillage(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].userRelatedVillage;
		}

		// Token: 0x0600310F RID: 12559 RVA: 0x002828A0 File Offset: 0x00280AA0
		public void updateLocalVillagesFromFactions()
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (this.villageList[userVillageData.villageID].factionID != RemoteServices.Instance.UserFactionID)
					{
						this.villageList[userVillageData.villageID].userVillageID = -1;
					}
				}
				this.updateUserRelatedVillages();
			}
		}

		// Token: 0x06003110 RID: 12560 RVA: 0x0028292C File Offset: 0x00280B2C
		public void updateYourVillageFactions(int yourNewFaction)
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					this.villageList[userVillageData.villageID].factionID = yourNewFaction;
				}
			}
		}

		// Token: 0x06003111 RID: 12561 RVA: 0x00282994 File Offset: 0x00280B94
		public List<int> getListOfUserVillages()
		{
			List<int> list = new List<int>();
			if (this.m_userVillages == null)
			{
				return list;
			}
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				if (!userVillageData.capital)
				{
					list.Add(userVillageData.villageID);
				}
			}
			return list;
		}

		// Token: 0x06003112 RID: 12562 RVA: 0x00282A08 File Offset: 0x00280C08
		public List<int> getListOfUserParishes()
		{
			List<int> list = new List<int>();
			if (this.m_userVillages == null)
			{
				return list;
			}
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				if (!userVillageData.capital)
				{
					int regionID = (int)this.villageList[userVillageData.villageID].regionID;
					if (!list.Contains(regionID))
					{
						list.Add(regionID);
					}
				}
			}
			return list;
		}

		// Token: 0x06003113 RID: 12563 RVA: 0x00282A90 File Offset: 0x00280C90
		public List<int> getListOfUserCounties()
		{
			List<int> list = new List<int>();
			List<int> listOfUserVillages = this.getListOfUserVillages();
			foreach (int villageID in listOfUserVillages)
			{
				int countyFromVillageID = this.getCountyFromVillageID(villageID);
				if (!list.Contains(countyFromVillageID))
				{
					list.Add(countyFromVillageID);
				}
			}
			return list;
		}

		// Token: 0x06003114 RID: 12564 RVA: 0x00282B00 File Offset: 0x00280D00
		public List<int> getListOfUserProvinces()
		{
			List<int> list = new List<int>();
			List<int> listOfUserVillages = this.getListOfUserVillages();
			foreach (int villageID in listOfUserVillages)
			{
				int provinceFromVillageID = this.getProvinceFromVillageID(villageID);
				if (!list.Contains(provinceFromVillageID))
				{
					list.Add(provinceFromVillageID);
				}
			}
			return list;
		}

		// Token: 0x06003115 RID: 12565 RVA: 0x00282B70 File Offset: 0x00280D70
		public List<int> getListOfUserCountries()
		{
			List<int> list = new List<int>();
			List<int> listOfUserVillages = this.getListOfUserVillages();
			foreach (int villageID in listOfUserVillages)
			{
				int countryFromVillageID = this.getCountryFromVillageID(villageID);
				if (!list.Contains(countryFromVillageID))
				{
					list.Add(countryFromVillageID);
				}
			}
			return list;
		}

		// Token: 0x06003116 RID: 12566 RVA: 0x00023A24 File Offset: 0x00021C24
		public void addGold(double gold)
		{
			this.m_userGoldLevel += gold;
		}

		// Token: 0x06003117 RID: 12567 RVA: 0x00282BE0 File Offset: 0x00280DE0
		public double getCurrentGold()
		{
			double num = (DXTimer.GetCurrentMilliseconds() - this.m_lastGoldUpdate) / 1000.0;
			double num2 = num;
			double num3 = this.m_userGoldLevel + this.m_userGoldIncomeRate * num2;
			if (num3 < 0.0)
			{
				num3 = 0.0;
			}
			return num3;
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x00023A34 File Offset: 0x00021C34
		public double getCurrentGoldRate()
		{
			return this.m_userGoldIncomeRate;
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x00023A3C File Offset: 0x00021C3C
		public void addHonour(double honour)
		{
			this.m_userHonourLevel += honour;
		}

		// Token: 0x0600311A RID: 12570 RVA: 0x00282C30 File Offset: 0x00280E30
		public double getCurrentHonour()
		{
			double num = (DXTimer.GetCurrentMilliseconds() - this.m_lastHonourUpdate) / 1000.0;
			double num2 = num;
			return this.m_userHonourLevel + this.m_userHonourIncomeRate * num2;
		}

		// Token: 0x0600311B RID: 12571 RVA: 0x00023A4C File Offset: 0x00021C4C
		public double getCurrentHonourRate()
		{
			return this.m_userHonourIncomeRate;
		}

		// Token: 0x0600311C RID: 12572 RVA: 0x00282C68 File Offset: 0x00280E68
		public double getCurrentFaithPoints()
		{
			double num = (DXTimer.GetCurrentMilliseconds() - this.m_lastFaithPointsUpdate) / 1000.0;
			double num2 = num;
			double num3 = this.m_userFaithPointsLevel + this.m_userFaithPointsRate * num2;
			if (GameEngine.Instance.LocalWorldData.EraWorld)
			{
				int num4 = this.getRank();
				if (num4 < 0)
				{
					num4 = 0;
				}
				else if (num4 >= VillageBuildingsData.faithPointCap_EraWorlds.Length)
				{
					num4 = VillageBuildingsData.faithPointCap_EraWorlds.Length - 1;
				}
				int num5 = VillageBuildingsData.faithPointCap_EraWorlds[num4];
				if (num3 > (double)num5)
				{
					num3 = (double)num5;
				}
			}
			return num3;
		}

		// Token: 0x0600311D RID: 12573 RVA: 0x00023A54 File Offset: 0x00021C54
		public void addFaithPoints(double amount)
		{
			this.m_userFaithPointsLevel += amount;
		}

		// Token: 0x0600311E RID: 12574 RVA: 0x00023A64 File Offset: 0x00021C64
		public double getCurrentFaithPointsRate()
		{
			return this.m_userFaithPointsRate;
		}

		// Token: 0x0600311F RID: 12575 RVA: 0x00023A6C File Offset: 0x00021C6C
		public int getCurrentPoints()
		{
			return this.m_userPoints;
		}

		// Token: 0x06003120 RID: 12576 RVA: 0x00023A74 File Offset: 0x00021C74
		public int getNumMadeCaptains()
		{
			if (this.m_numMadeCaptains <= 0)
			{
				return 1;
			}
			return this.m_numMadeCaptains;
		}

		// Token: 0x06003121 RID: 12577 RVA: 0x00023A87 File Offset: 0x00021C87
		public int getRank()
		{
			return this.m_userRank;
		}

		// Token: 0x06003122 RID: 12578 RVA: 0x00023A8F File Offset: 0x00021C8F
		public int getRankSubLevel()
		{
			return this.m_userRankSubLevel;
		}

		// Token: 0x06003123 RID: 12579 RVA: 0x00282CE8 File Offset: 0x00280EE8
		public bool canUserOwnMoreVillages()
		{
			int num = this.numVillagesAllowed();
			int num2 = this.numVillagesOwned();
			return num2 < num;
		}

		// Token: 0x06003124 RID: 12580 RVA: 0x00282D0C File Offset: 0x00280F0C
		public bool canUserOwnMoreVassals()
		{
			int userRank = this.m_userRank;
			int maxVassals = GameEngine.Instance.LocalWorldData.getMaxVassals(userRank, this.m_userRankSubLevel);
			int num = this.countVassals();
			return num < maxVassals;
		}

		// Token: 0x06003125 RID: 12581 RVA: 0x00282D48 File Offset: 0x00280F48
		public bool isVillageAVassal(int villageID)
		{
			if (this.m_userVillages == null)
			{
				return false;
			}
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				foreach (int num in userVillageData.vassals)
				{
					if (num == villageID)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x00282DE8 File Offset: 0x00280FE8
		public int countVassals()
		{
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.vassals != null)
					{
						num += userVillageData.vassals.Count;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x06003127 RID: 12583 RVA: 0x00282E58 File Offset: 0x00281058
		public int numVillagesAllowed()
		{
			int num = ResearchData.leadershipVillages[(int)this.UserResearchData.Research_Leadership];
			if (GameEngine.Instance.LocalWorldData.Alternate_Ruleset == 1)
			{
				num = ResearchData.leadershipVillages2[(int)this.UserResearchData.Research_Leadership];
			}
			if (num >= 25 && GameEngine.Instance.World.FourthAgeWorld)
			{
				num = 40;
			}
			else if (num >= 25 && GameEngine.Instance.World.ThirdAgeWorld)
			{
				num = 30;
			}
			return num;
		}

		// Token: 0x06003128 RID: 12584 RVA: 0x00282ED0 File Offset: 0x002810D0
		public int numVillagesOwned()
		{
			if (this.m_userVillages == null)
			{
				return 1;
			}
			int num = 0;
			int count = this.m_userVillages.Count;
			for (int i = 0; i < count; i++)
			{
				if (!this.villageList[this.m_userVillages[i].villageID].Capital)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06003129 RID: 12585 RVA: 0x00282F28 File Offset: 0x00281128
		public int numVassalsAllowed()
		{
			int userRank = this.m_userRank;
			if (userRank < 0)
			{
				return 0;
			}
			return GameEngine.Instance.LocalWorldData.getMaxVassals(userRank, this.m_userRankSubLevel);
		}

		// Token: 0x0600312A RID: 12586 RVA: 0x00023A97 File Offset: 0x00021C97
		public int numVassalsAllowed(int rank)
		{
			if (rank < 0)
			{
				return 0;
			}
			return GameEngine.Instance.LocalWorldData.getMaxVassals(rank, this.m_userRankSubLevel);
		}

		// Token: 0x0600312B RID: 12587 RVA: 0x00009262 File Offset: 0x00007462
		public int numVassalsOwned()
		{
			return 0;
		}

		// Token: 0x0600312C RID: 12588 RVA: 0x00282F58 File Offset: 0x00281158
		public double calcVillageDistance(int fromVillageID, int villageID)
		{
			if (this.m_userVillages == null)
			{
				return 0.0;
			}
			if (villageID < 0 || villageID >= this.villageList.Length)
			{
				return 0.0;
			}
			if (fromVillageID < 0 || fromVillageID >= this.villageList.Length)
			{
				return 0.0;
			}
			int regionID = (int)this.villageList[villageID].regionID;
			int capitalVillage = this.regionList[regionID].capitalVillage;
			int regionID2 = (int)this.villageList[fromVillageID].regionID;
			if (regionID2 == regionID || regionID2 < 0 || regionID < 0)
			{
				return 0.0;
			}
			int capitalVillage2 = this.regionList[regionID2].capitalVillage;
			int num = (int)(this.villageList[capitalVillage].x - this.villageList[capitalVillage2].x);
			int num2 = (int)(this.villageList[capitalVillage].y - this.villageList[capitalVillage2].y);
			int num3 = num * num + num2 * num2;
			num3 = (int)Math.Sqrt((double)num3);
			if (num3 > GameEngine.Instance.LocalWorldData.maxVillageCostDistance)
			{
				num3 = GameEngine.Instance.LocalWorldData.maxVillageCostDistance;
			}
			return (double)num3 / (double)GameEngine.Instance.LocalWorldData.maxVillageCostDistance;
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x00283084 File Offset: 0x00281284
		public void updateUserRelatedVillages()
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userRelatedVillages)
				{
					if (userVillageData.villageID >= 0 && userVillageData.villageID < this.villageList.Length)
					{
						this.villageList[userVillageData.villageID].userRelatedVillage = false;
					}
				}
				this.m_userRelatedVillages.Clear();
				List<int> list = new List<int>();
				try
				{
					foreach (WorldMap.UserVillageData userVillageData2 in this.m_userVillages)
					{
						if (!this.villageList[userVillageData2.villageID].Capital)
						{
							int regionID = (int)this.villageList[userVillageData2.villageID].regionID;
							int capitalVillage = this.regionList[regionID].capitalVillage;
							if (!list.Contains(capitalVillage) && !this.isUserVillage(capitalVillage))
							{
								list.Add(capitalVillage);
								WorldMap.UserVillageData userVillageData3 = new WorldMap.UserVillageData();
								userVillageData3.villageID = capitalVillage;
								userVillageData3.capital = true;
								userVillageData3.parishCapital = true;
								this.m_userRelatedVillages.Add(userVillageData3);
								this.villageList[capitalVillage].userRelatedVillage = true;
							}
						}
					}
					foreach (WorldMap.UserVillageData userVillageData4 in this.m_userVillages)
					{
						if (!this.villageList[userVillageData4.villageID].Capital)
						{
							int countyID = (int)this.villageList[userVillageData4.villageID].countyID;
							int capitalVillage2 = this.countyList[countyID].capitalVillage;
							if (!list.Contains(capitalVillage2) && !this.isUserVillage(capitalVillage2))
							{
								list.Add(capitalVillage2);
								WorldMap.UserVillageData userVillageData5 = new WorldMap.UserVillageData();
								userVillageData5.villageID = capitalVillage2;
								userVillageData5.capital = true;
								userVillageData5.countyCapital = true;
								this.m_userRelatedVillages.Add(userVillageData5);
								this.villageList[capitalVillage2].userRelatedVillage = true;
							}
						}
					}
					foreach (WorldMap.UserVillageData userVillageData6 in this.m_userVillages)
					{
						if (!this.villageList[userVillageData6.villageID].Capital)
						{
							int countyID2 = (int)this.villageList[userVillageData6.villageID].countyID;
							int parentID = this.countyList[countyID2].parentID;
							int capitalVillage3 = this.provincesList[parentID].capitalVillage;
							if (!list.Contains(capitalVillage3) && !this.isUserVillage(capitalVillage3))
							{
								list.Add(capitalVillage3);
								WorldMap.UserVillageData userVillageData7 = new WorldMap.UserVillageData();
								userVillageData7.villageID = capitalVillage3;
								userVillageData7.capital = true;
								userVillageData7.provinceCapital = true;
								this.m_userRelatedVillages.Add(userVillageData7);
								this.villageList[capitalVillage3].userRelatedVillage = true;
							}
						}
					}
					foreach (WorldMap.UserVillageData userVillageData8 in this.m_userVillages)
					{
						if (!this.villageList[userVillageData8.villageID].Capital)
						{
							int countyID3 = (int)this.villageList[userVillageData8.villageID].countyID;
							int parentID2 = this.countyList[countyID3].parentID;
							int parentID3 = this.provincesList[parentID2].parentID;
							int capitalVillage4 = this.countryList[parentID3].capitalVillage;
							if (!list.Contains(capitalVillage4) && !this.isUserVillage(capitalVillage4))
							{
								list.Add(capitalVillage4);
								WorldMap.UserVillageData userVillageData9 = new WorldMap.UserVillageData();
								userVillageData9.villageID = capitalVillage4;
								userVillageData9.capital = true;
								userVillageData9.countryCapital = true;
								this.m_userRelatedVillages.Add(userVillageData9);
								this.villageList[capitalVillage4].userRelatedVillage = true;
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x002834FC File Offset: 0x002816FC
		public int getNextUserVillage(int curVillage, int searchDir)
		{
			if (this.m_userVillages == null || this.m_userVillages.Count == 0)
			{
				return -1;
			}
			int num = -1;
			bool flag = false;
			List<WorldMap.UserVillageData> list = new List<WorldMap.UserVillageData>();
			list.AddRange(this.m_userVillages);
			list.AddRange(this.m_userRelatedVillages);
			if (curVillage >= 0 && curVillage < this.villageList.Length)
			{
				num = 0;
				foreach (WorldMap.UserVillageData userVillageData in list)
				{
					if (userVillageData.villageID == curVillage)
					{
						break;
					}
					num++;
				}
				if (this.villageList[curVillage].Capital)
				{
					flag = true;
				}
			}
			int num2 = 0;
			int count = list.Count;
			int i = 0;
			while (i < count)
			{
				num += searchDir;
				if (num < 0)
				{
					num = list.Count - 1;
				}
				if (num >= count)
				{
					num = 0;
				}
				if (flag)
				{
					if (this.villageList[list[num].villageID].Capital)
					{
						break;
					}
				}
				else if (!this.villageList[list[num].villageID].Capital)
				{
					break;
				}
				num2++;
				if (num2 > 1000)
				{
					return -1;
				}
			}
			return list[num].villageID;
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x00283630 File Offset: 0x00281830
		public int getPlayerChildVillageFromCapital(int capitalID)
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					VillageData villageData = this.villageList[userVillageData.villageID];
					int num = this.getRegionCapitalVillage((int)villageData.regionID);
					if (num == capitalID)
					{
						return userVillageData.villageID;
					}
					num = this.getCountyCapitalVillage((int)villageData.countyID);
					if (num == capitalID)
					{
						return userVillageData.villageID;
					}
					num = this.getProvinceCapital(this.getProvinceFromVillageID(userVillageData.villageID));
					if (num == capitalID)
					{
						return userVillageData.villageID;
					}
					num = this.getCountryCapital(this.getCountryFromVillageID(userVillageData.villageID));
					if (num == capitalID)
					{
						return userVillageData.villageID;
					}
				}
				return capitalID;
			}
			return capitalID;
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x00023AB5 File Offset: 0x00021CB5
		public List<WorldMap.UserVillageData> getUserVillageList()
		{
			return this.m_userVillages;
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x0028371C File Offset: 0x0028191C
		public List<int> getUserVillageIDList()
		{
			List<int> list = new List<int>();
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (!this.villageList[userVillageData.villageID].Capital)
					{
						list.Add(userVillageData.villageID);
					}
				}
				return list;
			}
			return list;
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x0028379C File Offset: 0x0028199C
		public List<WorldMap.VillageNameItem> getUserVillageNamesList()
		{
			List<WorldMap.VillageNameItem> list = new List<WorldMap.VillageNameItem>();
			if (this.m_userVillages == null)
			{
				return list;
			}
			int num = 0;
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				if (this.villageList[userVillageData.villageID].Capital)
				{
					int num2 = 1;
					if (this.villageList[userVillageData.villageID].regionCapital)
					{
						num2 = 1;
					}
					else if (this.villageList[userVillageData.villageID].countyCapital)
					{
						num2 = 2;
					}
					else if (this.villageList[userVillageData.villageID].provinceCapital)
					{
						num2 = 3;
					}
					else if (this.villageList[userVillageData.villageID].countryCapital)
					{
						num2 = 4;
					}
					if (num != num2)
					{
						list.Add(new WorldMap.VillageNameItem
						{
							villageName = "-----------------",
							villageID = -1
						});
						num = num2;
					}
				}
				list.Add(new WorldMap.VillageNameItem
				{
					villageName = this.getVillageName(userVillageData.villageID),
					villageID = userVillageData.villageID,
					capital = userVillageData.capital
				});
			}
			return list;
		}

		// Token: 0x06003133 RID: 12595 RVA: 0x002838E4 File Offset: 0x00281AE4
		public List<WorldMap.VillageNameItem> getUserVillageNamesListAndCapitals()
		{
			List<WorldMap.VillageNameItem> list = new List<WorldMap.VillageNameItem>();
			if (this.m_userVillages == null)
			{
				return list;
			}
			for (int i = 0; i < 5; i++)
			{
				if (i > 0)
				{
					WorldMap.VillageNameItem villageNameItem = new WorldMap.VillageNameItem();
					switch (i)
					{
					case 1:
						villageNameItem.villageName = SK.Text("GENERIC_Parishes", "Parishes");
						villageNameItem.villageID = -1;
						list.Add(villageNameItem);
						break;
					case 2:
						villageNameItem.villageName = SK.Text("GENERIC_Counties", "Counties");
						villageNameItem.villageID = -1;
						list.Add(villageNameItem);
						break;
					case 3:
						villageNameItem.villageName = SK.Text("GENERIC_Provinces", "Provinces");
						villageNameItem.villageID = -1;
						list.Add(villageNameItem);
						break;
					case 4:
						villageNameItem.villageName = SK.Text("GENERIC_Countries", "Countries");
						villageNameItem.villageID = -1;
						list.Add(villageNameItem);
						break;
					}
				}
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					bool flag = false;
					switch (i)
					{
					case 0:
						if (!userVillageData.capital)
						{
							flag = true;
						}
						break;
					case 1:
						if (userVillageData.parishCapital)
						{
							flag = true;
						}
						break;
					case 2:
						if (userVillageData.countyCapital)
						{
							flag = true;
						}
						break;
					case 3:
						if (userVillageData.provinceCapital)
						{
							flag = true;
						}
						break;
					case 4:
						if (userVillageData.countryCapital)
						{
							flag = true;
						}
						break;
					}
					if (flag)
					{
						WorldMap.VillageNameItem villageNameItem2 = new WorldMap.VillageNameItem();
						villageNameItem2.villageName = this.getVillageName(userVillageData.villageID);
						switch (i)
						{
						case 2:
							villageNameItem2.villageName = villageNameItem2.villageName + " / " + this.getCountyName(this.getCountyFromVillageID(userVillageData.villageID));
							break;
						case 3:
							villageNameItem2.villageName = villageNameItem2.villageName + " / " + this.getProvinceName(this.getProvinceFromVillageID(userVillageData.villageID));
							break;
						case 4:
							villageNameItem2.villageName = villageNameItem2.villageName + " / " + this.getCountryName(this.getCountryFromVillageID(userVillageData.villageID));
							break;
						}
						villageNameItem2.villageID = userVillageData.villageID;
						villageNameItem2.capital = userVillageData.capital;
						list.Add(villageNameItem2);
					}
				}
				foreach (WorldMap.UserVillageData userVillageData2 in this.m_userRelatedVillages)
				{
					bool flag2 = false;
					switch (i)
					{
					case 0:
						if (!userVillageData2.capital)
						{
							flag2 = true;
						}
						break;
					case 1:
						if (userVillageData2.parishCapital)
						{
							flag2 = true;
						}
						break;
					case 2:
						if (userVillageData2.countyCapital)
						{
							flag2 = true;
						}
						break;
					case 3:
						if (userVillageData2.provinceCapital)
						{
							flag2 = true;
						}
						break;
					case 4:
						if (userVillageData2.countryCapital)
						{
							flag2 = true;
						}
						break;
					}
					if (flag2)
					{
						WorldMap.VillageNameItem villageNameItem3 = new WorldMap.VillageNameItem();
						villageNameItem3.villageName = this.getVillageName(userVillageData2.villageID);
						switch (i)
						{
						case 2:
							villageNameItem3.villageName = villageNameItem3.villageName + " / " + this.getCountyName(this.getCountyFromVillageID(userVillageData2.villageID));
							break;
						case 3:
							villageNameItem3.villageName = villageNameItem3.villageName + " / " + this.getProvinceName(this.getProvinceFromVillageID(userVillageData2.villageID));
							break;
						case 4:
							villageNameItem3.villageName = villageNameItem3.villageName + " / " + this.getCountryName(this.getCountryFromVillageID(userVillageData2.villageID));
							break;
						}
						villageNameItem3.villageID = userVillageData2.villageID;
						villageNameItem3.capital = userVillageData2.capital;
						list.Add(villageNameItem3);
					}
				}
			}
			return list;
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x00283D00 File Offset: 0x00281F00
		public void sortUserVillages()
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (this.villageList[userVillageData.villageID].Capital)
					{
						userVillageData.capital = true;
						if (this.villageList[userVillageData.villageID].regionCapital)
						{
							userVillageData.parishCapital = true;
						}
						else if (this.villageList[userVillageData.villageID].countyCapital)
						{
							userVillageData.countyCapital = true;
						}
						else if (this.villageList[userVillageData.villageID].provinceCapital)
						{
							userVillageData.provinceCapital = true;
						}
						else if (this.villageList[userVillageData.villageID].countryCapital)
						{
							userVillageData.countryCapital = true;
						}
					}
				}
				this.m_userVillages.Sort(this.villageNameComparer);
				int num = 0;
				foreach (WorldMap.UserVillageData userVillageData2 in this.m_userVillages)
				{
					this.villageList[userVillageData2.villageID].userVillageID = num;
					num++;
				}
			}
		}

		// Token: 0x06003135 RID: 12597 RVA: 0x00283E54 File Offset: 0x00282054
		public int numUserParishes()
		{
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.parishCapital)
					{
						num++;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x06003136 RID: 12598 RVA: 0x00283EBC File Offset: 0x002820BC
		public int numUserCounties()
		{
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.countyCapital)
					{
						num++;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x06003137 RID: 12599 RVA: 0x00283F24 File Offset: 0x00282124
		public int numUserProvinces()
		{
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.provinceCapital)
					{
						num++;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x06003138 RID: 12600 RVA: 0x00283F8C File Offset: 0x0028218C
		public int numUserCountries()
		{
			int num = 0;
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					if (userVillageData.countryCapital)
					{
						num++;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x06003139 RID: 12601 RVA: 0x00283FF4 File Offset: 0x002821F4
		public ResearchData GetResearchDataForCurrentVillage()
		{
			int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
			if (this.isCapital(selectedMenuVillage) && GameEngine.Instance.Village != null)
			{
				return GameEngine.Instance.Village.m_parishCapitalResearchData;
			}
			return this.UserResearchData;
		}

		// Token: 0x0600313A RID: 12602 RVA: 0x00284038 File Offset: 0x00282238
		public ResearchData GetResearchDataForVillage(int villageID)
		{
			if (this.isCapital(villageID))
			{
				VillageMap village = GameEngine.Instance.getVillage(villageID);
				if (village != null)
				{
					return village.m_parishCapitalResearchData;
				}
			}
			return this.UserResearchData;
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x00023ABD File Offset: 0x00021CBD
		public void setResearchData(ResearchData data)
		{
			if (data != null)
			{
				this.userResearchData = data;
			}
			this.requestSent = false;
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x00023AD0 File Offset: 0x00021CD0
		public void addResearchPoints(int amount)
		{
			if (this.userResearchData != null)
			{
				this.userResearchData.research_points += amount;
			}
		}

		// Token: 0x0600313D RID: 12605 RVA: 0x0028406C File Offset: 0x0028226C
		public bool isResearchLagging()
		{
			if (this.userResearchData.researchingType >= 0 && VillageMap.getCurrentServerTime() > this.userResearchData.research_completionTime.AddSeconds(15.0))
			{
				DateTime now = DateTime.Now;
				if (this.m_lastResearchCompleteTimeMatch == this.userResearchData.research_completionTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600313E RID: 12606 RVA: 0x002840D0 File Offset: 0x002822D0
		public void updateResearch(bool force)
		{
			if (force)
			{
				this.requestSent = true;
				RemoteServices.Instance.set_GetResearchData_UserCallBack(new RemoteServices.GetResearchData_UserCallBack(this.getResearchDataCallback));
				RemoteServices.Instance.GetResearchData();
				return;
			}
			if (this.userResearchData == null || this.userResearchData.researchingType < 0 || this.requestSent || !(VillageMap.getCurrentServerTime() > this.userResearchData.research_completionTime.AddSeconds(5.0)))
			{
				return;
			}
			DateTime now = DateTime.Now;
			if (this.m_lastResearchCompleteTimeMatch == this.userResearchData.research_completionTime)
			{
				int num = 40 * this.m_researchLagCount;
				if (num < 40)
				{
					num = 40;
				}
				else if (num > 300)
				{
					num = 300;
				}
				if ((now - this.m_lastResearchCompleteRequestTime).TotalSeconds < (double)num)
				{
					return;
				}
				this.m_researchLagCount++;
			}
			else
			{
				this.m_researchLagCount = 0;
			}
			if (this.userResearchData.researchingType == 59)
			{
				int tutorialStage = this.getTutorialStage();
				if (tutorialStage == 5)
				{
					GameEngine.Instance.World.TutorialQuestCompleted(4);
					Thread.Sleep(200);
				}
			}
			this.m_lastResearchCompleteRequestTime = now;
			this.m_lastResearchCompleteTimeMatch = this.userResearchData.research_completionTime;
			this.requestSent = true;
			RemoteServices.Instance.set_GetResearchData_UserCallBack(new RemoteServices.GetResearchData_UserCallBack(this.getResearchDataCallback));
			RemoteServices.Instance.GetResearchData();
		}

		// Token: 0x0600313F RID: 12607 RVA: 0x00284230 File Offset: 0x00282430
		public void getResearchDataCallback(GetResearchData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.setResearchData(returnData.researchData);
				VillageMap.setServerTime(returnData.currentTime);
				InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				if (returnData.researchData != null && (this.m_lastResearchCompleteTimeMatch != returnData.researchData.research_completionTime || returnData.researchData.researchingType < 0) && GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_VILLAGE)
				{
					GameEngine.Instance.downloadCurrentVillage();
				}
			}
		}

		// Token: 0x06003140 RID: 12608 RVA: 0x00023AED File Offset: 0x00021CED
		public void doResearch(int researchType)
		{
			this.doResearch(researchType, null);
		}

		// Token: 0x06003141 RID: 12609 RVA: 0x002842C8 File Offset: 0x002824C8
		public void doResearch(int researchType, WorldMap.ResearchChangedDelegate uiDelegate)
		{
			this.uiResearchDelegate = uiDelegate;
			if (!this.inDoResearch || (DateTime.Now - this.lastDoResearchClick).TotalSeconds >= 120.0)
			{
				this.inDoResearch = true;
				this.lastDoResearchClick = DateTime.Now;
				RemoteServices.Instance.set_DoResearch_UserCallBack(new RemoteServices.DoResearch_UserCallBack(this.doResearchCallback));
				RemoteServices.Instance.DoResearch(researchType);
			}
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x00023AF7 File Offset: 0x00021CF7
		public void CancelQueuedResearch(int researchType, int queuePos)
		{
			this.CancelQueuedResearch(researchType, queuePos, null);
		}

		// Token: 0x06003143 RID: 12611 RVA: 0x0028433C File Offset: 0x0028253C
		public void CancelQueuedResearch(int researchType, int queuePos, WorldMap.ResearchChangedDelegate uiDelegate)
		{
			this.uiResearchDelegate = uiDelegate;
			if (!this.inDoResearch || (DateTime.Now - this.lastDoResearchClick).TotalSeconds >= 120.0)
			{
				this.inDoResearch = true;
				this.lastDoResearchClick = DateTime.Now;
				RemoteServices.Instance.set_DoResearch_UserCallBack(new RemoteServices.DoResearch_UserCallBack(this.doResearchCallback));
				RemoteServices.Instance.CancelQueuedResearch(researchType, queuePos);
			}
		}

		// Token: 0x06003144 RID: 12612 RVA: 0x002843B0 File Offset: 0x002825B0
		public void doResearchCallback(DoResearch_ReturnType returnData)
		{
			this.inDoResearch = false;
			if (returnData.Success)
			{
				this.setResearchData(returnData.researchData);
				VillageMap.setServerTime(returnData.currentTime);
				InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
			}
			else
			{
				ErrorCodes.ErrorCode errorCode = returnData.m_errorCode;
				if (errorCode - ErrorCodes.ErrorCode.RESEARCH_CANNOT_DO_RESEARCH_ALREADY_RESEARCHING <= 3)
				{
					InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
				}
				ControlForm controlForm = DX.ControlForm;
				if (controlForm != null)
				{
					controlForm.Log(ErrorCodes.getErrorString(returnData.m_errorCode, returnData.m_errorID), ControlForm.Tab.Research, true);
				}
			}
			if (this.uiResearchDelegate != null)
			{
				this.uiResearchDelegate();
			}
		}

		// Token: 0x06003145 RID: 12613 RVA: 0x00023B02 File Offset: 0x00021D02
		public void setOnResearchPointPurchaseDelegate(CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate del)
		{
			this.onResearchPointPurchaseDelegate = del;
		}

		// Token: 0x06003146 RID: 12614 RVA: 0x0028444C File Offset: 0x0028264C
		public void buyResearchPoint()
		{
			if (!this.inBuyPoint || (DateTime.Now - this.lastBuyPointClick).TotalSeconds >= 120.0)
			{
				this.inBuyPoint = true;
				this.lastBuyPointClick = DateTime.Now;
				RemoteServices.Instance.set_BuyResearchPoint_UserCallBack(new RemoteServices.BuyResearchPoint_UserCallBack(this.buyResearchPointCallback));
				RemoteServices.Instance.BuyResearchPoint();
			}
		}

		// Token: 0x06003147 RID: 12615 RVA: 0x002844B8 File Offset: 0x002826B8
		public void buyResearchPointCallback(BuyResearchPoint_ReturnType returnData)
		{
			this.inBuyPoint = false;
			if (returnData.Success || returnData.m_errorCode == ErrorCodes.ErrorCode.RESEARCH_NOT_ENOUGH_HONOUR)
			{
				this.setResearchData(returnData.researchData);
				this.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				InterfaceMgr.Instance.researchDataChanged(returnData.researchData);
				if (this.onResearchPointPurchaseDelegate != null)
				{
					this.onResearchPointPurchaseDelegate();
				}
			}
		}

		// Token: 0x06003148 RID: 12616 RVA: 0x00284520 File Offset: 0x00282720
		public bool doesUserHaveVillageInParishByCapital(int capitalID)
		{
			int parishFromVillageID = this.getParishFromVillageID(capitalID);
			return this.doesUserHaveVillageInParish(parishFromVillageID);
		}

		// Token: 0x06003149 RID: 12617 RVA: 0x0028453C File Offset: 0x0028273C
		public bool doesUserHaveVillageInParish(int parishID)
		{
			if (this.m_userVillages != null)
			{
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					int parishFromVillageID = this.getParishFromVillageID(userVillageData.villageID);
					if (parishFromVillageID == parishID)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x00023B0B File Offset: 0x00021D0B
		public void resetTutorialInfo()
		{
			this.m_tutorialInfo = new QuestsAndTutorialInfo();
			this.QuestObjectivesSent = new SparseArray();
			this.tutorialQuestsObjectivesComplete = new List<int>();
		}

		// Token: 0x0600314B RID: 12619 RVA: 0x002845A8 File Offset: 0x002827A8
		public void setTutorialInfo(QuestsAndTutorialInfo tutorialInfo)
		{
			if (tutorialInfo != null)
			{
				int tutorialStage = this.m_tutorialInfo.tutorialStage;
				if (tutorialInfo.questsActive == null)
				{
					this.m_tutorialInfo.tutorialActive = tutorialInfo.tutorialActive;
					this.m_tutorialInfo.tutorialCompleted = tutorialInfo.tutorialCompleted;
					this.m_tutorialInfo.tutorialStage = tutorialInfo.tutorialStage;
					this.m_tutorialInfo.resumeStage = tutorialInfo.resumeStage;
				}
				else
				{
					this.m_tutorialInfo = tutorialInfo;
				}
				if (this.m_tutorialInfo.tutorialActive && tutorialStage != this.m_tutorialInfo.tutorialStage)
				{
					this.newTutorialAvailable = true;
				}
			}
		}

		// Token: 0x0600314C RID: 12620 RVA: 0x00023B2E File Offset: 0x00021D2E
		public int getTutorialStage()
		{
			if (this.m_tutorialInfo == null)
			{
				return 0;
			}
			if (!this.m_tutorialInfo.tutorialActive)
			{
				return -1;
			}
			return this.m_tutorialInfo.tutorialStage;
		}

		// Token: 0x0600314D RID: 12621 RVA: 0x00023B54 File Offset: 0x00021D54
		public bool isTutorialResumable()
		{
			return this.m_tutorialInfo != null && this.m_tutorialInfo.resumeStage >= 0;
		}

		// Token: 0x0600314E RID: 12622 RVA: 0x00284640 File Offset: 0x00282840
		public bool isTutorialActive()
		{
			int tutorialStage = this.getTutorialStage();
			return tutorialStage != -3 && tutorialStage != -1;
		}

		// Token: 0x0600314F RID: 12623 RVA: 0x00023B71 File Offset: 0x00021D71
		public bool isNewTutorialAvailable()
		{
			return this.newTutorialAvailable;
		}

		// Token: 0x06003150 RID: 12624 RVA: 0x00023B79 File Offset: 0x00021D79
		public void tutorialPopupShown()
		{
			this.newTutorialAvailable = false;
		}

		// Token: 0x06003151 RID: 12625 RVA: 0x00023B82 File Offset: 0x00021D82
		public void forceTutorialToBeShown()
		{
			this.newTutorialAvailable = true;
		}

		// Token: 0x06003152 RID: 12626 RVA: 0x00023B8B File Offset: 0x00021D8B
		public int[] getActiveQuests()
		{
			if (this.m_tutorialInfo == null || this.m_tutorialInfo.questsActive == null)
			{
				return new int[0];
			}
			return this.m_tutorialInfo.questsActive;
		}

		// Token: 0x06003153 RID: 12627 RVA: 0x00023BB4 File Offset: 0x00021DB4
		public int[] getCompletedQuests()
		{
			if (this.m_tutorialInfo == null || this.m_tutorialInfo.questsCompleted == null)
			{
				return new int[0];
			}
			return this.m_tutorialInfo.questsCompleted;
		}

		// Token: 0x06003154 RID: 12628 RVA: 0x00284660 File Offset: 0x00282860
		public bool isQuestComplete(int quest)
		{
			if (this.m_tutorialInfo == null || this.m_tutorialInfo.questsCompleted == null)
			{
				return false;
			}
			int[] questsCompleted = this.m_tutorialInfo.questsCompleted;
			foreach (int num in questsCompleted)
			{
				if (num == quest)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003155 RID: 12629 RVA: 0x00023BDD File Offset: 0x00021DDD
		public bool isQuestObjectiveComplete(int quest)
		{
			return this.tutorialQuestsObjectivesComplete.Contains(quest);
		}

		// Token: 0x06003156 RID: 12630 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void advanceTutorialOLD()
		{
		}

		// Token: 0x06003157 RID: 12631 RVA: 0x002846AC File Offset: 0x002828AC
		public void advanceTutorialTo(int targetStage)
		{
			UniversalDebugLog.Log("advancetutorialto " + targetStage.ToString() + "/" + this.getTutorialStage().ToString());
			if (this.getTutorialStage() == -1)
			{
				this.targetTutorialStage = -1;
				return;
			}
			this.targetTutorialStage = targetStage;
			if (this.getTutorialStage() != this.targetTutorialStage)
			{
				this.advanceTutorial();
			}
		}

		// Token: 0x06003158 RID: 12632 RVA: 0x00284710 File Offset: 0x00282910
		public void advanceTutorial()
		{
			UniversalDebugLog.Log("Advancing from " + this.getTutorialStage().ToString());
			if (GameEngine.Instance.World.getTutorialStage() != 0)
			{
				StatTrackingClient.Instance().ActivateTrigger(12, GameEngine.Instance.World.getTutorialStage());
			}
			this.inTutorialAdvance = true;
			RemoteServices.Instance.set_TutorialCommand_UserCallBack(new RemoteServices.TutorialCommand_UserCallBack(this.TutorialCommandCallback));
			RemoteServices.Instance.TutorialCommand(-2);
		}

		// Token: 0x06003159 RID: 12633 RVA: 0x00284794 File Offset: 0x00282994
		public void endTutorial()
		{
			StatTrackingClient.Instance().ActivateTrigger(13, GameEngine.Instance.World.getTutorialStage());
			this.targetTutorialStage = -3;
			this.m_tutorialInfo.tutorialStage = -3;
			RemoteServices.Instance.set_TutorialCommand_UserCallBack(new RemoteServices.TutorialCommand_UserCallBack(this.TutorialCommandCallback));
			RemoteServices.Instance.TutorialCommand(-3);
		}

		// Token: 0x0600315A RID: 12634 RVA: 0x00023BF0 File Offset: 0x00021DF0
		public void resumeTutorial()
		{
			this.inTutorialAdvance = true;
			RemoteServices.Instance.set_TutorialCommand_UserCallBack(new RemoteServices.TutorialCommand_UserCallBack(this.TutorialCommandCallback));
			RemoteServices.Instance.TutorialCommand(-5);
		}

		// Token: 0x0600315B RID: 12635 RVA: 0x00023C1B File Offset: 0x00021E1B
		public bool TutorialIsAdvancing()
		{
			return this.inTutorialAdvance;
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x00023C23 File Offset: 0x00021E23
		public void restartTutorial()
		{
			RemoteServices.Instance.set_TutorialCommand_UserCallBack(new RemoteServices.TutorialCommand_UserCallBack(this.TutorialCommandCallback));
			RemoteServices.Instance.TutorialCommand(-4);
		}

		// Token: 0x0600315D RID: 12637 RVA: 0x002847F8 File Offset: 0x002829F8
		public void TutorialCommandCallback(TutorialCommand_ReturnType returnData)
		{
			this.inTutorialAdvance = false;
			if (returnData.Success)
			{
				this.setTutorialInfo(returnData.m_tutorialInfo);
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_QUESTS)
				{
					InterfaceMgr.Instance.reloadQuestPanel();
				}
				if (returnData.m_tutorialInfo != null && returnData.m_tutorialInfo.tutorialStage == -1)
				{
					this.doSelectTutorialArmy = true;
					GameEngine.Instance.World.getArmiesIfNewAttacks();
				}
			}
		}

		// Token: 0x0600315E RID: 12638 RVA: 0x00284864 File Offset: 0x00282A64
		public void handleQuestObjectiveHappening(int objective)
		{
			int questFromObjectiveFlag = Quests.getQuestFromObjectiveFlag(objective);
			if (questFromObjectiveFlag < 0 || this.m_tutorialInfo == null || this.m_tutorialInfo.questsActive == null || this.QuestObjectivesSent[objective] != null)
			{
				return;
			}
			int[] questsActive = this.m_tutorialInfo.questsActive;
			foreach (int num in questsActive)
			{
				if (num == questFromObjectiveFlag)
				{
					RemoteServices.Instance.set_FlagQuestObjectiveComplete_UserCallBack(new RemoteServices.FlagQuestObjectiveComplete_UserCallBack(this.FlagQuestObjectiveCompleteCallBack));
					RemoteServices.Instance.FlagQuestObjectiveComplete(objective);
					this.QuestObjectivesSent[objective] = 1;
					break;
				}
			}
			if (objective != 10005 && objective != 10002)
			{
				return;
			}
			bool flag = false;
			int[] questsCompleted = this.m_tutorialInfo.questsCompleted;
			foreach (int num2 in questsCompleted)
			{
				if (num2 == questFromObjectiveFlag)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				RemoteServices.Instance.set_FlagQuestObjectiveComplete_UserCallBack(new RemoteServices.FlagQuestObjectiveComplete_UserCallBack(this.FlagQuestObjectiveCompleteCallBack));
				RemoteServices.Instance.FlagQuestObjectiveComplete(objective);
				this.QuestObjectivesSent[objective] = 1;
			}
		}

		// Token: 0x0600315F RID: 12639 RVA: 0x00284980 File Offset: 0x00282B80
		private void FlagQuestObjectiveCompleteCallBack(FlagQuestObjectiveComplete_ReturnType returnData)
		{
			if (returnData.Success && returnData.objectiveCompleted >= 0)
			{
				int questFromObjectiveFlag = Quests.getQuestFromObjectiveFlag(returnData.objectiveCompleted);
				if (questFromObjectiveFlag >= 0)
				{
					this.tutorialQuestsObjectivesComplete.Add(questFromObjectiveFlag);
					this.TutorialQuestCompleted(questFromObjectiveFlag);
				}
			}
		}

		// Token: 0x06003160 RID: 12640 RVA: 0x002849C4 File Offset: 0x00282BC4
		public void TutorialQuestCompleted(int quest)
		{
			int questsTutorialStage = Tutorials.getQuestsTutorialStage(quest);
			if (questsTutorialStage >= 0 && questsTutorialStage == this.getTutorialStage())
			{
				this.forceTutorialToBeShown();
			}
		}

		// Token: 0x06003161 RID: 12641 RVA: 0x002849EC File Offset: 0x00282BEC
		public void handleQuestObjectiveHappening_PlayedCard(int cardType)
		{
			int num = -1;
			if (cardType - 769 > 1 && cardType != 2950)
			{
				if (cardType - 3201 <= 2)
				{
					num = 10005;
				}
			}
			else
			{
				num = 10002;
			}
			if (num >= 0)
			{
				this.handleQuestObjectiveHappening(num);
				if (GameEngine.Instance.GameDisplayMode == GameEngine.GameDisplays.DISPLAY_QUESTS)
				{
					InterfaceMgr.Instance.reloadQuestPanel();
				}
			}
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x00023C47 File Offset: 0x00021E47
		public void checkQuestObjectiveComplete(int quest)
		{
			RemoteServices.Instance.set_CheckQuestObjectiveComplete_UserCallBack(new RemoteServices.CheckQuestObjectiveComplete_UserCallBack(this.CheckQuestObjectiveCompleteCallBack));
			RemoteServices.Instance.CheckQuestObjectiveComplete(quest);
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x00023C6A File Offset: 0x00021E6A
		private void CheckQuestObjectiveCompleteCallBack(CheckQuestObjectiveComplete_ReturnType returnData)
		{
			if (returnData.Success && returnData.questCompleted >= 0)
			{
				this.tutorialQuestsObjectivesComplete.Add(returnData.questCompleted);
			}
		}

		// Token: 0x06003164 RID: 12644 RVA: 0x00023C8E File Offset: 0x00021E8E
		public void addCompletedQuestObjectives(int quest)
		{
			this.tutorialQuestsObjectivesComplete.Add(quest);
		}

		// Token: 0x06003165 RID: 12645 RVA: 0x00284A4C File Offset: 0x00282C4C
		public void getPersonData()
		{
			this.lastPersonTime = DateTime.Now.AddYears(-5);
			RemoteServices.Instance.set_GetUserPeople_UserCallBack(new RemoteServices.GetUserPeople_UserCallBack(this.getUserPeopleCallback));
			RemoteServices.Instance.GetUserPeople();
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x00023C9C File Offset: 0x00021E9C
		public void getUserPeopleCallback(GetUserPeople_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
				return;
			}
			this.loadingErrored = true;
		}

		// Token: 0x06003167 RID: 12647 RVA: 0x00023CC9 File Offset: 0x00021EC9
		public void getActivePeople()
		{
			RemoteServices.Instance.set_GetActivePeople_UserCallBack(new RemoteServices.GetActivePeople_UserCallBack(this.getActivePeopleCallback));
			RemoteServices.Instance.GetActivePeople(this.lastPersonTime);
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x00023CF1 File Offset: 0x00021EF1
		public void getActivePeopleCallback(GetActivePeople_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
				this.lastPersonTime = returnData.currentTime;
				return;
			}
			this.loadingErrored = true;
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x00284A90 File Offset: 0x00282C90
		public void importOrphanedPeople(List<PersonData> personData, DateTime curServerTime, int villageID)
		{
			this.clearPersonArray(villageID);
			if (personData != null)
			{
				AllArmiesPanel2.MonksUpdated = true;
				foreach (PersonData personData2 in personData)
				{
					this.addPerson(personData2, curServerTime);
				}
			}
			this.countChildren();
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x00284AF8 File Offset: 0x00282CF8
		public void clearPersonArray(int villageID)
		{
			if (villageID != -2)
			{
				if (villageID < 0)
				{
					this.personArray.Clear();
					return;
				}
				List<WorldMap.LocalPerson> list = new List<WorldMap.LocalPerson>();
				foreach (object obj in this.personArray)
				{
					WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
					if (localPerson.person.homeVillageID == villageID)
					{
						list.Add(localPerson);
					}
				}
				foreach (WorldMap.LocalPerson localPerson2 in list)
				{
					this.personArray[localPerson2.personID] = null;
				}
			}
		}

		// Token: 0x0600316B RID: 12651 RVA: 0x00284BC8 File Offset: 0x00282DC8
		public void addPerson(PersonData personData, DateTime curServerTime)
		{
			WorldMap.LocalPerson localPerson = new WorldMap.LocalPerson();
			localPerson.person = personData;
			localPerson.personID = personData.personID;
			if (personData.state > 0)
			{
				localPerson.createJourney(personData.startTime, curServerTime, personData.endTime);
				if (personData.targetVillageID < this.villageList.Length)
				{
					localPerson.targetDisplayX = (double)this.villageList[personData.targetVillageID].x;
					localPerson.targetDisplayY = (double)this.villageList[personData.targetVillageID].y;
				}
				localPerson.seaTravel = this.isIslandTravel(personData.homeVillageID, personData.targetVillageID);
				bool flag = true;
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					int special = this.getSpecial(personData.homeVillageID);
					if (special - 7 <= 7)
					{
						flag = false;
					}
				}
				if (flag)
				{
					foreach (object obj in this.personArray)
					{
						WorldMap.LocalPerson localPerson2 = (WorldMap.LocalPerson)obj;
						localPerson2.childrenCount = 0;
						if (localPerson2.parentPerson == -1L && localPerson2.personID != localPerson.personID && localPerson2.person.state == personData.state && localPerson2.person.targetVillageID == personData.targetVillageID && localPerson2.person.homeVillageID == personData.homeVillageID)
						{
							TimeSpan timeSpan = localPerson2.person.endTime - personData.endTime;
							if (timeSpan.TotalSeconds < 1.0 && timeSpan.TotalSeconds > -1.0)
							{
								localPerson.parentPerson = localPerson2.person.personID;
								break;
							}
						}
					}
				}
			}
			if (personData.homeVillageID < this.villageList.Length)
			{
				localPerson.baseDisplayX = (double)this.villageList[personData.homeVillageID].x;
				localPerson.baseDisplayY = (double)this.villageList[personData.homeVillageID].y;
			}
			double realTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
			localPerson.updatePosition(realTime);
			this.personArray[localPerson.personID] = localPerson;
		}

		// Token: 0x0600316C RID: 12652 RVA: 0x00284E08 File Offset: 0x00283008
		public void countChildren()
		{
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.parentPerson != -1L && localPerson.personID != localPerson.parentPerson && this.personArray.ContainsKey(localPerson.parentPerson))
				{
					((WorldMap.LocalPerson)this.personArray[localPerson.parentPerson]).childrenCount++;
				}
			}
		}

		// Token: 0x0600316D RID: 12653 RVA: 0x00284EA8 File Offset: 0x002830A8
		public void updatePeople()
		{
			try
			{
				List<long> list = new List<long>();
				int num = 0;
				bool flag = true;
				if (!flag)
				{
					this.p_startAt = this.p_endAt;
					if (this.p_startAt >= this.personArray.Count)
					{
						this.p_startAt = 0;
						this.p_endAt = 0;
					}
					this.p_endAt += this.p_perFrame;
					if (this.p_endAt > this.personArray.Count)
					{
						this.p_endAt = this.personArray.Count;
					}
				}
				double realTime = DXTimer.GetCurrentMilliseconds() / 1000.0;
				foreach (object obj in this.personArray)
				{
					WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
					if (!flag)
					{
						if (num < this.p_startAt)
						{
							num++;
							continue;
						}
						if (num >= this.p_endAt)
						{
							break;
						}
						num++;
					}
					localPerson.updatePosition(realTime);
					if (localPerson.dying)
					{
						list.Add(localPerson.personID);
					}
				}
				foreach (long index in list)
				{
					this.personArray.RemoveAt(index);
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("exception updating armies " + ex.ToString());
			}
		}

		// Token: 0x0600316E RID: 12654 RVA: 0x00285054 File Offset: 0x00283254
		public void drawPeople(RectangleF screenRect)
		{
			float num = (float)this.m_worldScale / 28f / 0.6f;
			if (num < 0.1f)
			{
				num = 0.1f;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			SparseArray sparseArray = new SparseArray();
			SparseArray sparseArray2 = new SparseArray();
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			bool aiworld = GameEngine.Instance.LocalWorldData.AIWorld;
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.person.state > 0 && localPerson.isVisible(screenRect) && worldMapFilter.showPeople(localPerson))
				{
					if ((localPerson.person.state == 1 || localPerson.person.state == 11 || localPerson.person.state == 21 || localPerson.person.state == 31 || localPerson.person.state == 50 || localPerson.person.state == 75) && localPerson.parentPerson == -1L)
					{
						int num2 = 0;
						int num3 = 2;
						if (!this.isUserVillage(localPerson.person.homeVillageID))
						{
							num2 = 1;
							num3 += num2;
							if (aiworld)
							{
								switch (this.getSpecial(localPerson.person.homeVillageID))
								{
								case 7:
								case 8:
									num2 = 403;
									num3 = 404;
									break;
								case 9:
								case 10:
									num2 = 404;
									num3 = 408;
									break;
								case 11:
								case 12:
									num2 = 405;
									num3 = 412;
									break;
								case 13:
								case 14:
									num2 = 406;
									num3 = 416;
									break;
								}
							}
						}
						if (localPerson.person.personType == 100)
						{
							num3 = 142;
						}
						if (this.DrawingArmyArrows)
						{
							this.villageSprite.PosX = (float)(localPerson.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							this.villageSprite.PosY = (float)(localPerson.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
							this.villageSprite.SpriteNo = num3;
							this.villageSprite.Center = new PointF(44f, 44f);
							this.villageSprite.RotationAngle = SpriteWrapper.getFacing(localPerson.BasePoint(), localPerson.TargetPoint());
							this.villageSprite.Scale = num;
							this.villageSprite.Update();
							this.villageSprite.DrawAndClear();
						}
						int num4 = num3;
						int personType = localPerson.person.personType;
						if (personType != 4)
						{
							if (personType == 100)
							{
								num3 = 173;
							}
						}
						else
						{
							num3 = 18 + num2;
						}
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						this.villageSprite.SpriteNo = num3;
						this.villageSprite.Center = new PointF(44f, 44f);
						this.villageSprite.Scale = num;
						this.villageSprite.Update();
						this.villageSprite.DrawAndClear();
						if (localPerson.seaTravel)
						{
							this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
							if (num4 <= 404)
							{
								switch (num4)
								{
								case 0:
									this.villageSprite.SpriteNo = 425;
									break;
								case 1:
									this.villageSprite.SpriteNo = 426;
									break;
								case 2:
									this.villageSprite.SpriteNo = 427;
									break;
								case 3:
									this.villageSprite.SpriteNo = 428;
									break;
								default:
									if (num4 == 404)
									{
										this.villageSprite.SpriteNo = 429;
									}
									break;
								}
							}
							else if (num4 != 408)
							{
								if (num4 != 412)
								{
									if (num4 == 416)
									{
										this.villageSprite.SpriteNo = 432;
									}
								}
								else
								{
									this.villageSprite.SpriteNo = 431;
								}
							}
							else
							{
								this.villageSprite.SpriteNo = 430;
							}
							this.villageSprite.Center = new PointF(44f, 44f);
							this.villageSprite.ColorToUse = Color.FromArgb(this.alphaValue, global::ARGBColors.White);
							this.villageSprite.Scale = num;
							this.villageSprite.Update();
							this.villageSprite.DrawAndClear();
						}
					}
					else if (localPerson.person.state == 2)
					{
						int targetVillageID = localPerson.person.targetVillageID;
						WorldMap.CapitalPeopleGFX capitalPeopleGFX;
						if (sparseArray[targetVillageID] == null)
						{
							capitalPeopleGFX = new WorldMap.CapitalPeopleGFX();
							capitalPeopleGFX.posX = (float)(localPerson.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							capitalPeopleGFX.posY = (float)(localPerson.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							sparseArray[targetVillageID] = capitalPeopleGFX;
						}
						else
						{
							capitalPeopleGFX = (WorldMap.CapitalPeopleGFX)sparseArray[targetVillageID];
						}
						if (!this.isUserVillage(localPerson.person.homeVillageID))
						{
							capitalPeopleGFX.numOthers++;
						}
						else
						{
							capitalPeopleGFX.numYours++;
						}
					}
					else if (localPerson.person.state == 12 || localPerson.person.state == 22)
					{
						int targetVillageID2 = localPerson.person.targetVillageID;
						WorldMap.CapitalPeopleGFX capitalPeopleGFX2;
						if (sparseArray2[targetVillageID2] == null)
						{
							capitalPeopleGFX2 = new WorldMap.CapitalPeopleGFX();
							capitalPeopleGFX2.posX = (float)(localPerson.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							capitalPeopleGFX2.posY = (float)(localPerson.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							sparseArray2[targetVillageID2] = capitalPeopleGFX2;
						}
						else
						{
							capitalPeopleGFX2 = (WorldMap.CapitalPeopleGFX)sparseArray2[targetVillageID2];
						}
						if (localPerson.person.state == 12)
						{
							capitalPeopleGFX2.numYours++;
						}
						else
						{
							capitalPeopleGFX2.numOthers++;
						}
					}
				}
			}
		}

		// Token: 0x0600316F RID: 12655 RVA: 0x002856FC File Offset: 0x002838FC
		private long findNearestPersonFromScreenPos(Point mousePos, ref double bestDist)
		{
			if (InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return -1L;
			}
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestPersonFromMapPos(num, num2, ref bestDist);
			}
			return -1L;
		}

		// Token: 0x06003170 RID: 12656 RVA: 0x002857A4 File Offset: 0x002839A4
		private long findNearestPersonFromMapPos(double mapX, double mapY, ref double bestDist)
		{
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			long result = -1L;
			double num = 2.25;
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.person.state > 0 && localPerson.person.state != 2 && localPerson.person.state != 12 && localPerson.person.state != 22 && localPerson.parentPerson == -1L && worldMapFilter.showPeople(localPerson))
				{
					double num2 = (localPerson.displayX - mapX) * (localPerson.displayX - mapX) + (localPerson.displayY - mapY) * (localPerson.displayY - mapY);
					if (num2 < num)
					{
						num = num2;
						result = localPerson.personID;
					}
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x00023D2A File Offset: 0x00021F2A
		public WorldMap.LocalPerson getPerson(long personID)
		{
			return (WorldMap.LocalPerson)this.personArray[personID];
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x00023D3D File Offset: 0x00021F3D
		public SparseArray getPeopleArray()
		{
			return this.personArray;
		}

		// Token: 0x06003173 RID: 12659 RVA: 0x002858B0 File Offset: 0x00283AB0
		public int countVillagePeople(int villageID, int personType, ref int athome)
		{
			athome = 0;
			int num = 0;
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.person.homeVillageID == villageID && localPerson.person.personType == personType)
				{
					num++;
					if (localPerson.person.state == 0)
					{
						athome++;
					}
				}
			}
			return num;
		}

		// Token: 0x06003174 RID: 12660 RVA: 0x0028593C File Offset: 0x00283B3C
		public bool isSpyCommandDataActive(int villageID, int commandBits)
		{
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.person.targetVillageID == villageID && localPerson.person.personType == 1 && localPerson.person.state == 12 && (localPerson.person.spyCommandsDone & commandBits) != 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003175 RID: 12661 RVA: 0x00023D45 File Offset: 0x00021F45
		public void importCounterSpyInfo(List<CounterSpyInfo> info)
		{
			this.counterSpyInfo = info;
		}

		// Token: 0x06003176 RID: 12662 RVA: 0x002859D0 File Offset: 0x00283BD0
		public List<CounterSpyInfo> getCounterSpyInfo(int villageID)
		{
			List<CounterSpyInfo> list = new List<CounterSpyInfo>();
			if (this.counterSpyInfo != null)
			{
				foreach (CounterSpyInfo counterSpyInfo in this.counterSpyInfo)
				{
					if (counterSpyInfo.targetVillageID == villageID)
					{
						list.Add(counterSpyInfo);
					}
				}
				return list;
			}
			return list;
		}

		// Token: 0x06003177 RID: 12663 RVA: 0x00023D4E File Offset: 0x00021F4E
		public void importFreeCardData(int currentLevel, bool[] stages, DateTime nextCardTime, DateTime serverTime)
		{
			this.freeCardInfo = FreeCardsData.createFreeCardData(currentLevel, stages, nextCardTime, serverTime);
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x00285A40 File Offset: 0x00283C40
		public void initWorldMap(int mapType)
		{
			this.storedRegionFactionsPos = -1L;
			this.storedCountyFactionsPos = -1L;
			this.storedProvinceFactionsPos = -1L;
			this.storedVillageFactionsPos = -1L;
			this.storedCountryFactionsPos = -1L;
			this.storedFactionChangesPos = -1L;
			this.storedParishFlagsPos = -1L;
			this.storedCountyFlagsPos = -1L;
			this.storedProvinceFlagsPos = -1L;
			this.storedCountryFlagsPos = -1L;
			this.currentMapType = mapType;
			WorldMapType mapData = GameEngine.Instance.WorldMapTypesData.getMapData(mapType);
			if (mapData == null)
			{
				throw new Exception("Map Data was null");
			}
			if (mapData.mapName == null)
			{
				throw new Exception("Map Data Name was null");
			}
			this.loadData(mapData.mapName);
			this.initMapTiles(mapData.tmapName, mapData.tileMapWidth, mapData.tileMapHeight);
			if (mapData.mapName.ToLower() == "uk.wmpData".ToLower())
			{
				WorldMap.WorldPointList worldPointList = this.regionList[2399];
				List<WorldMap.Triangle> list = new List<WorldMap.Triangle>();
				list.AddRange(worldPointList.triangleList);
				list.Add(this.makeTriangle(worldPointList.regionBorderList[9], worldPointList.regionBorderList[11], worldPointList.regionBorderList[10]));
				list.Add(this.makeTriangle(worldPointList.regionBorderList[11], worldPointList.regionBorderList[9], worldPointList.regionBorderList[12]));
				worldPointList.triangleList = list.ToArray();
				List<WorldMap.WorldPoint> list2 = new List<WorldMap.WorldPoint>();
				for (int i = 0; i < worldPointList.regionBorderList.Length; i++)
				{
					if (i < 9 || i > 12)
					{
						list2.Add(worldPointList.regionBorderList[i]);
					}
				}
				worldPointList.regionBorderList = list2.ToArray();
				worldPointList = this.regionList[3152];
				list = new List<WorldMap.Triangle>();
				list.AddRange(worldPointList.triangleList);
				list.Add(this.makeTriangle(worldPointList.regionBorderList[10], worldPointList.regionBorderList[12], worldPointList.regionBorderList[11]));
				worldPointList.triangleList = list.ToArray();
				list2 = new List<WorldMap.WorldPoint>();
				for (int j = 0; j < worldPointList.regionBorderList.Length; j++)
				{
					if (j < 10 || j > 12)
					{
						list2.Add(worldPointList.regionBorderList[j]);
					}
				}
				worldPointList.regionBorderList = list2.ToArray();
				worldPointList = this.regionList[1880];
				list = new List<WorldMap.Triangle>();
				list.AddRange(worldPointList.triangleList);
				list.Add(this.makeTriangle(worldPointList.regionBorderList[4], worldPointList.regionBorderList[5], worldPointList.regionBorderList[6]));
				worldPointList.triangleList = list.ToArray();
				list2 = new List<WorldMap.WorldPoint>();
				for (int k = 0; k < worldPointList.regionBorderList.Length; k++)
				{
					if (k < 4 || k > 6)
					{
						list2.Add(worldPointList.regionBorderList[k]);
					}
				}
				worldPointList.regionBorderList = list2.ToArray();
				worldPointList = this.regionList[907];
				list = new List<WorldMap.Triangle>();
				list.AddRange(worldPointList.triangleList);
				list.Add(this.makeTriangle(worldPointList.regionBorderList[9], worldPointList.regionBorderList[10], worldPointList.regionBorderList[11]));
				worldPointList.triangleList = list.ToArray();
				list2 = new List<WorldMap.WorldPoint>();
				for (int l = 0; l < worldPointList.regionBorderList.Length; l++)
				{
					if (l != 10)
					{
						list2.Add(worldPointList.regionBorderList[l]);
					}
				}
				worldPointList.regionBorderList = list2.ToArray();
				worldPointList = this.regionList[35];
				list = new List<WorldMap.Triangle>();
				list.AddRange(worldPointList.triangleList);
				list.Add(this.makeTriangle(worldPointList.regionBorderList[2], worldPointList.regionBorderList[4], worldPointList.regionBorderList[3]));
				worldPointList.triangleList = list.ToArray();
				list2 = new List<WorldMap.WorldPoint>();
				for (int m = 0; m < worldPointList.regionBorderList.Length; m++)
				{
					if (m != 3)
					{
						list2.Add(worldPointList.regionBorderList[m]);
					}
				}
				worldPointList.regionBorderList = list2.ToArray();
			}
			if (mapData.mapName.ToLower() == "uk2.wmpData".ToLower() || mapData.mapName.ToLower() == "ukai.wmpData".ToLower())
			{
				WorldMap.WorldPointList worldPointList2 = this.regionList[1162];
				worldPointList2.regionBorderList[2].x = 1826f;
				worldPointList2.regionBorderList[2].y = 2747f;
				worldPointList2.triangleList[4].x2 = 1826f;
				worldPointList2.triangleList[4].y2 = 2747f;
			}
			if (mapData.mapName.ToLower() == "de.wmpData".ToLower())
			{
				WorldMap.WorldPointList worldPointList3 = this.regionList[4058];
				List<WorldMap.Triangle> list3 = new List<WorldMap.Triangle>();
				list3.AddRange(worldPointList3.triangleList);
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[4], worldPointList3.regionBorderList[6], worldPointList3.regionBorderList[5]));
				worldPointList3.triangleList = list3.ToArray();
				List<WorldMap.WorldPoint> list4 = new List<WorldMap.WorldPoint>();
				for (int n = 0; n < worldPointList3.regionBorderList.Length; n++)
				{
					if (n < 4 || n > 6)
					{
						list4.Add(worldPointList3.regionBorderList[n]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[551];
				list3 = new List<WorldMap.Triangle>();
				for (int num = 0; num < worldPointList3.triangleList.Length; num++)
				{
					if ((worldPointList3.triangleList[num].x1 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num].y1 != worldPointList3.regionBorderList[5].y) && (worldPointList3.triangleList[num].x2 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num].y2 != worldPointList3.regionBorderList[5].y) && (worldPointList3.triangleList[num].x3 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num].y3 != worldPointList3.regionBorderList[5].y))
					{
						list3.Add(worldPointList3.triangleList[num]);
					}
				}
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num2 = 0; num2 < worldPointList3.regionBorderList.Length; num2++)
				{
					if (num2 < 3 || num2 > 5)
					{
						list4.Add(worldPointList3.regionBorderList[num2]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[2890];
				list3 = new List<WorldMap.Triangle>();
				for (int num3 = 0; num3 < worldPointList3.triangleList.Length; num3++)
				{
					if ((worldPointList3.triangleList[num3].x1 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num3].y1 != worldPointList3.regionBorderList[7].y) && (worldPointList3.triangleList[num3].x2 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num3].y2 != worldPointList3.regionBorderList[7].y) && (worldPointList3.triangleList[num3].x3 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num3].y3 != worldPointList3.regionBorderList[7].y))
					{
						list3.Add(worldPointList3.triangleList[num3]);
					}
				}
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[6], worldPointList3.regionBorderList[13], worldPointList3.regionBorderList[10]));
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num4 = 0; num4 < worldPointList3.regionBorderList.Length; num4++)
				{
					if (num4 < 6 || num4 > 8)
					{
						list4.Add(worldPointList3.regionBorderList[num4]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[3725];
				list3 = new List<WorldMap.Triangle>();
				for (int num5 = 0; num5 < worldPointList3.triangleList.Length; num5++)
				{
					if ((worldPointList3.triangleList[num5].x1 != worldPointList3.regionBorderList[4].x || worldPointList3.triangleList[num5].y1 != worldPointList3.regionBorderList[4].y) && (worldPointList3.triangleList[num5].x2 != worldPointList3.regionBorderList[4].x || worldPointList3.triangleList[num5].y2 != worldPointList3.regionBorderList[4].y) && (worldPointList3.triangleList[num5].x3 != worldPointList3.regionBorderList[4].x || worldPointList3.triangleList[num5].y3 != worldPointList3.regionBorderList[4].y))
					{
						list3.Add(worldPointList3.triangleList[num5]);
					}
				}
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[3], worldPointList3.regionBorderList[4], worldPointList3.regionBorderList[8]));
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[8], worldPointList3.regionBorderList[4], worldPointList3.regionBorderList[9]));
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[4], worldPointList3.regionBorderList[6], worldPointList3.regionBorderList[9]));
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num6 = 0; num6 < worldPointList3.regionBorderList.Length; num6++)
				{
					if (num6 != 3)
					{
						if (num6 - 4 > 5)
						{
							list4.Add(worldPointList3.regionBorderList[num6]);
						}
					}
					else
					{
						list4.Add(worldPointList3.regionBorderList[num6]);
						list4.Add(worldPointList3.regionBorderList[4]);
						list4.Add(worldPointList3.regionBorderList[6]);
						list4.Add(worldPointList3.regionBorderList[9]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[624];
				list3 = new List<WorldMap.Triangle>();
				for (int num7 = 0; num7 < worldPointList3.triangleList.Length; num7++)
				{
					if ((worldPointList3.triangleList[num7].x1 != worldPointList3.regionBorderList[6].x || worldPointList3.triangleList[num7].y1 != worldPointList3.regionBorderList[6].y) && (worldPointList3.triangleList[num7].x2 != worldPointList3.regionBorderList[6].x || worldPointList3.triangleList[num7].y2 != worldPointList3.regionBorderList[6].y) && (worldPointList3.triangleList[num7].x3 != worldPointList3.regionBorderList[6].x || worldPointList3.triangleList[num7].y3 != worldPointList3.regionBorderList[6].y))
					{
						list3.Add(worldPointList3.triangleList[num7]);
					}
				}
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num8 = 0; num8 < worldPointList3.regionBorderList.Length; num8++)
				{
					if (num8 < 4 || num8 > 6)
					{
						list4.Add(worldPointList3.regionBorderList[num8]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[274];
				list3 = new List<WorldMap.Triangle>();
				list3.AddRange(worldPointList3.triangleList);
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[7], worldPointList3.regionBorderList[9], worldPointList3.regionBorderList[8]));
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num9 = 0; num9 < worldPointList3.regionBorderList.Length; num9++)
				{
					if (num9 < 7 || num9 > 9)
					{
						list4.Add(worldPointList3.regionBorderList[num9]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[1704];
				list3 = new List<WorldMap.Triangle>();
				for (int num10 = 0; num10 < worldPointList3.triangleList.Length; num10++)
				{
					if ((worldPointList3.triangleList[num10].x1 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num10].y1 != worldPointList3.regionBorderList[5].y) && (worldPointList3.triangleList[num10].x2 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num10].y2 != worldPointList3.regionBorderList[5].y) && (worldPointList3.triangleList[num10].x3 != worldPointList3.regionBorderList[5].x || worldPointList3.triangleList[num10].y3 != worldPointList3.regionBorderList[5].y))
					{
						list3.Add(worldPointList3.triangleList[num10]);
					}
				}
				list4 = new List<WorldMap.WorldPoint>();
				for (int num11 = 0; num11 < worldPointList3.regionBorderList.Length; num11++)
				{
					if (num11 < 5 || num11 > 7)
					{
						list4.Add(worldPointList3.regionBorderList[num11]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[4], worldPointList3.regionBorderList[5], worldPointList3.regionBorderList[8]));
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[5], worldPointList3.regionBorderList[6], worldPointList3.regionBorderList[8]));
				worldPointList3.triangleList = list3.ToArray();
				worldPointList3 = this.regionList[737];
				list3 = new List<WorldMap.Triangle>();
				for (int num12 = 0; num12 < worldPointList3.triangleList.Length; num12++)
				{
					if ((worldPointList3.triangleList[num12].x1 != worldPointList3.regionBorderList[9].x || worldPointList3.triangleList[num12].y1 != worldPointList3.regionBorderList[9].y) && (worldPointList3.triangleList[num12].x2 != worldPointList3.regionBorderList[9].x || worldPointList3.triangleList[num12].y2 != worldPointList3.regionBorderList[9].y) && (worldPointList3.triangleList[num12].x3 != worldPointList3.regionBorderList[9].x || worldPointList3.triangleList[num12].y3 != worldPointList3.regionBorderList[9].y))
					{
						list3.Add(worldPointList3.triangleList[num12]);
					}
				}
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[10], worldPointList3.regionBorderList[6], worldPointList3.regionBorderList[7]));
				list3.Add(this.makeTriangle(worldPointList3.regionBorderList[10], worldPointList3.regionBorderList[7], worldPointList3.regionBorderList[8]));
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num13 = 0; num13 < worldPointList3.regionBorderList.Length; num13++)
				{
					if (num13 < 8 || num13 > 10)
					{
						list4.Add(worldPointList3.regionBorderList[num13]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
				worldPointList3 = this.regionList[2002];
				list3 = new List<WorldMap.Triangle>();
				for (int num14 = 0; num14 < worldPointList3.triangleList.Length; num14++)
				{
					if ((worldPointList3.triangleList[num14].x1 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num14].y1 != worldPointList3.regionBorderList[7].y) && (worldPointList3.triangleList[num14].x2 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num14].y2 != worldPointList3.regionBorderList[7].y) && (worldPointList3.triangleList[num14].x3 != worldPointList3.regionBorderList[7].x || worldPointList3.triangleList[num14].y3 != worldPointList3.regionBorderList[7].y))
					{
						list3.Add(worldPointList3.triangleList[num14]);
					}
				}
				worldPointList3.triangleList = list3.ToArray();
				list4 = new List<WorldMap.WorldPoint>();
				for (int num15 = 0; num15 < worldPointList3.regionBorderList.Length; num15++)
				{
					if (num15 < 6 || num15 > 8)
					{
						list4.Add(worldPointList3.regionBorderList[num15]);
					}
				}
				worldPointList3.regionBorderList = list4.ToArray();
			}
			if (mapData.mapName.ToLower() == "fr.wmpData".ToLower())
			{
				WorldMap.WorldPointList worldPointList4 = this.regionList[1286];
				List<WorldMap.WorldPoint> list5 = new List<WorldMap.WorldPoint>();
				for (int num16 = 0; num16 < worldPointList4.regionBorderList.Length; num16++)
				{
					if (num16 == 2)
					{
						list5.Add(this.pointList[this.pointList.Length - 1]);
					}
					list5.Add(worldPointList4.regionBorderList[num16]);
				}
				worldPointList4.regionBorderList = list5.ToArray();
				List<WorldMap.Triangle> list6 = new List<WorldMap.Triangle>();
				for (int num17 = 0; num17 < worldPointList4.triangleList.Length; num17++)
				{
					list6.Add(worldPointList4.triangleList[num17]);
				}
				list6.Add(this.makeTriangle(worldPointList4.regionBorderList[1], worldPointList4.regionBorderList[2], worldPointList4.regionBorderList[3]));
				worldPointList4.triangleList = list6.ToArray();
			}
			bool isSpain = mapData.mapName.ToLower() == "es.wmpData".ToLower();
			if (mapData.mapName.ToLower() == "uk.wmpData".ToLower() || mapData.mapName.ToLower() == "ukai.wmpData".ToLower() || mapData.mapName.ToLower() == "uk2.wmpData".ToLower())
			{
				this.villageList[92752].whiteName = true;
				this.villageList[104470].whiteName = true;
				this.villageList[35971].whiteName = true;
				this.villageList[40877].whiteName = true;
				this.villageList[79880].whiteName = true;
				this.villageList[15606].whiteName = true;
				this.villageList[47150].whiteName = true;
				this.villageList[38968].whiteName = true;
				this.villageList[887].whiteName = true;
				this.villageList[63242].whiteName = true;
				this.villageList[48860].whiteName = true;
				this.villageList[9814].whiteName = true;
				this.villageList[63346].whiteName = true;
				this.villageList[7048].whiteName = true;
				this.villageList[26822].whiteName = true;
				this.villageList[92323].whiteName = true;
				this.villageList[20064].whiteName = true;
				this.villageList[101024].whiteName = true;
				this.villageList[4990].whiteName = true;
				this.villageList[57072].whiteName = true;
				this.villageList[68411].whiteName = true;
				this.villageList[97936].whiteName = true;
				this.villageList[96751].whiteName = true;
				this.villageList[47510].whiteName = true;
				this.villageList[100192].whiteName = true;
				this.villageList[67820].whiteName = true;
				this.villageList[40584].whiteName = true;
				this.villageList[7023].whiteName = true;
				this.villageList[20886].whiteName = true;
				this.villageList[47609].whiteName = true;
				this.villageList[51105].whiteName = true;
				this.villageList[17224].whiteName = true;
				this.villageList[40621].whiteName = true;
				this.villageList[78266].whiteName = true;
				this.villageList[99511].whiteName = true;
				this.villageList[86735].whiteName = true;
				this.villageList[96213].whiteName = true;
				this.villageList[5939].whiteName = true;
				this.villageList[33068].whiteName = true;
				this.villageList[96920].whiteName = true;
				this.villageList[72446].whiteName = true;
				this.villageList[65059].whiteName = true;
				this.villageList[80891].whiteName = true;
				this.villageList[37030].whiteName = true;
				this.villageList[44474].whiteName = true;
				this.villageList[92875].whiteName = true;
				this.villageList[1260].whiteName = true;
				this.villageList[98708].whiteName = true;
				this.villageList[84603].whiteName = true;
				this.villageList[13420].whiteName = true;
				this.villageList[102192].whiteName = true;
				this.villageList[61617].whiteName = true;
				this.villageList[6298].whiteName = true;
				this.villageList[1849].whiteName = true;
				this.villageList[1922].whiteName = true;
				this.villageList[46926].whiteName = true;
				this.villageList[8269].whiteName = true;
				this.villageList[47460].whiteName = true;
				this.villageList[69904].whiteName = true;
				this.villageList[73159].whiteName = true;
				this.villageList[90296].whiteName = true;
				this.villageList[2333].whiteName = true;
				this.villageList[75785].whiteName = true;
				this.villageList[61988].whiteName = true;
				this.villageList[95778].whiteName = true;
				this.villageList[4907].whiteName = true;
				this.villageList[80977].whiteName = true;
				this.villageList[63648].whiteName = true;
				this.villageList[59676].whiteName = true;
				this.villageList[97400].whiteName = true;
				this.villageList[73745].whiteName = true;
				this.villageList[6110].whiteName = true;
				this.villageList[89402].whiteName = true;
				this.villageList[66929].whiteName = true;
				this.villageList[71819].whiteName = true;
				this.villageList[4096].whiteName = true;
				this.villageList[77463].whiteName = true;
				this.villageList[48655].whiteName = true;
				this.villageList[70438].whiteName = true;
				this.villageList[67537].whiteName = true;
				this.villageList[81005].whiteName = true;
				this.villageList[74711].whiteName = true;
				this.villageList[78992].whiteName = true;
				this.villageList[73367].whiteName = true;
				this.villageList[16549].whiteName = true;
				this.villageList[88967].whiteName = true;
				this.villageList[11626].whiteName = true;
				this.villageList[90169].whiteName = true;
				this.villageList[6870].whiteName = true;
				this.villageList[3419].whiteName = true;
				this.villageList[16513].whiteName = true;
				this.villageList[82509].whiteName = true;
				this.villageList[28871].whiteName = true;
				this.villageList[26127].whiteName = true;
				this.villageList[34202].whiteName = true;
				this.villageList[73281].whiteName = true;
				this.villageList[35297].whiteName = true;
				this.villageList[97838].whiteName = true;
				this.villageList[83438].whiteName = true;
				this.villageList[5667].whiteName = true;
				this.villageList[84766].whiteName = true;
				this.villageList[8931].whiteName = true;
				this.villageList[104362].whiteName = true;
				this.villageList[40448].whiteName = true;
				this.villageList[56972].whiteName = true;
				this.villageList[55864].whiteName = true;
				this.villageList[70568].whiteName = true;
				this.villageList[28572].whiteName = true;
				this.villageList[92022].whiteName = true;
				this.villageList[70772].whiteName = true;
				this.villageList[72672].whiteName = true;
				this.villageList[5411].whiteName = true;
				this.villageList[1399].whiteName = true;
				this.villageList[72492].whiteName = true;
				this.villageList[15605].whiteName = true;
				this.villageList[104772].whiteName = true;
				this.villageList[67668].whiteName = true;
				this.villageList[50526].whiteName = true;
				this.villageList[72429].whiteName = true;
				this.villageList[46961].whiteName = true;
				this.villageList[50526].whiteName = true;
				this.villageList[72429].whiteName = true;
				this.villageList[27672].whiteName = true;
				this.villageList[21519].whiteName = true;
				this.villageList[22470].whiteName = true;
				this.villageList[10316].whiteName = true;
				this.villageList[64236].whiteName = true;
				this.villageList[27672].whiteName = true;
				this.villageList[42421].whiteName = true;
				this.villageList[55689].whiteName = true;
				this.villageList[35377].whiteName = true;
				this.villageList[1925].whiteName = true;
				this.villageList[81147].whiteName = true;
				this.villageList[97051].whiteName = true;
				this.villageList[61137].whiteName = true;
				this.villageList[8703].whiteName = true;
				this.villageList[28286].whiteName = true;
				this.villageList[38025].whiteName = true;
				this.villageList[6812].whiteName = true;
				this.villageList[14536].whiteName = true;
				this.villageList[76156].whiteName = true;
				this.villageList[73071].whiteName = true;
				this.villageList[23995].whiteName = true;
				this.villageList[43806].whiteName = true;
				this.villageList[93282].whiteName = true;
				this.villageList[98715].whiteName = true;
				this.villageList[18253].whiteName = true;
				this.villageList[85156].whiteName = true;
				this.villageList[1479].whiteName = true;
				this.villageList[46961].whiteName = true;
				this.villageList[43811].whiteName = true;
				this.villageList[86963].whiteName = true;
				this.villageList[92752].whiteFlags = true;
				this.villageList[104470].whiteFlags = true;
				this.villageList[35971].whiteFlags = true;
				this.villageList[40877].whiteFlags = true;
				this.villageList[79880].whiteFlags = true;
				this.villageList[15606].whiteFlags = true;
				this.villageList[47150].whiteFlags = true;
				this.villageList[38968].whiteFlags = true;
				this.villageList[887].whiteFlags = true;
				this.villageList[63242].whiteFlags = true;
				this.villageList[48860].whiteFlags = true;
				this.villageList[9814].whiteFlags = true;
				this.villageList[63346].whiteFlags = true;
				this.villageList[35630].whiteFlags = true;
				this.villageList[40448].whiteFlags = true;
				this.villageList[82058].whiteFlags = true;
				this.villageList[84107].whiteFlags = true;
				this.villageList[42482].whiteFlags = true;
				this.villageList[59108].whiteFlags = true;
				this.villageList[29859].whiteFlags = true;
				this.villageList[7023].whiteFlags = true;
				this.villageList[20886].whiteFlags = true;
				this.villageList[47609].whiteFlags = true;
				this.villageList[30203].whiteFlags = true;
				this.villageList[38132].whiteFlags = true;
				this.villageList[31740].whiteFlags = true;
				this.villageList[84652].whiteFlags = true;
				this.villageList[102224].whiteFlags = true;
				this.villageList[101258].whiteFlags = true;
				this.villageList[57133].whiteFlags = true;
				this.villageList[43001].whiteFlags = true;
				this.villageList[5939].whiteFlags = true;
				this.villageList[33068].whiteFlags = true;
				this.villageList[96920].whiteFlags = true;
				this.villageList[72446].whiteFlags = true;
				this.villageList[65059].whiteFlags = true;
				this.villageList[80891].whiteFlags = true;
				this.villageList[37030].whiteFlags = true;
				this.villageList[44474].whiteFlags = true;
				this.villageList[92875].whiteFlags = true;
				this.villageList[1260].whiteFlags = true;
				this.villageList[98708].whiteFlags = true;
				this.villageList[84603].whiteFlags = true;
				this.villageList[13420].whiteFlags = true;
				this.villageList[102192].whiteFlags = true;
				this.villageList[61617].whiteFlags = true;
				this.villageList[50767].whiteFlags = true;
				this.villageList[90761].whiteFlags = true;
				this.villageList[20978].whiteFlags = true;
				this.villageList[105064].whiteFlags = true;
				this.villageList[26816].whiteFlags = true;
				this.villageList[55705].whiteFlags = true;
				this.villageList[73094].whiteFlags = true;
				this.villageList[28559].whiteFlags = true;
				this.villageList[90770].whiteFlags = true;
				this.villageList[53288].whiteFlags = true;
				this.villageList[83101].whiteFlags = true;
				this.villageList[91326].whiteFlags = true;
				this.villageList[3767].whiteFlags = true;
				this.villageList[11626].whiteFlags = true;
				this.villageList[90169].whiteFlags = true;
				this.villageList[6870].whiteFlags = true;
				this.villageList[3419].whiteFlags = true;
				this.villageList[16513].whiteFlags = true;
				this.villageList[82509].whiteFlags = true;
				this.villageList[73071].whiteFlags = true;
				this.villageList[66848].whiteFlags = true;
				this.villageList[63476].whiteFlags = true;
				this.villageList[42267].whiteFlags = true;
				this.villageList[77643].whiteFlags = true;
				this.villageList[100192].whiteFlags = true;
				this.villageList[82907].whiteFlags = true;
				this.villageList[65895].whiteFlags = true;
				this.villageList[102469].whiteFlags = true;
				this.villageList[57072].whiteFlags = true;
				this.villageList[78406].whiteFlags = true;
				this.villageList[97936].whiteFlags = true;
				this.villageList[35377].whiteFlags = true;
				this.villageList[38025].whiteFlags = true;
				this.villageList[76156].whiteFlags = true;
				this.villageList[26815].whiteFlags = true;
				this.villageList[66929].whiteFlags = true;
				this.villageList[71819].whiteFlags = true;
				this.villageList[10586].whiteFlags = true;
				this.villageList[16433].whiteFlags = true;
				this.villageList[74985].whiteFlags = true;
				this.villageList[34202].whiteFlags = true;
				this.villageList[86448].whiteFlags = true;
				this.villageList[102588].whiteFlags = true;
				this.villageList[99511].whiteFlags = true;
				this.villageList[86735].whiteFlags = true;
				this.villageList[64236].whiteFlags = true;
				this.villageList[4325].whiteFlags = true;
			}
			bool isGermany = mapData.mapName.ToLower() == "de.wmpData".ToLower();
			bool isFrance = mapData.mapName.ToLower() == "fr.wmpData".ToLower();
			bool isRussia = mapData.mapName.ToLower() == "ru.wmpData".ToLower();
			if (mapData.mapName.ToLower() == "uk2.wmpData".ToLower() || mapData.mapName.ToLower() == "ukai.wmpData".ToLower())
			{
				this.provincesList[24].parentID = 3;
			}
			if (mapData.mapName.ToLower() == "ph.wmpData".ToLower())
			{
				this.villageList[18492].x = 2263;
				this.villageList[18492].y = 1758;
				this.villageList[18492].regionID = this.villageList[63857].regionID;
				this.villageList[18492].countyID = this.villageList[63857].countyID;
			}
			this.buildVillageTree();
			this.experimentalStuff(mapData.mapName.ToLower());
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x00287EE8 File Offset: 0x002860E8
		private void fixupNames()
		{
			WorldMapType mapData = GameEngine.Instance.WorldMapTypesData.getMapData(this.currentMapType);
			if (mapData.mapName.ToLower() == "de.wmpData".ToLower())
			{
				this.fixupParishName(2288, 63395, "Milovice");
				this.fixupParishName(1251, 35200, "Cesky Krumlov");
				this.fixupParishName(2165, 60225, "Lazec");
				this.fixupParishName(886, 25428, "Samtens");
				this.fixupParishName(4145, 111386, "Bergen auf Rugen");
				this.fixupParishName(2162, 60189, "Gro? Kordshagen");
				this.fixupParishName(1855, 51571, "Gransee");
				this.fixupParishName(4027, 108332, "O?nig");
				this.fixupParishName(762, 21819, "Tietzow");
				this.fixupParishName(706, 20155, "Wustermark");
				this.fixupParishName(3065, 84108, "Spremberg");
				this.fixupParishName(2255, 62603, "Lieske");
				this.fixupParishName(1040, 29069, "Welzow");
				this.fixupParishName(2636, 72969, "Gro?raschen");
				this.fixupParishName(792, 22556, "Spremberg");
				this.fixupParishName(3588, 98158, "Lugau");
				this.fixupParishName(35, 838, "Sayda");
				this.fixupParishName(3372, 92181, "Gro?enhain");
				this.fixupParishName(1364, 38191, "Stary Materov");
				this.fixupParishName(489, 13973, "Stavenhagen");
				this.fixupParishName(1117, 31347, "Lemberg");
				this.fixupParishName(3169, 86633, "Marienbaum");
				this.fixupParishName(2350, 65035, "Geeste");
				this.fixupParishName(1002, 28093, "Lastrup");
				this.fixupParishName(3394, 92600, "Markhausen");
				this.fixupParishName(1903, 53366, "Bar?el");
				this.fixupParishName(134, 3889, "Leer");
				this.fixupParishName(700, 19945, "Dorverden");
				this.fixupParishName(3549, 97013, "Hoya");
				this.fixupParishName(81, 2493, "Struth");
				this.fixupParishName(3310, 90139, "Nackenheim");
				this.fixupParishName(3003, 82636, "Hammersbach");
				this.fixupParishName(760, 21778, "Grenderich");
				this.fixupParishName(1164, 32535, "Blankenrath");
				this.fixupParishName(1064, 29645, "Beltheim");
				this.fixupParishName(372, 10174, "Stocksee");
				this.fixupParishName(1774, 49198, "Scharbeutz");
				this.fixupParishName(1803, 50090, "Potsdam");
				this.fixupParishName(3058, 83939, "Gol?en");
				this.fixupParishName(1799, 49961, "Dahme-Spreewald");
				this.fixupParishName(1078, 30061, "Treuenbrietzen");
				this.fixupParishName(1824, 50711, "Hohenseefeld");
				this.fixupParishName(648, 18509, "Jessen");
				this.fixupParishName(624, 17930, "Sonnewalde");
				this.fixupParishName(3854, 104394, "Droy?ig");
				this.fixupParishName(2251, 62489, "Rohr");
				this.fixupParishName(2051, 57386, "Martigny");
				this.fixupParishName(958, 26999, "Amberg-Sulzbach");
				this.fixupParishName(3900, 105547, "Amberg");
				this.fixupParishName(4183, 112373, "Ebersdorf");
				this.fixupParishName(1810, 50324, "Bad Bederkesa");
				this.fixupParishName(271, 7487, "Osnabruck");
				this.fixupParishName(4042, 108662, "Furstenau");
				this.fixupParishName(4053, 108895, "Vorden");
				this.fixupParishName(1312, 36972, "Bad Holzhausen");
				this.fixupParishName(3201, 87470, "Spenge");
				this.fixupParishName(1784, 49433, "Lohne");
				this.fixupParishName(3990, 107532, "Steinegge");
				this.fixupParishName(757, 21657, "Porta Westfalica");
				this.fixupParishName(2229, 61985, "Auetal");
				this.fixupParishName(2200, 61308, "Merxhausen");
				this.fixupParishName(1880, 52315, "Schwarmstedt");
				this.fixupParishName(3066, 84109, "Bad Essen");
				this.fixupParishName(3160, 86407, "Hemke");
				this.fixupParishName(890, 25572, "Tabor");
				this.fixupParishName(4241, 113638, "Rok");
				this.fixupParishName(3093, 84820, "Bad Gandersheim");
				this.fixupParishName(253, 6915, "Dannenberg");
				this.fixupParishName(3353, 91736, "Lubbow");
				this.fixupParishName(808, 22963, "Spandau bei Berlin");
				this.countyList[6].areaName = "Braunschweig-Luneburg";
				this.provincesList[9].areaName = "Bohmen";
				this.provincesList[10].areaName = "Mahren";
			}
			if (mapData.mapName.ToLower() == "fr.wmpData".ToLower())
			{
				this.fixupParishName(3633, 105754, "Aubepine");
				this.fixupParishName(952, 28077, "Uza");
				this.fixupParishName(1778, 53102, "Fontvieille");
				this.fixupParishName(1892, 56377, "Fourques");
				this.fixupParishName(3603, 104868, "Camargue");
				this.fixupParishName(994, 29154, "La Dynamite");
				this.fixupParishName(1007, 29559, "Pioch Badet");
				this.fixupParishName(1552, 46259, "Marignane");
				this.fixupParishName(1567, 46488, "Saint-Laurent d'Aigouze");
				this.fixupParishName(3158, 92105, "Desvres");
				this.fixupParishName(928, 27252, "Diksmuide");
				this.fixupParishName(2331, 68423, "Arendonk");
				this.fixupParishName(3707, 107765, "Dessel");
				this.fixupParishName(339, 10307, "Simmerath");
				this.fixupParishName(3888, 113266, "Hachiville");
				this.fixupParishName(281, 8155, "Germingen");
				this.fixupParishName(3491, 101446, "Montreux");
				this.fixupParishName(2357, 69163, "Mouthe");
				this.fixupParishName(3621, 105473, "Moissey");
				this.fixupParishName(1156, 34122, "La Giettaz");
				this.fixupParishName(3331, 96846, "Lanslevillard");
				this.fixupParishName(2871, 84197, "Le Lautaret");
				this.fixupParishName(2412, 70382, "Le Freney-d'Oisans");
				this.fixupParishName(211, 5780, "Mont Thabor");
				this.fixupParishName(3160, 92152, "Saint-Laurent-en-Beaumont");
				this.fixupParishName(17, 404, "Orcieres");
				this.fixupParishName(2378, 69628, "La Martre");
				this.fixupParishName(3715, 108295, "Cuers");
				this.fixupParishName(2739, 80545, "Vauvenargues");
				this.fixupParishName(719, 21432, "Riez");
				this.fixupParishName(1003, 29435, "Le Liouquet");
				this.fixupParishName(3219, 93590, "Murat-sur-Vebre");
				this.fixupParishName(248, 6896, "Le Margues");
				this.fixupParishName(1865, 55509, "Sainte-Foi");
				this.fixupParishName(1259, 37483, "Saint Etienne de Baigorry");
				this.fixupParishName(952, 28077, "Levignac");
				this.fixupParishName(1934, 57380, "Contis Plage");
				this.fixupParishName(539, 16126, "Garein");
				this.fixupParishName(3169, 92380, "Sanguinet");
				this.fixupParishName(1924, 56991, "Lugos");
				this.fixupParishName(290, 8316, "Cazaux");
				this.fixupParishName(2970, 87091, "Le Pilat");
				this.fixupParishName(1436, 43119, "Lugos");
				this.fixupParishName(696, 20792, "Audenge");
				this.fixupParishName(790, 23367, "Saumos");
				this.fixupParishName(1181, 34850, "Lesparre-Medoc");
				this.fixupParishName(1455, 43735, "Trebivan");
				this.fixupParishName(3520, 102414, "Guiscriff");
				this.fixupParishName(2163, 63489, "Rosporden");
				this.fixupParishName(2255, 65775, "Plouasne");
				this.fixupParishName(575, 17435, "Villenauxe-la-Grande");
				this.fixupParishName(1515, 45219, "Nemours");
				this.fixupParishName(2754, 81141, "Charny");
				this.fixupParishName(2936, 85807, "Saint Gondon");
				this.fixupParishName(3012, 88362, "Menestreau-en-Villette");
				this.fixupParishName(3653, 106284, "La Brosse");
				this.fixupParishName(1712, 51032, "Menetreol-sur-Sauldre");
				this.fixupParishName(2084, 61426, "Saulieu");
				this.fixupParishName(2522, 73279, "Evron");
				this.fixupParishName(295, 8335, "Oudenaarde");
				this.fixupParishName(2964, 86839, "Bievre");
				this.fixupParishName(193, 5277, "Eprave");
				this.fixupParishName(2171, 63715, "Etalle");
				this.fixupParishName(405, 11986, "Paulhenc");
				this.fixupParishName(1599, 47396, "Froidchapelle");
				this.fixupParishName(1017, 29861, "Momignies");
				this.fixupParishName(3566, 103690, "Sivry-Rance");
				this.fixupParishName(843, 24899, "Bievre");
				this.fixupParishName(2048, 60392, "Jodoigne");
				this.fixupParishName(1258, 37476, "Fontenois-la-Ville");
				this.fixupParishName(614, 18330, "Ninove");
				this.fixupParishName(1535, 45754, "Landos");
				this.fixupParishName(3017, 88448, "Mallemort");
				this.fixupParishName(3897, 113669, "La Trimouille");
				this.fixupParishName(3778, 110225, "Saint-Germain-de-la-Coudre");
				this.fixupParishName(1141, 33761, "Hastiere-par-dela");
				this.fixupParishName(105, 2957, "Aragnouet");
				this.fixupParishName(2143, 62832, "Thermes Maguoac");
				this.fixupParishName(1098, 32229, "Gavarnie");
				this.fixupParishName(71, 1735, "Castelnau-Riviere-Basse");
				this.fixupParishName(2679, 78363, "Bareges");
				this.fixupParishName(2010, 59464, "Cauterets");
				this.fixupParishName(332, 9563, "Launemezan");
				this.fixupParishName(1871, 55651, "Gedre");
				this.fixupParishName(911, 26678, "Bagneres-de-Bigorre");
				this.fixupParishName(590, 17737, "Tournoy");
				this.fixupParishName(1413, 42443, "Arreau");
				this.fixupParishName(130, 3571, "Borderes-Louron");
				this.fixupParishName(1377, 41325, "Sost");
				this.fixupParishName(1198, 35405, "Sarrancolin");
				this.fixupParishName(425, 12567, "La Soula");
				this.fixupParishName(3534, 102847, "Siradan");
				this.fixupParishName(2942, 85973, "La Barthe-de-Neste");
				this.fixupParishName(2165, 63566, "Argeles-Gazost");
				this.fixupParishName(819, 24224, "Cauterets");
				this.fixupParishName(1065, 31248, "Arrens-Marsous");
				this.fixupParishName(1669, 49520, "Pouyastruc");
				this.fixupParishName(2914, 85342, "Labatut-Riviere");
				this.fixupParishName(3395, 98929, "Lafitole");
				this.fixupParishName(3227, 93882, "Trie-sur-Baise");
				this.fixupParishName(3879, 113082, "Issoudun");
				this.fixupParishName(96, 2427, "Treves");
				this.fixupParishName(2905, 85039, "Vissec");
				this.fixupParishName(2694, 79033, "Centuri");
				this.fixupParishName(1, 95, "Sainte-Lucie-de-Tallano");
				this.fixupParishName(2639, 77006, "Falzet");
				this.fixupParishName(3861, 112648, "Chezal-Benoit");
				this.fixupParishName(2655, 77607, "Le Massegros");
				this.fixupParishName(3040, 89092, "Ocquier");
				this.fixupParishName(3273, 95292, "Lourdes");
				this.fixupParishName(2754, 81141, "Fontenouilles");
				this.fixupParishName(939, 27264, "San-Gavino-di-Carbini");
				this.villageList[28533].m_villageName = "Poitiers";
			}
			bool isUK = mapData.mapName.ToLower() == "uk.wmpData".ToLower();
			if (mapData.mapName.ToLower() == "ru.wmpData".ToLower())
			{
				this.countyList[55].areaName = "�����";
				this.villageList[53871].villageName = "�������";
				this.countyList[54].areaName = "��������� �������";
			}
			if (mapData.mapName.ToLower() == "pl.wmpData".ToLower())
			{
				this.provincesList[0].areaName = "Zachodniopomorskie";
				this.provincesList[6].areaName = "Lodzkie";
			}
			if (mapData.mapName.ToLower() == "us.wmpData".ToLower())
			{
				this.fixupParishName(2166, 52241, "Niagara");
				this.fixupParishName(2698, 64654, "Juniata");
				this.fixupParishName(4336, 105829, "Barnstable");
				this.fixupParishName(2882, 69593, "Cuba");
				this.fixupParishName(1486, 35877, "Jacksonville");
				this.countyList[32].areaName = "East Kentucky";
				this.countyList[35].areaName = "South Indiana";
				this.countyList[51].areaName = "San Antonio";
			}
			if (mapData.mapName.ToLower() == "it.wmpData".ToLower())
			{
				this.countyList[112].areaName = "Osijek-Baranja";
				this.provincesList[37].areaName = "Sardegna";
				this.provincesList[7].areaName = "Toscana";
				this.fixupParishName(1505, 33173, "Krusevo");
				this.provincesList[27].areaName = "Juzna Crna Gora";
				this.provincesList[28].areaName = "Sjeverna Crna Gora";
				this.countyList[116].areaName = "Bjelovar-Bilogora";
				this.villageList[28991].villageName = "Bjelovar";
				this.fixupParishName(3157, 69460, "Fagagna");
				this.fixupParishName(1400, 30548, "Cimolais");
			}
			if (mapData.mapName.ToLower() == "eu.wmpData".ToLower() || mapData.mapName.ToLower() == "euai.wmpData".ToLower())
			{
				this.countyList[191].areaName = "Gotaland";
				this.countyList[189].areaName = "Svealand";
				this.countyList[188].areaName = "Norrland";
				this.countyList[192].areaName = "Dalarna";
				this.countyList[70].areaName = "Jylland";
				this.provincesList[30].areaName = "Region Jylland";
				this.countyList[60].areaName = "Gelre";
				this.countyList[58].areaName = "Holland";
				this.countyList[57].areaName = "Brabant";
				this.countyList[101].areaName = "Dunantul Megye";
				this.countyList[102].areaName = "Duna-Tisza Koze Megye";
				this.countyList[103].areaName = "Tiszantul Megye";
				this.countyList[187].areaName = "Lapin Laani";
				this.countyList[186].areaName = "Oulun Laani";
				this.countyList[185].areaName = "Lansi-Suomen Laani";
				this.countyList[184].areaName = "Ita-Suomen Laani";
				this.countyList[125].areaName = "������ �����";
				this.countyList[126].areaName = "������ ������ �������";
				this.countyList[127].areaName = "������ �����";
				this.countyList[129].areaName = "������ �������";
				this.countyList[176].areaName = "Harjumaa";
				this.countyList[53].areaName = "Distrito de Vila Real";
				this.provincesList[81].areaName = "Pohjois-Suomi";
				this.provincesList[80].areaName = "Etela-Suomi";
				this.countyList[124].areaName = "?????";
				this.countyList[123].areaName = "????????????";
				this.countyList[122].areaName = "?????? ??????";
				this.countyList[120].areaName = "????????";
				this.countyList[119].areaName = "???????? ?????????";
				this.countyList[121].areaName = "????????? ????????? ??? ?????";
				this.countyList[54].areaName = "Estremadura";
				this.countyList[53].areaName = "Douro";
				this.countyList[52].areaName = "Beiras";
				this.countyList[51].areaName = "Alentejo";
				this.countyList[65].areaName = "Sachsen";
				this.countyList[95].areaName = "Jihomoravsky kraj";
				this.countyList[2].areaName = "Trondelag";
				this.provincesList[10].areaName = "Eastern Ireland";
				this.fixupParishName(2932, 64799, "Builth Wells");
				this.fixupParishName(2187, 48426, "Skegness");
				this.countyList[4].areaName = "Inverness-shire";
				this.fixupParishName(4124, 93874, "Karlovy Vary");
				this.fixupParishName(26, 511, "������� �����");
				string villageName = this.villageList[55123].m_villageName;
				this.villageList[55123].m_villageName = this.villageList[31844].m_villageName;
				this.villageList[31844].m_villageName = villageName;
			}
			if (mapData.mapName.ToLower() == "wrld.wmpData".ToLower())
			{
				this.countryList[66].areaName = "Philippines";
				this.provincesList[66].areaName = "Philippines";
			}
			this.updateRegionsNamesBasedOnLanguage();
		}

		// Token: 0x0600317A RID: 12666 RVA: 0x00023D60 File Offset: 0x00021F60
		private void fixupParishName(int parishID, int villageID, string newName)
		{
			this.villageList[villageID].m_villageName = newName;
			this.regionList[parishID].areaName = newName;
		}

		// Token: 0x0600317B RID: 12667 RVA: 0x002894E0 File Offset: 0x002876E0
		private WorldMap.Triangle makeTriangle(WorldMap.WorldPoint p1, WorldMap.WorldPoint p2, WorldMap.WorldPoint p3)
		{
			return new WorldMap.Triangle
			{
				x1 = p1.x,
				y1 = p1.y,
				x2 = p2.x,
				y2 = p2.y,
				x3 = p3.x,
				y3 = p3.y
			};
		}

		// Token: 0x0600317C RID: 12668 RVA: 0x0028953C File Offset: 0x0028773C
		public void loadData(string dataName)
		{
			this.drawFakeProvinceBorders = false;
			this.EUMap = false;
			this.GSMap = false;
			this.KGMap = false;
			this.yMarkerOffset = 0;
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			this.chMap = false;
			this.mapDataFilename = dataName;
			if (dataName.ToLower() == "de.wmpData".ToLower())
			{
				flag5 = true;
			}
			if (dataName.ToLower() == "sa.wmpData".ToLower())
			{
				this.yMarkerOffset = -10;
			}
			if (dataName.ToLower() == "uk.wmpData".ToLower())
			{
				flag = true;
			}
			if (dataName.ToLower() == "ukai.wmpData".ToLower())
			{
				flag6 = true;
			}
			if (dataName.ToLower() == "uk2.wmpData".ToLower())
			{
				flag2 = true;
			}
			if (dataName.ToLower() == "fr.wmpData".ToLower())
			{
				num = 1;
				flag3 = true;
			}
			if (dataName.ToLower() == "es.wmpData".ToLower())
			{
				num = 1;
				flag4 = true;
			}
			this.smallMapFont = false;
			if (dataName.ToLower() == "eu.wmpData".ToLower() || dataName.ToLower() == "wrld.wmpData".ToLower() || dataName.ToLower() == "ch.wmpData".ToLower())
			{
				this.smallMapFont = true;
				this.EUMap = true;
				if (dataName.ToLower() == "ch.wmpData".ToLower())
				{
					this.chMap = true;
				}
			}
			if (dataName.ToLower() == "wrld.wmpData".ToLower())
			{
				this.GSMap = true;
			}
			if (dataName.ToLower() == "euai.wmpData".ToLower())
			{
				this.smallMapFont = true;
				this.EUMap = true;
				flag7 = true;
			}
			if (dataName.ToLower() == "king.wmpData".ToLower())
			{
				this.KGMap = true;
				this.smallMapFont = true;
				this.EUMap = true;
			}
			dataName = Application.StartupPath + "\\assets\\" + dataName;
			FileStream fileStream = new FileStream(dataName, FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			this.LoadLocalisedParishNamesFromFiles();
			int num2 = binaryReader.ReadInt32();
			for (int i = 0; i < num2; i++)
			{
				binaryReader.ReadString();
			}
			int num3 = binaryReader.ReadInt32();
			int[] array = new int[num3];
			for (int j = 0; j < num3; j++)
			{
				array[j] = binaryReader.ReadInt32();
			}
			binaryReader.Close();
			fileStream.Close();
			int num4 = 0;
			this.worldMapWidth = array[num4++];
			this.worldMapHeight = array[num4++];
			this.villageMapWidth = array[num4++];
			this.villageMapHeight = array[num4++];
			int num5 = array[num4++];
			this.pointList = new WorldMap.WorldPoint[num5 + num];
			for (int k = 0; k < num5; k++)
			{
				WorldMap.WorldPoint worldPoint = new WorldMap.WorldPoint();
				worldPoint.x = (float)array[num4++];
				worldPoint.y = (float)array[num4++];
				this.pointList[k] = worldPoint;
			}
			if (flag3)
			{
				WorldMap.WorldPoint worldPoint2 = new WorldMap.WorldPoint();
				worldPoint2.x = 1885f;
				worldPoint2.y = 2204f;
				this.pointList[num5] = worldPoint2;
			}
			int num6 = array[num4++];
			this.countryList = new WorldMap.WorldPointList[num6];
			for (int l = 0; l < num6; l++)
			{
				WorldMap.WorldPointList worldPointList = new WorldMap.WorldPointList();
				worldPointList.parentID = array[num4++];
				worldPointList.capitalVillage = array[num4++];
				int x = array[num4++];
				int y = array[num4++];
				worldPointList.marker = new Point(x, y);
				num4++;
				int num7 = array[num4++];
				worldPointList.borderList = new int[num7];
				for (int m = 0; m < num7; m++)
				{
					worldPointList.borderList[m] = array[num4++];
					worldPointList.updateBounds(this.pointList[worldPointList.borderList[m]]);
				}
				int num8 = array[num4++];
				worldPointList.childList = new int[num8];
				for (int n = 0; n < num8; n++)
				{
					worldPointList.childList[n] = array[num4++];
				}
				int num9 = array[num4++];
				worldPointList.triangleList = new WorldMap.Triangle[num9];
				for (int num10 = 0; num10 < num9; num10++)
				{
					WorldMap.Triangle triangle = new WorldMap.Triangle();
					triangle.x1 = (float)array[num4++] / 10000f;
					triangle.y1 = (float)array[num4++] / 10000f;
					triangle.x2 = (float)array[num4++] / 10000f;
					triangle.y2 = (float)array[num4++] / 10000f;
					triangle.x3 = (float)array[num4++] / 10000f;
					triangle.y3 = (float)array[num4++] / 10000f;
					worldPointList.triangleList[num10] = triangle;
				}
				this.countryList[l] = worldPointList;
			}
			int num11 = array[num4++];
			this.provincesList = new WorldMap.WorldPointList[num11];
			for (int num12 = 0; num12 < num11; num12++)
			{
				WorldMap.WorldPointList worldPointList2 = new WorldMap.WorldPointList();
				worldPointList2.parentID = array[num4++];
				worldPointList2.capitalVillage = array[num4++];
				int x2 = array[num4++];
				int y2 = array[num4++];
				worldPointList2.marker = new Point(x2, y2);
				num4++;
				int num13 = array[num4++];
				worldPointList2.borderList = new int[num13];
				for (int num14 = 0; num14 < num13; num14++)
				{
					worldPointList2.borderList[num14] = array[num4++];
					worldPointList2.updateBounds(this.pointList[worldPointList2.borderList[num14]]);
				}
				int num15 = array[num4++];
				worldPointList2.childList = new int[num15];
				for (int num16 = 0; num16 < num15; num16++)
				{
					worldPointList2.childList[num16] = array[num4++];
				}
				int num17 = array[num4++];
				worldPointList2.triangleList = new WorldMap.Triangle[num17];
				for (int num18 = 0; num18 < num17; num18++)
				{
					WorldMap.Triangle triangle2 = new WorldMap.Triangle();
					triangle2.x1 = (float)array[num4++] / 10000f;
					triangle2.y1 = (float)array[num4++] / 10000f;
					triangle2.x2 = (float)array[num4++] / 10000f;
					triangle2.y2 = (float)array[num4++] / 10000f;
					triangle2.x3 = (float)array[num4++] / 10000f;
					triangle2.y3 = (float)array[num4++] / 10000f;
					worldPointList2.triangleList[num18] = triangle2;
				}
				this.provincesList[num12] = worldPointList2;
			}
			int num19 = array[num4++];
			this.countyList = new WorldMap.WorldPointList[num19];
			for (int num20 = 0; num20 < num19; num20++)
			{
				WorldMap.WorldPointList worldPointList3 = new WorldMap.WorldPointList();
				worldPointList3.parentID = array[num4++];
				worldPointList3.capitalVillage = array[num4++];
				int x3 = array[num4++];
				int y3 = array[num4++];
				worldPointList3.marker = new Point(x3, y3);
				num4++;
				int num21 = array[num4++];
				worldPointList3.borderList = new int[num21];
				for (int num22 = 0; num22 < num21; num22++)
				{
					worldPointList3.borderList[num22] = array[num4++];
					worldPointList3.updateBounds(this.pointList[worldPointList3.borderList[num22]]);
				}
				int num23 = array[num4++];
				worldPointList3.childList = new int[num23];
				for (int num24 = 0; num24 < num23; num24++)
				{
					worldPointList3.childList[num24] = array[num4++];
				}
				int num25 = array[num4++];
				worldPointList3.triangleList = new WorldMap.Triangle[num25];
				for (int num26 = 0; num26 < num25; num26++)
				{
					WorldMap.Triangle triangle3 = new WorldMap.Triangle();
					triangle3.x1 = (float)array[num4++] / 10000f;
					triangle3.y1 = (float)array[num4++] / 10000f;
					triangle3.x2 = (float)array[num4++] / 10000f;
					triangle3.y2 = (float)array[num4++] / 10000f;
					triangle3.x3 = (float)array[num4++] / 10000f;
					triangle3.y3 = (float)array[num4++] / 10000f;
					worldPointList3.triangleList[num26] = triangle3;
				}
				this.countyList[num20] = worldPointList3;
			}
			int num27 = array[num4++];
			this.villageList = new VillageData[num27];
			for (int num28 = 0; num28 < num27; num28++)
			{
				VillageData villageData = new VillageData();
				villageData.id = array[num4++];
				villageData.x = (short)array[num4++];
				villageData.y = (short)array[num4++];
				if (num28 == 94886 && flag5)
				{
					VillageData villageData2 = villageData;
					villageData2.y -= 1;
				}
				villageData.countyID = (short)array[num4++];
				villageData.regionID = (short)array[num4++];
				int num29 = array[num4++];
				if ((num29 & 1) != 0)
				{
					villageData.regionCapital = true;
				}
				else
				{
					villageData.regionCapital = false;
				}
				if ((num29 & 8) != 0)
				{
					villageData.countyCapital = true;
				}
				else
				{
					villageData.countyCapital = false;
				}
				if ((num29 & 16) != 0)
				{
					villageData.provinceCapital = true;
				}
				else
				{
					villageData.provinceCapital = false;
				}
				if ((num29 & 32) != 0)
				{
					villageData.countryCapital = true;
				}
				else
				{
					villageData.countryCapital = false;
				}
				this.villageList[num28] = villageData;
				num4++;
			}
			int num30 = array[num4++];
			this.regionList = new WorldMap.WorldPointList[num30];
			for (int num31 = 0; num31 < num30; num31++)
			{
				WorldMap.WorldPointList worldPointList4 = new WorldMap.WorldPointList();
				worldPointList4.parentID = array[num4++];
				num4++;
				int num32 = array[num4++];
				worldPointList4.childList = new int[num32];
				for (int num33 = 0; num33 < num32; num33++)
				{
					worldPointList4.childList[num33] = array[num4++];
				}
				int num34 = array[num4++];
				worldPointList4.triangleList = new WorldMap.Triangle[num34];
				for (int num35 = 0; num35 < num34; num35++)
				{
					WorldMap.Triangle triangle4 = new WorldMap.Triangle();
					triangle4.x1 = (float)array[num4++] / 10000f;
					triangle4.y1 = (float)array[num4++] / 10000f;
					triangle4.x2 = (float)array[num4++] / 10000f;
					triangle4.y2 = (float)array[num4++] / 10000f;
					triangle4.x3 = (float)array[num4++] / 10000f;
					triangle4.y3 = (float)array[num4++] / 10000f;
					worldPointList4.triangleList[num35] = triangle4;
				}
				worldPointList4.updateBoundsFromTriangles();
				int num36 = array[num4++];
				worldPointList4.regionBorderList = new WorldMap.WorldPoint[num36];
				for (int num37 = 0; num37 < num36; num37++)
				{
					WorldMap.WorldPoint worldPoint3 = new WorldMap.WorldPoint();
					worldPoint3.x = (float)array[num4++];
					worldPoint3.y = (float)array[num4++];
					worldPointList4.regionBorderList[num37] = worldPoint3;
				}
				this.regionList[num31] = worldPointList4;
			}
			VillageData[] array2 = this.villageList;
			foreach (VillageData villageData3 in array2)
			{
				if (villageData3.regionCapital)
				{
					this.regionList[(int)villageData3.regionID].capitalVillage = villageData3.id;
				}
			}
			int num39 = array[num4++];
			List<WorldMap.WorldPointList> list = new List<WorldMap.WorldPointList>();
			for (int num40 = 0; num40 < num39; num40++)
			{
				WorldMap.WorldPointList worldPointList5 = new WorldMap.WorldPointList();
				worldPointList5.data = array[num4++];
				if (worldPointList5.data >= 0)
				{
					int num41 = array[num4++];
					worldPointList5.triangleList = new WorldMap.Triangle[num41];
					for (int num42 = 0; num42 < num41; num42++)
					{
						WorldMap.Triangle triangle5 = new WorldMap.Triangle();
						triangle5.x1 = (float)array[num4++] / 10000f;
						triangle5.y1 = (float)array[num4++] / 10000f;
						triangle5.x2 = (float)array[num4++] / 10000f;
						triangle5.y2 = (float)array[num4++] / 10000f;
						triangle5.x3 = (float)array[num4++] / 10000f;
						triangle5.y3 = (float)array[num4++] / 10000f;
						worldPointList5.triangleList[num42] = triangle5;
					}
					worldPointList5.updateBoundsFromTriangles();
					list.Add(worldPointList5);
				}
				else
				{
					this.drawFakeProvinceBorders = true;
					if (worldPointList5.data > -2000)
					{
						int num43 = -worldPointList5.data - 1000;
						WorldMap.WorldPointList worldPointList6 = this.provincesList[num43];
						List<int> list2 = new List<int>();
						if (!worldPointList6.rebuiltBorderList)
						{
							worldPointList6.rebuiltBorderList = true;
						}
						list2.AddRange(worldPointList6.borderList);
						list2.Add(-1);
						int num44 = array[num4++];
						for (int num45 = 0; num45 < num44; num45++)
						{
							int num46 = array[num4++];
							list2.Add(num46);
							worldPointList6.updateBounds(this.pointList[num46]);
						}
						worldPointList6.borderList = list2.ToArray();
						int num47 = array[num4++];
						List<WorldMap.Triangle> list3 = new List<WorldMap.Triangle>();
						list3.AddRange(worldPointList6.triangleList);
						for (int num48 = 0; num48 < num47; num48++)
						{
							list3.Add(new WorldMap.Triangle
							{
								x1 = (float)array[num4++] / 10000f,
								y1 = (float)array[num4++] / 10000f,
								x2 = (float)array[num4++] / 10000f,
								y2 = (float)array[num4++] / 10000f,
								x3 = (float)array[num4++] / 10000f,
								y3 = (float)array[num4++] / 10000f
							});
						}
						worldPointList6.triangleList = list3.ToArray();
					}
					else
					{
						int num49 = -worldPointList5.data - 3000;
						WorldMap.WorldPointList worldPointList7 = this.countryList[num49];
						List<int> list4 = new List<int>();
						if (!worldPointList7.rebuiltBorderList)
						{
							worldPointList7.rebuiltBorderList = true;
						}
						list4.AddRange(worldPointList7.borderList);
						list4.Add(-1);
						int num50 = array[num4++];
						for (int num51 = 0; num51 < num50; num51++)
						{
							int num52 = array[num4++];
							list4.Add(num52);
							worldPointList7.updateBounds(this.pointList[num52]);
						}
						worldPointList7.borderList = list4.ToArray();
						int num53 = array[num4++];
						List<WorldMap.Triangle> list5 = new List<WorldMap.Triangle>();
						list5.AddRange(worldPointList7.triangleList);
						for (int num54 = 0; num54 < num53; num54++)
						{
							list5.Add(new WorldMap.Triangle
							{
								x1 = (float)array[num4++] / 10000f,
								y1 = (float)array[num4++] / 10000f,
								x2 = (float)array[num4++] / 10000f,
								y2 = (float)array[num4++] / 10000f,
								x3 = (float)array[num4++] / 10000f,
								y3 = (float)array[num4++] / 10000f
							});
						}
						worldPointList7.triangleList = list5.ToArray();
					}
				}
			}
			this.seaList = list.ToArray();
			int num55 = array[num4++];
			this.islandList = new WorldMap.IslandInfoList[num55];
			for (int num56 = 0; num56 < num55; num56++)
			{
				WorldMap.IslandInfoList islandInfoList = new WorldMap.IslandInfoList();
				islandInfoList.county = array[num4++];
				islandInfoList.province = array[num4++];
				islandInfoList.country = array[num4++];
				islandInfoList.sx = array[num4++];
				islandInfoList.sy = array[num4++];
				islandInfoList.ex = array[num4++];
				islandInfoList.ey = array[num4++];
				this.islandList[num56] = islandInfoList;
			}
			if (flag)
			{
				this.villageList[42538].x = 1255;
				this.villageList[42538].y = 1044;
				this.villageList[22358].x = 1078;
				this.villageList[22358].y = 525;
				this.villageList[73093].x = 1060;
				this.villageList[73093].y = 528;
				this.villageList[49242].x = 1081;
				this.villageList[49242].y = 533;
				this.villageList[77800].x = 1070;
				this.villageList[77800].y = 529;
				this.villageList[69149].x = 1041;
				this.villageList[69149].y = 545;
				this.villageList[49042].x = 614;
				this.villageList[49042].y = 2070;
				this.villageList[55962].x = 1527;
				this.villageList[55962].y = 1303;
				this.villageList[98865].x = 1532;
				this.villageList[98865].y = 1298;
				this.villageList[65073].x = 978;
				this.villageList[65073].y = 950;
				this.villageList[19033].x = 1120;
				this.villageList[19033].y = 867;
				this.villageList[38352].x = 1115;
				this.villageList[38352].y = 874;
			}
			if (flag || flag2 || flag6)
			{
				this.villageList[69936].x = 1826;
				this.villageList[69936].y = 2747;
			}
			if (flag5)
			{
				this.villageList[8650].x = 1701;
				this.villageList[8650].y = 2637;
			}
			if (flag4)
			{
				this.villageList[59419].x = 1452;
				this.villageList[59419].y = 1396;
				this.villageList[26428].x = 1466;
				this.villageList[26428].y = 1275;
				this.villageList[32451].x = 1450;
				this.villageList[32451].y = 1269;
			}
			this.aiWorldTreeBuilding = false;
			this.aiWorldInvasionLineList = null;
			this.aiWorldSpecialVillages.Clear();
			if (flag6 || flag7)
			{
				this.aiWorldTreeBuilding = true;
				this.aiWorldInvasionLineList = new List<WorldMap.IslandInfoList>();
				array2 = this.villageList;
				foreach (VillageData villageData4 in array2)
				{
					int x4 = (int)villageData4.x;
					int y4 = (int)villageData4.y;
					int x5 = (int)villageData4.x;
					int y5 = (int)villageData4.y;
					if (AIWorldSettings.getAIWorldVillageLocation(villageData4.id, ref x5, ref y5, flag7))
					{
						villageData4.x = (short)x5;
						villageData4.y = (short)y5;
						WorldMap.IslandInfoList islandInfoList2 = new WorldMap.IslandInfoList();
						islandInfoList2.villageID = villageData4.id;
						double num58 = (double)x4;
						double num59 = (double)y4;
						double num60 = (double)villageData4.x;
						double num61 = (double)villageData4.y;
						double num62 = num58 - num60;
						double num63 = num59 - num61;
						double num64 = Math.Sqrt(num62 * num62 + num63 * num63);
						num62 /= num64;
						num63 /= num64;
						num58 -= num62 * 50.0;
						num59 -= num63 * 50.0;
						num60 += num62 * 25.0;
						num61 += num63 * 25.0;
						islandInfoList2.sx = (int)num58;
						islandInfoList2.sy = (int)num59;
						islandInfoList2.ex = (int)num60;
						islandInfoList2.ey = (int)num61;
						this.aiWorldInvasionLineList.Add(islandInfoList2);
						this.aiWorldSpecialVillages.Add(villageData4.id);
					}
				}
			}
			this.initUserVillages();
		}

		// Token: 0x0600317D RID: 12669 RVA: 0x0028AB90 File Offset: 0x00288D90
		public void buildVillageTree()
		{
			this.m_baseNode = new WorldMap.VillageQuadNode(0, 0, this.villageMapWidth, this.villageMapHeight, 0);
			this.m_baseNode.setWorld(this);
			VillageData[] array = this.villageList;
			foreach (VillageData village in array)
			{
				this.m_baseNode.addVillage(village, 0);
			}
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level0Nodes.ToString() + " level 0 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level1Nodes.ToString() + " level 1 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level2Nodes.ToString() + " level 2 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level3Nodes.ToString() + " level 3 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level4Nodes.ToString() + " level 4 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level5Nodes.ToString() + " level 5 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level6Nodes.ToString() + " level 6 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level7Nodes.ToString() + " level 7 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level8Nodes.ToString() + " level 8 nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.level9Nodes.ToString() + " level 9 nodes");
			UniversalDebugLog.Log(this.villageList.Length.ToString() + " villages in total. " + WorldMap.VillageQuadNode.villagesInNodes.ToString() + " in nodes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.parishesInNodes.ToString() + " parishes");
			UniversalDebugLog.Log(WorldMap.VillageQuadNode.capitalsInNodes.ToString() + " capitals");
			this.WorldZoom = 4.0;
			this.m_screenCentreX = (double)this.worldMapWidth / 2.0;
			this.m_screenCentreY = (double)this.worldMapHeight / 2.0;
		}

		// Token: 0x0600317E RID: 12670 RVA: 0x0028AD84 File Offset: 0x00288F84
		public void loadLocalWorldData()
		{
			this.m_factionData.Clear();
			this.m_downloadedDataSafely = true;
			if (!this.m_cachesFlushed)
			{
				this.m_dataLoaded = this.loadFactionData();
				this.m_namesLoaded = this.loadNamesData();
				UniversalDebugLog.Log("m_dataLoaded = " + this.m_dataLoaded.ToString());
				UniversalDebugLog.Log("m_namesLoaded = " + this.m_namesLoaded.ToString());
				int num = 0;
				int num2 = 0;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.villageName.Length == 0)
					{
						num++;
					}
					if (villageData.visible)
					{
						num2++;
					}
				}
				if (num > 500 || num2 < 2)
				{
					this.m_dataLoaded = false;
					this.m_namesLoaded = false;
					return;
				}
			}
			else
			{
				this.m_cachesFlushed = false;
				this.m_dataLoaded = false;
				this.m_namesLoaded = false;
			}
		}

		// Token: 0x0600317F RID: 12671 RVA: 0x00023D7E File Offset: 0x00021F7E
		public void invalidateWorldData()
		{
			this.m_dataLoaded = false;
			this.loginHistory = null;
			this.m_userVillages = null;
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x00023D95 File Offset: 0x00021F95
		public void flushCaches()
		{
			this.m_cachesFlushed = true;
		}

		// Token: 0x06003181 RID: 12673 RVA: 0x0028AE70 File Offset: 0x00289070
		public void updateWorldMapOwnership()
		{
			GameEngine.Instance.World.clearPersonArray(-1);
			this.downloadingCounter = 0;
			this.downloadComplete = false;
			this.downloadFullyComplete = false;
			this.delayedFactionSave = false;
			this.m_WorkerThread = new Thread(new ThreadStart(this.updateWorldMapOwnershipX));
			this.m_WorkerThread.Name = "Downloading";
			this.m_WorkerThread.Start();
		}

		// Token: 0x06003182 RID: 12674 RVA: 0x00023D9E File Offset: 0x00021F9E
		public bool isDownloadComplete()
		{
			return this.downloadComplete;
		}

		// Token: 0x06003183 RID: 12675 RVA: 0x00023DA6 File Offset: 0x00021FA6
		public bool isDownloadFullyComplete()
		{
			return this.downloadFullyComplete;
		}

		// Token: 0x06003184 RID: 12676 RVA: 0x00023DAE File Offset: 0x00021FAE
		public bool isWorkerThreadAlive()
		{
			return this.m_WorkerThread != null && this.m_WorkerThread.IsAlive;
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x0028AEDC File Offset: 0x002890DC
		private void downloadWait()
		{
			Thread.Sleep(this.threadDelaySize);
			DateTime now = DateTime.Now;
			while (!RemoteServices.Instance.queueEmpty())
			{
				Thread.Sleep(20);
				if (GameEngine.Instance.loginCancelled())
				{
					this.m_WorkerThread.Abort();
				}
				DateTime now2 = DateTime.Now;
				if ((now2 - now).TotalMinutes > 10.0)
				{
					break;
				}
			}
			if (GameEngine.Instance.loginCancelled())
			{
				this.m_WorkerThread.Abort();
			}
			if (!this.loadingErrored)
			{
				this.downloadingCounter++;
			}
			else
			{
				Thread.Sleep(2000 + new Random().Next(1000));
			}
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void maybeMultiAccount(int level)
		{
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x0028AF9C File Offset: 0x0028919C
		public void updateWorldMapOwnershipX()
		{
			RemoteServices.Instance.set_FullTick_UserCallBack(new RemoteServices.FullTick_UserCallBack(this.fullTickCallBack));
			this.requestedReturnedArmyIDs.Clear();
			GameEngine.Instance.setPendingSessionExpiredStat(-1);
			if (!this.m_namesLoaded)
			{
				this.storedVillageNamePos = -1L;
			}
			int num = 0;
			do
			{
				this.loadingErrored = false;
				RemoteServices.Instance.set_GetVillageNames_UserCallBack(new RemoteServices.GetVillageNames_UserCallBack(this.villageNamesCallBack));
				RemoteServices.Instance.GetVillageNames(this.storedVillageNamePos);
				this.downloadWait();
			}
			while ((this.loadingErrored || !RemoteServices.Instance.GetVillageNames_ValidDownload) && num++ < 3);
			if (this.loadingErrored || !RemoteServices.Instance.GetVillageNames_ValidDownload)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.retrieveUserVillages(true);
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			if (!this.m_dataLoaded)
			{
				this.storedRegionFactionsPos = -1L;
				this.storedCountyFactionsPos = -1L;
				this.storedProvinceFactionsPos = -1L;
				this.storedVillageFactionsPos = -1L;
				this.storedCountryFactionsPos = -1L;
				this.storedFactionChangesPos = -1L;
				this.storedParishFlagsPos = -1L;
				this.storedCountyFlagsPos = -1L;
				this.storedProvinceFlagsPos = -1L;
				this.storedCountryFlagsPos = -1L;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					villageData.numFlags = 0;
				}
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				RemoteServices.Instance.set_GetAreaFactionChanges_UserCallBack(new RemoteServices.GetAreaFactionChanges_UserCallBack(this.getAreaFactionChangesCallback));
				RemoteServices.Instance.GetAreaFactionChanges(this.storedRegionFactionsPos - 50L, this.storedCountyFactionsPos - 10L, this.storedProvinceFactionsPos - 10L, this.storedCountryFactionsPos - 5L, this.storedParishFlagsPos, this.storedCountyFlagsPos, this.storedProvinceFlagsPos, this.storedCountryFlagsPos);
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			if (this.m_dataLoaded)
			{
				num = 0;
				do
				{
					this.loadingErrored = false;
					RemoteServices.Instance.set_GetVillageFactionChanges_UserCallBack(new RemoteServices.GetVillageFactionChanges_UserCallBack(this.getVillageFactionChangesCallback));
					RemoteServices.Instance.GetVillageFactionChanges(this.storedVillageFactionsPos - 500L, this.storedFactionChangesPos - 10L);
					this.downloadWait();
				}
				while ((this.loadingErrored || !RemoteServices.Instance.GetVillageFactionChanges_ValidDownload) && num++ < 3);
				if (this.loadingErrored || !RemoteServices.Instance.GetVillageFactionChanges_ValidDownload)
				{
					GameEngine.Instance.setPendingSessionExpiredStat(2);
					return;
				}
			}
			else
			{
				num = 0;
				do
				{
					this.loadingErrored = false;
					RemoteServices.Instance.set_GetAllVillageOwnerFactions_UserCallBack(new RemoteServices.GetAllVillageOwnerFactions_UserCallBack(this.getAllVillageOwnerFactionsCallback));
					RemoteServices.Instance.GetAllVillageOwnerFactions();
					this.downloadWait();
				}
				while ((this.loadingErrored || !RemoteServices.Instance.GetAllVillageOwnerFactions_ValidDownload) && num++ < 3);
				if (this.loadingErrored || !RemoteServices.Instance.GetAllVillageOwnerFactions_ValidDownload)
				{
					GameEngine.Instance.setPendingSessionExpiredStat(2);
					return;
				}
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.retrieveArmies();
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.getTraderData();
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.getActiveTraders();
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.getPersonData();
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			num = 0;
			do
			{
				this.loadingErrored = false;
				this.getActivePeople();
				this.downloadWait();
			}
			while (this.loadingErrored && num++ < 3);
			if (this.loadingErrored)
			{
				GameEngine.Instance.setPendingSessionExpiredStat(2);
				return;
			}
			InterfaceMgr.Instance.downCurrentFactionInfo();
			this.downloadWait();
			List<AchievementData> achievementData = null;
			List<int> achievementsToTest = this.getAchievementsToTest(ref achievementData);
			if (achievementsToTest != null && achievementsToTest.Count > 0)
			{
				num = 0;
				do
				{
					this.loadingErrored = false;
					this.inTestAchievements = false;
					this.testAchievements(achievementsToTest, achievementData, true);
					this.downloadWait();
				}
				while (this.loadingErrored && num++ < 3);
				if (this.loadingErrored)
				{
					GameEngine.Instance.setPendingSessionExpiredStat(2);
					return;
				}
			}
			this.fixupNames();
			this.downloadComplete = true;
			this.downloadFullyComplete = true;
			GC.Collect();
			GC.WaitForPendingFinalizers();
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.downloadAIInvasionInfo();
			}
			this.delayedFactionSave = true;
		}

		// Token: 0x06003188 RID: 12680 RVA: 0x0028B464 File Offset: 0x00289664
		public void villageNamesCallBack(GetVillageNames_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				if (returnData.villageNames != null)
				{
					int num = 0;
					foreach (string text in returnData.villageNames)
					{
						if (num < this.villageList.Length)
						{
							if (text.Length == 0)
							{
								this.villageList[num++].villageName = "Village:" + (num - 1).ToString();
							}
							else
							{
								this.villageList[num++].villageName = text;
							}
						}
					}
				}
				if (returnData.regionNames != null)
				{
					int num2 = 0;
					foreach (string areaName in returnData.regionNames)
					{
						if (num2 < this.regionList.Length)
						{
							this.regionList[num2++].areaName = areaName;
						}
					}
				}
				if (returnData.countyNames != null)
				{
					int num3 = 0;
					foreach (string areaName2 in returnData.countyNames)
					{
						if (num3 < this.countyList.Length)
						{
							this.countyList[num3++].areaName = areaName2;
						}
					}
				}
				if (returnData.provinceNames != null)
				{
					int num4 = 0;
					foreach (string areaName3 in returnData.provinceNames)
					{
						if (num4 < this.provincesList.Length)
						{
							this.provincesList[num4++].areaName = areaName3;
						}
					}
				}
				if (returnData.countryNames != null)
				{
					int num5 = 0;
					foreach (string areaName4 in returnData.countryNames)
					{
						if (num5 < this.countryList.Length)
						{
							this.countryList[num5++].areaName = areaName4;
						}
					}
				}
				if (returnData.villageChangedNames != null)
				{
					this.changeVillageNames(returnData.villageChangedNames);
				}
				this.storedVillageNamePos = returnData.currentVillageNameChangePos;
				for (int i = 0; i < returnData.worldMapCachedData.Length; i++)
				{
					if (i < this.villageList.Length && this.villageList[i] != null)
					{
						this.villageList[i].villageInfo = returnData.worldMapCachedData[i];
					}
				}
				this.saveNamesData();
				VillageMap.setServerTime(returnData.currentTime);
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				GameEngine.Instance.World.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				GameEngine.Instance.World.setPoints(returnData.currentPoints);
				return;
			}
			this.loadingErrored = true;
			this.m_downloadedDataSafely = false;
		}

		// Token: 0x06003189 RID: 12681 RVA: 0x0028B7A8 File Offset: 0x002899A8
		public void changeVillageNames(List<NameUpdateListItem> newNames)
		{
			if (newNames != null)
			{
				foreach (NameUpdateListItem nameUpdateListItem in newNames)
				{
					if (nameUpdateListItem.areaID < this.villageList.Length && nameUpdateListItem.areaID >= 0)
					{
						this.villageList[nameUpdateListItem.areaID].villageName = nameUpdateListItem.newName;
					}
				}
			}
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x00023DC5 File Offset: 0x00021FC5
		private void GetKillStreakDataCallback(GetKillStreakData_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.KillStreakTimer = returnData.killStreakExpiry;
				this.KillStreakCount = returnData.killStreakCount;
				this.KillStreakPoints = returnData.killStreakPoints;
			}
		}

		// Token: 0x0600318B RID: 12683 RVA: 0x0028B824 File Offset: 0x00289A24
		public void getVillageFactionChangesCallback(GetVillageFactionChanges_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				if (returnData.villageUpdateList != null)
				{
					this.processVillageFactionChangesList(returnData.villageUpdateList, returnData.currentVillageChangePos);
				}
				else if (returnData.villageOwnerFactions != null)
				{
					this.processVillageFactionList(returnData.villageOwnerFactions, returnData.currentVillageChangePos);
				}
				if (returnData.factionsList != null)
				{
					this.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
					return;
				}
			}
			else
			{
				this.loadingErrored = true;
				this.m_downloadedDataSafely = false;
			}
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x0028B8A0 File Offset: 0x00289AA0
		public void getAllVillageOwnerFactionsCallback(GetAllVillageOwnerFactions_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.processVillageFactionList(returnData.villageOwnerFactions, returnData.currentVillageChangePos);
				if (returnData.factionsList != null)
				{
					this.m_factionData.Clear();
					this.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
					return;
				}
			}
			else
			{
				this.loadingErrored = true;
				this.m_downloadedDataSafely = false;
			}
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x0028B904 File Offset: 0x00289B04
		public void processVillageFactionList(int[,] ownerList, long newPos)
		{
			int num = 0;
			int num2 = 0;
			if (ownerList.GetUpperBound(1) == 5)
			{
				for (int i = 0; i < ownerList.Length / 6; i++)
				{
					this.villageList[num].factionID = ownerList[i, 0];
					this.villageList[num].userID = ownerList[i, 1];
					if (ownerList[i, 2] == 1)
					{
						this.villageList[num].visible = true;
						num2++;
					}
					else
					{
						this.villageList[num].visible = false;
					}
					this.villageList[num].connecter = ownerList[i, 3];
					this.villageList[num].special = ownerList[i, 4];
					this.villageList[num].villageTerrain = (short)ownerList[i, 5];
					if (this.villageList[num].special == 20)
					{
						this.villageList[num].visible = false;
					}
					this.villageList[num].rolloverInfo = null;
					num++;
				}
			}
			else
			{
				int num3 = 0;
				while (num3 < ownerList.Length / 6 && num < this.villageList.Length)
				{
					this.villageList[num].factionID = ownerList[0, num3];
					this.villageList[num].userID = ownerList[1, num3];
					if (ownerList[2, num3] == 1)
					{
						this.villageList[num].visible = true;
						num2++;
					}
					else
					{
						this.villageList[num].visible = false;
					}
					this.villageList[num].connecter = ownerList[3, num3];
					this.villageList[num].special = ownerList[4, num3];
					this.villageList[num].villageTerrain = (short)ownerList[5, num3];
					if (this.villageList[num].special == 20)
					{
						this.villageList[num].visible = false;
					}
					this.villageList[num].rolloverInfo = null;
					num++;
					num3++;
				}
			}
			this.updateUserVassals();
			if (num2 > 2)
			{
				this.storedVillageFactionsPos = newPos;
			}
			else
			{
				this.storedVillageFactionsPos = -1L;
			}
			if (ownerList.Length > 0)
			{
				this.fixupVisibleParishCapitals();
			}
		}

		// Token: 0x0600318E RID: 12686 RVA: 0x0028BB24 File Offset: 0x00289D24
		public void processVillageFactionChangesList(AreaUpdateListItem[] ownerList, long newPos)
		{
			int num = 0;
			bool flag = false;
			foreach (AreaUpdateListItem areaUpdateListItem in ownerList)
			{
				if (areaUpdateListItem != null && areaUpdateListItem.areaID >= 0)
				{
					if (areaUpdateListItem.areaID < this.villageList.Length)
					{
						if ((this.villageList[areaUpdateListItem.areaID].userID == RemoteServices.Instance.UserID || areaUpdateListItem.newOwnerID == RemoteServices.Instance.UserID) && this.villageList[areaUpdateListItem.areaID].userID != areaUpdateListItem.newOwnerID)
						{
							flag = true;
						}
						this.villageList[areaUpdateListItem.areaID].factionID = areaUpdateListItem.newFactionID;
						this.villageList[areaUpdateListItem.areaID].userID = areaUpdateListItem.newOwnerID;
						this.villageList[areaUpdateListItem.areaID].visible = true;
						this.villageList[areaUpdateListItem.areaID].connecter = areaUpdateListItem.connectorID;
						if (areaUpdateListItem.special != -1)
						{
							this.villageList[areaUpdateListItem.areaID].special = areaUpdateListItem.special;
						}
						if (areaUpdateListItem.mapTerrain >= 0)
						{
							this.villageList[areaUpdateListItem.areaID].villageTerrain = (short)areaUpdateListItem.mapTerrain;
						}
						if (areaUpdateListItem.special == 2 || areaUpdateListItem.special == -1 || areaUpdateListItem.special == 20)
						{
							this.villageList[areaUpdateListItem.areaID].visible = false;
						}
						this.villageList[areaUpdateListItem.areaID].rolloverInfo = null;
					}
				}
				else
				{
					num++;
				}
			}
			if ((long)ownerList.Length < newPos - this.storedVillageFactionsPos || num > 1)
			{
				num = 100;
			}
			if (num >= 0)
			{
				this.storedVillageFactionsPos = newPos;
				this.updateUserVassals();
				if (flag)
				{
					this.retrieveUserVillages(false);
				}
			}
			if (ownerList.Length != 0)
			{
				this.fixupVisibleParishCapitals();
			}
		}

		// Token: 0x0600318F RID: 12687 RVA: 0x0028BCFC File Offset: 0x00289EFC
		public void processFactionsList(List<FactionData> factionsList, long currentFactionChangePos)
		{
			foreach (FactionData factionData in factionsList)
			{
				this.m_factionData[factionData.factionID] = factionData;
			}
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				foreach (object obj in this.m_factionData)
				{
					FactionData factionData2 = (FactionData)obj;
					if (factionData2.factionID >= 1 && factionData2.factionID <= 4)
					{
						if (!GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld || factionData2.factionID != 4)
						{
							factionData2.numMembers = 1;
						}
						factionData2.openForApplications = false;
						if (factionData2.factionID == 4)
						{
							factionData2.houseRank = 10;
						}
						switch (factionData2.factionID)
						{
						case 1:
							factionData2.flagData = 951615895;
							break;
						case 2:
							factionData2.flagData = 941629576;
							break;
						case 3:
							factionData2.flagData = 946006923;
							break;
						case 4:
							factionData2.flagData = 941809835;
							break;
						}
					}
				}
			}
			this.inactiveFaction.active = false;
			int num = -1;
			foreach (object obj2 in this.m_factionData)
			{
				FactionData factionData3 = (FactionData)obj2;
				if (factionData3.factionID > num)
				{
					num = factionData3.factionID;
				}
			}
			for (int i = 0; i <= num; i++)
			{
				if (this.m_factionData[i] == null)
				{
					this.m_factionData[i] = this.inactiveFaction;
				}
			}
			this.storedFactionChangesPos = currentFactionChangePos;
		}

		// Token: 0x06003190 RID: 12688 RVA: 0x0028BF08 File Offset: 0x0028A108
		public void getVillageRankTaxTreeCallback(GetVillageRankTaxTree_ReturnType returnData)
		{
			if (returnData.Success)
			{
				for (int i = 0; i < returnData.villageConnecters.Length; i++)
				{
					this.villageList[i].connecter = returnData.villageConnecters[i];
				}
				this.updateUserVassals();
				VillageMap.setServerTime(returnData.currentTime);
				GameEngine.Instance.World.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				GameEngine.Instance.World.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
			}
		}

		// Token: 0x06003191 RID: 12689 RVA: 0x0028BF8C File Offset: 0x0028A18C
		public bool isVassal(int yourVillage, int potentialVassalVillage)
		{
			if (potentialVassalVillage >= 0 && potentialVassalVillage < this.villageList.Length)
			{
				int connecter = this.villageList[potentialVassalVillage].connecter;
				if (connecter == yourVillage)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003192 RID: 12690 RVA: 0x00023DF3 File Offset: 0x00021FF3
		public void breakVassal(int lordVillage, int vassalVillage)
		{
			this.villageList[vassalVillage].connecter = -1;
		}

		// Token: 0x06003193 RID: 12691 RVA: 0x0028BFC0 File Offset: 0x0028A1C0
		public void fixupVisibleParishCapitals()
		{
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				if (villageData.visible && !villageData.Capital)
				{
					int regionID = (int)villageData.regionID;
					if (regionID >= 0)
					{
						this.villageList[this.regionList[regionID].capitalVillage].visible = true;
					}
				}
			}
		}

		// Token: 0x06003194 RID: 12692 RVA: 0x0028C020 File Offset: 0x0028A220
		public void doFullTick(bool registerSession, int mode)
		{
			if ((DateTime.Now - this.lastFullTickCall).TotalSeconds >= 10.0)
			{
				this.lastFullTickCall = DateTime.Now;
				RemoteServices.Instance.FullTick(this.storedVillageFactionsPos, this.storedRegionFactionsPos, this.storedCountyFactionsPos, this.storedProvinceFactionsPos, this.storedCountryFactionsPos, registerSession, this.storedVillageNamePos, this.storedFactionChangesPos, this.lastTraderTime, this.lastPersonTime, this.storedParishFlagsPos, this.storedCountyFlagsPos, this.storedProvinceFlagsPos, this.storedCountryFlagsPos, this.highestDownloadedArmy, mode, WorldMap.fullTickFullMode || mode > 1);
				WorldMap.fullTickFullMode = !WorldMap.fullTickFullMode;
			}
		}

		// Token: 0x06003195 RID: 12693 RVA: 0x0028C0DC File Offset: 0x0028A2DC
		public void fullTickCallBack(FullTick_ReturnType returnData)
		{
			if (InterfaceMgr.Instance.getCardWindow() != null)
			{
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.getCardWindow());
			}
			if (returnData.Success)
			{
				if (DX.ControlForm != null)
				{
					DX.ControlForm.Log(LNG.Print("World Map Refreshed"), ControlForm.Tab.Main, false);
					DX.ControlForm.LastWorldMapUpdate = DateTime.Now;
				}
				if (returnData.villageUpdateList != null)
				{
					this.processVillageFactionChangesList(returnData.villageUpdateList, returnData.currentVillageChangePos);
				}
				else if (returnData.villageOwnerFactions != null)
				{
					this.processVillageFactionList(returnData.villageOwnerFactions, returnData.currentVillageChangePos);
				}
				this.updateRegionFactions(returnData.regionUpdateList, returnData.regionFactions, returnData.currentRegionChangePos);
				this.updateCountyFactions(returnData.countyUpdateList, returnData.countyFactions, returnData.currentCountyChangePos);
				this.updateProvinceFactions(returnData.provinceUpdateList, returnData.provinceFactions, returnData.currentProvinceChangePos);
				this.updateCountryFactions(returnData.countryUpdateList, returnData.countryFactions, returnData.currentCountryChangePos);
				if (returnData.userCapitals != null)
				{
					this.updateUserCapitals(returnData.userCapitals);
				}
				if (returnData.villageChangedNames != null)
				{
					this.changeVillageNames(returnData.villageChangedNames);
				}
				if (returnData.factionsList != null)
				{
					this.processFactionsList(returnData.factionsList, returnData.currentFactionChangePos);
				}
				if (returnData.parishFlagChanges != null)
				{
					this.updateParishFlags(returnData.parishFlagChanges, returnData.currentParishFlagPos);
				}
				if (returnData.countyFlagChanges != null)
				{
					this.updateCountyFlags(returnData.countyFlagChanges, returnData.currentCountyFlagPos);
				}
				if (returnData.provinceFlagChanges != null)
				{
					this.updateProvinceFlags(returnData.provinceFlagChanges, returnData.currentProvinceFlagPos);
				}
				if (returnData.countryFlagChanges != null)
				{
					this.updateCountryFlags(returnData.countryFlagChanges, returnData.currentCountryFlagPos);
				}
				this.storedVillageNamePos = returnData.currentVillageNameChangePos;
				if (returnData.armyDataReturn != null)
				{
					returnData.armyDataReturn.SetAsSucceeded();
					this.getArmyData(returnData.armyDataReturn);
				}
				this.highestArmySeen = returnData.armyHighestSeen;
				if (returnData.changedTraders != null && returnData.changedTraders.Count > 0)
				{
					this.importOrphanedTraders(returnData.changedTraders, returnData.currentTime, -2);
					this.lastTraderTime = returnData.currentTime;
				}
				if (returnData.people != null && returnData.people.Count > 0)
				{
					this.importOrphanedPeople(returnData.people, returnData.currentTime, -2);
					this.lastPersonTime = returnData.currentTime;
				}
				this.setGoldData(returnData.currentGoldLevel, returnData.currentGoldRate);
				this.setHonourData(returnData.currentHonourLevel, returnData.currentHonourRate);
				this.setFaithPointsData(returnData.currentFaithPointsLevel, returnData.currentFaithPointsRate);
				this.setPoints(returnData.currentPoints);
				this.setNumMadeCaptains(returnData.numMadeCaptains);
				this.m_mostAge4Villages = returnData.mostAge4Villages;
				GameEngine.Instance.setServerDownTime(returnData.serverDowntime);
				this.setTickets(0, returnData.wheel_Treasure1Tickets);
				this.setTickets(1, returnData.wheel_Treasure2Tickets);
				this.setTickets(2, returnData.wheel_Treasure3Tickets);
				this.setTickets(3, returnData.wheel_Treasure4Tickets);
				this.setTickets(4, returnData.wheel_Treasure5Tickets);
				if (returnData.m_cardData != null)
				{
					GameEngine.Instance.cardsManager.UserCardData = returnData.m_cardData;
				}
				if (returnData.achievements != null)
				{
					InterfaceMgr.Instance.processAchievements(returnData.achievements);
				}
				if (returnData.m_newQuestsData != null)
				{
					this.setNewQuestData(returnData.m_newQuestsData);
				}
				if (!this.isIslandWorld())
				{
					WorldMap.TreasureCastle_AttackGap = returnData.m_treasureCastle_AttackGap;
					return;
				}
				this.SpecialSeaConditionsData = returnData.m_treasureCastle_AttackGap;
				WorldMap.TreasureCastle_AttackGap = 86400;
			}
		}

		// Token: 0x06003196 RID: 12694 RVA: 0x0028C440 File Offset: 0x0028A640
		public void getAreaFactionChangesCallback(GetAreaFactionChanges_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.updateRegionFactions(returnData.regionUpdateList, returnData.regionFactions, returnData.currentRegionChangePos);
				this.updateCountyFactions(returnData.countyUpdateList, returnData.countyFactions, returnData.currentCountyChangePos);
				this.updateProvinceFactions(returnData.provinceUpdateList, returnData.provinceFactions, returnData.currentProvinceChangePos);
				this.updateCountryFactions(returnData.countryUpdateList, returnData.countryFactions, returnData.currentCountryChangePos);
				this.updateParishFlags(returnData.parishFlagChanges, returnData.currentParishFlagPos);
				this.updateCountyFlags(returnData.countyFlagChanges, returnData.currentCountyFlagPos);
				this.updateProvinceFlags(returnData.provinceFlagChanges, returnData.currentProvinceFlagPos);
				this.updateCountryFlags(returnData.countryFlagChanges, returnData.currentCountryFlagPos);
				return;
			}
			this.loadingErrored = true;
			this.m_downloadedDataSafely = false;
		}

		// Token: 0x06003197 RID: 12695 RVA: 0x0028C518 File Offset: 0x0028A718
		private void updateParishFlags(List<CapitalFlagChangeInfo> parishFlagChanges, long parishFlagChangePos)
		{
			this.storedParishFlagsPos = parishFlagChangePos;
			foreach (CapitalFlagChangeInfo capitalFlagChangeInfo in parishFlagChanges)
			{
				if (capitalFlagChangeInfo.areaID >= 0)
				{
					int areaID = capitalFlagChangeInfo.areaID;
					if (areaID < this.regionList.Length)
					{
						int capitalVillage = this.regionList[areaID].capitalVillage;
						if (capitalVillage >= 0)
						{
							this.villageList[capitalVillage].numFlags = (short)capitalFlagChangeInfo.numFlags;
						}
					}
				}
			}
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x0028C5A8 File Offset: 0x0028A7A8
		private void updateCountyFlags(List<CapitalFlagChangeInfo> countyFlagChanges, long countyFlagChangePos)
		{
			this.storedCountyFlagsPos = countyFlagChangePos;
			foreach (CapitalFlagChangeInfo capitalFlagChangeInfo in countyFlagChanges)
			{
				if (capitalFlagChangeInfo.areaID >= 0)
				{
					int areaID = capitalFlagChangeInfo.areaID;
					if (areaID < this.countyList.Length)
					{
						int capitalVillage = this.countyList[areaID].capitalVillage;
						if (capitalVillage >= 0)
						{
							this.villageList[capitalVillage].numFlags = (short)capitalFlagChangeInfo.numFlags;
						}
					}
				}
			}
		}

		// Token: 0x06003199 RID: 12697 RVA: 0x0028C638 File Offset: 0x0028A838
		private void updateProvinceFlags(List<CapitalFlagChangeInfo> provinceFlagChanges, long provinceFlagChangePos)
		{
			this.storedProvinceFlagsPos = provinceFlagChangePos;
			foreach (CapitalFlagChangeInfo capitalFlagChangeInfo in provinceFlagChanges)
			{
				if (capitalFlagChangeInfo.areaID >= 0)
				{
					int areaID = capitalFlagChangeInfo.areaID;
					if (areaID < this.provincesList.Length)
					{
						int capitalVillage = this.provincesList[areaID].capitalVillage;
						if (capitalVillage >= 0)
						{
							this.villageList[capitalVillage].numFlags = (short)capitalFlagChangeInfo.numFlags;
						}
					}
				}
			}
		}

		// Token: 0x0600319A RID: 12698 RVA: 0x0028C6C8 File Offset: 0x0028A8C8
		private void updateCountryFlags(List<CapitalFlagChangeInfo> countryFlagChanges, long countryFlagChangePos)
		{
			this.storedCountryFlagsPos = countryFlagChangePos;
			foreach (CapitalFlagChangeInfo capitalFlagChangeInfo in countryFlagChanges)
			{
				if (capitalFlagChangeInfo.areaID >= 0)
				{
					int areaID = capitalFlagChangeInfo.areaID;
					if (areaID < this.countryList.Length)
					{
						int capitalVillage = this.countryList[areaID].capitalVillage;
						if (capitalVillage >= 0)
						{
							this.villageList[capitalVillage].numFlags = (short)capitalFlagChangeInfo.numFlags;
						}
					}
				}
			}
		}

		// Token: 0x0600319B RID: 12699 RVA: 0x0028C758 File Offset: 0x0028A958
		private void updateRegionFactions(AreaUpdateListItem[] regionUpdateList, int[,] regionFactions, long currentRegionChangePos)
		{
			if (regionUpdateList != null)
			{
				foreach (AreaUpdateListItem areaUpdateListItem in regionUpdateList)
				{
					if (areaUpdateListItem != null && areaUpdateListItem.areaID < this.regionList.Length)
					{
						this.regionList[areaUpdateListItem.areaID].factionID = areaUpdateListItem.newFactionID;
						this.regionList[areaUpdateListItem.areaID].plague = areaUpdateListItem.special;
					}
				}
			}
			else if (regionFactions != null)
			{
				int num = 0;
				for (int j = 0; j < regionFactions.Length / 3; j++)
				{
					if (num < this.regionList.Length)
					{
						this.regionList[num].factionID = regionFactions[j, 0];
						this.regionList[num].userID = regionFactions[j, 1];
						this.regionList[num++].plague = regionFactions[j, 2];
					}
				}
			}
			this.storedRegionFactionsPos = currentRegionChangePos;
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x0028C838 File Offset: 0x0028AA38
		private void updateCountyFactions(AreaUpdateListItem[] countyUpdateList, int[,] countyFactions, long currentCountyChangePos)
		{
			if (countyUpdateList != null)
			{
				foreach (AreaUpdateListItem areaUpdateListItem in countyUpdateList)
				{
					if (areaUpdateListItem != null && areaUpdateListItem.areaID < this.countyList.Length)
					{
						this.countyList[areaUpdateListItem.areaID].factionID = areaUpdateListItem.newFactionID;
					}
				}
			}
			else if (countyFactions != null)
			{
				int num = 0;
				for (int j = 0; j < countyFactions.Length / 2; j++)
				{
					if (num < this.countyList.Length)
					{
						this.countyList[num].factionID = countyFactions[j, 0];
						this.countyList[num++].userID = countyFactions[j, 1];
					}
				}
			}
			this.storedCountyFactionsPos = currentCountyChangePos;
		}

		// Token: 0x0600319D RID: 12701 RVA: 0x0028C8E8 File Offset: 0x0028AAE8
		private void updateProvinceFactions(AreaUpdateListItem[] provinceUpdateList, int[,] provinceFactions, long currentProvinceChangePos)
		{
			if (provinceUpdateList != null)
			{
				foreach (AreaUpdateListItem areaUpdateListItem in provinceUpdateList)
				{
					if (areaUpdateListItem != null && areaUpdateListItem.areaID < this.provincesList.Length)
					{
						this.provincesList[areaUpdateListItem.areaID].factionID = areaUpdateListItem.newFactionID;
					}
				}
			}
			else if (provinceFactions != null)
			{
				int num = 0;
				for (int j = 0; j < provinceFactions.Length / 2; j++)
				{
					if (num < this.provincesList.Length)
					{
						this.provincesList[num].factionID = provinceFactions[j, 0];
						this.provincesList[num++].userID = provinceFactions[j, 1];
					}
				}
			}
			this.storedProvinceFactionsPos = currentProvinceChangePos;
		}

		// Token: 0x0600319E RID: 12702 RVA: 0x0028C998 File Offset: 0x0028AB98
		private void updateCountryFactions(AreaUpdateListItem[] countryUpdateList, int[,] countryFactions, long currentCountryChangePos)
		{
			if (countryUpdateList != null)
			{
				foreach (AreaUpdateListItem areaUpdateListItem in countryUpdateList)
				{
					if (areaUpdateListItem != null && areaUpdateListItem.areaID < this.countryList.Length)
					{
						this.countryList[areaUpdateListItem.areaID].factionID = areaUpdateListItem.newFactionID;
					}
				}
			}
			else if (countryFactions != null)
			{
				int num = 0;
				for (int j = 0; j < countryFactions.Length / 2; j++)
				{
					if (num < this.countryList.Length)
					{
						this.countryList[num].factionID = countryFactions[j, 0];
						this.countryList[num++].userID = countryFactions[j, 1];
					}
				}
			}
			this.storedCountryFactionsPos = currentCountryChangePos;
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x0028CA48 File Offset: 0x0028AC48
		public void saveFactionData()
		{
			if (this.m_downloadedDataSafely)
			{
				string settingsPath = GameEngine.getSettingsPath(true);
				try
				{
					FileInfo fileInfo = new FileInfo(settingsPath + "\\VillageData" + this.m_globalWorldID.ToString() + ".dat");
					fileInfo.IsReadOnly = false;
				}
				catch (Exception ex)
				{
					UniversalDebugLog.Log("Exception in saveFactionData " + ex.Message);
				}
				try
				{
					FileStream fileStream = new FileStream(settingsPath + "\\VillageData" + this.m_globalWorldID.ToString() + ".dat", FileMode.Create);
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					byte[] buffer = RemoteServices.Instance.WorldGUID.ToByteArray();
					int value = 10;
					binaryWriter.Write(value);
					binaryWriter.Write(buffer, 0, 16);
					binaryWriter.Write(this.storedVillageFactionsPos);
					for (int i = 0; i < this.villageList.Length; i++)
					{
						binaryWriter.Write(this.villageList[i].factionID);
						binaryWriter.Write(this.villageList[i].userID);
						binaryWriter.Write(this.villageList[i].connecter);
						binaryWriter.Write(this.villageList[i].special);
						binaryWriter.Write((int)this.villageList[i].villageTerrain);
						binaryWriter.Write((int)this.villageList[i].numFlags);
					}
					binaryWriter.Write(this.storedRegionFactionsPos);
					binaryWriter.Write(this.storedParishFlagsPos);
					binaryWriter.Write(this.storedCountyFlagsPos);
					binaryWriter.Write(this.storedProvinceFlagsPos);
					binaryWriter.Write(this.storedCountryFlagsPos);
					for (int j = 0; j < this.regionList.Length; j++)
					{
						binaryWriter.Write(this.regionList[j].factionID);
						binaryWriter.Write(this.regionList[j].userID);
						binaryWriter.Write(this.regionList[j].plague);
					}
					binaryWriter.Write(this.storedCountyFactionsPos);
					for (int k = 0; k < this.countyList.Length; k++)
					{
						binaryWriter.Write(this.countyList[k].factionID);
						binaryWriter.Write(this.countyList[k].userID);
					}
					binaryWriter.Write(this.storedProvinceFactionsPos);
					for (int l = 0; l < this.provincesList.Length; l++)
					{
						binaryWriter.Write(this.provincesList[l].factionID);
						binaryWriter.Write(this.provincesList[l].userID);
					}
					binaryWriter.Write(this.storedCountryFactionsPos);
					for (int m = 0; m < this.countryList.Length; m++)
					{
						binaryWriter.Write(this.countryList[m].factionID);
						binaryWriter.Write(this.countryList[m].userID);
					}
					for (int n = 0; n < this.villageList.Length; n++)
					{
						binaryWriter.Write(this.villageList[n].visible);
					}
					binaryWriter.Write(this.storedFactionChangesPos);
					int num = 0;
					foreach (object obj in this.m_factionData)
					{
						FactionData factionData = (FactionData)obj;
						num++;
					}
					binaryWriter.Write(num);
					foreach (object obj2 in this.m_factionData)
					{
						FactionData factionData2 = (FactionData)obj2;
						binaryWriter.Write(factionData2.factionID);
						binaryWriter.Write(factionData2.active);
						binaryWriter.Write(factionData2.factionName);
						binaryWriter.Write(factionData2.factionNameAbrv);
						binaryWriter.Write(factionData2.houseID);
						binaryWriter.Write(factionData2.numMembers);
						binaryWriter.Write(factionData2.points);
						binaryWriter.Write(factionData2.flagData);
						binaryWriter.Write(factionData2.openForApplications);
					}
					binaryWriter.Close();
					fileStream.Close();
				}
				catch (Exception ex2)
				{
					MyMessageBox.Show(SK.Text("WorldMapLoader_DataSaveError_Text", "A problem occurred saving 'VillageData.data'") + "\n\n" + ex2.ToString(), SK.Text("WorldMapLoader_DataSaveError_Header", "Data Save Error"));
				}
			}
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x0028CF20 File Offset: 0x0028B120
		public bool loadFactionData()
		{
			string settingsPath = GameEngine.getSettingsPath(false);
			FileStream fileStream = null;
			BinaryReader binaryReader = null;
			try
			{
				fileStream = new FileStream(settingsPath + "\\VillageData" + this.m_globalWorldID.ToString() + ".dat", FileMode.Open, FileAccess.Read);
				binaryReader = new BinaryReader(fileStream);
				int num = binaryReader.ReadInt32();
				if (num != 10)
				{
					binaryReader.Close();
					fileStream.Close();
					return false;
				}
				byte[] b = new byte[16];
				b = binaryReader.ReadBytes(16);
				Guid value = new Guid(b);
				if (RemoteServices.Instance.WorldGUID.CompareTo(value) != 0)
				{
					binaryReader.Close();
					fileStream.Close();
					return false;
				}
				this.storedVillageFactionsPos = binaryReader.ReadInt64();
				for (int i = 0; i < this.villageList.Length; i++)
				{
					this.villageList[i].factionID = binaryReader.ReadInt32();
					this.villageList[i].userID = binaryReader.ReadInt32();
					this.villageList[i].connecter = binaryReader.ReadInt32();
					this.villageList[i].special = binaryReader.ReadInt32();
					this.villageList[i].villageTerrain = (short)binaryReader.ReadInt32();
					this.villageList[i].numFlags = (short)binaryReader.ReadInt32();
				}
				this.storedRegionFactionsPos = binaryReader.ReadInt64();
				this.storedParishFlagsPos = binaryReader.ReadInt64();
				this.storedCountyFlagsPos = binaryReader.ReadInt64();
				this.storedProvinceFlagsPos = binaryReader.ReadInt64();
				this.storedCountryFlagsPos = binaryReader.ReadInt64();
				for (int j = 0; j < this.regionList.Length; j++)
				{
					this.regionList[j].factionID = binaryReader.ReadInt32();
					this.regionList[j].userID = binaryReader.ReadInt32();
					this.regionList[j].plague = binaryReader.ReadInt32();
				}
				this.storedCountyFactionsPos = binaryReader.ReadInt64();
				for (int k = 0; k < this.countyList.Length; k++)
				{
					this.countyList[k].factionID = binaryReader.ReadInt32();
					this.countyList[k].userID = binaryReader.ReadInt32();
				}
				this.storedProvinceFactionsPos = binaryReader.ReadInt64();
				for (int l = 0; l < this.provincesList.Length; l++)
				{
					this.provincesList[l].factionID = binaryReader.ReadInt32();
					this.provincesList[l].userID = binaryReader.ReadInt32();
				}
				this.storedCountryFactionsPos = binaryReader.ReadInt64();
				for (int m = 0; m < this.countryList.Length; m++)
				{
					this.countryList[m].factionID = binaryReader.ReadInt32();
					this.countryList[m].userID = binaryReader.ReadInt32();
				}
				for (int n = 0; n < this.villageList.Length; n++)
				{
					this.villageList[n].visible = binaryReader.ReadBoolean();
				}
				this.storedFactionChangesPos = binaryReader.ReadInt64();
				int num2 = binaryReader.ReadInt32();
				for (int num3 = 0; num3 < num2; num3++)
				{
					FactionData factionData = new FactionData();
					factionData.factionID = binaryReader.ReadInt32();
					factionData.active = binaryReader.ReadBoolean();
					factionData.factionName = binaryReader.ReadString();
					factionData.factionNameAbrv = binaryReader.ReadString();
					factionData.houseID = binaryReader.ReadInt32();
					factionData.numMembers = binaryReader.ReadInt32();
					factionData.points = binaryReader.ReadInt32();
					factionData.flagData = binaryReader.ReadInt32();
					factionData.openForApplications = binaryReader.ReadBoolean();
					this.m_factionData[factionData.factionID] = factionData;
				}
				binaryReader.Close();
				fileStream.Close();
			}
			catch (Exception)
			{
				try
				{
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				return false;
			}
			return true;
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x0028D344 File Offset: 0x0028B544
		public void saveNamesData()
		{
			if (!this.MapEditing)
			{
				string settingsPath = GameEngine.getSettingsPath(true);
				try
				{
					FileInfo fileInfo = new FileInfo(settingsPath + "\\NameData" + this.m_globalWorldID.ToString() + ".dat");
					fileInfo.IsReadOnly = false;
				}
				catch (Exception)
				{
				}
				try
				{
					FileStream fileStream = new FileStream(settingsPath + "\\NameData" + this.m_globalWorldID.ToString() + ".dat", FileMode.Create);
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					byte[] buffer = RemoteServices.Instance.WorldGUID.ToByteArray();
					binaryWriter.Write(buffer, 0, 16);
					binaryWriter.Write(this.storedVillageNamePos);
					int num = 0;
					for (int i = 0; i < this.villageList.Length; i++)
					{
						binaryWriter.Write(this.villageList[i].m_villageName);
						num ^= this.villageList[i].m_villageName.GetHashCode();
					}
					for (int j = 0; j < this.regionList.Length; j++)
					{
						binaryWriter.Write(this.regionList[j].areaName);
						num ^= this.regionList[j].areaName.GetHashCode();
					}
					for (int k = 0; k < this.countyList.Length; k++)
					{
						binaryWriter.Write(this.countyList[k].areaName);
						num ^= this.countyList[k].areaName.GetHashCode();
					}
					for (int l = 0; l < this.provincesList.Length; l++)
					{
						binaryWriter.Write(this.provincesList[l].areaName);
						num ^= this.provincesList[l].areaName.GetHashCode();
					}
					for (int m = 0; m < this.countryList.Length; m++)
					{
						binaryWriter.Write(this.countryList[m].areaName);
						num ^= this.countryList[m].areaName.GetHashCode();
					}
					binaryWriter.Write(num);
					binaryWriter.Close();
					fileStream.Close();
				}
				catch (Exception ex)
				{
					MyMessageBox.Show(SK.Text("WorldMapLoader_NameSaveError_Text", "A problem occurred saving 'NameData.data'") + "\n\n" + ex.ToString(), SK.Text("WorldMapLoader_DataSaveError_Header", "Data Save Error"));
				}
			}
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x0028D5BC File Offset: 0x0028B7BC
		public bool loadNamesData()
		{
			string settingsPath = GameEngine.getSettingsPath(false);
			FileStream fileStream = null;
			BinaryReader binaryReader = null;
			try
			{
				fileStream = new FileStream(settingsPath + "\\NameData" + this.m_globalWorldID.ToString() + ".dat", FileMode.Open, FileAccess.Read);
				binaryReader = new BinaryReader(fileStream);
				byte[] b = new byte[16];
				b = binaryReader.ReadBytes(16);
				Guid value = new Guid(b);
				if (RemoteServices.Instance.WorldGUID.CompareTo(value) != 0)
				{
					binaryReader.Close();
					fileStream.Close();
					return false;
				}
				bool flag = false;
				this.storedVillageNamePos = binaryReader.ReadInt64();
				int num = 0;
				for (int i = 0; i < this.villageList.Length; i++)
				{
					this.villageList[i].villageName = binaryReader.ReadString();
					num ^= this.villageList[i].m_villageName.GetHashCode();
				}
				for (int j = 0; j < this.regionList.Length; j++)
				{
					this.regionList[j].areaName = binaryReader.ReadString();
					num ^= this.regionList[j].areaName.GetHashCode();
					if (this.regionList[j].areaName.Length == 0)
					{
						flag = true;
					}
				}
				for (int k = 0; k < this.countyList.Length; k++)
				{
					this.countyList[k].areaName = binaryReader.ReadString();
					num ^= this.countyList[k].areaName.GetHashCode();
				}
				for (int l = 0; l < this.provincesList.Length; l++)
				{
					this.provincesList[l].areaName = binaryReader.ReadString();
					num ^= this.provincesList[l].areaName.GetHashCode();
				}
				for (int m = 0; m < this.countryList.Length; m++)
				{
					this.countryList[m].areaName = binaryReader.ReadString();
					num ^= this.countryList[m].areaName.GetHashCode();
				}
				int num2 = binaryReader.ReadInt32();
				binaryReader.Close();
				fileStream.Close();
				if (num2 != num)
				{
					return false;
				}
				if (flag)
				{
					return false;
				}
			}
			catch (Exception)
			{
				try
				{
					if (binaryReader != null)
					{
						binaryReader.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
					if (fileStream != null)
					{
						fileStream.Close();
					}
				}
				catch (Exception)
				{
				}
				return false;
			}
			return true;
		}

		// Token: 0x060031A3 RID: 12707 RVA: 0x00007CE0 File Offset: 0x00005EE0
		private void loadInitParishText()
		{
		}

		// Token: 0x060031A4 RID: 12708 RVA: 0x0028D858 File Offset: 0x0028BA58
		public void resetParishTextReadID()
		{
			foreach (object obj in this.m_parishChatLog)
			{
				WorldMap.ParishChatData parishChatData = (WorldMap.ParishChatData)obj;
				parishChatData.m_readIDs[0] = -1L;
				parishChatData.m_readIDs[1] = -1L;
				parishChatData.m_readIDs[2] = -1L;
				parishChatData.m_readIDs[3] = -1L;
				parishChatData.m_readIDs[4] = -1L;
				parishChatData.m_readIDs[5] = -1L;
			}
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x0028D8E8 File Offset: 0x0028BAE8
		public DateTime getParishChatNewestPostTime(int parishID, DateTime allowedMinTime)
		{
			DateTime dateTime = DateTime.MinValue;
			if (this.m_parishChatLog[parishID] != null)
			{
				WorldMap.ParishChatData parishChatData = (WorldMap.ParishChatData)this.m_parishChatLog[parishID];
				dateTime = parishChatData.m_newestPost;
			}
			else
			{
				dateTime = VillageMap.getCurrentServerTime().AddDays(-30.0);
			}
			if (dateTime < allowedMinTime)
			{
				dateTime = allowedMinTime;
			}
			if (dateTime == DateTime.MaxValue && RemoteServices.Instance.Admin)
			{
				dateTime = DateTime.Now.AddDays(-30.0);
			}
			return dateTime;
		}

		// Token: 0x060031A6 RID: 12710 RVA: 0x0028D978 File Offset: 0x0028BB78
		public List<Chat_TextEntry> getParishChat(int parishID, int subForum, DateTime minTime)
		{
			if (minTime == DateTime.MaxValue && RemoteServices.Instance.Admin)
			{
				minTime = DateTime.MinValue;
			}
			if (this.m_parishChatLog[parishID] == null)
			{
				return new List<Chat_TextEntry>();
			}
			WorldMap.ParishChatData parishChatData = (WorldMap.ParishChatData)this.m_parishChatLog[parishID];
			List<Chat_TextEntry> chatPage = parishChatData.getChatPage(subForum);
			if (chatPage == null)
			{
				return new List<Chat_TextEntry>();
			}
			List<Chat_TextEntry> list = new List<Chat_TextEntry>();
			foreach (Chat_TextEntry chat_TextEntry in chatPage)
			{
				if (chat_TextEntry.postedTime >= minTime)
				{
					list.Add(chat_TextEntry);
				}
			}
			if (list.Count > 100)
			{
				List<Chat_TextEntry> list2 = new List<Chat_TextEntry>();
				for (int i = list.Count - 100; i < list.Count; i++)
				{
					list2.Add(list[i]);
				}
				list2.Sort(this.parishChatComparer);
				return list2;
			}
			list.Sort(this.parishChatComparer);
			return list;
		}

		// Token: 0x060031A7 RID: 12711 RVA: 0x0028DA90 File Offset: 0x0028BC90
		public List<Chat_TextEntry> addParishChat(int parishID, List<Chat_TextEntry> newText)
		{
			if (newText == null || newText.Count == 0)
			{
				return null;
			}
			if (this.m_parishChatLog[parishID] == null)
			{
				WorldMap.ParishChatData parishChatData = new WorldMap.ParishChatData();
				parishChatData.init();
				this.m_parishChatLog[parishID] = parishChatData;
			}
			WorldMap.ParishChatData parishChatData2 = (WorldMap.ParishChatData)this.m_parishChatLog[parishID];
			List<Chat_TextEntry> list = new List<Chat_TextEntry>();
			foreach (Chat_TextEntry chat_TextEntry in newText)
			{
				if (parishChatData2.addEntry(chat_TextEntry))
				{
					list.Add(chat_TextEntry);
				}
			}
			return list;
		}

		// Token: 0x060031A8 RID: 12712 RVA: 0x0028DB38 File Offset: 0x0028BD38
		public int[] setReadIDs(int parishID, long[] readIDs)
		{
			int[] array = new int[6];
			if (this.m_parishChatLog[parishID] == null)
			{
				return array;
			}
			WorldMap.ParishChatData parishChatData = (WorldMap.ParishChatData)this.m_parishChatLog[parishID];
			parishChatData.setReadIDs(readIDs);
			for (int i = 0; i < 6; i++)
			{
				array[i] = 0;
				bool flag = false;
				long readID = parishChatData.getReadID(i);
				foreach (Chat_TextEntry chat_TextEntry in parishChatData.m_pages[i])
				{
					if (chat_TextEntry.textID > readID)
					{
						flag = true;
					}
					if (flag)
					{
						array[i]++;
					}
				}
			}
			return array;
		}

		// Token: 0x060031A9 RID: 12713 RVA: 0x0028DBF0 File Offset: 0x0028BDF0
		public long getHighestReadID(int parishID, int pageID)
		{
			if (this.m_parishChatLog[parishID] == null)
			{
				return -1L;
			}
			WorldMap.ParishChatData parishChatData = (WorldMap.ParishChatData)this.m_parishChatLog[parishID];
			List<Chat_TextEntry> list = parishChatData.m_pages[pageID];
			if (list.Count > 0)
			{
				long num = -1L;
				foreach (Chat_TextEntry chat_TextEntry in list)
				{
					if (chat_TextEntry.textID > num)
					{
						num = chat_TextEntry.textID;
					}
				}
				return num;
			}
			return -1L;
		}

		// Token: 0x060031AA RID: 12714 RVA: 0x00023E03 File Offset: 0x00022003
		public void clearParishChat()
		{
			this.m_parishChatLog = new SparseArray();
			this.m_parishWallDonateDetails = new SparseArray();
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x0028DC88 File Offset: 0x0028BE88
		public void registerParishWallDonateDetails(ParishWallDetailInfo_ReturnType returnData)
		{
			int parishCapitalID = returnData.parishCapitalID;
			int userID = returnData.userID;
			WorldMap.ParishWallDonateInfo parishWallDonateInfo = new WorldMap.ParishWallDonateInfo();
			parishWallDonateInfo.returnData = returnData;
			parishWallDonateInfo.lastUpdateTime = DateTime.Now;
			long index = ((long)parishCapitalID << 32) + (long)userID;
			this.m_parishWallDonateDetails[index] = parishWallDonateInfo;
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x0028DCD4 File Offset: 0x0028BED4
		public void flushParishWallDonation(int parishCapitalID, int userID)
		{
			long index = ((long)parishCapitalID << 32) + (long)userID;
			this.m_parishWallDonateDetails[index] = null;
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x0028DCF8 File Offset: 0x0028BEF8
		public ParishWallDetailInfo_ReturnType getParishWallDonateDetails(int parishCapitalID, int userID)
		{
			long index = ((long)parishCapitalID << 32) + (long)userID;
			if (this.m_parishWallDonateDetails[index] != null)
			{
				WorldMap.ParishWallDonateInfo parishWallDonateInfo = (WorldMap.ParishWallDonateInfo)this.m_parishWallDonateDetails[index];
				if ((DateTime.Now - parishWallDonateInfo.lastUpdateTime).TotalMinutes < 2.0)
				{
					return parishWallDonateInfo.returnData;
				}
			}
			return null;
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x0028DD5C File Offset: 0x0028BF5C
		public List<int> getAchievementsToTest(ref List<AchievementData> achievementData)
		{
			achievementData = new List<AchievementData>();
			List<int> list = new List<int>();
			List<int> userAchievements = RemoteServices.Instance.UserAchievements;
			if (userAchievements != null)
			{
				double currentGold = this.getCurrentGold();
				if (currentGold >= 20000.0)
				{
					if (!userAchievements.Contains(100))
					{
						list.Add(100);
					}
					if (currentGold >= 200000.0)
					{
						if (!userAchievements.Contains(268435556))
						{
							list.Add(268435556);
						}
						if (currentGold >= 1000000.0)
						{
							if (!userAchievements.Contains(536871012))
							{
								list.Add(536871012);
							}
							if (currentGold >= 5000000.0)
							{
								if (!userAchievements.Contains(1073741924))
								{
									list.Add(1073741924);
								}
								if (currentGold >= 10000000.0)
								{
									if (!userAchievements.Contains(1342177380))
									{
										list.Add(1342177380);
									}
									if (currentGold >= 20000000.0)
									{
										if (!userAchievements.Contains(1610612836))
										{
											list.Add(1610612836);
										}
										if (currentGold >= 50000000.0 && !userAchievements.Contains(1879048292))
										{
											list.Add(1879048292);
										}
									}
								}
							}
						}
					}
				}
				int num = this.numUserParishes();
				if (num >= 1)
				{
					if (!userAchievements.Contains(385))
					{
						list.Add(385);
					}
					if (num >= 2)
					{
						if (!userAchievements.Contains(268435841))
						{
							list.Add(268435841);
						}
						if (num >= 3)
						{
							if (!userAchievements.Contains(536871297))
							{
								list.Add(536871297);
							}
							if (num >= 4 && !userAchievements.Contains(1073742209))
							{
								list.Add(1073742209);
							}
						}
					}
				}
				int num2 = this.numUserCounties();
				if (num2 >= 1)
				{
					if (!userAchievements.Contains(386))
					{
						list.Add(386);
					}
					if (num2 >= 2)
					{
						if (!userAchievements.Contains(268435842))
						{
							list.Add(268435842);
						}
						if (num2 >= 3)
						{
							if (!userAchievements.Contains(536871298))
							{
								list.Add(536871298);
							}
							if (num2 >= 4 && !userAchievements.Contains(1073742210))
							{
								list.Add(1073742210);
							}
						}
					}
				}
				int num3 = this.numUserProvinces();
				if (num3 >= 1)
				{
					if (!userAchievements.Contains(387))
					{
						list.Add(387);
					}
					if (num3 >= 2)
					{
						if (!userAchievements.Contains(268435843))
						{
							list.Add(268435843);
						}
						if (num3 >= 3)
						{
							if (!userAchievements.Contains(536871299))
							{
								list.Add(536871299);
							}
							if (num3 >= 4 && !userAchievements.Contains(1073742211))
							{
								list.Add(1073742211);
							}
						}
					}
				}
				int num4 = this.numUserCountries();
				if (num4 >= 1)
				{
					if (!userAchievements.Contains(388))
					{
						list.Add(388);
					}
					if (num4 >= 2)
					{
						if (!userAchievements.Contains(268435844))
						{
							list.Add(268435844);
						}
						if (num4 >= 3)
						{
							if (!userAchievements.Contains(536871300))
							{
								list.Add(536871300);
							}
							if (num4 >= 4 && !userAchievements.Contains(1073742212))
							{
								list.Add(1073742212);
							}
						}
					}
				}
				int num5 = 0;
				if (this.UserResearchData != null)
				{
					num5 = this.UserResearchData.numBranchesComplete(GameEngine.Instance.LocalWorldData);
				}
				if (num5 >= 1)
				{
					if (!userAchievements.Contains(225))
					{
						list.Add(225);
					}
					if (num5 >= 2)
					{
						if (!userAchievements.Contains(268435681))
						{
							list.Add(268435681);
						}
						if (num5 >= 3)
						{
							if (!userAchievements.Contains(536871137))
							{
								list.Add(536871137);
							}
							if (num5 >= 4 && !userAchievements.Contains(1073742049))
							{
								list.Add(1073742049);
							}
						}
					}
				}
				FactionData yourFaction = this.YourFaction;
				if (yourFaction != null)
				{
					int houseID = yourFaction.houseID;
					if (houseID > 0)
					{
						List<int> list2 = new List<int>();
						int num6 = 0;
						WorldMap.WorldPointList[] array = this.countyList;
						foreach (WorldMap.WorldPointList worldPointList in array)
						{
							if (this.getHouse(worldPointList.factionID) == houseID)
							{
								num6++;
								list2.Add(worldPointList.capitalVillage);
							}
						}
						List<int> list3 = new List<int>();
						int num7 = 0;
						WorldMap.WorldPointList[] array3 = this.provincesList;
						foreach (WorldMap.WorldPointList worldPointList2 in array3)
						{
							if (this.getHouse(worldPointList2.factionID) == houseID)
							{
								num7++;
								list3.Add(worldPointList2.capitalVillage);
							}
						}
						List<int> list4 = new List<int>();
						int num8 = 0;
						WorldMap.WorldPointList[] array5 = this.countryList;
						foreach (WorldMap.WorldPointList worldPointList3 in array5)
						{
							if (this.getHouse(worldPointList3.factionID) == houseID)
							{
								num8++;
								list4.Add(worldPointList3.capitalVillage);
							}
						}
						if (num6 >= 1 && !userAchievements.Contains(194))
						{
							list.Add(194);
							foreach (int data in list2)
							{
								AchievementData achievementData2 = new AchievementData();
								achievementData2.data = data;
								achievementData2.achievement = 194;
								achievementData.Add(achievementData2);
							}
						}
						if (num7 >= 1 && !userAchievements.Contains(268435650))
						{
							list.Add(268435650);
							foreach (int data2 in list3)
							{
								AchievementData achievementData3 = new AchievementData();
								achievementData3.data = data2;
								achievementData3.achievement = 268435650;
								achievementData.Add(achievementData3);
							}
						}
						if (num8 >= 1)
						{
							if (!userAchievements.Contains(536871106))
							{
								list.Add(536871106);
								foreach (int data3 in list4)
								{
									AchievementData achievementData4 = new AchievementData();
									achievementData4.data = data3;
									achievementData4.achievement = 536871106;
									achievementData.Add(achievementData4);
								}
							}
							if (num8 > 1 && !userAchievements.Contains(1073742018))
							{
								list.Add(1073742018);
								foreach (int data4 in list4)
								{
									AchievementData achievementData5 = new AchievementData();
									achievementData5.data = data4;
									achievementData5.achievement = 1073742018;
									achievementData.Add(achievementData5);
								}
							}
						}
					}
					VillageMap.getCurrentServerTime();
					if (this.FactionMembers != null)
					{
						FactionMemberData[] factionMembers = this.FactionMembers;
						FactionMemberData[] array7 = factionMembers;
						int l = 0;
						while (l < array7.Length)
						{
							FactionMemberData factionMemberData = array7[l];
							if (factionMemberData.userID == RemoteServices.Instance.UserID)
							{
								TimeSpan timeSpan = VillageMap.getCurrentServerTime() - factionMemberData.dateJoined;
								if (timeSpan.TotalDays < 14.0)
								{
									break;
								}
								if (!userAchievements.Contains(195))
								{
									list.Add(195);
								}
								if (timeSpan.TotalDays < 70.0)
								{
									break;
								}
								if (!userAchievements.Contains(268435651))
								{
									list.Add(268435651);
								}
								if (timeSpan.TotalDays < 182.0)
								{
									break;
								}
								if (!userAchievements.Contains(536871107))
								{
									list.Add(536871107);
								}
								if (timeSpan.TotalDays >= 364.0 && !userAchievements.Contains(1073742019))
								{
									list.Add(1073742019);
									break;
								}
								break;
							}
							else
							{
								l++;
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x0028E538 File Offset: 0x0028C738
		public int getCurrentFactionDuration()
		{
			if (this.FactionMembers != null)
			{
				FactionMemberData[] factionMembers = this.FactionMembers;
				foreach (FactionMemberData factionMemberData in factionMembers)
				{
					if (factionMemberData.userID == RemoteServices.Instance.UserID)
					{
						return (int)(VillageMap.getCurrentServerTime() - factionMemberData.dateJoined).TotalDays / 7;
					}
				}
			}
			return 0;
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x0028E598 File Offset: 0x0028C798
		public void runClientAchievementTests()
		{
			List<AchievementData> achievementData = null;
			List<int> achievementsToTest = this.getAchievementsToTest(ref achievementData);
			if (achievementsToTest != null && achievementsToTest.Count > 0)
			{
				this.testAchievements(achievementsToTest, achievementData, false);
			}
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x0028E5C8 File Offset: 0x0028C7C8
		public void testAchievements(List<int> achievementToTest, List<AchievementData> achievementData, bool onLoading)
		{
			if (achievementToTest == null || achievementToTest.Count <= 0)
			{
				return;
			}
			if (this.inTestAchievements)
			{
				int num = 30;
				if (!onLoading)
				{
					num = 60;
				}
				if ((DateTime.Now - this.lastTestAchievements).TotalSeconds > (double)num)
				{
					this.inTestAchievements = false;
				}
			}
			if (!this.inTestAchievements)
			{
				this.inTestAchievements = true;
				this.lastTestAchievements = DateTime.Now;
				RemoteServices.Instance.set_TestAchievements_UserCallBack(new RemoteServices.TestAchievements_UserCallBack(this.testAchievementsCallback));
				RemoteServices.Instance.TestAchievements(achievementToTest, achievementData);
			}
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x00023E1B File Offset: 0x0002201B
		public void testAchievementsCallback(TestAchievements_ReturnType returnData)
		{
			this.inTestAchievements = false;
			if (returnData.Success)
			{
				this.loadingErrored = false;
				if (returnData.achievements != null)
				{
					InterfaceMgr.Instance.processAchievements(returnData.achievements);
					return;
				}
			}
			else
			{
				this.loadingErrored = true;
			}
		}

		// Token: 0x060031B3 RID: 12723 RVA: 0x0028E654 File Offset: 0x0028C854
		public bool isHeretic()
		{
			if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
			{
				FactionData yourFaction = this.YourFaction;
				if (yourFaction != null && yourFaction.factionID == 4)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060031B4 RID: 12724 RVA: 0x0028E688 File Offset: 0x0028C888
		public void getTraderData()
		{
			this.clearTraderArray(-1);
			this.lastTraderTime = DateTime.Now.AddYears(-5);
			RemoteServices.Instance.set_GetUserTraders_UserCallBack(new RemoteServices.GetUserTraders_UserCallBack(this.getUserTradersCallback));
			RemoteServices.Instance.GetUserTraders();
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x00023E53 File Offset: 0x00022053
		public void getUserTradersCallback(GetUserTraders_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.importOrphanedTraders(returnData.traders, returnData.currentTime, -2);
				return;
			}
			this.loadingErrored = true;
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x00023E80 File Offset: 0x00022080
		public void getActiveTraders()
		{
			RemoteServices.Instance.set_GetActiveTraders_UserCallBack(new RemoteServices.GetActiveTraders_UserCallBack(this.getActiveTradersCallback));
			RemoteServices.Instance.GetActiveTraders(this.lastTraderTime);
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x00023EA8 File Offset: 0x000220A8
		public void getActiveTradersCallback(GetActiveTraders_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loadingErrored = false;
				this.importOrphanedTraders(returnData.traders, returnData.currentTime, -2);
				this.lastTraderTime = returnData.currentTime;
				return;
			}
			this.loadingErrored = true;
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x0028E6D4 File Offset: 0x0028C8D4
		public void importOrphanedTraders(List<MarketTraderData> traderData, DateTime curServerTime, int villageID)
		{
			GameEngine.Instance.World.clearTraderArray(villageID);
			if (traderData != null)
			{
				AllArmiesPanel2.TradersUpdated = true;
				foreach (MarketTraderData marketTrader in traderData)
				{
					this.addTrader(marketTrader, curServerTime);
				}
			}
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x0028E73C File Offset: 0x0028C93C
		public void clearTraderArray(int villageID)
		{
			if (villageID != -2)
			{
				if (villageID < 0)
				{
					this.traderArray.Clear();
					return;
				}
				List<WorldMap.LocalTrader> list = new List<WorldMap.LocalTrader>();
				foreach (object obj in this.traderArray)
				{
					WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
					if (localTrader.trader.homeVillageID == villageID)
					{
						list.Add(localTrader);
					}
				}
				foreach (WorldMap.LocalTrader localTrader2 in list)
				{
					this.traderArray[localTrader2.traderID] = null;
				}
			}
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x0028E80C File Offset: 0x0028CA0C
		public void addTrader(MarketTraderData marketTrader, DateTime curServerTime)
		{
			WorldMap.LocalTrader localTrader = new WorldMap.LocalTrader();
			localTrader.trader = marketTrader;
			localTrader.traderID = marketTrader.traderID;
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (marketTrader.targetVillageID >= 0 && marketTrader.homeVillageID >= 0)
			{
				if (marketTrader.traderState > 0)
				{
					localTrader.createJourney(marketTrader.startTime, curServerTime, marketTrader.endTime);
					localTrader.targetDisplayX = (double)this.villageList[marketTrader.targetVillageID].x;
					localTrader.targetDisplayY = (double)this.villageList[marketTrader.targetVillageID].y;
					localTrader.seaTravel = this.isIslandTravel(marketTrader.homeVillageID, marketTrader.targetVillageID);
					foreach (object obj in this.traderArray)
					{
						WorldMap.LocalTrader localTrader2 = (WorldMap.LocalTrader)obj;
						if (localTrader2.parentTrader == -1L && localTrader2.traderID != localTrader.traderID && localTrader2.trader.traderState == marketTrader.traderState && localTrader2.trader.targetVillageID == marketTrader.targetVillageID && localTrader2.trader.homeVillageID == marketTrader.homeVillageID && localTrader2.trader.resource == marketTrader.resource)
						{
							TimeSpan timeSpan = localTrader2.trader.endTime - marketTrader.endTime;
							if (timeSpan.TotalSeconds < 1.0 && timeSpan.TotalSeconds > -1.0)
							{
								localTrader.parentTrader = localTrader2.trader.traderID;
							}
						}
					}
				}
				localTrader.baseDisplayX = (double)this.villageList[marketTrader.homeVillageID].x;
				localTrader.baseDisplayY = (double)this.villageList[marketTrader.homeVillageID].y;
				localTrader.updatePosition(currentMilliseconds);
				this.traderArray[localTrader.traderID] = localTrader;
			}
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x0028EA0C File Offset: 0x0028CC0C
		public double[] getTraderTimes()
		{
			if (this.thisVillageTraders == null)
			{
				return null;
			}
			List<double> list = new List<double>();
			for (int i = 0; i < this.thisVillageTraders.Count; i++)
			{
				list.Add(this.thisVillageTraders[i].localEndTime);
			}
			return list.ToArray();
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x0028EA5C File Offset: 0x0028CC5C
		public void updateTraders()
		{
			try
			{
				int num = 0;
				bool flag = true;
				if (!flag)
				{
					this.t_startAt = this.t_endAt;
					if (this.t_startAt >= this.traderArray.Count)
					{
						this.t_startAt = 0;
						this.t_endAt = 0;
					}
					this.t_endAt += this.t_perFrame;
					if (this.t_endAt > this.traderArray.Count)
					{
						this.t_endAt = this.traderArray.Count;
					}
				}
				double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
				List<WorldMap.LocalTrader> list = new List<WorldMap.LocalTrader>();
				foreach (object obj in this.traderArray)
				{
					WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
					if (!flag)
					{
						if (num < this.t_startAt)
						{
							num++;
							continue;
						}
						if (num >= this.t_endAt)
						{
							break;
						}
						num++;
					}
					localTrader.updatePosition(currentMilliseconds);
					if (localTrader.dying)
					{
						list.Add(localTrader);
					}
				}
				foreach (WorldMap.LocalTrader localTrader2 in list)
				{
					this.traderArray[localTrader2.trader.traderID] = null;
				}
			}
			catch (Exception ex)
			{
				UniversalDebugLog.Log("exception updating armies " + ex.ToString());
			}
		}

		// Token: 0x060031BD RID: 12733 RVA: 0x00023EE1 File Offset: 0x000220E1
		public bool isVillageTrading(int villageID)
		{
			return this.tradingVillageList.Contains(villageID);
		}

		// Token: 0x060031BE RID: 12734 RVA: 0x00023EF4 File Offset: 0x000220F4
		public bool isVillageMarketTrading(int villageID)
		{
			return this.marketTradingVillageList.Contains(villageID);
		}

		// Token: 0x060031BF RID: 12735 RVA: 0x0028EC04 File Offset: 0x0028CE04
		public void drawTraders(RectangleF screenRect)
		{
			this.tradingVillageList.Clear();
			this.marketTradingVillageList.Clear();
			float num = (float)this.m_worldScale / 28f / 0.6f;
			if (num < 0.1f)
			{
				num = 0.1f;
			}
			if (num > 1f)
			{
				num = 1f;
			}
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			foreach (object obj in this.traderArray)
			{
				WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
				if (localTrader.trader.traderState > 0 && localTrader.parentTrader == -1L)
				{
					int traderState = localTrader.trader.traderState;
					if (traderState - 1 > 1)
					{
						if (traderState - 3 <= 3)
						{
							this.marketTradingVillageList.Add(localTrader.trader.targetVillageID);
							this.marketTradingVillageList.Add(localTrader.trader.homeVillageID);
						}
					}
					else
					{
						this.tradingVillageList.Add(localTrader.trader.targetVillageID);
						this.tradingVillageList.Add(localTrader.trader.homeVillageID);
					}
					if (localTrader.isVisible(screenRect) && worldMapFilter.showTrader(localTrader))
					{
						int num2 = 0;
						if (!this.isUserVillage(localTrader.trader.homeVillageID))
						{
							num2 = 1;
						}
						int num3 = 2 + num2;
						int num4 = num3;
						if (this.DrawingArmyArrows)
						{
							this.villageSprite.PosX = (float)(localTrader.displayX - (double)screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							this.villageSprite.PosY = (float)(localTrader.displayY - (double)screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
							bool flag = this.isUserVillage(localTrader.trader.homeVillageID) && this.isUserVillage(localTrader.trader.targetVillageID) && !this.isCapital(localTrader.trader.targetVillageID);
							this.villageSprite.SpriteNo = (flag ? (num3 - 1) : num3);
							this.villageSprite.Center = new PointF(44f, 44f);
							this.villageSprite.RotationAngle = SpriteWrapper.getFacing(localTrader.BasePoint(), localTrader.TargetPoint());
							this.villageSprite.Scale = num;
							this.villageSprite.Update();
							this.villageSprite.DrawAndClear();
						}
						num3 = 10 + num2;
						this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
						this.villageSprite.SpriteNo = num3;
						this.villageSprite.Center = new PointF(44f, 44f);
						this.villageSprite.Scale = num;
						this.villageSprite.Update();
						this.villageSprite.DrawAndClear();
						if (localTrader.seaTravel)
						{
							this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapIconsTexID;
							if (num4 <= 404)
							{
								switch (num4)
								{
								case 0:
									this.villageSprite.SpriteNo = 425;
									break;
								case 1:
									this.villageSprite.SpriteNo = 426;
									break;
								case 2:
									this.villageSprite.SpriteNo = 427;
									break;
								case 3:
									this.villageSprite.SpriteNo = 428;
									break;
								default:
									if (num4 == 404)
									{
										this.villageSprite.SpriteNo = 429;
									}
									break;
								}
							}
							else if (num4 != 408)
							{
								if (num4 != 412)
								{
									if (num4 == 416)
									{
										this.villageSprite.SpriteNo = 432;
									}
								}
								else
								{
									this.villageSprite.SpriteNo = 431;
								}
							}
							else
							{
								this.villageSprite.SpriteNo = 430;
							}
							this.villageSprite.Center = new PointF(44f, 44f);
							this.villageSprite.ColorToUse = Color.FromArgb(this.alphaValue, global::ARGBColors.White);
							this.villageSprite.Scale = num;
							this.villageSprite.Update();
							this.villageSprite.DrawAndClear();
						}
					}
				}
			}
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x0028F070 File Offset: 0x0028D270
		private long findNearestTraderFromScreenPos(Point mousePos, ref double bestDist)
		{
			if (InterfaceMgr.Instance.WorldMapMode != 0)
			{
				return -1L;
			}
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestTraderFromMapPos(num, num2, ref bestDist);
			}
			return -1L;
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x0028F118 File Offset: 0x0028D318
		private long findNearestTraderFromMapPos(double mapX, double mapY, ref double bestDist)
		{
			WorldMapFilter worldMapFilter = GameEngine.Instance.World.worldMapFilter;
			long result = -1L;
			double num = 2.25;
			foreach (object obj in this.traderArray)
			{
				WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
				if (localTrader.trader.traderState > 0 && localTrader.parentTrader == -1L && worldMapFilter.showTrader(localTrader))
				{
					double num2 = (localTrader.displayX - mapX) * (localTrader.displayX - mapX) + (localTrader.displayY - mapY) * (localTrader.displayY - mapY);
					if (num2 < num)
					{
						num = num2;
						result = localTrader.traderID;
					}
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x060031C2 RID: 12738 RVA: 0x0028F1EC File Offset: 0x0028D3EC
		public int getTradingAmount(long traderID)
		{
			int num = 0;
			if (this.traderArray[traderID] != null)
			{
				WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)this.traderArray[traderID];
				num += localTrader.trader.amount;
				foreach (object obj in this.traderArray)
				{
					WorldMap.LocalTrader localTrader2 = (WorldMap.LocalTrader)obj;
					if (localTrader2.parentTrader == traderID)
					{
						num += localTrader2.trader.amount;
					}
				}
				return num;
			}
			return num;
		}

		// Token: 0x060031C3 RID: 12739 RVA: 0x00023F07 File Offset: 0x00022107
		public WorldMap.LocalTrader getTrader(long traderID)
		{
			return (WorldMap.LocalTrader)this.traderArray[traderID];
		}

		// Token: 0x060031C4 RID: 12740 RVA: 0x00023F1A File Offset: 0x0002211A
		public SparseArray getTraderArray()
		{
			return this.traderArray;
		}

		// Token: 0x060031C5 RID: 12741 RVA: 0x0028F28C File Offset: 0x0028D48C
		public int getTotalMerchantsFromVillage(int villageID)
		{
			int num = 0;
			foreach (object obj in this.traderArray)
			{
				WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)obj;
				if (localTrader.trader.homeVillageID == villageID)
				{
					num += localTrader.trader.numTraders;
				}
			}
			return num;
		}

		// Token: 0x060031C6 RID: 12742 RVA: 0x0028F300 File Offset: 0x0028D500
		public bool allowExchangeTrade(int exchangeVillageID, int buyingVillageID)
		{
			if (exchangeVillageID < 0 || buyingVillageID < 0 || exchangeVillageID >= this.villageList.Length || buyingVillageID >= this.villageList.Length)
			{
				return false;
			}
			VillageData villageData = this.villageList[exchangeVillageID];
			VillageData villageData2 = this.villageList[buyingVillageID];
			if (!villageData.Capital)
			{
				return false;
			}
			switch (this.UserResearchData.Research_Commerce)
			{
			case 0:
				if (villageData.regionID != villageData2.regionID)
				{
					return false;
				}
				break;
			case 1:
				if (villageData.countyID != villageData2.countyID)
				{
					return false;
				}
				break;
			case 2:
			{
				if (villageData2.countyID < 0 || villageData.countyID < 0)
				{
					return false;
				}
				int parentID = this.countyList[(int)villageData.countyID].parentID;
				int parentID2 = this.countyList[(int)villageData2.countyID].parentID;
				if (parentID != parentID2)
				{
					return false;
				}
				break;
			}
			case 3:
			{
				if (villageData2.countyID < 0 || villageData.countyID < 0)
				{
					return false;
				}
				int parentID3 = this.countyList[(int)villageData.countyID].parentID;
				int parentID4 = this.countyList[(int)villageData2.countyID].parentID;
				if (parentID3 < 0 || parentID4 < 0)
				{
					return false;
				}
				int parentID5 = this.provincesList[parentID3].parentID;
				int parentID6 = this.provincesList[parentID4].parentID;
				if (parentID5 != parentID6)
				{
					return false;
				}
				break;
			}
			}
			return true;
		}

		// Token: 0x060031C7 RID: 12743 RVA: 0x00023F22 File Offset: 0x00022122
		public WorldMap.WorldPointList GetProvinceById(int id)
		{
			return this.provincesList[id];
		}

		// Token: 0x060031C8 RID: 12744 RVA: 0x00023F2C File Offset: 0x0002212C
		public WorldMap.WorldPointList GetCountryById(int id)
		{
			return this.countryList[id];
		}

		// Token: 0x060031C9 RID: 12745 RVA: 0x00023F36 File Offset: 0x00022136
		public WorldMap.WorldPointList GetCountryFromWorldPoint(WorldMap.WorldPoint candidate, RectangleF screenRect)
		{
			return this.GetRegionFromWorldPoint(candidate, screenRect, this.countryList);
		}

		// Token: 0x060031CA RID: 12746 RVA: 0x00023F46 File Offset: 0x00022146
		public WorldMap.WorldPointList GetProvinceFromWorldPoint(WorldMap.WorldPoint candidate, RectangleF screenRect)
		{
			return this.GetRegionFromWorldPoint(candidate, screenRect, this.provincesList);
		}

		// Token: 0x060031CB RID: 12747 RVA: 0x00023F56 File Offset: 0x00022156
		public WorldMap.WorldPointList GetCountyFromWorldPoint(WorldMap.WorldPoint candidate, RectangleF screenRect)
		{
			return this.GetRegionFromWorldPoint(candidate, screenRect, this.countyList);
		}

		// Token: 0x060031CC RID: 12748 RVA: 0x00023F66 File Offset: 0x00022166
		public WorldMap.WorldPointList GetParishFromWorldPoint(WorldMap.WorldPoint candidate, RectangleF screenRect)
		{
			return this.GetRegionFromWorldPoint(candidate, screenRect, this.regionList);
		}

		// Token: 0x060031CD RID: 12749 RVA: 0x0028F44C File Offset: 0x0028D64C
		public WorldMap.WorldPointList GetRegionFromWorldPoint(WorldMap.WorldPoint candidate, RectangleF screenRect, WorldMap.WorldPointList[] regions)
		{
			foreach (WorldMap.WorldPointList worldPointList in regions)
			{
				if (worldPointList.isVisible(screenRect) && worldPointList.PointWithinRegion(candidate))
				{
					return worldPointList;
				}
			}
			return null;
		}

		// Token: 0x060031CE RID: 12750 RVA: 0x00023F76 File Offset: 0x00022176
		public VillageData GetVllageByID(int id)
		{
			return this.villageList[id];
		}

		// Token: 0x060031CF RID: 12751 RVA: 0x00023F80 File Offset: 0x00022180
		public int getGloryPoints(int houseID)
		{
			if (houseID > 0 && this.m_gloryPoints != null && houseID < this.m_gloryPoints.Length)
			{
				return this.m_gloryPoints[houseID];
			}
			return 0;
		}

		// Token: 0x060031D0 RID: 12752 RVA: 0x0028F484 File Offset: 0x0028D684
		public bool alreadyGotFactionApplication(int factionID)
		{
			if (this.m_factionApplications != null)
			{
				foreach (FactionInviteData factionInviteData in this.m_factionApplications)
				{
					if (factionInviteData.factionID == factionID)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x060031D1 RID: 12753 RVA: 0x0028F4E8 File Offset: 0x0028D6E8
		public bool testGloryPointsUpdate()
		{
			if ((DateTime.Now - this.lastHouseGloryPointsUpdate).TotalHours > 2.0)
			{
				this.lastHouseGloryPointsUpdate = DateTime.Now;
				return true;
			}
			return false;
		}

		// Token: 0x060031D2 RID: 12754 RVA: 0x00023FA3 File Offset: 0x000221A3
		public void clearGloryHistory()
		{
			this.lastHouseGloryPointsUpdate = DateTime.MinValue;
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x0028F528 File Offset: 0x0028D728
		public int getGloryRank(int houseID)
		{
			int[,] array = new int[20, 2];
			int num = 0;
			for (int i = 0; i < 20; i++)
			{
				if (!GameEngine.Instance.World.HouseInfo[i + 1].loser)
				{
					array[i, 0] = GameEngine.Instance.World.HouseGloryPoints[i + 1];
				}
				else
				{
					array[i, 0] = -1;
					num++;
				}
				array[i, 1] = i;
			}
			for (int j = 0; j < 19; j++)
			{
				for (int k = 0; k < 19; k++)
				{
					if (array[k, 0] < array[k + 1, 0])
					{
						int num2 = array[k, 0];
						array[k, 0] = array[k + 1, 0];
						array[k + 1, 0] = num2;
						num2 = array[k, 1];
						array[k, 1] = array[k + 1, 1];
						array[k + 1, 1] = num2;
					}
				}
			}
			for (int l = 0; l < 20 - num; l++)
			{
				int num3 = array[l, 1] + 1;
				if (num3 == houseID)
				{
					return l;
				}
			}
			return -1;
		}

		// Token: 0x060031D4 RID: 12756 RVA: 0x00023FB0 File Offset: 0x000221B0
		public FactionData getFaction(int factionID)
		{
			return (FactionData)this.m_factionData[factionID];
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x00023FC3 File Offset: 0x000221C3
		public void setFactionData(FactionData fd)
		{
			if (fd != null && fd.factionID >= 0)
			{
				this.m_factionData[fd.factionID] = fd;
			}
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x0028F658 File Offset: 0x0028D858
		public int getFactionRank(int factionID)
		{
			FactionData faction = this.getFaction(factionID);
			if (faction == null)
			{
				return -1;
			}
			int points = faction.points;
			int num = 0;
			foreach (object obj in this.m_factionData)
			{
				FactionData factionData = (FactionData)obj;
				if (factionData.factionID != faction.factionID)
				{
					if (factionData.points > points)
					{
						num++;
					}
					else if (factionData.points == points && factionData.factionID < faction.factionID)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x0028F704 File Offset: 0x0028D904
		public string getFactionName(int factionID)
		{
			FactionData faction = this.getFaction(factionID);
			if (faction == null)
			{
				return "";
			}
			return faction.factionName;
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x00023FE3 File Offset: 0x000221E3
		public SparseArray getAllFactions()
		{
			return this.m_factionData;
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x0028F728 File Offset: 0x0028D928
		public int getYourFactionRank()
		{
			if (this.m_factionMembers != null)
			{
				FactionMemberData[] factionMembers = this.m_factionMembers;
				foreach (FactionMemberData factionMemberData in factionMembers)
				{
					if (factionMemberData.userID == RemoteServices.Instance.UserID)
					{
						return factionMemberData.status;
					}
				}
			}
			return 0;
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x0028F774 File Offset: 0x0028D974
		public int getYourFactionRelation(int otherFactionID)
		{
			int userFactionID = RemoteServices.Instance.UserFactionID;
			if (userFactionID < 0)
			{
				return 0;
			}
			if (otherFactionID == userFactionID)
			{
				return 0;
			}
			if (this.m_factionAllies != null)
			{
				int[] factionAllies = this.m_factionAllies;
				foreach (int num in factionAllies)
				{
					if (num == otherFactionID)
					{
						return 1;
					}
				}
			}
			if (this.m_factionEnemies != null)
			{
				int[] factionEnemies = this.m_factionEnemies;
				foreach (int num2 in factionEnemies)
				{
					if (num2 == otherFactionID)
					{
						return -1;
					}
				}
			}
			return 0;
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x0028F7FC File Offset: 0x0028D9FC
		public int getYourHouseRelation(int otherHouseID)
		{
			int userFactionID = RemoteServices.Instance.UserFactionID;
			if (userFactionID < 0)
			{
				return 0;
			}
			FactionData faction = this.getFaction(userFactionID);
			if (faction == null)
			{
				return 0;
			}
			int houseID = faction.houseID;
			if (houseID == 0 || otherHouseID == houseID)
			{
				return 0;
			}
			if (this.m_houseAllies != null)
			{
				int[] houseAllies = this.m_houseAllies;
				foreach (int num in houseAllies)
				{
					if (num == otherHouseID)
					{
						return 1;
					}
				}
			}
			if (this.m_houseEnemies != null)
			{
				int[] houseEnemies = this.m_houseEnemies;
				foreach (int num2 in houseEnemies)
				{
					if (num2 == otherHouseID)
					{
						return -1;
					}
				}
			}
			return 0;
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x0028F8A0 File Offset: 0x0028DAA0
		public int getYourHouseRank()
		{
			int userFactionID = RemoteServices.Instance.UserFactionID;
			if (userFactionID < 0)
			{
				return 0;
			}
			FactionData faction = this.getFaction(userFactionID);
			if (faction == null)
			{
				return 0;
			}
			return faction.houseRank;
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x0028F8D0 File Offset: 0x0028DAD0
		public FactionData getFactionLeadingHouse(int houseID)
		{
			foreach (object obj in this.m_factionData)
			{
				FactionData factionData = (FactionData)obj;
				if (factionData.houseID == houseID && factionData.houseRank == 10)
				{
					return factionData;
				}
			}
			return null;
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x0028F93C File Offset: 0x0028DB3C
		public FactionData[] getHouseFactions(int houseID)
		{
			List<FactionData> list = new List<FactionData>();
			if (this.m_factionData != null)
			{
				foreach (object obj in this.m_factionData)
				{
					FactionData factionData = (FactionData)obj;
					if (factionData.houseID == houseID)
					{
						list.Add(factionData);
					}
				}
			}
			WorldMap.FactionPointsComparer comparer = new WorldMap.FactionPointsComparer();
			list.Sort(comparer);
			return list.ToArray();
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x0028F9C4 File Offset: 0x0028DBC4
		public void setFactionMemberData(int factionID, FactionMemberData[] memberData)
		{
			if (factionID == RemoteServices.Instance.UserFactionID)
			{
				this.FactionMembers = memberData;
				return;
			}
			if (this.cachedFactionMemberData[factionID] == null)
			{
				FactionCachedMemberData factionCachedMemberData = new FactionCachedMemberData();
				factionCachedMemberData.factionID = factionID;
				factionCachedMemberData.memberData = memberData;
				factionCachedMemberData.lastRefreshed = DateTime.Now;
				this.cachedFactionMemberData[factionID] = factionCachedMemberData;
				return;
			}
			FactionCachedMemberData factionCachedMemberData2 = (FactionCachedMemberData)this.cachedFactionMemberData[factionID];
			factionCachedMemberData2.memberData = memberData;
			factionCachedMemberData2.lastRefreshed = DateTime.Now;
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x0028FA48 File Offset: 0x0028DC48
		public FactionMemberData[] getFactionMemberData(int factionID, ref bool uptodate)
		{
			if (factionID == RemoteServices.Instance.UserFactionID)
			{
				if ((DateTime.Now - this.lastTimeOwnMembersUpdated).TotalMinutes < 1.0)
				{
					uptodate = true;
				}
				else
				{
					uptodate = false;
				}
				return this.FactionMembers;
			}
			uptodate = false;
			if (this.cachedFactionMemberData[factionID] == null)
			{
				return null;
			}
			FactionCachedMemberData factionCachedMemberData = (FactionCachedMemberData)this.cachedFactionMemberData[factionID];
			if ((DateTime.Now - factionCachedMemberData.lastRefreshed).TotalMinutes < 3.0)
			{
				uptodate = true;
			}
			return factionCachedMemberData.memberData;
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x0028FAE8 File Offset: 0x0028DCE8
		public int countHouseMembers(int houseID)
		{
			int num = 0;
			foreach (object obj in this.m_factionData)
			{
				FactionData factionData = (FactionData)obj;
				if (factionData.houseID == houseID)
				{
					num += factionData.numMembers;
				}
			}
			return num;
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x0028FB50 File Offset: 0x0028DD50
		public int countHouseFactions(int houseID)
		{
			int num = 0;
			foreach (object obj in this.m_factionData)
			{
				FactionData factionData = (FactionData)obj;
				if (factionData.active && factionData.factionName.Length > 0 && factionData.numMembers > 0 && factionData.houseID == houseID)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060031E3 RID: 12771 RVA: 0x00023FEB File Offset: 0x000221EB
		public bool isAccountPremium()
		{
			return CardTypes.isPremiumToken(GameEngine.Instance.cardsManager.UserCardData.premiumCard) && VillageMap.getCurrentServerTime() < GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry;
		}

		// Token: 0x060031E4 RID: 12772 RVA: 0x0002402B File Offset: 0x0002222B
		public bool isAccount730Premium()
		{
			return CardTypes.is730PremiumToken(GameEngine.Instance.cardsManager.UserCardData.premiumCard) && VillageMap.getCurrentServerTime() < GameEngine.Instance.cardsManager.UserCardData.premiumCardExpiry;
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x0028FBD4 File Offset: 0x0028DDD4
		public void logout()
		{
			this.worldEnded = false;
			this.clearGloryHistory();
			if (this.cachedUserInfo != null)
			{
				foreach (object obj in this.cachedUserInfo)
				{
					WorldMap.CachedUserInfo cachedUserInfo = (WorldMap.CachedUserInfo)obj;
					if (cachedUserInfo != null && cachedUserInfo.avatarBitmap != null)
					{
						cachedUserInfo.avatarBitmap.Dispose();
						cachedUserInfo.avatarBitmap = null;
					}
				}
			}
			this.cachedUserInfo = new SparseArray();
			this.cachedFactionMemberData = new SparseArray();
			if (this.villageList != null)
			{
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					villageData.rolloverInfo = null;
				}
			}
			this.cached_retrieveUserID = -1;
			this.cached_retrieveVillageID = -1;
			this.downloadingCounter = 0;
			GameEngine.Instance.cardsManager.onLogout();
			PresetManager.Instance.LogOut();
			this.playbackItems = null;
			this.playingCountries = false;
			this.playingProvinces = false;
			this.invasionMarkerState = new SparseArray();
			this.m_userRelatedVillages.Clear();
			if (this.m_userVillages != null)
			{
				this.m_userVillages.Clear();
			}
			this.KillStreakTimer = DateTime.MinValue;
			this.KillStreakCount = 0;
			this.KillStreakPoints = 0;
			this.clearFW();
		}

		// Token: 0x060031E6 RID: 12774 RVA: 0x0028FD30 File Offset: 0x0028DF30
		public void drawVillage(VillageData village, double scrX, double scrY)
		{
			if (this.shouldDrawMapIcon(village))
			{
				this.mapIcon = new MapIconDrawCall(this.gfx, this.villageSprite, this.m_worldZoomInverted, this.m_worldScale, this.mapEditing, new Size(this.m_screenWidth, this.m_screenHeight), this.pulse, this.pulseValue, this.xmasPresents);
				this.mapIcon.draw(village, scrX, scrY);
			}
		}

		// Token: 0x060031E7 RID: 12775 RVA: 0x0002406B File Offset: 0x0002226B
		public int getVillageFaction(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].factionID;
			}
			return 0;
		}

		// Token: 0x060031E8 RID: 12776 RVA: 0x0002408B File Offset: 0x0002228B
		public int getVillageRegion(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return (int)this.villageList[villageID].regionID;
			}
			return 0;
		}

		// Token: 0x060031E9 RID: 12777 RVA: 0x000240AB File Offset: 0x000222AB
		public int getVillageCounty(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return (int)this.villageList[villageID].countyID;
			}
			return 0;
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x000240CB File Offset: 0x000222CB
		public int getCountyProvince(int countyID)
		{
			if (countyID >= 0 && countyID < this.countyList.Length)
			{
				return this.countyList[countyID].parentID;
			}
			return 0;
		}

		// Token: 0x060031EB RID: 12779 RVA: 0x000240EB File Offset: 0x000222EB
		public int getProvinceCountry(int provinceID)
		{
			if (provinceID >= 0 && provinceID < this.provincesList.Length)
			{
				return this.provincesList[provinceID].parentID;
			}
			return 0;
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x0028FDA0 File Offset: 0x0028DFA0
		public bool isCapital(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && (this.villageList[villageID].regionCapital || this.villageList[villageID].countyCapital || this.villageList[villageID].provinceCapital || this.villageList[villageID].countryCapital);
		}

		// Token: 0x060031ED RID: 12781 RVA: 0x0028FDFC File Offset: 0x0028DFFC
		public int getCapitalType(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				if (this.villageList[villageID].regionCapital)
				{
					return 3;
				}
				if (this.villageList[villageID].countyCapital)
				{
					return 2;
				}
				if (this.villageList[villageID].provinceCapital)
				{
					return 1;
				}
				if (this.villageList[villageID].countryCapital)
				{
					return 0;
				}
			}
			return 4;
		}

		// Token: 0x060031EE RID: 12782 RVA: 0x0002410B File Offset: 0x0002230B
		public bool isSpecial(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].special > 2;
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x0028FE60 File Offset: 0x0028E060
		public bool isSpecialAIPlayer(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].special > 2)
			{
				switch (this.villageList[villageID].special)
				{
				case 7:
				case 9:
				case 11:
				case 13:
					return true;
				}
			}
			return false;
		}

		// Token: 0x060031F0 RID: 12784 RVA: 0x0002412F File Offset: 0x0002232F
		public int getVillageSize(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return Math.Min((int)(this.villageList[villageID].villageInfo / 6), 19);
			}
			return 0;
		}

		// Token: 0x060031F1 RID: 12785 RVA: 0x00024158 File Offset: 0x00022358
		public int getSpecial(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].special;
			}
			return 0;
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x00024178 File Offset: 0x00022378
		public bool isVillageVisible(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].visible;
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x0028FEC4 File Offset: 0x0028E0C4
		public bool isScoutableSpecial(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				if (this.villageList[villageID].special >= 100 && this.villageList[villageID].special <= 199)
				{
					return true;
				}
				switch (this.villageList[villageID].special)
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
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(this.villageList[villageID].special))
				{
					return true;
				}
				if (SpecialVillageTypes.IS_ROYAL_TOWER(this.villageList[villageID].special))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x00024198 File Offset: 0x00022398
		public bool isForagingSpecial(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].special >= 100 && this.villageList[villageID].special <= 199;
		}

		// Token: 0x060031F5 RID: 12789 RVA: 0x0028FF90 File Offset: 0x0028E190
		public bool isAttackableSpecial(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				switch (this.villageList[villageID].special)
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
				if (SpecialVillageTypes.IS_TREASURE_CASTLE(this.villageList[villageID].special))
				{
					return true;
				}
				if (SpecialVillageTypes.IS_ROYAL_TOWER(this.villageList[villageID].special))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x000241D1 File Offset: 0x000223D1
		public bool isRegionCapital(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].regionCapital;
		}

		// Token: 0x060031F7 RID: 12791 RVA: 0x000241F4 File Offset: 0x000223F4
		public bool isCountyCapital(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].countyCapital;
		}

		// Token: 0x060031F8 RID: 12792 RVA: 0x00024217 File Offset: 0x00022417
		public bool isProvinceCapital(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].provinceCapital;
		}

		// Token: 0x060031F9 RID: 12793 RVA: 0x0002423A File Offset: 0x0002243A
		public bool isCountryCapital(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].countryCapital;
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x00290038 File Offset: 0x0028E238
		public List<int> getCapitalList()
		{
			List<int> list = new List<int>();
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				if (villageData.Capital && villageData.visible)
				{
					list.Add(villageData.id);
				}
			}
			return list;
		}

		// Token: 0x060031FB RID: 12795 RVA: 0x00290088 File Offset: 0x0028E288
		public int getSquareDistance(int villageID1, int villageID2)
		{
			return (int)((this.villageList[villageID1].x - this.villageList[villageID2].x) * (this.villageList[villageID1].x - this.villageList[villageID2].x) + (this.villageList[villageID1].y - this.villageList[villageID2].y) * (this.villageList[villageID1].y - this.villageList[villageID2].y));
		}

		// Token: 0x060031FC RID: 12796 RVA: 0x00290104 File Offset: 0x0028E304
		public double getDistance(int from, int to)
		{
			Point villageLocation = this.getVillageLocation(from);
			Point villageLocation2 = this.getVillageLocation(to);
			int x = villageLocation.X;
			int y = villageLocation.Y;
			int x2 = villageLocation2.X;
			int y2 = villageLocation2.Y;
			double d = (double)((x - x2) * (x - x2) + (y - y2) * (y - y2));
			return Math.Sqrt(d);
		}

		// Token: 0x060031FD RID: 12797 RVA: 0x00290160 File Offset: 0x0028E360
		public bool isValidArmyTarget(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && !this.villageList[villageID].countyCapital && !this.villageList[villageID].provinceCapital && !this.villageList[villageID].countryCapital && (!this.villageList[villageID].regionCapital || this.villageList[villageID].factionID != 0);
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x0002425D File Offset: 0x0002245D
		public int getVillageUserID(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].userID;
			}
			return -1;
		}

		// Token: 0x060031FF RID: 12799 RVA: 0x002901D0 File Offset: 0x0028E3D0
		public Point getVillageLocation(int villageID)
		{
			Point result = new Point(-1, -1);
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				result.X = (int)this.villageList[villageID].x;
				result.Y = (int)this.villageList[villageID].y;
			}
			return result;
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x00290220 File Offset: 0x0028E420
		public List<int> searchVillageNames(string searchString)
		{
			List<int> list = new List<int>();
			searchString = searchString.ToLower();
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				if (villageData.special == 0 && villageData.visible && (villageData.userID >= 0 || villageData.Capital) && villageData.m_villageName.ToLower().Contains(searchString))
				{
					list.Add(villageData.id);
				}
			}
			return list;
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x002902A0 File Offset: 0x0028E4A0
		public Point getRegionCapitalLocation(int regionID)
		{
			Point result = new Point(-1, -1);
			if (regionID >= 0 && regionID < this.regionList.Length)
			{
				int capitalVillage = this.regionList[regionID].capitalVillage;
				if (capitalVillage >= 0 && capitalVillage < this.villageList.Length)
				{
					result.X = (int)this.villageList[capitalVillage].x;
					result.Y = (int)this.villageList[capitalVillage].y;
					return result;
				}
			}
			return result;
		}

		// Token: 0x06003202 RID: 12802 RVA: 0x0002427D File Offset: 0x0002247D
		public int getRegionCapitalVillage(int regionID)
		{
			if (regionID >= 0 && regionID < this.regionList.Length)
			{
				return this.regionList[regionID].capitalVillage;
			}
			return -1;
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x00290310 File Offset: 0x0028E510
		public Point getCountyCapitalLocation(int countyID)
		{
			Point result = new Point(-1, -1);
			if (countyID >= 0 && countyID < this.countyList.Length)
			{
				int capitalVillage = this.countyList[countyID].capitalVillage;
				if (capitalVillage >= 0 && capitalVillage < this.villageList.Length)
				{
					result.X = (int)this.villageList[capitalVillage].x;
					result.Y = (int)this.villageList[capitalVillage].y;
					return result;
				}
			}
			return result;
		}

		// Token: 0x06003204 RID: 12804 RVA: 0x0002429D File Offset: 0x0002249D
		public int getCountyCapitalVillage(int countyID)
		{
			if (countyID >= 0 && countyID < this.countyList.Length)
			{
				return this.countyList[countyID].capitalVillage;
			}
			return -1;
		}

		// Token: 0x06003205 RID: 12805 RVA: 0x00290380 File Offset: 0x0028E580
		public Point getCountyMarkerLocation(int countyID)
		{
			Point result = new Point(-1, -1);
			if (countyID >= 0 && countyID < this.countyList.Length)
			{
				return this.countyList[countyID].marker;
			}
			return result;
		}

		// Token: 0x06003206 RID: 12806 RVA: 0x000242BD File Offset: 0x000224BD
		public int numCounties()
		{
			return this.countyList.Length;
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x002903B4 File Offset: 0x0028E5B4
		public Point getProvinceCapitalLocation(int provinceID)
		{
			Point result = new Point(-1, -1);
			if (provinceID >= 0 && provinceID < this.provincesList.Length)
			{
				int capitalVillage = this.provincesList[provinceID].capitalVillage;
				if (capitalVillage >= 0 && capitalVillage < this.villageList.Length)
				{
					result.X = (int)this.villageList[capitalVillage].x;
					result.Y = (int)this.villageList[capitalVillage].y;
					return result;
				}
			}
			return result;
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x000242C7 File Offset: 0x000224C7
		public int getProvinceCapital(int provinceID)
		{
			if (provinceID >= 0 && provinceID < this.provincesList.Length)
			{
				return this.provincesList[provinceID].capitalVillage;
			}
			return -1;
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x000242E7 File Offset: 0x000224E7
		public int getVillageTerrainType(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return (int)this.villageList[villageID].villageTerrain;
			}
			return 0;
		}

		// Token: 0x0600320A RID: 12810 RVA: 0x00024307 File Offset: 0x00022507
		public string getVillageName(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].villageName;
			}
			return "";
		}

		// Token: 0x0600320B RID: 12811 RVA: 0x0002432B File Offset: 0x0002252B
		public string getVillageNameOnly(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].m_villageName;
			}
			return "";
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x0002434F File Offset: 0x0002254F
		public VillageData getVillageData(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID];
			}
			return null;
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x00290424 File Offset: 0x0028E624
		public int getVillageParent(int villageID)
		{
			if (villageID < 0 || villageID >= this.villageList.Length)
			{
				return villageID;
			}
			VillageData villageData = this.villageList[villageID];
			if (!villageData.Capital)
			{
				return this.getRegionCapitalVillage((int)villageData.regionID);
			}
			if (villageData.regionCapital)
			{
				return this.getCountyCapitalVillage((int)villageData.countyID);
			}
			if (villageData.countyCapital)
			{
				return this.getProvinceCapital(this.getProvinceFromVillageID(villageID));
			}
			if (villageData.provinceCapital)
			{
				return this.getCountryCapital(this.getCountryFromVillageID(villageID));
			}
			return villageID;
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x002904A4 File Offset: 0x0028E6A4
		public string getVillageNameOrType(int villageID)
		{
			if (this.isSpecial(villageID))
			{
				int special = this.getSpecial(villageID);
				if (GameEngine.Instance.LocalWorldData.AIWorld)
				{
					switch (special)
					{
					case 7:
					case 9:
					case 11:
					case 13:
						if (Program.mySettings.viewVillageIDs)
						{
							return "[" + villageID.ToString() + "] " + SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
						}
						break;
					}
				}
				if (SpecialVillageTypes.IS_ROYAL_TOWER(special) && Program.mySettings.viewVillageIDs)
				{
					return "[" + villageID.ToString() + "] " + SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
				}
				switch (special)
				{
				case 2:
					return SK.Text("GENERIC_Unknown", "Unknown");
				case 3:
				case 4:
					return SK.Text("GENERIC_Bandit_Camp", "Bandit Camp");
				case 5:
				case 6:
					return SK.Text("GENERIC_Wolf_Camp", "Wolf Lair");
				default:
					if (special != 30)
					{
						return SpecialVillageTypes.getName(special, Program.mySettings.LanguageIdent);
					}
					return SK.Text("GENERIC_Invasion", "Invasion");
				}
			}
			else
			{
				if (!this.isVillageVisible(villageID))
				{
					return "";
				}
				if (!this.isCapital(villageID) && this.getVillageUserID(villageID) < 0)
				{
					return SK.Text("ReportFilter_Village_Charter", "Village Charter");
				}
				return GameEngine.Instance.World.getVillageName(villageID);
			}
		}

		// Token: 0x0600320F RID: 12815 RVA: 0x00290620 File Offset: 0x0028E820
		public bool isVillageInterdictProtected(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (currentServerTime < this.villageList[villageID].interdictionTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003210 RID: 12816 RVA: 0x0002436A File Offset: 0x0002256A
		public DateTime getInterdictTime(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].interdictionTime;
			}
			return DateTime.MinValue;
		}

		// Token: 0x06003211 RID: 12817 RVA: 0x0002438E File Offset: 0x0002258E
		public void setInterdictTime(int villageID, DateTime interdictionTime)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].interdictionTime = interdictionTime;
			}
		}

		// Token: 0x06003212 RID: 12818 RVA: 0x000243AD File Offset: 0x000225AD
		public void setPeaceTime(int villageID, DateTime peaceTime)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].peaceTime = peaceTime;
			}
		}

		// Token: 0x06003213 RID: 12819 RVA: 0x000243CC File Offset: 0x000225CC
		public void setExcommunicationTime(int villageID, DateTime excommunicationTime)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].excommunicationTime = excommunicationTime;
			}
		}

		// Token: 0x06003214 RID: 12820 RVA: 0x000243EB File Offset: 0x000225EB
		public DateTime getExcommunicationTime(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].excommunicationTime;
			}
			return DateTime.MinValue;
		}

		// Token: 0x06003215 RID: 12821 RVA: 0x0029065C File Offset: 0x0028E85C
		public bool isVillagePeaceTimeProtected(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (currentServerTime < this.villageList[villageID].peaceTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003216 RID: 12822 RVA: 0x0002440F File Offset: 0x0002260F
		public bool isVillageVacationProtected(int villageID)
		{
			return villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].vacationMode;
		}

		// Token: 0x06003217 RID: 12823 RVA: 0x00290698 File Offset: 0x0028E898
		public bool isVillageExcommunicated(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				DateTime currentServerTime = VillageMap.getCurrentServerTime();
				if (currentServerTime < this.villageList[villageID].excommunicationTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06003218 RID: 12824 RVA: 0x0002442F File Offset: 0x0002262F
		public DateTime getPeaceTime(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return this.villageList[villageID].peaceTime;
			}
			return DateTime.MinValue;
		}

		// Token: 0x06003219 RID: 12825 RVA: 0x00024453 File Offset: 0x00022653
		public void setVillageName(int villageID, string villageName)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].villageName = villageName;
				this.sortUserVillages();
			}
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x002906D4 File Offset: 0x0028E8D4
		public void setParishName(int villageID, string villageName)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].villageName = villageName;
				int parishFromVillageID = this.getParishFromVillageID(villageID);
				if (parishFromVillageID >= 0 && parishFromVillageID < this.regionList.Length)
				{
					this.regionList[parishFromVillageID].areaName = villageName;
				}
				this.sortUserVillages();
			}
		}

		// Token: 0x0600321B RID: 12827 RVA: 0x0029072C File Offset: 0x0028E92C
		public void ImportParishNames(string[] newNames)
		{
			if (newNames == null || newNames.Length == 0)
			{
				return;
			}
			for (int i = 0; i < newNames.Length; i++)
			{
				this.regionList[i].areaName = newNames[i];
				int capitalVillage = this.regionList[i].capitalVillage;
				if (capitalVillage >= 0 && capitalVillage < this.villageList.Length)
				{
					this.villageList[capitalVillage].villageName = newNames[i];
					this.villageList[capitalVillage].visible = true;
				}
			}
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x0029079C File Offset: 0x0028E99C
		public string[] getParishNameList()
		{
			string[] array = new string[this.regionList.Length];
			for (int i = 0; i < this.regionList.Length; i++)
			{
				array[i] = this.regionList[i].areaName;
			}
			return array;
		}

		// Token: 0x0600321D RID: 12829 RVA: 0x00024478 File Offset: 0x00022678
		public string getParishName(int parishID)
		{
			if (parishID >= 0 && parishID < this.regionList.Length)
			{
				return this.regionList[parishID].areaName;
			}
			return "";
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x002907DC File Offset: 0x0028E9DC
		public string getParishNameFromVillageID(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				int regionID = (int)this.villageList[villageID].regionID;
				return this.regionList[regionID].areaName;
			}
			return "";
		}

		// Token: 0x0600321F RID: 12831 RVA: 0x0029081C File Offset: 0x0028EA1C
		public int getParishIDFromName(string parishName)
		{
			for (int i = 0; i < this.regionList.Length; i++)
			{
				if (this.regionList[i].areaName == parishName)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003220 RID: 12832 RVA: 0x0002449C File Offset: 0x0002269C
		public int getParishPlague(int parishID)
		{
			if (parishID >= 0 && parishID < this.regionList.Length)
			{
				return this.regionList[parishID].plague;
			}
			return 0;
		}

		// Token: 0x06003221 RID: 12833 RVA: 0x0002427D File Offset: 0x0002247D
		public int getParishCapital(int parishID)
		{
			if (parishID >= 0 && parishID < this.regionList.Length)
			{
				return this.regionList[parishID].capitalVillage;
			}
			return -1;
		}

		// Token: 0x06003222 RID: 12834 RVA: 0x000244BC File Offset: 0x000226BC
		public int getCountyIDFromParishID(int parishID)
		{
			if (parishID >= 0 && parishID < this.regionList.Length)
			{
				return this.regionList[parishID].parentID;
			}
			return -1;
		}

		// Token: 0x06003223 RID: 12835 RVA: 0x000244DC File Offset: 0x000226DC
		public string getExchangeName(int villageID)
		{
			if (this.isRegionCapital(villageID))
			{
				return this.getParishNameFromVillageID(villageID);
			}
			return this.getVillageName(villageID);
		}

		// Token: 0x06003224 RID: 12836 RVA: 0x000244F6 File Offset: 0x000226F6
		public string getCountyName(int countyID)
		{
			if (countyID >= 0 && countyID < this.countyList.Length)
			{
				return this.countyList[countyID].areaName;
			}
			return "";
		}

		// Token: 0x06003225 RID: 12837 RVA: 0x0002451A File Offset: 0x0002271A
		public string getProvinceName(int provinceID)
		{
			if (provinceID >= 0 && provinceID < this.provincesList.Length)
			{
				return this.provincesList[provinceID].areaName;
			}
			return "";
		}

		// Token: 0x06003226 RID: 12838 RVA: 0x0002453E File Offset: 0x0002273E
		public string getCountryName(int countryID)
		{
			if (countryID >= 0 && countryID < this.countryList.Length)
			{
				return this.countryList[countryID].areaName;
			}
			return "";
		}

		// Token: 0x06003227 RID: 12839 RVA: 0x00024562 File Offset: 0x00022762
		public int getCountryCapital(int countryID)
		{
			if (countryID >= 0 && countryID < this.countryList.Length)
			{
				return this.countryList[countryID].capitalVillage;
			}
			return -1;
		}

		// Token: 0x06003228 RID: 12840 RVA: 0x00024582 File Offset: 0x00022782
		public int getNumParishes()
		{
			return this.regionList.Length;
		}

		// Token: 0x06003229 RID: 12841 RVA: 0x0002458C File Offset: 0x0002278C
		public int getParishFromVillageID(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return (int)this.villageList[villageID].regionID;
			}
			return -1;
		}

		// Token: 0x0600322A RID: 12842 RVA: 0x000245AC File Offset: 0x000227AC
		public int getCountyFromVillageID(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				return (int)this.villageList[villageID].countyID;
			}
			return -1;
		}

		// Token: 0x0600322B RID: 12843 RVA: 0x00290854 File Offset: 0x0028EA54
		public int getProvinceFromVillageID(int villageID)
		{
			int countyFromVillageID = this.getCountyFromVillageID(villageID);
			if (countyFromVillageID >= 0)
			{
				return this.countyList[countyFromVillageID].parentID;
			}
			return -1;
		}

		// Token: 0x0600322C RID: 12844 RVA: 0x0029087C File Offset: 0x0028EA7C
		public int getCountryFromVillageID(int villageID)
		{
			int provinceFromVillageID = this.getProvinceFromVillageID(villageID);
			if (provinceFromVillageID >= 0)
			{
				return this.provincesList[provinceFromVillageID].parentID;
			}
			return -1;
		}

		// Token: 0x0600322D RID: 12845 RVA: 0x000245CC File Offset: 0x000227CC
		public void givePlaguesToParish(int parishID)
		{
			if (parishID >= 0 && parishID < this.regionList.Length && this.regionList[parishID].plague == 0)
			{
				this.regionList[parishID].plague = 1;
			}
		}

		// Token: 0x0600322E RID: 12846 RVA: 0x002908A4 File Offset: 0x0028EAA4
		public string getVillageAddress(int villageID)
		{
			int parishFromVillageID = this.getParishFromVillageID(villageID);
			int countyFromVillageID = this.getCountyFromVillageID(villageID);
			int provinceFromVillageID = this.getProvinceFromVillageID(villageID);
			int countryFromVillageID = this.getCountryFromVillageID(villageID);
			return string.Concat(new string[]
			{
				this.getParishName(parishFromVillageID),
				", ",
				this.getCountyName(countyFromVillageID),
				", ",
				this.getProvinceName(provinceFromVillageID),
				", ",
				this.getCountryName(countryFromVillageID)
			});
		}

		// Token: 0x0600322F RID: 12847 RVA: 0x0029091C File Offset: 0x0028EB1C
		public string getVillageDescription(int villageID)
		{
			string text = "";
			if (this.isCapital(villageID))
			{
				switch (this.getCapitalType(villageID))
				{
				case 0:
				{
					int countryFromVillageID = this.getCountryFromVillageID(villageID);
					text = SK.Text("TOUCH_Y_CountryCapital", "The Country Capital of");
					text = text + " " + this.getCountryName(countryFromVillageID);
					break;
				}
				case 1:
				{
					int provinceFromVillageID = this.getProvinceFromVillageID(villageID);
					text = SK.Text("TOUCH_Y_ProvinceCapital", "The Province Capital of");
					text = text + " " + this.getProvinceName(provinceFromVillageID);
					break;
				}
				case 2:
				{
					int countyFromVillageID = this.getCountyFromVillageID(villageID);
					text = SK.Text("TOUCH_Y_CountyCapital", "The County Capital of");
					text = text + " " + this.getCountyName(countyFromVillageID);
					break;
				}
				case 3:
					text = SK.Text("TOUCH_Y_ParishCapital", "Parish Capital");
					break;
				}
			}
			if (this.isSpecial(villageID))
			{
				text = SK.Text("TOUCH_Y_InParishOf", "In the parish of");
				text = text + " " + this.getParishNameFromVillageID(villageID);
			}
			return text;
		}

		// Token: 0x06003230 RID: 12848 RVA: 0x00290A28 File Offset: 0x0028EC28
		public bool isScoutHonourOutOfRange(int userVillageID, int targetVillageID)
		{
			if (userVillageID < 0 || targetVillageID < 0)
			{
				return false;
			}
			if (this.isCapital(userVillageID))
			{
				return false;
			}
			if (!this.isSpecial(targetVillageID))
			{
				return false;
			}
			int num = CardTypes.adjustScoutingHonourRange(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.BaseScoutHonourRange);
			int num2 = num * num;
			int x = (int)this.villageList[targetVillageID].x;
			int y = (int)this.villageList[targetVillageID].y;
			int x2 = (int)this.villageList[userVillageID].x;
			int y2 = (int)this.villageList[userVillageID].y;
			int num3 = (x - x2) * (x - x2) + (y - y2) * (y - y2);
			return num3 >= num2;
		}

		// Token: 0x06003231 RID: 12849 RVA: 0x00290AD4 File Offset: 0x0028ECD4
		public int[] getRoyalTowerCounts()
		{
			int[] array = new int[21];
			for (int i = 0; i < 21; i++)
			{
				array[i] = 0;
			}
			VillageData[] array2 = this.villageList;
			foreach (VillageData villageData in array2)
			{
				if (villageData.visible && SpecialVillageTypes.IS_ROYAL_TOWER(villageData.special))
				{
					int num = villageData.special - 200;
					if (num >= 0 && num < 21)
					{
						array[num]++;
					}
				}
			}
			return array;
		}

		// Token: 0x06003232 RID: 12850 RVA: 0x00290B5C File Offset: 0x0028ED5C
		public int countRemainingRoyalTowers()
		{
			int num = 0;
			return this.countRemainingRoyalTowers(ref num);
		}

		// Token: 0x06003233 RID: 12851 RVA: 0x00290B74 File Offset: 0x0028ED74
		public int countRemainingRoyalTowers(ref int total)
		{
			total = 0;
			int[] royalTowerCounts = this.getRoyalTowerCounts();
			int num = 0;
			int num2 = -1;
			int num3 = 0;
			for (int i = 1; i < 21; i++)
			{
				if (royalTowerCounts[i] > num3)
				{
					num3 = royalTowerCounts[i];
					num2 = i;
				}
			}
			for (int j = 0; j < 21; j++)
			{
				if (num2 != j)
				{
					num += royalTowerCounts[j];
				}
				total += royalTowerCounts[j];
			}
			return num;
		}

		// Token: 0x06003234 RID: 12852 RVA: 0x000245FA File Offset: 0x000227FA
		public bool isIslandWorld()
		{
			return WorldMapTypes.isIslandWorld(this.m_globalWorldID);
		}

		// Token: 0x06003235 RID: 12853 RVA: 0x00290BD8 File Offset: 0x0028EDD8
		public bool isIslandTravel(int fromVillageID, int targetVillageID)
		{
			int countyFromVillageID = this.getCountyFromVillageID(fromVillageID);
			int countyFromVillageID2 = this.getCountyFromVillageID(targetVillageID);
			return WorldMapTypes.isIslandTravel(this.m_globalWorldID, countyFromVillageID, countyFromVillageID2);
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x00290C04 File Offset: 0x0028EE04
		public double adjustIfIslandTravel(double distance, int homeVillage, int targetVillage)
		{
			if (WorldMapTypes.isIslandWorld(this.m_globalWorldID) && this.isIslandTravel(homeVillage, targetVillage))
			{
				int specialSeaConditionsData = this.SpecialSeaConditionsData;
				distance = WorldMapTypes.adjustTravelTimes(distance, specialSeaConditionsData);
			}
			return distance;
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x00024607 File Offset: 0x00022807
		public void clearVillageRolloverInfo(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length)
			{
				this.villageList[villageID].rolloverInfo = null;
			}
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x00290C3C File Offset: 0x0028EE3C
		public bool retrieveUserData(int villageID, int userID, ref WorldMap.VillageRolloverInfo villageInfo, ref WorldMap.CachedUserInfo userInfo, bool doServerRetrieve, bool forceExtended)
		{
			bool result;
			try
			{
				if (doServerRetrieve)
				{
					villageInfo = null;
				}
				villageInfo = null;
				userInfo = null;
				if (villageID >= 0)
				{
					userID = this.villageList[villageID].userID;
					if (userID == -1 && GameEngine.Instance.LocalWorldData.AIWorld)
					{
						this.getSpecial(villageID);
						switch (GameEngine.Instance.World.getSpecial(villageID))
						{
						case 7:
							userID = 1;
							break;
						case 9:
							userID = 2;
							break;
						case 11:
							userID = 3;
							break;
						case 13:
							userID = 4;
							break;
						}
					}
					villageInfo = this.villageList[villageID].rolloverInfo;
					if (villageInfo != null && (DateTime.Now - villageInfo.lastUpdateTime).TotalMinutes > 3.0)
					{
						villageInfo = null;
					}
				}
				bool flag = false;
				if (userID >= 0)
				{
					userInfo = (WorldMap.CachedUserInfo)this.cachedUserInfo[userID];
					if (userInfo != null)
					{
						if ((DateTime.Now - userInfo.lastUpdateTime).TotalMinutes > 2.0)
						{
							flag = true;
						}
						if (!flag && userInfo.villages == null)
						{
							flag = true;
						}
					}
				}
				if ((villageID < 0 || villageInfo != null) && (userID < 0 || (userInfo != null && !flag)))
				{
					result = true;
				}
				else
				{
					if (doServerRetrieve)
					{
						bool flag2 = false;
						if (userID >= 0)
						{
							if (userID == this.lastRetieveUserID && forceExtended == this.lastForceExtended)
							{
								if ((DateTime.Now - this.lastRetieveUserTime).TotalSeconds < 30.0 && (villageID < 0 || villageInfo != null || villageID == this.lastRetieveVillageID))
								{
									flag2 = true;
								}
								else
								{
									this.lastRetieveUserTime = DateTime.Now;
								}
							}
							else
							{
								this.lastRetieveUserID = userID;
								this.lastRetieveUserTime = DateTime.Now;
								this.lastForceExtended = forceExtended;
							}
						}
						else if (villageID == this.lastRetieveVillageID)
						{
							if ((DateTime.Now - this.lastRetieveVillageTime).TotalSeconds < 30.0)
							{
								flag2 = true;
							}
							else
							{
								this.lastRetieveVillageTime = DateTime.Now;
							}
						}
						else
						{
							this.lastRetieveVillageID = villageID;
							this.lastRetieveVillageTime = DateTime.Now;
						}
						if (!flag2)
						{
							if (forceExtended)
							{
								RemoteServices.Instance.set_RetrieveVillageUserInfo_UserCallBack(new RemoteServices.RetrieveVillageUserInfo_UserCallBack(this.villageUserInfoCallback));
								RemoteServices.Instance.RetrieveVillageUserInfo(villageID, userID, forceExtended);
								this.cached_retrieveVillageID = -1;
								this.cached_retrieveUserID = -1;
							}
							else if (this.cached_retrieveUserID != userID || this.cached_retrieveVillageID != villageID)
							{
								this.cached_retrieveUserID = userID;
								this.cached_retrieveVillageID = villageID;
								this.cached_retrieveVillageUserInfoDate = DateTime.Now;
							}
						}
					}
					result = false;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06003239 RID: 12857 RVA: 0x00024626 File Offset: 0x00022826
		public void clearCachedVillageUserInfo()
		{
			this.cached_retrieveVillageID = -1;
			this.cached_retrieveUserID = -1;
		}

		// Token: 0x0600323A RID: 12858 RVA: 0x00290EE0 File Offset: 0x0028F0E0
		public void monitorCachedVillageUserInfo()
		{
			if (this.cached_retrieveVillageID != -1 || this.cached_retrieveUserID != -1)
			{
				DateTime now = DateTime.Now;
				if ((now - this.cached_retrieveVillageUserInfoDate).TotalMilliseconds > 800.0)
				{
					RemoteServices.Instance.set_RetrieveVillageUserInfo_UserCallBack(new RemoteServices.RetrieveVillageUserInfo_UserCallBack(this.villageUserInfoCallback));
					RemoteServices.Instance.RetrieveVillageUserInfo(this.cached_retrieveVillageID, this.cached_retrieveUserID, false);
					this.cached_retrieveVillageID = -1;
					this.cached_retrieveUserID = -1;
				}
			}
		}

		// Token: 0x0600323B RID: 12859 RVA: 0x00290F60 File Offset: 0x0028F160
		public void villageUserInfoCallback(RetrieveVillageUserInfo_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.villageID >= 0)
			{
				WorldMap.VillageRolloverInfo villageRolloverInfo = new WorldMap.VillageRolloverInfo();
				villageRolloverInfo.lastUpdateTime = DateTime.Now;
				villageRolloverInfo.interdictionTime = returnData.interdictionDate;
				villageRolloverInfo.vacationMode = returnData.vacationMode;
				villageRolloverInfo.peaceTime = returnData.peaceTime;
				villageRolloverInfo.villageID = returnData.villageID;
				villageRolloverInfo.plagueLevel = returnData.plagueLevel;
				this.villageList[returnData.villageID].rolloverInfo = villageRolloverInfo;
				this.villageList[returnData.villageID].userID = returnData.userID;
				this.villageList[returnData.villageID].villageTerrain = (short)returnData.mapType;
				if (returnData.numVillageBuildings >= 255)
				{
					this.villageList[returnData.villageID].villageInfo = byte.MaxValue;
				}
				else
				{
					this.villageList[returnData.villageID].villageInfo = (byte)returnData.numVillageBuildings;
				}
				this.villageList[returnData.villageID].interdictionTime = returnData.interdictionDate;
				this.villageList[returnData.villageID].peaceTime = returnData.peaceTime;
				this.villageList[returnData.villageID].excommunicationTime = returnData.excommunicationTime;
				this.villageList[returnData.villageID].vacationMode = returnData.vacationMode;
			}
			if (returnData.userID < 0)
			{
				return;
			}
			WorldMap.CachedUserInfo cachedUserInfo = new WorldMap.CachedUserInfo();
			cachedUserInfo.userID = returnData.userID;
			cachedUserInfo.userName = returnData.userName;
			cachedUserInfo.rank = returnData.userRank;
			cachedUserInfo.numVillages = returnData.numVillages;
			cachedUserInfo.numQuests = returnData.numQuests;
			cachedUserInfo.completedQuests = returnData.completedQuests;
			cachedUserInfo.points = returnData.points;
			cachedUserInfo.standing = returnData.standing;
			cachedUserInfo.factionID = returnData.factionID;
			cachedUserInfo.lastUpdateTime = DateTime.Now;
			cachedUserInfo.avatarData = returnData.avatarData;
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				switch (returnData.userID)
				{
				case 1:
					cachedUserInfo.avatarData = Avatar.getRatAvatar();
					break;
				case 2:
					cachedUserInfo.avatarData = Avatar.getSnakeAvatar();
					break;
				case 3:
					cachedUserInfo.avatarData = Avatar.getPigAvatar();
					break;
				case 4:
					cachedUserInfo.avatarData = Avatar.getWolfAvatar();
					break;
				}
			}
			cachedUserInfo.avatarData.validateColours();
			if (cachedUserInfo.avatarBitmap != null)
			{
				cachedUserInfo.avatarBitmap.Dispose();
			}
			cachedUserInfo.avatarBitmap = Avatar.CreateAvatar(cachedUserInfo.avatarData, 214, global::ARGBColors.Transparent, false);
			if (returnData.villages != null)
			{
				cachedUserInfo.villages = returnData.villages.ToArray();
				cachedUserInfo.admin = returnData.admin;
				cachedUserInfo.moderator = returnData.moderator;
				cachedUserInfo.stuff = returnData.stuff;
			}
			if (returnData.achievements != null)
			{
				cachedUserInfo.achievements = returnData.achievements;
			}
			this.cachedUserInfo[returnData.userID] = cachedUserInfo;
		}

		// Token: 0x0600323C RID: 12860 RVA: 0x00024636 File Offset: 0x00022836
		public WorldMap.CachedUserInfo getStoredUserInfo(int userID)
		{
			return (WorldMap.CachedUserInfo)this.cachedUserInfo[userID];
		}

		// Token: 0x0600323D RID: 12861 RVA: 0x00024649 File Offset: 0x00022849
		public int getParishPlagueLevel(int villageID)
		{
			if (villageID >= 0 && villageID < this.villageList.Length && this.villageList[villageID].rolloverInfo != null)
			{
				return this.villageList[villageID].rolloverInfo.plagueLevel;
			}
			return -1;
		}

		// Token: 0x0600323E RID: 12862 RVA: 0x00291248 File Offset: 0x0028F448
		public WorldMap.SpecialVillageCache getSpecialVillageData(int villageID, bool download)
		{
			WorldMap.SpecialVillageCache specialVillageCache = null;
			if (villageID >= 0)
			{
				bool flag = false;
				if (this.specialVillageCache[villageID] == null)
				{
					flag = true;
				}
				else
				{
					specialVillageCache = (WorldMap.SpecialVillageCache)this.specialVillageCache[villageID];
					if ((DateTime.Now - specialVillageCache.lastUpdate).TotalMinutes > 1.0)
					{
						flag = true;
					}
					if (this.villageList[villageID].special > 100 && this.villageList[villageID].special <= 199)
					{
						int num = this.villageList[villageID].special - 100;
						if (num != specialVillageCache.resourceType)
						{
							this.specialVillageCache[villageID] = null;
							specialVillageCache = null;
						}
					}
					else
					{
						this.specialVillageCache[villageID] = null;
						specialVillageCache = null;
					}
				}
				if (flag && this.lastSpecialRequestSent != villageID)
				{
					bool flag2 = true;
					if (this.lastActualSpecialRequestSent == villageID && (DateTime.Now - this.lastActualSpecialRequestTime).TotalMinutes < 1.0)
					{
						flag2 = false;
					}
					if (flag2 && this.villageList[villageID].special > 100 && this.villageList[villageID].special <= 199)
					{
						RemoteServices.Instance.set_SpecialVillageInfo_UserCallBack(new RemoteServices.SpecialVillageInfo_UserCallBack(this.specialVillageInfoCallback));
						RemoteServices.Instance.SpecialVillageInfo(villageID);
						this.lastSpecialRequestSent = villageID;
						this.lastActualSpecialRequestSent = villageID;
						this.lastActualSpecialRequestTime = DateTime.Now;
					}
				}
			}
			return specialVillageCache;
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x002913B4 File Offset: 0x0028F5B4
		public void specialVillageInfoCallback(SpecialVillageInfo_ReturnType returnData)
		{
			this.lastSpecialRequestSent = -1;
			if (returnData.Success && returnData.villageID >= 0)
			{
				WorldMap.SpecialVillageCache specialVillageCache = new WorldMap.SpecialVillageCache();
				specialVillageCache.resourceType = returnData.resourceType;
				specialVillageCache.resourceLevel = returnData.resourceLevel;
				this.specialVillageCache[returnData.villageID] = specialVillageCache;
			}
		}

		// Token: 0x06003240 RID: 12864 RVA: 0x0002467D File Offset: 0x0002287D
		public List<LoginHistoryInfo> getLoginHistory(bool request)
		{
			if (this.loginHistory == null)
			{
				if (request)
				{
					RemoteServices.Instance.set_GetLoginHistory_UserCallBack(new RemoteServices.GetLoginHistory_UserCallBack(this.getLoginHistoryCallback));
					RemoteServices.Instance.GetLoginHistory();
				}
				return null;
			}
			return this.loginHistory;
		}

		// Token: 0x06003241 RID: 12865 RVA: 0x000246B2 File Offset: 0x000228B2
		public void getLoginHistoryCallback(GetLoginHistory_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.loginHistory = returnData.history;
			}
		}

		// Token: 0x06003242 RID: 12866 RVA: 0x000246C8 File Offset: 0x000228C8
		public void registerWorldIdentifier(int worldID)
		{
			if (worldID != this.m_globalWorldID)
			{
				this.m_globalWorldID = worldID;
			}
		}

		// Token: 0x06003243 RID: 12867 RVA: 0x000246DA File Offset: 0x000228DA
		public int GetGlobalWorldID()
		{
			return this.m_globalWorldID;
		}

		// Token: 0x06003244 RID: 12868 RVA: 0x000246E2 File Offset: 0x000228E2
		public void RetrievePreviousContestIDs()
		{
			this.previousContests.Clear();
			RemoteServices.Instance.set_GetContestHistoryIDs_UserCallBack(new RemoteServices.GetContestHistoryIDs_UserCallBack(this.RetrievePreviousContestIDsCallback));
			RemoteServices.Instance.GetContestHistoryIDs();
		}

		// Token: 0x06003245 RID: 12869 RVA: 0x0029140C File Offset: 0x0028F60C
		private void RetrievePreviousContestIDsCallback(GetContestHistoryIDs_ReturnType returnData)
		{
			if (!returnData.Success)
			{
				return;
			}
			for (int i = 0; i < returnData.contestIDs.Length; i++)
			{
				if (returnData.contestIDs[i] > 0)
				{
					this.previousContests.Add(returnData.contestIDs[i]);
				}
			}
			InterfaceMgr.Instance.getMainMenuBar().setContestLeaderboardButtonVisible(this.previousContests.Count > 0 || GameEngine.Instance.World.contestID > 0);
		}

		// Token: 0x06003246 RID: 12870 RVA: 0x00291488 File Offset: 0x0028F688
		public void downloadPlayerShield(string md5, ShieldFactory.AsyncDelegate callback)
		{
			this.playerShieldCallback = callback;
			if (this.playerShieldFactory == null)
			{
				this.playerShieldFactory = new ShieldFactory();
			}
			this.playerShieldFactory.clear();
			this.playerShield = null;
			this.playerShieldFactory.downloadPlayerShieldAsync(md5, new ShieldFactory.AsyncDelegate(this.shieldDownloaded));
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x0002470F File Offset: 0x0002290F
		public void shieldDownloaded()
		{
			if (this.playerShieldCallback != null)
			{
				this.playerShieldCallback();
			}
		}

		// Token: 0x06003248 RID: 12872 RVA: 0x00024724 File Offset: 0x00022924
		public Image getPlayerShieldImage(int width, int height)
		{
			return this.getPlayerShieldImage(width, height, width, height);
		}

		// Token: 0x06003249 RID: 12873 RVA: 0x002914DC File Offset: 0x0028F6DC
		public Image getPlayerShieldImage(int width, int height, int bmapWidth, int bmapHeight)
		{
			if (this.playerShieldFactory == null || !this.playerShieldFactory.PlayerAvailable)
			{
				return this.getDummyShield(width, height, bmapWidth, bmapHeight);
			}
			if (this.playerShield == null)
			{
				this.playerShield = this.playerShieldFactory.getPlayerShield();
			}
			if (this.playerShield != null)
			{
				Image sourceImage = this.playerShield.Render(width, height, bmapWidth, bmapHeight);
				return this.shieldOverlay(sourceImage, width, height, bmapWidth, bmapHeight);
			}
			return null;
		}

		// Token: 0x0600324A RID: 12874 RVA: 0x0029154C File Offset: 0x0028F74C
		public string getPlayerShieldString()
		{
			if (this.playerShieldFactory != null && this.playerShieldFactory.PlayerAvailable)
			{
				if (this.playerShield == null)
				{
					this.playerShield = this.playerShieldFactory.getPlayerShield();
				}
				if (this.playerShield != null)
				{
					return this.playerShield.getString();
				}
			}
			return "";
		}

		// Token: 0x0600324B RID: 12875 RVA: 0x002915A0 File Offset: 0x0028F7A0
		public void downloadWorldShields(int worldID)
		{
			this.activeShieldsWorldID = worldID;
			ShieldFactory shieldFactory = (ShieldFactory)this.worldShields[worldID];
			ShieldFactory shieldFactory2;
			if (shieldFactory != null)
			{
				shieldFactory2 = shieldFactory;
				if (!shieldFactory2.WorldsRequireRefresh(new TimeSpan(1, 0, 0)))
				{
					this.worldShieldsAvailable = true;
					this.clearShieldCache();
					return;
				}
				shieldFactory2.clearWorld();
			}
			else
			{
				shieldFactory2 = new ShieldFactory();
				this.worldShields[worldID] = shieldFactory2;
			}
			this.worldShieldsAvailable = false;
			this.clearShieldCache();
			shieldFactory2.downloadWorldShieldsAsync(worldID, new ShieldFactory.AsyncDelegate(this.worldShieldsDownloaded));
		}

		// Token: 0x0600324C RID: 12876 RVA: 0x00024730 File Offset: 0x00022930
		private void worldShieldsDownloaded()
		{
			this.worldShieldsAvailable = true;
			this.clearShieldCache();
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x00291628 File Offset: 0x0028F828
		public bool isWorldShieldAvailable(int playerID)
		{
			if (playerID == RemoteServices.Instance.UserID)
			{
				if (this.playerShieldFactory != null)
				{
					return this.playerShieldFactory.PlayerAvailable;
				}
			}
			else if (this.worldShieldsAvailable)
			{
				ShieldFactory shieldFactory = (ShieldFactory)this.worldShields[this.activeShieldsWorldID];
				if (shieldFactory != null && shieldFactory.WorldAvailable)
				{
					return shieldFactory.isWorldShieldAvailable(playerID);
				}
			}
			return false;
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x0029168C File Offset: 0x0028F88C
		public Image getWorldShieldOrBlank(int playerID, int width, int height)
		{
			Image image = this.getWorldShield(playerID, width, height, width, height);
			if (image == null)
			{
				image = this.getDummyShield(width, height);
			}
			return image;
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x0002473F File Offset: 0x0002293F
		public Image getWorldShield(int playerID, int width, int height)
		{
			return this.getWorldShield(playerID, width, height, width, height);
		}

		// Token: 0x06003250 RID: 12880 RVA: 0x002916B4 File Offset: 0x0028F8B4
		public Image getWorldShield(int playerID, int width, int height, int bmapWidth, int bmapHeight)
		{
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				switch (playerID)
				{
				case 1:
					playerID = -1;
					break;
				case 2:
					playerID = -2;
					break;
				case 3:
					playerID = -3;
					break;
				case 4:
					playerID = -4;
					break;
				}
			}
			if (playerID == RemoteServices.Instance.UserID)
			{
				return this.getPlayerShieldImage(width, height, bmapWidth, bmapHeight);
			}
			if (playerID < 0)
			{
				return this.renderAIShield(playerID, width, height, bmapWidth, bmapHeight);
			}
			if (this.worldShieldsAvailable)
			{
				ShieldFactory shieldFactory = (ShieldFactory)this.worldShields[this.activeShieldsWorldID];
				if (shieldFactory != null && shieldFactory.WorldAvailable)
				{
					Shield worldShield = shieldFactory.getWorldShield(playerID);
					if (worldShield != null)
					{
						Image sourceImage = worldShield.Render(width, height, bmapWidth, bmapHeight);
						return this.shieldOverlay(sourceImage, width, height, bmapWidth, bmapHeight);
					}
				}
			}
			return null;
		}

		// Token: 0x06003251 RID: 12881 RVA: 0x00291780 File Offset: 0x0028F980
		private Image shieldOverlay(Image sourceImage, int width, int height, int bmapWidth, int bmapHeight)
		{
			int width2 = width;
			int height2 = height;
			int x = 0;
			int y = 0;
			Image image = null;
			if (width == 140 && height == 156)
			{
				width2 = 158;
				height2 = 175;
				x = 8;
				y = 9;
				image = GFXLibrary.shieldOverlay_144x160;
			}
			else if (width == 69 && height == 77)
			{
				width2 = 81;
				height2 = 88;
				x = 4;
				y = 5;
				image = GFXLibrary.shieldOverlay_70x78;
			}
			else if (width == 47 && height == 54)
			{
				width2 = 55;
				height2 = 61;
				x = 3;
				y = 3;
				image = GFXLibrary.shieldOverlay_56x64;
			}
			else if (width == 32 && height == 36)
			{
				width2 = 37;
				height2 = 41;
				x = 2;
				y = 2;
				image = GFXLibrary.shieldOverlay_32x36;
			}
			else if (width == 25 && height == 28)
			{
				width2 = 30;
				height2 = 32;
				x = 2;
				y = 2;
				image = GFXLibrary.shieldOverlay_25x28;
			}
			if (image != null)
			{
				if (width != bmapWidth)
				{
					width2 = bmapWidth;
				}
				if (height != bmapHeight)
				{
					height2 = bmapHeight;
				}
				Bitmap bitmap = new Bitmap(width2, height2);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.PageUnit = GraphicsUnit.Pixel;
				if (sourceImage != null)
				{
					graphics.DrawImage(sourceImage, x, y, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height), GraphicsUnit.Pixel);
				}
				graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				return bitmap;
			}
			return sourceImage;
		}

		// Token: 0x06003252 RID: 12882 RVA: 0x002918E4 File Offset: 0x0028FAE4
		public Image getDummyShield(int width, int height)
		{
			Image sourceImage = Shield.RenderDummyShield(width, height);
			return this.shieldOverlay(sourceImage, width, height, width, height);
		}

		// Token: 0x06003253 RID: 12883 RVA: 0x00291904 File Offset: 0x0028FB04
		public Image getDummyShield(int width, int height, int bmapWidth, int bmapHeight)
		{
			Image sourceImage = Shield.RenderDummyShield(width, height, bmapWidth, bmapHeight);
			return this.shieldOverlay(sourceImage, width, height, bmapWidth, bmapHeight);
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x0002474C File Offset: 0x0002294C
		public int getWorldShieldTexture(int playerID)
		{
			return this.getWorldShieldTexture(playerID, false);
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x00291928 File Offset: 0x0028FB28
		public int getWorldShieldTexture(int playerID, bool force)
		{
			WorldMap.ShieldTextureCacheEntry shieldTextureCacheEntry = null;
			WorldMap.ShieldTextureCacheEntry shieldTextureCacheEntry2 = null;
			if (this.worldShieldCachePlayerIDs[playerID] != null)
			{
				int num = (int)this.worldShieldCachePlayerIDs[playerID];
				if (num >= 0)
				{
					if (num != 12345678)
					{
						return this.worldShieldCache[num].textureID;
					}
					if (!force)
					{
						return -1;
					}
				}
			}
			Bitmap bitmap = null;
			if (playerID == RemoteServices.Instance.UserID)
			{
				bitmap = (Bitmap)this.getWorldShield(playerID, 32, 36, 64, 64);
				if (bitmap == null && force)
				{
					bitmap = (Bitmap)this.getDummyShield(32, 36, 64, 64);
				}
			}
			else
			{
				bitmap = (Bitmap)this.getWorldShield(playerID, 25, 28, 32, 32);
				if (bitmap == null && force)
				{
					bitmap = (Bitmap)this.getDummyShield(25, 28, 32, 32);
				}
			}
			if (bitmap != null)
			{
				foreach (WorldMap.ShieldTextureCacheEntry shieldTextureCacheEntry3 in this.worldShieldCache)
				{
					if (shieldTextureCacheEntry == null && shieldTextureCacheEntry3.playerID < -1000)
					{
						shieldTextureCacheEntry = shieldTextureCacheEntry3;
						break;
					}
					if (shieldTextureCacheEntry2 == null || shieldTextureCacheEntry3.lastUsage < shieldTextureCacheEntry2.lastUsage)
					{
						shieldTextureCacheEntry2 = shieldTextureCacheEntry3;
					}
				}
				if (shieldTextureCacheEntry != null)
				{
					shieldTextureCacheEntry.playerID = playerID;
					shieldTextureCacheEntry.lastUsage = DateTime.Now;
					shieldTextureCacheEntry.textureID = GameEngine.Instance.GFX.loadTextureFromBitmap(bitmap, shieldTextureCacheEntry.textureID);
					this.worldShieldCachePlayerIDs[playerID] = shieldTextureCacheEntry.index;
					return shieldTextureCacheEntry.textureID;
				}
				if (this.worldShieldCache.Count < 125)
				{
					WorldMap.ShieldTextureCacheEntry shieldTextureCacheEntry4 = new WorldMap.ShieldTextureCacheEntry();
					shieldTextureCacheEntry4.playerID = playerID;
					shieldTextureCacheEntry4.lastUsage = DateTime.Now;
					shieldTextureCacheEntry4.textureID = GameEngine.Instance.GFX.loadTextureFromBitmap(bitmap);
					if (shieldTextureCacheEntry4.textureID >= 0)
					{
						shieldTextureCacheEntry4.index = this.worldShieldCache.Count;
						this.worldShieldCachePlayerIDs[playerID] = this.worldShieldCache.Count;
						this.worldShieldCache.Add(shieldTextureCacheEntry4);
						return shieldTextureCacheEntry4.textureID;
					}
				}
				if (shieldTextureCacheEntry2 != null)
				{
					this.worldShieldCachePlayerIDs[shieldTextureCacheEntry2.playerID] = -1;
					shieldTextureCacheEntry2.playerID = playerID;
					shieldTextureCacheEntry2.lastUsage = DateTime.Now;
					shieldTextureCacheEntry2.textureID = GameEngine.Instance.GFX.loadTextureFromBitmap(bitmap, shieldTextureCacheEntry2.textureID);
					this.worldShieldCachePlayerIDs[playerID] = shieldTextureCacheEntry2.index;
					return shieldTextureCacheEntry2.textureID;
				}
			}
			else
			{
				this.worldShieldCachePlayerIDs[playerID] = 12345678;
			}
			return -1;
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x00291BC0 File Offset: 0x0028FDC0
		public Image renderAIShield(int AI, int width, int height, int bmapWidth, int bmapHeight)
		{
			switch (AI)
			{
			case -4:
			{
				Image sourceImage = this.wolfShield.Render(width, height, bmapWidth, bmapHeight);
				return this.shieldOverlay(sourceImage, width, height, width, height);
			}
			case -3:
			{
				Image sourceImage2 = this.pigShield.Render(width, height, bmapWidth, bmapHeight);
				return this.shieldOverlay(sourceImage2, width, height, width, height);
			}
			case -2:
			{
				Image sourceImage3 = this.snakeShield.Render(width, height, bmapWidth, bmapHeight);
				return this.shieldOverlay(sourceImage3, width, height, width, height);
			}
			case -1:
			{
				Image sourceImage4 = this.ratShield.Render(width, height, bmapWidth, bmapHeight);
				return this.shieldOverlay(sourceImage4, width, height, width, height);
			}
			default:
				return null;
			}
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x00291C64 File Offset: 0x0028FE64
		public void clearShieldCache()
		{
			foreach (WorldMap.ShieldTextureCacheEntry shieldTextureCacheEntry in this.worldShieldCache)
			{
				shieldTextureCacheEntry.playerID = -10000;
			}
			this.worldShieldCachePlayerIDs.Clear();
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x00291CC8 File Offset: 0x0028FEC8
		public void setUserRelationship(int userID, int relationship, string username)
		{
			foreach (UserRelationship userRelationship in this.userRelations)
			{
				if (userRelationship.userID == userID)
				{
					if (relationship == 0)
					{
						this.userRelations.Remove(userRelationship);
						return;
					}
					userRelationship.friendly = (relationship > 0);
					return;
				}
			}
			if (relationship != 0)
			{
				UserRelationship userRelationship2 = new UserRelationship();
				userRelationship2.userID = userID;
				userRelationship2.userName = username;
				userRelationship2.friendly = (relationship > 0);
				this.userRelations.Add(userRelationship2);
			}
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x00291D68 File Offset: 0x0028FF68
		public int getUserRelationship(int userID)
		{
			foreach (UserRelationship userRelationship in this.userRelations)
			{
				if (userRelationship.userID == userID)
				{
					if (userRelationship.friendly)
					{
						return 1;
					}
					return -1;
				}
			}
			return 0;
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x00291DD0 File Offset: 0x0028FFD0
		public UserRelationship getUserRelationshipData(int userID)
		{
			foreach (UserRelationship userRelationship in this.userRelations)
			{
				if (userRelationship.userID == userID)
				{
					return userRelationship;
				}
			}
			return null;
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x00291E2C File Offset: 0x0029002C
		public UserMarker getUserMarker(int userID)
		{
			foreach (UserMarker userMarker in this.userMarkers)
			{
				if (userMarker.userID == userID)
				{
					return userMarker;
				}
			}
			return null;
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x00291E88 File Offset: 0x00290088
		public void setUserMarker(int userID, int markerType, string name)
		{
			foreach (UserMarker userMarker in this.userMarkers)
			{
				if (userMarker.userID == userID)
				{
					userMarker.markerType = markerType;
					userMarker.userName = name;
					return;
				}
			}
			UserMarker userMarker2 = new UserMarker();
			userMarker2.userID = userID;
			userMarker2.markerType = markerType;
			userMarker2.userName = name;
			this.userMarkers.Add(userMarker2);
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x00024756 File Offset: 0x00022956
		public void setLastTreasureCastleAttackTime(DateTime lastTime)
		{
			this.m_lastTreasureCastleAttackTime = lastTime;
		}

		// Token: 0x0600325E RID: 12894 RVA: 0x0002475F File Offset: 0x0002295F
		public DateTime getLastTreasureCastleAttackTime()
		{
			return this.m_lastTreasureCastleAttackTime;
		}

		// Token: 0x0600325F RID: 12895 RVA: 0x00291F14 File Offset: 0x00290114
		public void setTickets(int level, int number)
		{
			switch (level)
			{
			case -1:
				this.m_numQuestTickets = number;
				return;
			case 0:
				this.m_treasure1Tickets = number;
				return;
			case 1:
				this.m_treasure2Tickets = number;
				return;
			case 2:
				this.m_treasure3Tickets = number;
				return;
			case 3:
				this.m_treasure4Tickets = number;
				return;
			case 4:
				this.m_treasure5Tickets = number;
				return;
			default:
				return;
			}
		}

		// Token: 0x06003260 RID: 12896 RVA: 0x00291F74 File Offset: 0x00290174
		public int getTickets(int level)
		{
			switch (level)
			{
			case -1:
				return this.m_numQuestTickets;
			case 0:
				return this.m_treasure1Tickets;
			case 1:
				return this.m_treasure2Tickets;
			case 2:
				return this.m_treasure3Tickets;
			case 3:
				return this.m_treasure4Tickets;
			case 4:
				return this.m_treasure5Tickets;
			default:
				return 0;
			}
		}

		// Token: 0x06003261 RID: 12897 RVA: 0x00291FD0 File Offset: 0x002901D0
		public void addTickets(int level, int numberToUse)
		{
			switch (level)
			{
			case -1:
				this.m_numQuestTickets += numberToUse;
				return;
			case 0:
				this.m_treasure1Tickets += numberToUse;
				return;
			case 1:
				this.m_treasure2Tickets += numberToUse;
				return;
			case 2:
				this.m_treasure3Tickets += numberToUse;
				return;
			case 3:
				this.m_treasure4Tickets += numberToUse;
				return;
			case 4:
				this.m_treasure5Tickets += numberToUse;
				return;
			default:
				return;
			}
		}

		// Token: 0x06003262 RID: 12898 RVA: 0x00292058 File Offset: 0x00290258
		public void useTickets(int level, int numberToUse)
		{
			switch (level)
			{
			case -1:
				this.m_numQuestTickets -= numberToUse;
				return;
			case 0:
				this.m_treasure1Tickets -= numberToUse;
				return;
			case 1:
				this.m_treasure2Tickets -= numberToUse;
				return;
			case 2:
				this.m_treasure3Tickets -= numberToUse;
				return;
			case 3:
				this.m_treasure4Tickets -= numberToUse;
				return;
			case 4:
				this.m_treasure5Tickets -= numberToUse;
				return;
			default:
				return;
			}
		}

		// Token: 0x06003263 RID: 12899 RVA: 0x002920E0 File Offset: 0x002902E0
		public int numWheelTypesAvailable()
		{
			int num = 0;
			if (this.m_treasure1Tickets > 0)
			{
				num++;
			}
			if (this.m_treasure2Tickets > 0)
			{
				num++;
			}
			if (this.m_treasure3Tickets > 0)
			{
				num++;
			}
			if (this.m_treasure4Tickets > 0)
			{
				num++;
			}
			if (this.m_treasure5Tickets > 0)
			{
				num++;
			}
			if (this.m_numQuestTickets > 0)
			{
				num++;
			}
			return num;
		}

		// Token: 0x06003264 RID: 12900 RVA: 0x00292140 File Offset: 0x00290340
		private List<int> removeDuplicateQuests(List<int> availableQuests)
		{
			List<int> list = new List<int>();
			list.AddRange(this.m_newQuestData.completedQuests);
			List<int> list2 = new List<int>();
			foreach (int num in availableQuests)
			{
				if ((GameEngine.Instance.LocalWorldData.Alternate_Ruleset != 1 || (num - 188 > 2 && num - 197 > 1)) && !list.Contains(num) && !list2.Contains(num) && this.m_newQuestData.questID != num)
				{
					list2.Add(num);
				}
			}
			return list2;
		}

		// Token: 0x06003265 RID: 12901 RVA: 0x002921F4 File Offset: 0x002903F4
		public void setNewQuestData(NewQuestsData data)
		{
			try
			{
				if (data.availableQuests != null || this.m_newQuestData == null)
				{
					this.m_newQuestData = data;
					List<int> list = new List<int>();
					list.AddRange(this.m_newQuestData.availableQuests);
					list = this.removeDuplicateQuests(list);
					list.Sort(delegate(int first, int second)
					{
						int result;
						try
						{
							int num = NewQuests.questSortOrder[first];
							int value = NewQuests.questSortOrder[second];
							result = num.CompareTo(value);
						}
						catch (Exception)
						{
							result = first.CompareTo(second);
						}
						return result;
					});
					this.m_newQuestData.availableQuests = list.ToArray();
				}
				else
				{
					this.m_newQuestData.completionState = data.completionState;
					this.m_newQuestData.data = data.data;
					this.m_newQuestData.questID = data.questID;
					this.m_newQuestData.startingData = data.startingData;
					this.m_newQuestData.startTime = data.startTime;
					this.m_newQuestData.totalCompleted = data.totalCompleted;
				}
				int questID = this.m_newQuestData.questID;
				if (questID <= 48)
				{
					if (questID <= 16)
					{
						if (questID != 4 && questID != 16)
						{
							goto IL_12C;
						}
					}
					else if (questID != 34 && questID != 48)
					{
						goto IL_12C;
					}
				}
				else if (questID <= 84)
				{
					if (questID != 64 && questID != 84)
					{
						goto IL_12C;
					}
				}
				else if (questID != 101 && questID != 122)
				{
					goto IL_12C;
				}
				this.m_newQuestData.data = 1000;
				IL_12C:
				QuestsHelper.questReadyToHandIn = (QuestsHelper.isQuestComplete(this.m_newQuestData) || (this.m_newQuestData.questID < 0 && this.m_newQuestData.totalCompleted == 0));
				bool newQuests = QuestsHelper.questReadyToHandIn && GameEngine.Instance.GameDisplayMode != GameEngine.GameDisplays.DISPLAY_QUESTS;
				InterfaceMgr.Instance.getMainTabBar().newQuestsCompleted(newQuests);
			}
			catch
			{
				UniversalDebugLog.Log("setNewQuestData had an error");
			}
		}

		// Token: 0x06003266 RID: 12902 RVA: 0x00024767 File Offset: 0x00022967
		public NewQuestsData getNewQuestData()
		{
			return this.m_newQuestData;
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x0002476F File Offset: 0x0002296F
		public int[] getNewQuestList()
		{
			if (this.m_newQuestData != null)
			{
				return this.m_newQuestData.availableQuests;
			}
			return null;
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x00024786 File Offset: 0x00022986
		public void updateLastAttackerInfo()
		{
			if (!this.inUpdateLastAttackerInfo)
			{
				this.inUpdateLastAttackerInfo = true;
				RemoteServices.Instance.set_GetLastAttacker_UserCallBack(new RemoteServices.GetLastAttacker_UserCallBack(this.getLastAttackerCallback));
				RemoteServices.Instance.GetLastAttacker();
			}
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x002923B8 File Offset: 0x002905B8
		public void getLastAttackerCallback(GetLastAttacker_ReturnType returnData)
		{
			if (returnData.Success)
			{
				this.lastAttacker = returnData.lastAttacker;
				this.newPlayer = returnData.newPlayer;
				this.lastAttackerLastUpdate = DateTime.Now;
				InterfaceMgr.Instance.ParentForm.Enabled = false;
				if (!this.newPlayer)
				{
					GameEngine.Instance.openLostVillage(0);
				}
				else
				{
					GameEngine.Instance.openSimpleSelectVillage();
				}
			}
			this.inUpdateLastAttackerInfo = false;
		}

		// Token: 0x0600326A RID: 12906 RVA: 0x00292428 File Offset: 0x00290628
		public void setPlaybackData(List<WorldHouseHistoryItem> items, DateTime startDate)
		{
			if (items != null)
			{
				this.playbackItems = items;
				int num = 0;
				int num2 = 0;
				int num3 = (int)(VillageMap.getCurrentServerTime() - startDate).TotalDays + 1;
				int num4 = 10000000;
				foreach (WorldHouseHistoryItem worldHouseHistoryItem in items)
				{
					if (worldHouseHistoryItem.countryID > num)
					{
						num = worldHouseHistoryItem.countryID;
					}
					if (worldHouseHistoryItem.provinceID > num2)
					{
						num2 = worldHouseHistoryItem.provinceID;
					}
					int num5 = (int)(worldHouseHistoryItem.date - startDate).TotalDays;
					if (num5 < num4)
					{
						num4 = num5;
					}
				}
				num4 = ((num4 >= 20) ? (num4 - 20) : 0);
				if (items.Count == 0)
				{
					num4 = 0;
				}
				this.playbackTotalDays = num3 - num4;
				if (this.playbackTotalDays <= 0 || this.playbackTotalDays > 100000)
				{
					this.playbackTotalDays = 0;
					this.playbackItems = null;
					return;
				}
				this.playbackCountriesData = new int[this.playbackTotalDays, num + 1];
				this.playbackProvincesData = new int[this.playbackTotalDays, num2 + 1];
				this.playbackBasedDay = num4;
				foreach (WorldHouseHistoryItem worldHouseHistoryItem2 in items)
				{
					int num6 = (int)(worldHouseHistoryItem2.date - startDate).TotalDays - num4;
					if (worldHouseHistoryItem2.countryID >= 0)
					{
						this.playbackCountriesData[num6, worldHouseHistoryItem2.countryID] = worldHouseHistoryItem2.houseID;
					}
					if (worldHouseHistoryItem2.provinceID >= 0)
					{
						this.playbackProvincesData[num6, worldHouseHistoryItem2.provinceID] = worldHouseHistoryItem2.houseID;
					}
				}
				this.playbackMaxCountries = num + 1;
				this.playbackMaxProvinces = num2 + 1;
			}
		}

		// Token: 0x0600326B RID: 12907 RVA: 0x000247B7 File Offset: 0x000229B7
		private int getPlaybackCountryHouse(int day, int countryID)
		{
			if (day >= 0 && day < this.playbackTotalDays && countryID < this.playbackMaxCountries)
			{
				return this.playbackCountriesData[day, countryID];
			}
			return 0;
		}

		// Token: 0x0600326C RID: 12908 RVA: 0x000247DE File Offset: 0x000229DE
		private int getPlaybackProvinceHouse(int day, int provinceID)
		{
			if (day >= 0 && day < this.playbackTotalDays && provinceID < this.playbackMaxProvinces)
			{
				return this.playbackProvincesData[day, provinceID];
			}
			return 0;
		}

		// Token: 0x0600326D RID: 12909 RVA: 0x00024805 File Offset: 0x00022A05
		public bool gotPlaybackData()
		{
			return this.playbackItems != null;
		}

		// Token: 0x0600326E RID: 12910 RVA: 0x00024810 File Offset: 0x00022A10
		public void togglePlaybackPause()
		{
			this.playbackPaused = !this.playbackPaused;
			if (!this.playbackPaused)
			{
				this.playbackLastUpdateTime = DateTime.Now;
			}
		}

		// Token: 0x0600326F RID: 12911 RVA: 0x00292608 File Offset: 0x00290808
		public void playbackCountries()
		{
			if (this.gotPlaybackData())
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				GameEngine.Instance.mainTabChange(0);
				GameEngine.Instance.World.zoomOutMax();
				InterfaceMgr.Instance.togglePlaybackBarDXActive(true);
				this.playingCountries = true;
				this.playingProvinces = false;
				this.playbackDay = 0;
				this.lastSetPlaybackDay = 0;
				this.playbackStartTime = DateTime.Now;
				this.playbackBaseTime = DateTime.Now;
				this.playbackFrameTime = DateTime.Now;
				this.playbackLastUpdateTime = DateTime.Now;
				this.playbackFrameFraction = 0.0;
				this.playbackPaused = false;
				this.playbackFrameMS = 500.0;
			}
		}

		// Token: 0x06003270 RID: 12912 RVA: 0x002926C4 File Offset: 0x002908C4
		public void playbackProvinces()
		{
			if (this.gotPlaybackData())
			{
				InterfaceMgr.Instance.getMainTabBar().changeTab(0);
				GameEngine.Instance.mainTabChange(0);
				GameEngine.Instance.World.zoomOutMax();
				InterfaceMgr.Instance.togglePlaybackBarDXActive(true);
				this.playingCountries = false;
				this.playingProvinces = true;
				this.playbackDay = 0;
				this.lastSetPlaybackDay = 0;
				this.playbackStartTime = DateTime.Now;
				this.playbackBaseTime = DateTime.Now;
				this.playbackFrameTime = DateTime.Now;
				this.playbackLastUpdateTime = DateTime.Now;
				this.playbackFrameFraction = 0.0;
				this.playbackPaused = false;
				this.playbackFrameMS = 500.0;
			}
		}

		// Token: 0x06003271 RID: 12913 RVA: 0x00024834 File Offset: 0x00022A34
		public void setPlaybackDay(int day)
		{
			this.playbackBaseTime = DateTime.Now;
			this.playbackLastUpdateTime = DateTime.Now;
			this.lastSetPlaybackDay = day;
			this.playbackDay = day;
			this.playbackFrameFraction = 0.0;
		}

		// Token: 0x06003272 RID: 12914 RVA: 0x00292780 File Offset: 0x00290980
		public void updatePlaybackDay()
		{
			if (this.playbackPaused)
			{
				return;
			}
			double totalMilliseconds = (DateTime.Now - this.playbackLastUpdateTime).TotalMilliseconds;
			if (totalMilliseconds > 1.9 * this.playbackFrameMS)
			{
				this.playbackLastUpdateTime = DateTime.Now;
				return;
			}
			if (this.playbackDay < this.playbackTotalDays - 1)
			{
				this.playbackFrameFraction += totalMilliseconds / this.playbackFrameMS;
				if (this.playbackFrameFraction > 1.0)
				{
					this.playbackFrameFraction -= 1.0;
					this.playbackDay++;
				}
			}
			this.playbackLastUpdateTime = DateTime.Now;
		}

		// Token: 0x06003273 RID: 12915 RVA: 0x00024869 File Offset: 0x00022A69
		public void changePlaybackSpeed(double modifier)
		{
			this.playbackFrameMS = 500.0 / modifier;
			this.setPlaybackDay(this.playbackDay);
		}

		// Token: 0x06003274 RID: 12916 RVA: 0x00024888 File Offset: 0x00022A88
		public double getPlaybackFrameTime()
		{
			return this.playbackFrameMS;
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x00024890 File Offset: 0x00022A90
		public void stopPlayback()
		{
			this.playingCountries = false;
			this.playingProvinces = false;
			InterfaceMgr.Instance.togglePlaybackBarDXActive(false);
		}

		// Token: 0x06003276 RID: 12918 RVA: 0x000248AB File Offset: 0x00022AAB
		public int getPlaybackDay()
		{
			if (this.playingCountries || this.playingProvinces)
			{
				return this.playbackDay + this.playbackBasedDay;
			}
			return -1;
		}

		// Token: 0x06003277 RID: 12919 RVA: 0x000248CC File Offset: 0x00022ACC
		public bool playbackActive()
		{
			return this.playingCountries || this.playingProvinces;
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x000248DE File Offset: 0x00022ADE
		public void clearPlaybackData()
		{
			if (this.playbackActive())
			{
				this.stopPlayback();
			}
			this.playbackItems = null;
		}

		// Token: 0x06003279 RID: 12921 RVA: 0x00292834 File Offset: 0x00290A34
		public int countRatsCastles()
		{
			if (this.nextRatsCalc < DateTime.Now)
			{
				int num = 0;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.special == 7 && villageData.visible)
					{
						num++;
					}
				}
				this.lastRatsValue = num;
				this.nextRatsCalc = DateTime.Now.AddSeconds(30.0);
				return num;
			}
			return this.lastRatsValue;
		}

		// Token: 0x0600327A RID: 12922 RVA: 0x002928B4 File Offset: 0x00290AB4
		public int countSnakesCastles()
		{
			if (this.nextSnakesCalc < DateTime.Now)
			{
				int num = 0;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.special == 9 && villageData.visible)
					{
						num++;
					}
				}
				this.lastSnakesValue = num;
				this.nextSnakesCalc = DateTime.Now.AddSeconds(30.0);
				return num;
			}
			return this.lastSnakesValue;
		}

		// Token: 0x0600327B RID: 12923 RVA: 0x00292938 File Offset: 0x00290B38
		public int countPigsCastles()
		{
			if (this.nextPigsCalc < DateTime.Now)
			{
				int num = 0;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.special == 11 && villageData.visible)
					{
						num++;
					}
				}
				this.lastPigsValue = num;
				this.nextPigsCalc = DateTime.Now.AddSeconds(30.0);
				return num;
			}
			return this.lastPigsValue;
		}

		// Token: 0x0600327C RID: 12924 RVA: 0x002929BC File Offset: 0x00290BBC
		public int countWolfsCastles()
		{
			if (this.nextWolfsCalc < DateTime.Now)
			{
				int num = 0;
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.special == 13 && villageData.visible)
					{
						num++;
					}
				}
				this.lastWolfsValue = num;
				this.nextWolfsCalc = DateTime.Now.AddSeconds(30.0);
				return num;
			}
			return this.lastWolfsValue;
		}

		// Token: 0x0600327D RID: 12925 RVA: 0x000248F5 File Offset: 0x00022AF5
		public static Color getVillageColor(int colourid)
		{
			if (colourid < 0)
			{
				colourid = 0;
			}
			if (colourid >= WorldMap.villageColorList.Length)
			{
				colourid = 0;
			}
			return WorldMap.villageColorList[colourid];
		}

		// Token: 0x0600327E RID: 12926 RVA: 0x00292A40 File Offset: 0x00290C40
		public void drawVillageTree(GraphicsMgr newGFX)
		{
			this.xmasPresents = (HolidayPeriods.xmas(VillageMap.getCurrentServerTime()) && !GameEngine.Instance.LocalWorldData.AIWorld);
			this.pulse += 8;
			if (this.pulse > 255)
			{
				this.pulse -= 255;
			}
			if (this.pulse > 127)
			{
				this.pulseValue = 255 - this.pulse + 127;
			}
			else
			{
				this.pulseValue = this.pulse + 127;
			}
			Point point = new Point(0, 64);
			Point point2 = new Point(0, 144);
			this.gfx = newGFX;
			double num = (double)this.m_screenWidth / this.m_worldScale;
			double num2 = (double)this.m_screenHeight / this.m_worldScale;
			RectangleF screenRect = new RectangleF((float)(this.m_screenCentreX - num / 2.0), (float)(this.m_screenCentreY - num2 / 2.0), (float)num, (float)num2);
			if (this.m_worldScale == 24.0)
			{
				this.GeographicalMap = true;
				this.PoliticalMap = false;
			}
			else if (this.m_worldScale >= 7.0)
			{
				if (this.m_worldScale >= 23.899999998509884 && !this.Zooming)
				{
					this.m_worldScale = 24.0;
				}
				this.GeographicalMap = true;
				this.PoliticalMap = true;
			}
			else
			{
				this.GeographicalMap = false;
				this.PoliticalMap = true;
			}
			this.gfx.beginSprites();
			for (int i = 0; i < this.m_screenHeight; i += 512)
			{
				for (int j = 0; j < this.m_screenWidth; j += 512)
				{
					this.gfx.addSprite(GFXLibrary.Instance.ImageSurroundTexID2, new Rectangle(0, 0, 512, 512), new Size(512, 512), new PointF((float)j, (float)i));
				}
			}
			this.gfx.drawSprites();
			this.gfx.endSprites();
			float num3 = 0f;
			float num4 = 0f;
			float num5 = (float)this.worldMapWidth;
			float num6 = (float)this.worldMapHeight;
			this.gfx.startPoly();
			this.drawSurroundBox(screenRect, Color.FromArgb(64, global::ARGBColors.Black), num3 + 100f, num4 + 100f, num5 + 100f, num6 + 100f);
			this.drawSurroundBox(screenRect, Color.FromArgb(64, global::ARGBColors.Black), num3 + 75f, num4 + 75f, num5 + 75f, num6 + 75f);
			this.drawSurroundBox(screenRect, Color.FromArgb(64, global::ARGBColors.Black), num3 + 50f, num4 + 50f, num5 + 50f, num6 + 50f);
			this.drawSurroundBox(screenRect, Color.FromArgb(64, global::ARGBColors.Black), num3 + 25f, num4 + 25f, num5 + 25f, num6 + 25f);
			this.drawSurroundBox(screenRect, Color.FromArgb(192, global::ARGBColors.Black), num3 - 2f, num4 - 2f, num5 + 2f, num6 + 2f);
			this.drawSurroundBox(screenRect, WorldMap.SEACOLOR, num3, num4, num5, num6);
			this.gfx.drawBufferedPolygons();
			if (this.playingCountries)
			{
				this.updatePlaybackDay();
				this.drawCountryPolyPlayback(screenRect);
				this.drawSeas(screenRect);
				this.drawCountryBorders(screenRect);
				return;
			}
			if (this.playingProvinces)
			{
				this.updatePlaybackDay();
				this.drawProvincePolyPlayback(screenRect);
				this.drawSeas(screenRect);
				this.drawProvinceBorders(screenRect, true, !this.GeographicalMap);
				return;
			}
			if (this.GeographicalMap)
			{
				this.gfx.beginSprites();
				if (this.m_worldScale >= 3.0)
				{
					int num7 = (int)((-64f * screenRect.Width / (float)this.m_screenWidth + screenRect.Left) * 17f / 64f);
					int num8 = (int)((-64f * screenRect.Height / (float)this.m_screenHeight + screenRect.Top) * 17f / 64f);
					int num9 = (int)(((float)this.m_screenWidth * screenRect.Width / (float)this.m_screenWidth + screenRect.Left) * 17f / 64f);
					int num10 = (int)(((float)this.m_screenHeight * screenRect.Height / (float)this.m_screenHeight + screenRect.Top) * 17f / 64f);
					if (num7 < 0)
					{
						num7 = 0;
					}
					else if (num7 > this.TILEMAP_WIDTH - 1)
					{
						num7 = this.TILEMAP_WIDTH - 1;
					}
					if (num8 < 0)
					{
						num8 = 0;
					}
					else if (num8 > this.TILEMAP_HEIGHT - 1)
					{
						num8 = this.TILEMAP_HEIGHT - 1;
					}
					if (num9 < 0)
					{
						num9 = 0;
					}
					else if (num9 > this.TILEMAP_WIDTH - 1)
					{
						num9 = this.TILEMAP_WIDTH - 1;
					}
					if (num10 < 0)
					{
						num10 = 0;
					}
					else if (num10 > this.TILEMAP_HEIGHT - 1)
					{
						num10 = this.TILEMAP_HEIGHT - 1;
					}
					float num11 = (float)this.m_screenWidth / screenRect.Width;
					float num12 = (float)this.m_screenHeight / screenRect.Height;
					for (int k = num8; k <= num10; k++)
					{
						for (int l = num7; l <= num9; l++)
						{
							float num13 = (64f * (float)l / 17f - screenRect.Left) * num11;
							float num14 = (64f * (float)k / 17f - screenRect.Top) * num12;
							float num15 = (64f * ((float)l + 1f) / 17f - screenRect.Left) * num11;
							float num16 = (64f * ((float)k + 1f) / 17f - screenRect.Top) * num12;
							this.worldTileSprite.PosX = num13;
							this.worldTileSprite.PosY = num14;
							this.worldTileSprite.SpriteNo = (int)this.mapTileGrid[l, k];
							this.worldTileSprite.specialTileScaleAdjust(num15 - num13, num16 - num14);
							this.worldTileSprite.Update();
							this.worldTileSprite.Draw();
						}
					}
					this.gfx.drawSprites();
					for (int m = num8; m <= num10; m++)
					{
						for (int n = num7; n <= num9; n++)
						{
							if (this.tree1Grid[n, m] > 0)
							{
								float posX = (64f * (float)n / 17f - screenRect.Left) * num11;
								float posY = ((64f * (float)m - 8f) / 17f - screenRect.Top) * num12;
								float num17 = 64f * ((float)n + 1f) / 17f;
								float left = screenRect.Left;
								float num18 = 64f * ((float)m + 1f - 8f) / 17f;
								float top = screenRect.Top;
								this.worldTreeSprite.PosX = posX;
								this.worldTreeSprite.PosY = posY;
								this.worldTreeSprite.SpriteNo = (int)(this.tree1Grid[n, m] - 1);
								this.worldTreeSprite.Scale = (float)(this.m_worldScale / 23.611);
								this.worldTreeSprite.Update();
								this.worldTreeSprite.Draw();
							}
							if (this.tree2Grid[n, m] > 0)
							{
								float posX2 = (64f * (float)n / 17f - screenRect.Left) * num11;
								float posY2 = ((64f * (float)m - 8f) / 17f - screenRect.Top) * num12;
								float num19 = 64f * ((float)n + 1f) / 17f;
								float left2 = screenRect.Left;
								float num20 = 64f * ((float)m + 1f - 8f) / 17f;
								float top2 = screenRect.Top;
								this.worldTreeSprite.PosX = posX2;
								this.worldTreeSprite.PosY = posY2;
								this.worldTreeSprite.SpriteNo = (int)(this.tree2Grid[n, m] - 1);
								this.worldTreeSprite.Scale = (float)(this.m_worldScale / 23.611);
								this.worldTreeSprite.Update();
								this.worldTreeSprite.Draw();
							}
						}
					}
					this.gfx.drawSprites();
				}
				this.gfx.endSprites();
				this.manageDynamicLines();
				this.overrideLinelessMap = false;
				if (!this.PoliticalMap)
				{
					this.overrideLinelessMap = true;
					if (this.WorldZoom > 2.3)
					{
						if (this.WorldZoom >= 5.0)
						{
							this.drawRegionsBorder(screenRect, true);
						}
						this.drawCountyBorders(screenRect, true);
						this.drawCountryBorders(screenRect);
						this.drawProvinceBorders(screenRect, true, false);
						this.drawRangeCircle(screenRect);
						if (this.WorldZoom >= 13.0)
						{
							this.drawInterVillageLines(screenRect);
						}
					}
					else if (this.WorldZoom > 0.1)
					{
						this.drawCountryBorders(screenRect);
						this.drawProvinceBorders(screenRect, true, false);
						this.drawRangeCircle(screenRect);
					}
					else
					{
						this.drawProvinceBorders(screenRect, false, false);
						this.drawCountryBorders(screenRect);
						this.drawRangeCircle(screenRect);
					}
				}
			}
			if (this.PoliticalMap)
			{
				this.overrideLinelessMap = false;
				if (this.WorldZoom > 9.5)
				{
					this.overrideLinelessMap = true;
				}
				if (this.WorldZoom > 2.3)
				{
					this.drawCountyPoly(screenRect);
					this.drawSeas(screenRect);
					if (this.WorldZoom >= 5.0)
					{
						this.drawRegions(screenRect);
					}
					if (!this.LinelessMaps && this.WorldZoom >= 5.0)
					{
						this.drawRegionsBorder(screenRect, false);
					}
					this.drawCountyBorders(screenRect, true);
					this.drawCountryBorders(screenRect);
					this.drawProvinceBorders(screenRect, true, !this.GeographicalMap);
					this.drawRangeCircle(screenRect);
					if (this.WorldZoom >= 13.0)
					{
						this.drawInterVillageLines(screenRect);
					}
				}
				else if (this.WorldZoom > 0.1)
				{
					this.drawProvincePoly(screenRect);
					this.drawSeas(screenRect);
					this.drawCountryBorders(screenRect);
					this.drawProvinceBorders(screenRect, true, !this.GeographicalMap);
					this.drawRangeCircle(screenRect);
				}
				else
				{
					this.drawCountryPoly(screenRect);
					this.drawSeas(screenRect);
					this.drawProvinceBorders(screenRect, false, !this.GeographicalMap);
					this.drawCountryBorders(screenRect);
					this.drawRangeCircle(screenRect);
				}
				if (this.m_worldScale < 0.5)
				{
					this.drawIslandLines(screenRect);
				}
			}
			if (this.m_worldScale >= 23.999)
			{
				this.gfx.beginSprites();
				this.gfx.testBlending(true);
				int num21 = (int)(1000000.0 / this.m_worldScale) - (int)(this.m_screenCentreX * this.m_worldScale);
				int num22 = (int)(1000000.0 / this.m_worldScale) - (int)(this.m_screenCentreY * this.m_worldScale);
				int num23 = num21 / 512 * 512;
				num21 -= num23;
				int num24 = num22 / 512 * 512;
				num22 -= num24;
				while (num21 > 0)
				{
					num21 -= 512;
				}
				while (num22 > 0)
				{
					num22 -= 512;
				}
				for (int num25 = num22; num25 < this.m_screenHeight; num25 += 512)
				{
					for (int num26 = num21; num26 < this.m_screenWidth; num26 += 512)
					{
						this.overlaySprite.PosX = (float)num26;
						this.overlaySprite.PosY = (float)num25;
						this.overlaySprite.Update();
						this.overlaySprite.Draw();
					}
				}
				this.gfx.drawSprites();
				this.gfx.endSprites();
				this.gfx.testBlending(false);
			}
			else if (!Program.ShowSeasonalGraphics)
			{
				this.gfx.testBlending(true);
				this.gfx.startPoly();
				this.gfx.addTriangle(Color.FromArgb(251, 251, 213), 0f, 0f, (float)this.m_screenWidth, 0f, 0f, (float)this.m_screenHeight);
				this.gfx.addTriangle(Color.FromArgb(251, 251, 213), 0f, (float)this.m_screenHeight, (float)this.m_screenWidth, 0f, (float)this.m_screenWidth, (float)this.m_screenHeight);
				this.gfx.drawBufferedPolygons();
				this.gfx.testBlending(false);
			}
			this.gfx.beginSprites();
			this.drawVillages(screenRect);
			if (this.WorldZoom >= 5.5)
			{
				this.gfx.endSprites();
				this.gfx.beginSprites();
				if (InterfaceMgr.Instance.WorldMapMode != 1 && InterfaceMgr.Instance.WorldMapMode != 2)
				{
					this.gfx.setSpriteSamplerStateNone(false);
					if (!this.WorldEnded)
					{
						this.drawPeople(screenRect);
						this.drawTraders(screenRect);
						this.drawArmies(screenRect, true);
					}
					else
					{
						this.drawFW(screenRect);
					}
					this.gfx.setSpriteSamplerStateNone(true);
				}
			}
			else if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				this.gfx.endSprites();
				this.gfx.beginSprites();
				this.gfx.setSpriteSamplerStateNone(false);
				this.drawArmies(screenRect, false);
				this.gfx.setSpriteSamplerStateNone(true);
			}
			this.gfx.endSprites();
			this.drawText();
			this.gfx.renderLines();
			this.gfx.setSpriteSamplerStateNone(false);
			this.gfx.beginSprites();
			int clockMode = GameEngine.Instance.clockMode;
			if (clockMode != 1)
			{
				if (clockMode - 2 > 3)
				{
					this.updateClockSprite.SpriteNo = 69 + GameEngine.Instance.clockFrame;
				}
				else
				{
					this.updateClockSprite.SpriteNo = 197 + GameEngine.Instance.clockFrame;
				}
			}
			else
			{
				this.updateClockSprite.SpriteNo = 133 + GameEngine.Instance.clockFrame;
			}
			this.updateClockSprite.PosX = (float)this.m_screenWidth - 80f + 41f;
			this.updateClockSprite.PosY = -10f;
			this.updateClockSprite.Scale = 0.8f;
			this.updateClockSprite.Update();
			this.updateClockSprite.Draw();
			if ((this.isTutorialActive() || Program.mySettings.showGameFeaturesScreenIcon) && !this.WorldEnded)
			{
				if (!TutorialWindow.overIcon)
				{
					this.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconNormalID;
				}
				else
				{
					this.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconOverID;
				}
				this.tutorialOverlaySprite.PosX = 0f;
				this.tutorialOverlaySprite.PosY = (float)this.m_screenHeight - 64f;
				this.tutorialOverlaySprite.Update();
				this.tutorialOverlaySprite.Draw();
			}
			TimeSpan timeSpan = this.freeCardInfo.timeUntilNextFreeCard();
			if (timeSpan.TotalDays > 10.0 || timeSpan.TotalSeconds < 1.0)
			{
				this.freeCardsSprite2.SpriteNo = 4;
				this.freeCardsSprite2.PosX = (float)point.X;
				this.freeCardsSprite2.PosY = (float)point.Y;
				this.freeCardsSprite2.FakeWidthShrink = 0;
				this.freeCardsSprite2.ColorToUse = Color.FromArgb(Math.Max((this.pulseValue - 128) * 2, 0), global::ARGBColors.White);
				this.freeCardsSprite2.Center = new PointF(0f, 0f);
				this.freeCardsSprite2.defaultScaling();
				this.freeCardsSprite2.Update();
				this.freeCardsSprite2.Draw();
				if (!this.overIcon)
				{
					this.freeCardsSprite.SpriteNo = 2;
				}
				else
				{
					this.freeCardsSprite.SpriteNo = 3;
				}
				this.freeCardsSprite.PosX = (float)point.X;
				this.freeCardsSprite.PosY = (float)point.Y;
				int num27 = (this.pulseValue - 127) / 2 + 192;
				if (num27 > 255)
				{
					num27 = 255;
				}
				this.freeCardsSprite.ColorToUse = Color.FromArgb(num27, num27, num27);
				this.freeCardsSprite.Update();
				this.freeCardsSprite.Draw();
			}
			else
			{
				if (!this.overIcon)
				{
					this.freeCardsSprite.SpriteNo = 0;
				}
				else
				{
					this.freeCardsSprite.SpriteNo = 1;
				}
				this.freeCardsSprite.PosX = (float)point.X;
				this.freeCardsSprite.PosY = (float)point.Y;
				this.freeCardsSprite.ColorToUse = global::ARGBColors.White;
				this.freeCardsSprite.Update();
				this.freeCardsSprite.Draw();
				double num28 = this.freeCardInfo.durationHours();
				double totalHours = timeSpan.TotalHours;
				double num29 = totalHours / num28 * 50.0;
				this.freeCardsSprite2.ColorToUse = global::ARGBColors.White;
				this.freeCardsSprite2.SpriteNo = 5;
				this.freeCardsSprite2.FakeWidthShrink = (int)num29;
				this.freeCardsSprite2.PosX = (float)point.X;
				this.freeCardsSprite2.PosY = (float)point.Y;
				this.freeCardsSprite2.Update();
				this.freeCardsSprite2.Draw();
			}
			if (this.numWheelTypesAvailable() > 0)
			{
				this.ticketsSprite2.SpriteNo = 4;
				this.ticketsSprite2.PosX = (float)point2.X;
				this.ticketsSprite2.PosY = (float)point2.Y;
				this.ticketsSprite2.FakeWidthShrink = 0;
				this.ticketsSprite2.ColorToUse = Color.FromArgb(Math.Max((this.pulseValue - 128) * 2, 0), global::ARGBColors.White);
				this.ticketsSprite2.Center = new PointF(0f, 0f);
				this.ticketsSprite2.defaultScaling();
				this.ticketsSprite2.Update();
				this.ticketsSprite2.Draw();
				this.ticketsSprite2.Draw();
				if (!this.overTicketsIcon)
				{
					this.ticketsSprite.SpriteNo = 23;
				}
				else
				{
					this.ticketsSprite.SpriteNo = 24;
				}
				this.ticketsSprite.PosX = 0f;
				this.ticketsSprite.PosY = 144f;
				int num30 = (this.pulseValue - 127) / 2 + 192;
				if (num30 > 255)
				{
					num30 = 255;
				}
				this.ticketsSprite.ColorToUse = Color.FromArgb(num30, num30, num30);
				this.ticketsSprite.Update();
				this.ticketsSprite.Draw();
			}
			if (GameEngine.Instance.LocalWorldData.AIWorld && this.isInWolfsRevenge())
			{
				this.wolfsRevengeSprite.SpriteNo = 30;
				this.wolfsRevengeSprite.PosX = 0f;
				this.wolfsRevengeSprite.PosY = 224f;
				this.wolfsRevengeSprite.ColorToUse = global::ARGBColors.White;
				this.wolfsRevengeSprite.Update();
				this.wolfsRevengeSprite.Draw();
				double totalHours2 = (this.wolfsRevengeEnd - this.wolfsRevengeStart).TotalHours;
				double totalHours3 = (this.wolfsRevengeEnd - VillageMap.getCurrentServerTime()).TotalHours;
				if (totalHours2 > 0.0 && totalHours3 > 0.0)
				{
					double num31 = totalHours3 / totalHours2 * 50.0;
					this.wolfsRevengeSprite2.ColorToUse = global::ARGBColors.White;
					this.wolfsRevengeSprite2.FakeWidthShrink = (int)num31;
					this.wolfsRevengeSprite2.SpriteNo = 31;
					this.wolfsRevengeSprite2.PosX = 0f;
					this.wolfsRevengeSprite2.PosY = 224f;
					this.wolfsRevengeSprite2.Update();
					this.wolfsRevengeSprite2.Draw();
				}
			}
			if (this.isIslandWorld())
			{
				this.seaSprite.SpriteNo = 58 + this.SpecialSeaConditionsData + 4;
				this.seaSprite.PosX = (float)this.m_screenWidth - 110f;
				this.seaSprite.PosY = 0f;
				this.seaSprite.ColorToUse = global::ARGBColors.White;
				this.seaSprite.Update();
				this.seaSprite.Draw();
			}
			if (this.SeventhAgeWorld && !GameEngine.Instance.LocalWorldData.AIWorld)
			{
				if (this.overRoyalTower)
				{
					this.royalTowerSprite.SpriteNo = 264;
				}
				else
				{
					this.royalTowerSprite.SpriteNo = 262;
				}
				this.royalTowerSprite.PosX = -10f;
				this.royalTowerSprite.PosY = 239f;
				this.royalTowerSprite.ColorToUse = global::ARGBColors.White;
				this.royalTowerSprite.Update();
				this.royalTowerSprite.Draw();
				int num32 = this.countRemainingRoyalTowers();
				if (num32 >= 100)
				{
					int num33 = num32 / 100;
					int num34 = num32 % 100 / 10;
					int num35 = num32 % 10;
					if (num33 == 0)
					{
						this.royalTowerSprite2.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite1.SpriteNo = 33 + num33;
					}
					this.royalTowerSprite1.PosX = -4f;
					this.royalTowerSprite1.PosY = 309f;
					this.royalTowerSprite1.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite1.Update();
					this.royalTowerSprite1.Draw();
					if (num34 == 0)
					{
						this.royalTowerSprite2.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite2.SpriteNo = 33 + num34;
					}
					this.royalTowerSprite2.PosX = 23f;
					this.royalTowerSprite2.PosY = 309f;
					this.royalTowerSprite2.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite2.Update();
					this.royalTowerSprite2.Draw();
					if (num35 == 0)
					{
						this.royalTowerSprite3.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite3.SpriteNo = 33 + num35;
					}
					this.royalTowerSprite3.PosX = 50f;
					this.royalTowerSprite3.PosY = 309f;
					this.royalTowerSprite3.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite3.Update();
					this.royalTowerSprite3.Draw();
				}
				else if (num32 >= 10)
				{
					int num36 = num32 / 10;
					int num37 = num32 % 10;
					if (num36 == 0)
					{
						this.royalTowerSprite2.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite1.SpriteNo = 33 + num36;
					}
					this.royalTowerSprite1.PosX = 6f;
					this.royalTowerSprite1.PosY = 309f;
					this.royalTowerSprite1.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite1.Update();
					this.royalTowerSprite1.Draw();
					if (num37 == 0)
					{
						this.royalTowerSprite2.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite2.SpriteNo = 33 + num37;
					}
					this.royalTowerSprite2.PosX = 36f;
					this.royalTowerSprite2.PosY = 309f;
					this.royalTowerSprite2.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite2.Update();
					this.royalTowerSprite2.Draw();
				}
				else
				{
					if (num32 == 0)
					{
						this.royalTowerSprite1.SpriteNo = 43;
					}
					else
					{
						this.royalTowerSprite1.SpriteNo = 33 + num32;
					}
					this.royalTowerSprite1.PosX = 23f;
					this.royalTowerSprite1.PosY = 309f;
					this.royalTowerSprite1.ColorToUse = global::ARGBColors.White;
					this.royalTowerSprite1.Update();
					this.royalTowerSprite1.Draw();
				}
			}
			DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleStartTime);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleEndTime);
			bool flag = false;
			if (t <= VillageMap.getCurrentServerTime() && dateTime > VillageMap.getCurrentServerTime())
			{
				flag = true;
				TimeSpan timeSpan2 = dateTime - VillageMap.getCurrentServerTime();
				this.saleSprite.ColorToUse = global::ARGBColors.White;
				this.saleSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				int num38 = 0;
				if (!this.overSale)
				{
					this.saleSprite.SpriteNo = 32;
				}
				else
				{
					num38 = 12;
					this.saleSprite.SpriteNo = 33;
				}
				this.saleSprite.PosX = (float)this.m_screenWidth - 140f;
				if (timeSpan2.Hours < 24)
				{
					this.saleSprite.PosY = (float)this.m_screenHeight - 160f;
				}
				else
				{
					this.saleSprite.PosY = (float)this.m_screenHeight - 130f;
				}
				this.saleSprite.Update();
				this.saleSprite.Draw();
				bool flag2 = GameEngine.Instance.World.salePercentage - 99 > 0;
				int num39 = GameEngine.Instance.World.salePercentage;
				this.saleDigits[0].SpriteNo = 44 + num38;
				this.saleDigits[this.saleDigits.Count - 1].SpriteNo = 45 + num38;
				List<int> list = new List<int>();
				list.Add(num39 / (flag2 ? 100 : 10));
				list.Add((num39 - list[0] * (flag2 ? 100 : 10)) / ((!flag2) ? 1 : 10));
				if (flag2)
				{
					list.Add(flag2 ? (num39 - list[0] * 100 - list[1] * 10) : 0);
				}
				for (int num40 = 0; num40 < list.Count; num40++)
				{
					int num41 = list[num40];
					if (num41 == 0)
					{
						this.saleDigits[num40 + 1].SpriteNo = 43 + num38;
					}
					else
					{
						this.saleDigits[num40 + 1].SpriteNo = 33 + num41 + num38;
					}
				}
				float num42 = this.saleSprite.PosX + (float)(flag2 ? -20 : 10);
				foreach (SpriteWrapper spriteWrapper in this.saleDigits)
				{
					spriteWrapper.PosX = num42;
					spriteWrapper.PosY = this.saleSprite.PosY + 70f;
					spriteWrapper.Update();
					spriteWrapper.Draw();
					num42 += 20f;
				}
				if (timeSpan2.TotalHours < 24.0)
				{
					List<int> list2 = new List<int>();
					int hours = timeSpan2.Hours;
					int minutes = timeSpan2.Minutes;
					if (hours < 10)
					{
						list2.Add(-1);
					}
					else
					{
						list2.Add((hours - hours % 10) / 10);
					}
					if (hours > 0)
					{
						list2.Add(hours % 10);
					}
					else
					{
						list2.Add(0);
					}
					list2.Add(0);
					if (minutes < 10)
					{
						list2.Add(0);
					}
					else
					{
						list2.Add((minutes - minutes % 10) / 10);
					}
					if (minutes > 0)
					{
						list2.Add(minutes % 10);
					}
					else
					{
						list2.Add(0);
					}
					for (int num43 = 0; num43 < 5; num43++)
					{
						int num44 = list2[num43];
						if (num43 == 2)
						{
							this.saleTimer[num43].SpriteNo = 271;
						}
						else if (num44 == 0)
						{
							this.saleTimer[num43].SpriteNo = 43;
						}
						else
						{
							this.saleTimer[num43].SpriteNo = 33 + num44;
						}
					}
					num42 = this.saleSprite.PosX + 20f;
					for (int num45 = 0; num45 < 5; num45++)
					{
						if (list2[num45] > -1)
						{
							if (num45 == 2)
							{
								this.saleTimer[num45].PosX = num42 + 2f;
								num42 += 13f;
							}
							else
							{
								this.saleTimer[num45].PosX = num42;
								num42 += 18f;
							}
							this.saleTimer[num45].PosY = this.saleSprite.PosY + this.saleSprite.Height + 5f;
							this.saleTimer[num45].Update();
							this.saleTimer[num45].Draw();
							this.saleTimer[num45].Scale = 0.8f;
						}
					}
					this.saleClock.TextureID = GFXLibrary.Instance.FreeCardIconsID;
					this.saleClock.SpriteNo = 270;
					this.saleClock.PosX = this.saleSprite.PosX - 10f;
					this.saleClock.PosY = this.saleSprite.PosY + this.saleSprite.Height - 3f;
					this.saleClock.Scale = 0.8f;
					this.saleClock.Update();
					this.saleClock.Draw();
				}
			}
			if (GameEngine.Instance.cardsManager.PremiumOfferAvailable())
			{
				this.offerSprite.ColorToUse = global::ARGBColors.White;
				this.offerSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				if (!this.overOffer)
				{
					this.offerSprite.SpriteNo = 272;
				}
				else
				{
					this.offerSprite.SpriteNo = 273;
				}
				this.offerSprite.PosX = (float)this.m_screenWidth - 140f;
				if (flag)
				{
					this.offerSprite.PosY = (float)this.m_screenHeight - 160f - 160f;
				}
				else
				{
					this.offerSprite.PosY = (float)this.m_screenHeight - 160f;
				}
				this.offerSprite.Update();
				this.offerSprite.Draw();
				TimeSpan t2 = TimeSpan.Zero;
				PremiumOfferData[] premiumOffers = GameEngine.Instance.cardsManager.PremiumOffers;
				foreach (PremiumOfferData premiumOfferData in premiumOffers)
				{
					TimeSpan timeSpan3 = premiumOfferData.ExpirationDate - VillageMap.getCurrentServerTime();
					if (timeSpan3 > t2)
					{
						t2 = timeSpan3;
					}
				}
				if (t2.TotalSeconds > 0.0)
				{
					float num47 = this.offerSprite.PosX;
					List<int> list3 = new List<int>();
					int days = t2.Days;
					int hours2 = t2.Hours;
					int minutes2 = t2.Minutes;
					if (days < 10)
					{
						list3.Add(-1);
					}
					else
					{
						list3.Add((days - days % 10) / 10);
					}
					if (days > 0)
					{
						list3.Add(days % 10);
						list3.Add(0);
					}
					else
					{
						list3.Add(-1);
						list3.Add(-1);
					}
					if (hours2 < 10)
					{
						list3.Add(0);
					}
					else
					{
						list3.Add((hours2 - hours2 % 10) / 10);
					}
					if (hours2 > 0)
					{
						list3.Add(hours2 % 10);
					}
					else
					{
						list3.Add(0);
					}
					list3.Add(0);
					if (minutes2 < 10)
					{
						list3.Add(0);
					}
					else
					{
						list3.Add((minutes2 - minutes2 % 10) / 10);
					}
					if (minutes2 > 0)
					{
						list3.Add(minutes2 % 10);
					}
					else
					{
						list3.Add(0);
					}
					for (int num48 = 0; num48 < 8; num48++)
					{
						int num49 = list3[num48];
						if (num48 == 2 || num48 == 5)
						{
							this.offerTimer[num48].SpriteNo = 271;
						}
						else if (num49 == 0)
						{
							this.offerTimer[num48].SpriteNo = 43;
						}
						else
						{
							this.offerTimer[num48].SpriteNo = 33 + num49;
						}
					}
					for (int num50 = 0; num50 < 8; num50++)
					{
						if (list3[num50] > -1)
						{
							if (num50 == 2 || num50 == 5)
							{
								this.offerTimer[num50].PosX = num47 + 2f;
								num47 += 13f;
							}
							else
							{
								this.offerTimer[num50].PosX = num47;
								num47 += 18f;
							}
							this.offerTimer[num50].PosY = this.offerSprite.PosY + this.offerSprite.Height + 5f;
							this.offerTimer[num50].Update();
							this.offerTimer[num50].Draw();
							this.offerTimer[num50].Scale = 0.8f;
						}
					}
					this.offerClock.TextureID = GFXLibrary.Instance.FreeCardIconsID;
					this.offerClock.SpriteNo = 270;
					if (days > 9)
					{
						this.offerClock.PosX = this.offerSprite.PosX - 50f;
					}
					else
					{
						this.offerClock.PosX = this.offerSprite.PosX - 30f;
					}
					this.offerClock.PosY = this.offerSprite.PosY + this.offerSprite.Height - 3f;
					this.offerClock.Scale = 0.8f;
					this.offerClock.Update();
					this.offerClock.Draw();
				}
			}
			bool flag3 = false;
			if (GameEngine.Instance.World.pendingPrizes.Count > 0)
			{
				this.contestSprite.ColorToUse = Color.FromArgb(this.contestPulseValue, this.contestPulseValue, this.contestPulseValue);
				this.contestPulseValue += this.contestPulse;
				if (this.contestPulseValue >= 255)
				{
					this.contestPulse = -3;
				}
				else if (this.contestPulseValue <= 200)
				{
					this.contestPulse = 3;
				}
				this.contestSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				if (!this.overContest)
				{
					this.contestSprite.SpriteNo = 267;
				}
				else
				{
					this.contestSprite.SpriteNo = 268;
				}
				flag3 = true;
			}
			else if (GameEngine.Instance.World.contestID >= 0)
			{
				DateTime t3 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime);
				DateTime t4 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
				if (t3 <= VillageMap.getCurrentServerTime() && t4 > VillageMap.getCurrentServerTime())
				{
					if (Program.mySettings.LastContestViewed != GameEngine.Instance.World.contestID)
					{
						this.contestSprite.ColorToUse = Color.FromArgb(this.contestPulseValue, this.contestPulseValue, this.contestPulseValue);
						this.contestPulseValue += this.contestPulse;
						if (this.contestPulseValue >= 255)
						{
							this.contestPulse = -3;
						}
						else if (this.contestPulseValue <= 200)
						{
							this.contestPulse = 3;
						}
					}
					else
					{
						this.contestSprite.ColorToUse = global::ARGBColors.White;
					}
					if (!this.overContest)
					{
						this.contestSprite.SpriteNo = 265;
					}
					else
					{
						this.contestSprite.SpriteNo = 266;
					}
					flag3 = true;
				}
			}
			if (flag3)
			{
				this.contestSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				this.contestSprite.PosX = 0f;
				if (this.isTutorialActive() || Program.mySettings.showGameFeaturesScreenIcon)
				{
					this.contestSprite.PosY = (float)this.m_screenHeight - 130f - 64f + 32f;
				}
				else
				{
					this.contestSprite.PosY = (float)this.m_screenHeight - 130f + 32f;
				}
				this.contestSprite.Update();
				this.contestSprite.Scale = 0.75f;
				this.contestSprite.Draw();
			}
			if (this.overWikiHelp)
			{
				this.gfx.addSprite(GFXLibrary.Instance.WikiHelpIconOver, new Rectangle(0, 0, 64, 64), new Size(40, 40), new PointF((float)(this.m_screenWidth - 80 + 41 + 11), 32f));
			}
			else
			{
				this.gfx.addSprite(GFXLibrary.Instance.WikiHelpIconNormal, new Rectangle(0, 0, 64, 64), new Size(40, 40), new PointF((float)(this.m_screenWidth - 80 + 41 + 11), 32f));
			}
			this.gfx.drawSprites();
			this.gfx.endSprites();
			this.gfx.setSpriteSamplerStateNone(true);
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x00294F54 File Offset: 0x00293154
		public void freeCardTooltip(Point dxMousePos)
		{
			this.overIcon = false;
			if (dxMousePos.X < 70 && dxMousePos.Y >= 64 && dxMousePos.Y < 134)
			{
				this.overIcon = true;
				CustomTooltipManager.MouseEnterTooltipArea(10500);
			}
			this.overTicketsIcon = false;
			if (dxMousePos.X < 70 && dxMousePos.Y >= 144 && dxMousePos.Y < 214 && this.numWheelTypesAvailable() > 0)
			{
				this.overTicketsIcon = true;
				CustomTooltipManager.MouseEnterTooltipArea(10501);
			}
			this.overWikiHelp = false;
			if (dxMousePos.X > this.m_screenWidth - 30 && dxMousePos.Y > 30 && dxMousePos.Y < 60)
			{
				this.overWikiHelp = true;
				CustomTooltipManager.MouseEnterTooltipArea(4400, 0);
			}
			this.overWolf = false;
			this.overRoyalTower = false;
			if (GameEngine.Instance.LocalWorldData.AIWorld)
			{
				if (dxMousePos.X < 70 && dxMousePos.Y >= 224 && dxMousePos.Y < 294 && this.isInWolfsRevenge())
				{
					this.overWolf = true;
					CustomTooltipManager.MouseEnterTooltipArea(10502, (int)(this.wolfsRevengeEnd - VillageMap.getCurrentServerTime()).TotalSeconds);
				}
			}
			else if (this.SeventhAgeWorld && !GameEngine.Instance.LocalWorldData.AIWorld && dxMousePos.X < 90 && dxMousePos.Y >= 262 && dxMousePos.Y < 342)
			{
				this.overRoyalTower = true;
				CustomTooltipManager.MouseEnterTooltipArea(24000);
			}
			this.overSale = false;
			DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleStartTime);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleEndTime);
			bool flag = t <= VillageMap.getCurrentServerTime() && dateTime > VillageMap.getCurrentServerTime();
			if (dxMousePos.X > this.m_screenWidth - 140 && dxMousePos.Y > this.m_screenHeight - 130 && flag)
			{
				CustomTooltipManager.MouseEnterTooltipArea(25100, (int)(dateTime - VillageMap.getCurrentServerTime()).TotalSeconds);
				this.overSale = true;
			}
			this.overOffer = false;
			if (GameEngine.Instance.cardsManager.PremiumOfferAvailable())
			{
				int num = this.m_screenHeight - 130;
				if (flag)
				{
					num = this.m_screenHeight - 130 - 160;
				}
				if (dxMousePos.X > this.m_screenWidth - 140 && dxMousePos.Y > num && dxMousePos.Y < num + 130)
				{
					this.overOffer = true;
					CustomTooltipManager.MouseEnterTooltipArea(25101);
				}
			}
			if (dxMousePos.X > this.m_screenWidth - 110 && dxMousePos.X < this.m_screenWidth - 40 && dxMousePos.Y < 85 && this.isIslandWorld())
			{
				int num2 = this.SpecialSeaConditionsData + 4;
				CustomTooltipManager.MouseEnterTooltipArea(23010 + num2, 0);
			}
			this.overContest = false;
			if ((float)dxMousePos.X >= this.contestSprite.Width || (float)dxMousePos.Y <= this.contestSprite.PosY || (float)dxMousePos.Y >= this.contestSprite.PosY + this.contestSprite.Height)
			{
				return;
			}
			if (GameEngine.Instance.World.pendingPrizes.Count > 0)
			{
				CustomTooltipManager.MouseEnterTooltipArea(25001, GameEngine.Instance.World.pendingPrizes.Count);
				this.overContest = true;
				return;
			}
			if (GameEngine.Instance.World.contestID >= 0)
			{
				DateTime t2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime);
				DateTime dateTime2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
				if (t2 <= VillageMap.getCurrentServerTime() && dateTime2 > VillageMap.getCurrentServerTime())
				{
					this.overContest = true;
					CustomTooltipManager.MouseEnterTooltipArea(25002, (int)(dateTime2 - VillageMap.getCurrentServerTime()).TotalSeconds);
				}
			}
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x002953D0 File Offset: 0x002935D0
		private bool shouldDrawMapIcon(VillageData village)
		{
			if (!this.worldMapFilter.showVillage(village))
			{
				return false;
			}
			if (InterfaceMgr.Instance.WorldMapMode != 0)
			{
				if (InterfaceMgr.Instance.WorldMapMode == 1)
				{
					if (this.isSpecial(village.id))
					{
						return false;
					}
					if (!village.Capital && village.userID < 0)
					{
						return false;
					}
				}
				if (InterfaceMgr.Instance.WorldMapMode == 2)
				{
					if (!village.Capital && (village.id != InterfaceMgr.Instance.StockExchangeBuyingVillage || InterfaceMgr.Instance.StockExchangeBuyingVillage < 0))
					{
						return false;
					}
					if (village.id != InterfaceMgr.Instance.StockExchangeBuyingVillage && !this.allowExchangeTrade(village.id, InterfaceMgr.Instance.StockExchangeBuyingVillage))
					{
						return false;
					}
				}
				if ((InterfaceMgr.Instance.WorldMapMode == 5 || InterfaceMgr.Instance.WorldMapMode == 7) && village.Capital)
				{
					return false;
				}
				if (InterfaceMgr.Instance.WorldMapMode == 3)
				{
					if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
					{
						if (!this.isHeretic())
						{
							if (this.isSpecial(village.id))
							{
								if (this.isAttackableSpecial(village.id))
								{
									return true;
								}
							}
							else if (village.userID <= 4)
							{
								return true;
							}
							return village.factionID == 4;
						}
						if (this.isSpecial(village.id))
						{
							int special = village.special;
							if (special <= 5)
							{
								if (special != 3 && special != 5)
								{
									goto IL_130;
								}
							}
							else if (special != 15 && special != 17)
							{
								goto IL_130;
							}
							return true;
							IL_130:
							return SpecialVillageTypes.IS_TREASURE_CASTLE(village.special) || SpecialVillageTypes.IS_ROYAL_TOWER(village.special);
						}
						return village.userID > 4 && village.factionID != 4;
					}
					else
					{
						if (this.isSpecial(village.id) && !this.isAttackableSpecial(village.id))
						{
							return false;
						}
						if (!this.isSpecial(village.id) && village.userID < 0 && !village.Capital)
						{
							return false;
						}
					}
				}
				if (InterfaceMgr.Instance.WorldMapMode == 7)
				{
					if (this.isSpecial(village.id) && !this.isAttackableSpecial(village.id))
					{
						return false;
					}
					if (!this.isSpecial(village.id) && village.userID < 0)
					{
						return false;
					}
				}
				if (InterfaceMgr.Instance.WorldMapMode == 5 && (this.isSpecial(village.id) || village.Capital || village.userID < 0))
				{
					return false;
				}
				if (InterfaceMgr.Instance.WorldMapMode == 6 && (this.isSpecial(village.id) || village.Capital))
				{
					return false;
				}
				if (InterfaceMgr.Instance.WorldMapMode == 4)
				{
					if (GameEngine.Instance.LocalWorldData.IsHereticEUAIWorld)
					{
						if (!this.isHeretic())
						{
							if (this.isSpecial(village.id))
							{
								if (this.isScoutableSpecial(village.id))
								{
									return true;
								}
							}
							else if (village.userID <= 4)
							{
								return true;
							}
							return village.factionID == 4;
						}
						if (this.isSpecial(village.id))
						{
							if (this.isScoutableSpecial(village.id))
							{
								switch (village.special)
								{
								case 7:
								case 9:
								case 11:
								case 13:
									return false;
								}
							}
							return true;
						}
						return village.userID > 4 && village.factionID != 4;
					}
					else
					{
						if (this.isSpecial(village.id) && !this.isScoutableSpecial(village.id))
						{
							return false;
						}
						if (!this.isSpecial(village.id) && village.userID < 0 && !this.isCapital(village.id))
						{
							return false;
						}
					}
				}
				if (InterfaceMgr.Instance.WorldMapMode == 9 && (this.isSpecial(village.id) || (village.userID < 0 && !village.Capital)))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06003281 RID: 12929 RVA: 0x00295790 File Offset: 0x00293990
		private void drawPlayerVillageList(ref WorldMap.FastScreenRect fRect)
		{
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				if (!userVillageData.capital)
				{
					VillageData villageData = this.villageList[userVillageData.villageID];
					if (this.mapIcon == null)
					{
						this.mapIcon = new MapIconDrawCall(this.gfx, this.villageSprite, this.m_worldZoomInverted, this.m_worldScale, this.mapEditing, new Size(this.m_screenWidth, this.m_screenHeight), this.pulse, this.pulseValue, this.xmasPresents);
					}
					float num = ((float)villageData.x - fRect.Left) / fRect.Width;
					float num2 = ((float)villageData.y - fRect.Top) / fRect.Height;
					if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f && this.shouldDrawMapIcon(villageData))
					{
						this.mapIcon.draw(villageData, (double)num, (double)num2);
					}
				}
			}
		}

		// Token: 0x06003282 RID: 12930 RVA: 0x002958BC File Offset: 0x00293ABC
		private void drawVillages(RectangleF screenRect)
		{
			WorldMap.FastScreenRect fastScreenRect = new WorldMap.FastScreenRect();
			fastScreenRect.left = (int)screenRect.Left;
			fastScreenRect.top = (int)screenRect.Top;
			fastScreenRect.Left = screenRect.Left;
			fastScreenRect.Top = screenRect.Top;
			fastScreenRect.Width = screenRect.Width;
			fastScreenRect.Height = screenRect.Height;
			fastScreenRect.right = (int)(screenRect.Right + 0.999f);
			fastScreenRect.bottom = (int)(screenRect.Bottom + 0.999f);
			fastScreenRect.zoomLevel = this.WorldZoom;
			this.m_baseNode.drawVillages(fastScreenRect);
			if (fastScreenRect.zoomLevel < 8.0 && this.m_userVillages != null && !this.PickingStartCounty)
			{
				this.drawPlayerVillageList(ref fastScreenRect);
			}
		}

		// Token: 0x06003283 RID: 12931 RVA: 0x00295988 File Offset: 0x00293B88
		public PointF getDrawPosition(double displayX, double displayY)
		{
			double num = (double)this.m_screenWidth / this.m_worldScale;
			double num2 = (double)this.m_screenHeight / this.m_worldScale;
			RectangleF rectangleF = new RectangleF((float)(this.m_screenCentreX - num / 2.0), (float)(this.m_screenCentreY - num2 / 2.0), (float)num, (float)num2);
			WorldMap.FastScreenRect fastScreenRect = new WorldMap.FastScreenRect();
			fastScreenRect.left = (int)rectangleF.Left;
			fastScreenRect.top = (int)rectangleF.Top;
			fastScreenRect.Left = rectangleF.Left;
			fastScreenRect.Top = rectangleF.Top;
			fastScreenRect.Width = rectangleF.Width;
			fastScreenRect.Height = rectangleF.Height;
			fastScreenRect.right = (int)(rectangleF.Right + 0.999f);
			fastScreenRect.bottom = (int)(rectangleF.Bottom + 0.999f);
			fastScreenRect.zoomLevel = this.WorldZoom;
			float num3 = (float)(displayX - (double)fastScreenRect.Left) / fastScreenRect.Width;
			float num4 = (float)(displayY - (double)fastScreenRect.Top) / fastScreenRect.Height;
			return new PointF
			{
				X = num3 * (float)this.m_screenWidth,
				Y = num4 * (float)this.m_screenHeight
			};
		}

		// Token: 0x06003284 RID: 12932 RVA: 0x00295AC0 File Offset: 0x00293CC0
		public PointF getPersonDrawPosition(long personID)
		{
			WorldMap.LocalPerson person = this.getPerson(personID);
			return this.getDrawPosition(person.displayX, person.displayY);
		}

		// Token: 0x06003285 RID: 12933 RVA: 0x00295AE8 File Offset: 0x00293CE8
		public PointF getTraderDrawPosition(long traderID)
		{
			WorldMap.LocalTrader trader = this.getTrader(traderID);
			return this.getDrawPosition(trader.displayX, trader.displayY);
		}

		// Token: 0x06003286 RID: 12934 RVA: 0x00295B10 File Offset: 0x00293D10
		public PointF getArmyDrawPosition(long armyID)
		{
			WorldMap.LocalArmyData armyByID = this.GetArmyByID(armyID);
			if (armyByID == null)
			{
				return PointF.Empty;
			}
			return this.getDrawPosition(armyByID.displayX, armyByID.displayY);
		}

		// Token: 0x06003287 RID: 12935 RVA: 0x00295B40 File Offset: 0x00293D40
		public PointF getVillageDrawPosition(int villageid)
		{
			double num = (double)this.m_screenWidth / this.m_worldScale;
			double num2 = (double)this.m_screenHeight / this.m_worldScale;
			RectangleF rectangleF = new RectangleF((float)(this.m_screenCentreX - num / 2.0), (float)(this.m_screenCentreY - num2 / 2.0), (float)num, (float)num2);
			WorldMap.FastScreenRect fastScreenRect = new WorldMap.FastScreenRect();
			fastScreenRect.left = (int)rectangleF.Left;
			fastScreenRect.top = (int)rectangleF.Top;
			fastScreenRect.Left = rectangleF.Left;
			fastScreenRect.Top = rectangleF.Top;
			fastScreenRect.Width = rectangleF.Width;
			fastScreenRect.Height = rectangleF.Height;
			fastScreenRect.right = (int)(rectangleF.Right + 0.999f);
			fastScreenRect.bottom = (int)(rectangleF.Bottom + 0.999f);
			fastScreenRect.zoomLevel = this.WorldZoom;
			if (villageid < 0 || this.villageList == null || villageid >= this.villageList.Length)
			{
				return PointF.Empty;
			}
			VillageData villageData = this.villageList[villageid];
			float num3 = ((float)villageData.x - fastScreenRect.Left) / fastScreenRect.Width;
			float num4 = ((float)villageData.y - fastScreenRect.Top) / fastScreenRect.Height;
			return new PointF
			{
				X = num3 * (float)this.m_screenWidth,
				Y = num4 * (float)this.m_screenHeight
			};
		}

		// Token: 0x06003288 RID: 12936 RVA: 0x00295CAC File Offset: 0x00293EAC
		public PointF getDrawPosition(PointF worldMapPosition)
		{
			double num = (double)this.m_screenWidth / this.m_worldScale;
			double num2 = (double)this.m_screenHeight / this.m_worldScale;
			RectangleF rectangleF = new RectangleF((float)(this.m_screenCentreX - num / 2.0), (float)(this.m_screenCentreY - num2 / 2.0), (float)num, (float)num2);
			WorldMap.FastScreenRect fastScreenRect = new WorldMap.FastScreenRect();
			fastScreenRect.left = (int)rectangleF.Left;
			fastScreenRect.top = (int)rectangleF.Top;
			fastScreenRect.Left = rectangleF.Left;
			fastScreenRect.Top = rectangleF.Top;
			fastScreenRect.Width = rectangleF.Width;
			fastScreenRect.Height = rectangleF.Height;
			fastScreenRect.right = (int)(rectangleF.Right + 0.999f);
			fastScreenRect.bottom = (int)(rectangleF.Bottom + 0.999f);
			fastScreenRect.zoomLevel = this.WorldZoom;
			float num3 = (worldMapPosition.X - fastScreenRect.Left) / fastScreenRect.Width;
			float num4 = (worldMapPosition.Y - fastScreenRect.Top) / fastScreenRect.Height;
			return new PointF
			{
				X = num3 * (float)this.m_screenWidth,
				Y = num4 * (float)this.m_screenHeight
			};
		}

		// Token: 0x06003289 RID: 12937 RVA: 0x00024916 File Offset: 0x00022B16
		public PointF pixelAlignPoint(float x, float y)
		{
			return new PointF((float)Math.Round((double)x), (float)Math.Round((double)y));
		}

		// Token: 0x0600328A RID: 12938 RVA: 0x0002492D File Offset: 0x00022B2D
		public void showShieldUser(int userID)
		{
			this.m_userInfoShieldRolloverUserID = userID;
		}

		// Token: 0x0600328B RID: 12939 RVA: 0x00024936 File Offset: 0x00022B36
		public int getVillageColour(int factionID)
		{
			return this.getHouse(factionID);
		}

		// Token: 0x0600328C RID: 12940 RVA: 0x00295DEC File Offset: 0x00293FEC
		public int getVillageColour(WorldMap.WorldPointList wpl)
		{
			if (!this.PickingStartCounty)
			{
				return this.getHouse(wpl.factionID);
			}
			int countyFromVillageID = GameEngine.Instance.World.getCountyFromVillageID(wpl.capitalVillage);
			if (GameEngine.Instance.World.AvailableCounties == null || !GameEngine.Instance.World.AvailableCounties.ContainsKey(countyFromVillageID))
			{
				return 0;
			}
			WorldMap.AvailableCounty availableCounty = this.AvailableCounties[countyFromVillageID];
			if (availableCounty.available <= 0)
			{
				return 1;
			}
			if (availableCounty.available > availableCounty.total / 2)
			{
				return 0;
			}
			if (availableCounty.available > availableCounty.total / 7)
			{
				return 3;
			}
			return 2;
		}

		// Token: 0x0600328D RID: 12941 RVA: 0x00295E8C File Offset: 0x0029408C
		public int getHouse(int factionID)
		{
			if (factionID < 0)
			{
				return 0;
			}
			int result;
			try
			{
				FactionData factionData = (FactionData)this.m_factionData[factionID];
				if (factionData != null)
				{
					if (factionData.houseID < 0 || factionData.houseID > 20)
					{
						result = 0;
					}
					else
					{
						result = factionData.houseID;
					}
				}
				else
				{
					result = 0;
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x00295EF0 File Offset: 0x002940F0
		private void experimentalStuff(string mapName)
		{
			int[] array = null;
			int[] array2 = null;
			int[] array3 = null;
			int num = 4;
			if (mapName != null)
			{
				uint num2 = PrivateImplementationDetails.ComputeStringHash(mapName);
				if (num2 <= 1815825712U)
				{
					if (num2 <= 1073140115U)
					{
						if (num2 <= 250393819U)
						{
							if (num2 != 177902812U)
							{
								if (num2 == 250393819U)
								{
									if (mapName == "us.wmpdata")
									{
										array = this.usCountyColour;
										array2 = this.usProvinceColour;
										array3 = this.usCountryColour;
									}
								}
							}
							else if (mapName == "de.wmpdata")
							{
								array = this.deCountyColour;
								array2 = this.deProvinceColour;
								array3 = this.deCountryColour;
							}
						}
						else if (num2 != 596384664U)
						{
							if (num2 == 1073140115U)
							{
								if (mapName == "fr.wmpdata")
								{
									array = this.frCountyColour;
									array2 = this.frProvinceColour;
									array3 = this.frCountryColour;
								}
							}
						}
						else if (mapName == "king.wmpdata")
						{
							array = this.kgCountyColour;
							array2 = this.kgProvinceColour;
							array3 = this.kgCountryColour;
							num = 5;
						}
					}
					else if (num2 <= 1248348107U)
					{
						if (num2 != 1122617957U)
						{
							if (num2 == 1248348107U)
							{
								if (mapName == "es.wmpdata")
								{
									array = this.esCountyColour;
									array2 = this.esProvinceColour;
									array3 = this.esCountryColour;
								}
							}
						}
						else if (mapName == "tr.wmpdata")
						{
							array = this.trCountyColour;
							array2 = this.trProvinceColour;
							array3 = this.trCountryColour;
						}
					}
					else if (num2 != 1364499433U)
					{
						if (num2 == 1815825712U)
						{
							if (mapName == "ch.wmpdata")
							{
								array = this.chCountyColour;
								array2 = this.chProvinceColour;
								array3 = this.chCountryColour;
							}
						}
					}
					else if (mapName == "eu.wmpdata")
					{
						array = this.euCountyColour;
						array2 = this.euProvinceColour;
						array3 = this.euCountryColour;
					}
				}
				else if (num2 <= 3203354827U)
				{
					if (num2 <= 2561964122U)
					{
						if (num2 != 1941924283U)
						{
							if (num2 == 2561964122U)
							{
								if (mapName == "ru.wmpdata")
								{
									array = this.ruCountyColour;
									array2 = this.ruProvinceColour;
									array3 = this.ruCountryColour;
								}
							}
						}
						else if (mapName == "pl.wmpdata")
						{
							array = this.plCountyColour;
							array2 = this.plProvinceColour;
							array3 = this.plCountryColour;
						}
					}
					else if (num2 != 2807536270U)
					{
						if (num2 == 3203354827U)
						{
							if (mapName == "uk2.wmpdata")
							{
								array = this.uk2CountyColour;
								array2 = this.uk2ProvinceColour;
								array3 = this.uk2CountryColour;
							}
						}
					}
					else if (mapName == "wrld.wmpdata")
					{
						array = this.gcCountyColour;
						array2 = this.gcProvinceColour;
						array3 = this.gcCountryColour;
					}
				}
				else if (num2 <= 3462506403U)
				{
					if (num2 != 3349807279U)
					{
						if (num2 == 3462506403U)
						{
							if (mapName == "uk.wmpdata")
							{
								array = this.ukCountyColour;
								array2 = this.ukProvinceColour;
								array3 = this.ukCountryColour;
							}
						}
					}
					else if (mapName == "ph.wmpdata")
					{
						array = this.phCountyColour;
						array2 = this.phProvinceColour;
						array3 = this.phCountryColour;
					}
				}
				else if (num2 != 3876139242U)
				{
					if (num2 == 4095064411U)
					{
						if (mapName == "sa.wmpdata")
						{
							array = this.saCountyColour;
							array2 = this.saProvinceColour;
							array3 = this.saCountryColour;
						}
					}
				}
				else if (mapName == "it.wmpdata")
				{
					array = this.itCountyColour;
					array2 = this.itProvinceColour;
					array3 = this.itCountryColour;
				}
			}
			if (array != null)
			{
				int num3 = 0;
				WorldMap.WorldPointList[] array4 = this.countyList;
				foreach (WorldMap.WorldPointList worldPointList in array4)
				{
					worldPointList.experimentalColourVariant = this.experimentalColourRemapping[array[num3++]];
				}
			}
			if (array2 != null)
			{
				int num4 = 0;
				WorldMap.WorldPointList[] array6 = this.provincesList;
				foreach (WorldMap.WorldPointList worldPointList2 in array6)
				{
					worldPointList2.experimentalColourVariant = this.experimentalColourRemapping[array2[num4++]];
				}
			}
			if (array != null)
			{
				int num5 = 0;
				WorldMap.WorldPointList[] array8 = this.countryList;
				foreach (WorldMap.WorldPointList worldPointList3 in array8)
				{
					worldPointList3.experimentalColourVariant = this.experimentalColourRemapping[array3[num5++]];
				}
			}
			WorldMap.WorldPointList[] array10 = this.regionList;
			foreach (WorldMap.WorldPointList worldPointList4 in array10)
			{
				WorldMap.WorldPointList worldPointList5 = this.countyList[worldPointList4.parentID];
				int num6 = worldPointList5.experimentalColourVariant;
				num6 += 2;
				if (num6 >= num)
				{
					num6 -= num;
				}
				worldPointList4.experimentalColourVariant = num6;
			}
		}

		// Token: 0x0600328F RID: 12943 RVA: 0x0029643C File Offset: 0x0029463C
		public Color getAreaColour(int areaCol, WorldMap.WorldPointList wpl)
		{
			if (this.PickingStartCounty && this.getCountyFromVillageID(this.LastClickedVillage) == this.getCountyFromVillageID(wpl.capitalVillage) && wpl.capitalVillage >= 0)
			{
				return global::ARGBColors.White;
			}
			Color result = WorldMap.areaColorList[areaCol];
			if (this.bLinelessMap && wpl.experimentalColourVariant > 0)
			{
				int num = 2;
				switch (areaCol)
				{
				case 0:
					num = 2;
					break;
				case 1:
					num = 5;
					break;
				case 2:
					num = 4;
					break;
				case 3:
					num = 4;
					break;
				case 4:
					num = 5;
					break;
				case 5:
					num = 4;
					break;
				case 6:
					num = 8;
					break;
				case 7:
					num = 4;
					break;
				case 8:
					num = 4;
					break;
				case 9:
					num = 3;
					break;
				case 10:
					num = 8;
					break;
				case 11:
					num = 4;
					break;
				case 12:
					num = 4;
					break;
				case 13:
					num = 4;
					break;
				case 14:
					num = 5;
					break;
				case 15:
					num = 4;
					break;
				case 16:
					num = 5;
					break;
				case 17:
					num = 4;
					break;
				case 18:
					num = 3;
					break;
				case 19:
					num = 5;
					break;
				case 20:
					num = 3;
					break;
				}
				int num2 = 50 - wpl.experimentalColourVariant * num;
				int red = (int)result.R * num2 / 50;
				int green = (int)result.G * num2 / 50;
				int blue = (int)result.B * num2 / 50;
				return Color.FromArgb(255, red, green, blue);
			}
			return result;
		}

		// Token: 0x06003290 RID: 12944 RVA: 0x00296594 File Offset: 0x00294794
		private void drawCountyBorders(RectangleF screenRect, bool solidBorders)
		{
			Color black = global::ARGBColors.Black;
			if (!solidBorders)
			{
				Color.FromArgb(80, global::ARGBColors.Black);
			}
			float num = ((float)this.m_worldScale + 0.001f - 2f) / 3f;
			if (num < 1f)
			{
				num = 1f;
			}
			double num2 = 0.5;
			double num3 = 5.0;
			if (this.EUMap)
			{
				num2 = 1.5;
			}
			if (!this.KGMap)
			{
				WorldMap.WorldPointList[] array = this.countyList;
				foreach (WorldMap.WorldPointList worldPointList in array)
				{
					if (worldPointList.isVisible(screenRect))
					{
						if (!this.LinelessMaps)
						{
							int num4 = worldPointList.borderList.Length;
							if (num4 > 1)
							{
								this.gfx.startThickLine(global::ARGBColors.Black, num);
								this.gfx.setThickLineRadius((float)this.m_worldScale);
								for (int j = 0; j < num4; j++)
								{
									WorldMap.WorldPoint worldPoint = this.pointList[worldPointList.borderList[j]];
									float x = (worldPoint.x - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
									float y = (worldPoint.y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
									this.gfx.addThickLinePoint(x, y);
								}
								this.gfx.drawThickLines(true);
							}
						}
						if (worldPointList.marker.X >= 0 && this.m_worldScale < num3 && this.m_worldScale > num2)
						{
							float x2 = ((float)worldPointList.marker.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							float num5 = ((float)worldPointList.marker.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							if (this.smallMapFont)
							{
								this.addText(worldPointList, new PointF(x2, num5 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 0, true, WorldMap.MapTextType.COUNTY);
							}
							else
							{
								this.addText(worldPointList, new PointF(x2, num5 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 1, true, WorldMap.MapTextType.COUNTY);
							}
						}
					}
				}
			}
			else
			{
				int num6 = 0;
				WorldMap.WorldPointList[] array3 = this.countyList;
				foreach (WorldMap.WorldPointList worldPointList2 in array3)
				{
					if (worldPointList2.isVisible(screenRect))
					{
						if (!this.LinelessMaps)
						{
							int num7 = worldPointList2.borderList.Length;
							if (num7 > 1)
							{
								this.gfx.startThickLine(global::ARGBColors.Black, num);
								this.gfx.setThickLineRadius((float)this.m_worldScale);
								for (int l = 0; l < num7; l++)
								{
									WorldMap.WorldPoint worldPoint2 = this.pointList[worldPointList2.borderList[l]];
									float x3 = (worldPoint2.x - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
									float y2 = (worldPoint2.y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
									this.gfx.addThickLinePoint(x3, y2);
								}
								this.gfx.drawThickLines(true);
							}
						}
						if (worldPointList2.marker.X >= 0 && this.m_worldScale < num3 && this.m_worldScale > num2)
						{
							float x4 = ((float)worldPointList2.marker.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							float num8 = ((float)worldPointList2.marker.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							WorldMap.WorldPointList wpl = this.countryList[num6];
							if (this.smallMapFont)
							{
								this.addText(wpl, new PointF(x4, num8 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 0, true, WorldMap.MapTextType.COUNTY);
							}
							else
							{
								this.addText(wpl, new PointF(x4, num8 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 1, true, WorldMap.MapTextType.COUNTY);
							}
						}
					}
					num6++;
				}
			}
			this.gfx.renderLines();
		}

		// Token: 0x06003291 RID: 12945 RVA: 0x002969B4 File Offset: 0x00294BB4
		private void drawProvinceBorders(RectangleF screenRect, bool thickBorders, bool political)
		{
			Color col = global::ARGBColors.Green;
			if (!political)
			{
				col = global::ARGBColors.Black;
			}
			float num = ((float)this.m_worldScale - 2f) / 3f;
			if (num < 1f)
			{
				num = 1f;
			}
			num = ((!thickBorders) ? (num * 2f) : (num * 3.5f));
			double num2 = 0.22;
			double num3 = 0.5;
			if (this.KGMap)
			{
				num2 = 0.65;
				num3 = 1.5;
			}
			else if (this.EUMap)
			{
				num2 = 0.5;
				num3 = 1.5;
			}
			if (this.playingProvinces)
			{
				col = global::ARGBColors.Black;
			}
			if (!this.KGMap)
			{
				WorldMap.WorldPointList[] array = this.provincesList;
				foreach (WorldMap.WorldPointList worldPointList in array)
				{
					if (this.drawProvinceBorder(screenRect, worldPointList, num, col) && this.m_worldScale < num3 && worldPointList.marker.X >= 0 && this.m_worldScale <= num3 && this.m_worldScale > num2)
					{
						float x = ((float)worldPointList.marker.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						float num4 = ((float)worldPointList.marker.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						if (this.smallMapFont)
						{
							this.addText(worldPointList, new PointF(x, num4 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 0, true, WorldMap.MapTextType.PROVINCE);
						}
						else
						{
							this.addText(worldPointList, new PointF(x, num4 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 1, true, WorldMap.MapTextType.PROVINCE);
						}
					}
				}
			}
			else
			{
				int num5 = 0;
				WorldMap.WorldPointList[] array3 = this.provincesList;
				foreach (WorldMap.WorldPointList worldPointList2 in array3)
				{
					if (this.drawProvinceBorder(screenRect, worldPointList2, num, col) && this.m_worldScale < num3 && worldPointList2.marker.X >= 0 && this.m_worldScale <= num3 && this.m_worldScale > num2)
					{
						float x2 = ((float)worldPointList2.marker.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						float num6 = ((float)worldPointList2.marker.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						WorldMap.WorldPointList wpl = this.countryList[num5];
						if (this.smallMapFont)
						{
							this.addText(wpl, new PointF(x2, num6 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 0, true, WorldMap.MapTextType.PROVINCE);
						}
						else
						{
							this.addText(wpl, new PointF(x2, num6 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 1, true, WorldMap.MapTextType.PROVINCE);
						}
					}
					num5++;
				}
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array5 = this.islandList;
				foreach (WorldMap.IslandInfoList islandInfoList in array5)
				{
					WorldMap.WorldPointList wpl2 = this.countyList[islandInfoList.county];
					this.drawProvinceBorder(screenRect, wpl2, num, col);
				}
			}
			this.gfx.renderLines();
		}

		// Token: 0x06003292 RID: 12946 RVA: 0x00296CF8 File Offset: 0x00294EF8
		private bool drawProvinceBorder(RectangleF screenRect, WorldMap.WorldPointList wpl, float scale, Color col)
		{
			if (this.LinelessMaps)
			{
				return true;
			}
			if (wpl.isVisible(screenRect))
			{
				int num = wpl.borderList.Length;
				if (num > 1)
				{
					this.gfx.startThickLine(col, scale);
					this.gfx.setThickLineRadius((float)this.m_worldScale);
					for (int i = 0; i < num; i++)
					{
						if (wpl.borderList[i] == -1)
						{
							this.gfx.drawThickLines(true);
							this.gfx.startThickLine(col, scale);
							this.gfx.setThickLineRadius((float)this.m_worldScale);
						}
						else
						{
							WorldMap.WorldPoint worldPoint = this.pointList[wpl.borderList[i]];
							float x = (worldPoint.x - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
							float y = (worldPoint.y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
							this.gfx.addThickLinePoint(x, y);
						}
					}
					this.gfx.drawThickLines(true);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06003293 RID: 12947 RVA: 0x00296E04 File Offset: 0x00295004
		private void drawCountryBorders(RectangleF screenRect)
		{
			float num = ((float)this.m_worldScale - 2f) / 3f;
			if (num < 1f)
			{
				num = 1f;
			}
			num *= 7f;
			Color col = global::ARGBColors.Purple;
			if (this.m_worldScale <= 0.2)
			{
				num = 3f;
				col = global::ARGBColors.Black;
			}
			double num2 = 0.0;
			double num3 = 0.22;
			if (this.KGMap)
			{
				num2 = 10000.0;
			}
			else if (this.EUMap)
			{
				num3 = 0.5;
			}
			if (this.playingCountries)
			{
				col = global::ARGBColors.Black;
			}
			WorldMap.WorldPointList[] array = this.countryList;
			foreach (WorldMap.WorldPointList worldPointList in array)
			{
				if (this.drawProvinceBorder(screenRect, worldPointList, num, col) && worldPointList.marker.X >= 0 && this.m_worldScale <= num3 && this.m_worldScale > num2)
				{
					float x = ((float)worldPointList.marker.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
					float num4 = ((float)worldPointList.marker.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
					if (this.smallMapFont)
					{
						this.addText(worldPointList, new PointF(x, num4 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 0, true, WorldMap.MapTextType.COUNTRY);
					}
					else
					{
						this.addText(worldPointList, new PointF(x, num4 + (float)this.yMarkerOffset), global::ARGBColors.Black, true, 1, true, WorldMap.MapTextType.COUNTRY);
					}
				}
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array3 = this.islandList;
				foreach (WorldMap.IslandInfoList islandInfoList in array3)
				{
					WorldMap.WorldPointList wpl = this.countyList[islandInfoList.county];
					this.drawProvinceBorder(screenRect, wpl, num, col);
				}
			}
			this.gfx.renderLines();
		}

		// Token: 0x06003294 RID: 12948 RVA: 0x00297000 File Offset: 0x00295200
		public void drawIslandLines(RectangleF screenRect)
		{
			float num = ((float)this.m_worldScale - 2f) / 3f;
			if (num < 1f)
			{
				num = 1f;
			}
			num *= 2f;
			WorldMap.IslandInfoList[] array = this.islandList;
			foreach (WorldMap.IslandInfoList islandInfoList in array)
			{
				if (((float)islandInfoList.sx >= screenRect.Left || (float)islandInfoList.ex >= screenRect.Left) && ((float)islandInfoList.sy >= screenRect.Top || (float)islandInfoList.ey >= screenRect.Top) && ((float)islandInfoList.sx <= screenRect.Right || (float)islandInfoList.ex <= screenRect.Right) && ((float)islandInfoList.sy <= screenRect.Bottom || (float)islandInfoList.ey <= screenRect.Bottom))
				{
					this.gfx.startThickLine(this.islandLineColor, num);
					this.gfx.setThickLineRadius((float)this.m_worldScale);
					float x = ((float)islandInfoList.sx - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
					float y = ((float)islandInfoList.sy - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
					this.gfx.addThickLinePoint(x, y);
					float x2 = ((float)islandInfoList.ex - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
					float y2 = ((float)islandInfoList.ey - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
					this.gfx.addThickLinePoint(x2, y2);
					this.gfx.drawThickLines(true);
				}
			}
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x002971C4 File Offset: 0x002953C4
		public void drawAIWorldLines(RectangleF screenRect)
		{
			float num = ((float)this.m_worldScale - 2f) / 3f;
			if (num < 1f)
			{
				num = 1f;
			}
			num *= 2f;
			if (this.aiWorldInvasionLineList != null)
			{
				foreach (WorldMap.IslandInfoList islandInfoList in this.aiWorldInvasionLineList)
				{
					if (((float)islandInfoList.sx >= screenRect.Left || (float)islandInfoList.ex >= screenRect.Left) && ((float)islandInfoList.sy >= screenRect.Top || (float)islandInfoList.ey >= screenRect.Top) && ((float)islandInfoList.sx <= screenRect.Right || (float)islandInfoList.ex <= screenRect.Right) && ((float)islandInfoList.sy <= screenRect.Bottom || (float)islandInfoList.ey <= screenRect.Bottom))
					{
						Color color = global::ARGBColors.DarkRed;
						if (this.getAIInvasionMarkerState(islandInfoList.villageID) == 0)
						{
							color = Color.FromArgb(80, color);
						}
						this.gfx.startThickLine(color, num);
						this.gfx.setThickLineRadius((float)this.m_worldScale);
						float x = ((float)islandInfoList.sx - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						float y = ((float)islandInfoList.sy - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						this.gfx.addThickLinePoint(x, y);
						float x2 = ((float)islandInfoList.ex - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
						float y2 = ((float)islandInfoList.ey - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
						this.gfx.addThickLinePoint(x2, y2);
						this.gfx.drawThickLines(true);
					}
				}
			}
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x002973D0 File Offset: 0x002955D0
		private void drawCountyPoly(RectangleF screenRect)
		{
			this.gfx.startPoly();
			WorldMap.WorldPointList[] array = this.countyList;
			WorldMap.WorldPointList[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				WorldMap.WorldPointList wpl = array2[i];
				int villageColour = this.getVillageColour(wpl);
				Color color = this.getAreaColour(villageColour, wpl);
				if (!this.GeographicalMap)
				{
					goto IL_7F;
				}
				float num = 255f;
				float num2 = (float)this.m_worldZoomInverted / 17.5f;
				if (num2 < 1f)
				{
					num *= num2;
				}
				if (villageColour != 0 || this.m_worldScale < 23.899999998509884)
				{
					color = Color.FromArgb((int)num, color);
					goto IL_7F;
				}
				IL_89:
				i++;
				continue;
				IL_7F:
				this.drawAreaPoly(screenRect, wpl, color);
				goto IL_89;
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x06003297 RID: 12951 RVA: 0x0029747C File Offset: 0x0029567C
		private void drawAreaPoly(RectangleF screenRect, WorldMap.WorldPointList wpl, Color col)
		{
			if (!wpl.isVisible(screenRect))
			{
				return;
			}
			int num = wpl.triangleList.Length;
			if (num > 0)
			{
				float num2 = screenRect.Width / (float)this.m_screenWidth;
				float num3 = screenRect.Height / (float)this.m_screenHeight;
				float left = screenRect.Left;
				float top = screenRect.Top;
				for (int i = 0; i < num; i++)
				{
					float x = (wpl.triangleList[i].x1 - left) / num2;
					float x2 = (wpl.triangleList[i].x2 - left) / num2;
					float x3 = (wpl.triangleList[i].x3 - left) / num2;
					float y = (wpl.triangleList[i].y1 - top) / num3;
					float y2 = (wpl.triangleList[i].y2 - top) / num3;
					float y3 = (wpl.triangleList[i].y3 - top) / num3;
					this.gfx.addTriangle(col, x, y, x2, y2, x3, y3);
				}
			}
		}

		// Token: 0x06003298 RID: 12952 RVA: 0x00297580 File Offset: 0x00295780
		private void drawProvincePoly(RectangleF screenRect)
		{
			this.gfx.startPoly();
			WorldMap.WorldPointList[] array = this.provincesList;
			WorldMap.WorldPointList[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				WorldMap.WorldPointList wpl = array2[i];
				int villageColour = this.getVillageColour(wpl);
				Color color = this.getAreaColour(villageColour, wpl);
				if (!this.GeographicalMap)
				{
					goto IL_7F;
				}
				float num = 255f;
				float num2 = (float)this.m_worldZoomInverted / 17.5f;
				if (num2 < 1f)
				{
					num *= num2;
				}
				if (villageColour != 0 || this.m_worldScale < 23.899999998509884)
				{
					color = Color.FromArgb((int)num, color);
					goto IL_7F;
				}
				IL_89:
				i++;
				continue;
				IL_7F:
				this.drawAreaPoly(screenRect, wpl, color);
				goto IL_89;
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array3 = this.islandList;
				WorldMap.IslandInfoList[] array4 = array3;
				int j = 0;
				while (j < array4.Length)
				{
					WorldMap.IslandInfoList islandInfoList = array4[j];
					WorldMap.WorldPointList wpl2 = this.provincesList[islandInfoList.province];
					int villageColour2 = this.getVillageColour(wpl2);
					Color color2 = this.getAreaColour(villageColour2, wpl2);
					if (!this.GeographicalMap)
					{
						goto IL_12E;
					}
					float num3 = 255f;
					float num4 = (float)this.m_worldZoomInverted / 17.5f;
					if (num4 < 1f)
					{
						num3 *= num4;
					}
					if (villageColour2 != 0 || this.m_worldScale < 23.899999998509884)
					{
						color2 = Color.FromArgb((int)num3, color2);
						goto IL_12E;
					}
					IL_149:
					j++;
					continue;
					IL_12E:
					WorldMap.WorldPointList wpl3 = this.countyList[islandInfoList.county];
					this.drawAreaPoly(screenRect, wpl3, color2);
					goto IL_149;
				}
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x06003299 RID: 12953 RVA: 0x002976F4 File Offset: 0x002958F4
		private void drawProvincePolyPlayback(RectangleF screenRect)
		{
			this.gfx.startPoly();
			int num = 0;
			WorldMap.WorldPointList[] array = this.provincesList;
			foreach (WorldMap.WorldPointList wpl in array)
			{
				int playbackProvinceHouse = this.getPlaybackProvinceHouse(this.playbackDay, num);
				Color col = WorldMap.areaColorList[playbackProvinceHouse];
				if (this.playbackDay < this.playbackTotalDays - 1)
				{
					int playbackProvinceHouse2 = this.getPlaybackProvinceHouse(this.playbackDay + 1, num);
					if (playbackProvinceHouse != playbackProvinceHouse2)
					{
						double num2 = this.playbackFrameFraction;
						Color color = WorldMap.areaColorList[playbackProvinceHouse2];
						col = Color.FromArgb((int)((double)col.R * (1.0 - num2) + (double)color.R * num2), (int)((double)col.G * (1.0 - num2) + (double)color.G * num2), (int)((double)col.B * (1.0 - num2) + (double)color.B * num2));
					}
				}
				num++;
				this.drawAreaPoly(screenRect, wpl, col);
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array3 = this.islandList;
				foreach (WorldMap.IslandInfoList islandInfoList in array3)
				{
					int playbackProvinceHouse3 = this.getPlaybackProvinceHouse(this.playbackDay, islandInfoList.province);
					Color col2 = WorldMap.areaColorList[playbackProvinceHouse3];
					if (this.playbackDay < this.playbackTotalDays - 1)
					{
						int playbackProvinceHouse4 = this.getPlaybackProvinceHouse(this.playbackDay + 1, islandInfoList.province);
						if (playbackProvinceHouse3 != playbackProvinceHouse4)
						{
							double num3 = this.playbackFrameFraction;
							Color color2 = WorldMap.areaColorList[playbackProvinceHouse4];
							col2 = Color.FromArgb((int)((double)col2.R * (1.0 - num3) + (double)color2.R * num3), (int)((double)col2.G * (1.0 - num3) + (double)color2.G * num3), (int)((double)col2.B * (1.0 - num3) + (double)color2.B * num3));
						}
					}
					WorldMap.WorldPointList wpl2 = this.countyList[islandInfoList.county];
					this.drawAreaPoly(screenRect, wpl2, col2);
				}
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x0600329A RID: 12954 RVA: 0x00297944 File Offset: 0x00295B44
		private void drawCountryPoly(RectangleF screenRect)
		{
			this.gfx.startPoly();
			WorldMap.WorldPointList[] array = this.countryList;
			WorldMap.WorldPointList[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				WorldMap.WorldPointList wpl = array2[i];
				int villageColour = this.getVillageColour(wpl);
				Color color = this.getAreaColour(villageColour, wpl);
				if (!this.GeographicalMap)
				{
					goto IL_7F;
				}
				float num = 255f;
				float num2 = (float)this.m_worldZoomInverted / 17.5f;
				if (num2 < 1f)
				{
					num *= num2;
				}
				if (villageColour != 0 || this.m_worldScale < 23.899999998509884)
				{
					color = Color.FromArgb((int)num, color);
					goto IL_7F;
				}
				IL_89:
				i++;
				continue;
				IL_7F:
				this.drawAreaPoly(screenRect, wpl, color);
				goto IL_89;
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array3 = this.islandList;
				WorldMap.IslandInfoList[] array4 = array3;
				int j = 0;
				while (j < array4.Length)
				{
					WorldMap.IslandInfoList islandInfoList = array4[j];
					WorldMap.WorldPointList wpl2 = this.countryList[islandInfoList.country];
					int villageColour2 = this.getVillageColour(wpl2);
					Color color2 = this.getAreaColour(villageColour2, wpl2);
					if (!this.GeographicalMap)
					{
						goto IL_12E;
					}
					float num3 = 255f;
					float num4 = (float)this.m_worldZoomInverted / 17.5f;
					if (num4 < 1f)
					{
						num3 *= num4;
					}
					if (villageColour2 != 0 || this.m_worldScale < 23.899999998509884)
					{
						color2 = Color.FromArgb((int)num3, color2);
						goto IL_12E;
					}
					IL_149:
					j++;
					continue;
					IL_12E:
					WorldMap.WorldPointList wpl3 = this.countyList[islandInfoList.county];
					this.drawAreaPoly(screenRect, wpl3, color2);
					goto IL_149;
				}
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x0600329B RID: 12955 RVA: 0x00297AB8 File Offset: 0x00295CB8
		private void drawCountryPolyPlayback(RectangleF screenRect)
		{
			this.gfx.startPoly();
			int num = 0;
			WorldMap.WorldPointList[] array = this.countryList;
			foreach (WorldMap.WorldPointList wpl in array)
			{
				int playbackCountryHouse = this.getPlaybackCountryHouse(this.playbackDay, num);
				Color col = WorldMap.areaColorList[playbackCountryHouse];
				if (this.playbackDay < this.playbackTotalDays - 2)
				{
					int playbackCountryHouse2 = this.getPlaybackCountryHouse(this.playbackDay + 1, num);
					if (playbackCountryHouse != playbackCountryHouse2)
					{
						double num2 = this.playbackFrameFraction;
						Color color = WorldMap.areaColorList[playbackCountryHouse2];
						col = Color.FromArgb((int)((double)col.R * (1.0 - num2) + (double)color.R * num2), (int)((double)col.G * (1.0 - num2) + (double)color.G * num2), (int)((double)col.B * (1.0 - num2) + (double)color.B * num2));
					}
				}
				num++;
				this.drawAreaPoly(screenRect, wpl, col);
			}
			if (!this.drawFakeProvinceBorders)
			{
				WorldMap.IslandInfoList[] array3 = this.islandList;
				foreach (WorldMap.IslandInfoList islandInfoList in array3)
				{
					int playbackCountryHouse3 = this.getPlaybackCountryHouse(this.playbackDay, islandInfoList.country);
					Color col2 = WorldMap.areaColorList[playbackCountryHouse3];
					if (this.playbackDay < this.playbackTotalDays - 2)
					{
						int playbackCountryHouse4 = this.getPlaybackCountryHouse(this.playbackDay + 1, islandInfoList.country);
						if (playbackCountryHouse3 != playbackCountryHouse4)
						{
							double num3 = this.playbackFrameFraction;
							Color color2 = WorldMap.areaColorList[playbackCountryHouse4];
							col2 = Color.FromArgb((int)((double)col2.R * (1.0 - num3) + (double)color2.R * num3), (int)((double)col2.G * (1.0 - num3) + (double)color2.G * num3), (int)((double)col2.B * (1.0 - num3) + (double)color2.B * num3));
						}
					}
					WorldMap.WorldPointList wpl2 = this.countyList[islandInfoList.county];
					this.drawAreaPoly(screenRect, wpl2, col2);
				}
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x0600329C RID: 12956 RVA: 0x00297D08 File Offset: 0x00295F08
		private void drawRegions(RectangleF screenRect)
		{
			this.gfx.startPoly();
			int num = -1;
			float num2 = screenRect.Width / (float)this.m_screenWidth;
			float num3 = screenRect.Height / (float)this.m_screenHeight;
			float left = screenRect.Left;
			float top = screenRect.Top;
			WorldMap.WorldPointList[] array = this.regionList;
			foreach (WorldMap.WorldPointList worldPointList in array)
			{
				num++;
				if (worldPointList.isVisible(screenRect))
				{
					int villageColour = this.getVillageColour(worldPointList);
					Color areaColour = this.getAreaColour(villageColour, worldPointList);
					int num4 = worldPointList.triangleList.Length;
					if (num4 > 0)
					{
						float num5 = 255f;
						float num6 = (float)this.WorldZoom - 5f;
						if (num6 < 1f)
						{
							num5 *= num6;
						}
						if (this.GeographicalMap)
						{
							num6 = (float)this.m_worldZoomInverted / 8f;
							if (num6 < 1f)
							{
								num5 *= num6;
							}
							if (villageColour == 0 && this.m_worldScale >= 23.899999998509884)
							{
								goto IL_1B5;
							}
						}
						Color col = Color.FromArgb((int)num5, areaColour);
						for (int j = 0; j < num4; j++)
						{
							float x = (worldPointList.triangleList[j].x1 - left) / num2;
							float x2 = (worldPointList.triangleList[j].x2 - left) / num2;
							float x3 = (worldPointList.triangleList[j].x3 - left) / num2;
							float y = (worldPointList.triangleList[j].y1 - top) / num3;
							float y2 = (worldPointList.triangleList[j].y2 - top) / num3;
							float y3 = (worldPointList.triangleList[j].y3 - top) / num3;
							this.gfx.addTriangle(col, x, y, x2, y2, x3, y3);
						}
					}
				}
				IL_1B5:;
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x0600329D RID: 12957 RVA: 0x00297EE8 File Offset: 0x002960E8
		public void drawRegionsBorder(RectangleF screenRect, bool forcedDraw)
		{
			Color color = global::ARGBColors.DarkGreen;
			float num = 255f;
			float num2 = (float)this.WorldZoom - 5f;
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			if (num2 < 1f)
			{
				num *= num2;
				color = Color.FromArgb((int)num, color);
			}
			float num3 = screenRect.Width / (float)this.m_screenWidth;
			float num4 = screenRect.Height / (float)this.m_screenHeight;
			float left = screenRect.Left;
			float top = screenRect.Top;
			int num5 = -1;
			WorldMap.WorldPointList[] array = this.regionList;
			foreach (WorldMap.WorldPointList worldPointList in array)
			{
				num5++;
				if (worldPointList.isVisible(screenRect))
				{
					int parentID = worldPointList.parentID;
					if (parentID < 0 || forcedDraw || this.getHouse(worldPointList.factionID) == this.getHouse(this.countyList[parentID].factionID) || this.GeographicalMap)
					{
						int num6 = worldPointList.regionBorderList.Length;
						if (num6 > 1)
						{
							this.gfx.startThickLine(color, 1f);
							this.gfx.setThickLineRadius((float)this.m_worldScale);
							for (int j = 0; j < num6; j++)
							{
								WorldMap.WorldPoint worldPoint = worldPointList.regionBorderList[j];
								if (worldPoint.x == 0f && worldPoint.y == 0f)
								{
									break;
								}
								float x = (worldPoint.x - left) / num3;
								float y = (worldPoint.y - top) / num4;
								this.gfx.addThickLinePoint(x, y);
							}
							this.gfx.drawThickLines(true);
						}
					}
				}
			}
			this.gfx.renderLines();
		}

		// Token: 0x0600329E RID: 12958 RVA: 0x00298098 File Offset: 0x00296298
		private void drawSeas(RectangleF screenRect)
		{
			if (this.GeographicalMap)
			{
				return;
			}
			float num = screenRect.Width / (float)this.m_screenWidth;
			float num2 = screenRect.Height / (float)this.m_screenHeight;
			float left = screenRect.Left;
			float top = screenRect.Top;
			WorldMap.WorldPointList[] array = this.seaList;
			foreach (WorldMap.WorldPointList worldPointList in array)
			{
				Color col = WorldMap.SEACOLOR;
				if (worldPointList.data == 1)
				{
					col = Color.FromArgb(255, 152, 181, 134);
				}
				if (worldPointList.isVisible(screenRect))
				{
					int num3 = worldPointList.triangleList.Length;
					if (num3 > 0)
					{
						this.gfx.startPoly();
						for (int j = 0; j < num3; j++)
						{
							float x = (worldPointList.triangleList[j].x1 - left) / num;
							float x2 = (worldPointList.triangleList[j].x2 - left) / num;
							float x3 = (worldPointList.triangleList[j].x3 - left) / num;
							float y = (worldPointList.triangleList[j].y1 - top) / num2;
							float y2 = (worldPointList.triangleList[j].y2 - top) / num2;
							float y3 = (worldPointList.triangleList[j].y3 - top) / num2;
							this.gfx.addTriangle(col, x, y, x2, y2, x3, y3);
						}
						this.gfx.drawBufferedPolygons();
					}
				}
			}
		}

		// Token: 0x0600329F RID: 12959 RVA: 0x0029821C File Offset: 0x0029641C
		private void drawSurroundBox(RectangleF screenRect, Color col, float x1, float y1, float x2, float y2)
		{
			x1 = (x1 - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			x2 = (x2 - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			y1 = (y1 - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			y2 = (y2 - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			this.gfx.addTriangle(col, x1, y1, x2, y1, x1, y2);
			this.gfx.addTriangle(col, x2, y1, x2, y2, x1, y2);
		}

		// Token: 0x060032A0 RID: 12960 RVA: 0x0002493F File Offset: 0x00022B3F
		public void addText(string text, PointF loc, Color col, bool centered, int size)
		{
			this.addText(text, loc, col, centered, size, false);
		}

		// Token: 0x060032A1 RID: 12961 RVA: 0x002982C8 File Offset: 0x002964C8
		public void addText(string text, PointF loc, Color col, bool centered, int size, bool bordered)
		{
			WorldMap.MapText mapText = new WorldMap.MapText();
			mapText.text = text;
			mapText.loc = loc;
			mapText.col = col;
			mapText.size = size;
			mapText.centered = centered;
			mapText.bordered = bordered;
			this.textDrawList.Add(mapText);
		}

		// Token: 0x060032A2 RID: 12962 RVA: 0x00298314 File Offset: 0x00296514
		public void addText(string text, PointF loc, Color col, bool centered, int size, bool bordered, bool preAdjusted)
		{
			WorldMap.MapText mapText = new WorldMap.MapText();
			mapText.text = text;
			mapText.loc = loc;
			mapText.col = col;
			mapText.size = size;
			mapText.centered = centered;
			mapText.bordered = bordered;
			mapText.preAdjustedForRetina = preAdjusted;
			this.textDrawList.Add(mapText);
		}

		// Token: 0x060032A3 RID: 12963 RVA: 0x00298368 File Offset: 0x00296568
		public void addText(string text, PointF loc, Color col, bool centered, int size, bool bordered, WorldMap.MapTextType type)
		{
			WorldMap.MapText mapText = new WorldMap.MapText();
			mapText.text = text;
			mapText.loc = loc;
			mapText.col = col;
			mapText.size = size;
			mapText.centered = centered;
			mapText.bordered = bordered;
			mapText.type = type;
			this.textDrawList.Add(mapText);
		}

		// Token: 0x060032A4 RID: 12964 RVA: 0x002983BC File Offset: 0x002965BC
		public void addText(string text, PointF loc, Color col, bool centered, int size, bool bordered, bool preAdjusted, WorldMap.MapTextType type)
		{
			WorldMap.MapText mapText = new WorldMap.MapText();
			mapText.text = text;
			mapText.loc = loc;
			mapText.col = col;
			mapText.size = size;
			mapText.centered = centered;
			mapText.bordered = bordered;
			mapText.type = type;
			mapText.preAdjustedForRetina = preAdjusted;
			this.textDrawList.Add(mapText);
		}

		// Token: 0x060032A5 RID: 12965 RVA: 0x00298418 File Offset: 0x00296618
		public void addText(WorldMap.WorldPointList wpl, PointF loc, Color col, bool centered, int size, bool bordered, WorldMap.MapTextType type)
		{
			WorldMap.MapText mapText = new WorldMap.MapText();
			mapText.text = wpl.areaName;
			mapText.wpl = wpl;
			mapText.loc = loc;
			mapText.col = col;
			mapText.size = size;
			mapText.centered = centered;
			mapText.bordered = bordered;
			mapText.type = type;
			this.textDrawList.Add(mapText);
		}

		// Token: 0x060032A6 RID: 12966 RVA: 0x00298478 File Offset: 0x00296678
		private void drawText()
		{
			this.gfx.startPoly();
			foreach (WorldMap.MapText mapText in this.textDrawList)
			{
				if (mapText.bordered && Program.mySettings.UseMapTextBorders)
				{
					Rectangle textSize = this.gfx.getTextSize(mapText.text, mapText.size);
					float num = mapText.loc.X - (float)(textSize.Width / 2) - 5f;
					float num2 = mapText.loc.X + (float)(textSize.Width / 2) + 3f;
					float num3 = mapText.loc.Y - 2f;
					float num4 = mapText.loc.Y + (float)textSize.Height;
					if (mapText.size == 0)
					{
						num3 += 2f;
					}
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num, num3 + 2f, num2, num3 + 2f, num, num4 - 2f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num2, num3 + 2f, num2, num4 - 2f, num, num4 - 2f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num + 1f, num3 + 1f, num2 - 1f, num3 + 1f, num + 1f, num3 + 2f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num2 - 1f, num3 + 1f, num2 - 1f, num3 + 2f, num + 1f, num3 + 2f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num + 1f, num4 - 2f, num2 - 1f, num4 - 2f, num + 1f, num4 - 1f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num2 - 1f, num4 - 2f, num2 - 1f, num4 - 1f, num + 1f, num4 - 1f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num + 2f, num3, num2 - 2f, num3, num + 2f, num3 + 1f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num2 - 2f, num3, num2 - 2f, num3 + 1f, num + 2f, num3 + 1f);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num + 2f, num4 - 1f, num2 - 2f, num4 - 1f, num + 2f, num4);
					this.gfx.addTriangle(Color.FromArgb(144, 255, 255, 255), num2 - 2f, num4 - 1f, num2 - 2f, num4, num + 2f, num4);
				}
			}
			this.gfx.drawBufferedPolygons();
			foreach (WorldMap.MapText mapText2 in this.textDrawList)
			{
				this.gfx.drawText(mapText2.text, mapText2.loc.X, mapText2.loc.Y, mapText2.col, mapText2.centered, mapText2.size, mapText2.bordered, false);
			}
			this.textDrawList.Clear();
		}

		// Token: 0x060032A7 RID: 12967 RVA: 0x0002494F File Offset: 0x00022B4F
		public void setScreenSize(int screenWidth, int screenHeight)
		{
			this.m_screenWidth = screenWidth;
			this.m_screenHeight = screenHeight;
		}

		// Token: 0x060032A8 RID: 12968 RVA: 0x00298920 File Offset: 0x00296B20
		public void moveMap(double dx, double dy)
		{
			this.m_screenCentreX += dx;
			this.m_screenCentreY += dy;
			if (this.m_screenCentreX < 0.0)
			{
				this.m_screenCentreX = 0.0;
			}
			if (this.m_screenCentreY < 0.0)
			{
				this.m_screenCentreY = 0.0;
			}
			if (this.m_screenCentreX >= (double)this.worldMapWidth)
			{
				this.m_screenCentreX = (double)(this.worldMapWidth - 1);
			}
			if (this.m_screenCentreY >= (double)this.worldMapHeight)
			{
				this.m_screenCentreY = (double)(this.worldMapHeight - 1);
			}
		}

		// Token: 0x060032A9 RID: 12969 RVA: 0x002989C8 File Offset: 0x00296BC8
		public void centreMap(bool useTarget)
		{
			if (this.m_zoomStage >= 0 && this.m_zoomStage < 6)
			{
				return;
			}
			double num = this.m_worldScale;
			double num2 = this.m_screenCentreX;
			double num3 = this.m_screenCentreY;
			if (useTarget && this.m_zoomDiff != 0.0)
			{
				double num4 = 27.0 - this.m_targetZoom;
				num = ((num4 < 23.0) ? (24.0 - num4) : (1.0 / (num4 - 22.0)));
				num2 = this.m_zoomXPosTarget;
				num3 = this.m_zoomYPosTarget;
			}
			int num5 = 0;
			double num6 = (0.0 - (double)this.m_screenWidth / 2.0) / num + num2;
			double num7 = ((double)(-(double)num5) - (double)this.m_screenHeight / 2.0) / num + num3;
			double num8 = ((double)this.m_screenWidth - (double)this.m_screenWidth / 2.0) / num + num2;
			double num9 = ((double)this.m_screenHeight - (double)this.m_screenHeight / 2.0) / num + num3;
			bool flag = false;
			if (this.m_zooming && this.m_zoomDiff > 0.0)
			{
				flag = true;
			}
			if (num6 < 0.0 && num8 >= (double)this.worldMapWidth)
			{
				this.m_screenCentreX = (double)(this.worldMapWidth / 2);
				if (!flag)
				{
					this.m_zoomXPosDiff = 0.0;
				}
			}
			else if (num6 < 0.0)
			{
				double num10 = (double)this.m_screenWidth / num;
				if (num10 > (double)this.worldMapWidth)
				{
					this.m_screenCentreX = (double)(this.worldMapWidth / 2);
					if (!flag)
					{
						this.m_zoomXPosDiff = 0.0;
					}
				}
				else
				{
					this.m_screenCentreX = num10 / 2.0;
				}
			}
			else if (num8 >= (double)this.worldMapWidth)
			{
				double num11 = (double)this.m_screenWidth / num;
				if (num11 > (double)this.worldMapWidth)
				{
					this.m_screenCentreX = (double)(this.worldMapWidth / 2);
					if (!flag)
					{
						this.m_zoomXPosDiff = 0.0;
					}
				}
				else
				{
					this.m_screenCentreX = (double)this.worldMapWidth - num11 / 2.0;
				}
			}
			if (num7 < 0.0 && num9 >= (double)this.worldMapHeight)
			{
				this.m_screenCentreY = (double)(this.worldMapHeight / 2) + (double)num5 / 2.0 / num;
				if (!flag)
				{
					this.m_zoomYPosDiff = 0.0;
					return;
				}
			}
			else if (num7 < 0.0)
			{
				double num12 = (double)this.m_screenHeight / num;
				if (num12 <= (double)this.worldMapHeight)
				{
					this.m_screenCentreY = num12 / 2.0 + (double)num5 / num;
					return;
				}
				this.m_screenCentreY = (double)(this.worldMapHeight / 2) + (double)num5 / 2.0 / num;
				if (!flag)
				{
					this.m_zoomYPosDiff = 0.0;
					return;
				}
			}
			else
			{
				if (num9 < (double)this.worldMapHeight)
				{
					return;
				}
				double num13 = (double)this.m_screenHeight / num;
				if (num13 > (double)this.worldMapHeight)
				{
					this.m_screenCentreY = (double)(this.worldMapHeight / 2) + (double)(num5 / 2) / num;
					if (!flag)
					{
						this.m_zoomYPosDiff = 0.0;
						return;
					}
				}
				else
				{
					this.m_screenCentreY = (double)this.worldMapHeight - num13 / 2.0;
				}
			}
		}

		// Token: 0x060032AA RID: 12970 RVA: 0x00298D20 File Offset: 0x00296F20
		public void moveMouse(Point mousePos)
		{
			this.m_rolloverTargetVillage = -1;
			this.m_rolloverTargetVillageNoDelay = -1;
			this.m_rolloverVillageShieldID = -1;
			if (this.WorldZoom > 13.0)
			{
				double num = 100000.0;
				int num2 = this.findNearestVillageFromScreenPos(mousePos, ref num);
				if (num > 4.0)
				{
					num2 = -1;
				}
				long num3 = -1L;
				long num4 = -1L;
				long num5 = -1L;
				long num6 = -1L;
				if (num2 < 0 && InterfaceMgr.Instance.WorldMapMode == 0)
				{
					double num7 = 0.0;
					num3 = this.findNearestArmyFromScreenPos(mousePos, ref num7);
					if (num3 >= 0L && num7 > 4.0)
					{
						num3 = -1L;
					}
					if (num3 < 0L)
					{
						double num8 = 0.0;
						num4 = this.findNearestTraderFromScreenPos(mousePos, ref num8);
						if (num4 >= 0L && num8 > 4.0)
						{
							num4 = -1L;
						}
						if (num4 < 0L)
						{
							double num9 = 0.0;
							num5 = this.findNearestReinforcementFromScreenPos(mousePos, ref num9);
							if (num5 >= 0L && num9 > 4.0)
							{
								num5 = -1L;
							}
							if (num5 < 0L)
							{
								double num10 = 0.0;
								num6 = this.findNearestPersonFromScreenPos(mousePos, ref num10);
								if (num6 >= 0L && num10 > 4.0)
								{
									num6 = -1L;
								}
							}
						}
					}
				}
				if (num3 < 0L && num2 < 0 && num4 < 0L && num6 < 0L && num5 < 0L && !InterfaceMgr.Instance.isMenuPopupOpen() && !InterfaceMgr.Instance.isInsideAchievementPopup())
				{
					CursorManager.SetCursor(CursorManager.CursorType.Hand, InterfaceMgr.Instance.ParentForm);
				}
				else
				{
					CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
				}
				bool flag = false;
				if (this.m_rolloverLastMousepos == mousePos)
				{
					long currentMillisecondsLong = DXTimer.GetCurrentMillisecondsLong();
					if (currentMillisecondsLong - this.m_rolloverLastTime > 150L)
					{
						flag = true;
					}
				}
				else
				{
					this.m_rolloverLastMousepos = mousePos;
					this.m_rolloverLastTime = DXTimer.GetCurrentMillisecondsLong();
				}
				if (num2 < 0 || this.m_worldZoomInverted >= 0.001 || this.m_leftMouseHeldDown)
				{
					return;
				}
				this.m_rolloverTargetVillageNoDelay = num2;
				if (flag)
				{
					this.m_rolloverTargetVillage = num2;
					if (this.isOverVillageShield(num2, mousePos, false))
					{
						this.m_rolloverVillageShieldID = num2;
						this.m_rolloverTargetVillage = -1;
						return;
					}
				}
			}
			else
			{
				double num11 = 100000.0;
				int num12 = this.findNearestVillageFromScreenPos(mousePos, ref num11);
				if (num11 > 4.0)
				{
					num12 = -1;
				}
				if (num12 < 0 && !InterfaceMgr.Instance.isMenuPopupOpen() && !InterfaceMgr.Instance.isInsideAchievementPopup())
				{
					CursorManager.SetCursor(CursorManager.CursorType.Hand, InterfaceMgr.Instance.ParentForm);
					return;
				}
				CursorManager.SetCursor(CursorManager.CursorType.Default, InterfaceMgr.Instance.ParentForm);
			}
		}

		// Token: 0x060032AB RID: 12971 RVA: 0x00298FA8 File Offset: 0x002971A8
		public bool isOverVillageShield(int villageID, PointF mousePos, bool fromNotOwn)
		{
			if (this.isUserVillage(villageID) || this.isUserRelatedVillage(villageID))
			{
				VillageData villageData = this.villageList[villageID];
				double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
				double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
				double num3 = num - (double)villageData.x;
				double num4 = num2 - (double)villageData.y;
				if (num3 > -0.5 && num3 < 0.3 && num4 < -1.1 && num4 > -2.0)
				{
					return true;
				}
				if (InterfaceMgr.Instance.OwnSelectedVillage < 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060032AC RID: 12972 RVA: 0x00299080 File Offset: 0x00297280
		public bool isOnlyOverVillageShield(int villageID, PointF mousePos)
		{
			if (this.isUserVillage(villageID) || this.isUserRelatedVillage(villageID))
			{
				VillageData villageData = this.villageList[villageID];
				double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
				double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
				double num3 = num - (double)villageData.x;
				double num4 = num2 - (double)villageData.y;
				if (num3 > -0.5 && num3 < 0.3 && num4 < -1.1 && num4 > -2.0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060032AD RID: 12973 RVA: 0x00299148 File Offset: 0x00297348
		public void createTributeLinesList(int villageID)
		{
			this.clearInterVillageLines();
			if (villageID < 0 || villageID >= this.villageList.Length)
			{
				return;
			}
			VillageData villageData = this.villageList[villageID];
			VillageData[] array = this.villageList;
			foreach (VillageData villageData2 in array)
			{
				if (villageData2.connecter == villageID)
				{
					float scale = 2f - (float)villageData2.villageInfo / 120f;
					this.addInterVillageLine(new Point((int)villageData.x, (int)villageData.y), new Point((int)villageData2.x, (int)villageData2.y), true, scale);
				}
			}
			if (villageData.connecter >= 0 && villageData.connecter < this.villageList.Length)
			{
				VillageData villageData3 = this.villageList[villageData.connecter];
				float scale2 = 2f - (float)villageData.villageInfo / 120f;
				this.addInterVillageLine(new Point((int)villageData3.x, (int)villageData3.y), new Point((int)villageData.x, (int)villageData.y), false, scale2);
			}
		}

		// Token: 0x060032AE RID: 12974 RVA: 0x00299248 File Offset: 0x00297448
		private void addInterVillageLine(Point start, Point end, bool yours)
		{
			WorldMap.InterVillageLine interVillageLine = new WorldMap.InterVillageLine();
			interVillageLine.start = new PointF((float)start.X, (float)start.Y);
			interVillageLine.end = new PointF((float)end.X, (float)end.Y);
			if (yours)
			{
				interVillageLine.style = 2;
			}
			this.interVillageLines.Add(interVillageLine);
		}

		// Token: 0x060032AF RID: 12975 RVA: 0x002992A8 File Offset: 0x002974A8
		private void addInterVillageLine(Point start, Point end, bool yours, float scale)
		{
			WorldMap.InterVillageLine interVillageLine = new WorldMap.InterVillageLine();
			interVillageLine.start = new PointF((float)start.X, (float)start.Y);
			interVillageLine.end = new PointF((float)end.X, (float)end.Y);
			if (yours)
			{
				interVillageLine.style = 2;
			}
			interVillageLine.widthScalar = scale;
			if (interVillageLine.widthScalar < 1f)
			{
				interVillageLine.widthScalar = 1f;
			}
			else if (interVillageLine.widthScalar > 2f)
			{
				interVillageLine.widthScalar = 2f;
			}
			this.interVillageLines.Add(interVillageLine);
		}

		// Token: 0x060032B0 RID: 12976 RVA: 0x00299344 File Offset: 0x00297544
		private void addDynamicInterVillageLine(Point start, Point end, int style)
		{
			WorldMap.InterVillageLine interVillageLine = new WorldMap.InterVillageLine();
			interVillageLine.start = new PointF((float)start.X, (float)start.Y);
			interVillageLine.end = new PointF((float)end.X, (float)end.Y);
			interVillageLine.style = style;
			interVillageLine.minLength = false;
			this.dynamicVillageLines.Add(interVillageLine);
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x0002495F File Offset: 0x00022B5F
		private void addDynamicInterVillageLine(PointF start, PointF end, int style)
		{
			this.addDynamicInterVillageLine(start, end, style, 1.1f);
		}

		// Token: 0x060032B2 RID: 12978 RVA: 0x002993A8 File Offset: 0x002975A8
		private void addDynamicInterVillageLine(PointF start, PointF end, int style, float scalar)
		{
			WorldMap.InterVillageLine interVillageLine = new WorldMap.InterVillageLine();
			interVillageLine.start = start;
			interVillageLine.end = end;
			interVillageLine.style = style;
			interVillageLine.widthScalar = scalar;
			if (interVillageLine.widthScalar < 1f)
			{
				interVillageLine.widthScalar = 1f;
			}
			else if (interVillageLine.widthScalar > 2f)
			{
				interVillageLine.widthScalar = 2f;
			}
			this.dynamicVillageLines.Add(interVillageLine);
		}

		// Token: 0x060032B3 RID: 12979 RVA: 0x00299418 File Offset: 0x00297618
		public void drawInterVillageLines(RectangleF screenRect)
		{
			Color outerColour = Color.FromArgb(128, global::ARGBColors.Blue);
			Color innerColour = Color.FromArgb(128, global::ARGBColors.LightBlue);
			Color outerColour2 = Color.FromArgb(128, global::ARGBColors.Green);
			Color innerColour2 = Color.FromArgb(128, global::ARGBColors.LightGreen);
			Color outerColour3 = Color.FromArgb(128, Color.FromArgb(128, 255, 128));
			Color innerColour3 = Color.FromArgb(128, Color.FromArgb(192, 255, 192));
			Color outerColour4 = Color.FromArgb(128, Color.FromArgb(255, 128, 128));
			Color innerColour4 = Color.FromArgb(128, Color.FromArgb(255, 192, 192));
			double worldZoom = this.WorldZoom;
			if (worldZoom >= 8.0 && (this.interVillageLines.Count > 0 || this.dynamicVillageLines.Count > 0))
			{
				float num = ((float)this.m_worldScale - 2f) / 3f;
				if (num < 0.3f)
				{
				}
				this.gfx.startPoly();
				if (InterfaceMgr.Instance.WorldMapMode == 0)
				{
					foreach (WorldMap.InterVillageLine interVillageLine in this.interVillageLines)
					{
						if (interVillageLine.style == 2)
						{
							this.drawInterVillageLine(interVillageLine, screenRect, outerColour2, innerColour2);
						}
						else if (interVillageLine.style == 1)
						{
							this.drawInterVillageLine(interVillageLine, screenRect, outerColour, innerColour);
						}
					}
				}
				foreach (WorldMap.InterVillageLine interVillageLine2 in this.dynamicVillageLines)
				{
					if (interVillageLine2.style == 3)
					{
						this.drawInterVillageLine(interVillageLine2, screenRect, outerColour3, innerColour3);
					}
					else if (interVillageLine2.style == 4)
					{
						this.drawInterVillageLine(interVillageLine2, screenRect, outerColour4, innerColour4);
					}
					else if (interVillageLine2.style == 5)
					{
						this.drawInterVillageLine(interVillageLine2, screenRect, global::ARGBColors.Yellow, Color.FromArgb(64, 255, 64));
					}
					else if (interVillageLine2.style == 6)
					{
						double num2 = (double)this.pulse / 128.0;
						if (num2 > 1.0)
						{
							num2 = 2.0 - num2;
						}
						Color innerColour5 = Color.FromArgb(96, 255 - (int)(191.0 * num2), 255, (int)(64.0 * num2));
						Color outerColour5 = Color.FromArgb(96, global::ARGBColors.Yellow);
						this.drawInterVillageLine(interVillageLine2, screenRect, outerColour5, innerColour5);
					}
				}
				this.gfx.drawBufferedPolygons();
			}
			this.dynamicVillageLines.Clear();
		}

		// Token: 0x060032B4 RID: 12980 RVA: 0x0029971C File Offset: 0x0029791C
		private void drawInterVillageLine(WorldMap.InterVillageLine line, RectangleF screenRect, Color outerColour, Color innerColour)
		{
			PointF pointF = new PointF(line.end.X - line.start.X, line.end.Y - line.start.Y);
			PointF pointF2 = pointF;
			float num = (float)Math.Sqrt((double)(pointF.X * pointF.X + pointF.Y * pointF.Y)) * line.widthScalar;
			pointF.X /= num;
			pointF.Y /= num;
			PointF pointF3 = this.gfx.rotatePoint(pointF, -90);
			PointF pointF4 = this.gfx.rotatePoint(pointF, 90);
			if (line.style == 5 || line.style == 6)
			{
				pointF3 = this.gfx.rotatePoint(pointF, -135);
				pointF4 = this.gfx.rotatePoint(pointF, 135);
				pointF3.X *= 1.2f;
				pointF3.Y *= 1.2f;
				pointF4.X *= 1.2f;
				pointF4.Y *= 1.2f;
				pointF3.X += line.end.X - pointF.X;
				pointF3.Y += line.end.Y - pointF.Y;
				pointF4.X += line.end.X - pointF.X;
				pointF4.Y += line.end.Y - pointF.Y;
			}
			else
			{
				pointF3.X += line.end.X;
				pointF3.Y += line.end.Y;
				pointF4.X += line.end.X;
				pointF4.Y += line.end.Y;
			}
			float num2 = pointF2.X / 5f * (pointF2.X / 5f) + pointF2.Y / 5f * (pointF2.Y / 5f);
			float num3 = pointF.X * 1.5f * (pointF.X * 1.5f) + pointF.Y * 1.5f * (pointF.Y * 1.5f);
			if (num2 < num3 && line.minLength)
			{
				pointF.X *= 1.5f;
				pointF.Y *= 1.5f;
				pointF.X = line.end.X - pointF.X;
				pointF.Y = line.end.Y - pointF.Y;
			}
			else
			{
				pointF.X = line.end.X - pointF2.X / 5f;
				pointF.Y = line.end.Y - pointF2.Y / 5f;
			}
			float num4 = (pointF3.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			float num5 = (pointF3.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			float x = (pointF4.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			float y = (pointF4.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			float x2 = (line.start.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			float y2 = (line.start.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			if (line.style == 5 || line.style == 6)
			{
				float x3 = (line.end.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
				float y3 = (line.end.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
				this.gfx.addTriangle(Color.FromArgb(0, (int)outerColour.R, (int)outerColour.G, (int)outerColour.B), outerColour, outerColour, x3, y3, num4, num5, x, y, 2);
				this.gfx.addTriangle(outerColour, innerColour, outerColour, num4, num5, x2, y2, x, y, 2);
				return;
			}
			float x4 = (pointF.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			float y4 = (pointF.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			this.gfx.addTriangle(outerColour, num4, num5, x2, y2, x, y, 2);
			this.gfx.addTriangle(innerColour, num4, num5, x4, y4, x, y, 3);
		}

		// Token: 0x060032B5 RID: 12981 RVA: 0x0002496F File Offset: 0x00022B6F
		private void clearInterVillageLines()
		{
			this.interVillageLines.Clear();
		}

		// Token: 0x060032B6 RID: 12982 RVA: 0x00299C4C File Offset: 0x00297E4C
		private void manageDynamicLines()
		{
			if (InterfaceMgr.Instance.MapSelectedArmy >= 0L)
			{
				WorldMap.LocalArmyData armyByID = this.GetArmyByID(InterfaceMgr.Instance.MapSelectedArmy);
				if (armyByID != null && armyByID.targetVillageID >= 0 && armyByID.travelFromVillageID >= 0)
				{
					PointF start = armyByID.TargetPoint();
					PointF pointF = new PointF((float)armyByID.displayX, (float)armyByID.displayY);
					PointF end = armyByID.BasePoint();
					this.addDynamicInterVillageLine(start, pointF, 3, 1.2f);
					this.addDynamicInterVillageLine(pointF, end, 4, 1.2f);
				}
			}
			if (InterfaceMgr.Instance.MapSelectedReinforcement >= 0L)
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)this.reinforcementArray[InterfaceMgr.Instance.MapSelectedReinforcement];
				if (localArmyData != null && localArmyData.targetVillageID >= 0 && localArmyData.travelFromVillageID >= 0)
				{
					PointF start2 = localArmyData.TargetPoint();
					PointF pointF2 = new PointF((float)localArmyData.displayX, (float)localArmyData.displayY);
					PointF end2 = localArmyData.BasePoint();
					this.addDynamicInterVillageLine(start2, pointF2, 3, 1.2f);
					this.addDynamicInterVillageLine(pointF2, end2, 4, 1.2f);
				}
			}
			if (InterfaceMgr.Instance.MapSelectedTrader >= 0L)
			{
				WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)this.traderArray[InterfaceMgr.Instance.MapSelectedTrader];
				if (localTrader != null && localTrader.trader.targetVillageID >= 0 && localTrader.trader.homeVillageID >= 0)
				{
					PointF start3 = localTrader.TargetPoint();
					PointF pointF3 = new PointF((float)localTrader.displayX, (float)localTrader.displayY);
					PointF end3 = localTrader.BasePoint();
					this.addDynamicInterVillageLine(start3, pointF3, 3, 1.2f);
					this.addDynamicInterVillageLine(pointF3, end3, 4, 1.2f);
				}
			}
			if (InterfaceMgr.Instance.MapSelectedPerson >= 0L)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)this.personArray[InterfaceMgr.Instance.MapSelectedPerson];
				if (localPerson != null && localPerson.person.targetVillageID >= 0 && localPerson.person.homeVillageID >= 0)
				{
					PointF start4 = localPerson.TargetPoint();
					PointF pointF4 = new PointF((float)localPerson.displayX, (float)localPerson.displayY);
					PointF end4 = localPerson.BasePoint();
					this.addDynamicInterVillageLine(start4, pointF4, 3, 1.2f);
					this.addDynamicInterVillageLine(pointF4, end4, 4, 1.2f);
				}
			}
			if (InterfaceMgr.Instance.SelectedVassalVillage >= 0)
			{
				if (InterfaceMgr.Instance.SelectedVillage >= 0 && InterfaceMgr.Instance.SelectedVassalVillage >= 0 && InterfaceMgr.Instance.SelectedVillage < this.villageList.Length && InterfaceMgr.Instance.SelectedVassalVillage < this.villageList.Length && InterfaceMgr.Instance.SelectedVillage != InterfaceMgr.Instance.SelectedVassalVillage)
				{
					VillageData villageData = this.villageList[InterfaceMgr.Instance.SelectedVassalVillage];
					VillageData villageData2 = this.villageList[InterfaceMgr.Instance.SelectedVillage];
					float scalar = 2f - (float)villageData.villageInfo / 120f;
					this.addDynamicInterVillageLine(new Point((int)villageData2.x, (int)villageData2.y), new Point((int)villageData.x, (int)villageData.y), 5, scalar);
				}
			}
			else if (InterfaceMgr.Instance.SelectedVillage >= 0 && InterfaceMgr.Instance.OwnSelectedVillage >= 0 && InterfaceMgr.Instance.SelectedVillage < this.villageList.Length && InterfaceMgr.Instance.OwnSelectedVillage < this.villageList.Length && InterfaceMgr.Instance.SelectedVillage != InterfaceMgr.Instance.OwnSelectedVillage)
			{
				VillageData villageData3 = this.villageList[InterfaceMgr.Instance.OwnSelectedVillage];
				VillageData villageData4 = this.villageList[InterfaceMgr.Instance.SelectedVillage];
				float scalar2 = 2f - (float)villageData3.villageInfo / 120f;
				this.addDynamicInterVillageLine(new Point((int)villageData4.x, (int)villageData4.y), new Point((int)villageData3.x, (int)villageData3.y), 5, scalar2);
			}
			if (this.m_rolloverTargetVillage >= 0 && InterfaceMgr.Instance.OwnSelectedVillage >= 0 && this.m_rolloverTargetVillage < this.villageList.Length && InterfaceMgr.Instance.OwnSelectedVillage < this.villageList.Length && InterfaceMgr.Instance.OwnSelectedVillage != this.m_rolloverTargetVillage)
			{
				VillageData villageData5 = this.villageList[InterfaceMgr.Instance.OwnSelectedVillage];
				VillageData villageData6 = this.villageList[this.m_rolloverTargetVillage];
				float scalar3 = 2f - (float)villageData5.villageInfo / 120f;
				this.addDynamicInterVillageLine(new Point((int)villageData6.x, (int)villageData6.y), new Point((int)villageData5.x, (int)villageData5.y), 6, scalar3);
			}
		}

		// Token: 0x060032B7 RID: 12983 RVA: 0x0029A11C File Offset: 0x0029831C
		public void drawRangeCircle(RectangleF screenRect)
		{
			if ((InterfaceMgr.Instance.OwnSelectedVillage >= 0 || InterfaceMgr.Instance.SelectedVassalVillage >= 0) && this.isSpecial(InterfaceMgr.Instance.SelectedVillage) && this.getSpecial(InterfaceMgr.Instance.SelectedVillage) != 21 && this.getSpecial(InterfaceMgr.Instance.SelectedVillage) != 20)
			{
				int num = InterfaceMgr.Instance.OwnSelectedVillage;
				if (InterfaceMgr.Instance.SelectedVassalVillage >= 0)
				{
					num = InterfaceMgr.Instance.SelectedVassalVillage;
				}
				if (num >= 0 && num < this.villageList.Length)
				{
					VillageData villageData = this.villageList[num];
					this.drawRangeCircle(new Point((int)villageData.x, (int)villageData.y), (float)CardTypes.adjustScoutingHonourRange(GameEngine.Instance.cardsManager.UserCardData, GameEngine.Instance.LocalWorldData.BaseScoutHonourRange), screenRect);
				}
			}
		}

		// Token: 0x060032B8 RID: 12984 RVA: 0x0029A204 File Offset: 0x00298404
		public void drawRangeCircle(PointF centre, float radius, RectangleF screenRect)
		{
			int num = (int)((double)(radius * 2f * 10f) / (this.m_worldZoomInverted + 10.0));
			if (num < 32)
			{
				num = 32;
			}
			float num2 = 6.28318f / (float)num;
			float num3 = 0f;
			float num4 = 0f;
			Color color = Color.FromArgb(80, 255, 0, 0);
			for (int i = -1; i < num; i++)
			{
				float num5 = (float)i * num2;
				float num6 = (float)((double)centre.X + (double)radius * Math.Cos((double)num5));
				float num7 = (float)((double)centre.Y - (double)radius * Math.Sin((double)num5));
				if (i >= 0)
				{
					this.addCircleTriangle(screenRect, num3, num4, num6, num7, centre, color);
					this.addCircleTriangle(screenRect, num6, num7, num3, num4, centre, color);
				}
				num3 = num6;
				num4 = num7;
			}
			this.gfx.drawBufferedPolygons();
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x0029A2DC File Offset: 0x002984DC
		private void addCircleTriangle(RectangleF screenRect, float x1, float y1, float x2, float y2, PointF centre, Color color)
		{
			x1 = (x1 - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			y1 = (y1 - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			float x3 = (centre.X - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			float y3 = (centre.Y - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			x2 = (x2 - screenRect.Left) / screenRect.Width * (float)this.m_screenWidth;
			y2 = (y2 - screenRect.Top) / screenRect.Height * (float)this.m_screenHeight;
			this.gfx.addTriangle(color, x1, y1, x2, y2, x3, y3);
		}

		// Token: 0x060032BA RID: 12986 RVA: 0x0029A3AC File Offset: 0x002985AC
		public void mouseNotDown(Point mousePos)
		{
			if (!this.m_leftMouseHeldDown)
			{
				return;
			}
			if (!this.isDraggingMap)
			{
				double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
				bool doubleClick = false;
				if (currentMilliseconds - this.m_doubleClickTime < 300.0 && Math.Abs(mousePos.X - this.m_doubleClickMousePos.X) < 3 && Math.Abs(mousePos.Y - this.m_doubleClickMousePos.Y) < 3)
				{
					doubleClick = true;
				}
				this.windowClicked(mousePos, doubleClick);
				this.m_doubleClickTime = currentMilliseconds;
				this.m_doubleClickMousePos = mousePos;
			}
			this.stopDrag();
			InterfaceMgr.Instance.mouseUpDXPlaybackBar(mousePos);
		}

		// Token: 0x060032BB RID: 12987 RVA: 0x0002497C File Offset: 0x00022B7C
		public bool holdingLeftMouse()
		{
			return this.m_leftMouseHeldDown;
		}

		// Token: 0x060032BC RID: 12988 RVA: 0x0029A448 File Offset: 0x00298648
		public void startDrag(Point mousePos)
		{
			this.m_lastMousePressedTime = DXTimer.GetCurrentMilliseconds();
			this.m_leftMouseHeldDown = true;
			this.m_baseMousePos = mousePos;
			this.m_baseScreenX = this.m_screenCentreX;
			this.m_baseScreenY = this.m_screenCentreY;
			this.isDraggingMap = false;
			InterfaceMgr.Instance.mouseDownDXPlaybackBar(mousePos);
			this.dragMode = true;
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x00024984 File Offset: 0x00022B84
		public void stopDrag()
		{
			this.m_leftMouseHeldDown = false;
			this.isDraggingMap = false;
			this.dragMode = false;
		}

		// Token: 0x060032BE RID: 12990 RVA: 0x0029A4A0 File Offset: 0x002986A0
		public void dragMapRelative(Point lastMousePos, Point newMousePos)
		{
			double num = 0.0;
			double num2 = 0.0;
			this.getMapCoords(newMousePos, ref num, ref num2);
			double num3 = 0.0;
			double num4 = 0.0;
			this.getMapCoords(lastMousePos, ref num3, ref num4);
			this.m_screenCentreX += num3 - num;
			this.m_screenCentreY += num4 - num2;
		}

		// Token: 0x060032BF RID: 12991 RVA: 0x0029A50C File Offset: 0x0029870C
		public void dragMap(Point mousePos)
		{
			this.m_zooming = false;
			this.isDraggingMap = true;
			this.m_screenCentreX = this.m_baseScreenX;
			this.m_screenCentreY = this.m_baseScreenY;
			double num = 0.0;
			double num2 = 0.0;
			this.getMapCoords(mousePos, ref num, ref num2);
			double num3 = 0.0;
			double num4 = 0.0;
			this.getMapCoords(this.m_baseMousePos, ref num3, ref num4);
			this.m_screenCentreX = this.m_baseScreenX + num3 - num;
			this.m_screenCentreY = this.m_baseScreenY + num4 - num2;
			this.moveMap(0.0, 0.0);
			this.centreMap(false);
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x0029A5C4 File Offset: 0x002987C4
		public void leftMouseDown(Point mousePos)
		{
			if (!this.holdingLeftMouse())
			{
				this.startDrag(mousePos);
				return;
			}
			double currentMilliseconds = DXTimer.GetCurrentMilliseconds();
			if (currentMilliseconds - this.m_lastMousePressedTime <= 250.0 && Math.Abs(this.m_baseMousePos.X - mousePos.X) <= 3 && Math.Abs(this.m_baseMousePos.Y - mousePos.Y) <= 3)
			{
				return;
			}
			bool flag = true;
			if (!this.isDraggingMap && Math.Abs(this.m_baseMousePos.X - mousePos.X) <= 3 && Math.Abs(this.m_baseMousePos.Y - mousePos.Y) <= 3 && this.WorldZoom > 18.5)
			{
				double num = 100000.0;
				int num2 = this.findNearestVillageFromScreenPos(mousePos, ref num);
				if (num > 4.0)
				{
					num2 = -1;
				}
				long num3 = -1L;
				long num4 = -1L;
				long num5 = -1L;
				long num6 = -1L;
				if (num2 < 0 && InterfaceMgr.Instance.WorldMapMode == 0)
				{
					double num7 = 0.0;
					num3 = this.findNearestArmyFromScreenPos(mousePos, ref num7);
					if (num3 >= 0L && num7 > 4.0)
					{
						num3 = -1L;
					}
					if (num3 < 0L)
					{
						double num8 = 0.0;
						num4 = this.findNearestTraderFromScreenPos(mousePos, ref num8);
						if (num4 >= 0L && num8 > 4.0)
						{
							num4 = -1L;
						}
						if (num4 < 0L)
						{
							double num9 = 0.0;
							num5 = this.findNearestReinforcementFromScreenPos(mousePos, ref num9);
							if (num5 >= 0L && num9 > 4.0)
							{
								num5 = -1L;
							}
							if (num5 < 0L)
							{
								double num10 = 0.0;
								num6 = this.findNearestPersonFromScreenPos(mousePos, ref num10);
								if (num6 >= 0L && num10 > 4.0)
								{
									num6 = -1L;
								}
							}
						}
					}
				}
				if (num3 >= 0L || num2 >= 0 || num4 >= 0L || num5 >= 0L || num6 >= 0L)
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.dragMap(mousePos);
			}
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x0029A7C8 File Offset: 0x002989C8
		public int lastClickedVillage()
		{
			double num = -1.0;
			return this.findNearestVillageFromScreenPosAnyVis(this.lastClickedLocation, ref num);
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x0029A7F0 File Offset: 0x002989F0
		public void clickOnMapIcon(Point mousePos, bool doubleClick)
		{
			bool flag = true;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			int num6 = this.LastClickedVillage = this.findNearestVillageFromScreenPos(mousePos, ref num);
			if (this.WorldEnded && num6 > 0)
			{
				VillageData villageData = this.villageList[num6];
				if (villageData.Capital)
				{
					this.fwDisplayClock = 0f;
				}
			}
			bool flag2 = false;
			if (num6 >= 0 && this.WorldZoom > 18.5 && this.isOnlyOverVillageShield(num6, mousePos))
			{
				flag2 = true;
			}
			if ((num6 == -1 || this.WorldZoom > 18.5 || this.PickingStartCounty) && !flag2 && InterfaceMgr.Instance.WorldMapMode == 0)
			{
				long num7 = this.findNearestArmyFromScreenPos(mousePos, ref num2);
				if (num7 >= 0L && (num6 == -1 || num2 <= num))
				{
					WorldMap.LocalArmyData armyByID = this.GetArmyByID(num7);
					if (armyByID.numScouts > 0)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_scouts", false);
					}
					else
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_army", false);
					}
					if (armyByID.attackType != 17 && flag)
					{
						this.setZooming(27.0, armyByID.displayX, armyByID.displayY);
					}
					InterfaceMgr.Instance.closeFilterPanel();
					InterfaceMgr.Instance.closeSelectedVillagePanel();
					InterfaceMgr.Instance.closeTraderInfoPanel();
					InterfaceMgr.Instance.closeReinforcementSelectedPanel();
					InterfaceMgr.Instance.closePersonInfoPanel();
					InterfaceMgr.Instance.clearAndCloseUserInfo();
					InterfaceMgr.Instance.displayArmySelectPanel(num7);
					return;
				}
				long num8 = this.findNearestReinforcementFromScreenPos(mousePos, ref num3);
				if (num8 >= 0L && (num6 == -1 || num3 <= num))
				{
					GameEngine.Instance.playInterfaceSound("WorldMap_reinforcement", false);
					WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)this.reinforcementArray[num8];
					if (flag)
					{
						this.setZooming(27.0, localArmyData.displayX, localArmyData.displayY);
					}
					InterfaceMgr.Instance.closeFilterPanel();
					InterfaceMgr.Instance.closeSelectedVillagePanel();
					InterfaceMgr.Instance.closeTraderInfoPanel();
					InterfaceMgr.Instance.closeArmySelectedPanel();
					InterfaceMgr.Instance.closePersonInfoPanel();
					InterfaceMgr.Instance.clearAndCloseUserInfo();
					InterfaceMgr.Instance.displayReinforcementSelectPanel(num8);
					return;
				}
				long num9 = this.findNearestTraderFromScreenPos(mousePos, ref num4);
				if (num9 >= 0L && (num6 == -1 || num4 <= num))
				{
					GameEngine.Instance.playInterfaceSound("WorldMap_trader", false);
					WorldMap.LocalTrader localTrader = (WorldMap.LocalTrader)this.traderArray[num9];
					if (flag)
					{
						this.setZooming(27.0, localTrader.displayX, localTrader.displayY);
					}
					InterfaceMgr.Instance.closeFilterPanel();
					InterfaceMgr.Instance.closeSelectedVillagePanel();
					InterfaceMgr.Instance.closeArmySelectedPanel();
					InterfaceMgr.Instance.closeReinforcementSelectedPanel();
					InterfaceMgr.Instance.closePersonInfoPanel();
					InterfaceMgr.Instance.clearAndCloseUserInfo();
					InterfaceMgr.Instance.displayTraderInfoPanel(num9);
					return;
				}
				long num10 = this.findNearestPersonFromScreenPos(mousePos, ref num5);
				if (num10 >= 0L && (num6 == -1 || num5 <= num))
				{
					WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)this.personArray[num10];
					if (localPerson.person.personType == 100)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_rat", false);
					}
					else
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_monk", false);
					}
					if (flag)
					{
						this.setZooming(27.0, localPerson.displayX, localPerson.displayY);
					}
					InterfaceMgr.Instance.closeFilterPanel();
					InterfaceMgr.Instance.closeSelectedVillagePanel();
					InterfaceMgr.Instance.closeArmySelectedPanel();
					InterfaceMgr.Instance.closeReinforcementSelectedPanel();
					InterfaceMgr.Instance.closeTraderInfoPanel();
					InterfaceMgr.Instance.clearAndCloseUserInfo();
					InterfaceMgr.Instance.displayPersonInfoPanel(num10);
					return;
				}
			}
			InterfaceMgr.Instance.closeArmySelectedPanel();
			InterfaceMgr.Instance.closeTraderInfoPanel();
			InterfaceMgr.Instance.closeReinforcementSelectedPanel();
			InterfaceMgr.Instance.closePersonInfoPanel();
			if (num6 >= 0)
			{
				bool flag3 = true;
				if (this.PickingStartCounty && (this.worldMapFilter.showVillage(num6) >= 0 || (GameEngine.Instance.World.isCountyCapital(num6) && GameEngine.Instance.World.worldMapFilter.FilterMode == 11)))
				{
					InterfaceMgr.Instance.displaySelectedVillagePanel(num6, doubleClick, true, false, false);
				}
				if (this.villageList[num6].special == 30)
				{
					InterfaceMgr.Instance.displaySelectedVillagePanel(num6, doubleClick, true, false, false);
					return;
				}
				if (this.WorldZoom < 1.1)
				{
					int countyID = (int)this.villageList[num6].countyID;
					if (countyID >= 0)
					{
						PointF centrePoint = this.countyList[countyID].getCentrePoint();
						if (flag)
						{
							this.setZooming(2.1, (double)centrePoint.X, (double)centrePoint.Y);
						}
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
						return;
					}
				}
				else if (this.WorldZoom < 3.1)
				{
					int countyID2 = (int)this.villageList[num6].countyID;
					if (countyID2 >= 0)
					{
						PointF centrePoint2 = this.countyList[countyID2].getCentrePoint();
						if (flag)
						{
							this.setZooming(3.5, (double)centrePoint2.X, (double)centrePoint2.Y);
						}
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
						return;
					}
				}
				else if (this.WorldZoom < 5.5)
				{
					int regionID = (int)this.villageList[num6].regionID;
					if (regionID >= 0)
					{
						PointF centrePoint3 = this.regionList[regionID].getCentrePoint();
						if (flag)
						{
							this.setZooming(6.01, (double)centrePoint3.X, (double)centrePoint3.Y);
						}
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
						return;
					}
				}
				else if (this.WorldZoom < 8.0)
				{
					int regionID2 = (int)this.villageList[num6].regionID;
					if (regionID2 >= 0)
					{
						PointF centrePoint4 = this.regionList[regionID2].getCentrePoint();
						if (flag)
						{
							this.setZooming(9.51, (double)centrePoint4.X, (double)centrePoint4.Y);
						}
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
						return;
					}
				}
				else if (this.WorldZoom > 14.5)
				{
					if (flag)
					{
						this.setZooming(27.0, (double)this.villageList[num6].x, (double)this.villageList[num6].y);
					}
					if (this.m_worldZoomInverted > 0.10000000149011612)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					}
					if (this.isVillageVisible(num6))
					{
						if (this.isCapital(num6))
						{
							if (this.isRegionCapital(num6))
							{
								if (this.isUserVillage(num6))
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_parish_capital_clicked_player_owned", false);
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_parish_capital_clicked", false);
								}
							}
							if (this.isCountyCapital(num6))
							{
								if (this.isUserVillage(num6))
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_county_capital_clicked_player_owned", false);
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_county_capital_clicked", false);
								}
							}
							if (this.isProvinceCapital(num6))
							{
								if (this.isUserVillage(num6))
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_province_capital_clicked_player_owned", false);
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_province_capital_clicked", false);
								}
							}
							if (this.isCountryCapital(num6))
							{
								if (this.isUserVillage(num6))
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_country_capital_clicked_player_owned", false);
								}
								else
								{
									GameEngine.Instance.playInterfaceSound("WorldMap_country_capital_clicked", false);
								}
							}
						}
						else if (this.isSpecial(num6))
						{
							int special = this.getSpecial(num6);
							if (SpecialVillageTypes.IS_TREASURE_CASTLE(special) || SpecialVillageTypes.IS_ROYAL_TOWER(special))
							{
								GameEngine.Instance.playInterfaceSound("WorldMap_AI_Castle_clicked", false);
							}
							else
							{
								switch (special)
								{
								case 3:
									GameEngine.Instance.playInterfaceSound("WorldMap_bandit_camp_clicked", false);
									goto IL_8B1;
								case 4:
									GameEngine.Instance.playInterfaceSound("WorldMap_bandit_camp_destroyed_clicked", false);
									goto IL_8B1;
								case 5:
									GameEngine.Instance.playInterfaceSound("WorldMap_wolf_lair_clicked", false);
									goto IL_8B1;
								case 6:
									GameEngine.Instance.playInterfaceSound("WorldMap_wolf_lair_destroyed_clicked", false);
									goto IL_8B1;
								case 7:
								case 9:
								case 11:
								case 13:
								case 15:
								case 17:
									GameEngine.Instance.playInterfaceSound("WorldMap_AI_Castle_clicked", false);
									goto IL_8B1;
								case 8:
								case 10:
								case 12:
								case 14:
								case 16:
								case 18:
									break;
								case 19:
								case 20:
									goto IL_8B1;
								case 21:
									GameEngine.Instance.playInterfaceSound("WorldMap_enemy_camp_clicked", false);
									goto IL_8B1;
								default:
									if (special != 40)
									{
										goto IL_8B1;
									}
									break;
								}
								GameEngine.Instance.playInterfaceSound("WorldMap_AI_Castle_destroyed_clicked", false);
							}
							IL_8B1:
							switch (special)
							{
							case 100:
								GameEngine.Instance.playInterfaceSound("WorldMap_unknown_resource_stash_clicked", false);
								break;
							case 106:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_wood", false);
								break;
							case 107:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_stone", false);
								break;
							case 108:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_iron", false);
								break;
							case 109:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_pitch", false);
								break;
							case 112:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_ale", false);
								break;
							case 113:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_apple", false);
								break;
							case 114:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_bread", false);
								break;
							case 115:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_veg", false);
								break;
							case 116:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_meat", false);
								break;
							case 117:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_cheese", false);
								break;
							case 118:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_fish", false);
								break;
							case 119:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_clothes", false);
								break;
							case 121:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_furniture", false);
								break;
							case 122:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_venison", false);
								break;
							case 123:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_salt", false);
								break;
							case 124:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_spices", false);
								break;
							case 125:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_silk", false);
								break;
							case 126:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_metalware", false);
								break;
							case 133:
								GameEngine.Instance.playInterfaceSound("WorldMap_resource_stash_clicked_wine", false);
								break;
							}
						}
						else if (this.isUserVillage(num6))
						{
							GameEngine.Instance.playInterfaceSound("WorldMap_user_village_clicked", false);
						}
						else if (this.getVillageUserID(num6) >= 0)
						{
							GameEngine.Instance.playInterfaceSound("WorldMap_normal_village_clicked", false);
						}
						else
						{
							GameEngine.Instance.playInterfaceSound("WorldMap_charter_clicked", false);
						}
					}
					if (InterfaceMgr.Instance.OwnSelectedVillage >= 0 || (InterfaceMgr.Instance.WorldMapMode == 0 && this.isOverVillageShield(num6, mousePos, true)))
					{
						if (InterfaceMgr.Instance.WorldMapMode == 1)
						{
							VillageData villageData2 = this.getVillageData(num6);
							if (!this.isSpecial(num6) && (this.isCapital(num6) || villageData2.userID >= 0))
							{
								flag3 = false;
								InterfaceMgr.Instance.SelectedVillage = num6;
								InterfaceMgr.Instance.setTradeWithVillage(num6);
							}
							else
							{
								InterfaceMgr.Instance.SelectedVillage = -1;
								InterfaceMgr.Instance.setTradeWithVillage(-1);
							}
						}
						else if (InterfaceMgr.Instance.WorldMapMode == 2)
						{
							if (this.isCapital(num6))
							{
								bool flag4 = true;
								if (!this.allowExchangeTrade(num6, InterfaceMgr.Instance.StockExchangeBuyingVillage))
								{
									flag4 = false;
								}
								if (flag4)
								{
									flag3 = false;
									InterfaceMgr.Instance.SelectedVillage = num6;
									InterfaceMgr.Instance.setStockExchangeSidePanelVillage(num6);
								}
								else
								{
									InterfaceMgr.Instance.SelectedVillage = -1;
									InterfaceMgr.Instance.setStockExchangeSidePanelVillage(-1);
								}
							}
						}
						else if (InterfaceMgr.Instance.WorldMapMode == 3)
						{
							VillageData villageData3 = this.getVillageData(num6);
							bool flag5 = true;
							if (this.isSpecial(num6) && !this.isAttackableSpecial(num6))
							{
								flag5 = false;
							}
							else if (!this.isSpecial(num6) && villageData3.userID < 0 && !this.isCapital(num6))
							{
								flag5 = false;
							}
							if (flag5)
							{
								flag3 = false;
								InterfaceMgr.Instance.SelectedVillage = num6;
								InterfaceMgr.Instance.setAttackTargetSidePanelVillage(num6);
							}
							else
							{
								InterfaceMgr.Instance.SelectedVillage = -1;
								InterfaceMgr.Instance.setAttackTargetSidePanelVillage(-1);
							}
						}
						else if (InterfaceMgr.Instance.WorldMapMode == 4)
						{
							VillageData villageData4 = this.getVillageData(num6);
							bool flag6 = true;
							if (this.isSpecial(num6) && !this.isScoutableSpecial(num6))
							{
								flag6 = false;
							}
							else if (!this.isSpecial(num6) && villageData4.userID < 0 && !this.isCapital(num6))
							{
								flag6 = false;
							}
							if (flag6)
							{
								flag3 = false;
								InterfaceMgr.Instance.SelectedVillage = num6;
								InterfaceMgr.Instance.setScoutTargetSidePanelVillage(num6);
							}
							else
							{
								InterfaceMgr.Instance.SelectedVillage = -1;
								InterfaceMgr.Instance.setScoutTargetSidePanelVillage(-1);
							}
						}
						else if (InterfaceMgr.Instance.WorldMapMode == 5)
						{
							VillageData villageData5 = this.getVillageData(num6);
							if (!this.isCapital(num6) && !this.isSpecial(num6) && villageData5.userID >= 0)
							{
								flag3 = false;
								InterfaceMgr.Instance.SelectedVillage = num6;
								InterfaceMgr.Instance.setReinforcementTargetSidePanelVillage(num6);
							}
							else
							{
								InterfaceMgr.Instance.SelectedVillage = -1;
								InterfaceMgr.Instance.setReinforcementTargetSidePanelVillage(-1);
							}
						}
						else if (InterfaceMgr.Instance.WorldMapMode != 6)
						{
							if (InterfaceMgr.Instance.WorldMapMode == 7)
							{
								VillageData villageData6 = this.getVillageData(num6);
								bool flag7 = true;
								if (this.isCapital(num6))
								{
									flag7 = false;
								}
								else if (this.isSpecial(num6) && !this.isAttackableSpecial(num6))
								{
									flag7 = false;
								}
								else if (!this.isSpecial(num6) && villageData6.userID < 0)
								{
									flag7 = false;
								}
								if (flag7)
								{
									flag3 = false;
									InterfaceMgr.Instance.SelectedVillage = num6;
									InterfaceMgr.Instance.setVassalSelectSidePanelVillage(num6);
								}
								else
								{
									InterfaceMgr.Instance.SelectedVillage = -1;
									InterfaceMgr.Instance.setVassalSelectSidePanelVillage(-1);
								}
							}
							else if (InterfaceMgr.Instance.WorldMapMode == 9)
							{
								VillageData villageData7 = this.getVillageData(num6);
								if (!this.isSpecial(num6) && (villageData7.userID >= 0 || villageData7.Capital))
								{
									flag3 = false;
									InterfaceMgr.Instance.SelectedVillage = num6;
									InterfaceMgr.Instance.setMonkSelectSidePanelVillage(num6);
								}
								else
								{
									InterfaceMgr.Instance.SelectedVillage = -1;
									InterfaceMgr.Instance.setMonkSelectSidePanelVillage(-1);
								}
							}
							else
							{
								bool forceSelfClick = this.isOverVillageShield(num6, mousePos, false);
								flag3 = false;
								if (this.worldMapFilter.showVillage(num6) >= 0)
								{
									InterfaceMgr.Instance.displaySelectedVillagePanel(num6, doubleClick, true, forceSelfClick, false);
								}
							}
						}
					}
					else
					{
						InterfaceMgr.Instance.clearAndCloseUserInfo();
						InterfaceMgr.Instance.displaySelectedVillagePanel(num6, doubleClick, true, false, true);
						flag3 = false;
					}
					if (flag3)
					{
						InterfaceMgr.Instance.closeSelectedVillagePanelButNotSelect();
						return;
					}
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					if (flag)
					{
						this.setZooming(27.0, (double)this.villageList[num6].x, (double)this.villageList[num6].y);
					}
				}
				return;
			}
			else
			{
				double xPos = 0.0;
				double yPos = 0.0;
				this.getMapCoords(mousePos, ref xPos, ref yPos);
				if (this.WorldZoom < 1.1 && flag)
				{
					this.setZooming(2.1, xPos, yPos);
					GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					return;
				}
				if (this.WorldZoom < 3.1 && flag)
				{
					this.setZooming(3.5, xPos, yPos);
					GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					return;
				}
				if (this.WorldZoom < 5.5 && flag)
				{
					this.setZooming(6.01, xPos, yPos);
					GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					return;
				}
				if (this.WorldZoom < 8.0 && flag)
				{
					this.setZooming(9.51, xPos, yPos);
					GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					return;
				}
				if (flag)
				{
					this.setZooming(27.0, xPos, yPos);
					if (this.m_worldZoomInverted > 0.10000000149011612)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_zoomin");
					}
				}
				return;
			}
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x0029B8C4 File Offset: 0x00299AC4
		public void windowClicked(Point mousePos, bool doubleClick)
		{
			this.lastClickedLocation = mousePos;
			if (this.WorldEnded)
			{
				if (this.SeventhAgeWorld && !GameEngine.Instance.LocalWorldData.AIWorld && mousePos.X < 90 && mousePos.Y >= 262 && mousePos.Y < 342)
				{
					InterfaceMgr.Instance.showRoyalTowerPanel();
					return;
				}
				if (InterfaceMgr.Instance.clickDXPlaybackBar(mousePos))
				{
					return;
				}
			}
			if (!this.WorldEnded)
			{
				if (InterfaceMgr.Instance.clickDXCardBar(mousePos) || InterfaceMgr.Instance.clickDXPlaybackBar(mousePos))
				{
					return;
				}
				if ((GameEngine.Instance.World.isTutorialActive() || Program.mySettings.showGameFeaturesScreenIcon) && !this.WorldEnded)
				{
					int num = this.gfx.ViewportHeight - 64;
					if (mousePos.X < 64 && mousePos.Y >= num)
					{
						if (GameEngine.Instance.World.isTutorialActive())
						{
							GameEngine.Instance.World.forceTutorialToBeShown();
							GameEngine.Instance.playInterfaceSound("WorldMap_tutorial_open");
							return;
						}
						if (Program.mySettings.showGameFeaturesScreenIcon)
						{
							PostTutorialWindow.CreatePostTutorialWindow(false);
							return;
						}
					}
				}
				if (mousePos.X < 70 && mousePos.Y >= 64 && mousePos.Y < 134)
				{
					InterfaceMgr.Instance.openFreeCardsPopup();
					GameEngine.Instance.playInterfaceSound("WorldMap_open_free_Cards");
					return;
				}
				int num2 = this.numWheelTypesAvailable();
				if (num2 > 0 && mousePos.X < 70 && mousePos.Y >= 144 && mousePos.Y < 214)
				{
					if (num2 == 1)
					{
						for (int i = -1; i < 5; i++)
						{
							if (this.getTickets(i) > 0)
							{
								InterfaceMgr.Instance.openWheelPopup(i);
								break;
							}
						}
					}
					else
					{
						InterfaceMgr.Instance.openWheelSelectPopup();
					}
					GameEngine.Instance.playInterfaceSound("WorldMap_open_wheel");
					return;
				}
				if (mousePos.X > this.m_screenWidth - 30 && mousePos.Y > 30 && mousePos.Y < 60)
				{
					CustomSelfDrawPanel.WikiLinkControl.openHelpLink(0);
					return;
				}
				if (this.SeventhAgeWorld && !GameEngine.Instance.LocalWorldData.AIWorld && mousePos.X < 90 && mousePos.Y >= 262 && mousePos.Y < 342)
				{
					InterfaceMgr.Instance.showRoyalTowerPanel();
					return;
				}
				DateTime t = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleStartTime);
				DateTime t2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.saleEndTime);
				bool flag = t <= VillageMap.getCurrentServerTime() && t2 > VillageMap.getCurrentServerTime();
				if (flag && mousePos.X > this.m_screenWidth - 140 && mousePos.Y > this.m_screenHeight - 130)
				{
					InterfaceMgr.Instance.openPlayCardsWindow(0);
					PlayCardsWindow playCardsWindow = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
					playCardsWindow.GetCrowns("&click=saleindicator");
					return;
				}
				if (GameEngine.Instance.cardsManager.PremiumOfferAvailable())
				{
					int num3 = this.m_screenHeight - 130;
					if (flag)
					{
						num3 = this.m_screenHeight - 130 - 160;
					}
					if (mousePos.X > this.m_screenWidth - 140 && mousePos.Y > num3 && mousePos.Y < num3 + 130)
					{
						InterfaceMgr.Instance.openPlayCardsWindow(0);
						PlayCardsWindow playCardsWindow2 = (PlayCardsWindow)InterfaceMgr.Instance.getCardWindow();
						playCardsWindow2.SwitchPanel(9);
						GameEngine.Instance.cardsManager.PremiumOffersViewed = true;
						return;
					}
				}
			}
			if (GameEngine.Instance.World.pendingPrizes != null && GameEngine.Instance.World.pendingPrizes.Count > 0)
			{
				if ((float)mousePos.X < this.contestSprite.Width && (float)mousePos.Y > this.contestSprite.PosY && (float)mousePos.Y < this.contestSprite.PosY + this.contestSprite.Height)
				{
					GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
					PrizeClaimWindow.CreatePrizeClaimWindow();
					return;
				}
			}
			else if (GameEngine.Instance.World.contestID >= 0)
			{
				DateTime t3 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestStartTime);
				DateTime t4 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)GameEngine.Instance.World.contestEndTime);
				if (t3 <= VillageMap.getCurrentServerTime() && t4 > VillageMap.getCurrentServerTime() && (float)mousePos.X < this.contestSprite.Width && (float)mousePos.Y > this.contestSprite.PosY && (float)mousePos.Y < this.contestSprite.PosY + this.contestSprite.Height)
				{
					GameEngine.Instance.playInterfaceSound("WorldMapScreen_menu_leaderboard");
					InterfaceMgr.Instance.getMainTabBar().selectDummyTab(30);
					return;
				}
			}
			this.clickOnMapIcon(mousePos, doubleClick);
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x0029BE18 File Offset: 0x0029A018
		public void centerOverVillage(int villageID)
		{
			if (this.villageList != null && this.villageList.Length > villageID && villageID >= 0)
			{
				this.m_screenCentreX = (double)this.villageList[villageID].x;
				this.m_screenCentreY = (double)this.villageList[villageID].y;
			}
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x0002499B File Offset: 0x00022B9B
		public void zoomToVillage(int villageID)
		{
			this.startMultiStageZoom(27.0, (double)this.villageList[villageID].x, (double)this.villageList[villageID].y);
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x0029BE64 File Offset: 0x0029A064
		public void zoomToArmy(long armyID)
		{
			WorldMap.LocalArmyData armyByID = this.GetArmyByID(armyID);
			if (armyByID != null)
			{
				this.startMultiStageZoom(27.0, armyByID.displayX, armyByID.displayY);
			}
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x0029BE98 File Offset: 0x0029A098
		public void zoomtoReinforcement(long armyID)
		{
			WorldMap.LocalArmyData reinformcementArmyByID = this.GetReinformcementArmyByID(armyID);
			if (reinformcementArmyByID != null)
			{
				this.startMultiStageZoom(27.0, reinformcementArmyByID.displayX, reinformcementArmyByID.displayY);
			}
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x0029BECC File Offset: 0x0029A0CC
		public void zoomToTrader(long traderID)
		{
			WorldMap.LocalTrader trader = this.getTrader(traderID);
			if (trader != null)
			{
				this.startMultiStageZoom(27.0, trader.displayX, trader.displayY);
			}
		}

		// Token: 0x060032C9 RID: 13001 RVA: 0x0029BF00 File Offset: 0x0029A100
		public void zoomToPerson(long personID)
		{
			WorldMap.LocalPerson person = this.getPerson(personID);
			if (person != null)
			{
				this.startMultiStageZoom(27.0, person.displayX, person.displayY);
			}
		}

		// Token: 0x060032CA RID: 13002 RVA: 0x000249C8 File Offset: 0x00022BC8
		public void capZoom(double cap)
		{
			this.m_zoomCap = cap;
			this.capZoomIFace((float)cap);
		}

		// Token: 0x060032CB RID: 13003 RVA: 0x0029BF34 File Offset: 0x0029A134
		public void zoomOut()
		{
			InterfaceMgr.Instance.clearAndCloseUserInfo();
			InterfaceMgr.Instance.closeSelectedVillagePanelButNotSelect();
			InterfaceMgr.Instance.closeArmySelectedPanel();
			InterfaceMgr.Instance.closeReinforcementSelectedPanel();
			InterfaceMgr.Instance.closePersonInfoPanel();
			InterfaceMgr.Instance.closeTraderInfoPanel();
			if (this.m_zooming && this.m_zoomDiff < 0.0)
			{
				return;
			}
			if (this.WorldZoom > 9.51)
			{
				this.setZooming(9.51, this.m_screenCentreX, this.m_screenCentreY);
				GameEngine.Instance.playInterfaceSound("WorldMap_zoomout");
				return;
			}
			if (this.WorldZoom > 6.02)
			{
				this.setZooming(6.01, this.m_screenCentreX, this.m_screenCentreY);
				GameEngine.Instance.playInterfaceSound("WorldMap_zoomout");
				return;
			}
			if (this.WorldZoom > 4.02)
			{
				this.setZooming(4.01, this.m_screenCentreX, this.m_screenCentreY);
				GameEngine.Instance.playInterfaceSound("WorldMap_zoomout");
				return;
			}
			if (this.WorldZoom > 2.12)
			{
				this.setZooming(2.11, this.m_screenCentreX, this.m_screenCentreY);
				GameEngine.Instance.playInterfaceSound("WorldMap_zoomout");
				return;
			}
			this.setZooming(this.m_zoomCap, this.m_screenCentreX, this.m_screenCentreY);
			if (this.m_worldZoomInverted < 26.899999998509884)
			{
				GameEngine.Instance.playInterfaceSound("WorldMap_zoomout");
			}
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x000249D9 File Offset: 0x00022BD9
		public void zoomOutMax()
		{
			this.setZooming(this.m_zoomCap, this.m_screenCentreX, this.m_screenCentreY);
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x0029C0C0 File Offset: 0x0029A2C0
		public void startMultiStageZoom(double targetZoom, double xPos, double yPos)
		{
			if (targetZoom > 27.0)
			{
				targetZoom = 27.0;
			}
			this.m_stagedTargetZoom = targetZoom;
			this.m_stagedTargetX = xPos;
			this.m_stagedTargetY = yPos;
			double worldZoom = this.WorldZoom;
			if (worldZoom > 9.51)
			{
				this.m_zoomStage = 0;
			}
			else if (worldZoom > 3.51)
			{
				this.m_zoomStage = 1;
			}
			else if (worldZoom > this.m_zoomCap + 0.5)
			{
				this.m_zoomStage = 2;
			}
			else
			{
				this.m_zoomStage = 3;
			}
			this.m_multiStageSoundMode = 0;
			this.nextStageZoom(true);
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x0029C15C File Offset: 0x0029A35C
		public void nextStageZoom(bool initialStage)
		{
			UniversalDebugLog.Log("stage: " + this.m_zoomStage.ToString());
			if (this.m_zoomStage < 0)
			{
				return;
			}
			int num = this.m_zoomStage;
			switch (num)
			{
			case 0:
				if (this.m_stagedTargetZoom == 27.0)
				{
					double num2 = (this.m_screenCentreX - this.m_stagedTargetX) * (this.m_screenCentreX - this.m_stagedTargetX) + (this.m_screenCentreY - this.m_stagedTargetY) * (this.m_screenCentreY - this.m_stagedTargetY);
					if (num2 < 10000.0)
					{
						num = 5;
					}
					else if (num2 < 30625.0)
					{
						num = 4;
					}
				}
				if (num != 0)
				{
					if (num != 4)
					{
						if (num == 5)
						{
							this.m_zoomStage = num + 1;
							this.setZooming(27.0, this.m_stagedTargetX, this.m_stagedTargetY, initialStage);
						}
					}
					else
					{
						this.setZooming(9.5, (this.m_screenCentreX - this.m_stagedTargetX) / 2.0 + this.m_stagedTargetX, (this.m_screenCentreY - this.m_stagedTargetY) / 2.0 + this.m_stagedTargetY, initialStage);
					}
				}
				else
				{
					this.setZooming(9.5, this.m_screenCentreX, this.m_screenCentreY, initialStage);
				}
				break;
			case 1:
				if (this.m_stagedTargetZoom >= 9.5)
				{
					double num3 = (this.m_screenCentreX - this.m_stagedTargetX) * (this.m_screenCentreX - this.m_stagedTargetX) + (this.m_screenCentreY - this.m_stagedTargetY) * (this.m_screenCentreY - this.m_stagedTargetY);
					if (num3 < 360000.0)
					{
						num = 3;
					}
				}
				if (num == 1)
				{
					this.setZooming(3.5, this.m_screenCentreX, this.m_screenCentreY, initialStage);
				}
				else
				{
					this.setZooming(3.5, (this.m_screenCentreX - this.m_stagedTargetX) / 2.0 + this.m_stagedTargetX, (this.m_screenCentreY - this.m_stagedTargetY) / 2.0 + this.m_stagedTargetY, initialStage);
				}
				break;
			case 2:
				this.setZooming(this.m_zoomCap, (this.m_screenCentreX - this.m_stagedTargetX) / 2.0 + this.m_stagedTargetX, (this.m_screenCentreY - this.m_stagedTargetY) / 2.0 + this.m_stagedTargetY, initialStage);
				break;
			case 3:
				this.setZooming(3.5, this.m_stagedTargetX, this.m_stagedTargetY, initialStage);
				break;
			case 4:
				this.setZooming(9.5, this.m_stagedTargetX, this.m_stagedTargetY, initialStage);
				break;
			case 5:
				this.m_zoomStage = num + 1;
				this.setZooming(27.0, this.m_stagedTargetX, this.m_stagedTargetY, initialStage);
				break;
			}
			this.m_zoomStage = num + 1;
			if (num >= 3)
			{
				if (this.m_stagedTargetZoom <= this.m_targetZoom)
				{
					this.m_zoomStage = -1;
				}
				this.centreMap(true);
			}
		}

		// Token: 0x060032CF RID: 13007 RVA: 0x000249F3 File Offset: 0x00022BF3
		public void setZooming(double targetZoom, double xPos, double yPos)
		{
			UniversalDebugLog.Log("setZooming 3");
			this.setZooming(targetZoom, xPos, yPos, 16.0);
		}

		// Token: 0x060032D0 RID: 13008 RVA: 0x0029C46C File Offset: 0x0029A66C
		public void setZooming(double targetZoom, double xPos, double yPos, bool initialStage)
		{
			UniversalDebugLog.Log("setZooming 1");
			if (initialStage)
			{
				double num = (targetZoom - this.WorldZoom) / 16.0;
				if (num == 0.0)
				{
					if (xPos != this.m_screenCentreX || yPos != this.m_screenCentreY)
					{
						GameEngine.Instance.playInterfaceSound("WorldMap_map_moving_sideways");
					}
				}
				else if (num < 0.0)
				{
					this.m_multiStageSoundMode = 1;
					GameEngine.Instance.playInterfaceSound("WorldMap_map_zooming_out");
				}
				else
				{
					GameEngine.Instance.playInterfaceSound("WorldMap_map_zooming_in");
				}
			}
			else if (this.m_multiStageSoundMode == 1)
			{
				double num2 = (targetZoom - this.WorldZoom) / 16.0;
				if (num2 > 0.0)
				{
					GameEngine.Instance.playInterfaceSound("WorldMap_map_zooming_in");
					this.m_multiStageSoundMode = 2;
				}
			}
			this.setZooming(targetZoom, xPos, yPos, 16.0);
		}

		// Token: 0x060032D1 RID: 13009 RVA: 0x0029C554 File Offset: 0x0029A754
		public void setZoomingPaced(double targetZoom, double xPos, double yPos)
		{
			if (targetZoom > 27.0)
			{
				targetZoom = 27.0;
			}
			double num = 16.0;
			double num2 = Math.Abs(xPos - this.m_screenCentreX);
			double num3 = Math.Abs(yPos - this.m_screenCentreY);
			if (num3 > num2)
			{
				num2 = num3;
			}
			if (num2 > 300.0)
			{
				num *= num2 / 300.0;
			}
			this.setZooming(targetZoom, xPos, yPos, num);
		}

		// Token: 0x060032D2 RID: 13010 RVA: 0x0029C5C8 File Offset: 0x0029A7C8
		public void setZooming(double targetZoom, double xPos, double yPos, double zoomTime)
		{
			UniversalDebugLog.Log("setZooming 2");
			if (GameEngine.Instance.World.playbackActive())
			{
				return;
			}
			bool flag = false;
			if (this.m_zoomStage >= 0 && this.m_zoomStage < 6)
			{
				flag = true;
			}
			this.m_zoomStage = -1;
			this.m_zooming = true;
			this.m_targetZoom = targetZoom;
			this.m_zoomDiff = (this.m_targetZoom - this.WorldZoom) / zoomTime;
			if (targetZoom == 27.0 && this.m_worldZoomInverted < 0.001)
			{
				this.m_zoomDiff = 0.0;
			}
			if (!flag)
			{
				this.m_zoomXPosTarget = xPos;
				this.m_zoomYPosTarget = yPos;
				double screenCentreX = this.m_screenCentreX;
				double screenCentreY = this.m_screenCentreY;
				this.m_screenCentreX = xPos;
				this.m_screenCentreY = yPos;
				this.centreMap(true);
				xPos = this.m_screenCentreX;
				yPos = this.m_screenCentreY;
				this.m_screenCentreX = screenCentreX;
				this.m_screenCentreY = screenCentreY;
			}
			if (this.m_zoomDiff != 0.0 && Math.Abs(this.m_zoomDiff) < 0.07)
			{
				if (this.m_zoomDiff < 0.0)
				{
					this.m_zoomDiff = -0.07;
				}
				else
				{
					this.m_zoomDiff = 0.07;
				}
			}
			this.m_zoomXPosTarget = xPos;
			this.m_zoomYPosTarget = yPos;
			this.m_zoomXPosDiff = (xPos - this.m_screenCentreX) / zoomTime;
			this.m_zoomYPosDiff = (yPos - this.m_screenCentreY) / zoomTime;
		}

		// Token: 0x060032D3 RID: 13011 RVA: 0x0029C738 File Offset: 0x0029A938
		private int findNearestVillageFromScreenPos(Point mousePos, ref double bestDist)
		{
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestVillageFromMapPos(num, num2, ref bestDist);
			}
			return -1;
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x0029C7D0 File Offset: 0x0029A9D0
		private int findNearestVillageFromScreenPosAnyVis(Point mousePos, ref double bestDist)
		{
			double num = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
			double num2 = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			if (num >= 0.0 && num < (double)this.worldMapWidth && num2 >= 0.0 && num2 < (double)this.worldMapHeight)
			{
				return this.findNearestVillageFromMapPosAnyVis(num, num2, ref bestDist);
			}
			return -1;
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x0029C868 File Offset: 0x0029AA68
		private void getMapCoords(Point mousePos, ref double mapPosX, ref double mapPosY)
		{
			if (!WorldMap.KILL_SCROLLING)
			{
				mapPosX = ((double)mousePos.X - (double)this.m_screenWidth / 2.0) / this.m_worldScale + this.m_screenCentreX;
				mapPosY = ((double)mousePos.Y - (double)this.m_screenHeight / 2.0) / this.m_worldScale + this.m_screenCentreY;
			}
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x0029C8D0 File Offset: 0x0029AAD0
		private Point getScreenPosFromMapCoords(double mapX, double mapY)
		{
			return new Point
			{
				X = (int)((mapX - this.m_screenCentreX) * this.m_worldScale + (double)this.m_screenWidth / 2.0),
				Y = (int)((mapY - this.m_screenCentreY) * this.m_worldScale + (double)this.m_screenHeight / 2.0)
			};
		}

		// Token: 0x060032D7 RID: 13015 RVA: 0x0029C938 File Offset: 0x0029AB38
		public int findNearestVillageFromMapPos(double mapX, double mapY, ref double bestDist)
		{
			int result = -1;
			double num = 64.0;
			if (this.PickingStartCounty)
			{
				num = 16384.0;
			}
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				if (villageData.visible && (!this.PickingStartCounty || villageData.countyCapital))
				{
					double num2 = ((double)villageData.x - mapX) * ((double)villageData.x - mapX) + ((double)villageData.y - mapY) * ((double)villageData.y - mapY);
					if (num2 < num)
					{
						num = num2;
						result = villageData.id;
					}
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x060032D8 RID: 13016 RVA: 0x0029C9E0 File Offset: 0x0029ABE0
		public int findNearestVillageFromMapPosAnyVis(double mapX, double mapY, ref double bestDist)
		{
			int result = -1;
			double num = 64.0;
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				double num2 = ((double)villageData.x - mapX) * ((double)villageData.x - mapX) + ((double)villageData.y - mapY) * ((double)villageData.y - mapY);
				if (num2 < num)
				{
					num = num2;
					result = villageData.id;
				}
			}
			bestDist = num;
			return result;
		}

		// Token: 0x060032D9 RID: 13017 RVA: 0x00024A11 File Offset: 0x00022C11
		public void stopZoom()
		{
			this.m_zooming = false;
			this.m_zoomStage = -1;
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x0029CA5C File Offset: 0x0029AC5C
		private void updateZooming()
		{
			this.m_zoomChangeThisFrame = 0.0;
			if (!this.m_zooming)
			{
				return;
			}
			double screenCentreX = this.m_screenCentreX;
			double screenCentreY = this.m_screenCentreY;
			double num = this.WorldZoom + this.m_zoomDiff;
			this.m_zoomChangeThisFrame = this.m_zoomDiff;
			this.moveMap(this.m_zoomXPosDiff, this.m_zoomYPosDiff);
			if (this.m_zoomXPosDiff < 0.0)
			{
				if (this.m_screenCentreX < this.m_zoomXPosTarget)
				{
					this.m_screenCentreX = this.m_zoomXPosTarget;
					this.m_zoomXPosDiff = 0.0;
				}
			}
			else if (this.m_screenCentreX > this.m_zoomXPosTarget)
			{
				this.m_screenCentreX = this.m_zoomXPosTarget;
				this.m_zoomXPosDiff = 0.0;
			}
			if (this.m_zoomYPosDiff < 0.0)
			{
				if (this.m_screenCentreY < this.m_zoomYPosTarget)
				{
					this.m_screenCentreY = this.m_zoomYPosTarget;
					this.m_zoomYPosDiff = 0.0;
				}
			}
			else if (this.m_screenCentreY > this.m_zoomYPosTarget)
			{
				this.m_screenCentreY = this.m_zoomYPosTarget;
				this.m_zoomYPosDiff = 0.0;
			}
			if (Math.Abs(this.m_zoomXPosTarget - this.m_screenCentreX) < 0.1)
			{
				this.m_zoomXPosDiff = 0.0;
			}
			if (Math.Abs(this.m_zoomYPosTarget - this.m_screenCentreY) < 0.1)
			{
				this.m_zoomYPosDiff = 0.0;
			}
			if (this.m_zoomDiff > 0.0)
			{
				if (num >= this.m_targetZoom)
				{
					this.m_zoomChangeThisFrame = this.m_targetZoom - this.WorldZoom;
					this.m_zoomDiff = 0.0;
					this.WorldZoom = this.m_targetZoom;
				}
			}
			else if (this.m_zoomDiff < 0.0 && num <= this.m_targetZoom)
			{
				this.m_zoomChangeThisFrame = this.m_targetZoom - this.WorldZoom;
				this.m_zoomDiff = 0.0;
				this.WorldZoom = this.m_targetZoom;
			}
			if (this.m_zoomStage < 0 && this.m_zoomDiff <= 0.0)
			{
				this.centreMap(false);
			}
			if (this.m_zoomDiff == 0.0 && screenCentreX == this.m_screenCentreX && screenCentreY == this.m_screenCentreY)
			{
				this.m_zoomXPosDiff = 0.0;
				this.m_zoomXPosDiff = 0.0;
			}
			if (this.m_zoomDiff == 0.0 && this.m_zoomXPosDiff == 0.0 && this.m_zoomYPosDiff == 0.0)
			{
				this.m_zooming = false;
				this.nextStageZoom(false);
			}
		}

		// Token: 0x060032DB RID: 13019 RVA: 0x00024A21 File Offset: 0x00022C21
		public void registerWorldZoomCallback(WorldMap.WorldZoomCallback newWorldZoomCallback)
		{
			this.worldZoomCallback = newWorldZoomCallback;
		}

		// Token: 0x060032DC RID: 13020 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public void capZoomIFace(float cap)
		{
		}

		// Token: 0x060032DD RID: 13021 RVA: 0x00024A2A File Offset: 0x00022C2A
		public void setCurrentZoom(float zoom)
		{
			this.zoomCurrent = (int)(zoom * 1000f);
		}

		// Token: 0x060032DE RID: 13022 RVA: 0x0029CD14 File Offset: 0x0029AF14
		public void changeZoom(float change, Point mousePos)
		{
			if (!GameEngine.Instance.World.playbackActive())
			{
				double num = 0.0;
				double num2 = 0.0;
				this.getMapCoords(mousePos, ref num, ref num2);
				int num3 = (int)(change * 1000f);
				if (num3 < this.zoomMin)
				{
					num3 = this.zoomMin;
				}
				if (num3 > this.zoomMax)
				{
					num3 = this.zoomMax;
				}
				this.zoomCurrent = num3;
				this.worldZoomCallback((double)this.zoomCurrent / 1000.0, false);
				if (num3 < this.zoomMax)
				{
					double num4 = 0.0;
					double num5 = 0.0;
					this.getMapCoords(mousePos, ref num4, ref num5);
					num += this.m_screenCentreX - num4;
					num2 += this.m_screenCentreY - num5;
					this.m_screenCentreX = num;
					this.m_screenCentreY = num2;
				}
				if (this.m_zoomDiff <= 0.0)
				{
					this.centreMap(false);
				}
			}
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x0029CE08 File Offset: 0x0029B008
		public void setMouseWheelZoomOut(float change)
		{
			if ((float)this.zoomCurrent > 0.1f)
			{
				GameEngine.Instance.playInterfaceSound("WorldMap_mousewheel_zoomout");
			}
			int num = (int)(change * 1000f);
			if (num < this.zoomMin)
			{
				num = this.zoomMin;
			}
			if (num > this.zoomMax)
			{
				num = this.zoomMax;
			}
			this.zoomCurrent = num;
			this.worldZoomCallback((double)this.zoomCurrent / 1000.0, false);
			this.centreMap(false);
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x0029CE88 File Offset: 0x0029B088
		public void changeZoom(float change)
		{
			int num = this.zoomCurrent + (int)(change * 1000f);
			if (num < this.zoomMin)
			{
				num = this.zoomMin;
			}
			if (num > this.zoomMax)
			{
				num = this.zoomMax;
			}
			this.zoomCurrent = num;
			this.worldZoomCallback((double)this.zoomCurrent / 1000.0, false);
		}

		// Token: 0x060032E1 RID: 13025 RVA: 0x0029CEEC File Offset: 0x0029B0EC
		public void startGameZoom(int villageID)
		{
			double targetZoom = 0.0;
			if (villageID >= 0)
			{
				VillageData villageData = this.villageList[villageID];
				this.setZooming(27.0, (double)villageData.x, (double)villageData.y);
				while (this.Zooming)
				{
					this.updateZooming();
					if (this.ZoomChange != 0.0)
					{
						this.changeZoom((float)this.ZoomChange);
						this.centreMap(false);
					}
				}
				return;
			}
			this.setZooming(targetZoom, 0.0, 0.0);
			while (this.Zooming)
			{
				this.updateZooming();
				if (this.ZoomChange != 0.0)
				{
					this.changeZoom((float)this.ZoomChange);
					this.centreMap(false);
				}
			}
		}

		// Token: 0x060032E2 RID: 13026 RVA: 0x00024A3A File Offset: 0x00022C3A
		public void Update()
		{
			this.updateZooming();
		}

		// Token: 0x060032E3 RID: 13027 RVA: 0x00024A42 File Offset: 0x00022C42
		public Color getColorFromFaction(int factionID)
		{
			if (factionID > 20)
			{
				factionID = 0;
			}
			return WorldMap.areaColorList[factionID];
		}

		// Token: 0x060032E4 RID: 13028 RVA: 0x0029CFB4 File Offset: 0x0029B1B4
		public void initSprites(GraphicsMgr newGFX)
		{
			this.gfx = newGFX;
			this.villageSprite = new SpriteWrapper();
			this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapTilesTexID;
			this.villageSprite.SpriteNo = 0;
			this.villageSprite.Initialize(this.gfx);
			this.villageSprite.AutoCentre = true;
			this.villageSprite = new SpriteWrapper();
			this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapTilesTexID;
			this.villageSprite.SpriteNo = 0;
			this.villageSprite.Initialize(this.gfx);
			this.villageSprite.AutoCentre = true;
			this.worldTileSprite.TextureID = GFXLibrary.Instance.WorldMapTilesTexID;
			this.worldTileSprite.SpriteNo = 0;
			this.worldTileSprite.PolySprite = true;
			this.worldTileSprite.Initialize(this.gfx);
			this.worldTreeSprite.TextureID = GFXLibrary.Instance.MapElementsTexID;
			this.worldTreeSprite.SpriteNo = 0;
			this.worldTreeSprite.PolySprite = true;
			this.worldTreeSprite.Initialize(this.gfx);
			this.overlaySprite.TextureID = GFXLibrary.Instance.EffectLayerTexID;
			this.overlaySprite.SpriteNo = 0;
			this.overlaySprite.PolySprite = true;
			this.overlaySprite.Initialize(this.gfx);
			this.updateClockSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.updateClockSprite.SpriteNo = 30;
			this.updateClockSprite.PolySprite = true;
			this.updateClockSprite.Initialize(this.gfx);
			this.tutorialOverlaySprite.TextureID = GFXLibrary.Instance.TutorialIconNormalID;
			this.tutorialOverlaySprite.SpriteNo = 0;
			this.tutorialOverlaySprite.PolySprite = true;
			this.tutorialOverlaySprite.Initialize(this.gfx);
			this.freeCardsSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.freeCardsSprite.SpriteNo = 0;
			this.freeCardsSprite.PolySprite = false;
			this.freeCardsSprite.Initialize(this.gfx);
			this.freeCardsSprite2.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.freeCardsSprite2.SpriteNo = 0;
			this.freeCardsSprite2.PolySprite = false;
			this.freeCardsSprite2.Initialize(this.gfx);
			this.wolfsRevengeSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.wolfsRevengeSprite.SpriteNo = 0;
			this.wolfsRevengeSprite.PolySprite = false;
			this.wolfsRevengeSprite.Initialize(this.gfx);
			this.wolfsRevengeSprite2.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.wolfsRevengeSprite2.SpriteNo = 0;
			this.wolfsRevengeSprite2.PolySprite = false;
			this.wolfsRevengeSprite2.Initialize(this.gfx);
			this.saleSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.saleSprite.SpriteNo = 0;
			this.saleSprite.PolySprite = false;
			this.saleSprite.Initialize(this.gfx);
			bool flag = GameEngine.Instance.World.salePercentage > 99;
			for (int i = 0; i < (flag ? 5 : 4); i++)
			{
				SpriteWrapper spriteWrapper = new SpriteWrapper();
				spriteWrapper.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				spriteWrapper.SpriteNo = 0;
				spriteWrapper.PolySprite = false;
				spriteWrapper.Initialize(this.gfx);
				this.saleDigits.Add(spriteWrapper);
			}
			for (int j = 0; j < 5; j++)
			{
				SpriteWrapper spriteWrapper2 = new SpriteWrapper();
				spriteWrapper2.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				spriteWrapper2.SpriteNo = 0;
				spriteWrapper2.PolySprite = false;
				spriteWrapper2.Initialize(this.gfx);
				this.saleTimer.Add(spriteWrapper2);
			}
			this.offerSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.offerSprite.SpriteNo = 0;
			this.offerSprite.PolySprite = false;
			this.offerSprite.Initialize(this.gfx);
			for (int k = 0; k < 8; k++)
			{
				SpriteWrapper spriteWrapper3 = new SpriteWrapper();
				spriteWrapper3.TextureID = GFXLibrary.Instance.FreeCardIconsID;
				spriteWrapper3.SpriteNo = 0;
				spriteWrapper3.PolySprite = false;
				spriteWrapper3.Initialize(this.gfx);
				this.offerTimer.Add(spriteWrapper3);
			}
			this.seaSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.seaSprite.SpriteNo = 0;
			this.seaSprite.PolySprite = false;
			this.seaSprite.Initialize(this.gfx);
			this.royalTowerSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.royalTowerSprite.SpriteNo = 0;
			this.royalTowerSprite.PolySprite = false;
			this.royalTowerSprite.Initialize(this.gfx);
			this.royalTowerSprite1.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.royalTowerSprite1.SpriteNo = 0;
			this.royalTowerSprite1.PolySprite = false;
			this.royalTowerSprite1.Initialize(this.gfx);
			this.royalTowerSprite2.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.royalTowerSprite2.SpriteNo = 0;
			this.royalTowerSprite2.PolySprite = false;
			this.royalTowerSprite2.Initialize(this.gfx);
			this.royalTowerSprite3.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.royalTowerSprite3.SpriteNo = 0;
			this.royalTowerSprite3.PolySprite = false;
			this.royalTowerSprite3.Initialize(this.gfx);
			this.contestSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.contestSprite.SpriteNo = 0;
			this.contestSprite.PolySprite = false;
			this.contestSprite.Initialize(this.gfx);
			this.ticketsSprite.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.ticketsSprite.SpriteNo = 0;
			this.ticketsSprite.PolySprite = false;
			this.ticketsSprite.Initialize(this.gfx);
			this.ticketsSprite2.TextureID = GFXLibrary.Instance.FreeCardIconsID;
			this.ticketsSprite2.SpriteNo = 0;
			this.ticketsSprite2.PolySprite = false;
			this.ticketsSprite2.Initialize(this.gfx);
		}

		// Token: 0x060032E5 RID: 13029 RVA: 0x0029D5F8 File Offset: 0x0029B7F8
		public void updateSeasonalGFX()
		{
			this.overlaySprite.TextureID = GFXLibrary.Instance.EffectLayerTexID;
			this.worldTreeSprite.TextureID = GFXLibrary.Instance.MapElementsTexID;
			if (this.villageSprite != null)
			{
				this.villageSprite.TextureID = GFXLibrary.Instance.WorldMapTilesTexID;
			}
			this.worldTileSprite.TextureID = GFXLibrary.Instance.WorldMapTilesTexID;
		}

		// Token: 0x060032E6 RID: 13030 RVA: 0x0029D664 File Offset: 0x0029B864
		public void initMapTiles(string fileName, int width, int height)
		{
			this.TILEMAP_WIDTH = width;
			this.TILEMAP_HEIGHT = height;
			this.mapTileGrid = new short[this.TILEMAP_WIDTH, this.TILEMAP_HEIGHT];
			this.tree1Grid = new byte[this.TILEMAP_WIDTH, this.TILEMAP_HEIGHT];
			this.tree2Grid = new byte[this.TILEMAP_WIDTH, this.TILEMAP_HEIGHT];
			try
			{
				FileStream fileStream = new FileStream(Application.StartupPath + "\\assets\\" + fileName, FileMode.Open, FileAccess.Read);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				binaryReader.ReadInt32();
				int num = binaryReader.ReadInt32();
				byte[] array = new byte[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = binaryReader.ReadByte();
				}
				binaryReader.Close();
				fileStream.Close();
				byte[] array2 = RLECompress.DecodeData(array);
				int num2 = 0;
				for (int j = 0; j < this.TILEMAP_HEIGHT; j++)
				{
					for (int k = 0; k < this.TILEMAP_WIDTH; k++)
					{
						this.mapTileGrid[k, j] = (short)array2[num2++];
					}
				}
				for (int l = 0; l < this.TILEMAP_HEIGHT; l++)
				{
					for (int m = 0; m < this.TILEMAP_WIDTH; m++)
					{
						short ptr = this.mapTileGrid[m, l];
						ptr |= (short)(array2[num2++] << 8);
						this.mapTileGrid[m, l] = ptr;
					}
				}
				for (int n = 0; n < this.TILEMAP_HEIGHT; n++)
				{
					for (int num3 = 0; num3 < this.TILEMAP_WIDTH; num3++)
					{
						this.tree1Grid[num3, n] = array2[num2++];
					}
				}
				for (int num4 = 0; num4 < this.TILEMAP_HEIGHT; num4++)
				{
					for (int num5 = 0; num5 < this.TILEMAP_WIDTH; num5++)
					{
						this.tree2Grid[num5, num4] = array2[num2++];
					}
				}
				this.haveInitMapTiles = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060032E7 RID: 13031 RVA: 0x0029D868 File Offset: 0x0029BA68
		public void resetLeaderboards()
		{
			this.leaderboardSearchResults = new List<LeaderBoardSearchResults>();
			this.leaderboard_Main = new SparseArray();
			this.leaderboard_MainRank = new SparseArray();
			this.leaderboard_MainVillages = new SparseArray();
			this.leaderboard_Factions = new SparseArray();
			this.leaderboard_Houses = new SparseArray();
			this.leaderboard_ParishFlags = new SparseArray();
			this.leaderboard_Sub_Pillager = new SparseArray();
			this.leaderboard_Sub_Defender = new SparseArray();
			this.leaderboard_Sub_Ransack = new SparseArray();
			this.leaderboard_Sub_Wolfsbane = new SparseArray();
			this.leaderboard_Sub_Banditkiller = new SparseArray();
			this.leaderboard_Sub_AIKiller = new SparseArray();
			this.leaderboard_Sub_Trader = new SparseArray();
			this.leaderboard_Sub_Forager = new SparseArray();
			this.leaderboard_Sub_Stockpiler = new SparseArray();
			this.leaderboard_Sub_Farmer = new SparseArray();
			this.leaderboard_Sub_Brewer = new SparseArray();
			this.leaderboard_Sub_Weaponsmith = new SparseArray();
			this.leaderboard_Sub_banquetter = new SparseArray();
			this.leaderboard_Sub_Achiever = new SparseArray();
			this.leaderboard_Sub_Donater = new SparseArray();
			this.leaderboard_Sub_Capture = new SparseArray();
			this.leaderboard_Sub_Raze = new SparseArray();
			this.leaderboard_Sub_Glory = new SparseArray();
			this.leaderboard_Sub_KillStreak = new SparseArray();
			this.max_leaderboard_Main = -1;
			this.max_leaderboard_MainRank = -1;
			this.max_leaderboard_MainVillages = -1;
			this.max_leaderboard_Factions = -1;
			this.max_leaderboard_Houses = -1;
			this.max_leaderboard_ParishFlags = -1;
			this.max_leaderboard_Sub_Pillager = -1;
			this.max_leaderboard_Sub_Defender = -1;
			this.max_leaderboard_Sub_Ransack = -1;
			this.max_leaderboard_Sub_Wolfsbane = -1;
			this.max_leaderboard_Sub_Banditkiller = -1;
			this.max_leaderboard_Sub_AIKiller = -1;
			this.max_leaderboard_Sub_Trader = -1;
			this.max_leaderboard_Sub_Forager = -1;
			this.max_leaderboard_Sub_Stockpiler = -1;
			this.max_leaderboard_Sub_Farmer = -1;
			this.max_leaderboard_Sub_Brewer = -1;
			this.max_leaderboard_Sub_Weaponsmith = -1;
			this.max_leaderboard_Sub_banquetter = -1;
			this.max_leaderboard_Sub_Achiever = -1;
			this.max_leaderboard_Sub_Donater = -1;
			this.max_leaderboard_Sub_Capture = -1;
			this.max_leaderboard_Sub_Raze = -1;
			this.max_leaderboard_Sub_Glory = -1;
			this.max_leaderboard_Sub_KillStreak = -1;
			this.lastZeroDownload_leaderboard_Main = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_MainRank = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_MainVillages = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Factions = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Houses = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_ParishFlags = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Pillager = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Defender = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Ransack = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Wolfsbane = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Banditkiller = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_AIKiller = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Trader = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Forager = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Stockpiler = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Farmer = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Brewer = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Weaponsmith = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_banquetter = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Achiever = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Donater = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Capture = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Raze = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Glory = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_KillStreak = DateTime.MinValue;
			this.inDownloading = false;
		}

		// Token: 0x060032E8 RID: 13032 RVA: 0x00024A57 File Offset: 0x00022C57
		public void DownloadSectionOfLeaderboard(int mode, int position, int pageSize)
		{
			this.getLeaderboardEntry(mode, position, pageSize);
		}

		// Token: 0x060032E9 RID: 13033 RVA: 0x0029DB5C File Offset: 0x0029BD5C
		public LeaderBoardEntryData getLeaderboardEntry(int mode, int position, int pageSize)
		{
			DateTime minValue = DateTime.MinValue;
			int num = -1;
			SparseArray sparseArray = null;
			switch (mode)
			{
			case -6:
				sparseArray = this.leaderboard_MainVillages;
				num = this.max_leaderboard_MainVillages;
				minValue = this.lastZeroDownload_leaderboard_MainVillages;
				break;
			case -5:
				sparseArray = this.leaderboard_MainRank;
				num = this.max_leaderboard_MainRank;
				minValue = this.lastZeroDownload_leaderboard_MainRank;
				break;
			case -4:
				sparseArray = this.leaderboard_ParishFlags;
				num = this.max_leaderboard_ParishFlags;
				minValue = this.lastZeroDownload_leaderboard_ParishFlags;
				break;
			case -3:
				sparseArray = this.leaderboard_Houses;
				num = this.max_leaderboard_Houses;
				minValue = this.lastZeroDownload_leaderboard_Houses;
				break;
			case -2:
				sparseArray = this.leaderboard_Factions;
				num = this.max_leaderboard_Factions;
				minValue = this.lastZeroDownload_leaderboard_Factions;
				break;
			case -1:
				sparseArray = this.leaderboard_Main;
				num = this.max_leaderboard_Main;
				minValue = this.lastZeroDownload_leaderboard_Main;
				break;
			case 0:
				sparseArray = this.leaderboard_Sub_Pillager;
				num = this.max_leaderboard_Sub_Pillager;
				minValue = this.lastZeroDownload_leaderboard_Sub_Pillager;
				break;
			case 1:
				sparseArray = this.leaderboard_Sub_Defender;
				num = this.max_leaderboard_Sub_Defender;
				minValue = this.lastZeroDownload_leaderboard_Sub_Defender;
				break;
			case 2:
				sparseArray = this.leaderboard_Sub_Ransack;
				num = this.max_leaderboard_Sub_Ransack;
				minValue = this.lastZeroDownload_leaderboard_Sub_Ransack;
				break;
			case 3:
				sparseArray = this.leaderboard_Sub_Wolfsbane;
				num = this.max_leaderboard_Sub_Wolfsbane;
				minValue = this.lastZeroDownload_leaderboard_Sub_Wolfsbane;
				break;
			case 4:
				sparseArray = this.leaderboard_Sub_Banditkiller;
				num = this.max_leaderboard_Sub_Banditkiller;
				minValue = this.lastZeroDownload_leaderboard_Sub_Banditkiller;
				break;
			case 5:
				sparseArray = this.leaderboard_Sub_AIKiller;
				num = this.max_leaderboard_Sub_AIKiller;
				minValue = this.lastZeroDownload_leaderboard_Sub_AIKiller;
				break;
			case 6:
				sparseArray = this.leaderboard_Sub_Trader;
				num = this.max_leaderboard_Sub_Trader;
				minValue = this.lastZeroDownload_leaderboard_Sub_Trader;
				break;
			case 7:
				sparseArray = this.leaderboard_Sub_Forager;
				num = this.max_leaderboard_Sub_Forager;
				minValue = this.lastZeroDownload_leaderboard_Sub_Forager;
				break;
			case 8:
				sparseArray = this.leaderboard_Sub_Stockpiler;
				num = this.max_leaderboard_Sub_Stockpiler;
				minValue = this.lastZeroDownload_leaderboard_Sub_Stockpiler;
				break;
			case 9:
				sparseArray = this.leaderboard_Sub_Farmer;
				num = this.max_leaderboard_Sub_Farmer;
				minValue = this.lastZeroDownload_leaderboard_Sub_Farmer;
				break;
			case 10:
				sparseArray = this.leaderboard_Sub_Brewer;
				num = this.max_leaderboard_Sub_Brewer;
				minValue = this.lastZeroDownload_leaderboard_Sub_Brewer;
				break;
			case 11:
				sparseArray = this.leaderboard_Sub_Weaponsmith;
				num = this.max_leaderboard_Sub_Weaponsmith;
				minValue = this.lastZeroDownload_leaderboard_Sub_Weaponsmith;
				break;
			case 12:
				sparseArray = this.leaderboard_Sub_banquetter;
				num = this.max_leaderboard_Sub_banquetter;
				minValue = this.lastZeroDownload_leaderboard_Sub_banquetter;
				break;
			case 13:
				sparseArray = this.leaderboard_Sub_Achiever;
				num = this.max_leaderboard_Sub_Achiever;
				minValue = this.lastZeroDownload_leaderboard_Sub_Achiever;
				break;
			case 14:
				sparseArray = this.leaderboard_Sub_Donater;
				num = this.max_leaderboard_Sub_Donater;
				minValue = this.lastZeroDownload_leaderboard_Sub_Donater;
				break;
			case 15:
				sparseArray = this.leaderboard_Sub_Capture;
				num = this.max_leaderboard_Sub_Capture;
				minValue = this.lastZeroDownload_leaderboard_Sub_Capture;
				break;
			case 16:
				sparseArray = this.leaderboard_Sub_Raze;
				num = this.max_leaderboard_Sub_Raze;
				minValue = this.lastZeroDownload_leaderboard_Sub_Raze;
				break;
			case 17:
				sparseArray = this.leaderboard_Sub_Glory;
				num = this.max_leaderboard_Sub_Glory;
				minValue = this.lastZeroDownload_leaderboard_Sub_Glory;
				break;
			case 18:
				sparseArray = this.leaderboard_Sub_KillStreak;
				num = this.max_leaderboard_Sub_KillStreak;
				minValue = this.lastZeroDownload_leaderboard_Sub_KillStreak;
				break;
			}
			if (sparseArray == null)
			{
				return null;
			}
			if (num <= 0 && (DateTime.Now - minValue).TotalMinutes < 1.0)
			{
				return null;
			}
			if (sparseArray.Count == 0)
			{
				this.downloadLeaderboard(sparseArray, mode, -1, pageSize);
				return null;
			}
			if (position < 0)
			{
				return null;
			}
			if (sparseArray[position] != null)
			{
				return (LeaderBoardEntryData)sparseArray[position];
			}
			if (position <= num)
			{
				this.downloadLeaderboard(sparseArray, mode, position, pageSize);
				return null;
			}
			if (num >= 0)
			{
				if (WorldMap.dummyEntry == null)
				{
					WorldMap.dummyEntry = new LeaderBoardEntryData();
					WorldMap.dummyEntry.dummy = true;
				}
				return WorldMap.dummyEntry;
			}
			return null;
		}

		// Token: 0x060032EA RID: 13034 RVA: 0x0029DEF0 File Offset: 0x0029C0F0
		public void leaderboardLookHigher(int mode, int position, int pageSize)
		{
			SparseArray leaderboardArray = this.getLeaderboardArray(mode);
			int num = position;
			int maxValue = position;
			bool flag = false;
			for (int i = 1; i < 50 + pageSize; i++)
			{
				int num2 = position - i;
				if (num2 < 1)
				{
					num2 = 1;
				}
				if (leaderboardArray[num2] != null)
				{
					if (i >= pageSize + 5 && !flag)
					{
						return;
					}
				}
				else if (!flag)
				{
					maxValue = (num = num2);
					flag = true;
				}
				else
				{
					num = num2;
				}
			}
			if (num != position)
			{
				RemoteServices.Instance.LeaderBoard(mode, num, maxValue, this.leaderboardLastUpdateTime);
			}
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x0029DF68 File Offset: 0x0029C168
		public void leaderboardLookLower(int mode, int position, int pageSize)
		{
			position += pageSize;
			SparseArray leaderboardArray = this.getLeaderboardArray(mode);
			int maxLeaderboardEntries = this.getMaxLeaderboardEntries(mode);
			int num = position;
			int maxValue = position;
			bool flag = false;
			for (int i = 1; i < 50 + pageSize; i++)
			{
				int num2 = position + i;
				if (num2 >= maxLeaderboardEntries)
				{
					num2 = maxLeaderboardEntries;
				}
				if (leaderboardArray[num2] != null)
				{
					if (i >= pageSize + 5 && !flag)
					{
						return;
					}
				}
				else if (!flag)
				{
					maxValue = (num = num2);
					flag = true;
				}
				else
				{
					maxValue = num2;
				}
			}
			if (num != position)
			{
				RemoteServices.Instance.LeaderBoard(mode, num, maxValue, this.leaderboardLastUpdateTime);
			}
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x00024A63 File Offset: 0x00022C63
		public DateTime getLastLeaderboardUpdate()
		{
			return this.leaderboardLastUpdateTime;
		}

		// Token: 0x060032ED RID: 13037 RVA: 0x00024A6B File Offset: 0x00022C6B
		public bool downloadingLeaderboard()
		{
			return this.inDownloading || this.inLeaderboardSearch;
		}

		// Token: 0x060032EE RID: 13038 RVA: 0x0029DFF0 File Offset: 0x0029C1F0
		public void downloadLeaderboard(SparseArray currentArray, int mode, int position, int pageSize)
		{
			if (this.inDownloading)
			{
				return;
			}
			this.inDownloading = true;
			RemoteServices.Instance.set_LeaderBoard_UserCallBack(new RemoteServices.LeaderBoard_UserCallBack(this.LeaderboardCallback));
			if (position < 0)
			{
				RemoteServices.Instance.LeaderBoard(mode, -1, -1, this.leaderboardLastUpdateTime);
				return;
			}
			int minValue = position;
			int maxValue = position;
			bool flag = false;
			bool flag2 = false;
			for (int i = 1; i < 50 + pageSize; i++)
			{
				int num = position - i;
				if (num < 1)
				{
					num = 1;
				}
				int num2 = position + i;
				if (!flag)
				{
					if (currentArray[num] != null)
					{
						flag = true;
					}
					else
					{
						minValue = num;
					}
				}
				if (!flag2)
				{
					if (currentArray[num2] != null)
					{
						if (i > pageSize + 1)
						{
							flag = true;
						}
					}
					else
					{
						maxValue = num2;
					}
				}
			}
			RemoteServices.Instance.LeaderBoard(mode, minValue, maxValue, this.leaderboardLastUpdateTime);
		}

		// Token: 0x060032EF RID: 13039 RVA: 0x0029E0B0 File Offset: 0x0029C2B0
		public void LeaderboardCallback(LeaderBoard_ReturnType returnData)
		{
			this.inDownloading = false;
			if (!returnData.Success)
			{
				return;
			}
			if (returnData.lastUpdate != this.leaderboardLastUpdateTime)
			{
				if (this.leaderboardLastUpdateTime != DateTime.MinValue)
				{
					this.resetLeaderboards();
				}
				this.leaderboardLastUpdateTime = returnData.lastUpdate;
			}
			if (returnData.ownStandings != null)
			{
				this.importStandings(returnData.ownStandings);
			}
			int maxValue = returnData.maxValue;
			SparseArray currentArray = null;
			switch (returnData.leaderboardType)
			{
			case -6:
				currentArray = this.leaderboard_MainVillages;
				this.max_leaderboard_MainVillages = maxValue;
				break;
			case -5:
				currentArray = this.leaderboard_MainRank;
				this.max_leaderboard_MainRank = maxValue;
				break;
			case -4:
				currentArray = this.leaderboard_ParishFlags;
				this.max_leaderboard_ParishFlags = maxValue;
				break;
			case -3:
				currentArray = this.leaderboard_Houses;
				this.max_leaderboard_Houses = maxValue;
				break;
			case -2:
				currentArray = this.leaderboard_Factions;
				this.max_leaderboard_Factions = maxValue;
				break;
			case -1:
				currentArray = this.leaderboard_Main;
				this.max_leaderboard_Main = maxValue;
				break;
			case 0:
				currentArray = this.leaderboard_Sub_Pillager;
				this.max_leaderboard_Sub_Pillager = maxValue;
				break;
			case 1:
				currentArray = this.leaderboard_Sub_Defender;
				this.max_leaderboard_Sub_Defender = maxValue;
				break;
			case 2:
				currentArray = this.leaderboard_Sub_Ransack;
				this.max_leaderboard_Sub_Ransack = maxValue;
				break;
			case 3:
				currentArray = this.leaderboard_Sub_Wolfsbane;
				this.max_leaderboard_Sub_Wolfsbane = maxValue;
				break;
			case 4:
				currentArray = this.leaderboard_Sub_Banditkiller;
				this.max_leaderboard_Sub_Banditkiller = maxValue;
				break;
			case 5:
				currentArray = this.leaderboard_Sub_AIKiller;
				this.max_leaderboard_Sub_AIKiller = maxValue;
				break;
			case 6:
				currentArray = this.leaderboard_Sub_Trader;
				this.max_leaderboard_Sub_Trader = maxValue;
				break;
			case 7:
				currentArray = this.leaderboard_Sub_Forager;
				this.max_leaderboard_Sub_Forager = maxValue;
				break;
			case 8:
				currentArray = this.leaderboard_Sub_Stockpiler;
				this.max_leaderboard_Sub_Stockpiler = maxValue;
				break;
			case 9:
				currentArray = this.leaderboard_Sub_Farmer;
				this.max_leaderboard_Sub_Farmer = maxValue;
				break;
			case 10:
				currentArray = this.leaderboard_Sub_Brewer;
				this.max_leaderboard_Sub_Brewer = maxValue;
				break;
			case 11:
				currentArray = this.leaderboard_Sub_Weaponsmith;
				this.max_leaderboard_Sub_Weaponsmith = maxValue;
				break;
			case 12:
				currentArray = this.leaderboard_Sub_banquetter;
				this.max_leaderboard_Sub_banquetter = maxValue;
				break;
			case 13:
				currentArray = this.leaderboard_Sub_Achiever;
				this.max_leaderboard_Sub_Achiever = maxValue;
				break;
			case 14:
				currentArray = this.leaderboard_Sub_Donater;
				this.max_leaderboard_Sub_Donater = maxValue;
				break;
			case 15:
				currentArray = this.leaderboard_Sub_Capture;
				this.max_leaderboard_Sub_Capture = maxValue;
				break;
			case 16:
				currentArray = this.leaderboard_Sub_Raze;
				this.max_leaderboard_Sub_Raze = maxValue;
				break;
			case 17:
				currentArray = this.leaderboard_Sub_Glory;
				this.max_leaderboard_Sub_Glory = maxValue;
				break;
			case 18:
				currentArray = this.leaderboard_Sub_KillStreak;
				this.max_leaderboard_Sub_KillStreak = maxValue;
				break;
			}
			this.importLeaderboardData(currentArray, returnData.leaderboardType, returnData.mainLeaderboard, returnData.subLeaderboard, returnData.parishLeaderboard, returnData.houseLeaderboard, returnData.factionLeaderboard);
		}

		// Token: 0x060032F0 RID: 13040 RVA: 0x0029E384 File Offset: 0x0029C584
		public bool isLeaderboardCategoryPopulated(int mode)
		{
			SparseArray sparseArray = null;
			switch (mode)
			{
			case -6:
				sparseArray = this.leaderboard_MainVillages;
				break;
			case -5:
				sparseArray = this.leaderboard_MainRank;
				break;
			case -4:
				sparseArray = this.leaderboard_ParishFlags;
				break;
			case -3:
				sparseArray = this.leaderboard_Houses;
				break;
			case -2:
				sparseArray = this.leaderboard_Factions;
				break;
			case -1:
				sparseArray = this.leaderboard_Main;
				break;
			case 0:
				sparseArray = this.leaderboard_Sub_Pillager;
				break;
			case 1:
				sparseArray = this.leaderboard_Sub_Defender;
				break;
			case 2:
				sparseArray = this.leaderboard_Sub_Ransack;
				break;
			case 3:
				sparseArray = this.leaderboard_Sub_Wolfsbane;
				break;
			case 4:
				sparseArray = this.leaderboard_Sub_Banditkiller;
				break;
			case 5:
				sparseArray = this.leaderboard_Sub_AIKiller;
				break;
			case 6:
				sparseArray = this.leaderboard_Sub_Trader;
				break;
			case 7:
				sparseArray = this.leaderboard_Sub_Forager;
				break;
			case 8:
				sparseArray = this.leaderboard_Sub_Stockpiler;
				break;
			case 9:
				sparseArray = this.leaderboard_Sub_Farmer;
				break;
			case 10:
				sparseArray = this.leaderboard_Sub_Brewer;
				break;
			case 11:
				sparseArray = this.leaderboard_Sub_Weaponsmith;
				break;
			case 12:
				sparseArray = this.leaderboard_Sub_banquetter;
				break;
			case 13:
				sparseArray = this.leaderboard_Sub_Achiever;
				break;
			case 14:
				sparseArray = this.leaderboard_Sub_Donater;
				break;
			case 15:
				sparseArray = this.leaderboard_Sub_Capture;
				break;
			case 16:
				sparseArray = this.leaderboard_Sub_Raze;
				break;
			case 17:
				sparseArray = this.leaderboard_Sub_Glory;
				break;
			case 18:
				sparseArray = this.leaderboard_Sub_KillStreak;
				break;
			}
			return sparseArray != null && sparseArray.Count > 0;
		}

		// Token: 0x060032F1 RID: 13041 RVA: 0x0029E514 File Offset: 0x0029C714
		public int findSelfInLeaderboard(int mode)
		{
			int num = RemoteServices.Instance.UserID;
			SparseArray sparseArray = null;
			switch (mode)
			{
			case -6:
				sparseArray = this.leaderboard_MainVillages;
				break;
			case -5:
				sparseArray = this.leaderboard_MainRank;
				break;
			case -4:
			{
				sparseArray = this.leaderboard_ParishFlags;
				num = 1;
				int selectedMenuVillage = InterfaceMgr.Instance.getSelectedMenuVillage();
				if (this.isCapital(selectedMenuVillage))
				{
					if (this.isRegionCapital(selectedMenuVillage))
					{
						num = this.getParishFromVillageID(selectedMenuVillage);
						break;
					}
					List<int> userVillageIDList = this.getUserVillageIDList();
					if (userVillageIDList.Count <= 0)
					{
						break;
					}
					using (List<int>.Enumerator enumerator = userVillageIDList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							int villageID = enumerator.Current;
							if (!this.isCapital(villageID))
							{
								num = this.getParishFromVillageID(selectedMenuVillage);
								break;
							}
						}
						break;
					}
				}
				num = this.getParishFromVillageID(selectedMenuVillage);
				break;
			}
			case -3:
				sparseArray = this.leaderboard_Houses;
				num = GameEngine.Instance.World.getHouse(RemoteServices.Instance.UserFactionID);
				break;
			case -2:
				sparseArray = this.leaderboard_Factions;
				num = RemoteServices.Instance.UserFactionID;
				break;
			case -1:
				sparseArray = this.leaderboard_Main;
				break;
			case 0:
				sparseArray = this.leaderboard_Sub_Pillager;
				break;
			case 1:
				sparseArray = this.leaderboard_Sub_Defender;
				break;
			case 2:
				sparseArray = this.leaderboard_Sub_Ransack;
				break;
			case 3:
				sparseArray = this.leaderboard_Sub_Wolfsbane;
				break;
			case 4:
				sparseArray = this.leaderboard_Sub_Banditkiller;
				break;
			case 5:
				sparseArray = this.leaderboard_Sub_AIKiller;
				break;
			case 6:
				sparseArray = this.leaderboard_Sub_Trader;
				break;
			case 7:
				sparseArray = this.leaderboard_Sub_Forager;
				break;
			case 8:
				sparseArray = this.leaderboard_Sub_Stockpiler;
				break;
			case 9:
				sparseArray = this.leaderboard_Sub_Farmer;
				break;
			case 10:
				sparseArray = this.leaderboard_Sub_Brewer;
				break;
			case 11:
				sparseArray = this.leaderboard_Sub_Weaponsmith;
				break;
			case 12:
				sparseArray = this.leaderboard_Sub_banquetter;
				break;
			case 13:
				sparseArray = this.leaderboard_Sub_Achiever;
				break;
			case 14:
				sparseArray = this.leaderboard_Sub_Donater;
				break;
			case 15:
				sparseArray = this.leaderboard_Sub_Capture;
				break;
			case 16:
				sparseArray = this.leaderboard_Sub_Raze;
				break;
			case 17:
				sparseArray = this.leaderboard_Sub_Glory;
				break;
			case 18:
				sparseArray = this.leaderboard_Sub_KillStreak;
				break;
			}
			foreach (object obj in sparseArray)
			{
				LeaderBoardEntryData leaderBoardEntryData = (LeaderBoardEntryData)obj;
				if (leaderBoardEntryData.entryID == num)
				{
					return leaderBoardEntryData.standing;
				}
			}
			return 1;
		}

		// Token: 0x060032F2 RID: 13042 RVA: 0x0029E7BC File Offset: 0x0029C9BC
		public int getMaxLeaderboardEntries(int mode)
		{
			int result = -1;
			switch (mode)
			{
			case -6:
				result = this.max_leaderboard_MainVillages;
				break;
			case -5:
				result = this.max_leaderboard_MainRank;
				break;
			case -4:
				result = this.max_leaderboard_ParishFlags;
				break;
			case -3:
				result = this.max_leaderboard_Houses;
				break;
			case -2:
				result = this.max_leaderboard_Factions;
				break;
			case -1:
				result = this.max_leaderboard_Main;
				break;
			case 0:
				result = this.max_leaderboard_Sub_Pillager;
				break;
			case 1:
				result = this.max_leaderboard_Sub_Defender;
				break;
			case 2:
				result = this.max_leaderboard_Sub_Ransack;
				break;
			case 3:
				result = this.max_leaderboard_Sub_Wolfsbane;
				break;
			case 4:
				result = this.max_leaderboard_Sub_Banditkiller;
				break;
			case 5:
				result = this.max_leaderboard_Sub_AIKiller;
				break;
			case 6:
				result = this.max_leaderboard_Sub_Trader;
				break;
			case 7:
				result = this.max_leaderboard_Sub_Forager;
				break;
			case 8:
				result = this.max_leaderboard_Sub_Stockpiler;
				break;
			case 9:
				result = this.max_leaderboard_Sub_Farmer;
				break;
			case 10:
				result = this.max_leaderboard_Sub_Brewer;
				break;
			case 11:
				result = this.max_leaderboard_Sub_Weaponsmith;
				break;
			case 12:
				result = this.max_leaderboard_Sub_banquetter;
				break;
			case 13:
				result = this.max_leaderboard_Sub_Achiever;
				break;
			case 14:
				result = this.max_leaderboard_Sub_Donater;
				break;
			case 15:
				result = this.max_leaderboard_Sub_Capture;
				break;
			case 16:
				result = this.max_leaderboard_Sub_Raze;
				break;
			case 17:
				result = this.max_leaderboard_Sub_Glory;
				break;
			case 18:
				result = this.max_leaderboard_Sub_KillStreak;
				break;
			}
			return result;
		}

		// Token: 0x060032F3 RID: 13043 RVA: 0x0029E93C File Offset: 0x0029CB3C
		public SparseArray getLeaderboardArray(int mode)
		{
			SparseArray result = null;
			switch (mode)
			{
			case -6:
				result = this.leaderboard_MainVillages;
				break;
			case -5:
				result = this.leaderboard_MainRank;
				break;
			case -4:
				result = this.leaderboard_ParishFlags;
				break;
			case -3:
				result = this.leaderboard_Houses;
				break;
			case -2:
				result = this.leaderboard_Factions;
				break;
			case -1:
				result = this.leaderboard_Main;
				break;
			case 0:
				result = this.leaderboard_Sub_Pillager;
				break;
			case 1:
				result = this.leaderboard_Sub_Defender;
				break;
			case 2:
				result = this.leaderboard_Sub_Ransack;
				break;
			case 3:
				result = this.leaderboard_Sub_Wolfsbane;
				break;
			case 4:
				result = this.leaderboard_Sub_Banditkiller;
				break;
			case 5:
				result = this.leaderboard_Sub_AIKiller;
				break;
			case 6:
				result = this.leaderboard_Sub_Trader;
				break;
			case 7:
				result = this.leaderboard_Sub_Forager;
				break;
			case 8:
				result = this.leaderboard_Sub_Stockpiler;
				break;
			case 9:
				result = this.leaderboard_Sub_Farmer;
				break;
			case 10:
				result = this.leaderboard_Sub_Brewer;
				break;
			case 11:
				result = this.leaderboard_Sub_Weaponsmith;
				break;
			case 12:
				result = this.leaderboard_Sub_banquetter;
				break;
			case 13:
				result = this.leaderboard_Sub_Achiever;
				break;
			case 14:
				result = this.leaderboard_Sub_Donater;
				break;
			case 15:
				result = this.leaderboard_Sub_Capture;
				break;
			case 16:
				result = this.leaderboard_Sub_Raze;
				break;
			case 17:
				result = this.leaderboard_Sub_Glory;
				break;
			case 18:
				result = this.leaderboard_Sub_KillStreak;
				break;
			}
			return result;
		}

		// Token: 0x060032F4 RID: 13044 RVA: 0x0029EABC File Offset: 0x0029CCBC
		public void leaderboardSearch(int category, string searchString)
		{
			searchString = searchString.ToLowerInvariant();
			foreach (LeaderBoardSearchResults leaderBoardSearchResults in this.leaderboardSearchResults)
			{
				if (leaderBoardSearchResults.category == category)
				{
					if (searchString == leaderBoardSearchResults.searchString)
					{
						InterfaceMgr.Instance.leaderboardSearchComplete(leaderBoardSearchResults);
						return;
					}
					if (searchString.Contains(leaderBoardSearchResults.searchString))
					{
						LeaderBoardSearchResults leaderBoardSearchResults2 = new LeaderBoardSearchResults();
						leaderBoardSearchResults2.category = category;
						leaderBoardSearchResults2.searchString = searchString;
						if (category - -4 > 1)
						{
							SparseArray leaderboardArray = this.getLeaderboardArray(category);
							foreach (int num in leaderBoardSearchResults.entries)
							{
								LeaderBoardEntryData leaderBoardEntryData = (LeaderBoardEntryData)leaderboardArray[num];
								if (leaderBoardEntryData != null && leaderBoardEntryData.name.ToLower().Contains(searchString))
								{
									leaderBoardSearchResults2.entries.Add(num);
								}
							}
						}
						leaderBoardSearchResults2.entries.Sort();
						this.leaderboardSearchResults.Add(leaderBoardSearchResults2);
						InterfaceMgr.Instance.leaderboardSearchComplete(leaderBoardSearchResults2);
						return;
					}
				}
			}
			this.inLeaderboardSearch = true;
			RemoteServices.Instance.set_LeaderBoardSearch_UserCallBack(new RemoteServices.LeaderBoardSearch_UserCallBack(this.leaderboardSearchCallback));
			RemoteServices.Instance.LeaderBoardSearch(category, searchString, this.leaderboardLastUpdateTime);
		}

		// Token: 0x060032F5 RID: 13045 RVA: 0x0029EC50 File Offset: 0x0029CE50
		private void leaderboardSearchCallback(LeaderBoardSearch_ReturnType returnData)
		{
			if (returnData.Success)
			{
				if (returnData.lastUpdate != this.leaderboardLastUpdateTime)
				{
					if (this.leaderboardLastUpdateTime != DateTime.MinValue)
					{
						this.resetLeaderboards();
					}
					this.leaderboardLastUpdateTime = returnData.lastUpdate;
				}
				if (returnData.ownStandings != null)
				{
					this.importStandings(returnData.ownStandings);
				}
				int maxValue = returnData.maxValue;
				SparseArray currentArray = null;
				switch (returnData.leaderboardType)
				{
				case -6:
					currentArray = this.leaderboard_MainVillages;
					this.max_leaderboard_MainVillages = maxValue;
					break;
				case -5:
					currentArray = this.leaderboard_MainRank;
					this.max_leaderboard_MainRank = maxValue;
					break;
				case -4:
					currentArray = this.leaderboard_ParishFlags;
					this.max_leaderboard_ParishFlags = maxValue;
					break;
				case -3:
					currentArray = this.leaderboard_Houses;
					this.max_leaderboard_Houses = maxValue;
					break;
				case -2:
					currentArray = this.leaderboard_Factions;
					this.max_leaderboard_Factions = maxValue;
					break;
				case -1:
					currentArray = this.leaderboard_Main;
					this.max_leaderboard_Main = maxValue;
					break;
				case 0:
					currentArray = this.leaderboard_Sub_Pillager;
					this.max_leaderboard_Sub_Pillager = maxValue;
					break;
				case 1:
					currentArray = this.leaderboard_Sub_Defender;
					this.max_leaderboard_Sub_Defender = maxValue;
					break;
				case 2:
					currentArray = this.leaderboard_Sub_Ransack;
					this.max_leaderboard_Sub_Ransack = maxValue;
					break;
				case 3:
					currentArray = this.leaderboard_Sub_Wolfsbane;
					this.max_leaderboard_Sub_Wolfsbane = maxValue;
					break;
				case 4:
					currentArray = this.leaderboard_Sub_Banditkiller;
					this.max_leaderboard_Sub_Banditkiller = maxValue;
					break;
				case 5:
					currentArray = this.leaderboard_Sub_AIKiller;
					this.max_leaderboard_Sub_AIKiller = maxValue;
					break;
				case 6:
					currentArray = this.leaderboard_Sub_Trader;
					this.max_leaderboard_Sub_Trader = maxValue;
					break;
				case 7:
					currentArray = this.leaderboard_Sub_Forager;
					this.max_leaderboard_Sub_Forager = maxValue;
					break;
				case 8:
					currentArray = this.leaderboard_Sub_Stockpiler;
					this.max_leaderboard_Sub_Stockpiler = maxValue;
					break;
				case 9:
					currentArray = this.leaderboard_Sub_Farmer;
					this.max_leaderboard_Sub_Farmer = maxValue;
					break;
				case 10:
					currentArray = this.leaderboard_Sub_Brewer;
					this.max_leaderboard_Sub_Brewer = maxValue;
					break;
				case 11:
					currentArray = this.leaderboard_Sub_Weaponsmith;
					this.max_leaderboard_Sub_Weaponsmith = maxValue;
					break;
				case 12:
					currentArray = this.leaderboard_Sub_banquetter;
					this.max_leaderboard_Sub_banquetter = maxValue;
					break;
				case 13:
					currentArray = this.leaderboard_Sub_Achiever;
					this.max_leaderboard_Sub_Achiever = maxValue;
					break;
				case 14:
					currentArray = this.leaderboard_Sub_Donater;
					this.max_leaderboard_Sub_Donater = maxValue;
					break;
				case 15:
					currentArray = this.leaderboard_Sub_Capture;
					this.max_leaderboard_Sub_Capture = maxValue;
					break;
				case 16:
					currentArray = this.leaderboard_Sub_Raze;
					this.max_leaderboard_Sub_Raze = maxValue;
					break;
				case 17:
					currentArray = this.leaderboard_Sub_Glory;
					this.max_leaderboard_Sub_Glory = maxValue;
					break;
				case 18:
					currentArray = this.leaderboard_Sub_KillStreak;
					this.max_leaderboard_Sub_KillStreak = maxValue;
					break;
				}
				this.importLeaderboardData(currentArray, returnData.leaderboardType, returnData.mainLeaderboard, returnData.subLeaderboard, returnData.parishLeaderboard, returnData.houseLeaderboard, returnData.factionLeaderboard);
				LeaderBoardSearchResults leaderBoardSearchResults = new LeaderBoardSearchResults();
				switch (returnData.leaderboardType)
				{
				case -6:
				case -5:
				case -1:
					using (List<LeaderboardDataMainClass>.Enumerator enumerator = returnData.mainLeaderboard.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							LeaderboardDataMainClass leaderboardDataMainClass = enumerator.Current;
							leaderBoardSearchResults.entries.Add(leaderboardDataMainClass.standing);
						}
						goto IL_408;
					}
					break;
				case -4:
					goto IL_382;
				case -3:
					goto IL_3C5;
				case -2:
					break;
				default:
					goto IL_3C5;
				}
				using (List<FactionLeaderboardInfo>.Enumerator enumerator2 = returnData.factionLeaderboard.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						FactionLeaderboardInfo factionLeaderboardInfo = enumerator2.Current;
						leaderBoardSearchResults.entries.Add(factionLeaderboardInfo.standing);
					}
					goto IL_408;
				}
				IL_382:
				using (List<ParishFlagLeaderboardInfo>.Enumerator enumerator3 = returnData.parishLeaderboard.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						ParishFlagLeaderboardInfo parishFlagLeaderboardInfo = enumerator3.Current;
						leaderBoardSearchResults.entries.Add(parishFlagLeaderboardInfo.standing);
					}
					goto IL_408;
				}
				IL_3C5:
				foreach (LeaderboardSubDataClass leaderboardSubDataClass in returnData.subLeaderboard)
				{
					leaderBoardSearchResults.entries.Add(leaderboardSubDataClass.standing);
				}
				IL_408:
				leaderBoardSearchResults.entries.Sort();
				leaderBoardSearchResults.searchString = returnData.searchString;
				leaderBoardSearchResults.category = returnData.leaderboardType;
				this.leaderboardSearchResults.Add(leaderBoardSearchResults);
				InterfaceMgr.Instance.leaderboardSearchComplete(leaderBoardSearchResults);
			}
			this.inLeaderboardSearch = false;
		}

		// Token: 0x060032F6 RID: 13046 RVA: 0x0029F0DC File Offset: 0x0029D2DC
		private void importLeaderboardData(SparseArray currentArray, int leaderboardType, List<LeaderboardDataMainClass> mainLeaderboard, List<LeaderboardSubDataClass> subLeaderboard, List<ParishFlagLeaderboardInfo> parishLeaderboard, List<HouseLeaderboardInfo> houseLeaderboard, List<FactionLeaderboardInfo> factionLeaderboard)
		{
			switch (leaderboardType)
			{
			case -6:
				foreach (LeaderboardDataMainClass leaderboardDataMainClass in mainLeaderboard)
				{
					int standing = leaderboardDataMainClass.standing;
					currentArray[standing] = new LeaderBoardEntryData
					{
						standing = standing,
						name = leaderboardDataMainClass.userName,
						house = leaderboardDataMainClass.house,
						value = leaderboardDataMainClass.numVillages,
						entryID = leaderboardDataMainClass.userID
					};
				}
				if (mainLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_MainVillages = DateTime.Now;
				}
				return;
			case -5:
				foreach (LeaderboardDataMainClass leaderboardDataMainClass2 in mainLeaderboard)
				{
					DX.ImportLeaderBoardInfo(leaderboardDataMainClass2);
					int standing2 = leaderboardDataMainClass2.standing;
					LeaderBoardEntryData leaderBoardEntryData = new LeaderBoardEntryData();
					leaderBoardEntryData.standing = standing2;
					leaderBoardEntryData.name = leaderboardDataMainClass2.userName;
					leaderBoardEntryData.house = leaderboardDataMainClass2.house;
					if (leaderboardDataMainClass2.rank >= 0)
					{
						leaderBoardEntryData.value = leaderboardDataMainClass2.rank;
						leaderBoardEntryData.male = true;
					}
					else
					{
						leaderBoardEntryData.value = -1 - leaderboardDataMainClass2.rank;
						leaderBoardEntryData.male = false;
					}
					leaderBoardEntryData.entryID = leaderboardDataMainClass2.userID;
					currentArray[standing2] = leaderBoardEntryData;
				}
				if (mainLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_MainRank = DateTime.Now;
				}
				return;
			case -4:
				foreach (ParishFlagLeaderboardInfo parishFlagLeaderboardInfo in parishLeaderboard)
				{
					int standing3 = parishFlagLeaderboardInfo.standing;
					currentArray[standing3] = new LeaderBoardEntryData
					{
						standing = standing3,
						name = this.getParishName(parishFlagLeaderboardInfo.regionID),
						house = 0,
						value = parishFlagLeaderboardInfo.points,
						entryID = parishFlagLeaderboardInfo.regionID
					};
				}
				if (parishLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_ParishFlags = DateTime.Now;
				}
				return;
			case -3:
			{
				int num = 1;
				foreach (HouseLeaderboardInfo houseLeaderboardInfo in houseLeaderboard)
				{
					int num2 = num++;
					currentArray[num2] = new LeaderBoardEntryData
					{
						standing = num2,
						name = SK.Text("STATS_CATEGORY_TITLE_HOUSE", "House") + " " + houseLeaderboardInfo.houseID.ToString(),
						house = houseLeaderboardInfo.houseID,
						value = houseLeaderboardInfo.housePoints,
						entryID = houseLeaderboardInfo.houseID
					};
				}
				if (houseLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_Houses = DateTime.Now;
				}
				return;
			}
			case -2:
				foreach (FactionLeaderboardInfo factionLeaderboardInfo in factionLeaderboard)
				{
					int standing4 = factionLeaderboardInfo.standing;
					currentArray[standing4] = new LeaderBoardEntryData
					{
						standing = standing4,
						name = factionLeaderboardInfo.factionname,
						house = factionLeaderboardInfo.house,
						value = factionLeaderboardInfo.factionPoints,
						entryID = factionLeaderboardInfo.factionID
					};
				}
				if (factionLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_Factions = DateTime.Now;
				}
				return;
			case -1:
				foreach (LeaderboardDataMainClass leaderboardDataMainClass3 in mainLeaderboard)
				{
					int standing5 = leaderboardDataMainClass3.standing;
					currentArray[standing5] = new LeaderBoardEntryData
					{
						standing = standing5,
						name = leaderboardDataMainClass3.userName,
						house = leaderboardDataMainClass3.house,
						value = leaderboardDataMainClass3.numPoints,
						entryID = leaderboardDataMainClass3.userID
					};
				}
				if (mainLeaderboard.Count == 0)
				{
					this.lastZeroDownload_leaderboard_Main = DateTime.Now;
				}
				return;
			default:
				foreach (LeaderboardSubDataClass leaderboardSubDataClass in subLeaderboard)
				{
					int standing6 = leaderboardSubDataClass.standing;
					currentArray[standing6] = new LeaderBoardEntryData
					{
						standing = standing6,
						name = leaderboardSubDataClass.userName,
						house = leaderboardSubDataClass.house,
						value = leaderboardSubDataClass.data,
						entryID = leaderboardSubDataClass.userID
					};
				}
				if (subLeaderboard.Count == 0)
				{
					switch (leaderboardType)
					{
					case 0:
						this.lastZeroDownload_leaderboard_Sub_Pillager = DateTime.Now;
						return;
					case 1:
						this.lastZeroDownload_leaderboard_Sub_Defender = DateTime.Now;
						return;
					case 2:
						this.lastZeroDownload_leaderboard_Sub_Ransack = DateTime.Now;
						return;
					case 3:
						this.lastZeroDownload_leaderboard_Sub_Wolfsbane = DateTime.Now;
						return;
					case 4:
						this.lastZeroDownload_leaderboard_Sub_Banditkiller = DateTime.Now;
						return;
					case 5:
						this.lastZeroDownload_leaderboard_Sub_AIKiller = DateTime.Now;
						return;
					case 6:
						this.lastZeroDownload_leaderboard_Sub_Trader = DateTime.Now;
						return;
					case 7:
						this.lastZeroDownload_leaderboard_Sub_Forager = DateTime.Now;
						return;
					case 8:
						this.lastZeroDownload_leaderboard_Sub_Stockpiler = DateTime.Now;
						return;
					case 9:
						this.lastZeroDownload_leaderboard_Sub_Farmer = DateTime.Now;
						return;
					case 10:
						this.lastZeroDownload_leaderboard_Sub_Brewer = DateTime.Now;
						return;
					case 11:
						this.lastZeroDownload_leaderboard_Sub_Weaponsmith = DateTime.Now;
						return;
					case 12:
						this.lastZeroDownload_leaderboard_Sub_banquetter = DateTime.Now;
						return;
					case 13:
						this.lastZeroDownload_leaderboard_Sub_Achiever = DateTime.Now;
						return;
					case 14:
						this.lastZeroDownload_leaderboard_Sub_Donater = DateTime.Now;
						return;
					case 15:
						this.lastZeroDownload_leaderboard_Sub_Capture = DateTime.Now;
						return;
					case 16:
						this.lastZeroDownload_leaderboard_Sub_Raze = DateTime.Now;
						return;
					case 17:
						this.lastZeroDownload_leaderboard_Sub_Glory = DateTime.Now;
						return;
					case 18:
						this.lastZeroDownload_leaderboard_Sub_KillStreak = DateTime.Now;
						break;
					default:
						return;
					}
				}
				return;
			}
		}

		// Token: 0x060032F7 RID: 13047 RVA: 0x0029F728 File Offset: 0x0029D928
		private void importStandings(int[,] standings)
		{
			this.dirtyStanding = true;
			this.leaderboardSelfRankings.Clear();
			int numberOfLeaderboardCategories = GameEngine.Instance.LocalWorldData.getNumberOfLeaderboardCategories();
			for (int i = 0; i < numberOfLeaderboardCategories; i++)
			{
				if (standings[i, 0] > 0)
				{
					LeaderBoardSelfRankings leaderBoardSelfRankings = new LeaderBoardSelfRankings();
					leaderBoardSelfRankings.place = standings[i, 0];
					leaderBoardSelfRankings.value = standings[i, 1];
					leaderBoardSelfRankings.oldPlace = standings[i, 2];
					if (i < 15)
					{
						leaderBoardSelfRankings.category = i;
					}
					else
					{
						switch (i)
						{
						case 15:
							leaderBoardSelfRankings.category = -1;
							break;
						case 16:
							leaderBoardSelfRankings.category = -5;
							break;
						case 17:
							leaderBoardSelfRankings.category = -6;
							break;
						case 18:
							leaderBoardSelfRankings.category = 15;
							break;
						case 19:
							leaderBoardSelfRankings.category = 16;
							break;
						case 20:
							leaderBoardSelfRankings.category = 17;
							break;
						case 21:
							leaderBoardSelfRankings.category = 18;
							break;
						}
					}
					this.leaderboardSelfRankings.Add(leaderBoardSelfRankings);
				}
			}
			this.leaderboardSelfRankings.Sort(this.leaderboardSelfRankingsComparer);
			if (this.getGameDay() < 30)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (LeaderBoardSelfRankings leaderBoardSelfRankings2 in this.leaderboardSelfRankings)
			{
				if (leaderBoardSelfRankings2.place <= 1)
				{
					flag = true;
				}
				if (leaderBoardSelfRankings2.place <= 5)
				{
					flag2 = true;
				}
				if (leaderBoardSelfRankings2.place <= 20)
				{
					flag3 = true;
				}
				if (leaderBoardSelfRankings2.place <= 100)
				{
					flag4 = true;
				}
			}
			List<int> userAchievements = RemoteServices.Instance.UserAchievements;
			if (userAchievements == null)
			{
				return;
			}
			List<int> list = new List<int>();
			if (flag4)
			{
				if (!userAchievements.Contains(321))
				{
					list.Add(321);
				}
				if (flag3)
				{
					if (!userAchievements.Contains(268435777))
					{
						list.Add(268435777);
					}
					if (flag2)
					{
						if (!userAchievements.Contains(536871233))
						{
							list.Add(536871233);
						}
						if (flag && !userAchievements.Contains(1073742145))
						{
							list.Add(1073742145);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				GameEngine.Instance.World.testAchievements(list, new List<AchievementData>(), false);
			}
		}

		// Token: 0x060032F8 RID: 13048 RVA: 0x0029F98C File Offset: 0x0029DB8C
		public bool areSelfStandingsDirty()
		{
			bool result = this.dirtyStanding;
			this.dirtyStanding = false;
			return result;
		}

		// Token: 0x060032F9 RID: 13049 RVA: 0x00024A7D File Offset: 0x00022C7D
		public LeaderBoardSelfRankings getLeaderboardBestRanking(int row)
		{
			if (row >= this.leaderboardSelfRankings.Count)
			{
				return null;
			}
			return this.leaderboardSelfRankings[row];
		}

		// Token: 0x060032FA RID: 13050 RVA: 0x0029F9A8 File Offset: 0x0029DBA8
		public string GetLeaderboardCategoryScore(int category, int value, WorldData worldData)
		{
			NumberFormatInfo nfi = GameEngine.NFI;
			switch (category)
			{
			case -6:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Villages", "Villages"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case -5:
			{
				int rank = value / 100;
				int rankSubLevel = value % 100;
				return "(" + Rankings.getRankingName(worldData, rank, rankSubLevel, true) + ")";
			}
			case -1:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Points", "Points"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 0:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Resources_Pillages", "Resources Pillaged"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 1:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Attacked_Killed", "Attackers Killed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 2:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Buildings_Destroyed", "Buildings Destroyed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 3:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Wolves_Killed", "Wolves Killed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 4:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Bandits_Killed", "Bandits Killed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 5:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_AI_Killed", "AI Troops Killed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 6:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Traded", "Packets Traded"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 7:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Foraged", "Packets Foraged"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 8:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Produced", "Packets Produced"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 9:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Produced", "Packets Produced"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 10:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Produced", "Packets Produced"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 11:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Produced", "Packets Produced"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 12:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Produced", "Packets Produced"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 13:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("User_Quests_Complete", "Quests Completed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 14:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Packets_Donated", "Packets Donated"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 15:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Villages_Captured", "Villages Captured"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 16:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Villages_Razed", "Villages Razed"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 17:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_Glory_Generated", "Glory Generated"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			case 18:
				return string.Concat(new string[]
				{
					"(",
					SK.Text("Stats_killstreak_Generated", "Kill Streak"),
					" : ",
					value.ToString("N", nfi),
					")"
				});
			}
			throw new ArgumentException("Invalid leaderboard category: " + category.ToString());
		}

		// Token: 0x060032FB RID: 13051 RVA: 0x002A0024 File Offset: 0x0029E224
		public void updateRegionsNamesBasedOnLanguage()
		{
			if (this.chMap)
			{
				string languageIdent = Program.mySettings.languageIdent;
				string[,] array;
				string[,] array2;
				string[,] array3;
				string[] array4;
				if (languageIdent != null && (languageIdent == "zh" || languageIdent == "zhhk"))
				{
					array = this.china_country_Simplified;
					array2 = this.china_province_Simplified;
					array3 = this.china_county_Simplified;
					array4 = this.china_parish_Simplified;
				}
				else
				{
					array = this.china_country_English;
					array2 = this.china_province_English;
					array3 = this.china_county_English;
					array4 = this.china_parish_English;
				}
				try
				{
					for (int i = 0; i < 6; i++)
					{
						int countryCapital = this.getCountryCapital(i);
						VillageData villageData = this.getVillageData(countryCapital);
						villageData.villageName = array[i, 1];
						this.countryList[i].areaName = array[i, 0];
					}
					for (int j = 0; j < 13; j++)
					{
						int provinceCapital = this.getProvinceCapital(j);
						VillageData villageData2 = this.getVillageData(provinceCapital);
						villageData2.villageName = array2[j, 1];
						this.provincesList[j].areaName = array2[j, 0];
					}
					for (int k = 0; k < 73; k++)
					{
						int countyCapitalVillage = this.getCountyCapitalVillage(k);
						VillageData villageData3 = this.getVillageData(countyCapitalVillage);
						villageData3.villageName = array3[k, 1];
						this.countyList[k].areaName = array3[k, 0];
					}
					for (int l = 0; l < 5411; l++)
					{
						this.fixupParishName(l, this.getParishCapital(l), array4[l]);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060032FC RID: 13052 RVA: 0x00024A9B File Offset: 0x00022C9B
		public void LoadLocalisedParishNamesFromFiles()
		{
			if (this.china_parish_Simplified == null)
			{
				this.china_parish_Simplified = this.getParishNamesFromFile("zh");
			}
			if (this.china_parish_English == null)
			{
				this.china_parish_English = this.getParishNamesFromFile("zhEN");
			}
		}

		// Token: 0x060032FD RID: 13053 RVA: 0x002A01D8 File Offset: 0x0029E3D8
		private string[] getParishNamesFromFile(string ident)
		{
			List<string> list = new List<string>();
			FileStream fileStream = new FileStream(Application.StartupPath + "\\Localization\\parishes-" + ident + ".txt", FileMode.Open, FileAccess.Read);
			StreamReader streamReader = new StreamReader(fileStream);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				int startIndex = text.IndexOf("//");
				list.Add(text.Remove(startIndex).Trim());
			}
			streamReader.Close();
			fileStream.Close();
			return list.ToArray();
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060032FE RID: 13054 RVA: 0x00024ACF File Offset: 0x00022CCF
		// (set) Token: 0x060032FF RID: 13055 RVA: 0x00024AD7 File Offset: 0x00022CD7
		internal VillageData[] VillageList
		{
			get
			{
				return this.villageList;
			}
			set
			{
				this.villageList = value;
			}
		}

		// Token: 0x06003300 RID: 13056 RVA: 0x002A0254 File Offset: 0x0029E454
		public int[] CountYourArmyTroopsArray(int villageID)
		{
			int[] array = new int[6];
			foreach (object obj in this.getArmyArray())
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.travelFromVillageID == villageID && localArmyData.homeVillageID == villageID)
				{
					array[0] += localArmyData.numPeasants;
					array[1] += localArmyData.numArchers;
					array[2] += localArmyData.numPikemen;
					array[3] += localArmyData.numSwordsmen;
					array[4] += localArmyData.numCatapults;
				}
			}
			return array;
		}

		// Token: 0x06003301 RID: 13057 RVA: 0x002A0318 File Offset: 0x0029E518
		public int[] CountYourReinforcementTroopsArray(int villageID)
		{
			int[] array = new int[6];
			foreach (object obj in this.getReinforcementsArray())
			{
				WorldMap.LocalArmyData localArmyData = (WorldMap.LocalArmyData)obj;
				if (localArmyData.homeVillageID == villageID)
				{
					array[0] += localArmyData.numPeasants;
					array[1] += localArmyData.numArchers;
					array[2] += localArmyData.numPikemen;
					array[3] += localArmyData.numSwordsmen;
					array[4] += localArmyData.numCatapults;
				}
			}
			return array;
		}

		// Token: 0x06003302 RID: 13058 RVA: 0x002A03D0 File Offset: 0x0029E5D0
		public void doGetUserVillages(List<int> userVillageList, List<string> userVillageNameList)
		{
			VillageData[] array = this.villageList;
			foreach (VillageData villageData in array)
			{
				villageData.userVillageID = -1;
			}
			int count = userVillageList.Count;
			List<int> list;
			if (this.m_userVillages != null && this.m_userVillages.Count != 0)
			{
				list = new List<int>(from v in this.m_userVillages
				select v.villageID);
			}
			else
			{
				list = new List<int>();
			}
			this.m_userVillages = new List<WorldMap.UserVillageData>();
			for (int j = 0; j < count; j++)
			{
				WorldMap.UserVillageData userVillageData = new WorldMap.UserVillageData();
				userVillageData.villageID = userVillageList[j];
				this.m_userVillages.Add(userVillageData);
				this.villageList[userVillageData.villageID].userVillageID = j;
				this.villageList[userVillageData.villageID].visible = true;
				this.villageList[userVillageData.villageID].userID = RemoteServices.Instance.UserID;
				this.villageList[userVillageData.villageID].factionID = RemoteServices.Instance.UserFactionID;
			}
			using (List<int>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int villageID = enumerator.Current;
					if (!this.m_userVillages.Any((WorldMap.UserVillageData v) => v.villageID == villageID))
					{
						ControlForm controlForm = DX.ControlForm;
						if (controlForm != null)
						{
							controlForm.RemoveVillage(villageID);
						}
					}
				}
			}
			foreach (WorldMap.UserVillageData userVillageData2 in this.m_userVillages)
			{
				if (!list.Contains(userVillageData2.villageID))
				{
					ControlForm controlForm2 = DX.ControlForm;
					if (controlForm2 != null)
					{
						controlForm2.AddVillage(userVillageData2.villageID);
					}
				}
			}
			this.updateUserRelatedVillages();
			this.sortUserVillages();
			InterfaceMgr.Instance.validateUserVillage();
			this.updateUserVassals();
		}

		// Token: 0x06003303 RID: 13059 RVA: 0x002A05FC File Offset: 0x0029E7FC
		public WorldMap.SpecialVillageCache GetSpecialVillageData(int villageID, out bool delay)
		{
			WorldMap.SpecialVillageCache specialVillageCache = null;
			delay = false;
			if (villageID >= 0)
			{
				bool flag = false;
				if (this.specialVillageCache[villageID] == null)
				{
					flag = true;
				}
				else
				{
					specialVillageCache = (WorldMap.SpecialVillageCache)this.specialVillageCache[villageID];
					if ((DateTime.Now - specialVillageCache.lastUpdate).TotalMinutes > 1.0)
					{
						flag = true;
					}
					if (this.villageList[villageID].special > 100 && this.villageList[villageID].special <= 199)
					{
						int num = this.villageList[villageID].special - 100;
						if (num != specialVillageCache.resourceType)
						{
							this.specialVillageCache[villageID] = null;
							specialVillageCache = null;
						}
					}
					else
					{
						this.specialVillageCache[villageID] = null;
						specialVillageCache = null;
					}
				}
				if (flag && this.lastSpecialRequestSent != villageID)
				{
					bool flag2 = true;
					if (this.lastActualSpecialRequestSent == villageID && (DateTime.Now - this.lastActualSpecialRequestTime).TotalMinutes < 1.0)
					{
						flag2 = false;
					}
					if (flag2 && this.villageList[villageID].special > 100 && this.villageList[villageID].special <= 199)
					{
						RemoteServices.Instance.set_SpecialVillageInfo_UserCallBack(new RemoteServices.SpecialVillageInfo_UserCallBack(this.specialVillageInfoCallback));
						RemoteServices.Instance.SpecialVillageInfo(villageID);
						this.lastSpecialRequestSent = villageID;
						this.lastActualSpecialRequestSent = villageID;
						this.lastActualSpecialRequestTime = DateTime.Now;
						delay = true;
					}
				}
			}
			return specialVillageCache;
		}

		// Token: 0x06003304 RID: 13060 RVA: 0x002A0770 File Offset: 0x0029E970
		public void updateUserVassals()
		{
			if (this.m_userVillages != null)
			{
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
				{
					list.AddRange(userVillageData.vassals);
					userVillageData.vassals.Clear();
				}
				VillageData[] array = this.villageList;
				foreach (VillageData villageData in array)
				{
					if (villageData.connecter >= 0)
					{
						foreach (WorldMap.UserVillageData userVillageData2 in this.m_userVillages)
						{
							if (userVillageData2.villageID == villageData.connecter)
							{
								userVillageData2.vassals.Add(villageData.id);
								list2.Add(villageData.id);
								break;
							}
						}
					}
				}
				if (DX.ControlForm == null)
				{
					return;
				}
				foreach (int num in list)
				{
					if (!list2.Contains(num))
					{
						DX.ControlForm.RemoveVassal(array[num]);
					}
				}
				foreach (int num2 in list2)
				{
					if (!list.Contains(num2))
					{
						DX.ControlForm.AddVassal(array[num2]);
					}
				}
			}
		}

		// Token: 0x06003305 RID: 13061 RVA: 0x002A0938 File Offset: 0x0029EB38
		public List<int> getListOfUserVillagesAndCapitals(int userID)
		{
			List<int> list = new List<int>();
			foreach (VillageData villageData in GameEngine.Instance.World.VillageList)
			{
				if (villageData.userID == userID)
				{
					list.Add(villageData.id);
				}
			}
			return list;
		}

		// Token: 0x06003306 RID: 13062 RVA: 0x002A0984 File Offset: 0x0029EB84
		public string getUsernameByUserId(int userID)
		{
			foreach (UserRelationship userRelationship in this.userRelations)
			{
				if (userRelationship.userID == userID)
				{
					return userRelationship.userName;
				}
			}
			return string.Empty;
		}

		// Token: 0x06003307 RID: 13063 RVA: 0x002A09EC File Offset: 0x0029EBEC
		public string getUsernameByVillageId(int villageId)
		{
			int villageUserID = this.getVillageUserID(villageId);
			foreach (UserRelationship userRelationship in this.userRelations)
			{
				if (userRelationship.userID == villageUserID)
				{
					return userRelationship.userName;
				}
			}
			return string.Empty;
		}

		// Token: 0x06003308 RID: 13064 RVA: 0x002A0A5C File Offset: 0x0029EC5C
		internal WorldMap.CachedUserInfo getStoredUserInfo(string username)
		{
			username = username.Trim().ToLower();
			foreach (object obj in this.cachedUserInfo)
			{
				WorldMap.CachedUserInfo cachedUserInfo = (WorldMap.CachedUserInfo)obj;
				if (cachedUserInfo.userName.ToLower() == username)
				{
					return cachedUserInfo;
				}
			}
			return null;
		}

		// Token: 0x06003309 RID: 13065 RVA: 0x002A0AD8 File Offset: 0x0029ECD8
		public int getSquareDistance(int x1, int y1, int villageID2)
		{
			return (x1 - (int)this.villageList[villageID2].x) * (x1 - (int)this.villageList[villageID2].x) + (y1 - (int)this.villageList[villageID2].y) * (y1 - (int)this.villageList[villageID2].y);
		}

		// Token: 0x0600330A RID: 13066 RVA: 0x00024AE0 File Offset: 0x00022CE0
		public int getSquareDistance(int x1, int y1, int x2, int y2)
		{
			return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
		}

		// Token: 0x0600330B RID: 13067 RVA: 0x002A0B24 File Offset: 0x0029ED24
		public List<int> getListOfUserParishCapitals()
		{
			List<int> list = new List<int>();
			if (this.m_userVillages == null)
			{
				return list;
			}
			foreach (WorldMap.UserVillageData userVillageData in this.m_userVillages)
			{
				if (userVillageData.parishCapital)
				{
					list.Add(userVillageData.villageID);
				}
			}
			return list;
		}

		// Token: 0x0600330C RID: 13068 RVA: 0x002A0B98 File Offset: 0x0029ED98
		public int countCommandMonksSent(int command, int targetId)
		{
			List<int> listOfUserVillages = GameEngine.Instance.World.getListOfUserVillages();
			int num = 0;
			foreach (object obj in this.personArray)
			{
				WorldMap.LocalPerson localPerson = (WorldMap.LocalPerson)obj;
				if (localPerson.person.personType == 4 && localPerson.person.command == command && listOfUserVillages.Contains(localPerson.person.homeVillageID) && (targetId == -1 || localPerson.person.targetVillageID == targetId))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600330D RID: 13069 RVA: 0x002A0C48 File Offset: 0x0029EE48
		public bool IsPlayerVillage(int villageID)
		{
			if (villageID < 0 || villageID >= this.villageList.Length)
			{
				return false;
			}
			VillageData villageData = this.villageList[villageID];
			return villageData.visible && !villageData.Capital && villageData.special == 0 && villageData.userID >= 0;
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x00024AF3 File Offset: 0x00022CF3
		internal bool areSameVillageType(int villageA, int villageB)
		{
			return this.villageList[villageA].villageTerrain == this.villageList[villageB].villageTerrain;
		}

		// Token: 0x0600330F RID: 13071 RVA: 0x00024B11 File Offset: 0x00022D11
		internal bool isTargetTerrain(int villageA, short targetTerrain)
		{
			return this.villageList[villageA].villageTerrain == targetTerrain;
		}

		// Token: 0x06003310 RID: 13072 RVA: 0x002A0C98 File Offset: 0x0029EE98
		public WorldMap()
		{
			int[] array = new int[4];
			array[1] = 1;
			array[2] = 1;
			this.ukCountryColour = array;
			this.deCountyColour = new int[]
			{
				3,
				1,
				2,
				2,
				0,
				1,
				2,
				3,
				1,
				2,
				0,
				3,
				0,
				2,
				1,
				0,
				3,
				0,
				2,
				3,
				0,
				1,
				3,
				2,
				1,
				0,
				1,
				2,
				0,
				1,
				2,
				2,
				3,
				0,
				3,
				2,
				1,
				1,
				2,
				0,
				0,
				3,
				1,
				3,
				2,
				1,
				2,
				3,
				0,
				3,
				0,
				3,
				1,
				2,
				0,
				1,
				2,
				0,
				3,
				0,
				2,
				1,
				1,
				0,
				3
			};
			this.deProvinceColour = new int[]
			{
				0,
				1,
				2,
				2,
				0,
				1,
				1,
				3,
				2,
				0,
				3,
				1,
				0,
				1,
				0
			};
			this.deCountryColour = new int[]
			{
				0,
				1,
				2,
				1
			};
			this.frCountyColour = new int[]
			{
				2,
				1,
				0,
				1,
				3,
				0,
				1,
				0,
				2,
				3,
				2,
				3,
				3,
				2,
				0,
				1,
				0,
				3,
				2,
				0,
				1,
				1,
				0,
				3,
				0,
				2,
				0,
				3,
				1,
				2,
				2,
				0,
				3,
				0,
				3,
				0,
				3,
				2,
				0,
				3,
				1,
				0,
				0,
				2,
				1,
				2,
				3,
				1,
				2,
				3,
				1,
				0,
				0,
				2,
				3,
				0,
				2,
				0,
				1,
				3,
				0,
				1,
				0,
				2,
				3,
				1,
				0,
				3,
				1,
				1,
				2,
				1,
				3,
				2,
				0,
				1,
				3,
				1,
				0,
				2,
				0,
				2,
				1,
				0,
				2,
				2,
				3,
				1,
				2,
				3,
				1,
				1,
				0,
				1,
				0,
				2,
				3,
				0
			};
			this.frProvinceColour = new int[]
			{
				0,
				1,
				1,
				2,
				0,
				1,
				1,
				0,
				1,
				0,
				2,
				3,
				1,
				2,
				0,
				3,
				1,
				2
			};
			this.frCountryColour = new int[]
			{
				0,
				1,
				2,
				1,
				0,
				2,
				0
			};
			this.ruCountyColour = new int[]
			{
				0,
				1,
				0,
				2,
				1,
				2,
				0,
				1,
				3,
				0,
				2,
				3,
				0,
				1,
				1,
				3,
				0,
				3,
				0,
				1,
				2,
				0,
				1,
				3,
				0,
				2,
				3,
				0,
				1,
				3,
				2,
				0,
				3,
				1,
				1,
				3,
				2,
				3,
				0,
				1,
				0,
				2,
				2,
				1,
				2,
				0,
				3,
				2,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				3,
				0,
				2,
				0,
				1,
				3,
				1,
				0,
				3,
				1,
				0,
				2,
				1,
				2,
				2,
				2,
				0,
				2,
				3,
				1,
				3,
				0,
				2,
				1,
				0,
				2,
				3,
				1,
				3,
				0,
				1,
				2,
				3,
				0,
				3,
				2,
				3,
				1,
				2,
				1,
				3,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				2
			};
			this.ruProvinceColour = new int[]
			{
				0,
				1,
				1,
				0,
				2,
				3,
				2,
				0,
				3,
				1,
				2,
				0,
				1,
				0,
				1,
				2,
				2,
				1,
				2,
				0
			};
			this.ruCountryColour = new int[]
			{
				0,
				1,
				2,
				1,
				1,
				1,
				0
			};
			this.esCountyColour = new int[]
			{
				0,
				1,
				2,
				0,
				0,
				2,
				1,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				2,
				2,
				0,
				1,
				3,
				0,
				2,
				0,
				1,
				1,
				2,
				0,
				2,
				0,
				3,
				2,
				3,
				0,
				2,
				3,
				1,
				0,
				1,
				1,
				3,
				2,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				0,
				0,
				0,
				0,
				1,
				2,
				3,
				0,
				3,
				1,
				0,
				3,
				1,
				0,
				1,
				2,
				3,
				1,
				3,
				0,
				2
			};
			this.esProvinceColour = new int[]
			{
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				3,
				2,
				0,
				2,
				1,
				3
			};
			this.esCountryColour = new int[]
			{
				0,
				1
			};
			this.euCountyColour = new int[]
			{
				2,
				3,
				0,
				1,
				1,
				0,
				3,
				0,
				3,
				1,
				0,
				2,
				1,
				0,
				2,
				3,
				1,
				0,
				2,
				3,
				1,
				2,
				3,
				1,
				2,
				3,
				1,
				2,
				1,
				3,
				3,
				2,
				1,
				3,
				0,
				1,
				3,
				1,
				0,
				0,
				2,
				3,
				1,
				2,
				3,
				1,
				2,
				0,
				1,
				3,
				2,
				0,
				2,
				0,
				1,
				0,
				2,
				1,
				2,
				3,
				1,
				0,
				2,
				1,
				3,
				1,
				2,
				3,
				0,
				2,
				1,
				0,
				2,
				0,
				0,
				1,
				3,
				2,
				3,
				1,
				3,
				2,
				0,
				1,
				0,
				1,
				1,
				2,
				2,
				1,
				0,
				2,
				3,
				0,
				1,
				3,
				2,
				1,
				0,
				3,
				1,
				1,
				2,
				0,
				0,
				3,
				0,
				1,
				1,
				2,
				0,
				3,
				2,
				3,
				1,
				2,
				3,
				0,
				3,
				2,
				1,
				1,
				2,
				1,
				0,
				3,
				2,
				0,
				0,
				3,
				1,
				0,
				3,
				1,
				2,
				1,
				0,
				2,
				0,
				3,
				1,
				1,
				2,
				0,
				3,
				3,
				0,
				1,
				3,
				2,
				0,
				0,
				1,
				2,
				3,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				3,
				3,
				2,
				2,
				0,
				1,
				2,
				0,
				3,
				1,
				3,
				0,
				2,
				1,
				2,
				1,
				2,
				3,
				2,
				0,
				1,
				3,
				2,
				3,
				0,
				1,
				0,
				1,
				1,
				2,
				2,
				2,
				3,
				0,
				2
			};
			this.euProvinceColour = new int[]
			{
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				0,
				0,
				1,
				2,
				0,
				3,
				1,
				0,
				2,
				0,
				1,
				0,
				2,
				1,
				0,
				2,
				3,
				0,
				1,
				2,
				3,
				0,
				2,
				0,
				0,
				0,
				1,
				2,
				1,
				0,
				0,
				2,
				1,
				3,
				1,
				2,
				0,
				0,
				3,
				1,
				1,
				2,
				3,
				1,
				2,
				0,
				2,
				1,
				0,
				0,
				3,
				0,
				2,
				0,
				3,
				2,
				1,
				0,
				2,
				3,
				2,
				1,
				0,
				1,
				1,
				2,
				0,
				2,
				2,
				0,
				0,
				1,
				1,
				0,
				2,
				1,
				2,
				1,
				0
			};
			this.euCountryColour = new int[]
			{
				0,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				2,
				0,
				1,
				2,
				0,
				1,
				2,
				3,
				1,
				0,
				1,
				2,
				0,
				1,
				3,
				0,
				3,
				0,
				2,
				1,
				0,
				3,
				2,
				1,
				1
			};
			this.itCountyColour = new int[]
			{
				0,
				0,
				3,
				1,
				0,
				1,
				2,
				0,
				3,
				0,
				3,
				1,
				1,
				0,
				2,
				3,
				2,
				2,
				2,
				3,
				0,
				1,
				0,
				3,
				2,
				1,
				1,
				3,
				0,
				0,
				2,
				3,
				1,
				1,
				0,
				0,
				3,
				2,
				1,
				0,
				1,
				3,
				3,
				2,
				0,
				2,
				2,
				3,
				2,
				0,
				1,
				1,
				1,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				0,
				1,
				1,
				2,
				0,
				1,
				2,
				0,
				3,
				2,
				1,
				2,
				0,
				1,
				3,
				1,
				2,
				0,
				1,
				2,
				1,
				0,
				1,
				2,
				0,
				0,
				2,
				1,
				0,
				2,
				1,
				0,
				2,
				1,
				0,
				0,
				2,
				0,
				1,
				1,
				0,
				0,
				0,
				2,
				1,
				0,
				2,
				1,
				0,
				2,
				0,
				2,
				1,
				0,
				3,
				2,
				0,
				2,
				1,
				0,
				1,
				3,
				1,
				2,
				0,
				2,
				1,
				2,
				0,
				2,
				1,
				2,
				1,
				0,
				0,
				1,
				0,
				3,
				0,
				1,
				3,
				2,
				2,
				0,
				2,
				1,
				3,
				1,
				0,
				3,
				1,
				1,
				2,
				2,
				0,
				3,
				0,
				2,
				1,
				0,
				1,
				2,
				0,
				3,
				1,
				0,
				2,
				1,
				2,
				1,
				2,
				0,
				1,
				0,
				3,
				0,
				1,
				2,
				3,
				0,
				3,
				2,
				3,
				0,
				1,
				3,
				2,
				0,
				3,
				0,
				2,
				1,
				3,
				0,
				2,
				0,
				1,
				2,
				1,
				0,
				2
			};
			this.itProvinceColour = new int[]
			{
				0,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				2,
				3,
				1,
				0,
				1,
				0,
				2,
				1,
				0,
				0,
				1,
				0,
				1,
				2,
				0,
				2,
				0,
				1,
				3,
				0,
				1,
				0,
				2,
				1,
				0,
				2,
				1,
				2,
				0,
				0
			};
			this.itCountryColour = new int[]
			{
				0,
				1,
				0,
				1,
				2,
				3,
				2,
				0
			};
			this.plCountyColour = new int[]
			{
				0,
				1,
				2,
				1,
				2,
				0,
				3,
				0,
				1,
				3,
				0,
				2,
				1,
				0,
				3,
				0,
				1,
				2,
				1,
				0,
				2,
				2,
				0,
				1,
				2,
				0,
				2,
				1,
				0,
				0,
				3,
				2,
				1,
				3,
				2,
				2,
				0,
				1,
				0,
				3,
				3,
				1,
				2,
				0,
				1,
				3,
				2,
				1,
				2,
				1,
				0,
				3
			};
			this.plProvinceColour = new int[]
			{
				0,
				1,
				2,
				1,
				0,
				1,
				3,
				0,
				3,
				0,
				1,
				2,
				0,
				3,
				0,
				3
			};
			this.plCountryColour = new int[1];
			this.saCountyColour = new int[]
			{
				0,
				1,
				1,
				2,
				2,
				0,
				0,
				3,
				1,
				1,
				2,
				0,
				1,
				0,
				2,
				0,
				1,
				1,
				0,
				2,
				0,
				1,
				3,
				0,
				1,
				2,
				2,
				3,
				0,
				1,
				2,
				3,
				0,
				0,
				1,
				2,
				2,
				0,
				1,
				0,
				2,
				3,
				1,
				0,
				2,
				1,
				2,
				3,
				0,
				2,
				2,
				3,
				0,
				2,
				1,
				0,
				1,
				0,
				3,
				0,
				0,
				2,
				1,
				3,
				0,
				1,
				2,
				1,
				0,
				2,
				3,
				3,
				0,
				3,
				0,
				1,
				3,
				0,
				3,
				2,
				1,
				2,
				0,
				1,
				3,
				2,
				0,
				1,
				0,
				2,
				2,
				0,
				1,
				3,
				0,
				1,
				2,
				0,
				1,
				2,
				3,
				1,
				0,
				0,
				3,
				2,
				1,
				2,
				1,
				0,
				0,
				0,
				2,
				0,
				2,
				0,
				2,
				0,
				2,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			this.saProvinceColour = new int[]
			{
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				3,
				0,
				2,
				0,
				3,
				2,
				0,
				1
			};
			int[] array2 = new int[5];
			array2[1] = 1;
			array2[3] = 2;
			this.saCountryColour = array2;
			this.trCountyColour = new int[]
			{
				2,
				3,
				1,
				2,
				1,
				3,
				2,
				3,
				0,
				3,
				1,
				2,
				1,
				2,
				0,
				3,
				0,
				2,
				1,
				0,
				3,
				2,
				3,
				0,
				1,
				1,
				3,
				2,
				3,
				0,
				1,
				0,
				3,
				0,
				1,
				1,
				2,
				3,
				0,
				0,
				1,
				3,
				0,
				1,
				2,
				3,
				1,
				0,
				2,
				1,
				3,
				1,
				0,
				2,
				1,
				3,
				0,
				2,
				0,
				2,
				3,
				1,
				2,
				0,
				1,
				0,
				2,
				3,
				2,
				0,
				1,
				3,
				0,
				2,
				1,
				3,
				2,
				0,
				3,
				0,
				0
			};
			this.trProvinceColour = new int[]
			{
				0,
				1,
				0,
				2,
				1,
				3,
				1
			};
			this.trCountryColour = new int[1];
			this.uk2CountyColour = new int[]
			{
				0,
				1,
				2,
				1,
				2,
				1,
				0,
				1,
				0,
				0,
				2,
				0,
				3,
				1,
				3,
				2,
				1,
				0,
				2,
				0,
				1,
				0,
				2,
				3,
				1,
				3,
				0,
				1,
				0,
				0,
				1,
				3,
				1,
				0,
				0,
				0,
				1,
				2,
				3,
				2,
				1,
				0,
				3,
				0,
				3,
				2,
				1,
				3,
				0,
				1,
				0,
				0,
				0,
				2,
				1,
				3,
				0,
				1,
				3,
				2,
				0,
				3,
				1,
				0,
				1,
				0,
				3,
				0,
				3,
				1,
				0,
				1,
				1,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				2,
				3,
				1,
				2,
				0,
				3,
				2,
				3,
				3,
				1,
				0,
				3,
				0,
				2,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				3,
				2,
				3,
				2,
				0
			};
			this.uk2ProvinceColour = new int[]
			{
				0,
				0,
				2,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				2,
				0,
				1,
				0,
				2,
				0,
				2,
				1,
				1,
				1,
				1,
				0
			};
			this.uk2CountryColour = new int[]
			{
				0,
				1,
				0,
				0,
				0,
				1,
				2,
				1,
				0,
				1,
				2,
				0,
				0,
				2
			};
			this.usCountyColour = new int[]
			{
				0,
				1,
				2,
				1,
				0,
				1,
				0,
				0,
				2,
				2,
				0,
				1,
				0,
				2,
				0,
				1,
				2,
				3,
				0,
				0,
				1,
				2,
				1,
				3,
				0,
				3,
				0,
				1,
				0,
				1,
				0,
				2,
				1,
				1,
				2,
				0,
				1,
				0,
				0,
				1,
				2,
				0,
				3,
				0,
				2,
				3,
				2,
				3,
				0,
				1,
				2,
				1,
				2,
				0,
				1,
				2,
				3,
				2,
				1,
				2,
				0,
				1,
				3,
				2,
				0,
				2,
				3,
				0,
				1,
				2,
				1,
				0,
				2,
				2,
				1,
				3,
				1,
				2,
				0,
				3,
				0,
				1,
				0,
				1,
				2,
				3,
				0,
				1,
				1,
				3,
				0,
				3,
				1,
				0,
				2,
				0,
				1,
				2,
				0,
				2,
				1
			};
			this.usProvinceColour = new int[]
			{
				0,
				1,
				1,
				0,
				2,
				2,
				1,
				0,
				2,
				1,
				0,
				2,
				3,
				0,
				3,
				1,
				0,
				0,
				3,
				1,
				0,
				3,
				0,
				2,
				1,
				2,
				1,
				2,
				1,
				0,
				3,
				3,
				1,
				0,
				1,
				2,
				3,
				2,
				0,
				3,
				0,
				1
			};
			this.usCountryColour = new int[]
			{
				0,
				1,
				2,
				0,
				0,
				1,
				2,
				1,
				0,
				1,
				2
			};
			this.gcCountyColour = new int[]
			{
				2,
				2,
				1,
				0,
				3,
				0,
				1,
				0,
				1,
				2,
				0,
				3,
				0,
				3,
				1,
				2,
				0,
				0,
				0,
				0,
				1,
				0,
				2,
				0,
				0,
				1,
				0,
				2,
				0,
				3,
				0,
				1,
				1,
				3,
				2,
				1,
				3,
				2,
				0,
				0,
				1,
				2,
				3,
				2,
				0,
				2,
				0,
				1,
				2,
				1,
				2,
				0,
				3,
				0,
				3,
				2,
				2,
				1,
				0,
				3,
				0,
				0,
				3,
				0,
				3,
				3,
				0,
				1,
				1,
				3,
				2,
				1,
				0,
				0,
				2,
				0,
				2,
				1,
				1,
				1,
				0,
				1,
				0,
				2,
				3,
				0,
				2,
				1,
				1,
				1,
				2,
				3,
				2,
				0,
				3,
				2,
				0,
				2,
				0,
				2,
				3,
				1,
				0,
				1,
				1,
				3,
				0,
				3,
				1,
				3,
				0,
				3,
				1,
				3,
				2,
				0,
				2,
				0,
				1,
				2,
				0,
				3,
				0,
				1,
				2,
				2,
				0,
				2,
				1,
				0,
				1,
				1,
				1,
				0,
				1,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				2,
				1,
				0,
				1,
				0,
				2,
				1,
				2,
				1,
				1,
				2,
				3,
				0,
				1,
				3,
				2,
				0,
				1,
				0,
				1,
				2,
				1,
				2,
				2,
				0,
				2,
				0,
				2,
				1,
				3,
				0,
				0,
				2,
				0,
				1,
				2,
				3,
				2,
				1,
				1,
				2,
				0,
				0,
				3,
				2,
				0,
				1,
				3,
				1,
				2,
				0,
				1,
				3,
				1,
				2,
				1,
				0,
				2,
				0,
				1,
				1,
				0,
				2,
				3,
				2,
				1,
				2,
				3,
				2,
				1,
				0,
				1,
				2,
				1,
				2,
				1,
				0,
				3,
				3,
				0,
				1,
				1,
				1,
				1,
				0,
				2,
				0,
				3,
				3,
				0,
				3,
				1,
				3,
				0,
				2,
				2,
				1,
				0,
				2,
				3,
				0,
				2,
				1,
				0,
				1,
				3,
				0,
				0,
				0
			};
			this.gcProvinceColour = new int[]
			{
				1,
				0,
				0,
				1,
				3,
				2,
				1,
				0,
				3,
				0,
				3,
				1,
				2,
				3,
				2,
				0,
				2,
				1,
				0,
				2,
				1,
				2,
				3,
				1,
				0,
				1,
				2,
				3,
				0,
				1,
				0,
				1,
				2,
				3,
				3,
				1,
				0,
				2,
				1,
				1,
				3,
				2,
				0,
				3,
				1,
				2,
				0,
				2,
				1,
				3,
				0,
				1,
				3,
				1,
				0,
				1,
				1,
				2,
				0,
				2,
				1,
				0,
				1,
				3,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				1,
				0,
				3,
				0,
				3,
				2,
				3,
				0,
				1,
				2,
				0,
				1,
				2,
				0,
				1,
				2,
				0,
				3,
				2,
				3,
				1,
				2,
				1,
				0,
				2,
				3,
				1,
				0,
				1,
				0,
				1,
				0,
				3,
				2,
				1,
				0,
				0,
				2,
				0,
				3,
				2,
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				3,
				1,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				2,
				0,
				1,
				2,
				1,
				2,
				3,
				0,
				1,
				1,
				2,
				1,
				0,
				3,
				1,
				2,
				0,
				1,
				3
			};
			this.gcCountryColour = new int[]
			{
				1,
				0,
				0,
				1,
				3,
				2,
				1,
				0,
				3,
				0,
				3,
				1,
				2,
				3,
				2,
				0,
				2,
				1,
				0,
				2,
				1,
				2,
				3,
				1,
				0,
				1,
				2,
				3,
				0,
				1,
				0,
				1,
				2,
				3,
				3,
				1,
				0,
				2,
				1,
				1,
				3,
				2,
				0,
				3,
				1,
				2,
				0,
				2,
				1,
				3,
				0,
				1,
				3,
				1,
				0,
				1,
				1,
				2,
				0,
				2,
				1,
				0,
				1,
				3,
				1,
				1,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				1,
				0,
				3,
				0,
				3,
				2,
				3,
				0,
				1,
				2,
				0,
				1,
				2,
				0,
				1,
				2,
				0,
				3,
				2,
				3,
				1,
				2,
				1,
				0,
				2,
				3,
				1,
				0,
				1,
				0,
				1,
				0,
				3,
				2,
				1,
				0,
				0,
				2,
				0,
				3,
				2,
				1,
				2,
				1,
				1,
				1,
				2,
				1,
				3,
				1,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				2,
				0,
				1,
				2,
				1,
				2,
				3,
				0,
				1,
				1,
				2,
				1,
				0,
				3,
				1,
				2,
				0,
				1,
				3
			};
			this.phCountyColour = new int[]
			{
				0,
				1,
				2,
				1,
				3,
				2,
				1,
				3,
				2,
				0,
				3,
				0,
				2,
				0,
				1,
				0,
				3,
				1,
				2,
				3,
				2,
				3,
				0,
				1,
				0,
				3,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				1,
				2,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				2,
				1,
				0,
				2,
				1,
				0,
				1,
				2,
				0,
				2,
				1,
				0,
				1,
				3,
				1,
				0,
				0,
				2,
				0,
				1,
				0,
				2,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				2,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1
			};
			this.phProvinceColour = new int[]
			{
				0,
				1,
				2,
				1,
				0,
				2,
				0,
				2,
				0,
				1,
				0,
				3,
				2,
				0,
				3,
				1,
				2,
				1
			};
			this.phCountryColour = new int[1];
			this.chCountyColour = new int[]
			{
				0,
				1,
				2,
				0,
				3,
				1,
				0,
				3,
				0,
				0,
				2,
				0,
				2,
				0,
				2,
				1,
				2,
				0,
				0,
				1,
				0,
				3,
				2,
				1,
				2,
				3,
				0,
				1,
				0,
				1,
				3,
				0,
				3,
				1,
				0,
				1,
				2,
				3,
				0,
				1,
				1,
				2,
				0,
				3,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				1,
				3,
				0,
				2,
				0,
				1,
				3,
				2,
				1,
				0,
				2,
				3,
				0,
				2,
				0,
				0
			};
			this.chProvinceColour = new int[]
			{
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				0,
				1,
				2,
				0,
				0
			};
			int[] array3 = new int[6];
			array3[1] = 1;
			array3[4] = 1;
			this.chCountryColour = array3;
			this.kgCountyColour = new int[]
			{
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				1,
				2,
				3,
				4,
				0,
				4,
				1,
				2,
				0,
				1,
				0,
				0,
				2,
				3,
				2,
				1,
				0,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				2,
				0,
				2,
				0,
				2,
				1,
				3,
				1,
				3,
				0,
				1,
				2,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				3,
				2,
				1,
				3,
				1,
				2,
				0,
				3,
				1,
				0,
				1,
				0,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				2,
				3,
				1,
				2,
				0,
				1,
				3,
				1,
				0,
				2,
				0,
				1,
				4,
				0,
				1,
				0,
				3,
				4,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				3,
				0,
				3,
				0,
				1,
				0,
				2,
				4,
				0,
				2,
				3,
				0,
				0,
				3,
				0,
				1,
				2,
				0,
				4,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				2,
				0,
				0,
				0,
				0,
				1,
				1,
				4,
				1,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				1,
				2,
				3,
				0,
				1,
				2,
				1,
				0,
				1,
				4,
				1,
				0,
				2,
				1,
				0,
				3,
				2,
				0,
				1,
				0,
				1,
				0,
				4,
				0,
				0,
				0,
				0,
				4,
				1,
				1,
				2,
				1,
				2,
				1,
				3,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				0,
				1,
				0,
				4,
				0,
				1,
				2,
				0,
				3,
				0,
				1,
				2,
				0,
				2,
				3,
				1,
				4,
				2,
				1,
				0,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				1,
				4,
				2,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				0,
				2,
				0
			};
			this.kgProvinceColour = new int[]
			{
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				1,
				2,
				3,
				4,
				0,
				4,
				1,
				2,
				0,
				1,
				0,
				0,
				2,
				3,
				2,
				1,
				0,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				2,
				0,
				2,
				0,
				2,
				1,
				3,
				1,
				3,
				0,
				1,
				2,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				3,
				2,
				1,
				3,
				1,
				2,
				0,
				3,
				1,
				0,
				1,
				0,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				2,
				3,
				1,
				2,
				0,
				1,
				3,
				1,
				0,
				2,
				0,
				1,
				4,
				0,
				1,
				0,
				3,
				4,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				3,
				0,
				3,
				0,
				1,
				0,
				2,
				4,
				0,
				2,
				3,
				0,
				0,
				3,
				0,
				1,
				2,
				0,
				4,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				2,
				0,
				0,
				0,
				0,
				1,
				1,
				4,
				1,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				1,
				2,
				3,
				0,
				1,
				2,
				1,
				0,
				1,
				4,
				1,
				0,
				2,
				1,
				0,
				3,
				2,
				0,
				1,
				0,
				1,
				0,
				4,
				0,
				0,
				0,
				0,
				4,
				1,
				1,
				2,
				1,
				2,
				1,
				3,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				0,
				1,
				0,
				4,
				0,
				1,
				2,
				0,
				3,
				0,
				1,
				2,
				0,
				2,
				3,
				1,
				4,
				2,
				1,
				0,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				1,
				4,
				2,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				0,
				2,
				0
			};
			this.kgCountryColour = new int[]
			{
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				1,
				2,
				3,
				4,
				0,
				4,
				1,
				2,
				0,
				1,
				0,
				0,
				2,
				3,
				2,
				1,
				0,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				0,
				3,
				1,
				0,
				2,
				0,
				2,
				0,
				2,
				1,
				3,
				1,
				3,
				0,
				1,
				2,
				0,
				2,
				0,
				1,
				0,
				0,
				0,
				0,
				3,
				2,
				1,
				3,
				1,
				2,
				0,
				3,
				1,
				0,
				1,
				0,
				0,
				1,
				2,
				0,
				2,
				1,
				2,
				0,
				1,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				2,
				3,
				1,
				2,
				0,
				1,
				3,
				1,
				0,
				2,
				0,
				1,
				4,
				0,
				1,
				0,
				3,
				4,
				0,
				2,
				1,
				0,
				2,
				0,
				1,
				3,
				0,
				3,
				0,
				1,
				0,
				2,
				4,
				0,
				2,
				3,
				0,
				0,
				3,
				0,
				1,
				2,
				0,
				4,
				0,
				1,
				0,
				1,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				2,
				0,
				0,
				0,
				0,
				1,
				1,
				4,
				1,
				1,
				0,
				0,
				0,
				1,
				0,
				1,
				0,
				1,
				2,
				1,
				2,
				3,
				0,
				1,
				2,
				1,
				0,
				1,
				4,
				1,
				0,
				2,
				1,
				0,
				3,
				2,
				0,
				1,
				0,
				1,
				0,
				4,
				0,
				0,
				0,
				0,
				4,
				1,
				1,
				2,
				1,
				2,
				1,
				3,
				0,
				1,
				2,
				0,
				3,
				2,
				0,
				0,
				1,
				0,
				4,
				0,
				1,
				2,
				0,
				3,
				0,
				1,
				2,
				0,
				2,
				3,
				1,
				4,
				2,
				1,
				0,
				0,
				1,
				0,
				1,
				2,
				0,
				1,
				0,
				2,
				1,
				4,
				2,
				3,
				0,
				2,
				0,
				1,
				0,
				1,
				0,
				2,
				0
			};
			this.leaderboard_Main = new SparseArray();
			this.leaderboard_MainRank = new SparseArray();
			this.leaderboard_MainVillages = new SparseArray();
			this.leaderboard_Factions = new SparseArray();
			this.leaderboard_Houses = new SparseArray();
			this.leaderboard_ParishFlags = new SparseArray();
			this.leaderboard_Sub_Pillager = new SparseArray();
			this.leaderboard_Sub_Defender = new SparseArray();
			this.leaderboard_Sub_Ransack = new SparseArray();
			this.leaderboard_Sub_Wolfsbane = new SparseArray();
			this.leaderboard_Sub_Banditkiller = new SparseArray();
			this.leaderboard_Sub_AIKiller = new SparseArray();
			this.leaderboard_Sub_Trader = new SparseArray();
			this.leaderboard_Sub_Forager = new SparseArray();
			this.leaderboard_Sub_Stockpiler = new SparseArray();
			this.leaderboard_Sub_Farmer = new SparseArray();
			this.leaderboard_Sub_Brewer = new SparseArray();
			this.leaderboard_Sub_Weaponsmith = new SparseArray();
			this.leaderboard_Sub_banquetter = new SparseArray();
			this.leaderboard_Sub_Achiever = new SparseArray();
			this.leaderboard_Sub_Donater = new SparseArray();
			this.leaderboard_Sub_Capture = new SparseArray();
			this.leaderboard_Sub_Raze = new SparseArray();
			this.leaderboard_Sub_Glory = new SparseArray();
			this.leaderboard_Sub_KillStreak = new SparseArray();
			this.max_leaderboard_Main = -1;
			this.max_leaderboard_MainRank = -1;
			this.max_leaderboard_MainVillages = -1;
			this.max_leaderboard_Factions = -1;
			this.max_leaderboard_Houses = -1;
			this.max_leaderboard_ParishFlags = -1;
			this.max_leaderboard_Sub_Pillager = -1;
			this.max_leaderboard_Sub_Defender = -1;
			this.max_leaderboard_Sub_Ransack = -1;
			this.max_leaderboard_Sub_Wolfsbane = -1;
			this.max_leaderboard_Sub_Banditkiller = -1;
			this.max_leaderboard_Sub_AIKiller = -1;
			this.max_leaderboard_Sub_Trader = -1;
			this.max_leaderboard_Sub_Forager = -1;
			this.max_leaderboard_Sub_Stockpiler = -1;
			this.max_leaderboard_Sub_Farmer = -1;
			this.max_leaderboard_Sub_Brewer = -1;
			this.max_leaderboard_Sub_Weaponsmith = -1;
			this.max_leaderboard_Sub_banquetter = -1;
			this.max_leaderboard_Sub_Achiever = -1;
			this.max_leaderboard_Sub_Donater = -1;
			this.max_leaderboard_Sub_Capture = -1;
			this.max_leaderboard_Sub_Raze = -1;
			this.max_leaderboard_Sub_Glory = -1;
			this.max_leaderboard_Sub_KillStreak = -1;
			this.lastZeroDownload_leaderboard_Main = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_MainRank = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_MainVillages = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Factions = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Houses = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_ParishFlags = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Pillager = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Defender = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Ransack = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Wolfsbane = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Banditkiller = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_AIKiller = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Trader = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Forager = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Stockpiler = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Farmer = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Brewer = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Weaponsmith = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_banquetter = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Achiever = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Donater = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Capture = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Raze = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_Glory = DateTime.MinValue;
			this.lastZeroDownload_leaderboard_Sub_KillStreak = DateTime.MinValue;
			this.leaderboardLastUpdateTime = DateTime.MinValue;
			this.leaderboardSelfRankings = new List<LeaderBoardSelfRankings>();
			this.leaderboardSearchResults = new List<LeaderBoardSearchResults>();
			this.leaderboardSelfRankingsComparer = new WorldMap.LeaderboardSelfRankingsComparer();
			this.leaderboardSelfStaticComparer = new WorldMap.LeaderboardSelfStaticComparer();
			string[,] array4 = new string[6, 2];
			array4[0, 0] = "??";
			array4[0, 1] = "??";
			array4[1, 0] = "???";
			array4[1, 1] = "??";
			array4[2, 0] = "???";
			array4[2, 1] = "??";
			array4[3, 0] = "??";
			array4[3, 1] = "??";
			array4[4, 0] = "??";
			array4[4, 1] = "????";
			array4[5, 0] = "????";
			array4[5, 1] = "??";
			this.china_country_Simplified = array4;
			string[,] array5 = new string[6, 2];
			array5[0, 0] = "China";
			array5[0, 1] = "Beijing";
			array5[1, 0] = "North Korea";
			array5[1, 1] = "Pyongyang";
			array5[2, 0] = "South Korea";
			array5[2, 1] = "Seoul";
			array5[3, 0] = "Japan";
			array5[3, 1] = "Tokyo";
			array5[4, 0] = "Mongolia";
			array5[4, 1] = "Ulaanbaatar";
			array5[5, 0] = "Taiwan, Province of China";
			array5[5, 1] = "Taipei";
			this.china_country_English = array5;
			string[,] array6 = new string[6, 2];
			array6[0, 0] = "China";
			array6[0, 1] = "Beijing";
			array6[1, 0] = "North Korea";
			array6[1, 1] = "Pyongyang";
			array6[2, 0] = "South Korea";
			array6[2, 1] = "Seoul";
			array6[3, 0] = "Japan";
			array6[3, 1] = "Tokyo";
			array6[4, 0] = "Mongolia";
			array6[4, 1] = "Ulaanbaatar";
			array6[5, 0] = "Taiwan, Province of China";
			array6[5, 1] = "Taipei";
			this.china_country_Korean = array6;
			string[,] array7 = new string[6, 2];
			array7[0, 0] = "China";
			array7[0, 1] = "Beijing";
			array7[1, 0] = "North Korea";
			array7[1, 1] = "Pyongyang";
			array7[2, 0] = "South Korea";
			array7[2, 1] = "Seoul";
			array7[3, 0] = "Japan";
			array7[3, 1] = "Tokyo";
			array7[4, 0] = "Mongolia";
			array7[4, 1] = "Ulaanbaatar";
			array7[5, 0] = "Taiwan, Province of China";
			array7[5, 1] = "Taipei";
			this.china_country_Japanese = array7;
			string[,] array8 = new string[13, 2];
			array8[0, 0] = "?????";
			array8[0, 1] = "??";
			array8[1, 0] = "????";
			array8[1, 1] = "???";
			array8[2, 0] = "?????";
			array8[2, 1] = "??";
			array8[3, 0] = "?????";
			array8[3, 1] = "??";
			array8[4, 0] = "????";
			array8[4, 1] = "??";
			array8[5, 0] = "?????";
			array8[5, 1] = "??";
			array8[6, 0] = "???";
			array8[6, 1] = "??";
			array8[7, 0] = "???";
			array8[7, 1] = "??";
			array8[8, 0] = "????";
			array8[8, 1] = "??";
			array8[9, 0] = "????";
			array8[9, 1] = "??";
			array8[10, 0] = "????";
			array8[10, 1] = "??";
			array8[11, 0] = "????";
			array8[11, 1] = "???";
			array8[12, 0] = "??";
			array8[12, 1] = "??";
			this.china_province_Simplified = array8;
			string[,] array9 = new string[13, 2];
			array9[0, 0] = "Northwest China";
			array9[0, 1] = "Xi'an";
			array9[1, 0] = "North China";
			array9[1, 1] = "Shijiazhuang";
			array9[2, 0] = "Northeast China";
			array9[2, 1] = "Shenyang";
			array9[3, 0] = "Southwest China";
			array9[3, 1] = "Nanning";
			array9[4, 0] = "Central China";
			array9[4, 1] = "Chongqing";
			array9[5, 0] = "Southeast China";
			array9[5, 1] = "Shanghai";
			array9[6, 0] = "Hamhung";
			array9[6, 1] = "Hamhung";
			array9[7, 0] = "Busan";
			array9[7, 1] = "Busan";
			array9[8, 0] = "South Japan";
			array9[8, 1] = "Osaka";
			array9[9, 0] = "North Japan";
			array9[9, 1] = "Yokohama";
			array9[10, 0] = "West Mongolia";
			array9[10, 1] = "Moron";
			array9[11, 0] = "East Mongolia";
			array9[11, 1] = "Darkhan";
			array9[12, 0] = "Kaohsiung City";
			array9[12, 1] = "Kaohsiung City";
			this.china_province_English = array9;
			string[,] array10 = new string[13, 2];
			array10[0, 0] = "Northwest China";
			array10[0, 1] = "Xi'an";
			array10[1, 0] = "North China";
			array10[1, 1] = "Shijiazhuang";
			array10[2, 0] = "Northeast China";
			array10[2, 1] = "Shenyang";
			array10[3, 0] = "Southwest China";
			array10[3, 1] = "Nanning";
			array10[4, 0] = "Central China";
			array10[4, 1] = "Chongqing";
			array10[5, 0] = "Southeast China";
			array10[5, 1] = "Shanghai";
			array10[6, 0] = "Hamhung";
			array10[6, 1] = "Hamhung";
			array10[7, 0] = "Busan";
			array10[7, 1] = "Busan";
			array10[8, 0] = "South Japan";
			array10[8, 1] = "Osaka";
			array10[9, 0] = "North Japan";
			array10[9, 1] = "Yokohama";
			array10[10, 0] = "West Mongolia";
			array10[10, 1] = "Moron";
			array10[11, 0] = "East Mongolia";
			array10[11, 1] = "Darkhan";
			array10[12, 0] = "Kaohsiung City";
			array10[12, 1] = "Kaohsiung City";
			this.china_province_Korean = array10;
			string[,] array11 = new string[13, 2];
			array11[0, 0] = "Northwest China";
			array11[0, 1] = "Xi'an";
			array11[1, 0] = "North China";
			array11[1, 1] = "Shijiazhuang";
			array11[2, 0] = "Northeast China";
			array11[2, 1] = "Shenyang";
			array11[3, 0] = "Southwest China";
			array11[3, 1] = "Nanning";
			array11[4, 0] = "Central China";
			array11[4, 1] = "Chongqing";
			array11[5, 0] = "Southeast China";
			array11[5, 1] = "Shanghai";
			array11[6, 0] = "Hamhung";
			array11[6, 1] = "Hamhung";
			array11[7, 0] = "Busan";
			array11[7, 1] = "Busan";
			array11[8, 0] = "South Japan";
			array11[8, 1] = "Osaka";
			array11[9, 0] = "North Japan";
			array11[9, 1] = "Yokohama";
			array11[10, 0] = "West Mongolia";
			array11[10, 1] = "Moron";
			array11[11, 0] = "East Mongolia";
			array11[11, 1] = "Darkhan";
			array11[12, 0] = "Kaohsiung City";
			array11[12, 1] = "Kaohsiung City";
			this.china_province_Japanese = array11;
			string[,] array12 = new string[73, 2];
			array12[0, 0] = "??";
			array12[0, 1] = "????";
			array12[1, 0] = "??";
			array12[1, 1] = "??";
			array12[2, 0] = "??";
			array12[2, 1] = "??";
			array12[3, 0] = "??";
			array12[3, 1] = "??";
			array12[4, 0] = "??";
			array12[4, 1] = "??";
			array12[5, 0] = "???";
			array12[5, 1] = "????";
			array12[6, 0] = "??";
			array12[6, 1] = "??";
			array12[7, 0] = "??";
			array12[7, 1] = "??";
			array12[8, 0] = "??";
			array12[8, 1] = "??";
			array12[9, 0] = "??";
			array12[9, 1] = "??";
			array12[10, 0] = "??";
			array12[10, 1] = "??";
			array12[11, 0] = "???";
			array12[11, 1] = "???";
			array12[12, 0] = "??";
			array12[12, 1] = "??";
			array12[13, 0] = "??";
			array12[13, 1] = "??";
			array12[14, 0] = "??";
			array12[14, 1] = "??";
			array12[15, 0] = "??";
			array12[15, 1] = "??";
			array12[16, 0] = "??";
			array12[16, 1] = "??";
			array12[17, 0] = "??";
			array12[17, 1] = "??";
			array12[18, 0] = "??";
			array12[18, 1] = "??";
			array12[19, 0] = "???";
			array12[19, 1] = "??";
			array12[20, 0] = "??";
			array12[20, 1] = "??";
			array12[21, 0] = "??";
			array12[21, 1] = "??";
			array12[22, 0] = "??";
			array12[22, 1] = "??";
			array12[23, 0] = "??";
			array12[23, 1] = "??";
			array12[24, 0] = "??";
			array12[24, 1] = "??";
			array12[25, 0] = "??";
			array12[25, 1] = "??";
			array12[26, 0] = "??";
			array12[26, 1] = "??";
			array12[27, 0] = "??";
			array12[27, 1] = "??";
			array12[28, 0] = "??";
			array12[28, 1] = "??";
			array12[29, 0] = "????";
			array12[29, 1] = "???";
			array12[30, 0] = "???";
			array12[30, 1] = "??";
			array12[31, 0] = "???";
			array12[31, 1] = "??";
			array12[32, 0] = "????";
			array12[32, 1] = "??";
			array12[33, 0] = "????";
			array12[33, 1] = "??";
			array12[34, 0] = "????";
			array12[34, 1] = "??";
			array12[35, 0] = "????";
			array12[35, 1] = "??";
			array12[36, 0] = "????";
			array12[36, 1] = "???";
			array12[37, 0] = "???";
			array12[37, 1] = "??";
			array12[38, 0] = "???";
			array12[38, 1] = "??";
			array12[39, 0] = "???";
			array12[39, 1] = "??";
			array12[40, 0] = "????";
			array12[40, 1] = "??";
			array12[41, 0] = "????";
			array12[41, 1] = "??";
			array12[42, 0] = "????";
			array12[42, 1] = "??";
			array12[43, 0] = "????";
			array12[43, 1] = "??";
			array12[44, 0] = "????";
			array12[44, 1] = "??";
			array12[45, 0] = "????";
			array12[45, 1] = "??";
			array12[46, 0] = "??";
			array12[46, 1] = "??";
			array12[47, 0] = "????";
			array12[47, 1] = "???";
			array12[48, 0] = "??";
			array12[48, 1] = "??";
			array12[49, 0] = "??";
			array12[49, 1] = "??";
			array12[50, 0] = "??";
			array12[50, 1] = "???";
			array12[51, 0] = "??";
			array12[51, 1] = "??";
			array12[52, 0] = "????";
			array12[52, 1] = "??";
			array12[53, 0] = "???";
			array12[53, 1] = "??";
			array12[54, 0] = "?????";
			array12[54, 1] = "???";
			array12[55, 0] = "???";
			array12[55, 1] = "????";
			array12[56, 0] = "???";
			array12[56, 1] = "????";
			array12[57, 0] = "???";
			array12[57, 1] = "?????";
			array12[58, 0] = "?????";
			array12[58, 1] = "???";
			array12[59, 0] = "?????";
			array12[59, 1] = "??????";
			array12[60, 0] = "???";
			array12[60, 1] = "?????";
			array12[61, 0] = "????";
			array12[61, 1] = "????";
			array12[62, 0] = "???";
			array12[62, 1] = "????";
			array12[63, 0] = "???";
			array12[63, 1] = "?????";
			array12[64, 0] = "???";
			array12[64, 1] = "??????";
			array12[65, 0] = "???";
			array12[65, 1] = "?????";
			array12[66, 0] = "??";
			array12[66, 1] = "???";
			array12[67, 0] = "???";
			array12[67, 1] = "?????";
			array12[68, 0] = "??";
			array12[68, 1] = "????";
			array12[69, 0] = "???";
			array12[69, 1] = "????";
			array12[70, 0] = "?????";
			array12[70, 1] = "????";
			array12[71, 0] = "??";
			array12[71, 1] = "???";
			array12[72, 0] = "??";
			array12[72, 1] = "??";
			this.china_county_Simplified = array12;
			string[,] array13 = new string[73, 2];
			array13[0, 0] = "Xinjiang";
			array13[0, 1] = "Urumqi";
			array13[1, 0] = "Qinghai";
			array13[1, 1] = "Xining";
			array13[2, 0] = "Gansu";
			array13[2, 1] = "Lanzhou";
			array13[3, 0] = "Ningxia";
			array13[3, 1] = "Yinchuan";
			array13[4, 0] = "Shaanxi";
			array13[4, 1] = "Weinan";
			array13[5, 0] = "Inner Mongolia";
			array13[5, 1] = "Hohhot";
			array13[6, 0] = "Shanxi";
			array13[6, 1] = "Taiyuan";
			array13[7, 0] = "Hebei";
			array13[7, 1] = "Baoding";
			array13[8, 0] = "Capital District";
			array13[8, 1] = "Tianjin";
			array13[9, 0] = "Shandong";
			array13[9, 1] = "Jinan";
			array13[10, 0] = "Henan";
			array13[10, 1] = "Zhengzhou";
			array13[11, 0] = "Heilongjiang";
			array13[11, 1] = "Harbin";
			array13[12, 0] = "Jilin";
			array13[12, 1] = "Changchun";
			array13[13, 0] = "Liaoning";
			array13[13, 1] = "Dalian";
			array13[14, 0] = "Tibet";
			array13[14, 1] = "Lhasa";
			array13[15, 0] = "Yunnan";
			array13[15, 1] = "Kunming";
			array13[16, 0] = "Guizhou";
			array13[16, 1] = "Guiyang";
			array13[17, 0] = "Guangxi";
			array13[17, 1] = "Yulin";
			array13[18, 0] = "Sichuan";
			array13[18, 1] = "Chengdu";
			array13[19, 0] = "Chongqing Municipality";
			array13[19, 1] = "Wanzhou";
			array13[20, 0] = "Hubei";
			array13[20, 1] = "Wuhan";
			array13[21, 0] = "Hunan";
			array13[21, 1] = "Changsha";
			array13[22, 0] = "Jiangxi";
			array13[22, 1] = "Nanchang";
			array13[23, 0] = "Anhui";
			array13[23, 1] = "Hefei";
			array13[24, 0] = "Jiangsu";
			array13[24, 1] = "Nanjing";
			array13[25, 0] = "Zhejiang";
			array13[25, 1] = "Hangzhou";
			array13[26, 0] = "Fujian";
			array13[26, 1] = "Fuzhou";
			array13[27, 0] = "Guangdong";
			array13[27, 1] = "Guangzhou";
			array13[28, 0] = "Hainan";
			array13[28, 1] = "Haikou";
			array13[29, 0] = "Pyongan-bukto";
			array13[29, 1] = "Sinuiju";
			array13[30, 0] = "Chagang-do";
			array13[30, 1] = "Kanggye";
			array13[31, 0] = "Yanggang-do";
			array13[31, 1] = "Hyesan";
			array13[32, 0] = "Hamgyong-bukto";
			array13[32, 1] = "Chongjin";
			array13[33, 0] = "Hamgyong-namdo";
			array13[33, 1] = "Sinpo";
			array13[34, 0] = "Pyongan-namdo";
			array13[34, 1] = "Pyongsong";
			array13[35, 0] = "Hwanghae-namdo";
			array13[35, 1] = "Haeju";
			array13[36, 0] = "Hwanghe-bukto";
			array13[36, 1] = "Sariwon";
			array13[37, 0] = "Kangwon-do";
			array13[37, 1] = "Wonsan";
			array13[38, 0] = "Gyeonggi";
			array13[38, 1] = "Incheon";
			array13[39, 0] = "Gangwon";
			array13[39, 1] = "Chuncheon";
			array13[40, 0] = "South Chungcheong";
			array13[40, 1] = "Hongseong";
			array13[41, 0] = "North Chungcheong";
			array13[41, 1] = "Cheongju";
			array13[42, 0] = "North Gyeongsang";
			array13[42, 1] = "Daegu";
			array13[43, 0] = "North Jeolla";
			array13[43, 1] = "Jeonju";
			array13[44, 0] = "South Gyeongsang";
			array13[44, 1] = "Changwon";
			array13[45, 0] = "South Jeolla";
			array13[45, 1] = "Gwangju";
			array13[46, 0] = "Kyushu";
			array13[46, 1] = "Fukuoka";
			array13[47, 0] = "Chugoku";
			array13[47, 1] = "Hiroshima";
			array13[48, 0] = "Shikoku";
			array13[48, 1] = "Matsuyama";
			array13[49, 0] = "Kansai";
			array13[49, 1] = "Kobe";
			array13[50, 0] = "Chubu";
			array13[50, 1] = "Nagoya";
			array13[51, 0] = "Kanto";
			array13[51, 1] = "Chiba";
			array13[52, 0] = "Tohoku";
			array13[52, 1] = "Sendai";
			array13[53, 0] = "Hokkaido";
			array13[53, 1] = "Sapporo";
			array13[54, 0] = "Bayan-Olgii";
			array13[54, 1] = "Olgii";
			array13[55, 0] = "Uvs";
			array13[55, 1] = "Ulaangom";
			array13[56, 0] = "Khovd";
			array13[56, 1] = "Khovd";
			array13[57, 0] = "Zavkhan";
			array13[57, 1] = "Uliastai";
			array13[58, 0] = "Govi-Altai";
			array13[58, 1] = "Altai";
			array13[59, 0] = "Bayankhongor";
			array13[59, 1] = "Bayankhongor";
			array13[60, 0] = "Arkhangai";
			array13[60, 1] = "Tsetserleg";
			array13[61, 0] = "Khovsgol";
			array13[61, 1] = "Tarialan";
			array13[62, 0] = "Bulgan";
			array13[62, 1] = "Bulgan";
			array13[63, 0] = "Ovorkhangai";
			array13[63, 1] = "Arvaikheer";
			array13[64, 0] = "Omnogovi";
			array13[64, 1] = "Dalanzadgad";
			array13[65, 0] = "Dundgovi";
			array13[65, 1] = "Mandalgovi";
			array13[66, 0] = "Tov";
			array13[66, 1] = "Zuunmod";
			array13[67, 0] = "Selenge";
			array13[67, 1] = "Sukhbaatar";
			array13[68, 0] = "Khentii";
			array13[68, 1] = "Ondorkhaan";
			array13[69, 0] = "Dornogovi";
			array13[69, 1] = "Sainshand";
			array13[70, 0] = "Sukhbaatar";
			array13[70, 1] = "Baruun-Urt";
			array13[71, 0] = "Dornod";
			array13[71, 1] = "Choibalsan";
			array13[72, 0] = "Taichung City";
			array13[72, 1] = "Taichung City";
			this.china_county_English = array13;
			string[,] array14 = new string[73, 2];
			array14[0, 0] = "Xinjiang";
			array14[0, 1] = "Urumqi";
			array14[1, 0] = "Qinghai";
			array14[1, 1] = "Xining";
			array14[2, 0] = "Gansu";
			array14[2, 1] = "Lanzhou";
			array14[3, 0] = "Ningxia";
			array14[3, 1] = "Yinchuan";
			array14[4, 0] = "Shaanxi";
			array14[4, 1] = "Weinan";
			array14[5, 0] = "Inner Mongolia";
			array14[5, 1] = "Hohhot";
			array14[6, 0] = "Shanxi";
			array14[6, 1] = "Taiyuan";
			array14[7, 0] = "Hebei";
			array14[7, 1] = "Baoding";
			array14[8, 0] = "Capital District";
			array14[8, 1] = "Tianjin";
			array14[9, 0] = "Shandong";
			array14[9, 1] = "Jinan";
			array14[10, 0] = "Henan";
			array14[10, 1] = "Zhengzhou";
			array14[11, 0] = "Heilongjiang";
			array14[11, 1] = "Harbin";
			array14[12, 0] = "Jilin";
			array14[12, 1] = "Changchun";
			array14[13, 0] = "Liaoning";
			array14[13, 1] = "Dalian";
			array14[14, 0] = "Tibet";
			array14[14, 1] = "Lhasa";
			array14[15, 0] = "Yunnan";
			array14[15, 1] = "Kunming";
			array14[16, 0] = "Guizhou";
			array14[16, 1] = "Guiyang";
			array14[17, 0] = "Guangxi";
			array14[17, 1] = "Yulin";
			array14[18, 0] = "Sichuan";
			array14[18, 1] = "Chengdu";
			array14[19, 0] = "Chongqing Municipality";
			array14[19, 1] = "Wanzhou";
			array14[20, 0] = "Hubei";
			array14[20, 1] = "Wuhan";
			array14[21, 0] = "Hunan";
			array14[21, 1] = "Changsha";
			array14[22, 0] = "Jiangxi";
			array14[22, 1] = "Nanchang";
			array14[23, 0] = "Anhui";
			array14[23, 1] = "Hefei";
			array14[24, 0] = "Jiangsu";
			array14[24, 1] = "Nanjing";
			array14[25, 0] = "Zhejiang";
			array14[25, 1] = "Hangzhou";
			array14[26, 0] = "Fujian";
			array14[26, 1] = "Fuzhou";
			array14[27, 0] = "Guangdong";
			array14[27, 1] = "Guangzhou";
			array14[28, 0] = "Hainan";
			array14[28, 1] = "Haikou";
			array14[29, 0] = "Pyongan-bukto";
			array14[29, 1] = "Sinuiju";
			array14[30, 0] = "Chagang-do";
			array14[30, 1] = "Kanggye";
			array14[31, 0] = "Yanggang-do";
			array14[31, 1] = "Hyesan";
			array14[32, 0] = "Hamgyong-bukto";
			array14[32, 1] = "Chongjin";
			array14[33, 0] = "Hamgyong-namdo";
			array14[33, 1] = "Sinpo";
			array14[34, 0] = "Pyongan-namdo";
			array14[34, 1] = "Pyongsong";
			array14[35, 0] = "Hwanghae-namdo";
			array14[35, 1] = "Haeju";
			array14[36, 0] = "Hwanghe-bukto";
			array14[36, 1] = "Sariwon";
			array14[37, 0] = "Kangwon-do";
			array14[37, 1] = "Wonsan";
			array14[38, 0] = "Gyeonggi";
			array14[38, 1] = "Incheon";
			array14[39, 0] = "Gangwon";
			array14[39, 1] = "Chuncheon";
			array14[40, 0] = "South Chungcheong";
			array14[40, 1] = "Hongseong";
			array14[41, 0] = "North Chungcheong";
			array14[41, 1] = "Cheongju";
			array14[42, 0] = "North Gyeongsang";
			array14[42, 1] = "Daegu";
			array14[43, 0] = "North Jeolla";
			array14[43, 1] = "Jeonju";
			array14[44, 0] = "South Gyeongsang";
			array14[44, 1] = "Changwon";
			array14[45, 0] = "South Jeolla";
			array14[45, 1] = "Gwangju";
			array14[46, 0] = "Kyushu";
			array14[46, 1] = "Fukuoka";
			array14[47, 0] = "Chugoku";
			array14[47, 1] = "Hiroshima";
			array14[48, 0] = "Shikoku";
			array14[48, 1] = "Matsuyama";
			array14[49, 0] = "Kansai";
			array14[49, 1] = "Kobe";
			array14[50, 0] = "Chubu";
			array14[50, 1] = "Nagoya";
			array14[51, 0] = "Kanto";
			array14[51, 1] = "Chiba";
			array14[52, 0] = "Tohoku";
			array14[52, 1] = "Sendai";
			array14[53, 0] = "Hokkaido";
			array14[53, 1] = "Sapporo";
			array14[54, 0] = "Bayan-Olgii";
			array14[54, 1] = "Olgii";
			array14[55, 0] = "Uvs";
			array14[55, 1] = "Ulaangom";
			array14[56, 0] = "Khovd";
			array14[56, 1] = "Khovd";
			array14[57, 0] = "Zavkhan";
			array14[57, 1] = "Uliastai";
			array14[58, 0] = "Govi-Altai";
			array14[58, 1] = "Altai";
			array14[59, 0] = "Bayankhongor";
			array14[59, 1] = "Bayankhongor";
			array14[60, 0] = "Arkhangai";
			array14[60, 1] = "Tsetserleg";
			array14[61, 0] = "Khovsgol";
			array14[61, 1] = "Tarialan";
			array14[62, 0] = "Bulgan";
			array14[62, 1] = "Bulgan";
			array14[63, 0] = "Ovorkhangai";
			array14[63, 1] = "Arvaikheer";
			array14[64, 0] = "Omnogovi";
			array14[64, 1] = "Dalanzadgad";
			array14[65, 0] = "Dundgovi";
			array14[65, 1] = "Mandalgovi";
			array14[66, 0] = "Tov";
			array14[66, 1] = "Zuunmod";
			array14[67, 0] = "Selenge";
			array14[67, 1] = "Sukhbaatar";
			array14[68, 0] = "Khentii";
			array14[68, 1] = "Ondorkhaan";
			array14[69, 0] = "Dornogovi";
			array14[69, 1] = "Sainshand";
			array14[70, 0] = "Sukhbaatar";
			array14[70, 1] = "Baruun-Urt";
			array14[71, 0] = "Dornod";
			array14[71, 1] = "Choibalsan";
			array14[72, 0] = "Taichung City";
			array14[72, 1] = "Taichung City";
			this.china_county_Korean = array14;
			string[,] array15 = new string[73, 2];
			array15[0, 0] = "Xinjiang";
			array15[0, 1] = "Urumqi";
			array15[1, 0] = "Qinghai";
			array15[1, 1] = "Xining";
			array15[2, 0] = "Gansu";
			array15[2, 1] = "Lanzhou";
			array15[3, 0] = "Ningxia";
			array15[3, 1] = "Yinchuan";
			array15[4, 0] = "Shaanxi";
			array15[4, 1] = "Weinan";
			array15[5, 0] = "Inner Mongolia";
			array15[5, 1] = "Hohhot";
			array15[6, 0] = "Shanxi";
			array15[6, 1] = "Taiyuan";
			array15[7, 0] = "Hebei";
			array15[7, 1] = "Baoding";
			array15[8, 0] = "Capital District";
			array15[8, 1] = "Tianjin";
			array15[9, 0] = "Shandong";
			array15[9, 1] = "Jinan";
			array15[10, 0] = "Henan";
			array15[10, 1] = "Zhengzhou";
			array15[11, 0] = "Heilongjiang";
			array15[11, 1] = "Harbin";
			array15[12, 0] = "Jilin";
			array15[12, 1] = "Changchun";
			array15[13, 0] = "Liaoning";
			array15[13, 1] = "Dalian";
			array15[14, 0] = "Tibet";
			array15[14, 1] = "Lhasa";
			array15[15, 0] = "Yunnan";
			array15[15, 1] = "Kunming";
			array15[16, 0] = "Guizhou";
			array15[16, 1] = "Guiyang";
			array15[17, 0] = "Guangxi";
			array15[17, 1] = "Yulin";
			array15[18, 0] = "Sichuan";
			array15[18, 1] = "Chengdu";
			array15[19, 0] = "Chongqing Municipality";
			array15[19, 1] = "Wanzhou";
			array15[20, 0] = "Hubei";
			array15[20, 1] = "Wuhan";
			array15[21, 0] = "Hunan";
			array15[21, 1] = "Changsha";
			array15[22, 0] = "Jiangxi";
			array15[22, 1] = "Nanchang";
			array15[23, 0] = "Anhui";
			array15[23, 1] = "Hefei";
			array15[24, 0] = "Jiangsu";
			array15[24, 1] = "Nanjing";
			array15[25, 0] = "Zhejiang";
			array15[25, 1] = "Hangzhou";
			array15[26, 0] = "Fujian";
			array15[26, 1] = "Fuzhou";
			array15[27, 0] = "Guangdong";
			array15[27, 1] = "Guangzhou";
			array15[28, 0] = "Hainan";
			array15[28, 1] = "Haikou";
			array15[29, 0] = "Pyongan-bukto";
			array15[29, 1] = "Sinuiju";
			array15[30, 0] = "Chagang-do";
			array15[30, 1] = "Kanggye";
			array15[31, 0] = "Yanggang-do";
			array15[31, 1] = "Hyesan";
			array15[32, 0] = "Hamgyong-bukto";
			array15[32, 1] = "Chongjin";
			array15[33, 0] = "Hamgyong-namdo";
			array15[33, 1] = "Sinpo";
			array15[34, 0] = "Pyongan-namdo";
			array15[34, 1] = "Pyongsong";
			array15[35, 0] = "Hwanghae-namdo";
			array15[35, 1] = "Haeju";
			array15[36, 0] = "Hwanghe-bukto";
			array15[36, 1] = "Sariwon";
			array15[37, 0] = "Kangwon-do";
			array15[37, 1] = "Wonsan";
			array15[38, 0] = "Gyeonggi";
			array15[38, 1] = "Incheon";
			array15[39, 0] = "Gangwon";
			array15[39, 1] = "Chuncheon";
			array15[40, 0] = "South Chungcheong";
			array15[40, 1] = "Hongseong";
			array15[41, 0] = "North Chungcheong";
			array15[41, 1] = "Cheongju";
			array15[42, 0] = "North Gyeongsang";
			array15[42, 1] = "Daegu";
			array15[43, 0] = "North Jeolla";
			array15[43, 1] = "Jeonju";
			array15[44, 0] = "South Gyeongsang";
			array15[44, 1] = "Changwon";
			array15[45, 0] = "South Jeolla";
			array15[45, 1] = "Gwangju";
			array15[46, 0] = "Kyushu";
			array15[46, 1] = "Fukuoka";
			array15[47, 0] = "Chugoku";
			array15[47, 1] = "Hiroshima";
			array15[48, 0] = "Shikoku";
			array15[48, 1] = "Matsuyama";
			array15[49, 0] = "Kansai";
			array15[49, 1] = "Kobe";
			array15[50, 0] = "Chubu";
			array15[50, 1] = "Nagoya";
			array15[51, 0] = "Kanto";
			array15[51, 1] = "Chiba";
			array15[52, 0] = "Tohoku";
			array15[52, 1] = "Sendai";
			array15[53, 0] = "Hokkaido";
			array15[53, 1] = "Sapporo";
			array15[54, 0] = "Bayan-Olgii";
			array15[54, 1] = "Olgii";
			array15[55, 0] = "Uvs";
			array15[55, 1] = "Ulaangom";
			array15[56, 0] = "Khovd";
			array15[56, 1] = "Khovd";
			array15[57, 0] = "Zavkhan";
			array15[57, 1] = "Uliastai";
			array15[58, 0] = "Govi-Altai";
			array15[58, 1] = "Altai";
			array15[59, 0] = "Bayankhongor";
			array15[59, 1] = "Bayankhongor";
			array15[60, 0] = "Arkhangai";
			array15[60, 1] = "Tsetserleg";
			array15[61, 0] = "Khovsgol";
			array15[61, 1] = "Tarialan";
			array15[62, 0] = "Bulgan";
			array15[62, 1] = "Bulgan";
			array15[63, 0] = "Ovorkhangai";
			array15[63, 1] = "Arvaikheer";
			array15[64, 0] = "Omnogovi";
			array15[64, 1] = "Dalanzadgad";
			array15[65, 0] = "Dundgovi";
			array15[65, 1] = "Mandalgovi";
			array15[66, 0] = "Tov";
			array15[66, 1] = "Zuunmod";
			array15[67, 0] = "Selenge";
			array15[67, 1] = "Sukhbaatar";
			array15[68, 0] = "Khentii";
			array15[68, 1] = "Ondorkhaan";
			array15[69, 0] = "Dornogovi";
			array15[69, 1] = "Sainshand";
			array15[70, 0] = "Sukhbaatar";
			array15[70, 1] = "Baruun-Urt";
			array15[71, 0] = "Dornod";
			array15[71, 1] = "Choibalsan";
			array15[72, 0] = "Taichung City";
			array15[72, 1] = "Taichung City";
			this.china_county_Japanese = array15;

		}

		// Token: 0x04003CE1 RID: 15585
		private const double ARMY_UPDATE_ZOOM_THRESHOLD = 15.0;

		// Token: 0x04003CE2 RID: 15586
		private const double ARMY_DRAW_ZOOM_THRESHOLD = 5.5;

		// Token: 0x04003CE3 RID: 15587
		private const double ARMY_ARROW_ZOOM_THRESHOLD = 10.0;

		// Token: 0x04003CE4 RID: 15588
		private const int NUMLEVELS = 5;

		// Token: 0x04003CE5 RID: 15589
		public const int downloadSteps = 4;

		// Token: 0x04003CE6 RID: 15590
		private const int SAVEDATA_VERSION_ID = 10;

		// Token: 0x04003CE7 RID: 15591
		public const int ZOOM_MAX_VAL = 27;

		// Token: 0x04003CE8 RID: 15592
		private const int ZOOM_CENTRE_VAL = 23;

		// Token: 0x04003CE9 RID: 15593
		public const double ZOOM_MIN_VAL_RETINA = 0.0;

		// Token: 0x04003CEA RID: 15594
		public const double ZOOM_MIN_VAL_NORMAL = 0.0;

		// Token: 0x04003CEB RID: 15595
		private const int SHIELD_CACHE_SIZE = 125;

		// Token: 0x04003CEC RID: 15596
		public const int ZOOM_MAX_VAL_CHANGE = 7;

		// Token: 0x04003CED RID: 15597
		public const float WORLD_SCALE_OLD_MAX = 17f;

		// Token: 0x04003CEE RID: 15598
		public const float WORLD_SCALE_MAX = 24f;

		// Token: 0x04003CEF RID: 15599
		public const float WORLD_SCALE_MAX_CLOSE = 23.9f;

		// Token: 0x04003CF0 RID: 15600
		public const double REGION_DRAW_ZOOM_LEVEL = 5.0;

		// Token: 0x04003CF1 RID: 15601
		public const double REGION_BORDER_DRAW_ZOOM_LEVEL = 5.0;

		// Token: 0x04003CF2 RID: 15602
		private const double ZOOM_TIME = 16.0;

		// Token: 0x04003CF3 RID: 15603
		private const int NUM_VILLAGE_SPRITEWRAPPERS = 1;

		// Token: 0x04003CF4 RID: 15604
		private const int READ_AROUND_RANGE = 50;

		// Token: 0x04003CF5 RID: 15605
		public static bool USE_QUADTREE = false;

		// Token: 0x04003CF6 RID: 15606
		public static bool LOG_ARMY_ERRORS = false;

		// Token: 0x04003CF7 RID: 15607
		public bool UpdatingArmies;

		// Token: 0x04003CF8 RID: 15608
		public bool DrawingArmies;

		// Token: 0x04003CF9 RID: 15609
		public bool DrawingArmyArrows = true;

		// Token: 0x04003CFA RID: 15610
		public long tutorialArmyID = -1L;

		// Token: 0x04003CFB RID: 15611
		public List<WorldMap.ArmyRetrieveData> requestedReturnedArmyIDs = new List<WorldMap.ArmyRetrieveData>();

		// Token: 0x04003CFC RID: 15612
		private SparseArray armyArray = new SparseArray();

		// Token: 0x04003CFD RID: 15613
		private SparseArray reinforcementArray = new SparseArray();

		// Token: 0x04003CFE RID: 15614
		private long highestArmySeen = -1L;

		// Token: 0x04003CFF RID: 15615
		private long highestDownloadedArmy = -1L;

		// Token: 0x04003D00 RID: 15616
		public bool doSelectTutorialArmy;

		// Token: 0x04003D01 RID: 15617
		private List<long> rememberedExistingArmies = new List<long>();

		// Token: 0x04003D02 RID: 15618
		private int a_startAt;

		// Token: 0x04003D03 RID: 15619
		private int a_endAt;

		// Token: 0x04003D04 RID: 15620
		private int a_perFrame = 100;

		// Token: 0x04003D05 RID: 15621
		public List<long> thisVillageArmies = new List<long>();

		// Token: 0x04003D06 RID: 15622
		private SparseArray scoutsForaging = new SparseArray();

		// Token: 0x04003D07 RID: 15623
		private SparseArray scoutsVillageForaging = new SparseArray();

		// Token: 0x04003D08 RID: 15624
		private SparseArray attackingArmies = new SparseArray();

		// Token: 0x04003D09 RID: 15625
		private SparseArray villagesInvolvedInAttacks = new SparseArray();

		// Token: 0x04003D0A RID: 15626
		private SparseArray villagesInvolvedInAIAttacks = new SparseArray();

		// Token: 0x04003D0B RID: 15627
		private int alphaPulse;

		// Token: 0x04003D0C RID: 15628
		private int alphaValue;

		// Token: 0x04003D0D RID: 15629
		private SparseArray armyIconsFilter = new SparseArray();

		// Token: 0x04003D0E RID: 15630
		private DateTime wolfsRevengeStart = DateTime.MinValue;

		// Token: 0x04003D0F RID: 15631
		private DateTime wolfsRevengeEnd = DateTime.MinValue;

		// Token: 0x04003D10 RID: 15632
		private SparseArray invasionMarkerState = new SparseArray();

		// Token: 0x04003D11 RID: 15633
		private List<AIWorldInvasionData> invasionInfo;

		// Token: 0x04003D12 RID: 15634
		private DateTime lastInvasionInfoTime = DateTime.MinValue;

		// Token: 0x04003D13 RID: 15635
		private DateTime lastUpdateInvasionInfoTime = DateTime.MinValue;

		// Token: 0x04003D14 RID: 15636
		public int aiWorldGloryWinLevel = 1000;

		// Token: 0x04003D15 RID: 15637
		public WorldMap.FWData[] fwDataList = new WorldMap.FWData[25];

		// Token: 0x04003D16 RID: 15638
		public int[] fwChickenOrder = new int[3];

		// Token: 0x04003D17 RID: 15639
		public int[] fwSheepOrder = new int[3];

		// Token: 0x04003D18 RID: 15640
		public int[] fwJesterOrder = new int[3];

		// Token: 0x04003D19 RID: 15641
		public int[] fwPigOrder = new int[3];

		// Token: 0x04003D1A RID: 15642
		private string fwSourceData = "3,10,30,60,30,10,5,8,12,5,2,6,0,0,0,9,0,0,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,7,1,0,0,1,1,0,1,0,1000,0.1,0.1,0.5,0.01,0,21,5,1,0,0,1,1,0,1,0,600,0.06,0.3,0.3,0,0,1,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,1,1,10,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,19,25,0,1,7,1,1,0,1,1000,2500,0.1,0.3,0.3,0,0,0,50,0,1,40,1,0.1,0.05,0.6,0,300,0.06,0.3,0.3,0,0.3,0,8,1,0,0,1,1,0,1,0,300,0.05,0.3,0.3,0,0,14,20,1,0,0,1,1,0,1,100,300,0.06,0.4,0.3,0,0,0,205,1,1,10,1,0,0,1,500,2000,0.06,0.3,0.3,0,0.3,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,5,1,1,20,1,1,0,1,0,3000,0.6,0.3,0.5,0,0.3,7,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,20,0,1,10,1,0.25,0.03,0.5,0,300,0.06,0.1,0.3,0,0,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,50,1,1,100,1,0.2,0.05,0.6,1000,3000,0.06,0.1,0.1,0,0,0,20,1,1,5,0,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,1,4,1,1,0.01,0.1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,1,30,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,0,0,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,25,0,1,5,0,0.3,0.01,0.5,0,600,0.06,0.3,73,0.1,0.6,0,25,1,1,2,1,1,0,1,0,300,0.06,0.3,0.3,0,0.3,0,";

		// Token: 0x04003D1B RID: 15643
		private int[] fwSpriteIDs = new int[]
		{
			-1,
			1,
			4,
			6,
			24,
			8,
			13,
			27,
			22,
			12,
			18,
			0,
			10,
			7,
			26,
			14,
			19,
			25,
			21,
			20,
			3,
			17,
			23,
			2,
			5
		};

		// Token: 0x04003D1C RID: 15644
		private List<WorldMap.ClusterBase> clusters = new List<WorldMap.ClusterBase>();

		// Token: 0x04003D1D RID: 15645
		public int fwMode;

		// Token: 0x04003D1E RID: 15646
		public int fwTick;

		// Token: 0x04003D1F RID: 15647
		public int totalNumFW = 3;

		// Token: 0x04003D20 RID: 15648
		public int totalNumFWBusy = 6;

		// Token: 0x04003D21 RID: 15649
		public int totalNumFWCrazy = 10;

		// Token: 0x04003D22 RID: 15650
		public int fwNormalChance = 80;

		// Token: 0x04003D23 RID: 15651
		public int fwBusyChance = 15;

		// Token: 0x04003D24 RID: 15652
		public int fwCrazyChance = 5;

		// Token: 0x04003D25 RID: 15653
		public int fwCycle = 5;

		// Token: 0x04003D26 RID: 15654
		private int fwUnique;

		// Token: 0x04003D27 RID: 15655
		private float fwDisplayClock;

		// Token: 0x04003D28 RID: 15656
		private List<WorldMap.UserVillageData> m_userVillages;

		// Token: 0x04003D29 RID: 15657
		private List<WorldMap.UserVillageData> m_userRelatedVillages = new List<WorldMap.UserVillageData>();

		// Token: 0x04003D2A RID: 15658
		private double m_userGoldLevel;

		// Token: 0x04003D2B RID: 15659
		private double m_userGoldIncomeRate;

		// Token: 0x04003D2C RID: 15660
		private double m_lastGoldUpdate;

		// Token: 0x04003D2D RID: 15661
		private double m_userHonourLevel;

		// Token: 0x04003D2E RID: 15662
		private double m_userHonourIncomeRate;

		// Token: 0x04003D2F RID: 15663
		private double m_lastHonourUpdate;

		// Token: 0x04003D30 RID: 15664
		private double m_userFaithPointsLevel;

		// Token: 0x04003D31 RID: 15665
		private double m_userFaithPointsRate;

		// Token: 0x04003D32 RID: 15666
		private double m_lastFaithPointsUpdate;

		// Token: 0x04003D33 RID: 15667
		private int m_userPoints;

		// Token: 0x04003D34 RID: 15668
		private int m_numMadeCaptains;

		// Token: 0x04003D35 RID: 15669
		private int m_userRank;

		// Token: 0x04003D36 RID: 15670
		private int m_userRankSubLevel;

		// Token: 0x04003D37 RID: 15671
		private int m_mostAge4Villages;

		// Token: 0x04003D38 RID: 15672
		private bool retrievingUserVillages;

		// Token: 0x04003D39 RID: 15673
		public DateTime m_worldStartDate = DateTime.Now;

		// Token: 0x04003D3A RID: 15674
		private WorldMap.VillageNameComparer villageNameComparer = new WorldMap.VillageNameComparer();

		// Token: 0x04003D3B RID: 15675
		public ResearchData userResearchData;

		// Token: 0x04003D3C RID: 15676
		private bool requestSent;

		// Token: 0x04003D3D RID: 15677
		private DateTime m_lastResearchCompleteTimeMatch = DateTime.MinValue;

		// Token: 0x04003D3E RID: 15678
		private DateTime m_lastResearchCompleteRequestTime = DateTime.MinValue;

		// Token: 0x04003D3F RID: 15679
		private int m_researchLagCount;

		// Token: 0x04003D40 RID: 15680
		private WorldMap.ResearchChangedDelegate uiResearchDelegate;

		// Token: 0x04003D41 RID: 15681
		private DateTime lastDoResearchClick = DateTime.MinValue;

		// Token: 0x04003D42 RID: 15682
		private bool inDoResearch;

		// Token: 0x04003D43 RID: 15683
		private DateTime lastBuyPointClick = DateTime.MinValue;

		// Token: 0x04003D44 RID: 15684
		private bool inBuyPoint;

		// Token: 0x04003D45 RID: 15685
		private CustomSelfDrawPanel.CSDControl.CSD_ClickDelegate onResearchPointPurchaseDelegate;

		// Token: 0x04003D46 RID: 15686
		private bool newTutorialAvailable;

		// Token: 0x04003D47 RID: 15687
		private QuestsAndTutorialInfo m_tutorialInfo = new QuestsAndTutorialInfo();

		// Token: 0x04003D48 RID: 15688
		private List<int> tutorialQuestsObjectivesComplete = new List<int>();

		// Token: 0x04003D49 RID: 15689
		private bool inTutorialAdvance;

		// Token: 0x04003D4A RID: 15690
		private int targetTutorialStage;

		// Token: 0x04003D4B RID: 15691
		private SparseArray QuestObjectivesSent = new SparseArray();

		// Token: 0x04003D4C RID: 15692
		private int numVacationsAvailable = 2;

		// Token: 0x04003D4D RID: 15693
		private bool vacationNot30Days;

		// Token: 0x04003D4E RID: 15694
		private SparseArray personArray = new SparseArray();

		// Token: 0x04003D4F RID: 15695
		private List<CounterSpyInfo> counterSpyInfo = new List<CounterSpyInfo>();

		// Token: 0x04003D50 RID: 15696
		private DateTime lastPersonTime = DateTime.Now.AddYears(-5);

		// Token: 0x04003D51 RID: 15697
		private int p_startAt;

		// Token: 0x04003D52 RID: 15698
		private int p_endAt;

		// Token: 0x04003D53 RID: 15699
		private int p_perFrame = 100;

		// Token: 0x04003D54 RID: 15700
		public bool isBigpointAccount;

		// Token: 0x04003D55 RID: 15701
		public int ProfileCardpoints;

		// Token: 0x04003D56 RID: 15702
		public int ProfileCrowns;

		// Token: 0x04003D57 RID: 15703
		public int FakeCardPoints;

		// Token: 0x04003D58 RID: 15704
		public int ProfileNumFriends;

		// Token: 0x04003D59 RID: 15705
		public DateTime LastUpdatedCrowns = DateTime.Now.AddHours(-1.0);

		// Token: 0x04003D5A RID: 15706
		private FreeCardsData freeCardInfo = new FreeCardsData();

		// Token: 0x04003D5B RID: 15707
		private bool inviteSystemNotImplemented = true;

		// Token: 0x04003D5C RID: 15708
		private bool mapEditing;

		// Token: 0x04003D5D RID: 15709
		private string mapDataFilename = string.Empty;

		// Token: 0x04003D5E RID: 15710
		private bool worldEnded;

		// Token: 0x04003D5F RID: 15711
		private bool worldEnded_message;

		// Token: 0x04003D60 RID: 15712
		private int currentMapType;

		// Token: 0x04003D61 RID: 15713
		private int yMarkerOffset;

		// Token: 0x04003D62 RID: 15714
		private bool smallMapFont;

		// Token: 0x04003D63 RID: 15715
		public bool EUMap;

		// Token: 0x04003D64 RID: 15716
		public bool GSMap;

		// Token: 0x04003D65 RID: 15717
		public bool chMap;

		// Token: 0x04003D66 RID: 15718
		public bool KGMap;

		// Token: 0x04003D67 RID: 15719
		public bool aiWorldTreeBuilding;

		// Token: 0x04003D68 RID: 15720
		public List<int> aiWorldSpecialVillages = new List<int>();

		// Token: 0x04003D69 RID: 15721
		private bool m_cachesFlushed;

		// Token: 0x04003D6A RID: 15722
		private bool m_dataLoaded;

		// Token: 0x04003D6B RID: 15723
		private bool m_namesLoaded;

		// Token: 0x04003D6C RID: 15724
		private bool m_downloadedDataSafely = true;

		// Token: 0x04003D6D RID: 15725
		private Thread m_WorkerThread;

		// Token: 0x04003D6E RID: 15726
		private bool downloadComplete;

		// Token: 0x04003D6F RID: 15727
		private bool downloadFullyComplete;

		// Token: 0x04003D70 RID: 15728
		public bool delayedFactionSave;

		// Token: 0x04003D71 RID: 15729
		public int downloadingCounter;

		// Token: 0x04003D72 RID: 15730
		private bool loadingErrored;

		// Token: 0x04003D73 RID: 15731
		private int threadDelaySize = 50;

		// Token: 0x04003D74 RID: 15732
		private FactionData inactiveFaction = new FactionData();

		// Token: 0x04003D75 RID: 15733
		private static bool fullTickFullMode = true;

		// Token: 0x04003D76 RID: 15734
		public DateTime lastFullTickCall = DateTime.MinValue;

		// Token: 0x04003D77 RID: 15735
		public static int TreasureCastle_AttackGap = 86400;

		// Token: 0x04003D78 RID: 15736
		private SparseArray m_parishChatLog = new SparseArray();

		// Token: 0x04003D79 RID: 15737
		private WorldMap.ParishChatComparer parishChatComparer = new WorldMap.ParishChatComparer();

		// Token: 0x04003D7A RID: 15738
		private SparseArray m_parishWallDonateDetails = new SparseArray();

		// Token: 0x04003D7B RID: 15739
		private bool inTestAchievements;

		// Token: 0x04003D7C RID: 15740
		private DateTime lastTestAchievements = DateTime.MinValue;

		// Token: 0x04003D7D RID: 15741
		public bool FacebookFreePack;

		// Token: 0x04003D7E RID: 15742
		private SparseArray traderArray = new SparseArray();

		// Token: 0x04003D7F RID: 15743
		private DateTime lastTraderTime = DateTime.Now.AddYears(-5);

		// Token: 0x04003D80 RID: 15744
		private List<WorldMap.LocalTrader> thisVillageTraders;

		// Token: 0x04003D81 RID: 15745
		private int t_startAt;

		// Token: 0x04003D82 RID: 15746
		private int t_endAt;

		// Token: 0x04003D83 RID: 15747
		private int t_perFrame = 100;

		// Token: 0x04003D84 RID: 15748
		public List<int> tradingVillageList = new List<int>();

		// Token: 0x04003D85 RID: 15749
		public List<int> marketTradingVillageList = new List<int>();

		// Token: 0x04003D86 RID: 15750
		public int worldMapWidth;

		// Token: 0x04003D87 RID: 15751
		public int worldMapHeight;

		// Token: 0x04003D88 RID: 15752
		public int villageMapWidth;

		// Token: 0x04003D89 RID: 15753
		public int villageMapHeight;

		// Token: 0x04003D8A RID: 15754
		private long storedVillageFactionsPos = -1L;

		// Token: 0x04003D8B RID: 15755
		private long storedRegionFactionsPos = -1L;

		// Token: 0x04003D8C RID: 15756
		private long storedCountyFactionsPos = -1L;

		// Token: 0x04003D8D RID: 15757
		private long storedProvinceFactionsPos = -1L;

		// Token: 0x04003D8E RID: 15758
		private long storedCountryFactionsPos = -1L;

		// Token: 0x04003D8F RID: 15759
		private long storedParishFlagsPos = -1L;

		// Token: 0x04003D90 RID: 15760
		private long storedCountyFlagsPos = -1L;

		// Token: 0x04003D91 RID: 15761
		private long storedProvinceFlagsPos = -1L;

		// Token: 0x04003D92 RID: 15762
		private long storedCountryFlagsPos = -1L;

		// Token: 0x04003D93 RID: 15763
		private long storedFactionChangesPos = -1L;

		// Token: 0x04003D94 RID: 15764
		private long storedVillageNamePos = -1L;

		// Token: 0x04003D95 RID: 15765
		private WorldMap.WorldPoint[] pointList;

		// Token: 0x04003D96 RID: 15766
		private WorldMap.WorldPointList[] countryList;

		// Token: 0x04003D97 RID: 15767
		private WorldMap.WorldPointList[] provincesList;

		// Token: 0x04003D98 RID: 15768
		private WorldMap.WorldPointList[] countyList;

		// Token: 0x04003D99 RID: 15769
		private VillageData[] villageList;

		// Token: 0x04003D9A RID: 15770
		private WorldMap.WorldPointList[] regionList;

		// Token: 0x04003D9B RID: 15771
		private WorldMap.WorldPointList[] seaList;

		// Token: 0x04003D9C RID: 15772
		private WorldMap.IslandInfoList[] islandList;

		// Token: 0x04003D9D RID: 15773
		private List<WorldMap.IslandInfoList> aiWorldInvasionLineList;

		// Token: 0x04003D9E RID: 15774
		public bool drawFakeProvinceBorders;

		// Token: 0x04003D9F RID: 15775
		private HouseData[] m_houseData;

		// Token: 0x04003DA0 RID: 15776
		private HouseVoteData m_houseVoteData;

		// Token: 0x04003DA1 RID: 15777
		private SparseArray m_factionData = new SparseArray();

		// Token: 0x04003DA2 RID: 15778
		private FactionMemberData[] m_factionMembers;

		// Token: 0x04003DA3 RID: 15779
		private FactionInviteData[] m_factionInvites;

		// Token: 0x04003DA4 RID: 15780
		private List<FactionInviteData> m_factionApplications;

		// Token: 0x04003DA5 RID: 15781
		private int m_factionLeaderVote = -1;

		// Token: 0x04003DA6 RID: 15782
		private int[] m_factionAllies;

		// Token: 0x04003DA7 RID: 15783
		private int[] m_factionEnemies;

		// Token: 0x04003DA8 RID: 15784
		private int[] m_houseAllies;

		// Token: 0x04003DA9 RID: 15785
		private int[] m_houseEnemies;

		// Token: 0x04003DAA RID: 15786
		private int[] m_gloryPoints;

		// Token: 0x04003DAB RID: 15787
		private GloryRoundData m_gloryRoundData;

		// Token: 0x04003DAC RID: 15788
		private DateTime lastHouseGloryPointsUpdate = DateTime.MinValue;

		// Token: 0x04003DAD RID: 15789
		private bool secondAgeWorld;

		// Token: 0x04003DAE RID: 15790
		private bool thirdAgeWorld;

		// Token: 0x04003DAF RID: 15791
		private bool fourthAgeWorld;

		// Token: 0x04003DB0 RID: 15792
		private bool fifthAgeWorld;

		// Token: 0x04003DB1 RID: 15793
		private bool sixthAgeWorld;

		// Token: 0x04003DB2 RID: 15794
		private bool seventhAgeWorld;

		// Token: 0x04003DB3 RID: 15795
		private int m_globalWorldID = -1;

		// Token: 0x04003DB4 RID: 15796
		private DateTime lastTimeOwnMembersUpdated = DateTime.MinValue;

		// Token: 0x04003DB5 RID: 15797
		private SparseArray cachedFactionMemberData = new SparseArray();

		// Token: 0x04003DB6 RID: 15798
		private SparseArray cachedUserInfo = new SparseArray();

		// Token: 0x04003DB7 RID: 15799
		private WorldMap.VillageQuadNode m_baseNode;

		// Token: 0x04003DB8 RID: 15800
		private GraphicsMgr gfx;

		// Token: 0x04003DB9 RID: 15801
		private double m_worldZoomInverted;

		// Token: 0x04003DBA RID: 15802
		private double m_worldScale = 1.0;

		// Token: 0x04003DBB RID: 15803
		private double m_screenCentreX;

		// Token: 0x04003DBC RID: 15804
		private double m_screenCentreY;

		// Token: 0x04003DBD RID: 15805
		public int m_screenWidth;

		// Token: 0x04003DBE RID: 15806
		public int m_screenHeight;

		// Token: 0x04003DBF RID: 15807
		private MapIconDrawCall mapIcon;

		// Token: 0x04003DC0 RID: 15808
		public static int mapIconDrawCount = 0;

		// Token: 0x04003DC1 RID: 15809
		private int seaConditionsDay = -1;

		// Token: 0x04003DC2 RID: 15810
		private int seaConditionsEarly = -1;

		// Token: 0x04003DC3 RID: 15811
		private int seaConditionsLate = -1;

		// Token: 0x04003DC4 RID: 15812
		private int lastRetieveUserID = -1;

		// Token: 0x04003DC5 RID: 15813
		private int lastRetieveVillageID = -1;

		// Token: 0x04003DC6 RID: 15814
		private bool lastForceExtended;

		// Token: 0x04003DC7 RID: 15815
		private DateTime lastRetieveUserTime = DateTime.MinValue;

		// Token: 0x04003DC8 RID: 15816
		private DateTime lastRetieveVillageTime = DateTime.MinValue;

		// Token: 0x04003DC9 RID: 15817
		private int cached_retrieveVillageID = -1;

		// Token: 0x04003DCA RID: 15818
		private int cached_retrieveUserID = -1;

		// Token: 0x04003DCB RID: 15819
		private DateTime cached_retrieveVillageUserInfoDate = DateTime.MinValue;

		// Token: 0x04003DCC RID: 15820
		private SparseArray specialVillageCache = new SparseArray();

		// Token: 0x04003DCD RID: 15821
		private int lastSpecialRequestSent = -1;

		// Token: 0x04003DCE RID: 15822
		private int lastActualSpecialRequestSent = -1;

		// Token: 0x04003DCF RID: 15823
		private DateTime lastActualSpecialRequestTime = DateTime.MinValue;

		// Token: 0x04003DD0 RID: 15824
		private List<LoginHistoryInfo> loginHistory;

		// Token: 0x04003DD1 RID: 15825
		private ShieldFactory playerShieldFactory;

		// Token: 0x04003DD2 RID: 15826
		private Shield playerShield;

		// Token: 0x04003DD3 RID: 15827
		private SparseArray worldShields = new SparseArray();

		// Token: 0x04003DD4 RID: 15828
		private ShieldFactory.AsyncDelegate playerShieldCallback;

		// Token: 0x04003DD5 RID: 15829
		private int activeShieldsWorldID = -1;

		// Token: 0x04003DD6 RID: 15830
		private bool worldShieldsAvailable;

		// Token: 0x04003DD7 RID: 15831
		private List<WorldMap.ShieldTextureCacheEntry> worldShieldCache = new List<WorldMap.ShieldTextureCacheEntry>();

		// Token: 0x04003DD8 RID: 15832
		private SparseArray worldShieldCachePlayerIDs = new SparseArray();

		// Token: 0x04003DD9 RID: 15833
		private Shield ratShield = new Shield(constants.RAT_SHIELD);

		// Token: 0x04003DDA RID: 15834
		private Shield snakeShield = new Shield(constants.SNAKE_SHIELD);

		// Token: 0x04003DDB RID: 15835
		private Shield wolfShield = new Shield(constants.WOLF_SHIELD);

		// Token: 0x04003DDC RID: 15836
		private Shield pigShield = new Shield(constants.PIG_SHIELD);

		// Token: 0x04003DDD RID: 15837
		private List<UserRelationship> userRelations = new List<UserRelationship>();

		// Token: 0x04003DDE RID: 15838
		private List<UserMarker> userMarkers = new List<UserMarker>();

		// Token: 0x04003DDF RID: 15839
		private DateTime m_lastTreasureCastleAttackTime = DateTime.MinValue;

		// Token: 0x04003DE0 RID: 15840
		private int m_treasure1Tickets;

		// Token: 0x04003DE1 RID: 15841
		private int m_treasure2Tickets;

		// Token: 0x04003DE2 RID: 15842
		private int m_treasure3Tickets;

		// Token: 0x04003DE3 RID: 15843
		private int m_treasure4Tickets;

		// Token: 0x04003DE4 RID: 15844
		private int m_treasure5Tickets;

		// Token: 0x04003DE5 RID: 15845
		private int m_numQuestTickets;

		// Token: 0x04003DE6 RID: 15846
		private NewQuestsData m_newQuestData;

		// Token: 0x04003DE7 RID: 15847
		public string lastAttacker = "";

		// Token: 0x04003DE8 RID: 15848
		public bool newPlayer;

		// Token: 0x04003DE9 RID: 15849
		public DateTime lastAttackerLastUpdate = DateTime.MinValue;

		// Token: 0x04003DEA RID: 15850
		public bool inUpdateLastAttackerInfo;

		// Token: 0x04003DEB RID: 15851
		public bool PickingStartCounty;

		// Token: 0x04003DEC RID: 15852
		public Dictionary<int, WorldMap.AvailableCounty> AvailableCounties;

		// Token: 0x04003DED RID: 15853
		private List<WorldHouseHistoryItem> playbackItems;

		// Token: 0x04003DEE RID: 15854
		private int[,] playbackCountriesData;

		// Token: 0x04003DEF RID: 15855
		private int[,] playbackProvincesData;

		// Token: 0x04003DF0 RID: 15856
		private bool playingCountries;

		// Token: 0x04003DF1 RID: 15857
		private bool playingProvinces;

		// Token: 0x04003DF2 RID: 15858
		public int playbackDay;

		// Token: 0x04003DF3 RID: 15859
		public int playbackTotalDays;

		// Token: 0x04003DF4 RID: 15860
		public int playbackBasedDay;

		// Token: 0x04003DF5 RID: 15861
		private int lastSetPlaybackDay;

		// Token: 0x04003DF6 RID: 15862
		private DateTime playbackStartTime;

		// Token: 0x04003DF7 RID: 15863
		private DateTime playbackBaseTime;

		// Token: 0x04003DF8 RID: 15864
		private DateTime playbackFrameTime;

		// Token: 0x04003DF9 RID: 15865
		private DateTime playbackLastUpdateTime;

		// Token: 0x04003DFA RID: 15866
		private int playbackMaxCountries;

		// Token: 0x04003DFB RID: 15867
		private int playbackMaxProvinces;

		// Token: 0x04003DFC RID: 15868
		private bool playbackPaused = true;

		// Token: 0x04003DFD RID: 15869
		private double playbackFrameMS = 500.0;

		// Token: 0x04003DFE RID: 15870
		private double playbackFrameFraction;

		// Token: 0x04003DFF RID: 15871
		private DateTime nextRatsCalc = DateTime.MinValue;

		// Token: 0x04003E00 RID: 15872
		private int lastRatsValue;

		// Token: 0x04003E01 RID: 15873
		private DateTime nextSnakesCalc = DateTime.MinValue;

		// Token: 0x04003E02 RID: 15874
		private int lastSnakesValue;

		// Token: 0x04003E03 RID: 15875
		private DateTime nextPigsCalc = DateTime.MinValue;

		// Token: 0x04003E04 RID: 15876
		private int lastPigsValue;

		// Token: 0x04003E05 RID: 15877
		private DateTime nextWolfsCalc = DateTime.MinValue;

		// Token: 0x04003E06 RID: 15878
		private int lastWolfsValue;

		// Token: 0x04003E07 RID: 15879
		public int saleStartTime;

		// Token: 0x04003E08 RID: 15880
		public int saleEndTime;

		// Token: 0x04003E09 RID: 15881
		public int salePercentage;

		// Token: 0x04003E0A RID: 15882
		public int contestStartTime;

		// Token: 0x04003E0B RID: 15883
		public int contestEndTime;

		// Token: 0x04003E0C RID: 15884
		public string contestName = string.Empty;

		// Token: 0x04003E0D RID: 15885
		public string contestDescription = string.Empty;

		// Token: 0x04003E0E RID: 15886
		public int contestID;

		// Token: 0x04003E0F RID: 15887
		public List<int> previousContests = new List<int>();

		// Token: 0x04003E10 RID: 15888
		public ContestType contestType;

		// Token: 0x04003E11 RID: 15889
		public List<int> pendingPrizes = new List<int>();

		// Token: 0x04003E12 RID: 15890
		public bool showGloryResults;

		// Token: 0x04003E13 RID: 15891
		public DateTime KillStreakTimer = DateTime.MinValue;

		// Token: 0x04003E14 RID: 15892
		private int KillStreakPoints;

		// Token: 0x04003E15 RID: 15893
		private int m_KillStreakCount;

		// Token: 0x04003E16 RID: 15894
		private bool bLinelessMap;

		// Token: 0x04003E17 RID: 15895
		private bool overrideLinelessMap;

		// Token: 0x04003E18 RID: 15896
		public WorldMapFilter worldMapFilter = new WorldMapFilter();

		// Token: 0x04003E19 RID: 15897
		public static Color SEACOLOR = Color.FromArgb(140, 182, 206);

		// Token: 0x04003E1A RID: 15898
		private bool drawDebugNames;

		// Token: 0x04003E1B RID: 15899
		private bool drawDebugVillageNames;

		// Token: 0x04003E1C RID: 15900
		private static Color[] areaColorList = new Color[]
		{
			Color.FromArgb(255, 169, 202, 149),
			Color.FromArgb(255, 236, 20, 20),
			Color.FromArgb(255, 236, 128, 20),
			Color.FromArgb(255, 240, 240, 25),
			Color.FromArgb(255, 22, 236, 22),
			Color.FromArgb(255, 4, 200, 200),
			Color.FromArgb(255, 2, 2, 188),
			Color.FromArgb(255, 155, 68, 196),
			Color.FromArgb(255, 241, 123, 177),
			Color.FromArgb(255, 231, 231, 231),
			Color.FromArgb(255, 41, 41, 48),
			Color.FromArgb(255, 127, 127, 127),
			Color.FromArgb(255, 109, 103, 3),
			Color.FromArgb(255, 2, 94, 46),
			Color.FromArgb(255, 3, 92, 125),
			Color.FromArgb(255, 58, 162, 230),
			Color.FromArgb(255, 157, 42, 41),
			Color.FromArgb(255, 134, 89, 46),
			Color.FromArgb(255, 194, 194, 82),
			Color.FromArgb(255, 84, 3, 207),
			Color.FromArgb(255, 210, 175, 226)
		};

		// Token: 0x04003E1D RID: 15901
		private static Color[] villageColorList = new Color[]
		{
			Color.FromArgb(255, 255, 255, 255),
			Color.FromArgb(255, 236, 20, 20),
			Color.FromArgb(255, 236, 128, 20),
			Color.FromArgb(255, 240, 240, 25),
			Color.FromArgb(255, 22, 236, 22),
			Color.FromArgb(255, 4, 200, 200),
			Color.FromArgb(255, 2, 2, 188),
			Color.FromArgb(255, 155, 68, 196),
			Color.FromArgb(255, 241, 123, 177),
			Color.FromArgb(255, 231, 231, 231),
			Color.FromArgb(255, 41, 41, 48),
			Color.FromArgb(255, 127, 127, 127),
			Color.FromArgb(255, 109, 103, 3),
			Color.FromArgb(255, 2, 94, 46),
			Color.FromArgb(255, 3, 92, 125),
			Color.FromArgb(255, 58, 162, 230),
			Color.FromArgb(255, 157, 42, 41),
			Color.FromArgb(255, 134, 89, 46),
			Color.FromArgb(255, 194, 194, 82),
			Color.FromArgb(255, 84, 3, 207),
			Color.FromArgb(255, 210, 175, 226),
			Color.FromArgb(255, 0, 0, 0)
		};

		// Token: 0x04003E1E RID: 15902
		public bool TributeLines;

		// Token: 0x04003E1F RID: 15903
		public bool PoliticalMap = true;

		// Token: 0x04003E20 RID: 15904
		public bool PolitcalMapView = true;

		// Token: 0x04003E21 RID: 15905
		public bool GeographicalMap = true;

		// Token: 0x04003E22 RID: 15906
		private int pulse;

		// Token: 0x04003E23 RID: 15907
		private int pulseValue;

		// Token: 0x04003E24 RID: 15908
		private int contestPulseValue = 175;

		// Token: 0x04003E25 RID: 15909
		private int contestPulse = 5;

		// Token: 0x04003E26 RID: 15910
		private bool xmasPresents;

		// Token: 0x04003E27 RID: 15911
		public bool overIcon;

		// Token: 0x04003E28 RID: 15912
		public bool overWikiHelp;

		// Token: 0x04003E29 RID: 15913
		public bool overTicketsIcon;

		// Token: 0x04003E2A RID: 15914
		public bool overWolf;

		// Token: 0x04003E2B RID: 15915
		public bool overRoyalTower;

		// Token: 0x04003E2C RID: 15916
		public bool overSale;

		// Token: 0x04003E2D RID: 15917
		public bool overOffer;

		// Token: 0x04003E2E RID: 15918
		public bool overContest;

		// Token: 0x04003E2F RID: 15919
		private int[] experimentalColourRemapping = new int[]
		{
			0,
			3,
			1,
			2,
			4
		};

		// Token: 0x04003E30 RID: 15920
		private Color islandLineColor = global::ARGBColors.DarkBlue;

		// Token: 0x04003E31 RID: 15921
		private List<WorldMap.MapText> textDrawList = new List<WorldMap.MapText>();

		// Token: 0x04003E32 RID: 15922
		private int m_rolloverTargetVillage = -1;

		// Token: 0x04003E33 RID: 15923
		private int m_rolloverTargetVillageNoDelay = -1;

		// Token: 0x04003E34 RID: 15924
		public int m_userInfoShieldRolloverUserID = -1;

		// Token: 0x04003E35 RID: 15925
		private int m_rolloverVillageShieldID = -1;

		// Token: 0x04003E36 RID: 15926
		private Point m_rolloverLastMousepos;

		// Token: 0x04003E37 RID: 15927
		private long m_rolloverLastTime;

		// Token: 0x04003E38 RID: 15928
		private List<WorldMap.InterVillageLine> interVillageLines = new List<WorldMap.InterVillageLine>();

		// Token: 0x04003E39 RID: 15929
		private List<WorldMap.InterVillageLine> dynamicVillageLines = new List<WorldMap.InterVillageLine>();

		// Token: 0x04003E3A RID: 15930
		private bool m_zooming;

		// Token: 0x04003E3B RID: 15931
		private double m_targetZoom;

		// Token: 0x04003E3C RID: 15932
		private double m_zoomDiff;

		// Token: 0x04003E3D RID: 15933
		private double m_zoomXPosDiff;

		// Token: 0x04003E3E RID: 15934
		private double m_zoomYPosDiff;

		// Token: 0x04003E3F RID: 15935
		private double m_zoomXPosTarget;

		// Token: 0x04003E40 RID: 15936
		private double m_zoomYPosTarget;

		// Token: 0x04003E41 RID: 15937
		private double m_zoomChangeThisFrame;

		// Token: 0x04003E42 RID: 15938
		public bool isDraggingMap;

		// Token: 0x04003E43 RID: 15939
		private bool m_leftMouseHeldDown;

		// Token: 0x04003E44 RID: 15940
		private double m_lastMousePressedTime;

		// Token: 0x04003E45 RID: 15941
		private Point m_baseMousePos;

		// Token: 0x04003E46 RID: 15942
		private double m_baseScreenX;

		// Token: 0x04003E47 RID: 15943
		private double m_baseScreenY;

		// Token: 0x04003E48 RID: 15944
		private double m_doubleClickTime = DXTimer.GetCurrentMilliseconds();

		// Token: 0x04003E49 RID: 15945
		private Point m_doubleClickMousePos;

		// Token: 0x04003E4A RID: 15946
		private bool dragMode;

		// Token: 0x04003E4B RID: 15947
		public static bool USE_MOMENTUM = true;

		// Token: 0x04003E4C RID: 15948
		public static bool KILL_SCROLLING = false;

		// Token: 0x04003E4D RID: 15949
		public static bool FORCE_VILLAGE_SELECTION_ALWAYS = false;

		// Token: 0x04003E4E RID: 15950
		private double lastX;

		// Token: 0x04003E4F RID: 15951
		private double lastY;

		// Token: 0x04003E50 RID: 15952
		public Point lastClickedLocation;

		// Token: 0x04003E51 RID: 15953
		public int LastClickedVillage = -1;

		// Token: 0x04003E52 RID: 15954
		private double m_zoomCap;

		// Token: 0x04003E53 RID: 15955
		private int m_zoomStage = -1;

		// Token: 0x04003E54 RID: 15956
		private double m_stagedTargetZoom;

		// Token: 0x04003E55 RID: 15957
		private double m_stagedTargetX;

		// Token: 0x04003E56 RID: 15958
		private double m_stagedTargetY;

		// Token: 0x04003E57 RID: 15959
		private int m_multiStageSoundMode;

		// Token: 0x04003E58 RID: 15960
		private WorldMap.WorldZoomCallback worldZoomCallback;

		// Token: 0x04003E59 RID: 15961
		private int zoomMin;

		// Token: 0x04003E5A RID: 15962
		private int zoomMax = 27000;

		// Token: 0x04003E5B RID: 15963
		private int zoomCurrent = 4000;

		// Token: 0x04003E5C RID: 15964
		private SpriteWrapper villageSprite;

		// Token: 0x04003E5D RID: 15965
		private SpriteWrapper worldTileSprite = new SpriteWrapper();

		// Token: 0x04003E5E RID: 15966
		private SpriteWrapper worldTreeSprite = new SpriteWrapper();

		// Token: 0x04003E5F RID: 15967
		private SpriteWrapper overlaySprite = new SpriteWrapper();

		// Token: 0x04003E60 RID: 15968
		private SpriteWrapper updateClockSprite = new SpriteWrapper();

		// Token: 0x04003E61 RID: 15969
		private SpriteWrapper tutorialOverlaySprite = new SpriteWrapper();

		// Token: 0x04003E62 RID: 15970
		private SpriteWrapper freeCardsSprite = new SpriteWrapper();

		// Token: 0x04003E63 RID: 15971
		private SpriteWrapper freeCardsSprite2 = new SpriteWrapper();

		// Token: 0x04003E64 RID: 15972
		private SpriteWrapper wikiHelpSprite = new SpriteWrapper();

		// Token: 0x04003E65 RID: 15973
		private SpriteWrapper wolfsRevengeSprite = new SpriteWrapper();

		// Token: 0x04003E66 RID: 15974
		private SpriteWrapper wolfsRevengeSprite2 = new SpriteWrapper();

		// Token: 0x04003E67 RID: 15975
		private SpriteWrapper saleSprite = new SpriteWrapper();

		// Token: 0x04003E68 RID: 15976
		private SpriteWrapper offerSprite = new SpriteWrapper();

		// Token: 0x04003E69 RID: 15977
		private SpriteWrapper contestSprite = new SpriteWrapper();

		// Token: 0x04003E6A RID: 15978
		private List<SpriteWrapper> saleDigits = new List<SpriteWrapper>();

		// Token: 0x04003E6B RID: 15979
		private List<SpriteWrapper> saleTimer = new List<SpriteWrapper>();

		// Token: 0x04003E6C RID: 15980
		private List<SpriteWrapper> offerTimer = new List<SpriteWrapper>();

		// Token: 0x04003E6D RID: 15981
		private SpriteWrapper saleClock = new SpriteWrapper();

		// Token: 0x04003E6E RID: 15982
		private SpriteWrapper offerClock = new SpriteWrapper();

		// Token: 0x04003E6F RID: 15983
		private SpriteWrapper seaSprite = new SpriteWrapper();

		// Token: 0x04003E70 RID: 15984
		private SpriteWrapper royalTowerSprite = new SpriteWrapper();

		// Token: 0x04003E71 RID: 15985
		private SpriteWrapper royalTowerSprite1 = new SpriteWrapper();

		// Token: 0x04003E72 RID: 15986
		private SpriteWrapper royalTowerSprite2 = new SpriteWrapper();

		// Token: 0x04003E73 RID: 15987
		private SpriteWrapper royalTowerSprite3 = new SpriteWrapper();

		// Token: 0x04003E74 RID: 15988
		private SpriteWrapper ticketsSprite = new SpriteWrapper();

		// Token: 0x04003E75 RID: 15989
		private SpriteWrapper ticketsSprite2 = new SpriteWrapper();

		// Token: 0x04003E76 RID: 15990
		public int TILEMAP_WIDTH = 691;

		// Token: 0x04003E77 RID: 15991
		public int TILEMAP_HEIGHT = 804;

		// Token: 0x04003E78 RID: 15992
		private short[,] mapTileGrid;

		// Token: 0x04003E79 RID: 15993
		private byte[,] tree1Grid;

		// Token: 0x04003E7A RID: 15994
		private byte[,] tree2Grid;

		// Token: 0x04003E7B RID: 15995
		public bool haveInitMapTiles;

		// Token: 0x04003E7C RID: 15996
		private int[] ukCountyColour = new int[]
		{
			0,
			1,
			2,
			1,
			2,
			1,
			0,
			1,
			0,
			0,
			2,
			0,
			3,
			1,
			3,
			2,
			1,
			0,
			2,
			0,
			1,
			0,
			2,
			3,
			1,
			3,
			0,
			1,
			0,
			0,
			1,
			3,
			1,
			0,
			0,
			0,
			1,
			2,
			3,
			2,
			1,
			0,
			3,
			0,
			3,
			2,
			1,
			3,
			0,
			1,
			0,
			0,
			0,
			2,
			1,
			3,
			0,
			1,
			3,
			2,
			0,
			3,
			1,
			0,
			1,
			0,
			3,
			0,
			3,
			1,
			0,
			1,
			1,
			2,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			2,
			1,
			0,
			2,
			0,
			1,
			2,
			3,
			1,
			2,
			0,
			3,
			2,
			3,
			3,
			1,
			0,
			3,
			0,
			2,
			0,
			1,
			2,
			0,
			1,
			0,
			1,
			3,
			2,
			3,
			2,
			0
		};

		// Token: 0x04003E7D RID: 15997
		private int[] ukProvinceColour = new int[]
		{
			0,
			1,
			2,
			0,
			1,
			3,
			1,
			1,
			2,
			0,
			2,
			0,
			2,
			0,
			1,
			2,
			2,
			0,
			1,
			0,
			1,
			2,
			0
		};

		// Token: 0x04003E7E RID: 15998
		private int[] ukCountryColour;

		// Token: 0x04003E7F RID: 15999
		private int[] deCountyColour;

		// Token: 0x04003E80 RID: 16000
		private int[] deProvinceColour;

		// Token: 0x04003E81 RID: 16001
		private int[] deCountryColour;

		// Token: 0x04003E82 RID: 16002
		private int[] frCountyColour;

		// Token: 0x04003E83 RID: 16003
		private int[] frProvinceColour;

		// Token: 0x04003E84 RID: 16004
		private int[] frCountryColour;

		// Token: 0x04003E85 RID: 16005
		private int[] ruCountyColour;

		// Token: 0x04003E86 RID: 16006
		private int[] ruProvinceColour;

		// Token: 0x04003E87 RID: 16007
		private int[] ruCountryColour;

		// Token: 0x04003E88 RID: 16008
		private int[] esCountyColour;

		// Token: 0x04003E89 RID: 16009
		private int[] esProvinceColour;

		// Token: 0x04003E8A RID: 16010
		private int[] esCountryColour;

		// Token: 0x04003E8B RID: 16011
		private int[] euCountyColour;

		// Token: 0x04003E8C RID: 16012
		private int[] euProvinceColour;

		// Token: 0x04003E8D RID: 16013
		private int[] euCountryColour;

		// Token: 0x04003E8E RID: 16014
		private int[] itCountyColour;

		// Token: 0x04003E8F RID: 16015
		private int[] itProvinceColour;

		// Token: 0x04003E90 RID: 16016
		private int[] itCountryColour;

		// Token: 0x04003E91 RID: 16017
		private int[] plCountyColour;

		// Token: 0x04003E92 RID: 16018
		private int[] plProvinceColour;

		// Token: 0x04003E93 RID: 16019
		private int[] plCountryColour;

		// Token: 0x04003E94 RID: 16020
		private int[] saCountyColour;

		// Token: 0x04003E95 RID: 16021
		private int[] saProvinceColour;

		// Token: 0x04003E96 RID: 16022
		private int[] saCountryColour;

		// Token: 0x04003E97 RID: 16023
		private int[] trCountyColour;

		// Token: 0x04003E98 RID: 16024
		private int[] trProvinceColour;

		// Token: 0x04003E99 RID: 16025
		private int[] trCountryColour;

		// Token: 0x04003E9A RID: 16026
		private int[] uk2CountyColour;

		// Token: 0x04003E9B RID: 16027
		private int[] uk2ProvinceColour;

		// Token: 0x04003E9C RID: 16028
		private int[] uk2CountryColour;

		// Token: 0x04003E9D RID: 16029
		private int[] usCountyColour;

		// Token: 0x04003E9E RID: 16030
		private int[] usProvinceColour;

		// Token: 0x04003E9F RID: 16031
		private int[] usCountryColour;

		// Token: 0x04003EA0 RID: 16032
		private int[] gcCountyColour;

		// Token: 0x04003EA1 RID: 16033
		private int[] gcProvinceColour;

		// Token: 0x04003EA2 RID: 16034
		private int[] gcCountryColour;

		// Token: 0x04003EA3 RID: 16035
		private int[] phCountyColour;

		// Token: 0x04003EA4 RID: 16036
		private int[] phProvinceColour;

		// Token: 0x04003EA5 RID: 16037
		private int[] phCountryColour;

		// Token: 0x04003EA6 RID: 16038
		private int[] chCountyColour;

		// Token: 0x04003EA7 RID: 16039
		private int[] chProvinceColour;

		// Token: 0x04003EA8 RID: 16040
		private int[] chCountryColour;

		// Token: 0x04003EA9 RID: 16041
		private int[] kgCountyColour;

		// Token: 0x04003EAA RID: 16042
		private int[] kgProvinceColour;

		// Token: 0x04003EAB RID: 16043
		private int[] kgCountryColour;

		// Token: 0x04003EAC RID: 16044
		private SparseArray leaderboard_Main;

		// Token: 0x04003EAD RID: 16045
		private SparseArray leaderboard_MainRank;

		// Token: 0x04003EAE RID: 16046
		private SparseArray leaderboard_MainVillages;

		// Token: 0x04003EAF RID: 16047
		private SparseArray leaderboard_Factions;

		// Token: 0x04003EB0 RID: 16048
		private SparseArray leaderboard_Houses;

		// Token: 0x04003EB1 RID: 16049
		private SparseArray leaderboard_ParishFlags;

		// Token: 0x04003EB2 RID: 16050
		private SparseArray leaderboard_Sub_Pillager;

		// Token: 0x04003EB3 RID: 16051
		private SparseArray leaderboard_Sub_Defender;

		// Token: 0x04003EB4 RID: 16052
		private SparseArray leaderboard_Sub_Ransack;

		// Token: 0x04003EB5 RID: 16053
		private SparseArray leaderboard_Sub_Wolfsbane;

		// Token: 0x04003EB6 RID: 16054
		private SparseArray leaderboard_Sub_Banditkiller;

		// Token: 0x04003EB7 RID: 16055
		private SparseArray leaderboard_Sub_AIKiller;

		// Token: 0x04003EB8 RID: 16056
		private SparseArray leaderboard_Sub_Trader;

		// Token: 0x04003EB9 RID: 16057
		private SparseArray leaderboard_Sub_Forager;

		// Token: 0x04003EBA RID: 16058
		private SparseArray leaderboard_Sub_Stockpiler;

		// Token: 0x04003EBB RID: 16059
		private SparseArray leaderboard_Sub_Farmer;

		// Token: 0x04003EBC RID: 16060
		private SparseArray leaderboard_Sub_Brewer;

		// Token: 0x04003EBD RID: 16061
		private SparseArray leaderboard_Sub_Weaponsmith;

		// Token: 0x04003EBE RID: 16062
		private SparseArray leaderboard_Sub_banquetter;

		// Token: 0x04003EBF RID: 16063
		private SparseArray leaderboard_Sub_Achiever;

		// Token: 0x04003EC0 RID: 16064
		private SparseArray leaderboard_Sub_Donater;

		// Token: 0x04003EC1 RID: 16065
		private SparseArray leaderboard_Sub_Capture;

		// Token: 0x04003EC2 RID: 16066
		private SparseArray leaderboard_Sub_Raze;

		// Token: 0x04003EC3 RID: 16067
		private SparseArray leaderboard_Sub_Glory;

		// Token: 0x04003EC4 RID: 16068
		private SparseArray leaderboard_Sub_KillStreak;

		// Token: 0x04003EC5 RID: 16069
		private int max_leaderboard_Main;

		// Token: 0x04003EC6 RID: 16070
		private int max_leaderboard_MainRank;

		// Token: 0x04003EC7 RID: 16071
		private int max_leaderboard_MainVillages;

		// Token: 0x04003EC8 RID: 16072
		private int max_leaderboard_Factions;

		// Token: 0x04003EC9 RID: 16073
		private int max_leaderboard_Houses;

		// Token: 0x04003ECA RID: 16074
		private int max_leaderboard_ParishFlags;

		// Token: 0x04003ECB RID: 16075
		private int max_leaderboard_Sub_Pillager;

		// Token: 0x04003ECC RID: 16076
		private int max_leaderboard_Sub_Defender;

		// Token: 0x04003ECD RID: 16077
		private int max_leaderboard_Sub_Ransack;

		// Token: 0x04003ECE RID: 16078
		private int max_leaderboard_Sub_Wolfsbane;

		// Token: 0x04003ECF RID: 16079
		private int max_leaderboard_Sub_Banditkiller;

		// Token: 0x04003ED0 RID: 16080
		private int max_leaderboard_Sub_AIKiller;

		// Token: 0x04003ED1 RID: 16081
		private int max_leaderboard_Sub_Trader;

		// Token: 0x04003ED2 RID: 16082
		private int max_leaderboard_Sub_Forager;

		// Token: 0x04003ED3 RID: 16083
		private int max_leaderboard_Sub_Stockpiler;

		// Token: 0x04003ED4 RID: 16084
		private int max_leaderboard_Sub_Farmer;

		// Token: 0x04003ED5 RID: 16085
		private int max_leaderboard_Sub_Brewer;

		// Token: 0x04003ED6 RID: 16086
		private int max_leaderboard_Sub_Weaponsmith;

		// Token: 0x04003ED7 RID: 16087
		private int max_leaderboard_Sub_banquetter;

		// Token: 0x04003ED8 RID: 16088
		private int max_leaderboard_Sub_Achiever;

		// Token: 0x04003ED9 RID: 16089
		private int max_leaderboard_Sub_Donater;

		// Token: 0x04003EDA RID: 16090
		private int max_leaderboard_Sub_Capture;

		// Token: 0x04003EDB RID: 16091
		private int max_leaderboard_Sub_Raze;

		// Token: 0x04003EDC RID: 16092
		private int max_leaderboard_Sub_Glory;

		// Token: 0x04003EDD RID: 16093
		private int max_leaderboard_Sub_KillStreak;

		// Token: 0x04003EDE RID: 16094
		private DateTime lastZeroDownload_leaderboard_Main;

		// Token: 0x04003EDF RID: 16095
		private DateTime lastZeroDownload_leaderboard_MainRank;

		// Token: 0x04003EE0 RID: 16096
		private DateTime lastZeroDownload_leaderboard_MainVillages;

		// Token: 0x04003EE1 RID: 16097
		private DateTime lastZeroDownload_leaderboard_Factions;

		// Token: 0x04003EE2 RID: 16098
		private DateTime lastZeroDownload_leaderboard_Houses;

		// Token: 0x04003EE3 RID: 16099
		private DateTime lastZeroDownload_leaderboard_ParishFlags;

		// Token: 0x04003EE4 RID: 16100
		private DateTime lastZeroDownload_leaderboard_Sub_Pillager;

		// Token: 0x04003EE5 RID: 16101
		private DateTime lastZeroDownload_leaderboard_Sub_Defender;

		// Token: 0x04003EE6 RID: 16102
		private DateTime lastZeroDownload_leaderboard_Sub_Ransack;

		// Token: 0x04003EE7 RID: 16103
		private DateTime lastZeroDownload_leaderboard_Sub_Wolfsbane;

		// Token: 0x04003EE8 RID: 16104
		private DateTime lastZeroDownload_leaderboard_Sub_Banditkiller;

		// Token: 0x04003EE9 RID: 16105
		private DateTime lastZeroDownload_leaderboard_Sub_AIKiller;

		// Token: 0x04003EEA RID: 16106
		private DateTime lastZeroDownload_leaderboard_Sub_Trader;

		// Token: 0x04003EEB RID: 16107
		private DateTime lastZeroDownload_leaderboard_Sub_Forager;

		// Token: 0x04003EEC RID: 16108
		private DateTime lastZeroDownload_leaderboard_Sub_Stockpiler;

		// Token: 0x04003EED RID: 16109
		private DateTime lastZeroDownload_leaderboard_Sub_Farmer;

		// Token: 0x04003EEE RID: 16110
		private DateTime lastZeroDownload_leaderboard_Sub_Brewer;

		// Token: 0x04003EEF RID: 16111
		private DateTime lastZeroDownload_leaderboard_Sub_Weaponsmith;

		// Token: 0x04003EF0 RID: 16112
		private DateTime lastZeroDownload_leaderboard_Sub_banquetter;

		// Token: 0x04003EF1 RID: 16113
		private DateTime lastZeroDownload_leaderboard_Sub_Achiever;

		// Token: 0x04003EF2 RID: 16114
		private DateTime lastZeroDownload_leaderboard_Sub_Donater;

		// Token: 0x04003EF3 RID: 16115
		private DateTime lastZeroDownload_leaderboard_Sub_Capture;

		// Token: 0x04003EF4 RID: 16116
		private DateTime lastZeroDownload_leaderboard_Sub_Raze;

		// Token: 0x04003EF5 RID: 16117
		private DateTime lastZeroDownload_leaderboard_Sub_Glory;

		// Token: 0x04003EF6 RID: 16118
		private DateTime lastZeroDownload_leaderboard_Sub_KillStreak;

		// Token: 0x04003EF7 RID: 16119
		private DateTime leaderboardLastUpdateTime;

		// Token: 0x04003EF8 RID: 16120
		private List<LeaderBoardSelfRankings> leaderboardSelfRankings;

		// Token: 0x04003EF9 RID: 16121
		private List<LeaderBoardSearchResults> leaderboardSearchResults;

		// Token: 0x04003EFA RID: 16122
		private static LeaderBoardEntryData dummyEntry = null;

		// Token: 0x04003EFB RID: 16123
		private bool inDownloading;

		// Token: 0x04003EFC RID: 16124
		private bool inLeaderboardSearch;

		// Token: 0x04003EFD RID: 16125
		private WorldMap.LeaderboardSelfRankingsComparer leaderboardSelfRankingsComparer;

		// Token: 0x04003EFE RID: 16126
		private WorldMap.LeaderboardSelfStaticComparer leaderboardSelfStaticComparer;

		// Token: 0x04003EFF RID: 16127
		private bool dirtyStanding;

		// Token: 0x04003F00 RID: 16128
		private string[,] china_country_Simplified;

		// Token: 0x04003F01 RID: 16129
		private string[,] china_country_English;

		// Token: 0x04003F02 RID: 16130
		private string[,] china_country_Korean;

		// Token: 0x04003F03 RID: 16131
		private string[,] china_country_Japanese;

		// Token: 0x04003F04 RID: 16132
		private string[,] china_province_Simplified;

		// Token: 0x04003F05 RID: 16133
		private string[,] china_province_English;

		// Token: 0x04003F06 RID: 16134
		private string[,] china_province_Korean;

		// Token: 0x04003F07 RID: 16135
		private string[,] china_province_Japanese;

		// Token: 0x04003F08 RID: 16136
		private string[,] china_county_Simplified;

		// Token: 0x04003F09 RID: 16137
		private string[,] china_county_English;

		// Token: 0x04003F0A RID: 16138
		private string[,] china_county_Korean;

		// Token: 0x04003F0B RID: 16139
		private string[,] china_county_Japanese;

		// Token: 0x04003F0C RID: 16140
		private string[] china_parish_Simplified;

		// Token: 0x04003F0D RID: 16141
		private string[] china_parish_English;

		// Token: 0x04003F0E RID: 16142
		[CompilerGenerated]
		private static Comparison<int> _003C_003E9__CachedAnonymousMethodDelegate1;

		// Token: 0x020004FC RID: 1276
		public struct ArmyRetrieveData
		{
			// Token: 0x04003F0F RID: 16143
			public long armyID;

			// Token: 0x04003F10 RID: 16144
			public DateTime expiryTime;
		}

		// Token: 0x020004FD RID: 1277
		public class LocalArmyData
		{
			// Token: 0x170002AB RID: 683
			// (get) Token: 0x06003312 RID: 13074 RVA: 0x00024B23 File Offset: 0x00022D23
			public bool reinforcementsAtTarget
			{
				get
				{
					return this.reinforcements && this.displayX == this.baseDisplayX && this.displayY == this.baseDisplayY;
				}
			}

			// Token: 0x06003313 RID: 13075 RVA: 0x002A4864 File Offset: 0x002A2A64
			public bool isVisible(RectangleF screenRect)
			{
				return (double)(screenRect.Top - 50f) <= this.displayY && (double)(screenRect.Left - 50f) <= this.displayX && (double)(screenRect.Bottom + 50f) >= this.displayY && (double)(screenRect.Right + 50f) >= this.displayX;
			}

			// Token: 0x06003314 RID: 13076 RVA: 0x00024B4B File Offset: 0x00022D4B
			public bool isScouts()
			{
				return this.numScouts > 0;
			}

			// Token: 0x06003315 RID: 13077 RVA: 0x00024B56 File Offset: 0x00022D56
			public bool isCaptainAttack()
			{
				return this.numCaptains > 0 || this.attackType == 18;
			}

			// Token: 0x06003316 RID: 13078 RVA: 0x002A48D4 File Offset: 0x002A2AD4
			public void createJourney(DateTime startTime, DateTime curTime, DateTime endTime)
			{
				endTime = endTime.AddSeconds(2.0);
				this.serverStartTime = startTime;
				this.serverEndTime = endTime;
				if (curTime > endTime && this.reinforcements)
				{
					this.visible = false;
					return;
				}
				this.visible = true;
				double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
				this.localStartTime = num - (curTime - startTime).TotalSeconds;
				this.localEndTime = num + (endTime - curTime).TotalSeconds;
				this.fakeEndTime = this.localEndTime + 3.0;
				this.requestSent = false;
				if (this.attackType == 21 && !GameEngine.Instance.World.isUserVillage(this.homeVillageID))
				{
					this.visible = false;
				}
			}

			// Token: 0x06003317 RID: 13079 RVA: 0x002A49A4 File Offset: 0x002A2BA4
			public void updatePosition()
			{
				if (this.targetVillageID >= 0 && this.visible)
				{
					double num = WorldMap.LocalArmyData.groupCurrentTime / 1000.0;
					double num2 = this.localStartTime;
					double num3 = this.localEndTime;
					if (this.lootType >= 0)
					{
						num2 += 3.0;
						num3 += 3.0;
					}
					double num4 = (num - num2) / (num3 - num2);
					double num5 = (num - num2) / (this.fakeEndTime - num2);
					double num6 = num4;
					if (!this.reinforcements)
					{
						if (this.lootType < 0)
						{
							num6 = num5;
							if (num4 > 1.0)
							{
								if (this.attackType == 30 || this.attackType == 31)
								{
									this.dead = true;
								}
								else if (!this.requestSent && num - this.localEndTime > 1.0 && num - this.localEndTime < 60.0)
								{
									if ((RemoteServices.Instance.UserID == this.userID || GameEngine.Instance.World.isUserVillage(this.targetVillageID)) && GameEngine.Instance.World.checkRecentRetrievalSend(this.armyID))
									{
										if (this.attackType == 13)
										{
											GameEngine.Instance.World.tutorialArmyID = this.armyID;
										}
										RemoteServices.Instance.RetrieveAttackResult(this.armyID, GameEngine.Instance.World.StoredVillageFactionPos);
										WorldMap.ArmyRetrieveData item = default(WorldMap.ArmyRetrieveData);
										item.armyID = this.armyID;
										item.expiryTime = DateTime.Now.AddSeconds(30.0);
										GameEngine.Instance.World.requestedReturnedArmyIDs.Add(item);
									}
									this.requestSent = true;
								}
							}
						}
						if (num6 > 1.0)
						{
							if (this.lootType < 0)
							{
								if (GameEngine.Instance.LocalWorldData.AIWorld && this.attackType == 17)
								{
									this.dead = true;
								}
								else
								{
									this.requestSent = false;
									num6 = 0.0;
									this.lootType = 10000;
									double num7 = this.localEndTime - this.localStartTime;
									this.localStartTime = this.localEndTime;
									this.localEndTime += num7;
									this.fakeEndTime += num7;
									this.realData = false;
								}
							}
							else
							{
								this.dead = true;
								VillageMap village = GameEngine.Instance.getVillage(this.travelFromVillageID);
								if (village != null && this.realData)
								{
									village.addTroopsArmyReturnSpecial(this.numPeasants, this.numArchers, this.numPikemen, this.numSwordsmen, this.numCatapults, this.numScouts, this.numCaptains);
									if (this.numScouts > 0 && this.lootType >= 100 && this.lootType <= 199)
									{
										village.addResources(this.lootType - 100, (int)this.lootLevel);
									}
									if (this.lootType == 2 && this.lootData != null)
									{
										village.addResources(6, this.lootData.woodLevel);
										village.addResources(7, this.lootData.stoneLevel);
										village.addResources(8, this.lootData.ironLevel);
										village.addResources(9, this.lootData.pitchLevel);
										village.addResources(13, this.lootData.applesLevel);
										village.addResources(14, this.lootData.breadLevel);
										village.addResources(17, this.lootData.cheeseLevel);
										village.addResources(16, this.lootData.meatLevel);
										village.addResources(18, this.lootData.fishLevel);
										village.addResources(15, this.lootData.vegLevel);
										village.addResources(12, this.lootData.aleLevel);
										village.addResources(21, this.lootData.furnitureLevel);
										village.addResources(19, this.lootData.clothesLevel);
										village.addResources(22, this.lootData.venisonLevel);
										village.addResources(23, this.lootData.saltLevel);
										village.addResources(33, this.lootData.wineLevel);
										village.addResources(26, this.lootData.metalwareLevel);
										village.addResources(24, this.lootData.spicesLevel);
										village.addResources(25, this.lootData.silkLevel);
										village.addResources(29, this.lootData.bowsLevel);
										village.addResources(28, this.lootData.pikesLevel);
										village.addResources(30, this.lootData.swordsLevel);
										village.addResources(31, this.lootData.armourLevel);
										village.addResources(32, this.lootData.catapultLevel);
									}
									else if (this.lootType >= 500 && this.lootType < 1000 && this.lootType < 700)
									{
										village.addResources(this.lootType, (int)this.lootLevel);
									}
								}
								else if (village != null)
								{
									GameEngine.Instance.flushVillage(village.VillageID);
								}
							}
						}
						if (num6 < 0.0)
						{
							num6 = 0.0;
						}
						if (this.lootType < 0)
						{
							this.displayX = (this.targetDisplayX - this.baseDisplayX) * num6 + this.baseDisplayX;
							this.displayY = (this.targetDisplayY - this.baseDisplayY) * num6 + this.baseDisplayY;
							return;
						}
						this.displayX = (this.baseDisplayX - this.targetDisplayX) * num6 + this.targetDisplayX;
						this.displayY = (this.baseDisplayY - this.targetDisplayY) * num6 + this.targetDisplayY;
						return;
					}
					else if (num4 > 1.0)
					{
						this.visible = false;
						VillageMap village2 = GameEngine.Instance.getVillage(this.homeVillageID);
						if (this.attackType == 21 && village2 != null)
						{
							this.dead = true;
							village2.addTroops(this.numPeasants, this.numArchers, this.numPikemen, this.numSwordsmen, this.numCatapults, this.numScouts);
							this.numPeasants = (this.numArchers = (this.numPikemen = (this.numSwordsmen = (this.numCatapults = 0))));
							return;
						}
					}
					else
					{
						if (this.attackType == 20)
						{
							this.displayX = (this.targetDisplayX - this.baseDisplayX) * num6 + this.baseDisplayX;
							this.displayY = (this.targetDisplayY - this.baseDisplayY) * num6 + this.baseDisplayY;
							return;
						}
						this.displayX = (this.baseDisplayX - this.targetDisplayX) * num6 + this.targetDisplayX;
						this.displayY = (this.baseDisplayY - this.targetDisplayY) * num6 + this.targetDisplayY;
						return;
					}
				}
				else
				{
					this.displayX = this.baseDisplayX;
					this.displayY = this.baseDisplayY;
				}
			}

			// Token: 0x06003318 RID: 13080 RVA: 0x002A50C8 File Offset: 0x002A32C8
			public PointF BasePoint()
			{
				if (!this.reinforcements)
				{
					if (this.lootType < 0)
					{
						return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
					}
					return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
				}
				else
				{
					if (this.attackType == 20)
					{
						return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
					}
					return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
				}
			}

			// Token: 0x06003319 RID: 13081 RVA: 0x002A5140 File Offset: 0x002A3340
			public PointF TargetPoint()
			{
				if (!this.reinforcements)
				{
					if (this.lootType < 0)
					{
						return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
					}
					return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
				}
				else
				{
					if (this.attackType == 20)
					{
						return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
					}
					return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
				}
			}

			// Token: 0x0600331A RID: 13082 RVA: 0x002A51B8 File Offset: 0x002A33B8
			public TroopCount GetTroopCount()
			{
				return new TroopCount
				{
					peasants = this.numPeasants,
					archers = this.numArchers,
					pikemen = this.numPikemen,
					swordsmen = this.numSwordsmen,
					catapults = this.numCatapults,
					captains = this.numCaptains
				};
			}

			// Token: 0x04003F11 RID: 16145
			public long armyID;

			// Token: 0x04003F12 RID: 16146
			public int homeVillageID;

			// Token: 0x04003F13 RID: 16147
			public int travelFromVillageID;

			// Token: 0x04003F14 RID: 16148
			public int userID;

			// Token: 0x04003F15 RID: 16149
			public int attackType;

			// Token: 0x04003F16 RID: 16150
			public int targetVillageID;

			// Token: 0x04003F17 RID: 16151
			public int numPeasants;

			// Token: 0x04003F18 RID: 16152
			public int numArchers;

			// Token: 0x04003F19 RID: 16153
			public int numPikemen;

			// Token: 0x04003F1A RID: 16154
			public int numSwordsmen;

			// Token: 0x04003F1B RID: 16155
			public int numCatapults;

			// Token: 0x04003F1C RID: 16156
			public int numCaptains;

			// Token: 0x04003F1D RID: 16157
			public int numScouts;

			// Token: 0x04003F1E RID: 16158
			public int captainsCommand;

			// Token: 0x04003F1F RID: 16159
			public int lootType;

			// Token: 0x04003F20 RID: 16160
			public double lootLevel;

			// Token: 0x04003F21 RID: 16161
			public ArmyLootData lootData;

			// Token: 0x04003F22 RID: 16162
			public double displayX;

			// Token: 0x04003F23 RID: 16163
			public double displayY;

			// Token: 0x04003F24 RID: 16164
			public double baseDisplayX;

			// Token: 0x04003F25 RID: 16165
			public double baseDisplayY;

			// Token: 0x04003F26 RID: 16166
			public double targetDisplayX;

			// Token: 0x04003F27 RID: 16167
			public double targetDisplayY;

			// Token: 0x04003F28 RID: 16168
			public double localStartTime;

			// Token: 0x04003F29 RID: 16169
			public double localEndTime;

			// Token: 0x04003F2A RID: 16170
			public double fakeEndTime;

			// Token: 0x04003F2B RID: 16171
			public int aiPlayer;

			// Token: 0x04003F2C RID: 16172
			public DateTime serverStartTime;

			// Token: 0x04003F2D RID: 16173
			public DateTime serverEndTime;

			// Token: 0x04003F2E RID: 16174
			public bool carryingFlag;

			// Token: 0x04003F2F RID: 16175
			public bool seaTravel;

			// Token: 0x04003F30 RID: 16176
			public bool requestSent;

			// Token: 0x04003F31 RID: 16177
			public bool dead;

			// Token: 0x04003F32 RID: 16178
			public bool realData = true;

			// Token: 0x04003F33 RID: 16179
			public bool reinforcements;

			// Token: 0x04003F34 RID: 16180
			public bool visible = true;

			// Token: 0x04003F35 RID: 16181
			public bool singlyAdded;

			// Token: 0x04003F36 RID: 16182
			public static double groupCurrentTime;
		}

		// Token: 0x020004FE RID: 1278
		public class FWData
		{
			// Token: 0x04003F37 RID: 16183
			public int spriteID;

			// Token: 0x04003F38 RID: 16184
			public int numToSpawn = 25;

			// Token: 0x04003F39 RID: 16185
			public bool symmetrical;

			// Token: 0x04003F3A RID: 16186
			public bool randomStartRotation;

			// Token: 0x04003F3B RID: 16187
			public float rotateSpeed;

			// Token: 0x04003F3C RID: 16188
			public bool rotateClockwise = true;

			// Token: 0x04003F3D RID: 16189
			public float startScale = 1f;

			// Token: 0x04003F3E RID: 16190
			public float scaleSpeed;

			// Token: 0x04003F3F RID: 16191
			public float scaleTarget = 1f;

			// Token: 0x04003F40 RID: 16192
			public int fadeInTime;

			// Token: 0x04003F41 RID: 16193
			public int fadeOutTime;

			// Token: 0x04003F42 RID: 16194
			public float fadeRate;

			// Token: 0x04003F43 RID: 16195
			public float initialVelocity = 1f;

			// Token: 0x04003F44 RID: 16196
			public float maxVelocity = 1f;

			// Token: 0x04003F45 RID: 16197
			public float acceleration = 1f;

			// Token: 0x04003F46 RID: 16198
			public float speedVariance = 0.3f;

			// Token: 0x04003F47 RID: 16199
			public int childFirework;
		}

		// Token: 0x020004FF RID: 1279
		private enum FW_Resources
		{
			// Token: 0x04003F49 RID: 16201
			apple = 1,
			// Token: 0x04003F4A RID: 16202
			bread,
			// Token: 0x04003F4B RID: 16203
			meat,
			// Token: 0x04003F4C RID: 16204
			veg,
			// Token: 0x04003F4D RID: 16205
			fish,
			// Token: 0x04003F4E RID: 16206
			dairy,
			// Token: 0x04003F4F RID: 16207
			wood,
			// Token: 0x04003F50 RID: 16208
			stone,
			// Token: 0x04003F51 RID: 16209
			iron,
			// Token: 0x04003F52 RID: 16210
			pitch,
			// Token: 0x04003F53 RID: 16211
			ale,
			// Token: 0x04003F54 RID: 16212
			furniture,
			// Token: 0x04003F55 RID: 16213
			clothes,
			// Token: 0x04003F56 RID: 16214
			wine,
			// Token: 0x04003F57 RID: 16215
			metalware,
			// Token: 0x04003F58 RID: 16216
			salt,
			// Token: 0x04003F59 RID: 16217
			venison,
			// Token: 0x04003F5A RID: 16218
			spices,
			// Token: 0x04003F5B RID: 16219
			silk,
			// Token: 0x04003F5C RID: 16220
			bows,
			// Token: 0x04003F5D RID: 16221
			poles,
			// Token: 0x04003F5E RID: 16222
			swords,
			// Token: 0x04003F5F RID: 16223
			armour,
			// Token: 0x04003F60 RID: 16224
			catapults
		}

		// Token: 0x02000500 RID: 1280
		private class ClusterBase
		{
			// Token: 0x04003F61 RID: 16225
			public int unique;

			// Token: 0x04003F62 RID: 16226
			public List<WorldMap.Burst> bursts = new List<WorldMap.Burst>();

			// Token: 0x04003F63 RID: 16227
			public int startVillage = -1;

			// Token: 0x04003F64 RID: 16228
			public int targetX = -1;

			// Token: 0x04003F65 RID: 16229
			public int targetY = -1;

			// Token: 0x04003F66 RID: 16230
			public DateTime startTime;

			// Token: 0x04003F67 RID: 16231
			public DateTime endTime;

			// Token: 0x04003F68 RID: 16232
			public bool parentVisible = true;

			// Token: 0x04003F69 RID: 16233
			public int spriteID;

			// Token: 0x04003F6A RID: 16234
			public int type;

			// Token: 0x04003F6B RID: 16235
			public int[] fwS;
		}

		// Token: 0x02000501 RID: 1281
		private class Burst
		{
			// Token: 0x04003F6C RID: 16236
			public int unique;

			// Token: 0x04003F6D RID: 16237
			public float startX = -1f;

			// Token: 0x04003F6E RID: 16238
			public float startY = -1f;

			// Token: 0x04003F6F RID: 16239
			public float dX;

			// Token: 0x04003F70 RID: 16240
			public float dY;

			// Token: 0x04003F71 RID: 16241
			public float speed = 0.1f;

			// Token: 0x04003F72 RID: 16242
			public float acceleration;

			// Token: 0x04003F73 RID: 16243
			public DateTime startTime;

			// Token: 0x04003F74 RID: 16244
			public int spriteID;

			// Token: 0x04003F75 RID: 16245
			public float curRotation;

			// Token: 0x04003F76 RID: 16246
			public float rotationValue;

			// Token: 0x04003F77 RID: 16247
			public float scale = 1f;

			// Token: 0x04003F78 RID: 16248
			public float scaleDiff;

			// Token: 0x04003F79 RID: 16249
			public float alpha;

			// Token: 0x04003F7A RID: 16250
			public int fadeState;

			// Token: 0x04003F7B RID: 16251
			public WorldMap.FWData definition;
		}

		// Token: 0x02000502 RID: 1282
		public class UserVillageData
		{
			// Token: 0x04003F7C RID: 16252
			public int villageID;

			// Token: 0x04003F7D RID: 16253
			public bool capital;

			// Token: 0x04003F7E RID: 16254
			public bool parishCapital;

			// Token: 0x04003F7F RID: 16255
			public bool countyCapital;

			// Token: 0x04003F80 RID: 16256
			public bool provinceCapital;

			// Token: 0x04003F81 RID: 16257
			public bool countryCapital;

			// Token: 0x04003F82 RID: 16258
			public List<int> vassals = new List<int>();
		}

		// Token: 0x02000503 RID: 1283
		public class VillageNameItem
		{
			// Token: 0x06003320 RID: 13088 RVA: 0x00024BF9 File Offset: 0x00022DF9
			public override string ToString()
			{
				if (this.capital && GameEngine.Instance.World.isUserVillage(this.villageID))
				{
					return this.villageName + "*";
				}
				return this.villageName;
			}

			// Token: 0x04003F83 RID: 16259
			public string villageName;

			// Token: 0x04003F84 RID: 16260
			public int villageID;

			// Token: 0x04003F85 RID: 16261
			public bool capital;

			// Token: 0x04003F86 RID: 16262
			public int sortLevel;
		}

		// Token: 0x02000504 RID: 1284
		public class VillageNameComparer : IComparer<WorldMap.UserVillageData>
		{
			// Token: 0x06003322 RID: 13090 RVA: 0x002A5278 File Offset: 0x002A3478
			public int Compare(WorldMap.UserVillageData x, WorldMap.UserVillageData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.capital && !y.capital)
					{
						return 1;
					}
					if (!x.capital && y.capital)
					{
						return -1;
					}
					string villageNameOnly = GameEngine.Instance.World.getVillageNameOnly(x.villageID);
					string villageNameOnly2 = GameEngine.Instance.World.getVillageNameOnly(y.villageID);
					return villageNameOnly.CompareTo(villageNameOnly2);
				}
			}
		}

		// Token: 0x02000505 RID: 1285
		// (Invoke) Token: 0x06003325 RID: 13093
		public delegate void ResearchChangedDelegate();

		// Token: 0x02000506 RID: 1286
		public class LocalPerson
		{
			// Token: 0x06003328 RID: 13096 RVA: 0x002A52EC File Offset: 0x002A34EC
			public PointF BasePoint()
			{
				if (this.person.state == 0 || this.person.state == 1 || this.person.state == 2 || this.person.state == 11 || this.person.state == 12 || this.person.state == 21 || this.person.state == 22 || this.person.state == 31 || this.person.state == 75)
				{
					return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
				}
				return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
			}

			// Token: 0x06003329 RID: 13097 RVA: 0x002A53A4 File Offset: 0x002A35A4
			public PointF TargetPoint()
			{
				if (this.person.state == 0 || this.person.state == 1 || this.person.state == 2 || this.person.state == 11 || this.person.state == 12 || this.person.state == 21 || this.person.state == 22 || this.person.state == 31 || this.person.state == 75)
				{
					return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
				}
				return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
			}

			// Token: 0x0600332A RID: 13098 RVA: 0x002A545C File Offset: 0x002A365C
			public bool isVisible(RectangleF screenRect)
			{
				return (double)(screenRect.Top - 50f) <= this.displayY && (double)(screenRect.Left - 50f) <= this.displayX && (double)(screenRect.Bottom + 50f) >= this.displayY && (double)(screenRect.Right + 50f) >= this.displayX;
			}

			// Token: 0x0600332B RID: 13099 RVA: 0x002A54CC File Offset: 0x002A36CC
			public void createJourney(DateTime startTime, DateTime curTime, DateTime endTime)
			{
				this.serverEndTime = endTime;
				double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
				this.localStartTime = num - (curTime - startTime).TotalSeconds;
				this.localEndTime = num + (endTime - curTime).TotalSeconds;
			}

			// Token: 0x0600332C RID: 13100 RVA: 0x002A5520 File Offset: 0x002A3720
			public void updatePosition(double realTime)
			{
				if (this.person.state == 2 || this.person.state == 12 || this.person.state == 22)
				{
					this.displayX = (this.targetDisplayX - this.baseDisplayX) * 1.0 + this.baseDisplayX;
					this.displayY = (this.targetDisplayY - this.baseDisplayY) * 1.0 + this.baseDisplayY;
					return;
				}
				if (this.person.state <= 0)
				{
					this.displayX = this.baseDisplayX;
					this.displayY = this.baseDisplayY;
					return;
				}
				double num = (this.localEndTime == this.localStartTime) ? 1.1 : ((realTime - this.localStartTime) / (this.localEndTime - this.localStartTime));
				if (num > 1.0)
				{
					if (this.person.state == 1 || this.person.state == 11 || this.person.state == 21)
					{
						num = 1.0;
						this.person.state++;
					}
					else if (this.person.state == 50)
					{
						num = 0.0;
						this.person.state = 0;
						this.person.lastSpyTime = VillageMap.getCurrentServerTime();
					}
					else if (this.person.state == 31 || this.person.state == 75)
					{
						this.dying = true;
						if (this.person.state == 75)
						{
							int parishFromVillageID = GameEngine.Instance.World.getParishFromVillageID(this.person.targetVillageID);
							GameEngine.Instance.World.givePlaguesToParish(parishFromVillageID);
						}
						GameEngine.Instance.World.clearVillageRolloverInfo(this.person.targetVillageID);
					}
				}
				else if (num < 0.0)
				{
					num = 0.0;
				}
				this.lastRatio = num;
				if (this.person.state == 1 || this.person.state == 11 || this.person.state == 21 || this.person.state == 31 || this.person.state == 75)
				{
					this.displayX = (this.targetDisplayX - this.baseDisplayX) * num + this.baseDisplayX;
					this.displayY = (this.targetDisplayY - this.baseDisplayY) * num + this.baseDisplayY;
					return;
				}
				if (this.person.state == 50)
				{
					this.displayX = (this.baseDisplayX - this.targetDisplayX) * num + this.targetDisplayX;
					this.displayY = (this.baseDisplayY - this.targetDisplayY) * num + this.targetDisplayY;
					return;
				}
				this.displayX = this.baseDisplayX;
				this.displayY = this.baseDisplayY;
			}

			// Token: 0x04003F87 RID: 16263
			public long personID;

			// Token: 0x04003F88 RID: 16264
			public PersonData person;

			// Token: 0x04003F89 RID: 16265
			public double displayX;

			// Token: 0x04003F8A RID: 16266
			public double displayY;

			// Token: 0x04003F8B RID: 16267
			public double baseDisplayX;

			// Token: 0x04003F8C RID: 16268
			public double baseDisplayY;

			// Token: 0x04003F8D RID: 16269
			public double targetDisplayX;

			// Token: 0x04003F8E RID: 16270
			public double targetDisplayY;

			// Token: 0x04003F8F RID: 16271
			public double localStartTime;

			// Token: 0x04003F90 RID: 16272
			public double localEndTime;

			// Token: 0x04003F91 RID: 16273
			public DateTime serverEndTime;

			// Token: 0x04003F92 RID: 16274
			public long parentPerson = -1L;

			// Token: 0x04003F93 RID: 16275
			public int childrenCount;

			// Token: 0x04003F94 RID: 16276
			public double lastRatio;

			// Token: 0x04003F95 RID: 16277
			public bool seaTravel;

			// Token: 0x04003F96 RID: 16278
			public bool dying;
		}

		// Token: 0x02000507 RID: 1287
		private class CapitalPeopleGFX
		{
			// Token: 0x04003F97 RID: 16279
			public int numYours;

			// Token: 0x04003F98 RID: 16280
			public int numOthers;

			// Token: 0x04003F99 RID: 16281
			public float posX;

			// Token: 0x04003F9A RID: 16282
			public float posY;
		}

		// Token: 0x02000508 RID: 1288
		public class VillageQuadNode
		{
			// Token: 0x0600332F RID: 13103 RVA: 0x002A5818 File Offset: 0x002A3A18
			public VillageQuadNode(int x, int y, int width, int height, int level)
			{
				this.m_x = x;
				this.m_y = y;
				this.m_width = width;
				this.m_height = height;
				this.m_centreX = width / 2 + x;
				this.m_centreY = height / 2 + y;
				switch (level)
				{
				case 0:
					WorldMap.VillageQuadNode.level0Nodes++;
					return;
				case 1:
					WorldMap.VillageQuadNode.level1Nodes++;
					return;
				case 2:
					WorldMap.VillageQuadNode.level2Nodes++;
					return;
				case 3:
					WorldMap.VillageQuadNode.level3Nodes++;
					return;
				case 4:
					WorldMap.VillageQuadNode.level4Nodes++;
					return;
				case 5:
					WorldMap.VillageQuadNode.level5Nodes++;
					return;
				case 6:
					WorldMap.VillageQuadNode.level6Nodes++;
					return;
				case 7:
					WorldMap.VillageQuadNode.level7Nodes++;
					return;
				case 8:
					WorldMap.VillageQuadNode.level8Nodes++;
					return;
				case 9:
					WorldMap.VillageQuadNode.level9Nodes++;
					return;
				default:
					return;
				}
			}

			// Token: 0x06003330 RID: 13104 RVA: 0x00024C41 File Offset: 0x00022E41
			public void setWorld(WorldMap newWorld)
			{
				WorldMap.VillageQuadNode.world = newWorld;
			}

			// Token: 0x06003331 RID: 13105 RVA: 0x002A5910 File Offset: 0x002A3B10
			public void addVillage(VillageData village, int level)
			{
				if (level < 5)
				{
					if ((int)village.x < this.m_centreX)
					{
						if ((int)village.y < this.m_centreY)
						{
							if (this.m_TL == null)
							{
								this.m_TL = new WorldMap.VillageQuadNode(this.m_x, this.m_y, this.m_width / 2 + 1, this.m_height / 2 + 1, level);
							}
							this.m_TL.addVillage(village, level + 1);
							return;
						}
						if (this.m_BL == null)
						{
							this.m_BL = new WorldMap.VillageQuadNode(this.m_x, this.m_centreY, this.m_width / 2 + 1, this.m_height / 2 + 1, level);
						}
						this.m_BL.addVillage(village, level + 1);
						return;
					}
					else
					{
						if ((int)village.y < this.m_centreY)
						{
							if (this.m_TR == null)
							{
								this.m_TR = new WorldMap.VillageQuadNode(this.m_centreX, this.m_y, this.m_width / 2 + 1, this.m_height / 2 + 1, level);
							}
							this.m_TR.addVillage(village, level + 1);
							return;
						}
						if (this.m_BR == null)
						{
							this.m_BR = new WorldMap.VillageQuadNode(this.m_centreX, this.m_centreY, this.m_width / 2 + 1, this.m_height / 2 + 1, level);
						}
						this.m_BR.addVillage(village, level + 1);
						return;
					}
				}
				else
				{
					this.m_drawLevel = true;
					if (!village.Capital && (!WorldMap.VillageQuadNode.world.aiWorldTreeBuilding || !WorldMap.VillageQuadNode.world.aiWorldSpecialVillages.Contains(village.id)))
					{
						if (this.m_villageList == null)
						{
							this.m_villageList = new List<VillageData>();
						}
						this.m_villageList.Add(village);
						WorldMap.VillageQuadNode.villagesInNodes++;
						return;
					}
					if (this.m_capitalList == null)
					{
						this.m_capitalList = new List<VillageData>();
					}
					if (this.m_parishCapitalList == null)
					{
						this.m_parishCapitalList = new List<VillageData>();
					}
					if (village.regionCapital)
					{
						this.m_parishCapitalList.Add(village);
						WorldMap.VillageQuadNode.parishesInNodes++;
						return;
					}
					this.m_capitalList.Add(village);
					WorldMap.VillageQuadNode.capitalsInNodes++;
					return;
				}
			}

			// Token: 0x06003332 RID: 13106 RVA: 0x002A5B20 File Offset: 0x002A3D20
			public bool isAreaVisible(WorldMap.FastScreenRect screenRect)
			{
				int num = 50;
				return screenRect.top - num <= this.m_y + this.m_height && screenRect.left - num <= this.m_x + this.m_width && screenRect.bottom + num >= this.m_y && screenRect.right + num >= this.m_x;
			}

			// Token: 0x06003333 RID: 13107 RVA: 0x002A5B88 File Offset: 0x002A3D88
			private void drawVillagesInNode(WorldMap.FastScreenRect screenRect)
			{
				foreach (VillageData villageData in this.m_villageList)
				{
					if (villageData.visible)
					{
						float num = ((float)villageData.x - screenRect.Left) / screenRect.Width;
						float num2 = ((float)villageData.y - screenRect.Top) / screenRect.Height;
						if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f)
						{
							WorldMap.VillageQuadNode.world.drawVillage(villageData, (double)num, (double)num2);
						}
					}
				}
			}

			// Token: 0x06003334 RID: 13108 RVA: 0x002A5C38 File Offset: 0x002A3E38
			private void drawVillagesInNodeEditMode(WorldMap.FastScreenRect screenRect)
			{
				foreach (VillageData villageData in this.m_villageList)
				{
					if (villageData.visible || villageData.Capital)
					{
						float num = ((float)villageData.x - screenRect.Left) / screenRect.Width;
						float num2 = ((float)villageData.y - screenRect.Top) / screenRect.Height;
						if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f)
						{
							WorldMap.VillageQuadNode.world.drawVillage(villageData, (double)num, (double)num2);
						}
					}
				}
			}

			// Token: 0x06003335 RID: 13109 RVA: 0x002A5CF0 File Offset: 0x002A3EF0
			private void drawParishesInNode(WorldMap.FastScreenRect screenRect)
			{
				foreach (VillageData villageData in this.m_parishCapitalList)
				{
					if (villageData.visible)
					{
						float num = ((float)villageData.x - screenRect.Left) / screenRect.Width;
						float num2 = ((float)villageData.y - screenRect.Top) / screenRect.Height;
						if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f)
						{
							WorldMap.VillageQuadNode.world.drawVillage(villageData, (double)num, (double)num2);
						}
					}
				}
			}

			// Token: 0x06003336 RID: 13110 RVA: 0x002A5DA0 File Offset: 0x002A3FA0
			private void drawCapitalsInNode(WorldMap.FastScreenRect screenRect)
			{
				foreach (VillageData villageData in this.m_capitalList)
				{
					if (villageData.visible)
					{
						float num = ((float)villageData.x - screenRect.Left) / screenRect.Width;
						float num2 = ((float)villageData.y - screenRect.Top) / screenRect.Height;
						if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f)
						{
							WorldMap.VillageQuadNode.world.drawVillage(villageData, (double)num, (double)num2);
						}
					}
				}
			}

			// Token: 0x06003337 RID: 13111 RVA: 0x002A5E50 File Offset: 0x002A4050
			private void drawCapitalsInNodeEditMode(WorldMap.FastScreenRect screenRect)
			{
				foreach (VillageData villageData in this.m_capitalList)
				{
					if (villageData.visible || villageData.countyCapital)
					{
						float num = ((float)villageData.x - screenRect.Left) / screenRect.Width;
						float num2 = ((float)villageData.y - screenRect.Top) / screenRect.Height;
						if (num >= -0.1f && num <= 1.1f && num2 >= -0.1f && num2 <= 1.1f)
						{
							WorldMap.VillageQuadNode.world.drawVillage(villageData, (double)num, (double)num2);
						}
					}
				}
			}

			// Token: 0x06003338 RID: 13112 RVA: 0x002A5F08 File Offset: 0x002A4108
			public void drawVillages(WorldMap.FastScreenRect screenRect)
			{
				if (this.m_drawLevel)
				{
					double num = 8.0;
					double num2 = 5.0;
					if ((screenRect.zoomLevel >= num || (GameEngine.Instance.World.SeventhAgeWorld && screenRect.zoomLevel >= num2)) && this.m_villageList != null)
					{
						if (!GameEngine.Instance.World.mapEditing)
						{
							this.drawVillagesInNode(screenRect);
						}
						else
						{
							this.drawVillagesInNodeEditMode(screenRect);
						}
					}
					if (screenRect.zoomLevel >= num2 && this.m_parishCapitalList != null)
					{
						this.drawParishesInNode(screenRect);
					}
					if (this.m_capitalList != null)
					{
						if (!GameEngine.Instance.World.mapEditing)
						{
							this.drawCapitalsInNode(screenRect);
							return;
						}
						this.drawCapitalsInNodeEditMode(screenRect);
						return;
					}
				}
				else if (this.isAreaVisible(screenRect))
				{
					if (this.m_TL != null)
					{
						this.m_TL.drawVillages(screenRect);
					}
					if (this.m_TR != null)
					{
						this.m_TR.drawVillages(screenRect);
					}
					if (this.m_BL != null)
					{
						this.m_BL.drawVillages(screenRect);
					}
					if (this.m_BR != null)
					{
						this.m_BR.drawVillages(screenRect);
					}
				}
			}

			// Token: 0x04003F9B RID: 16283
			private static WorldMap world;

			// Token: 0x04003F9C RID: 16284
			public int m_level;

			// Token: 0x04003F9D RID: 16285
			public int m_x;

			// Token: 0x04003F9E RID: 16286
			public int m_y;

			// Token: 0x04003F9F RID: 16287
			public int m_width;

			// Token: 0x04003FA0 RID: 16288
			public int m_height;

			// Token: 0x04003FA1 RID: 16289
			public int m_centreX;

			// Token: 0x04003FA2 RID: 16290
			public int m_centreY;

			// Token: 0x04003FA3 RID: 16291
			public WorldMap.VillageQuadNode m_TL;

			// Token: 0x04003FA4 RID: 16292
			public WorldMap.VillageQuadNode m_TR;

			// Token: 0x04003FA5 RID: 16293
			public WorldMap.VillageQuadNode m_BL;

			// Token: 0x04003FA6 RID: 16294
			public WorldMap.VillageQuadNode m_BR;

			// Token: 0x04003FA7 RID: 16295
			public List<VillageData> m_villageList;

			// Token: 0x04003FA8 RID: 16296
			public List<VillageData> m_capitalList;

			// Token: 0x04003FA9 RID: 16297
			public List<VillageData> m_parishCapitalList;

			// Token: 0x04003FAA RID: 16298
			public bool m_drawLevel;

			// Token: 0x04003FAB RID: 16299
			public bool m_childrenDisplayed;

			// Token: 0x04003FAC RID: 16300
			public static int level0Nodes;

			// Token: 0x04003FAD RID: 16301
			public static int level1Nodes;

			// Token: 0x04003FAE RID: 16302
			public static int level2Nodes;

			// Token: 0x04003FAF RID: 16303
			public static int level3Nodes;

			// Token: 0x04003FB0 RID: 16304
			public static int level4Nodes;

			// Token: 0x04003FB1 RID: 16305
			public static int level5Nodes;

			// Token: 0x04003FB2 RID: 16306
			public static int level6Nodes;

			// Token: 0x04003FB3 RID: 16307
			public static int level7Nodes;

			// Token: 0x04003FB4 RID: 16308
			public static int level8Nodes;

			// Token: 0x04003FB5 RID: 16309
			public static int level9Nodes;

			// Token: 0x04003FB6 RID: 16310
			public static int villagesInNodes;

			// Token: 0x04003FB7 RID: 16311
			public static int parishesInNodes;

			// Token: 0x04003FB8 RID: 16312
			public static int capitalsInNodes;
		}

		// Token: 0x02000509 RID: 1289
		private class ParishChatData
		{
			// Token: 0x06003339 RID: 13113 RVA: 0x002A601C File Offset: 0x002A421C
			public void init()
			{
				for (int i = 0; i < 6; i++)
				{
					this.m_pages[i] = new List<Chat_TextEntry>();
					this.m_readIDs[i] = -1L;
				}
			}

			// Token: 0x0600333A RID: 13114 RVA: 0x002A604C File Offset: 0x002A424C
			public List<Chat_TextEntry> getChatPage(int pageID)
			{
				List<Chat_TextEntry> result = null;
				switch (pageID)
				{
				case 0:
					result = this.m_pages[0];
					break;
				case 1:
					result = this.m_pages[1];
					break;
				case 2:
					result = this.m_pages[2];
					break;
				case 3:
					result = this.m_pages[3];
					break;
				case 4:
					result = this.m_pages[4];
					break;
				case 5:
					result = this.m_pages[5];
					break;
				}
				return result;
			}

			// Token: 0x0600333B RID: 13115 RVA: 0x00024C49 File Offset: 0x00022E49
			public long getReadID(int pageID)
			{
				return this.m_readIDs[pageID];
			}

			// Token: 0x0600333C RID: 13116 RVA: 0x002A60BC File Offset: 0x002A42BC
			public void setReadIDs(long[] readIDs)
			{
				for (int i = 0; i < 6; i++)
				{
					if (this.m_readIDs[i] < readIDs[i])
					{
						this.m_readIDs[i] = readIDs[i];
					}
				}
			}

			// Token: 0x0600333D RID: 13117 RVA: 0x002A60F0 File Offset: 0x002A42F0
			public bool addEntry(Chat_TextEntry textEntry)
			{
				List<Chat_TextEntry> chatPage = this.getChatPage(textEntry.roomID);
				if (chatPage != null)
				{
					foreach (Chat_TextEntry chat_TextEntry in chatPage)
					{
						if (chat_TextEntry.textID == textEntry.textID)
						{
							return false;
						}
					}
					chatPage.Add(textEntry);
					if (textEntry.postedTime > this.m_newestPost)
					{
						this.m_newestPost = textEntry.postedTime;
					}
					return true;
				}
				return false;
			}

			// Token: 0x04003FB9 RID: 16313
			public List<Chat_TextEntry>[] m_pages = new List<Chat_TextEntry>[6];

			// Token: 0x04003FBA RID: 16314
			public DateTime m_newestPost = DateTime.MinValue;

			// Token: 0x04003FBB RID: 16315
			public long[] m_readIDs = new long[6];
		}

		// Token: 0x0200050A RID: 1290
		public class ParishChatComparer : IComparer<Chat_TextEntry>
		{
			// Token: 0x0600333F RID: 13119 RVA: 0x00024C7E File Offset: 0x00022E7E
			public int Compare(Chat_TextEntry x, Chat_TextEntry y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					return y.textID.CompareTo(x.textID);
				}
			}
		}

		// Token: 0x0200050B RID: 1291
		private class ParishWallDonateInfo
		{
			// Token: 0x04003FBC RID: 16316
			public ParishWallDetailInfo_ReturnType returnData;

			// Token: 0x04003FBD RID: 16317
			public DateTime lastUpdateTime = DateTime.MinValue;
		}

		// Token: 0x0200050C RID: 1292
		public class LocalTrader
		{
			// Token: 0x06003342 RID: 13122 RVA: 0x002A6184 File Offset: 0x002A4384
			public PointF BasePoint()
			{
				if (this.trader.traderState == 0 || this.trader.traderState == 1 || this.trader.traderState == 3 || this.trader.traderState == 5)
				{
					return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
				}
				return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
			}

			// Token: 0x06003343 RID: 13123 RVA: 0x002A61F0 File Offset: 0x002A43F0
			public PointF TargetPoint()
			{
				if (this.trader.traderState == 0 || this.trader.traderState == 1 || this.trader.traderState == 3 || this.trader.traderState == 5)
				{
					return new PointF((float)this.targetDisplayX, (float)this.targetDisplayY);
				}
				return new PointF((float)this.baseDisplayX, (float)this.baseDisplayY);
			}

			// Token: 0x06003344 RID: 13124 RVA: 0x002A625C File Offset: 0x002A445C
			public bool isVisible(RectangleF screenRect)
			{
				return (double)(screenRect.Top - 50f) <= this.displayY && (double)(screenRect.Left - 50f) <= this.displayX && (double)(screenRect.Bottom + 50f) >= this.displayY && (double)(screenRect.Right + 50f) >= this.displayX;
			}

			// Token: 0x06003345 RID: 13125 RVA: 0x002A62CC File Offset: 0x002A44CC
			public void createJourney(DateTime startTime, DateTime curTime, DateTime endTime)
			{
				this.serverEndTime = endTime;
				double num = DXTimer.GetCurrentMilliseconds() / 1000.0;
				this.localStartTime = num - (curTime - startTime).TotalSeconds;
				this.localEndTime = num + (endTime - curTime).TotalSeconds;
			}

			// Token: 0x06003346 RID: 13126 RVA: 0x002A6320 File Offset: 0x002A4520
			public void updatePosition(double currentMilliseconds)
			{
				if (this.trader.traderState <= 0)
				{
					this.displayX = this.baseDisplayX;
					this.displayY = this.baseDisplayY;
					return;
				}
				double num = currentMilliseconds / 1000.0;
				double num2 = this.localStartTime + 3.0;
				double num3 = this.localEndTime + 3.0;
				double num4 = (num - num2) / (num3 - num2);
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				if (num4 > 1.0)
				{
					if (this.trader.traderState == 1)
					{
						num4 = 0.0;
						this.trader.traderState++;
						double num5 = this.localEndTime - this.localStartTime;
						this.localStartTime = this.localEndTime;
						this.localEndTime += num5;
						this.serverEndTime = this.serverEndTime.AddSeconds(num5);
						int targetVillageID = this.trader.targetVillageID;
						VillageMap village = GameEngine.Instance.getVillage(targetVillageID);
						if (village != null)
						{
							village.addResources(this.trader.resource, this.trader.amount);
						}
					}
					else if (this.trader.traderState == 3)
					{
						num4 = 0.0;
						this.trader.traderState++;
						double num6 = this.localEndTime - this.localStartTime;
						this.localStartTime = this.localEndTime;
						this.localEndTime += num6;
						this.serverEndTime = this.serverEndTime.AddSeconds(num6);
						int homeVillageID = this.trader.homeVillageID;
						if (GameEngine.Instance.World.isUserVillage(homeVillageID))
						{
							GameEngine.Instance.World.addGold((double)this.trader.goldCost);
						}
					}
					else if (this.trader.traderState == 2 || this.trader.traderState == 4)
					{
						this.dying = true;
						num4 = 0.0;
						this.trader.traderState = 0;
						VillageMap village2 = GameEngine.Instance.getVillage(this.trader.homeVillageID);
						if (village2 != null)
						{
							village2.addTraders(this.trader.numTraders, this.trader.traderID);
						}
					}
					else if (this.trader.traderState == 5)
					{
						num4 = 0.0;
						this.trader.traderState++;
						double num7 = this.localEndTime - this.localStartTime;
						this.localStartTime = this.localEndTime;
						this.localEndTime += num7;
						this.serverEndTime = this.serverEndTime.AddSeconds(num7);
						int targetVillageID2 = this.trader.targetVillageID;
					}
					else if (this.trader.traderState == 6)
					{
						this.dying = true;
						num4 = 0.0;
						this.trader.traderState = 0;
						int homeVillageID2 = this.trader.homeVillageID;
						VillageMap village3 = GameEngine.Instance.getVillage(homeVillageID2);
						if (village3 != null)
						{
							village3.addResources(this.trader.resource, this.trader.amount);
							village3.addTraders(this.trader.numTraders, this.trader.traderID);
						}
					}
				}
				if (num4 < 0.0)
				{
					num4 = 0.0;
				}
				this.lastRatio = num4;
				if (this.trader.traderState == 1 || this.trader.traderState == 3 || this.trader.traderState == 5)
				{
					this.displayX = (this.targetDisplayX - this.baseDisplayX) * num4 + this.baseDisplayX;
					this.displayY = (this.targetDisplayY - this.baseDisplayY) * num4 + this.baseDisplayY;
					return;
				}
				if (this.trader.traderState == 2 || this.trader.traderState == 4 || this.trader.traderState == 6)
				{
					this.displayX = (this.baseDisplayX - this.targetDisplayX) * num4 + this.targetDisplayX;
					this.displayY = (this.baseDisplayY - this.targetDisplayY) * num4 + this.targetDisplayY;
					return;
				}
				this.displayX = this.baseDisplayX;
				this.displayY = this.baseDisplayY;
			}

			// Token: 0x04003FBE RID: 16318
			public long traderID;

			// Token: 0x04003FBF RID: 16319
			public MarketTraderData trader;

			// Token: 0x04003FC0 RID: 16320
			public double displayX;

			// Token: 0x04003FC1 RID: 16321
			public double displayY;

			// Token: 0x04003FC2 RID: 16322
			public double baseDisplayX;

			// Token: 0x04003FC3 RID: 16323
			public double baseDisplayY;

			// Token: 0x04003FC4 RID: 16324
			public double targetDisplayX;

			// Token: 0x04003FC5 RID: 16325
			public double targetDisplayY;

			// Token: 0x04003FC6 RID: 16326
			public double localStartTime;

			// Token: 0x04003FC7 RID: 16327
			public double localEndTime;

			// Token: 0x04003FC8 RID: 16328
			public DateTime serverEndTime;

			// Token: 0x04003FC9 RID: 16329
			public long parentTrader = -1L;

			// Token: 0x04003FCA RID: 16330
			public double lastRatio;

			// Token: 0x04003FCB RID: 16331
			public bool dying;

			// Token: 0x04003FCC RID: 16332
			public bool seaTravel;
		}

		// Token: 0x0200050D RID: 1293
		public class WorldPoint
		{
			// Token: 0x170002AC RID: 684
			// (get) Token: 0x06003348 RID: 13128 RVA: 0x00024CC3 File Offset: 0x00022EC3
			// (set) Token: 0x06003349 RID: 13129 RVA: 0x00024CCC File Offset: 0x00022ECC
			public float x
			{
				get
				{
					return (float)this.mx;
				}
				set
				{
					this.mx = (short)value;
				}
			}

			// Token: 0x170002AD RID: 685
			// (get) Token: 0x0600334A RID: 13130 RVA: 0x00024CD6 File Offset: 0x00022ED6
			// (set) Token: 0x0600334B RID: 13131 RVA: 0x00024CDF File Offset: 0x00022EDF
			public float y
			{
				get
				{
					return (float)this.my;
				}
				set
				{
					this.my = (short)value;
				}
			}

			// Token: 0x04003FCD RID: 16333
			public short mx;

			// Token: 0x04003FCE RID: 16334
			public short my;
		}

		// Token: 0x0200050E RID: 1294
		public class Triangle
		{
			// Token: 0x170002AE RID: 686
			// (get) Token: 0x0600334D RID: 13133 RVA: 0x00024CE9 File Offset: 0x00022EE9
			// (set) Token: 0x0600334E RID: 13134 RVA: 0x00024CF2 File Offset: 0x00022EF2
			public float x1
			{
				get
				{
					return (float)this.mx1;
				}
				set
				{
					this.mx1 = (short)value;
				}
			}

			// Token: 0x170002AF RID: 687
			// (get) Token: 0x0600334F RID: 13135 RVA: 0x00024CFC File Offset: 0x00022EFC
			// (set) Token: 0x06003350 RID: 13136 RVA: 0x00024D05 File Offset: 0x00022F05
			public float y1
			{
				get
				{
					return (float)this.my1;
				}
				set
				{
					this.my1 = (short)value;
				}
			}

			// Token: 0x170002B0 RID: 688
			// (get) Token: 0x06003351 RID: 13137 RVA: 0x00024D0F File Offset: 0x00022F0F
			// (set) Token: 0x06003352 RID: 13138 RVA: 0x00024D18 File Offset: 0x00022F18
			public float x2
			{
				get
				{
					return (float)this.mx2;
				}
				set
				{
					this.mx2 = (short)value;
				}
			}

			// Token: 0x170002B1 RID: 689
			// (get) Token: 0x06003353 RID: 13139 RVA: 0x00024D22 File Offset: 0x00022F22
			// (set) Token: 0x06003354 RID: 13140 RVA: 0x00024D2B File Offset: 0x00022F2B
			public float y2
			{
				get
				{
					return (float)this.my2;
				}
				set
				{
					this.my2 = (short)value;
				}
			}

			// Token: 0x170002B2 RID: 690
			// (get) Token: 0x06003355 RID: 13141 RVA: 0x00024D35 File Offset: 0x00022F35
			// (set) Token: 0x06003356 RID: 13142 RVA: 0x00024D3E File Offset: 0x00022F3E
			public float x3
			{
				get
				{
					return (float)this.mx3;
				}
				set
				{
					this.mx3 = (short)value;
				}
			}

			// Token: 0x170002B3 RID: 691
			// (get) Token: 0x06003357 RID: 13143 RVA: 0x00024D48 File Offset: 0x00022F48
			// (set) Token: 0x06003358 RID: 13144 RVA: 0x00024D51 File Offset: 0x00022F51
			public float y3
			{
				get
				{
					return (float)this.my3;
				}
				set
				{
					this.my3 = (short)value;
				}
			}

			// Token: 0x04003FCF RID: 16335
			public short mx1;

			// Token: 0x04003FD0 RID: 16336
			public short my1;

			// Token: 0x04003FD1 RID: 16337
			public short mx2;

			// Token: 0x04003FD2 RID: 16338
			public short my2;

			// Token: 0x04003FD3 RID: 16339
			public short mx3;

			// Token: 0x04003FD4 RID: 16340
			public short my3;
		}

		// Token: 0x0200050F RID: 1295
		public class WorldPointList
		{
			// Token: 0x0600335A RID: 13146 RVA: 0x002A677C File Offset: 0x002A497C
			public void updateBounds(WorldMap.WorldPoint wp)
			{
				if (wp.x < this.minX)
				{
					this.minX = wp.x;
				}
				if (wp.y < this.minY)
				{
					this.minY = wp.y;
				}
				if (wp.x > this.maxX)
				{
					this.maxX = wp.x;
				}
				if (wp.y > this.maxY)
				{
					this.maxY = wp.y;
				}
			}

			// Token: 0x0600335B RID: 13147 RVA: 0x002A67F4 File Offset: 0x002A49F4
			public void updateBoundsFromTriangles()
			{
				WorldMap.Triangle[] array = this.triangleList;
				foreach (WorldMap.Triangle triangle in array)
				{
					if (triangle.x1 < this.minX)
					{
						this.minX = triangle.x1;
					}
					if (triangle.x2 < this.minX)
					{
						this.minX = triangle.x2;
					}
					if (triangle.x3 < this.minX)
					{
						this.minX = triangle.x3;
					}
					if (triangle.y1 < this.minY)
					{
						this.minY = triangle.y1;
					}
					if (triangle.y2 < this.minY)
					{
						this.minY = triangle.y2;
					}
					if (triangle.y3 < this.minY)
					{
						this.minY = triangle.y3;
					}
					if (triangle.x1 > this.maxX)
					{
						this.maxX = triangle.x1;
					}
					if (triangle.x2 > this.maxX)
					{
						this.maxX = triangle.x2;
					}
					if (triangle.x3 > this.maxX)
					{
						this.maxX = triangle.x3;
					}
					if (triangle.y1 > this.maxY)
					{
						this.maxY = triangle.y1;
					}
					if (triangle.y2 > this.maxY)
					{
						this.maxY = triangle.y2;
					}
					if (triangle.y3 > this.maxY)
					{
						this.maxY = triangle.y3;
					}
				}
			}

			// Token: 0x0600335C RID: 13148 RVA: 0x00024D5B File Offset: 0x00022F5B
			public bool PointWithinBounds(WorldMap.WorldPoint candidate)
			{
				return candidate.x >= this.minX && candidate.x <= this.maxX && candidate.y >= this.minY && candidate.y <= this.maxY;
			}

			// Token: 0x0600335D RID: 13149 RVA: 0x002A695C File Offset: 0x002A4B5C
			public bool PointWithinRegion(WorldMap.WorldPoint candidate)
			{
				if (this.PointWithinBounds(candidate))
				{
					int num = 0;
					for (int i = 0; i < this.regionBorderList.Length; i++)
					{
						WorldMap.WorldPoint worldPoint = this.regionBorderList[i];
						WorldMap.WorldPoint worldPoint2 = (i >= this.regionBorderList.Length - 1) ? this.regionBorderList[0] : this.regionBorderList[i + 1];
						float num2 = Math.Min(worldPoint.y, worldPoint2.y);
						float num3 = Math.Max(worldPoint.y, worldPoint2.y);
						if (candidate.y >= num2 && candidate.y <= num3 && (worldPoint.x >= candidate.x || worldPoint2.x >= candidate.x))
						{
							float num4 = (worldPoint2.y - worldPoint.y) / worldPoint2.x - worldPoint.x;
							float num5 = worldPoint.y - num4 * worldPoint.x;
							float num6 = (candidate.y - num5) / num4;
							if (num6 >= candidate.x)
							{
								num++;
							}
						}
					}
					return num % 2 == 1;
				}
				return false;
			}

			// Token: 0x0600335E RID: 13150 RVA: 0x002A6A64 File Offset: 0x002A4C64
			public PointF getCentrePoint()
			{
				return new PointF
				{
					X = (this.maxX - this.minX) / 2f + this.minX,
					Y = (this.maxY - this.minY) / 2f + this.minY
				};
			}

			// Token: 0x0600335F RID: 13151 RVA: 0x002A6ABC File Offset: 0x002A4CBC
			public bool isVisible(RectangleF screenRect)
			{
				return this.maxX >= screenRect.Left && this.minX <= screenRect.Right && this.minY <= screenRect.Bottom && this.maxY >= screenRect.Top;
			}

			// Token: 0x04003FD5 RID: 16341
			public int parentID = -1;

			// Token: 0x04003FD6 RID: 16342
			public int capitalVillage = -1;

			// Token: 0x04003FD7 RID: 16343
			public int data;

			// Token: 0x04003FD8 RID: 16344
			public int factionID;

			// Token: 0x04003FD9 RID: 16345
			public int userID;

			// Token: 0x04003FDA RID: 16346
			public bool rebuiltBorderList;

			// Token: 0x04003FDB RID: 16347
			public int[] borderList;

			// Token: 0x04003FDC RID: 16348
			public int[] childList;

			// Token: 0x04003FDD RID: 16349
			public WorldMap.Triangle[] triangleList;

			// Token: 0x04003FDE RID: 16350
			public WorldMap.WorldPoint[] regionBorderList;

			// Token: 0x04003FDF RID: 16351
			public Point marker = new Point(-1, -1);

			// Token: 0x04003FE0 RID: 16352
			public int experimentalColourVariant;

			// Token: 0x04003FE1 RID: 16353
			public string areaName = "";

			// Token: 0x04003FE2 RID: 16354
			public int plague;

			// Token: 0x04003FE3 RID: 16355
			public float minX = 100000000f;

			// Token: 0x04003FE4 RID: 16356
			public float minY = 100000000f;

			// Token: 0x04003FE5 RID: 16357
			public float maxX = -100000000f;

			// Token: 0x04003FE6 RID: 16358
			public float maxY = -100000000f;

			// Token: 0x04003FE7 RID: 16359
			private PointF centroid = PointF.Empty;
		}

		// Token: 0x02000510 RID: 1296
		public class IslandInfoList
		{
			// Token: 0x04003FE8 RID: 16360
			public int villageID = -1;

			// Token: 0x04003FE9 RID: 16361
			public int county = -1;

			// Token: 0x04003FEA RID: 16362
			public int province = -1;

			// Token: 0x04003FEB RID: 16363
			public int country = -1;

			// Token: 0x04003FEC RID: 16364
			public int sx;

			// Token: 0x04003FED RID: 16365
			public int sy;

			// Token: 0x04003FEE RID: 16366
			public int ex;

			// Token: 0x04003FEF RID: 16367
			public int ey;
		}

		// Token: 0x02000511 RID: 1297
		public class VillageRolloverInfo
		{
			// Token: 0x04003FF0 RID: 16368
			public DateTime lastUpdateTime = DateTime.Now.AddYears(-1);

			// Token: 0x04003FF1 RID: 16369
			public DateTime interdictionTime = DateTime.MinValue;

			// Token: 0x04003FF2 RID: 16370
			public DateTime peaceTime = DateTime.MinValue;

			// Token: 0x04003FF3 RID: 16371
			public bool vacationMode;

			// Token: 0x04003FF4 RID: 16372
			public string villageName = "";

			// Token: 0x04003FF5 RID: 16373
			public int villageID = -1;

			// Token: 0x04003FF6 RID: 16374
			public int plagueLevel = -1;
		}

		// Token: 0x02000512 RID: 1298
		public class CachedUserInfo
		{
			// Token: 0x06003363 RID: 13155 RVA: 0x002A6BD8 File Offset: 0x002A4DD8
			~CachedUserInfo()
			{
				if (this.avatarBitmap != null)
				{
					this.avatarBitmap.Dispose();
				}
			}

			// Token: 0x04003FF7 RID: 16375
			public DateTime lastUpdateTime = DateTime.Now.AddYears(-1);

			// Token: 0x04003FF8 RID: 16376
			public int userID = -1;

			// Token: 0x04003FF9 RID: 16377
			public string userName = "";

			// Token: 0x04003FFA RID: 16378
			public double honour = -1.0;

			// Token: 0x04003FFB RID: 16379
			public double gold = -1.0;

			// Token: 0x04003FFC RID: 16380
			public int rank;

			// Token: 0x04003FFD RID: 16381
			public int points;

			// Token: 0x04003FFE RID: 16382
			public int standing;

			// Token: 0x04003FFF RID: 16383
			public int numVillages;

			// Token: 0x04004000 RID: 16384
			public int factionID = -1;

			// Token: 0x04004001 RID: 16385
			public AvatarData avatarData;

			// Token: 0x04004002 RID: 16386
			public Bitmap avatarBitmap;

			// Token: 0x04004003 RID: 16387
			public int[] villages;

			// Token: 0x04004004 RID: 16388
			public List<int> achievements;

			// Token: 0x04004005 RID: 16389
			public int numQuests;

			// Token: 0x04004006 RID: 16390
			public List<int> completedQuests;

			// Token: 0x04004007 RID: 16391
			public bool admin;

			// Token: 0x04004008 RID: 16392
			public bool moderator;

			// Token: 0x04004009 RID: 16393
			public string stuff = "";
		}

		// Token: 0x02000513 RID: 1299
		public class FactionPointsComparer : IComparer<FactionData>
		{
			// Token: 0x06003365 RID: 13157 RVA: 0x0011C73C File Offset: 0x0011A93C
			public int Compare(FactionData x, FactionData y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.points > y.points)
					{
						return -1;
					}
					if (x.points < y.points)
					{
						return 1;
					}
					return x.factionName.CompareTo(y.factionName);
				}
			}
		}

		// Token: 0x02000514 RID: 1300
		public class SpecialVillageCache
		{
			// Token: 0x0400400A RID: 16394
			public DateTime lastUpdate = DateTime.Now;

			// Token: 0x0400400B RID: 16395
			public int resourceLevel;

			// Token: 0x0400400C RID: 16396
			public int resourceType;
		}

		// Token: 0x02000515 RID: 1301
		private class ShieldTextureCacheEntry
		{
			// Token: 0x0400400D RID: 16397
			public int index = -1;

			// Token: 0x0400400E RID: 16398
			public int playerID = -10000;

			// Token: 0x0400400F RID: 16399
			public int textureID = -1;

			// Token: 0x04004010 RID: 16400
			public DateTime lastUsage = DateTime.MinValue;
		}

		// Token: 0x02000516 RID: 1302
		public struct AvailableCounty
		{
			// Token: 0x04004011 RID: 16401
			public int countyID;

			// Token: 0x04004012 RID: 16402
			public int available;

			// Token: 0x04004013 RID: 16403
			public int total;

			// Token: 0x04004014 RID: 16404
			public int maturity;
		}

		// Token: 0x02000517 RID: 1303
		public class FastScreenRect
		{
			// Token: 0x04004015 RID: 16405
			public int left;

			// Token: 0x04004016 RID: 16406
			public int top;

			// Token: 0x04004017 RID: 16407
			public int right;

			// Token: 0x04004018 RID: 16408
			public int bottom;

			// Token: 0x04004019 RID: 16409
			public float Left;

			// Token: 0x0400401A RID: 16410
			public float Top;

			// Token: 0x0400401B RID: 16411
			public float Width;

			// Token: 0x0400401C RID: 16412
			public float Height;

			// Token: 0x0400401D RID: 16413
			public double zoomLevel;
		}

		// Token: 0x02000518 RID: 1304
		public class MapText
		{
			// Token: 0x0400401E RID: 16414
			public string text = "";

			// Token: 0x0400401F RID: 16415
			public int size = 1;

			// Token: 0x04004020 RID: 16416
			public bool centered;

			// Token: 0x04004021 RID: 16417
			public Color col = global::ARGBColors.Black;

			// Token: 0x04004022 RID: 16418
			public PointF loc;

			// Token: 0x04004023 RID: 16419
			public bool bordered;

			// Token: 0x04004024 RID: 16420
			public WorldMap.MapTextType type = WorldMap.MapTextType.DEBUG;

			// Token: 0x04004025 RID: 16421
			public WorldMap.WorldPointList wpl;

			// Token: 0x04004026 RID: 16422
			public bool preAdjustedForRetina;
		}

		// Token: 0x02000519 RID: 1305
		public enum MapTextType
		{
			// Token: 0x04004028 RID: 16424
			PARISH,
			// Token: 0x04004029 RID: 16425
			COUNTY,
			// Token: 0x0400402A RID: 16426
			PROVINCE,
			// Token: 0x0400402B RID: 16427
			COUNTRY,
			// Token: 0x0400402C RID: 16428
			DEBUG
		}

		// Token: 0x0200051A RID: 1306
		public class InterVillageLinesStyles
		{
			// Token: 0x0400402D RID: 16429
			public const int VASSAL_BLUE = 1;

			// Token: 0x0400402E RID: 16430
			public const int VASSAL_GREEN = 2;

			// Token: 0x0400402F RID: 16431
			public const int VASSAL_LIGHTGREEN = 3;

			// Token: 0x04004030 RID: 16432
			public const int VASSAL_LIGHTRED = 4;

			// Token: 0x04004031 RID: 16433
			public const int SELECT_GREEN_YELLOW_TAPER = 5;

			// Token: 0x04004032 RID: 16434
			public const int SELECT_GREEN_YELLOW_TAPER_PULSE = 6;
		}

		// Token: 0x0200051B RID: 1307
		private class InterVillageLine
		{
			// Token: 0x04004033 RID: 16435
			public PointF start;

			// Token: 0x04004034 RID: 16436
			public PointF end;

			// Token: 0x04004035 RID: 16437
			public int style = 1;

			// Token: 0x04004036 RID: 16438
			public float widthScalar = 1.1f;

			// Token: 0x04004037 RID: 16439
			public bool minLength = true;
		}

		// Token: 0x0200051C RID: 1308
		// (Invoke) Token: 0x0600336E RID: 13166
		public delegate void WorldZoomCallback(double newWorldZoom, bool redraw);

		// Token: 0x0200051D RID: 1309
		public class LeaderboardSelfRankingsComparer : IComparer<LeaderBoardSelfRankings>
		{
			// Token: 0x06003371 RID: 13169 RVA: 0x002A6C80 File Offset: 0x002A4E80
			public int Compare(LeaderBoardSelfRankings y, LeaderBoardSelfRankings x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.value == 0)
					{
						if (y.value == 0)
						{
							return 0;
						}
						return -1;
					}
					else
					{
						if (y.value == 0)
						{
							return 1;
						}
						if (x.place < y.place)
						{
							return 1;
						}
						if (x.place > y.place)
						{
							return -1;
						}
						return 0;
					}
				}
			}
		}

		// Token: 0x0200051E RID: 1310
		public class LeaderboardSelfStaticComparer : IComparer<LeaderBoardSelfRankings>
		{
			// Token: 0x06003373 RID: 13171 RVA: 0x00024E4A File Offset: 0x0002304A
			public int Compare(LeaderBoardSelfRankings y, LeaderBoardSelfRankings x)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				else
				{
					if (y == null)
					{
						return 1;
					}
					if (x.category < y.category)
					{
						return 1;
					}
					if (x.category > y.category)
					{
						return -1;
					}
					return 0;
				}
			}
		}
	}
}
