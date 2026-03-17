using System;

namespace Kingdoms
{
	// Token: 0x020004D0 RID: 1232
	public class VillageData
	{
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06002D87 RID: 11655 RVA: 0x00021729 File Offset: 0x0001F929
		// (set) Token: 0x06002D88 RID: 11656 RVA: 0x00243440 File Offset: 0x00241640
		public DateTime interdictionTime
		{
			get
			{
				if (this.m_extendedInfo == null)
				{
					return DateTime.MinValue;
				}
				return this.m_extendedInfo.interdictionTime;
			}
			set
			{
				if (value != DateTime.MinValue || (this.m_extendedInfo != null && value == DateTime.MinValue))
				{
					if (this.m_extendedInfo == null)
					{
						this.m_extendedInfo = new VillageDataExtendedInfo();
					}
					this.m_extendedInfo.interdictionTime = value;
				}
			}
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06002D89 RID: 11657 RVA: 0x00021744 File Offset: 0x0001F944
		// (set) Token: 0x06002D8A RID: 11658 RVA: 0x00243490 File Offset: 0x00241690
		public DateTime peaceTime
		{
			get
			{
				if (this.m_extendedInfo == null)
				{
					return DateTime.MinValue;
				}
				return this.m_extendedInfo.peaceTime;
			}
			set
			{
				if (value != DateTime.MinValue || (this.m_extendedInfo != null && value == DateTime.MinValue))
				{
					if (this.m_extendedInfo == null)
					{
						this.m_extendedInfo = new VillageDataExtendedInfo();
					}
					this.m_extendedInfo.peaceTime = value;
				}
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06002D8B RID: 11659 RVA: 0x0002175F File Offset: 0x0001F95F
		// (set) Token: 0x06002D8C RID: 11660 RVA: 0x002434E0 File Offset: 0x002416E0
		public DateTime excommunicationTime
		{
			get
			{
				if (this.m_extendedInfo == null)
				{
					return DateTime.MinValue;
				}
				return this.m_extendedInfo.excommunicationTime;
			}
			set
			{
				if (value != DateTime.MinValue || (this.m_extendedInfo != null && value == DateTime.MinValue))
				{
					if (this.m_extendedInfo == null)
					{
						this.m_extendedInfo = new VillageDataExtendedInfo();
					}
					this.m_extendedInfo.excommunicationTime = value;
				}
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06002D8D RID: 11661 RVA: 0x00243530 File Offset: 0x00241730
		// (set) Token: 0x06002D8E RID: 11662 RVA: 0x0002177A File Offset: 0x0001F97A
		public string villageName
		{
			get
			{
				if (Program.mySettings.viewVillageIDs && !this.Capital)
				{
					return "[" + this.id.ToString() + "] " + this.m_villageName;
				}
				if (Program.mySettings.viewCapitalIDs && this.Capital)
				{
					return "[" + this.id.ToString() + "] " + this.m_villageName;
				}
				return this.m_villageName;
			}
			set
			{
				this.m_villageName = value;
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06002D8F RID: 11663 RVA: 0x00021783 File Offset: 0x0001F983
		public bool Capital
		{
			get
			{
				return this.regionCapital | this.countyCapital | this.provinceCapital | this.countryCapital;
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06002D90 RID: 11664 RVA: 0x000217A0 File Offset: 0x0001F9A0
		public bool isAICastle
		{
			get
			{
				return this.special == 7 || this.special == 11 || this.special == 9 || this.special == 13;
			}
		}

		// Token: 0x040038AC RID: 14508
		public int id = -1;

		// Token: 0x040038AD RID: 14509
		public short x = -1;

		// Token: 0x040038AE RID: 14510
		public short y = -1;

		// Token: 0x040038AF RID: 14511
		public short countyID = -1;

		// Token: 0x040038B0 RID: 14512
		public short regionID = -1;

		// Token: 0x040038B1 RID: 14513
		public bool regionCapital;

		// Token: 0x040038B2 RID: 14514
		public bool countyCapital;

		// Token: 0x040038B3 RID: 14515
		public bool provinceCapital;

		// Token: 0x040038B4 RID: 14516
		public bool countryCapital;

		// Token: 0x040038B5 RID: 14517
		public bool visible;

		// Token: 0x040038B6 RID: 14518
		public byte villageInfo;

		// Token: 0x040038B7 RID: 14519
		private VillageDataExtendedInfo m_extendedInfo;

		// Token: 0x040038B8 RID: 14520
		public bool vacationMode;

		// Token: 0x040038B9 RID: 14521
		public int factionID = 1;

		// Token: 0x040038BA RID: 14522
		public int userID = 1;

		// Token: 0x040038BB RID: 14523
		public int connecter = -1;

		// Token: 0x040038BC RID: 14524
		public int special;

		// Token: 0x040038BD RID: 14525
		public int userVillageID = -1;

		// Token: 0x040038BE RID: 14526
		public string m_villageName = "";

		// Token: 0x040038BF RID: 14527
		public short villageTerrain;

		// Token: 0x040038C0 RID: 14528
		public bool whiteName;

		// Token: 0x040038C1 RID: 14529
		public bool whiteFlags;

		// Token: 0x040038C2 RID: 14530
		public bool userRelatedVillage;

		// Token: 0x040038C3 RID: 14531
		public bool notDuplicate = true;

		// Token: 0x040038C4 RID: 14532
		public short numFlags;

		// Token: 0x040038C5 RID: 14533
		public WorldMap.VillageRolloverInfo rolloverInfo;
	}
}
